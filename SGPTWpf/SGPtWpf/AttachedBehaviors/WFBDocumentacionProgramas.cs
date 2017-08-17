using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBDocumentacionProgramas
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

        #region WFBDocumentacionProgramas Constructor

        static WFBDocumentacionProgramas()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBDocumentacionProgramas),
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
                    //Temporal
                    double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

                    double largo = System.Windows.SystemParameters.PrimaryScreenHeight * 0.95;
                    var crearVentana = new MetroWindow();
                    string encabezado = "";
                    crearVentana.WindowStartupLocation = WindowStartupLocation.Manual;
                    switch (e.NewValue.ToString())
                    {
                        /* case "ProgramaModeloCrearView":
                             encabezado = "Creación de programa de auditoría";
                             crearVentana = new ProgramaCrearView();
                             crearVentana.MinHeight = 200;
                             crearVentana.MinWidth = 300;
                             crearVentana.Width = 640;
                             crearVentana.Height = 360;
                             crearVentana.DataContext = new ProgramaControllerViewModel();
                             break;
                         case "ProgramaCopiarView":
                             encabezado = "Copia de programa de auditoría";
                             crearVentana = new ProgramaCrearView();
                             crearVentana.MinHeight = 200;
                             crearVentana.MinWidth = 300;
                             crearVentana.Width = 640;
                             crearVentana.Height = 400;
                             crearVentana.DataContext = new ProgramaControllerViewModel();
                             break;
                         case "ProgramaModeloEditarView":
                             //Temporal
                             encabezado = "Edición de programa de auditoría";
                             crearVentana = new ProgramaCrudView();
                             crearVentana.MinHeight = largo * 0.30;
                             crearVentana.MinWidth = ancho * 0.20;
                             //crearVentana.Width = ancho;
                             //crearVentana.Height = largo;
                             crearVentana.MaxWidth = ancho;
                             crearVentana.MaxHeight = largo;
                             crearVentana.DataContext = new ProgramaControllerViewModel();
                             break;
                         case "ProgramaModeloImportarPlantillaView":
                             //Temporal
                             encabezado = "Importacion de programas de auditoría de plantillas";
                             crearVentana = new ImportacionSeleccionProgramaView();
                             crearVentana.MinHeight = largo * 0.30;
                             crearVentana.MinWidth = ancho * 0.20;
                             crearVentana.MaxWidth = ancho;
                             crearVentana.MaxHeight = largo;
                             crearVentana.DataContext = new ProgramaControllerViewModel(6);
                             break;
                         case "ProgramaModeloImportarEncargoView":
                             //Temporal
                             encabezado = "Importacion de programas de auditoría de encargos anteriores";
                             crearVentana = new ImportacionSeleccionProgramaView();
                             crearVentana.MinHeight = largo * 0.30;
                             crearVentana.MinWidth = ancho * 0.20;
                             crearVentana.MaxWidth = ancho;
                             crearVentana.MaxHeight = largo;
                             crearVentana.DataContext = new ProgramaControllerViewModel(7);
                             break;
                         case "ProgramaModeloConsultarView":
                             //Temporal
                             encabezado = "Consulta de programa de auditoría";
                             crearVentana = new ProgramaCrudView();
                             crearVentana.MinHeight = largo * 0.30;
                             crearVentana.MinWidth = ancho * 0.20;
                             crearVentana.Width = ancho;
                             crearVentana.Height = largo;
                             crearVentana.DataContext = new ProgramaControllerViewModel();
                             break;*/
                        case "ProgramaModeloVerProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Height = largo;
                            crearVentana.DataContext = new ProgramaPresentacionViewModel();
                            break;
                        //Documentacion
                        case "ProgramaEjecucionVerProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Height = largo;

                            crearVentana.DataContext = new ProgramaPresentacionViewModel("Ejecucion");
                            break;
                        case "ProgramaModeloReferenciarView":
                            encabezado = "Referenciación del programa de auditoría";
                            crearVentana = new ReferenciarProgramasView();
                            crearVentana.MinHeight = 230;
                            crearVentana.MinWidth = 540;
                            crearVentana.MaxWidth = 920;
                            crearVentana.MaxHeight = 760;
                            crearVentana.DataContext = new ProgramaControllerViewModel("Ejecucion");
                            break;
                        case "DetalleProgramaModeloCompletarView":
                            encabezado = "Completar datos de procedimientos de auditoria";
                            crearVentana = new DetalleProgramaEdicionView();
                            crearVentana.MinHeight = 230;
                            crearVentana.MinWidth = 540;
                            crearVentana.MaxWidth = 920;
                            crearVentana.MaxHeight = 760;
                            crearVentana.DataContext = new DetalleProgramaControllerViewModel("Ejecucion");
                            break;
                        case "ProgramaModeloBitacoraView":
                            encabezado = "Historial del programa de auditoría";
                            crearVentana = new ProgramaBitacoraView();
                            crearVentana.MinHeight = 230;
                            crearVentana.MinWidth = 540;
                            crearVentana.MaxWidth = 920;
                            crearVentana.MaxHeight = 760;
                            crearVentana.DataContext = new ProgramaControllerViewModel("Ejecucion");
                            break;
                        case "DetalleIndiceModeloReferenciarview":
                            encabezado = "Referenciar contenido programa de auditoría";
                            crearVentana = new IndiceReferenciacionView();
                            crearVentana.DataContext = new DetalleIndiceControllerViewModel("ProgramasReferenciacion");
                            crearVentana.MinWidth = 250;
                            crearVentana.MinHeight = 150;
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error";
                            break;
                    }
                    //Configuración de pantalla

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