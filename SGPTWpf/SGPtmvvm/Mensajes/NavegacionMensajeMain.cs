using System;
using System.Windows.Controls;

namespace SGPTmvvm.Mensajes
{
    public class NavegacionMensajeMain
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl view { get; set; }
        public string pestaña { get; set; }
        public string cualPanel { get; set; }
    }
}
