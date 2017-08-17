using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Plantilla;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Herramientas
{
    class DetallePlantillaCrudMensaje : Messenger
    {
        public PlantillaModelo elementoModelo { get; set; }
        public ObservableCollection<PlantillaModelo> listaElementos { get; set; }
        public int comandoCrud { get; set; }
        public UsuarioModelo usuarioModeloValidado { get; set; }
    }
}
