using SGPTWpf.Model.Modelo.detalleherramientas;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperHerramientaProcedimiento : DependencyObject
    {
        public static readonly DependencyProperty listaHProcedimientoSeleccionProperty =
             DependencyProperty.Register("listaHProcedimientoSeleccion", typeof(ObservableCollection<DetalleHerramientasModelo>),
             typeof(WrapperHerramientaProcedimiento), new FrameworkPropertyMetadata());

        public ObservableCollection<DetalleHerramientasModelo> listaHProcedimientoSeleccion
        {
            get { return (ObservableCollection<DetalleHerramientasModelo>)GetValue(listaHProcedimientoSeleccionProperty); }
            set { SetValue(listaHProcedimientoSeleccionProperty, value); }
        }
    }

    public class NombreDetalleHerramientaUnico : ValidationRule
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
                            ObservableCollection<DetalleHerramientasModelo> castedCollection = this.Wrapper.listaHProcedimientoSeleccion;
                            string descripciondp = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.descripcionDh.ToUpper().Trim()).Contains(descripciondp);
                                if (contains)
                                    return new ValidationResult(false,
                                    "Los procedimientos o preguntas deben ser únicos no deben repetirse");
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
                        return new ValidationResult(false, "El procedimiento o pregunta debe ser significativo");
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
        public WrapperHerramientaProcedimiento Wrapper { get; set; }
    }

}