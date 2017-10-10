using CapaDatos;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.MarcasEstandares;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;

namespace SGPTWpf.ViewModel.Herramientas
{

    public sealed class MarcasEstandaresViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private string tokenRecepcionPrincipal = "Marcas" + "Herramientas";
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

        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int numeroProcesoCrud = 0;

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

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<MarcasEstandaresModelo> _lista;

        public ObservableCollection<MarcasEstandaresModelo> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion


        #region significadoMe

        public const string significadoMePropertyName = "significadoMe";

        private string _significadoMe = string.Empty;

        public string significadoMe
        {
            get
            {
                return _significadoMe;
            }

            set
            {
                if (_significadoMe == value)
                {
                    return;
                }

                _significadoMe = value;
                RaisePropertyChanged(significadoMePropertyName);
            }
        }

        #endregion

        #region inicialesusuario

        public const string inicialesusuarioPropertyName = "inicialesusuario";

        private string _inicialesusuario = string.Empty;

        public string inicialesusuario
        {
            get
            {
                return _inicialesusuario;
            }

            set
            {
                if (_inicialesusuario == value)
                {
                    return;
                }

                _inicialesusuario = value;
                RaisePropertyChanged(inicialesusuarioPropertyName);
            }
        }

        #endregion

        #region  Primary key


        public const string idPropertyName = "id";

        private int _id = 0;

        public int idrol
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

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

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

        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

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

        public const string currentEntidadPropertyName = "currentEntidad";

        private MarcasEstandaresModelo _currentEntidad;

        public MarcasEstandaresModelo currentEntidad
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


        #region  Usuario key


        public const string idusuarioPropertyName = "idusuario";

        private int _idusuario = 0;

        public int idusuario
        {
            get
            {
                return _idusuario;
            }

            set
            {
                if (_idusuario == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(idusuarioPropertyName);
            }
        }

        #endregion

        #region Simbolo de marca

        public const string marcamePropertyName = "marcame";

        private string _marcame = string.Empty;

        public string marcame
        {
            get
            {
                return _marcame;
            }

            set
            {
                if (_marcame == value)
                {
                    return;
                }

                _marcame = value;
                RaisePropertyChanged(marcamePropertyName);
            }
        }

        #endregion


        #region Fecha de creación

        public const string fechahoymePropertyName = "fechahoyme";

        private string _fechahoyme = string.Empty;

        public string fechahoyme
        {
            get
            {
                return _fechahoyme;
            }

            set
            {
                if (_fechahoyme == value)
                {
                    return;
                }

                _fechahoyme = value;
                RaisePropertyChanged(fechahoymePropertyName);
            }
        }

        #endregion

        #endregion



        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand PermisosCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand<MarcasEstandaresModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region MarcasEstandaresMainModel

        private MainModel _mainModel = null;

        public MainModel MarcasEstandaresMainModel
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

        #endregion

        #region ViewModel Public Methods

        #region Constructores

        // Metodo adicionado
        public MarcasEstandaresViewModel(string origen)//Documentacion/Carpetas
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
            //lista = new ObservableCollection<MarcasEstandaresModelo>(MarcasEstandaresModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            //Messenger.Default.Register<VentanaViewMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal,(herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
            Messenger.Default.Register<MarcasEstandaresCierreMensaje>(this, (marcasEstandaresCierreMensaje) => ControlMarcasEstandaresCierreMensaje(marcasEstandaresCierreMensaje));

            MarcasEstandaresMainModel = new MainModel();
        }

        #endregion

        #region Envio mensajes

        public void enviarDatosMarcaEstandar()
        {
            //Se crea el mensaje
            MarcasEstandaresMensaje elemento = new MarcasEstandaresMensaje();
            elemento.elementoMensaje = currentEntidad;
            elemento.listaMensaje = lista;
            elemento.numeroProcesoCrudEnviado = numeroProcesoCrud;
            elemento.comandoCrud = comando;
            numeroProcesoCrud = numeroProcesoCrud + 1;//Se incrementa para  proximo envio
            Messenger.Default.Send(elemento);
        }

        #endregion

        #region Receptor de mensajes

        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
        {
            currentUsuario = herramientaUsuarioValidadoMensaje.usuarioMensaje;
            //Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
            actualizarLista();
        }

        private async void ControlMarcasEstandaresCierreMensaje(MarcasEstandaresCierreMensaje marcasEstandaresCierreMensaje)
        {
            //TypeName = null;
            MarcasEstandaresMainModel.TypeName = null;
            if (marcasEstandaresCierreMensaje.numeroProcesoCrud == numeroProcesoCrud)
            {
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
                        //activarVentanaConsulta = true;
                        break;
                    default:
                        break;
                }
                comando = 0;
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Error en cuenta de mensajes de cierre", "");
            }

        }
        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            MarcasEstandaresMainModel.TypeName = "MarcasEstandaresCrearView";
            currentEntidad = new MarcasEstandaresModelo();
            currentEntidad.idMe = 0;
            currentEntidad.fechahoyme = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            currentEntidad.fechahoymeDate = DateTime.Now;
            currentEntidad.idusuario = currentUsuario.idusuario;
            currentEntidad.marcame = "";
            currentEntidad.significadoMe = "";
            currentEntidad.sistema = false;
            currentEntidad.tamaniotipografiame = 11;
            currentEntidad.tipografiame = "";
            currentEntidad.estado = "A";
            currentEntidad.usuario = currentUsuario;
            comando = 1;
            enviarDatosMarcaEstandar();

        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                    MarcasEstandaresMainModel.TypeName = "MarcasEstandaresEditarView";
                    comando = 2;
                    currentEntidad.usuario= currentUsuario;
                    enviarDatosMarcaEstandar();//Debe ir antes, porque evalua si la ventana es cero para enviarse
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
                        MarcasEstandaresMainModel.TypeName = "MarcasEstandaresConsultarView";
                        comando = 3;
                        enviarDatosMarcaEstandar();

                        //activarVentanaConsulta = false;

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

                        MarcasEstandaresMainModel.TypeName = "MarcasEstandaresConsultarView";
                        comando = 3;
                        enviarDatosMarcaEstandar();

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
                    //Se realiza un borrado completo
                    if (MarcasEstandaresModelo.Delete(currentEntidad.idMe, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        lista.Remove(currentEntidad);
                        currentEntidad = null;
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
            return !(currentEntidad.idMe == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.significadoMe);
        }

        #region Verificaciones

        private void actualizarLista()
        {
            try
            {
                    lista = new ObservableCollection<MarcasEstandaresModelo>(MarcasEstandaresModelo.GetAll());
           }
            catch (Exception )
            {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
            }
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
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            SelectionChangedCommand = new RelayCommand<MarcasEstandaresModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion

    }
}