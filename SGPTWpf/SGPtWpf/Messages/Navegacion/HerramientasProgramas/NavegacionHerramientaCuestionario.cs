using SGPTWpf.ViewModel;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Messages.Navegacion.HerramientasProgramas
{
    class NavegacionHerramientaCuestionario
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public ViewModeloBase Contexto { get; set; }
    }
}
