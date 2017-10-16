//http://stackoverflow.com/questions/20242817/resolving-windows-in-structure-map-or-how-to-manage-multiple-windows-in-wpf-mvvm
using MahApps.Metro.Controls;
using SGPTmvvm.Modales;
using SGPTWpf.SGPtmvvm.Reportes;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBReportes 
    {
        /// <summary>
        /// Clase que sirve para disparar la vista que crea los reportes de diferentes tipos, como matriz de riesgo, cuestionarios, programas, entre otros.
        /// </summary>
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

        #region WFBReportes Constructor

        static WFBReportes()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBReportes),
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
                    switch (e.NewValue.ToString())
                    {
                        case "ReporteMatrizRiesgo":
                            encabezado = "Reporte de Matriz de Riesgos";
                            break;
                        case "ReporteCuestionario":
                            encabezado = "Reporte de Cuestionario";
                            ////crearVentana.Owner = CuestionarioViewImpresion();
                            //var a=Application.Current.MainWindow.OwnedWindows;
                            //for (int i = 0;i< a.Count;i++)
                            //{
                            //    if (a[i].Title == "Vista preliminar del cuestionario de auditoría")
                            //    {
                            //        crearVentana.Owner = a[i];
                            //    }
                            //}
                            break;
                        case "ReportePrograma":
                            encabezado = "Reporte de Programa";
                            break;
                        case "ReportePortadaCarpeta":
                            encabezado = "Reporte de Portada de Carpeta";
                            break;
                        case "ReporteIndiceCarpeta":
                            encabezado = "Reporte de Indice de Carpeta";
                            break;
                        case "ReporteCedulaMarcas":
                            encabezado = "Reporte de Cedula de Marcas";
                            break;
                        case "ReporteCedulaHallazgos":
                            encabezado = "Reporte de Cedula de Hallazgos";
                            break;
                        case "ReporteCedulaNotas":
                            encabezado = "Reporte de Cedula de Notas";
                            break;
                        case "ReporteCedulaSumarias":
                            encabezado = "Reporte de Cedula de Sumarias";
                            break;
                        case "ReporteCedulaSumariaDetalle":
                            encabezado = "Reporte de Cedula Sumaria Detalle";
                            break;
                        case "ReporteCedulaAjustesReclasificaciones":
                            encabezado = "Reporte de Cedula de Ajustes y Reclasificaciones";
                            break;
                        default:
                            encabezado = "Reporte no se de que...";
                            break;
                    }
                    crearVentana = new ReportesView();
                    crearVentana.DataContext = new ReportesViewModel();

                    crearVentana.Width = 870;
                    crearVentana.Height = 550;
                    crearVentana.IsMinButtonEnabled = true;
                    crearVentana.IsMaxRestoreButtonEnabled = false;
                    crearVentana.ShowMinButton = true;
                    crearVentana.ShowMaxRestoreButton = true;
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