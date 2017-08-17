using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Administracion
{
    public sealed  class CatalogosViewModel : ViewModeloBase
    {

        #region ViewModel Properties

        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
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

        #region tokenCatalogoDatos

        private string _tokenCatalogoDatos;
        private string tokenCatalogoDatos
        {
            get { return _tokenCatalogoDatos; }
            set { _tokenCatalogoDatos = value; }
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

        #region ViewModel Properties : tokenRecepcionAdmon

        public const string tokenRecepcionAdmonPropertyName = "tokenRecepcionAdmon";

        private string _tokenRecepcionAdmon;

        public string tokenRecepcionAdmon
        {
            get
            {
                return _tokenRecepcionAdmon;
            }

            set
            {
                if (_tokenRecepcionAdmon == value)
                {
                    return;
                }

                _tokenRecepcionAdmon = value;
                RaisePropertyChanged(tokenRecepcionAdmonPropertyName);
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

        #region Vistas SGPT

        #region Propiedades visibilidad


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

        #endregion

        #endregion

        #region ViewModel PropertiesPrivadas

        private DialogCoordinator dlg;

        #endregion

        #region ViewModel Properties : listaCatalogo

        public const string listaCatalogoPropertyName = "listaCatalogo";

        private ObservableCollection<MenuCatalogoModelo> _listaCatalogo;

        public ObservableCollection<MenuCatalogoModelo> listaCatalogo
        {
            get
            {
                return _listaCatalogo;
            }

            set
            {
                if (_listaCatalogo == value) return;

                _listaCatalogo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCatalogoPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuCatalogoModelo _currentEntidad;

        public MenuCatalogoModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidad = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion

        #endregion


        public CatalogosViewModel()
        {
            RegistrarComandos();
            _tokenEnvio="CatalogoDatos";
            _tokenCatalogoDatos = "CatalogoDatos";
            _cursorWindow = Cursors.Hand;
            dlg = new DialogCoordinator();
            listaCatalogo =new ObservableCollection<MenuCatalogoModelo>(MenuCatalogoModelo.GetAll());
            Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            _tokenRecepcionAdmon = "Catalogos" + "Administracion";
            Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));
            currentEntidad = new MenuCatalogoModelo();
        }

        private void ControlAdministracionUsuarioValidadoMensaje(AdministracionUsuarioValidadoMensaje administracionUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = administracionUsuarioValidadoMensaje.usuarioMensaje;
            usuarioModelo = administracionUsuarioValidadoMensaje.usuarioModelo;
            Messenger.Default.Unregister<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon);
            inicializacionTerminada();
            Mouse.OverrideCursor = null;
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionAdmon);
        }
        private void ControlTabitemMensaje(TabItemMensaje mensaje)
        {
            accesibilidadTab = mensaje.mensaje;
        }


        #region ShowWindowCommand

        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            VerVistaCrudCommand = new RelayCommand(Mostrar);
        }

        #endregion
        #region ViewModel Commands


        public RelayCommand VerVistaCrudCommand { get; set; }
        public RelayCommand VerVistaHerramientasCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        #endregion

        #region Redireccion de comandos

        public void Mostrar()
        {
            if (currentEntidad == null || currentEntidad.ViewDisplay == null)
            {
            }
            else
            {
                tokenCatalogoDatos = currentEntidad.ViewDisplay + "CatalogosViewModel";
                Messenger.Default.Register<ComandoTerminado>(this, tokenCatalogoDatos, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando
                listaCatalogo = new ObservableCollection<MenuCatalogoModelo>(MenuCatalogoModelo.GetAll());
            }
        }
        #endregion

        public void enviarMensajeDatos()
        {
            //Creando el mensaje de transmision del usuario
            UsuarioMensaje elemento = new UsuarioMensaje();
            elemento.usuarioMensaje= currentUsuario;
            elemento.usuarioModeloMensaje = usuarioModelo;
            Messenger.Default.Send(elemento, tokenCatalogoDatos);
            //lo voy a recibir en NivSecund_Administracion_UsuarioValidadoMensaje para el nivel de mas abajo.
        }

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenCatalogoDatos);
            currentEntidad = new MenuCatalogoModelo();
        }
        #endregion

    }
}