using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.Views.Principales.Herramientas.Indice;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBPlantillaIndice
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

        #region WFBPlantillaIndice Constructor

        static WFBPlantillaIndice()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBPlantillaIndice),
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
                        case "PlantillaIndiceCrearView":
                            encabezado = "Creación de plantilla de índices";
                            crearVentana = new PlantillaIndiceEdicionView();
                            crearVentana.DataContext = new PlantillaIndiceControllerViewModel();
                            crearVentana.MinWidth = 500;
                            crearVentana.MinHeight = 150;

                            break;
                        case "PlantillaIndiceEditarView":
                            encabezado = "Actualización de plantilla de índices";
                            crearVentana = new PlantillaIndiceEdicionView();
                            crearVentana.DataContext = new PlantillaIndiceControllerViewModel();
                            crearVentana.MinWidth = 500;
                            crearVentana.MinHeight = 150;

                            break;
                        case "PlantillaIndiceConsultarView":
                            encabezado = "Consulta de plantilla de índices";
                            crearVentana = new PlantillaIndiceEdicionView();
                            crearVentana.DataContext = new PlantillaIndiceControllerViewModel();
                            crearVentana.MinWidth = 500;
                            crearVentana.MinHeight = 150;

                            break;
                        case "PlantillaIndiceCopiarView":
                            encabezado = "Copia de plantilla de índices";
                            crearVentana = new PlantillaIndiceEdicionView();
                            crearVentana.DataContext = new PlantillaIndiceControllerViewModel();
                            crearVentana.MinWidth = 500;
                            crearVentana.MinHeight = 150;

                            break;
                        case "PlantillaIndicePreviewView":
                            encabezado = "Vista preliminar de  índice para impresión";
                            crearVentana = new PlantillaIndicePreView();
                            crearVentana.DataContext = new PlantillaIndicePreViewModel();
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