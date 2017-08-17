using GalaSoft.MvvmLight.Messaging;

namespace SGPTWpf.Messages.Genericos
{
    class ArchivoBinario : Messenger
    {
        public byte[] archivoBinario { get; set; }
        public string nombre { get; set; }
        public string extension { get; set; }
    }
}
