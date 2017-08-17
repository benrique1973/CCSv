using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Administracion.Clientes
{
    public class ExpedienteViewModel : ViewModeloBase
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

        public ExpedienteViewModel()
        {
            dlg = new DialogCoordinator();
        }
        #endregion
    }
}