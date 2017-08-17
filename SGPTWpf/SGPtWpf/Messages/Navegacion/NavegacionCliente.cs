using SGPTmvvm.ViewModel;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Administracion.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTWpf.Messages.Navegacion
{
    class NavegacionCliente
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public ViewModeloBase Contexto { get; set; }

        public int opcionMenu { get; set; }
        public tabconenedorClienteContactosViewModel Contexto1 { get; set; }
        public tabconenedorClienteExpedientesViewModel Contexto2 { get; set; }
        public tabconenedorClienteEncargosViewModel Contexto3 { get; set; }

        public ClientesListadoViewModel ContextoCliList { get; set; }
        //public tabc
    }
}
