using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Encargos;
using SGPTWpf.ViewModel.Encargos.Gestion;
using SGPTWpf.Views.Principales.Encargos;
using SGPTWpf.Views.Principales.Encargos.Gestion;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBAsignacion
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

        #region WFBAsignacion Constructor

        static WFBAsignacion()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBAsignacion),
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
                        case "AsignacionModeloCrearView":
                            encabezado = "Seleccione el empleado a asignar";
                            crearVentana = new AsignacionEdicionView();
                            crearVentana.DataContext = new AsignacionControllerViewModel();
                            crearVentana.Width = 600;
                            crearVentana.Height = 300;
                            break;
                        case "AsignacionModeloEditarView":
                            encabezado = "Seleccione el empleado para editar";
                            crearVentana = new AsignacionEdicionView();
                            crearVentana.DataContext = new AsignacionControllerViewModel();
                            crearVentana.Width = 600;
                            crearVentana.Height = 300;
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