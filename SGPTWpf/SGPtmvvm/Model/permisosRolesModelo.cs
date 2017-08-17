namespace SGPTWpf.SGPtmvvm.Model
{
    public class permisosRolesModelo
    {
        public int idpru { get; set; }
        public int idusuario { get; set; }
        public int idrol { get; set; }
        public string Menu { get; set; }
        public string SubMenu { get; set; }
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

    }
}
