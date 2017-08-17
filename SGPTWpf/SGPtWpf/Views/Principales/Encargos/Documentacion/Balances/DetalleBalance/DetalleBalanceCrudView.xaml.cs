using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances.DetalleBalance
{
    /// <summary>
    /// Lógica de interacción para DetalleBalanceCrudView.xaml
    /// </summary>
    public partial class DetalleBalanceCrudView : MetroWindow
    {
        public DetalleBalanceCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            txtCodigoContable.Focus();
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) DetalleBalanceControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) DetalleBalanceControllerViewModel.Errors -= 1;
        }

        private void txtSaldoInicialKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                codCargos.Focus();
            }
        }

        private void txtCargosKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                codAbonos.Focus();
            }
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
        private void txtCodigoKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                codSaldoInicial.Focus();
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