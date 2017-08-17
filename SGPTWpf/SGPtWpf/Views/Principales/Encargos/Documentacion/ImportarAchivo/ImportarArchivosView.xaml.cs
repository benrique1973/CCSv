using MahApps.Metro.Controls;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.ImportarAchivo
{
    /// <summary>
    /// Lógica de interacción para ImportarArchivosView.xaml
    /// </summary>
    public partial class ImportarArchivosView : MetroWindow
    {
        public ImportarArchivosView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.ancho;
            double largo = PrincipalAlterna.largo;

            this.MaxWidth = ancho ;
            this.MaxHeight = largo;

            MinWidth = MaxWidth * 0.6;
            MaxWidth = MaxWidth;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = MaxHeight * 0.5;
            MaxHeight = MaxHeight;

            #region Datos capturados

            //datosConsulta.Width = Width - 7;
            datosConsulta.MinWidth = MaxWidth * 0.5;
            datosConsulta.MaxWidth = MaxWidth - 7;

            //datosConsulta.Height = Height - 350;
            datosConsulta.MaxHeight = MaxHeight - 350;
            datosConsulta.MinHeight = MaxHeight * 0.5;

            //dtGrid.Width = datosConsulta.Width - 1;
            dtGrid.MaxWidth = datosConsulta.MinWidth - 1;
            dtGrid.MinWidth = datosConsulta.MaxWidth - 1;

            //dtGrid.Height = datosConsulta.Height - 1;
            dtGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dtGrid.MinHeight = datosConsulta.MinHeight - 1;

            #endregion Datos capturados

            #region Datos transformados

            datosConsultaTransformados.Width = MaxWidth - 7;
            datosConsultaTransformados.MinWidth = MaxWidth * 0.5;
            datosConsultaTransformados.MaxWidth = MaxWidth - 7;

            datosConsultaTransformados.Height = MaxHeight - 350;
            datosConsultaTransformados.MaxHeight = MaxHeight - 350;
            datosConsultaTransformados.MinHeight = MaxHeight * 0.5;

            dataGrid.Width = datosConsultaTransformados.Width - 1;
            dataGrid.MaxWidth = datosConsultaTransformados.MaxWidth - 1;
            dataGrid.MinWidth = datosConsultaTransformados.MinWidth - 20;

            //dataGrid.Height = datosConsultaTransformados.Height - 1;
            dataGrid.MaxHeight = datosConsultaTransformados.MaxHeight - 1;
            dataGrid.MinHeight = datosConsultaTransformados.MinHeight - 1;

            datosTransformadosBalance.Width = Width - 7;
            datosTransformadosBalance.MinWidth = MaxWidth * 0.5;
            datosTransformadosBalance.MaxWidth = MaxWidth - 20;

            //datosTransformadosBalance.Height = Height - 350;
            datosTransformadosBalance.MaxHeight = MaxHeight - 350;
            datosTransformadosBalance.MinHeight =MaxHeight * 0.5;

            #endregion
        }
    }
}
