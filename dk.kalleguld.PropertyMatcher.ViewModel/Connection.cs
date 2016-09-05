using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class Connection : INotifyPropertyChanged, ISelectable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Connection(Field input, Field output, Creator createdBy)
            : this(input, output, createdBy, SelectionStatus.NotSelected) { }

        public Connection(Field input, Field output, Creator createdBy, SelectionStatus selectionStatus)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            Input = input;

            if (output == null)
                throw new ArgumentNullException(nameof(output));
            Output = output;

            CreatedBy = createdBy;
            _selectionStatus = selectionStatus;
        }

        public Field Input { get; }
        public Field Output { get; }

        public Creator CreatedBy { get; }

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



        public enum Creator { User, Auto, }

    }
}
