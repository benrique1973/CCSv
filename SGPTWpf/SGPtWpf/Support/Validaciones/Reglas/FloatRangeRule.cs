using System;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class FloatRangeRule : ValidationRule
    {
        public double Max { get; set; }
        public double Min { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            float number = 0;

            try
            {
                if (value != null && ((string)value).Length > 0)
                {
                    number = float.Parse((String)value);
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

            if ((number < Min) || (number > Max))
            {
                return new ValidationResult(false,
                  "Por favor ingrese datos en el rango siguiente : " + Min + " y " + Max);
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
