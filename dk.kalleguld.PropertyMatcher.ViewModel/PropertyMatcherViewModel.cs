using dk.kalleguld.PropertyMatcher.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class PropertyMatcherViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<ViewModel.Property> Inputs { get; }
        public ObservableCollection<ViewModel.Property> Outputs { get; }
        public ObservableCollection<ViewModel.Connection> Connections { get; }

        public string InputsName { get; private set; }
        public string OutputsName { get; private set; }

        public PropertyMatcherViewModel(
            PropertyCollection inputs, 
            PropertyCollection outputs,
            IEnumerable<Model.Connection> connections)
        {
            Inputs = GetViewModelProperties(inputs);
            Outputs = GetViewModelProperties(outputs);
            Connections = GetViewModelConnections(connections, Inputs, Outputs);
            
            InputsName = inputs.Name;
            OutputsName = outputs.Name;

            //Connections.CollectionChanged += Connections_CollectionChanged;
        }

        [Obsolete]
        private void Connections_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                

                var connectionsToRemove = new List<Connection>();
                foreach (var newConnectionObj in e.NewItems)
                {
                    var newConnection = (Connection)newConnectionObj;
                    connectionsToRemove.AddRange(
                        Connections.Where(existingConn => existingConn != newConnection
                            && existingConn.Output == newConnection.Output));
                }
                foreach (var conn in connectionsToRemove)
                {
                    Connections.Remove(conn);
                }
            }
        }

        public void AddConnection(Property input, Property output, Connection.Creator createdBy)
        {
            // Remove any existing connections to a newly connected output.
            // There should never be more than one input connected to any given output
            var conflictingConnections = Connections.Where(conn => conn.Output == output).ToList();
            foreach (var conn in conflictingConnections)
            {
                Connections.Remove(conn);
            }

            SelectionStatus selectionStatus;
            if (Selection.Contains(input) || Selection.Contains(output))
            {
                selectionStatus = SelectionStatus.ConnectionSelected;
            }
            else
            {
                selectionStatus = SelectionStatus.NotSelected;
            }

            Connections.Add(new Connection(input, output, createdBy, selectionStatus));
        }

        private static ObservableCollection<Connection> GetViewModelConnections(
            IEnumerable<Model.Connection> modelConnections,
            ObservableCollection<Property> inputs,
            ObservableCollection<Property> outputs)
        {
            var result = new ObservableCollection<Connection>();

            foreach (var modelConnection in modelConnections)
            {
                var input = inputs.FirstOrDefault(prop => prop.ModelProperty == modelConnection.Input);
                if (input == null)
                    continue;

                var output = outputs.FirstOrDefault(prop => prop.ModelProperty == modelConnection.Output);
                if (output == null)
                    continue;

                var connection = new Connection(input, output, (Connection.Creator)modelConnection.CreatedBy);
                result.Add(connection);
            }
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static ObservableCollection<ViewModel.Property> GetViewModelProperties(Model.PropertyCollection inputCollection)
        {
            var inputEnumerable = inputCollection.Properties.Select(p => new ViewModel.Property(p));
            return new ObservableCollection<Property>(inputEnumerable);
        }

        private IEnumerable<ISelectable> _selection = Enumerable.Empty<ISelectable>();
        public IEnumerable<ISelectable> Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                SetSelection(value.ToList());
            }
        }


        private void SetSelection(List<ISelectable> selection)
        {
            if (selection == null)
                throw new ArgumentNullException(nameof(selection));

            var connections = selection.Where(s => s is Connection).Cast<Connection>();
            var properties = selection.Where(s => s is Property).Cast<Property>();

            foreach (var prop in Inputs)
            {
                if (properties.Contains(prop))
                {
                    prop.SelectionStatus = SelectionStatus.Selected;
                }
                else if (connections.Any(c => c.Input == prop))
                {
                    prop.SelectionStatus = SelectionStatus.ConnectionSelected;
                }
                else
                {
                    prop.SelectionStatus = SelectionStatus.NotSelected;
                }
            }
            foreach (var prop in Outputs)
            {
                if (properties.Contains(prop))
                {
                    prop.SelectionStatus = SelectionStatus.Selected;
                }
                else if (connections.Any(c => c.Output == prop))
                {
                    prop.SelectionStatus = SelectionStatus.ConnectionSelected;
                }
                else
                {
                    prop.SelectionStatus = SelectionStatus.NotSelected;
                }
            }
            foreach (var conn in Connections)
            {
                if (connections.Contains(conn))
                {
                    conn.SelectionStatus = SelectionStatus.Selected;
                }
                else if (properties.Any(p => p == conn.Input || p == conn.Output))
                {
                    conn.SelectionStatus = SelectionStatus.ConnectionSelected;
                }
                else
                {
                    conn.SelectionStatus = SelectionStatus.NotSelected;
                }
            }
        }
    }
}
