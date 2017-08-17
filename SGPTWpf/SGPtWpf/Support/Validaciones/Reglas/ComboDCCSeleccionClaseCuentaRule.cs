using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
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
    public class WrapperDCCuentas : DependencyObject
    {
        public static readonly DependencyProperty listaDCCSeleccionProperty =
             DependencyProperty.Register("listaDCCSeleccion", typeof(ObservableCollection<CatalogoCuentasModelo>),
             typeof(WrapperDCCuentas), new FrameworkPropertyMetadata());

        public ObservableCollection<CatalogoCuentasModelo> listaDCCSeleccion
        {
            get { return (ObservableCollection<CatalogoCuentasModelo>)GetValue(listaDCCSeleccionProperty); }
            set { SetValue(listaDCCSeleccionProperty, value); }
        }
    }
    public class ComboDCCSeleccionClaseCuentaRule : ValidationRule
    {
        public WrapperDCCuentas Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                bool cuenta = true;
                bool cuentaBase = false;
                string mensaje = "";
                ClaseCuentaModelo eleccion = value as ClaseCuentaModelo;
                if (eleccion != null)
                {
                    if (eleccion==null || eleccion.id == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar el nivel de la cuenta ");
                    }
                    else
                    {
                        string dependencia = string.Empty;
                        ObservableCollection<CatalogoCuentasModelo> castedCollection = this.Wrapper.listaDCCSeleccion;
                        switch (eleccion.descripcionccuentas.ToUpper().Trim())
                        {
                            case "ELEMENTO":
                                cuentaBase = true;
                                break;
                            case "RUBRO":
                                dependencia = "ELEMENTO";
                                break;
                            case "CUENTA":
                                dependencia = "RUBRO";
                                break;
                            case "SUB-CUENTA":
                                dependencia = "CUENTA";
                                break;
                            case "SUB-SUB-CUENTA":
                                dependencia = "SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-CUENTA":
                                dependencia = "SUB-SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-SUB-CUENTA":
                                dependencia = "SUB-SUB-SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-SUB-SUB-CUENTA":
                                dependencia = "SUB-SUB-SUB-SUB-CUENTA";
                                break;
                        }
                        if (cuentaBase)
                        {
                            //Es una cuenta base no hay nada que deba depender de ella
                            return new ValidationResult(true, null);
                        }
                        else
                        { 
                        if (!(castedCollection.Where(x => x.nombreClaseCuenta.ToUpper().Trim() == dependencia).Count() > 0))
                        {
                            cuenta = false;//No hay registros
                            mensaje = "No hay cuentas de ese nivel para poder tener esa clase de cuenta, cambie su seleccion";
                        }
                        if (cuenta)
                        {
                            return new ValidationResult(true, null);
                        }
                        else
                        {
                            return new ValidationResult(false, mensaje);
                        }
                        }
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
