using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtmvvm.Model
{
    public class ElementosContablesModelo
    {
        public int correlativo { get; set; }
        public int idelementos { get; set; }
        public string idnitcliente { get; set; }
        public string descripcionelementos { get; set; }
        public string fechacreacionelementos { get; set; }
        public bool sistemaelementos { get; set; }
        public string estadoelementos { get; set; }
        public int idscelementos { get; set; }
        public int codigoelemento { get; set; }

        public virtual cliente cliente { get; set; }
        public virtual sistemascontable sistemascontable { get; set; }
    }
}
