﻿using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System.Windows.Input;
using System.ComponentModel;
using SGPTWpf.Messages;
using SGPTWpf.Model.Modelo.programas;

namespace SGPTWpf.ViewModel.Planificacion.Programas

{

    public sealed class ProgramasViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region tokenRecepcionPlanificacion

        private string _tokenRecepcionPlanificacion;
        private string tokenRecepcionPlanificacion
        {
            get { return _tokenRecepcionPlanificacion; }
            set { _tokenRecepcionPlanificacion = value; }
        }

        #endregion

        #region tokenRecepcionController

        private string _tokenRecepcionController;
        private string tokenRecepcionController
        {
            get { return _tokenRecepcionController; }
            set { _tokenRecepcionController = value; }
        }

        #endregion

        #region comando

        private int _comando;
        private int comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        #endregion


        private DialogCoordinator dlg;

        #region tokenRecepcionCierrePreView

        private string _tokenRecepcionCierrePreView;
        private string tokenRecepcionCierrePreView
        {
            get { return _tokenRecepcionCierrePreView; }
            set { _tokenRecepcionCierrePreView = value; }
        }

        #endregion

        #region opcionTipoPrograma Estandar o Ad-hoc

        private int _opcionTipoPrograma;//Ad-hoc o estandar
        private int opcionTipoPrograma
        {
            get { return _opcionTipoPrograma; }
            set { _opcionTipoPrograma = value; }
        }

        #endregion 

        #region opcionTipoHerramientaprograma //Programa o cuestionario

        private int _opcionTipoHerramientaprograma;//Tipo de herramienta cuestionario o programa
        private int opcionTipoHerramientaprograma
        {
            get { return _opcionTipoHerramientaprograma; }
            set { _opcionTipoHerramientaprograma = value; }
        }

        #endregion

        #endregion

        #region tokenEnvioProgramas

        private string _tokenEnvioProgramas;
        private string tokenEnvioProgramas
        {
            get { return _tokenEnvioProgramas; }
            set { _tokenEnvioProgramas = value; }
        }

        #endregion

        #region tokenEnvioPlanificacion

        private string _tokenEnvioPlanificacion;
        private string tokenEnvioPlanificacion
        {
            get { return _tokenEnvioPlanificacion; }
            set { _tokenEnvioPlanificacion = value; }
        }

        #endregion

        #region ViewModel Property : usuarioModelo usuario

        public const string usuarioModeloPropertyName = "usuarioModelo";

        private UsuarioModelo _usuarioModelo;

        public UsuarioModelo usuarioModelo
        {
            get
            {
                return _usuarioModelo;
            }

            set
            {
                if (_usuarioModelo == value) return;

                _usuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(usuarioModeloPropertyName);
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

        #region ViewModel Properties publicas

        #region encabezadoPrograma

        public const string encabezadoProgramaPropertyName = "encabezadoPrograma";

        private string _encabezadoPrograma = string.Empty;

        public string encabezadoPrograma
        {
            get
            {
                return _encabezadoPrograma;
            }

            set
            {
                if (_encabezadoPrograma == value)
                {
                    return;
                }

                _encabezadoPrograma = value;
                RaisePropertyChanged(encabezadoProgramaPropertyName);
            }
        }

        #endregion

        #region visibilidadTipoPrograma

        public const string visibilidadTipoProgramaPropertyName = "visibilidadTipoPrograma";

        private Visibility _visibilidadTipoPrograma = Visibility.Visible;

        public Visibility visibilidadTipoPrograma
        {
            get
            {
                return _visibilidadTipoPrograma;
            }

            set
            {
                if (_visibilidadTipoPrograma == value)
                {
                    return;
                }

                _visibilidadTipoPrograma = value;
                RaisePropertyChanged(visibilidadTipoProgramaPropertyName);
            }
        }

        #endregion


        #region widthTipoPrograma

        public const string widthTipoProgramaPropertyName = "widthTipoPrograma";

        private string _widthTipoPrograma = "0";

        public string widthTipoPrograma
        {
            get
            {
                return _widthTipoPrograma;
            }

            set
            {
                if (_widthTipoPrograma == value)
                {
                    return;
                }

                _widthTipoPrograma = value;
                RaisePropertyChanged(widthTipoProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<ProgramaModelo> _lista;

        public ObservableCollection<ProgramaModelo> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaTipoHerramienta

        public const string listaTipoHerramientaPropertyName = "listaTipoHerramienta";

        private ObservableCollection<TipoProgramaModelo> _listaTipoHerramienta;

        public ObservableCollection<TipoProgramaModelo> listaTipoHerramienta
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

        #region Entidades

        #region ViewModel Property : currentEntidad Programa Modelo

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

        #endregion

        #region Propiedades programa

        #region idCorrelativo

        public const string idCorrelativoPropertyName = "idCorrelativo";

        private int _idCorrelativo = 0;

        public int idCorrelativo
        {
            get
            {
                return _idCorrelativo;
            }

            set
            {
                if (_idCorrelativo == value)
                {
                    return;
                }

                _idCorrelativo = value;
                RaisePropertyChanged(idCorrelativoPropertyName);
            }
        }

        #endregion

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

        #region horasPlanHerramienta

        public const string horasPlanHerramientaPropertyName = "horasPlanHerramienta";

        private decimal _horasPlanHerramienta = 0;

        public decimal horasPlanHerramienta
        {
            get
            {
                return _horasPlanHerramienta;
            }

            set
            {
                if (_horasPlanHerramienta == value)
                {
                    return;
                }

                _horasPlanHerramienta = value;
                RaisePropertyChanged(horasPlanHerramientaPropertyName);
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

        private decimal _ordenDh = 0;

        public decimal ordenDh
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

        #endregion

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

        #region Properties : cursorWindow

        public const string cursorWindowPropertyName = "cursorWindow";

        private Cursor _cursorWindow;

        public Cursor cursorWindow
        {
            get
            {
                return _cursorWindow;
            }

            set
            {
                if (_cursorWindow == value)
                {
                    return;
                }

                _cursorWindow = value;
                RaisePropertyChanged(cursorWindowPropertyName);
            }
        }

        #endregion


        #region visibilidadProcesando

        public const string visibilidadProcesandoPropertyName = "visibilidadProcesando";

        private Visibility _visibilidadProcesando;

        public Visibility visibilidadProcesando
        {
            get
            {
                return _visibilidadProcesando;
            }

            set
            {
                if (_visibilidadProcesando == value)
                {
                    return;
                }

                _visibilidadProcesando = value;
                RaisePropertyChanged(visibilidadProcesandoPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands

        public RelayCommand ImportarCommand { get; set; }
        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand<ProgramaModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region EncargoProgramasMainModel

        private MainModel _mainModel = null;

        public MainModel EncargoProgramasMainModel
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

        #region idTpNombre //Nombre de los tipo de programa

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

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private bool _activarCaptura;

        public bool activarCaptura
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

        #region ViewModel Public Methods

        #region Constructores


        public ProgramasViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _dialogCoordinator = new DialogCoordinator();
            _cursorWindow =Cursors.Hand;//Definición preliminar
            _comando = 0;
            _accesibilidadWindow =false;
            //_tokenRecepcionPlanificacion = "PlanificacionDatos";//Permite captar los mensajes del  menú planificacion
            _tokenRecepcionPlanificacion = "Programas"+ "Planificación";//Permite captar los mensajes del  menú planificacion

            _tokenRecepcionCierrePreView = "CierreEncargosPlanProgramaEncargos";//Sirve tanto para los programas en vista previa como para el controllador;
            _tokenEnvioProgramas = "datosEncargosPrograma";//Para control de los datos que  remite programas a sub-ventanas
            _tokenRecepcionController = "datosController";
            _tokenEnvioPlanificacion = "inicioProgramas";
            _visibilidadProcesando = Visibility.Collapsed;
            _cursorWindow = Cursors.Hand;
            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPlanificacion, (planificacionDatos) => ControlPlanificacionDatos(planificacionDatos));
            opcionTipoPrograma = 2; //Por ser  programa ad-hoc, los estandares no pueden ediarse
            opcionTipoHerramientaprograma = 1;//Por ser un programa para  cuestionario es 2
            //currentEntidad = new ProgramaModelo(opcionTipoHerramientaprograma, opcionTipoPrograma,0);
            currentEncargo = null;
            RegisterCommands();
            comando = 0;
            dlg = new DialogCoordinator();
            //lista = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAll(opcionTipoPrograma));//Es uno por ser programas
            lista = new ObservableCollection<ProgramaModelo>();//Lista vacia no se conoce el encargo y el cliente
            //listaTipoHerramienta = new ObservableCollection<TipoProgramaModelo>(TipoProgramaModelo.GetAll());
            //Suscribiendo al tipo de mensaje
            //Messenger.Default.Register<bool>(this, tokenRecepcionController,(controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            //Messenger.Default.Register<bool>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
            //Messenger.Default.Register<bool>(this, tokenRecepcionCierrePreView, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));

            //Seleccion de opcion de opciones (Programa o Cuestionario)
            EncargoProgramasMainModel = new MainModel();

        }

        private void ControlPlanificacionDatos(EncargosDatosMsj planificacionDatos)
        {
            //usuarioModelo = UsuarioModelo.GetRegistroById(planificacionDatos.idUsuarioModelo);
            //currentEncargo = EncargoModelo.GetRegistro(planificacionDatos.idEncargo);  //El encargo puede estar cambiando.
            usuarioModelo = planificacionDatos.usuarioModelo;
            currentEncargo =planificacionDatos.encargoModelo;  //El encargo puede estar cambiando.

            actualizarLista();
            accesibilidadWindow = true;
            inicializacionTerminada();
        }


        private void actualizarLista()
        {
            try
            {
                //if (!(lista == null))
                //{
                //    lista.Clear();
                //}
                lista = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(opcionTipoHerramientaprograma,currentEncargo));
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista ", "");

                }
            }
        }

        #endregion



        #region Envio mensajes
        

        //Caso de nuevo registro 
        public void enviarMensaje()
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            elemento.programaModelo = currentEntidad;//Programa a crear 
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = currentEntidadDetalle;
            elemento.opcionTipoPrograma = opcionTipoPrograma;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 0; //no se utilizaa
            elemento.listaProgramaModelo = lista;
            Messenger.Default.Send(elemento, tokenEnvioProgramas);
        }

        public void enviarMensajeCrud()
        {
            //Se crea el mensaje
            ProgramaDatosMsj elemento = new ProgramaDatosMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = usuarioModelo;
            elemento.programaModelo = currentEntidad;//Programa a crear 
            elemento.detalleCuestionario = null;//Para el caso de  edicion de programas
            elemento.detallePrograma = null;
            elemento.opcionTipoPrograma = opcionTipoPrograma;
            elemento.opcionMenuCrud = comando;
            elemento.fuenteLlamado = 1;
            elemento.listaProgramaModelo = lista;
            //1 Cuando se origina de  encargo/planificacion/programa 
            //2 de encargo/planificacion/edicion/vista
            Messenger.Default.Send(elemento, tokenEnvioProgramas);
        }

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
        {
            EncargoProgramasMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    if (controlVentanaCrearMensaje!=0)//Cancelo o cerro la ventana no se requiere actualizar
                    { 
                    actualizarLista();
                    }
                    comando = 0;
                    break;
                case 2:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    comando = 0;
                    break;
                case 3:
                    //EncargoProgramasMainModel.TypeName = null;
                    comando = 0;
                    break;
                case 4:
                    //caso de vista de programa
                    //EncargoProgramasMainModel.TypeName = null;
                    comando = 0;
                    break;
                case 5://Programa vista
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    accesibilidadWindow = true;
                    comando = 0;
                    enviarMensajeHabilitar();
                    break;
                case 6:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                case 7:
                    //EncargoProgramasMainModel.TypeName = null;
                    if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                    {
                        actualizarLista();
                    }
                    //enviarMensajeHabilitar();
                    comando = 0;
                    break;
                default:
                    break;
            }
            finComando();   
        }

        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            iniciarComando();

            comando = 1;
            #region Inicializacion de herramienta 
            currentEntidad =new  ProgramaModelo(opcionTipoHerramientaprograma, opcionTipoPrograma, usuarioModelo, currentEncargo); //Es un programa, Ad-Hod, id del  encargo
            //Temporal para identificar al usuario
            currentEntidad.usuarioModifico = usuarioModelo.inicialesusuario.ToUpper();
            currentEntidad.usuarioModeloPrograma= usuarioModelo;
            EncargoProgramasMainModel.TypeName = "ProgramaModeloCrearView";
            //Seleccion de programa
            //currentEntidad.tipoProgramaModelo = listaTipoHerramienta[0];

            #endregion

            #region Inicializacion del detalle Programa/Cuestionario
            currentEntidadDetalle = new DetalleProgramaModelo(7, currentEntidad.idprograma,usuarioModelo);//7 por ser objetivo
            activarCaptura = true;
            #endregion
            enviarMensaje();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {

                if (currentEntidad.idtpprograma != 1)//Es un programa estándar debe modificarlo desde herramientas
                {
                    iniciarComando();

                    comando = 2;
                    EncargoProgramasMainModel.TypeName = "ProgramaModeloEditarView";
                    #region Configuracion
                    currentEntidad.usuarioModifico = usuarioModelo.inicialesusuario.ToUpper();
                    currentEntidad.usuarioModeloPrograma = usuarioModelo;
                    currentEntidad.usuarioProgramaAccionModelo.rolUsuarioModelo = RolUsuarioModelo.GetRegistro("M");
                    currentEntidad.usuarioProgramaAccionModelo.rolupa = currentEntidad.usuarioProgramaAccionModelo.rolUsuarioModelo.rolUsuario;
                    #endregion

                    enviarMensajeCrud(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Es un programa estándar no puede ser modificado en esta sección", "Sólo puede modificarse en herramientas");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
        }
        public async void Consultar()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                comando = 3;
                EncargoProgramasMainModel.TypeName = "ProgramaModeloConsultarView";
                #region Configuracion
                currentEntidad.usuarioModifico = usuarioModelo.inicialesusuario.ToUpper();
                currentEntidad.usuarioModeloPrograma = usuarioModelo;
                currentEntidad.usuarioProgramaAccionModelo.rolUsuarioModelo = RolUsuarioModelo.GetRegistro("M");
                currentEntidad.usuarioProgramaAccionModelo.rolupa = currentEntidad.usuarioProgramaAccionModelo.rolUsuarioModelo.rolUsuario;
                #endregion
                enviarMensajeCrud(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                //enviarMensaje();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        public async void ConsultarDobleClick()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                comando = 3;
                EncargoProgramasMainModel.TypeName = "ProgramaModeloConsultarView";
                //enviarElemento(currentEntidad);
                //enviarMensaje();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }


        public async void Borrar()
        {

            if (!(currentEntidad == null))
            {
                if (ProgramaModelo.evaluarEstadoPrograma(currentEntidad.idprograma) == 0)//Hay cero procedimientos diferentes a iniciados
                {
                 accesibilidadWindow = false;
                //Mouse.OverrideCursor = Cursors.Wait;
                
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    if (ProgramaModelo.DeleteByDetallePrograma(currentEntidad.idprograma, true))
                    {
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        actualizarLista();
                        currentEntidad = new ProgramaModelo();
                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                        accesibilidadWindow = true;
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El programa ya tiene procedimientos iniciados, no puede eliminarse", "solo puede  eliminar o modificar los procedimientos  no  iniciados en forma individual");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
            accesibilidadWindow = true;
            Mouse.OverrideCursor = null;
            visibilidadProcesando = Visibility.Collapsed;
        }

        public async void BorrarLogico()
        {
            if (!(currentEntidad == null))
            {
                if (ProgramaModelo.evaluarEstadoCuestionario(currentEntidad.idprograma) == 0)//Hay cero procedimientos diferentes a iniciados
                {
                    var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                  
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (ProgramaModelo.DeleteByDetallePrograma(currentEntidad.idprograma, true))
                    {
                            Mouse.OverrideCursor = null;
                            await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        actualizarLista();
                        currentEntidad = ProgramaModelo.Clear(currentEntidad);
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El programa ya tiene procedimientos iniciados, no puede eliminarse", "solo puede  eliminar o modificar los procedimientos  no  iniciados en forma individual");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el registro a editar", "", MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }

        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.idprograma == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.nombreprograma);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<ProgramaModelo> listaEntidad)
        {
            lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        public bool CanCommand()
        {
            if (!(currentEntidad == null))
            {
                try
                {
                    return currentEntidad.idprograma != 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            ImportarCommand = new RelayCommand(Importar, null);//ok
            NuevoCommand = new RelayCommand(Nuevo, null);//ok
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            BuscarCommand = new RelayCommand(Buscar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            XImprimirCommand = new RelayCommand(XImprimir, CanCommand);
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanCommand);
            SelectionChangedCommand = new RelayCommand<ProgramaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        public async void Importar()
        {

            var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Plantillas",
                    FirstAuxiliaryButtonText = "Cancelar",
                    NegativeButtonText = "Encargos",
                };

                    MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione la fuente para importar", "Para los encargos se toman de los programas de años anteriores", 
                    MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {

                        iniciarComando();

                        comando = 6;//Importara de las plantillas
                        EncargoProgramasMainModel.TypeName = "ProgramaModeloImportarPlantillaView";
                        #region Configuracion copia

                        currentEntidad = new ProgramaModelo(opcionTipoHerramientaprograma, opcionTipoPrograma, usuarioModelo, currentEncargo); //Es un programa, Ad-Hod, id del  encargo
                        currentEntidad.usuarioModifico = usuarioModelo.inicialesusuario.ToUpper();
                        currentEntidad.usuarioModeloPrograma = usuarioModelo;
                        
                        #endregion

                        #region Inicializacion del detalle Programa/Cuestionario
                        currentEntidadDetalle = new DetalleProgramaModelo(7, currentEntidad.idprograma, usuarioModelo);//7 por ser objetivo
                        activarCaptura = true;
                        #endregion
                        enviarMensaje();
            }
            else
                {
                    if (result == MessageDialogResult.Negative)
                    {
                    iniciarComando();

                    comando = 7;//Importa de los encargos de  años anteriores
                    EncargoProgramasMainModel.TypeName = "ProgramaModeloImportarEncargoView";
                    #region Configuracion copia

                    currentEntidad = new ProgramaModelo(opcionTipoHerramientaprograma, opcionTipoPrograma, usuarioModelo, currentEncargo); //Es un programa, Ad-Hod, id del  encargo
                    currentEntidad.usuarioModifico = usuarioModelo.inicialesusuario.ToUpper();
                    currentEntidad.usuarioModeloPrograma = usuarioModelo;

                    #endregion

                    #region Inicializacion del detalle Programa/Cuestionario
                    currentEntidadDetalle = new DetalleProgramaModelo(7, currentEntidad.idprograma, usuarioModelo);//7 por ser objetivo
                    activarCaptura = true;
                    #endregion
                    enviarMensaje();
                    }
                    else
                    {
                    await dlg.ShowMessageAsync(this, "Cancelo operación", "");
                    }
                    }
        }
        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private async void VistaPrograma()
        {
            if (!(currentEntidad == null))
            {
                iniciarComando();
                enviarMensajeInhabilitar();//Para evitar que el usuario  tome otras acciones
                comando = 5;
                accesibilidadWindow = false;
                EncargoProgramasMainModel.TypeName = "ProgramaModeloVerProgramaView";
                //enviarElemento(currentEntidad);
                enviarMensajeCrud(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                //enviarMensaje();

            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }


        private void XImprimir()
        {
            //throw new NotImplementedException();
        }

        public void enviarMensajeApertura()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(true, tokenEnvioPlanificacion);
        }

        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPlanificacion);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        #endregion

        #region Lanzado de  comando

        private void iniciarComando ()
        {
            //cursorWindow = Cursors.Wait;
                 Mouse.OverrideCursor = Cursors.Wait;
                 Messenger.Default.Register<int>(this, tokenRecepcionController,(controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
                 Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
                 accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionController);
            Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
        }


        #endregion Fin de comando

    }
}