using CapaDatos;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Indice;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas.Indice
{
    public sealed class DetallePlantillaIndiceViewModel : ViewModeloBase
    {
        #region Propiedades privadas de control

        #region  tokenRecepcionPrincipal

        private string _tokenRecepcionPrincipal;
        private string tokenRecepcionPrincipal
        {
            get { return _tokenRecepcionPrincipal; }
            set { _tokenRecepcionPrincipal = value; }
        }

        #endregion

        #region  tokenRecepcionEntidadSeleccionada

        private string _tokenRecepcionEntidadSeleccionada;
        private string tokenRecepcionEntidadSeleccionada
        {
            get { return _tokenRecepcionEntidadSeleccionada; }
            set { _tokenRecepcionEntidadSeleccionada = value; }
        }

        #endregion

        #region  tokenEnvio

        private string _tokenEnvio;
        private string tokenEnvio
        {
            get { return _tokenEnvio; }
            set { _tokenEnvio = value; }
        }

        #endregion

        #region  tokenEnvioVista

        private string _tokenEnvioVista;
        private string tokenEnvioVista
        {
            get { return _tokenEnvioVista; }
            set { _tokenEnvioVista = value; }
        }

        #endregion

        #region  tokenRecepcionCierre

        private string _tokenRecepcionCierre;
        private string tokenRecepcionCierre
        {
            get { return _tokenRecepcionCierre; }
            set { _tokenRecepcionCierre = value; }
        }

        #endregion

        #region  comando

        private int _comando;
        private int comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        #endregion

        #region  numeroProcesoCrud

        private int _numeroProcesoCrud;
        private int numeroProcesoCrud
        {
            get { return _numeroProcesoCrud; }
            set { _numeroProcesoCrud = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
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

        #region ViewModel Property : currentUsuarioModelo UsuarioModelo

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

        #endregion

        #region ViewModel Properties

        #region Indice



        #endregion

        #region ViewModel Properties publicas

        #region ViewModel Properties : listaIndicesDetalle

        public const string listaIndicesDetallePropertyName = "listaIndicesDetalle";

        private ObservableCollection<DetallePlantillaIndiceModelo> _listaIndicesDetalle;

        public ObservableCollection<DetallePlantillaIndiceModelo> listaIndicesDetalle
        {
            get
            {
                return _listaIndicesDetalle;
            }

            set
            {
                if (_listaIndicesDetalle == value) return;

                _listaIndicesDetalle = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaIndicesDetallePropertyName);
            }
        }

        #endregion

        #region  Primary key detalle indice

        public const string iddpiPropertyName = "iddpi";

        private int? _iddpi = 0;

        public int? iddpi
        {
            get
            {
                return _iddpi;
            }

            set
            {
                if (_iddpi == value)
                {
                    return;
                }

                _iddpi = value;
                RaisePropertyChanged(iddpiPropertyName);
            }
        }

        #endregion

        #region  Primary key de Tipo de carpeta idtc

        public const string idtcPropertyName = "idtc";

        private int _idtc = 0;

        public int idtc
        {
            get
            {
                return _idtc;
            }

            set
            {
                if (_idtc == value)
                {
                    return;
                }

                _idtc = value;
                RaisePropertyChanged(idtcPropertyName);
            }
        }

        #endregion

        #region  Primary key tipo de elemento del indice idtei

        public const string idteiPropertyName = "idtei";

        private int _idtei = 0;

        public int idtei
        {
            get
            {
                return _idtei;
            }

            set
            {
                if (_idtei == value)
                {
                    return;
                }

                _idtei = value;
                RaisePropertyChanged(idteiPropertyName);
            }
        }

        #endregion

        #region  Primary key Plantilla de indice idpi

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

                _idpi = value;
                RaisePropertyChanged(idpiPropertyName);
            }
        }

        #endregion

        #region  Primary key detalle indice padre iddpi

        public const string detiddpiPropertyName = "detiddpi";

        private int _detiddpi = 0;

        public int detiddpi
        {
            get
            {
                return _detiddpi;
            }

            set
            {
                if (_detiddpi == value)
                {
                    return;
                }

                _detiddpi = value;
                RaisePropertyChanged(detiddpiPropertyName);
            }
        }

        #endregion


        #region descripciondpi del Detalle descripciondpi

        public const string descripciondpiPropertyName = "descripciondpi";

        private string _descripciondpi = string.Empty;

        public string descripciondpi
        {
            get
            {
                return _descripciondpi;
            }

            set
            {
                if (_descripciondpi == value)
                {
                    return;
                }

                _descripciondpi = value;
                RaisePropertyChanged(descripciondpiPropertyName);
            }
        }

        #endregion

        #region ordendpi Orden del detalle

        public const string ordendpiPropertyName = "ordendpi";

        private decimal? _ordendpi = 0;

        public decimal? ordendpi
        {
            get
            {
                return _ordendpi;
            }

            set
            {
                if (_ordendpi == value)
                {
                    return;
                }

                _ordendpi = value;
                RaisePropertyChanged(ordendpiPropertyName);
            }
        }

        #endregion

        #region referenciadpi del Detalle referenciadpi

        public const string referenciadpiPropertyName = "referenciadpi";

        private string _referenciadpi = string.Empty;

        public string referenciadpi
        {
            get
            {
                return _referenciadpi;
            }

            set
            {
                if (_referenciadpi == value)
                {
                    return;
                }

                _referenciadpi = value;
                RaisePropertyChanged(referenciadpiPropertyName);
            }
        }

        #endregion

        #region obligatoriodpi indica si  es obligatorio el documento

        public const string obligatoriodpiPropertyName = "obligatoriodpi";

        private bool _obligatoriodpi = false;

        public bool obligatoriodpi
        {
            get
            {
                return _obligatoriodpi;
            }

            set
            {
                if (_obligatoriodpi == value)
                {
                    return;
                }

                _obligatoriodpi = value;
                RaisePropertyChanged(obligatoriodpiPropertyName);
            }
        }

        #endregion



        #region sistemadpi

        public const string sistemadpiPropertyName = "sistemadpi";

        private bool _sistemadpi = false;

        public bool sistemadpi
        {
            get
            {
                return _sistemadpi;
            }

            set
            {
                if (_sistemadpi == value)
                {
                    return;
                }

                _sistemadpi = value;
                RaisePropertyChanged(sistemadpiPropertyName);
            }
        }

        #endregion

        #region estadodpi
        public const string estadodpiPropertyName = "estadodpi";

        private string _estadodpi = string.Empty;

        public string estadodpi
        {
            get
            {
                return _estadodpi;
            }

            set
            {
                if (_estadodpi == value)
                {
                    return;
                }

                _estadodpi = value;
                RaisePropertyChanged(estadodpiPropertyName);
            }
        }
        #endregion

        #region Nombre de usuario

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

        #region ordendpiPadre Orden del detalle

        public const string ordendpiPadrePropertyName = "ordendpiPadre";

        private decimal? _ordendpiPadre = 0;

        public decimal? ordendpiPadre
        {
            get
            {
                return _ordendpiPadre;
            }

            set
            {
                if (_ordendpiPadre == value)
                {
                    return;
                }

                _ordendpiPadre = value;
                RaisePropertyChanged(ordendpiPadrePropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetallePlantillaIndiceModelo _currentEntidad;

        public DetallePlantillaIndiceModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidad = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion


        #region ViewModel Property : currentEntidadDetalleIndice

        public const string currentEntidadDetalleIndicePropertyName = "currentEntidadDetalleIndice";

        private DetallePlantillaIndiceModelo _currentEntidadDetalleIndice;

        public DetallePlantillaIndiceModelo currentEntidadDetalleIndice
        {
            get
            {
                return _currentEntidadDetalleIndice;
            }

            set
            {
                if (_currentEntidadDetalleIndice == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadDetalleIndice = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadDetalleIndicePropertyName);
            }
        }

        #endregion


        #region Entidad en uso de Indice

        #region ViewModel Property : currentEntidadPlantillaIndice

        public const string currentEntidadPlantillaIndicePropertyName = "currentEntidadPlantillaIndice";

        private PlantillaIndiceModelo _currentEntidadPlantillaIndice;

        public PlantillaIndiceModelo currentEntidadPlantillaIndice
        {
            get
            {
                return _currentEntidadPlantillaIndice;
            }

            set
            {
                if (_currentEntidadPlantillaIndice == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadPlantillaIndice = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPlantillaIndicePropertyName);
            }
        }

        #endregion


        #region ViewModel Property : currentEntidadPlantillaIndiceDetalleIndice

        public const string currentEntidadPlantillaIndiceDetalleIndicePropertyName = "currentEntidadPlantillaIndiceDetalleIndice";

        private DetallePlantillaIndiceModelo _currentEntidadPlantillaIndiceDetalleIndice;

        public DetallePlantillaIndiceModelo currentEntidadPlantillaIndiceDetalleIndice
        {
            get
            {
                return _currentEntidadPlantillaIndiceDetalleIndice;
            }

            set
            {
                if (_currentEntidadPlantillaIndiceDetalleIndice == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadPlantillaIndiceDetalleIndice = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPlantillaIndiceDetalleIndicePropertyName);
            }
        }

        #endregion

        #endregion

        #endregion


        #region DetallePlantillaIndiceMainModel 


        private MainModel _DetallePlantillaIndiceMainModel = null;

        public MainModel DetallePlantillaIndiceMainModel
        {
            get
            {
                return _DetallePlantillaIndiceMainModel;
            }

            set
            {
                _DetallePlantillaIndiceMainModel = value;
            }
        }
        #endregion

        #endregion



        #endregion


        public DetallePlantillaIndiceViewModel()
        {
            _tokenRecepcionVista = "EncargoPlanificacionIndiceCambioOrden";
            _accesibilidadWindow = true;
            _tokenRecepcionPrincipal = "Plantillas" + "Herramientas";
            _tokenRecepcionEntidadSeleccionada = "DatosEntidadSeleccionadaADetalle";//Identifica la fuente de un mensaje generico
            _tokenEnvio = "DetalleDatosElementoAController";//Identifica la fuente de un mensaje generico
            _tokenEnvioVista = "DetalleDatosElementoAVista";//Identifica la fuente de un mensaje generico
            _tokenRecepcionCierre = "ControllerCerradoAViewModel";//Identifica la fuente de un mensaje generico
            _comando = 0;
            _numeroProcesoCrud = 0;
            RegistrarComandos();
            dlg = new DialogCoordinator();
            currentEntidadDetalleIndice = null;
            currentEntidad = null;
            _listaIndicesDetalle = new ObservableCollection<DetallePlantillaIndiceModelo>();
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal, (herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
            //Messenger.Default.Register<PlantillaIndiceCierreMensaje>(this, (plantillaIndiceCierreMensaje) => ControlPlantillaIndiceCierreMensaje(plantillaIndiceCierreMensaje));
            Messenger.Default.Register<PlantillaIndiceModelo>(this, tokenRecepcionEntidadSeleccionada, (plantillaIndiceModelo) => ControlPlantillaIndiceModelo(plantillaIndiceModelo));
            inicialesusuario = "";
            DetallePlantillaIndiceMainModel = new MainModel();
            Messenger.Default.Register<bool>(this, tokenRecepcionVista, (recepcionDatos) => ControlCambioLista(recepcionDatos));
        }

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            DetallePlantillaIndiceMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 2:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 3:
                    break;
                case 4:
                    //caso de vista de programa
                    break;
                case 5://Programa vista
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    accesibilidadWindow = true;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    break;
                case 7:
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                case 8:
                    //if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    //{
                    //    actualizarLista();
                    //}

                    //enviarMensajeHabilitar();
                    //controlVentanaCrearMensaje
                    break;
                case 9://Desplazamiento a ver el detalle del usuario
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    break;
                default:
                    break;
            }
            comando = 0;
            currentEntidad = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierre);
            finComando();
        }
        private void ControlCambioLista(bool recepcionDatos)
        {
            if (recepcionDatos)
            {
                BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    guardarLista();
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    //Nada se deja la lista actualizada;
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }
        private void ControlPlantillaIndiceModelo(PlantillaIndiceModelo plantillaIndiceModelo)
        {
            currentEntidadPlantillaIndice = plantillaIndiceModelo;
            //currentEntidad = null;

            //Messenger.Default.Unregister<PlantillaIndiceModelo>(this, tokenRecepcionEntidadSeleccionada);//El usuario  no puede cambiar a menos que vuelva a ingresar
            actualizarLista();
        }


        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
        {
            //Pendiente optimizar
            currentUsuario = herramientaUsuarioValidadoMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = herramientaUsuarioValidadoMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
        }


        #region ShowWindowCommand

        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            BuscarCommand = new RelayCommand(Buscar, CanCommand);
            //DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            XImprimirCommand = new RelayCommand(XImprimir, CanCommand);
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanCommand);
            /*SelectionChangedCommand = new RelayCommand<DetallePlantillaIndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
                enviarInhabilitacionMenu();
            });*/
        }


        #endregion

        #region ViewModel Commands

        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand BuscarCommand { get; set; }
        //public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }

        //public RelayCommand<DetallePlantillaIndiceModelo> SelectionChangedCommand { get; set; }

        //public RelayCommand<LegalNormaModelo> SelectionChangedCommand { get; set; }
        #endregion


        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();
            DetallePlantillaIndiceMainModel.TypeName = "DetallePlantillaIndiceCrearView";
            currentEntidad = new DetallePlantillaIndiceModelo();
            currentEntidad.ordendpi = listaIndicesDetalle.Count + 1;
            currentEntidad.idpi = currentEntidadPlantillaIndice.idpi;
            comando = 1;
            enviarDatosPlantillaIndice();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                DetallePlantillaIndiceMainModel.TypeName = "DetallePlantillaIndiceEditarView";
                comando = 2;
                currentEntidad.idpi = currentEntidadPlantillaIndice.idpi;
                enviarDatosPlantillaIndice(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
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
                DetallePlantillaIndiceMainModel.TypeName = "DetallePlantillaIndiceConsultarView";
                comando = 3;
                enviarDatosPlantillaIndice();
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
                {
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (DetallePlantillaIndiceModelo.Delete((int)currentEntidad.iddpi))
                    //if (DetallePlantillaIndiceModelo.Delete(currentEntidad.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        actualizarLista();
                        currentEntidad = DetallePlantillaIndiceModelo.Clear(currentEntidad);
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }
        public bool CanSave()
        {
            return !(currentEntidad.idpi == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripciondpi);
        }

        public bool CanCommand()
        {
            if (currentEntidad == null || currentEntidad.iddpi == 0)
            {

                return false;
            }
            else
            {

                return true;
            }
        }
        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private void VistaPrograma()
        {
            throw new NotImplementedException();
        }

        private void XImprimir()
        {
            throw new NotImplementedException();
        }

        private void actualizarLista()
        {
            if (currentEntidadPlantillaIndice != null)
            {
                try
                {
                    if (listaIndicesDetalle.Count>0)
                    {
                        guardarLista();
                    }
                    listaIndicesDetalle = new ObservableCollection<DetallePlantillaIndiceModelo>(DetallePlantillaIndiceModelo.GetAll(currentEntidadPlantillaIndice.idpi));
                }
                catch (Exception e)
                {
                    if (e.Source != null)
                    {
                        dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas de índices " + e.Message, "");
                    }
                }
            }
            else
            {
                listaIndicesDetalle = new ObservableCollection<DetallePlantillaIndiceModelo>();
            }
            enviarListaVista();
        }

        #endregion


        #region Mensajes
        public void enviarDatosPlantillaIndice()
        {
            //Se crea el mensaje
            DetallePlantillaIndiceCrudMensaje elemento = new DetallePlantillaIndiceCrudMensaje();
            elemento.detallePlantillaIndiceModelo = currentEntidad;
            elemento.listaElementos = listaIndicesDetalle;
            elemento.numeroProcesoCrudEnviado = numeroProcesoCrud;
            elemento.comandoCrud = comando;
            elemento.plantillaIndiceModelo = currentEntidadPlantillaIndice;
            elemento.usuarioModeloValidado = currentUsuarioModelo;
            numeroProcesoCrud = numeroProcesoCrud + 1;//Se incrementa para  proximo envio
            Messenger.Default.Send(elemento, tokenEnvio);
        }

        public void enviarListaVista()
        {
            //Se crea el mensaje
            Messenger.Default.Send(listaIndicesDetalle, tokenEnvioVista);
        }

        public void guardarLista()
        {
            //Reordenar lista
            foreach (DetallePlantillaIndiceModelo item in listaIndicesDetalle)
            {
                if (!item.guardadoBase)
                {
                    DetallePlantillaIndiceModelo.UpdateModeloReodenar(item);
                }
            }
        }
        //Reordenar lista


        #endregion
        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            Messenger.Default.Register<int>(this, tokenRecepcionCierre, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierre);
            //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
    }
}