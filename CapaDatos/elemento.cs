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
    
    public partial class elemento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public elemento()
        {
            this.catalogocuentas = new HashSet<catalogocuenta>();
            this.elementos1 = new HashSet<elemento>();
        }
    
        public int idelementos { get; set; }
        public string idnitcliente { get; set; }
        public string descripcionelementos { get; set; }
        public string fechacreacionelementos { get; set; }
        public bool sistemaelementos { get; set; }
        public string estadoelementos { get; set; }
        public Nullable<int> idscelementos { get; set; }
        public int codigoelemento { get; set; }
        public Nullable<int> isuso { get; set; }
        public Nullable<int> padreidelemento { get; set; }
        public string uuid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catalogocuenta> catalogocuentas { get; set; }
        public virtual cliente cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<elemento> elementos1 { get; set; }
        public virtual elemento elemento1 { get; set; }
        public virtual sistemascontable sistemascontable { get; set; }
    }
}
