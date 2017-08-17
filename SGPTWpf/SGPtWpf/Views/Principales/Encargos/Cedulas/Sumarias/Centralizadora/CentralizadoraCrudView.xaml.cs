using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Centralizadora;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Centralizadora
{
    /// <summary>
    /// Lógica de interacción para CentralizadoraCrudView.xaml
    /// </summary>
    public partial class CentralizadoraCrudView : MetroWindow
    {
        public CentralizadoraCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.MaxWidth = ancho;
            this.MaxHeight = PrincipalAlterna.largoFrame;

            MinWidth = ancho * 0.6;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = MaxHeight * 0.5;
            MaxHeight = MaxHeight;

            //datosConsulta.Width = ancho - 7;
            datosConsulta.MinWidth = ancho * 0.5;
            datosConsulta.MaxWidth = ancho - 7;

            //datosConsulta.Height = MaxHeight - 300;
            datosConsulta.MaxHeight = MaxHeight - 300;
            datosConsulta.MinHeight = MaxHeight * 0.2;

            //dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MaxWidth - 1;
            dataGrid.MinWidth = datosConsulta.MinWidth - 1;

            //dataGrid.Height = datosConsulta.MaxHeight - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;

            //datosConsultaComparativa.Width = ancho- 7;
            datosConsultaComparativa.MinWidth = ancho * 0.5;
            datosConsultaComparativa.MaxWidth = ancho - 7;

            //datosConsultaComparativa.Height = MaxHeight - 300;
            datosConsultaComparativa.MaxHeight = MaxHeight - 300;
            datosConsultaComparativa.MinHeight = MaxHeight * 0.2;

            //dataGridComparativo.Width = datosConsulta.ancho - 1;
            dataGridComparativo.MaxWidth = datosConsulta.MaxWidth - 1;
            dataGridComparativo.MinWidth = datosConsulta.MinWidth - 1;

            //dataGridComparativo.Height = datosConsulta.MaxHeight - 1;
            dataGridComparativo.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGridComparativo.MinHeight = datosConsulta.MinHeight - 1;


        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) CentralizadoraControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) CentralizadoraControllerViewModel.Errors -= 1;
        }

    }
}