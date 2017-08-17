using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Model.Menus;
using System.Collections.Generic;
using SGPTWpf.Messages.Administracion.Usuario;
using CapaDatos;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Model.Modelo;
using System.Collections.ObjectModel;
using SGPTWpf.SGPtWpf.Messages.Genericos;

namespace SGPTWpf.ViewModel.Herramientas
{
    public sealed class HerramientasViewModel : ViewModeloBase
    {
        private DialogCoordinator dlg;


        #region Propiedades privadas

        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion

        private string tokenRecepcionPrincipal = "Herramientas";

        private string tokenEnvio = "HerramientaDatos";

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

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuHerramienta _currentEntidad;

        public MenuHerramienta currentEntidad
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

        private static int controlVentana = 0;

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

        #region EstiloProgramas

        public const string EstiloProgramasPropertyName = "EstiloProgramas";

        private string _EstiloProgramas = string.Empty;

        public string EstiloProgramas
        {
            get
            {
                return _EstiloProgramas;
            }

            set
            {
                if (_EstiloProgramas == value)
                {
                    return;
                }
                _EstiloProgramas = value;
                RaisePropertyChanged(EstiloProgramasPropertyName);
            }
        }

        #endregion

        #region EstiloCuestionarios

        public const string EstiloCuestionariosPropertyName = "EstiloCuestionarios";

        private string _EstiloCuestionarios = string.Empty;

        public string EstiloCuestionarios
        {
            get
            {
                return _EstiloCuestionarios;
            }

            set
            {
                if (_EstiloCuestionarios == value)
                {
                    return;
                }
                _EstiloCuestionarios = value;
                RaisePropertyChanged(EstiloCuestionariosPropertyName);
            }
        }

        #endregion

        #region EstiloPlantillas

        public const string EstiloPlantillasPropertyName = "EstiloPlantillas";

        private string _EstiloPlantillas = string.Empty;

        public string EstiloPlantillas
        {
            get
            {
                return _EstiloPlantillas;
            }

            set
            {
                if (_EstiloPlantillas == value)
                {
                    return;
                }
                _EstiloPlantillas = value;
                RaisePropertyChanged(EstiloPlantillasPropertyName);
            }
        }

        #endregion

        #region EstiloNormativa

        public const string EstiloNormativaPropertyName = "EstiloNormativa";

        private string _EstiloNormativa = string.Empty;

        public string EstiloNormativa
        {
            get
            {
                return _EstiloNormativa;
            }

            set
            {
                if (_EstiloNormativa == value)
                {
                    return;
                }
                _EstiloNormativa = value;
                RaisePropertyChanged(EstiloNormativaPropertyName);
            }
        }

        #endregion

        #region EstiloIndice

        public const string EstiloIndicePropertyName = "EstiloIndice";

        private string _EstiloIndice = string.Empty;

        public string EstiloIndice
        {
            get
            {
                return _EstiloIndice;
            }

            set
            {
                if (_EstiloIndice == value)
                {
                    return;
                }
                _EstiloIndice = value;
                RaisePropertyChanged(EstiloIndicePropertyName);
            }
        }

        #endregion

        #region EstiloMarcas

        public const string EstiloMarcasPropertyName = "EstiloMarcas";

        private string _EstiloMarcas = string.Empty;

        public string EstiloMarcas
        {
            get
            {
                return _EstiloMarcas;
            }

            set
            {
                if (_EstiloMarcas == value)
                {
                    return;
                }
                _EstiloMarcas = value;
                RaisePropertyChanged(EstiloMarcasPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands


        public RelayCommand ProgramasCommand { get; set; }
        public RelayCommand CuestionariosCommand { get; set; }
        public RelayCommand PlantillasCommand { get; set; }
        public RelayCommand NormativaCommand { get; set; }
        public RelayCommand IndiceCommand { get; set; }
        public RelayCommand MarcasCommand { get; set; }
        public RelayCommand SelectionChangedCommand { get; set; }
        public RelayCommand DobleClickCommand { get; set; }

        #endregion


        #region ViewModel Public Methods


        #region Opciones

        #region ViewModel Properties : ListaPrincipal

        public const string ListaPrincipalPropertyName = "ListaPrincipal";

        private ObservableCollection<MenuHerramienta> _ListaPrincipal;

        public ObservableCollection<MenuHerramienta> ListaPrincipal
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

        #endregion

        #region Constructores


        public HerramientasViewModel()
        {
            RegisterCommands();
            dlg = new DialogCoordinator();
            estilos();
            ListaPrincipal = new ObservableCollection<MenuHerramienta>(MenuHerramienta.GetAll());
            //opcion[0].NavigateExecute();
            Messenger.Default.Register<EstiloMensaje>(this, (controlEstiloMensaje) => ControlEstiloMensaje(controlEstiloMensaje));
            //Recibiendo al usuario que esta en la sesión
            Messenger.Default.Register<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal,(principalUsuarioValidadoMensaje) => ControlPrincipalUsuarioValidadoMensaje(principalUsuarioValidadoMensaje));
            currentEntidad = new MenuHerramienta();
            _accesibilidadWindow = true;
            _cursorWindow = Cursors.Hand;
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

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {

            ProgramasCommand = new RelayCommand(Programas);
            CuestionariosCommand = new RelayCommand(Cuestionarios);
            PlantillasCommand = new RelayCommand(Plantillas);
            NormativaCommand = new RelayCommand(Normativa);
            IndiceCommand = new RelayCommand(Indice);
            MarcasCommand = new RelayCommand(Marcas);
            SelectionChangedCommand = new RelayCommand(prueba);
            DobleClickCommand = new RelayCommand(Repeticion);
        }

        private async void prueba()
        {
            await dlg.ShowMessageAsync(this, "Seleccion comando {}", "");
        }
        #endregion

        #region Metodos
        public async void Repeticion()
        {
            controlVentana = controlVentana + 1;
            await dlg.ShowMessageAsync(this, "Repeticion comando {}", "");

        }
        public void Programas()
        {
            currentEntidad = ListaPrincipal[0];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloProgramas = "SquareButtonStyle"; 

            Mostrar();
        }
        public void Cuestionarios()
        {
            currentEntidad = ListaPrincipal[1];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloCuestionarios = "SquareButtonStyle"; 

            Mostrar();


        }
        public void Plantillas()
        {
            currentEntidad = ListaPrincipal[2];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloPlantillas = "SquareButtonStyle";

            Mostrar();

        }
        public void Normativa()
        {
            currentEntidad = ListaPrincipal[3];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloNormativa = "SquareButtonStyle";

            Mostrar();

        }

        public void Indice()
        {
            currentEntidad = ListaPrincipal[4];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloIndice = "SquareButtonStyle";

            Mostrar();

        }
        public void Marcas()
        {
            currentEntidad = ListaPrincipal[6];
            controlVentana = controlVentana + 1;
            estilos();
            EstiloMarcas = "SquareButtonStyle";

            Mostrar();

        }
        private void estilos()
        {
            EstiloProgramas = "MetroFlatButtonSG";
            EstiloCuestionarios = "MetroFlatButtonSG";
            EstiloPlantillas = "MetroFlatButtonSG";
            EstiloNormativa = "MetroFlatButtonSG";
            EstiloIndice = "MetroFlatButtonSG";
            EstiloMarcas = "MetroFlatButtonSG";
        }
        public void Mostrar()
        {
            if (currentEntidad == null)
            {
            }
            else
            {
                tokenEnvio = currentEntidad.ViewDisplay + "Herramientas";
                currentEntidad.NavigateExecute();
                mandarInicioMensaje();
                enviarHerramientaMensajeUsuario();
                //Actualizacion de listado
                ListaPrincipal = new ObservableCollection<MenuHerramienta>(MenuHerramienta.GetAll());
            }
        }

        public void mandarInicioMensaje()
        {
            HerramientasMensajesInicio elemento = new HerramientasMensajesInicio();
            elemento.inicio = true;
            Messenger.Default.Send(elemento);//Mensaje para reinicializar listas
        }

        public void enviarHerramientaMensajeUsuario()
        {
            //Creando el mensaje de transmision del usuario
            UsuarioMensaje elemento = new UsuarioMensaje(); ;
            elemento.usuarioMensaje = currentUsuario;
            elemento.usuarioModeloMensaje = usuarioModelo;
            Messenger.Default.Send(elemento, tokenEnvio);
        }
        #endregion

        #region Lanzado de  comando

        //private void iniciarComando()
        //{
        //    //cursorWindow = Cursors.Wait;
        //    Mouse.OverrideCursor = Cursors.Wait;
        //    Messenger.Default.Register<int>(this, tokenRecepcionController, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
        //    Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
        //    accesibilidadWindow = false;
        //}

        //private void finComando()
        //{
        //    //cursorWindow = null;
        //    Mouse.OverrideCursor = null;
        //    Messenger.Default.Unregister<int>(this, tokenRecepcionController);
        //    Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
        //    accesibilidadWindow = true;
        //}


        #endregion Fin de comando

    }
}
