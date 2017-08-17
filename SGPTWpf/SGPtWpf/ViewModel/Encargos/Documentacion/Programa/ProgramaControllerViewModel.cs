using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.SGPtWpf.Model.Menus.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Linq;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Model.Modelo.detalleherramientas;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Messages.Encargos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.ViewModel;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa
{
    public sealed class ProgramaControllerViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        #region tokenHabilitarVentanaPadreRecepcion

        private string _tokenHabilitarVentanaPadreRecepcion;
        private string tokenHabilitarVentanaPadreRecepcion
        {
            get { return _tokenHabilitarVentanaPadreRecepcion; }
            set { _tokenHabilitarVentanaPadreRecepcion = value; }
        }

        #endregion

        #region tokenEnvioController

        private string _tokenEnvioController;
        private string tokenEnvioController
        {
            get { return _tokenEnvioController; }
            set { _tokenEnvioController = value; }
        }

        #endregion

        #region tokenEnvioControllerDetalle

        private string _tokenEnvioControllerDetalle;
        private string tokenEnvioControllerDetalle
        {
            get { return _tokenEnvioControllerDetalle; }
            set { _tokenEnvioControllerDetalle = value; }
        }

        #endregion

        #region tokenRecepcionVista

        private string _tokenRecepcionVista;
        private string tokenRecepcionVista
        {
            get { return _tokenRecepcionVista; }
            set { _tokenRecepcionVista = value; }
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

        #region detalle //Para lanzamiento  de Frame

        private MenuEncargoProgramas _detalle;
        private MenuEncargoProgramas detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }

        #endregion

        public static int Errors { get; set; }

        //#region detalle //Para lanzamiento  de Frame

        //private MenuEncargoCuestionario _detalle;
        //private MenuEncargoCuestionario detalle
        //{
        //    get { return _detalle; }
        //    set { _detalle = value; }
        //}

        //#endregion

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

        #region Usuario validado

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

        #region maxnombreprograma

        private int _maxnombreprograma;
        private int maxnombreprograma
        {
            get { return _maxnombreprograma; }
            set { _maxnombreprograma = value; }
        }

        #endregion

        #region tokenRecepcionProgramas

        private string _tokenRecepcionProgramas;
        private string tokenRecepcionProgramas
        {
            get { return _tokenRecepcionProgramas; }
            set { _tokenRecepcionProgramas = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        #region opcionMenu

        private int _opcionMenu;
        private int opcionMenu
        {
            get { return _opcionMenu; }
            set { _opcionMenu = value; }
        }

        #endregion

        #endregion

        #region Lista de entidades

        #region ViewModel Properties : ListaEntidad Programa

        public const string listaEntidadPropertyName = "ListaEntidad";

        private ObservableCollection<ProgramaModelo> _ListaEntidad;

        public ObservableCollection<ProgramaModelo> ListaEntidad
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

        #region ViewModel Properties : listaProgramaModelo Programa

        public const string listaProgramaModeloPropertyName = "listaProgramaModelo";

        private ObservableCollection<ProgramaModelo> _listaProgramaModelo;

        public ObservableCollection<ProgramaModelo> listaProgramaModelo
        {
            get
            {
                return _listaProgramaModelo;
            }
            set
            {
                if (_listaProgramaModelo == value) return;

                _listaProgramaModelo = value;

                RaisePropertyChanged(listaProgramaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties :  Programa Por Encargo

        public const string listaProgramaByEncargoPropertyName = "listaProgramaByEncargo";

        private ObservableCollection<ProgramaModelo> _listaProgramaByEncargo;

        public ObservableCollection<ProgramaModelo> listaProgramaByEncargo
        {
            get
            {
                return _listaProgramaByEncargo;
            }
            set
            {
                if (_listaProgramaByEncargo == value) return;

                _listaProgramaByEncargo = value;

                RaisePropertyChanged(listaProgramaByEncargoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDetallePrograma

        public const string listaDetalleProgramaPropertyName = "listaDetallePrograma";

        private ObservableCollection<DetalleProgramaModelo> _listaDetallePrograma;

        public ObservableCollection<DetalleProgramaModelo> listaDetallePrograma
        {
            get
            {
                return _listaDetallePrograma;
            }
            set
            {
                if (_listaDetallePrograma == value) return;

                _listaDetallePrograma = value;
                RaisePropertyChanged(listaDetalleProgramaPropertyName);
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

        #region ViewModel Properties : listaTipoPrograma

        public const string listaTipoProgramaPropertyName = "listaTipoPrograma";

        private ObservableCollection<TipoProgramaModelo> _listaTipoPrograma;

        public ObservableCollection<TipoProgramaModelo> listaTipoPrograma
        {
            get
            {
                return _listaTipoPrograma;
            }
            set
            {
                if (_listaTipoPrograma == value) return;

                _listaTipoPrograma = value;

                RaisePropertyChanged(listaTipoProgramaPropertyName);
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

        #region ViewModel Properties : listadoBitacoraVista

        public const string listadoBitacoraVistaPropertyName = "listadoBitacoraVista";

        private ObservableCollection<UsuarioProgramaAccionModelo> _listadoBitacoraVista;

        public ObservableCollection<UsuarioProgramaAccionModelo> listadoBitacoraVista
        {
            get
            {
                return _listadoBitacoraVista;
            }
            set
            {
                if (_listadoBitacoraVista == value) return;

                _listadoBitacoraVista = value;

                RaisePropertyChanged(listadoBitacoraVistaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaPlantillas

        public const string listaPlantillasPropertyName = "listaPlantillas";

        private ObservableCollection<HerramientasModelo> _listaPlantillas;

        public ObservableCollection<HerramientasModelo> listaPlantillas
        {
            get
            {
                return _listaPlantillas;
            }

            set
            {
                if (_listaPlantillas == value) return;

                _listaPlantillas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPlantillasPropertyName);
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

        #region ViewModel Property : currentEntidadPrograma Programa Modelo

        public const string currentEntidadProgramaPropertyName = "currentEntidadPrograma";

        private ProgramaModelo _currentEntidadPrograma;

        public ProgramaModelo currentEntidadPrograma
        {
            get
            {
                return _currentEntidadPrograma;
            }

            set
            {
                if (_currentEntidadPrograma == value) return;

                _currentEntidadPrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidadProgramaDetalle Programa Modelo

        public const string currentEntidadProgramaDetallePropertyName = "currentEntidadProgramaDetalle";

        private DetalleProgramaModelo _currentEntidadProgramaDetalle;

        public DetalleProgramaModelo currentEntidadProgramaDetalle
        {
            get
            {
                return _currentEntidadProgramaDetalle;
            }

            set
            {
                if (_currentEntidadProgramaDetalle == value) return;

                _currentEntidadProgramaDetalle = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadProgramaDetallePropertyName);
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

        #region idindiceprograma

        public const string idindiceprogramaPropertyName = "idindiceprograma";

        private int _idindiceprograma = 0;

        public int idindiceprograma
        {
            get
            {
                return _idindiceprograma;
            }

            set
            {
                if (_idindiceprograma == value)
                {
                    return;
                }

                _idindiceprograma = value;
                RaisePropertyChanged(idindiceprogramaPropertyName);
            }
        }

        #endregion

        #region idcedulaprograma

        public const string idcedulaprogramaPropertyName = "idcedulaprograma";

        private int _idcedulaprograma = 0;

        public int idcedulaprograma
        {
            get
            {
                return _idcedulaprograma;
            }

            set
            {
                if (_idcedulaprograma == value)
                {
                    return;
                }

                _idcedulaprograma = value;
                RaisePropertyChanged(idcedulaprogramaPropertyName);
            }
        }

        #endregion

        #region idpapelesprograma

        public const string idpapelesprogramaPropertyName = "idpapelesprograma";

        private int _idpapelesprograma = 0;

        public int idpapelesprograma
        {
            get
            {
                return _idpapelesprograma;
            }

            set
            {
                if (_idpapelesprograma == value)
                {
                    return;
                }

                _idpapelesprograma = value;
                RaisePropertyChanged(idpapelesprogramaPropertyName);
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

        #region horasplanprograma

        public const string horasplanprogramaPropertyName = "horasplanprograma";

        private decimal _horasplanprograma = 0;

        public decimal horasplanprograma
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
                if (_horasplanprograma > 0)
                {
                    currentEntidadPrograma.horasplanprograma = _horasplanprograma;
                }
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

        #region etapaprograma

        public const string etapaprogramaPropertyName = "etapaprograma";

        private string _etapaprograma = string.Empty;

        public string etapaprograma
        {
            get
            {
                return _etapaprograma;
            }

            set
            {
                if (_etapaprograma == value)
                {
                    return;
                }

                _etapaprograma = value;
                RaisePropertyChanged(etapaprogramaPropertyName);
            }
        }

        #endregion

        #region horasejecucionprograma

        public const string horasejecucionprogramaPropertyName = "horasejecucionprograma";

        private decimal _horasejecucionprograma = 0;

        public decimal horasejecucionprograma
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
                if (_horasejecucionprograma > 0)
                {
                    currentEntidadPrograma.horasejecucionprograma = _horasejecucionprograma;
                }
            }
        }

        #endregion

        #region idencargoprograma

        public const string idencargoprogramaPropertyName = "idencargoprograma";

        private int _idencargoprograma = 0;

        public int idencargoprograma
        {
            get
            {
                return _idencargoprograma;
            }

            set
            {
                if (_idencargoprograma == value)
                {
                    return;
                }

                _idencargoprograma = value;
                RaisePropertyChanged(idencargoprogramaPropertyName);
            }
        }

        #endregion

        #region idTpNombre

        public const string idTpNombrePropertyName = "idTpNombre";

        private string _idTpNombre = string.Empty;

        public string idTpNombre
        {
            get
            {
                return _idTpNombre;
            }

            set
            {
                if (_idTpNombre == value)
                {
                    return;
                }

                _idTpNombre = value;
                RaisePropertyChanged(idTpNombrePropertyName);
            }
        }

        #endregion

        #region TipoProgramaModeloPrograma

        public const string tipoProgramaModeloProgramaPropertyName = "tipoProgramaModeloPrograma";

        private TipoProgramaModelo _tipoProgramaModeloPrograma;

        public TipoProgramaModelo tipoProgramaModeloPrograma
        {
            get
            {
                return _tipoProgramaModeloPrograma;
            }

            set
            {
                if (_tipoProgramaModeloPrograma == value) return;

                _tipoProgramaModeloPrograma = value;
                RaisePropertyChanged(tipoProgramaModeloProgramaPropertyName);
                //Asignación del tipo de programa
                currentEntidadPrograma.idtpprograma = _tipoProgramaModeloPrograma.id;
            }
        }

        #endregion

        #region TipoHerramientaModeloPrograma

        public const string tipoHerramientaModeloProgramaPropertyName = "tipoHerramientaModeloPrograma";

        private TipoHerramientaModelo _tipoHerramientaModeloPrograma;

        public TipoHerramientaModelo tipoHerramientaModeloPrograma
        {
            get
            {
                return _tipoHerramientaModeloPrograma;
            }

            set
            {
                if (_tipoHerramientaModeloPrograma == value) return;

                _tipoHerramientaModeloPrograma = value;
                RaisePropertyChanged(tipoHerramientaModeloProgramaPropertyName);
                //Asignación del tipo de programa
                currentEntidadPrograma.idthprograma = _tipoHerramientaModeloPrograma.id;
            }
        }

        #endregion

        #region encargoModeloPrograma

        public const string encargoModeloProgramaPropertyName = "encargoModeloPrograma";

        private EncargoModelo _encargoModeloPrograma;

        public EncargoModelo encargoModeloPrograma
        {
            get
            {
                return _encargoModeloPrograma;
            }

            set
            {
                if (_encargoModeloPrograma == value) return;

                _encargoModeloPrograma = value;
                RaisePropertyChanged(encargoModeloProgramaPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _encargoModeloPrograma.id;
            }
        }

        #endregion

        #region indiceModeloPrograma

        public const string indiceModeloProgramaPropertyName = "indiceModeloPrograma";

        private IndiceModelo _indiceModeloPrograma;

        public IndiceModelo indiceModeloPrograma
        {
            get
            {
                return _indiceModeloPrograma;
            }

            set
            {
                if (_indiceModeloPrograma == value) return;

                _indiceModeloPrograma = value;
                RaisePropertyChanged(indiceModeloProgramaPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _indiceModeloPrograma.id;
            }
        }

        #endregion

        #region etapaEncargoModeloPrograma

        public const string etapaEncargoModeloProgramaPropertyName = "etapaEncargoModeloPrograma";

        private EtapaEncargoModelo _etapaEncargoModeloPrograma;

        public EtapaEncargoModelo etapaEncargoModeloPrograma
        {
            get
            {
                return _etapaEncargoModeloPrograma;
            }

            set
            {
                if (_etapaEncargoModeloPrograma == value) return;

                _etapaEncargoModeloPrograma = value;
                RaisePropertyChanged(etapaEncargoModeloProgramaPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _etapaEncargoModeloPrograma.id;
            }
        }

        #endregion

        #region usuarioProgramaAccionModelo

        public const string usuarioProgramaAccionModeloPropertyName = "usuarioProgramaAccionModelo";

        private UsuarioProgramaAccionModelo _usuarioProgramaAccionModelo;

        public UsuarioProgramaAccionModelo usuarioProgramaAccionModelo
        {
            get
            {
                return _usuarioProgramaAccionModelo;
            }

            set
            {
                if (_usuarioProgramaAccionModelo == value) return;

                _usuarioProgramaAccionModelo = value;
                RaisePropertyChanged(usuarioProgramaAccionModeloPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _usuarioProgramaAccionModelo.id;
            }
        }

        #endregion

        #region usuarioModeloPrograma

        public const string usuarioModeloProgramaPropertyName = "usuarioModeloPrograma";

        private UsuarioModelo _usuarioModeloPrograma;

        public UsuarioModelo usuarioModeloPrograma
        {
            get
            {
                return _usuarioModeloPrograma;
            }

            set
            {
                if (_usuarioModeloPrograma == value) return;

                _usuarioModeloPrograma = value;
                RaisePropertyChanged(usuarioModeloProgramaPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _usuarioModeloPrograma.id;
            }
        }

        #endregion

        #region usuarioModifico

        public const string usuarioModificoPropertyName = "usuarioModifico";

        private string _usuarioModifico = string.Empty;

        public string usuarioModifico
        {
            get
            {
                return _usuarioModifico;
            }

            set
            {
                if (_usuarioModifico == value)
                {
                    return;
                }

                _usuarioModifico = value;
                RaisePropertyChanged(usuarioModificoPropertyName);
            }
        }

        #endregion

        #region fechacierre

        public const string fechacierrePropertyName = "fechacierre";

        private DateTime _fechacierre;

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

        private DateTime _fechasupervision;

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

        private DateTime _fechaaprobacion;

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

        #region Detalle programa

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

        #region idprogramadp

        public const string idprogramadpPropertyName = "idprogramadp";

        private int _idprogramadp = 0;

        public int idprogramadp
        {
            get
            {
                return _idprogramadp;
            }

            set
            {
                if (_idprogramadp == value)
                {
                    return;
                }

                _idprogramadp = value;
                RaisePropertyChanged(idprogramadpPropertyName);
            }
        }

        #endregion

        #region idpapelesdp

        public const string idpapelesdpPropertyName = "idpapelesdp";

        private int _idpapelesdp = 0;

        public int idpapelesdp
        {
            get
            {
                return _idpapelesdp;
            }

            set
            {
                if (_idpapelesdp == value)
                {
                    return;
                }

                _idpapelesdp = value;
                RaisePropertyChanged(idpapelesdpPropertyName);
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
                // currentEntidadProgramaDetalle.descripciondp = value;
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

        #region fechainidp

        public const string fechainidpPropertyName = "fechainidp";

        private DateTime _fechainidp = DateTime.Now;

        public DateTime fechainidp
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

        private DateTime _fechafindp = DateTime.Now;

        public DateTime fechafindp
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

        #region horaejecdp

        public const string horaejecdpPropertyName = "horaejecdp";

        private decimal _horaejecdp = 0;

        public decimal horaejecdp
        {
            get
            {
                return _horaejecdp;
            }

            set
            {
                if (_horaejecdp == value)
                {
                    return;
                }

                _horaejecdp = value;
                RaisePropertyChanged(horaejecdpPropertyName);
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

        #region comentariodp

        public const string comentariodpPropertyName = "comentariodp";

        private string _comentariodp = string.Empty;

        public string comentariodp
        {
            get
            {
                return _comentariodp;
            }

            set
            {
                if (_comentariodp == value)
                {
                    return;
                }

                _comentariodp = value;
                RaisePropertyChanged(comentariodpPropertyName);
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
            }
        }

        #endregion


        #region ordendpPresentacion

        public const string ordendpPresentacionPropertyName = "ordendpPresentacion";

        private decimal _ordendpPresentacion = 0;

        public decimal ordendpPresentacion
        {
            get
            {
                return _ordendpPresentacion;
            }

            set
            {
                if (_ordendpPresentacion == value)
                {
                    return;
                }

                _ordendpPresentacion = value;
                RaisePropertyChanged(ordendpPresentacionPropertyName);
            }
        }

        #endregion

        #region ordendpPadre

        public const string ordendpPadrePropertyName = "ordendpPadre";

        private decimal _ordendpPadre = 0;

        public decimal ordendpPadre
        {
            get
            {
                return _ordendpPadre;
            }

            set
            {
                if (_ordendpPadre == value)
                {
                    return;
                }

                _ordendpPadre = value;
                RaisePropertyChanged(ordendpPadrePropertyName);
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
                // currentEntidadProgramaDetalle.nombreVisita = value;
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
                // currentEntidadProgramaDetalle.nombreTipoProcedimiento = value;
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
                // currentEntidadProgramaDetalle.nombreDetallePadre = value;
            }
        }

        #endregion

        #region guardadoBase

        public const string guardadoBasePropertyName = "guardadoBase";

        private bool _guardadoBase = false;

        public bool guardadoBase
        {
            get
            {
                return _guardadoBase;
            }

            set
            {
                if (_guardadoBase == value)
                {
                    return;
                }

                _guardadoBase = value;
                RaisePropertyChanged(guardadoBasePropertyName);
                // currentEntidadProgramaDetalle.guardadoBase = value;
            }
        }

        #endregion

        #region usuarioProgramaAccionModeloDp

        public const string usuarioProgramaAccionModeloDpPropertyName = "usuarioProgramaAccionModeloDp";

        private UsuarioProgramaAccionModelo _usuarioProgramaAccionModeloDp;

        public UsuarioProgramaAccionModelo usuarioProgramaAccionModeloDp
        {
            get
            {
                return _usuarioProgramaAccionModeloDp;
            }

            set
            {
                if (_usuarioProgramaAccionModeloDp == value) return;

                _usuarioProgramaAccionModeloDp = value;
                RaisePropertyChanged(usuarioProgramaAccionModeloDpPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _usuarioProgramaAccionModeloDp.id;
            }
        }

        #endregion

        #region usuarioModeloDp

        public const string usuarioModeloDpPropertyName = "usuarioModeloDp";

        private UsuarioModelo _usuarioModeloDp;

        public UsuarioModelo usuarioModeloDp
        {
            get
            {
                return _usuarioModeloDp;
            }

            set
            {
                if (_usuarioModeloDp == value) return;

                _usuarioModeloDp = value;
                RaisePropertyChanged(usuarioModeloDpPropertyName);
                //Asignación del tipo de programa
                //currentEntidadPrograma.idthprograma = _usuarioModeloDp.id;
            }
        }

        #endregion

        #region usuarioModificoDp

        public const string usuarioModificoDpPropertyName = "usuarioModificoDp";

        private string _usuarioModificoDp = string.Empty;

        public string usuarioModificoDp
        {
            get
            {
                return _usuarioModificoDp;
            }

            set
            {
                if (_usuarioModificoDp == value)
                {
                    return;
                }

                _usuarioModificoDp = value;
                RaisePropertyChanged(usuarioModificoDpPropertyName);
            }
        }

        #endregion

        #region fechaUltimaModificacionProgramaDp

        public const string fechaUltimaModificacionProgramaDpPropertyName = "fechaUltimaModificacionProgramaDp";

        private string _fechaUltimaModificacionProgramaDp = string.Empty;

        public string fechaUltimaModificacionProgramaDp
        {
            get
            {
                return _fechaUltimaModificacionProgramaDp;
            }

            set
            {
                if (_fechaUltimaModificacionProgramaDp == value)
                {
                    return;
                }

                _fechaUltimaModificacionProgramaDp = value;
                RaisePropertyChanged(fechaUltimaModificacionProgramaDpPropertyName);
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

        #region ViewModel Property : SelectedTipoProgramaModelo

        public const string SelectedTipoProgramaModeloPropertyName = "SelectedTipoProgramaModelo";

        private TipoProgramaModelo _SelectedTipoProgramaModelo;

        public TipoProgramaModelo SelectedTipoProgramaModelo
        {
            get
            {
                return _SelectedTipoProgramaModelo;
            }

            set
            {
                if (_SelectedTipoProgramaModelo == value) return;

                _SelectedTipoProgramaModelo = value;
                RaisePropertyChanged(SelectedTipoProgramaModeloPropertyName);
                //Asignación del tipo de programa
                currentEntidadPrograma.idtpprograma = _SelectedTipoProgramaModelo.id;
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
                currentEntidadPrograma.idthprograma = _SelectedTipoHerramientaModelo.id;
            }
        }

        #endregion

        #region ViewModel Property : currentEntidadPlantilla

        public const string currentEntidadPlantillaPropertyName = "currentEntidadPlantilla";

        private HerramientasModelo _currentEntidadPlantilla;

        public HerramientasModelo currentEntidadPlantilla
        {
            get
            {
                return _currentEntidadPlantilla;
            }

            set
            {
                if (_currentEntidadPlantilla == value) return;

                _currentEntidadPlantilla = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPlantillaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentBitacora

        public const string currentBitacoraPropertyName = "currentBitacora";

        private UsuarioProgramaAccionModelo _currentBitacora;

        public UsuarioProgramaAccionModelo currentBitacora
        {
            get
            {
                return _currentBitacora;
            }

            set
            {
                if (_currentBitacora == value) return;

                _currentBitacora = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentBitacoraPropertyName);
            }
        }

        #endregion

        #endregion


        #endregion

        #region Propiedades de  Plantillas

        #region seleccionHerramienta

        public const string seleccionHerramientaPropertyName = "seleccionHerramienta";

        private bool _seleccionHerramienta = false;

        public bool seleccionHerramienta
        {
            get
            {
                return _seleccionHerramienta;
            }

            set
            {
                if (_seleccionHerramienta == value)
                {
                    return;
                }

                _seleccionHerramienta = value;
                RaisePropertyChanged(seleccionHerramientaPropertyName);
                // currentEntidadProgramaDetalle.seleccionHerramienta = value;
            }
        }

        #endregion

        #endregion

        #region Propiedades de ventanas

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

        #region tipoProgramaCuestionario

        public const string tipoProgramaCuestionarioPropertyName = "tipoProgramaCuestionario";

        private string _tipoProgramaCuestionario = string.Empty;

        public string tipoProgramaCuestionario
        {
            get
            {
                return _tipoProgramaCuestionario;
            }

            set
            {
                if (_tipoProgramaCuestionario == value)
                {
                    return;
                }

                _tipoProgramaCuestionario = value;
                RaisePropertyChanged(tipoProgramaCuestionarioPropertyName);
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


        #region visibilidadPrograma

        public const string visibilidadProgramaPropertyName = "visibilidadPrograma";

        private Visibility _visibilidadPrograma = Visibility.Collapsed;

        public Visibility visibilidadPrograma
        {
            get
            {
                return _visibilidadPrograma;
            }

            set
            {
                if (_visibilidadPrograma == value)
                {
                    return;
                }

                _visibilidadPrograma = value;
                RaisePropertyChanged(visibilidadProgramaPropertyName);
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


        #region visibilidadCreacion

        public const string visibilidadCreacionPropertyName = "visibilidadCreacion";

        private Visibility _visibilidadCreacion = Visibility.Collapsed;

        public Visibility visibilidadCreacion
        {
            get
            {
                return _visibilidadCreacion;
            }

            set
            {
                if (_visibilidadCreacion == value)
                {
                    return;
                }

                _visibilidadCreacion = value;
                RaisePropertyChanged(visibilidadCreacionPropertyName);
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

        #region visibilidadObjetivo

        public const string visibilidadObjetivoPropertyName = "visibilidadObjetivo";

        private Visibility _visibilidadObjetivo = Visibility.Collapsed;

        public Visibility visibilidadObjetivo
        {
            get
            {
                return _visibilidadObjetivo;
            }

            set
            {
                if (_visibilidadObjetivo == value)
                {
                    return;
                }

                _visibilidadObjetivo = value;
                RaisePropertyChanged(visibilidadObjetivoPropertyName);
            }
        }

        #endregion

        #region visibilidadReferencia

        public const string visibilidadReferenciaPropertyName = "visibilidadReferencia";

        private Visibility _visibilidadReferencia = Visibility.Collapsed;

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
        public RelayCommand<ProgramaModelo> SelectionChangedCommand { get; set; }
        public RelayCommand mouseClickCommand { get; set; }

        public RelayCommand<UsuarioProgramaAccionModelo> SelectionBitacoraChangedCommand { get; set; }
        public RelayCommand<HerramientasModelo> SelectionChangedPlantillaCommand { get; set; }
        public RelayCommand CopiarCommand { get; set; }

        public RelayCommand CancelarProgramaEncargoCommand { get; set; }//Seleccion desde el encargo
        public RelayCommand SeleccionProgramaEncargoCommand { get; set; }//seleccion desde el encargo

        public RelayCommand CancelarPlantillaCommand { get; set; }//Seleccion desde las plantillas
        public RelayCommand SeleccionPlantillaCommand { get; set; }//seleccion desde las plantillas
        public RelayCommand referenciarCommand { get; set; }//seleccion desde las plantillas

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores


        public ProgramaControllerViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenEnvioController = "datosController";
            _tokenEnvioControllerDetalle = "datosProgramaDetalle";
            _tokenRecepcionVista = "listaDetalleProgramaVista";
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            _detalle = new MenuEncargoProgramas();//Es generico el view display es cualquier string
            _maxnombreprograma = 500;
            _opcionMenu = 0;
            Errors = 0;
            _tokenRecepcionProgramas = "datosEncargosPrograma";
            _accesibilidadWindow = true;
            _accesibilidadCuerpo = true;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadCreacion = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadReferencia = Visibility.Collapsed;
            _visibilidadObjetivo = Visibility.Visible;
            _visibilidadCmdReferenciar = Visibility.Collapsed;

            _tokenHabilitarVentanaPadreRecepcion = "HabilitarVentanaPadreEncargoPlanEdicion";
            //Suscribiendo el mensaje
            _listaProgramaModelo = new ObservableCollection<ProgramaModelo>();
            _listaTipoPrograma = new ObservableCollection<TipoProgramaModelo>(TipoProgramaModelo.GetAll());
            _listaTipoHerramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
            _listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>();
            _listadoBitacoraVista = new ObservableCollection<UsuarioProgramaAccionModelo>();

            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionProgramas, (programaDatosMsj) => ControlProgramaDatosMsj(programaDatosMsj));
            Messenger.Default.Register<EncargosPlanProgramasDetalleListaMsj>(this, tokenRecepcionVista, (encargosPlanProgramasDetalleListaMsj) => ControlEncargosPlanProgramasDetalleListaMsj(encargosPlanProgramasDetalleListaMsj));
            Messenger.Default.Register<bool>(this, tokenHabilitarVentanaPadreRecepcion, (encargosPlanProgramasVentanaMsj) => ControlencargosPlanProgramasVentanaMsj(encargosPlanProgramasVentanaMsj));

            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            enviarMensajeInhabilitar();
            _currentEncargo = new EncargoModelo();
            _currentBitacora = new UsuarioProgramaAccionModelo();

        }

        public ProgramaControllerViewModel(string origen)
        {
            _origenLlamada = origen;
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _resultadoProceso = 0;
            _tokenEnvioController = "datosControllerProgramaDocumentacion";//Modificado
            _tokenEnvioControllerDetalle = "datosProgramaDetalleDocumentacion";//Modificado
            _tokenRecepcionVista = "listaDetalleProgramaVistaDocumentacion";
            _fuenteCierre = 0;
            _detalle =new MenuEncargoProgramas();//Es generico el view display es cualquier string
            _maxnombreprograma = 500;
            _opcionMenu = 0;
            Errors = 0;
            _tokenRecepcionProgramas = "datosEncargosProgramaDocumentacion";//Modificado
            _accesibilidadWindow = true;
            _accesibilidadCuerpo = true;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadCreacion = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadReferencia = Visibility.Collapsed;
            _visibilidadObjetivo = Visibility.Visible;
            _visibilidadCmdReferenciar = Visibility.Collapsed;
            _tokenHabilitarVentanaPadreRecepcion = "HabilitarVentanaPadreEncargoPlanEdicionProgramaDocumentacion";
            //Suscribiendo el mensaje
            _listaProgramaModelo = new ObservableCollection<ProgramaModelo>();
            _listaTipoPrograma = new ObservableCollection<TipoProgramaModelo>(TipoProgramaModelo.GetAll());
            _listaTipoHerramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
            _listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>();
            _listadoBitacoraVista = new ObservableCollection<UsuarioProgramaAccionModelo>();
            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionProgramas, (programaDatosMsj) => ControlProgramaDatosMsj(programaDatosMsj));
            Messenger.Default.Register<EncargosPlanProgramasDetalleListaMsj>(this, tokenRecepcionVista, (encargosPlanProgramasDetalleListaMsj) => ControlEncargosPlanProgramasDetalleListaMsj(encargosPlanProgramasDetalleListaMsj));
            Messenger.Default.Register<bool>(this, tokenHabilitarVentanaPadreRecepcion, (encargosPlanProgramasVentanaMsj) => ControlencargosPlanProgramasVentanaMsj(encargosPlanProgramasVentanaMsj));

            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            enviarMensajeInhabilitar();
            _currentEncargo = new EncargoModelo();
        }

        private void ControlencargosPlanProgramasVentanaMsj(bool encargosPlanProgramasVentanaMsj)
        {
            accesibilidadWindow = encargosPlanProgramasVentanaMsj;
            //Controla la habilitacion de la  ventana padre al hacer crud de sub-ventana
        }

        public ProgramaControllerViewModel(int comando)
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _resultadoProceso = 0;
            _tokenEnvioController = "datosControllerPrograma";//Modificado
            _tokenEnvioControllerDetalle = "datosProgramaDetalle";
            _tokenRecepcionVista = "listaDetalleProgramaVista";
            _tokenHabilitarVentanaPadreRecepcion = "HabilitarVentanaPadreEncargoPlanEdicionPrograma";
            _fuenteCierre = 0;
            Errors = 0;
            _detalle = new MenuEncargoProgramas();//Es generico el view display es cualquier string
            _maxnombreprograma = 500;
            _opcionMenu = 0;
            _tokenRecepcionProgramas = "datosEncargosPrograma";//Modificado
            _accesibilidadWindow = true;
            _accesibilidadCuerpo = true;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadCreacion = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            if (comando == 6)
            {
                visibilidadCrear = Visibility.Visible;
                visibilidadCreacion = Visibility.Visible;
                visibilidadCopiar = Visibility.Collapsed;
            }
            else
            {
                if (comando == 7)
                {
                    visibilidadCreacion = Visibility.Collapsed;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadCopiar = Visibility.Visible;
                }
                else
                {
                    visibilidadCreacion = Visibility.Visible;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadCopiar = Visibility.Visible;
                }
            }

            //Suscribiendo el mensaje
            _listaProgramaModelo = new ObservableCollection<ProgramaModelo>();
            _listaProgramaByEncargo = new ObservableCollection<ProgramaModelo>();
            _listaTipoPrograma = new ObservableCollection<TipoProgramaModelo>(TipoProgramaModelo.GetAll());
            _listaTipoHerramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
            _listaDetallePrograma = new ObservableCollection<DetalleProgramaModelo>();
            Messenger.Default.Register<EncargosPlanProgramasDetalleListaMsj>(this, tokenRecepcionVista, (encargosPlanProgramasDetalleListaMsj) => ControlEncargosPlanProgramasDetalleListaMsj(encargosPlanProgramasDetalleListaMsj));

            Messenger.Default.Register<ProgramaDatosMsj>(this, tokenRecepcionProgramas, (programaDatosMsj) => ControlProgramaDatosMsj(programaDatosMsj));

            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            enviarMensajeInhabilitar();

            #region Importacion

            listaPlantillas = new ObservableCollection<HerramientasModelo>();
            currentEntidadPlantilla = null;
            _currentEncargo = new EncargoModelo();
            #endregion
        }

        private void ControlEncargosPlanProgramasDetalleListaMsj(EncargosPlanProgramasDetalleListaMsj DetalleListaMensaje)
        {   //Permite manejar cambios en la lista realizados por drag and drop
            listaDetallePrograma = DetalleListaMensaje.listaElementos;
            //Messenger.Default.Unregister<EncargosPlanProgramasDetalleListaMsj>(this, tokenRecepcionVista);
        }

        private async void ControlProgramaDatosMsj(ProgramaDatosMsj programaDatosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = programaDatosMsj.encargoModelo;
            currentUsuario = programaDatosMsj.usuarioModelo;
            currentEntidadPrograma = programaDatosMsj.programaModelo;
            currentEntidadProgramaDetalle = programaDatosMsj.detallePrograma;
            //currentEntidadProgramaDetalle = programaDatosMsj.detallePrograma;
            opcionMenu = programaDatosMsj.opcionMenuCrud;
            #region conversion  de fechas
            //fechainiperauditencargo = currentEntidadEncargo.fechainiperauditencargo;

            if (!(string.IsNullOrEmpty(currentEntidadPrograma.fechacierre) || currentEntidadPrograma.fechacierre == null))
            {
                try
                {
                    fechacierre = MetodosModelo.convertirFecha(currentEntidadPrograma.fechacierre);
                }
                catch (Exception)
                {
                    this.except1();
                    //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de ejecución del programa", "");
                    //MensajesError("No se pudo convertir la fecha de fin de la auditoria", "");
                    //fechainiperauditencargo = new DateTime((DateTime.Now.Year - 1), 1, 1);
                }
            }

            if (!(string.IsNullOrEmpty(currentEntidadPrograma.fechasupervision) || currentEntidadPrograma.fechasupervision == null))
            {
                try
                {
                    fechasupervision = MetodosModelo.convertirFecha(currentEntidadPrograma.fechasupervision);
                }
                catch (Exception)
                {
                    this.except3();
                    //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de supervision del programa", "");
                    //MensajesError("No se pudo convertir la fecha de fin de la auditoria", "");
                    //fechainiperauditencargo = new DateTime((DateTime.Now.Year - 1), 1, 1);
                }
            }

            if (!(string.IsNullOrEmpty(currentEntidadPrograma.fechaaprobacion) || currentEntidadPrograma.fechaaprobacion == null))
            {
                try
                {
                    fechaaprobacion = MetodosModelo.convertirFecha(currentEntidadPrograma.fechaaprobacion);
                }
                catch (Exception)
                {
                    this.except2();
                    //await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de aprobacion del programa", "");
                    //MensajesError("No se pudo convertir la fecha de fin de la auditoria", "");
                    //fechainiperauditencargo = new DateTime((DateTime.Now.Year - 1), 1, 1);
                }
            }

            #endregion
            switch (programaDatosMsj.opcionMenuCrud)
            {
                case 1://Crear 
                       //Seleccion de programa
                       //listaProgramaModelo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(currentEntidadPrograma.idthprograma, currentEncargo));
                    listaProgramaModelo = programaDatosMsj.listaProgramaModelo;
                    currentEntidadPrograma.tipoHerramientaModeloPrograma = listaTipoHerramienta[1]; //Es un programa
                    currentEntidadPrograma.idthprograma = programaDatosMsj.programaModelo.idthprograma;
                    currentEntidadPrograma.listadoProgramaModelo = listaProgramaModelo;
                    SelectedTipoHerramientaModelo = listaTipoHerramienta[1];//Es un programa
                    encabezadoPantalla = "Introduzca los datos para el programa";
                    nombreprogramaVista = "Ingrese el nombre del programa";
                    tipoProgramaCuestionario = "Tipo de programa";
                    visibilidadHoras = Visibility.Collapsed;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadCreacion = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    visibilidadHoras = Visibility.Visible;
                    //Propiedades de presentacion
                    activarCaptura = true;
                    visibilidadPrograma = Visibility.Visible;
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    SelectedTipoProgramaModelo = currentEntidadPrograma.tipoProgramaModeloPrograma;
                    tipoProgramaModeloPrograma = currentEntidadPrograma.tipoProgramaModeloPrograma;
                    descripcion = currentEntidadPrograma.tipoProgramaModeloPrograma.descripcion;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    break;
                case 2://Editar

                    listaProgramaModelo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(currentEntidadPrograma.idthprograma, currentEncargo));

                    currentEntidadPrograma.listadoProgramaModelo = new ObservableCollection<ProgramaModelo>(listaProgramaModelo.Where(x => x.idprograma != currentEntidadPrograma.idprograma));

                    //currentEntidadPrograma.listadoProgramaModelo = listaProgramaModelo;

                    detalle.NavigateExecute();//Es un programa

                    SelectedTipoProgramaModelo = listaTipoPrograma.Single(i => i.id == currentEntidadPrograma.idtpprograma);
                    SelectedTipoHerramientaModelo = listaTipoHerramienta.Single(j => j.id == currentEntidadPrograma.idthprograma);


                    //Enviar datos al detalle
                    enviarDetalleProgramaMsj();
                    //Enviar el elemento para recuperar el detalle
                    visibilidadPrograma = Visibility.Visible;
                    encabezadoPantalla = "Actualice los datos";
                    activarCaptura = true;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadCreacion = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;

                    activarCrear = false;
                    activarConsultar = false;
                    activarEditar = true;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = true;
                    break;
                case 3://Consultar
                    listaProgramaModelo = programaDatosMsj.listaProgramaModelo;
                    detalle.NavigateExecute();//Es un programa
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = false;
                    SelectedTipoProgramaModelo = listaTipoPrograma.Single(i => i.id == currentEntidadPrograma.idtpprograma);
                    SelectedTipoHerramientaModelo = listaTipoHerramienta.Single(j => j.id == currentEntidadPrograma.idthprograma);
                    //Enviar datos al detalle
                    enviarDetalleProgramaMsj();
                    //Enviar el elemento para recuperar el detalle
                    visibilidadPrograma = Visibility.Visible;
                    encabezadoPantalla = "Actualice los datos";
                    activarCaptura = false;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadCreacion = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;

                    activarCrear = false;
                    activarConsultar = true;
                    activarEditar = false;
                    break;
                case 6://Importar de las plantillas
                       //Seleccion de programa
                       //listaProgramaModelo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByHerramientaNotEncargo(currentEntidadPrograma.idthprograma, currentEncargo.idencargo));
                    listaProgramaModelo = programaDatosMsj.listaProgramaModelo;
                    currentEntidadPrograma.tipoHerramientaModeloPrograma = listaTipoHerramienta[1];//Son cuestionarios
                    currentEntidadPrograma.idthprograma = listaTipoHerramienta[1].id;//Son cuestionarios
                    SelectedTipoHerramientaModelo = listaTipoHerramienta[1];//Son cuestionarios
                    SelectedTipoProgramaModelo = currentEntidadPrograma.tipoProgramaModeloPrograma;
                    tipoProgramaModeloPrograma = currentEntidadPrograma.tipoProgramaModeloPrograma;
                    descripcion = currentEntidadPrograma.tipoProgramaModeloPrograma.descripcion;
                    //idthPrograma indica si es programa o programa
                    listaPlantillas = new ObservableCollection<HerramientasModelo>(HerramientasModelo.GetAll(currentEntidadPrograma.idthprograma));//Es uno por ser programas
                    if (!(listaPlantillas.Count > 0))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }
                    else
                    {
                        accesibilidadWindow = true;
                        accesibilidadCuerpo = true;
                    }
                    break;
                case 7://Importar de las plantillas
                       //Seleccion de programa

                    listaProgramaModelo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByHerramientaNotEncargo(currentEntidadPrograma.idthprograma, currentEncargo.idencargo));
                    if (listaProgramaModelo.Count > 0)
                    {
                        //listaProgramaByEncargo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(currentEntidadPrograma.idthprograma, currentEntidadPrograma.idencargoprograma));
                        currentEntidadPrograma.tipoHerramientaModeloPrograma = listaTipoHerramienta[1];
                        currentEntidadPrograma.idthprograma = listaTipoHerramienta[1].id;
                        SelectedTipoHerramientaModelo = listaTipoHerramienta[1];
                        SelectedTipoProgramaModelo = currentEntidadPrograma.tipoProgramaModeloPrograma;
                        tipoProgramaModeloPrograma = currentEntidadPrograma.tipoProgramaModeloPrograma;
                        descripcion = currentEntidadPrograma.tipoProgramaModeloPrograma.descripcion;
                        //idthPrograma indica si es programa o programa
                        //listaPlantillas = new ObservableCollection<HerramientasModelo>(HerramientasModelo.GetAll(currentEntidadPrograma.idthprograma));//Es uno por ser programas
                        accesibilidadWindow = true;
                        accesibilidadCuerpo = true;
                    }
                    else
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
                       //Seleccion de programa
                       //listaProgramaModelo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(currentEntidadPrograma.idthprograma, currentEncargo));
                    visibilidadCmdReferenciar = Visibility.Visible;
                    visibilidadObjetivo = Visibility.Collapsed;
                    visibilidadReferencia = Visibility.Visible;

                    SelectedTipoProgramaModelo = listaTipoPrograma.Single(i => i.id == currentEntidadPrograma.idtpprograma);
                    SelectedTipoHerramientaModelo = listaTipoHerramienta.Single(j => j.id == currentEntidadPrograma.idthprograma);




                    listaProgramaModelo = programaDatosMsj.listaProgramaModelo;
                    currentEntidadPrograma.tipoHerramientaModeloPrograma = listaTipoHerramienta[1]; //Es un programa
                    currentEntidadPrograma.idthprograma = programaDatosMsj.programaModelo.idthprograma;
                    currentEntidadPrograma.listadoProgramaModelo = listaProgramaModelo;
                    encabezadoPantalla = "Introduzca la referencia para el programa";
                    nombreprogramaVista = "Nombre del programa";
                    tipoProgramaCuestionario = "Tipo de programa";
                    visibilidadHoras = Visibility.Visible;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadCreacion = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    //Propiedades de presentacion
                    activarCaptura = true;
                    visibilidadPrograma = Visibility.Visible;
                    activarCrear = false;
                    activarConsultar = false;
                    activarEditar = false;
                    tipoProgramaModeloPrograma = currentEntidadPrograma.tipoProgramaModeloPrograma;
                    descripcion = currentEntidadPrograma.tipoProgramaModeloPrograma.descripcion;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = false;
                    if (currentEntidadPrograma.etapaprograma == "T")
                    {
                        #region conversion  de fechas
                        //fechainiperauditencargo = currentEntidadEncargo.fechainiperauditencargo;
                        try
                        {
                            fechacierre = MetodosModelo.convertirFecha(currentEntidadPrograma.fechacierre);
                        }
                        catch (Exception)
                        {
                            fechacierre = DateTime.Now;
                        }
                        #endregion
                    }
                    else
                    {
                        fechacierre = DateTime.Now;
                    }
                    break;
                case 9://Historial de la bitacora
                    //Actualizacion de historial
                    try
                    {
                        listadoBitacoraVista = new ObservableCollection<UsuarioProgramaAccionModelo>(UsuarioProgramaAccionModelo.GetAll(currentEntidadPrograma.idprograma));
                        //currentEntidadPrograma.listadoBitacoraVista = listadoBitacoraVista;
                    }
                    catch (Exception)
                    {
                        this.except4();
                        //await dlg.ShowMessageAsync(this, "No se pudo recuperar el historia", "");
                    }
                    //listaProgramaModelo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(currentEntidadPrograma.idthprograma, currentEncargo));
                    visibilidadCmdReferenciar = Visibility.Visible;
                    visibilidadObjetivo = Visibility.Collapsed;
                    visibilidadReferencia = Visibility.Visible;

                    SelectedTipoProgramaModelo = listaTipoPrograma.Single(i => i.id == currentEntidadPrograma.idtpprograma);
                    SelectedTipoHerramientaModelo = listaTipoHerramienta.Single(j => j.id == currentEntidadPrograma.idthprograma);

                    listaProgramaModelo = programaDatosMsj.listaProgramaModelo;
                    currentEntidadPrograma.tipoHerramientaModeloPrograma = listaTipoHerramienta[1]; //Es un programa
                    currentEntidadPrograma.idthprograma = programaDatosMsj.programaModelo.idthprograma;
                    currentEntidadPrograma.listadoProgramaModelo = listaProgramaModelo;
                    encabezadoPantalla = "Historial del programa";
                    nombreprogramaVista = "Nombre del programa";
                    tipoProgramaCuestionario = "Tipo de programa";
                    visibilidadHoras = Visibility.Visible;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadCreacion = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    //Propiedades de presentacion
                    activarCaptura = true;
                    visibilidadPrograma = Visibility.Visible;
                    activarCrear = false;
                    activarConsultar = false;
                    activarEditar = false;
                    tipoProgramaModeloPrograma = currentEntidadPrograma.tipoProgramaModeloPrograma;
                    descripcion = currentEntidadPrograma.tipoProgramaModeloPrograma.descripcion;
                    accesibilidadWindow = true;
                    accesibilidadCuerpo = false;
                    break;

            }
            Messenger.Default.Unregister<ProgramaDatosMsj>(this, tokenRecepcionProgramas);
            finComando();//Inicio de proceso
        }

        private async void except4()
        {
            await dlg.ShowMessageAsync(this, "No se pudo recuperar el historia", "");
        }

        private async void except3()
        {
            await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de supervision del programa", "");
        }

        private async void except2()
        {
            await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de aprobacion del programa", "");
        }

        private async void except1()
        {
            await dlg.ShowMessageAsync(this, "No se pudo convertir la fecha de ejecución del programa", "");
        }

        #endregion

        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            iniciarComando();
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            fuenteCierre = 1;
            CloseWindow();
        }

        private void OkCierre()
        {
            iniciarComando();
            fuenteCierre = 1;
            CloseWindow();
        }

        private void Salir()
        {
            if (fuenteCierre == 0)
            {
                iniciarComando();
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

        //Guarda los cambios en la lista una vez se cierra la ventana
        public async void guardarLista()
        {
            if (listaDetallePrograma.Count > 0 && listaDetallePrograma.Where(x => x.guardadoBase == false).Count() > 0)
            {
                var listatemporal = listaDetallePrograma.Where(x => x.guardadoBase == false);
                foreach (DetalleProgramaModelo item in listatemporal)
                {
                    if (item.guardadoBase == false)
                    {
                        if (DetalleProgramaModelo.UpdateModelo(item, currentUsuario,currentEncargo.idencargo))
                        {
                            //Se guardo con éxito
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "No ha sido posible actualizar un registro", "");
                        }
                    }
                }
                if (currentEntidadPrograma.idthprograma == 1)
                {
                    if (!(ProgramaModelo.UpdateSumaModelo((int)currentEntidadPrograma.idthprograma)))
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible actualizar la suma de horas", "");
                    }
                }
            }
        }
        public async void Copiar()
        {
            iniciarComando();
            if (!(ProgramaModelo.FindTexto(currentEntidadPrograma.nombreprograma)))
            {
                if (ProgramaModelo.CopiarModelo(currentEntidadPrograma))
                {
                    var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                    controller.SetIndeterminate();
                    await TaskEx.Delay(1000);
                    await controller.CloseAsync();
                    fuenteCierre = 1;
                    resultadoProceso = 3;//3 para  copiar;
                    CloseWindow();
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Error al copiar programa", "");
                    finComando();

                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "El registro ya existe con ese nombre, debe cambiarlo", "");
                finComando();
            }
        }

        public async void Guardar()
        {
            iniciarComando();
            try
            {
                switch (ProgramaModelo.InsertByCreacion(currentEntidadPrograma))
                {
                    case 0://No se pudo insertar
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                        finComando();
                        break;
                    case 1://Se inserto con éxito
                        currentEntidadProgramaDetalle.idprogramadp = currentEntidadPrograma.idprograma;
                        if (DetalleProgramaModelo.Insert(currentEntidadProgramaDetalle, true, currentEncargo.idencargo))
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            resultadoProceso = 1;//1 para  crear
                            fuenteCierre = 1;
                            CloseWindow();
                        }
                        break;
                    case 2://Error al insertar registro auxiliar, debe eliminarse el registro
                        await dlg.ShowMessageAsync(this, "No ha sido posible importar la plantilla", "en  su registro auxiliar");
                        //Borrar el registro
                        if (ProgramaModelo.DeleteByDetalleCuestionario(currentEntidadPrograma.idprograma, true))
                        {
                            //await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        }
                        else
                        {
                            finComando();
                            await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "debe corregirse manualmente");
                        }
                        break;
                    case 3:
                        finComando();
                        await dlg.ShowMessageAsync(this, "Se produjo una excepción", "debe corregirse manualmente");
                        break;

                }
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                finComando();
                MessageBox.Show("No ha sido posible insertar el registro");
            }
        }


        private async void ImportarProgramasEncargos()
        {
            iniciarComando();
            int continuar = 0;
            if (listaProgramaModelo.Count > 0)
            {
                continuar = 0;
            }
            else
            {
                continuar = 1;//No hay registros
            }
            if (continuar == 0)
            {
                //Verificar que no exista nombre duplicado
                for (int k = 0; k < listaProgramaModelo.Count; k++)
                {
                    if (listaProgramaModelo[k].seleccionPrograma)
                    {
                        //Verificar que no existan duplicados
                        if (validarPlantillaDeEncargo(listaProgramaModelo[k]))
                        {
                            //Importar
                            ProgramaModelo temporal = new ProgramaModelo((int)currentEntidadPrograma.idthprograma, (int)currentEntidadPrograma.idtpprograma, currentUsuario, currentEncargo);
                            continuar = ImportarProgramasByItemForEncargos(ProgramaModelo.equivalencia(temporal, listaProgramaModelo[k]), listaProgramaModelo[k]);

                            //continuar = ImportarProgramasByItemForEncargos(ProgramaModelo.equivalencia(currentEntidadPrograma, listaProgramaModelo[k]), listaProgramaModelo[k]);
                            if (continuar == 0)
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La plantilla denominada " + listaProgramaModelo[k].nombreprograma, "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                            }
                            else
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La plantilla denominada " + listaProgramaModelo[k].nombreprograma + " no pudo ser importada con  éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                            }
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "Ya existe un programa con el nombre " + listaProgramaModelo[k].nombreprograma, "por lo que no  se importará");
                            var controller = await dlg.ShowProgressAsync(this, "Ya existe un programa con el nombre " + listaProgramaModelo[k].nombreprograma + " por lo que no  se importará", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                        }
                    }
                    if (continuar != 0 && continuar > 0)
                    {
                        //Hubo error debe eliminarse el registro
                        if (ProgramaModelo.DeleteByDetalleCuestionario(currentEntidadPrograma.idprograma, true))
                        {
                            //await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "No ha sido posible eliminar el registro auxiliares debe corregirse manualmente", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                        }
                    }
                }
                //Termina el ciclo
                if (continuar == 0)
                {
                    if (listaProgramaModelo.Count(j => j.seleccionPrograma) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Los registros se importaron con éxito ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();

                    }
                }
                else
                {
                    if (listaProgramaModelo.Count(j => j.seleccionPrograma) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Algunos registros no se importaron ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                    }
                }
                fuenteCierre = 1;
                resultadoProceso = 4;//2 para  importar;
                CloseWindow();
            }
        }

        private async void ImportarPlantillas()
        {
            iniciarComando();

            int continuar = 0;
            if (listaPlantillas.Count > 0)
            {
                continuar = 0;
            }
            else
            {
                continuar = 1;//No hay registros
            }
            if (continuar == 0)
            {
                //Verificar que no exista nombre duplicado
                for (int k = 0; k < listaPlantillas.Count; k++)
                {
                    if (listaPlantillas[k].seleccionHerramienta)
                    {
                        //Verificar que no existan duplicados
                        if (validarPlantilla(listaPlantillas[k]))
                        {
                            //Importar
                            continuar = ImportarPlantillasByItem(ProgramaModelo.equivalencia(currentEntidadPrograma, listaPlantillas[k], currentUsuario, currentEncargo), listaPlantillas[k]);
                            if (continuar == 0)
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La plantilla denominada " + listaPlantillas[k].nombreHerramienta + " fue importada con  éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();
                            }
                            else
                            {
                                var controller = await dlg.ShowProgressAsync(this, "La plantilla denominada " + listaPlantillas[k].nombreHerramienta + " no pudo ser importada con  éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                                controller.SetIndeterminate();
                                await TaskEx.Delay(1000);
                                await controller.CloseAsync();

                            }
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "Ya existe un programa con el nombre " + listaPlantillas[k].nombreHerramienta + " por lo que no  se importará", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                        }
                    }
                    if (continuar != 0 && continuar > 0)
                    {
                        //Hubo error debe eliminarse el registro
                        if (ProgramaModelo.DeleteByDetalleCuestionario(currentEntidadPrograma.idprograma, true))
                        {
                            //await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "No ha sido posible eliminar el registro auxiliares" + " debe corregirse manualmente", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                        }
                    }
                }
                //Termina el ciclo
                if (continuar == 0)
                {
                    if (listaPlantillas.Count(j => j.seleccionHerramienta) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Los registros se importaron con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();

                    }
                }
                else
                {
                    if (listaPlantillas.Count(j => j.seleccionHerramienta) > 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Algunos registros no se importaron ", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                    }
                }
                fuenteCierre = 1;
                resultadoProceso = 5;//5 para  importar de encargos;
                CloseWindow();
            }
        }
        public int ImportarPlantillasByItem(ProgramaModelo entidad, HerramientasModelo herramientaPlantilla)
        {
            int resultado = 0; //Valor por defecto
            int i = 0;
            DetalleProgramaModelo temporal;
            //Verificar que no exista nombre duplicado
            //Importar
            switch (ProgramaModelo.InsertByCreacion(entidad))
            {
                case 0://No se pudo  insertar el principal
                    resultado = 1;
                    break;
                case 1://Caso normal se inserto el principal y el auxiliar, se procede  a insertar los dependientes
                       //Conseguir el listado de detalles de la  herramienta
                    currentEntidadProgramaDetalle.idprogramadp = entidad.idprograma;//Aplica para todos
                    ObservableCollection<DetalleHerramientasModelo> listaDetalle = new ObservableCollection<DetalleHerramientasModelo>(DetalleHerramientasModelo.GetAll(herramientaPlantilla.idHerramienta));
                    ObservableCollection<DetalleProgramaModelo> listaDestino = new ObservableCollection<DetalleProgramaModelo>();
                    i = 0;
                    temporal = null;
                    for (int p = 0; p < listaDetalle.Count; p++)
                    {
                        //Hacer la  equivalencia
                        temporal = new DetalleProgramaModelo(currentEntidadProgramaDetalle, listaDetalle[p]);
                        listaDestino.Add(temporal);
                        switch (DetalleProgramaModelo.InsertbyImportacion(listaDestino[i], currentEncargo.idencargo))
                        {
                            case 0:
                                resultado = 2;//No pudo insertar un detalle
                                p = listaDetalle.Count;//Se aborta el proceso
                                                       //await dlg.ShowMessageAsync(this, "No ha sido posible importar el detalle de la plantilla denominada " + currentEntidadPrograma.nombreprograma, "");
                                break;
                            case 1://Se inserto sin problemas
                                i++;
                                break;
                            case 2:
                                resultado = 3;//Se dio una excepcion en el detalle
                                p = listaDetalle.Count;//Se aborta el proceso
                                                       //await dlg.ShowMessageAsync(this, "No ha sido posible crear registros auxiliares del detalle de la plantilla denominada " + currentEntidadPrograma.nombreprograma, "");
                                break;
                            case 3:
                                resultado = 4;
                                p = listaDetalle.Count;//Se aborta el proceso
                                break;
                        }
                    }
                    //Insertar las dependencias entre registros
                    if (resultado == 0)
                    {
                        foreach (DetalleProgramaModelo itemDetalle in listaDestino)
                        {
                            if (itemDetalle.idpadredp != null && itemDetalle.guardadoBase)
                            {
                                itemDetalle.idpadredp = listaDestino.Single(j => j.idpapelesdp == itemDetalle.idpadredp).iddp;
                                if (DetalleProgramaModelo.UpdateModeloByImportacion(itemDetalle))
                                {
                                    //codigoError = 7;
                                }
                                else
                                {
                                    resultado = 5;
                                }
                            }
                        }
                    }
                    break;
                case 2://No se inserto el registro auxiliar
                    resultado = 2;
                    //await dlg.ShowMessageAsync(this, "No ha sido posible importar la plantilla", "en  su registro auxiliar");
                    break;
            }
            return resultado;
        }

        public int ImportarProgramasByItemForEncargos(ProgramaModelo entidad, ProgramaModelo programaOrigen)
        {
            int resultado = 0; //Valor por defecto
            int i = 0;
            DetalleProgramaModelo temporal;
            //Verificar que no exista nombre duplicado
            //Importar
            switch (ProgramaModelo.InsertByCreacion(entidad))
            {
                case 0://No se pudo  insertar el principal
                    resultado = 1;
                    break;
                case 1://Caso normal se inserto el principal y el auxiliar, se procede  a insertar los dependientes
                       //Conseguir el listado de detalles de la  herramienta
                    ObservableCollection<DetalleProgramaModelo> listaDetalle = new ObservableCollection<DetalleProgramaModelo>(DetalleProgramaModelo.GetAll(programaOrigen.idprograma));
                    ObservableCollection<DetalleProgramaModelo> listaDestino = new ObservableCollection<DetalleProgramaModelo>();
                    currentEntidadProgramaDetalle.idprogramadp = entidad.idprograma;//Aplica para todos
                    i = 0;
                    temporal = null;
                    for (int p = 0; p < listaDetalle.Count; p++)
                    {
                        //Hacer la  equivalencia
                        temporal = new DetalleProgramaModelo(currentEntidadProgramaDetalle, listaDetalle[p]);
                        listaDestino.Add(temporal);
                        switch (DetalleProgramaModelo.InsertbyImportacion(listaDestino[i], currentEncargo.idencargo))
                        {
                            case 0:
                                resultado = 2;//No pudo insertar un detalle
                                p = listaDetalle.Count;//Se aborta el proceso
                                                       //await dlg.ShowMessageAsync(this, "No ha sido posible importar el detalle de la plantilla denominada " + currentEntidadPrograma.nombreprograma, "");
                                break;
                            case 1://Se inserto sin problemas
                                i++;
                                break;
                            case 2:
                                resultado = 3;//Se dio una excepcion en el detalle
                                p = listaDetalle.Count;//Se aborta el proceso
                                                       //await dlg.ShowMessageAsync(this, "No ha sido posible crear registros auxiliares del detalle de la plantilla denominada " + currentEntidadPrograma.nombreprograma, "");
                                break;
                            case 3:
                                resultado = 4;
                                p = listaDetalle.Count;//Se aborta el proceso
                                break;
                        }
                    }
                    //Insertar las dependencias entre registros
                    if (resultado == 0)
                    {
                        foreach (DetalleProgramaModelo itemDetalle in listaDestino)
                        {
                            if (itemDetalle.idpadredp != null && itemDetalle.guardadoBase)
                            {
                                itemDetalle.idpadredp = listaDestino.Single(j => j.idpapelesdp == itemDetalle.idpadredp).iddp;
                                if (DetalleProgramaModelo.UpdateModeloByImportacion(itemDetalle))
                                {
                                    //codigoError = 7;
                                }
                                else
                                {
                                    resultado = 5;
                                }
                            }
                        }
                    }
                    break;
                case 2://No se inserto el registro auxiliar
                    resultado = 2;
                    //await dlg.ShowMessageAsync(this, "No ha sido posible importar la plantilla", "en  su registro auxiliar");
                    break;
            }
            return resultado;
        }

        public async void Modificar()
        {
            iniciarComando();
            if (currentEntidadPrograma.fechaaprobacion != null)
            {
                currentEntidadPrograma.fechaaprobacion = MetodosModelo.homologacionFecha(currentEntidadPrograma.fechaaprobacion);
            }
            if (currentEntidadPrograma.fechacierre != null)
            {
                currentEntidadPrograma.fechacierre = MetodosModelo.homologacionFecha(currentEntidadPrograma.fechacierre);
            }
            if (currentEntidadPrograma.fechasupervision != null)
            {
                currentEntidadPrograma.fechasupervision = MetodosModelo.homologacionFecha(currentEntidadPrograma.fechasupervision);
            }
            if (ProgramaModelo.UpdateModelo(currentEntidadPrograma, currentUsuario))
            {
                var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en segundos", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                fuenteCierre = 1;
                resultadoProceso = 2;//2 para  modificar;
                CloseWindow();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                finComando();
            }
        }
        #endregion

        #region Mensajes

        //Procesando el mensaje recibido
        private bool ControlVentanaMensaje(CatalogoMensaje controlVentanaMensaje)
        {
            if (controlVentanaMensaje.mensaje == 0)
            {
                //Nuevo();
                return true;
            }
            else
            {
                fuenteCierre = 1;
                CloseWindow();
                return false;

            }
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvioController);
        }

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

        public void enviarDetalleProgramaMsj()
        {
            //Creando el mensaje para que se actualice el listado.
            DetalleEncargoPlanProgramaMsj mensaje = new DetalleEncargoPlanProgramaMsj();
            mensaje.currentEncargo = currentEncargo;
            mensaje.programaModelo = currentEntidadPrograma;
            mensaje.opcionMenuPrincipal = (int)currentEntidadPrograma.idthprograma;
            mensaje.usuarioModelo = currentUsuario;
            mensaje.opcionMenuCrud = opcionMenu;
            Messenger.Default.Send(mensaje, tokenEnvioControllerDetalle);
        }

        #endregion

        #endregion

        #region Metodos de apoyo

        public bool CanSaveNuevo()
        {
            bool evaluar = false;

            if (currentEntidadPrograma == null)
            {
                return evaluar;
            }
            else
            {
                if (currentEntidadProgramaDetalle == null)
                {
                    evaluar = (Errors == 0);
                    return evaluar;
                }
                else
                {
                    evaluar = (Errors == 0);
                    return evaluar;
                }
            }
        }
        public bool CanSave()
        {
            bool evaluar = false;

            if (currentEntidadPrograma == null)
            {
                return evaluar;
            }
            else
            {
                evaluar = (Errors == 0);
                return evaluar;
            }
        }

        private bool canImport()
        {
            //bool evaluar = false;
            return (listaPlantillas.Count(j => j.seleccionHerramienta) > 0);
        }


        private bool canImportForEncargos()
        {
            //bool evaluar = false;
            return (listaProgramaModelo.Count(j => j.seleccionPrograma) > 0);
        }
        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            referenciarCommand = new RelayCommand(Modificar, CanSave);//Para guardar la referencia
            EditarCommand = new RelayCommand(Modificar, CanSave);
            CopiarCommand = new RelayCommand(Copiar, CanSave);
            GuardarCommand = new RelayCommand(Guardar, CanSaveNuevo);//Caso de nuevo registro
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(OkCierre);
            mouseClickCommand = new RelayCommand(OkCierre);
            SalirCommand = new RelayCommand(Salir);

            SelectionChangedCommand = new RelayCommand<ProgramaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidadPrograma = entidad;
            });
            SelectionBitacoraChangedCommand = new RelayCommand<UsuarioProgramaAccionModelo>(entidad =>
            {
                if (entidad == null) return;
                currentBitacora = entidad;
            });
            SelectionChangedPlantillaCommand = new RelayCommand<HerramientasModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidadPlantilla = entidad;
                seleccionHerramienta = currentEntidadPlantilla.seleccionHerramienta;
            });

            CancelarPlantillaCommand = new RelayCommand(Cancelar);
            SeleccionPlantillaCommand = new RelayCommand(ImportarPlantillas, canImport);
            CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
            SeleccionProgramaEncargoCommand = new RelayCommand(ImportarProgramasEncargos, canImportForEncargos);

        }




        #endregion

        private bool validarPlantilla(HerramientasModelo item)
        {
            try
            {
                if (listaProgramaModelo.Count > 0)
                {
                    var contains = listaProgramaModelo.Select(x => x.nombreprograma.ToUpper().Trim()).Contains(item.nombreHerramienta.ToUpper().Trim());
                    if (contains)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;//No hay registros en el listado por lo que es único
                    //return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en verificación de registro único de programas : " + e.Message);
                return false;
            }
        }

        private bool validarPlantillaDeEncargo(ProgramaModelo item)
        {
            try
            {
                actualizarLista();
                if (listaProgramaByEncargo.Count > 0)
                {
                    var contains = listaProgramaByEncargo.Select(x => x.nombreprograma.ToUpper().Trim()).Contains(item.nombreprograma.ToUpper().Trim());
                    if (contains)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;//No hay registros en el listado por lo que es único
                    //return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en verificación de registro único de programas : " + e.Message);
                return false;
            }

        }
        private void actualizarLista()
        {
            try
            {
                listaProgramaByEncargo = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(currentEntidadPrograma.idthprograma, currentEncargo));
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista \n" + e, "");
                }
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
    }
}

