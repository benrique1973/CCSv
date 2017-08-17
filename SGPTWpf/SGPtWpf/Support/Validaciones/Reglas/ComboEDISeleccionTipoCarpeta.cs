using CapaDatos;
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
    public class WrapperEDITipoCarpeta : DependencyObject
    {
        public static readonly DependencyProperty listaEDITipoCarpetaSeleccionProperty =
             DependencyProperty.Register("listaEDITipoCarpetaSeleccion", typeof(ObservableCollection<tipocarpeta>),
             typeof(WrapperEDITipoCarpeta), new FrameworkPropertyMetadata());

        public ObservableCollection<tipocarpeta> listaEDITipoCarpetaSeleccion
        {
            get { return (ObservableCollection<tipocarpeta>)GetValue(listaEDITipoCarpetaSeleccionProperty); }
            set { SetValue(listaEDITipoCarpetaSeleccionProperty, value); }
        }
    }
    public class ComboEDISeleccionTipoCarpeta : ValidationRule
    {
        public WrapperEDITipoCarpeta Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                tipocarpeta eleccion = value as tipocarpeta;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.idtc ==0 )
                    {
                        return new ValidationResult(false, "Debe seleccionar el tipo de carpeta ");
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
