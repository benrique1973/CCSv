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
    
    public partial class matrizanalisisfinanciero
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public matrizanalisisfinanciero()
        {
            this.detallesmafs = new HashSet<detallesmaf>();
            this.usuariomatanalisfinancaccions = new HashSet<usuariomatanalisfinancaccion>();
        }
    
        public int idmaf { get; set; }
        public Nullable<int> idencargo { get; set; }
        public Nullable<int> idpapeles { get; set; }
        public string descripcionmaf { get; set; }
        public string estadomaf { get; set; }
        public string fechaevaluacionmaf { get; set; }
        public string referenciamaf { get; set; }
        public string uuid { get; set; }
        public string usuarioaprobo { get; set; }
        public string usuariocerro { get; set; }
        public string usuariosuperviso { get; set; }
        public string fechaaprobacion { get; set; }
        public string fechacierre { get; set; }
        public string fechasupervision { get; set; }
        public string etapapapel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallesmaf> detallesmafs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuariomatanalisfinancaccion> usuariomatanalisfinancaccions { get; set; }
    }
}
