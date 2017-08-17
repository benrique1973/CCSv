using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Cuestionarios
{
    /// <summary>
    /// Lógica de interacción para CuestionarioBitacoraView.xaml
    /// </summary>
    public partial class CuestionarioBitacoraView : MetroWindow
    {
        public CuestionarioBitacoraView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            txtReferencia.Focus();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) CuestionarioControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) CuestionarioControllerViewModel.Errors -= 1;
        }
    }
}
