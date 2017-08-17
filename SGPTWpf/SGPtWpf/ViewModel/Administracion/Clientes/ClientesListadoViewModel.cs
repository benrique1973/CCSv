using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.ViewModel.Administracion.Clientes
{
    public class ClientesListadoViewModel
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<cliente> ListadoClientes { get; set; }

        public ClientesListadoViewModel()
        {
            this.ObtenerDatos();
        }
        
        public void ObtenerDatos()
        {
            using (db = new SGPTEntidades())
            {
                ListadoClientes = (from c in db.clientes orderby c.razonsocialcliente select c).ToList();
            }
        }
    }
}
