using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;

namespace SGPTWpf.ViewModel.Encargos.Cierre
{
    public sealed class CierreViewModel : ViewModeloBase
    {
        #region propiedades privadas
        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
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

        #region tokenRecepcionCuestionarios

        private string _tokenRecepcionCuestionarios;
        private string tokenRecepcionCuestionarios
        {
            get { return _tokenRecepcionCuestionarios; }
            set { _tokenRecepcionCuestionarios = value; }
        }

        #endregion

        #region tokenRecepcionIndices

        private string _tokenRecepcionIndices;
        private string tokenRecepcionIndices
        {
            get { return _tokenRecepcionIndices; }
            set { _tokenRecepcionIndices = value; }
        }

        #endregion

        #region tokenRecepcionCierreEncargos

        private string _tokenRecepcionCierreEncargos;
        private string tokenRecepcionCierreEncargos
        {
            get { return _tokenRecepcionCierreEncargos; }
            set { _tokenRecepcionCierreEncargos = value; }
        }

        #endregion


        #region tokenRecepcionEncargos
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

        #region tokenEnvioCierre

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
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

        #region tokenRecepcionSubMenuRiesgo
        private string _tokenRecepcionSubMenuRiesgo;
        private string tokenRecepcionSubMenuRiesgo
        {
            get { return _tokenRecepcionSubMenuRiesgo; }
            set { _tokenRecepcionSubMenuRiesgo = value; }
        }
        #endregion

        #endregion

        #region ViewModel Properties

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

        private CierreModelo _currentEntidad;

        public CierreModelo currentEntidad
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

        private ObservableCollection<CierreModelo> _listaVistas;

        public ObservableCollection<CierreModelo> listaVistas
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



        public CierreViewModel()
        {
            _opcionSeleccionada = 0;
            _tokenRecepcionSeleccionCliente = "Cierre"+"ClienteSeleccionado";//Proviene de  EncargosControllerViewModel;
            _tokenEnvioCierre = "CierreDatos";
            _tokenRecepcionEncargos = "Cierre" + "MenuEncargos";//Proviene de  EncargosControllerViewModel;

            //_tokenRecepcionProgramas = "inicioProgramas";
            //_tokenRecepcionCuestionarios = "inicioCuestionarios";

            _tokenRecepcionIndices = "inicioEncargoCierreIndices";
            _tokenRecepcionSubMenuIndice = "CierreDetalleIndiceRegreso";

            _tokenRecepcionCierreEncargos = "EncargoCierreEncargos";
            //_tokenRecepcionSubMenuRiesgo = "PlanDetalleRiesgoRegreso";

            _visibilidadProcesando = Visibility.Collapsed;
            RegistrarComandos();
            _accesibilidadWindow = true;
            _cursorWindow = Cursors.Hand;
            dlg = new DialogCoordinator();
            listaVistas = new ObservableCollection<CierreModelo>(CierreModelo.GetAll());
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionEncargos, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));

            // Messenger.Default.Register<bool>(this, tokenRecepcionProgramas, (controllerInicioProgramaMensaje) => ControllerInicioProgramaMensaje(controllerInicioProgramaMensaje));
            Messenger.Default.Register<int>(this, tokenRecepcionSubMenuIndice, (detalleTerminado) => ControlDetalleTerminadoSubmenuIndice(detalleTerminado));
            //Messenger.Default.Register<int>(this, tokenRecepcionSubMenuRiesgo, (detalleTerminado) => ControltokenRecepcionSubMenuRiesgo(detalleTerminado));

            currentEntidad = new CierreModelo();

        }

        private void ControltokenRecepcionSubMenuRiesgo(int detalleTerminado)
        {
            for (int i = 0; i < listaVistas.Count; i++)
            {
                if (listaVistas[i].tabla.Contains("Riesgo"))
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
                tokenEnvioCierre =currentEntidad.ViewDisplay + "CierreEncargo";
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioCierre, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<CierreModelo>(CierreModelo.GetAll());
                foreach (CierreModelo item in listaVistas)
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

        private void ControlDetalleTerminadoSubmenuIndice(int detalleTerminado)
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
                tokenEnvioCierre =currentEntidad.ViewDisplay + "CierreEncargo";
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioCierre, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<CierreModelo>(CierreModelo.GetAll());
                foreach (CierreModelo item in listaVistas)
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

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenEnvioCierre);
            currentEntidad = new CierreModelo();
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
            accesibilidadTab = mensaje.mensaje;
        }

        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            VerVistaCrudCommand = new RelayCommand(Mostrar);
            DoubleClickCommand = new RelayCommand(dobleClick);
        }

        private void dobleClick()
        {
            //throw new NotImplementedException();
            //Nada es para inactivar la accion
        }

        #endregion

        #region ViewModel Commands
        public RelayCommand VerVistaCrudCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
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
                tokenEnvioCierre =currentEntidad.ViewDisplay + "CierreEncargo";
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvioCierre, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                enviarMensajeDatos();
                //Reinicializando las vistas
                listaVistas = new ObservableCollection<CierreModelo>(CierreModelo.GetAll());
                foreach (CierreModelo item in listaVistas)
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
            //elemento.idEncargo = currentEncargo.idencargo;
            //elemento.idUsuarioModelo = currentUsuario.idusuario;
            Messenger.Default.Send(elemento, tokenEnvioCierre);
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