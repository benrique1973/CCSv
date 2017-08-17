using CapaDatos;
using SGPTmvvm.Model;
using SGPTWpf.SGPtmvvm.Model;

namespace SGPTmvvm.Mensajes
{
    /// <summary>
    /// Este mensaje sirve para el tab cliente que controla dos tablas; la de contactos y la de estructura organica
    /// </summary>
    public class ClientesContactosMensajeModal
    {
        public TipoComando Accion { get; set; }
        public usuario UsuarioValidado { get; set; }
        public cliente currentCliente { get; set; }
        public string llamadoDesde { get; set; } //se utilizara para saber si la ventana se llamo desde expedientes, o desde contactos pq las dos la utilizan.
        //public ClienteContactoModelo currentCliente2 { get; set; }
        public ContactosModelo ContactosAmodificar { get; set; }
        public sistemascontable SistemaContableAModificar { get; set; }
        public estructurasorganica EstructuraAmodificar { get; set; }
    }
}
