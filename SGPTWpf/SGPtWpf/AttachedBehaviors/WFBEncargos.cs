using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Programas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion;
using SGPTWpf.ViewModel.Encargos;
using SGPTWpf.ViewModel.Encargos.Edicion;
using SGPTWpf.ViewModel.Encargos.Gestion;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.Views.Principales.Encargos;
using SGPTWpf.Views.Principales.Encargos.Gestion;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBEncargos
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

        #region WFBEncargos Constructor

        static WFBEncargos()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBEncargos),
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
                    double ancho = PrincipalAlterna.ancho;
                    double largo = PrincipalAlterna.largo;
                    var crearVentana = new MetroWindow();
                    string encabezado = "";
                    switch (e.NewValue.ToString())
                    {
                        case "Planificación":
                            encabezado = "Seleccione el cliente para planificacion";
                            crearVentana = new EncargoCrudView();
                            crearVentana.DataContext = new EncargosControllerViewModel("Planificación");
                            //crearVentana.Width = ancho*0.80;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;
                            break;
                        case "Documentacion":
                            encabezado = "Seleccione el cliente para documentación";
                            crearVentana = new EncargoCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new EncargosControllerViewModel("Documentacion");
                            break;
                        case "Cédulas":
                            encabezado = "Seleccione el cliente para cédulas";
                            crearVentana = new EncargoCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new EncargosControllerViewModel("Cédulas");
                            break;
                        case "Supervision":
                            encabezado = "Seleccione el cliente para supervisión";
                            crearVentana = new EncargoCrudView();
                            crearVentana.DataContext = new EncargosControllerViewModel("Supervision");
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;
                            break;
                        case "Cierre":
                            encabezado = "Seleccione el cliente para cierre";
                            crearVentana = new EncargoCrudView();
                            crearVentana.DataContext = new EncargosControllerViewModel("Cierre");
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;

                            break;

                        case "EncargosCrearView"://Para edicion  encargo
                            encabezado = "Creación de encargo de auditoría";
                            crearVentana = new EncargosEdicionView();
                            crearVentana.DataContext = new EdicionEncargoCrudControllerViewModel();
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;
                            break;
                        case "EncargosEditarView"://Para edicion  encargo
                            encabezado = "Edicion de encargo de auditoría";
                            crearVentana = new EncargosEdicionView();
                            crearVentana.DataContext = new EdicionEncargoCrudControllerViewModel();
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;
                            break;
                        case "EncargosConsultarView"://Para edicion  encargo
                            encabezado = "Consulta de encargo de auditoría";
                            crearVentana = new EncargosEdicionView();
                            crearVentana.DataContext = new EdicionEncargoCrudControllerViewModel();
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;
                            break;
                        case "ProgramaModeloVerProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.Height = largo*0.85;
                            crearVentana.MaxHeight = largo;
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.DataContext = new ProgramaPresentacionViewModel();
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