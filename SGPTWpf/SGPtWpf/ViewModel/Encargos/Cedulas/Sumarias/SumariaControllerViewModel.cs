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
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias
{

    public sealed class SumariaControllerViewModel : ViewModeloBase
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

        #region ViewModel Properties : listaDocumentosAnteriores

        public const string listaDocumentosAnterioresPropertyName = "listaDocumentosAnteriores";

        private ObservableCollection<CedulaModelo> _listaDocumentosAnteriores;

        public ObservableCollection<CedulaModelo> listaDocumentosAnteriores
        {
            get
            {
                return _listaDocumentosAnteriores;
            }

            set
            {
                if (_listaDocumentosAnteriores == value) return;

                _listaDocumentosAnteriores = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDocumentosAnterioresPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDocumentosAnterioresCompleta

        public const string listaDocumentosAnterioresCompletaPropertyName = "listaDocumentosAnterioresCompleta";

        private ObservableCollection<CedulaModelo> _listaDocumentosAnterioresCompleta;

        public ObservableCollection<CedulaModelo> listaDocumentosAnterioresCompleta
        {
            get
            {
                return _listaDocumentosAnterioresCompleta;
            }

            set
            {
                if (_listaDocumentosAnterioresCompleta == value) return;

                _listaDocumentosAnterioresCompleta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDocumentosAnterioresCompletaPropertyName);
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

        #region Balances
        #region ViewModel Properties : listaBalancePrincipal

        public const string listaBalancePrincipalPropertyName = "listaBalancePrincipal";

        private ObservableCollection<BalanceModelo> _listaBalancePrincipal;

        public ObservableCollection<BalanceModelo> listaBalancePrincipal
        {
            get
            {
                return _listaBalancePrincipal;
            }
            set
            {
                if (_listaBalancePrincipal == value) return;

                _listaBalancePrincipal = value;

                RaisePropertyChanged(listaBalancePrincipalPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedBalance

        public const string selectedBalancePropertyName = "selectedBalance";

        private BalanceModelo _selectedBalance;

        public BalanceModelo selectedBalance
        {
            get
            {
                return _selectedBalance;
            }

            set
            {
                if (_selectedBalance == value) return;

                _selectedBalance = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedBalancePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaBalanceComparativo

        public const string listaBalanceComparativoPropertyName = "listaBalanceComparativo";

        private ObservableCollection<BalanceModelo> _listaBalanceComparativo;

        public ObservableCollection<BalanceModelo> listaBalanceComparativo
        {
            get
            {
                return _listaBalanceComparativo;
            }
            set
            {
                if (_listaBalanceComparativo == value) return;

                _listaBalanceComparativo = value;

                RaisePropertyChanged(listaBalanceComparativoPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedBalComparativo

        public const string selectedBalComparativoPropertyName = "selectedBalComparativo";

        private BalanceModelo _selectedBalComparativo;

        public BalanceModelo selectedBalComparativo
        {
            get
            {
                return _selectedBalComparativo;
            }

            set
            {
                if (_selectedBalComparativo == value) return;

                _selectedBalComparativo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedBalComparativoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaBalanceDetalle

        public const string listaBalanceDetallePropertyName = "listaBalanceDetalle";

        private ObservableCollection<DetalleCedulaModelo> _listaBalanceDetalle;

        public ObservableCollection<DetalleCedulaModelo> listaBalanceDetalle
        {
            get
            {
                return _listaBalanceDetalle;
            }
            set
            {
                if (_listaBalanceDetalle == value) return;

                _listaBalanceDetalle = value;

                RaisePropertyChanged(listaBalanceDetallePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaVisitas

        public const string listaVisitasPropertyName = "listaVisitas";

        private ObservableCollection<VisitaModelo> _listaVisitas;

        public ObservableCollection<VisitaModelo> listaVisitas
        {
            get
            {
                return _listaVisitas;
            }
            set
            {
                if (_listaVisitas == value) return;

                _listaVisitas = value;

                RaisePropertyChanged(listaVisitasPropertyName);
            }
        }

        #endregion
        
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

        #region ViewModel Property : selectedVisitaModelo

        public const string selectedVisitaModeloPropertyName = "selectedVisitaModelo";

        private VisitaModelo _selectedVisitaModelo;

        public VisitaModelo selectedVisitaModelo
        {
            get
            {
                return _selectedVisitaModelo;
            }

            set
            {
                if (_selectedVisitaModelo == value) return;

                _selectedVisitaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedVisitaModeloPropertyName);
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


        #region Propiedades : titulocedula 

        public const string titulocedulaPropertyName = "titulocedula";

        private string _titulocedula = string.Empty;


        public string titulocedula
        {
            get
            {
                return _titulocedula;
            }
            set
            {
                if (_titulocedula == value)
                {
                    return;
                }
                _titulocedula = value;
                RaisePropertyChanged(titulocedulaPropertyName);
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

        private DetalleCedulaModelo _currentDetalleEntidad;

        public DetalleCedulaModelo currentDetalleEntidad
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

        #region visibilidadBalanceSeleccionar

        public const string visibilidadBalanceSeleccionarPropertyName = "visibilidadBalanceSeleccionar";

        private Visibility _visibilidadBalanceSeleccionar = Visibility.Collapsed;

        public Visibility visibilidadBalanceSeleccionar
        {
            get
            {
                return _visibilidadBalanceSeleccionar;
            }

            set
            {
                if (_visibilidadBalanceSeleccionar == value)
                {
                    return;
                }

                _visibilidadBalanceSeleccionar = value;
                RaisePropertyChanged(visibilidadBalanceSeleccionarPropertyName);
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

        

        #region visibilidadBalanceComparativo

        public const string visibilidadBalanceComparativoPropertyName = "visibilidadBalanceComparativo";

        private Visibility _visibilidadBalanceComparativo = Visibility.Collapsed;

        public Visibility visibilidadBalanceComparativo
        {
            get
            {
                return _visibilidadBalanceComparativo;
            }

            set
            {
                if (_visibilidadBalanceComparativo == value)
                {
                    return;
                }

                _visibilidadBalanceComparativo = value;
                RaisePropertyChanged(visibilidadBalanceComparativoPropertyName);
            }
        }

        #endregion

        #region visibilidadVisita

        public const string visibilidadVisitaPropertyName = "visibilidadVisita";

        private Visibility _visibilidadVisita = Visibility.Collapsed;

        public Visibility visibilidadVisita
        {
            get
            {
                return _visibilidadVisita;
            }

            set
            {
                if (_visibilidadVisita == value)
                {
                    return;
                }

                _visibilidadVisita = value;
                RaisePropertyChanged(visibilidadVisitaPropertyName);
            }
        }

        #endregion

        #region visibilidadDatosSumaria

        public const string visibilidadDatosSumariaPropertyName = "visibilidadDatosSumaria";

        private Visibility _visibilidadDatosSumaria = Visibility.Collapsed;

        public Visibility visibilidadDatosSumaria
        {
            get
            {
                return _visibilidadDatosSumaria;
            }

            set
            {
                if (_visibilidadDatosSumaria == value)
                {
                    return;
                }

                _visibilidadDatosSumaria = value;
                RaisePropertyChanged(visibilidadDatosSumariaPropertyName);
            }
        }

        #endregion

        #region accesibilidad



        #region ViewModel Properties : accesibilidadVisita

        public const string accesibilidadVisitaPropertyName = "accesibilidadVisita";

        private bool _accesibilidadVisita;

        public bool accesibilidadVisita
        {
            get
            {
                return _accesibilidadVisita;
            }

            set
            {
                if (_accesibilidadVisita == value)
                {
                    return;
                }

                _accesibilidadVisita = value;
                RaisePropertyChanged(accesibilidadVisitaPropertyName);
            }
        }

        #endregion

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

        #region ViewModel Properties : accesibilidadBalanceSeleccionar

        public const string accesibilidadBalanceSeleccionarPropertyName = "accesibilidadBalanceSeleccionar";

        private bool _accesibilidadBalanceSeleccionar;

        public bool accesibilidadBalanceSeleccionar
        {
            get
            {
                return _accesibilidadBalanceSeleccionar;
            }

            set
            {
                if (_accesibilidadBalanceSeleccionar == value)
                {
                    return;
                }

                _accesibilidadBalanceSeleccionar = value;
                RaisePropertyChanged(accesibilidadBalanceSeleccionarPropertyName);
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

        #region ViewModel Properties : accesibilidadDetalleBalance

        public const string accesibilidadDetalleBalancePropertyName = "accesibilidadDetalleBalance";

        private bool _accesibilidadDetalleBalance;

        public bool accesibilidadDetalleBalance
        {
            get
            {
                return _accesibilidadDetalleBalance;
            }

            set
            {
                if (_accesibilidadDetalleBalance == value)
                {
                    return;
                }

                _accesibilidadDetalleBalance = value;
                RaisePropertyChanged(accesibilidadDetalleBalancePropertyName);
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

        public RelayCommand<TipoCedulaModelo> SelectionCarpetaCommand { get; set; }


        #region Importacion

        public RelayCommand CancelarProgramaEncargoCommand { get; set; }//Seleccion desde el encargo
        public RelayCommand SeleccionProgramaEncargoCommand { get; set; }//seleccion desde el encargo

        public RelayCommand CancelarPlantillaCommand { get; set; }//Seleccion desde las plantillas
        public RelayCommand SeleccionPlantillaCommand { get; set; }//seleccion desde las plantillas

        public RelayCommand<TipoCedulaModelo> SeleccionClaseDocumentoCommand { get; set; }

        public RelayCommand<CedulaModelo> SelectionCarpetaChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateSupervisionChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateAprobacionCommand { get; set; }


        public RelayCommand referenciarCommand { get; set; }//seleccion desde las plantillas
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }

        public RelayCommand cerrarCommand { get; set; }

        public RelayCommand cmdCargarPdf_Click { get; set; }

        public RelayCommand cmdCargarFuente_Click { get; set; }
        public RelayCommand<BalanceModelo> SeleccionBalanceCommand { get; set; }
        public RelayCommand<BalanceModelo> SeleccionBalanceComparativoCommand { get; set; }
        
        public RelayCommand<VisitaModelo> SeleccionVisitaCommand { get; set; }

        #endregion


        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public SumariaControllerViewModel()
        {
        }

        public SumariaControllerViewModel(string origenLlamada)
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
            _listaBalanceComparativo = new ObservableCollection<BalanceModelo>();
            _listaBalancePrincipal = new ObservableCollection<BalanceModelo>();
            _selectedBalance = new BalanceModelo();
            _selectedBalComparativo = new BalanceModelo();
            _listaBalanceDetalle = new ObservableCollection<DetalleCedulaModelo>();
            _listaVisitas = new ObservableCollection<VisitaModelo>(VisitaModelo.GetAllSeleccion());
            Errors = 0;
            //Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcion, (plantillaIndiceMensaje) => ControlPlantillaIndiceMensaje(plantillaIndiceMensaje));
            RegisterCommands();
            //Recibe un numero para procesar solo el último mensaje
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            dlg = new DialogCoordinator();
            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            _accesibilidadBalanceSeleccionar = false;
            _accesibilidadVisita = false;
            _visibilidadClaseDocumento = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _visibilidadPlantilla = Visibility.Collapsed;
            _visibilidadBalance = Visibility.Collapsed;
            _visibilidadBalanceComparativo = Visibility.Collapsed;
            _visibilidadClaseDocumento = Visibility.Collapsed;
            _visibilidadVisita = Visibility.Visible;
            _visibilidadConclusiones = Visibility.Visible;
            _visibilidadBalanceSeleccionar = Visibility.Collapsed;
            _visibilidadDatosSumaria = Visibility.Visible;
            _selectedTipoCedulaModelo = new TipoCedulaModelo();
            _eleccionTipoCedulaModelo = new TipoCedulaModelo();

            _currentEncargo = new EncargoModelo();
            _currentEntidad = new CedulaModelo();
            _currentDetalleEntidad = new DetalleCedulaModelo();
            _eleccionTipoCedulaModelo = new TipoCedulaModelo();
            _selectedVisitaModelo = new VisitaModelo();
            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            switch (origenLlamada)
            {
                case "DocumentacionCedulas"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosEncargoCedulasSumariasController";
                    _tokenRecepcion = "datosEncargoCedulasSumarias";
                    #endregion
                    break;

                case "EncargoCedulasSumariasDetalle"://Llamada desde Documentacion/Sumarias/Detalle
                    #region configuracion Documentacion
                    _tokenEnvio = "datosControllerEncargoCedulasSumariasDetalle";
                    _tokenRecepcion = "datosEncargoCedulasSumariasDetalle"; //Modificado
                    _visibilidadDatosSumaria = Visibility.Collapsed;
                    #endregion
                    break;
                case "ReferenciarDocumentacionCartas"://Referenciacion
                    #region configuracion Documentacion
                    _tokenEnvio = "datosControllerCartas";
                    _tokenRecepcion = "datosEDCartas";
                    #endregion
                    #region contenido

                    _accesibilidadWindow = false;
                    _accesibilidadCuerpo = false;
                    _accesibilidadReferencia = false;
                    _accesibilidadCierre = false;
                    _accesibilidadSupervision = false;
                    _accesibilidadAprobacion = false;
                    _accesibilidadEvaluacion = false;

                    #endregion
                    #region visibilidad botones inferiores

                    _visibilidadReferenciar = Visibility.Collapsed;
                    _visibilidadAprobar = Visibility.Collapsed;
                    _visibilidadSupervisar = Visibility.Collapsed;
                    _visibilidadConsultar = Visibility.Collapsed;
                    _visibilidadCerrar = Visibility.Collapsed;
                    _visibilidadEditar = Visibility.Collapsed;

                    #endregion
                    #region visibilidadContenido

                    _visibilidadReferencia = Visibility.Collapsed;
                    _visibilidadFechaCierre = Visibility.Collapsed;
                    _visibilidadFechaSupervision = Visibility.Collapsed;
                    _visibilidadFechaAprobacion = Visibility.Collapsed;
                    _visibilidadFechaAprobacion = Visibility.Collapsed;
                    _visibilidadFechaEvaluacion = Visibility.Visible;

                    #endregion

                    break;
                case "DocumentacionCedulasHallazgos"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosEncargoCedulasHallazgosControllerMenuPrincipal";
                    _tokenRecepcion = "datosEncargoCedulasHallazgosMenuPrincipal";
                    #endregion
                    break;
                case "DocumentacionCedulasAjustes"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosEncargoCedulasAjustesControllerMenuPrincipal";
                    _tokenRecepcion = "datosEncargoCedulasAjustesMenuPrincipal";
                    #endregion
                    break;
                case "DocumentacionCedulasNotas"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosEncargoCedulasNotasControllerMenuPrincipal";
                    _tokenRecepcion = "datosEncargoCedulasNotasMenuPrincipal";
                    #endregion
                    break;
            }
            //Suscribiendo el mensaje
            Messenger.Default.Register<CedulaMsj>(this, tokenRecepcion, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            _currentEncargo = new EncargoModelo();


            #region Importacion

            _listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>();

            #endregion

            _fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
            _fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
            _fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
        }

        private async void ControlDatosMsj(CedulaMsj datosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            //FuenteLlamada = datosMsj.fuenteLlamado;
            tokenEnvio = datosMsj.tokenRespuestaController;
            listacurrentEntidad = datosMsj.listaMaestroModelo;
            //Eliminar visitas ya existentes
            currentEntidad = datosMsj.entidadMaestroModelo;
            if (datosMsj.listaDetalle != null && datosMsj.listaDetalle.Count > 0)
            {
                currentEntidad.listaDetalleCedula = datosMsj.listaDetalle;//Lista de cuentas seleccionadas
            }
                if (currentEntidad.idvisita != null)
            {
                selectedVisitaModelo = listaVisitas.Single(x => x.id == currentEntidad.idvisita);
            }
            else
            {
                selectedVisitaModelo = listaVisitas.Single(x => x.id == 0);
            }
            switch (currentEntidad.idtc)
            {
                case 1: //Cedula sumaria
                    #region carga datos
                    if (opcionMenu != 14)
                    {
                        listaBalancePrincipal = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAllByIsScForCedulas(currentEncargo));
                        listaBalanceComparativo = new ObservableCollection<BalanceModelo>(listaBalancePrincipal.ToList());
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
                            //10; "Contactos"; "A"; TRUE
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
                    }

                    #endregion

                    #region Sumaria
                    switch (datosMsj.opcionMenuCrud)
            {
                case 1://Crear 

                            if (origen == "EncargoCedulasSumariasDetalle")
                            {
                                encabezadoPantalla = "Seleccione las cuentas";
                                titulocedula = currentEntidad.titulocedula;
                                visibilidadCrear = Visibility.Visible;
                                visibilidadEditar = Visibility.Collapsed;
                                visibilidadConsultar = Visibility.Collapsed;
                                visibilidadCopiar = Visibility.Collapsed;
                                visibilidadBalanceSeleccionar = Visibility.Visible;
                                accesibilidadCuerpo = true;
                                accesibilidadVisita = false;
                                accesibilidadClaseCedula = false;
                                accesibilidadDetalleBalance = true;
                                accesibilidadBalanceSeleccionar = false;
                            }
                            else
                            {
                                encabezadoPantalla = "Proporcione los datos requeridos";
                                visibilidadCrear = Visibility.Visible;
                                visibilidadEditar = Visibility.Collapsed;
                                visibilidadConsultar = Visibility.Collapsed;
                                visibilidadCopiar = Visibility.Collapsed;
                                visibilidadBalanceSeleccionar = Visibility.Visible;
                                visibilidadBalance = Visibility.Collapsed;
                                visibilidadBalanceComparativo = Visibility.Collapsed;
                                accesibilidadCuerpo = false;
                                accesibilidadClaseCedula = false;
                                accesibilidadDetalleBalance = true;
                                accesibilidadBalanceSeleccionar = true;
                                accesibilidadVisita = true;
                                titulocedula = string.Empty;
                            }

                    break;
                case 14://Seleccionar visita 
                    encabezadoPantalla = "Proporcione los datos requeridos";
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    visibilidadBalanceSeleccionar = Visibility.Visible;
                    visibilidadBalance = Visibility.Collapsed;
                    visibilidadBalanceComparativo = Visibility.Collapsed;
                    accesibilidadCuerpo = true;
                    accesibilidadClaseCedula = true;
                    accesibilidadDetalleBalance = true;
                    accesibilidadBalanceSeleccionar = true;
                    accesibilidadVisita = false;
                    accesibilidadWindow = true;
                    titulocedula = string.Empty;
                    break;
                case 2://Editar, no sera activada
                    encabezadoPantalla = "Edite los datos";
                    titulocedula = currentEntidad.titulocedula;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    visibilidadBalanceSeleccionar = Visibility.Visible;
                    accesibilidadCuerpo = true;
                    accesibilidadVisita = false;
                    accesibilidadClaseCedula = false;
                    accesibilidadDetalleBalance = false;
                    accesibilidadBalanceSeleccionar = false;
                    break;
                case 3://Consultar
                    encabezadoPantalla = "Consulta del tipo de carpeta";
                    titulocedula = currentEntidad.titulocedula;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    accesibilidadCuerpo = false;
                    accesibilidadVisita = false;
                    accesibilidadClaseCedula = false;
                    accesibilidadDetalleBalance = false;
                    accesibilidadBalanceSeleccionar = false;

                    break;
                case 6://Importar de las plantillas (No se usa)
                    listacurrentEntidad = datosMsj.listaMaestroModelo;
                    listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAll());
                    //Remover todas las carpetas ya existentes
                    ObservableCollection<CedulaModelo> listaRepositorioTemporal = new ObservableCollection<CedulaModelo>();
                    foreach (CedulaModelo item in listacurrentEntidad)
                    {
                        listaRepositorioTemporal = new ObservableCollection<CedulaModelo>(listaDocumentosAnteriores.Where(x => x.idencargo == item.idencargo));
                        if (listaRepositorioTemporal.Count > 0)
                        {
                            foreach (CedulaModelo itemRemover in listaRepositorioTemporal)
                            {
                                listaDocumentosAnteriores.Remove(itemRemover);
                            }
                        }
                    }

                    visibilidadCrear = Visibility.Visible;
                    accesibilidadWindow = true;
                    if (!(listaDocumentosAnteriores.Count > 0))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }

                    break;
                case 7://Importar de programas de otros encargos
                       //Seleccion de programa
                    visibilidadCopiar = Visibility.Visible;
                    accesibilidadWindow = true;
                    listacurrentEntidad = datosMsj.listaMaestroModelo;
                    ControlCambioLista();
                    if (currentEntidad.idtc == 0 || (currentEntidad.idtc != 2 && currentEntidad.idtc != 7 && currentEntidad.idtc != 8))
                    {
                        //listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllByEncargosImportacionEncabezadosOtros(currentEncargo, currentEntidad.idtc));
                    }
                    else
                    {
                        //listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllByEncargosImportacionEncabezados(currentEncargo, currentEntidad.idtc));
                    }
                    accesibilidadWindow = true;
                    if (!(listaDocumentosAnteriores.Count > 0))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }
                    break;
                case 8://Referenciar 
                    encabezadoPantalla = "Introduzca la referencia para la cédula";
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

            }
                    #endregion sumaria
                break;

                default: //Cedula Hallazgos
                    #region carga datos
                    if (opcionMenu != 14)
                    {
                            visibilidadClaseDocumento = Visibility.Visible;
                            listaClaseDocumentos = new ObservableCollection<TipoCedulaModelo>(TipoCedulaModelo.GetAllOtros());
                            llenadoDatos(datosMsj.opcionMenuCrud);
                            selectedTipoCedulaModelo = listaClaseDocumentos.Single(i => i.id == currentEntidad.idtc);
                            currentClaseDocumento = selectedTipoCedulaModelo;
                    }

                    #endregion

                    #region Hallazgos
                    switch (datosMsj.opcionMenuCrud)
                    {
                        case 1://Crear 
                            encabezadoPantalla = "Seleccione la visita a que corresponde la cédula";
                            visibilidadCrear = Visibility.Visible;
                            visibilidadEditar = Visibility.Collapsed;
                            visibilidadConsultar = Visibility.Collapsed;
                            visibilidadCopiar = Visibility.Collapsed;
                            visibilidadBalanceSeleccionar = Visibility.Collapsed;
                            visibilidadBalance = Visibility.Collapsed;
                            visibilidadBalanceComparativo = Visibility.Collapsed;
                            accesibilidadCuerpo = false;
                            accesibilidadClaseCedula = false;
                            accesibilidadDetalleBalance = true;
                            accesibilidadBalanceSeleccionar = true;
                            switch (currentEntidad.idtc)
                            {
                                case 6:
                                    currentEntidad.titulocedula = "Cédula de hallazgos";
                                    break;
                                case 7:
                                    currentEntidad.titulocedula = "Cédula de notas";
                                    break;
                                case 15:
                                    currentEntidad.titulocedula = "Cédula de ajustes y reclasificaciones";
                                    break;
                            }
                            accesibilidadVisita = true;
                            titulocedula = currentEntidad.titulocedula;
                            VisitaModelo temporal = null;
                            foreach (CedulaModelo item in listacurrentEntidad)
                            {
                                if (item.idvisita != null)
                                {
                                    temporal = listaVisitas.Single(x => x.id == item.idvisita);
                                    listaVisitas.Remove(temporal);
                                    temporal = new VisitaModelo();
                                }
                                else
                                {
                                    temporal = listaVisitas.Single(x => x.id == 0);
                                    listaVisitas.Remove(temporal);
                                    temporal = new VisitaModelo();
                                }
                            }
                            break;
                        case 14://Seleccionar visita 
                            encabezadoPantalla = "Proporcione los datos requeridos";
                            visibilidadCrear = Visibility.Collapsed;
                            visibilidadEditar = Visibility.Collapsed;
                            visibilidadConsultar = Visibility.Visible;
                            visibilidadCopiar = Visibility.Collapsed;
                            visibilidadBalanceSeleccionar = Visibility.Visible;
                            visibilidadBalance = Visibility.Collapsed;
                            visibilidadBalanceComparativo = Visibility.Collapsed;
                            accesibilidadCuerpo = true;
                            accesibilidadClaseCedula = true;
                            accesibilidadDetalleBalance = true;
                            accesibilidadBalanceSeleccionar = true;
                            accesibilidadWindow = true;
                            titulocedula = string.Empty;
                            break;
                        case 2://Editar, no sera activada
                            encabezadoPantalla = "Edite los datos";
                            titulocedula = currentEntidad.titulocedula;
                            visibilidadCrear = Visibility.Collapsed;
                            visibilidadEditar = Visibility.Collapsed;
                            visibilidadConsultar = Visibility.Visible;
                            visibilidadCopiar = Visibility.Collapsed;
                            visibilidadBalanceSeleccionar = Visibility.Collapsed;
                            accesibilidadCuerpo = false;
                            accesibilidadVisita = false;
                            accesibilidadClaseCedula = false;
                            accesibilidadDetalleBalance = false;
                            accesibilidadBalanceSeleccionar = false;
                            break;
                        case 3://Consultar
                            encabezadoPantalla = "Consulta del tipo de carpeta";
                            titulocedula = currentEntidad.titulocedula;
                            visibilidadCrear = Visibility.Collapsed;
                            visibilidadEditar = Visibility.Collapsed;
                            visibilidadConsultar = Visibility.Visible;
                            visibilidadCopiar = Visibility.Collapsed;
                            accesibilidadCuerpo = false;
                            accesibilidadClaseCedula = false;
                            accesibilidadDetalleBalance = false;
                            accesibilidadBalanceSeleccionar = false;
                            accesibilidadVisita = false;
                            break;
                        case 6://Importar de las plantillas (No se usa)
                            listacurrentEntidad = datosMsj.listaMaestroModelo;
                            listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAll());
                            //Remover todas las carpetas ya existentes
                            ObservableCollection<CedulaModelo> listaRepositorioTemporal = new ObservableCollection<CedulaModelo>();
                            foreach (CedulaModelo item in listacurrentEntidad)
                            {
                                listaRepositorioTemporal = new ObservableCollection<CedulaModelo>(listaDocumentosAnteriores.Where(x => x.idencargo == item.idencargo));
                                if (listaRepositorioTemporal.Count > 0)
                                {
                                    foreach (CedulaModelo itemRemover in listaRepositorioTemporal)
                                    {
                                        listaDocumentosAnteriores.Remove(itemRemover);
                                    }
                                }
                            }

                            visibilidadCrear = Visibility.Visible;
                            accesibilidadWindow = true;
                            if (!(listaDocumentosAnteriores.Count > 0))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                fuenteCierre = 1;
                                resultadoProceso = 0;//1 para  crear
                                CloseWindow();
                            }

                            break;
                        case 7://Importar de programas de otros encargos
                               //Seleccion de programa
                            visibilidadCopiar = Visibility.Visible;
                            accesibilidadWindow = true;
                            listacurrentEntidad = datosMsj.listaMaestroModelo;
                            ControlCambioLista();
                            if (currentEntidad.idtc == 0 || (currentEntidad.idtc != 2 && currentEntidad.idtc != 7 && currentEntidad.idtc != 8))
                            {
                                //listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllByEncargosImportacionEncabezadosOtros(currentEncargo, currentEntidad.idtc));
                            }
                            else
                            {
                                //listaDocumentosAnteriores = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllByEncargosImportacionEncabezados(currentEncargo, currentEntidad.idtc));
                            }
                            accesibilidadWindow = true;
                            if (!(listaDocumentosAnteriores.Count > 0))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                fuenteCierre = 1;
                                resultadoProceso = 0;//1 para  crear
                                CloseWindow();
                            }
                            break;
                        case 8://Referenciar 
                            encabezadoPantalla = "Introduzca la referencia para la cédula";
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

                    }
                    #endregion Hallazgos
                    break;
            }
            Messenger.Default.Unregister<CedulaMsj>(this, tokenRecepcion);
            finComando();
            finInicializacion = true;//Termino la carga se activan los comando
        }

        private void ControlCambioLista()
        {
            BackgroundWorker worker = new BackgroundWorker();
            //var secureString = passwordContainer.Password;
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                if (currentEntidad.idtc== 0 || (currentEntidad.idtc!= 2 && currentEntidad.idtc!= 7 && currentEntidad.idtc!= 8))
                {
                    visibilidadClaseDocumento = Visibility.Visible;
                    listaDocumentosAnterioresCompleta = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllByEncargosImportacion(currentEncargo, currentEntidad.idtc));
                }
                else
                {
                    listaDocumentosAnterioresCompleta = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllByEncargosImportacion(currentEncargo, currentEntidad.idtc));
                }
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                isListaCargada = true;
            };
            worker.Dispose();
            worker.RunWorkerAsync();
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
            if (currentEntidad.idtc == 1)//Sumaria
            {
                if (comando == 1 || comando == 2 || comando == 3)
                {
                    if (currentEntidad.idbalance != null && currentEntidad.idbalance != 0)
                    {
                        selectedBalance = listaBalancePrincipal.Single(i => i.idbalance == currentEntidad.idbalance);

                        if (origen == "EncargoCedulasSumariasDetalle")
                        {
                            #region listados para seleccion  de cuentas desde el detalle
                            if (currentEntidad.idbalanceanterior != null && currentEntidad.idbalanceanterior != 0)
                            {
                                        visibilidadBalance = Visibility.Collapsed;
                                        listaBalanceDetalle = DetalleCedulaModelo.GetAllCreacionComparativo((int)currentEncargo.idsc, (int)currentEntidad.idbalance, (int)currentEntidad.idbalanceanterior, currentEncargo.idencargo, currentUsuario);
                                        visibilidadBalanceComparativo = Visibility.Visible;
                                        accesibilidadCuerpo = true;
                                        selectedBalComparativo = listaBalanceComparativo.Single(i => i.idbalance == currentEntidad.idbalance);
                            }
                            else
                            {
                                        visibilidadBalance = Visibility.Visible;
                                        listaBalanceDetalle = DetalleCedulaModelo.GetAllCreacionUnico((int)currentEncargo.idsc, (int)currentEntidad.idbalance, currentEncargo.idencargo, currentUsuario);
                                        visibilidadBalanceComparativo = Visibility.Collapsed;
                                        accesibilidadCuerpo = true;
                            }
                            #endregion fin listado para seleccion de cuentas
                            //Indicar cuentas ya seleccionadas
                            try
                            {
                                foreach (DetalleCedulaModelo item in currentEntidad.listaDetalleCedula)
                                {
                                    if (item.claseregistro == "D")
                                    {
                                        listaBalanceDetalle.Single(x => x.idcc == item.idcc).IsSelected = true;
                                        listaBalanceDetalle.Single(x => x.idcc == item.idcc).isuso = 1;//Bloqueando en caso de estar seleccionado
                                    }
                                }
                            }
                            catch (Exception e)
                            {
                                await mensajeAutoCerrado(e.ToString(), "", 3);
                            }

                        }
                        else
                        {
                            if (currentEntidad.idbalanceanterior != null && currentEntidad.idbalanceanterior != 0)
                            {
                                selectedBalComparativo = listaBalanceComparativo.Single(i => i.idbalance == currentEntidad.idbalance);
                                visibilidadBalance = Visibility.Collapsed;
                                visibilidadBalanceComparativo = Visibility.Visible;
                                //listaBalanceDetalle = DetalleCedulaModelo.GetAllCreacionComparativo((int)currentEncargo.idsc, (int)currentEntidad.idbalance, (int)currentEntidad.idbalanceanterior, currentEncargo.idencargo, currentUsuario);
                                listaBalanceDetalle = DetalleCedulaModelo.GetAllEdicion(currentEncargo, currentEntidad.idcedula);
                                //Filtrado de marcas
                                listaBalanceDetalle = new ObservableCollection<DetalleCedulaModelo>(listaBalanceDetalle.Where(x => x.claseregistro != "M"));
                            }
                            else
                            {
                                visibilidadBalance = Visibility.Visible;
                                visibilidadBalanceComparativo = Visibility.Collapsed;
                                //listaBalanceDetalle = DetalleCedulaModelo.GetAllCreacionUnico((int)currentEncargo.idsc, (int)currentEntidad.idbalance, currentEncargo.idencargo, currentUsuario);
                                listaBalanceDetalle = DetalleCedulaModelo.GetAllEdicion(currentEncargo, currentEntidad.idcedula);
                                //filtrado de marcas
                                listaBalanceDetalle = new ObservableCollection<DetalleCedulaModelo>(listaBalanceDetalle.Where(x => x.claseregistro != "M"));
                            }
                        }

                    }

                    if (currentEntidad.idvisita != null && currentEntidad.idvisita != 0)
                    {
                        selectedBalComparativo = listaBalanceComparativo.Single(i => i.idbalance == currentEntidad.idbalance);
                        visibilidadBalance = Visibility.Collapsed;
                        visibilidadBalanceComparativo = Visibility.Visible;
                    }
                }
            }
        }
        #endregion



        private async void ImportarDeEncargos()
        {
            iniciarComando();
            int continuar = 0;
            if (listaDocumentosAnteriores.Count > 0)
            {
                continuar = 0;
            }
            else
            {
                continuar = 1;//No hay registros
            }
            if (continuar == 0)
            {
                CedulaModelo temporal = new CedulaModelo(currentEncargo, currentUsuario);
                CedulaModelo itemImportar = new CedulaModelo();
                //Verificar que no exista nombre duplicado
                for (int k = 0; k < listaDocumentosAnteriores.Count; k++)
                {
                    if (listaDocumentosAnteriores[k].IsSelected)
                    {
                        //Importar
                        //ProgramaModelo tem = listaDocumentosAnteriores[k];
                        if (isListaCargada && listaDocumentosAnterioresCompleta.Count > 0)
                        {
                            itemImportar = listaDocumentosAnterioresCompleta.Single(x => x.idcedula == listaDocumentosAnteriores[k].idcedula);
                        }
                        else
                        {
                            //itemImportar = CedulaModelo.Find(listaDocumentosAnteriores[k].idcedula);
                        }
                        if (itemImportar.idcedula != 0)
                        {
                            temporal = new CedulaModelo(itemImportar, currentEncargo, currentUsuario);
                            #region Guardando

                            if (nombreUnico(temporal.titulocedula, listacurrentEntidad,temporal.idvisita) == 0)
                            {
                                try
                                {
                                    switch (CedulaModelo.Insert(temporal))
                                    {
                                        case 0://No se pudo insertar
                                            await mensajeAutoCerrado("No ha sido posible insertar el registro denominado " + temporal.titulocedula, "Este mensaje desaparecerá en segundos", 1);
                                            break;
                                        case 1://Se inserto con éxito
                                            await mensajeAutoCerrado("Registro insertado con éxito denominado " + temporal.titulocedula, "Este mensaje desaparecerá en segundos", 1);
                                            //fuenteCierre = 1;
                                            resultadoProceso = 1;//1 para  crear
                                                                 //CloseWindow();
                                            break;
                                    }
                                }
                                catch (Exception)
                                {
                                    await mensajeAutoCerrado("No ha sido posible insertar el registro denominado " + temporal.titulocedula, "Este mensaje desaparecerá en segundos", 1);
                                }
                            }
                            else
                            {
                                await mensajeAutoCerrado("El nombre ya esta siendo utilizado ", "Debe cambiar el nombre, no se importará", 1);
                            }

                            #endregion
                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "Se intentará con el siguiente");
                            iniciarComando();
                        }

                        listaDocumentosAnteriores[k].IsSelected = false;
                    }
                }
                fuenteCierre = 1;
                resultadoProceso = 4;//2 para  importar;
                CloseWindow();
            }
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
            if (opcionMenu != 14)
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
            else
            {
                if (currentEntidad.idvisita != null)
                {
                    resultadoProceso = (int)currentEntidad.idvisita;
                }
                else
                {
                        resultadoProceso = 100;
                }
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
            if (origen == "EncargoCedulasSumariasDetalle")
            {
                //Caso de  inserción de cuentas seleccionadas
                try
                {
                    //Se envian los detalles
                    ObservableCollection<DetalleCedulaModelo> listaDetalleCedulaAdicionales = new ObservableCollection<DetalleCedulaModelo>(listaBalanceDetalle.Where(x => x.IsSelected && x.isuso==0));
                    foreach (DetalleCedulaModelo item in listaDetalleCedulaAdicionales)
                    {
                        //Adicionando los registros nuevos
                        currentEntidad.listaDetalleCedula.Add(item);
                    }

                    if (listaDetalleCedulaAdicionales.Count > 0)
                    {
                        switch (CedulaModelo.InsertCuentas(currentEntidad))
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
                    else
                    {
                        await mensajeAutoCerrado("No seleccionó ningún registro nuevo", "Este mensaje desaparecerá en segundos", 1);
                        fuenteCierre = 1;
                        resultadoProceso = 1;//1 para  crear
                        CloseWindow();
                    }
                }
                catch (Exception)
                {
                    //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                    MessageBox.Show("No ha sido posible insertar el registro");
                }
            }
            else
            {
                if (nombreUnico(currentEntidad.titulocedula, listacurrentEntidad, currentEntidad.idvisita) == 0)
                {
                    if (currentEntidad.idtc == 1)
                    {
                        try
                        {
                            //Se envian los detalles
                            currentEntidad.listaDetalleCedula = new ObservableCollection<DetalleCedulaModelo>(listaBalanceDetalle.Where(x => x.IsSelected));
                            switch (CedulaModelo.Insert(currentEntidad))
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
                        }
                    }
                    else
                    {
                        switch (CedulaModelo.Insert(currentEntidad, true))
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

                        }
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El nombre ya esta siendo utilizado,", "seleccione otro nombre");
                }
            }
        }

        public void Copiar()
        {
            /*  iniciarComando();
              if ((currentEntidad.tipoAuditoriaModelo != null))
              {
                  if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                  {
                      currentEntidad.tipoAuditoriaModelo = null;
                  }
              }
              if (!string.IsNullOrEmpty(currentEntidad.titulocedula))
              {

                  if (nombreUnico(currentEntidad.titulocedula, listaEntidad) == 0)
                  {
                      if (CedulaModelo.CopiarModelo(currentEntidad))
                      {
                          finComando();
                          await dlg.ShowMessageAsync(this, "Registro copiado con éxito", "");
                          CloseWindow();
                          cerradoFinalVentana = true;
                          enviarMensajeHabilitar();
                      }
                      else
                      {
                          finComando();
                          await dlg.ShowMessageAsync(this, "No ha sido posible copiar el registro", "");
                      }
                  }
                  else
                  {
                      finComando();
                      //Mensaje en caso de indice mayor
                      await dlg.ShowMessageAsync(this, "Ya existe un registro con ese nombre", "Debe cambiar el nombre");
                  }

              }
              else
              {
                  finComando();
                  await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
              }
              //Nuevo();*/
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
                evaluar = Errors == 0 ;
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
            SelectionCarpetaCommand = new RelayCommand<TipoCedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionTipoCedulaModelo = entidad;
                if (entidad.id != 0)
                {
                    currentEntidad.idtc= entidad.id;
                }
            });
            SeleccionClaseDocumentoCommand = new RelayCommand<TipoCedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.idtc= entidad.id;
            });
            //cmdCargarPdf_Click = new RelayCommand(cmdCargarPDF);
            //cmdCargarFuente_Click = new RelayCommand(cmdCargarFuente);
            SelectionCarpetaCommand = new RelayCommand<TipoCedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionTipoCedulaModelo = entidad;
                if (entidad.id != 0)
                {
                    currentEntidad.idtc= entidad.id;
                    //currentEntidad.titulocedula = entidad.descripciontc;
                    currentEntidad.titulocedula = "Para eliminar error";
                }
                //else
                //{
                //    currentEntidad.padreidtc = 0;
                //    currentEntidad.titulocedula = "";
                //    currentEntidad.titulocedula = string.Empty;
                //}
            });

            CancelarPlantillaCommand = new RelayCommand(Cancelar);
            //SeleccionPlantillaCommand = new RelayCommand(ImportarPlantillas, canImport);
            CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
            SeleccionProgramaEncargoCommand = new RelayCommand(ImportarDeEncargos, canImportForEncargos);

            SeleccionClaseDocumentoCommand = new RelayCommand<TipoCedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.idtc= entidad.id;
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

            referenciarCommand = new RelayCommand(Modificar, CanReferenciarSave);//Para guardar la referencia

            supervisarCommand = new RelayCommand(Modificar, CanSupervisar);//Para guardar la referencia

            aprobarCommand = new RelayCommand(Modificar, CanAprobar);//Para guardar la referencia

            cerrarCommand = new RelayCommand(Modificar, CanCerrar);//Para guardar la referencia

            SeleccionBalanceCommand = new RelayCommand<BalanceModelo>(entidad =>
            {
                if (entidad == null) return;
                    currentEntidad.idbalance = entidad.idbalance;
                if (entidad.idbalance != 0)
                {
                    iniciarComando();
                    visibilidadBalance = Visibility.Visible;
                    accesibilidadCuerpo = false;
                    listaBalanceDetalle = DetalleCedulaModelo.GetAllCreacionUnico((int)currentEncargo.idsc,(int) currentEntidad.idbalance, currentEncargo.idencargo, currentUsuario);
                    listaBalanceComparativo = new ObservableCollection<BalanceModelo>(listaBalancePrincipal.ToList().Where(x => x.idbalance != entidad.idbalance));
                    visibilidadBalanceComparativo = Visibility.Collapsed;
                    finComando();
                    accesibilidadCuerpo = true;
                }
                else
                {
                    visibilidadBalance = Visibility.Collapsed;
                    accesibilidadCuerpo = false;
                    listaBalanceDetalle = new ObservableCollection<DetalleCedulaModelo>();
                    listaBalanceComparativo = new ObservableCollection<BalanceModelo>(listaBalancePrincipal.ToList());
                    visibilidadBalanceComparativo = Visibility.Collapsed;
                }

            });
            SeleccionBalanceComparativoCommand = new RelayCommand<BalanceModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.idbalanceanterior = entidad.idbalance;
                if (entidad.idbalance != 0)
                {
                    iniciarComando();
                    visibilidadBalance = Visibility.Collapsed;
                    accesibilidadCuerpo = false;
                    //listaBalanceDetalle = DetalleCedulaModelo.GetAllByIdBC(entidad.idbalance);
                    //listaBalanceComparativo = new ObservableCollection<BalanceModelo>(listaBalancePrincipal.ToList().Where(x => x.idbalance != entidad.idbalance));
                    listaBalanceDetalle = DetalleCedulaModelo.GetAllCreacionComparativo((int)currentEncargo.idsc,(int) currentEntidad.idbalance,(int) currentEntidad.idbalanceanterior, currentEncargo.idencargo, currentUsuario);
                    visibilidadBalanceComparativo = Visibility.Visible;
                    finComando();
                    accesibilidadCuerpo = true;
                }
                else
                {
                    visibilidadBalance = Visibility.Collapsed;
                    visibilidadBalanceComparativo = Visibility.Collapsed;
                    accesibilidadCuerpo = false;
                    listaBalanceDetalle = new ObservableCollection<DetalleCedulaModelo>();
                }
            });

            SeleccionVisitaCommand = new RelayCommand<VisitaModelo>(entidad =>
                            {
                                if (entidad == null) return;
                                currentEntidad.idvisita=entidad.id;
                            });
        }

        private bool CanNuevo()
        {
            bool evaluar = false;
            
            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                if (currentEntidad.idtc == 1)
                {
                    int valor = listaBalanceDetalle.Where(x => x.IsSelected).Count();
                    evaluar = Errors == 0 && listaBalanceDetalle.Where(x => x.IsSelected).Count() > 0;
                }
                else
                {
                   return evaluar=currentEntidad.idvisita != null;
                }
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
                && (!string.IsNullOrWhiteSpace(currentEntidad.fechacierre));
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
                        && (!string.IsNullOrWhiteSpace(currentEntidad.usuariocerro))
                        && (!string.IsNullOrEmpty(currentEntidad.conclusioncedula))
                        && (!string.IsNullOrWhiteSpace(currentEntidad.conclusioncedula));
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
                    case 2: //Editar solo actualiza la fecha de evaluación
                        if (nombreUnico(currentEntidad.titulocedula, listacurrentEntidad,currentEntidad.idvisita) == 1)
                        {
                            resultadoModificar = CedulaModelo.UpdateModelo(currentEntidad, true);
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "El nombre no puede repetirse", "Modifique  el nombre la cédula");
                        }
                        break;
                    case 8: //Referenciar
                        resultadoModificar = CedulaModelo.UpdateReferencia(currentEntidad);
                        break;
                    case 10://Cerrar
                        resultadoModificar = CedulaModelo.UpdateCierre(currentEntidad, currentUsuario,currentEntidad.conclusioncedula);
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
                }

                switch (resultadoModificar)
                {
                    case 0://No se pudo insertar
                        finComando();
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        break;
                    case 1://Se inserto con éxito
                        var controller = await dlg.ShowProgressAsync(this, "Operación con registro realizada con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
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


        private bool canImportForEncargos()
        {
            return (listaDocumentosAnteriores.Count(j => j.IsSelected) > 0);
        }

        private bool canImport()
        {
            //bool evaluar = false;
            return (listaDocumentosAnteriores.Count(j => j.IsSelected) > 0);
        }


        #region Verifica unicidad
        //Cada marca debe ser única
        public int nombreUnico(string nombre, ObservableCollection<CedulaModelo> listaBusqueda, int? idVisita)
        {
            int numeroRegistros = 0;
            if (listaBusqueda != null || listaBusqueda.Count > 0)
            {
                string nombreBuscado = nombre.ToUpper().Trim();
                numeroRegistros = listaBusqueda.Where(j => j.titulocedula.ToUpper().Trim() == nombreBuscado && j.idvisita==idVisita).Count();
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
