using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class EncargoPlanDetalleIndiceMsj : MessageBase
    {
        public EncargoModelo encargoModelo { get; set; }
        public IndiceModelo detalleHerramientaElemento { get; set; }

        public ObservableCollection<IndiceModelo> listaElementos { get; set; }


        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public UsuarioModelo usuarioModelo { get; set; }

        public TipoCarpetaModelo herramientaModelo { get; set; }

        public string tokenRespuesta { get; set; }

        public DetalleProgramaModelo programaModelo { get; set; }

        public DetalleCuestionarioModelo cuestionarioModelo { get; set; }

        public DetalleCedulaModelo detalleCedulaModelo { get; set; }

        public int columnaDestino { get; set; }
    }
}
