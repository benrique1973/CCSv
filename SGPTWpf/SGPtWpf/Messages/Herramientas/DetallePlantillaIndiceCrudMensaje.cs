using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Indice;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class DetallePlantillaIndiceCrudMensaje
    {
        public DetallePlantillaIndiceModelo detallePlantillaIndiceModelo { get; set; }
        public ObservableCollection<DetallePlantillaIndiceModelo> listaElementos { get; set; }

        public int numeroProcesoCrudEnviado { get; set; }
        public int comandoCrud { get; set; }

        public UsuarioModelo usuarioModeloValidado { get; set; }

        public PlantillaIndiceModelo plantillaIndiceModelo { get; set; }
    }
}
