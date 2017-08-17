using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using CapaDatos;
using System.Linq;
using System.Windows;
using SGPTWpf.Model;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using Microsoft.Win32;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio
{

    public sealed class RepositorioModeloController : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        #region cerradoFinalVentana

        private bool _cerradoFinalVentana;
        private bool cerradoFinalVentana
        {
            get { return _cerradoFinalVentana; }
            set { _cerradoFinalVentana = value; }
        }

        #endregion

        #region tokenEnvio

        private string _tokenEnvio;
        private string tokenEnvio
        {
            get { return _tokenEnvio; }
            set { _tokenEnvio = value; }
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

        #region maxDescripcion

        private int _maxDescripcion;
        private int maxDescripcion
        {
            get { return _maxDescripcion; }
            set { _maxDescripcion = value; }
        }

        #endregion

        #region tamanoArchivo

        private int _tamanoArchivo;
        private int tamanoArchivo
        {
            get { return _tamanoArchivo; }
            set { _tamanoArchivo = value; }
        }

        #endregion

        #region numeroProcesoCrudRecibido

        private int _numeroProcesoCrudRecibido;
        private int numeroProcesoCrudRecibido
        {
            get { return _numeroProcesoCrudRecibido; }
            set { _numeroProcesoCrudRecibido = value; }
        }

        #endregion

        #region origen

        private string _origen;
        private string origen
        {
            get { return _origen; }
            set { _origen = value; }
        }

        #endregion

        #region opcionMenu

        private int _opcionMenu;
        private int opcionMenu
        {
            get { return _opcionMenu; }
            set { _opcionMenu = value; }
        }

        #endregion

        #region FuenteCierre

        private int _fuenteCierre;
        private int fuenteCierre
        {
            get { return _fuenteCierre; }
            set { _fuenteCierre = value; }
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

        private DialogCoordinator dlg;

        public static int Errors { get; set; }//Para controllar los errores de edición

        #endregion

        #region ViewModel Properties listas

        #region ViewModel Properties : isListaCargada

        public const string isListaCargadaPropertyName = "isListaCargada";

        private bool _isListaCargada;

        public bool isListaCargada
        {
            get
            {
                return _isListaCargada;
            }

            set
            {
                if (_isListaCargada == value)
                {
                    return;
                }

                _isListaCargada = value;
                RaisePropertyChanged(isListaCargadaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDocumentosAnteriores

        public const string listaDocumentosAnterioresPropertyName = "listaDocumentosAnteriores";

        private ObservableCollection<RepositorioModelo> _listaDocumentosAnteriores;

        public ObservableCollection<RepositorioModelo> listaDocumentosAnteriores
        {
            get
            {
                return _listaDocumentosAnteriores;
            }

            set
            {
                if (_listaDocumentosAnteriores == value) return;

                _listaDocumentosAnteriores = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDocumentosAnterioresPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDocumentosAnterioresCompleta

        public const string listaDocumentosAnterioresCompletaPropertyName = "listaDocumentosAnterioresCompleta";

        private ObservableCollection<RepositorioModelo> _listaDocumentosAnterioresCompleta;

        public ObservableCollection<RepositorioModelo> listaDocumentosAnterioresCompleta
        {
            get
            {
                return _listaDocumentosAnterioresCompleta;
            }

            set
            {
                if (_listaDocumentosAnterioresCompleta == value) return;

                _listaDocumentosAnterioresCompleta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDocumentosAnterioresCompletaPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listacurrentEntidad

        public const string listacurrentEntidadPropertyName = "listacurrentEntidad";

        private ObservableCollection<RepositorioModelo> _listacurrentEntidad;

        public ObservableCollection<RepositorioModelo> listacurrentEntidad
        {
            get
            {
                return _listacurrentEntidad;
            }

            set
            {
                if (_listacurrentEntidad == value) return;

                _listacurrentEntidad = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listacurrentEntidadPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaTiposAuditoria

        public const string listaTiposAuditoriaPropertyName = "listaTiposAuditoria";

        private ObservableCollection<TipoAuditoriaModelo> _listaTiposAuditoria;

        public ObservableCollection<TipoAuditoriaModelo> listaTiposAuditoria
        {
            get
            {
                return _listaTiposAuditoria;
            }
            set
            {
                if (_listaTiposAuditoria == value) return;

                _listaTiposAuditoria = value;
                RaisePropertyChanged(listaTiposAuditoriaPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaClaseDocumentos

        public const string listaClaseDocumentosPropertyName = "listaClaseDocumentos";

        private ObservableCollection<DocumentoModelo> _listaClaseDocumentos;

        public ObservableCollection<DocumentoModelo> listaClaseDocumentos
        {
            get
            {
                return _listaClaseDocumentos;
            }
            set
            {
                if (_listaClaseDocumentos == value) return;

                _listaClaseDocumentos = value;

                RaisePropertyChanged(listaClaseDocumentosPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedDocumentoModelo

        public const string selectedDocumentoModeloPropertyName = "selectedDocumentoModelo";

        private DocumentoModelo _selectedDocumentoModelo;

        public DocumentoModelo selectedDocumentoModelo
        {
            get
            {
                return _selectedDocumentoModelo;
            }

            set
            {
                if (_selectedDocumentoModelo == value) return;

                _selectedDocumentoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedDocumentoModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionDocumentoModelo

        public const string eleccionDocumentoModeloPropertyName = "eleccionDocumentoModelo";

        private DocumentoModelo _eleccionDocumentoModelo;

        public DocumentoModelo eleccionDocumentoModelo
        {
            get
            {
                return _eleccionDocumentoModelo;
            }

            set
            {
                if (_eleccionDocumentoModelo == value) return;

                _eleccionDocumentoModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionDocumentoModeloPropertyName);
            }
        }

        #endregion


        #region Propiedades : nombrerepositorio 

        public const string nombrerepositorioPropertyName = "nombrerepositorio";

        private string _nombrerepositorio = string.Empty;


        public string nombrerepositorio
        {
            get
            {
                return _nombrerepositorio;
            }
            set
            {
                if (_nombrerepositorio == value)
                {
                    return;
                }
                _nombrerepositorio = value;
                RaisePropertyChanged(nombrerepositorioPropertyName);
            }
        }

        #endregion

        #region Propiedades : btnContenidoPdf 

        public const string btnContenidoPdfPropertyName = "btnContenidoPdf";

        private string _btnContenidoPdf = string.Empty;


        public string btnContenidoPdf
        {
            get
            {
                return _btnContenidoPdf;
            }
            set
            {
                if (_btnContenidoPdf == value)
                {
                    return;
                }
                _btnContenidoPdf = value;
                RaisePropertyChanged(btnContenidoPdfPropertyName);
            }
        }

        #endregion

        #region Propiedades : btnContenidoFuente 

        public const string btnContenidoFuentePropertyName = "btnContenidoFuente";

        private string _btnContenidoFuente = string.Empty;


        public string btnContenidoFuente
        {
            get
            {
                return _btnContenidoFuente;
            }
            set
            {
                if (_btnContenidoFuente == value)
                {
                    return;
                }
                _btnContenidoFuente = value;
                RaisePropertyChanged(btnContenidoFuentePropertyName);
            }
        }

        #endregion        


        #region Primary key Plantilla Indice


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

                _id = value;
                RaisePropertyChanged(idpiPropertyName);
            }
        }

        #endregion

        #region Primary key Tipo Auditoria


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

        #region sistemapi


        public const string sistemapiPropertyName = "sistemapi";

        private bool _sistemapi = false;


        public bool sistemapi
        {
            get
            {
                return _sistemapi;
            }

            set
            {
                if (_sistemapi == value)
                {
                    return;
                }

                _sistemapi = value;
                RaisePropertyChanged(sistemapiPropertyName);
            }
        }

        #endregion

        #region estadopi


        public const string estadopiPropertyName = "estadopi";

        private string _estadopi = string.Empty;

        public string estadopi
        {
            get
            {
                return _estadopi;
            }

            set
            {
                if (_estadopi == value)
                {
                    return;
                }

                _estadopi = value;
                RaisePropertyChanged(estadopiPropertyName);
            }
        }

        #endregion

        #region fechacreadopi


        public const string fechacreadopiPropertyName = "fechacreadopi";

        private string _fechacreadopi = string.Empty;

        public string fechacreadopi
        {
            get
            {
                return _fechacreadopi;
            }

            set
            {
                if (_fechacreadopi == value)
                {
                    return;
                }

                _fechacreadopi = value;
                RaisePropertyChanged(fechacreadopiPropertyName);
            }
        }

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

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

        #region ViewModel Property : currentClaseDocumento

        public const string currentClaseDocumentoPropertyName = "currentClaseDocumento";

        private DocumentoModelo _currentClaseDocumento;

        public DocumentoModelo currentClaseDocumento
        {
            get
            {
                return _currentClaseDocumento;
            }

            set
            {
                if (_currentClaseDocumento == value) return;

                _currentClaseDocumento = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentClaseDocumentoPropertyName);
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

        #region visibilidadPlantilla

        public const string visibilidadPlantillaPropertyName = "visibilidadPlantilla";

        private Visibility _visibilidadPlantilla = Visibility.Collapsed;

        public Visibility visibilidadPlantilla
        {
            get
            {
                return _visibilidadPlantilla;
            }

            set
            {
                if (_visibilidadPlantilla == value)
                {
                    return;
                }

                _visibilidadPlantilla = value;
                RaisePropertyChanged(visibilidadPlantillaPropertyName);
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

        #region visibilidad botones  inferiores

        #region visibilidadReferenciar

        public const string visibilidadReferenciarPropertyName = "visibilidadReferenciar";

        private Visibility _visibilidadReferenciar = Visibility.Visible;

        public Visibility visibilidadReferenciar
        {
            get
            {
                return _visibilidadReferenciar;
            }

            set
            {
                if (_visibilidadReferenciar == value)
                {
                    return;
                }

                _visibilidadReferenciar = value;
                RaisePropertyChanged(visibilidadReferenciarPropertyName);
            }
        }

        #endregion

        #region  visibilidadAprobar

        public const string visibilidadAprobarPropertyName = "visibilidadAprobar";

        private Visibility _visibilidadAprobar = Visibility.Visible;

        public Visibility visibilidadAprobar
        {
            get
            {
                return _visibilidadAprobar;
            }

            set
            {
                if (_visibilidadAprobar == value)
                {
                    return;
                }

                _visibilidadAprobar = value;
                RaisePropertyChanged(visibilidadAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadSupervisar

        public const string visibilidadSupervisarPropertyName = "visibilidadSupervisar";

        private Visibility _visibilidadSupervisar = Visibility.Visible;

        public Visibility visibilidadSupervisar
        {
            get
            {
                return _visibilidadSupervisar;
            }

            set
            {
                if (_visibilidadSupervisar == value)
                {
                    return;
                }

                _visibilidadSupervisar = value;
                RaisePropertyChanged(visibilidadSupervisarPropertyName);
            }
        }

        #endregion


        #region visibilidadCerrar

        public const string visibilidadCerrarPropertyName = "visibilidadCerrar";

        private Visibility _visibilidadCerrar = Visibility.Visible;

        public Visibility visibilidadCerrar
        {
            get
            {
                return _visibilidadCerrar;
            }

            set
            {
                if (_visibilidadCerrar == value)
                {
                    return;
                }

                _visibilidadCerrar = value;
                RaisePropertyChanged(visibilidadCerrarPropertyName);
            }
        }

        #endregion


        #endregion

        #region visibilidadContenido

        #region visibilidadReferencia

        public const string visibilidadReferenciaPropertyName = "visibilidadReferencia";

        private Visibility _visibilidadReferencia = Visibility.Visible;

        public Visibility visibilidadReferencia
        {
            get
            {
                return _visibilidadReferencia;
            }

            set
            {
                if (_visibilidadReferencia == value)
                {
                    return;
                }

                _visibilidadReferencia = value;
                RaisePropertyChanged(visibilidadReferenciaPropertyName);
            }
        }

        #endregion

        #region visibilidadFechaCierre

        public const string visibilidadFechaCierrePropertyName = "visibilidadFechaCierre";

        private Visibility _visibilidadFechaCierre = Visibility.Visible;

        public Visibility visibilidadFechaCierre
        {
            get
            {
                return _visibilidadFechaCierre;
            }

            set
            {
                if (_visibilidadFechaCierre == value)

                {
                    return;
                }

                _visibilidadFechaCierre = value;
                RaisePropertyChanged(visibilidadFechaCierrePropertyName);
            }
        }

        #endregion

        #region visibilidadFechaSupervision

        public const string visibilidadFechaSupervisionPropertyName = "visibilidadFechaSupervision";

        private Visibility _visibilidadFechaSupervision = Visibility.Visible;

        public Visibility visibilidadFechaSupervision
        {
            get
            {
                return _visibilidadFechaSupervision;
            }

            set
            {
                if (_visibilidadFechaSupervision == value)
                {
                    return;
                }

                _visibilidadFechaSupervision = value;
                RaisePropertyChanged(visibilidadFechaSupervisionPropertyName);
            }
        }

        #endregion

        #region visibilidadFechaAprobacion

        public const string visibilidadFechaAprobacionPropertyName = "visibilidadFechaAprobacion";

        private Visibility _visibilidadFechaAprobacion = Visibility.Visible;

        public Visibility visibilidadFechaAprobacion
        {
            get
            {
                return _visibilidadFechaAprobacion;
            }

            set
            {
                if (_visibilidadFechaAprobacion == value)
                {
                    return;
                }

                _visibilidadFechaAprobacion = value;
                RaisePropertyChanged(visibilidadFechaAprobacionPropertyName);
            }
        }

        #endregion

        #region visibilidadFechaEvaluacion

        public const string visibilidadFechaEvaluacionPropertyName = "visibilidadFechaEvaluacion";

        private Visibility _visibilidadFechaEvaluacion = Visibility.Visible;

        public Visibility visibilidadFechaEvaluacion
        {
            get
            {
                return _visibilidadFechaEvaluacion;
            }

            set
            {
                if (_visibilidadFechaEvaluacion == value)
                {
                    return;
                }

                _visibilidadFechaEvaluacion = value;
                RaisePropertyChanged(visibilidadFechaEvaluacionPropertyName);
            }
        }

        #endregion

        #endregion

        #region visibilidadClaseDocumento

        public const string visibilidadClaseDocumentoPropertyName = "visibilidadClaseDocumento";

        private Visibility _visibilidadClaseDocumento = Visibility.Collapsed;

        public Visibility visibilidadClaseDocumento
        {
            get
            {
                return _visibilidadClaseDocumento;
            }

            set
            {
                if (_visibilidadClaseDocumento == value)
                {
                    return;
                }

                _visibilidadClaseDocumento = value;
                RaisePropertyChanged(visibilidadClaseDocumentoPropertyName);
            }
        }

        #endregion


        #region accesibilidad

        #region ViewModel Properties : accesibilidadReferencia

        public const string accesibilidadReferenciaPropertyName = "accesibilidadReferencia";

        private bool _accesibilidadReferencia;

        public bool accesibilidadReferencia
        {
            get
            {
                return _accesibilidadReferencia;
            }

            set
            {
                if (_accesibilidadReferencia == value)
                {
                    return;
                }

                _accesibilidadReferencia = value;
                RaisePropertyChanged(accesibilidadReferenciaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadCuerpo

        public const string accesibilidadCuerpoPropertyName = "accesibilidadCuerpo";

        private bool _accesibilidadCuerpo;

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

        #region ViewModel Properties : accesibilidadCierre

        public const string accesibilidadCierrePropertyName = "accesibilidadCierre";

        private bool _accesibilidadCierre;

        public bool accesibilidadCierre
        {
            get
            {
                return _accesibilidadCierre;
            }

            set
            {
                if (_accesibilidadCierre == value)
                {
                    return;
                }

                _accesibilidadCierre = value;
                RaisePropertyChanged(accesibilidadCierrePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : activarCarga

        public const string activarCargaPropertyName = "activarCarga";

        private bool _activarCarga;

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

        #region ViewModel Properties : activarCargaCorriente

        public const string activarCargaCorrientePropertyName = "activarCargaCorriente";

        private bool _activarCargaCorriente;

        public bool activarCargaCorriente
        {
            get
            {
                return _activarCargaCorriente;
            }

            set
            {
                if (_activarCargaCorriente == value)
                {
                    return;
                }

                _activarCargaCorriente = value;
                RaisePropertyChanged(activarCargaCorrientePropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadSupervision

        public const string accesibilidadSupervisionPropertyName = "accesibilidadSupervision";

        private bool _accesibilidadSupervision;

        public bool accesibilidadSupervision
        {
            get
            {
                return _accesibilidadSupervision;
            }

            set
            {
                if (_accesibilidadSupervision == value)
                {
                    return;
                }

                _accesibilidadSupervision = value;
                RaisePropertyChanged(accesibilidadSupervisionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties :  accesibilidadAprobacion

        public const string accesibilidadAprobacionPropertyName = "accesibilidadAprobacion";

        private bool _accesibilidadAprobacion;

        public bool accesibilidadAprobacion
        {
            get
            {
                return _accesibilidadAprobacion;
            }

            set
            {
                if (_accesibilidadAprobacion == value)
                {
                    return;
                }

                _accesibilidadAprobacion = value;
                RaisePropertyChanged(accesibilidadAprobacionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties :  accesibilidadEvaluacion

        public const string accesibilidadEvaluacionPropertyName = "accesibilidadEvaluacion";

        private bool _accesibilidadEvaluacion;

        public bool accesibilidadEvaluacion
        {
            get
            {
                return _accesibilidadEvaluacion;
            }

            set
            {
                if (_accesibilidadEvaluacion == value)
                {
                    return;
                }

                _accesibilidadEvaluacion = value;
                RaisePropertyChanged(accesibilidadEvaluacionPropertyName);
            }
        }

        #endregion

        #region identifica el fin de la carga inicial : finInicializacion

        public const string finInicializacionPropertyName = "finInicializacion";

        private bool _finInicializacion;

        public bool finInicializacion
        {
            get
            {
                return _finInicializacion;
            }

            set
            {
                if (_finInicializacion == value)
                {
                    return;
                }

                _finInicializacion = value;
                RaisePropertyChanged(finInicializacionPropertyName);
            }
        }

        #endregion

        #region fechacierre

        public const string fechacierrePropertyName = "fechacierre";

        private DateTime _fechacierre = DateTime.Now;

        public DateTime fechacierre
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

        private DateTime _fechasupervision = DateTime.Now;

        public DateTime fechasupervision
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

        private DateTime _fechaaprobacion = DateTime.Now;

        public DateTime fechaaprobacion
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


        #region usuariocerro

        public const string usuariocerroPropertyName = "usuariocerro";

        private string _usuariocerro = string.Empty;

        public string usuariocerro
        {
            get
            {
                return _usuariocerro;
            }

            set
            {
                if (_usuariocerro == value)
                {
                    return;
                }

                _usuariocerro = value;
                RaisePropertyChanged(usuariocerroPropertyName);
            }
        }

        #endregion

        #region usuariosuperviso

        public const string usuariosupervisoPropertyName = "usuariosuperviso";

        private string _usuariosuperviso = string.Empty;

        public string usuariosuperviso
        {
            get
            {
                return _usuariosuperviso;
            }

            set
            {
                if (_usuariosuperviso == value)
                {
                    return;
                }

                _usuariosuperviso = value;
                RaisePropertyChanged(usuariosupervisoPropertyName);
            }
        }

        #endregion

        #region usuarioaprobo

        public const string usuarioaproboPropertyName = "usuarioaprobo";

        private string _usuarioaprobo = string.Empty;

        public string usuarioaprobo
        {
            get
            {
                return _usuarioaprobo;
            }

            set
            {
                if (_usuarioaprobo == value)
                {
                    return;
                }

                _usuarioaprobo = value;
                RaisePropertyChanged(usuarioaproboPropertyName);
            }
        }

        #endregion



        #endregion

        #endregion

        #region ViewModel Commands
        public RelayCommand CopiarCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }

        public RelayCommand<DocumentoModelo> SelectionCarpetaCommand { get; set; }


        #region Importacion

        public RelayCommand CancelarProgramaEncargoCommand { get; set; }//Seleccion desde el encargo
        public RelayCommand SeleccionProgramaEncargoCommand { get; set; }//seleccion desde el encargo

        public RelayCommand CancelarPlantillaCommand { get; set; }//Seleccion desde las plantillas
        public RelayCommand SeleccionPlantillaCommand { get; set; }//seleccion desde las plantillas

        public RelayCommand<DocumentoModelo> SeleccionClaseDocumentoCommand { get; set; }

        public RelayCommand<RepositorioModelo> SelectionCarpetaChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateChangedCommand { get; set; }


        public RelayCommand<DateTime> SelectedDateSupervisionChangedCommand { get; set; }

        public RelayCommand<DateTime> SelectedDateAprobacionCommand { get; set; }


        public RelayCommand referenciarCommand { get; set; }//seleccion desde las plantillas
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }

        public RelayCommand cerrarCommand { get; set; }

        public RelayCommand cmdCargarPdf_Click { get; set; }

        public RelayCommand cmdCargarFuente_Click { get; set; }

        #endregion


        #endregion

        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public RepositorioModeloController()
        {
        }

        public RepositorioModeloController(string origenLlamada)
        {
            finInicializacion = false;
            _isListaCargada = false;
            tamanoArchivo = 2867200;
            _btnContenidoFuente = "Cargar fuente";
            _btnContenidoPdf = "Cargar pdf";
            //Documentacion/Planificacion/Indices
            _origen = origenLlamada;
            _cerradoFinalVentana = false;//Controla el cierre de la ventana
            _maxDescripcion = 40;
            _numeroProcesoCrudRecibido = 0;
            _opcionMenu = 0;
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            //Suscribiendo el mensaje
            listaClaseDocumentos = new ObservableCollection<DocumentoModelo>();
            listacurrentEntidad = new ObservableCollection<RepositorioModelo>();
            Errors = 0;
            //Messenger.Default.Register<PlantillaIndiceMensaje>(this, tokenRecepcion, (plantillaIndiceMensaje) => ControlPlantillaIndiceMensaje(plantillaIndiceMensaje));
            RegisterCommands();
            //Recibe un numero para procesar solo el último mensaje
            numeroProcesoCrudRecibido = PlantillaIndiceViewModel.numeroProcesoCrud;
            dlg = new DialogCoordinator();
            accesibilidadWindow = false;

            _visibilidadClaseDocumento = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCopiar = Visibility.Collapsed;
            _visibilidadPlantilla = Visibility.Collapsed;
            _selectedDocumentoModelo = new DocumentoModelo();
            _eleccionDocumentoModelo = new DocumentoModelo();

            _currentEncargo = new EncargoModelo();
            _currentEntidad = new RepositorioModelo();
            _eleccionDocumentoModelo = new DocumentoModelo();

            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            switch (origenLlamada)
            {
                case "DocumentacionCartas"://Llamada desde Documentacion/Carpetas
                    #region configuracion Documentacion
                    _tokenEnvio = "datosControllerCartas";
                    _tokenRecepcion = "datosEDCartas";
                    #endregion
                    break;
                case "ReferenciarDocumentacionCartas"://Referenciacion
                    #region configuracion Documentacion
                    _tokenEnvio = "datosControllerCartas";
                    _tokenRecepcion = "datosEDCartas";
                    #endregion
                    #region contenido

                    _accesibilidadWindow = false;
                    _accesibilidadCuerpo = false;
                    _accesibilidadReferencia = false;
                    _accesibilidadCierre = false;
                    _accesibilidadSupervision = false;
                    _accesibilidadAprobacion = false;
                    _accesibilidadEvaluacion = false;

                    #endregion
                    #region visibilidad botones inferiores

                    _visibilidadReferenciar = Visibility.Collapsed;
                    _visibilidadAprobar = Visibility.Collapsed;
                    _visibilidadSupervisar = Visibility.Collapsed;
                    _visibilidadConsultar = Visibility.Collapsed;
                    _visibilidadCerrar = Visibility.Collapsed;
                    _visibilidadEditar = Visibility.Collapsed;

                    #endregion
                    #region visibilidadContenido

                    _visibilidadReferencia = Visibility.Collapsed;
                    _visibilidadFechaCierre = Visibility.Collapsed;
                    _visibilidadFechaSupervision = Visibility.Collapsed;
                    _visibilidadFechaAprobacion = Visibility.Collapsed;
                    _visibilidadFechaAprobacion = Visibility.Collapsed;
                    _visibilidadFechaEvaluacion = Visibility.Visible;

                    #endregion

                    break;


            }
            //Suscribiendo el mensaje
            Messenger.Default.Register<RepositorioMsj>(this, tokenRecepcion, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            _currentEncargo = new EncargoModelo();


            #region Importacion

            _listaDocumentosAnteriores = new ObservableCollection<RepositorioModelo>();

            #endregion
            _fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
            _fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
            _fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
        }

        private async void ControlDatosMsj(RepositorioMsj datosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            //FuenteLlamada = datosMsj.fuenteLlamado;
            listacurrentEntidad = datosMsj.lista;
            currentEntidad = datosMsj.entidadTrasladada;
            if (currentEntidad.iddocumento == 0 || ( currentEntidad.iddocumento != 2 && currentEntidad.iddocumento != 7 && currentEntidad.iddocumento != 8))
            {
                visibilidadClaseDocumento = Visibility.Visible;
                listaClaseDocumentos = new ObservableCollection<DocumentoModelo>(DocumentoModelo.GetAllOtros());
            }
            else
            {
                visibilidadClaseDocumento = Visibility.Collapsed;
                listaClaseDocumentos = new ObservableCollection<DocumentoModelo>(DocumentoModelo.GetAll());

            }
            llenadoDatos();
            switch (datosMsj.opcionMenuCrud)
            {
                case 1://Crear 
                    encabezadoPantalla = "Proporcione los datos requeridos";
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    accesibilidadCuerpo = false;
                    activarCarga = true;
                    activarCargaCorriente = true;
                    nombrerepositorio = string.Empty;
                    break;
                case 2://Editar, no sera activada
                    encabezadoPantalla = "Edite los datos";
                    nombrerepositorio = currentEntidad.nombrerepositorio;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Collapsed;
                    accesibilidadCuerpo = true;
                    activarCarga = true;
                    activarCargaCorriente = true;
                    break;
                case 3://Consultar
                    encabezadoPantalla = "Consulta del tipo de carpeta";
                    nombrerepositorio = currentEntidad.nombrerepositorio;
                    accesibilidadWindow = false;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    selectedDocumentoModelo = listaClaseDocumentos.Single(i => i.id == currentEntidad.iddocumento);
                    eleccionDocumentoModelo = selectedDocumentoModelo;
                    break;
                case 6://Importar de las plantillas (No se usa)
                    listacurrentEntidad = datosMsj.lista;
                    listaDocumentosAnteriores = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAll());
                    //Remover todas las carpetas ya existentes
                    ObservableCollection<RepositorioModelo> listaRepositorioTemporal = new ObservableCollection<RepositorioModelo>();
                    foreach (RepositorioModelo item in listacurrentEntidad)
                    {
                        listaRepositorioTemporal = new ObservableCollection<RepositorioModelo>(listaDocumentosAnteriores.Where(x => x.idencargo == item.idencargo));
                        if (listaRepositorioTemporal.Count > 0)
                        {
                            foreach (RepositorioModelo itemRemover in listaRepositorioTemporal)
                            {
                                listaDocumentosAnteriores.Remove(itemRemover);
                            }
                        }
                    }

                    visibilidadCrear = Visibility.Visible;
                    accesibilidadWindow = true;
                    if (!(listaDocumentosAnteriores.Count > 0))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }

                    break;
                case 7://Importar de programas de otros encargos
                       //Seleccion de programa
                    visibilidadCopiar = Visibility.Visible;
                    accesibilidadWindow = true;
                    listacurrentEntidad = datosMsj.lista;
                    ControlCambioLista();
                    if (currentEntidad.iddocumento == 0 || (currentEntidad.iddocumento != 2 && currentEntidad.iddocumento != 7 && currentEntidad.iddocumento != 8))
                    {
                        listaDocumentosAnteriores = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllByEncargosImportacionEncabezadosOtros(currentEncargo, currentEntidad.iddocumento));
                    }
                    else
                    {
                        listaDocumentosAnteriores = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllByEncargosImportacionEncabezados(currentEncargo, currentEntidad.iddocumento));
                    }
                    accesibilidadWindow = true;
                    if (!(listaDocumentosAnteriores.Count > 0))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }
                    break;
                case 8://Referenciar 
                    encabezadoPantalla = "Introduzca la referencia para la matriz";
                    #region contenido

                    accesibilidadCuerpo = true;
                    accesibilidadReferencia = true;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = false;
                    accesibilidadEvaluacion = false;

                    #endregion

                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Visible;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Collapsed;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Visible;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;

                    #endregion
                    break;
                case 10://Cerrar el papel 
                    encabezadoPantalla = "Introduzca la fecha de cierre a utilizar";
                    #region contenido


                    accesibilidadReferencia = false;
                    accesibilidadCierre = true;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = false;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Visible;
                    visibilidadFechaSupervision = Visibility.Collapsed;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Visible;

                    #endregion
                    break;
                case 11://Finaliza la  supervisión
                    encabezadoPantalla = "Introduzca la fecha de la supervisión";
                    #region contenido


                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = true;
                    accesibilidadAprobacion = false;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Visible;
                    visibilidadFechaAprobacion = Visibility.Collapsed;
                    visibilidadFechaEvaluacion = Visibility.Collapsed;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Collapsed;
                    visibilidadSupervisar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;

                    #endregion
                    break;
                case 12://Cerrar el papel 
                    encabezadoPantalla = "Introduzca la fecha de cierre a utilizar";
                    #region contenido


                    accesibilidadReferencia = false;
                    accesibilidadCierre = false;
                    accesibilidadSupervision = false;
                    accesibilidadAprobacion = true;

                    #endregion
                    #region visibilidadContenido

                    visibilidadReferencia = Visibility.Collapsed;
                    visibilidadFechaCierre = Visibility.Collapsed;
                    visibilidadFechaSupervision = Visibility.Visible;
                    visibilidadFechaAprobacion = Visibility.Visible;
                    visibilidadFechaEvaluacion = Visibility.Visible;
                    #endregion

                    #region visibilidad botones inferiores

                    visibilidadReferenciar = Visibility.Collapsed;
                    visibilidadAprobar = Visibility.Visible;
                    visibilidadSupervisar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCerrar = Visibility.Collapsed;

                    #endregion
                    break;

            }
            Messenger.Default.Unregister<RepositorioMsj>(this, tokenRecepcion);
            finComando();
            finInicializacion = true;//Termino la carga se activan los comando
        }

        private void ControlCambioLista()
        {
            BackgroundWorker worker = new BackgroundWorker();
            //var secureString = passwordContainer.Password;
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                if (currentEntidad.iddocumento == 0 || (currentEntidad.iddocumento != 2 && currentEntidad.iddocumento != 7 && currentEntidad.iddocumento != 8))
                {
                    visibilidadClaseDocumento = Visibility.Visible;
                    listaDocumentosAnterioresCompleta = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllByEncargosImportacion(currentEncargo, currentEntidad.iddocumento));
                }
                else
                {
                    listaDocumentosAnterioresCompleta = new ObservableCollection<RepositorioModelo>(RepositorioModelo.GetAllByEncargosImportacion(currentEncargo, currentEntidad.iddocumento));
                }
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                isListaCargada = true;
            };
            worker.Dispose();
            worker.RunWorkerAsync();
        }

        private async void llenadoDatos()
        {
            if (currentEntidad.idrepositorio != 0)
            {
                selectedDocumentoModelo = listaClaseDocumentos.Single(i => i.id == currentEntidad.iddocumento);
                currentClaseDocumento = selectedDocumentoModelo;
                btnContenidoFuente = "Cargar fuente";
                btnContenidoPdf = "Cargar pdf";
                if (currentEntidad.pdfrepositorio != null)
                {
                    btnContenidoPdf = "Cambiar pdf";
                }
                else
                {
                    btnContenidoPdf = "Cargar pdf";
                }
                if (currentEntidad.binariorepositorio != null)
                {
                    btnContenidoFuente = "Cambiar fuente";
                }
                else
                {
                    btnContenidoFuente = "Cargar fuente";
                }
            }
            else
            {
                selectedDocumentoModelo = new DocumentoModelo();
                currentClaseDocumento = selectedDocumentoModelo;
                btnContenidoFuente = "Cargar fuente";
                btnContenidoPdf = "Cargar pdf";
            }
            //Llenar fecha de cierre
            if (currentEntidad.fechacierre != null && currentEntidad.fechacierre != "")
            {
                try
                {
                    fechacierre = MetodosModelo.convertirFecha(currentEntidad.fechacierre);
                }
                catch (Exception)
                {
                    //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                    await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                    fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
                }
            }
            else
            {
                fechacierre = new DateTime((DateTime.Now.Year), 1, 1);
            }
            //Llenar fecha de supervision
            if (currentEntidad.fechasupervision != null && currentEntidad.fechasupervision != "")
            {
                try
                {
                    fechasupervision = MetodosModelo.convertirFecha(currentEntidad.fechasupervision);
                }
                catch (Exception)
                {
                    //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                    await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                    fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
                }
            }
            else
            {
                fechasupervision = new DateTime((DateTime.Now.Year), 1, 1);
            }
            //Llenar fecha de aprobacion
            if (currentEntidad.fechaaprobacion != null && currentEntidad.fechaaprobacion != "")
            {
                try
                {
                    fechaaprobacion = MetodosModelo.convertirFecha(currentEntidad.fechaaprobacion);
                }
                catch (Exception)
                {
                    //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de inicio  de la auditoria", "");
                    await dlg.ShowMessageAsync(this, "No ha sido posible convertir la fecha", "");
                    fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
                }
            }
            else
            {
                fechaaprobacion = new DateTime((DateTime.Now.Year), 1, 1);
            }

        }
        #endregion



      private async void ImportarDeEncargos()
        {
            iniciarComando();
            int continuar = 0;
            if (listaDocumentosAnteriores.Count > 0)
            {
                continuar = 0;
            }
            else
            {
                continuar = 1;//No hay registros
            }
            if (continuar == 0)
            {
                RepositorioModelo temporal = new RepositorioModelo(currentEncargo, currentUsuario);
                RepositorioModelo itemImportar = new RepositorioModelo();
                //bool seguir = false;
                //int cuenta = 0;
                //do
                //{
                //    seguir = true;
                //    if (isListaCargada)
                //    {
                //        seguir = false;
                //        cuenta = 10;
                //    }
                //    else
                //    {
                //        System.Threading.Thread.Sleep(5000);
                //        cuenta++;
                //    }
                //    if (cuenta > 5)
                //    {
                //        seguir = false;
                //    }
                //}
                //while (seguir);

                //Verificar que no exista nombre duplicado
                for (int k = 0; k < listaDocumentosAnteriores.Count; k++)
                {
                    if (listaDocumentosAnteriores[k].IsSelected)
                    {
                        //Importar
                        //ProgramaModelo tem = listaDocumentosAnteriores[k];
                        if (isListaCargada && listaDocumentosAnterioresCompleta.Count>0)
                        {
                            itemImportar = listaDocumentosAnterioresCompleta.Single(x => x.idrepositorio == listaDocumentosAnteriores[k].idrepositorio);
                        }
                        else
                        {
                            itemImportar = RepositorioModelo.Find(listaDocumentosAnteriores[k].idrepositorio);
                        }
                        if (itemImportar.idrepositorio != 0)
                        {
                        temporal = new RepositorioModelo(itemImportar, currentEncargo, currentUsuario);
                        #region Guardando

                        if (nombreUnico(temporal.nombrerepositorio, listacurrentEntidad) == 0)
                        {
                            try
                            {
                                switch (RepositorioModelo.Insert(temporal))
                                {
                                    case 0://No se pudo insertar
                                        await AvisaYCerrate("No ha sido posible insertar el registro denominado " + temporal.nombrerepositorio, "Este mensaje desaparecerá en segundos", 1);
                                        break;
                                    case 1://Se inserto con éxito
                                        await AvisaYCerrate("Registro insertado con éxito denominado "+temporal.nombrerepositorio, "Este mensaje desaparecerá en segundos", 1);
                                        //fuenteCierre = 1;
                                        resultadoProceso = 1;//1 para  crear
                                        //CloseWindow();
                                        break;
                                }
                            }
                            catch (Exception)
                            {
                                await AvisaYCerrate("No ha sido posible insertar el registro denominado " + temporal.nombrerepositorio, "Este mensaje desaparecerá en segundos", 1);
                            }
                        }
                        else
                        {
                            await AvisaYCerrate("El nombre ya esta siendo utilizado ", "Debe cambiar el nombre, no se importará", 1);
                        }

                            #endregion
                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "Error al recuperar el  registro", "Se intentará con el siguiente");
                            iniciarComando();
                        }

                        listaDocumentosAnteriores[k].IsSelected = false;
                   }
                }
                fuenteCierre = 1;
                resultadoProceso = 4;//2 para  importar;
                CloseWindow();
            }
        }
       

        private async void Cancelar()
        {
            if (origen == null)
            {
                // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
                //Debe cerrar el sistemapi
                await dlg.ShowMessageAsync(this, "Operación cancelada", "");
                cerradoFinalVentana = true;
                CloseWindow();
                enviarMensajeHabilitar();
            }
            else
            {
                // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
                //Debe cerrar el sistema
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                fuenteCierre = 1;
                CloseWindow();
            }

        }

        private void Ok()
        {
            if (origen == null)
            {
                cerradoFinalVentana = true;
                CloseWindow();
                enviarMensajeHabilitar();
            }
            else
            {
                fuenteCierre = 1;
                CloseWindow();

            }
        }

        private void Salir()
        {
            if (origen == null)
            {
                if (!(cerradoFinalVentana))
                {
                    CloseWindow();
                    enviarMensajeHabilitar();
                }
                enviarMensajeFinProceso();//Manda mensaje de cierre
            }
            else
            {
                if (fuenteCierre == 0)
                {
                    accesibilidadWindow = false;
                    Mouse.OverrideCursor = Cursors.Wait;
                    enviarMensajeHabilitar();
                    enviarMensaje();//Cero por cancelamiento
                    fuenteCierre = 3;
                    CloseWindow();
                }
                else
                {
                    if (fuenteCierre == 1)
                    {
                        enviarMensajeHabilitar();
                        enviarMensaje();
                        fuenteCierre = 4;
                    }
                }
            }
        }

        public async void Guardar()
        {
                if (nombreUnico(currentEntidad.nombrerepositorio,listacurrentEntidad) == 0)
                {
                    try
                    {
                        switch (RepositorioModelo.Insert(currentEntidad))
                        {
                            case 0://No se pudo insertar
                                finComando();
                                await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                break;
                            case 1://Se inserto con éxito
                                var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                fuenteCierre = 1;
                                resultadoProceso = 1;//1 para  crear
                                CloseWindow();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        MessageBox.Show("No ha sido posible insertar el registro");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El nombre ya esta siendo utilizado,", "seleccione otro nombre");
                }
        }

        public void GuardarD()
        {
            {
                /*   //Debe coindicir el inicio con el elemento contable seleccionado
                   iniciarComando();
                   try
                   {
                       switch (RepositorioModelo.Insert(currentEntidad, currentEncargo))
                       {
                           case 0://No se pudo insertar
                               finComando();
                               await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                               break;
                           case 1://Se inserto con éxito
                               var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                               controller.SetIndeterminate();
                               await TaskEx.Delay(1000);
                               await controller.CloseAsync();
                               fuenteCierre = 1;
                               resultadoProceso = 1;//1 para  crear
                               CloseWindow();
                               break;
                       }
                   }
                   catch (Exception)
                   {
                       //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                       MessageBox.Show("No ha sido posible insertar el registro");
                   }*/
            }
        }

        public void Copiar()
        {
            /*  iniciarComando();
              if ((currentEntidad.tipoAuditoriaModelo != null))
              {
                  if (!(currentEntidad.tipoAuditoriaModelo.id != 0))
                  {
                      currentEntidad.tipoAuditoriaModelo = null;
                  }
              }
              if (!string.IsNullOrEmpty(currentEntidad.nombrerepositorio))
              {

                  if (nombreUnico(currentEntidad.nombrerepositorio, listaEntidad) == 0)
                  {
                      if (RepositorioModelo.CopiarModelo(currentEntidad))
                      {
                          finComando();
                          await dlg.ShowMessageAsync(this, "Registro copiado con éxito", "");
                          CloseWindow();
                          cerradoFinalVentana = true;
                          enviarMensajeHabilitar();
                      }
                      else
                      {
                          finComando();
                          await dlg.ShowMessageAsync(this, "No ha sido posible copiar el registro", "");
                      }
                  }
                  else
                  {
                      finComando();
                      //Mensaje en caso de indice mayor
                      await dlg.ShowMessageAsync(this, "Ya existe un registro con ese nombre", "Debe cambiar el nombre");
                  }

              }
              else
              {
                  finComando();
                  await dlg.ShowMessageAsync(this, "Faltan datos requeridos verifique", "");
              }
              //Nuevo();*/
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
            mensajeDeCierreCrud mensaje = new mensajeDeCierreCrud();
            mensaje.numeroProcesoCrud = numeroProcesoCrudRecibido;
            numeroProcesoCrudRecibido++;
            Messenger.Default.Send(mensaje, tokenEnvio);
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvio);
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
                evaluar = Errors == 0 && (currentEntidad.binariorepositorio!=null||currentEntidad.pdfrepositorio!=null);
                return evaluar;
            }
        }

        public bool CanSaveDocumentacion()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = Errors == 0;
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
            //GuardarCommand = new RelayCommand(GuardarD, CanSaveDocumentacion);

            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionCarpetaCommand = new RelayCommand<DocumentoModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionDocumentoModelo = entidad;
                if (entidad.id != 0)
                {
                    currentEntidad.iddocumento = entidad.id;
                }
            });
            SeleccionClaseDocumentoCommand = new RelayCommand<DocumentoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.iddocumento = entidad.id;
            });
            cmdCargarPdf_Click = new RelayCommand(cmdCargarPDF);
            cmdCargarFuente_Click = new RelayCommand(cmdCargarFuente);
            SelectionCarpetaCommand = new RelayCommand<DocumentoModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionDocumentoModelo = entidad;
                if (entidad.id != 0)
                {
                    currentEntidad.iddocumento = entidad.id;
                    //currentEntidad.nombrerepositorio = entidad.descripciontc;
                    currentEntidad.nombrerepositorio = "Para eliminar error";
                }
                //else
                //{
                //    currentEntidad.padreidtc = 0;
                //    currentEntidad.nombrerepositorio = "";
                //    currentEntidad.nombrerepositorio = string.Empty;
                //}
            });

            CancelarPlantillaCommand = new RelayCommand(Cancelar);
            //SeleccionPlantillaCommand = new RelayCommand(ImportarPlantillas, canImport);
            CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
            SeleccionProgramaEncargoCommand = new RelayCommand(ImportarDeEncargos, canImportForEncargos);

            SeleccionClaseDocumentoCommand = new RelayCommand<DocumentoModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad.iddocumento = entidad.id;
            });


            SelectedDateChangedCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechacierre != null)
                    {
                        currentEntidad.fechacierre = MetodosModelo.homologacionFecha(fechacierre.ToShortDateString());
                        currentEntidad.usuariocerro = currentUsuario.inicialesusuario;
                    }
                }
            });


            SelectedDateSupervisionChangedCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechasupervision != null)
                    {
                        currentEntidad.fechasupervision = MetodosModelo.homologacionFecha(fechasupervision.ToShortDateString());
                        currentEntidad.usuariosuperviso = currentUsuario.inicialesusuario;
                    }
                }
            });

            SelectedDateAprobacionCommand = new RelayCommand<DateTime>(entidad =>
            {
                if (entidad == null) return;

                if (finInicializacion)
                {
                    if (fechaaprobacion != null)
                    {
                        currentEntidad.fechaaprobacion = MetodosModelo.homologacionFecha(fechaaprobacion.ToShortDateString());
                        currentEntidad.usuarioaprobo = currentUsuario.inicialesusuario;
                    }
                }
            });

            referenciarCommand = new RelayCommand(Modificar, CanReferenciarSave);//Para guardar la referencia

            supervisarCommand = new RelayCommand(Modificar, CanSupervisar);//Para guardar la referencia

            aprobarCommand = new RelayCommand(Modificar, CanAprobar);//Para guardar la referencia

            cerrarCommand = new RelayCommand(Modificar, CanCerrar);//Para guardar la referencia

        }


        private async void cmdCargarPDF()
        {
            try
            {

                if (btnContenidoPdf == "Quitar pdf")
                {
                    currentEntidad.pdfrepositorio = null;//Elimina el archivo
                    currentEntidad.nombrepdf = string.Empty;
                    btnContenidoPdf = "Cargar Pdf";
                }
                else
                { 
                #region cargaDatos

                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Title = "Seleccione el PDF a cargar";
                openDialog.Filter = "PDF File (*.pdf)|*.pdf";
                openDialog.Multiselect = false;
                // Abrir el cuadro de dialogo para cargar una imagen de un archivo
                if (openDialog.ShowDialog() == true)
                {
                    iniciarComando();
                    if (new FileInfo(openDialog.FileName).Length > tamanoArchivo)
                    {
                        await AvisaYCerrate("El archivo excede los 2.8 Megas", "No puede incorporarse el archivo", 1);
                        finComando();
                        return;
                    }
                    else
                    {
                        string rutaArchivo = openDialog.FileName;
                        if (!(string.IsNullOrEmpty(rutaArchivo)))
                        {
                            using (FileStream fsSource = new FileStream(rutaArchivo,
                            FileMode.Open, FileAccess.Read))
                            {
                                //Leer la imagen en un array de bytes
                                //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                                currentEntidad.pdfrepositorio = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                                currentEntidad.nombrepdf = rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                                fsSource.Close();//Evaluar
                                btnContenidoPdf = "Quitar pdf";
                                finComando();
                                accesibilidadCuerpo = true;
                            }
                        }
                    }
                }
                else
                {
                    btnContenidoPdf = "Cargar Pdf";
                    finComando();
                }

                    #endregion
                }
            }
            catch (Exception e)
            {
                finComando();
                await AvisaYCerrate("Ocurrio un error en la importacion ", "No puede incorporarse el archivo "+e, 1);
                accesibilidadCuerpo = false;
            }
        }

        private async void cmdCargarFuente()
        {
            try
            {
                if (btnContenidoFuente == "Quitar fuente")
                {
                    currentEntidad.binariorepositorio = null;//Elimina el archivo
                    currentEntidad.nombrebinariorepositorio = string.Empty;
                    btnContenidoFuente = "Cargar fuente";
                }
                else
                {
                    #region cargaDatos
                    OpenFileDialog openDialog = new OpenFileDialog();
                    openDialog.Title = "Seleccione el documento a cargar";
                    openDialog.Filter = "Document(*.doc,*.docx)|*.doc;*.docx|Excel(*.xls,*.xlsx)|*.xls;*.xlsx|Text(*.txt)|*.txt|Image(*.tif,*.tiff,*.jpg,*.gif)|*.tif;*.tiff;*.jpg;*.gif";
                    openDialog.Multiselect = false;
                    // Abrir el cuadro de dialogo para cargar una imagen de un archivo
                    if (openDialog.ShowDialog() == true)
                    {
                        iniciarComando();
                        if (new FileInfo(openDialog.FileName).Length > tamanoArchivo)
                        {
                            await AvisaYCerrate("El archivo excede los 2.8 Megas", "No puede incorporarse el archivo", 1);
                            finComando();
                            return;
                        }
                        else
                        {
                            string rutaArchivo = openDialog.FileName;
                            if (!(string.IsNullOrEmpty(rutaArchivo)))
                            {
                                using (FileStream fsSource = new FileStream(rutaArchivo,
                                FileMode.Open, FileAccess.Read))
                                {
                                    //Leer la imagen en un array de bytes
                                    //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                                    currentEntidad.binariorepositorio = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                                    currentEntidad.nombrebinariorepositorio = rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                                    currentEntidad.tipoarchivorepositorio= rutaArchivo.Substring(rutaArchivo.LastIndexOf(".") + 1);
                                    fsSource.Close();//Evaluar
                                    btnContenidoFuente = "Quitar fuente";
                                    accesibilidadCuerpo = true;
                                    finComando();
                                }
                            }
                        }
                    }
                    else
                    {
                        btnContenidoFuente = "Cargar fuente";
                        finComando();
                    }

                    #endregion
                }
            }
            catch (Exception e)
            {
                finComando();
                await AvisaYCerrate("Ocurrio un error en la importacion ", "No puede incorporarse el archivo " + e, 1);
                accesibilidadCuerpo = false;
            }
        }


        private bool CanModificar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0)
                && (!string.IsNullOrWhiteSpace(currentEntidad.fechacierre));
                return evaluar;
            }
        }

        private bool CanCerrar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidad.usuariocerro))
                        && (!string.IsNullOrWhiteSpace(currentEntidad.usuariocerro));
            }
        }


        private bool CanAprobar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return ((!string.IsNullOrEmpty(currentEntidad.usuarioaprobo))
                    || (string.IsNullOrEmpty(currentEntidad.usuarioaprobo)));
            }
        }

        private bool CanSupervisar()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                return (!string.IsNullOrEmpty(currentEntidad.usuariosuperviso))
                        && (!string.IsNullOrWhiteSpace(currentEntidad.usuariosuperviso));
            }
        }


        private bool CanReferenciarSave()
        {
            bool evaluar = false;

            if (currentEntidad == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0);
                return evaluar;
            }
        }

        private async void Modificar()
        {
            iniciarComando();
            try
            {
                int resultadoModificar = -10;
                //currentEntidad.referenciamr = referenciamr;
                switch (opcionMenu)
                {
                    case 2: //Editar solo actualiza la fecha de evaluación
                        resultadoModificar = RepositorioModelo.UpdateModelo(currentEntidad,true);
                        break;
                    case 8: //Referenciar
                        resultadoModificar = RepositorioModelo.UpdateReferencia(currentEntidad);
                        break;
                    case 10:
                        resultadoModificar = RepositorioModelo.UpdateCierre(currentEntidad, currentUsuario);
                        break;
                    case 11://Supervisar
                        resultadoModificar = RepositorioModelo.UpdateSupervision(currentEntidad);
                        break;
                    case 12://Aprobar
                        if (string.IsNullOrEmpty(currentEntidad.usuariosuperviso) || string.IsNullOrWhiteSpace(currentEntidad.usuariosuperviso))
                        {
                            resultadoModificar = RepositorioModelo.UpdateAprobacionSupervision(currentEntidad);
                            currentEntidad.usuariosuperviso = currentEntidad.usuarioaprobo;
                            currentEntidad.fechasupervision = currentEntidad.fechaaprobacion;
                        }
                        else
                        {
                            resultadoModificar = RepositorioModelo.UpdateAprobacion(currentEntidad);
                        }
                        break;
                }

                switch (resultadoModificar)
                {
                    case 0://No se pudo insertar
                        finComando();
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        break;
                    case 1://Se inserto con éxito
                        var controller = await dlg.ShowProgressAsync(this, "Operación con registro realizada con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 1;//1 para  crear
                        CloseWindow();
                        break;
                    case -1://No se pudo insertar
                        finComando();
                        await dlg.ShowMessageAsync(this, "Se genero un  error en la operación", "");
                        break;
                }
            }
            catch (Exception)
            {
                finComando();
                this.except3();
            }
        }

        private async void except3()
        {
            finComando();
            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
        }

        public async void advertenciaSeleccion()
        {
            await dlg.ShowMessageAsync(this, "No puede seleccionar 2 carpetas del mismo tipo", "Debe eliminar una de las 2 selecciones");
        }


        private bool canImportForEncargos()
        {
            return (listaDocumentosAnteriores.Count(j => j.IsSelected) > 0);
        }

        private bool canImport()
        {
            //bool evaluar = false;
            return (listaDocumentosAnteriores.Count(j => j.IsSelected) > 0);
        }


        #region Verifica unicidad
        //Cada marca debe ser única
        public int nombreUnico(string nombre, ObservableCollection<RepositorioModelo> listaBusqueda)
        {
            int numeroRegistros=0;
            if (listaBusqueda!=null || listaBusqueda.Count > 0)
            {
                string nombreBuscado = nombre.ToUpper().Trim();
                numeroRegistros = listaBusqueda.Where(j => j.nombrerepositorio.ToUpper().Trim() == nombreBuscado).Count();
                if (numeroRegistros == 1)
                {
                    return 1;
                }
                else
                {
                    return numeroRegistros;
                }
            }
            else
            {
                return numeroRegistros;
            }
        }

        #endregion

        #endregion

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

        public async Task AvisaYCerrate(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

    }

}
