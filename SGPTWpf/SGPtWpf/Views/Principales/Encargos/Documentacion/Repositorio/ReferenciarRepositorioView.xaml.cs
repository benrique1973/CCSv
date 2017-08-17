using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio
{
    /// <summary>
    /// Lógica de interacción para ReferenciarRepositorioView.xaml
    /// </summary>
    public partial class ReferenciarRepositorioView : MetroWindow
    {
        public ReferenciarRepositorioView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            txtReferencia.Focus();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) RepositorioModeloController.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) RepositorioModeloController.Errors -= 1;
        }

    }
}
