using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
//Libreria indispensable para realizar la validacion de can executa.
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Linq;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Globalization;
using CapaDatos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cierre
{
    public sealed class CierreEncargoControllerViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        #region tokenEnvioController

        private string _tokenEnvioController;
        private string tokenEnvioController
        {
            get { return _tokenEnvioController; }
            set { _tokenEnvioController = value; }
        }

        #endregion

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        public static int Errors { get; set; }


        #region FuenteCierre

        private int _fuenteCierre;
        private int fuenteCierre
        {
            get { return _fuenteCierre; }
            set { _fuenteCierre = value; }
        }

        #endregion

        #region FuenteLlamada

        private int _FuenteLlamada;
        private int FuenteLlamada
        {
            get { return _FuenteLlamada; }
            set { _FuenteLlamada = value; }
        }

        #endregion

        #region idNivelCuenta

        private int _idNivelCuenta;
        private int idNivelCuenta
        {
            get { return _idNivelCuenta; }
            set { _idNivelCuenta = value; }
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

        #region Usuario validado

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

        #region opcionMenu

        private int _opcionMenu;
        private int opcionMenu
        {
            get { return _opcionMenu; }
            set { _opcionMenu = value; }
        }

        #endregion

        #region codigoContableValido

        private bool _codigoContableValido;
        private bool codigoContableValido
        {
            get { return _codigoContableValido; }
            set { _codigoContableValido = value; }
        }

        #endregion

        #endregion

        #region Lista de entidades

        #region ViewModel Properties : listaBitacora

        public const string listaBitacoraPropertyName = "listaBitacora";

        private ObservableCollection<BitacoraModelo> _listaBitacora;

        public ObservableCollection<BitacoraModelo> listaBitacora
        {
            get
            {
                return _listaBitacora;
            }
            set
            {
                if (_listaBitacora == value) return;

                _listaBitacora = value;

                RaisePropertyChanged(listaBitacoraPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaBCEncargos

        public const string listaBCEncargosPropertyName = "listaBCEncargos";

        private ObservableCollection<BalanceModelo> _listaBCEncargos;

        public ObservableCollection<BalanceModelo> listaBCEncargos
        {
            get
            {
                return _listaBCEncargos;
            }
            set
            {
                if (_listaBCEncargos == value) return;

                _listaBCEncargos = value;

                RaisePropertyChanged(listaBCEncargosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<BalanceModelo> _listaEntidadSeleccion;

        public ObservableCollection<BalanceModelo> listaEntidadSeleccion
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

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<EncargoModelo> _lista;

        public ObservableCollection<EncargoModelo> lista
        {
            get
            {
                return _lista;
            }
            set
            {
                if (_lista == value) return;

                _lista = value;

                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaEntidadSeleccionPeriodo

        public const string listaEntidadSeleccionPeriodoPropertyName = "listaEntidadSeleccionPeriodo";

        private ObservableCollection<PeriodoModelo> _listaEntidadSeleccionPeriodo;

        public ObservableCollection<PeriodoModelo> listaEntidadSeleccionPeriodo
        {
            get
            {
                return _listaEntidadSeleccionPeriodo;
            }
            set
            {
                if (_listaEntidadSeleccionPeriodo == value) return;

                _listaEntidadSeleccionPeriodo = value;

                RaisePropertyChanged(listaEntidadSeleccionPeriodoPropertyName);
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


        #region Propiedes de presentacion agregadas

        #region razonsocialcliente

        public const string razonsocialclientePropertyName = "razonsocialcliente";

        private string _razonsocialcliente = string.Empty;

        public string razonsocialcliente
        {
            get
            {
                return _razonsocialcliente;
            }

            set
            {
                if (_razonsocialcliente == value)
                {
                    return;
                }

                _razonsocialcliente = value;
                RaisePropertyChanged(razonsocialclientePropertyName);
            }
        }

        #endregion

        #region descripcionCbEtapaEncargo

        public const string descripcionCbEtapaEncargoPropertyName = "descripcionCbEtapaEncargo";

        private string _descripcionCbEtapaEncargo = string.Empty;

        public string descripcionCbEtapaEncargo
        {
            get
            {
                return _descripcionCbEtapaEncargo;
            }

            set
            {
                if (_descripcionCbEtapaEncargo == value)
                {
                    return;
                }

                _descripcionCbEtapaEncargo = value;
                RaisePropertyChanged(descripcionCbEtapaEncargoPropertyName);
            }
        }

        #endregion

        #region descripcionCbTipoClienteEncargo

        public const string descripcionCbTipoClienteEncargoPropertyName = "descripcionCbTipoClienteEncargo";

        private string _descripcionCbTipoClienteEncargo = string.Empty;

        public string descripcionCbTipoClienteEncargo
        {
            get
            {
                return _descripcionCbTipoClienteEncargo;
            }

            set
            {
                if (_descripcionCbTipoClienteEncargo == value)
                {
                    return;
                }

                _descripcionCbTipoClienteEncargo = value;
                RaisePropertyChanged(descripcionCbTipoClienteEncargoPropertyName);
            }
        }


        #endregion

        #region descripcionCbTipoAuditoria

        public const string descripcionCbTipoAuditoriaPropertyName = "descripcionCbTipoAuditoria";

        private string _descripcionCbTipoAuditoria = string.Empty;

        public string descripcionCbTipoAuditoria
        {
            get
            {
                return _descripcionCbTipoAuditoria;
            }

            set
            {
                if (_descripcionCbTipoAuditoria == value)
                {
                    return;
                }

                _descripcionCbTipoAuditoria = value;
                RaisePropertyChanged(descripcionCbTipoAuditoriaPropertyName);
            }
        }


        #endregion

        #endregion

        #region Otras propiedades



        #endregion

        #endregion

        #endregion Lista de entidades

        #region Entidades en uso de encargos

        #region ViewModel Property : currentEntidadBitacora

        public const string currentEntidadBitacoraPropertyName = "currentEntidadBitacora";

        private BitacoraModelo _currentEntidadBitacora;

        public BitacoraModelo currentEntidadBitacora
        {
            get
            {
                return _currentEntidadBitacora;
            }

            set
            {
                if (_currentEntidadBitacora == value) return;

                _currentEntidadBitacora = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadBitacoraPropertyName);
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

        #region ViewModel Property : selectedBCImportar

        public const string selectedBCImportarPropertyName = "selectedBCImportar";

        private BalanceModelo _selectedBCImportar;

        public BalanceModelo selectedBCImportar
        {
            get
            {
                return _selectedBCImportar;
            }

            set
            {
                if (_selectedBCImportar == value) return;

                _selectedBCImportar = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedBCImportarPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionBCImportar

        public const string eleccionBCImportarPropertyName = "eleccionBCImportar";

        private BalanceModelo _eleccionBCImportar;

        public BalanceModelo eleccionBCImportar
        {
            get
            {
                return _eleccionBCImportar;
            }

            set
            {
                if (_eleccionBCImportar == value) return;

                _eleccionBCImportar = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionBCImportarPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private EncargoModelo _currentEntidad;

        public EncargoModelo currentEntidad
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

        #region ViewModel Property : tipoAuditoriaModelo

        public const string tipoAuditoriaModeloPropertyName = "tipoAuditoriaModelo";

        private TipoAuditoriaModelo _tipoAuditoriaModelo;

        public TipoAuditoriaModelo tipoAuditoriaModelo
        {
            get
            {
                return _tipoAuditoriaModelo;
            }

            set
            {
                if (_tipoAuditoriaModelo == value) return;

                _tipoAuditoriaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(tipoAuditoriaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : clienteModelo

        public const string clienteModeloPropertyName = "clienteModelo";

        private ClienteModelo _clienteModelo;

        public ClienteModelo clienteModelo
        {
            get
            {
                return _clienteModelo;
            }

            set
            {
                if (_clienteModelo == value) return;

                _clienteModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(clienteModeloPropertyName);
            }
        }

        #endregion


        #endregion

        #region Propiedades de ventanas


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

        #region contenidoControlCarga

        public const string contenidoControlCargaPropertyName = "contenidoControlCarga";

        private string _contenidoControlCarga = "Cargar";

        public string contenidoControlCarga
        {
            get
            {
                return _contenidoControlCarga;
            }

            set
            {
                if (_contenidoControlCarga == value)
                {
                    return;
                }

                _contenidoControlCarga = value;
                RaisePropertyChanged(contenidoControlCargaPropertyName);
            }
        }

        #endregion


        #region visibilidadCuentaPadre

        public const string visibilidadCuentaPadrePropertyName = "visibilidadCuentaPadre";

        private Visibility _visibilidadCuentaPadre = Visibility.Collapsed;

        public Visibility visibilidadCuentaPadre
        {
            get
            {
                return _visibilidadCuentaPadre;
            }

            set
            {
                if (_visibilidadCuentaPadre == value)
                {
                    return;
                }

                _visibilidadCuentaPadre = value;
                RaisePropertyChanged(visibilidadCuentaPadrePropertyName);
            }
        }

        #endregion

        #region visibilidadBitacora

        public const string visibilidadBitacoraPropertyName = "visibilidadBitacora";

        private Visibility _visibilidadBitacora = Visibility.Visible;

        public Visibility visibilidadBitacora
        {
            get
            {
                return _visibilidadBitacora;
            }

            set
            {
                if (_visibilidadBitacora == value)
                {
                    return;
                }

                _visibilidadBitacora = value;
                RaisePropertyChanged(visibilidadBitacoraPropertyName);
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

        #region activacionContenido 


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


        #region identifica el cambiode la fecha de evaluacion : cambioFechaEvaluacion

        public const string cambioFechaEvaluacionPropertyName = "cambioFechaEvaluacion";

        private bool _cambioFechaEvaluacion;

        public bool cambioFechaEvaluacion
        {
            get
            {
                return _cambioFechaEvaluacion;
            }

            set
            {
                if (_cambioFechaEvaluacion == value)
                {
                    return;
                }

                _cambioFechaEvaluacion = value;
                RaisePropertyChanged(cambioFechaEvaluacionPropertyName);
            }
        }

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

        #region activarClaseCuenta

        public const string activarClaseCuentaPropertyName = "activarClaseCuenta";

        private bool _activarClaseCuenta = false;

        public bool activarClaseCuenta
        {
            get
            {
                return _activarClaseCuenta;
            }

            set
            {
                if (_activarClaseCuenta == value)
                {
                    return;
                }

                _activarClaseCuenta = value;
                RaisePropertyChanged(activarClaseCuentaPropertyName);
            }
        }

        #endregion

        #region fechaejecutoSelected

        public const string fechaejecutoSelectedPropertyName = "fechaejecutoSelected";

        private DateTime _fechaejecutoSelected;

        public DateTime fechaejecutoSelected
        {
            get
            {
                return _fechaejecutoSelected;
            }

            set
            {
                if (_fechaejecutoSelected == value)
                {
                    return;
                }

                _fechaejecutoSelected = value;
                RaisePropertyChanged(fechaejecutoSelectedPropertyName);
            }
        }


        #endregion

        #region fechacreado

        public const string fechacreadoPropertyName = "fechacreado";

        private DateTime _fechacreado = DateTime.Now;

        public DateTime fechacreado
        {
            get
            {
                return _fechacreado;
            }

            set
            {
                if (_fechacreado == value)
                {
                    return;
                }

                _fechacreado = value;
                RaisePropertyChanged(fechacreadoPropertyName);
            }
        }

        #endregion

        #region fechaevaluacionmr

        public const string fechaevaluacionmrPropertyName = "fechaevaluacionmr";

        private DateTime _fechaevaluacionmr = DateTime.Now;

        public DateTime fechaevaluacionmr
        {
            get
            {
                return _fechaevaluacionmr;
            }

            set
            {
                if (_fechaevaluacionmr == value)
                {
                    return;
                }

                _fechaevaluacionmr = value;
                RaisePropertyChanged(fechaevaluacionmrPropertyName);
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


        #region referenciamr

        public const string referenciamrPropertyName = "referenciamr";

        private string _referenciamr = string.Empty;

        public string referenciamr
        {
            get
            {
                return _referenciamr;
            }

            set
            {
                if (_referenciamr == value)
                {
                    return;
                }

                _referenciamr = value;
                RaisePropertyChanged(referenciamrPropertyName);
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
        public RelayCommand SeleccionProgramaEncargoCommand { get; set; }
        public RelayCommand CancelarProgramaEncargoCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateFechaEvaluacionCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateSupervisionChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateAprobacionCommand { get; set; }


        public RelayCommand referenciarCommand { get; set; }//seleccion desde las plantillas
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }

        public RelayCommand cerrarCommand { get; set; }
        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public CierreEncargoControllerViewModel()
        {
            enviarMensajeInhabilitar();
            finInicializacion = false;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenEnvioController = "datosControllerCierreEncargos";
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            _opcionMenu = 0;
            _codigoContableValido = true;
            Errors = 0;
            _tokenRecepcionPadre = "datosEDCierreEncargos";
            _activarClaseCuenta = false;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadCuentaPadre = Visibility.Collapsed;
            _visibilidadBitacora = Visibility.Collapsed;



            #region contenido

            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            _accesibilidadReferencia = false;
            _accesibilidadCierre = false;
            _accesibilidadSupervision = false;
            _accesibilidadAprobacion = false;
            _accesibilidadEvaluacion = false;

            #endregion
            #region visibilidadContenido

            _visibilidadReferencia = Visibility.Collapsed;
            _visibilidadFechaCierre = Visibility.Collapsed;
            _visibilidadFechaSupervision = Visibility.Collapsed;
            _visibilidadFechaAprobacion = Visibility.Collapsed;
            _visibilidadFechaAprobacion = Visibility.Collapsed;
            _visibilidadFechaEvaluacion = Visibility.Visible;

            #endregion

            #region visibilidad botones inferiores

            _visibilidadReferenciar = Visibility.Collapsed;
            _visibilidadAprobar = Visibility.Collapsed;
            _visibilidadSupervisar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCerrar = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;

            #endregion
            //Suscribiendo el mensaje
            _listaBCEncargos = new ObservableCollection<BalanceModelo>();
            _listaEntidadSeleccion = new ObservableCollection<BalanceModelo>();//Lista para inyectarla en la entidad
            _listaEntidadSeleccionPeriodo = new ObservableCollection<PeriodoModelo>();
            _listaBitacora = new ObservableCollection<BitacoraModelo>();
            _lista = new ObservableCollection<EncargoModelo>();
            _FuenteLlamada = 0;
            _idNivelCuenta = 3;//Se escoge el nivel de cuenta
            Messenger.Default.Register<CierreEncargoMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            _currentEncargo = new EncargoModelo();
            _currentEntidad = new EncargoModelo();
            _currentSistemaContable = new SistemaContableModelo();
            _currentEntidadBitacora = new BitacoraModelo();
            _selectedBCImportar = new BalanceModelo();
            _eleccionBCImportar = new BalanceModelo();
            _fechacierre = new DateTime();
            _fechaevaluacionmr = new DateTime();
            _referenciamr = string.Empty;
            _cambioFechaEvaluacion = false;
        }

        private async void ControlDatosMsj(CierreEncargoMsj datosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            currentSistemaContable = datosMsj.sistemaContableModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            FuenteLlamada = datosMsj.fuenteLlamado;
            //Carga de combo de clase de balance
            //Carga de combo de periodicidad

            currentEntidad = datosMsj.encargoModelo;

            llenadoDatos();
            //Inyeccion de listado de cuentas
            currentEntidad.listaEntidadSeleccion = datosMsj.lista;
            //listaEntidadSeleccion = currentEntidad.listaEntidadSeleccion;
            lista = datosMsj.lista;


            switch (datosMsj.opcionMenuCrud)
            {
                case 1://Crear a partir de  los balances
                       //Se excluye los balances del sistema contable del encargo en uso porque seria redundante
                    listaBCEncargos = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAllForRiesto(currentEncargo.idnitcliente, currentSistemaContable.idsc));
                    //CurrentEncargo es el encargo en uso que da el idsc del sistema contable y ademas proporciona el idnit del cliente para  localizar todos los encargos que tengan ese nit
                    if (listaBCEncargos.Count > 0)
                    {
                        encabezadoPantalla = "Seleccion el balance del encargo a importar";
                        nombreprogramaVista = "Balances disponibles";
                        visibilidadBitacora = Visibility.Collapsed;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadCopiar = Visibility.Visible;//Gestional la presentacion del datagrid
                                                               //Propiedades de presentacion
                        activarCaptura = true;
                        activarCrear = true;
                        activarConsultar = false;
                        activarEditar = false;
                    }
                    else
                    {
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }
                    break;
                case 2://Editar
                    encabezadoPantalla = "Actualice la fecha de evaluación";
                    nombreprogramaVista = "*Edición de  datos";
                    #region contenido

                    accesibilidadCuerpo = true;
                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = false;
                    accesibilidadEvaluacion = true;

                    #endregion

                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Visible;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Collapsed;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Visible;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;

                    #endregion
                    break;
                case 3://Consultar
                    encabezadoPantalla = "Consulta de datos del papel";
                    nombreprogramaVista = "*Consulta de  datos";
                    #region contenido

                    accesibilidadCuerpo = false;
                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = false;
                    accesibilidadEvaluacion = false;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Visible;
                    visibilidadFechaCierre = Visibility.Visible;
                    visibilidadFechaSupervision = Visibility.Visible;
                    visibilidadFechaAprobacion = Visibility.Visible;
                    visibilidadFechaEvaluacion = Visibility.Visible;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCerrar = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;

                    #endregion
                    break;

                case 7://Crear 
                    encabezadoPantalla = "Introduzca los datos para el balance";
                    nombreprogramaVista = "*Nombre de balance";
                    visibilidadBitacora = Visibility.Collapsed;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    //Propiedades de presentacion
                    activarCaptura = true;
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    break;
                case 8://Referenciar 
                    encabezadoPantalla = "Introduzca la referencia para la matriz";
                    nombreprogramaVista = "*Referenciación de documento";
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
                    visibilidadFechaEvaluacion = Visibility.Visible;
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
                    nombreprogramaVista = "*Cierre de documento";
                    #region contenido

                    accesibilidadCuerpo = true;
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
                    nombreprogramaVista = "*Cierre de spervisión del documento";
                    #region contenido

                    accesibilidadCuerpo = true;
                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = true;
                    accesibilidadAprobacion = false;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Visible;
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
                    nombreprogramaVista = "*Cierre de documento";
                    #region contenido

                    accesibilidadCuerpo = true;
                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = true;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Visible;
                    visibilidadFechaSupervision = Visibility.Visible;
                    visibilidadFechaAprobacion = Visibility.Visible;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
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
            Messenger.Default.Unregister<CierreEncargoMsj>(this, tokenRecepcionPadre);
            finComando();
            finInicializacion = true;//Termino la carga se activan los comandos
        }

        private async void llenadoDatos()
        {
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



        public void Guardar()
        {

        }

        private int VerificarClaveCompuesta(EncargoModelo currentEntidad)
        {
            int resultado = 0;
            if (opcionMenu == 1)
            {

                for (int i = 0; i < lista.Count(); i++)
                {
                    if (lista[i].idencargo == currentEntidad.idencargo)
                    {
                        resultado++;
                        i = lista.Count;
                    }
                }
            }
            else
            {
                for (int i = 0; i < lista.Count(); i++)
                {
                    if (lista[i].idencargo == currentEntidad.idencargo)
                    {
                        resultado++;
                    }
                }
            }
            return resultado;
        }

        private async void except3()
        {
            finComando();
            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
        }


        #endregion

        #region Mensajes

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvioController);
        }

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

        #endregion

        #endregion

        #region Metodos de apoyo

        public bool CanSaveNuevo()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = true; // (Errors == 0)
                //&& selectedClaseBalance.idCb != 0
                //&& selectedPeriodo.id != 0;

                return evaluar;
            }
        }
        public bool CanSave()
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

        private bool canImportForEncargos()
        {
            if (eleccionBCImportar != null)
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
            EditarCommand = new RelayCommand(Modificar, CanReferenciarSave);
            //SeleccionProgramaEncargoCommand = new RelayCommand(ImportarCatalogoEncargos, canImportForEncargos);
            GuardarCommand = new RelayCommand(Guardar, CanSaveNuevo);//Caso de nuevo registro
            CancelarCommand = new RelayCommand(Cancelar);
            CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(OkCierre);
            SalirCommand = new RelayCommand(Salir);

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
                return ((!string.IsNullOrEmpty(currentEntidad.usuarioaprobo))
                    || (string.IsNullOrEmpty(currentEntidad.usuarioaprobo)));
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
                evaluar = (Errors == 0) ;
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
                       // resultadoModificar = EncargoModelo.UpdateModificacion(currentEntidad, currentUsuario);
                        break;
                    case 8: //Referenciar
                        //resultadoModificar = EncargoModelo.UpdateReferencia(currentEntidad);
                        break;
                    case 10:
                        resultadoModificar = EncargoModelo.UpdateCierre(currentEntidad, currentUsuario);
                        break;
                    case 11://Supervisar
                        resultadoModificar = EncargoModelo.UpdateSupervision(currentEntidad);
                        break;
                    case 12://Aprobar
                        if (string.IsNullOrEmpty(currentEntidad.usuariosuperviso) || string.IsNullOrWhiteSpace(currentEntidad.usuariosuperviso))
                        {
                            resultadoModificar = EncargoModelo.UpdateAprobacionSupervision(currentEntidad);
                            currentEntidad.usuariosuperviso = currentEntidad.usuarioaprobo;
                            currentEntidad.fechasupervision = currentEntidad.fechaaprobacion;
                        }
                        else
                        {
                            resultadoModificar = EncargoModelo.UpdateAprobacion(currentEntidad);
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


        #endregion

    }
}

//Correccion