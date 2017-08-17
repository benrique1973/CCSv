using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Messages.Navegacion.Herramientas.Programas;
using CapaDatos;
using SGPTWpf.Messages.Herramientas;
using System.Windows;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Model;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas.Programas
{
    public sealed class ProgramaPresentacionViewModel : ViewModeloBase
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

        #region fuenteLlamado 
        //Permite identificar si proviene del menu principal o si es de una ventana
        private string _fuenteLlamado;
        private string fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        #region tokenRecepcionEncargos

        private string _tokenRecepcionEncargos;
        private string tokenRecepcionEncargos
        {
            get { return _tokenRecepcionEncargos; }
            set { _tokenRecepcionEncargos = value; }
        }

        #endregion

        #region tokenRecepcionEncargosDetalle

        private string _tokenRecepcionEncargosDetalle;
        private string tokenRecepcionEncargosDetalle
        {
            get { return _tokenRecepcionEncargosDetalle; }
            set { _tokenRecepcionEncargosDetalle = value; }
        }

        #endregion

        #region fuenteCierre 
        //Permite identificar si proviene del menu principal o si es de una ventana
        private int _fuenteCierre;
        private int fuenteCierre
        {
            get { return _fuenteCierre; }
            set { _fuenteCierre = value; }
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

        private int opcionMenuCrud = 0;

        private int idFirmaUnica=2;//Id de firma a utilizar

        #endregion

        #region Lista de entidades


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

        #region ViewModel Properties : listaObjetivos

        public const string listaObjetivosPropertyName = "listaObjetivos";

        private ObservableCollection<DetalleHerramientasModelo> _listaObjetivos;

        public ObservableCollection<DetalleHerramientasModelo> listaObjetivos
        {
            get
            {
                return _listaObjetivos;
            }
            set
            {
                if (_listaObjetivos == value) return;

                _listaObjetivos = value;
                RaisePropertyChanged(listaObjetivosPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaAlcances

        public const string listaAlcancesPropertyName = "listaAlcances";

        private ObservableCollection<DetalleHerramientasModelo> _listaAlcances;

        public ObservableCollection<DetalleHerramientasModelo> listaAlcances
        {
            get
            {
                return _listaAlcances;
            }
            set
            {
                if (_listaAlcances == value) return;

                _listaAlcances = value;
                RaisePropertyChanged(listaAlcancesPropertyName);
            }
        }


        #endregion

        #region ViewModel Properties : listaDetalleProcedimientos

        public const string listaDetalleProcedimientosPropertyName = "listaDetalleProcedimientos";

        private ObservableCollection<DetalleHerramientasModelo> _listaDetalleProcedimientos;

        public ObservableCollection<DetalleHerramientasModelo> listaDetalleProcedimientos
        {
            get
            {
                return _listaDetalleProcedimientos;
            }
            set
            {
                if (_listaDetalleProcedimientos == value) return;

                _listaDetalleProcedimientos = value;
                RaisePropertyChanged(listaDetalleProcedimientosPropertyName);
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

            #region ViewModel Property : currentEntidad Herramienta Modelo

            public const string currentEntidadPropertyName = "currentEntidad";

            private HerramientasModelo _currentEntidad;

            public HerramientasModelo currentEntidad
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

            private DetalleHerramientasModelo _currentEntidadDetalle;

            public DetalleHerramientasModelo currentEntidadDetalle
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

            private decimal? _horasPlanHerramienta = 0;

            public decimal? horasPlanHerramienta
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

            #region horasEjecucionHerramienta

        public const string horasEjecucionHerramientaPropertyName = "horasEjecucionHerramienta";

        private decimal? _horasEjecucionHerramienta = 0;

        public decimal? horasEjecucionHerramienta
        {
            get
            {
                return _horasEjecucionHerramienta;
            }

            set
            {
                if (_horasEjecucionHerramienta == value)
                {
                    return;
                }

                _horasEjecucionHerramienta = value;
                RaisePropertyChanged(horasEjecucionHerramientaPropertyName);
            }
        }

        #endregion

            #region cantidadProcedimientosPlan

        public const string cantidadProcedimientosPlanPropertyName = "cantidadProcedimientosPlan";

        private decimal? _cantidadProcedimientosPlan = 0;

        public decimal? cantidadProcedimientosPlan
        {
            get
            {
                return _cantidadProcedimientosPlan;
            }

            set
            {
                if (_cantidadProcedimientosPlan == value)
                {
                    return;
                }

                _cantidadProcedimientosPlan = value;
                RaisePropertyChanged(cantidadProcedimientosPlanPropertyName);
            }
        }

        #endregion

            #region cantidadProcedimientosEjecucion

        public const string cantidadProcedimientosEjecucionPropertyName = "cantidadProcedimientosEjecucion";

        private decimal? _cantidadProcedimientosEjecucion = 0;

        public decimal? cantidadProcedimientosEjecucion
        {
            get
            {
                return _cantidadProcedimientosEjecucion;
            }

            set
            {
                if (_cantidadProcedimientosEjecucion == value)
                {
                    return;
                }

                _cantidadProcedimientosEjecucion = value;
                RaisePropertyChanged(cantidadProcedimientosEjecucionPropertyName);
            }
        }

        #endregion

            #region indiceHoras

        public const string indiceHorasPropertyName = "indiceHoras";

        private decimal? _indiceHoras = 0;

        public decimal? indiceHoras
        {
            get
            {
                return _indiceHoras;
            }

            set
            {
                if (_indiceHoras == value)
                {
                    return;
                }

                _indiceHoras = value;
                RaisePropertyChanged(indiceHorasPropertyName);
            }
        }

        #endregion

            #region indiceProcedimientos

        public const string indiceProcedimientosPropertyName = "indiceProcedimientos";

        private decimal? _indiceProcedimientos = 0;

        public decimal? indiceProcedimientos
        {
            get
            {
                return _indiceProcedimientos;
            }

            set
            {
                if (_indiceProcedimientos == value)
                {
                    return;
                }

                _indiceProcedimientos = value;
                RaisePropertyChanged(indiceProcedimientosPropertyName);
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
                    currentEntidadDetalle.descripcionDh = value;
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

            #region ordenDhPresentacion

        public const string ordenDhPresentacionPropertyName = "ordenDhPresentacion";

        private decimal _ordenDhPresentacion = 0;

        public decimal ordenDhPresentacion
        {
            get
            {
                return _ordenDhPresentacion;
            }

            set
            {
                if (_ordenDhPresentacion == value)
                {
                    return;
                }

                _ordenDhPresentacion = value;
                RaisePropertyChanged(ordenDhPresentacionPropertyName);
            }
        }

        #endregion

        #region propiedades en  ejecucion

        #region nombreCliente

        public const string nombreClientePropertyName = "nombreCliente";

        private string _nombreCliente = string.Empty;

        public string nombreCliente
        {
            get
            {
                return _nombreCliente;
            }

            set
            {
                if (_nombreCliente == value)
                {
                    return;
                }

                _nombreCliente = value;
                RaisePropertyChanged(nombreClientePropertyName);
            }
        }

        #endregion

        #region nombreElabora

        public const string nombreElaboraPropertyName = "nombreElabora";

        private string _nombreElabora = string.Empty;

        public string nombreElabora
        {
            get
            {
                return _nombreElabora;
            }

            set
            {
                if (_nombreElabora == value)
                {
                    return;
                }

                _nombreElabora = value;
                RaisePropertyChanged(nombreElaboraPropertyName);
            }
        }

        #endregion

        #region comentarioDh

        public const string comentarioDhPropertyName = "comentarioDh";

        private string _comentarioDh = string.Empty;

        public string comentarioDh
        {
            get
            {
                return _comentarioDh;
            }

            set
            {
                if (_comentarioDh == value)
                {
                    return;
                }

                _comentarioDh = value;
                RaisePropertyChanged(comentarioDhPropertyName);
            }
        }

        #endregion

        #region referenciaPt

        public const string referenciaPtPropertyName = "referenciaPt";

        private string _referenciaPt = string.Empty;

        public string referenciaPt
        {
            get
            {
                return _referenciaPt;
            }

            set
            {
                if (_referenciaPt == value)
                {
                    return;
                }

                _referenciaPt = value;
                RaisePropertyChanged(referenciaPtPropertyName);
            }
        }

        #endregion

        #region fechaEjecucion

        public const string fechaEjecucionPropertyName = "fechaEjecucion";

        private DateTime _fechaEjecucion = DateTime.Now;

        public DateTime fechaEjecucion
        {
            get
            {
                return _fechaEjecucion;
            }

            set
            {
                if (_fechaEjecucion == value)
                {
                    return;
                }

                _fechaEjecucion = value;
                RaisePropertyChanged(fechaEjecucionPropertyName);
            }
        }

        #endregion

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

            #region visibilidadObjetivos

            public const string visibilidadObjetivosPropertyName = "visibilidadObjetivos";

            private Visibility _visibilidadObjetivos = Visibility.Collapsed;

            public Visibility visibilidadObjetivos
            {
                get
                {
                    return _visibilidadObjetivos;
                }

                set
                {
                    if (_visibilidadObjetivos == value)
                    {
                        return;
                    }

                    _visibilidadObjetivos = value;
                    RaisePropertyChanged(visibilidadObjetivosPropertyName);
                }
            }

        #endregion

            #region visibilidadAlcances

        public const string visibilidadAlcancesPropertyName = "visibilidadAlcances";

        private Visibility _visibilidadAlcances = Visibility.Collapsed;

        public Visibility visibilidadAlcances
        {
            get
            {
                return _visibilidadAlcances;
            }

            set
            {
                if (_visibilidadAlcances == value)
                {
                    return;
                }

                _visibilidadAlcances = value;
                RaisePropertyChanged(visibilidadAlcancesPropertyName);
            }
        }

        #endregion


            #region visibilidadObjetivosReducido

        public const string visibilidadObjetivosReducidoPropertyName = "visibilidadObjetivosReducido";

        private Visibility _visibilidadObjetivosReducido = Visibility.Collapsed;

        public Visibility visibilidadObjetivosReducido
        {
            get
            {
                return _visibilidadObjetivosReducido;
            }

            set
            {
                if (_visibilidadObjetivosReducido == value)
                {
                    return;
                }

                _visibilidadObjetivosReducido = value;
                RaisePropertyChanged(visibilidadObjetivosReducidoPropertyName);
            }
        }

        #endregion

            #region visibilidadAlcancesReducido

        public const string visibilidadAlcancesReducidoPropertyName = "visibilidadAlcancesReducido";

        private Visibility _visibilidadAlcancesReducido = Visibility.Collapsed;

        public Visibility visibilidadAlcancesReducido
        {
            get
            {
                return _visibilidadAlcancesReducido;
            }

            set
            {
                if (_visibilidadAlcancesReducido == value)
                {
                    return;
                }

                _visibilidadAlcancesReducido = value;
                RaisePropertyChanged(visibilidadAlcancesReducidoPropertyName);
            }
        }

        #endregion

            #region nombreHerramientaVista

        public const string nombreHerramientaVistaPropertyName = "nombreHerramientaVista";

            private string _nombreHerramientaVista = string.Empty;

            public string nombreHerramientaVista
            {
                get
                {
                    return _nombreHerramientaVista;
                }

                set
                {
                    if (_nombreHerramientaVista == value)
                    {
                        return;
                    }

                    _nombreHerramientaVista = value;
                    RaisePropertyChanged(nombreHerramientaVistaPropertyName);
                }
            }

            #endregion


            #endregion

            #region ViewModel Commands

            public RelayCommand SalirCommand { get; set; }

            #endregion


            #region Implementacion comandos

            #region ViewModel Public Methods

            #region Constructores

            public ProgramaPresentacionViewModel()
            {
            _fechaEjecucion = MetodosModelo.FechaHoy();
            _salidaRealizada = false;
            _tokenRecepcionEncargos = "datosHPrograma";
            _tokenRecepcionEncargosDetalle = "HProgramaDetalle";
            _tokenEnvioCierre = "CierreHPrograma";
            _fuenteLlamado = "";
            //Llenado de encabezado
            try
            {
                currentFirma = FirmaModelo.Find(idFirmaUnica);//Solo hay un registro
            }
            catch (Exception)
            {
                currentFirma = new FirmaModelo();
                currentFirma.razonSocialFirma = "Corporación de Contadores de El Salvador";
                currentFirma.logofirma =null;
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
            //Captura de titulo de programa
                _salidaRealizada = false;
                _tokenEnvioCierre = "CierrePrevioPrograma";
                listaObjetivos = new ObservableCollection<DetalleHerramientasModelo>();
                listaAlcances = new ObservableCollection<DetalleHerramientasModelo>();
                listaDetalleProcedimientos = new ObservableCollection<DetalleHerramientasModelo>();
                //Mensaje de vista desde el menu principal
                Messenger.Default.Register<HModeloDatosMensajes>(this, tokenRecepcionEncargos, (herramientasModeloElementoCuestionarioMensajes) => ControlHerramientasModeloElementoMensajes(herramientasModeloElementoCuestionarioMensajes));
                //Datos de sub-ventana
                Messenger.Default.Register<HModeloDatosMensajes>(this, tokenRecepcionEncargosDetalle, (herramientasModeloElementoCuestionarioMensajes) => ControlHerramientasModeloElementoMensajes(herramientasModeloElementoCuestionarioMensajes));

                accesibilidadWindow = false;
                //Inicializar el contenido del frame con el detalle de procedimientos
                dlg = new DialogCoordinator();
                RegisterCommands();
            _fuenteCierre = 0;
        }

        private void ControlHerramientasModeloElementoMensajes(HModeloDatosMensajes herramientasModeloElementoMensajes)
        {

            currentUsuario = herramientasModeloElementoMensajes.usuarioValidado;
            currentEntidad = herramientasModeloElementoMensajes.herramientaModeloElemento;
            currentEntidadDetalle = herramientasModeloElementoMensajes.detalleHerramientaModelo;
            encabezadoPantalla = _currentEntidad.nombreHerramienta;
            horasPlanHerramienta = currentEntidad.horasPlanHerramienta;
            horasEjecucionHerramienta = 0;
            visibilidadObjetivos = Visibility.Visible;
            visibilidadAlcances = Visibility.Visible;
            visibilidadObjetivosReducido = Visibility.Collapsed;
            visibilidadAlcancesReducido = Visibility.Collapsed;
            indiceHoras = 0;
            indiceProcedimientos = 0;
            horasEjecucionHerramienta = 0;
            cantidadProcedimientosEjecucion = 0;
            cantidadProcedimientosPlan = 0;
            if (herramientasModeloElementoMensajes.cmd != 1)
            {
                fuenteLlamado = "Main";
                tokenEnvioCierre = "CierrePrevioVistaPrograma";
                //enviarMensajeInhabilitar();//Ventana main
                listaDetalleHerramienta = new ObservableCollection<DetalleHerramientasModelo>(DetalleHerramientasModelo.GetAllVista(currentEntidad.idHerramienta));
            }
            else
            {
                fuenteLlamado = "Sub-ventana";
                tokenEnvioCierre = "CierrePrevioProgramaSub-ventana";
                enviarMensajeInhabilitar(tokenEnvioCierre);
                listaDetalleHerramienta = herramientasModeloElementoMensajes.listaDetalleHerramienta;
            }
            if (horasPlanHerramienta > 0)
            {
                indiceHoras = 100 * (horasEjecucionHerramienta / horasPlanHerramienta);
            }
            else
            {
                indiceHoras = 0;
            }

            decimal contador = 1;
            decimal contadorProcedimiento = 1;
            decimal contadorAlcance = 1;

            DetalleHerramientasModelo padre;
            decimal diferencia = 0;
            //Basado en el  supuesto que la lista viene ordenada con base a ordenDh
            foreach (DetalleHerramientasModelo item in listaDetalleHerramienta)
            {
                if ((item.nombreTipoProcedimiento.ToUpper() == "Objetivo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Objetivo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Objetivo".ToUpper()))
                {
                    if (item.idDhPrincipalDh == null)
                    {
                        item.ordenDhPresentacion = DetalleHerramientasModelo.ordenConversion(contador);
                    }
                    else
                    {
                        contador--;
                        diferencia = Decimal.Subtract((decimal)item.ordenDh, Decimal.Truncate((decimal)item.ordenDh));
                        item.ordenDhPresentacion = DetalleHerramientasModelo.ordenConversion(Decimal.Add(contador, diferencia));
                    }
                    listaObjetivos.Add(item);
                    contador++;
                }
                else
                {
                    if (!((item.nombreTipoProcedimiento.ToUpper() == "Alcance".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Alcance".ToUpper() || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Alcance".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Alcance".ToUpper()))))
                    {
                        if ((item.nombreTipoProcedimiento.ToUpper() == "Titulo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Titulo".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Sub-Titulo".ToUpper()) || ((item.nombreTipoProcedimiento.ToUpper() == "Indicaciones".ToUpper()) || (item.nombreTipoProcedimiento.ToUpper() == "Sub-Indicaciones".ToUpper() || (item.nombreTipoProcedimiento.ToUpper() == "Sub-sub-Indicaciones".ToUpper()))))
                        {
                            item.ordenDhPresentacion = "";
                            listaDetalleProcedimientos.Add(item);
                        }
                        else
                        {

                            if (item.idDhPrincipalDh == null)
                            {
                                item.ordenDhPresentacion = DetalleHerramientasModelo.ordenConversion(contadorProcedimiento);
                            }
                            else
                            {
                                contadorProcedimiento--;
                                diferencia = Decimal.Subtract((decimal)item.ordenDh, Decimal.Truncate((decimal)item.ordenDh));
                                item.ordenDhPresentacion = DetalleHerramientasModelo.ordenConversion(Decimal.Add(contadorProcedimiento, diferencia));
                            }
                            listaDetalleProcedimientos.Add(item);
                            contadorProcedimiento++;
                        }


                    }
                    else
                    {
                        if (item.idDhPrincipalDh == null)
                        {
                            item.ordenDhPresentacion = DetalleHerramientasModelo.ordenConversion(contadorAlcance);

                        }
                        else
                        {
                            contadorAlcance--;
                            diferencia = Decimal.Subtract((decimal)item.ordenDh, Decimal.Truncate((decimal)item.ordenDh));
                            item.ordenDhPresentacion = DetalleHerramientasModelo.ordenConversion(Decimal.Add(contadorAlcance, diferencia));
                        }
                        listaAlcances.Add(item);
                        contadorAlcance++;
                    }
                }
                padre = item;
            }
            if (contadorAlcance > 1)
            {
                if (contadorAlcance == 2)
                {
                    visibilidadAlcancesReducido = Visibility.Visible;
                    visibilidadAlcances = Visibility.Collapsed;
                }
                else
                {
                    visibilidadAlcances = Visibility.Visible;
                    visibilidadAlcancesReducido = Visibility.Collapsed;
                }
            }
            else
            {
                visibilidadAlcances = Visibility.Collapsed;
                visibilidadAlcancesReducido = Visibility.Collapsed;
            }
            if (contador > 1)
            {
                if (contador == 2)
                {
                    visibilidadObjetivosReducido = Visibility.Visible;
                    visibilidadObjetivos = Visibility.Collapsed;
                }
                else
                {
                    visibilidadObjetivos = Visibility.Visible;
                }
            }
            else
            {
                visibilidadObjetivos = Visibility.Collapsed;
            }
            cantidadProcedimientosPlan = contadorProcedimiento - 1;
            cantidadProcedimientosEjecucion = 0;
            if (cantidadProcedimientosPlan > 0)
            {
                indiceProcedimientos = 100 * cantidadProcedimientosEjecucion / cantidadProcedimientosPlan;
            }
            else
            {
                indiceProcedimientos = 0;
            }
            #region Depuracion de numeros de presentacion

            foreach (DetalleHerramientasModelo item in listaDetalleProcedimientos)
            {
                if (item.ordenDhPresentacion.Length > 4)
                {
                    if (item.ordenDhPresentacion.Substring(item.ordenDhPresentacion.Length - 2, 2) == "00")
                    {
                        item.ordenDhPresentacion = item.ordenDhPresentacion.Substring(0, item.ordenDhPresentacion.Length - 2);
                    }
                }
            }

            #endregion
            //Desuscribir mensaje
            Messenger.Default.Unregister<HModeloDatosMensajes>(this, tokenRecepcionEncargos);
            Messenger.Default.Unregister<HModeloDatosMensajes>(this, tokenRecepcionEncargosDetalle);
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        #endregion


        private async void Cancelar()
        {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            await dlg.ShowMessageAsync(this, "Operación cancelada", "");
            accesibilidadWindow = false;
            Mouse.OverrideCursor = null;
            enviarMensaje();
            fuenteCierre = 1;
            CloseWindow();
        }

        private void OkCierre()
        {
            accesibilidadWindow = false;
            Mouse.OverrideCursor = Cursors.Wait;
            fuenteCierre = 1;
            enviarMensaje();
            CloseWindow();
        }

        private void Salir()
        {
            if (fuenteCierre == 0)
            {
                accesibilidadWindow = false;
                Mouse.OverrideCursor = Cursors.Wait;
                if (fuenteLlamado == "Main")
                {
                    enviarMensajeHabilitar();
                    enviarMensajeMain();
                }
                else
                {
                    enviarMensaje();
                    enviarMensajeHabilitar(tokenEnvioCierre);
                }
                fuenteCierre = 1;
                CloseWindow();
            }
            else
            {
                //Nada ya se cerro todo
            }
        }


        #endregion

        #region Mensajes

        //Procesando mensajes

        public void enviarMensajeMain()
        {
            //Creando el mensaje de cierre
            //VentanaControllerToHerramientasViewMensaje cierre = new VentanaControllerToHerramientasViewMensaje();
            VentanaControllerToHerramientasViewMensaje cierre = new VentanaControllerToHerramientasViewMensaje();
            cierre.activarVentana = true;
            Messenger.Default.Send(cierre);
        }
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
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            bool cerrado = true;
            Messenger.Default.Send(cerrado, tokenEnvioCierre);
        }

        public void enviarDetalleHerramientaMensaje()
            {
            //Creando el mensaje para que se actualice el listado.
                ProgramaPreviewDetalleVistaMensaje mensaje = new ProgramaPreviewDetalleVistaMensaje();

                mensaje.herramientaModelo = currentEntidad;
                mensaje.opcionMenuPrincipal = opcionMenu;
                mensaje.usuarioValidado = currentUsuario;
                mensaje.opcionMenuCrud = opcionMenuCrud;
                Messenger.Default.Send(mensaje);
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
            }

            #endregion


        }
    }

