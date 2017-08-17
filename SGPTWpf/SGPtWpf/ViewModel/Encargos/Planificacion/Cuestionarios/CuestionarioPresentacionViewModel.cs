using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model.Modelo.detalleherramientas;
using System.Windows;
using SGPTmvvm.Soporte;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.Model;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios
{
    public sealed class CuestionarioPresentacionViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        #region salidaRealizada

        private bool _salidaRealizada;
        private bool salidaRealizada
        {
            get { return _salidaRealizada; }
            set { _salidaRealizada = value; }
        }
        #endregion 

        #region tokenEnvioCierre

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
        }

        #endregion

        #region fuenteLlamado 
        //Permite identificar si proviene del menu principal o si es de una ventana
        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        #region tokenRecepcionEncargos

        private string _tokenRecepcionEncargos;
        private string tokenRecepcionEncargos
        {
            get { return _tokenRecepcionEncargos; }
            set { _tokenRecepcionEncargos = value; }
        }

        #endregion

        #region tokenRecepcionEncargosDetalle

        private string _tokenRecepcionEncargosDetalle;
        private string tokenRecepcionEncargosDetalle
        {
            get { return _tokenRecepcionEncargosDetalle; }
            set { _tokenRecepcionEncargosDetalle = value; }
        }

        #endregion

        #region ViewModel Property : currentFirma 

        public const string currentFirmaPropertyName = "currentFirma";

        private FirmaModelo _currentFirma;

        public FirmaModelo currentFirma
        {
            get
            {
                return _currentFirma;
            }

            set
            {
                if (_currentFirma == value) return;

                _currentFirma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentFirmaPropertyName);
            }
        }

        #endregion


        #region propiedades Firma

        #region logoFirma

        public const string logoFirmaPropertyName = "logoFirma";

        private byte[] _logoFirma = null;

        public byte[] logoFirma
        {
            get
            {
                return _logoFirma;
            }

            set
            {
                if (_logoFirma == value)
                {
                    return;
                }

                _logoFirma = value;
                RaisePropertyChanged(logoFirmaPropertyName);
            }
        }

        #endregion

        #region Propiedades : razonSocialFirma


        public const string razonSocialFirmaPropertyName = "razonSocialFirma";

        private string _razonSocialFirma = string.Empty;

        public string razonSocialFirma
        {
            get
            {
                return _razonSocialFirma;
            }
            set
            {
                if (_razonSocialFirma == value)
                {
                    return;
                }
                _razonSocialFirma = value;
                RaisePropertyChanged(razonSocialFirmaPropertyName);
            }
        }

        #endregion

        #region Primary key

        public const string idFirmaPropertyName = "idFirma";

        private int _idFirma = 0;

        public int idFirma
        {
            get
            {
                return _idFirma;
            }

            set
            {
                if (_idFirma == value)
                {
                    return;
                }

                _idFirma = value;
                RaisePropertyChanged(idFirmaPropertyName);
            }
        }

        #endregion

        #endregion

        #region resultadoProceso

        private int _resultadoProceso;
        private int resultadoProceso
        {
            get { return _resultadoProceso; }
            set { _resultadoProceso = value; }
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


        private DialogCoordinator dlg;

        private int idFirmaUnica = 2;//Id de firma a utilizar

        #endregion

        #region Lista de entidades


        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<DetalleCuestionarioModelo> _listaDetalleHerramienta;

        public ObservableCollection<DetalleCuestionarioModelo> listaDetalleHerramienta
        {
            get
            {
                return _listaDetalleHerramienta;
            }
            set
            {
                if (_listaDetalleHerramienta == value) return;

                _listaDetalleHerramienta = value;
                RaisePropertyChanged(listaDetalleHerramientaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaObjetivos

        public const string listaObjetivosPropertyName = "listaObjetivos";

        private ObservableCollection<DetalleCuestionarioModelo> _listaObjetivos;

        public ObservableCollection<DetalleCuestionarioModelo> listaObjetivos
        {
            get
            {
                return _listaObjetivos;
            }
            set
            {
                if (_listaObjetivos == value) return;

                _listaObjetivos = value;
                RaisePropertyChanged(listaObjetivosPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaAlcances

        public const string listaAlcancesPropertyName = "listaAlcances";

        private ObservableCollection<DetalleCuestionarioModelo> _listaAlcances;

        public ObservableCollection<DetalleCuestionarioModelo> listaAlcances
        {
            get
            {
                return _listaAlcances;
            }
            set
            {
                if (_listaAlcances == value) return;

                _listaAlcances = value;
                RaisePropertyChanged(listaAlcancesPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaDetalleProcedimientos

        public const string listaDetalleProcedimientosPropertyName = "listaDetalleProcedimientos";

        private ObservableCollection<DetalleCuestionarioModelo> _listaDetalleProcedimientos;

        public ObservableCollection<DetalleCuestionarioModelo> listaDetalleProcedimientos
        {
            get
            {
                return _listaDetalleProcedimientos;
            }
            set
            {
                if (_listaDetalleProcedimientos == value) return;

                _listaDetalleProcedimientos = value;
                RaisePropertyChanged(listaDetalleProcedimientosPropertyName);
            }
        }


        #endregion

        #endregion Lista de entidades

        #region Propiedades

        #region Entidades

        #region TipoProgramaModelo

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

        #endregion

        #region ViewModel Property : currentEntidad Herramienta Modelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private ProgramaModelo _currentEntidad;

        public ProgramaModelo currentEntidad
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

        private DetalleCuestionarioModelo _currentEntidadDetalle;

        public DetalleCuestionarioModelo currentEntidadDetalle
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

        #region Programa Modelo

        #region idprograma

        public const string idprogramaPropertyName = "idprograma";

        private int _idprograma = 0;

        public int idprograma
        {
            get
            {
                return _idprograma;
            }

            set
            {
                if (_idprograma == value)
                {
                    return;
                }

                _idprograma = value;
                RaisePropertyChanged(idprogramaPropertyName);
            }
        }

        #endregion

        #region idtpprograma

        public const string idtpprogramaPropertyName = "idtpprograma";

        private int _idtpprograma = 0;

        public int idtpprograma
        {
            get
            {
                return _idtpprograma;
            }

            set
            {
                if (_idtpprograma == value)
                {
                    return;
                }

                _idtpprograma = value;
                RaisePropertyChanged(idtpprogramaPropertyName);
            }
        }

        #endregion

        #region idthprograma

        public const string idthprogramaPropertyName = "idthprograma";

        private int _idthprograma = 0;

        public int idthprograma
        {
            get
            {
                return _idthprograma;
            }

            set
            {
                if (_idthprograma == value)
                {
                    return;
                }

                _idthprograma = value;
                RaisePropertyChanged(idthprogramaPropertyName);
            }
        }

        #endregion


        #region nombreprograma

        public const string nombreprogramaPropertyName = "nombreprograma";

        private string _nombreprograma = string.Empty;

        public string nombreprograma
        {
            get
            {
                return _nombreprograma;
            }

            set
            {
                if (_nombreprograma == value)
                {
                    return;
                }

                _nombreprograma = value;
                RaisePropertyChanged(nombreprogramaPropertyName);
            }
        }

        #endregion


        #region fechahoyprograma

        public const string fechahoyprogramaPropertyName = "fechahoyprograma";

        private DateTime _fechahoyprograma = DateTime.Now;

        public DateTime fechahoyprograma
        {
            get
            {
                return _fechahoyprograma;
            }

            set
            {
                if (_fechahoyprograma == value)
                {
                    return;
                }

                _fechahoyprograma = value;
                RaisePropertyChanged(fechahoyprogramaPropertyName);
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

        #region horasplanprograma

        public const string horasplanprogramaPropertyName = "horasplanprograma";

        private decimal? _horasplanprograma = 0;

        public decimal? horasplanprograma
        {
            get
            {
                return _horasplanprograma;
            }

            set
            {
                if (_horasplanprograma == value)
                {
                    return;
                }

                _horasplanprograma = value;
                RaisePropertyChanged(horasplanprogramaPropertyName);
            }
        }

        #endregion

        #region horasejecucionprograma

        public const string horasejecucionprogramaPropertyName = "horasejecucionprograma";

        private decimal? _horasejecucionprograma = 0;

        public decimal? horasejecucionprograma
        {
            get
            {
                return _horasejecucionprograma;
            }

            set
            {
                if (_horasejecucionprograma == value)
                {
                    return;
                }

                _horasejecucionprograma = value;
                RaisePropertyChanged(horasejecucionprogramaPropertyName);
            }
        }

        #endregion

        #region cantidadProcedimientosPlan

        public const string cantidadProcedimientosPlanPropertyName = "cantidadProcedimientosPlan";

        private decimal? _cantidadProcedimientosPlan = 0;

        public decimal? cantidadProcedimientosPlan
        {
            get
            {
                return _cantidadProcedimientosPlan;
            }

            set
            {
                if (_cantidadProcedimientosPlan == value)
                {
                    return;
                }

                _cantidadProcedimientosPlan = value;
                RaisePropertyChanged(cantidadProcedimientosPlanPropertyName);
            }
        }

        #endregion

        #region cantidadProcedimientosEjecucion

        public const string cantidadProcedimientosEjecucionPropertyName = "cantidadProcedimientosEjecucion";

        private decimal? _cantidadProcedimientosEjecucion = 0;

        public decimal? cantidadProcedimientosEjecucion
        {
            get
            {
                return _cantidadProcedimientosEjecucion;
            }

            set
            {
                if (_cantidadProcedimientosEjecucion == value)
                {
                    return;
                }

                _cantidadProcedimientosEjecucion = value;
                RaisePropertyChanged(cantidadProcedimientosEjecucionPropertyName);
            }
        }

        #endregion

        #region indiceHoras

        public const string indiceHorasPropertyName = "indiceHoras";

        private decimal? _indiceHoras = 0;

        public decimal? indiceHoras
        {
            get
            {
                return _indiceHoras;
            }

            set
            {
                if (_indiceHoras == value)
                {
                    return;
                }

                _indiceHoras = value;
                RaisePropertyChanged(indiceHorasPropertyName);
            }
        }

        #endregion

        #region indiceProcedimientos

        public const string indiceProcedimientosPropertyName = "indiceProcedimientos";

        private decimal? _indiceProcedimientos = 0;

        public decimal? indiceProcedimientos
        {
            get
            {
                return _indiceProcedimientos;
            }

            set
            {
                if (_indiceProcedimientos == value)
                {
                    return;
                }

                _indiceProcedimientos = value;
                RaisePropertyChanged(indiceProcedimientosPropertyName);
            }
        }

        #endregion

        #region estadoprograma

        public const string estadoprogramaPropertyName = "estadoprograma";

        private string _estadoprograma = string.Empty;

        public string estadoprograma
        {
            get
            {
                return _estadoprograma;
            }

            set
            {
                if (_estadoprograma == value)
                {
                    return;
                }

                _estadoprograma = value;
                RaisePropertyChanged(estadoprogramaPropertyName);
            }
        }

        #endregion


        #endregion

        #region Detalle Programa

        #region iddp

        public const string iddpPropertyName = "iddp";

        private int _iddp = 0;

        public int iddp
        {
            get
            {
                return _iddp;
            }

            set
            {
                if (_iddp == value)
                {
                    return;
                }

                _iddp = value;
                RaisePropertyChanged(iddpPropertyName);
            }
        }

        #endregion

        #region idtprocedimientodp

        public const string idtprocedimientodpPropertyName = "idtprocedimientodp";

        private int _idtprocedimientodp = 0;

        public int idtprocedimientodp
        {
            get
            {
                return _idtprocedimientodp;
            }

            set
            {
                if (_idtprocedimientodp == value)
                {
                    return;
                }

                _idtprocedimientodp = value;
                RaisePropertyChanged(idtprocedimientodpPropertyName);
            }
        }

        #endregion

        #region descripciondp

        public const string descripciondpPropertyName = "descripciondp";

        private string _descripciondp = string.Empty;

        public string descripciondp
        {
            get
            {
                return _descripciondp;
            }

            set
            {
                if (_descripciondp == value)
                {
                    return;
                }

                _descripciondp = value;
                RaisePropertyChanged(descripciondpPropertyName);
                currentEntidadDetalle.descripciondp = value;
            }
        }

        #endregion

        #region fechacreadodp

        public const string fechacreadodpPropertyName = "fechacreadodp";

        private DateTime _fechacreadodp = DateTime.Now;

        public DateTime fechacreadodp
        {
            get
            {
                return _fechacreadodp;
            }

            set
            {
                if (_fechacreadodp == value)
                {
                    return;
                }

                _fechacreadodp = value;
                RaisePropertyChanged(fechacreadodpPropertyName);
            }
        }

        #endregion

        #region fechaEjecucion

        public const string fechaEjecucionPropertyName = "fechaEjecucion";

        private string _fechaEjecucion;

        public string fechaEjecucion
        {
            get
            {
                return _fechaEjecucion;
            }

            set
            {
                if (_fechaEjecucion == value)
                {
                    return;
                }

                _fechaEjecucion = value;
                RaisePropertyChanged(fechaEjecucionPropertyName);
            }
        }

        #endregion

        #region estadoprocedimientodp

        public const string estadoprocedimientodpPropertyName = "estadoprocedimientodp";

        private string _estadoprocedimientodp = string.Empty;

        public string estadoprocedimientodp
        {
            get
            {
                return _estadoprocedimientodp;
            }

            set
            {
                if (_estadoprocedimientodp == value)
                {
                    return;
                }

                _estadoprocedimientodp = value;
                RaisePropertyChanged(estadoprocedimientodpPropertyName);
            }
        }

        #endregion

        #region nombreCliente

        public const string nombreClientePropertyName = "nombreCliente";

        private string _nombreCliente = string.Empty;

        public string nombreCliente
        {
            get
            {
                return _nombreCliente;
            }

            set
            {
                if (_nombreCliente == value)
                {
                    return;
                }

                _nombreCliente = value;
                RaisePropertyChanged(nombreClientePropertyName);
            }
        }

        #endregion

        #region nombreElabora

        public const string nombreElaboraPropertyName = "nombreElabora";

        private string _nombreElabora = string.Empty;

        public string nombreElabora
        {
            get
            {
                return _nombreElabora;
            }

            set
            {
                if (_nombreElabora == value)
                {
                    return;
                }

                _nombreElabora = value;
                RaisePropertyChanged(nombreElaboraPropertyName);
            }
        }

        #endregion

        #region ordendp

        public const string ordendpPropertyName = "ordendp";

        private decimal _ordendp = 0;

        public decimal ordendp
        {
            get
            {
                return _ordendp;
            }

            set
            {
                if (_ordendp == value)
                {
                    return;
                }

                _ordendp = value;
                RaisePropertyChanged(ordendpPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion

        #endregion


        #region Propiedades de ventanas

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


        #region encabezadoPantalla

        public const string encabezadoPantallaPropertyName = "encabezadoPantalla";

        private string _encabezadoPantalla = string.Empty;

        public string encabezadoPantalla
        {
            get
            {
                return _encabezadoPantalla;
            }

            set
            {
                if (_encabezadoPantalla == value)
                {
                    return;
                }

                _encabezadoPantalla = value;
                RaisePropertyChanged(encabezadoPantallaPropertyName);
            }
        }

        #endregion

        #region visibilidadObjetivos

        public const string visibilidadObjetivosPropertyName = "visibilidadObjetivos";

        private Visibility _visibilidadObjetivos = Visibility.Collapsed;

        public Visibility visibilidadObjetivos
        {
            get
            {
                return _visibilidadObjetivos;
            }

            set
            {
                if (_visibilidadObjetivos == value)
                {
                    return;
                }

                _visibilidadObjetivos = value;
                RaisePropertyChanged(visibilidadObjetivosPropertyName);
            }
        }

        #endregion

        #region visibilidadAlcances

        public const string visibilidadAlcancesPropertyName = "visibilidadAlcances";

        private Visibility _visibilidadAlcances = Visibility.Collapsed;

        public Visibility visibilidadAlcances
        {
            get
            {
                return _visibilidadAlcances;
            }

            set
            {
                if (_visibilidadAlcances == value)
                {
                    return;
                }

                _visibilidadAlcances = value;
                RaisePropertyChanged(visibilidadAlcancesPropertyName);
            }
        }

        #endregion


        #region visibilidadObjetivosReducido

        public const string visibilidadObjetivosReducidoPropertyName = "visibilidadObjetivosReducido";

        private Visibility _visibilidadObjetivosReducido = Visibility.Collapsed;

        public Visibility visibilidadObjetivosReducido
        {
            get
            {
                return _visibilidadObjetivosReducido;
            }

            set
            {
                if (_visibilidadObjetivosReducido == value)
                {
                    return;
                }

                _visibilidadObjetivosReducido = value;
                RaisePropertyChanged(visibilidadObjetivosReducidoPropertyName);
            }
        }

        #endregion

        #region visibilidadAlcancesReducido

        public const string visibilidadAlcancesReducidoPropertyName = "visibilidadAlcancesReducido";

        private Visibility _visibilidadAlcancesReducido = Visibility.Collapsed;

        public Visibility visibilidadAlcancesReducido
        {
            get
            {
                return _visibilidadAlcancesReducido;
            }

            set
            {
                if (_visibilidadAlcancesReducido == value)
                {
                    return;
                }

                _visibilidadAlcancesReducido = value;
                RaisePropertyChanged(visibilidadAlcancesReducidoPropertyName);
            }
        }

        #endregion

        #region nombreprogramaVista

        public const string nombreprogramaVistaPropertyName = "nombreprogramaVista";

        private string _nombreprogramaVista = string.Empty;

        public string nombreprogramaVista
        {
            get
            {
                return _nombreprogramaVista;
            }

            set
            {
                if (_nombreprogramaVista == value)
                {
                    return;
                }

                _nombreprogramaVista = value;
                RaisePropertyChanged(nombreprogramaVistaPropertyName);
            }
        }

        #endregion


        #endregion

        #region ViewModel Commands

        public RelayCommand SalirCommand { get; set; }

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public CuestionarioPresentacionViewModel()
        {
            //Llenado de encabezado
            try
            {
                currentFirma = FirmaModelo.Find(idFirmaUnica);//Solo hay un registro
            }
            catch (Exception)
            {
                currentFirma = new FirmaModelo();
                currentFirma.razonSocialFirma = "Corporación de Contadores de El Salvador";
                currentFirma.logofirma = null;
            }
            if (!(currentFirma == null))
            {
                razonSocialFirma = currentFirma.razonSocialFirma;
                logoFirma = currentFirma.logofirma;
            }
            else
            {
                razonSocialFirma = "Corporación de Contadores de El Salvador";

            }
            //Captura de titulo de programa
            _resultadoProceso = 0;
            _fechaEjecucion = MetodosModelo.homologacionFecha();
            _salidaRealizada = false;
            _tokenRecepcionEncargos = "datosEncargosCuestionario"; //Modificado
            _tokenRecepcionEncargosDetalle = "EncargoPlanCuestionarioAuditoriaDetalle";//Modificado

            _tokenEnvioCierre = "CierreEncargosPlanCuestionarioEncargos";//Modificado
            _fuenteLlamado = 0;
            listaObjetivos = new ObservableCollection<DetalleCuestionarioModelo>();
            listaAlcances = new ObservableCollection<DetalleCuestionarioModelo>();
            listaDetalleProcedimientos = new ObservableCollection<DetalleCuestionarioModelo>();
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionEncargos, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionEncargosDetalle, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));

            accesibilidadWindow = false;
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
        }

        private void ControlDetalleHerramientoCrudMensaje(ProgramaDatosMsj herramientasModeloElementoMensajes)
        {
            //Procesos normal
            currentUsuario = herramientasModeloElementoMensajes.usuarioModelo;
            currentEntidad = herramientasModeloElementoMensajes.programaModelo;
            currentEntidadDetalle = herramientasModeloElementoMensajes.detalleCuestionario;
            encabezadoPantalla = currentEntidad.nombreprograma;
            horasplanprograma = currentEntidad.horasplanprograma;
            horasejecucionprograma = 0;
            visibilidadObjetivos = Visibility.Visible;
            visibilidadAlcances = Visibility.Visible;
            visibilidadObjetivosReducido = Visibility.Collapsed;
            visibilidadAlcancesReducido = Visibility.Collapsed;
            indiceHoras = 0;
            indiceProcedimientos = 0;
            horasejecucionprograma = 0;
            cantidadProcedimientosEjecucion = 0;
            cantidadProcedimientosPlan = 0;
            //Procesado desde la ventana principal;
            if (herramientasModeloElementoMensajes.fuenteLlamado == 1)
            {
                tokenEnvioCierre = "CierreEncargosPlanCuestionarioEncargos";//Modificado
                //enviarMensajeInhabilitar();//Ventana main
                fuenteLlamado = 1;
                listaDetalleHerramienta = new ObservableCollection<DetalleCuestionarioModelo>(DetalleCuestionarioModelo.GetAllVista(currentEntidad.idprograma));
            }
            else
            {
                //Solicitud realizada desde la sub-ventana
                fuenteLlamado = 2;
                tokenEnvioCierre = "CierreEncargoPlanCuestionarioSub-ventana";
                enviarMensajeInhabilitar(tokenEnvioCierre);
                listaDetalleHerramienta = herramientasModeloElementoMensajes.listaDetalleHerramientaC;
            }
            if (horasplanprograma > 0)
            {
                indiceHoras = 100 * (horasejecucionprograma / horasplanprograma);
            }
            else
            {
                indiceHoras = 0;
            }
            decimal contador = 1;
            decimal contadorProcedimiento = 1;
            decimal contadorAlcance = 1;

            DetalleCuestionarioModelo padre;
            decimal diferencia = 0;
            //Basado en el  supuesto que la lista viene ordenada con base a ordendp
            foreach (DetalleCuestionarioModelo item in listaDetalleHerramienta)
            {
                if ((item.nombreTipoProcedimiento.ToUpper() == "Objetivo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Objetivo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Objetivo".ToUpper()))
                {
                    if (item.idpadredp == null)
                    {
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(contador);
                    }
                    else
                    {
                        contador--;
                        diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contador, diferencia));
                    }
                    listaObjetivos.Add(item);
                    contador++;
                }
                else
                {
                    if (!((item.nombreTipoProcedimiento.ToUpper() == "Alcance".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Alcance".ToUpper() || (item.nombreTipoProcedimiento.ToUpper() == "Sub-sub-Alcance".ToUpper()))))
                    {
                        if ((item.nombreTipoProcedimiento.ToUpper() == "Titulo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Titulo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Titulo".ToUpper()) || ((item.nombreTipoProcedimiento.ToUpper() == "Indicaciones".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Indicaciones".ToUpper() || (item.nombreTipoProcedimiento.ToUpper() == "Sub-sub-Indicaciones".ToUpper()))))
                        {
                            item.ordenDhPresentacion = "";
                            listaDetalleProcedimientos.Add(item);
                        }
                        else
                        {
                            if (item.idpadredp == null)
                            {
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(contadorProcedimiento);
                            }
                            else
                            {
                                contadorProcedimiento--;
                                diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contadorProcedimiento, diferencia));
                            }
                            listaDetalleProcedimientos.Add(item);
                            contadorProcedimiento++;
                        }
                    }
                    else
                    {
                        if (item.idpadredp == null)
                        {
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(contadorAlcance);

                        }
                        else
                        {
                            contadorAlcance--;
                            diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contadorAlcance, diferencia));
                        }
                        listaAlcances.Add(item);
                        contadorAlcance++;
                    }
                }
                padre = item;
            }
            if (contadorAlcance > 1)
            {
                if (contadorAlcance == 2)
                {
                    visibilidadAlcancesReducido = Visibility.Visible;
                    visibilidadAlcances = Visibility.Collapsed;
                }
                else
                {
                    visibilidadAlcances = Visibility.Visible;
                    visibilidadAlcancesReducido = Visibility.Collapsed;
                }
            }
            else
            {
                visibilidadAlcances = Visibility.Collapsed;
                visibilidadAlcancesReducido = Visibility.Collapsed;
            }
            if (contador > 1)
            {
                if (contador == 2)
                {
                    visibilidadObjetivosReducido = Visibility.Visible;
                    visibilidadObjetivos = Visibility.Collapsed;
                }
                else
                {
                    visibilidadObjetivos = Visibility.Visible;
                }
            }
            else
            {
                visibilidadObjetivos = Visibility.Collapsed;
            }
            cantidadProcedimientosPlan = contadorProcedimiento - 1;
            cantidadProcedimientosEjecucion = 0;
            if (cantidadProcedimientosPlan > 0)
            {
                indiceProcedimientos = 100 * cantidadProcedimientosEjecucion / cantidadProcedimientosPlan;
            }
            else
            {
                indiceProcedimientos = 0;
            }
            //Desuscribir mensaje
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionEncargos);//Proviene de pantalla principal
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionEncargosDetalle);//Proviene de sub-ventana

            Mouse.OverrideCursor = null;//Termino el proceso de  carga
            accesibilidadWindow = true;
        }


        #endregion


        private void Salir()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            if (!salidaRealizada)
            {
                if (fuenteLlamado != 1)// Si es 1 o proviene del principal,  2 de la subventana
                {
                    enviarMensajeHabilitar(tokenEnvioCierre);
                }
                else
                {
                    //Llamado desde la sub-ventana
                    enviarMensajeCierre();
                    //enviarMensajeHabilitar(tokenEnvioCierre);
                }
                CloseWindow();
                salidaRealizada = true;
            }
        }


        #endregion

        #region Mensajes

        //Procesando mensajes
        public void enviarMensajeInhabilitar()
        {
            //Para la ventana principal
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }

        public void enviarMensajeInhabilitar(string tokenEnvioCierre)
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar, tokenEnvioCierre);
        }
        public void enviarMensajeHabilitar(string tokenEnvioCierre)
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(habilitar, tokenEnvioCierre);
        }

        public void enviarMensajeCierre()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvioCierre);
        }

        #endregion

        #region Metodos de apoyo

        public bool CanSaveNuevo()
        {
            return true;
        }
        #endregion

        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            SalirCommand = new RelayCommand(Salir);
        }

        #endregion


    }
}

