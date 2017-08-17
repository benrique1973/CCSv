using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Model.Modelo.Herramientas;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class HModeloDatosMensajes
    {
        public HerramientasModelo herramientaModeloElemento { get; set; }

        public ObservableCollection<HerramientasModelo> listaHerramientas { get; set; }
        public DetalleHerramientasModelo detalleHerramientaModelo { get; set; }

        public UsuarioModelo usuarioValidado { get; set; }

        public int opcionMenuPrincipal { get; set; }

        public int opcionMenuCrud { get; set; }

        public int cmd { set; get; }

        public ObservableCollection<DetalleHerramientasModelo> listaDetalleHerramienta { get; set; }
    }
}
