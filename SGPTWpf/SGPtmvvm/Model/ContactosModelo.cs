using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class ContactosModelo
    {
        public int correlativo { get; set; }
        public int idcontacto { get; set; }
        public int idcargoeo { get; set; }
        public string nombrecargo { get; set; }
        public string nombrescontacto { get; set; }
        public string apellidoscontacto { get; set; }
        public string nombrecompleto { get; set; }
        public string fechainiciofuncioncontacto { get; set; }
        public string fechacesefuncioncontacto { get; set; }
        public string observacionescontacto { get; set; }
        public string estadocontacto { get; set; }

        public string telefonos { get; set; }

        public string correos { get; set; }

        public virtual correo correo { get; set; }

        public virtual telefono telefonoFijo { get; set; }

        public virtual telefono telefonoCelular { get; set; }
    }
}
