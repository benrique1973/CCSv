using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.Messages.Encargos
{
    class EncargosPlanProgramasDetalleListaMsj : Messenger
    {
        public ObservableCollection<DetalleProgramaModelo> listaElementos { get; set; }

        public ObservableCollection<DetalleCuestionarioModelo> listaElementosCuestionario { get; set; }

        public int cuentaMensajeDetalleVistaPrograma { get; set; }
    }
}
