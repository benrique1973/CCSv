//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class contacto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contacto()
        {
            this.correos = new HashSet<correo>();
            this.correspondencias = new HashSet<correspondencia>();
            this.telefonos = new HashSet<telefono>();
        }
    
        public int idcontacto { get; set; }
        public Nullable<int> idcargoeo { get; set; }
        public string nombrescontacto { get; set; }
        public string apellidoscontacto { get; set; }
        public string fechainiciofuncioncontacto { get; set; }
        public string fechacesefuncioncontacto { get; set; }
        public string estadocontacto { get; set; }
        public string observacionescontacto { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual estructurasorganica estructurasorganica { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correo> correos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correspondencia> correspondencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefono> telefonos { get; set; }
    }
}
