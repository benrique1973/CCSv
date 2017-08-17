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
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;

namespace SGPTWpf.ViewModel.Encargos.Documentacion
{
    public sealed class DocumentacionViewModel : ViewModeloBase
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

        #region tokenRecepcionIndice
        //Permite  recibir de  EncargosController el cliente  seleccionado
        private string _tokenRecepcionIndice;
        private string tokenRecepcionIndice
        {
            get { return _tokenRecepcionIndice; }
            set { _tokenRecepcionIndice = value; }
        }
        #endregion

        #region tokenRecepcionSubMenuIndice
        private string _tokenRecepcionSubMenuIndice;
        private string tokenRecepcionSubMenuIndice
        {
            get { return _tokenRecepcionSubMenuIndice; }
            set { _tokenRecepcionSubMenuIndice = value; }
        }
        #endregion


        #region tokenRecepcionRepositorio
        //Permite  recibir de  EncargosController el cliente  seleccionado
        private string _tokenRecepcionRepositorio;
        private string tokenRecepcionRepositorio
        {
            get { return _tokenRecepcionRepositorio; }
            set { _tokenRecepcionRepositorio = value; }
        }
        #endregion

        #region tokenRecepcionSubMenuRepositorio
        private string _tokenRecepcionSubMenuRepositorio;
        private string tokenRecepcionSubMenuRepositorio
        {
            get { return _tokenRecepcionSubMenuRepositorio; }
            set { _tokenRecepcionSubMenuRepositorio = value; }
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

        #region tokenRecepcionSubMenuCuestionarios
        private string _tokenRecepcionSubMenuCuestionarios;
        private string tokenRecepcionSubMenuCuestionarios
        {
            get { return _tokenRecepcionSubMenuCuestionarios; }
            set { _tokenRecepcionSubMenuCuestionarios = value; }
        }
        #endregion

        #region tokenRecepcionSubMenuProgramas
        private string _tokenRecepcionSubMenuProgramas;
        private string tokenRecepcionSubMenuProgramas
        {
            get { return _tokenRecepcionSubMenuProgramas; }
            set { _tokenRecepcionSubMenuProgramas = value; }
        }
        #endregion

        #region tokenEnvioDocumentacion

        private string _tokenEnvioDocumentacion;
        private string tokenEnvioDocumentacion
        {
            get { return _tokenEnvioDocumentacion; }
            set { _tokenEnvioDocumentacion = value; }
        }

        #endregion

        #region tokenRecepcionCuestionarios

        private string _tokenRecepcionCuestionarios;
        private string tokenRecepcionCuestionarios
        {
            get { return _tokenRecepcionCuestionarios; }
            set { _tokenRecepcionCuestionarios = value; }
        }

        #endregion

        #region tokenRecepcionProgramas

        private string _tokenRecepcionProgramas;
        private string tokenRecepcionProgramas
        {
            get { return _tokenRecepcionProgramas; }
            set { _tokenRecepcionProgramas = value; }
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

        private MenuDocumentacion _currentEntidad;

        public MenuDocumentacion currentEntidad
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

        private ObservableCollection<MenuDocumentacion> _listaVistas;

        public ObservableCollection<MenuDocumentacion> listaVistas
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

        public DocumentacionViewModel()
        {
            _tokenRecepcionSeleccionCliente = "Documentacion"+"ClienteSeleccionado";//Proviene de  EncargosControllerViewModel;
            _tokenEnvioDocumentacion = "DocumentacionDatos";//Para comunicar los mensajes a las sub-ventanas
            _tokenRecepcionEncargos = "Documentacion"+ "MenuEncargos"; 
            _tokenRecepcionSubMenu = "DetalleBalanceRegreso";
            _tokenRecepcionProgramas = "inicioProgramasDocumentacion";
            _tokenRecepcionCuestionarios = "inicioCuestionariosDocumentacion";
            _tokenRecepcionSubMenuCuestionarios = "DetalleCuestionarioRegreso";
            _tokenRecepcionSubMenuProgramas = "DetalleProgramaRegreso";
            _tokenRecepcionIndice = "inicioEncargoDocumentacionIndices";
            _tokenRecepcionSubMenuIndice = "DocumentacionDetalleIndiceRegreso";

            _tokenRecepcionRepositorio = "inicioEncargoDocumentacionRepositorio";
            _tokenRecepcionSubMenuRepositorio = "DocumentacionDetalleRepositorioRegreso";

            RegistrarComandos();
            _accesibilidadWindow = true;
            _cursorWindow = Cursors.Hand;
            dlg = new DialogCoordinator();
            listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
            _opcionSeleccionada = 0;
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionEncargos, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));

            Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlDetalleTerminado(detalleTerminado));
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenuCuestionarios, (detalleTerminado) => ControlDetalleTerminadoSubmenuCuestionarios(detalleTerminado));
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenuProgramas, (detalleTerminado) => ControlDetalleTerminadoSubmenuPrograma(detalleTerminado));
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenuIndice, (detalleTerminado) => ControlDetalleTerminadoSubMenuIndice(detalleTerminado));

            Messenger.Default.Register<int>(this, tokenRecepcionIndice, (detalleTerminado) => ControlDetalleTerminadoIndice(detalleTerminado));

            Messenger.Default.Register<int>(this, tokenRecepcionRepositorio, (detalleTerminado) => ControlDetalleTerminadoIndice(detalleTerminado));
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenuRepositorio, (detalleTerminado) => ControlDetalleTerminadoSubMenuIndice(detalleTerminado));


            currentEntidad = new MenuDocumentacion();

            // Messenger.Default.Register<bool>(this, tokenRecepcionCartas, (controllerInicioProgramaMensaje) => ControllerInicioProgramaMensaje(controllerInicioProgramaMensaje));

        }



        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenEnvioDocumentacion);
            currentEntidad = new MenuDocumentacion();
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
                opcionSeleccionada = currentEntidad.id;
                tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializacion de vista
                listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
                foreach (MenuDocumentacion item in listaVistas)
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

        private void ControlDetalleTerminado(int detalleTerminado)
        {
            for (int i = 0; i < listaVistas.Count; i++)
            {
                if (listaVistas[i].tabla.Contains("Balances"))
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
                tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
                foreach (MenuDocumentacion item in listaVistas)
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

        private void ControlDetalleTerminadoIndice(int detalleTerminado)
        {
            for (int i = 0; i < listaVistas.Count; i++)
            {
                if (listaVistas[i].tabla.Contains("Carpetas"))
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
                tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
                foreach (MenuDocumentacion item in listaVistas)
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

        private void ControlDetalleTerminadoSubmenuPrograma(int detalleTerminado)
        {
            for (int i = 0; i < listaVistas.Count; i++)
            {
                if (listaVistas[i].tabla.Contains("Programas"))
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
                tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
                foreach (MenuDocumentacion item in listaVistas)
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

        private void ControlDetalleTerminadoSubMenuIndice(int detalleTerminado)
        {
            for (int i = 0; i < listaVistas.Count; i++)
            {
                if (listaVistas[i].tabla.Contains("Indices"))
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
                tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
                foreach (MenuDocumentacion item in listaVistas)
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

        private void ControlDetalleTerminadoSubmenuCuestionarios(int detalleTerminado)
        {
            for (int i=0;i<listaVistas.Count;i++)
            {
                if (listaVistas[i].tabla.Contains("Cuestionarios"))
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
                tokenEnvioDocumentacion = currentEntidad.ViewDisplay + "Documentacion";//Se personaliza segun el destinatario
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioDocumentacion, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<MenuDocumentacion>(MenuDocumentacion.GetAll());
                foreach (MenuDocumentacion item in listaVistas)
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
        private void enviarMensajeDatos()
        {
            //Creando el mensaje de transmision del usuario
            EncargosDatosMsj elemento = new EncargosDatosMsj(); ;
            elemento.usuarioModelo = currentUsuarioModelo;
            elemento.encargoModelo = currentEncargo;
            switch (tokenEnvioDocumentacion)
            {
                case "BalancesDocumentacion":
                    elemento.tokenRespuesta = tokenRecepcionSubMenu;
                    break;
                case "Catalogo cuentasDocumentacion":
                    elemento.tokenRespuesta = string.Empty;
                    break;
                case "CuestionariosDocumentacion":
                    elemento.tokenRespuesta = tokenRecepcionCuestionarios;
                    break;
                case "CartasDocumentacion":
                    elemento.tokenRespuesta = tokenRecepcionRepositorio;
                    break;
                case "CarpetasDocumentacion":
                    elemento.tokenRespuesta = tokenRecepcionRepositorio;
                    break;
                case "ProgramasDocumentacion":
                    elemento.tokenRespuesta = tokenRecepcionProgramas;
                    break;
                case "MemorandosDocumentacion":
                    elemento.tokenRespuesta = tokenRecepcionRepositorio;
                    break;
                case "Informe auditoría":
                    elemento.tokenRespuesta = tokenRecepcionRepositorio;
                    break;
            }
        
            //elemento.idEncargo = currentEncargo.idencargo;
            //elemento.idUsuarioModelo = currentUsuario.idusuario;
            Messenger.Default.Send(elemento, tokenEnvioDocumentacion);
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