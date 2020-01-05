using System;
using System.Globalization;
using System.Windows.Data;

namespace MyApp.Converter
{
    public class CheckNull:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string) value == null || (string) value == "" ? "yes" : "no";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}