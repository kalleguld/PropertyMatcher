using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dk.kalleguld.PropertyMatcher.View
{
    class FieldGrid : System.Windows.Controls.Grid
    {
        public static readonly System.Windows.DependencyProperty FieldProperty =
            System.Windows.DependencyProperty.Register(
                nameof(Field),
                typeof(ViewModel.Field),
                typeof(FieldGrid),
                new System.Windows.PropertyMetadata(null));


        public ViewModel.Field Field
        {
            get
            {
                return (ViewModel.Field)this.GetValue(FieldProperty);
            }
            set
            {
                this.SetValue(FieldProperty, value);
            }

        }
    }
}
