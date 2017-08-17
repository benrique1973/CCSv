using System;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class FloatRule : ValidationRule
    {
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            float number = 0;

            try
            {
                if (value != null && ((string)value).Length > 0)
                {
                    number = float.Parse((String)value);
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch (Exception )
            {
                return new ValidationResult(false, "Lo ingresado contiene carácteres inválidos");
            }

        }
    }
}
