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
using SGPtmvvm.Mensajes;
using CapaDatos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas
{

    public sealed class CatalogoCuentasViewModel : ViewModeloBase
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

        private ObservableCollection<CatalogoCuentasModelo> _SelectedItems;

        public ObservableCollection<CatalogoCuentasModelo> SelectedItems
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


        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<CatalogoCuentasModelo> _lista;

        public ObservableCollection<CatalogoCuentasModelo> lista
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

        #region Entidades

        #region ViewModel Property : currentEntidad Catalogo Modelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private CatalogoCuentasModelo _currentEntidad;

        public CatalogoCuentasModelo currentEntidad
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
        public RelayCommand<CatalogoCuentasModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region EDCatalogoCuentasMainModel

        private MainModel _mainModel = null;

        public MainModel EDCatalogoCuentasMainModel
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


        public CatalogoCuentasViewModel()
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
            _tokenRecepcionPadre = "Catalogo cuentas" + "Documentacion";//Permite captar los mensajes del  menú planificacion

            _tokenRecepcionCierrePreView = "CierreEDCatalogoCuentas";//Sirve tanto para los programas en vista previa como para el controllador;
            _tokenEnvioDatosAHijo = "datosEDCatalogoCuentas";//Para control de los datos que  remite programas a sub-ventanas
            _tokenRecepcionHijo = "datosControllerCatalogoCuentas";
            _cursorWindow = Cursors.Hand;
            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));

            //currentEntidad = new CatalogoCuentasModelo(opcionTipoHerramientaprograma, opcionTipoPrograma,0);
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            RegisterCommands();
            comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<CatalogoCuentasModelo>();//Lista vacia no se conoce el encargo y el cliente
            EDCatalogoCuentasMainModel = new MainModel();
            //Carga
            _tokenEnvioDatosCarga = "ImportarArchivos";
            _tokenRecepcionDatosCarga = "RecepcionCargaCatalogo";
            //
           // Messenger.Default.Register<int>(this, tokenRecepcionDatosCarga, (detalleTerminado) => ControlCarga(detalleTerminado));
        }

        private void ControlCarga(int detalleTerminado)
        {
            switch (detalleTerminado)
            {
                case 0:
                    dlg.ShowMessageAsync(this, "No se hizo la carga ", "");
                    break;
                case -1:
                    dlg.ShowMessageAsync(this, "No se pudo realizar la importacion ", "");
                    break;
                case 1:
                    dlg.ShowMessageAsync(this, "Importacion realizada con éxito ", "");
                    actualizarLista();
                    break;
                case 2:
                    dlg.ShowMessageAsync(this, "Canceló la carga ", "");
                    break;
            }
            EDCatalogoCuentasMainModel.TypeName = null;
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
            currentSistemaContable= SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            actualizarLista();
            accesibilidadWindow = true;
            inicializacionTerminada();
            Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            guardarlista();
            try
            {
                lista = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAll(currentEncargo.idencargo));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e.Message, "");

                }
            }
            //Se manda a la vista actualizada
            enviarlistaDetalleProgramaAVista();
        }


        public void guardarlista()
        {
            try
            {
                if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                {

                    foreach (CatalogoCuentasModelo item in lista)
                    {
                        if (item.guardadoBase == false)
                        {
                            CatalogoCuentasModelo.UpdateModeloReodenar(item);
                            //if (CatalogoCuentasModelo.UpdateModeloOrden(item))
                            //{
                            //    item.guardadoBase = true;//Se actualizo el registro
                            //}
                            //else
                            //{
                            //    await dlg.ShowMessageAsync(this, "No ha sido posible actualizar un registro", "");
                            //}
                            //item.guardadoBase = true;
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
            CatalogoCuentasMsj elemento = new CatalogoCuentasMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.catalogoCuentasModelo = currentEntidad;//Para el caso de  edicion de programas
            elemento.listaCatalogoCuentasModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 0; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        private void enviarlistaDetalleProgramaAVista()
        {
            //Manda la referencia de la vista; Para programas
            EncargoDCCDetalleCuentasListaMsj listaDetalle = new EncargoDCCDetalleCuentasListaMsj();
            listaDetalle.listaElementos = lista;
            Messenger.Default.Send(listaDetalle, tokenEnvioDatosAHijo);
        }

        public void enviarMensajeCargarCatalogo()
        {
            CargarArchivosMensajeModal elemento = new CargarArchivosMensajeModal();
            elemento.usuarioModelo = usuarioModelo;
            elemento.TipoArchivoACargar = TipoArchivoCargar.CatalogoDeCuenta;
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
            EDCatalogoCuentasMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    comando = 0;
                    break;
                case 2:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    comando = 0;
                    break;
                case 3:
                    comando = 0;
                    break;
                case 4:
                    //caso de vista de programa
                    comando = 0;
                    break;
                case 5://Programa vista
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    accesibilidadWindow = true;
                    comando = 0;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    comando = 0;
                    break;
                case 7:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                case 8:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                default:
                    break;
            }
            finComando();
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad = new CatalogoCuentasModelo(currentSistemaContable); 
            EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloCrearview";
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
                    EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloEditarView";
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
                EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloConsultarView";
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

                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Ok",
                        NegativeButtonText = "Cancelar",
                    };

                    MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                    if (result == MessageDialogResult.Affirmative)
                    {
                    iniciarComandoBorrar();
                    bool repetir = false;
                    do
                    {
                        repetir = false;
                        foreach (CatalogoCuentasModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    //Hay hijos
                                    foreach (CatalogoCuentasModelo itemDetalle in lista)
                                    {
                                        if (itemDetalle.catidcc == item.idcc)
                                        {
                                            if (!itemDetalle.IsSelected)
                                            {
                                                //Hay hijos
                                                itemDetalle.IsSelected = true;
                                                repetir = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    while (repetir);
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //caso de un registro
                        var dependientes = DetalleBalanceModelo.GetAllCapaDatosByCodigoContable(currentEntidad.idcc);
                        if (dependientes.Count > 0)
                        {
                            var controller = await dlg.ShowProgressAsync(this, "No puede eliminarse la cuenta  ", "existen registros dependientes, este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new CatalogoCuentasModelo();
                            finComandoBorrar();
                        }
                        else
                        { 
                        if (CatalogoCuentasModelo.Delete(currentEntidad.idcc, true))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borro el registro ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new CatalogoCuentasModelo();
                            finComandoBorrar();
                        }
                        else
                        {
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                        }
                        }
                    }
                    else
                    {
                        if (lista.Count() == lista.Where(x => x.IsSelected).Count())
                        {//Quiere borrar todo el catalogo
                            var consultarBalances = BalanceModelo.GetAllCapaDatosByidSc(currentSistemaContable.idsc);
                            if (consultarBalances.Count > 0)
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el catalogo", "porque existen balances relacionados");
                            }
                            else
                            {
                                if (CatalogoCuentasModelo.DeleteAllByIdsc(currentSistemaContable.idsc))
                                {
                                    var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                    controller.SetIndeterminate();
                                    await TaskEx.Delay(1000);
                                    await controller.CloseAsync(); actualizarLista();
                                    currentEntidad = new CatalogoCuentasModelo();
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
                            //caso de muchos registros
                            ObservableCollection<CatalogoCuentasModelo> listaEliminar = new ObservableCollection<CatalogoCuentasModelo>(lista.Where(x => x.IsSelected));
                            ObservableCollection<detallebalance> listaDetalle = new ObservableCollection<detallebalance>();
                            bool eliminacionCompleta = true;
                            foreach (CatalogoCuentasModelo elemento in listaEliminar)
                            {
                                listaDetalle = DetalleBalanceModelo.GetAllCapaDatosByCodigoContable(elemento.idcc);
                                if (listaDetalle.Count > 0)
                                {
                                    lista.Where(x => x.idcc == elemento.idcc).SingleOrDefault(x => x.IsSelected = false);
                                    eliminacionCompleta = false;
                                }
                            }

                                if (CatalogoCuentasModelo.Delete(new ObservableCollection<CatalogoCuentasModelo>(lista.Where(x => x.IsSelected))))
                                {
                                if (eliminacionCompleta)
                                {
                                    var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                    controller.SetIndeterminate();
                                    await TaskEx.Delay(1000);
                                    await controller.CloseAsync(); actualizarLista();
                                    currentEntidad = new CatalogoCuentasModelo();
                                    finComandoBorrar();
                                }
                                else
                                {
                                    var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros posibles", "Los que tienen dependientes no. Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                    controller.SetIndeterminate();
                                    await TaskEx.Delay(1000);
                                    await controller.CloseAsync(); actualizarLista();
                                    currentEntidad = new CatalogoCuentasModelo();
                                    finComandoBorrar();
                                }
                            }
                                else
                                {
                                    finComandoBorrar();
                                    await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                                }
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

                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    //Revisar si tiene dependientes porque se deben eliminar tambien
                    bool repetir = false;
                    do
                    {
                    repetir = false;
                    foreach (CatalogoCuentasModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    //Hay hijos
                                    foreach (CatalogoCuentasModelo itemDetalle in lista)
                                    {
                                        if (itemDetalle.catidcc == item.idcc)
                                        {
                                            if(!itemDetalle.IsSelected)
                                            { 
                                            //Hay hijos
                                            itemDetalle.IsSelected = true;
                                            repetir = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    while (repetir);
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //caso de un registro
                        if (CatalogoCuentasModelo.DeleteBorradoLogico(currentEntidad.idcc, true))
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                            actualizarLista();
                            currentEntidad = new CatalogoCuentasModelo();
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
                        if (lista.Count() == lista.Where(x => x.IsSelected).Count())
                        {//Quiere borrar todo el catalogo
                            if (CatalogoCuentasModelo.DeleteLogicoAllByIdsc(currentSistemaContable.idsc))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync(); actualizarLista();
                                currentEntidad = new CatalogoCuentasModelo();
                                finComandoBorrar();
                            }
                            else
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                            }
                        }
                        else
                        {
                            //caso de muchos registros
                            if (CatalogoCuentasModelo.DeleteBorradoLogico(new ObservableCollection<CatalogoCuentasModelo>(lista.Where(x => x.IsSelected))))
                            {
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "Se borraron  los registros ", "");
                                actualizarLista();
                                currentEntidad = new CatalogoCuentasModelo();
                            }
                            else
                            {
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                                accesibilidadWindow = true;
                            }
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
            return !(currentEntidad.idcc == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcioncc);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<CatalogoCuentasModelo> listaEntidad)
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
                    return currentEntidad.idcc != 0;
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
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanCommand);
            SelectionChangedCommand = new RelayCommand<CatalogoCuentasModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
            });
        }

        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i +" registros seleccionados", "");
        }

        private void cargarCC()
        {
            iniciarComando();
            Messenger.Default.Register<int>(this, tokenRecepcionDatosCarga, (detalleTerminado) => ControlCarga(detalleTerminado));

            comando = 8;

            EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloCargarView";
            activarCaptura = true;

            enviarMensajeCargarCatalogo();
            enviarMensajeInhabilitar();

        }

        public async void Importar()
        {

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Cancelar",
                NegativeButtonText = "Encargos",
            };

            MessageDialogResult result = await dlg.ShowMessageAsync(this, "El catalogo se importará de los encargos y sustituira los datos existentes", "Usando los datos de años anteriores",
            MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Negative)
            {
                    iniciarComando();
                    comando = 7;//Importa de los encargos de  años anteriores
                    EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloImportarView";
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

        private async void VistaPrograma()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                enviarMensajeInhabilitar();//Para evitar que el usuario  tome otras acciones
                comando = 5;
                accesibilidadWindow = false;
                EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloVerProgramaView";
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
            Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
        }


        #endregion Fin de comando

    }
}