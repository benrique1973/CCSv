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
    
    public partial class departamento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public departamento()
        {
            this.clientes = new HashSet<cliente>();
            this.firmas = new HashSet<firma>();
            this.municipios = new HashSet<municipio>();
        }
    
        public int iddepartamento { get; set; }
        public Nullable<int> idpais { get; set; }
        public string nombredepartamento { get; set; }
        public bool sistemadepartamento { get; set; }
        public string estadodepartamento { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cliente> clientes { get; set; }
        public virtual pais pais { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<firma> firmas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<municipio> municipios { get; set; }
    }
}
