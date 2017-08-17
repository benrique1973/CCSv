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
using System.Linq;
using SGPTmvvm.Model;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices
{
    public sealed class IndicePresentacionViewModel : ViewModeloBase
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

        #region fuenteLlamado 
        //Permite identificar si proviene del menu principal o si es de una ventana
        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion


        #region tokenRecepcionDeDetalle

        private string _tokenRecepcionDeDetalle;
        private string tokenRecepcionDeDetalle
        {
            get { return _tokenRecepcionDeDetalle; }
            set { _tokenRecepcionDeDetalle = value; }
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


        #region IndiceItemsTotales

        public const string IndiceItemsTotalesPropertyName = "IndiceItemsTotales";

        private decimal _IndiceItemsTotales;

        public decimal IndiceItemsTotales
        {
            get
            {
                return _IndiceItemsTotales;
            }

            set
            {
                if (_IndiceItemsTotales == value)
                {
                    return;
                }

                _IndiceItemsTotales = value;
                RaisePropertyChanged(IndiceItemsTotalesPropertyName);
            }
        }


        #endregion

        #region itemsTotalesReferenciados

        public const string itemsTotalesReferenciadosPropertyName = "itemsTotalesReferenciados";

        private int _itemsTotalesReferenciados;

        public int itemsTotalesReferenciados
        {
            get
            {
                return _itemsTotalesReferenciados;
            }

            set
            {
                if (_itemsTotalesReferenciados == value)
                {
                    return;
                }

                _itemsTotalesReferenciados = value;
                RaisePropertyChanged(itemsTotalesReferenciadosPropertyName);
            }
        }


        #endregion

        #region itemsTotales

        public const string itemsTotalesPropertyName = "itemsTotales";

        private int _itemsTotales;

        public int itemsTotales
        {
            get
            {
                return _itemsTotales;
            }

            set
            {
                if (_itemsTotales == value)
                {
                    return;
                }

                _itemsTotales = value;
                RaisePropertyChanged(itemsTotalesPropertyName);
            }
        }


        #endregion

        #region IndiceItemsVoluntarios

        public const string IndiceItemsVoluntariosPropertyName = "IndiceItemsVoluntarios";

        private decimal _IndiceItemsVoluntarios;

        public decimal IndiceItemsVoluntarios
        {
            get
            {
                return _IndiceItemsVoluntarios;
            }

            set
            {
                if (_IndiceItemsVoluntarios == value)
                {
                    return;
                }

                _IndiceItemsVoluntarios = value;
                RaisePropertyChanged(IndiceItemsVoluntariosPropertyName);
            }
        }


        #endregion

        #region itemsVoluntariosReferenciados

        public const string itemsVoluntariosReferenciadosPropertyName = "itemsVoluntariosReferenciados";

        private int _itemsVoluntariosReferenciados;

        public int itemsVoluntariosReferenciados
        {
            get
            {
                return _itemsVoluntariosReferenciados;
            }

            set
            {
                if (_itemsVoluntariosReferenciados == value)
                {
                    return;
                }

                _itemsVoluntariosReferenciados = value;
                RaisePropertyChanged(itemsVoluntariosReferenciadosPropertyName);
            }
        }


        #endregion

        #region itemsVoluntarios

        public const string itemsVoluntariosPropertyName = "itemsVoluntarios";

        private int _itemsVoluntarios;

        public int itemsVoluntarios
        {
            get
            {
                return _itemsVoluntarios;
            }

            set
            {
                if (_itemsVoluntarios == value)
                {
                    return;
                }



                _itemsVoluntarios = value;
                RaisePropertyChanged(itemsVoluntariosPropertyName);
            }
        }


        #endregion

        #region IndiceItemsObligatorios

        public const string IndiceItemsObligatoriosPropertyName = "IndiceItemsObligatorios";

        private decimal _IndiceItemsObligatorios;

        public decimal IndiceItemsObligatorios
        {
            get
            {
                return _IndiceItemsObligatorios;
            }

            set
            {
                if (_IndiceItemsObligatorios == value)
                {
                    return;
                }

                _IndiceItemsObligatorios = value;
                RaisePropertyChanged(IndiceItemsObligatoriosPropertyName);
            }
        }


        #endregion

        #region itemsObligatoriosReferenciados

        public const string itemsObligatoriosReferenciadosPropertyName = "itemsObligatoriosReferenciados";

        private int _itemsObligatoriosReferenciados;

        public int itemsObligatoriosReferenciados
        {
            get
            {
                return _itemsObligatoriosReferenciados;
            }

            set
            {
                if (_itemsObligatoriosReferenciados == value)
                {
                    return;
                }

                _itemsObligatoriosReferenciados = value;
                RaisePropertyChanged(itemsObligatoriosReferenciadosPropertyName);
            }
        }


        #endregion


        #region itemsObligatorios

        public const string itemsObligatoriosPropertyName = "itemsObligatorios";

        private int _itemsObligatorios;

        public int itemsObligatorios
        {
            get
            {
                return _itemsObligatorios;
            }

            set
            {
                if (_itemsObligatorios == value)
                {
                    return;
                }

                _itemsObligatorios = value;
                RaisePropertyChanged(itemsObligatoriosPropertyName);
            }
        }


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


        private DialogCoordinator dlg;

        private int idFirmaUnica = 2;//Id de firma a utilizar

        #endregion

        #region Lista de entidades


        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<IndiceModelo> _listaDetalleHerramienta;

        public ObservableCollection<IndiceModelo> listaDetalleHerramienta
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

        private TipoCarpetaModelo _currentEntidad;

        public TipoCarpetaModelo currentEntidad
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

        private IndiceModelo _currentEntidadDetalle;

        public IndiceModelo currentEntidadDetalle
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
                //currentEntidadDetalle.descripciondp = value;
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

        #endregion

        #region ViewModel Commands
        public RelayCommand ImprimirCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public IndicePresentacionViewModel()
        {
            ReportesAImpresionMainModel = new MainModel();
            enviarMensajeInhabilitar();
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

            _tokenRecepcionPadre = "LlamadaDePrincipal"; //Modificado

            _tokenRecepcionDeDetalle = "LlamadaDeDetalle";//Modificado

           _tokenEnvioCierre = string.Empty;//Modificado

            _fuenteLlamado = 0;
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<IndiceMsj>(this, tokenRecepcionPadre, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Register<IndiceMsj>(this, tokenRecepcionDeDetalle, (herramientasModeloElementoMensajes) => ControlDetalleHerramientoCrudMensaje(herramientasModeloElementoMensajes));

            accesibilidadWindow = false;
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            _IndiceItemsObligatorios = 0;
            _IndiceItemsTotales = 0;
            _IndiceItemsVoluntarios = 0;
            _itemsObligatorios = 0;
            _itemsVoluntarios = 0;
            _itemsTotales = 0;
            _itemsVoluntariosReferenciados = 0;
            _itemsTotalesReferenciados = 0;
            _itemsTotalesReferenciados = 0;
            RegisterCommands();
            _usuarioAprobo = string.Empty;
            _usuarioEjecuto = string.Empty;
            _usuarioSuperviso = string.Empty;
            _visibilidadFAprobacion = Visibility.Collapsed;
            _visibilidadFElaboracion = Visibility.Collapsed;
            _visibilidadFSupervision = Visibility.Collapsed;
            _visibilidadImprimir = Visibility.Collapsed;
            _fechaaprobo = string.Empty;
            _fechaejecuto = string.Empty;
            _fechasuperviso = string.Empty;
        }

        private void ControlDetalleHerramientoCrudMensaje(IndiceMsj herramientasModeloElementoMensajes)
        {
            //Procesos normal
            currentEncargo = herramientasModeloElementoMensajes.encargoModelo;
            currentUsuario = herramientasModeloElementoMensajes.usuarioModelo;
            currentEntidad = herramientasModeloElementoMensajes.tipoCarpetaModelo;
            //currentEntidadDetalle = herramientasModeloElementoMensajes.detalleCuestionario;
            encabezadoPantalla = "Carpeta : " +currentEntidad.descripcion;
            tokenEnvioCierre = herramientasModeloElementoMensajes.tokenRespuestaVista;

           fuenteLlamado = 1;
            if (herramientasModeloElementoMensajes.fuenteLlamado == 1500)
            {
                visibilidadImprimir = Visibility.Visible;
            }
            else
            {
                visibilidadImprimir = Visibility.Collapsed;
            }
            listaDetalleHerramienta = new ObservableCollection<IndiceModelo>(IndiceModelo.GetAllByIdTC(currentEntidad.id));
            if (listaDetalleHerramienta.Count > 0)
            {
                #region Indices

                #region Obligatorios

                currentEntidad.itemsObligatorios = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 &&
                                                                   x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10 &&
                                                                   x.obligatorioindice).Count();
                currentEntidad.itemsObligatoriosReferenciados = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 &&
                                                                  x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10 && x.obligatorioindice &&
                                                                  x.referenciaindice != null).Count();
                if (currentEntidad.itemsObligatorios > 0)
                {
                    currentEntidad.IndiceItemsObligatorios = ((decimal)currentEntidad.itemsObligatoriosReferenciados / (decimal)currentEntidad.itemsObligatorios) * 100;
                }
                else
                {
                    currentEntidad.IndiceItemsObligatorios = 0;
                }

                #endregion


                #region Voluntarios

                currentEntidad.itemsVoluntarios = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 &&
                                                                  x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10 &&
                                                                  !x.obligatorioindice).Count();
                currentEntidad.itemsVoluntariosReferenciados = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 &&
                                                                  x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10 && !x.obligatorioindice &&
                                                                  x.referenciaindice != null).Count();
                if (currentEntidad.itemsVoluntarios > 0)
                {
                    currentEntidad.IndiceItemsVoluntarios = ((decimal)currentEntidad.itemsVoluntariosReferenciados / (decimal)currentEntidad.itemsVoluntarios) * 100;
                }
                else
                { 
                    currentEntidad.IndiceItemsVoluntarios = 0;
                }

                #endregion


                #region Totales

                currentEntidad.itemsTotales = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 &&
                                                                  x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10).Count();
                currentEntidad.itemsTotalesReferenciados = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 &&
                                                                  x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10 && x.referenciaindice != null).Count();
                if (currentEntidad.itemsTotales > 0)
                {
                    currentEntidad.IndiceItemsTotales = ((decimal) currentEntidad.itemsTotalesReferenciados /(decimal) currentEntidad.itemsTotales) * 100;
                }
                else
                {
                    currentEntidad.IndiceItemsTotales = 0;
                }

                #endregion

                #endregion
            }
            //Basado en el  supuesto que la lista viene ordenada con base a ordendp
            //Desuscribir mensaje
            llenadoDatos();

            Messenger.Default.Unregister<IndiceMsj>(this, tokenRecepcionPadre);
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Unregister<IndiceMsj>(this, tokenRecepcionDeDetalle);

            Mouse.OverrideCursor = null;//Termino el proceso de  carga
            accesibilidadWindow = true;
        }

        private void llenadoDatos()
        {
            //Usuarios
            usuarioEjecuto = currentEntidad.usuariocerro;
            usuarioAprobo = currentEntidad.usuarioaprobo;
            usuarioSuperviso = currentEntidad.usuariosuperviso;
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
                }
                CloseWindow();
                enviarMensajeHabilitar();
                salidaRealizada = true;
            }
        }


        #endregion

        #region Mensajes

        //Procesando mensajes

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

        private async void imprimirReporte()
        {
            //dlg.ShowMessageAsync(this, "Proceso de impresion ", "En proceso");

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
                //EncabezadosPiesReportesProgramasCuestionarios ep = new EncabezadosPiesReportesProgramasCuestionarios();
                EncabezadosPiesReportesIndiceCarpetas ep = new EncabezadosPiesReportesIndiceCarpetas();

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
                ep.itemsObligatorios = (int)currentEntidad.itemsObligatorios; 
                ep.itemsObligatoriosReferenciados = (int)currentEntidad.itemsObligatoriosReferenciados;
                ep.IndiceItemsObligatorios = (decimal) currentEntidad.IndiceItemsObligatorios;
                ep.itemsVoluntarios = (int)currentEntidad.itemsVoluntarios;
                ep.itemsVoluntariosReferenciados = (int)currentEntidad.itemsVoluntariosReferenciados;
                ep.IndiceItemsVoluntarios = (decimal) currentEntidad.IndiceItemsVoluntarios;



                GenerarReporteMensajeModal msj = new GenerarReporteMensajeModal();
                msj.TipoReporteAGenerar = TipoReporteAGenerar.IndiceCarpeta;

                msj.EncabezadosPiesReportesIndiceCarpetas = ep;
                msj.listaDetalleHerramienta= listaDetalleHerramienta;



                ReportesAImpresionMainModel.TypeName = "ReporteIndiceCarpeta";
                Messenger.Default.Send<GenerarReporteMensajeModal>(msj, "GenerameUnReporte");

            }


        }
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
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
    }
}

