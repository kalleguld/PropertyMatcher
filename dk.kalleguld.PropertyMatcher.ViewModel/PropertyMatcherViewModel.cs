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

        public IEnumerable<ISelectable> Selection
        {
            get { return _selection; }
            set
            {
                _selection = value;
                SetSelection(value.ToList());
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selection)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PropertyMatcherViewModel(
            Model.Table inputs, 
            Model.Table outputs,
            IEnumerable<Model.Connection> connections)
        {
            InputFields = GetViewModelFields(inputs, this, Field.ConnectionDirection.Input);
            OutputFields = GetViewModelFields(outputs, this, Field.ConnectionDirection.Output);
            Connections = GetViewModelConnections(connections, InputFields, OutputFields);

            foreach (var conn in Connections)
            {
                conn.Input.IsConnected = true;
                conn.Output.IsConnected = true;
            }

            InputTable = new Table(inputs);
            OutputTable = new Table(outputs);

        }

        public void AddConnection(Field a, Field b, Connection.Creator createdBy)
        {
            //Find out which is the input field and which is the output field
            Field input, output;
            if (InputFields.Contains(a) && OutputFields.Contains(b))
            {
                input = a;
                output = b;
            }
            else if (InputFields.Contains(b) && OutputFields.Contains(a))
            {
                input = b;
                output = a;
            }
            else
            {
                //Only connect inputs with outputs
                return;
            }

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
            input.IsConnected = true;
            output.IsConnected = true;
        }

        public void RemoveConnection(Connection connection)
        {
            Connections.Remove(connection);
            UpdateIsConnected(connection.Input);
            UpdateIsConnected(connection.Output);
        }

        public void Disconnect(Field field)
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

        public bool IsConnectable(Field a, Field b)
        {
            return a != null && b != null && 
                ((InputFields.Contains(a) && OutputFields.Contains(b))
                    || (InputFields.Contains(b) && OutputFields.Contains(a)));
        }

        private void UpdateIsConnected(Field field)
        {
            field.IsConnected = (Connections.Any(conn => conn.Input == field || conn.Output == field));
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

        private static ObservableCollection<ViewModel.Field> GetViewModelFields(
            Model.Table fieldCollection, 
            PropertyMatcherViewModel viewModel, 
            Field.ConnectionDirection direction)
        {
            var fieldEnumerable = fieldCollection.Fields.Select(p => new Field(p, viewModel, direction));
            return new ObservableCollection<Field>(fieldEnumerable);
        }

        private IEnumerable<ISelectable> _selection = Enumerable.Empty<ISelectable>();
        
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

        
    }
}
