using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class IndiceMsj : Messenger
    {
        public TipoCarpetaModelo tipoCarpetaModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<TipoCarpetaModelo> listaTipoCarpetaModelo;

        public ObservableCollection<IndiceModelo> listaDetalle { get; set; }

        public string tokenRespuestaController { get; set; }
        public string tokenRespuestaVista { get; set; }

        public string tokenRecepcionSubMenuDetalle { get; set; }
    }
}
