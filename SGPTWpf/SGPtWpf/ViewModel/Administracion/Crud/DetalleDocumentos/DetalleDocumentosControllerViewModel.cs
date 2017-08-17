using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System.Linq;
using System.Windows;
using SGPTWpf.Messages.Administracion.DetalleDocumentoCrudMensaje;
using System;
using SGPTWpf.Model.Modelo.Plantilla;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.ViewModel.Administracion.Crud.DetalleDocumentos
{
    public sealed class DetalleDocumentosControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private int maxDescripcion = 100;
        private string tokenRecepcion = "DetalleDocumentoModelo";
        private string tokenEnvioCierre = "CrudDetalleDocumentoCerrada";
        private DialogCoordinator dlg;
        private bool salida = false;
        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";


        private ObservableCollection<DetalleDocumentoModelo> _lista;

        public ObservableCollection<DetalleDocumentoModelo> lista
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

        #region estadodddd

        public const string estadoddddPropertyName = "estadodddd";

        private string _estadodddd = string.Empty;

        public string estadodddd
        {
            get
            {
                return _estadodddd;
            }

            set
            {
                if (_estadodddd == value)
                {
                    return;
                }

                _estadodddd = value;
                RaisePropertyChanged(estadoddddPropertyName);
            }
        }
        #endregion

        #region ViewModel Property : iddocumento

        #region Primary key


        #region ViewModel Property : documentoModelo

        public const string documentoModeloPropertyName = "documentoModelo";

        private DocumentoModelo _documentoModelo;

        public DocumentoModelo documentoModelo
        {
            get
            {
                return _documentoModelo;
            }

            set
            {
                if (_documentoModelo == value) return;

                _documentoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(documentoModeloPropertyName);
            }
        }

        #endregion

        #region iddocumento

        public const string iddocumentoPropertyName = "iddocumento";

        private int _iddocumento = 0;

        public int iddocumento
        {
            get
            {
                return _iddocumento;
            }

            set
            {
                if (_iddocumento == value)
                {
                    return;
                }

                _iddocumento = value;
                RaisePropertyChanged(iddocumentoPropertyName);
            }
        }

        #endregion

        #endregion

        #endregion

        #region Descripcion de nombreDocumento

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

        #region Entidad en uso

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

        #endregion

        #region ViewModel Property : currentUsuario UsuarioModelo

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

        #endregion

        #region listaDocumentos

        public const string listaDocumentosPropertyName = "listaDocumentos";


        private ObservableCollection<DocumentoModelo> _listaDocumentos;

        public ObservableCollection<DocumentoModelo> listaDocumentos
        {
            get
            {
                return _listaDocumentos;
            }
            set
            {
                if (_listaDocumentos == value) return;

                _listaDocumentos = value;

                RaisePropertyChanged(listaDocumentosPropertyName);
            }
        }

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

        #endregion

        #region ViewModel Commands

        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<DetalleDocumentoModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public DetalleDocumentosControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();

            //Suscribiendo el mensaje
            listaDocumentos = new ObservableCollection<DocumentoModelo>(DocumentoModelo.GetAll());
            Messenger.Default.Register<DetalleDocumentoCrudMensaje>(this, tokenRecepcion,(detalleDocumentoCrudMensaje) => ControlDetalleDocumentoCrudMensaje(detalleDocumentoCrudMensaje));
            RegisterCommands();
            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            salida = false;
        }

        private void ControlDetalleDocumentoCrudMensaje(DetalleDocumentoCrudMensaje detalleDocumentoCrudMensaje)
        {
            currentEntidad = detalleDocumentoCrudMensaje.detalleDocumentoModelo;

            /*if (!((currentEntidad == null) || ((currentEntidad.iddocumento == null) || (currentEntidad.iddocumento == 0))))
            {
                selectedDocumento = listaDocumentos.Single(i => i.id == currentEntidad.iddocumento);
            }
            else
            {
                selectedDocumento = null;
            }*/
            lista = detalleDocumentoCrudMensaje.listadetalleDocumento;

            currentUsuario = detalleDocumentoCrudMensaje.usuarioModeloValidado;
            if (detalleDocumentoCrudMensaje.comandoCrud == 1)
            {
                accesibilidadWindow = true;
                visibilidadCrear = Visibility.Visible;
                visibilidadEditar = Visibility.Collapsed;
                visibilidadConsultar = Visibility.Collapsed;
                visibilidadCopiar = Visibility.Collapsed;
            }
            else
            {
                if (detalleDocumentoCrudMensaje.comandoCrud == 2)
                {
                    accesibilidadWindow = true;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                }
                else
                {
                        accesibilidadWindow = false;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Visible;
                        visibilidadCopiar = Visibility.Collapsed;
                }
            }

            Messenger.Default.Unregister<DetalleDocumentoCrudMensaje>(this, tokenRecepcion);
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
            if (!(DetalleDocumentoModelo.FindTexto(currentEntidad)))
            {

                //currentEntidad.id = DetalleDocumentoModelo.IdAsignar();
                if (DetalleDocumentoModelo.Insert(currentEntidad, true))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
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
                currentEntidad.iddd = DetalleDocumentoModelo.FindTextoEliminados(currentEntidad);
                if (currentEntidad.iddd!=0)
                {
                    if (DetalleDocumentoModelo.UpdateModelo(currentEntidad, true))
                    {

                        var controller = await dlg.ShowProgressAsync(this, "Registro creado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        salida = true;
                        CloseWindow();
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible crear el registro", "");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción los tipos de documentos", "");
                }
            }
        }


        public async void Modificar()
        {
            if (!(DetalleDocumentoModelo.FindTexto(currentEntidad)))
            {
                if (DetalleDocumentoModelo.UpdateModelo(currentEntidad, true))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
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

            if (currentEntidad == null && documentoModelo == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripciondd) &&
                           (currentEntidad.descripciondd.Length <= maxDescripcion) &&
                           ((currentEntidad.documentoModelo != null));
                return evaluar;
            }
        }

        #endregion

        #endregion
        #region ViewModel Private Methods

        private void RegisterCommands()
        {

            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<DetalleDocumentoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion
    }
}

