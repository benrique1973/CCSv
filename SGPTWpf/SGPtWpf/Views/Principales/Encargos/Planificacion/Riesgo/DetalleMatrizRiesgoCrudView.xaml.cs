using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo
{
    /// <summary>
    /// Lógica de interacción para DetalleMatrizRiesgoCrudView.xaml
    /// </summary>
    public partial class DetalleMatrizRiesgoCrudView : MetroWindow
    {
        public DetalleMatrizRiesgoCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) DetalleMatrizRiesgoControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) DetalleMatrizRiesgoControllerViewModel.Errors -= 1;
        }


        private void txtAbonosKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                comboSaldo.Focus();
            }
        }
        private void txtBuscarCodigoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                comboSaldo.Focus();
            }
        }
        private void txtSaldoFinalKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                spMenu.Focus();
            }
        }
    }
}