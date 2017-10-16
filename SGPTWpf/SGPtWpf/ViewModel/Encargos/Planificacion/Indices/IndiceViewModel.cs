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
using SGPTmvvm.Mensajes;
using System.Linq;
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPtmvvm.Mensajes;
using CapaDatos;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices
{

    public sealed class IndiceViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region tablaDetalle

        private string _tablaDetalle;
        private string tablaDetalle
        {
            get { return _tablaDetalle; }
            set { _tablaDetalle = value; }
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

        #region tokenRecepcionHijo

        private string _tokenRecepcionHijo;
        private string tokenRecepcionHijo
        {
            get { return _tokenRecepcionHijo; }
            set { _tokenRecepcionHijo = value; }
        }

        #endregion

        #region tokenRecepcionSubMenu
        private string _tokenRecepcionSubMenu;
        private string tokenRecepcionSubMenu
        {
            get { return _tokenRecepcionSubMenu; }
            set { _tokenRecepcionSubMenu = value; }
        }
        #endregion

        #region tokenEnvioPadre

        private string _tokenEnvioPadre;
        private string tokenEnvioPadre
        {
            get { return _tokenEnvioPadre; }
            set { _tokenEnvioPadre = value; }
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

        #region fuenteLlamado //Sirve para diferenciar las fuentas de  la llamada para las vistas
        //0 Sin identificar
        //1 Plan Indices
        //2 Plan Indices detalle
        //3 Documentacion indice
        //4 Documentacion detalle indice

        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        #region tokenRecepcionCierrePreView

        private string _tokenRecepcionCierrePreView;
        private string tokenRecepcionCierrePreView
        {
            get { return _tokenRecepcionCierrePreView; }
            set { _tokenRecepcionCierrePreView = value; }
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

        #region nombreopcionor

        private string _nombreopcionor;
        private string nombreopcionor
        {
            get { return _nombreopcionor; }
            set { _nombreopcionor = value; }
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

        #region tokenEnvioDatosAVistaPreview

        private string _tokenEnvioDatosAVistaPreview;
        private string tokenEnvioDatosAVistaPreview
        {
            get { return _tokenEnvioDatosAVistaPreview; }
            set { _tokenEnvioDatosAVistaPreview = value; }
        }

        #endregion

        #region tokenEnvioDatosCarga

        private string _tokenEnvioDatosCarga;
        private string tokenEnvioDatosCarga
        {
            get { return _tokenEnvioDatosCarga; }
            set { _tokenEnvioDatosCarga = value; }
        }

        #endregion


        #region tokenRecepcionDatosCarga

        private string _tokenRecepcionDatosCarga;
        private string tokenRecepcionDatosCarga
        {
            get { return _tokenRecepcionDatosCarga; }
            set { _tokenRecepcionDatosCarga = value; }
        }

        #endregion

        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<TipoCarpetaModelo> _SelectedItems;

        public ObservableCollection<TipoCarpetaModelo> SelectedItems
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

        #region Nombre tipo auditoria

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

        #region visibilidadMenu



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

        #region ViewModel Property : usuarioModelo usuario

        public const string usuarioModeloPropertyName = "usuarioModelo";

        private UsuarioModelo _usuarioModelo;

        public UsuarioModelo usuarioModelo
        {
            get
            {
                return _usuarioModelo;
            }

            set
            {
                if (_usuarioModelo == value) return;

                _usuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(usuarioModeloPropertyName);
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

        private ObservableCollection<menuIndiceDetalle> _listaVistas;

        public ObservableCollection<menuIndiceDetalle> listaVistas
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

        private ObservableCollection<TipoCarpetaModelo> _lista;

        public ObservableCollection<TipoCarpetaModelo> lista
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

        #region ViewModel Property : currentEntidad Catalogo Modelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private TipoCarpetaModelo _currentEntidad;

        public TipoCarpetaModelo currentEntidad
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
        //public RelayCommand cmdCargarCatalogo { get; set; }


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand copiarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<TipoCarpetaModelo> SelectionChangedCommand { get; set; }
        public RelayCommand detalleCommand { get; set; }

        public RelayCommand vistaCommand { get; set; }
        public RelayCommand ImportarCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }

        public RelayCommand ItemSeleccionadoCommand { get; set; }
        #endregion

        #region EDPlanIndiceMainModel

        private MainModel _mainModel = null;

        public MainModel EDPlanIndiceMainModel
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

        //Llamado desde planificacion
        public IndiceViewModel()//Caso Encargo/PlanIndice
        {
        }

        //Llamado desde documentacion
        public IndiceViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;
            _descripcion = string.Empty;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar
            _accesibilidadWindow = false;
            _IsSelected = false;
            //currentEntidad = new TipoCarpetaModelo(opcionTipoHerramientaprograma, opcionTipoPrograma,0);
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<TipoCarpetaModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            EDPlanIndiceMainModel = new MainModel();
            _tokenEnvioDatosAVistaPreview = "LlamadaDePrincipal";
            switch (origen)
            {
                case "EncargoPlanIndice"://Llamada desde documentacion plan indices
                    #region Configuracion plan
                        _menuElegido = "Planificacion";
                        _nombreopcionor = "Indices";
                        tablaDetalle = "Detalle Indices";

                        fuenteLlamado = 1;
                        //0 Sin identificar
                        //1 Plan Indices
                        //2 Plan Indices detalle
                        #region  menu
                            _visibilidadMCrear = Visibility.Visible;
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Visible;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMRegresar = Visibility.Visible;
                            _visibilidadMVista = Visibility.Visible;
                            _visibilidadMImportar = Visibility.Visible;
                            _visibilidadMDetalle = Visibility.Visible;

                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                        #endregion

                        _tokenRecepcionPadre = "Indices" + "Planificación";//Permite captar los mensajes del  menú planificacion
                        _tokenEnvioDatosAHijo = "datosEDIndices";//Para control de los datos que  remite programas a sub-ventanas
                        _tokenRecepcionHijo = "datosControllerIndices";
                        _tokenRecepcionSubMenu = "PlanDetalleIndiceRegreso";
                        _tokenEnvioPadre = "inicioEncargoDocumentacionPlanIndices";
                        _tokenRecepcionCierrePreView = "Retorno"+ "EncargoPlanIndice" + "LlamadaDePrincipal";//Sirve la vista del indice como tal;

                    RegisterCommands();
                    listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAll());
                    #endregion
                    break;
                case "EncargoDocumentacion"://Documentacion carpetas
                    _menuElegido = "Documentacion";
                    _nombreopcionor = "Carpetas";
                    tablaDetalle = "Detalle carpetas";
                      fuenteLlamado = 3;
                    //2 Plan Indices detalle
                    #region  menu

                        _visibilidadMCrear = Visibility.Collapsed;
                        _visibilidadMEditar = Visibility.Collapsed;
                        _visibilidadMBorrar = Visibility.Collapsed;
                        _visibilidadMConsulta = Visibility.Collapsed;
                        _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                        _visibilidadMRegresar = Visibility.Collapsed;
                        _visibilidadMVista = Visibility.Visible;
                        _visibilidadMImportar = Visibility.Collapsed;
                        _visibilidadMDetalle = Visibility.Visible;

                        _visibilidadMCerrar = Visibility.Collapsed;
                        _visibilidadMSupervisar = Visibility.Collapsed;
                        _visibilidadMAprobar = Visibility.Collapsed;
                        _visibilidadMTask = Visibility.Collapsed;
                        _visibilidadMImprimir = Visibility.Collapsed;


                    #endregion

                    #region  tokens
                    _tokenRecepcionPadre = "Carpetas" + "Documentacion";//Permite captar los mensajes del  menú planificacion, corresponde a Indices
                    _tokenEnvioDatosAHijo = "datosEncargoDocumentacionIndices";//Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosEncargoDocumentacionControllerIndices";
                    _tokenRecepcionSubMenu = "DocumentacionDetalleIndiceRegreso";
                    _tokenEnvioPadre = "inicioEncargoDocumentacionIndices";
                    _tokenRecepcionCierrePreView = "Retorno" + "EncargoDocumentacion" + "LlamadaDePrincipal";//Sirve la vista del indice como tal;

                    #endregion
                    RegisterCommandsDocumentacion();
                    //Messenger.Default.Register<int>(this, tokenRecepcionDatosCarga, (detalleTerminado) => ControlCarga(detalleTerminado));
                    listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllDocumentacion());
                    break;
                case "EncargoCierre": //Encargos cierre
                    _menuElegido = "Cierre";
                    _nombreopcionor = "Revision de papeles";
                    tablaDetalle = "Detalle papeles";
                    fuenteLlamado = 5;
                    //5 Cierre indice
                    //6 Cierre detalle indice
                    #region  menu

                        _visibilidadMCrear = Visibility.Collapsed;
                        _visibilidadMEditar = Visibility.Collapsed;
                        _visibilidadMBorrar = Visibility.Collapsed;
                        _visibilidadMConsulta = Visibility.Collapsed;
                        _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                        _visibilidadMRegresar = Visibility.Collapsed;
                        _visibilidadMVista = Visibility.Visible;
                        _visibilidadMImportar = Visibility.Collapsed;
                        _visibilidadMDetalle = Visibility.Visible;

                        _visibilidadMCerrar = Visibility.Visible;
                        _visibilidadMSupervisar = Visibility.Visible;
                        _visibilidadMAprobar = Visibility.Visible;
                        _visibilidadMTask = Visibility.Collapsed;
                        _visibilidadMImprimir = Visibility.Collapsed;


                    #endregion
                    #region tokens
                    _tokenRecepcionPadre = "Revision de papeles" + "CierreEncargo";//Permite captar los mensajes del  menú planificacion, corresponde a Indices
                    _tokenEnvioDatosAHijo = "datosEncargoCierreIndices";//Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosEncargoCierreControllerIndices";
                    _cursorWindow = Cursors.Hand;
                    _tokenRecepcionSubMenu = "CierreDetalleIndiceRegreso";
                    _tokenEnvioPadre = "inicioEncargoCierreIndices";
                    _tokenRecepcionCierrePreView = "Retorno" + "EncargoCierre" + "LlamadaDePrincipal";//Sirve la vista del indice como tal;

                    #endregion
                    RegisterCommandsCierre();
                    listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllCierre());
                    break;
                case "SupervisionIndice": //Encargos cierre
                    _menuElegido = "Supervision";
                    _nombreopcionor = "Revision de carpetas";
                    tablaDetalle = "Detalle archivos";
                    fuenteLlamado = 5;
                    //5 Cierre indice
                    //6 Cierre detalle indice
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Visible;

                    _visibilidadMCerrar = Visibility.Visible;
                    _visibilidadMSupervisar = Visibility.Visible;
                    _visibilidadMAprobar = Visibility.Visible;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;


                    #endregion
                    #region tokens
                    _tokenRecepcionPadre = "Revision de carpetas" + "Supervision";//Permite captar los mensajes del  menú planificacion, corresponde a Indices
                    _tokenEnvioDatosAHijo = "datosEncargoCierreIndices";//Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosEncargoCierreControllerIndices";
                    _cursorWindow = Cursors.Hand;
                    _tokenRecepcionSubMenu = "Revision de carpetas" + "Supervision"  +"DetalleRegreso";
                    _tokenEnvioPadre = "Revision de carpetas" + "Supervision" + "Hijo";
                    _tokenRecepcionCierrePreView = "Retorno" + "EncargoCierre" + "LlamadaDePrincipal";//Sirve la vista del indice como tal;

                    #endregion
                    RegisterCommandsCierre();
                    listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllSupervision());
                    break;
                case "Documentos"://Llamada desde el principal documentos consulta
                    _menuElegido = "Consulta";
                    _nombreopcionor = "Consulta";
                    tablaDetalle = "Detalle papeles";
                    fuenteLlamado = 5;
                    //5 Cierre indice
                    //6 Cierre detalle indice
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Collapsed;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir =Visibility.Collapsed;


                    #endregion
                    #region tokens
                    _tokenRecepcionPadre = "Consulta" + "MenuDocumentos";//Permite captar los mensajes del  menú planificacion, corresponde a Indices
                    _tokenEnvioDatosAHijo = "datosDocumentosConsultaIndices";//Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosDocumentosConsultaControllerIndices";
                    _cursorWindow = Cursors.Hand;
                    _tokenRecepcionSubMenu = "CierreDetalleIndiceRegreso";
                    _tokenEnvioPadre = "inicioDocumentosConsultaIndices";
                    _tokenRecepcionCierrePreView = "Retorno" + "Documentos" + "LlamadaDePrincipal";//Sirve la vista del indice como tal;

                    #endregion
                    RegisterCommandsDocumentos();
                    listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllConsultaDocumentos());
                    break;
                case "DocumentosImpresion"://Llamada desde el principal documentos impresion
                    _menuElegido = "Impresion";
                    _nombreopcionor = "Impresion";
                    tablaDetalle = "Detalle impresion";
                    fuenteLlamado = 5;
                    //5 Cierre indice
                    //6 Cierre detalle indice
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Collapsed;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;


                    #endregion
                    #region tokens
                    _tokenRecepcionPadre = "Impresión" + "MenuDocumentos";//Permite captar los mensajes del  menú planificacion, corresponde a Indices
                    _tokenEnvioDatosAHijo = "datosDocumentosImpresionIndices";//Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosDocumentosImpresionControllerIndices";
                    _cursorWindow = Cursors.Hand;
                    _tokenRecepcionSubMenu = "CierreDetalleIndiceRegreso";
                    _tokenEnvioPadre = "inicioDocumentosImpresionIndices";
                    _tokenRecepcionCierrePreView = "Retorno" + "DocumentosImpresion" + "LlamadaDePrincipal";//Sirve la vista del indice como tal;

                    #endregion
                    RegisterCommandsDocumentosImpresion();
                    listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllImpresionDocumentos());
                    break;

            }
            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            _comando = 0;
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));



        }

        private void RegisterCommandsDocumentos()
        {
            DoubleClickCommand = new RelayCommand(Nada);
            ItemSeleccionadoCommand = new RelayCommand(itemDetalleSeleccion, CanDocumentacionCommand);
            SelectionChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
    }
        private void RegisterCommandsDocumentosImpresion()
        {
            DoubleClickCommand = new RelayCommand(Nada);
            ItemSeleccionadoCommand = new RelayCommand(itemDetalleSeleccionImpresion, CanDocumentacionCommand);
            SelectionChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private bool CanDocumentacionCommand()
        {
            return true;
        }

        private void itemDetalleSeleccionImpresion()
        {
            descripcion = currentEntidad.descripcion;
            //detallePlantillaIndice.NavigateExecute();
            listaVistas[0].NavigateExecute(); //Repite para inicializar desde documentacion
                                              //Enviar elemento seleccionado a detalle Plantilla indice
            enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllImpresionDocumentos());
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
            currentEntidad = null;

        }
        private void itemDetalleSeleccion()
        {
            descripcion = currentEntidad.descripcion;
            //detallePlantillaIndice.NavigateExecute();
            listaVistas[0].NavigateExecute(); //Repite para inicializar desde documentacion
                                              //Enviar elemento seleccionado a detalle Plantilla indice
            enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllConsultaDocumentos());
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
            currentEntidad = null;

        }
        private void ControlCambioLista(bool recepcionDatos)
        {
            if (recepcionDatos)
            {
                BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    //guardarlista();
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    //Nada se deja la lista actualizada;
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
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
            if (usuarioModelo.listaPermisos != null)
            {
                try
                {
                    #region Menu permisos
                    switch (origenLlamada)
                    {
                        case "EncargoPlanIndice"://Llamada desde documentacion plan indices
                            #region configuracion

                            if (usuarioModelo.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()) > 0)
                            {
                                #region  permisos asignados
                                //_menuElegido = "Planificacion";
                                //_nombreopcionor = "Indices";
                                permisosrolesusuario permisosAsignados = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()
                                && x.submenupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {
                                    #region crear-importar-detalle

                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                        _visibilidadMImportar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                        _visibilidadMImportar = Visibility.Collapsed;
                                    }

                                    #endregion crear

                                    #region editar-referenciar-cerrar-detalle
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Visible;
                                        _visibilidadMCerrar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Collapsed;
                                        _visibilidadMCerrar = Visibility.Collapsed;
                                    }
                                    #endregion editar

                                    #region consultar-vista-detalle
                                    if (permisosAsignados.consultarpru)
                                    {
                                        _visibilidadMConsulta = Visibility.Visible;
                                        _visibilidadMVista = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMConsulta = Visibility.Collapsed;
                                        _visibilidadMVista = Visibility.Collapsed;
                                    }
                                    #endregion consultar

                                    #region borrar
                                    if (permisosAsignados.eliminarpru)
                                    {
                                        _visibilidadMBorrar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMBorrar = Visibility.Collapsed;
                                    }
                                    #endregion borrar

                                    #region supervisar-aprobar
                                    if (permisosAsignados.revisarpru)
                                    {
                                        _visibilidadMSupervisar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMSupervisar = Visibility.Collapsed;
                                    }

                                    if (permisosAsignados.aprobarpru)
                                    {
                                        _visibilidadMAprobar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMAprobar = Visibility.Collapsed;
                                    }
                                    #endregion supervisar-aprobar

                                    #region No operativos

                                    _visibilidadMEditar = Visibility.Collapsed;
                                    _visibilidadMTask = Visibility.Collapsed;
                                    _visibilidadMRegresar = Visibility.Collapsed;
                                    _visibilidadMImprimir = Visibility.Collapsed;
                                    
                                    #endregion
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

                            #endregion configuracion
                            #region  menu
                            //_visibilidadMCrear = Visibility.Visible;
                            //_visibilidadMBorrar = Visibility.Visible;
                            //_visibilidadMVista = Visibility.Visible;
                            //_visibilidadMImportar = Visibility.Visible;
                            //_visibilidadMDetalle = Visibility.Visible;

                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                            #endregion
                            break;
                        case "EncargoDocumentacion"://Documentacion carpetas
                            #region configuracion

                            if (usuarioModelo.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()) > 0)
                            {
                                #region  permisos asignados
                                //_menuElegido = "Planificacion";
                                //_nombreopcionor = "Indices";
                                permisosrolesusuario permisosAsignados = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()
                                && x.submenupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {
                                    #region crear-importar-detalle

                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                        _visibilidadMImportar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                        _visibilidadMImportar = Visibility.Collapsed;
                                    }

                                    #endregion crear

                                    #region editar-referenciar-cerrar-detalle
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Visible;
                                        _visibilidadMCerrar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Collapsed;
                                        _visibilidadMCerrar = Visibility.Collapsed;
                                    }
                                    #endregion editar

                                    #region consultar-vista-detalle
                                    if (permisosAsignados.consultarpru)
                                    {
                                        _visibilidadMConsulta = Visibility.Visible;
                                        _visibilidadMVista = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMConsulta = Visibility.Collapsed;
                                        _visibilidadMVista = Visibility.Collapsed;
                                    }
                                    #endregion consultar

                                    #region borrar
                                    if (permisosAsignados.eliminarpru)
                                    {
                                        _visibilidadMBorrar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMBorrar = Visibility.Collapsed;
                                    }
                                    #endregion borrar

                                    #region supervisar-aprobar
                                    if (permisosAsignados.revisarpru)
                                    {
                                        _visibilidadMSupervisar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMSupervisar = Visibility.Collapsed;
                                    }

                                    if (permisosAsignados.aprobarpru)
                                    {
                                        _visibilidadMAprobar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMAprobar = Visibility.Collapsed;
                                    }
                                    #endregion supervisar-aprobar

                                    #region No operativos

                                    _visibilidadMEditar = Visibility.Collapsed;
                                    _visibilidadMTask = Visibility.Collapsed;
                                    _visibilidadMRegresar = Visibility.Collapsed;
                                    _visibilidadMImprimir = Visibility.Collapsed;

                                    #endregion
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

                            #endregion configuracion
                            #region  menu
                            _visibilidadMCrear = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            //_visibilidadMVista = Visibility.Visible;
                            _visibilidadMImportar = Visibility.Collapsed;
                            //_visibilidadMDetalle = Visibility.Visible;

                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                            #endregion
                            break;
                        case "EncargoCierre": //Encargos cierre
                            #region configuracion

                            if (usuarioModelo.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()) > 0)
                            {
                                #region  permisos asignados
                                //_menuElegido = "Planificacion";
                                //_nombreopcionor = "Indices";
                                permisosrolesusuario permisosAsignados = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()
                                && x.submenupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {
                                    #region crear-importar-detalle

                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                        _visibilidadMImportar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                        _visibilidadMImportar = Visibility.Collapsed;
                                    }

                                    #endregion crear

                                    #region editar-referenciar-cerrar-detalle
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Visible;
                                        _visibilidadMCerrar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Collapsed;
                                        _visibilidadMCerrar = Visibility.Collapsed;
                                    }
                                    #endregion editar

                                    #region consultar-vista-detalle
                                    if (permisosAsignados.consultarpru)
                                    {
                                        _visibilidadMConsulta = Visibility.Visible;
                                        _visibilidadMVista = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMConsulta = Visibility.Collapsed;
                                        _visibilidadMVista = Visibility.Collapsed;
                                    }
                                    #endregion consultar

                                    #region borrar
                                    if (permisosAsignados.eliminarpru)
                                    {
                                        _visibilidadMBorrar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMBorrar = Visibility.Collapsed;
                                    }
                                    #endregion borrar

                                    #region supervisar-aprobar
                                    if (permisosAsignados.revisarpru)
                                    {
                                        _visibilidadMSupervisar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMSupervisar = Visibility.Collapsed;
                                    }

                                    if (permisosAsignados.aprobarpru)
                                    {
                                        _visibilidadMAprobar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMAprobar = Visibility.Collapsed;
                                    }
                                    #endregion supervisar-aprobar

                                    #region No operativos

                                    _visibilidadMEditar = Visibility.Collapsed;
                                    _visibilidadMTask = Visibility.Collapsed;
                                    _visibilidadMRegresar = Visibility.Collapsed;
                                    _visibilidadMImprimir = Visibility.Collapsed;

                                    #endregion
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

                            #endregion configuracion
                            #region  menu
                            _visibilidadMCrear = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            //_visibilidadMVista = Visibility.Visible;
                            _visibilidadMImportar = Visibility.Collapsed;
                            //_visibilidadMDetalle = Visibility.Visible;

                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMEditar = Visibility.Collapsed;
                            //_visibilidadMCerrar = Visibility.Visible;
                            //_visibilidadMSupervisar = Visibility.Visible;
                            //_visibilidadMAprobar = Visibility.Visible;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                            #endregion
                            break;
                        case "SupervisionIndice": //Encargos cierre
                            #region configuracion

                            if (usuarioModelo.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()) > 0)
                            {
                                #region  permisos asignados
                                //_menuElegido = "Planificacion";
                                //_nombreopcionor = "Indices";
                                permisosrolesusuario permisosAsignados = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()
                                && x.submenupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {
                                    #region crear-importar-detalle

                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                        _visibilidadMImportar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                        _visibilidadMImportar = Visibility.Collapsed;
                                    }

                                    #endregion crear

                                    #region editar-referenciar-cerrar-detalle
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Visible;
                                        _visibilidadMCerrar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Collapsed;
                                        _visibilidadMCerrar = Visibility.Collapsed;
                                    }
                                    #endregion editar

                                    #region consultar-vista-detalle
                                    if (permisosAsignados.consultarpru)
                                    {
                                        _visibilidadMConsulta = Visibility.Visible;
                                        _visibilidadMVista = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMConsulta = Visibility.Collapsed;
                                        _visibilidadMVista = Visibility.Collapsed;
                                    }
                                    #endregion consultar

                                    #region borrar
                                    if (permisosAsignados.eliminarpru)
                                    {
                                        _visibilidadMBorrar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMBorrar = Visibility.Collapsed;
                                    }
                                    #endregion borrar

                                    #region supervisar-aprobar
                                    if (permisosAsignados.revisarpru)
                                    {
                                        _visibilidadMSupervisar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMSupervisar = Visibility.Collapsed;
                                    }

                                    if (permisosAsignados.aprobarpru)
                                    {
                                        _visibilidadMAprobar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMAprobar = Visibility.Collapsed;
                                    }
                                    #endregion supervisar-aprobar

                                    #region No operativos

                                    _visibilidadMEditar = Visibility.Collapsed;
                                    _visibilidadMTask = Visibility.Collapsed;
                                    _visibilidadMRegresar = Visibility.Collapsed;
                                    _visibilidadMImprimir = Visibility.Collapsed;

                                    #endregion
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

                            #endregion configuracion
                            #region  menu
                            _visibilidadMCrear = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            //_visibilidadMVista = Visibility.Visible;
                            _visibilidadMImportar = Visibility.Collapsed;
                            //_visibilidadMDetalle = Visibility.Visible;

                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMEditar = Visibility.Collapsed;
                            //_visibilidadMCerrar = Visibility.Visible;
                            //_visibilidadMSupervisar = Visibility.Visible;
                            //_visibilidadMAprobar = Visibility.Visible;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                            #endregion
                             break;
                        case "Documentos"://Llamada desde el principal documentos consulta
                            #region  menu

                            _visibilidadMCrear = Visibility.Collapsed;
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMVista = Visibility.Collapsed;
                            _visibilidadMImportar = Visibility.Collapsed;
                            _visibilidadMDetalle = Visibility.Collapsed;

                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;


                            #endregion
                            break;
                        case "DocumentosImpresion"://Llamada desde el principal documentos impresion
                            #region  menu

                            _visibilidadMCrear = Visibility.Collapsed;
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMVista = Visibility.Collapsed;
                            _visibilidadMImportar = Visibility.Collapsed;
                            _visibilidadMDetalle = Visibility.Collapsed;

                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;


                            #endregion
                            break;
                    }
                    #endregion permisos
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
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Visible;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
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
                _visibilidadMDetalle = Visibility.Visible;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMTask = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;
                #endregion
            }

        }


        private void ControlRecepcionDatos(EncargosDatosMsj msj)
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            //currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            actualizarLista();
            accesibilidadWindow = true;
            if (!string.IsNullOrEmpty(msj.tokenRespuesta))
            {
                _tokenEnvioPadre = msj.tokenRespuesta;
            }
            if (!string.IsNullOrEmpty(msj.tokenRespuestaDetalle))
            {

                _tokenRecepcionSubMenu = msj.tokenRespuestaDetalle;
            }

            inicializacionTerminada();
            permisos();
            Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            //guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAllEncargos(currentEncargo.idencargo));

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
            IndiceMsj elemento = new IndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.tipoCarpetaModelo = currentEntidad;//Para el caso de  edicion de programas
            elemento.listaTipoCarpetaModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRecepcionSubMenuDetalle = tokenRecepcionSubMenu;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionCierrePreView;
            elemento.fuenteLlamado = fuenteLlamado; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        public void enviarPreVistaMensaje()
        {
            //Se crea el mensaje
            IndiceMsj elemento = new IndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.tipoCarpetaModelo = currentEntidad;//Para el caso de  edicion de programas
            elemento.listaTipoCarpetaModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionCierrePreView;
            elemento.fuenteLlamado = fuenteLlamado; //no se utilizaa
            Messenger.Default.Send(elemento,tokenEnvioDatosAVistaPreview);
        }

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EDPlanIndiceMainModel.TypeName = null;
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
                    //if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    //{
                    //    actualizarLista();
                    //}

                    //enviarMensajeHabilitar();
                    //controlVentanaCrearMensaje
                    break;
                case 9://Desplazamiento a ver el detalle del usuario
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
            Messenger.Default.Unregister<int>(this, tokenRecepcionSubMenu);
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
            currentEntidad = new TipoCarpetaModelo(currentEncargo);
            EDPlanIndiceMainModel.TypeName = "TipoCarpetaModeloCrearview";
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
                    EDPlanIndiceMainModel.TypeName = "TipoCarpetaModeloEditarView";
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
            // ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 3;
                    EDPlanIndiceMainModel.TypeName = "TipoCarpetaModeloConsultarView";
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

            if (!(currentEntidad == null))
            {
                accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComando();
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        int indice = 0;
                        if (currentEntidad.indiceCarpeta > 0)
                        {
                            indice = 2;
                        }
                        else
                        {
                            indice = 0;
                        }
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                        switch (indice)
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 0:
                                //Puede borrarse por completo
                                switch (TipoCarpetaModelo.Delete(currentEntidad))
                                {
                                    case -2:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No se pudo eliminar registros dependientes ", "intentelo en otro momento");
                                        //Hay error en el procedimiento
                                        break;
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                        break;
                                    case 0:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "El registro estaba vacio ", "no puede eliminarse por ese motivo");
                                        break;
                                    case 1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                        actualizarLista();
                                        currentEntidad = new TipoCarpetaModelo();
                                        break;
                                }
                                break;
                            default:
                                finComando();
                                await dlg.ShowMessageAsync(this, "No puede eliminarse ", "porque hay papeles referenciados");
                                break;
                        }
                    }
                    else
                    {
                        //Evaluar que registros pueden eliminarse
                        ObservableCollection<TipoCarpetaModelo> temporal = new ObservableCollection<TipoCarpetaModelo>();
                        foreach (TipoCarpetaModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                int indice = 0;
                                if (currentEntidad.indiceCarpeta > 0)
                                {
                                    indice = 2;
                                }
                                else
                                {
                                    indice = 0;
                                }
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                                switch (indice)
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al consultar la carpeta " + item.descripcion, "intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    default:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse la carpeta" + item.descripcion, "porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (TipoCarpetaModelo.Delete(temporal))
                            {
                                case -2:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "No se pudo eliminar registros dependientes ", "intentelo en otro momento");
                                    //Hay error en el procedimiento
                                    break;
                                case -1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                    break;
                                case 0:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Los registros estaban estaba vacio ", "no puede eliminarse por ese motivo");
                                    break;
                                case 1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                    actualizarLista();
                                    currentEntidad = new TipoCarpetaModelo();
                                    break;
                                case 2:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Algunos  registros no se han podido eliminar ", "");
                                    actualizarLista();
                                    currentEntidad = new TipoCarpetaModelo();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            finComando();
        }


        public async void BorrarLogico()
        {

            if (!(currentEntidad == null))
            {
                accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse y se incluirá a los registros dependientes", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComando();
                    //Repite el  ciclo para evitar errores

                    if (lista.Where(x => x.IsSelected).Count() == 1)
                    {
                        int indice = 0;
                        if (currentEntidad.indiceCarpeta > 0)
                        {
                            indice = 2;
                        }
                        else
                        {
                            indice = 0;
                        }
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                        switch (indice)
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 0:
                                //Puede borrarse por completo
                                switch (TipoCarpetaModelo.DeleteBorradoLogico(currentEntidad))
                                {
                                    case -2:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No se pudo eliminar registros dependientes ", "intentelo en otro momento");
                                        //Hay error en el procedimiento
                                        break;
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                        break;
                                    case 0:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "El registro estaba vacio ", "no puede eliminarse por ese motivo");
                                        break;
                                    case 1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                        actualizarLista();
                                        currentEntidad = new TipoCarpetaModelo();
                                        break;
                                }
                                break;
                            default:
                                finComando();
                                await dlg.ShowMessageAsync(this, "No puede eliminarse ", "porque hay papeles referenciados");
                                break;
                        }
                    }
                    else
                    {
                        //Evaluar que registros pueden eliminarse
                        ObservableCollection<TipoCarpetaModelo> temporal = new ObservableCollection<TipoCarpetaModelo>();
                        foreach (TipoCarpetaModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                int indice = 0;
                                if (currentEntidad.indiceCarpeta > 0)
                                {
                                    indice = 2;
                                }
                                else
                                {
                                    indice = 0;
                                }
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                                switch (indice)
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al consultar la carpeta " + item.descripcion, "intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    default:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse la carpeta" + item.descripcion, "porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (TipoCarpetaModelo.DeleteBorradoLogico(temporal))
                            {
                                case -2:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "No se pudo eliminar registros dependientes ", "intentelo en otro momento");
                                    //Hay error en el procedimiento
                                    break;
                                case -1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                    break;
                                case 0:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Los registros estaba estaba vacio ", "no puede eliminarse por ese motivo");
                                    break;
                                case 1:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Se borro el registro ", "");
                                    actualizarLista();
                                    currentEntidad = new TipoCarpetaModelo();
                                    break;
                                case 2:
                                    finComando();
                                    await dlg.ShowMessageAsync(this, "Algunos  registros no se han podido eliminar ", "");
                                    actualizarLista();
                                    currentEntidad = new TipoCarpetaModelo();
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            finComando();
        }


        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.id == 0);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<TipoCarpetaModelo> listaEntidad)
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
                    return currentEntidad.id != 0;
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
            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            copiarCommand = new RelayCommand(Importar);
            DoubleClickCommand = new RelayCommand(Consultar);
            SelectionChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                //listaDetalles = entidad.listaBitacora;
            });
            detalleCommand = new RelayCommand(detalleIndice, CanCommand);

            vistaCommand = new RelayCommand(VistaProgramaEjecucion, CanCommand);

            ImportarCommand = new RelayCommand(Importar, null);//ok
        }

        private void RegisterCommandsDocumentacion()
        {
            //Aplica para la  opcion de documentacion

            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(ConsultarDocumentacion, CanCommand);
            copiarCommand = new RelayCommand(Importar);
            DoubleClickCommand = new RelayCommand(ConsultarDocumentacion);
            SelectionChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                //listaDetalles = entidad.listaBitacora;
            });
            detalleCommand = new RelayCommand(detalleIndiceDocumentacion, CanCommand);

            vistaCommand = new RelayCommand(VistaProgramaEjecucion, CanCommand);

            ImportarCommand = new RelayCommand(Importar, null);//ok
        }

        private void RegisterCommandsCierre()
        {
            //Aplica para la  opcion de documentacion

            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(ConsultarCierre, CanCommand);
            copiarCommand = new RelayCommand(Importar);
            DoubleClickCommand = new RelayCommand(Nada);
            SelectionChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                //listaDetalles = entidad.listaBitacora;
            });
            detalleCommand = new RelayCommand(detalleIndiceDocumentacion, CanCommand);

            vistaCommand = new RelayCommand(VistaProgramaEjecucion, CanCommand);

            ImportarCommand = new RelayCommand(Importar, null);//ok


            terminarPapelCommand = new RelayCommand(cerrarPrograma, CanTerminar);
            supervisarCommand = new RelayCommand(supervisarPrograma, CanSupervisar);
            aprobarCommand = new RelayCommand(aprobarPrograma, CanAprobar);
            agendaCommand = new RelayCommand(tareasPrograma, CanCommand);

        }


        private bool CanEditar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty);
            }
        }

        private bool CanBorrar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty);
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
                return (((!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                    || (string.IsNullOrEmpty(currentEntidad.usuariosuperviso)))
                    && ((string.IsNullOrEmpty(currentEntidad.usuarioaprobo)))
                    && (currentEntidad.IndiceItemsTotales == 100));
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
                return ((!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                    && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                    && (currentEntidad.IndiceItemsTotales == 100));
            }
        }

        private void tareasPrograma()
        {
            throw new NotImplementedException();
        }

        private async void aprobarPrograma()
        {
            if (!(currentEntidad == null))
            {
                comando = 12;//Supervisar
                iniciarComando();

                EDPlanIndiceMainModel.TypeName = "IndiceModeloAprobarView";
                #region Configuracion
                currentEntidad.usuarioModelo = usuarioModelo;
                #endregion
                enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro ", "");
            }

        }

        private async void supervisarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    comando = 11;//Supervisar
                    iniciarComando();

                    EDPlanIndiceMainModel.TypeName = "IndiceModeloSupervisarView";
                    #region Configuracion
                    currentEntidad.usuarioModelo = usuarioModelo;
                    #endregion
                    enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro", "");
                }

            }
        }

        private bool CanTerminar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return ((string.IsNullOrEmpty(currentEntidad.usuariocerro))
                && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                && (currentEntidad.IndiceItemsTotales==100));
            }
        }

        private async void cerrarPrograma()
        {

            if (!(currentEntidad == null))
            {
                iniciarComando();
                //decimal avance = (decimal)currentEntidad.indiceEjecucionprograma;
                //int estadoDocumento = BitacoraModelo.evaluarEstado(currentEntidad,4,"MATRIZRIESGOS");//Etapa 4 es cerrado
                int estadoDocumento = TipoCarpetaModelo.evaluarCerrar(currentEntidad);
                if (estadoDocumento == 1) //Hay cero procedimientos diferentes a iniciados
                {
                    if (currentEntidad.IndiceItemsTotales== 100)
                    {
                        comando = 10;//Referenciacion
                        iniciarComando();

                        EDPlanIndiceMainModel.TypeName = "IndiceModeloCerrarView";
                        #region Configuracion
                        currentEntidad.usuarioModelo = usuarioModelo;
                        #endregion
                        enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "Debe referenciar cada item del índice ", "antes de cerrarlo");
                    }
                }
                else
                {
                    if (estadoDocumento != -1)
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "El documento ya esta cerrado", "No puede cerrarse dos veces");
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "Se produjo un error", "intentelo mas tarde");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a cerrar", "", MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a cerrar", "");
            }
            finComando();
        }
        private void Nada()
        {
           // throw new NotImplementedException();
           //Para anular el doble click
        }

        private async void ConsultarCierre()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 3;
                    iniciarComando();

                    EDPlanIndiceMainModel.TypeName = "CierreTipoCarpetaModeloConsultarView";
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

        private async void detalleIndiceDocumentacion()
        {
            //Para guardar lo que esta en la  pantalla
            //ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 9;
                    iniciarComando();

                    int indice= -1;
                    for (int i = 0; i < listaVistas.Count; i++)
                    {
                        if (listaVistas[i].ViewDisplay.Contains(tablaDetalle))
                        {
                            indice = i;
                            i = listaVistas.Count;
                        }
                    }
                    if (indice != -1)
                    {
                        listaVistas[indice].NavigateExecute(); //Repite para inicializar desde documentacion
                        enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                        listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAllDocumentacion());
                        Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Error en la tabla llamada en menuIndiceDetalle", "");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro para ver el detalle", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para ver el detalle", "");
            }
        }


        private async void ConsultarDocumentacion()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 3;
                    iniciarComando();

                    EDPlanIndiceMainModel.TypeName = "DocumentacionTipoCarpetaModeloConsultarView";
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

        private async void VistaProgramaEjecucion()
        {
            if (!(currentEntidad == null))
            {
                comando = 5;
                iniciarComando();

                EDPlanIndiceMainModel.TypeName = "IndiceEncargoPlanVistaPreviaView";
                enviarPreVistaMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        private async void detalleIndice()
        {
            //Para guardar lo que esta en la  pantalla
            //ControlCambioLista(true);
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 9;
                    iniciarComando();
                    int indice = -1;
                    for (int i = 0; i < listaVistas.Count; i++)
                    {
                        if (listaVistas[i].ViewDisplay.Contains(tablaDetalle))
                        {
                            indice = i;
                            i = listaVistas.Count;
                        }
                    }
                    if (indice != -1)
                    {
                        listaVistas[indice].NavigateExecute();
                        enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                        listaVistas = new ObservableCollection<menuIndiceDetalle>(menuIndiceDetalle.GetAll());
                        Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Error en la tabla llamada en menuIndiceDetalle", "");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro para ver el detalle", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para ver el detalle", "");
            }
        }

        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }


        public async void Importar()
        {
            //Evaluar  si procede la importacion
            iniciarComando();
            switch (TipoCarpetaModelo.evaluarImportacion(currentEncargo.idencargo))
            {
                case 0:
                    finComando();
                    await dlg.ShowMessageAsync(this, "Ya creó todas las carpetas posibles", "no puede importarse por ese motivo");
                    break;
                case -1:
                    finComando();
                    await dlg.ShowMessageAsync(this, "Hubo un error en  la comunicación", "no puede importarse por ese motivo");
                    break;
                default:
                    #region Proceso de importacion
                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Plantillas",
                        FirstAuxiliaryButtonText = "Cancelar",
                        NegativeButtonText = "Encargos",
                    };
                    finComando();
                    MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione la fuente para importar", "Para los encargos se toman de las carpetas de años anteriores",
                    MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);
                    iniciarComando();
                    if (result == MessageDialogResult.Affirmative)
                    {

                        comando = 6;//Importara de las plantillas
                        iniciarComando();


                        EDPlanIndiceMainModel.TypeName = "TipoCarpetaModeloImportarView";
                        currentEntidad = currentEntidad = new TipoCarpetaModelo(currentEncargo);
                        activarCaptura = true;
                        enviarMensaje();
                    }
                    else
                    {
                        if (result == MessageDialogResult.Negative)
                        {
                            comando = 7;//Importa de los encargos de  años anteriores
                            iniciarComando();


                            EDPlanIndiceMainModel.TypeName = "TipoCarpetaModeloImportarView";
                            EDPlanIndiceMainModel.TypeName = "TipoCarpetaModeloImportarView";
                            currentEntidad = new TipoCarpetaModelo(currentEncargo);
                            activarCaptura = true;
                            enviarMensaje();
                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Canceló operación", "");

                        }
                    }
                    #endregion fin de proceso
                    break;
        }
    }


        private void Buscar()
        {
            throw new NotImplementedException();
        }

        public void enviarMensajeCargarCatalogo()
        {
            //Se crea el mensaje
            CargarArchivosMensajeModal elemento = new CargarArchivosMensajeModal();
            elemento.usuarioModelo = usuarioModelo;
            elemento.TipoArchivoACargar = TipoArchivoCargar.Balance;
            elemento.currentCliente = ClienteModelo.GetRegistro(currentEncargo.idnitcliente);
            elemento.currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargoCapaDatos(currentEncargo.idencargo);
            elemento.encargoModelo = currentEncargo;
            elemento.TokenAUtilizar = tokenRecepcionDatosCarga;
            Messenger.Default.Send(elemento, tokenEnvioDatosCarga);
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
            switch (origenLlamada)
            {
                case "EncargoPlanIndice"://Llamada desde documentacion plan indice
                    Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
                    break;
                case "EncargoDocumentacion"://Documentacion carpetas
                    Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
                    break;
                case "EncargoCierre": //Encargos cierre
                    Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
                    break;
                case "SupervisionIndice": //Encargos cierre
                    Messenger.Default.Send<ComandoTerminado>(cursor, tokenEnvioPadre);
                    break;
                case "Documentos"://Llamada desde el principal documentos consulta
                    Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
                    break;
                case "DocumentosImpresion"://Llamada desde el principal documentos impresion
                    Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
                    break;
            }
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
            Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));
            accesibilidadWindow = false;
            //if(comando!=9)
            //{ 
            //enviarMensajeInhabilitar();
            //}
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
            //if (comando != 9)
            //{
            //    enviarMensajeHabilitar();
            //}
        }


        #endregion Fin de comando

    }
}