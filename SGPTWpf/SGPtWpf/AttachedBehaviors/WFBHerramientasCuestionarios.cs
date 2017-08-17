using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Cuestionarios;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using SGPTWpf.ViewModel.Herramientas.Programas;
using SGPTWpf.Views.Principales.Herramientas.Cuestionarios;
using SGPTWpf.Views.Principales.Herramientas.Tools;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBHerramientasCuestionarios
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

        #region WFBHerramientasCuestionarios Constructor

        static WFBHerramientasCuestionarios()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBHerramientasCuestionarios),
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
                        case "HerramientaModeloCrearCuestionarioView":
                            encabezado = "Creación de cuestionario de auditoría";
                            crearVentana = new HCuestionarioCrearView();
                            crearVentana.MinHeight = 200;
                            crearVentana.MinWidth = 300;
                            crearVentana.Width = 640;
                            crearVentana.Height = 360;
                            crearVentana.DataContext = new HerramientasCuestionarioControllerCrearViewModel();
                            break;
                        case "CuestionarioCopiarView":
                            encabezado = "Copia de cuestionario de auditoría";
                            crearVentana = new HCuestionarioCrearView();
                            crearVentana.MinHeight = 200;
                            crearVentana.MinWidth = 300;
                            crearVentana.MaxWidth = 640;
                            crearVentana.MaxHeight = 360;
                            crearVentana.DataContext = new HerramientasCuestionarioControllerCrearViewModel();
                            break;
                        case "HerrramientaModeloEditarCuestionarioView":
                            //Temporal
                            encabezado = "Edición de cuestionario de auditoría";
                            crearVentana = new HerramientasCuestionarioCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new HerramientasCuestionarioControllerViewModel();
                            break;
                        case "HerrramientaModeloConsultarCuestionarioView":
                            //Temporal
                            encabezado = "Consulta de cuestionario de auditoría";
                            crearVentana = new HerramientasCuestionarioCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new HerramientasCuestionarioControllerViewModel();
                            break;
                        case "HerrramientaModeloVerCuestionarioView":
                            encabezado = "Vista preliminar del cuestionario de auditoría";
                            crearVentana = new CuestionarioImpresionView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new CuestionarioPresentacionViewModel();
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