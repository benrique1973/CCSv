using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Encargos.Documentacion
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ConsultaMaterialidadViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public ConsultaMaterialidadViewModel()
        {
            dlg = new DialogCoordinator();
        }

        #endregion
    }
}