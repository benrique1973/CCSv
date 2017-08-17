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

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa
{
    public sealed class ProgramaPresentacionViewModel : ViewModeloBase
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

        #region tokenRecepcionEncargos

        private string _tokenRecepcionEncargos;
        private string tokenRecepcionEncargos
        {
            get { return _tokenRecepcionEncargos; }
            set { _tokenRecepcionEncargos = value; }
        }

        #endregion

        #region tokenRecepcionEncargosDetalle

        private string _tokenRecepcionEncargosDetalle;
        private string tokenRecepcionEncargosDetalle
        {
            get { return _tokenRecepcionEncargosDetalle; }
            set { _tokenRecepcionEncargosDetalle = value; }
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

        #region Lista de entidades


        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<DetalleProgramaModelo> _listaDetalleHerramienta;

        public ObservableCollection<DetalleProgramaModelo> listaDetalleHerramienta
        {
            get
            {
                return _listaDetalleHerramienta;
            }
            set
            {
                if (_listaDetalleHerramienta == value) return;

                _listaDetalleHerramienta = value;
                RaisePropertyChanged(listaDetalleHerramientaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaObjetivos

        public const string listaObjetivosPropertyName = "listaObjetivos";

        private ObservableCollection<DetalleProgramaModelo> _listaObjetivos;

        public ObservableCollection<DetalleProgramaModelo> listaObjetivos
        {
            get
            {
                return _listaObjetivos;
            }
            set
            {
                if (_listaObjetivos == value) return;

                _listaObjetivos = value;
                RaisePropertyChanged(listaObjetivosPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaAlcances

        public const string listaAlcancesPropertyName = "listaAlcances";

        private ObservableCollection<DetalleProgramaModelo> _listaAlcances;

        public ObservableCollection<DetalleProgramaModelo> listaAlcances
        {
            get
            {
                return _listaAlcances;
            }
            set
            {
                if (_listaAlcances == value) return;

                _listaAlcances = value;
                RaisePropertyChanged(listaAlcancesPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaDetalleProcedimientos

        public const string listaDetalleProcedimientosPropertyName = "listaDetalleProcedimientos";

        private ObservableCollection<DetalleProgramaModelo> _listaDetalleProcedimientos;

        public ObservableCollection<DetalleProgramaModelo> listaDetalleProcedimientos
        {
            get
            {
                return _listaDetalleProcedimientos;
            }
            set
            {
                if (_listaDetalleProcedimientos == value) return;

                _listaDetalleProcedimientos = value;
                RaisePropertyChanged(listaDetalleProcedimientosPropertyName);
            }
        }


        #endregion

        #endregion Lista de entidades

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

        #endregion

        #region ViewModel Property : currentEntidad Herramienta Modelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private ProgramaModelo _currentEntidad;

        public ProgramaModelo currentEntidad
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

        #region ViewModel Property : currentEntidadDetalle Herramienta Modelo

        public const string currentEntidadDetallePropertyName = "currentEntidadDetalle";

        private DetalleProgramaModelo _currentEntidadDetalle;

        public DetalleProgramaModelo currentEntidadDetalle
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

        #region  Primary key idencargo

        public const string idencargoPropertyName = "idencargo";

        private int _idencargo = 0;

        public int idencargo
        {
            get
            {
                return _idencargo;
            }

            set
            {
                if (_idencargo == value)
                {
                    return;
                }

                _idencargo = value;
                RaisePropertyChanged(idencargoPropertyName);
            }
        }

        #endregion


        #region  Primary key idDigitosModelo

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

        #region  Primary key tipo de auditoria idta

        public const string idtaPropertyName = "idta";

        private int _idta = 0;

        public int idta
        {
            get
            {
                return _idta;
            }

            set
            {
                if (_idta == value)
                {
                    return;
                }

                _idta = value;
                RaisePropertyChanged(idtaPropertyName);
            }
        }

        #endregion


        #region idindice

        public const string idindicePropertyName = "idindice";

        private int _idindice = 0;

        public int idindice
        {
            get
            {
                return _idindice;
            }

            set
            {
                if (_idindice == value)
                {
                    return;
                }

                _idindice = value;
                RaisePropertyChanged(idindicePropertyName);
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

        #region etapaencargo
        //Permite gestionar las diferentes etapas de los archivos que componen las auditorias. 
        //Se distinguen las siguientes etapas; I=inicial, P=En proceso, R=Revisado, C=Cerrado. 
        //Un encargo con estado = "Cerrado" no se debe modificar ningun elemento asociado a el.

        public const string etapaencargoPropertyName = "etapaencargo";

        private byte[] _etapaencargo = null;

        public byte[] etapaencargo
        {
            get
            {
                return _etapaencargo;
            }

            set
            {
                if (_etapaencargo == value)
                {
                    return;
                }

                _etapaencargo = value;
                RaisePropertyChanged(etapaencargoPropertyName);
            }
        }

        #endregion

        #region costoejecucionencargo

        public const string costoejecucionencargoPropertyName = "costoejecucionencargo";

        private decimal _costoejecucionencargo = 0;

        public decimal costoejecucionencargo
        {
            get
            {
                return _costoejecucionencargo;
            }

            set
            {
                if (_costoejecucionencargo == value)
                {
                    return;
                }

                _costoejecucionencargo = value;
                RaisePropertyChanged(costoejecucionencargoPropertyName);
            }
        }

        #endregion

        #region honorariosencargo

        public const string honorariosencargoPropertyName = "honorariosencargo";

        private decimal _honorariosencargo = 0;

        public decimal honorariosencargo
        {
            get
            {
                return _honorariosencargo;
            }

            set
            {
                if (_honorariosencargo == value)
                {
                    return;
                }

                _honorariosencargo = value;
                RaisePropertyChanged(honorariosencargoPropertyName);
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

        #region fechacierre

        public const string fechacierrePropertyName = "fechacierre";

        private string _fechacierre;

        public string fechacierre
        {
            get
            {
                return _fechacierre;
            }

            set
            {
                if (_fechacierre == value)
                {
                    return;
                }

                _fechacierre = value;
                RaisePropertyChanged(fechacierrePropertyName);
            }
        }


        #endregion

        #region fechasupervision

        public const string fechasupervisionPropertyName = "fechasupervision";

        private string _fechasupervision;

        public string fechasupervision
        {
            get
            {
                return _fechasupervision;
            }

            set
            {
                if (_fechasupervision == value)
                {
                    return;
                }

                _fechasupervision = value;
                RaisePropertyChanged(fechasupervisionPropertyName);
            }
        }


        #endregion

        #region fechaaprobacion

        public const string fechaaprobacionPropertyName = "fechaaprobacion";

        private string _fechaaprobacion;

        public string fechaaprobacion
        {
            get
            {
                return _fechaaprobacion;
            }

            set
            {
                if (_fechaaprobacion == value)
                {
                    return;
                }

                _fechaaprobacion = value;
                RaisePropertyChanged(fechaaprobacionPropertyName);
            }
        }


        #endregion

        #endregion

        #region Programa Modelo

        #region idprograma

        public const string idprogramaPropertyName = "idprograma";

        private int _idprograma = 0;

        public int idprograma
        {
            get
            {
                return _idprograma;
            }

            set
            {
                if (_idprograma == value)
                {
                    return;
                }

                _idprograma = value;
                RaisePropertyChanged(idprogramaPropertyName);
            }
        }

        #endregion

        #region idtpprograma

        public const string idtpprogramaPropertyName = "idtpprograma";

        private int _idtpprograma = 0;

        public int idtpprograma
        {
            get
            {
                return _idtpprograma;
            }

            set
            {
                if (_idtpprograma == value)
                {
                    return;
                }

                _idtpprograma = value;
                RaisePropertyChanged(idtpprogramaPropertyName);
            }
        }

        #endregion

        #region idthprograma

        public const string idthprogramaPropertyName = "idthprograma";

        private int _idthprograma = 0;

        public int idthprograma
        {
            get
            {
                return _idthprograma;
            }

            set
            {
                if (_idthprograma == value)
                {
                    return;
                }

                _idthprograma = value;
                RaisePropertyChanged(idthprogramaPropertyName);
            }
        }

        #endregion


        #region nombreprograma

        public const string nombreprogramaPropertyName = "nombreprograma";

        private string _nombreprograma = string.Empty;

        public string nombreprograma
        {
            get
            {
                return _nombreprograma;
            }

            set
            {
                if (_nombreprograma == value)
                {
                    return;
                }

                _nombreprograma = value;
                RaisePropertyChanged(nombreprogramaPropertyName);
            }
        }

        #endregion


        #region fechahoyprograma

        public const string fechahoyprogramaPropertyName = "fechahoyprograma";

        private DateTime _fechahoyprograma = DateTime.Now;

        public DateTime fechahoyprograma
        {
            get
            {
                return _fechahoyprograma;
            }

            set
            {
                if (_fechahoyprograma == value)
                {
                    return;
                }

                _fechahoyprograma = value;
                RaisePropertyChanged(fechahoyprogramaPropertyName);
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

        #region horasplanprograma

        public const string horasplanprogramaPropertyName = "horasplanprograma";

        private decimal? _horasplanprograma = 0;

        public decimal? horasplanprograma
        {
            get
            {
                return _horasplanprograma;
            }

            set
            {
                if (_horasplanprograma == value)
                {
                    return;
                }

                _horasplanprograma = value;
                RaisePropertyChanged(horasplanprogramaPropertyName);
            }
        }

        #endregion

        #region horasejecucionprograma

        public const string horasejecucionprogramaPropertyName = "horasejecucionprograma";

        private decimal? _horasejecucionprograma = 0;

        public decimal? horasejecucionprograma
        {
            get
            {
                return _horasejecucionprograma;
            }

            set
            {
                if (_horasejecucionprograma == value)
                {
                    return;
                }

                _horasejecucionprograma = value;
                RaisePropertyChanged(horasejecucionprogramaPropertyName);
            }
        }

        #endregion

        #region cantidadProcedimientosPlan

        public const string cantidadProcedimientosPlanPropertyName = "cantidadProcedimientosPlan";

        private decimal? _cantidadProcedimientosPlan = 0;

        public decimal? cantidadProcedimientosPlan
        {
            get
            {
                return _cantidadProcedimientosPlan;
            }

            set
            {
                if (_cantidadProcedimientosPlan == value)
                {
                    return;
                }

                _cantidadProcedimientosPlan = value;
                RaisePropertyChanged(cantidadProcedimientosPlanPropertyName);
            }
        }

        #endregion

        #region cantidadProcedimientosEjecucion

        public const string cantidadProcedimientosEjecucionPropertyName = "cantidadProcedimientosEjecucion";

        private decimal? _cantidadProcedimientosEjecucion = 0;

        public decimal? cantidadProcedimientosEjecucion
        {
            get
            {
                return _cantidadProcedimientosEjecucion;
            }

            set
            {
                if (_cantidadProcedimientosEjecucion == value)
                {
                    return;
                }

                _cantidadProcedimientosEjecucion = value;
                RaisePropertyChanged(cantidadProcedimientosEjecucionPropertyName);
            }
        }

        #endregion

        #region indiceHoras

        public const string indiceHorasPropertyName = "indiceHoras";

        private decimal? _indiceHoras = 0;

        public decimal? indiceHoras
        {
            get
            {
                return _indiceHoras;
            }

            set
            {
                if (_indiceHoras == value)
                {
                    return;
                }

                _indiceHoras = value;
                RaisePropertyChanged(indiceHorasPropertyName);
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

        #region estadoprograma

        public const string estadoprogramaPropertyName = "estadoprograma";

        private string _estadoprograma = string.Empty;

        public string estadoprograma
        {
            get
            {
                return _estadoprograma;
            }

            set
            {
                if (_estadoprograma == value)
                {
                    return;
                }

                _estadoprograma = value;
                RaisePropertyChanged(estadoprogramaPropertyName);
            }
        }

        #endregion

        #region referenciaPrograma

        public const string referenciaProgramaPropertyName = "referenciaPrograma";

        private string _referenciaPrograma = string.Empty;

        public string referenciaPrograma
        {
            get
            {
                return _referenciaPrograma;
            }

            set
            {
                if (_referenciaPrograma == value)
                {
                    return;
                }

                _referenciaPrograma = value;
                RaisePropertyChanged(referenciaProgramaPropertyName);
            }
        }

        #endregion

        #region descripcionEtapaEncargo

        public const string descripcionEtapaEncargoPropertyName = "descripcionEtapaEncargo";

        private string _descripcionEtapaEncargo = string.Empty;

        public string descripcionEtapaEncargo
        {
            get
            {
                return _descripcionEtapaEncargo;
            }

            set
            {
                if (_descripcionEtapaEncargo == value)
                {
                    return;
                }

                _descripcionEtapaEncargo = value;
                RaisePropertyChanged(descripcionEtapaEncargoPropertyName);
            }
        }

        #endregion

        #region indiceEjecucionprograma

        public const string indiceEjecucionprogramaPropertyName = "indiceEjecucionprograma";

        private string _indiceEjecucionprograma = string.Empty;

        public string indiceEjecucionprograma
        {
            get
            {
                return _indiceEjecucionprograma;
            }

            set
            {
                if (_indiceEjecucionprograma == value)
                {
                    return;
                }

                _indiceEjecucionprograma = value;
                RaisePropertyChanged(indiceEjecucionprogramaPropertyName);
            }
        }

        #endregion

        #region totalProcedimientos

        public const string totalProcedimientosPropertyName = "totalProcedimientos";

        private string _totalProcedimientos = string.Empty;

        public string totalProcedimientos
        {
            get
            {
                return _totalProcedimientos;
            }

            set
            {
                if (_totalProcedimientos == value)
                {
                    return;
                }

                _totalProcedimientos = value;
                RaisePropertyChanged(totalProcedimientosPropertyName);
            }
        }

        #endregion

        #endregion

        #region Detalle Programa

        #region iddp

        public const string iddpPropertyName = "iddp";

        private int _iddp = 0;

        public int iddp
        {
            get
            {
                return _iddp;
            }

            set
            {
                if (_iddp == value)
                {
                    return;
                }

                _iddp = value;
                RaisePropertyChanged(iddpPropertyName);
            }
        }

        #endregion

        #region idtprocedimientodp

        public const string idtprocedimientodpPropertyName = "idtprocedimientodp";

        private int _idtprocedimientodp = 0;

        public int idtprocedimientodp
        {
            get
            {
                return _idtprocedimientodp;
            }

            set
            {
                if (_idtprocedimientodp == value)
                {
                    return;
                }

                _idtprocedimientodp = value;
                RaisePropertyChanged(idtprocedimientodpPropertyName);
            }
        }

        #endregion

        #region descripciondp

        public const string descripciondpPropertyName = "descripciondp";

        private string _descripciondp = string.Empty;

        public string descripciondp
        {
            get
            {
                return _descripciondp;
            }

            set
            {
                if (_descripciondp == value)
                {
                    return;
                }

                _descripciondp = value;
                RaisePropertyChanged(descripciondpPropertyName);
                currentEntidadDetalle.descripciondp = value;
            }
        }

        #endregion

        #region respuestaCuestionarioDp

        public const string respuestaCuestionarioDpPropertyName = "respuestaCuestionarioDp";

        private string _respuestaCuestionarioDp = string.Empty;

        public string respuestaCuestionarioDp
        {
            get
            {
                return _respuestaCuestionarioDp;
            }

            set
            {
                if (_respuestaCuestionarioDp == value)
                {
                    return;
                }

                _respuestaCuestionarioDp = value;
                RaisePropertyChanged(respuestaCuestionarioDpPropertyName);
            }
        }

        #endregion

        #region fechacreadodp

        public const string fechacreadodpPropertyName = "fechacreadodp";

        private DateTime _fechacreadodp = DateTime.Now;

        public DateTime fechacreadodp
        {
            get
            {
                return _fechacreadodp;
            }

            set
            {
                if (_fechacreadodp == value)
                {
                    return;
                }

                _fechacreadodp = value;
                RaisePropertyChanged(fechacreadodpPropertyName);
            }
        }

        #endregion

        #region fechaEjecucion

        public const string fechaEjecucionPropertyName = "fechaEjecucion";

        private string _fechaEjecucion;

        public string fechaEjecucion
        {
            get
            {
                return _fechaEjecucion;
            }

            set
            {
                if (_fechaEjecucion == value)
                {
                    return;
                }

                _fechaEjecucion = value;
                RaisePropertyChanged(fechaEjecucionPropertyName);
            }
        }

        #endregion

        #region estadoprocedimientodp

        public const string estadoprocedimientodpPropertyName = "estadoprocedimientodp";

        private string _estadoprocedimientodp = string.Empty;

        public string estadoprocedimientodp
        {
            get
            {
                return _estadoprocedimientodp;
            }

            set
            {
                if (_estadoprocedimientodp == value)
                {
                    return;
                }

                _estadoprocedimientodp = value;
                RaisePropertyChanged(estadoprocedimientodpPropertyName);
            }
        }

        #endregion

        #region nombreCliente

        public const string nombreClientePropertyName = "nombreCliente";

        private string _nombreCliente = string.Empty;

        public string nombreCliente
        {
            get
            {
                return _nombreCliente;
            }

            set
            {
                if (_nombreCliente == value)
                {
                    return;
                }

                _nombreCliente = value;
                RaisePropertyChanged(nombreClientePropertyName);
            }
        }

        #endregion

        #region nombreElabora

        public const string nombreElaboraPropertyName = "nombreElabora";

        private string _nombreElabora = string.Empty;

        public string nombreElabora
        {
            get
            {
                return _nombreElabora;
            }

            set
            {
                if (_nombreElabora == value)
                {
                    return;
                }

                _nombreElabora = value;
                RaisePropertyChanged(nombreElaboraPropertyName);
            }
        }

        #endregion

        #region ordendp

        public const string ordendpPropertyName = "ordendp";

        private decimal _ordendp = 0;

        public decimal ordendp
        {
            get
            {
                return _ordendp;
            }

            set
            {
                if (_ordendp == value)
                {
                    return;
                }

                _ordendp = value;
                RaisePropertyChanged(ordendpPropertyName);
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

        public ProgramaPresentacionViewModel()
        {
            ReportesAImpresionMainModel = new MainModel();
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
            _resultadoProceso = 0;
            //Captura de titulo de programa
            _fechaEjecucion = MetodosModelo.homologacionFecha();
            _salidaRealizada = false;
            _tokenRecepcionEncargos = "datosEncargosPrograma";
            _tokenRecepcionEncargosDetalle = "EncargoPlanProgramaAuditoriaDetalle";
            _tokenEnvioCierre = "CierreEncargosPlanProgramaEncargos"; ;
            _fuenteLlamado = 0;
            listaObjetivos = new ObservableCollection<DetalleProgramaModelo>();
            listaAlcances = new ObservableCollection<DetalleProgramaModelo>();
            listaDetalleProcedimientos = new ObservableCollection<DetalleProgramaModelo>();
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionEncargos, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionEncargosDetalle, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));

            accesibilidadWindow = false;
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();

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

        public ProgramaPresentacionViewModel(string origen)
        {
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
            _fechaEjecucion = MetodosModelo.homologacionFecha();
            _salidaRealizada = false;
            _tokenRecepcionEncargos = "datosEncargosProgramaDocumentacion"; //Modificado
            _tokenRecepcionEncargosDetalle = "EncargoDocumentacionProgramaAuditoriaDetalle";//Modificado

            _tokenRecepcionReferencias = "DocumentacionDetalleReferenciaVista";//Referencia de encargo/documentacion/indice
            _tokenRecepcionReferenciasPlan = "PlanDetalleReferenciaVista";//Referencia de encargo/documentacion/indice

            _tokenEnvioCierre = "CierreEncargosDocumentacionPrograma";//Modificado
            _fuenteLlamado = 0;
            listaObjetivos = new ObservableCollection<DetalleProgramaModelo>();
            listaAlcances = new ObservableCollection<DetalleProgramaModelo>();
            listaDetalleProcedimientos = new ObservableCollection<DetalleProgramaModelo>();
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionEncargos, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionEncargosDetalle, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));

            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionReferencias, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionReferenciasPlan, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));

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
        private void ControlDetalleHerramientoCrudMensaje(ProgramaDatosMsj herramientasModeloElementoMensajes)
        {
            //Procesos normal
            currentEncargo = herramientasModeloElementoMensajes.encargoModelo;
            currentUsuario = herramientasModeloElementoMensajes.usuarioModelo;
            currentEntidad = herramientasModeloElementoMensajes.programaModelo;
            currentEntidadDetalle = herramientasModeloElementoMensajes.detallePrograma;
            encabezadoPantalla = currentEntidad.nombreprograma;
            horasplanprograma = currentEntidad.horasplanprograma;
            horasejecucionprograma = 0;

            visibilidadObjetivos = Visibility.Visible;
            visibilidadAlcances = Visibility.Visible;
            visibilidadObjetivosReducido = Visibility.Collapsed;
            visibilidadAlcancesReducido = Visibility.Collapsed;
            indiceHoras = 0;
            indiceProcedimientos = 0;
            horasejecucionprograma = 0;
            cantidadProcedimientosEjecucion = 0;
            cantidadProcedimientosPlan = 0;
            //Visibiliad de fechas
            if (currentEntidad.fechaaprobacion != null)
            {
                _visibilidadFAprobacion = Visibility.Visible;
            }
            if (currentEntidad.fechasupervision != null)
            {
                _visibilidadFSupervision = Visibility.Collapsed;
            }
            if (currentEntidad.fechacierre != null)
            {
                _visibilidadFElaboracion = Visibility.Collapsed;
            }
            //Procesado desde la ventana principal;
            if (herramientasModeloElementoMensajes.listaDetalleHerramientaP != null)
            {
                listaDetalleHerramienta = herramientasModeloElementoMensajes.listaDetalleHerramientaP;
            }
            else
            {
                listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAllVista(currentEntidad.idprograma,currentEncargo.idencargo));

            }
            switch (herramientasModeloElementoMensajes.fuenteLlamado)
            {
                case 1:
                    tokenEnvioCierre = "CierreEncargosPlanProgramaEncargos";//Modificado
                    fuenteLlamado = 1;
                    //listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAllVista(currentEntidad.idprograma));
                    break;
                case 2:
                    //Solicitud realizada desde la sub-ventana
                    fuenteLlamado = 2;
                    tokenEnvioCierre = "CierreEncargoPlanProgramaSub-ventana";
                    enviarMensajeInhabilitar(tokenEnvioCierre);
                    //listaDetalleHerramienta = herramientasModeloElementoMensajes.listaDetalleHerramientaP;
                    break;
                case 11:
                    tokenEnvioCierre = "CierreEncargosDocumentacionPrograma";//Modificado
                    fuenteLlamado = 11;
                    //listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAllVista(currentEntidad.idprograma));
                    //listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(currentEntidad.idprograma));
                    break;
                case 12:
                    tokenEnvioCierre = herramientasModeloElementoMensajes.tokenRespuesta; //Modificado
                    fuenteLlamado = 12;
                    //listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAllVista(currentEntidad.idprograma));
                    //listaDetalleHerramienta = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(currentEntidad.idprograma));
                    break;
                default:
                    if (!(string.IsNullOrEmpty(herramientasModeloElementoMensajes.tokenRespuesta) || string.IsNullOrWhiteSpace(herramientasModeloElementoMensajes.tokenRespuesta)))
                    {
                        tokenEnvioCierre = herramientasModeloElementoMensajes.tokenRespuesta;
                    }
                    fuenteLlamado = 13;
                    if (herramientasModeloElementoMensajes.fuenteLlamado == 1500)
                    {
                        visibilidadImprimir = Visibility.Visible;
                    }
                    else
                    {
                        visibilidadImprimir = Visibility.Collapsed;
                    }
                    break;
            }

            if (horasplanprograma > 0)
            {
                indiceHoras = 100 * (horasejecucionprograma / horasplanprograma);
            }
            else
            {
                indiceHoras = 0;
            }
            decimal contador = 1;
            decimal contadorProcedimiento = 1;
            decimal contadorAlcance = 1;

            DetalleProgramaModelo padre;
            decimal diferencia = 0;
            //Basado en el  supuesto que la lista viene ordenada con base a ordendp
            foreach (DetalleProgramaModelo item in listaDetalleHerramienta)
            {
                if ((item.nombreTipoProcedimiento.ToUpper() == "Objetivo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Objetivo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Objetivo".ToUpper()))
                {
                    if (item.idpadredp == null)
                    {
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(contador);
                    }
                    else
                    {
                        contador--;
                        diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contador, diferencia));
                    }
                    listaObjetivos.Add(item);
                    contador++;
                }
                else
                {
                    if (!((item.nombreTipoProcedimiento.ToUpper() == "Alcance".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Alcance".ToUpper() || (item.nombreTipoProcedimiento.ToUpper() == "Sub-sub-Alcance".ToUpper()))))
                    {
                        if ((item.nombreTipoProcedimiento.ToUpper() == "Titulo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Titulo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Titulo".ToUpper()) || ((item.nombreTipoProcedimiento.ToUpper() == "Indicaciones".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Indicaciones".ToUpper() || (item.nombreTipoProcedimiento.ToUpper() == "Sub-sub-Indicaciones".ToUpper()))))
                        {
                            item.ordenDhPresentacion = "";
                            listaDetalleProcedimientos.Add(item);
                        }
                        else
                        {
                            if (item.idpadredp == null)
                            {
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(contadorProcedimiento);
                            }
                            else
                            {
                                contadorProcedimiento--;
                                diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contadorProcedimiento, diferencia));
                            }
                            listaDetalleProcedimientos.Add(item);
                            contadorProcedimiento++;
                        }
                    }
                    else
                    {
                        if (item.idpadredp == null)
                        {
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(contadorAlcance);

                        }
                        else
                        {
                            contadorAlcance--;
                            diferencia = Decimal.Subtract((decimal)item.ordendp, Decimal.Truncate((decimal)item.ordendp));
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(Decimal.Add(contadorAlcance, diferencia));
                        }
                        listaAlcances.Add(item);
                        contadorAlcance++;
                    }
                }
                padre = item;
            }
            if (contadorAlcance > 1)
            {
                if (contadorAlcance == 2)
                {
                    visibilidadAlcancesReducido = Visibility.Visible;
                    visibilidadAlcances = Visibility.Collapsed;
                }
                else
                {
                    visibilidadAlcances = Visibility.Visible;
                    visibilidadAlcancesReducido = Visibility.Collapsed;
                }
            }
            else
            {
                visibilidadAlcances = Visibility.Collapsed;
                visibilidadAlcancesReducido = Visibility.Collapsed;
            }
            if (contador > 1)
            {
                if (contador == 2)
                {
                    visibilidadObjetivosReducido = Visibility.Visible;
                    visibilidadObjetivos = Visibility.Collapsed;
                }
                else
                {
                    visibilidadObjetivos = Visibility.Visible;
                }
            }
            else
            {
                visibilidadObjetivos = Visibility.Collapsed;
            }
            cantidadProcedimientosPlan = contadorProcedimiento - 1;
            cantidadProcedimientosEjecucion = 0;
            if (cantidadProcedimientosPlan > 0)
            {
                if (origenLlamada == "")
                {
                    indiceProcedimientos = 100 * cantidadProcedimientosEjecucion / cantidadProcedimientosPlan;
                }
                else
                {
                    indiceProcedimientos = currentEntidad.indiceEjecucionprograma;
                }
            }
            else
            {
                indiceProcedimientos = 0;
            }
            //Desuscribir mensaje
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionEncargos);//Proviene de pantalla principal
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionEncargosDetalle);//Proviene de sub-ventana
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionReferencias);
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionReferenciasPlan);

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
                        break;
                    case 2:
                        //Llamado desde la sub-ventana Plan
                        enviarMensajeCierre();
                        break;
                    case 3:
                        enviarMensajeCierre(); //Llamado desde documentacion
                        break;
                    case 4:
                        //Llamado desde la sub-ventana documentacion
                        enviarMensajeCierre();
                        break;
                    case 11:
                        //Llamado desde la sub-ventana documentacion
                        enviarMensajeCierre();
                        break;
                    case 12:
                        //Llamado desde la sub-ventana documentacion
                        enviarMensajeCierre();
                        break;
                    case 13:
                        enviarMensajeCierre();
                        break;
                    default:
                        enviarMensajeHabilitar(tokenEnvioCierre);
                        break;
                }
                /*if (fuenteLlamado != 1 && fuenteLlamado != 11)// Si es 1 o proviene del principal,  2 de la subventana // 11 Del principal pero de documentacion
                {
                    enviarMensajeHabilitar(tokenEnvioCierre);
                }
                else
                {
                    //Llamado desde la sub-ventana
                    enviarMensajeCierre();
                    //enviarMensajeHabilitar(tokenEnvioCierre);
                }*/
                CloseWindow();
                salidaRealizada = true;
            }
        }


        #endregion

        #region Mensajes

        //Procesando mensajes
        public void enviarMensajeInhabilitar()
        {
            //Para la ventana principal
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }

        public void enviarMensajeInhabilitar(string tokenEnvioCierre)
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar, tokenEnvioCierre);
        }
        public void enviarMensajeHabilitar(string tokenEnvioCierre)
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(habilitar, tokenEnvioCierre);
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
                ep.cantidadprocedplan = (decimal)currentEntidad.cantidadProcedimientosPlan;//(decimal)evaluacioninherentedmrAlto;
                ep.cantidadprocedejecucion = (decimal)currentEntidad.cantidadProcedimientosEjecucion;//(decimal)evaluacioncontroldmrAlto;
                ep.indiceejecucion = (decimal)currentEntidad.indiceEjecucionprograma;//(decimal)evaluacionDetecciondmrAlto;
                ep.horasplan = (decimal)currentEntidad.horasplanprograma;//(decimal)evaluacioninherentedmrMedio;
                ep.horasejecucion = (decimal)currentEntidad.horasejecucionprograma;//(decimal)evaluacioncontroldmrMedio;
                ep.indicehoras = (decimal)currentEntidad.indiceHoras;//(decimal)evaluacionDetecciondmrMedio;



                GenerarReporteMensajeModal msj = new GenerarReporteMensajeModal();
                msj.TipoReporteAGenerar = TipoReporteAGenerar.ReportePrograma;
                //public ObservableCollection<DetalleProgramaModelo> listaObjetivos
                //public ObservableCollection<DetalleProgramaModelo> listaAlcances
                //public ObservableCollection<DetalleProgramaModelo> listaDetalleProcedimientos
                msj.EncabezadosPiesReportesProgramasCuestionarios = ep;
                msj.listaObjetivos = listaObjetivos;
                msj.listaAlcances = listaAlcances;
                msj.listaDetalleProcedimientos = listaDetalleProcedimientos;

                ReportesAImpresionMainModel.TypeName = "ReportePrograma";
                Messenger.Default.Send<GenerarReporteMensajeModal>(msj, "GenerameUnReporte");
                CloseWindow();
            }

        }
        #endregion
    }
}

