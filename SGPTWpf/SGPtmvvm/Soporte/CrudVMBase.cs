using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
//using ModeloSGPT.Modelo;
using CapaDatos;

namespace SGPTmvvm.Soporte
{
    public class CrudVMBase : NotificacionUIBase
    {
        public SGPTEntidades db = new SGPTEntidades();
        protected bool esVistaActual = false;
        protected CrudVMBase()
        {
            ObtenerDatos();
            Messenger.Default.Register<ComandoMensaje>(this, (x) => ManejarComando(x));
            Messenger.Default.Register<NavegacionMensaje>(this, (action) => ActualUserControl(action));
        }

        private void ActualUserControl(NavegacionMensaje nm)
        {
            if (this.GetType() == nm.ViewModelType)
            {
                esVistaActual = true;
            }
            else
            {
                esVistaActual = false;
            }
        }
        protected void ManejarComando(ComandoMensaje accion)
        {
            if (esVistaActual)
            {
                switch (accion.Comando)
                {
                    case TipoComando.Insertar:
                        InsertarNuevo();
                        break;
                    case TipoComando.Editar:
                        EditarActual();
                        break;
                    case TipoComando.Eliminar:
                        EliminarActual();
                        break;
                    case TipoComando.Guardar:
                        ConfirmarActualizaciones();
                        break;
                    case TipoComando.Refrescar:
                        RefrescarDatos();
                        break;
                    default:
                        break;
                }
            }
        }
        //private Visibility throbberVisible = Visibility.Visible;
        //public Visibility ThrobberVisible
        //{
        //    get { return throbberVisible; }
        //    set
        //    {
        //        throbberVisible = value;
        //        RaisePropertyChanged();
        //    }
        //}
        private string MensajeError;

        public string ErrorMessage
        {
            get { return MensajeError; }
            set
            {
                MensajeError = value;
                RaisePropertyChanged();
            }
        }

        protected virtual void EditarActual()
        {
        }
        protected virtual void InsertarNuevo()
        {
        }
        protected virtual void ConfirmarActualizaciones()
        {
        }
        protected virtual void EliminarActual()
        {
        }
        protected virtual void RefrescarDatos()
        {
            ObtenerDatos();
            //Messenger.Default.Send<UsuarioMensaje>(new UsuarioMensaje { Mensaje = "Datos Refrescados" });
        }
        protected virtual void ObtenerDatos()
        {
        }

    }

}
