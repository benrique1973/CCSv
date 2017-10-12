using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.NormaLegal;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.PDF;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Messages.Genericos;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Linq;
using CapaDatos;
using System.Threading.Tasks;

namespace SGPTWpf.ViewModel.Crud.CatalogoNormaLegalIndice
{

    public sealed class CatalogoNormaLegalViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        public string tokenNormaLegalBinarioEnvio = "NormaLegalBinario";

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<NormativaModelo> _listaEntidadSeleccion;

        public ObservableCollection<NormativaModelo> listaEntidadSeleccion
        {
            get
            {
                return _listaEntidadSeleccion;
            }
            set
            {
                if (_listaEntidadSeleccion == value) return;

                _listaEntidadSeleccion = value;

                RaisePropertyChanged(listaEntidadSeleccionPropertyName);
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

        int idUsuario = 0;//Temporal el numero de usuario
        private static int comando = 0;
        private DialogCoordinator dlg;
        private bool controlPdfListados = false; //Controla los casos que no se halla el pdf en la lista por la actualizacion
        private static int? idln = 0;


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

        #region procesamiento Archivos

        #region ViewModel Properties : fileName

        public const string fileNamePropertyName = "fileName";

        private string _fileName;

        public string fileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                if (_fileName == value)
                {
                    return;
                }

                _fileName = value;
                RaisePropertyChanged(fileNamePropertyName);
            }
        }

        #endregion

        #endregion

        #region procesos en gestion

        #region ViewModel Properties : isBusy

        public const string isBusyPropertyName = "isBusy";

        private bool _isBusy;

        public bool isBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged(isBusyPropertyName);
            }
        }

        #endregion

        #region visibilidadProcesando

        public const string visibilidadProcesandoPropertyName = "visibilidadProcesando";

        private Visibility _visibilidadProcesando;

        public Visibility visibilidadProcesando
        {
            get
            {
                return _visibilidadProcesando;
            }

            set
            {
                if (_visibilidadProcesando == value)
                {
                    return;
                }

                _visibilidadProcesando = value;
                RaisePropertyChanged(visibilidadProcesandoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadLoguin

        public const string accesibilidadLoguinPropertyName = "accesibilidadLoguin";

        private bool _accesibilidadLoguin;

        public bool accesibilidadLoguin
        {
            get
            {
                return _accesibilidadLoguin;
            }

            set
            {
                if (_accesibilidadLoguin == value)
                {
                    return;
                }

                _accesibilidadLoguin = value;
                RaisePropertyChanged(accesibilidadLoguinPropertyName);
            }
        }

        #endregion

        #endregion


        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista

        public const string ListaPropertyName = "Lista";

        private ObservableCollection<NormativaModelo> _Lista;

        public ObservableCollection<NormativaModelo> Lista
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

        #region visibilidadPdf

        public const string visibilidadPdfPropertyName = "visibilidadPdf";

        private Visibility _visibilidadPdf;

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


        #region visibilidadVistaPdf

        public const string visibilidadVistaPdfPropertyName = "visibilidadVistaPdf";


        private bool _visibilidadVistaPdf = false;

        public bool visibilidadVistaPdf
        {
            get
            {
                return _visibilidadVistaPdf;
            }

            set
            {
                if (_visibilidadVistaPdf == value)
                {
                    return;
                }

                _visibilidadVistaPdf = value;
                RaisePropertyChanged(visibilidadVistaPdfPropertyName);
            }
        }


        #endregion

        #region Descripcion de norma

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

        #region  Primary key

        public const string idPropertyName = "id";

        private int _id = 0;

        public int idtei
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

        #region Sistema

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        public bool sistema
        {
            get
            {
                return _sistema;
            }

            set
            {
                if (_sistema == value)
                {
                    return;
                }

                _sistema = value;
                RaisePropertyChanged(sistemaPropertyName);
            }
        }

        #endregion



        #region binarioNormativa

        public const string binarioNormativaPropertyName = "binarioNormativa";

        private byte[] _binarioNormativa = null;

        public byte[] binarioNormativa
        {
            get
            {
                return _binarioNormativa;
            }

            set
            {
                if (_binarioNormativa == value)
                {
                    return;
                }

                _binarioNormativa = value;
                RaisePropertyChanged(binarioNormativaPropertyName);
            }
        }

        #endregion


        #region Estado

        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        public string estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(estadoPropertyName);
            }
        }
        #endregion

        #region nombrearchivonormativa

        public const string nombrearchivonormativaPropertyName = "nombrearchivonormativa";

        private string _nombrearchivonormativa = string.Empty;

        public string nombrearchivonormativa
        {
            get
            {
                return _nombrearchivonormativa;
            }

            set
            {
                if (_nombrearchivonormativa == value)
                {
                    return;
                }

                _nombrearchivonormativa = value;
                RaisePropertyChanged(nombrearchivonormativaPropertyName);
            }
        }
        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private NormativaModelo _currentEntidad;

        public NormativaModelo currentEntidad
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


        #region currentEntidadNueva//Se usa en el caso de se cree un registro

        public const string currentEntidadNuevaPropertyName = "currentEntidadNueva";

        private NormativaModelo _currentEntidadNueva;
        public NormativaModelo currentEntidadNueva
        {
            get
            {
                return _currentEntidadNueva;
            }

            set
            {
                if (_currentEntidadNueva == value) return;

                _currentEntidadNueva = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadNuevaPropertyName);
            }
        }
        #endregion

        #region ViewModel Property : currentEntidadNorma

        public const string currentEntidadNormaPropertyName = "currentEntidadNorma";

        private LegalNormaModelo _currentEntidadNorma;

        public LegalNormaModelo currentEntidadNorma
        {
            get
            {
                return _currentEntidadNorma;
            }

            set
            {
                if (_currentEntidadNorma == value) return;

                _currentEntidadNorma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadNormaPropertyName);
            }
        }

        #endregion

        #endregion

        #region viewTypePdf

        public const string viewTypePdfPropertyName = "viewTypePdf";

        private string _viewTypePdf = "SinglePage";

        public string viewTypePdf
        {
            get
            {
                return _viewTypePdf;
            }

            set
            {
                if (_viewTypePdf == value)
                {
                    return;
                }

                _viewTypePdf = value;
                RaisePropertyChanged(viewTypePdfPropertyName);
            }
        }

        #endregion


        #region viewPaginaPdf

        public const string viewPaginaPdfPropertyName = "viewPaginaPdf";

        private string _viewPaginaPdf = string.Empty;

        public string viewPaginaPdf
        {
            get
            {
                return _viewPaginaPdf;
            }

            set
            {
                if (_viewPaginaPdf == value)
                {
                    return;
                }

                _viewPaginaPdf = value;
                RaisePropertyChanged(viewPaginaPdfPropertyName);
            }
        }

        #endregion


        #region totalPaginas

        public const string totalPaginasPropertyName = "totalPaginas";

        private int _totalPaginas = 0;

        public int totalPaginas
        {
            get
            {
                return _totalPaginas;
            }

            set
            {
                if (_totalPaginas == value)
                {
                    return;
                }

                _totalPaginas = value;
                RaisePropertyChanged(totalPaginasPropertyName);
            }
        }

        #endregion

        #region paginaDestino

        public const string paginaDestinoPropertyName = "paginaDestino";

        private int _paginaDestino = 1;

        public int paginaDestino
        {
            get
            {
                return _paginaDestino;
            }

            set
            {
                if (_paginaDestino == value)
                {
                    return;
                }

                _paginaDestino = value;
                RaisePropertyChanged(paginaDestinoPropertyName);
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
        public RelayCommand ExportarPdfCommand { get; set; }
        public RelayCommand VerVistaCommand { get; set; }
        public RelayCommand cambiarVistaPageCommand { get; set; }
        public RelayCommand cambiarContinuaPageCommand { get; set; }
        public RelayCommand rotarIzquierdaCommand { get; set; }

        public RelayCommand rotarDerechaCommand { get; set; }

        public RelayCommand zoomInCommand { get; set; }
        public RelayCommand zoomOutCommand { get; set; }

        public RelayCommand paginaInicialCommand { get; set; }
        public RelayCommand paginaPreviaCommand { get; set; }
        public RelayCommand paginaSiguienteCommand { get; set; }
        public RelayCommand paginaUltimaCommand { get; set; }
        public RelayCommand paginaEscogerCommand { get; set; }

        public RelayCommand genericoCommand { get; set; }
        public RelayCommand<NormativaModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region NormaMainModel

        private MainModel _mainModel = null;

        public MainModel NormaMainModel
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

        #region ViewModel Public Methods

        #region Constructores


        public CatalogoNormaLegalViewModel(string origen)
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            switch (origen)
            {
                case "Normas":
                    _origenLlamada = origen;
                    _menuElegido = "Normas";
                    #region  menu

                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
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
                    break;
                case "Normativa":
                     menuElegido = "Herramientas";
                    _origenLlamada = origen;
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
                    break;
            }




            if (!(currentEntidadNorma == null))
            {
                if (!((NormativaModelo.ContarRegistros(currentEntidadNorma.id) == 0)))
                {
                    Lista = new ObservableCollection<NormativaModelo>(NormativaModelo.GetAll(currentEntidadNorma.id));
                }
            }
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<VentanaViewMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            //Mensaje que recibe el pdf que eligio
            Messenger.Default.Register<NormativaPDFmensaje>(this, (normativaPDFmensaje) => ControlNormativaPDFmensaje(normativaPDFmensaje));
            Messenger.Default.Register<TotalPagesMessages>(this, (totalPagesMessages) => ControlTotalPagesMessages(totalPagesMessages));
            Messenger.Default.Register<CurrentPageMensaje>(this, (currentPageMensaje) => ControlCurrentPageMensaje(currentPageMensaje));
            //Seleccion de opcion de herramientas
            Messenger.Default.Register<NormaLegalSeleccionMensaje>(this, (normaLegalSeleccionMensaje) => ControlNormaLegalSeleccionMensaje(normaLegalSeleccionMensaje));

            Lista = new ObservableCollection<NormativaModelo>(NormativaModelo.GetAllEncabezados());
            visibilidadPdf = Visibility.Collapsed;
            NormaMainModel = new MainModel();

            #region control de procesado

            _visibilidadProcesando = Visibility.Collapsed;
            _accesibilidadLoguin = true;
            _accesibilidadWindow = false;
            _isBusy = false;

            #endregion

            fileName = "";
            _tokenRecepcionPadre = "finCargaNormativaVista";
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
            if (currentUsuario != null)
            {
                #region evaluacion

                if (currentUsuario.listaPermisos != null)
                {
                    try
                    {
                        if (currentUsuario != null)
                        {
                            if (currentUsuario.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()) > 0)
                            {
                                #region  permisos asignados

                                permisosrolesusuario permisosAsignados = currentUsuario.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()
                                && x.menupru.ToUpper() == menuElegido.ToUpper());

                                if (permisosAsignados != null)
                                {


                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMCrear = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMCrear = Visibility.Collapsed;
                                    }
                                    if (permisosAsignados.editarpru)
                                    {
                                        _visibilidadMEditar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMEditar = Visibility.Collapsed;
                                    }
                                    if (permisosAsignados.consultarpru)
                                    {
                                        _visibilidadMConsulta = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMConsulta = Visibility.Collapsed;
                                    }
                                    if (permisosAsignados.eliminarpru)
                                    {
                                        _visibilidadMBorrar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMBorrar = Visibility.Collapsed;
                                    }
                                    if (permisosAsignados.impresionpru)
                                    {
                                        _visibilidadMVista = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMVista = Visibility.Collapsed;
                                    }
                                    if (permisosAsignados.crearpru)
                                    {
                                        _visibilidadMImportar = Visibility.Visible;
                                    }
                                    else
                                    {
                                        _visibilidadMImportar = Visibility.Collapsed;
                                    }
                                }
                                else
                                {
                                    if(menuElegido != "Normas")
                                    MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                                }
                                #endregion fin de region de permisos
                            }
                            else
                            {
                                if (menuElegido != "Normas")
                                    MessageBox.Show("Error en opción y la base de datos\nRevise la opción programada");
                            }
                        }
                        else
                        {
                            #region  menu
                            _visibilidadMCrear = Visibility.Collapsed;
                            _visibilidadMEditar = Visibility.Collapsed;
                            _visibilidadMBorrar = Visibility.Collapsed;
                            _visibilidadMConsulta = Visibility.Visible;
                            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                            _visibilidadMRegresar = Visibility.Collapsed;
                            _visibilidadMVista = Visibility.Visible;
                            _visibilidadMImportar = Visibility.Visible;
                            _visibilidadMDetalle = Visibility.Collapsed;

                            _visibilidadMCerrar = Visibility.Collapsed;
                            _visibilidadMSupervisar = Visibility.Collapsed;
                            _visibilidadMAprobar = Visibility.Collapsed;
                            _visibilidadMImprimir = Visibility.Collapsed;
                            #endregion                    }
                        }
                    }
                    catch (Exception)
                    {
                        if (menuElegido != "Normas")
                            MessageBox.Show("Error al identificar los permisos\nRevise la opción programada");
                        #region  menu
                        _visibilidadMCrear = Visibility.Collapsed;
                        _visibilidadMEditar = Visibility.Collapsed;
                        _visibilidadMBorrar = Visibility.Collapsed;
                        _visibilidadMConsulta = Visibility.Collapsed;
                        _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                        _visibilidadMRegresar = Visibility.Collapsed;
                        _visibilidadMVista = Visibility.Visible;
                        _visibilidadMImportar = Visibility.Visible;
                        _visibilidadMDetalle = Visibility.Collapsed;

                        _visibilidadMCerrar = Visibility.Collapsed;
                        _visibilidadMSupervisar = Visibility.Collapsed;
                        _visibilidadMAprobar = Visibility.Collapsed;
                        _visibilidadMImprimir = Visibility.Collapsed;
                        #endregion
                    }
                }
                else
                {
                    #region  menu
                    if (menuElegido != "Normas")
                        MessageBox.Show("No están definidos los permisos\nRevise los permisos del usuario");
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
                    _visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                }

                #endregion fin de evaluacion
            }
            else
            {
                #region  menu
                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Visible;
                _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                _visibilidadMRegresar = Visibility.Collapsed;
                _visibilidadMVista = Visibility.Visible;
                _visibilidadMImportar = Visibility.Visible;
                _visibilidadMDetalle = Visibility.Collapsed;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;
                #endregion                    }
            }


        }


        private void ControlNormaLegalSeleccionMensaje(NormaLegalSeleccionMensaje normaLegalSeleccionMensaje)
        {
            idln = normaLegalSeleccionMensaje.idln;
            currentEntidad = NormativaModelo.Clear(currentEntidad);
            currentUsuario = normaLegalSeleccionMensaje.usuarioValidadoMensaje;
            if (currentUsuario == null)
            {
                idUsuario = 0;//Sustitucion del usuario
            }
            else
            {
                idUsuario = currentUsuario.idUsuario;
            }

            permisos();

            inicializacionTerminada();
        }

        #region procesando archivos pesados

        private void ControlNormativaPDFmensaje(NormativaPDFmensaje normativaPDFmensaje)
        {
            enviarMensajeInhabilitar();
            //Basado en  capítulo 8 Microsoft 10272
            accesibilidadLoguin = false;
            Mouse.OverrideCursor = Cursors.Wait;
            isBusy = true;
            visibilidadProcesando = Visibility.Visible;
            BackgroundWorker worker = new BackgroundWorker();
            if (normativaPDFmensaje.idNormativaModeloPdfMensaje != -1)
            {
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                            {
                                //Cambia el elemento que se muestra
                                for (int i = 0; i < Lista.Count; i++)
                                {
                                    if (normativaPDFmensaje.idNormativaModeloPdfMensaje == Lista[i].id)
                                    {
                                        //Se carga una entidad completa no solo de titulo
                                        currentEntidad = NormativaModelo.Find(Lista[i].id);
                                        controlPdfListados = true;
                                        i = Lista.Count + 1;
                                    }
                                }
                                if (!(controlPdfListados))
                                {
                                    //No esta en el listado debe actualizarse o buscarse en la base directamente
                                    currentEntidad = NormativaModelo.Find(normativaPDFmensaje.idNormativaModeloPdfMensaje);
                                    Lista.Add(currentEntidad);//Actualizo la lista por el registro que no esta
                                }
                            };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                        {

                            binarioNormativa = currentEntidad.binarioNormativa;
                            if (binarioNormativa != null)
                            {
                                enviarBinario();
                                visibilidadPdf = Visibility.Visible;
                            }
                            else
                            {
                                mensaje();
                                    //await dlg.ShowMessageAsync(this, "No se pudo localizar el registro", "");
                                }
                            controlPdfListados = false;
                            visibilidadPdf = Visibility.Collapsed;
                            accesibilidadLoguin = true;
                            Mouse.OverrideCursor = null;
                            visibilidadProcesando = Visibility.Collapsed;
                            isBusy = false;
                            enviarMensajeHabilitar();
                            inicializacionTerminada();

                        };
                worker.RunWorkerAsync();
                worker.Dispose();
            }
            else
            {
                enviarMensajeHabilitar();
                currentEntidad = NormativaModelo.Clear(currentEntidad);// No se ha seleccionado ninguna norma en particular
                visibilidadPdf = Visibility.Collapsed;
                accesibilidadLoguin = true;
                Mouse.OverrideCursor = null;
                visibilidadProcesando = Visibility.Collapsed;
                isBusy = false;
            }
        }

        #endregion


        private async void mensaje()
        {
            await dlg.ShowMessageAsync(this, "No se pudo localizar el registro", "");
        }

        private void ControlCurrentPageMensaje(CurrentPageMensaje currentPageMensaje)
        {
            paginaDestino = currentPageMensaje.currentPage;
        }

        private void ControlTotalPagesMessages(TotalPagesMessages totalPagesMessages)
        {
            totalPaginas = totalPagesMessages.totalPages;
        }


        private async void enviarBinario()
        {
            if (!(string.IsNullOrEmpty(binarioNormativa.ToString())))
            {
                ArchivoBinario elemento = new ArchivoBinario();
                elemento.archivoBinario = binarioNormativa;
                Messenger.Default.Send(elemento, tokenNormaLegalBinarioEnvio);
            }
            else
            {
                await dlg.ShowMessageAsync(this, "No se envia el binario por ser vacio ", "");
            }
        }
        private void enviarBinarioNulo()
        {
            //Se envia para limpiar el contenido del PDF mostrado
            ArchivoBinario elemento = new ArchivoBinario();
            elemento.archivoBinario = null;
            Messenger.Default.Send(elemento, tokenNormaLegalBinarioEnvio);
        }
        #endregion

        #region Envio mensajes

        //Caso de nuevo registro 
        public void enviarElemento(NormativaModelo currentEntidad)
        {
            //Se crea el mensaje
            CatalogoNormaLegalElementoMensaje elemento = new CatalogoNormaLegalElementoMensaje();
            currentEntidad.idln = idln;
            currentEntidad.idusuario = idUsuario;
            elemento.elementoMensaje = currentEntidad;
            elemento.listaNormativa = Lista;
            Messenger.Default.Send<CatalogoNormaLegalElementoMensaje>(elemento);
        }
        public void enviarElemento()
        {
            //Se crea el mensaje
            CatalogoNormaLegalElementoMensaje elemento = new CatalogoNormaLegalElementoMensaje();
            currentEntidad.idln = idln;
            currentEntidad.idusuario = idUsuario;
            elemento.elementoMensaje = currentEntidad;
            elemento.listaNormativa = Lista;
            Messenger.Default.Send<CatalogoNormaLegalElementoMensaje>(elemento);
        }

        public void enviarCmdElemento(int cmd)
        {
            //Se crea el mensaje de comando
            HerramientaCmdCrudMensaje elemento = new HerramientaCmdCrudMensaje();
            elemento.cmd = cmd;
            elemento.usuarioModelo = currentUsuario;
            elemento.listaNormativaModelo = Lista;
            Messenger.Default.Send(elemento);
        }



        #endregion

        #region Receptor de mensajes
        private void ControlVentanaMensaje(VentanaViewMensaje controlVentanaCrearMensaje)
        {
            //Para controlar la ventana abierta
            //TypeName = null;
            NormaMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (!(currentEntidadNorma == null))
                    {
                        if (!((NormativaModelo.ContarRegistros(currentEntidadNorma.id) == 0)))
                        {
                            Lista = new ObservableCollection<NormativaModelo>(NormativaModelo.GetAll(currentEntidadNorma.id));
                        }
                    }
                    //currentEntidad = null; No es nula porque se agrega a la lista pero no ha cambiado la ventana
                    break;
                case 2:
                    break;
                case 3:
                    //activarVentanaConsulta = true;
                    break;
                default:
                    break;
            }
            finComando();
            comando = 0;

        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            NormaMainModel.TypeName = "CatalogoNormaLegalCrearView";
            currentEntidadNueva = new NormativaModelo();
            currentEntidadNueva.idln = idln;
            currentEntidadNueva.ordennormativa = NormativaModelo.ContarRegistros() + 1;
            enviarElemento(currentEntidadNueva);
            //enviarLista(); No necesita la lista porque al regresar se actualiza a ventana
            enviarCmdElemento(1);
            comando = 1;
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                NormaMainModel.TypeName = "CatalogoNormaLegalEditarView";
                enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                comando = 2;
                enviarCmdElemento(2);
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
                iniciarComando();
                NormaMainModel.TypeName = "CatalogoNormaLegalConsultarView";
                enviarElemento();
                comando = 3;
                enviarCmdElemento(3);
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
                iniciarComando();
                NormaMainModel.TypeName = "CatalogoNormaLegalIndiceConsultarView";
                enviarElemento();
                comando = 3;
                enviarCmdElemento(3);
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
                iniciarComando();
                enviarMensajeInhabilitar();
                //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                //if (NormativaModelo.DeleteBorradoLogico(currentEntidad.id, true))
                if (NormativaModelo.Delete(currentEntidad.id, true))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Se borro el registro", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    Lista.Remove(currentEntidad);
                    currentEntidad = NormativaModelo.Clear(currentEntidad);
                    visibilidadPdf = Visibility.Collapsed;
                    enviarNormaLegalCrearActualizarMensaje();
                    enviarBinarioNulo();
                    finComando();
                    enviarMensajeHabilitar();
                }
                else
                {
                    finComando();
                    await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    enviarMensajeHabilitar();
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
            return !(currentEntidad.id == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<NormativaModelo> listaEntidad)
        {
            Lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        public bool CanCommand()
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


        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            VerVistaCommand = new RelayCommand(VerVistaContextual);
            cambiarVistaPageCommand = new RelayCommand(cambiarVistaPage, CanCommand);
            ExportarPdfCommand = new RelayCommand(ExportarPdf, CanCommand);
            cambiarContinuaPageCommand = new RelayCommand(cambiarContinuaPage, CanCommand);
            rotarIzquierdaCommand = new RelayCommand(rotarIzquierda, CanCommand);
            rotarDerechaCommand = new RelayCommand(rotarDerecha, CanCommand);
            zoomInCommand = new RelayCommand(zoomIn, CanCommand);
            zoomOutCommand = new RelayCommand(zoomOut, CanCommand);
            //Tratamiento de navegacion
            paginaInicialCommand = new RelayCommand(paginaInicial, CanCommand);
            paginaPreviaCommand = new RelayCommand(paginaPrevia, CanCommand);
            paginaSiguienteCommand = new RelayCommand(paginaSiguiente, CanCommand);
            paginaUltimaCommand = new RelayCommand(paginaUltima, CanCommand);
            paginaEscogerCommand = new RelayCommand(paginaEscoger, CanCommand);
            genericoCommand = new RelayCommand(generico, CanCommand);

            SelectionChangedCommand = new RelayCommand<NormativaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void ExportarPdf()
        {
            bool resultado = false;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //fileName = Path.g.GetTempPath() + currentEntidad.nombrearchivonormativa;
                if (!string.IsNullOrEmpty(mydocpath))
                {
                    //https://msdn.microsoft.com/es-es/library/6ka1wd3w(v=vs.110).aspx
                    fileName = mydocpath + @"\" + currentEntidad.nombrearchivonormativa;
                }
                else
                {
                    //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
                    fileName = Path.GetTempPath() + currentEntidad.nombrearchivonormativa;
                }
                try
                {
                    File.WriteAllBytes(fileName, currentEntidad.binarioNormativa);
                    //listaArchivosCreados.Add(fileName);
                    //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                    Process.Start(fileName);
                    //this.CloseWindow();
                    resultado = true;
                }
                catch (Exception g)
                {
                    mensajeFalloPdf(g);
                    //dlg.ShowMessageAsync(this, "No tiene una aplicación instalada que maneje el archivo " + k.Message, "");
                    resultado = false;
                }
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                                {
                                    if (!(resultado))
                                    { 
                                       // mensajeFalloPdf(e);
                                    }
                                };
            worker.RunWorkerAsync();
            worker.Dispose();
        }

        private async void mensajeFalloPdf(RunWorkerCompletedEventArgs e)
        {
            await dlg.ShowMessageAsync(this, "No se pudo exportar el archivo " + e.ToString(), "");
        }

        private async void mensajeFalloPdf(Exception e)
        {
            await dlg.ShowMessageAsync(this, "No se pudo exportar el archivo porque hay otro archivo con el mismo nombre estando abierto"+ e.Message, "");
        }


        private void generico()
        {
            //Nada solo para bloquear
        }

        private async void paginaEscoger()
        {
            if (!(paginaDestino == 0)|| paginaDestino <= 0)
            {
                if (paginaDestino <= totalPaginas)
                {
                    goToPaginaMensaje(paginaDestino);
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El número de página debe ser menor al total", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe ingresar el número de página y mayor que cero", "");
            }
        }

        private bool CanEscoger()
        {
            return (!(paginaDestino == 0) && paginaDestino <= totalPaginas && paginaDestino > 0);
        }

        private void paginaInicial()
        {
            goToPaginaMensaje(1);
        }
        private void paginaPrevia()
        {
            goToPaginaMensaje(2);
        }
        private void paginaSiguiente()
        {
            goToPaginaMensaje(3);
        }
        private void paginaUltima()
        {
            goToPaginaMensaje(4);
        }

        private void cambiarVistaPage()
        {
            if (viewTypePdf == "SinglePage")
            {
                viewTypePdf = "BookView";
            }
            else
            {
                if (viewTypePdf == "BookView")
                {
                    viewTypePdf = "Facing";
                }
                else
                {
                    viewTypePdf = "SinglePage";
                }
            }
            tipoVistaMensaje(viewTypePdf);
        }

        private void tipoVistaMensaje(string seleccion)
        {
            {
                //Se crea el mensaje
                ViewTypeMessages elemento = new ViewTypeMessages();
                elemento.viewType = seleccion;
                Messenger.Default.Send(elemento);
            }
        }

        private void goToPaginaMensaje(int seleccion)
        {
            {
                //Se crea el mensaje
                PaginasPdfMensaje elemento = new PaginasPdfMensaje();
                elemento.Opcion = seleccion;
                Messenger.Default.Send(elemento);
            }
        }

        private void rotarDerecha()
        {
            {
                //Se crea el mensaje
                RotarDerechaMensaje elemento = new RotarDerechaMensaje();
                elemento.rotarDerecha = true;
                Messenger.Default.Send(elemento);
            }
        }

        private void zoomIn()
        {
            ZoomInMensaje elemento = new ZoomInMensaje();
            elemento.zoomIn = true;
            Messenger.Default.Send(elemento);
        }

        private void zoomOut()
        {
            ZoomOutMensaje elemento = new ZoomOutMensaje();
            elemento.zoomOut = true;
            Messenger.Default.Send(elemento);
        }

        private void rotarIzquierda()
        {
            {
                //Se crea el mensaje
                RotarIzquierdaMensaje elemento = new RotarIzquierdaMensaje();
                elemento.rotarIzquierda = true;
                Messenger.Default.Send(elemento);
            }
        }


        private void cambiarContinuaPage()
        {
            if (viewPaginaPdf == "ContinuousPageRows")
            {
                viewPaginaPdf = "SinglePageRow";
            }
            else
            {
                viewPaginaPdf = "ContinuousPageRows";
            }
            cambiarPresentacionPagina(viewPaginaPdf);
        }

        
        private void cambiarPresentacionPagina(string pageRowDisplay)
        {
            {
                //Se crea el mensaje
                PageRowDisplayMessages elemento = new PageRowDisplayMessages();
                elemento.PageRowDisplay = pageRowDisplay;
                Messenger.Default.Send(elemento);
            }
        }
        private void VerVistaContextual()
        {
            visibilidadVistaPdf = true;
        }

        public void enviarNormaLegalCrearActualizarMensaje()
        {
            //Creando el mensaje de cierre
            NormaLegalCrearActualizarMensaje actualizar = new NormaLegalCrearActualizarMensaje();
            actualizar.actualizar = true;
            Messenger.Default.Send<NormaLegalCrearActualizarMensaje>(actualizar);

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

        #region Gestion de comandos

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        #endregion Fin de comando
    }
}