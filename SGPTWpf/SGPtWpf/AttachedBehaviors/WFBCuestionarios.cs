using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Cuestionario;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBCuestionarios
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

        #region WFBCuestionarios Constructor

        static WFBCuestionarios()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBCuestionarios),
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
                        case "CuestionarioModeloCrearView":
                            encabezado = "Creación de cuestionario de auditoría";
                            crearVentana = new CuestionarioCrearView();
                            crearVentana.MinHeight = 200;
                            crearVentana.MinWidth = 300;
                            crearVentana.Width = 640;
                            crearVentana.Height = 360;
                            crearVentana.DataContext = new CuestionarioControllerViewModel();
                            break;
                        case "CuestionarioCopiarView":
                            encabezado = "Copia de cuestionario de auditoría";
                            crearVentana = new CuestionarioCrearView();
                            crearVentana.MinHeight = 200;
                            crearVentana.MinWidth = 300;
                            crearVentana.Width = 640;
                            crearVentana.Height = 400;
                            crearVentana.DataContext = new CuestionarioControllerViewModel();
                            break;
                        case "CuestionarioModeloEditarView":
                            //Temporal
                            encabezado = "Edición de cuestionario de auditoría";
                            crearVentana = new CuestionarioCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            //crearVentana.Width = ancho;
                            //crearVentana.Height = largo;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CuestionarioControllerViewModel();
                            break;
                        case "CuestionarioModeloImportarPlantillaView":
                            //Temporal
                            encabezado = "Importacion de programas de auditoría de plantillas";
                            crearVentana = new ImportacionSeleccionCuestionarioView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CuestionarioControllerViewModel(6);
                            break;
                        case "CuestionarioModeloImportarEncargoView":
                            //Temporal
                            encabezado = "Importacion de programas de auditoría de encargos anteriores";
                            crearVentana = new ImportacionSeleccionCuestionarioView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CuestionarioControllerViewModel(7);
                            break;
                        case "CuestionarioModeloConsultarView":
                            //Temporal
                            encabezado = "Consulta de cuestionario de auditoría";
                            crearVentana = new CuestionarioCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new CuestionarioControllerViewModel();
                            break;
                        case "CuestionarioModeloVerCuestionarioView":
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