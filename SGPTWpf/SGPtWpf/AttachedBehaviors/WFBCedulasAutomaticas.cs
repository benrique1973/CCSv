using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBCedulasAutomaticas
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

        #region WFBCedulasAutomaticas Constructor

        static WFBCedulasAutomaticas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBCedulasAutomaticas),
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

                        case "CedulaModeloCrearview":
                            encabezado = "Creación de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloEditarView":
                            encabezado = "Actualización de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloConsultarView":
                            encabezado = "Consulta de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
                            break;
                        case "CedulaModeloCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
                            break;
                        case "CedulaModeloSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
                            break;
                        case "CedulaModeloAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulas");
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