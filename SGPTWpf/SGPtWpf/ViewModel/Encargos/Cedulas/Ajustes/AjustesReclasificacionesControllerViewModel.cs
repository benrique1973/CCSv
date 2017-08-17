using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Windows;
using SGPTWpf.Model;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Threading.Tasks;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.Model.Modelo.Auxiliares;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Ajustes
{

    public sealed class AjustesReclasificacionesControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        #region cerradoFinalVentana

        private bool _cerradoFinalVentana;
        private bool cerradoFinalVentana
        {
            get { return _cerradoFinalVentana; }
            set { _cerradoFinalVentana = value; }
        }

        #endregion

        #region tokenEnvio

        private string _tokenEnvio;
        private string tokenEnvio
        {
            get { return _tokenEnvio; }
            set { _tokenEnvio = value; }
        }

        #endregion

        #region tokenRecepcionCodigo

        private string _tokenRecepcionCodigo;
        private string tokenRecepcionCodigo
        {
            get { return _tokenRecepcionCodigo; }
            set { _tokenRecepcionCodigo = value; }
        }

        #endregion

        #region tokenRecepcionCuenta

        private string _tokenRecepcionCuenta;
        private string tokenRecepcionCuenta
        {
            get { return _tokenRecepcionCuenta; }
            set { _tokenRecepcionCuenta = value; }
        }

        #endregion

        #region tokenRecepcionCargos

        private string _tokenRecepcionCargos;
        private string tokenRecepcionCargos
        {
            get { return _tokenRecepcionCargos; }
            set { _tokenRecepcionCargos = value; }
        }

        #endregion

        #region tokenRecepcionAbonos

        private string _tokenRecepcionAbonos;
        private string tokenRecepcionAbonos
        {
            get { return _tokenRecepcionAbonos; }
            set { _tokenRecepcionAbonos = value; }
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

        #region maxDescripcion

        private int _maxDescripcion;
        private int maxDescripcion
        {
            get { return _maxDescripcion; }
            set { _maxDescripcion = value; }
        }

        #endregion

        #region tamanoArchivo

        private int _tamanoArchivo;
        private int tamanoArchivo
        {
            get { return _tamanoArchivo; }
            set { _tamanoArchivo = value; }
        }

        #endregion

        #region numeroProcesoCrudRecibido

        private int _numeroProcesoCrudRecibido;
        private int numeroProcesoCrudRecibido
        {
            get { return _numeroProcesoCrudRecibido; }
            set { _numeroProcesoCrudRecibido = value; }
        }

        #endregion

        #region origen

        private string _origen;
        private string origen
        {
            get { return _origen; }
            set { _origen = value; }
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

        #region FuenteCierre

        private int _fuenteCierre;
        private int fuenteCierre
        {
            get { return _fuenteCierre; }
            set { _fuenteCierre = value; }
        }

        #endregion

        #region resultadoProceso

        private int _resultadoProceso;
        private int resultadoProceso
        {
            get { return _resultadoProceso; }
            set { _resultadoProceso = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        public static int Errors { get; set; }//Para controllar los errores de edición

        #endregion

        #region ViewModel Properties listas

        #region ViewModel Properties : isListaCargada

        public const string isListaCargadaPropertyName = "isListaCargada";

        private bool _isListaCargada;

        public bool isListaCargada
        {
            get
            {
                return _isListaCargada;
            }

            set
            {
                if (_isListaCargada == value)
                {
                    return;
                }

                _isListaCargada = value;
                RaisePropertyChanged(isListaCargadaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listacurrentEntidad

        public const string listacurrentEntidadPropertyName = "listacurrentEntidad";

        private ObservableCollection<CedulaModelo> _listacurrentEntidad;

        public ObservableCollection<CedulaModelo> listacurrentEntidad
        {
            get
            {
                return _listacurrentEntidad;
            }

            set
            {
                if (_listacurrentEntidad == value) return;

                _listacurrentEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listacurrentEntidadPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaTiposAuditoria

        public const string listaTiposAuditoriaPropertyName = "listaTiposAuditoria";

        private ObservableCollection<TipoAuditoriaModelo> _listaTiposAuditoria;

        public ObservableCollection<TipoAuditoriaModelo> listaTiposAuditoria
        {
            get
            {
                return _listaTiposAuditoria;
            }
            set
            {
                if (_listaTiposAuditoria == value) return;

                _listaTiposAuditoria = value;
                RaisePropertyChanged(listaTiposAuditoriaPropertyName);
            }
        }

        #endregion

        #region listas

        #region ViewModel Properties : listaDetalleEntidad

        public const string listaDetalleEntidadPropertyName = "listaDetalleEntidad";

        private ObservableCollection<CedulaPartidasModelo> _listaDetalleEntidad;

        public ObservableCollection<CedulaPartidasModelo> listaDetalleEntidad
        {
            get
            {
                return _listaDetalleEntidad;
            }
            set
            {
                if (_listaDetalleEntidad == value) return;

                _listaDetalleEntidad = value;

                RaisePropertyChanged(listaDetalleEntidadPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaClasePartidas

        public const string listaClasePartidasPropertyName = "listaClasePartidas";

        private ObservableCollection<TipoPartidaModelo> _listaClasePartidas;

        public ObservableCollection<TipoPartidaModelo> listaClasePartidas
        {
            get
            {
                return _listaClasePartidas;
            }
            set
            {
                if (_listaClasePartidas == value) return;

                _listaClasePartidas = value;

                RaisePropertyChanged(listaClasePartidasPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCodigosCuentas

        public const string listaCodigosCuentasPropertyName = "listaCodigosCuentas";

        private ObservableCollection<string> _listaCodigosCuentas;

        public ObservableCollection<string> listaCodigosCuentas
        {
            get
            {
                return _listaCodigosCuentas;
            }
            set
            {
                if (_listaCodigosCuentas == value) return;

                _listaCodigosCuentas = value;
                RaisePropertyChanged(listaCodigosCuentasPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaNombresCuentas

        public const string listaNombresCuentasPropertyName = "listaNombresCuentas";

        private ObservableCollection<string> _listaNombresCuentas;

        public ObservableCollection<string> listaNombresCuentas
        {
            get
            {
                return _listaNombresCuentas;
            }
            set
            {
                if (_listaNombresCuentas == value) return;

                _listaNombresCuentas = value;
                RaisePropertyChanged(listaNombresCuentasPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaCatalogo

        public const string listaCatalogoPropertyName = "listaCatalogo";

        private ObservableCollection<CatalogoCuentasModelo> _listaCatalogo;

        public ObservableCollection<CatalogoCuentasModelo> listaCatalogo
        {
            get
            {
                return _listaCatalogo;
            }
            set
            {
                if (_listaCatalogo == value) return;

                _listaCatalogo = value;
                RaisePropertyChanged(listaCatalogoPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Properties : listaMovimientos

        public const string listaMovimientosPropertyName = "listaMovimientos";

        private ObservableCollection<CedulaMovimientoModelo> _listaMovimientos;

        public ObservableCollection<CedulaMovimientoModelo> listaMovimientos
        {
            get
            {
                return _listaMovimientos;
            }
            set
            {
                if (_listaMovimientos == value) return;

                _listaMovimientos = value;

                RaisePropertyChanged(listaMovimientosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaClaseDocumentos

        public const string listaClaseDocumentosPropertyName = "listaClaseDocumentos";

        private ObservableCollection<TipoCedulaModelo> _listaClaseDocumentos;

        public ObservableCollection<TipoCedulaModelo> listaClaseDocumentos
        {
            get
            {
                return _listaClaseDocumentos;
            }
            set
            {
                if (_listaClaseDocumentos == value) return;

                _listaClaseDocumentos = value;

                RaisePropertyChanged(listaClaseDocumentosPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedTipoCedulaModelo

        public const string selectedTipoCedulaModeloPropertyName = "selectedTipoCedulaModelo";

        private TipoCedulaModelo _selectedTipoCedulaModelo;

        public TipoCedulaModelo selectedTipoCedulaModelo
        {
            get
            {
                return _selectedTipoCedulaModelo;
            }

            set
            {
                if (_selectedTipoCedulaModelo == value) return;

                _selectedTipoCedulaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedTipoCedulaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedClasePartidaModelo

        public const string selectedClasePartidaModeloPropertyName = "selectedClasePartidaModelo";

        private TipoPartidaModelo _selectedClasePartidaModelo;

        public TipoPartidaModelo selectedClasePartidaModelo
        {
            get
            {
                return _selectedClasePartidaModelo;
            }

            set
            {
                if (_selectedClasePartidaModelo == value) return;

                _selectedClasePartidaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedClasePartidaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionTipoCedulaModelo

        public const string eleccionTipoCedulaModeloPropertyName = "eleccionTipoCedulaModelo";

        private TipoCedulaModelo _eleccionTipoCedulaModelo;

        public TipoCedulaModelo eleccionTipoCedulaModelo
        {
            get
            {
                return _eleccionTipoCedulaModelo;
            }

            set
            {
                if (_eleccionTipoCedulaModelo == value) return;

                _eleccionTipoCedulaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionTipoCedulaModeloPropertyName);
            }
        }

        #endregion


        #region Propiedades : numPartida 

        public const string numPartidaPropertyName = "numPartida";

        private string _numPartida = string.Empty;


        public string numPartida
        {
            get
            {
                return _numPartida;
            }
            set
            {
                if (_numPartida == value)
                {
                    return;
                }
                _numPartida = value;
                RaisePropertyChanged(numPartidaPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private CedulaModelo _currentEntidad;

        public CedulaModelo currentEntidad
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

        #region ViewModel Property : currentDetalleEntidad

        public const string currentDetalleEntidadPropertyName = "currentDetalleEntidad";

        private CedulaPartidasModelo _currentDetalleEntidad;

        public CedulaPartidasModelo currentDetalleEntidad
        {
            get
            {
                return _currentDetalleEntidad;
            }

            set
            {
                if (_currentDetalleEntidad == value) return;

                _currentDetalleEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentDetalleEntidadPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentMovimientos

        public const string currentMovimientosPropertyName = "currentMovimientos";

        private CedulaMovimientoModelo _currentMovimientos;

        public CedulaMovimientoModelo currentMovimientos
        {
            get
            {
                return _currentMovimientos;
            }

            set
            {
                if (_currentMovimientos == value) return;

                _currentMovimientos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentMovimientosPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Property : currentUsuario UsuarioModelo

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

        #region ViewModel Property : currentClaseDocumento

        public const string currentClaseDocumentoPropertyName = "currentClaseDocumento";

        private TipoCedulaModelo _currentClaseDocumento;

        public TipoCedulaModelo currentClaseDocumento
        {
            get
            {
                return _currentClaseDocumento;
            }

            set
            {
                if (_currentClaseDocumento == value) return;

                _currentClaseDocumento = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentClaseDocumentoPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentUsuarioModelo UsuarioModelo

        public const string currentUsuarioModeloPropertyName = "currentUsuarioModelo";

        private UsuarioModelo _currentUsuarioModelo;

        public UsuarioModelo currentUsuarioModelo
        {
            get
            {
                return _currentUsuarioModelo;
            }

            set
            {
                if (_currentUsuarioModelo == value) return;

                _currentUsuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentUsuarioModeloPropertyName);
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

        #region visibilidadPlantilla

        public const string visibilidadPlantillaPropertyName = "visibilidadPlantilla";

        private Visibility _visibilidadPlantilla = Visibility.Collapsed;

        public Visibility visibilidadPlantilla
        {
            get
            {
                return _visibilidadPlantilla;
            }

            set
            {
                if (_visibilidadPlantilla == value)
                {
                    return;
                }

                _visibilidadPlantilla = value;
                RaisePropertyChanged(visibilidadPlantillaPropertyName);
            }
        }

        #endregion

        #region visibilidadCrear

        public const string visibilidadCrearPropertyName = "visibilidadCrear";

        private Visibility _visibilidadCrear = Visibility.Collapsed;

        public Visibility visibilidadCrear
        {
            get
            {
                return _visibilidadCrear;
            }

            set
            {
                if (_visibilidadCrear == value)
                {
                    return;
                }

                _visibilidadCrear = value;
                RaisePropertyChanged(visibilidadCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadCopiar

        public const string visibilidadCopiarPropertyName = "visibilidadCopiar";

        private Visibility _visibilidadCopiar = Visibility.Collapsed;

        public Visibility visibilidadCopiar
        {
            get
            {
                return _visibilidadCopiar;
            }

            set
            {
                if (_visibilidadCopiar == value)
                {
                    return;
                }

                _visibilidadCopiar = value;
                RaisePropertyChanged(visibilidadCopiarPropertyName);
            }
        }

        #endregion

        #region visibilidadConsultar

        public const string visibilidadConsultarPropertyName = "visibilidadConsultar";

        private Visibility _visibilidadConsultar = Visibility.Collapsed;

        public Visibility visibilidadConsultar
        {
            get
            {
                return _visibilidadConsultar;
            }

            set
            {
                if (_visibilidadConsultar == value)
                {
                    return;
                }

                _visibilidadConsultar = value;
                RaisePropertyChanged(visibilidadConsultarPropertyName);
            }
        }

        #endregion

        #region visibilidadEditar

        public const string visibilidadEditarPropertyName = "visibilidadEditar";

        private Visibility _visibilidadEditar = Visibility.Collapsed;

        public Visibility visibilidadEditar
        {
            get
            {
                return _visibilidadEditar;
            }

            set
            {
                if (_visibilidadEditar == value)
                {
                    return;
                }

                _visibilidadEditar = value;
                RaisePropertyChanged(visibilidadEditarPropertyName);
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

        #region visibilidad botones  inferiores

        #region visibilidadReferenciar

        public const string visibilidadReferenciarPropertyName = "visibilidadReferenciar";

        private Visibility _visibilidadReferenciar = Visibility.Visible;

        public Visibility visibilidadReferenciar
        {
            get
            {
                return _visibilidadReferenciar;
            }

            set
            {
                if (_visibilidadReferenciar == value)
                {
                    return;
                }

                _visibilidadReferenciar = value;
                RaisePropertyChanged(visibilidadReferenciarPropertyName);
            }
        }

        #endregion

        #region  visibilidadAprobar

        public const string visibilidadAprobarPropertyName = "visibilidadAprobar";

        private Visibility _visibilidadAprobar = Visibility.Visible;

        public Visibility visibilidadAprobar
        {
            get
            {
                return _visibilidadAprobar;
            }

            set
            {
                if (_visibilidadAprobar == value)
                {
                    return;
                }

                _visibilidadAprobar = value;
                RaisePropertyChanged(visibilidadAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadSupervisar

        public const string visibilidadSupervisarPropertyName = "visibilidadSupervisar";

        private Visibility _visibilidadSupervisar = Visibility.Visible;

        public Visibility visibilidadSupervisar
        {
            get
            {
                return _visibilidadSupervisar;
            }

            set
            {
                if (_visibilidadSupervisar == value)
                {
                    return;
                }

                _visibilidadSupervisar = value;
                RaisePropertyChanged(visibilidadSupervisarPropertyName);
            }
        }

        #endregion


        #region visibilidadCerrar

        public const string visibilidadCerrarPropertyName = "visibilidadCerrar";

        private Visibility _visibilidadCerrar = Visibility.Visible;

        public Visibility visibilidadCerrar
        {
            get
            {
                return _visibilidadCerrar;
            }

            set
            {
                if (_visibilidadCerrar == value)
                {
                    return;
                }

                _visibilidadCerrar = value;
                RaisePropertyChanged(visibilidadCerrarPropertyName);
            }
        }

        #endregion


        #endregion

        #region visibilidadContenido

        #region visibilidadReferencia

        public const string visibilidadReferenciaPropertyName = "visibilidadReferencia";

        private Visibility _visibilidadReferencia = Visibility.Visible;

        public Visibility visibilidadReferencia
        {
            get
            {
                return _visibilidadReferencia;
            }

            set
            {
                if (_visibilidadReferencia == value)
                {
                    return;
                }

                _visibilidadReferencia = value;
                RaisePropertyChanged(visibilidadReferenciaPropertyName);
            }
        }

        #endregion

        #region visibilidadFechaCierre

        public const string visibilidadFechaCierrePropertyName = "visibilidadFechaCierre";

        private Visibility _visibilidadFechaCierre = Visibility.Visible;

        public Visibility visibilidadFechaCierre
        {
            get
            {
                return _visibilidadFechaCierre;
            }

            set
            {
                if (_visibilidadFechaCierre == value)

                {
                    return;
                }

                _visibilidadFechaCierre = value;
                RaisePropertyChanged(visibilidadFechaCierrePropertyName);
            }
        }

        #endregion

        #region visibilidadFechaSupervision

        public const string visibilidadFechaSupervisionPropertyName = "visibilidadFechaSupervision";

        private Visibility _visibilidadFechaSupervision = Visibility.Visible;

        public Visibility visibilidadFechaSupervision
        {
            get
            {
                return _visibilidadFechaSupervision;
            }

            set
            {
                if (_visibilidadFechaSupervision == value)
                {
                    return;
                }

                _visibilidadFechaSupervision = value;
                RaisePropertyChanged(visibilidadFechaSupervisionPropertyName);
            }
        }

        #endregion

        #region visibilidadFechaAprobacion

        public const string visibilidadFechaAprobacionPropertyName = "visibilidadFechaAprobacion";

        private Visibility _visibilidadFechaAprobacion = Visibility.Visible;

        public Visibility visibilidadFechaAprobacion
        {
            get
            {
                return _visibilidadFechaAprobacion;
            }

            set
            {
                if (_visibilidadFechaAprobacion == value)
                {
                    return;
                }

                _visibilidadFechaAprobacion = value;
                RaisePropertyChanged(visibilidadFechaAprobacionPropertyName);
            }
        }

        #endregion

        #region visibilidadFechaEvaluacion

        public const string visibilidadFechaEvaluacionPropertyName = "visibilidadFechaEvaluacion";

        private Visibility _visibilidadFechaEvaluacion = Visibility.Visible;

        public Visibility visibilidadFechaEvaluacion
        {
            get
            {
                return _visibilidadFechaEvaluacion;
            }

            set
            {
                if (_visibilidadFechaEvaluacion == value)
                {
                    return;
                }

                _visibilidadFechaEvaluacion = value;
                RaisePropertyChanged(visibilidadFechaEvaluacionPropertyName);
            }
        }

        #endregion

        #endregion

        #region visibilidadClaseDocumento

        public const string visibilidadClaseDocumentoPropertyName = "visibilidadClaseDocumento";

        private Visibility _visibilidadClaseDocumento = Visibility.Collapsed;

        public Visibility visibilidadClaseDocumento
        {
            get
            {
                return _visibilidadClaseDocumento;
            }

            set
            {
                if (_visibilidadClaseDocumento == value)
                {
                    return;
                }

                _visibilidadClaseDocumento = value;
                RaisePropertyChanged(visibilidadClaseDocumentoPropertyName);
            }
        }

        #endregion


        #region visibilidadConclusiones

        public const string visibilidadConclusionesPropertyName = "visibilidadConclusiones";

        private Visibility _visibilidadConclusiones = Visibility.Collapsed;

        public Visibility visibilidadConclusiones
        {
            get
            {
                return _visibilidadConclusiones;
            }

            set
            {
                if (_visibilidadConclusiones == value)
                {
                    return;
                }

                _visibilidadConclusiones = value;
                RaisePropertyChanged(visibilidadConclusionesPropertyName);
            }
        }

        #endregion

        #region visibilidadCuerpo

        public const string visibilidadCuerpoPropertyName = "visibilidadCuerpo";

        private Visibility _visibilidadCuerpo = Visibility.Collapsed;

        public Visibility visibilidadCuerpo
        {
            get
            {
                return _visibilidadCuerpo;
            }

            set
            {
                if (_visibilidadCuerpo == value)
                {
                    return;
                }

                _visibilidadCuerpo = value;
                RaisePropertyChanged(visibilidadCuerpoPropertyName);
            }
        }

        #endregion

        #region visibilidadBalance

        public const string visibilidadBalancePropertyName = "visibilidadBalance";

        private Visibility _visibilidadBalance = Visibility.Collapsed;

        public Visibility visibilidadBalance
        {
            get
            {
                return _visibilidadBalance;
            }

            set
            {
                if (_visibilidadBalance == value)
                {
                    return;
                }

                _visibilidadBalance = value;
                RaisePropertyChanged(visibilidadBalancePropertyName);
            }
        }

        #endregion



        #region visibilidadTareas

        public const string visibilidadTareasPropertyName = "visibilidadTareas";

        private Visibility _visibilidadTareas = Visibility.Collapsed;

        public Visibility visibilidadTareas
        {
            get
            {
                return _visibilidadTareas;
            }

            set
            {
                if (_visibilidadTareas == value)
                {
                    return;
                }

                _visibilidadTareas = value;
                RaisePropertyChanged(visibilidadTareasPropertyName);
            }
        }

        #endregion

        #region visibilidadRespuesta

        public const string visibilidadRespuestaPropertyName = "visibilidadRespuesta";

        private Visibility _visibilidadRespuesta = Visibility.Collapsed;

        public Visibility visibilidadRespuesta
        {
            get
            {
                return _visibilidadRespuesta;
            }

            set
            {
                if (_visibilidadRespuesta == value)
                {
                    return;
                }

                _visibilidadRespuesta = value;
                RaisePropertyChanged(visibilidadRespuestaPropertyName);
            }
        }

        #endregion

        #region accesibilidad

        #region ViewModel Properties : accesibilidadReferencia

        public const string accesibilidadReferenciaPropertyName = "accesibilidadReferencia";

        private bool _accesibilidadReferencia;

        public bool accesibilidadReferencia
        {
            get
            {
                return _accesibilidadReferencia;
            }

            set
            {
                if (_accesibilidadReferencia == value)
                {
                    return;
                }

                _accesibilidadReferencia = value;
                RaisePropertyChanged(accesibilidadReferenciaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadCuerpo

        public const string accesibilidadCuerpoPropertyName = "accesibilidadCuerpo";

        private bool _accesibilidadCuerpo;

        public bool accesibilidadCuerpo
        {
            get
            {
                return _accesibilidadCuerpo;
            }

            set
            {
                if (_accesibilidadCuerpo == value)
                {
                    return;
                }

                _accesibilidadCuerpo = value;
                RaisePropertyChanged(accesibilidadCuerpoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : enableTareas

        public const string enableTareasPropertyName = "enableTareas";

        private bool _enableTareas;

        public bool enableTareas
        {
            get
            {
                return _enableTareas;
            }

            set
            {
                if (_enableTareas == value)
                {
                    return;
                }

                _enableTareas = value;
                RaisePropertyChanged(enableTareasPropertyName);
            }
        }

        #endregion



        #region ViewModel Properties : accesibilidadCierre

        public const string accesibilidadCierrePropertyName = "accesibilidadCierre";

        private bool _accesibilidadCierre;

        public bool accesibilidadCierre
        {
            get
            {
                return _accesibilidadCierre;
            }

            set
            {
                if (_accesibilidadCierre == value)
                {
                    return;
                }

                _accesibilidadCierre = value;
                RaisePropertyChanged(accesibilidadCierrePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadClaseCedula

        public const string accesibilidadClaseCedulaPropertyName = "accesibilidadClaseCedula";

        private bool _accesibilidadClaseCedula;

        public bool accesibilidadClaseCedula
        {
            get
            {
                return _accesibilidadClaseCedula;
            }

            set
            {
                if (_accesibilidadClaseCedula == value)
                {
                    return;
                }

                _accesibilidadClaseCedula = value;
                RaisePropertyChanged(accesibilidadClaseCedulaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadRespuesta

        public const string accesibilidadRespuestaPropertyName = "accesibilidadRespuesta";

        private bool _accesibilidadRespuesta;

        public bool accesibilidadRespuesta
        {
            get
            {
                return _accesibilidadRespuesta;
            }

            set
            {
                if (_accesibilidadRespuesta == value)
                {
                    return;
                }

                _accesibilidadRespuesta = value;
                RaisePropertyChanged(accesibilidadRespuestaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadSupervision

        public const string accesibilidadSupervisionPropertyName = "accesibilidadSupervision";

        private bool _accesibilidadSupervision;

        public bool accesibilidadSupervision
        {
            get
            {
                return _accesibilidadSupervision;
            }

            set
            {
                if (_accesibilidadSupervision == value)
                {
                    return;
                }

                _accesibilidadSupervision = value;
                RaisePropertyChanged(accesibilidadSupervisionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties :  accesibilidadAprobacion

        public const string accesibilidadAprobacionPropertyName = "accesibilidadAprobacion";

        private bool _accesibilidadAprobacion;

        public bool accesibilidadAprobacion
        {
            get
            {
                return _accesibilidadAprobacion;
            }

            set
            {
                if (_accesibilidadAprobacion == value)
                {
                    return;
                }

                _accesibilidadAprobacion = value;
                RaisePropertyChanged(accesibilidadAprobacionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties :  accesibilidadEvaluacion

        public const string accesibilidadEvaluacionPropertyName = "accesibilidadEvaluacion";

        private bool _accesibilidadEvaluacion;

        public bool accesibilidadEvaluacion
        {
            get
            {
                return _accesibilidadEvaluacion;
            }

            set
            {
                if (_accesibilidadEvaluacion == value)
                {
                    return;
                }

                _accesibilidadEvaluacion = value;
                RaisePropertyChanged(accesibilidadEvaluacionPropertyName);
            }
        }

        #endregion

        #region identifica el fin de la carga inicial : finInicializacion

        public const string finInicializacionPropertyName = "finInicializacion";

        private bool _finInicializacion;

        public bool finInicializacion
        {
            get
            {
                return _finInicializacion;
            }

            set
            {
                if (_finInicializacion == value)
                {
                    return;
                }

                _finInicializacion = value;
                RaisePropertyChanged(finInicializacionPropertyName);
            }
        }

        #endregion

        #region fechacierre

        public const string fechacierrePropertyName = "fechacierre";

        private DateTime _fechacierre = DateTime.Now;

        public DateTime fechacierre
        {
            get
            {
                return _fechacierre;
            }

            set
            {
                if (_fechacierre == value)
                {
                    return;
                }

                _fechacierre = value;
                RaisePropertyChanged(fechacierrePropertyName);
            }
        }

        #endregion

        #region fechapartida

        public const string fechapartidaPropertyName = "fechapartida";

        private DateTime _fechapartida = DateTime.Now;

        public DateTime fechapartida
        {
            get
            {
                return _fechapartida;
            }

            set
            {
                if (_fechapartida == value)
                {
                    return;
                }

                _fechapartida = value;
                RaisePropertyChanged(fechapartidaPropertyName);
            }
        }

        #endregion

        #region fechasupervision

        public const string fechasupervisionPropertyName = "fechasupervision";

        private DateTime _fechasupervision = DateTime.Now;

        public DateTime fechasupervision
        {
            get
            {
                return _fechasupervision;
            }

            set
            {
                if (_fechasupervision == value)
                {
                    return;
                }

                _fechasupervision = value;
                RaisePropertyChanged(fechasupervisionPropertyName);
            }
        }

        #endregion

        #region fechaaprobacion

        public const string fechaaprobacionPropertyName = "fechaaprobacion";

        private DateTime _fechaaprobacion = DateTime.Now;

        public DateTime fechaaprobacion
        {
            get
            {
                return _fechaaprobacion;
            }

            set
            {
                if (_fechaaprobacion == value)
                {
                    return;
                }

                _fechaaprobacion = value;
                RaisePropertyChanged(fechaaprobacionPropertyName);
            }
        }

        #endregion


        #region usuariocerro

        public const string usuariocerroPropertyName = "usuariocerro";

        private string _usuariocerro = string.Empty;

        public string usuariocerro
        {
            get
            {
                return _usuariocerro;
            }

            set
            {
                if (_usuariocerro == value)
                {
                    return;
                }

                _usuariocerro = value;
                RaisePropertyChanged(usuariocerroPropertyName);
            }
        }

        #endregion

        #region usuariosuperviso

        public const string usuariosupervisoPropertyName = "usuariosuperviso";

        private string _usuariosuperviso = string.Empty;

        public string usuariosuperviso
        {
            get
            {
                return _usuariosuperviso;
            }

            set
            {
                if (_usuariosuperviso == value)
                {
                    return;
                }

                _usuariosuperviso = value;
                RaisePropertyChanged(usuariosupervisoPropertyName);
            }
        }

        #endregion

        #region usuarioaprobo

        public const string usuarioaproboPropertyName = "usuarioaprobo";

        private string _usuarioaprobo = string.Empty;

        public string usuarioaprobo
        {
            get
            {
                return _usuarioaprobo;
            }

            set
            {
                if (_usuarioaprobo == value)
                {
                    return;
                }

                _usuarioaprobo = value;
                RaisePropertyChanged(usuarioaproboPropertyName);
            }
        }

        #endregion



        #endregion

        #endregion

        #region ViewModel Commands
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand actualizarCommand { get; set; }
        public RelayCommand<TipoPartidaModelo> SelectionTipoPartidaCommand { get; set; }

        #region Importacion

        public RelayCommand CancelarProgramaEncargoCommand { get; set; }//Seleccion desde el encargo
        public RelayCommand SeleccionProgramaEncargoCommand { get; set; }//seleccion desde el encargo

        public RelayCommand CancelarPlantillaCommand { get; set; }//Seleccion desde las plantillas
        public RelayCommand SeleccionPlantillaCommand { get; set; }//seleccion desde las plantillas

        public RelayCommand<TipoCedulaModelo> SeleccionClaseDocumentoCommand { get; set; }

        public RelayCommand<CedulaModelo> SelectionCarpetaChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateChangedCommand { get; set; }
        public RelayCommand<DateTime> SelectedDatePartidaChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateSupervisionChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateAprobacionCommand { get; set; }

        
        public RelayCommand<CedulaMovimientoModelo> SelectionCuentaChangedCommand { get; set; }

        public RelayCommand<string> SelectedCodigoChangedCommand { get; set; }

        public RelayCommand<MarcasSimbolos> SelectionSimboloChangedCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }//seleccion desde las plantillas
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }

        public RelayCommand cerrarCommand { get; set; }

        public RelayCommand cmdCargarPdf_Click { get; set; }

        public RelayCommand cmdCargarFuente_Click { get; set; }

        RelayCommand<string> CellEditEndingCommand { get; set; }
        #endregion


        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public AjustesReclasificacionesControllerViewModel()
        {
        }

        public AjustesReclasificacionesControllerViewModel(string origenLlamada)
        {
            finInicializacion = false;
            _isListaCargada = false;
            //Documentacion/Planificacion/Indices
            _origen = origenLlamada;
            _cerradoFinalVentana = false;//Controla el cierre de la ventana
            _maxDescripcion = 40;
            _numeroProcesoCrudRecibido = 0;
            _opcionMenu = 0;
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            //Suscribiendo el mensaje
            _listaClaseDocumentos = new ObservableCollection<TipoCedulaModelo>();
            _listacurrentEntidad = new ObservableCollection<CedulaModelo>();
            _listaDetalleEntidad = new ObservableCollection<CedulaPartidasModelo>();
            _listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>();

            _listaClasePartidas = new ObservableCollection<TipoPartidaModelo>();
            Errors = 0;
            //Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcion, (plantillaIndiceMensaje) => ControlPlantillaIndiceMensaje(plantillaIndiceMensaje));
            RegisterCommands();
            //Recibe un numero para procesar solo el último mensaje
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            dlg = new DialogCoordinator();
            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            _enableTareas = false;
            _visibilidadClaseDocumento = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _visibilidadPlantilla = Visibility.Collapsed;
            _visibilidadBalance = Visibility.Collapsed;
            _visibilidadTareas = Visibility.Collapsed;
            _visibilidadClaseDocumento = Visibility.Collapsed;
            _visibilidadRespuesta = Visibility.Visible;
            _visibilidadConclusiones = Visibility.Visible;
            _visibilidadCuerpo = Visibility.Collapsed;
            _selectedTipoCedulaModelo = new TipoCedulaModelo();
            _eleccionTipoCedulaModelo = new TipoCedulaModelo();

            _currentEncargo = new EncargoModelo();
            _currentEntidad = new CedulaModelo();
            _currentDetalleEntidad = new CedulaPartidasModelo();
            _currentMovimientos = new CedulaMovimientoModelo();
            _eleccionTipoCedulaModelo = new TipoCedulaModelo();
            _selectedClasePartidaModelo = new TipoPartidaModelo();
            _numPartida=string.Empty;
            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            switch (origenLlamada)
            {
                case "DocumentacionCedulaAjustesReclasificaciones"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosEncargoCedulaAjustesYReclasificacionesController";
                    _tokenRecepcion = "datosEncargoCedulaAjustesYReclasificaciones"; //Modificado

                    _tokenRecepcionCodigo = "CedulaAjustesYReclasificaciones"+"Codigo";
                    _tokenRecepcionCuenta = "CedulaAjustesYReclasificaciones" + "Cuenta";
                    _tokenRecepcionCargos = "CedulaAjustesYReclasificaciones" + "Cargos";
                    _tokenRecepcionAbonos = "CedulaAjustesYReclasificaciones" + "Abonos";

                    #endregion
                    break;
                case "DocumentacionCedulasAjustesResumen"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosEncargoCedulasAjustesControllerMenuPrincipal";
                    _tokenRecepcion = "datosEncargoCedulasAjustesMenuPrincipal"; //Modificado

                    _tokenRecepcionCodigo = "CedulaAjustesYReclasificaciones" + "Codigo";
                    _tokenRecepcionCuenta = "CedulaAjustesYReclasificaciones" + "Cuenta";
                    _tokenRecepcionCargos = "CedulaAjustesYReclasificaciones" + "Cargos";
                    _tokenRecepcionAbonos = "CedulaAjustesYReclasificaciones" + "Abonos";
                    #endregion
                    break;
            }
            //Suscribiendo el mensaje
            Messenger.Default.Register<AjustesYReclasificacionesMsj>(this, tokenRecepcion, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            _currentEncargo = new EncargoModelo();

            #region Importacion

            _listaClasePartidas = new ObservableCollection<TipoPartidaModelo>(TipoPartidaModelo.GetAll());
            _listaNombresCuentas = new ObservableCollection<string>();
            _listaCodigosCuentas = new ObservableCollection<string>();
            _listaCatalogo = new ObservableCollection<CatalogoCuentasModelo>();

            #endregion

            _fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
            _fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
            _fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
            _fechapartida=  new DateTime((DateTime.Now.Year - 1), 12, 31);

            #region Inicializacion simbolos

            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            #endregion
        }

        private void ControlDatosMsj(AjustesYReclasificacionesMsj datosMsj)
        {
            //Errors = 0;
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            tokenEnvio = datosMsj.tokenRespuestaController;
            currentDetalleEntidad = datosMsj.entidadDetalle;
            //FuenteLlamada = datosMsj.fuenteLlamado;
            listacurrentEntidad = datosMsj.listaMaestroModelo;
            listaDetalleEntidad = datosMsj.listaDetalle;
            //Cargor catalogo
            //listaCatalogo = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllByIdScForDisplayToPartidas(((int)currentEncargo.idsc)));
            listaCatalogo = CatalogoCuentasModelo.GetAllByIdScForDisplayToPartidas(((int)currentEncargo.idsc));
            //Lista de codigos
            foreach( CatalogoCuentasModelo item in listaCatalogo)
            {
                switch (item.nombreClaseCuenta.ToUpper().Trim())
                {
                    case "CUENTA":
                        listaCodigosCuentas.Add(item.codigocc);
                        listaNombresCuentas.Add(item.nombreCuenta);
                        break;
                    case "SUB-CUENTA":
                        listaCodigosCuentas.Add(item.codigocc);
                        listaNombresCuentas.Add(item.nombreCuenta);
                        break;
                    case "SUB-SUB-CUENTA":
                        listaCodigosCuentas.Add(item.codigocc);
                        listaNombresCuentas.Add(item.nombreCuenta);
                        break;
                    case "SUB-SUB-SUB-CUENTA":
                        listaCodigosCuentas.Add(item.codigocc);
                        listaNombresCuentas.Add(item.nombreCuenta);
                        break;
                    case "SUB-SUB-SUB-SUB-CUENTA":
                        listaCodigosCuentas.Add(item.codigocc);
                        listaNombresCuentas.Add(item.nombreCuenta);
                        break;
                }
            }
            //Lista de cuentas
            listaNombresCuentas.Insert(0, "Ninguna");
            currentEntidad = datosMsj.entidadMaestroModelo;
            if (currentEntidad.idtc == 0 || (currentEntidad.idtc != 1
                && currentEntidad.idtc != 2 && currentEntidad.idtc != 3
                && currentEntidad.idtc != 5 && currentEntidad.idtc != 6))
            {
                //1; "Sumaria"; "A"; TRUE
                //2; "Analítica"; "A"; TRUE
                //3; "De detalle"; "A"; TRUE
                //4; "De variaciones"; "A"; TRUE
                //5; "Cumplimiento legal"; "A"; TRUE
                //6; "Hallazgos"; "A"; TRUE
                //7; "Notas"; "A"; TRUE
                //8; "Correspondencia"; "A"; TRUE
                //9; "Reuniones"; "A"; TRUE
                //10; "Correspondencias"; "A"; TRUE
                //11; "Expediente"; "A"; TRUE
                //12; "Cronograma"; "A"; TRUE
                //13; "Marcas"; "A"; TRUE
                //14; "Confirmaciones"; "A"; TRUE
                //15; "Ajustes y reclasificaciones"; "A"; TRUE
                //16; "Expediente"; "A"; TRUE
                //17; "Conclusiones"; "A"; TRUE
                //18; "Otras"; "A"; 
                visibilidadClaseDocumento = Visibility.Visible;
                listaClaseDocumentos = new ObservableCollection<TipoCedulaModelo>(TipoCedulaModelo.GetAllOtros());
            }
            else
            {
                visibilidadClaseDocumento = Visibility.Collapsed;
                listaClaseDocumentos = new ObservableCollection<TipoCedulaModelo>(TipoCedulaModelo.GetAll());
            }

            llenadoDatos(datosMsj.opcionMenuCrud);
            switch (datosMsj.opcionMenuCrud)
            {
                case 1://Crear 
                    encabezadoPantalla = "Proporcione los datos requeridos";
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    visibilidadCuerpo = Visibility.Visible;
                    visibilidadBalance = Visibility.Collapsed;
                    visibilidadRespuesta = Visibility.Collapsed;
                    accesibilidadCuerpo = true;
                    accesibilidadClaseCedula = false;
                    accesibilidadRespuesta = true;
                    enableTareas = true;
                    numPartida = "Partida #" + currentDetalleEntidad.numeropartida;
                    selectedClasePartidaModelo = listaClasePartidas[0];
                    currentDetalleEntidad.idtp = selectedClasePartidaModelo.id;
                    currentDetalleEntidad.fechapartida= MetodosModelo.homologacionFecha(fechapartida.ToShortDateString());
                    listaMovimientos = CedulaMovimientoModelo.GetListaVacia(currentEncargo);
                    break;
                case 2://Editar, no sera activada
                            encabezadoPantalla = "Edite los datos";
                            visibilidadCrear = Visibility.Collapsed;
                            visibilidadEditar = Visibility.Visible;
                            visibilidadConsultar = Visibility.Collapsed;
                            visibilidadCopiar = Visibility.Collapsed;
                            visibilidadCuerpo = Visibility.Visible;
                            accesibilidadCuerpo = true;
                            accesibilidadClaseCedula = false;
                            accesibilidadRespuesta = false;
                            enableTareas = true;
                            numPartida = "Partida #" + currentDetalleEntidad.numeropartida;
                            listaMovimientos = CedulaMovimientoModelo.GetListaComplementaria(currentEncargo,currentDetalleEntidad.listaCedulaMovimientoModelo,currentDetalleEntidad);
                    break;
                case 3://Consultar
                    encabezadoPantalla = "Consulta tarea";
                    encabezadoPantalla = "Edite su respuesta";
                    visibilidadCuerpo = Visibility.Visible;
                    visibilidadRespuesta = Visibility.Visible;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    accesibilidadCuerpo = false;
                    accesibilidadClaseCedula = false;
                    accesibilidadRespuesta = false;
                    enableTareas = true;
                    numPartida = "Partida #" + currentDetalleEntidad.numeropartida;
                    listaMovimientos = CedulaMovimientoModelo.GetListaComplementaria(currentEncargo, currentDetalleEntidad.listaCedulaMovimientoModelo, currentDetalleEntidad);
                    break;
                case 6://Importar de las plantillas (No se usa)

                    break;
                case 7://Importar de programas de otros encargos
                       //Seleccion de programa
                    break;
                case 8://Referenciar 
                    encabezadoPantalla = "Introduzca la referencia para la matriz";
                    #region contenido

                    accesibilidadCuerpo = true;
                    accesibilidadReferencia = true;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = false;
                    accesibilidadEvaluacion = false;

                    #endregion

                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Visible;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Collapsed;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Visible;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;

                    #endregion
                    break;
                case 10://Cerrar el papel 
                    encabezadoPantalla = "Introduzca la fecha de cierre a utilizar";
                    #region contenido
                    accesibilidadReferencia = false;
                    accesibilidadCierre = true;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = false;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Visible;
                    visibilidadFechaSupervision = Visibility.Collapsed;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Visible;

                    #endregion
                    break;
                case 11://Finaliza la  supervisión
                    encabezadoPantalla = "Introduzca la fecha de la supervisión";
                    #region contenido


                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = true;
                    accesibilidadAprobacion = false;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Visible;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;

                    #endregion
                    break;
                case 12://Cerrar el papel 
                    encabezadoPantalla = "Introduzca la fecha de cierre a utilizar";
                    #region contenido


                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = true;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Visible;
                    visibilidadFechaAprobacion = Visibility.Visible;
                    visibilidadFechaEvaluacion = Visibility.Visible;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Visible;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;

                    #endregion
                    break;
                case 14://Responder
                    break;

            }
            Messenger.Default.Unregister<AjustesYReclasificacionesMsj>(this, tokenRecepcion);
            finComando();
            finInicializacion = true;//Termino la carga se activan los comando
        }


        private async void llenadoDatos(int comando)
        {
            if (comando != 1 || comando != 2 || comando != 3)
            {
                if (currentEntidad.idcedula != 0)
                {
                    selectedTipoCedulaModelo = listaClaseDocumentos.Single(i => i.id == currentEntidad.idtc);
                    currentClaseDocumento = selectedTipoCedulaModelo;
                    visibilidadClaseDocumento = Visibility.Visible;
                    if (currentDetalleEntidad != null && currentDetalleEntidad.idtp != null)
                    {
                        selectedClasePartidaModelo = listaClasePartidas.Single(x => x.id == currentDetalleEntidad.idtp);//Clase de partida
                    }
                }
                else
                {
                    selectedTipoCedulaModelo = new TipoCedulaModelo();
                    currentClaseDocumento = selectedTipoCedulaModelo;
                }
                //Llenar fecha de cierre
                if (currentEntidad.fechacierre != null && currentEntidad.fechacierre != "")
                {
                    try
                    {
                        fechacierre = MetodosModelo.convertirFecha(currentEntidad.fechacierre);
                    }
                    catch (Exception)
                    {
                        //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                        await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                        fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
                    }
                }
                else
                {
                    fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
                }
                if (currentDetalleEntidad != null)
                {
                    if (currentDetalleEntidad.fechapartida != null && currentDetalleEntidad.fechapartida != "")
                    {
                        try
                        {
                            fechapartida = MetodosModelo.convertirFecha(currentDetalleEntidad.fechapartida);
                        }
                        catch (Exception)
                        {
                            //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                            await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                            fechapartida = new DateTime((DateTime.Now.Year - 1), 12, 31); ;
                        }
                    }
                    else
                    {
                        fechapartida = new DateTime((DateTime.Now.Year - 1), 12, 31);
                    }
                }
                //Llenar fecha de supervision
                if (currentEntidad.fechasupervision != null && currentEntidad.fechasupervision != "")
                {
                    try
                    {
                        fechasupervision = MetodosModelo.convertirFecha(currentEntidad.fechasupervision);
                    }
                    catch (Exception)
                    {
                        //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                        await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                        fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
                    }
                }
                else
                {
                    fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
                }
                //Llenar fecha de aprobacion
                if (currentEntidad.fechaaprobacion != null && currentEntidad.fechaaprobacion != "")
                {
                    try
                    {
                        fechaaprobacion = MetodosModelo.convertirFecha(currentEntidad.fechaaprobacion);
                    }
                    catch (Exception)
                    {
                        //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                        await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                        fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
                    }
                }
                else
                {
                    fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
                }
            }
        }
        #endregion



        private async void ImportarDeEncargos()
        {
            await mensajeAutoCerrado("No programado", "No utilizado", 2);
        }


        private async void Cancelar()
        {
            if (origen == null)
            {
                // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
                //Debe cerrar el sistemapi
                await dlg.ShowMessageAsync(this, "Operación cancelada", "");
                cerradoFinalVentana = true;
                CloseWindow();
                enviarMensajeHabilitar();
            }
            else
            {
                // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
                //Debe cerrar el sistema
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                fuenteCierre = 1;
                CloseWindow();
            }

        }

        private void Ok()
        {
            if (origen == null)
            {
                cerradoFinalVentana = true;
                CloseWindow();
                enviarMensajeHabilitar();
            }
            else
            {
                fuenteCierre = 1;
                CloseWindow();

            }
        }

        private void Salir()
        {
            if (origen == null)
            {
                if (!(cerradoFinalVentana))
                {
                    CloseWindow();
                    enviarMensajeHabilitar();
                }
                enviarMensajeFinProceso();//Manda mensaje de cierre
            }
            else
            {
                if (fuenteCierre == 0)
                {
                    accesibilidadWindow = false;
                    Mouse.OverrideCursor = Cursors.Wait;
                    enviarMensajeHabilitar();
                    enviarMensaje();//Cero por cancelamiento
                    fuenteCierre = 3;
                    CloseWindow();
                }
                else
                {
                    if (fuenteCierre == 1)
                    {
                        enviarMensajeHabilitar();
                        enviarMensaje();
                        fuenteCierre = 4;
                    }
                }
            }
        }

        public async void Guardar()
        {
            iniciarComando();
            await verificacion();
            foreach(CedulaMovimientoModelo item in listaMovimientos)
            { 
                if(item.nombreCuenta!=null 
                    && item.nombreCuenta!="" 
                    && item.nombreCuenta!="Ninguna" 
                    && (item.cargomovimiento>0 || item.abonomovimiento>0))
                { 
                CatalogoCuentasModelo temporal = listaCatalogo.SingleOrDefault(x => x.nombreCuenta == item.nombreCuenta);
                item.idencargo = currentDetalleEntidad.idencargo;
                item.idpartida = currentDetalleEntidad.idpartida;
                item.codigocc = temporal.codigocc;
                item.descripcioncc = temporal.descripcioncc;
                item.codigocc = temporal.codigocc;
                item.idcc = temporal.idcc;
                item.ordencc = temporal.ordencc;
                currentDetalleEntidad.listaCedulaMovimientoModelo.Add(item);
                }
            }
            if ( valida())
            {
                if (nombreUnico(currentDetalleEntidad.conceptopartida, listaDetalleEntidad) == 0)
                {
                    try
                    {
                        //Se envian los detalles
                        switch (CedulaPartidasModelo.Insert(currentDetalleEntidad,currentDetalleEntidad.listaCedulaMovimientoModelo))
                        {
                            case 0://No se pudo insertar
                                finComando();
                                await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                break;
                            case 1://Se inserto con éxito
                                await mensajeAutoCerrado("Registro insertado con éxito", "Este mensaje desaparecerá en segundos", 1);
                                fuenteCierre = 1;
                                resultadoProceso = 1;//1 para  crear
                                CloseWindow();
                                break;
                            case -1://Se inserto con éxito
                                await mensajeAutoCerrado("Error al insertar el registro", "Este mensaje desaparecerá en segundos", 1);
                                fuenteCierre = 1;
                                resultadoProceso = 1;//1 para  crear
                                CloseWindow();
                                break;
                            case 2://Se inserto con éxito
                                await mensajeAutoCerrado("Algunos registros del detalle estaban vacios", "Este mensaje desaparecerá en segundos", 1);
                                fuenteCierre = 1;
                                resultadoProceso = 1;//1 para  crear
                                CloseWindow();
                                break;
                            case -2://Se inserto con éxito
                                await mensajeAutoCerrado("Hubo error al insertar algunos elementos", "Este mensaje desaparecerá en segundos", 1);
                                fuenteCierre = 1;
                                resultadoProceso = 1;//1 para  crear
                                CloseWindow();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        MessageBox.Show("No ha sido posible insertar el registro");
                        finComando();
                    }
                }
                else
                {
                    await mensajeAutoCerrado("El nombre ya esta siendo utilizado, ", "seleccione otro nombre", 1);
                    finComando();
                }
            }
            else
            {
                await mensajeAutoCerrado("Hay errores  en los datos", "Revise", 1);
                finComando();
            }
        }

        public async void Copiar()
        {
            await mensajeAutoCerrado("No programado", "No utilizado", 2);
        }

        #endregion

        #region Mensajes

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

        public void enviarMensajeFinProceso()
        {
            //Se crea el mensaje
            mensajeDeCierreCrud mensaje = new mensajeDeCierreCrud();
            mensaje.numeroProcesoCrud = numeroProcesoCrudRecibido;
            numeroProcesoCrudRecibido++;
            Messenger.Default.Send(mensaje, tokenEnvio);
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvio);
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
                if (opcionMenu == 14)
                {
                    bool verifica= valida();
                    evaluar = Errors == 0 &&
                         !string.IsNullOrEmpty(currentDetalleEntidad.conceptopartida)
                         && !string.IsNullOrWhiteSpace(currentDetalleEntidad.conceptopartida)
                         && !string.IsNullOrEmpty(currentDetalleEntidad.comentariopartida)
                         && !string.IsNullOrWhiteSpace(currentDetalleEntidad.comentariopartida)
                         && verifica;
                }
                else
                {
                    evaluar = Errors == 0;
                }
                return evaluar;
            }
        }

        public bool CanSaveDocumentacion()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = Errors == 0;
                return evaluar;
            }
        }

        #endregion

        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            CopiarCommand = new RelayCommand(Copiar, CanSave);
            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanNuevo);
            //GuardarCommand = new RelayCommand(GuardarD, CanSaveDocumentacion);

            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);

            actualizarCommand = new RelayCommand(actualizaSumas);

            SelectionTipoPartidaCommand = new RelayCommand<TipoPartidaModelo>(async entidad =>
            {
                if (entidad == null) return;
                if (entidad.id != 0)
                {
                    currentDetalleEntidad.idtp = entidad.id;
                    currentDetalleEntidad.descripciontp = entidad.descripcion;
                    await verificacion();//actualiza sumas
                }
            });
            SeleccionClaseDocumentoCommand = new RelayCommand<TipoCedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.idtc = entidad.id;
            });
            //cmdCargarPdf_Click = new RelayCommand(cmdCargarPDF);
            //cmdCargarFuente_Click = new RelayCommand(cmdCargarFuente);

            CancelarPlantillaCommand = new RelayCommand(Cancelar);
            //SeleccionPlantillaCommand = new RelayCommand(ImportarPlantillas, canImport);
            CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
            SeleccionClaseDocumentoCommand = new RelayCommand<TipoCedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.idtc = entidad.id;
            });


            SelectedDateChangedCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechacierre != null)
                    {
                        currentEntidad.fechacierre = MetodosModelo.homologacionFecha(fechacierre.ToShortDateString());
                        currentEntidad.usuariocerro = currentUsuario.inicialesusuario;
                    }
                }
            });

            SelectedDatePartidaChangedCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechapartida != null)
                    {
                        currentDetalleEntidad.fechapartida = MetodosModelo.homologacionFecha(fechapartida.ToShortDateString());
                    }
                }
            });
            SelectedDateSupervisionChangedCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechasupervision != null)
                    {
                        currentEntidad.fechasupervision = MetodosModelo.homologacionFecha(fechasupervision.ToShortDateString());
                        currentEntidad.usuariosuperviso = currentUsuario.inicialesusuario;
                    }
                }
            });

            SelectedDateAprobacionCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechaaprobacion != null)
                    {
                        currentEntidad.fechaaprobacion = MetodosModelo.homologacionFecha(fechaaprobacion.ToShortDateString());
                        currentEntidad.usuarioaprobo = currentUsuario.inicialesusuario;
                    }
                }
            });


            SelectedCodigoChangedCommand = new RelayCommand<string>(async entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechaaprobacion != null)
                    {
                        try
                        {
                            CatalogoCuentasModelo temporal = listaCatalogo.SingleOrDefault(x => x.codigocc == entidad);
                            currentMovimientos.descripcioncc = temporal.descripcioncc;
                            currentMovimientos.codigocc = temporal.codigocc;
                            currentMovimientos.idcc = temporal.idcc;
                            currentMovimientos.ordencc = temporal.ordencc;
                        }
                        catch (Exception e)
                        {
                            await mensajeAutoCerrado("Error en seleccion", "" + e, 2);
                        }
                    }
                }
            });

            SelectionCuentaChangedCommand = new RelayCommand<CedulaMovimientoModelo>(async entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    currentMovimientos = entidad;
                //Actualiacion  de sumas
                //Correccion de listas
                await verificacion();
                }

            });

            referenciarCommand = new RelayCommand(Modificar, CanReferenciarSave);//Para guardar la referencia

            supervisarCommand = new RelayCommand(Modificar, CanSupervisar);//Para guardar la referencia

            aprobarCommand = new RelayCommand(Modificar, CanAprobar);//Para guardar la referencia

            cerrarCommand = new RelayCommand(Modificar, CanCerrar);//Para guardar la referencia


        }

        private async void actualizaSumas()
        {
            await verificacion();
        }

        public async Task verificacion()
        {
            for (int i = 0; i < listaMovimientos.Count(); i++)
            {
                if (listaMovimientos[i].nombreCuenta != null)
                {
                    currentDetalleEntidad.sumacargopartida = (decimal)listaMovimientos.Sum(x => x.cargomovimiento);
                    currentDetalleEntidad.sumaabonopartida = (decimal)listaMovimientos.Sum(x => x.abonomovimiento);

                    //if(listaMovimientos[i].is)
                    if (listaMovimientos[i].nombreCuenta == "Ninguna")
                    {
                        listaMovimientos[i].nombreCuenta = string.Empty;
                        listaMovimientos[i].cargomovimiento = 0;
                        listaMovimientos[i].cargosActivados = 0;
                        listaMovimientos[i].abonosActivados = 0;
                        listaMovimientos[i].cargomovimiento = 0;
                        listaMovimientos[i].cargosActivados = 0;
                    }

                    if (listaMovimientos[i].nombreCuenta != "Ninguna" && listaMovimientos[i].nombreCuenta != "")
                    {
                        listaMovimientos[i].cuentaValida = listaCatalogo.SingleOrDefault(x => x.nombreCuenta == listaMovimientos[i].nombreCuenta).IsOperable;

                        if (!(listaMovimientos[i].cargomovimiento > 0 || listaMovimientos[i].abonomovimiento > 0))
                        {
                            await mensajeAutoCerrado("No es válida cuentas sin cargos o abonos", "Debe introducir un valor", 2);
                            listaMovimientos[i].nombreCuenta = string.Empty;
                            listaMovimientos[i].cargomovimiento = 0;
                            listaMovimientos[i].cargosActivados = 0;
                            listaMovimientos[i].abonosActivados = 0;
                            listaMovimientos[i].cargomovimiento = 0;
                            listaMovimientos[i].cargosActivados = 0;
                        }
                        if (!listaMovimientos[i].cuentaValida)
                        {
                            await mensajeAutoCerrado("No es el último  nivel para aplicar ", "Debe seleccionar el último nivel", 2);
                            listaMovimientos[i].nombreCuenta = string.Empty;
                            listaMovimientos[i].cargomovimiento = 0;
                            listaMovimientos[i].cargosActivados = 0;
                            listaMovimientos[i].abonosActivados = 0;
                            listaMovimientos[i].cargomovimiento = 0;
                            listaMovimientos[i].cargosActivados = 0;
                        }
                    }
                    if (listaMovimientos[i].cargomovimiento > 0)
                    {
                        listaMovimientos[i].cargosActivados = 1;
                        listaMovimientos[i].abonomovimiento = 0;
                        listaMovimientos[i].abonosActivados = 0;
                    }
                    if (listaMovimientos[i].abonomovimiento > 0)
                    {
                        listaMovimientos[i].abonosActivados = 1;
                        listaMovimientos[i].cargomovimiento = 0;
                        listaMovimientos[i].cargosActivados = 0;
                    }
                    if (listaMovimientos[i].cargomovimiento == 0 && listaMovimientos[i].abonomovimiento == 0)
                    {
                        listaMovimientos[i].cargosActivados = 0;
                        listaMovimientos[i].abonosActivados = 0;
                    }
                    if (i == 0)
                    {
                        listaMovimientos[i].cargosActivados = 1;//Siempre se comienza por cargar las cuentas
                        listaMovimientos[i].abonomovimiento = 0;
                        listaMovimientos[i].abonosActivados = 0;
                    }
                    else
                    {
                        if (listaMovimientos[i - 1].abonomovimiento > 0)
                        {
                            listaMovimientos[i].abonosActivados = 1;
                            listaMovimientos[i].cargomovimiento = 0;
                            listaMovimientos[i].cargosActivados = 0;
                        }
                        else
                        {
                            if (listaMovimientos[i - 1].abonosActivados == 1)
                            {
                                listaMovimientos[i].abonosActivados = 1;
                                listaMovimientos[i].cargomovimiento = 0;
                                listaMovimientos[i].cargosActivados = 0;
                            }
                        }
                    }
                }
            }
        }

        public bool valida()
        {
            bool respuesta = true;
            if (currentDetalleEntidad.sumacargopartida != currentDetalleEntidad.sumaabonopartida )
            {
                respuesta = false;
                currentDetalleEntidad.sumacargopartida = (decimal)listaMovimientos.Sum(x => x.cargomovimiento);
                currentDetalleEntidad.sumaabonopartida = (decimal)listaMovimientos.Sum(x => x.abonomovimiento);
            }
            if (currentDetalleEntidad.sumacargopartida != currentDetalleEntidad.sumaabonopartida)
            {
                respuesta = false;
            }
            if (respuesta)
            { 
            if (currentDetalleEntidad.sumacargopartida == currentDetalleEntidad.sumaabonopartida && currentDetalleEntidad.sumacargopartida > 0)
            {
                int cuentasCargadas = listaMovimientos.Count(x => x.cargomovimiento > 0);
                int cuentasAbonadas = listaMovimientos.Count(x => x.abonomovimiento > 0);
                int cuentas = listaMovimientos.Where(x => x.nombreCuenta != ""
                   && x.nombreCuenta != "Ninguna").Count();

                if (!(cuentasCargadas + cuentasAbonadas == cuentas))
                {
                    respuesta = false;
                }
            }
            else
            {
                respuesta = false;
            }
            }
            return respuesta;
        }

        private void ControlCuenta(string datosCuentaMsj)
        {
            if (!string.IsNullOrEmpty(datosCuentaMsj) && !string.IsNullOrWhiteSpace(datosCuentaMsj))
            {
                CatalogoCuentasModelo temporal = listaCatalogo.SingleOrDefault(x => x.descripcioncc == datosCuentaMsj);
                currentMovimientos.codigocc = temporal.codigocc;
                currentMovimientos.descripcioncc = temporal.descripcioncc;
                currentMovimientos.codigocc = temporal.codigocc;
                currentMovimientos.idcc = temporal.idcc;
                currentMovimientos.ordencc = temporal.ordencc;
            }
        }

        private void ControlCodigo(string datosCodigoMsj)
        {
            if(!string.IsNullOrEmpty(datosCodigoMsj) && !string.IsNullOrWhiteSpace(datosCodigoMsj))
            { 
            CatalogoCuentasModelo temporal = listaCatalogo.SingleOrDefault(x => x.codigocc == datosCodigoMsj);
            currentMovimientos.codigocc = temporal.codigocc;
            currentMovimientos.descripcioncc = temporal.descripcioncc;
            currentMovimientos.codigocc = temporal.codigocc;
            currentMovimientos.idcc = temporal.idcc;
            currentMovimientos.ordencc = temporal.ordencc;
            }
        }

        private bool CanNuevo()
        {
            bool evaluar = false;

            if (currentDetalleEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = Errors == 0;
                return evaluar;
            }
        }

        private bool CanModificar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0)
                && (!string.IsNullOrWhiteSpace(currentEntidad.usuarioaprobo));
                return evaluar;
            }
        }

        private bool CanCerrar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                        && (!string.IsNullOrWhiteSpace(currentEntidad.usuariocerro));
            }
        }


        private bool CanAprobar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidad.usuarioaprobo))
                        && (!string.IsNullOrWhiteSpace(currentEntidad.usuarioaprobo));
            }
        }

        private bool CanSupervisar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                        && (!string.IsNullOrWhiteSpace(currentEntidad.usuariosuperviso));
            }
        }


        private bool CanReferenciarSave()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0);
                return evaluar;
            }
        }

        private async void Modificar()
        {
            iniciarComando();
            try
            {
                int resultadoModificar = -10;
                //currentEntidad.referenciamr = referenciamr;
                switch (opcionMenu)
                {
                    case 2: //Actualiza
                        await verificacion();
                        ObservableCollection<CedulaMovimientoModelo> listaTemporal = new ObservableCollection<CedulaMovimientoModelo>();
                        foreach (CedulaMovimientoModelo item in listaMovimientos)
                        {
                            if (item.nombreCuenta != null
                                && item.nombreCuenta != ""
                                && item.nombreCuenta != "Ninguna"
                                && (item.cargomovimiento > 0 || item.abonomovimiento > 0))
                            {
                                CatalogoCuentasModelo temporal = listaCatalogo.SingleOrDefault(x => x.nombreCuenta == item.nombreCuenta);
                                item.idencargo = currentDetalleEntidad.idencargo;
                                item.idpartida = currentDetalleEntidad.idpartida;
                                item.codigocc = temporal.codigocc;
                                item.descripcioncc = temporal.descripcioncc;
                                item.codigocc = temporal.codigocc;
                                item.idcc = temporal.idcc;
                                item.ordencc = temporal.ordencc;
                                listaTemporal.Add(item);
                            }
                        }
                        if (valida())
                        {
                            if (nombreUnico(currentDetalleEntidad.conceptopartida, listaDetalleEntidad) == 1)
                            {
                                resultadoModificar = CedulaPartidasModelo.UpdateModelo(currentDetalleEntidad, listaTemporal);
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "El nombre no puede repetirse", "Modifique  el nombre la cédula");
                            }
                        }
                        else
                        {
                            await mensajeAutoCerrado("Hay errores  en los datos", "Revise", 1);
                            finComando();
                        }
                        break;
                    case 8: //Referenciar
                        resultadoModificar = CedulaModelo.UpdateReferencia(currentEntidad);
                        break;
                    case 10://Cerrar
                        resultadoModificar = CedulaModelo.UpdateCierre(currentEntidad, currentUsuario, currentEntidad.conclusioncedula);
                        //resultadoModificar = CedulaModelo.UpdateCierre(currentEntidad, currentUsuario);
                        break;
                    case 11://Supervisar
                        resultadoModificar = CedulaModelo.UpdateSupervision(currentEntidad);
                        break;
                    case 12://Aprobar
                        if (string.IsNullOrEmpty(currentEntidad.usuariosuperviso) || string.IsNullOrWhiteSpace(currentEntidad.usuariosuperviso))
                        {
                            resultadoModificar = CedulaModelo.UpdateAprobacionSupervision(currentEntidad);
                            currentEntidad.usuariosuperviso = currentEntidad.usuarioaprobo;
                            currentEntidad.fechasupervision = currentEntidad.fechaaprobacion;
                        }
                        else
                        {
                            resultadoModificar = CedulaModelo.UpdateAprobacion(currentEntidad);
                        }
                        break;
                    case 14: //Responder
                break;
                }

                switch (resultadoModificar)
                {
                    case 0://No se pudo insertar
                        finComando();
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        break;
                    case 1://Se inserto con éxito
                        await mensajeAutoCerrado("Operación con registro realizada con éxito", "Este mensaje desaparecerá en segundos", 2);
                        fuenteCierre = 1;
                        resultadoProceso = 1;//1 para  crear
                        CloseWindow();
                        break;
                    case -1://No se pudo insertar
                        finComando();
                        await dlg.ShowMessageAsync(this, "Se genero un  error en la operación", "");
                        break;
                }
            }
            catch (Exception)
            {
                finComando();
                this.except3();
            }
        }

        private async void except3()
        {
            finComando();
            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
        }

        public async void advertenciaSeleccion()
        {
            await dlg.ShowMessageAsync(this, "No puede seleccionar 2 carpetas del mismo tipo", "Debe eliminar una de las 2 selecciones");
        }


        #region Verifica unicidad
        //Cada marca debe ser única
        public int nombreUnico(string nombre, ObservableCollection<CedulaPartidasModelo> listaBusqueda)
        {
            int numeroRegistros = 0;
            if (listaBusqueda != null || listaBusqueda.Count > 0)
            {
                string nombreBuscado = nombre.ToUpper().Trim();
                numeroRegistros = listaBusqueda.Where(j => j.conceptopartida.ToUpper().Trim() == nombreBuscado).Count();
                if (numeroRegistros == 1)
                {
                    return 1;
                }
                else
                {
                    return numeroRegistros;
                }
            }
            else
            {
                return numeroRegistros;
            }
        }
        #endregion

        #endregion

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

    }

}

