using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class AsignacionesModelo
    {
        public int correlativo { get; set; }
        public int idasignacion { get; set; }
        public int idusuario { get; set; }
        public string nombreCompletoUsuario { get; set; } //agregado
        public int idrol { get; set; } //agregado
        public string rolUsuario { get; set; } //agregado
        public int idencargo { get; set; }
        public string fechacreaasignacion { get; set; }
        public decimal horasplanasignacion { get; set; }
        public decimal HorasQueQuedanPorAsignar { get; set; }
        public decimal horasejecucionasignacion { get; set; }
        public decimal preciohoraasignacion { get; set; }
        public decimal UssPlaneado { get; set; } //agregado
        public decimal UssEjecutado { get; set; } //agregado
        public decimal Indice { get; set; } //agregado
        public string estadoasignacion { get; set; }

        //public virtual usuario usuario { get; set; }
    }

}
