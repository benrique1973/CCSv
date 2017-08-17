using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Encargos.Supervision
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class RevisiónPapelesViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public RevisiónPapelesViewModel()
        {
            dlg = new DialogCoordinator();
        }

        #endregion
    }
}