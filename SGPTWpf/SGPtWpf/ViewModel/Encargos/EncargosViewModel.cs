using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Model;
using SGPTWpf.Model.Menus.Encargos;
using System.Collections.Generic;
using System;
using SGPTWpf.Model.Modelo.Encargos;
using System.Collections.ObjectModel;
using SGPTWpf.Messages.Encargos;
using System.Windows;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;

namespace SGPTWpf.ViewModel.Administracion
{
    public sealed class EncargosViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;
        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion

        #region Propiedades privadas

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


        #region tokenRecepcionPrincipal

        private string _tokenRecepcionPrincipal;
        private string tokenRecepcionPrincipal
        {
            get { return _tokenRecepcionPrincipal; }
            set { _tokenRecepcionPrincipal = value; }
        }

        #endregion

        #region tokenEnvio

        private string _tokenEnvio;
        private string tokenEnvio
        {
            get { return _tokenEnvio; }
            set { _tokenEnvio = value; }
        }

        #endregion

        #region tokenRecepcionSeleccionCliente

        private string _tokenRecepcionSeleccionCliente;
        private string tokenRecepcionSeleccionCliente
        {
            get { return _tokenRecepcionSeleccionCliente; }
            set { _tokenRecepcionSeleccionCliente = value; }
        }

        #endregion

        #region tokenEnvioCreacion

        private string _tokenEnvioCreacion;
        private string tokenEnvioCreacion
        {
            get { return _tokenEnvioCreacion; }
            set { _tokenEnvioCreacion = value; }
        }
        #endregion

        private int comando = 0;

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

        #region nombreEncargo

        public const string nombreEncargoPropertyName = "nombreEncargo";

        private string _nombreEncargo = string.Empty;

        public string nombreEncargo
        {
            get
            {
                return _nombreEncargo;
            }

            set
            {
                if (_nombreEncargo == value)
                {
                    return;
                }

                _nombreEncargo = value;
                RaisePropertyChanged(nombreEncargoPropertyName);
            }
        }


        #endregion

        #region MainModel

        private MainModel _EncargosMainModel = null;

        public MainModel EncargosMainModel
        {
            get
            {
                return _EncargosMainModel;
            }

            set
            {
                _EncargosMainModel = value;
            }
        }
        #endregion

        #endregion

        #region ViewModel Properties publicas

        #region Seleccion

        public const string SeleccionPropertyName = "Seleccion";

        private string _Seleccion = string.Empty;

        public string Seleccion
        {
            get
            {
                return _Seleccion;
            }

            set
            {
                if (_Seleccion == value)
                {
                    return;
                }

                _Seleccion = value;
                RaisePropertyChanged(SeleccionPropertyName);
            }
        }

        #endregion

        #region EstiloPlanificacion

        public const string EstiloPlanificacionPropertyName = "EstiloPlanificacion";

        private string _EstiloPlanificacion = string.Empty;

        public string EstiloPlanificacion
        {
            get
            {
                return _EstiloPlanificacion;
            }

            set
            {
                if (_EstiloPlanificacion == value)
                {
                    return;
                }
                _EstiloPlanificacion = value;
                RaisePropertyChanged(EstiloPlanificacionPropertyName);
            }
        }

        #endregion

        #region EstiloDocumentacion

        public const string EstiloDocumentacionPropertyName = "EstiloDocumentacion";

        private string _EstiloDocumentacion = string.Empty;

        public string EstiloDocumentacion
        {
            get
            {
                return _EstiloDocumentacion;
            }

            set
            {
                if (_EstiloDocumentacion == value)
                {
                    return;
                }
                _EstiloDocumentacion = value;
                RaisePropertyChanged(EstiloDocumentacionPropertyName);
            }
        }

        #endregion

        #region EstiloCedulas

        public const string EstiloCedulasPropertyName = "EstiloCedulas";

        private string _EstiloCedulas = string.Empty;

        public string EstiloCedulas
        {
            get
            {
                return _EstiloCedulas;
            }

            set
            {
                if (_EstiloCedulas == value)
                {
                    return;
                }
                _EstiloCedulas = value;
                RaisePropertyChanged(EstiloCedulasPropertyName);
            }
        }

        #endregion

        #region EstiloSupervision

        public const string EstiloSupervisionPropertyName = "EstiloSupervision";

        private string _EstiloSupervision = string.Empty;

        public string EstiloSupervision
        {
            get
            {
                return _EstiloSupervision;
            }

            set
            {
                if (_EstiloSupervision == value)
                {
                    return;
                }
                _EstiloSupervision = value;
                RaisePropertyChanged(EstiloSupervisionPropertyName);
            }
        }

        #endregion

        #region EstiloCierre

        public const string EstiloCierrePropertyName = "EstiloCierre";

        private string _EstiloCierre = string.Empty;

        public string EstiloCierre
        {
            get
            {
                return _EstiloCierre;
            }

            set
            {
                if (_EstiloCierre == value)
                {
                    return;
                }
                _EstiloCierre = value;
                RaisePropertyChanged(EstiloCierrePropertyName);
            }
        }

        #endregion

        #region EstiloEdicion

        public const string EstiloEdicionPropertyName = "EstiloEdicion";

        private string _EstiloEdicion = string.Empty;

        public string EstiloEdicion
        {
            get
            {
                return _EstiloEdicion;
            }

            set
            {
                if (_EstiloEdicion == value)
                {
                    return;
                }
                _EstiloEdicion = value;
                RaisePropertyChanged(EstiloEdicionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadEncargos

        public const string accesibilidadEncargosPropertyName = "accesibilidadEncargos";

        private bool _accesibilidadEncargos = true;

        public bool accesibilidadEncargos
        {
            get
            {
                return _accesibilidadEncargos;
            }

            set
            {
                if (_accesibilidadEncargos == value)
                {
                    return;
                }

                _accesibilidadEncargos = value;
                RaisePropertyChanged(accesibilidadEncargosPropertyName);
            }
        }

        #endregion

        #region visibilidadCliente

        public const string visibilidadClientePropertyName = "visibilidadCliente";

        private Visibility _visibilidadCliente = Visibility.Collapsed;

        public Visibility visibilidadCliente
        {
            get
            {
                return _visibilidadCliente;
            }

            set
            {
                if (_visibilidadCliente == value)
                {
                    return;
                }

                _visibilidadCliente = value;
                RaisePropertyChanged(visibilidadClientePropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand EdicionCommand { get; set; }
        public RelayCommand PlanificacionCommand { get; set; }
        public RelayCommand DocumentacionCommand { get; set; }
        public RelayCommand CedulasCommand { get; set; }
        public RelayCommand SupervisionCommand { get; set; }
        public RelayCommand CierreCommand { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }
        public RelayCommand DobleClickCommand { get; set; }

        #endregion


        #region ViewModel Public Methods

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuEncargos _currentEntidad;

        public MenuEncargos currentEntidad
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

        #region Opciones
        public const string ListaPrincipalPropertyName = "ListaPrincipal";

        private List<MenuEncargos> _ListaPrincipal;
        public List<MenuEncargos> ListaPrincipal
        {
            get
            {
                return _ListaPrincipal;
            }

            set
            {
                if (_ListaPrincipal == value) return;

                _ListaPrincipal = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPrincipalPropertyName);
            }
        }

        #endregion


        #region Constructores

        public EncargosViewModel()
        {
            _tokenRecepcionSeleccionCliente = string.Empty;
            //_tokenRecepcionSeleccionCliente ="Encargos"+ "ClienteSeleccionado";//Recepcion de  EncargosControllerViewModel
            _tokenRecepcionPrincipal = "Encargos";//Para recepcion de menu principal
            _tokenEnvio = "EncargosDatos";//Envio para todos los menus de  Encargos
            _tokenEnvioCreacion = "GestionEncargo";//Para ventana de  seleccion de  cliente.

            RegisterCommands();
            EncargosMainModel = new MainModel();
            dlg = new DialogCoordinator();
            ListaPrincipal = new List<MenuEncargos>(MenuEncargos.GetAll());
            Messenger.Default.Register<EstiloMensaje>(this, (controlEstiloMensaje) => ControlEstiloMensaje(controlEstiloMensaje));
            Messenger.Default.Register<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal,(principalUsuarioValidadoMensaje) => ControlPrincipalUsuarioValidadoMensaje(principalUsuarioValidadoMensaje));
            //Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));
            accesibilidadEncargos = false;
            visibilidadCliente = Visibility.Collapsed;
            currentEncargo = null;
            nombreEncargo = "";
        }

        private void ControlEncargoMensaje(EncargoMensaje encargoMensaje)
        {
            EncargosMainModel.TypeName = null;
            if (encargoMensaje.encargoModelo == null)
            {
                currentEncargo = null;
                accesibilidadEncargos = false;
                nombreEncargo = "";
            }
            else
            {
                if (comando == 5)
                {
                    currentEncargo = null;
                    accesibilidadEncargos = true;
                    nombreEncargo = "";
                }
                else
                {
                    currentEncargo = encargoMensaje.encargoModelo;
                    accesibilidadEncargos = true;
                    nombreEncargo = currentEncargo.razonsocialcliente + "\n" + currentEncargo.descripcionTipoAuditoria + " de " + Convert.ToDateTime(currentEncargo.fechainiperauditencargo).Year;
                }
            }
            Messenger.Default.Unregister<EncargoMensaje>(this, tokenRecepcionSeleccionCliente);
        }


        private void ControlPrincipalUsuarioValidadoMensaje(PrincipalUsuarioValidadoMensaje principalUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = principalUsuarioValidadoMensaje.elementoMensaje;
            usuarioModelo = principalUsuarioValidadoMensaje.usuarioModelo;
            inicializacionTerminada();
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPrincipal);
        }

        private void ControlEstiloMensaje(EstiloMensaje controlEstiloMensaje)
        {
            if (controlEstiloMensaje.mensajeEstilo == 0)
            {
                estilos();
            }
        }

        #endregion

        #endregion

        #region Implementacion de comandos
        private void estilos()
        {
            EstiloEdicion = "MetroFlatButtonSG";
            EstiloPlanificacion = "MetroFlatButtonSG";
            EstiloDocumentacion = "MetroFlatButtonSG";
            EstiloCedulas = "MetroFlatButtonSG";
            EstiloSupervision = "MetroFlatButtonSG";
            EstiloCierre = "MetroFlatButtonSG";
        }
        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            EdicionCommand = new RelayCommand(Edicion);//Comando 5
            PlanificacionCommand = new RelayCommand(Planificacion);//Comando 1
            DocumentacionCommand = new RelayCommand(Documentacion);//Comando 6
            CedulasCommand = new RelayCommand(Cedulas);//Comando 4
            SupervisionCommand = new RelayCommand(Supervision);//COmando 2
            CierreCommand = new RelayCommand(Cierre);//Comando 3
            SelectionChangedCommand = new RelayCommand();
            DobleClickCommand = new RelayCommand(Repeticion);
        }
        #endregion

        #region Metodos
        public void Repeticion()
        {

        }
        public async void PlanificacionPrevio()
        {
            comando = 1;
            visibilidadCliente = Visibility.Visible;
            //Consultar el listado de encargos
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                //Si el rol del usuario es socio  o gerente tiene opcion de crear encargos
                if (usuarioModelo.idRol == 7 || usuarioModelo.idRol == 6)
                {
                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Ok",
                        NegativeButtonText = "Cancelar",
                    };

                    MessageDialogResult result = await dlg.ShowMessageAsync(this, "No existen encargos asignados", "¿Desea crear uno?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                    if (result == MessageDialogResult.Affirmative)
                    {
                        EncargosMainModel.TypeName = "Crear Encargo";
                        //Crear el encargo
                        
                        //Lista de elementos  contables
                        listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());
                        //Carga del sistema contable
                        //Como no se conoce de que cliente es el encargo, se carga una lista generica que debe validarse para crear los elementos y sistema contable
                        //del encargo y del cliente.
                        currentSistemaContable = new SistemaContableModelo();
                        currentEncargo = new EncargoModelo();
                        enviarCrearEncargoMensaje();
                    }
                    else
                    {
                        //No se hace nada xp no hay encargos
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "");
                }

            }
            else
            {
                //int cantidad=EncargoModelo.ContarRegistros
                EncargosMainModel.TypeName = "Planificación";
                currentEntidad = ListaPrincipal[0];
                estilos();
                EstiloPlanificacion = "SquareButtonStyle";
                Mostrar();
            }
        }

        public async void Planificacion()
        {
            comando = 1;
            visibilidadCliente = Visibility.Visible;
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "");
            }
            else
            {
                //int cantidad=EncargoModelo.ContarRegistros
                EncargosMainModel.TypeName = "Planificación";
                currentEntidad = ListaPrincipal[1];
                estilos();
                EstiloPlanificacion = "SquareButtonStyle";
                Mostrar();
            }
        }

        public void Edicion()
        {
            visibilidadCliente = Visibility.Collapsed;
            comando = 5;
            currentEntidad = ListaPrincipal[0];
            estilos();
            EstiloEdicion = "SquareButtonStyle";
            accesibilidadEncargos = true;//No necesita seleccion para habilitar
            currentEncargo = null;//no  hay ninguno elegido
            nombreEncargo = "";
            Mostrar();
        }
        public async void Documentacion()
        {
            comando = 6;
            visibilidadCliente = Visibility.Visible;
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                    await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "");
            }
            else
            {
                EncargosMainModel.TypeName = "Documentacion";
                currentEntidad = ListaPrincipal[2];
                estilos();
                EstiloDocumentacion = "SquareButtonStyle";
                Mostrar();
            }
        }
        public async void Cedulas()
        {
            comando = 4;
            visibilidadCliente = Visibility.Visible;
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "");
            }
            else
            {
                EncargosMainModel.TypeName = "Cédulas";
                currentEntidad = ListaPrincipal[5];
                estilos();
                EstiloCedulas = "SquareButtonStyle";
                Mostrar();
            }
        }
        public async void Supervision()
        {
            visibilidadCliente = Visibility.Visible;
            comando = 2;
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                    await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "");
            }
            else
            {
                EncargosMainModel.TypeName = "Supervision";
                currentEntidad = ListaPrincipal[3];
                estilos();
                EstiloSupervision = "SquareButtonStyle";
                Mostrar();
            }

        }
        public async void Cierre()
        {
            visibilidadCliente = Visibility.Visible;
            comando = 3;
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                    await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "");

            }
            else
            {
                EncargosMainModel.TypeName = "Cierre";
                currentEntidad = ListaPrincipal[4];
                estilos();
                EstiloCierre = "SquareButtonStyle";
                Mostrar();
            }

        }

        public void Mostrar()
        {
            if (currentEntidad == null)
            {
            }
            else
            {
                tokenEnvio = currentEntidad.ViewDisplay + "MenuEncargos";
                tokenRecepcionSeleccionCliente= currentEntidad.ViewDisplay+"ClienteSeleccionado";
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvio, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));

                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeUsuario();
                ListaPrincipal = new List<MenuEncargos>(MenuEncargos.GetAll());
            }
        }

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            //cursorWindow = comandoTerminado.cursorWindow;
            cursorWindow = null;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenEnvio);
            currentEntidad = new MenuEncargos();
        }

        public void enviarMensajeUsuario()
        {
            //Creando el mensaje de transmision del usuario
            UsuarioMensaje elemento = new UsuarioMensaje(); ;
            elemento.usuarioMensaje = currentUsuario;
            elemento.usuarioModeloMensaje = usuarioModelo;
            Messenger.Default.Send(elemento, tokenEnvio);
        }
        public void enviarCrearEncargoMensaje()
        {
            encargosDatosCreacion mensaje = new encargosDatosCreacion();
            mensaje.listaElementos = listaElementos;
            mensaje.sistemaContable = currentSistemaContable;
            mensaje.encargoModelo = currentEncargo;
            Messenger.Default.Send(mensaje, tokenEnvioCreacion);
        }

        #endregion
    }
}

