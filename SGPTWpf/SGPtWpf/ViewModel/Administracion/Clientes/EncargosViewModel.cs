using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Administracion.Clientes
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class EncargosViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;
        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion
        #region Constructores

        public EncargosViewModel()
        {
            dlg = new DialogCoordinator();
        }
        #endregion
    }
}