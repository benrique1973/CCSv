using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.CatalogoCuentas
{
    public partial class CatalogoCuentasCrudView : MetroWindow
    {
        public CatalogoCuentasCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) CatalogoCuentasControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) CatalogoCuentasControllerViewModel.Errors -= 1;
        }

    }
}
