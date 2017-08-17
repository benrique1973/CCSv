using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Views.Compartidas;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.Views.Administracion.Herramientas
{
    /// <summary>
    /// Lógica de interacción para IndiceCrudView.xaml
    /// </summary>
    public partial class IndiceCrudView : UserControl
    {
        public string token = "MenuHerramientasPlantillasIndices";
        public IndiceCrudView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionSgpt>(this,token, (action) => ShowContenidoControl(action));
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.MinWidth = PrincipalAlterna.MinanchoFrame*0.5;
            this.Width = PrincipalAlterna.anchoFrame - 4;
            this.MaxWidth = PrincipalAlterna.MaxanchoFrame - 4;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinHeight = PrincipalAlterna.MinlargoFrame*0.5;
            this.MaxHeight = PrincipalAlterna.MaxlargoFrame - 42;
            this.Height = PrincipalAlterna.largoFrame - 42;


            gridMenuLateral.MinWidth = Width * 0.08;
            gridMenuLateral.Width = 200;
            gridMenuLateral.MaxWidth = 200;

            gridMenuLateral.MinHeight = Height - 62;
            gridMenuLateral.Height = Height - 62;
            gridMenuLateral.MinHeight = Height - 62;

            dataGridMenuIndice.MinHeight = Height - 65;
            dataGridMenuIndice.Height = Height - 65;
            dataGridMenuIndice.MinHeight = Height - 65;

            gtiDatos.Width = Width - 200;
            gtiDatos.MinWidth = Width * 0.5;

            gtiDatos.Height = Height - 63;
            gtiDatos.MaxHeight = Height - 63;


            gridMenu.MinHeight = 55;
            gridMenu.Height = Height * 0.09;
            gridMenu.Width = Width;
            gridMenu.MinWidth = Width * 0.25;


            /////////////////////////////////////////////////////////
            EditFrame.Width = Width - 200;
            EditFrame.Height = Height - 62;

            indicesMenu.Width = gridMenuLateral.Width-2;
            indicesMenu.MinWidth = gridMenuLateral.Width-2;
            indicesMenu.MaxWidth = gridMenuLateral.Width-2;

        }
        private void ShowContenidoControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            EditFrame.Content = nm.View;
        }
        /*https://www.dotnetperls.com/radiobutton-wpf*/
    }
}
