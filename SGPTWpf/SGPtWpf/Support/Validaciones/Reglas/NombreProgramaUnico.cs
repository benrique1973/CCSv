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
    public class WrapperPrograma : DependencyObject
    {
        public static readonly DependencyProperty listaEntidadSeleccionProperty =
             DependencyProperty.Register("listaEntidadSeleccion", typeof(ObservableCollection<ProgramaModelo>),
             typeof(WrapperPrograma), new FrameworkPropertyMetadata());

        public ObservableCollection<ProgramaModelo> listaEntidadSeleccion
        {
            get { return (ObservableCollection<ProgramaModelo>)GetValue(listaEntidadSeleccionProperty); }
            set { SetValue(listaEntidadSeleccionProperty, value); }
        }
    }

    public class NombreProgramaUnico : ValidationRule
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
                           ObservableCollection<ProgramaModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                            string nombreprogramaInput = (string)value.ToString().ToUpper().Trim();
                           if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.nombreprograma.ToUpper().Trim()).Contains(nombreprogramaInput);
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
        public WrapperPrograma Wrapper { get; set; }
    }

    public class NombreReferenciaProgramaUnico : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 3)
                    {
                        if (((string)value).Length <= 30)
                        {
                            ObservableCollection<ProgramaModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                            string nombreprogramaInput = (string)value.ToString().ToUpper().Trim();
                            int contarRepetidos = 0;
                            if (castedCollection.Count > 0)
                            {
                                for (int i = 0; i < castedCollection.Count(); i++)
                                {
                                    if (castedCollection[i].referenciaPrograma != null && string.IsNullOrEmpty(castedCollection[i].referenciaPrograma))
                                    {
                                        if (castedCollection[i].referenciaPrograma.ToUpper().Trim().Contains(nombreprogramaInput))
                                        {
                                            contarRepetidos++;
                                            i = castedCollection.Count();
                                        }
                                    }
                                }
                                //var contains = castedCollection.Select(x => x.referenciaPrograma.ToUpper().Trim()).Contains(nombreprogramaInput);
                                if (contarRepetidos>0)
                                    return new ValidationResult(false,
                                    "La referencia debe ser única");
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
                            return new ValidationResult(false, "La referencia debe ser menor a 30 caracteres");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "La referencia debe ser significativa mayor a 3 letras");
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
        public WrapperPrograma Wrapper { get; set; }
    }
}