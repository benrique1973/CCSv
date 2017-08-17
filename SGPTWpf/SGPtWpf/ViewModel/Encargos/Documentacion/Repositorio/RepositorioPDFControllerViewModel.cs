using MahApps.Metro.Controls.Dialogs;
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
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Printing;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio
{
    public sealed class RepositorioPDFControllerViewModel : ViewModeloBase
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

        #region tokenDocumentoBinarioEnvio

        private string _tokenDocumentoBinarioEnvio;
        private string tokenDocumentoBinarioEnvio
        {
            get { return _tokenDocumentoBinarioEnvio; }
            set { _tokenDocumentoBinarioEnvio = value; }
        }

        #endregion

        #region tokenEnvioHijo

        private string _tokenEnvioHijo;
        private string tokenEnvioHijo
        {
            get { return _tokenEnvioHijo; }
            set { _tokenEnvioHijo = value; }
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

        #region tokenRecepcionPadreDetalle

        private string _tokenRecepcionPadreDetalle;
        private string tokenRecepcionPadreDetalle
        {
            get { return _tokenRecepcionPadreDetalle; }
            set { _tokenRecepcionPadreDetalle = value; }
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

        #region procesamiento Archivos

        #region ViewModel Properties : fileName

        public const string fileNamePropertyName = "fileName";

        private string _fileName;

        public string fileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                if (_fileName == value)
                {
                    return;
                }

                _fileName = value;
                RaisePropertyChanged(fileNamePropertyName);
            }
        }

        #endregion

        #endregion

        #region Lista de entidades

        #endregion Lista de entidades

        #region Propiedades

        #region Entidades


        #region ViewModel Property : currentEntidad repositorioModelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private RepositorioModelo _currentEntidad;

        public RepositorioModelo currentEntidad
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


        #region ViewModel Property : contenidoPdfArchivo 

        public const string contenidoPdfArchivoPropertyName = "contenidoPdfArchivo";

        private contenidoPDF _contenidoPdfArchivo;

        public contenidoPDF contenidoPdfArchivo
        {
            get
            {
                return _contenidoPdfArchivo;
            }

            set
            {
                if (_contenidoPdfArchivo == value) return;

                _contenidoPdfArchivo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(contenidoPdfArchivoPropertyName);
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

        #region fechaejecutoRepositorio

        public const string fechaejecutoRepositorioPropertyName = "fechaejecutoRepositorio";

        private string _fechaejecutoRepositorio;

        public string fechaejecutoRepositorio
        {
            get
            {
                return _fechaejecutoRepositorio;
            }

            set
            {
                if (_fechaejecutoRepositorio == value)
                {
                    return;
                }

                _fechaejecutoRepositorio = value;
                RaisePropertyChanged(fechaejecutoRepositorioPropertyName);
            }
        }


        #endregion

        #region fechasupervisoRepositorio

        public const string fechasupervisoRepositorioPropertyName = "fechasupervisoRepositorio";

        private string _fechasupervisoRepositorio;

        public string fechasupervisoRepositorio
        {
            get
            {
                return _fechasupervisoRepositorio;
            }

            set
            {
                if (_fechasupervisoRepositorio == value)
                {
                    return;
                }

                _fechasupervisoRepositorio = value;
                RaisePropertyChanged(fechasupervisoRepositorioPropertyName);
            }
        }


        #endregion

        #region fechaaproboRepositorio

        public const string fechaaproboRepositorioPropertyName = "fechaaproboRepositorio";

        private string _fechaaproboRepositorio;

        public string fechaaproboRepositorio
        {
            get
            {
                return _fechaaproboRepositorio;
            }

            set
            {
                if (_fechaaproboRepositorio == value)
                {
                    return;
                }

                _fechaaproboRepositorio = value;
                RaisePropertyChanged(fechaaproboRepositorioPropertyName);
            }
        }


        #endregion

        #endregion

        #region Repositorio Modelo

        #region referenciaRepositorio

        public const string referenciaRepositorioPropertyName = "referenciaRepositorio";

        private string _referenciaRepositorio = string.Empty;

        public string referenciaRepositorio
        {
            get
            {
                return _referenciaRepositorio;
            }

            set
            {
                if (_referenciaRepositorio == value)
                {
                    return;
                }

                _referenciaRepositorio = value;
                RaisePropertyChanged(referenciaRepositorioPropertyName);
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

        #region visibilidadHideEncabezado

        public const string visibilidadHideEncabezadoPropertyName = "visibilidadHideEncabezado";

        private Visibility _visibilidadHideEncabezado = Visibility.Collapsed;

        public Visibility visibilidadHideEncabezado
        {
            get
            {
                return _visibilidadHideEncabezado;
            }

            set
            {
                if (_visibilidadHideEncabezado == value)
                {
                    return;
                }

                _visibilidadHideEncabezado = value;
                RaisePropertyChanged(visibilidadHideEncabezadoPropertyName);
            }
        }

        #endregion

        #region visibilidadShowEncabezado

        public const string visibilidadShowEncabezadoPropertyName = "visibilidadShowEncabezado";

        private Visibility _visibilidadShowEncabezado = Visibility.Collapsed;

        public Visibility visibilidadShowEncabezado
        {
            get
            {
                return _visibilidadShowEncabezado;
            }

            set
            {
                if (_visibilidadShowEncabezado == value)
                {
                    return;
                }

                _visibilidadShowEncabezado = value;
                RaisePropertyChanged(visibilidadShowEncabezadoPropertyName);
            }
        }

        #endregion


        #region visibilidadHideMenu

        public const string visibilidadHideMenuPropertyName = "visibilidadHideMenu";

        private Visibility _visibilidadHideMenu = Visibility.Collapsed;

        public Visibility visibilidadHideMenu
        {
            get
            {
                return _visibilidadHideMenu;
            }

            set
            {
                if (_visibilidadHideMenu == value)
                {
                    return;
                }

                _visibilidadHideMenu = value;
                RaisePropertyChanged(visibilidadHideMenuPropertyName);
            }
        }

        #endregion

        #region visibilidadShowMenu

        public const string visibilidadShowMenuPropertyName = "visibilidadShowMenu";

        private Visibility _visibilidadShowMenu = Visibility.Collapsed;

        public Visibility visibilidadShowMenu
        {
            get
            {
                return _visibilidadShowMenu;
            }

            set
            {
                if (_visibilidadShowMenu == value)
                {
                    return;
                }

                _visibilidadShowMenu = value;
                RaisePropertyChanged(visibilidadShowMenuPropertyName);
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

        #region nombreRepositorioVista

        public const string nombreRepositorioVistaPropertyName = "nombreRepositorioVista";

        private string _nombreRepositorioVista = string.Empty;

        public string nombreRepositorioVista
        {
            get
            {
                return _nombreRepositorioVista;
            }

            set
            {
                if (_nombreRepositorioVista == value)
                {
                    return;
                }

                _nombreRepositorioVista = value;
                RaisePropertyChanged(nombreRepositorioVistaPropertyName);
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

        #region visibilidadExportarPdf

        public const string visibilidadExportarPdfPropertyName = "visibilidadExportarPdf";

        private Visibility _visibilidadExportarPdf = Visibility.Collapsed;

        public Visibility visibilidadExportarPdf
        {
            get
            {
                return _visibilidadExportarPdf;
            }

            set
            {
                if (_visibilidadExportarPdf == value)
                {
                    return;
                }

                _visibilidadExportarPdf = value;
                RaisePropertyChanged(visibilidadExportarPdfPropertyName);
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
        public RelayCommand hideEncabezadoCommand { get; set; }
        public RelayCommand showEncabezadoCommand { get; set; }
        public RelayCommand hideMenuCommand { get; set; }
        public RelayCommand showMenuCommand { get; set; }
        public RelayCommand ExportarPdfCommand { get; set; }


        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public RepositorioPDFControllerViewModel()
        {
        }
        public RepositorioPDFControllerViewModel(string origen)
        {
            _origenLlamada = origen;
            _contenidoPdfArchivo = new contenidoPDF();
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
            //Captura de titulo de Repositorio
            _resultadoProceso = 0;
            _salidaRealizada = false;
            switch (origen)
            {
                case "DocumentacionCartas":
                    fuenteLlamado = 13;
                    _tokenRecepcionPadre = "datosEDCartas"; //Modificado
                    _tokenRecepcionPadreDetalle = "datosEDCartasDetalle";//Modificado
                    _tokenEnvioCierre = "datosEDCartas";//Modificado
                    _tokenDocumentoBinarioEnvio = "DocumentoBinario";
                    _tokenEnvioHijo = "mandatoMenu";
                    break;
                case "IndiceDocumentacion":
                    fuenteLlamado = 13;
                    _tokenRecepcionPadre = "datosPadreDetalleIndices"; //Modificado
                    _tokenRecepcionPadreDetalle = "datosEDCartasDetalle";//Modificado
                    _tokenEnvioCierre = "datosEDCartas";//Modificado
                    _tokenDocumentoBinarioEnvio = "DocumentoBinario";
                    _tokenEnvioHijo = "mandatoMenu";
                    break;
            }
            //Mensaje de vista desde el menu principal
            Messenger.Default.Register<RepositorioMsj>(this, tokenRecepcionPadre, (msj) => ControlDetalleHerramientoCrudMensaje(msj));
            //Mensaje de  vista desde sub ventana
            Messenger.Default.Register<RepositorioMsj>(this, tokenRecepcionPadreDetalle, (msj) => ControlDetalleHerramientoCrudMensaje(msj));
 
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
            _visibilidadExportarPdf = Visibility.Visible;
            _visibilidadHideMenu = Visibility.Visible;
            _visibilidadShowMenu = Visibility.Collapsed;
            _visibilidadHideEncabezado = Visibility.Visible;
            _visibilidadShowEncabezado = Visibility.Collapsed;
        }
        private void ControlDetalleHerramientoCrudMensaje(RepositorioMsj msj)
        {
            //Procesos normal
            currentEncargo = msj.encargoModelo;
            currentUsuario = msj.usuarioModelo;
            currentEntidad = msj.entidadTrasladada;
            encabezadoPantalla = currentEntidad.nombrerepositorio;
            tokenEnvioCierre = msj.tokenRespuestaVista;
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
            if (msj.fuenteLlamado == 1500)
            {
                visibilidadImprimir = Visibility.Visible;
            }
            else
            {
                visibilidadImprimir = Visibility.Collapsed;
            }

            //Basado en el  supuesto que la lista viene ordenada con base a ordendp
            //Desuscribir mensaje
            Messenger.Default.Unregister<RepositorioMsj>(this, tokenRecepcionPadre);//Proviene de pantalla principal
            Messenger.Default.Unregister<RepositorioMsj>(this, tokenRecepcionPadreDetalle);//Proviene de sub-ventana
            contenidoPdfArchivo.NavigateExecute(msj);
            Mouse.OverrideCursor = null;//Termino el proceso de  carga
            accesibilidadWindow = true;
            //enviarBinario();
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
                    case 13:
                        enviarMensajeCierre();
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

            hideEncabezadoCommand = new RelayCommand(hideEncabezado);
            showEncabezadoCommand = new RelayCommand(showEncabezado);
            hideMenuCommand = new RelayCommand(hideMenu);
            showMenuCommand = new RelayCommand(showMenu);
            ExportarPdfCommand = new RelayCommand(ExportarPdf);

    }

        private void showMenu()
        {
            visibilidadShowMenu = Visibility.Collapsed;
            visibilidadHideMenu = Visibility.Visible;
            mensajeMenu(0); //mostrar el menu
        }

        private void mensajeMenu(int opcion)
        {
            switch (opcion)
                { 
                case 0:
                    Messenger.Default.Send(true, tokenEnvioHijo);
                    break;
            case 1:
                    Messenger.Default.Send(false, tokenEnvioHijo);
                    break;
                }
        }

        private void hideMenu()
        {
            visibilidadShowMenu = Visibility.Visible;
            visibilidadHideMenu = Visibility.Collapsed;
            mensajeMenu(1);//Oculatar el menu
        }

        private void showEncabezado()
        {
            visibilidadHideEncabezado = Visibility.Visible;
            visibilidadShowEncabezado = Visibility.Collapsed;
        }

        private void hideEncabezado()
        {
            visibilidadHideEncabezado = Visibility.Collapsed;
            visibilidadShowEncabezado = Visibility.Visible;
        }

        #endregion

        #region Impresion

        private void imprimirReporte()
        {
            //dlg.ShowMessageAsync(this, "Proceso de impresion aqui cae ", "En proceso");

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //fileName = Path.g.GetTempPath() + currentEntidad.nombrepdf;
            if (!string.IsNullOrEmpty(mydocpath))
            {
                fileName = mydocpath + @"\" + currentEntidad.nombrepdf;
            }
            else
            {
                fileName = Path.GetTempPath() + currentEntidad.nombrepdf;
            }
            try
            {
                if(!File.Exists(fileName))
                    File.WriteAllBytes(fileName, currentEntidad.pdfrepositorio);
                var pi = new ProcessStartInfo(fileName);
                pi.UseShellExecute = true;
                pi.Verb = "print";
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                pi.CreateNoWindow = true;
                pi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //var process = System.Diagnostics.Process.Start(pi);
                p.StartInfo = pi;
                p.Start();
                MessageBox.Show("El documento ha sido enviado a la cola de impresion");
            }
            catch (Exception g)
            {
                mensajeFalloPdf(g);
                //dlg.ShowMessageAsync(this, "No tiene una aplicación instalada que maneje el archivo " + k.Message, "");
            }


        }
        #endregion

        #region exportacion

        private void ExportarPdf()
        {
            bool resultado = false;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //fileName = Path.g.GetTempPath() + currentEntidad.nombrepdf;
                if (!string.IsNullOrEmpty(mydocpath))
                {
                    //https://msdn.microsoft.com/es-es/library/6ka1wd3w(v=vs.110).aspx
                    fileName = mydocpath + @"\" + currentEntidad.nombrepdf;
                }
                else
                {
                    //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
                    fileName = Path.GetTempPath() + currentEntidad.nombrepdf;
                }
                try
                {
                    File.WriteAllBytes(fileName, currentEntidad.pdfrepositorio);
                    //listaArchivosCreados.Add(fileName);
                    //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                    Process.Start(fileName);
                    //this.CloseWindow();
                    resultado = true;
                    Salir();
                }
                catch (Exception g)
                {
                    mensajeFalloPdf(g);
                    //dlg.ShowMessageAsync(this, "No tiene una aplicación instalada que maneje el archivo " + k.Message, "");
                    resultado = false;
                }
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                if (!(resultado))
                {
                    Salir();

                }
            };
            worker.RunWorkerAsync();
            worker.Dispose();
        }

        private async void mensajeFalloPdf(RunWorkerCompletedEventArgs e)
        {
            await dlg.ShowMessageAsync(this, "No se pudo exportar el archivo " + e.ToString(), "");
        }

        private async void mensajeFalloPdf(Exception e)
        {
            await dlg.ShowMessageAsync(this, "No se pudo exportar el archivo porque hay otro archivo con el mismo nombre estando abierto" + e.Message, "");
        }


        private void generico()
        {
            //Nada solo para bloquear
        }

        #endregion

    }
}

