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
using SGPTmvvm.Mensajes;
using System.Linq;
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPtmvvm.Mensajes;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances
{

    public sealed class BalancesViewModel: ViewModeloBase
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

            #region tokenRecepcionHijo

            private string _tokenRecepcionHijo;
            private string tokenRecepcionHijo
            {
                get { return _tokenRecepcionHijo; }
                set { _tokenRecepcionHijo = value; }
            }

        #endregion

            #region tokenRecepcionSubMenu
        private string _tokenRecepcionSubMenu;
        private string tokenRecepcionSubMenu
        {
            get { return _tokenRecepcionSubMenu; }
            set { _tokenRecepcionSubMenu = value; }
        }
        #endregion

            private static int comando = 0;

            private DialogCoordinator dlg;

            #region tokenRecepcionCierrePreView

            private string _tokenRecepcionCierrePreView;
            private string tokenRecepcionCierrePreView
            {
                get { return _tokenRecepcionCierrePreView; }
                set { _tokenRecepcionCierrePreView = value; }
            }

            #endregion

            #endregion

            #region tokenEnvioDatosAHijo

            private string _tokenEnvioDatosAHijo;
            private string tokenEnvioDatosAHijo
            {
                get { return _tokenEnvioDatosAHijo; }
                set { _tokenEnvioDatosAHijo = value; }
            }

            #endregion

            #region tokenEnvioDatosCarga

            private string _tokenEnvioDatosCarga;
            private string tokenEnvioDatosCarga
            {
                get { return _tokenEnvioDatosCarga; }
                set { _tokenEnvioDatosCarga = value; }
            }

            #endregion
            #region tokenRecepcionDatosCarga

            private string _tokenRecepcionDatosCarga;
            private string tokenRecepcionDatosCarga
            {
                get { return _tokenRecepcionDatosCarga; }
                set { _tokenRecepcionDatosCarga = value; }
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

            private ObservableCollection<BalanceModelo> _lista;

            public ObservableCollection<BalanceModelo> lista
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

            #region ViewModel Property : currentEntidad Catalogo Modelo

            public const string currentEntidadPropertyName = "currentEntidad";

                private BalanceModelo _currentEntidad;

                public BalanceModelo currentEntidad
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
            public RelayCommand cmdCargarCatalogo { get; set; }

            public RelayCommand ImportarCommand { get; set; }
            public RelayCommand NuevoCommand { get; set; }
            public RelayCommand EditarCommand { get; set; }
            public RelayCommand BorrarCommand { get; set; }
            public RelayCommand ConsultarCommand { get; set; }
            public RelayCommand copiarCommand { get; set; }
            public RelayCommand DoubleClickCommand { get; set; }
            public RelayCommand XImprimirCommand { get; set; }
            public RelayCommand VistaProgramaCommand { get; set; }
            public RelayCommand<BalanceModelo> SelectionChangedCommand { get; set; }
            public RelayCommand detalleCommand { get; set; }


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


            public BalancesViewModel()
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
                _tokenRecepcionPadre = "Balances" + "Documentacion";//Permite captar los mensajes del  menú planificacion

                _tokenRecepcionCierrePreView = "CierreEDBalances";//Sirve tanto para los programas en vista previa como para el controllador;
                _tokenEnvioDatosAHijo = "datosEDBalances";//Para control de los datos que  remite programas a sub-ventanas
                _tokenRecepcionHijo = "datosControllerBalances";
                _cursorWindow = Cursors.Hand;
                _tokenRecepcionSubMenu = "DetalleBalanceRegreso";
                Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));

                //currentEntidad = new BalanceModelo(opcionTipoHerramientaprograma, opcionTipoPrograma,0);
                currentEncargo = null;
                currentEntidad = null;
                currentSistemaContable = null;
                RegisterCommands();
                comando = 0;

                dlg = new DialogCoordinator();

                lista = new ObservableCollection<BalanceModelo>();//Lista vacia no se conoce el encargo y el cliente
                listaDetalles = new ObservableCollection<BitacoraModelo>();
                EDBalanceMainModel = new MainModel();
                listaVistas = new ObservableCollection<menuBalanceDetalle>(menuBalanceDetalle.GetAll());

                //Carga
                _tokenEnvioDatosCarga= "ImportarArchivos";
                _tokenRecepcionDatosCarga= "RecepcionCargaBalance";
                //
                Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
                Messenger.Default.Register<int>(this, tokenRecepcionDatosCarga, (detalleTerminado) => ControlCarga(detalleTerminado));
        }

        private void ControlCarga(int detalleTerminado)
        {
            switch (detalleTerminado)
            {
                case 0:
                    //await dlg.ShowMessageAsync(this, "No se hizo la carga ", "");
                    //var controllerCancelar = await dlg.ShowProgressAsync(this, "No se pudo realizar la importacion ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    //controllerCancelar.SetIndeterminate();
                    //await TaskEx.Delay(1000);
                    //await controllerCancelar.CloseAsync();
                    break;
                case -1:
                    //await dlg.ShowMessageAsync(this, "No se pudo realizar la carga ", "");
                    //var controller = await dlg.ShowProgressAsync(this, "No se pudo realizar la importacion ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    //controller.SetIndeterminate();
                    //await TaskEx.Delay(1000);
                    //await controller.CloseAsync();
                    break;
                case 1:
                    //var controlleréxito = await dlg.ShowProgressAsync(this, "Importacion realizada con éxito ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    //controlleréxito.SetIndeterminate();
                    //await TaskEx.Delay(1000);
                    //await controlleréxito.CloseAsync();
                    actualizarLista();
                    break;
                case 2:
                    ////await dlg.ShowMessageAsync(this, "Canceló la carga ", "");
                    // var controllerCancelarUsuario = await dlg.ShowProgressAsync(this, "No se pudo realizar la importacion ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    // controllerCancelarUsuario.SetIndeterminate();
                    // await TaskEx.Delay(1000);
                    // await controllerCancelarUsuario.CloseAsync();
                    break;
            }
            EDBalanceMainModel.TypeName = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionDatosCarga);
            enviarMensajeHabilitar();
            finComando();
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

            private void ControlRecepcionDatos(EncargosDatosMsj msj)
            {
                usuarioModelo = msj.usuarioModelo;
                currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
                currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
                actualizarLista();
                accesibilidadWindow = true;
                inicializacionTerminada();
                Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);

        }


        private async void actualizarLista()
        {
            guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAll(currentEncargo));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    await dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e.Message, "");

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

                        foreach (BalanceModelo item in lista)
                        {
                            if (item.guardadoBase == false)
                            {
                                if (BalanceModelo.UpdateModelo(item, true))
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
                BalanceMsj elemento = new BalanceMsj();
                elemento.encargoModelo = currentEncargo;
                elemento.usuarioModelo = usuarioModelo;
                elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
                elemento.balanceModelo = currentEntidad;//Para el caso de  edicion de programas
                elemento.listaBalanceModelo = lista;
                elemento.opcionMenuCrud = comando;
                elemento.fuenteLlamado = 0; //no se utilizaa
                Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
            }


        public void enviarMensajeCargarBalance()
        {
            //Se crea el mensaje
            CargarArchivosMensajeModal elemento = new CargarArchivosMensajeModal();
            elemento.usuarioModelo = usuarioModelo;
            elemento.TipoArchivoACargar = TipoArchivoCargar.Balance;
            elemento.currentCliente = ClienteModelo.GetRegistro(currentEncargo.idnitcliente);
            elemento.currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargoCapaDatos(currentEncargo.idencargo);
            elemento.encargoModelo = currentEncargo;
            elemento.TokenAUtilizar = tokenRecepcionDatosCarga;
            Messenger.Default.Send(elemento, tokenEnvioDatosCarga);
        }
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
                        //if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        //{
                        //    actualizarLista();
                        //}

                        //enviarMensajeHabilitar();
                        //controlVentanaCrearMensaje
                        break;
                   case 9://Desplazamiento a ver el detalle del usuario
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
            Messenger.Default.Unregister<int>(this, tokenRecepcionSubMenu);
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
                currentEntidad = new BalanceModelo(currentSistemaContable,usuarioModelo);
                EDBalanceMainModel.TypeName = "BalanceModeloCrearview";
                #endregion

                activarCaptura = true;


                enviarMensaje();
            }
        #endregion
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
                        EDBalanceMainModel.TypeName = "BalanceModeloEditarView";
                        currentEntidad.usuarioModelo = usuarioModelo;
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
                        currentEntidad.usuarioModelo = usuarioModelo;
                        EDBalanceMainModel.TypeName = "BalanceModeloConsultarView";
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
                    currentEntidad.usuarioModelo = usuarioModelo;
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
                            if (BalanceModelo.Delete(currentEntidad.idbalance, true))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borro el registro ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                actualizarLista();
                                currentEntidad = new BalanceModelo();
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
                            if (BalanceModelo.Delete(new ObservableCollection<BalanceModelo>(lista.Where(x => x.IsSelected))))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                actualizarLista();
                                currentEntidad = new BalanceModelo();
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
                    currentEntidad.usuarioModelo = usuarioModelo;
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
                            if (BalanceModelo.DeleteBorradoLogico(currentEntidad.idbalance, currentEntidad))
                            {
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                actualizarLista();
                                currentEntidad = new BalanceModelo();
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
                            if (BalanceModelo.DeleteBorradoLogico(new ObservableCollection<BalanceModelo>(lista.Where(x => x.IsSelected))))
                            {
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "Se borraron  los registros ", "");
                                actualizarLista();
                                currentEntidad = new BalanceModelo();
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

            public bool CanSave()
            {
                return !(currentEntidad.idbalance == 0) &&
                       !string.IsNullOrEmpty(currentEntidad.fechasistemabalance);
            }

            #region Verificaciones

            public void Actualizar(ObservableCollection<BalanceModelo> listaEntidad)
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
                        return currentEntidad.idbalance != 0;
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
                cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
                NuevoCommand = new RelayCommand(Nuevo, null);//ok
                EditarCommand = new RelayCommand(Editar, CanCommand);
                BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
                ConsultarCommand = new RelayCommand(Consultar, CanCommand);
                copiarCommand = new RelayCommand(Importar);
                DoubleClickCommand = new RelayCommand(Consultar);
                SelectionChangedCommand = new RelayCommand<BalanceModelo>(entidad =>
                {
                    if (entidad == null) return;
                    //Verificar la cantidad de  registros seleccionados
                    currentEntidad = entidad;
                    //listaDetalles = entidad.listaBitacora;
                });
            detalleCommand = new RelayCommand(detalleBalance, CanCommand);
            }

        private async void detalleBalance()
        {
            //tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
            //Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
            //cursorWindow = Cursors.Wait;
            //Mandar a  la vista
            //currentEntidad.NavigateExecute();
            //enviarMensajeDatos();

            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 9;
                    //EDBalanceMainModel.TypeName = "BalanceModeloEditarView";
                    currentEntidad.usuarioModelo = usuarioModelo;
                    listaVistas[1].NavigateExecute();
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    listaVistas = new ObservableCollection<menuBalanceDetalle>(menuBalanceDetalle.GetAll());
                    Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro para ver el detalle", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para ver el detalle", "");
            }
        }

        private async void mostrarCantidad(int i)
            {
                await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
            }

        private async void cargarCC()
        {

            iniciarComando();
            Messenger.Default.Register<int>(this, tokenRecepcionDatosCarga, (detalleTerminado) => ControlCarga(detalleTerminado));
            //Verificar que existe un catalogo

            int cantidadCatalogo = CatalogoCuentasModelo.ContarRegistros(currentSistemaContable.idsc);
            if (cantidadCatalogo > 0)
            {
                comando = 8;

                EDBalanceMainModel.TypeName = "BalanceModeloCargarView";
                activarCaptura = true;

                enviarMensajeCargarBalance();
                enviarMensajeInhabilitar();
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "No ha cargado un catalogo", "debe registrar primero el catalogo de cuentas");
            }
        }

        public async void Importar()
            {

                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Cancelar",
                    NegativeButtonText = "Encargos",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "El balance se importará de los encargos anteriores", "Usando los datos de años anteriores",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Negative)
                {
                    iniciarComando();
                    comando = 7;//Importa de los encargos de  años anteriores
                    //Inicializanado el  registro
                    currentEntidad = new BalanceModelo(currentSistemaContable, usuarioModelo);

                    EDBalanceMainModel.TypeName = "BalanceModeloImportarView";
                    enviarMensaje();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Cancelo operación", "");
                }
            }
            private void Buscar()
            {
                throw new NotImplementedException();
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