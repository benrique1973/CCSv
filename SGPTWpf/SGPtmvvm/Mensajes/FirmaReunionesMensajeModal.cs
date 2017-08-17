using CapaDatos;
using SGPTmvvm.Model;

namespace SGPTmvvm.Mensajes
{
    public class FirmaReunionesMensajeModal
    {
        public TipoComando Accion { get; set; }
        public usuario UsuarioValidado { get; set; }
        public ReunionesModelo ReunionesAmodificar { get; set; }
    }
}


