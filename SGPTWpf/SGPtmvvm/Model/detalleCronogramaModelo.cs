
using System;
namespace SGPTmvvm.Model
{
    public class detalleCronogramaModelo
    {
        public int correlativo { get; set; }
        public int iddc { get; set; }
        public int idpa { get; set; }
        public string nombreProcesoAuditoria { get; set; } //Agregado
        public int idvisita { get; set; }
        public string nombreVisita { get; set; } //Agregado
        public int idcronograma { get; set; }
        public string actividaddc { get; set; }
        public DateTime fechainicialdc { get; set; }
        public DateTime fechafinaldc   { get; set; }
        public decimal horasplaneadasdc { get; set; }
        public string  personalPorEtapa { get; set; } //Agregado
        public int cantidadPersonasAsignadasPorEtapa { get; set; }//Agregado
        public string iDpersonalPorEtapa { get; set; }//Agregado
        public decimal valorUs          { get; set; }
        public string fechacreadodc { get; set; }
        public string estadodc { get; set; }
        public int idusuario { get; set; }
    }
}
