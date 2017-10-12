using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Documentos
{
    public sealed class DocumentosViewModel: ViewModeloBase
    {
        private DialogCoordinator dlg;


        #region Propiedades privadas

        #region control de Acceso

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region menuElegido

        private string _menuElegido;
        private string menuElegido
        {
            get { return _menuElegido; }
            set { _menuElegido = value; }
        }

        #endregion


        #region ViewModel Properties : enableMConsulta

        public const string enableMConsultaPropertyName = "enableMConsulta";

        private bool _enableMConsulta = true;

        public bool enableMConsulta
        {
            get
            {
                return _enableMConsulta;
            }

            set
            {
                if (_enableMConsulta == value)
                {
                    return;
                }

                _enableMConsulta = value;
                RaisePropertyChanged(enableMConsultaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : enableMImpresion

        public const string enableMImpresionPropertyName = "enableMImpresion";

        private bool _enableMImpresion = true;

        public bool enableMImpresion
        {
            get
            {
                return _enableMImpresion;
            }

            set
            {
                if (_enableMImpresion == value)
                {
                    return;
                }

                _enableMImpresion = value;
                RaisePropertyChanged(enableMImpresionPropertyName);
            }
        }

        #endregion

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

        #endregion propiedades de acceso

        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion

        #region tokenRecepcionPrincipal
        //Permite  recibir de  EncargosController el cliente  seleccionado
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

        #region tokenRecepcionSeleccionCliente
        //Permite  recibir de  EncargosController el cliente  seleccionado
        private string _tokenRecepcionSeleccionCliente;
        private string tokenRecepcionSeleccionCliente
        {
            get { return _tokenRecepcionSeleccionCliente; }
            set { _tokenRecepcionSeleccionCliente = value; }
        }
        #endregion

        private static int controlVentana = 0;

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

        #region EstiloCarga

        public const string EstiloCargaPropertyName = "EstiloCarga";

        private string _EstiloCarga = string.Empty;

        public string EstiloCarga
        {
            get
            {
                return _EstiloCarga;
            }

            set
            {
                if (_EstiloCarga == value)
                {
                    return;
                }
                _EstiloCarga = value;
                RaisePropertyChanged(EstiloCargaPropertyName);
            }
        }

        #endregion

        #region EstiloConsulta

        public const string EstiloConsultaPropertyName = "EstiloConsulta";

        private string _EstiloConsulta = string.Empty;

        public string EstiloConsulta
        {
            get
            {
                return _EstiloConsulta;
            }

            set
            {
                if (_EstiloConsulta == value)
                {
                    return;
                }
                _EstiloConsulta = value;
                RaisePropertyChanged(EstiloConsultaPropertyName);
            }
        }

        #endregion

        #region EstiloGeneracion

        public const string EstiloGeneracionPropertyName = "EstiloGeneracion";

        private string _EstiloGeneracion = string.Empty;

        public string EstiloGeneracion
        {
            get
            {
                return _EstiloGeneracion;
            }

            set
            {
                if (_EstiloGeneracion == value)
                {
                    return;
                }
                _EstiloGeneracion = value;
                RaisePropertyChanged(EstiloGeneracionPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands


        public RelayCommand CargaCommand { get; set; }
        public RelayCommand ConsultaCommand { get; set; }
        public RelayCommand GeneracionCommand { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }
        public RelayCommand DobleClickCommand { get; set; }

        #endregion


        #region ViewModel Public Methods

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuDocumentos _currentEntidad;

        public MenuDocumentos currentEntidad
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

        private List<MenuDocumentos> _ListaPrincipal;
        public List<MenuDocumentos> ListaPrincipal
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

        public DocumentosViewModel(string origen)
        {
            _accesibilidadWindow = false;
            _enableMConsulta = false;
            _enableMImpresion = false;

            _origenLlamada = origen;
            _menuElegido = "Documentos";

            _tokenRecepcionPrincipal = "Documentos";
            _tokenRecepcionSeleccionCliente = "Documentos" + "ClienteSeleccionado"; //Proviene de  EncargosControllerViewModel;
            _visibilidadCliente = Visibility.Collapsed;
            _nombreEncargo = string.Empty;
            RegisterCommands();
            dlg = new DialogCoordinator();
            estilos();
            ListaPrincipal = new List<MenuDocumentos>(MenuDocumentos.GetAll());
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<EstiloMensaje>(this, (controlEstiloMensaje) => ControlEstiloMensaje(controlEstiloMensaje));
            Messenger.Default.Register<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal,(principalUsuarioValidadoMensaje) => ControlPrincipalUsuarioValidadoMensaje(principalUsuarioValidadoMensaje));
            Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));

        }
        private void ControlEncargoMensaje(EncargoMensaje encargoMensaje)
        {
            if (encargoMensaje.encargoModelo == null)
            {
                currentEncargo = null;
                accesibilidadEncargos = false;
                nombreEncargo = "";
                visibilidadCliente = Visibility.Collapsed;
            }
            else
            {
                currentEncargo = encargoMensaje.encargoModelo;
                accesibilidadEncargos = true;
                nombreEncargo = currentEncargo.razonsocialcliente + "\n" + currentEncargo.descripcionTipoAuditoria + " de " + Convert.ToDateTime(currentEncargo.fechainiperauditencargo).Year;
                visibilidadCliente = Visibility.Visible;
                //enviarMensajeDatos();
            }
            }
        private void enviarMensajeDatos()
        {
            //Creando el mensaje de transmision del usuario
            EncargosDatosMsj elemento = new EncargosDatosMsj(); ;
            elemento.usuarioModelo = usuarioModelo;
            elemento.encargoModelo = currentEncargo;
            Messenger.Default.Send(elemento, tokenEnvio);
        }

        public async System.Threading.Tasks.Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 10,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

        private void permisos()
        {
            if (usuarioModelo.listaPermisos != null)
            {
                try
                {
                    if (usuarioModelo.listaPermisos.Count(x => x.menupru.ToUpper() == origenLlamada.ToUpper()) > 0)
                    {
                        #region  permisos asignados

                        permisosrolesusuario permisosAsignadosConsulta = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == "Consulta".ToUpper()
                        && x.menupru.ToUpper() == menuElegido.ToUpper());

                        permisosrolesusuario permisosAsignadosImpresion = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == "Impresion".ToUpper()
                        && x.menupru.ToUpper() == menuElegido.ToUpper());

                        if (permisosAsignadosConsulta != null)
                        {

                            if (permisosAsignadosConsulta.consultarpru)
                            {
                                enableMConsulta = true;
                            }
                            else
                            {
                                enableMConsulta = false;
                            }
                            if (permisosAsignadosImpresion != null)
                            {

                                if (permisosAsignadosImpresion.exportacionpru)
                                {
                                    enableMImpresion = true;
                                }
                                else
                                {
                                    enableMImpresion = false;
                                }
                            }
                            else
                            {
                                System.Windows.MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                        }
                        #endregion fin de region de permisos
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Error en opción y la base de datos\nRevise la opción programada");
                    }
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Error al identificar los permisos\nRevise la opción programada");
                }
            }
        }

        private void ControlPrincipalUsuarioValidadoMensaje(PrincipalUsuarioValidadoMensaje principalUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = principalUsuarioValidadoMensaje.elementoMensaje;
            usuarioModelo = principalUsuarioValidadoMensaje.usuarioModelo;
            Messenger.Default.Unregister<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal);
            permisos();
            inicializacionTerminada();
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            accesibilidadWindow = true;
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

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            CargaCommand = new RelayCommand(Carga);
            ConsultaCommand = new RelayCommand(Consulta);
            GeneracionCommand = new RelayCommand(Generacion);
            SelectionChangedCommand = new RelayCommand();
            DobleClickCommand = new RelayCommand(Repeticion);
        }
        #endregion

        #region Metodos
        public void Repeticion()
        {
            controlVentana = controlVentana + 1;
        }
        public void Carga()
        {
            currentEntidad = ListaPrincipal[0];
            controlVentana = controlVentana + 1;
           estilos();
            EstiloCarga = "SquareButtonStyle";

            Mostrar();
        }
        public void Consulta()
        {
            currentEntidad = ListaPrincipal[0];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloConsulta = "SquareButtonStyle";

            Mostrar();


        }
        public void Generacion()
        {
            currentEntidad = ListaPrincipal[1];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloGeneracion = "SquareButtonStyle";

            Mostrar();

        }
        private void estilos()
        {
            EstiloCarga = "MetroFlatButtonSG";
            EstiloConsulta = "MetroFlatButtonSG";
            EstiloGeneracion = "MetroFlatButtonSG";
        }
        public void Mostrar()
        {
            if (currentEntidad == null)
            {
            }
            else
            {
                tokenEnvio = currentEntidad.ViewDisplay + "MenuDocumentos";
                tokenRecepcionSeleccionCliente = currentEntidad.ViewDisplay + "ClienteSeleccionado";
                Messenger.Default.Register<ComandoTerminado>(this, tokenEnvio, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                Messenger.Default.Register<EncargoMensaje>(this, tokenRecepcionSeleccionCliente, (encargoMensaje) => ControlEncargoMensaje(encargoMensaje));

                cursorWindow = Cursors.Wait;
                currentEntidad.NavigateExecute();
                //enviarMensajeUsuario();
                if (currentEncargo != null)
                {
                    enviarMensajeDatos();
                }
                ListaPrincipal = new List<MenuDocumentos>(MenuDocumentos.GetAll());
            }
        }

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            //cursorWindow = comandoTerminado.cursorWindow;
            cursorWindow = null;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokenEnvio);
            currentEntidad =new MenuDocumentos();
        }

        public void enviarMensajeUsuario()
        {
            //Creando el mensaje de transmision del usuario
            UsuarioMensaje elemento = new UsuarioMensaje(); ;
            elemento.usuarioMensaje = currentUsuario;
            elemento.usuarioModeloMensaje = usuarioModelo;
            Messenger.Default.Send(elemento, tokenEnvio);
        }

        #endregion
    }
}
