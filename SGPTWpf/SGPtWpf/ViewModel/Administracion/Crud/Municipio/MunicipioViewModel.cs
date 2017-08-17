using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Municipio;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.Municipio
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class MunicipioViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int ventanas = 0;
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

        #region ViewModel Properties : Lista
        /// <summary>
        /// The <see cref="Lista" /> property's name.
        /// </summary>
        public const string ListaPropertyName = "Lista";

        private ObservableCollection<MunicipioModelo> _Lista;

        public ObservableCollection<MunicipioModelo> Lista
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

        #region ViewModel Property : ListaPais

        /// <summary>
        /// The <see cref="ListaPais" /> property's name.
        /// </summary>
        public const string ListaPaisPropertyName = "ListaPais";

        private List<PaisModelo> _ListaPais;

        public List<PaisModelo> ListaPais
        {
            get
            {
                return _ListaPais;
            }

            set
            {
                if (_ListaPais == value) return;

                _ListaPais = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPaisPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : ListaDepartamento

        /// <summary>
        /// The <see cref="ListaDepartamento" /> property's name.
        /// </summary>
        public const string ListaDepartamentoPropertyName = "ListaDepartamento";

        private List<DepartamentoModelo> _ListaDepartamento;

        public List<DepartamentoModelo> ListaDepartamento
        {
            get
            {
                return _ListaDepartamento;
            }

            set
            {
                if (_ListaDepartamento == value) return;

                _ListaDepartamento = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaDepartamentoPropertyName);
            }
        }

        #endregion

        #region Descripcion de cuentas

        /// <summary>
        /// The <see cref="nombremunicipio" /> property's name.
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

        #region Descripcion de nombrePais

        public const string nombrePaisPropertyName = "nombrePais";

        private string _nombrePais = string.Empty;

        public string nombrePais
        {
            get
            {
                return _nombrePais;
            }

            set
            {
                if (_nombrePais == value)
                {
                    return;
                }

                _nombrePais = value;
                RaisePropertyChanged(nombrePaisPropertyName);
            }
        }

        #endregion

        #region Descripcion de nombreDepartamento

        public const string nombreDepartamentoPropertyName = "nombreDepartamento";

        private string _nombreDepartamento = string.Empty;

        public string nombreDepartamento
        {
            get
            {
                return _nombreDepartamento;
            }

            set
            {
                if (_nombreDepartamento == value)
                {
                    return;
                }

                _nombreDepartamento = value;
                RaisePropertyChanged(nombreDepartamentoPropertyName);
            }
        }

        #endregion

        #region  Primary key

         public const string idPropertyName = "id";

        private int _id = 0;

        public int idmunicipio
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

        #region  Foreing key

        /// <summary>
        /// The <see cref="idDepartamento" /> property's name.
        /// </summary>
        public const string idDepartamentoPropertyName = "idDepartamento";

        private int _idDepartamento = 0;

        public int idDepartamento
        {
            get
            {
                return _idDepartamento;
            }

            set
            {
                if (_idDepartamento == value)
                {
                    return;
                }

                _idDepartamento = value;
                RaisePropertyChanged(idDepartamentoPropertyName);
            }
        }

        #endregion

        #region  Foreing key Pais

        /// <summary>
        /// The <see cref="idPais" /> property's name.
        /// </summary>
        public const string idPaisPropertyName = "idPais";

        private int _idPais = 0;


        public int idPais
        {
            get
            {
                return _idPais;
            }

            set
            {
                if (_idPais == value)
                {
                    return;
                }

                _idPais = value;
                RaisePropertyChanged(idPaisPropertyName);
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

        private MunicipioModelo _currentEntidad;

        public MunicipioModelo currentEntidad
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

        public RelayCommand<MunicipioModelo> SelectionChangedCommand { get; set; }

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

        // Metodo adicionado

        public MunicipioViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionHijo = "";
            _tokenRecepcionPadre = "Municipos por depto" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));

            Lista = new ObservableCollection<MunicipioModelo>(MunicipioModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<VentanaViewMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            MainModel = new MainModel();
            //Nuevo();
        }

        #endregion

        #region Envio mensajes
        public void enviarMensaje()
        {
            //Se crea el mensaje
            VentanaViewMensaje apertura = new VentanaViewMensaje();
            apertura.mensaje = ventanas;//Guardo el mensaje
            Messenger.Default.Send<VentanaViewMensaje>(apertura);
            ventanas = ventanas + 1;
            enviarMensajeInhabilitar();
        }
        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            if ((ventanas == 0))
            {
                inhabilitar.mensaje = true;
            }
            else
            {
                inhabilitar.mensaje = false;
            }
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarElemento()
        {
            //Se crea el mensaje
            MunicipioElementoMensaje elemento = new MunicipioElementoMensaje();
            if ((ventanas == 0))
            {
                elemento.elementoMensaje = currentEntidad;
            }
            else
            {
                elemento.elementoMensaje = null;
            }
            Messenger.Default.Send<MunicipioElementoMensaje>(elemento);
        }
        public void enviarLista()
        {
            //Se crea el mensaje
            MunicipioListaMensaje listaEnviada = new MunicipioListaMensaje();
            if ((ventanas == 0))
            {
                listaEnviada.listaMensaje = Lista;
            }
            else
            {
                listaEnviada.listaMensaje = null;
            }
            Messenger.Default.Send<MunicipioListaMensaje>(listaEnviada);
        }
        #endregion

        #region Receptor de mensajes
        private void ControlVentanaMensaje(VentanaViewMensaje controlVentanaCrearMensaje)
        {
            ventanas = ventanas + controlVentanaCrearMensaje.mensaje;
            if (ventanas < 0)
            { ventanas = 0; }//Para mantener el valor en cero y no en menos
            enviarMensajeInhabilitar();
            //TypeName = null;
            MainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    currentEntidad = null;
                    break;
                case 2:
                    break;
                case 3:
                    activarVentanaConsulta = true;
                    break;
                default:
                    break;
            }
            comando = 0;

        }
        #endregion

        #region Implementacion de comandos
        public async void Nuevo()
        {
            if (ventanas == 0)
            {

                MainModel.TypeName = "MunicipioCrearView";
                currentEntidad = new MunicipioModelo();
                enviarElemento();
                enviarLista();
                enviarMensaje();
                comando = 1;
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
            }
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                if (ventanas == 0)
                {

                    MainModel.TypeName = "MunicipioEditarView";
                    enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                    enviarLista();
                    enviarMensaje();
                    comando = 2;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                }
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
                    if (ventanas == 0)
                    {
                        MainModel.TypeName = "MunicipioConsultarView";
                        enviarElemento();
                        enviarMensaje();
                        comando = 3;
                        activarVentanaConsulta = false;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                    }
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
                    if (ventanas == 0)
                    {
                        MainModel.TypeName = "MunicipioConsultarView";
                        enviarElemento();
                        enviarMensaje();
                        comando = 3;
                        activarVentanaConsulta = false;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                    }
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
                if (ventanas == 0)
                {
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (MunicipioModelo.DeleteBorradoLogico(currentEntidad.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        Lista.Remove(currentEntidad);
                        currentEntidad = null;
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                }
                else
                {

                    await dlg.ShowMessageAsync(this, "No es posible usar la función, tiene ventanas abiertas", "");
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

        public void Actualizar(ObservableCollection<MunicipioModelo> listaEntidad)
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
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            SelectionChangedCommand = new RelayCommand<MunicipioModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
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
                Lista = new ObservableCollection<MunicipioModelo>(MunicipioModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    Lista = new ObservableCollection<MunicipioModelo>();
                }
            }
        }


        #endregion
    }
}

