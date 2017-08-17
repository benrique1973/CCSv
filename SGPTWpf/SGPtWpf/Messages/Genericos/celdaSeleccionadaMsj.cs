using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    class celdaSeleccionadaMsj:Messenger
    {
        public int? fila { get; set; }

        public int? columna { get; set; }

        public DetalleCedulaModelo registro { get; set; }
    }
}
