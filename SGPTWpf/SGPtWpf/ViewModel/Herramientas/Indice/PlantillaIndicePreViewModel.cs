using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model.Modelo.Indice;
using SGPTWpf.Model;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Genericos;

namespace SGPTWpf.ViewModel.Herramientas.Indice
{
    public sealed class PlantillaIndicePreViewModel : ViewModeloBase
    {

        #region Propiedades privadas
        private string tokenRecepcionPrincipal = "Plantillas" + "Herramientas";
        private string tokenEnvio = "PlantillaIndiceController";
        private string tokenRecepcionEntidadSeleccionada = "DatosEntidadSeleccionadaADetallePreview";//Identifica la fuente de un mensaje generico


        public int fuenteCierre = 0;

        #region ViewModel Property : currentFirma 

        public const string currentFirmaPropertyName = "currentFirma";

        private FirmaModelo _currentFirma;

        public FirmaModelo currentFirma
        {
            get
            {
                return _currentFirma;
            }

            set
            {
                if (_currentFirma == value) return;

                _currentFirma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentFirmaPropertyName);
            }
        }

        #endregion

        #region indiceProcedimientos

        public const string indiceProcedimientosPropertyName = "indiceProcedimientos";

        private decimal? _indiceProcedimientos = 0;

        public decimal? indiceProcedimientos
        {
            get
            {
                return _indiceProcedimientos;
            }

            set
            {
                if (_indiceProcedimientos == value)
                {
                    return;
                }

                _indiceProcedimientos = value;
                RaisePropertyChanged(indiceProcedimientosPropertyName);
            }
        }

        #endregion


        #region propiedades Firma

        #region logoFirma

        public const string logoFirmaPropertyName = "logoFirma";

        private byte[] _logoFirma = null;

        public byte[] logoFirma
        {
            get
            {
                return _logoFirma;
            }

            set
            {
                if (_logoFirma == value)
                {
                    return;
                }

                _logoFirma = value;
                RaisePropertyChanged(logoFirmaPropertyName);
            }
        }

        #endregion

        #region Propiedades : razonSocialFirma


        public const string razonSocialFirmaPropertyName = "razonSocialFirma";

        private string _razonSocialFirma = string.Empty;

        public string razonSocialFirma
        {
            get
            {
                return _razonSocialFirma;
            }
            set
            {
                if (_razonSocialFirma == value)
                {
                    return;
                }
                _razonSocialFirma = value;
                RaisePropertyChanged(razonSocialFirmaPropertyName);
            }
        }

        #endregion

        #region Primary key

        public const string idFirmaPropertyName = "idFirma";

        private int _idFirma = 0;

        public int idFirma
        {
            get
            {
                return _idFirma;
            }

            set
            {
                if (_idFirma == value)
                {
                    return;
                }

                _idFirma = value;
                RaisePropertyChanged(idFirmaPropertyName);
            }
        }

        #endregion

        #endregion

        private DialogCoordinator dlg;

        private int numeroProcesoCrudRecibido = 0;


        private bool arranque = true;


        private int idFirmaUnica = 2;//Id de firma a utilizar

        #endregion

        #region Lista de entidades


       #endregion Lista de entidades

        #region Propiedades



        #region ViewModel Property : currentEntidadDetalle Indice Plantilla Modelo

        public const string currentEntidadDetallePropertyName = "currentEntidadDetalle";

        private DetallePlantillaIndiceModelo _currentEntidadDetalle;

        public DetallePlantillaIndiceModelo currentEntidadDetalle
        {
            get
            {
                return _currentEntidadDetalle;
            }

            set
            {
                if (_currentEntidadDetalle == value) return;

                _currentEntidadDetalle = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadDetallePropertyName);
            }
        }

        #endregion


        #region autorizadoPorHerramienta

        public const string autorizadoPorHerramientaPropertyName = "autorizadoPorHerramienta";

        private string _autorizadoPorHerramienta = string.Empty;

        public string autorizadoPorHerramienta
        {
            get
            {
                return _autorizadoPorHerramienta;
            }

            set
            {
                if (_autorizadoPorHerramienta == value)
                {
                    return;
                }

                _autorizadoPorHerramienta = value;
                RaisePropertyChanged(autorizadoPorHerramientaPropertyName);
            }
        }

        #endregion

        #region cantidadVoluntarios

        public const string cantidadVoluntariosPropertyName = "cantidadVoluntarios";

        private decimal? _cantidadVoluntarios = 0;

        public decimal? cantidadVoluntarios
        {
            get
            {
                return _cantidadVoluntarios;
            }

            set
            {
                if (_cantidadVoluntarios == value)
                {
                    return;
                }

                _cantidadVoluntarios = value;
                RaisePropertyChanged(cantidadVoluntariosPropertyName);
            }
        }

        #endregion

        #region cantidadObligatorios

        public const string cantidadObligatoriosPropertyName = "cantidadObligatorios";

        private decimal? _cantidadObligatorios = 0;

        public decimal? cantidadObligatorios
        {
            get
            {
                return _cantidadObligatorios;
            }

            set
            {
                if (_cantidadObligatorios == value)
                {
                    return;
                }

                _cantidadObligatorios = value;
                RaisePropertyChanged(cantidadObligatoriosPropertyName);
            }
        }

        #endregion

        #region indiceObligatorios

        public const string indiceObligatoriosPropertyName = "indiceObligatorios";

        private decimal? _indiceObligatorios= 0;

        public decimal? indiceObligatorios
        {
            get
            {
                return _indiceObligatorios;
            }

            set
            {
                if (_indiceObligatorios== value)
                {
                    return;
                }

                _indiceObligatorios= value;
                RaisePropertyChanged(indiceObligatoriosPropertyName);
            }
        }

        #endregion

        #region Propiedades importadas

        #region ViewModel Properties : listaDetallePlantillaIndiceCompleta

        public const string listaDetallePlantillaIndicePropertyName = "listaDetallePlantillaIndiceCompleta";

        private ObservableCollection<DetallePlantillaIndiceModelo> _listaDetallePlantillaIndice;

        public ObservableCollection<DetallePlantillaIndiceModelo> listaDetallePlantillaIndiceCompleta
        {
            get
            {
                return _listaDetallePlantillaIndice;
            }
            set
            {
                if (_listaDetallePlantillaIndice == value) return;

                _listaDetallePlantillaIndice = value;
                RaisePropertyChanged(listaDetallePlantillaIndicePropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : lista tipo elemento Indice modelo 

        public const string listaTipoElementoCarpetaPropertyName = "listaTipoElementoCarpeta";

        private ObservableCollection<TipoElementoIndiceModelo> _listaTipoElementoCarpeta;

        public ObservableCollection<TipoElementoIndiceModelo> listaTipoElementoCarpeta
        {
            get
            {
                return _listaTipoElementoCarpeta;
            }
            set
            {
                if (_listaTipoElementoCarpeta == value) return;

                _listaTipoElementoCarpeta = value;

                RaisePropertyChanged(listaTipoElementoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista tipo carpeta

        public const string listaTipoCarpetaPropertyName = "listaTipoCarpeta";

        private ObservableCollection<TipoCarpetaModelo> _listaTipoCarpeta;

        public ObservableCollection<TipoCarpetaModelo> listaTipoCarpeta
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

        #region Entidades

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

        #region ViewModel Property : selectedPadreEntidad 

        public const string selectedPadreEntidadPropertyName = "selectedPadreEntidad";

        private DetallePlantillaIndiceModelo _selectedPadreEntidad;

        public DetallePlantillaIndiceModelo selectedPadreEntidad
        {
            get
            {
                return _selectedPadreEntidad;
            }

            set
            {
                if (_selectedPadreEntidad == value) return;

                _selectedPadreEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedPadreEntidadPropertyName);
                if (arranque)
                {
                    arranque = false;
                }
                else
                {
                    if (!(value == null))
                    {
                        if (!(value.iddpi == 0))
                        {
                            int registros = DetallePlantillaIndiceModelo.ContarSubRegistros(_selectedPadreEntidad.idpi) + 1;
                            if (registros == 1)
                            {
                                currentEntidad.ordendpi = Decimal.Add((Decimal)_selectedPadreEntidad.ordendpi, (Decimal)0.01);

                            }
                            else
                            {
                                decimal suma = Decimal.Add((Decimal)0.01, (decimal)0.01 * registros);
                                currentEntidad.ordendpi = Decimal.Add((Decimal)_selectedPadreEntidad.ordendpi, suma);

                            }
                        }
                        currentEntidad.ordendpiPadre = _selectedPadreEntidad.ordendpi;
                    }
                    else
                    {
                        currentEntidad.ordendpi = (decimal)DetallePlantillaIndiceModelo.FindOrden(((int)currentEntidad.idpi));
                        currentEntidad.ordendpiPadre = 0;
                    }
                }
            }
        }

        #endregion

        #region ViewModel Property : SelectedTipoCarpeta

        public const string SelectedTipoCarpetaPropertyName = "SelectedTipoCarpeta";

        private TipoCarpetaModelo _SelectedTipoCarpeta;

        public TipoCarpetaModelo SelectedTipoCarpeta
        {
            get
            {
                return _SelectedTipoCarpeta;
            }

            set
            {
                if (_SelectedTipoCarpeta == value) return;

                _SelectedTipoCarpeta = value;
                RaisePropertyChanged(SelectedTipoCarpetaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : SelectedTipoElementoIndiceModelo

        public const string SelectedTipoElementoIndiceModeloPropertyName = "SelectedTipoElementoIndiceModelo";

        private TipoElementoIndiceModelo _SelectedTipoElementoIndiceModelo;

        public TipoElementoIndiceModelo SelectedTipoElementoIndiceModelo
        {
            get
            {
                return _SelectedTipoElementoIndiceModelo;
            }

            set
            {
                if (_SelectedTipoElementoIndiceModelo == value) return;

                _SelectedTipoElementoIndiceModelo = value;
                RaisePropertyChanged(SelectedTipoElementoIndiceModeloPropertyName);
                //Asignación del tipo de programa
                //currentEntidad.idTh = _SelectedTipoElementoIndiceModelo.id;
            }
        }

        #endregion


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


        #region Propiedades : descripcionDpiPadre


        public const string descripcionDpiPadrePropertyName = "descripcionDpiPadre";

        private string _descripcionDpiPadre = string.Empty;

        public string descripcionDpiPadre
        {
            get
            {
                return _descripcionDpiPadre;
            }
            set
            {
                if (_descripcionDpiPadre == value)
                {
                    return;
                }
                _descripcionDpiPadre = value;
                RaisePropertyChanged(descripcionDpiPadrePropertyName);
            }
        }

        #endregion

        #region Propiedades : descripciondpi


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

        #region Propiedades : tipoCarpetaIndice


        public const string tipoCarpetaIndicePropertyName = "tipoCarpetaIndice";

        private string _tipoCarpetaIndice = string.Empty;

        public string tipoCarpetaIndice
        {
            get
            {
                return _tipoCarpetaIndice;
            }
            set
            {
                if (_tipoCarpetaIndice == value)
                {
                    return;
                }
                _tipoCarpetaIndice = value;
                RaisePropertyChanged(tipoCarpetaIndicePropertyName);
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




        #endregion



        #endregion

        #endregion


        #region Propiedades de ventanas

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


        #region nombreHerramientaVista

        public const string nombreHerramientaVistaPropertyName = "nombreHerramientaVista";

        private string _nombreHerramientaVista = string.Empty;

        public string nombreHerramientaVista
        {
            get
            {
                return _nombreHerramientaVista;
            }

            set
            {
                if (_nombreHerramientaVista == value)
                {
                    return;
                }

                _nombreHerramientaVista = value;
                RaisePropertyChanged(nombreHerramientaVistaPropertyName);
            }
        }

        #endregion


        #endregion

        #region ViewModel Commands

        public RelayCommand SalirCommand { get; set; }

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public PlantillaIndicePreViewModel()
        {
            //Llenado de encabezado
            try
            {
                currentFirma = FirmaModelo.Find(idFirmaUnica);//Solo hay un registro
            }
            catch (Exception)
            {
                currentFirma = new FirmaModelo();
                currentFirma.razonSocialFirma = "Corporación de Contadores de El Salvador";
                currentFirma.logofirma = null;
            }
            if (!(currentFirma == null))
            {
                razonSocialFirma = currentFirma.razonSocialFirma;
                logoFirma = currentFirma.logofirma;
            }
            else
            {
                razonSocialFirma = "Corporación de Contadores de El Salvador";

            }
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal,(herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
            Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcionEntidadSeleccionada, (plantillaIndiceModelo) => ControlPlantillaIndiceModelo(plantillaIndiceModelo));
            indiceProcedimientos=0;
            accesibilidadWindow = true;
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            enviarMensajeInhabilitar();
        }


        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
        {
            //Pendiente optimizar
            currentUsuario = herramientaUsuarioValidadoMensaje.usuarioModeloMensaje;
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
        }
        private void ControlPlantillaIndiceModelo(PlantillaIndiceMensaje plantillaIndiceModelo)
        {
            currentEntidadPlantillaIndice = plantillaIndiceModelo.elementoMensaje;
            encabezadoPantalla = "Indice de auditoría";
           
            cantidadObligatorios = 0;
            cantidadVoluntarios = 0;
            listaIndicesDetalle = new ObservableCollection<DetallePlantillaIndiceModelo>(DetallePlantillaIndiceModelo.GetAllPublicacion(currentEntidadPlantillaIndice.idpi));
            if (listaIndicesDetalle != null)
            {
                tipoCarpetaIndice = currentEntidadPlantillaIndice.descripciontc;
            }
            decimal contador = 1;
            decimal contadorProcedimiento = 1;

           //Basado en el  supuesto que la lista viene ordenada con base a ordenDh
            foreach (DetallePlantillaIndiceModelo item in listaIndicesDetalle)
            {
                if (item.obligatoriodpi)
                {
                    contador++;
                }
                else
                {
                    contadorProcedimiento++;
                }
                cantidadVoluntarios = contadorProcedimiento - 1;
                cantidadObligatorios = contador-1;
                //Desuscribir mensaje
                Messenger.Default.Unregister<PlantillaIndiceModelo>(this,tokenRecepcionEntidadSeleccionada);
            }
        }


        #endregion



        private void Salir()
        {
                enviarMensajeFinProceso();
                enviarMensajeHabilitar();
                CloseWindow();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public void Modificar()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        private bool ControlVentanaMensaje(CatalogoMensaje controlVentanaMensaje)
        {
            if (controlVentanaMensaje.mensaje == 0)
            {
                return true;
            }
            else
            {
                fuenteCierre = 1;
                CloseWindow();
                return false;

            }
        }
        //Guarda los cambios en la lista una vez se cierra la ventana
        public void enviarMensaje(bool registroCreado)
        {
            //Creando el mensaje de cierre
            //VentanaControllerToHerramientasViewMensaje cierre = new VentanaControllerToHerramientasViewMensaje();
            VentanaControllerToHerramientasViewMensaje cierre = new VentanaControllerToHerramientasViewMensaje();
            cierre.activarVentana = true;
            cierre.registroCreado = registroCreado;
            Messenger.Default.Send(cierre);
        }

        public void enviarMensajeFinProceso()
        {
            //Se crea el mensaje
            mensajeDeCierreCrud mensaje = new mensajeDeCierreCrud();
            mensaje.numeroProcesoCrud = numeroProcesoCrudRecibido+1;
            //numeroProcesoCrudRecibido++;
            Messenger.Default.Send(mensaje, tokenEnvio);
        }
        #endregion

        #region Metodos de apoyo

        public bool CanSaveNuevo()
        {
            return true;
        }
        #endregion

        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            SalirCommand = new RelayCommand(Salir);
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


    }
}

