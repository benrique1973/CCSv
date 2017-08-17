using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Administracion.Firma
{
    class ConfiguracionViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public ConfiguracionViewModel(DialogCoordinator dlgIn)
        {
            dlg = new DialogCoordinator();
        }
        #endregion
    }
}
