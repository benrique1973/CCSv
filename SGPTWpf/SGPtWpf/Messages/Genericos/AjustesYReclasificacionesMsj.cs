using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class AjustesYReclasificacionesMsj : Messenger
    {
        public CedulaModelo entidadMaestroModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<CedulaModelo> listaMaestroModelo { get; set; }

        public ObservableCollection<CedulaPartidasModelo> listaDetalle { get; set; }

        public ObservableCollection<CedulaDiarioModelo> listaDiario { get; set; }

        public ObservableCollection<CedulaMovimientoModelo> listaMovimientosPorPartida { get; set; }

        public CedulaPartidasModelo entidadDetalle { get; set; }

        public string tokenRespuestaController { get; set; }
        public string tokenRespuestaVista { get; set; }

        public string tokenRecepcionSubMenuDetalle { get; set; }

    }
}
