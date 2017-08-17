using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Documentos.Carga
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class CargaViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public CargaViewModel()
        {
            dlg = new DialogCoordinator();
        }

        #endregion
    }
}