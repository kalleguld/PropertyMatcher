using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace dk.kalleguld.PropertyMatcher.View.Converters
{
    [ValueConversion(typeof(object), typeof(GridLength))]
    internal class GridZeroHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return new GridLength(0);
            }
            else if (string.IsNullOrWhiteSpace(value as string))
            {
                return new GridLength(0);
            }
            else
            {
                return new GridLength(1, GridUnitType.Star);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
