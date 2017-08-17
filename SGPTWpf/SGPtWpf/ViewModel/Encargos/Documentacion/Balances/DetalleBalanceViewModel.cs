using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using System.Windows.Input;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Linq;
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances
{

    public sealed class DetalleBalanceViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #region opcionMenu

        private int _opcionMenu;
        private int opcionMenu
        {
            get { return _opcionMenu; }
            set { _opcionMenu = value; }
        }

        #endregion

        #region FuenteLlamada

        private int _FuenteLlamada;
        private int FuenteLlamada
        {
            get { return _FuenteLlamada; }
            set { _FuenteLlamada = value; }
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

        private static int comando = 0;

        private DialogCoordinator dlg;


        #endregion

        #region tokenEnvioDatosAHijo

        private string _tokenEnvioDatosAHijo;
        private string tokenEnvioDatosAHijo
        {
            get { return _tokenEnvioDatosAHijo; }
            set { _tokenEnvioDatosAHijo = value; }
        }

        #endregion

        #region tokenEnvioDatosAMenu

        private string _tokenEnvioDatosAMenu;
        private string tokenEnvioDatosAMenu
        {
            get { return _tokenEnvioDatosAMenu; }
            set { _tokenEnvioDatosAMenu = value; }
        }

        #endregion


        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<BalanceModelo> _SelectedItems;

        public ObservableCollection<BalanceModelo> SelectedItems
        {
            get
            {
                return _SelectedItems;
            }
            set
            {
                if (_SelectedItems == value) return;

                _SelectedItems = value;

                RaisePropertyChanged(SelectedItemsPropertyName);
            }
        }

        #endregion

        //http://stackoverflow.com/questions/14918602/isselected-binding-in-wpf-datagrid

        #region ViewModel Properties : IsSelected

        public const string IsSelectedPropertyName = "IsSelected";

        private bool _IsSelected;

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }

            set
            {
                if (_IsSelected == value)
                {
                    return;
                }

                _IsSelected = value;
                RaisePropertyChanged(IsSelectedPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentBalance Catalogo Modelo

        public const string currentBalancePropertyName = "currentBalance";

        private BalanceModelo _currentBalance;

        public BalanceModelo currentBalance
        {
            get
            {
                return _currentBalance;
            }

            set
            {
                if (_currentBalance == value) return;

                _currentBalance = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentBalancePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        private UsuarioModelo _currentUsuario;

        public UsuarioModelo currentUsuario
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

        #region ViewModel Property : currentEncargo

        public const string currentEncargoPropertyName = "currentEncargo";

        private EncargoModelo _currentEncargo;

        public EncargoModelo currentEncargo
        {
            get
            {
                return _currentEncargo;
            }

            set
            {
                if (_currentEncargo == value) return;

                _currentEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEncargoPropertyName);
            }
        }

        #endregion

        #region Sistema contable

        #region ViewModel Property : currentSistemaContable

        public const string currentSistemaContablePropertyName = "currentSistemaContable";

        private SistemaContableModelo _currentSistemaContable;

        public SistemaContableModelo currentSistemaContable
        {
            get
            {
                return _currentSistemaContable;
            }

            set
            {
                if (_currentSistemaContable == value) return;

                _currentSistemaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentSistemaContablePropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Properties publicas

        #region encabezadoPrograma

        public const string encabezadoProgramaPropertyName = "encabezadoPrograma";

        private string _encabezadoPrograma = string.Empty;

        public string encabezadoPrograma
        {
            get
            {
                return _encabezadoPrograma;
            }

            set
            {
                if (_encabezadoPrograma == value)
                {
                    return;
                }

                _encabezadoPrograma = value;
                RaisePropertyChanged(encabezadoProgramaPropertyName);
            }
        }

        #endregion

        #region visibilidadTipoPrograma

        public const string visibilidadTipoProgramaPropertyName = "visibilidadTipoPrograma";

        private Visibility _visibilidadTipoPrograma = Visibility.Visible;

        public Visibility visibilidadTipoPrograma
        {
            get
            {
                return _visibilidadTipoPrograma;
            }

            set
            {
                if (_visibilidadTipoPrograma == value)
                {
                    return;
                }

                _visibilidadTipoPrograma = value;
                RaisePropertyChanged(visibilidadTipoProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaVistas

        public const string listaVistasPropertyName = "listaVistas";

        private ObservableCollection<menuBalanceDetalle> _listaVistas;

        public ObservableCollection<menuBalanceDetalle> listaVistas
        {
            get
            {
                return _listaVistas;
            }

            set
            {
                if (_listaVistas == value) return;

                _listaVistas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaVistasPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<DetalleBalanceModelo> _lista;

        public ObservableCollection<DetalleBalanceModelo> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetalles

        public const string listaDetallesPropertyName = "listaDetalles";

        private ObservableCollection<BitacoraModelo> _listaDetalles;

        public ObservableCollection<BitacoraModelo> listaDetalles
        {
            get
            {
                return _listaDetalles;
            }

            set
            {
                if (_listaDetalles == value) return;

                _listaDetalles = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDetallesPropertyName);
            }
        }

        #endregion

        #region Entidades

        #region ViewModel Property : currentEntidad Detalle Balance

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleBalanceModelo _currentEntidad;

        public DetalleBalanceModelo currentEntidad
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

        #region descripcioncb Clase balance

        public const string descripcioncbPropertyName = "descripcioncb";

        private string _descripcioncb = string.Empty;

        public string descripcioncb
        {
            get
            {
                return _descripcioncb;
            }

            set
            {
                if (_descripcioncb == value)
                {
                    return;
                }

                _descripcioncb = value;
                RaisePropertyChanged(descripcioncbPropertyName);
            }
        }


        #endregion

        #region codigoBuscado Clase detalleBalance

        public const string codigoBuscadoPropertyName = "codigoBuscado";

        private string _codigoBuscado = string.Empty;

        public string codigoBuscado
        {
            get
            {
                return _codigoBuscado;
            }

            set
            {
                if (_codigoBuscado == value)
                {
                    return;
                }

                _codigoBuscado = value;
                RaisePropertyChanged(codigoBuscadoPropertyName);
            }
        }


        #endregion

        
        #endregion

        #region Propiedades Catalogo Contale

        #region idCorrelativo

        public const string idCorrelativoPropertyName = "idCorrelativo";

        private int _idCorrelativo = 0;

        public int idCorrelativo
        {
            get
            {
                return _idCorrelativo;
            }

            set
            {
                if (_idCorrelativo == value)
                {
                    return;
                }

                _idCorrelativo = value;
                RaisePropertyChanged(idCorrelativoPropertyName);
            }
        }

        #endregion

        #region idcc

        public const string idccPropertyName = "idcc";

        private int _idcc = 0;

        public int idcc
        {
            get
            {
                return _idcc;
            }

            set
            {
                if (_idcc == value)
                {
                    return;
                }

                _idcc = value;
                RaisePropertyChanged(idccPropertyName);
            }
        }

        #endregion

        #region idelementos

        public const string idelementosPropertyName = "idelementos";

        private int _idelementos = 0;

        public int idelementos
        {
            get
            {
                return _idelementos;
            }

            set
            {
                if (_idelementos == value)
                {
                    return;
                }

                _idelementos = value;
                RaisePropertyChanged(idelementosPropertyName);
            }
        }

        #endregion

        #region idsc

        public const string idscPropertyName = "idsc";

        private int _idsc = 0;

        public int idsc
        {
            get
            {
                return _idsc;
            }

            set
            {
                if (_idsc == value)
                {
                    return;
                }

                _idsc = value;
                RaisePropertyChanged(idscPropertyName);
            }
        }

        #endregion


        #region catidcc

        public const string catidccPropertyName = "catidcc";

        private int _catidcc = 0;

        public int catidcc
        {
            get
            {
                return _catidcc;
            }

            set
            {
                if (_catidcc == value)
                {
                    return;
                }

                _catidcc = value;
                RaisePropertyChanged(catidccPropertyName);
            }
        }

        #endregion

        #region idccuentas

        public const string idccuentasPropertyName = "idccuentas";

        private int _idccuentas = 0;

        public int idccuentas
        {
            get
            {
                return _idccuentas;
            }

            set
            {
                if (_idccuentas == value)
                {
                    return;
                }

                _idccuentas = value;
                RaisePropertyChanged(idccuentasPropertyName);
            }
        }

        #endregion


        #region codigocc

        public const string usuarioModificoPropertyName = "codigocc";

        private string _usuarioModifico = string.Empty;

        public string codigocc
        {
            get
            {
                return _usuarioModifico;
            }

            set
            {
                if (_usuarioModifico == value)
                {
                    return;
                }

                _usuarioModifico = value;
                RaisePropertyChanged(usuarioModificoPropertyName);
            }
        }

        #endregion

        #region codigoContablePadre
        public string codigoContablePadre
        {
            get
            {
                return _usuarioModifico;
            }

            set
            {
                if (_usuarioModifico == value)
                {
                    return;
                }

                _usuarioModifico = value;
                RaisePropertyChanged(usuarioModificoPropertyName);
            }
        }

        #endregion

        #region descripcioncc

        public const string nombreHerramientaPropertyName = "descripcioncc";

        private string _nombreHerramienta = string.Empty;

        public string descripcioncc
        {
            get
            {
                return _nombreHerramienta;
            }

            set
            {
                if (_nombreHerramienta == value)
                {
                    return;
                }

                _nombreHerramienta = value;
                RaisePropertyChanged(nombreHerramientaPropertyName);
            }
        }

        #endregion

        #region tiposaldocc

        public const string autorizadoPorHerramientaPropertyName = "tiposaldocc";

        private string _autorizadoPorHerramienta = string.Empty;

        public string tiposaldocc
        {
            get
            {
                return _autorizadoPorHerramienta;
            }

            set
            {
                if (_autorizadoPorHerramienta == value)
                {
                    return;
                }

                _autorizadoPorHerramienta = value;
                RaisePropertyChanged(autorizadoPorHerramientaPropertyName);
            }
        }

        #endregion

        #region fechacreacioncc

        public const string fechacreadoherramientaPropertyName = "fechacreacioncc";

        private DateTime _fechacreadoherramienta = DateTime.Now;

        public DateTime fechacreacioncc
        {
            get
            {
                return _fechacreadoherramienta;
            }

            set
            {
                if (_fechacreadoherramienta == value)
                {
                    return;
                }

                _fechacreadoherramienta = value;
                RaisePropertyChanged(fechacreadoherramientaPropertyName);
            }
        }

        #endregion


        #region ordencc

        public const string ordenccPropertyName = "ordencc";

        private decimal _ordencc = 0;

        public decimal ordencc
        {
            get
            {
                return _ordencc;
            }

            set
            {
                if (_ordencc == value)
                {
                    return;
                }

                _ordencc = value;
                RaisePropertyChanged(ordenccPropertyName);
            }
        }

        #endregion

        #region estadocc

        public const string estadoccPropertyName = "estadocc";

        private string _estadocc = string.Empty;

        public string estadocc
        {
            get
            {
                return _estadocc;
            }

            set
            {
                if (_estadocc == value)
                {
                    return;
                }

                _estadocc = value;
                RaisePropertyChanged(estadoccPropertyName);
            }
        }

        #endregion


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

        #region Properties : cursorWindow

        public const string cursorWindowPropertyName = "cursorWindow";

        private Cursor _cursorWindow;

        public Cursor cursorWindow
        {
            get
            {
                return _cursorWindow;
            }

            set
            {
                if (_cursorWindow == value)
                {
                    return;
                }

                _cursorWindow = value;
                RaisePropertyChanged(cursorWindowPropertyName);
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
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<DetalleBalanceModelo> SelectionChangedCommand { get; set; }
        public RelayCommand irMenuPadreCommand { get; set; }
        
        #endregion

        #region EDBalanceMainModel

        private MainModel _mainModel = null;

        public MainModel EDBalanceMainModel
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

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private bool _activarCaptura;

        public bool activarCaptura
        {
            get
            {
                return _activarCaptura;
            }

            set
            {
                if (_activarCaptura == value)
                {
                    return;
                }

                _activarCaptura = value;
                RaisePropertyChanged(activarCapturaPropertyName);
            }
        }

        public int NumberOfItemsSelected { get; private set; }

        #endregion

        #region ViewModel Public Methods

        #region Constructores


        public DetalleBalanceViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar

            _accesibilidadWindow = false;
            _IsSelected = false;
            //_tokenRecepcionPadre = "PlanificacionDatos";//Permite captar los mensajes del  menú planificacion
            _tokenRecepcionPadre = "datosEDBalances";//Permite captar los mensajes del  view model BalancesViewModel
            _tokenEnvioDatosAHijo = "datosPadreDetalleBalances";  //Para control de los datos que  remite programas a sub-ventanas
            _tokenRecepcionHijo = "datosControllerDetalleBalances"; 
            _tokenEnvioDatosAMenu = "DetalleBalanceRegreso";//Para regresar al menu anterior.
            _cursorWindow = Cursors.Hand;
            _opcionMenu = 0;
            _FuenteLlamada = 0;
            _descripcioncb = string.Empty;
            Messenger.Default.Register<BalanceMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlRecepcionDatos(datosMsj));

            //Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));

            //currentEntidad = new BalanceModelo(opcionTipoHerramientaprograma, opcionTipoPrograma,0);
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            RegisterCommands();
            comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<DetalleBalanceModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            EDBalanceMainModel = new MainModel();

        }

        private void ControlCambioLista(bool recepcionDatos)
        {
            if (recepcionDatos)
            {
                BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    guardarlista();
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    //Nada se deja la lista actualizada;
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }

        private void ControlRecepcionDatos(BalanceMsj msj)
        {
            currentEncargo = msj.encargoModelo;//Encargo en uso actual
            currentUsuario = msj.usuarioModelo;
            currentSistemaContable = msj.sistemaContableModelo;
            currentBalance = msj.balanceModelo;
            opcionMenu = msj.opcionMenuCrud;
            FuenteLlamada = msj.fuenteLlamado;
            actualizarLista();
            //No se desuscribe porque continua existiendo
            //Messenger.Default.Unregister<BalanceMsj>(this, tokenRecepcionPadre);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
            Messenger.Default.Unregister<BalanceMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<DetalleBalanceModelo>(DetalleBalanceModelo.GetAllByIdBC(currentBalance.idbalance));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e.Message, "");

                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }


        public async void guardarlista()
        {
            try
            {
                if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                {

                    foreach (DetalleBalanceModelo item in lista)
                    {
                        if (item.guardadoBase == false)
                        {
                            if (DetalleBalanceModelo.UpdateModelo(item, true))
                            {
                                item.guardadoBase = true;//Se actualizo el registro
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar un registro", "");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Mensaje de error
            }
        }

        #endregion

        #region Envio mensajes


        //Caso de nuevo registro 
        public void enviarMensaje()
        {
            //Se crea el mensaje
            DetalleBalanceMsj elemento = new DetalleBalanceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.balanceModelo = currentBalance;//Para el caso de  edicion de programas
            elemento.detalleBalancemodelo = currentEntidad;
            elemento.listaDetalleBalanceModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 0; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }


        //public void enviarMensajeCargarBalance()
        //{
        //    //Se crea el mensaje
        //    ClientesContactosMensajeModal elemento = new ClientesContactosMensajeModal();
        //    elemento.UsuarioValidado = UsuarioModelo.GetRegistroByIdUsarioCapaDatos(currentUsuario.idUsuario);
        //    elemento.currentCliente = ClienteModelo.GetRegistroByNitCapaDatos(currentEncargo.idnitcliente);
        //    elemento.SistemaContableAModificar = SistemaContableModelo.GetRegistroByIdEncargoCapaDatos(currentEncargo.idencargo);
        //    Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        //}

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EDBalanceMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 2:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    //caso de vista de programa
                    break;
                case 5://Programa vista
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    accesibilidadWindow = true;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 7:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                case 8:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                default:
                    break;
            }
            comando = 0;
            currentEntidad = null;
            finComando();
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            //Para guardar lo que esta en la  pantalla
            //No se utiliza debido a que no existe edicion
            //ControlCambioLista(true);
            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad = new DetalleBalanceModelo(currentBalance);
            currentEntidad.balanceModelo = currentBalance;
            EDBalanceMainModel.TypeName = "DetalleBalanceModeloCrearview";
            #endregion

            activarCaptura = true;
            #endregion
            enviarMensaje();
        }

        public async void Editar()
        {
            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 2;
                    EDBalanceMainModel.TypeName = "DetalleBalanceModeloEditarView";
                    currentEntidad.usuarioModelo = currentUsuario;
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para editar", "");
            }
        }
        public async void Consultar()
        {
            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 3;
                    currentEntidad.usuarioModelo = currentUsuario;
                    EDBalanceMainModel.TypeName = "DetalleBalanceModeloConsultarView";
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para consultar", "");
            }
        }

        public async void Borrar()
        {
            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (!(currentEntidad == null))
            {
                currentEntidad.usuarioModelo = currentUsuario;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComandoBorrar();
                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //caso de un registro
                        if (DetalleBalanceModelo.Delete(currentEntidad.iddb, true))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borro el registro ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new DetalleBalanceModelo();
                            finComandoBorrar();
                        }
                        else
                        {
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                        }

                    }
                    else
                    {
                        //caso de muchos registros
                        if (DetalleBalanceModelo.Delete(new ObservableCollection<DetalleBalanceModelo>(lista.Where(x => x.IsSelected))))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new DetalleBalanceModelo();
                            finComandoBorrar();
                        }
                        else
                        {
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                        }
                    }

                }
                else
                {
                    finComandoBorrar();
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "", MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            finComandoBorrar();
        }


        public async void Borrarlógico()
        {

            if (!(currentEntidad == null))
            {
                accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                currentEntidad.usuarioModelo = currentUsuario;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //caso de un registro
                        if (DetalleBalanceModelo.DeleteBorradoLogico(currentEntidad.iddb, true))
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                            actualizarLista();
                            currentEntidad = new DetalleBalanceModelo();
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                            accesibilidadWindow = true;
                        }

                    }
                    else
                    {
                        //caso de muchos registros
                        if (DetalleBalanceModelo.DeleteBorradoLogico(new ObservableCollection<DetalleBalanceModelo>(lista.Where(x => x.IsSelected))))
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Se borraron  los registros ", "");
                            actualizarLista();
                            currentEntidad = new DetalleBalanceModelo();
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                            accesibilidadWindow = true;
                        }
                    }

                }
                else
                {
                    Mouse.OverrideCursor = null;
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "", MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            accesibilidadWindow = true;
            Mouse.OverrideCursor = null;
        }


        #endregion

        #region Verificaciones

        public void Actualizar(ObservableCollection<DetalleBalanceModelo> listaEntidad)
        {
            lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        public bool CanCommand()
        {
            if (!(currentEntidad == null))
            {
                try
                {
                    return currentEntidad.iddb!= 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            DoubleClickCommand = new RelayCommand(Consultar);
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanCommand);
            SelectionChangedCommand = new RelayCommand<DetalleBalanceModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                //listaDetalles = entidad.listaBitacora;
            });
            irMenuPadreCommand = new RelayCommand(irPrincipal);
    }

        private void irPrincipal()
        {
            iniciarComando();
            //Mandar el mensaje al principal que domina la pantalla
            Messenger.Default.Send(opcionMenu, tokenEnvioDatosAMenu);
        }

        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }


        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private async void VistaPrograma()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                enviarMensajeInhabilitar();//Para evitar que el usuario  tome otras acciones
                comando = 5;
                accesibilidadWindow = false;
                EDBalanceMainModel.TypeName = "BalanceModeloVerProgramaView";
                //enviarElemento(currentEntidad);
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                                 //enviarMensaje();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }


        private void XImprimir()
        {
            //throw new NotImplementedException();
        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }


        private void iniciarComandoBorrar()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            enviarMensajeInhabilitar();
            accesibilidadWindow = false;
        }

        private void finComandoBorrar()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            enviarMensajeHabilitar();
            accesibilidadWindow = true;
        }
        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            //Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));

            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);

            //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
        }


        #endregion Fin de comando

    }
}