using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace NetAz_UpAndDown.Converters
{
    internal class Int32ToBrushConverter : IValueConverter
    {
        //ViewModel To View
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int i)
            {
                Color[] colors = new Color[] { Colors.Yellow, Colors.Blue, Colors.Red, Colors.Green, Colors.Black,
                    Colors.Pink, Colors.Purple, Colors.Orange, Colors.Violet, Colors.Salmon
                };

                return new SolidColorBrush(colors[i]);
            }

            return Binding.DoNothing;
        }

        //View To ViewModel
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
