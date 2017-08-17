namespace SGPTmvvm.Model
{
    /// <summary>
    /// Esta clase sirve para poder enviar los encabezados y el cuerpo para generar los reportes de portadas de las carpetas Permanente, corriente, etc. 
    /// </summary>
    public class EncabezadosPiesReportesPortadasCarpetas
    {
        //Encabezado 
        public byte[] logofirma { get; set; }
        public string razonsocialfirma { get; set; }
        public string encabezadopantalla { get; set; }
        public string descripciontipoauditoria { get; set; }
        public string razonsocialcliente { get; set; }
        public string fechainiperauditencargo { get; set; }
        public string fechafinperauditencargo { get; set; }
    }
}
