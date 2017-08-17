using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Model;
using SGPTWpf.Model.Menus.Herramientas;
using CapaDatos;
using SGPTWpf.Messages.Herramientas;
using System.Windows;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas.Cuestionarios
{
    public sealed class HerramientasCuestionarioControllerCrearViewModel : ViewModeloBase
    {
        #region Propiedades privadas


        private MetroDialogSettings configuracionDialogo;
        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        public MenuHerramientasProgramas detalle = new MenuHerramientasProgramas();//Es generico el view display es cualquier string

        public int fuenteCierre = 0;

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

        #region nombreOriginal
        private string _nombreOriginal;
        private string nombreOriginal
        {
            get { return _nombreOriginal; }
            set { _nombreOriginal = value; }
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

        #region cmd

        private int _cmd;
        private int cmd
        {
            get { return _cmd; }
            set { _cmd = value; }
        }
        #endregion

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

        #region ViewModel Properties : listadoHerramientaModelo

        public const string listadoHerramientaModeloPropertyName = "listadoHerramientaModelo";

        private ObservableCollection<HerramientasModelo> _listadoHerramientaModelo;

        public ObservableCollection<HerramientasModelo> listadoHerramientaModelo
        {
            get
            {
                return _listadoHerramientaModelo;
            }
            set
            {
                if (_listadoHerramientaModelo == value) return;

                _listadoHerramientaModelo = value;

                RaisePropertyChanged(listadoHerramientaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<DetalleHerramientasModelo> _listaDetalleHerramienta;

        public ObservableCollection<DetalleHerramientasModelo> listaDetalleHerramienta
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
                if (_horasPlanHerramienta > 0)
                {
                    currentEntidad.horasPlanHerramienta = _horasPlanHerramienta;
                }
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
                currentEntidadDetalle.descripcionDh = value;
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
                currentEntidad.idTp = _SelectedTipoProgramaModelo.id;
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
                currentEntidad.idTh = _SelectedTipoHerramientaModelo.id;
            }
        }

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

        #region tipoProgramaCuestionario

        public const string tipoProgramaCuestionarioPropertyName = "tipoProgramaCuestionario";

        private string _tipoProgramaCuestionario = string.Empty;

        public string tipoProgramaCuestionario
        {
            get
            {
                return _tipoProgramaCuestionario;
            }

            set
            {
                if (_tipoProgramaCuestionario == value)
                {
                    return;
                }

                _tipoProgramaCuestionario = value;
                RaisePropertyChanged(tipoProgramaCuestionarioPropertyName);
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

        #region visibilidadPrograma

        public const string visibilidadProgramaPropertyName = "visibilidadPrograma";

        private Visibility _visibilidadPrograma = Visibility.Collapsed;

        public Visibility visibilidadPrograma
        {
            get
            {
                return _visibilidadPrograma;
            }

            set
            {
                if (_visibilidadPrograma == value)
                {
                    return;
                }

                _visibilidadPrograma = value;
                RaisePropertyChanged(visibilidadProgramaPropertyName);
            }
        }

        #endregion

        #region visibilidadHoras

        public const string visibilidadHorasPropertyName = "visibilidadHoras";

        private Visibility _visibilidadHoras = Visibility.Visible;

        public Visibility visibilidadHoras
        {
            get
            {
                return _visibilidadHoras;
            }

            set
            {
                if (_visibilidadHoras == value)
                {
                    return;
                }

                _visibilidadHoras = value;
                RaisePropertyChanged(visibilidadHorasPropertyName);
            }
        }

        #endregion

        #region visibilidadConsultar

        public const string visibilidadConsultarPropertyName = "visibilidadConsultar";

        private string _visibilidadConsultar = "Hidden";

        public string visibilidadConsultar
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

        private string _visibilidadEditar = "Hidden";

        public string visibilidadEditar
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

        #region nombreHerramientaVista

        public const string nombreHerramientaVistaPropertyName = "nombreHerramientaVista";

        private string _nombreHerramientaVista = string.Empty;

        public string nombreHerramientaVista
        {
            get
            {
                return _nombreHerramientaVista;
            }

            set
            {
                if (_nombreHerramientaVista == value)
                {
                    return;
                }

                _nombreHerramientaVista = value;
                RaisePropertyChanged(nombreHerramientaVistaPropertyName);
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
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<HerramientasModelo> SelectionChangedCommand { get; set; }


        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public HerramientasCuestionarioControllerCrearViewModel()
        {
            _cmd = 0;
            _opcionMenu = 0;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            Errors = 0;
            _dialogCoordinator = new DialogCoordinator();
            //Suscribiendo el mensaje
            listaPrograma = new ObservableCollection<TipoProgramaModelo>(TipoProgramaModelo.GetAll());
            listaTipoHerramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
            _listadoHerramientaModelo = new ObservableCollection<HerramientasModelo>();
            Messenger.Default.Register<HerramientasToControllerCuestionarioCrearMsj>(this, (herramientasToControllerCuestionarioCrearMsj) => ControlHerramientasToControllerCrearElementoMensajes(herramientasToControllerCuestionarioCrearMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            //enviarMensajeInhabilitar();
            _nombreOriginal = "";
            accesibilidadWindow = false;
        }

        private void ControlHerramientasToControllerCrearElementoMensajes(HerramientasToControllerCuestionarioCrearMsj herramientasModeloElementoMensajes)
        {
                    //Asignacion de  entidades
                    currentUsuario = herramientasModeloElementoMensajes.usuarioValidado;
                    currentEntidad = herramientasModeloElementoMensajes.herramientaModeloElemento;
                    currentEntidadDetalle = herramientasModeloElementoMensajes.detalleHerramientaModelo;
                    opcionMenu = herramientasModeloElementoMensajes.opcionMenu;
                    currentEntidad.listadoHerramientaModelo = herramientasModeloElementoMensajes.listaHerramientas;
                    listadoHerramientaModelo = currentEntidad.listadoHerramientaModelo;
                    cmd = herramientasModeloElementoMensajes.cmd;
            if (herramientasModeloElementoMensajes.cmd == 5)
            {
                nombreOriginal = currentEntidad.nombreHerramienta;//Debe modificar el nombre  al copial
            }
            if (herramientasModeloElementoMensajes.cmd == 1)
            {
                //Seleccion de programa
                currentEntidad.tipoHerramientaModelo = listaTipoHerramienta[1];
                currentEntidad.idTh = listaTipoHerramienta[1].id;
                SelectedTipoHerramientaModelo = listaTipoHerramienta[1];
                encabezadoPantalla = "Introduzca los datos para el cuestionario";
                nombreHerramientaVista = "Ingrese el nombre del cuestionario";
                tipoProgramaCuestionario = "Tipo de cuestionario";
                visibilidadCrear = Visibility.Visible;
                visibilidadCopiar = Visibility.Collapsed;
                visibilidadHoras = Visibility.Visible;
                //Propiedades de presentacion
                currentEntidad.activarCaptura = true;
                activarCaptura = true;
                visibilidadPrograma = Visibility.Visible;
                activarCrear = true;
                activarConsultar = false;
                activarEditar = false;
            }
            else
            {
                //Seleccion de programa
                currentEntidad.tipoHerramientaModelo = listaTipoHerramienta[1];
                currentEntidad.idTh = listaTipoHerramienta[1].id;
                SelectedTipoHerramientaModelo = listaTipoHerramienta[1];
                encabezadoPantalla = "Modifique el nombre  del cuestionario a copiar";
                nombreHerramientaVista = "Modifique el nombre del cuestionario";
                tipoProgramaCuestionario = "Tipo de cuestionario";
                visibilidadHoras = Visibility.Collapsed;
                visibilidadCrear = Visibility.Collapsed;
                visibilidadCopiar = Visibility.Visible;
                //Propiedades de presentacion
                currentEntidad.activarCaptura = true;
                activarCaptura = true;
                visibilidadPrograma = Visibility.Visible;
                activarCrear = true;
                activarConsultar = false;
                activarEditar = false;
            }
            Messenger.Default.Unregister<HerramientasToControllerCuestionarioCrearMsj>(this);
            Mouse.OverrideCursor = null; //Para inicial el proceso
            accesibilidadWindow = true;
            enviarMensajeInhabilitar();
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            //await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            enviarMensaje();
            fuenteCierre = 1;
            CloseWindow();

        }

        private void OkCierre()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            fuenteCierre = 1;
            enviarMensaje();
            CloseWindow();

        }

        private void Salir()
        {
            if (fuenteCierre == 1)
            {
                //Nada ya se cerro la ventana
                enviarMensajeHabilitar();
            }
            else
            {
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                enviarMensaje();
                CloseWindow();
                enviarMensajeHabilitar();
            }
        }

        public async void Guardar()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            if ((currentEntidad.idHerramienta == 0))
                        {
                            if (HerramientasModelo.Insert(currentEntidad, currentUsuario))
                            {
                                currentEntidadDetalle.idHerramienta = currentEntidad.idHerramienta;
                                if (DetalleHerramientasModelo.Insert(currentEntidadDetalle, true))
                                {
                                    var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                    controller.SetIndeterminate();
                                    await TaskEx.Delay(1000);
                                    await controller.CloseAsync();
                                    //await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                                    enviarMensaje(true);//Avisa que se creo un registro
                                    fuenteCierre = 1;
                                    CloseWindow();
                                }
                            }
                            else
                            {
                            accesibilidadWindow = true;
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            }
                        }

        }

        public async void Copiar()
        {

            if (!(HerramientasModelo.FindTexto(currentEntidad.nombreHerramienta)))
            {
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                if (HerramientasModelo.CopiarModelo(currentEntidad, currentUsuario))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    //await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                    enviarMensaje(true);//Avisa que se creo un registro
                    fuenteCierre = 1;
                    CloseWindow();
                }
                else
                {
                    accesibilidadWindow = true;
                    Mouse.OverrideCursor = null;
                    await dlg.ShowMessageAsync(this, "Error al copiar cuestionario", "");
                }
            }
            else
            {
                accesibilidadWindow = true;
                Mouse.OverrideCursor = null; 
                await dlg.ShowMessageAsync(this, "El cuestionario ya existe con ese nombre, debe cambiarlo", "");
            }
        }

        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        private bool ControlVentanaMensaje(CatalogoMensaje controlVentanaMensaje)
        {
            if (controlVentanaMensaje.mensaje == 0)
            {
                //Nuevo();
                return true;
            }
            else
            {
                fuenteCierre = 1;
                CloseWindow();
                return false;

            }
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            VentanaControllerToCuestionarioHerramientasViewMensaje cierre = new VentanaControllerToCuestionarioHerramientasViewMensaje();
            cierre.activarVentana = true;
            cierre.registroCreado = false;
            Messenger.Default.Send(cierre);
        }

        public void enviarMensaje(bool registroCreado)
        {
            //Creando el mensaje de cierre
            VentanaControllerToCuestionarioHerramientasViewMensaje cierre = new VentanaControllerToCuestionarioHerramientasViewMensaje();
            cierre.activarVentana = true;
            cierre.registroCreado = registroCreado;
            Messenger.Default.Send(cierre);
        }

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

        #region Metodos de apoyo

        public bool CanSaveNuevo()
        {
            bool evaluar = false;

            if (currentEntidad == null || currentEntidadDetalle == null)
            {
                 return evaluar;
            }
            else
            {
                    evaluar = (Errors == 0) &&
                              (SelectedTipoProgramaModelo != null);
            }
                return evaluar;
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
                evaluar = (Errors == 0) && nombreOriginal.ToUpper().Trim() != currentEntidad.nombreHerramienta.ToUpper().Trim();
                return evaluar;
            }
        }
        #endregion

        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            CopiarCommand = new RelayCommand(Copiar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSaveNuevo);//Caso de nuevo registro
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(OkCierre);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<HerramientasModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion

    }
}

