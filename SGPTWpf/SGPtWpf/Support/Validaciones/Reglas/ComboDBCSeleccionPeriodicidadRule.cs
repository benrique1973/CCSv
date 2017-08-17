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
    public class WrapperDBCPeriodo : DependencyObject
    {
        public static readonly DependencyProperty listaDBCPeriodoSeleccionProperty =
             DependencyProperty.Register("listaDBCPeriodoSeleccion", typeof(ObservableCollection<PeriodoModelo>),
             typeof(WrapperDBCPeriodo), new FrameworkPropertyMetadata());

        public ObservableCollection<PeriodoModelo> listaDBCPeriodoSeleccion
        {
            get { return (ObservableCollection<PeriodoModelo>)GetValue(listaDBCPeriodoSeleccionProperty); }
            set { SetValue(listaDBCPeriodoSeleccionProperty, value); }
        }
    }
    public class ComboDBCSeleccionPeriodicidadRule : ValidationRule
    {
        public WrapperDBCPeriodo Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                PeriodoModelo eleccion = value as PeriodoModelo;
                if (eleccion != null)
                {
                    if (eleccion == null || eleccion.id == 0)
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
