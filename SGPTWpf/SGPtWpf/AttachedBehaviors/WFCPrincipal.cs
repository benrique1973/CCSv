using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Sincronizacion;
using SGPTWpf.SGPtWpf.Views.Sincronizacion;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Encargos;
using SGPTWpf.Views;
using SGPTWpf.Views.Compartidas;
using SGPTWpf.Views.Principales.Encargos;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFCPrincipal
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

        #region WFCPrincipal Constructor

        static WFCPrincipal()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFCPrincipal),
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
                        case "SincronizarView":
                            encabezado = "Sincronización de datos";
                            crearVentana = new SincronizacionView();
                            crearVentana.DataContext = new SincronizacionViewModel();
                            crearVentana.MinWidth = 300;
                            crearVentana.MinHeight = 300;

                            break;
                        case "SeleccionEncargo":
                            encabezado = "Seleccione el encargo del  cliente para consulta o impresión";
                            crearVentana = new EncargoCrudView();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new EncargosControllerViewModel("PrincipalDocumentacion");
                            break;
                        default:
                            //Controller y vista solo para mientras

                            encabezado = "Error"; break;
                    }
                    crearVentana.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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