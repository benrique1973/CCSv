using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Media;
using SGPTmvvm.Mensajes;

namespace SGPTmvvm.ViewModel.FilaVM
{
    public class ComandoVM
    {
        public ComandoVM()
        {
            Send = new RelayCommand(SendExecute);
        }
        public string CommandDisplay { get; set; }
        public ComandoMensaje Message{ get; set; }
        public RelayCommand Send { get; private set; }
        public Geometry IconGeometry { get; set; }

        private void SendExecute()
        {
            Messenger.Default.Send<ComandoMensaje>(Message);
        }
    }
}
