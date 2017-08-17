using MahApps.Metro.Controls;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice
{
    /// <summary>
    /// Lógica de interacción para IndiceReferenciacionView.xaml
    /// </summary>
    public partial class IndiceReferenciacionView : MetroWindow
    {
        public IndiceReferenciacionView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.ancho;
            double largo = PrincipalAlterna.largo;

            this.MaxWidth = ancho;
            this.MaxHeight = PrincipalAlterna.largo;

            MinWidth = MaxWidth * 0.30;
            MaxWidth = ancho;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = MaxHeight * 0.5;
            MaxHeight = MaxHeight;

            datosConsulta.Width = MaxWidth - 400;
            datosConsulta.MinWidth = MaxWidth * 0.5;
            datosConsulta.MaxWidth = MaxWidth - 7;

            datosConsulta.Height = Height - 150;
            datosConsulta.MaxHeight = MaxHeight - 150;
            datosConsulta.MinHeight = MaxHeight * 0.5;

            //dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MinWidth - 1;
            dataGrid.MinWidth = datosConsulta.MaxWidth - 1;

            //dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;
        }
    }
}
