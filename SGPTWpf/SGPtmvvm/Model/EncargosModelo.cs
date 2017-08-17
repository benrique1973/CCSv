using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class EncargosModelo
    {
        public int correlativo { get; set; }
        public int idencargo { get; set; }
        public string idnitcliente { get; set; }
        public string razonsocialcliente { get; set; }
        public int idta { get; set; }
        public string nombreTa { get; set; }
        public int idsc { get; set; }
        public int idindice { get; set; }
        public string fechacreadoencargo { get; set; }
        public bool tipoclienteencargo { get; set; }
        public string etapaencargo { get; set; }
        public string nombreetapaencargo { get; set; }
        public decimal costoejecucionencargo { get; set; }
        public decimal honorariosencargo { get; set; }
        public string fechainiperauditencargo { get; set; }
        public string añoencargo { get; set; }
        public string fechafinperauditencargo { get; set; }
        public string estadoencargo { get; set; }
    }
}
