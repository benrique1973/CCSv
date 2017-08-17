using SGPTWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.Departamento
{
    class DepartamentoListaMensaje
    {
        public ObservableCollection<DepartamentoModelo> listaMensaje { get; set; }
    }
}
