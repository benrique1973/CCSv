using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SGPTWpf.Support.Conversores
{
    public class FlexibleBooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(
        
            
        object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            try
            {
                int intValor = 0;
                switch (value.ToString())
                {
                    case "Visible":
                        intValor = 0;
                        break;
                    case "Hidden":
                        intValor = 1;
                        break;
                    case "Collapsed":
                        intValor = 2;
                        break;
                    default:
                        intValor = 2;
                        break;
                }
                return intValor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception en borrar registro : " + ex.Message);
                return 2;
            }
        }

        public object ConvertBack(
            object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            string intValor = string.Empty;
            switch (value.ToString())
            {
                case "0":
                    intValor = "Visible";
                    break;
                case "1":
                    intValor = "Hidden";
                    break;
                case "2":
                    intValor = "Collapsed";
                    break;
            }
            return intValor;
        }
    }
}