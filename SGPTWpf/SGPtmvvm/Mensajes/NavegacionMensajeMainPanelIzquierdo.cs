using System;
using System.Windows.Controls;

namespace SGPTmvvm.Mensajes
{
    public class NavegacionMensajeMainPanelIzquierdo
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl view { get; set; }
    }
}
