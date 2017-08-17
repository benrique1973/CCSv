using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using CapaDatos;
using System.Linq;
using SGPTWpf.Messages.Genericos;
using System.Data;
using System;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;

namespace SGPTWpf.ViewModel.Encargos
{
    public sealed class EncargosControllerViewModel: ViewModeloBase
    {
        #region Propiedades privadas

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
        }

        private string _tokenRecepcionEncargos;
        private string tokenRecepcionEncargos
        {
            get { return _tokenRecepcionEncargos; }
            set { _tokenRecepcionEncargos = value; }
        }

        private DialogCoordinator dlg;
        private bool _salida;
        private bool salida
        {
            get { return _salida; }
            set { _salida = value; }
        }

        #endregion

        #region ViewModel Properties publicas


        #region lista entidades

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

        #region Propiedades de  entidad

        #region  Primary key idencargo

        public const string idencargoPropertyName = "idencargo";

        private int _idencargo;

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

        private string _idnitcliente;

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

        private int _idta;

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

        private int _idsc;

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

        private int _idindice;

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

        private string _fechacreadoencargo;

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

        private string _fechacreadoplantilla;

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

        private bool _tipoclienteencargo;

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

        private byte[] _etapaencargo;

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

        private decimal _costoejecucionencargo;

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

        private decimal _honorariosencargo;

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

        private string _fechainiperauditencargo;

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

        private string _fechafinperauditencargo;

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

        private string _estadoencargo;

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

        private string _razonsocialcliente;
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

        private string _descripcionEtapaEncargo ;

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

        private string _descripcionTipoClienteEncargo;

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

        private string _descripcionTipoAuditoria;

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

        #region ViewModel Properties : accesibilidadCuerpo

        public const string accesibilidadCuerpoPropertyName = "accesibilidadCuerpo";

        private bool _accesibilidadCuerpo;

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

        private bool _activarCarga ;

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

        private Visibility _visibilidadCrear;

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

        private Visibility _visibilidadConsultar;

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

        private Visibility _visibilidadEditar;

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

        private Visibility _visibilidadCopiar;

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

        private string _encabezadoPantalla;

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

        #region ViewModel Commands

        
        public RelayCommand SeleccionarCommand { get; set; }
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<EncargoModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public EncargosControllerViewModel()
        {
            _tokenEnvioCierre = "ClienteSeleccionado";
            _tokenRecepcionEncargos = "Encargos";
            _salida = false;
            _idencargo = 0;
            _idnitcliente = string.Empty;
            _idta = 0;
            _idsc = 0;
            _estadoencargo = string.Empty;
            _razonsocialcliente = string.Empty;
            _descripcionEtapaEncargo = string.Empty;
            _descripcionTipoClienteEncargo = string.Empty;
            _descripcionTipoAuditoria = string.Empty;
            _accesibilidadWindow = true;
            _accesibilidadCuerpo = true;
            _activarCarga = true;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _encabezadoPantalla = string.Empty;
            //Suscribiendo el mensaje
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionEncargos, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            //Temporalmente  todos pero deben filtrarse por id de usuario
             encabezadoPantalla = "";
            RegisterCommands();
            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            try
            {
                listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll());
            }
            catch (Exception)
            {
                listaEncargos = new ObservableCollection<EncargoModelo>();
            }
            salida = false;
            accesibilidadCuerpo = false;
            activarCarga = false;
        }
        public EncargosControllerViewModel(string origen)
        {
            _tokenEnvioCierre = origen  +"ClienteSeleccionado";
            switch (origen)
            {
                case "PrincipalDocumentacion": //Llamada desde documentacion
                    _tokenRecepcionEncargos = "Documentacion";
                    _tokenEnvioCierre = "Documentos" + "ClienteSeleccionado";
                    break;
                case "Encargos":
                    _tokenRecepcionEncargos = "Encargos"; 
                    break;
                case "Edición":
                    _tokenRecepcionEncargos = "Encargos"; 
                    break;
                case "Planificación":
                    _tokenRecepcionEncargos = "Encargos";
                    break;
                case "Documentacion":
                    _tokenRecepcionEncargos = "Encargos";
                    break;
                case "Supervision":
                    _tokenRecepcionEncargos = "Encargos";
                    break;
                case "Cierre":
                    _tokenRecepcionEncargos = "Encargos";
                    break;
                case "Cédulas":
                    _tokenRecepcionEncargos = "Encargos";
                    break;
            }

            _salida = false;
            _idencargo = 0;
            _idnitcliente = string.Empty;
            _idta = 0;
            _idsc = 0;
            _estadoencargo = string.Empty;
            _razonsocialcliente = string.Empty;
            _descripcionEtapaEncargo = string.Empty;
            _descripcionTipoClienteEncargo = string.Empty;
            _descripcionTipoAuditoria = string.Empty;
            _accesibilidadWindow = true;
            _accesibilidadCuerpo = true;
            _activarCarga = true;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _encabezadoPantalla = string.Empty;
            //Suscribiendo el mensaje
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionEncargos, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            //Temporalmente  todos pero deben filtrarse por id de usuario
            encabezadoPantalla = "";
            RegisterCommands();
            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            try
            {
                listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll());
            }
            catch (Exception)
            {
                listaEncargos = new ObservableCollection<EncargoModelo>();
            }
            salida = false;
            accesibilidadCuerpo = false;
            activarCarga = false;
        }

        private void ControlUsuarioMensaje(UsuarioMensaje usuarioMensaje)
        {
            currentUsuario = usuarioMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = usuarioMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionEncargos);//El usuario  no puede cambiar a menos que vuelva a ingresar

        }

        private void inicializacion()
        {
            currentEntidad = null;
                encabezadoPantalla = "Ingrese los datos del cliente";
                accesibilidadWindow = true;
                visibilidadCrear = Visibility.Visible;
                visibilidadEditar = Visibility.Collapsed;
                visibilidadConsultar = Visibility.Collapsed;
                visibilidadCopiar = Visibility.Collapsed;
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            currentEntidad = null;
            salida = true;
            enviarMensajeEncargo();
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            CloseWindow();
        }

        private void Ok()
        {
            salida = true;
            CloseWindow();
        }


        private void Salir()
        {
            if (!salida)
            {
                currentEntidad = null;
                salida = true;
                enviarMensajeEncargo();
                CloseWindow();
            }
            else
            {
                //Ya procesado
            }
            enviarMensajeHabilitar();
        }


        public void Guardar()
        {
            throw new NotImplementedException();
        }


        public void Copiar()
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }


        #endregion

        #region Mensajes

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

        #region Metodos de apoyo

        public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidad == null )
            {
                return evaluar;
            }
            else
            {
                evaluar = true;
                return evaluar;
            }
        }

        #endregion

        #endregion
        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            SeleccionarCommand = new RelayCommand(Seleccionar, CanSave);
            CopiarCommand = new RelayCommand(Copiar, CanSave);
            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<EncargoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void Seleccionar()
        {
            salida = true;
            enviarMensajeEncargo();
            CloseWindow();
        }

        public void enviarMensajeEncargo()
        {
            //Creando el mensaje de transmision del usuario
            EncargoMensaje elemento = new EncargoMensaje();
            if (currentEntidad != null && currentEntidad.idencargo != 0)
            {
                currentEntidad.sistemaContableModelo = SistemaContableModelo.GetRegistroByIdEncargo(currentEntidad.idencargo);
                currentEntidad.idsc = currentEntidad.sistemaContableModelo.idsc;
            }
            elemento.encargoModelo = currentEntidad;
            Messenger.Default.Send(elemento, tokenEnvioCierre);
        }

        #endregion

        #region Verifica unicidad
        //Cada marca debe ser única
        public int contenidoUnico(string elemento, ObservableCollection<EncargoModelo> listaBusqueda)
        {
            int numeroRegistros;
            string marcame = elemento.ToUpper();
            numeroRegistros = listaBusqueda.Where(j => j.razonsocialcliente.ToUpper() == marcame).Count();
            if (numeroRegistros == 1)
            {
                return 1;
            }
            else
            {
                return numeroRegistros;
            }
        }
        #endregion


    }
}

