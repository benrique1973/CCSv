using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Programas;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using SGPTWpf.ViewModel.Herramientas.Programas;
using SGPTWpf.Views.Principales.Herramientas.Cuestionarios;
using SGPTWpf.Views.Principales.Herramientas.Tools;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBHerramientas
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

        #region WFBHerramientas Constructor

        static WFBHerramientas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBHerramientas),
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
                    //Temporal
                    double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

                    double largo = System.Windows.SystemParameters.PrimaryScreenHeight * 0.95;
                    var crearVentana = new MetroWindow();
                    string encabezado = "";
                    switch (e.NewValue.ToString())
                    { 
                        case "HerramientaModeloCrearView":
                            encabezado = "Creación de programa de auditoría";
                            crearVentana = new HProgramaCrearView();
                            crearVentana.MinHeight = 200;
                            crearVentana.MinWidth = 300;
                            crearVentana.Width = 640;
                            crearVentana.Height = 360;
                            crearVentana.DataContext = new HerramientasControllerCrearViewModel();
                            break;
                        case "ProgramaCopiarView":
                            encabezado = "Copia de programa de auditoría";
                            crearVentana = new HProgramaCrearView();
                            crearVentana.MinHeight = 200;
                            crearVentana.MinWidth = 300;
                            crearVentana.Width = 640;
                            crearVentana.Height = 360;
                            crearVentana.DataContext = new HerramientasControllerCrearViewModel();
                            break;
                        case "HerrramientaModeloEditarView":
                            //Temporal
                            encabezado = "Edición de programa de auditoría";
                            crearVentana = new HerramientasProgramaCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new HerramientasControllerViewModel();
                            break;
                        case "HerrramientaModeloConsultarView":
                            //Temporal
                            encabezado = "Consulta de programa de auditoría";
                            crearVentana = new HerramientasProgramaCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new HerramientasControllerViewModel();
                            break;
                        case "HerrramientaModeloVerProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new ProgramaPresentacionViewModel();
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error";
                            break;
                    }
                    //Configuración de pantalla
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