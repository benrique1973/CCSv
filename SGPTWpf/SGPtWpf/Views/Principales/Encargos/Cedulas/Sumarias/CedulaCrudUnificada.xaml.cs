using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias
{
    /// <summary>
    /// Lógica de interacción para CedulaCrudUnificada.xaml
    /// </summary>
    public partial class CedulaCrudUnificada : MetroWindow
    {
        public CedulaCrudUnificada()
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

            #region Balance simple
            //datosConsulta.Width = ancho - 7;
            datosConsulta.MinWidth = ancho * 0.5;
            datosConsulta.MaxWidth = ancho - 7;

            //datosConsulta.Height = MaxHeight - 300;
            datosConsulta.MaxHeight = (MaxHeight - 300) * 0.40;
            datosConsulta.MinHeight = MaxHeight * 0.2;

            //dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MaxWidth - 1;
            dataGrid.MinWidth = datosConsulta.MinWidth - 1;

            //dataGrid.Height = datosConsulta.MaxHeight - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;
            #endregion

            #region Balance Conmparativo
            //datosConsultaComparativa.Width = ancho- 7;
            datosConsultaComparativa.MinWidth = ancho * 0.5;
            datosConsultaComparativa.MaxWidth = ancho - 7;

            //datosConsultaComparativa.Height = MaxHeight - 300;
            datosConsultaComparativa.MaxHeight = (MaxHeight - 300) * 0.40;
            datosConsultaComparativa.MinHeight = MaxHeight * 0.2;

            //dataGridComparativo.Width = datosConsulta.ancho - 1;
            dataGridComparativo.MaxWidth = datosConsulta.MaxWidth - 1;
            dataGridComparativo.MinWidth = datosConsulta.MinWidth - 1;

            //dataGridComparativo.Height = datosConsulta.MaxHeight - 1;
            dataGridComparativo.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGridComparativo.MinHeight = datosConsulta.MinHeight - 1;
            #endregion

            #region Analitica
            //datosConsulta.Width = ancho - 7;
            datosAnalitica.MinWidth = ancho * 0.5;
            datosAnalitica.MaxWidth = ancho - 7;

            //datosAnalitica.Height = MaxHeight - 300;
            datosAnalitica.MaxHeight = (MaxHeight - 300) * 0.40;
            datosAnalitica.MinHeight = MaxHeight * 0.2;

            //dataGrid.Width = datosConsulta.Width - 1;
            dataGridSumaria.MaxWidth = datosAnalitica.MaxWidth - 1;
            dataGridSumaria.MinWidth = datosAnalitica.MinWidth - 1;

            //dataGridSumaria.Height = datosAnalitica.MaxHeight - 1;
            dataGridSumaria.MaxHeight = datosAnalitica.MaxHeight - 1;
            dataGridSumaria.MinHeight = datosAnalitica.MinHeight - 1;
            #endregion analitica
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) SumariaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) SumariaControllerViewModel.Errors -= 1;
        }

    }
}