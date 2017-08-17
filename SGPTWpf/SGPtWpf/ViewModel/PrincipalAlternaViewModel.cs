using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Navegacion;
using System.Collections.Generic;
using System;
using CapaDatos;
using SGPTWpf.Model.Modelo.firmas;
using System.Collections.ObjectModel;
using SGPTmvvm.Soporte;
using System.Windows.Input;
using System.Data.Entity;
using System.Threading.Tasks;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Messages.Genericos;

namespace SGPTWpf.ViewModel
{
    public sealed class PrincipalAlternaViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;


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

        #region tokenRecepcionSincronizacion

        private string _tokenRecepcionSincronizacion;
        private string tokenRecepcionSincronizacion
        {
            get { return _tokenRecepcionSincronizacion; }
            set { _tokenRecepcionSincronizacion = value; }
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

        #region tokenEnvioSincronizacion

        private string _tokenEnvioSincronizacion;
        private string tokenEnvioSincronizacion
        {
            get { return _tokenEnvioSincronizacion; }
            set { _tokenEnvioSincronizacion = value; }
        }

        #endregion

        #region PrincipalMainModel

        private MainModel _mainModel = null;

        public MainModel PrincipalMainModel
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
        
        
        //public SGPTEntidades db = new SGPTEntidades();
        public SGPTEntidades db = new SGPTEntidades();
        private DialogCoordinator dlg;

        #region tokenEnvioPrincipal

        private string _tokenEnvioPrincipal;
        private string tokenEnvioPrincipal
        {
            get { return _tokenEnvioPrincipal; }
            set { _tokenEnvioPrincipal = value; }
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

        #region ViewModel Property : currentFirma Firma en uso

        public const string currentFirmaPropertyName = "currentFirma";

        private FirmaModelo _currentFirma;

        public FirmaModelo currentFirma
        {
            get
            {
                return _currentFirma;
            }

            set
            {
                if (_currentFirma == value) return;

                _currentFirma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentFirmaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaFirma

        public const string listaFirmaPropertyName = "listaFirma";

        private ObservableCollection<FirmaModelo> _listaFirma;

        public ObservableCollection<FirmaModelo> listaFirma
        {
            get
            {
                return _listaFirma;
            }
            set
            {
                if (_listaFirma == value) return;

                _listaFirma = value;

                RaisePropertyChanged(listaFirmaPropertyName);
            }
        }

        #endregion

        #endregion

        #region razonsocialfirma

        public const string razonsocialfirmaPropertyName = "razonsocialfirma";

        private string _razonsocialfirma = string.Empty;

        public string razonsocialfirma
        {
            get
            {
                return _razonsocialfirma;
            }

            set
            {
                if (_razonsocialfirma == value)
                {
                    return;
                }

                _razonsocialfirma = value;
                RaisePropertyChanged(razonsocialfirmaPropertyName);
            }
        }

        #endregion

        #region estadoVentanaPrincipal

        public const string estadoVentanaPrincipalPropertyName = "estadoVentanaPrincipal";

        private string _estadoVentanaPrincipal = string.Empty;

        public string estadoVentanaPrincipal
        {
            get
            {
                return _estadoVentanaPrincipal;
            }

            set
            {
                if (_estadoVentanaPrincipal == value)
                {
                    return;
                }

                _estadoVentanaPrincipal = value;
                RaisePropertyChanged(estadoVentanaPrincipalPropertyName);
            }
        }

        #endregion

        #region nickUsuarioUsuario

        public const string nickusuariousuarioPropertyName = "nickusuariousuario";

        private string _nickusuariousuario = string.Empty;

        public string nickusuariousuario
        {
            get
            {
                return _nickusuariousuario;
            }

            set
            {
                if (_nickusuariousuario == value)
                {
                    return;
                }

                _nickusuariousuario = value;
                RaisePropertyChanged(nickusuariousuarioPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties publicas

        public const string VisiblePropertyName = "Visible";


        private bool _Visible = false;

        public bool Visible
        {
            get
            {
                return _Visible;
            }

            set
            {
                if (_Visible == value)
                {
                    return;
                }

                _Visible = value;
                RaisePropertyChanged(VisiblePropertyName);
            }
        }

        #region EstiloAdministracion

        public const string EstiloAdministracionPropertyName = "EstiloAdministracion";

        private string _EstiloAdministracion = string.Empty;

        public string EstiloAdministracion
        {
            get
            {
                return _EstiloAdministracion;
            }

            set
            {
                if (_EstiloAdministracion == value)
                {
                    return;
                }
                _EstiloAdministracion = value;
                RaisePropertyChanged(EstiloAdministracionPropertyName);
            }
        }

        #endregion

        #region EstiloHerramientas

        public const string EstiloHerramientasPropertyName = "EstiloHerramientas";

        private string _EstiloHerramientas = string.Empty;

        public string EstiloHerramientas
        {
            get
            {
                return _EstiloHerramientas;
            }

            set
            {
                if (_EstiloHerramientas == value)
                {
                    return;
                }
                _EstiloHerramientas = value;
                RaisePropertyChanged(EstiloHerramientasPropertyName);
            }
        }

        #endregion

        #region EstiloEncargos

        public const string EstiloEncargosPropertyName = "EstiloEncargos";

        private string _EstiloEncargos = string.Empty;

        public string EstiloEncargos
        {
            get
            {
                return _EstiloEncargos;
            }

            set
            {
                if (_EstiloEncargos == value)
                {
                    return;
                }
                _EstiloEncargos = value;
                RaisePropertyChanged(EstiloEncargosPropertyName);
            }
        }

        #endregion

        #region EstiloDocumentos

        public const string EstiloDocumentosPropertyName = "EstiloDocumentos";

        private string _EstiloDocumentos = string.Empty;

        public string EstiloDocumentos
        {
            get
            {
                return _EstiloDocumentos;
            }

            set
            {
                if (_EstiloDocumentos == value)
                {
                    return;
                }
                _EstiloDocumentos = value;
                RaisePropertyChanged(EstiloDocumentosPropertyName);
            }
        }

        #endregion

        #region EstiloNormas

        public const string EstiloNormasPropertyName = "EstiloNormas";

        private string _EstiloNormas = string.Empty;

        public string EstiloNormas
        {
            get
            {
                return _EstiloNormas;
            }

            set
            {
                if (_EstiloNormas == value)
                {
                    return;
                }
                _EstiloNormas = value;
                RaisePropertyChanged(EstiloNormasPropertyName);
            }
        }

        #endregion

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


        #region tokenRecepcionSeleccionCliente

        private string _tokenRecepcionSeleccionCliente;
        private string tokenRecepcionSeleccionCliente
        {
            get { return _tokenRecepcionSeleccionCliente; }
            set { _tokenRecepcionSeleccionCliente = value; }
        }

        #endregion

        #region ViewModel Commands

        public RelayCommand SalirCommand { get; set; }
        public RelayCommand DesplegarLateralCommand { get; set; }

        public RelayCommand OlvidoCommand { get; set; }


        public RelayCommand SincronizacionCommand { get; set; }
        public RelayCommand AdministracionCommand { get; set; }
            public RelayCommand EncargosCommand { get; set; }
            public RelayCommand HerramientasCommand { get; set; }
            public RelayCommand DocumentosCommand { get; set; }
            public RelayCommand NormasCommand { get; set; }
            public RelayCommand DobleClickCommand { get; set; }
            public RelayCommand SelectionChangedCommand { get; set; }

        #endregion

        private void Salir()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            CloseWindow();
        }


        private void DesplegarLateral()
        {
            if (Visible)
            { Visible = false; }
            else
            { Visible = true; }
        }

        private void Olvido() // aqui no va. ya esta programado en otro lugar. 04/04/2017
        {
            //Opciones aplicables cuando olvida la contraseña
        }

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

        #region ViewModel Properties : accesibilidadTab

        public const string accesibilidadTabPropertyName = "AccesibilidadTab";

        private bool _accesibilidadTab = true;

        public bool accesibilidadTab
        {
            get
            {
                return _accesibilidadTab;
            }

            set
            {
                if (_accesibilidadTab == value)
                {
                    return;
                }

                _accesibilidadTab = value;
                RaisePropertyChanged(accesibilidadTabPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : habilitarMenus

        public const string habilitarMenusPropertyName = "habilitarMenus";

        private bool _habilitarMenus ;

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

        #region ViewModel Public Methods

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

                private MenuPrincipal _currentEntidad;

                public MenuPrincipal currentEntidad
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

        private List<MenuPrincipal> _ListaPrincipal;
        public List<MenuPrincipal> ListaPrincipal
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

        public PrincipalAlternaViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _estadoVentanaPrincipal = "Maximized";
            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar
            _visibilidadCliente = Visibility.Collapsed;
            _accesibilidadWindow = true;

            _habilitarMenus = true;

            _comando = 0;

            _tokenControlarMenu = "ClienteControlMenu";
            _tokenEnvioPrincipal = "EncargosDatos";

            _tokenEnvioSincronizacion = "SincronizarBase";
            _tokenRecepcionSincronizacion = "SincronizarTerminada";
            RegisterCommands();
            dlg = new DialogCoordinator();
            estilos();
            ListaPrincipal = new List<MenuPrincipal>(MenuPrincipal.GetAll());
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            Messenger.Default.Register<UsuarioValidadoMensaje>(this, (usuarioValidadoMensaje) => ControlUsuarioValidadoMensaje(usuarioValidadoMensaje));
            if (FirmaModelo.ContarRegistros() == 0)
            {
                currentFirma = new FirmaModelo();
                currentFirma.razonsocialfirma = "Nombre de  la firma";
            }
            else
            {
                listaFirma = new ObservableCollection<FirmaModelo>(FirmaModelo.GetAll());
                currentFirma = listaFirma[0];
            }
            Messenger.Default.Register<bool>(this, tokenControlarMenu,(controlBarraMenu) => ControlControlBarraMenu(controlBarraMenu));
            //Para control de  ventanas
            PrincipalMainModel = new MainModel();
            currentEncargo = null;
            nombreEncargo = "";
            _accesibilidadEncargos = false;
            _tokenRecepcionSeleccionCliente = string.Empty;
            //_tokenRecepcionSeleccionCliente = "Documentacion"+"ClienteSeleccionado";//Recepcion de  EncargosControllerViewModel
            //Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));


        }

        private void ControlEncargoMensaje(EncargoMensaje encargoMensaje)
        {
            PrincipalMainModel.TypeName = null;
            if (encargoMensaje.encargoModelo == null)
            {
                currentEncargo = null;
                accesibilidadEncargos = false;
                nombreEncargo = "";
            }
            else
            {
                if (comando == 4) //Documentacion
                {
                    currentEncargo = encargoMensaje.encargoModelo;
                    accesibilidadEncargos = true;
                    nombreEncargo = currentEncargo.razonsocialcliente + "\n" + currentEncargo.descripcionTipoAuditoria + " de " + Convert.ToDateTime(currentEncargo.fechainiperauditencargo).Year;
                    visibilidadCliente = Visibility.Visible;
                }
                else
                {
                    currentEncargo = null;
                    accesibilidadEncargos = true;
                    nombreEncargo = "";
                    visibilidadCliente = Visibility.Collapsed;
                }
            }
            Messenger.Default.Unregister<EncargoMensaje>(this, tokenRecepcionSeleccionCliente);
        }
        public void sincronizar()
        {

            iniciarComando();

            comando = 1;
            PrincipalMainModel.TypeName = "SincronizarView";
            //Debe ir antes, porque evalua si la ventana es cero para enviarse
            enviarMensajeUsuario(tokenEnvioSincronizacion);
        }

        private void ControlControlBarraMenu(bool controlBarraMenu)
        {
            habilitarMenus = controlBarraMenu;
        }

        private void ControlUsuarioValidadoMensaje(UsuarioValidadoMensaje usuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = usuarioValidadoMensaje.elementoMensaje;
            usuarioModelo = usuarioValidadoMensaje.usuarioModelo;
            nickusuariousuario = currentUsuario.nickusuariousuario;
            Messenger.Default.Unregister<UsuarioValidadoMensaje>(this);

            //Editado por Eliezer 04/04/2017
            //Despues de conocer quien es el usuario actual, le traemos su configuracion personal del color.
            //using (db = new SGPTEntidades())
            //{
            switch (currentUsuario.temacolorsistemausuario)
            {
                case 1: Messenger.Default.Send<String>("1", "ponelecolor"); break;
                case 2: Messenger.Default.Send<String>("2", "ponelecolor"); break;
                case 3: Messenger.Default.Send<String>("3", "ponelecolor"); break;
                case 4: Messenger.Default.Send<String>("4", "ponelecolor"); break;
                case 5: Messenger.Default.Send<String>("5", "ponelecolor"); break;
                case 6: Messenger.Default.Send<String>("6", "ponelecolor"); break;
                case 7: Messenger.Default.Send<String>("7", "ponelecolor"); break;
                case 8: Messenger.Default.Send<String>("8", "ponelecolor"); break;
                case 9: Messenger.Default.Send<String>("9", "ponelecolor"); break;
                case 10: Messenger.Default.Send<String>("10", "ponelecolor"); break;
            }
            //}
        }

        private void ControlTabitemMensaje(TabItemMensaje mensaje)
        {
            accesibilidadTab = mensaje.mensaje;
            //if (mensaje.mensaje)
            //{
            //    estadoVentanaPrincipal = "Maximized";
            //}
            //else
            //{
            //    estadoVentanaPrincipal = "Minimized";
            //}
        }

        #endregion


        #endregion

        #region Implementacion de comandos

        #endregion

        #region ViewModel Private Methods

        private void estilos()
        {
            EstiloAdministracion = "MetroFlatButtonSG";
            EstiloHerramientas = "MetroFlatButtonSG";
            EstiloEncargos = "MetroFlatButtonSG";
            EstiloDocumentos = "MetroFlatButtonSG"; 
            EstiloNormas = "MetroFlatButtonSG"; 
        }
        private void RegisterCommands()
        {
            SalirCommand = new RelayCommand(Salir);
            DesplegarLateralCommand = new RelayCommand(DesplegarLateral);
            OlvidoCommand = new RelayCommand(Olvido);

            AdministracionCommand = new RelayCommand(administracion);
            EncargosCommand = new RelayCommand(Encargos);
            HerramientasCommand = new RelayCommand(Herramientas);
            DocumentosCommand = new RelayCommand(Documentos);
            NormasCommand = new RelayCommand(Normas);
            SelectionChangedCommand = new RelayCommand();
            DobleClickCommand = new RelayCommand(Repeticion);
            SincronizacionCommand = new RelayCommand(sincronizar);
        }


        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            PrincipalMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    comando = 0;
                    break;
                case 2:
                    comando = 0;
                    break;
            }
            finComando();
        }

        #endregion

        #region Metodos
        public void Repeticion()
        {
            
        }
        public void administracion()
        {
            visibilidadCliente = Visibility.Collapsed;
            currentEntidad = ListaPrincipal[0];
            
            estilos();
            EstiloAdministracion= "SquareButtonStyle";
            Mostrar();
            enviarMensajeEstilo();
            //tokenEnvioPrincipal = "Administracion";
            //enviarMensajeUsuario(tokenEnvioPrincipal);
        }
        public  void Encargos()
        {
            visibilidadCliente = Visibility.Collapsed;
            currentEntidad = ListaPrincipal[1];
            
            estilos();
            EstiloEncargos = "SquareButtonStyle";
            Mostrar();
            enviarMensajeEstilo();
            //tokenEnvioPrincipal = "Encargos";
            //enviarMensajeUsuario(tokenEnvioPrincipal);

        }
        public  void Herramientas()
        {
            visibilidadCliente = Visibility.Collapsed;
            currentEntidad = ListaPrincipal[2];
            
            estilos();
            EstiloHerramientas = "SquareButtonStyle";
            Mostrar();
            enviarMensajeEstilo();
            //tokenEnvioPrincipal = "Herramientas";
            //enviarMensajeUsuario(tokenEnvioPrincipal);
        }
        public async void Documentos()
        {
            visibilidadCliente = Visibility.Visible;
            comando = 4;
            if (AsignacionModelo.ContarRegistrosUsuario(usuarioModelo.idUsuario) == 0)
            {
                await dlg.ShowMessageAsync(this, "No hay registros de encargos asignados", "Por tanto no  hay registros a consultar");

            }
            else
            {
                PrincipalMainModel.TypeName = "SeleccionEncargo";
                currentEntidad = ListaPrincipal[3];
                estilos();
                EstiloDocumentos = "SquareButtonStyle";
                enviarMensajeEstilo();
                Mostrar();
            }
        }
        public  void Normas()
        {
            visibilidadCliente = Visibility.Collapsed;
            currentEntidad = ListaPrincipal[4];
            estilos();
            EstiloNormas = "SquareButtonStyle";
            Mostrar();
            enviarMensajeEstilo();
            //tokenEnvioPrincipal = "Normas";
            //enviarMensajeUsuario(tokenEnvioPrincipal);
        }
        public void Mostrar()
        {
            if (currentEntidad == null)
            {
            }
            else
            {
                //Se suscribe a los mensajes
                    tokenEnvioPrincipal = currentEntidad.ViewDisplay ;
                    if(comando==4)//Caso de documentacion
                { 
                    tokenRecepcionSeleccionCliente = currentEntidad.ViewDisplay+"ClienteSeleccionado"; 
                    Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));
                }
                    Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioPrincipal, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));

                    cursorWindow = Cursors.Wait;
                    currentEntidad.NavigateExecute();
                    enviarMensajeUsuario(tokenEnvioPrincipal);//Se personaliza segun el destinatario
                    //Reinicializacion de vista
                    ListaPrincipal = new List<MenuPrincipal>(MenuPrincipal.GetAll());
            }
        }

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenEnvioPrincipal);
            currentEntidad = new MenuPrincipal();
        }

        #endregion

        #region Habilitacion

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send(inhabilitar);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send(inhabilitar);
        }

        #endregion

        #region Lanzado de  comando

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionSincronizacion, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            accesibilidadTab = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionSincronizacion);
            accesibilidadTab = true;
        }


        #endregion Fin de comando


        #region Mensajes de estilos
        //Mandar mensaje por escoger un menu principal
        public void enviarMensajeEstilo()
        {
            //Creando el mensaje de cierre
            EstiloMensaje estilo = new EstiloMensaje(); ;
            estilo.mensajeEstilo = 0;
            Messenger.Default.Send(estilo);
        }
        public void enviarMensajeUsuario(string token)
        {
            //Creando el mensaje de transmision del usuario
            PrincipalUsuarioValidadoMensaje elemento = new PrincipalUsuarioValidadoMensaje(); ;
            elemento.elementoMensaje = currentUsuario;
            elemento.usuarioModelo = usuarioModelo;
            //Hacer la consulta de  los  permisos de los usuarios
            Messenger.Default.Send(elemento, token);
        }
        #endregion

        #region ComandosCambioColor de Eliezer no borrar 04/04/2017
        public bool _canExecute=true;

        private ICommand _MenuItem_Click_1;
        public ICommand MenuItem_Click_1
        {
            get
            {
                return _MenuItem_Click_1 ?? (_MenuItem_Click_1 = new CommandHandler(() => MyColor1(), _canExecute));
            }
        }

        private async void MyColor1()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "",1);
            this.guardarCambioColor(1);
            Messenger.Default.Send<String>("1", "ponelecolor");
        }



        private ICommand _MenuItem_Click_2;
        public ICommand MenuItem_Click_2
        {
            get
            {
                return _MenuItem_Click_2 ?? (_MenuItem_Click_2 = new CommandHandler(() => MyColor2(), _canExecute));
            }
        }

        private async void MyColor2()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(2);
            Messenger.Default.Send<String>("2", "ponelecolor");
        }



        private ICommand _MenuItem_Click_3;
        public ICommand MenuItem_Click_3
        {
            get
            {
                return _MenuItem_Click_3 ?? (_MenuItem_Click_3 = new CommandHandler(() => MyColor3(), _canExecute));
            }
        }

        private async void MyColor3()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(3);
            Messenger.Default.Send<String>("3", "ponelecolor");
        }


        private ICommand _MenuItem_Click_4;
        public ICommand MenuItem_Click_4
        {
            get
            {
                return _MenuItem_Click_4 ?? (_MenuItem_Click_4 = new CommandHandler(() => MyColor4(), _canExecute));
            }
        }

        private async void MyColor4()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(4);
            Messenger.Default.Send<String>("4", "ponelecolor");
        }


        private ICommand _MenuItem_Click_5;
        public ICommand MenuItem_Click_5
        {
            get
            {
                return _MenuItem_Click_5 ?? (_MenuItem_Click_5 = new CommandHandler(() => MyColor5(), _canExecute));
            }
        }

        private async void MyColor5()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(5);
            Messenger.Default.Send<String>("5", "ponelecolor");
        }



        private ICommand _MenuItem_Click_6;
        public ICommand MenuItem_Click_6
        {
            get
            {
                return _MenuItem_Click_6 ?? (_MenuItem_Click_6 = new CommandHandler(() => MyColor6(), _canExecute));
            }
        }

        private async void MyColor6()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(6);
            Messenger.Default.Send<String>("6", "ponelecolor");
        }


        private ICommand _MenuItem_Click_7;
        public ICommand MenuItem_Click_7
        {
            get
            {
                return _MenuItem_Click_7 ?? (_MenuItem_Click_7 = new CommandHandler(() => MyColor7(), _canExecute));
            }
        }

        private async void MyColor7()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(7);
            Messenger.Default.Send<String>("7", "ponelecolor");
        }


        private ICommand _MenuItem_Click_8;
        public ICommand MenuItem_Click_8
        {
            get
            {
                return _MenuItem_Click_8 ?? (_MenuItem_Click_8 = new CommandHandler(() => MyColor8(), _canExecute));
            }
        }

        private async void MyColor8()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(8);
            Messenger.Default.Send<String>("8", "ponelecolor");
        }



        private ICommand _MenuItem_Click_9;
        public ICommand MenuItem_Click_9
        {
            get
            {
                return _MenuItem_Click_9 ?? (_MenuItem_Click_9 = new CommandHandler(() => MyColor9(), _canExecute));
            }
        }

        private async void MyColor9()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(9);
            Messenger.Default.Send<String>("9", "ponelecolor"); 
        }



        private ICommand _MenuItem_Click_10;
        public ICommand MenuItem_Click_10
        {
            get
            {
                return _MenuItem_Click_10 ?? (_MenuItem_Click_10 = new CommandHandler(() => MyColor10(), _canExecute));
            }
        }

        private async void MyColor10()
        {
            await AvisaYCerrateVosSolo("Guardando el tema seleccionado...", "", 1);
            this.guardarCambioColor(10);
            Messenger.Default.Send<String>("10", "ponelecolor"); 
        }

        private void guardarCambioColor(int p)
        {
            try
            {
                using (db = new SGPTEntidades())
                {
                    var usux = db.usuarios.Find(currentUsuario.idusuario);
                    usux.temacolorsistemausuario = p;
                    db.Entry(usux).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                this.exception1();
            }
        }
        private async void exception1()
        {
            await AvisaYCerrateVosSolo("Verifique que la base de datos esta disponible", "No se guardo el tema seleccionado.", 1);
        }

        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            await Task.Delay(segundos);
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }
        #endregion
    }
}
