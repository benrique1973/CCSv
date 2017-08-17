using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    public class RepositorioMsj : Messenger
    {
        public RepositorioModelo entidadTrasladada { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<RepositorioModelo> lista;

        //public ObservableCollection<IndiceModelo> listaDetalle { get; set; }

        public string tokenRespuestaController { get; set; }
        public string tokenRespuestaVista { get; set; }
        //public SistemaContableModelo sistemaContableModelo { get; set; }
    }
}
