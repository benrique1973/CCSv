//using ModeloSGPT.Modelo;
using CapaDatos;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class usuariospersonas : CrudVMBase
    {
        public usuariospersonas()
        {
            this.correos = new HashSet<correo>();
            this.telefonos = new HashSet<telefono>();
            this.usuarios = new HashSet<usuario>();
            
            this.usuarios1 = new HashSet<usuario>();
        }
        /*Personas*/
        public int correlativo { get; set; }
        public string idduipersona { get; set; }
        public string nombrespersona { get; set; }
        public string apellidospersona { get; set; }
        public string nombreCompleto { get; set; }
        public string sexopersona { get; set; }
        public string direccionpersona { get; set; }
        public string noafppersona { get; set; }
        public string noissspersona { get; set; }
        public string nitpersona { get; set; }
        public string estadopersona { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correo> correos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefono> telefonos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuarios { get; set; }

        /*Usuarios*/
        public int idusuario { get; set; }
        public int idpista { get; set; }
        public int usuidusuario { get; set; }
        public string nombreusuidusuario { get; set; }
        public int idrol { get; set; }
        public string nombrerol { get; set; }
        public int idfirma { get; set; }
        public string fecharegistrousuario { get; set; }
        public string fechadebaja { get; set; }
        public string fechacontratacion { get; set; }
        public string nickusuariousuario { get; set; }
        public string inicialesusuario { get; set; }
        public string respuestapistausuario { get; set; }
        public string numerocvpausuario { get; set; }
        public string fechacvpausuario { get; set; }
        public string estadousuario { get; set; }
        public string contraseniausuario { get; set; }
    
        
        public virtual persona personas { get; set; }
        public virtual pista pistas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual role roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuarios1 { get; set; }
        public virtual usuario usuarios2 { get; set; }

        /***************************************************************************/

    }
}
    
