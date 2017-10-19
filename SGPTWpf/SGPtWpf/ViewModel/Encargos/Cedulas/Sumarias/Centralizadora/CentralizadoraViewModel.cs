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
using SGPTmvvm.Mensajes;
using System.Linq;
using SGPtmvvm.Mensajes;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using System.Threading.Tasks;
using System.ComponentModel;
using CapaDatos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Centralizadora
{
    //22-06-2017

    public sealed class CentralizadoraViewModel : ViewModeloBase
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


        #region tokenEnvioVista

        private string _tokenEnvioVista;
        private string tokenEnvioVista
        {
            get { return _tokenEnvioVista; }
            set { _tokenEnvioVista = value; }
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
        //6;"Agenda";"A";TRUE
        //7;"Notas";"A";TRUE
        //8;"Correspondencia";"A";TRUE
        //9;"Reuniones";"A";TRUE
        //10;"Contactos";"A";TRUE
        //11;"Expediente";"A";TRUE
        //12;"CedulaModelos";"A";TRUE
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

        #region visibilidadMResponder

        public const string visibilidadMResponderPropertyName = "visibilidadMResponder";

        private Visibility _visibilidadMResponder = Visibility.Collapsed;

        public Visibility visibilidadMResponder
        {
            get
            {
                return _visibilidadMResponder;
            }

            set
            {
                if (_visibilidadMResponder == value)
                {
                    return;
                }

                _visibilidadMResponder = value;
                RaisePropertyChanged(visibilidadMResponderPropertyName);
            }
        }

        #endregion

        #region origenMenu

        private string _origenMenu;
        private string origenMenu
        {
            get { return _origenMenu; }
            set { _origenMenu = value; }
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

        private ObservableCollection<CedulaModelo> _listaDetalles;

        public ObservableCollection<CedulaModelo> listaDetalles
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

        private CedulaModelo _currentEntidadDetalle;

        public CedulaModelo currentEntidadDetalle
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

        public RelayCommand vistaCommand { get; set; }

        public RelayCommand aprobarTareaCommand { get; set; }
        public RelayCommand ResponderCommand { get; set; }
        public RelayCommand referenciarCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }
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


        //Llamado desde documentacion
        public CentralizadoraViewModel(string origen)//Documentacion/Carpetas
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
                case "cedulasResumenSumariasDetalle":
                    fuenteLlamado = 1;
                    _idtc = 25;//

                    _menuElegido = "Cedulas";
                    _nombreopcionor = "Sumarias";

                    //15;"Resumen de cuentas";"A";TRUE
                    #region tokens
                    _permitirArrastrar = true;//Permite al usuario arrastrar
                    _tokenRecepcionPadre = "datosEncargoCedulasSumarias";//Permite captar los mensajes del  view model BalancesViewModel
                    _tokenEnvioDatosAHijo = "datosEncargoCedulasSumariasCentralizadora";  //Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosControllerEncargoCedulasSumariasCentralizadora";
                    _tokenEnvioDatosAMenu = "PlanDetalleIndiceRegreso"; //Para regresar al menu anterior.
                    _tokenReferenciaVista = "datosControllerEncargoCedulasSumariasCentralizadoraReferenciaVista";
                    _tokenRecepcionVista = "datosControllerEncargoCedulasSumariasCentralizadoraCambioOrden";

                    _tokenEnvioVista = "datosControllerEncargoCedulasSumariasCentralizadoraDatosVista";
                    _tokenRespuestaReferenciaVista = "RespuestaDatosControllerEncargoCedulasSumariasCentralizadoraReferenciaVista";

                    #endregion

                    RegisterCommands();
                    _tablaDetalle = "resumenSumariascedulas"; 
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMResponder = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Visible;
                    _visibilidadMSupervisar = Visibility.Visible;
                    _visibilidadMAprobar = Visibility.Visible;
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

            //Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            currentEntidadDetalle = new CedulaModelo();


            _comando = 0;
            dlg = new DialogCoordinator();
            _lista = new ObservableCollection<CedulaModelo>();//Lista vacia no se conoce el encargo y el cliente
            _listaDetalles = new ObservableCollection<CedulaModelo>();
            _listaMaestro = new ObservableCollection<CedulaModelo>();
            ECMainModel = new MainModel();
            _listaMaestro = new ObservableCollection<CedulaModelo>();
            //Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));

            Messenger.Default.Register<CedulaMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlRecepcionDatos(datosMsj));
            currentEncargo = null;
            currentEntidad = null;
            currentSistemaContable = null;
            _comando = 0;
            dlg = new DialogCoordinator();
            lista = new ObservableCollection<CedulaModelo>();//Lista vacia no se conoce el encargo y el cliente
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


        private void permisos()
        {
            if (currentUsuario.listaPermisos != null)
            {
                try
                {
                    #region permisos
                    switch (origenLlamada)
                    {
                        case "cedulasResumenSumariasDetalle":
                            #region configuracion

                            //_menuElegido = "Cedulas";
                            //_nombreopcionor = "Sumarias";

                            #region configuracion

                            if (currentUsuario.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()) > 0)
                            {
                                #region  permisos asignados
                                //_menuElegido = "Cedulas";
                                //_nombreopcionor = "Sumarias";
                                permisosrolesusuario permisosAsignados = currentUsuario.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == nombreopcionor.ToUpper()
                                && x.submenupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {
                                    #region crear-importar-detalle

                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                        _visibilidadMImportar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                        _visibilidadMResumen = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                        _visibilidadMImportar = Visibility.Collapsed;
                                        _visibilidadMResumen = Visibility.Collapsed;
                                    }

                                    #endregion crear

                                    #region editar-referenciar-cerrar-detalle
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Visible;
                                        _visibilidadMReferenciar = Visibility.Visible;
                                        _visibilidadMCerrar = Visibility.Visible;
                                        _visibilidadMDetalle = Visibility.Visible;
                                        _visibilidadMResumen = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                        _visibilidadMReferenciar = Visibility.Collapsed;
                                        _visibilidadMCerrar = Visibility.Collapsed;
                                        _visibilidadMResumen = Visibility.Collapsed;
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
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Collapsed;
                            //_visibilidadMReferenciar = Visibility.Visible;//Pendiente
                            _visibilidadMRegresar = Visibility.Visible;
                            _visibilidadMVista = Visibility.Visible;
                            _visibilidadMImportar = Visibility.Collapsed;
                            _visibilidadMDetalle = Visibility.Collapsed;

                            //_visibilidadMCerrar = Visibility.Collapsed;
                            //_visibilidadMSupervisar = Visibility.Collapsed;
                            //_visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMTask = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                            _visibilidadMResumen = Visibility.Collapsed;
                            _visibilidadMResponder = Visibility.Collapsed;
                            _visibilidadPdf = Visibility.Collapsed;
                            #endregion

                            #endregion

                            break;
                    }
                    #endregion

                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al identificar los permisos\nRevise la opción programada\n" + e.ToString());
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadMResumen = Visibility.Collapsed;
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("No están definidos los permisos\nRevise los permisos del usuario");
                #region  menu

                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Collapsed;
                _visibilidadMReferenciar = Visibility.Collapsed;
                _visibilidadMRegresar = Visibility.Visible;
                _visibilidadMVista = Visibility.Visible;
                _visibilidadMImportar = Visibility.Collapsed;
                _visibilidadMDetalle = Visibility.Collapsed;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMTask = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;
                _visibilidadMResumen = Visibility.Collapsed;
                #endregion
            }

        }
        private async void ControlRecepcionDatos(CedulaMsj msj)
        {

            currentEncargo = msj.encargoModelo;//Encargo en uso actual
            currentUsuario = msj.usuarioModelo;
            currentMaestro = msj.entidadMaestroModelo;
            tokenEnvioDatosAMenu = msj.tokenRecepcionSubMenuDetalle;

            //No se desuscribe porque continua existiendo
            if (currentMaestro.fechabalancebalance != null)
            {
                fechaBalanceActual = currentMaestro.fechabalancebalance;
            }
            if (currentMaestro.fechabalancebalanceComparativo != null)
            {
                fechaBalanceAnterior = currentMaestro.fechabalancebalanceComparativo;
            }

            //Verificar que exista el  registro de cedulay en caso  contrario crearlo
            if (currentMaestro.idvisita == 100)
            {
                currentEntidad = CedulaModelo.FindMaestro(currentEncargo.idencargo, idtc, "Cédula resumen de sumarias general");
            }
            else
            {
                currentEntidad = CedulaModelo.FindMaestro(currentEncargo.idencargo, idtc, "Cédula resumen de sumarias en " + currentMaestro.descripcionvisita,(int) currentMaestro.idvisita);
            }
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
                    currentEntidad.usuarioModelo = currentUsuario;
                    currentEntidad.idbalance = currentMaestro.idbalance;
                    currentEntidad.idbalanceanterior = currentMaestro.idbalanceanterior;
                    if (currentMaestro.idvisita!=null && currentMaestro.idvisita != 100 )
                    {
                        currentEntidad.idvisita = currentMaestro.idvisita;
                        currentEntidad.titulocedula = "Cédula resumen de sumarias en " + currentMaestro.descripcionvisita;
                    }
                    else
                    {
                        currentEntidad.titulocedula = "Cédula resumen de sumarias general";

                    }
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
            listaMaestro.Add(currentEntidad);
            if (lista.Count(x => x.idbalanceanterior != null && x.idbalanceanterior != 0) > 0)
            {
                visibilidadBalanceAnterior = Visibility.Visible;
            }
            else
            {
                visibilidadBalanceAnterior = Visibility.Collapsed;
            }

            permisos();
            inicializacionTerminada();
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
            Messenger.Default.Unregister<CedulaMsj>(this, tokenRecepcionPadre);

        }


        private void actualizarLista()
        {
            //guardarlista();
            try
            {
                if (currentMaestro.idvisita == 100)
                {
                    //el  tipo de cedula es sumaria por eso se usa  1
                    lista = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, 1));
                }
                else
                {
                    //el tipo de cedula es sumaria, por eso se usa 1
                    //currentEntidad.titulocedula = "Cédula resumen de sumarias general";
                    lista = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAllResumen(currentEncargo.idencargo, 1,(int) currentMaestro.idvisita));
                }

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e, "");
                    lista = new ObservableCollection<CedulaModelo>();
                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }




        #endregion


        //Caso de nuevo registro 
        public void enviarMensaje()
        {

            //Se crea el mensaje
            CedulaMsj elemento = new CedulaMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentEntidad;//Para el caso de  edicion de programas
                                                           //elemento.listaDiario = listaDetalles;//Partida de diario en especificio
            elemento.listaMaestroModelo = lista;
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
                    break;
                case 14://Desplazamiento a ver el detalle del usuario
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
        public async void Nuevo()
        {
            await mensajeAutoCerrado("No  utilizado", "", 1);
        }

        public void Editar()
        {
            //Para guardar lo que esta en la  pantalla
        }
        public async void Consultar()
        {
            //Para guardar lo que esta en la  pantalla
            // ControlCambioLista(true);

            if (!(currentEntidadDetalle == null))
            {
                iniciarComando();
                comando = 3;
                #region filtrado
                //Con base a seleccion de partida currentEntidadDetalle
                //currentEntidadPartida = listaPartidas.SingleOrDefault(x => x.idcedula == currentEntidadDetalle.idcedula);
                #endregion
                ECMainModel.TypeName = "CedulaCentralizadoraConsultarView";
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }

        }


        public void Borrar()
        {

        }


        public void BorrarLogico()
        {

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
            return false;
        }

        public bool CanCommand()
        {
            if (!(currentEntidadDetalle == null))
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


        #region ViewModel Private Methods


        private void RegisterCommands()
        {
            //Aplica para la  opcion de documentacion

            //cmdCargarCatalogo = new RelayCommand(cargarCC, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, CanNuevo);//ok
            EditarCommand = new RelayCommand(Editar, CanEditar);
            BorrarCommand = new RelayCommand(Borrar, CanBorrar);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            copiarCommand = new RelayCommand(Responder, CanEditar);
            DoubleClickCommand = new RelayCommand(Nada);
            SelectionChangedCommand = new RelayCommand<CedulaModelo>(entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                if (entidad.idcedula != 0)
                {
                    //se actualiza
                }
                currentEntidadDetalle = entidad;
            });

            vistaCommand = new RelayCommand(vistaPapel);

            ResponderCommand = new RelayCommand(Responder, CanResponder);//ok
            aprobarTareaCommand = new RelayCommand(aprobarTarea, CanAprobarTarea);

            terminarPapelCommand = new RelayCommand(cerrarPapel, CanTerminar);
            supervisarCommand = new RelayCommand(supervisarPapel, CanSupervisar);
            aprobarCommand = new RelayCommand(aprobarPapel, CanAprobar);
            agendaCommand = new RelayCommand(tareasPapel, CanCommand);
            referenciarCommand = new RelayCommand(referenciarPrograma);//Para guardar la referencia

            irMenuPadreCommand = new RelayCommand(irPrincipal);


        }
        private void irPrincipal()
        {
            iniciarComando();
            //Mandar el mensaje al principal que domina la pantalla
            Messenger.Default.Send(currentMaestro.idcedula, tokenEnvioDatosAMenu);
        }

        private bool CanAprobarTarea()
        {
            return true;
        }

        private bool CanResponder()
        {
            return false;
        }

        public void aprobarTarea()
        {

        }



        public async void Responder()
        {
            await mensajeAutoCerrado("Pendiente", "Próximo a utilizar", 2);
        }


        private async void referenciarPrograma()
        {
            {
                if (!(currentEntidad == null))
                {
                    iniciarComando();
                    comando = 8;//Referenciacion
                    ECMainModel.TypeName = "CedulaCentralizadoraReferenciarView";
                    #region Configuracion
                    currentEntidad.usuarioModelo = currentUsuario;
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
            return false;
        }

        private bool CanNuevo()
        {
            return (currentEntidad.usuariocerro == null || currentEntidad.usuariocerro == string.Empty);
        }

        private bool CanBorrar()
        {
            return false;
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

                ECMainModel.TypeName = "CedulaCentralizadoraAprobarView";
                #region Configuracion
                currentEntidad.usuarioModelo = currentUsuario;
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

                    ECMainModel.TypeName = "CedulaCentralizadoraSupervisarView";
                    #region Configuracion
                    currentEntidad.usuarioModelo = currentUsuario;
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
                    if (lista.Count(x => x.estadocedula == "Propuesta") == 0)
                    {
                        if (currentEntidad.referenciacedula != string.Empty)
                        {
                            comando = 10;//Referenciacion
                            iniciarComando();

                            ECMainModel.TypeName = "CedulaCentralizadoraCerrarView";
                            #region Configuracion
                            currentEntidad.usuarioModelo = currentUsuario;
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
                        finComando();
                        await dlg.ShowMessageAsync(this, "Debe aprobar las partidas ", "antes de cerrar la cédula");

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

                ECMainModel.TypeName = "CedulaCentralizadoraCerrarView";
                enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }

        }



        private void vistaPapel()
        {
            comando = 5;
            iniciarComando();
            //currentEntidadDetalle.usuarioaprobo = currentUsuario;
            //currentEntidadDetalle.fechacreadoagenda = MetodosModelo.homologacionFecha();
            ECMainModel.TypeName = "CedulaCentralizadoraVerView";
            enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

        }


        private async void mostrarCantidad(int i)
        {
            await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
        }



        private async void Buscar()
        {
            await mensajeAutoCerrado("No utilizado", "No requerido", 1);
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