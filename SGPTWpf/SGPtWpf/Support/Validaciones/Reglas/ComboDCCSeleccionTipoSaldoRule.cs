using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
//http://stackoverflow.com/questions/26589853/wpf-combobox-validationrules
//https://msdn.microsoft.com/es-sv/library/cscsdfbt.aspx
//https://msdn.microsoft.com/es-sv/library/cc488006.aspx
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class ComboDCCSeleccionTipoSaldoRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                TipoSaldoCuentaModelo eleccion = value as TipoSaldoCuentaModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.idTSaldoCuenta == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar el saldo de la cuenta");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                }
                else
                {
                    return new ValidationResult(false, "No pudo realizarse la conversion ");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
