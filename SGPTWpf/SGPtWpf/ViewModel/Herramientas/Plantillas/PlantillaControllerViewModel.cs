using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using SGPTWpf.Model.Modelo.Plantilla;
using CapaDatos;
using SGPTWpf.Messages.Herramientas;
using System.Linq;
using SGPTWpf.Messages.Genericos;
using System.Data;
using System.ComponentModel;
using System.IO;
using System;

namespace SGPTWpf.ViewModel.Herramientas.Plantillas
{
    public sealed class PlantillaControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private int maxDescripcion = 100;

        private DialogCoordinator dlg;


        #region tokenPlantillaByte

        private string _tokenPlantillaByte;
        private string tokenPlantillaByte
        {
            get { return _tokenPlantillaByte; }
            set { _tokenPlantillaByte = value; }
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

        #region tokenEnvioCierre

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
        }

        #endregion

        #region salida

        private bool _salida;
        private bool salida
        {
            get { return _salida; }
            set { _salida = value; }
        }

        #endregion



        // Temporales
        //private MetroDialogSettings configuracionDialogo;

        //private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
        }

        #endregion

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

        #region ViewModel Properties publicas

        #region lista entidades

        public const string listaPropertyName = "lista";


        private ObservableCollection<PlantillaModelo> _lista;

        public ObservableCollection<PlantillaModelo> lista
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

        #region listaClaseDocumentos entidades

        public const string listaClaseDocumentosPropertyName = "listaClaseDocumentos";


        private ObservableCollection<DocumentoModelo> _listaClaseDocumentos;

        public ObservableCollection<DocumentoModelo> listaClaseDocumentos
        {
            get
            {
                return _listaClaseDocumentos;
            }

            set
            {
                if (_listaClaseDocumentos == value) return;

                _listaClaseDocumentos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaClaseDocumentosPropertyName);
            }
        }

        #endregion

        #region listaDetalleDocumentos entidades

        public const string listaDetalleDocumentosPropertyName = "listaDetalleDocumentos";


        private ObservableCollection<DetalleDocumentoModelo> _listaDetalleDocumentos;

        public ObservableCollection<DetalleDocumentoModelo> listaDetalleDocumentos
        {
            get
            {
                return _listaDetalleDocumentos;
            }

            set
            {
                if (_listaDetalleDocumentos == value) return;

                _listaDetalleDocumentos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDetalleDocumentosPropertyName);
            }
        }

        #endregion

        #region listaTipoArchivos tipoArhivos

        public const string listaTipoArchivosPropertyName = "listaTipoArchivos";


        private ObservableCollection<TipoArchivoModelo> _listaTipoArchivos;

        public ObservableCollection<TipoArchivoModelo> listaTipoArchivos
        {
            get
            {
                return _listaTipoArchivos;
            }

            set
            {
                if (_listaTipoArchivos == value) return;

                _listaTipoArchivos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaTipoArchivosPropertyName);
            }
        }

        #endregion

        #region  Primary key plantilla idplantilla

        public const string idplantillaPropertyName = "idplantilla";

        private int _idplantilla = 0;

        public int idplantilla
        {
            get
            {
                return _idplantilla;
            }

            set
            {
                if (_idplantilla == value)
                {
                    return;
                }

                _idplantilla = value;
                RaisePropertyChanged(idplantillaPropertyName);
            }
        }

        #endregion

        #region  Primary key plantilla idusuario

        public const string idusuarioPropertyName = "idusuario";

        private int _idusuario = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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

                _idusuario = value;
                RaisePropertyChanged(idusuarioPropertyName);
            }
        }

        #endregion

        #region  Primary key plantilla iddd

        public const string idddPropertyName = "iddd";

        private int _iddd = 0;

        public int iddd
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

        #region nombre de plantilla

        public const string nombreplantillaPropertyName = "nombreplantilla";

        private string _nombreplantilla = string.Empty;

        public string nombreplantilla
        {
            get
            {
                return _nombreplantilla;
            }

            set
            {
                if (_nombreplantilla == value)
                {
                    return;
                }

                _nombreplantilla = value;
                RaisePropertyChanged(nombreplantillaPropertyName);
            }
        }


        #endregion

        #region Comentario plantilla

        public const string comentarioplantillaPropertyName = "comentarioplantilla";

        private string _comentarioplantilla = string.Empty;

        public string comentarioplantilla
        {
            get
            {
                return _comentarioplantilla;
            }

            set
            {
                if (_comentarioplantilla == value)
                {
                    return;
                }

                _comentarioplantilla = value;
                RaisePropertyChanged(comentarioplantillaPropertyName);
            }
        }

        #endregion

        #region versionplantilla

        public const string versionplantillaPropertyName = "versionplantilla";

        private decimal _versionplantilla = 0;

        public decimal versionplantilla
        {
            get
            {
                return _versionplantilla;
            }

            set
            {
                if (_versionplantilla == value)
                {
                    return;
                }

                _versionplantilla = value;
                RaisePropertyChanged(versionplantillaPropertyName);
            }
        }

        #endregion

        #region fecha de modificacion de plantilla

        public const string fechacreadoplantillaPropertyName = "fechacreadoplantilla";

        private string _fechacreadoplantilla = string.Empty;

        public string fechacreadoplantilla
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

        #region Tipo  de archivo

        public const string tipoarchivoplantillaPropertyName = "tipoarchivoplantilla";

        private string _tipoarchivoplantilla = string.Empty;

        public string tipoarchivoplantilla
        {
            get
            {
                return _tipoarchivoplantilla;
            }

            set
            {
                if (_tipoarchivoplantilla == value)
                {
                    return;
                }

                _tipoarchivoplantilla = value;
                RaisePropertyChanged(tipoarchivoplantillaPropertyName);
            }
        }

        #endregion

        #region ficherobinarioplantilla

        public const string ficherobinarioplantillaPropertyName = "ficherobinarioplantilla";

        private byte[] _ficherobinarioplantilla = null;

        public byte[] ficherobinarioplantilla
        {
            get
            {
                return _ficherobinarioplantilla;
            }

            set
            {
                if (_ficherobinarioplantilla == value)
                {
                    return;
                }

                _ficherobinarioplantilla = value;
                RaisePropertyChanged(ficherobinarioplantillaPropertyName);
            }
        }

        #endregion

        #region sistemaplantilla

        public const string sistemaplantillaPropertyName = "sistemaplantilla";

        private bool _sistemaplantilla = false;

        public bool sistemaplantilla
        {
            get
            {
                return _sistemaplantilla;
            }

            set
            {
                if (_sistemaplantilla == value)
                {
                    return;
                }

                _sistemaplantilla = value;
                RaisePropertyChanged(sistemaplantillaPropertyName);
            }
        }

        #endregion

        #region estadoplantilla

        public const string estadoplantillaPropertyName = "estadoplantilla";

        private string _estadoplantilla = string.Empty;

        public string estadoplantilla
        {
            get
            {
                return _estadoplantilla;
            }

            set
            {
                if (_estadoplantilla == value)
                {
                    return;
                }

                _estadoplantilla = value;
                RaisePropertyChanged(estadoplantillaPropertyName);
            }
        }
        #endregion

        #region nombre de detalle documento

        public const string nombreDetalleDocumentoPropertyName = "nombreDetalleDocumento";

        private string _nombreDetalleDocumento = string.Empty;

        public string nombreDetalleDocumento
        {
            get
            {
                return _nombreDetalleDocumento;
            }

            set
            {
                if (_nombreDetalleDocumento == value)
                {
                    return;
                }

                _nombreDetalleDocumento = value;
                RaisePropertyChanged(nombreDetalleDocumentoPropertyName);
            }
        }


        #endregion

        #region descripcion de detalle de documento

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

        #region nombre de extension de tipo de archivo

        public const string nombreTipoArchivoPropertyName = "nombreTipoArchivo";

        private string _nombreTipoArchivo = string.Empty;

        public string nombreTipoArchivo
        {
            get
            {
                return _nombreTipoArchivo;
            }

            set
            {
                if (_nombreTipoArchivo == value)
                {
                    return;
                }

                _nombreTipoArchivo = value;
                RaisePropertyChanged(nombreTipoArchivoPropertyName);
            }
        }

        #endregion

        #region descripcion de clase de documento

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

        #region nombrearchivoplantilla de clase de documento

        public const string nombrearchivoplantillaPropertyName = "nombrearchivoplantilla";

        private string _nombrearchivoplantilla = string.Empty;

        public string nombrearchivoplantilla
        {
            get
            {
                return _nombrearchivoplantilla;
            }

            set
            {
                if (_nombrearchivoplantilla == value)
                {
                    return;
                }

                _nombrearchivoplantilla = value;
                RaisePropertyChanged(nombrearchivoplantillaPropertyName);
            }
        }


        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private PlantillaModelo _currentEntidad;

        public PlantillaModelo currentEntidad
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

        #region ViewModel Property : currentClaseDocumento

        public const string currentClaseDocumentoPropertyName = "currentClaseDocumento";

        private DocumentoModelo _currentClaseDocumento;

        public DocumentoModelo currentClaseDocumento
        {
            get
            {
                return _currentClaseDocumento;
            }

            set
            {
                if (_currentClaseDocumento == value) return;

                _currentClaseDocumento = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentClaseDocumentoPropertyName);
                if (_currentClaseDocumento != null)
                {
                    accesibilidadCuerpo = true;
                    listaDetalleDocumentos = new ObservableCollection<DetalleDocumentoModelo>(DetalleDocumentoModelo.GetAll(_currentClaseDocumento.id));
                }
                else
                {
                    accesibilidadCuerpo = false;
                }
            }
        }

        #endregion

        #region ViewModel Property : detalleDocumentosModelo

        public const string detalleDocumentosModeloPropertyName = "detalleDocumentosModelo";

        private DetalleDocumentoModelo _detalleDocumentosModelo;

        public DetalleDocumentoModelo detalleDocumentosModelo
        {
            get
            {
                return _detalleDocumentosModelo;
            }

            set
            {
                if (_detalleDocumentosModelo == value) return;

                _detalleDocumentosModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(detalleDocumentosModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : tipoArchivoModelo

        public const string tipoArchivoModeloPropertyName = "tipoArchivoModelo";

        private TipoArchivoModelo _tipoArchivoModelo;

        public TipoArchivoModelo tipoArchivoModelo
        {
            get
            {
                return _tipoArchivoModelo;
            }

            set
            {
                if (_tipoArchivoModelo == value) return;

                _tipoArchivoModelo = value;

                if (_tipoArchivoModelo != null)
                {
                    activarCarga = true;
                }
                else
                {
                    activarCarga = false;
                }
                // Update bindings, no broadcast
                RaisePropertyChanged(tipoArchivoModeloPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Propiedades Ventana


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

        #region ViewModel Properties : accesibilidadCuerpo

        public const string accesibilidadCuerpoPropertyName = "accesibilidadCuerpo";

        private bool _accesibilidadCuerpo = true;

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

        #region ViewModel Properties : activarCarga

        public const string activarCargaPropertyName = "activarCarga";

        private bool _activarCarga = true;

        public bool activarCarga
        {
            get
            {
                return _activarCarga;
            }

            set
            {
                if (_activarCarga == value)
                {
                    return;
                }

                _activarCarga = value;
                RaisePropertyChanged(activarCargaPropertyName);
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
        public RelayCommand<PlantillaModelo> SelectionChangedCommand { get; set; }
        public RelayCommand<DetalleDocumentoModelo> SelectionDetalleDocumentoCommand { get; set; }
        public RelayCommand<TipoArchivoModelo> SelectionTipoArchivoCommand { get; set; }
        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public PlantillaControllerViewModel()
        {
            _tokenPlantillaByte = "PlantillaByte";
            _tokenRecepcion = "PlantillaModelo";
            _tokenEnvioCierre = "CrudPlantillaCerrada";
            _salida = false;
        //Suscribiendo el mensaje
            listaClaseDocumentos = new ObservableCollection<DocumentoModelo>(DocumentoModelo.GetAll());
            listaDetalleDocumentos = new ObservableCollection<DetalleDocumentoModelo>(DetalleDocumentoModelo.GetAll());
            listaTipoArchivos = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
            Messenger.Default.Register<DetallePlantillaCrudMensaje>(this, tokenRecepcion, (detallePlantillaCrudMensaje) => ControlDetallePlantillaCrudMensaje(detallePlantillaCrudMensaje));
            //Messenger.Default.Register<ArchivoBinario>(this, tokenPlantillaByte, (archivoByte) => ControlArchivoByte(archivoByte));
            Messenger.Default.Register<string>(this, tokenPlantillaByte, (rutaArchivo) => ControlRutaArchivo(rutaArchivo));
            Messenger.Default.Register<bool>(this, tokenRecepcionVista, (controlErrorMensaje) => ControlErrorMensaje(controlErrorMensaje));

            encabezadoPantalla = "";
            RegisterCommands();
            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            salida = false;
            accesibilidadCuerpo = false;
            activarCarga = false;

            #region control de procesado

            _visibilidadProcesando = Visibility.Collapsed;
            _accesibilidadProceso = true;
            _isBusy = false;

            #endregion

        }

        private async void ControlErrorMensaje(bool controlErrorMensaje)
        {
            await dlg.ShowMessageAsync(this, "El tamaño del archivo debe ser menor a 128Kb", "Seleccionar otra imagen");
        }
        //private void ControlArchivoByte(ArchivoBinario archivoByte)
        //{
        //    currentEntidad.ficherobinarioplantilla = archivoByte.archivoBinario;
        //    currentEntidad.nombrearchivoplantilla = archivoByte.nombre;
        //}

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
                            //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                            //Byte[] ByteArray = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //binarioNormativa = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //nombrearchivonormativa= rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                            currentEntidad.ficherobinarioplantilla = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            currentEntidad.nombrearchivoplantilla = rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                            ficherobinarioplantilla = currentEntidad.ficherobinarioplantilla;
                            nombrearchivoplantilla = currentEntidad.nombrearchivoplantilla;
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
            await dlg.ShowMessageAsync(this, "No se puedo subir el archivo" + ex.Message, "");
        }


        private void ControlDetallePlantillaCrudMensaje(DetallePlantillaCrudMensaje detallePlantillaCrudMensaje)
        {
            currentEntidad = detallePlantillaCrudMensaje.elementoModelo;
            lista = detallePlantillaCrudMensaje.listaElementos;
            currentUsuarioModelo = detallePlantillaCrudMensaje.usuarioModeloValidado;
            if (currentEntidad.detalleDocumentosModelo != null)
            {
                currentClaseDocumento = listaClaseDocumentos.Single(i => i.id == currentEntidad.detalleDocumentosModelo.iddocumento);
                detalleDocumentosModelo = currentEntidad.detalleDocumentosModelo;
            }
            if (currentEntidad.tipoArchivoModelo != null)
            {
                activarCarga = true;
            }
            if (detallePlantillaCrudMensaje.comandoCrud == 1)
            {
                encabezadoPantalla = "Ingrese los datos de la plantilla";
                accesibilidadWindow = true;
                visibilidadCrear = Visibility.Visible;
                visibilidadEditar = Visibility.Collapsed;
                visibilidadConsultar = Visibility.Collapsed;
                visibilidadCopiar = Visibility.Collapsed;
            }
            else
            {
                if (detallePlantillaCrudMensaje.comandoCrud == 2)
                {
                    encabezadoPantalla = "Modifique los datos de la plantilla";
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                }
                else
                {
                    if (detallePlantillaCrudMensaje.comandoCrud == 5)
                    {
                        encabezadoPantalla = "Modifique el nombre de la copia de plantilla";
                        accesibilidadWindow = true;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Collapsed;
                        visibilidadCopiar = Visibility.Visible; ;
                    }
                    else
                    {
                        encabezadoPantalla = "Consulta de plantilla";
                        accesibilidadWindow = false;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Visible;
                        visibilidadCopiar = Visibility.Collapsed;
                    }
                }
            }

            Messenger.Default.Unregister<DetallePlantillaCrudMensaje>(this, tokenRecepcion);
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            salida = true;
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            CloseWindow();
        }

        private void Ok()
        {
            salida = true;
            CloseWindow();
        }


        private void Salir()
        {
            Messenger.Default.Unregister<bool>(this, tokenRecepcionVista);
            if (!salida)
            {

                CloseWindow();
            }
            else
            {
                //Ya procesado
            }
            enviarMensaje();
            enviarMensajeHabilitar();
        }


        public async void Guardar()
        {
            if (contenidoUnico(currentEntidad.nombreplantilla, lista) == 0)
            {

                //currentEntidad.id = PlantillaModelo.IdAsignar();
                if (PlantillaModelo.Insert(currentEntidad, true))
                {
                    await dlg.ShowMessageAsync(this, "Registro insertado con éxito", "");
                    salida = true;
                    CloseWindow();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                }
            }
            else
            {
                    await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción los tipos de documentos", "");
            }
        }


        public async void Copiar()
        {
            if (contenidoUnico(currentEntidad.nombreplantilla, lista) == 0)
            {

                //currentEntidad.id = PlantillaModelo.IdAsignar();
                if (PlantillaModelo.Insert(currentEntidad, true))
                {
                    await dlg.ShowMessageAsync(this, "Registro copiado con éxito", "");
                    salida = true;
                    CloseWindow();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible copiar el registro", "");
                }
            }
            else
            {
                currentEntidad.iddd = PlantillaModelo.FindTextoEliminados(currentEntidad);
                if (currentEntidad.iddd != 0)
                {
                    if (PlantillaModelo.UpdateModelo(currentEntidad, true))
                    {
                        await dlg.ShowMessageAsync(this, "Registro copiado con éxito", "");
                        salida = true;
                        CloseWindow();
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido copiar el registro", "");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El registro ya existe con ese nombre debe modificar el nombre", "");
                }
            }
        }

        public async void Modificar()
        {
            if ((contenidoUnico(currentEntidad.nombreplantilla,lista) == 0) || (contenidoUnico(currentEntidad.nombreplantilla, lista) == 1))
            {
                if (PlantillaModelo.UpdateModelo(currentEntidad, true))
                {
                    await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                    salida = true;
                    CloseWindow();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción ", "");
            }
        }


        #endregion

        #region Mensajes

        //Procesando el mensaje recibido

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            bool cerrado = true;
            Messenger.Default.Send(cerrado, tokenEnvioCierre);
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

            if (currentEntidad == null && detalleDocumentosModelo == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = !string.IsNullOrEmpty(currentEntidad.nombreplantilla) &&
                           (currentEntidad.nombreplantilla.Length <= maxDescripcion) &&
                           (detalleDocumentosModelo != null) &&
                           (currentClaseDocumento != null) &&
                           (currentEntidad.tipoArchivoModelo != null) &&
                           (currentEntidad.ficherobinarioplantilla != null);
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
            SelectionChangedCommand = new RelayCommand<PlantillaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
            SelectionTipoArchivoCommand = new RelayCommand<TipoArchivoModelo>(archivo =>
            {
                if (archivo == null) return;
                tipoArchivoModelo = archivo;
            });
            SelectionDetalleDocumentoCommand = new RelayCommand<DetalleDocumentoModelo>(detalle =>
            {
                if (detalle == null) return;
                detalleDocumentosModelo = detalle;
                currentEntidad.detalleDocumentosModelo = detalle;
            });
        }

        #endregion

        #region Verifica unicidad
        //Cada marca debe ser única
        public int contenidoUnico(string elemento, ObservableCollection<PlantillaModelo> listaBusqueda)
        {
            int numeroRegistros;
            string marcame = elemento.ToUpper();
            numeroRegistros = listaBusqueda.Where(j => j.nombreplantilla.ToUpper() == marcame).Count();
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


        }
}

