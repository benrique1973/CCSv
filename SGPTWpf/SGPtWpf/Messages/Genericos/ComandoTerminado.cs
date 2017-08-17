using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class ComandoTerminado : Messenger
    {
        public bool cargaTerminada { get; set; }

        public Cursor cursorWindow { get; set; }
    }
}
