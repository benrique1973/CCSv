using SGPTWpf.Model;
using System;
using System.Globalization;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{

    public class comboSeleccionEmpleado : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                UsuarioModelo eleccion = value as UsuarioModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.idUsuario == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar el usuario");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                }
                else
                {
                    return new ValidationResult(false, "No pudo realizarse la selección ");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(true, null);
            }
        }
    }
}