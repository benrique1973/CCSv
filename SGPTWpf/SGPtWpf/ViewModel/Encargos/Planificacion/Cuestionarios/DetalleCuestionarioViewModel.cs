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
using System.ComponentModel;
using SGPTWpf.Model.Modelo.Encargos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios

{

    public sealed class DetalleCuestionarioViewModel : ViewModeloBase
    {
        #region Propiedades privadas

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

        private DialogCoordinator dlg;


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

        #endregion

        #region Visibilidad de  botones

        private MetroDialogSettings configuracionDialogo;

        #region comando

        private int _comando;
        private int comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        #endregion

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

        #region ViewModel Property : currentEncargo usuario

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

        private Visibility _visibilidadTipoPrograma = Visibility.Collapsed;

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

        private ObservableCollection<DetalleCuestionarioModelo> _listaDetallePrograma;

        public ObservableCollection<DetalleCuestionarioModelo> listaDetallePrograma
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

        private ObservableCollection<DetalleCuestionarioModelo> _listaHistoricaDetallePrograma;

        public ObservableCollection<DetalleCuestionarioModelo> listaHistoricaDetallePrograma
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
        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<DetalleCuestionarioModelo> SelectionChangedCommand { get; set; }

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

        #region ViewModel Properties : listaTipoRespuestaCuestionario

        public const string listaTipoRespuestaCuestionarioPropertyName = "listaTipoRespuestaCuestionario";

        private ObservableCollection<TipoRespuestaCuestionarioModelo> _listaTipoRespuestaCuestionario;

        public ObservableCollection<TipoRespuestaCuestionarioModelo> listaTipoRespuestaCuestionario
        {
            get
            {
                return _listaTipoRespuestaCuestionario;
            }
            set
            {
                if (_listaTipoRespuestaCuestionario == value) return;

                _listaTipoRespuestaCuestionario = value;

                RaisePropertyChanged(listaTipoRespuestaCuestionarioPropertyName);
            }
        }

        #endregion

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

        #endregion

        #region ViewModel Property : currentDetallePrograma DetalleCuestionarioModelo

        public const string currentDetalleProgramaPropertyName = "currentDetallePrograma";

        private DetalleCuestionarioModelo _currentDetallePrograma;

        public DetalleCuestionarioModelo currentDetallePrograma
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

        #region ViewModel Public Methods

        #region Constructores

        public DetalleCuestionarioViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;
            _menuElegido = "Planificacion";
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
            _visibilidadMVista = Visibility.Visible;
            _visibilidadMImportar = Visibility.Collapsed;
            _visibilidadMDetalle = Visibility.Collapsed;

            _visibilidadMCerrar = Visibility.Collapsed;
            _visibilidadMSupervisar = Visibility.Collapsed;
            _visibilidadMAprobar = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            #endregion
            _tokenRecepcionCierre = "CierreEncargoPlanCuestionarioSub-ventana"; //Modificado

            _opcionMenuCrud = 0;
            _opcionMenuPrincipal =2; //1 para  programa 1, 2 para cuestionario
            _comando = 0;
            _tokenRecepcionDatosPadre = "datosCuestionarioDetalle";//Modificado
            _tokenEnvioVista = "listaDetalleCuestionarioVista";//Modificado
            _tokenEnvioProgramas = "EncargoPlanCuestionarioAuditoriaDetalle";//Modificado
            _tokenEnvioDetallePrograma = "DatosParaCuestionarioDetalle";
            _tokenRecepcionVista = "EncargoPlanificacionCuestionarioCambioOrden";
            _accesibilidadWindow = true;
            _tokenHabilitarVentanaPadre = "HabilitarVentanaPadreEncargoPlanEdicionCuestionario"; 
            RegisterCommands();
            EncargoPlanProgramaDetalleMain = new MainModel();
            currentUsuario = new UsuarioModelo();
            currentPrograma = new ProgramaModelo();
            currentDetallePrograma = new DetalleCuestionarioModelo();
            currentEncargo = new EncargoModelo();
            accesibilidadWindow = false;
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje de ventana especifico entre la  ventana de crud y la de comandos

            Messenger.Default.Register<DetalleEncargoPlanProgramaMsj>(this, tokenRecepcionDatosPadre, (detalleEncargoPlanProgramaMsj) => ControlDetalleEncargoPlanProgramaMsj(detalleEncargoPlanProgramaMsj));

            Messenger.Default.Register<bool>(this, tokenRecepcionVista, (recepcionDatos) => ControlCambioLista(recepcionDatos));
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
                listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>();
            }
            else
            {
                listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>(DetalleCuestionarioModelo.GetAll(currentPrograma.idprograma,currentEncargo.idencargo));
            }
            enviarlistaDetalleProgramaAVista();
            Messenger.Default.Unregister<ProgramaPreviewDetalleVistaMensaje>(this);
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
            opcionMenuPrincipal = detalleHerramientaMensaje.opcionMenuPrincipal;//1 Para programa, 2 para cuestionario
            currentUsuario = detalleHerramientaMensaje.usuarioModelo;
            currentPrograma = detalleHerramientaMensaje.programaModelo;
            currentEncargo = detalleHerramientaMensaje.currentEncargo;
            opcionMenuCrud = detalleHerramientaMensaje.opcionMenuCrud;
            if (opcionMenuCrud == 3)
            {
                accesibilidadWindow = false;
            }
            else
            {
                accesibilidadWindow = true;
            }
            try
            {
                if (currentPrograma.idprograma == 0)
                {
                    listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>();
                }
                else
                {
                    listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>(DetalleCuestionarioModelo.GetAll(currentPrograma.idprograma, currentEncargo.idencargo));
                }
                enviarlistaDetalleProgramaAVista();
                Messenger.Default.Unregister<DetalleEncargoPlanProgramaMsj>(this, tokenRecepcionDatosPadre);
                finComando();
            }
            catch (Exception e)
            {
                listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>();
                MessageBox.Show("Error en recuperación del detalle\nElimine el cuestionario\n" + e.ToString());
                enviarlistaDetalleProgramaAVista();
                Messenger.Default.Unregister<DetalleEncargoPlanProgramaMsj>(this, tokenRecepcionDatosPadre);
                finComando();
            }
        }

        private void enviarlistaDetalleProgramaAVista()
        {
            //Manda la referencia de la vista; Para programas
            EncargosPlanProgramasDetalleListaMsj listaDetalle = new EncargosPlanProgramasDetalleListaMsj();
            listaDetalle.listaElementosCuestionario = listaDetallePrograma;
            Messenger.Default.Send(listaDetalle, tokenEnvioVista);
        }

        private void ActualizarlistaDetallePrograma()
        {
            guardarlistaDetallePrograma();
            try
            {
                if (listaDetallePrograma == null)
                {
                    listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>(DetalleCuestionarioModelo.GetAll(currentPrograma.idprograma,currentEncargo.idencargo));
                }
                else
                {
                    listaDetallePrograma.Clear();
                    listaDetallePrograma = new ObservableCollection<DetalleCuestionarioModelo>(DetalleCuestionarioModelo.GetAll(currentPrograma.idprograma,currentEncargo.idencargo));
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                }
            }
            //Se manda a la vista actualizada
            enviarlistaDetalleProgramaAVista();
        }

        public void guardarlistaDetallePrograma()
        {
            foreach (DetalleCuestionarioModelo item in listaDetallePrograma)
            {
                if (item.guardadoBase == false)
                {
                    DetalleCuestionarioModelo.UpdateModeloReodenar(item);
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
            elemento.detalleHerramientaCuestionarioElemento = currentDetallePrograma;
            elemento.listaElementosCuestionario = listaDetallePrograma;
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
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = null;
            elemento.opcionTipoPrograma = 2;//Por ser un programa ad-hoc
            elemento.opcionMenuCrud = opcionMenuCrud;
            elemento.fuenteLlamado = 2;//Se esta llamando desde la sub-ventana
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            elemento.listaDetalleHerramientaC = listaDetallePrograma;
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
            currentDetallePrograma = new DetalleCuestionarioModelo(currentPrograma.idprograma, currentUsuario);
            //currentDetallePrograma.ordendp = ordenElementolistaDetallePrograma();
            comando = 1;
            EncargoPlanProgramaDetalleMain.TypeName = "DetalleCuestionarioModeloCrearView";
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
                    EncargoPlanProgramaDetalleMain.TypeName = "DetalleCuestionarioModeloEditarView";
                    comando = 2;
                    enviarElemento();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "La pregunta esta ya en proceso, no puede modificarse", "Puede realizar consulta únicamente");
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
                EncargoPlanProgramaDetalleMain.TypeName = "DetalleCuestionarioModeloConsultarView";
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
                EncargoPlanProgramaDetalleMain.TypeName = "DetalleCuestionarioModeloConsultarView";
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

                    if (DetalleCuestionarioModelo.Delete(currentDetallePrograma.iddp, true))
                    //if (HerramientasModelo.Delete(currentDetallePrograma.id, true))
                    {
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        ActualizarlistaDetallePrograma();
                        currentDetallePrograma = new DetalleCuestionarioModelo();

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
                    await dlg.ShowMessageAsync(this, "La pregunta esta ya en proceso, no puede modificarse", "Puede realizar consulta únicamente");
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

                if (DetalleCuestionarioModelo.DeleteBorradoLogico(currentDetallePrograma.iddp, true))
                //if (HerramientasModelo.Delete(currentDetallePrograma.id, true))
                {
                    await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                    ActualizarlistaDetallePrograma();
                    currentDetallePrograma = new DetalleCuestionarioModelo();

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
                    await dlg.ShowMessageAsync(this, "La pregunta esta ya en proceso, no puede modificarse", "Puede realizar consulta únicamente");
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

        public void Actualizar(ObservableCollection<DetalleCuestionarioModelo> listaEntidad)
        {
            listaDetallePrograma = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentDetallePrograma != null;
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
            SelectionChangedCommand = new RelayCommand<DetalleCuestionarioModelo>(entidad =>
            {
                if (entidad == null) return;
                currentDetallePrograma = entidad;
            });
        }

        private void VistaPrograma()
        {
            iniciarComando();
            enviarMensajeInhabilitar();
            comando = 5;
            //accesibilidadWindow = false;
               EncargoPlanProgramaDetalleMain.TypeName = "CuestionarioVistaImpresionView";
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

    }
}