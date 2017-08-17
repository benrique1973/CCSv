namespace SGPTmvvm.Model
{
    /// <summary>
    /// Esta clase sirve para poder enviar los encabezados y pies de pagina para generar un reporte de matriz de riesgo. 
    /// El cuerpo sera enviado por aparte en una lista del tipo que corresponda.
    /// </summary>
    public class EncabezadosPiesReporteMatrizRiesgos
    {
        //Encabezado 
        public string urlLogo { get; set; }
        public byte [] logofirma { get; set; }
        public string referencia { get; set; }
        public string razonSocialFirma { get; set; }
        public string encabezadoPantalla { get; set; }
        public string descripcionTipoAuditoria { get; set; }
        public string razonsocialcliente { get; set; }
        public string usuarioEjecuto { get; set; }
        public string fechaejecuto { get; set; }
        public string fechainiperauditencargo { get; set; }
        public string fechafinperauditencargo { get; set; }
        public string usuarioSuperviso { get; set; }
        public string fechasuperviso { get; set; }
        public string usuarioAprobo { get; set; }
        public string fechaaprobo { get; set; }

        //pie de pagina.
        public decimal evaluacioninherentedmrAlto { get; set; }
        public decimal evaluacioncontroldmrAlto { get; set; }
        public decimal evaluacionDetecciondmrAlto { get; set; }
        public decimal evaluacioninherentedmrMedio { get; set; }
        public decimal evaluacioncontroldmrMedio { get; set; }
        public decimal evaluacionDetecciondmrMedio { get; set; }
        public decimal evaluacioninherentedmrBajo { get; set; }
        public decimal evaluacioncontroldmrBajo { get; set; }
        public decimal evaluacionDetecciondmrBajo { get; set; }
    }
}