using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using System.Windows;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using System.Windows.Input;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using System.Linq;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Model.Modelo.Menus;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias
{

    public sealed class DetalleCedulaViewModel : ViewModeloBase
        {
        //17-08-2017

            #region Propiedades privadas

            private MetroDialogSettings configuracionDialogo;

            private readonly IDialogCoordinator _dialogCoordinator;
            public static int Errors { get; set; }//Para controllar los errores de edición

            #region tokenRecepcionPadre

            private string _tokenRecepcionPadre;
            private string tokenRecepcionPadre
            {
                get { return _tokenRecepcionPadre; }
                set { _tokenRecepcionPadre = value; }
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

            #region FuenteLlamada

            private int _FuenteLlamada;
            private int FuenteLlamada
            {
                get { return _FuenteLlamada; }
                set { _FuenteLlamada = value; }
            }

            #endregion

            #region tokenRecepcionHijo

            private string _tokenRecepcionHijo;
            private string tokenRecepcionHijo
            {
                get { return _tokenRecepcionHijo; }
                set { _tokenRecepcionHijo = value; }
            }

            #endregion

            #region tokenEnvioVista

            private string _tokenEnvioVista;
            private string tokenEnvioVista
            {
                get { return _tokenEnvioVista; }
                set { _tokenEnvioVista = value; }
            }
            #endregion

            #region origenLlamada //Sirve para diferenciar las fuentas de  la llamada para las vistas
            //0 Sin identificar
            //1 Plan Indices
            //2 Plan Indices detalle
            //3 Documentacion indice
            //4 Documentacion detalle indice

            private int _origenLlamada;
            private int origenLlamada
            {
                get { return _origenLlamada; }
                set { _origenLlamada = value; }
            }

            #endregion


            #region fuenteLlamada

            private string _fuenteLlamada;
            private string fuenteLlamada
            {
                get { return _fuenteLlamada; }
                set { _fuenteLlamada = value; }
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

            #region comandoPartida

            private int _comandoPartida;
            private int comandoPartida
            {
                get { return _comandoPartida; }
                set { _comandoPartida = value; }
            }

        #endregion

        #region inicializacionCatalogo

        private int _inicializacionCatalogo;
        private int inicializacionCatalogo
        {
            get { return _inicializacionCatalogo; }
            set { _inicializacionCatalogo = value; }
        }

        #endregion

        private DialogCoordinator dlg;


            #endregion

            #region tokenEnvioDatosAHijo

            private string _tokenEnvioDatosAHijo;
            private string tokenEnvioDatosAHijo
            {
                get { return _tokenEnvioDatosAHijo; }
                set { _tokenEnvioDatosAHijo = value; }
            }

            #endregion

            #region tokenEnvioDatosAMenu

            private string _tokenEnvioDatosAMenu;
            private string tokenEnvioDatosAMenu
            {
                get { return _tokenEnvioDatosAMenu; }
                set { _tokenEnvioDatosAMenu = value; }
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

            #region tokenReferenciaVista

            private string _tokenReferenciaVista;
            private string tokenReferenciaVista
            {
                get { return _tokenReferenciaVista; }
                set { _tokenReferenciaVista = value; }
            }

            #endregion

            #region tokenEnvioDatosAVistaPreview

            private string _tokenEnvioDatosAVistaPreview;
            private string tokenEnvioDatosAVistaPreview
            {
                get { return _tokenEnvioDatosAVistaPreview; }
                set { _tokenEnvioDatosAVistaPreview = value; }
            }

            #endregion

            #region tokenRespuestaReferenciaVista

            private string _tokenRespuestaReferenciaVista;
            private string tokenRespuestaReferenciaVista
            {
                get { return _tokenRespuestaReferenciaVista; }
                set { _tokenRespuestaReferenciaVista = value; }
            }

        #endregion

            #region tokenRespuestaVistaColumna

            private string _tokenRespuestaVistaColumna;
            private string tokenRespuestaVistaColumna
            {
                get { return _tokenRespuestaVistaColumna; }
                set { _tokenRespuestaVistaColumna = value; }
            }

            #endregion

            #region ViewModel Properties : listaMarcas

            public const string listaMarcasPropertyName = "listaMarcas";

            private ObservableCollection<string> _listaMarcas;

            public ObservableCollection<string> listaMarcas
            {
                get
                {
                    return _listaMarcas;
                }
                set
                {
                    if (_listaMarcas == value) return;

                    _listaMarcas = value;
                    RaisePropertyChanged(listaMarcasPropertyName);
                }
            }


            #endregion

            #region ViewModel Properties : SelectedItems

            public const string SelectedItemsPropertyName = "SelectedItems";

                private ObservableCollection<CedulaModelo> _SelectedItems;

                public ObservableCollection<CedulaModelo> SelectedItems
                {
                    get
                    {
                        return _SelectedItems;
                    }
                    set
                    {
                        if (_SelectedItems == value) return;

                        _SelectedItems = value;

                        RaisePropertyChanged(SelectedItemsPropertyName);
                    }
                }

            #endregion

        //http://stackoverflow.com/questions/14918602/isselected-binding-in-wpf-datagrid

        #region ViewModel Properties : fechaBalanceAnterior

        public const string fechaBalanceAnteriorPropertyName = "fechaBalanceAnterior";

        private string _fechaBalanceAnterior;

        public string fechaBalanceAnterior
        {
            get
            {
                return _fechaBalanceAnterior;
            }

            set
            {
                if (_fechaBalanceAnterior == value)
                {
                    return;
                }

                _fechaBalanceAnterior = value;
                RaisePropertyChanged(fechaBalanceAnteriorPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : fechaBalanceActual

        public const string fechaBalanceActualPropertyName = "fechaBalanceActual";

        private string _fechaBalanceActual;

        public string fechaBalanceActual
        {
            get
            {
                return _fechaBalanceActual;
            }

            set
            {
                if (_fechaBalanceActual == value)
                {
                    return;
                }

                _fechaBalanceActual = value;
                RaisePropertyChanged(fechaBalanceActualPropertyName);
            }
        }

        #endregion


        #region Datagrid Properties : RecordIndex

        public const string RecordIndexPropertyName = "RecordIndex";

        private int _RecordIndex;

        public int RecordIndex
        {
            get
            {
                return _RecordIndex;
            }

            set
            {
                if (_RecordIndex == value)
                {
                    return;
                }

                _RecordIndex = value;
                RaisePropertyChanged(RecordIndexPropertyName);
            }
        }

        #endregion

        #region Datagrid Properties : RecordColumn

        public const string RecordColumnPropertyName = "RecordColumn";

        private DataGridColumn _RecordColumn;

        public DataGridColumn RecordColumn
        {
            get
            {
                return _RecordColumn;
            }

            set
            {
                if (_RecordColumn == value)
                {
                    return;
                }

                _RecordColumn = value;
                RaisePropertyChanged(RecordColumnPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : IsSelected

        public const string IsSelectedPropertyName = "IsSelected";

            private bool _IsSelected;

            public bool IsSelected
            {
                get
                {
                    return _IsSelected;
                }

                set
                {
                    if (_IsSelected == value)
                    {
                        return;
                    }

                    _IsSelected = value;
                    RaisePropertyChanged(IsSelectedPropertyName);
                }
            }

            #endregion

            #region ViewModel Properties : permitirArrastrar

            public const string permitirArrastrarPropertyName = "permitirArrastrar";

            private bool _permitirArrastrar;

            public bool permitirArrastrar
            {
                get
                {
                    return _permitirArrastrar;
                }

                set
                {
                    if (_permitirArrastrar == value)
                    {
                        return;
                    }

                    _permitirArrastrar = value;
                    RaisePropertyChanged(permitirArrastrarPropertyName);
                }
            }

            #endregion


            #region ViewModel Property : currentMaestro Carpeta Modelo

            public const string currentMaestroPropertyName = "currentMaestro";

            private CedulaModelo _currentMaestro;

            public CedulaModelo currentMaestro
            {
                get
                {
                    return _currentMaestro;
                }

                set
                {
                    if (_currentMaestro == value) return;

                    _currentMaestro = value;

                    // Update bindings, no broadcast
                    RaisePropertyChanged(currentMaestroPropertyName);
                }
            }

            #endregion

            #region Propiedades : Descripcion Tipo Carpeta Modelo


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

            #region ViewModel Properties : listaVistas

            public const string listaVistasPropertyName = "listaVistas";

            private ObservableCollection<menuBalanceDetalle> _listaVistas;

            public ObservableCollection<menuBalanceDetalle> listaVistas
            {
                get
                {
                    return _listaVistas;
                }

                set
                {
                    if (_listaVistas == value) return;

                    _listaVistas = value;

                    // Update bindings, no broadcast
                    RaisePropertyChanged(listaVistasPropertyName);
                }
            }

            #endregion

            #region ViewModel Properties : lista

            public const string listaPropertyName = "lista";

            private ObservableCollection<DetalleCedulaModelo> _lista;

            public ObservableCollection<DetalleCedulaModelo> lista
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

           #region ViewModel Properties : listaCedulaMarcas

        public const string listaCedulaMarcasPropertyName = "listaCedulaMarcas";

        private ObservableCollection<CedulaMarcasModelo> _listaCedulaMarcas;

        public ObservableCollection<CedulaMarcasModelo> listaCedulaMarcas
        {
            get
            {
                return _listaCedulaMarcas;
            }

            set
            {
                if (_listaCedulaMarcas == value) return;

                _listaCedulaMarcas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCedulaMarcasPropertyName);
            }
        }

        #endregion

           #region ViewModel Properties : listaDetalles

        public const string listaDetallesPropertyName = "listaDetalles";

            private ObservableCollection<BitacoraModelo> _listaDetalles;

            public ObservableCollection<BitacoraModelo> listaDetalles
            {
                get
                {
                    return _listaDetalles;
                }

                set
                {
                    if (_listaDetalles == value) return;

                    _listaDetalles = value;

                    // Update bindings, no broadcast
                    RaisePropertyChanged(listaDetallesPropertyName);
                }
            }

        #endregion

        #region Lista por partidas

        #region currentEntidadPartida

        public const string currentEntidadPartidaPropertyName = "currentEntidadPartida";

        private CedulaPartidasModelo _currentEntidadPartida;

        public CedulaPartidasModelo currentEntidadPartida
        {
            get
            {
                return _currentEntidadPartida;
            }

            set
            {
                if (_currentEntidadPartida == value) return;

                _currentEntidadPartida = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPartidaPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentCedulaPartidas

        public const string currentCedulaPartidasPropertyName = "currentCedulaPartidas";

        private CedulaModelo _currentCedulaPartidas;

        public CedulaModelo currentCedulaPartidas
        {
            get
            {
                return _currentCedulaPartidas;
            }

            set
            {
                if (_currentCedulaPartidas == value) return;

                _currentCedulaPartidas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentCedulaPartidasPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaDiario

        public const string listaDiarioPropertyName = "listaDiario";

        private ObservableCollection<CedulaDiarioModelo> _listaDiario;

        public ObservableCollection<CedulaDiarioModelo> listaDiario
        {
            get
            {
                return _listaDiario;
            }

            set
            {
                if (_listaDiario == value) return;

                _listaDiario = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDiarioPropertyName);
            }
        }

        #endregion


        #region ViewModel Properties : listaDetallesDiario

        public const string listaDetallesDiarioPropertyName = "listaDetallesDiario";

        private ObservableCollection<CedulaDiarioModelo> _listaDetallesDiario;

        public ObservableCollection<CedulaDiarioModelo> listaDetallesDiario
        {
            get
            {
                return _listaDetallesDiario;
            }

            set
            {
                if (_listaDetallesDiario == value) return;

                _listaDetallesDiario = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaDetallesDiarioPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaPartidas

        public const string listaPartidasPropertyName = "listaPartidas";

        private ObservableCollection<CedulaPartidasModelo> _listaPartidas;

        public ObservableCollection<CedulaPartidasModelo> listaPartidas
        {
            get
            {
                return _listaPartidas;
            }

            set
            {
                if (_listaPartidas == value) return;

                _listaPartidas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPartidasPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaMovimientos

        public const string listaMovimientosPropertyName = "listaMovimientos";

        private ObservableCollection<CedulaMovimientoModelo> _listaMovimientos;

        public ObservableCollection<CedulaMovimientoModelo> listaMovimientos
        {
            get
            {
                return _listaMovimientos;
            }

            set
            {
                if (_listaMovimientos == value) return;

                _listaMovimientos = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaMovimientosPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaMovimientosPorPartida

        public const string listaMovimientosPorPartidaPropertyName = "listaMovimientosPorPartida";

        private ObservableCollection<CedulaMovimientoModelo> _listaMovimientosPorPartida;

        public ObservableCollection<CedulaMovimientoModelo> listaMovimientosPorPartida
        {
            get
            {
                return _listaMovimientosPorPartida;
            }

            set
            {
                if (_listaMovimientosPorPartida == value) return;

                _listaMovimientosPorPartida = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaMovimientosPorPartidaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCatalogo

        public const string listaCatalogoPropertyName = "listaCatalogo";

        private ObservableCollection<CatalogoCuentasModelo> _listaCatalogo;

        public ObservableCollection<CatalogoCuentasModelo> listaCatalogo
        {
            get
            {
                return _listaCatalogo;
            }
            set
            {
                if (_listaCatalogo == value) return;

                _listaCatalogo = value;
                RaisePropertyChanged(listaCatalogoPropertyName);
            }
        }

        #endregion

        #endregion

        #region Entidades

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

            private DetalleCedulaModelo _currentEntidad;

            public DetalleCedulaModelo currentEntidad
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

            #region descripcioncb Clase balance

            public const string descripcioncbPropertyName = "descripcioncb";

            private string _descripcioncb = string.Empty;

            public string descripcioncb
            {
                get
                {
                    return _descripcioncb;
                }

                set
                {
                    if (_descripcioncb == value)
                    {
                        return;
                    }

                    _descripcioncb = value;
                    RaisePropertyChanged(descripcioncbPropertyName);
                }
            }


            #endregion

            #region codigoBuscado Clase detalleBalance

            public const string codigoBuscadoPropertyName = "codigoBuscado";

            private string _codigoBuscado = string.Empty;

            public string codigoBuscado
            {
                get
                {
                    return _codigoBuscado;
                }

                set
                {
                    if (_codigoBuscado == value)
                    {
                        return;
                    }

                    _codigoBuscado = value;
                    RaisePropertyChanged(codigoBuscadoPropertyName);
                }
            }


        #endregion


        #endregion

        #region Propiedades Catalogo Contale

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

            #region codigoContablePadre
            public string codigoContablePadre
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

            public const string nombreHerramientaPropertyName = "descripcioncc";

            private string _nombreHerramienta = string.Empty;

            public string descripcioncc
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


        #endregion

        #region Visibilidad de  botones



        #region visibilidadMCrear

        public const string visibilidadMCrearPropertyName = "visibilidadMCrear";

        private Visibility _visibilidadMCrear = Visibility.Collapsed;

        public Visibility visibilidadMCrear
        {
            get
            {
                return _visibilidadMCrear;
            }

            set
            {
                if (_visibilidadMCrear == value)
                {
                    return;
                }

                _visibilidadMCrear = value;
                RaisePropertyChanged(visibilidadMCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadMEditar

        public const string visibilidadMEditarPropertyName = "visibilidadMEditar";

        private Visibility _visibilidadMEditar = Visibility.Collapsed;

        public Visibility visibilidadMEditar
        {
            get
            {
                return _visibilidadMEditar;
            }

            set
            {
                if (_visibilidadMEditar == value)
                {
                    return;
                }

                _visibilidadMEditar = value;
                RaisePropertyChanged(visibilidadMEditarPropertyName);
            }
        }

        #endregion

        #region visibilidadMReferenciar

        public const string visibilidadMReferenciarPropertyName = "visibilidadMReferenciar";

        private Visibility _visibilidadMReferenciar = Visibility.Collapsed;

        public Visibility visibilidadMReferenciar
        {
            get
            {
                return _visibilidadMReferenciar;
            }

            set
            {
                if (_visibilidadMReferenciar == value)
                {
                    return;
                }

                _visibilidadMReferenciar = value;
                RaisePropertyChanged(visibilidadMReferenciarPropertyName);
            }
        }

        #endregion

        #region visibilidadMCerrar

        public const string visibilidadMCerrarPropertyName = "visibilidadMCerrar";

        private Visibility _visibilidadMCerrar = Visibility.Collapsed;

        public Visibility visibilidadMCerrar
        {
            get
            {
                return _visibilidadMCerrar;
            }

            set
            {
                if (_visibilidadMCerrar == value)
                {
                    return;
                }

                _visibilidadMCerrar = value;
                RaisePropertyChanged(visibilidadMCerrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMSupervisar

        public const string visibilidadMSupervisarPropertyName = "visibilidadMSupervisar";

        private Visibility _visibilidadMSupervisar = Visibility.Collapsed;

        public Visibility visibilidadMSupervisar
        {
            get
            {
                return _visibilidadMSupervisar;
            }

            set
            {
                if (_visibilidadMSupervisar == value)
                {
                    return;
                }

                _visibilidadMSupervisar = value;
                RaisePropertyChanged(visibilidadMSupervisarPropertyName);
            }
        }

        #endregion

        #region visibilidadMAprobar

        public const string visibilidadMAprobarPropertyName = "visibilidadMAprobar";

        private Visibility _visibilidadMAprobar = Visibility.Collapsed;

        public Visibility visibilidadMAprobar
        {
            get
            {
                return _visibilidadMAprobar;
            }

            set
            {
                if (_visibilidadMAprobar == value)
                {
                    return;
                }

                _visibilidadMAprobar = value;
                RaisePropertyChanged(visibilidadMAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadMBorrar

        public const string visibilidadMBorrarPropertyName = "visibilidadMBorrar";

        private Visibility _visibilidadMBorrar = Visibility.Collapsed;

        public Visibility visibilidadMBorrar
        {
            get
            {
                return _visibilidadMBorrar;
            }

            set
            {
                if (_visibilidadMBorrar == value)
                {
                    return;
                }

                _visibilidadMBorrar = value;
                RaisePropertyChanged(visibilidadMBorrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMConsulta

        public const string visibilidadMConsultaPropertyName = "visibilidadMConsulta";

        private Visibility _visibilidadMConsulta = Visibility.Collapsed;

        public Visibility visibilidadMConsulta
        {
            get
            {
                return _visibilidadMConsulta;
            }

            set
            {
                if (_visibilidadMConsulta == value)
                {
                    return;
                }

                _visibilidadMConsulta = value;
                RaisePropertyChanged(visibilidadMConsultaPropertyName);
            }
        }

        #endregion

        #region visibilidadMDetalle

        public const string visibilidadMDetallePropertyName = "visibilidadMDetalle";

        private Visibility _visibilidadMDetalle = Visibility.Collapsed;

        public Visibility visibilidadMDetalle
        {
            get
            {
                return _visibilidadMDetalle;
            }

            set
            {
                if (_visibilidadMDetalle == value)
                {
                    return;
                }

                _visibilidadMDetalle = value;
                RaisePropertyChanged(visibilidadMDetallePropertyName);
            }
        }

        #endregion

        #region visibilidadMVista

        public const string visibilidadMVistaPropertyName = "visibilidadMVista";

        private Visibility _visibilidadMVista = Visibility.Collapsed;

        public Visibility visibilidadMVista
        {
            get
            {
                return _visibilidadMVista;
            }

            set
            {
                if (_visibilidadMVista == value)
                {
                    return;
                }

                _visibilidadMVista = value;
                RaisePropertyChanged(visibilidadMVistaPropertyName);
            }
        }

        #endregion

        #region visibilidadMTask

        public const string visibilidadMTaskPropertyName = "visibilidadMTask";

        private Visibility _visibilidadMTask = Visibility.Collapsed;

        public Visibility visibilidadMTask
        {
            get
            {
                return _visibilidadMTask;
            }

            set
            {
                if (_visibilidadMTask == value)
                {
                    return;
                }

                _visibilidadMTask = value;
                RaisePropertyChanged(visibilidadMTaskPropertyName);
            }
        }

        #endregion


        #region visibilidadPdf

        public const string visibilidadPdfPropertyName = "visibilidadPdf";

        private Visibility _visibilidadPdf = Visibility.Collapsed;

        public Visibility visibilidadPdf
        {
            get
            {
                return _visibilidadPdf;
            }

            set
            {
                if (_visibilidadPdf == value)
                {
                    return;
                }

                _visibilidadPdf = value;
                RaisePropertyChanged(visibilidadPdfPropertyName);
            }
        }

        #endregion

        #region visibilidadMRegresar

        public const string visibilidadMRegresarPropertyName = "visibilidadMRegresar";

        private Visibility _visibilidadMRegresar = Visibility.Hidden;

        public Visibility visibilidadMRegresar
        {
            get
            {
                return _visibilidadMRegresar;
            }

            set
            {
                if (_visibilidadMRegresar == value)
                {
                    return;
                }

                _visibilidadMRegresar = value;
                RaisePropertyChanged(visibilidadMRegresarPropertyName);
            }
        }

        #endregion


        #region visibilidadMResponder

        public const string visibilidadMResponderPropertyName = "visibilidadMResponder";

        private Visibility _visibilidadMResponder = Visibility.Collapsed;

        public Visibility visibilidadMResponder
        {
            get
            {
                return _visibilidadMResponder;
            }

            set
            {
                if (_visibilidadMResponder == value)
                {
                    return;
                }

                _visibilidadMResponder = value;
                RaisePropertyChanged(visibilidadMResponderPropertyName);
            }
        }

        #endregion

        #region visibilidadMImprimir

        public const string visibilidadMImprimirPropertyName = "visibilidadMImprimir";

        private Visibility _visibilidadMImprimir = Visibility.Hidden;

        public Visibility visibilidadMImprimir
        {
            get
            {
                return _visibilidadMImprimir;
            }

            set
            {
                if (_visibilidadMImprimir == value)
                {
                    return;
                }

                _visibilidadMImprimir = value;
                RaisePropertyChanged(visibilidadMImprimirPropertyName);
            }
        }

        #endregion

        #endregion

        #region visibilidadBalanceAnterior

        public const string visibilidadBalanceAnteriorPropertyName = "visibilidadBalanceAnterior";

        private Visibility _visibilidadBalanceAnterior = Visibility.Hidden;

        public Visibility visibilidadBalanceAnterior
        {
            get
            {
                return _visibilidadBalanceAnterior;
            }

            set
            {
                if (_visibilidadBalanceAnterior == value)
                {
                    return;
                }

                _visibilidadBalanceAnterior = value;
                RaisePropertyChanged(visibilidadBalanceAnteriorPropertyName);
            }
        }

        #endregion


        #region menuContextual

        #region visibilidadMenuReferencias

        public const string visibilidadMenuReferenciasPropertyName = "visibilidadMenuReferencias";

        private Visibility _visibilidadMenuReferencias = Visibility.Collapsed;

        public Visibility visibilidadMenuReferencias
        {
            get
            {
                return _visibilidadMenuReferencias;
            }

            set
            {
                if (_visibilidadMenuReferencias == value)
                {
                    return;
                }

                _visibilidadMenuReferencias = value;
                RaisePropertyChanged(visibilidadMenuReferenciasPropertyName);
            }
        }

        #endregion

        #region visibilidadMenuMarcas

        public const string visibilidadMenuMarcasPropertyName = "visibilidadMenuMarcas";

        private Visibility _visibilidadMenuMarcas = Visibility.Collapsed;

        public Visibility visibilidadMenuMarcas
        {
            get
            {
                return _visibilidadMenuMarcas;
            }

            set
            {
                if (_visibilidadMenuMarcas == value)
                {
                    return;
                }

                _visibilidadMenuMarcas = value;
                RaisePropertyChanged(visibilidadMenuMarcasPropertyName);
            }
        }

        #endregion

        #region visibilidadMenuNotas

        public const string visibilidadMenuNotasPropertyName = "visibilidadMenuNotas";

        private Visibility _visibilidadMenuNotas = Visibility.Collapsed;

        public Visibility visibilidadMenuNotas
        {
            get
            {
                return _visibilidadMenuNotas;
            }

            set
            {
                if (_visibilidadMenuNotas == value)
                {
                    return;
                }

                _visibilidadMenuNotas = value;
                RaisePropertyChanged(visibilidadMenuNotasPropertyName);
            }
        }

        #endregion

        #region visibilidadMenuHallazgos

        public const string visibilidadMenuHallazgosPropertyName = "visibilidadMenuHallazgos";

        private Visibility _visibilidadMenuHallazgos = Visibility.Collapsed;

        public Visibility visibilidadMenuHallazgos
        {
            get
            {
                return _visibilidadMenuHallazgos;
            }

            set
            {
                if (_visibilidadMenuHallazgos == value)
                {
                    return;
                }

                _visibilidadMenuHallazgos = value;
                RaisePropertyChanged(visibilidadMenuHallazgosPropertyName);
            }
        }

        #endregion

        #region visibilidadMenuTareas

        public const string visibilidadMenuTareasPropertyName = "visibilidadMenuTareas";

        private Visibility _visibilidadMenuTareas = Visibility.Collapsed;

        public Visibility visibilidadMenuTareas
        {
            get
            {
                return _visibilidadMenuTareas;
            }

            set
            {
                if (_visibilidadMenuTareas == value)
                {
                    return;
                }

                _visibilidadMenuTareas = value;
                RaisePropertyChanged(visibilidadMenuTareasPropertyName);
            }
        }

        #endregion

        #region visibilidadMenuPartidas

        public const string visibilidadMenuPartidasPropertyName = "visibilidadMenuPartidas";

        private Visibility _visibilidadMenuPartidas = Visibility.Collapsed;

        public Visibility visibilidadMenuPartidas
        {
            get
            {
                return _visibilidadMenuPartidas;
            }

            set
            {
                if (_visibilidadMenuPartidas == value)
                {
                    return;
                }

                _visibilidadMenuPartidas = value;
                RaisePropertyChanged(visibilidadMenuPartidasPropertyName);
            }
        }

        #endregion

        #endregion fin  menuContextual

        #region filaIndice

        private int? _filaIndice;
        private int? filaIndice
        {
            get { return _filaIndice; }
            set { _filaIndice = value; }
        }
        #endregion

        #region colIndice

        private int? _colIndice;
        private int? colIndice
        {
            get { return _colIndice; }
            set { _colIndice = value; }
        }
        #endregion

        #region colNombre

        private string _colNombre;
        private string colNombre
        {
            get { return _colNombre; }
            set { _colNombre = value; }
        }
        #endregion

        #region ViewModel Commands
        public RelayCommand NuevoCommand { get; set; }
            public RelayCommand EditarCommand { get; set; }
            public RelayCommand BorrarCommand { get; set; }
            public RelayCommand ConsultarCommand { get; set; }
            public RelayCommand DoubleClickCommand { get; set; }
            public RelayCommand VistaProgramaCommand { get; set; }
            public RelayCommand vistaPreviaReferenciaCommand { get; set; }
            public RelayCommand<DetalleCedulaModelo> SelectionChangedCommand { get; set; }

        
            public RelayCommand<DataGrid> SelectionCellsChangedCommand { get; set; }

            public RelayCommand GestionMarcasCommand { get; set; }

            public RelayCommand GestionNotasCommand { get; set; }

            public RelayCommand GestionHallazgosCommand { get; set; }

            public RelayCommand GestionPartidasCommand { get; set; }

            public RelayCommand GestionTareasCommand { get; set; }

            public RelayCommand GestionReferenciasCommand { get; set; }

            public RelayCommand irMenuPadreCommand { get; set; }

            public RelayCommand referenciarCommand { get; set; }


        public RelayCommand copiarCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand detalleCommand { get; set; }

        public RelayCommand vistaCommand { get; set; }

        public RelayCommand aprobarTareaCommand { get; set; }
        public RelayCommand ResponderCommand { get; set; }
        public RelayCommand terminarPapelCommand { get; set; }
        public RelayCommand supervisarCommand { get; set; }

        public RelayCommand aprobarCommand { get; set; }
        public RelayCommand agendaCommand { get; set; }

        #region comandos Partidas
            public RelayCommand nuevaPartidaCommand { get; set; }
            public RelayCommand consultarPartidasCommand { get; set; }
            public RelayCommand editarPartidasCommand { get; set; }
            public RelayCommand borrarPartidaCommand { get; set; }
        #endregion

        #region comandos Notas
        public RelayCommand nuevaNotaCommand { get; set; }
        public RelayCommand consultarNotasCommand { get; set; }
        public RelayCommand editarNotasCommand { get; set; }
        public RelayCommand borrarNotaCommand { get; set; }
        #endregion

        #region comandos Hallazgos
        public RelayCommand nuevoHallazgoCommand { get; set; }
        public RelayCommand consultarHallazgosCommand { get; set; }
        public RelayCommand editarHallazgosCommand { get; set; }
        public RelayCommand borrarHallazgoCommand { get; set; }
        #endregion

        #endregion

        private void CellBeginningEditMethod(object sender, DataGridBeginningEditEventArgs e)
        {
            colIndice = e.Column.DisplayIndex;
            int valor = e.Column.DisplayIndex;
            MessageBox.Show("Columna " + colIndice);
        }

        #region EDDetalleIMainModel

        private MainModel _mainModel = null;

            public MainModel EDDetalleIMainModel
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

            public int NumberOfItemsSelected { get; private set; }

            #endregion


            #region ViewModel Public Methods

            #region Constructores


            public DetalleCedulaViewModel()
            {

            }

            public DetalleCedulaViewModel(string origen)
            {
                _fuenteLlamada = origen;
                configuracionDialogo = new MetroDialogSettings()
                {
                    AnimateShow = false,
                    AnimateHide = false
                };

                _dialogCoordinator = new DialogCoordinator();
                _cursorWindow = Cursors.Hand;//Definición preliminar

                _accesibilidadWindow = false;
                _IsSelected = false;
                _cursorWindow = Cursors.Hand;
                _opcionMenu = 0;
                _descripcioncb = string.Empty;
                _tokenEnvioDatosAVistaPreview = "LlamadaDeDetalle";
                switch (origen)
                {
                    case "cedulasSumariasDetalle":
                    #region configuracion

                    #region  menu

                    _visibilidadMCrear = Visibility.Visible; ;
                    _visibilidadMEditar = Visibility.Visible; ;
                    _visibilidadMBorrar = Visibility.Visible; ;
                    _visibilidadMConsulta = Visibility.Visible; ;
                    _visibilidadMReferenciar = Visibility.Visible;//Pendiente
                    _visibilidadMRegresar = Visibility.Visible;
                    _visibilidadMVista = Visibility.Collapsed; ;
                    _visibilidadMResponder = Visibility.Collapsed;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMTask = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    _visibilidadPdf = Visibility.Collapsed;
                    #endregion

                    #region token 
                    _permitirArrastrar = true;//Permite al usuario arrastrar
                        _tokenRecepcionPadre = "datosEncargoCedulasSumarias";//Permite captar los mensajes del  view model BalancesViewModel

                        _tokenEnvioDatosAHijo = "datosEncargoCedulasSumariasDetalle";  //Para control de los datos que  remite programas a sub-ventanas
                        _tokenRecepcionHijo = "datosControllerEncargoCedulasSumariasDetalle";
                        _tokenEnvioDatosAMenu = "PlanDetalleIndiceRegreso"; //Para regresar al menu anterior.
                        _tokenReferenciaVista = "datosControllerEncargoCedulasSumariasDetalleReferenciaVista";

                        _tokenRespuestaVistaColumna = "datosControllerEncargoCedulasSumariasDetalleColumna";
                        _tokenRecepcionVista = "datosControllerEncargoCedulasSumariasDetallefila";
                        _tokenEnvioVista = "datosControllerEncargoCedulasSumariasDetalleColumna";

                        _tokenRespuestaReferenciaVista = "RespuestaDatosControllerEncargoCedulasSumariasDetalleReferenciaVista";
                        #endregion
                        _FuenteLlamada = 0;
                        RegisterCommands();
                        _origenLlamada = 2;

                    #region menuContextual

                    visibilidadMenuHallazgos = Visibility.Collapsed;
                    visibilidadMenuMarcas = Visibility.Collapsed;
                    visibilidadMenuNotas = Visibility.Collapsed;
                    visibilidadMenuPartidas = Visibility.Collapsed;
                    visibilidadMenuReferencias = Visibility.Collapsed;
                    visibilidadMenuTareas = Visibility.Collapsed;

                    #endregion fin  menuContextual

                    #endregion

                    break;
                    case "EncargoDocumentacionIndiceDetalle":
                        #region configuracion
                        #region  menu

                        visibilidadMCrear = Visibility.Collapsed;
                        visibilidadMEditar = Visibility.Collapsed;
                        visibilidadMBorrar = Visibility.Collapsed;
                        visibilidadMConsulta = Visibility.Visible;
                        visibilidadMReferenciar = Visibility.Visible;//Pendiente
                        visibilidadMRegresar = Visibility.Visible;
                        visibilidadMVista = Visibility.Visible;
                        visibilidadMImprimir = Visibility.Collapsed;
                        #endregion
                        _permitirArrastrar = false;//Permite al usuario arrastrar
                        #region tokens

                        _tokenRecepcionPadre = "datosEncargoDocumentacionIndices";//Permite captar los mensajes del  view model BalancesViewModel
                        _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                        _tokenRecepcionHijo = "datosControllerDetalleIndices";
                        _tokenEnvioDatosAMenu = "DocumentacionDetalleIndiceRegreso"; //Para regresar al menu anterior.
                        _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices;
                        _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";
                        _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";
                        _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";

                        #endregion
                        _FuenteLlamada = 0;
                        RegisterCommands();
                        _origenLlamada = 2;
                        #endregion
                        break;
                    case "EncargoCierreIndiceDetalle":
                        #region configuracion
                        #region  menu

                        visibilidadMCrear = Visibility.Collapsed;
                        visibilidadMEditar = Visibility.Collapsed;
                        visibilidadMBorrar = Visibility.Collapsed;
                        visibilidadMConsulta = Visibility.Collapsed;
                        visibilidadMReferenciar = Visibility.Collapsed; //Pendiente
                        visibilidadMRegresar = Visibility.Collapsed;
                        visibilidadMVista = Visibility.Visible;
                        visibilidadMImprimir = Visibility.Collapsed;
                        #endregion
                        _permitirArrastrar = false;//Permite al usuario arrastrar
                        #region token
                        _tokenRecepcionPadre = "datosEncargoCierreIndices";//Permite captar los mensajes del  view model BalancesViewModel
                        _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                        _tokenRecepcionHijo = "datosControllerDetalleIndices";
                        _tokenEnvioDatosAMenu = "CierreDetalleIndiceRegreso";  //Para regresar al menu anterior.
                        _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices
                        _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";//Transmite a  la vista 
                        _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";//Transmite a  la vista
                        _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                        #endregion
                        _opcionMenu = 0;
                        _FuenteLlamada = 0;
                        RegisterCommands();
                        _origenLlamada = 2;
                        #endregion
                        break;
                    case "DocumentosConsultaIndiceDetalle":
                        #region configuracion
                        #region  menu

                        visibilidadMCrear = Visibility.Collapsed;
                        visibilidadMEditar = Visibility.Collapsed;
                        visibilidadMBorrar = Visibility.Collapsed;
                        visibilidadMConsulta = Visibility.Collapsed;
                        visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                        visibilidadMRegresar = Visibility.Collapsed;
                        visibilidadMVista = Visibility.Collapsed;
                        visibilidadMImprimir = Visibility.Visible;
                        #endregion
                        _permitirArrastrar = false;//Permite al usuario arrastrar
                        #region token
                        _tokenRecepcionPadre = "datosDocumentosConsultaIndices";//Permite captar los mensajes del  view model BalancesViewModel
                        _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                        _tokenRecepcionHijo = "datosControllerDetalleIndices";
                        _tokenEnvioDatosAMenu = "DocumentosConsultaDetalleIndiceRegreso";  //Para regresar al menu anterior.
                        _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices
                        _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";//Transmite a  la vista 
                        _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";//Transmite a  la vista
                        _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                        #endregion
                        _opcionMenu = 0;
                        _FuenteLlamada = 0;
                        _origenLlamada = 2;
                        #endregion
                        break;
                    case "DocumentosImpresionIndiceDetalle":
                        #region configuracion
                        #region  menu

                        visibilidadMCrear = Visibility.Collapsed;
                        visibilidadMEditar = Visibility.Collapsed;
                        visibilidadMBorrar = Visibility.Collapsed;
                        visibilidadMConsulta = Visibility.Collapsed;
                        visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                        visibilidadMRegresar = Visibility.Collapsed;
                        visibilidadMVista = Visibility.Collapsed;
                        visibilidadMImprimir = Visibility.Visible;
                        #endregion
                        _permitirArrastrar = false;//Permite al usuario arrastrar
                        #region token
                        _tokenRecepcionPadre = "datosDocumentosImpresionIndices";//Permite captar los mensajes del  view model BalancesViewModel
                        _tokenEnvioDatosAHijo = "datosPadreDetalleIndices";  //Para control de los datos que  remite programas a sub-ventanas
                        _tokenRecepcionHijo = "datosControllerDetalleIndices";
                        _tokenEnvioDatosAMenu = "DocumentosImpresionDetalleIndiceRegreso";  //Para regresar al menu anterior.
                        _tokenReferenciaVista = "PlanDetalleReferenciaVista";//Recepcion de indices
                        _tokenRecepcionVista = "EncargoPlanIndiceCambioOrden";//Transmite a  la vista 
                        _tokenEnvioVista = "EncargoPlanIndiceDetalleDatosVista";//Transmite a  la vista
                        _tokenRespuestaReferenciaVista = "RespuestaPlanDetalleReferenciaVista";
                        #endregion
                        _opcionMenu = 0;
                        _FuenteLlamada = 0;
                        RegisterCommands();
                        _origenLlamada = 2;
                        #endregion
                        break;
                }
                Messenger.Default.Register<CedulaMsj>(this, tokenRecepcionPadre, (datosMsj) => ControlRecepcionDatos(datosMsj));
                currentEncargo = null;
                currentEntidad = null;
                currentSistemaContable = null;
                _comando = 0;
                _comandoPartida = 0;
                dlg = new DialogCoordinator();
                lista = new ObservableCollection<DetalleCedulaModelo>();//Lista vacia no se conoce el encargo y el cliente
                listaDetalles = new ObservableCollection<BitacoraModelo>();
                EDDetalleIMainModel = new MainModel();
                _visibilidadBalanceAnterior = Visibility.Visible;
                _fechaBalanceActual = string.Empty;
                _fechaBalanceAnterior = string.Empty;
                //Messenger.Default.Register<bool>(this, tokenRecepcionVista, (recepcionDatos) => ControlCambioLista(recepcionDatos));
            Messenger.Default.Register<int>(this, tokenRecepcionVista, (recepcionDatos) => ControlCambioFila(recepcionDatos));

            Messenger.Default.Register<int>(this, tokenRespuestaVistaColumna, (recepcionDatos) => ControlCambioColumna(recepcionDatos));

            Messenger.Default.Register<celdaSeleccionadaMsj>(this, tokenRecepcionVista, (recepcionDatos) => ControlSeleccionRegistros(recepcionDatos));

            _listaCedulaMarcas = new ObservableCollection<CedulaMarcasModelo>();

            #region Marcas
            listaMarcas = new ObservableCollection<string>();//Lista vacia no se conoce el encargo y el cliente
            #endregion
            // InitData();
            _RecordIndex = 0;
            //_RecordColumn;
            _colIndice = -1;
            _filaIndice = -1;
            _colNombre = string.Empty;
            #region partidas
            _listaDiario = new ObservableCollection<CedulaDiarioModelo>();
            _listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>();
            _listaMovimientosPorPartida = new ObservableCollection<CedulaMovimientoModelo>();
            _listaDetallesDiario = new ObservableCollection<CedulaDiarioModelo>();
            _currentCedulaPartidas = new CedulaModelo();
            _currentEntidadPartida = new CedulaPartidasModelo();
            _listaCatalogo = new ObservableCollection<CatalogoCuentasModelo>();
            _inicializacionCatalogo = 0;
            #endregion
        }

        private void ControlSeleccionRegistros(celdaSeleccionadaMsj recepcionDatos)
        {
            if (recepcionDatos != null && recepcionDatos.columna != null && recepcionDatos.columna != -1 && recepcionDatos.fila != null && recepcionDatos.fila != -1)
            {
                colNombre = string.Empty;
                colIndice = recepcionDatos.columna;
                filaIndice = recepcionDatos.fila;
                currentEntidad = lista[(int)filaIndice];
                switch (recepcionDatos.columna)
                {
                    case 1:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Collapsed;
                        visibilidadMenuNotas = Visibility.Collapsed;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Visible;
                        visibilidadMenuTareas = Visibility.Collapsed;
                        colNombre = "referenciapapel";
                        #endregion fin  menuContextual

                        break;
                    case 4:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Collapsed;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Collapsed;
                        visibilidadMenuTareas = Visibility.Collapsed;
                        colNombre = "m1dc";
                        #endregion fin  menuContextual
                        break;
                    case 6:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Visible;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Collapsed;
                        visibilidadMenuTareas = Visibility.Collapsed;
                        colNombre = "m2dc";
                        #endregion fin  menuContextual
                        break;
                    case 8:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Visible;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Collapsed;
                        visibilidadMenuTareas = Visibility.Collapsed;
                        colNombre = "m3dc";
                        #endregion fin  menuContextual
                        break;
                    case 11:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Collapsed;
                        visibilidadMenuNotas = Visibility.Collapsed;
                        visibilidadMenuPartidas = Visibility.Visible;
                        visibilidadMenuReferencias = Visibility.Collapsed;
                        visibilidadMenuTareas = Visibility.Collapsed;

                        #endregion fin  menuContextual
                        break;
                    case 12:
                        #region menuContextual
                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Collapsed;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Collapsed;
                        visibilidadMenuTareas = Visibility.Collapsed;
                        colNombre = "m4dc";
                        #endregion fin  menuContextual
                        break;
                    case 13:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Collapsed;
                        visibilidadMenuMarcas = Visibility.Collapsed;
                        visibilidadMenuNotas = Visibility.Collapsed;
                        visibilidadMenuPartidas = Visibility.Visible;
                        visibilidadMenuReferencias = Visibility.Collapsed;
                        visibilidadMenuTareas = Visibility.Collapsed;
                        #endregion fin  menuContextual
                        break;
                    case 14:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Visible;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Visible;
                        visibilidadMenuPartidas = Visibility.Visible;
                        visibilidadMenuReferencias = Visibility.Visible;
                        visibilidadMenuTareas = Visibility.Visible;
                        colNombre = "m5dc";
                        #endregion fin  menuContextual
                        break;
                    case 16:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Visible;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Visible;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Visible;
                        visibilidadMenuTareas = Visibility.Visible;
                        colNombre = "m6dc";
                        #endregion fin  menuContextual
                        break;
                    case 18:
                        #region menuContextual

                        visibilidadMenuHallazgos = Visibility.Visible;
                        visibilidadMenuMarcas = Visibility.Visible;
                        visibilidadMenuNotas = Visibility.Visible;
                        visibilidadMenuPartidas = Visibility.Collapsed;
                        visibilidadMenuReferencias = Visibility.Visible;
                        visibilidadMenuTareas = Visibility.Visible;
                        colNombre = "m7dc";
                        #endregion fin  menuContextual
                        break;
                }
                //await mensajeAutoCerrado("Registros \n" + "fila " + filaIndice + "\n" + "columna " + colIndice, "Mensaje recibido", 2);

                Messenger.Default.Unregister<celdaSeleccionadaMsj>(this, tokenRecepcionVista);

                Messenger.Default.Register<celdaSeleccionadaMsj>(this, tokenRecepcionVista, (recepcionDatos2) => ControlSeleccionRegistros(recepcionDatos2));

            }
        }

        private void ControlCambioColumna(int recepcionDatos)
        {
            colIndice=recepcionDatos;
            switch (recepcionDatos)
            {
                case 1:
                    #region menuContextual

                    visibilidadMenuHallazgos = Visibility.Collapsed;
                    visibilidadMenuMarcas = Visibility.Collapsed;
                    visibilidadMenuNotas = Visibility.Collapsed;
                    visibilidadMenuPartidas = Visibility.Collapsed;
                    visibilidadMenuReferencias = Visibility.Visible;
                    visibilidadMenuTareas = Visibility.Collapsed;

                    #endregion fin  menuContextual
                    break;
                case 4:
                    #region menuContextual

                    visibilidadMenuHallazgos = Visibility.Collapsed;
                    visibilidadMenuMarcas = Visibility.Visible;
                    visibilidadMenuNotas = Visibility.Visible;
                    visibilidadMenuPartidas = Visibility.Collapsed;
                    visibilidadMenuReferencias = Visibility.Collapsed;
                    visibilidadMenuTareas = Visibility.Collapsed;

                    #endregion fin  menuContextual
                    break;
                case 6:
                    #region menuContextual

                    visibilidadMenuHallazgos = Visibility.Collapsed;
                    visibilidadMenuMarcas = Visibility.Visible;
                    visibilidadMenuNotas = Visibility.Visible;
                    visibilidadMenuPartidas = Visibility.Collapsed;
                    visibilidadMenuReferencias = Visibility.Collapsed;
                    visibilidadMenuTareas = Visibility.Collapsed;

                    #endregion fin  menuContextual
                    break;
                case 8:
                    #region menuContextual

                    visibilidadMenuHallazgos = Visibility.Collapsed;
                    visibilidadMenuMarcas = Visibility.Visible;
                    visibilidadMenuNotas = Visibility.Visible;
                    visibilidadMenuPartidas = Visibility.Collapsed;
                    visibilidadMenuReferencias = Visibility.Collapsed;
                    visibilidadMenuTareas = Visibility.Collapsed;

                    #endregion fin  menuContextual
                    break;
            }
        }

        private void ControlCambioFila(int recepcionDatos)
        {
            if(recepcionDatos!=-1)
            { 
            if (filaIndice != recepcionDatos)
            {
                filaIndice = recepcionDatos;
                    #region cambio datos
                    //Antes de cambiar  la entidad se enviará para guardar cualquier cambio posible.
                    /*if (currentEntidad != null && currentEntidad.iddc != 0)
                    {
                        DetalleCedulaModelo.UpdateModelo(currentEntidad);
                    }*/
                    #endregion
                    currentEntidad = lista[(int)filaIndice];
            }
            }
        }

        private async void ControlRecepcionDatos(CedulaMsj msj)
        {
            currentEncargo = msj.encargoModelo;//Encargo en uso actual
            currentUsuario = msj.usuarioModelo;
            //currentSistemaContable = msj.sistemaContableModelo;
            currentMaestro = msj.entidadMaestroModelo;

            if (currentMaestro.idbalanceanterior != null && currentMaestro.idbalanceanterior != 0)
            {
                visibilidadBalanceAnterior = Visibility.Visible;
            }
            else
            {
                visibilidadBalanceAnterior = Visibility.Collapsed;
            }
            opcionMenu = msj.opcionMenuCrud;
            FuenteLlamada = msj.fuenteLlamado;
            tokenEnvioDatosAMenu = msj.tokenRecepcionSubMenuDetalle;
            actualizarLista();
            #region catalogo
            inicializarCatalogo();
            #endregion
            //No se desuscribe porque continua existiendo
            //Messenger.Default.Unregister<CedulaMsj>(this, tokenRecepcionPadre);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
            Messenger.Default.Unregister<CedulaMsj>(this, tokenRecepcionPadre);
            if (currentMaestro.fechabalancebalance != null)
            {
                fechaBalanceActual = currentMaestro.fechabalancebalance;
            }
            if (currentMaestro.fechabalancebalanceComparativo != null)
            {
                fechaBalanceAnterior = currentMaestro.fechabalancebalanceComparativo;
            }

            #region Marcas

            CedulaModelo temporal = CedulaModelo.FindMaestro((int)currentEncargo.idencargo, 13, "Cédula de marcas");
            switch (temporal.idcedula)
            {
                case -1:
                    //Error en la comunicacion
                    //No  puede trabajarse
                    await mensajeAutoCerrado("Existen errores de comunicación", "No se recuperaron las  marcas", 1);
                    accesibilidadWindow = false;
                    break;
                case 0:
                    //Registro no creado, se deberá crear
                    temporal = new CedulaModelo();
                    temporal.idtc = 13;
                    temporal.idencargo = currentEncargo.idencargo;
                    temporal.titulocedula = "Cédula de marcas";
                    temporal.usuarioModelo = currentUsuario;
                    switch (CedulaModelo.Insert(temporal, true))
                    {
                        case 0://No se pudo insertar
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            accesibilidadWindow = false;
                            break;
                        case 1://Se inserto con éxito
                            //await mensajeAutoCerrado("Registro insertado con éxito", "Este mensaje desaparecerá en segundos", 1);
                            break;
                        case -1://Se inserto con éxito
                            await mensajeAutoCerrado("Error al insertar el registro", "Este mensaje desaparecerá en segundos", 1);
                            accesibilidadWindow = false;
                            break;
                    }
                    break;
                default:
                    //existe el registro
                    listaCedulaMarcas = CedulaMarcasModelo.GetAllEdicion(currentEncargo, temporal.idcedula);
                    listaMarcas.Add(" ");
                    if (listaCedulaMarcas.Count > 0)
                    {
                        foreach (CedulaMarcasModelo item in listaCedulaMarcas)
                        {
                            listaMarcas.Add(item.marcama);
                        }
                    }
                    //Cargar los registros dependientes
                    break;
            }
            #endregion Marcas

            #region Partidas

            currentCedulaPartidas = CedulaModelo.FindMaestro((int)currentEncargo.idencargo, 15, "Cédula de ajustes y reclasificaciones",currentMaestro.idvisita);
            switch (currentCedulaPartidas.idcedula)
            {
                case -1:
                    //Error en la comunicacion
                    //No  puede trabajarse
                    await mensajeAutoCerrado("Existen errores de comunicación", "Intentelo más tarde para recuperar detalle de partidas", 1);
                    accesibilidadWindow = false;
                    break;
                case 0:
                    //Registro no creado, se deberá crear
                    currentCedulaPartidas = new CedulaModelo();
                    currentCedulaPartidas.idtc = 15;
                    currentCedulaPartidas.idencargo = currentEncargo.idencargo;
                    currentCedulaPartidas.titulocedula = "Cédula de ajustes y reclasificaciones";
                    currentCedulaPartidas.usuarioModelo = currentUsuario;
                    currentCedulaPartidas.idvisita = currentMaestro.idvisita;
                    switch (CedulaModelo.Insert(currentCedulaPartidas, true))
                    {
                        case 0://No se pudo insertar
                            await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                            accesibilidadWindow = false;
                            break;
                        case 1://Se inserto con éxito
                            //await mensajeAutoCerrado("Registro insertado con éxito", "Este mensaje desaparecerá en segundos", 1);
                            break;
                        case -1://Se inserto con éxito
                            await mensajeAutoCerrado("Error al insertar el registro", "Este mensaje desaparecerá en segundos", 1);
                            accesibilidadWindow = false;
                            break;
                    }
                    break;
                default:
                    //existe el registro
                    actualizarListaPartidas();
                    //Cargar los registros dependientes
                    break;
            }
            #endregion Marcas
            #region mayorizacion
            //Mayorizar
            mayorizar();
            #endregion

        }

        private void actualizarSumaTotal()
        {
            foreach (DetalleCedulaModelo item in lista)
            {
                if (item.claseregistro == "S") //Es una cuenta
                {
                    item.saldoactualdc = lista.Where(x => x.claseregistro == "D").Sum(x => x.saldoactualdc);
                    item.saldoanteriordc = lista.Where(x => x.claseregistro == "D").Sum(x => x.saldoanteriordc);
                    if (item.saldoanteriordc != null && item.saldoanteriordc != 0)
                    {
                        item.aumentodc = lista.Where(x => x.claseregistro == "D").Sum(x => x.aumentodc);
                        item.disminuciondc = (item.aumentodc / item.saldoanteriordc) * 100;
                    }
                    item.cargoreajuste = lista.Where(x => x.claseregistro == "D").Sum(x => x.cargoreajuste);
                    item.abonoreajuste = lista.Where(x => x.claseregistro == "D").Sum(x => x.abonoreajuste);
                    item.cargoreajuste = lista.Where(x => x.claseregistro == "D").Sum(x => x.cargoreajuste);
                    item.abonoreclasificacion = lista.Where(x => x.claseregistro == "D").Sum(x => x.abonoreclasificacion);
                    item.cargoreclasificacion = lista.Where(x => x.claseregistro == "D").Sum(x => x.cargoreclasificacion);
                    item.abonoreajusteyreclasificacion = item.abonoreajuste + item.abonoreclasificacion;
                    item.cargosreajusteyreclasificacion = item.cargoreajuste + item.cargoreclasificacion;
                    item.saldofinaldc = lista.Where(x => x.claseregistro == "D").Sum(x => x.saldofinaldc);
                }
            }
        }


        private void mayorizar()
        {
            decimal? sumaCargos = 0;
            decimal? sumaAbonos = 0;
            decimal? sumaCargosAnterior = 0;
            decimal? sumaAbonosAnterior = 0;
            decimal? sumaCargosAjustes = 0;
            decimal? sumaAbonosAjustes = 0;
            decimal? sumaCargosAnteriorAjustes = 0;
            decimal? sumaAbonosAnteriorAjustes = 0;
            //string detallePartidas = "";
            foreach (DetalleCedulaModelo item in lista)
            {
                sumaCargos = 0;
                sumaAbonos = 0;
                sumaCargosAjustes = 0;
                sumaAbonosAjustes = 0;
                item.listaNumeroPartidasAbonos = new ObservableCollection<int>();
                item.listaNumeroPartidasCargos = new ObservableCollection<int>();
                item.m4dc = string.Empty;
                item.m5dc = string.Empty;
                if (item.claseregistro == "D") //Es una cuenta
                {
                    foreach (CedulaPartidasModelo partida in listaPartidas)
                    {
                        sumaCargosAnterior = sumaCargos;
                        sumaAbonosAnterior = sumaAbonos;
                        sumaCargosAnteriorAjustes = sumaCargosAjustes;
                        sumaAbonosAnteriorAjustes = sumaAbonosAjustes;
                        foreach (CatalogoCuentasModelo elemento in item.listaCuentasMayorizar)
                        {
                            if (partida.idpartida == 1)//Partida de ajuste
                            {
                                sumaCargosAjustes = listaMovimientos.Where(x => x.codigocc == elemento.codigocc && partida.idpartida == x.idpartida).Sum(x => x.cargomovimiento) + sumaCargosAjustes;
                                sumaAbonosAjustes = listaMovimientos.Where(x => x.codigocc == elemento.codigocc && partida.idpartida == x.idpartida).Sum(x => x.abonomovimiento) + sumaAbonosAjustes;
                            }
                            else
                            {
                                //Partidas de reclasificacion
                                sumaCargos = listaMovimientos.Where(x => x.codigocc == elemento.codigocc && partida.idpartida == x.idpartida).Sum(x => x.cargomovimiento) + sumaCargos;
                                sumaAbonos = listaMovimientos.Where(x => x.codigocc == elemento.codigocc && partida.idpartida == x.idpartida).Sum(x => x.abonomovimiento) + sumaAbonos;
                            }
                        }

                        if (sumaAbonos != sumaAbonosAnterior)
                        {
                            item.listaNumeroPartidasAbonos.Add((int)partida.numeropartida);
                        }
                        if (sumaCargos != sumaCargosAnterior)
                        {
                            item.listaNumeroPartidasCargos.Add((int)partida.numeropartida);
                        }
                        if (sumaAbonosAjustes != sumaAbonosAnteriorAjustes)
                        {
                            item.listaNumeroPartidasAbonos.Add((int)partida.numeropartida);
                        }
                        if (sumaCargosAjustes != sumaCargosAnteriorAjustes)
                        {
                            item.listaNumeroPartidasCargos.Add((int)partida.numeropartida);
                        }
                        sumaCargosAnterior = 0;
                        sumaAbonosAnterior = 0;
                        sumaCargosAnteriorAjustes = 0;
                        sumaAbonosAnteriorAjustes = 0;
                    }
                    if (item.listaNumeroPartidasCargos.Count > 0)
                    {
                        foreach (int numPartida in item.listaNumeroPartidasCargos)
                        {
                            if (item.m4dc == null || item.m4dc == "")
                            {
                                item.m4dc = numPartida.ToString();
                            }
                            else
                            {
                                item.m4dc = item.m4dc + ", " + numPartida.ToString();
                            }
                        }
                    }
                    if(item.listaNumeroPartidasAbonos.Count>0)
                    { 
                    foreach (int numPartida in item.listaNumeroPartidasAbonos)
                    {
                        if (item.m5dc == null || item.m5dc == "")
                        {
                            item.m5dc = numPartida.ToString();
                        }
                        else
                        {
                            item.m5dc = item.m5dc + ", " + numPartida.ToString();
                        }
                    }
                    }
                }
                item.abonoreajuste = sumaAbonosAjustes;
                item.cargoreajuste = sumaCargosAjustes;
                item.abonoreclasificacion = sumaAbonos;
                item.cargoreclasificacion = sumaCargos;

                if (item.tiposaldocc == "D" || item.tiposaldocc == "RD")
                {
                    item.saldofinaldc= item.saldoactualdc + item.cargoreajuste - item.abonoreajuste + item.cargoreclasificacion - item.abonoreclasificacion;
                }
                else
                {
                    item.saldofinaldc = item.saldoactualdc - item.cargoreajuste + item.abonoreajuste - item.cargoreclasificacion + item.abonoreclasificacion;
                }
                item.cargosreajusteyreclasificacion = sumaCargos + sumaCargosAjustes;
                item.abonoreajusteyreclasificacion = sumaAbonos + sumaCargosAjustes;
            }
            foreach (DetalleCedulaModelo item in lista)
            {
                if (item.claseregistro == "S") //Es una cuenta
                {
                    item.saldoactualdc = lista.Where(x => x.claseregistro == "D").Sum(x => x.saldoactualdc);
                    item.saldoanteriordc = lista.Where(x => x.claseregistro == "D").Sum(x => x.saldoanteriordc);
                    if (item.saldoanteriordc != null && item.saldoanteriordc != 0)
                    {
                        item.aumentodc = lista.Where(x => x.claseregistro == "D").Sum(x => x.aumentodc);
                        item.disminuciondc = (item.aumentodc / item.saldoanteriordc) * 100;
                    }
                    item.cargoreajuste = lista.Where(x => x.claseregistro == "D").Sum(x => x.cargoreajuste);
                    item.abonoreajuste = lista.Where(x => x.claseregistro=="D").Sum(x => x.abonoreajuste);
                    item.cargoreajuste = lista.Where(x => x.claseregistro == "D").Sum(x => x.cargoreajuste);
                    item.abonoreclasificacion = lista.Where(x => x.claseregistro == "D").Sum(x => x.abonoreclasificacion);
                    item.cargoreclasificacion = lista.Where(x => x.claseregistro == "D").Sum(x => x.cargoreclasificacion);
                    item.abonoreajusteyreclasificacion = item.abonoreajuste + item.abonoreclasificacion;
                    item.cargosreajusteyreclasificacion = item.cargoreajuste + item.cargoreclasificacion;
                    item.saldofinaldc= lista.Where(x => x.claseregistro == "D").Sum(x => x.saldofinaldc);

                }
            }
        }

        private void inicializarCatalogo()
        {
                //BackgroundWorker worker = new BackgroundWorker();
                //var secureString = passwordContainer.Password;
                //worker.DoWork += (object sender, DoWorkEventArgs e) =>
                //{
                    CatalogoCuentasModelo temporal = new CatalogoCuentasModelo();
                    listaCatalogo = CatalogoCuentasModelo.GetAllByIdScForDisplayToPartidas(((int)currentEncargo.idsc));
                    //Para cada cuenta buscar las subcuentas y agregarlas para mayorizar
                    foreach (DetalleCedulaModelo item in lista)
                    {
                        if (item.claseregistro == "D") //Es una cuenta
                        {
                            //Agregar el detalle en la listaCatalogo
                            temporal = listaCatalogo.Single(x => x.codigocc == item.codigocontabledc);
                            if (temporal.IsOperable)
                            {
                                //Es el ultimo nivel no requiere busqueda
                            }
                            else
                            {
                                //Requiere buscar el detalle para mayorizar
                                 //listaHijos = new ObservableCollection<CatalogoCuentasModelo>(listaDetalleHerramienta.Where(x => x.catidcc == item.idcc));
                                ObservableCollection<CatalogoCuentasModelo> listaInicial = new ObservableCollection<CatalogoCuentasModelo>(listaCatalogo.Where(x => x.catidcc == temporal.idcc));
                                bool adicion = false;
                                int recorrido = listaInicial.Count;
                                int inicioAnterior = 0;
                                do
                                {
                                    adicion = false;
                                    recorrido = listaInicial.Count;
                                    for (int i = inicioAnterior; i < recorrido; i++)
                                    {
                                        if (listaInicial[i].IsOperable)
                                        {
                                            //Es Ok ya esta  en el nivel final
                                        }
                                        else
                                        {
                                            foreach (CatalogoCuentasModelo elemento in listaCatalogo)
                                            {
                                                //si el elemento coincide con el padre y ademas no  existe ese elemento dentro del listado
                                                if (listaInicial[i].idcc == elemento.catidcc && listaInicial.Count(x=>x.idcc==elemento.idcc)==0)
                                                {
                                                    listaInicial.Add(elemento);//Se agrega el elemento
                                                    adicion = true;
                                                }
                                            }
                                        }
                                    }
                                    inicioAnterior = recorrido;
                                }
                                while (adicion);
                                //Se trasladan cuentas operables
                                item.listaCuentasMayorizar = new ObservableCollection<CatalogoCuentasModelo>(listaInicial.Where(x => x.IsOperable));
                            }
                            //temporal.listaSubCuentasMayorizacion =listaCatalogo.Select(x => x.catidcc == temporal.idcc));
                        }
                    }
                //};
                //worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                //{
                    inicializacionCatalogo = 1;
                //};
                //worker.Dispose();
                //worker.RunWorkerAsync();
        }

        private void actualizarListaPartidas()
        {
            try
            {
                listaPartidas = new ObservableCollection<CedulaPartidasModelo>(CedulaPartidasModelo.GetAllEdicion(currentEncargo, currentCedulaPartidas.idcedula));
                listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>(CedulaMovimientoModelo.GetAllEdicion(currentEncargo));
                listaDiario = CedulaDiarioModelo.GetAllEdicion(currentEncargo, currentCedulaPartidas.idcedula, listaPartidas, listaMovimientos);
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista partidas" + e, "");
                    listaDiario = new ObservableCollection<CedulaDiarioModelo>();
                    listaPartidas = new ObservableCollection<CedulaPartidasModelo>();
                    listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>();
                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }

            private void actualizarLista()
            {
                guardarlista();
                try
                {
                    //Internamenteo consigo el id del sistema contable
                    //lista = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAll(currentEncargo.idencargo));
                    lista = new ObservableCollection<DetalleCedulaModelo>(DetalleCedulaModelo.GetAllEdicion(currentEncargo,currentMaestro.idcedula));

                }
                catch (Exception e)
                {
                    if (e.Source != null)
                    {
                        dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista ", "" + e);

                    }
                }
                //Se manda a la vista actualizada
                enviarlistaDetalleVista();
            }

            private void enviarlistaDetalleVista()
            {
                //Manda la referencia de la vista; Para programas
                Messenger.Default.Send(lista, tokenEnvioVista);
            }

            public void guardarlista()
            {
                try
                {
                    if (lista.Where(x => x.guardadoBase == false).Count() > 0)
                    {

                        foreach (DetalleCedulaModelo item in lista)
                        {
                            if (item.guardadoBase == false && item.claseregistro!="M" && item.iddc!=0)
                            {
                                DetalleCedulaModelo.UpdateModeloReodenar(item);
                                item.guardadoBase = true;//Se actualizo el registro
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //Mensaje de error
                }
            }

            #endregion

            #region Envio mensajes


            //Caso de nuevo registro 
            public void enviarMensaje()
            {
                //Se crea el mensaje
                CedulaMsj elemento = new CedulaMsj();
                elemento.encargoModelo = currentEncargo;
                elemento.usuarioModelo = currentUsuario;
                //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
                elemento.entidadMaestroModelo = currentMaestro;//Para el caso de  edicion de programas
                                                            //elemento.listaTipoCarpetaModel =;
                elemento.listaDetalle = lista;
                elemento.opcionMenuCrud = comando;
                elemento.tokenRespuestaController = tokenRecepcionHijo;
                elemento.fuenteLlamado = origenLlamada; //no se utiliza
                Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
            }

            public void enviarMensajeCrud()
            {
                //Se crea el mensaje
                CedulaMsj elemento = new CedulaMsj();
                elemento.encargoModelo = currentEncargo;
                elemento.usuarioModelo = currentUsuario;
                elemento.entidadDetalle = currentEntidad;
                //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
                elemento.entidadMaestroModelo = currentMaestro;//Para el caso de  edicion de programas
                                                            //elemento.listaTipoCarpetaModel =;
                elemento.listaDetalle = lista;
                elemento.opcionMenuCrud = comando;
                elemento.tokenRespuestaController = tokenRecepcionHijo;
                elemento.fuenteLlamado = origenLlamada; //no se utilizaa
                Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
            }

        #endregion

        #region Receptor de mensajes

        private void ControlVentanaMensaje(int controlVentanaCrearMensaje)
            {
            EDDetalleIMainModel.TypeName = null;
            if (comandoPartida == 0)
            {
                #region Seleccion del retorno
                switch (comando)
                {
                    case 1:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarLista();
                        }
                        break;
                    case 2:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarLista();
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        //caso de vista de programa
                        break;
                    case 5://Programa vista
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarLista();
                        }
                        accesibilidadWindow = true;
                        enviarMensajeHabilitar();
                        break;
                    case 6:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarLista();
                        }
                        break;
                    case 7:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarLista();
                        }
                        //enviarMensajeHabilitar();
                        break;
                    case 8:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarLista();
                        }
                        //enviarMensajeHabilitar();
                        break;
                    case 12://Vista referencia
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            //actualizarLista();
                        }
                        //enviarMensajeHabilitar();
                        break;
                    default:
                        break;
                }
                #endregion seleccion  de retorno
            }
            else
            {
                #region Seleccion del retorno de partida
                switch (comandoPartida)
                {
                    case 1:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarListaPartidas();
                            mayorizar();
                        }
                        break;
                    case 2:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarListaPartidas();
                            mayorizar();
                        }
                        break;
                    case 3:
                        break;
                    case 4:
                        //caso de vista de programa
                        break;
                    case 5://Programa vista
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarListaPartidas();
                            mayorizar();
                        }
                        accesibilidadWindow = true;
                        enviarMensajeHabilitar();
                        break;
                    case 6:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarListaPartidas();
                            mayorizar();
                        }
                        break;
                    case 7:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarListaPartidas();
                            mayorizar();
                        }
                        //enviarMensajeHabilitar();
                        break;
                    case 8:
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            actualizarListaPartidas();
                            mayorizar();
                        }
                        //enviarMensajeHabilitar();
                        break;
                    case 12://Vista referencia
                        if (controlVentanaCrearMensaje != 0)//Cancelo o cerro la ventana no se requiere actualizar
                        {
                            //actualizarLista();
                        }
                        //enviarMensajeHabilitar();
                        break;
                    default:
                        break;
                }
                #endregion seleccion  de retorno partidas
            }
            //currentEntidad = null;
            finComando();
            }

            #endregion

            #region Implementacion de comandos
            public void Nuevo()
            {
                iniciarComando();
                //Para guardar lo que esta en la  pantalla
                //No se utiliza debido a que no existe edicion
                //ControlCambioLista(true);
                comando = 1;
                #region Inicializacion de herramienta 
                currentEntidad = new DetalleCedulaModelo(currentMaestro, currentEncargo,currentUsuario);
                if (lista.Count > 0)
                {
                    currentEntidad.ordendc = lista.Max(x => x.ordendc) + 10;
                }
                else
                {
                    currentEntidad.ordendc = 10;
                }
                //currentEntidad.balanceModelo = currentMaestro;
                EDDetalleIMainModel.TypeName = "DetalleSumariaModeloCrearview";
                #endregion

                activarCaptura = true;
                enviarMensajeCrud();
            }
            #endregion
            public async void Editar()
            {
                //Para guardar lo que esta en la  pantalla
                    if (!(currentEntidad == null))
                    {
                        iniciarComando();
                        comando = 2;
                        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloEditarview";
                        //currentEntidad.usuarioModelo = currentUsuario;
                        enviarMensajeCrud();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                    }
            }
            public async void Consultar()
            {
                //Para guardar lo que esta en la  pantalla
                    if (!(currentEntidad == null))
                    {
                        iniciarComando();
                        comando = 3;
                        //currentEntidad.usuarioModelo = currentUsuario;
                        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloConsultarView";
                        enviarMensajeCrud(); //Debe ir antes, porque evalua si la ventana es cero para enviarse

                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                    }

            }

            public async void Borrar()
            {

                //Para guardar lo que esta en la  pantalla
                if (!(currentEntidad == null))
                {
                if (lista.Where(x => x.claseregistro == "D").Count() > 1)
                {
                    //currentEntidad.usuarioModelo = currentUsuario;
                    var mySettings = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Ok",
                        NegativeButtonText = "Cancelar",
                    };

                    MessageDialogResult result = await dlg.ShowMessageAsync(this, "La acción no podrá revertirse", "¿Desea eliminar el o los  registros?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                    if (result == MessageDialogResult.Affirmative)
                    {
                        iniciarComandoBorrar();
                        //Para guardar lo que esta en la  pantalla
                        if (!(currentEntidad == null))
                        {
                            //caso de un registro
                            if (DetalleCedulaModelo.Delete((int)currentEntidad.iddc, true))
                            {
                                await mensajeAutoCerrado("Se borro el registro ", "Este mensaje desaparecerá en segundos", 2);
                                actualizarLista();
                                actualizarSumaTotal();
                                currentEntidad = new DetalleCedulaModelo();
                                finComandoBorrar();
                            }
                            else
                            {
                                finComandoBorrar();
                                await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                            }
                        }
                    }
                    else
                    {
                        finComandoBorrar();
                        await dlg.ShowMessageAsync(this, "Canceló la eliminacion", "");
                    }

                }
                else
                {
                    await mensajeAutoCerrado("Debe existir por lo menos una cuenta", "no puede eliminarse", 2);
                }
                }
                else
                {
                await mensajeAutoCerrado("Debe seleccionar el registro a eliminar", "", 1);
                }
                finComandoBorrar();
            }

        #endregion

        #region Verificaciones

        public void Actualizar(ObservableCollection<DetalleCedulaModelo> listaEntidad)
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
                if (currentEntidad.claseregistro == "D")
                {
                    try
                    {
                        return currentEntidad.idindice != 0 && (currentMaestro.usuariocerro == null || currentMaestro.usuariocerro == string.Empty);
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
                else
                {
                    return false;
                }
            }

            public bool CanVista()
            {
                if (!(currentEntidad == null))
                {
                    try
                    {
                        if (currentEntidad.referenciapapel != null)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
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

            public bool CanReferenciar()
            {
                bool resultado = false;
                if (!(currentEntidad == null))
                {
                    try
                    {
                        switch (currentEntidad.idcc)
                        {
                            case 0:
                                resultado = false;
                                break;
                            case 1:
                                resultado = false;
                                break;
                            case 2:
                                resultado = false;
                                break;
                            case 3:
                                resultado = false;
                                break;
                            case 4:
                                resultado = true;
                                break;
                            case 5:
                                resultado = true;
                                break;
                            case 6:
                                resultado = true;
                                break;
                            case 7:
                                resultado = true;
                                break;
                            case 8:
                                resultado = false;
                                break;
                            case 9:
                                resultado = false;
                                break;
                        }
                        return resultado;
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


            #region ViewModel Private Methods

            private void RegisterCommands()
            {
                NuevoCommand = new RelayCommand(Nuevo, null);//ok
                EditarCommand = new RelayCommand(Editar, CanCommand);
                BorrarCommand = new RelayCommand(Borrar, CanCommand);//ok
                ConsultarCommand = new RelayCommand(Consultar, CanCommand);
                DoubleClickCommand = new RelayCommand(Consultar);

                //vistaPreviaReferenciaCommand = new RelayCommand(vistaPreviaReferencia, CanVista);

                VistaProgramaCommand = new RelayCommand(VistaPrograma, CanVista);
                SelectionChangedCommand = new RelayCommand<DetalleCedulaModelo>(entidad =>
                {
                    if (entidad == null) return;
                    //Verificar la cantidad de  registros seleccionados
                    currentEntidad = entidad;

                    //listaDetalles = entidad.listaBitacora;
                });
                irMenuPadreCommand = new RelayCommand(irPrincipal);

                referenciarCommand = new RelayCommand(Referenciar, CanReferenciar);


                GestionMarcasCommand = new RelayCommand(gestionarMarca);

                GestionNotasCommand = new RelayCommand(gestionarNotas);


                GestionHallazgosCommand = new RelayCommand(gestionarHallazgos);

                GestionPartidasCommand  =new RelayCommand(gestionarPartidas);

                GestionTareasCommand  =new RelayCommand(gestionarTareas);

                GestionReferenciasCommand = new RelayCommand(gestionarReferencias);

                SelectionCellsChangedCommand=new RelayCommand<DataGrid> (entidad =>
            {
                if (entidad == null) return;
                //Verificar la cantidad de  registros seleccionados
                var valor = entidad;

                //listaDetalles = entidad.listaBitacora;
            });
            #region comandos de Partidas
                nuevaPartidaCommand = new RelayCommand(nuevoPartida );
                consultarPartidasCommand = new RelayCommand(consultarPartidas );
                editarPartidasCommand = new RelayCommand(editarPartidas );
                borrarPartidaCommand = new RelayCommand(borrarPartida );

            #endregion

            #region comandos de Hallazgos
            nuevoHallazgoCommand = new RelayCommand(nuevoHallazgo);
            consultarHallazgosCommand = new RelayCommand(consultarHallazgos);
            editarHallazgosCommand = new RelayCommand(editarHallazgos);
            borrarHallazgoCommand = new RelayCommand(borrarHallazgo);

            #endregion

            #region comandos de Notas
            nuevaNotaCommand = new RelayCommand(nuevoNota);
            consultarNotasCommand = new RelayCommand(consultarNotas);
            editarNotasCommand = new RelayCommand(editarNotas);
            borrarNotaCommand = new RelayCommand(borrarNota);

            #endregion
        }

        private void borrarHallazgo()
        {
            throw new NotImplementedException();
        }

        private void editarHallazgos()
        {
            throw new NotImplementedException();
        }

        private void consultarHallazgos()
        {
            throw new NotImplementedException();
        }

        private void nuevoHallazgo()
        {
            throw new NotImplementedException();
        }

        private void borrarNota()
        {
            throw new NotImplementedException();
        }

        private void editarNotas()
        {
            throw new NotImplementedException();
        }

        private void consultarNotas()
        {
            throw new NotImplementedException();
        }

        private void nuevoNota()
        {
            throw new NotImplementedException();
        }

        private void editarPartidas()
        {
            throw new NotImplementedException();
        }

        private void borrarPartida()
        {
            throw new NotImplementedException();
        }

        private async void consultarPartidas()
        {
            if (!(currentEntidad == null))
            {
                if (currentEntidad.cargosreajusteyreclasificacion == 0 && currentEntidad.abonoreajusteyreclasificacion == 0)
                {
                    await mensajeAutoCerrado("El registro no tiene ni  cargos o abonos", "No  hay nada que consultar", 2);
                }
                else
                {
                    bool sumaValida = true;
                    switch (colIndice)
                    {
                        case 11:
                            //Cargos
                            if (currentEntidad.cargosreajusteyreclasificacion == 0)
                            {
                                await mensajeAutoCerrado("El registro no tiene ni cargos", "No  hay nada que consultar", 2);
                                sumaValida = false;
                            }
                            break;
                        case 13:
                            //Abonos
                            if (currentEntidad.abonoreajusteyreclasificacion == 0)
                            {
                                await mensajeAutoCerrado("El registro no tiene ni abonos", "No  hay nada que consultar", 2);
                                sumaValida = false;
                            }
                            break;
                        default:
                            await mensajeAutoCerrado("Error en selección de registro", " ", 2);
                            sumaValida = false;
                            break;

                    }
                    if(sumaValida)
                    { 
                        iniciarComando();
                        comando = 3;
                        comandoPartida = 3;
                        //currentEntidad.usuarioModelo = currentUsuario;
                        EDDetalleIMainModel.TypeName = "CedulaAjustesReclasificacionesConsultaview";
                        enviarMensajePartidasConsulta(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    }
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        private void nuevoPartida()
        {
            iniciarComando();
            //Para guardar lo que esta en la  pantalla
            //No se utiliza debido a que no existe edicion
            comando = 1;
            comandoPartida = 1;
            #region Inicializacion de herramienta 
            currentEntidadPartida = new CedulaPartidasModelo(currentCedulaPartidas, currentEncargo, currentUsuario);
            currentEntidadPartida.elaboradapartida = currentUsuario.inicialesusuario;
            currentEntidadPartida.numeropartida = listaPartidas.Count() + 1;
            currentEntidadPartida.idcedula = currentCedulaPartidas.idcedula;
            #region filtrado
            //Con base a seleccion de partida currentEntidadDetalle
            //currentEntidadPartida = listaPartidas.SingleOrDefault(x => x.idpartida == currentEntidadDetalle.idpartida);
            listaMovimientosPorPartida = new ObservableCollection<CedulaMovimientoModelo>();
            listaDetallesDiario = new ObservableCollection<CedulaDiarioModelo>();
            #endregion

            EDDetalleIMainModel.TypeName = "CedulaAjustesReclasificacionesCrearview";
            #endregion

            activarCaptura = true;
            enviarMensajePartidas();
        }

        public void enviarMensajePartidas()
        {
            //Se crea el mensaje
            AjustesYReclasificacionesMsj elemento = new AjustesYReclasificacionesMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo =currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentCedulaPartidas;//Para el caso de  edicion de programas
                                                           //elemento.listaMaestroModelo = lista;
            elemento.listaDiario = listaDiario;
            elemento.listaDetalle = listaPartidas;//Lista completa de diario
            elemento.entidadDetalle = currentEntidadPartida;
            //elemento.listaDiario = listaDetalles;//Partida de diario en especificio
            elemento.listaMovimientosPorPartida = listaMovimientosPorPartida;//Movimientos de la partida en particular
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRecepcionHijo;
            elemento.fuenteLlamado =3; //no se utiliza
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }
        public void enviarMensajePartidasConsulta()
        {
            //Se crea el mensaje
            AjustesYReclasificacionesMsj elemento = new AjustesYReclasificacionesMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            elemento.entidadMaestroModelo = currentCedulaPartidas;//Para el caso de  edicion de programas
                                                                  //elemento.listaMaestroModelo = lista;
            #region Seleccion de partidas
            //Filtrando el numero de partida
            ObservableCollection<CedulaPartidasModelo> listaDetalleMsj = new ObservableCollection<CedulaPartidasModelo>();
            switch (colIndice)
            {
                case 11:
                    //Cargos
                    foreach (CedulaPartidasModelo item in listaPartidas)
                    {
                    foreach(int idPartida in currentEntidad.listaNumeroPartidasCargos)
                        {
                            if (idPartida == item.numeropartida)
                            {
                                listaDetalleMsj.Add(item);
                            }
                        }
                    }
                    break;
                case 13:
                    //Abonos
                    foreach (CedulaPartidasModelo item in listaPartidas)
                    {
                        foreach (int idPartida in currentEntidad.listaNumeroPartidasAbonos)
                        {
                            if (idPartida == item.numeropartida)
                            {
                                listaDetalleMsj.Add(item);
                            }
                        }
                    }
                    break;
            }
            //elemento.listaDetalle = listaPartidas;//Lista completa de diario
            elemento.listaDetalle = listaDetalleMsj;//Lista filtrada de composicion  de abonos
            #endregion fin  seleccion de partidas

            #region Seleccion de movimientos de partidas
            //Filtrando las partidas seleccionadas

            ObservableCollection<CedulaDiarioModelo> listaDiarioMsj = new ObservableCollection<CedulaDiarioModelo>();
            foreach (CedulaPartidasModelo partida in elemento.listaDetalle)
            {
                foreach (CedulaDiarioModelo item in listaDiario)
                {
                    if (item.idpartida == partida.idpartida)
                    {
                        listaDiarioMsj.Add(item);
                    }
                }
            }
            elemento.listaDiario = listaDiarioMsj;
            //elemento.listaDiario = listaDiario;
            #endregion fin de seleccion de partidas

            #region filtrado de movimientos
            ObservableCollection<CedulaMovimientoModelo> listaMovimientosMsj = new ObservableCollection<CedulaMovimientoModelo>();
            foreach (CedulaPartidasModelo partida in elemento.listaDetalle)
            {
                foreach (CedulaMovimientoModelo item in listaMovimientos)
                {
                    if (item.idpartida == partida.idpartida)
                    {
                        listaMovimientosMsj.Add(item);
                    }
                }
            }
            elemento.listaMovimientosPorPartida = listaMovimientosMsj;
            #endregion filtrado de movimientos

            elemento.entidadDetalle = currentEntidadPartida;

            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuestaController = tokenRecepcionHijo;
            elemento.tokenRecepcionSubMenuDetalle = tokenRecepcionHijo;
            elemento.fuenteLlamado = 3; //no se utiliza
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }


        private async void gestionarReferencias()
        {
            if (colIndice != -1 && filaIndice != -1 && currentEntidad != null && currentEntidad.iddc != 0)
            {
                //Gestionar referencias
                //await mensajeAutoCerrado("Nota Insertar columna " + colIndice + "\n fila " + filaIndice + "\n", "", 3);
                currentEntidad = lista[(int)filaIndice];
                #region gestion

                //Insertar-Modificar
                //Borrar
                //Ir a referencia
                //Cancelar
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Insertar/Modificar",
                    NegativeButtonText = "Borrar",
                    FirstAuxiliaryButtonText = "Cancelar",
                    //SecondAuxiliaryButtonText="Cancelar"
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione la opción", "Gestión de referencias",
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    //Se mandara listado de referencias y realizará la inserción
                    if (currentEntidad != null && colIndice!=-1)
                    {
                        comando = 8;//Referenciar
                        iniciarComando();
                        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloReferenciarview";
                        enviarMensajeReferenciacion();
                    }
                    else
                    {
                        await mensajeAutoCerrado("Debe seleccionar el elemento a referenciar", "", 2);
                    }

                }
                else
                {
                    if (result == MessageDialogResult.Negative)
                    {
                        //Borrar la referencia
                        DetalleCedulaModelo.BorrarModeloReferencia(currentEntidad);
                        await mensajeAutoCerrado("Referencia eliminada", "", 2);
                    }
                    else
                    {
                        //if (result == MessageDialogResult.FirstAuxiliary)
                        //{
                        //    if (currentEntidad != null && colIndice != -1)
                        //    {
                        //        comando = 8;//Referenciar
                        //        iniciarComando();
                        //        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloVerview";
                        //        enviarMensajeReferenciacion();
                        //    }
                        //    else
                        //    {
                        //        await mensajeAutoCerrado("Debe seleccionar el elemento a referenciar", "", 2);
                        //    }
                        //}
                        //else
                        //{
                            await dlg.ShowMessageAsync(this, "Cancelo operación", "");
                            finComando();

                    }
                }


                #endregion
            }
            else
            {
                await mensajeAutoCerrado("Debe seleccionar una celta para operar","Seleccione una celda", 2);
            }
            //await mensajeAutoCerrado("Nota Insertar columna " + colIndice + "\n fila " + filaIndice + "\n", "", 3);
            finComando();
        }

        public void enviarMensajeReferenciacion()
        {
            //Se crea el mensaje
            EncargoPlanDetalleIndiceMsj elemento = new EncargoPlanDetalleIndiceMsj();
            elemento.encargoModelo = currentEncargo;
            elemento.usuarioModelo = currentUsuario;
            //elemento.detalleHerramientaElemento = currentEntidad;
            //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
            //elemento.herramientaModelo = currentCarpeta;//Para el caso de  edicion de programas
            //elemento.listaTipoCarpetaModel =;
            //elemento.listaElementos = lista;
            elemento.opcionMenuCrud = comando;
            elemento.tokenRespuesta = tokenRecepcionHijo;
            elemento.fuenteLlamado = 5; //no se utiliza
            //elemento.programaModelo = currentDetallePrograma;
            elemento.detalleCedulaModelo = currentEntidad;
            elemento.columnaDestino =(int) colIndice;
            Messenger.Default.Send(elemento, tokenEnvioDatosAHijo);
        }

        private void gestionarTareas()
        {
            throw new NotImplementedException();
        }

        private async void gestionarPartidas()
        {
            if (colIndice != -1 && filaIndice != -1 && currentEntidad != null && currentEntidad.iddc != 0)
            {
                //Gestionar referencias
                //await mensajeAutoCerrado("Nota Insertar columna " + colIndice + "\n fila " + filaIndice + "\n", "", 3);
                currentEntidad = lista[(int)filaIndice];
                #region gestion

                //Insertar-Modificar
                //Borrar
                //Ir a referencia
                //Cancelar
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Insertar/Modificar",
                    NegativeButtonText = "Borrar",
                    FirstAuxiliaryButtonText = "Cancelar",
                    //SecondAuxiliaryButtonText="Cancelar"
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione la opción", "Gestión de referencias",
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    //Se mandara listado de referencias y realizará la inserción
                    if (currentEntidad != null && colIndice != -1)
                    {
                        comando = 8;//Referenciar
                        iniciarComando();
                        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloReferenciarview";
                        enviarMensajeReferenciacion();
                    }
                    else
                    {
                        await mensajeAutoCerrado("Debe seleccionar el elemento a referenciar", "", 2);
                    }

                }
                else
                {
                    if (result == MessageDialogResult.Negative)
                    {
                        //Borrar la referencia
                        DetalleCedulaModelo.BorrarModeloReferencia(currentEntidad);
                        await mensajeAutoCerrado("Referencia eliminada", "", 2);
                    }
                    else
                    {
                        //if (result == MessageDialogResult.FirstAuxiliary)
                        //{
                        //    if (currentEntidad != null && colIndice != -1)
                        //    {
                        //        comando = 8;//Referenciar
                        //        iniciarComando();
                        //        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloVerview";
                        //        enviarMensajeReferenciacion();
                        //    }
                        //    else
                        //    {
                        //        await mensajeAutoCerrado("Debe seleccionar el elemento a referenciar", "", 2);
                        //    }
                        //}
                        //else
                        //{
                        await dlg.ShowMessageAsync(this, "Cancelo operación", "");
                        finComando();

                    }
                }


                #endregion
            }
            else
            {
                await mensajeAutoCerrado("Debe seleccionar una celta para operar", "Seleccione una celda", 2);
            }
            //await mensajeAutoCerrado("Nota Insertar columna " + colIndice + "\n fila " + filaIndice + "\n", "", 3);
            finComando();
        }

        private void gestionarHallazgos()
        {
            throw new NotImplementedException();
        }

        private async void gestionarNotas()
        {
            await mensajeAutoCerrado("Nota Insertar columna "+ colIndice +"\n fila "+ filaIndice+"\n","", 3);
        }

        private async void gestionarMarca()
        {
            if (colIndice != -1 && filaIndice != -1 && currentEntidad != null && currentEntidad.iddc != 0)
            {
                //Gestionar referencias
                //await mensajeAutoCerrado("Nota Insertar columna " + colIndice + "\n fila " + filaIndice + "\n", "", 3);
                currentEntidad = lista[(int)filaIndice];
                #region gestion

                //Insertar-Modificar
                //Borrar
                //Ir a referencia
                //Cancelar
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Insertar/Modificar",
                    NegativeButtonText = "Borrar",
                    FirstAuxiliaryButtonText = "Cancelar",
                    //SecondAuxiliaryButtonText="Cancelar"
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Seleccione la opción", "Gestión de marcas",
                MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    //Se mandara listado de referencias y realizará la inserción
                    if (currentEntidad != null && colIndice != -1)
                    {
                        comando = 8;//Referenciar
                        iniciarComando();
                        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloMarcasview";
                        //enviarMensajeMarca();
                    }
                    else
                    {
                        await mensajeAutoCerrado("Debe seleccionar el elemento para insertar la marca", "", 2);
                    }

                }
                else
                {
                    if (result == MessageDialogResult.Negative)
                    {
                        //Borrar la referencia
                        DetalleCedulaModelo.BorrarModeloMarca(currentEntidad,colNombre);
                        await mensajeAutoCerrado("Marca eliminada", "", 2);
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Cancelo operación", "");
                        finComando();

                    }
                }


                #endregion
            }
            else
            {
                await mensajeAutoCerrado("Debe seleccionar una celta para operar", "Seleccione una celda", 2);
            }
            //await mensajeAutoCerrado("Nota Insertar columna " + colIndice + "\n fila " + filaIndice + "\n", "", 3);
            finComando();
        }


        public void enviarDetalleMensaje()
            {
                //Se crea el mensaje
                CedulaMsj elemento = new CedulaMsj();
                elemento.encargoModelo = currentEncargo;
                elemento.usuarioModelo = currentUsuario;
                //elemento.sistemaContableModelo = currentSistemaContable;//Programa a crear 
                elemento.entidadMaestroModelo = currentMaestro;//Para el caso de  edicion de programas
                                                            //elemento.listaCedulaModelo = lista;
                elemento.opcionMenuCrud = comando;
                elemento.tokenRespuestaController = tokenRecepcionHijo;
                elemento.tokenRespuestaVista = tokenRecepcionHijo;
                elemento.fuenteLlamado = FuenteLlamada; //no se utilizaa
                Messenger.Default.Send(elemento, tokenEnvioDatosAVistaPreview);
            }

            private void consultarCarpeta()
            {
                throw new NotImplementedException();
            }

 
 
 
            private async void Referenciar()
            {
                if (lista.Where(x => x.IsSelected).Count() == 1)
                {
                    if (!(currentEntidad == null))
                    {
                        iniciarComando();
                        comando = 8;//Referenciar
                        EDDetalleIMainModel.TypeName = "DetalleSumariaModeloReferenciarview";
                        //currentEntidad.usuarioModelo = currentUsuario;
                        enviarMensajeCrud();  //Debe ir antes, porque evalua si la ventana es cero para enviarse
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Debe seleccionar el elemento a referenciar", "");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar solo un registro para referenciar", "");
                }
            }



            private void irPrincipal()
            {
                iniciarComando();
            #region cambio datos
            //Antes de regresar se guarda cualquier cambio posible.
            if (lista.Count() > 0)
            {
                foreach (DetalleCedulaModelo item in lista)
                {
                    if (item.claseregistro != "M")
                    {
                        DetalleCedulaModelo.UpdateModelo(item);
                    }
                }
            }

                    //if (currentEntidad != null && currentEntidad.iddc != 0)
                    //{
                    //    DetalleCedulaModelo.UpdateModelo(currentEntidad);
                    //}
                    #endregion
            //Mandar el mensaje al principal que domina la pantalla
            Messenger.Default.Send(currentMaestro.idcedula, tokenEnvioDatosAMenu);
            }

            private async void mostrarCantidad(int i)
            {
                await dlg.ShowMessageAsync(this, "Hay " + i + " registros seleccionados", "");
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
                    EDDetalleIMainModel.TypeName = "CedulaModeloVerProgramaView";
                    //enviarElemento(currentEntidad);
                    enviarMensaje(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
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
                Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPadre);
            }
            public void enviarMensajeHabilitar()
            {
                //Se crea el mensaje
                TabItemMensaje inhabilitar = new TabItemMensaje();
                inhabilitar.mensaje = true;
                Messenger.Default.Send<TabItemMensaje>(inhabilitar);
            }


            private void iniciarComandoBorrar()
            {
                //cursorWindow = Cursors.Wait;
                Mouse.OverrideCursor = Cursors.Wait;
                enviarMensajeInhabilitar();
                accesibilidadWindow = false;
            }

            private void finComandoBorrar()
            {
                //cursorWindow = null;
                Mouse.OverrideCursor = null;
                enviarMensajeHabilitar();
                accesibilidadWindow = true;
            }
            private void iniciarComando()
            {
                //cursorWindow = Cursors.Wait;
                Mouse.OverrideCursor = Cursors.Wait;
                Messenger.Default.Register<int>(this, tokenRecepcionHijo, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
                //Messenger.Default.Register<int>(this, tokenRecepcionCierrePreView, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));
                //Messenger.Default.Register<bool>(this, tokenRecepcionHijo, (recepcionDatos) => ControlCambioLista(recepcionDatos));
                Messenger.Default.Register<int>(this, tokenRespuestaReferenciaVista, (controllerProgramaViewMensaje) => ControlVentanaMensaje(controllerProgramaViewMensaje));

                accesibilidadWindow = false;
            }

            private void finComando()
            {
                //cursorWindow = null;
                Mouse.OverrideCursor = null;
                Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
                Messenger.Default.Unregister<int>(this, tokenRespuestaReferenciaVista);
                Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);
                if (comando == 12)
                {
                    enviarMensajeHabilitar();
                }
                //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
                accesibilidadWindow = true;
                comando = 0;
                comandoPartida = 0;
            }


        #endregion Fin de comando

        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
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