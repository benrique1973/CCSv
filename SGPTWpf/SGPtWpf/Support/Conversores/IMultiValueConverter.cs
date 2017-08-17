using System;
using System.Windows;
using System.Windows.Data;

namespace SGPTWpf.Support.Conversores
{
    public class StyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            FrameworkElement targetElement = values[0] as FrameworkElement;
            string styleName = values[1] as string;

            if (styleName == null)
                return null;

            Style newStyle = (Style)targetElement.TryFindResource(styleName);

            if (newStyle == null)
                newStyle = (Style)targetElement.TryFindResource("FlatButton");

            return newStyle;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            throw new NotImplementedException();
        }
    }
}
