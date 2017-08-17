using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using CapaDatos;
using System.Linq;
using System.Windows;
using SGPTWpf.Model.Modelo.Indice;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model;
using SGPTWpf.Messages.Genericos;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas.Indice
{

    public sealed class PlantillaIndiceControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        #region cerradoFinalVentana

        private bool _cerradoFinalVentana;
        private bool cerradoFinalVentana
        {
            get { return _cerradoFinalVentana; }
            set { _cerradoFinalVentana = value; }
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

        #region tokenRecepcion

        private string _tokenRecepcion;
        private string tokenRecepcion
        {
            get { return _tokenRecepcion; }
            set { _tokenRecepcion = value; }
        }

        #endregion

        #region maxDescripcion

        private int _maxDescripcion;
        private int maxDescripcion
        {
            get { return _maxDescripcion; }
            set { _maxDescripcion = value; }
        }

        #endregion

        #region numeroProcesoCrudRecibido

        private int _numeroProcesoCrudRecibido;
        private int numeroProcesoCrudRecibido
        {
            get { return _numeroProcesoCrudRecibido; }
            set { _numeroProcesoCrudRecibido = value; }
        }

        #endregion

        #region origen

        private string _origen;
        private string origen
        {
            get { return _origen; }
            set { _origen = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        public static int Errors { get; set; }//Para controllar los errores de edición

        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : listaEntidad

        public const string listaEntidadPropertyName = "listaEntidad";

        private ObservableCollection<PlantillaIndiceModelo> _listaEntidad;

        public ObservableCollection<PlantillaIndiceModelo> listaEntidad
        {
            get
            {
                return _listaEntidad;
            }
            set
            {
                if (_listaEntidad == value) return;

                _listaEntidad = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }
        #endregion


        #region ViewModel Properties : listaTiposAuditoria

        public const string listaTiposAuditoriaPropertyName = "listaTiposAuditoria";

        private ObservableCollection<TipoAuditoriaModelo> _listaTiposAuditoria;

        public ObservableCollection<TipoAuditoriaModelo> listaTiposAuditoria
        {
            get
            {
                return _listaTiposAuditoria;
            }
            set
            {
                if (_listaTiposAuditoria == value) return;

                _listaTiposAuditoria = value;
                RaisePropertyChanged(listaTiposAuditoriaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista tipo carpeta

        public const string listaTipoCarpetaPropertyName = "listaTipoCarpeta";

        private ObservableCollection<tipocarpeta> _listaTipoCarpeta;

        public ObservableCollection<tipocarpeta> listaTipoCarpeta
        {
            get
            {
                return _listaTipoCarpeta;
            }
            set
            {
                if (_listaTipoCarpeta == value) return;

                _listaTipoCarpeta = value;

                RaisePropertyChanged(listaTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedTipoCarpeta

        public const string selectedTipoCarpetaPropertyName = "selectedTipoCarpeta";

        private tipocarpeta _selectedTipoCarpeta;

        public tipocarpeta selectedTipoCarpeta
        {
            get
            {
                return _selectedTipoCarpeta;
            }

            set
            {
                if (_selectedTipoCarpeta == value) return;

                _selectedTipoCarpeta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionTipoCarpeta

        public const string eleccionTipoCarpetaPropertyName = "eleccionTipoCarpeta";

        private tipocarpeta _eleccionTipoCarpeta;

        public tipocarpeta eleccionTipoCarpeta
        {
            get
            {
                return _eleccionTipoCarpeta;
            }

            set
            {
                if (_eleccionTipoCarpeta == value) return;

                _eleccionTipoCarpeta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region activarDescripcionIndice

        public const string activarDescripcionIndicePropertyName = "activarDescripcionIndice";

        private bool _activarDescripcionIndice = false;

        public bool activarDescripcionIndice
        {
            get
            {
                return _activarDescripcionIndice;
            }

            set
            {
                if (_activarDescripcionIndice == value)
                {
                    return;
                }

                _activarDescripcionIndice = value;
                RaisePropertyChanged(activarDescripcionIndicePropertyName);
            }
        }

        #endregion

        #region Propiedades : descripcionpi //Nombre del indice maximo 40 


        public const string descripcionPropertyName = "descripcionpi";

        private string _descripcion = string.Empty;


        public string descripcionpi
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

        #region Primary key Plantilla Indice


        public const string idpiPropertyName = "idpi";

        private int _idpi = 0;

        public int idpi
        {
            get
            {
                return _idpi;
            }

            set
            {
                if (_idpi == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(idpiPropertyName);
            }
        }

        #endregion

        #region Primary key Tipo Auditoria


        public const string idPropertyName = "id";

        private int _id = 0;

        public int id
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

        #region sistemapi


        public const string sistemapiPropertyName = "sistemapi";

        private bool _sistemapi = false;


        public bool sistemapi
        {
            get
            {
                return _sistemapi;
            }

            set
            {
                if (_sistemapi == value)
                {
                    return;
                }

                _sistemapi = value;
                RaisePropertyChanged(sistemapiPropertyName);
            }
        }

        #endregion

        #region estadopi


        public const string estadopiPropertyName = "estadopi";

        private string _estadopi = string.Empty;

        public string estadopi
        {
            get
            {
                return _estadopi;
            }

            set
            {
                if (_estadopi == value)
                {
                    return;
                }

                _estadopi = value;
                RaisePropertyChanged(estadopiPropertyName);
            }
        }

        #endregion

        #region fechacreadopi


        public const string fechacreadopiPropertyName = "fechacreadopi";

        private string _fechacreadopi = string.Empty;

        public string fechacreadopi
        {
            get
            {
                return _fechacreadopi;
            }

            set
            {
                if (_fechacreadopi == value)
                {
                    return;
                }

                _fechacreadopi = value;
                RaisePropertyChanged(fechacreadopiPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private PlantillaIndiceModelo _currentEntidad;

        public PlantillaIndiceModelo currentEntidad
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

        #region visibilidadPlantilla

        public const string visibilidadPlantillaPropertyName = "visibilidadPlantilla";

        private Visibility _visibilidadPlantilla = Visibility.Collapsed;

        public Visibility visibilidadPlantilla
        {
            get
            {
                return _visibilidadPlantilla;
            }

            set
            {
                if (_visibilidadPlantilla == value)
                {
                    return;
                }

                _visibilidadPlantilla = value;
                RaisePropertyChanged(visibilidadPlantillaPropertyName);
            }
        }

        #endregion

        #region visibilidadCrear

        public const string visibilidadCrearPropertyName = "visibilidadCrear";

        private Visibility _visibilidadCrear = Visibility.Collapsed;

        public Visibility visibilidadCrear
        {
            get
            {
                return _visibilidadCrear;
            }

            set
            {
                if (_visibilidadCrear == value)
                {
                    return;
                }

                _visibilidadCrear = value;
                RaisePropertyChanged(visibilidadCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadCopiar

        public const string visibilidadCopiarPropertyName = "visibilidadCopiar";

        private Visibility _visibilidadCopiar = Visibility.Collapsed;

        public Visibility visibilidadCopiar
        {
            get
            {
                return _visibilidadCopiar;
            }

            set
            {
                if (_visibilidadCopiar == value)
                {
                    return;
                }

                _visibilidadCopiar = value;
                RaisePropertyChanged(visibilidadCopiarPropertyName);
            }
        }

        #endregion

        #region visibilidadConsultar

        public const string visibilidadConsultarPropertyName = "visibilidadConsultar";

        private Visibility _visibilidadConsultar = Visibility.Collapsed;

        public Visibility visibilidadConsultar
        {
            get
            {
                return _visibilidadConsultar;
            }

            set
            {
                if (_visibilidadConsultar == value)
                {
                    return;
                }

                _visibilidadConsultar = value;
                RaisePropertyChanged(visibilidadConsultarPropertyName);
            }
        }

        #endregion

        #region visibilidadEditar

        public const string visibilidadEditarPropertyName = "visibilidadEditar";

        private Visibility _visibilidadEditar = Visibility.Collapsed;

        public Visibility visibilidadEditar
        {
            get
            {
                return _visibilidadEditar;
            }

            set
            {
                if (_visibilidadEditar == value)
                {
                    return;
                }

                _visibilidadEditar = value;
                RaisePropertyChanged(visibilidadEditarPropertyName);
            }
        }

        #endregion

        #region encabezadoPantalla

        public const string encabezadoPantallaPropertyName = "encabezadoPantalla";

        private string _encabezadoPantalla = string.Empty;

        public string encabezadoPantalla
        {
            get
            {
                return _encabezadoPantalla;
            }

            set
            {
                if (_encabezadoPantalla == value)
                {
                    return;
                }

                _encabezadoPantalla = value;
                RaisePropertyChanged(encabezadoPantallaPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }

        public RelayCommand<tipocarpeta> SelectionCarpetaCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public PlantillaIndiceControllerViewModel()
        {
            _origen = "";
            _cerradoFinalVentana = false;//Controla el cierre de la ventana
            _tokenEnvio = "PlantillaIndiceController";
            _tokenRecepcion = "DatosElementoADetalle";//Identifica la fuente de un mensaje generico
            _maxDescripcion = 40;
            _numeroProcesoCrudRecibido = 0;
            //Suscribiendo el mensaje
            listaTiposAuditoria = new ObservableCollection<TipoAuditoriaModelo>(TipoAuditoriaModelo.GetAllCombo());
            listaTipoCarpeta = new ObservableCollection<tipocarpeta>(TipoCarpetaModelo.GetAllCapaDatosSeleccion());//Lista de carpeta
            Errors = 0;
            Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcion,(plantillaIndiceMensaje) => ControlPlantillaIndiceMensaje(plantillaIndiceMensaje));
            RegisterCommands();
            //Recibe un numero para procesar solo el último mensaje
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            dlg = new DialogCoordinator();
            accesibilidadWindow = false;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _visibilidadPlantilla = Visibility.Visible;
            _selectedTipoCarpeta = new tipocarpeta();
            _eleccionTipoCarpeta = new tipocarpeta();
            _activarDescripcionIndice = false;
        }

        private void ControlPlantillaIndiceMensaje(PlantillaIndiceMensaje plantillaIndiceMensaje)
        {
            currentEntidad = plantillaIndiceMensaje.elementoMensaje;
            listaEntidad = plantillaIndiceMensaje.listaMensaje;
            numeroProcesoCrudRecibido = plantillaIndiceMensaje.numeroProcesoCrudEnviado + 1;
            switch (plantillaIndiceMensaje.comandoCrud)
            {
                case 1:
                    encabezadoPantalla = "Ingrese los datos para  la plantilla de índice";
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    descripcionpi = string.Empty;
                    break;
                case 2:
                    encabezadoPantalla = "Modifique los datos para  la plantilla de índice";
                    accesibilidadWindow = true;
                    descripcionpi = currentEntidad.descripcionpi;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidad.idtcpi);
                    eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                    break;
                case 3:
                    encabezadoPantalla = "Consulta de los datos para  la plantilla de índice";
                    descripcionpi = currentEntidad.descripcionpi;
                    accesibilidadWindow = false;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidad.idtcpi);
                    eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                    break;
                case 5:
                    encabezadoPantalla = "Copia de la plantilla de índice, debe cambiar el nombre para guardar";
                    descripcionpi = currentEntidad.descripcionpi;
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Visible;
                    selectedTipoCarpeta = listaTipoCarpeta.Single(i => i.idtc == currentEntidad.idtcpi);
                    eleccionTipoCarpeta = currentEntidad.Tipocarpeta;
                    activarDescripcionIndice = true;
                    break;
            }
            enviarMensajeInhabilitar();
            Messenger.Default.Unregister<PlantillaIndiceMensaje>(this, tokenRecepcion);
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistemapi
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            cerradoFinalVentana = true;
            CloseWindow();
            enviarMensajeHabilitar();
        }

        private void Ok()
        {
            cerradoFinalVentana = true;
            CloseWindow();
            enviarMensajeHabilitar();
        }

        private void Salir()
        {
            if (!(cerradoFinalVentana))
            {
                CloseWindow();
                enviarMensajeHabilitar();
            }
            enviarMensajeFinProceso();//Manda mensaje de cierre
        }

        public async void Guardar()
        {
            if ((currentEntidad.tipoAuditoriaModelo != null))
            {
                if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                {
                    currentEntidad.tipoAuditoriaModelo = null;
                }
            }
            if (!(PlantillaIndiceModelo.FindTexto(currentEntidad.descripcionpi)))
            {
                        if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 0)
                        {
                            if (currentEntidad.Tipocarpeta != null)
                            {
                                currentEntidad.idtcpi = currentEntidad.Tipocarpeta.idtc;
                                if (PlantillaIndiceModelo.Insert(currentEntidad, currentUsuarioModelo))
                                {
                                    await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                                    listaEntidad.Add(currentEntidad);
                                    cerradoFinalVentana = true;
                                    CloseWindow();
                                    enviarMensajeHabilitar();
                                }
                                else
                                {
                                    await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                }
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "Debe seleccionar el tipo de carpeta para el  índice,", "");
                            }

                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "El nombre ya esta siendo utilizado,", "seleccione otro nombre");
                        }
                //Nuevo();
            }
            else
            {
                //Se reactiva el registro
                if ((PlantillaIndiceModelo.FindTextoReturnIdBorrados(currentEntidad.descripcionpi) == 1))
                {
                    if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 0)
                    {
                        if (PlantillaIndiceModelo.UpdateBorradoModelo(currentEntidad, true))
                        {
                            await dlg.ShowMessageAsync(this, "Registro creado con éxito", "");
                            CloseWindow();
                            cerradoFinalVentana = true;
                            enviarMensajeHabilitar();
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible crear el registro", "");
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "El nombre ya tiene ha sido utilizado,", "seleccione otro nombre");
                    }
                }
            }
        }

        public async void Modificar()
        {
            if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 1)
            {
                if ((currentEntidad.tipoAuditoriaModelo != null))
                {
                    if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                    {
                        currentEntidad.tipoAuditoriaModelo = null;
                    }
                }
                if (!string.IsNullOrEmpty(currentEntidad.descripcionpi))
                {

                        if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 1)
                        {
                            if (currentEntidad.Tipocarpeta != null)
                            {
                                currentEntidad.idtcpi = currentEntidad.Tipocarpeta.idtc;
                                    if (PlantillaIndiceModelo.UpdateModelo(currentEntidad))
                                    {
                                        await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                                        CloseWindow();
                                        cerradoFinalVentana = true;
                                        enviarMensajeHabilitar();
                                    }
                                    else
                                    {
                                        await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                                    }
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "Debe seleccionar el tipo de carpeta para el  índice,", "");
                            }
                        }
                    else
                    {
                        //Mensaje en caso de indice mayor
                        await dlg.ShowMessageAsync(this, "La descripcion es la misma que la de otro  registro", "");
                    }

                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
                }
                //Nuevo();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa nombre", "");
            }
        }


        public async void Copiar()
        {
            iniciarComando();
                if ((currentEntidad.tipoAuditoriaModelo != null))
                {
                    if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                    {
                        currentEntidad.tipoAuditoriaModelo = null;
                    }
                }
                if (!string.IsNullOrEmpty(currentEntidad.descripcionpi))
                {

                    if (nombreUnico(currentEntidad.descripcionpi, listaEntidad) == 0)
                    {
                        if (PlantillaIndiceModelo.CopiarModelo(currentEntidad))
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Registro copiado con éxito", "");
                            CloseWindow();
                            cerradoFinalVentana = true;
                            enviarMensajeHabilitar();
                        }
                        else
                        {
                        finComando();
                        await dlg.ShowMessageAsync(this, "No ha sido posible copiar el registro", "");
                        }
                    }
                    else
                    {
                    finComando();
                    //Mensaje en caso de indice mayor
                    await dlg.ShowMessageAsync(this, "Ya existe un registro con ese nombre", "Debe cambiar el nombre");
                    }

                }
                else
                {
                finComando();
                await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
                }
                //Nuevo();
        }

        #endregion

        #region Mensajes

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

        public void enviarMensajeFinProceso()
        {
            //Se crea el mensaje
            mensajeDeCierreCrud mensaje = new mensajeDeCierreCrud();
            mensaje.numeroProcesoCrud = numeroProcesoCrudRecibido;
            numeroProcesoCrudRecibido++;
            Messenger.Default.Send(mensaje,tokenEnvio);
        }
        #endregion

        #region Metodos de apoyo

        public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripcionpi) &&
                           (currentEntidad.descripcionpi.Length <= maxDescripcion) &&
                           Errors==0;
                return evaluar;
            }
        }

        #endregion

        #endregion
        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            CopiarCommand = new RelayCommand(Copiar, CanSave);
            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);

            SelectionCarpetaCommand = new RelayCommand<tipocarpeta>(entidad =>
            {
                if (entidad == null) return;
                eleccionTipoCarpeta = entidad;
                if (entidad.idtc != 0)
                {
                    currentEntidad.idtcpi = entidad.idtc;
                    currentEntidad.Tipocarpeta = eleccionTipoCarpeta;
                    activarDescripcionIndice = true;
                }
                //else
                //{
                //    currentEntidad.idtcpi = entidad.idtc;
                //    currentEntidad.Tipocarpeta = eleccionTipoCarpeta;
                //}
            });
        }



        #region Verifica unicidad
        //Cada marca debe ser única
        public int nombreUnico(string nombre, ObservableCollection<PlantillaIndiceModelo> listaBusqueda)
        {
            int numeroRegistros;
            string fechacreadopi = nombre.ToUpper().Trim();
            numeroRegistros = listaBusqueda.Where(j => j.descripcionpi.ToUpper().Trim() == fechacreadopi).Count();
            if (numeroRegistros == 1)
            {
                return 1;
            }
            else
            {
                return numeroRegistros;
            }
        }

        #endregion

        #endregion

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }
    }

}
