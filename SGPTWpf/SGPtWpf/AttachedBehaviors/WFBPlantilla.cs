using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Plantillas;
using SGPTWpf.Views.Principales.Herramientas.Plantillas;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBPlantilla
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

        #region WFBPlantilla Constructor

        static WFBPlantilla()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBPlantilla),
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
                        case "PlantillaModeloCrearView":
                            encabezado = "Creación de plantilla";
                            crearVentana = new PlantillaEdicionView();
                            crearVentana.DataContext = new PlantillaControllerViewModel();
                            crearVentana.MinWidth = 300;
                            crearVentana.MinHeight = 300;

                            break;
                        case "PlantillaModeloEditarView":
                            encabezado = "Actualización de plantilla";
                            crearVentana = new PlantillaEdicionView();
                            crearVentana.DataContext = new PlantillaControllerViewModel();
                            crearVentana.MinWidth = 300;
                            crearVentana.MinHeight = 300;

                            break;
                        case "PlantillaModeloConsultarView":
                            encabezado = "Consulta de plantilla";
                            crearVentana = new PlantillaEdicionView();
                            crearVentana.DataContext = new PlantillaControllerViewModel();
                            crearVentana.MinWidth = 300;
                            crearVentana.MinHeight = 300;
                            break;
                        case "PlantillaIndiceCopiarView":
                            encabezado = "Copia de plantilla";
                            crearVentana = new PlantillaEdicionView();
                            crearVentana.DataContext = new PlantillaControllerViewModel();
                            crearVentana.MinWidth = 300;
                            crearVentana.MinHeight = 300;

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