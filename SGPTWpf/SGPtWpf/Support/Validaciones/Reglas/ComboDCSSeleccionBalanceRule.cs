using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System;
using System.Globalization;
using System.Windows.Controls;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{

    public class ComboDCSSeleccionBalanceRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                BalanceModelo eleccion = value as BalanceModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.idbalance == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar el balance");
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