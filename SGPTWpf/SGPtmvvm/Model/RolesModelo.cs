using System;

namespace SGPTWpf.SGPtmvvm.Model
{
    public class RolesModelo
    {
        public int correlativo { get; set; }
        public int idrol { get; set; }
        public string nombrerol { get; set; }
        public bool sistemarol { get; set; }
        public string estadorol { get; set; }
        public string descripcionrol { get; set; }
        public Nullable<int> basadoenrol { get; set; }
    }
}
