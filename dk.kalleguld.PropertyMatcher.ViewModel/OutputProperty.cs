using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.ViewModel
{
    public class OutputProperty : INotifyPropertyChanged
    {

        public OutputProperty(Model.OutputProperty modelProperty)
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

        private Connection _connectedTo;

        public event PropertyChangedEventHandler PropertyChanged;

        public Connection ConnectedTo
        {
            get { return _connectedTo; }
            set
            {
                _connectedTo = value;
                if (value?.Input?.ModelProperty == null)
                {
                    ModelProperty.ConnectedTo = null;
                }
                else
                {
                    ModelProperty.ConnectedTo = new Model.Connection(value.Input.ModelProperty, Model.Connection.Creator.User);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectedTo)));
            }
        }

        internal Model.OutputProperty ModelProperty { get; set; }



    }
}
