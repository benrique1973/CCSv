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
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Supervision;
using System.Threading.Tasks;
using CapaDatos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices
{

    public sealed class DetalleIndiceViewModel : ViewModeloBase
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


        #region ViewModel Property : currentCarpeta Carpeta Modelo

        public const string currentCarpetaPropertyName = "currentCarpeta";

        private TipoCarpetaModelo _currentCarpeta;

        public TipoCarpetaModelo currentCarpeta
        {
            get
            {
                return _currentCarpeta;
            }

            set
            {
                if (_currentCarpeta == value) return;

                _currentCarpeta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentCarpetaPropertyName);
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

        private ObservableCollection<IndiceModelo> _lista;

        public ObservableCollection<IndiceModelo> lista
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

        private IndiceModelo _currentEntidad;

        public IndiceModelo currentEntidad
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
        public RelayCommand vistaPreviaReferenciaCommand { get; set; }
        public RelayCommand<IndiceModelo> SelectionChangedCommand { get; set; }
        public RelayCommand irMenuPadreCommand { get; set; }

        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand XImprimirCarpetaCommand { get; set; }
        public RelayCommand XImprimirItemCommand { get; set; }
        public RelayCommand XImprimirIndiceCommand { get; set; }
        public RelayCommand XImprimirPortadaCommand { get; set; }


        #endregion

        #region EDDetalleIndiceMainModel

        private MainModel _mainModel = null;

        public MainModel EDDetalleIndiceMainModel
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

        public DetalleIndiceViewModel()
        {

        }

        public DetalleIndiceViewModel(string origen)
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
                case "EncargoPlanIndiceDetalle":
                    #region configuracion
                    _menuElegido = "Planificacion";
                    _nombreopcionor = "Edición índices";
                    #region  menu

                    _visibilidadMCrear = Visibility.Visible;
                        _visibilidadMEditar = Visibility.Visible;
                        _visibilidadMBorrar = Visibility.Visible;
                        _visibilidadMConsulta = Visibility.Visible;
                        _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                        _visibilidadMRegresar = Visibility.Visible;
                        _visibilidadMVista = Visibility.Visible;
                        _visibilidadMImprimir = Visibility.Collapsed;

                    #endregion

                    #region token 
                    _permitirArrastrar = true;//Permite al usuario arrastrar
                    _tokenRecepcionPadre = "datosEDIndices";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerDetalleIndices";
                    _tokenEnvioDatosAMenu = "PlanDetalleIndiceRegreso"; //Para regresar al menu anterior.
                    _tokenReferenciaVista = "PlanDetalleReferenciaVista";
                    _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";
                    _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";
                    _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                    #endregion
                    _FuenteLlamada = 0;
                    RegisterCommands();
                    _origenLlamada = 2;
                    #endregion
                    break;
                case "EncargoDocumentacionIndiceDetalle":
                    _menuElegido = "Documentacion";
                    _nombreopcionor = "Carpetas";
                    #region configuracion
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Visible;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImprimir = Visibility.Collapsed;
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
                    _menuElegido = "Documentacion";
                    _nombreopcionor = "Carpetas";
                    #region configuracion
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                        _visibilidadMEditar = Visibility.Collapsed;
                        _visibilidadMBorrar = Visibility.Collapsed;
                        _visibilidadMConsulta = Visibility.Collapsed; 
                        _visibilidadMReferenciar = Visibility.Collapsed; //Pendiente
                        _visibilidadMRegresar = Visibility.Visible; 
                        _visibilidadMVista = Visibility.Visible;
                        _visibilidadMImprimir = Visibility.Collapsed;
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
                case "EncargoSupervisionIndiceDetalle":
                    _menuElegido = "Documentacion";
                    _nombreopcionor = "Carpetas";
                    #region configuracion
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed; //Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                    _permitirArrastrar = false;//Permite al usuario arrastrar
                    #region token
                    _tokenRecepcionPadre = "datosEncargoCierreIndices";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                    _tokenRecepcionHijo = "datosControllerDetalleIndices";
                    _tokenEnvioDatosAMenu = "Revision de carpetas" + "Supervision" + "DetalleRegreso";  //Para regresar al menu anterior.
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
                    _menuElegido = "Documentacion";
                    _nombreopcionor = "Carpetas";
                    #region configuracion
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Visible;
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
                    RegisterCommandsConsulta();
                    _origenLlamada = 2;
                    #endregion
                    break;
                case "DocumentosImpresionIndiceDetalle":
                    _menuElegido = "Documentacion";
                    _nombreopcionor = "Carpetas";
                    #region configuracion
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Collapsed; 
                    _visibilidadMImprimir = Visibility.Visible;
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
            Messenger.Default.Register<IndiceMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlRecepcionDatos(datosMsj));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            _comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<IndiceModelo>();//Lista vacia no se conoce el encargo y el cliente
            listaDetalles = new ObservableCollection<BitacoraModelo>();
            EDDetalleIndiceMainModel = new MainModel();
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
                    #region Menu permisos

                    switch (fuenteLlamada)
                    {
                        case "EncargoPlanIndiceDetalle":
                            #region configuracion
                            _menuElegido = "Planificacion";
                            _nombreopcionor = "Edición índices";
                            #region configuracion

                            if (currentUsuario.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()) > 0)
                            {
                                #region  permisos asignados
                                permisosrolesusuario permisosAsignados = currentUsuario.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()
                                && x.submenupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {
                                    #region crear-importar-detalle

                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                    }

                                    #endregion crear

                                    #region editar-referenciar-cerrar-detalle
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Visible;
                                        _visibilidadMReferenciar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Collapsed;
                                    }
                                    #endregion editar

                                    #region consultar-vista-detalle
                                    if (permisosAsignados.consultarpru)
                                    {
                                        _visibilidadMConsulta = Visibility.Visible;
                                        _visibilidadMVista = Visibility.Visible;
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

                                    #region imprimir
                                    if (permisosAsignados.impresionpru)
                                    {
                                        _visibilidadMImprimir = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMImprimir = Visibility.Collapsed;
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
                                    _visibilidadMImportar = Visibility.Collapsed;
                                    _visibilidadMTask = Visibility.Collapsed;
                                    _visibilidadMRegresar = Visibility.Visible;
                                    _visibilidadMDetalle = Visibility.Collapsed;
                                    _visibilidadMCerrar = Visibility.Collapsed;

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
                            //_visibilidadMEditar = Visibility.Visible;
                            //_visibilidadMBorrar = Visibility.Visible;
                            //_visibilidadMConsulta = Visibility.Visible;
                            //_visibilidadMReferenciar = Visibility.Visible;
                            //_visibilidadMRegresar = Visibility.Visible;
                            //_visibilidadMVista = Visibility.Visible;
                            _visibilidadMImprimir = Visibility.Collapsed;

                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            #endregion

                            #endregion
                            break;
                        case "EncargoDocumentacionIndiceDetalle":
                            _menuElegido = "Documentacion";
                            _nombreopcionor = "Carpetas";
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

                            #endregion
                            break;
                        case "EncargoCierreIndiceDetalle":
                            _menuElegido = "Documentacion";
                            _nombreopcionor = "Carpetas";
                            #region configuracion
                            #region  menu

                            visibilidadMCrear = Visibility.Collapsed;
                            visibilidadMEditar = Visibility.Collapsed;
                            visibilidadMBorrar = Visibility.Collapsed;
                            visibilidadMConsulta = Visibility.Collapsed;
                            visibilidadMReferenciar = Visibility.Collapsed; //Pendiente
                            visibilidadMRegresar = Visibility.Visible;
                            visibilidadMVista = Visibility.Visible;
                            visibilidadMImprimir = Visibility.Collapsed;
                            #endregion

                            #endregion
                            break;
                        case "EncargoSupervisionIndiceDetalle":
                            _menuElegido = "Documentacion";
                            _nombreopcionor = "Carpetas";
                            #region configuracion
                            #region  menu

                            visibilidadMCrear = Visibility.Collapsed;
                            visibilidadMEditar = Visibility.Collapsed;
                            visibilidadMBorrar = Visibility.Collapsed;
                            visibilidadMConsulta = Visibility.Collapsed;
                            visibilidadMReferenciar = Visibility.Collapsed; //Pendiente
                            visibilidadMRegresar = Visibility.Visible;
                            visibilidadMVista = Visibility.Visible;
                            visibilidadMImprimir = Visibility.Collapsed;
                            #endregion

                            #endregion
                            break;
                        case "DocumentosConsultaIndiceDetalle":
                            _menuElegido = "Documentacion";
                            _nombreopcionor = "Carpetas";
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
                            #endregion
                            break;
                        case "DocumentosImpresionIndiceDetalle":
                            _menuElegido = "Documentacion";
                            _nombreopcionor = "Carpetas";
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
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

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

                //Solo permite consulta
                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Visible;
                _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                _visibilidadMRegresar = Visibility.Visible;
                _visibilidadMVista = Visibility.Visible;
                _visibilidadMImportar = Visibility.Collapsed;
                _visibilidadMDetalle = Visibility.Collapsed;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMTask = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;

                #endregion
            }

        }



        private void ControlRecepcionDatos(IndiceMsj msj)
        {
            currentEncargo = msj.encargoModelo;//Encargo en uso actual
            currentUsuario = msj.usuarioModelo;
            //currentSistemaContable = msj.sistemaContableModelo;
            currentCarpeta = msj.tipoCarpetaModelo;
            opcionMenu = msj.opcionMenuCrud;
            FuenteLlamada = msj.fuenteLlamado;
            actualizarLista();
            //No se desuscribe porque continua existiendo
            //Messenger.Default.Unregister<IndiceMsj>(this, tokenRecepcionPadre);
            Mouse.OverrideCursor = null;
            if (!string.IsNullOrEmpty(msj.tokenRespuestaController))
            {
                //_to = msj.tokenRespuestaController;
            }
            if (!string.IsNullOrEmpty(msj.tokenRecepcionSubMenuDetalle))
            {

                _tokenEnvioDatosAMenu = msj.tokenRecepcionSubMenuDetalle;
            }
            permisos();
            accesibilidadWindow = true;
            Messenger.Default.Unregister<IndiceMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<IndiceModelo>(IndiceModelo.GetAllByIdTC(currentCarpeta.id));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista ", ""+e);

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

                    foreach (IndiceModelo item in lista)
                    {
                        if (item.guardadoBase == false)
                        {
                            IndiceModelo.UpdateModeloReodenar(item);
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
            DetalleIndiceMsj elemento = new DetalleIndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.tipoCarpetaModelo = currentCarpeta;//Para el caso de  edicion de programas
            //elemento.listaTipoCarpetaModel =;
            elemento.listaDetalleIndiceModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuesta = tokenRecepcionHijo;
            elemento.fuenteLlamado = origenLlamada; //no se utiliza
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        public void enviarMensajeCrud()
        {
            //Se crea el mensaje
            EncargoPlanDetalleIndiceMsj elemento = new EncargoPlanDetalleIndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.detalleHerramientaElemento = currentEntidad;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.herramientaModelo = currentCarpeta;//Para el caso de  edicion de programas
            //elemento.listaTipoCarpetaModel =;
            elemento.listaElementos = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuesta = tokenRecepcionHijo;
            elemento.fuenteLlamado = origenLlamada; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EDDetalleIndiceMainModel.TypeName = null;
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
            currentEntidad = new IndiceModelo(currentCarpeta,currentEncargo);
            if (lista.Count > 0)
            {
                currentEntidad.ordenindice = lista.Max(x => x.ordenindice) + 10;
            }
            else
            {
                currentEntidad.ordenindice = 10;
            }
            //currentEntidad.balanceModelo = currentCarpeta;
            EDDetalleIndiceMainModel.TypeName = "DetalleIndiceModeloCrearview";
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
                    EDDetalleIndiceMainModel.TypeName = "DetalleIndiceModeloEditarview";
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
                    EDDetalleIndiceMainModel.TypeName = "DetalleIndiceModeloConsultarview";
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

            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (!(currentEntidad == null))
            {
                //currentEntidad.usuarioModelo = currentUsuario;
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
                        if (string.IsNullOrEmpty(currentEntidad.referenciaindice))
                        {
                            if (IndiceModelo.Delete((int)currentEntidad.idindice, true))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borro el registro ", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                actualizarLista();
                                currentEntidad = new IndiceModelo();
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
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "Porque esta referenciado");

                        }

                    }
                    else
                    {
                        ObservableCollection<IndiceModelo> temporal = new ObservableCollection<IndiceModelo>(lista.Where(x => x.IsSelected));
                        foreach (IndiceModelo itemRemover in temporal)
                        {
                            if (!string.IsNullOrEmpty(itemRemover.referenciaindice))
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "El registro "+itemRemover.descripcionindice, "No será removido,  contiene referencias");
                                iniciarComando();
                            }
                        }
                        //caso de muchos registros
                        temporal = new ObservableCollection<IndiceModelo>(lista.Where(x => x.IsSelected && string.IsNullOrEmpty(x.referenciaindice)));
                        if (temporal.Count() > 0)
                        {
                            if (IndiceModelo.Delete(temporal))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                actualizarLista();
                                currentEntidad = new IndiceModelo();
                                finComandoBorrar();
                            }
                            else
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                            }
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros posibles", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new IndiceModelo();
                            finComandoBorrar();
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

        public async void BorrarLogico()
        {

            //Para guardar lo que esta en la  pantalla
            ControlCambioLista(true);
            if (!(currentEntidad == null))
            {
                //currentEntidad.usuarioModelo = currentUsuario;
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
                        if (string.IsNullOrEmpty(currentEntidad.referenciaindice))
                        {
                            if (IndiceModelo.DeleteBorradoLogico((int)currentEntidad.idindice, true))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borro el registro ", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                actualizarLista();
                                currentEntidad = new IndiceModelo();
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
                            finComandoBorrar();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "Porque esta referenciado");

                        }

                    }
                    else
                    {
                        ObservableCollection<IndiceModelo> temporal = new ObservableCollection<IndiceModelo>(lista.Where(x => x.IsSelected));
                        foreach (IndiceModelo itemRemover in temporal)
                        {
                            if (!string.IsNullOrEmpty(itemRemover.referenciaindice))
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "El registro " + itemRemover.descripcionindice, "No será removido,  contiene referencias");
                                iniciarComando();
                            }
                        }
                        //caso de muchos registros
                        temporal = new ObservableCollection<IndiceModelo>(lista.Where(x => x.IsSelected && string.IsNullOrEmpty(x.referenciaindice)));
                        if (temporal.Count() > 0)
                        {
                            if (IndiceModelo.DeleteBorradoLogico(temporal))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                actualizarLista();
                                currentEntidad = new IndiceModelo();
                                finComandoBorrar();
                            }
                            else
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "No ha sido posible eliminar los registros", "");
                            }
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Se borraron los registros posibles", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            actualizarLista();
                            currentEntidad = new IndiceModelo();
                            finComandoBorrar();
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


        #endregion

        #region Verificaciones

        public void Actualizar(ObservableCollection<IndiceModelo> listaEntidad)
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
                    return currentEntidad.idindice != 0 && (currentCarpeta.usuariocerro == null || currentCarpeta.usuariocerro == string.Empty); 
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
                    if (currentEntidad.referenciaindice != null)
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
                    switch (currentEntidad.idteiindice)
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

            vistaPreviaReferenciaCommand = new RelayCommand(vistaPreviaReferencia, CanVista);

            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanVista);
            SelectionChangedCommand = new RelayCommand<IndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;
                
                //listaDetalles = entidad.listaBitacora;
            });
            irMenuPadreCommand = new RelayCommand(irPrincipal);

            referenciarCommand = new RelayCommand(Referenciar, CanReferenciar);

            XImprimirCarpetaCommand = new RelayCommand(imprimirCarpeta);
            XImprimirItemCommand = new RelayCommand(imprimirItem, CanCommand);
            XImprimirIndiceCommand = new RelayCommand(imprimirIndice);
            XImprimirPortadaCommand = new RelayCommand(imprimirPortada);

        }

        private void RegisterCommandsConsulta()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanVista);
            DoubleClickCommand = new RelayCommand(Consultar);

            vistaPreviaReferenciaCommand = new RelayCommand(vistaPreviaReferencia, CanVista);

            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanVista);
            SelectionChangedCommand = new RelayCommand<IndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                currentEntidad = entidad;

                //listaDetalles = entidad.listaBitacora;
            });
            irMenuPadreCommand = new RelayCommand(irPrincipal);

            referenciarCommand = new RelayCommand(Referenciar, CanReferenciar);

            XImprimirCarpetaCommand = new RelayCommand(consultarCarpeta);
            XImprimirItemCommand = new RelayCommand(vistaPreviaReferencia, CanCommand);
            XImprimirIndiceCommand = new RelayCommand(ConsultarIndice);
            XImprimirPortadaCommand = new RelayCommand(ConsultarPortada);

        }

        private void ConsultarPortada()
        {
            comando = 5;
            iniciarComando();

            EDDetalleIndiceMainModel.TypeName = "PortadaIndiceDocumentosVistaPreviaView";
            enviarIndiceMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
        }

        private void ConsultarIndice()
        {
                comando = 5;
                iniciarComando();

                EDDetalleIndiceMainModel.TypeName = "IndiceDocumentosVistaPreviaView";
                enviarIndiceMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
        }

        public void enviarIndiceMensaje()
        {
            //Se crea el mensaje
            IndiceMsj elemento = new IndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.tipoCarpetaModelo = currentCarpeta;//Para el caso de  edicion de programas
            //elemento.listaTipoCarpetaModelo = lista;
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

        private void imprimirPortada()
        {
            comando = 5;
            iniciarComando();

            EDDetalleIndiceMainModel.TypeName = "PortadaIndiceDocumentosImprimirPreviaView";
            enviarIndiceMensajeImprimir(1500); //Debe ir antes, porque evalua si la ventana es cero para enviarse

        }

        private void imprimirIndice()
        {
            comando = 5;
            iniciarComando();

            EDDetalleIndiceMainModel.TypeName = "IndiceDocumentosImprimirPreviaView";
            enviarIndiceMensajeImprimir(1500); //Debe ir antes, porque evalua si la ventana es cero para enviarse
        }

        private void enviarIndiceMensajeImprimir(int imprimir)
        {
            //Se crea el mensaje
            IndiceMsj elemento = new IndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.tipoCarpetaModelo = currentCarpeta;//Para el caso de  edicion de programas
            //elemento.listaTipoCarpetaModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRespuestaVista = tokenRecepcionHijo;
            elemento.fuenteLlamado = imprimir; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAVistaPreview);
        }

    private async void imprimirItem()
        {
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    enviarMensajeInhabilitar();//Para evitar que el usuario  tome otras acciones

                    comando = 12;//Mostrar la referencia
                    switch (currentEntidad.tablaindice)
                    {
                        case "MATRIZRIESGOS":
                            MatrizRiesgoModelo currentMatrizRiesgo = new MatrizRiesgoModelo();
                            currentMatrizRiesgo = MatrizRiesgoModelo.GetRegistro((int)currentEntidad.idgenericoindice);
                            if (currentMatrizRiesgo != null)
                            {
                                EDDetalleIndiceMainModel.TypeName = "MatrizRiesgoModeloImprimirView";
                                enviarMensajeMatrizRiesgo(currentMatrizRiesgo, 1500);//1500 para identificar que es impresion
                            }
                            //enviarMensajeImprimir(currentMatrizRiesgo);
                            break;
                        case "Papeles":
                            break;
                        case "MATRIZANALISISFINANCIERO":
                            break;
                        case "PROGRAMAS":
                            //1 para programas, 2 para cuestionarios
                            ProgramaModelo currentPrograma = new ProgramaModelo();
                            currentPrograma = ProgramaModelo.GetRegistro((int)currentEntidad.idprograma);
                            if (currentPrograma != null)
                            {
                                if (currentPrograma.idthprograma == 1)
                                {
                                    //Programa
                                    EDDetalleIndiceMainModel.TypeName = "ProgramaModeloImprimirProgramaView";
                                    enviarMensajeCrudPrograma(currentPrograma,1500);
                                }
                                else
                                {
                                    //Cuestionario
                                    EDDetalleIndiceMainModel.TypeName = "CuestionarioModeloImprimirCuestionarioView";
                                    enviarMensajeCrudCuestionario(currentPrograma,1500);
                                }
                            }
                            break;
                        case "REPOSITORIO":
                            RepositorioModelo currentRepositorio = new RepositorioModelo();
                            currentRepositorio = RepositorioModelo.GetRegistro((int)currentEntidad.idgenericoindice);
                            if (currentRepositorio != null)
                            {
                                EDDetalleIndiceMainModel.TypeName = "RepositorioImprimirPDFPreviaView";
                                enviarMensajeRepositorio(currentRepositorio,1500);
                            }
                            break;
                        case "CEDULAS":
                            CedulaModelo currentCedula = new CedulaModelo();
                            currentCedula = CedulaModelo.GetRegistro((int)currentEntidad.idgenericoindice);
                            if (currentCedula != null)
                            {
                                switch (currentCedula.idtc)
                                {
                                    case 1:
                                        EDDetalleIndiceMainModel.TypeName = "CedulaSumariaImprimirPDFPreviaView";
                                        enviarMensajeSumariaImprimir(currentCedula, 1500);
                                        break;
                                    case 6:
                                        ObservableCollection<CedulaHallazgosModelo> listaHallazgos = CedulaHallazgosModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaHallazgosImprimirPDFPreviaView";
                                        enviarMensajeCedulaHallazgosImprimir(currentCedula, listaHallazgos, 1500);
                                        break;
                                    case 7:
                                        ObservableCollection<CedulaNotasModelo> listaNotas = CedulaNotasModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaNotasImprimirPDFPreviaView";
                                        enviarMensajeCedulaNotasImprimir(currentCedula, listaNotas,1500);
                                        break;
                                    case 13:
                                        ObservableCollection<CedulaMarcasModelo> listaMarcas = CedulaMarcasModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaMarcasImprimirPDFPreviaView";
                                        enviarMensajeCedulaMarcasImprimir(currentCedula, listaMarcas, 1500);
                                        break;
                                    case 15:
                                        ObservableCollection<CedulaPartidasModelo>  listaPartidas = new ObservableCollection<CedulaPartidasModelo>(CedulaPartidasModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula));
                                        ObservableCollection<CedulaMovimientoModelo> listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>(CedulaMovimientoModelo.GetAllEdicion(currentEncargo));
                                        ObservableCollection<CedulaDiarioModelo>  listaDiario = CedulaDiarioModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula, listaPartidas, listaMovimientos);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaAjustesYReclasificacionesMsjImprimirPDFPreviaView";
                                        enviarMensajeAjustesYReclasificacionesMsjImprimir(currentCedula, listaDiario, listaMovimientos,listaPartidas, 1500);
                                        break;
                                    case 18:
                                        ObservableCollection<CedulaAgendaModelo> listaAgenda = CedulaAgendaModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaAgendaImprimirPDFPreviaView";
                                        enviarMensajeCedulaAgendaImprimir(currentCedula, listaAgenda, 1500);
                                        break;
                                    case 25:
                                        ObservableCollection<CedulaModelo> listaCentralizadora = new ObservableCollection<CedulaModelo>();

                                        if (currentCedula.idvisita == null || currentCedula.idvisita == 0)
                                        {
                                            //el  tipo de cedula es sumaria por eso se usa  1
                                            listaCentralizadora = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, 1));
                                        }
                                        else
                                        {
                                            //el tipo de cedula es sumaria, por eso se usa 1
                                            //currentEntidad.titulocedula = "Cédula resumen de sumarias general";
                                            listaCentralizadora = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, 1, (int)currentCedula.idvisita));
                                        }
                                        EDDetalleIndiceMainModel.TypeName = "CedulaCentralizadoraImprimirPDFPreviaView";
                                        enviarMensajeCedulaCentralizadoraImprimir(currentCedula, listaCentralizadora,1500);
                                        break;
                                }
                            }
                            break;
                        default:
                            await dlg.ShowMessageAsync(this, "No hay un item referenciado", "No hay nada que se muestre");
                            finComando();
                            break;
                    }
                    
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el elemento a visualizar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para visualizar", "");
            }
        }
        public void enviarMensajeCedulaCentralizadoraImprimir(CedulaModelo currentEntidad, ObservableCollection<CedulaModelo> lista, int valor)
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            elemento.listaMaestroModelo = lista;
            //elemento.listaDetalle = lista;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        public void enviarMensajeSumariaImprimir(CedulaModelo currentEntidad, int valor)
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaNotasImprimir(CedulaModelo currentEntidad, ObservableCollection<CedulaNotasModelo> lista, int valor)
        {
            //Se crea el mensaje
            NotasMsj elemento = new NotasMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = lista;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeAjustesYReclasificacionesMsjImprimir(CedulaModelo currentEntidad, 
            ObservableCollection<CedulaDiarioModelo> lista, 
            ObservableCollection<CedulaMovimientoModelo> listaMovimientos,
            ObservableCollection<CedulaPartidasModelo> listaPartidas,
            int valor)
        {

            //Se crea el mensaje
            AjustesYReclasificacionesMsj elemento = new AjustesYReclasificacionesMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
                                                           //elemento.listaMaestroModelo = lista;
            elemento.listaDiario = lista;
            elemento.listaDetalle = listaPartidas;//Lista completa de diario
            //elemento.entidadDetalle = currentEntidadPartida;
            //elemento.listaDiario = listaDetalles;//Partida de diario en especificio
            //elemento.listaMovimientosPorPartida = listaMovimientosPorPartida;//Movimientos de la partida en particular
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }


        public void enviarMensajeCedulaAgendaImprimir(CedulaModelo currentEntidad, ObservableCollection<CedulaAgendaModelo> listaHallazgos, int valor)
        {
            //Se crea el mensaje
            AgendaMsj elemento = new AgendaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaHallazgos;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaHallazgosImprimir(CedulaModelo currentEntidad, ObservableCollection<CedulaHallazgosModelo> listaHallazgos, int valor)
        {
            //Se crea el mensaje
            HallazgosMsj elemento = new HallazgosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaHallazgos;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaMarcasImprimir(CedulaModelo currentEntidad, ObservableCollection<CedulaMarcasModelo> listaMarcas,int valor)
        {
            //Se crea el mensaje
            MarcasMsj elemento = new MarcasMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaMarcas;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = valor; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        private void enviarMensajeImprimir(MatrizRiesgoModelo currentMatrizRiesgo)
        {
            //Se crea el mensaje
            GenerarReporteMensajeModal elemento = new GenerarReporteMensajeModal();
            elemento.TokenAUtilizar = "GenerameUnReporte"; //OJO, este es el token con el que respondera el reporte.
            elemento.TipoReporteAGenerar = TipoReporteAGenerar.ReporteMatrizRiesgos;

            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.matrizRiesgoModelo = currentMatrizRiesgo;//Para el caso de  edicion de programas
            //elemento.listaMatrizRiesgoModelo = lista;//Aca no hay lista
            Messenger.Default.Send(elemento, "GenerameUnReporte");
        }


        //Aqui se debera enviar a imprimir toda la carpeta
        private void imprimirCarpeta()
        {
            throw new NotImplementedException();
        }

        public async void vistaPreviaReferencia()
        {
            //Depende del tipo de dato de la referencia
            //Seleccione el tipo de tabla a usar y con base en ello se configura el mensaje

            //Obtener la entidad
            //enviar la entidad
            if (lista.Where(x => x.IsSelected).Count() == 1)
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    enviarMensajeInhabilitar();//Para evitar que el usuario  tome otras acciones

                    comando = 12;//Mostrar la referencia
                    switch (currentEntidad.tablaindice)
                    {
                        case "MATRIZRIESGOS":
                            MatrizRiesgoModelo currentMatrizRiesgo = new MatrizRiesgoModelo();
                            currentMatrizRiesgo = MatrizRiesgoModelo.GetRegistro((int)currentEntidad.idgenericoindice);
                            if (currentMatrizRiesgo != null)
                            {
                                    EDDetalleIndiceMainModel.TypeName = "MatrizRiesgoModeloVerView";
                                    enviarMensajeMatrizRiesgo(currentMatrizRiesgo);
                            }
                            break;
                        case "Papeles":
                            break;
                        case "MATRIZANALISISFINANCIERO":
                            break;
                        case "PROGRAMAS":
                            //1 para programas, 2 para cuestionarios
                            ProgramaModelo currentPrograma = new ProgramaModelo();
                            currentPrograma = ProgramaModelo.GetRegistro((int)currentEntidad.idprograma);
                            if (currentPrograma != null)
                            {
                                if (currentPrograma.idthprograma == 1)
                                {
                                    //Programa
                                    EDDetalleIndiceMainModel.TypeName = "ProgramaModeloConsultarProgramaView";
                                    enviarMensajeCrudPrograma(currentPrograma);
                                }
                                else
                                {
                                    //Cuestionario
                                    EDDetalleIndiceMainModel.TypeName = "CuestionarioModeloConsultarCuestionarioView";
                                    enviarMensajeCrudCuestionario(currentPrograma);
                                }
                            }
                            break;
                        case "REPOSITORIO":
                            RepositorioModelo currentRepositorio= new RepositorioModelo();
                            currentRepositorio = RepositorioModelo.GetRegistro((int)currentEntidad.idgenericoindice);
                            if (currentRepositorio != null)
                            {
                                EDDetalleIndiceMainModel.TypeName = "RepositorioVistaPDFPreviaView";
                                enviarMensajeRepositorio(currentRepositorio);
                            }
                            break;
                        case "CEDULAS":
                            CedulaModelo currentCedula = new CedulaModelo();
                            currentCedula = CedulaModelo.GetRegistro((int)currentEntidad.idgenericoindice);
                            if (currentCedula != null)
                            {
                                switch (currentCedula.idtc)
                                {
                                    case 1:
                                        EDDetalleIndiceMainModel.TypeName = "CedulaSumariaAnaliticaVerView";
                                        enviarMensajeSumaria(currentCedula);
                                        break;
                                    case 2:
                                        EDDetalleIndiceMainModel.TypeName = "CedulaSumariaAnaliticasVerPDFPreviaView";
                                        enviarMensajeSumaria(currentCedula);
                                        break;
                                    case 6:
                                        ObservableCollection<CedulaHallazgosModelo> listaHallazgos = CedulaHallazgosModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaHallazgosVerPDFPreviaView";
                                        enviarMensajeCedulaHallazgos(currentCedula, listaHallazgos);
                                        break;
                                    case 7:
                                        ObservableCollection<CedulaNotasModelo> listaNotas = CedulaNotasModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaNotasVerPDFPreviaView";
                                        enviarMensajeCedulaNotas(currentCedula, listaNotas);
                                        break;
                                    case 15:
                                        ObservableCollection<CedulaPartidasModelo> listaPartidas = new ObservableCollection<CedulaPartidasModelo>(CedulaPartidasModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula));
                                        ObservableCollection<CedulaMovimientoModelo> listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>(CedulaMovimientoModelo.GetAllEdicion(currentEncargo));
                                        ObservableCollection<CedulaDiarioModelo> listaDiario = CedulaDiarioModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula, listaPartidas, listaMovimientos);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaAjustesYReclasificacionesMsjVerPDFPreviaView";
                                        enviarMensajeAjustesYReclasificacionesMsj(currentCedula, listaDiario, listaMovimientos, listaPartidas);
                                        break;
                                    case 13:
                                        ObservableCollection<CedulaMarcasModelo> listaMarcas = CedulaMarcasModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaMarcasVistaPDFPreviaView";
                                        enviarMensajeCedulaMarcas(currentCedula, listaMarcas);
                                        break;
                                    case 18:
                                        ObservableCollection<CedulaAgendaModelo> listaAgenda = CedulaAgendaModelo.GetAllEdicion(currentEncargo, currentCedula.idcedula);
                                        EDDetalleIndiceMainModel.TypeName = "CedulaAgendaVerPDFPreviaView";
                                        enviarMensajeCedulaAgenda(currentCedula, listaAgenda);
                                        break;
                                    case 25:
                                        ObservableCollection<CedulaModelo> listaCentralizadora = new ObservableCollection<CedulaModelo>();

                                        if (currentCedula.idvisita == null || currentCedula.idvisita==0)
                                        {
                                            //el  tipo de cedula es sumaria por eso se usa  1
                                            listaCentralizadora = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, 1));
                                        }
                                        else
                                        {
                                            //el tipo de cedula es sumaria, por eso se usa 1
                                            //currentEntidad.titulocedula = "Cédula resumen de sumarias general";
                                            listaCentralizadora = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, 1, (int)currentCedula.idvisita));
                                        }
                                        EDDetalleIndiceMainModel.TypeName = "CedulaCentralizadoraPDFPreviaView";
                                        enviarMensajeCedulaCentralizadora(currentCedula, listaCentralizadora);
                                        break;

                                }
                            }
                            break;
                        default:
                            await dlg.ShowMessageAsync(this, "No hay un item referenciado", "No hay nada que se muestre");
                            finComando();
                            break;
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el elemento a visualizar", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para visualizar", "");
            }
        }
        public void enviarMensajeCedulaCentralizadora(CedulaModelo currentEntidad, ObservableCollection<CedulaModelo> listaMarcas)
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaMaestroModelo = listaMarcas;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeSumaria(CedulaModelo currentEntidad)
        {
            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaNotas(CedulaModelo currentEntidad, ObservableCollection<CedulaNotasModelo> listaMarcas)
        {
            //Se crea el mensaje
            NotasMsj elemento = new NotasMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaMarcas;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        public void enviarMensajeAjustesYReclasificacionesMsj(CedulaModelo currentEntidad,
            ObservableCollection<CedulaDiarioModelo> lista,
            ObservableCollection<CedulaMovimientoModelo> listaMovimientos,
            ObservableCollection<CedulaPartidasModelo> listaPartidas)
        {

            //Se crea el mensaje
            AjustesYReclasificacionesMsj elemento = new AjustesYReclasificacionesMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
                                                           //elemento.listaMaestroModelo = lista;
            elemento.listaDiario = lista;
            elemento.listaDetalle = listaPartidas;//Lista completa de diario
            //elemento.entidadDetalle = currentEntidadPartida;
            //elemento.listaDiario = listaDetalles;//Partida de diario en especificio
            //elemento.listaMovimientosPorPartida = listaMovimientosPorPartida;//Movimientos de la partida en particular
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaAgenda(CedulaModelo currentEntidad, ObservableCollection<CedulaAgendaModelo> listaMarcas)
        {
            //Se crea el mensaje
            AgendaMsj elemento = new AgendaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaMarcas;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaHallazgos(CedulaModelo currentEntidad, ObservableCollection<CedulaHallazgosModelo> listaMarcas)
        {
            //Se crea el mensaje
            HallazgosMsj elemento = new HallazgosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaMarcas;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajeCedulaMarcas(CedulaModelo currentEntidad, ObservableCollection<CedulaMarcasModelo> listaMarcas)
        {
            //Se crea el mensaje
            MarcasMsj elemento = new MarcasMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
            //elemento.listaMaestroModelo = lista;
            elemento.listaDetalle = listaMarcas;
            //elemento.entidadDetalle = currentEntidadDetalle;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        private void enviarMensajeRepositorio(RepositorioModelo currentRepositorio)
        {
            //Se crea el mensaje
            RepositorioMsj elemento = new RepositorioMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.opcionMenuCrud = comando;
            elemento.entidadTrasladada = currentRepositorio;
            //elemento.lista = lista;
            elemento.tokenRespuestaController = tokenRespuestaReferenciaVista;
            elemento.tokenRespuestaVista = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = 5; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        private void enviarMensajeRepositorio(RepositorioModelo currentRepositorio, int fuente)
        {
            //Se crea el mensaje
            RepositorioMsj elemento = new RepositorioMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.opcionMenuCrud = comando;
            elemento.entidadTrasladada = currentRepositorio;
            //elemento.lista = lista;
            elemento.tokenRespuestaController = tokenRespuestaReferenciaVista;
            elemento.tokenRespuestaVista = tokenRespuestaReferenciaVista;
            elemento.fuenteLlamado = fuente; //no se utilizaa
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        //Caso de nuevo registro 
        public void enviarMensajeMatrizRiesgo(MatrizRiesgoModelo currentMatrizRiesgo)
        {
            //Para consulta
            //Se crea el mensaje
            RiesgoMsj elemento = new RiesgoMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.matrizRiesgoModelo = currentMatrizRiesgo;//Para el caso de  edicion de programas
            //elemento.listaMatrizRiesgoModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 5; //Comando desde el principal
            elemento.tokenRespuesta = tokenRespuestaReferenciaVista; 
            Messenger.Default.Send(elemento, tokenReferenciaVista);
        }
        public void enviarMensajeMatrizRiesgo(MatrizRiesgoModelo currentMatrizRiesgo, int fuenteRiesgo)
        {
            //Para impresion
            //Se crea el mensaje
            RiesgoMsj elemento = new RiesgoMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.matrizRiesgoModelo = currentMatrizRiesgo;//Para el caso de  edicion de programas
            //elemento.listaMatrizRiesgoModelo = lista;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = fuenteRiesgo; //Comando desde el principal
            elemento.tokenRespuesta = tokenRespuestaReferenciaVista;
            Messenger.Default.Send(elemento, tokenReferenciaVista);
        }
        public void enviarMensajeCrudPrograma(ProgramaModelo currentPrograma)
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.programaModelo = currentPrograma;//Programa a crear 
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = null;
            //elemento.opcionTipoPrograma = opcionTipoPrograma;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 12;//Llamado desde principal documentacion
            elemento.tokenRespuesta = tokenRespuestaReferenciaVista;
            //elemento.listaProgramaModelo = lista;
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            Messenger.Default.Send(elemento, tokenReferenciaVista);
        }
        public void enviarMensajeCrudCuestionario(ProgramaModelo currentPrograma)
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.programaModelo = currentPrograma;//Programa a crear 
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = null;
            //elemento.opcionTipoPrograma = opcionTipoPrograma;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 12;//Llamado desde principal documentacion
            elemento.tokenRespuesta = tokenRespuestaReferenciaVista;
            //elemento.listaProgramaModelo = lista;
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            Messenger.Default.Send(elemento, tokenReferenciaVista);
        }

        public void enviarMensajeCrudPrograma(ProgramaModelo currentPrograma, int fuente)
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.programaModelo = currentPrograma;//Programa a crear 
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = null;
            //elemento.opcionTipoPrograma = opcionTipoPrograma;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = fuente;//Llamado desde principal documentacion
            elemento.tokenRespuesta = tokenRespuestaReferenciaVista;
            //elemento.listaProgramaModelo = lista;
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            Messenger.Default.Send(elemento, tokenReferenciaVista);
        }
        public void enviarMensajeCrudCuestionario(ProgramaModelo currentPrograma, int fuente)
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            elemento.programaModelo = currentPrograma;//Programa a crear 
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = null;
            //elemento.opcionTipoPrograma = opcionTipoPrograma;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = fuente;//Llamado desde principal documentacion
            elemento.tokenRespuesta = tokenRespuestaReferenciaVista;
            //elemento.listaProgramaModelo = lista;
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            Messenger.Default.Send(elemento, tokenReferenciaVista);
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
                    EDDetalleIndiceMainModel.TypeName = "DetalleIndiceModeloReferenciarview";
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
            Messenger.Default.Send(currentCarpeta.id, tokenEnvioDatosAMenu);
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
                EDDetalleIndiceMainModel.TypeName = "TipoCarpetaModeloVerProgramaView";
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
            if(comando==12)
            { 
            enviarMensajeHabilitar();
            }
            //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
            comando = 0;
        }


        #endregion Fin de comando

    }
}