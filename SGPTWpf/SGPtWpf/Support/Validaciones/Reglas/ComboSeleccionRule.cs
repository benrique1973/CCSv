using SGPTWpf.Model;
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
    public class WrapperSubProcedimiento: DependencyObject
    {
        public static readonly DependencyProperty listaEntidadSeleccioProperty =
             DependencyProperty.Register("listaEntidadSeleccion", typeof(ObservableCollection<DetalleProgramaModelo>),
             typeof(WrapperSubProcedimiento), new FrameworkPropertyMetadata());

        public ObservableCollection<DetalleProgramaModelo> listaEntidadSeleccion
        {
            get { return (ObservableCollection<DetalleProgramaModelo>)GetValue(listaEntidadSeleccioProperty); }
            set { SetValue(listaEntidadSeleccioProperty, value); }
        }
    }
    public class ComboSeleccionRule : ValidationRule
    {
        public WrapperSubProcedimiento Wrapper { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                bool cuenta = true;
                string mensaje = "";
                TipoProcedimientoModelo eleccion = value as TipoProcedimientoModelo;
                if (eleccion != null)
                {
                    if (eleccion.id == 0)
                    {
                        return new ValidationResult(false, "Debe seleccionar el tipo de procedimiento ");
                    }
                    else
                    {
                        ObservableCollection<DetalleProgramaModelo> castedCollection = this.Wrapper.listaEntidadSeleccion;
                        switch (eleccion.descripcion.ToUpper())
                        {
                            case "PROCEDIMIENTO":
                                break;
                            case "PREGUNTA":
                                break;
                            case "OBJETIVO":
                                break;
                            case "TITULO":
                                break;
                            case "INDICACIONES":
                                break;
                            case "ALCANCE":
                                break;
                            case "SUB-TITULO":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "TITULO").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay títulos para poder crear sub-títulos, cambie su seleccion";
                                }
                                break;
                            case "SUB-SUB-TITULO":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-TITULO").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay sub-títulos para poder crear sub-sub-títulos, cambie su seleccion";
                                }
                                break;
                            case "SUB-INDICACIONES":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "INDICACIONES").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay indicaciones para poder crear sub-indicaciones, cambie su seleccion";
                                }
                                break;
                            case "SUB-SUB-INDICACIONES":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-INDICACIONES").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay sub-sub-indicaciones para poder crear sub-sub-indicaciones, cambie su seleccion";
                                }
                                break;
                            case "SUB-PROCEDIMIENTO":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "PROCEDIMIENTO").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay procedimientos para poder crear sub-procedimientos, cambie su seleccion";
                                }
                                break;
                            case "SUB-SUB-PROCEDIMIENTO":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-PROCEDIMIENTO").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay sub-procedimientos para poder crear sub-sub-procedimientos, cambie su seleccion";
                                }
                                break;
                            case "SUB-PREGUNTA":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "PREGUNTA").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay preguntas para poder crear sub-preguntas, cambie su seleccion";
                                }
                                break;
                            case "SUB-OBJETIVO":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "OBJETIVO").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay objetivos para poder crear sub-objetivos, cambie su seleccion";
                                }
                                break;
                            case "SUB-SUB-OBJETIVO":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-OBJETIVO").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay sub-objetivos para poder crear sub-sub-objetivos, cambie su seleccion";
                                }
                                break;
                            case "SUB-ALCANCE":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "ALCANCE").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay alcances para poder crear sub-alcances, cambie su seleccion";
                                }
                                break;
                            case "SUB-SUB-ALCANCE":
                                if (!(castedCollection.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-ALCANCE").Count() > 0))
                                {
                                    cuenta = false;//No hay registros
                                    mensaje = "No hay sub-alcances para poder crear sub-sub-alcances, cambie su seleccion";
                                }
                                break;
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
