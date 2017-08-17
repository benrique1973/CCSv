using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class EnumMatchToBooleanConverterRadioButtonInformes : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType,
                             object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            //if (value == null || parameter == null)
            //    return false;

            //string checkValue = value.ToString();
            //string targetValue = parameter.ToString();
            //return checkValue.Equals(targetValue,
            //         StringComparison.InvariantCultureIgnoreCase);

                    //string parameterString = parameter as string;
                    //if (parameterString == null)
                    //    return DependencyProperty.UnsetValue;

                    //if (Enum.IsDefined(value.GetType(), value) == false)
                    //    return DependencyProperty.UnsetValue;

                    //object parameterValue = Enum.Parse(value.GetType(), parameterString);

                    //return parameterValue.Equals(value);
            if (value == null)
            {
                return false; // or return parameter.Equals(YourEnumType.SomeDefaultValue);
            }
            return value.Equals(parameter);
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, System.Globalization.CultureInfo cultureInfo)
        {
            ////if (value == null || parameter == null)
            ////    return null;

            ////bool useValue = (bool)value;
            //////string targetValue = parameter.ToString();
            //////var asd = Enum.Parse(targetType, targetValue);
            //////if (useValue)
            //////    return Enum.Parse(targetType, targetValue);
            ////        //string checkValue = parameter.ToString(); //value.ToString();
            ////        //string targetValue = parameter.ToString();
            ////        //if (useValue)
            ////        //return checkValue.Equals(targetValue,
            ////        //         StringComparison.InvariantCultureIgnoreCase);
            ////bool param = bool.Parse(parameter.ToString());
            ////if (useValue)
            ////return !((bool)value ^ param);

            ////return null;
                    //string parameterString = parameter as string;
                    //if (parameterString == null)
                    //    return DependencyProperty.UnsetValue;

                    //return Enum.Parse(targetType, parameterString);
            RaisePropertyChanged("InformeactividadesListado");
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
