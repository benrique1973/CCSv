using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Actividad;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.Actividad
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class ActividadViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static int comando = 0;
        private DialogCoordinator dlg;


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

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        private usuario _currentUsuario;

        public usuario currentUsuario
        {
            get
            {
                return _currentUsuario;
            }

            set
            {
                if (_currentUsuario == value) return;

                _currentUsuario = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentUsuarioPropertyName);
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

        #region ViewModel Properties : lista
        /// <summary>
        /// The <see cref="lista" /> property's name.
        /// </summary>
        public const string ListaPropertyName = "lista";

        private ObservableCollection<ActividadModelo> _Lista;

        public ObservableCollection<ActividadModelo> lista
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
        /// The <see cref="descripcionactividad" /> property's name.
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

        private string _id;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string idcodigoactividad
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


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand XExcellCommand { get; set; }
        public RelayCommand XWordCommand { get; set; }
        public RelayCommand XPdfCommand { get; set; }

        public RelayCommand<ActividadModelo> SelectionChangedCommand { get; set; }

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

        public ActividadViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenRecepcionHijo = "ActividadesController";
            _tokenRecepcionPadre = "Actividades" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));

            _dialogCoordinator = new DialogCoordinator();
            _id = "0";
            lista = new ObservableCollection<ActividadModelo>(ActividadModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            //Messenger.Default.Register<bool>(this,tokenRecepcionHijo, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            MainModel = new MainModel();
            //Nuevo();
        }



        #endregion

        #region Envio mensajes
        public void enviarElemento()
        {
                //Se crea el mensaje
                ActividadElementoMensaje elemento = new ActividadElementoMensaje();
                elemento.elementoMensaje = currentEntidad;
                Messenger.Default.Send<ActividadElementoMensaje>(elemento);
        }
        #endregion

        #region Receptor de mensajes
        private void ControlVentanaMensaje(bool controlVentanaCrearMensaje)
        {
            MainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    currentEntidad = null;
                    actualizarLista();
                    break;
                case 2:
                    actualizarLista();
                    break;
                case 3:

                    break;
                default:
                    break;
            }
            comando = 0;
            finComando();
            enviarMensajeHabilitar();
        }
        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            MainModel.TypeName = "ActividadCrearView";
            currentEntidad = new ActividadModelo();
            enviarElemento();
            comando = 1;
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                    MainModel.TypeName = "ActividadEditarView";
                    enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                    comando = 2;
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
                iniciarComando();
                        MainModel.TypeName = "ActividadConsultarView";
                        enviarElemento();
                        comando = 3;
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
                iniciarComando();
                        MainModel.TypeName = "ActividadConsultarView";
                        enviarElemento();
                        comando = 3;
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
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (ActividadModelo.DeleteBorradoLogico(currentEntidad.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        lista.Remove(currentEntidad);
                        currentEntidad = null;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
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
            return !string.IsNullOrEmpty(currentEntidad.id) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion) &&
                   !(string.IsNullOrWhiteSpace(currentEntidad.id));
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<ActividadModelo> listaEntidad)
        {
            lista = listaEntidad;
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
            SelectionChangedCommand = new RelayCommand<ActividadModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion

        #region actualizaciones

        private void actualizarLista()
        {
            //borrarTemporales();//Para borrar cualquier  archivo creado
            try
            {
                lista = new ObservableCollection<ActividadModelo>(ActividadModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    lista = new ObservableCollection<ActividadModelo>();
                }
            }
        }
        #endregion

        #region Lanzado de  comando

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
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
            Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);
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
        #endregion Fin de comando

    }
}

