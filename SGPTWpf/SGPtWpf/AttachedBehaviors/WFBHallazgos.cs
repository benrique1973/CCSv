using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBHallazgos
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

        #region WFBHallazgos Constructor

        static WFBHallazgos()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBHallazgos),
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

                        case "CedulaHallazgosCrearview":
                            encabezado = "Creación de Hallazgos";
                            crearVentana = new HallazgosCrudView();
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaHallazgosEditarView":
                            encabezado = "Actualización de Hallazgos";
                            crearVentana = new HallazgosCrudView();
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaHallazgosConsultarView":
                            encabezado = "Consulta de Hallazgos";
                            crearVentana = new HallazgosCrudView();
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaHallazgosImportarView":
                            encabezado = "Consulta de Hallazgos";
                            crearVentana = new HallazgosCrudView();
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaHallazgosVerView":
                            encabezado = "Vista de Hallazgos";
                            crearVentana = new HallazgosImpresionView();
                            crearVentana.DataContext = new HallazgosPresentacionViewModel("CedulaHallazgos");
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
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            break;
                        case "CedulaHallazgosCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            break;
                        case "CedulaHallazgosSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            break;
                        case "CedulaHallazgosAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgos");
                            break;

                        #region Sumarias o resumenes

                        //Hallazgos
                        case "CedulaModeloHallazgosCrearview":
                            encabezado = "Creación de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloHallazgosEditarView":
                            encabezado = "Actualización de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloHallazgosConsultarView":
                            encabezado = "Consulta de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;


                        case "CedulaModeloHallazgosReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            //crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasHallazgos");
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgosResumen");

                            break;
                        case "CedulaModeloHallazgosCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgosResumen");
                            break;
                        case "CedulaModeloHallazgosSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgosResumen");
                            break;
                        case "CedulaModeloHallazgosAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new HallazgosControllerViewModel("DocumentacionCedulasHallazgosResumen");
                            break;
                        case "CedulaSumariaHallazgosVerView":
                            encabezado = "Vista de Hallazgos";
                            crearVentana = new HallazgosImpresionView();
                            crearVentana.DataContext = new HallazgosPresentacionViewModel("DocumentacionCedulasHallazgosResumen");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        #endregion Sumaria

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