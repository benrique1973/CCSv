using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Administracion.Herramientas
{
    /// <summary>
    /// Lógica de interacción para CuestionarioCrudView.xaml
    /// </summary>
    public partial class CuestionarioCrudView : UserControl
    {
        public CuestionarioCrudView()
        {
            InitializeComponent();
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame);//Porque no hay barra lateral
            this.Height = PrincipalAlterna.largoFrame - 42;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width - 8;
            datosConsulta.MinWidth = MinWidth;
            datosConsulta.MaxWidth = MaxWidth;

            datosConsulta.Height = Height - 60;
            datosConsulta.MinHeight = MinHeight - 3;
            datosConsulta.MaxHeight = MaxHeight - 3;

            dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MinWidth = datosConsulta.MinWidth - 1;
            dataGrid.MaxWidth = datosConsulta.MaxWidth - 1;

            dataGrid.MaxHeight = datosConsulta.Height - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;

            correlativo.Width = Width * 0.05;
            correlativo.MinWidth = Width * 0.01;
            correlativo.MaxWidth = Width * 0.10;

            nombre.Width = dataGrid.Width * 0.25;
            nombre.MinWidth = dataGrid.Width * 0.10;
            nombre.MaxWidth = dataGrid.Width * 0.20;

            creador.Width = dataGrid.Width * 0.25;
            creador.MinWidth = dataGrid.Width * 0.10;
            creador.MaxWidth = dataGrid.Width * 0.20;

            actualizacion.Width = dataGrid.Width * 0.25;
            actualizacion.MinWidth = dataGrid.Width * 0.10;
            actualizacion.MaxWidth = dataGrid.Width * 0.20;


        }
    }
}
