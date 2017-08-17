using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Plantilla;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Administracion.DetalleDocumentoCrudMensaje
{
    class DetalleDocumentoCrudMensaje
    {
        public DetalleDocumentoModelo detalleDocumentoModelo { get; set; }
        public ObservableCollection<DetalleDocumentoModelo> listadetalleDocumento { get; set; }
        public int comandoCrud { get; set; }
        public UsuarioModelo usuarioModeloValidado { get; set; }
    }
}
