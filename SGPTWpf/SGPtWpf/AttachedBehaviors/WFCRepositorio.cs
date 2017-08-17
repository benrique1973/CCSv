using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFCRepositorio
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

        #region WFCRepositorio Constructor

        static WFCRepositorio()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFCRepositorio),
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

                        case "RepositorioModeloCrearview":
                            encabezado = "Creación de documento";
                            crearVentana = new RepositorioCrudView();
                            crearVentana.DataContext = new RepositorioModeloController("DocumentacionCartas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "RepositorioModeloEditarView":
                            encabezado = "Actualización de documento";
                            crearVentana = new RepositorioCrudView();
                            crearVentana.DataContext = new RepositorioModeloController("DocumentacionCartas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "RepositorioModeloImportarView":
                            encabezado = "Importar de encargos anteriores";
                            crearVentana = new ImportarRepositorioView();
                            crearVentana.DataContext = new RepositorioModeloController("DocumentacionCartas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "RepositorioModeloConsultarView":
                            encabezado = "Consulta de documento";
                            crearVentana = new RepositorioCrudView();
                            crearVentana.DataContext = new RepositorioModeloController("DocumentacionCartas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "RepositorioModeloReferenciarView":
                            encabezado = "Referenciación de documento de auditoría";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioControllerViewModel();
                            break;
                        case "RepositorioModeloCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioControllerViewModel();
                            break;
                        case "RepositorioModeloSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioControllerViewModel();
                            break;
                        case "RepositorioModeloAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioControllerViewModel();
                            break;
                        case "RepositorioModeloVistaView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new RiesgoViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RiesgoPresentacionViewModel();
                            break;
                        case "RepositorioVistaPDFPreviaView":
                            encabezado = "Documento escaneado";
                            crearVentana = new PDFView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioPDFControllerViewModel("DocumentacionCartas");
                            break;
                        case "RepositorioReferenciarView":
                            encabezado = "Referenciación de documento auditoría";
                            crearVentana = new ReferenciarRepositorioView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioModeloController("ReferenciarDocumentacionCartas");
                            break;
                        case "RepositorioCerrarView":
                            encabezado = "Cierre de documento auditoría";
                            crearVentana = new ReferenciarRepositorioView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioModeloController("ReferenciarDocumentacionCartas");
                            break;
                        case "RepositorioSupervisarView":
                            encabezado = "Supervisión de documento auditoría";
                            crearVentana = new ReferenciarRepositorioView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioModeloController("ReferenciarDocumentacionCartas");
                            break;
                        case "RepositorioAprobarView":
                            encabezado = "Aprobación de documento auditoría";
                            crearVentana = new ReferenciarRepositorioView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioModeloController("ReferenciarDocumentacionCartas");
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