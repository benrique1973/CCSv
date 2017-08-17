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
using CapaDatos;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances
{
    public sealed class DetalleBalanceControllerViewModel : ViewModeloBase
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

        public static int Errors { get; set; }


        #region FuenteCierre

        private int _fuenteCierre;
        private int fuenteCierre
        {
            get { return _fuenteCierre; }
            set { _fuenteCierre = value; }
        }

        #endregion

        //Monitorea que el  codigo contable sea correcto o que la cuenta no contenga ya datos
        #region cuentaValida

        private bool _cuentaValida;
        private bool cuentaValida
        {
            get { return _cuentaValida; }
            set { _cuentaValida = value; }
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

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
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

        #region ViewModel Properties : listaEncargos

        public const string listaEncargosPropertyName = "listaEncargos";

        private ObservableCollection<EncargoModelo> _listaEncargos;

        public ObservableCollection<EncargoModelo> listaEncargos
        {
            get
            {
                return _listaEncargos;
            }
            set
            {
                if (_listaEncargos == value) return;

                _listaEncargos = value;

                RaisePropertyChanged(listaEncargosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<CatalogoCuentasModelo> _listaEntidadSeleccion;

        public ObservableCollection<CatalogoCuentasModelo> listaEntidadSeleccion
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

        #region ViewModel Properties : listaDetalleBalanceModelo

        public const string listaDetalleBalanceModeloPropertyName = "listaDetalleBalanceModelo";

        private ObservableCollection<DetalleBalanceModelo> _listaDetalleBalanceModelo;

        public ObservableCollection<DetalleBalanceModelo> listaDetalleBalanceModelo
        {
            get
            {
                return _listaDetalleBalanceModelo;
            }
            set
            {
                if (_listaDetalleBalanceModelo == value) return;

                _listaDetalleBalanceModelo = value;

                RaisePropertyChanged(listaDetalleBalanceModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCatalogoCuentasModelo

        public const string listaCatalogoCuentasModeloPropertyName = "listaCatalogoCuentasModelo";

        private ObservableCollection<CatalogoCuentasModelo> _listaCatalogoCuentasModelo;

        public ObservableCollection<CatalogoCuentasModelo> listaCatalogoCuentasModelo
        {
            get
            {
                return _listaCatalogoCuentasModelo;
            }
            set
            {
                if (_listaCatalogoCuentasModelo == value) return;

                _listaCatalogoCuentasModelo = value;

                RaisePropertyChanged(listaCatalogoCuentasModeloPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaElementos

        public const string listaElementosPropertyName = "listaElementos";

        private ObservableCollection<ElementoModelo> _listaElementos;

        public ObservableCollection<ElementoModelo> listaElementos
        {
            get
            {
                return _listaElementos;
            }
            set
            {
                if (_listaElementos == value) return;

                _listaElementos = value;

                RaisePropertyChanged(listaElementosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaElementoSeleccion

        public const string listaElementoSeleccionPropertyName = "listaElementoSeleccion";

        private ObservableCollection<ElementoModelo> _listaElementoSeleccion;

        public ObservableCollection<ElementoModelo> listaElementoSeleccion
        {
            get
            {
                return _listaElementoSeleccion;
            }
            set
            {
                if (_listaElementoSeleccion == value) return;

                _listaElementoSeleccion = value;

                RaisePropertyChanged(listaElementoSeleccionPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaClaseCuenta

        public const string listaClaseCuentaPropertyName = "listaClaseCuenta";

        private ObservableCollection<ClaseCuentaModelo> _listaClaseCuenta;

        public ObservableCollection<ClaseCuentaModelo> listaClaseCuenta
        {
            get
            {
                return _listaClaseCuenta;
            }
            set
            {
                if (_listaClaseCuenta == value) return;

                _listaClaseCuenta = value;

                RaisePropertyChanged(listaClaseCuentaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCuentasFiltradaModelo

        public const string listaCuentasFiltradaModeloPropertyName = "listaCuentasFiltradaModelo";

        private ObservableCollection<CatalogoCuentasModelo> _listaCuentasFiltradaModelo;

        public ObservableCollection<CatalogoCuentasModelo> listaCuentasFiltradaModelo
        {
            get
            {
                return _listaCuentasFiltradaModelo;
            }
            set
            {
                if (_listaCuentasFiltradaModelo == value) return;

                _listaCuentasFiltradaModelo = value;

                RaisePropertyChanged(listaCuentasFiltradaModeloPropertyName);
            }
        }

        #endregion

        #region propiedades Elementos Contables

        #region  Primary key numeroCorrelativoElemento

        public const string numeroCorrelativoElementoPropertyName = "numeroCorrelativoElemento";

        private int _numeroCorrelativoElemento = 0;

        public int numeroCorrelativoElemento
        {
            get
            {
                return _numeroCorrelativoElemento;
            }

            set
            {
                if (_numeroCorrelativoElemento == value)
                {
                    return;
                }

                _numeroCorrelativoElemento = value;
                RaisePropertyChanged(numeroCorrelativoElementoPropertyName);
            }
        }

        #endregion

        #region descripcion Elemento contable

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

        #region descripcionccuentas clase cuenta

        public const string descripcionccuentasPropertyName = "descripcionccuentas";

        private string _descripcionccuentas = string.Empty;

        public string descripcionccuentas
        {
            get
            {
                return _descripcionccuentas;
            }

            set
            {
                if (_descripcionccuentas == value)
                {
                    return;
                }

                _descripcionccuentas = value;
                RaisePropertyChanged(descripcionccuentasPropertyName);
            }
        }


        #endregion

        #region digitosElementoModelo

        public const string digitosElementoModeloPropertyName = "digitosElementoModelo";

        private DigitosModelo _digitosElementoModelo;

        public DigitosModelo digitosElementoModelo
        {
            get
            {
                return _digitosElementoModelo;
            }

            set
            {
                if (_digitosElementoModelo == value)
                {
                    return;
                }

                _digitosElementoModelo = value;
                RaisePropertyChanged(digitosElementoModeloPropertyName);
            }
        }


        #endregion

        #region  codigoelemento

        public const string codigoelementoPropertyName = "codigoelemento";

        private int _codigoelemento = 0;

        public int codigoelemento
        {
            get
            {
                return _codigoelemento;
            }

            set
            {
                if (_codigoelemento == value)
                {
                    return;
                }

                _codigoelemento = value;
                RaisePropertyChanged(codigoelementoPropertyName);
            }
        }

        #endregion

        #endregion

        #region lista Sistema Contable

        public const string listaSistemaContablePropertyName = "listaSistemaContable";

        private ObservableCollection<SistemaContableModelo> _listaSistemaContable;

        public ObservableCollection<SistemaContableModelo> listaSistemaContable
        {
            get
            {
                return _listaSistemaContable;
            }

            set
            {
                if (_listaSistemaContable == value) return;

                _listaSistemaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaSistemaContablePropertyName);
            }
        }

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

        #region Propiedades Catalogo Contable

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

        #region idcc

        public const string idccPropertyName = "idcc";

        private int _idcc = 0;

        public int idcc
        {
            get
            {
                return _idcc;
            }

            set
            {
                if (_idcc == value)
                {
                    return;
                }

                _idcc = value;
                RaisePropertyChanged(idccPropertyName);
            }
        }

        #endregion

        #region idelementos

        public const string idelementosPropertyName = "idelementos";

        private int _idelementos = 0;

        public int idelementos
        {
            get
            {
                return _idelementos;
            }

            set
            {
                if (_idelementos == value)
                {
                    return;
                }

                _idelementos = value;
                RaisePropertyChanged(idelementosPropertyName);
            }
        }

        #endregion

        #region idsc

        public const string idscPropertyName = "idsc";

        private int _idsc = 0;

        public int idsc
        {
            get
            {
                return _idsc;
            }

            set
            {
                if (_idsc == value)
                {
                    return;
                }

                _idsc = value;
                RaisePropertyChanged(idscPropertyName);
            }
        }

        #endregion


        #region catidcc

        public const string catidccPropertyName = "catidcc";

        private int _catidcc = 0;

        public int catidcc
        {
            get
            {
                return _catidcc;
            }

            set
            {
                if (_catidcc == value)
                {
                    return;
                }

                _catidcc = value;
                RaisePropertyChanged(catidccPropertyName);
            }
        }

        #endregion

        #region idccuentas

        public const string idccuentasPropertyName = "idccuentas";

        private int _idccuentas = 0;

        public int idccuentas
        {
            get
            {
                return _idccuentas;
            }

            set
            {
                if (_idccuentas == value)
                {
                    return;
                }

                _idccuentas = value;
                RaisePropertyChanged(idccuentasPropertyName);
            }
        }

        #endregion


        #region codigocc

        public const string usuarioModificoPropertyName = "codigocc";

        private string _usuarioModifico = string.Empty;

        public string codigocc
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

        #region descripcioncc

        public const string descripcionccPropertyName = "descripcioncc";

        private string _descripcioncc = string.Empty;

        public string descripcioncc
        {
            get
            {
                return _descripcioncc;
            }

            set
            {
                if (_descripcioncc == value)
                {
                    return;
                }

                _descripcioncc = value;
                RaisePropertyChanged(descripcionccPropertyName);
            }
        }

        #endregion

        #region tiposaldocc

        public const string autorizadoPorHerramientaPropertyName = "tiposaldocc";

        private string _autorizadoPorHerramienta = string.Empty;

        public string tiposaldocc
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

        #region fechacreacioncc

        public const string fechacreadoherramientaPropertyName = "fechacreacioncc";

        private DateTime _fechacreadoherramienta = DateTime.Now;

        public DateTime fechacreacioncc
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


        #region ordencc

        public const string ordenccPropertyName = "ordencc";

        private decimal _ordencc = 0;

        public decimal ordencc
        {
            get
            {
                return _ordencc;
            }

            set
            {
                if (_ordencc == value)
                {
                    return;
                }

                _ordencc = value;
                RaisePropertyChanged(ordenccPropertyName);
            }
        }

        #endregion

        #region estadocc

        public const string estadoccPropertyName = "estadocc";

        private string _estadocc = string.Empty;

        public string estadocc
        {
            get
            {
                return _estadocc;
            }

            set
            {
                if (_estadocc == value)
                {
                    return;
                }

                _estadocc = value;
                RaisePropertyChanged(estadoccPropertyName);
            }
        }

        #endregion

        #region descripcionTSCuenta

        public const string nombreHerramientaPropertyName = "descripcionTSCuenta";

        private string _nombreHerramienta = string.Empty;

        public string descripcionTSCuenta
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

        #endregion

        #region Otras propiedades



        #endregion

        #endregion

        #endregion Lista de entidades

        #region Entidades en uso de encargos

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

        #region ViewModel Property : eleccionEncargo

        public const string eleccionEncargoPropertyName = "eleccionEncargo";

        private EncargoModelo _eleccionEncargo;

        public EncargoModelo eleccionEncargo
        {
            get
            {
                return _eleccionEncargo;
            }

            set
            {
                if (_eleccionEncargo == value) return;

                _eleccionEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionEncargoPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentCuentaContable

        public const string currentCuentaContablePropertyName = "currentCuentaContable";

        private CatalogoCuentasModelo _currentCuentaContable;

        public CatalogoCuentasModelo currentCuentaContable
        {
            get
            {
                return _currentCuentaContable;
            }

            set
            {
                if (_currentCuentaContable == value) return;

                _currentCuentaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentCuentaContablePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedCuentaContable

        public const string selectedCuentaContablePropertyName = "selectedCuentaContable";

        private CatalogoCuentasModelo _selectedCuentaContable;

        public CatalogoCuentasModelo selectedCuentaContable
        {
            get
            {
                return _selectedCuentaContable;
            }

            set
            {
                if (_selectedCuentaContable == value) return;

                _selectedCuentaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedCuentaContablePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionCuentaContable

        public const string eleccionCuentaContablePropertyName = "eleccionCuentaContable";

        private CatalogoCuentasModelo _eleccionCuentaContable;

        public CatalogoCuentasModelo eleccionCuentaContable
        {
            get
            {
                return _eleccionCuentaContable;
            }

            set
            {
                if (_eleccionCuentaContable == value) return;

                _eleccionCuentaContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionCuentaContablePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private DetalleBalanceModelo _currentEntidad;

        public DetalleBalanceModelo currentEntidad
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

        #region saldoanteriordbdp

        public const string saldoanteriordbdpPropertyName = "saldoanteriordbdp";

        private decimal _saldoanteriordbdp = 0;

        public decimal saldoanteriordbdp
        {
            get
            {
                return _saldoanteriordbdp;
            }

            set
            {
                if (_saldoanteriordbdp == value)
                {
                    return;
                }

                _saldoanteriordbdp = value;
                RaisePropertyChanged(saldoanteriordbdpPropertyName);
            }
        }

        #endregion

        #region cargodbdp

        public const string cargodbdpPropertyName = "cargodbdp";

        private decimal _cargodbdp = 0;

        public decimal cargodbdp
        {
            get
            {
                return _cargodbdp;
            }

            set
            {
                if (_cargodbdp == value)
                {
                    return;
                }

                _cargodbdp = value;
                RaisePropertyChanged(cargodbdpPropertyName);
            }
        }

        #endregion

        #region abonodbdp

        public const string abonodbdpPropertyName = "abonodbdp";

        private decimal _abonodbdp = 0;

        public decimal abonodbdp
        {
            get
            {
                return _abonodbdp;
            }

            set
            {
                if (_abonodbdp == value)
                {
                    return;
                }

                _abonodbdp = value;
                RaisePropertyChanged(abonodbdpPropertyName);
            }
        }

        #endregion

        #region saldofinaldbdp

        public const string saldofinaldbdpPropertyName = "saldofinaldbdp";

        private decimal _saldofinaldbdp = 0;

        public decimal saldofinaldbdp
        {
            get
            {
                return _saldofinaldbdp;
            }

            set
            {
                if (_saldofinaldbdp == value)
                {
                    return;
                }

                _saldofinaldbdp = value;
                RaisePropertyChanged(saldofinaldbdpPropertyName);
            }
        }

        #endregion

        #region codigoccdb Clase detalleBalance

        public const string codigoccdbPropertyName = "codigoccdb";

        private string _codigoccdb = string.Empty;

        public string codigoccdb
        {
            get
            {
                return _codigoccdb;
            }

            set
            {
                if (_codigoccdb == value)
                {
                    return;
                }

                _codigoccdb = value;
                RaisePropertyChanged(codigoccdbPropertyName);
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


        #region ViewModel Properties : editarCodigo

        public const string editarCodigoPropertyName = "editarCodigo";

        private bool _editarCodigo;

        public bool editarCodigo
        {
            get
            {
                return _editarCodigo;
            }

            set
            {
                if (_editarCodigo == value)
                {
                    return;
                }

                _editarCodigo = value;
                RaisePropertyChanged(editarCodigoPropertyName);
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

        #region accesibilidadDigitarDatos

        public const string accesibilidadDigitarDatosPropertyName = "accesibilidadDigitarDatos";

        private bool _accesibilidadDigitarDatos;

        public bool accesibilidadDigitarDatos
        {
            get
            {
                return _accesibilidadDigitarDatos;
            }

            set
            {
                if (_accesibilidadDigitarDatos == value)
                {
                    return;
                }

                _accesibilidadDigitarDatos = value;
                RaisePropertyChanged(accesibilidadDigitarDatosPropertyName);
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


        #endregion

        #region ViewModel Commands
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand operarCommand { get; set; }
        public RelayCommand GuardarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand OkCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }
        public RelayCommand<CatalogoCuentasModelo> SeleccionCuentaContableCommand { get; set; }
        public RelayCommand<CatalogoCuentasModelo> SelectionChangedCommand { get; set; }
        public RelayCommand buscarCuentaCommand { get; set; }
        public RelayCommand verificarCommand { get; set; }

        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public DetalleBalanceControllerViewModel()
        {
            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenEnvioController = "datosControllerDetalleBalances";
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            _opcionMenu = 0;
            _codigoContableValido = true;
            Errors = 0;
            _tokenRecepcionPadre = "datosPadreDetalleBalances";
            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            //Suscribiendo el mensaje
            _listaCatalogoCuentasModelo = new ObservableCollection<CatalogoCuentasModelo>();
            _listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());
            _listaElementos = new ObservableCollection<ElementoModelo>();
            _listaEncargos = new ObservableCollection<EncargoModelo>();
            _listaCuentasFiltradaModelo = new ObservableCollection<CatalogoCuentasModelo>();
            _listaEntidadSeleccion = new ObservableCollection<CatalogoCuentasModelo>();//Lista para inyectarla en la entidad
            _listaElementoSeleccion = _listaElementos;
            _listaDetalleBalanceModelo = new ObservableCollection<DetalleBalanceModelo>();
            _FuenteLlamada = 0;
            _activarCaptura = false;
            _cuentaValida = false;
            _editarCodigo = false;
            Messenger.Default.Register<DetalleBalanceMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            _currentEncargo = new EncargoModelo();
            _currentEntidad = new DetalleBalanceModelo();
            _currentSistemaContable = new SistemaContableModelo();
            _currentCuentaContable = new CatalogoCuentasModelo();
            _selectedCuentaContable = new CatalogoCuentasModelo();
            _eleccionEncargo = new EncargoModelo();
            _saldoanteriordbdp = 0;
            _abonodbdp = 0;
            _cargodbdp = 0;
            _saldofinaldbdp = 0;
            _accesibilidadDigitarDatos = true;
        }

        private void ControlDatosMsj(DetalleBalanceMsj datosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            currentSistemaContable = datosMsj.sistemaContableModelo;
            currentEntidad = datosMsj.detalleBalancemodelo;
            listaDetalleBalanceModelo = datosMsj.listaDetalleBalanceModelo;
            currentEntidad.listaEntidadSeleccion = listaDetalleBalanceModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            FuenteLlamada = datosMsj.fuenteLlamado;
            listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentSistemaContable.idsc));
            listaCatalogoCuentasModelo = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllByIdScForDisplay(currentSistemaContable.idsc));
            currentEntidad.listaCatalogoCuentasModelo = listaCatalogoCuentasModelo;
            switch (datosMsj.opcionMenuCrud)
            {
                case 1://Crear 
                    encabezadoPantalla = "Introduzca los datos para el movimiento de la cuenta contable";
                    nombreprogramaVista = "*Movimiento de cuenta";
                    visibilidadCrear = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    editarCodigo = true;
                    //Propiedades de presentacion
                    activarCaptura = true;
                    accesibilidadWindow = true;
                    eleccionCuentaContable = listaCatalogoCuentasModelo[0];
                    selectedCuentaContable = listaCatalogoCuentasModelo[0];
                    break;
                case 2://Editar
                    encabezadoPantalla = "Actualice los datos para el movimiento de la cuenta contable";
                    nombreprogramaVista = "*Movimiento de cuenta";
                    editarCodigo = false;
                    cuentaValida = true;

                    selectedCuentaContable = listaCatalogoCuentasModelo.Single(i => i.codigocc == currentEntidad.codigoccdb);
                    eleccionCuentaContable = selectedCuentaContable;
                    descripcioncc = selectedCuentaContable.descripcioncc;

                    saldoanteriordbdp = currentEntidad.saldoanteriordb;
                    abonodbdp = currentEntidad.abonodb;
                    cargodbdp = currentEntidad.cargodb;
                    saldofinaldbdp = currentEntidad.saldofinaldb;

                    //Enviar el elemento para recuperar el detalle

                    encabezadoPantalla = "Actualice los datos";
                    activarCaptura = true;
                    visibilidadConsultar = Visibility.Collapsed;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Visible;

                    accesibilidadWindow = true;
                    break;
                case 3://Consultar
                    encabezadoPantalla = "Datos para la cuenta";
                    nombreprogramaVista = "*Nombre de cuenta";
                    editarCodigo = false;
                    cuentaValida = true;

                    selectedCuentaContable = listaCatalogoCuentasModelo.Single(i => i.codigocc == currentEntidad.codigoccdb);
                    eleccionCuentaContable = selectedCuentaContable;
                    descripcioncc = selectedCuentaContable.descripcioncc;

                    saldoanteriordbdp = currentEntidad.saldoanteriordb;
                    abonodbdp = currentEntidad.abonodb;
                    cargodbdp = currentEntidad.cargodb;
                    saldofinaldbdp = currentEntidad.saldofinaldb;

                    accesibilidadWindow = false;
                    accesibilidadCuerpo = false;
                    //Enviar datos al detalle
                    //Enviar el elemento para recuperar el detalle
                    encabezadoPantalla = "Datos del registro";
                    activarCaptura = false;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;

                    break;
            }
            Messenger.Default.Unregister<CatalogoCuentasMsj>(this, tokenRecepcionPadre);
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
            if (CatalogoCuentasModelo.DeleteBorradoLogico(2, true))
            {
                var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
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
            //Debe coindicir el inicio con el elemento contable seleccionado
                Mouse.OverrideCursor = Cursors.Wait;
                accesibilidadWindow = false;
                    try
                    {
                        switch (DetalleBalanceModelo.Insert(currentEntidad))
                        {
                            case 0://No se pudo insertar
                                Mouse.OverrideCursor = null;
                                accesibilidadWindow = true;
                                await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                break;
                            case 1://Se inserto con éxito
                                var controller = await dlg.ShowProgressAsync(this, "Registro insertado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
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



        public async void Modificar()
        {
                Mouse.OverrideCursor = Cursors.Wait;
                accesibilidadWindow = false;

                    if (DetalleBalanceModelo.UpdateModelo(currentEntidad, true))
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
                && cuentaValida;
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
                && cuentaValida;
                return evaluar;
            }
        }

        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            EditarCommand = new RelayCommand(Modificar, CanSave);
            SeleccionCuentaContableCommand = new RelayCommand<CatalogoCuentasModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionCuentaContable = entidad;
                currentEntidad.idcc = entidad.idcc;
                currentEntidad.orden = entidad.ordencc;
                currentEntidad.ordenDhPresentacion = entidad.ordenDhPresentacion;
                currentEntidad.codigoccdb=entidad.codigocc;
                operacion();
            });
            GuardarCommand = new RelayCommand(Guardar, CanSaveNuevo);//Caso de nuevo registro
            CancelarCommand = new RelayCommand(Cancelar);
            OkCommand = new RelayCommand(OkCierre);
            SalirCommand = new RelayCommand(Salir);

            buscarCuentaCommand = new RelayCommand(buscarCuenta);

            operarCommand = new RelayCommand(operacion);
            verificarCommand = new RelayCommand(verificarConsistencia);
        }

        private async void verificarConsistencia()
        {
            try
            {
                bool cuentaConsistencia = false;
                switch (selectedCuentaContable.tiposaldocc.ToUpper())
                {
                    case "A":
                        if (0 == (currentEntidad.saldofinaldb -(currentEntidad.saldoanteriordb - currentEntidad.cargodb + currentEntidad.abonodb)))
                        {
                            cuentaConsistencia = true;
                        }
                        else
                        {
                            cuentaConsistencia = false;
                        }
                        break;
                    case "D":
                        if (0 == (currentEntidad.saldofinaldb - currentEntidad.saldoanteriordb + currentEntidad.cargodb - currentEntidad.abonodb))
                        {
                            cuentaConsistencia = true;
                        }
                        else
                        {
                            cuentaConsistencia = false;
                        }
                        break;
                    case "RD":
                        if (0 == (currentEntidad.saldofinaldb - currentEntidad.saldoanteriordb + currentEntidad.cargodb - currentEntidad.abonodb))
                        {
                            cuentaConsistencia = true;
                        }
                        else
                        {
                            cuentaConsistencia = false;
                        }
                        break;
                    case "RA":
                        if (0 == (currentEntidad.saldofinaldb - (currentEntidad.saldoanteriordb - currentEntidad.cargodb + currentEntidad.abonodb)))
                        {
                            cuentaConsistencia = true;
                        }
                        else
                        {
                            cuentaConsistencia = false;
                        }
                        break;
                }
                if (!cuentaConsistencia)
                {
                    await dlg.ShowMessageAsync(this, "El saldo final es inconsistente con los datos", "verifique la operacion aritmética");

                }

            }
            catch (Exception)
            {
                this.exception1();
                //await dlg.ShowMessageAsync(this, "Error en la verificación", "verifique la operacion aritmética");
            }
        }

        private async void exception1()
        {
            await dlg.ShowMessageAsync(this, "Error en la verificación", "verifique la operacion aritmética");
        }

        private async void buscarCuenta()
        {
            try
            {
                //Busca con el codigo  válido la cuenta a que corresponde
                selectedCuentaContable = listaCatalogoCuentasModelo.Single(x => x.codigocc == currentEntidad.codigoccdb);
                if (selectedCuentaContable != null && selectedCuentaContable.idcc != 0)
                {
                    //Buscar que no existe en el balance actual
                    int repetido = 0;
                    if (opcionMenu == 1)
                    {
                        for (int i = 0; i < currentEntidad.listaEntidadSeleccion.Count; i++)
                        {
                            if (currentEntidad.listaEntidadSeleccion[i].codigoccdb == selectedCuentaContable.codigocc)
                            {
                                repetido++;
                                i = currentEntidad.listaEntidadSeleccion.Count;
                            }
                        }

                        //var temporal=currentEntidad.listaEntidadSeleccion.Where(x => x.codigoccdb==currentEntidad.codigoccdb);

                        if (repetido > 0)
                        {
                            await dlg.ShowMessageAsync(this, "La cuenta ya tiene datos reintroduzca una cuenta", " sin movimiento o edite el registro con saldo");
                            eleccionCuentaContable = listaCatalogoCuentasModelo[0];
                            selectedCuentaContable= listaCatalogoCuentasModelo[0];
                            cuentaValida = false;
                        }
                        else
                        {
                            eleccionCuentaContable = selectedCuentaContable;
                            currentEntidad.codigoccdb = selectedCuentaContable.codigocc;
                            currentEntidad.tiposaldocc = selectedCuentaContable.tiposaldocc;
                            currentEntidad.orden = selectedCuentaContable.ordencc;
                            currentEntidad.ordenDhPresentacion = selectedCuentaContable.ordenDhPresentacion;
                            cuentaValida = true;
                            //Correccion del saldo
                            operacion();
                            //Accesibilidad de los datos
                        }
                    }
                    else
                    {
                        //Caso de edicion y consulta
                        for (int i = 0; i < currentEntidad.listaEntidadSeleccion.Count; i++)
                        {
                            if (currentEntidad.listaEntidadSeleccion[i].codigoccdb == selectedCuentaContable.codigocc)
                            {
                                repetido++;
                            }
                            if (repetido > 1)
                            {
                                i = currentEntidad.listaEntidadSeleccion.Count;
                            }
                        }

                        //var temporal=currentEntidad.listaEntidadSeleccion.Where(x => x.codigoccdb==currentEntidad.codigoccdb);

                        if (repetido > 1)
                        {
                            await dlg.ShowMessageAsync(this, "La cuenta ya tiene datos reintroduzca una cuenta", " sin movimiento o edite el registro con saldo");
                            eleccionCuentaContable = listaCatalogoCuentasModelo[0];
                            selectedCuentaContable = listaCatalogoCuentasModelo[0];
                            cuentaValida = false;
                        }
                        else
                        {
                            eleccionCuentaContable = selectedCuentaContable;
                            currentEntidad.codigoccdb = selectedCuentaContable.codigocc;
                            currentEntidad.tiposaldocc = selectedCuentaContable.tiposaldocc;
                            currentEntidad.orden = selectedCuentaContable.ordencc;
                            currentEntidad.ordenDhPresentacion = selectedCuentaContable.ordenDhPresentacion;
                            cuentaValida = true;
                            //Correccion del saldo
                            operacion();
                            //Accesibilidad de los datos
                        }
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El código digitado no existe", "reintroduzca un código válido");
                    eleccionCuentaContable = listaCatalogoCuentasModelo[0];
                    selectedCuentaContable = listaCatalogoCuentasModelo[0];
                    cuentaValida = false;
                }
            }
            catch (Exception)
            {
                this.exception2();
                //await dlg.ShowMessageAsync(this, "El código digitado no existe", "reintroduzca un código válido");
                //accesibilidadDigitarDatos = false;

            }
        }

        private async void exception2()
        {
            await dlg.ShowMessageAsync(this, "El código digitado no existe", "reintroduzca un código válido");
        }

        private void operacion()
        {
            switch (selectedCuentaContable.tiposaldocc.ToUpper())
            {
                case "A":
                    currentEntidad.saldofinaldb = currentEntidad.saldoanteriordb - currentEntidad.cargodb + currentEntidad.abonodb;
                break;
                case "D":
                    currentEntidad.saldofinaldb = currentEntidad.saldoanteriordb + currentEntidad.cargodb - currentEntidad.abonodb;
                    break;
                case "RD":
                    currentEntidad.saldofinaldb = currentEntidad.saldoanteriordb + currentEntidad.cargodb - currentEntidad.abonodb;
                    break;
                case "RA":
                    currentEntidad.saldofinaldb = currentEntidad.saldoanteriordb - currentEntidad.cargodb + currentEntidad.abonodb;
                    break;
            }
        }


        #endregion

    }
}

//Correccion