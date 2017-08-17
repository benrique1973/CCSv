using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.Model.Modelo;
using SGPTWpf.Messages.Administracion.NormaLegal;
using System;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Messages.Navegacion.PDF;
using System.Windows;
using System.Globalization;
using System.IO;
using System.ComponentModel;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Model;
using System.Linq;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas.Normativa
{
    public sealed class NormaLegalControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas
        // Temporales

        private MetroDialogSettings configuracionDialogo;

        public static int Errors { get; set; }//Para controllar los errores de edición

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }

        #endregion

        //fin

        #region tokenNormaViewRecepcion

        private string _tokenNormaViewRecepcion;
        private string tokenNormaViewRecepcion
        {
            get { return _tokenNormaViewRecepcion; }
            set { _tokenNormaViewRecepcion = value; }
        }

        #endregion


        private DialogCoordinator dlg;


        private bool _isRealizadaSalida;//Controlla si ya se realizo la salida
        private bool isRealizadaSalida
        {
            get { return _isRealizadaSalida; }
            set { _isRealizadaSalida = value; }
        }

        private bool _isValidarfechar;//Controlla si ya se realizo la salida
        private bool isValidarfechar
        {
            get { return _isValidarfechar; }
            set { _isValidarfechar = value; }
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

        #region ViewModel Properties : accesibilidadCuerpo

        public const string accesibilidadCuerpoPropertyName = "accesibilidadCuerpo";

        private bool _accesibilidadCuerpo;

        public bool accesibilidadCuerpo
        {
            get
            {
                return _accesibilidadCuerpo;
            }

            set
            {
                if (_accesibilidadCuerpo == value)
                {
                    return;
                }

                _accesibilidadCuerpo = value;
                RaisePropertyChanged(accesibilidadCuerpoPropertyName);
            }
        }

        #endregion



        #region procesos en gestion

        #region ViewModel Properties : isBusy

        public const string isBusyPropertyName = "isBusy";

        private bool _isBusy;

        public bool isBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged(isBusyPropertyName);
            }
        }

        #endregion

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

        #region ViewModel Properties : accesibilidadProceso

        public const string accesibilidadProcesoPropertyName = "accesibilidadProceso";

        private bool _accesibilidadProceso;

        public bool accesibilidadProceso
        {
            get
            {
                return _accesibilidadProceso;
            }

            set
            {
                if (_accesibilidadProceso == value)
                {
                    return;
                }

                _accesibilidadProceso = value;
                RaisePropertyChanged(accesibilidadProcesoPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : ListaEntidad

        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<NormativaModelo> _ListaEntidad;

        public ObservableCollection<NormativaModelo> ListaEntidad
        {
            get
            {
                return _ListaEntidad;
            }
            set
            {
                if (_ListaEntidad == value) return;

                _ListaEntidad = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }
        #endregion

        #region Propiedades : Descripcion

        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

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

        #region Primary key

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

        #region Propiedades : nombrenormativa

        public const string nombrenormativaPropertyName = "nombrenormativa";
        //Nombre largo de la normativa
        private string _nombrenormativa = string.Empty;

        public string nombrenormativa
        {
            get
            {
                return _nombrenormativa;
            }
            set
            {
                if (_nombrenormativa == value)
                {
                    return;
                }
                _nombrenormativa = value;
                RaisePropertyChanged(nombrenormativaPropertyName);
            }
        }

        #endregion

        #region Propiedades : fechavigencianormativa

        public const string fechavigencianormativaPropertyName = "fechavigencianormativa";
        //fecha de vigencia de la normativa
        private DateTime _fechavigencianormativa;

        public DateTime fechavigencianormativa
        {
            get
            {
                return _fechavigencianormativa;
            }
            set
            {
                if (_fechavigencianormativa == value)
                {
                    return;
                }
                _fechavigencianormativa = value;
                RaisePropertyChanged(fechavigencianormativaPropertyName);
                if(isValidarfechar)
                { 
                if (!(string.IsNullOrEmpty(value.ToString())))
                {
                    validarFechasMensajes();
                }
                }
            }
        }

        #endregion

        #region Propiedades : fechaemisionnormativa

        public const string fechaemisionnormativaPropertyName = "fechaemisionnormativa";
        //fecha de emision de normativa
        private DateTime _fechaemisionnormativa;

        public DateTime fechaemisionnormativa
        {
            get
            {
                return _fechaemisionnormativa;
            }
            set
            {
                if (_fechaemisionnormativa == value)
                {
                    return;
                }
                _fechaemisionnormativa = value;
                RaisePropertyChanged(fechaemisionnormativaPropertyName);
                RaisePropertyChanged(fechavigencianormativaPropertyName);
                if (isValidarfechar)
                { 
                if (!(string.IsNullOrEmpty(value.ToString())))
                {
                    validarFechasMensajes();
                }
            }
        }
        }

        #endregion

        #region binarioNormativa

        public const string binarioNormativaPropertyName = "binarioNormativa";

        private byte[] _binarioNormativa = null;

        public byte[] binarioNormativa
        {
            get
            {
                return _binarioNormativa;
            }

            set
            {
                if (_binarioNormativa == value)
                {
                    return;
                }

                _binarioNormativa = value;
                RaisePropertyChanged("AsignarBinarioNormativa");
                RaisePropertyChanged(binarioNormativaPropertyName);
            }
        }

        #endregion

        #region binarioNormativaInicial

        public bool AsignarBinarioNormativa
        {
            get
            {
                currentEntidad.binarioNormativa = binarioNormativa;
                return (!(this.binarioNormativa == null));
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

        #region nombrearchivonormativa

        public const string nombrearchivonormativaPropertyName = "nombrearchivonormativa";

        private string _nombrearchivonormativa = string.Empty;


        public string nombrearchivonormativa
        {
            get
            {
                return _nombrearchivonormativa;
            }

            set
            {
                if (_nombrearchivonormativa == value)
                {
                    return;
                }

                _nombrearchivonormativa = value;
                RaisePropertyChanged(nombrearchivonormativaPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad


        public const string currentEntidadPropertyName = "currentEntidad";

        private NormativaModelo _currentEntidad;

        public NormativaModelo currentEntidad
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

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<NormativaModelo> _listaEntidadSeleccion;

        public ObservableCollection<NormativaModelo> listaEntidadSeleccion
        {
            get
            {
                return _listaEntidadSeleccion;
            }
            set
            {
                if (_listaEntidadSeleccion == value) return;

                _listaEntidadSeleccion = value;

                RaisePropertyChanged(listaEntidadSeleccionPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        private UsuarioModelo _currentUsuario;

        public UsuarioModelo currentUsuario
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

        #region Propiedades de ventanas

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

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private Boolean _activarCaptura;

        public Boolean activarCaptura
        {
            get
            {
                return _activarCaptura;
            }

            set
            {
                if (_activarCaptura == value)
                {
                    return;
                }

                _activarCaptura = value;
                RaisePropertyChanged(activarCapturaPropertyName);
            }
        }

        #endregion

        #region contenidoControlCarga

        public const string contenidoControlCargaPropertyName = "contenidoControlCarga";

        private string _contenidoControlCarga;

        public string contenidoControlCarga
        {
            get
            {
                return _contenidoControlCarga;
            }

            set
            {
                if (_contenidoControlCarga == value)
                {
                    return;
                }

                _contenidoControlCarga = value;
                RaisePropertyChanged(contenidoControlCargaPropertyName);
            }
        }

        #endregion

        #region visibilidadNombre

        public const string visibilidadNombrePropertyName = "visibilidadNombre";

        private Visibility _visibilidadNombre;

        public Visibility visibilidadNombre
        {
            get
            {
                return _visibilidadNombre;
            }

            set
            {
                if (_visibilidadNombre == value)
                {
                    return;
                }

                _visibilidadNombre = value;
                RaisePropertyChanged(visibilidadNombrePropertyName);
            }
        }

        #endregion

        #region visibilidadCrear

        public const string visibilidadCrearPropertyName = "visibilidadCrear";

        private Visibility _visibilidadCrear;

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

        #region visibilidadRuta

        public const string visibilidadRutaPropertyName = "visibilidadRuta";

        private Visibility _visibilidadRuta;

        public Visibility visibilidadRuta
        {
            get
            {
                return _visibilidadRuta;
            }

            set
            {
                if (_visibilidadRuta == value)
                {
                    return;
                }

                _visibilidadRuta = value;
                RaisePropertyChanged(visibilidadRutaPropertyName);
            }
        }

        #endregion

        #region visibilidadConsultar

        public const string visibilidadConsultarPropertyName = "visibilidadConsultar";

        private Visibility _visibilidadConsultar;

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

        private Visibility _visibilidadEditar;

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

        #region marcaAguaArchivo

        public const string marcaAguaArchivoPropertyName = "marcaAguaArchivo";

        private string _marcaAguaArchivo = string.Empty;

        public string marcaAguaArchivo
        {
            get
            {
                return _marcaAguaArchivo;
            }

            set
            {
                if (_marcaAguaArchivo == value)
                {
                    return;
                }

                _marcaAguaArchivo = value;
                RaisePropertyChanged(marcaAguaArchivoPropertyName);
            }
        }

        #endregion


        #region activarCrear

        public const string activarCrearPropertyName = "activarCrear";

        private bool _activarCrear = false;

        public bool activarCrear
        {
            get
            {
                return _activarCrear;
            }

            set
            {
                if (_activarCrear == value)
                {
                    return;
                }

                _activarCrear = value;
                RaisePropertyChanged(activarCrearPropertyName);
            }
        }

        #endregion

        #region activarConsultar

        public const string activarConsultarPropertyName = "activarConsultar";

        private bool _activarConsultar = false;

        public bool activarConsultar
        {
            get
            {
                return _activarConsultar;
            }

            set
            {
                if (_activarConsultar == value)
                {
                    return;
                }

                _activarConsultar = value;
                RaisePropertyChanged(activarConsultarPropertyName);
            }
        }

        #endregion

        #region activarEditar

        public const string activarEditarPropertyName = "activarEditar";

        private bool _activarEditar = false;

        public bool activarEditar
        {
            get
            {
                return _activarEditar;
            }

            set
            {
                if (_activarEditar == value)
                {
                    return;
                }

                _activarEditar = value;
                RaisePropertyChanged(activarEditarPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CargarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<NormativaModelo> SelectionChangedCommand { get; set; }


        #endregion

        //************************************************************

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores



        public NormaLegalControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            Errors = 0;
            _tokenRecepcionVista = "datosNormaCrearVista"; 
            //Suscribiendo el mensaje
            _contenidoControlCarga = "Cargar";
            _tokenNormaViewRecepcion = "NormalLegalCaptura";

            Messenger.Default.Register<CatalogoNormaLegalElementoMensaje>(this, (controlElementoMensaje) => ControlElementoMensaje(controlElementoMensaje));
            //Messenger.Default.Register<ArchivoBinario>(this, tokenNormaViewRecepcion, (controlNormaLegalByteMensaje) => ControlNormaLegalByteMensaje(controlNormaLegalByteMensaje));
            Messenger.Default.Register<string>(this, tokenNormaViewRecepcion, (rutaArchivo) => ControlRutaArchivo(rutaArchivo));
            Messenger.Default.Register<bool>(this, tokenRecepcionVista, (controlErrorMensaje) => ControlErrorMensaje(controlErrorMensaje));

            Messenger.Default.Register<HerramientaCmdCrudMensaje>(this, (herramientaCmdCrudMensaje) => ControlHerramientaCmdCrudMensaje(herramientaCmdCrudMensaje));
            _listaEntidadSeleccion = new ObservableCollection<NormativaModelo>();
            _currentUsuario = new UsuarioModelo();
            enviarMensajeInhabilitar();
            currentEntidad = null;
            RegisterCommands();
            dlg = new DialogCoordinator();
            _isRealizadaSalida = false;
            _isValidarfechar = false;
            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            _visibilidadNombre = Visibility.Collapsed;
            #region control de procesado

            _visibilidadProcesando = Visibility.Collapsed;
            _accesibilidadProceso = true;
            _isBusy = false;

            #endregion

        }

        private async void ControlErrorMensaje(bool controlErrorMensaje)
        {
            await dlg.ShowMessageAsync(this, "El tamaño del archivo debe ser menor a 2.8Megabytes", "Seleccionar otra archivo o reducir el tamaño");
        }

        private void ControlRutaArchivo(string rutaArchivo)
        {
            accesibilidadProceso = false;
            visibilidadProcesando = Visibility.Visible;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                try
                {
                    if (!(string.IsNullOrEmpty(rutaArchivo)))
                    {
                        using (FileStream fsSource = new FileStream(rutaArchivo,
                        FileMode.Open, FileAccess.Read))
                        {
                            //Leer la imagen en un array de bytes
                            ///////////////////////////////////////////////////
                            //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                            //Byte[] ByteArray = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //binarioNormativa = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //nombrearchivonormativa= rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                            currentEntidad.binarioNormativa = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            currentEntidad.nombrearchivonormativa = rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                            binarioNormativa = currentEntidad.binarioNormativa;
                            nombrearchivonormativa = currentEntidad.nombrearchivonormativa;
                        }
                    }
                }
                catch (Exception ex)
                {
                    mensajeProcesado(ex);
                }

            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                    visibilidadProcesando = Visibility.Collapsed;
                    accesibilidadProceso = true;
            };
            worker.RunWorkerAsync();
            worker.Dispose();
        }

        private async void mensajeProcesado(Exception ex)
        {
            finComando();
            await dlg.ShowMessageAsync(this, "No se puedo subir el archivo" + ex.Message, "");
        }

        private async void ControlHerramientaCmdCrudMensaje(HerramientaCmdCrudMensaje herramientaCmdCrudMensaje)
        {
            currentUsuario = herramientaCmdCrudMensaje.usuarioModelo;

            switch (herramientaCmdCrudMensaje.cmd.ToString())
            {
                case "1":
                    encabezadoPantalla = "Introduzca los datos";
                    contenidoControlCarga = "Cargar";
                    activarCaptura = true;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadRuta = Visibility.Visible;
                    marcaAguaArchivo = "Haga click para cargar";
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    visibilidadNombre = Visibility.Collapsed;
                    visibilidadRuta = Visibility.Visible;
                    break;
                case "2":
                    encabezadoPantalla = "Actualice los datos";
                    contenidoControlCarga = "Modificar";
                    activarCaptura = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadRuta = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    marcaAguaArchivo = "Haga click para actualizar archivo";
                    activarCrear = false;
                    activarConsultar = false;
                    activarEditar = true;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    visibilidadNombre = Visibility.Visible;
                    visibilidadRuta = Visibility.Collapsed;
                    break;
                case "3":
                    encabezadoPantalla = "Datos del registro";
                    contenidoControlCarga = "Consulta";
                    activarCaptura = false;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadRuta = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    marcaAguaArchivo = "";
                    activarCrear = false;
                    activarConsultar = true;
                    activarEditar = false;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = false;
                    visibilidadNombre = Visibility.Visible;
                    visibilidadRuta = Visibility.Collapsed;
                    break;
                default:
                    await dlg.ShowMessageAsync(this, "Error en comunicacion de comando", "");
                    break;
            }
            Messenger.Default.Unregister<HerramientaCmdCrudMensaje>(this);
        }

        /*private void ControlNormaLegalByteMensaje(ArchivoBinario controlNormaLegalByteMensaje)
        {
            currentEntidad.binarioNormativa = controlNormaLegalByteMensaje.archivoBinario;
            currentEntidad.nombrearchivonormativa = controlNormaLegalByteMensaje.nombre;

            if (!((currentEntidad.binarioNormativa == null)))
            {
                binarioNormativa = currentEntidad.binarioNormativa;
                nombrearchivonormativa = currentEntidad.nombrearchivonormativa;

            }
            else
            {
                binarioNormativa = null;
            }
        }*/

        private void ControlElementoMensaje(CatalogoNormaLegalElementoMensaje controlElementoMensaje)
        {
            currentEntidad = controlElementoMensaje.elementoMensaje;
            DateTime temporal1;
            bool isValid = DateTime.TryParseExact(
            currentEntidad.fechaemisionnormativa,
            "dd/MM/yyyy",
            CultureInfo.CurrentCulture,
            DateTimeStyles.None, out temporal1);
            if (isValid)
            {
                fechaemisionnormativa = temporal1;
            }
            else {
                fechaemisionnormativa = DateTime.Now;
            }

            DateTime temporal2;
            bool isValid2 = DateTime.TryParseExact(
            currentEntidad.fechavigencianormativa,
            "dd/MM/yyyy",
            CultureInfo.CurrentCulture,
            DateTimeStyles.None, out temporal2);
            if (isValid2)
            {
                fechavigencianormativa = temporal2;
            }
            else
            {
                fechavigencianormativa = DateTime.Now;
            }
            isValidarfechar = true; //Ya se cargaron ambas fechas se puede hacer comparaciones
            binarioNormativa = currentEntidad.binarioNormativa;
            if (currentEntidad.id == 0)
            {
                currentEntidad.listaEntidadSeleccion = controlElementoMensaje.listaNormativa;
                listaEntidadSeleccion = controlElementoMensaje.listaNormativa;
            }
            else
            {
                listaEntidadSeleccion = controlElementoMensaje.listaNormativa;
                //Se excluye el caso para que se cumpla la condicion de unico
                currentEntidad.listaEntidadSeleccion =new ObservableCollection<NormativaModelo>(listaEntidadSeleccion.Where(x=>x.id!=currentEntidad.id));
            }
            if (string.IsNullOrEmpty(currentEntidad.nombrearchivonormativa))
            {
                visibilidadNombre = Visibility.Collapsed;
                visibilidadRuta = Visibility.Visible;
                nombrearchivonormativa = currentEntidad.nombrearchivonormativa;
            }
            else
            {
                visibilidadNombre = Visibility.Visible;
                visibilidadRuta = Visibility.Collapsed;
                nombrearchivonormativa = currentEntidad.nombrearchivonormativa;
            }
            finComando();
            Messenger.Default.Unregister<CatalogoNormaLegalElementoMensaje>(this);

        }

        #endregion

        private async void Cancelar()
        {
            iniciarComando();
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            isRealizadaSalida = true;
            CloseWindow();

        }

        private void Ok()
        {
            iniciarComando();
            isRealizadaSalida = true;
            CloseWindow();


        }

        private void Salir()
        {
            Messenger.Default.Unregister<bool>(this, tokenRecepcionVista);

            if (isRealizadaSalida)
            {
                //ya cerro la ventana
            }
            else
            {
                iniciarComando();
                CloseWindow();
            }
            enviarMensajeHabilitar();
            enviarMensaje();

        }

        public async void Guardar()
        {
                    currentEntidad.binarioNormativa = binarioNormativa;
                    iniciarComando();
                    currentEntidad.fechaemisionnormativa = MetodosModelo.homologacionFecha(fechaemisionnormativa.ToString("d", CultureInfo.CurrentCulture));
                    currentEntidad.fechavigencianormativa= MetodosModelo.homologacionFecha(fechavigencianormativa.ToString("d", CultureInfo.CurrentCulture));
                    if (NormativaModelo.Insert(currentEntidad, true))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        enviarNormaLegalCrearActualizarMensaje();
                        isRealizadaSalida = true;
                        CloseWindow();
                    }
                    else
                    {
                        finComando();
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                    }
        }

        public async void Modificar()
        {
            iniciarComando();
                    //Caso de actualizacion
                        {
                            currentEntidad.binarioNormativa = binarioNormativa;
                            currentEntidad.fechaemisionnormativa = MetodosModelo.homologacionFecha(fechaemisionnormativa.ToString("d", CultureInfo.CurrentCulture));
                            currentEntidad.fechavigencianormativa = MetodosModelo.homologacionFecha(fechavigencianormativa.ToString("d", CultureInfo.CurrentCulture));
                            if (NormativaModelo.UpdateModelo(currentEntidad, true))
                            {
                                var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                enviarNormaLegalCrearActualizarMensaje();
                                isRealizadaSalida = true;
                                CloseWindow();
                            }
                            else
                            {
                                finComando();
                                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                            }
                        }
        }

        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            VentanaViewMensaje cierre = new VentanaViewMensaje();
            cierre.mensaje = -1;
            Messenger.Default.Send<VentanaViewMensaje>(cierre);

        }
        public void enviarNormaLegalCrearActualizarMensaje()
        {
            //Creando el mensaje de cierre
            NormaLegalCrearActualizarMensaje actualizar = new NormaLegalCrearActualizarMensaje();
            actualizar.actualizar = true;
            Messenger.Default.Send<NormaLegalCrearActualizarMensaje>(actualizar);

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
                evaluar = (Errors == 0)
                && !(binarioNormativa == null) 
                &&  validarFechas();
                //evaluar = (Errors == 0)
                //            && !string.IsNullOrEmpty(currentEntidad.descripcion) &&
                //            (currentEntidad.descripcion.Length <= maxDescripcion) &&
                //            !(binarioNormativa == null) &&
                //            (currentEntidad.nombrenormativa.Length <= maxDescripcionNombreLargo) &&
                //            !string.IsNullOrEmpty(currentEntidad.nombrenormativa) &&
                //            validarFechas();
                return evaluar;
            }
        }
        public async void validarFechasMensajes()
        {
            //http://stackoverflow.com/questions/1359188/c-sharp-regular-expression-to-validate-a-date

            DateTime fechaemision = fechaemisionnormativa;
            DateTime fechavigencia=fechavigencianormativa;
            DateTime fechalimiteInicial = Convert.ToDateTime("01/01/1950", CultureInfo.CurrentCulture);
            DateTime fechalimiteEmision = DateTime.Now.AddMonths(1);
            DateTime fechaLimiteFinal = DateTime.Now.AddYears(5);
                if (fechaemision > fechavigencia)
                {
                    await dlg.ShowMessageAsync(this, "La fecha de emision  debe ser menor a la de vigencia", "");
                }
                else
                {
                    if (!(fechaemision >= fechalimiteInicial))
                    {
                        await dlg.ShowMessageAsync(this, "La fecha de emision  debe ser mayor a a 01/01/1950", "");
                    }
                    else
                    {
                        if (!(fechaemision <= fechalimiteEmision))
                        {
                            await dlg.ShowMessageAsync(this, "La fecha de emision  debe ser menor al futuro próximo", "");
                        }
                        else
                        {
                            if (!(fechavigencia >= fechalimiteInicial))
                            {
                                await dlg.ShowMessageAsync(this, "La fecha de vigencia debe ser mayor a  01/01/1950", "");
                            }
                            else
                            {
                                if (!(fechavigencia <= fechaLimiteFinal))
                                {
                                    await dlg.ShowMessageAsync(this, "La fecha de vigencia debe ser menor al futuro  próximo", "");
                                }
                            }
                        }
                    }
                }
            }

        public bool validarFechas()
        {
            //http://stackoverflow.com/questions/1359188/c-sharp-regular-expression-to-validate-a-date
            DateTime fechalimiteInicial = Convert.ToDateTime("01/01/1950", CultureInfo.CurrentCulture);
            DateTime fechalimiteEmision = DateTime.Now.AddMonths(1);
            DateTime fechaLimiteFinal = DateTime.Now.AddYears(5);

                if ((fechaemisionnormativa < fechavigencianormativa) && (fechaemisionnormativa >= fechalimiteInicial) && (fechaemisionnormativa <= fechalimiteEmision) && (fechavigencianormativa >= fechalimiteInicial) && (fechavigencianormativa <= fechaLimiteFinal))
                {
                    return true;
                }

                else
                {
                    return false;
                }
        }

        #endregion

        #endregion
        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            GuardarCommand = new RelayCommand(Guardar, CanSave);//Crear
            EditarCommand = new RelayCommand(Modificar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            SelectionChangedCommand = new RelayCommand<NormativaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }


        #endregion
        #region Gestion de comandos

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


        #endregion Fin de comando
    }
}
