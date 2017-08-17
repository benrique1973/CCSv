using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.Messages.Elemento;
using SGPTWpf.Model.Modelo.Encargos;
using System.Windows;
using System;
using System.Linq;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;


namespace SGPTWpf.ViewModel.Crud.Elemento
{
    public sealed class ElementoControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;

        public static int Errors { get; set; }//Para controllar los errores de edición

        private bool salida = false;
        private int maxDescripcion = 50;
        private DialogCoordinator dlg;
        private string tokenRecepcion = "ElementoModelo";
        private string tokenEnvioCierre = "CrudElementoCerrada";

        #endregion

        #region ViewModel Properties


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


        #region Propiedades : codigoelemento

        public const string codigoelementoPropertyName = "codigoelemento";

        private int? _codigoelemento = 0;

        public int? codigoelemento
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

        #region Primary key DigitosModelo

        public const string idDigitosModeloPropertyName = "idDigitosModelo";

        private int _idDigitosModelo = 0;

        public int idDigitosModelo
        {
            get
            {
                return _idDigitosModelo;
            }

            set
            {
                if (_idDigitosModelo == value)
                {
                    return;
                }

                _idDigitosModelo = value;
                RaisePropertyChanged(idDigitosModeloPropertyName);
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

        #endregion

        #region ViewModel Commands

        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<ElementoModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public ElementoControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();

            //Suscribiendo el mensaje
            Messenger.Default.Register<ElementoElementoMensaje>(this, (controlElementoMensaje) => ControlElementoMensaje(controlElementoMensaje));
            listaDigitosElementoModelo = new ObservableCollection<DigitosModelo>(DigitosModelo.GetAll());

            RegisterCommands();
            dlg = new DialogCoordinator();
            enviarMensajeInhabilitar();
            salida = false;
            accesibilidadCuerpo = false;
            activarCarga = false;
        }

        private void ControlElementoMensaje(ElementoElementoMensaje controlElementoMensaje)
        {
            currentEntidad = controlElementoMensaje.elementoMensaje;
            if (currentEntidad.digitosElementoModelo != null)
            {
                currentDigitosElementoModelo = listaDigitosElementoModelo.Single(i => i.idDigitosModelo == currentEntidad.codigoelemento);
                digitosElementoModelo = currentEntidad.digitosElementoModelo;
                codigoelemento = currentEntidad.codigoelemento;
                //currentDigitosElementoModelo.idDigitosModelo=currentEntidad.digitosElementoModelo.idDigitosModelo;
            }
            if (controlElementoMensaje.comando == 1)
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
                if (controlElementoMensaje.comando == 2)
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
                    if (controlElementoMensaje.comando == 5)
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

            Messenger.Default.Unregister<ElementoElementoMensaje>(this, tokenRecepcion);
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
            int cuenta = ElementoModelo.ContarRepetidos(currentEntidad);
            if ((cuenta==0))
            {

                if ((currentEntidad.id == 0))
                {
                    if (ElementoModelo.Insert(currentEntidad, true))
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
                    //}
                }
            }
            else
            {

                    await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción los tipos de documentos", "");
            }
        }

        public async void Modificar()
        {
            if (ElementoModelo.ContarRepetidos(currentEntidad)==1)
            {

                                    if (ElementoModelo.UpdateModelo(currentEntidad, true))
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
                await dlg.ShowMessageAsync(this, "El registro ya existe con esa descripción o el código contable ya existe", "");
            }
        }

        #endregion

        #region Mensajes

        //Procesando el mensaje recibido

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

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            bool cerrado = true;
            Messenger.Default.Send(cerrado, tokenEnvioCierre);
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
                evaluar = !string.IsNullOrEmpty(currentEntidad.descripcion) &&
                           (currentEntidad.descripcion.Length <= maxDescripcion) &&
                           (currentEntidad.codigoelemento>0);
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
            SelectionChangedCommand = new RelayCommand<ElementoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void Copiar()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}



