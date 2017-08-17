using SGPTWpf.ViewModel.Administracion.Clientes;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion.Clientes
{
    /// <summary>
    /// Lógica de interacción para CorrespondenciaView.xaml
    /// </summary>
    public partial class ClientesListadoView : UserControl
    {
        public ClientesListadoView()
        {
            InitializeComponent();
            this.DataContext = new ClientesListadoViewModel();

            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            Width = ancho * 0.806;
            MinWidth = ancho * 0.20;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = largo * 0.50;
            Height = largo * 0.781;


            dataGrid.Width = Width * 0.9995;
            dataGrid.MaxHeight = Height;


            IDcorre.Width = Width * 0.18;
            IDcorre.MinWidth = Width * 1.15;
            IDcorre.MaxWidth = Width * 0.25;

            Quecorre.Width = Width * 0.60;
            Quecorre.MinWidth = Width * 0.25;
            Quecorre.MaxWidth = Width * 0.75;

            //TipoCorre.Width = Width * 0.10;
            //TipoCorre.MinWidth = Width * 0.05;
            //TipoCorre.MaxWidth = Width * 0.10;

            //AsuCorre.Width = Width * 0.20;
            //AsuCorre.MinWidth = Width * 0.15;
            //AsuCorre.MaxWidth = Width * 0.25;

            ////ClieCorre
            //ClieCorre.Width = Width * 0.20;
            //ClieCorre.MinWidth = Width * 0.15;
            //ClieCorre.MaxWidth = Width * 0.25;

            //AsuCorre.Width = Width * 0.20;
            //AsuCorre.MinWidth = Width * 0.15;
            //AsuCorre.MaxWidth = Width * 0.22;

            //FecCorre.Width = Width * 0.12;
            //FecCorre.MinWidth = Width * 0.10;
            //FecCorre.MaxWidth = Width * 0.15;

            //RefCorre.Width = Width * 0.12;
            //RefCorre.MinWidth = Width * 0.10;
            //RefCorre.MaxWidth = Width * 0.15;

            ////RefEstado

            //RefEstado.Width = Width * 0.10;
            //RefEstado.MinWidth = Width * 0.07;
            //RefEstado.MaxWidth = Width * 0.12;
        }
    }
}
