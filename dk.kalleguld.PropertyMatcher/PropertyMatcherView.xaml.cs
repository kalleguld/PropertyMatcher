using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using dk.kalleguld.PropertyMatcher.ViewModel;

namespace dk.kalleguld.PropertyMatcher.View
{
    public partial class PropertyMatcherView : UserControl
    {
        private static readonly Point OriginPoint = new Point(0, 0);

        private const string DataFormatName = "viewModel.InputProperty";

        private PropertyMatcherViewModel _viewModel;
        private PropertyMatcherViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel != null)
                {
                    Unsubscribe(_viewModel);
                }
                _viewModel = value;
                if (_viewModel != null)
                {
                    Subscribe(_viewModel);
                }
            }
        }


        private Dictionary<Field, Path> ConnectionPaths = new Dictionary<Field, Path>();


        public PropertyMatcherView()
        {
            InitializeComponent();
            ViewModel = this.DataContext as PropertyMatcherViewModel;
        }


        private void Subscribe(PropertyMatcherViewModel viewModel)
        {
            viewModel.InputFields.CollectionChanged += viewModel_CollectionChanged;
            viewModel.OutputFields.CollectionChanged += viewModel_CollectionChanged;
            viewModel.Connections.CollectionChanged += viewModel_CollectionChanged;
            viewModel.Connections.CollectionChanged += connections_collectionChanged;
            foreach (var conn in viewModel.Connections)
            {
                conn.PropertyChanged += connection_PropertyChanged;
            }
        }

        private void connections_collectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
            {
                foreach (var oldObj in e.OldItems)
                {
                    var oldConn = (Connection)oldObj;
                    oldConn.PropertyChanged -= connection_PropertyChanged;
                }
            }
            if (e.NewItems != null)
            {
                foreach (var newObj in e.NewItems)
                {
                    var newConn = (Connection)newObj;
                    newConn.PropertyChanged += connection_PropertyChanged;
                }
            }

        }

        private void Unsubscribe(PropertyMatcherViewModel viewModel)
        {
            viewModel.InputFields.CollectionChanged -= viewModel_CollectionChanged;
            viewModel.OutputFields.CollectionChanged -= viewModel_CollectionChanged;
            viewModel.Connections.CollectionChanged -= viewModel_CollectionChanged;
            viewModel.Connections.CollectionChanged -= connections_collectionChanged;

            foreach (var conn in viewModel.Connections)
            {
                conn.PropertyChanged -= connection_PropertyChanged;
            }
        }

        private void ClearAllPaths()
        {
            ConnectorCanvas.Children.Clear();
            ConnectionPaths.Clear();
        }



        private void UpdateAllPaths()
        {
            ClearAllPaths();
            for (int i = 0; i < OutputsGrid.Items.Count; i++)
            {
                var row = (FrameworkElement)OutputsGrid.ItemContainerGenerator
                        .ContainerFromIndex(i);
                AddPath(row);
            }
        }

        private void ClearPath(Connection connection)
        {
            Path path;
            if (ConnectionPaths.TryGetValue(connection.Output, out path))
            {
                ConnectorCanvas.Children.Remove(path);
                ConnectionPaths.Remove(connection.Output);
            }
            connection.Output.PropertyChanged -= OutputProperty_PropertyChanged;
        }

        private void AddPath(Connection connection)
        {
            for (int i = 0; i < OutputsGrid.Items.Count; i++)
            {
                FrameworkElement row = (FrameworkElement)OutputsGrid.ItemContainerGenerator
                        .ContainerFromIndex(i);
                var rowProperty = row.DataContext as ViewModel.Field;
                if (rowProperty == connection.Output)
                {
                    AddPath(row);
                    break;
                }
            }
        }

        private void AddPath(FrameworkElement outputElement)
        {
            var outputProperty = outputElement.DataContext as ViewModel.Field;
            outputProperty.PropertyChanged += OutputProperty_PropertyChanged;

            var connection = ViewModel?.Connections.FirstOrDefault(conn => conn.Output == outputProperty);

            if (connection == null)
                return;

            var inputRow = GetInputRow(connection.Input);

            Path path = GetConnectingPath(inputRow, outputElement, MainGrid, connection);

            ConnectorCanvas.Children.Add(path);
            ConnectionPaths.Add(outputProperty, path);


        }

        private Path GetConnectingPath(FrameworkElement inputElement, FrameworkElement outputElement, Visual commonAncestor, Connection connection)
        {
            var inputTopLeft = inputElement.TransformToAncestor(commonAncestor).Transform(OriginPoint);
            var inputMiddleRight = inputTopLeft + new Vector(
                inputElement.ActualWidth,
                inputElement.ActualHeight / 2);

            var outputTopLeft = outputElement.TransformToAncestor(commonAncestor).Transform(OriginPoint);
            var outputMidleLeft = outputTopLeft + new Vector(
                0,
                outputElement.ActualHeight / 2);

            var midX = (inputMiddleRight.X + outputMidleLeft.X) / 2;
            var midPointA = new Point(midX, inputMiddleRight.Y);
            var midPointB = new Point(midX, outputMidleLeft.Y);

            var bezierSegment = new BezierSegment(midPointA, midPointB, outputMidleLeft, true);
            var pathFigure = new PathFigure(
                inputMiddleRight,
                new List<PathSegment> { bezierSegment },
                closed: false);
            var pathGeometry = new PathGeometry(new List<PathFigure> { pathFigure });
            var path = new Path
            {
                Data = pathGeometry,
                Stroke = GetBrush(connection),
                StrokeThickness = GetStrokeThickness(connection),
            };
            return path;
        }

        private double GetStrokeThickness(Connection connection)
        {
            switch (connection.SelectionStatus)
            {
                default:
                case SelectionStatus.NotSelected:
                    return 1;
                case SelectionStatus.ConnectionSelected:
                    return 3;
                case SelectionStatus.Selected:
                    return 5;
            }
        }

        private Brush GetBrush(Connection connection)
        {
            switch (connection.CreatedBy)
            {
                case Connection.Creator.User:
                    return Brushes.Blue;
                case Connection.Creator.Auto:
                default:
                    return Brushes.Red;
            }
        }

        private ListBoxItem GetInputRow(Field inputProperty)
        {
            var container = InputsGrid.ItemContainerGenerator.ContainerFromItem(inputProperty);
            return (ListBoxItem)container;
        }


        #region Actions


        private void viewModel_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateAllPaths();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateAllPaths();
        }


        private void OutputProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var outputProperty = (Field)sender;
            var connection = ViewModel?.Connections.FirstOrDefault(conn => conn.Output == outputProperty);
            if (connection == null)
                return;
            ClearPath(connection);
            AddPath(connection);
        }

        #region UserControl Actions


        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateAllPaths();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAllPaths();
        }


        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ViewModel = e.NewValue as PropertyMatcherViewModel;
            UpdateAllPaths();
        }

        #endregion UserControl Actions

        #endregion actions

        #region DragDrop


        private Point? _mouseDragStart = null;
        private Field _draggingInputProperty = null;

        private void MainGrid_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
            {
                _mouseDragStart = null;
                _draggingInputProperty = null;
            }
            else if (_mouseDragStart.HasValue && _draggingInputProperty != null)
            {
                Point mousePos = e.GetPosition(null);
                Vector diff = _mouseDragStart.Value - mousePos;
                if (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance && 
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    var originalSource = (DependencyObject)e.OriginalSource;
                    DataObject viewModelData = new DataObject(DataFormatName, _draggingInputProperty);
                    DragDrop.DoDragDrop(originalSource, viewModelData, DragDropEffects.Link);
                }
            }

        }

        private void LeftGrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _mouseDragStart = e.GetPosition(null);
            _draggingInputProperty = ((sender as FrameworkElement)?.DataContext) as Field;

        }

        private void FieldGrid_DragEnter(object sender, DragEventArgs e)
        {
            DragDropEffects effect;
            if (!e.Data.GetDataPresent(DataFormatName))
            {
                effect = DragDropEffects.None;
            }
            else
            {

                var draggedField = e.Data.GetData(DataFormatName) as Field;
                var dropTarget = ((sender as FrameworkElement)?.DataContext) as Field;

                if (draggedField == null || dropTarget == null)
                {
                    effect = DragDropEffects.None;
                }
                else if (ViewModel.IsConnectable(draggedField, dropTarget))
                {
                    effect = DragDropEffects.Link;
                }
                else
                {
                    effect = DragDropEffects.None;
                }
            }
            e.Effects = effect;
        }

        private void RightGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormatName))
            {
                var draggedField = e.Data.GetData(DataFormatName) as Field;
                var dropTarget = sender as Field;
                var outputPropertyElement = (FrameworkElement)sender;
                var inputField = (Field)e.Data.GetData(DataFormatName);
                var outputField = outputPropertyElement.DataContext as Field;
                ViewModel?.AddConnection(inputField, outputField,  Connection.Creator.User);
            }
        }

        #endregion DragDrop


        private bool _selectionChanging = false;

        private void Properties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (_selectionChanging)
                return;
            _selectionChanging = true;

            IEnumerable<ISelectable> selection;

            if (sender == InputsGrid)
            {
                OutputsGrid.SelectedItem = null;
                selection = InputsGrid.SelectedItems.Cast<ISelectable>();
            }
            else
            {
                InputsGrid.SelectedItem = null;
                selection = OutputsGrid.SelectedItems.Cast<ISelectable>();
            }
            ViewModel.Selection = selection;

            _selectionChanging = false;
        }

        private void connection_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var connection = (Connection)sender;
            ClearPath(connection);
            AddPath(connection);
        }

        private void FieldList_LostFocus(object sender, RoutedEventArgs e)
        {
            var grid = (System.Windows.Controls.Primitives.Selector)sender;
            grid.SelectedItem = null;
        }
    }
}
