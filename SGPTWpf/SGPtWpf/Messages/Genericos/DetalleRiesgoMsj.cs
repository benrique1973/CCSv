using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class DetalleRiesgoMsj : Messenger
    {
        public MatrizRiesgoModelo matrizRiesgoModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public DetalleMatrizRiesgoModelo detalleMatrizRiesgoModelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<DetalleMatrizRiesgoModelo> listaDetalleMatrizRiesgoModelo;

        //public ObservableCollection<CatalogoCuentasModelo> listaCatalogoCuentas;

        //public SistemaContableModelo sistemaContableModelo { get; set; }
        public string tokenRespuesta { get; set; }

        public ObservableCollection<DetalleBalanceModelo> listaDetalleBalanceModelo { get; set; }
    }
}
