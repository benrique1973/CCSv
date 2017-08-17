using CapaDatos;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTWpf.SGPtmvvm.Modales.ImportarArchivos
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ImportarArchivosGeneralesViewModel : ViewModeloBase
    {
        /// <summary>
        /// Initializes a new instance of the ImportarArchivosGeneralesViewModel class.
        /// </summary>
        /// 
        public ObservableCollection<ElementoModelo> listaElementos { get; set; }
        public List<clasesbalance> ListadoClaseBalance { get; set; }
        public List<periodo>       ListaPeriodoBalance { get; set; }
        public ObservableCollection<ClaseCuentaModelo> listaClaseCuenta { get; set; }
        public List<detallebalance> ListitaDetalleBalance { get; set; } // lista para insertar en la base
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

        private bool _canExecute;
        private DialogCoordinator dlg;
        public SGPTEntidades db = new SGPTEntidades();

        System.Data.DataTable dt = new System.Data.DataTable();
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }

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




        private Visibility _HabilitarDatagridCatalogoCuentas;
        public Visibility HabilitarDatagridCatalogoCuentas
        {
            get { return _HabilitarDatagridCatalogoCuentas; }
            set { _HabilitarDatagridCatalogoCuentas = value; RaisePropertyChanged("HabilitarDatagridCatalogoCuentas"); }
        }

        private Visibility _HabilitarDatagridBalances;
        public Visibility HabilitarDatagridBalances
        {
            get { return _HabilitarDatagridBalances; }
            set { _HabilitarDatagridBalances = value; RaisePropertyChanged("HabilitarDatagridBalances"); }
        }

        private Visibility _HabilitarDatagridGeneral;
        public Visibility HabilitarDatagridGeneral
        {
            get { return _HabilitarDatagridGeneral; }
            set { _HabilitarDatagridGeneral = value; RaisePropertyChanged("HabilitarDatagridGeneral"); }
        }

        #region Habilitadores Barra control de botones
        private bool _HabilitarBarraControlBotones;
        public bool HabilitarBarraControlBotones
        {
            get { return _HabilitarBarraControlBotones; }
            set { _HabilitarBarraControlBotones = value; RaisePropertyChanged("HabilitarBarraControlBotones"); }
        }

        private bool _HabilitarcmdCancelar;
        public bool HabilitarcmdCancelar
        {
            get { return _HabilitarcmdCancelar; }
            set { _HabilitarcmdCancelar = value; RaisePropertyChanged("HabilitarcmdCancelar"); }
        }

        private bool _HabilitarcmdAtras;
        public bool HabilitarcmdAtras
        {
            get { return _HabilitarcmdAtras; }
            set { _HabilitarcmdAtras = value; RaisePropertyChanged("HabilitarcmdAtras"); }
        }

        private bool _HabilitarcmdAdelante;
        public bool HabilitarcmdAdelante
        {
            get { return _HabilitarcmdAdelante; }
            set { _HabilitarcmdAdelante = value; RaisePropertyChanged("HabilitarcmdAdelante"); }
        }

        private bool _HabilitarcmdFinalizar;
        public bool HabilitarcmdFinalizar
        {
            get { return _HabilitarcmdFinalizar; }
            set { _HabilitarcmdFinalizar = value; RaisePropertyChanged("HabilitarcmdFinalizar"); }
        } 
        #endregion

        private int _FocoPestañaSeleccionada;
        public int FocoPestañaSeleccionada
        {
            get { return _FocoPestañaSeleccionada; }
            set
            {
                _FocoPestañaSeleccionada = value;
                RaisePropertyChanged("FocoPestañaSeleccionada");
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

        private string _QueEstaImportandoElQue;
        public string QueEstaImportandoElQue
        {
            get { return _QueEstaImportandoElQue; }
            set { _QueEstaImportandoElQue = value; RaisePropertyChanged("QueEstaImportandoElQue"); }
        }

        //readonly ObservableCollection<CompanyItem> companies;
        public ImportarArchivosGeneralesViewModel()
        {
            Messenger.Default.Register<CargarArchivosMensajeModal>(this, "ImportarArchivos", (recepcionOrdenImportacion) => this.IniciarProcesoDeImportacion(recepcionOrdenImportacion));
            //Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            dlg = new DialogCoordinator();
            
            #region Pruebas
            //companies = new ObservableCollection<CompanyItem>
            //{
            //new CompanyItem { ID = 1, Name = "Company 1" },
            //new CompanyItem { ID = 2, Name = "Company 2" },
            //new CompanyItem { ID = 3, Name = "Company 3" }
            //};

            //GridItems = new ObservableCollection<GridItem> {
            //    new GridItem { Name = "Jim", Company = companies[2], CompanyList = companies},
            //    new GridItem { Name = "Juan", Company = companies[1], CompanyList = companies},
            //    new GridItem { Name = "Marco", Company = companies[0], CompanyList = companies}
            //};




            //companies = new ObservableCollection<CompanyItem>
            //    {
            //    new CompanyItem { ID = 1, Name = "Company 1" },
            //    new CompanyItem { ID = 2, Name = "Company 2" },
            //    new CompanyItem { ID = 3, Name = "Company 3" }
            //    };
            ////ObservableCollection<CompanyItem> companies = new ObservableCollection<CompanyItem>();
            //GridItems = new ObservableCollection<GridItem> {
            //        new GridItem { Name = "Jim", Company = companies[2], CompanyList = companies, descripcionccuentas=listaClaseCuenta[1], ListaClaseCuenta=listaClaseCuenta},
            //        new GridItem { Name = "Juan", Company = companies[1], CompanyList = companies, descripcionccuentas=listaClaseCuenta[2], ListaClaseCuenta=listaClaseCuenta},
            //        new GridItem { Name = "Marco", Company = companies[0], CompanyList = companies, descripcionccuentas=listaClaseCuenta[3], ListaClaseCuenta=listaClaseCuenta}
            //    }; 
            #endregion
            
            HabilitarDatagridCatalogoCuentas = Visibility.Hidden;
            HabilitarDatagridBalances = Visibility.Hidden;
            HabilitarcmbClaseBalance = false;
            HabilitarcmbPeriodosBalance = false;

            HabilitarDatagridGeneral = Visibility.Hidden;
            _canExecute = true;
            QueEstaImportandoElQue = ""; //texto del tab3
            DatosConEncabezados = true; //checbox
            ComienzoFilaImportar = 1; //spinner
            lista = new ObservableCollection<CatalogoCuentasModelo>();
            this.inicializadoresBasicos();
            HayCatalogoGeneradoAPartirBalance = false;
        }

        private async void IniciarProcesoDeImportacion(CargarArchivosMensajeModal msj) //aqui cae el mensaje del solicitante
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            tokenAUsar = msj.TokenAUtilizar;
            MensajeModalRecibido = msj;
            //actualizarLista(); //no aplica, pq no tenemos aun el catalogo que tiene que ser importado
            //accesibilidadWindow = true;
            //inicializacionTerminada();
            Messenger.Default.Unregister<CargarArchivosMensajeModal>(this, "ImportarArchivos");

            QueEstaImportandoElQue = "Se esta importando: " + msj.TipoArchivoACargar;
            if (msj.TipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
            {
                HabilitarcmbClaseBalance = false;
                HabilitarcmbPeriodosBalance = false;
                HabilitarDatagridCatalogoCuentas = Visibility.Visible;
                HabilitarDatagridBalances = Visibility.Hidden;
                HabilitardpickFechaBalance=false;
            }
                

            if (msj.TipoArchivoACargar == TipoArchivoCargar.Balance)
            {
                HabilitarcmbClaseBalance = true;
                HabilitarcmbPeriodosBalance = true;
                await AvisaYCerrateVosSolo("Para empezar la carga del Balance"+Environment.NewLine+"Es necesario que seleccione el tipo de Balance del listado disponible en el Paso 1","",3);
                HabilitarDatagridBalances = Visibility.Visible;
                HabilitarDatagridCatalogoCuentas = Visibility.Hidden;
                HabilitardpickFechaBalance=true;
                string fechabalance="31/12/"+DateTime.Now.Year.ToString();
                FechaBalance=DateTime.Parse(fechabalance);
            }
                
            //if (msj.TipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
            //{
            //    await AvisaYCerrateVosSolo("Quiere importar catalogo", "", 1);
            //}
            //else
            //{
            //    await AvisaYCerrateVosSolo("El pedido es: " + msj.TipoArchivoACargar, "", 1);
            //}
            Mouse.OverrideCursor = null;
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
            set { _HojaCalculoUsada = value; RaisePropertyChanged("HojaCalculoUsada"); }
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

        public async void cmdPestaña3()
        {
            FocoPestañaSeleccionada = 3;

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
                                MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "No tiene registrado el catalogo de cuentas para este encargo." + Environment.NewLine + "El sistema intentara generar uno a partir del balance ingresado" + Environment.NewLine + "Cliente: " + currentEncargo.razonsocialcliente + Environment.NewLine + "Encargo seleccionado: " + currentEncargo.descripcionTipoAuditoria + " " + currentEncargo.fechainiperauditencargo + "-" + currentEncargo.fechafinperauditencargo + Environment.NewLine, "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                                if (resultk == MessageDialogResult.Affirmative)
                                {
                                    HabilitarDatagridBalances = Visibility.Hidden;
                                    HabilitarDatagridCatalogoCuentas = Visibility.Visible;
                                    HabilitarBarraControlBotones = true;
                                    bool reconocimientoCorrecto = await this.ReconocerCatalogoCuentas();
                                    if (reconocimientoCorrecto)
                                    {
                                        HayCatalogoGeneradoAPartirBalance = true;
                                        await AvisaYCerrateVosSolo("Guarde el catalogo generado. Y despues guarde el Balance", "", 1);
                                    }
                                }

                            }
                        }
                        #endregion
                        HabilitarBarraControlBotones = true;
                        HabilitarcmdFinalizar = true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error en el reconocimiento del archivo importado. " + e);
                    } 
                    #endregion 
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("No ha iniciado la importacion de ningun archivo...", "Importacion no iniciada.", 1);
                HabilitarBarraControlBotones = true;
                HabilitarcmdFinalizar = false;
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
                    await dlg.ShowMessageAsync(this,"El codigo contable " + codcont1 + "Esta duplicado." + Environment.NewLine + "Regrese al paso 1 y corrija el codigo", "");
                        FocoPestañaSeleccionada=0;
                    return false;
                }
             }
            
            return true;
        }

        public async void ReconocerBalance()
        {
            //bool puedeContinuar = false;
            
            //decimal ah,bh;

            //foreach (DataRowView a in dtGrd)
            //{
                //string cv=(a.Row.ItemArray[2].ToString()).Trim();
                //bool af = decimal.TryParse(cv, out ah);

                //string dv=(a.Row.ItemArray[3].ToString()).Trim();
                //bool bf = decimal.TryParse(dv, out ah);
                
                //string ev = (a.Row.ItemArray[4].ToString()).Trim();
                //bool cf = decimal.TryParse(ev,out ah);

                //string fv=(a.Row.ItemArray[5].ToString()).Trim();
                //bool df = decimal.TryParse(fv,out ah);
            //}

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
                    QueEstaImportandoElQue = "Espere... reconociendo las cuentas del balance una a una. " + h;
                    await Task.Delay(1);
                    //if (h == 219)
                    //    QueEstaImportandoElQue = "Espere";
                    DetalleBalanceModelo dl = new DetalleBalanceModelo();
                    dl.idCorrelativo = h;

                    
                    var unf = (dr.Row.ItemArray[0].ToString()).Trim();
                    if (!string.IsNullOrEmpty(unf))
                    {
                        dl.codigoccdb = (dr.Row.ItemArray[0].ToString()).Trim();
                        var pl=listaCatalogoGuardado.Where(x => x.codigocc.Trim() == dl.codigoccdb).SingleOrDefault();
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
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en el reconocimiento del balance. El balance esta corrupto " + e);
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
            Mouse.OverrideCursor = Cursors.Wait;
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
                                            await AvisaYCerrateVosSolo("Se ha encontrado mas de un separador en el codigo contable. El catalogo esta corrupto", "Repare las incongruencias y vuelva a intentarlo", 1);
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
                            await AvisaYCerrateVosSolo("Se han encontrado incongruencias en los codigos de las cuentas.", "Asegurese de haber eliminado los encabezados extras en el Paso 1", 4);
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
            Mouse.OverrideCursor = null;

            if (puedeContinuar) //se desactiva cuando en los codigos de las cuentas se encuentran mas de un separador de numeros
            {
                #region +
                if (!string.IsNullOrEmpty(separador) && separador.Length == 1)
                { await AvisaYCerrateVosSolo("Cada separacion en Los codigos de las cuentas, sera tomado como un digito.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [2], Cuentas [3], Sub-Cuentas [4], Sub-sub-cuentas [5], etc.", 4); }
                else { await AvisaYCerrateVosSolo("Los codigos de las cuentas contables seran separados" + Environment.NewLine + "Segun la configuracion de digitos en el sistema contable.", "La separacion quedara asi:" + Environment.NewLine + "Elementos [1], Rubros [" + digitosRubros + "], Cuentas [" + digitosCuentas + "]," + Environment.NewLine + "Sub-Cuentas [" + digitosSubCuenta + "], Sub-sub-cuentas [" + digitosSubSubCuenta + "], Sub-sub-sub-cuentas [" + digitosSubSubSubCuenta + "]" + Environment.NewLine + "El exceso sera ignorado.", 5); }

                //lista = new ObservableCollection<CatalogoCuentasModelo>(CatalogoCuentasModelo.GetAllImportacion(currentEncargo.idencargo));
                //currentSistemaContable.
                int idimaginario = 0;
                //var cuantosRegistrosHayEnLaBase;
                using (db = new SGPTEntidades())
                {
                    //var cuantosRegistrosHayEnLaBase = db.Database.ExecuteSqlCommand(
                    //                    "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 1)");
                    ////"SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 1, true);");
                    //idimaginario = cuantosRegistrosHayEnLaBase;

                    //catalogocuenta existeCatalogoParaEsteSistemaContable = new catalogocuenta();
                    //try
                    //{
                    //    existeCatalogoParaEsteSistemaContable = (from c in db.catalogocuentas where c.idsc == currentSistemaContable.idsc select c).First();
                    //}
                    //catch (Exception)
                    //{
                    //    existeCatalogoParaEsteSistemaContable = new catalogocuenta();
                    //}
                    //if (existeCatalogoParaEsteSistemaContable.idcc > 0 && lista != null)
                    //{
                    //    idimaginario = existeCatalogoParaEsteSistemaContable.idcc; //le ponemos el mismo id del primer elmento encontrado, ya que el catalogo viejo debe eliminarse
                    //}
                    //else
                    //{
                    idimaginario = db.catalogocuentas.Max(t => t.idcc);
                    //if (idimaginario < 0 || idimaginario == null)
                    if (idimaginario < 0 )

                        idimaginario = 0;

                    string fd = "ALTER SEQUENCE sgpt.catalogocuentas_idcc_seq RESTART WITH " + (idimaginario + 1) + ";";
                    var reiniciarIdPorDefectoDePostgreSql = db.Database.ExecuteSqlCommand(fd);
                    db.SaveChanges();
                    //}
                    //idimaginario++; //le sumo uno, pq la cochinada del restart lo pone en un valor y postgres le suma 1 no se por que.
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
                QueEstaImportandoElQue = "Espere... reconociendo las cuentas una a una.";
                await Task.Delay(1);
                Mouse.OverrideCursor = Cursors.Wait;
                foreach (DataRowView dr in dtGrd)
                {
                    #region +
                    idcorrelativo++;
                    idimaginario++;
                    decimal drr = dtGrd.Count / 2;
                    if (idcorrelativo == Math.Round(drr))
                    {
                        QueEstaImportandoElQue = "Espere... reconociendo las cuentas una a una. Fila: " + idcorrelativo;
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
                                    cat.idcc = idimaginario;
                                    cat.idCorrelativo = idcorrelativo;

                                    int cod = int.Parse(col11[0]);
                                    var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                    ClaseCuentaModelo cla = new ClaseCuentaModelo();


                                    if (col11.Count() == 1) //Elemento
                                    {
                                        cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                        codpadreelemento = idimaginario;
                                    }
                                    else if (col11.Count() == 2)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                    {
                                        cla = listaClaseCuenta2[2];
                                        //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                        cat.catidcc = codpadreelemento;//pad.idcc;
                                        codpadrerubro = idimaginario;
                                    }
                                    else if (col11.Count() == 3)//currentSistemaContable.digitoscuentamayorsc)
                                    {
                                        cla = listaClaseCuenta2[3];
                                        cat.catidcc = codpadrerubro; //idimaginario - 1;
                                        codpadrecuenta = idimaginario;
                                    }
                                    else if (col11.Count() == 4)//currentSistemaContable.digitoscuentamayorsc + 1)
                                    {
                                        cla = listaClaseCuenta2[4];
                                        cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                        codpadresubcuenta = idimaginario;
                                    }
                                    else if (col11.Count() == 5)//currentSistemaContable.digitoscuentamayorsc + 2)
                                    {
                                        cla = listaClaseCuenta2[5];
                                        cat.catidcc = codpadresubcuenta;//idimaginario - 1;
                                        codpadresubsubcuenta = idimaginario;
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
                                    if (elem.descripcion == "Activo")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Pasivo" || elem.descripcion == "Patrimonio")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Costos y gastos")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Ingresos o ventas")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor") Cuentas de orden
                                    if (elem.descripcion == "Cuentas de orden")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0];
                                    if (elem.descripcion == "Cuentas de orden por contra")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1];
                                    cat.listaTipoSaldo = cat.listaTipoSaldoX;

                                    //Vamos a quemar las cuentas de resultados deudoras
                                    if (cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "COSTO DE VENTA" || cat.descripcioncc.ToUpper().Trim() == "COSTO DE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE VENTA" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE ADMINISTRACION" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE ADMON" || cat.descripcioncc.ToUpper().Trim() == "GASTOS FINANCIEROS" || cat.descripcioncc.ToUpper().Trim() == "OTROS GASTOS")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[2];

                                    //vamos a quemar las cuentas de resultados acreedoras
                                    //if (cat.descripcioncc.ToUpper().Trim() == "VENTAS" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "PRODUCTOS FINANCIEROS" || cat.descripcioncc.ToUpper().Trim() == "OTROS PRODUCTOS")
                                    if (cat.descripcioncc.ToUpper().Trim().Contains("VENTAS") || cat.descripcioncc.ToUpper().Trim().Contains("DEVOLUCIONES SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("REBAJAS SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("DESCUENTOS SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("PRODUCTOS FINANCIEROS") || cat.descripcioncc.ToUpper().Trim().Contains("OTROS PRODUCTOS"))
                                        cat.tipoSaldo = cat.listaTipoSaldoX[3];

                                    //            TipoSaldo{Id="D", tiposaldo="Deudor"},
                                    //new         TipoSaldo{Id="A", tiposaldo="Acreedor"},
                                    //new         TipoSaldo{Id="RD", tiposaldo="Resultado deudor"},
                                    //new         TipoSaldo{Id="RA", tiposaldo="Resultado acreedor"} 
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
                                    cat.idcc = idimaginario;
                                    cat.idCorrelativo = idcorrelativo;

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
                                        codpadreelemento = idimaginario;
                                    }
                                    else if (colcount == 2)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                    {
                                        cla = listaClaseCuenta2[2];
                                        //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                        cat.catidcc = codpadreelemento;//pad.idcc;
                                        codpadrerubro = idimaginario;
                                    }
                                    else if (colcount == 3)//currentSistemaContable.digitoscuentamayorsc)
                                    {
                                        cla = listaClaseCuenta2[3];
                                        cat.catidcc = codpadrerubro; //idimaginario - 1;
                                        codpadrecuenta = idimaginario;
                                    }
                                    else if (colcount == 4)//currentSistemaContable.digitoscuentamayorsc + 1)
                                    {
                                        cla = listaClaseCuenta2[4];
                                        cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                        codpadresubcuenta = idimaginario;
                                    }
                                    else if (colcount == 5)//currentSistemaContable.digitoscuentamayorsc + 2)
                                    {
                                        cla = listaClaseCuenta2[5];
                                        cat.catidcc = codpadresubcuenta;//idimaginario - 1;
                                        codpadresubsubcuenta = idimaginario;
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
                                    if (elem.descripcion == "Activo")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Pasivo" || elem.descripcion == "Patrimonio")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Costos y gastos")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Ingresos o ventas")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor") Cuentas de orden
                                    if (elem.descripcion == "Cuentas de orden")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0];
                                    if (elem.descripcion == "Cuentas de orden por contra")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1];
                                    cat.listaTipoSaldo = cat.listaTipoSaldoX;

                                    //Vamos a quemar las cuentas de resultados deudoras
                                    if (cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "COSTO DE VENTA" || cat.descripcioncc.ToUpper().Trim() == "COSTO DE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE VENTA" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE ADMINISTRACION" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE ADMON" || cat.descripcioncc.ToUpper().Trim() == "GASTOS FINANCIEROS" || cat.descripcioncc.ToUpper().Trim() == "OTROS GASTOS")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[2];

                                    //vamos a quemar las cuentas de resultados acreedoras
                                    //if (cat.descripcioncc.ToUpper().Trim() == "VENTAS" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "PRODUCTOS FINANCIEROS" || cat.descripcioncc.ToUpper().Trim() == "OTROS PRODUCTOS")
                                    if (cat.descripcioncc.ToUpper().Trim().Contains("VENTAS") || cat.descripcioncc.ToUpper().Trim().Contains("DEVOLUCIONES SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("REBAJAS SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("DESCUENTOS SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("PRODUCTOS FINANCIEROS") || cat.descripcioncc.ToUpper().Trim().Contains("OTROS PRODUCTOS"))
                                        cat.tipoSaldo = cat.listaTipoSaldoX[3];

                                    //            TipoSaldo{Id="D", tiposaldo="Deudor"},
                                    //new         TipoSaldo{Id="A", tiposaldo="Acreedor"},
                                    //new         TipoSaldo{Id="RD", tiposaldo="Resultado deudor"},
                                    //new         TipoSaldo{Id="RA", tiposaldo="Resultado acreedor"} 
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
                                    cat.idcc = idimaginario;
                                    cat.idCorrelativo = idcorrelativo;

                                    int cod = int.Parse(col1.Substring(0, 1));
                                    var elem = listaElementos2.Find(x => x.codigoelemento == cod);
                                    ClaseCuentaModelo cla = new ClaseCuentaModelo();


                                    if (col1.Count() == digitosElementos) //Elemento
                                    {
                                        cla = listaClaseCuenta2[1];//listaClaseCuenta2.Find(x => x.id == 1);
                                        codpadreelemento = idimaginario;
                                    }
                                    else if (col1.Count() == digitosRubros)//currentSistemaContable.digitosrubroscontablessc)  //Rubro
                                    {
                                        cla = listaClaseCuenta2[2];
                                        //var pad = (from a in lista where a.codigocc == col11[1] select a).SingleOrDefault();
                                        cat.catidcc = codpadreelemento;//pad.idcc;
                                        codpadrerubro = idimaginario;
                                    }
                                    else if (col1.Count() == digitosCuentas)//currentSistemaContable.digitoscuentamayorsc)
                                    {
                                        cla = listaClaseCuenta2[3];
                                        cat.catidcc = codpadrerubro; //idimaginario - 1;
                                        codpadrecuenta = idimaginario;
                                    }
                                    else if (col1.Count() == digitosSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 1)
                                    {
                                        cla = listaClaseCuenta2[4];
                                        cat.catidcc = codpadrecuenta;//idimaginario - 1;
                                        codpadresubcuenta = idimaginario;
                                    }
                                    else if (col1.Count() == digitosSubSubCuenta)//currentSistemaContable.digitoscuentamayorsc + 2)
                                    {
                                        cla = listaClaseCuenta2[5];
                                        cat.catidcc = codpadresubcuenta;
                                        codpadresubsubcuenta = idimaginario;
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
                                    if (elem.descripcion == "Activo")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Pasivo" || elem.descripcion == "Patrimonio")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Costos y gastos")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor")
                                    if (elem.descripcion == "Ingresos o ventas")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1]; //cat.listaTipoSaldoX.Find(x=>x.tiposaldo=="Deudor") Cuentas de orden
                                    if (elem.descripcion == "Cuentas de orden")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[0];
                                    if (elem.descripcion == "Cuentas de orden por contra")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[1];
                                    cat.listaTipoSaldo = cat.listaTipoSaldoX;

                                    //Vamos a quemar las cuentas de resultados deudoras
                                    if (cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE VENTA" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "COSTO DE VENTA" || cat.descripcioncc.ToUpper().Trim() == "COSTO DE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE VENTA" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE VENTAS" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE ADMINISTRACION" || cat.descripcioncc.ToUpper().Trim() == "GASTOS DE ADMON" || cat.descripcioncc.ToUpper().Trim() == "GASTOS FINANCIEROS" || cat.descripcioncc.ToUpper().Trim() == "OTROS GASTOS")
                                        cat.tipoSaldo = cat.listaTipoSaldoX[2];

                                    //vamos a quemar las cuentas de resultados acreedoras
                                    //if (cat.descripcioncc.ToUpper().Trim() == "VENTAS" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "DEVOLUCIONES SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "REBAJAS SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE COMPRA" || cat.descripcioncc.ToUpper().Trim() == "DESCUENTOS SOBRE COMPRAS" || cat.descripcioncc.ToUpper().Trim() == "PRODUCTOS FINANCIEROS" || cat.descripcioncc.ToUpper().Trim() == "OTROS PRODUCTOS")
                                    if (cat.descripcioncc.ToUpper().Trim().Contains("VENTAS") || cat.descripcioncc.ToUpper().Trim().Contains("DEVOLUCIONES SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("REBAJAS SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("DESCUENTOS SOBRE COMPRA") || cat.descripcioncc.ToUpper().Trim().Contains("PRODUCTOS FINANCIEROS") || cat.descripcioncc.ToUpper().Trim().Contains("OTROS PRODUCTOS"))
                                        cat.tipoSaldo = cat.listaTipoSaldoX[3];

                                    //            TipoSaldo{Id="D", tiposaldo="Deudor"},
                                    //new         TipoSaldo{Id="A", tiposaldo="Acreedor"},
                                    //new         TipoSaldo{Id="RD", tiposaldo="Resultado deudor"},
                                    //new         TipoSaldo{Id="RA", tiposaldo="Resultado acreedor"} 
                                    #endregion
                                }
                                else
                                {
                                    await AvisaYCerrateVosSolo("Los codigos de las cuentas no fueron soportados en esta version 1.0 educativa.", "Sugerencia: Realice puntuaciones para dividir los elementos y rubros de las cuentas", 4);
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
                Mouse.OverrideCursor = null;
                RaisePropertyChanged("lista");
                if (lista.Count() > 0)
                {
                    QueEstaImportandoElQue = "Ordenando las cuentas de forma ascendente... Espere...";
                    await Task.Delay(1);
                    var lixta = await this.OrdenarImportacion(lista.ToList());
                    QueEstaImportandoElQue = "Finalizado éxitosamente. Guarde la importacion antes de salir.";
                    await Task.Delay(1);
                    Mouse.OverrideCursor = null;
                    return true;
                }
                else
                {
                    QueEstaImportandoElQue = "Lista vacia... accion no permitida.";
                    await Task.Delay(1);
                    return false;
                }
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("No fue posible continuar. Existen incongruencias.","Revise el archivo e intentelo nuevamente.",2);
                return false;
            }
            #endregion 
        }

        public async Task<List<CatalogoCuentasModelo>> OrdenarImportacion(List<CatalogoCuentasModelo> lista)
        {
            try
            {

                //SistemaContableModelo scm = SistemaContableModelo.GetRegistroByIdEncargo(idEncargo);
                using (db = new SGPTEntidades())
                {
                    var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)currentSistemaContable.idsc));
                    var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

                    //var listaElementos2 = listaElementos.ToList();
                    //var listaClaseCuenta2 = listaClaseCuenta.ToList();

                    if (lista.Count == 0)
                    {
                        return new List<CatalogoCuentasModelo>();
                    }
                    else
                    {
                        int i = 1;
                        //var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)scm.idsc));
                        //var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());
                        Mouse.OverrideCursor = Cursors.Wait;
                        foreach (CatalogoCuentasModelo item in lista)
                        {
                            //item.idCorrelativo = i;
                            i++;
                            //decimal drr = dtGrd.Count / 4;
                            //if (i== Math.Round(drr))
                            //{
                                //QueEstaImportandoElQue = "Espere... Buscando los padres de las cuentas: " + i;
                                //await Task.Delay(1);
                            //}
                            
                            item.guardadoBase = false;
                            item.IsSelected = false;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                            if (item.catidcc != null && item.catidcc>0)
                            {
                                QueEstaImportandoElQue = "Espere... Buscando los padres de las cuentas: " + item.catidcc+" Fila: " + i;
                                await Task.Delay(1);

                                item.CatalogoCuentasModeloPadre = lista.Single(d => d.idcc == item.catidcc);
                                item.nombrePadre = item.CatalogoCuentasModeloPadre.descripcioncc;
                                item.ordenccPadre = item.CatalogoCuentasModeloPadre.ordencc;
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                                item.codigoContablePadre = item.CatalogoCuentasModeloPadre.codigocc;
                            }

                            item.elementoModeloCC = listaElementos.Single(p => p.id == item.idelementos);

                            //item.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)item.idccuentas);
                            item.claseCuentaModeloCC = listaClaseCuenta.Single(z => z.id == item.idccuentas);

                            item.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(item.tiposaldocc);
                            item.nombreTipoSaldoCuenta = item.tipoSaldoCuentaModelo.descripcionTSCuenta;

                        }

                        QueEstaImportandoElQue = "Finalizado... Ordenando las cuentas ascendentemente... Espere...";
                        await Task.Delay(1);
                        Mouse.OverrideCursor = null;
                        Mouse.OverrideCursor = Cursors.Wait;
                        return await this.RegeneraOrdenSubRegistrosImportacionX(lista);
                        //Mouse.OverrideCursor = null;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista de importacion" + e.Message + " fuente " + e.Source);
                var listaa = new ObservableCollection<CatalogoCuentasModelo>();
                return listaa.ToList();
            }
        }

        #region Ordenar Buscando todos los padres y todos los hijos
        public async Task<List<CatalogoCuentasModelo>> RegeneraOrdenSubRegistrosImportacionX(List<CatalogoCuentasModelo> listaDetalleHerramienta)
        {

            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    //bool guardar = false;
                    decimal contador = 1;
                    int escalarCuenta = 100000;//Sirve para escalar el contador
                    decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<CatalogoCuentasModelo> listaHijos = new ObservableCollection<CatalogoCuentasModelo>();
                    int ubicacion = 0;
                    Mouse.OverrideCursor = Cursors.Wait;
                    QueEstaImportandoElQue = "Estableciendo el orden... Espere...";
                    await Task.Delay(1);
                    int kl = 0;
                    foreach (CatalogoCuentasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        kl++;
                        QueEstaImportandoElQue = "Buscando... estableciendo el Orden: "+kl+"... Espere...";
                        await Task.Delay(1);
                        //guardar = false;
                        if (itemDetalle.catidcc == null)
                        {
                            if (itemDetalle.ordencc != contador * escalarCuenta)
                            {
                                //Se asigna el orden a los principales
                                itemDetalle.ordencc = contador * escalarCuenta;
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                            }
                            contador++;
                        }
                        else
                        {
                            //Se verifica que segun el tipo de procedimiento deba tener hijos o  no
                            if (!MetodosModelo.correccionOrdenCatogo(itemDetalle.nombreClaseCuenta))
                            {
                                if (itemDetalle.catidcc != null)
                                {
                                    itemDetalle.catidcc = null;
                                    itemDetalle.ordenccPadre = null;
                                }
                                if (itemDetalle.ordencc != contador * escalarCuenta)
                                {
                                    //Se asigna el orden a los principales
                                    itemDetalle.ordencc = contador * escalarCuenta;
                                    //itemDetalle.ordenccPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                    itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                }
                                contador++;
                            }
                        }
                    }
                    Mouse.OverrideCursor = null;
                    QueEstaImportandoElQue = "Finalizado... Orden Establecido éxitosamente... Espere...";
                    await Task.Delay(1);

                    //Corrigiendo los sub-procedimientos
                    Mouse.OverrideCursor = Cursors.Wait;
                    int ñ = 0;
                    foreach (CatalogoCuentasModelo item in listaDetalleHerramienta)
                    {
                        ñ++;
                        
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<CatalogoCuentasModelo>(listaDetalleHerramienta.Where(x => x.catidcc == item.idcc));
                        QueEstaImportandoElQue = "Extrayendo lista de hijos... Espere... Fila: "+ñ+"   Hijos encontrados: " + listaHijos.Count();
                        await Task.Delay(1);
                        if (listaHijos.Count > 0)
                        {
                            #region +
                            //Hay hijos
                            QueEstaImportandoElQue = "Reconociendo los hijos encontrados... Espere... Fila: "+ñ;
                            await Task.Delay(1);
                            contador = (decimal)item.ordencc;
                            factor = MetodosModelo.factorPadreCatalogo(item.nombreClaseCuenta);
                            int j = 1;
                            //guardar = false;
                            ubicacion = -1;
                            foreach (CatalogoCuentasModelo hijo in listaHijos)
                            {
                                #region +

                                //Es un hijo
                                ubicacion = listaDetalleHerramienta.IndexOf(hijo);
                                if (ubicacion != -1)
                                {
                                    if (listaDetalleHerramienta[ubicacion].ordencc != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        listaDetalleHerramienta[ubicacion].ordenccPadre = contador;
                                        listaDetalleHerramienta[ubicacion].ordencc = Decimal.Add((decimal)contador, factor * j);
                                        //listaDetalleHerramienta[ubicacion].ordenccPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        listaDetalleHerramienta[ubicacion].ordenDhPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        //CatalogoCuentasModelo.UpdateModeloReodenar(listaDetalleHerramienta[ubicacion]);
                                    }
                                    j++;
                                }
                                #endregion
                            } 
                            #endregion
                        }
                    }
                    Mouse.OverrideCursor = null;
                    return listaDetalleHerramienta.OrderBy(x => x.ordencc).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta.OrderBy(x => x.ordencc).ToList();
                    throw;
                }
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


        private ICommand _MiComanditoPaso3;
        public ICommand MicomanditoPaso3
        {
            get
            {
                return _MiComanditoPaso3 ?? (_MiComanditoPaso3 = new CommandHandler(() => cmdPestaña3(), _canExecute));
            }
        }
        private ICommand _cmdCargarCat_Click;
        public ICommand cmdCargarCat_Click
        {
            get
            {
                return _cmdCargarCat_Click ?? (_cmdCargarCat_Click = new CommandHandler(() => cmdCargarCatalogo(), _canExecute));
            }
        }

        #region Cancelar
        private ICommand _cmdCancelar;
        public ICommand cmdCancelar
        {
            get
            {
                return _cmdCancelar ?? (_cmdCancelar = new CommandHandler(() => MycmdCancelar(), _canExecute));
            }
        }

        private void MycmdCancelar()
        {
            //await AvisaYCerrateVosSolo("Cancelado ", "", 1);

            Messenger.Default.Send<int>(2, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
            //Messenger.Default.Register<Boolean>(this, "TokenImportarArchivo", this.NotificarAlUsuario());

            //private void NotificarAlUsuario(bool result)
            //{
            //    if (result == true)
            //      //se guardo el archivo de importacion correctamente.
            //    else
            //      //Fallo la carga del archivo de importacion. No se guardo nada.
            //}
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
            enviarMensaje();
            CloseWindow();
        }

        public void enviarMensaje()
        {
            //Messenger.Default.Unregister<UsuariosMensajeModal>(this);
            //Creando el mensaje de cierre
            VentanaViewMensajeFin cierre = new VentanaViewMensajeFin();
            cierre.mensaje = -1;
            Messenger.Default.Send<VentanaViewMensajeFin>(cierre);
        } 
        #endregion

        private ICommand _cmdAtras;
        public ICommand cmdAtras
        {
            get
            {
                return _cmdAtras ?? (_cmdAtras = new CommandHandler(() => MycmdAtras(), _canExecute));
            }
        }

        private void MycmdAtras()
        {
            if (FocoPestañaSeleccionada > 0)
                FocoPestañaSeleccionada--;
        }


        private ICommand _cmdAdelante;
        public ICommand cmdAdelante
        {
            get
            {
                return _cmdAdelante ?? (_cmdAdelante = new CommandHandler(() => MycmdAdelante(), _canExecute));
            }
        }

        private void MycmdAdelante()
        {
            //await AvisaYCerrateVosSolo("Adelante", "", 1);
            if (FocoPestañaSeleccionada < 3)
                FocoPestañaSeleccionada++;
            if (FocoPestañaSeleccionada == 3)
                this.cmdPestaña3();
        }

        private ICommand _cmdFinalizar;
        public ICommand cmdFinalizar
        {
            get
            {
                return _cmdFinalizar ?? (_cmdFinalizar = new CommandHandler(() => MycmdFinalizar(), _canExecute));
            }
        }
        #region Comando Salida

        private ICommand _SalirCommand;
        public ICommand SalirCommand
        {
            get
            {
                return _SalirCommand ?? (_SalirCommand = new CommandHandler(() => Salir(), _canExecute));
            }
        }

        private void Salir()
        {
            //Creando el mensaje de cierre
            
            //Messenger.Default.Send(-1, "RecepcionCargaCatalogo");
            Messenger.Default.Send(-1, tokenAUsar);
            CloseWindow();
        }

        #endregion
        private async void MycmdFinalizar() //Boton finalizar
        {
            //await AvisaYCerrateVosSolo("Finalizar", "", 1);

            //string oldValue = "1"; //valueFieldValue.ToString();
            //string newValue = "2"; //value.ToString();
            //var l = lista.ToList();
            //int index = l.IndexOf(oldValue);
            //if (index != -1)
            //    lista[index] = newValue;
            if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.Balance)
            {
                if(HayCatalogoGeneradoAPartirBalance) //Quiere cargar un balance, pero no ha ingresado el catalog de cuentas. se genero uno y va a guardarlo
                {
                    await AvisaYCerrateVosSolo("Se va a guardar un catalogo de cuentas y despues guarda el balance.", "", 3);
                    bool drg= await this.GuardarCatalogoCuentas();
                    await AvisaYCerrateVosSolo("El catalogo de cuentas se ha guardado."+Environment.NewLine+"Continue revisando el balance y Guardelo.","",3);
                    HabilitarDatagridBalances = Visibility.Visible;
                    HabilitarDatagridCatalogoCuentas = Visibility.Hidden;
                    HayCatalogoGeneradoAPartirBalance = false;
                    HabilitarBarraControlBotones = true;
                    HabilitarcmdFinalizar = true;
                    HabilitarcmdCancelar = true;
                    this.ReconocerBalance(); //ahora vamos a recorrer el balance.
                }
                else //se guardara el balance pq ya existe un catalogo.
                {
                    //busco nuevamente el catalogo guardado para ponerles el id a cada cuenta del balance.
                    //List<catalogocuenta> catal = new List<catalogocuenta>();
                    //using (db=new SGPTEntidades())
                    //{
                    //    catal = db.catalogocuentas.Where(x => x.idsc == currentSistemaContable.idsc).ToList(); 
                    //}
                    //if (catal != null)
                    //{
                    //    foreach (var a in ListaDetalleBalance)
                    //    {
                    //        a.idcc = catal.Find(z => z.codigocc == a.codigoccdb).idcc;
                    //    }
                    //}
                    QueEstaImportandoElQue="Preparandose para almacenar un catalogo...Espere...";
                    await Task.Delay(1);
                    if (ListaDetalleBalance != null)
                    {
                        try 
	                    {	        
	                        #region +
		                    balance bal = new balance();
                            bal.idcb = SelectedClaseBalance.idcb;
                            bal.idperiodos = SelectedPeriodoBalance.idperiodos;
                            bal.fechasistemabalance = DateTime.Now.ToShortDateString();
                            bal.fechabalancebalance = FechaBalance.ToShortDateString();//DateTime.Now.ToShortDateString(); // Ojo hay que pedir esta fecha
                            bal.estadobalance = "A";
                            bal.idscbalance = currentSistemaContable.idsc;
                            if (ListaDetalleBalance != null)
                            {
                                #region +
                                ListitaDetalleBalance = new List<detallebalance>();
                                int i=0;
                                QueEstaImportandoElQue="Convirtiendo cada fila en un registro de base de datos...Espere...";
                                await Task.Delay(1);
                                foreach(var a in ListaDetalleBalance)
                                {
                                    #region +
                                detallebalance b = new detallebalance();
                                i++;
                                QueEstaImportandoElQue = "Convirtiendo cada fila en un registro de base de datos...Espere... " + i;
                                await Task.Delay(1);
                                b.iddb = a.idCorrelativo;
                                b.idcc = a.idcc;
                                b.idbalance = 100000;
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
                                QueEstaImportandoElQue = "Finalizado. Continuando el proceso de guardado...Espere... " ;
                                await Task.Delay(1);
	                            #endregion
                            }
                            bal.detallebalances = ListitaDetalleBalance;
                            QueEstaImportandoElQue="Intentando guardar el balance...Espere...";
                                await Task.Delay(1);
                            using (db = new SGPTEntidades())
                            {
                                Mouse.OverrideCursor = Cursors.Wait;
                                db.balances.Add(bal);
                                db.SaveChanges();
                                Mouse.OverrideCursor = null;
                                QueEstaImportandoElQue = "Proceso de Guardado finalizo éxitosamente";
                                await Task.Delay(1);
                                await AvisaYCerrateVosSolo("El proceso de guardado del Balance ha finalizado éxitosamente.", "Finalizado.", 3);
                            } 
                            Messenger.Default.Send<int>(1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.


                            ////-1 fracaso
                            ////0 inicializadores (No usar)
                            ////1 éxito
                            ////2 Cancelo
                            this.cmdCancelarX();
	                        #endregion
	                    }
	                    catch (Exception)
	                    {
	                    	//MessageBox("")
                            Messenger.Default.Send<int>(-1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.


                            ////-1 fracaso
                            ////0 inicializadores (No usar)
                            ////1 éxito
                            ////2 Cancelo
                            this.cmdCancelarX();
	                    }
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("No es posible guardar el balance. El listado se encontro vacio","Verifique que el archivo aun este disponible",3);
                        Messenger.Default.Send<int>(-1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.


                    ////-1 fracaso
                    ////0 inicializadores (No usar)
                    ////1 éxito
                    ////2 Cancelo
                    this.cmdCancelarX();
                    }
                    

                }
            }
            else if (MensajeModalRecibido.TipoArchivoACargar == TipoArchivoCargar.CatalogoDeCuenta)
            {
                bool grd=await this.GuardarCatalogoCuentas();
                if(grd)
                    Messenger.Default.Send<int>(1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
                else
                    Messenger.Default.Send<int>(-1, tokenAUsar);


                //-1 fracaso
                //0 inicializadores (No usar)
                //1 éxito
                //2 Cancelo
                this.cmdCancelarX();
            }

            
        }

        private async Task<bool> GuardarCatalogoCuentas()
        {
            string k = QueEstaImportandoElQue;
            QueEstaImportandoElQue = QueEstaImportandoElQue + "*-Buscando Catalogos antiguos para eliminarlos-*";
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
                    existeCatalogoParaEsteSistemaContable = (from c in db.catalogocuentas where c.idsc == currentSistemaContable.idsc select c).First();
                }
                catch (Exception)
                {
                    existeCatalogoParaEsteSistemaContable = new catalogocuenta();
                }
                if (existeCatalogoParaEsteSistemaContable.idcc > 0 && lista != null)
                {
                    #region +
                    MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El cliente: " + currentEncargo.razonsocialcliente + " Ya ha registrado un catalogo de cuentas" + Environment.NewLine + " para el encargo seleccionado: " + currentEncargo.descripcionTipoAuditoria + " " + currentEncargo.fechainiperauditencargo + "-" + currentEncargo.fechafinperauditencargo + Environment.NewLine + "Atencion: Se eliminara irreversiblemente el catalogo antiguo.", "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                    if (resultk == MessageDialogResult.Affirmative)
                    {
                        using (db = new SGPTEntidades())
                        {
                            string cad = "delete from sgpt.catalogocuentas where idsc=" + currentSistemaContable.idsc + ";";
                            var valorMantenimiento = db.Database.ExecuteSqlCommand(cad);
                            db.SaveChanges();
                            puedeGuardarCatalogo = true;
                            await AvisaYCerrateVosSolo("Se ha eliminado el catalogo antiguo", "finalizado éxitosamente", 1);
                        }
                    }
                    else puedeGuardarCatalogo = false;
                    #endregion
                }
                else if (lista != null)
                {
                    MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Esta seguro que desea guardar el catalogo de cuentas para el  cliente: " + currentEncargo.razonsocialcliente + Environment.NewLine + " para el encargo seleccionado: " + currentEncargo.descripcionTipoAuditoria + " " + currentEncargo.fechainiperauditencargo + "-" + currentEncargo.fechafinperauditencargo + Environment.NewLine, "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                    if (resultk == MessageDialogResult.Affirmative)
                        puedeGuardarCatalogo = true;
                    else
                        puedeGuardarCatalogo = false;
                }
                else puedeGuardarCatalogo = false;

            }
            QueEstaImportandoElQue = k;
            if (lista != null && lista.Count() > 1 && puedeGuardarCatalogo)
            {
                //using (db = new SGPTEntidades())
                //{

                #region +

                //var valorMantenimiento = db.Database.ExecuteSqlCommand(
                //"SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 10);");
                string l = ""; l = QueEstaImportandoElQue;
                int zx = 0;
                ObservableCollection<catalogocuenta> lst = new ObservableCollection<catalogocuenta>();
                try
                {
                    foreach (var cuenta in lista)
                    {
                        zx++;
                        catalogocuenta UnaFilaCuenta = new catalogocuenta();

                        UnaFilaCuenta.idcc = cuenta.idcc;
                        UnaFilaCuenta.idelementos = cuenta.Elementoss.id;
                        UnaFilaCuenta.idsc = currentSistemaContable.idsc;
                        UnaFilaCuenta.catidcc = cuenta.catidcc;
                        UnaFilaCuenta.idccuentas = cuenta.ClaseCuenta.id;
                        UnaFilaCuenta.codigocc = cuenta.codigocc;
                        UnaFilaCuenta.descripcioncc = cuenta.descripcioncc;
                        UnaFilaCuenta.tiposaldocc = cuenta.tipoSaldo.Id;
                        UnaFilaCuenta.fechacreacioncc = DateTime.Now.ToShortDateString();
                        UnaFilaCuenta.estadocc = "A";
                        UnaFilaCuenta.ordencc = cuenta.ordencc;
                        //if (zx == 599)
                        //    QueEstaImportandoElQue = "";
                        //lst.Add(UnaFilaCuenta);
                        using (db = new SGPTEntidades())
                        {
                            db.catalogocuentas.Add(UnaFilaCuenta);
                            db.SaveChanges();
                        }
                        QueEstaImportandoElQue = "Guardando: -**- " + zx + " de " + lista.Count() + " -**- " + cuenta.descripcioncc;
                        await Task.Delay(1);
                    }
                    QueEstaImportandoElQue = "Proceso de Guardado finalizo éxitosamente";
                    await Task.Delay(1);
                    await AvisaYCerrateVosSolo("El proceso de guardado del catalogo ha finalizado éxitosamente.", "Finalizado.", 2);

                    //Messenger.Default.Send<int>(1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
                    return true;

                    ////-1 fracaso
                    ////0 inicializadores (No usar)
                    ////1 éxito
                    ////2 Cancelo
                    //this.cmdCancelarX();


                    //using (db = new SGPTEntidades())
                    //{
                    //    Mouse.OverrideCursor = Cursors.Wait;
                    //    db.catalogocuentas.AddRange(lst);
                    //    db.SaveChanges();
                    //    //int r = CatalogoCuentasModelo.InsertByRangeCatalogo(lst);
                    //    Mouse.OverrideCursor = null;
                    //    QueEstaImportandoElQue = "Finalizado éxitosamente.";
                    //    await Task.Delay(1);
                    //}
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error desconocido. " + e, "Se cerro una conexion existente.");
                    Messenger.Default.Send<int>(-1, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.

                    //-1 fracaso
                    //0 inicializadores (No usar)
                    //1 éxito
                    //2 Cancelo
                    
                    this.cmdCancelarX();
                    return false;
                }
                #endregion
                //} 
            }
            else
            {
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
                        //txtBandera = "0";
                        //dt.Columns.Clear();
                        dt = new System.Data.DataTable();
                        dtGrd = dt.DefaultView;
                        OpenFileDialog openCatalogo = new OpenFileDialog();
                        openCatalogo.DefaultExt = ".xlsx";
                        openCatalogo.Filter = "Archivos Excel (*.xlsx, *.xls, *.csv, *.txt)|*.xlsx; *.xls; *.csv; *.txt;";

                        openCatalogo.Title = "Importar archivos";
                        //openfile.ShowDialog();

                        var browsefile = openCatalogo.ShowDialog();

                        if (browsefile == true)
                        {
                            Message = "Procesando...";
                            //await cuenteUno();
                            //txtFilePath.Text = openfile.FileName;
                            await AvisaYCerrateVosSolo("Analizando el archivo...", "Espere, la operacion puede tardar mas de lo esperado", 2);
                            Mouse.OverrideCursor = Cursors.Wait;
                            string sArchivo = openCatalogo.FileName;
                            string extension = Path.GetExtension(sArchivo);
                            NombreCatalogo = sArchivo;
                            RaisePropertyChanged("NombreCatalogo");


                            //dtGrid.ItemsSource = dt.DefaultView;
                            //dtGrd = dt.DefaultView;
                            if (extension == ".xlsx" || extension == ".xls")
                            {
                                DataTable dtf = await SiEsArchivoExcel(sArchivo);
                                dtGrd = dtf.DefaultView;
                            }
                            if (extension == ".txt")
                            {
                                //dtGrd = SiEsArchivoExcel(sArchivo).DefaultView;
                                Message = "Analizando archivo de texto .txt";
                                await Task.Delay(1);
                                dtGrd = SiEsArchivoTxT.DataTableDesdeArchivoTexto(sArchivo, ',').DefaultView;
                            }

                            if (extension == ".csv")
                            {
                                Message = "Analizando archivo separado por comas .csv";
                                await Task.Delay(1);
                                dtGrd = SiEsArchivoCSV(sArchivo).DefaultView;

                            }
                            Message = "Importacion finalizada con éxito. Indicaciones: Puede eliminar filas con tecla delete/suprimir";


                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        //HabilitarValidarCatalogo = false;
                        //txtBandera = "0";
                        MessageBox.Show("Ocurrio un error en la importacion del catalogo de cuentas. \nVerifique que el archivo no este corrupto. " + e.Message, "El archivo del catalogo esta corrupto", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                    HabilitarBarraControlBotones = true;
                    HabilitarcmdCancelar = true;
                    HabilitarcmdAdelante = true;
                    HabilitarcmdAtras = true;
                    HabilitarcmdFinalizar = false;
                    Mouse.OverrideCursor = null;
                }
                else
                {
                    await AvisaYCerrateVosSolo("Para importar un balance, es necesario que especifique su tipo", "Seleccione de los disponibles en el Paso 1", 3);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error desconocido");
            }
        } //boton cargar catalogo 

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

                            //var strColumn = (excelRange.Cells[filainicio, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2.ToString();
                            //if (string.IsNullOrEmpty(strColumn))
                            //{
                            //    colvacias++;
                            //}
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