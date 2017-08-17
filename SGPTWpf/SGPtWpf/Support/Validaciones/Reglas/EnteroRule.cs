using System;
using System.Globalization;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class EnteroRule : ValidationRule
    {
        public EnteroRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
        {
            int valorAConvertir = 0;

            try
            {
                if (((string)value).Length > 0)
                {
                    valorAConvertir = int.Parse(value.ToString());
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "No contiene un valor válido");
                }
            }
            catch (Exception )
            {
                return new ValidationResult(false, "Contiene caracteres no válidos");
            }

        }
    }
}