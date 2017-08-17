using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Notas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Notas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBNotas
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

        #region WFBNotas Constructor

        static WFBNotas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBNotas),
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

                        case "CedulaNotasCrearview":
                            encabezado = "Creación de notas";
                            crearVentana = new NotasCrudView();
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasEditarView":
                            encabezado = "Actualización de notas";
                            crearVentana = new NotasCrudView();
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasConsultarView":
                            encabezado = "Consulta de notas";
                            crearVentana = new NotasCrudView();
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasImportarView":
                            encabezado = "Consulta de notas";
                            crearVentana = new NotasCrudView();
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasVerView":
                            encabezado = "Vista de notas";
                            crearVentana = new NotasImpresionView();
                            crearVentana.DataContext = new NotasPresentacionViewModel("CedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.WindowStartupLocation = WindowStartupLocation.Manual;
                            break;
                        case "CedulaModeloReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;
                        case "CedulaNotasAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulaNotas");
                            crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            break;

                        #region Sumarias o resumenes

                        //Notas
                        case "CedulaModeloNotasCrearview":
                            encabezado = "Creación de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloNotasEditarView":
                            encabezado = "Actualización de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloNotasConsultarView":
                            encabezado = "Consulta de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;


                        case "CedulaModeloNotasReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            //crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasNotas");
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulasNotasResumen");

                            break;
                        case "CedulaModeloNotasCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulasNotasResumen");
                            break;
                        case "CedulaModeloNotasSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulasNotasResumen");
                            break;
                        case "CedulaModeloNotasAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new NotasControllerViewModel("DocumentacionCedulasNotasResumen");
                            break;
                        case "CedulaSumariaNotasVerView":
                            encabezado = "Vista de Notas";
                            crearVentana = new NotasImpresionView();
                            crearVentana.DataContext = new NotasPresentacionViewModel("DocumentacionCedulasNotasResumen");
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