using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class Field : INotifyPropertyChanged, ISelectable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal Model.Field ModelField { get; }
        private readonly PropertyMatcherViewModel ViewModel;

        public Field(Model.Field modelField, PropertyMatcherViewModel viewModel)
        {
            ModelField = modelField;
            ViewModel = viewModel;

            _selectionStatus = SelectionStatus.NotSelected;
            Disconnect = new DisconnectCommand(this);
        }

        public string Name { get { return ModelField.Name; } }
        public string SystemTableId { get { return ModelField.SystemTableId; } }
        public string Id { get { return ModelField.Id; } }
        public string Description { get { return ModelField.Description; } }
        public string Sample { get { return ModelField.Sample; } }
        public bool? IsMandatory { get { return ModelField.IsMandatory; } }
        public string Attribute { get { return ModelField.Attribute; } }
        public string Reference { get { return ModelField.Reference; } }

        private SelectionStatus _selectionStatus;
        public SelectionStatus SelectionStatus
        {
            get { return _selectionStatus; }
            set
            {
                _selectionStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectionStatus)));
            }
        }

        public ICommand Disconnect { get; }

        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            internal set
            {
                _isConnected = value;
                ((DisconnectCommand)Disconnect).isConnectedChanged();
            }
        }

        private class DisconnectCommand : ICommand
        {
            private Field field;
            public event EventHandler CanExecuteChanged;

            public DisconnectCommand(Field field)
            {
                this.field = field;
            }


            public bool CanExecute(object parameter)
            {
                return field.IsConnected;
            }

            public void Execute(object parameter)
            {
                field.ViewModel.Disconnect(field);
            }

            internal void isConnectedChanged() => CanExecuteChanged?.Invoke(field, new EventArgs());
        }
    }
}
