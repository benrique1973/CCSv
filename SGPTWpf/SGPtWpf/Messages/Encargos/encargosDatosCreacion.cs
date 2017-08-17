using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Encargos
{
    class encargosDatosCreacion:Messenger

    {
        public SistemaContableModelo sistemaContable { get; set; }
        public ObservableCollection<ElementoModelo> listaElementos { get;set;}

        public EncargoModelo encargoModelo { get; set; }

        public int comando { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }
    }
}
