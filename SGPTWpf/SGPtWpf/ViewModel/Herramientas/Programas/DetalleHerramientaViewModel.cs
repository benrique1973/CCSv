using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Messages.Herramientas;
using System.Windows;
using SGPTWpf.Messages;
using System.Linq;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.ComponentModel;

namespace SGPTWpf.ViewModel.Herramientas.Programas

{

    public sealed class DetalleHerramientaViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;
        private readonly IDialogCoordinator _dialogCoordinator;
       

        #region opcionMenuCrud

        private int _opcionMenuCrud;
        private int opcionMenuCrud
        {
            get { return _opcionMenuCrud; }
            set { _opcionMenuCrud = value; }
        }

        #endregion

        #region fuenteLlamado

        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }
        #endregion

        #region comando

        private int _comando;
        private int comando
        {
            get { return _comando; }
            set { _comando = value; }
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

        #region tokenRecepcionCierre

        private string _tokenRecepcionCierre;
        private string tokenRecepcionCierre
        {
            get { return _tokenRecepcionCierre; }
            set { _tokenRecepcionCierre = value; }
        }

        #endregion

        #region tokenEnvioDetalle

        private string _tokenEnvioDetalle;
        private string tokenEnvioDetalle
        {
            get { return _tokenEnvioDetalle; }
            set { _tokenEnvioDetalle = value; }
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

        private ObservableCollection<DetalleHerramientasModelo> _Lista;

        public ObservableCollection<DetalleHerramientasModelo> Lista
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

        #region ViewModel Properties : listaHistorica

        public const string listaHistoricaPropertyName = "listaHistorica";

        private ObservableCollection<DetalleHerramientasModelo> _listaHistorica;

        public ObservableCollection<DetalleHerramientasModelo> listaHistorica
        {
            get
            {
                return _listaHistorica;
            }

            set
            {
                if (_listaHistorica == value) return;

                _listaHistorica = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaHistoricaPropertyName);
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
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<DetalleHerramientasModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region HerramientasDetalleMain

        private MainModel _mainModel = null;

        public MainModel HerramientasDetalleMain
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

        #region Lista de entidades

        #region ViewModel Properties : ListaEntidad

        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<HerramientasModelo> _ListaEntidad;

        public ObservableCollection<HerramientasModelo> ListaEntidad
        {
            get
            {
                return _ListaEntidad;
            }
            set
            {
                if (_ListaEntidad == value) return;

                _ListaEntidad = value;

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

        #region ViewModel Properties : listaPrograma

        public const string listaProgramaPropertyName = "listaPrograma";

        private ObservableCollection<TipoProgramaModelo> _listaPrograma;

        public ObservableCollection<TipoProgramaModelo> listaPrograma
        {
            get
            {
                return _listaPrograma;
            }
            set
            {
                if (_listaPrograma == value) return;

                _listaPrograma = value;

                RaisePropertyChanged(listaProgramaPropertyName);
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

        #region ViewModel Properties : listaUsuarioHerramientasAccionModelo

        public const string listaUsuarioHerramientasAccionModeloPropertyName = "listaUsuarioHerramientasAccionModelo";

        private ObservableCollection<UsuarioHerramientasAccionModelo> _listaUsuarioHerramientasAccionModelo;

        public ObservableCollection<UsuarioHerramientasAccionModelo> listaUsuarioHerramientasAccionModelo
        {
            get
            {
                return _listaUsuarioHerramientasAccionModelo;
            }
            set
            {
                if (_listaUsuarioHerramientasAccionModelo == value) return;

                _listaUsuarioHerramientasAccionModelo = value;

                RaisePropertyChanged(listaUsuarioHerramientasAccionModeloPropertyName);
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


        #endregion Lista de entidades

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

        #region ViewModel Property : currentEntidad DetalleHerramientasModelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleHerramientasModelo _currentEntidad;

        public DetalleHerramientasModelo currentEntidad
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

        #region Herramienta Modelo

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

        #region ViewModel Property : currentEntidad HerramientasModelo

        public const string currentHerramientaPropertyName = "currentHerramienta";

        private HerramientasModelo _currentHerramienta;

        public HerramientasModelo currentHerramienta
        {
            get
            {
                return _currentHerramienta;
            }

            set
            {
                if (_currentHerramienta == value) return;

                _currentHerramienta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentHerramientaPropertyName);
            }
        }

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

        private decimal? _ordenDh = 0;

        public decimal? ordenDh
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

        #region horasPlanDh

        public const string horasPlanDhPropertyName = "horasPlanDh";

        private decimal _horasPlanDh = 0;

        public decimal horasPlanDh
        {
            get
            {
                return _horasPlanDh;
            }

            set
            {
                if (_horasPlanDh == value)
                {
                    return;
                }

                _horasPlanDh = value;
                RaisePropertyChanged(horasPlanDhPropertyName);
            }
        }

        #endregion

        #region idDhPrincipalDh

        public const string idDhPrincipalDhPropertyName = "idDhPrincipalDh";

        private int _idDhPrincipalDh = 0;

        public int idDhPrincipalDh
        {
            get
            {
                return _idDhPrincipalDh;
            }

            set
            {
                if (_idDhPrincipalDh == value)
                {
                    return;
                }

                _idDhPrincipalDh = value;
                RaisePropertyChanged(idDhPrincipalDhPropertyName);
                //Seleccion de valor
                currentEntidad.idDhPrincipalDh = _idDhPrincipalDh;
            }
        }

        #endregion

        #region idVisitaDh

        public const string idVisitaDhPropertyName = "idVisitaDh";

        private int _idVisitaDh = 0;

        public int idVisitaDh
        {
            get
            {
                return _idVisitaDh;
            }

            set
            {
                if (_idVisitaDh == value)
                {
                    return;
                }

                _idVisitaDh = value;
                RaisePropertyChanged(idVisitaDhPropertyName);
            }
        }

        #endregion

        #endregion

        #region Usuario herramientas accion modelo

        #region idUha

        public const string idUhaPropertyName = "idUha";

        private int _idUha = 0;

        public int idUha
        {
            get
            {
                return _idUha;
            }

            set
            {
                if (_idUha == value)
                {
                    return;
                }

                _idUha = value;
                RaisePropertyChanged(idUhaPropertyName);
            }
        }

        #endregion

        #region idUsuario

        public const string idUsuarioPropertyName = "idUsuario";

        private int _idUsuario = 0;

        public int idUsuario
        {
            get
            {
                return _idUsuario;
            }

            set
            {
                if (_idUsuario == value)
                {
                    return;
                }

                _idUsuario = value;
                RaisePropertyChanged(idUsuarioPropertyName);
            }
        }

        #endregion

        #region rolUha

        public const string rolUhaPropertyName = "rolUha";

        private string _rolUha = string.Empty;

        public string rolUha
        {
            get
            {
                return _rolUha;
            }

            set
            {
                if (_rolUha == value)
                {
                    return;
                }

                _rolUha = value;
                RaisePropertyChanged(rolUhaPropertyName);
            }
        }

        #endregion

        #region fechaCreadoUha

        public const string fechaCreadoUhaPropertyName = "fechaCreadoUha";

        private DateTime _fechaCreadoUha = DateTime.Now;

        public DateTime fechaCreadoUha
        {
            get
            {
                return _fechaCreadoUha;
            }

            set
            {
                if (_fechaCreadoUha == value)
                {
                    return;
                }

                _fechaCreadoUha = value;
                RaisePropertyChanged(fechaCreadoUhaPropertyName);
            }
        }

        #endregion

        #region estadoUha

        public const string estadoUhaPropertyName = "estadoUha";

        private string _estadoUha = string.Empty;

        public string estadoUha
        {
            get
            {
                return _estadoUha;
            }

            set
            {
                if (_estadoUha == value)
                {
                    return;
                }

                _estadoUha = value;
                RaisePropertyChanged(estadoUhaPropertyName);
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
                //currentEntidad.idTp = _SelectedTipoProgramaModelo.id;
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
                //currentEntidad.idTh = _SelectedTipoHerramientaModelo.id;
            }
        }

        #endregion


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

        public DetalleHerramientaViewModel()
        {
            _fuenteLlamado = 1;//Llamado desde sub-ventana
            _comando = 0;
            _opcionMenuCrud = 2;//Para indicar que es sub-ventana
            _opcionMenuPrincipal = 0; //1 para  programa 2, para cuestionario
            _origenLlamada = "";
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
            _visibilidadMVista = Visibility.Visible;
            _visibilidadMImportar = Visibility.Collapsed;
            _visibilidadMDetalle = Visibility.Collapsed;

            _visibilidadMCerrar = Visibility.Collapsed;
            _visibilidadMSupervisar = Visibility.Collapsed;
            _visibilidadMAprobar = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            #endregion
            _dialogCoordinator = new DialogCoordinator();
            RegisterCommands();
            _tokenEnvioDetalle = "HProgramaDetalle";//Conexion con  Controller Preview
            _tokenRecepcionCierre = "CierrePrevioProgramaSub-ventana";
            _tokenRecepcionVista= "HerramientaProgramaCambioOrden";
            RegisterCommands();
            HerramientasDetalleMain = new MainModel();
            currentUsuario = new UsuarioModelo();
            currentHerramienta = new HerramientasModelo();
            currentHerramienta.idHerramienta = 0;
            currentEntidad = new DetalleHerramientasModelo();
            currentEntidad.idDh = 0;
            accesibilidadWindow = false;
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje de ventana especifico entre la  ventana de crud y la de comandos
            //Messenger.Default.Register<VentanaCrudDetalleHerramienta>(this, (ventanaCrudDetalleHerramienta) => ControlVentanaMensaje(ventanaCrudDetalleHerramienta));
            Messenger.Default.Register<DetalleHerramientaMensaje>(this, (detalleHerramientaMensaje) => ControlDetalleHerramientaMensaje(detalleHerramientaMensaje));
            //Mensaje de ProgramaPresentacioViewModel
            Messenger.Default.Register<ProgramaPreviewDetalleVistaMensaje>(this, (programaPreviewDetalleVistaMensaje) => ControlProgramaPreviewDetalleVistaMensaje(programaPreviewDetalleVistaMensaje));
            //Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
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
                    guardarLista();
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
            currentUsuario = programaPreviewDetalleVistaMensaje.usuarioValidado;
            currentHerramienta = programaPreviewDetalleVistaMensaje.herramientaModelo;
            opcionMenuCrud = programaPreviewDetalleVistaMensaje.opcionMenuCrud;
            if (opcionMenuPrincipal == 3)
            {
                accesibilidadWindow = false;
            }
            else
            {
                accesibilidadWindow = true;
            }
            if (currentHerramienta.idHerramienta == 0)
            {
                Lista = new ObservableCollection<DetalleHerramientasModelo>();
            }
            else
            {
                Lista = new ObservableCollection<DetalleHerramientasModelo>(DetalleHerramientasModelo.GetAll(currentHerramienta.idHerramienta));
            }
            enviarListaAVista();
            Messenger.Default.Unregister<ProgramaPreviewDetalleVistaMensaje>(this);
            Mouse.OverrideCursor = null;
        }


        private async void ControlTabitemMensaje(TabItemMensaje mensaje)
        {
            //Recibe mensaje que cerro Preview Programa
            if (mensaje.mensaje)
            {
                //Para controlar la ventana abierta
                HerramientasDetalleMain.TypeName = null;
                switch (comando)
                {
                    case 1:
                        currentEntidad = null;// No es nula porque se agrega a la lista pero no ha cambiado la ventana
                        if ((HerramientasModelo.UpdateSumaModelo(currentHerramienta)))
                        {
                            horasPlanDh = (decimal)currentHerramienta.horasPlanHerramienta;
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible actualizar la suma de horas", "");
                            horasPlanDh = 0;
                        }
                        ActualizarLista();
                        break;
                    case 2:
                        if ((HerramientasModelo.UpdateSumaModelo(currentHerramienta)))
                        {
                            horasPlanDh = (decimal)currentHerramienta.horasPlanHerramienta;
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible actualizar la suma de horas", "");
                        }
                        ActualizarLista();
                        break;
                    case 3:
                        //activarVentanaConsulta = true;
                        break;
                    case 4:
                        //activarVentanaConsulta = true;
                        break;
                    default:
                        break;
                }
                comando = 0;
                Mouse.OverrideCursor = null;
                accesibilidadWindow = true;
                //Se desuscribe al mensaje
                Messenger.Default.Unregister<TabItemMensaje>(this, tokenRecepcionCierre);

            }
        }

        private void ControlDetalleHerramientaMensaje(DetalleHerramientaMensaje detalleHerramientaMensaje)
        {

                opcionMenuPrincipal = detalleHerramientaMensaje.opcionMenuPrincipal;//1 Para programa, 2 para cuestionario
                currentUsuario = detalleHerramientaMensaje.usuarioValidado;
                currentHerramienta = detalleHerramientaMensaje.herramientaModelo;
                opcionMenuCrud = detalleHerramientaMensaje.opcionMenuCrud;
                if (opcionMenuCrud == 3)//Consulta
                {
                    accesibilidadWindow = false;
                }
                else
                {
                    accesibilidadWindow = true;
                }
                if (currentHerramienta.idHerramienta == 0)
                {
                    Lista = new ObservableCollection<DetalleHerramientasModelo>();
                }
                else
                {
                    Lista = new ObservableCollection<DetalleHerramientasModelo>(DetalleHerramientasModelo.GetAll(currentHerramienta.idHerramienta));
                }
                enviarListaAVista();
                Messenger.Default.Unregister<DetalleHerramientaMensaje>(this);
            Mouse.OverrideCursor = null;//Termina el proceso de carga
        }

        private void enviarListaAVista()
        {


            //Manda la referencia de la vista; Para programas
                HerramientasDetalleListaMensaje listaDetalle = new HerramientasDetalleListaMensaje();
                listaDetalle.listaElementos = Lista;
                Messenger.Default.Send(listaDetalle);
        }

        /*private void ControlHerramientaUsuarioValidadoMensaje(HerramientaUsuarioValidadoMensaje herramientaUsuarioValidadoMensaje)
        {
            currentUsuario = herramientaUsuarioValidadoMensaje.elementoMensaje;
        }*/


        private void ActualizarLista()
        {
            guardarLista();
            try
            {
                if (Lista == null)
                {
                    Lista = new ObservableCollection<DetalleHerramientasModelo>(DetalleHerramientasModelo.GetAll(currentHerramienta.idHerramienta));
                }
                else
                {
                    Lista.Clear();
                    Lista = new ObservableCollection<DetalleHerramientasModelo>(DetalleHerramientasModelo.GetAll(currentHerramienta.idHerramienta));
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
            enviarListaAVista();
        }

        public void guardarLista()
        {
            foreach (DetalleHerramientasModelo item in Lista)
            {
                if (item.guardadoBase == false)
                {
                    DetalleHerramientasModelo.UpdateModeloReodenar(item);
                }
            }
        }

        #endregion

        #region Envio mensajes

        //Caso de nuevo registro 
        public void enviarElemento()
        {
            //Se crea el mensaje
                DetalleHerramientoCrudMensaje elemento = new DetalleHerramientoCrudMensaje();
                elemento.detalleHerramientaElemento = currentEntidad;
                elemento.listaElementos = Lista;
                elemento.comando = comando;
                elemento.tiposHerramienta = currentHerramienta.idTh;//1 Programa 2 cuestionario
                elemento.usuarioValidado = currentUsuario;
                elemento.herramientaModelo = currentHerramienta;
                Messenger.Default.Send(elemento);
        }

        public void enviarElementoVistaPreliminar()
        {
            //Se crea el mensaje
            HModeloDatosMensajes elemento = new HModeloDatosMensajes();
            elemento.usuarioValidado = currentUsuario;
            elemento.detalleHerramientaModelo = null;
            elemento.listaHerramientas = ListaEntidad;
            elemento.opcionMenuPrincipal = opcionMenuPrincipal;
            elemento.opcionMenuCrud = comando;
            elemento.herramientaModeloElemento = currentHerramienta;
            elemento.cmd = fuenteLlamado;
            elemento.listaDetalleHerramienta = Lista;
            Messenger.Default.Send(elemento, tokenEnvioDetalle);
        }
        #endregion

        #region Receptor de mensajes



        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));

            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;

            currentEntidad = new DetalleHerramientasModelo();
            currentEntidad.idUsuario = currentUsuario.idUsuario;
            currentEntidad.descripcionByteaDh = null;
            currentEntidad.idHerramienta = currentHerramienta.idHerramienta;
            currentEntidad.idDhPrincipalDh = null;
            currentEntidad.ordenDh = ordenElementoLista();
            comando = 1;
            HerramientasDetalleMain.TypeName = "DetalleHerrramientaModeloCrearView";
            enviarElemento();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));

                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait; 
                HerramientasDetalleMain.TypeName = "DetalleHerrramientaModeloEditarView";
                    comando = 2;
                    enviarElemento();

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
                Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));

                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                HerramientasDetalleMain.TypeName = "DetalleHerrramientaModeloConsultarView";
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
            if (!(currentEntidad == null))
            {
                Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));

                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                comando = 3;
                        HerramientasDetalleMain.TypeName = "DetalleHerrramientaModeloConsultarView";
                        enviarElemento();

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
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                if (DetalleHerramientasModelo.Delete(currentEntidad.idDh, true))
                        //if (HerramientasModelo.Delete(currentEntidad.id, true))
                        {
                    var controller = await dlg.ShowProgressAsync(this, "Se borro el registro", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    ActualizarLista();
                            currentEntidad = DetalleHerramientasModelo.Clear(currentEntidad);
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                }
                        else
                        {
                    var controller = await dlg.ShowProgressAsync(this, "No ha sido posible eliminar el registro", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
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
            return !(currentEntidad.idHerramienta == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcionDh);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<DetalleHerramientasModelo> listaEntidad)
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
                    return currentEntidad.idDh != 0 ;
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
            NuevoCommand = new RelayCommand(Nuevo);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            BuscarCommand = new RelayCommand(Buscar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            XImprimirCommand = new RelayCommand(XImprimir, CanCommand);
            VistaProgramaCommand = new RelayCommand(VistaPrograma);
            SelectionChangedCommand = new RelayCommand<DetalleHerramientasModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void VistaPrograma()
        {
            Messenger.Default.Register<TabItemMensaje>(this, tokenRecepcionCierre, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            accesibilidadWindow = false;
            if (opcionMenuPrincipal == 1)//1 Para programa 2 para cuestionario
            {
                HerramientasDetalleMain.TypeName = "ProgramaVistaImpresionView";
            }
            else
            {
                HerramientasDetalleMain.TypeName = "HerrramientaModeloVerCuestionarioView";
            }
            comando = 4;
            enviarElementoVistaPreliminar();
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

        public decimal ordenElementoLista()
        {
            if (Lista.Count > 0)
            {
                return (decimal)(int)Lista.Max(j => j.ordenDh) + 1;
            }
            else
            {
                return (decimal)(int)Lista.Count + 1;
            }
        }
        #endregion

    }
}