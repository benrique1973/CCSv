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
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using CapaDatos;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo
{

    public sealed class DetalleMatrizRiesgoViewModel : ViewModeloBase
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

        #region controlRemotoGuardar

        private bool _controlRemotoGuardar;
        private bool controlRemotoGuardar
        {
            get { return _controlRemotoGuardar; }
            set { _controlRemotoGuardar = value; }
        }

        #endregion

        private static int comando = 0;

        private DialogCoordinator dlg;


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

        #region visibilidadMTask

        public const string visibilidadMTaskPropertyName = "visibilidadMTask";

        private Visibility _visibilidadMTask = Visibility.Collapsed;

        public Visibility visibilidadMTask
        {
            get
            {
                return _visibilidadMTask;
            }

            set
            {
                if (_visibilidadMTask == value)
                {
                    return;
                }

                _visibilidadMTask = value;
                RaisePropertyChanged(visibilidadMTaskPropertyName);
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


        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<MatrizRiesgoModelo> _SelectedItems;

        public ObservableCollection<MatrizRiesgoModelo> SelectedItems
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

        #region ViewModel Property : currentBalance Catalogo Modelo

        public const string currentBalancePropertyName = "currentBalance";

        private MatrizRiesgoModelo _currentBalance;

        public MatrizRiesgoModelo currentBalance
        {
            get
            {
                return _currentBalance;
            }

            set
            {
                if (_currentBalance == value) return;

                _currentBalance = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentBalancePropertyName);
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

        private ObservableCollection<DetalleMatrizRiesgoModelo> _lista;

        public ObservableCollection<DetalleMatrizRiesgoModelo> lista
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


        #region ViewModel Properties : listaDetalleBalanceModelo

        public const string listaDetalleBalanceModeloPropertyName = "listaDetalleBalanceModelo";

        private ObservableCollection<DetalleBalanceModelo> _listaDetalleBalanceModelo;

        public ObservableCollection<DetalleBalanceModelo> listaDetalleBalanceModelo
        {
            get
            {
                return _listaDetalleBalanceModelo;
            }
            set
            {
                if (_listaDetalleBalanceModelo == value) return;

                _listaDetalleBalanceModelo = value;

                RaisePropertyChanged(listaDetalleBalanceModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaRiesgos

        public const string listaRiesgosPropertyName = "listaRiesgos";

        private ObservableCollection<string> _listaRiesgos;

        public ObservableCollection<string> listaRiesgos
        {
            get
            {
                return _listaRiesgos;
            }

            set
            {
                if (_listaRiesgos == value) return;

                _listaRiesgos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaRiesgosPropertyName);
            }
        }

        #endregion

        #region Entidades

        #region ViewModel Property : currentEntidad Detalle Balance

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleMatrizRiesgoModelo _currentEntidad;

        public DetalleMatrizRiesgoModelo currentEntidad
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

        #region ViewModel Commands
        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<DetalleMatrizRiesgoModelo> SelectionChangedCommand { get; set; }
        
        public RelayCommand irMenuPadreCommand { get; set; }

        
        public RelayCommand<DetalleMatrizRiesgoModelo> SelectionGuardarCommand { get; set; }
        #endregion

        #region EDMatrizRiesgoMainModel

        private MainModel _mainModel = null;

        public MainModel EDMatrizRiesgoMainModel
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

        #region ViewModel Public Methods

        #region Constructores


        public DetalleMatrizRiesgoViewModel(string origen)//Documentacion/Carpetas
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
            _visibilidadMReferenciar = Visibility.Collapsed;
            _visibilidadMRegresar = Visibility.Visible;
            _visibilidadMVista = Visibility.Collapsed;
            _visibilidadMImportar = Visibility.Collapsed;
            _visibilidadMDetalle = Visibility.Collapsed;

            _visibilidadMCerrar = Visibility.Collapsed;
            _visibilidadMSupervisar = Visibility.Collapsed;
            _visibilidadMAprobar = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            _visibilidadMTask = Visibility.Collapsed;
            #endregion

            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar

            _accesibilidadWindow = false;
            _IsSelected = false;
            //_tokenRecepcionPadre = "PlanificacionDatos";//Permite captar los mensajes del  menú planificacion
            _tokenRecepcionPadre = "datosEDRiesgos";//Permite captar los mensajes del  view model BalancesViewModel
            _tokenEnvioDatosAHijo = "datosPadreDetalleRiesgos";  //Para control de los datos que  remite programas a sub-ventanas
            _tokenRecepcionHijo = "datosControllerDetalleRiesgos";
            _tokenEnvioDatosAMenu = "PlanDetalleRiesgoRegreso";//Para regresar al menu anterior.
            _cursorWindow = Cursors.Hand;
            _opcionMenu = 0;
            _FuenteLlamada = 0;
            _descripcioncb = string.Empty;
            Messenger.Default.Register<RiesgoMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlRecepcionDatos(datosMsj));

            //Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));

            //currentEntidad = new MatrizRiesgoModelo(opcionTipoHerramientaprograma, opcionTipoPrograma,0);
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            RegisterCommands();
            comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<DetalleMatrizRiesgoModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            listaRiesgos = new ObservableCollection<string>(MedicionRiesgo.GetAllCalificacionRiesgo());
            EDMatrizRiesgoMainModel = new MainModel();
            listaDetalleBalanceModelo = new ObservableCollection<DetalleBalanceModelo>();
            _controlRemotoGuardar=true;
        }

        private void ControlCambioLista()
        {
            if (controlRemotoGuardar)
            {
                BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    controlRemotoGuardar =false;
                    guardarlista();
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    controlRemotoGuardar = true;
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }

        private void obtencionListaBalance(int? idBalance)
        {
            if (idBalance!=null && idBalance >0)
            {
                BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    listaDetalleBalanceModelo = new ObservableCollection<DetalleBalanceModelo>(DetalleBalanceModelo.GetAllByIdBCRiesgo((int)currentBalance.idbalance));
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                     //mensajeLista();
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }

        private async void mensajeLista()
        {
            await dlg.ShowMessageAsync(this, "Lista cargada", "");
        }

        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 10,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

        private void permisos()
        {
            if (currentUsuario.listaPermisos != null)
            {
                try
                {
                    if (currentUsuario.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()) > 0)
                    {
                        #region  permisos asignados

                        permisosrolesusuario permisosAsignados = currentUsuario.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()
                        && x.submenupru.ToUpper() == menuElegido.ToUpper());

                        if (permisosAsignados != null)
                        {
                            _visibilidadMRegresar = Visibility.Visible;
                            if (permisosAsignados.crearpru)
                            {
                                _visibilidadMCrear = Visibility.Visible;
                                _visibilidadMImportar = Visibility.Collapsed;
                                _visibilidadMDetalle = Visibility.Collapsed;
                            }
                            else
                            {
                                _visibilidadMCrear = Visibility.Collapsed;
                                _visibilidadMImportar = Visibility.Collapsed;
                            }
                            if (permisosAsignados.editarpru)
                            {
                                _visibilidadMEditar = Visibility.Visible;
                                _visibilidadMReferenciar = Visibility.Collapsed;
                                _visibilidadMCerrar = Visibility.Collapsed;
                                _visibilidadMDetalle = Visibility.Collapsed;
                            }
                            else
                            {
                                _visibilidadMEditar = Visibility.Collapsed;
                                _visibilidadMReferenciar = Visibility.Collapsed;
                                _visibilidadMCerrar = Visibility.Collapsed;
                            }


                            if (permisosAsignados.consultarpru)
                            {
                                _visibilidadMConsulta = Visibility.Visible;
                                _visibilidadMVista = Visibility.Collapsed;
                                _visibilidadMDetalle = Visibility.Collapsed;
                            }
                            else
                            {
                                _visibilidadMConsulta = Visibility.Collapsed;
                                _visibilidadMVista = Visibility.Collapsed;
                            }
                            if (permisosAsignados.eliminarpru)
                            {
                                _visibilidadMBorrar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMBorrar = Visibility.Collapsed;
                            }

                            if (permisosAsignados.revisarpru)
                            {
                                _visibilidadMSupervisar = Visibility.Collapsed;
                            }
                            else
                            {
                                _visibilidadMSupervisar = Visibility.Collapsed;
                            }

                            if (permisosAsignados.aprobarpru)
                            {
                                _visibilidadMAprobar = Visibility.Collapsed;
                            }
                            else
                            {
                                _visibilidadMAprobar = Visibility.Collapsed;
                            }
                            //Tareas queda pendiente
                            _visibilidadMTask = Visibility.Collapsed;

                        }
                        else
                        {
                            MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                        }
                        #endregion fin de region de permisos
                    }
                    else
                    {
                        MessageBox.Show("Error en opción y la base de datos\nRevise la opción programada");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al identificar los permisos\nRevise la opción programada\n" + e.ToString());
                    #region  menu
                    //Solo permite consulta
                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Visible;
                    _visibilidadMReferenciar = Visibility.Collapsed;
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Collapsed;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    #endregion
                }
            }
            else
            {
                #region  menu
                MessageBox.Show("No están definidos los permisos\nRevise los permisos del usuario");
                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Collapsed;
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
            }

        }


        private void ControlRecepcionDatos(RiesgoMsj msj)
        {
            currentEncargo = msj.encargoModelo;//Encargo en uso actual
            currentUsuario = msj.usuarioModelo;
            currentSistemaContable = msj.sistemaContableModelo;
            currentBalance = msj.matrizRiesgoModelo;
            obtencionListaBalance(currentBalance.idbalance);//Comienza a cargar la lista del balance
            opcionMenu = msj.opcionMenuCrud;
            FuenteLlamada = msj.fuenteLlamado;
            actualizarLista();
            //No se desuscribe porque continua existiendo
            //Messenger.Default.Unregister<RiesgoMsj>(this, tokenRecepcionPadre);
            Mouse.OverrideCursor = null;
            permisos();
            accesibilidadWindow = true;
            Messenger.Default.Unregister<RiesgoMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<MatrizRiesgoModelo>(MatrizRiesgoModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<DetalleMatrizRiesgoModelo>(DetalleMatrizRiesgoModelo.GetAll(currentBalance,currentUsuario));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e, "");

                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }




        #endregion

        #region Envio mensajes


        //Caso de nuevo registro 
        public void enviarMensaje()
        {
            //Se crea el mensaje
            DetalleRiesgoMsj elemento = new DetalleRiesgoMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.matrizRiesgoModelo = currentBalance;//Para el caso de  edicion de programas
            elemento.detalleMatrizRiesgoModelo = currentEntidad;
            elemento.listaDetalleMatrizRiesgoModelo = lista;
            elemento.listaDetalleBalanceModelo = listaDetalleBalanceModelo;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuesta = tokenRecepcionHijo;
            elemento.fuenteLlamado = 0; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }


        //public void enviarMensajeCargarBalance()
        //{
        //    //Se crea el mensaje
        //    ClientesContactosMensajeModal elemento = new ClientesContactosMensajeModal();
        //    elemento.UsuarioValidado = UsuarioModelo.GetRegistroByIdUsarioCapaDatos(currentUsuario.idUsuario);
        //    elemento.currentCliente = ClienteModelo.GetRegistroByNitCapaDatos(currentEncargo.idnitcliente);
        //    elemento.SistemaContableAModificar = SistemaContableModelo.GetRegistroByIdEncargoCapaDatos(currentEncargo.idencargo);
        //    Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        //}

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EDMatrizRiesgoMainModel.TypeName = null;
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
                default:
                    break;
            }
            comando = 0;
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
            currentEntidad = new DetalleMatrizRiesgoModelo(currentBalance);
            currentEntidad.matrizRiesgoModelo = currentBalance;
            currentEntidad.usuarioModelo = currentUsuario;
            EDMatrizRiesgoMainModel.TypeName = "DetalleMatrizRiesgoModeloCrearview";
            #endregion

            activarCaptura = true;
            #endregion
            enviarMensaje();
        }

        public async void Editar()
        {
            //Para guardar lo que esta en la  pantalla
            //ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 2;
                    EDMatrizRiesgoMainModel.TypeName = "DetalleMatrizRiesgoModeloEditarView";
                    currentEntidad.usuarioModelo = currentUsuario;
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
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
            //ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 3;
                    currentEntidad.usuarioModelo = currentUsuario;
                    EDMatrizRiesgoMainModel.TypeName = "DetalleMatrizRiesgoModeloConsultarView";
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

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
            //Para guardar lo que esta en la  pantalla
            //ControlCambioLista(true);
            if (!(currentEntidad == null))
            {
                currentEntidad.usuarioModelo = currentUsuario;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComandoBorrar();
                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //caso de un registro
                        if (DetalleMatrizRiesgoModelo.Delete(currentEntidad.iddmr, true))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borro el registro ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new DetalleMatrizRiesgoModelo();
                            finComandoBorrar();
                        }
                        else
                        {
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                        }

                    }
                    else
                    {
                        //caso de muchos registros
                        if (DetalleMatrizRiesgoModelo.Delete(new ObservableCollection<DetalleMatrizRiesgoModelo>(lista.Where(x => x.IsSelected))))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new DetalleMatrizRiesgoModelo();
                            finComandoBorrar();
                        }
                        else
                        {
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                        }
                    }

                }
                else
                {
                    finComandoBorrar();
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "", MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            finComandoBorrar();
        }


        public async void Borrarlógico()
        {

            if (!(currentEntidad == null))
            {
                accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                currentEntidad.usuarioModelo = currentUsuario;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        //caso de un registro
                        if (DetalleMatrizRiesgoModelo.DeleteBorradoLogico(currentEntidad.iddmr, currentEntidad))
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                            actualizarLista();
                            currentEntidad = new DetalleMatrizRiesgoModelo();
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                            accesibilidadWindow = true;
                        }

                    }
                    else
                    {
                        //caso de muchos registros
                        if (DetalleMatrizRiesgoModelo.DeleteBorradoLogico(new ObservableCollection<DetalleMatrizRiesgoModelo>(lista.Where(x => x.IsSelected))))
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Se borraron  los registros ", "");
                            actualizarLista();
                            currentEntidad = new DetalleMatrizRiesgoModelo();
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                            accesibilidadWindow = true;
                        }
                    }

                }
                else
                {
                    Mouse.OverrideCursor = null;
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a eliminar", "", MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            accesibilidadWindow = true;
            Mouse.OverrideCursor = null;
        }


        #endregion

        #region Verificaciones

        public void Actualizar(ObservableCollection<DetalleMatrizRiesgoModelo> listaEntidad)
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
                    return currentEntidad.iddmr!= 0 && (currentBalance.usuariocerro == null || currentBalance.usuariocerro == string.Empty);
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
            NuevoCommand = new RelayCommand(Nuevo, canNuevo);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanVistas);
            DoubleClickCommand = new RelayCommand(nada);
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanVistas);
            SelectionChangedCommand = new RelayCommand<DetalleMatrizRiesgoModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                currentEntidad.guardadoBase = false;
                /*if (controlRemotoGuardar)
                {
                    ControlCambioLista();//Lanza el proceso
                }*/
                //listaDetalles = entidad.listaBitacora;
            });
            irMenuPadreCommand = new RelayCommand(irPrincipal);

            SelectionGuardarCommand = new RelayCommand<DetalleMatrizRiesgoModelo>(entidad =>
                            {
                                if (entidad == null) return;
                                //Verificar la cantidad de  registros seleccionados
                                calificacionRiesgo(entidad);
                                entidad.guardadoBase = false;
                                if (controlRemotoGuardar)
                                {
                                    ControlCambioLista();//Lanza el proceso
                                }
                                //listaDetalles = entidad.listaBitacora;
                            });
            
        }

        private bool canNuevo()
        {
            if (!(currentEntidad == null))
            {
                try
                {
                    return (currentBalance.usuariocerro == null || currentBalance.usuariocerro == string.Empty);
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

        private bool CanVistas()
        {
            if (!(currentEntidad == null))
            {
                try
                {
                    return currentEntidad.iddmr != 0;
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

        private void nada()
        {
           // throw new NotImplementedException();
        }

        private async void irPrincipal()
        {
            if ((currentBalance.usuariocerro == null || currentBalance.usuariocerro == string.Empty))
            {
                if (Errors != 0)
                {
                    await dlg.ShowMessageAsync(this, "Hay datos editados con error", "debe corregir antes de regresar");
                }
                else
                {

                    if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                    {
                        var mySettings = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Si",
                            NegativeButtonText = "No",
                        };

                        MessageDialogResult result = await dlg.ShowMessageAsync(this, "Desea guardar los cambios antes de regresar", "", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                        if (result == MessageDialogResult.Affirmative)
                        {
                            iniciarComando();
                            //Repite el  ciclo para evitar errores
                            if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                            {
                                if (guardarlistaDetalleProgramaEjecucion() == -1)
                                {
                                    var controller = await dlg.ShowProgressAsync(this, "Se actualizaron los datos ", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                    controller.SetIndeterminate();
                                    await TaskEx.Delay(1000);
                                    await controller.CloseAsync();
                                    //finComando();
                                }
                                else
                                {
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "No pudo actualizarse ", "Verifique si tiene conexión");
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
                            finComando();
                        }
                    }
                    //Gestiona el guardar los cambios en  la lista
                    iniciarComando();
                    //Mandar el mensaje al principal que domina la pantalla
                    Messenger.Default.Send(opcionMenu, tokenEnvioDatosAMenu);
                }
            }
            else
            {
                //Gestiona el guardar los cambios en  la lista
                iniciarComando();
                //Mandar el mensaje al principal que domina la pantalla
                Messenger.Default.Send(opcionMenu, tokenEnvioDatosAMenu);
            }
        }
        public int guardarlistaDetalleProgramaEjecucion()
        {
            try
            {
                int resultado = 0;
                foreach (DetalleMatrizRiesgoModelo item in lista)
                // foreach (DetalleProgramaModelo item in listaDetallePrograma)
                {
                    //if (item.guardadoBase == false && ((item.descripciontrc != null && item.descripciontrc != "") || (item.comentariodp != null && item.comentariodp != "") || (item.referenciaPt != null && item.referenciaPt != "")) )
                    if (item.guardadoBase == false )
                    {
                        calificacionRiesgo(item);
                        //Ver que campo debe ser actualizado
                        if (DetalleMatrizRiesgoModelo.UpdateModelo(item,true))
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
                public async void guardarlista()
        {
            try
            {
                if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                {

                    foreach (DetalleMatrizRiesgoModelo item in lista)
                    {
                        if (item.guardadoBase == false)
                        {
                            calificacionRiesgo(item);
                            if (DetalleMatrizRiesgoModelo.UpdateModelo(item, true))
                            {
                                item.guardadoBase = true;//Se actualizo el registro
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar un registro", "");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Mensaje de error
            }
        }
        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }

        public void calificacionRiesgo(DetalleMatrizRiesgoModelo currentEntidad)
        {
            if (currentEntidad.alcanceinherentedmr > 40)
            {
                if (currentEntidad.alcanceinherentedmr > 60)
                {
                    currentEntidad.evaluacioninherentedmr = "ALTO";
                }
                else
                {
                    currentEntidad.evaluacioninherentedmr = "MEDIO";
                }
            }
            else
            {
                currentEntidad.evaluacioninherentedmr = "BAJO";
            }
            if (currentEntidad.alcancecontroldmr > 20)
            {
                if (currentEntidad.alcancecontroldmr > 40)
                {
                    currentEntidad.evaluacioncontroldmr = "ALTO";
                }
                else
                {
                    currentEntidad.evaluacioncontroldmr = "MEDIO";
                }
            }
            else
            {
                currentEntidad.evaluacioncontroldmr = "BAJO";
            }
            if (currentEntidad.alcancecombinadodmr > 20)
            {
                if (currentEntidad.alcancecombinadodmr > 40)
                {
                    currentEntidad.evaluacioncombinadodmr = "ALTO";
                }
                else
                {
                    currentEntidad.evaluacioncombinadodmr = "MEDIO";
                }
            }
            else
            {
                currentEntidad.evaluacioncombinadodmr = "BAJO";
            }
            currentEntidad.riesgoAuditoriadmr = (currentEntidad.alcancecombinadodmr / 100 * currentEntidad.alcancecontroldmr / 100 * currentEntidad.alcanceinherentedmr / 100) * 100;
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
                EDMatrizRiesgoMainModel.TypeName = "BalanceModeloVerProgramaView";
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
            //Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));

            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);

            //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
        }


        #endregion Fin de comando

    }
}