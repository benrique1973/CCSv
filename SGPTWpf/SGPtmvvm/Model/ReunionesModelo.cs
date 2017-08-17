namespace SGPTmvvm.Model
{
    public class ReunionesModelo
    {
        public int idreunion { get; set; }
        public string idnitcliente { get; set; }
        public string nombrecliente { get; set; }
        public string fechareunion { get; set; }
        public decimal tiempoduracionreunion { get; set; }
        public string participanteexternoreunion { get; set; }
        public string participantesinternoreunion { get; set; }
        public string asuntoreunion { get; set; }
        public string conclusionesreunion { get; set; }
        public string aprobacionreunion { get; set; }
        public string estadoreunion { get; set; }
        public string estadoreunion2 { get; set; }
    }
}
