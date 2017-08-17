using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Encargos
{
    class EncargoPlanDetalleProgramaCrudMsj : MessageBase
    {
        public DetalleProgramaModelo detalleHerramientaElemento { get; set; }

        public DetalleCuestionarioModelo detalleHerramientaCuestionarioElemento { get; set; }
        public ObservableCollection<DetalleProgramaModelo> listaElementos { get; set; }

        public ObservableCollection<DetalleCuestionarioModelo> listaElementosCuestionario { get; set; }

        public int comando { get; set; }

        public int? tiposHerramienta { get; set; }//Almacena el tipo  de herramienta ya sea programa o cuestionario u otro

        public UsuarioModelo usuarioValidado { get; set; }

        public ProgramaModelo herramientaModelo { get; set; }

        public EncargoModelo currentEncargo { get; set; }

    }
}
