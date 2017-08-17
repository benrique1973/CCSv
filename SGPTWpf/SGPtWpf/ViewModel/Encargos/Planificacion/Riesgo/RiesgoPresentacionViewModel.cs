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
using SGPTWpf.Model;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Linq;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo
{
    public sealed class RiesgoPresentacionViewModel : ViewModeloBase
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

        #region Lista de entidades


        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<DetalleMatrizRiesgoModelo> _listaDetalleHerramienta;

        public ObservableCollection<DetalleMatrizRiesgoModelo> listaDetalleHerramienta
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

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<DetalleMatrizRiesgoModelo> _lista;

        public ObservableCollection<DetalleMatrizRiesgoModelo> lista
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

        #endregion Lista de entidades

        #region Propiedades

        #region Entidades

        #region TipoMatrizRiesgoModelo

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

        #region ViewModel Property : currentEntidad Herramienta Modelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private MatrizRiesgoModelo _currentEntidad;

        public MatrizRiesgoModelo currentEntidad
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

        private DetalleMatrizRiesgoModelo _currentEntidadDetalle;

        public DetalleMatrizRiesgoModelo currentEntidadDetalle
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

        #region evaluacioncontroldmrBajo

        public const string evaluacioncontroldmrBajoPropertyName = "evaluacioncontroldmrBajo";

        private int _evaluacioncontroldmrBajo = 0;

        public int evaluacioncontroldmrBajo
        {
            get
            {
                return _evaluacioncontroldmrBajo;
            }

            set
            {
                if (_evaluacioncontroldmrBajo == value)
                {
                    return;
                }

                _evaluacioncontroldmrBajo = value;
                RaisePropertyChanged(evaluacioncontroldmrBajoPropertyName);
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

        #endregion

        #region Programa Modelo


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

        #region evaluacioncontroldmrAlto

        public const string evaluacioncontroldmrAltoPropertyName = "evaluacioncontroldmrAlto";

        private decimal? _evaluacioncontroldmrAlto = 0;

        public decimal? evaluacioncontroldmrAlto
        {
            get
            {
                return _evaluacioncontroldmrAlto;
            }

            set
            {
                if (_evaluacioncontroldmrAlto == value)
                {
                    return;
                }

                _evaluacioncontroldmrAlto = value;
                RaisePropertyChanged(evaluacioncontroldmrAltoPropertyName);
            }
        }

        #endregion

        #region evaluacioncontroldmrMedio

        public const string evaluacioncontroldmrMedioPropertyName = "evaluacioncontroldmrMedio";

        private decimal? _evaluacioncontroldmrMedio = 0;

        public decimal? evaluacioncontroldmrMedio
        {
            get
            {
                return _evaluacioncontroldmrMedio;
            }

            set
            {
                if (_evaluacioncontroldmrMedio == value)
                {
                    return;
                }

                _evaluacioncontroldmrMedio = value;
                RaisePropertyChanged(evaluacioncontroldmrMedioPropertyName);
            }
        }

        #endregion

        #region evaluacioninherentedmrAlto

        public const string evaluacioninherentedmrAltoPropertyName = "evaluacioninherentedmrAlto";

        private decimal? _evaluacioninherentedmrAlto = 0;

        public decimal? evaluacioninherentedmrAlto
        {
            get
            {
                return _evaluacioninherentedmrAlto;
            }

            set
            {
                if (_evaluacioninherentedmrAlto == value)
                {
                    return;
                }

                _evaluacioninherentedmrAlto = value;
                RaisePropertyChanged(evaluacioninherentedmrAltoPropertyName);
            }
        }

        #endregion

        #region evaluacioninherentedmrMedio

        public const string evaluacioninherentedmrMedioPropertyName = "evaluacioninherentedmrMedio";

        private decimal? _evaluacioninherentedmrMedio = 0;

        public decimal? evaluacioninherentedmrMedio
        {
            get
            {
                return _evaluacioninherentedmrMedio;
            }

            set
            {
                if (_evaluacioninherentedmrMedio == value)
                {
                    return;
                }

                _evaluacioninherentedmrMedio = value;
                RaisePropertyChanged(evaluacioninherentedmrMedioPropertyName);
            }
        }

        #endregion

        #region evaluacioninherentedmrBajo

        public const string evaluacioninherentedmrBajoPropertyName = "evaluacioninherentedmrBajo";

        private decimal? _evaluacioninherentedmrBajo = 0;

        public decimal? evaluacioninherentedmrBajo
        {
            get
            {
                return _evaluacioninherentedmrBajo;
            }

            set
            {
                if (_evaluacioninherentedmrBajo == value)
                {
                    return;
                }

                _evaluacioninherentedmrBajo = value;
                RaisePropertyChanged(evaluacioninherentedmrBajoPropertyName);
            }
        }

        #endregion


        #region evaluacionDetecciondmrAlto

        public const string evaluacionDetecciondmrAltoPropertyName = "evaluacionDetecciondmrAlto";

        private decimal? _evaluacionDetecciondmrAlto = 0;

        public decimal? evaluacionDetecciondmrAlto
        {
            get
            {
                return _evaluacionDetecciondmrAlto;
            }

            set
            {
                if (_evaluacionDetecciondmrAlto == value)
                {
                    return;
                }

                _evaluacionDetecciondmrAlto = value;
                RaisePropertyChanged(evaluacionDetecciondmrAltoPropertyName);
            }
        }

        #endregion

        #region evaluacionDetecciondmrMedio

        public const string evaluacionDetecciondmrMedioPropertyName = "evaluacionDetecciondmrMedio";

        private decimal? _evaluacionDetecciondmrMedio = 0;

        public decimal? evaluacionDetecciondmrMedio
        {
            get
            {
                return _evaluacionDetecciondmrMedio;
            }

            set
            {
                if (_evaluacionDetecciondmrMedio == value)
                {
                    return;
                }

                _evaluacionDetecciondmrMedio = value;
                RaisePropertyChanged(evaluacionDetecciondmrMedioPropertyName);
            }
        }

        #endregion

        #region evaluacionDetecciondmrBajo

        public const string evaluacionDetecciondmrBajoPropertyName = "evaluacionDetecciondmrBajo";

        private decimal? _evaluacionDetecciondmrBajo = 0;

        public decimal? evaluacionDetecciondmrBajo
        {
            get
            {
                return _evaluacionDetecciondmrBajo;
            }

            set
            {
                if (_evaluacionDetecciondmrBajo == value)
                {
                    return;
                }

                _evaluacionDetecciondmrBajo = value;
                RaisePropertyChanged(evaluacionDetecciondmrBajoPropertyName);
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


        #endregion

        #region ViewModel Commands

        public RelayCommand SalirCommand { get; set; }

        public RelayCommand ImprimirCommand { get; set; }
        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public RiesgoPresentacionViewModel()
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

            _tokenRecepcionEncargos = "datosEDRiesgos";

            _tokenRecepcionEncargosDetalle = "datosPadreDetalleRiesgos";

            _tokenRecepcionReferencias= "PlanDetalleReferenciaVista";//Recepcion de indices 


            _tokenEnvioCierre = string.Empty;
            _fuenteLlamado = 0;
            lista = new ObservableCollection<DetalleMatrizRiesgoModelo>();
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<RiesgoMsj>(this, tokenRecepcionReferencias, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));


            Messenger.Default.Register<RiesgoMsj>(this, tokenRecepcionEncargos, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Register<RiesgoMsj>(this, tokenRecepcionEncargosDetalle, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));

            accesibilidadWindow = true;
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
            _evaluacioncontroldmrAlto = 0;
            _evaluacioncontroldmrMedio = 0;
            _evaluacioncontroldmrBajo = 0;
            _evaluacioninherentedmrAlto = 0;
            _evaluacioninherentedmrMedio = 0;
            _evaluacioninherentedmrBajo = 0;
            _evaluacionDetecciondmrAlto = 0;
            _evaluacionDetecciondmrMedio = 0;
            _evaluacioninherentedmrBajo = 0;
            _visibilidadImprimir = Visibility.Collapsed;

        }

        private void ControlDetalleHerramientoCrudMensaje(RiesgoMsj herramientasModeloElementoMensajes)
        {
            //Procesos normal
            currentEncargo = herramientasModeloElementoMensajes.encargoModelo;
            currentUsuario = herramientasModeloElementoMensajes.usuarioModelo;
            currentEntidad = herramientasModeloElementoMensajes.matrizRiesgoModelo;
            tokenEnvioCierre = herramientasModeloElementoMensajes.tokenRespuesta;
            actualizarLista();
            encabezadoPantalla = "MATRIZ DE ESTIMACIÓN DE RIESGOS DE AUDITORÍA AL "+ currentEntidad.fechaevaluacionmr;
            evaluacioninherentedmrBajo = 0;
            indiceProcedimientos = 0;
            evaluacioncontroldmrMedio = 0;
            evaluacioninherentedmrMedio = 0;
            evaluacioninherentedmrAlto = 0;
            //Procesado desde la ventana principal;
            fuenteLlamado = herramientasModeloElementoMensajes.fuenteLlamado;
            if (herramientasModeloElementoMensajes.fuenteLlamado == 1500)
            {
                visibilidadImprimir = Visibility.Visible;
            }
            else
            {
                visibilidadImprimir = Visibility.Collapsed;
            }
            llenadoDatos();

            //Basado en el  supuesto que la lista viene ordenada con base a ordendp
            //Desuscribir mensaje
            Messenger.Default.Unregister<RiesgoMsj>(this, tokenRecepcionEncargos);//Proviene de pantalla principal
            Messenger.Default.Unregister<RiesgoMsj>(this, tokenRecepcionEncargosDetalle);//Proviene de sub-ventana
            Mouse.OverrideCursor = null;//Termino el proceso de  carga
            accesibilidadWindow = true;
            enviarMensajeInhabilitar();
        }

        private void llenadoDatos()
        {
            //Usuarios
            usuarioEjecuto = currentEntidad.usuariocerro;
            usuarioAprobo = currentEntidad.usuarioaprobo;
            usuarioSuperviso = currentEntidad.usuariosuperviso;
            //llenar referencia
            if (currentEntidad.referenciamr != null && currentEntidad.referenciamr != "")
            {
                referencia = currentEntidad.referenciamr;

            }
            else
            {
                referencia = string.Empty;
            }
            //Llenar fecha de cierre
            if (currentEntidad.fechacierre != null && currentEntidad.fechacierre != "")
            {

                fechaejecuto = currentEntidad.fechacierre;
                visibilidadFElaboracion = Visibility.Visible;
            }
            else
            {
                fechaejecuto = DateTime.Now.ToShortDateString();
                visibilidadFElaboracion = Visibility.Collapsed;
            }
            //Llenar fecha de supervision
            if (currentEntidad.fechasupervision != null && currentEntidad.fechasupervision != "")
            {

                fechasuperviso = currentEntidad.fechasupervision;
                visibilidadFSupervision = Visibility.Visible;
            }
            else
            {
                fechasuperviso = DateTime.Now.ToShortDateString();
            }
            //Llenar fecha de supervision
            if (currentEntidad.fechaaprobacion != null && currentEntidad.fechaaprobacion != "")
            {

                fechaaprobo = currentEntidad.fechaaprobacion;
                visibilidadFAprobacion = Visibility.Visible;
            }
            else
            {
                fechaaprobo = DateTime.Now.ToShortDateString();
            }
            //Llenado de riesgos
            evaluacioninherentedmrAlto = lista.Where(x=>x.evaluacioninherentedmr.ToUpper()=="ALTO").Count();
            evaluacioninherentedmrMedio = lista.Where(x => x.evaluacioninherentedmr.ToUpper() == "MEDIO").Count();
            evaluacioninherentedmrBajo = lista.Where(x => x.evaluacioninherentedmr.ToUpper() == "BAJO").Count();
            evaluacioncontroldmrAlto = lista.Where(x => x.evaluacioncontroldmr.ToUpper() == "ALTO").Count();
            evaluacioncontroldmrMedio = lista.Where(x => x.evaluacioncontroldmr.ToUpper() == "MEDIO").Count();
            evaluacioncontroldmrBajo = lista.Where(x => x.evaluacioncontroldmr.ToUpper() == "BAJO").Count();
            evaluacionDetecciondmrAlto = lista.Where(x => x.evaluacioncombinadodmr.ToUpper() == "ALTO").Count();
            evaluacionDetecciondmrMedio = lista.Where(x => x.evaluacioncombinadodmr.ToUpper() == "MEDIO").Count();
            evaluacionDetecciondmrBajo = lista.Where(x => x.evaluacioncombinadodmr.ToUpper() == "BAJO").Count();
        }
        #endregion
        private void actualizarLista()
        {
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<MatrizRiesgoModelo>(MatrizRiesgoModelo.GetAll(currentEncargo.idencargo));
                lista = new ObservableCollection<DetalleMatrizRiesgoModelo>(DetalleMatrizRiesgoModelo.GetAll(currentEntidad));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e, "");

                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }

        private void Salir()
        {
            ReportesAImpresionMainModel.TypeName = null;
            if (!salidaRealizada)
            {
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                enviarMensajeCierre();//Cero por cancelamiento
                enviarMensajeHabilitar();
                fuenteLlamado = 100;
                CloseWindow();
            }
            else
            {
                if (fuenteLlamado == 100)
                {
                    //Ya se hizo el proceso
                }
                else
                {
                    enviarMensajeCierre();
                    CloseWindow();
                    enviarMensajeHabilitar();
                    salidaRealizada = true;
                }
            }
            //listaDetallePrograma = null;
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

        public void enviarMensajeHabilitar()
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(habilitar);
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
            //dlg.ShowMessageAsync(this, "Proceso de impresion ", "En proceso");
            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Acepto",
                NegativeButtonText = "Cancelar",

            };
            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El documento sera enviado a impresion.", "Desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
            if (resultk == MessageDialogResult.Affirmative)
            {
                //CargarArchivosMensajeModal msj = new CargarArchivosMensajeModal();
                EncabezadosPiesReporteMatrizRiesgos ep = new EncabezadosPiesReporteMatrizRiesgos();

                ep.urlLogo = "";
                ep.logofirma = logoFirma;
                ep.referencia = referencia;
                ep.razonSocialFirma = razonSocialFirma;
                ep.encabezadoPantalla = encabezadoPantalla;
                ep.descripcionTipoAuditoria = currentEncargo.descripcionTipoAuditoria;
                ep.razonsocialcliente = currentEncargo.razonsocialcliente;//razonsocialcliente;
                ep.usuarioEjecuto = usuarioEjecuto;
                ep.fechaejecuto = fechaejecuto;
                ep.fechainiperauditencargo = currentEncargo.fechainiperauditencargo;
                ep.fechafinperauditencargo = currentEncargo.fechafinperauditencargo;
                ep.usuarioSuperviso = usuarioSuperviso;
                ep.fechasuperviso = fechasuperviso;
                ep.usuarioAprobo = usuarioAprobo;
                ep.fechaaprobo = fechaaprobo;

                //pie de pagina.
                ep.evaluacioninherentedmrAlto = (decimal)evaluacioninherentedmrAlto;
                ep.evaluacioncontroldmrAlto = (decimal)evaluacioncontroldmrAlto;
                ep.evaluacionDetecciondmrAlto = (decimal)evaluacionDetecciondmrAlto;
                ep.evaluacioninherentedmrMedio= (decimal)evaluacioninherentedmrMedio;
                ep.evaluacioncontroldmrMedio  = (decimal)evaluacioncontroldmrMedio;
                ep.evaluacionDetecciondmrMedio= (decimal)evaluacionDetecciondmrMedio;
                ep.evaluacioninherentedmrBajo = (decimal)evaluacioninherentedmrBajo;
                ep.evaluacioncontroldmrBajo   = (decimal)evaluacioncontroldmrAlto;
                ep.evaluacionDetecciondmrBajo = (decimal)evaluacionDetecciondmrBajo;


                GenerarReporteMensajeModal msj = new GenerarReporteMensajeModal();
                msj.TipoReporteAGenerar = TipoReporteAGenerar.ReporteMatrizRiesgos;
                msj.listaMatrizRiesgoModelo = lista;
                msj.EncabezadosPiesReporteMatrizRiesgos = ep;

                ReportesAImpresionMainModel.TypeName = "ReporteMatrizRiesgo";
                Messenger.Default.Send<GenerarReporteMensajeModal>(msj, "GenerameUnReporte");

            }
        }
        #endregion

    }
}

