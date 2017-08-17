using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.TipoProcedimiento;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.TipoProcedimiento
{
    public sealed class TipoProcedimientoViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int ventanas = 0;
        private static bool activarVentanaConsulta = true;

        #region edicionActivada

        private bool _edicionActivada;
        private bool edicionActivada
        {
            get { return _edicionActivada; }
            set { _edicionActivada = value; }
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

        public const string ListaPropertyName = "Lista";

        private ObservableCollection<TipoProcedimientoModelo> _Lista;

        public ObservableCollection<TipoProcedimientoModelo> Lista
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

        #region ViewModel Properties : listaTipoHerramienta

        public const string listaTipoHerramientaPropertyName = "listaTipoHerramienta";

        private ObservableCollection<TipoHerramientaModelo> _listaTipoHerramienta;

        public ObservableCollection<TipoHerramientaModelo> listaTipoHerramienta
        {
            get
            {
                return _listaTipoHerramienta;
            }

            set
            {
                if (_listaTipoHerramienta == value) return;

                _listaTipoHerramienta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaTipoHerramientaPropertyName);
            }
        }

        #endregion

        #region Descripcion 

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
        public int idtprocedimiento
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

        private TipoProcedimientoModelo _currentEntidad;

        public TipoProcedimientoModelo currentEntidad
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

        #region Tipo Herramienta Seleccionada

        #region ViewModel Property : selectedTipoHerramienta

        public const string selectedTipoHerramientaPropertyName = "selectedTipoHerramienta";

        private TipoProcedimientoModelo _selectedTipoHerramienta;

        public TipoProcedimientoModelo selectedTipoHerramienta
        {
            get
            {
                return _selectedTipoHerramienta;
            }

            set
            {
                if (_selectedTipoHerramienta == value) return;

                _selectedTipoHerramienta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedTipoHerramientaPropertyName);
            }
        }

        #endregion

        #endregion

        #region  Key de tipo de herramienta

        public const string idThTprocedimientoPropertyName = "idThTprocedimiento";

        private int _idThTprocedimiento = 0;

        public int idThTprocedimientotprocedimiento
        {
            get
            {
                return _idThTprocedimiento;
            }

            set
            {
                if (_idThTprocedimiento == value)
                {
                    return;
                }

                _idThTprocedimiento = value;
                RaisePropertyChanged(idThTprocedimientoPropertyName);
            }
        }

        #endregion

        #region descripcionIdThTp 

        public const string descripcionIdThTpPropertyName = "descripcionIdThTp";

        private string _descripcionIdThTp = string.Empty;


        public string descripcionIdThTp
        {
            get
            {
                return _descripcionIdThTp;
            }

            set
            {
                if (_descripcionIdThTp == value)
                {
                    return;
                }

                _descripcionIdThTp = value;
                RaisePropertyChanged(descripcionIdThTpPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand<TipoProcedimientoModelo> SelectionChangedCommand { get; set; }

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

        public TipoProcedimientoViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionHijo = "";
            _tokenRecepcionPadre = "Tipos de procedimiento programas" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            _edicionActivada = false;//La edicion queda inactivada
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));

            Lista = new ObservableCollection<TipoProcedimientoModelo>(TipoProcedimientoModelo.GetAll());
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
            TipoProcedimientoElementoMensaje elemento = new TipoProcedimientoElementoMensaje();
            if ((ventanas == 0))
            {
                elemento.elementoMensaje = currentEntidad;
            }
            else
            {
                elemento.elementoMensaje = null;
            }
            Messenger.Default.Send<TipoProcedimientoElementoMensaje>(elemento);
        }
        public void enviarLista()
        {
            //Se crea el mensaje
            TipoProcedimientoListaMensaje listaEnviada = new TipoProcedimientoListaMensaje();
            if ((ventanas == 0))
            {
                listaEnviada.listaMensaje = Lista;
            }
            else
            {
                listaEnviada.listaMensaje = null;
            }
            Messenger.Default.Send<TipoProcedimientoListaMensaje>(listaEnviada);
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
            ActualizarLista();
            comando = 0;

        }
        #endregion

        #region Implementacion de comandos
        public async void Nuevo()
        {
            if (edicionActivada)
            {
                if (ventanas == 0)
                {

                    MainModel.TypeName = "TipoProcedimientoCrearView";
                    currentEntidad = new TipoProcedimientoModelo();
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
            else
            {
                await dlg.ShowMessageAsync(this, "Para este catálogo solo se permite la consulta ", "");
            }
        }

        public async void Editar()
        {
            if (edicionActivada)
            {
                if (!(currentEntidad == null))
            {
                if (ventanas == 0)
                {

                    MainModel.TypeName = "TipoProcedimientoEditarView";
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
            else
            {
                await dlg.ShowMessageAsync(this, "Para este catálogo solo se permite la consulta ", "");
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
                        MainModel.TypeName = "TipoProcedimientoConsultarView";
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
                        MainModel.TypeName = "TipoProcedimientoConsultarView";
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
            if (edicionActivada)
            {
                if (!(currentEntidad == null))
            {
                if (ventanas == 0)
                {
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (TipoProcedimientoModelo.DeleteBorradoLogico(currentEntidad.id, true))
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
            else
            {
                await dlg.ShowMessageAsync(this, "Para este catálogo solo se permite la consulta ", "");
            }
        }

        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.id == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion);
        }

        #region Verificaciones


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
            SelectionChangedCommand = new RelayCommand<TipoProcedimientoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }
        private void ActualizarLista()
        {
            try
            {
                if (Lista == null)
                {
                    Lista = new ObservableCollection<TipoProcedimientoModelo>(TipoProcedimientoModelo.GetAll());
                }
                else
                {
                    Lista.Clear();
                    Lista = new ObservableCollection<TipoProcedimientoModelo>(TipoProcedimientoModelo.GetAll());
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                }
            }

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
                Lista = new ObservableCollection<TipoProcedimientoModelo>(TipoProcedimientoModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    Lista = new ObservableCollection<TipoProcedimientoModelo>();
                }
            }
        }


        #endregion
    }
}


