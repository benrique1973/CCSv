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
    
    public partial class historicoscontrasenia
    {
        public int idhc { get; set; }
        public int idusuario { get; set; }
        public string fechacreacionhc { get; set; }
        public string contraseniahc { get; set; }
        public string estadohc { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}
