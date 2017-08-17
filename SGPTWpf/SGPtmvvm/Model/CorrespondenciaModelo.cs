using CapaDatos;
namespace SGPTmvvm.Model
{
    public class CorrespondenciaModelo
    {
        public int correlativo { get; set; }
        public int idcorrespondencia { get; set; }

        public int idpapeles { get; set; }

        public int idusuario { get; set; }

        public int idct { get; set; }

        public string idnitcliente { get; set; }

        public string razonsocialcliente { get; set; }

        public int usuidusuario { get; set; }

        public string numerocorrespondencia { get; set; }

        public string asuntocorrespondencia { get; set; }

        public string firmacorrespondencia { get; set; }

        public string auditorfirmacarta { get; set; }

        public string fecharecepcioncorrespondencia { get; set; }

        public string comentariocorrespondencia { get; set; }

        public string aprobacioncorrespondencia { get; set; }

        public string fechacreadocorrespondencia { get; set; }

        public string fechaaprobacioncorrespondenci { get; set; }

        public byte[] archivocorrespondencia { get; set; }
        public string nombrefilecorrespondencia { get; set; }
        public int idcontactofirmacorrespondencia { get; set; }

        public string tienePDF { get; set; }


        public bool salientecorrespondencia { get; set; }
        public string QueCorrespondencia { get; set; }
        public string TipoCorrespondencia { get; set; }

        public string estadocorrespondencia { get; set; }

        public string estadocorrespondencia2 { get; set; }


        public virtual correspondenciatipos correspondenciatipos { get; set; }

        public virtual usuario usuario { get; set; }
    }
}
