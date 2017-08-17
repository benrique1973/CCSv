using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPTWpf.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Encargos.Supervision
{
    public sealed class SupervisionViewModel : ViewModeloBase
    {
        #region propiedades privadas

        //private MetroDialogSettings configuracionDialogo;
        //private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region Encargos
        //Permite recibir de encargos el usuario
        private string _tokenRecepcionEncargos;
        private string tokenRecepcionEncargos
        {
            get { return _tokenRecepcionEncargos; }
            set { _tokenRecepcionEncargos = value; }
        }
        #endregion

        #region tokenRecepcionSeleccionCliente
        //Permite  recibir de  EncargosController el cliente  seleccionado
        private string _tokenRecepcionSeleccionCliente;
        private string tokenRecepcionSeleccionCliente
        {
            get { return _tokenRecepcionSeleccionCliente; }
            set { _tokenRecepcionSeleccionCliente = value; }
        }
        #endregion

        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion

        #region isEjecutadoMostrar
        private bool _isEjecutadoMostrar;
        private bool isEjecutadoMostrar
        {
            get { return _isEjecutadoMostrar; }
            set { _isEjecutadoMostrar = value; }
        }
        #endregion

        #region valorRetornado
        private int _valorRetornado;
        private int valorRetornado
        {
            get { return _valorRetornado; }
            set { _valorRetornado = value; }
        }
        #endregion

        #region tokenRecepcionSubMenuDetalle
        private string _tokenRecepcionSubMenuDetalle;
        private string tokenRecepcionSubMenuDetalle
        {
            get { return _tokenRecepcionSubMenuDetalle; }
            set { _tokenRecepcionSubMenuDetalle = value; }
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

        #region tokenRecepcionHijoMenu

        private string _tokenRecepcionHijoMenu;
        private string tokenRecepcionHijoMenu
        {
            get { return _tokenRecepcionHijoMenu; }
            set { _tokenRecepcionHijoMenu = value; }
        }

        #endregion

        #endregion

        #region ViewModel Properties


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

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuSupervision _currentEntidad;

        public MenuSupervision currentEntidad
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

        #region Vistas SGPT

        #region ViewModel Properties : listaVistas

        public const string listaVistasPropertyName = "listaVistas";

        private ObservableCollection<MenuSupervision> _listaVistas;

        public ObservableCollection<MenuSupervision> listaVistas
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

        public SupervisionViewModel()
        {
            _opcionSeleccionada = 0;
            _valorRetornado = 0;
            _tokenRecepcionSeleccionCliente = "Supervision" + "ClienteSeleccionado";//Proviene de  EncargosControllerViewModel;

            _tokenEnvioPadre = string.Empty;//Para comunicar los mensajes a las sub-ventanas
            _tokenRecepcionEncargos = "Supervision" + "MenuEncargos";

            _tokenRecepcionHijoMenu = string.Empty;
            _tokenRecepcionSubMenuDetalle = string.Empty;

            RegistrarComandos();
            _accesibilidadWindow = true;
            _cursorWindow = Cursors.Hand;
            dlg = new DialogCoordinator();
            listaVistas = new ObservableCollection<MenuSupervision>(MenuSupervision.GetAll());
            _opcionSeleccionada = 0;
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionEncargos, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));

            currentEntidad = new MenuSupervision();
            isEjecutadoMostrar = false;
            // Messenger.Default.Register<bool>(this, tokenRecepcionCartas, (controllerInicioProgramaMensaje) => ControllerInicioProgramaMensaje(controllerInicioProgramaMensaje));

        }



        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenRecepcionHijoMenu);
            currentEntidad = new MenuSupervision();
        }

        private void ControlUsuarioMensaje(UsuarioMensaje usuarioMensaje)
        {
            currentUsuario = usuarioMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = usuarioMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionEncargos);//El usuario  no puede cambiar a menos que vuelva a ingresar

            inicializacionTerminada();
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionEncargos);
        }

        private void ControlEncargoMensaje(EncargoMensaje encargoMensaje)
        {
            if (encargoMensaje.encargoModelo == null)
            {
                currentEncargo = null;
            }
            else
            {
                currentEncargo = encargoMensaje.encargoModelo;
                //isEjecutadoMostrar = false;
            }
        }

        private void ControlTabitemMensaje(TabItemMensaje mensaje)
        {
            accesibilidadWindow = mensaje.mensaje;
        }

        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            VerVistaCrudCommand = new RelayCommand(Mostrar);
        }

        #endregion

        #region ViewModel Commands

        public RelayCommand VerVistaCrudCommand { get; set; }

        #endregion

        #region ViewModel Private Methods

        #endregion

        public void Mostrar()
        {
            if (currentEntidad == null || currentEntidad.ViewDisplay == null)
            {
            }
            else
            {
                    Messenger.Default.Unregister<int>(this, tokenRecepcionSubMenuDetalle);//No siempre se da el  sub-detalle
                    Messenger.Default.Unregister<ComandoTerminado>(this, tokenRecepcionHijoMenu);

                    opcionSeleccionada = currentEntidad.id;
                    tokenEnvioPadre = currentEntidad.ViewDisplay + "Supervision";//Se personaliza segun el destinatario
                    tokenRecepcionSubMenuDetalle = tokenEnvioPadre + "DetalleRegreso";
                    tokenRecepcionHijoMenu = tokenEnvioPadre + "Hijo";

                    Messenger.Default.Register<ComandoTerminado>(this, tokenRecepcionHijoMenu, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                    Messenger.Default.Register<int>(this, tokenRecepcionSubMenuDetalle, (valorRetornado) => ControlValorRetornado(valorRetornado));

                    cursorWindow = Cursors.Wait;
                    currentEntidad.NavigateExecute();
                    enviarMensajeDatos();
                    //Reinicializacion de vista
                    listaVistas = new ObservableCollection<MenuSupervision>(MenuSupervision.GetAll());
                    foreach (MenuSupervision item in listaVistas)
                    {
                        if (item.id == opcionSeleccionada)
                        {
                            item.opcionSeleccionada = true;
                        }
                        else
                        {
                            item.opcionSeleccionada = false;
                        }
                    }
            }
        }

        private void ControlValorRetornado(int valorRetornado)
        {
            for (int i = 0; i < listaVistas.Count; i++)
            {
                if (listaVistas[i].id == opcionSeleccionada)
                {
                    currentEntidad = listaVistas[i];
                    i = listaVistas.Count;
                }
            }

            if (currentEntidad == null || currentEntidad.ViewDisplay == null)
            {
            }
            else
            {
                Mostrar();
            }

        }

        private void enviarMensajeDatos()
        {
            //Creando el mensaje de transmision del usuario
            EncargosDatosMsj elemento = new EncargosDatosMsj(); ;
            elemento.usuarioModelo = currentUsuarioModelo;
            elemento.encargoModelo = currentEncargo;
            elemento.tokenRespuesta = tokenRecepcionHijoMenu;
            elemento.tokenRespuestaDetalle = tokenRecepcionSubMenuDetalle;
            elemento.tabla = currentEntidad.tabla;
            Messenger.Default.Send(elemento, tokenEnvioPadre);
        }
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

    }
}