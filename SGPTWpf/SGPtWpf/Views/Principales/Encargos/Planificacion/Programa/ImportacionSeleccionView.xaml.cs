using MahApps.Metro.Controls;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion
{
    /// <summary>
    /// Lógica de interacción para ImportacionSeleccionView.xaml
    /// </summary>
    public partial class ImportacionSeleccionView : MetroWindow
    {
        public ImportacionSeleccionView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = ancho - 205;
            this.Height = PrincipalAlterna.largoFrame - 42;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            //datosConsulta.Width = Width - 7;
            datosConsulta.MinWidth = Width * 0.5;
            datosConsulta.MaxWidth = Width - 7;

            //datosConsulta.Height = Height - 62;
            datosConsulta.MaxHeight = Height - 62;
            datosConsulta.MinHeight = Height * 0.5;

            //dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MinWidth - 1;
            dataGrid.MinWidth = datosConsulta.MaxWidth - 1;

            //dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;


            //datosConsultaEncargo.Width = Width - 7;
            datosConsultaEncargo.MinWidth = Width * 0.5;
            datosConsultaEncargo.MaxWidth = Width - 7;

            //datosConsultaEncargo.Height = Height - 62;
            datosConsultaEncargo.MaxHeight = Height - 62;
            datosConsultaEncargo.MinHeight = Height * 0.5;

            //dataGridEncargos.Width = datosConsultaEncargo.Width - 1;
            dataGridEncargos.MaxWidth = datosConsultaEncargo.MinWidth - 1;
            dataGridEncargos.MinWidth = datosConsultaEncargo.MaxWidth - 1;

            //dataGridEncargos.Height = datosConsultaEncargo.Height - 1;
            dataGridEncargos.MaxHeight = datosConsultaEncargo.MaxHeight - 1;
            dataGridEncargos.MinHeight = datosConsultaEncargo.MinHeight - 1;

        }
    }
}
