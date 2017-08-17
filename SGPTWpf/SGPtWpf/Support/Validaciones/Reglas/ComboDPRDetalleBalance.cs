using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//http://stackoverflow.com/questions/26589853/wpf-combobox-validationrules
//https://msdn.microsoft.com/es-sv/library/cscsdfbt.aspx
//https://msdn.microsoft.com/es-sv/library/cc488006.aspx
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class WrapperDPRDetalleBalance : DependencyObject
    {
        public static readonly DependencyProperty listaEntidadSeleccionProperty =
             DependencyProperty.Register("listaEntidadSeleccion", typeof(ObservableCollection<DetalleMatrizRiesgoModelo>),
             typeof(WrapperDPRDetalleBalance), new FrameworkPropertyMetadata());

        public ObservableCollection<DetalleMatrizRiesgoModelo> listaEntidadSeleccion
        {
            get { return (ObservableCollection<DetalleMatrizRiesgoModelo>)GetValue(listaEntidadSeleccionProperty); }
            set { SetValue(listaEntidadSeleccionProperty, value); }
        }
    }
    public class ComboDPRDetalleBalance : ValidationRule
    {
        public WrapperDPRDetalleBalance Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                DetalleBalanceModelo eleccion = value as DetalleBalanceModelo;
                if (eleccion != null)
                {
                    try
                    {

                                ObservableCollection<DetalleMatrizRiesgoModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                                if (castedCollection !=null && castedCollection.Count > 0)
                                {
                                    var contains = castedCollection.Where(x => x.codigocontabledmr==eleccion.codigoccdb);
                                    if (contains.Count()>0)
                                        return new ValidationResult(false,
                                        "La cuenta, rubro o elemento ya esta seleccionado, no puede agregarse 2 veces");
                                    else
                                        return new ValidationResult(true, null);
                                }
                                else
                                {
                                    return new ValidationResult(true, null);
                                }
                    }
                    catch (Exception)
                    {
                        return new ValidationResult(false, "Error en la validación" );
                    }

                }
                else
                {
                    return new ValidationResult(false, "Debe seleccionar un elemento ");
                }

            }
            catch (Exception )
            {
                return new ValidationResult(false, "Error en la validación ingresada " );
            }
        }
    }
}
