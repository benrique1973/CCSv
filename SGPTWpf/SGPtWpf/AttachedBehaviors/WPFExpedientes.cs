using MahApps.Metro.Controls;
using System;
using System.Windows;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Expediente;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.PreElaboradas.Expediente;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WPFExpedientes
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

        #region WPFExpedientes Constructor

        static WPFExpedientes()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WPFExpedientes),
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

                        case "ExpedienteVerView":
                            encabezado = "Vista de expediente";
                            crearVentana = new ExpedienteImpresionView();
                            crearVentana.DataContext = new ExpedientePresentacionViewModel("cedulaExpediente");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
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