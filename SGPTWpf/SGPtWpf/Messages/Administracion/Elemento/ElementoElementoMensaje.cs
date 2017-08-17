using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;

namespace SGPTWpf.Messages.Elemento
{
    class ElementoElementoMensaje:Messenger
    {
        public ElementoModelo elementoMensaje { get; set; }

        public int comando { get; set; }
    }
}
