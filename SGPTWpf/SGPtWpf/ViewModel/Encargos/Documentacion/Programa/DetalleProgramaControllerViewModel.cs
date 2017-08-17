using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model;
using System.Windows;
using System.Linq;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Messages.Encargos;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Model.Modelo.Encargos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa
{
    public sealed class DetalleProgramaControllerViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        public static int Errors { get; set; }//Para controllar los errores de edición

        #region resultadoProceso

        private bool _resultadoProceso;
        private bool resultadoProceso
        {
            get { return _resultadoProceso; }
            set { _resultadoProceso = value; }
        }

        #endregion

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region cerradoFinalVentana

        private bool _cerradoFinalVentana;
        private bool cerradoFinalVentana
        {
            get { return _cerradoFinalVentana; }
            set { _cerradoFinalVentana = value; }
        }

        #endregion

        #region  tokenEnvioCierre

        private string _tokenEnvioCierre;
        private string tokenEnvioCierre
        {
            get { return _tokenEnvioCierre; }
            set { _tokenEnvioCierre = value; }
        }

        #endregion

        #region tokenRecepcionDetallePrograma

        private string _tokenRecepcionDetallePrograma;
        private string tokenRecepcionDetallePrograma
        {
            get { return _tokenRecepcionDetallePrograma; }
            set { _tokenRecepcionDetallePrograma = value; }
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

        private readonly IDialogCoordinator _dialogCoordinator;

        private DialogCoordinator dlg;

        #region opcionMenu

        private int _opcionMenu;
        private int opcionMenu
        {
            get { return _opcionMenu; }
            set { _opcionMenu = value; }
        }

        #endregion

        #region tipoHerramientaMenu

        private int _tipoHerramientaMenu;
        private int tipoHerramientaMenu
        {
            get { return _tipoHerramientaMenu; }
            set { _tipoHerramientaMenu = value; }
        }

        #endregion


        #region arranque

        private bool _arranque;
        private bool arranque
        {
            get { return _arranque; }
            set { _arranque = value; }
        }

        #endregion


        #endregion

        #region Lista de entidades

        #region ViewModel Properties : listaEntidad

        public const string listaEntidadPropertyName = "listaEntidad";

        private ObservableCollection<DetalleProgramaModelo> _listaEntidad;

        public ObservableCollection<DetalleProgramaModelo> listaEntidad
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

        #region Lista de entidades

        #region ViewModel Properties : listaEntidadFiltrada

        public const string listaEntidadFiltradaPropertyName = "listaEntidadFiltrada";

        private ObservableCollection<DetalleProgramaModelo> _listaEntidadFiltrada;

        public ObservableCollection<DetalleProgramaModelo> listaEntidadFiltrada
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

        private ObservableCollection<DetalleProgramaModelo> _listaEntidadSeleccion;

        public ObservableCollection<DetalleProgramaModelo> listaEntidadSeleccion
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

        #region ViewModel Properties : listaUsuarioProgramaAccionModelo

        public const string listaUsuarioProgramaAccionModeloPropertyName = "listaUsuarioProgramaAccionModelo";

        private ObservableCollection<UsuarioProgramaAccionModelo> _listaUsuarioProgramaAccionModelo;

        public ObservableCollection<UsuarioProgramaAccionModelo> listaUsuarioProgramaAccionModelo
        {
            get
            {
                return _listaUsuarioProgramaAccionModelo;
            }
            set
            {
                if (_listaUsuarioProgramaAccionModelo == value) return;

                _listaUsuarioProgramaAccionModelo = value;

                RaisePropertyChanged(listaUsuarioProgramaAccionModeloPropertyName);
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

        #endregion lista de entidades

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

        #region ViewModel Property : currentEntidad Detalle Programa Modelo 

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleProgramaModelo _currentEntidad;

        public DetalleProgramaModelo currentEntidad
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

        #region ViewModel Property : currentEncargo Detalle Programa Modelo 

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

        #region ViewModel Property : selectedPadreEntidad Detalle Herramientas Modelo 

        public const string selectedPadreEntidadPropertyName = "selectedPadreEntidad";

        private DetalleProgramaModelo _selectedPadreEntidad;

        public DetalleProgramaModelo selectedPadreEntidad
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

        #region estadodp

        public const string estadodpPropertyName = "estadodp";

        private string _estadodp = string.Empty;

        public string estadodp
        {
            get
            {
                return _estadodp;
            }

            set
            {
                if (_estadodp == value)
                {
                    return;
                }

                _estadodp = value;
                RaisePropertyChanged(estadodpPropertyName);
            }
        }

        #endregion

        #region ordendp

        public const string ordendpPropertyName = "ordendp";

        private decimal? _ordendp = 0;

        public decimal? ordendp
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

        #region horaplandp

        public const string horaplandpPropertyName = "horaplandp";

        private decimal _horaplandp = 0;

        public decimal horaplandp
        {
            get
            {
                return _horaplandp;
            }

            set
            {
                if (_horaplandp == value)
                {
                    return;
                }

                _horaplandp = value;
                RaisePropertyChanged(horaplandpPropertyName);
            }
        }

        #endregion

        #region idpadredp

        public const string idpadredpPropertyName = "idpadredp";

        private int _idpadredp = 0;

        public int idpadredp
        {
            get
            {
                return _idpadredp;
            }

            set
            {
                if (_idpadredp == value)
                {
                    return;
                }

                _idpadredp = value;
                RaisePropertyChanged(idpadredpPropertyName);
                //Seleccion de valor
                currentEntidad.idpadredp = _idpadredp;
            }
        }

        #endregion

        #region idvisitadp

        public const string idvisitadpPropertyName = "idvisitadp";

        private int _idvisitadp = 0;

        public int idvisitadp
        {
            get
            {
                return _idvisitadp;
            }

            set
            {
                if (_idvisitadp == value)
                {
                    return;
                }

                _idvisitadp = value;
                RaisePropertyChanged(idvisitadpPropertyName);
            }
        }

        #endregion

        #region nombreVisita 

        public const string nombreVisitaPropertyName = "nombreVisita";

        private string _nombreVisita = string.Empty;

        public string nombreVisita
        {
            get
            {
                return _nombreVisita;
            }

            set
            {
                if (_nombreVisita == value)
                {
                    return;
                }

                _nombreVisita = value;
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

        #region UsuarioProgramaAccionModelo

        #region idupa

        public const string idupaPropertyName = "idupa";

        private int _idupa = 0;

        public int idupa
        {
            get
            {
                return _idupa;
            }

            set
            {
                if (_idupa == value)
                {
                    return;
                }

                _idupa = value;
                RaisePropertyChanged(idupaPropertyName);
            }
        }

        #endregion

        #region idusuarioupa

        public const string idusuarioupaPropertyName = "idusuarioupa";

        private int _idusuarioupa = 0;

        public int idusuarioupa
        {
            get
            {
                return _idusuarioupa;
            }

            set
            {
                if (_idusuarioupa == value)
                {
                    return;
                }

                _idusuarioupa = value;
                RaisePropertyChanged(idusuarioupaPropertyName);
            }
        }

        #endregion

        #region rolupa

        public const string rolupaPropertyName = "rolupa";

        private string _rolupa = string.Empty;

        public string rolupa
        {
            get
            {
                return _rolupa;
            }

            set
            {
                if (_rolupa == value)
                {
                    return;
                }

                _rolupa = value;
                RaisePropertyChanged(rolupaPropertyName);
            }
        }

        #endregion

        #region fechacreadoupa

        public const string fechacreadoupaPropertyName = "fechacreadoupa";

        private DateTime _fechacreadoupa = DateTime.Now;

        public DateTime fechacreadoupa
        {
            get
            {
                return _fechacreadoupa;
            }

            set
            {
                if (_fechacreadoupa == value)
                {
                    return;
                }

                _fechacreadoupa = value;
                RaisePropertyChanged(fechacreadoupaPropertyName);
            }
        }

        #endregion

        #region estadoupa

        public const string estadoupaPropertyName = "estadoupa";

        private string _estadoupa = string.Empty;

        public string estadoupa
        {
            get
            {
                return _estadoupa;
            }

            set
            {
                if (_estadoupa == value)
                {
                    return;
                }

                _estadoupa = value;
                RaisePropertyChanged(estadoupaPropertyName);
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
                if (!(value == null) && (!(currentEntidad == null)))
                {
                    evaluarOpciones();
                    //currentEntidad.idtprocedimientodp = _SelectedTipoProcedimiento.id;
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
                //currentEntidad.idthprograma = _SelectedTipoHerramientaModelo.id;
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
                    currentEntidad.idtprocedimientodp = _SelectedVisita.id;
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

        #region fechainidp

        public const string fechainidpPropertyName = "fechainidp";

        private string _fechainidp;

        public string fechainidp
        {
            get
            {
                return _fechainidp;
            }

            set
            {
                if (_fechainidp == value)
                {
                    return;
                }

                _fechainidp = value;
                RaisePropertyChanged(fechainidpPropertyName);
            }
        }

        #endregion

        #region fechafindp

        public const string fechafindpPropertyName = "fechafindp";

        private string _fechafindp;

        public string fechafindp
        {
            get
            {
                return _fechafindp;
            }

            set
            {
                if (_fechafindp == value)
                {
                    return;
                }

                _fechafindp = value;
                RaisePropertyChanged(fechafindpPropertyName);
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

        #region fechainidpDate

        public const string fechainidpDatePropertyName = "fechainidpDate";

        private DateTime? _fechainidpDate;

        public DateTime? fechainidpDate
        {
            get
            {
                return _fechainidpDate;
            }

            set
            {
                if (_fechainidpDate == value)
                {
                    return;
                }

                _fechainidpDate = value;
                RaisePropertyChanged(fechainidpDatePropertyName);
            }
        }

        #endregion

        #region fechafindpDate

        public const string fechafindpDatePropertyName = "fechafindpDate";

        private DateTime? _fechafindpDate;

        public DateTime? fechafindpDate
        {
            get
            {
                return _fechafindpDate;
            }

            set
            {
                if (_fechafindpDate == value)
                {
                    return;
                }

                _fechafindpDate = value;
                RaisePropertyChanged(fechafindpDatePropertyName);
            }
        }

        #endregion

        #region fechasupervisionDate

        public const string fechasupervisionDatePropertyName = "fechasupervisionDate";

        private DateTime? _fechasupervisionDate;

        public DateTime? fechasupervisionDate
        {
            get
            {
                return _fechasupervisionDate;
            }

            set
            {
                if (_fechasupervisionDate == value)
                {
                    return;
                }

                _fechasupervisionDate = value;
                RaisePropertyChanged(fechasupervisionDatePropertyName);
            }
        }

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

        #region visibilidadCmdReferenciar

        public const string visibilidadCmdReferenciarPropertyName = "visibilidadCmdReferenciar";

        private Visibility _visibilidadCmdReferenciar = Visibility.Collapsed;

        public Visibility visibilidadCmdReferenciar
        {
            get
            {
                return _visibilidadCmdReferenciar;
            }

            set
            {
                if (_visibilidadCmdReferenciar == value)
                {
                    return;
                }

                _visibilidadCmdReferenciar = value;
                RaisePropertyChanged(visibilidadCmdReferenciarPropertyName);
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

        public RelayCommand<TipoProcedimientoModelo> cambioListaCommand { get; set; }
        public RelayCommand<DetalleProgramaModelo> SelectionChangedCommand { get; set; }

        public RelayCommand referenciarCommand { get; set; }


        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores


        public DetalleProgramaControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _resultadoProceso = false;
            _tokenEnvioCierre = "CierreEncargoPlanProgramaSub-ventana";
            //enviarMensajeInhabilitar();
            _cerradoFinalVentana = false;
            _accesibilidadCuerpo = false;
            _opcionMenu = 0;
            Errors = 0;
            _arranque = true;
            _tipoHerramientaMenu = 0; //1 para programa 2 para cuestionario
            _tokenRecepcionDetallePrograma = "DatosParaProgramaDetalle";
            //Suscribiendo el mensaje
            _listaVisita = new ObservableCollection<VisitaModelo>(VisitaModelo.GetAll(true));
            _listaEntidadSeleccion = new ObservableCollection<DetalleProgramaModelo>();
            _listaTipoProcedimiento = new ObservableCollection<TipoProcedimientoModelo>();
            _listaEntidad = new ObservableCollection<DetalleProgramaModelo>();
            _listaEntidadFiltrada = new ObservableCollection<DetalleProgramaModelo>();
            _visibilidadDependencia = Visibility.Collapsed;
            _visibilidadCmdReferenciar = Visibility.Collapsed;
            Messenger.Default.Register<EncargoPlanDetalleProgramaCrudMsj>(this, tokenRecepcionDetallePrograma, (encargoPlanDetalleProgramaCrudMsj) => ControlEncargoPlanDetalleProgramaCrudMsj(encargoPlanDetalleProgramaCrudMsj));
            dlg = new DialogCoordinator();
            accesibilidadWindow = true;
            RegisterCommands();
            arranque = true;
            Errors = 0;//Control de errores
            SelectedTipoProcedimiento = new TipoProcedimientoModelo();
            currentEntidad = new DetalleProgramaModelo();

            _fechainidp = string.Empty;
            _fechafindp = string.Empty;
            _fechasupervision = string.Empty;
            _fechainidpDate = new DateTime();
            _fechafindpDate = new DateTime();
            _fechasupervisionDate = new DateTime();
            _fechacreadodp = new DateTime();
        }

        public DetalleProgramaControllerViewModel(string origen)
        {
            _origenLlamada = origen;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _resultadoProceso = false;
            _tokenEnvioCierre = "CierreEncargoDocumentacionProgramaSub-ventana";
            //enviarMensajeInhabilitar();
            _cerradoFinalVentana = false;
            _accesibilidadCuerpo = false;
            _opcionMenu = 0;
            Errors = 0;
            _arranque = true;
            _tipoHerramientaMenu = 0; //1 para programa 2 para cuestionario
            _tokenRecepcionDetallePrograma = "DatosDocumentacionParaProgramaDetalle";
            //Suscribiendo el mensaje
            _listaVisita = new ObservableCollection<VisitaModelo>(VisitaModelo.GetAll(true));
            _listaEntidadSeleccion = new ObservableCollection<DetalleProgramaModelo>();
            _listaTipoProcedimiento = new ObservableCollection<TipoProcedimientoModelo>();
            _listaEntidad = new ObservableCollection<DetalleProgramaModelo>();
            _listaEntidadFiltrada = new ObservableCollection<DetalleProgramaModelo>();
            _visibilidadDependencia = Visibility.Collapsed;
            _visibilidadCmdReferenciar = Visibility.Collapsed;
            Messenger.Default.Register<EncargoPlanDetalleProgramaCrudMsj>(this, tokenRecepcionDetallePrograma, (encargoPlanDetalleProgramaCrudMsj) => ControlEncargoPlanDetalleProgramaCrudMsj(encargoPlanDetalleProgramaCrudMsj));
            dlg = new DialogCoordinator();
            accesibilidadWindow = true;
            RegisterCommands();
            arranque = true;
            Errors = 0;//Control de errores
            SelectedTipoProcedimiento = new TipoProcedimientoModelo();
            currentEntidad = new DetalleProgramaModelo();

            _fechainidp = string.Empty;
            _fechafindp = string.Empty;
            _fechasupervision = string.Empty;
            _fechainidpDate = new DateTime();
            _fechafindpDate = new DateTime();
            _fechasupervisionDate = new DateTime();
            _fechacreadodp = new DateTime();

            #endregion Inicializacion de  fechas
                fechainidpDate = new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day);
                fechafindpDate = new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day);
                fechasupervisionDate = new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day);
            #endregion
        }
        private void ControlEncargoPlanDetalleProgramaCrudMsj(EncargoPlanDetalleProgramaCrudMsj detalleHerramientoCrudMensaje)
        {
            listaTipoProcedimiento = new ObservableCollection<TipoProcedimientoModelo>(TipoProcedimientoModelo.GetAllByIdTh(detalleHerramientoCrudMensaje.tiposHerramienta, true));
            tipoHerramientaMenu = (int)detalleHerramientoCrudMensaje.tiposHerramienta;//1 Para programa 2 para cuestionario
            currentEntidad = detalleHerramientoCrudMensaje.detalleHerramientaElemento;
            currentUsuario = detalleHerramientoCrudMensaje.usuarioValidado;
            opcionMenu = detalleHerramientoCrudMensaje.comando;
            currentEncargo = detalleHerramientoCrudMensaje.currentEncargo;
            configuracionHerramientaCmdCrud(opcionMenu);

            listaEntidadSeleccion = detalleHerramientoCrudMensaje.listaElementos;
            currentEntidad.listaEntidadSeleccion = listaEntidadSeleccion;


            listaEntidad = detalleHerramientoCrudMensaje.listaElementos;

            ordendp = currentEntidad.ordendp;


            //Carga de datos preliminares
            if (!((currentEntidad.idtprocedimientodp == 0) || (currentEntidad.idtprocedimientodp == null)))
            {
                SelectedTipoProcedimiento = listaTipoProcedimiento.Single(i => i.id == currentEntidad.idtprocedimientodp);
            }
            else
            {
                SelectedTipoProcedimiento = listaTipoProcedimiento[0];
                //Configuracion de tipo  propiedades de tipode  procedimiento
            }

            evaluarOpciones();

            if (!((currentEntidad.idvisitadp == 0) || (currentEntidad.idvisitadp == null)))
            {
                SelectedVisita = listaVisita.Single(i => i.id == currentEntidad.idvisitadp);
            }
            else
            {
                SelectedVisita = listaVisita[0];
            }
            if (!((currentEntidad.idpadredp == null) || (currentEntidad.idpadredp == 0)))
            {
                listaEntidadFiltrada = filtradoLista(currentEntidad);//Se crea la lista filtrada
                selectedPadreEntidad = listaEntidadFiltrada.Single(i => i.iddp == currentEntidad.idpadredp);
                visibilidadDependencia = Visibility.Visible;
            }
            else
            {
                selectedPadreEntidad = null;
                //selectedPadreEntidad = listaEntidad[0];
                visibilidadDependencia = Visibility.Collapsed;
            }

            #region fechas

            //Conversion de fechas
            if (!string.IsNullOrEmpty(currentEntidad.fechainidp))
            {
                fechainidpDate = MetodosModelo.convertirFecha(currentEntidad.fechainidp);
            }
            else
            {
               fechainidpDate = new DateTime((DateTime.Now.Year), DateTime.Now.Month-1, DateTime.Now.Day);
            }
            if (!string.IsNullOrEmpty(currentEntidad.fechafindp))
            {
                fechafindpDate = MetodosModelo.convertirFecha(currentEntidad.fechafindp);
            }
            else
            {
                fechafindpDate = new DateTime((DateTime.Now.Year) , DateTime.Now.Month - 1, DateTime.Now.Day);
            }
            if (!string.IsNullOrEmpty(currentEntidad.fechasupervision))
            {
                fechasupervisionDate = MetodosModelo.convertirFecha(currentEntidad.fechasupervision);
            }
            else
            {
                fechasupervisionDate = new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day);
            }
            #endregion
            Messenger.Default.Unregister<EncargoPlanDetalleProgramaCrudMsj>(this, tokenRecepcionDetallePrograma);
            Mouse.OverrideCursor = null;
        }

        private void evaluarOpciones()
        {
            if (!(SelectedTipoProcedimiento.id == 0))
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

        private async void configuracionHerramientaCmdCrud(int comando)
        {
            tipoProcedimientoPregunta = "Descripcion";
            switch (comando.ToString())
            {
                case "1":
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    encabezadoPantalla = "Introduzca el procedimiento, objetivo o sub-procedimiento";
                    visibilidadCrear = Visibility.Visible;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCmdReferenciar = Visibility.Collapsed;
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    visibilidadDependencia = Visibility.Collapsed;
                    break;
                case "2":
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    encabezadoPantalla = "Actualice los datos";
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCmdReferenciar = Visibility.Collapsed;
                    activarCrear = false;
                    activarConsultar = false;
                    activarEditar = true;
                    break;
                case "3":
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = false;
                    encabezadoPantalla = "Datos del registro";
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCmdReferenciar = Visibility.Collapsed;
                    activarCrear = false;
                    activarConsultar = true;
                    activarEditar = false;
                    break;
                case "10":
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    encabezadoPantalla = "Complete los datos del procedimiento";
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCmdReferenciar = Visibility.Visible;
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    visibilidadDependencia = Visibility.Collapsed;
                    break;
                default:
                    await dlg.ShowMessageAsync(this, "Error en comunicacion de comando", "");
                    break;
            }
        }


        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            this.CloseWindow();
            cerradoFinalVentana = true;

        }

        private void Ok()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            CloseWindow();
            cerradoFinalVentana = true;

        }

        private void Salir()
        {
            if (!(cerradoFinalVentana))
            {
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                enviarMensajeHabilitar();
                CloseWindow();
            }
            else
            {
                enviarMensajeHabilitar();
            }
        }

        public async void Guardar()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;

            if (!((SelectedVisita == null) || (SelectedVisita.id == 0)))
            {
                currentEntidad.idvisitadp = SelectedVisita.id;
            }
            if (!((SelectedTipoProcedimiento == null) || (SelectedTipoProcedimiento.id == 0)))
            {
                currentEntidad.idtprocedimientodp = SelectedTipoProcedimiento.id;
            }
            if (!((selectedPadreEntidad == null) || (selectedPadreEntidad.iddp == 0)))
            {
                currentEntidad.idpadredp = selectedPadreEntidad.iddp;
                currentEntidad.ordendp = ordenRegistro(selectedPadreEntidad, selectedPadreEntidad.idprogramadp);
                currentEntidad.ordendpPadre = selectedPadreEntidad.ordendp;
                //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
            }
            else
            {
                currentEntidad.ordendp = ordenRegistro(selectedPadreEntidad, currentEntidad.idprogramadp);
                //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
            }
            if (DetalleProgramaModelo.Insert(currentEntidad, true,currentEncargo.idencargo))
            {
                var controller = await dlg.ShowProgressAsync(this, "Registro creado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                resultadoProceso = true;
                cerradoFinalVentana = true;
                CloseWindow();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                accesibilidadWindow = true;
                Mouse.OverrideCursor = null;

            }
        }

        public async void Modificar()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            if (!((SelectedVisita == null) || (SelectedVisita.id == 0)))
            {
                currentEntidad.idvisitadp = SelectedVisita.id;
            }
            else
            {
                currentEntidad.idvisitadp = null;
            }
            if (!((SelectedTipoProcedimiento == null) || (SelectedTipoProcedimiento.id == 0)))
            {
                currentEntidad.idtprocedimientodp = SelectedTipoProcedimiento.id;
            }
            else
            {
                currentEntidad.idtprocedimientodp = null;
            }
            if (!((selectedPadreEntidad == null) || (selectedPadreEntidad.iddp == 0)))
            {
                currentEntidad.idpadredp = selectedPadreEntidad.iddp;
                currentEntidad.ordendp = ordenRegistro(selectedPadreEntidad, selectedPadreEntidad.idprogramadp);
                currentEntidad.ordendpPadre = selectedPadreEntidad.ordendp;
                //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
            }
            else
            {
                currentEntidad.ordendp = ordenRegistro(selectedPadreEntidad, currentEntidad.idprogramadp);
                //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
            }
            if (DetalleProgramaModelo.UpdateModelo(currentEntidad, currentUsuario, currentEncargo.idencargo))
            {
                var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                resultadoProceso = true;
                cerradoFinalVentana = true;

                CloseWindow();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                accesibilidadWindow = true;
                Mouse.OverrideCursor = null;
            }

        }


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
            inhabilitar.concluido = resultadoProceso;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar, tokenEnvioCierre);
        }
        public void enviarMensajeHabilitar()
        {
            //Para sub-ventana
            //Se crea el mensaje
            TabItemMensaje habilitar = new TabItemMensaje();
            habilitar.mensaje = true;
            habilitar.concluido = resultadoProceso;
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
                evaluar = (Errors == 0) &&
                         ((SelectedTipoProcedimiento.id != 0));
                return evaluar;
            }
        }

        #endregion


        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            EditarCommand = new RelayCommand(Modificar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSave);
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(Ok);
            SalirCommand = new RelayCommand(Salir);
            SelectionChangedCommand = new RelayCommand<DetalleProgramaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });

            //Permite guardar los cambios en la ejecución
            referenciarCommand = new RelayCommand(GuardarCierreEjecución, CanSave);


            cambioListaCommand = new RelayCommand<TipoProcedimientoModelo>(entidad =>
            {
                if (entidad == null) return;
                visibilidadDependencia = Visibility.Collapsed;
                listaEntidadFiltrada = new ObservableCollection<DetalleProgramaModelo>();
                currentEntidad.tipoProcedimientoModelo = entidad;
                currentEntidad.idtprocedimientodp = entidad.id;
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


        private async void GuardarCierreEjecución()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            if (fechainidpDate != new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day))
            {
                currentEntidad.fechainidp = MetodosModelo.homologacionFecha(fechainidpDate.ToString());
            }
            if (fechafindpDate != new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day))
            {
                currentEntidad.fechafindp = MetodosModelo.homologacionFecha(fechafindpDate.ToString());
            }
            if (fechasupervisionDate != new DateTime((DateTime.Now.Year), DateTime.Now.Month - 1, DateTime.Now.Day))
            {
                currentEntidad.fechasupervision = MetodosModelo.homologacionFecha(fechasupervisionDate.ToString());
            }

            if (DetalleProgramaModelo.UpdateModeloCierre(currentEntidad, currentUsuario, currentEncargo.idencargo))
            {
                var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                resultadoProceso = true;
                cerradoFinalVentana = true;

                CloseWindow();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                accesibilidadWindow = true;
                Mouse.OverrideCursor = null;
            }
        }

        //Para establecer la lista 

        #endregion


        private decimal ordenRegistro(DetalleProgramaModelo padre, int idHerramientaSeleccionada)
        {
            decimal ordenRespuesta = 0;
            if (!(padre == null))
            {
                if (!(padre.iddp == 0))
                {
                    int registros = DetalleProgramaModelo.ContarSubRegistros(padre.iddp) + 1;
                    decimal factorSuma = MetodosModelo.factorPadre(padre.nombreTipoProcedimiento);
                    if (registros == 1)
                    {
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordendp, factorSuma);
                    }
                    else
                    {
                        //decimal suma = Decimal.Add((Decimal)0.01, (decimal)0.01 * registros);
                        //currentEntidad.ordenDh = Decimal.Add((Decimal)_selectedPadreEntidad.ordenDh, suma);
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordendp, factorSuma * registros);
                    }
                }
            }
            else
            {
                ordenRespuesta = (decimal)DetalleProgramaModelo.FindOrden(idHerramientaSeleccionada);
            }
            return ordenRespuesta;
        }

        private ObservableCollection<DetalleProgramaModelo> filtradoLista(DetalleProgramaModelo entidad)
        {
            return filtradoLista(entidad.nombreTipoProcedimiento);
        }

        private ObservableCollection<DetalleProgramaModelo> filtradoLista(TipoProcedimientoModelo entidad)
        {
            return filtradoLista(entidad.descripcion);//Descripcion del tipo de procedimiento
        }

        private ObservableCollection<DetalleProgramaModelo> filtradoLista(string TipoProcedimiento)
        {
            ObservableCollection<DetalleProgramaModelo> listaFiltrada = new ObservableCollection<DetalleProgramaModelo>();
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
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-TITULO"));
                        break;
                    case "SUB-TITULO":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "TITULO"));
                        break;
                    case "SUB-SUB-INDICACIONES":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-INDICACIONES"));
                        break;
                    case "SUB-INDICACIONES":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "INDICACIONES"));
                        break;
                    case "SUB-PROCEDIMIENTO":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "PROCEDIMIENTO"));
                        break;
                    case "SUB-SUB-PROCEDIMIENTO":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-PROCEDIMIENTO"));
                        break;
                    case "SUB-PREGUNTA":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "PREGUNTA"));
                        break;
                    case "SUB-OBJETIVO":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "OBJETIVO"));
                        break;
                    case "SUB-SUB-OBJETIVO":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-OBJETIVO"));
                        break;
                    case "SUB-ALCANCE":
                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "ALCANCE"));
                        break;
                    case "SUB-SUB-ALCANCE":

                        listaFiltrada = new ObservableCollection<DetalleProgramaModelo>(listaEntidad.Where(x => x.nombreTipoProcedimiento.ToUpper() == "SUB-ALCANCE"));
                        break;
                }
                if (listaFiltrada.Count > 0)
                {
                    foreach (DetalleProgramaModelo item in listaFiltrada)
                    {
                        item.descripciondp = item.ordendp + "-" + item.descripciondp;
                    }
                }
                return listaFiltrada;
            }
        }
    }
}
