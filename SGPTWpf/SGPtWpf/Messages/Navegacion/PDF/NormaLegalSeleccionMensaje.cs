using SGPTWpf.Model;
using SGPTWpf.Model.Modelo;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Navegacion.PDF
{
    class NormaLegalSeleccionMensaje
    {
        public int? idln { get; set; }
        public UsuarioModelo usuarioValidadoMensaje { get; set; }

        public ObservableCollection<NormativaModelo> listaMensaje { get; set; }
    }
}
