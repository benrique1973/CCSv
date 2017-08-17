using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Cuestionarios
{
    /// <summary>
    /// Lógica de interacción para ReferenciarCuestionarios.xaml
    /// </summary>
    public partial class ReferenciarCuestionariosView : MetroWindow
    {
        public ReferenciarCuestionariosView()
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
        private void txtReferenciaKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtHorasEjecucion.Focus();
            }
        }
        private void txtHojasEjecucionKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dpkfechaCierrePrograma.Focus();
            }
        }
        private void txtFechaCierreKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                botones.Focus();
            }
        }
    }
}
