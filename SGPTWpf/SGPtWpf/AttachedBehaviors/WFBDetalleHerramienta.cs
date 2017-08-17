using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Cuestionarios;
using SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Programas;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using SGPTWpf.ViewModel.Herramientas.Programas;
using SGPTWpf.Views.Principales.Herramientas.Cuestionarios;
using SGPTWpf.Views.Principales.Herramientas.Tools;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBDetalleHerramienta
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

        #region WFBDetalleHerramienta Constructor

        static WFBDetalleHerramienta()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBDetalleHerramienta),
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
                    double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
                    double largo = System.Windows.SystemParameters.PrimaryScreenHeight * 0.95;
                    switch (e.NewValue.ToString())
                    {
                        /*Herraminas programas y cuestaionarios*/
                        case "DetalleHerrramientaModeloCrearView":
                            encabezado = "Creación de procedimiento de auditoría";
                            crearVentana = new DetalleHProgramaCrudView();
                            crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetalleHerrramientaModeloEditarView":
                            encabezado = "Actualización de procedimiento de auditoría";
                            crearVentana = new DetalleHProgramaCrudView();
                            crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetalleHerrramientaModeloConsultarView":
                            encabezado = "Consulta de procedimiento de auditoría";
                            crearVentana = new DetalleHProgramaCrudView();
                            crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "CuestionarioDetalleHerrramientaModeloCrearView":
                            encabezado = "Creación de pregunta de auditoría";
                            crearVentana = new DetalleHCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "CuestionarioDetalleHerrramientaModeloEditarView":
                            encabezado = "Actualización de pregunta de auditoría";
                            crearVentana = new DetalleHCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "CuestionarioDetalleHerrramientaModeloConsultarView":
                            encabezado = "Consulta de pregunta de auditoría";
                            crearVentana = new DetalleHCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;

                        /*Casos de Encargos planificacion programas */

                        case "DetallePlanProgramaModeloCrearView":
                            encabezado = "Creación de procedimiento de auditoría";
                            crearVentana = new DetalleHProgramaCrudView();
                            crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanProgramaModeloEditarView":
                            encabezado = "Actualización de procedimiento de auditoría";
                            crearVentana = new DetalleHProgramaCrudView();
                            crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanProgramaModeloConsultarView":
                            encabezado = "Consulta de procedimiento de auditoría";
                            crearVentana = new DetalleHProgramaCrudView();
                            crearVentana.DataContext = new DetalleHerramientaControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanCuestionarioModeloModeloCrearView":
                            encabezado = "Creación de pregunta de auditoría";
                            crearVentana = new DetalleHCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanCuestionarioModeloEditarView":
                            encabezado = "Actualización de pregunta de auditoría";
                            crearVentana = new DetalleHCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;
                        case "DetallePlanCuestionarioModeloConsultarView":
                            encabezado = "Consulta de pregunta de auditoría";
                            crearVentana = new DetalleHCuestionarioCrudView();
                            crearVentana.DataContext = new DetalleHerramientaCuestionarioControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = 780;
                            crearVentana.Height = 450;
                            break;

                        /*Casos de vista en herramientas*/
                        case "ProgramaVistaImpresionView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.DataContext = new ProgramaPresentacionViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            break;
                        case "HerrramientaModeloVerCuestionarioView":
                            encabezado = "Vista preliminar del cuestionario de auditoría";
                            crearVentana = new CuestionarioImpresionView();
                            crearVentana.DataContext = new CuestionarioPresentacionViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
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