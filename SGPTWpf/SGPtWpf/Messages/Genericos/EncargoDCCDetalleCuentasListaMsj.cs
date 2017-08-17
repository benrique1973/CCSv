using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Collections.ObjectModel;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class EncargoDCCDetalleCuentasListaMsj : Messenger
    {
        public ObservableCollection<CatalogoCuentasModelo> listaElementos { get; set; }
    }
}
