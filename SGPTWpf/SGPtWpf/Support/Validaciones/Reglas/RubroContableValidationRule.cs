using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperDigitosCuenta : DependencyObject
    {
        public static readonly DependencyProperty digitoscuentamayorscProperty =
             DependencyProperty.Register("digitoscuentamayorsc", typeof(int),
             typeof(WrapperDigitosCuenta), new FrameworkPropertyMetadata());

        public int digitoscuentamayorsc
        {
            get { return (int) GetValue(digitoscuentamayorscProperty); }
            set { SetValue(digitoscuentamayorscProperty, value); }
        }

    }

    public class RubroContableValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    int valor;
                    int.TryParse(value.ToString(), out valor);
                    if (valor > 0)
                    {
                        if (valor <= 20)
                        {
                            if (valor > this.Wrapper.digitoscuentamayorsc)
                            {
                                return new ValidationResult(false, "La cantidad de dígitos del rubro no puede ser mayor que el de las cuentas");
                            }
                            else
                            { 
                            return ValidationResult.ValidResult;
                            }
                        }
                        else
                        {
                            return new ValidationResult(false, "El máximo es de 20 dígitos");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "Debe ingresar un valor");
                    }

                }
                catch (Exception)
                {
                    return new ValidationResult(false, "No ha ingresado el dato solicitado o no es un dígito válido");
                }
            }
            else
            {
                return new ValidationResult(false, "No ha ingresado el dato solicitado");
            }
        }
        public WrapperDigitosCuenta Wrapper { get; set; }
    }

}