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
    
    public partial class hallazgo
    {
        public int idhallazgo { get; set; }
        public Nullable<int> idcedula { get; set; }
        public Nullable<int> detidcedula { get; set; }
        public Nullable<int> idcorrespondencia { get; set; }
        public string descripcionhallazgo { get; set; }
        public string referenciahallazgo { get; set; }
        public string fechacreadohallazgo { get; set; }
        public string baselegalhallazgo { get; set; }
        public string recomendacionhallazgo { get; set; }
        public string respuestaclientehallazgo { get; set; }
        public string fecharespclientehallazgo { get; set; }
        public string estadohallazgo { get; set; }
        public string titulohallazgo { get; set; }
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
        public Nullable<decimal> orden { get; set; }
        public Nullable<int> isuso { get; set; }
        public string uuid { get; set; }
    
        public virtual cedulacorrespondencia cedulacorrespondencia { get; set; }
        public virtual cedula cedula { get; set; }
        public virtual detallecedula detallecedula { get; set; }
        public virtual encargo encargo { get; set; }
    }
}
