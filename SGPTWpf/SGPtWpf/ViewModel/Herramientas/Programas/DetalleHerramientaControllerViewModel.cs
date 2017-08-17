using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Model;
using CapaDatos;
using SGPTWpf.Messages.Herramientas;
using System.Windows;
using System.Linq;
using SGPTWpf.Messages;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.ViewModel.Herramientas.Programas
{
    public sealed class DetalleHerramientaControllerViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición


        private bool cerradoFinalVentana = false;

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
        }

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

        private int opcionMenu = 0;

        private int? tipoHerramientaMenu = 0; //1 para programa 2 para cuestionario

        private bool arranque = true;

        #endregion

        #region Lista de entidades

        #region ViewModel Properties : ListaEntidad

        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<DetalleHerramientasModelo> _ListaEntidad;

        public ObservableCollection<DetalleHerramientasModelo> ListaEntidad
        {
            get
            {
                return _ListaEntidad;
            }
            set
            {
                if (_ListaEntidad == value) return;

                _ListaEntidad = value;

                RaisePropertyChanged(listaEntidadPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaEntidadFiltrada

        public const string listaEntidadFiltradaPropertyName = "listaEntidadFiltrada";

        private ObservableCollection<DetalleHerramientasModelo> _listaEntidadFiltrada;

        public ObservableCollection<DetalleHerramientasModelo> listaEntidadFiltrada
        {
            get
            {
                return _listaEntidadFiltrada;
            }
            set
            {
                if (_listaEntidadFiltrada == value) return;

                _listaEntidadFiltrada = value;

                RaisePropertyChanged(listaEntidadFiltradaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<DetalleHerramientasModelo> _listaEntidadSeleccion;

        public ObservableCollection<DetalleHerramientasModelo> listaEntidadSeleccion
        {
            get
            {
                return _listaEntidadSeleccion;
            }
            set
            {
                if (_listaEntidadSeleccion == value) return;

                _listaEntidadSeleccion = value;

                RaisePropertyChanged(listaEntidadSeleccionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetalleHerramienta

        public const string listaDetalleHerramientaPropertyName = "listaDetalleHerramienta";

        private ObservableCollection<DetalleHerramientasModelo> _listaDetalleHerramienta;

        public ObservableCollection<DetalleHerramientasModelo> listaDetalleHerramienta
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

        #region ViewModel Properties : listaTipoProcedimiento

        public const string listaTipoProcedimientoPropertyName = "listaTipoProcedimiento";

        private ObservableCollection<TipoProcedimientoModelo> _listaTipoProcedimiento;

        public ObservableCollection<TipoProcedimientoModelo> listaTipoProcedimiento
        {
            get
            {
                return _listaTipoProcedimiento;
            }
            set
            {
                if (_listaTipoProcedimiento == value) return;

                _listaTipoProcedimiento = value;

                RaisePropertyChanged(listaTipoProcedimientoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaVisita

        public const string listaVisitaPropertyName = "listaVisita";

        private ObservableCollection<VisitaModelo> _listaVisita;

        public ObservableCollection<VisitaModelo> listaVisita
        {
            get
            {
                return _listaVisita;
            }
            set
            {
                if (_listaVisita == value) return;

                _listaVisita = value;

                RaisePropertyChanged(listaVisitaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaTipoRespuestaCuestionario

        public const string listaTipoRespuestaCuestionarioPropertyName = "listaTipoRespuestaCuestionario";

        private ObservableCollection<TipoRespuestaCuestionarioModelo> _listaTipoRespuestaCuestionario;

        public ObservableCollection<TipoRespuestaCuestionarioModelo> listaTipoRespuestaCuestionario
        {
            get
            {
                return _listaTipoRespuestaCuestionario;
            }
            set
            {
                if (_listaTipoRespuestaCuestionario == value) return;

                _listaTipoRespuestaCuestionario = value;

                RaisePropertyChanged(listaTipoRespuestaCuestionarioPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaUsuarioHerramientasAccionModelo

        public const string listaUsuarioHerramientasAccionModeloPropertyName = "listaUsuarioHerramientasAccionModelo";

        private ObservableCollection<UsuarioHerramientasAccionModelo> _listaUsuarioHerramientasAccionModelo;

        public ObservableCollection<UsuarioHerramientasAccionModelo> listaUsuarioHerramientasAccionModelo
        {
            get
            {
                return _listaUsuarioHerramientasAccionModelo;
            }
            set
            {
                if (_listaUsuarioHerramientasAccionModelo == value) return;

                _listaUsuarioHerramientasAccionModelo = value;

                RaisePropertyChanged(listaUsuarioHerramientasAccionModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaTipoHerramienta

        public const string listaTipoHerramientaPropertyName = "listaTipoHerramienta";

        private ObservableCollection<TipoHerramientaModelo> _listaTipoHerramienta;

        public ObservableCollection<TipoHerramientaModelo> listaTipoHerramienta
        {
            get
            {
                return _listaTipoHerramienta;
            }
            set
            {
                if (_listaTipoHerramienta == value) return;

                _listaTipoHerramienta = value;

                RaisePropertyChanged(listaTipoHerramientaPropertyName);
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

        #region ViewModel Property : currentEntidad Detalle Herramientas Modelo 

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleHerramientasModelo _currentEntidad;

        public DetalleHerramientasModelo currentEntidad
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

        #region ViewModel Property : selectedPadreEntidad Detalle Herramientas Modelo 

        public const string selectedPadreEntidadPropertyName = "selectedPadreEntidad";

        private DetalleHerramientasModelo _selectedPadreEntidad;

        public DetalleHerramientasModelo selectedPadreEntidad
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
            }
        }

        #endregion

        #region Herramienta Modelo

        #region idHerramienta

        public const string idHerramientaPropertyName = "idHerramienta";

        private int _idHerramienta = 0;

        public int idHerramienta
        {
            get
            {
                return _idHerramienta;
            }

            set
            {
                if (_idHerramienta == value)
                {
                    return;
                }

                _idHerramienta = value;
                RaisePropertyChanged(idHerramientaPropertyName);
            }
        }

        #endregion

        #region idTp

        public const string idTpPropertyName = "idTp";

        private int _idTp = 0;

        public int idTp
        {
            get
            {
                return _idTp;
            }

            set
            {
                if (_idTp == value)
                {
                    return;
                }

                _idTp = value;
                RaisePropertyChanged(idTpPropertyName);
            }
        }

        #endregion

        #region idTh

        public const string idThPropertyName = "idTh";

        private int _idTh = 0;

        public int idTh
        {
            get
            {
                return _idTh;
            }

            set
            {
                if (_idTh == value)
                {
                    return;
                }

                _idTh = value;
                RaisePropertyChanged(idThPropertyName);
            }
        }

        #endregion


        #region nombreHerramienta

        public const string nombreHerramientaPropertyName = "nombreHerramienta";

        private string _nombreHerramienta = string.Empty;

        public string nombreHerramienta
        {
            get
            {
                return _nombreHerramienta;
            }

            set
            {
                if (_nombreHerramienta == value)
                {
                    return;
                }

                _nombreHerramienta = value;
                RaisePropertyChanged(nombreHerramientaPropertyName);
            }
        }

        #endregion

        #region descripcionDhSeleccion

        public const string descripcionDhSeleccionPropertyName = "descripcionDhSeleccion";

        private string _descripcionDhSeleccion = string.Empty;

        public string descripcionDhSeleccion
        {
            get
            {
                return _descripcionDhSeleccion;
            }

            set
            {
                if (_descripcionDhSeleccion == value)
                {
                    return;
                }

                _descripcionDhSeleccion = value;
                RaisePropertyChanged(descripcionDhSeleccionPropertyName);
            }
        }

        #endregion

        #region fechacreadoherramienta

        public const string fechacreadoherramientaPropertyName = "fechacreadoherramienta";

        private DateTime _fechacreadoherramienta = DateTime.Now;

        public DateTime fechacreadoherramienta
        {
            get
            {
                return _fechacreadoherramienta;
            }

            set
            {
                if (_fechacreadoherramienta == value)
                {
                    return;
                }

                _fechacreadoherramienta = value;
                RaisePropertyChanged(fechacreadoherramientaPropertyName);
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


        #region estadoHerramienta

        public const string estadoHerramientaPropertyName = "estadoHerramienta";

        private string _estadoHerramienta = string.Empty;

        public string estadoHerramienta
        {
            get
            {
                return _estadoHerramienta;
            }

            set
            {
                if (_estadoHerramienta == value)
                {
                    return;
                }

                _estadoHerramienta = value;
                RaisePropertyChanged(estadoHerramientaPropertyName);
            }
        }

        #endregion

        #region sistemaHerramienta

        public const string sistemaHerramientaPropertyName = "sistemaHerramienta";

        private bool _sistemaHerramienta = false;

        public bool sistemaHerramienta
        {
            get
            {
                return _sistemaHerramienta;
            }

            set
            {
                if (_sistemaHerramienta == value)
                {
                    return;
                }

                _sistemaHerramienta = value;
                RaisePropertyChanged(sistemaHerramientaPropertyName);
            }
        }

        #endregion


        #endregion

        #region Detalle herramienta

        #region idDh

        public const string idDhPropertyName = "idDh";

        private int _idDh = 0;

        public int idDh
        {
            get
            {
                return _idDh;
            }

            set
            {
                if (_idDh == value)
                {
                    return;
                }

                _idDh = value;
                RaisePropertyChanged(idDhPropertyName);
            }
        }

        #endregion

        #region idtProcedimiento

        public const string idtProcedimientoPropertyName = "idtProcedimiento";

        private int _idtProcedimiento = 0;

        public int idtProcedimiento
        {
            get
            {
                return _idtProcedimiento;
            }

            set
            {
                if (_idtProcedimiento == value)
                {
                    return;
                }

                _idtProcedimiento = value;
                RaisePropertyChanged(idtProcedimientoPropertyName);
            }
        }

        #endregion

        #region descripcionDh

        public const string descripcionDhPropertyName = "descripcionDh";

        private string _descripcionDh = string.Empty;

        public string descripcionDh
        {
            get
            {
                return _descripcionDh;
            }

            set
            {
                if (_descripcionDh == value)
                {
                    return;
                }

                _descripcionDh = value;
                RaisePropertyChanged(descripcionDhPropertyName);
            }
        }

        #endregion

        #region fechaCreadoDh

        public const string fechaCreadoDhPropertyName = "fechaCreadoDh";

        private DateTime _fechaCreadoDh = DateTime.Now;

        public DateTime fechaCreadoDh
        {
            get
            {
                return _fechaCreadoDh;
            }

            set
            {
                if (_fechaCreadoDh == value)
                {
                    return;
                }

                _fechaCreadoDh = value;
                RaisePropertyChanged(fechaCreadoDhPropertyName);
            }
        }

        #endregion

        #region estadoDh

        public const string estadoDhPropertyName = "estadoDh";

        private string _estadoDh = string.Empty;

        public string estadoDh
        {
            get
            {
                return _estadoDh;
            }

            set
            {
                if (_estadoDh == value)
                {
                    return;
                }

                _estadoDh = value;
                RaisePropertyChanged(estadoDhPropertyName);
            }
        }

        #endregion

        #region sistemaDh

        public const string sistemaDhPropertyName = "sistemaDh";

        private bool _sistemaDh = false;

        public bool sistemaDh
        {
            get
            {
                return _sistemaDh;
            }

            set
            {
                if (_sistemaDh == value)
                {
                    return;
                }

                _sistemaDh = value;
                RaisePropertyChanged(sistemaDhPropertyName);
            }
        }

        #endregion

        #region ordenDh

        public const string ordenDhPropertyName = "ordenDh";

        private decimal? _ordenDh = 0;

        public decimal? ordenDh
        {
            get
            {
                return _ordenDh;
            }

            set
            {
                if (_ordenDh == value)
                {
                    return;
                }

                _ordenDh = value;
                RaisePropertyChanged(ordenDhPropertyName);
            }
        }

        #endregion

        #region horasPlanDh

        public const string horasPlanDhPropertyName = "horasPlanDh";

        private decimal _horasPlanDh = 0;

        public decimal horasPlanDh
        {
            get
            {
                return _horasPlanDh;
            }

            set
            {
                if (_horasPlanDh == value)
                {
                    return;
                }

                _horasPlanDh = value;
                RaisePropertyChanged(horasPlanDhPropertyName);
            }
        }

        #endregion

        #region idDhPrincipalDh

        public const string idDhPrincipalDhPropertyName = "idDhPrincipalDh";

        private int _idDhPrincipalDh = 0;

        public int idDhPrincipalDh
        {
            get
            {
                return _idDhPrincipalDh;
            }

            set
            {
                if (_idDhPrincipalDh == value)
                {
                    return;
                }

                _idDhPrincipalDh = value;
                RaisePropertyChanged(idDhPrincipalDhPropertyName);
                //Seleccion de valor
                currentEntidad.idDhPrincipalDh = _idDhPrincipalDh;
            }
        }

        #endregion

        #region idVisitaDh

        public const string idVisitaDhPropertyName = "idVisitaDh";

        private int _idVisitaDh = 0;

        public int idVisitaDh
        {
            get
            {
                return _idVisitaDh;
            }

            set
            {
                if (_idVisitaDh == value)
                {
                    return;
                }

                _idVisitaDh = value;
                RaisePropertyChanged(idVisitaDhPropertyName);
            }
        }

        #endregion

        #region nombreVisita 

        public const string nombreVisitaPropertyName = "nombreVisita";

        private string _nombreVisita  = string.Empty;

        public string nombreVisita 
        {
            get
            {
                return _nombreVisita ;
            }

            set
            {
                if (_nombreVisita  == value)
                {
                    return;
                }

                _nombreVisita  = value;
                RaisePropertyChanged(nombreVisitaPropertyName);
            }
        }

        #endregion

        #region nombreTipoProcedimiento

        public const string nombreTipoProcedimientoPropertyName = "nombreTipoProcedimiento";

        private string _nombreTipoProcedimiento = string.Empty;

        public string nombreTipoProcedimiento
        {
            get
            {
                return _nombreTipoProcedimiento;
            }

            set
            {
                if (_nombreTipoProcedimiento == value)
                {
                    return;
                }

                _nombreTipoProcedimiento = value;
                RaisePropertyChanged(nombreTipoProcedimientoPropertyName);
            }
        }

        #endregion

        #region nombreDetallePadre

        public const string nombreDetallePadrePropertyName = "nombreDetallePadre";

        private string _nombreDetallePadre = string.Empty;

        public string nombreDetallePadre
        {
            get
            {
                return _nombreDetallePadre;
            }

            set
            {
                if (_nombreDetallePadre == value)
                {
                    return;
                }

                _nombreDetallePadre = value;
                RaisePropertyChanged(nombreDetallePadrePropertyName);
            }
        }

        #endregion

        #endregion

        #region Usuario herramientas accion modelo

        #region idUha

        public const string idUhaPropertyName = "idUha";

        private int _idUha = 0;

        public int idUha
        {
            get
            {
                return _idUha;
            }

            set
            {
                if (_idUha == value)
                {
                    return;
                }

                _idUha = value;
                RaisePropertyChanged(idUhaPropertyName);
            }
        }

        #endregion

        #region idUsuario

        public const string idUsuarioPropertyName = "idUsuario";

        private int _idUsuario = 0;

        public int idUsuario
        {
            get
            {
                return _idUsuario;
            }

            set
            {
                if (_idUsuario == value)
                {
                    return;
                }

                _idUsuario = value;
                RaisePropertyChanged(idUsuarioPropertyName);
            }
        }

        #endregion

        #region rolUha

        public const string rolUhaPropertyName = "rolUha";

        private string _rolUha = string.Empty;

        public string rolUha
        {
            get
            {
                return _rolUha;
            }

            set
            {
                if (_rolUha == value)
                {
                    return;
                }

                _rolUha = value;
                RaisePropertyChanged(rolUhaPropertyName);
            }
        }

        #endregion

        #region fechaCreadoUha

        public const string fechaCreadoUhaPropertyName = "fechaCreadoUha";

        private DateTime _fechaCreadoUha = DateTime.Now;

        public DateTime fechaCreadoUha
        {
            get
            {
                return _fechaCreadoUha;
            }

            set
            {
                if (_fechaCreadoUha == value)
                {
                    return;
                }

                _fechaCreadoUha = value;
                RaisePropertyChanged(fechaCreadoUhaPropertyName);
            }
        }

        #endregion

        #region estadoUha

        public const string estadoUhaPropertyName = "estadoUha";

        private string _estadoUha = string.Empty;

        public string estadoUha
        {
            get
            {
                return _estadoUha;
            }

            set
            {
                if (_estadoUha == value)
                {
                    return;
                }

                _estadoUha = value;
                RaisePropertyChanged(estadoUhaPropertyName);
            }
        }

        #endregion


        #endregion

        #region ViewModel Property : SelectedTipoProcedimiento

        public const string SelectedTipoProcedimientoPropertyName = "SelectedTipoProcedimiento";

        private TipoProcedimientoModelo _SelectedTipoProcedimiento;

        public TipoProcedimientoModelo SelectedTipoProcedimiento
        {
            get
            {
                return _SelectedTipoProcedimiento;
            }

            set
            {
                if (_SelectedTipoProcedimiento == value) return;

                _SelectedTipoProcedimiento = value;
                RaisePropertyChanged(SelectedTipoProcedimientoPropertyName);
                if (!(value == null)&&(!(currentEntidad==null)))
                {
                    evaluarOpciones();
                    //currentEntidad.idtProcedimiento = _SelectedTipoProcedimiento.id;
                    //currentEntidad.nombreTipoProcedimiento = value.descripcion;
                }
            }
        }

        #endregion

        #region ViewModel Property : SelectedTipoHerramientaModelo

        public const string SelectedTipoHerramientaModeloPropertyName = "SelectedTipoHerramientaModelo";

        private TipoHerramientaModelo _SelectedTipoHerramientaModelo;

        public TipoHerramientaModelo SelectedTipoHerramientaModelo
        {
            get
            {
                return _SelectedTipoHerramientaModelo;
            }

            set
            {
                if (_SelectedTipoHerramientaModelo == value) return;

                _SelectedTipoHerramientaModelo = value;
                RaisePropertyChanged(SelectedTipoHerramientaModeloPropertyName);
                //Asignación del tipo de programa
                //currentEntidad.idTh = _SelectedTipoHerramientaModelo.id;
            }
        }

        #endregion

        #region ViewModel Property : SelectedVisita

        public const string SelectedVisitaPropertyName = "SelectedVisita";

        private VisitaModelo _SelectedVisita;

        public VisitaModelo SelectedVisita
        {
            get
            {
                return _SelectedVisita;
            }

            set
            {
                if (_SelectedVisita == value) return;

                _SelectedVisita = value;
                RaisePropertyChanged(SelectedVisitaPropertyName);
                //Asignación del tipo de programa
                /*if (!(value == null) && (!(currentEntidad == null)))
                    {
                    currentEntidad.idtProcedimiento = _SelectedVisita.id;
                    currentEntidad.nombreVisita = _SelectedVisita.descripcion;
                }*/
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

        #endregion


        #endregion


        #region Propiedades de ventanas

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

        #region tipoProcedimientoPregunta

        public const string tipoProcedimientoPreguntaPropertyName = "tipoProcedimientoPregunta";

        private string _tipoProcedimientoPregunta = string.Empty;

        public string tipoProcedimientoPregunta
        {
            get
            {
                return _tipoProcedimientoPregunta;
            }

            set
            {
                if (_tipoProcedimientoPregunta == value)
                {
                    return;
                }

                _tipoProcedimientoPregunta = value;
                RaisePropertyChanged(tipoProcedimientoPreguntaPropertyName);
            }
        }

        #endregion

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private Boolean _activarCaptura;

        public Boolean activarCaptura
        {
            get
            {
                return _activarCaptura;
            }

            set
            {
                if (_activarCaptura == value)
                {
                    return;
                }

                _activarCaptura = value;
                RaisePropertyChanged(activarCapturaPropertyName);
            }
        }

        #endregion

        #region contenidoControlCarga

        public const string contenidoControlCargaPropertyName = "contenidoControlCarga";

        private string _contenidoControlCarga = "Cargar";

        public string contenidoControlCarga
        {
            get
            {
                return _contenidoControlCarga;
            }

            set
            {
                if (_contenidoControlCarga == value)
                {
                    return;
                }

                _contenidoControlCarga = value;
                RaisePropertyChanged(contenidoControlCargaPropertyName);
            }
        }

        #endregion


        #region visibilidadHoras

        public const string visibilidadHorasPropertyName = "visibilidadHoras";

        private Visibility _visibilidadHoras = Visibility.Visible;

        public Visibility visibilidadHoras
        {
            get
            {
                return _visibilidadHoras;
            }

            set
            {
                if (_visibilidadHoras == value)
                {
                    return;
                }

                _visibilidadHoras = value;
                RaisePropertyChanged(visibilidadHorasPropertyName);
            }
        }

        #endregion

        #region marcaAguaArchivo

        public const string marcaAguaArchivoPropertyName = "marcaAguaArchivo";

        private string _marcaAguaArchivo = string.Empty;

        public string marcaAguaArchivo
        {
            get
            {
                return _marcaAguaArchivo;
            }

            set
            {
                if (_marcaAguaArchivo == value)
                {
                    return;
                }

                _marcaAguaArchivo = value;
                RaisePropertyChanged(marcaAguaArchivoPropertyName);
            }
        }

        #endregion

        #region visibilidadDependencia

        public const string visibilidadDependenciaPropertyName = "visibilidadDependencia";

        private Visibility _visibilidadDependencia = Visibility.Collapsed;

        public Visibility visibilidadDependencia
        {
            get
            {
                return _visibilidadDependencia;
            }

            set
            {
                if (_visibilidadDependencia == value)
                {
                    return;
                }

                _visibilidadDependencia = value;
                RaisePropertyChanged(visibilidadDependenciaPropertyName);
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

        #region activarCrear

        public const string activarCrearPropertyName = "activarCrear";

        private bool _activarCrear = false;

        public bool activarCrear
        {
            get
            {
                return _activarCrear;
            }

            set
            {
                if (_activarCrear == value)
                {
                    return;
                }

                _activarCrear = value;
                RaisePropertyChanged(activarCrearPropertyName);
            }
        }

        #endregion

        #region activarConsultar

        public const string activarConsultarPropertyName = "activarConsultar";

        private bool _activarConsultar = false;

        public bool activarConsultar
        {
            get
            {
                return _activarConsultar;
            }

            set
            {
                if (_activarConsultar == value)
                {
                    return;
                }

                _activarConsultar = value;
                RaisePropertyChanged(activarConsultarPropertyName);
            }
        }

        #endregion

        #region activarEditar

        public const string activarEditarPropertyName = "activarEditar";

        private bool _activarEditar = false;

        public bool activarEditar
        {
            get
            {
                return _activarEditar;
            }

            set
            {
                if (_activarEditar == value)
                {
                    return;
                }

                _activarEditar = value;
                RaisePropertyChanged(activarEditarPropertyName);
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
        public RelayCommand<DetalleHerramientasModelo> SelectionChangedCommand { get; set; }

        public RelayCommand<TipoProcedimientoModelo> cambioListaCommand { get; set; }

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public DetalleHerramientaControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _listaEntidadFiltrada = new ObservableCollection<DetalleHerramientasModelo>();
            _ListaEntidad = new ObservableCollection<DetalleHerramientasModelo>();
            _tokenEnvioCierre = "CierrePrevioProgramaSub-ventana";
            _visibilidadDependencia = Visibility.Collapsed;
            _accesibilidadCuerpo = false;
            enviarMensajeInhabilitar();

            //Suscribiendo el mensaje
            _listaEntidadFiltrada = new ObservableCollection<DetalleHerramientasModelo>();
            _ListaEntidad = new ObservableCollection<DetalleHerramientasModelo>();
            _listaTipoProcedimiento = new ObservableCollection<TipoProcedimientoModelo>();
            _listaEntidadSeleccion = new ObservableCollection<DetalleHerramientasModelo>();
            _listaTipoProcedimiento = new ObservableCollection<TipoProcedimientoModelo>();

            cerradoFinalVentana = false;
            listaVisita = new ObservableCollection<VisitaModelo>(VisitaModelo.GetAll(true));
            Messenger.Default.Register<DetalleHerramientoCrudMensaje>(this, (detalleHerramientoCrudMensaje) => ControlDetalleHerramientoCrudMensaje(detalleHerramientoCrudMensaje));
            dlg = new DialogCoordinator();
            accesibilidadWindow = true;
            RegisterCommands();
            arranque = true;
            Errors = 0;//Control de errores
        }
        private void ControlDetalleHerramientoCrudMensaje(DetalleHerramientoCrudMensaje detalleHerramientoCrudMensaje)
        {
            Errors = 0;//Control de errores
            listaTipoProcedimiento = new ObservableCollection<TipoProcedimientoModelo>(TipoProcedimientoModelo.GetAllByIdTh(detalleHerramientoCrudMensaje.tiposHerramienta,true));
            tipoHerramientaMenu = detalleHerramientoCrudMensaje.tiposHerramienta;//1 Para programa 2 para cuestionario
            currentEntidad = detalleHerramientoCrudMensaje.detalleHerramientaElemento;
            currentUsuario= detalleHerramientoCrudMensaje.usuarioValidado;
            opcionMenu = detalleHerramientoCrudMensaje.comando;

            configuracionHerramientaCmdCrud(opcionMenu);

            if (currentEntidad.idDh != 0)
            {
                //Si ya esta creada se cambia el listado para evitar duplicidad
                listaEntidadSeleccion = new ObservableCollection<DetalleHerramientasModelo>(detalleHerramientoCrudMensaje.listaElementos.Where(x => x.idDh != currentEntidad.idDh));
            }
            else
            {
                listaEntidadSeleccion = detalleHerramientoCrudMensaje.listaElementos;
            }
           
            currentEntidad.listaEntidadSeleccion = listaEntidadSeleccion;//Para poder verificar que el procedimiento sea único
            ListaEntidad = detalleHerramientoCrudMensaje.listaElementos;

            ordenDh = currentEntidad.ordenDh;

            //Carga de datos preliminares
            if (!((currentEntidad.idtProcedimiento == 0) || (currentEntidad.idtProcedimiento == null)))
            {
                SelectedTipoProcedimiento = listaTipoProcedimiento.Single(i => i.id == currentEntidad.idtProcedimiento);
            }
            else
            {
                SelectedTipoProcedimiento = listaTipoProcedimiento[0];
                //Configuracion de tipo  propiedades de tipode  procedimiento
            }

            evaluarOpciones();

            if (!((currentEntidad.idVisitaDh == 0) || (currentEntidad.idVisitaDh == null)))
            {
                SelectedVisita = listaVisita.Single(i => i.id == currentEntidad.idVisitaDh);
            }
            else
            {
                SelectedVisita = listaVisita[0];
            }
            //if (!((currentEntidad.idDhPrincipalDh == null)|| (currentEntidad.idDhPrincipalDh == 0)))
            //{
            //    selectedPadreEntidad = ListaEntidad.Single(i => i.idDh == currentEntidad.idDhPrincipalDh);
            //}
            //else
            //{
            //    selectedPadreEntidad = null;
            //}
            if (!((currentEntidad.idDhPrincipalDh == null) || (currentEntidad.idDhPrincipalDh == 0)))
            {
                listaEntidadFiltrada = filtradoLista(currentEntidad);//Se crea la lista filtrada
                selectedPadreEntidad = listaEntidadFiltrada.Single(i => i.idDh == currentEntidad.idDhPrincipalDh);
                visibilidadDependencia = Visibility.Visible;

            }
            else
            {
                selectedPadreEntidad = null;
                visibilidadDependencia = Visibility.Collapsed;
            }

            Messenger.Default.Unregister<DetalleHerramientoCrudMensaje>(this);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        private void evaluarOpciones()
        {
            if (!(SelectedTipoProcedimiento.id ==0))
            {
                if ((SelectedTipoProcedimiento.id == 1) || (SelectedTipoProcedimiento.id == 2) || (SelectedTipoProcedimiento.id == 0))//Solo si es procedimiento o sub-procedimiento 
                {
                    visibilidadHoras = Visibility.Visible;
                }
                else
                {
                    visibilidadHoras = Visibility.Collapsed;
                }
            }
            else
            {
                visibilidadHoras = Visibility.Collapsed;
            }
        }

        private async void  configuracionHerramientaCmdCrud(int comando)
        {
                tipoProcedimientoPregunta = "Descripcion";
                switch (comando.ToString())
                {
                    case "1":
                        accesibilidadWindow = true;
                        accesibilidadCuerpo = true;
                        encabezadoPantalla = "Introduzca el procedimiento, objetivo o sub-procedimiento";
                        currentEntidad.activarCaptura = true;
                        activarCaptura = true;
                        visibilidadCrear = Visibility.Visible;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Collapsed;
                        activarCrear = true;
                        activarConsultar = false;
                        activarEditar = false;
                        break;
                    case "2":
                        accesibilidadWindow = true;
                        accesibilidadCuerpo = true;
                        encabezadoPantalla = "Actualice los datos";
                        currentEntidad.activarCaptura = true;
                        activarCaptura = true;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Visible;
                        visibilidadConsultar = Visibility.Collapsed;
                        activarCrear = false;
                        activarConsultar = false;
                        activarEditar = true;
                        break;
                    case "3":
                        accesibilidadWindow = true;
                        accesibilidadCuerpo = false;
                        encabezadoPantalla = "Datos del registro";
                        currentEntidad.activarCaptura = false;
                        activarCaptura = false;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadConsultar = Visibility.Visible;
                        activarCrear = false;
                        activarConsultar = true;
                        activarEditar = false;
                        break;
                    default:
                        //await dlg.ShowMessageAsync(this, "Error en comunicacion de comando", "");
                    var controller = await dlg.ShowProgressAsync(this, "Error en comunicacion de comando", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();

                    break;
            }
        }


        #endregion

        private async void Cancelar()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            cerradoFinalVentana = true;
            CloseWindow();


        }

        private void Ok()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            cerradoFinalVentana = true;
            CloseWindow();


        }

        private void Salir()
        {
            if (!(cerradoFinalVentana))
            {
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                cerradoFinalVentana = true;
                CloseWindow();

            }
            enviarMensajeHabilitar();
        }

        public async void Guardar()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
                        if (!((SelectedVisita == null)|| (SelectedVisita.id == 0)))
                        {
                            currentEntidad.idVisitaDh = SelectedVisita.id;
                        }
                        if (!((SelectedTipoProcedimiento == null)|| (SelectedTipoProcedimiento.id == 0)))
                        {
                            currentEntidad.idtProcedimiento = SelectedTipoProcedimiento.id;
                        }
                        if (!((selectedPadreEntidad == null) || (selectedPadreEntidad.idDh == 0)))
                        {
                            currentEntidad.idDhPrincipalDh = selectedPadreEntidad.idDh;
                            currentEntidad.ordenDh = ordenRegistro(selectedPadreEntidad, selectedPadreEntidad.idHerramienta);
                            currentEntidad.ordenDhPadre = selectedPadreEntidad.ordenDh;
                            currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordenDh);
                        }
                        else
                        {
                            currentEntidad.ordenDh = ordenRegistro(selectedPadreEntidad, currentEntidad.idHerramienta);
                            currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordenDh);
                        }
                        if (DetalleHerramientasModelo.Insert(currentEntidad, true))
                            {

                                //await dlg.ShowMessageAsync(this, "Registro creado con éxito", "");
                                var controller = await dlg.ShowProgressAsync(this, "Registro creado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                                cerradoFinalVentana = true;
                                CloseWindow();

            }
                            else
                            {
                                accesibilidadWindow = true;
                                Mouse.OverrideCursor = null;
                                await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            }
        }

        public async void Modificar()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            if (!((SelectedVisita == null)|| (SelectedVisita.id == 0)))
                        {
                            currentEntidad.idVisitaDh = SelectedVisita.id;
                        }
                        else
                        {
                            currentEntidad.idVisitaDh = null;
                        }
                        if (!((SelectedTipoProcedimiento == null)|| (SelectedTipoProcedimiento.id == 0)))
                        {
                            currentEntidad.idtProcedimiento = SelectedTipoProcedimiento.id;
                        }
                        else
                        {
                            currentEntidad.idtProcedimiento = null;
                        }
                        if (!((selectedPadreEntidad == null) || (selectedPadreEntidad.idDh == 0)))
                        {
                            currentEntidad.idDhPrincipalDh = selectedPadreEntidad.idDh;
                            currentEntidad.ordenDh = ordenRegistro(selectedPadreEntidad, selectedPadreEntidad.idHerramienta);
                            currentEntidad.ordenDhPadre = selectedPadreEntidad.ordenDh;
                            currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordenDh);
                        }
                        else
                        {
                            currentEntidad.ordenDh = ordenRegistro(selectedPadreEntidad, currentEntidad.idHerramienta);
                            currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordenDh);
                        }
                        if (DetalleHerramientasModelo.UpdateModelo(currentEntidad, true))
                        {

                            var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync(); cerradoFinalVentana = true;
                            CloseWindow();
                        }
                        else
                        {
                            accesibilidadWindow = true;
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                        }

        }

        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        private bool ControlVentanaMensaje(int controlVentanaMensaje)
        {
            if (controlVentanaMensaje == 0)
            {
                //Nuevo();
                return true;
            }
            else
            {
                cerradoFinalVentana = true;
                CloseWindow();
                return false;

            }
        }

        public void enviarMensajeInhabilitar()
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar, tokenEnvioCierre);
        }
        public void enviarMensajeHabilitar()
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(habilitar, tokenEnvioCierre);
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
                evaluar= (Errors == 0) &&
                          ((SelectedTipoProcedimiento.id != 0));
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
            SelectionChangedCommand = new RelayCommand<DetalleHerramientasModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
            cambioListaCommand = new RelayCommand<TipoProcedimientoModelo>(entidad =>
            {
                if (entidad == null) return;
                visibilidadDependencia = Visibility.Collapsed;
                listaEntidadFiltrada = new ObservableCollection<DetalleHerramientasModelo>();
                currentEntidad.tipoProcedimientoModelo = entidad;
                currentEntidad.idtProcedimiento = entidad.id;
                //Filtrar la lista según la selección
                listaEntidadFiltrada = filtradoLista(entidad);
                if (!arranque)
                {
                    if (listaEntidadFiltrada.Count > 0)

                    {
                        selectedPadreEntidad = listaEntidadFiltrada[0];//Cambio la seleccion debe eliminarse lo escogido
                    }
                    else
                    {
                        selectedPadreEntidad = null;
                    }
                }
                if (listaEntidadFiltrada.Count > 0)
                {
                    visibilidadDependencia = Visibility.Visible;
                }
            });
        }


        private ObservableCollection<DetalleHerramientasModelo> filtradoLista(DetalleHerramientasModelo entidad)
        {
            return filtradoLista(entidad.nombreTipoProcedimiento);
        }

        private ObservableCollection<DetalleHerramientasModelo> filtradoLista(TipoProcedimientoModelo entidad)
        {
            return filtradoLista(entidad.descripcion);//Descripcion del tipo de procedimiento
        }

        private ObservableCollection<DetalleHerramientasModelo> filtradoLista(string TipoProcedimiento)
        {
            ObservableCollection<DetalleHerramientasModelo> listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>();
            if (TipoProcedimiento == null || string.IsNullOrEmpty(TipoProcedimiento))
            {
                return listaFiltrada;
            }
            else
            {
                //Filtrar la lista según la selección
                switch (TipoProcedimiento.ToUpper())
                {
                    case "PROCEDIMIENTO":
                        break;
                    case "PREGUNTA":
                        break;
                    case "OBJETIVO":
                        break;
                    case "TITULO":
                        break;
                    case "INDICACIONES":
                        break;
                    case "ALCANCE":
                        break;
                    case "SUB-SUB-TITULO":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-TITULO"));
                        break;
                    case "SUB-TITULO":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "TITULO"));
                        break;
                    case "SUB-SUB-INDICACIONES":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-INDICACIONES"));
                        break;
                    case "SUB-INDICACIONES":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "INDICACIONES"));
                        break;
                    case "SUB-PROCEDIMIENTO":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "PROCEDIMIENTO"));
                        break;
                    case "SUB-SUB-PROCEDIMIENTO":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-PROCEDIMIENTO"));
                        break;
                    case "SUB-PREGUNTA":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "PREGUNTA"));
                        break;
                    case "SUB-OBJETIVO":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "OBJETIVO"));
                        break;
                    case "SUB-SUB-OBJETIVO":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-OBJETIVO"));
                        break;
                    case "SUB-ALCANCE":
                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "ALCANCE"));
                        break;
                    case "SUB-SUB-ALCANCE":

                        listaFiltrada = new ObservableCollection<DetalleHerramientasModelo>(ListaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-ALCANCE"));
                        break;
                }
                if (listaFiltrada.Count > 0)
                {
                    foreach (DetalleHerramientasModelo item in listaFiltrada)
                    {
                        item.descripcionDhSeleccion = item.ordenDh + "-" + item.descripcionDh;
                    }
                }
                return listaFiltrada;
            }
        }


        private decimal ordenRegistro(DetalleHerramientasModelo padre, int idHerramientaSeleccionada)
        {
            decimal ordenRespuesta = 0;
            if (!(padre == null))
            {
                if (!(padre.idDh == 0))
                {
                    int registros = DetalleHerramientasModelo.ContarSubRegistros(padre.idDh) + 1;
                    decimal factorSuma = MetodosModelo.factorPadre(padre.nombreTipoProcedimiento);
                    if (registros == 1)
                    {
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordenDh, factorSuma);
                    }
                    else
                    {
                        //decimal suma = Decimal.Add((Decimal)0.01, (decimal)0.01 * registros);
                        //currentEntidad.ordenDh = Decimal.Add((Decimal)_selectedPadreEntidad.ordenDh, suma);
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordenDh, factorSuma * registros);
                    }
                }
            }
            else
            {
                ordenRespuesta = (decimal)DetalleHerramientasModelo.FindOrden(idHerramientaSeleccionada);
            }
            return ordenRespuesta;
        }

        #endregion

    }
}
