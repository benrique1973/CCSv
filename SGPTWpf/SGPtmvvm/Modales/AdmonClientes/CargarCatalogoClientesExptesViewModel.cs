using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTWpf.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTmvvm.Modales.AdmonClientes
{

    public class CargarCatalogoClientesExptesViewModel: INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<catalogocuenta> CatalogoRegistrado { get; set; }
        public List<string> ListitaTipoSaldos { get; set; }
        public List<elemento> ListadoElementos { get; set; }

        private DialogCoordinator dlg;

        System.Data.DataTable dt = new System.Data.DataTable();

        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        #region Message y currentUsuario
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }
        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";
        private usuario _currentUsuario;
        public usuario currentUsuario
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

        private cliente _currentCliente;

        public cliente currentCliente
        {
            get
            {
                return _currentCliente;
            }

            set
            {
                if (_currentCliente == value) return;

                _currentCliente = value;

                RaisePropertyChanged("currentCliente");
            }
        }

        private sistemascontable _currentSistemaContable;
        public sistemascontable CurrentSistemaContable
        {
            get { return _currentSistemaContable; }
            set
            {
                _currentSistemaContable = value;
                RaisePropertyChanged("CurrentSistemaContable");
            }
        }

        #endregion
        #endregion
        //public CRUDfirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg, DialogCoordinator dlgIn)

        //09-03-2016 BELr para vista de encargos
        public CargarCatalogoClientesExptesViewModel()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            _canExecute = true;
            string tokenRecepcionPadre = "datosEDCatalogoCuentas";
            Messenger.Default.Register<ClientesContactosMensajeModal>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            enviarMensajeInhabilitar();
        }


        private void ControlRecepcionDatos(ClientesContactosMensajeModal msg)
        {
            currentUsuario = msg.UsuarioValidado;
            currentCliente = msg.currentCliente;
            CurrentSistemaContable = msg.SistemaContableAModificar;
            this.inicializarListados();
            this.EscuchandoALaVista(msg);
            Mouse.OverrideCursor = null;
        }
        //En caso de éxito

        #region Mensajes

        public void enviarMensaje()
        {
            string tokenEnvioController = "datosControllerCatalogoCuentas";
            int resultadoProceso = 1;//éxito
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvioController);
        }
        //En caso de éxito
        public void enviarMensajeFracaso()
        {
            string tokenEnvioController = "datosControllerCatalogoCuentas";
            int resultadoProceso = 0;//éxito
            //Creando el mensaje de cierre
            Messenger.Default.Send(resultadoProceso, tokenEnvioController);
        }
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
        //Fin adicion: BELr

        public CargarCatalogoClientesExptesViewModel(ClientesContactosMensajeModal msg)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            _canExecute = true;
            currentUsuario = msg.UsuarioValidado;
            currentCliente = msg.currentCliente;
            CurrentSistemaContable = msg.SistemaContableAModificar;
            this.inicializarListados();
            this.EscuchandoALaVista(msg);
        }

        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(ClientesContactosMensajeModal Mensajito)
        {
            currentUsuario = Mensajito.UsuarioValidado;
            currentCliente = Mensajito.currentCliente;
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    Editar(Mensajito); break;
                case TipoComando.Consultar:
                    Consultar(Mensajito);
                    break;
                case TipoComando.Nuevo:
                    NuevoInformeTiempo(); break;
                default: break;
            }

        }


        #region Campos
        private int     _idcargoeo;
        private int     _estidcargoeo;
        private string _idnitcliente ;
        private string _nombrecargoeo;
        private string _responsabilidadeo ;
        private string _funcionadicionaleo;
        private string _estadoeo;

        public int Idcargoeo { get { return _idcargoeo; } set { _idcargoeo = value; RaisePropertyChanged("Idcargoeo"); } }
        public int Estidcargoeo { get { return _estidcargoeo; } set { _estidcargoeo = value; RaisePropertyChanged("Estidcargoeo"); } }
        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public string Nombrecargoeo { get { return _nombrecargoeo; } set { _nombrecargoeo = value; RaisePropertyChanged("Nombrecargoeo"); } }
        public string Responsabilidadeo { get { return _responsabilidadeo; } set { _responsabilidadeo = value; RaisePropertyChanged("Responsabilidadeo"); } }
        public string Funcionadicionaleo { get { return _funcionadicionaleo; } set { _funcionadicionaleo = value; RaisePropertyChanged("Funcionadicionaleo"); } }
        public string Estadoeo { get { return _estadoeo; } set { _estadoeo = value; RaisePropertyChanged("Estadoeo"); } }
        

       
        #endregion

        #region Bindiados

        private string _txtBandera = "0"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
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

        private void activarbotonguardar()
        {
            if (AccionConsultar == false && AccionGuardar == false) { txtBandera = "1"; RaisePropertyChanged("txtBandera"); }
        }

        #endregion

        #region Activadores

        #endregion

        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ICommand _cmdCargarCat_Click;
        public ICommand cmdCargarCat_Click
        {
            get
            {
                return _cmdCargarCat_Click ?? (_cmdCargarCat_Click = new CommandHandler(() => cmdCargarCatalogo(), _canExecute));
            }
        }


        private bool _HabilitarValidarCatalogo=false;
        public bool HabilitarValidarCatalogo
        {
            get { return _HabilitarValidarCatalogo; }
            set
            {
                _HabilitarValidarCatalogo = value;
                RaisePropertyChanged("HabilitarValidarCatalogo");
            }
        }

        private bool _HabilitarcmdCargarCat = true;
        public bool HabilitarcmdCargarCat
        {
            get { return _HabilitarcmdCargarCat; }
            set
            {
                _HabilitarcmdCargarCat = value;
                RaisePropertyChanged("HabilitarcmdCargarCat");
            }
        }
        //HabilitarcmdCargarCat
        private ICommand _cmdValidarCat_Click;
        public ICommand cmdValidarCat_Click
        {
            get
            {
                return _cmdValidarCat_Click ?? (_cmdValidarCat_Click = new CommandHandler(() => cmdValidarCatalogo(), _canExecute));
            }
        }

        private void cmdValidarCatalogo()
        {
            if (ValidacionManualOk())
            {
                MessageBox.Show("El catalogo importado es valido y esta listo para guardarse","Catalogo correcto",MessageBoxButton.OK,MessageBoxImage.Information);
                txtBandera = "1";
            }
            else
            {
                txtBandera = "0";
                MessageBox.Show("Se encontraron incongruencias irreparables en el catalogo importado.\n Corrija los datos requeridos en las columnas con asterisco (*)\nElimine los encabezados y vuelva a cargar el catalogo corregido.", "Error en las columnas",MessageBoxButton.OK,MessageBoxImage.Stop);
            }
        }

        private async Task cuenteUno()
        {
            await Task.Delay(1);
        }
        private async void cmdCargarCatalogo()
        {
            try
            {
                #region +
                dt.Clear();
                txtBandera = "0";
                ////dt.Columns.Clear();
                //dt=new System.Data.DataTable();
                OpenFileDialog openCatalogo = new OpenFileDialog();
                openCatalogo.DefaultExt = ".xlsx";
                openCatalogo.Filter = "Archivos Excel (*.xlsx, *.xls)|*.xlsx; *.xls";
                openCatalogo.Title = "Importar catalogo de cuentas";
                //openfile.ShowDialog();

                var browsefile = openCatalogo.ShowDialog();

                if (browsefile == true)
                {
                    Message = "Procesando...";
                    await cuenteUno();
                    //txtFilePath.Text = openfile.FileName;
                    string sArchivo = openCatalogo.FileName;
                    NombreCatalogo = sArchivo;
                    RaisePropertyChanged("NombreCatalogo");
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                    Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(sArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1);
                    //excelSheet.Columns("A:A").SpecialCells(XlCellType.xlCellTypeBlanks).EntireRow.Delete
                    //excelSheet.Rows("1:1").SpecialCells(XlCellType.xlCellTypeBlanks).EntireColumn.Delete
                    Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                    string strCellData = "";
                    double douCellData;
                    int rowCnt = 0;
                    int colCnt = 0;

                    //System.Data.DataTable dt = new System.Data.DataTable();
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        string strColumn = "";
                        strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                        if (!string.IsNullOrEmpty(strColumn))
                            dt.Columns.Add(strColumn, typeof(string));
                    }
                    Message = "Cargando catalogo de cuentas... Iniciando reconocimiento de caracteres... Espere un momento por favor. El proceso puede demorar, pero depende de la capacidad de su computador.";
                    await cuenteUno();
                    for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                    {
                        string strData = "";
                        int vacio = 0;
                        for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                        {
                            try
                            {
                                strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                strData += strCellData + "|";
                                if (String.IsNullOrEmpty(strCellData))
                                    vacio += 1;
                            }
                            catch (Exception)
                            {
                                douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                                strData += douCellData.ToString() + "|";
                                if (String.IsNullOrEmpty(douCellData.ToString()))
                                    vacio += 1;
                            }

                        }
                        if (vacio <= 2)
                        {
                            strData = strData.Remove(strData.Length - 1, 1);
                            dt.Rows.Add(strData.Split('|'));
                            await cuenteUno();
                            Message = " Filas agregadas:  " + rowCnt + " de  " + excelRange.Rows.Count;
                        }
                        else
                        {
                            await cuenteUno();
                            Message = "Fila vacia ignorada...";
                        }

                    }

                    //dtGrid.ItemsSource = dt.DefaultView;
                    dtGrd = dt.DefaultView;
                    Message = "Importacion finalizada con éxito. Indicaciones: Puede eliminar filas con tecla delete/suprimir, editar filas dando doble click a la celda. ";
                    HabilitarValidarCatalogo = true;
                    txtBandera = "0";
                    excelBook.Close(true, null, null);
                    excelApp.Quit();
                }
                #endregion
            }
            catch (Exception)
            {
                HabilitarValidarCatalogo = false;
                txtBandera = "0";
                MessageBox.Show("Ocurrio un error en la importacion del catalogo de cuentas. \nVerifique que el archivo no este corrupto.","El archivo del catalogo esta corrupto",MessageBoxButton.OK,MessageBoxImage.Stop);
            }
        }

        private ICommand _cmdCancelar_Click;
        public ICommand cmdCancelar_Click
        {
            get
            {
                return _cmdCancelar_Click ?? (_cmdCancelar_Click = new CommandHandler(() => cmdCancelar(), _canExecute));
            }
        }

        private ICommand _cmdGuardar_Click;
        public ICommand cmdGuardar_Click
        {
            get
            {
                return _cmdGuardar_Click ?? (_cmdGuardar_Click = new CommandHandler(() => this.activarBarra(), _canExecute));
            }
        }


        public void inicializarListados()
        {

            ListitaTipoSaldos = new List<string>();
            string d="D"; ListitaTipoSaldos.Add(d);
            string a="A"; ListitaTipoSaldos.Add(a);
            string rd="RD"; ListitaTipoSaldos.Add(rd);
            string ra="RA"; ListitaTipoSaldos.Add(ra);
            ListadoElementos = new List<elemento>();

            using (db=new SGPTEntidades())
            {
                ListadoElementos = (from e in db.elementos select e).ToList(); 
            }
            //La idea de aqui es inicializar un catalogo de cuentas de ejemplo y que sea basico.
            dt.Clear();
            using (db = new SGPTEntidades())
            {
                //var catalogoExistente = from c in db.catalogocuentas
                //                         where c.idsc == CurrentSistemaContable.idsc
                //                         orderby c.codigocc
                //                         select new {Nivel= c.nivelcc,CodigoCont= c.codigocc, Cuenta=c.descripcioncc, IdElemento=c.idelementos, TipoSaldo=c.tiposaldocc };
                CatalogoRegistrado = new List<catalogocuenta>();
                CatalogoRegistrado = (from de in db.catalogocuentas
                                      where de.idsc == CurrentSistemaContable.idsc
                                      orderby de.codigocc
                                      select de).ToList();

                if (CatalogoRegistrado != null && CatalogoRegistrado.Count>1)
                {
                    dt.Columns.Add("* Nivel", typeof(int));
                    dt.Columns.Add("* Codigo contable", typeof(string));
                    dt.Columns.Add("* Nombre cuenta", typeof(string));
                    dt.Columns.Add("* Id elemento", typeof(int));
                    dt.Columns.Add("Elemento (opcional)");
                    dt.Columns.Add("* Id tipo saldo", typeof(string));
                    dt.Columns.Add("Tipo saldo (opcional)");

                    //catalogoExistente.CopyToDataTable<System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Row>(dt, LoadOption.PreserveChanges);
                    //dt = catalogoExistente.CopyToDataTable<System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Row>();
                    //foreach (var e in catalogoExistente)
                    foreach (var e in CatalogoRegistrado)
                    {
                        var row = dt.NewRow();
                        //row["* Nivel"] = e.nivelcc;
                        row["* Codigo contable"] = e.codigocc;
                        row["* Nombre cuenta"] = e.descripcioncc;
                        row["* Id elemento"] = e.idelementos;
                        var rr = ListadoElementos.Find(x => x.idelementos == e.idelementos);
                        row["Elemento (opcional)"] = rr.descripcionelementos;
                        row["* Id tipo saldo"] = e.tiposaldocc;
                        switch (e.tiposaldocc)
                        {
                            case "A": row["Tipo saldo (opcional)"] = "Acreedor"; break;
                            case "D": row["Tipo saldo (opcional)"] = "Deudor"; break;
                            case "RD": row["Tipo saldo (opcional)"] = "Resultado deudor"; break;
                            case "RA": row["Tipo saldo (opcional)"] = "Resultado acreedor"; break;
                        }
                        
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    dt.Columns.Add("* Nivel");
                    dt.Columns.Add("* Codigo contable");
                    dt.Columns.Add("* Nombre cuenta");
                    dt.Columns.Add("* Id elemento");
                    dt.Columns.Add("Elemento (opcional)");
                    dt.Columns.Add("* Id tipo saldo");
                    dt.Columns.Add("Tipo saldo (opcional)");

                    #region Catalogo de Ejemplo
                    dt.Rows.Add(new Object[] { 1, "1110-000-000", " ACTIVOS	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 2, "1110-100-000", " Circulante 	                          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-101-000", " Caja	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-102-000", " Bancos 	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-102-001", " Banamex SA	                          ", 1, " Activo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 4, "1110-102-002", " Banco Agricola S.A                   ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-102-003", " Scotiabank SA	                      ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-103-000", " Almacen	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-103-001", " Magna	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-103-002", " Premium	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-103-003", " Diesel	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-104-000", " Clientes	                          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-104-001", " Electropura SA de CV	              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-105-000", " Deudores Diversos 	                  ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-106-000", " Documentos Por Cobrar 	              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-107-000", " IVA ACREDITABLE	                      ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-107-001", " IVA ACREDITABLE 16%	                  ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 2, "1110-200-000", " Fijo	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-201-000", " Terreno	                              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-202-000", " Edificios 	                          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-203-000", " Mobiliario y Equipo de Oficina	      ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-203-001", " Monitor Dell	                      ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 4, "1110-203-002", " Mousse Dell	                          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-204-000", " Equipo de Reparto y Entrega	          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-205-000", " Maquinaria	                          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-206-000", " depositos en garantia	              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-207-000", " Gastos de instalacion	              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-208-000", " Papeleria y utiles	                  ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 2, "1110-300-000", " DIferido	                          ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-301-000", " Propaganda y Publicidad	              ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-302-000", " Pirmas de seguro	                  ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-303-000", " Rentas pagadas por anticipado	      ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1110-304-000", " Intereses pagados por anticipado	  ", 1, " Activo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 1, "1120-000-000", " PASIVOS	                              ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 2, "1120-100-000", " Circulante	                          ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-101-000", " Proveedores	                          ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 4, "1120-101-001", " PEMEX	                              ", 2, " Pasivo", "D", " Deudora                 " });
                    dt.Rows.Add(new Object[] { 3, "1120-102-000", " Documentos por pagar	              ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-103-000", " Acreedores diversos	                  ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-104-000", " IVA TRASLADADO	                      ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 4, "1120-104-001", " Iva trasladado 16%	                  ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 4, "1120-104-002", " IVA por trasladar 16%	              ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 2, "1120-200-000", " Fijo	                              ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-201-000", " Documenos por pagar a largo plazo 	  ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-202-000", " Acreedores Hipotecarios	              ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 2, "1120-300-000", " Diferido	                          ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-301-000", " Rentas cobradas x anticipado	      ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 3, "1120-302-000", " Intereses Cobrados x anticipado	      ", 2, " Pasivo", "A", " Acreedora               " });
                    dt.Rows.Add(new Object[] { 1, "1130-000-000", " CAPITAL CONTABLE	                      ", 3, " Patrimonio ", "D", " Deudora            " });
                    dt.Rows.Add(new Object[] { 2, "1130-100-000", " Capital Social	                      ", 3, " Patrimonio ", "D", " Deudora            " });
                    dt.Rows.Add(new Object[] { 1, "1140-000-000", " CUENTAS DE ORDEN	                  ", 6, " Cuentas de orden ", "A", "Acreedora     " });
                    dt.Rows.Add(new Object[] { 2, "1140-100-000", " Mercancías en Comisión               ", 6, " Cuentas de orden ", "A", "Acreedora     " });
                    dt.Rows.Add(new Object[] { 3, "1140-101-000", " Mercancías en Consignación           ", 6, " Cuentas de orden ", "A", "Acreedora     " });
                    dt.Rows.Add(new Object[] { 4, "1140-101-001", " Documentos Descontados y Endosados   ", 6, " Cuentas de orden ", "A", "Acreedora     " });
                    dt.Rows.Add(new Object[] { 1, "1150-000-000", " GASTOS	                              ", 4, " Costos y Gastos ", "D", "Deudora        " });
                    dt.Rows.Add(new Object[] { 2, "1150-100-000", " Depreciaciones	                      ", 4, " Costos y Gastos ", "D", "Deudora        " });
                    dt.Rows.Add(new Object[] { 3, "1150-101-000", " Amortizaciones intangibles	          ", 4, " Costos y Gastos ", "D", "Deudora        " });
                    dt.Rows.Add(new Object[] { 2, "1150-200-000", " Gasto de personal	                  ", 4, " Costos y Gastos ", "D", "Deudora        " });
                    dt.Rows.Add(new Object[] { 3, "1150-201-000", " Provisiones	                          ", 4, " Costos y Gastos ", "D", "Deudora        " });
                    dt.Rows.Add(new Object[] { 1, "1160-000-000", " COMPRAS	                               ", 4, " Costos y Gastos ", "RD", "Resultado Deudor" });
                    dt.Rows.Add(new Object[] { 2, "1160-100-000", " Compras al exterior                    ", 4, " Costos y Gastos ", "RD", "Resultado Deudor" });
                    dt.Rows.Add(new Object[] { 1, "1170-000-000", " VENTAS	                               ", 5, " Ingresos o ventas ", "RA", "Resultado Acreedor" });
                    dt.Rows.Add(new Object[] { 2, "1170-100-000", " Devoluciones sobre compras             ", 5, " Ingresos o ventas ", "RA", "Resultado Acreedor" });

                    #endregion
                }

            }
            
            
            dtGrd = dt.DefaultView;


            Message="Ejemplo de catalogo de cuentas valido. Asegurese que el catalogo de cuentas a importar tenga la siguiente estructura en sus columnas y esten en el orden indicado. Las columnas con '*' son requeridas obligatorias. Consulte el 'Catalogo de elementos' en el menu administracion. Nota: La estructura del codigo contable y el nombre de las cuentas pueden variar de un cliente a otro sin afectar.";

            RaisePropertyChanged("");
        }


        #region +
        private void NuevoInformeTiempo()
        {
            //txtBandera = "1";
            AccionGuardar = true;
            AccionConsultar = false;
            HabilitarcmdCargarCat = true;
            RaisePropertyChanged("HabilitarcmdCargarCat");
            //Message = "Nuevo puesto de estructura organica";
        }
        private void Editar(ClientesContactosMensajeModal Mensajito)
        {
            //txtBandera = "1";
            AccionGuardar = true;
            AccionConsultar = false;
            HabilitarcmdCargarCat = true;
            RaisePropertyChanged("HabilitarcmdCargarCat");
            Message = "Editar catalogo de cuentas";
            ////CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            //Message = "Editar cargo estructura organica";
            //this.compartidaEditarConsultar(Mensajito);
        }
        private void compartidaEditarConsultar(ClientesContactosMensajeModal Mensajito)
        {
            //this.inicializarListados();
            //estructurasorganica est = Mensajito.EstructuraAmodificar;
            //try
            //{
            //    #region -
            //    Idcargoeo = est.idcargoeo;
            //    //Estidcargoeo = (int)est.estidcargoeo;
            //    SelectedEstructuraO = estructuraOListado.Find(x => x.idcargoeo == est.estidcargoeo);
            //    Idnitcliente = est.idnitcliente;
            //    Nombrecargoeo = est.nombrecargoeo;
            //    Responsabilidadeo = est.responsabilidadeo;
            //    //Funcionadicionaleo = est.funcionadicionaleo;
            //    if (!string.IsNullOrEmpty(est.funcionadicionaleo))
            //    {
            //        string[] oFunc = est.funcionadicionaleo.Split(','); //r.participanteexternoreunion.Split(',');
            //        if (oFunc.Length > 0)
            //        {
            //            foreach (var a in oFunc)
            //            {
            //                if (a.Length > 1)
            //                {
            //                    var f = otrasFuncionesListad.Find(s => s.descripcion == a.Trim());
            //                    if (f != null) f.esSeleccionado = true;
            //                }
            //            }
            //        }
            //    }
            //    RaisePropertyChanged("otrasFuncionesListad");
            //    //Estadoeo = "A";
            //    #endregion
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ocurrio un error al recuperar los datos de la correspondencia. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error.", "Error de compatibilidad");
            //}
        }
        private void Consultar(ClientesContactosMensajeModal Mensajito)
        {
            ////this.inicializarListados();
            txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            HabilitarcmdCargarCat = false;
            RaisePropertyChanged("HabilitarcmdCargarCat");
            Message = "Consultar catalogo de cuentas";
            //this.compartidaEditarConsultar(Mensajito);
        } 
        #endregion

        private void cmdCancelar()
        {
            MessageBox.Show("No se realizo ninguna modificacion.", "Operacion cancelada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            this.FinalizarAction();
        }

        private void activarBarra()
        {
            //DejarseVer = Visibility.Visible;
            RaisePropertyChanged();
            MessageBoxResult Guarde = MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            switch (Guarde)
            {
                case MessageBoxResult.Yes: this.cmdGuardar(); break;
                case MessageBoxResult.No: MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
                case MessageBoxResult.Cancel: this.cmdCancelar(); break;
            }

        }

        private void cmdGuardar()
        {//***********************************************************************************************************
            if (AccionGuardar)
            {
                if (CatalogoRegistrado.Count() > 3)
                {
                    MessageBoxResult Guarde = MessageBox.Show("El Cliente: " + currentCliente.razonsocialcliente + " ya posee un catalogo registrado en este sistema contable. \n Desea eliminar el catalogo y reemplazarlo por uno nuevo?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    switch (Guarde)
                    {
                        case MessageBoxResult.Yes: this.cmdEliminarYGuardar(); break;
                        case MessageBoxResult.No: MessageBox.Show("La operacion guardar ha sido cancelado por el usuario..", "No se ha guardado nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
                        case MessageBoxResult.Cancel: this.cmdCancelar(); break;
                    }
                }
                else
                {
                    this.cmdGuardarHoySi();
                } 
            }
        }

        private async void cmdGuardarHoySi()
        {
            Message = "Iniciando el proceso de almacenamiento en la base de datos.";
            int k = 0;
            using (db=new SGPTEntidades())
            {
                foreach (DataRow r in dt.Rows)
                {
                    catalogocuenta c = new catalogocuenta();
                    c.idcc = 10000000;
                    c.idelementos = (int.Parse(r[3].ToString()));
                    c.idsc = CurrentSistemaContable.idsc;
                    c.codigocc = r[1].ToString();
                    c.descripcioncc = r[2].ToString();
                    c.tiposaldocc = r[5].ToString();
                    c.fechacreacioncc = DateTime.Now.ToShortDateString();
                    c.estadocc = "A";
                    //c.nivelcc = (int.Parse(r[0].ToString()));

                    try
                    {
                        db.catalogocuentas.Add(c);
                        db.SaveChanges();
                        k++;
                        Message = k + " Registro(s) han sido almacenados en la base de datos.";
                        await cuenteUno();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al intentar guardar el catalogo de cuentas. \nLa base de datos tardo demasiado en responder."+ex.InnerException, "Error grave", MessageBoxButton.OK, MessageBoxImage.Stop);
                        this.cmdCancelar();
                    }
                } 
            }
            Message = "Finalizado. "+k +" registros fueron guardados.";
            AvisaYCerrateVosSolo("El registro se guardo con éxito.", "Finalizado.",2);
            this.FinalizarAction();
        }

        private async void AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
            };
            //DialogMessageFontSize = 30,
            //    DialogTitleFontSize=30,
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }
        private async void cmdEliminarYGuardar()
        {
            using (db=new SGPTEntidades())
            {
                int j = 0;
                foreach (var a in CatalogoRegistrado)
                {
                    db.catalogocuentas.Remove(a);
                    j++;
                    Message = j + " Registro(s) marcados para eliminar.";
                    await cuenteUno();
                }
                try
                {
                    Message = "Guardando los cambios de eliminacion en la base de datos...";
                    await cuenteUno();
                    db.SaveChanges();
                    Message = "Finalizado. La eliminacion se realizo éxitosamente.";
                    await cuenteUno();

                    this.cmdGuardarHoySi();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Imposible eliminar el catalogo guardado. \n La base de datos tardo demasiado en responder "+ex.InnerException);
                } 
            }
        }


        private bool ValidacionManualOk()
        {
            if (dt.Columns.Count == 7)
            {
                //string rr=dt.Rows[0][0].ToString();
                //if((dt.Rows[0][0].ToString()).All(char.IsDigit)
                //{
                //    if((dt.Rows[0][2].ToString()).All(char.IsLetter)
                //    {
                //        if((dt.Rows[0][3].ToString()).All(char.IsDigit)
                //        {
                //            //if(TodaColumnaOk(0,1))
                //        }
                //    }
                //}
                if(TodaColumnaOk(7,1,0,0,1,0))
                    return true;

            }
            else if (dt.Columns.Count == 5)
            {
                if (TodaColumnaOk(5, 1, 0, 0, 1, 0))
                    return true;
            }
            return false;
        }

        private bool TodaColumnaOk(int columnas, int nivel, int codigocont, int cuenta, int elemento, int saldo)
        {
            //foreach()
            //ListitaCantidadDigitos = new List<int>();
            //for (int i = 1; i <= 10; i++)
            //    ListitaCantidadDigitos.Add(i);

            //try
            //{
                int incongruencias = 0;
                //if (columnas == 7)
                //{
                foreach (DataRow r in dt.Rows)
                {
                    //string a = r[0].ToString();
                    if (!r[0].ToString().All(char.IsDigit))
                        incongruencias += 1;
                   // string b = r[3].ToString();
                    //var bb = r[3];
                    if (!r[3].ToString().All(char.IsDigit))
                        incongruencias += 1;
                    //string k = (r[3].ToString());
                    //int kk = int.Parse(k);
                    try
                    {
                        if (!ListadoElementos.Exists(x => x.idelementos == (int.Parse(r[3].ToString()))))
                            incongruencias += 1;
                    }
                    catch (Exception)
                    {
                        incongruencias += 1;
                    }

                    if (columnas == 7)
                    {
                        string c = r[5].ToString();
                        var cc = r[5];
                        if (!ListitaTipoSaldos.Contains(r[5].ToString()))
                            incongruencias += 1;
                    }
                    else if (columnas == 5)
                    {
                        string d = r[5].ToString();
                        if (!ListitaTipoSaldos.Contains(r[5].ToString()))
                            incongruencias += 1;
                    }
                }
                if (incongruencias == 0)
                    return true;
                else
                {
                    if (incongruencias <= 5)
                        Message = "Se encontraron " + incongruencias + " incongruencias en el catalogo. Intente eliminar la primera fila de titulos si existe";
                    else
                        Message = "Se encontraron " + incongruencias + " incongruencias en el catalogo. Intente cargar nuevamente el catalogo corregido.";
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(" error " + ex);
            //}
            //}
            //else if (columnas == 5)
            //{

            //}
            return false;
        }


    }
}