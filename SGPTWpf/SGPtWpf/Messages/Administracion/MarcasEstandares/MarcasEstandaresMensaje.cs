using SGPTWpf.Model.Modelo;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Administracion.MarcasEstandares
{
    class MarcasEstandaresMensaje
    {
        public MarcasEstandaresModelo elementoMensaje { get; set; }
        public ObservableCollection<MarcasEstandaresModelo> listaMensaje { get; set; }
        public int numeroProcesoCrudEnviado { get; set; }

        public int comandoCrud { get; set; }
    }
}
