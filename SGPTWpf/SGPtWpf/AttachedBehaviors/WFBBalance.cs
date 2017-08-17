using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances.DetalleBalance;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.CatalogoCuentas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.ImportarAchivo;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBBalance
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

        #region WFBBalance Constructor

        static WFBBalance()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBBalance),
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
                    double ancho = SystemParameters.PrimaryScreenWidth;
                    double largo = SystemParameters.PrimaryScreenHeight * 0.95;
                    switch (e.NewValue.ToString())
                    {
                        /*Casos de Encargos planificacion programas */

                        case "BalanceModeloCargarView":
                            encabezado = "Carga de balance";
                            crearVentana = new ImportarArchivosView();
                            //crearVentana = new ImportarArchivosGeneralesView();
                            crearVentana.DataContext = new ImportarArchivosGeneralesViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;

                        case "BalanceModeloCrearview":
                            encabezado = "Creación de balance";
                            crearVentana = new BalancesCrudView();
                            crearVentana.DataContext = new BalancesControllerViewModel();
                            crearVentana.MinHeight = 350;
                            crearVentana.MinWidth = 500;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        case "BalanceModeloEditarView":
                            encabezado = "Actualización de balance";
                            crearVentana = new BalancesCrudView();
                            crearVentana.DataContext = new BalancesControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        case "BalanceModeloConsultarView":
                            encabezado = "Consulta de balance";
                            crearVentana = new BalancesCrudView();
                            crearVentana.DataContext = new BalancesControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        //case "BalanceModeloImportarView":
                        //    encabezado = "Importar balances de encargos anteriores";
                        //    crearVentana = new ImportarBalancesView();
                        //    crearVentana.DataContext = new BalancesControllerViewModel();
                        //    crearVentana.MinHeight = largo * 0.30;
                        //    crearVentana.MinWidth = ancho * 0.20;
                        //    crearVentana.MaxWidth = largo;
                        //    crearVentana.MaxHeight = ancho;
                        //    break;
                        ///*Casos de vista en herramientas*/
                        case "BalanceModeloImportarView":
                            encabezado = "Importacion de balance de cuentas de encargos anteriores";
                            crearVentana = new ImportarBalancesView();
                            crearVentana.DataContext = new BalancesControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                            //Casos del detalle
                        case "DetalleBalanceModeloCrearview":
                            encabezado = "Creación de balance";
                            crearVentana = new DetalleBalanceCrudView();
                            crearVentana.DataContext = new DetalleBalanceControllerViewModel();
                            crearVentana.MinHeight = 350;
                            crearVentana.MinWidth = 500;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        case "DetalleBalanceModeloEditarView":
                            encabezado = "Actualización de balance";
                            crearVentana = new DetalleBalanceCrudView();
                            crearVentana.DataContext = new DetalleBalanceControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
                            break;
                        case "DetalleBalanceModeloConsultarView":
                            encabezado = "Consulta de balance";
                            crearVentana = new DetalleBalanceCrudView();
                            crearVentana.DataContext = new DetalleBalanceControllerViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = largo;
                            crearVentana.MaxHeight = ancho;
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