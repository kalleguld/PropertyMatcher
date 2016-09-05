using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class Field : INotifyPropertyChanged, ISelectable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal Model.Field ModelField { get; }

        public Field(Model.Field modelField)
        {
            ModelField = modelField;
            _selectionStatus = SelectionStatus.NotSelected;
        }

        public string Name { get { return ModelField.Name; } }
        public string SystemTableId { get { return ModelField.SystemTableId; } }
        public string Id { get { return ModelField.Id; } }
        public string Description { get { return ModelField.Description; } }
        public string Samplee { get { return ModelField.Samplee; } }
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
    }
}
