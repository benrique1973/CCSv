using SGPTWpf.Model.Modelo.detalleherramientas;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class HerramientasDetalleCuestionarioListaMensaje
    {
        public ObservableCollection<DetalleHerramientasModelo> listaElementos { get; set; }
    }
}
