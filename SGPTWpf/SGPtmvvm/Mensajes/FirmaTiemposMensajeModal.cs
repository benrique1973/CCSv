using CapaDatos;
using SGPTmvvm.Model;

namespace SGPTmvvm.Mensajes
{
    public class FirmaTiemposMensajeModal
    {
        public TipoComando Accion { get; set; }
        public usuario UsuarioValidado { get; set; }
        public InformeActividadesModelo InformeAmodificar { get; set; }
        
    }
}
