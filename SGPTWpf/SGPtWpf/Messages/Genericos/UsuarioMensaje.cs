using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;

namespace SGPTWpf.Messages.Genericos
{
    public class UsuarioMensaje : Messenger
    {
            public usuario usuarioMensaje { get; set; }

            public UsuarioModelo usuarioModeloMensaje { get; set; }
    }
}
