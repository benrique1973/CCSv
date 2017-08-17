using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances
{
    /// <summary>
    /// Lógica de interacción para BalancesCrudView.xaml
    /// </summary>
    public partial class BalancesCrudView : MetroWindow
    {
        public BalancesCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) BalancesControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) BalancesControllerViewModel.Errors -= 1;
        }

    }
}
