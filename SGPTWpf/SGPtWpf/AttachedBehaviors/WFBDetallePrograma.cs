using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Programas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Cuestionario;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Programa;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBDetallePrograma
    {
        #region Private Section
        private static string vista = string.Empty;
        private static string vistaAnterior = string.Empty;
        private static bool controlStrin = true;

        #endregion

        #region Name Dependency Property

        public static readonly DependencyProperty NameProperty;

        public static void SetName(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(NameProperty, value);
        }

        public static string GetName(DependencyObject DepObject)
        {
            return (string)DepObject.GetValue(NameProperty);
        }

        #endregion

        #region WFBDetallePrograma Constructor

        static WFBDetallePrograma()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBDetallePrograma),
                                                               new UIPropertyMetadata(String.Empty, IsFactoryStart));
        }

        #endregion

        #region IsFactoryStart

        private static void IsFactoryStart(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            if (e.NewValue is String && String.IsNullOrEmpty((string)e.NewValue) == false)
            {
                if (controlStrin)
                {
                    vista = e.NewValue.ToString();
                    controlStrin = false;
                }
                else
                {
                    vistaAnterior = e.NewValue.ToString();
                    controlStrin = true;
                }
                if (vistaAnterior == vista)
                {
                    //Repetido
                }
                else
                {
                    var crearVentana = new MetroWindow();
                    string encabezado = "";
                    double ancho = SystemParameters.PrimaryScreenWidth;
                    double largo = SystemParameters.PrimaryScreenHeight * 0.95;
                    switch (e.NewValue.ToString())
                    {
                        /*Herraminas programas y cuestaionarios*/
                        case "DetalleProgramaModeloCrearView":
                            encabezado = "Creación de procedimiento de auditoría";
                            crearVentana = new DetalleProgramaCrudView();
                            crearVentana.DataContext = new DetalleProgramaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.10;
                            crearVentana.MinWidth = ancho * 0.10;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleProgramaModeloEditarView":
                            encabezado = "Actualización de procedimiento de auditoría";
                            crearVentana = new DetalleProgramaCrudView();
                            crearVentana.DataContext = new DetalleProgramaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.10;
                            crearVentana.MinWidth = ancho * 0.10;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleProgramaModeloConsultarView":
                            encabezado = "Consulta de procedimiento de auditoría";
                            crearVentana = new DetalleProgramaCrudView();
                            crearVentana.DataContext = new DetalleProgramaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleCuestionarioModeloCrearView":
                            encabezado = "Creación de pregunta de auditoría";
                            crearVentana = new DetalleCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.10;
                            crearVentana.MinWidth = ancho * 0.10;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleCuestionarioModeloEditarView":
                            encabezado = "Actualización de pregunta de auditoría";
                            crearVentana = new DetalleCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.10;
                            crearVentana.MinWidth = ancho * 0.10;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleCuestionarioModeloConsultarView":
                            encabezado = "Consulta de pregunta de auditoría";
                            crearVentana = new DetalleCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.10;
                            crearVentana.MinWidth = ancho * 0.10;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;

                        /*Casos de Encargos planificacion programas */

                        case "DetallePlanProgramaModeloCrearView":
                            encabezado = "Creación de procedimiento de auditoría";
                            crearVentana = new DetalleProgramaCrudView();
                            //crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanProgramaModeloEditarView":
                            encabezado = "Actualización de procedimiento de auditoría";
                            crearVentana = new DetalleProgramaCrudView();
                            //crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanProgramaModeloConsultarView":
                            encabezado = "Consulta de procedimiento de auditoría";
                            crearVentana = new DetalleProgramaCrudView();
                            //crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanCuestionarioModeloModeloCrearView":
                            encabezado = "Creación de pregunta de auditoría";
                            //crearVentana = new DetalleCuestionarioCrudView();
                            //crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanCuestionarioModeloEditarView":
                            encabezado = "Actualización de pregunta de auditoría";
                            //crearVentana = new DetalleCuestionarioCrudView();
                            //crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanCuestionarioModeloConsultarView":
                            encabezado = "Consulta de pregunta de auditoría";
                            //crearVentana = new DetalleCuestionarioCrudView();
                            //crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        /*Casos de vista en herramientas*/
                        case "ProgramaVistaImpresionView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new ProgramaPresentacionViewModel();
                            break;
                        case "CuestionarioVistaImpresionView":
                            encabezado = "Vista preliminar del cuestionario de auditoría";
                            crearVentana = new CuestionarioViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new CuestionarioPresentacionViewModel();
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error"; break;
                    }
                    crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    crearVentana.Title = encabezado;
                    crearVentana.Owner = Application.Current.MainWindow;
                    crearVentana.Show();
                }
            }
            else
            {
                vista = string.Empty;
                vistaAnterior = string.Empty;
                controlStrin = true;
            }
        }
        #endregion
    }
}