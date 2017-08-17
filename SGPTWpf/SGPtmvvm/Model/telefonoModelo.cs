using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class telefonoModelo
    {
        public telefonoModelo()
        {
            this.clientes = new HashSet<cliente>();
        }


        public int idtelefono { get; set; }

        public int idfirma { get; set; }

        public string idduipersona { get; set; }

        public int idtt { get; set; }

        public string idnitcliente { get; set; }

        public int idcontacto { get; set; }

        public string numerotelefono { get; set; }
        public string descripciontelefono { get; set; }

        public string estadotelefono { get; set; }

        public virtual ICollection<cliente> clientes { get; set; }

        public virtual firma firma { get; set; }

        public virtual persona persona { get; set; }

        public virtual tipostelefono tipostelefono { get; set; }
    }
}
