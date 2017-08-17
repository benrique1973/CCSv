using SGPTWpf.Model.Modelo.detalleherramientas;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class HerramientasDetalleListaMensaje
    {
        public ObservableCollection<DetalleHerramientasModelo> listaElementos { get; set; }

        public int cuentaMensajeDetalleVistaPrograma { get; set; }
    }
}
