using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion
{
    /// <summary>
    /// Lógica de interacción para CatalogosView.xaml
    /// </summary>
    public partial class CatalogosView : UserControl
    {
        private string token = "MenuCatalogo";
        public CatalogosView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionSgpt>(this,token, (action) => ShowCatalogoControl(action));
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            MinWidth = PrincipalAlterna.MinanchoFrame - 7;
            Width = PrincipalAlterna.anchoFrame - 7;
            MaxWidth = PrincipalAlterna.MaxanchoFrame - 7;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = PrincipalAlterna.MinlargoFrame - 46;
            MaxHeight = PrincipalAlterna.MaxlargoFrame - 46;
            Height = PrincipalAlterna.largoFrame - 46;
            

            dataGridMenu.MinWidth = (Width - 3)*0.18;
            dataGridMenu.Height = Height - 3;

            EditFrame.Width = (Width - 3) * (1-0.18) ;
            EditFrame.Height = Height-3;

           /* gMenu.Width = Width * 0.20;
            gMenu.Height = Height;*/


            gtiDatos.Width = Width * 0.815;
            gtiDatos.MinWidth = Width * 0.815;
            gtiDatos.MaxHeight = Height;

            contenidoMenu.Width = Width * 0.175;
            contenidoMenu.MinWidth = Width * 0.175;
            contenidoMenu.MaxWidth = Width * 0.175;



        }
        private void ShowCatalogoControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            EditFrame.Content = nm.View;
        }
    }
}
