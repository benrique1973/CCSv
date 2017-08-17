using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Messages.Navegacion.PDF;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Messages.Navegacion.Herramientas.Programas;
using SGPTWpf.Model;
using CapaDatos;
using System.Windows;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Messages.Genericos;
using System.Globalization;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas.Programas

{

    public sealed class HerramientasProgramaViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;
        private readonly IDialogCoordinator _dialogCoordinator;
        private string tokenRecepcionPrincipal = "Programas"+ "Herramientas";
        private static int comando = 0;
        private DialogCoordinator dlg;
        private int opcionHerramienta = 1; //Por ser  programas

        #region fuenteLlamado

        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        private string _tokenRecepcionCierrePreView;
        private string tokenRecepcionCierrePreView
        {
            get { return _tokenRecepcionCierrePreView; }
            set { _tokenRecepcionCierrePreView = value; }
        }

        #region tokenEnvioProgramas

        private string _tokenEnvioProgramas;
        private string tokenEnvioProgramas
        {
            get { return _tokenEnvioProgramas; }
            set { _tokenEnvioProgramas = value; }
        }

        #endregion

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

        #region ViewModel Properties publicas

        #region encabezadoHerramienta

        public const string encabezadoHerramientaPropertyName = "encabezadoHerramienta";

        private string _encabezadoHerramienta = string.Empty;

        public string encabezadoHerramienta
        {
            get
            {
                return _encabezadoHerramienta;
            }

            set
            {
                if (_encabezadoHerramienta == value)
                {
                    return;
                }

                _encabezadoHerramienta = value;
                RaisePropertyChanged(encabezadoHerramientaPropertyName);
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


        #region widthTipoPrograma

        public const string widthTipoProgramaPropertyName = "widthTipoPrograma";

        private string _widthTipoPrograma = "0";

        public string widthTipoPrograma
        {
            get
            {
                return _widthTipoPrograma;
            }

            set
            {
                if (_widthTipoPrograma == value)
                {
                    return;
                }

                _widthTipoPrograma = value;
                RaisePropertyChanged(widthTipoProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : Lista

        public const string ListaPropertyName = "Lista";

        private ObservableCollection<HerramientasModelo> _Lista;

        public ObservableCollection<HerramientasModelo> Lista
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

                RaisePropertyChanged(listaTipoHerramientaPropertyName);
            }
        }

        #endregion

        #region Entidades

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private HerramientasModelo _currentEntidad;

        public HerramientasModelo currentEntidad
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

        #region ViewModel Property : currentEntidadDetalle Herramienta Modelo

        public const string currentEntidadDetallePropertyName = "currentEntidadDetalle";

        private DetalleHerramientasModelo _currentEntidadDetalle;

        public DetalleHerramientasModelo currentEntidadDetalle
        {
            get
            {
                return _currentEntidadDetalle;
            }

            set
            {
                if (_currentEntidadDetalle == value) return;

                _currentEntidadDetalle = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadDetallePropertyName);
            }
        }

        #endregion

        #endregion

        #region Propiedades programa

        #region idHerramienta

        public const string idHerramientaPropertyName = "idHerramienta";

        private int _idHerramienta = 0;

        public int idHerramienta
        {
            get
            {
                return _idHerramienta;
            }

            set
            {
                if (_idHerramienta == value)
                {
                    return;
                }

                _idHerramienta = value;
                RaisePropertyChanged(idHerramientaPropertyName);
            }
        }

        #endregion

        #region idTp

        public const string idTpPropertyName = "idTp";

        private int _idTp = 0;

        public int idTp
        {
            get
            {
                return _idTp;
            }

            set
            {
                if (_idTp == value)
                {
                    return;
                }

                _idTp = value;
                RaisePropertyChanged(idTpPropertyName);
            }
        }

        #endregion

        #region idTh

        public const string idThPropertyName = "idTh";

        private int _idTh = 0;

        public int idTh
        {
            get
            {
                return _idTh;
            }

            set
            {
                if (_idTh == value)
                {
                    return;
                }

                _idTh = value;
                RaisePropertyChanged(idThPropertyName);
            }
        }

        #endregion

        #region nombreHerramienta

        public const string nombreHerramientaPropertyName = "nombreHerramienta";

        private string _nombreHerramienta = string.Empty;

        public string nombreHerramienta
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

        #region fechacreadoherramienta

        public const string fechacreadoherramientaPropertyName = "fechacreadoherramienta";

        private DateTime _fechacreadoherramienta = DateTime.Now;

        public DateTime fechacreadoherramienta
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

        #region autorizadoPorHerramienta

        public const string autorizadoPorHerramientaPropertyName = "autorizadoPorHerramienta";

        private string _autorizadoPorHerramienta = string.Empty;

        public string autorizadoPorHerramienta
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

        #region horasPlanHerramienta

        public const string horasPlanHerramientaPropertyName = "horasPlanHerramienta";

        private decimal _horasPlanHerramienta = 0;

        public decimal horasPlanHerramienta
        {
            get
            {
                return _horasPlanHerramienta;
            }

            set
            {
                if (_horasPlanHerramienta == value)
                {
                    return;
                }

                _horasPlanHerramienta = value;
                RaisePropertyChanged(horasPlanHerramientaPropertyName);
            }
        }

        #endregion

        #region estadoHerramienta

        public const string estadoHerramientaPropertyName = "estadoHerramienta";

        private string _estadoHerramienta = string.Empty;

        public string estadoHerramienta
        {
            get
            {
                return _estadoHerramienta;
            }

            set
            {
                if (_estadoHerramienta == value)
                {
                    return;
                }

                _estadoHerramienta = value;
                RaisePropertyChanged(estadoHerramientaPropertyName);
            }
        }

        #endregion

        #region sistemaHerramienta

        public const string sistemaHerramientaPropertyName = "sistemaHerramienta";

        private bool _sistemaHerramienta = false;

        public bool sistemaHerramienta
        {
            get
            {
                return _sistemaHerramienta;
            }

            set
            {
                if (_sistemaHerramienta == value)
                {
                    return;
                }

                _sistemaHerramienta = value;
                RaisePropertyChanged(sistemaHerramientaPropertyName);
            }
        }

        #endregion

        #region visibilidadHoras

        public const string visibilidadHorasPropertyName = "visibilidadHoras";

        private Visibility _visibilidadHoras = Visibility.Visible;

        public Visibility visibilidadHoras
        {
            get
            {
                return _visibilidadHoras;
            }

            set
            {
                if (_visibilidadHoras == value)
                {
                    return;
                }

                _visibilidadHoras = value;
                RaisePropertyChanged(visibilidadHorasPropertyName);
            }
        }

        #endregion

        #endregion

        #region Detalle herramienta

        #region idDh

        public const string idDhPropertyName = "idDh";

        private int _idDh = 0;

        public int idDh
        {
            get
            {
                return _idDh;
            }

            set
            {
                if (_idDh == value)
                {
                    return;
                }

                _idDh = value;
                RaisePropertyChanged(idDhPropertyName);
            }
        }

        #endregion

        #region idtProcedimiento

        public const string idtProcedimientoPropertyName = "idtProcedimiento";

        private int _idtProcedimiento = 0;

        public int idtProcedimiento
        {
            get
            {
                return _idtProcedimiento;
            }

            set
            {
                if (_idtProcedimiento == value)
                {
                    return;
                }

                _idtProcedimiento = value;
                RaisePropertyChanged(idtProcedimientoPropertyName);
            }
        }

        #endregion

        #region descripcionDh

        public const string descripcionDhPropertyName = "descripcionDh";

        private string _descripcionDh = string.Empty;

        public string descripcionDh
        {
            get
            {
                return _descripcionDh;
            }

            set
            {
                if (_descripcionDh == value)
                {
                    return;
                }

                _descripcionDh = value;
                RaisePropertyChanged(descripcionDhPropertyName);
            }
        }

        #endregion

        #region fechaCreadoDh

        public const string fechaCreadoDhPropertyName = "fechaCreadoDh";

        private DateTime _fechaCreadoDh = DateTime.Now;

        public DateTime fechaCreadoDh
        {
            get
            {
                return _fechaCreadoDh;
            }

            set
            {
                if (_fechaCreadoDh == value)
                {
                    return;
                }

                _fechaCreadoDh = value;
                RaisePropertyChanged(fechaCreadoDhPropertyName);
            }
        }

        #endregion

        #region estadoDh

        public const string estadoDhPropertyName = "estadoDh";

        private string _estadoDh = string.Empty;

        public string estadoDh
        {
            get
            {
                return _estadoDh;
            }

            set
            {
                if (_estadoDh == value)
                {
                    return;
                }

                _estadoDh = value;
                RaisePropertyChanged(estadoDhPropertyName);
            }
        }

        #endregion

        #region sistemaDh

        public const string sistemaDhPropertyName = "sistemaDh";

        private bool _sistemaDh = false;

        public bool sistemaDh
        {
            get
            {
                return _sistemaDh;
            }

            set
            {
                if (_sistemaDh == value)
                {
                    return;
                }

                _sistemaDh = value;
                RaisePropertyChanged(sistemaDhPropertyName);
            }
        }

        #endregion

        #region ordenDh

        public const string ordenDhPropertyName = "ordenDh";

        private decimal _ordenDh = 0;

        public decimal ordenDh
        {
            get
            {
                return _ordenDh;
            }

            set
            {
                if (_ordenDh == value)
                {
                    return;
                }

                _ordenDh = value;
                RaisePropertyChanged(ordenDhPropertyName);
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
        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set;}
        public RelayCommand DuplicarCommand { get; set; }
        public RelayCommand<HerramientasModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region HerramientasProgramasMainModel

        private MainModel _mainModel = null;

        public MainModel HerramientasProgramasMainModel
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

        #region idTpNombre

        public const string idTpNombrePropertyName = "idTpNombre";

        private string _idTpNombre = string.Empty;

        public string idTpNombre
        {
            get
            {
                return _idTpNombre;
            }

            set
            {
                if (_idTpNombre == value)
                {
                    return;
                }

                _idTpNombre = value;
                RaisePropertyChanged(idTpNombrePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadWindow

        public const string accesibilidadWindowPropertyName = "accesibilidadWindow";

        private bool _accesibilidadWindow = true;

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

        #region ViewModel Public Methods

        #region Constructores


        public HerramientasProgramaViewModel()
        {
            _fuenteLlamado = 0;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();

            _tokenEnvioProgramas = "datosHPrograma";//Mensaje para vistaCuestionarioPreview

            _tokenRecepcionCierrePreView = "CierrePrevioPrograma";//Sirve tanto para los programas en vista previa como para el controllador;

            currentEntidad = new HerramientasModelo();
            currentEntidad.idHerramienta = 0;
            RegisterCommands();
            comando = 0;
            dlg = new DialogCoordinator();
            //Lista = new ObservableCollection<HerramientasModelo>(HerramientasModelo.GetAll(opcionHerramienta));//Es uno por ser programas
            listaTipoHerramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
            //Suscribiendo al tipo de mensaje
            //Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));
            //Seleccion de opcion de opciones (Programa o Cuestionario)
            HerramientasProgramasMainModel = new MainModel();
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal,(herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));

            Messenger.Default.Register<bool>(this, tokenRecepcionCierrePreView, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
        }

        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
        {
            currentUsuario = herramientaUsuarioValidadoMensaje.usuarioModeloMensaje;
            //Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);
            ActualizarLista();
        }


        private void ActualizarLista()
        {
                try
                {
                    Lista = new ObservableCollection<HerramientasModelo>(HerramientasModelo.GetAll(opcionHerramienta));
                }
                catch (Exception )
                {
                        dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                }
        }

        #endregion

        #region Envio mensajes


        //Caso de nuevo registro 
        public void enviarMsjCrear(HerramientasModelo currentEntidad, DetalleHerramientasModelo currentEntidadDetalle, int cmd)
        {
            //Se crea el mensaje
                HerramientasToControllerCrearMsj elementoHerramienta = new HerramientasToControllerCrearMsj();            

                elementoHerramienta.usuarioValidado = currentUsuario;
                if (comando == 1)
                {
                    elementoHerramienta.detalleHerramientaModelo = currentEntidadDetalle;
                }
                else
                {
                    elementoHerramienta.detalleHerramientaModelo = null;
                }
                elementoHerramienta.opcionMenu = opcionHerramienta;
                elementoHerramienta.herramientaModeloElemento = currentEntidad;
                elementoHerramienta.cmd = cmd;
                elementoHerramienta.listaHerramientas = Lista;
                Messenger.Default.Send(elementoHerramienta);
        }

        public void enviarElemento(HerramientasModelo currentEntidad)
        {
            //Se crea el mensaje
            HModeloDatosMensajes elemento = new HModeloDatosMensajes();

                elemento.usuarioValidado = currentUsuario;
                elemento.detalleHerramientaModelo = null;
                elemento.opcionMenuPrincipal = opcionHerramienta;
                elemento.opcionMenuCrud = comando;
                elemento.listaHerramientas = Lista;
                elemento.herramientaModeloElemento = currentEntidad;
                elemento.cmd = fuenteLlamado;
            Messenger.Default.Send(elemento, tokenEnvioProgramas);
        }

        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(VentanaControllerToHerramientasViewMensaje controlVentanaCrearMensaje)
        {
            accesibilidadWindow = true;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje.registroCreado)
                    { 
                    Editar(); //regresa a generar una ventana para editar el programa creado
                    ActualizarLista();
                    }
                    else
                    {
                     HerramientasProgramasMainModel.TypeName = null;
                    }
                    break;
                case 2:
                    //currentEntidad = new HerramientasModelo();
                    //currentEntidad.idHerramienta = 0;
                    HerramientasProgramasMainModel.TypeName = null;
                    ActualizarLista();
                    comando = 0;
                    break;
                case 3:
                    //currentEntidad = new HerramientasModelo();
                    //currentEntidad.idHerramienta = 0;
                    HerramientasProgramasMainModel.TypeName = null;
                    //ActualizarLista();
                    comando = 0;
                    break;
                case 4:
                    //caso de vista de programa
                    HerramientasProgramasMainModel.TypeName = null;

                    comando = 0;
                    break;
                case 5:
                    //currentEntidad = new HerramientasModelo();
                    //currentEntidad.idHerramienta = 0;
                    HerramientasProgramasMainModel.TypeName = null;
                    ActualizarLista();
                    comando = 0;
                    break;
                default:
                    break;
            }
            Messenger.Default.Unregister<VentanaControllerToHerramientasViewMensaje>(this);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;

        }

        private void ControlVentanaMensaje(bool controlVentanaCrearMensaje)
        {
            accesibilidadWindow = true;
            switch (comando)
            {
                case 1:
                    ActualizarLista();
                    break;
                case 2:
                    HerramientasProgramasMainModel.TypeName = null;
                    ActualizarLista();
                    comando = 0;
                    break;
                case 3:
                    HerramientasProgramasMainModel.TypeName = null;
                    comando = 0;
                    break;
                case 4:
                    //caso de vista de programa
                    HerramientasProgramasMainModel.TypeName = null;

                    comando = 0;
                    break;
                case 5:
                    HerramientasProgramasMainModel.TypeName = null;
                    ActualizarLista();
                    enviarMensajeHabilitar();
                    comando = 0;
                    break;
                default:
                    break;
            }
            Messenger.Default.Unregister<VentanaControllerToHerramientasViewMensaje>(this);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));

            accesibilidadWindow = false;
            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad = new HerramientasModelo();
            //Temporal para identificar al usuario
            currentEntidad.autorizadoPorHerramienta = currentUsuario.inicialesusuario.ToUpper();
            currentEntidad.fechacreadoherramienta = DateTime.Now;
            currentEntidad.fechacreadoherramientaString = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            currentEntidad.horasPlanHerramienta = 0;
            currentEntidad.idHerramienta = 0;
            HerramientasProgramasMainModel.TypeName = "HerramientaModeloCrearView";
            //Seleccion de programa
            currentEntidad.tipoHerramientaModelo = listaTipoHerramienta[0];
            currentEntidad.idTh = listaTipoHerramienta[0].id;
            
            #endregion
            
            #region Inicializacion del detalle Objetivo
            currentEntidadDetalle = new DetalleHerramientasModelo();
            currentEntidadDetalle.idUsuario = currentUsuario.idUsuario;
            currentEntidadDetalle.fechaCreadoDh = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            currentEntidadDetalle.horasPlanDh = 0;
            currentEntidadDetalle.descripcionByteaDh = null;
            currentEntidadDetalle.idtProcedimiento = 7;//Es un objetivo vease tipoProcedimiento
            currentEntidadDetalle.idHerramienta = currentEntidad.idHerramienta;
            currentEntidadDetalle.estadoDh = "A";
            currentEntidadDetalle.sistemaDh = false;
            currentEntidadDetalle.guardadoBase = false;
            currentEntidadDetalle.idDhPrincipalDh = null;
            currentEntidadDetalle.ordenDh = 1;//El objetivo es el primero
            currentEntidadDetalle.activarCaptura = true;
            #endregion
            enviarMsjCrear(currentEntidad, currentEntidadDetalle, opcionHerramienta);
            //enviarMensaje();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso

                comando = 2;
                accesibilidadWindow = false;
                HerramientasProgramasMainModel.TypeName = "HerrramientaModeloEditarView";
                enviarElemento(currentEntidad);//Debe ir antes, porque evalua si la ventana es cero para enviarse
                //enviarMensaje();
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
                Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso

                comando = 3;
                        accesibilidadWindow = false;
                        HerramientasProgramasMainModel.TypeName = "HerrramientaModeloConsultarView";
                        enviarElemento(currentEntidad);
                        //enviarMensaje();
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
                Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso

                comando = 3;
                        accesibilidadWindow = false;
                        HerramientasProgramasMainModel.TypeName = "HerrramientaModeloConsultarView";
                        enviarElemento(currentEntidad);
                        //enviarMensaje();

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
                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso
                                                               //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                if (HerramientasModelo.Delete(currentEntidad.idHerramienta, true))
                    //if (HerramientasModelo.Delete(currentEntidad.id, true))
                    {
                    var controller = await dlg.ShowProgressAsync(this, "Se borro el registro", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    ActualizarLista();
                        currentEntidad = HerramientasModelo.Clear(currentEntidad);
                    }
                    else
                    {
                    var controller = await dlg.ShowProgressAsync(this, "No ha sido posible eliminar el registro", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                }
                GestionAccesibilidad.finalizarComandoLocal();
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
            return !(currentEntidad.idHerramienta == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.nombreHerramienta);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<HerramientasModelo> listaEntidad)
        {
            Lista = listaEntidad;
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
                    return currentEntidad.idHerramienta != 0;
                }
                catch (Exception )
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

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            BuscarCommand = new RelayCommand(Buscar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            XImprimirCommand = new RelayCommand(XImprimir, CanCommand);
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanCommand);
            DuplicarCommand = new RelayCommand(Seleccion, CanCommand);
            SelectionChangedCommand = new RelayCommand<HerramientasModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private async void VistaPrograma()
        {
            if (!(currentEntidad == null))
            {
                Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso

                comando = 5;
                accesibilidadWindow = false;
                HerramientasProgramasMainModel.TypeName = "HerrramientaModeloVerProgramaView";
                enviarElemento(currentEntidad);
                //enviarMensaje();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        private async void Seleccion()
        {
            if (!(currentEntidad == null))
            {
                Messenger.Default.Register<VentanaControllerToHerramientasViewMensaje>(this, (ventanaControllerToHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToHerramientasViewMensaje));

                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Se copiará el programa a otro registro", "¿Desea confirmar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso

                    int idCopia = currentEntidad.idHerramienta;
                    currentEntidad = new HerramientasModelo();
                    currentEntidad = HerramientasModelo.GetRegistro(idCopia);
                    HerramientasProgramasMainModel.TypeName = "ProgramaCopiarView";
                    comando = 5;
                    currentEntidad.autorizadoPorHerramienta = currentUsuario.inicialesusuario.ToUpper();
                    currentEntidad.fechacreadoherramienta = DateTime.Now;
                    currentEntidad.fechacreadoherramientaString = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
                    enviarMsjCrear(currentEntidad, currentEntidadDetalle, comando);
                    //enviarMensaje();

                }
                else
                {
                    comando = 5;
                    currentEntidad = null;
                }
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

        private void tipoVistaMensaje(string seleccion)
        {
            {
                //Se crea el mensaje
                ViewTypeMessages elemento = new ViewTypeMessages();
                elemento.viewType = seleccion;
                Messenger.Default.Send(elemento);
            }
        }
        #endregion
    }
}