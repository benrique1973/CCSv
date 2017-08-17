using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.ViewModel.Herramientas;
using SGPTWpf.Views.Principales.Herramientas.Marcas;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBMarcas
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

        #region WFBMarcas Constructor

        static WFBMarcas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBMarcas),
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
                    switch (e.NewValue.ToString())
                    {
                        case "MarcasEstandaresCrearView":
                            crearVentana = new MarcasEstandaresCrearView();
                            crearVentana.DataContext = new MarcasEstandaresControllerViewModel();
                            encabezado = "Creación de marcas estándares";
                            break;
                        case "MarcasEstandaresEditarView":
                            crearVentana = new MarcasEstandaresCrearView();
                            crearVentana.DataContext = new MarcasEstandaresControllerViewModel();
                            encabezado = "Actualización de marcas estándares";
                            break;
                        case "MarcasEstandaresConsultarView":
                            crearVentana = new MarcasEstandaresCrearView();
                            crearVentana.DataContext = new MarcasEstandaresControllerViewModel();
                            encabezado = "Consulta de datos de marcas estándares";
                            break;
                        default:
                            //Controller y vista solo para mientras

                            encabezado = "Error"; break;
                    }
                    crearVentana.Width = 1036;
                    crearVentana.Height = 580;
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