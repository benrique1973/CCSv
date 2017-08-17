using System;
using System.Windows.Data;

//http://stackoverflow.com/questions/17320456/checkbox-like-radiobutton-wpf-c-sharp/17320737#17320737

namespace SGPTWpf.Support.Conversores
{
    class BooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            var test = (bool?)value;
            var result = bool.Parse((string)parameter);

            if (test == result)
            {
                return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            var result = bool.Parse((string)parameter);
            return result;
        }
    }
}
