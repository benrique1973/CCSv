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
    public class WrapperCuestionario : DependencyObject
    {
        public static readonly DependencyProperty listaPreguntaSeleccionProperty =
             DependencyProperty.Register("listaPreguntaSeleccion", typeof(ObservableCollection<DetalleCuestionarioModelo>),
             typeof(WrapperCuestionario), new FrameworkPropertyMetadata());

        public ObservableCollection<DetalleCuestionarioModelo> listaPreguntaSeleccion
        {
            get { return (ObservableCollection<DetalleCuestionarioModelo>)GetValue(listaPreguntaSeleccionProperty); }
            set { SetValue(listaPreguntaSeleccionProperty, value); }
        }
    }

    public class nombrePreguntaUnica : ValidationRule
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
                            ObservableCollection<DetalleCuestionarioModelo> castedCollection = this.Wrapper.listaPreguntaSeleccion;
                            string descripciondp = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.descripciondp.ToUpper().Trim()).Contains(descripciondp);
                                if (contains)
                                    return new ValidationResult(false,
                                    "Los detalles  deben ser únicos no deben repetirse");
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
                        return new ValidationResult(false, "La pregunta debe ser significativa");
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
        public WrapperCuestionario Wrapper { get; set; }
    }

}