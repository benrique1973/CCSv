using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.DetalleDocumentoCrudMensaje;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Plantilla;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.Departamento
{
    public sealed class DetalleDocumentosViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static int comando = 0;
        private string tokenEnvio = "DetalleDocumentoModelo";
        private string tokenRecepcionPrincipal = "CatalogoDatos";
        private string tokenRecepcionCierre = "CrudDetalleDocumentoCerrada";
        private DialogCoordinator dlg;
        private static bool activarVentanaConsulta = true;

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #region tokenRecepcionHijo

        private string _tokenRecepcionHijo;
        private string tokenRecepcionHijo
        {
            get { return _tokenRecepcionHijo; }
            set { _tokenRecepcionHijo = value; }
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

        #endregion

        #region ViewModel Properties publicas

        #region Lista entidades

        public const string listaPropertyName = "Lista";


        private ObservableCollection<DetalleDocumentoModelo>_lista;

        public ObservableCollection<DetalleDocumentoModelo> Lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : listaDocumentos

        /// <summary>
        /// The <see cref="listaDocumentos" /> property's name.
        /// </summary>
        public const string listaDocumentosPropertyName = "listaDocumentos";

        private List<DocumentoModelo> _listaDocumentos;

        public List<DocumentoModelo> listaDocumentos
        {
            get
            {
                return _listaDocumentos;
            }

            set
            {
                if (_listaDocumentos == value) return;

                _listaDocumentos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDocumentosPropertyName);
            }
        }

        #endregion

        #region descripciond de detalle documento

        public const string descripcionddPropertyName = "descripciondd";

        private string _descripciondd = string.Empty;

        public string descripciondd
        {
            get
            {
                return _descripciondd;
            }

            set
            {
                if (_descripciondd == value)
                {
                    return;
                }

                _descripciondd = value;
                RaisePropertyChanged(descripcionddPropertyName);
            }
        }


        #endregion

        #region descripciond de nombreDocumento

        public const string nombreDocumentoPropertyName = "nombreDocumento";

        private string _nombreDocumento = string.Empty;

        public string nombreDocumento
        {
            get
            {
                return _nombreDocumento;
            }

            set
            {
                if (_nombreDocumento == value)
                {
                    return;
                }

                _nombreDocumento = value;
                RaisePropertyChanged(nombreDocumentoPropertyName);
            }
        }

        #endregion

        #region fechacreadoplantilla

        public const string fechacreadoplantillaPropertyName = "fechacreadoplantilla";

        private DateTime _fechacreadoplantilla = DateTime.Now;

        public DateTime fechacreadoplantilla
        {
            get
            {
                return _fechacreadoplantilla;
            }

            set
            {
                if (_fechacreadoplantilla == value)
                {
                    return;
                }

                _fechacreadoplantilla = value;
                RaisePropertyChanged(fechacreadoplantillaPropertyName);
            }
        }

        #endregion

        #region  Primary key

        /// <summary>
        /// The <see cref="iddd" /> property's name.
        /// </summary>
        public const string idddPropertyName = "iddd";

        private int _iddd = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int iddddepartamento
        {
            get
            {
                return _iddd;
            }

            set
            {
                if (_iddd == value)
                {
                    return;
                }

                _iddd = value;
                RaisePropertyChanged(idddPropertyName);
            }
        }

        #endregion

        #region sistemadd

        /// <summary>
        /// The <see cref="sistemadd" /> property's name.
        /// </summary>

        public const string sistemaddPropertyName = "sistemadd";

        private bool _sistemadd = false;

        /// <summary>
        /// Sets and gets the sistemaddmc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool sistemadd
        {
            get
            {
                return _sistemadd;
            }

            set
            {
                if (_sistemadd == value)
                {
                    return;
                }

                _sistemadd = value;
                RaisePropertyChanged(sistemaddPropertyName);
            }
        }

        #endregion

        #region estadodd

        public const string estadoddPropertyName = "estadodd";

        private string _estadodd = string.Empty;

        public string estadodd
        {
            get
            {
                return _estadodd;
            }

            set
            {
                if (_estadodd == value)
                {
                    return;
                }

                _estadodd = value;
                RaisePropertyChanged(estadoddPropertyName);
            }
        }
        #endregion

        #region Entidddad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleDocumentoModelo _currentEntidad;

        public DetalleDocumentoModelo currentEntidad
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

        #endregion


        #endregion

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand<DetalleDocumentoModelo> SelectionChangedCommand { get; set; }

        #endregion
        #region MainModel

        private MainModel _mainModel = null;

        public MainModel MainModel
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

        #region ViewModel Public Methods

        #region Constructores

        public DetalleDocumentosViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionHijo = "";
            _tokenRecepcionPadre = "Detalle de clase de documentos" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));
            Lista = new ObservableCollection<DetalleDocumentoModelo>(DetalleDocumentoModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<bool>(this, tokenRecepcionCierre,(controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));

            MainModel = new MainModel();
            //Nuevo();
        }

        private void ControlUsuarioMensaje(UsuarioMensaje usuarioMensaje)
        {
            currentUsuario = usuarioMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = usuarioMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
        }

        #endregion

        public void enviarDatos()
        {
            //Se crea el mensaje
            DetalleDocumentoCrudMensaje elemento = new DetalleDocumentoCrudMensaje();
            elemento.detalleDocumentoModelo = currentEntidad;
            elemento.listadetalleDocumento = Lista;
            elemento.comandoCrud = comando;
            elemento.usuarioModeloValidado =currentUsuarioModelo ;
            Messenger.Default.Send(elemento, tokenEnvio);
        }

        #region Receptor de mensajes
        private void ControlVentanaMensaje(bool controlVentanaCrearMensaje)
        {
            if(controlVentanaCrearMensaje)
            { 
            //Para controlar la ventana abierta
            MainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    currentEntidad = null;
                    actualizarLista();
                    break;
                case 2:
                    actualizarLista();
                    break;
                case 3:
                    activarVentanaConsulta = true;
                    break;
                default:
                    break;
            }
            comando = 0;
            }
        }
        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            MainModel.TypeName = "DetalleDocumentoCrearView";
            currentEntidad = new DetalleDocumentoModelo();
            comando = 1;
            enviarDatos();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {

                    MainModel.TypeName = "DetalleDocumentoEditarView";
                    comando = 2;
                    enviarDatos();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
        }
        public async void Consultar()
        {
            if (!(currentEntidad == null))
            {
                if (activarVentanaConsulta)
                {

                        MainModel.TypeName = "DetalleDocumentoConsultarView";
                        comando = 3;
                        enviarDatos();
                        activarVentanaConsulta = false;
                }
                else
                {
                    //La ventana de consulta esta activa
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }


        public async void ConsultarDobleClick()
        {
            if (!(currentEntidad == null))
            {
                if (activarVentanaConsulta)
                {

                        MainModel.TypeName = "DetalleDocumentoConsultarView";
                        comando = 3;
                        enviarDatos();
                        activarVentanaConsulta = false;

                }
                else
                {
                    //La ventana de consulta esta activa
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }
        public async void Borrar()
        {
            if (!(currentEntidad == null))
            {
                    //Unicamente realiza un borrado lógico cambiando el estadodd a B y actualizando el listado
                    if (DetalleDocumentoModelo.DeleteBorradoLogico(currentEntidad.iddd, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        Lista.Remove(currentEntidad);
                        currentEntidad = null;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sidddo posible eliminar el registro", "");
                    }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }

        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.iddd == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripciondd);
        }

        #region Verificaciones

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        #endregion
        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanDelete);
            BorrarCommand = new RelayCommand(Borrar, CanDelete);
            ConsultarCommand = new RelayCommand(Consultar, CanDelete);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            SelectionChangedCommand = new RelayCommand<DetalleDocumentoModelo>(entidddad =>
            {
                if (entidddad == null) return;
                currentEntidad = entidddad;
            });
        }

        #endregion


        #region Lanzado de  comando

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            accesibilidadWindow = false;
        }

        private void ControlVentanaMensaje(int controllerProgramaViewMensaje)
        {
            throw new NotImplementedException();
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            accesibilidadWindow = true;
        }

        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        private void ControlCatalogoDatos(UsuarioMensaje catalogoDatos)
        {
            usuarioModelo = catalogoDatos.usuarioModeloMensaje;
            actualizarLista();
            accesibilidadWindow = true;
            inicializacionTerminada();
        }
        #endregion Fin de comando

        #region actualizaciones

        private void actualizarLista()
        {
            //borrarTemporales();//Para borrar cualquier  archivo creado
            try
            {
                Lista = new ObservableCollection<DetalleDocumentoModelo>(DetalleDocumentoModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    Lista = new ObservableCollection<DetalleDocumentoModelo>();
                }
            }
        }


        #endregion
    }
}

