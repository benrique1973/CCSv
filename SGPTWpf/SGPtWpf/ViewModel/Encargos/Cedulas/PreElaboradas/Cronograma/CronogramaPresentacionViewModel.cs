using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model.Modelo.detalleherramientas;
using System.Windows;
using SGPTmvvm.Soporte;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.Model;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTmvvm.Model;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.PreElaboradas.Cronograma
{
    public sealed class CronogramaPresentacionViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        #region salidaRealizada

        private bool _salidaRealizada;
        private bool salidaRealizada
        {
            get { return _salidaRealizada; }
            set { _salidaRealizada = value; }
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

        #region fuenteLlamado 
        //Permite identificar si proviene del menu principal o si es de una ventana
        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
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

        #region tokenRecepcionReferencias

        private string _tokenRecepcionReferencias;
        private string tokenRecepcionReferencias
        {
            get { return _tokenRecepcionReferencias; }
            set { _tokenRecepcionReferencias = value; }
        }

        #endregion

        #region tokenRecepcionReferenciasPlan

        private string _tokenRecepcionReferenciasPlan;
        private string tokenRecepcionReferenciasPlan
        {
            get { return _tokenRecepcionReferenciasPlan; }
            set { _tokenRecepcionReferenciasPlan = value; }
        }

        #endregion

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

        #endregion

        #region resultadoProceso

        private int _resultadoProceso;
        private int resultadoProceso
        {
            get { return _resultadoProceso; }
            set { _resultadoProceso = value; }
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


        private DialogCoordinator dlg;

        private int idFirmaUnica = 2;//Id de firma a utilizar

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #endregion

        #region ReportesAImpresionMainModel
        private MainModel _mainModel = null;

        public MainModel ReportesAImpresionMainModel
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

        #region Propiedades

        #region Entidades

        #region TipoProgramaModelo

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

        #endregion

        #region ViewModel Property : currentEncargo

        public const string currentEncargoPropertyName = "currentEncargo";

        private EncargoModelo _currentEncargo;

        public EncargoModelo currentEncargo
        {
            get
            {
                return _currentEncargo;
            }

            set
            {
                if (_currentEncargo == value) return;

                _currentEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEncargoPropertyName);
            }
        }

        #endregion

        #region Propiedades de  entidad encargo


        #region  Primary key Cliente idnitcliente

        public const string idnitclientePropertyName = "idnitcliente";

        private string _idnitcliente = string.Empty;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string idnitcliente
        {
            get
            {
                return _idnitcliente;
            }

            set
            {
                if (_idnitcliente == value)
                {
                    return;
                }

                _idnitcliente = value;
                RaisePropertyChanged(idnitclientePropertyName);
            }
        }

        #endregion

        #region fechacreadoencargo

        public const string fechacreadoencargoPropertyName = "fechacreadoencargo";

        private string _fechacreadoencargo = string.Empty;

        public string fechacreadoencargo
        {
            get
            {
                return _fechacreadoencargo;
            }

            set
            {
                if (_fechacreadoencargo == value)
                {
                    return;
                }

                _fechacreadoencargo = value;
                RaisePropertyChanged(fechacreadoencargoPropertyName);
            }
        }

        #endregion

        #region tipoclienteencargo
        //Permite determinar si es un encargo recurrente (segunda o mas veces) que se hace el encargo del cliente.
        //True=El encargo es recurrente, False= Primera vez que se hace la auditoria. 
        //En el caso de las auditorias recurrentes permite utilizar archivos del encargo inmediato anterior.
        public const string tipoclienteencargoPropertyName = "tipoclienteencargo";

        private bool _tipoclienteencargo = false;

        public bool tipoclienteencargo
        {
            get
            {
                return _tipoclienteencargo;
            }

            set
            {
                if (_tipoclienteencargo == value)
                {
                    return;
                }

                _tipoclienteencargo = value;
                RaisePropertyChanged(tipoclienteencargoPropertyName);
            }
        }

        #endregion

        #region fechainiperauditencargo

        public const string fechainiperauditencargoPropertyName = "fechainiperauditencargo";

        private DateTime _fechainiperauditencargo;

        public DateTime fechainiperauditencargo
        {
            get
            {
                return _fechainiperauditencargo;
            }

            set
            {
                if (_fechainiperauditencargo == value)
                {
                    return;
                }

                _fechainiperauditencargo = value;
                RaisePropertyChanged(fechainiperauditencargoPropertyName);
            }
        }


        #endregion

        #region fechafinperauditencargo

        public const string fechafinperauditencargoPropertyName = "fechafinperauditencargo";

        private DateTime _fechafinperauditencargo;

        public DateTime fechafinperauditencargo
        {
            get
            {
                return _fechafinperauditencargo;
            }

            set
            {
                if (_fechafinperauditencargo == value)
                {
                    return;
                }

                _fechafinperauditencargo = value;
                RaisePropertyChanged(fechafinperauditencargoPropertyName);
            }
        }


        #endregion

        #region estadoencargo

        public const string estadoencargoPropertyName = "estadoencargo";

        private string _estadoencargo = string.Empty;

        public string estadoencargo
        {
            get
            {
                return _estadoencargo;
            }

            set
            {
                if (_estadoencargo == value)
                {
                    return;
                }

                _estadoencargo = value;
                RaisePropertyChanged(estadoencargoPropertyName);
            }
        }
        #endregion

        #region inicialesusuario

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

        #endregion

        #region Propiedes de presentacion agregadas

        #region razonsocialcliente

        public const string razonsocialclientePropertyName = "razonsocialcliente";

        private string _razonsocialcliente = string.Empty;

        public string razonsocialcliente
        {
            get
            {
                return _razonsocialcliente;
            }

            set
            {
                if (_razonsocialcliente == value)
                {
                    return;
                }

                _razonsocialcliente = value;
                RaisePropertyChanged(razonsocialclientePropertyName);
            }
        }

        #endregion

        #region descripcionTipoClienteEncargo

        public const string descripcionTipoClienteEncargoPropertyName = "descripcionTipoClienteEncargo";

        private string _descripcionTipoClienteEncargo = string.Empty;

        public string descripcionTipoClienteEncargo
        {
            get
            {
                return _descripcionTipoClienteEncargo;
            }

            set
            {
                if (_descripcionTipoClienteEncargo == value)
                {
                    return;
                }

                _descripcionTipoClienteEncargo = value;
                RaisePropertyChanged(descripcionTipoClienteEncargoPropertyName);
            }
        }


        #endregion

        #region descripcionTipoAuditoria

        public const string descripcionTipoAuditoriaPropertyName = "descripcionTipoAuditoria";

        private string _descripcionTipoAuditoria = string.Empty;

        public string descripcionTipoAuditoria
        {
            get
            {
                return _descripcionTipoAuditoria;
            }

            set
            {
                if (_descripcionTipoAuditoria == value)
                {
                    return;
                }

                _descripcionTipoAuditoria = value;
                RaisePropertyChanged(descripcionTipoAuditoriaPropertyName);
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

        #region visibilidadObjetivos

        public const string visibilidadObjetivosPropertyName = "visibilidadObjetivos";

        private Visibility _visibilidadObjetivos = Visibility.Collapsed;

        public Visibility visibilidadObjetivos
        {
            get
            {
                return _visibilidadObjetivos;
            }

            set
            {
                if (_visibilidadObjetivos == value)
                {
                    return;
                }

                _visibilidadObjetivos = value;
                RaisePropertyChanged(visibilidadObjetivosPropertyName);
            }
        }

        #endregion

        #region visibilidadAlcances

        public const string visibilidadAlcancesPropertyName = "visibilidadAlcances";

        private Visibility _visibilidadAlcances = Visibility.Collapsed;

        public Visibility visibilidadAlcances
        {
            get
            {
                return _visibilidadAlcances;
            }

            set
            {
                if (_visibilidadAlcances == value)
                {
                    return;
                }

                _visibilidadAlcances = value;
                RaisePropertyChanged(visibilidadAlcancesPropertyName);
            }
        }

        #endregion


        #region visibilidadObjetivosReducido

        public const string visibilidadObjetivosReducidoPropertyName = "visibilidadObjetivosReducido";

        private Visibility _visibilidadObjetivosReducido = Visibility.Collapsed;

        public Visibility visibilidadObjetivosReducido
        {
            get
            {
                return _visibilidadObjetivosReducido;
            }

            set
            {
                if (_visibilidadObjetivosReducido == value)
                {
                    return;
                }

                _visibilidadObjetivosReducido = value;
                RaisePropertyChanged(visibilidadObjetivosReducidoPropertyName);
            }
        }

        #endregion

        #region visibilidadAlcancesReducido

        public const string visibilidadAlcancesReducidoPropertyName = "visibilidadAlcancesReducido";

        private Visibility _visibilidadAlcancesReducido = Visibility.Collapsed;

        public Visibility visibilidadAlcancesReducido
        {
            get
            {
                return _visibilidadAlcancesReducido;
            }

            set
            {
                if (_visibilidadAlcancesReducido == value)
                {
                    return;
                }

                _visibilidadAlcancesReducido = value;
                RaisePropertyChanged(visibilidadAlcancesReducidoPropertyName);
            }
        }

        #endregion

        #region visibilidadFElaboracion

        public const string visibilidadFElaboracionPropertyName = "visibilidadFElaboracion";

        private Visibility _visibilidadFElaboracion = Visibility.Collapsed;

        public Visibility visibilidadFElaboracion
        {
            get
            {
                return _visibilidadFElaboracion;
            }

            set
            {
                if (_visibilidadFElaboracion == value)
                {
                    return;
                }

                _visibilidadFElaboracion = value;
                RaisePropertyChanged(visibilidadFElaboracionPropertyName);
            }
        }

        #endregion

        #region visibilidadFSupervision

        public const string visibilidadFSupervisionPropertyName = "visibilidadFSupervision";

        private Visibility _visibilidadFSupervision = Visibility.Collapsed;

        public Visibility visibilidadFSupervision
        {
            get
            {
                return _visibilidadFSupervision;
            }

            set
            {
                if (_visibilidadFSupervision == value)
                {
                    return;
                }

                _visibilidadFSupervision = value;
                RaisePropertyChanged(visibilidadFSupervisionPropertyName);
            }
        }

        #endregion

        #region visibilidadFAprobacion

        public const string visibilidadFAprobacionPropertyName = "visibilidadFAprobacion";

        private Visibility _visibilidadFAprobacion = Visibility.Collapsed;

        public Visibility visibilidadFAprobacion
        {
            get
            {
                return _visibilidadFAprobacion;
            }

            set
            {
                if (_visibilidadFAprobacion == value)
                {
                    return;
                }

                _visibilidadFAprobacion = value;
                RaisePropertyChanged(visibilidadFAprobacionPropertyName);
            }
        }

        #endregion

        #region nombreprogramaVista

        public const string nombreprogramaVistaPropertyName = "nombreprogramaVista";

        private string _nombreprogramaVista = string.Empty;

        public string nombreprogramaVista
        {
            get
            {
                return _nombreprogramaVista;
            }

            set
            {
                if (_nombreprogramaVista == value)
                {
                    return;
                }

                _nombreprogramaVista = value;
                RaisePropertyChanged(nombreprogramaVistaPropertyName);
            }
        }

        #endregion


        #region visibilidadImprimir

        public const string visibilidadImprimirPropertyName = "visibilidadImprimir";

        private Visibility _visibilidadImprimir = Visibility.Collapsed;

        public Visibility visibilidadImprimir
        {
            get
            {
                return _visibilidadImprimir;
            }

            set
            {
                if (_visibilidadImprimir == value)
                {
                    return;
                }

                _visibilidadImprimir = value;
                RaisePropertyChanged(visibilidadImprimirPropertyName);
            }
        }

        #endregion

        #region fechaejecuto

        public const string fechaejecutoPropertyName = "fechaejecuto";

        private string _fechaejecuto;

        public string fechaejecuto
        {
            get
            {
                return _fechaejecuto;
            }

            set
            {
                if (_fechaejecuto == value)
                {
                    return;
                }

                _fechaejecuto = value;
                RaisePropertyChanged(fechaejecutoPropertyName);
            }
        }


        #endregion

        #region fechasuperviso

        public const string fechasupervisoPropertyName = "fechasuperviso";

        private string _fechasuperviso;

        public string fechasuperviso
        {
            get
            {
                return _fechasuperviso;
            }

            set
            {
                if (_fechasuperviso == value)
                {
                    return;
                }

                _fechasuperviso = value;
                RaisePropertyChanged(fechasupervisoPropertyName);
            }
        }


        #endregion

        #region fechaaprobo

        public const string fechaaproboPropertyName = "fechaaprobo";

        private string _fechaaprobo;

        public string fechaaprobo
        {
            get
            {
                return _fechaaprobo;
            }

            set
            {
                if (_fechaaprobo == value)
                {
                    return;
                }

                _fechaaprobo = value;
                RaisePropertyChanged(fechaaproboPropertyName);
            }
        }


        #endregion


        #region usuarioEjecuto

        public const string usuarioEjecutoPropertyName = "usuarioEjecuto";

        private string _usuarioEjecuto;

        public string usuarioEjecuto
        {
            get
            {
                return _usuarioEjecuto;
            }

            set
            {
                if (_usuarioEjecuto == value)
                {
                    return;
                }

                _usuarioEjecuto = value;
                RaisePropertyChanged(usuarioEjecutoPropertyName);
            }
        }


        #endregion

        #region usuarioSuperviso

        public const string usuarioSupervisoPropertyName = "usuarioSuperviso";

        private string _usuarioSuperviso;

        public string usuarioSuperviso
        {
            get
            {
                return _usuarioSuperviso;
            }

            set
            {
                if (_usuarioSuperviso == value)
                {
                    return;
                }

                _usuarioSuperviso = value;
                RaisePropertyChanged(usuarioSupervisoPropertyName);
            }
        }


        #endregion


        #region usuarioAprobo

        public const string usuarioAproboPropertyName = "usuarioAprobo";

        private string _usuarioAprobo;

        public string usuarioAprobo
        {
            get
            {
                return _usuarioAprobo;
            }

            set
            {
                if (_usuarioAprobo == value)
                {
                    return;
                }

                _usuarioAprobo = value;
                RaisePropertyChanged(usuarioAproboPropertyName);
            }
        }


        #endregion

        #region  referencia

        public const string referenciaPropertyName = "referencia";

        private string _referencia = string.Empty;

        public string referencia
        {
            get
            {
                return _referencia;
            }

            set
            {
                if (_referencia == value)
                {
                    return;
                }

                _referencia = value;
                RaisePropertyChanged(referenciaPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand SalirCommand { get; set; }

        public RelayCommand ImprimirCommand { get; set; }

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public CronogramaPresentacionViewModel()
        {

        }

        public CronogramaPresentacionViewModel(string origen)
        {
            #region configuracion general
            enviarMensajeInhabilitar();
            ReportesAImpresionMainModel = new SGPTWpf.Model.MainModel();
            _origenLlamada = origen;
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
            //Captura de titulo de programa
            _resultadoProceso = 0;
            _salidaRealizada = false;

            #endregion
            switch (origen)
            {
                case "cedulaCronograma":
                    _tokenRecepcion = "datosEncargoCedulasCronograma"; //Modificado
                    _tokenEnvioCierre = "datosEncargoCedulasCronogramaController";//Modificado
                    _fuenteLlamado = 1;
                    _encabezadoPantalla = "Cronograma de encargo";

                    break;
            }
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<CronogramaMsj>(this, tokenRecepcion, (ElementoMsj) => ControlDetalleHerramientoCrudMensaje(ElementoMsj));
            //Mensaje de  vista desde sub ventana
            accesibilidadWindow = false;
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            _currentEncargo = new EncargoModelo();
            _visibilidadFAprobacion = Visibility.Collapsed;
            _visibilidadFElaboracion = Visibility.Collapsed;
            _visibilidadFSupervision = Visibility.Collapsed;

            _referencia = string.Empty;
            _usuarioAprobo = string.Empty;
            _usuarioEjecuto = string.Empty;
            _usuarioSuperviso = string.Empty;
            _visibilidadFAprobacion = Visibility.Collapsed;
            _visibilidadFElaboracion = Visibility.Collapsed;
            _visibilidadFSupervision = Visibility.Collapsed;
            _fechaaprobo = string.Empty;
            _fechaejecuto = string.Empty;
            _fechasuperviso = string.Empty;
            _visibilidadImprimir = Visibility.Collapsed;
        }
        private void ControlDetalleHerramientoCrudMensaje(CronogramaMsj ElementoMsj)
        {
            //Procesos normal
            currentEncargo = ElementoMsj.encargoModelo;
            currentUsuario = ElementoMsj.usuarioModelo;
            descripcionTipoAuditoria = currentEncargo.descripcionTipoAuditoria;
            razonsocialcliente = currentEncargo.razonsocialcliente;
            visibilidadObjetivos = Visibility.Visible;
            visibilidadAlcances = Visibility.Visible;
            visibilidadObjetivosReducido = Visibility.Collapsed;
            visibilidadAlcancesReducido = Visibility.Collapsed;
            if (!(string.IsNullOrEmpty(ElementoMsj.tokenRespuestaController) || string.IsNullOrWhiteSpace(ElementoMsj.tokenRespuestaController)))
            {
                tokenEnvioCierre = ElementoMsj.tokenRespuestaController;
            }
            if (ElementoMsj.fuenteLlamado == 1500)
            {
                visibilidadImprimir = Visibility.Visible;
            }
            else
            {
                visibilidadImprimir = Visibility.Collapsed;
            }

            //Desuscribir mensaje
            Messenger.Default.Unregister<CronogramaMsj>(this, tokenRecepcion);//Proviene de pantalla principal

            Mouse.OverrideCursor = null;//Termino el proceso de  carga
            accesibilidadWindow = true;
        }


        #endregion


        private void Salir()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            if (!salidaRealizada)
            {
                switch (fuenteLlamado)
                {
                    case 1:
                        enviarMensajeCierre(); //Llamado desde plan
                        enviarMensajeHabilitar();
                        break;

                }
                CloseWindow();
                salidaRealizada = true;
            }
        }


        #endregion

        #region Mensajes

        //Procesando mensajes

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

        public void enviarMensajeCierre()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvioCierre);
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
            ImprimirCommand = new RelayCommand(imprimirReporte);
        }

        #endregion

        #region Impresion

        private async void imprimirReporte()
        {
            //dlg.ShowMessageAsync(this, "Proceso de impresion esta.... ", "En proceso");

            //EncabezadosPiesReportesProgramasCuestionarios

            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Acepto",
                NegativeButtonText = "Cancelar",

            };
            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El documento sera enviado a impresion.", "Desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
            if (resultk == MessageDialogResult.Affirmative)
            {
                //CargarArchivosMensajeModal msj = new CargarArchivosMensajeModal();
                EncabezadosPiesReportesProgramasCuestionarios ep = new EncabezadosPiesReportesProgramasCuestionarios();

                ep.logofirma = logoFirma;
                ep.razonsocialfirma = razonSocialFirma;
                ep.encabezadopantalla = encabezadoPantalla;
                ep.descripciontipoauditoria = currentEncargo.descripcionTipoAuditoria;
                ep.razonsocialcliente = currentEncargo.razonsocialcliente;//razonsocialcliente;
                ep.usuarioejecuto = usuarioEjecuto;
                ep.fechaejecuto = fechaejecuto;
                ep.fechainiperauditencargo = currentEncargo.fechainiperauditencargo;
                ep.fechafinperauditencargo = currentEncargo.fechafinperauditencargo;
                ep.usuariosuperviso = usuarioSuperviso;
                ep.fechasuperviso = fechasuperviso;
                ep.usuarioaprobo = usuarioAprobo;
                ep.fechaaprobo = fechaaprobo;

                //pie de pagina.
                //ep.cantidadprocedplan = (decimal)currentEntidad.cantidadProcedimientosPlan;//(decimal)evaluacioninherentedmrAlto;
                //ep.cantidadprocedejecucion = (decimal)currentEntidad.cantidadProcedimientosEjecucion;//(decimal)evaluacioncontroldmrAlto;
                //ep.indiceejecucion = (decimal)currentEntidad.indiceEjecucionprograma;//(decimal)evaluacionDetecciondmrAlto;
                //ep.horasplan = (decimal)currentEntidad.horasplanprograma;//(decimal)evaluacioninherentedmrMedio;
                //ep.horasejecucion = (decimal)currentEntidad.horasejecucionprograma;//(decimal)evaluacioncontroldmrMedio;
                //ep.indicehoras = (decimal)currentEntidad.indiceHoras;//(decimal)evaluacionDetecciondmrMedio;



                GenerarReporteMensajeModal msj = new GenerarReporteMensajeModal();
                msj.TipoReporteAGenerar = TipoReporteAGenerar.ReportePrograma;
                //public ObservableCollection<DetalleProgramaModelo> listaObjetivos
                //public ObservableCollection<DetalleProgramaModelo> listaAlcances
                //public ObservableCollection<DetalleProgramaModelo> listaDetalleProcedimientos
                msj.EncabezadosPiesReportesProgramasCuestionarios = ep;
                //msj.listaObjetivos = listaObjetivos;
                //msj.listaAlcances = listaAlcances;
                //msj.listaDetalleProcedimientos = listaDetalleProcedimientos;

                ReportesAImpresionMainModel.TypeName = "ReportePrograma";
                Messenger.Default.Send<GenerarReporteMensajeModal>(msj, "GenerameUnReporte");
                CloseWindow();
            }

        }
        #endregion
    }
}

