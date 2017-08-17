using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model.Modelo.Encargos;

namespace SGPTWpf.Messages.Genericos
{
    class EncargoMensaje: Messenger
    {
        public EncargoModelo encargoModelo { get; set; }
    }
}
