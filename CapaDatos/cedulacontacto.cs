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
    
    public partial class cedulacontacto
    {
        public int idccontacto { get; set; }
        public Nullable<int> idcedula { get; set; }
        public string nombresccontacto { get; set; }
        public string apellidosccontacto { get; set; }
        public string fechainiciofuncionccontacto { get; set; }
        public string fechacesefuncionccontacto { get; set; }
        public string cargoccontacto { get; set; }
        public string estadoccontacto { get; set; }
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
        public virtual encargo encargo { get; set; }
    }
}
