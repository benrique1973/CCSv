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
    class RiesgoMsj : Messenger
    {
        public MatrizRiesgoModelo matrizRiesgoModelo { get; set; }

        public EncargoModelo encargoModelo { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }

        public int opcionMenuCrud { get; set; }

        public int fuenteLlamado { get; set; }//1 Cuando se origina de  encargo/documentacion/programa, //2 de admon/clientes/encargos

        public ObservableCollection<MatrizRiesgoModelo> listaMatrizRiesgoModelo;

        public SistemaContableModelo sistemaContableModelo { get; set; }

        public string tokenRespuesta { get; set; }
    }
}
