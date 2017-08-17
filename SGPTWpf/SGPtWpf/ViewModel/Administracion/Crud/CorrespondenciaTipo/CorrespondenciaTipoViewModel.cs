using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.CorrespondenciaTipo;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.CorrespondenciaTipo
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed  class CorrespondenciaTipoViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static CorrespondenciaTipoViewModel correspondenciaTipoTipoViewModel;
        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int ventanas = 0;
        private static bool activarVentanaConsulta = true;

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #region tokenRecepcionHijo

        private string _tokenRecepcionHijo;
        private string tokenRecepcionHijo
        {
            get { return _tokenRecepcionHijo; }
            set { _tokenRecepcionHijo = value; }
        }

        #endregion


        #region ViewModel Properties : accesibilidadWindow

        public const string accesibilidadWindowPropertyName = "accesibilidadWindow";

        private bool _accesibilidadWindow;

        public bool accesibilidadWindow
        {
            get
            {
                return _accesibilidadWindow;
            }

            set
            {
                if (_accesibilidadWindow == value)
                {
                    return;
                }

                _accesibilidadWindow = value;
                RaisePropertyChanged(accesibilidadWindowPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : usuarioModelo usuario

        public const string usuarioModeloPropertyName = "usuarioModelo";

        private UsuarioModelo _usuarioModelo;

        public UsuarioModelo usuarioModelo
        {
            get
            {
                return _usuarioModelo;
            }

            set
            {
                if (_usuarioModelo == value) return;

                _usuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(usuarioModeloPropertyName);
            }
        }


        #endregion

        #endregion

        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista
        /// <summary>
        /// The <see cref="Lista" /> property's name.
        /// </summary>
        public const string ListaPropertyName = "Lista";

        private ObservableCollection<CorrespondenciaTipoModelo> _Lista;

        public ObservableCollection<CorrespondenciaTipoModelo> Lista
        {
            get
            {
                return _Lista;
            }

            set
            {
                if (_Lista == value) return;

                _Lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPropertyName);
            }
        }

        #endregion

        #region Descripcion de cuentas

        /// <summary>
        /// The <see cref="descripcionct" /> property's name.
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

        #region  Primary key

        /// <summary>
        /// The <see cref="id" /> property's name.
        /// </summary>
        public const string idPropertyName = "id";

        private int _id = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idct
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

        /// <summary>
        /// The <see cref="sistema" /> property's name.
        /// </summary>

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        /// <summary>
        /// Sets and gets the sistemamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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

        private CorrespondenciaTipoModelo _currentEntidad;

        public CorrespondenciaTipoModelo currentEntidad
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


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand<CorrespondenciaTipoModelo> SelectionChangedCommand { get; set; }

        #endregion
        #region MainModel

        private MainModel _mainModel = null;

        public MainModel MainModel
        {
            get
            {
                return _mainModel;
            }

            set
            {
                _mainModel = value;
            }
        }
        #endregion

        #region ViewModel Public Methods

        #region Constructores

        public static CorrespondenciaTipoViewModel SharedViewModel()
        {
            
            return correspondenciaTipoTipoViewModel ?? (correspondenciaTipoTipoViewModel = new CorrespondenciaTipoViewModel());
        }

        public CorrespondenciaTipoViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionHijo = "";
            _tokenRecepcionPadre = "Tipo de correspondencia" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));

            Lista = new ObservableCollection<CorrespondenciaTipoModelo>(CorrespondenciaTipoModelo.GetAll());
            RegisterCommands();
            MainModel = new MainModel();
            //Nuevo();
        }

        public CorrespondenciaTipoViewModel(DialogCoordinator dlgIn)
        {
            Lista = new ObservableCollection<CorrespondenciaTipoModelo>(CorrespondenciaTipoModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<VentanaViewMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            MainModel = new MainModel();
            //Nuevo();
        }

        #endregion

        #region Envio mensajes
        public void enviarMensaje()
        {
            //Se crea el mensaje
            VentanaViewMensaje apertura = new VentanaViewMensaje();
            apertura.mensaje = ventanas;//Guardo el mensaje
            Messenger.Default.Send<VentanaViewMensaje>(apertura);
            ventanas = ventanas + 1;
            enviarMensajeInhabilitar();
        }
        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            if ((ventanas == 0))
            {
                inhabilitar.mensaje = true;
            }
            else
            {
                inhabilitar.mensaje = false;
            }
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarElemento()
        {
            //Se crea el mensaje
            CorrespondenciaTipoElementoMensaje elemento = new CorrespondenciaTipoElementoMensaje();
            if ((ventanas == 0))
            {
                elemento.elementoMensaje = currentEntidad;
            }
            else
            {
                elemento.elementoMensaje = null;
            }
            Messenger.Default.Send<CorrespondenciaTipoElementoMensaje>(elemento);
        }
        public void enviarLista()
        {
            //Se crea el mensaje
            CorrespondenciaTipoListaMensaje listaEnviada = new CorrespondenciaTipoListaMensaje();
            if ((ventanas == 0))
            {
                listaEnviada.listaMensaje = Lista;
            }
            else
            {
                listaEnviada.listaMensaje = null;
            }
            Messenger.Default.Send<CorrespondenciaTipoListaMensaje>(listaEnviada);
        }
        #endregion

        #region Receptor de mensajes
        private void ControlVentanaMensaje(VentanaViewMensaje controlVentanaCrearMensaje)
        {
            //Para controlar la ventana abierta
            ventanas = ventanas + controlVentanaCrearMensaje.mensaje;
            if (ventanas < 0)
            { ventanas = 0; }//Para mantener el valor en cero y no en menos
            enviarMensajeInhabilitar();
            //TypeName = null;
            MainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    currentEntidad = null;
                    break;
                case 2:
                    break;
                case 3:
                    activarVentanaConsulta = true;
                    break;
                default:
                    break;
            }
            comando = 0;

        }
        #endregion

        #region Implementacion de comandos
        public async void Nuevo()
        {
            if (ventanas == 0)
            {

                MainModel.TypeName = "CorrespondenciaTipoCrearView";
                currentEntidad = new CorrespondenciaTipoModelo();
                enviarElemento();
                enviarLista();
                enviarMensaje();
                comando = 1;
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
            }
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                if (ventanas == 0)
                {

                    MainModel.TypeName = "CorrespondenciaTipoEditarView";
                    enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                    enviarLista();
                    enviarMensaje();
                    comando = 2;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
        }
        public async void Consultar()
        {
            if (!(currentEntidad == null))
            {
                if (activarVentanaConsulta)
                {
                    if (ventanas == 0)
                    {
                        MainModel.TypeName = "CorrespondenciaTipoConsultarView";
                        enviarElemento();
                        enviarMensaje();
                        comando = 3;
                        activarVentanaConsulta = false;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                    }
                }
                else
                {
                    //La ventana de consulta esta activa
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }
        public async void ConsultarDobleClick()
        {
            if (!(currentEntidad == null))
            {
                if (activarVentanaConsulta)
                {
                    if (ventanas == 0)
                    {
                        MainModel.TypeName = "CorrespondenciaTipoConsultarView";
                        enviarElemento();
                        enviarMensaje();
                        comando = 3;
                        activarVentanaConsulta = false;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                    }
                }
                else
                {
                    //La ventana de consulta esta activa
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }
        public async void Borrar()
        {
            if (!(currentEntidad == null))
            {
                if (ventanas == 0)
                {
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (CorrespondenciaTipoModelo.DeleteBorradoLogico(currentEntidad.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        Lista.Remove(currentEntidad);
                        currentEntidad = null;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                }
                else
                {

                    await dlg.ShowMessageAsync(this, "No es posible usar la función, tiene ventanas abiertas", "");
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }

        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.id == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<CorrespondenciaTipoModelo> listaEntidad)
        {
            Lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        #endregion
        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanDelete);
            BorrarCommand = new RelayCommand(Borrar, CanDelete);
            ConsultarCommand = new RelayCommand(Consultar, CanDelete);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            SelectionChangedCommand = new RelayCommand<CorrespondenciaTipoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion


        #region Lanzado de  comando

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            accesibilidadWindow = false;
        }

        private void ControlVentanaMensaje(int controllerProgramaViewMensaje)
        {
            throw new NotImplementedException();
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            accesibilidadWindow = true;
        }

        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        private void ControlCatalogoDatos(UsuarioMensaje catalogoDatos)
        {
            usuarioModelo = catalogoDatos.usuarioModeloMensaje;
            actualizarLista();
            accesibilidadWindow = true;
            inicializacionTerminada();
        }
        #endregion Fin de comando

        #region actualizaciones

        private void actualizarLista()
        {
            //borrarTemporales();//Para borrar cualquier  archivo creado
            try
            {
                Lista = new ObservableCollection<CorrespondenciaTipoModelo>(CorrespondenciaTipoModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    Lista = new ObservableCollection<CorrespondenciaTipoModelo>();
                }
            }
        }


        #endregion
    }
}
