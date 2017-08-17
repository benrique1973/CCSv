using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using SGPTWpf.Messages.Herramientas;
using System.Windows;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Messages.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using CapaDatos;
using System.Linq;
using System.ComponentModel;
using SGPTWpf.Model.Modelo.Encargos;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa

{

    public sealed class DetalleProgramaViewModel : ViewModeloBase
    {
        #region Propiedades privadas


        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region opcionMenuCrud

        private int _opcionMenuCrud;
        private int opcionMenuCrud
        {
            get { return _opcionMenuCrud; }
            set { _opcionMenuCrud = value; }
        }

        #endregion

        #region opcionMenuPrincipal

        private int _opcionMenuPrincipal;
        private int opcionMenuPrincipal
        {
            get { return _opcionMenuPrincipal; }
            set { _opcionMenuPrincipal = value; }
        }

        #endregion

        #region comando

        private static int _comando;
        private static int comando
        {
            get { return _comando; }
            set { _comando = value; }
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

        #region edicionHabilitada

        private bool _edicionHabilitada;
        private bool edicionHabilitada
        {
            get { return _edicionHabilitada; }
            set { _edicionHabilitada = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        #region tokenEnvioDatosAMenu

        private string _tokenEnvioDatosAMenu;
        private string tokenEnvioDatosAMenu
        {
            get { return _tokenEnvioDatosAMenu; }
            set { _tokenEnvioDatosAMenu = value; }
        }

        #endregion

        #region tokenEnvioProgramas

        private string _tokenEnvioProgramas;
        private string tokenEnvioProgramas
        {
            get { return _tokenEnvioProgramas; }
            set { _tokenEnvioProgramas = value; }
        }

        #endregion

        #region tokenHabilitarVentanaPadre

        private string _tokenHabilitarVentanaPadre;
        private string tokenHabilitarVentanaPadre
        {
            get { return _tokenHabilitarVentanaPadre; }
            set { _tokenHabilitarVentanaPadre = value; }
        }

        #endregion


        #region tokenRecepcionCierre

        private string _tokenRecepcionCierre;
        private string tokenRecepcionCierre
        {
            get { return _tokenRecepcionCierre; }
            set { _tokenRecepcionCierre = value; }
        }
        #endregion

        #region tokenEnvioVista

        private string _tokenEnvioVista;
        private string tokenEnvioVista
        {
            get { return _tokenEnvioVista; }
            set { _tokenEnvioVista = value; }
        }
        #endregion

        #region tokenEnvioDetallePrograma

        private string _tokenEnvioDetallePrograma;
        private string tokenEnvioDetallePrograma
        {
            get { return _tokenEnvioDetallePrograma; }
            set { _tokenEnvioDetallePrograma = value; }
        }
        #endregion

        #region tokenRecepcionDatosPadre

        private string _tokenRecepcionDatosPadre;
        private string tokenRecepcionDatosPadre
        {
            get { return _tokenRecepcionDatosPadre; }
            set { _tokenRecepcionDatosPadre = value; }
        }
        #endregion

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }

        #endregion

        #region tokenRecepcionPadrePrincipal

        private string _tokenRecepcionPadrePrincipal;
        private string tokenRecepcionPadrePrincipal
        {
            get { return _tokenRecepcionPadrePrincipal; }
            set { _tokenRecepcionPadrePrincipal = value; }
        }

        #endregion

        #endregion

        #region Importadas de VistaPrevia

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

        #region visibilidadFElaboracion

        public const string visibilidadFElaboracionPropertyName = "visibilidadFElaboracion";

        private Visibility _visibilidadFElaboracion = Visibility.Collapsed;

        public Visibility visibilidadFElaboracion
        {
            get
            {
                return _visibilidadFElaboracion;
            }

            set
            {
                if (_visibilidadFElaboracion == value)
                {
                    return;
                }

                _visibilidadFElaboracion = value;
                RaisePropertyChanged(visibilidadFElaboracionPropertyName);
            }
        }

        #endregion

        #region visibilidadFSupervision

        public const string visibilidadFSupervisionPropertyName = "visibilidadFSupervision";

        private Visibility _visibilidadFSupervision = Visibility.Collapsed;

        public Visibility visibilidadFSupervision
        {
            get
            {
                return _visibilidadFSupervision;
            }

            set
            {
                if (_visibilidadFSupervision == value)
                {
                    return;
                }

                _visibilidadFSupervision = value;
                RaisePropertyChanged(visibilidadFSupervisionPropertyName);
            }
        }

        #endregion

        #region visibilidadFAprobacion

        public const string visibilidadFAprobacionPropertyName = "visibilidadFAprobacion";

        private Visibility _visibilidadFAprobacion = Visibility.Collapsed;

        public Visibility visibilidadFAprobacion
        {
            get
            {
                return _visibilidadFAprobacion;
            }

            set
            {
                if (_visibilidadFAprobacion == value)
                {
                    return;
                }

                _visibilidadFAprobacion = value;
                RaisePropertyChanged(visibilidadFAprobacionPropertyName);
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

        #region ViewModel Property : currentEntidadDetalle Herramienta Modelo

        public const string currentEntidadDetallePropertyName = "currentEntidadDetalle";

        private DetalleProgramaModelo _currentEntidadDetalle;

        public DetalleProgramaModelo currentEntidadDetalle
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

        #region

        #region visibilidadMEditarHide

        public const string visibilidadMEditarHidePropertyName = "visibilidadMEditarHide";

        private Visibility _visibilidadMEditarHide = Visibility.Collapsed;

        public Visibility visibilidadMEditarHide
        {
            get
            {
                return _visibilidadMEditarHide;
            }

            set
            {
                if (_visibilidadMEditarHide == value)
                {
                    return;
                }

                _visibilidadMEditarHide = value;
                RaisePropertyChanged(visibilidadMEditarHidePropertyName);
            }
        }

        #endregion

        #region visibilidadMOHide

        public const string visibilidadMOHidePropertyName = "visibilidadMOHide";

        private Visibility _visibilidadMOHide = Visibility.Collapsed;

        public Visibility visibilidadMOHide
        {
            get
            {
                return _visibilidadMOHide;
            }

            set
            {
                if (_visibilidadMOHide == value)
                {
                    return;
                }

                _visibilidadMOHide = value;
                RaisePropertyChanged(visibilidadMOHidePropertyName);
            }
        }

        #endregion

        #region visibilidadMOShow

        public const string visibilidadMOShowPropertyName = "visibilidadMOShow";

        private Visibility _visibilidadMOShow = Visibility.Collapsed;

        public Visibility visibilidadMOShow
        {
            get
            {
                return _visibilidadMOShow;
            }

            set
            {
                if (_visibilidadMOShow == value)
                {
                    return;
                }

                _visibilidadMOShow = value;
                RaisePropertyChanged(visibilidadMOShowPropertyName);
            }
        }

        #endregion

        #region visibilidadMAHide

        public const string visibilidadMAHidePropertyName = "visibilidadMAHide";

        private Visibility _visibilidadMAHide = Visibility.Collapsed;

        public Visibility visibilidadMAHide
        {
            get
            {
                return _visibilidadMAHide;
            }

            set
            {
                if (_visibilidadMAHide == value)
                {
                    return;
                }

                _visibilidadMAHide = value;
                RaisePropertyChanged(visibilidadMAHidePropertyName);
            }
        }

        #endregion

        #region visibilidadMAShow

        public const string visibilidadMAShowPropertyName = "visibilidadMAShow";

        private Visibility _visibilidadMAShow = Visibility.Collapsed;

        public Visibility visibilidadMAShow
        {
            get
            {
                return _visibilidadMAShow;
            }

            set
            {
                if (_visibilidadMAShow == value)
                {
                    return;
                }

                _visibilidadMAShow = value;
                RaisePropertyChanged(visibilidadMAShowPropertyName);
            }
        }

        #endregion


        #endregion

        #region Lista de entidades


        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<DetalleProgramaModelo> _listaDetalleHerramienta;

        public ObservableCollection<DetalleProgramaModelo> listaDetalleHerramienta
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

        #region ViewModel Properties : listaDetalleCapaDatos

        public const string listaDetalleCapaDatosPropertyName = "listaDetalleCapaDatos";

        private ObservableCollection<detalleprograma> _listaDetalleCapaDatos;

        public ObservableCollection<detalleprograma> listaDetalleCapaDatos
        {
            get
            {
                return _listaDetalleCapaDatos;
            }
            set
            {
                if (_listaDetalleCapaDatos == value) return;

                _listaDetalleCapaDatos = value;
                RaisePropertyChanged(listaDetalleCapaDatosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaObjetivos

        public const string listaObjetivosPropertyName = "listaObjetivos";

        private ObservableCollection<DetalleProgramaModelo> _listaObjetivos;

        public ObservableCollection<DetalleProgramaModelo> listaObjetivos
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

        private ObservableCollection<DetalleProgramaModelo> _listaAlcances;

        public ObservableCollection<DetalleProgramaModelo> listaAlcances
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

        private ObservableCollection<DetalleProgramaModelo> _listaDetalleProcedimientos;

        public ObservableCollection<DetalleProgramaModelo> listaDetalleProcedimientos
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

        #region ViewModel Properties : listarespuestacuestionario

        public const string listarespuestacuestionarioPropertyName = "listarespuestacuestionario";

        private ObservableCollection<string> _listarespuestacuestionario;

        public ObservableCollection<string> listarespuestacuestionario
        {
            get
            {
                return _listarespuestacuestionario;
            }
            set
            {
                if (_listarespuestacuestionario == value) return;

                _listarespuestacuestionario = value;
                RaisePropertyChanged(listarespuestacuestionarioPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listatiporespuestacuestionario

        public const string listatiporespuestacuestionarioPropertyName = "listatiporespuestacuestionario";

        private ObservableCollection<tiporespuestacuestionario> _listatiporespuestacuestionario;

        public ObservableCollection<tiporespuestacuestionario> listatiporespuestacuestionario
        {
            get
            {
                return _listatiporespuestacuestionario;
            }
            set
            {
                if (_listatiporespuestacuestionario == value) return;

                _listatiporespuestacuestionario = value;
                RaisePropertyChanged(listatiporespuestacuestionarioPropertyName);
            }
        }


        #endregion


        #endregion Lista de entidades

        #region Programa Modelo

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


        #region referenciaPrograma

        public const string referenciaProgramaPropertyName = "referenciaPrograma";

        private string _referenciaPrograma = string.Empty;

        public string referenciaPrograma
        {
            get
            {
                return _referenciaPrograma;
            }

            set
            {
                if (_referenciaPrograma == value)
                {
                    return;
                }

                _referenciaPrograma = value;
                RaisePropertyChanged(referenciaProgramaPropertyName);
            }
        }

        #endregion

        #region descripcionEtapaEncargo

        public const string descripcionEtapaEncargoPropertyName = "descripcionEtapaEncargo";

        private string _descripcionEtapaEncargo = string.Empty;

        public string descripcionEtapaEncargo
        {
            get
            {
                return _descripcionEtapaEncargo;
            }

            set
            {
                if (_descripcionEtapaEncargo == value)
                {
                    return;
                }

                _descripcionEtapaEncargo = value;
                RaisePropertyChanged(descripcionEtapaEncargoPropertyName);
            }
        }

        #endregion

        #region indiceEjecucionprograma

        public const string indiceEjecucionprogramaPropertyName = "indiceEjecucionprograma";

        private string _indiceEjecucionprograma = string.Empty;

        public string indiceEjecucionprograma
        {
            get
            {
                return _indiceEjecucionprograma;
            }

            set
            {
                if (_indiceEjecucionprograma == value)
                {
                    return;
                }

                _indiceEjecucionprograma = value;
                RaisePropertyChanged(indiceEjecucionprogramaPropertyName);
            }
        }

        #endregion

        #region totalProcedimientos

        public const string totalProcedimientosPropertyName = "totalProcedimientos";

        private string _totalProcedimientos = string.Empty;

        public string totalProcedimientos
        {
            get
            {
                return _totalProcedimientos;
            }

            set
            {
                if (_totalProcedimientos == value)
                {
                    return;
                }

                _totalProcedimientos = value;
                RaisePropertyChanged(totalProcedimientosPropertyName);
            }
        }

        #endregion

        #region IsEditable

        public const string IsEditablePropertyName = "IsEditable";

        private bool _IsEditable = false;

        public bool IsEditable
        {
            get
            {
                return _IsEditable;
            }

            set
            {
                if (_IsEditable == value)
                {
                    return;
                }

                _IsEditable = value;
                RaisePropertyChanged(IsEditablePropertyName);
            }
        }

        #endregion

        #endregion

        #region Detalle Programa

        #region respuestaProgramaDp

        public const string respuestaProgramaDpPropertyName = "respuestaProgramaDp";

        private string _respuestaProgramaDp = string.Empty;

        public string respuestaProgramaDp
        {
            get
            {
                return _respuestaProgramaDp;
            }

            set
            {
                if (_respuestaProgramaDp == value)
                {
                    return;
                }

                _respuestaProgramaDp = value;
                RaisePropertyChanged(respuestaProgramaDpPropertyName);
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

        #region fechainidp

        public const string fechainidpPropertyName = "fechainidp";

        private string _fechainidp;

        public string fechainidp
        {
            get
            {
                return _fechainidp;
            }

            set
            {
                if (_fechainidp == value)
                {
                    return;
                }

                _fechainidp = value;
                RaisePropertyChanged(fechainidpPropertyName);
            }
        }

        #endregion

        #region fechafindp

        public const string fechafindpPropertyName = "fechafindp";

        private string _fechafindp;

        public string fechafindp
        {
            get
            {
                return _fechafindp;
            }

            set
            {
                if (_fechafindp == value)
                {
                    return;
                }

                _fechafindp = value;
                RaisePropertyChanged(fechafindpPropertyName);
            }
        }

        #endregion

        #region fechasupervision

        public const string fechasupervisionPropertyName = "fechasupervision";

        private string _fechasupervision;

        public string fechasupervision
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

        #region fechainidpDate

        public const string fechainidpDatePropertyName = "fechainidpDate";

        private DateTime? _fechainidpDate;

        public DateTime? fechainidpDate
        {
            get
            {
                return _fechainidpDate;
            }

            set
            {
                if (_fechainidpDate == value)
                {
                    return;
                }

                _fechainidpDate = value;
                RaisePropertyChanged(fechainidpDatePropertyName);
            }
        }

        #endregion

        #region fechafindpDate

        public const string fechafindpDatePropertyName = "fechafindpDate";

        private DateTime? _fechafindpDate;

        public DateTime? fechafindpDate
        {
            get
            {
                return _fechafindpDate;
            }

            set
            {
                if (_fechafindpDate == value)
                {
                    return;
                }

                _fechafindpDate = value;
                RaisePropertyChanged(fechafindpDatePropertyName);
            }
        }

        #endregion

        #region fechasupervisionDate

        public const string fechasupervisionDatePropertyName = "fechasupervisionDate";

        private DateTime? _fechasupervisionDate;

        public DateTime? fechasupervisionDate
        {
            get
            {
                return _fechasupervisionDate;
            }

            set
            {
                if (_fechasupervisionDate == value)
                {
                    return;
                }

                _fechasupervisionDate = value;
                RaisePropertyChanged(fechasupervisionDatePropertyName);
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

        #region ViewModel Properties publicas

        #region visibilidadTipoPrograma

        public const string visibilidadTipoProgramaPropertyName = "visibilidadTipoPrograma";

        private Visibility _visibilidadTipoPrograma = Visibility.Hidden;

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



        #region ViewModel Properties : listaDetallePrograma

        public const string listaDetalleProgramaPropertyName = "listaDetallePrograma";

        private ObservableCollection<DetalleProgramaModelo> _listaDetallePrograma;

        public ObservableCollection<DetalleProgramaModelo> listaDetallePrograma
        {
            get
            {
                return _listaDetallePrograma;
            }

            set
            {
                if (_listaDetallePrograma == value) return;

                _listaDetallePrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDetalleProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaHistoricaDetallePrograma

        public const string listaHistoricaDetalleProgramaPropertyName = "listaHistoricaDetallePrograma";

        private ObservableCollection<DetalleProgramaModelo> _listaHistoricaDetallePrograma;

        public ObservableCollection<DetalleProgramaModelo> listaHistoricaDetallePrograma
        {
            get
            {
                return _listaHistoricaDetallePrograma;
            }

            set
            {
                if (_listaHistoricaDetallePrograma == value) return;

                _listaHistoricaDetallePrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaHistoricaDetalleProgramaPropertyName);
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
        public RelayCommand DobleClickCommand { get; set; }
        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<DetalleProgramaModelo> SelectionChangedCommand { get; set; }
        public RelayCommand<DetalleProgramaModelo> SelectionDetalleChangedCommand { get; set; }
        public RelayCommand irMenuPadreCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand guardarDetalleCommand { get; set; }
        public RelayCommand<tiporespuestacuestionario> cambioRespuestaCommand { get; set; }
        public RelayCommand completarCommand { get; set; }
        public RelayCommand hideObjetivosCommand { get; set; }
        public RelayCommand showObjetivosCommand { get; set; }
        public RelayCommand hideAlcanceCommand { get; set; }
        public RelayCommand showAlcanceCommand { get; set; }

        public RelayCommand terminarPapelCommand { get; set; } //Cierra el  procedimiento
        

        #endregion

        #region EncargoPlanProgramaDetalleMain

        private MainModel _mainModel = null;

        public MainModel EncargoPlanProgramaDetalleMain
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

        #region nombreTipoProcedimiento

        public const string nombreTipoProcedimientoPropertyName = "nombreTipoProcedimiento";

        private string _nombreTipoProcedimiento = string.Empty;

        public string nombreTipoProcedimiento
        {
            get
            {
                return _nombreTipoProcedimiento;
            }

            set
            {
                if (_nombreTipoProcedimiento == value)
                {
                    return;
                }

                _nombreTipoProcedimiento = value;
                RaisePropertyChanged(nombreTipoProcedimientoPropertyName);
            }
        }

        #endregion

        #region listaDetallePrograma de entidades

        #region ViewModel Properties : listaProgramasModelo

        public const string listaEntidadPropertyName = "listaProgramasModelo";

        private ObservableCollection<ProgramaModelo> _listaProgramasModelo;

        public ObservableCollection<ProgramaModelo> listaProgramasModelo
        {
            get
            {
                return _listaProgramasModelo;
            }
            set
            {
                if (_listaProgramasModelo == value) return;

                _listaProgramasModelo = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaTipoProcedimiento

        public const string listaTipoProcedimientoPropertyName = "listaTipoProcedimiento";

        private ObservableCollection<TipoProcedimientoModelo> _listaTipoProcedimiento;

        public ObservableCollection<TipoProcedimientoModelo> listaTipoProcedimiento
        {
            get
            {
                return _listaTipoProcedimiento;
            }
            set
            {
                if (_listaTipoProcedimiento == value) return;

                _listaTipoProcedimiento = value;

                RaisePropertyChanged(listaTipoProcedimientoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaTipoPrograma

        public const string listaTipoProgramaPropertyName = "listaTipoPrograma";

        private ObservableCollection<TipoProgramaModelo> _listaTipoPrograma;

        public ObservableCollection<TipoProgramaModelo> listaTipoPrograma
        {
            get
            {
                return _listaTipoPrograma;
            }
            set
            {
                if (_listaTipoPrograma == value) return;

                _listaTipoPrograma = value;

                RaisePropertyChanged(listaTipoProgramaPropertyName);
            }
        }

        #endregion

      /*  #region ViewModel Properties : listaTipoRespuestaPrograma

        public const string listaTipoRespuestaProgramaPropertyName = "listaTipoRespuestaPrograma";

        private ObservableCollection<TipoRespuestaProgramaModelo> _listaTipoRespuestaPrograma;

        public ObservableCollection<TipoRespuestaProgramaModelo> listaTipoRespuestaPrograma
        {
            get
            {
                return _listaTipoRespuestaPrograma;
            }
            set
            {
                if (_listaTipoRespuestaPrograma == value) return;

                _listaTipoRespuestaPrograma = value;

                RaisePropertyChanged(listaTipoRespuestaProgramaPropertyName);
            }
        }

        #endregion*/

        #region ViewModel Properties : listaUsuarioProgramaAccionModelo

        public const string listaUsuarioProgramaAccionModeloPropertyName = "listaUsuarioProgramaAccionModelo";

        private ObservableCollection<UsuarioProgramaAccionModelo> _listaUsuarioProgramaAccionModelo;

        public ObservableCollection<UsuarioProgramaAccionModelo> listaUsuarioProgramaAccionModelo
        {
            get
            {
                return _listaUsuarioProgramaAccionModelo;
            }
            set
            {
                if (_listaUsuarioProgramaAccionModelo == value) return;

                _listaUsuarioProgramaAccionModelo = value;

                RaisePropertyChanged(listaUsuarioProgramaAccionModeloPropertyName);
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


        #endregion listaDetallePrograma de entidades

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

        #endregion

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

        #region Propiedades : descripciontrctrc


        public const string descripciontrcPropertyName = "descripciontrctrc";

        private string _descripciontrc = string.Empty;

        public string descripciontrctrc
        {
            get
            {
                return _descripciontrc;
            }
            set
            {
                if (_descripciontrc == value)
                {
                    return;
                }
                _descripciontrc = value;
                RaisePropertyChanged(descripciontrcPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Property : currentDetallePrograma DetalleProgramaModelo

        public const string currentDetalleProgramaPropertyName = "currentDetallePrograma";

        private DetalleProgramaModelo _currentDetallePrograma;

        public DetalleProgramaModelo currentDetallePrograma
        {
            get
            {
                return _currentDetallePrograma;
            }

            set
            {
                if (_currentDetallePrograma == value) return;

                _currentDetallePrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentDetalleProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : registroGuardarDetallePrograma DetalleProgramaModelo

        public const string registroGuardarDetalleProgramaPropertyName = "registroGuardarDetallePrograma";

        private DetalleProgramaModelo _registroGuardarDetallePrograma;

        public DetalleProgramaModelo registroGuardarDetallePrograma
        {
            get
            {
                return _registroGuardarDetallePrograma;
            }

            set
            {
                if (_registroGuardarDetallePrograma == value) return;

                _registroGuardarDetallePrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(registroGuardarDetalleProgramaPropertyName);
            }
        }

        #endregion

        #region Propiedades Programa Modelo

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

        #region usuarioModifico

        public const string usuarioModificoPropertyName = "usuarioModifico";

        private string _usuarioModifico = string.Empty;

        public string usuarioModifico
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

        #region horasplanprograma

        public const string horasplanprogramaPropertyName = "horasplanprograma";

        private decimal _horasplanprograma = 0;

        public decimal horasplanprograma
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

        #region ViewModel Property : ProgramaModelo

        public const string currentProgramaPropertyName = "currentPrograma";

        private ProgramaModelo _currentPrograma;

        public ProgramaModelo currentPrograma
        {
            get
            {
                return _currentPrograma;
            }

            set
            {
                if (_currentPrograma == value) return;

                _currentPrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentProgramaPropertyName);
            }
        }

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

        #region ordendp

        public const string ordendpPropertyName = "ordendp";

        private decimal? _ordendp = 0;

        public decimal? ordendp
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

        #region horaplandp

        public const string horaplandpPropertyName = "horaplandp";

        private decimal _horaplandp = 0;

        public decimal horaplandp
        {
            get
            {
                return _horaplandp;
            }

            set
            {
                if (_horaplandp == value)
                {
                    return;
                }

                _horaplandp = value;
                RaisePropertyChanged(horaplandpPropertyName);
            }
        }

        #endregion

        #region idpadredp

        public const string idpadredpPropertyName = "idpadredp";

        private int _idpadredp = 0;

        public int idpadredp
        {
            get
            {
                return _idpadredp;
            }

            set
            {
                if (_idpadredp == value)
                {
                    return;
                }

                _idpadredp = value;
                RaisePropertyChanged(idpadredpPropertyName);
                //Seleccion de valor
                currentDetallePrograma.idpadredp = _idpadredp;
            }
        }

        #endregion

        #region idvisitadp

        public const string idvisitadpPropertyName = "idvisitadp";

        private int _idvisitadp = 0;

        public int idvisitadp
        {
            get
            {
                return _idvisitadp;
            }

            set
            {
                if (_idvisitadp == value)
                {
                    return;
                }

                _idvisitadp = value;
                RaisePropertyChanged(idvisitadpPropertyName);
            }
        }

        #endregion

        #endregion


        #region ViewModel Property : SelectedTipoProgramaModelo

        public const string SelectedTipoProgramaModeloPropertyName = "SelectedTipoProgramaModelo";

        private TipoProgramaModelo _SelectedTipoProgramaModelo;

        public TipoProgramaModelo SelectedTipoProgramaModelo
        {
            get
            {
                return _SelectedTipoProgramaModelo;
            }

            set
            {
                if (_SelectedTipoProgramaModelo == value) return;

                _SelectedTipoProgramaModelo = value;
                RaisePropertyChanged(SelectedTipoProgramaModeloPropertyName);
                //Asignación del tipo de programa
                //currentDetallePrograma.idtpprograma = _SelectedTipoProgramaModelo.id;
            }
        }

        #endregion

        #region ViewModel Property : SelectedTipoHerramientaModelo

        public const string SelectedTipoHerramientaModeloPropertyName = "SelectedTipoHerramientaModelo";

        private TipoHerramientaModelo _SelectedTipoHerramientaModelo;

        public TipoHerramientaModelo SelectedTipoHerramientaModelo
        {
            get
            {
                return _SelectedTipoHerramientaModelo;
            }

            set
            {
                if (_SelectedTipoHerramientaModelo == value) return;

                _SelectedTipoHerramientaModelo = value;
                RaisePropertyChanged(SelectedTipoHerramientaModeloPropertyName);
                //Asignación del tipo de programa
                //currentDetallePrograma.idthprograma = _SelectedTipoHerramientaModelo.id;
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

        #region ViewModel Properties : inicializacionListados

        public const string inicializacionListadosPropertyName = "inicializacionListados";

        private bool _inicializacionListados;

        public bool inicializacionListados
        {
            get
            {
                return _inicializacionListados;
            }

            set
            {
                if (_inicializacionListados == value)
                {
                    return;
                }

                _inicializacionListados = value;
                RaisePropertyChanged(inicializacionListadosPropertyName);
            }
        }

        #endregion

        #region ViewModel Public Methods

        #region Constructores

        public DetalleProgramaViewModel()
        {

        }
        private void ControlCambioLista(bool recepcionDatos)
        {
            if (recepcionDatos)
            {
                BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    guardarlistaDetallePrograma();
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    //Nada se deja la lista actualizada;
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }

        public DetalleProgramaViewModel(string origen)
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            _dialogCoordinator = new DialogCoordinator();
            _origenLlamada = origen;
            switch (origen)
            {
                case "EncargoDocumentacionProgramas":
                    #region tokens
                    _tokenRecepcionCierre = "CierreEncargoDocumentacionProgramaSub-ventana";  //Modificado
                    _tokenRecepcionDatosPadre = "datosDocumentacionDetallePrograma";//Modificado
                    _tokenEnvioVista = "listaDocumentacionDetalleProgramaVista";//Modificado
                    _tokenEnvioProgramas = "EncargoDocumentacionProgramaAuditoriaDetalle";//Modificado
                    _tokenEnvioDetallePrograma = "DatosDocumentacionParaProgramaDetalle";
                    _tokenRecepcionPadrePrincipal = "Programas" + "Documentacion";
                    _tokenHabilitarVentanaPadre = "HabilitarDocumentacionVentanaPadreEncargoPlanEdicionPrograma";
                    _tokenRecepcionVista = "EncargoPlanificacionProgramaCambioOrden";
                    _tokenEnvioDatosAMenu = "DetalleProgramaRegreso";

                    #endregion tokens

                    #region Propiedades del menu
                    _visibilidadMOHide = Visibility.Visible;
                    _visibilidadMOShow = Visibility.Collapsed;
                    _visibilidadMAHide = Visibility.Visible;
                    _visibilidadMAShow = Visibility.Collapsed;
                    Errors = 0;
                    #endregion

                    break;
                case "EncargosPlaneacionProgramas":
                    #region tokens
                    _tokenRecepcionCierre = "CierreEncargoPlanProgramaSub-ventana";
                    _tokenRecepcionDatosPadre = "datosProgramaDetalle";
                    _tokenEnvioVista = "listaDetalleProgramaVista";
                    _tokenEnvioProgramas = "EncargoPlanProgramaAuditoriaDetalle";
                    _tokenEnvioDetallePrograma = "DatosParaProgramaDetalle";
                    _tokenHabilitarVentanaPadre = "HabilitarVentanaPadreEncargoPlanEdicion";
                    _tokenRecepcionVista = "EncargoPlanificacionProgramaCambioOrden";

                    #endregion token
                    #region Propiedades del menu
                    _visibilidadMOHide = Visibility.Collapsed;
                    _visibilidadMOShow = Visibility.Collapsed;
                    _visibilidadMAHide = Visibility.Collapsed;
                    _visibilidadMAShow = Visibility.Collapsed;
                    _visibilidadMEditarHide = Visibility.Collapsed;
                    #endregion
                    break;
            }


            _opcionMenuCrud = 0;
            _opcionMenuPrincipal = 1; //1 para  programa 1, 2 para cuestionario
            _comando = 0;
            _accesibilidadWindow = true;
            RegisterCommands();
            EncargoPlanProgramaDetalleMain = new MainModel();
            currentUsuario = new UsuarioModelo();
            currentPrograma = new ProgramaModelo();
            currentDetallePrograma = null;
            currentEntidadDetalle = new DetalleProgramaModelo();
            accesibilidadWindow = false;
            _inicializacionListados = true;
            dlg = new DialogCoordinator();
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionDatosPadre, (programaDatosMsj) => ControlProgramaDatosMsj(programaDatosMsj));

            #region Vista
            listaObjetivos = new ObservableCollection<DetalleProgramaModelo>();
            listaAlcances = new ObservableCollection<DetalleProgramaModelo>();
            listaDetalleProcedimientos = new ObservableCollection<DetalleProgramaModelo>();
            listaDetalleCapaDatos = new ObservableCollection<detalleprograma>();
            _visibilidadFAprobacion = Visibility.Collapsed;
            _visibilidadFElaboracion = Visibility.Collapsed;
            _visibilidadFSupervision = Visibility.Collapsed;
            _visibilidadMEditarHide = Visibility.Visible;
            currentEntidadDetalle = new DetalleProgramaModelo();
            registroGuardarDetallePrograma = new DetalleProgramaModelo();
            _edicionHabilitada = true;

            #endregion


            _fechainidp = string.Empty;
            _fechafindp = string.Empty;
            _fechasupervision = string.Empty;
            _fechainidpDate = new DateTime();
            _fechafindpDate = new DateTime();
            _fechasupervisionDate = new DateTime();
            _fechacreadodp = new DateTime();
            _currentEncargo = new EncargoModelo();
        }

        private void ControlProgramaDatosMsj(ProgramaDatosMsj programaDatosMsj)
        {
            //opcionMenuPrincipal = programaDatosMsj.opcionMenuPrincipal;//1 Para programa, 2 para cuestionario
            if (!inicializacionListados)
            {
                inicializacion();
            }
            currentEncargo = programaDatosMsj.encargoModelo;
            currentUsuario = programaDatosMsj.usuarioModelo;
            currentPrograma = programaDatosMsj.programaModelo;
            opcionMenuCrud = programaDatosMsj.opcionMenuCrud;
            currentEntidadDetalle = programaDatosMsj.detallePrograma;
            listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>();

            inicializacionListados = true;//Inicializa

            ActualizarlistaDetallePrograma();

            inicializacionListados = false;
            //enviarlistaDetalleProgramaAVista();
            accesibilidadWindow = true;
            //inicializacionTerminada();
            if (currentPrograma.indiceEjecucionprograma == 100)
            {
                edicionHabilitada = false;
            }
            else
            {
                edicionHabilitada = true;
            }
            finComando();
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionDatosPadre);
        }

        private void procesamiento()
        {
            //Procesos normal
            //Inicializando listas
            listaObjetivos = new ObservableCollection<DetalleProgramaModelo>();
            listaAlcances = new ObservableCollection<DetalleProgramaModelo>();
            listaDetalleProcedimientos = new ObservableCollection<DetalleProgramaModelo>();
            listarespuestacuestionario = new ObservableCollection<string>();
            listaDetalleCapaDatos = new ObservableCollection<detalleprograma>(DetalleProgramaModelo.GetAllCapaDatos(currentPrograma.idprograma));
            //listatiporespuestacuestionario = new ObservableCollection<tiporespuestacuestionario>(TipoRespuestaProgramaModelo.GetAllDisplay());
            /*foreach (tiporespuestacuestionario elemento in listatiporespuestacuestionario)
            {
                listarespuestacuestionario.Add(elemento.descripciontrc);
            }*/
            //listarespuestacuestionario = new ObservableCollection<string>(TipoRespuestaProgramaModelo.GetAllDisplayTexto());

            encabezadoPantalla = currentPrograma.nombreprograma;
            horasplanprograma = (decimal)currentPrograma.horasplanprograma;
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
            //Visibiliad de fechas
            if (currentPrograma.fechaaprobacion != null)
            {
                _visibilidadFAprobacion = Visibility.Visible;
            }
            if (currentPrograma.fechasupervision != null)
            {
                _visibilidadFSupervision = Visibility.Collapsed;
            }
            if (currentPrograma.fechacierre != null)
            {
                _visibilidadFElaboracion = Visibility.Collapsed;
            }
            //Procesado desde la ventana principal;

            listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAllVistaEjecucion(currentPrograma.idprograma,currentEncargo.idencargo));

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

            DetalleProgramaModelo padre;
            decimal diferencia = 0;
            //Basado en el  supuesto que la lista viene ordenada con base a ordendp
            foreach (DetalleProgramaModelo item in listaDetalleHerramienta)
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
                            item.IsEditable = false;
                            listaDetalleProcedimientos.Add(item);
                        }
                        else
                        {
                            if (item.idpadredp == null)
                            {
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(contadorProcedimiento);
                                //item.IsEditable = true;
                            }
                            else
                            {
                                contadorProcedimiento--;
                                //item.IsEditable = true;
                                diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contadorProcedimiento, diferencia));
                                //Ajustar la accesibilidad de El procedimiento del  padre
                                try
                                {
                                    listaDetalleProcedimientos.SingleOrDefault(x => x.iddp == item.idpadredp).IsEditable = false;
                                }
                                catch (Exception)
                                {
                                    //Continuar
                                }

                            }
                            //Se habilita para funcionar unicamente para las preguntas
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
            if (listaObjetivos.Count() > 0)
            {
                visibilidadMOHide = Visibility.Visible;
                visibilidadMOShow = Visibility.Collapsed;
            }
            else
            {
                visibilidadMOHide = Visibility.Collapsed;
                visibilidadMOShow = Visibility.Collapsed;
            }
            if (listaAlcances.Count() > 0)
            {
                visibilidadMAHide = Visibility.Visible;
                visibilidadMAShow = Visibility.Collapsed;
            }
            else
            {
                visibilidadMAHide = Visibility.Collapsed;
                visibilidadMAShow = Visibility.Collapsed;
            }
        }

        private void inicializacion()
        {
            currentUsuario = new UsuarioModelo();
            currentPrograma = new ProgramaModelo();
            currentDetallePrograma = new DetalleProgramaModelo();
            currentEntidadDetalle = new DetalleProgramaModelo();
            accesibilidadWindow = false;
            #region Vista
            listaObjetivos = new ObservableCollection<DetalleProgramaModelo>();
            listaAlcances = new ObservableCollection<DetalleProgramaModelo>();
            listaDetalleProcedimientos = new ObservableCollection<DetalleProgramaModelo>();
            //listarespuestacuestionario = new ObservableCollection<string>(TipoRespuestaProgramaModelo.GetAllDisplayTexto());
            //listatiporespuestacuestionario = new ObservableCollection<tiporespuestacuestionario>();
            listaDetalleCapaDatos = new ObservableCollection<detalleprograma>();
            currentEntidadDetalle = new DetalleProgramaModelo();
            registroGuardarDetallePrograma = new DetalleProgramaModelo();
            RegisterCommands();
            #endregion
        }
        private void ControlProgramaPreviewDetalleVistaMensaje(ProgramaPreviewDetalleVistaMensaje programaPreviewDetalleVistaMensaje)
        {
            //Mensaje de ProgramaPresentacionViewModel
            opcionMenuPrincipal = programaPreviewDetalleVistaMensaje.opcionMenuPrincipal;//1 Para programa, 2 para cuestionario
            //currentUsuario = programaPreviewDetalleVistaMensaje.usuarioValidado; 
            //currentPrograma = programaPreviewDetalleVistaMensaje.herramientaModelo; ********Pendiente
            opcionMenuCrud = programaPreviewDetalleVistaMensaje.opcionMenuCrud;
            if (opcionMenuCrud == 3)//Consulta
            {
                accesibilidadWindow = false;
            }
            else
            {
                accesibilidadWindow = true;
            }
            if (currentPrograma.idprograma == 0)
            {
                listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>();
            }
            else
            {
                listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(currentPrograma.idprograma));
            }
            enviarlistaDetalleProgramaAVista();
            Messenger.Default.Unregister<ProgramaPreviewDetalleVistaMensaje>(this);
        }
        private void ControlVentanaMensaje(int controllerProgramaViewMensaje)
        {

                //Para controlar la ventana abierta
                EncargoPlanProgramaDetalleMain.TypeName = null;
                switch (controllerProgramaViewMensaje)
                {
                    case 1:
                        currentDetallePrograma = null;// No es nula porque se agrega a la lista pero no ha cambiado la ventana
                        enviarMensajeHabilitar();
                        break;
                    case 2:
                        currentDetallePrograma = null;// No es nula porque se agrega a la lista pero no ha cambiado la ventana
                        enviarMensajeHabilitar();
                        break;
                    case 3:
                        enviarMensajeHabilitar();
                        break;
                    case 5://Vistaprograma preview
                        enviarMensajeHabilitar();
                        break;
                    default:
                        break;
            }
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierre);
            finComando();
            comando = 0;

        }

        private void ControlTabitemMensaje(TabItemMensaje mensaje)
        {
            //Recibe mensaje que cerro Preview Programa
            if (mensaje.mensaje)
            {
                //Para controlar la ventana abierta
                EncargoPlanProgramaDetalleMain.TypeName = null;
                switch (comando)
                {
                    case 1:
                        currentDetallePrograma = null;// No es nula porque se agrega a la lista pero no ha cambiado la ventana
                        if (mensaje.concluido)//No se procesa porque se cancelo o se cerro la ventana
                        {
                            ActualizarlistaDetallePrograma();
                        }
                        enviarMensajeHabilitar();
                        break;
                    case 2:
                        currentDetallePrograma = null;// No es nula porque se agrega a la lista pero no ha cambiado la ventana
                                                      //Mouse.OverrideCursor = null;
                        if (mensaje.concluido)//No se procesa porque se cancelo o se cerro la ventana
                        {
                            ActualizarlistaDetallePrograma();
                        }
                        enviarMensajeHabilitar();

                        break;
                    case 3:
                        enviarMensajeHabilitar();
                        break;
                    case 5://Vistaprograma preview
                        enviarMensajeHabilitar();
                        break;
                    default:
                        break;
                }
                Messenger.Default.Unregister<TabItemMensaje>(this, tokenRecepcionCierre);
                finComando();
                comando = 0;
            }
        }

        private void ControlDetalleEncargoPlanProgramaMsj(DetalleEncargoPlanProgramaMsj detalleHerramientaMensaje)
        {
            if (!inicializacionListados)
            {
                inicializacion();
            }
            inicializacionListados = false;
            currentDetallePrograma = new DetalleProgramaModelo();
            opcionMenuPrincipal = detalleHerramientaMensaje.opcionMenuPrincipal;//1 Para programa, 2 para cuestionario
            currentUsuario = detalleHerramientaMensaje.usuarioModelo;
            currentPrograma = detalleHerramientaMensaje.programaModelo;
            opcionMenuCrud = detalleHerramientaMensaje.opcionMenuCrud;
            if (opcionMenuCrud == 3)
            {
                accesibilidadWindow = false;
            }
            else
            {
                accesibilidadWindow = true;
            }
            if (currentPrograma.idprograma == 0)
            {
                listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>();
            }
            else
            {
                listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(currentPrograma.idprograma));
            }
            enviarlistaDetalleProgramaAVista();
            Messenger.Default.Unregister<DetalleEncargoPlanProgramaMsj>(this, tokenRecepcionDatosPadre);
            finComando();
        }

        private void enviarlistaDetalleProgramaAVista()
        {
            //Manda la referencia de la vista; Para programas
            EncargosPlanProgramasDetalleListaMsj listaDetalle = new EncargosPlanProgramasDetalleListaMsj();
            listaDetalle.listaElementos = listaDetallePrograma;
            Messenger.Default.Send(listaDetalle, tokenEnvioVista);
        }

        #region listados
        private void ActualizarlistaDetallePrograma()
        {
            if (!inicializacionListados)
            {
                if (origenLlamada == "")
                {
                    guardarlistaDetallePrograma();
                }
                else
                {
                    //guardarlistaDetalleProgramaEjecucion();
                }
            }
            try
            {
                if (origenLlamada == "")
                {
                    listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(currentPrograma.idprograma));
                }
                else
                {
                    //No se reordena
                    listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(currentPrograma.idprograma, false));
                }

                if (origenLlamada != "")
                {
                    procesamiento();
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas \n", ""+e);
                }
            }
            //Se manda a la vista actualizada
            //enviarlistaDetalleProgramaAVista();
        }

        #endregion


        //public async Task<int> guardarlistaDetalleProgramaEjecucion()
        //{
        //    try
        //    {
        //        int resultado = -1;
        //        int caso = 0;
        //        foreach (DetalleProgramaModelo item in listaDetalleProcedimientos)
        //        // foreach (DetalleCuestionarioModelo item in listaDetallePrograma)
        //        {
        //            caso = 0;
        //            //if (item.guardadoBase == false && ((item.descripciontrc != null && item.descripciontrc != "") || (item.comentariodp != null && item.comentariodp != "") || (item.referenciaPt != null && item.referenciaPt != "")) )
        //            if (item.guardadoBase == false && item.estadoprocedimientodp != "T")
        //            {

        //                if (item.descripciontrc != null && item.descripciontrc != "")
        //                {
        //                    item.idtrcdc = listatiporespuestacuestionario.SingleOrDefault(x => x.descripciontrc == item.descripciontrc).idtrc;
        //                    item.estadoprocedimientodp = "E";
        //                    caso = 1; //cambio la respuesta
        //                }
        //                if (caso == 1)
        //                {
        //                    if (item.comentariodp != null && item.comentariodp != "")
        //                    {
        //                        caso = 2; //cambio la respuesta y el comentario
        //                    }
        //                }
        //                else
        //                {
        //                    if (item.comentariodp != null && item.comentariodp != "")
        //                    {
        //                        caso = 3; //cambio el comentario
        //                    }
        //                }
        //                switch (caso)
        //                {
        //                    case 1://Cambio solo tipo de respuesta
        //                        if (origenLlamada == "EncargoDocumentacionCuestionarios")
        //                        {
        //                            if (DetalleCuestionarioModelo.UpdateModeloEjecucion(item, caso))
        //                            {
        //                                //Se guardo con éxito
        //                                resultado = -1;
        //                                item.guardadoBase = true;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (DetalleCuestionarioModelo.UpdateModelo(item, currentUsuario, currentEncargo.idencargo))
        //                            {
        //                                //Se guardo con éxito
        //                                resultado = -1;
        //                                item.guardadoBase = true;
        //                            }
        //                        }
        //                        break;
        //                    case 2://Cambio  comentario y tipo de respuesta
        //                        if (origenLlamada == "EncargoDocumentacionCuestionarios")
        //                        {
        //                            if (DetalleCuestionarioModelo.UpdateModeloEjecucion(item))
        //                            {
        //                                //Se guardo con éxito
        //                                resultado = -1;
        //                                item.guardadoBase = true;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (DetalleCuestionarioModelo.UpdateModelo(item, currentUsuario, currentEncargo.idencargo))
        //                            {
        //                                //Se guardo con éxito
        //                                resultado = -1;
        //                                item.guardadoBase = true;
        //                            }
        //                        }
        //                        break;
        //                    case 3:// cambio solo comentario
        //                        if (origenLlamada == "EncargoDocumentacionCuestionarios")
        //                        {
        //                            if (DetalleCuestionarioModelo.UpdateModeloEjecucion(item, caso))
        //                            {
        //                                //Se guardo con éxito
        //                                resultado = -1;
        //                                item.guardadoBase = true;
        //                            }
        //                        }
        //                        else
        //                        {
        //                            if (DetalleCuestionarioModelo.UpdateModelo(item, currentUsuario, currentEncargo.idencargo))
        //                            {
        //                                //Se guardo con éxito
        //                                resultado = -1;
        //                                item.guardadoBase = true;
        //                            }
        //                        }
        //                        break;
        //                    default://Error
        //                        break;
        //                }

        //            }

        //        }
        //        return resultado;
        //    }
        //    catch (Exception e)
        //    {
        //        await mensajeAutoCerrado("Error \n" + e, "", 2);
        //        return 0;
        //    }
        //}


        public int guardarlistaDetalleProgramaEjecucion()
        {
            try
            {
                int resultado = 0;
                foreach (DetalleProgramaModelo item in listaDetalleProcedimientos)
                // foreach (DetalleProgramaModelo item in listaDetallePrograma)
                {
                    //if (item.guardadoBase == false && ((item.descripciontrc != null && item.descripciontrc != "") || (item.comentariodp != null && item.comentariodp != "") || (item.referenciaPt != null && item.referenciaPt != "")) )
                    if (item.guardadoBase == false && item.estadoprocedimientodp != "T")
                    {
                        //Ver que campo debe ser actualizado
                        if (DetalleProgramaModelo.UpdateModeloCierre(item, currentUsuario, currentEncargo.idencargo))
                        {
                            //Se guardo con éxito
                            resultado = -1;
                            item.guardadoBase = true;
                        }
                        else
                        {
                            // await dlg.ShowMessageAsync(this, "No ha sido posible actualizar un registro", "");
                            //resultado= 0;
                        }
                    }

                }
                return resultado;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public void guardarlistaDetallePrograma()
        {
            foreach (DetalleProgramaModelo item in listaDetallePrograma)
            {
                if (item.guardadoBase == false)
                {
                    DetalleProgramaModelo.UpdateModeloReodenar(item);
                }
            }
        }

        #endregion

        #region Envio mensajes

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            bool mensaje = false;
            Messenger.Default.Send<bool>(mensaje, tokenHabilitarVentanaPadre);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            bool mensaje = true;
            Messenger.Default.Send<bool>(mensaje, tokenHabilitarVentanaPadre);
        }
        public void enviarElemento()
        {
            //Se crea el mensaje
            EncargoPlanDetalleProgramaCrudMsj elemento = new EncargoPlanDetalleProgramaCrudMsj();
            elemento.detalleHerramientaElemento = currentDetallePrograma;
            elemento.listaElementos = listaDetallePrograma;
            elemento.comando = comando;
            elemento.tiposHerramienta = currentPrograma.idthprograma;//1 Programa 2 cuestionario
            elemento.usuarioValidado = currentUsuario;
            elemento.herramientaModelo = currentPrograma;
            elemento.currentEncargo = currentEncargo;
            Messenger.Default.Send(elemento, tokenEnvioDetallePrograma);
        }
        public void enviarMensajeVista()
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.usuarioModelo = currentUsuario;
            elemento.programaModelo = currentPrograma;//Programa a crear 
            elemento.detallePrograma = null;//Para el caso de  edicion de programas
            elemento.opcionTipoPrograma = 2;//Por ser un programa ad-hoc
            elemento.opcionMenuCrud = opcionMenuCrud;
            elemento.fuenteLlamado = 2;//Se esta llamando desde la sub-ventana
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            elemento.listaDetalleHerramientaP = listaDetallePrograma;
            Messenger.Default.Send(elemento, tokenEnvioProgramas);
        }

        #endregion

        #region Receptor de mensajes


        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            enviarMensajeInhabilitar();
            currentDetallePrograma = new DetalleProgramaModelo(currentPrograma.idprograma, currentUsuario);
            //currentDetallePrograma.ordendp = ordenElementolistaDetallePrograma();
            comando = 1;
            EncargoPlanProgramaDetalleMain.TypeName = "DetalleProgramaModeloCrearView";
            enviarElemento();

        }

        public async void Editar()
        {
            if (!(currentDetallePrograma == null))
            {
                if (currentDetallePrograma.estadoprocedimientodp == "I")
                {
                    iniciarComando();
                    enviarMensajeInhabilitar();
                    EncargoPlanProgramaDetalleMain.TypeName = "DetalleProgramaModeloEditarView";
                    comando = 2;
                    enviarElemento();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El procedimiento esta ya en proceso, no puede modificarse", "Puede realizar consulta únicamente");
                }

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
        }
        public async void Consultar()
        {
            if (!(currentDetallePrograma == null))
            {
                iniciarComando();
                enviarMensajeInhabilitar();
                EncargoPlanProgramaDetalleMain.TypeName = "DetalleProgramaModeloConsultarView";
                comando = 3;
                enviarElemento();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        public async void ConsultarDobleClick()
        {
            if (!(currentDetallePrograma == null))
            {
                iniciarComando();
                enviarMensajeInhabilitar();
                comando = 3;
                EncargoPlanProgramaDetalleMain.TypeName = "DetalleProgramaModeloConsultarView";
                enviarElemento();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        public async void Borrar()
        {
            if (!(currentDetallePrograma == null))
            {
                if (currentDetallePrograma.estadoprocedimientodp == "I")
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    accesibilidadWindow = false;

                    if (DetalleProgramaModelo.Delete(currentDetallePrograma.iddp, true))
                    //if (HerramientasModelo.Delete(currentDetallePrograma.id, true))
                    {
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        ActualizarlistaDetallePrograma();
                        currentDetallePrograma = new DetalleProgramaModelo();

                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                    accesibilidadWindow = true;
                    Mouse.OverrideCursor = null;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El procedimiento esta ya en proceso, no puede modificarse", "Puede realizar consulta únicamente");
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }

        public async void BorrarLogico()
        {
            if (!(currentDetallePrograma == null))
            {
                if (currentDetallePrograma.estadoprocedimientodp == "I")
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    accesibilidadWindow = false;

                    if (DetalleProgramaModelo.DeleteBorradoLogico(currentDetallePrograma.iddp, true))
                    //if (HerramientasModelo.Delete(currentDetallePrograma.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        ActualizarlistaDetallePrograma();
                        currentDetallePrograma = new DetalleProgramaModelo();

                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                    accesibilidadWindow = true;
                    Mouse.OverrideCursor = null;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El procedimiento esta ya en proceso, no puede modificarse", "Puede realizar consulta únicamente");
                }
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
            return !(currentDetallePrograma.iddp == 0) &&
                   !string.IsNullOrEmpty(currentDetallePrograma.descripciondp);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<DetalleProgramaModelo> listaEntidad)
        {
            listaDetallePrograma = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentDetallePrograma != null;
        }

        public bool CanEditar()
        {
            if (listaDetalleProcedimientos.Count() == listaDetalleProcedimientos.Where(x => x.estadoprocedimientodp == "T").Count())
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool CanCommand()
        {
            if (!(currentDetallePrograma == null))
            {
                try
                {
                    return currentDetallePrograma.iddp != 0;
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
        public bool CanDetalleCommand()
        {
            if (!(currentDetallePrograma == null))
            {
                try
                {
                    return currentDetallePrograma.iddp != 0;
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

        public bool CanHideObjetivo()
        {
            if (visibilidadMOShow == Visibility.Collapsed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CanShowObjetivo()
        {
            if (visibilidadMOHide == Visibility.Collapsed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CanHideAlcance()
        {
            if (visibilidadMAShow == Visibility.Collapsed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanShowAlcance()
        {
            if (visibilidadMAHide == Visibility.Collapsed)
            {
                return true;
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
            NuevoCommand = new RelayCommand(Nuevo);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            BuscarCommand = new RelayCommand(Buscar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            VistaProgramaCommand = new RelayCommand(VistaPrograma);
            //Asignar el registro
            SelectionChangedCommand = new RelayCommand<DetalleProgramaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentDetallePrograma = entidad;
            });

            irMenuPadreCommand = new RelayCommand(irPrincipal);

            referenciarCommand = new RelayCommand(Referenciar, CanEditar);


            guardarDetalleCommand = new RelayCommand(guardarDetalle, CanEditar);

            cambioRespuestaCommand = new RelayCommand<tiporespuestacuestionario>(entidad =>
            {
                if (entidad == null) return;
                //currentDetallePrograma.SelectedTipoRespuesta = entidad;
                //currentDetallePrograma.descripciontrc = entidad.descripciontrc;
            });

            //SelectionDetalleChangedCommand
            SelectionDetalleChangedCommand = new RelayCommand<DetalleProgramaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentDetallePrograma = entidad;
                currentDetallePrograma.guardadoBase = false;//Para tener registros que guardar
                //currentDetallePrograma.IsSelected = true;
                listaDetalleProcedimientos.Where(x => x.iddp != currentDetallePrograma.iddp).Select(x => x.IsSelected = false);
                //Verificar el estado y habilitar en caso que corresponda
            });


            DobleClickCommand = new RelayCommand(DobleClick);

            completarCommand = new RelayCommand(completarProcedimiento, CanDetalleCommand);

            hideObjetivosCommand = new RelayCommand(ocultarObjetivos, CanHideObjetivo);
            showObjetivosCommand = new RelayCommand(mostrarObjetivos, CanShowObjetivo);

            hideAlcanceCommand = new RelayCommand(ocultarAlcance, CanHideAlcance);
            showAlcanceCommand = new RelayCommand(mostrarAlcance, CanShowAlcance);
            terminarPapelCommand = new RelayCommand(terminarProcedimiento, CanDetalleCommand);//Finaliza el procedimiento

        }

        private async void terminarProcedimiento()
        {
            //Para cerrar el programa, debe de estar referenciados cada procedimiento de  auditoria
            if (!(currentDetallePrograma == null))
            {
                //int preguntasPendientes = ProgramaModelo.evaluarCierreCuestionario(currentEntidad.idprograma)
                if (currentDetallePrograma.estadoprocedimientodp != "T" && currentDetallePrograma.estadoprocedimientodp != "R" && currentDetallePrograma.estadoprocedimientodp != "A")
                 //   if (currentDetallePrograma.estadoprocedimientodp != "T") //Hay cero procedimientos diferentes a iniciados
                {
                    if (currentDetallePrograma.idgenerico!=null && currentDetallePrograma.idgenerico != 0)
                    {
                        accesibilidadWindow = false;
                        //Mouse.OverrideCursor = Cursors.Wait;
                        var mySettings = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Ok",
                            NegativeButtonText = "Cancelar",
                        };

                        MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea dar por terminado el procedimiento?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                        if (result == MessageDialogResult.Affirmative)
                        {
                            Mouse.OverrideCursor = Cursors.Wait;
                            if (DetalleProgramaModelo.UpdateModeloCierreProcedimiento(currentDetallePrograma, currentUsuario, currentEncargo.idencargo))
                            {
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "Se cerro el procedimiento, queda sujeto a revision", "");
                                //actualizarLista();
                                currentDetallePrograma = new DetalleProgramaModelo();
                            }
                            else
                            {
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "No ha sido posible cerrar el registro", "");
                            }
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Canceló el cierre del procedimiento", "");
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "El procedimiento no  tiene referencia ","Debe referenciarlo para poder cerrarlo") ;
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    await dlg.ShowMessageAsync(this, "El procedimiento ya esta cerrado", "No puede cerrarse dos veces");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a cerrar", "");
            }
            accesibilidadWindow = true;
            Mouse.OverrideCursor = null;
        }

        private void mostrarAlcance()
        {
            visibilidadMAHide = Visibility.Visible;
            visibilidadMAShow = Visibility.Collapsed;

            if (listaAlcances.Count() > 0)
            {
                if (listaAlcances.Count() > 1)
                {
                    visibilidadAlcancesReducido = Visibility.Collapsed;
                    visibilidadAlcances = Visibility.Visible;
                }
                else
                {
                    visibilidadAlcancesReducido = Visibility.Visible;
                    visibilidadAlcances = Visibility.Collapsed;
                }
            }
            else
            {
                visibilidadAlcances = Visibility.Collapsed;
                visibilidadAlcancesReducido = Visibility.Collapsed;
            }
        }

        private void mostrarObjetivos()
        {
            visibilidadMOHide = Visibility.Visible;
            visibilidadMOShow = Visibility.Collapsed;
            if (listaObjetivos.Count() > 0)
            {
                if (listaObjetivos.Count() >1)
                {
                    visibilidadObjetivosReducido = Visibility.Collapsed;
                    visibilidadObjetivos = Visibility.Visible;
                }
                else
                {
                    visibilidadObjetivos = Visibility.Collapsed;
                    visibilidadObjetivosReducido = Visibility.Visible;
                }
            }
            else
            {
                visibilidadObjetivosReducido = Visibility.Collapsed;
                visibilidadObjetivos = Visibility.Collapsed;
            }
        }
        private void ocultarAlcance()
        {
            visibilidadMAHide = Visibility.Collapsed;
            visibilidadMAShow = Visibility.Visible;
            visibilidadAlcances = Visibility.Collapsed;
            visibilidadAlcancesReducido = Visibility.Collapsed;
        }

        private void ocultarObjetivos()
        {
            visibilidadMOHide = Visibility.Collapsed;
            visibilidadMOShow = Visibility.Visible;
            visibilidadObjetivosReducido = Visibility.Collapsed;
            visibilidadObjetivos = Visibility.Collapsed;
        }


        private async void completarProcedimiento()
        {
            //Se lanza la ventana para completar datos
            if (!(currentDetallePrograma == null))
            {
                if (currentDetallePrograma.estadoprocedimientodp == "T" && currentDetallePrograma.estadoprocedimientodp == "R" && currentDetallePrograma.estadoprocedimientodp == "A")
                {
                    await dlg.ShowMessageAsync(this, "El procedimeinto esta cerrado", "ya no puede editarse");
                }
                else
                { 
                    iniciarComando();
                    enviarMensajeInhabilitar();
                    EncargoPlanProgramaDetalleMain.TypeName = "DetalleProgramaModeloCompletarView";
                    comando = 10;
                    enviarElemento();
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a completar", "");
            }
        }

        private void DobleClick()
        {
            //Nada
        }

        private async void guardarDetalle()
        {
            if (Errors != 0)
            {
                await dlg.ShowMessageAsync(this, "Han sido editados datos con error", "Corríjalos para poder guardar");
            }
            else
            { 
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Ok",
                NegativeButtonText = "Cancelar",
            };

            MessageDialogResult result = await dlg.ShowMessageAsync(this, "Se guardaran los datos", "¿Desea guardar los cambios?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

            if (result == MessageDialogResult.Affirmative)
            {
                iniciarComando();
                //Repite el  ciclo para evitar errores
                if (listaDetalleProcedimientos.Where(x => x.guardadoBase == false).Count() > 0)
                {
                    if (guardarlistaDetalleProgramaEjecucion() == -1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Se actualizaron las respuestas ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        finComando();
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "No pudo actualizarse las  respuesta", "Verifique si tiene conexión");
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "No hay cambios en los registros", "");
                }
            }
            else
            {
                currentEntidadDetalle = null;
                finComando();
                await dlg.ShowMessageAsync(this, "No se actualizaron los registros", "verifique si tiene conexión");
            }

            finComando();
            }
            //Gestiona el guardar los cambios en  la lista
        }

        private async void Referenciar()
        {
            ControlCambioLista(true);
            //if (listaDetalleProcedimientos.Where(x => x.IsSelected).Count() == 1)
            //{
                if (!(currentDetallePrograma == null))
                {
                comando = 8;//Referenciar
                iniciarComando();
                    EncargoPlanProgramaDetalleMain.TypeName = "DetalleIndiceModeloReferenciarview";
                    //currentEntidad.usuarioModelo = currentUsuario;
                    enviarMensajeReferenciacion();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el elemento a referenciar", "");
                }
            //}
            //else
            //{
            //    await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para referenciar", "");
            //}
        }

        public void enviarMensajeReferenciacion()
        {
            //Se crea el mensaje
            EncargoPlanDetalleIndiceMsj elemento = new EncargoPlanDetalleIndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.detalleHerramientaElemento = currentEntidad;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            //elemento.herramientaModelo = currentCarpeta;//Para el caso de  edicion de programas
            //elemento.listaTipoCarpetaModel =;
            //elemento.listaElementos = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuesta = tokenRecepcionCierre;
            elemento.fuenteLlamado = 5; //no se utiliza
            elemento.programaModelo = currentDetallePrograma;
            Messenger.Default.Send(elemento,tokenEnvioDetallePrograma);
        }

        private void irPrincipal()
        {
            //if (Errors != 0)
            //{
            //    await dlg.ShowMessageAsync(this, "Hay datos editados con error", "debe corregir antes de regresar");
            //}
            //else
            //{ 
            //if (CanEditar())
            //{
            //    if (listaDetalleProcedimientos.Where(x => x.guardadoBase == false).Count() > 0)
            //    {
            //        var mySettings = new MetroDialogSettings()
            //        {
            //            AffirmativeButtonText = "Si",
            //            NegativeButtonText = "No",
            //        };

            //        MessageDialogResult result = await dlg.ShowMessageAsync(this, "Desea guardar los cambios antes de regresar", "", MessageDialogStyle.AffirmativeAndNegative, mySettings);

            //        if (result == MessageDialogResult.Affirmative)
            //        {
            //iniciarComando();
            ////Repite el  ciclo para evitar errores
            //if (listaDetalleProcedimientos.Where(x => x.guardadoBase == false).Count() > 0)
            //{
            //    if (guardarlistaDetalleProgramaEjecucion() == -1)
            //    {
            //        var controller = await dlg.ShowProgressAsync(this, "Se actualizaron las respuestas ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
            //controller.SetIndeterminate();
            //await TaskEx.Delay(1000);
            //await controller.CloseAsync();
            //finComando();
            //}
            //else
            //{
            //    finComando();
            //    await dlg.ShowMessageAsync(this, "No pudo actualizarse las  respuesta", "Verifique si tiene conexión");
            //}
            //            }
            //            else
            //            {
            //                finComando();
            //                await dlg.ShowMessageAsync(this, "No hay cambios en los registros", "");
            //            }
            //        }
            //        else
            //        {
            //            finComando();
            //        }
            //    }
            //}
            //Gestiona el guardar los cambios en  la lista
            iniciarComando();
            //Mandar el mensaje al principal que domina la pantalla
            currentEntidadDetalle = null;
            Messenger.Default.Send(currentPrograma.idprograma, tokenEnvioDatosAMenu);
            //}
        }

        private void VistaPrograma()
        {
            iniciarComando();
            enviarMensajeInhabilitar();
            comando = 5;
            //accesibilidadWindow = false;
            EncargoPlanProgramaDetalleMain.TypeName = "ProgramaVistaImpresionView";
            comando = 5;
            enviarMensajeVista();
        }


        private void Buscar()
        {
            throw new NotImplementedException();
            //Pendiente
        }

        private void XImprimir()
        {
            //throw new NotImplementedException();
        }


        #endregion


        #region Lanzado de  comando

        private void iniciarComando()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<ProgramaPreviewDetalleVistaMensaje>(this, (programaPreviewDetalleVistaMensaje) => ControlProgramaPreviewDetalleVistaMensaje(programaPreviewDetalleVistaMensaje));
            Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            if (comando == 8)
            {
                Messenger.Default.Register<int>(this, tokenRecepcionCierre, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            }
            accesibilidadWindow = false;
        }



        private void finComando()
        {
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<ProgramaPreviewDetalleVistaMensaje>(this);
            Messenger.Default.Unregister<TabItemMensaje>(this, tokenRecepcionCierre);
            if (opcionMenuCrud != 3)
            {
                accesibilidadWindow = true;
            }
        }



        #endregion Fin de comando
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