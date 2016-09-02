using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.View
{
    class PropertyGrid : System.Windows.Controls.Grid
    {
        public static readonly System.Windows.DependencyProperty PropertyProperty =
            System.Windows.DependencyProperty.Register(
                nameof(Property),
                typeof(ViewModel.Property),
                typeof(PropertyGrid),
                new System.Windows.PropertyMetadata(null));


        public ViewModel.Property Property
        {
            get
            {
                return (ViewModel.Property)this.GetValue(PropertyProperty);
            }
            set
            {
                this.SetValue(PropertyProperty, value);
            }

        }
    }
}
