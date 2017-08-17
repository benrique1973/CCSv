using CapaDatos;
using SGPTmvvm.Model;

namespace SGPTmvvm.Mensajes
{
    public class FirmaCorrespondenciaMensajeModal
    {
        public TipoComando Accion { get; set; }
        public usuario UsuarioValidado { get; set; }
        public CorrespondenciaModelo CorrespondenciaAmodificar { get; set; }
    }
}


