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
    
    public partial class cedulacorrespondencia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cedulacorrespondencia()
        {
            this.hallazgos = new HashSet<hallazgo>();
        }
    
        public int idccorrespondencia { get; set; }
        public Nullable<int> idcedula { get; set; }
        public Nullable<int> idpapeles { get; set; }
        public string numeroccorrespondencia { get; set; }
        public string asuntoccorrespondencia { get; set; }
        public string firmaccorrespondencia { get; set; }
        public string fecharecepcionccorrespondenc { get; set; }
        public string comentarioccorrespondencia { get; set; }
        public string estadoccorrespondencia { get; set; }
        public string referenciapapel { get; set; }
        public Nullable<int> idgenerico { get; set; }
        public string tabla { get; set; }
        public string usuariocerro { get; set; }
        public string usuarioaprobo { get; set; }
        public string usuariosuperviso { get; set; }
        public string fechasupervision { get; set; }
        public string fechaaprobacion { get; set; }
        public string fechacierre { get; set; }
        public string etapapapel { get; set; }
        public Nullable<int> idencargo { get; set; }
        public string uuid { get; set; }
    
        public virtual cedula cedula { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hallazgo> hallazgos { get; set; }
        public virtual encargo encargo { get; set; }
        public virtual papele papele { get; set; }
    }
}
