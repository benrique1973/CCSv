using System;
using System.Windows.Data;

namespace SGPTWpf.Support.Conversores
{
    public class EnableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            if (value.ToString().ToUpper() == "TRUE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            int valor = System.Convert.ToInt16(value);
            if (valor == 0)
                return "true";
            else
                return "false";
        }
    }
}