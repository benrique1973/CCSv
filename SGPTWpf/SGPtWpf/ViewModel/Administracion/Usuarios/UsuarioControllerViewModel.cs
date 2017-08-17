using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Administracion
{

    public class UsuarioControllerViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public UsuarioControllerViewModel(DialogCoordinator dlgIn)
        {
            dlg = new DialogCoordinator();
        }
        #endregion
    }
}