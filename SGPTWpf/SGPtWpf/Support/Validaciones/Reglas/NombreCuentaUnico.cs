using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperCuentaContable : DependencyObject
    {
        public static readonly DependencyProperty listaEntidadSeleccionProperty =
             DependencyProperty.Register("listaEntidadSeleccion", typeof(ObservableCollection<CatalogoCuentasModelo>),
             typeof(WrapperCuentaContable), new FrameworkPropertyMetadata());

        public ObservableCollection<CatalogoCuentasModelo> listaEntidadSeleccion
        {
            get { return (ObservableCollection<CatalogoCuentasModelo>)GetValue(listaEntidadSeleccionProperty); }
            set { SetValue(listaEntidadSeleccionProperty, value); }
        }
    }

    public class NombreCuentaUnico : ValidationRule
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
                        if (((string)value).Length <= 150)
                        {
                            ObservableCollection<CatalogoCuentasModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                            string nombreprogramaInput = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.descripcioncc.ToUpper().Trim()).Contains(nombreprogramaInput);
                                if (contains)
                                    return new ValidationResult(false,
                                    "El nombre del elemento, rubro o cuenta debe ser único");
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
                            return new ValidationResult(false, "El nombre debe ser menor a 150 caracteres");
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
        public WrapperCuentaContable Wrapper { get; set; }
    }

}