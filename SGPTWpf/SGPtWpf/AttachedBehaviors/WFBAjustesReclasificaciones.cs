using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Ajustes;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Ajustes;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBAjustesReclasificaciones
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

        #region WFBAjustesReclasificaciones Constructor

        static WFBAjustesReclasificaciones()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBAjustesReclasificaciones),
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

                        case "CedulaAjustesReclasificacionesCrearview":
                            encabezado = "Creación de ajustes y reclasificaciones";
                            crearVentana = new AjustesCrudView();
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAjustesReclasificacionesEditarView":
                            encabezado = "Actualización de ajustes y reclasificaciones";
                            crearVentana = new AjustesCrudView();
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAjustesReclasificacionesConsultarView":
                            encabezado = "Consulta de ajustes y reclasificaciones";
                            crearVentana = new AjustesCrudView();
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAjustesReclasificacionesImportarView":
                            encabezado = "Consulta de ajustes y reclasificaciones";
                            crearVentana = new AjustesCrudView();
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAjustesReclasificacionesVerView":
                            encabezado = "Vista de ajustes y reclasificaciones";
                            crearVentana = new AjustesPresentacionView();
                            crearVentana.DataContext = new AjustesReclasificacionesPresentacionViewModel("CedulaAjustesReclasificaciones");
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
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            break;
                        case "CedulaAjustesReclasificacionesCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            break;
                        case "CedulaAjustesReclasificacionesSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            break;
                        case "CedulaAjustesReclasificacionesAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulaAjustesReclasificaciones");
                            break;

                        #region Sumarias o resumenes

                        //Ajustes
                        case "CedulaModeloAjustesCrearview":
                            encabezado = "Creación de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasAjustes");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloAjustesEditarView":
                            encabezado = "Actualización de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasAjustes");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaModeloAjustesConsultarView":
                            encabezado = "Consulta de cédula";
                            crearVentana = new CedulaCrudView();
                            crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasAjustes");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;


                        case "CedulaModeloAjustesReferenciarView":
                            encabezado = "Referenciación de cédula de auditoría";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            //crearVentana.DataContext = new SumariaControllerViewModel("DocumentacionCedulasAjustes");
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulasAjustesResumen");

                            break;
                        case "CedulaModeloAjustesCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulasAjustesResumen");
                            break;
                        case "CedulaModeloAjustesSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulasAjustesResumen");
                            break;
                        case "CedulaModeloAjustesAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new AjustesReclasificacionesControllerViewModel("DocumentacionCedulasAjustesResumen");
                            break;
                        case "CedulaSumariaAjustesVerView":
                            encabezado = "Vista de ajustes y reclasificaciones";
                            crearVentana = new AjustesPresentacionView();
                            crearVentana.DataContext = new AjustesReclasificacionesPresentacionViewModel("DocumentacionCedulasAjustesResumen");
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