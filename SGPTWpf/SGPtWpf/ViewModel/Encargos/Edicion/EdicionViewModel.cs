using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using CapaDatos;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Messages.Encargos;
using System;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Encargos
{
    public sealed class EdicionViewModel : ViewModeloBase
    {
        #region Propiedades privadas
        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion

        private int comando = 0;
        private DialogCoordinator dlg;

        #region ViewModel Properties : tokenRecepcionEncargos

        private string _tokenRecepcionEncargos;
        private string tokenRecepcionEncargos
        {
            get { return _tokenRecepcionEncargos; }
            set { _tokenRecepcionEncargos = value; }
        }
        #endregion

        #region ViewModel Properties : tokenRecepcionCrudEncargos

        private string _tokenRecepcionCrudEncargos;
        private string tokenRecepcionCrudEncargos
        {
            get { return _tokenRecepcionCrudEncargos; }
            set { _tokenRecepcionCrudEncargos = value; }
        }

        #endregion

        #region ViewModel Properties : tokenEnvioEdicion

        private string _tokenEnvioEdicion;
        private string tokenEnvioEdicion
        {
            get { return _tokenEnvioEdicion; }
            set { _tokenEnvioEdicion = value; }
        }
        #endregion

        #endregion

        #region ViewModel Properties publicas

        #region lista entidades de elementos contables

        public const string listaElementosPropertyName = "listaElementos";

        private ObservableCollection<ElementoModelo> _listaElementos;

        public ObservableCollection<ElementoModelo> listaElementos
        {
            get
            {
                return _listaElementos;
            }

            set
            {
                if (_listaElementos == value) return;

                _listaElementos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaElementosPropertyName);
            }
        }

        #endregion

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


        #region lista de encargos

        public const string listaEncargosPropertyName = "listaEncargos";

        private ObservableCollection<EncargoModelo> _listaEncargos;

        public ObservableCollection<EncargoModelo> listaEncargos
        {
            get
            {
                return _listaEncargos;
            }

            set
            {
                if (_listaEncargos == value) return;

                _listaEncargos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaEncargosPropertyName);
            }
        }

        #endregion

        #region lista de listaAsignaciones

        public const string listaAsignacionesPropertyName = "listaAsignaciones";

        private ObservableCollection<AsignacionModelo> _listaAsignaciones;

        public ObservableCollection<AsignacionModelo> listaAsignaciones
        {
            get
            {
                return _listaAsignaciones;
            }

            set
            {
                if (_listaAsignaciones == value) return;

                _listaAsignaciones = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaAsignacionesPropertyName);
            }
        }

        #endregion

        #region Propiedades de  entidad

        #region  Primary key idencargo

        public const string idencargoPropertyName = "idencargo";

        private int _idencargo = 0;

        public int idencargo
        {
            get
            {
                return _idencargo;
            }

            set
            {
                if (_idencargo == value)
                {
                    return;
                }

                _idencargo = value;
                RaisePropertyChanged(idencargoPropertyName);
            }
        }

        #endregion

        #region  Primary key Cliente idnitcliente

        public const string idnitclientePropertyName = "idnitcliente";

        private string _idnitcliente = string.Empty;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string idnitcliente
        {
            get
            {
                return _idnitcliente;
            }

            set
            {
                if (_idnitcliente == value)
                {
                    return;
                }

                _idnitcliente = value;
                RaisePropertyChanged(idnitclientePropertyName);
            }
        }

        #endregion

        #region  Primary key tipo de auditoria idta

        public const string idtaPropertyName = "idta";

        private int _idta = 0;

        public int idta
        {
            get
            {
                return _idta;
            }

            set
            {
                if (_idta == value)
                {
                    return;
                }

                _idta = value;
                RaisePropertyChanged(idtaPropertyName);
            }
        }

        #endregion

        #region primary Key Idsc

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

        #region idindice

        public const string idindicePropertyName = "idindice";

        private int _idindice = 0;

        public int idindice
        {
            get
            {
                return _idindice;
            }

            set
            {
                if (_idindice == value)
                {
                    return;
                }

                _idindice = value;
                RaisePropertyChanged(idindicePropertyName);
            }
        }

        #endregion

        #region fechacreadoencargo

        public const string fechacreadoencargoPropertyName = "fechacreadoencargo";

        private string _fechacreadoencargo = string.Empty;

        public string fechacreadoencargo
        {
            get
            {
                return _fechacreadoencargo;
            }

            set
            {
                if (_fechacreadoencargo == value)
                {
                    return;
                }

                _fechacreadoencargo = value;
                RaisePropertyChanged(fechacreadoencargoPropertyName);
            }
        }

        #endregion

        #region fecha de modificacion de plantilla

        public const string fechacreadoplantillaPropertyName = "fechacreadoplantilla";

        private string _fechacreadoplantilla = string.Empty;

        public string fechacreadoplantilla
        {
            get
            {
                return _fechacreadoplantilla;
            }

            set
            {
                if (_fechacreadoplantilla == value)
                {
                    return;
                }

                _fechacreadoplantilla = value;
                RaisePropertyChanged(fechacreadoplantillaPropertyName);
            }
        }

        #endregion

        #region tipoclienteencargo
        //Permite determinar si es un encargo recurrente (segunda o mas veces) que se hace el encargo del cliente.
        //True=El encargo es recurrente, False= Primera vez que se hace la auditoria. 
        //En el caso de las auditorias recurrentes permite utilizar archivos del encargo inmediato anterior.
        public const string tipoclienteencargoPropertyName = "tipoclienteencargo";

        private bool _tipoclienteencargo = false;

        public bool tipoclienteencargo
        {
            get
            {
                return _tipoclienteencargo;
            }

            set
            {
                if (_tipoclienteencargo == value)
                {
                    return;
                }

                _tipoclienteencargo = value;
                RaisePropertyChanged(tipoclienteencargoPropertyName);
            }
        }

        #endregion

        #region etapaencargo
        //Permite gestionar las diferentes etapas de los archivos que componen las auditorias. 
        //Se distinguen las siguientes etapas; I=inicial, P=En proceso, R=Revisado, C=Cerrado. 
        //Un encargo con estado = "Cerrado" no se debe modificar ningun elemento asociado a el.

        public const string etapaencargoPropertyName = "etapaencargo";

        private byte[] _etapaencargo = null;

        public byte[] etapaencargo
        {
            get
            {
                return _etapaencargo;
            }

            set
            {
                if (_etapaencargo == value)
                {
                    return;
                }

                _etapaencargo = value;
                RaisePropertyChanged(etapaencargoPropertyName);
            }
        }

        #endregion

        #region costoejecucionencargo

        public const string costoejecucionencargoPropertyName = "costoejecucionencargo";

        private decimal _costoejecucionencargo = 0;

        public decimal costoejecucionencargo
        {
            get
            {
                return _costoejecucionencargo;
            }

            set
            {
                if (_costoejecucionencargo == value)
                {
                    return;
                }

                _costoejecucionencargo = value;
                RaisePropertyChanged(costoejecucionencargoPropertyName);
            }
        }

        #endregion

        #region honorariosencargo

        public const string honorariosencargoPropertyName = "honorariosencargo";

        private decimal _honorariosencargo = 0;

        public decimal honorariosencargo
        {
            get
            {
                return _honorariosencargo;
            }

            set
            {
                if (_honorariosencargo == value)
                {
                    return;
                }

                _honorariosencargo = value;
                RaisePropertyChanged(honorariosencargoPropertyName);
            }
        }

        #endregion

        #region fechainiperauditencargo

        public const string fechainiperauditencargoPropertyName = "fechainiperauditencargo";

        private string _fechainiperauditencargo = string.Empty;

        public string fechainiperauditencargo
        {
            get
            {
                return _fechainiperauditencargo;
            }

            set
            {
                if (_fechainiperauditencargo == value)
                {
                    return;
                }

                _fechainiperauditencargo = value;
                RaisePropertyChanged(fechainiperauditencargoPropertyName);
            }
        }


        #endregion

        #region fechafinperauditencargo

        public const string fechafinperauditencargoPropertyName = "fechafinperauditencargo";

        private string _fechafinperauditencargo = string.Empty;

        public string fechafinperauditencargo
        {
            get
            {
                return _fechafinperauditencargo;
            }

            set
            {
                if (_fechafinperauditencargo == value)
                {
                    return;
                }

                _fechafinperauditencargo = value;
                RaisePropertyChanged(fechafinperauditencargoPropertyName);
            }
        }


        #endregion

        #region estadoencargo

        public const string estadoencargoPropertyName = "estadoencargo";

        private string _estadoencargo = string.Empty;

        public string estadoencargo
        {
            get
            {
                return _estadoencargo;
            }

            set
            {
                if (_estadoencargo == value)
                {
                    return;
                }

                _estadoencargo = value;
                RaisePropertyChanged(estadoencargoPropertyName);
            }
        }
        #endregion


        #endregion

        #region Propiedes de presentacion agregadas

        #region razonsocialcliente

        public const string razonsocialclientePropertyName = "razonsocialcliente";

        private string _razonsocialcliente = string.Empty;

        public string razonsocialcliente
        {
            get
            {
                return _razonsocialcliente;
            }

            set
            {
                if (_razonsocialcliente == value)
                {
                    return;
                }

                _razonsocialcliente = value;
                RaisePropertyChanged(razonsocialclientePropertyName);
            }
        }

        #endregion

        #region descripcionEtapaEncargo

        public const string descripcionEtapaEncargoPropertyName = "descripcionEtapaEncargo";

        private string _descripcionEtapaEncargo = string.Empty;

        public string descripcionEtapaEncargo
        {
            get
            {
                return _descripcionEtapaEncargo;
            }

            set
            {
                if (_descripcionEtapaEncargo == value)
                {
                    return;
                }

                _descripcionEtapaEncargo = value;
                RaisePropertyChanged(descripcionEtapaEncargoPropertyName);
            }
        }

        #endregion

        #region descripcionTipoClienteEncargo

        public const string descripcionTipoClienteEncargoPropertyName = "descripcionTipoClienteEncargo";

        private string _descripcionTipoClienteEncargo = string.Empty;

        public string descripcionTipoClienteEncargo
        {
            get
            {
                return _descripcionTipoClienteEncargo;
            }

            set
            {
                if (_descripcionTipoClienteEncargo == value)
                {
                    return;
                }

                _descripcionTipoClienteEncargo = value;
                RaisePropertyChanged(descripcionTipoClienteEncargoPropertyName);
            }
        }


        #endregion

        #region descripcionTipoAuditoria

        public const string descripcionTipoAuditoriaPropertyName = "descripcionTipoAuditoria";

        private string _descripcionTipoAuditoria = string.Empty;

        public string descripcionTipoAuditoria
        {
            get
            {
                return _descripcionTipoAuditoria;
            }

            set
            {
                if (_descripcionTipoAuditoria == value)
                {
                    return;
                }

                _descripcionTipoAuditoria = value;
                RaisePropertyChanged(descripcionTipoAuditoriaPropertyName);
            }
        }


        #endregion

        #endregion

        #region Entidades en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private EncargoModelo _currentEntidad;

        public EncargoModelo currentEntidad
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

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        private usuario _currentUsuario;

        public usuario currentUsuario
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

        #region ViewModel Property : currentUsuarioModelo usuario

        public const string currentUsuarioModeloPropertyName = "currentUsuarioModelo";

        private UsuarioModelo _currentUsuarioModelo;

        public UsuarioModelo currentUsuarioModelo
        {
            get
            {
                return _currentUsuarioModelo;
            }

            set
            {
                if (_currentUsuarioModelo == value) return;

                _currentUsuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentUsuarioModeloPropertyName);
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

        #region ViewModel Property : currentIndiceModelo

        public const string currentIndiceModeloPropertyName = "currentIndiceModelo";

        private IndiceModelo _currentIndiceModelo;

        public IndiceModelo currentIndiceModelo
        {
            get
            {
                return _currentIndiceModelo;
            }

            set
            {
                if (_currentIndiceModelo == value) return;

                _currentIndiceModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentIndiceModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : indiceModelo

        public const string indiceModeloPropertyName = "indiceModelo";

        private IndiceModelo _indiceModelo;

        public IndiceModelo indiceModelo
        {
            get
            {
                return _indiceModelo;
            }

            set
            {
                if (_indiceModelo == value) return;

                _indiceModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(indiceModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : tipoAuditoriaModelo

        public const string tipoAuditoriaModeloPropertyName = "tipoAuditoriaModelo";

        private TipoAuditoriaModelo _tipoAuditoriaModelo;

        public TipoAuditoriaModelo tipoAuditoriaModelo
        {
            get
            {
                return _tipoAuditoriaModelo;
            }

            set
            {
                if (_tipoAuditoriaModelo == value) return;

                _tipoAuditoriaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(tipoAuditoriaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : etapaEncargoModelo

        public const string etapaEncargoModeloPropertyName = "etapaEncargoModelo";

        private EtapaEncargoModelo _etapaEncargoModelo;

        public EtapaEncargoModelo etapaEncargoModelo
        {
            get
            {
                return _etapaEncargoModelo;
            }

            set
            {
                if (_etapaEncargoModelo == value) return;

                _etapaEncargoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(etapaEncargoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : tipoClienteEncargoModelo

        public const string tipoClienteEncargoModeloPropertyName = "tipoClienteEncargoModelo";

        private TipoClienteEncargoModelo _tipoClienteEncargoModelo;

        public TipoClienteEncargoModelo tipoClienteEncargoModelo
        {
            get
            {
                return _tipoClienteEncargoModelo;
            }

            set
            {
                if (_tipoClienteEncargoModelo == value) return;

                _tipoClienteEncargoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(tipoClienteEncargoModeloPropertyName);
            }
        }

        #endregion

        #endregion


        #endregion


        #region Propiedades Ventana


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

        #region ViewModel Properties : accesibilidadCuerpo

        public const string accesibilidadCuerpoPropertyName = "accesibilidadCuerpo";

        private bool _accesibilidadCuerpo = true;

        public bool accesibilidadCuerpo
        {
            get
            {
                return _accesibilidadCuerpo;
            }

            set
            {
                if (_accesibilidadCuerpo == value)
                {
                    return;
                }

                _accesibilidadCuerpo = value;
                RaisePropertyChanged(accesibilidadCuerpoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : activarCarga

        public const string activarCargaPropertyName = "activarCarga";

        private bool _activarCarga = true;

        public bool activarCarga
        {
            get
            {
                return _activarCarga;
            }

            set
            {
                if (_activarCarga == value)
                {
                    return;
                }

                _activarCarga = value;
                RaisePropertyChanged(activarCargaPropertyName);
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

        #region visibilidadConsultar

        public const string visibilidadConsultarPropertyName = "visibilidadConsultar";

        private Visibility _visibilidadConsultar = Visibility.Collapsed;

        public Visibility visibilidadConsultar
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

        private Visibility _visibilidadEditar = Visibility.Collapsed;

        public Visibility visibilidadEditar
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

        #endregion

        #region EncargosCrudMainModel

        private MainModel _mainModel = null;

        public MainModel EncargosCrudMainModel
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

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand PermisosCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand<EncargoModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public EdicionViewModel()
        {
            _opcionSeleccionada = 0;
            _tokenRecepcionEncargos = "Edición" + "MenuEncargos";
            _tokenEnvioEdicion = "CrudEdicionEncargos";//Para envio de  mensajes
            _tokenRecepcionCrudEncargos= "CierreCrudEncargoEdicion";//Para saber que se cerro Edicion
            //Suscribiendo el mensaje
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionEncargos, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            Messenger.Default.Register<bool>(this, tokenRecepcionCrudEncargos, (cierreCrudEdicionMensaje) => ControlCierreCrudEdicionMensaje(cierreCrudEdicionMensaje));

            //Temporalmente  todos pero deben filtrarse por id de usuario
            try
            {
                listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll());

                listaAsignaciones = new ObservableCollection<AsignacionModelo>();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "Problema de comunicacion en la recopilacion de listas " + e.Message, "");
                listaEncargos = new ObservableCollection<EncargoModelo>();

                listaAsignaciones = new ObservableCollection<AsignacionModelo>();
            }
            encabezadoPantalla = "";
            RegisterCommands();
            dlg = new DialogCoordinator();
            accesibilidadCuerpo = false;
            activarCarga = false;
            EncargosCrudMainModel = new MainModel();
        }

        private void ControlCierreCrudEdicionMensaje(bool cierreCrudEdicionMensaje)
        {
            if (cierreCrudEdicionMensaje)
            {
                //Para controlar la ventana abierta
                EncargosCrudMainModel.TypeName = null;
                switch (comando)
                {
                    case 1:
                        currentEntidad = null;
                        actualizarLista();
                        break;
                    case 2:
                        actualizarLista();
                        break;
                    case 3:
                        break;
                    case 5:
                        actualizarLista();
                        break;
                    default:
                        break;
                }
                comando = 0;
            }
        }

        private void actualizarLista()
        {
            //borrarTemporales();//Para borrar cualquier  archivo creado
            try
            {
                if (!(listaEncargos == null))
                {
                    listaEncargos.Clear();
                }
                if ((currentUsuario.idrol == 1 || currentUsuario.idrol == 2 || currentUsuario.idrol == 3) || (currentUsuarioModelo.basadoenrol == 1 || currentUsuarioModelo.basadoenrol == 2 || currentUsuarioModelo.basadoenrol == 3))
                {
                    //Se mostrara la lista completa
                    listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll());
                }
                else
                {
                    //Asignaciones  del usuario para buscar los encargos
                    listaAsignaciones = new ObservableCollection<AsignacionModelo>(AsignacionModelo.GetAllByIdUsuario(currentUsuario.idusuario));
                    //Se mostrará una lista filtrada por asignaciones del usuario
                    listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll(listaAsignaciones));
                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas de encargos " + e.Message, "");
                    listaEncargos = new ObservableCollection<EncargoModelo>();
                }
            }
        }


        private void ControlUsuarioMensaje(UsuarioMensaje usuarioMensaje)
        {
            currentUsuario = usuarioMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = usuarioMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionEncargos);//El usuario  no puede cambiar a menos que vuelva a ingresar
            //Filtrar la lista
            if ((currentUsuario.idrol == 1 || currentUsuario.idrol == 2 || currentUsuario.idrol == 3)|| (currentUsuarioModelo.basadoenrol == 1 || currentUsuarioModelo.basadoenrol == 2 || currentUsuarioModelo.basadoenrol == 3))
            {
                //Se mostrara la lista completa
                listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll());
            }
            else
            {
                //Asignaciones  del usuario para buscar los encargos
                listaAsignaciones = new ObservableCollection<AsignacionModelo>(AsignacionModelo.GetAllByIdUsuario(currentUsuario.idusuario));
                //Se mostrará una lista filtrada por asignaciones del usuario
                listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll(listaAsignaciones));
            }
            inicializacionTerminada();
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionEncargos);
        }


        #endregion



        #endregion

        #region Mensajes
        public void enviarEncargoMensaje()
        {
            encargosDatosCreacion mensaje = new encargosDatosCreacion();
            mensaje.listaElementos = listaElementos;
            mensaje.sistemaContable = currentSistemaContable;
            mensaje.encargoModelo = currentEntidad;
            mensaje.usuarioModelo = usuarioModelo;
            mensaje.comando = comando;
            Messenger.Default.Send(mensaje, tokenEnvioEdicion);
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            EncargosCrudMainModel.TypeName = "EncargosCrearView";
            //Lista de elementos  contables
            //listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());No se requiere
            listaElementos = null;
            currentSistemaContable = new SistemaContableModelo();
            currentEntidad = new EncargoModelo();
            comando = 1;
            enviarEncargoMensaje();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                if (currentEntidad.etapaencargo != "C")
                {
                    currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEntidad.idencargo);
                    listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll(currentSistemaContable.idsc));
                    EncargosCrudMainModel.TypeName = "EncargosEditarView";
                    comando = 2;
                    enviarEncargoMensaje();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No puede editarse encargos ya  cerrados, solo puede consultarlos", "");
                }
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
                currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEntidad.idencargo);
                listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll(currentSistemaContable.idsc));
                EncargosCrudMainModel.TypeName = "EncargosConsultarView";
                comando = 3;
                enviarEncargoMensaje();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                //activarVentanaConsulta = false;

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

                EncargosCrudMainModel.TypeName = "EncargosConsultarView";
                listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll((int)currentEntidad.idencargo));
                currentSistemaContable = SistemaContableModelo.Find((int)currentEntidad.idencargo);
                comando = 3;
                enviarEncargoMensaje();

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
                //Se realiza un borrado completo
                if (EncargoModelo.Delete(currentEntidad))
                {
                    await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                    actualizarLista();
                    currentEntidad = null;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                }

            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }

        public async void BorrarL()
        {
            if (!(currentEntidad == null))
            {
                //Se realiza un borrado completo
                if (EncargoModelo.DeleteBorradoLogico(currentEntidad))
                {
                    await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                    actualizarLista();
                    currentEntidad = null;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                }

            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }
        #endregion

        #region Metodos de apoyo

        public bool CanDelete()
        {
            return currentEntidad != null;
        }
        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanEditar);
            BorrarCommand = new RelayCommand(Borrar, CanBorrar);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            SelectionChangedCommand = new RelayCommand<EncargoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }


        #endregion

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


        #region Verifica unicidad
        //Cada marca debe ser única
        #endregion


    }
}

