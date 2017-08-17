using MahApps.Metro.Controls.Dialogs;

namespace SGPTWpf.ViewModel.Herramientas
{
    class GenericoHerramientasViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;

        #region Constructores

        public GenericoHerramientasViewModel()
        {
            dlg = new DialogCoordinator();
        }

        #endregion
    }
}