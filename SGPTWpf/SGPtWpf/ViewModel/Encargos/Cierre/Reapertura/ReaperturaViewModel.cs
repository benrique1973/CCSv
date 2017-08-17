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
using System.Threading.Tasks;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cierre.Reapertura
{

    public sealed class ReaperturaViewModel : ViewModeloBase
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

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
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

        private static int comando = 0;

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

        #region tokenEnvioDatosAHijo

        private string _tokenEnvioDatosAHijo;
        private string tokenEnvioDatosAHijo
        {
            get { return _tokenEnvioDatosAHijo; }
            set { _tokenEnvioDatosAHijo = value; }
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

        #region tokenEnvioPadre

        private string _tokenEnvioPadre;
        private string tokenEnvioPadre
        {
            get { return _tokenEnvioPadre; }
            set { _tokenEnvioPadre = value; }
        }

        #endregion

        #region ViewModel Properties : SelectedItems

        public const string SelectedItemsPropertyName = "SelectedItems";

        private ObservableCollection<EncargoModelo> _SelectedItems;

        public ObservableCollection<EncargoModelo> SelectedItems
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

        private ObservableCollection<menuMatrizRiesgoDetalle> _listaVistas;

        public ObservableCollection<menuMatrizRiesgoDetalle> listaVistas
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

        private ObservableCollection<UniversalPT> _lista;

        public ObservableCollection<UniversalPT> lista
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

        #region Entidades

        #region ViewModel Property : currentEntidad Catalogo Modelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private UniversalPT _currentEntidad;

        public UniversalPT currentEntidad
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

        private Visibility _visibilidadMImportar = Visibility.Hidden;

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

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand copiarCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<UniversalPT> SelectionChangedCommand { get; set; }
        public RelayCommand detalleCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand vistaCommand { get; set; }
        public RelayCommand ImportarCommand { get; set; }
        #endregion

        #region EncargosMainModel

        private MainModel _mainModel = null;

        public MainModel EncargosMainModel
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
        public ReaperturaViewModel()
        {
        }

        public ReaperturaViewModel(string origen)
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            _dialogCoordinator = new DialogCoordinator();
            _origenLlamada = origen;
            configuracionDialogo = new MetroDialogSettings();

            switch (origen)
            {
                case "EncargosCierreReapertura":
                    #region tokens
                    _tokenRecepcionPadre = "Reapertura de papeles" + "CierreEncargo"; //Permite captar los mensajes del  menú planificacion
                    _tokenEnvioDatosAHijo = "datosEDReaperturaEncargos";//Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerReaperturaEncargos";
                    _tokenEnvioPadre = "EncargoReaperturaEncargos";
                    #endregion

                    #region  menu

                    _visibilidadMCrear = Visibility.Visible;
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
                default:
                     break;
            }
                    
            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar
            _accesibilidadWindow = false;
            _IsSelected = false;
            _cursorWindow = Cursors.Hand;

            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));

            currentEncargo = new EncargoModelo();
            currentEntidad = new UniversalPT();
            currentSistemaContable = null;
            RegisterCommands();
            comando = 0;
            dlg = new DialogCoordinator();
            _lista = new ObservableCollection<UniversalPT>();//Lista vacia no se conoce el encargo y el cliente
            _lista = new ObservableCollection<UniversalPT>();
            EncargosMainModel = new MainModel();
            listaVistas = new ObservableCollection<menuMatrizRiesgoDetalle>(menuMatrizRiesgoDetalle.GetAll());

            //
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));


        }

       private void ControlRecepcionDatos(EncargosDatosMsj msj)
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            //currentEntidad = msj.encargoModelo;
            //currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            //actualizarLista();
            accesibilidadWindow = true;
            actualizarlista();
            inicializacionTerminada();
            Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);

        }
        private void actualizarlista()
        {
            //guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<UniversalPT>(UniversalPT.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<UniversalPT>(UniversalPT.GetAllContenido(currentEncargo.idencargo,usuarioModelo));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de carpetas" + e, "");
                    lista = new ObservableCollection<UniversalPT>();
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
            CierreEncargoMsj elemento = new CierreEncargoMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            //elemento.lista = lista;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 1; //Comando desde el principal
            elemento.tokenRespuesta = tokenRecepcionHijo;
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }


        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EncargosMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarlista();
                    }
                    break;
                case 2:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarlista();
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
                        actualizarlista();
                    }
                    accesibilidadWindow = true;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarlista();
                    }
                    break;
                case 7:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarlista();
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
                        actualizarlista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                case 10://Cierre de programa
                    //if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    //{
                    //    actualizarLista();
                    //}
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
        public async void Reabrir()//Reapertura
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

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Reabrirá el documento y los  sub-registros", "¿Desea reabrir el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    if (string.IsNullOrEmpty(currentEncargo.fechaaprobacion))

                    {
                        iniciarComando();
                        //Repite el  ciclo para evitar errores
                        //string commandString;
                        int resultado = 0;
                        switch (currentEntidad.idTpt)
                        {
                            case 0:
                                break;
                            case 1:
                                //Matriz de riesgo
                                resultado = MatrizRiesgoModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.matrizriesgos SET  usuarioaprobo ='{0}', fechacierre ='{1}',"+
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', "+
                                //    " etapapapel ='{6}' WHERE idmr={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                            case 2:
                                await mensajeAutoCerrado("Opción no habilitada", "Pendiente de programacion papeles", 3);
                                //Papeles
                                //resultado = PapelesModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.papeles SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                //    " etapapapel ='{6}' WHERE idpapeles={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                            case 3:
                                await mensajeAutoCerrado("Opción no habilitada", "Pendiente de programacion analisis financiero", 3);
                                //Matriz de analisis financiero
                                //resultado = MatrizAnalisisFinancieroModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.matrizanalisisfinanciero SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                //    " etapapapel ='{6}' WHERE idmaf={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                            case 4://Programas
                                resultado = ProgramaModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.programas SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                //    " etapapapel ='{6}' WHERE idprograma={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                            case 5://Repositorio
                                resultado = RepositorioModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.programas SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                //    " etapapapel ='{6}' WHERE idrepositorio={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                            case 6://Cedulas
                                resultado = CedulaModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.cedulas SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                //    " etapapapel ='{6}' WHERE idcedula={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                            case 7://Tipo de carpeta
                                resultado = TipoCarpetaModelo.Reapertura(currentEntidad);
                                //commandString = String.Format("UPDATE sgpt.tipocarpeta SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                //    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                //    " etapapapel ='{6}' WHERE idtc={7};",
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    string.Empty,
                                //    "P",//Proceso
                                //    currentEntidad.idOrigenUpt);
                                //currentEntidad.fechaaprobacion = string.Empty;
                                //currentEntidad.fechacierre = string.Empty;
                                //currentEntidad.fechasupervision = string.Empty;
                                //currentEntidad.usuarioaprobo = string.Empty;
                                //currentEntidad.usuariocerro = string.Empty;
                                //currentEntidad.usuariosuperviso = string.Empty;
                                //currentEntidad.etapapapel = "En proceso";
                                break;
                        }

                        //Resultados
                        switch (resultado)
                        {
                            case 0://No se pudo insertar
                                await mensajeAutoCerrado("No ha sido posible reabrir el registro", "", 2);
                                break;
                            case 1://Se inserto con éxito
                                await mensajeAutoCerrado("Documento reabierto", "Puede modificarlo", 2);
                                break;
                            case -1://No se pudo insertar
                                await mensajeAutoCerrado("Se genero un  error en la operación", "", 2);
                                break;
                        }

                    }
                    else
                    {
                        await mensajeAutoCerrado("No procede la reapertura porque  el encargo ya esta cerrado", "Ya no es posible reabrir", 2);
                    }
                    }
                else
                {
                    await mensajeAutoCerrado("Canceló la eliminacion", "", 2);
                }
            }
            else
            {
                await mensajeAutoCerrado("Debe seleccionar el registro a eliminar", "", 2);
            }
            finComando();
        }
        #endregion
        public void Editar()
        {
        }
        public void Consultar()
        {
        }

        public void Borrar()
        {
        }


        public void Borrarlógico()
        {


        }


        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.idencargo == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.fechacierre);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<EncargoModelo> listaEntidad)
        {
            //lista = listaEntidad;
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
                    return currentEntidad.idencargo != 0;
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
            NuevoCommand = new RelayCommand(Reabrir, CanReabrir);//ok
            EditarCommand = new RelayCommand(Editar, CanEditar);
            BorrarCommand = new RelayCommand(Borrar, CanBorrar);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            DoubleClickCommand = new RelayCommand(Consultar);
            SelectionChangedCommand = new RelayCommand<UniversalPT>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                //listaDetalles = entidad.listaBitacora;
            });
            terminarPapelCommand = new RelayCommand(cerrarPrograma, CanTerminar);
            referenciarCommand = new RelayCommand(referenciarPrograma, CanCommand);
            supervisarCommand = new RelayCommand(supervisarPrograma, CanSupervisar);
            aprobarCommand = new RelayCommand(aprobarPrograma, CanAprobar);
            agendaCommand = new RelayCommand(tareasPrograma, CanCommand);
            vistaCommand = new RelayCommand(vistaImpresion, CanCommand);
            ImportarCommand = new RelayCommand(nada, CanCommand);

        }

        private bool CanReabrir()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (((!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                    || (!string.IsNullOrEmpty(currentEntidad.usuariosuperviso)))
                    || ((!string.IsNullOrEmpty(currentEntidad.usuarioaprobo))));
            }
        }

        private void nada()
        {
            throw new NotImplementedException();
        }

        private async void vistaImpresion()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                comando = 12;//Supervisar
                EncargosMainModel.TypeName = "EncargoModeloVistaView";
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
                    || (!string.IsNullOrEmpty(currentEntidad.usuariosuperviso)))
                    && ((string.IsNullOrEmpty(currentEntidad.usuarioaprobo))));
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
                    && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso)));
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
                iniciarComando();
                comando = 12;//Supervisar
                EncargosMainModel.TypeName = "EncargoModeloAprobarView";
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
                    iniciarComando();
                    comando = 11;//Supervisar
                    EncargosMainModel.TypeName = "EncargoModeloSupervisarView";
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
                && (string.IsNullOrEmpty(currentEntidad.usuariosuperviso)));
            }
        }

        private async void referenciarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 8;//Referenciacion
                    EncargosMainModel.TypeName = "EncargoModeloReferenciarView";
                    #region Configuracion
                    currentEntidad.usuarioModelo = usuarioModelo;
                    #endregion
                    enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a referenciar", "");
                }

            }
        }

        private void cerrarPrograma()
        {

        }


        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }

        private void Buscar()
        {
            throw new NotImplementedException();
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