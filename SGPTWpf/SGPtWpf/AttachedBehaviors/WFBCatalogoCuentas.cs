using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.CatalogoCuentas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.ImportarAchivo;
using SGPTWpf.Views.Compartidas;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBCatalogoCuentas
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

        #region WFBCatalogoCuentas Constructor

        static WFBCatalogoCuentas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBCatalogoCuentas),
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

                        case "CatalogoCuentasModeloCargarView":
                            encabezado = "Carga de catalogo de cuentas";
                            crearVentana = new ImportarArchivosView();
                            //crearVentana = new ImportarArchivosGeneralesView();
                            crearVentana.DataContext = new ImportarArchivosGeneralesViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.60;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CatalogoCuentasModeloCrearview":
                            encabezado = "Creación de cuentas del catalogo de cuentas";
                            crearVentana = new CatalogoCuentasCrudView();
                            crearVentana.DataContext = new CatalogoCuentasControllerViewModel();
                            crearVentana.MinHeight = 350;
                            crearVentana.MinWidth = 500;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        case "CatalogoCuentasModeloEditarView":
                            encabezado = "Actualización de cuentas de catálogo";
                            crearVentana = new CatalogoCuentasCrudView();
                            crearVentana.DataContext = new CatalogoCuentasControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        case "CatalogoCuentasModeloConsultarView":
                            encabezado = "Consulta de cuentas de catalogo";
                            crearVentana = new CatalogoCuentasCrudView();
                            crearVentana.DataContext = new CatalogoCuentasControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        /*Casos de vista en herramientas*/
                        case "CatalogoCuentasModeloImportarView":
                            encabezado = "Importacion de catalogos de cuentas de encargos anteriores";
                            crearVentana = new ImportacionCatalogoCuentasView();
                            crearVentana.DataContext = new CatalogoCuentasControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error"; break;
                    }
                    //crearVentana.WindowStartupLocation = WindowStartupLocation.CenterOwner;
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