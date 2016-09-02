using System;
using System.Collections.Generic;
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

        private readonly HashSet<ViewModel.OutputProperty> SubscribedOutputProperties = new HashSet<ViewModel.OutputProperty>();

        private Dictionary<ViewModel.OutputProperty, Path> ConnectionPaths = new Dictionary<ViewModel.OutputProperty, Path>();

        public PropertyMatcherView()
        {
            InitializeComponent();
        }



        private void ClearAllPaths()
        {
            ConnectorCanvas.Children.Clear();
            ConnectionPaths.Clear();
            foreach (var outputProperty in SubscribedOutputProperties)
            {
                outputProperty.PropertyChanged -= OutputProperty_PropertyChanged;
            }
            SubscribedOutputProperties.Clear();
        }



        private void UpdateAllPaths()
        {
            ClearAllPaths();
            for (int i = 0; i < OutputsGrid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)OutputsGrid.ItemContainerGenerator
                        .ContainerFromIndex(i);
                AddPath(row);
            }
        }

        private void ClearPath(ViewModel.OutputProperty outputProperty)
        {
            Path path;
            if (ConnectionPaths.TryGetValue(outputProperty, out path))
            {
                ConnectorCanvas.Children.Remove(path);
                ConnectionPaths.Remove(outputProperty);
            }
            outputProperty.PropertyChanged -= OutputProperty_PropertyChanged;
            SubscribedOutputProperties.Remove(outputProperty);
        }

        private void AddPath(OutputProperty outputProperty)
        {
            for (int i = 0; i < OutputsGrid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)OutputsGrid.ItemContainerGenerator
                        .ContainerFromIndex(i);
                var rowProperty = row.DataContext as ViewModel.OutputProperty;
                if (rowProperty == outputProperty)
                {
                    AddPath(row);
                    break;
                }
            }
        }

        private void AddPath(DataGridRow outputRow)
        {
            var outputProperty = outputRow.DataContext as ViewModel.OutputProperty;
            outputProperty.PropertyChanged += OutputProperty_PropertyChanged;
            SubscribedOutputProperties.Add(outputProperty);
            

            if (outputProperty?.ConnectedTo == null)
                return;

            var inputRow = GetInputRow(outputProperty.ConnectedTo.Input);

            Path path = GetConnectingPath(inputRow, outputRow, MainGrid, outputProperty.ConnectedTo);

            ConnectorCanvas.Children.Add(path);
            ConnectionPaths.Add(outputProperty, path);


        }

        private Path GetConnectingPath(FrameworkElement inputElement, FrameworkElement outputElement, Visual commonAncestor, ViewModel.Connection connection)
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
                StrokeThickness = 3,
            };
            return path;
        }


        private Brush GetBrush(ViewModel.Connection connection)
        {
            switch (connection.CreatedBy)
            {
                case ViewModel.Connection.Creator.User:
                    return Brushes.Blue;
                case ViewModel.Connection.Creator.Auto:
                default:
                    return Brushes.Red;
            }
        }

        private DataGridRow GetInputRow(ViewModel.InputProperty inputProperty)
        {
            return (DataGridRow)InputsGrid.ItemContainerGenerator.ContainerFromItem(inputProperty);
        }


        #region Actions

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateAllPaths();
        }


        private void OutputProperty_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var outputProperty = (ViewModel.OutputProperty)sender;
            ClearPath(outputProperty);
            AddPath(outputProperty);
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
            UpdateAllPaths();
        }

        #endregion UserControl Actions

        #endregion actions

        #region DragDrop


        private Point? _mouseDragStart = null;
        private ViewModel.InputProperty _draggingInputProperty = null;

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
            _draggingInputProperty = (sender as InputPropertyGrid)?.Property;

        }

        private void RightGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormatName))
            {
                e.Effects = DragDropEffects.None;
            }
            else
            {
                e.Effects = DragDropEffects.Link;
            }
        }

        private void RightGrid_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormatName))
            {
                var outputPropertyGrid = (OutputPropertyGrid)sender;
                var inputProperty = (ViewModel.InputProperty)e.Data.GetData(DataFormatName);
                outputPropertyGrid.Property.ConnectedTo = new ViewModel.Connection(inputProperty, ViewModel.Connection.Creator.User);
            }
        }

        #endregion DragDrop
    }
}
