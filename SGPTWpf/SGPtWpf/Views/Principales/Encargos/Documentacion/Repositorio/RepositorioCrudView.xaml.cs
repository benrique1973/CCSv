using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio
{
    /// <summary>
    /// Lógica de interacción para RepositorioCrudView.xaml
    /// </summary>
    public partial class RepositorioCrudView : MetroWindow
    {
        public RepositorioCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) RepositorioModeloController.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) RepositorioModeloController.Errors -= 1;
        }

    }
}