using SGPTWpf.Command;
using MahApps.Metro.Controls.Dialogs;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using CapaDatos;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;

namespace SGPTWpf.ViewModel.Administracion
{
    public sealed class AdministracionViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;


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

       

        #region ViewModel Properties : tokenRecepcionPrincipal

        public const string tokenRecepcionPrincipalPropertyName = "tokenRecepcionPrincipal";

        private string _tokenRecepcionPrincipal;

        public string tokenRecepcionPrincipal
        {
            get
            {
                return _tokenRecepcionPrincipal;
            }

            set
            {
                if (_tokenRecepcionPrincipal == value)
                {
                    return;
                }

                _tokenRecepcionPrincipal = value;
                RaisePropertyChanged(tokenRecepcionPrincipalPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : tokenEnvioAdmon

        public const string tokenEnvioAdmonPropertyName = "tokenEnvioAdmon";

        private string _tokenEnvioAdmon;

        public string tokenEnvioAdmon
        {
            get
            {
                return _tokenEnvioAdmon;
            }

            set
            {
                if (_tokenEnvioAdmon == value)
                {
                    return;
                }

                _tokenEnvioAdmon = value;
                RaisePropertyChanged(tokenEnvioAdmonPropertyName);
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

        private static int controlVentana = 0;

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

        #region EstiloCatalogo

        public const string EstiloCatalogoPropertyName = "EstiloCatalogo";

        private string _EstiloCatalogo = string.Empty;

        public string EstiloCatalogo
        {
            get
            {
                return _EstiloCatalogo;
            }

            set
            {
                if (_EstiloCatalogo == value)
                {
                    return;
                }
                _EstiloCatalogo = value;
                RaisePropertyChanged(EstiloCatalogoPropertyName);
            }
        }

        #endregion

        #region EstiloUsuarios

        public const string EstiloUsuariosPropertyName = "EstiloUsuarios";

        private string _EstiloUsuarios = string.Empty;

        public string EstiloUsuarios
        {
            get
            {
                return _EstiloUsuarios;
            }

            set
            {
                if (_EstiloUsuarios == value)
                {
                    return;
                }
                _EstiloUsuarios = value;
                RaisePropertyChanged(EstiloUsuariosPropertyName);
            }
        }

        #endregion

        #region EstiloRoles

        public const string EstiloRolesPropertyName = "EstiloRoles";

        private string _EstiloRoles = string.Empty;

        public string EstiloRoles
        {
            get
            {
                return _EstiloRoles;
            }

            set
            {
                if (_EstiloRoles == value)
                {
                    return;
                }
                _EstiloRoles = value;
                RaisePropertyChanged(EstiloRolesPropertyName);
            }
        }

        #endregion

        #region EstiloFirma

        public const string EstiloFirmaPropertyName = "EstiloFirma";

        private string _EstiloFirma = string.Empty;

        public string EstiloFirma
        {
            get
            {
                return _EstiloFirma;
            }

            set
            {
                if (_EstiloFirma == value)
                {
                    return;
                }
                _EstiloFirma = value;
                RaisePropertyChanged(EstiloFirmaPropertyName);
            }
        }

        #endregion

        #region EstiloClientes

        public const string EstiloClientesPropertyName = "EstiloClientes";

        private string _EstiloClientes = string.Empty;

        public string EstiloClientes
        {
            get
            {
                return _EstiloClientes;
            }

            set
            {
                if (_EstiloClientes == value)
                {
                    return;
                }
                _EstiloClientes = value;
                RaisePropertyChanged(EstiloClientesPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Properties : habilitarMenus

        public const string habilitarMenusPropertyName = "habilitarMenus";

        private bool _habilitarMenus;

        public bool habilitarMenus
        {
            get
            {
                return _habilitarMenus;
            }

            set
            {
                if (_habilitarMenus == value)
                {
                    return;
                }

                _habilitarMenus = value;
                RaisePropertyChanged(habilitarMenusPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : tokenControlarMenu

        public const string tokenControlarMenuPropertyName = "tokenControlarMenu";

        private string _tokenControlarMenu;

        public string tokenControlarMenu
        {
            get
            {
                return _tokenControlarMenu;
            }

            set
            {
                if (_tokenControlarMenu == value)
                {
                    return;
                }

                _tokenControlarMenu = value;
                RaisePropertyChanged(tokenControlarMenuPropertyName);
            }
        }

        #endregion

        #region ViewModel Commands


        public RelayCommand CatalogoCommand { get; set; }
        public RelayCommand UsuarioCommand { get; set; }
        public RelayCommand RolesCommand { get; set; }
        public RelayCommand FirmaCommand { get; set; }
        public RelayCommand ClientesCommand { get; set; }
        public RelayCommand DobleClickCommand { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }

        #endregion


        #region ViewModel Public Methods

    #region ViewModel Property : currentEntidad

    public const string currentEntidadPropertyName = "currentEntidad";

    private MenuAdministracion _currentEntidad;

    public MenuAdministracion currentEntidad
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

    private List<MenuAdministracion> _ListaPrincipal;
    public List<MenuAdministracion> ListaPrincipal
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


    public AdministracionViewModel()
        {
            _habilitarMenus = true;
            _tokenControlarMenu = "ClienteControlMenu";
            _tokenEnvioAdmon = "usuarioAdministracion";
            _tokenRecepcionPrincipal = "Administracion";
            RegisterCommands();
            dlg = new DialogCoordinator();
            ListaPrincipal = new List<MenuAdministracion>(MenuAdministracion.GetAll());
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<EstiloMensaje>(this, (controlEstiloMensaje) => ControlEstiloMensaje(controlEstiloMensaje));
            Messenger.Default.Register<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal,(principalUsuarioValidadoMensaje) => ControlPrincipalUsuarioValidadoMensaje(principalUsuarioValidadoMensaje));
            Messenger.Default.Register<bool>(this, tokenControlarMenu, (controlBarraMenu) => ControlControlBarraMenu(controlBarraMenu));

        }

        private void ControlControlBarraMenu(bool controlBarraMenu)
        {
            habilitarMenus = controlBarraMenu;
        }

        private void ControlPrincipalUsuarioValidadoMensaje(PrincipalUsuarioValidadoMensaje principalUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = principalUsuarioValidadoMensaje.elementoMensaje;
            usuarioModelo = principalUsuarioValidadoMensaje.usuarioModelo; ;
            Messenger.Default.Unregister<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal);
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
            Messenger.Default.Unregister<EstiloMensaje>(this);
        }

        #endregion


        #endregion

        #region Implementacion de comandos

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
    {
            CatalogoCommand = new RelayCommand(Catalogo);
            UsuarioCommand = new RelayCommand(Usuario);
            RolesCommand = new RelayCommand(Roles);
            FirmaCommand = new RelayCommand(Firma);
            ClientesCommand = new RelayCommand(Clientes);
            SelectionChangedCommand = new RelayCommand();
            DobleClickCommand = new RelayCommand(Repeticion);
    }
        #endregion

        private void estilos()
        {
            EstiloCatalogo = "MetroFlatButtonSG";
            EstiloClientes = "MetroFlatButtonSG";
            EstiloFirma = "MetroFlatButtonSG";
            EstiloRoles = "MetroFlatButtonSG";
            EstiloUsuarios = "MetroFlatButtonSG";
        }
        #region Metodos
        public void Repeticion()
    {
        controlVentana = controlVentana + 1;


    }
    public void Catalogo()
    {
        currentEntidad = ListaPrincipal[0];
        controlVentana = controlVentana + 1;
            estilos();
           EstiloCatalogo = "SquareButtonStyle";
           
            Mostrar();
    }
    public void Usuario()
    {
        currentEntidad = ListaPrincipal[1];
        controlVentana = controlVentana + 1;
            estilos();
            EstiloUsuarios = "SquareButtonStyle";
            Mostrar();


    }
    public void Roles()
    {
        currentEntidad = ListaPrincipal[2];
        controlVentana = controlVentana + 1;
            estilos();
           EstiloRoles = "SquareButtonStyle";
            Mostrar();

    }
    public void Firma()
    {
        /********************************************************************************/
        currentEntidad = ListaPrincipal[3];
        controlVentana = controlVentana + 1;
            estilos();
            EstiloFirma = "SquareButtonStyle";
            Mostrar();

    }
    public void Clientes()
    {
        //MessageBox.Show("Clientes jjeeejeje");
        currentEntidad = ListaPrincipal[4];
        controlVentana = controlVentana + 1;
        estilos();
        EstiloClientes = "SquareButtonStyle";
        Mostrar();

    }
    public void Mostrar()
    {
        if (currentEntidad == null)
        {
        }
        else
        {
                tokenEnvioAdmon = currentEntidad.ViewDisplay + "Administracion";
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioAdmon, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeUsuario();
                //Reinicializacion de vista
                ListaPrincipal = new List<MenuAdministracion>(MenuAdministracion.GetAll());
                //currentEntidad.NavigateExecute();
        }
    }

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenEnvioAdmon);
            currentEntidad = new MenuAdministracion();
        }

        public void enviarMensajeUsuario()
        {
            //Creando el mensaje de transmision del usuario
            AdministracionUsuarioValidadoMensaje elemento = new AdministracionUsuarioValidadoMensaje();
            elemento.usuarioMensaje = currentUsuario;
            elemento.usuarioModelo = usuarioModelo;
            Messenger.Default.Send(elemento, tokenEnvioAdmon);

            //lo voy a recibir en NivSecund_Administracion_UsuarioValidadoMensaje para el nivel de mas abajo.
        }
        #endregion
    }
}

