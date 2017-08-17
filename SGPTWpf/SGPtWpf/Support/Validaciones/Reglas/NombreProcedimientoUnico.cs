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
    public class Wrapper : DependencyObject
    {
        public static readonly DependencyProperty listaEntidadSeleccionProperty =
             DependencyProperty.Register("listaEntidadSeleccion", typeof(ObservableCollection<DetalleProgramaModelo>),
             typeof(Wrapper), new FrameworkPropertyMetadata());

        public ObservableCollection<DetalleProgramaModelo> listaEntidadSeleccion
        {
            get { return (ObservableCollection<DetalleProgramaModelo>)GetValue(listaEntidadSeleccionProperty); }
            set { SetValue(listaEntidadSeleccionProperty, value); }
        }
    }

    public class NombreProcedimientoUnico : ValidationRule
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
                        if (((string)value).Length <= 500)
                        {
                            ObservableCollection<DetalleProgramaModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                            string descripciondp = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                    var contains = castedCollection.Select(x => x.descripciondp.ToUpper().Trim()).Contains(descripciondp);
                                    if (contains)
                                    return new ValidationResult(false,
                                    "Los procedimientos deben ser únicos no deben repetirse");
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
                            return new ValidationResult(false, "La descripción debe ser menor a 500 caracteres");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "El procedimiento debe ser significativo");
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
        public Wrapper Wrapper { get; set; }
    }

}