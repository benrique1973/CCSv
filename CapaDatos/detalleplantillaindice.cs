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
    
    public partial class detalleplantillaindice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public detalleplantillaindice()
        {
            this.detalleplantillaindice1 = new HashSet<detalleplantillaindice>();
        }
    
        public int iddpi { get; set; }
        public Nullable<int> idtei { get; set; }
        public Nullable<int> idpi { get; set; }
        public Nullable<int> detiddpi { get; set; }
        public string descripciondpi { get; set; }
        public Nullable<decimal> ordendpi { get; set; }
        public string referenciadpi { get; set; }
        public bool obligatoriodpi { get; set; }
        public bool sistemadpi { get; set; }
        public string estadodpi { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleplantillaindice> detalleplantillaindice1 { get; set; }
        public virtual detalleplantillaindice detalleplantillaindice2 { get; set; }
        public virtual tipoelementoindice tipoelementoindice { get; set; }
        public virtual plantillaindice plantillaindice { get; set; }
    }
}
