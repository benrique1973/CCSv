using SGPTmvvm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Mensajes
{
    public class ClientesEncargosCronogramaMensajeModal
    {
        //public TipoComando Accion { get; set; }
        public List<AsignacionesModelo> ListadoPersonalAsignado { get; set; }
        public List<AsignacionesModelo> ListadoPersonalSeleccionado { get; set; }
        public int Etapa { get; set; }
        public string nombreEtapa { get; set; }
        public int Visita { get; set; }
        public string nombreVisita { get; set; }
        public decimal monto { get; set; }
        public bool HayAgregadosSioNo { get; set; }
        //public ContactosModelo ContactosAmodificar { get; set; }
        //public sistemascontable SistemaContableAModificar { get; set; }
        //public estructurasorganica EstructuraAmodificar { get; set; }
    }
}
