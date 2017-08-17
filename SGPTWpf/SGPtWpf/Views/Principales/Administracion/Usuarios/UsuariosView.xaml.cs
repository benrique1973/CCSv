using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion
{
    /// <summary>
    /// Lógica de interacción para UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        public UsuariosView()
        {
            InitializeComponent();
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame);//Porque no hay barra lateral
            this.Height = PrincipalAlterna.largoFrame - 42;;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width;
            datosConsulta.Height = Height - 15;
            datosConsulta.MaxHeight = Height - 15;

            dataGrid.Width = Width;
            dataGrid.MaxHeight = Height - 60;
            dataGrid.Height = Height - 60;


            correlativo.Width = Width * 0.07;
            correlativo.MinWidth = Width * 0.05;
            correlativo.MaxWidth = Width * 0.10;

            nombr.Width = Width * 0.20;
            nombr.MinWidth = Width * 0.10;
            nombr.MaxWidth = Width * 0.40;

            apell.Width = Width * 0.20;
            apell.MinWidth = Width * 0.10;
            apell.MaxWidth = Width * 0.40;

            datosUsuario.Width = Width * 0.20;
            datosUsuario.MinWidth = Width * 0.10;
            datosUsuario.MaxWidth = Width * 0.40;

            datosRol.Width = Width * 0.20;
            datosRol.MinWidth = Width * 0.10;
            datosRol.MaxWidth = Width * 0.40;
        }
    }
}
