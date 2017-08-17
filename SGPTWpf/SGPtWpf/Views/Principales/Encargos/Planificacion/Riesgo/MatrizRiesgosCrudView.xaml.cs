using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo
{
    /// <summary>
    /// Lógica de interacción para MatrizRiesgosCrudView.xaml
    /// </summary>
    public partial class MatrizRiesgosCrudView : MetroWindow
    {
        public MatrizRiesgosCrudView()
        {
            InitializeComponent();
            //var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            double ancho = PrincipalAlterna.ancho;
            double largo = PrincipalAlterna.largo;

            this.MaxWidth = ancho ;
            this.MaxHeight =largo;

            MinWidth = MaxWidth * 0.25;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = MaxHeight * 0.25;


            //datosConsulta.Width = Width - 7;
            datosConsulta.MinWidth = MaxWidth * 0.25;
            datosConsulta.MaxWidth = MaxWidth - 7;

            //datosConsulta.Height = Height - 62;
            datosConsulta.MaxHeight = MaxHeight - 100;
            datosConsulta.MinHeight = MaxHeight * 0.25;

            //dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MaxWidth = datosConsulta.MaxWidth - 1;
            dataGrid.MinWidth = datosConsulta.MinWidth - 1;

            //dataGrid.Height = datosConsulta.Height - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) MatrizRiesgoControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) MatrizRiesgoControllerViewModel.Errors -= 1;
        }

    }

}
