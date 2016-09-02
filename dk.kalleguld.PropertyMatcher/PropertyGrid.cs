using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.View
{
    class PropertyGrid<T> : System.Windows.Controls.Grid
    {
        public static readonly System.Windows.DependencyProperty PropertyProperty =
            System.Windows.DependencyProperty.Register(
                nameof(Property),
                typeof(T),
                typeof(PropertyGrid<T>),
                new System.Windows.PropertyMetadata(null));


        public T Property
        {
            get
            {
                return (T)this.GetValue(PropertyProperty);
            }
            set
            {
                this.SetValue(PropertyProperty, value);
            }

        }
    }
}
