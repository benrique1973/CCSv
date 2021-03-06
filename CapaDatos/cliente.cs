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
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.elementos = new HashSet<elemento>();
            this.encargos = new HashSet<encargo>();
            this.estructurasorganicas = new HashSet<estructurasorganica>();
            this.papeles = new HashSet<papele>();
            this.correos = new HashSet<correo>();
            this.detalletiempoes = new HashSet<detalletiempo>();
            this.telefonos = new HashSet<telefono>();
        }
    
        public string idnitcliente { get; set; }
        public int idclasificacion { get; set; }
        public int idpais { get; set; }
        public string idcodigoactividad { get; set; }
        public Nullable<int> idsc { get; set; }
        public Nullable<int> iddepartamento { get; set; }
        public Nullable<int> idmunicipio { get; set; }
        public string razonsocialcliente { get; set; }
        public string nrccliente { get; set; }
        public string direccioncliente { get; set; }
        public string actividadcliente { get; set; }
        public string paginawebcliente { get; set; }
        public string fechaconstitucioncliente { get; set; }
        public string estadocliente { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual actividade actividade { get; set; }
        public virtual clasificacione clasificacione { get; set; }
        public virtual pais pais { get; set; }
        public virtual departamento departamento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<elemento> elementos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<encargo> encargos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<estructurasorganica> estructurasorganicas { get; set; }
        public virtual municipio municipio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<papele> papeles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correo> correos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalletiempo> detalletiempoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefono> telefonos { get; set; }
    }
}
