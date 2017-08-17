using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Marcas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Marcas;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBCedulaMarcas
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

        #region WFBCedulaMarcas Constructor

        static WFBCedulaMarcas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBCedulaMarcas),
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

                        case "CedulaMarcasCrearview":
                            encabezado = "Creación de Marcas";
                            crearVentana = new MarcasCrudView();
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaMarcasEditarView":
                            encabezado = "Actualización de Marcas";
                            crearVentana = new MarcasCrudView();
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaMarcasConsultarView":
                            encabezado = "Consulta de Marcas";
                            crearVentana = new MarcasCrudView();
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaMarcasImportarView":
                            encabezado = "Consulta de Marcas";
                            crearVentana = new MarcasCrudView();
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaMarcasVerView":
                            encabezado = "Vista de Marcas";
                            crearVentana = new MarcasImpresionView();
                            crearVentana.DataContext = new MarcasPresentacionViewModel("CedulaMarcas");
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
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            break;
                        case "CedulaMarcasCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            break;
                        case "CedulaMarcasSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
                            break;
                        case "CedulaMarcasAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MarcasControllerViewModel("DocumentacionCedulasMarcas");
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