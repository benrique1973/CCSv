using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtmvvm.Model
{
    public class ClienteContactoModelo
    {
        public string idnitcliente { get; set; }
        public int idclasificacion { get; set; }
        public int idpais { get; set; }
        public string idcodigoactividad { get; set; }
        public int idsc { get; set; }
        public int iddepartamento { get; set; }
        public int idmunicipio { get; set; }
        public string razonsocialcliente { get; set; }
        public string nrccliente { get; set; }
        public string direccioncliente { get; set; }
        public string actividadcliente { get; set; }
        public string paginawebcliente { get; set; }
        public string fechaconstitucioncliente { get; set; }
        public string estadocliente { get; set; }

        public string estructuraorganica { get; set; }
        public virtual ICollection<estructurasorganica> estructurasorganica { get; set; }

        public int cantidadcontactos { get; set; }
        public virtual ICollection<contacto> contactos { get; set; }
    }
}
