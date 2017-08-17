using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Centralizadora;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Centralizadora;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBCentralizadora
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

        #region WFBCentralizadora Constructor

        static WFBCentralizadora()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBCentralizadora),
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

                        case "CedulaCentralizadoraCrearview":
                            encabezado = "Creación de resúmenes de sumarias";
                            crearVentana = new CentralizadoraCrudView();
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaCentralizadoraEditarView":
                            encabezado = "Actualización de resúmenes de sumarias";
                            crearVentana = new CentralizadoraCrudView();
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaCentralizadoraConsultarView":
                            encabezado = "Consulta de resúmenes de sumarias";
                            crearVentana = new CentralizadoraCrudView();
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaCentralizadoraImportarView":
                            encabezado = "Consulta de resúmenes de sumarias";
                            crearVentana = new CentralizadoraCrudView();
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaCentralizadoraVerView":
                            encabezado = "Vista de resúmenes de sumarias";
                            crearVentana = new CentralizadoraPresentacionView();
                            crearVentana.DataContext = new CentralizadoraPresentacionViewModel("CedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaCentralizadoraReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            break;
                        case "CedulaCentralizadoraCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            break;
                        case "CedulaCentralizadoraSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            break;
                        case "CedulaCentralizadoraAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new CentralizadoraControllerViewModel("DocumentacionCedulaCentralizadora");
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error"; break;
                    }
                    crearVentana.WindowStartupLocation = WindowStartupLocation.Manual;
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