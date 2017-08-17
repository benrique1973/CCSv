using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperHPrograma : DependencyObject
    {
        public static readonly DependencyProperty listaHEntidadSeleccionProperty =
             DependencyProperty.Register("listaHEntidadSeleccion", typeof(ObservableCollection<HerramientasModelo>),
             typeof(WrapperHPrograma), new FrameworkPropertyMetadata());

        public ObservableCollection<HerramientasModelo> listaHEntidadSeleccion
        {
            get { return (ObservableCollection<HerramientasModelo>)GetValue(listaHEntidadSeleccionProperty); }
            set { SetValue(listaHEntidadSeleccionProperty, value); }
        }
    }

    public class NombreHProgramaUnico : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 5)
                    {
                        if (((string)value).Length <= 200)
                        {
                            ObservableCollection<HerramientasModelo> castedCollection = this.Wrapper.listaHEntidadSeleccion;
                              string nombreprogramaInput = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.nombreHerramienta.ToUpper().Trim()).Contains(nombreprogramaInput);
                                if (contains)
                                    return new ValidationResult(false,
                                    "El nombre del programa debe ser único");
                                else
                                    return new ValidationResult(true, null);
                            }
                            else
                            {
                                return new ValidationResult(true, null);
                            }
                        }
                        else
                        {
                            return new ValidationResult(false, "El nombre debe ser menor a 200 caracteres");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "El nombre debe ser significativo");
                    }

                }
                catch (Exception)
                {
                    return new ValidationResult(false, "No ha ingresado el dato solicitado");
                }
            }
            else
            {
                return new ValidationResult(false, "No ha ingresado el dato solicitado");
            }
        }
        public WrapperHPrograma Wrapper { get; set; }
    }

}