using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro;
using MahApps.Metro.Controls;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.ViewModel;
using System;
using System.Windows;

namespace SGPTWpf.Views.Compartidas
{
    /// <summary>
    /// Description for PrincipalAlterna.
    /// </summary>
    public partial class PrincipalAlterna : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the PrincipalAlterna class.
        /// </summary>
        public static double largoFrame=0;
        public static double anchoFrame = 0;
        public static double MaxlargoFrame = 0;
        public static double MaxanchoFrame = 0;
        private string token = "MenuPrincipal";
        public static double ancho = 0;
        public static double largo = 0;
        public static double anchoPagina = 0;
        public static double largoPaginaBond = 0;
        public static double largoPaginaOficio = 0;


        public static double MinlargoFrame = 0;
        public static double MinanchoFrame = 0;
        public PrincipalAlterna()
        {
            InitializeComponent();

            anchoFrame = 0;

            //this.DataContext = new PrincipalAlternaViewModel(DialogCoordinator.Instance);
            Messenger.Default.Register<NavegacionSgpt>(this,token, (action) => ShowMenuControl(action));
            Messenger.Default.Register<String>(this, "ponelecolor", CtrlX); //mensaje vacio sirve para controlar el color del tema configurado por el usuario
                                                                            //Messenger.Default.Send<String>("2", "ponelecolor");
                                                                            //Tamaño de pantalla
            
            ///http://www.elguille.info/NET/dotnet/adaptar_formulario_tamano_y_posicion_escritorio.aspx


            #region Configuracion de pantalla

            ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            largo = System.Windows.SystemParameters.PrimaryScreenHeight;         

            this.Width = ancho;
            this.MinWidth = ancho * 0.60;
            this.MaxWidth = ancho;
            //https://stackoverflow.com/questions/9768301/how-to-set-a4-size-in-a-wpf-usercontrol
            anchoPagina = (8.5 * 96); //Tamaño carta
            largoPaginaBond = (11 * 96);//Tamaño carta
            largoPaginaOficio = (11.7 * 96);

            this.Height = largo - 40;
            this.MinHeight = largo * 0.40;
            this.MaxHeight = largo - 40;

            PrincipalFrame.MinWidth = Width * 0.20;
            PrincipalFrame.Width = Width-4;
            PrincipalFrame.MaxWidth = Width-4;
            anchoFrame = Width;

            PrincipalFrame.MinHeight = Height * 0.20;
            PrincipalFrame.Height = Height - 75;//40 Es tamaño de los titulos
            PrincipalFrame.MaxHeight = Height - 75;//40 Es tamaño de los titulos

            //Valores a propagar
            anchoFrame = PrincipalFrame.Width;

            MaxlargoFrame = PrincipalFrame.Height;
            largoFrame = PrincipalFrame.Height;
            MaxanchoFrame = anchoFrame;

            MinlargoFrame = PrincipalFrame.MinHeight;
            MinanchoFrame = PrincipalFrame.MinWidth;

            ///http://stackoverflow.com/questions/12590336/how-to-set-wpf-application-windowstartuplocation-to-top-right-corner-using-xaml
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;

            #endregion fin de configuracion de pantalla
            
            //Estableciendolo como la pantalla principal

            App.Current.MainWindow = this;
        }
        public PrincipalAlternaViewModel ViewModel
        {
            get { return this.DataContext as PrincipalAlternaViewModel; }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.ViewModel.Dispose();
         }

        private void ShowMenuControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            PrincipalFrame.Content = nm.View;
        }
        private void CtrlX(string msj)
        {
            if (msj == "1")
                this.MenuItem_Click_1();
            if (msj == "2")
                this.MenuItem_Click_2();
            if (msj == "3")
                this.MenuItem_Click_3();
            if (msj == "4")
                this.MenuItem_Click_4();
            if (msj == "5")
                this.MenuItem_Click_5();
            if (msj == "6")
                this.MenuItem_Click_6();
            if (msj == "7")
                this.MenuItem_Click_7();
            if (msj == "8")
                this.MenuItem_Click_8();
            if (msj == "9")
                this.MenuItem_Click_9();
            if (msj == "10")
                this.MenuItem_Click_10();
        }


        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        private void MenuItem_Click_1()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            // now set the Green accent and dark theme
            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Green"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1
        }

        //private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        private void MenuItem_Click_2()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Green"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
        }

        //private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        private void MenuItem_Click_3()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Red"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1
        }

        //private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        private void MenuItem_Click_4()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Red"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
        }

        //private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        private void MenuItem_Click_6()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Blue"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
        }
        //private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        private void MenuItem_Click_5()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Blue"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1
        }
        //private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        private void MenuItem_Click_8()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Purple"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
        }
        //private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        private void MenuItem_Click_7()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Purple"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1
        }
        //private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        private void MenuItem_Click_10()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Orange"),
                                        ThemeManager.GetAppTheme("BaseLight")); // or appStyle.Item1
        }
        //private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        private void MenuItem_Click_9()
        {
            Tuple<AppTheme, Accent> appStyle = ThemeManager.DetectAppStyle(Application.Current);

            ThemeManager.ChangeAppStyle(Application.Current,
                                        ThemeManager.GetAccent("Orange"),
                                        ThemeManager.GetAppTheme("BaseDark")); // or appStyle.Item1
        }

    }
}