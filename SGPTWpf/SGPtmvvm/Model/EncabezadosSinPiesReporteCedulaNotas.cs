//using System;
//using System.Collections.Generic;
//using System.Linq;
namespace SGPTmvvm.Model
{
    /// <summary>
    /// Esta clase sirve para poder enviar los encabezados y pies de pagina para generar los reportes de Cedula de hallazgos. 
    /// </summary>
    public class EncabezadosSinPiesReporteCedulaNotas
    {
        //Encabezado 
        public byte[] logofirma { get; set; }
        public string referencia { get; set; }
        public string razonsocialfirma { get; set; }
        public string encabezadopantalla { get; set; }
        public string descripciontipoauditoria { get; set; }
        public string razonsocialcliente { get; set; }
        public string usuarioejecuto { get; set; }
        public string fechaejecuto { get; set; }
        public string fechainiperauditencargo { get; set; }
        public string fechafinperauditencargo { get; set; }
        public string usuariosuperviso { get; set; }
        public string fechasuperviso { get; set; }
        public string usuarioaprobo { get; set; }
        public string fechaaprobo { get; set; }

    }
}
