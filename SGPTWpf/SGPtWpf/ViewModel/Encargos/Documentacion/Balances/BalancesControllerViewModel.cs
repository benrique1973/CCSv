using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Linq;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Globalization;
using CapaDatos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances
{
    public sealed class BalancesControllerViewModel : ViewModeloBase
    {

            #region Propiedades privadas

            private MetroDialogSettings configuracionDialogo;

            #region tokenEnvioController

            private string _tokenEnvioController;
            private string tokenEnvioController
            {
                get { return _tokenEnvioController; }
                set { _tokenEnvioController = value; }
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

        public static int Errors { get; set; }


            #region FuenteCierre

            private int _fuenteCierre;
            private int fuenteCierre
            {
                get { return _fuenteCierre; }
                set { _fuenteCierre = value; }
            }

            #endregion

            #region FuenteLlamada

            private int _FuenteLlamada;
            private int FuenteLlamada
            {
                get { return _FuenteLlamada; }
                set { _FuenteLlamada = value; }
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



            private DialogCoordinator dlg;

            #region opcionMenu

            private int _opcionMenu;
            private int opcionMenu
            {
                get { return _opcionMenu; }
                set { _opcionMenu = value; }
            }

            #endregion

            #region codigoContableValido

            private bool _codigoContableValido;
            private bool codigoContableValido
            {
                get { return _codigoContableValido; }
                set { _codigoContableValido = value; }
            }

        #endregion

            #endregion

            #region Lista de entidades

            #region ViewModel Properties : listaBitacora

        public const string listaBitacoraPropertyName = "listaBitacora";

        private ObservableCollection<BitacoraModelo> _listaBitacora;

        public ObservableCollection<BitacoraModelo> listaBitacora
        {
            get
            {
                return _listaBitacora;
            }
            set
            {
                if (_listaBitacora == value) return;

                _listaBitacora = value;

                RaisePropertyChanged(listaBitacoraPropertyName);
            }
        }

        #endregion

            #region ViewModel Properties : listaBCEncargos

        public const string listaBCEncargosPropertyName = "listaBCEncargos";

            private ObservableCollection<BalanceModelo> _listaBCEncargos;

            public ObservableCollection<BalanceModelo> listaBCEncargos
            {
                get
                {
                    return _listaBCEncargos;
                }
                set
                {
                    if (_listaBCEncargos == value) return;

                    _listaBCEncargos = value;

                    RaisePropertyChanged(listaBCEncargosPropertyName);
                }
            }

            #endregion

            #region ViewModel Properties : listaEntidadSeleccion

            public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

            private ObservableCollection<BalanceModelo> _listaEntidadSeleccion;

            public ObservableCollection<BalanceModelo> listaEntidadSeleccion
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

            #region ViewModel Properties : listaBalanceModelo

            public const string listaBalanceModeloPropertyName = "listaBalanceModelo";

            private ObservableCollection<BalanceModelo> _listaBalanceModelo;

            public ObservableCollection<BalanceModelo> listaBalanceModelo
            {
                get
                {
                    return _listaBalanceModelo;
                }
                set
                {
                    if (_listaBalanceModelo == value) return;

                    _listaBalanceModelo = value;

                    RaisePropertyChanged(listaBalanceModeloPropertyName);
                }
            }

            #endregion



            #region ViewModel Properties : listaCatalogoCuentaSeleccion

            public const string listaCatalogoCuentaSeleccionPropertyName = "listaCatalogoCuentaSeleccion";

            private ObservableCollection<BalanceModelo> _listaBalanceSeleccion;

            public ObservableCollection<BalanceModelo> listaCatalogoCuentaSeleccion
            {
                get
                {
                    return _listaBalanceSeleccion;
                }
                set
                {
                    if (_listaBalanceSeleccion == value) return;

                    _listaBalanceSeleccion = value;

                    RaisePropertyChanged(listaCatalogoCuentaSeleccionPropertyName);
                }
            }

            #endregion

            #region ViewModel Properties : listaClaseBalance

            public const string listaClaseBalancePropertyName = "listaClaseBalance";

            private ObservableCollection<ClaseBalanceModelo> _listaClaseBalance;

            public ObservableCollection<ClaseBalanceModelo> listaClaseBalance
            {
                get
                {
                    return _listaClaseBalance;
                }
                set
                {
                    if (_listaClaseBalance == value) return;

                    _listaClaseBalance = value;

                    RaisePropertyChanged(listaClaseBalancePropertyName);
                }
            }

            #endregion

            #region ViewModel Properties : listaClaseBalanceSeleccion

            public const string listaClaseBalanceSeleccionPropertyName = "listaClaseBalanceSeleccion";

            private ObservableCollection<ClaseBalanceModelo> _listaClaseBalanceSeleccion;

            public ObservableCollection<ClaseBalanceModelo> listaClaseBalanceSeleccion
            {
                get
                {
                    return _listaClaseBalanceSeleccion;
                }
                set
                {
                    if (_listaClaseBalanceSeleccion == value) return;

                    _listaClaseBalanceSeleccion = value;

                    RaisePropertyChanged(listaClaseBalanceSeleccionPropertyName);
                }
            }

        #endregion

            #region ViewModel Properties : listaEntidadSeleccionCb

        public const string listaEntidadSeleccionCbPropertyName = "listaEntidadSeleccionCb";

        private ObservableCollection<ClaseBalanceModelo> _listaEntidadSeleccionCb;

        public ObservableCollection<ClaseBalanceModelo> listaEntidadSeleccionCb
        {
            get
            {
                return _listaEntidadSeleccionCb;
            }
            set
            {
                if (_listaEntidadSeleccionCb == value) return;

                _listaEntidadSeleccionCb = value;

                RaisePropertyChanged(listaEntidadSeleccionCbPropertyName);
            }
        }

        #endregion

            #region ViewModel Properties : listaPeriodo

        public const string listaPeriodoPropertyName = "listaPeriodo";

            private ObservableCollection<PeriodoModelo> _listaPeriodo;

            public ObservableCollection<PeriodoModelo> listaPeriodo
            {
                get
                {
                    return _listaPeriodo;
                }
                set
                {
                    if (_listaPeriodo == value) return;

                    _listaPeriodo = value;

                    RaisePropertyChanged(listaPeriodoPropertyName);
                }
            }

        #endregion

            #region ViewModel Properties : listaEntidadSeleccionPeriodo

        public const string listaEntidadSeleccionPeriodoPropertyName = "listaEntidadSeleccionPeriodo";

        private ObservableCollection<PeriodoModelo> _listaEntidadSeleccionPeriodo;

        public ObservableCollection<PeriodoModelo> listaEntidadSeleccionPeriodo
        {
            get
            {
                return _listaEntidadSeleccionPeriodo;
            }
            set
            {
                if (_listaEntidadSeleccionPeriodo == value) return;

                _listaEntidadSeleccionPeriodo = value;

                RaisePropertyChanged(listaEntidadSeleccionPeriodoPropertyName);
            }
        }

        #endregion

            #region propiedades Clase para display

        #region  Primary key idCorrelativoCB

        public const string idCorrelativoCBPropertyName = "idCorrelativoCB";

            private int _idCorrelativoCB = 0;

            public int idCorrelativoCB
            {
                get
                {
                    return _idCorrelativoCB;
                }

                set
                {
                    if (_idCorrelativoCB == value)
                    {
                        return;
                    }

                    _idCorrelativoCB = value;
                    RaisePropertyChanged(idCorrelativoCBPropertyName);
                }
            }

            #endregion

            #region descripcionCb Clase balance

            public const string descripcionCbPropertyName = "descripcionCb";

            private string _descripcionCb = string.Empty;

            public string descripcionCb
            {
                get
                {
                    return _descripcionCb;
                }

                set
                {
                    if (_descripcionCb == value)
                    {
                        return;
                    }

                    _descripcionCb = value;
                    RaisePropertyChanged(descripcionCbPropertyName);
                }
            }


        #endregion

            #region descripcionPeriodo clase cuenta

        public const string descripcionPeriodoPropertyName = "descripcionPeriodo";

            private string _descripcionPeriodo = string.Empty;

            public string descripcionPeriodo
            {
                get
                {
                    return _descripcionPeriodo;
                }

                set
                {
                    if (_descripcionPeriodo == value)
                    {
                        return;
                    }

                _descripcionPeriodo = value;
                    RaisePropertyChanged(descripcionPeriodoPropertyName);
                }
            }


        #endregion

            #region idCorrelativoPeriodo

        public const string idCorrelativoPeriodoPropertyName = "idCorrelativoPeriodo";

        private int _idCorrelativoPeriodo = 0;

        public int idCorrelativoPeriodo
        {
            get
            {
                return _idCorrelativoPeriodo;
            }

            set
            {
                if (_idCorrelativoPeriodo == value)
                {
                    return;
                }

                _idCorrelativoPeriodo = value;
                RaisePropertyChanged(idCorrelativoPeriodoPropertyName);
            }
        }

        #endregion

        #endregion
    
            #region Sistema contable

        #region ViewModel Property : currentSistemaContable

        public const string currentSistemaContablePropertyName = "currentSistemaContable";

            private SistemaContableModelo _currentSistemaContable;

            public SistemaContableModelo currentSistemaContable
            {
                get
                {
                    return _currentSistemaContable;
                }

                set
                {
                    if (_currentSistemaContable == value) return;

                    _currentSistemaContable = value;

                    // Update bindings, no broadcast
                    RaisePropertyChanged(currentSistemaContablePropertyName);
                }
            }

            #endregion

            #region Propiedades Balance

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

            #region idbalance

            public const string idbalancePropertyName = "idbalance";

            private int _idbalance = 0;

            public int idbalance
            {
                get
                {
                    return _idbalance;
                }

                set
                {
                    if (_idbalance == value)
                    {
                        return;
                    }

                    _idbalance = value;
                    RaisePropertyChanged(idbalancePropertyName);
                }
            }

            #endregion

            #region idcb

            public const string idcbPropertyName = "idcb";

            private int _idcb = 0;

            public int idcb
            {
                get
                {
                    return _idcb;
                }

                set
                {
                    if (_idcb == value)
                    {
                        return;
                    }

                    _idcb = value;
                    RaisePropertyChanged(idcbPropertyName);
                }
            }

            #endregion


            #region fechabalancebalance

            public const string fechabalancebalancePropertyName = "fechabalancebalance";

            private DateTime _fechabalancebalance = DateTime.Now;

            public DateTime fechabalancebalance
            {
                get
                {
                    return _fechabalancebalance;
                }

                set
                {
                    if (_fechabalancebalance == value)
                    {
                        return;
                    }

                    _fechabalancebalance = value;
                    RaisePropertyChanged(fechabalancebalancePropertyName);
                }
            }

        #endregion

            #region fechaDbalancebalance

            public const string fechaDbalancebalancePropertyName = "fechaDbalancebalance";

            private DateTime _fechaDbalancebalance = DateTime.Now;

            public DateTime fechaDbalancebalance
            {
                get
                {
                    return _fechaDbalancebalance;
                }

                set
                {
                    if (_fechaDbalancebalance == value)
                    {
                        return;
                    }

                    _fechaDbalancebalance = value;
                    RaisePropertyChanged(fechaDbalancebalancePropertyName);
                }
            }

            #endregion

            #region estadobalance

        public const string estadobalancePropertyName = "estadobalance";

            private string _estadobalance = string.Empty;

            public string estadobalance
            {
                get
                {
                    return _estadobalance;
                }

                set
                {
                    if (_estadobalance == value)
                    {
                        return;
                    }

                    _estadobalance = value;
                    RaisePropertyChanged(estadobalancePropertyName);
                }
            }

            #endregion

            #region idscbalance

            public const string nombreHerramientaPropertyName = "idscbalance";

            private int _nombreHerramienta = 0;

            public int idscbalance
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

            #region descripcionCbEtapaEncargo

            public const string descripcionCbEtapaEncargoPropertyName = "descripcionCbEtapaEncargo";

            private string _descripcionCbEtapaEncargo = string.Empty;

            public string descripcionCbEtapaEncargo
            {
                get
                {
                    return _descripcionCbEtapaEncargo;
                }

                set
                {
                    if (_descripcionCbEtapaEncargo == value)
                    {
                        return;
                    }

                    _descripcionCbEtapaEncargo = value;
                    RaisePropertyChanged(descripcionCbEtapaEncargoPropertyName);
                }
            }

            #endregion

            #region descripcionCbTipoClienteEncargo

            public const string descripcionCbTipoClienteEncargoPropertyName = "descripcionCbTipoClienteEncargo";

            private string _descripcionCbTipoClienteEncargo = string.Empty;

            public string descripcionCbTipoClienteEncargo
            {
                get
                {
                    return _descripcionCbTipoClienteEncargo;
                }

                set
                {
                    if (_descripcionCbTipoClienteEncargo == value)
                    {
                        return;
                    }

                    _descripcionCbTipoClienteEncargo = value;
                    RaisePropertyChanged(descripcionCbTipoClienteEncargoPropertyName);
                }
            }


            #endregion

            #region descripcionCbTipoAuditoria

            public const string descripcionCbTipoAuditoriaPropertyName = "descripcionCbTipoAuditoria";

            private string _descripcionCbTipoAuditoria = string.Empty;

            public string descripcionCbTipoAuditoria
            {
                get
                {
                    return _descripcionCbTipoAuditoria;
                }

                set
                {
                    if (_descripcionCbTipoAuditoria == value)
                    {
                        return;
                    }

                    _descripcionCbTipoAuditoria = value;
                    RaisePropertyChanged(descripcionCbTipoAuditoriaPropertyName);
                }
            }


        #endregion

        #endregion

        #region Otras propiedades



        #endregion

        #endregion

        #endregion Lista de entidades

            #region Entidades en uso de encargos

            #region ViewModel Property : currentEntidadBitacora

            public const string currentEntidadBitacoraPropertyName = "currentEntidadBitacora";

            private BitacoraModelo _currentEntidadBitacora;

            public BitacoraModelo currentEntidadBitacora
            {
                get
                {
                    return _currentEntidadBitacora;
                }

                set
                {
                    if (_currentEntidadBitacora == value) return;

                    _currentEntidadBitacora = value;

                    // Update bindings, no broadcast
                    RaisePropertyChanged(currentEntidadBitacoraPropertyName);
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

            #region ViewModel Property : selectedBCImportar

            public const string selectedBCImportarPropertyName = "selectedBCImportar";

            private BalanceModelo _selectedBCImportar;

            public BalanceModelo selectedBCImportar
            {
                get
                {
                    return _selectedBCImportar;
                }

                set
                {
                    if (_selectedBCImportar == value) return;

                    _selectedBCImportar = value;

                    // Update bindings, no broadcast
                    RaisePropertyChanged(selectedBCImportarPropertyName);
                }
            }

            #endregion

            #region ViewModel Property : eleccionBCImportar

            public const string eleccionBCImportarPropertyName = "eleccionBCImportar";

                private BalanceModelo _eleccionBCImportar;

                public BalanceModelo eleccionBCImportar
                {
                    get
                    {
                        return _eleccionBCImportar;
                    }

                    set
                    {
                        if (_eleccionBCImportar == value) return;

                        _eleccionBCImportar = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(eleccionBCImportarPropertyName);
                    }
                }

                #endregion

                #region ViewModel Property : currentEntidad

                public const string currentEntidadPropertyName = "currentEntidad";

                private BalanceModelo _currentEntidad;

                public BalanceModelo currentEntidad
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

                #region ViewModel Property : selectedClaseBalance

                public const string selectedClaseBalancePropertyName = "selectedClaseBalance";

                private ClaseBalanceModelo _selectedClaseBalance;

                public ClaseBalanceModelo selectedClaseBalance
                {
                    get
                    {
                        return _selectedClaseBalance;
                    }

                    set
                    {
                        if (_selectedClaseBalance == value) return;

                        _selectedClaseBalance = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(selectedClaseBalancePropertyName);
                    }
                }

            #endregion

                #region ViewModel Property : eleccionClaseBalance

            public const string eleccionClaseBalancePropertyName = "eleccionClaseBalance";

                private ClaseBalanceModelo _eleccionClaseBalance;

                public ClaseBalanceModelo eleccionClaseBalance
                {
                    get
                    {
                        return _eleccionClaseBalance;
                    }

                    set
                    {
                        if (_eleccionClaseBalance == value) return;

                        _eleccionClaseBalance = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(eleccionClaseBalancePropertyName);
                    }
                }

                #endregion

                #region ViewModel Property : tipoAuditoriaModelo

                public const string tipoAuditoriaModeloPropertyName = "tipoAuditoriaModelo";

                private TipoAuditoriaModelo _tipoAuditoriaModelo;

                public TipoAuditoriaModelo tipoAuditoriaModelo
                {
                    get
                    {
                        return _tipoAuditoriaModelo;
                    }

                    set
                    {
                        if (_tipoAuditoriaModelo == value) return;

                        _tipoAuditoriaModelo = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(tipoAuditoriaModeloPropertyName);
                    }
                }

                #endregion

                #region ViewModel Property : clienteModelo

                public const string clienteModeloPropertyName = "clienteModelo";

                private ClienteModelo _clienteModelo;

                public ClienteModelo clienteModelo
                {
                    get
                    {
                        return _clienteModelo;
                    }

                    set
                    {
                        if (_clienteModelo == value) return;

                        _clienteModelo = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(clienteModeloPropertyName);
                    }
                }

                #endregion

                #region ViewModel Property : selectedPeriodo

                public const string selectedPeriodoPropertyName = "selectedPeriodo";

                private PeriodoModelo _selectedPeriodo;

                public PeriodoModelo selectedPeriodo
                {
                    get
                    {
                        return _selectedPeriodo;
                    }

                    set
                    {
                        if (_selectedPeriodo == value) return;

                        _selectedPeriodo = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(selectedPeriodoPropertyName);
                    }
                }

                #endregion

                #region ViewModel Property : eleccionPeriodo

                public const string eleccionPeriodoPropertyName = "eleccionPeriodo";

                private PeriodoModelo _eleccionPeriodo;

                public PeriodoModelo eleccionPeriodo
                {
                    get
                    {
                        return _eleccionPeriodo;
                    }

                    set
                    {
                        if (_eleccionPeriodo == value) return;

                        _eleccionPeriodo = value;

                        // Update bindings, no broadcast
                        RaisePropertyChanged(eleccionPeriodoPropertyName);
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


            #region visibilidadCuentaPadre

            public const string visibilidadCuentaPadrePropertyName = "visibilidadCuentaPadre";

            private Visibility _visibilidadCuentaPadre = Visibility.Collapsed;

            public Visibility visibilidadCuentaPadre
            {
                get
                {
                    return _visibilidadCuentaPadre;
                }

                set
                {
                    if (_visibilidadCuentaPadre == value)
                    {
                        return;
                    }

                    _visibilidadCuentaPadre = value;
                    RaisePropertyChanged(visibilidadCuentaPadrePropertyName);
                }
            }

            #endregion

            #region visibilidadBitacora

            public const string visibilidadBitacoraPropertyName = "visibilidadBitacora";

            private Visibility _visibilidadBitacora = Visibility.Visible;

            public Visibility visibilidadBitacora
            {
                get
                {
                    return _visibilidadBitacora;
                }

                set
                {
                    if (_visibilidadBitacora == value)
                    {
                        return;
                    }

                    _visibilidadBitacora = value;
                    RaisePropertyChanged(visibilidadBitacoraPropertyName);
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

            #region activarClaseCuenta

            public const string activarClaseCuentaPropertyName = "activarClaseCuenta";

            private bool _activarClaseCuenta = false;

            public bool activarClaseCuenta
            {
                get
                {
                    return _activarClaseCuenta;
                }

                set
                {
                    if (_activarClaseCuenta == value)
                    {
                        return;
                    }

                    _activarClaseCuenta = value;
                    RaisePropertyChanged(activarClaseCuentaPropertyName);
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
            public RelayCommand SeleccionProgramaEncargoCommand { get; set; }
            public RelayCommand CancelarProgramaEncargoCommand { get; set; }
            public RelayCommand<BalanceModelo> SelectionChangedCommand { get; set; }
            public RelayCommand<BalanceModelo> SelectionChangedEncargoCommand { get; set; }
            public RelayCommand<PeriodoModelo> SelPeriodoCommand { get; set; }

            public RelayCommand<ClaseBalanceModelo> SelectionClaseBalanceCommand { get; set; }
            public RelayCommand<BalanceModelo> SelectionImportarChangedCommand { get; set; }


            #endregion


            #region Implementacion comandos

            #region ViewModel Public Methods

            #region Constructores

            public BalancesControllerViewModel()
            {
                enviarMensajeInhabilitar();

                configuracionDialogo = new MetroDialogSettings()
                {
                    AnimateShow = false,
                    AnimateHide = false
                };
                _tokenEnvioController = "datosControllerBalances"; 
                _fuenteCierre = 0;
                _resultadoProceso = 0;
                _opcionMenu = 0;
                _codigoContableValido = true;
                Errors = 0;
                _tokenRecepcionPadre = "datosEDBalances";
                _accesibilidadWindow = false;
                _accesibilidadCuerpo = false;
                _activarClaseCuenta = false;
                _visibilidadConsultar = Visibility.Collapsed;
                _visibilidadCrear = Visibility.Collapsed;
                _visibilidadEditar = Visibility.Collapsed;
                _visibilidadCuentaPadre = Visibility.Collapsed;
                _visibilidadBitacora = Visibility.Collapsed;
                //Suscribiendo el mensaje
                _listaBalanceModelo = new ObservableCollection<BalanceModelo>();
                _listaPeriodo = new ObservableCollection<PeriodoModelo>();
                _listaClaseBalance = new ObservableCollection<ClaseBalanceModelo>();
                _listaBCEncargos = new ObservableCollection<BalanceModelo>();
                _listaEntidadSeleccion = new ObservableCollection<BalanceModelo>();//Lista para inyectarla en la entidad
                _listaBalanceSeleccion = new ObservableCollection<BalanceModelo>();
                _listaClaseBalanceSeleccion = _listaClaseBalance;
                _listaEntidadSeleccionCb = new ObservableCollection<ClaseBalanceModelo>();
                _listaEntidadSeleccionPeriodo = new ObservableCollection<PeriodoModelo>();
                _listaBitacora = new ObservableCollection<BitacoraModelo>();
                _FuenteLlamada = 0;
                Messenger.Default.Register<BalanceMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlDatosMsj(datosMsj));
                //Inicializar el contenido del frame con el detalle de procedimientos
                dlg = new DialogCoordinator();
                RegisterCommands();
                fuenteCierre = 0;
                _currentEncargo = new EncargoModelo();
                _currentEntidad = new BalanceModelo();
                _currentSistemaContable = new SistemaContableModelo();
                _currentEntidadBitacora = new BitacoraModelo();
                _selectedClaseBalance = new ClaseBalanceModelo();
                _selectedPeriodo = new PeriodoModelo();
                _selectedBCImportar = new BalanceModelo();
                _eleccionClaseBalance = new ClaseBalanceModelo();
                _eleccionPeriodo = new PeriodoModelo();
                _eleccionBCImportar = new BalanceModelo();
                _fechaDbalancebalance = DateTime.Now;
            }

            private async void ControlDatosMsj(BalanceMsj datosMsj)
            {
                //Asignacion de  entidades
                currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
                currentUsuario = datosMsj.usuarioModelo;
                currentSistemaContable = datosMsj.sistemaContableModelo;
                opcionMenu = datosMsj.opcionMenuCrud;
                FuenteLlamada = datosMsj.fuenteLlamado;
                //Carga de combo de clase de balance
                listaClaseBalance = new ObservableCollection<ClaseBalanceModelo>(ClaseBalanceModelo.GetAllToDisplay());
                listaEntidadSeleccionCb = listaClaseBalance;
                selectedClaseBalance.listaEntidadSeleccionCb = listaEntidadSeleccionCb;
                //Carga de combo de periodicidad
                listaPeriodo = new ObservableCollection<PeriodoModelo>(PeriodoModelo.GetAllDisplay());
                listaEntidadSeleccionPeriodo = listaPeriodo;
                selectedPeriodo.listaEntidadSeleccionPeriodo = listaPeriodo;
                fechaDbalancebalance = MetodosModelo.convertirFecha(currentEncargo.fechafinperauditencargo);

                //if (opcionMenu != 7)
                //{
                    currentEntidad = datosMsj.balanceModelo;
                    //Inyeccion de listado de cuentas
                    currentEntidad.listaEntidadSeleccion = datosMsj.listaBalanceModelo;
                    listaEntidadSeleccion = currentEntidad.listaEntidadSeleccion;
                    listaBalanceModelo = datosMsj.listaBalanceModelo;
                    listaBitacora = currentEntidad.listaBitacora;
                //}
                switch (datosMsj.opcionMenuCrud)
                {
                    case 1://Crear 
                        encabezadoPantalla = "Introduzca los datos para el balance";
                        nombreprogramaVista = "*Nombre de balance";
                        visibilidadBitacora = Visibility.Collapsed;
                        visibilidadCrear = Visibility.Visible;
                        visibilidadCopiar = Visibility.Collapsed;
                        //Propiedades de presentacion
                        activarCaptura = true;
                        activarCrear = true;
                        activarConsultar = false;
                        activarEditar = false;
                        accesibilidadWindow = true;
                        break;
                    case 2://Editar
                        encabezadoPantalla = "Actualice los datos para el balance";
                        nombreprogramaVista = "*Nombre de balance";

                        selectedClaseBalance = listaClaseBalance.Single(i => i.idCb == currentEntidad.idcb);
                        selectedClaseBalance.listaEntidadSeleccionCb = listaEntidadSeleccionCb;

                        selectedPeriodo = listaPeriodo.Single(i => i.idCorrelativoPeriodo == currentEntidad.idperiodos);
                        //listaCuentasFiltradaModelo = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAllByIdElementoYIdClaseCuenta(selectedClaseBalance,selectedPeriodoModelo,currentSistemaContable));
                        eleccionPeriodo = currentEntidad.periodoModelo;
                        eleccionClaseBalance = currentEntidad.claseBalanceModelo;
                        activarClaseCuenta = true;

                        fechaDbalancebalance = MetodosModelo.convertirFecha(currentEntidad.fechabalancebalance);


                        //Enviar el elemento para recuperar el detalle

                        encabezadoPantalla = "Actualice los datos";
                        activarCaptura = true;
                        visibilidadConsultar = Visibility.Collapsed;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Visible;

                        activarCrear = false;
                        activarConsultar = false;
                        activarEditar = true;
                        accesibilidadWindow = true;
                        break;
                    case 3://Consultar
                        encabezadoPantalla = "Datos del balance";
                        nombreprogramaVista = "*Nombre de balance";

                        selectedClaseBalance = listaClaseBalance.Single(i => i.idCb == currentEntidad.idcb);
                        selectedClaseBalance.listaEntidadSeleccionCb = listaEntidadSeleccionCb;

                        selectedPeriodo = listaPeriodo.Single(i => i.id == currentEntidad.idperiodos);
                        //listaCuentasFiltradaModelo = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAllByIdElementoYIdClaseCuenta(selectedClaseBalance,selectedPeriodoModelo,currentSistemaContable));
                        eleccionPeriodo = currentEntidad.periodoModelo;
                        eleccionClaseBalance = currentEntidad.claseBalanceModelo;

                        fechaDbalancebalance = MetodosModelo.convertirFecha(currentEntidad.fechabalancebalance);
                        activarClaseCuenta = true;
                        accesibilidadWindow = false;
                        accesibilidadCuerpo = false;
                        //Enviar datos al detalle
                        //Enviar el elemento para recuperar el detalle
                        encabezadoPantalla = "Datos del registro";
                        activarCaptura = false;
                        visibilidadConsultar = Visibility.Visible;
                        visibilidadCrear = Visibility.Collapsed;
                        visibilidadEditar = Visibility.Collapsed;
                        visibilidadBitacora = Visibility.Visible;
                        activarCrear = false;
                        activarConsultar = true;
                        activarEditar = false;
                        break;
                    case 7://Importar de programas de otros encargos
                        //Se excluye los balances del sistema contable del encargo en uso porque seria redundante
                        listaBCEncargos = new ObservableCollection<BalanceModelo>(BalanceModelo.GetAllForImportacion(currentEncargo.idnitcliente, currentSistemaContable.idsc));
                        //CurrentEncargo es el encargo en uso que da el idsc del sistema contable y ademas proporciona el idnit del cliente para  localizar todos los encargos que tengan ese nit
                        if (listaBCEncargos.Count > 0)
                        {
                            accesibilidadWindow = true;
                            encabezadoPantalla = "Seleccion el balance del encargo a importar";
                            nombreprogramaVista = "Balances disponibles";
                            visibilidadBitacora = Visibility.Collapsed;
                            visibilidadCrear = Visibility.Collapsed;
                            visibilidadCopiar = Visibility.Visible;//Gestional la presentacion del datagrid
                                                                   //Propiedades de presentacion
                            activarCaptura = true;
                            activarCrear = true;
                            activarConsultar = false;
                            activarEditar = false;
                        }
                        else
                        {
                            var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            fuenteCierre = 1;
                            resultadoProceso = 0;//1 para  crear
                            CloseWindow();
                        }
                        break;
                }
                Messenger.Default.Unregister<BalanceMsj>(this, tokenRecepcionPadre);
                Mouse.OverrideCursor = null;
            }

            #endregion

            private async void Cancelar()
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

            private void OkCierre()
            {
                fuenteCierre = 1;
                CloseWindow();

            }

            private void Salir()
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
                //listaDetallePrograma = null;
            }


            public async void CopiarM()
            {
                if (BalanceModelo.DeleteBorradoLogico(2, currentEntidad))
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
                }
            }

        public async void Guardar()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
            try
            {
                currentEntidad.fechabalancebalance = MetodosModelo.homologacionFecha(fechaDbalancebalance.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
                if (VerificarClaveCompuesta(currentEntidad)==0)
                {
                    switch (BalanceModelo.Insert(currentEntidad))
                    {
                        case 0://No se pudo insertar
                            Mouse.OverrideCursor = null;
                            accesibilidadWindow = true;
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            break;
                        case 1://Se inserto con éxito
                            var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                            controller.SetIndeterminate();
                            await TaskEx.Delay(1000);
                            await controller.CloseAsync();
                            fuenteCierre = 1;
                            resultadoProceso = 1;//1 para  crear
                            CloseWindow();
                            break;
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                    await dlg.ShowMessageAsync(this, "El balance debe ser únicos pueden diferir en tipo, periodicidad y fecha", "modifique el parámetro o seleccione el que sustituirá");
                }
            }
            catch (Exception)
            {
                //Mouse.OverrideCursor = null;
                //accesibilidadWindow = true;
                //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                this.except3();
            }
        }

        private int VerificarClaveCompuesta(BalanceModelo currentEntidad)
        {
            int resultado = 0;
            string clave = currentEntidad.idcb + "-" + currentEntidad.idperiodos + "-" + currentEntidad.fechabalancebalance + "-" + currentEntidad.idscbalance;
            string claveC = "";
            if (opcionMenu == 1)
            {
                for (int i = 0; i < listaBalanceModelo.Count(); i++)
                {
                    claveC = listaBalanceModelo[i].idcb + "-" + listaBalanceModelo[i].idperiodos + "-" + listaBalanceModelo[i].fechabalancebalance + "-" + listaBalanceModelo[i].idscbalance;
                    if (claveC == clave)
                    {
                        resultado = resultado + 1;
                        i = listaBalanceModelo.Count();
                    }
                    claveC = "";
                }
            }
            else
            {
                for (int i = 0; i < listaBalanceModelo.Count(); i++)
                {
                    claveC = listaBalanceModelo[i].idcb + "-" + listaBalanceModelo[i].idperiodos + "-" + listaBalanceModelo[i].fechabalancebalance + "-" + listaBalanceModelo[i].idscbalance;
                    if (claveC == clave)
                    {
                        resultado = resultado + 1;
                    }
                    claveC = "";
                    if (resultado > 1)
                    {
                        i = listaBalanceModelo.Count();
                    }
                }
            }
            return resultado;
        }

        private async void except3()
        {
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
        }


           private async void ImportarCatalogoEncargos()
            {
                bool continuarProceso = false;
                Mouse.OverrideCursor = Cursors.Wait;
                accesibilidadWindow = false;
            //Verificar que en el encargo actual exista catalogo, si no pedir que se importe de encargo escogido y termina la operacion

            if (CatalogoCuentasModelo.GetAllCountByIdSc(currentSistemaContable.idsc) > 0)
            {
                //Verificar que ambos catalogos sean iguales o que  el catalogo de destino  contenga al de origen
                if (CatalogoCuentasModelo.validarConversionCatalogo(eleccionBCImportar.idscbalance, currentSistemaContable.idsc))
                {
                    //Si son  iguales procede o si el de destino contiene el  de origen
                    continuarProceso = true;
                }
                else
                {
                    //Si el catalogo de origen es  mayor que el de el destino se sugiere realizar la importacion del catalogo.
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                    resultadoProceso = 0;
                    await dlg.ShowMessageAsync(this, "El catalogo de origen es diferente al de destino", "No es posible importar, primero importe el catalogo");
                }
            }
            else
            {
                Mouse.OverrideCursor = null;
                accesibilidadWindow = true;
                resultadoProceso = 0;
                await dlg.ShowMessageAsync(this, "El encargo actual no contiene un catalogo, debe crearlo o importarlo", "Para importarlo vaya a catalogo opción importar");
            }
            if (continuarProceso)
            {
                //Verificar que existan datos
                if (eleccionBCImportar != null && currentEncargo != null)
                {
                    //Completar los datos para crear el  registro y obtener el nuevo id
                    currentEntidad.idcb = eleccionBCImportar.idcb;
                    currentEntidad.idperiodos = eleccionBCImportar.idperiodos;
                    currentEntidad.fechabalancebalance = eleccionBCImportar.fechabalancebalance;
                    if (VerificarClaveCompuesta(currentEntidad) == 0)
                    {
                        switch (BalanceModelo.Insert(currentEntidad))
                        {
                            case 0://No se pudo insertar
                                Mouse.OverrideCursor = null;
                                accesibilidadWindow = true;
                                await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                continuarProceso = false;
                                break;
                            case 1://Se inserto con éxito
                                continuarProceso = true;//Debe insertarse el detalle
                                break;
                        }
                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        accesibilidadWindow = true;
                        await dlg.ShowMessageAsync(this, "El balance debe ser únicos pueden diferir en tipo, periodicidad y fecha", "ya hay un balance con iguales características");
                        continuarProceso = false;
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                    resultadoProceso = 0;
                    await dlg.ShowMessageAsync(this, "Debe seleccionar un  encargo", "");
                    continuarProceso = false;
                }
            }
            if (continuarProceso)
            {
                //Importar el detalle
                ObservableCollection<detallebalance> listaDetalle = DetalleBalanceModelo.GetAllCapaDatosByidBc(eleccionBCImportar.idbalance);
                //Verificar que contiene registros
                if (listaDetalle.Count > 0)
                {
                    //Sustituir el id del balance
                    foreach (detallebalance item in listaDetalle)
                    {
                        //Sustitucion  del id del balance
                        item.idbalance = currentEntidad.idbalance;
                        //Reemplaso del id del detalle
                        item.iddb = 0;
                    }
                    //Guardado del registro
                    if (DetalleBalanceModelo.InsertByRange(listaDetalle) == 1)
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 1;//1 para  crear
                        CloseWindow();
                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        accesibilidadWindow = true;
                        await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                    }
                }
                else
                {
                    //No  hay registros
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                    resultadoProceso = 0;
                    await dlg.ShowMessageAsync(this, "El balance  seleccionado no contiene registros", "Seleccione otro o cancele");
                    //Se borra el  registro creado para dejar en forma consistente
                    BalanceModelo.Delete(currentEntidad.idbalance);
                }
            }
            }

            private async void except2()
            {
                var controller = await dlg.ShowProgressAsync(this, "Error en la actualizacion", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                controller.SetIndeterminate();
                await TaskEx.Delay(1000);
                await controller.CloseAsync();
                //continuarProceso = false;
            }

            private async void except1()
            {
                Mouse.OverrideCursor = null;
                accesibilidadWindow = true;
                resultadoProceso = 0;
                await dlg.ShowMessageAsync(this, "Error en las sustituciones", "");
                //continuarProceso = false;
            }



        public async void Modificar()
        {
            try
            {

                currentEntidad.fechabalancebalance = MetodosModelo.homologacionFecha(fechaDbalancebalance.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
                if (VerificarClaveCompuesta(currentEntidad) == 1)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    accesibilidadWindow = false;
                    if (BalanceModelo.UpdateModelo(currentEntidad, true))
                    {
                        var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 2;//2 para  modificar;
                        CloseWindow();
                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "");
                        accesibilidadWindow = true;
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    await dlg.ShowMessageAsync(this, "El balance debe ser únicos pueden diferir en tipo, periodicidad y fecha", "modifique el parámetro o seleccione el que sustituirá");
                    accesibilidadWindow = true;
                }
            }
            catch (Exception)
            {
                this.except4();
                //Mouse.OverrideCursor = null;
                //await dlg.ShowMessageAsync(this, "Error en la operacion", "reporte el  error");
                //accesibilidadWindow = true;

            }
        }

        private async void except4()
        {
            Mouse.OverrideCursor = null;
            await dlg.ShowMessageAsync(this, "Error en la operacion", "reporte el  error");
            accesibilidadWindow = true;
        }
            #endregion

            #region Mensajes

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

            #endregion

            #endregion

            #region Metodos de apoyo

            public bool CanSaveNuevo()
            {
                bool evaluar = false;

                if (currentEntidad == null)
                {
                    return evaluar;
                }
                else
                {
                evaluar = (Errors == 0)
                && selectedClaseBalance.idCb != 0
                && selectedPeriodo.id != 0;

                    return evaluar;
                }
            }
            public bool CanSave()
            {
                bool evaluar = false;

                if (currentEntidad == null)
                {
                    return evaluar;
                }
                else
                {
                evaluar = (Errors == 0)
                && selectedClaseBalance.idCb != 0
                && selectedPeriodo.id != 0;
                    return evaluar;
                }
            }

            private bool canImportForEncargos()
            {
                if (eleccionBCImportar != null)
                {
                    return true;
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
                EditarCommand = new RelayCommand(Modificar, CanSave);
                SeleccionProgramaEncargoCommand = new RelayCommand(ImportarCatalogoEncargos, canImportForEncargos);
                GuardarCommand = new RelayCommand(Guardar, CanSaveNuevo);//Caso de nuevo registro
                CancelarCommand = new RelayCommand(Cancelar);
                CancelarProgramaEncargoCommand = new RelayCommand(Cancelar);
                OkCommand = new RelayCommand(OkCierre);
                SalirCommand = new RelayCommand(Salir);

                SelectionChangedCommand = new RelayCommand<BalanceModelo>(entidad =>
                {
                    if (entidad == null) return;
                    currentEntidad = entidad;
                });

                SelectionChangedEncargoCommand = new RelayCommand<BalanceModelo>(entidad =>
                {
                    if (entidad == null) return;
                    selectedBCImportar = entidad;
                });
                SelPeriodoCommand = new RelayCommand<PeriodoModelo>(entidad =>
                {

                    if (entidad == null) return;
                    eleccionPeriodo = entidad;
                    currentEntidad.idperiodos = entidad.id;
                    currentEntidad.periodicidadperiodos = entidad.descripcion;
                    currentEntidad.periodoModelo = entidad;
                    //visibilidadCuentaPadre = Visibility.Collapsed;
                    //Filtrar la lista según la selección
                });
               SelectionClaseBalanceCommand = new RelayCommand<ClaseBalanceModelo>(entidad =>
                {
                    if (entidad == null) return;
                    eleccionClaseBalance = entidad;
                    if (entidad.idCb != 0)
                    {
                        currentEntidad.idcb = entidad.idCb;
                        currentEntidad.claseBalanceModelo = entidad;
                        //activarClaseCuenta = true;
                    }
                    else
                    {
                        currentEntidad.idcb = entidad.id;
                    }
                });


                SelectionImportarChangedCommand = new RelayCommand<BalanceModelo>(entidad =>
                {
                    if (entidad == null) return;
                    eleccionBCImportar = entidad;
                });

            }





            #endregion

        }
}

//Correccion