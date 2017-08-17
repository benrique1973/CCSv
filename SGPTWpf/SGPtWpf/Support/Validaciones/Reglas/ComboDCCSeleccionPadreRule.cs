using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System;
using System.Globalization;
using System.Windows.Controls;
//http://stackoverflow.com/questions/26589853/wpf-combobox-validationrules
//https://msdn.microsoft.com/es-sv/library/cscsdfbt.aspx
//https://msdn.microsoft.com/es-sv/library/cc488006.aspx
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class ComboDCCSeleccionPadreRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                CatalogoCuentasModelo eleccion = value as CatalogoCuentasModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.idcc == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar la cuenta de la que depende");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                }
                else
                {
                    return new ValidationResult(false, "Error en la conversion ");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
