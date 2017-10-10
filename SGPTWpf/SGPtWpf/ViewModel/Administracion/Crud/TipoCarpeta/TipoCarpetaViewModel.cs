using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.TipoCarpeta;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.TipoCarpeta
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class TipoCarpetaViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static TipoCarpetaViewModel tipoCarpetaViewModel;
        private int comando = 0;
        private DialogCoordinator dlg;


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

        #region Visibilidad de  botones

        #region visibilidadMCrear

        public const string visibilidadMCrearPropertyName = "visibilidadMCrear";

        private Visibility _visibilidadMCrear = Visibility.Collapsed;

        public Visibility visibilidadMCrear
        {
            get
            {
                return _visibilidadMCrear;
            }

            set
            {
                if (_visibilidadMCrear == value)
                {
                    return;
                }

                _visibilidadMCrear = value;
                RaisePropertyChanged(visibilidadMCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadMEditar

        public const string visibilidadMEditarPropertyName = "visibilidadMEditar";

        private Visibility _visibilidadMEditar = Visibility.Collapsed;

        public Visibility visibilidadMEditar
        {
            get
            {
                return _visibilidadMEditar;
            }

            set
            {
                if (_visibilidadMEditar == value)
                {
                    return;
                }

                _visibilidadMEditar = value;
                RaisePropertyChanged(visibilidadMEditarPropertyName);
            }
        }

        #endregion

        #region visibilidadMReferenciar

        public const string visibilidadMReferenciarPropertyName = "visibilidadMReferenciar";

        private Visibility _visibilidadMReferenciar = Visibility.Collapsed;

        public Visibility visibilidadMReferenciar
        {
            get
            {
                return _visibilidadMReferenciar;
            }

            set
            {
                if (_visibilidadMReferenciar == value)
                {
                    return;
                }

                _visibilidadMReferenciar = value;
                RaisePropertyChanged(visibilidadMReferenciarPropertyName);
            }
        }

        #endregion

        #region visibilidadMCerrar

        public const string visibilidadMCerrarPropertyName = "visibilidadMCerrar";

        private Visibility _visibilidadMCerrar = Visibility.Collapsed;

        public Visibility visibilidadMCerrar
        {
            get
            {
                return _visibilidadMCerrar;
            }

            set
            {
                if (_visibilidadMCerrar == value)
                {
                    return;
                }

                _visibilidadMCerrar = value;
                RaisePropertyChanged(visibilidadMCerrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMSupervisar

        public const string visibilidadMSupervisarPropertyName = "visibilidadMSupervisar";

        private Visibility _visibilidadMSupervisar = Visibility.Collapsed;

        public Visibility visibilidadMSupervisar
        {
            get
            {
                return _visibilidadMSupervisar;
            }

            set
            {
                if (_visibilidadMSupervisar == value)
                {
                    return;
                }

                _visibilidadMSupervisar = value;
                RaisePropertyChanged(visibilidadMSupervisarPropertyName);
            }
        }

        #endregion

        #region visibilidadMAprobar

        public const string visibilidadMAprobarPropertyName = "visibilidadMAprobar";

        private Visibility _visibilidadMAprobar = Visibility.Collapsed;

        public Visibility visibilidadMAprobar
        {
            get
            {
                return _visibilidadMAprobar;
            }

            set
            {
                if (_visibilidadMAprobar == value)
                {
                    return;
                }

                _visibilidadMAprobar = value;
                RaisePropertyChanged(visibilidadMAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadMBorrar

        public const string visibilidadMBorrarPropertyName = "visibilidadMBorrar";

        private Visibility _visibilidadMBorrar = Visibility.Collapsed;

        public Visibility visibilidadMBorrar
        {
            get
            {
                return _visibilidadMBorrar;
            }

            set
            {
                if (_visibilidadMBorrar == value)
                {
                    return;
                }

                _visibilidadMBorrar = value;
                RaisePropertyChanged(visibilidadMBorrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMConsulta

        public const string visibilidadMConsultaPropertyName = "visibilidadMConsulta";

        private Visibility _visibilidadMConsulta = Visibility.Collapsed;

        public Visibility visibilidadMConsulta
        {
            get
            {
                return _visibilidadMConsulta;
            }

            set
            {
                if (_visibilidadMConsulta == value)
                {
                    return;
                }

                _visibilidadMConsulta = value;
                RaisePropertyChanged(visibilidadMConsultaPropertyName);
            }
        }

        #endregion

        #region visibilidadMDetalle

        public const string visibilidadMDetallePropertyName = "visibilidadMDetalle";

        private Visibility _visibilidadMDetalle = Visibility.Collapsed;

        public Visibility visibilidadMDetalle
        {
            get
            {
                return _visibilidadMDetalle;
            }

            set
            {
                if (_visibilidadMDetalle == value)
                {
                    return;
                }

                _visibilidadMDetalle = value;
                RaisePropertyChanged(visibilidadMDetallePropertyName);
            }
        }

        #endregion

        #region visibilidadMVista

        public const string visibilidadMVistaPropertyName = "visibilidadMVista";

        private Visibility _visibilidadMVista = Visibility.Collapsed;

        public Visibility visibilidadMVista
        {
            get
            {
                return _visibilidadMVista;
            }

            set
            {
                if (_visibilidadMVista == value)
                {
                    return;
                }

                _visibilidadMVista = value;
                RaisePropertyChanged(visibilidadMVistaPropertyName);
            }
        }

        #endregion

        #region visibilidadMRegresar

        public const string visibilidadMRegresarPropertyName = "visibilidadMRegresar";

        private Visibility _visibilidadMRegresar = Visibility.Hidden;

        public Visibility visibilidadMRegresar
        {
            get
            {
                return _visibilidadMRegresar;
            }

            set
            {
                if (_visibilidadMRegresar == value)
                {
                    return;
                }

                _visibilidadMRegresar = value;
                RaisePropertyChanged(visibilidadMRegresarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImportar

        public const string visibilidadMImportarPropertyName = "visibilidadMImportar";

        private Visibility _visibilidadMImportar = Visibility.Collapsed;

        public Visibility visibilidadMImportar
        {
            get
            {
                return _visibilidadMImportar;
            }

            set
            {
                if (_visibilidadMImportar == value)
                {
                    return;
                }

                _visibilidadMImportar = value;
                RaisePropertyChanged(visibilidadMImportarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImprimir

        public const string visibilidadMImprimirPropertyName = "visibilidadMImprimir";

        private Visibility _visibilidadMImprimir = Visibility.Hidden;

        public Visibility visibilidadMImprimir
        {
            get
            {
                return _visibilidadMImprimir;
            }

            set
            {
                if (_visibilidadMImprimir == value)
                {
                    return;
                }

                _visibilidadMImprimir = value;
                RaisePropertyChanged(visibilidadMImprimirPropertyName);
            }
        }

        #endregion

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion
        #endregion

        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista
        /// <summary>
        /// The <see cref="Lista" /> property's name.
        /// </summary>
        public const string ListaPropertyName = "Lista";

        private ObservableCollection<TipoCarpetaModelo> _Lista;

        public ObservableCollection<TipoCarpetaModelo> Lista
        {
            get
            {
                return _Lista;
            }

            set
            {
                if (_Lista == value) return;

                _Lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPropertyName);
            }
        }

        #endregion

        #region Descripcion de cuentas

        /// <summary>
        /// The <see cref="descripciontc" /> property's name.
        /// </summary>
        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

        /// <summary>
        /// Sets and gets the nombremc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(descripcionPropertyName);
            }
        }

        #endregion

        #region  Primary key

        /// <summary>
        /// The <see cref="id" /> property's name.
        /// </summary>
        public const string idPropertyName = "id";

        private int _id = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idtc
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(idPropertyName);
            }
        }

        #endregion

        #region Sistema

        /// <summary>
        /// The <see cref="sistema" /> property's name.
        /// </summary>

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        /// <summary>
        /// Sets and gets the sistemamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool sistema
        {
            get
            {
                return _sistema;
            }

            set
            {
                if (_sistema == value)
                {
                    return;
                }

                _sistema = value;
                RaisePropertyChanged(sistemaPropertyName);
            }
        }

        #endregion

        #region Estado
        /// <summary>
        /// The <see cref="estado" /> property's name.
        /// </summary>
        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        /// <summary>
        /// Sets and gets the estadomc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(estadoPropertyName);
            }
        }
        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        /// <summary>
        /// The <see cref="currentEntidad" /> property's name.
        /// </summary>
        public const string currentEntidadPropertyName = "currentEntidad";

        private TipoCarpetaModelo _currentEntidad;

        public TipoCarpetaModelo currentEntidad
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

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand<TipoCarpetaModelo> SelectionChangedCommand { get; set; }

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

        public TipoCarpetaViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            #region  menu

            _visibilidadMCrear = Visibility.Visible;
            _visibilidadMEditar = Visibility.Visible;
            _visibilidadMBorrar = Visibility.Visible;
            _visibilidadMConsulta = Visibility.Visible;
            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
            _visibilidadMRegresar = Visibility.Collapsed;
            _visibilidadMVista = Visibility.Collapsed;
            _visibilidadMImportar = Visibility.Collapsed;
            _visibilidadMDetalle = Visibility.Collapsed;

            _visibilidadMCerrar = Visibility.Collapsed;
            _visibilidadMSupervisar = Visibility.Collapsed;
            _visibilidadMAprobar = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            #endregion
            dlg = new DialogCoordinator();
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionHijo = "AdministracionCatalogoTipoCarpetas";
            _tokenRecepcionPadre = "Tipos de carpetas" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));

            Lista = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAll());
            RegisterCommands();
            MainModel = new MainModel();
            //Nuevo();
        }

        #endregion

        #region Envio mensajes
        public void enviarMensaje()
        {
            //Se crea el mensaje
            VentanaViewMensaje apertura = new VentanaViewMensaje();
            Messenger.Default.Send<VentanaViewMensaje>(apertura);
        }
        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }

        public void enviarElemento()
        {
            //Se crea el mensaje
                TipoCarpetaElementoMensaje elemento = new TipoCarpetaElementoMensaje();
                elemento.elementoMensaje = currentEntidad;
                Messenger.Default.Send<TipoCarpetaElementoMensaje>(elemento);
        }
        public void enviarLista()
        {
            //Se crea el mensaje
            TipoCarpetaListaMensaje listaEnviada = new TipoCarpetaListaMensaje();
            listaEnviada.listaMensaje = Lista;
            Messenger.Default.Send<TipoCarpetaListaMensaje>(listaEnviada);
        }
        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            //TypeName = null;
            MainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    comando = 0;
                    break;
                case 2:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    comando = 0;
                    break;
                case 3:
                    //EncargoProgramasMainModel.TypeName = null;
                    comando = 0;
                    break;
                case 4:
                    //caso de vista de programa
                    //EncargoProgramasMainModel.TypeName = null;
                    comando = 0;
                    break;
                case 5://Programa vista
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    accesibilidadWindow = true;
                    comando = 0;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                case 7:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                case 8:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                case 9:
                    //EncargoProgramasMainModel.TypeName = null;
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                case 10:
                    //EncargoProgramasMainModel.TypeName = null;
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                default:
                    break;
            }
            finComando();
        }
        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            MainModel.TypeName = "TipoCarpetaCrearView";
            currentEntidad = new TipoCarpetaModelo();
            enviarElemento();
            enviarLista();
            enviarMensaje();
            comando = 1;
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                    iniciarComando();
                    MainModel.TypeName = "TipoCarpetaEditarView";
                    enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                    enviarLista();
                    enviarMensaje();
                    comando = 2;
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
                        iniciarComando();
                        MainModel.TypeName = "TipoCarpetaConsultarView";
                        enviarElemento();
                        enviarMensaje();
                        comando = 3;
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
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (TipoCarpetaModelo.DeleteBorradoLogico(currentEntidad.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        currentEntidad = null;
                        actualizarLista();
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
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
            return !(currentEntidad.id == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<TipoCarpetaModelo> listaEntidad)
        {
            Lista = listaEntidad;
        }

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
            DoubleClickCommand = new RelayCommand(Consultar, CanDelete);
            SelectionChangedCommand = new RelayCommand<TipoCarpetaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion


        #region Lanzado de  comando



        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
        }
        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
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
                    if (usuarioModelo.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()) > 0)
                    {
                        #region  permisos asignados

                        permisosrolesusuario permisosAsignados = usuarioModelo.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper());

                        if (permisosAsignados != null)
                        {


                            if (permisosAsignados.crearpru)
                            {
                                _visibilidadMCrear = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMCrear = Visibility.Collapsed;
                            }
                            if (permisosAsignados.editarpru)
                            {
                                _visibilidadMEditar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMEditar = Visibility.Collapsed;
                            }
                            if (permisosAsignados.consultarpru)
                            {
                                _visibilidadMConsulta = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMConsulta = Visibility.Collapsed;
                            }
                            if (permisosAsignados.eliminarpru)
                            {
                                _visibilidadMBorrar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMBorrar = Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                        }
                        #endregion fin de region de permisos
                    }
                    else
                    {
                        MessageBox.Show("Error en opción y la base de datos\nRevise la opción programada");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al identificar los permisos\nRevise la opción programada");
                    #region  menu
                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Collapsed;
                    _visibilidadMImportar = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                }
            }
            else
            {
                #region  menu
                MessageBox.Show("No están definidos los permisos\nRevise los permisos del usuario");
                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Collapsed;
                _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                _visibilidadMRegresar = Visibility.Collapsed;
                _visibilidadMVista = Visibility.Collapsed;
                _visibilidadMImportar = Visibility.Collapsed;
                _visibilidadMDetalle = Visibility.Collapsed;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;
                #endregion
            }

        }
        private void ControlCatalogoDatos(UsuarioMensaje catalogoDatos)
        {
            usuarioModelo = catalogoDatos.usuarioModeloMensaje;
            permisos();
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
                Lista = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    Lista = new ObservableCollection<TipoCarpetaModelo>();
                }
            }
        }



        #endregion

        #region Lanzado de  comando

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            accesibilidadWindow = false;
            enviarMensajeInhabilitar();
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            accesibilidadWindow = true;
            enviarMensajeHabilitar();
        }

        #endregion Fin de comando
    }
}
