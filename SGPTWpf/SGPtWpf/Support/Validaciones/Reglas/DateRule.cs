using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class DateRule : ValidationRule
{
    public DateRule()
    {
    }

    public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
    {
        DateTime valorAConvertir = DateTime.Now;

        try
        {
            if (value.ToString().Length > 0)
                //valorAConvertir = DateTime.Parse(value.ToString());
                valorAConvertir = DateTime.Parse(value.ToString(), CurrentCulture);
                return new ValidationResult(true, null);
            }
        catch (Exception)
        {
            return new ValidationResult(false, "No es una fecha válida");
        }
    }
}
}
