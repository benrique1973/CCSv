using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrappeDescripcion : DependencyObject
    {
        public static readonly DependencyProperty listaDescripcionSeleccionProperty =
             DependencyProperty.Register("listaDescripcionSeleccion", typeof(ObservableCollection<string>),
             typeof(WrappeDescripcion), new FrameworkPropertyMetadata());

        public ObservableCollection<string> listaDescripcionSeleccion
        {
            get { return (ObservableCollection<string>)GetValue(listaDescripcionSeleccionProperty); }
            set { SetValue(listaDescripcionSeleccionProperty, value); }
        }
    }

    public class DescripcionUnica : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 5)
                    {
                            ObservableCollection<string> castedCollection = this.Wrapper.listaDescripcionSeleccion;
                            string descripciondp = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.ToUpper().Trim()).Contains(descripciondp);
                                if (contains)
                                    return new ValidationResult(false,
                                    "La descripción deben ser únicos no deben repetirse");
                                else
                                    return new ValidationResult(true, null);
                            }
                            else
                            {
                                return new ValidationResult(true, null);
                            }
                    }
                    else
                    {
                        return new ValidationResult(false, "La descripción debe ser significativo");
                    }

                }
                catch (Exception)
                {
                    return new ValidationResult(false, "No ha ingresado el dato solicitado");
                }
            }
            else
            {
                return new ValidationResult(false, "No ha ingresado el dato solicitado");
            }
        }
        public WrappeDescripcion Wrapper { get; set; }
    }

}