using CapaDatos;

namespace SGPTmvvm.Model
{
    public class InformeActividadesModelo
    {
        public int correlativo { get; set; }
        public int idia { get; set; }
        public int idusuario { get; set; }
        public string Inicialesusuario { get; set; }
        public string nombreCompletoUsuario { get; set; }
        public string usuarioNick { get; set; }
        public int usuidusuario { get; set; }
        public string fechainicialia { get; set; }
        public string fechafinalia { get; set; }
        public decimal totalhorasia { get; set; }
        public decimal tiempodias { get; set; }
        public string observacionesia { get; set; }
        public string aprobacionia { get; set; }

        public bool aprobado { get; set; }
        public bool rechazado { get; set; }
        //private bool _aprobado;
        //public bool aprobado
        //{
        //    get { return _aprobado; }
        //    set 
        //    {
        //        _aprobado = value;
        //        if (value==true)
        //        {
        //            rechazado = false; 
        //        }
        //    }
        //}

        //private bool _rechazado;
        //public bool rechazado
        //{
        //    get { return _rechazado; }
        //    set 
        //    { 
        //        _rechazado = value;

        //        if (value==true)
        //        {
        //            aprobado = false; 
        //        }
        //    }
        //}

        public string fechaaprobacionia { get; set; }
        public string estadoia { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
