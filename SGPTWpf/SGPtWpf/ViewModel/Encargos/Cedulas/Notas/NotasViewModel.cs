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
using CapaDatos;
using SGPTWpf.Model.Modelo;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Notas
{

    public sealed class NotasViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;
        private static SGPTEntidades _context;
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


        #region tokenEnvioDatosAMenu

        private string _tokenEnvioDatosAMenu;
        private string tokenEnvioDatosAMenu
        {
            get { return _tokenEnvioDatosAMenu; }
            set { _tokenEnvioDatosAMenu = value; }
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
        //12;"CedulaNotasModelos";"A";TRUE
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

        private ObservableCollection<CedulaNotasModelo> _SelectedItems;

        public ObservableCollection<CedulaNotasModelo> SelectedItems
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


        #region visibilidadPdf

        public const string visibilidadPdfPropertyName = "visibilidadPdf";

        private Visibility _visibilidadPdf = Visibility.Collapsed;

        public Visibility visibilidadPdf
        {
            get
            {
                return _visibilidadPdf;
            }

            set
            {
                if (_visibilidadPdf == value)
                {
                    return;
                }

                _visibilidadPdf = value;
                RaisePropertyChanged(visibilidadPdfPropertyName);
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

        private ObservableCollection<CedulaNotasModelo> _lista;

        public ObservableCollection<CedulaNotasModelo> lista
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

        #region ViewModel Properties : listaMaestro

        public const string listaMaestroPropertyName = "listaMaestro";

        private ObservableCollection<CedulaModelo> _listaMaestro;

        public ObservableCollection<CedulaModelo> listaMaestro
        {
            get
            {
                return _listaMaestro;
            }

            set
            {
                if (_listaMaestro == value) return;

                _listaMaestro = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaMaestroPropertyName);
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

        #region currentEntidad

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

        #region currentEntidadDetalle

        public const string currentEntidadDetallePropertyName = "currentEntidadDetalle";

        private CedulaNotasModelo _currentEntidadDetalle;

        public CedulaNotasModelo currentEntidadDetalle
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
        public RelayCommand<CedulaNotasModelo> SelectionChangedCommand { get; set; }
        public RelayCommand detalleCommand { get; set; }

        public RelayCommand vistaCommand { get; set; }
        public RelayCommand ImportarCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }
        public RelayCommand aprobarTareaCommand { get; set; }

        public RelayCommand irMenuPadreCommand { get; set; }
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
        public NotasViewModel()//Caso Encargo/PlanIndice
        {
        }

        //Llamado desde documentacion
        public NotasViewModel(string origen)//Documentacion/Carpetas
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
                case "cedulasNotas":
                    fuenteLlamado = 1;
                    _idtc = 7;//
                    //7.- Notas
                    //#region tokens

                    //_tokenRecepcionPadre = "Notas" + "Cédulas";//Permite captar los mensajes del  menú planificacion, corresponde a Indices

                    //_tokenEnvioDatosAHijo = "datosEncargoCedulaNotas";//Para control de los datos que  remite programas a sub-ventanas

                    //_tokenRecepcionHijo = "datosEncargoCedulaNotasController";

                    //#endregion

                    #region tokens
                    _tokenRecepcionPadre = "datosEncargoCedulasNotasMenuPrincipal";//Permite captar los mensajes del  view model BalancesViewModel

                    _tokenEnvioDatosAHijo = "datosEncargoCedulasNotas";  //Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosEncargoCedulasNotasController";

                    _tokenEnvioDatosAMenu = "Notas" + "Cédulas" + "DetalleRegreso"; //Para regresar al menu anterior.

                    #endregion

                    RegisterCommands();
                    _tablaDetalle = "Notas";
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Visible;
                    _visibilidadMBorrar = Visibility.Visible;
                    _visibilidadMConsulta = Visibility.Visible;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Visible;
                    _visibilidadMSupervisar = Visibility.Visible;
                    _visibilidadMAprobar = Visibility.Visible;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadPdf = Visibility.Collapsed;
                    #endregion
                    break;
                case "SupervisionNotas":
                    fuenteLlamado = 1;
                    _idtc = 7;//
                    //7;"Notas";"A";TRUE
                    #region tokens

                    _tokenRecepcionPadre = "Consulta de Notas" + "Supervision";//Permite captar los mensajes del  menú planificacion, corresponde a Indices

                    _tokenEnvioDatosAHijo = "datosEncargoCedulaNotas";//Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosEncargoCedulaNotasController";

                    #endregion

                    RegisterCommands();
                    _tablaDetalle = "Notas";
                    #region  menu

                    _visibilidadMCrear = Visibility.Visible;
                    _visibilidadMEditar = Visibility.Visible;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Visible;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Visible;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadPdf = Visibility.Collapsed;
                    #endregion
                    break;

            }



            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar

            _accesibilidadWindow = false;
            _IsSelected = false;

            _cursorWindow = Cursors.Hand;

            Messenger.Default.Register<CedulaMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            currentEntidadDetalle = new CedulaNotasModelo();
            _comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<CedulaNotasModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            ECMainModel = new MainModel();
            listaVistas = new ObservableCollection<menuCedulaDetalle>(menuCedulaDetalle.GetAll());
            _listaMaestro = new ObservableCollection<CedulaModelo>();
            //Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
        }

        private async void ControlRecepcionDatos(CedulaMsj msj)
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            accesibilidadWindow = true;
            //_tokenEnvioPadre = msj.tokenRespuesta;
            //_tokenRecepcionSubMenu = msj.tokenRespuestaDetalle;
            Messenger.Default.Unregister<NotasMsj>(this, tokenRecepcionPadre);
            //Verificar que exista el  registro de cedulay en caso  contrario crearlo
            //currentEntidad = CedulaModelo.FindMaestro(currentEncargo.idencargo, idtc, "Cédula de notas");
            currentEntidad = msj.entidadMaestroModelo;
            switch (currentEntidad.idcedula)
            {
                case -1:
                    //Error en la comunicacion
                    //No  puede trabajarse
                    await mensajeAutoCerrado("Existen errores de comunicación", "Intentelo más tarde", 1);
                    accesibilidadWindow = false;
                    break;
                case 0:
                    //Registro no creado, se deberá crear
                    currentEntidad = new CedulaModelo();
                    currentEntidad.idtc = idtc;
                    currentEntidad.idencargo = currentEncargo.idencargo;
                    currentEntidad.titulocedula = "Cédula de notas";
                    currentEntidad.usuarioModelo = usuarioModelo;
                    switch (CedulaModelo.Insert(currentEntidad, true))
                    {
                        case 0://No se pudo insertar
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            accesibilidadWindow = false;
                            break;
                        case 1://Se inserto con éxito
                            //await mensajeAutoCerrado("Registro insertado con éxito", "Este mensaje desaparecerá en segundos", 1);
                            break;
                        case -1://Se inserto con éxito
                            await mensajeAutoCerrado("Error al insertar el registro", "Este mensaje desaparecerá en segundos", 1);
                            accesibilidadWindow = false;
                            break;
                    }
                    break;
                default:
                    //existe el registro
                    actualizarLista();

                    accesibilidadWindow = true;
                    //Cargar los registros dependientes
                    break;
            }
            listaMaestro = msj.listaMaestroModelo;
            //listaMaestro.Add(currentEntidad);
            //inicializacionTerminada();
            finComando();
        }


        private void actualizarLista()
        {
            //guardarlista();
            try
            {
                using (_context = new SGPTEntidades())
                {
                    lista = CedulaNotasModelo.GetAllEdicion(currentEncargo, currentEntidad.idcedula);
                }
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
            NotasMsj elemento = new NotasMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = lista;
            elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
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
            currentEntidadDetalle = null;
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
            //currentEntidad = new CedulaModelo(currentEncargo, usuarioModelo);
            //currentEntidad.idtc = idtc;//Se asigna el tipo de cedula a utilizar
            currentEntidadDetalle = new CedulaNotasModelo(currentEntidad, currentEncargo, usuarioModelo);
            currentEntidadDetalle.numnotapt =CedulaNotasModelo.indice(lista.Count() + 1);
            currentEntidadDetalle.idusuariocreador = usuarioModelo.idUsuario;
            ECMainModel.TypeName = "CedulaNotasCrearview";
            #endregion

            activarCaptura = true;
            #endregion

            enviarMensaje();
        }

        public async void Editar()
        {
            //Para guardar lo que esta en la  pantalla
            //ControlCambioLista(true);


            if (!(currentEntidadDetalle == null))
            {
                iniciarComando();
                comando = 2;
                currentEntidadDetalle.usuarioModelo = usuarioModelo;
                ECMainModel.TypeName = "CedulaNotasEditarView";
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }

        }
        public async void Consultar()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);

            if (!(currentEntidadDetalle == null))
            {
                iniciarComando();
                comando = 3;
                currentEntidadDetalle.usuarioModelo = usuarioModelo;
                ECMainModel.TypeName = "CedulaNotasConsultarView";
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }

        }


        public async void Borrar()
        {

            if (!(currentEntidadDetalle == null))
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

                        //switch (IndiceModelo.EvaluarBorrar(currentEntidadDetalle.id))
                        switch (CedulaModelo.evaluarBorrar(currentEntidad))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 1:
                                //Puede borrarse por completo
                                switch (CedulaNotasModelo.Delete(currentEntidadDetalle))
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
                                        currentEntidadDetalle = new CedulaNotasModelo();
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
                        ObservableCollection<CedulaNotasModelo> temporal = new ObservableCollection<CedulaNotasModelo>();
                        foreach (CedulaNotasModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                switch (CedulaModelo.evaluarBorrar(currentEntidad))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al consultar  " + item.descripcionnotaspt, "intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    default:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse " + item.descripcionnotaspt, "porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (CedulaNotasModelo.Delete(temporal))
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
                                    currentEntidadDetalle = new CedulaNotasModelo();
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

            if (!(currentEntidadDetalle == null))
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
                        //switch (IndiceModelo.EvaluarBorrar(currentEntidadDetalle.id))
                        switch (CedulaModelo.evaluarBorrar(currentEntidad))
                        {
                            case -1:
                                finComando();
                                await dlg.ShowMessageAsync(this, "Se produjo un error ", "intentelo en otro momento");
                                //Hay error en el procedimiento
                                break;
                            case 1:
                                //Puede borrarse por completo
                                switch (CedulaNotasModelo.DeleteLogico(currentEntidadDetalle))
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
                                        currentEntidadDetalle = new CedulaNotasModelo();
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
                        ObservableCollection<CedulaNotasModelo> temporal = new ObservableCollection<CedulaNotasModelo>();
                        foreach (CedulaNotasModelo item in lista)
                        {
                            if (item.IsSelected)
                            {
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidadDetalle.id))
                                switch (CedulaModelo.evaluarBorrar(currentEntidad))
                                //switch (IndiceModelo.EvaluarBorrar(currentEntidadDetalle.id))
                                {
                                    case -1:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "Se produjo un error al consultar  " + item.descripcionnotaspt, "intentelo en otro momento");
                                        iniciarComando();
                                        //Hay error en el procedimiento
                                        break;
                                    case 0:
                                        //Puede borrarse por completo
                                        temporal.Add(item);
                                        break;
                                    default:
                                        finComando();
                                        await dlg.ShowMessageAsync(this, "No puede eliminarse " + item.descripcionnotaspt, "porque hay papeles referenciados");
                                        iniciarComando();
                                        break;
                                }
                            }
                        }
                        if (temporal.Count > 0)
                        {
                            //caso de muchos registros
                            switch (CedulaNotasModelo.DeleteBorradoLogico(temporal))
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
                                    currentEntidadDetalle = new CedulaNotasModelo();
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

        public void Actualizar(ObservableCollection<CedulaNotasModelo> listaEntidad)
        {
            lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidadDetalle != null;
        }

        public bool CanCommand()
        {
            if (!(currentEntidadDetalle == null))
            {
                try
                {
                    return currentEntidadDetalle.idnotaspt != 0;
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
            //Aplica para la  opcion de documentacion

            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, CanNuevo);//ok
            EditarCommand = new RelayCommand(Editar, CanEditar);
            BorrarCommand = new RelayCommand(Borrar, CanBorrar);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            copiarCommand = new RelayCommand(Importar, CanEditar);
            DoubleClickCommand = new RelayCommand(Nada);
            SelectionChangedCommand = new RelayCommand<CedulaNotasModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidadDetalle = entidad;
                //listaDetalles = entidad.listaBitacora;
            });

            vistaCommand = new RelayCommand(vistaPapel);

            ImportarCommand = new RelayCommand(Importar, CanEditar);//ok


            terminarPapelCommand = new RelayCommand(cerrarPapel, CanTerminar);
            supervisarCommand = new RelayCommand(supervisarPapel, CanSupervisar);
            aprobarCommand = new RelayCommand(aprobarPapel, CanAprobar);
            agendaCommand = new RelayCommand(tareasPapel, CanCommand);
            referenciarCommand = new RelayCommand(referenciarPrograma);//Para guardar la referencia
            aprobarTareaCommand = new RelayCommand(aprobarTarea, CanAprobarTarea);
            irMenuPadreCommand = new RelayCommand(irPrincipal);
        }

        private void irPrincipal()
        {
            iniciarComando();
            //Mandar el mensaje al principal que domina la pantalla
            Messenger.Default.Send(currentEntidad.idcedula, tokenEnvioDatosAMenu);
        }

        private bool CanAprobarTarea()
        {
            bool evaluar = false;

            if (currentEntidadDetalle == null || currentEntidadDetalle == null)
            {
                return evaluar;
            }
            else
            {
                try
                {

                    if (currentEntidadDetalle.commandButton == "Cerrar")
                    {
                        return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty);
                    }
                    else
                    {
                        if (currentEntidadDetalle.commandButton == "Aprobar")
                        {
                            return (currentEntidad.usuarioaprobo == null || currentEntidad.usuarioaprobo == string.Empty);
                        }
                        else
                        {
                            if (currentEntidadDetalle.commandButton == "Revisado")
                            {
                                return (currentEntidad.usuariosuperviso == null || currentEntidad.usuariosuperviso == string.Empty);
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        public async void aprobarTarea()
        {
            iniciarComando();
            if (!(currentEntidadDetalle == null))
            {
                accesibilidadWindow = false;
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Aprobar",
                    NegativeButtonText = "Cancelar",
                };
                switch (currentEntidadDetalle.commandButton)
                {
                    case "Cerrar":
                        mySettings.AffirmativeButtonText = "Cerrar";
                        mySettings.NegativeButtonText = "Cancelar";
                        break;
                    case "Revisado":
                        mySettings.AffirmativeButtonText = "Revisado";
                        mySettings.NegativeButtonText = "Cancelar";
                        break;
                    case "Aprobar":
                        mySettings.AffirmativeButtonText = "Aprobado";
                        mySettings.NegativeButtonText = "Cancelar";
                        break;

                }
                finComando();
                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Aprobar implica dar por valido la operación", "¿Desea hacerlo?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    iniciarComando();
                    //Repite el  ciclo para evitar errores
                    if (currentEntidadDetalle.usuariocreo == usuarioModelo.inicialesusuario || usuarioModelo.idRolPadre == 2)//idrol=2 es de  Socio
                    {
                        int resultadoModificar = -10;
                        currentEntidadDetalle.usuarioModelo = usuarioModelo;
                        //Es el usuario que creo la actividad o es  un usuario con perfil de socio
                        switch (currentEntidadDetalle.commandButton)
                        {
                            case "Cerrar":
                                resultadoModificar = CedulaNotasModelo.UpdateCierre(currentEntidadDetalle, usuarioModelo);
                                //resultadoModificar = CedulaModelo.UpdateCierre(currentEntidad, currentUsuario);
                                break;
                            case "Revisado":
                                resultadoModificar = CedulaNotasModelo.UpdateSupervision(currentEntidadDetalle);
                                break;
                            case "Aprobar":
                                if (string.IsNullOrEmpty(currentEntidad.usuariosuperviso) || string.IsNullOrWhiteSpace(currentEntidad.usuariosuperviso))
                                {
                                    resultadoModificar = CedulaNotasModelo.UpdateAprobacionSupervision(currentEntidadDetalle);
                                    currentEntidad.usuariosuperviso = currentEntidad.usuarioaprobo;
                                    currentEntidad.fechasupervision = currentEntidad.fechaaprobacion;
                                }
                                else
                                {
                                    resultadoModificar = CedulaNotasModelo.UpdateAprobacion(currentEntidadDetalle);
                                }
                                break;
                        }

                        switch (resultadoModificar)
                        {
                            case 0://No se pudo insertar
                                await mensajeAutoCerrado("No ha sido posible insertar el registro", "Este mensaje desaparecerá en segundos", 2);
                                break;
                            case 1://Se inserto con éxito
                                await mensajeAutoCerrado("Operación con registro realizada con éxito", "Este mensaje desaparecerá en segundos", 2);
                                actualizarLista();
                                break;
                            case -1://No se pudo insertar
                                await mensajeAutoCerrado("Se genero un  error en la operación", "Este mensaje desaparecerá en segundos", 2);
                                break;
                        }
                        finComando();
                    }
                    else
                    {
                        await mensajeAutoCerrado("Debe ser un usuario diferente el que debe realizar la operacion", "O un usuario con perfil de socio", 1);
                        finComando();
                    }
                }
                else
                {
                    await mensajeAutoCerrado("Cancelo la operacion", "", 1);
                    finComando();
                }
            }
            else
            {
                await mensajeAutoCerrado("Debe seleccionar el registro para la operación", "", 1);
            }
            finComando();
        }



        private async void referenciarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 8;//Referenciacion
                    ECMainModel.TypeName = "CedulaModeloReferenciarView";
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
            if (!(currentEntidadDetalle == null))
            {
                try
                {
                    if (currentEntidadDetalle.idnotaspt != 0)
                    {
                        return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty)
                            && (currentEntidadDetalle.usuariocerro == null || currentEntidadDetalle.usuariocerro == string.Empty);
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

        private bool CanNuevo()
        {
            return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty);
        }

        private bool CanBorrar()
        {
            if (!(currentEntidadDetalle == null))
            {
                try
                {
                    if (currentEntidadDetalle.idnotaspt != 0)
                    {
                        return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty)
                            && (currentEntidadDetalle.usuariocerro == null || currentEntidadDetalle.usuariocerro == string.Empty);
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

        private bool CanAprobar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return lista.Count(x => x.etapaPapelDescripcion == "Cerrado") == lista.Count()
                && lista.Count > 0
                && (((!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                    || (string.IsNullOrEmpty(currentEntidad.usuariosuperviso)))
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

                ECMainModel.TypeName = "CedulaNotasAprobarView";
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

                    ECMainModel.TypeName = "CedulaNotasSupervisarView";
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
                && lista.Count(x=>x.etapaPapelDescripcion== "Cerrado")==lista.Count() 
                && lista.Count > 0);
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
                    if (currentEntidad.referenciacedula != string.Empty)
                    {
                        comando = 10;//Referenciacion
                        iniciarComando();

                        ECMainModel.TypeName = "CedulaNotasCerrarView";
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

            if (!(currentEntidad == null))
            {
                comando = 3;
                iniciarComando();

                ECMainModel.TypeName = "CedulaNotasCerrarView";
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }

        }



        private void vistaPapel()
        {
            //if (!(currentEntidad == null))
            //{
            comando = 5;
            iniciarComando();
            ECMainModel.TypeName = "CedulaNotasVerView";
            enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            //}
            //else
            //{
            //    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            //}
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
                NegativeButtonText = "Cancelar",
            };
            finComando();
            MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione la fuente para importar", "",
            MessageDialogStyle.AffirmativeAndNegative, mySettings);
            iniciarComando();
            if (result == MessageDialogResult.Affirmative)
            {
                iniciarComando();
                bool resultado = await ImportarMarcas();
                if (resultado)
                {
                    await mensajeAutoCerrado("Proceso concluído", "", 2);
                }
                else
                {
                    await mensajeAutoCerrado("Existieron errores en  la importación", "No todos los registros se extrajeron", 2);
                }
                actualizarLista();
                finComando();

            }
            else
            {
                finComando();
                await dlg.ShowMessageAsync(this, "Canceló operación", "");
            }
            #endregion fin de proceso
        }

        private async Task<bool> ImportarMarcas()
        {
            //Llamar lista de marcas estandares
            ObservableCollection<MarcasEstandaresModelo> listaMarcasEstandares = new ObservableCollection<MarcasEstandaresModelo>(MarcasEstandaresModelo.GetAll());
            //Comparar listados y determinar diferencias
            ObservableCollection<MarcasEstandaresModelo> agregar = new ObservableCollection<MarcasEstandaresModelo>((from p in listaMarcasEstandares
                                                                                                                     where !(from ex in lista
                                                                                                                             select ex.descripcionnotaspt)
                                                                                                                            .Contains(p.marcame)
                                                                                                                     select p).ToList());
            //Convertir e importar
            if (agregar.Count > 0)
            {
                CedulaNotasModelo temporal = new CedulaNotasModelo();
                //Convertir 
                int orden = lista.Count() + 1;
                try
                {
                    foreach (MarcasEstandaresModelo item in agregar)
                    {
                        temporal.idnotaspt = 0;
                        temporal.idcedula = currentEntidad.idcedula;
                        temporal.descripcionnotaspt = item.marcame;
                        //temporal.significadoma = item.significadoMe;
                        //temporal.tipografiama = item.tipografiame;
                        //temporal.tamaniotipografiama = item.tamaniotipografiame;
                        temporal.idencargo = currentEncargo.idencargo;
                        temporal.usuariocerro = usuarioModelo.inicialesusuario;
                        temporal.isuso = 0;
                        orden++;
                        temporal.usuarioModelo = usuarioModelo;
                        //Guardar
                        switch (CedulaNotasModelo.Insert(temporal))
                        {
                            case 0://No se pudo insertar
                                await mensajeAutoCerrado("No ha sido posible insertar el registro " + item.marcame, "con significado : " + item.significadoMe, 2);
                                break;
                            case 1://Se inserto con éxito
                                await mensajeAutoCerrado("Se insertó el registro " + item.marcame, "con significado : " + item.significadoMe, 2);
                                break;
                            case -1://Se inserto con éxito
                                await mensajeAutoCerrado("No ha sido posible insertar el registro " + item.marcame, "con significado : " + item.significadoMe, 2);
                                break;
                        }

                    }
                    return true;
                }
                catch (Exception)
                {
                    //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                    await mensajeAutoCerrado("No ha sido posible continuar", "se generó un error", 2);
                    return false;
                }
            }
            else
            {
                await mensajeAutoCerrado("No hay nada que importar", "Las marcas estándares y las locales son  iguales", 2);
                return true;
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
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
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
            accesibilidadWindow = true;
            //if (comando != 9)
            //{
            //    enviarMensajeHabilitar();
            //}
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