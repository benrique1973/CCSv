using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using SGPTWpf.Messages.TipoElementoIndice;
using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;

namespace SGPTWpf.ViewModel.Crud.TipoElementoIndice
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class TipoElementoIndiceControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private int maxDescripcion = 50;
        private DialogCoordinator dlg;
        private static int controlVentana = 0;

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }

        #endregion

        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : ListaEntidad
        /// <summary>
        /// The <see cref="ListaEntidad" /> property's name.
        /// </summary>
        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<TipoElementoIndiceModelo> _ListaEntidad;

        public ObservableCollection<TipoElementoIndiceModelo> ListaEntidad
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

        //***********************************
        /// <summary>
        /// The <see cref="descripcion" /> property's name.
        /// </summary>
        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

        /// <summary>
        /// Sets and gets the nombremc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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

        /// <summary>
        /// The <see cref="id" /> property's name.
        /// </summary>
        public const string idPropertyName = "id";

        private int _id = 0;

        /// <summary>
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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


        #region Imagen

        public const string imagenPropertyName = "imagen";

        private byte[] _imagen = null;

        public byte[] imagen
        {
            get
            {
                return _imagen;
            }

            set
            {
                if (_imagen == value)
                {
                    return;
                }

                _imagen = value;
                RaisePropertyChanged("AsignarImagen");
                RaisePropertyChanged(imagenPropertyName);
            }
        }

        #endregion

        #region ImagenInicial

        public bool AsignarImagen
        {
            get {
                currentEntidad.imagen = imagen;
                return (!(this.imagen == null) ); }
        }



        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="estado" /> property's name.
        /// </summary>
        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        /// <summary>
        /// Sets and gets the estadomc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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

        /// <summary>
        /// The <see cref="currentEntidad" /> property's name.
        /// </summary>
        public const string currentEntidadPropertyName = "currentEntidad";

        private TipoElementoIndiceModelo _currentEntidad;

        public TipoElementoIndiceModelo currentEntidad
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
        public RelayCommand<TipoElementoIndiceModelo> SelectionChangedCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        

        #endregion

        //************************************************************

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores


        public TipoElementoIndiceControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionVista = "datosTipoElementoVista";
            //Suscribiendo el mensaje
            Messenger.Default.Register<CatalogoMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            Messenger.Default.Register<TipoElementoIndiceElementoMensaje>(this, (controlElementoMensaje) => ControlElementoMensaje(controlElementoMensaje));
            Messenger.Default.Register<TipoElementoIndiceListaMensaje>(this, (controlListaMensaje) => ControlListaMensaje(controlListaMensaje));
            Messenger.Default.Register<bool>(this, tokenRecepcionVista,(controlErrorMensaje) => ControlErrorMensaje(controlErrorMensaje));
            Errors = 0;
            RegisterCommands();
            dlg = new DialogCoordinator();
            controlVentana = controlVentana + 1;
            if (controlVentana > 1)
            {
                Ok();//Hay una abierta se cierra la ventana creada

            }
        }

        private async void ControlErrorMensaje(bool controlErrorMensaje)
        {
            await dlg.ShowMessageAsync(this, "El tamaño del archivo debe ser menor a 128Kb", "Seleccionar otra imagen");
        }

        private void ControlElementoMensaje(TipoElementoIndiceElementoMensaje controlElementoMensaje)
        {
            currentEntidad = controlElementoMensaje.elementoMensaje;
            if (!((currentEntidad.imagen == null)))
            {
                imagen = currentEntidad.imagen;

            }
            else
            {
                imagen = null;
            }
        }

        private void ControlListaMensaje(TipoElementoIndiceListaMensaje controlListaMensaje)
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
            Messenger.Default.Unregister<bool>(this, tokenRecepcionVista);

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
            if ((TipoElementoIndiceModelo.FindTexto(currentEntidad.descripcion))==0)
        {
            if (!string.IsNullOrEmpty(currentEntidad.descripcion))
            {

                if (currentEntidad.descripcion.Length <= maxDescripcion)
                {
                    if ((currentEntidad.id == 0))
                    {
                        //currentEntidad.id = TipoElementoIndiceModelo.IdAsignar();
                        //if (!TipoElementoIndiceModelo.FindClaseCuentaPK(currentEntidad.idtei))
                        //{
                        currentEntidad.imagen = imagen;
                        if (TipoElementoIndiceModelo.Insert(currentEntidad, true))
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
                    //ListaEntidad.Add(currentEntidad);
                }
                else
                {
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

        public async void Modificar()
        {
            if ((TipoElementoIndiceModelo.FindTexto(currentEntidad.descripcion))==1)
            {
                if (!string.IsNullOrEmpty(currentEntidad.descripcion))
                {

                    if (currentEntidad.descripcion.Length <= maxDescripcion)
                    {
                        if ((currentEntidad.id != 0))
                        {
                            //Caso de actualizacion
                            {
                                {
                                    currentEntidad.imagen = imagen;
                                    if (TipoElementoIndiceModelo.UpdateModelo(currentEntidad, true))
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

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripcion) &&
                           (currentEntidad.descripcion.Length <= maxDescripcion)&&
                           (!(imagen==null));
                return evaluar;
            }
        }

        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {

            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<TipoElementoIndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion

        #region Imagenes

        #endregion
    }
    }
