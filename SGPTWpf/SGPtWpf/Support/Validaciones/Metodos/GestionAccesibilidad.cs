using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Metodos
{
    public static class GestionAccesibilidad
    {
        //Gestionara los de comandos de framework
         public static void iniciarComandoPrincipal()
            {
            Mouse.OverrideCursor = Cursors.Wait;
            enviarMensajeInHabilitar();
            }
        public static void iniciarComandoLocal()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            //enviarMensajeInHabilitar();
        }

        //Conclusion de comando de principal
        public static void finalizarComandoPrincipal()
        {
            Mouse.OverrideCursor = null;
            //enviarMensajeHabilitar();
        }

        //Finalizacion de comando local a la pantalla principal
        public static void finalizarComandoLocal()
        {
            Mouse.OverrideCursor = null;
            enviarMensajeHabilitar();
        }


        public static void enviarMensajeInHabilitar()
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(habilitar);
        }
        public static void enviarMensajeHabilitar()
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(habilitar);
        }

    }
}
