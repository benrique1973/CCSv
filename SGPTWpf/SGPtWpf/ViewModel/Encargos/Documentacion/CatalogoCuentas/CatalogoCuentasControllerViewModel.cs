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

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas
{
    public sealed class CatalogoCuentasControllerViewModel : ViewModeloBase
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



        #region ViewModel Properties : listaCatalogoCuentaSeleccion

        public const string listaCatalogoCuentaSeleccionPropertyName = "listaCatalogoCuentaSeleccion";

        private ObservableCollection<CatalogoCuentasModelo> _listaCatalogoCuentaSeleccion;

        public ObservableCollection<CatalogoCuentasModelo> listaCatalogoCuentaSeleccion
        {
            get
            {
                return _listaCatalogoCuentaSeleccion;
            }
            set
            {
                if (_listaCatalogoCuentaSeleccion == value) return;

                _listaCatalogoCuentaSeleccion = value;

                RaisePropertyChanged(listaCatalogoCuentaSeleccionPropertyName);
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

        #region ViewModel Properties : listaTipoSaldoCuenta

        public const string listaTipoSaldoCuentaPropertyName = "listaTipoSaldoCuenta";

        private ObservableCollection<TipoSaldoCuentaModelo> _listaTipoSaldoCuenta;

        public ObservableCollection<TipoSaldoCuentaModelo> listaTipoSaldoCuenta
        {
            get
            {
                return _listaTipoSaldoCuenta;
            }
            set
            {
                if (_listaTipoSaldoCuenta == value) return;

                _listaTipoSaldoCuenta = value;

                RaisePropertyChanged(listaTipoSaldoCuentaPropertyName);
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

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private CatalogoCuentasModelo _currentEntidad;

        public CatalogoCuentasModelo currentEntidad
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

        #region ViewModel Property : selectedElementoContable

        public const string selectedElementoContablePropertyName = "selectedElementoContable";

        private ElementoModelo _selectedElementoContable;

        public ElementoModelo selectedElementoContable
        {
            get
            {
                return _selectedElementoContable;
            }

            set
            {
                if (_selectedElementoContable == value) return;

                _selectedElementoContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedElementoContablePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionElementoContable

        public const string eleccionElementoContablePropertyName = "eleccionElementoContable";

        private ElementoModelo _eleccionElementoContable;

        public ElementoModelo eleccionElementoContable
        {
            get
            {
                return _eleccionElementoContable;
            }

            set
            {
                if (_eleccionElementoContable == value) return;

                _eleccionElementoContable = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionElementoContablePropertyName);
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

        #region ViewModel Property : selectedCuentaPadre

        public const string selectedCuentaPadrePropertyName = "selectedCuentaPadre";

        private CatalogoCuentasModelo _selectedCuentaPadre;

        public CatalogoCuentasModelo selectedCuentaPadre
        {
            get
            {
                return _selectedCuentaPadre;
            }

            set
            {
                if (_selectedCuentaPadre == value) return;

                _selectedCuentaPadre = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedCuentaPadrePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionCuentaPadre

        public const string eleccionCuentaPadrePropertyName = "eleccionCuentaPadre";

        private CatalogoCuentasModelo _eleccionCuentaPadre;

        public CatalogoCuentasModelo eleccionCuentaPadre
        {
            get
            {
                return _eleccionCuentaPadre;
            }

            set
            {
                if (_eleccionCuentaPadre == value) return;

                _eleccionCuentaPadre = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionCuentaPadrePropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedTipoSaldoCuenta

        public const string selectedTipoSaldoCuentaPropertyName = "selectedTipoSaldoCuenta";

        private TipoSaldoCuentaModelo _selectedTipoSaldoCuenta;

        public TipoSaldoCuentaModelo selectedTipoSaldoCuenta
        {
            get
            {
                return _selectedTipoSaldoCuenta;
            }

            set
            {
                if (_selectedTipoSaldoCuenta == value) return;

                _selectedTipoSaldoCuenta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedTipoSaldoCuentaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionTipoSaldoCuenta

        public const string eleccionTipoSaldoCuentaPropertyName = "eleccionTipoSaldoCuenta";

        private TipoSaldoCuentaModelo _eleccionTipoSaldoCuenta;

        public TipoSaldoCuentaModelo eleccionTipoSaldoCuenta
        {
            get
            {
                return _eleccionTipoSaldoCuenta;
            }

            set
            {
                if (_eleccionTipoSaldoCuenta == value) return;

                _eleccionTipoSaldoCuenta = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionTipoSaldoCuentaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedClaseCuentaModelo

        public const string selectedClaseCuentaModeloPropertyName = "selectedClaseCuentaModelo";

        private ClaseCuentaModelo _selectedClaseCuentaModelo;

        public ClaseCuentaModelo selectedClaseCuentaModelo
        {
            get
            {
                return _selectedClaseCuentaModelo;
            }

            set
            {
                if (_selectedClaseCuentaModelo == value) return;

                _selectedClaseCuentaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedClaseCuentaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : eleccionClaseCuentaModelo

        public const string eleccionClaseCuentaModeloPropertyName = "eleccionClaseCuentaModelo";

        private ClaseCuentaModelo _eleccionClaseCuentaModelo;

        public ClaseCuentaModelo eleccionClaseCuentaModelo
        {
            get
            {
                return _eleccionClaseCuentaModelo;
            }

            set
            {
                if (_eleccionClaseCuentaModelo == value) return;

                _eleccionClaseCuentaModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(eleccionClaseCuentaModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : selectedEncargoImportar

        public const string selectedEncargoImportarPropertyName = "selectedEncargoImportar";

        private EncargoModelo _selectedEncargoImportar;

        public EncargoModelo selectedEncargoImportar
        {
            get
            {
                return _selectedEncargoImportar;
            }

            set
            {
                if (_selectedEncargoImportar == value) return;

                _selectedEncargoImportar = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(selectedEncargoImportarPropertyName);
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
        public RelayCommand<CatalogoCuentasModelo> SelectionChangedCommand { get; set; }
        public RelayCommand<EncargoModelo> SelectionChangedEncargoCommand { get; set; }
        public RelayCommand<ClaseCuentaModelo> SelClasCtaCommand { get; set; }

        public RelayCommand<TipoSaldoCuentaModelo> SelectionTipoSaldoCuentaCommand { get; set; }
        public RelayCommand<CatalogoCuentasModelo> SelectionPadreCommand { get; set; }
        public RelayCommand<ElementoModelo> SelectionElementoCommand { get; set; }
        public RelayCommand<EncargoModelo> SelectionImportarChangedCommand { get; set; }


        #endregion


        #region Implementacion comandos

        #region ViewModel Public Methods

        #region Constructores

        public CatalogoCuentasControllerViewModel()
        {
            enviarMensajeInhabilitar();

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenEnvioController = "datosControllerCatalogoCuentas"; ;
            _fuenteCierre = 0;
            _resultadoProceso = 0;
            _opcionMenu = 0;
            _codigoContableValido = true;
            Errors = 0;
            _tokenRecepcionPadre = "datosEDCatalogoCuentas";
            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            _activarClaseCuenta = false;
            _visibilidadConsultar = Visibility.Collapsed;
            _visibilidadCrear = Visibility.Collapsed;
            _visibilidadEditar = Visibility.Collapsed;
            _visibilidadCuentaPadre = Visibility.Collapsed;
            //Suscribiendo el mensaje
            _listaCatalogoCuentasModelo = new ObservableCollection<CatalogoCuentasModelo>();
            _listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());
            _listaElementos = new ObservableCollection<ElementoModelo>();
            _listaTipoSaldoCuenta = new ObservableCollection<TipoSaldoCuentaModelo>(TipoSaldoCuentaModelo.GetAll());
            _listaEncargos = new ObservableCollection<EncargoModelo>();
            _listaCuentasFiltradaModelo = new ObservableCollection<CatalogoCuentasModelo>();
            _listaEntidadSeleccion = new ObservableCollection<CatalogoCuentasModelo>();//Lista para inyectarla en la entidad
            _listaCatalogoCuentaSeleccion = new ObservableCollection<CatalogoCuentasModelo>();
            _listaElementoSeleccion = _listaElementos;
            _FuenteLlamada = 0;
            Messenger.Default.Register<CatalogoCuentasMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            fuenteCierre = 0;
            _currentEncargo = new EncargoModelo();
            _currentEntidad = new CatalogoCuentasModelo();
            _currentSistemaContable = new SistemaContableModelo();
            _selectedElementoContable = new ElementoModelo();
            _selectedCuentaPadre = new CatalogoCuentasModelo();
            _selectedTipoSaldoCuenta = new TipoSaldoCuentaModelo();
            _selectedClaseCuentaModelo = new ClaseCuentaModelo();
            _selectedEncargoImportar = new EncargoModelo();
            _eleccionClaseCuentaModelo = new ClaseCuentaModelo();
            _eleccionElementoContable = new ElementoModelo();
            _eleccionTipoSaldoCuenta = new TipoSaldoCuentaModelo();
            _eleccionCuentaPadre = new CatalogoCuentasModelo();
            _eleccionEncargo = new EncargoModelo();
        }

        private async void ControlDatosMsj(CatalogoCuentasMsj datosMsj)
        {
            //Asignacion de  entidades
            currentEncargo = datosMsj.encargoModelo;//Encargo en uso actual
            currentUsuario = datosMsj.usuarioModelo;
            currentSistemaContable = datosMsj.sistemaContableModelo;
            opcionMenu = datosMsj.opcionMenuCrud;
            FuenteLlamada = datosMsj.fuenteLlamado;
            listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentSistemaContable.idsc));

            if (opcionMenu != 7)
            {
                currentEntidad = datosMsj.catalogoCuentasModelo;
                //Inyeccion de listado de cuentas
                currentEntidad.listaEntidadSeleccion = datosMsj.listaCatalogoCuentasModelo;
                listaEntidadSeleccion = currentEntidad.listaEntidadSeleccion;
                listaCatalogoCuentasModelo = datosMsj.listaCatalogoCuentasModelo;
                //listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAll((int)currentEntidad.idsc));
                //listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentEntidad.idsc));
                listaTipoSaldoCuenta = new ObservableCollection<TipoSaldoCuentaModelo>(TipoSaldoCuentaModelo.GetAll());
                selectedClaseCuentaModelo.listaCatalogoCuentaSeleccion = datosMsj.listaCatalogoCuentasModelo;
                listaCatalogoCuentaSeleccion = selectedClaseCuentaModelo.listaCatalogoCuentaSeleccion;
            }
            switch (datosMsj.opcionMenuCrud)
            {
                case 1://Crear 
                    encabezadoPantalla = "Introduzca los datos para la cuenta";
                    nombreprogramaVista = "*Nombre de cuenta";
                    visibilidadHoras = Visibility.Collapsed;
                    visibilidadCrear = Visibility.Visible;
                    visibilidadCopiar = Visibility.Collapsed;
                    //Propiedades de presentacion
                    activarCaptura = true;
                    activarCrear = true;
                    activarConsultar = false;
                    activarEditar = false;
                    accesibilidadWindow = true;
                    selectedElementoContable = listaElementos[0];
                    break;
                case 2://Editar
                    encabezadoPantalla = "Actualice los datos para la cuenta";
                    nombreprogramaVista = "*Nombre de cuenta";

                    selectedElementoContable = listaElementos.Single(i => i.id == currentEntidad.idelementos);
                    selectedTipoSaldoCuenta = listaTipoSaldoCuenta.Single(i => i.tiposaldocc == currentEntidad.tiposaldocc);
                    selectedClaseCuentaModelo = listaClaseCuenta.Single(i => i.id == currentEntidad.idccuentas);
                    //listaCuentasFiltradaModelo = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllByIdElementoYIdClaseCuenta(selectedElementoContable,selectedClaseCuentaModelo,currentSistemaContable));
                    listaCuentasFiltradaModelo = listaFiltrada(selectedClaseCuentaModelo, selectedElementoContable);
                    descripcioncc = currentEntidad.descripcioncc;
                    codigocc = currentEntidad.codigocc;
                    eleccionClaseCuentaModelo = currentEntidad.claseCuentaModeloCC;
                    eleccionElementoContable = currentEntidad.elementoModeloCC;
                    eleccionTipoSaldoCuenta = currentEntidad.tipoSaldoCuentaModelo;


                    activarClaseCuenta = true;
                    if (currentEntidad.catidcc != null && currentEntidad.catidcc != 0)
                    {
                        selectedCuentaPadre = listaCatalogoCuentasModelo.Single(i => i.idcc == currentEntidad.catidcc);
                        eleccionCuentaPadre = currentEntidad.CatalogoCuentasModeloPadre;
                        visibilidadCuentaPadre = Visibility.Visible;

                    }
                    else
                    {
                        selectedCuentaPadre = null;
                        eleccionCuentaPadre = null;
                        visibilidadCuentaPadre = Visibility.Collapsed;
                    }

                    if (currentEntidad.nombreClaseCuenta.ToUpper().Trim() == "ELEMENTO" || currentEntidad.nombreClaseCuenta.ToUpper().Trim() == "ELEMENTOS")
                    {
                        visibilidadCuentaPadre = Visibility.Collapsed;
                    }
                    else
                    {
                        //No es  un elemento debe tener dependencia
                        visibilidadCuentaPadre = Visibility.Visible;
                    }

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
                    encabezadoPantalla = "Datos para la cuenta";
                    nombreprogramaVista = "*Nombre de cuenta";

                    selectedElementoContable = listaElementos.Single(i => i.id == currentEntidad.idelementos);
                    selectedTipoSaldoCuenta = listaTipoSaldoCuenta.Single(i => i.tiposaldocc == currentEntidad.tiposaldocc);
                    selectedClaseCuentaModelo = listaClaseCuenta.Single(i => i.id == currentEntidad.idccuentas);
                    listaCuentasFiltradaModelo = listaFiltrada(selectedClaseCuentaModelo, selectedElementoContable);
                    descripcioncc = currentEntidad.descripcioncc;
                    codigocc = currentEntidad.codigocc;
                    eleccionClaseCuentaModelo = currentEntidad.claseCuentaModeloCC;
                    eleccionElementoContable = currentEntidad.elementoModeloCC;
                    eleccionTipoSaldoCuenta = currentEntidad.tipoSaldoCuentaModelo;

                    activarClaseCuenta = true;
                    if (currentEntidad.catidcc != null && currentEntidad.catidcc != 0)
                    {
                        selectedCuentaPadre = listaCatalogoCuentasModelo.Single(i => i.idcc == currentEntidad.catidcc);
                        eleccionCuentaPadre = currentEntidad.CatalogoCuentasModeloPadre;
                        visibilidadCuentaPadre = Visibility.Visible;
                    }
                    else
                    {
                        selectedCuentaPadre = null;
                        eleccionCuentaPadre = null;
                        visibilidadCuentaPadre = Visibility.Collapsed;
                    }
                    if (currentEntidad.nombreClaseCuenta.ToUpper().Trim() == "ELEMENTO" || currentEntidad.nombreClaseCuenta.ToUpper().Trim() == "ELEMENTOS")
                    {
                        visibilidadCuentaPadre = Visibility.Collapsed;
                    }
                    else
                    {
                        //No es  un elemento debe tener dependencia
                        visibilidadCuentaPadre = Visibility.Visible;
                    }
                    accesibilidadWindow = false;
                    accesibilidadCuerpo = false;
                    //Enviar datos al detalle
                    //Enviar el elemento para recuperar el detalle
                    encabezadoPantalla = "Datos del registro";
                    activarCaptura = false;
                    visibilidadConsultar = Visibility.Visible;
                    visibilidadCrear = Visibility.Collapsed;
                    visibilidadEditar = Visibility.Collapsed;

                    activarCrear = false;
                    activarConsultar = true;
                    activarEditar = false;
                    break;
                case 7://Importar de programas de otros encargos
                    listaEncargos = new ObservableCollection<EncargoModelo>(EncargoModelo.GetAll());

                    listaEncargos.Remove(currentEncargo);//Elimino el encargo en uso
                    if (listaEncargos.Count > 0)
                    {
                        accesibilidadWindow = true;
                        encabezadoPantalla = "Seleccion el catalogo del encargo a importar";
                        nombreprogramaVista = "Nombre del catalogo";
                        visibilidadHoras = Visibility.Collapsed;
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
                        var controller = await dlg.ShowProgressAsync(this, "No hay registros disponibles", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
                        controller.SetIndeterminate();
                        await TaskEx.Delay(1000);
                        await controller.CloseAsync();
                        fuenteCierre = 1;
                        resultadoProceso = 0;//1 para  crear
                        CloseWindow();
                    }
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
            if ((currentEntidad.codigocc.Substring(0, 1) != eleccionElementoContable.codigoelemento.ToString()))
            {
                //Error el código  inicial del elemento seleccionado no coindice con el codigo de la cuenta digitada
                await dlg.ShowMessageAsync(this, "El código " + currentEntidad.codigocc + " no coincide con el código del elemento : " + eleccionElementoContable.descripcion + " contable que es " + eleccionElementoContable.codigoelemento, "Debe modificar el código digitado");
                codigoContableValido = false;
            }
            else
            {
                codigoContableValido = true;
            }
            if (codigoContableValido)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                accesibilidadWindow = false;
                if (currentEntidad.nombreClaseCuenta.Trim().ToUpper() != "ELEMENTO" || currentEntidad.nombreClaseCuenta.Trim().ToUpper() != "ELEMENTOS")
                {
                    if (!((selectedCuentaPadre == null) || (selectedCuentaPadre.idcc == 0)))
                    {
                        currentEntidad.catidcc = selectedCuentaPadre.idcc;
                        currentEntidad.ordencc = ordenRegistro(selectedCuentaPadre, (int)currentEntidad.idsc);
                        currentEntidad.ordenccPadre = selectedCuentaPadre.ordencc;
                        //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                        currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordencc);
                    }
                    else
                    {
                        currentEntidad.ordencc = ordenRegistro(selectedCuentaPadre, (int)currentEntidad.idsc);
                        //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                        currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordencc);
                    }
                    try
                    {
                        switch (CatalogoCuentasModelo.Insert(currentEntidad))
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
                else
                {
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                    await dlg.ShowMessageAsync(this, "Debe seleccionar la cuenta de la que depende", "");
                    visibilidadCuentaPadre = Visibility.Visible;
                }
            }
        }


        private async void ImportarCatalogoEncargos()
        {
            bool continuarProceso = false;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
            catalogocuenta referenciaPadre = new catalogocuenta();//Referencia de posicion
            catalogocuenta temporal = new catalogocuenta();//Referencia de posicion
            elemento temporalElemento = new elemento();
            int indice = 0;
            //Verificar que existan datos
            if (eleccionEncargo != null && currentEncargo != null)
            {
                //Sistema contable a copiar
                SistemaContableModelo temporalSistema = SistemaContableModelo.GetRegistroByIdEncargo(eleccionEncargo.idencargo);
                //Verificar que existe registros en ese encargo
                ObservableCollection<catalogocuenta> listaDetalle = new ObservableCollection<catalogocuenta>(CatalogoCuentasModelo.GetAllCapaDatosByidSC(temporalSistema.idsc));
                //Lista de elementos del sistema contable a copiar
                ObservableCollection<elemento> listaElementosOrigen = new ObservableCollection<elemento>(ElementoModelo.GetBySistemaContableAllForSeleccionForCapaDatos((int)temporalSistema.idsc));

                //Ver que registros existen ya en el catalogo
                ObservableCollection<catalogocuenta> listaOriginal = new ObservableCollection<catalogocuenta>(CatalogoCuentasModelo.GetAllCapaDatosByidSC(currentSistemaContable.idsc));
                //Eliminar lógicamente los registros del catalogo
                if (CatalogoCuentasModelo.DeleteBorradoLogicoTotal(listaOriginal,currentSistemaContable.idsc))
                {
                    continuarProceso = true;
                    //Se borraron los registros
                }
                //Clonar la lista para encontrar los equivalentes
                ObservableCollection<catalogocuenta> listaSincambio = new ObservableCollection<catalogocuenta>(listaDetalle);
                //Temporal para determinar que elementos se deben eliminar
                ObservableCollection<catalogocuenta> listaBorrar = new ObservableCollection<catalogocuenta>();

                if (continuarProceso && listaDetalle.Count > 0)
                {
                    //Actualizacion  de datos para insertar lista de elementos
                    if (continuarProceso)
                    {
                        if (listaElementos.Count > 0)
                        {
                            foreach (elemento item in listaElementosOrigen)
                            {
                                item.idelementos = 0;
                                item.idnitcliente = currentSistemaContable.idnitcliente;
                                item.idscelementos = currentSistemaContable.idsc;
                            }
                        }
                        //Borrado en forma lógica de todos los registros 
                        if (!(ElementoModelo.DeleteBorradoLogico(listaElementos, currentSistemaContable.idsc)))
                        {
                            //Borrar todos los  elementos existentes
                            continuarProceso = false;
                        }

                        //Guardar la  lista
                        if (continuarProceso)
                        {
                            if (!(ElementoModelo.InsertByRange(listaElementosOrigen) == 1))
                            {
                                //Inserto sin problema
                                continuarProceso = false;
                            }
                        }
                        if (continuarProceso)
                        {
                            //Recuperar la nueva lista recien creada
                            //Lista original
                            listaElementosOrigen = new ObservableCollection<elemento>(ElementoModelo.GetBySistemaContableAllForSeleccionForCapaDatos((int)temporalSistema.idsc));
                            //Actualizando el listado con  los nuevos  elementos                                
                            listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentSistemaContable.idsc));
                            //Sustitucion de valores

                            foreach (catalogocuenta item in listaDetalle)
                            {
                                item.idcc = 0;
                                item.idsc = currentSistemaContable.idsc;
                                item.fechacreacioncc = MetodosModelo.homologacionFecha();
                            }
                            //Sustituyendo los nuevos id para el catalogo
                            foreach (elemento item in listaElementosOrigen)
                            {
                                //Buscar el nuevo id
                                try
                                {
                                    indice = listaElementos.Single(x => x.codigoelemento == item.codigoelemento).id;
                                    foreach (catalogocuenta itemDetalle in listaDetalle)
                                    {
                                        if (itemDetalle.idelementos == item.idelementos)
                                        {
                                            itemDetalle.idelementos = indice;
                                        }
                                    }
                                }
                                catch
                                {
                                    this.except1();
                                    //Mouse.OverrideCursor = null;
                                    //accesibilidadWindow = true;
                                    //resultadoProceso = 0;
                                    //await dlg.ShowMessageAsync(this, "Error en las sustituciones", "");
                                    continuarProceso = false;
                                }
                            }
                        }
                        //Copiar los elementos contables creando un nuevo  registro con base al sistema contable que se esta  copiando
                        if (continuarProceso)
                        {
                            //Guardar los nuevos registros
                            switch (CatalogoCuentasModelo.InsertByRange(listaDetalle))
                            {
                                case 0:
                                    Mouse.OverrideCursor = null;
                                    accesibilidadWindow = true;
                                    resultadoProceso = 0;
                                    await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                    continuarProceso = false;
                                    break;
                                case 1:
                                    //Referenciar los registros
                                    //Obtener la nueva lista
                                    listaDetalle = new ObservableCollection<catalogocuenta>(CatalogoCuentasModelo.GetAllCapaDatosByidSC(currentSistemaContable.idsc));
                                    for (int k = 0; k < listaDetalle.Count(); k++)
                                    {
                                        //Determinar si es hijo
                                        if (listaDetalle[k].catidcc != null && listaDetalle[k].catidcc != 0)
                                        {
                                            //Coinciden la condicion
                                            //Se obtiene el registro del padre
                                            try
                                            {
                                                var valor = listaDetalle[k].catidcc;
                                                referenciaPadre = listaSincambio.Single(x => x.idcc == listaDetalle[k].catidcc);
                                                listaDetalle[k].catidcc = listaDetalle.Single(x => x.codigocc == referenciaPadre.codigocc).idcc;
                                                //Se limpia el registro
                                            }
                                            catch (Exception)
                                            {
                                                this.except2();
                                                //var controller = await dlg.ShowProgressAsync(this, "Error en la actualizacion", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                                //controller.SetIndeterminate();
                                                //await TaskEx.Delay(1000);
                                                //await controller.CloseAsync();
                                                continuarProceso = false;
                                            }
                                            referenciaPadre = new catalogocuenta();
                                        }
                                    }
                                    if (continuarProceso)
                                    {
                                        //Actualizarel listado en  la base con los cambios
                                        if ((CatalogoCuentasModelo.UpdateByRange(listaDetalle) == 1))
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
                                            var controller = await dlg.ShowProgressAsync(this, "Error en modificar referencias", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
                                            controller.SetIndeterminate();
                                            await TaskEx.Delay(1000);
                                            await controller.CloseAsync();
                                            fuenteCierre = 1;
                                            resultadoProceso = 1;//1 para  crear
                                            CloseWindow();
                                        }
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            accesibilidadWindow = true;
                            resultadoProceso = 0;
                            await dlg.ShowMessageAsync(this, "No pudo importarse el catalogo", "");
                        }
                    }
                    else
                    {
                        Mouse.OverrideCursor = null;
                        accesibilidadWindow = true;
                        resultadoProceso = 0;
                        await dlg.ShowMessageAsync(this, "El encargo seleccionado no contiene cuentas en el catalogo", "Seleccione otro o cancele");
                    }
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    accesibilidadWindow = true;
                    resultadoProceso = 0;
                    await dlg.ShowMessageAsync(this, "Debe seleccionar un  encargo", "");
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
            //Debe coindicir el inicio con el elemento contable seleccionado
            if ((currentEntidad.codigocc.Substring(0, 1) != eleccionElementoContable.codigoelemento.ToString()))
            {
                //Error el código  inicial del elemento seleccionado no coindice con el codigo de la cuenta digitada
                await dlg.ShowMessageAsync(this, "El código " + currentEntidad.codigocc + " no coincide con el código del elemento : " + eleccionElementoContable.descripcion + " que es " + eleccionElementoContable.codigoelemento, "Debe modificar el código digitado");
                codigoContableValido = false;
            }
            else
            {
                codigoContableValido = true;
            }
            if (codigoContableValido)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                accesibilidadWindow = false;


            if (currentEntidad.nombreClaseCuenta.Trim().ToUpper() != "ELEMENTO" || currentEntidad.nombreClaseCuenta.Trim().ToUpper() != "ELEMENTOS")
            {
                if (!((selectedCuentaPadre == null) || (selectedCuentaPadre.idcc == 0)))
            {
                currentEntidad.catidcc = selectedCuentaPadre.idcc;
                currentEntidad.ordencc = ordenRegistro(selectedCuentaPadre, (int)currentEntidad.idsc);
                currentEntidad.ordenccPadre = selectedCuentaPadre.ordencc;
                //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordencc);
            }
            else
            {
                currentEntidad.ordencc = ordenRegistro(selectedCuentaPadre, (int)currentEntidad.idsc);
                //currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordendp);
                currentEntidad.ordenDhPresentacion = MetodosModelo.ordenConversion(currentEntidad.ordencc);
            }
            if (CatalogoCuentasModelo.UpdateModelo(currentEntidad, true))
            {
                var controller = await dlg.ShowProgressAsync(this, "Registro actualizado con éxito", "Este mensaje desaparecerá en 2 segundos", settings: configuracionDialogo);
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
                accesibilidadWindow = true;
                await dlg.ShowMessageAsync(this, "Debe seleccionar la cuenta de la que depende", "");
                visibilidadCuentaPadre = Visibility.Visible;
            }
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
                if (visibilidadCuentaPadre == Visibility.Visible)
                {
                    evaluar = (Errors == 0)
                    && selectedElementoContable.id != 0
                    && selectedClaseCuentaModelo.id != 0
                    && selectedTipoSaldoCuenta.idTSaldoCuenta != 0
                    && selectedCuentaPadre.idcc != 0;
                }
                else
                {
                    evaluar = (Errors == 0)
                    && selectedElementoContable.id != 0
                    && selectedClaseCuentaModelo.id != 0
                    && selectedTipoSaldoCuenta.idTSaldoCuenta != 0;

                }
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
                if (visibilidadCuentaPadre == Visibility.Visible)
                {
                    evaluar = (Errors == 0)
                    && selectedElementoContable.id != 0
                    && selectedClaseCuentaModelo.id != 0
                    && selectedTipoSaldoCuenta.idTSaldoCuenta != 0
                    && selectedCuentaPadre.idcc != 0;
                }
                else
                {
                    evaluar = (Errors == 0)
                    && selectedElementoContable.id != 0
                    && selectedClaseCuentaModelo.id != 0
                    && selectedTipoSaldoCuenta.idTSaldoCuenta != 0;

                }
                return evaluar;
            }
        }

        private bool canImportForEncargos()
        {
            if (eleccionEncargo != null)
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

            SelectionChangedCommand = new RelayCommand<CatalogoCuentasModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });

            SelectionChangedEncargoCommand = new RelayCommand<EncargoModelo>(entidad =>
            {
                if (entidad == null) return;
                selectedEncargoImportar = entidad;
            });
            SelClasCtaCommand = new RelayCommand<ClaseCuentaModelo>(entidad =>
            {

                if (entidad == null) return;
                visibilidadCuentaPadre = Visibility.Collapsed;
                eleccionClaseCuentaModelo = entidad;
                currentEntidad.idccuentas = entidad.id;
                currentEntidad.claseCuentaModeloCC = eleccionClaseCuentaModelo;
                currentEntidad.nombreClaseCuenta = eleccionClaseCuentaModelo.descripcionccuentas;
                //Filtrar la lista según la selección
                filtrarLista();
                if (listaCuentasFiltradaModelo.Count > 0)

                {
                    selectedCuentaPadre = listaCuentasFiltradaModelo[0];//Cambio la seleccion debe eliminarse lo escogido
                }
                else
                {
                    selectedCuentaPadre = null;
                }
            });
            SelectionTipoSaldoCuentaCommand = new RelayCommand<TipoSaldoCuentaModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionTipoSaldoCuenta = entidad;
                currentEntidad.tiposaldocc = eleccionTipoSaldoCuenta.tiposaldocc;
                currentEntidad.tipoSaldoCuentaModelo = eleccionTipoSaldoCuenta;
            });
            
            SelectionPadreCommand = new RelayCommand<CatalogoCuentasModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionCuentaPadre = entidad;
                currentEntidad.catidcc = entidad.idcc;
                currentEntidad.CatalogoCuentasModeloPadre = eleccionCuentaPadre;
            });
            SelectionElementoCommand = new RelayCommand<ElementoModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionElementoContable = entidad;
                if (entidad.id != 0)
                {
                    currentEntidad.idelementos = entidad.id;
                    currentEntidad.elementoModeloCC = eleccionElementoContable;
                    activarClaseCuenta = true;
                }
                else
                {
                    currentEntidad.idelementos = entidad.id;
                    currentEntidad.elementoModeloCC = eleccionElementoContable;
                }
            });


            SelectionImportarChangedCommand = new RelayCommand<EncargoModelo>(entidad =>
            {
                if (entidad == null) return;
                eleccionEncargo = entidad;
            });

        }


        public void filtrarLista()
        {
            if (eleccionClaseCuentaModelo != null || eleccionClaseCuentaModelo.id != 0)
            {
                //Filtrar el listado
                if (eleccionElementoContable != null || eleccionElementoContable.id != 0)
                {
                    if (eleccionClaseCuentaModelo.descripcionccuentas.ToUpper().Trim() == "ELEMENTO")
                    {
                        visibilidadCuentaPadre = Visibility.Collapsed;
                    }
                    else
                    {
                        listaCuentasFiltradaModelo = listaFiltrada(eleccionClaseCuentaModelo, eleccionElementoContable);
                        //listaCuentasFiltradaModelo = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllByIdElementoYIdClaseCuenta(eleccionElementoContable, eleccionClaseCuentaModelo, currentSistemaContable));
                        if (listaCuentasFiltradaModelo.Count > 0)
                        {
                            visibilidadCuentaPadre = Visibility.Visible;
                        }
                        else
                        {
                            visibilidadCuentaPadre = Visibility.Collapsed;
                        }
                    }
                }
            }
        }

        public ObservableCollection<CatalogoCuentasModelo> listaFiltrada(ClaseCuentaModelo valor, ElementoModelo elementoModelo)
        {
            try
            {
                bool cuentaBase = false;
                ClaseCuentaModelo eleccion = valor as ClaseCuentaModelo;
                if (eleccion != null)
                {
                    if (eleccion == null && eleccion.id == 0)
                    {
                        return new ObservableCollection<CatalogoCuentasModelo>();
                    }
                    else
                    {
                        string dependencia = string.Empty;
                        //ObservableCollection<CatalogoCuentasModelo> castedCollection = listaEntidadSeleccion;
                        switch (eleccion.descripcionccuentas.ToUpper().Trim())
                        {
                            case "ELEMENTO":
                                cuentaBase = true;
                                break;
                            case "RUBRO":
                                dependencia = "ELEMENTO";
                                break;
                            case "CUENTA":
                                dependencia = "RUBRO";
                                break;
                            case "SUB-CUENTA":
                                dependencia = "CUENTA";
                                break;
                            case "SUB-SUB-CUENTA":
                                dependencia = "SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-CUENTA":
                                dependencia = "SUB-SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-SUB-CUENTA":
                                dependencia = "SUB-SUB-SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-SUB-SUB-CUENTA":
                                dependencia = "SUB-SUB-SUB-SUB-CUENTA";
                                break;
                            case "ELEMENTOS":
                                cuentaBase = true;
                                break;
                            case "RUBROS":
                                dependencia = "ELEMENTO";
                                break;
                            case "CUENTAS":
                                dependencia = "RUBRO";
                                break;
                            case "SUB-CUENTAS":
                                dependencia = "CUENTA";
                                break;
                            case "SUB-SUB-CUENTAS":
                                dependencia = "SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-CUENTAS":
                                dependencia = "SUB-SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-SUB-CUENTAS":
                                dependencia = "SUB-SUB-SUB-CUENTA";
                                break;
                            case "SUB-SUB-SUB-SUB-SUB-CUENTAS":
                                dependencia = "SUB-SUB-SUB-SUB-CUENTA";
                                break;
                        }
                        if (cuentaBase)
                        {
                            //Es una cuenta base no hay nada que deba depender de ella
                            return new ObservableCollection<CatalogoCuentasModelo>();
                        }
                        else
                        {
                            ObservableCollection<CatalogoCuentasModelo> filtrado = new ObservableCollection<CatalogoCuentasModelo>(listaEntidadSeleccion.Where(x => x.nombreClaseCuenta.ToUpper().Trim() == dependencia && x.idelementos == elementoModelo.id));

                            if ((filtrado.Count > 0))
                            {
                                //return new ObservableCollection<CatalogoCuentasModelo>(listaEntidadSeleccion.Where(x => x.nombreClaseCuenta.ToUpper().Trim() == dependencia.ToUpper().Trim() && x.idelementos == elementoModelo.id));
                                CatalogoCuentasModelo temporal = new CatalogoCuentasModelo
                                {
                                    idcc = 0,
                                    idelementos = 0,
                                    idsc = 0,
                                    catidcc = null,
                                    idccuentas = 0,
                                    codigocc = string.Empty,
                                    descripcioncc = "Ninguna",
                                    tiposaldocc = string.Empty,
                                    fechacreacioncc = MetodosModelo.homologacionFecha(),
                                    estadocc = "A",
                                    guardadoBase = false,
                                    ordencc = 1,
                                };
                                filtrado.Insert(0, temporal);
                                return filtrado;
                            }
                            else
                            {
                                return new ObservableCollection<CatalogoCuentasModelo>();
                            }
                        }
                    }
                }
                else
                {
                    return new ObservableCollection<CatalogoCuentasModelo>();
                }
            }
            catch (Exception)
            {
                return new ObservableCollection<CatalogoCuentasModelo>();
            }
        }
        #endregion

        private decimal ordenRegistro(CatalogoCuentasModelo padre, int idSc)
        {
            decimal ordenRespuesta = 0;
            if (!(padre == null))
            {
                if (!(padre.idcc == 0))
                {
                    int registros = CatalogoCuentasModelo.ContarSubRegistros(padre.idcc) + 1;
                    decimal factorSuma = MetodosModelo.factorPadre(padre.nombreClaseCuenta);
                    if (registros == 1)
                    {
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordencc, factorSuma);
                    }
                    else
                    {
                        //decimal suma = Decimal.Add((Decimal)0.01, (decimal)0.01 * registros);
                        //currentEntidad.ordenDh = Decimal.Add((Decimal)_selectedPadreEntidad.ordenDh, suma);
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordencc, factorSuma * registros);
                    }
                }
            }
            else
            {
                ordenRespuesta = (decimal)CatalogoCuentasModelo.FindOrden(idSc);
            }
            return ordenRespuesta;
        }
    }
}

//Correccion