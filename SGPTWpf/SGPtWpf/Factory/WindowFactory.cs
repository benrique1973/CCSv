//http://stackoverflow.com/questions/20242817/resolving-windows-in-structure-map-or-how-to-manage-multiple-windows-in-wpf-mvvm
using System;
using System.Windows;
using MahApps.Metro.Controls;

namespace SGPTWpf.Factory
{
    public class WindowFactory : IWindowFactory
    {
        #region WindowFactory Singleton Instance

        private static WindowFactory _instance = null;
        private static readonly object padlock = new object();

        public static WindowFactory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new WindowFactory();
                    }

                    return _instance;
                }
            }
        }

        #endregion

        public Window Make(string TypeWindow)
        {
            if (TypeWindow.Equals("WPClaseCuentaCrearViewProxy"))
            {
                var windowCrear = new MetroWindow();

                windowCrear.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                windowCrear.Title = "Sistema de gestión de papeles de trabajo";

                windowCrear.Width = 550;
                windowCrear.Height = 282;
                windowCrear.Title = TypeWindow;
                windowCrear.ContentTemplate = Application.Current.Resources[TypeWindow] as DataTemplate;

                return windowCrear;
            }
            else
                throw new Exception("La fabrica no pudo crear la ventana {0}" + TypeWindow);
        }
    }
}