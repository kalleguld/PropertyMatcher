using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class InputProperty : INotifyPropertyChanged
    {
        public InputProperty(Model.InputProperty modelProperty)
        {
            ModelProperty = modelProperty;
        }

        public string Name
        {
            get
            {
                return ModelProperty.Name;
            }
        }

        internal Model.InputProperty ModelProperty { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
