using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion
{
    /// <summary>
    /// Lógica de interacción para RolesView.xaml
    /// </summary>
    public partial class RolesView : UserControl
    {
        public RolesView()
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

            correlativo.Width = Width * 0.10;
            correlativo.MinWidth = Width * 0.05;
            correlativo.MaxWidth = Width * 0.10;

            datos.Width = Width * 0.35;
            datos.MinWidth = Width * 0.10;
            datos.MaxWidth = Width * 0.50;

            datosRol.Width = Width * 0.35;
            datosRol.MinWidth = Width * 0.10;
            datosRol.MaxWidth = Width * 0.40;
        }
    }
}
