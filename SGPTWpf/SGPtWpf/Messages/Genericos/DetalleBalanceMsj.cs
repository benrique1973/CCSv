using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class DetalleBalanceMsj : Messenger
    {
        public BalanceModelo balanceModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public DetalleBalanceModelo detalleBalancemodelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<DetalleBalanceModelo> listaDetalleBalanceModelo { get; set; }

        public ObservableCollection<CatalogoCuentasModelo> listaCatalogoCuentas { get; set; }

        public SistemaContableModelo sistemaContableModelo { get; set; }
    }
}
