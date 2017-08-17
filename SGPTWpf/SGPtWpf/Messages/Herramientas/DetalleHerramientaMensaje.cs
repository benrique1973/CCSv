using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Herramientas;

namespace SGPTWpf.Messages.Herramientas
{
    class DetalleHerramientaMensaje: MessageBase
    {
        public int opcionMenuPrincipal { get; set; }
        public HerramientasModelo herramientaModelo { get; set; }
        public UsuarioModelo usuarioValidado { get; set; }
        public int opcionMenuCrud { get; set; }

        public int numeroMensaje { get; set; }
    }
}
