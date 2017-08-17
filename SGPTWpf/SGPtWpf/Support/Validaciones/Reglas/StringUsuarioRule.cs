using System;
using System.Globalization;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class StringUsuarioRule : ValidationRule
    {
        public StringUsuarioRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
        {
            string valorAConvertir = string.Empty;
            try
            {
                if (((string)value).Length >= 4)
                {
                    if (((string)value).Length <= 25)
                    {
                        return new ValidationResult(true, null);
                    }
                    else
                    {
                        return new ValidationResult(false, "El valor menor a 25 caracteres");
                    }
                }
                else
                {
                    return new ValidationResult(false, "El valor esta vacio debe ser mayor a 4 caracteres");
                }

            }
            catch (Exception)
            {
                return new ValidationResult(false, "No ha ingresado el dato solicitado");
            }
        }
    }
}
