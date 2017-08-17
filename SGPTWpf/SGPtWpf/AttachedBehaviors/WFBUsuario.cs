//http://stackoverflow.com/questions/20242817/resolving-windows-in-structure-map-or-how-to-manage-multiple-windows-in-wpf-mvvm
using MahApps.Metro.Controls;
using SGPTmvvm.Modales;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBUsuario
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

        #region WFBUsuario Constructor

        static WFBUsuario()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBUsuario),
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
                                case "UsuarioCrearView":
                                    encabezado = "Creación de usuario";
                                    break;
                                case "UsuarioEditarView":
                                    encabezado = "Edición de usuario";
                                    break;
                                case "UsuarioConsultarView":
                                    encabezado = "Consulta de usuario";
                                    break;
                                default:
                                    encabezado = "Error en la frase revisa bien";
                                    break;
                            }
                    crearVentana = new CRUDusuariosView();
                    crearVentana.DataContext = new CRUDusuariosViewModel();

                    //crearVentana.Width = 870;
                    //crearVentana.Height = 510;
                    //crearVentana.IsMinButtonEnabled = true;
                    //crearVentana.IsMaxRestoreButtonEnabled = false;
                    //crearVentana.ShowMinButton = true;
                    //crearVentana.ShowMaxRestoreButton = true;
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