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
    public class WrapperDCElemento : DependencyObject
    {
        public static readonly DependencyProperty listaDCElementoSeleccionProperty =
             DependencyProperty.Register("listaDCElementoSeleccion", typeof(ObservableCollection<ElementoModelo>),
             typeof(WrapperDCElemento), new FrameworkPropertyMetadata());

        public ObservableCollection<ElementoModelo> listaDCElementoSeleccion
        {
            get { return (ObservableCollection<ElementoModelo>)GetValue(listaDCElementoSeleccionProperty); }
            set { SetValue(listaDCElementoSeleccionProperty, value); }
        }
    }
    public class ComboDCCSeleccionElementoRule : ValidationRule
    {
        public WrapperDCElemento Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                ElementoModelo eleccion = value as ElementoModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.id == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar la clase de elemento contable ");
                    }
                    else
                    {
                            return new ValidationResult(true, null);
                    }
                }
                else
                {
                    return new ValidationResult(false, "No pudo realizarse la conversion ");
                }
            }
            catch (Exception)
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
