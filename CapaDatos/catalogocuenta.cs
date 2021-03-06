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
    
    public partial class catalogocuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public catalogocuenta()
        {
            this.catalogocuentas1 = new HashSet<catalogocuenta>();
            this.detallebalances = new HashSet<detallebalance>();
            this.detallecedulas = new HashSet<detallecedula>();
            this.movimientos = new HashSet<movimiento>();
        }
    
        public int idcc { get; set; }
        public Nullable<int> idelementos { get; set; }
        public Nullable<int> idsc { get; set; }
        public Nullable<int> catidcc { get; set; }
        public Nullable<int> idccuentas { get; set; }
        public string codigocc { get; set; }
        public string descripcioncc { get; set; }
        public string tiposaldocc { get; set; }
        public string fechacreacioncc { get; set; }
        public string estadocc { get; set; }
        public Nullable<decimal> ordencc { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual elemento elemento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<catalogocuenta> catalogocuentas1 { get; set; }
        public virtual catalogocuenta catalogocuenta1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallebalance> detallebalances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallecedula> detallecedulas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<movimiento> movimientos { get; set; }
        public virtual clasecuenta clasecuenta { get; set; }
        public virtual sistemascontable sistemascontable { get; set; }
    }
}
