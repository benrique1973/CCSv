using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cierre;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBEncargoCierre
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

        #region WFBEncargoCierre Constructor

        static WFBEncargoCierre()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBEncargoCierre),
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
                    double ancho = PrincipalAlterna.ancho;
                    double largo = PrincipalAlterna.largo;
                    switch (e.NewValue.ToString())
                    {
                        /*Casos de Encargos planificacion programas */

                        case "EncargoModeloCrearview":
                            encabezado = "Creación de Encargos";
                            crearVentana = new MatrizRiesgosCrudView();
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "EncargoModeloEditarView":
                            encabezado = "Actualización de encargos";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "EncargoModeloConsultarView":
                            encabezado = "Consulta de encargos";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "EncargoModeloReferenciarView":
                            encabezado = "Referenciación de Encargos de auditoría";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            break;
                        case "EncargoModeloCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            break;
                        case "EncargoModeloSupervisarView":
                            encabezado = "Supervisa y aprueba en el encargo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            break;
                        case "EncargoModeloAprobarView":
                            encabezado = "Terminación del encargo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CierreEncargoControllerViewModel();
                            break;
                        case "EncargoModeloVistaView":
                            encabezado = "Terminación del encargo";
                            crearVentana = new RiesgoViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RiesgoPresentacionViewModel();
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error"; break;
                    }
                    // crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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