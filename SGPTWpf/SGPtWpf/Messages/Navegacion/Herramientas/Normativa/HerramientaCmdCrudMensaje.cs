using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Navegacion.Herramientas
{

    class HerramientaCmdCrudMensaje:  Messenger
    {

        public int cmd { set; get; }

        public UsuarioModelo usuarioModelo { set; get; }

        public NormativaModelo normativaModelo { set; get; }

        public ObservableCollection<NormativaModelo> listaNormativaModelo { set; get; }
    }
}
