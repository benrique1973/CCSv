using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Model;
using CapaDatos;
using System.Windows;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;

namespace SGPTWpf.ViewModel.Herramientas.Cuestionarios

{

    public sealed class HerramientasCuestionarioViewModel : ViewModeloBase
        {

        #region Propiedades privadas

            private MetroDialogSettings configuracionDialogo;

            private readonly IDialogCoordinator _dialogCoordinator;

        #region opcionHerramienta

        #region fuenteLlamado

        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        private int _opcionHerramienta;
        private int opcionHerramienta
        {
            get { return _opcionHerramienta; }
            set { _opcionHerramienta = value; }
        }

        #endregion

        private static int comando = 0;

            private DialogCoordinator dlg;


        #region tokenEnvioProgramas

        private string _tokenEnvioProgramas;
            private string tokenEnvioProgramas
            {
                get { return _tokenEnvioProgramas; }
                set { _tokenEnvioProgramas = value; }
            }

            #endregion

            #region tokenRecepcion

            private string _tokenRecepcion;
            private string tokenRecepcion
            {
                get { return _tokenRecepcion; }
                set { _tokenRecepcion = value; }
            }

        #endregion

        #endregion

        #region Visibilidad de  botones

        #region visibilidadMCrear

        public const string visibilidadMCrearPropertyName = "visibilidadMCrear";

        private Visibility _visibilidadMCrear = Visibility.Collapsed;

        public Visibility visibilidadMCrear
        {
            get
            {
                return _visibilidadMCrear;
            }

            set
            {
                if (_visibilidadMCrear == value)
                {
                    return;
                }

                _visibilidadMCrear = value;
                RaisePropertyChanged(visibilidadMCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadMEditar

        public const string visibilidadMEditarPropertyName = "visibilidadMEditar";

        private Visibility _visibilidadMEditar = Visibility.Collapsed;

        public Visibility visibilidadMEditar
        {
            get
            {
                return _visibilidadMEditar;
            }

            set
            {
                if (_visibilidadMEditar == value)
                {
                    return;
                }

                _visibilidadMEditar = value;
                RaisePropertyChanged(visibilidadMEditarPropertyName);
            }
        }

        #endregion

        #region visibilidadMReferenciar

        public const string visibilidadMReferenciarPropertyName = "visibilidadMReferenciar";

        private Visibility _visibilidadMReferenciar = Visibility.Collapsed;

        public Visibility visibilidadMReferenciar
        {
            get
            {
                return _visibilidadMReferenciar;
            }

            set
            {
                if (_visibilidadMReferenciar == value)
                {
                    return;
                }

                _visibilidadMReferenciar = value;
                RaisePropertyChanged(visibilidadMReferenciarPropertyName);
            }
        }

        #endregion

        #region visibilidadMCerrar

        public const string visibilidadMCerrarPropertyName = "visibilidadMCerrar";

        private Visibility _visibilidadMCerrar = Visibility.Collapsed;

        public Visibility visibilidadMCerrar
        {
            get
            {
                return _visibilidadMCerrar;
            }

            set
            {
                if (_visibilidadMCerrar == value)
                {
                    return;
                }

                _visibilidadMCerrar = value;
                RaisePropertyChanged(visibilidadMCerrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMSupervisar

        public const string visibilidadMSupervisarPropertyName = "visibilidadMSupervisar";

        private Visibility _visibilidadMSupervisar = Visibility.Collapsed;

        public Visibility visibilidadMSupervisar
        {
            get
            {
                return _visibilidadMSupervisar;
            }

            set
            {
                if (_visibilidadMSupervisar == value)
                {
                    return;
                }

                _visibilidadMSupervisar = value;
                RaisePropertyChanged(visibilidadMSupervisarPropertyName);
            }
        }

        #endregion

        #region visibilidadMAprobar

        public const string visibilidadMAprobarPropertyName = "visibilidadMAprobar";

        private Visibility _visibilidadMAprobar = Visibility.Collapsed;

        public Visibility visibilidadMAprobar
        {
            get
            {
                return _visibilidadMAprobar;
            }

            set
            {
                if (_visibilidadMAprobar == value)
                {
                    return;
                }

                _visibilidadMAprobar = value;
                RaisePropertyChanged(visibilidadMAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadMBorrar

        public const string visibilidadMBorrarPropertyName = "visibilidadMBorrar";

        private Visibility _visibilidadMBorrar = Visibility.Collapsed;

        public Visibility visibilidadMBorrar
        {
            get
            {
                return _visibilidadMBorrar;
            }

            set
            {
                if (_visibilidadMBorrar == value)
                {
                    return;
                }

                _visibilidadMBorrar = value;
                RaisePropertyChanged(visibilidadMBorrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMConsulta

        public const string visibilidadMConsultaPropertyName = "visibilidadMConsulta";

        private Visibility _visibilidadMConsulta = Visibility.Collapsed;

        public Visibility visibilidadMConsulta
        {
            get
            {
                return _visibilidadMConsulta;
            }

            set
            {
                if (_visibilidadMConsulta == value)
                {
                    return;
                }

                _visibilidadMConsulta = value;
                RaisePropertyChanged(visibilidadMConsultaPropertyName);
            }
        }

        #endregion

        #region visibilidadMDetalle

        public const string visibilidadMDetallePropertyName = "visibilidadMDetalle";

        private Visibility _visibilidadMDetalle = Visibility.Collapsed;

        public Visibility visibilidadMDetalle
        {
            get
            {
                return _visibilidadMDetalle;
            }

            set
            {
                if (_visibilidadMDetalle == value)
                {
                    return;
                }

                _visibilidadMDetalle = value;
                RaisePropertyChanged(visibilidadMDetallePropertyName);
            }
        }

        #endregion

        #region visibilidadMVista

        public const string visibilidadMVistaPropertyName = "visibilidadMVista";

        private Visibility _visibilidadMVista = Visibility.Collapsed;

        public Visibility visibilidadMVista
        {
            get
            {
                return _visibilidadMVista;
            }

            set
            {
                if (_visibilidadMVista == value)
                {
                    return;
                }

                _visibilidadMVista = value;
                RaisePropertyChanged(visibilidadMVistaPropertyName);
            }
        }

        #endregion

        #region visibilidadMRegresar

        public const string visibilidadMRegresarPropertyName = "visibilidadMRegresar";

        private Visibility _visibilidadMRegresar = Visibility.Hidden;

        public Visibility visibilidadMRegresar
        {
            get
            {
                return _visibilidadMRegresar;
            }

            set
            {
                if (_visibilidadMRegresar == value)
                {
                    return;
                }

                _visibilidadMRegresar = value;
                RaisePropertyChanged(visibilidadMRegresarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImportar

        public const string visibilidadMImportarPropertyName = "visibilidadMImportar";

        private Visibility _visibilidadMImportar = Visibility.Collapsed;

        public Visibility visibilidadMImportar
        {
            get
            {
                return _visibilidadMImportar;
            }

            set
            {
                if (_visibilidadMImportar == value)
                {
                    return;
                }

                _visibilidadMImportar = value;
                RaisePropertyChanged(visibilidadMImportarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImprimir

        public const string visibilidadMImprimirPropertyName = "visibilidadMImprimir";

        private Visibility _visibilidadMImprimir = Visibility.Hidden;

        public Visibility visibilidadMImprimir
        {
            get
            {
                return _visibilidadMImprimir;
            }

            set
            {
                if (_visibilidadMImprimir == value)
                {
                    return;
                }

                _visibilidadMImprimir = value;
                RaisePropertyChanged(visibilidadMImprimirPropertyName);
            }
        }

        #endregion

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region menuElegido

        private string _menuElegido;
        private string menuElegido
        {
            get { return _menuElegido; }
            set { _menuElegido = value; }
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
            public RelayCommand VistaProgramaCommand { get; set; }
            public RelayCommand DuplicarCommand { get; set; }
            public RelayCommand<HerramientasModelo> SelectionChangedCommand { get; set; }

            #endregion

            #region HerramientasCuestionarioMainModel

            private MainModel _mainModel = null;

            public MainModel HerramientasCuestionarioMainModel
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


        public HerramientasCuestionarioViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;
            _menuElegido = "Herramientas";
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            #region  menu

            _visibilidadMCrear = Visibility.Visible;
            _visibilidadMEditar = Visibility.Visible;
            _visibilidadMBorrar = Visibility.Visible;
            _visibilidadMConsulta = Visibility.Visible;
            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
            _visibilidadMRegresar = Visibility.Collapsed;
            _visibilidadMVista = Visibility.Collapsed;
            _visibilidadMImportar = Visibility.Collapsed;
            _visibilidadMDetalle = Visibility.Visible;

            _visibilidadMCerrar = Visibility.Collapsed;
            _visibilidadMSupervisar = Visibility.Collapsed;
            _visibilidadMAprobar = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            #endregion

            _tokenRecepcion = "Cuestionarios" + "Herramientas";
                 opcionHerramienta = 2; //Por ser cuestionario
                _dialogCoordinator = new DialogCoordinator();
                _tokenEnvioProgramas = "datosHCuestionario";//Mensaje para vistaCuestionarioPreview
                currentEntidad = new HerramientasModelo();
                RegisterCommands();
                comando = 0;
                dlg = new DialogCoordinator();
                //Lista = new ObservableCollection<HerramientasModelo>(HerramientasModelo.GetAll(opcionHerramienta));
                listaTipoHerramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
                //Suscribiendo al tipo de mensaje
                //Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));
                //Seleccion de opcion de opciones (Programa o Cuestionario)
                HerramientasCuestionarioMainModel = new MainModel();
                Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcion,(herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
                //Creacion de  mensajes
            }


        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 10,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

        private void permisos()
        {
            if (currentUsuario.listaPermisos != null)
            {
                try
                {
                    if (currentUsuario.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()) > 0)
                    {
                        #region  permisos asignados

                        permisosrolesusuario permisosAsignados = currentUsuario.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()
                        && x.menupru.ToUpper() == menuElegido.ToUpper());

                        if (permisosAsignados != null)
                        {


                            if (permisosAsignados.crearpru)
                            {
                                _visibilidadMCrear = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMCrear = Visibility.Collapsed;
                            }
                            if (permisosAsignados.editarpru)
                            {
                                _visibilidadMEditar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMEditar = Visibility.Collapsed;
                            }
                            if (permisosAsignados.consultarpru)
                            {
                                _visibilidadMConsulta = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMConsulta = Visibility.Collapsed;
                            }
                            if (permisosAsignados.eliminarpru)
                            {
                                _visibilidadMBorrar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMBorrar = Visibility.Collapsed;
                            }
                            if (permisosAsignados.impresionpru)
                            {
                                _visibilidadMVista = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMVista = Visibility.Collapsed;
                            }
                            if (permisosAsignados.crearpru)
                            {
                                _visibilidadMImportar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMImportar = Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                        }
                        #endregion fin de region de permisos
                    }
                    else
                    {
                        MessageBox.Show("Error en opción y la base de datos\nRevise la opción programada");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al identificar los permisos\nRevise la opción programada");
                    #region  menu
                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Visible;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                }
            }
            else
            {
                #region  menu
                MessageBox.Show("No están definidos los permisos\nRevise los permisos del usuario");
                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Collapsed;
                _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                _visibilidadMRegresar = Visibility.Collapsed;
                _visibilidadMVista = Visibility.Collapsed;
                _visibilidadMImportar = Visibility.Collapsed;
                _visibilidadMDetalle = Visibility.Collapsed;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;
                #endregion
            }

        }

        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
            {
                currentUsuario = herramientaUsuarioValidadoMensaje.usuarioModeloMensaje;
                permisos();
                //Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcion);
                ActualizarLista();
                accesibilidadWindow = true;
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
            //Se crea el mensaje para crear elemento (Se utiliza el mismo para programa y cuestionario
                    HerramientasToControllerCuestionarioCrearMsj elementoHerramienta = new HerramientasToControllerCuestionarioCrearMsj();
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
                    elemento.listaHerramientas = Lista;
                    elemento.opcionMenuPrincipal = 2;//Para diferenciar 1 cuando es del  principal 2 cuando es de subventana
                    elemento.opcionMenuCrud = comando;
                    elemento.herramientaModeloElemento = currentEntidad;
            Messenger.Default.Send(elemento);
            }
        public void enviarElemento()
        {
            //Se crea el mensaje
            HModeloDatosMensajes elemento = new HModeloDatosMensajes();
            elemento.usuarioValidado = currentUsuario;
            elemento.detalleHerramientaModelo = null;
            elemento.listaHerramientas = Lista;
            elemento.opcionMenuPrincipal = 1;//Para diferenciar 1 cuando es del  principal 2 cuando es de subventana
            elemento.opcionMenuCrud = comando;
            elemento.herramientaModeloElemento = currentEntidad;
            elemento.cmd = fuenteLlamado;
            Messenger.Default.Send(elemento, tokenEnvioProgramas);
        }
        #endregion

            #region Receptor de mensajes

        private void ControlVentanaMensaje(VentanaControllerToCuestionarioHerramientasViewMensaje controlVentanaCrearMensaje)
            {
            HerramientasCuestionarioMainModel.TypeName = null;
            switch (comando)
                {
                    case 1:
                        //currentEntidad = null; No es nula porque se agrega a la lista pero no ha cambiado la ventana
                        if (controlVentanaCrearMensaje.registroCreado)
                        {
                            //Editar(); //regresa a generar una ventana para editar el programa creado
                            ActualizarLista();
                        }
                        break;
                    case 2:
                        //currentEntidad = new HerramientasModelo();
                        //currentEntidad.idHerramienta = 0;
                        ActualizarLista();
                        break;
                    case 3:
                        //currentEntidad = new HerramientasModelo();
                        //currentEntidad.idHerramienta = 0;

                        //ActualizarLista();

                        break;
                    case 4:
                    //caso de vista de programa

                    break;
                    case 5:
                        ActualizarLista();
                        
                        break;
                default:
                        break;
                }
            comando = 0;
            currentEntidad = null;
            Messenger.Default.Unregister<VentanaControllerToCuestionarioHerramientasViewMensaje>(this);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }


        #endregion

            #region Implementacion de comandos
        public void Nuevo()
            {
            Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));

            GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso

                comando = 1;
                #region Inicializacion de herramienta 
                currentEntidad = new HerramientasModelo(opcionHerramienta, currentUsuario, listaTipoHerramienta[1]);//2 por ser cuestionario
                //Seleccion de programa
                HerramientasCuestionarioMainModel.TypeName = "HerramientaModeloCrearCuestionarioView";

                #endregion
                #region Inicializacion del detalle Objetivo
                currentEntidadDetalle = new DetalleHerramientasModelo(currentEntidad.idHerramienta,currentUsuario);
                currentEntidadDetalle.idtProcedimiento = 7;//Es un objetivo vease tipoProcedimiento
                currentEntidadDetalle.activarCaptura = true;
                #endregion
                enviarMsjCrear(currentEntidad, currentEntidadDetalle, comando);
                //enviarMensaje();
            }

            public async void Editar()
            {
                if (!(currentEntidad == null))
                {
                Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso
                    comando = 2;
                    HerramientasCuestionarioMainModel.TypeName = "HerrramientaModeloEditarCuestionarioView";
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
                Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso
                    comando = 3;
                    HerramientasCuestionarioMainModel.TypeName = "HerrramientaModeloConsultarCuestionarioView";
                    enviarElemento(currentEntidad);

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
                Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso
                comando = 3;
                    HerramientasCuestionarioMainModel.TypeName = "HerrramientaModeloConsultarCuestionarioView";
                    enviarElemento(currentEntidad);

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
                Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));


                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Se copiará el cuestionario a otro registro", "¿Desea confirmar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso
                    int idCopia = currentEntidad.idHerramienta;
                    //currentEntidad = new HerramientasModelo();
                    currentEntidad = HerramientasModelo.GetRegistro(idCopia);
                    HerramientasCuestionarioMainModel.TypeName = "CuestionarioCopiarView";
                    comando = 5;
                    currentEntidad.autorizadoPorHerramienta = currentUsuario.inicialesusuario.ToUpper();
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
                    if (currentEntidad.idHerramienta != 0)
                    {
                    return currentEntidad.idHerramienta != 0;
                        }
                    else
                    {
                    return false;
                };
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
                Messenger.Default.Register<VentanaControllerToCuestionarioHerramientasViewMensaje>(this, (ventanaControllerToCuestionarioHerramientasViewMensaje) => ControlVentanaMensaje(ventanaControllerToCuestionarioHerramientasViewMensaje));

                GestionAccesibilidad.iniciarComandoPrincipal();//Para inicial el proceso
                comando = 5;
                    HerramientasCuestionarioMainModel.TypeName = "HerrramientaModeloVerCuestionarioView";
                    enviarElemento();
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

            #endregion
        }
    }
