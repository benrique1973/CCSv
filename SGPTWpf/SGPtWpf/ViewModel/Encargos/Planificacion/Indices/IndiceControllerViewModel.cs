using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using CapaDatos;
using System.Linq;
using System.Windows;
using SGPTWpf.Model.Modelo.Indice;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices
{

    public sealed class IndiceControllerViewModel : ViewModeloBase
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

        #region ViewModel Properties listaEntidadPlantilla Indice

        #region ViewModel Properties : listaEntidadPlantilla Indice

        public const string listaEntidadPropertyName = "listaEntidad";

        private ObservableCollection<PlantillaIndiceModelo> _listaEntidad;

        public ObservableCollection<PlantillaIndiceModelo> listaEntidad
        {
            get
            {
                return _listaEntidad;
            }
            set
            {
                if (_listaEntidad == value) return;

                _listaEntidad = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }
        #endregion

        #region ViewModel Properties : listaPlantillas

        public const string listaPlantillasPropertyName = "listaPlantillas";

        private ObservableCollection<PlantillaIndiceModelo> _listaPlantillas;

        public ObservableCollection<PlantillaIndiceModelo> listaPlantillas
        {
            get
            {
                return _listaPlantillas;
            }

            set
            {
                if (_listaPlantillas == value) return;

                _listaPlantillas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPlantillasPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidadPlantilla

        public const string currentEntidadPlantillaPropertyName = "currentEntidadPlantilla";

        private PlantillaIndiceModelo _currentEntidadPlantilla;

        public PlantillaIndiceModelo currentEntidadPlantilla
        {
            get
            {
                return _currentEntidadPlantilla;
            }

            set
            {
                if (_currentEntidadPlantilla == value) return;

                _currentEntidadPlantilla = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPlantillaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listacurrentEntidad

        public const string listacurrentEntidadPropertyName = "listacurrentEntidad";

        private ObservableCollection<TipoCarpetaModelo> _listacurrentEntidad;

        public ObservableCollection<TipoCarpetaModelo> listacurrentEntidad
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


        #region ViewModel Properties : listaCarpetaSeleccion

        public const string listaCarpetaSeleccionPropertyName = "listaCarpetaSeleccion";

        private ObservableCollection<TipoCarpetaModelo> _listaCarpetaSeleccion;

        public ObservableCollection<TipoCarpetaModelo> listaCarpetaSeleccion
        {
            get
            {
                return _listaCarpetaSeleccion;
            }

            set
            {
                if (_listaCarpetaSeleccion == value) return;

                _listaCarpetaSeleccion = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCarpetaSeleccionPropertyName);
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

        #region ViewModel Properties : listaTipoCarpetaModelo Carpeta

        public const string listaTipoCarpetaModeloPropertyName = "listaTipoCarpetaModelo";

        private ObservableCollection<TipoCarpetaModelo> _listaTipoCarpetaModelo;

        public ObservableCollection<TipoCarpetaModelo> listaTipoCarpetaModelo
        {
            get
            {
                return _listaTipoCarpetaModelo;
            }
            set
            {
                if (_listaTipoCarpetaModelo == value) return;

                _listaTipoCarpetaModelo = value;

                RaisePropertyChanged(listaTipoCarpetaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista tipo carpeta

        public const string listaTipoCarpetaPropertyName = "listaTipoCarpeta";

        private ObservableCollection<tipocarpeta> _listaTipoCarpeta;

        public ObservableCollection<tipocarpeta> listaTipoCarpeta
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

        #region ViewModel Property : selectedTipoCarpeta

        public const string selectedTipoCarpetaPropertyName = "selectedTipoCarpeta";

        private tipocarpeta _selectedTipoCarpeta;

        public tipocarpeta selectedTipoCarpeta
        {
            get
            {
                return _selectedTipoCarpeta;
            }

            set
            {
                if (_selectedTipoCarpeta == value) return;

                _selectedTipoCarpeta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionTipoCarpeta

        public const string eleccionTipoCarpetaPropertyName = "eleccionTipoCarpeta";

        private tipocarpeta _eleccionTipoCarpeta;

        public tipocarpeta eleccionTipoCarpeta
        {
            get
            {
                return _eleccionTipoCarpeta;
            }

            set
            {
                if (_eleccionTipoCarpeta == value) return;

                _eleccionTipoCarpeta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidadCarpetaDetalle Programa Modelo

        public const string currentEntidadCarpetaDetallePropertyName = "currentEntidadCarpetaDetalle";

        private index _currentEntidadCarpetaDetalle;

        public index currentEntidadCarpetaDetalle
        {
            get
            {
                return _currentEntidadCarpetaDetalle;
            }

            set
            {
                if (_currentEntidadCarpetaDetalle == value) return;

                _currentEntidadCarpetaDetalle = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadCarpetaDetallePropertyName);
            }
        }

        #endregion

        #region activarDescripcionIndice

        public const string activarDescripcionIndicePropertyName = "activarDescripcionIndice";

        private bool _activarDescripcionIndice = false;

        public bool activarDescripcionIndice
        {
            get
            {
                return _activarDescripcionIndice;
            }

            set
            {
                if (_activarDescripcionIndice == value)
                {
                    return;
                }

                _activarDescripcionIndice = value;
                RaisePropertyChanged(activarDescripcionIndicePropertyName);
            }
        }

        #endregion

        #region Propiedades : descripcionpi //Nombre del indice maximo 40 


        public const string descripcionPropertyName = "descripcionpi";

        private string _descripcion = string.Empty;


        public string descripcionpi
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

        #region Primary key Plantilla Indice


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

                _id = value;
                RaisePropertyChanged(idpiPropertyName);
            }
        }

        #endregion

        #region Primary key Tipo Auditoria


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

        #region sistemapi


        public const string sistemapiPropertyName = "sistemapi";

        private bool _sistemapi = false;


        public bool sistemapi
        {
            get
            {
                return _sistemapi;
            }

            set
            {
                if (_sistemapi == value)
                {
                    return;
                }

                _sistemapi = value;
                RaisePropertyChanged(sistemapiPropertyName);
            }
        }

        #endregion

        #region estadopi


        public const string estadopiPropertyName = "estadopi";

        private string _estadopi = string.Empty;

        public string estadopi
        {
            get
            {
                return _estadopi;
            }

            set
            {
                if (_estadopi == value)
                {
                    return;
                }

                _estadopi = value;
                RaisePropertyChanged(estadopiPropertyName);
            }
        }

        #endregion

        #region fechacreadopi


        public const string fechacreadopiPropertyName = "fechacreadopi";

        private string _fechacreadopi = string.Empty;

        public string fechacreadopi
        {
            get
            {
                return _fechacreadopi;
            }

            set
            {
                if (_fechacreadopi == value)
                {
                    return;
                }

                _fechacreadopi = value;
                RaisePropertyChanged(fechacreadopiPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private PlantillaIndiceModelo _currentEntidad;

        public PlantillaIndiceModelo currentEntidad
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

        #region ViewModel Property : currentEntidadCarpeta

        public const string currentEntidadCarpetaPropertyName = "currentEntidadCarpeta";

        private TipoCarpetaModelo _currentEntidadCarpeta;

        public TipoCarpetaModelo currentEntidadCarpeta
        {
            get
            {
                return _currentEntidadCarpeta;
            }

            set
            {
                if (_currentEntidadCarpeta == value) return;

                _currentEntidadCarpeta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadCarpetaPropertyName);
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

        public RelayCommand<tipocarpeta> SelectionCarpetaCommand { get; set; }


        #region Importacion

        public RelayCommand CancelarProgramaEncargoCommand { get; set; }//Seleccion desde el encargo
        public RelayCommand SeleccionProgramaEncargoCommand { get; set; }//seleccion desde el encargo

        public RelayCommand CancelarPlantillaCommand { get; set; }//Seleccion desde las plantillas
        public RelayCommand SeleccionPlantillaCommand { get; set; }//seleccion desde las plantillas

        public RelayCommand<PlantillaIndiceModelo> SelectionPlantillaChangedCommand { get; set; }

        public RelayCommand<TipoCarpetaModelo> SelectionCarpetaChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateSupervisionChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateAprobacionCommand { get; set; }


        public RelayCommand referenciarCommand { get; set; }//seleccion desde las plantillas
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }

        public RelayCommand cerrarCommand { get; set; }


        #endregion


        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public IndiceControllerViewModel()
        {
            /*
           //Herramienta/Indice
            _origen = null;
            _cerradoFinalVentana = false;//Controla el cierre de la ventana
            _tokenEnvio = "PlantillaIndiceController";
            _tokenRecepcion = "DatosElementoADetalle";//Identifica la fuente de un mensaje generico
            _maxDescripcion = 40;
            _numeroProcesoCrudRecibido = 0;
            _opcionMenu = 0;
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            //Suscribiendo el mensaje
            listaTiposAuditoria = new ObservableCollection<TipoAuditoriaModelo>(TipoAuditoriaModelo.GetAllCombo());
            listaTipoCarpeta = new ObservableCollection<tipocarpeta>(TipoCarpetaModelo.GetAllCapaDatosSeleccion());//Lista de carpeta
            listacurrentEntidad = new ObservableCollection<TipoCarpetaModelo>();
            Errors = 0;
            Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcion, (plantillaIndiceMensaje) => ControlPlantillaIndiceMensaje(plantillaIndiceMensaje));
            RegisterCommands();
            //Recibe un numero para procesar solo el último mensaje
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            dlg = new DialogCoordinator();
            accesibilidadWindow = false;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _visibilidadPlantilla = Visibility.Collapsed;
            _selectedTipoCarpeta = new tipocarpeta();
            _eleccionTipoCarpeta = new tipocarpeta();
            _activarDescripcionIndice = true;
            _currentEncargo = new EncargoModelo();
            _currentEntidad = new PlantillaIndiceModelo();
            _currentEntidadCarpeta = new TipoCarpetaModelo();
            _eleccionTipoCarpeta = new tipocarpeta();
            */
    }

        public IndiceControllerViewModel(string origenLlamada)
        {
            finInicializacion = false;
            //Documentacion/Planificacion/Indices
            _origen = origenLlamada;
            _cerradoFinalVentana = false;//Controla el cierre de la ventana
            _maxDescripcion = 40;
            _numeroProcesoCrudRecibido = 0;
            _opcionMenu = 0;
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            //Suscribiendo el mensaje
            listaTipoCarpeta = new ObservableCollection<tipocarpeta>(TipoCarpetaModelo.GetAllCapaDatosSeleccion());//Lista de carpeta
            listacurrentEntidad = new ObservableCollection<TipoCarpetaModelo>();
            Errors = 0;
            //Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcion, (plantillaIndiceMensaje) => ControlPlantillaIndiceMensaje(plantillaIndiceMensaje));
            RegisterCommandsDocumentacion();
            //Recibe un numero para procesar solo el último mensaje
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            dlg = new DialogCoordinator();
            accesibilidadWindow = false;

            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _visibilidadPlantilla = Visibility.Collapsed;
            _selectedTipoCarpeta = new tipocarpeta();
            _eleccionTipoCarpeta = new tipocarpeta();
            _activarDescripcionIndice = false;

            _currentEncargo = new EncargoModelo();
            _currentEntidad = new PlantillaIndiceModelo();
            _currentEntidadCarpeta = new TipoCarpetaModelo();
            _eleccionTipoCarpeta = new tipocarpeta();

            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            switch (origenLlamada)
            {
                case "Documentacion"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosControllerIndices";
                    _tokenRecepcion = "datosEDIndices";
                    #endregion
                    break;
                case "DocumentacionIndiceModelo":
                    #region Indice documentacion
                    _tokenEnvio = "datosEncargoDocumentacionControllerIndices";
                    _tokenRecepcion = "datosEncargoDocumentacionIndices";
                    #endregion
                    break;
                case "IndiceModeloCerrar":
                    #region Cierre carpeta
                    _tokenEnvio = "datosEncargoCierreControllerIndices";
                    _tokenRecepcion = "datosEncargoCierreIndices";
                    #endregion
                    break;

            }
            //Suscribiendo el mensaje
            Messenger.Default.Register<IndiceMsj>(this, tokenRecepcion, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            _currentEncargo = new EncargoModelo();


            #region Importacion

            _listaPlantillas = new ObservableCollection<PlantillaIndiceModelo>();
            _listaCarpetaSeleccion = new ObservableCollection<TipoCarpetaModelo>();
            currentEntidadPlantilla = null;

            #endregion
            _fechacierre = new DateTime((DateTime.Now.Year), 1, 1); 
            _fechaaprobacion= new DateTime((DateTime.Now.Year), 1, 1);
            _fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
        }

        private async void ControlDatosMsj(IndiceMsj datosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            //FuenteLlamada = datosMsj.fuenteLlamado;
            //Carga de combo de clase de balance
            listacurrentEntidad = datosMsj.listaTipoCarpetaModelo;
            //Carga de combo de periodicidad
            currentEntidadCarpeta = datosMsj.tipoCarpetaModelo;
            currentEntidadCarpeta.idencargotc = currentEncargo.idencargo;
            currentEntidadCarpetaDetalle = new index();
            //Filtrada por las ya existentes
            listaTipoCarpeta = new ObservableCollection<tipocarpeta>(TipoCarpetaModelo.GetAllCapaDatosSeleccion());//Lista de carpeta
                switch (datosMsj.opcionMenuCrud)
                {
                    case 1://Crear 
                        encabezadoPantalla = "Seleccione la carpeta de auditoría a crear";
                        accesibilidadWindow = true;
                        visibilidadCrear = Visibility.Visible;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Collapsed;
                        visibilidadCopiar = Visibility.Collapsed;
                        descripcionpi = string.Empty;
                        if (listacurrentEntidad.Count > 0)
                        {
                            tipocarpeta temporal = new tipocarpeta();
                            //Eliminar las carpetas ya existentes
                            foreach (TipoCarpetaModelo item in listacurrentEntidad)
                            {
                                if (listaTipoCarpeta.Count > 0)
                                {
                                    temporal = listaTipoCarpeta.SingleOrDefault(x => x.idtc == item.padreidtc);
                                    if (temporal != null)
                                    {
                                        listaTipoCarpeta.Remove(temporal);
                                        temporal = null;
                                    }
                                }
                            }
                        }
                        if (listaTipoCarpeta.Count == 0)
                        {
                            accesibilidadWindow = false;
                            Mouse.OverrideCursor = Cursors.Wait;
                            var controller = await dlg.ShowProgressAsync(this, "Ya estan creadas todas las carpetas", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            fuenteCierre = 1;
                            CloseWindow();
                        }
                        break;
                    case 2://Editar, no sera activada
                        encabezadoPantalla = "No puede modificarse el tipo de carpeta";
                        accesibilidadWindow = false;
                        descripcionpi = currentEntidad.descripcionpi;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Visible;
                        visibilidadConsultar = Visibility.Collapsed;
                        visibilidadCopiar = Visibility.Collapsed;
                        selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidadCarpeta.padreidtc);
                        eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                        break;
                    case 3://Consultar
                        encabezadoPantalla = "Consulta del tipo de carpeta";
                        descripcionpi = currentEntidadCarpeta.descripcion;
                        accesibilidadWindow = false;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Visible;
                        visibilidadCopiar = Visibility.Collapsed;
                        selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidadCarpeta.padreidtc);
                        eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                        break;
                case 6://Importar de las plantillas
                    listacurrentEntidad = datosMsj.listaTipoCarpetaModelo;
                    listaPlantillas = new ObservableCollection<PlantillaIndiceModelo>(PlantillaIndiceModelo.GetAll());
                    //Remover todas las carpetas ya existentes
                    ObservableCollection<PlantillaIndiceModelo> listaPlantillaTemporal = new ObservableCollection<PlantillaIndiceModelo>();
                    foreach (TipoCarpetaModelo item in listacurrentEntidad )
                    {
                        listaPlantillaTemporal = new ObservableCollection<PlantillaIndiceModelo>(listaPlantillas.Where(x=>x.idtcpi==item.padreidtc));
                        if (listaPlantillaTemporal.Count > 0)
                        {
                            foreach (PlantillaIndiceModelo itemRemover in listaPlantillaTemporal)
                            {
                                listaPlantillas.Remove(itemRemover);
                            }
                        }
                    }

                    visibilidadCrear = Visibility.Visible;
                    accesibilidadWindow = true;
                    if (!(listaPlantillas.Count > 0))
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
                    listaCarpetaSeleccion = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAllByEncargosImportacion(currentEncargo.idencargo));
                    visibilidadCopiar = Visibility.Visible;
                    accesibilidadWindow = true;
                    if (listaCarpetaSeleccion.Count > 0)
                    {
                        currentEntidadCarpeta=new TipoCarpetaModelo(currentEncargo);
                        ObservableCollection<TipoCarpetaModelo> listaCarpetaTemporal = new ObservableCollection<TipoCarpetaModelo>();
                        foreach (TipoCarpetaModelo item in listacurrentEntidad)
                        {
                            listaCarpetaTemporal = new ObservableCollection<TipoCarpetaModelo>(listaCarpetaSeleccion.Where(x => x.padreidtc == item.padreidtc));
                            if (listaCarpetaTemporal.Count > 0)
                            {
                                foreach (TipoCarpetaModelo itemRemover in listaCarpetaTemporal)
                                {
                                    listaCarpetaSeleccion.Remove(itemRemover);
                                }
                            }
                        }
                        if (!(listaCarpetaSeleccion.Count > 0))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Ya existen todos los indices posibles, no puede hacer la importación", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            fuenteCierre = 1;
                            resultadoProceso = 0;//1 para  crear
                            CloseWindow();
                        }
                    }
                    else
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
            Messenger.Default.Unregister<IndiceMsj>(this, tokenRecepcion);
            finComando();
            finInicializacion = true;//Termino la carga se activan los comando
        }

        private async void llenadoDatos()
        {
            //Llenar fecha de cierre
            if (currentEntidadCarpeta.fechacierre != null && currentEntidadCarpeta.fechacierre != "")
            {
                try
                {
                    fechacierre = MetodosModelo.convertirFecha(currentEntidadCarpeta.fechacierre);
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
            if (currentEntidadCarpeta.fechasupervision != null && currentEntidadCarpeta.fechasupervision != "")
            {
                try
                {
                    fechasupervision = MetodosModelo.convertirFecha(currentEntidadCarpeta.fechasupervision);
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
            if (currentEntidadCarpeta.fechaaprobacion != null && currentEntidadCarpeta.fechaaprobacion != "")
            {
                try
                {
                    fechaaprobacion = MetodosModelo.convertirFecha(currentEntidadCarpeta.fechaaprobacion);
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

        private void ControlPlantillaIndiceMensaje(PlantillaIndiceMensaje plantillaIndiceMensaje)
        {
            currentEntidad = plantillaIndiceMensaje.elementoMensaje;
            listaEntidad = plantillaIndiceMensaje.listaMensaje;
            numeroProcesoCrudRecibido = plantillaIndiceMensaje.numeroProcesoCrudEnviado + 1;
            switch (plantillaIndiceMensaje.comandoCrud)
            {
                case 1:
                    encabezadoPantalla = "Ingrese los datos para  la plantilla de índice";
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    descripcionpi = string.Empty;
                    break;
                case 2:
                    encabezadoPantalla = "Modifique los datos para  la plantilla de índice";
                    accesibilidadWindow = true;
                    descripcionpi = currentEntidad.descripcionpi;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidad.idtcpi);
                    eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                    break;
                case 3:
                    encabezadoPantalla = "Consulta de los datos para  la plantilla de índice";
                    descripcionpi = currentEntidad.descripcionpi;
                    accesibilidadWindow = false;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidad.idtcpi);
                    eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                    break;
                case 5:
                    encabezadoPantalla = "Copia de la plantilla de índice, debe cambiar el nombre para guardar";
                    descripcionpi = currentEntidad.descripcionpi;
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Visible;
                    selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidad.idtcpi);
                    eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                    activarDescripcionIndice = true;
                    break;
            }
            enviarMensajeInhabilitar();
            Messenger.Default.Unregister<PlantillaIndiceMensaje>(this, tokenRecepcion);
        }

        #endregion


       private async void ImportarPlantillas()
        {
            iniciarComando();

            int continuar = 0;
            if (listaPlantillas.Count > 0)
            {
                continuar = 0;
            }
            else
            {
                continuar = 1;//No hay registros
            }
            if (carpetaUnica() && continuar==0)
            {
                continuar = 1;
            }
            if (continuar == 0)
            {
                //Verificar que no exista nombre duplicado
                for (int k = 0; k < listaPlantillas.Count; k++)
                {
                    if (listaPlantillas[k].seleccionPlantilla)
                    {
                            //Importar
                            continuar = ImportarPlantillasByItem(TipoCarpetaModelo.equivalencia(currentEntidadCarpeta, listaPlantillas[k], currentEncargo), listaPlantillas[k]);
                            if (continuar == 0)
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La plantilla denominada " + listaPlantillas[k].descripcionpi + " fue importada con  éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                            }
                            else
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La plantilla denominada " + listaPlantillas[k].descripcionpi + " no pudo ser importada con  éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();

                            }
                    }
                    if (continuar != 0 && continuar > 0)
                    {
                        //Hubo error debe eliminarse el registro
                        if (IndiceModelo.DeleteByRangeForTC(currentEntidadCarpeta.id)==1)
                        {
                            //await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "No ha sido posible eliminar el registro auxiliares" + " debe corregirse manualmente", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                        }
                    }
                }
                //Termina el ciclo
                if (continuar == 0)
                {
                    if (listaPlantillas.Count(j => j.seleccionPlantilla) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Los registros se importaron con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();

                    }
                }
                else
                {
                    if (listaPlantillas.Count(j => j.seleccionPlantilla) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Algunos registros no se importaron ", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                    }
                }
                fuenteCierre = 1;
                resultadoProceso = 5;//5 para  importar de encargos;
                CloseWindow();
            }
            finComando();
        }

        //07-04-2017
        public int ImportarPlantillasByItem(TipoCarpetaModelo entidad, PlantillaIndiceModelo herramientaPlantilla)
        {
            int resultado = 0; //Valor por defecto
            try
            {
                //DetalleCuestionarioModelo temporal;
                index temporal;
                detalleplantillaindice padre;
                //Verificar que no exista nombre duplicado
                //Importar
                switch (TipoCarpetaModelo.Insert(entidad, currentEncargo))
                {
                    case 0://No se pudo  insertar el principal
                        resultado = 1;
                        break;
                    case 1://Caso normal se inserto el principal y el auxiliar, se procede  a insertar los dependientes
                        currentEntidadCarpetaDetalle.idencargo = currentEncargo.idencargo;//Aplica para todos
                        currentEntidadCarpetaDetalle.idtcindice = entidad.id;//Aplica para todos
                        ObservableCollection<detalleplantillaindice> listaDetalle = new ObservableCollection<detalleplantillaindice>(DetallePlantillaIndiceModelo.GetAllCapaDatos(herramientaPlantilla.idpi));
                        ObservableCollection<index> listaDestino = new ObservableCollection<index>();
                        temporal = null;
                        for (int p = 0; p < listaDetalle.Count; p++)
                        {
                            //Hacer la  equivalencia
                            temporal = IndiceModelo.IndiceConversion(currentEntidadCarpetaDetalle, listaDetalle[p]);
                            listaDestino.Add(temporal);
                        }
                        if (listaDestino.Count > 0)
                        {
                            //switch (DetalleCuestionarioModelo.InsertbyImportacionByRange(listaDestino, currentUsuario))
                            switch (IndiceModelo.InsertbyImportacionByRange(listaDestino, currentUsuario))
                            {
                                case 0:
                                    resultado = 2;//No pudo insertar un detalle
                                    break;
                                case 1://Se inserto sin problemas
                                    break;
                                case 2:
                                    resultado = 3;//Se dio una excepcion en el detalle
                                    break;
                                case 3:
                                    resultado = 4;
                                    break;
                            }
                        }
                        else
                        {
                            //Error
                            resultado = 4;
                        }
                        //Insertar las dependencias entre registros

                        if (resultado == 0)
                        {
                            //Obtener la lista insertada
                            foreach (detalleplantillaindice itemDetalle in listaDetalle)
                            {
                                if (itemDetalle.detiddpi != null)
                                {
                                    //Buscar el registro a actualizar
                                    temporal = listaDestino.Single(j => j.ordenindice == itemDetalle.ordendpi);//Elemento  buscado
                                    padre = listaDetalle.Single(j => j.iddpi == itemDetalle.detiddpi);//Busqueda del padre
                                    temporal.indidindice = listaDestino.Single(j => j.ordenindice == padre.ordendpi).idindice;
                                    if (IndiceModelo.UpdateModeloByImportacion(temporal))
                                    {
                                        //codigoError = 7;
                                    }
                                    else
                                    {
                                        resultado = 5;
                                    }
                                }
                            }

                        }
                        break;
                    case 2://No se inserto el registro auxiliar
                        resultado = 2;
                        break;
                }
                return resultado;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        private async void ImportarProgramasEncargos()
        {
            iniciarComando();
            int continuar = 0;
            if (listaCarpetaSeleccion.Count > 0)
            {
                continuar = 0;
            }
            else
            {
                continuar = 1;//No hay registros
            }
            if (carpetaUnicaFromEncargos() && continuar == 0)
            {
                continuar = 1;
            }
            if (continuar == 0)
            {
                //Verificar que no exista nombre duplicado
                for (int k = 0; k < listaCarpetaSeleccion.Count; k++)
                {
                    if (listaCarpetaSeleccion[k].seleccionEntidad)
                    {
                            //Importar
                            //ProgramaModelo tem = listaCarpetaSeleccion[k];
                            TipoCarpetaModelo temporal = new TipoCarpetaModelo(currentEncargo);
                            continuar = ImportarProgramasByItemForEncargos(TipoCarpetaModelo.equivalencia(temporal, listaCarpetaSeleccion[k]), listaCarpetaSeleccion[k]);
                            if (continuar == 0)
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se importo la carpeta " + listaCarpetaSeleccion[k].descripcion, "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                            }
                            else
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La carpeta denominada " + listaCarpetaSeleccion[k].descripcion + " no pudo ser importada con  éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                            }
                    }
                    if (continuar != 0 && continuar > 0)
                    {
                        //Hubo error debe eliminarse el registro
                        if (IndiceModelo.DeleteByRangeForTC(currentEntidadCarpeta.id) == 1)
                        {
                            //await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "No ha sido posible eliminar el registro auxiliares" + " debe corregirse manualmente", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                        }

                    }
                }
                //Termina el ciclo
                if (continuar == 0)
                {
                    if (listaCarpetaSeleccion.Count(j => j.seleccionEntidad) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Los registros se importaron con éxito ", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();

                    }
                }
                else
                {
                    if (listaCarpetaSeleccion.Count(j => j.seleccionEntidad) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Algunos registros no se importaron ", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                    }
                }
                fuenteCierre = 1;
                resultadoProceso = 4;//2 para  importar;
                CloseWindow();
            }
        }
        //07-04-2017
        public int ImportarProgramasByItemForEncargos(TipoCarpetaModelo entidad, TipoCarpetaModelo programaOrigen)
        {
            try
            {

                int resultado = 0; //Valor por defecto
                index temporal;
                index padre;
                //Verificar que no exista nombre duplicado
                //Importar
                entidad.idencargotc = currentEncargo.idencargo;

                switch (TipoCarpetaModelo.Insert(entidad, currentEncargo))
                {
                    case 0://No se pudo  insertar el principal
                        resultado = 1;
                        break;
                    case 1://Caso normal se inserto el principal y el auxiliar, se procede  a insertar los dependientes
                           //Conseguir el listado de detalles de la  herramienta
                        ObservableCollection<index> listaDetalle = new ObservableCollection<index>(IndiceModelo.GetAllCapaDatosByTipoCarpeta(programaOrigen.id));
                        ObservableCollection<index> listaDestino = new ObservableCollection<index>();
                        currentEntidadCarpetaDetalle.idencargo = entidad.idencargotc;//Aplica para todos
                        currentEntidadCarpetaDetalle.idtcindice = entidad.id;//Aplica para todos
                        temporal = null;
                        for (int p = 0; p < listaDetalle.Count; p++)
                        {
                            //Hacer la  equivalencia
                            temporal = IndiceModelo.IndiceConversion(currentEntidadCarpetaDetalle, listaDetalle[p]);
                            temporal.idencargo = entidad.idencargotc;//Aplica para todos
                            temporal.idtcindice = entidad.id;//Aplica para todos
                            listaDestino.Add(temporal);
                        }
                        if (listaDestino.Count > 0)
                        {
                            //switch (DetalleCuestionarioModelo.InsertbyImportacionByRange(listaDestino, currentUsuario))
                            switch (IndiceModelo.InsertbyImportacionByRange(listaDestino, currentUsuario))
                            {
                                case 0:
                                    resultado = 2;//No pudo insertar un detalle
                                    break;
                                case 1://Se inserto sin problemas
                                    break;
                                case 2:
                                    resultado = 3;//Se dio una excepcion en el detalle
                                    break;
                                case 3:
                                    resultado = 4;
                                    break;
                            }
                        }
                        else
                        {
                            //Error
                            resultado = 4;
                        }
                        //Insertar las dependencias entre registros

                        if (resultado == 0)
                        {
                            //Obtener la lista insertada
                            foreach (index itemDetalle in listaDetalle)
                            {
                                if (itemDetalle.indidindice != null)
                                {
                                    //Buscar el registro a actualizar
                                    temporal = listaDestino.Single(j => j.ordenindice == itemDetalle.ordenindice);//Elemento  buscado
                                    padre = listaDetalle.Single(j => j.idindice == itemDetalle.indidindice);//Busqueda del padre
                                    temporal.indidindice = listaDestino.Single(j => j.ordenindice == padre.ordenindice).idindice;
                                    if (IndiceModelo.UpdateModeloByImportacion(temporal))
                                    {
                                        //codigoError = 7;
                                    }
                                    else
                                    {
                                        resultado = 5;
                                    }
                                }
                            }
                        }
                        break;
                    case 2://No se inserto el registro auxiliar
                        resultado = 2;
                        //await dlg.ShowMessageAsync(this, "No ha sido posible importar la plantilla", "en  su registro auxiliar");
                        break;
                }
                return resultado;
            }
            catch (Exception)
            {
                return 0;
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
            if (origen ==null)
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
            if ((currentEntidad.tipoAuditoriaModelo != null))
            {
                if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                {
                    currentEntidad.tipoAuditoriaModelo = null;
                }
            }
            if (!(PlantillaIndiceModelo.FindTexto(currentEntidad.descripcionpi)))
            {
                if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 0)
                {
                    if (currentEntidad.Tipocarpeta != null)
                    {
                        currentEntidad.idtcpi = currentEntidad.Tipocarpeta.idtc;
                        if (PlantillaIndiceModelo.Insert(currentEntidad, currentUsuarioModelo))
                        {
                            await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                            listaEntidad.Add(currentEntidad);
                            cerradoFinalVentana = true;
                            CloseWindow();
                            enviarMensajeHabilitar();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Debe seleccionar el tipo de carpeta para el  índice,", "");
                    }

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El nombre ya esta siendo utilizado,", "seleccione otro nombre");
                }
                //Nuevo();
            }
            else
            {
                //Se reactiva el registro
                if ((PlantillaIndiceModelo.FindTextoReturnIdBorrados(currentEntidad.descripcionpi) == 1))
                {
                    if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 0)
                    {
                        if (PlantillaIndiceModelo.UpdateBorradoModelo(currentEntidad, true))
                        {
                            await dlg.ShowMessageAsync(this, "Registro creado con éxito", "");
                            CloseWindow();
                            cerradoFinalVentana = true;
                            enviarMensajeHabilitar();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible crear el registro", "");
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "El nombre ya tiene ha sido utilizado,", "seleccione otro nombre");
                    }
                }
            }
        }

        public async void GuardarD()
        {
            {
                //Debe coindicir el inicio con el elemento contable seleccionado
                iniciarComando();
                try
                {
                    switch (TipoCarpetaModelo.Insert(currentEntidadCarpeta, currentEncargo))
                    {
                        case 0://No se pudo insertar
                            finComando();
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            break;
                        case 1://Se inserto con éxito
                            var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
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
        }

        public async void Modificar()
        {
            if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 1)
            {
                if ((currentEntidad.tipoAuditoriaModelo != null))
                {
                    if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                    {
                        currentEntidad.tipoAuditoriaModelo = null;
                    }
                }
                if (!string.IsNullOrEmpty(currentEntidad.descripcionpi))
                {

                    if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 1)
                    {
                        if (currentEntidad.Tipocarpeta != null)
                        {
                            currentEntidad.idtcpi = currentEntidad.Tipocarpeta.idtc;
                            if (PlantillaIndiceModelo.UpdateModelo(currentEntidad))
                            {
                                await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                                CloseWindow();
                                cerradoFinalVentana = true;
                                enviarMensajeHabilitar();
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                            }
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "Debe seleccionar el tipo de carpeta para el  índice,", "");
                        }
                    }
                    else
                    {
                        //Mensaje en caso de indice mayor
                        await dlg.ShowMessageAsync(this, "La descripcion es la misma que la de otro  registro", "");
                    }

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
                }
                //Nuevo();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa nombre", "");
            }
        }


        public async void Copiar()
        {
            iniciarComando();
            if ((currentEntidad.tipoAuditoriaModelo != null))
            {
                if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                {
                    currentEntidad.tipoAuditoriaModelo = null;
                }
            }
            if (!string.IsNullOrEmpty(currentEntidad.descripcionpi))
            {

                if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 0)
                {
                    if (PlantillaIndiceModelo.CopiarModelo(currentEntidad))
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
            //Nuevo();
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
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripcionpi) &&
                           (currentEntidad.descripcionpi.Length <= maxDescripcion) &&
                           Errors == 0;
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
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);

            SelectionCarpetaCommand = new RelayCommand<tipocarpeta>(entidad =>
            {
                if (entidad == null) return;
                eleccionTipoCarpeta = entidad;
                if (entidad.idtc != 0)
                {
                    currentEntidad.idtcpi = entidad.idtc;
                    currentEntidad.Tipocarpeta = eleccionTipoCarpeta;
                    activarDescripcionIndice = true;
                }
                //else
                //{
                //    currentEntidad.idtcpi = entidad.idtc;
                //    currentEntidad.Tipocarpeta = eleccionTipoCarpeta;
                //}
            });
        }

        private void RegisterCommandsDocumentacion()
        {
            CopiarCommand = new RelayCommand(CopiarD, CanSaveDocumentacion);
            EditarCommand = new RelayCommand(ModificarD, CanSaveDocumentacion);
            GuardarCommand = new RelayCommand(GuardarD, CanSaveDocumentacion);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);

            SelectionCarpetaCommand = new RelayCommand<tipocarpeta>(entidad =>
            {
                if (entidad == null) return;
                eleccionTipoCarpeta = entidad;
                if (entidad.idtc != 0)
                {
                    currentEntidadCarpeta.padreidtc = entidad.idtc;
                    currentEntidadCarpeta.descripcion = entidad.descripciontc;
                    currentEntidad.descripcionpi = "Para eliminar error";
                }
                //else
                //{
                //    currentEntidadCarpeta.padreidtc = 0;
                //    currentEntidadCarpeta.descripcion = "";
                //    currentEntidad.descripcionpi = string.Empty;
                //}
            });

            CancelarPlantillaCommand = new RelayCommand(Cancelar);
            SeleccionPlantillaCommand = new RelayCommand(ImportarPlantillas, canImport);
            CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
            SeleccionProgramaEncargoCommand = new RelayCommand(ImportarProgramasEncargos, canImportForEncargos);

            SelectionPlantillaChangedCommand = new RelayCommand<PlantillaIndiceModelo>(entidad =>
            {
                foreach(tipocarpeta temporal in  listaTipoCarpeta)
                { 
                //Verificar si no hay otra carpeta seleccionada
                if (listaPlantillas.Where(x => x.seleccionPlantilla && x.idtcpi == temporal.idtc).Count()> 1)
                    {
                        advertenciaSeleccion();
                        listaPlantillas.LastOrDefault(x => x.seleccionPlantilla && x.idtcpi == temporal.idtc).seleccionPlantilla = false;
                    }
                }
            });

            SelectionCarpetaChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                foreach (tipocarpeta temporal in listaTipoCarpeta)
                {
                    //Verificar si no hay otra carpeta seleccionada
                    if (listaCarpetaSeleccion.Where(x => x.seleccionEntidad && x.padreidtc == temporal.idtc).Count() > 1)
                    {
                        advertenciaSeleccion();
                        listaCarpetaSeleccion.LastOrDefault(x => x.seleccionEntidad && x.padreidtc == temporal.idtc).seleccionEntidad = false;
                    }
                }
            });
            SelectedDateChangedCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechacierre != null)
                    {
                        currentEntidadCarpeta.fechacierre = MetodosModelo.homologacionFecha(fechacierre.ToShortDateString());
                        currentEntidadCarpeta.usuariocerro = currentUsuario.inicialesusuario;
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
                        currentEntidadCarpeta.fechasupervision = MetodosModelo.homologacionFecha(fechasupervision.ToShortDateString());
                        currentEntidadCarpeta.usuariosuperviso = currentUsuario.inicialesusuario;
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
                        currentEntidadCarpeta.fechaaprobacion = MetodosModelo.homologacionFecha(fechaaprobacion.ToShortDateString());
                        currentEntidadCarpeta.usuarioaprobo = currentUsuario.inicialesusuario;
                    }
                }
            });

            referenciarCommand = new RelayCommand(ModificarC, CanReferenciarSave);//Para guardar la referencia

            supervisarCommand = new RelayCommand(ModificarC, CanSupervisar);//Para guardar la referencia

            aprobarCommand = new RelayCommand(ModificarC, CanAprobar);//Para guardar la referencia

            cerrarCommand = new RelayCommand(ModificarC, CanCerrar);//Para guardar la referencia
        }

        private bool CanModificar()
        {
            bool evaluar = false;

            if (currentEntidadCarpeta == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0)
                && (!string.IsNullOrWhiteSpace(currentEntidadCarpeta.fechacierre));
                return evaluar;
            }
        }

        private bool CanCerrar()
        {
            bool evaluar = false;

            if (currentEntidadCarpeta == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidadCarpeta.usuariocerro))
                        && (!string.IsNullOrWhiteSpace(currentEntidadCarpeta.usuariocerro));
            }
        }


        private bool CanAprobar()
        {
            bool evaluar = false;

            if (currentEntidadCarpeta == null)
            {
                return evaluar;
            }
            else
            {
                return ((!string.IsNullOrEmpty(currentEntidadCarpeta.usuarioaprobo))
                    || (string.IsNullOrEmpty(currentEntidadCarpeta.usuarioaprobo)));
            }
        }

        private bool CanSupervisar()
        {
            bool evaluar = false;

            if (currentEntidadCarpeta == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidadCarpeta.usuariosuperviso))
                        && (!string.IsNullOrWhiteSpace(currentEntidadCarpeta.usuariosuperviso));
            }
        }


        private bool CanReferenciarSave()
        {
            bool evaluar = false;

            if (currentEntidadCarpeta == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0) ;
                return evaluar;
            }
        }

        private async void ModificarC()
        {
            iniciarComando();
            try
            {
                int resultadoModificar = -10;
                //currentEntidadCarpeta.referenciamr = referenciamr;
                switch (opcionMenu)
                {
                    case 2: //Editar solo actualiza la fecha de evaluación
                        //resultadoModificar = TipoCarpetaModelo.UpdateModificacion(currentEntidadCarpeta, currentUsuario);
                        break;
                    case 8: //Referenciar
                        //resultadoModificar = TipoCarpetaModelo.UpdateReferencia(currentEntidadCarpeta);
                        break;
                    case 10:
                        resultadoModificar = TipoCarpetaModelo.UpdateCierre(currentEntidadCarpeta, currentUsuario);
                        break;
                    case 11://Supervisar
                        resultadoModificar = TipoCarpetaModelo.UpdateSupervision(currentEntidadCarpeta);
                        break;
                    case 12://Aprobar
                        if (string.IsNullOrEmpty(currentEntidadCarpeta.usuariosuperviso) || string.IsNullOrWhiteSpace(currentEntidadCarpeta.usuariosuperviso))
                        {
                            resultadoModificar = TipoCarpetaModelo.UpdateAprobacionSupervision(currentEntidadCarpeta);
                            currentEntidadCarpeta.usuariosuperviso = currentEntidadCarpeta.usuarioaprobo;
                            currentEntidadCarpeta.fechasupervision = currentEntidadCarpeta.fechaaprobacion;
                        }
                        else
                        {
                            resultadoModificar = TipoCarpetaModelo.UpdateAprobacion(currentEntidadCarpeta);
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

        public bool carpetaUnica()
        {
            bool resultado = false;
            foreach (tipocarpeta temporal in listaTipoCarpeta)
            {
                //Verificar si no hay otra carpeta seleccionada
                if (listaPlantillas.Where(x => x.seleccionPlantilla && x.idtcpi == temporal.idtc).Count() > 1)
                {
                    advertenciaSeleccion();
                    listaPlantillas.LastOrDefault(x => x.seleccionPlantilla && x.idtcpi == temporal.idtc).seleccionPlantilla = false;
                    resultado = true;
                }
            }
            return resultado;
        }
        public bool carpetaUnicaFromEncargos()
        {
            bool resultado = false;
            foreach (tipocarpeta temporal in listaTipoCarpeta)
            {
                //Verificar si no hay otra carpeta seleccionada
                if (listaCarpetaSeleccion.Where(x => x.seleccionEntidad && x.padreidtc == temporal.idtc).Count() > 1)
                {
                    advertenciaSeleccion();
                    listaCarpetaSeleccion.LastOrDefault(x => x.seleccionEntidad && x.padreidtc == temporal.idtc).seleccionEntidad = false;
                    resultado = true;
                }
            }
            return resultado;
        }
        private bool canImportForEncargos()
        {
            return (listaCarpetaSeleccion.Count(j => j.seleccionEntidad) > 0);
        }

        private bool canImport()
        {
            //bool evaluar = false;
            return (listaPlantillas.Count(j => j.seleccionPlantilla) > 0);
        }



        private void CopiarD()
        {
            throw new NotImplementedException();
        }

        private void ModificarD()
        {
            throw new NotImplementedException();
        }



        #region Verifica unicidad
        //Cada marca debe ser única
        public int nombreUnico(string nombre, ObservableCollection<PlantillaIndiceModelo> listaBusqueda)
        {
            int numeroRegistros;
            string fechacreadopi = nombre.ToUpper().Trim();
            numeroRegistros = listaBusqueda.Where(j => j.descripcionpi.ToUpper().Trim() == fechacreadopi).Count();
            if (numeroRegistros == 1)
            {
                return 1;
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
    }

}
