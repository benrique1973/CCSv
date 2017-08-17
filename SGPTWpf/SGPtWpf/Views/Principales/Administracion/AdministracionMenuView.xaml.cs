using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Administracion
{

    public partial class AdministracionMenuView : UserControl
    {
        private string token = "MenuAdministracion";
        public AdministracionMenuView()
        {
            InitializeComponent();
            Messenger.Default.Register<NavegacionSgpt>(this, token,(action) => ShowMenuControl(action));
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;



            MinWidth = PrincipalAlterna.MinanchoFrame-3;
            Width = PrincipalAlterna.anchoFrame-3;
            MaxWidth = PrincipalAlterna.MaxanchoFrame-3;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = PrincipalAlterna.MinlargoFrame-3;
            MaxHeight = PrincipalAlterna.MaxlargoFrame-3;
            Height = PrincipalAlterna.largoFrame-3;


            AdministracionFrame.Width = ancho-3;
            AdministracionFrame.Height = largo-3;

    }
        private void ShowMenuControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            AdministracionFrame.Content = nm.View;
        }
    }
}
