using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Documentos.Generacion
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class GeneracionViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public GeneracionViewModel()
        {
            dlg = new DialogCoordinator();
        }

        #endregion
    }
}