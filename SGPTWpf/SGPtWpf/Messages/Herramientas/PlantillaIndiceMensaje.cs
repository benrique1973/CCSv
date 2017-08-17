using SGPTWpf.Model.Modelo.Indice;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class PlantillaIndiceMensaje
    {
        public PlantillaIndiceModelo elementoMensaje { get; set; }
        public ObservableCollection<PlantillaIndiceModelo> listaMensaje { get; set; }
        public int numeroProcesoCrudEnviado { get; set; }
        public int comandoCrud { get; set; }
    }
}
