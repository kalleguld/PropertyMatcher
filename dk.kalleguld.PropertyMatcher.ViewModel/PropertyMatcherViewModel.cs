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

        public ObservableCollection<ViewModel.Field> InputFields { get; }
        public ObservableCollection<ViewModel.Field> OutputFields { get; }

        public ViewModel.Table InputTable { get; }
        public ViewModel.Table OutputTable { get; }

        /// <summary>
        /// Please only add/remove from this list in AddConnection/RemoveConnection
        /// </summary>
        public ObservableCollection<ViewModel.Connection> Connections { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PropertyMatcherViewModel(
            Model.Table inputs, 
            Model.Table outputs,
            IEnumerable<Model.Connection> connections)
        {
            InputFields = GetViewModelFields(inputs);
            OutputFields = GetViewModelFields(outputs);
            Connections = GetViewModelConnections(connections, InputFields, OutputFields);

            InputTable = new Table(inputs);
            OutputTable = new Table(outputs);

        }

        public void AddConnection(Field input, Field output, Connection.Creator createdBy)
        {
            // Remove any existing connections to a newly connected output.
            // There should never be more than one input connected to any given output
            var conflictingConnections = Connections.Where(conn => conn.Output == output).ToList();
            foreach (var conn in conflictingConnections)
            {
                RemoveConnection(conn);
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

        public void RemoveConnection(Connection connection)
        {
            Connections.Remove(connection);
        }

        private static ObservableCollection<Connection> GetViewModelConnections(
            IEnumerable<Model.Connection> modelConnections,
            ObservableCollection<Field> inputs,
            ObservableCollection<Field> outputs)
        {
            var result = new ObservableCollection<Connection>();

            foreach (var modelConnection in modelConnections)
            {
                var input = inputs.FirstOrDefault(field => field.ModelField == modelConnection.Input);
                if (input == null)
                    continue;

                var output = outputs.FirstOrDefault(field => field.ModelField == modelConnection.Output);
                if (output == null)
                    continue;

                var connection = new Connection(input, output, (Connection.Creator)modelConnection.CreatedBy);
                result.Add(connection);
            }
            return result;
        }

        private static ObservableCollection<ViewModel.Field> GetViewModelFields(Model.Table inputCollection)
        {
            var inputEnumerable = inputCollection.Fields.Select(p => new ViewModel.Field(p));
            return new ObservableCollection<Field>(inputEnumerable);
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
            var fields = selection.Where(s => s is Field).Cast<Field>();

            foreach (var field in InputFields)
            {
                if (fields.Contains(field))
                {
                    field.SelectionStatus = SelectionStatus.Selected;
                }
                else if (connections.Any(c => c.Input == field))
                {
                    field.SelectionStatus = SelectionStatus.ConnectionSelected;
                }
                else
                {
                    field.SelectionStatus = SelectionStatus.NotSelected;
                }
            }
            foreach (var field in OutputFields)
            {
                if (fields.Contains(field))
                {
                    field.SelectionStatus = SelectionStatus.Selected;
                }
                else if (connections.Any(c => c.Output == field))
                {
                    field.SelectionStatus = SelectionStatus.ConnectionSelected;
                }
                else
                {
                    field.SelectionStatus = SelectionStatus.NotSelected;
                }
            }
            foreach (var conn in Connections)
            {
                if (connections.Contains(conn))
                {
                    conn.SelectionStatus = SelectionStatus.Selected;
                }
                else if (fields.Any(p => p == conn.Input || p == conn.Output))
                {
                    conn.SelectionStatus = SelectionStatus.ConnectionSelected;
                }
                else
                {
                    conn.SelectionStatus = SelectionStatus.NotSelected;
                }
            }
        }

        private void Disconnect(Field field)
        {
            var droppedConnections = Connections
                .Where(c => c.Input == field 
                         || c.Output == field)
                .ToList();
            foreach (var conn in droppedConnections)
            {
                RemoveConnection(conn);
            }
        }
    }
}
