using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBRiesgo
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

        #region WFBRiesgo Constructor

        static WFBRiesgo()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBRiesgo),
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

                        case "MatrizRiesgoModeloCrearview":
                            encabezado = "Creación de Matriz de Riesgo";
                            crearVentana = new MatrizRiesgosCrudView();
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            crearVentana.MinHeight = largo*0.25;
                            crearVentana.MinWidth = ancho*0.25;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "MatrizRiesgoModeloEditarView":
                            encabezado = "Actualización de MatrizRiesgo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "MatrizRiesgoModeloConsultarView":
                            encabezado = "Consulta de MatrizRiesgo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "MatrizRiesgoModeloReferenciarView":
                            encabezado = "Referenciación de matriz de riesgo de auditoría";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            break;
                        case "MatrizRiesgoModeloCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            break;
                        case "MatrizRiesgoModeloSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            break;
                        case "MatrizRiesgoModeloAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new MatrizRiesgoControllerViewModel();
                            break;
                        case "MatrizRiesgoModeloVistaView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new RiesgoViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RiesgoPresentacionViewModel();
                            break;
                        //Casos del detalle
                        case "DetalleMatrizRiesgoModeloCrearview":
                            encabezado = "Creación de MatrizRiesgo";
                            crearVentana = new DetalleMatrizRiesgoCrudView();
                            crearVentana.DataContext = new DetalleMatrizRiesgoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleMatrizRiesgoModeloEditarView":
                            encabezado = "Actualización de MatrizRiesgo";
                            crearVentana = new DetalleMatrizRiesgoCrudView();
                            crearVentana.DataContext = new DetalleMatrizRiesgoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "DetalleMatrizRiesgoModeloConsultarView":
                            encabezado = "Consulta de MatrizRiesgo";
                            crearVentana = new DetalleMatrizRiesgoCrudView();
                            crearVentana.DataContext = new DetalleMatrizRiesgoControllerViewModel();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
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