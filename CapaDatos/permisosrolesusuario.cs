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
    
    public partial class permisosrolesusuario
    {
        public int idpru { get; set; }
        public Nullable<int> idusuario { get; set; }
        public Nullable<int> idrol { get; set; }
        public string nombreopcionpru { get; set; }
        public bool crearpru { get; set; }
        public bool eliminarpru { get; set; }
        public bool consultarpru { get; set; }
        public bool editarpru { get; set; }
        public bool impresionpru { get; set; }
        public bool exportacionpru { get; set; }
        public bool revisarpru { get; set; }
        public bool aprobarpru { get; set; }
        public string estadopru { get; set; }
        public string menupru { get; set; }
        public string submenupru { get; set; }
        public string subsubmenupru { get; set; }
        public Nullable<bool> mostrarenmenupru { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual role role { get; set; }
        public virtual usuario usuario { get; set; }
    }
}
