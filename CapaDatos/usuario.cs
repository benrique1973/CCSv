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
    
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            this.agendas = new HashSet<agenda>();
            this.agendas1 = new HashSet<agenda>();
            this.asignaciones = new HashSet<asignacione>();
            this.bitacoras = new HashSet<bitacora>();
            this.correspondencias = new HashSet<correspondencia>();
            this.correspondencias1 = new HashSet<correspondencia>();
            this.designaciones = new HashSet<designacione>();
            this.detallecronogramas = new HashSet<detallecronograma>();
            this.detalleherramientas = new HashSet<detalleherramienta>();
            this.detalleprogramas = new HashSet<detalleprograma>();
            this.firmas = new HashSet<firma>();
            this.historicoscontrasenias = new HashSet<historicoscontrasenia>();
            this.informeactividades = new HashSet<informeactividade>();
            this.informeactividades1 = new HashSet<informeactividade>();
            this.marcasestandares = new HashSet<marcasestandare>();
            this.normativas = new HashSet<normativa>();
            this.notaspts = new HashSet<notaspt>();
            this.obligacioneslegales = new HashSet<obligacioneslegale>();
            this.papeles = new HashSet<papele>();
            this.permisosrolesusuarios = new HashSet<permisosrolesusuario>();
            this.plantillaindices = new HashSet<plantillaindice>();
            this.plantillas = new HashSet<plantilla>();
            this.ratios = new HashSet<ratio>();
            this.reuniones = new HashSet<reunione>();
            this.reuniones1 = new HashSet<reunione>();
            this.usuarioherramientasaccions = new HashSet<usuarioherramientasaccion>();
            this.usuariomatanalisfinancaccions = new HashSet<usuariomatanalisfinancaccion>();
            this.usuarioprogramasaccions = new HashSet<usuarioprogramasaccion>();
            this.usuariorequerimientosaccions = new HashSet<usuariorequerimientosaccion>();
        }
    
        public int idusuario { get; set; }
        public string idduipersona { get; set; }
        public Nullable<int> idpista { get; set; }
        public Nullable<int> usuidusuario { get; set; }
        public Nullable<int> idrol { get; set; }
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
        public Nullable<int> temacolorsistemausuario { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agenda> agendas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agenda> agendas1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<asignacione> asignaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bitacora> bitacoras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correspondencia> correspondencias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correspondencia> correspondencias1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<designacione> designaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detallecronograma> detallecronogramas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleherramienta> detalleherramientas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalleprograma> detalleprogramas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<firma> firmas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<historicoscontrasenia> historicoscontrasenias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<informeactividade> informeactividades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<informeactividade> informeactividades1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<marcasestandare> marcasestandares { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<normativa> normativas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notaspt> notaspts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obligacioneslegale> obligacioneslegales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<papele> papeles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permisosrolesusuario> permisosrolesusuarios { get; set; }
        public virtual persona persona { get; set; }
        public virtual pista pista { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plantillaindice> plantillaindices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<plantilla> plantillas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ratio> ratios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reunione> reuniones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reunione> reuniones1 { get; set; }
        public virtual role role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarioherramientasaccion> usuarioherramientasaccions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuariomatanalisfinancaccion> usuariomatanalisfinancaccions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarioprogramasaccion> usuarioprogramasaccions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuariorequerimientosaccion> usuariorequerimientosaccions { get; set; }
    }
}
