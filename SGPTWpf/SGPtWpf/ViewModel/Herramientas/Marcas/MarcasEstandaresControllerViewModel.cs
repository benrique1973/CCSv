using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using SGPTWpf.Model.Modelo;
using SGPTWpf.Messages.Administracion.MarcasEstandares;
using CapaDatos;
using System;
using SGPTWpf.Model.Modelo.Auxiliares;
using System.Linq;
using System.Windows.Media;
using System.Windows;

namespace SGPTWpf.ViewModel.Herramientas
{

    public sealed class MarcasEstandaresControllerViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private bool cerradoFinalVentana = false;//Controla el cierre de la ventana

        private int numeroProcesoCrudRecibido = 0;

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

        private int maxDescripcion = 100;

        private DialogCoordinator dlg;

        #endregion

        #region ViewModel Properties

        #region ViewModel Properties : listaEntidad

        public const string listaEntidadPropertyName = "listaEntidad";

        private ObservableCollection<MarcasEstandaresModelo> _listaEntidad;

        public ObservableCollection<MarcasEstandaresModelo> listaEntidad
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

        #region ViewModel Properties : listaFuentes

        public const string listaFuentesPropertyName = "listaFuentes";

        private ObservableCollection<FontFamily> _listaFuentes;

        public ObservableCollection<FontFamily> listaFuentes
        {
            get
            {
                return _listaFuentes;
            }
            set
            {
                if (_listaFuentes == value) return;

                _listaFuentes = value;

                RaisePropertyChanged(listaFuentesPropertyName);
            }
        }
        #endregion

        #region ViewModel Properties : listaSimbolos

        public const string listaSimbolosPropertyName = "listaSimbolos";

        private ObservableCollection<MarcasSimbolos> _listaSimbolos;

        public ObservableCollection<MarcasSimbolos> listaSimbolos
        {
            get
            {
                return _listaSimbolos;
            }
            set
            {
                if (_listaSimbolos == value) return;

                _listaSimbolos = value;

                RaisePropertyChanged(listaSimbolosPropertyName);
                if (currentSimbolo != null)
                {
                    simbolo = currentSimbolo.simbolo;
                }
            }
        }

        #endregion

        #region ViewModel Properties : listaCorrelativos

        public const string listaCorrelativosPropertyName = "listaCorrelativos";

        private ObservableCollection<CorrelativoModelo> _listaCorrelativos;

        public ObservableCollection<CorrelativoModelo> listaCorrelativos
        {
            get
            {
                return _listaCorrelativos;
            }
            set
            {
                if (_listaCorrelativos == value) return;

                _listaCorrelativos = value;
                RaisePropertyChanged(listaCorrelativosPropertyName);
            }
        }

        #endregion

        #region Propiedades : significadoMe


        public const string descripcionPropertyName = "significadoMe";

        private string _descripcion = string.Empty;


        public string significadoMe
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


        public const string idPropertyName = "idMe";

        private int _id = 0;

        public int idMe
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

        #region correlativoListaFuente


        public const string correlativoListaFuentesPropertyName = "correlativoListaFuentes";

        private int _correlativoListaFuentes = 0;

        public int correlativoListaFuentes
        {
            get
            {
                return _correlativoListaFuentes;
            }

            set
            {
                if (_correlativoListaFuentes == value)
                {
                    return;
                }

                _correlativoListaFuentes = value;
                RaisePropertyChanged(correlativoListaFuentesPropertyName);
            }
        }

        #endregion

        #region elegido


        public const string elegidoPropertyName = "elegido";

        private int _elegido = 0;

        public int elegido
        {
            get
            {
                return _elegido;
            }

            set
            {
                if (_elegido == value)
                {
                    return;
                }

                _elegido = value;
                RaisePropertyChanged(elegidoPropertyName);
            }
        }

        #endregion

        #region Tamaño fuente


        public const string correlativoPropertyName = "correlativo";

        private CorrelativoModelo _correlativo;

        public CorrelativoModelo correlativo
        {
            get
            {
                return _correlativo;
            }

            set
            {
                if (_correlativo == value)
                {
                    return;
                }

                _correlativo = value;
                RaisePropertyChanged(correlativoPropertyName);
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

        #region marcame


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

        #region source


        public const string sourcePropertyName = "source";

        private string _source = string.Empty;

        public string source
        {
            get
            {
                return _source;
            }

            set
            {
                if (_source == value)
                {
                    return;
                }

                _source = value;
                RaisePropertyChanged(sourcePropertyName);
            }
        }

        #endregion

        #region simbolo


        public const string simboloPropertyName = "simbolo";

        private string _simbolo = string.Empty;

        public string simbolo
        {
            get
            {
                return _simbolo;
            }

            set
            {
                if (_simbolo == value)
                {
                    return;
                }

                _simbolo = value;
                RaisePropertyChanged(simboloPropertyName);
            }
        }

        #endregion

        #region tipografiame


        public const string tipografiamePropertyName = "tipografiame";

        private string _tipografiame = string.Empty;

        public string tipografiame
        {
            get
            {
                return _tipografiame;
            }

            set
            {
                if (_tipografiame == value)
                {
                    return;
                }

                _tipografiame = value;
                RaisePropertyChanged(tipografiamePropertyName);
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

        #endregion

        #region entidad de currentSimbolo en uso

        #region ViewModel Property : currentSimbolo

        public const string currentSimboloPropertyName = "currentSimbolo";

        private MarcasSimbolos _currentSimbolo;

        public MarcasSimbolos currentSimbolo
        {
            get
            {
                return _currentSimbolo;
            }

            set
            {
                if (_currentSimbolo == value) return;

                _currentSimbolo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentSimboloPropertyName);
                /*if(_currentSimbolo!=null&& _currentSimbolo.simbolo!=""&& listaSimbolos!=null)
                { 
                    for (int i = 0; i <= listaSimbolos.Count; i++)
                    {
                        listaSimbolos[elegido].elegido = 0;
                        if (listaSimbolos[i].simbolo == _currentSimbolo.simbolo)
                        {
                            listaSimbolos[i].elegido = 1;
                            _currentSimbolo.elegido = 1;
                            elegido = i;
                            i = listaFuentes.Count;
                        }
                    }
                }*/
            }
        }

        #endregion

        #endregion


        #region ViewModel Properties : currenFuentes

        public const string currenFuentesPropertyName = "currenFuentes";

        private FontFamily _currenFuentes;

        public FontFamily currenFuente
        {
            get
            {
                return _currenFuentes;
            }
            set
            {
                if (_currenFuentes == value) return;

                _currenFuentes = value;
                RaisePropertyChanged(currenFuentesPropertyName);
                source = currenFuente.Source;
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

        #endregion

        #region ViewModel Commands
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<MarcasSimbolos> SelectionChangedCommand { get; set; }

        #endregion
        
        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the catalogosViewModel class.
        /// </summary>


        public MarcasEstandaresControllerViewModel()
        {
            //Suscribiendo el mensaje
            listaSimbolos = MarcasSimbolos.generarListaSimbolos();
            Messenger.Default.Register<MarcasEstandaresMensaje>(this, (marcasEstandaresMensaje) => ControlMarcasEstandaresMensaje(marcasEstandaresMensaje));
            RegisterCommands();
            listaCorrelativos = CorrelativoModelo.generarListaCorrelativo(8, 33);
            correlativo = new CorrelativoModelo(10);
            currentSimbolo =new MarcasSimbolos ();
            currenFuente = new FontFamily();
            correlativoListaFuentes=0;
            dlg = new DialogCoordinator();
            listaFuentes =FuenteFamilia.listaFuentes();
            enviarMensajeInhabilitar();
            tipografiame = "Arial";
            source = "Arial";
            accesibilidadWindow = true;
            elegido = 0;
            visibilidadCrear = Visibility.Visible;
            visibilidadEditar = Visibility.Collapsed;
            visibilidadConsultar = Visibility.Collapsed;
        }

        private void ControlMarcasEstandaresMensaje(MarcasEstandaresMensaje marcasEstandaresMensaje)
        {
            currentEntidad = marcasEstandaresMensaje.elementoMensaje;
            listaEntidad = marcasEstandaresMensaje.listaMensaje;
            numeroProcesoCrudRecibido = marcasEstandaresMensaje.numeroProcesoCrudEnviado + 1;
             if (marcasEstandaresMensaje.comandoCrud == 2)
            {
                currentSimbolo = listaSimbolos.Single(j => j.simbolo == currentEntidad.marcame);
                correlativo = listaCorrelativos.Single(j => j.correlativo ==(int) currentEntidad.tamaniotipografiame);
                for (int i= 0; i <= listaFuentes.Count; i++)
                {
                    if (listaFuentes[i].Source == currentEntidad.tipografiame)
                    {
                        currenFuente = listaFuentes[i];
                        correlativoListaFuentes = i;
                        i = listaFuentes.Count;
                    }

                }
                accesibilidadWindow = true;
                source = currentEntidad.tipografiame;
                marcame = currentEntidad.marcame;
                significadoMe = currentEntidad.significadoMe;
                visibilidadCrear = Visibility.Collapsed;
                visibilidadEditar = Visibility.Visible;
                visibilidadConsultar = Visibility.Collapsed;
            }
            else
            {

                if (marcasEstandaresMensaje.comandoCrud == 3)
                {
                    currentSimbolo = listaSimbolos.Single(j => j.simbolo == currentEntidad.marcame);
                    correlativo = listaCorrelativos.Single(j => j.correlativo == (int)currentEntidad.tamaniotipografiame);
                    for (int i = 0; i <= listaFuentes.Count; i++)
                    {
                        if (listaFuentes[i].Source == currentEntidad.tipografiame)
                        {
                            currenFuente = listaFuentes[i];
                            correlativoListaFuentes = i;
                            i = listaFuentes.Count;
                        }

                    }
                    accesibilidadWindow = false;
                    source = currentEntidad.tipografiame;
                    marcame = currentEntidad.marcame;
                    significadoMe = currentEntidad.significadoMe;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                }

            }
            Messenger.Default.Unregister<MarcasEstandaresMensaje>(this);
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
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
            if (!(MarcasEstandaresModelo.FindTexto(currentEntidad.significadoMe)))
            {
                if (!string.IsNullOrEmpty(currentEntidad.significadoMe))
                {

                    if (significadoMe.Length <= maxDescripcion)
                    {
                        if (string.IsNullOrEmpty(significadoMe))
                        {
                            significadoMe = currentEntidad.significadoMe;
                        }
                        else
                        {
                            currentEntidad.significadoMe = significadoMe;
                        }
                            currentEntidad.marcame = currentSimbolo.simbolo;
                            currentEntidad.tamaniotipografiame = correlativo.correlativo;
                        if (currenFuente != null && currenFuente.Source!=null)
                            {
                                currentEntidad.tipografiame = currenFuente.Source;
                            }
                        else
                            {
                            currentEntidad.tipografiame = listaFuentes[15].Source;
                            }
                            if (simboloUnico(currentEntidad.marcame, listaEntidad) == 0)
                            {
                                if (MarcasEstandaresModelo.Insert(currentEntidad, true))
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
                                await dlg.ShowMessageAsync(this, "El símbolo ya tiene otro significado,", "seleccione otro símbolo");
                            }
                    }
                    else
                    {
                        //Maximo de 100
                        //Mensaje en caso de indice mayor
                        await dlg.ShowMessageAsync(this, "La significadoMe excede el maximo permitido", "");
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
                //Se reactiva el registro
                if ((MarcasEstandaresModelo.FindTextoReturnIdBorrados(currentEntidad.significadoMe)==1))
                    {
                        currentEntidad.marcame = currentSimbolo.simbolo;
                        currentEntidad.tamaniotipografiame = correlativo.correlativo;
                        currentEntidad.tipografiame = currenFuente.Source;
                    if (simboloUnico(currentEntidad.marcame, listaEntidad) == 0)
                    {
                        if (MarcasEstandaresModelo.UpdateBorradoModelo(currentEntidad, true))
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
                        await dlg.ShowMessageAsync(this, "El símbolo ya tiene otro significado,", "seleccione otro símbolo");
                    }
                }
            }
        }

        public async void Modificar()
        {
            if ((MarcasEstandaresModelo.FindTextoReturnId(currentEntidad.significadoMe) <= 1))
            {
                if (!string.IsNullOrEmpty(currentEntidad.significadoMe))
                {

                    if (currentEntidad.significadoMe.Length <= maxDescripcion)
                    {
                        currentEntidad.marcame = currentSimbolo.simbolo;
                        currentEntidad.tamaniotipografiame = correlativo.correlativo;
                        currentEntidad.tipografiame = currenFuente.Source;
                        if (simboloUnico(currentEntidad.marcame, listaEntidad)==1)
                        {
                            if (MarcasEstandaresModelo.UpdateModelo(currentEntidad, true))
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
                            await dlg.ShowMessageAsync(this, "El símbolo ya tiene otro significado,", "seleccione otro símbolo");
                        }
                    }
                    else
                    {
                        //Mensaje en caso de indice mayor
                        await dlg.ShowMessageAsync(this, "La descripcion excede el maximo permitido", "");
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
            MarcasEstandaresCierreMensaje mensaje = new MarcasEstandaresCierreMensaje();
            mensaje.numeroProcesoCrud = numeroProcesoCrudRecibido;
            Messenger.Default.Send<MarcasEstandaresCierreMensaje>(mensaje);
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
                evaluar = !string.IsNullOrEmpty(currentEntidad.significadoMe) &&
                           (currentEntidad.significadoMe.Length <= maxDescripcion) &&
                           !(currentSimbolo.simbolo=="");
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
            SelectionChangedCommand = new RelayCommand<MarcasSimbolos>(entidad =>
            {
                if (entidad == null) return;
                currentSimbolo = entidad;
            });
        }

        #region Verifica unicidad
        //Cada marca debe ser única
        public int  simboloUnico(string marca, ObservableCollection<MarcasEstandaresModelo> listaBusqueda)
        {
            int numeroRegistros;
            string marcame = marca.ToUpper();
            numeroRegistros = listaBusqueda.Where(j => j.marcame.ToUpper() == marcame).Count();
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
    }

}
