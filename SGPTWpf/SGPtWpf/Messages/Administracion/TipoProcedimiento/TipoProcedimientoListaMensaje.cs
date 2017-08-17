using SGPTWpf.Model;
using SGPTWpf.Model.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.TipoProcedimiento
{
    class TipoProcedimientoListaMensaje
    {
        public ObservableCollection<TipoProcedimientoModelo> listaMensaje { get; set; }
    }
}
