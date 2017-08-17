using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model;
using SGPTWpf.Messages.Herramientas;
using System.Windows;
using System.Linq;
using SGPTWpf.Model.Modelo.Indice;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Messages;

namespace SGPTWpf.ViewModel.Herramientas.Programas
{
    public sealed class DetallePlantillaIndiceControllerViewModel : ViewModeloBase
    {

        #region Propiedades privadas



        private DialogCoordinator dlg;

        private MetroDialogSettings configuracionDialogo;


        #region  maxdescripciondpi

        private int _maxdescripciondpi;
        private int maxdescripciondpi
        {
            get { return _maxdescripciondpi; }
            set { _maxdescripciondpi = value; }
        }

        #endregion

        #region  opcionMenu

        private int _opcionMenu;
        private int opcionMenu
        {
            get { return _opcionMenu; }
            set { _opcionMenu = value; }
        }

        #endregion

        #region  tokenRecepcion

        private string _tokenRecepcion;
        private string tokenRecepcion
        {
            get { return _tokenRecepcion; }
            set { _tokenRecepcion = value; }
        }

        #endregion

        #region  tokenEnvioCierre

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
        }

        #endregion

        #region  arranque

        private bool _arranque;
        private bool arranque
        {
            get { return _arranque; }
            set { _arranque = value; }
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

        #region FuenteCierre

        private int _fuenteCierre;
        private int fuenteCierre
        {
            get { return _fuenteCierre; }
            set { _fuenteCierre = value; }
        }

        #endregion

        public static int Errors { get; set; }//Para controllar los errores de edición

        #endregion

        #region Lista de entidades

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<DetallePlantillaIndiceModelo> _listaEntidadSeleccion;

        public ObservableCollection<DetallePlantillaIndiceModelo> listaEntidadSeleccion
        {
            get
            {
                return _listaEntidadSeleccion;
            }
            set
            {
                if (_listaEntidadSeleccion == value) return;

                _listaEntidadSeleccion = value;

                RaisePropertyChanged(listaEntidadSeleccionPropertyName);
            }
        }

        public ObservableCollection<DetallePlantillaIndiceModelo> listaDetalleSeleccion
        {
            get
            {
                return _listaEntidadSeleccion;
            }
            set
            {
                if (_listaEntidadSeleccion == value) return;

                _listaEntidadSeleccion = value;

                RaisePropertyChanged(listaEntidadSeleccionPropertyName);
            }
        }

        #endregion

        
        #region ViewModel Properties : listaDescripcionSeleccion

        public const string listaDescripcionSeleccionPropertyName = "listaDescripcionSeleccion";

        private ObservableCollection<string> _listaDescripcionSeleccion;

        public ObservableCollection<string> listaDescripcionSeleccion
        {
            get
            {
                return _listaDescripcionSeleccion;
            }
            set
            {
                if (_listaDescripcionSeleccion == value) return;

                _listaDescripcionSeleccion = value;

                RaisePropertyChanged(listaDescripcionSeleccionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetallePlantillaIndiceCompleta

        public const string listaDetallePlantillaIndicePropertyName = "listaDetallePlantillaIndiceCompleta";

        private ObservableCollection<DetallePlantillaIndiceModelo> _listaDetallePlantillaIndice;

        public ObservableCollection<DetallePlantillaIndiceModelo> listaDetallePlantillaIndiceCompleta
        {
            get
            {
                return _listaDetallePlantillaIndice;
            }
            set
            {
                if (_listaDetallePlantillaIndice == value) return;

                _listaDetallePlantillaIndice = value;
                RaisePropertyChanged(listaDetallePlantillaIndicePropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : lista tipo elemento Indice modelo 

        public const string listaTipoElementoCarpetaPropertyName = "listaTipoElementoCarpeta";

        private ObservableCollection<TipoElementoIndiceModelo> _listaTipoElementoCarpeta;

        public ObservableCollection<TipoElementoIndiceModelo> listaTipoElementoCarpeta
        {
            get
            {
                return _listaTipoElementoCarpeta;
            }
            set
            {
                if (_listaTipoElementoCarpeta == value) return;

                _listaTipoElementoCarpeta = value;

                RaisePropertyChanged(listaTipoElementoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista tipo carpeta

        public const string listaTipoCarpetaPropertyName = "listaTipoCarpeta";

        private ObservableCollection<TipoCarpetaModelo> _listaTipoCarpeta;

        public ObservableCollection<TipoCarpetaModelo> listaTipoCarpeta
        {
            get
            {
                return _listaTipoCarpeta;
            }
            set
            {
                if (_listaTipoCarpeta == value) return;

                _listaTipoCarpeta = value;

                RaisePropertyChanged(listaTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaEntidadSeleccionTEI

        public const string listaEntidadSeleccionTEIPropertyName = "listaEntidadSeleccionTEI";

        private ObservableCollection<TipoElementoIndiceModelo> _listaEntidadSeleccionTEI;

        public ObservableCollection<TipoElementoIndiceModelo> listaEntidadSeleccionTEI
        {
            get
            {
                return _listaEntidadSeleccionTEI;
            }
            set
            {
                if (_listaEntidadSeleccionTEI == value) return;

                _listaEntidadSeleccionTEI = value;

                RaisePropertyChanged(listaEntidadSeleccionTEIPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaEntidadFiltrada

        public const string listaEntidadFiltradaPropertyName = "listaEntidadFiltrada";

        private ObservableCollection<DetallePlantillaIndiceModelo> _listaEntidadFiltrada;

        public ObservableCollection<DetallePlantillaIndiceModelo> listaEntidadFiltrada
        {
            get
            {
                return _listaEntidadFiltrada;
            }
            set
            {
                if (_listaEntidadFiltrada == value) return;

                _listaEntidadFiltrada = value;

                RaisePropertyChanged(listaEntidadFiltradaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedTEIndice

        public const string selectedTEIndicePropertyName = "selectedTEIndice";

        private TipoElementoIndiceModelo _selectedTEIndice;

        public TipoElementoIndiceModelo selectedTEIndice
        {
            get
            {
                return _selectedTEIndice;
            }

            set
            {
                if (_selectedTEIndice == value) return;

                _selectedTEIndice = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedTEIndicePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionTEIndice

        public const string eleccionTEIndicePropertyName = "eleccionTEIndice";

        private TipoElementoIndiceModelo _eleccionTEIndice;

        public TipoElementoIndiceModelo eleccionTEIndice
        {
            get
            {
                return _eleccionTEIndice;
            }

            set
            {
                if (_eleccionTEIndice == value) return;

                _eleccionTEIndice = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionTEIndicePropertyName);
            }
        }

        #endregion

        #region Entidades

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

        #region ViewModel Property : selectedPadreEntidad 

        public const string selectedPadreEntidadPropertyName = "selectedPadreEntidad";

        private DetallePlantillaIndiceModelo _selectedPadreEntidad;

        public DetallePlantillaIndiceModelo selectedPadreEntidad
        {
            get
            {
                return _selectedPadreEntidad;
            }

            set
            {
                if (_selectedPadreEntidad == value) return;

                _selectedPadreEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedPadreEntidadPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : SelectedTipoCarpeta

        public const string SelectedTipoCarpetaPropertyName = "SelectedTipoCarpeta";

        private TipoCarpetaModelo _SelectedTipoCarpeta;

        public TipoCarpetaModelo SelectedTipoCarpeta
        {
            get
            {
                return _SelectedTipoCarpeta;
            }

            set
            {
                if (_SelectedTipoCarpeta == value) return;

                _SelectedTipoCarpeta = value;
                RaisePropertyChanged(SelectedTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : SelectedTipoElementoIndiceModelo

        public const string SelectedTipoElementoIndiceModeloPropertyName = "SelectedTipoElementoIndiceModelo";

        private TipoElementoIndiceModelo _SelectedTipoElementoIndiceModelo;

        public TipoElementoIndiceModelo SelectedTipoElementoIndiceModelo
        {
            get
            {
                return _SelectedTipoElementoIndiceModelo;
            }

            set
            {
                if (_SelectedTipoElementoIndiceModelo == value) return;

                _SelectedTipoElementoIndiceModelo = value;
                RaisePropertyChanged(SelectedTipoElementoIndiceModeloPropertyName);
                //Asignación del tipo de programa
                //currentEntidad.idTh = _SelectedTipoElementoIndiceModelo.id;
            }
        }

        #endregion


        #endregion


        #endregion


        #region ViewModel Properties publicas

        #region ViewModel Properties : listaIndicesDetalle

        public const string listaIndicesDetallePropertyName = "listaIndicesDetalle";

        private ObservableCollection<DetallePlantillaIndiceModelo> _listaIndicesDetalle;

        public ObservableCollection<DetallePlantillaIndiceModelo> listaIndicesDetalle
        {
            get
            {
                return _listaIndicesDetalle;
            }

            set
            {
                if (_listaIndicesDetalle == value) return;

                _listaIndicesDetalle = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaIndicesDetallePropertyName);
            }
        }

        #endregion

        #region  Primary key detalle indice

        public const string iddpiPropertyName = "iddpi";

        private int? _iddpi = 0;

        public int? iddpi
        {
            get
            {
                return _iddpi;
            }

            set
            {
                if (_iddpi == value)
                {
                    return;
                }

                _iddpi = value;
                RaisePropertyChanged(iddpiPropertyName);
            }
        }

        #endregion

        #region  Primary key de Tipo de carpeta idtc

        public const string idtcPropertyName = "idtc";

        private int _idtc = 0;

        public int idtc
        {
            get
            {
                return _idtc;
            }

            set
            {
                if (_idtc == value)
                {
                    return;
                }

                _idtc = value;
                RaisePropertyChanged(idtcPropertyName);
            }
        }

        #endregion

        #region  Primary key tipo de elemento del indice idtei

        public const string idteiPropertyName = "idtei";

        private int _idtei = 0;

        public int idtei
        {
            get
            {
                return _idtei;
            }

            set
            {
                if (_idtei == value)
                {
                    return;
                }

                _idtei = value;
                RaisePropertyChanged(idteiPropertyName);
            }
        }

        #endregion

        #region  Primary key Plantilla de indice idpi

        public const string idpiPropertyName = "idpi";

        private int _idpi = 0;

        public int idpi
        {
            get
            {
                return _idpi;
            }

            set
            {
                if (_idpi == value)
                {
                    return;
                }

                _idpi = value;
                RaisePropertyChanged(idpiPropertyName);
            }
        }

        #endregion

        #region  Primary key detalle indice padre iddpi

        public const string detiddpiPropertyName = "detiddpi";

        private int _detiddpi = 0;

        public int detiddpi
        {
            get
            {
                return _detiddpi;
            }

            set
            {
                if (_detiddpi == value)
                {
                    return;
                }

                _detiddpi = value;
                RaisePropertyChanged(detiddpiPropertyName);
            }
        }

        #endregion


        #region Propiedades : descripcionDpiPadre


        public const string descripcionDpiPadrePropertyName = "descripcionDpiPadre";

        private string _descripcionDpiPadre = string.Empty;

        public string descripcionDpiPadre
        {
            get
            {
                return _descripcionDpiPadre;
            }
            set
            {
                if (_descripcionDpiPadre == value)
                {
                    return;
                }
                _descripcionDpiPadre = value;
                RaisePropertyChanged(descripcionDpiPadrePropertyName);
            }
        }

        #endregion

        #region Propiedades : descripciondpi


        public const string descripciondpiPropertyName = "descripciondpi";

        private string _descripciondpi = string.Empty;

        public string descripciondpi
        {
            get
            {
                return _descripciondpi;
            }
            set
            {
                if (_descripciondpi == value)
                {
                    return;
                }
                _descripciondpi = value;
                RaisePropertyChanged(descripciondpiPropertyName);
            }
        }

        #endregion


        #region ordendpi Orden del detalle

        public const string ordendpiPropertyName = "ordendpi";

        private decimal? _ordendpi = 0;

        public decimal? ordendpi
        {
            get
            {
                return _ordendpi;
            }

            set
            {
                if (_ordendpi == value)
                {
                    return;
                }

                _ordendpi = value;
                RaisePropertyChanged(ordendpiPropertyName);
            }
        }

        #endregion

        #region referenciadpi del Detalle referenciadpi

        public const string referenciadpiPropertyName = "referenciadpi";

        private string _referenciadpi = string.Empty;

        public string referenciadpi
        {
            get
            {
                return _referenciadpi;
            }

            set
            {
                if (_referenciadpi == value)
                {
                    return;
                }

                _referenciadpi = value;
                RaisePropertyChanged(referenciadpiPropertyName);
            }
        }

        #endregion

        #region obligatoriodpi indica si  es obligatorio el documento

        public const string obligatoriodpiPropertyName = "obligatoriodpi";

        private bool _obligatoriodpi = false;

        public bool obligatoriodpi
        {
            get
            {
                return _obligatoriodpi;
            }

            set
            {
                if (_obligatoriodpi == value)
                {
                    return;
                }

                _obligatoriodpi = value;
                RaisePropertyChanged(obligatoriodpiPropertyName);
            }
        }

        #endregion


        #region sistemadpi

        public const string sistemadpiPropertyName = "sistemadpi";

        private bool _sistemadpi = false;

        public bool sistemadpi
        {
            get
            {
                return _sistemadpi;
            }

            set
            {
                if (_sistemadpi == value)
                {
                    return;
                }

                _sistemadpi = value;
                RaisePropertyChanged(sistemadpiPropertyName);
            }
        }

        #endregion

        #region estadodpi
        public const string estadodpiPropertyName = "estadodpi";

        private string _estadodpi = string.Empty;

        public string estadodpi
        {
            get
            {
                return _estadodpi;
            }

            set
            {
                if (_estadodpi == value)
                {
                    return;
                }

                _estadodpi = value;
                RaisePropertyChanged(estadodpiPropertyName);
            }
        }
        #endregion

        #region Nombre de usuario

        public const string inicialesusuarioPropertyName = "inicialesusuario";

        private string _inicialesusuario = string.Empty;

        public string inicialesusuario
        {
            get
            {
                return _inicialesusuario;
            }

            set
            {
                if (_inicialesusuario == value)
                {
                    return;
                }

                _inicialesusuario = value;
                RaisePropertyChanged(inicialesusuarioPropertyName);
            }
        }

        #endregion


        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetallePlantillaIndiceModelo _currentEntidad;

        public DetallePlantillaIndiceModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidad = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion


        #region ViewModel Property : currentEntidadDetalleIndice

        public const string currentEntidadDetalleIndicePropertyName = "currentEntidadDetalleIndice";

        private DetallePlantillaIndiceModelo _currentEntidadDetalleIndice;

        public DetallePlantillaIndiceModelo currentEntidadDetalleIndice
        {
            get
            {
                return _currentEntidadDetalleIndice;
            }

            set
            {
                if (_currentEntidadDetalleIndice == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadDetalleIndice = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadDetalleIndicePropertyName);
            }
        }

        #endregion


        #region ViewModel Property : currentEntidadPlantillaIndice

        public const string currentEntidadPlantillaIndicePropertyName = "currentEntidadPlantillaIndice";

        private PlantillaIndiceModelo _currentEntidadPlantillaIndice;

        public PlantillaIndiceModelo currentEntidadPlantillaIndice
        {
            get
            {
                return _currentEntidadPlantillaIndice;
            }

            set
            {
                if (_currentEntidadPlantillaIndice == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadPlantillaIndice = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPlantillaIndicePropertyName);
            }
        }

        #endregion


        #endregion


        #endregion

        #region Propiedades de ventanas

        #region ViewModel Properties : accesibilidadWindow

        public const string accesibilidadWindowPropertyName = "accesibilidadWindow";

        private bool _accesibilidadWindow = false;

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

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private Boolean _activarCaptura;

        public Boolean activarCaptura
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

        #endregion

        #region visibilidadDependencia

        public const string visibilidadDependenciaPropertyName = "visibilidadDependencia";

        private Visibility _visibilidadDependencia = Visibility.Collapsed;

        public Visibility visibilidadDependencia
        {
            get
            {
                return _visibilidadDependencia;
            }

            set
            {
                if (_visibilidadDependencia == value)
                {
                    return;
                }

                _visibilidadDependencia = value;
                RaisePropertyChanged(visibilidadDependenciaPropertyName);
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

        #region activarCrear

        public const string activarCrearPropertyName = "activarCrear";

        private bool _activarCrear = false;

        public bool activarCrear
        {
            get
            {
                return _activarCrear;
            }

            set
            {
                if (_activarCrear == value)
                {
                    return;
                }

                _activarCrear = value;
                RaisePropertyChanged(activarCrearPropertyName);
            }
        }

        #endregion

        #region activarConsultar

        public const string activarConsultarPropertyName = "activarConsultar";

        private bool _activarConsultar = false;

        public bool activarConsultar
        {
            get
            {
                return _activarConsultar;
            }

            set
            {
                if (_activarConsultar == value)
                {
                    return;
                }

                _activarConsultar = value;
                RaisePropertyChanged(activarConsultarPropertyName);
            }
        }

        #endregion

        #region activarEditar

        public const string activarEditarPropertyName = "activarEditar";

        private bool _activarEditar = false;

        public bool activarEditar
        {
            get
            {
                return _activarEditar;
            }

            set
            {
                if (_activarEditar == value)
                {
                    return;
                }

                _activarEditar = value;
                RaisePropertyChanged(activarEditarPropertyName);
            }
        }

        #endregion


        #endregion

        #region ViewModel Commands
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand<DetallePlantillaIndiceModelo> SelectionChangedCommand { get; set; }

        public RelayCommand<TipoElementoIndiceModelo> cambioListaCommand { get; set; }
        

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public DetallePlantillaIndiceControllerViewModel()
        {
            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            //Suscribiendo el mensaje
            _arranque = true;
            _tokenRecepcion = "DetalleDatosElementoAController";//Identifica la fuente de un mensaje generico
            _tokenEnvioCierre = "ControllerCerradoAViewModel";//Identifica la fuente de un mensaje generico
            _maxdescripciondpi = 200;
            _opcionMenu = 0;
            _resultadoProceso = 0;
            _fuenteCierre = 0;
            listaTipoElementoCarpeta = new ObservableCollection<TipoElementoIndiceModelo>(TipoElementoIndiceModelo.GetAllPresentacion());//Lista de tipo elemento  de carpeta
            listaTipoCarpeta = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAll());//Lista de carpeta
            listaDescripcionSeleccion = new ObservableCollection<string>();
            listaEntidadSeleccionTEI = new ObservableCollection<TipoElementoIndiceModelo>();
            Messenger.Default.Register<DetallePlantillaIndiceCrudMensaje>(this, tokenRecepcion, (detallePlantillaIndiceCrudMensaje) => ControlDetallePlantillaIndiceCrudMensaje(detallePlantillaIndiceCrudMensaje));
            dlg = new DialogCoordinator();
            accesibilidadWindow = false;
            RegisterCommands();
            arranque = true;
            Errors = 0;
            eleccionTEIndice = new TipoElementoIndiceModelo();
            selectedTEIndice = new TipoElementoIndiceModelo();
            _visibilidadDependencia = Visibility.Collapsed;
        }
        private void ControlDetallePlantillaIndiceCrudMensaje(DetallePlantillaIndiceCrudMensaje detalleHerramientoCrudMensaje)
        {
            Errors = 0;
            currentEntidad = detalleHerramientoCrudMensaje.detallePlantillaIndiceModelo;
            currentUsuario = detalleHerramientoCrudMensaje.usuarioModeloValidado;
            opcionMenu = detalleHerramientoCrudMensaje.comandoCrud;
            listaDetallePlantillaIndiceCompleta = detalleHerramientoCrudMensaje.listaElementos;
            ordendpi = currentEntidad.ordendpi;
            listaEntidadSeleccion = new ObservableCollection<DetallePlantillaIndiceModelo>(DetallePlantillaIndiceModelo.GetAll(currentEntidad.idpi,currentEntidad.iddpi));
            configuracionHerramientaCmdCrud(opcionMenu);
            if ((currentEntidad.idtei != 0) && (currentEntidad.idtei != null))
            {
                selectedTEIndice = listaTipoElementoCarpeta.Single(i => i.id == currentEntidad.idtei);
                SelectedTipoElementoIndiceModelo = listaTipoElementoCarpeta.Single(i => i.id == currentEntidad.idtei);
            }
            else
            {
                SelectedTipoElementoIndiceModelo = listaTipoElementoCarpeta[0];
            }
            if ((currentEntidad.detiddpi != 0) && (currentEntidad.detiddpi != null))
            {
                selectedPadreEntidad = listaEntidadSeleccion.Single(i => i.iddpi == currentEntidad.detiddpi);
            }
            else
            {
                selectedPadreEntidad = listaEntidadSeleccion[0];
            }
            Messenger.Default.Unregister<DetallePlantillaIndiceCrudMensaje>(this);
            finComando();
        }

        private async void configuracionHerramientaCmdCrud(int comando)
        {
            switch (comando.ToString())
            {
                case "1":
                    //accesibilidadWindow = true;
                    encabezadoPantalla = "Introduzca el elemento del  índice";
                    activarCaptura = true;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    listaDescripcionSeleccion = new ObservableCollection<string>();
                    listaEntidadFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>();
                    foreach (DetallePlantillaIndiceModelo item in listaEntidadSeleccion)
                    {
                        listaDescripcionSeleccion.Add(item.descripciondpi);
                    }
                    currentEntidad.listaDescripcionSeleccion = listaDescripcionSeleccion;
                    selectedTEIndice.listaEntidadSeleccionTEI = listaTipoElementoCarpeta;
                    visibilidadDependencia = Visibility.Collapsed;
                    break;
                case "2":
                    //accesibilidadWindow = true;
                    encabezadoPantalla = "Actualice los datos";
                    activarCaptura = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    activarCrear = false;
                    activarConsultar = false;
                    activarEditar = true;
                    listaDescripcionSeleccion = new ObservableCollection<string>();
                    foreach (DetallePlantillaIndiceModelo item in listaEntidadSeleccion)
                    {
                        if (currentEntidad.iddpi != item.iddpi)
                        {
                            listaDescripcionSeleccion.Add(item.descripciondpi);
                        }
                    }
                    currentEntidad.listaDescripcionSeleccion = listaDescripcionSeleccion;
                    selectedTEIndice.listaEntidadSeleccionTEI = listaTipoElementoCarpeta;
                    listaEntidadFiltrada = filtradoLista(currentEntidad);//Se crea la lista filtrada
                    switch (currentEntidad.idtei)
                        {
                            case 0:
                                visibilidadDependencia = Visibility.Collapsed;
                                selectedPadreEntidad = null;
                            break;
                            case 1://Carpeta
                                visibilidadDependencia = Visibility.Collapsed;
                                selectedPadreEntidad = null;
                                break;
                            default:
                                if (currentEntidad.detiddpi != null)
                                {
                                 selectedPadreEntidad = listaEntidadFiltrada.Single(i => i.iddpi == currentEntidad.detiddpi);
                                }
                                else
                                {
                                    selectedPadreEntidad = null;
                                }
                                visibilidadDependencia = Visibility.Visible;
                                break;
                        }

                    break;
                case "3":
                    //accesibilidadWindow = false;
                    encabezadoPantalla = "Datos del registro";
                    activarCaptura = false;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    activarCrear = false;
                    activarConsultar = true;
                    activarEditar = false;
                    foreach (DetallePlantillaIndiceModelo item in listaEntidadSeleccion)
                    {
                        if (currentEntidad.iddpi != item.iddpi)
                        {
                            listaDescripcionSeleccion.Add(item.descripciondpi);
                        }
                    }
                    currentEntidad.listaDescripcionSeleccion = listaDescripcionSeleccion;
                    selectedTEIndice.listaEntidadSeleccionTEI = listaTipoElementoCarpeta;
                    listaEntidadFiltrada = filtradoLista(currentEntidad);//Se crea la lista filtrada
                    switch (currentEntidad.idtei)
                    {
                        case 0:
                            visibilidadDependencia = Visibility.Collapsed;
                            selectedPadreEntidad = null;
                            break;
                        case 1://Carpeta
                            visibilidadDependencia = Visibility.Collapsed;
                            selectedPadreEntidad = null;
                            break;
                        default:
                            if (currentEntidad.detiddpi != null)
                            {
                                selectedPadreEntidad = listaEntidadFiltrada.Single(i => i.iddpi == currentEntidad.detiddpi);
                            }
                            else
                            {
                                selectedPadreEntidad = null;
                            }
                            visibilidadDependencia = Visibility.Visible;
                            break;
                    }
                    break;
                default:
                    await dlg.ShowMessageAsync(this, "Error en comunicacion de comando", "");
                    break;
            }
        }


        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            iniciarComando();
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            fuenteCierre = 1;
            CloseWindow();
        }

        private void OkCierre()
        {
            iniciarComando();
            fuenteCierre = 1;
            CloseWindow();

        }

        private void Salir()
        {
            if (fuenteCierre == 0)
            {
                iniciarComando();
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
            //listaDetallePrograma = null;
        }

        public async void Guardar()
        {
            iniciarComando();
            if (selectedPadreEntidad != null && selectedPadreEntidad.iddpi != 0)
                {
                    currentEntidad.detalleplantillaindicePadre = selectedPadreEntidad;
                
                }
                else
                { 
                    if (selectedPadreEntidad==null ||selectedPadreEntidad.iddpi == 0)
                    {
                        currentEntidad.detalleplantillaindicePadre = null;
                    }
                }
                currentEntidad.ordendpi = ordenRegistro(currentEntidad.detalleplantillaindicePadre);
                if (DetallePlantillaIndiceModelo.Insert(currentEntidad, true))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    resultadoProceso = 1;
                    CloseWindow();
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                }

        }

        public async void Modificar()
        {
                if (selectedPadreEntidad != null && selectedPadreEntidad.iddpi != 0)
                {
                    if (currentEntidad.detalleplantillaindicePadre != null)
                    {
                        if (currentEntidad.detalleplantillaindicePadre.idpi != selectedPadreEntidad.iddpi)
                        {
                            currentEntidad.detalleplantillaindicePadre = selectedPadreEntidad;
                        }
                    }
                    else
                    {
                        currentEntidad.detalleplantillaindicePadre = selectedPadreEntidad;
                    }
                }
                else
                {
                    if (selectedPadreEntidad != null || selectedPadreEntidad.iddpi == 0)
                    {
                        currentEntidad.detalleplantillaindicePadre = null;
                    }
                }
                currentEntidad.ordendpi = ordenRegistro(currentEntidad.detalleplantillaindicePadre);
                if (DetallePlantillaIndiceModelo.UpdateModelo(currentEntidad, true))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 1 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    resultadoProceso = 2;
                    CloseWindow();
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                }
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



        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            //Messenger.Default.Send("terminoProceso", tokenEnvioCierre);
            Messenger.Default.Send(resultadoProceso, tokenEnvioCierre);
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
                evaluar = Errors==0 && 
                          ((currentEntidad.tipoElementoIndiceModelo != null));
                return evaluar;
            }
        }

        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {

            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(OkCierre);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<DetallePlantillaIndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
            cambioListaCommand = new RelayCommand<TipoElementoIndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionTEIndice = entidad;
                if (entidad.id != 0)
                {
                    currentEntidad.idtei = entidad.id;
                    currentEntidad.tipoElementoIndiceModelo = entidad;

                    listaEntidadFiltrada = filtradoLista(entidad);
                    if (listaEntidadFiltrada.Count > 1)
                    {
                        selectedPadreEntidad = listaEntidadFiltrada[0];//Cambio la seleccion debe eliminarse lo escogido
                        visibilidadDependencia = Visibility.Visible;
                    }
                    else
                    {
                        selectedPadreEntidad = null;
                        visibilidadDependencia = Visibility.Collapsed;
                    }
                }
                else
                {
                    currentEntidad.idtei = entidad.id;
                }
                    switch (currentEntidad.idtei)
                    {
                        case 0:
                            visibilidadDependencia = Visibility.Collapsed;
                            selectedPadreEntidad = null;
                            break;
                        case 1://Carpeta
                            visibilidadDependencia = Visibility.Collapsed;
                            selectedPadreEntidad = null;
                            break;
                        default:
                            if (currentEntidad.detiddpi != null)
                            {
                                selectedPadreEntidad = listaEntidadFiltrada.Single(i => i.iddpi == currentEntidad.detiddpi);
                            }
                            else
                            {
                                selectedPadreEntidad = listaEntidadFiltrada[0]; 
                            }
                            visibilidadDependencia = Visibility.Visible;
                            break;
                    }
            });
        }

        #endregion

        private ObservableCollection<DetallePlantillaIndiceModelo> filtradoLista(DetallePlantillaIndiceModelo entidad)
        {
            return filtradoLista(entidad.descripciontei);
        }

        private ObservableCollection<DetallePlantillaIndiceModelo> filtradoLista(TipoElementoIndiceModelo entidad)
        {
            return filtradoLista(entidad.descripcion);//Descripcion del tipo de procedimiento
        }

        private ObservableCollection<DetallePlantillaIndiceModelo> filtradoLista(string TipoProcedimiento)
        {
            ObservableCollection<DetallePlantillaIndiceModelo> listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>();
            if (TipoProcedimiento == null || string.IsNullOrEmpty(TipoProcedimiento))
            {
                return listaFiltrada;
            }
            else
            {
                //Filtrar la lista según la selección
                switch (TipoProcedimiento.ToUpper())
                {
                    case "CARPETA":
                        break;
                    case "TITULO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-CARPETAS"));
                        break;
                    case "TÍTULO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-CARPETAS"));
                        break;
                    case "INDICACIONES":
                        break;
                    case "ALCANCE":
                        break;
                    case "SUB-TÍTULO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "TÍTULO"));
                        break;
                    case "SUB-TITULO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "TITULO"));
                        break;
                    case "SUB-SUB-TÍTULO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "SUB-TÍTULO"));
                        break;
                    case "SUB-SUB-TITULO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "SUB-TITULO"));
                        break;
                    case "SUB-CARPETA":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CARPETA"));
                        break;
                    case "SUB-SUB-CARPETAS":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "SUB-CARPETA"));
                        break;
                    case "SUB-CARPETAS":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CARPETA"));
                        break;
                    case "SUB-SUB-CARPETA":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "SUB-CARPETA"));
                        break;
                    case "CÉDULA":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "TÍTULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-TITULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-TITULO" || 
                                                                                                                                x.descripciontei.ToUpper() == "SUB-CARPETA" || 
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-CARPETAS"));
                        break;
                    case "ANALÍTICA":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CÉDULA" ||
                                                                                                                                x.descripciontei.ToUpper() == "TÍTULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-TITULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-TITULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-CARPETAS"));
                        break;
                    case "ARCHIVO":
                        listaFiltrada = new ObservableCollection<DetallePlantillaIndiceModelo>(listaEntidadSeleccion.Where(x => x.descripciontei.ToUpper() == "CARPETA" ||
                                                                                                                                x.descripciontei.ToUpper() == "TÍTULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-TITULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-TITULO" ||
                                                                                                                                x.descripciontei.ToUpper() == "SUB-CARPETA" || 
                                                                                                                                x.descripciontei.ToUpper() == "SUB-SUB-CARPETAS" || 
                                                                                                                                x.descripciontei.ToUpper() == "CÉDULA"|| 
                                                                                                                                x.descripciontei.ToUpper() == "ANALÍTICA"));
                        break;
                }
                if (listaFiltrada.Count > 0)
                {
                    foreach (DetallePlantillaIndiceModelo item in listaFiltrada)
                    {
                        item.descripcionPresentacion = item.ordenDhPresentacion + "-" + item.descripciondpi;
                    }

                }
                listaFiltrada.Insert(0, listaEntidadSeleccion[0]);//Inserto la opción de  ninguno
                return listaFiltrada;
            }
        }


        private decimal ordenRegistro(DetallePlantillaIndiceModelo padre)
        {
            decimal factorSuma;
            decimal ordenRespuesta = 0;
            if ((padre != null && padre.iddpi!=0))
            {
                if (padre.iddpi != 0)
                {
                    int registros = DetallePlantillaIndiceModelo.ContarSubRegistros(padre.iddpi) + 1;
                    //Tiene el padre un padre
                    if (padre.detiddpi == null)
                    {
                        //No  tiene padres
                        factorSuma = (decimal)0.1;
                    }
                    else
                    {
                        //es un hijo
                        factorSuma = (decimal)0.1;
                        int posicionPunto = padre.ordenDhPresentacion.IndexOf(".");
                        if (posicionPunto == -1)
                        {
                            factorSuma = (decimal)0.1;
                        }
                        else
                        {
                            int largo = padre.ordenDhPresentacion.Length - posicionPunto - 1;
                            switch (largo)
                            {
                                case 0:
                                    factorSuma = (decimal)0.1;
                                    break;
                                case 1:
                                    factorSuma = factorSuma / 10;
                                    break;
                                case 2:
                                    factorSuma = factorSuma / 100;
                                    break;
                                case 3:
                                    factorSuma = factorSuma / 1000;
                                    break;
                                case 4:
                                    factorSuma = factorSuma / 10000;
                                    break;
                                case 5:
                                    factorSuma = factorSuma / 100000;
                                    break;
                                case 6:
                                    factorSuma = factorSuma / 1000000;
                                    break;
                                default:
                                    factorSuma = factorSuma / 10000000;
                                    break;
                            }
                        }
                    }
                    if (registros == 1)
                    {
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordendpi, factorSuma);
                    }
                    else
                    {
                        //decimal suma = Decimal.Add((Decimal)0.01, (decimal)0.01 * registros);
                        //currentEntidad.ordenDh = Decimal.Add((Decimal)_selectedPadreEntidad.ordenDh, suma);
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordendpi, factorSuma * registros);
                    }
                }
                else
                {
                    if (opcionMenu == 1)
                    {
                        ordenRespuesta = (decimal)listaEntidadSeleccion.Max(x => x.ordendpi) + 10;
                    }
                    else
                    {
                        ordenRespuesta = (decimal)listaEntidadSeleccion.Max(x => x.ordendpi) + 10;
                    }
                }
            }
            else
            {
                if (opcionMenu == 1)
                {
                    ordenRespuesta =(decimal) listaEntidadSeleccion.Max(x=>x.ordendpi) + 10;
                }
                else
                {
                    ordenRespuesta = (decimal)listaEntidadSeleccion.Max(x => x.ordendpi) + 10;
                }
            }
            return ordenRespuesta;
        }

        #region Verifica unicidad
        //Cada marca debe ser única
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
            if (opcionMenu == 3)
            {
                accesibilidadWindow = false;
            }
            else
            {
                accesibilidadWindow = true;
            }
        }
    }
}
