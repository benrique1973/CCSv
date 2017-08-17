using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Documentos.Consulta
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ConsultaViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public ConsultaViewModel()
        {
            dlg = new DialogCoordinator();
        }

        #endregion
    }
}