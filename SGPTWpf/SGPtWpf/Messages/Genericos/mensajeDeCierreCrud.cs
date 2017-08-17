using GalaSoft.MvvmLight.Messaging;

namespace SGPTWpf.Messages.Genericos
{
    class mensajeDeCierreCrud: Messenger
    {//Sirve para que un  controlador avise que ha terminado un proceso
     //El número permite  procesar únicamente si coindice el valor
     //Utilizado cuando se lanzan pantallas adicionales
        public int numeroProcesoCrud { get; set; }
    }
}
