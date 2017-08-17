using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Agenda;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Agenda
{
    /// <summary>
    /// Lógica de interacción para ReferenciarView.xaml
    /// </summary>
    public partial class ReferenciarView : MetroWindow
    {
        public ReferenciarView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            txtReferencia.Focus();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) AgendaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) AgendaControllerViewModel.Errors -= 1;
        }

    }
}