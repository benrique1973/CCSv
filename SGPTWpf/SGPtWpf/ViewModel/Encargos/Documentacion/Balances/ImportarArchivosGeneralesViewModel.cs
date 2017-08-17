using CapaDatos;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Soporte;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ImportarArchivosGeneralesViewModel : ViewModeloBase
    {
        #region Inicio  clase

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
        public ObservableCollection<ElementoModelo> listaElementos { get; set; }
        public List<clasesbalance> ListadoClaseBalance { get; set; }
        public List<periodo>       ListaPeriodoBalance { get; set; }

        #region ViewModel Properties : listaCatalogoImportar

        public const string listaCatalogoImportarPropertyName = "listaCatalogoImportar";

        private ObservableCollection<CatalogoCuentasModelo> _listaCatalogoImportar;

        public ObservableCollection<CatalogoCuentasModelo> listaCatalogoImportar
        {
            get
            {
                return _listaCatalogoImportar;
            }

            set
            {
                if (_listaCatalogoImportar == value) return;

                _listaCatalogoImportar = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCatalogoImportarPropertyName);
            }
        }

        #endregion

        public ObservableCollection<ClaseCuentaModelo> listaClaseCuenta { get; set; }
        public ObservableCollection<detallebalance> ListitaDetalleBalance { get; set; } // lista para insertar en la base
        public List<DetalleBalanceModelo> ListaDetalleBalance { get; set; } // lista para mostrar al usuario

        private bool HayCatalogoGeneradoAPartirBalance;

        private clasesbalance _SelectedClaseBalance;
        public clasesbalance SelectedClaseBalance
        {
            get { return _SelectedClaseBalance; }
            set { _SelectedClaseBalance = value; RaisePropertyChanged("SelectedClaseBalance"); }
        }

        private periodo _SelectedPeriodoBalance;
        public periodo SelectedPeriodoBalance
        {
            get { return _SelectedPeriodoBalance; }
            set { _SelectedPeriodoBalance = value; RaisePropertyChanged("SelectedPeriodoBalance"); }
        }


        private clasecuenta _SelectedClaseCuenta;
        public clasecuenta SelectedClaseCuenta
        {
            get { return _SelectedClaseCuenta; }
            set { _SelectedClaseCuenta = value; RaisePropertyChanged("SelectedClaseCuenta"); }
        }

        private DialogCoordinator dlg;
        public SGPTEntidades db = new SGPTEntidades();

        System.Data.DataTable dt = new System.Data.DataTable();
        private string _message;
        public string Message
        { get { return _message; }
          set { _message = value;
                RaisePropertyChanged("Message");
                if (!string.IsNullOrEmpty(_message))
                {
                    visibilidadMsjProceso = Visibility.Visible;
                }
                else
                {
                    visibilidadMsjProceso = Visibility.Collapsed;
                }
        }
        }

        #region ViewModel Properties : lista

        public const string listaPropertyName = "lista";

        private ObservableCollection<CatalogoCuentasModelo> _lista;

        public ObservableCollection<CatalogoCuentasModelo> lista
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

        private CargarArchivosMensajeModal _MensajeModalRecibido;
        public CargarArchivosMensajeModal MensajeModalRecibido
        {
            get { return _MensajeModalRecibido; }
            set { _MensajeModalRecibido = value; RaisePropertyChanged("MensajeModalRecibido"); }
        }
        #endregion

        #region Sistema contable

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

        #region ViewModel Property : currentEntidad Catalogo Modelo

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

        #region Propiedades de vista

        //03-05-2017 Belr
        #region ViewModel Properties : accesibilidadWindow
        //Controla la accesibilidad de  la vista
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

        #region ViewModel Properties : accesibilidadBotones
        //Controla la accesibilidad de botones
        public const string accesibilidadBotonesPropertyName = "accesibilidadBotones";

        private bool _accesibilidadBotones;

        public bool accesibilidadBotones
        {
            get
            {
                return _accesibilidadBotones;
            }

            set
            {
                if (_accesibilidadBotones == value)
                {
                    return;
                }

                _accesibilidadBotones = value;
                RaisePropertyChanged(accesibilidadBotonesPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : tipoArchivoACargar
        //Controla la accesibilidad de botones
        public const string tipoArchivoACargarPropertyName = "tipoArchivoACargar";

        private TipoArchivoCargar _tipoArchivoACargar;

        public TipoArchivoCargar tipoArchivoACargar
        {
            get
            {
                return _tipoArchivoACargar;
            }

            set
            {
                if (_tipoArchivoACargar == value)
                {
                    return;
                }

                _tipoArchivoACargar = value;
                RaisePropertyChanged(tipoArchivoACargarPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : HabilitartxtNombreCatalogo
        //Controla la accesibilidad de botones
        public const string HabilitartxtNombreCatalogoPropertyName = "HabilitartxtNombreCatalogo";

        private bool _HabilitartxtNombreCatalogo;

        public bool HabilitartxtNombreCatalogo
        {
            get
            {
                return _HabilitartxtNombreCatalogo;
            }

            set
            {
                if (_HabilitartxtNombreCatalogo == value)
                {
                    return;
                }

                _HabilitartxtNombreCatalogo = value;
                RaisePropertyChanged(HabilitartxtNombreCatalogoPropertyName);
            }
        }

        #endregion

        #region visibilidadMsjProceso
        //Gestiona la visibilidad del mensaje del encabezado
        public const string visibilidadMsjProcesoPropertyName = "visibilidadMsjProceso";

        private Visibility _visibilidadMsjProceso = Visibility.Visible;

        public Visibility visibilidadMsjProceso
        {
            get
            {
                return _visibilidadMsjProceso;
            }

            set
            {
                if (_visibilidadMsjProceso == value)
                {
                    return;
                }

                _visibilidadMsjProceso = value;
                RaisePropertyChanged(visibilidadMsjProcesoPropertyName);
            }
        }

        #endregion

        #region visibilidadOpcionesBalance
        //Se activa en el  caso de los balances
        public const string visibilidadOpcionesBalancePropertyName = "visibilidadOpcionesBalance";

        private Visibility _visibilidadOpcionesBalance = Visibility.Visible;

        public Visibility visibilidadOpcionesBalance
        {
            get
            {
                return _visibilidadOpcionesBalance;
            }

            set
            {
                if (_visibilidadOpcionesBalance == value)
                {
                    return;
                }

                _visibilidadOpcionesBalance = value;
                RaisePropertyChanged(visibilidadOpcionesBalancePropertyName);
            }
        }

        #endregion

        #region visibilityHoja

        public const string visibilityHojaPropertyName = "visibilityHoja";

        private Visibility _visibilityHoja = Visibility.Visible;

        public Visibility visibilityHoja
        {
            get
            {
                return _visibilityHoja;
            }

            set
            {
                if (_visibilityHoja == value)
                {
                    return;
                }

                _visibilityHoja = value;
                RaisePropertyChanged(visibilityHojaPropertyName);
            }
        }

        #endregion

        #region visibilityDatosCaptura

        public const string visibilityDatosCapturaPropertyName = "visibilityDatosCaptura";

        private Visibility _visibilityDatosCaptura = Visibility.Visible;

        public Visibility visibilityDatosCaptura
        {
            get
            {
                return _visibilityDatosCaptura;
            }

            set
            {
                if (_visibilityDatosCaptura == value)
                {
                    return;
                }

                _visibilityDatosCaptura = value;
                RaisePropertyChanged(visibilityDatosCapturaPropertyName);
            }
        }

        #endregion

        #region visibilityDatosTransformados

        public const string visibilityDatosTransformadosPropertyName = "visibilityDatosTransformados";

        private Visibility _visibilityDatosTransformados = Visibility.Visible;

        public Visibility visibilityDatosTransformados
        {
            get
            {
                return _visibilityDatosTransformados;
            }

            set
            {
                if (_visibilityDatosTransformados == value)
                {
                    return;
                }

                _visibilityDatosTransformados = value;
                RaisePropertyChanged(visibilityDatosTransformadosPropertyName);
            }
        }

        #endregion

        #region visibilityDatosTransformadosBalance

        public const string visibilityDatosTransformadosBalancePropertyName = "visibilityDatosTransformadosBalance";

        private Visibility _visibilityDatosTransformadosBalance = Visibility.Visible;

        public Visibility visibilityDatosTransformadosBalance
        {
            get
            {
                return _visibilityDatosTransformadosBalance;
            }

            set
            {
                if (_visibilityDatosTransformadosBalance == value)
                {
                    return;
                }

                _visibilityDatosTransformadosBalance = value;
                RaisePropertyChanged(visibilityDatosTransformadosBalancePropertyName);
            }
        }

        #endregion

        #region visibilityDatosIniciales

        public const string visibilityDatosInicialesPropertyName = "visibilityDatosIniciales";

        private Visibility _visibilityDatosIniciales = Visibility.Visible;

        public Visibility visibilityDatosIniciales
        {
            get
            {
                return _visibilityDatosIniciales;
            }

            set
            {
                if (_visibilityDatosIniciales == value)
                {
                    return;
                }

                _visibilityDatosIniciales = value;
                RaisePropertyChanged(visibilityDatosInicialesPropertyName);
            }
        }

        #endregion

        #region visibilidadOpcionesTexto

        public const string visibilidadOpcionesTextoPropertyName = "visibilidadOpcionesTexto";

        private Visibility _visibilidadOpcionesTexto = Visibility.Collapsed;

        public Visibility visibilidadOpcionesTexto
        {
            get
            {
                return _visibilidadOpcionesTexto;
            }

            set
            {
                if (_visibilidadOpcionesTexto == value)
                {
                    return;
                }

                _visibilidadOpcionesTexto = value;
                RaisePropertyChanged(visibilidadOpcionesTextoPropertyName);
            }
        }

        #endregion

        #region visibilidadOpcionesCarga

        public const string visibilidadOpcionesCargaPropertyName = "visibilidadOpcionesCarga";

        private Visibility _visibilidadOpcionesCarga = Visibility.Collapsed;

        public Visibility visibilidadOpcionesCarga
        {
            get
            {
                return _visibilidadOpcionesCarga;
            }

            set
            {
                if (_visibilidadOpcionesCarga == value)
                {
                    return;
                }

                _visibilidadOpcionesCarga = value;
                RaisePropertyChanged(visibilidadOpcionesCargaPropertyName);
            }
        }

        #endregion

        

        #region ViewModel Properties : extensionArchivo
        //Controla la accesibilidad de botones
        public const string extensionArchivoPropertyName = "extensionArchivo";

        private string _extensionArchivo;

        public string extensionArchivo
        {
            get
            {
                return _extensionArchivo;
            }

            set
            {
                if (_extensionArchivo == value)
                {
                    return;
                }

                _extensionArchivo = value;
                RaisePropertyChanged(extensionArchivoPropertyName);
            }
        }

        #endregion


        #endregion

        #endregion

        private int _FocoPestañaSeleccionada;
        public int FocoPestañaSeleccionada
        {
            get { return _FocoPestañaSeleccionada; }
            set
            {
                _FocoPestañaSeleccionada = value;
                RaisePropertyChanged("FocoPestañaSeleccionada");
                //Activar o anular vistas
                try
                {
                    switch (_FocoPestañaSeleccionada)
                    {
                        case 0:
                            visibilidadOpcionesCarga = Visibility.Collapsed;
                            visibilidadOpcionesTexto = Visibility.Collapsed;
                            visibilityDatosTransformados = Visibility.Collapsed;
                            visibilityDatosTransformadosBalance = Visibility.Collapsed;
                            visibilityDatosCaptura = Visibility.Collapsed;
                            visibilityDatosIniciales = Visibility.Collapsed;
                            if (tipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
                            {
                                visibilidadOpcionesBalance = Visibility.Collapsed;//03-05-2017 Belr se muestran las opciones del balance
                            }
                            else
                            {
                                if (tipoArchivoACargar == TipoArchivoCargar.Balance)
                                {
                                    visibilidadOpcionesBalance = Visibility.Visible;//03-05-2017 Belr se muestran las opciones del balance
                                }
                            }
                            break;
                        case 1:
                            visibilidadOpcionesCarga = Visibility.Collapsed;
                            visibilidadOpcionesTexto = Visibility.Collapsed;
                            visibilidadOpcionesBalance = Visibility.Collapsed;
                            visibilityDatosTransformados = Visibility.Collapsed;
                            visibilityDatosCaptura = Visibility.Visible;
                            visibilityDatosIniciales = Visibility.Visible;
                            break;
                        case 2:
                            visibilidadOpcionesCarga = Visibility.Collapsed;
                            visibilidadOpcionesTexto = Visibility.Collapsed;
                            visibilidadOpcionesBalance = Visibility.Collapsed;
                            visibilityDatosTransformados = Visibility.Collapsed;
                            visibilityDatosTransformadosBalance = Visibility.Collapsed;
                            visibilityDatosCaptura = Visibility.Visible;
                            visibilityDatosIniciales = Visibility.Visible;
                            break;
                        case 3:
                            visibilidadOpcionesCarga = Visibility.Collapsed;
                            visibilidadOpcionesTexto = Visibility.Collapsed;
                            visibilidadOpcionesBalance = Visibility.Collapsed;
                            visibilityDatosTransformados = Visibility.Visible;
                            visibilityDatosTransformadosBalance = Visibility.Collapsed;
                            visibilityDatosCaptura = Visibility.Collapsed;
                            visibilityDatosIniciales = Visibility.Collapsed;
                            break;
                        case 4:
                            visibilidadOpcionesCarga = Visibility.Collapsed;
                            visibilidadOpcionesTexto = Visibility.Collapsed;
                            visibilidadOpcionesBalance = Visibility.Collapsed;
                            visibilityDatosTransformados = Visibility.Visible;
                            visibilityDatosCaptura = Visibility.Visible;
                            visibilityDatosTransformadosBalance = Visibility.Collapsed;
                            visibilityDatosIniciales = Visibility.Collapsed;
                            break;
                        default:
                            visibilidadOpcionesCarga = Visibility.Collapsed;
                            visibilidadOpcionesTexto = Visibility.Collapsed;
                            visibilidadOpcionesBalance = Visibility.Collapsed;
                            visibilityDatosCaptura = Visibility.Visible;
                            visibilityDatosIniciales = Visibility.Visible;
                            visibilityDatosTransformados = Visibility.Collapsed;
                            visibilityDatosTransformadosBalance = Visibility.Collapsed;
                            break;
                    }
                }
                catch (Exception)
                {
                    visibilidadOpcionesCarga = Visibility.Collapsed;
                    visibilidadOpcionesTexto = Visibility.Collapsed;
                    visibilityDatosCaptura = Visibility.Visible;
                    visibilityDatosIniciales = Visibility.Visible;
                    visibilityDatosTransformados = Visibility.Collapsed;
                    visibilityDatosTransformadosBalance = Visibility.Collapsed;
                    if (tipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
                    {
                        visibilidadOpcionesBalance = Visibility.Collapsed;//03-05-2017 Belr se muestran las opciones del balance
                    }
                    else
                    {
                        if (tipoArchivoACargar == TipoArchivoCargar.Balance)
                        {
                            visibilidadOpcionesBalance = Visibility.Visible;//03-05-2017 Belr se muestran las opciones del balance
                        }
                    }
                }
            }
        }

        private bool _DatosConEncabezados;
        public bool DatosConEncabezados
        {
            get { return _DatosConEncabezados; }
            set { _DatosConEncabezados = value; RaisePropertyChanged("DatosConEncabezados"); }
        }

        private int _ComienzoFilaImportar;
        public int ComienzoFilaImportar
        {
            get { return _ComienzoFilaImportar; }
            set { _ComienzoFilaImportar = value; RaisePropertyChanged("ComienzoFilaImportar"); }
        }

        //readonly ObservableCollection<CompanyItem> companies;
        public ImportarArchivosGeneralesViewModel()
        {
            Messenger.Default.Register<CargarArchivosMensajeModal>(this, "ImportarArchivos", (recepcionOrdenImportacion) => this.IniciarProcesoDeImportacion(recepcionOrdenImportacion));
            //Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            dlg = new DialogCoordinator();
            
            HabilitarcmbClaseBalance = false;
            HabilitarcmbPeriodosBalance = false;
            Message = ""; //texto del tab3
            DatosConEncabezados = true; //checbox
            ComienzoFilaImportar = 1; //spinner
            lista = new ObservableCollection<CatalogoCuentasModelo>();
            this.inicializadoresBasicos();
            HayCatalogoGeneradoAPartirBalance = false;
            _fuenteCierre = 0;
            _resultadoProceso = 0;


            #region 
            //03-05-2017 Belr
            _accesibilidadWindow = false;
            _accesibilidadBotones = false;
            _HabilitartxtNombreCatalogo = false;
            _visibilidadMsjProceso = Visibility.Collapsed;
            _visibilidadOpcionesBalance = Visibility.Collapsed;
            _visibilityHoja = Visibility.Collapsed;
            _visibilityDatosCaptura = Visibility.Collapsed;
            _visibilityDatosIniciales = Visibility.Collapsed;
            _visibilityDatosTransformados = Visibility.Collapsed;
            _visibilityDatosTransformadosBalance = Visibility.Collapsed;
            _visibilidadOpcionesTexto = Visibility.Collapsed;
            _visibilidadOpcionesCarga = Visibility.Collapsed;
            _FocoPestañaSeleccionada = 0;
            _tipoArchivoACargar = TipoArchivoCargar.Ninguno;//Inicializando la variable
            _extensionArchivo = string.Empty;
            _listaCatalogoImportar = new ObservableCollection<CatalogoCuentasModelo>();
            RegisterCommands();
            #endregion
        }

        private async void IniciarProcesoDeImportacion(CargarArchivosMensajeModal msj) //aqui cae el mensaje del solicitante
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            tokenAUsar = msj.TokenAUtilizar;
            MensajeModalRecibido = msj;
            //actualizarLista(); //no aplica, pq no tenemos aun el catalogo que tiene que ser importado

            //inicializacionTerminada();
            Messenger.Default.Unregister<CargarArchivosMensajeModal>(this, "ImportarArchivos");

            Message = "Se esta importando: " + msj.TipoArchivoACargar;
            tipoArchivoACargar = msj.TipoArchivoACargar;//03/05/2017 para  almacenar  el tipo de archivo cargado
            if (msj.TipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
            {
                HabilitarcmbClaseBalance = false;
                HabilitarcmbPeriodosBalance = false;
                HabilitardpickFechaBalance=false;
            }
                

            if (msj.TipoArchivoACargar == TipoArchivoCargar.Balance)
            {
                HabilitarcmbClaseBalance = true;
                HabilitarcmbPeriodosBalance = true;
                await AvisaYCerrateVosSolo("Para cargar el Balance", "Seleccione el tipo de Balance", 3);//03-05-2017 Berl Modificado  el mensaje
                HabilitardpickFechaBalance=true;
                string fechabalance="31/12/"+DateTime.Now.Year.ToString();
                FechaBalance=DateTime.Parse(fechabalance);
                visibilidadOpcionesBalance = Visibility.Visible;//03-05-2017 Belr se muestran las opciones del balance
            }
                
           
            accesibilidadWindow = true;//03-05-2017 Belr
            accesibilidadBotones = true;
            visibilidadOpcionesCarga = Visibility.Collapsed;
            finComando();
        }

        private void inicializadoresBasicos()
        {
            using(db=new SGPTEntidades())
	        {
	        	ListadoClaseBalance=db.clasesbalances.Where(x=>x.estadocb=="A").ToList();
                ListaPeriodoBalance = db.periodos.Where(y=>y.estadoperiodos=="A").ToList(); 
	        }
            listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());
        }

        private string _HojaCalculoUsada;
        public string HojaCalculoUsada
        {
            get { return _HojaCalculoUsada; }
            set { _HojaCalculoUsada = value;
                RaisePropertyChanged("HojaCalculoUsada");
                if (!string.IsNullOrEmpty(_HojaCalculoUsada))
                {
                    visibilityHoja = Visibility.Visible;
                }
                else
                {
                    visibilityHoja = Visibility.Collapsed;
                }
            }
        }

        private string _TipoBalanceTextBlock;
        public string TipoBalanceTextBlock
        {
            get { return _TipoBalanceTextBlock; }
            set { _TipoBalanceTextBlock = value; RaisePropertyChanged("TipoBalanceTextBlock"); }
        }

        private bool _habilitarcmbClaseBalance;
        public bool HabilitarcmbClaseBalance
        {
            get { return _habilitarcmbClaseBalance; }
            set { _habilitarcmbClaseBalance = value; RaisePropertyChanged("HabilitarcmbClaseBalance"); }
        }

        private bool _HabilitarcmbPeriodosBalance;
        public bool HabilitarcmbPeriodosBalance
        {
            get { return _HabilitarcmbPeriodosBalance; }
            set { _HabilitarcmbPeriodosBalance = value; RaisePropertyChanged("HabilitarcmbPeriodosBalance"); }
        }
       
        private ClaseCuentaModelo _SelectedClaseCuentaM;
        public ClaseCuentaModelo SelectedClaseCuentaM
        {
            get { return _SelectedClaseCuentaM; }
            set { _SelectedClaseCuentaM = value; RaisePropertyChanged("SelectedClaseCuentaM"); this.cambio(); }
        }

        private DateTime _fechaBalance;
        public DateTime FechaBalance { get { return _fechaBalance; } set { _fechaBalance = value; RaisePropertyChanged("FechaBalance"); } }

        private Boolean _HabilitardpickFechaCVPA;
        public Boolean HabilitardpickFechaBalance
        {
            get
            {
                return _HabilitardpickFechaCVPA;
            }
            set
            {
                _HabilitardpickFechaCVPA = value;
                RaisePropertyChanged("HabilitardpickFechaBalance");
            }
        }

        private async void cambio()
        {
            await AvisaYCerrateVosSolo("Cambio", "", 1);
        }

        public async void ProcesarDatos()
        {
            iniciarComando();

            if (dtGrd != null)
            {
                
                if (await this.SinCodigosContablesRepetidos())
                {
                    #region +
                    try
                    {
                        #region +
                        if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
                        {
                            bool reconocimientoCatalogoCorrecto = await this.ReconocerCatalogoCuentas();
                        }
                        else if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.Balance)
                        {
                            bool yaTieneCatalogo = false;
                            //Verificar que el encargo ya haya registrado un catalogo de cuentas, sino le propondremos crearlo a partir del balance.
                            catalogocuenta existeCatalogoParaEsteSistemaContable = new catalogocuenta();
                            using (db = new SGPTEntidades())
                            {
                                try
                                {
                                    existeCatalogoParaEsteSistemaContable = (from c in db.catalogocuentas where c.idsc == currentSistemaContable.idsc select c).First();
                                }
                                catch (Exception)
                                {
                                    existeCatalogoParaEsteSistemaContable = new catalogocuenta();
                                }
                            }
                            if (existeCatalogoParaEsteSistemaContable.idcc > 0 && lista != null)
                            {
                                yaTieneCatalogo = true;
                            }
                            if (yaTieneCatalogo)
                            {
                                this.ReconocerBalance();
                            }
                            else
                            {
                                var mySettingsk = new MetroDialogSettings()
                                {
                                    AffirmativeButtonText = "Acepto",
                                    NegativeButtonText = "Cancelar",

                                };
                                finComando();
                                MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "No tiene registrado el catalogo de cuentas para este encargo." + Environment.NewLine + "El sistema intentara generar uno a partir del balance ingresado" + Environment.NewLine + "Cliente: " + currentEncargo.razonsocialcliente + Environment.NewLine + "Encargo seleccionado: " + currentEncargo.descripcionTipoAuditoria + " " + currentEncargo.fechainiperauditencargo + "-" + currentEncargo.fechafinperauditencargo + Environment.NewLine, "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                                if (resultk == MessageDialogResult.Affirmative)
                                {
                                    iniciarComando();
                                    bool reconocimientoCorrecto = await this.ReconocerCatalogoCuentas();
                                    if (reconocimientoCorrecto)
                                    {
                                        HayCatalogoGeneradoAPartirBalance = true;
                                        finComando();
                                        await AvisaYCerrateVosSolo("Guarde el catalogo generado. Y despues guarde el Balance", "", 1);
                                    }
                                }

                            }
                        }
                        #endregion
                        finComando();
                        FocoPestañaSeleccionada=4;
                        //Avanza al siguiente  paso
                    }
                    catch (Exception e)
                    {
                        finComando();
                        MessageBox.Show("Error en el reconocimiento del archivo importado. \n" + e);

                    } 
                    #endregion 
                }
            }
            else
            {
                finComando();
                await AvisaYCerrateVosSolo("No ha iniciado la importacion de ningun archivo...", "Importacion no iniciada.", 1);
            }
        }

        public async Task<bool> SinCodigosContablesRepetidos()
        {
            await AvisaYCerrateVosSolo("Buscando codigos contables repetidos...","",2);
             for (int j = 1; j < dtGrd.Count; j++)
            {
                int encont = 0;
                 string codcont1=(dtGrd[j].Row.ItemArray[0].ToString()).Trim();
                for (int k = 1; k < dtGrd.Count; k++)
                {
                    if ((dtGrd[k].Row.ItemArray[0].ToString()).Trim() == codcont1)
                        encont++;
                }
                if (encont > 1)
                {
                    await dlg.ShowMessageAsync(this,"El codigo contable " + codcont1 + "Esta duplicado." + Environment.NewLine , "Revise los datos corrija el codigo");
                        FocoPestañaSeleccionada=0;
                    return false;
                }
             }
            
            return true;
        }

        public async void ReconocerBalance()
        {
            //bool puedeContinuar = false;
            bool error = false;
            try
            {
                #region +
                int h = 0;
                List<catalogocuenta> listaCatalogoGuardado = new List<catalogocuenta>();
                using (db = new SGPTEntidades())
                {
                    listaCatalogoGuardado = db.catalogocuentas.Where(z => z.idsc == currentSistemaContable.idsc).ToList();
                }

                ListaDetalleBalance = new List<DetalleBalanceModelo>();
                foreach (DataRowView dr in dtGrd)
                {
                    #region +
                    h++;
                    Message = "Espere... reconociendo las cuentas del balance una a una. " + h;
                    await Task.Delay(1);
                    //if (h == 219)
                    //    Message = "Espere";
                    DetalleBalanceModelo dl = new DetalleBalanceModelo();
                    dl.idCorrelativo = h;


                    var unf = (dr.Row.ItemArray[0].ToString()).Trim();
                    if (!string.IsNullOrEmpty(unf))
                    {
                        dl.codigoccdb = (dr.Row.ItemArray[0].ToString()).Trim();
                        var pl = listaCatalogoGuardado.Where(x => x.codigocc.Trim() == dl.codigoccdb).SingleOrDefault();
                        dl.idcc = pl.idcc;
                        dl.orden = pl.ordencc;
                        dl.idbalance = currentSistemaContable.idsc;
                        dl.estadodb = "A";

                    }
                    var dof = (dr.Row.ItemArray[1].ToString()).Trim();
                    if (!string.IsNullOrEmpty(dof))
                        dl.nombreCuenta = (dr.Row.ItemArray[1].ToString()).Trim();
                    var tref = (dr.Row.ItemArray[2].ToString()).Trim();
                    if (!string.IsNullOrEmpty(tref))
                        dl.saldoanteriordb = decimal.Parse((dr.Row.ItemArray[2].ToString()).Trim());

                    var cuaf = (dr.Row.ItemArray[3].ToString()).Trim();
                    if (!string.IsNullOrEmpty(cuaf))
                        dl.cargodb = decimal.Parse((dr.Row.ItemArray[3].ToString()).Trim());

                    var cinf = (dr.Row.ItemArray[4].ToString()).Trim();
                    if (!string.IsNullOrEmpty(cinf))
                        dl.abonodb = decimal.Parse((dr.Row.ItemArray[4].ToString()).Trim());
                    var seif = (dr.Row.ItemArray[5].ToString()).Trim();
                    if (!string.IsNullOrEmpty(seif))
                        dl.saldofinaldb = decimal.Parse((dr.Row.ItemArray[5].ToString()).Trim());

                    ListaDetalleBalance.Add(dl);
                    //RaisePropertyChanged("ListaDetalleBalance");
                    //await Task.Delay(1); 

                    #endregion
                }
                RaisePropertyChanged("ListaDetalleBalance");
                if (ListaDetalleBalance.Count > 0)
                {
                    visibilityDatosTransformadosBalance = Visibility.Visible;
                    visibilityDatosTransformados = Visibility.Collapsed;
                    visibilityDatosCaptura = Visibility.Visible;
                    visibilityDatosIniciales = Visibility.Collapsed;
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el reconocimiento del balance. El código de las cuentas no coincide con el guardado \n" + e);
                error= true;
            }
            finally
            {
                if (error)
                {
                    Reprocesar();
                }
            }
        }
        public async Task<bool> ReconocerCatalogoCuentas()
        {
            #region +
            lista = new ObservableCollection<CatalogoCuentasModelo>();
            var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentSistemaContable.idsc));
            var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

            var listaElementos2 = listaElementos.ToList();
            var listaClaseCuenta2 = listaClaseCuenta.ToList();

            //Nota: los elementos solo tienen un digito: asi: Activo = 1; Pasivo=2...
            //Se desea saber cual es el separador de los codigos de las cuentas.
            
            await AvisaYCerrateVosSolo("Iniciando el reconocimiento de los separadores de los codigos de cuentas...", "", 1);
            bool puedeContinuar = true;
            string separador = "";
            int tamañomaximo = 0;
            int tamañominimo = 1000000000;

            int digitosElementos = 1;
            int digitosRubros = currentSistemaContable.digitosrubroscontablessc;
            int digitosCuentas = currentSistemaContable.digitoscuentamayorsc;
            int digitosSubCuenta = 0;
            int digitosSubSubCuenta = 0;
            int digitosSubSubSubCuenta = 0;
            for (int j = 1; j < dtGrd.Count; j++)
            {

                #region +
                string kl = dtGrd[j].Row.ItemArray[0].ToString(); //fila arbitraria.

                if (!string.IsNullOrEmpty(kl)) 
                {
                    if (!kl.All(char.IsDigit)) //preguntamos si no son todos digitos
                    {
                        #region +
                        if (!kl.Any(char.IsLetter)) //pregunto si algun codigo de cuenta posee letras.
                        {
                            #region +
                            for (int i = 1; i < kl.Count(); i++)
                            {
                                #region +
                                if (!kl.Substring(i, 1).All(char.IsDigit)) //si no es digito
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(separador))
                                    {
                                        #region +
                                        if (separador != (kl.Substring(i, 1)))
                                        {
                                            await AvisaYCerrateVosSolo("Se ha encontrado mas de un separador en el codigo contable. El catalogo esta corrupto", 
                                                "Repare las incongruencias y vuelva a intentarlo", 1);
                                            //Abandonar.
                                            puedeContinuar = false;
                                        }
                                        #endregion
                                    }
                                    else
                                        separador = (kl.Substring(i, 1));
                                    #endregion
                                } //fin del if
                                if (!string.IsNullOrEmpty(separador))
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                                    {
                                        string[] tam = kl.Split(char.Parse(separador.Trim()));
                                        if (tam.Length > tamañomaximo)
                                            tamañomaximo = tam.Length;
                                        if (tam.Length < tamañominimo)
                                            tamañominimo = tam.Length;
                                    }
                                    #endregion
                                }
                                #endregion
                            } // fin del for 
                            #endregion
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("Se han encontrado incongruencias en los codigos de las cuentas.", 
                                "Asegurese de haber eliminado los encabezados extras en el Paso 1", 4);
                            puedeContinuar = false;
                        }
                        #endregion
                    } //fin del if  
                    else //todos son digitos y no hay separadores
                    {
                        //if(j==219)
                        //{
                        //    var a = ""; 
                        //}
                        #region +
                        for (int i = 1; i < kl.Count(); i++)
                        {
                            int tamKl = kl.Trim().Length;
                            if (tamKl > tamañomaximo)
                                tamañomaximo = tamKl;
                            if (tamKl < tamañominimo)
                                tamañominimo = tamKl;

                            //Quiero indagar cuantos digitos tiene las 3 subcuentas si es que las hay!!
                            if (tamKl > digitosCuentas && digitosSubCuenta == 0)
                            {
                                digitosSubCuenta = tamKl;
                            }
                            if (tamKl > digitosCuentas && tamKl > digitosSubCuenta && digitosSubSubCuenta == 0)
                            {
                                digitosSubSubCuenta = tamKl;
                            }
                            if (tamKl > digitosCuentas && tamKl > digitosSubCuenta && tamKl > digitosSubSubCuenta && digitosSubSubSubCuenta == 0)
                            {
                                digitosSubSubSubCuenta = tamKl;
                            }
                        } // fin del for 
                        #endregion
                    }
                }
                else
                {
                    //DataRow dr = dtGrd[j].Row;
                    dtGrd.Delete(j);
                }
                #endregion
            } // fin del for
           

            if (puedeContinuar) //se desactiva cuando en los codigos de las cuentas se encuentran mas de un separador de numeros
            {
                #region +
                if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                { await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4); }
                else { await AvisaYCerrateVosSolo("Los codigos de las cuentas contables seran separados" + Environment.NewLine 
                    + "Segun la configuracion de digitos en el sistema contable.", "La separacion quedara asi:" 
                    + Environment.NewLine + "Elementos [1], Rubros [" + digitosRubros + "], Cuentas [" + digitosCuentas + "]," 
                    + Environment.NewLine + "Sub-Cuentas [" + digitosSubCuenta + "], Sub-sub-cuentas [" + digitosSubSubCuenta + "], Sub-sub-sub-cuentas [" + digitosSubSubSubCuenta + "]" 
                    + Environment.NewLine + "El exceso sera ignorado.", 5); }

                //lista = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllImportacion(currentEncargo.idencargo));
                //currentSistemaContable.
                int? idimaginario = 0;
                //var cuantosRegistrosHayEnLaBase;
                try
                {
                    using (db = new SGPTEntidades())
                    {
                        idimaginario = db.catalogocuentas.Max(t => t.idcc);
                        if (idimaginario < 0 || idimaginario == null)
                            idimaginario = 0;

                        string fd = "ALTER SEQUENCE sgpt.catalogocuentas_idcc_seq RESTART WITH " + (idimaginario + 1) + ";";
                        var reiniciarIdPorDefectoDePostgreSql = db.Database.ExecuteSqlCommand(fd);
                        db.SaveChanges();
                        //}
                        //idimaginario++; //le sumo uno, pq la cochinada del restart lo pone en un valor y postgres le suma 1 no se por que.
                    }
                }
                catch
                {
                    //Hay un error en la consulta sobre  el valor máximo
                    ObservableCollection<catalogocuenta> listaTemporal = CatalogoCuentasModelo.GetAllCapaDatos();
                    if (listaTemporal.Count > 0)
                    {

                        idimaginario = listaTemporal.Max(x => x.idcc);
                    }
                    else
                    {
                        //Lista vacia
                        idimaginario = 0;
                    }
                    if (idimaginario < 0 || idimaginario == null)
                        idimaginario = 0;
                    using (db = new SGPTEntidades())
                    {
                        string fd = "ALTER SEQUENCE sgpt.catalogocuentas_idcc_seq RESTART WITH " + (idimaginario + 1) + ";";
                        var reiniciarIdPorDefectoDePostgreSql = db.Database.ExecuteSqlCommand(fd);
                        db.SaveChanges();
                    }
                }
                //int cuantosRegistrosHayEnLaBase=GetAllCountByIdSc()
                //int idimaginario = cuantosRegistrosHayEnLaBase;
                int idcorrelativo = 0;

                int codpadreelemento = 0;
                int codpadrerubro = 0;
                int codpadrecuenta = 0;
                int codpadresubcuenta = 0;
                int codpadresubsubcuenta = 0;

                string[] col11 = { };
                Message = "Espere... reconociendo las cuentas una a una.";
                await Task.Delay(1);
                
                DataRowView dr ;
                bool notIsProcesable = false;
                for (int i=0;i< dtGrd.Count;i++ )
                { 
                //foreach (DataRowView dr in dtGrd)
                //{
                    dr = dtGrd[i];
                    notIsProcesable = true;
                    if ((dr.Row.ItemArray[0].ToString().Trim().Length > 0))
                    {
                        notIsProcesable = MetodosModelo.IsAlpha(dr.Row.ItemArray[0].ToString().Trim());//Verificando que no  contenga texto
                    }
                    else
                    {
                        notIsProcesable = true;
                    }
                    if (!notIsProcesable )
                    {
                        #region +
                        idcorrelativo++;
                        idimaginario++;
                        decimal drr = dtGrd.Count / 2;
                        if (idcorrelativo == Math.Round(drr))
                        {
                            Message = "Espere... reconociendo las cuentas una a una. Fila: " + idcorrelativo;
                            await Task.Delay(1);
                        }
                        string col1 = (dr.Row.ItemArray[0].ToString()).Trim();
                        string col2 = (dr.Row.ItemArray[1].ToString()).Trim();

                        CatalogoCuentasModelo cat = new CatalogoCuentasModelo();

                        if (!string.IsNullOrEmpty(separador) && separador.Length == 1)//(col11.Count() >= 1 && !string.IsNullOrEmpty(separador))//tienen separadores los codigos de cuenta
                        {
                            #region +
                            if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                            {
                                col11 = col1.Split(char.Parse(separador.Trim()));
                                col11 = col11.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            }

                            if (tamañomaximo > tamañominimo) //si los codigos de las cuentas no tienen el mismo numero de digitos
                            {
                                #region +
                                try
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(col1) && !string.IsNullOrEmpty(col2))
                                    {
                                        #region +
                                        //if (currentSistemaContable.digitoscuentamayorsc != currentSistemaContable.digitosrubroscontablessc + 1)
                                        //await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4);
                                        cat.idcc =(int) idimaginario;
                                        cat.idCorrelativo = idcorrelativo;

                                        int cod = int.Parse(col11[0]);
                                        var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                        ClaseCuentaModelo cla = new ClaseCuentaModelo();


                                        if (col11.Count() == 1) //Elemento
                                        {
                                            cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                            codpadreelemento =(int) idimaginario;
                                        }
                                        else if (col11.Count() == 2)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                        {
                                            cla = listaClaseCuenta2[2];
                                            //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                            cat.catidcc = codpadreelemento;//pad.idcc;
                                            codpadrerubro = (int) idimaginario;
                                        }
                                        else if (col11.Count() == 3)//currentSistemaContable.digitoscuentamayorsc)
                                        {
                                            cla = listaClaseCuenta2[3];
                                            cat.catidcc = codpadrerubro; //idimaginario - 1;
                                            codpadrecuenta = (int) idimaginario;
                                        }
                                        else if (col11.Count() == 4)//currentSistemaContable.digitoscuentamayorsc + 1)
                                        {
                                            cla = listaClaseCuenta2[4];
                                            cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                            codpadresubcuenta = (int) idimaginario;
                                        }
                                        else if (col11.Count() == 5)//currentSistemaContable.digitoscuentamayorsc + 2)
                                        {
                                            cla = listaClaseCuenta2[5];
                                            cat.catidcc = codpadresubcuenta;//idimaginario - 1;
                                            codpadresubsubcuenta = (int) idimaginario;
                                        }
                                        else if (col11.Count() == 6)//currentSistemaContable.digitoscuentamayorsc + 3)
                                        {
                                            cla = listaClaseCuenta2[6];
                                            cat.catidcc = codpadresubsubcuenta;// idimaginario - 1;
                                        }
                                        else
                                        {
                                            cla = listaClaseCuenta2[0];
                                            //cat.catidcc = idimaginario - 1;
                                        }

                                        cat.ClaseCuenta = cla;
                                        cat.nombreClaseCuenta = cla.descripcionccuentas;

                                        cat.listaClaseCuenta = listaClaseCuenta2;
                                        if (elem != null)
                                            cat.idelementos = elem.id;
                                        cat.Elementoss = elem;
                                        cat.nombreElemento = elem.descripcion;
                                        cat.listaElementos = listaElementos2;
                                        cat.idsc = currentSistemaContable.idsc;
                                        cat.idccuentas = 1;
                                        cat.codigocc = col1;
                                        cat.descripcioncc = col2;
                                        #endregion
                                    }
                                    #endregion
                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("Error desconocido al intentar reconocer los codigos de las cuentas", "Verifique que el archivo no este corrupto.");
                                    return false;
                                }
                                #endregion
                            }
                            else //todos los codigos de cuentas tienen el mismo tamaño. ej: 1.0.0.0.0 Activo, 1.1.0.0.0 activo circulante, etc. Osea los elementos, los rubros, las cuentas poseen el mismo numero de digitos.
                            {
                                #region +
                                try
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(col1) && !string.IsNullOrEmpty(col2))
                                    {
                                        #region +
                                        //if (currentSistemaContable.digitoscuentamayorsc != currentSistemaContable.digitosrubroscontablessc + 1)
                                        //await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4);
                                        cat.idcc = (int) idimaginario;
                                        cat.idCorrelativo = idcorrelativo;
                                        cat.ordencc = idcorrelativo;//Cualquier valor se supone que ya  viene ordenado
                                        int cod = int.Parse(col11[0]);
                                        var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                        ClaseCuentaModelo cla = new ClaseCuentaModelo();
                                        int colcount = 0;


                                        try
                                        {
                                            for (int h = 0; h < col11.Count(); h++)//empezamos por la columna 2 ej: 1.[1].0.0.00
                                            {
                                                //h++;
                                                string aj = col11[h];
                                                if (int.Parse(col11[h]) == 0)
                                                {
                                                    if ((h + 1) < col11.Count())
                                                    {
                                                        if (int.Parse(col11[h + 1]) == 0)
                                                        {
                                                            colcount = h;
                                                            h = col11.Count();
                                                            //cantDigitos = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        colcount = h;
                                                        h = col11.Count();
                                                        //cantDigitos = false;
                                                    }
                                                }
                                                else
                                                {
                                                    if ((h + 1) == col11.Count())
                                                    {
                                                        colcount = h + 1;
                                                    }

                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }

                                        //}

                                        if (colcount == 1) //Elemento
                                        {
                                            cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                            codpadreelemento = (int) idimaginario;
                                        }
                                        else if (colcount == 2)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                        {
                                            cla = listaClaseCuenta2[2];
                                            //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                            cat.catidcc = codpadreelemento;//pad.idcc;
                                            codpadrerubro = (int) idimaginario;
                                        }
                                        else if (colcount == 3)//currentSistemaContable.digitoscuentamayorsc)
                                        {
                                            cla = listaClaseCuenta2[3];
                                            cat.catidcc = codpadrerubro; //idimaginario - 1;
                                            codpadrecuenta = (int) idimaginario;
                                        }
                                        else if (colcount == 4)//currentSistemaContable.digitoscuentamayorsc + 1)
                                        {
                                            cla = listaClaseCuenta2[4];
                                            cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                            codpadresubcuenta = (int) idimaginario;
                                        }
                                        else if (colcount == 5)//currentSistemaContable.digitoscuentamayorsc + 2)
                                        {
                                            cla = listaClaseCuenta2[5];
                                            cat.catidcc = codpadresubcuenta;//idimaginario - 1;
                                            codpadresubsubcuenta = (int) idimaginario;
                                        }
                                        else if (colcount == 6)//currentSistemaContable.digitoscuentamayorsc + 3)
                                        {
                                            cla = listaClaseCuenta2[6];
                                            cat.catidcc = codpadresubsubcuenta;// idimaginario - 1;
                                        }
                                        else
                                        {
                                            cla = listaClaseCuenta2[0];

                                            //cat.catidcc = idimaginario - 1;
                                        }


                                        cat.ClaseCuenta = cla;
                                        cat.nombreClaseCuenta = cla.descripcionccuentas;

                                        cat.listaClaseCuenta = listaClaseCuenta2;
                                        if (elem != null)
                                            cat.idelementos = elem.id;
                                        cat.Elementoss = elem;
                                        cat.nombreElemento = elem.descripcion;
                                        cat.listaElementos = listaElementos2;
                                        cat.idsc = currentSistemaContable.idsc;
                                        cat.idccuentas = 1;
                                        cat.codigocc = col1;
                                        cat.descripcioncc = col2;
                                        #endregion
                                    }
                                    #endregion
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Error desconocido al intentar reconocer los codigos de las cuentas", "Verifique que el archivo no este corrupto.");
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else //sin separadores
                        {
                            #region +
                            try
                            {
                                if (!string.IsNullOrEmpty(col1) && !string.IsNullOrEmpty(col2))
                                {
                                    #region +
                                    if (tamañomaximo > tamañominimo)
                                    {
                                        #region +
                                        //if (currentSistemaContable.digitoscuentamayorsc != currentSistemaContable.digitosrubroscontablessc + 1)
                                        //await AvisaYCerrateVosSolo("Los codigos de las cuentas contables seran separados" + Environment.NewLine + "Segun la configuracion de digitos en el sistema contable.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [" + digitosRubros + "], Cuentas [" + digitosCuentas + "]," + Environment.NewLine + "Sub-Cuentas [" + digitosSubCuenta + "], Sub-sub-cuentas [" + digitosSubSubCuenta + "], Sub-sub-sub-cuentas [" + digitosSubSubSubCuenta + "]"+Environment.NewLine+"El exceso sera ignorado.", 5);
                                        cat.idcc = (int) idimaginario;
                                        cat.idCorrelativo = idcorrelativo;

                                        int cod = int.Parse(col1.Substring(0, 1));
                                        var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                        ClaseCuentaModelo cla = new ClaseCuentaModelo();


                                        if (col1.Count() == digitosElementos) //Elemento
                                        {
                                            cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                            codpadreelemento = (int) idimaginario;
                                        }
                                        else if (col1.Count() == digitosRubros)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                        {
                                            cla = listaClaseCuenta2[2];
                                            //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                            cat.catidcc = codpadreelemento;//pad.idcc;
                                            codpadrerubro = (int) idimaginario;
                                        }
                                        else if (col1.Count() == digitosCuentas)//currentSistemaContable.digitoscuentamayorsc)
                                        {
                                            cla = listaClaseCuenta2[3];
                                            cat.catidcc = codpadrerubro; //idimaginario - 1;
                                            codpadrecuenta = (int) idimaginario;
                                        }
                                        else if (col1.Count() == digitosSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 1)
                                        {
                                            cla = listaClaseCuenta2[4];
                                            cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                            codpadresubcuenta = (int) idimaginario;
                                        }
                                        else if (col1.Count() == digitosSubSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 2)
                                        {
                                            cla = listaClaseCuenta2[5];
                                            cat.catidcc = codpadresubcuenta;
                                            codpadresubsubcuenta = (int) idimaginario;
                                        }
                                        else if (col1.Count() == digitosSubSubSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 3)
                                        {
                                            cla = listaClaseCuenta2[6];
                                            cat.catidcc = codpadresubsubcuenta;
                                        }
                                        else
                                        {
                                            cla = listaClaseCuenta2[0];
                                            //cat.catidcc = idimaginario - 1;
                                        }


                                        cat.ClaseCuenta = cla;
                                        cat.nombreClaseCuenta = cla.descripcionccuentas;

                                        cat.listaClaseCuenta = listaClaseCuenta2;
                                        if (elem != null)
                                            cat.idelementos = elem.id;
                                        cat.Elementoss = elem;
                                        cat.nombreElemento = elem.descripcion;
                                        cat.listaElementos = listaElementos2;
                                        cat.idsc = currentSistemaContable.idsc;
                                        cat.idccuentas = 1;
                                        cat.codigocc = col1;
                                        cat.descripcioncc = col2;
                                        #endregion
                                    }
                                    else
                                    {
                                        await AvisaYCerrateVosSolo("Los codigos de las cuentas no fueron soportados en esta version 1.0 ", "Sugerencia: Realice puntuaciones para dividir los elementos y rubros de las cuentas", 4);
                                        return false;
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error desconocido al intentar reconocer los codigos de las cuentas", "Verifique que el archivo no este corrupto.");
                                return false;
                            }
                            #endregion
                        }

                        lista.Add(cat);
                        RaisePropertyChanged("lista");
                        #endregion
                    }
                    else
                    {
                        Message = "La Fila: " + i + "no sera importada";
                        await Task.Delay(1);
                    }
                //}
                }
               
                RaisePropertyChanged("lista");
                if (lista.Count() > 0)
                {
                    Message = "Ordenando las cuentas de forma ascendente... Espere...";
                    await Task.Delay(1);
                    //04-05-2015
                    //Correcciones a la lista
                    //Se requiere listado de elementos (para identificarlos)
                    ObservableCollection<elemento> elementos = new ObservableCollection<elemento>(ElementoModelo.GetBySistemaContableAllCapaDatos(currentSistemaContable.idsc));
                    ObservableCollection<clasecuenta> clasecuentas = new ObservableCollection<clasecuenta>(ClaseCuentaModelo.GetAllCapaDatos());
                    //Identificar los elementos
                    clasecuenta claseCuentaRegistro = new clasecuenta();
                    clasecuenta claseCuentaAnterior = new clasecuenta();
                    elemento tipoElemento = new elemento();
                    int localizacionCuenta = 0;
                    int largoSubcuenta = 0;
                    int limiteSuperior = 0;
                    for (int k=0;k<= clasecuentas.Count();k++)
                    {
                        #region clasificacion cuentas
                        try
                        {
                            //Inicializo el registro
                            claseCuentaRegistro = new clasecuenta();
                            if (k == 0)
                            {
                                //Inicio se busca el primer elemento 
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == null);
                            }
                            else
                            {
                                //Con base al padre se busca al hijo
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == claseCuentaAnterior.idccuentas);
                            }
                            //Guardando elemento procesado
                            if (claseCuentaRegistro != null)
                            {
                                claseCuentaAnterior = claseCuentaRegistro;
                            }
                            //Procesando el elemento
                            if (claseCuentaRegistro!=null || claseCuentaRegistro.idccuentas!=0)
                            {
                                #region Clasificacion de cuentas

                                if (claseCuentaRegistro.padreidccuentas == null)
                                {
                                    #region proceso para establecer el id elementos, tipo de saldos (preliminar) 
                                    //Busqueda de Elementos     
                                    foreach (elemento item in elementos)
                                    {
                                        localizacionCuenta = (int)lista.SingleOrDefault(x => x.idsc == currentSistemaContable.idsc &&
                                                                    x.codigocc == item.codigoelemento.ToString()).idelementos;
                                        if (localizacionCuenta != 0)
                                        {
                                            //Se localizo el  elemento
                                            lista[localizacionCuenta].idelementos = item.idelementos;
                                            lista[localizacionCuenta].idccuentas = claseCuentaRegistro.idccuentas;
                                            lista[localizacionCuenta].catidcc = null;//No tiene registro del que dependa es un elemento
                                            lista[localizacionCuenta].tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByIdElemento(item);
                                        }
                                    }

                                    #endregion fin de clasificacion preliminar
                                }
                                else
                                {
                                    #region clasificacion de  rubos y cuentas
                                    if (k == 1)//Rubros
                                    {
                                        //Clasificacion de rubros
                                        foreach (CatalogoCuentasModelo cuenta in lista)
                                        {
                                            if (cuenta.codigocc.Length == currentSistemaContable.digitosrubroscontablessc)
                                            {
                                                cuenta.idccuentas = claseCuentaRegistro.idccuentas; 
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (k == 2)//Cuentas
                                        {
                                            //Clasificacion de rubros
                                            foreach (CatalogoCuentasModelo cuenta in lista)
                                            {
                                                if (cuenta.codigocc.Length == currentSistemaContable.digitoscuentamayorsc)
                                                {
                                                    cuenta.idccuentas = claseCuentaRegistro.idccuentas;
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                #endregion fin de clasificacion de cuentas

                                #region clasificacion de sub-cuentas.
                                if(k>=3)
                                {
                                    if (limiteSuperior == 0)
                                    {
                                        limiteSuperior = currentSistemaContable.digitoscuentamayorsc;
                                    }
                                    else
                                    {
                                        limiteSuperior = largoSubcuenta;
                                    }
                                    //Se reinicializa la  variable
                                    largoSubcuenta =1000;//Solo para establecer un punto inicial
                                    foreach (CatalogoCuentasModelo cuenta in lista)
                                    {
                                        if (cuenta.codigocc.Length > limiteSuperior)
                                        {
                                            if (largoSubcuenta > cuenta.codigocc.Length)
                                            {
                                                largoSubcuenta = cuenta.codigocc.Length;
                                            }
                                        }
                                    }
                                    if (largoSubcuenta != 1000)
                                    {
                                        //Se conoce el nuevo elemento de clasificacion
                                        //Clasificacion de rubros
                                        foreach (CatalogoCuentasModelo cuenta in lista)
                                        {
                                            if (cuenta.codigocc.Length == largoSubcuenta)
                                            {
                                                cuenta.idccuentas = claseCuentaRegistro.idccuentas;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Se termino la busqueda
                                        k = clasecuentas.Count();
                                    }
                                }
                                #endregion
                            }

                        }
                        catch (Exception)
                        {
                            //Error el proceso
                        }
                        #endregion Fin de  clasificacion
                    }

                    ObservableCollection<CatalogoCuentasModelo> listaPadres = new ObservableCollection<CatalogoCuentasModelo>();
                    ObservableCollection<CatalogoCuentasModelo> listaHijos = new ObservableCollection<CatalogoCuentasModelo>();

                    //Longitud de rubro, cuenta, sub-cuenta
                    //Listado de clase de cuenta
                    claseCuentaAnterior = new clasecuenta();
                    claseCuentaAnterior = new clasecuenta();
                    int limite =(int) lista.Max(x=>x.idccuentas);
                    for (int k = 0; k <= limite-1; k++) //Es -1 porque el ultimo nivel no tiene dependencias
                    {
                        #region clasificacion cuentas
                        try
                        {
                            //Inicializo el registro
                            claseCuentaRegistro = new clasecuenta();
                            if (k == 0)
                            {
                                //Inicio se busca el primer elemento 
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == null);
                            }
                            else
                            {
                                //Con base al padre se busca al hijo
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == claseCuentaAnterior.idccuentas);
                            }
                            if (claseCuentaRegistro != null)
                            {
                                claseCuentaAnterior = claseCuentaRegistro;
                            }
                            listaPadres = new ObservableCollection<CatalogoCuentasModelo>(lista.Where(x => x.idccuentas == claseCuentaRegistro.idccuentas).ToList());
                            if (listaPadres.Count > 0)
                            {
                                foreach (CatalogoCuentasModelo padre in listaPadres)
                                { 
                                //Asignar los hijos
                                foreach (CatalogoCuentasModelo cuenta in lista)
                                {
                                    if (cuenta.codigocc.StartsWith(padre.codigocc) && cuenta.idccuentas== claseCuentaRegistro.idccuentas+1)
                                    {
                                        cuenta.catidcc=padre.idcc;
                                    }
                                }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error en  la reclasificación" + e);
                        }
                        #endregion clasificacion de padres
                    }
                    //var lixta = await this.OrdenarImportacion(lista.ToList());
                    //**Correccion de  saldos
                    #region correccion  de  saldos

                        string tiposaldo = string.Empty;
                        ObservableCollection<elemento> elementoContable = new ObservableCollection<elemento>(ElementoModelo.GetBySistemaContableAllCapaDatos(currentSistemaContable.idsc));
                        //int m = 1;
                        foreach (elemento item in elementoContable)
                        {
                            tiposaldo = TipoSaldoCuentaModelo.claseSaldoByIdElemento(item);
                            foreach (CatalogoCuentasModelo cuenta in lista)
                            {
                                if (cuenta.Elementoss.id == item.idelementos || cuenta.codigocc.StartsWith(item.codigoelemento.ToString()))
                                {
                                    cuenta.tiposaldocc = tiposaldo;
                                    //Message = "Corrigiendo: -**- "+m+" del total " + cuenta.descripcioncc + " tipo saldo " + cuenta.tiposaldocc;
                                    //await Task.Delay(1);
                                }
                                //m++;
                            }
                        }

                    #endregion

                    #region correccion de  saldos
                            #region correccion estimada de  saldos
                            foreach (CatalogoCuentasModelo cuenta in lista)
                            {
                                    if (cuenta.tiposaldocc == "D" && cuenta.idccuentas >= 4)
                                    {
                                        //Depreciaciones
                                        if ((cuenta.descripcioncc.Contains("DEPRECIA")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("DEPR")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }                                        //Amortizacion
                                        if ((cuenta.descripcioncc.Contains("DEP.")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }

                                        if ((cuenta.descripcioncc.Contains("AMORTIZ")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        //Amortizacion
                                        if ((cuenta.descripcioncc.Contains("ESTIMAC")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        //Amortizacion
                                        if ((cuenta.descripcioncc.Contains("RESERVA")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("DESVALORIZA")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("PROVISI")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("INCOBRABLE")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("DETERIORO")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("(CR)")))//Indica crédito
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                        if ((cuenta.descripcioncc.Contains("AGOTAMIENTO")))//Indica crédito
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                                        }
                                    }
                                    if (cuenta.tiposaldocc == "A" && cuenta.idccuentas >= 3)
                                    {
                                        //Depreciaciones
                                        if ((cuenta.descripcioncc.Contains("PERDIDA")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                                        }
                                        //Amortizacion
                                        if ((cuenta.descripcioncc.Contains("PERDIDAS")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                                        }
                                        if ((cuenta.descripcioncc.Contains("PÉRDIDA")))
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                                        }
                                        if ((cuenta.descripcioncc.Contains("(DR)")))//Indica saldo deudor
                                        {
                                            cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                                        }
                                    }

                    }
                    #endregion
                    #endregion

                    listaCatalogoImportar = CatalogoCuentasModelo.OrdenarImportacion(lista);

                    if (listaCatalogoImportar.Count > 0)
                    {
                        visibilityDatosTransformadosBalance = Visibility.Collapsed;
                        visibilityDatosTransformados = Visibility.Visible;
                        visibilityDatosCaptura = Visibility.Visible;
                        visibilityDatosIniciales = Visibility.Collapsed;
                    }
                    Message = "Finalizado éxitosamente. Guarde la importacion antes de salir.";
                    await Task.Delay(1);
                   
                    return true;
                }
                else
                {
                    Message = "Lista vacia... accion no permitida.";
                    await Task.Delay(1);
                    return false;
                }
                //await dlg.ShowMessageAsync(this, "Atencion. Haga doble click en las columnas: [Rango | Tipo de elemento | Tipo de Saldo] para ajustar alguna cuenta que este erronea por el reconocimiento automatico.", "Revise detenidamente los saldos Deudor/Acreedor de cada cuenta antes de guardar.");
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("No fue posible continuar. Existen cuentas que no estan  en  el catalogo.", "Ejecute incorporación de cuentas.", 2);
                Reprocesar();
                return false;
            }
            #endregion 
        }


        #region reprocesado

        public async Task<ObservableCollection<CatalogoCuentasModelo>> ReprocesarCatalogoCuentas()
        {
            #region +
            ObservableCollection<CatalogoCuentasModelo> lista = new ObservableCollection<CatalogoCuentasModelo>();
            var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentSistemaContable.idsc));
            var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

            var listaElementos2 = listaElementos.ToList();
            var listaClaseCuenta2 = listaClaseCuenta.ToList();

            //Nota: los elementos solo tienen un digito: asi: Activo = 1; Pasivo=2...
            //Se desea saber cual es el separador de los codigos de las cuentas.

            await AvisaYCerrateVosSolo("Iniciando el reconocimiento de los separadores de los codigos de cuentas...", "", 1);
            bool puedeContinuar = true;
            string separador = "";
            int tamañomaximo = 0;
            int tamañominimo = 1000000000;

            int digitosElementos = 1;
            int digitosRubros = currentSistemaContable.digitosrubroscontablessc;
            int digitosCuentas = currentSistemaContable.digitoscuentamayorsc;
            int digitosSubCuenta = 0;
            int digitosSubSubCuenta = 0;
            int digitosSubSubSubCuenta = 0;
            for (int j = 1; j < dtGrd.Count; j++)
            {

                #region +
                string kl = dtGrd[j].Row.ItemArray[0].ToString(); //fila arbitraria.

                if (!string.IsNullOrEmpty(kl))
                {
                    if (!kl.All(char.IsDigit)) //preguntamos si no son todos digitos
                    {
                        #region +
                        if (!kl.Any(char.IsLetter)) //pregunto si algun codigo de cuenta posee letras.
                        {
                            #region +
                            for (int i = 1; i < kl.Count(); i++)
                            {
                                #region +
                                if (!kl.Substring(i, 1).All(char.IsDigit)) //si no es digito
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(separador))
                                    {
                                        #region +
                                        if (separador != (kl.Substring(i, 1)))
                                        {
                                            await AvisaYCerrateVosSolo("Se ha encontrado mas de un separador en el codigo contable. El catalogo esta corrupto",
                                                "Repare las incongruencias y vuelva a intentarlo", 1);
                                            //Abandonar.
                                            puedeContinuar = false;
                                        }
                                        #endregion
                                    }
                                    else
                                        separador = (kl.Substring(i, 1));
                                    #endregion
                                } //fin del if
                                if (!string.IsNullOrEmpty(separador))
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                                    {
                                        string[] tam = kl.Split(char.Parse(separador.Trim()));
                                        if (tam.Length > tamañomaximo)
                                            tamañomaximo = tam.Length;
                                        if (tam.Length < tamañominimo)
                                            tamañominimo = tam.Length;
                                    }
                                    #endregion
                                }
                                #endregion
                            } // fin del for 
                            #endregion
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("Se han encontrado incongruencias en los codigos de las cuentas.",
                                "Asegurese de haber eliminado los encabezados extras en el Paso 1", 4);
                            puedeContinuar = false;
                        }
                        #endregion
                    } //fin del if  
                    else //todos son digitos y no hay separadores
                    {
                        #region +
                        for (int i = 1; i < kl.Count(); i++)
                        {
                            int tamKl = kl.Trim().Length;
                            if (tamKl > tamañomaximo)
                                tamañomaximo = tamKl;
                            if (tamKl < tamañominimo)
                                tamañominimo = tamKl;

                            //Quiero indagar cuantos digitos tiene las 3 subcuentas si es que las hay!!
                            if (tamKl > digitosCuentas && digitosSubCuenta == 0)
                            {
                                digitosSubCuenta = tamKl;
                            }
                            if (tamKl > digitosCuentas && tamKl > digitosSubCuenta && digitosSubSubCuenta == 0)
                            {
                                digitosSubSubCuenta = tamKl;
                            }
                            if (tamKl > digitosCuentas && tamKl > digitosSubCuenta && tamKl > digitosSubSubCuenta && digitosSubSubSubCuenta == 0)
                            {
                                digitosSubSubSubCuenta = tamKl;
                            }
                        } // fin del for 
                        #endregion
                    }
                }
                else
                {
                    //DataRow dr = dtGrd[j].Row;
                    dtGrd.Delete(j);
                }
                #endregion
            } // fin del for


            if (puedeContinuar) //se desactiva cuando en los codigos de las cuentas se encuentran mas de un separador de numeros
            {
                #region +
                if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                { await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4); }
                else
                {
                    await AvisaYCerrateVosSolo("Los codigos de las cuentas contables seran separados" + Environment.NewLine
                 + "Segun la configuracion de digitos en el sistema contable.", "La separacion quedara asi:"
                 + Environment.NewLine + "Elementos [1], Rubros [" + digitosRubros + "], Cuentas [" + digitosCuentas + "],"
                 + Environment.NewLine + "Sub-Cuentas [" + digitosSubCuenta + "], Sub-sub-cuentas [" + digitosSubSubCuenta + "], Sub-sub-sub-cuentas [" + digitosSubSubSubCuenta + "]"
                 + Environment.NewLine + "El exceso sera ignorado.", 5);
                }

                //lista = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllImportacion(currentEncargo.idencargo));
                //currentSistemaContable.
                int? idimaginario = 0;
                //var cuantosRegistrosHayEnLaBase;
                try
                {
                    using (db = new SGPTEntidades())
                    {
                        idimaginario = db.catalogocuentas.Max(t => t.idcc);
                        if (idimaginario < 0 || idimaginario == null)
                            idimaginario = 0;

                        string fd = "ALTER SEQUENCE sgpt.catalogocuentas_idcc_seq RESTART WITH " + (idimaginario + 1) + ";";
                        var reiniciarIdPorDefectoDePostgreSql = db.Database.ExecuteSqlCommand(fd);
                        db.SaveChanges();
                        //}
                        //idimaginario++; //le sumo uno, pq la cochinada del restart lo pone en un valor y postgres le suma 1 no se por que.
                    }
                }
                catch
                {
                    //Hay un error en la consulta sobre  el valor máximo
                    ObservableCollection<catalogocuenta> listaTemporal = CatalogoCuentasModelo.GetAllCapaDatos();
                    if (listaTemporal.Count > 0)
                    {

                        idimaginario = listaTemporal.Max(x => x.idcc);
                    }
                    else
                    {
                        //Lista vacia
                        idimaginario = 0;
                    }
                    if (idimaginario < 0 || idimaginario == null)
                        idimaginario = 0;
                    using (db = new SGPTEntidades())
                    {
                        string fd = "ALTER SEQUENCE sgpt.catalogocuentas_idcc_seq RESTART WITH " + (idimaginario + 1) + ";";
                        var reiniciarIdPorDefectoDePostgreSql = db.Database.ExecuteSqlCommand(fd);
                        db.SaveChanges();
                    }
                }
                //int cuantosRegistrosHayEnLaBase=GetAllCountByIdSc()
                //int idimaginario = cuantosRegistrosHayEnLaBase;
                int idcorrelativo = 0;

                int codpadreelemento = 0;
                int codpadrerubro = 0;
                int codpadrecuenta = 0;
                int codpadresubcuenta = 0;
                int codpadresubsubcuenta = 0;

                string[] col11 = { };
                Message = "Espere... reconociendo las cuentas una a una.";
                await Task.Delay(1);

                DataRowView dr;
                bool notIsProcesable = false;
                for (int i = 0; i < dtGrd.Count; i++)
                {
                    //foreach (DataRowView dr in dtGrd)
                    //{
                    dr = dtGrd[i];
                    notIsProcesable = true;
                    if ((dr.Row.ItemArray[0].ToString().Trim().Length > 0))
                    {
                        notIsProcesable = MetodosModelo.IsAlpha(dr.Row.ItemArray[0].ToString().Trim());//Verificando que no  contenga texto
                    }
                    else
                    {
                        notIsProcesable = true;
                    }
                    if (!notIsProcesable)
                    {
                        #region +
                        idcorrelativo++;
                        idimaginario++;
                        decimal drr = dtGrd.Count / 2;
                        if (idcorrelativo == Math.Round(drr))
                        {
                            Message = "Espere... reconociendo las cuentas una a una. Fila: " + idcorrelativo;
                            await Task.Delay(1);
                        }
                        string col1 = (dr.Row.ItemArray[0].ToString()).Trim();
                        string col2 = (dr.Row.ItemArray[1].ToString()).Trim();

                        CatalogoCuentasModelo cat = new CatalogoCuentasModelo();

                        if (!string.IsNullOrEmpty(separador) && separador.Length == 1)//(col11.Count() >= 1 && !string.IsNullOrEmpty(separador))//tienen separadores los codigos de cuenta
                        {
                            #region +
                            if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                            {
                                col11 = col1.Split(char.Parse(separador.Trim()));
                                col11 = col11.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                            }

                            if (tamañomaximo > tamañominimo) //si los codigos de las cuentas no tienen el mismo numero de digitos
                            {
                                #region +
                                try
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(col1) && !string.IsNullOrEmpty(col2))
                                    {
                                        #region +
                                        //if (currentSistemaContable.digitoscuentamayorsc != currentSistemaContable.digitosrubroscontablessc + 1)
                                        //await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4);
                                        cat.idcc = (int)idimaginario;
                                        cat.idCorrelativo = idcorrelativo;

                                        int cod = int.Parse(col11[0]);
                                        var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                        ClaseCuentaModelo cla = new ClaseCuentaModelo();


                                        if (col11.Count() == 1) //Elemento
                                        {
                                            cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                            codpadreelemento = (int)idimaginario;
                                        }
                                        else if (col11.Count() == 2)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                        {
                                            cla = listaClaseCuenta2[2];
                                            //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                            cat.catidcc = codpadreelemento;//pad.idcc;
                                            codpadrerubro = (int)idimaginario;
                                        }
                                        else if (col11.Count() == 3)//currentSistemaContable.digitoscuentamayorsc)
                                        {
                                            cla = listaClaseCuenta2[3];
                                            cat.catidcc = codpadrerubro; //idimaginario - 1;
                                            codpadrecuenta = (int)idimaginario;
                                        }
                                        else if (col11.Count() == 4)//currentSistemaContable.digitoscuentamayorsc + 1)
                                        {
                                            cla = listaClaseCuenta2[4];
                                            cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                            codpadresubcuenta = (int)idimaginario;
                                        }
                                        else if (col11.Count() == 5)//currentSistemaContable.digitoscuentamayorsc + 2)
                                        {
                                            cla = listaClaseCuenta2[5];
                                            cat.catidcc = codpadresubcuenta;//idimaginario - 1;
                                            codpadresubsubcuenta = (int)idimaginario;
                                        }
                                        else if (col11.Count() == 6)//currentSistemaContable.digitoscuentamayorsc + 3)
                                        {
                                            cla = listaClaseCuenta2[6];
                                            cat.catidcc = codpadresubsubcuenta;// idimaginario - 1;
                                        }
                                        else
                                        {
                                            cla = listaClaseCuenta2[0];
                                            //cat.catidcc = idimaginario - 1;
                                        }

                                        cat.ClaseCuenta = cla;
                                        cat.nombreClaseCuenta = cla.descripcionccuentas;

                                        cat.listaClaseCuenta = listaClaseCuenta2;
                                        if (elem != null)
                                            cat.idelementos = elem.id;
                                        cat.Elementoss = elem;
                                        cat.nombreElemento = elem.descripcion;
                                        cat.listaElementos = listaElementos2;
                                        cat.idsc = currentSistemaContable.idsc;
                                        cat.idccuentas = 1;
                                        cat.codigocc = col1;
                                        cat.descripcioncc = col2;
                                        #endregion
                                    }
                                    #endregion
                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("Error desconocido al intentar reconocer los codigos de las cuentas", "Verifique que el archivo no este corrupto.");
                                    return lista;
                                }
                                #endregion
                            }
                            else //todos los codigos de cuentas tienen el mismo tamaño. ej: 1.0.0.0.0 Activo, 1.1.0.0.0 activo circulante, etc. Osea los elementos, los rubros, las cuentas poseen el mismo numero de digitos.
                            {
                                #region +
                                try
                                {
                                    #region +
                                    if (!string.IsNullOrEmpty(col1) && !string.IsNullOrEmpty(col2))
                                    {
                                        #region +
                                        //if (currentSistemaContable.digitoscuentamayorsc != currentSistemaContable.digitosrubroscontablessc + 1)
                                        //await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4);
                                        cat.idcc = (int)idimaginario;
                                        cat.idCorrelativo = idcorrelativo;
                                        cat.ordencc = idcorrelativo;//Cualquier valor se supone que ya  viene ordenado
                                        int cod = int.Parse(col11[0]);
                                        var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                        ClaseCuentaModelo cla = new ClaseCuentaModelo();
                                        int colcount = 0;


                                        try
                                        {
                                            for (int h = 0; h < col11.Count(); h++)//empezamos por la columna 2 ej: 1.[1].0.0.00
                                            {
                                                //h++;
                                                string aj = col11[h];
                                                if (int.Parse(col11[h]) == 0)
                                                {
                                                    if ((h + 1) < col11.Count())
                                                    {
                                                        if (int.Parse(col11[h + 1]) == 0)
                                                        {
                                                            colcount = h;
                                                            h = col11.Count();
                                                            //cantDigitos = false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        colcount = h;
                                                        h = col11.Count();
                                                        //cantDigitos = false;
                                                    }
                                                }
                                                else
                                                {
                                                    if ((h + 1) == col11.Count())
                                                    {
                                                        colcount = h + 1;
                                                    }

                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }

                                        //}

                                        if (colcount == 1) //Elemento
                                        {
                                            cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                            codpadreelemento = (int)idimaginario;
                                        }
                                        else if (colcount == 2)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                        {
                                            cla = listaClaseCuenta2[2];
                                            //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                            cat.catidcc = codpadreelemento;//pad.idcc;
                                            codpadrerubro = (int)idimaginario;
                                        }
                                        else if (colcount == 3)//currentSistemaContable.digitoscuentamayorsc)
                                        {
                                            cla = listaClaseCuenta2[3];
                                            cat.catidcc = codpadrerubro; //idimaginario - 1;
                                            codpadrecuenta = (int)idimaginario;
                                        }
                                        else if (colcount == 4)//currentSistemaContable.digitoscuentamayorsc + 1)
                                        {
                                            cla = listaClaseCuenta2[4];
                                            cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                            codpadresubcuenta = (int)idimaginario;
                                        }
                                        else if (colcount == 5)//currentSistemaContable.digitoscuentamayorsc + 2)
                                        {
                                            cla = listaClaseCuenta2[5];
                                            cat.catidcc = codpadresubcuenta;//idimaginario - 1;
                                            codpadresubsubcuenta = (int)idimaginario;
                                        }
                                        else if (colcount == 6)//currentSistemaContable.digitoscuentamayorsc + 3)
                                        {
                                            cla = listaClaseCuenta2[6];
                                            cat.catidcc = codpadresubsubcuenta;// idimaginario - 1;
                                        }
                                        else
                                        {
                                            cla = listaClaseCuenta2[0];

                                            //cat.catidcc = idimaginario - 1;
                                        }


                                        cat.ClaseCuenta = cla;
                                        cat.nombreClaseCuenta = cla.descripcionccuentas;

                                        cat.listaClaseCuenta = listaClaseCuenta2;
                                        if (elem != null)
                                            cat.idelementos = elem.id;
                                        cat.Elementoss = elem;
                                        cat.nombreElemento = elem.descripcion;
                                        cat.listaElementos = listaElementos2;
                                        cat.idsc = currentSistemaContable.idsc;
                                        cat.idccuentas = 1;
                                        cat.codigocc = col1;
                                        cat.descripcioncc = col2;
                                        #endregion
                                    }
                                    #endregion
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Error desconocido al intentar reconocer los codigos de las cuentas", "Verifique que el archivo no este corrupto.");
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else //sin separadores
                        {
                            #region +
                            try
                            {
                                if (!string.IsNullOrEmpty(col1) && !string.IsNullOrEmpty(col2))
                                {
                                    #region +
                                    if (tamañomaximo > tamañominimo)
                                    {
                                        #region +
                                        //if (currentSistemaContable.digitoscuentamayorsc != currentSistemaContable.digitosrubroscontablessc + 1)
                                        //await AvisaYCerrateVosSolo("Los codigos de las cuentas contables seran separados" + Environment.NewLine + "Segun la configuracion de digitos en el sistema contable.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [" + digitosRubros + "], Cuentas [" + digitosCuentas + "]," + Environment.NewLine + "Sub-Cuentas [" + digitosSubCuenta + "], Sub-sub-cuentas [" + digitosSubSubCuenta + "], Sub-sub-sub-cuentas [" + digitosSubSubSubCuenta + "]"+Environment.NewLine+"El exceso sera ignorado.", 5);
                                        cat.idcc = (int)idimaginario;
                                        cat.idCorrelativo = idcorrelativo;

                                        int cod = int.Parse(col1.Substring(0, 1));
                                        var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                        ClaseCuentaModelo cla = new ClaseCuentaModelo();


                                        if (col1.Count() == digitosElementos) //Elemento
                                        {
                                            cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                            codpadreelemento = (int)idimaginario;
                                        }
                                        else if (col1.Count() == digitosRubros)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                        {
                                            cla = listaClaseCuenta2[2];
                                            //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                            cat.catidcc = codpadreelemento;//pad.idcc;
                                            codpadrerubro = (int)idimaginario;
                                        }
                                        else if (col1.Count() == digitosCuentas)//currentSistemaContable.digitoscuentamayorsc)
                                        {
                                            cla = listaClaseCuenta2[3];
                                            cat.catidcc = codpadrerubro; //idimaginario - 1;
                                            codpadrecuenta = (int)idimaginario;
                                        }
                                        else if (col1.Count() == digitosSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 1)
                                        {
                                            cla = listaClaseCuenta2[4];
                                            cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                            codpadresubcuenta = (int)idimaginario;
                                        }
                                        else if (col1.Count() == digitosSubSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 2)
                                        {
                                            cla = listaClaseCuenta2[5];
                                            cat.catidcc = codpadresubcuenta;
                                            codpadresubsubcuenta = (int)idimaginario;
                                        }
                                        else if (col1.Count() == digitosSubSubSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 3)
                                        {
                                            cla = listaClaseCuenta2[6];
                                            cat.catidcc = codpadresubsubcuenta;
                                        }
                                        else
                                        {
                                            cla = listaClaseCuenta2[0];
                                            //cat.catidcc = idimaginario - 1;
                                        }


                                        cat.ClaseCuenta = cla;
                                        cat.nombreClaseCuenta = cla.descripcionccuentas;

                                        cat.listaClaseCuenta = listaClaseCuenta2;
                                        if (elem != null)
                                            cat.idelementos = elem.id;
                                        cat.Elementoss = elem;
                                        cat.nombreElemento = elem.descripcion;
                                        cat.listaElementos = listaElementos2;
                                        cat.idsc = currentSistemaContable.idsc;
                                        cat.idccuentas = 1;
                                        cat.codigocc = col1;
                                        cat.descripcioncc = col2;
                                        #endregion
                                    }
                                    else
                                    {
                                        await AvisaYCerrateVosSolo("Los codigos de las cuentas no fueron soportados en esta version 1.0 ", "Sugerencia: Realice puntuaciones para dividir los elementos y rubros de las cuentas", 4);
                                        return lista;
                                    }
                                    #endregion
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error desconocido al intentar reconocer los codigos de las cuentas", "Verifique que el archivo no este corrupto.");
                                return lista;
                            }
                            #endregion
                        }

                        lista.Add(cat);
                        RaisePropertyChanged("lista");
                        #endregion
                    }
                    else
                    {
                        Message = "La Fila: " + i + "no sera importada";
                        await Task.Delay(1);
                    }
                    //}
                }

                RaisePropertyChanged("lista");
                if (lista.Count() > 0)
                {
                    Message = "Ordenando las cuentas de forma ascendente... Espere...";
                    await Task.Delay(1);
                    //04-05-2015
                    //Correcciones a la lista
                    //Se requiere listado de elementos (para identificarlos)
                    ObservableCollection<elemento> elementos = new ObservableCollection<elemento>(ElementoModelo.GetBySistemaContableAllCapaDatos(currentSistemaContable.idsc));
                    ObservableCollection<clasecuenta> clasecuentas = new ObservableCollection<clasecuenta>(ClaseCuentaModelo.GetAllCapaDatos());
                    //Identificar los elementos
                    clasecuenta claseCuentaRegistro = new clasecuenta();
                    clasecuenta claseCuentaAnterior = new clasecuenta();
                    elemento tipoElemento = new elemento();
                    int localizacionCuenta = 0;
                    int largoSubcuenta = 0;
                    int limiteSuperior = 0;
                    for (int k = 0; k <= clasecuentas.Count(); k++)
                    {
                        #region clasificacion cuentas
                        try
                        {
                            //Inicializo el registro
                            claseCuentaRegistro = new clasecuenta();
                            if (k == 0)
                            {
                                //Inicio se busca el primer elemento 
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == null);
                            }
                            else
                            {
                                //Con base al padre se busca al hijo
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == claseCuentaAnterior.idccuentas);
                            }
                            //Guardando elemento procesado
                            if (claseCuentaRegistro != null)
                            {
                                claseCuentaAnterior = claseCuentaRegistro;
                            }
                            //Procesando el elemento
                            if (claseCuentaRegistro != null || claseCuentaRegistro.idccuentas != 0)
                            {
                                #region Clasificacion de cuentas

                                if (claseCuentaRegistro.padreidccuentas == null)
                                {
                                    #region proceso para establecer el id elementos, tipo de saldos (preliminar) 
                                    //Busqueda de Elementos     
                                    foreach (elemento item in elementos)
                                    {
                                        localizacionCuenta = (int)lista.SingleOrDefault(x => x.idsc == currentSistemaContable.idsc &&
                                                                    x.codigocc == item.codigoelemento.ToString()).idelementos;
                                        if (localizacionCuenta != 0)
                                        {
                                            //Se localizo el  elemento
                                            lista[localizacionCuenta].idelementos = item.idelementos;
                                            lista[localizacionCuenta].idccuentas = claseCuentaRegistro.idccuentas;
                                            lista[localizacionCuenta].catidcc = null;//No tiene registro del que dependa es un elemento
                                            lista[localizacionCuenta].tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByIdElemento(item);
                                        }
                                    }

                                    #endregion fin de clasificacion preliminar
                                }
                                else
                                {
                                    #region clasificacion de  rubos y cuentas
                                    if (k == 1)//Rubros
                                    {
                                        //Clasificacion de rubros
                                        foreach (CatalogoCuentasModelo cuenta in lista)
                                        {
                                            if (cuenta.codigocc.Length == currentSistemaContable.digitosrubroscontablessc)
                                            {
                                                cuenta.idccuentas = claseCuentaRegistro.idccuentas;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (k == 2)//Cuentas
                                        {
                                            //Clasificacion de rubros
                                            foreach (CatalogoCuentasModelo cuenta in lista)
                                            {
                                                if (cuenta.codigocc.Length == currentSistemaContable.digitoscuentamayorsc)
                                                {
                                                    cuenta.idccuentas = claseCuentaRegistro.idccuentas;
                                                }
                                            }
                                        }
                                    }
                                    #endregion
                                }

                                #endregion fin de clasificacion de cuentas

                                #region clasificacion de sub-cuentas.
                                if (k >= 3)
                                {
                                    if (limiteSuperior == 0)
                                    {
                                        limiteSuperior = currentSistemaContable.digitoscuentamayorsc;
                                    }
                                    else
                                    {
                                        limiteSuperior = largoSubcuenta;
                                    }
                                    //Se reinicializa la  variable
                                    largoSubcuenta = 1000;//Solo para establecer un punto inicial
                                    foreach (CatalogoCuentasModelo cuenta in lista)
                                    {
                                        if (cuenta.codigocc.Length > limiteSuperior)
                                        {
                                            if (largoSubcuenta > cuenta.codigocc.Length)
                                            {
                                                largoSubcuenta = cuenta.codigocc.Length;
                                            }
                                        }
                                    }
                                    if (largoSubcuenta != 1000)
                                    {
                                        //Se conoce el nuevo elemento de clasificacion
                                        //Clasificacion de rubros
                                        foreach (CatalogoCuentasModelo cuenta in lista)
                                        {
                                            if (cuenta.codigocc.Length == largoSubcuenta)
                                            {
                                                cuenta.idccuentas = claseCuentaRegistro.idccuentas;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        //Se termino la busqueda
                                        k = clasecuentas.Count();
                                    }
                                }
                                #endregion
                            }

                        }
                        catch (Exception)
                        {
                            //Error el proceso
                        }
                        #endregion Fin de  clasificacion
                    }

                    ObservableCollection<CatalogoCuentasModelo> listaPadres = new ObservableCollection<CatalogoCuentasModelo>();
                    ObservableCollection<CatalogoCuentasModelo> listaHijos = new ObservableCollection<CatalogoCuentasModelo>();

                    //Longitud de rubro, cuenta, sub-cuenta
                    //Listado de clase de cuenta
                    claseCuentaAnterior = new clasecuenta();
                    claseCuentaAnterior = new clasecuenta();
                    int limite = (int)lista.Max(x => x.idccuentas);
                    for (int k = 0; k <= limite - 1; k++) //Es -1 porque el ultimo nivel no tiene dependencias
                    {
                        #region clasificacion cuentas
                        try
                        {
                            //Inicializo el registro
                            claseCuentaRegistro = new clasecuenta();
                            if (k == 0)
                            {
                                //Inicio se busca el primer elemento 
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == null);
                            }
                            else
                            {
                                //Con base al padre se busca al hijo
                                claseCuentaRegistro = clasecuentas.SingleOrDefault(x => x.padreidccuentas == claseCuentaAnterior.idccuentas);
                            }
                            if (claseCuentaRegistro != null)
                            {
                                claseCuentaAnterior = claseCuentaRegistro;
                            }
                            listaPadres = new ObservableCollection<CatalogoCuentasModelo>(lista.Where(x => x.idccuentas == claseCuentaRegistro.idccuentas).ToList());
                            if (listaPadres.Count > 0)
                            {
                                foreach (CatalogoCuentasModelo padre in listaPadres)
                                {
                                    //Asignar los hijos
                                    foreach (CatalogoCuentasModelo cuenta in lista)
                                    {
                                        if (cuenta.codigocc.StartsWith(padre.codigocc) && cuenta.idccuentas == claseCuentaRegistro.idccuentas + 1)
                                        {
                                            cuenta.catidcc = padre.idcc;
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error en  la reclasificación" + e);
                        }
                        #endregion clasificacion de padres
                    }
                    //var lixta = await this.OrdenarImportacion(lista.ToList());
                    //**Correccion de  saldos
                    #region correccion  de  saldos

                    string tiposaldo = string.Empty;
                    ObservableCollection<elemento> elementoContable = new ObservableCollection<elemento>(ElementoModelo.GetBySistemaContableAllCapaDatos(currentSistemaContable.idsc));
                    //int m = 1;
                    foreach (elemento item in elementoContable)
                    {
                        tiposaldo = TipoSaldoCuentaModelo.claseSaldoByIdElemento(item);
                        foreach (CatalogoCuentasModelo cuenta in lista)
                        {
                            if (cuenta.Elementoss.id == item.idelementos || cuenta.codigocc.StartsWith(item.codigoelemento.ToString()))
                            {
                                cuenta.tiposaldocc = tiposaldo;
                                //Message = "Corrigiendo: -**- "+m+" del total " + cuenta.descripcioncc + " tipo saldo " + cuenta.tiposaldocc;
                                //await Task.Delay(1);
                            }
                            //m++;
                        }
                    }

                    #endregion

                    #region correccion de  saldos
                    #region correccion estimada de  saldos
                    foreach (CatalogoCuentasModelo cuenta in lista)
                    {
                        if (cuenta.tiposaldocc == "D" && cuenta.idccuentas >= 4)
                        {
                            //Depreciaciones
                            if ((cuenta.descripcioncc.Contains("DEPRECIA")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("DEPR")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }                                        //Amortizacion
                            if ((cuenta.descripcioncc.Contains("DEP.")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }

                            if ((cuenta.descripcioncc.Contains("AMORTIZ")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            //Amortizacion
                            if ((cuenta.descripcioncc.Contains("ESTIMAC")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            //Amortizacion
                            if ((cuenta.descripcioncc.Contains("RESERVA")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("DESVALORIZA")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("PROVISI")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("INCOBRABLE")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("DETERIORO")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("(CR)")))//Indica crédito
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                            if ((cuenta.descripcioncc.Contains("AGOTAMIENTO")))//Indica crédito
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(2);
                            }
                        }
                        if (cuenta.tiposaldocc == "A" && cuenta.idccuentas >= 3)
                        {
                            //Depreciaciones
                            if ((cuenta.descripcioncc.Contains("PERDIDA")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                            }
                            //Amortizacion
                            if ((cuenta.descripcioncc.Contains("PERDIDAS")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                            }
                            if ((cuenta.descripcioncc.Contains("PÉRDIDA")))
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                            }
                            if ((cuenta.descripcioncc.Contains("(DR)")))//Indica saldo deudor
                            {
                                cuenta.tiposaldocc = TipoSaldoCuentaModelo.claseSaldoByClaseElemento(1);
                            }
                        }

                    }
                    #endregion
                    #endregion

                    listaCatalogoImportar = CatalogoCuentasModelo.OrdenarImportacion(lista);

                    //if (listaCatalogoImportar.Count > 0)
                    //{
                    //    visibilityDatosTransformadosBalance = Visibility.Collapsed;
                    //    visibilityDatosTransformados = Visibility.Visible;
                    //    visibilityDatosCaptura = Visibility.Visible;
                    //    visibilityDatosIniciales = Visibility.Collapsed;
                    //}
                    Message = "Finalizado éxitosamente. Se procedera a guardar.";
                    await Task.Delay(1);

                    return lista;
                }
                else
                {
                    Message = "Lista vacia... accion no permitida.";
                    await Task.Delay(1);
                    return lista;
                }
                //await dlg.ShowMessageAsync(this, "Atencion. Haga doble click en las columnas: [Rango | Tipo de elemento | Tipo de Saldo] para ajustar alguna cuenta que este erronea por el reconocimiento automatico.", "Revise detenidamente los saldos Deudor/Acreedor de cada cuenta antes de guardar.");
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("No fue posible continuar. Existen cuentas que no estan  en  el catalogo.", "Ejecute incorporación de cuentas.", 2);
                Reprocesar();
                return lista;
            }
            #endregion 
        }


        public async void Reprocesar()
        {
            //Para guardar lo que esta en la  pantalla
            try
            {
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Hay cuentas que no existen  en  el catalogo", "¿Desea actualizar los nuevos códigos?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    //Reprocesar datos
                    //var lista = ReprocesarCatalogoCuentas();
                    ObservableCollection<CatalogoCuentasModelo> lista = await ReprocesarCatalogoCuentas();
                    //Obtiene la lista del catalogo actual
                    ObservableCollection<CatalogoCuentasModelo> listaCatalogoGuardado = new ObservableCollection<CatalogoCuentasModelo>();
                    listaCatalogoGuardado = CatalogoCuentasModelo.GetAll(currentSistemaContable.idsc, true);
                    ObservableCollection<CatalogoCuentasModelo> Agregar = new ObservableCollection<CatalogoCuentasModelo>();
                    //Compararla y determinr registros a actualizar
                    lista = CatalogoCuentasModelo.RegeneraOrdenSubRegistrosSinGuardar(lista);
                    //Identificar registros a guardar
                    Agregar = new ObservableCollection<CatalogoCuentasModelo>((from p in lista
                                                                               where !(from ex in listaCatalogoGuardado
                                                                                       select ex.codigocc)
                                                                                       .Contains(p.codigocc)
                                                                               select p).ToList());
                    //Cambiar referencia de registros
                    ObservableCollection<CatalogoCuentasModelo> revisar = new ObservableCollection<CatalogoCuentasModelo>();
                    bool resultado = true;
                    CatalogoCuentasModelo temporal = new CatalogoCuentasModelo();
                    foreach (CatalogoCuentasModelo item in Agregar)
                    {
                        if (item.catidcc != null)
                        {
                            item.codigoContablePadre = lista.Single(x => x.idcc == item.catidcc).codigocc;
                        }
                    }
                    if (Agregar.Count > 0)
                    {
                        foreach (CatalogoCuentasModelo item in Agregar)
                        {
                            try
                            {
                                temporal = listaCatalogoGuardado.SingleOrDefault(x => x.codigocc == item.codigoContablePadre);
                                if (temporal != null && temporal.idcc != 0)
                                {
                                    item.catidcc = temporal.idcc;
                                    switch (CatalogoCuentasModelo.Insert(item))
                                    {
                                        case 0:
                                            await AvisaYCerrateVosSolo("El registro esta vacio no puede insertarse...", "", 1);
                                            break;
                                        case 1:
                                            await AvisaYCerrateVosSolo("Se insertó con éxito la cuenta " + item.descripcioncc, "", 1);
                                            break;
                                        case -1:
                                            await AvisaYCerrateVosSolo("Se generó un error en la cuenta " + item.descripcioncc, "", 1);
                                            break;
                                    }
                                }
                                else
                                {
                                    revisar.Add(item); //Se agrega para probar despues porque  el padre no se localiza
                                }
                                temporal = new CatalogoCuentasModelo();
                            }
                            catch (Exception e)
                            {
                                await AvisaYCerrateVosSolo("Se generó un error en la cuenta " + item.descripcioncc, ""+e, 1);
                                revisar.Add(item); //Se agrega para probar despues porque  el padre no se localiza
                            }
                        }
                    }
                    //Actualizar el listado
                    ObservableCollection<CatalogoCuentasModelo> registrosConProblemas = new ObservableCollection<CatalogoCuentasModelo>();
                    //Actualizar pendientes
                    if (revisar.Count > 0)
                    {
                        listaCatalogoGuardado = CatalogoCuentasModelo.GetAll(currentSistemaContable.idsc, true);

                            foreach (CatalogoCuentasModelo item in revisar)
                        {
                            temporal = listaCatalogoGuardado.Single(x => x.codigocc == item.codigoContablePadre);
                            if (temporal != null && temporal.idcc != 0)
                            {
                                item.catidcc = temporal.idcc;
                                switch (CatalogoCuentasModelo.Insert(item))
                                {
                                    case 0:
                                        await AvisaYCerrateVosSolo("El registro esta vacio no puede insertarse...", "", 1);
                                        break;
                                    case 1:
                                        await AvisaYCerrateVosSolo("Se insertó con éxito la cuenta " + item.descripcioncc, "", 1);
                                        break;
                                    case -1:
                                        await AvisaYCerrateVosSolo("Se generó un error en la cuenta " + item.descripcioncc, "", 1);
                                        break;
                                }
                            }
                            else
                            {
                                registrosConProblemas.Add(item); //Se agrega para probar despues porque  el padre no se localiza
                            }
                            temporal = new CatalogoCuentasModelo();
                        }
                    }
                    //Reintento
                    //Actualizar pendientes
                    if (registrosConProblemas.Count > 0)
                    {
                        listaCatalogoGuardado = CatalogoCuentasModelo.GetAll(currentSistemaContable.idsc, true);

                        foreach (CatalogoCuentasModelo item in registrosConProblemas)
                        {
                            temporal = listaCatalogoGuardado.Single(x => x.codigocc == item.codigoContablePadre);
                            if (temporal != null && temporal.idcc != 0)
                            {
                                item.catidcc = temporal.idcc;
                                switch (CatalogoCuentasModelo.Insert(item))
                                {
                                    case 0:
                                        await AvisaYCerrateVosSolo("El registro esta vacio no puede insertarse...", "", 1);
                                        break;
                                    case 1:
                                        await AvisaYCerrateVosSolo("Se insertó con éxito la cuenta " + item.descripcioncc, "", 1);
                                        break;
                                    case -1:
                                        await AvisaYCerrateVosSolo("Se generó un error en la cuenta " + item.descripcioncc, "", 1);
                                        break;
                                }
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("La cuenta " + item.descripcioncc, " No pudo incorporarse", 1);
                                resultado = false;
                            }

                        }
                    }
                    if (resultado)
                    {
                        await dlg.ShowMessageAsync(this, "El proceso concluyo con éxito", "Pruebe ahora incorporar el balance");
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Algunos registros no pudieron actualizare", "Revise el archivo contra el catalogo");
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No se puede incorporar los datos", "Corrija el catálogo de cuentas");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el reconocimiento del balance. Revise el archivo \n" + e);
            }
        }


        #endregion
        private string _TokenAUsar;
        public string tokenAUsar
        {
            get { return _TokenAUsar; }
            set { _TokenAUsar = value; RaisePropertyChanged("tokenAUsar"); }
        }
        public ObservableCollection<GridItem> GridItems { get; set; }


        /// 04/05/2016 para gestionar el boton

        public bool canAvanzar()
        {
            if (FocoPestañaSeleccionada < 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MycmdCancelar()
        {
            iniciarComando();
            //await AvisaYCerrateVosSolo("Cancelado ", "", 1);

            //Messenger.Default.Send<int>(2, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.

            GC.Collect();
            //-1 fracaso
            //0 inicializadores (No usar)
            //1 éxito
            //2 Cancelo
            this.cmdCancelarX();
        }

        private void cmdCancelarX()
        {
            //_result = false;
            //FinalizarAction();
            fuenteCierre = 1;
            resultadoProceso = 2;
            CloseWindow();

        }

        #region ViewModel Commands
        public RelayCommand cmdAtras { get; set; }

        public RelayCommand cmdAdelante { get; set; }

        public RelayCommand cmdFinalizar { get; set; }

        public RelayCommand SalirCommand { get; set; }

        public RelayCommand cmdCargarCat_Click { get; set; }

        public RelayCommand cmdCancelar { get; set; }

        #endregion

        #region Registro de comandos
        private void RegisterCommands()
        {
            cmdAtras = new RelayCommand(MycmdAtras, canAtras);//ok
            cmdAdelante = new RelayCommand(ProcesarDatos, canAdelante);//ok
            cmdFinalizar = new RelayCommand(MycmdFinalizar, canSave);//ok
            SalirCommand = new RelayCommand(Salir);//ok
            cmdCancelar = new RelayCommand(MycmdCancelar);//ok
            cmdCargarCat_Click = new RelayCommand(cmdCargarCatalogo);//ok
        }
        #endregion

        #region Comandos

            private void MycmdAtras()
            {
                if (FocoPestañaSeleccionada > 0)
                {
                    switch (FocoPestañaSeleccionada)
                     {
                         case 0:
                             FocoPestañaSeleccionada=0;
                             break;
                         case 1:
                             FocoPestañaSeleccionada = 0;
                             break;
                         case 2:
                             if (extensionArchivo.ToLower() == ".txt" || extensionArchivo.ToLower() == ".csv")
                             {
                                 FocoPestañaSeleccionada = 1;
                             }
                             else
                             {
                                 FocoPestañaSeleccionada = 0;
                             }
                             break;
                        case 3:
                            if (extensionArchivo.ToLower() == ".txt" || extensionArchivo.ToLower() == ".csv")
                            {
                                FocoPestañaSeleccionada = 2;
                            }
                            else
                            {
                                FocoPestañaSeleccionada = 1;
                            }
                            break;
                        default:
                            FocoPestañaSeleccionada--;
                            break;
                    }
                    //FocoPestañaSeleccionada--;
                };
            }

            public bool canAtras()
            {
                if (FocoPestañaSeleccionada > 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool canAdelante()
            {
                if (FocoPestañaSeleccionada >=1 && FocoPestañaSeleccionada<=3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            private void MycmdAdelante()
            {
                //await AvisaYCerrateVosSolo("Adelante", "", 1);
                if (FocoPestañaSeleccionada < 6)
                {
                     switch (FocoPestañaSeleccionada)
                     {
                         case 0:
                             FocoPestañaSeleccionada++;
                             break;
                         case 1:
                             if (extensionArchivo.ToLower() == ".txt" || extensionArchivo.ToLower() == ".csv")
                             {
                                 FocoPestañaSeleccionada = 2;
                             }
                             else
                             {
                                 FocoPestañaSeleccionada = 3;
                             }
                             break;
                         case 2:
                             FocoPestañaSeleccionada=3;
                             break;
                        case 3:
                            FocoPestañaSeleccionada = 4;
                            break;
                        default:
                            FocoPestañaSeleccionada++;
                            break;
                    }
                    //FocoPestañaSeleccionada++;
                }
                if (FocoPestañaSeleccionada == 3)
                    this.ProcesarDatos();
            }

            private bool canSave()
            {
                if (FocoPestañaSeleccionada > 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        private void Salir()
        {
            if (fuenteCierre == 0)
            {
                iniciarComando();
                enviarMensaje();//Cero por cancelamiento
                fuenteCierre = 3;
                CloseWindow();
            }
            else
            {
                if (fuenteCierre == 1)
                {
                    enviarMensaje();
                    fuenteCierre = 4;
                }
            }
            //listaDetallePrograma = null;
        }

        public void enviarMensaje()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenAUsar);
        }

        #endregion comandos
        private async void MycmdFinalizar() //Boton finalizar
        {
            iniciarComando();
            if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.Balance)
            {
                if(HayCatalogoGeneradoAPartirBalance) //Quiere cargar un balance, pero no ha ingresado el catalog de cuentas. se genero uno y va a guardarlo
                {
                    await AvisaYCerrateVosSolo("Se va a guardar un catalogo de cuentas y despues guarda el balance.", "", 3);
                    bool drg= await this.GuardarCatalogoCuentas();
                    await AvisaYCerrateVosSolo("El catalogo de cuentas se ha guardado."+Environment.NewLine+"Continue revisando el balance y Guardelo.","",3);
                    HayCatalogoGeneradoAPartirBalance = false;
                    this.ReconocerBalance(); //ahora vamos a recorrer el balance.
                }
                else //se guardara el balance pq ya existe un catalogo.
                {
                    Message="Preparandose para almacenar un catalogo...Espere...";
                    await Task.Delay(1);
                    if (ListaDetalleBalance != null)
                    {
                        try 
	                    {	        
	                        #region +
		                    balance bal = new balance();
                            bal.idcb = SelectedClaseBalance.idcb;
                            bal.idperiodos = SelectedPeriodoBalance.idperiodos;
                            bal.fechasistemabalance = MetodosModelo.homologacionFecha();
                            bal.fechabalancebalance = MetodosModelo.homologacionFecha(FechaBalance.ToShortDateString());//DateTime.Now.ToShortDateString(); // Ojo hay que pedir esta fecha
                            bal.estadobalance = "A";
                            bal.idscbalance = currentSistemaContable.idsc;
                            bool insercion= BalanceModelo.Insert(bal);
                            if (ListaDetalleBalance != null && insercion)
                            {
                                #region +
                                ListitaDetalleBalance =new ObservableCollection<detallebalance>();
                                int i=0;
                                Message="Convirtiendo cada fila en un registro de base de datos...Espere...";
                                await Task.Delay(1);
                                foreach(var a in ListaDetalleBalance)
                                {
                                    #region +
                                        detallebalance b = new detallebalance();
                                        i++;
                                        Message = "Convirtiendo cada fila en un registro de base de datos...Espere...registro # " + i+ " de "+ ListaDetalleBalance.Count;
                                        await Task.Delay(1);
                                        b.iddb = a.idCorrelativo;
                                        b.idcc = a.idcc;
                                        b.idbalance = bal.idbalance;
                                        b.saldoanteriordb = a.saldoanteriordb;
                                        b.cargodb = a.cargodb;
                                        b.abonodb = a.abonodb;
                                        b.saldofinaldb = a.saldofinaldb;
                                        b.estadodb = "A";
                                        b.orden = a.orden;
                                        if (b.idcc > 0 && b.orden > 0)
                                            ListitaDetalleBalance.Add(b); 
                                    #endregion
                                }
                                Message = "Finalizado. Continuando el proceso de guardado...Espere... " ;
                                await Task.Delay(1);
	                            #endregion
                            }
                            if (insercion && ListaDetalleBalance != null)
                            {
                                //bal.detallebalances = ListitaDetalleBalance;
                                Message = "Intentando guardar el balance...Espere...";
                                await Task.Delay(1);
                                using (db = new SGPTEntidades())
                                {
                                    //db.balances.Add(bal);
                                    //db.SaveChanges();

                                    //Guardando el detalle
                                    if (ListitaDetalleBalance.Count > 0)
                                    {
                                        int zx = 1;
                                        bool resultado = true;
                                        foreach (detallebalance item in  ListitaDetalleBalance)
                                        {
                                            try
                                            {
                                                using (db = new SGPTEntidades())
                                                {
                                                    db.detallebalances.Add(item);
                                                    db.SaveChanges();
                                                }
                                                Message = "Guardando: -**- " + zx + " de " + ListitaDetalleBalance.Count();
                                                await Task.Delay(1);
                                                zx++;
                                            }
                                            catch (Exception)
                                            {
                                                resultado = false;
                                            }

                                        }
                                        if (resultado)
                                        {
                                            Message = "Proceso de Guardado finalizo éxitosamente";
                                            await Task.Delay(1);
                                            await AvisaYCerrateVosSolo("El proceso de guardado del Balance ha finalizado éxitosamente.", "Finalizado.", 3);
                                            resultadoProceso = 1;
                                            fuenteCierre = 1;
                                            CloseWindow();
                                        }
                                        else
                                        {
                                            db.balances.Remove(bal);
                                            db.SaveChanges();
                                            Message = "Proceso de Guardado falló";
                                            await Task.Delay(1);
                                            await AvisaYCerrateVosSolo("El proceso de guardado del Balance ha fallado.", "Finalizado.", 3);
                                            fuenteCierre = 1;
                                            resultadoProceso = -1;
                                            finComando();
                                        }

                                    }
                                }
                            }
                            else
                            {
                                Message = "Proceso de Guardado falló";
                                await Task.Delay(1);
                                await AvisaYCerrateVosSolo("El proceso de guardado del Balance ha fallado.", "Finalizado.", 3);
                                fuenteCierre = 1;
                                resultadoProceso = -1;
                            }
                            finComando();
                            ////-1 fracaso
                            ////0 inicializadores (No usar)
                            ////1 éxito
                            ////2 Cancelo
                            #endregion
                        }
	                    catch (Exception)
	                    {
                            //MessageBox("")
                            //Messenger.Default.Send<int>(-1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.

                            ////-1 fracaso
                            ////0 inicializadores (No usar)
                            ////1 éxito
                            ////2 Cancelo
                            await AvisaYCerrateVosSolo("No es posible guardar el balance", "Verifique que el archivo aun este disponible", 3);
                            fuenteCierre = 1;
                            resultadoProceso = -1;
                            finComando();
                        }
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("No es posible guardar el balance. El listado se encontro vacio","Verifique que el archivo aun este disponible",3);
                        //Messenger.Default.Send<int>(-1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
                        fuenteCierre = 1;
                        resultadoProceso = -1;
                        finComando();

                    ////-1 fracaso
                    ////0 inicializadores (No usar)
                    ////1 éxito
                    ////2 Cancelo
                    }
                }
            }
            else if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
            {
                bool grd=await GuardarCatalogoCuentas();
                if (grd)
                //Messenger.Default.Send<int>(1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
                {
                    resultadoProceso = 1;
                    fuenteCierre = 1;
                }
                else
                {// Messenger.Default.Send<int>(-1, tokenAUsar);
                    resultadoProceso = -1;
                    fuenteCierre = 1;
                }
                CloseWindow();
                    //-1 fracaso
                    //0 inicializadores (No usar)
                    //1 éxito
                    //2 Cancelo
                finComando();
            }

            
        }

        private async Task<bool> GuardarCatalogoCuentas()
        {
            string k = Message;
            Message = Message + "*-Buscando Catalogos antiguos para eliminarlos-*";
            bool puedeGuardarCatalogo = false;
            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Acepto",
                NegativeButtonText = "Cancelar",

            };
            catalogocuenta existeCatalogoParaEsteSistemaContable = new catalogocuenta();
            using (db = new SGPTEntidades())
            {
                try
                {
                    existeCatalogoParaEsteSistemaContable = (from c in db.catalogocuentas where c.idsc == currentSistemaContable.idsc && c.estadocc=="A" select c).First();
                }
                catch (Exception)
                {
                    existeCatalogoParaEsteSistemaContable = new catalogocuenta();
                }
                if (existeCatalogoParaEsteSistemaContable.idcc > 0 && lista != null)
                {
                    #region +
                    finComando();
                    MessageDialogResult resultk = await dlg.ShowMessageAsync(this, " Ya ha registrado un catalogo de cuentas" 
                        + " para el encargo seleccionado: " + currentEncargo.descripcionTipoAuditoria + " " 
                        + currentEncargo.fechainiperauditencargo + "-" + currentEncargo.fechafinperauditencargo 
                        + Environment.NewLine + "Atencion: Se eliminara irreversiblemente el catalogo antiguo.", "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                    if (resultk == MessageDialogResult.Affirmative)
                    {
                        iniciarComando();
                        using (db = new SGPTEntidades())
                        {
                            /*
                            #region Borrado lógico

                                if (CatalogoCuentasModelo.DeleteLogicoAllByIdsc(currentSistemaContable.idsc))
                                {//string cad = "delete from sgpt.catalogocuentas where idsc=" + currentSistemaContable.idsc + ";";
                                 //var valorMantenimiento = db.Database.ExecuteSqlCommand(cad);
                                 //db.SaveChanges();
                                    puedeGuardarCatalogo = true;
                                    await AvisaYCerrateVosSolo("Se ha eliminado el catalogo antiguo", "finalizado éxitosamente", 1);
                                }
                                else
                                {
                                    puedeGuardarCatalogo = false;//No pudo borrarse el catalogo
                                }

                            #endregion
                            */
                            #region Borrado total

                                string cad = "delete from sgpt.catalogocuentas where idsc=" + currentSistemaContable.idsc + ";";
                                var valorMantenimiento = db.Database.ExecuteSqlCommand(cad);
                                db.SaveChanges();
                                puedeGuardarCatalogo = true;
                                await AvisaYCerrateVosSolo("Se ha eliminado el catalogo antiguo", "finalizado éxitosamente", 1);

                            #endregion
                        }
                    }
                    else puedeGuardarCatalogo = false;
                    #endregion
                }
                else if (lista != null)
                {
                    finComando();
                    MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Esta seguro que desea guardar el catalogo de cuentas" + " para el encargo seleccionado: " + currentEncargo.descripcionTipoAuditoria + " " + currentEncargo.fechainiperauditencargo + "-" + currentEncargo.fechafinperauditencargo + Environment.NewLine, "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                    if (resultk == MessageDialogResult.Affirmative)
                        puedeGuardarCatalogo = true;
                    else
                        puedeGuardarCatalogo = false;
                }
                else puedeGuardarCatalogo = false;

            }
            Message = k;
            if (lista != null && lista.Count() > 1 && puedeGuardarCatalogo)
            {
                iniciarComando();
                //using (db = new SGPTEntidades())
                //{

                #region +
                //var valorMantenimiento = db.Database.ExecuteSqlCommand(
                //"SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 10);");
                string l = ""; l = Message;
                int zx = 0;
                ObservableCollection<catalogocuenta> lst = new ObservableCollection<catalogocuenta>();
                try
                {
                    foreach (var cuenta in lista)
                    {
                        zx++;
                        catalogocuenta UnaFilaCuenta = new catalogocuenta();
                        #endregion*/
                        UnaFilaCuenta.idcc = cuenta.idcc;
                        UnaFilaCuenta.idelementos = cuenta.Elementoss.id;
                        UnaFilaCuenta.idsc = currentSistemaContable.idsc;
                        UnaFilaCuenta.catidcc = cuenta.catidcc;
                        UnaFilaCuenta.idccuentas = cuenta.ClaseCuenta.id;
                        UnaFilaCuenta.codigocc = cuenta.codigocc;
                        UnaFilaCuenta.descripcioncc = cuenta.descripcioncc;
                        UnaFilaCuenta.tiposaldocc = cuenta.tiposaldocc;
                        UnaFilaCuenta.fechacreacioncc = DateTime.Now.ToShortDateString();
                        UnaFilaCuenta.estadocc = "A";
                        UnaFilaCuenta.ordencc = cuenta.ordencc;
                        UnaFilaCuenta.isuso = 0;
                        //if (zx == 599)
                        //    Message = "";
                        //lst.Add(UnaFilaCuenta);
                        using (db = new SGPTEntidades())
                        {
                            db.catalogocuentas.Add(UnaFilaCuenta);
                            db.SaveChanges();
                        }
                        Message = "Guardando: -**- " + zx + " de " + lista.Count() + " -**- " + cuenta.descripcioncc;
                        await Task.Delay(1);
                    }
                    Message = "Proceso de Guardado finalizo éxitosamente";
                    await Task.Delay(1);
                    await AvisaYCerrateVosSolo("El proceso de guardado del catalogo ha finalizado éxitosamente.", "Finalizado.", 2);
                    //Messenger.Default.Send<int>(1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
                    return true;

                    ////-1 fracaso
                    ////0 inicializadores (No usar)
                    ////1 éxito
                    ////2 Cancelo

               }
                catch (Exception e)
                {
                    finComando();
                    MessageBox.Show("Error desconocido. \n" + e, "Se cerro una conexion existente.");
                    //Messenger.Default.Send<int>(-1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
                    resultadoProceso = -1;
                    fuenteCierre = 1;
                    //-1 fracaso
                    //0 inicializadores (No usar)
                    //1 éxito
                    //2 Cancelo
                    return false;
                }
                //} 
            }
            else
            {
                finComando();
                await AvisaYCerrateVosSolo("No hay nada que guardar.", "No ha importado ningun archivo", 2);
                return false;
            }
        }


        private string _NombreCatalogo;
        public string NombreCatalogo
        {
            get { return _NombreCatalogo; }
            set
            {
                _NombreCatalogo = value;
                RaisePropertyChanged("NombreCatalogo");
            }
        }

        private System.Data.DataView _dtGrd;
        public System.Data.DataView dtGrd
        {
            get { return _dtGrd; }
            set
            {
                _dtGrd = value;
                RaisePropertyChanged("dtGrd");
                if (value.Count > 0)
                {
                    visibilityDatosCaptura = Visibility.Visible;
                }
                else
                {
                    visibilityDatosCaptura = Visibility.Collapsed;
                }
            }
        }

        private async void cmdCargarCatalogo()
        {

            try
            {
                bool puedeContinuarImportacion = true;
                if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.Balance)
                {
                    if (SelectedClaseBalance == null || SelectedPeriodoBalance == null)
                        puedeContinuarImportacion = false;
                }
                //else
                //    puedeContinuarImportacion = false;

                if (puedeContinuarImportacion)
                {
                    try
                    {
                        #region +
                        dt.Clear();
                        dt = new DataTable();
                        dtGrd = dt.DefaultView;
                        OpenFileDialog openCatalogo = new OpenFileDialog();
                        openCatalogo.DefaultExt = ".xlsx";
                        openCatalogo.Filter = "Archivos Excel (*.xlsx, *.xls, *.csv, *.txt)|*.xlsx; *.xls; *.csv; *.txt;";

                        openCatalogo.Title = "Importar archivos";
                        //openfile.ShowDialog();

                        var browsefile = openCatalogo.ShowDialog();

                        if (browsefile == true)
                        {
                            iniciarComando();
                            Message = "Procesando...";
                            //await cuenteUno();
                            //txtFilePath.Text = openfile.FileName;
                            await AvisaYCerrateVosSolo("Analizando el archivo...", "Espere, la operacion puede tardar mas de lo esperado", 2);
                            
                            string sArchivo = openCatalogo.FileName;
                            
                            extensionArchivo = Path.GetExtension(sArchivo);
                            string extension = extensionArchivo;
                            NombreCatalogo = sArchivo;
                            RaisePropertyChanged("NombreCatalogo");


                            //dtGrid.ItemsSource = dt.DefaultView;
                            //dtGrd = dt.DefaultView;
                            if (extension.ToLower() == ".xlsx" || extension.ToLower() == ".xls")
                            {
                                DataTable dtf = await SiEsArchivoExcel(sArchivo);
                                dtGrd = dtf.DefaultView;
                            }
                            if (extension.ToLower() == ".txt")
                            {
                                //dtGrd = SiEsArchivoExcel(sArchivo).DefaultView;
                                Message = "Analizando archivo de texto .txt";
                                await Task.Delay(1);
                                dtGrd = SiEsArchivoTxT.DataTableDesdeArchivoTexto(sArchivo, '\t').DefaultView;
                                //dtGrd = SiEsArchivoTxT.DataTableDesdeArchivoTexto(sArchivo, ',').DefaultView;
                            }

                            if (extension.ToLower() == ".csv")
                            {
                                Message = "Analizando archivo separado por comas .csv";
                                await Task.Delay(1);
                                dtGrd = SiEsArchivoCSV(sArchivo).DefaultView;

                            }
                            Message = "Importacion finalizada con éxito. Indicaciones: Puede eliminar filas con tecla delete/suprimir";
                            FocoPestañaSeleccionada = 1;//Se realizo el paso 1
                            finComando();
                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        //HabilitarValidarCatalogo = false;
                        //txtBandera = "0";
                        finComando();
                        MessageBox.Show("Ocurrio un error en la importacion del catalogo de cuentas. \nVerifique que el archivo no este corrupto. " + e, "El archivo del catalogo esta corrupto", MessageBoxButton.OK, MessageBoxImage.Stop);
                        FocoPestañaSeleccionada = 0;//No se realizo el paso 1
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("Para importar un balance, es necesario que especifique su tipo", "Seleccione de los disponibles en el Paso 1", 3);
                    FocoPestañaSeleccionada = 0;//No se realizo el paso 1
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error desconocido");
                FocoPestañaSeleccionada = 0;//No se realizo el paso 1
            }
        } 
        //boton cargar catalogo 

        private async Task<DataTable> SiEsArchivoExcel(string nombreArchivo)
        {
            string sArchivo = nombreArchivo;
            System.Data.DataTable dtt = new System.Data.DataTable();
            Message = "Analizando hoja de calculo... ";
            await Task.Delay(1);
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(sArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet excelSheet2 = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1);

            string nom = excelSheet2.Name;
            HojaCalculoUsada = "Hoja en uso: " + nom;
            Message = "Analizando hoja... " + nom;
            await Task.Delay(1);
            Microsoft.Office.Interop.Excel.Worksheet excelSheet = excelBook.Sheets[nom] as Microsoft.Office.Interop.Excel.Worksheet;
            // Microsoft.Office.Interop.Excel.Worksheet ws = CType(excelBook.Worksheets.Item(1), Microsoft.Office.Interop.Excel.Worksheet);
            //excelSheet.Columns("A:A").SpecialCells(XlCellType.xlCellTypeBlanks).EntireRow.Delete
            //excelSheet.Rows("1:1").SpecialCells(XlCellType.xlCellTypeBlanks).EntireColumn.Delete
            if (excelSheet == null)
            {
                await AvisaYCerrateVosSolo("No hay ningun libro disponible", "", 1);
                //return;
            }

            Microsoft.Office.Interop.Excel.Range range = excelSheet.get_Range("A1", System.Reflection.Missing.Value);

            var yourValue = range.Text;

            Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

            string strCellData = "";
            double douCellData;
            int rowCnt = 0;
            int colCnt = 0;
            int filainicio = ComienzoFilaImportar; //es el valor que tiene el NumericUpDown
            //excelRange.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeBlanks).Value = String.Empty; //a todas las celdas en blanco les asigno un string vacio

            //System.Data.DataTable dt = new System.Data.DataTable();
            if (DatosConEncabezados)
            {
                #region +
                bool continua = true;
                while (continua)
                {
                    #region +
                    int colvacias = 0;
                    #region Verificando que toda la fila no este vacia
                    try
                    {
                        for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                        {
                            var jjj = (excelRange.Cells[filainicio, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            if (jjj == null)
                                //string adf = "A1:B5";

                                colvacias++;

                        }
                    }
                    catch (Exception) //si cae aqui es pq estoy tratando de leer un entero como string.
                    {
                        var strColumn = (excelRange.Cells[filainicio, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                        if ((excelRange.Cells[filainicio, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2.ToString() == null)
                        {
                            colvacias++;
                        }
                    }
                    if (colvacias == excelRange.Columns.Count) //si todas las columnas estan vacias, q pase a la siguiente.
                    {
                        Message = "Fila vacia, ignorada... " + filainicio;
                        await Task.Delay(1);
                        filainicio++;
                        continue;
                    }
                    #endregion

                    //necesitamos tener reflejados en el ds el total de columnas que posee el excel. Si llego hasta aqui, es pq alguna columna no esta vacia, entonces las demas se rellenaran con columna#
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        string strColumn = "";
                        var strColum = (excelRange.Cells[filainicio, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        if (strColum != null)
                            strColumn = strColum.ToString();

                        if (!string.IsNullOrEmpty(strColumn))
                        {
                            if (!strColumn.All(char.IsLetter))
                                strColumn = "COLUMNA " + colCnt;
                            dtt.Columns.Add(strColumn.Trim(), typeof(string));
                            continua = false;
                        }
                        else
                        {
                            strColumn = "COLUMNA " + colCnt;
                            dtt.Columns.Add(strColumn.Trim(), typeof(string));
                            continua = false;
                        }
                    }
                    filainicio++;
                    #endregion
                }
                #endregion
            }
            else //si los datos no contienen encabezados. Le ponemos uno generico
            {
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "COLUMNA " + colCnt;
                    dtt.Columns.Add(strColumn.Trim(), typeof(string));
                }
                //filainicio++;
            }
            Message = "Cargando catalogo de cuentas... Iniciando reconocimiento de caracteres... Espere un momento por favor. El proceso puede demorar, pero depende de la capacidad de su computador.";
            await Task.Delay(1);

            for (rowCnt = filainicio; rowCnt <= excelRange.Rows.Count; rowCnt++)
            {
                //if (rowCnt == 442) 
                //{ int i = 12; }

                #region +
                string strData = "";
                int vacio = 0;
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    #region +
                    try
                    {
                        var strCellDataa = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        if (strCellDataa == null)
                        {
                            strData += string.Empty + "|";
                            vacio += 1;
                        }
                        else
                        {
                            strCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                            strData += strCellData + "|";
                            if (String.IsNullOrEmpty(strCellData))
                                vacio += 1;
                        }
                    }
                    catch (Exception)
                    {
                        if ((excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2 == null)
                        {
                            vacio += 1;
                        }
                        else
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                            if (String.IsNullOrEmpty(douCellData.ToString()))
                                vacio += 1;
                        }
                    }
                    #endregion

                }
                //if (vacio <= 1 && strData != null) //excelRange.Columns.Count
                if (vacio < excelRange.Columns.Count && strData != null)
                {
                    strData = strData.Remove(strData.Length - 1, 1);
                    string[] datax = strData.Split('|');
                    //if (!(datax == null || datax[0] == null || datax[1] == null))
                    if (datax != null || datax.Length != 0)
                    {
                        dtt.Rows.Add(datax);
                        //dtt.Rows.Add(strData.Split('|'));
                        //await cuenteUno();

                        Message = " Filas agregadas:  " + rowCnt + " de  " + excelRange.Rows.Count;
                        await Task.Delay(1);
                    }
                    else
                    {
                        Message = " Fila ignorada...  " + rowCnt;
                        //await dlg.ShowMessageAsync(this, "valor de arreglo \n" + datax[0], ""+datax[1]);
                    }
                }
                else
                {
                    //await cuenteUno();
                    await Task.Delay(1);
                    Message = "Fila vacia ignorada...";
                }

                #endregion

            }
            //excelSheet2 = null;
            //excelSheet = null;
            excelBook.Close(true, Type.Missing, Type.Missing);
            //excelBook.Close(true, null, null);

            excelApp.Application.Quit();
            excelApp.Quit();
            return dtt;
        }

        public class SiEsArchivoTxT
        {

            //Message="Analizando archivo txt...";
            public static DataTable DataTableDesdeArchivoTexto(string nombreArchivo, char delimitador)
            {
                if (string.IsNullOrEmpty(delimitador.ToString()))
                    delimitador = '\t';

                DataTable result;

                string[] LineArray = File.ReadAllLines(nombreArchivo);

                //result = FormDataTable(LineArray, delimitador);
                result = otraForma(nombreArchivo, delimitador);

                return result;
            }

            private static DataTable otraForma(string arreglo, char delimitador)
            {
                var table = new DataTable();

                var fileContents = File.ReadAllLines(arreglo);

                //var splitFileContents = (from f in fileContents select f.Split('\n')).ToArray();
                var splitFileContents = (from f in fileContents select f.Split(delimitador)).ToArray();

                int maxLength = (from s in splitFileContents select s.Count()).Max();

                for (int i = 0; i < maxLength; i++)
                {
                    table.Columns.Add();
                }

                foreach (var line in splitFileContents)
                {
                    DataRow row = table.NewRow();
                    row.ItemArray = (object[])line;
                    table.Rows.Add(row);
                }
                return table;
            }

            private static DataTable FormDataTable(string[] LineArray, char delimiter)
            {
                //bool IsHeaderSet = false;

                DataTable dtb = new DataTable();

                AgregarColumnasATabla(LineArray, delimiter, ref dtb);

                AgregarFilasATabla(LineArray, delimiter, ref dtb);

                return dtb;
            }


            private static void AgregarFilasATabla(string[] valueCollection, char delimiter, ref DataTable dtb)
            {

                for (int i = 1; i < valueCollection.Length; i++)
                {
                    string[] values = valueCollection[i].Split(delimiter);

                    DataRow dr = dtb.NewRow();

                    for (int j = 0; j < values.Length; j++)
                    {
                        dr[j] = values[j];
                    }

                    dtb.Rows.Add(dr);
                }
            }


            private static void AgregarColumnasATabla(string[] columnCollection, char delimiter, ref DataTable dtb)
            {
                string[] columns = columnCollection[0].Split(delimiter);

                foreach (string columnName in columns)
                {
                    DataColumn dc = new DataColumn(columnName, typeof(string));
                    dtb.Columns.Add(dc);
                }

            }

        }

        public static DataTable SiEsArchivoCSV(string nombreArchivo)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(nombreArchivo))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }


            return dt;
        }

        private async Task cuenteUno()
        {
            await Task.Delay(1);
        }

        public async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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

        #region Inicio comandos

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
            accesibilidadBotones = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            //Messenger.Default.Unregister<int>(this, tokenRecepcionCierrePreView);
            accesibilidadWindow = true;
            accesibilidadBotones = true;
        }

        #endregion fin  de clase
    }

    public class GridItem
    {
        public string Name { get; set; }
        public CompanyItem Company { get; set; }
        public IEnumerable<CompanyItem> CompanyList { get; set; }

        public ClaseCuentaModelo descripcionccuentas { get; set; }
        public IEnumerable<ClaseCuentaModelo> ListaClaseCuenta { get; set; }
    }

    public class CompanyItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString() { return Name; }
    }


}