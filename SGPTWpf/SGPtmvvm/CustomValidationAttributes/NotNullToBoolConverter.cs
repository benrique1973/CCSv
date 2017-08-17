//Permite la conversion entre not null a true o false. para activar o desactivar botones
namespace SGPTmvvm.CustomValidationAttributes
{
    public class NotNullToBoolConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            bool result = value == null ? false : true;

            return result;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            return value;
        }
    }
}
