using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using System.Windows.Input;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Linq;
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Resumen
{

    public sealed class ResumenSumariasViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
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

        #region FuenteLlamada

        private int _FuenteLlamada;
        private int FuenteLlamada
        {
            get { return _FuenteLlamada; }
            set { _FuenteLlamada = value; }
        }

        #endregion

        #region tokenRecepcionHijo

        private string _tokenRecepcionHijo;
        private string tokenRecepcionHijo
        {
            get { return _tokenRecepcionHijo; }
            set { _tokenRecepcionHijo = value; }
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

        #region origenLlamada //Sirve para diferenciar las fuentas de  la llamada para las vistas
        //0 Sin identificar
        //1 Plan Indices
        //2 Plan Indices detalle
        //3 Documentacion indice
        //4 Documentacion detalle indice

        private int _origenLlamada;
        private int origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion


        #region fuenteLlamada

        private string _fuenteLlamada;
        private string fuenteLlamada
        {
            get { return _fuenteLlamada; }
            set { _fuenteLlamada = value; }
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

        private DialogCoordinator dlg;


        #endregion

        #region tokenEnvioDatosAHijo

        private string _tokenEnvioDatosAHijo;
        private string tokenEnvioDatosAHijo
        {
            get { return _tokenEnvioDatosAHijo; }
            set { _tokenEnvioDatosAHijo = value; }
        }

        #endregion

        #region tokenEnvioDatosAMenu

        private string _tokenEnvioDatosAMenu;
        private string tokenEnvioDatosAMenu
        {
            get { return _tokenEnvioDatosAMenu; }
            set { _tokenEnvioDatosAMenu = value; }
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

        #region tokenReferenciaVista

        private string _tokenReferenciaVista;
        private string tokenReferenciaVista
        {
            get { return _tokenReferenciaVista; }
            set { _tokenReferenciaVista = value; }
        }

        #endregion

        #region tokenEnvioDatosAVistaPreview

        private string _tokenEnvioDatosAVistaPreview;
        private string tokenEnvioDatosAVistaPreview
        {
            get { return _tokenEnvioDatosAVistaPreview; }
            set { _tokenEnvioDatosAVistaPreview = value; }
        }

        #endregion

        #region tokenRespuestaReferenciaVista

        private string _tokenRespuestaReferenciaVista;
        private string tokenRespuestaReferenciaVista
        {
            get { return _tokenRespuestaReferenciaVista; }
            set { _tokenRespuestaReferenciaVista = value; }
        }

        #endregion


        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<CedulaModelo> _SelectedItems;

        public ObservableCollection<CedulaModelo> SelectedItems
        {
            get
            {
                return _SelectedItems;
            }
            set
            {
                if (_SelectedItems == value) return;

                _SelectedItems = value;

                RaisePropertyChanged(SelectedItemsPropertyName);
            }
        }

        #endregion

        //http://stackoverflow.com/questions/14918602/isselected-binding-in-wpf-datagrid

        #region ViewModel Properties : fechaBalanceAnterior

        public const string fechaBalanceAnteriorPropertyName = "fechaBalanceAnterior";

        private string _fechaBalanceAnterior;

        public string fechaBalanceAnterior
        {
            get
            {
                return _fechaBalanceAnterior;
            }

            set
            {
                if (_fechaBalanceAnterior == value)
                {
                    return;
                }

                _fechaBalanceAnterior = value;
                RaisePropertyChanged(fechaBalanceAnteriorPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : fechaBalanceActual

        public const string fechaBalanceActualPropertyName = "fechaBalanceActual";

        private string _fechaBalanceActual;

        public string fechaBalanceActual
        {
            get
            {
                return _fechaBalanceActual;
            }

            set
            {
                if (_fechaBalanceActual == value)
                {
                    return;
                }

                _fechaBalanceActual = value;
                RaisePropertyChanged(fechaBalanceActualPropertyName);
            }
        }

        #endregion


        #region idtc //Sirve para diferenciar las fuentas de  la llamada para las vistas

        private int _idtc;
        private int idtc
        {
            get { return _idtc; }
            set { _idtc = value; }
        }

        #endregion

        #region ViewModel Properties : IsSelected

        public const string IsSelectedPropertyName = "IsSelected";

        private bool _IsSelected;

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }

            set
            {
                if (_IsSelected == value)
                {
                    return;
                }

                _IsSelected = value;
                RaisePropertyChanged(IsSelectedPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : permitirArrastrar

        public const string permitirArrastrarPropertyName = "permitirArrastrar";

        private bool _permitirArrastrar;

        public bool permitirArrastrar
        {
            get
            {
                return _permitirArrastrar;
            }

            set
            {
                if (_permitirArrastrar == value)
                {
                    return;
                }

                _permitirArrastrar = value;
                RaisePropertyChanged(permitirArrastrarPropertyName);
            }
        }

        #endregion


        #region ViewModel Property : currentMaestro Carpeta Modelo

        public const string currentMaestroPropertyName = "currentMaestro";

        private CedulaModelo _currentMaestro;

        public CedulaModelo currentMaestro
        {
            get
            {
                return _currentMaestro;
            }

            set
            {
                if (_currentMaestro == value) return;

                _currentMaestro = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentMaestroPropertyName);
            }
        }

        #endregion

        #region Propiedades : Descripcion Tipo Carpeta Modelo


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

        #endregion

        #region ViewModel Properties publicas

        #region encabezadoPrograma

        public const string encabezadoProgramaPropertyName = "encabezadoPrograma";

        private string _encabezadoPrograma = string.Empty;

        public string encabezadoPrograma
        {
            get
            {
                return _encabezadoPrograma;
            }

            set
            {
                if (_encabezadoPrograma == value)
                {
                    return;
                }

                _encabezadoPrograma = value;
                RaisePropertyChanged(encabezadoProgramaPropertyName);
            }
        }

        #endregion

        #region visibilidadTipoPrograma

        public const string visibilidadTipoProgramaPropertyName = "visibilidadTipoPrograma";

        private Visibility _visibilidadTipoPrograma = Visibility.Visible;

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

        #region ViewModel Properties : listaVistas

        public const string listaVistasPropertyName = "listaVistas";

        private ObservableCollection<menuBalanceDetalle> _listaVistas;

        public ObservableCollection<menuBalanceDetalle> listaVistas
        {
            get
            {
                return _listaVistas;
            }

            set
            {
                if (_listaVistas == value) return;

                _listaVistas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaVistasPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<CedulaModelo> _lista;

        public ObservableCollection<CedulaModelo> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetalles

        public const string listaDetallesPropertyName = "listaDetalles";

        private ObservableCollection<BitacoraModelo> _listaDetalles;

        public ObservableCollection<BitacoraModelo> listaDetalles
        {
            get
            {
                return _listaDetalles;
            }

            set
            {
                if (_listaDetalles == value) return;

                _listaDetalles = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDetallesPropertyName);
            }
        }

        #endregion

        #region Entidades

        #region ViewModel Property : currentEntidad Detalle Balance

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

        #region descripcioncb Clase balance

        public const string descripcioncbPropertyName = "descripcioncb";

        private string _descripcioncb = string.Empty;

        public string descripcioncb
        {
            get
            {
                return _descripcioncb;
            }

            set
            {
                if (_descripcioncb == value)
                {
                    return;
                }

                _descripcioncb = value;
                RaisePropertyChanged(descripcioncbPropertyName);
            }
        }


        #endregion

        #region codigoBuscado Clase detalleBalance

        public const string codigoBuscadoPropertyName = "codigoBuscado";

        private string _codigoBuscado = string.Empty;

        public string codigoBuscado
        {
            get
            {
                return _codigoBuscado;
            }

            set
            {
                if (_codigoBuscado == value)
                {
                    return;
                }

                _codigoBuscado = value;
                RaisePropertyChanged(codigoBuscadoPropertyName);
            }
        }


        #endregion


        #endregion

        #region Propiedades Catalogo Contale

        #region idCorrelativo

        public const string idCorrelativoPropertyName = "idCorrelativo";

        private int _idCorrelativo = 0;

        public int idCorrelativo
        {
            get
            {
                return _idCorrelativo;
            }

            set
            {
                if (_idCorrelativo == value)
                {
                    return;
                }

                _idCorrelativo = value;
                RaisePropertyChanged(idCorrelativoPropertyName);
            }
        }

        #endregion

        #region idcc

        public const string idccPropertyName = "idcc";

        private int _idcc = 0;

        public int idcc
        {
            get
            {
                return _idcc;
            }

            set
            {
                if (_idcc == value)
                {
                    return;
                }

                _idcc = value;
                RaisePropertyChanged(idccPropertyName);
            }
        }

        #endregion

        #region idelementos

        public const string idelementosPropertyName = "idelementos";

        private int _idelementos = 0;

        public int idelementos
        {
            get
            {
                return _idelementos;
            }

            set
            {
                if (_idelementos == value)
                {
                    return;
                }

                _idelementos = value;
                RaisePropertyChanged(idelementosPropertyName);
            }
        }

        #endregion

        #region idsc

        public const string idscPropertyName = "idsc";

        private int _idsc = 0;

        public int idsc
        {
            get
            {
                return _idsc;
            }

            set
            {
                if (_idsc == value)
                {
                    return;
                }

                _idsc = value;
                RaisePropertyChanged(idscPropertyName);
            }
        }

        #endregion


        #region catidcc

        public const string catidccPropertyName = "catidcc";

        private int _catidcc = 0;

        public int catidcc
        {
            get
            {
                return _catidcc;
            }

            set
            {
                if (_catidcc == value)
                {
                    return;
                }

                _catidcc = value;
                RaisePropertyChanged(catidccPropertyName);
            }
        }

        #endregion

        #region idccuentas

        public const string idccuentasPropertyName = "idccuentas";

        private int _idccuentas = 0;

        public int idccuentas
        {
            get
            {
                return _idccuentas;
            }

            set
            {
                if (_idccuentas == value)
                {
                    return;
                }

                _idccuentas = value;
                RaisePropertyChanged(idccuentasPropertyName);
            }
        }

        #endregion


        #region codigocc

        public const string usuarioModificoPropertyName = "codigocc";

        private string _usuarioModifico = string.Empty;

        public string codigocc
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

        #region codigoContablePadre
        public string codigoContablePadre
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

        #region descripcioncc

        public const string nombreHerramientaPropertyName = "descripcioncc";

        private string _nombreHerramienta = string.Empty;

        public string descripcioncc
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

        #region tiposaldocc

        public const string autorizadoPorHerramientaPropertyName = "tiposaldocc";

        private string _autorizadoPorHerramienta = string.Empty;

        public string tiposaldocc
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

        #region fechacreacioncc

        public const string fechacreadoherramientaPropertyName = "fechacreacioncc";

        private DateTime _fechacreadoherramienta = DateTime.Now;

        public DateTime fechacreacioncc
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


        #region ordencc

        public const string ordenccPropertyName = "ordencc";

        private decimal _ordencc = 0;

        public decimal ordencc
        {
            get
            {
                return _ordencc;
            }

            set
            {
                if (_ordencc == value)
                {
                    return;
                }

                _ordencc = value;
                RaisePropertyChanged(ordenccPropertyName);
            }
        }

        #endregion

        #region estadocc

        public const string estadoccPropertyName = "estadocc";

        private string _estadocc = string.Empty;

        public string estadocc
        {
            get
            {
                return _estadocc;
            }

            set
            {
                if (_estadocc == value)
                {
                    return;
                }

                _estadocc = value;
                RaisePropertyChanged(estadoccPropertyName);
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

        #region Properties : cursorWindow

        public const string cursorWindowPropertyName = "cursorWindow";

        private Cursor _cursorWindow;

        public Cursor cursorWindow
        {
            get
            {
                return _cursorWindow;
            }

            set
            {
                if (_cursorWindow == value)
                {
                    return;
                }

                _cursorWindow = value;
                RaisePropertyChanged(cursorWindowPropertyName);
            }
        }

        #endregion


        #endregion

        #region visibilidadMenu

        #region visibilidadMCrear

        public const string visibilidadMCrearPropertyName = "visibilidadMCrear";

        private Visibility _visibilidadMCrear = Visibility.Hidden;

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

        private Visibility _visibilidadMEditar = Visibility.Hidden;

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

        #region visibilidadMBorrar

        public const string visibilidadMBorrarPropertyName = "visibilidadMBorrar";

        private Visibility _visibilidadMBorrar = Visibility.Hidden;

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

        private Visibility _visibilidadMConsulta = Visibility.Hidden;

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

        #region visibilidadMReferenciar

        public const string visibilidadMReferenciarPropertyName = "visibilidadMReferenciar";

        private Visibility _visibilidadMReferenciar = Visibility.Hidden;

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

        #region visibilidadMVista

        public const string visibilidadMVistaPropertyName = "visibilidadMVista";

        private Visibility _visibilidadMVista = Visibility.Hidden;

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

        #endregion

        #region visibilidadBalanceAnterior

        public const string visibilidadBalanceAnteriorPropertyName = "visibilidadBalanceAnterior";

        private Visibility _visibilidadBalanceAnterior = Visibility.Hidden;

        public Visibility visibilidadBalanceAnterior
        {
            get
            {
                return _visibilidadBalanceAnterior;
            }

            set
            {
                if (_visibilidadBalanceAnterior == value)
                {
                    return;
                }

                _visibilidadBalanceAnterior = value;
                RaisePropertyChanged(visibilidadBalanceAnteriorPropertyName);
            }
        }

        #endregion


        #region ViewModel Commands
        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand vistaPreviaReferenciaCommand { get; set; }
        public RelayCommand<CedulaModelo> SelectionChangedCommand { get; set; }
        public RelayCommand irMenuPadreCommand { get; set; }

        public RelayCommand referenciarCommand { get; set; }

        #endregion

        #region EDDetalleIMainModel

        private MainModel _mainModel = null;

        public MainModel EDDetalleIMainModel
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

        public int NumberOfItemsSelected { get; private set; }

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

        #region ViewModel Public Methods

        #region Constructores


        public ResumenSumariasViewModel()
        {

        }

        public ResumenSumariasViewModel(string origen)
        {
            _fuenteLlamada = origen;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar

            _accesibilidadWindow = false;
            _IsSelected = false;
            _cursorWindow = Cursors.Hand;
            _opcionMenu = 0;
            _descripcioncb = string.Empty;
            _tokenEnvioDatosAVistaPreview = "LlamadaDeDetalle";
            switch (origen)
            {
                case "cedulasResumenSumariasDetalle":
                    _idtc = 1;//Sumarias
                    #region configuracion
                    #region  menu

                    visibilidadMCrear = Visibility.Collapsed;
                    visibilidadMEditar = Visibility.Collapsed;
                    visibilidadMBorrar = Visibility.Collapsed;
                    visibilidadMConsulta = Visibility.Collapsed;
                    visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    visibilidadMRegresar = Visibility.Visible;
                    visibilidadMVista = Visibility.Visible;
                    visibilidadMImprimir = Visibility.Collapsed;

                    #endregion

                    #region token 
                    _permitirArrastrar = true;//Permite al usuario arrastrar
                    _tokenRecepcionPadre = "datosEncargoCedulasSumarias";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosEncargoCedulasSumariasDetalle";  //Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosControllerEncargoCedulasSumariasDetalle";
                    _tokenEnvioDatosAMenu = "PlanDetalleIndiceRegreso"; //Para regresar al menu anterior.
                    _tokenReferenciaVista = "datosControllerEncargoCedulasSumariasDetalleReferenciaVista";
                    _tokenRecepcionVista = "datosControllerEncargoCedulasSumariasDetalleCambioOrden";

                    _tokenEnvioVista = "datosControllerEncargoCedulasSumariasDetalleDatosVista";
                    _tokenRespuestaReferenciaVista = "RespuestaDatosControllerEncargoCedulasSumariasDetalleReferenciaVista";
                    #endregion
                    _FuenteLlamada = 0;
                    RegisterCommands();
                    _origenLlamada = 2;
                    #endregion
                    break;
                case "EncargoDocumentacionIndiceDetalle":
                    #region configuracion
                    #region  menu

                    visibilidadMCrear = Visibility.Collapsed;
                    visibilidadMEditar = Visibility.Collapsed;
                    visibilidadMBorrar = Visibility.Collapsed;
                    visibilidadMConsulta = Visibility.Visible;
                    visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    visibilidadMRegresar = Visibility.Visible;
                    visibilidadMVista = Visibility.Visible;
                    visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                    _permitirArrastrar = false;//Permite al usuario arrastrar
                    #region tokens

                    _tokenRecepcionPadre = "datosEncargoDocumentacionIndices";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerDetalleIndices";
                    _tokenEnvioDatosAMenu = "DocumentacionDetalleIndiceRegreso"; //Para regresar al menu anterior.
                    _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices;
                    _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";
                    _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";
                    _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";

                    #endregion
                    _FuenteLlamada = 0;
                    RegisterCommands();
                    _origenLlamada = 2;
                    #endregion
                    break;
                case "EncargoCierreIndiceDetalle":
                    #region configuracion
                    #region  menu

                    visibilidadMCrear = Visibility.Collapsed;
                    visibilidadMEditar = Visibility.Collapsed;
                    visibilidadMBorrar = Visibility.Collapsed;
                    visibilidadMConsulta = Visibility.Collapsed;
                    visibilidadMReferenciar = Visibility.Collapsed; //Pendiente
                    visibilidadMRegresar = Visibility.Collapsed;
                    visibilidadMVista = Visibility.Visible;
                    visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                    _permitirArrastrar = false;//Permite al usuario arrastrar
                    #region token
                    _tokenRecepcionPadre = "datosEncargoCierreIndices";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerDetalleIndices";
                    _tokenEnvioDatosAMenu = "CierreDetalleIndiceRegreso";  //Para regresar al menu anterior.
                    _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices
                    _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";//Transmite a  la vista 
                    _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";//Transmite a  la vista
                    _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                    #endregion
                    _opcionMenu = 0;
                    _FuenteLlamada = 0;
                    RegisterCommands();
                    _origenLlamada = 2;
                    #endregion
                    break;
                case "DocumentosConsultaIndiceDetalle":
                    #region configuracion
                    #region  menu

                    visibilidadMCrear = Visibility.Collapsed;
                    visibilidadMEditar = Visibility.Collapsed;
                    visibilidadMBorrar = Visibility.Collapsed;
                    visibilidadMConsulta = Visibility.Collapsed;
                    visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    visibilidadMRegresar = Visibility.Collapsed;
                    visibilidadMVista = Visibility.Collapsed;
                    visibilidadMImprimir = Visibility.Visible;
                    #endregion
                    _permitirArrastrar = false;//Permite al usuario arrastrar
                    #region token
                    _tokenRecepcionPadre = "datosDocumentosConsultaIndices";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerDetalleIndices";
                    _tokenEnvioDatosAMenu = "DocumentosConsultaDetalleIndiceRegreso";  //Para regresar al menu anterior.
                    _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices
                    _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";//Transmite a  la vista 
                    _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";//Transmite a  la vista
                    _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                    #endregion
                    _opcionMenu = 0;
                    _FuenteLlamada = 0;
                    _origenLlamada = 2;
                    #endregion
                    break;
                case "DocumentosImpresionIndiceDetalle":
                    #region configuracion
                    #region  menu

                    visibilidadMCrear = Visibility.Collapsed;
                    visibilidadMEditar = Visibility.Collapsed;
                    visibilidadMBorrar = Visibility.Collapsed;
                    visibilidadMConsulta = Visibility.Collapsed;
                    visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    visibilidadMRegresar = Visibility.Collapsed;
                    visibilidadMVista = Visibility.Collapsed;
                    visibilidadMImprimir = Visibility.Visible;
                    #endregion
                    _permitirArrastrar = false;//Permite al usuario arrastrar
                    #region token
                    _tokenRecepcionPadre = "datosDocumentosImpresionIndices";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerDetalleIndices";
                    _tokenEnvioDatosAMenu = "DocumentosImpresionDetalleIndiceRegreso";  //Para regresar al menu anterior.
                    _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices
                    _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";//Transmite a  la vista 
                    _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";//Transmite a  la vista
                    _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                    #endregion
                    _opcionMenu = 0;
                    _FuenteLlamada = 0;
                    RegisterCommands();
                    _origenLlamada = 2;
                    #endregion
                    break;

            }
            Messenger.Default.Register<CedulaMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlRecepcionDatos(datosMsj));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            _comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<CedulaModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            EDDetalleIMainModel = new MainModel();
            _visibilidadBalanceAnterior = Visibility.Visible;
            _fechaBalanceActual = string.Empty;
            _fechaBalanceAnterior = string.Empty;
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
                    guardarlista();
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    //Nada se deja la lista actualizada;
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }

        private void ControlRecepcionDatos(CedulaMsj msj)
        {
            currentEncargo = msj.encargoModelo;//Encargo en uso actual
            currentUsuario = msj.usuarioModelo;
            //currentSistemaContable = msj.sistemaContableModelo;
            currentMaestro = msj.entidadMaestroModelo;
            opcionMenu = msj.opcionMenuCrud;
            FuenteLlamada = msj.fuenteLlamado;
            tokenEnvioDatosAMenu = msj.tokenRecepcionSubMenuDetalle;
            actualizarLista();
            if (lista.Count(x => x.idbalanceanterior != null && x.idbalanceanterior != 0) > 0)
            {
                visibilidadBalanceAnterior = Visibility.Visible;
            }
            else
            {
                visibilidadBalanceAnterior = Visibility.Collapsed;
            }

            //No se desuscribe porque continua existiendo
            //Messenger.Default.Unregister<CedulaMsj>(this, tokenRecepcionPadre);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
            Messenger.Default.Unregister<CedulaMsj>(this, tokenRecepcionPadre);
            if (currentMaestro.fechabalancebalance != null)
            {
                fechaBalanceActual = currentMaestro.fechabalancebalance;
            }
            if (currentMaestro.fechabalancebalanceComparativo != null)
            {
                fechaBalanceAnterior = currentMaestro.fechabalancebalanceComparativo;
            }
        }


        private void actualizarLista()
        {
            guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, idtc));
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista ", "" + e);

                }
            }
            //Se manda a la vista actualizada
            enviarlistaDetalleVista();
        }

        private void enviarlistaDetalleVista()
        {
            //Manda la referencia de la vista; Para programas
            Messenger.Default.Send(lista, tokenEnvioVista);
        }

        public void guardarlista()
        {
            try
            {
                if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                {

                    foreach (CedulaModelo item in lista)
                    {
                        if (item.guardadoBase == false)
                        {
                            //CedulaModelo.UpdateModeloReodenar(item);
                            item.guardadoBase = true;//Se actualizo el registro
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Mensaje de error
            }
        }

        #endregion

        #region Envio mensajes


        //Caso de nuevo registro 
        public void enviarMensaje()
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentMaestro;//Para el caso de  edicion de programas
                                                           //elemento.listaTipoCarpetaModel =;
            //elemento.listaDetalle = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.fuenteLlamado = origenLlamada; //no se utiliza
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        public void enviarMensajeCrud()
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.entidadDetalle = currentEntidad;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentMaestro;//Para el caso de  edicion de programas
                                                           //elemento.listaTipoCarpetaModel =;
            //elemento.listaDetalle = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.fuenteLlamado = origenLlamada; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EDDetalleIMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 2:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    //caso de vista de programa
                    break;
                case 5://Programa vista
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    accesibilidadWindow = true;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 7:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                case 8:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                case 12://Vista referencia
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        //actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                default:
                    break;
            }
            //comando = 0;
            currentEntidad = null;
            finComando();
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            //Para guardar lo que esta en la  pantalla
            //No se utiliza debido a que no existe edicion
            //ControlCambioLista(true);
            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad = new CedulaModelo(currentMaestro, currentEncargo, currentUsuario);
            if (lista.Count > 0)
            {
                //currentEntidad.ordendc = lista.Max(x => x.ordendc) + 10;
            }
            else
            {
                //currentEntidad.ordendc = 10;
            }
            //currentEntidad.balanceModelo = currentMaestro;
            EDDetalleIMainModel.TypeName = "DetalleCedulaModeloCrearview";
            #endregion

            activarCaptura = true;
            enviarMensajeCrud();
        }
        #endregion
        public async void Editar()
        {
            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 2;
                    EDDetalleIMainModel.TypeName = "DetalleCedulaModeloEditarview";
                    //currentEntidad.usuarioModelo = currentUsuario;
                    enviarMensajeCrud();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para editar", "");
            }
        }
        public async void Consultar()
        {
            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 3;
                    //currentEntidad.usuarioModelo = currentUsuario;
                    EDDetalleIMainModel.TypeName = "DetalleCedulaModeloConsultarview";
                    enviarMensajeCrud(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para consultar", "");
            }
        }

        public async void Borrar()
        {
            await mensajeAutoCerrado("No utilizado", "", 1);
        }
        public async void BorrarLogico()
        {
            await mensajeAutoCerrado("No utilizado", "", 1);
        }
 


        #endregion

        #region Verificaciones

        public void Actualizar(ObservableCollection<CedulaModelo> listaEntidad)
        {
            lista = listaEntidad;
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
                    return currentEntidad.idindice != 0 && (currentMaestro.usuariocerro == null || currentMaestro.usuariocerro == string.Empty);
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

        public bool CanVista()
        {
            if (!(currentEntidad == null))
            {
                try
                {
                    if (currentEntidad.referenciacedula != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

        public bool CanReferenciar()
        {
            bool resultado = false;
            if (!(currentEntidad == null))
            {
                try
                {
                    switch (currentEntidad.idcedula)
                    {
                        case 0:
                            resultado = false;
                            break;
                        case 1:
                            resultado = false;
                            break;
                        case 2:
                            resultado = false;
                            break;
                        case 3:
                            resultado = false;
                            break;
                        case 4:
                            resultado = true;
                            break;
                        case 5:
                            resultado = true;
                            break;
                        case 6:
                            resultado = true;
                            break;
                        case 7:
                            resultado = true;
                            break;
                        case 8:
                            resultado = false;
                            break;
                        case 9:
                            resultado = false;
                            break;
                    }
                    return resultado;
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


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanVista);
            DoubleClickCommand = new RelayCommand(Consultar);

            //vistaPreviaReferenciaCommand = new RelayCommand(vistaPreviaReferencia, CanVista);

            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanVista);
            SelectionChangedCommand = new RelayCommand<CedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;

                //listaDetalles = entidad.listaBitacora;
            });
            irMenuPadreCommand = new RelayCommand(irPrincipal);

            referenciarCommand = new RelayCommand(Referenciar, CanReferenciar);


        }


        public void enviarDetalleMensaje()
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentMaestro;//Para el caso de  edicion de programas
                                                           //elemento.listaCedulaModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionHijo;
            elemento.fuenteLlamado = FuenteLlamada; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAVistaPreview);
        }

        private void consultarCarpeta()
        {
            throw new NotImplementedException();
        }




        private async void Referenciar()
        {
            ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 8;//Referenciar
                    EDDetalleIMainModel.TypeName = "DetalleCedulaModeloReferenciarview";
                    //currentEntidad.usuarioModelo = currentUsuario;
                    enviarMensajeCrud();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el elemento a referenciar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para referenciar", "");
            }
        }



        private void irPrincipal()
        {
            iniciarComando();
            //Mandar el mensaje al principal que domina la pantalla
            Messenger.Default.Send(currentMaestro.idcedula, tokenEnvioDatosAMenu);
        }

        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }


        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private async void VistaPrograma()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                enviarMensajeInhabilitar();//Para evitar que el usuario  tome otras acciones
                comando = 5;
                accesibilidadWindow = false;
                EDDetalleIMainModel.TypeName = "CedulaModeloVerProgramaView";
                //enviarElemento(currentEntidad);
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                                 //enviarMensaje();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }


        private void XImprimir()
        {
            //throw new NotImplementedException();
        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }


        private void iniciarComandoBorrar()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            enviarMensajeInhabilitar();
            accesibilidadWindow = false;
        }

        private void finComandoBorrar()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            enviarMensajeHabilitar();
            accesibilidadWindow = true;
        }
        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            //Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));
            Messenger.Default.Register<int>(this, tokenRespuestaReferenciaVista, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));

            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<int>(this, tokenRespuestaReferenciaVista);
            Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);
            if (comando == 12)
            {
                enviarMensajeHabilitar();
            }
            //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
            comando = 0;
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