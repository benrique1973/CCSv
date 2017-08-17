using SGPTWpf.Model.Modelo;
using System.Collections.ObjectModel;

namespace SGPTWpf.Messages.Administracion.NormaLegal
{
    class CatalogoNormaLegalElementoMensaje
    {
        public NormativaModelo elementoMensaje { get; set; }

        public ObservableCollection<NormativaModelo> listaNormativa { get; set; }
    }
}
