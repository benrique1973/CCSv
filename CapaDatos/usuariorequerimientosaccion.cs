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
    
    public partial class usuariorequerimientosaccion
    {
        public int idura { get; set; }
        public Nullable<int> idrequerimiento { get; set; }
        public Nullable<int> idusuario { get; set; }
        public string rolura { get; set; }
        public string fechacreadoura { get; set; }
        public string estadoura { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual requerimiento requerimiento { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
