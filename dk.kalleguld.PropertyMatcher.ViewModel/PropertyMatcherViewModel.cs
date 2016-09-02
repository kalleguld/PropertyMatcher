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

            Connections.CollectionChanged += Connections_CollectionChanged;
        }


        /// <summary>
        /// Removes any existing connections to a newly connected output.
        /// There should only ever be one input connected to any given output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            // Removes any existing connections to a newly connected output.
            // There should never be more than one input connected to any given output

            var conflictingConnections = Connections.Where(conn => conn.Output == output).ToList();
            foreach (var conn in conflictingConnections)
            {
                Connections.Remove(conn);
            }
            Connections.Add(new Connection(input, output, createdBy));
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
    }
}
