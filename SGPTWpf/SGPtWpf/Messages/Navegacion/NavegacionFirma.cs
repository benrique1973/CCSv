using SGPTmvvm.ViewModel;
using SGPTWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTWpf.Messages.Navegacion
{
    class NavegacionFirma
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public ViewModeloBase Contexto { get; set; }
        public int opcionMenu { get; set; }
        //public FirmaInformeTiempoviewModel Contexto2 { get; set; }
        public tabconenedorFirmaConfiguracionViewModel Contexto1 { get; set; }
    }
}
