using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Model;
using SGPTWpf.Model.Menus;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Collections.Generic;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Administracion
{
    public sealed class FirmaViewModel : ViewModeloBase
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

        #region ViewModel Properties : Vistas

        #region Prueba Listas

        public const string ListaVistaPropertyName = "ListaVista";

        private List<MenuFirma> _ListaVista;

        public List<MenuFirma> ListaVista
        {
            get
            {
                return _ListaVista;
            }

            set
            {
                if (_ListaVista == value) return;

                _ListaVista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaVistaPropertyName);
            }
        }

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuFirma _currentEntidad;

        public MenuFirma currentEntidad
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

        #endregion
        #endregion
        #region Propiedades


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


        public FirmaViewModel()
        {
            RegistrarComandos();
            dlg = new DialogCoordinator();
            ListaVista = actualizarListaMenu();
            //opcion[0].NavigateExecute();

            Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));

            _tokenRecepcionAdmon = "Firma" + "Administracion";
            Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));

        }

        public List<MenuFirma> actualizarListaMenu()
        {
            List<MenuFirma> opcion = new List<MenuFirma>
            {
                new MenuFirma() { ViewDisplay="Configuracion"},
                new MenuFirma() { ViewDisplay="Tiempo"},
                new MenuFirma() { ViewDisplay="Correspondencia"},
                new MenuFirma() { ViewDisplay="Reuniones"}
            };
            return opcion;
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
        #endregion

        #region Redireccion de comandos
        public void Mostrar()
        {
            if (currentEntidad == null)
            {
            }
            else
            {
                currentEntidad.NavigateExecute();
                enviarMensajeUsuarioValidado();
                //Actualizacion de la lista
                ListaVista = actualizarListaMenu();
            }
        }

        public void enviarMensajeUsuarioValidado()
        {
            try
            {

                //Creando el mensaje de transmision del usuario
                //AdministracionUsuarioValidadoMensaje elemento = new AdministracionUsuarioValidadoMensaje();
                NivSecund_Administracion_UsuarioValidadoMensaje elemento = new NivSecund_Administracion_UsuarioValidadoMensaje();
                elemento.elementoMensaje = currentUsuario;
                Messenger.Default.Send(elemento);
                //lo voy a recibir en NivSecund_Administracion_UsuarioValidadoMensaje para el nivel de mas abajo.
            }
            catch (System.Exception)
            {
                
            }
        }
        #endregion
        #endregion

    }
}