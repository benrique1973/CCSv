using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class ProgramaDatosMsj : Messenger
    {
        public ProgramaModelo programaModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public DetalleProgramaModelo detallePrograma { get; set; }

        public DetalleCuestionarioModelo detalleCuestionario { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public int opcionTipoPrograma { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/planificacion/programa, //2 de encargo/planificacion/edicion/vista

        public ObservableCollection<DetalleProgramaModelo> listaDetalleHerramientaP;

        public ObservableCollection<DetalleCuestionarioModelo> listaDetalleHerramientaC;

        public ObservableCollection<ProgramaModelo> listaProgramaModelo;

        public string tokenRespuesta { get; set; }
    }
}
