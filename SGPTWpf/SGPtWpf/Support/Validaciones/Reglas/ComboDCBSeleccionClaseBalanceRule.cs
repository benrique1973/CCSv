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
    public class WrapperDBCClaseBalance : DependencyObject
    {
        public static readonly DependencyProperty listaDBCClaseBalanceSeleccionProperty =
             DependencyProperty.Register("listaDBCClaseBalanceSeleccion", typeof(ObservableCollection<ClaseBalanceModelo>),
             typeof(WrapperDBCClaseBalance), new FrameworkPropertyMetadata());

        public ObservableCollection<ClaseBalanceModelo> listaDBCClaseBalanceSeleccion
        {
            get { return (ObservableCollection<ClaseBalanceModelo>)GetValue(listaDBCClaseBalanceSeleccionProperty); }
            set { SetValue(listaDBCClaseBalanceSeleccionProperty, value); }
        }
    }
    public class ComboDCBSeleccionClaseBalanceRule : ValidationRule
    {
        public WrapperDBCClaseBalance Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                ClaseBalanceModelo eleccion = value as ClaseBalanceModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.idCb == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar la clase de balance contable ");
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
