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
        public SelectionStatus SelectionStatus
        {
            get { return _selectionStatus; }
            set
            {
                _selectionStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectionStatus)));
            }
        }
        public bool IsConnected
        {
            get { return _isConnected; }
            internal set
            {
                _isConnected = value;
                ((DisconnectCommand)Disconnect).isConnectedChanged();
            }
        }
        public ICommand Disconnect { get; }
        public ConnectionDirection Direction { get; }
        #region model properties
        public string Name { get { return ModelField.Name?.Trim(); } }
        public string SystemTableId { get { return ModelField.SystemTableId?.Trim(); } }
        public string Id { get { return ModelField.Id?.Trim(); } }
        public string Description { get { return ModelField.Description?.Trim(); } }
        public string Sample { get { return ModelField.Sample?.Trim(); } }
        public string Attribute { get { return ModelField.Attribute?.Trim(); } }
        public string Reference { get { return ModelField.Reference?.Trim(); } }
        public bool? IsMandatory { get { return ModelField.IsMandatory; } }
        #endregion


        private readonly PropertyMatcherViewModel ViewModel;
        internal readonly Model.Field ModelField;

        private SelectionStatus _selectionStatus;
        private bool _isConnected;

        internal Field(Model.Field modelField, PropertyMatcherViewModel viewModel, ConnectionDirection direction)
        {
            ModelField = modelField;
            ViewModel = viewModel;
            Direction = direction;

            _selectionStatus = SelectionStatus.NotSelected;
            Disconnect = new DisconnectCommand(this);
        }






        public enum ConnectionDirection { Input, Output, }

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
