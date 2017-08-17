using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion
{
    /// <summary>
    /// Lógica de interacción para FirmaView.xaml
    /// </summary>
    public partial class FirmaView : UserControl
    {
        public FirmaView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionFirma>(this, (action) => ShowFirmaControl(action));
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


            dataGridMenu.MinWidth = (Width - 3) * 0.18;
            dataGridMenu.Height = Height - 3;

            EditFrame.Width = (Width - 3) * (1 - 0.18);
            EditFrame.Height = Height - 3;

            /* gMenu.Width = Width * 0.20;
             gMenu.Height = Height;*/

            gtiDatos.Width = Width * 0.815;
            gtiDatos.MinWidth = Width * 0.815;
            gtiDatos.MaxHeight = Height;

            contenidoMenu.Width = Width * 0.175;
            contenidoMenu.MinWidth = Width * 0.175;
            contenidoMenu.MaxWidth = Width * 0.175;

            dataGridMenu.MinWidth = Width * 0.18;

        }
        private void ShowFirmaControl(NavegacionFirma nm)
        {
            if (nm.opcionMenu == 1)
            {
                nm.View.DataContext = nm.Contexto1;
            }

            if (nm.opcionMenu == 2 || nm.opcionMenu == 3 || nm.opcionMenu == 4)
            {
                nm.View.DataContext = nm.Contexto;
            }
            
            EditFrame.Content = nm.View;
        }
    }
}
