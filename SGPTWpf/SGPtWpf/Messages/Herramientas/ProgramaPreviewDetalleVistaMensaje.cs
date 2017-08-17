using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Model.Modelo.Herramientas;

namespace SGPTWpf.Messages.Herramientas
{
    class ProgramaPreviewDetalleVistaMensaje
    {
        public int opcionMenuPrincipal { get; set; }
        public HerramientasModelo herramientaModelo { get; set; }
        public UsuarioModelo usuarioValidado { get; set; }
        public int opcionMenuCrud { get; set; }


    }
}
