using CapaDatos;
using SGPTWpf.Model;

namespace SGPTWpf.Messages.Administracion.Usuario
{
    class PrincipalUsuarioValidadoMensaje
    {
        public usuario elementoMensaje { get; set; }
        public UsuarioModelo usuarioModelo { get; set; }
    }
}
