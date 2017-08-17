using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class DetalleIndiceMsj : Messenger
    {
        public TipoCarpetaModelo tipoCarpetaModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public IndiceModelo indiceModelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<IndiceModelo> listaDetalleIndiceModelo { get; set; }

        public ObservableCollection<TipoCarpetaModelo> listaTipoCarpetaModel { get; set; }

        public string tokenRespuesta { get; set; }

        // public SistemaContableModelo sistemaContableModelo { get; set; }
    }
}
