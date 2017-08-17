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
    public class WrapperCodicoCuentaContable : DependencyObject
    {
        public static readonly DependencyProperty listaEntidadSeleccionProperty =
             DependencyProperty.Register("listaEntidadSeleccion", typeof(ObservableCollection<CatalogoCuentasModelo>),
             typeof(WrapperCodicoCuentaContable), new FrameworkPropertyMetadata());

        public ObservableCollection<CatalogoCuentasModelo> listaEntidadSeleccion
        {
            get { return (ObservableCollection<CatalogoCuentasModelo>)GetValue(listaEntidadSeleccionProperty); }
            set { SetValue(listaEntidadSeleccionProperty, value); }
        }
    }

    public class CodigoCuentaContableUnicoRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 1)
                    {
                        if (((string)value).Length <= 30)
                        {
                            ObservableCollection<CatalogoCuentasModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                            string nombreprogramaInput = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.codigocc.ToUpper().Trim()).Contains(nombreprogramaInput);
                                if (contains)
                                    return new ValidationResult(false,
                                    "El código debe ser unico");
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
                            return new ValidationResult(false, "El nombre debe ser menor a 30 caracteres");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "El nombre debe ser mayor o igual a un caracter");
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
        public WrapperCodicoCuentaContable Wrapper { get; set; }
    }


    public class BusquedaCuentaContableUnicoRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            //return ValidationResult.ValidResult;
            if (value != null || (!string.IsNullOrEmpty(value.ToString())))
            {
                try
                {
                    if (((string)value).Length >= 1)
                    {
                        if (((string)value).Length <= 30)
                        {
                            ObservableCollection<CatalogoCuentasModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                            string nombreprogramaInput = (string)value.ToString().ToUpper().Trim();
                            if (castedCollection.Count > 0)
                            {
                                var contains = castedCollection.Select(x => x.codigocc.ToUpper().Trim()).Contains(nombreprogramaInput);
                                if (!contains)
                                    return new ValidationResult(false,
                                    "El código no existe en  el catalogo de cuentas");
                                else
                                    return new ValidationResult(true, null);
                            }
                            else
                            {
                                return new ValidationResult(false,
                                "El catalogo de cuentas no contiene cuentas ");
                            }
                        }
                        else
                        {
                            return new ValidationResult(false, "El codigo debe ser menor a 30 caracteres");
                        }
                    }
                    else
                    {
                        return new ValidationResult(false, "El codigo debe ser mayor o igual a un caracter");
                    }

                }
                catch (Exception)
                {
                    return new ValidationResult(false, "No ha ingresado el codigo");
                }
            }
            else
            {
                return new ValidationResult(false, "No ha ingresado el codigo");
            }
        }
        public WrapperCodicoCuentaContable Wrapper { get; set; }
    }
}