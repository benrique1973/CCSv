using SGPTWpf.ViewModel.Crud.Actividad;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows;
//https://code.msdn.microsoft.com/Validation-in-MVVM-using-12dafef3/sourcecode?fileId=107601&pathId=828172702
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Atributos
{
    public class UnqiueActividad : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
                try
                {
                    if (ActividadControllerViewModel.SharedViewModel().ListaEntidad.Count > 0)
                    {
                        var contains = ActividadControllerViewModel.SharedViewModel().ListaEntidad.Select(x => x.id).Contains(value);
                        if (contains)
                            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                        else
                            return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error en verificación de registro único: "+e.Message);
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
        }
    }
}