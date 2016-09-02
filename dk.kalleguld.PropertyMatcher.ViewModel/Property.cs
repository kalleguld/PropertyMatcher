using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class Property : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal Model.Property ModelProperty { get; }

        public Property(Model.Property modelProperty)
        {
            ModelProperty = modelProperty;
        }

        public string Name
        {
            get
            {
                return ModelProperty.Name;
            }
            set
            {
                ModelProperty.Name = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
    }
}
