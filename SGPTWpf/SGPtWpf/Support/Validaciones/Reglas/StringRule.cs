using System;
using System.Globalization;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class StringRule : ValidationRule
{
    public StringRule()
    {
    }

    public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
    {
        string valorAConvertir = string.Empty;
        try
        {
            if (((string)value).Length > 0)
            {
                return new ValidationResult(true, null);
            }
            else
            {
                return new ValidationResult(false, "El valor esta vacio");
            }

        }
        catch (Exception)
        {
            return new ValidationResult(false, "No ha ingresado el dato solicitado");
        }
    }
}
}
