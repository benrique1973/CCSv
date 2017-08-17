using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Elemento;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Crud.Elemento
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed class ElementoViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private static int comando = 0;
        private DialogCoordinator dlg;
        private string tokenRecepcionPrincipal = "CatalogoDatos";
        private string tokenRecepcionCierre = "CrudElementoCerrada";

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

        #region edicionActivada

        private bool _edicionActivada;
        private bool edicionActivada
        {
            get { return _edicionActivada; }
            set { _edicionActivada = value; }
        }

        #endregion
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

        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista
        /// <summary>
        /// The <see cref="Lista" /> property's name.
        /// </summary>
        public const string ListaPropertyName = "Lista";

        private ObservableCollection<ElementoModelo> _Lista;

        public ObservableCollection<ElementoModelo> Lista
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
        /// The <see cref="descripcionelementos" /> property's name.
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
        public int idelementos
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

        #region Propiedades : codigoelemento

        public const string codigoelementoPropertyName = "codigoelemento";

        private string _codigoelemento = string.Empty;

        public string codigoelemento
        {
            get
            {
                return _codigoelemento;
            }
            set
            {
                if (_codigoelemento == value)
                {
                    return;
                }
                _codigoelemento = value;
                RaisePropertyChanged(codigoelementoPropertyName);
            }
        }

        #endregion
        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        /// <summary>
        /// The <see cref="currentEntidad" /> property's name.
        /// </summary>
        public const string currentEntidadPropertyName = "currentEntidad";

        private ElementoModelo _currentEntidad;

        public ElementoModelo currentEntidad
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

        public RelayCommand<ElementoModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region lista digitos de Elementos

        public const string listaDigitosElementoModeloPropertyName = "listaDigitosElementoModelo";

        private ObservableCollection<DigitosModelo> _listaDigitosElementoModelo;

        public ObservableCollection<DigitosModelo> listaDigitosElementoModelo
        {
            get
            {
                return _listaDigitosElementoModelo;
            }

            set
            {
                if (_listaDigitosElementoModelo == value) return;

                _listaDigitosElementoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDigitosElementoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentDigitosElementoModelo

        public const string currentDigitosElementoModeloPropertyName = "currentDigitosElementoModelo";

        private DigitosModelo _currentDigitosElementoModelo;

        public DigitosModelo currentDigitosElementoModelo
        {
            get
            {
                return _currentDigitosElementoModelo;
            }

            set
            {
                if (_currentDigitosElementoModelo == value) return;

                _currentDigitosElementoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentDigitosElementoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : digitosElementoModelo

        public const string digitosElementoModeloPropertyName = "digitosElementoModelo";

        private DigitosModelo _digitosElementoModelo;

        public DigitosModelo digitosElementoModelo
        {
            get
            {
                return _digitosElementoModelo;
            }

            set
            {
                if (_digitosElementoModelo == value) return;

                _digitosElementoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(digitosElementoModeloPropertyName);
            }
        }

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
        public ElementoViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _tokenRecepcionHijo = "";
            _tokenRecepcionPadre = "Elementos contables" + "CatalogosViewModel";//Permite captar los mensajes del  menú planificacion
            _accesibilidadWindow = true;
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPadre, (catalogoDatos) => ControlCatalogoDatos(catalogoDatos));
            edicionActivada = false;
            Lista = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());
            listaDigitosElementoModelo = new ObservableCollection<DigitosModelo>(DigitosModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<bool>(this, tokenRecepcionCierre, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));

            MainModel = new MainModel();

            //Nuevo();
        }

        #endregion

        #region Envio mensajes



        public void enviarElemento()
        {
            //Se crea el mensaje
            ElementoElementoMensaje elemento = new ElementoElementoMensaje();
            elemento.elementoMensaje = currentEntidad;
            elemento.comando = comando;
            Messenger.Default.Send(elemento);
        }
        #endregion

        #region Receptor de mensajes

        private void ControlUsuarioMensaje(UsuarioMensaje usuarioMensaje)
        {
            currentUsuario = usuarioMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = usuarioMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
        }
        private void ControlVentanaMensaje(bool controlVentanaCrearMensaje)
        {
            {
                MainModel.TypeName = null;
                switch (comando)
                {
                    case 1:
                        currentEntidad = null;
                        Lista = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());
                        break;
                    case 2:
                        Lista = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());
                        break;
                    case 3:
                        Lista = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());
                        break;
                    default:
                        break;
                }
                comando = 0;
            }
        }
        #endregion

        #region Implementacion de comandos
        public async void Nuevo()
        {
            if (edicionActivada)
            {
                MainModel.TypeName = "ElementoCrearView";
                currentEntidad = new ElementoModelo();
                comando = 1;
                enviarElemento();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Para este catálogo solo se permite la consulta ", "");
            }

        }

        public async void Editar()
        {
            if (edicionActivada)
            {

                if (!(currentEntidad == null))
            {
                    MainModel.TypeName = "ElementoEditarView";
                    comando = 2;
                    enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Para este catálogo solo se permite la consulta ", "");
            }

        }
        public async void Consultar()
        {
            if (!(currentEntidad == null))
            {
                        MainModel.TypeName = "ElementoConsultarView";
                        comando = 3;
                        enviarElemento();
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
                        MainModel.TypeName = "ElementoConsultarView";
                        comando = 3;
                        enviarElemento();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }
        public async void Borrar()
        {
            if(edicionActivada)
            { 

            if (!(currentEntidad == null))
            {
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (ElementoModelo.DeleteBorradoLogico(currentEntidad.id, true))
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
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Para este catálogo solo se permite la consulta ", "");
    }

}

#endregion

public bool CanSave()
        {
            return !(currentEntidad.id == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcion);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<ElementoModelo> listaEntidad)
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
            SelectionChangedCommand = new RelayCommand<ElementoModelo>(entidad =>
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
                Lista = new ObservableCollection<ElementoModelo>(ElementoModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    Lista = new ObservableCollection<ElementoModelo>();
                }
            }
        }


        #endregion
    }
}


