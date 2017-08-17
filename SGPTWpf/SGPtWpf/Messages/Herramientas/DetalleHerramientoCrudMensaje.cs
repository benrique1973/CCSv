using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Model.Modelo.Herramientas;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class DetalleHerramientoCrudMensaje
    {
        public DetalleHerramientasModelo detalleHerramientaElemento { get; set; }
        public ObservableCollection<DetalleHerramientasModelo> listaElementos { get; set; }

        public DetalleHerramientasModelo detalleHerramientaModelo { get; set; }

        public UsuarioModelo usuarioValidado { get; set; }

        public int comando { get; set; }

        public int? tiposHerramienta { get; set; }//Almacena el tipo  de herramienta ya sea programa o cuestionario u otro

        public HerramientasModelo herramientaModelo { get; set; }

        public int opcionMenuPrincipal { get; set; }

        public int opcionMenuCrud { get; set; }

        public int cmd { set; get; }
    }
}
