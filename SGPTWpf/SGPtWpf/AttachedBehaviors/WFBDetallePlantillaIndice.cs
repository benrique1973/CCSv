using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.ViewModel.Herramientas.Programas;
using SGPTWpf.Views.Principales.Herramientas.Indice;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBDetallePlantillaIndice
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

        #region WFBDetallePlantillaIndice Constructor

        static WFBDetallePlantillaIndice()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBDetallePlantillaIndice),
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
                    crearVentana = new DetallePlantillaIndiceEdicionView();
                    crearVentana.DataContext = new DetallePlantillaIndiceControllerViewModel();
                    switch (e.NewValue.ToString())
                    {
                        case "DetallePlantillaIndiceCrearView":
                            encabezado = "Creación de elemento del índices";
                            break;
                        case "DetallePlantillaIndiceEditarView":
                            encabezado = "Actualización de elemento de índice";
                            break;
                        case "DetallePlantillaIndiceConsultarView":
                            encabezado = "Consulta de elemento del índice";
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error en elemento de índice";
                            break;
                    }
                    crearVentana.MinWidth = 500;
                    crearVentana.MinHeight = 360;
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