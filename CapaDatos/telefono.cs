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
    
    public partial class telefono
    {
        public int idtelefono { get; set; }
        public Nullable<int> idfirma { get; set; }
        public string idduipersona { get; set; }
        public Nullable<int> idtt { get; set; }
        public string idnitcliente { get; set; }
        public Nullable<int> idcontacto { get; set; }
        public string numerotelefono { get; set; }
        public string estadotelefono { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual cliente cliente { get; set; }
        public virtual contacto contacto { get; set; }
        public virtual firma firma { get; set; }
        public virtual persona persona { get; set; }
        public virtual tipostelefono tipostelefono { get; set; }
    }
}
