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
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPtmvvm.Mensajes;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias
{

    public sealed class SumariasViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region tablaDetalle

        private string _tablaDetalle;
        private string tablaDetalle
        {
            get { return _tablaDetalle; }
            set { _tablaDetalle = value; }
        }

        #endregion

        #region tablaResumen

        private string _tablaResumen;
        private string tablaResumen
        {
            get { return _tablaResumen; }
            set { _tablaResumen = value; }
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

        #region idtc //Sirve para diferenciar las fuentas de  la llamada para las vistas
        //Tipo de  cedulas
        //1;"Sumaria";"A";TRUE
        //2;"Analítica";"A";TRUE
        //3;"De detalle";"A";TRUE
        //4;"De variaciones";"A";TRUE
        //5;"Cumplimiento legal";"A";TRUE
        //6;"Hallazgos";"A";TRUE
        //7;"Notas";"A";TRUE
        //8;"Correspondencia";"A";TRUE
        //9;"Reuniones";"A";TRUE
        //10;"Contactos";"A";TRUE
        //11;"Expediente";"A";TRUE
        //12;"Cronograma";"A";TRUE
        //13;"Marcas";"A";TRUE
        //14;"Confirmaciones";"A";TRUE
        //15;"Ajustes y reclasificaciones";"A";TRUE
        //16;"Expediente";"A";TRUE
        //17;"Conclusiones";"A";TRUE
        //18;"Otras";"A";FALSE
        //Indica la clase de documento
        private int _idtc;
        private int idtc
        {
            get { return _idtc; }
            set { _idtc = value; }
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

        #region visibilidadMResumen

        public const string visibilidadMResumenPropertyName = "visibilidadMResumen";

        private Visibility _visibilidadMResumen = Visibility.Hidden;

        public Visibility visibilidadMResumen
        {
            get
            {
                return _visibilidadMResumen;
            }

            set
            {
                if (_visibilidadMResumen == value)
                {
                    return;
                }

                _visibilidadMResumen = value;
                RaisePropertyChanged(visibilidadMResumenPropertyName);
            }
        }

        #endregion
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

        private ObservableCollection<menuCedulaDetalle> _listaVistas;

        public ObservableCollection<menuCedulaDetalle> listaVistas
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

        #region ViewModel Property : currentEntidad Catalogo Modelo

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
        public RelayCommand<CedulaModelo> SelectionChangedCommand { get; set; }
        public RelayCommand detalleCommand { get; set; }

        public RelayCommand ResumenCommand { get; set; }

        public RelayCommand vistaCommand { get; set; }
        public RelayCommand ImportarCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }

        #endregion

        #region ECMainModel

        private MainModel _mainModel = null;

        public MainModel ECMainModel
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
        public SumariasViewModel()//Caso Encargo/PlanIndice
        {
        }

        //Llamado desde documentacion
        public SumariasViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;
            _tablaDetalle = string.Empty;
            _tokenEnvioPadre = string.Empty;
            _tokenRecepcionSubMenu = string.Empty;

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            switch (origen)
            {
                case "cedulasSumarias":
                    fuenteLlamado = 1;
                    _idtc = 1;//Sumarias
                    //2;"Analítica";"A";TRUE
                    //3;"De detalle";"A";TRUE
                    //4;"De variaciones";"A";TRUE
                    //5;"Cumplimiento legal";"A";TRUE
                    //6;"Hallazgos";"A";TRUE
                    //7;"Notas";"A";TRUE
                    //8;"Correspondencia";"A";TRUE
                    //9;"Reuniones";"A";TRUE
                    //10;"Contactos";"A";TRUE
                    //11;"Expediente";"A";TRUE
                    //12;"Cronograma";"A";TRUE
                    //13;"Marcas";"A";TRUE
                    //14;"Confirmaciones";"A";TRUE
                    //15;"Ajustes y reclasificaciones";"A";TRUE
                    //16;"Expediente";"A";TRUE
                    //17;"Conclusiones";"A";TRUE
                    //18;"Agenda";"A";FALSE
                    //19: Otras
                    //Indica la clase de documento
                    #region tokens

                    _tokenRecepcionPadre = "Sumarias" + "Cédulas";//Permite captar los mensajes del  menú planificacion, corresponde a Indices

                    _tokenRecepcionCierrePreView = "EncargoCedulasSumarias";//Sirve tanto para los programas en vista previa como para el controllador;

                    _tokenEnvioDatosAHijo = "datosEncargoCedulasSumarias";//Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosEncargoCedulasSumariasController";

                    #endregion
                   
                    RegisterCommands();
                    _tablaDetalle = "detallecedulas";
                    _tablaResumen = "resumenSumariascedulas";

                    #region  menu

                    _visibilidadMCrear = Visibility.Visible;
                    _visibilidadMEditar = Visibility.Visible;
                    _visibilidadMBorrar = Visibility.Visible;
                    _visibilidadMConsulta = Visibility.Visible;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Visible;

                    _visibilidadMCerrar = Visibility.Visible;
                    _visibilidadMSupervisar = Visibility.Visible;
                    _visibilidadMAprobar = Visibility.Visible;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadMResumen = Visibility.Visible;
                    #endregion

                    break;
                case "cedulasAnaliticas":
                    fuenteLlamado = 1;
                    _idtc = 2;//Sumarias
                    //2;"Analítica";"A";TRUE
                    //3;"De detalle";"A";TRUE
                    //4;"De variaciones";"A";TRUE
                    //5;"Cumplimiento legal";"A";TRUE
                    //6;"Hallazgos";"A";TRUE
                    //7;"Notas";"A";TRUE
                    //8;"Correspondencia";"A";TRUE
                    //9;"Reuniones";"A";TRUE
                    //10;"Contactos";"A";TRUE
                    //11;"Expediente";"A";TRUE
                    //12;"Cronograma";"A";TRUE
                    //13;"Marcas";"A";TRUE
                    //14;"Confirmaciones";"A";TRUE
                    //15;"Ajustes y reclasificaciones";"A";TRUE
                    //16;"Expediente";"A";TRUE
                    //17;"Conclusiones";"A";TRUE
                    //18;"Agenda";"A";FALSE
                    //19: Otras
                    //Indica la clase de documento
                    #region tokens

                    _tokenRecepcionPadre = "Analíticas" + "Cédulas";//Permite captar los mensajes del  menú planificacion, corresponde a Indices

                    _tokenRecepcionCierrePreView = "EncargoCedulasAnalíticas";//Sirve tanto para los programas en vista previa como para el controllador;

                    _tokenEnvioDatosAHijo = "datosEncargoCedulasAnalíticas";//Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosEncargoCedulasAnalíticasController";

                    #endregion

                    RegisterCommands();
                    _tablaDetalle = "detallecedulasAnaliticas";
                    _tablaResumen = "resumenAnaliticascedulas";

                    #region  menu

                    _visibilidadMCrear = Visibility.Visible;
                    _visibilidadMEditar = Visibility.Visible;
                    _visibilidadMBorrar = Visibility.Visible;
                    _visibilidadMConsulta = Visibility.Visible;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Visible;

                    _visibilidadMCerrar = Visibility.Visible;
                    _visibilidadMSupervisar = Visibility.Visible;
                    _visibilidadMAprobar = Visibility.Visible;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadMResumen = Visibility.Collapsed;
                    #endregion

                    break;
                    /* case "cedulasHallazgos":
                        #region hallazgos

                        fuenteLlamado = 1;
                        _idtc = 6;//Sumarias
                        //2;"Analítica";"A";TRUE
                        //3;"De detalle";"A";TRUE
                        //4;"De variaciones";"A";TRUE
                        //5;"Cumplimiento legal";"A";TRUE
                        //6;"Hallazgos";"A";TRUE
                        //7;"Notas";"A";TRUE
                        //8;"Correspondencia";"A";TRUE
                        //9;"Reuniones";"A";TRUE
                        //10;"Contactos";"A";TRUE
                        //11;"Expediente";"A";TRUE
                        //12;"Cronograma";"A";TRUE
                        //13;"Marcas";"A";TRUE
                        //14;"Confirmaciones";"A";TRUE
                        //15;"Ajustes y reclasificaciones";"A";TRUE
                        //16;"Expediente";"A";TRUE
                        //17;"Conclusiones";"A";TRUE
                        //18;"Agenda";"A";FALSE
                        //19: Otras
                        //Indica la clase de documento

                        #region tokens

                        _tokenRecepcionPadre = "Hallazgos" + "Cédulas";//Permite captar los mensajes del  menú planificacion, corresponde a Indices

                        _tokenEnvioDatosAHijo = "datosEncargoCedulasHallazgosMenuPrincipal";//Para control de los datos que  remite programas a sub-ventanas

                        _tokenRecepcionHijo = "datosEncargoCedulasHallazgosControllerMenuPrincipal";

                        _tokenRecepcionCierrePreView = "EncargoCedulasHallazgosMenuPrincipal";//Sirve tanto para los programas en vista previa como para el controllador;

                        #endregion

                        _tablaDetalle = "Hallazgos";
                        _tablaResumen = "resumenHallazgoscedulas";
                        RegisterCommands();

                        #region  menu

                        _visibilidadMCrear = Visibility.Visible;
                        _visibilidadMEditar = Visibility.Visible;
                        _visibilidadMBorrar = Visibility.Visible;
                        _visibilidadMConsulta = Visibility.Visible;
                        _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                        _visibilidadMRegresar = Visibility.Collapsed;
                        _visibilidadMVista = Visibility.Visible;
                        _visibilidadMImportar = Visibility.Collapsed;
                        _visibilidadMDetalle = Visibility.Visible;

                        _visibilidadMCerrar = Visibility.Visible;
                        _visibilidadMSupervisar = Visibility.Visible;
                        _visibilidadMAprobar = Visibility.Visible;
                        _visibilidadMTask = Visibility.Collapsed;
                        _visibilidadMImprimir = Visibility.Collapsed;
                        _visibilidadMResumen = Visibility.Collapsed;
                        #endregion

                        #endregion hallazgos

                        break;*/
            }



            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar

            _accesibilidadWindow = false;
            _IsSelected = false;

            _cursorWindow = Cursors.Hand;

            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            _comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<CedulaModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            ECMainModel = new MainModel();
            listaVistas = new ObservableCollection<menuCedulaDetalle>(menuCedulaDetalle.GetAll());

            //Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
        }

        private void ControlRecepcionDatos(EncargosDatosMsj msj)
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            //currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            actualizarLista();
            accesibilidadWindow = true;
            //tablaDetalle = msj.tabla;
            _tokenEnvioPadre = msj.tokenRespuesta;
            _tokenRecepcionSubMenu = msj.tokenRespuestaDetalle;
            Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);
            inicializacionTerminada();

        }


        private void actualizarLista()
        {
            //guardarlista();
            try
            {
                lista = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAll(currentEncargo,idtc));

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
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            elemento.listaMaestroModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionCierrePreView;
            elemento.tokenRecepcionSubMenuDetalle = tokenRecepcionSubMenu;
            elemento.fuenteLlamado = fuenteLlamado; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }


        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            ECMainModel.TypeName = null;
            switch (comando)
            {
                case 1://Registro nuevo
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }

                    break;
                case 2://Edicion  de registro
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 3://Consulta
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
            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad = new CedulaModelo(currentEncargo, usuarioModelo);
            currentEntidad.idtc = idtc;//Se asigna el tipo de cedula a utilizar
            switch (idtc)//Depende del tipo de cedula
            {
                case 1:
                ECMainModel.TypeName = "CedulaModeloCrearview";
                break;
                case 2:
                ECMainModel.TypeName = "CedulaModeloAnaliticaCrearview";
                break;
                case 6://Cedula hallazgos
                ECMainModel.TypeName = "CedulaModeloHallazgosCrearview";
                break;
            }
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
                    currentEntidad.usuarioModelo = usuarioModelo;
                    switch (idtc)//Depende del tipo de cedula
                    {
                        
                        case 1:
                            ECMainModel.TypeName = "CedulaModeloEditarView";
                            break;
                        case 2:
                            ECMainModel.TypeName = "CedulaModeloAnaliticaEditarView";
                        break;
                    case 6://Cedula hallazgos
                            ECMainModel.TypeName = "CedulaModeloHallazgosEditarView";
                            break;
                    }

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
                    currentEntidad.usuarioModelo = usuarioModelo;
                    switch (idtc)//Depende del tipo de cedula
                    {
                        case 1:
                            ECMainModel.TypeName = "CedulaModeloConsultarView";
                            break;
                        case 2:
                            ECMainModel.TypeName = "CedulaModeloAnaliticaConsultarView";
                            break;
                        case 6://Cedula hallazgos
                            ECMainModel.TypeName = "CedulaModeloHallazgosConsultarView";
                            break;
                    }
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

                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                        switch (CedulaModelo.evaluarBorrar(currentEntidad))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 1:
                                //Puede borrarse por completo
                                switch (CedulaModelo.Delete(currentEntidad))
                                {
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
                                        currentEntidad = new CedulaModelo();
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
                        ObservableCollection<CedulaModelo> temporal = new ObservableCollection<CedulaModelo>();
                        foreach (CedulaModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                switch (CedulaModelo.evaluarBorrar(currentEntidad))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al consultar  " + item.titulocedula, "intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    default:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse " + item.titulocedula, "porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (CedulaModelo.Delete(temporal))
                            {
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
                                    currentEntidad = new CedulaModelo();
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
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                        switch (CedulaModelo.evaluarBorrar(currentEntidad))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 1:
                                //Puede borrarse por completo
                                switch (CedulaModelo.DeleteLogico(currentEntidad))
                                {
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
                                        currentEntidad = new CedulaModelo();
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
                        ObservableCollection<CedulaModelo> temporal = new ObservableCollection<CedulaModelo>();
                        foreach (CedulaModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                                switch (CedulaModelo.evaluarBorrar(currentEntidad))
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidad.id))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al consultar  " + item.titulocedula, "intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    default:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse " + item.titulocedula, "porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (CedulaModelo.DeleteBorradoLogico(temporal))
                            {
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
                                    currentEntidad = new CedulaModelo();
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
            return !(currentEntidad.idcedula == 0);
        }

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
                    return currentEntidad.idcedula != 0;
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


        private void RegisterCommands()
        {
            //Aplica para la  opcion de documentacion

            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanEditar);
            BorrarCommand = new RelayCommand(Borrar, CanBorrar);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            copiarCommand = new RelayCommand(Importar);
            DoubleClickCommand = new RelayCommand(Nada);
            SelectionChangedCommand = new RelayCommand<CedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                //listaDetalles = entidad.listaBitacora;
            });
            detalleCommand = new RelayCommand(detalleContenido, CanCommand);

            ResumenCommand = new RelayCommand(seleccionarVisita, CanResumenCommand);

            vistaCommand = new RelayCommand(vistaPapel, CanCommand);

            ImportarCommand = new RelayCommand(Importar, null);//ok


            terminarPapelCommand = new RelayCommand(cerrarPapel, CanTerminar);
            supervisarCommand = new RelayCommand(supervisarPapel, CanSupervisar);
            aprobarCommand = new RelayCommand(aprobarPapel, CanAprobar);
            agendaCommand = new RelayCommand(tareasPapel, CanCommand);
            referenciarCommand = new RelayCommand(referenciarPrograma, CanCommand);//Para guardar la referencia
        }


        private void seleccionarVisita()
        {
            //Para guardar lo que esta en la  pantalla
            //No se utiliza debido a que no existe edicion
            comando = 14;
            iniciarComando();
            #region Inicializacion de herramienta 
            currentEntidad = new CedulaModelo(currentEncargo, usuarioModelo);
            currentEntidad.idtc = idtc;//Se asigna el tipo de cedula a utilizar
            switch (idtc)//Depende del tipo de cedula
            {
                case 1:
                    ECMainModel.TypeName = "CedulaModeloSeleccionarVisitaView";
                    break;
                case 2:
                    ECMainModel.TypeName = "CedulaModeloAnaliticaSeleccionarVisitaView";
                    break;
                case 6://Cedula hallazgos
                    ECMainModel.TypeName = "CedulaModeloHallazgosSeleccionarVisitaView";
                    break;
            }

            activarCaptura = true;
            #endregion
            enviarMensaje();

        }
        private bool CanResumenCommand()
        {
            bool evaluar = false;

            if (lista == null)
            {
                return evaluar;
            }
            else
            {
                return (lista.Count>0);
            }
        }


        private async void resumenContenido(int controllerProgramaViewMensaje)
        {
            switch (controllerProgramaViewMensaje)
            {
                case 0: //cancelo;
                    ECMainModel.TypeName = null;
                    comando = 0;
                    currentEntidad = null;
                    Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
                    Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
                    finComando();
                    break;
                default:
                    //Para guardar lo que esta en la  pantalla
                    if (lista.Count(x => x.idvisita == controllerProgramaViewMensaje) > 0 ||(controllerProgramaViewMensaje==100 && lista.Count>0))
                    {
                        comando = 15;
                        iniciarComando();

                        int indice = -1;
                        for (int i = 0; i < listaVistas.Count; i++)
                        {
                            if (listaVistas[i].tabla.Contains(tablaResumen))
                            {
                                indice = i;
                                i = listaVistas.Count;
                            }
                        }
                        if (indice != -1)
                        {
                            #region Inicializacion de herramienta 
                            currentEntidad = new CedulaModelo(currentEncargo, usuarioModelo);
                            if (lista != null && lista.Count > 0)
                            {
                                if (controllerProgramaViewMensaje != 100)
                                {
                                    currentEntidad = lista.First(x => x.idvisita == controllerProgramaViewMensaje);
                                }
                                else
                                {
                                    //Toma el primer registro
                                    currentEntidad.idbalance = lista[0].idbalance;
                                    currentEntidad.idbalanceanterior = lista[0].idbalanceanterior;
                                    currentEntidad.fechabalancebalance = lista[0].fechabalancebalance;
                                    currentEntidad.fechabalancebalanceComparativo = lista[0].fechabalancebalanceComparativo;
                                    currentEntidad.idvisita= controllerProgramaViewMensaje;
                                    currentEntidad.idtc = idtc;//Se asigna el tipo de cedula a utilizar
                                }
                            }
                            #endregion

                            currentEntidad.usuarioModelo = usuarioModelo;
                            listaVistas[indice].NavigateExecute(); //Repite para inicializar desde documentacion
                            enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                            listaVistas = new ObservableCollection<menuCedulaDetalle>(menuCedulaDetalle.GetAll());
                            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
                        }
                        else
                        {
                            await mensajeAutoCerrado("Error en la tabla llamada en Cedula Detalle", "", 2);
                        }
                    }
                    else
                    {
                        if (controllerProgramaViewMensaje == 100)
                        {
                            await mensajeAutoCerrado("No hay registros para resumenes de sumarias", "Debe crear las sumarias", 2);
                        }
                        else
                        {
                            await mensajeAutoCerrado("No hay registros para esa visita", "Debe crear las sumarias para esa visita", 2);

                        }
                        finComando();
                    }

                    break;
            }

         }

        private async void referenciarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 8;//Referenciacion
                    switch (idtc)//Depende del tipo de cedula
                    {
                        case 1:
                            ECMainModel.TypeName = "CedulaModeloReferenciarView";
                            break;
                        case 2:
                            ECMainModel.TypeName = "CedulaModeloAnaliticaReferenciarView";
                            break;
                        case 6://Cedula hallazgos
                            ECMainModel.TypeName = "CedulaModeloHallazgosReferenciarView";
                            break;
                    }
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

        private void tareasPapel()
        {
            throw new NotImplementedException();
        }

        private async void aprobarPapel()
        {
            if (!(currentEntidad == null))
            {
                comando = 12;//Supervisar
                iniciarComando();
                switch (idtc)//Depende del tipo de cedula
                {
                    case 1:
                        ECMainModel.TypeName = "CedulaModeloAprobarView";
                        break;
                        
                    case 2:
                        ECMainModel.TypeName = "CedulaModeloAnaliticaAprobarView";
                        break;
                    case 6://Cedula hallazgos
                        ECMainModel.TypeName = "CedulaModeloHallazgosAprobarView";
                        break;
                }


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

        private async void supervisarPapel()
        {
            {
                if (!(currentEntidad == null))
                {
                    comando = 11;//Supervisar
                    iniciarComando();
                    switch (idtc)//Depende del tipo de cedula
                    {
                        case 1:
                            ECMainModel.TypeName = "CedulaModeloSupervisarView";
                            break;
                        case 2:
                            ECMainModel.TypeName = "CedulaModeloAnaliticaSupervisarView";
                            break;
                        case 6://Cedula hallazgos
                            ECMainModel.TypeName = "CedulaModeloHallazgosSupervisarView";
                            break;
                    }

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
                && lista.Count()>0);
            }
        }

        private async void cerrarPapel()
        {

            if (!(currentEntidad == null))
            {
                iniciarComando();
                //decimal avance = (decimal)currentEntidad.indiceEjecucionprograma;
                //int estadoDocumento = BitacoraModelo.evaluarEstado(currentEntidad,4,"MATRIZRIESGOS");//Etapa 4 es cerrado
                int estadoDocumento = CedulaModelo.evaluarCerrar(currentEntidad);
                if (estadoDocumento == 1) //Hay cero procedimientos diferentes a iniciados
                {
                    if (currentEntidad.referenciacedula!=string.Empty)
                    {
                        if (currentEntidad.conclusioncedula != string.Empty || currentEntidad.idtc==2)
                        {
                            comando = 10;//Referenciacion
                            iniciarComando();
                            switch (idtc)//Depende del tipo de cedula
                            {
                                case 1:
                                    ECMainModel.TypeName = "CedulaModeloCerrarView";
                                    break;
                                case 2:
                                    ECMainModel.TypeName = "CedulaModeloAnaliticaCerrarView";
                                    break;
                                case 6://Cedula hallazgos
                                    ECMainModel.TypeName = "CedulaModeloHallazgosCerrarView";
                                    break;
                            }
                            #region Configuracion
                            currentEntidad.usuarioModelo = usuarioModelo;
                            #endregion
                            enviarMensaje();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Debe formular una  conclusión sobre  el  área", "antes de cerrarlo");
                        }
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
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 3;
                    iniciarComando();
                    switch (idtc)//Depende del tipo de cedula
                    {
                        case 1:
                            ECMainModel.TypeName = "CierreTipoCarpetaModeloConsultarView";
                            break;
                        case 2:
                            ECMainModel.TypeName = "CierreTipoCarpetaModeloAnaliticaConsultarView";
                            break;
                        case 6://Cedula hallazgos
                            ECMainModel.TypeName = "CierreTipoCarpetaModeloHallazgosConsultarView";
                            break;
                    }
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

        private async void detalleContenido()
        {
            //Para guardar lo que esta en la  pantalla
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    comando = 9;
                    iniciarComando();

                    int indice = -1;
                    for (int i = 0; i < listaVistas.Count; i++)
                    {
                        if (listaVistas[i].tabla.Contains(tablaDetalle))
                        {
                            indice = i;
                            i = listaVistas.Count;
                        }
                    }
                    if (indice != -1)
                    {
                        currentEntidad.usuarioModelo = usuarioModelo;
                        listaVistas[indice].NavigateExecute(); //Repite para inicializar desde documentacion
                        enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                        listaVistas = new ObservableCollection<menuCedulaDetalle>(menuCedulaDetalle.GetAll());
                        Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Error en la tabla llamada en Cedula Detalle", "");
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


         private async void vistaPapel()
        {
            if (!(currentEntidad == null))
            {
                comando = 5;
                iniciarComando();

                switch (idtc)//Depende del tipo de cedula
                {
                    case 1:
                        ECMainModel.TypeName = "CedulaSumariaVerView";
                        break;
                    case 2:
                        ECMainModel.TypeName = "CedulaSumariaAnaliticaVerView";
                        break;
                    case 6://Cedula hallazgos
                        ECMainModel.TypeName = "CedulaSumariaHallazgosVerView";
                        break;
                }
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
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


                        ECMainModel.TypeName = "CedulaModeloImportarView";
                        currentEntidad = currentEntidad = new CedulaModelo(currentEncargo);
                        activarCaptura = true;
                        enviarMensaje();
                    }
                    else
                    {
                        if (result == MessageDialogResult.Negative)
                        {
                            comando = 7;//Importa de los encargos de  años anteriores
                            iniciarComando();


                            ECMainModel.TypeName = "CedulaModeloImportarView";
                            currentEntidad = new CedulaModelo(currentEncargo);
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
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenEnvioPadre);
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
            if (comando != 14)
            {
                Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
                Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            }
            else
            {
                Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => resumenContenido(controllerProgramaViewMensaje));
                Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => resumenContenido(controllerProgramaViewMensaje));
            }
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
    }
}