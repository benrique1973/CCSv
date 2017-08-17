using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class detalletiempoModelo
    {
        public int iddt { get; set; }
        public int iddt2 { get; set; }
        public string idnitcliente { get; set; }
        public string descripcioncliente { get; set; }
        public int idia { get; set; }
        public int idchh { get; set; }
        public int idencargo { get; set; }
        public string descripcionencargo { get; set; }
        public int idindice { get; set; }
        public string actividaddt { get; set; }
        public DateTime fechainicialdt { get; set; }
        public DateTime fechafinaldt { get; set; }
        public decimal tiempohorasdt { get; set; }
        public string comentariosdt { get; set; }
        public string estadodt { get; set; }

        public virtual cliente cliente { get; set; }
        public virtual index index { get; set; }
    }
}
