using SGPTWpf.Model;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
//http://stackoverflow.com/questions/26589853/wpf-combobox-validationrules
//https://msdn.microsoft.com/es-sv/library/cscsdfbt.aspx
//https://msdn.microsoft.com/es-sv/library/cc488006.aspx
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperHITipoElemento  : DependencyObject
    {
        public static readonly DependencyProperty listaEntidadTEISeleccionProperty =
             DependencyProperty.Register("listaEntidadTEISeleccion", typeof(ObservableCollection<TipoElementoIndiceModelo>),
             typeof(WrapperHITipoElemento ), new FrameworkPropertyMetadata());

        public ObservableCollection<TipoElementoIndiceModelo> listaEntidadTEISeleccion
        {
            get { return (ObservableCollection<TipoElementoIndiceModelo>)GetValue(listaEntidadTEISeleccionProperty); }
            set { SetValue(listaEntidadTEISeleccionProperty, value); }
        }
    }
    public class ComboHISeleccionTipoElementoIndice : ValidationRule
    {
        public WrapperHITipoElemento  Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                TipoElementoIndiceModelo eleccion = value as TipoElementoIndiceModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.id == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar un elemento ");
                    }
                    else
                    {
                        return new ValidationResult(true, null);
                    }
                }
                else
                {
                    return new ValidationResult(false, "Debe seleccionar un elemento ");
                }

            }
            catch (Exception)
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
