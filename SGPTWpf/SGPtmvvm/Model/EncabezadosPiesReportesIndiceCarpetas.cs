
namespace SGPTmvvm.Model
{
    /// <summary>
    /// Esta clase sirve para poder enviar los encabezados y pies de pagina para generar los reportes de programas y cuestionarios. 
    /// Como poseen tres secciones de cuerpos [objetivos, alcances y detalles] estos seran enviado por aparte en listas del tipo que correspondan.
    /// </summary>
    public class EncabezadosPiesReportesIndiceCarpetas
    {
        //Encabezado 
        public byte[] logofirma { get; set; }
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



        //pie de pagina.
        public int itemsObligatorios { get; set; }
        public int itemsObligatoriosReferenciados { get; set; }
        public decimal IndiceItemsObligatorios { get; set; }
        public int itemsVoluntarios { get; set; }
        public int itemsVoluntariosReferenciados { get; set; }
        public decimal IndiceItemsVoluntarios { get; set; }

    }
}
