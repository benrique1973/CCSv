using System;
using System.Globalization;
using System.Windows.Controls;
//Agrupa reglas de validacion
//https://msdn.microsoft.com/en-us/library/system.windows.data.binding.updatesourceexceptionfilter(v=vs.110).aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class EntidadRule : ValidationRule
    {
        public EntidadRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                if (value!=null)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Debe seleccionar un valor");
                }

            }
            catch (Exception)
            {
                return new ValidationResult(false, "No ha seleccionado ninguna opción");
            }
        }
    }
}
