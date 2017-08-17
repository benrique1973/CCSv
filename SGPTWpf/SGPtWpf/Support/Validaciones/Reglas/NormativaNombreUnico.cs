using SGPTWpf.Model.Modelo;
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
    public class WrapperNorma : DependencyObject
    {
        public static readonly DependencyProperty listaNormaSeleccionProperty =
             DependencyProperty.Register("listaNormaSeleccion", typeof(ObservableCollection<NormativaModelo>),
             typeof(WrapperNorma), new FrameworkPropertyMetadata());

        public ObservableCollection<NormativaModelo> listaNormaSeleccion
        {
            get { return (ObservableCollection<NormativaModelo>)GetValue(listaNormaSeleccionProperty); }
            set { SetValue(listaNormaSeleccionProperty, value); }
        }
    }

    public class NormativaNombreUnico : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 4)
                    {
                        if (((string)value).Length <= 25)
                        {
                            ObservableCollection<NormativaModelo> castedCollection = this.Wrapper.listaNormaSeleccion;
                            string descripciondp = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                //Descripcion para nombre abreviado, nombrenormativa para nombre largo
                                var contains = castedCollection.Select(x => x.descripcion.ToUpper().Trim()).Contains(descripciondp);
                                if (contains)
                                    return new ValidationResult(false,
                                    "El nombre abreviado debe ser únicos no debe repetirse");
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
                            return new ValidationResult(false, "La descripción debe ser menor a 25 caracteres");
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
        public WrapperNorma Wrapper { get; set; }
    }

    public class NormativaNombreLargoUnico : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 4)
                    {
                        if (((string)value).Length <= 200)
                        {
                            ObservableCollection<NormativaModelo> castedCollection = this.Wrapper.listaNormaSeleccion;
                            string descripciondp = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                //Descripcion para nombre abreviado, nombrenormativa para nombre largo
                                var contains = castedCollection.Select(x => x.nombrenormativa.ToUpper().Trim()).Contains(descripciondp);
                                if (contains)
                                    return new ValidationResult(false,
                                    "El nombre debe ser únicos no debe repetirse");
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
                            return new ValidationResult(false, "La descripción debe ser menor a 200 caracteres");
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
        public WrapperNorma Wrapper { get; set; }
    }
}