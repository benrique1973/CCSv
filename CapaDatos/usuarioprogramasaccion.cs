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
    
    public partial class usuarioprogramasaccion
    {
        public int idupa { get; set; }
        public int idprograma { get; set; }
        public Nullable<int> iddp { get; set; }
        public Nullable<int> idusuarioupa { get; set; }
        public string rolupa { get; set; }
        public string fechacreadoupa { get; set; }
        public string estadoupa { get; set; }
        public Nullable<int> iddcupa { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
        public Nullable<int> idencargo { get; set; }
    
        public virtual detallecuestionario detallecuestionario { get; set; }
        public virtual detalleprograma detalleprograma { get; set; }
        public virtual encargo encargo { get; set; }
        public virtual programa programa { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
