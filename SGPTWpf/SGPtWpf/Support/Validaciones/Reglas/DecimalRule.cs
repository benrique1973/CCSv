using System;
using System.Globalization;
using System.Windows.Controls;
//Agrupa reglas de validacion
//https://msdn.microsoft.com/en-us/library/system.windows.data.binding.updatesourceexceptionfilter(v=vs.110).aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class DecimalRule : ValidationRule
    {
        public DecimalRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal valorAConvertir = 0;
            try
            {
                if (((string)value).Length > 0)
                {
                    valorAConvertir = decimal.Parse(value.ToString());
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "El valor esta vacio");
                }

            }
            catch (Exception)
            {
                return new ValidationResult(false, "Contiene caracteres no válidos");
            }
        }
    }
}
