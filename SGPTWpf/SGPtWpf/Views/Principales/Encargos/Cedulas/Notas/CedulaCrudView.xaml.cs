using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Notas
{
    /// <summary>
    /// Lógica de interacción para CedulaCrudView.xaml
    /// </summary>
    public partial class CedulaCrudView : MetroWindow
    {
        public CedulaCrudView()
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

        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) SumariaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) SumariaControllerViewModel.Errors -= 1;
        }

    }
}