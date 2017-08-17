using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.Messages.Actividad;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.Actividad
{
    public sealed class ActividadControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static ActividadControllerViewModel actividadControllerViewModel;

        private int maxDescripcion = 200;
        private int maxLongitudIndice = 10;
        private DialogCoordinator dlg;
        private static bool nuevo = false;
        private bool salida = false;

        #region tokenEnvioController

        private string _tokenEnvioController;
        private string tokenEnvioController
        {
            get { return _tokenEnvioController; }
            set { _tokenEnvioController = value; }
        }

        #endregion

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : ListaEntidad
        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<ActividadModelo> _ListaEntidad;

        public ObservableCollection<ActividadModelo> ListaEntidad
        {
            get
            {
                return _ListaEntidad;
            }
            set
            {
                if (_ListaEntidad == value) return;

                _ListaEntidad = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }
        #endregion

        #region Propiedades : Descripcion

        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

        public string descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                if (_descripcion == value)
                {
                    return;
                }
                _descripcion = value;
                RaisePropertyChanged(descripcionPropertyName);
            }
        }

        #endregion

        #region Primary key

        public const string idPropertyName = "id";

        private string _id = string.Empty;

        public string id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(idPropertyName);
            }
        }

        #endregion

        #region Sistema

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        public bool sistema
        {
            get
            {
                return _sistema;
            }

            set
            {
                if (_sistema == value)
                {
                    return;
                }

                _sistema = value;
                RaisePropertyChanged(sistemaPropertyName);
            }
        }

        #endregion

        #region Estado

        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        public string estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(estadoPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private ActividadModelo _currentEntidad;

        public ActividadModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                _currentEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        //public RelayCommand WindowClosingCommand { get; set; }

        public RelayCommand<ActividadModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods


        public static ActividadControllerViewModel SharedViewModel()
        {
            return actividadControllerViewModel ?? (actividadControllerViewModel = new ActividadControllerViewModel());
        }

        #region Constructores

        public ActividadControllerViewModel()
        {
            enviarMensajeInhabilitar();
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenEnvioController="ActividadesController";
            _tokenRecepcionPadre = "ActividadesPadre";
            _dialogCoordinator = new DialogCoordinator();

            //Suscribiendo el mensaje
            ListaEntidad = new ObservableCollection<ActividadModelo>(ActividadModelo.GetAll());
            Messenger.Default.Register<ActividadElementoMensaje>(this, (controlElementoMensaje) => ControlElementoMensaje(controlElementoMensaje));
            RegisterCommands();
            dlg = new DialogCoordinator();
        }

        private void ControlElementoMensaje(ActividadElementoMensaje controlElementoMensaje)
        {
            currentEntidad = controlElementoMensaje.elementoMensaje;
            if (currentEntidad.id == null)
            {
                nuevo = true;
            }
            else
            {
                nuevo = false;
            }
            Messenger.Default.Unregister<ActividadElementoMensaje>(this);
            Mouse.OverrideCursor = null;
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            salida = true;
            CloseWindow();
        }

        private void Ok()
        {
            salida = true;
            CloseWindow();
        }

        private void Salir()
        {
            if (!salida)
            {
                CloseWindow();
            }
            enviarMensaje();
            //enviarMensajeHabilitar();
        }


        public async void Guardar()
        {
            //Si la descripción es igual no debe crear ni actualizar
            if (!(ActividadModelo.FindTexto(currentEntidad.descripcion)))
            { 
                //Caso de nuevo registro
                if (nuevo)
                {
                    if (!(ActividadModelo.FindPK(currentEntidad.id)))
                    {
                        if (ActividadModelo.Insert(currentEntidad, true))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            salida = true;
                            CloseWindow();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "El código fue registrado en el pasado", "");
                    }
                }
                else
                {
                    if (!(ActividadModelo.FindPK(currentEntidad.id, true)))
                    {
                        if (ActividadModelo.UpdateModelo(currentEntidad, true))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            salida = true;
                            CloseWindow();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "El código fue registrado en el pasado", "");
                    }
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción", "");
            }
        }
        #endregion

        #region Mensajes

        //Procesando el mensaje recibido

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            //Para transferir el control
            Messenger.Default.Send(true, tokenEnvioController);

        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        #endregion

        #region Metodos de apoyo

        public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                    evaluar = !string.IsNullOrEmpty(currentEntidad.id) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion)
                   && (currentEntidad.id.Length <= maxLongitudIndice)
                   && (currentEntidad.descripcion.Length <= maxDescripcion);
                return evaluar;
            }
        }

        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            //WindowClosingCommand = new RelayCommand(enviarMensaje);
            SelectionChangedCommand = new RelayCommand<ActividadModelo>(entidad =>
            {
                if (currentEntidad == null) return;
                currentEntidad = currentEntidad;
            });
        }

        #endregion
    }

}


