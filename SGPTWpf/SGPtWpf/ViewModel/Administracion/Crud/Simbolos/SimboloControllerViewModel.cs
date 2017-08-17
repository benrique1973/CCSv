using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System;
using SGPTWpf.Messages.Simbolos;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.ViewModel.Crud.Simbolo
{
    public sealed  class SimboloControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private int maxDescripcion = 1;

        private DialogCoordinator dlg;
        private static int controlVentana = 0;
        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : ListaEntidad
        public const string listaEntidadPropertyName = "ListaEntidad";


        private ObservableCollection<SimboloModelo> _ListaEntidad;

        public ObservableCollection<SimboloModelo> ListaEntidad
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

        private int _id = 0;

        public int id
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
        #region ViewModel Property : idtd
        #region Primary key


        #region ViewModel Property : SelectedOpcion


        //Representa la opcion que se dara para elegir
        public const string SelectedOpcionPropertyName = "SelectedOpcion";

        private TipoDescriptorModelo _SelectedOpcion;

        public TipoDescriptorModelo SelectedOpcion
        {
            get
            {
                return _SelectedOpcion;
            }

            set
            {
                if (_SelectedOpcion == value) return;

                _SelectedOpcion = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(SelectedOpcionPropertyName);
            }
        }

        #endregion

        #region idtd

        public const string idtdPropertyName = "idtd";

        private int _idtd = 0;

        public int idtd
        {
            get
            {
                return _idtd;
            }

            set
            {
                if (_idtd == value)
                {
                    return;
                }

                _idtd = value;
                RaisePropertyChanged(idtdPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion
        #region Descripcion de descriptor

        public const string nombreDescriptorPropertyName = "nombreDescriptor";

        private string _nombreDescriptor = string.Empty;

        public string nombreDescriptor
        {
            get
            {
                return _nombreDescriptor;
            }

            set
            {
                if (_nombreDescriptor == value)
                {
                    return;
                }

                _nombreDescriptor = value;
                RaisePropertyChanged(nombreDescriptorPropertyName);
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

        private SimboloModelo _currentEntidad;

        public SimboloModelo currentEntidad
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

        #region ListaOpcion

        public const string listaOpcionPropertyName = "listaOpcion";


        private ObservableCollection<TipoDescriptorModelo> _listaOpcion;

        public ObservableCollection<TipoDescriptorModelo> listaOpcion
        {
            get
            {
                return _listaOpcion;
            }
            set
            {
                if (_listaOpcion == value) return;

                _listaOpcion = value;

                RaisePropertyChanged(listaOpcionPropertyName);
            }
        }

        #endregion

        #region ViewModel Commands

        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<SimboloModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public SimboloControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();

            //Suscribiendo el mensaje
            listaOpcion = new ObservableCollection<TipoDescriptorModelo>(TipoDescriptorModelo.GetAll());
            Messenger.Default.Register<CatalogoMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            Messenger.Default.Register<SimboloElementoMensaje>(this, (controlElementoMensaje) => ControlElementoMensaje(controlElementoMensaje));
            Messenger.Default.Register<SimboloListaMensaje>(this, (controlListaMensaje) => ControlListaMensaje(controlListaMensaje));
            RegisterCommands();
            dlg = new DialogCoordinator();
            controlVentana = controlVentana + 1;
            if (controlVentana > 1)
            {
                Ok();//Hay una abierta se cierra la ventana creada

            }

        }

        private void ControlElementoMensaje(SimboloElementoMensaje controlElementoMensaje)
        {
            currentEntidad = controlElementoMensaje.elementoMensaje; ;
            if (!((currentEntidad == null) || ((currentEntidad.idtd == null) || (currentEntidad.idtd == 0))))
            {

                SelectedOpcion = listaOpcion.Single(i => i.id == currentEntidad.idtd);

            }
            else
            { 
                SelectedOpcion = null;
            }
        }
        private void ControlListaMensaje(SimboloListaMensaje controlListaMensaje)
        {
            ListaEntidad = controlListaMensaje.listaMensaje;
        }
        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            enviarMensaje();
            controlVentana = controlVentana - 1;
            CloseWindow();
        }

        private void Ok()
        {
            enviarMensaje();
            controlVentana = controlVentana - 1;
            CloseWindow();
        }

        private void Salir()
        {
            if (!((controlVentana == 0)))
            {
                if (controlVentana < 0)
                {
                    controlVentana = 0;
                }
                else
                {
                    enviarMensaje();
                    controlVentana = controlVentana - 1;
                    CloseWindow();
                }
            }

        }

        public async void Guardar()
        {
            if (!(SimboloModelo.FindTexto(currentEntidad.descripcion)))
        {
            if (!string.IsNullOrEmpty(currentEntidad.descripcion))
            {
                if (currentEntidad.descripcion.Length <= maxDescripcion)
                {
                    currentEntidad.idtd = SelectedOpcion.id;
                    currentEntidad.tiposdescriptor = SelectedOpcion.descripcion;
                    if ((currentEntidad.id == 0))
                    {
                        //currentEntidad.id = SimboloModelo.IdAsignar();
                        if (SimboloModelo.Insert(currentEntidad, true))
                        {
                                var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                ListaEntidad.Add(currentEntidad);
                            enviarMensaje();
                            controlVentana = controlVentana - 1;
                            CloseWindow();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        }
                        //}
                    }
                    //ListaEntidad.Add(CurrentEntidad);
                    else
                    {
                        //Caso de actualizacion
                        {
                            {
                                if (SimboloModelo.UpdateModelo(currentEntidad, true))
                                {
                                        var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                        controller.SetIndeterminate();
                                        await TaskEx.Delay(1000);
                                        await controller.CloseAsync();
                                        enviarMensaje();
                                    controlVentana = controlVentana - 1;
                                    CloseWindow();
                                }
                                else
                                {
                                    await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Maximo de 1
                    //Mensaje en caso de indice mayor
                    await dlg.ShowMessageAsync(this, "La descripcion excede el maximo permitido", "");
                }

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
            }
                //Nuevo();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción", "");
            }
        }

        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        private bool ControlVentanaMensaje(CatalogoMensaje controlVentanaMensaje)
        {
            if (controlVentanaMensaje.mensaje == 0)
            {
                //Nuevo();
                return true;
            }
            else
            {
                CloseWindow();
                return false;
            }
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            VentanaViewMensaje cierre = new VentanaViewMensaje();
            cierre.mensaje = -1;
            Messenger.Default.Send<VentanaViewMensaje>(cierre);

        }
        #endregion

        #region Metodos de apoyo

       public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidad == null && SelectedOpcion == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripcion) &&
                           (currentEntidad.descripcion.Length <= maxDescripcion) &&
                           ((SelectedOpcion != null));
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
            SelectionChangedCommand = new RelayCommand<SimboloModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion
    }
}




