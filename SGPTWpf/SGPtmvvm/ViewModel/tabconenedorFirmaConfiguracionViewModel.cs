using CapaDatos;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Npgsql;

using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Data;
using System.Threading.Tasks;

namespace SGPTmvvm.ViewModel
{
    public class tabconenedorFirmaConfiguracionViewModel : INotifyPropertyChanged //, ViewModeloBase
    {
        private DialogCoordinator dlg;
        public SGPTEntidades db = new SGPTEntidades();
        public List<pais> ListadoPaises { get; set; }
        public List<departamento> ListadoDepartamentos { get; set; }
        public List<municipio> ListadoMunicipios { get; set; }
        public List<firma> ListadoFirmas { get; set; }
        public List<conexione> ListadoConexiones { get; set; }
        public List<tipostelefono> ListadoTipoTelefono { get; set; }
        public List<telefonoModelo> ListadoTelefonos { get; set; }
        List<telefono> _telefonos = new List<telefono>();
        public List<correo> ListadoCorreos { get; set; }
        List<correo> _correos = new List<correo>();
        public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }
        List<UsuariosVM> UsuariosListados = new List<UsuariosVM>();
        public ObservableCollection<servidoresCorreos> ListadoServidoresComunesCorreos { get; set; }
        public List<Conexion> ListadoConexionesBakup {get;set;}
        public class servidoresCorreos
        {
            public string nombreservidorcorreo{get;set;}
            public string hostcorreo{get;set;}
            public int puertocorreo { get; set; }
            public bool sslrequeridocorreo { get; set; }
        }

        public class Conexion
        {
            public int id {get;set;}
            public string descripcion {get;set;}
            public string Base {get;set;}
            public string Servidor{get;set;}
            public string Usuario {get;set;}
            public string Pass {get;set;}
            public string puerto {get;set;}
        }
        

        String strNombre, imagenNombre;

        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool _canExecute;
        
        public tabconenedorFirmaConfiguracionViewModel()
        {
            dlg = new DialogCoordinator();
            EstadoActualIPServidor = "IP Servidor fuera de alcance";

            this.inicializadoresBasicos();
            this.PruebaInicializadoresEnSegundoPlano();
           

            //this.ObtenerDatos();
            //this.verificarAlcanceIPservidor();
        }

        private async void verificarAlcanceIPservidor()
        {
            if (!string.IsNullOrEmpty(Ipconexion))
            {
                if (TipoIP==ListaBotonesTipoIP.IpLocal)
                {
                    if (parseIP(Ipconexion))
                    {
                        #region +
                        Ping pingSender = new Ping();
                        IPAddress address = IPAddress.Parse(Ipconexion);//IPAddress.Loopback;
                        PingReply reply = pingSender.Send(address);

                        if (reply.Status == IPStatus.Success)
                        {
                            EstadoActualIPServidor = "La IP servidor esta Disponible.";
       
                        }
                        else
                        {
                            EstadoActualIPServidor = "Ip servidor no disponible... " + reply.Status;
                        }
                        #endregion  
                    }
                    
                }
                else //si la ip es publica
                {
                    if (parseIP(Ipconexion))
                    {
                        #region +
                        Ping pingSender = new Ping();
                        IPAddress address = IPAddress.Parse(Ipconexion);//IPAddress.Loopback;
                        PingReply reply = pingSender.Send(address);

                        if (reply.Status == IPStatus.Success)
                        {
                            EstadoActualIPServidor = "La IP servidor esta Disponible.";
                        }
                        else
                        {
                            EstadoActualIPServidor ="Ip servidor no disponible "+reply.Status;
                        }
                        #endregion
                    }
                    else
                    {
                        //tratamos de obtener la ip basandose en un dominio por ej: www.googlu.com, cual es ?
                        try
                        {
                            Ping pingSender = new Ping();
                            IPAddress address = Dns.GetHostAddresses(Ipconexion)[0];
                            PingReply reply = pingSender.Send(address);

                            if (reply.Status == IPStatus.Success)
                            {
                                //await AvisaYCerrateVosSolo("La ip esta al alcance en la red.","",1); 
                                EstadoActualIPServidor = "La IP servidor esta Disponible en misma red.";
                            }
                            else
                            {
                                EstadoActualIPServidor = "Ip servidor no es alcanzable... " + reply.Status;
                                await AvisaYCerrateVosSolo("La Ip servidor no esta al alcance en la red. Se intentara crear una conexion directa a la base de datos servidor", "", 2); 

                                Mouse.OverrideCursor=Cursors.Wait;
                                bool Bandera = await this.Conectar(Ipconexion, "programador1", "Pa$$w0rd");
                                if (Bandera)
                                {
                                    EstadoActualIPServidor = "El servidor esta disponible.";
                                }
                                this.MycmdDesConectarABase();
                                Mouse.OverrideCursor=null;
                            }

                        }
                        catch (ArgumentNullException)
                        {
                            EstadoActualIPServidor = "IP erronea o nula...";
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            EstadoActualIPServidor = "Ip servidor Fuera de rango";
                        }
                        catch (System.Net.Sockets.SocketException)
                        {
                            EstadoActualIPServidor = "Ip servidor, salida socket no disponible";
                        }
                        catch(ArgumentException)
                        {
                            EstadoActualIPServidor = "IP servidor no disponible";
                        }
                    }
                }
            }
            else
            {
                EstadoActualIPServidor = "No hay servidor.";
            }

        }

        private bool parseIP(string ipAddress)
        {

            try
            {
                IPAddress address = IPAddress.Parse(ipAddress);
                return true;
            }

            catch (ArgumentNullException )
            {
                EstadoActualIPServidor = "IP erronea...";
            }

            catch (FormatException )
            {
                EstadoActualIPServidor = "IP erronea...";
            }

            catch (Exception )
            {
                EstadoActualIPServidor = "IP erronea...";
            }
            //Si llego hasta aqui es porque la ip produjo algun error.
            //Voy a intentar obtener la ip si es que es una ip publica.

            return false;
        }

        private void PruebaInicializadoresEnSegundoPlano()
        {
            /*OJO No borrar, puede servir para cuando se necesite proceso en segundo plano*/
            //System.Windows.Threading.Dispatcher logoDispatcher = ;
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_procesoFinalizado;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync(); 
        }

        #region Prueba de sub-Proceso en segundo plano
        private void worker_procesoFinalizado(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Finalizado");
            //ValorDejarseVer = 100;
            //RaisePropertyChanged();
            //valorProgresoTextBox = "Espere...";
            //RaisePropertyChanged();
            this.ObtenerDatos();
            //this.verificarAlcanceIPservidor();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0, String.Format("Proceso Interaccion 1."));
            //this.ObtenerDatos();
            this.inicializarListados();

            worker.ReportProgress(100, "Proceso Finalizado con éxito.");
        }

        //private delegate void CargarElLogotipo(byte[] Logofirmax);
        //private void CargarElLogotipo(byte[] Logofirmax)
        //{

        //}

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //RaisePropertyChanged();
            //ValorDejarseVer = e.ProgressPercentage;
            //RaisePropertyChanged();
            //valorProgresoTextBox = (string)e.UserState;
            //RaisePropertyChanged();
        } 
        #endregion

        private string _EstadoActualIPServidor;
        public string EstadoActualIPServidor
        {
            get { return _EstadoActualIPServidor; }
            set
            {
                _EstadoActualIPServidor = value;
                RaisePropertyChanged("EstadoActualIPServidor");
            }
        }
        private void inicializadoresBasicos()
        {
            txtBandera = "0";//no puede guardar
            _canExecute = true;
            //*********************************************
            TipoIP = ListaBotonesTipoIP.IpLocal;
            TipoProtocolo = ListaBotonesProtocoloIP.Ipv4;
            //**********************************************
            EsConexionPrincipal = true;
            LeyendasValidacionesCorreos = "Seleccione un correo";
            colorValidacionesCorreos = Brushes.Black;
            //**********************************************
            btnModificarCorreoVisible=Visibility.Hidden;
            btnGuardarCorreoVisible=Visibility.Hidden;
            btnAgregarCorreoVisible=Visibility.Visible;
            //btnQuitCorreosVisible = Visibility.Visible;
            btnQuitCorreosHabilitado = false;
            //btnCancelModificarCorreoVisible = Visibility.Hidden;
            btnCancelModificarCorreoActivado = false;
            RaisePropertyChanged();
        }


        #region Parte Sistema
        //public bool IsCheckBoxChecked
        //{
        //    get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
        //    set { SetValue(IsCheckBoxCheckedProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IsCheckBoxCheckedProperty =
        //    DependencyProperty.Register("IsCheckBoxChecked", typeof(bool), typeof(tabconenedorFirmaConfiguracionViewModel), new PropertyMetadata(false));
        public ICommand _cmdGuardarConfSistema;
        public ICommand cmdGuardarConfSistema { get { return _cmdGuardarConfSistema ?? (_cmdGuardarConfSistema = new CommandHandler(() => MycmdGuardarConfSistema(), _canExecute)); } }

        private void MycmdGuardarConfSistema()
        {
            //MessageBox.Show("Selecciono guardar en Sistema"); 
            if (ValidacionSistemaOk())
            {
                #region -
                using (db = new SGPTEntidades())
                {
                    conexione conex = new conexione();
                    if (Idconexion == 0)
                        conex.idconexion = 1;
                    else
                        conex.idconexion = Idconexion;
                    conex.idfirma = Idfirma; //verificar si la firma ya esta registrada
                    conex.ipconexion = Ipconexion; //validar si la ip esta correcta, pq en la vista tarda en reconocer la validacion
                    conex.tipoip = (TipoIP == ListaBotonesTipoIP.IpLocal ? "L" : "P"); //(TipoIP.ToString() == "IpLocal" ? "L" : "P");
                    conex.protocoloconexion = (TipoProtocolo == ListaBotonesProtocoloIP.Ipv4 ? true : false);
                    conex.puertoconexion = Puertoconexion;
                    conex.principalconexion = Principalconexion;
                    conex.estadoconexion = "A";
                    #region _
                    try
                    {
                        #region -
                        int a = db.conexiones.Count();
                        if (a == 0)
                        {
                            conex.idconexion = 1;
                            db.conexiones.Add(conex);
                            db.SaveChanges();
                            //MessageBox.Show("Los cambios fueron almacenados.\nSe creo un nuevo registro en la base de datos.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            db.Entry(conex).State = EntityState.Modified;
                            db.SaveChanges();
                            //MessageBox.Show("Los cambios fueron almacenados.\nSe actualizo el registro existente.","Finalizado.",MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurio un error al almacenar los datos de la configuracion.\nLa base de datos tardo demasiado en responder\nSi el error continua, informe a soporte tecnico.\n " + ex.InnerException, "Error al guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                    #endregion
                }
                #endregion 
            }
            else
            {
                dlg.ShowMessageAsync(this, "No ha configurado correctamente algun servidor para centralizar los datos. \nPuede realizarlo mas adelante, pero considerelo muy importante", "Preste mucha atencion, sino no podra compartir informacion con otros miembros del equipo.");
            }
        }

        private bool ValidacionSistemaOk()
        {
            if (Idfirma > 0 && Puertoconexion > 10) //aFde:254d:EFA2:245c
            {
                if (Ipconexion.Length < 19)
                    TipoProtocolo = ListaBotonesProtocoloIP.Ipv4;
                else
                    TipoProtocolo = ListaBotonesProtocoloIP.Ipv6;
                RaisePropertyChanged("TipoProtocolo");
                return true;
            }
            else
            {
                if (Ipconexion.Length < 19)
                    TipoProtocolo = ListaBotonesProtocoloIP.Ipv4;
                else
                    TipoProtocolo = ListaBotonesProtocoloIP.Ipv6;
                RaisePropertyChanged("TipoProtocolo");
                //MessageBox.Show("Inconguencias al momento de guardar.\n 1. Verifique que la firma existe. \n2. Verifique que el puerto de conexion sea mayor que 10.", "Error al guardar", MessageBoxButton.OK, MessageBoxImage.Stop);
                dlg.ShowMessageAsync(this, "Inconguencias al momento de guardar.\n 1. Verifique que la firma existe. \n2. Verifique que el puerto de conexion sea mayor que 10.","");
                return false;
            }
        }
 

        public enum ListaBotonesTipoIP { IpLocal, IpPublica }
        public enum ListaBotonesProtocoloIP { Ipv4, Ipv6 }

        private bool _esConexionPrincipal;
        public bool EsConexionPrincipal
        {
            get { return _esConexionPrincipal; }
            set { _esConexionPrincipal = value; RaisePropertyChanged("EsConexionPrincipal"); }

        }

        
        private ListaBotonesTipoIP _tipoIP;
        public ListaBotonesTipoIP TipoIP
        {
            get { return _tipoIP; }
            set
            {
                _tipoIP = value;
                RaisePropertyChanged("TipoIp");
            }
        }
        private ListaBotonesProtocoloIP _tipoProtocolo;
        public ListaBotonesProtocoloIP TipoProtocolo
        {
            get { return _tipoProtocolo; }
            set
            {
                _tipoProtocolo = value;
                RaisePropertyChanged("TipoProtocolo");
            }
        } 
        #endregion


        #region Bindiados

        private string _txtBandera; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }

        #region Correos y telefonos

        private ICommand _cmdAgreCorreos_Click;
        public ICommand cmdAgreCorreos_Click
        {
            get
            {
                return _cmdAgreCorreos_Click ?? (_cmdAgreCorreos_Click = new CommandHandler(() => cmdAgreCorreos(), _canExecute));
            }
        }

        private ICommand _cmdModiCorreos_Click;
        public ICommand cmdModiCorreos_Click
        {
            get
            {
                return _cmdModiCorreos_Click ?? (_cmdModiCorreos_Click = new CommandHandler(() => cmdModifCorreos(), _canExecute));
            }
        }

        private ICommand _cmdGuardarModifCorreos_Click;
        public ICommand cmdGuardarModifCorreos_Click
        {
            get
            {
                return _cmdGuardarModifCorreos_Click ?? (_cmdGuardarModifCorreos_Click = new CommandHandler(() => cmdGuardCorreos(), _canExecute));
            }
        }

        private ICommand _cmdCancelModiCorreos_Click;
        public ICommand cmdCancelModiCorreos_Click
        {
            get
            {
                return _cmdCancelModiCorreos_Click ?? (_cmdCancelModiCorreos_Click = new CommandHandler(() => cmdCancelModifCorreos(), _canExecute));
            }
        }

        private ICommand _cmdQuitCorreos_Click;
        public ICommand cmdQuitCorreos_Click
        {
            get
            {
                return _cmdQuitCorreos_Click ?? (_cmdQuitCorreos_Click = new CommandHandler(() => cmdQuitCorreos(), _canExecute));
            }
        }

        private ICommand _cmdconfirmarCorreos_Click;
        public ICommand cmdconfirmarCorreos_Click
        {
            get
            {
                return _cmdconfirmarCorreos_Click ?? (_cmdconfirmarCorreos_Click = new CommandHandler(() => cmdConfirmarCorreos(), _canExecute));
            }
        }

        //******************************************
        private ICommand _cmdQuitTelefono_Click;
        public ICommand cmdQuitTelefono_Click
        {
            get
            {
                return _cmdQuitTelefono_Click ?? (_cmdQuitTelefono_Click = new CommandHandler(() => cmdQuitTelefono(), _canExecute));
            }
        }

        private ICommand _cmdAgreTelef_Click;
        public ICommand cmdAgreTelef_Click
        {
            get
            {
                return _cmdAgreTelef_Click ?? (_cmdAgreTelef_Click = new CommandHandler(() => cmdAgreTelef(), _canExecute));
            }
        }


        #endregion

        /*******************************************************************************************************************/
            #region v
        //dos variables para controlar las leyendas cuando los correos no estan validados.
        #region leyendas validacion correos
        private string _LeyendasValidacionesCorreos;
        public string LeyendasValidacionesCorreos
        {
            get { return _LeyendasValidacionesCorreos; }
            set
            {
                _LeyendasValidacionesCorreos = value;
                RaisePropertyChanged("LeyendasValidacionesCorreos");
            }
        }

        private Brush _colorValidacionesCorreos;
        public Brush colorValidacionesCorreos
        {
            get { return _colorValidacionesCorreos; }
            set
            {
                _colorValidacionesCorreos = value;
                RaisePropertyChanged("colorValidacionesCorreos");
            }
        } 
        #endregion


        private pais _selectedPais;
        public pais SelectedPais
        {
            get
            {
                return _selectedPais;
            }
            set
            {
                _selectedPais = value;
                RaisePropertyChanged("");
                this.PaisSeleccionado();
            }
        }

        private void PaisSeleccionado()
        {
            if (SelectedPais != null)
            {
                using (db = new SGPTEntidades())
                {
                    ListadoDepartamentos = (from d in db.departamentos where d.idpais == SelectedPais.idpais orderby d.iddepartamento select d).ToList();
                    ListadoMunicipios = null;
                }
                RaisePropertyChanged("ListadoDepartamentos");
            }
            //ListadoMunicipios = (from m in db.municipios orderby m.idmunicipio select m).ToList();
        }
        /*******************************************************************************************************************/
        private departamento _selectedDepartamento;
        public departamento SelectedDepartamento
        {
            get
            {
                return _selectedDepartamento;
            }
            set
            {
                _selectedDepartamento = value;
                RaisePropertyChanged("");
                this.DepartamentoSeleccionado();
            }
        }

        private void DepartamentoSeleccionado()
        {
            if (SelectedDepartamento != null)
            {
                using (db = new SGPTEntidades())
                {
                    ListadoMunicipios = (from m in db.municipios where m.iddepartamento == SelectedDepartamento.iddepartamento orderby m.idmunicipio select m).ToList();
                }
                RaisePropertyChanged("ListadoMunicipios");
            }

        }
        /*******************************************************************************************************************/
        private municipio _selectedMunicipio;
        public municipio SelectedMunicipio
        {
            get
            {
                return _selectedMunicipio;
            }
            set
            {
                _selectedMunicipio = value;
                RaisePropertyChanged("");
            }
        }
        /*******************************************************************************************************************/
        private UsuariosVM _selectedRepresentanteLegal;
        public UsuariosVM SelectedRepresentanteLegal
        {
            get
            {
                return _selectedRepresentanteLegal;
            }
            set
            {
                _selectedRepresentanteLegal = value;
                RaisePropertyChanged("");
            }
        }

        /*******************************************************************************************************************/
        //Binding SelectedTipoTelefono notifica cuando un valor del combobox de los tipos de telefono ha sido seleccionado
        private tipostelefono _selectedTipoTelefono;
        public tipostelefono SelectedTipoTelefono
        {
            get
            {
                return _selectedTipoTelefono;
            }
            set
            {
                _selectedTipoTelefono = value;
                RaisePropertyChanged("SelectedTipoTelefono");
            }
        }
        /************************************************/
        //Binding selectedCorreoAgregado notifica cuando un valor del combobox de los correos agregados ha sido seleccionado para eliminar
        private correo _selectedCorreoAgregado;
        public correo SelectedCorreoAgregado
        {
            get
            {
                return _selectedCorreoAgregado;
            }
            set
            {
                _selectedCorreoAgregado = value;
                RaisePropertyChanged("selectedCorreoAgregado");
                this.habilitarEdicionCorreo();
            }
        }

        //Aqui hay que controlar cuando se desea agregar un nuevo correo, ya que debe soltarse el  if(SelectedCorreoAgregado!=null)
        //**************************************************************************************************************************************************
        private void habilitarEdicionCorreo()//habilita y deshabilita los botones para modificar el correo
        {
            btnAgregarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnAgregarCorreoVisible");
            btnModificarCorreoVisible = Visibility.Visible;
            RaisePropertyChanged("btnModificarCorreoVisible");
            btnGuardarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnGuardarCorreoVisible");
            if(SelectedCorreoAgregado!=null)
            LeyendasValidacionesCorreos = SelectedCorreoAgregado.estadoverificacioncorreo;
        }

        private servidoresCorreos _SelectedServidoresComunes;
        public servidoresCorreos SelectedServidoresComunes
        {
            get
            {
                return _SelectedServidoresComunes;
            }
            set
            {
                _SelectedServidoresComunes = value;
                RaisePropertyChanged("SelectedServidoresComunes");
                this.asignarvaloresConfigCorreos();
            }
        }

        //Permite que cuando se selecciona un servidor comun en SelectedServidoresComunes, los campos asociados se llenen con sus valores respectivos
        public void asignarvaloresConfigCorreos()
        {
            PuertoCorreoT=SelectedServidoresComunes.puertocorreo;
            HostCorreosT=SelectedServidoresComunes.hostcorreo;
            SSLRequeridoChek=SelectedServidoresComunes.sslrequeridocorreo;
            RaisePropertyChanged();
        }

        /***********************************************/
        //SelectedTelefonoAgregado
        private telefonoModelo _selectedTelefonoAgregado;
        public telefonoModelo SelectedTelefonoAgregado
        {
            get
            {
                return _selectedTelefonoAgregado;
            }
            set
            {
                _selectedTelefonoAgregado = value;
                RaisePropertyChanged("selectedTelefonoAgregado");
            }
        }

        /***********************************************/

        #endregion
            /************************************************Activar y desactivar campos en la vista**********************************/
            #region Habilitadores
            /**********************Inicio Habilitadores campos TabFirma****************************************/
            /**************************************************/
            private Boolean _HabilitartxtNombreFirma;
            public Boolean HabilitartxtNombreFirma
            {
                get
                {
                    return _HabilitartxtNombreFirma;
                }
                set
                {
                    _HabilitartxtNombreFirma = value;
                    RaisePropertyChanged("HabilitartxtNombreFirma");
                }
            }
            /**************************************************/
            private Boolean _HabilitarRepresentanteLegal;
            public Boolean HabilitarRepresentanteLegal
            {
                get
                {
                    return _HabilitarRepresentanteLegal;
                }
                set
                {
                    _HabilitarRepresentanteLegal = value;
                    RaisePropertyChanged("HabilitarRepresentanteLegal");
                }
            }

            private Boolean _HabilitartxtNoCVPV;
            public Boolean HabilitartxtNoCVPV
            {
                get
                {
                    return _HabilitartxtNoCVPV;
                }
                set
                {
                    _HabilitartxtNoCVPV = value;
                    RaisePropertyChanged("HabilitartxtNoCVPV");
                }
            }
            /**************************************************/
            private Boolean _HabilitartxtNIT;
            public Boolean HabilitartxtNIT
            {
                get
                {
                    return _HabilitartxtNIT;
                }
                set
                {
                    _HabilitartxtNIT = value;
                    RaisePropertyChanged("HabilitartxtNIT");
                }
            }
            /**************************************************/
            //HabilitarNRC
            private Boolean _HabilitarNRC;
            public Boolean HabilitarNRC
            {
                get
                {
                    return _HabilitarNRC;
                }
                set
                {
                    _HabilitarNRC = value;
                    RaisePropertyChanged("HabilitarNRC");
                }
            }
            /**************************************************/
            private Boolean _HabilitarComboPaises;
            public Boolean HabilitarComboPaises
            {
                get
                {
                    return _HabilitarComboPaises;
                }
                set
                {
                    _HabilitarComboPaises = value;
                    RaisePropertyChanged("HabilitarComboPaises");
                }
            }
            /**************************************************/
            private Boolean _HabilitarDepartamento;
            public Boolean HabilitarDepartamento
            {
                get
                {
                    return _HabilitarDepartamento;
                }
                set
                {
                    _HabilitarDepartamento = value;
                    RaisePropertyChanged("HabilitarDepartamento");
                }
            }
            /**************************************************/
            private Boolean _HabilitarMunicipio;
            public Boolean HabilitarMunicipio
            {
                get
                {
                    return _HabilitarMunicipio;
                }
                set
                {
                    _HabilitarMunicipio = value;
                    RaisePropertyChanged("HabilitarMunicipio");
                }
            }
            /**************************************************/
            private Boolean _HabilitarDireccion;
            public Boolean HabilitarDireccion
            {
                get
                {
                    return _HabilitarDireccion;
                }
                set
                {
                    _HabilitarDireccion = value;
                    RaisePropertyChanged("HabilitarDireccion");
                }
            }
            /**************************************************/
            private Boolean _HabilitarPaginaWeb;
            public Boolean HabilitarPaginaWeb
            {
                get
                {
                    return _HabilitarPaginaWeb;
                }
                set
                {
                    _HabilitarPaginaWeb = value;
                    RaisePropertyChanged("HabilitarPaginaWeb");
                }
            }
            /**************************************************/
            private Boolean _HabilitardpickFechaCVPA;
            public Boolean HabilitardpickFechaCVPA
            {
                get
                {
                    return _HabilitardpickFechaCVPA;
                }
                set
                {
                    _HabilitardpickFechaCVPA = value;
                    RaisePropertyChanged("HabilitardpickFechaCVPA");
                }
            }
            /**************************************************/
            private Boolean _HabilitarTelefonos;
            public Boolean HabilitarTelefonos
            {
                get
                {
                    return _HabilitarTelefonos;
                }
                set
                {
                    _HabilitarTelefonos = value;
                    RaisePropertyChanged("HabilitarTelefonos");
                }
            }
            /**************************************************/
            private Boolean _HabilitarCorreos;
            public Boolean HabilitarCorreos
            {
                get
                {
                    return _HabilitarCorreos;
                }
                set
                {
                    _HabilitarCorreos = value;
                    RaisePropertyChanged("HabilitarCorreos");
                }
            }

            public void habilitadorCampos(bool habilitado)
            {
                HabilitartxtNombreFirma = habilitado;
                HabilitartxtNoCVPV = habilitado;
                HabilitarRepresentanteLegal = habilitado;
                HabilitartxtNIT = habilitado;
                HabilitarNRC = habilitado;
                HabilitarComboPaises = habilitado;
                HabilitarDepartamento = habilitado;
                HabilitarMunicipio = habilitado;
                HabilitarDireccion = habilitado;
                HabilitarPaginaWeb = habilitado;
                HabilitardpickFechaCVPA = habilitado;
                HabilitarTelefonos = habilitado;
                HabilitarCorreos = habilitado;
            }
            /*************************************Fin Habilitador campos*****************************/
            /**********************************Habilitador de Botones de Comando TabFirma*****************/
            /**************************************************/
            private Boolean _HabilitarBtnNuevo;
            public Boolean HabilitarBtnNuevo
            {
                get
                {
                    return _HabilitarBtnNuevo;
                }
                set
                {
                    _HabilitarBtnNuevo = value;
                    RaisePropertyChanged("HabilitarBtnNuevo");
                }
            }
            /**************************************************/
            private Boolean _HabilitarBtnModificar;
            public Boolean HabilitarBtnModificar
            {
                get
                {
                    return _HabilitarBtnModificar;
                }
                set
                {
                    _HabilitarBtnModificar = value;
                    RaisePropertyChanged("HabilitarBtnModificar");
                }
            }
            /**************************************************/
            private Boolean _HabilitarBtnLogo;
            public Boolean HabilitarBtnLogo
            {
                get
                {
                    return _HabilitarBtnLogo;
                }
                set
                {
                    _HabilitarBtnLogo = value;
                    RaisePropertyChanged("HabilitarBtnLogo");
                }
            }
            /**************************************************/
            private Boolean _HabilitarBtnGuardar;
            public Boolean HabilitarBtnGuardar
            {
                get
                {
                    return _HabilitarBtnGuardar;
                }
                set
                {
                    _HabilitarBtnGuardar = value;
                    RaisePropertyChanged("HabilitarBtnGuardar");
                }
            }
            /**************************************************/
            private Boolean _HabilitarBtnCancelar;
            public Boolean HabilitarBtnCancelar
            {
                get
                {
                    return _HabilitarBtnCancelar;
                }
                set
                {
                    _HabilitarBtnCancelar = value;
                    RaisePropertyChanged("HabilitarBtnCancelar");
                }
            }

            #endregion
        #endregion

        #region Campos
            #region Campos Firma
            #region CorreoyTelefono
            /*Estos dos campos no pertenecen a ninguna de las dos tablas, pero se agregan para bindiarlas con el List de Telefonos y de Correos
             Ya que los correos y los telefonos se guardaran despues de guardado el usuario y la persona pq necesita el id de el*/
            private string _correoT;
            private string _ContraseniaCorreoT;
            private int _PuertoCorreoT;
            private string _HostCorreosT;
            private bool _correoPrincipalChek;
            private bool _SSLRequeridoChek;

            public string CorreoT { get { return _correoT; } set { _correoT = value; RaisePropertyChanged("CorreoT"); } }
            public string ContraseniaCorreoT { get { return _ContraseniaCorreoT; } set { _ContraseniaCorreoT = value; RaisePropertyChanged("ContraseniaCorreoT"); /*SelectedCorreoAgregado = null;*/ } }
            public int PuertoCorreoT { get { return _PuertoCorreoT; } set { _PuertoCorreoT = value; RaisePropertyChanged("PuertoCorreoT"); /*SelectedCorreoAgregado = null;*/ } }
            public string HostCorreosT { get { return _HostCorreosT; } set { _HostCorreosT = value; RaisePropertyChanged("HostCorreosT"); /*SelectedCorreoAgregado = null;*/ } }
            public bool CorreoPrincipalChek { get { return _correoPrincipalChek; } set { if (CorreoPrincipalChek != value) { _correoPrincipalChek = value; RaisePropertyChanged("CorreoPrincipalChek"); /*SelectedCorreoAgregado = null;*/ } } }
            public bool SSLRequeridoChek { get { return _SSLRequeridoChek; } set { _SSLRequeridoChek = value; RaisePropertyChanged("SSLRequeridoChek"); } }

            private string _telefonoT;
            public string TelefonoT { get { return _telefonoT; } set { _telefonoT = value; RaisePropertyChanged("TelefonoT"); SelectedTelefonoAgregado = null; } }

            #endregion

            private int _idfirma;
            private int _iddepartamento;
            private int _idpais;
            private int _idmunicipio;
            private int _idusuario;
            private string _razonsocialfirma;
            private string _representantefirma;
            private string _nitfirma;
            private string _nrcfirma;
            private string _direccionfirma;
            private string _numerocvpafirma;
            private DateTime _fechainscripcioncvpafirma;
            private string _fechacreadofirma;
            private string _urlfirma;
            private byte[] _logofirma;
            private string _estadofirma;
            public int Idfirma { get { return _idfirma; } set { _idfirma = value; RaisePropertyChanged("Idfirma"); } }
            public int Iddepartamento { get { return _iddepartamento; } set { _iddepartamento = value; RaisePropertyChanged("Iddepartamento"); } }
            public int Idpais { get { return _idpais; } set { _idpais = value; RaisePropertyChanged("Idpais"); } }
            public int Idmunicipio { get { return _idmunicipio; } set { _idmunicipio = value; RaisePropertyChanged("Idmunicipio"); } }
            public int Idusuario { get { return _idusuario; } set { _idusuario = value; RaisePropertyChanged("Idusuario"); } }
            public string Razonsocialfirma { get { return _razonsocialfirma; } set { _razonsocialfirma = value; RaisePropertyChanged("Razonsocialfirma"); } }
            public string Representantefirma { get { return _representantefirma; } set { _representantefirma = value; RaisePropertyChanged("Representantefirma"); } }
            public string Nitfirma { get { return _nitfirma; } set { _nitfirma = value; RaisePropertyChanged("Nitfirma"); } }
            public string Nrcfirma { get { return _nrcfirma; } set { _nrcfirma = value; RaisePropertyChanged("Nrcfirma"); } }
            public string Direccionfirma { get { return _direccionfirma; } set { _direccionfirma = value; RaisePropertyChanged("Direccionfirma"); } }
            public string Numerocvpafirma { get { return _numerocvpafirma; } set { _numerocvpafirma = value; RaisePropertyChanged("Numerocvpafirma"); } }
            public DateTime Fechainscripcioncvpafirma { get { return _fechainscripcioncvpafirma; } set { _fechainscripcioncvpafirma = value; RaisePropertyChanged("Fechainscripcioncvpafirma"); } }
            public string Fechacreadofirma { get { return _fechacreadofirma; } set { _fechacreadofirma = value; RaisePropertyChanged("Fechacreadofirma"); } }
            public string Urlfirma { get { return _urlfirma; } set { _urlfirma = value; RaisePropertyChanged("Urlfirma"); } }
            public byte[] Logofirma { get { return _logofirma; } set { _logofirma = value; RaisePropertyChanged("Logofirma"); } }
            public string Estadofirma { get { return _estadofirma; } set { _estadofirma = value; RaisePropertyChanged("Estadofirma"); } }
            #endregion
            #region Campos Confirguracion
            private int _idconexion;
            private string _ipconexion;
            private string _tipoip;
            private bool _protocoloconexion;
            private int _puertoconexion;
            private bool _principalconexion;
            private string _estadoconexion;    

            public int Idconexion { get { return _idconexion; } set { _idconexion = value; RaisePropertyChanged("Idconexion"); } }
            //public int idfirma { get; set; }
            public string Ipconexion { get { return _ipconexion; } set { _ipconexion = value; RaisePropertyChanged("Ipconexion"); } }
            public string Tipoip { get { return _tipoip; } set { _tipoip = value; RaisePropertyChanged("Tipoip"); } }
            public bool Protocoloconexion { get { return _protocoloconexion; } set { _protocoloconexion = value; RaisePropertyChanged("Protocoloconexion"); } }
            public int Puertoconexion { get { return _puertoconexion; } set { _puertoconexion = value; RaisePropertyChanged("Puertoconexion"); } }
            public bool Principalconexion { get { return _principalconexion; } set { _principalconexion = value; RaisePropertyChanged("Principalconexion"); } }
            public string Estadoconexion { get { return _estadoconexion; } set { _estadoconexion = value; RaisePropertyChanged("Estadoconexion"); } }
            #endregion 
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public ICommand _miComanditoFirma;
        public ICommand MiComanditoFirma { get { return _miComanditoFirma ?? (_miComanditoFirma = new CommandHandler(() => MyPestañaFirma(), _canExecute)); } }

        public ICommand _miComanditoSistema;
        public ICommand MiComanditoSistema { get { return _miComanditoSistema ?? (_miComanditoSistema = new CommandHandler(() => MyPestañaSistema(), _canExecute)); } }

        
        private void MyPestañaSistema()
        {
            //ViewTypex = typeof(RolesView);
            //Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            //VistaSistema = Viewx;
            this.verificarAlcanceIPservidor();
        }

        //Este codigo sirve para capturar el evento click el el tab
        /*public UserControl Viewx { get; set; }
        public Type ViewTypex { get; set; }

        private void MyPestañaFirma()
        {
            ViewTypex = typeof(RolesView);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            VistaFirma = Viewx;
        }*/

        private void MyPestañaFirma()
        {

        }
        

        private void ObtenerDatos() //protected override void ObtenerDatos()
        {
            #region ServidoresDeCorreosComunes
            ListadoServidoresComunesCorreos = new ObservableCollection<servidoresCorreos>();
            servidoresCorreos ser = new servidoresCorreos();
            ser.nombreservidorcorreo = "Gmail.com";
            ser.hostcorreo = "smtp.gmail.com";
            ser.puertocorreo = 587;
            ser.sslrequeridocorreo = true;
            ListadoServidoresComunesCorreos.Add(ser);

            ser = null;
            ser = new servidoresCorreos();
            ser.nombreservidorcorreo = "Hotmail.com";
            ser.hostcorreo = "smtp.live.com";
            ser.puertocorreo = 465;
            ser.sslrequeridocorreo = true;
            ListadoServidoresComunesCorreos.Add(ser);

            ser = null;
            ser = new servidoresCorreos();
            ser.nombreservidorcorreo = "Outlook.com";
            ser.hostcorreo = "smtp-mail.outlook.com";
            ser.puertocorreo = 587;
            ser.sslrequeridocorreo = true;
            ListadoServidoresComunesCorreos.Add(ser);

            ser = null;
            ser = new servidoresCorreos();
            ser.nombreservidorcorreo = "Yahoo.com";
            ser.hostcorreo = "smtp.mail.yahoo.com";
            ser.puertocorreo = 465;
            ser.sslrequeridocorreo = true;
            ListadoServidoresComunesCorreos.Add(ser);
            RaisePropertyChanged("ListadoServidoresComunesCorreos"); 
            #endregion


            persona persh = new persona();
            using (db = new SGPTEntidades())
            {
                try
                {
                    #region _
                    ListadoFirmas = (from f in db.firmas orderby f.idfirma select f).ToList();
                    ListadoConexiones = (from c in db.conexiones orderby c.idconexion select c).ToList();
                    //persh = db.personas.Join(db.usuarios, p => p.idduipersona, u => u.idduipersona, (p, u) => new { personas = p, usuarios = u }).Where(uu => uu.usuarios.idusuario == usua.usuidusuario).Select(uu => uu.personas).SingleOrDefault();
                    //}
                    if (ListadoConexiones.Count() > 0)
                    {
                        #region _
                        Idconexion = ListadoConexiones[0].idconexion;
                        //Idfirma=ListadoConexiones[0].idfirma; 
                        Ipconexion = ListadoConexiones[0].ipconexion;
                        TipoIP = (ListadoConexiones[0].tipoip == "L" ? ListaBotonesTipoIP.IpLocal : ListaBotonesTipoIP.IpPublica); //(TipoIP == ListaBotonesTipoIP.IpLocal ? "L" : "P"); //(TipoIP.ToString() == "IpLocal" ? "L" : "P");
                        TipoProtocolo = (ListadoConexiones[0].protocoloconexion == true ? ListaBotonesProtocoloIP.Ipv4 : ListaBotonesProtocoloIP.Ipv6); //(TipoProtocolo == ListaBotonesProtocoloIP.Ipv4 ? true : false);
                        Puertoconexion = ListadoConexiones[0].puertoconexion;
                        Principalconexion = ListadoConexiones[0].principalconexion;
                        #endregion
                    }
                    if (ListadoFirmas.Count() > 0)
                    {
                        #region _
                        //this.inicializarListados();
                        try
                        {
                            #region _
                            ListadoCorreos = (ListadoFirmas[0].correos).ToList();
                            foreach (correo coo in ListadoCorreos) { _correos.Add(coo); }
                            var lListadoTelefonos = (ListadoFirmas[0].telefonos).ToList();
                            ListadoTelefonos = new List<telefonoModelo>();
                            foreach (telefono too in lListadoTelefonos)
                            {
                                #region _
                                _telefonos.Add(too);
                                telefonoModelo tte = new telefonoModelo();
                                tte.idtelefono = too.idtelefono;
                                tte.idtt = (int)too.idtt;
                                var b = ListadoTipoTelefono.Find(x => x.idtt == too.idtt);
                                tte.descripciontelefono = b.descripciontt;
                                tte.numerotelefono = too.numerotelefono;
                                tte.estadotelefono = too.estadotelefono;
                                ListadoTelefonos.Add(tte);
                                #endregion
                            }
                            RaisePropertyChanged("ListadoTelefonos");


                            foreach (UsuariosVM uxuar in UsuariosListado)
                            {
                                if (uxuar.TheUsuariosPersonas.idusuario == ListadoFirmas[0].idusuario)
                                {
                                    SelectedRepresentanteLegal = uxuar;
                                }
                            }

                            var P = ListadoPaises.Find(x => x.idpais == ListadoFirmas[0].idpais);
                            SelectedPais = P;

                            var D = ListadoDepartamentos.Find(y => y.iddepartamento == ListadoFirmas[0].iddepartamento);
                            SelectedDepartamento = D;


                            foreach (municipio munx in ListadoMunicipios)
                            {
                                if (munx.idmunicipio == ListadoFirmas[0].idmunicipio)
                                {
                                    SelectedMunicipio = munx;
                                }
                            }


                            //if (ListadoFirmas.Count() > 0)
                            //{
                            //carga de datos a los campos.
                            Idfirma = ListadoFirmas[0].idfirma;
                            Iddepartamento = (int)ListadoFirmas[0].iddepartamento;
                            Idpais = ListadoFirmas[0].idpais;
                            Idmunicipio = ListadoFirmas[0].idmunicipio;
                            Idusuario = (int)ListadoFirmas[0].idusuario;
                            Razonsocialfirma = ListadoFirmas[0].razonsocialfirma;
                            Representantefirma = ListadoFirmas[0].representantefirma;
                            Nitfirma = ListadoFirmas[0].nitfirma;
                            Nrcfirma = ListadoFirmas[0].nrcfirma;
                            Direccionfirma = ListadoFirmas[0].direccionfirma;
                            Numerocvpafirma = Convert.ToString(ListadoFirmas[0].numerocvpafirma);

                            if (!String.IsNullOrEmpty(ListadoFirmas[0].fechainscripcioncvpafirma))
                            {
                                Fechainscripcioncvpafirma = convierteEnFecha(ListadoFirmas[0].fechainscripcioncvpafirma);
                            }                //RaisePropertyChanged("Fechainscripcioncvpafirma");
                            Fechacreadofirma = ListadoFirmas[0].fechacreadofirma;
                            //RaisePropertyChanged("Fechacreadofirma");
                            Urlfirma = ListadoFirmas[0].urlfirma;
                            //RaisePropertyChanged("Urlfirma");
                            Logofirma = ListadoFirmas[0].logofirma; //RaisePropertyChanged("Logofirma");
                            Estadofirma = ListadoFirmas[0].estadofirma; //RaisePropertyChanged("Estadofirma");
                            /*Recuperamos la foto*/

                            #region foto1
                            //Esta ok. Lo pasare a un delegado, talvez no da error *** Ha tronado, porqe se necesita un metodo delegado para cada campo que se vaya a actualizar.
                            try
                            {
                                byte[] blob = Logofirma;
                                MemoryStream stream = new MemoryStream(blob);
                                BitmapImage bi = new BitmapImage();
                                bi.BeginInit();
                                bi.StreamSource = stream;
                                bi.EndInit();
                                myImagenFirma = new Image();
                                MyImagenFirma.Source = bi;
                                RaisePropertyChanged("MyImagenFirma");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ocurrio un error al recuperar la imagen o logotipo", "Recuperacion imagen", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            }
                            #endregion


                            #endregion

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ocurrio un error al recuperar los datos.", "Error de recuperacion de datos", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }

                        //Control de botones y campos

                        this.habilitadorCampos(false);
                        HabilitarBtnNuevo = false;
                        HabilitarBtnModificar = true;
                        HabilitarBtnCancelar = false;
                        HabilitarBtnLogo = false;
                        HabilitarBtnGuardar = false;
                        txtBandera = "0";
                        #endregion
                    }
                    else
                    {
                        //MessageBox.Show("No se han introducido los datos de la firma. Es obligatorio introducirlos, antes de generar documentacion de auditoria.", "Mucha Atencion !!!", MessageBoxButton.OK, MessageBoxImage.Stop);
                        dlg.ShowMessageAsync(this, "No se han introducido los datos de la firma. Es obligatorio introducirlos antes de poder generar documentacion de auditoria.","Mucha atencion");
                        HabilitarBtnNuevo = true;
                        HabilitarBtnCancelar = false;
                    }
                    #endregion
                }
                catch (Exception)
                {
                    MessageBox.Show("Error inesperado al recuperar los datos de la firma.","Error en la recuperacion de datos de la firma",MessageBoxButton.OK,MessageBoxImage.Stop);
                }
            }
        }


        static public DateTime convierteEnFecha(string fecha)
        {
            int tama = fecha.Length;
            String fechaRecortada;
            String cortarx = fecha.Substring((tama - 4), 4);
            if (cortarx.ToUpper() == "A.M." || cortarx.ToUpper() == "P.M.")
            {
                fechaRecortada = fecha.Substring(0, (tama - 4));
                fecha = fechaRecortada;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            DateTime Fechita = DateTime.Now;
            try
            {
                DateTime a;
                if (DateTime.TryParse(fecha, out a))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                    Fechita = Convert.ToDateTime(fecha);
                }
                else
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                    Fechita = Convert.ToDateTime(fecha);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                }
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                return Fechita;
            }
            catch
            {

                return Fechita;
            }

        }
        /*************************************************************************************************************************/
        private void inicializarListados()
        {
            ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();
            try
            {
                List<usuariospersonas> usuariosy = new List<usuariospersonas>();
                using (db = new SGPTEntidades())
                {
                    ListadoTipoTelefono = new List<tipostelefono>();
                    ListadoTipoTelefono = (from t in db.tipostelefonos orderby t.idtt select t).ToList(); // .ToList();
                    RaisePropertyChanged("ListadoTipoTelefono");
                    ListadoPaises = new List<pais>();
                    ListadoPaises = (from p in db.paises orderby p.idpais select p).ToList();
                    RaisePropertyChanged("ListadoPaises");

                    usuariosy = (from u in db.usuarios
                                 join p in db.personas
                                 on u.idduipersona equals p.idduipersona
                                 orderby p.nombrespersona
                                 select new usuariospersonas
                                 {
                                     #region
                                     idusuario = u.idusuario,
                                     //idpista = (int)u.idpista,
                                     usuidusuario = (int)(u.usuidusuario),
                                     idrol = (int)(u.idrol),
                                     //fecharegistrousuario = u.fecharegistrousuario,
                                     //fechadebaja = (u.fechadebaja),
                                     //fechacontratacion = (u.fechacontratacion),
                                     //nickusuariousuario = u.nickusuariousuario,
                                     //contraseniausuario = u.contraseniausuario,
                                     //inicialesusuario = u.inicialesusuario,
                                     //respuestapistausuario = u.respuestapistausuario,
                                     //numerocvpausuario = u.numerocvpausuario,
                                     //fechacvpausuario = (u.fechacvpausuario),
                                     estadousuario = u.estadousuario,
                                     idduipersona = p.idduipersona,
                                     //nombrespersona = p.nombrespersona,
                                     //apellidospersona = p.apellidospersona,
                                     nombreCompleto=p.nombrespersona+", "+p.apellidospersona,
                                     sexopersona = p.sexopersona,
                                     direccionpersona = p.direccionpersona,
                                     //noafppersona = p.noafppersona,
                                     //noissspersona = p.noissspersona,
                                     //nitpersona = p.nitpersona,
                                     estadopersona = p.estadopersona,
                                     //correos = (from c in db.correos where c.idduipersona == p.idduipersona && c.estadocorreo == "A" orderby c.idcorreo select c).ToList(),
                                     //telefonos = (from t in db.telefonos where t.idduipersona == p.idduipersona && t.estadotelefono == "A" orderby t.idtt select t).ToList()
                                     #endregion
                                 }).ToList();
                }
                foreach (usuariospersonas usua in usuariosy)
                {

                    //usua.nombreCompleto = usua.nombrespersona + " " + usua.apellidospersona;
                    _usuarios.Add(new UsuariosVM { TheUsuariosPersonas = usua });
                    UsuariosListados.Add(new UsuariosVM {TheUsuariosPersonas = usua });
                }
                UsuariosListado = _usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado");
            //ThrobberVisible = Visibility.Collapsed;
        }
        /**************************************************************************************************************************/
        /*Comandos para el tab Firma*/
        //Image myImagenFirma;
        Image myImagenFirma;
        public Image MyImagenFirma
        {
            get { return myImagenFirma; }
            set { myImagenFirma = value; RaisePropertyChanged("MyImagenFirma"); }
        }

        #region
        public ICommand _cmdLogoFirma_Click;
        public ICommand cmdLogoFirma_Click { get { return _cmdLogoFirma_Click ?? (_cmdLogoFirma_Click = new CommandHandler(() => MycmdLogoFirma(), _canExecute)); } }

        public ICommand _cmdNuevoFirma_Click;
        public ICommand cmdNuevoFirma_Click { get { return _cmdNuevoFirma_Click ?? (_cmdNuevoFirma_Click = new CommandHandler(() => MycmdNuevoFirma(), _canExecute)); } }

        public ICommand _cmdModificarFirma_Click;
        public ICommand cmdModificarFirma_Click { get { return _cmdModificarFirma_Click ?? (_cmdModificarFirma_Click = new CommandHandler(() => MycmdModificarFirma_Click(), _canExecute)); } }



        public ICommand _cmdGuardarFirma_Click;
        public ICommand cmdGuardarFirma_Click { get { return _cmdGuardarFirma_Click ?? (_cmdGuardarFirma_Click = new CommandHandler(() => MycmdGuardarFirma(), _canExecute)); } }

        public ICommand _cmdCancelarFirma_Click;
        public ICommand cmdCancelarFirma_Click { get { return _cmdCancelarFirma_Click ?? (_cmdCancelarFirma_Click = new CommandHandler(() => MycmdCancelarFirma(), _canExecute)); } }

        private Image LaFoto = new Image();
        private void MycmdLogoFirma()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); //Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Imagen Firma (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.FilterIndex = 1;
                if (true == fldlg.ShowDialog())
                {
                    strNombre = fldlg.SafeFileName;
                    imagenNombre = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    LaFoto.SetValue(Image.SourceProperty, isc.ConvertFromString(imagenNombre));
                    MyImagenFirma = LaFoto;
                }
                else
                {
                    //MessageBox.Show("por favor seleccione una foto desde su disco local");
                    dlg.ShowMessageAsync(this, "Por favor seleccione una foto logotipo desde su disco local", "");
                }
                //fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void MycmdNuevoFirma()
        {
            if (ListadoFirmas==null)
            {
                this.inicializarListados();
                AccionGuardar = true;
                this.habilitadorCampos(true);

                HabilitarBtnNuevo = false;
                HabilitarBtnModificar = false;
                HabilitarBtnCancelar = true;
                HabilitarBtnLogo = true;
                HabilitarBtnGuardar = true;
                txtBandera = "1";
                try
                {
                    String Ubicacion = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "SaveFoto.Bmp");
                    if (File.Exists(Ubicacion))
                        File.Delete(Ubicacion);
                }
                catch { } 
            }
            else
            {
                this.habilitadorCampos(false);
                HabilitarBtnNuevo = false;
                HabilitarBtnCancelar = false;
                HabilitarBtnLogo = false;
                HabilitarBtnGuardar = false;
                txtBandera = "0";
                HabilitarBtnModificar = true;
            }
        }
        /*********************************************************************************************************/
        private void MycmdModificarFirma_Click()
        {
            //MessageBox.Show("ModificarFirma");
            AccionGuardar = false;
            this.habilitadorCampos(true);
            HabilitartxtNIT = false; //deshabilito el NIT pq no se debe permitir modificarlo nunca
            HabilitarBtnNuevo = false;
            HabilitarBtnModificar = false;
            HabilitarBtnCancelar = true;
            HabilitarBtnLogo = true;
            HabilitarBtnGuardar = true;
            txtBandera = "1";
        }
        /**************************************************************************************************************/
        private void MycmdGuardarFirma()
        {
            if (SelectedPais != null && SelectedDepartamento != null && SelectedMunicipio != null & Razonsocialfirma != null && SelectedRepresentanteLegal != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                #region Incorporando la imagen
                if (!string.IsNullOrEmpty(imagenNombre))
                {
                    FileStream fs = new FileStream(imagenNombre, FileMode.Open, FileAccess.Read);
                    Logofirma = new byte[fs.Length];
                    fs.Read(Logofirma, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                }
                #endregion

                //firmasModelo firmasModelo = new firmasModelo();
                firma f;
                cliente c = new cliente();
                if (AccionGuardar)
                {
                    f = new firma();
                    f.idfirma = 1;

                    /*vamos a crear un registro "Oficina" en clientes para utilizarlo en los reportes de tiempos cuando son aplicables a trabajos internos*/
                    
                }
                else
                {
                    using (db = new SGPTEntidades())
                    {
                        f = db.firmas.SingleOrDefault(o => o.idfirma == Idfirma);
                    }
                }
                f.iddepartamento = SelectedDepartamento.iddepartamento;
                f.idpais = SelectedPais.idpais;
                f.idmunicipio = SelectedMunicipio.idmunicipio;
                f.idusuario = SelectedRepresentanteLegal.TheUsuariosPersonas.idusuario;
                f.razonsocialfirma = Razonsocialfirma;
                f.representantefirma = Representantefirma;
                f.nitfirma = Nitfirma;
                f.nrcfirma = Nrcfirma;
                f.direccionfirma = Direccionfirma;
                if (String.IsNullOrEmpty(Numerocvpafirma)) Numerocvpafirma = "0";
                f.numerocvpafirma = int.Parse(Numerocvpafirma);
                f.fechainscripcioncvpafirma = Fechainscripcioncvpafirma.ToShortDateString();
                f.fechacreadofirma = DateTime.Now.ToShortDateString();
                f.urlfirma = Urlfirma;
                f.logofirma = Logofirma;
                f.estadofirma = "A";
                /*Parte del cliente que no es cliente, sino la misma empresa auditora*/

                c.idnitcliente = Nitfirma;
                c.idclasificacion = 1; //Quemado persona natural
                c.iddepartamento = SelectedDepartamento.iddepartamento;
                c.idpais = SelectedPais.idpais;
                c.idmunicipio = SelectedMunicipio.idmunicipio;
                c.razonsocialcliente = "Oficina - "+Razonsocialfirma;
                c.fechaconstitucioncliente = DateTime.Now.ToShortDateString();
                c.nrccliente = Nrcfirma;
                c.direccioncliente = Direccionfirma;
                c.estadocliente = "A";


                if (AccionGuardar)
                {
                    if (ListadoCorreos != null)
                    {
                        f.correos = ListadoCorreos;
                    }
                    if (ListadoTelefonos != null)
                    {
                        f.telefonos = _telefonos.ToList(); //ListadoTelefonos;
                    }
                }

                using (db = new SGPTEntidades())
                {
                    //var existe = (from j in db.clientes where j.idnitcliente == ListadoFirmas[0].nitfirma select j).SingleOrDefault();
                    string ffidnit = ListadoFirmas[0].nitfirma;
                    cliente existe = db.clientes.SingleOrDefault(o => o.idnitcliente == ffidnit);
                    var avv = "";
                    if (existe != null) { avv = existe.idnitcliente; }
                    try
                    {
                        if (AccionGuardar)
                        {
                            db.firmas.Add(f);
                            db.SaveChanges();

                            if (string.IsNullOrEmpty(avv))
                            {
                                db.clientes.Add(c);
                                db.SaveChanges();
                            }
                        }
                        else //si es editar
                        {
                            db.Entry(f).State = EntityState.Modified;
                            db.SaveChanges();

                            if (string.IsNullOrEmpty(avv)) //si la firma no tiene un registro en cliente
                            {
                                db.clientes.Add(c);
                                db.SaveChanges();
                            }
                            else //si la firma ya tiene un registro en clientes, lo actualizamos por cualquier cosa
                            {
                                var v = db.clientes.Find(Nitfirma);

                                if (v != null)
                                {
                                    v.iddepartamento = SelectedDepartamento.iddepartamento;
                                    v.idpais = SelectedPais.idpais;
                                    v.idmunicipio = SelectedMunicipio.idmunicipio;
                                    v.razonsocialcliente = "Oficina - " + Razonsocialfirma;
                                    v.fechaconstitucioncliente = DateTime.Now.ToShortDateString();
                                    v.nrccliente = Nrcfirma;
                                    v.direccioncliente = Direccionfirma;
                                    v.estadocliente = "A";
                                    db.Entry(v).State = EntityState.Modified;
                                    db.SaveChanges();
                                }
                                //Aqui existe un problema, pq el NIT de la firma es el PK de Clientes. Entonces si el cliente cambia el NIT, hay que borrar y eso deja desreferenciado todos los reportes de tiempos que pudieran estar asociados a el
                                //db.Entry(v).State = EntityState.Modified;
                                //db.SaveChanges();
                            }
                        }

                        this.habilitadorCampos(false);

                        HabilitarBtnNuevo = false;
                        HabilitarBtnModificar = true;
                        HabilitarBtnCancelar = false;
                        HabilitarBtnLogo = false;
                        HabilitarBtnGuardar = false;
                        txtBandera = "0";
                        //MessageBox.Show("El registro de la firma fue almacenado con éxito", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                        dlg.ShowMessageAsync(this, "El registro de la firma fue almacenado con éxito!", "Finalizado.!");
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al guardar la firma. " + ex.InnerException, "Error en los datos", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                //MessageBox.Show("Falta informacion");
                dlg.ShowMessageAsync(this,"Falta informacion","");
            }
            this.MycmdGuardarConfSistema(); //Indicamos que guarde la parte de la configuracion del sistema
        }
        /***********************************************************************************************************/

        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            #region +
            await Task.Delay(segundos);
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
            #endregion
        }

        /***************************************************************************************************************/
        private void MycmdCancelarFirma()
        {
            
            #region v

            //MyImagenFirma = null;

            //Control de botones y campos

            this.habilitadorCampos(false);
            if (ListadoFirmas== null)
                HabilitarBtnNuevo = true;
            if (ListadoFirmas != null)
                HabilitarBtnModificar = true;
            HabilitarBtnCancelar = false;
            HabilitarBtnLogo = false;
            HabilitarBtnGuardar = false;
            txtBandera = "0";
            SelectedCorreoAgregado = null;
            this.cmdCancelModifCorreos();
            //MessageBox.Show("No se guardo nada.", "Cancelado", MessageBoxButton.OK, MessageBoxImage.Warning);

            #endregion
        }
        #region prueba inputBox
        //public class InputBox
        //{

        //    Window Box = new Window();//window for the inputbox
        //    FontFamily font = new FontFamily("Tahoma");//font for the whole inputbox
        //    int FontSize = 30;//fontsize for the input
        //    StackPanel sp1 = new StackPanel();// items container
        //    string title = "InputBox";//title as heading
        //    string boxcontent;//title
        //    string defaulttext = "Scrivi quì il tuo nome...";//default textbox content
        //    string errormessage = "Scelta non valida";//error messagebox content
        //    string errortitle = "Errore";//error messagebox heading title
        //    string okbuttontext = "OK";//Ok button content
        //    Brush BoxBackgroundColor = Brushes.GreenYellow;// Window Background
        //    Brush InputBackgroundColor = Brushes.Ivory;// Textbox Background
        //    bool clicked = false;
        //    TextBox input = new TextBox();
        //    Button ok = new Button();
        //    bool inputreset = false;
        //    public InputBox(string content)
        //    {
        //        try
        //        {
        //            boxcontent = content;
        //        }
        //        catch { boxcontent = "Error!"; }
        //        windowdef();
        //    }
        //    public InputBox(string content, string Htitle, string DefaultText)
        //    {
        //        try
        //        {
        //            boxcontent = content;
        //        }
        //        catch { boxcontent = "Error!"; }
        //        try
        //        {
        //            title = Htitle;
        //        }
        //        catch
        //        {
        //            title = "Error!";
        //        }
        //        try
        //        {
        //            defaulttext = DefaultText;
        //        }
        //        catch
        //        {
        //            DefaultText = "Error!";
        //        }
        //        windowdef();
        //    }
        //    public InputBox(string content, string Htitle, string Font, int Fontsize)
        //    {
        //        try
        //        {
        //            boxcontent = content;
        //        }
        //        catch { boxcontent = "Error!"; }
        //        try
        //        {
        //            font = new FontFamily(Font);
        //        }
        //        catch { font = new FontFamily("Tahoma"); }
        //        try
        //        {
        //            title = Htitle;
        //        }
        //        catch
        //        {
        //            title = "Error!";
        //        }
        //        if (Fontsize >= 1)
        //            FontSize = Fontsize;
        //        windowdef();
        //    }
        //    private void windowdef()// window building - check only for window size
        //    {
        //        Box.Height = 500;// Box Height
        //        Box.Width = 300;// Box Width
        //        Box.Background = BoxBackgroundColor;
        //        Box.Title = title;
        //        Box.Content = sp1;
        //        Box.Closing += Box_Closing;
        //        TextBlock content = new TextBlock();
        //        content.TextWrapping = TextWrapping.Wrap;
        //        content.Background = null;
        //        content.HorizontalAlignment = HorizontalAlignment.Center;
        //        content.Text = boxcontent;
        //        content.FontFamily = font;
        //        content.FontSize = FontSize;
        //        sp1.Children.Add(content);

        //        input.Background = InputBackgroundColor;
        //        input.FontFamily = font;
        //        input.FontSize = FontSize;
        //        input.HorizontalAlignment = HorizontalAlignment.Center;
        //        input.Text = defaulttext;
        //        input.MinWidth = 200;
        //        input.MouseEnter += input_MouseDown;
        //        sp1.Children.Add(input);
        //        ok.Width = 70;
        //        ok.Height = 30;
        //        ok.Click += ok_Click;
        //        ok.Content = okbuttontext;
        //        ok.HorizontalAlignment = HorizontalAlignment.Center;
        //        sp1.Children.Add(ok);

        //    }
        //    void Box_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //    {
        //        if (!clicked)
        //            e.Cancel = true;
        //    }
        //    private void input_MouseDown(object sender, MouseEventArgs e)
        //    {
        //        if ((sender as TextBox).Text == defaulttext && inputreset == false)
        //        {
        //            (sender as TextBox).Text = null;
        //            inputreset = true;
        //        }
        //    }
        //    void ok_Click(object sender, RoutedEventArgs e)
        //    {
        //        clicked = true;
        //        if (input.Text == defaulttext || input.Text == "")
        //            MessageBox.Show(errormessage, errortitle);
        //        else
        //        {
        //            Box.Close();
        //        }
        //        clicked = false;
        //    }
        //    public string ShowDialog()
        //    {
        //        Box.ShowDialog();
        //        return input.Text;
        //    }


        //}
        #endregion

        #endregion

        /**************************************************************************************************************/
        /*Gestiona los correos y los telefonos de los usuarios.*/
        #region AgregarCorreos, QuitarCorreos, AgregarTelefono,QuitarTelefono
        //Telefonos
        #region Telefonos desh
        //public void cmdAgreTelef()
        //{

        //    if (SelectedTipoTelefono != null && TelefonoT.Length >= 8 && TelefonoT.Length <= 9)
        //    {
        //        try
        //        {
        //            #region
        //            telefono telef = new telefono();
        //            if (_telefonos != null)
        //                telef.idtelefono = _telefonos.Count() + 1;
        //            else
        //                telef.idtelefono = 1;
        //            telef.idtt = SelectedTipoTelefono.idtt;
        //            telef.numerotelefono = TelefonoT;
        //            telef.estadotelefono = "A";
        //            _telefonos.Add(telef);

        //            foreach (var a in _telefonos)
        //            {
        //                telefonoModelo tte = new telefonoModelo();
        //                tte.idtelefono = a.idtelefono;
        //                tte.idtt = (int)a.idtt;
        //                var b = ListadoTipoTelefono.Find(x => x.idtt == a.idtt);
        //                tte.descripciontelefono = b.descripciontt;
        //                tte.numerotelefono = a.numerotelefono;
        //                tte.estadotelefono = a.estadotelefono;
        //                ListadoTelefonos.Add(tte);
        //            }
        //            //ListadoTelefonos = _telefonos.ToList();

        //            RaisePropertyChanged("ListadoTelefonos");
        //            MessageBox.Show("Telefono agregado.", "Finalizado..", MessageBoxButton.OK, MessageBoxImage.Information);
        //            TelefonoT = "";
        //            SelectedTipoTelefono = null;
        //            RaisePropertyChanged("TelefonoT");
        //            if (!AccionGuardar) //Entonces es Editar
        //            {
        //                //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
        //                using (db = new SGPTEntidades())
        //                {
        //                    try
        //                    {
        //                        db.telefonos.Add(telef);
        //                        db.SaveChanges();
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
        //                    }
        //                }
        //            }
        //            #endregion
        //        }
        //        catch (System.Exception ex)
        //        {
        //            MessageBox.Show("Ocurrio un error al agregar el telefono. Verifique el campo DUI tenga valor" + ex, "Falta de Datos", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI.", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        //    }
        //}
        //private void cmdQuitTelefono()
        //{
        //    //TimeSpan interval;
        //    //string value = "5.001";

        //    //TimeSpan.TryParseExact(value, "ss\\.fff", null, out interval);
        //    //Window owner = CreateAutoCloseWindow(interval);
        //    //MessageBoxResult result = MessageBox.Show(owner, "hola camaleon");
        //    if (SelectedTelefonoAgregado != null && true)
        //    {
        //        var tp = _telefonos.Find(x => x.idtelefono == SelectedTelefonoAgregado.idtelefono && x.numerotelefono == SelectedTelefonoAgregado.numerotelefono && x.idtt == SelectedTelefonoAgregado.idtt);
        //        if (!AccionGuardar) //Entonces es Editar
        //        {
        //            //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
        //            using (db = new SGPTEntidades())
        //            {
        //                try
        //                {
        //                    tp.estadotelefono = "B";//SelectedTelefonoAgregado.estadotelefono = "B"; //le cambiamos el estado a Borrado logico.
        //                    db.Entry(tp).State = EntityState.Modified;
        //                    db.SaveChanges();
        //                }
        //                catch (Exception ex)
        //                {
        //                    MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
        //                }
        //            }
        //        }
        //        //telefono to = 

        //        _telefonos.Remove(tp);
        //        ListadoTelefonos = null;
        //        ListadoTelefonos = new List<telefonoModelo>();
        //        foreach (var a in _telefonos)
        //        {
        //            telefonoModelo tte = new telefonoModelo();
        //            tte.idtelefono = a.idtelefono;
        //            tte.idtt = (int)a.idtt;
        //            var b = ListadoTipoTelefono.Find(x => x.idtt == a.idtt);
        //            tte.descripciontelefono = b.descripciontt;
        //            tte.numerotelefono = a.numerotelefono;
        //            tte.estadotelefono = a.estadotelefono;
        //            ListadoTelefonos.Add(tte);
        //        }
        //        //ListadoTelefonos = _telefonos.ToList();
        //        RaisePropertyChanged("ListadoTelefonos");
        //    }

        //} 
        #endregion
        public async void cmdAgreTelef()
        {
            //bool noencontrado = _telefonos.Exists(x => x.numerotelefono == SelectedTelefonoAgregado.numerotelefono);
            //if (noencontrado)
            //{
            if (SelectedTipoTelefono != null && TelefonoT.Length >= 8 && TelefonoT.Length <= 9)
            {
                bool encontrado = _telefonos.Exists(x => x.numerotelefono == TelefonoT);
                if (!encontrado)
                {
                    #region +
                    try
                    {
                        #region
                        telefono telef = new telefono();
                        if (_telefonos != null)
                            telef.idtelefono = _telefonos.Count() + 1;
                        else
                            telef.idtelefono = 1;
                        telef.idtt = SelectedTipoTelefono.idtt;
                        telef.numerotelefono = TelefonoT;
                        telef.estadotelefono = "A";
                        _telefonos.Add(telef);

                        foreach (var a in _telefonos)
                        {
                            telefonoModelo tte = new telefonoModelo();
                            tte.idtelefono = a.idtelefono;
                            tte.idtt = (int)a.idtt;
                            var b = ListadoTipoTelefono.Find(x => x.idtt == a.idtt);
                            tte.descripciontelefono = b.descripciontt;
                            tte.numerotelefono = a.numerotelefono;
                            tte.estadotelefono = a.estadotelefono;
                            ListadoTelefonos.Add(tte);
                        }
                        //ListadoTelefonos = _telefonos.ToList();

                        RaisePropertyChanged("ListadoTelefonos");
                        //MessageBox.Show("Telefono agregado.", "Finalizado..", MessageBoxButton.OK, MessageBoxImage.Information);
                        await dlg.ShowMessageAsync(this,"Telefono agregado","Finalizado.");
                        TelefonoT = "";
                        SelectedTipoTelefono = null;
                        RaisePropertyChanged("TelefonoT");
                        if (!AccionGuardar) //Entonces es Editar
                        {
                            //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                            using (db = new SGPTEntidades())
                            {
                                try
                                {
                                    db.telefonos.Add(telef);
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                        }
                        #endregion
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al agregar el telefono. Verifique el campo DUI tenga valor" + ex, "Falta de Datos", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    #endregion
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El numero de telefono ya existe", "");


                }
            }
            else
            {
                //MessageBox.Show("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI.", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                await dlg.ShowMessageAsync(this, "Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI", "Falta informacion");
            }
            //}
        }
        private void cmdQuitTelefono()
        {
            //TimeSpan interval;
            //string value = "5.001";

            //TimeSpan.TryParseExact(value, "ss\\.fff", null, out interval);
            //Window owner = CreateAutoCloseWindow(interval);
            //MessageBoxResult result = MessageBox.Show(owner, "hola camaleon");
            if (SelectedTelefonoAgregado != null && true)
            {
                var tp = _telefonos.Find(x => x.idtelefono == SelectedTelefonoAgregado.idtelefono && x.numerotelefono == SelectedTelefonoAgregado.numerotelefono && x.idtt == SelectedTelefonoAgregado.idtt);
                if (!AccionGuardar) //Entonces es Editar
                {
                    //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            tp.estadotelefono = "B";//SelectedTelefonoAgregado.estadotelefono = "B"; //le cambiamos el estado a Borrado logico.
                            db.Entry(tp).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }
                //telefono to = 

                _telefonos.Remove(tp);
                ListadoTelefonos = null;
                ListadoTelefonos = new List<telefonoModelo>();
                foreach (var a in _telefonos)
                {
                    telefonoModelo tte = new telefonoModelo();
                    tte.idtelefono = a.idtelefono;
                    tte.idtt = (int)a.idtt;
                    var b = ListadoTipoTelefono.Find(x => x.idtt == a.idtt);
                    tte.descripciontelefono = b.descripciontt;
                    tte.numerotelefono = a.numerotelefono;
                    tte.estadotelefono = a.estadotelefono;
                    ListadoTelefonos.Add(tte);
                }
                //ListadoTelefonos = _telefonos.ToList();
                RaisePropertyChanged("ListadoTelefonos");
            }

        }
        //correos
        
        //botones visibles
        #region Visibilidad botones correos
        private Visibility _btnAgregarCorreoVisible;
        public Visibility btnAgregarCorreoVisible
        {
            get { return _btnAgregarCorreoVisible; }
            set { _btnAgregarCorreoVisible = value; RaisePropertyChanged("btnAgregarCorreoVisible"); }
        }

        private Visibility _btnGuardarCorreoVisible;
        public Visibility btnGuardarCorreoVisible
        {
            get { return _btnGuardarCorreoVisible; }
            set { _btnGuardarCorreoVisible = value; RaisePropertyChanged("btnGuardarCorreoVisible"); }
        }

        private Visibility _btnModificarCorreoVisible;
        public Visibility btnModificarCorreoVisible
        {
            get { return _btnModificarCorreoVisible; }
            set { _btnModificarCorreoVisible = value; RaisePropertyChanged("btnModificarCorreoVisible"); }
        }

        private Visibility _btnCancelModificarCorreoVisible;
        public Visibility btnCancelModificarCorreoVisible
        {
            get { return _btnCancelModificarCorreoVisible; }
            set { _btnCancelModificarCorreoVisible = value; RaisePropertyChanged("btnCancelModificarCorreoVisible"); }
        }

        private bool _btnCancelModificarCorreoActivado;
        public bool btnCancelModificarCorreoActivado
        {
            get { return _btnCancelModificarCorreoActivado; }
            set { _btnCancelModificarCorreoActivado = value; RaisePropertyChanged("btnCancelModificarCorreoActivado"); }
        }

        //btnQuitCorreosVisible
        private Visibility _btnQuitCorreosVisible;
        public Visibility btnQuitCorreosVisible
        {
            get { return _btnQuitCorreosVisible; }
            set { _btnQuitCorreosVisible = value; RaisePropertyChanged("btnQuitCorreosVisible"); }
        }
        private bool _btnQuitCorreosHabilitado;
        public bool btnQuitCorreosHabilitado
        {
            get { return _btnQuitCorreosHabilitado; }
            set { _btnQuitCorreosHabilitado = value; RaisePropertyChanged("btnQuitCorreosHabilitado"); }
        }
        #endregion

        private async void cmdAgreCorreos() //Permite agregar un nuevo correo
        {
            if (CorreoT != null && CorreoT.Length >= 7 && CorreoT.Length <= 30)
            {
                bool correoencontrado = _correos.Exists(y => y.direccioncorreo == CorreoT);
                if (!correoencontrado)
                {
                    Random rnd = new Random();
                    try
                    {
                        #region
                        correo Corre = new correo();
                        Corre.idcorreo = rnd.Next(1000, 10000);
                        Corre.idfirma = Idfirma;
                        Corre.direccioncorreo = CorreoT;
                        Corre.principalcorreo = CorreoPrincipalChek;
                        Corre.estadocorreo = "A";
                        Corre.contraseniacorreo = ratpirc(ContraseniaCorreoT);
                        Corre.hostcorreo = HostCorreosT;
                        Corre.puertocorreo = PuertoCorreoT;
                        Corre.sslrequeridocorreo = SSLRequeridoChek;
                        Corre.codigosolicitadocorreo = generarCodigoComprobacion(10);
                        Corre.estadoverificacioncorreo = "No verificado";

                        if (!AccionGuardar) //Entonces es Editar
                        {
                            //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                            using (db = new SGPTEntidades())
                            {
                                try
                                {
                                    db.correos.Add(Corre);
                                    db.SaveChanges();

                                    _correos.Add(Corre);
                                    ListadoCorreos = _correos.ToList();
                                    //MessageBox.Show("Correo agregado.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                    await dlg.ShowMessageAsync(this,"Correo agregado","Finalizado.");
                                    CorreoPrincipalChek = false; //reiniciamos para que quede deshabilitado
                                    CorreoT = "";
                                    ContraseniaCorreoT = "";
                                    HostCorreosT = "";
                                    PuertoCorreoT = 0;
                                    SSLRequeridoChek = false;
                                    RaisePropertyChanged("");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocurrio un error al actualizar el registro" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                        }
                        #endregion
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al agregar el Correo. " + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    } 
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El correo ya existe", "");
                }
            }
            else
            {
                //MessageBox.Show("Ingrese un correo valido...", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                await dlg.ShowMessageAsync(this, "Ingrese un correo valido...", "Falta informacion");
            }
        }
        //cuenteuno
        private void cmdModifCorreos() //permite la edicion de un correo
        {
            btnAgregarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnAgregarCorreoVisible");
            btnModificarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnModificarCorreoVisible");
            btnGuardarCorreoVisible = Visibility.Visible;
            RaisePropertyChanged("btnGuardarCorreoVisible");
            //btnQuitCorreosVisible = Visibility.Hidden;
            btnQuitCorreosHabilitado = false;
            //btnCancelModificarCorreoVisible = Visibility.Visible;

            //RaisePropertyChanged("btnCancelModificarCorreoVisible");
            btnCancelModificarCorreoActivado = true;

            CorreoT = SelectedCorreoAgregado.direccioncorreo;
            ContraseniaCorreoT = "*******";
            PuertoCorreoT= SelectedCorreoAgregado.puertocorreo>0?(int)SelectedCorreoAgregado.puertocorreo:0;
            HostCorreosT = SelectedCorreoAgregado.hostcorreo;
            CorreoPrincipalChek = SelectedCorreoAgregado.principalcorreo!=null?(bool)SelectedCorreoAgregado.principalcorreo:false ;
            SSLRequeridoChek = SelectedCorreoAgregado.sslrequeridocorreo!=null?(bool)SelectedCorreoAgregado.sslrequeridocorreo:false ;

        }

        private void cmdCancelModifCorreos()
        {
            //MessageBox.Show("Cancelar");
            SelectedCorreoAgregado = null;
            btnAgregarCorreoVisible = Visibility.Visible;
            RaisePropertyChanged("btnAgregarCorreoVisible");
            btnModificarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnModificarCorreoVisible");
            btnGuardarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnGuardarCorreoVisible");
            //btnQuitCorreosVisible =Visibility.Visible;
            //RaisePropertyChanged("btnQuitCorreosVisible");
            btnQuitCorreosHabilitado = true;
            //btnCancelModificarCorreoVisible = Visibility.Hidden;
            //RaisePropertyChanged("btnCancelModificarCorreoVisible");
            btnCancelModificarCorreoActivado = false;

            CorreoT = null;
            ContraseniaCorreoT = null;
            PuertoCorreoT = 0;
            HostCorreosT = null;
            CorreoPrincipalChek = false;
            SSLRequeridoChek = false;
        }
        private void cmdGuardCorreos() //permite guardar los cambios de la modificacion del correo
        {
            if (SelectedCorreoAgregado != null)
            {
                if (!AccionGuardar) //Entonces es Editar
                {
                    //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            _correos.Remove(SelectedCorreoAgregado);
                            SelectedCorreoAgregado.direccioncorreo = CorreoT;
                            if (ContraseniaCorreoT != "*******")
                                SelectedCorreoAgregado.contraseniacorreo = ratpirc(ContraseniaCorreoT);
                            SelectedCorreoAgregado.puertocorreo = PuertoCorreoT;
                            SelectedCorreoAgregado.hostcorreo = HostCorreosT;
                            SelectedCorreoAgregado.principalcorreo = CorreoPrincipalChek;
                            SelectedCorreoAgregado.sslrequeridocorreo = SSLRequeridoChek;
                            SelectedCorreoAgregado.codigosolicitadocorreo = generarCodigoComprobacion(10);
                            SelectedCorreoAgregado.estadoverificacioncorreo = "No verificado";
                            db.Entry(SelectedCorreoAgregado).State = EntityState.Modified;
                            db.SaveChanges();
                            _correos.Add(SelectedCorreoAgregado);
                            ListadoCorreos = _correos.ToList();
                            //MessageBox.Show("Cambios almacenados correctamente.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            dlg.ShowMessageAsync(this,"Cambios almacenados correctamente","Finalizado.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }


                RaisePropertyChanged("");
            }
            //MessageBox.Show("GuardarCorreo");
            CorreoPrincipalChek = false; //reiniciamos para que quede deshabilitado
            CorreoT = "";
            ContraseniaCorreoT = "";
            HostCorreosT = "";
            PuertoCorreoT = 0;
            SSLRequeridoChek = false;
            RaisePropertyChanged("");
            SelectedCorreoAgregado = null;
            btnAgregarCorreoVisible = Visibility.Visible;
            RaisePropertyChanged("btnAgregarCorreoVisible");
            btnModificarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnModificarCorreoVisible");
            btnGuardarCorreoVisible = Visibility.Hidden;
            RaisePropertyChanged("btnGuardarCorreoVisible");
            //btnQuitCorreosVisible = Visibility.Visible;
            btnQuitCorreosHabilitado = true;

            //btnCancelModificarCorreoVisible = Visibility.Hidden;
            //RaisePropertyChanged("btnCancelModificarCorreoVisible");
            btnCancelModificarCorreoActivado = false;
        }

        private void cmdConfirmarCorreos() //permite la confirmacion del correo con codigo de comprobacion
        {
           // MessageBox.Show("Confirmar correo");
            //string a = Microsoft.VisualBasic.Interaction.InputBox("Que numero introdujo?", "Introduzca la respuesta", "introduzca un numero");
            //MessageBox.Show("Valor introducido es " + a, "nada");
            
            //MessageBox.Show(mensajito);


            if (SelectedCorreoAgregado != null)
            {
                string correoDirigidoA = SelectedCorreoAgregado.direccioncorreo;
                string correoHostEmisor = SelectedCorreoAgregado.direccioncorreo;
                string contrasena = ircnEseD(SelectedCorreoAgregado.contraseniacorreo);
                string titulo = "Confirmacion de correo electronico";
                string cuerpo = "\n \t\t*** Confirmacion de correo electronico. ***.\n\nEnviado a las: "+DateTime.Now.ToString()+" \n\nCopie y pegue el siguiente codigo en la ventana que lo solicite. \n\nCuide de no agregar espacios en blanco.\n\n\t\t  Codigo: => \t" + SelectedCorreoAgregado.codigosolicitadocorreo;
                int puerto = (int)SelectedCorreoAgregado.puertocorreo;
                string host= SelectedCorreoAgregado.hostcorreo;
                bool sslOk = (bool)SelectedCorreoAgregado.sslrequeridocorreo;

                var mensajero = new EnviameElEmailCamaleon();
                bool enviado = mensajero.EnviarEmail(correoDirigidoA, correoHostEmisor,Razonsocialfirma, contrasena, titulo, cuerpo, puerto, host, sslOk);
                if (enviado)
                {
                    #region *
                    //MessageBox.Show("Se ha enviado a su correo un codigo, el cual tendra que introducir en la siguiente cuadro", "Confirme el codigo recibido", MessageBoxButton.OK, MessageBoxImage.Information);
                    dlg.ShowMessageAsync(this, "Se ha enviado a su correo un codigo, el cual tendra que introducir en la siguiente cuadro", "Confirme el codigo recibido");
                    var mensajito = new InputBox();
                    string aas = mensajito.windowdefinic("Ingrese los diez digitos", "Ingrese el numero que recibio en su correo", "Codigo de confirmacion", Brushes.DarkCyan);
                    if (aas != null)
                    {
                        if (aas == SelectedCorreoAgregado.codigosolicitadocorreo)
                        {
                            #region /
                            if (!AccionGuardar) //Entonces es Editar
                            {
                                //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                                using (db = new SGPTEntidades())
                                {
                                    try
                                    {
                                        SelectedCorreoAgregado.codigoverificadocorreo = aas; //adjuntamos el codigo introducido
                                        SelectedCorreoAgregado.estadoverificacioncorreo = "Verificado";
                                        SelectedCorreoAgregado.principalcorreo = true;
                                        db.Entry(SelectedCorreoAgregado).State = EntityState.Modified;
                                        db.SaveChanges();
                                        //MessageBox.Show("El codigo recibido es correcto y queda validado el correo: " + SelectedCorreoAgregado.direccioncorreo, "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                        dlg.ShowMessageAsync(this, "El codigo recibido es correcto y el correo queda validado" + SelectedCorreoAgregado.direccioncorreo, "Finalizado.");
                                        _correos = null;
                                        _correos = new List<correo>();
                                        foreach (var a in ListadoCorreos)
                                        {
                                            _correos.Add(a);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        MessageBox.Show("Ocurrio un error al actualizar.\nNo fue posible guardar la confirmacion del correo porque la base de datos tardo en responder.", "Error de almacenamiento", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    }
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            //MessageBox.Show("El codigo introducido es Invalido. El correo queda sin confirmarse: " + SelectedCorreoAgregado.direccioncorreo, "Codigo incorrecto.", MessageBoxButton.OK, MessageBoxImage.Warning);
                            dlg.ShowMessageAsync(this,"El codigo introducido es Invalido. El correo queda sin confirmarse: " + SelectedCorreoAgregado.direccioncorreo,"Codigo correcto");
                        }
                    } 
                    #endregion
                }
                else //entonces el correo es invalido
                {
                    #region _
                    if (!AccionGuardar) //Entonces es Editar
                    {
                        //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                        using (db = new SGPTEntidades())
                        {
                            try
                            {
                                #region _
                                SelectedCorreoAgregado.estadoverificacioncorreo = "Invalido";
                                SelectedCorreoAgregado.principalcorreo = false;
                                db.Entry(SelectedCorreoAgregado).State = EntityState.Modified;
                                db.SaveChanges();
                                //MessageBox.Show(SelectedCorreoAgregado.direccioncorreo + ".  El correo introducido es Invalido. El correo queda marcado como invalido. Pruebe modificar sus valores y vuelva a intentarlo", "Correo inexistente.", MessageBoxButton.OK, MessageBoxImage.Warning);
                                dlg.ShowMessageAsync(this, SelectedCorreoAgregado.direccioncorreo + ".  El correo introducido es Invalido. El correo queda marcado como invalido. Pruebe modificar sus valores y vuelva a intentarlo", "Correo inexistente.");
                                _correos = null;
                                _correos = new List<correo>();
                                foreach (var a in ListadoCorreos)
                                {
                                    _correos.Add(a);
                                }
                                ListadoCorreos = _correos.ToList();
                                #endregion
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Ocurrio un error al actualizar. \nNo fue posible guardar la confirmacion del correo porque la base de datos tardo en responder.", "Error de almacenamiento", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                    }  
                    #endregion
                }

                ////_correos.Remove(SelectedCorreoAgregado);
                //ListadoCorreos = _correos.ToList();
                RaisePropertyChanged("");
            }
            else 
            { 
                //MessageBox.Show("Seleccione el correo que desea confirmar","Confirmacion de correos",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                dlg.ShowMessageAsync(this,"Seleccione el correo que desea confirmar","Confirmacion de correos.-");
            } 
        }


        private void cmdQuitCorreos() //permite eliminar un correo
        {
            if (SelectedCorreoAgregado != null)
            {
                if (!AccionGuardar) //Entonces es Editar
                {
                    //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            SelectedCorreoAgregado.estadocorreo = "B"; //le cambiamos el estado a Borrado logico.
                            db.Entry(SelectedCorreoAgregado).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al quitar el correo\nPorque la base de datos tardo demasiado en responder\nSi el error continua, informe a soporte tecnico. " + ex.InnerException, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }
                _correos.Remove(SelectedCorreoAgregado);
                ListadoCorreos = _correos.ToList();
                RaisePropertyChanged("");
            }
        }


        #region cadenaverificacionAleatoria
        private static Random aleatorio = new Random();
        public static string generarCodigoComprobacion(int longitud)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, longitud).Select(s => s[aleatorio.Next(s.Length)]).ToArray());
        }

        #endregion

        //ratpirc, ircnEseD
        #region >
        #region .
        public static byte[] ratpirc(string _cAee)
        {
                byte[] bytes = new byte[_cAee.Length * sizeof(char)];
                System.Buffer.BlockCopy(_cAee.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
        }
        #endregion

        #region _
        public static string ircnEseD(byte[] _cAdd)
        {
            if (_cAdd!=null)
            {
                char[] chars = new char[_cAdd.Length / sizeof(char)];
                System.Buffer.BlockCopy(_cAdd, 0, chars, 0, _cAdd.Length);
                return new string(chars); 
            }
            else{
                string chars="";
                return chars;
            }
            
        }
        #endregion 
        #endregion
        #endregion


        /**************Parte Backup***************************************************************************/
        #region Parte Backup
        private string _Nombre_Base = string.Empty;
        public string Nombre_Base
        {
            get { return _Nombre_Base; }
            set { _Nombre_Base = value; RaisePropertyChanged("Nombre_Base"); }
        }
        private string _Nombre_Base_Defecto;
        public string Nombre_Base_Defecto{
            get{return _Nombre_Base_Defecto;}
            set{_Nombre_Base_Defecto=value; RaisePropertyChanged("Nombre_Base_Defecto");}
        }
        StringBuilder Str_Ruta_Dump = new StringBuilder();
        public static NpgsqlConnection Coneccion = new NpgsqlConnection();
        public static String Cadena = String.Empty;
        String Ruta_Dump = String.Empty;

        //public static NpgsqlConnection Coneccion;
        //public static String Cadena;
        public static Boolean Bandera;
        public static Int32 Num;
        public static StringBuilder Modificable;
        public static StreamWriter Escribe_Sequencia;
        #region Credenciales

        private string _IP;
        private string _USUARIO;
        private string _PASS;

        public string IP
        {
            get{return _IP;}
            set{_IP=value;}
        }
        public string USUARIO
        {
            get{return _USUARIO;}
            set{_USUARIO=value;}
        }
 
        public string PASS
        {
            get { return _PASS; }
            set{_PASS=value;}
        }
        #endregion

        string Install_Localizado = String.Empty;
        System.Data.DataView LstDatos = new System.Data.DataView();
        public List<String> LstDatox { get; set; }


        private Conexion _SelectedConexionBakup;
        public Conexion SelectedConexionBakup
        {
            get{return _SelectedConexionBakup;}
            set { _SelectedConexionBakup = value; RaisePropertyChanged("SelectedConexionBakup"); }
        }

        private string _SelectedNombreBase;
        public string SelectedNombreBase
        {
            get { return _SelectedNombreBase; }
            set { _SelectedNombreBase = value; RaisePropertyChanged("SelectedNombreBase"); this.asignarnombre(); }
        }

        private void asignarnombre()
        {
            if (SelectedNombreBase != null)
                Nombre_Base = SelectedNombreBase;
            else
                Nombre_Base = String.Empty;
        }
        private string _txtRutaGuardarBackup;
        public string txtRutaGuardarBackup
        {
            get { return _txtRutaGuardarBackup; }
            set { _txtRutaGuardarBackup = value; RaisePropertyChanged("txtRutaGuardarBackup"); }
        }

        private string _txtRutaBuscarBackup;
        public string txtRutaBuscarBackup
        {
            get { return _txtRutaBuscarBackup; }
            set { _txtRutaBuscarBackup = value; RaisePropertyChanged("txtRutaBuscarBackup"); }
        }

        #region Habilitadores 
        private bool _HabilitarDesconectarBase;
        public bool HabilitarDesconectarBase
        {
            get { return _HabilitarDesconectarBase; }
            set { _HabilitarDesconectarBase = value; RaisePropertyChanged("HabilitarDesconectarBase"); }
        }

        private bool _HabilitarConectarBase;
        public bool HabilitarConectarBase
        {
            get { return _HabilitarConectarBase; }
            set { _HabilitarConectarBase = value; RaisePropertyChanged("HabilitarConectarBase"); }
        }
        //HabilitarExaminarRestaurar
        private bool _HabilitarExaminarGuardar;
        public bool HabilitarExaminarGuardar
        {
            get { return _HabilitarExaminarGuardar; }
            set { _HabilitarExaminarGuardar = value; RaisePropertyChanged("HabilitarExaminarGuardar"); }
        }
        private bool _HabilitarExaminarRestaurar;
        public bool HabilitarExaminarRestaurar
        {
            get { return _HabilitarExaminarRestaurar; }
            set { _HabilitarExaminarRestaurar = value; RaisePropertyChanged("HabilitarExaminarRestaurar"); }
        }

        //HabilitarRestaurarBakap
        private bool _HabilitarRestaurarBakap;
        public bool HabilitarRestaurarBakap
        {
            get { return _HabilitarRestaurarBakap; }
            set { _HabilitarRestaurarBakap = value; RaisePropertyChanged("HabilitarRestaurarBakap"); }
        }

        private bool _HabilitarCrearBakap;
        public bool HabilitarCrearBakap
        {
            get { return _HabilitarCrearBakap; }
            set { _HabilitarCrearBakap = value; RaisePropertyChanged("HabilitarCrearBakap"); }
        }
        #endregion



        private string _txtPostgresVerificar;
        public string txtPostgresVerificar
        {
            get { return _txtPostgresVerificar; }
            set
            {
                _txtPostgresVerificar = value;
                RaisePropertyChanged("txtPostgresVerificar");
            }
        }

        private string _lblubicacion;
        public string lblubicacion
        {
            get { return _lblubicacion; }
            set { _lblubicacion = value; RaisePropertyChanged("lblubicacion"); }
        }

        public ICommand _MiComanditoBackap;
        public ICommand MiComanditoBackap { get { return _MiComanditoBackap ?? (_MiComanditoBackap = new CommandHandler(() => MyPestañaBackup(), _canExecute)); } }

        private async void MyPestañaBackup()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            HabilitarCrearBakap = false;
            HabilitarRestaurarBakap = false;
            HabilitarExaminarGuardar = false;
            HabilitarExaminarRestaurar = false;
            HabilitarConectarBase = false;
            HabilitarDesconectarBase = false;
            
            //Ojo esta es la conexion en la cual esta operando el sistema actual.
            var caden = System.Configuration.ConfigurationManager.ConnectionStrings["SGPTEntidades"];
            //var caden2 = "metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;provider=Npgsql;provider connection string=\"Application Name=Sgpt;Database=SGPT;Host=ec2-52-206-62-65.compute-1.amazonaws.com;Password=Pa$$w0rd;Username=postgres\"";
            string[] cadens = caden.ToString().Split(';');
            string[] datab = cadens[3].Split('=');
            string[] serve = cadens[4].Split('=');
            string[] passw = cadens[5].Split('=');
            string[] usuar = cadens[6].Split('=');

            /****************************************************************/
            string Base = datab[1];
            string Server = serve[1];//"ec2-52-206-62-65.compute-1.amazonaws.com";
            //string Puerto = "5432";
            string Usuario = usuar[1]; //"postgres";
            Usuario = Usuario.Substring(0, Usuario.Length - 1);
            string Pass = passw[1];//"Pa$$w0rd";
            //string connString = "Server= " + Server + "; port=5432; Database =" + Base + "; User id=" + Usuario + "; password= " + Pass;
            ListadoConexionesBakup=new List<Conexion>();
            Conexion cnx = new Conexion();
            if(Server=="localhost" || Server=="127.0.0.1") //esta conectado a la base local
            {
                cnx = new Conexion();
                cnx.descripcion="Base de Datos local";
                cnx.id=1;
                cnx.Base=Base;
                cnx.Servidor=Server;
                cnx.Usuario=Usuario;
                cnx.Pass=Pass;
                ListadoConexionesBakup.Add(cnx);
                RaisePropertyChanged("ListadoConexionesBakup");
                //SelectedConexionBakup = ListadoConexionesBakup[0]; //SelectedConexionBakup = cnx;
                //RaisePropertyChanged("SelectedConexionBakup");
                IP = "127.0.0.1";
                USUARIO = "sgpt";
                PASS = "sgpt2016";
                Puertoconexion=5432;
                

                if(Ipconexion!="localhost" || Ipconexion!="127.0.0.1" || !string.IsNullOrEmpty(Ipconexion)) //esta conectado a la base local
                {
                    bool Bandera = await this.Conectar(Ipconexion, "programador1", "Pa$$w0rd");
                    if (Bandera)
                    {
	                	cnx = new Conexion();
                        cnx.descripcion="Base de datos servidor";
                        cnx.id=2;
                        cnx.Base="SGPT";
                        cnx.Servidor=Ipconexion;
                        cnx.Usuario="programador1";
                        cnx.Pass="Pa$$w0rd";
                        ListadoConexionesBakup.Add(cnx); 
                        this.MycmdDesConectarABase();
	                }
                }

            }
            else //esta conectado al servidor. (Base de datos centralizada.)
            {
                cnx = new Conexion();
                cnx.descripcion="Base de Datos Servidor";
                cnx.id=1;
                cnx.Base=Base;
                cnx.Servidor=Server;
                cnx.Usuario=Usuario;
                cnx.Pass=Pass;
                ListadoConexionesBakup.Add(cnx);
                RaisePropertyChanged("ListadoConexionesBakup");
                SelectedConexionBakup=ListadoConexionesBakup.Find(x=>x.id==1);
                //RaisePropertyChanged("SelectedConexionBakup");
                IP = Server;
                USUARIO = Usuario;
                PASS = Pass;
                Puertoconexion=5432;

                bool Bandera = await this.Conectar("127.0.0.1", "sgpt", "sgpt2016");
                if (Bandera)
                {
                    cnx = new Conexion();
                    cnx.descripcion="Base de Datos local";
                    cnx.id=2;
                    cnx.Base="SGPT";
                    cnx.Servidor="127.0.0.1";
                    cnx.Usuario="sgpt";
                    cnx.Pass="sgpt2016";
                    ListadoConexionesBakup.Add(cnx);
                    RaisePropertyChanged("ListadoConexionesBakup");
                    this.MycmdDesConectarABase();
                }
            }
            RaisePropertyChanged("ListadoConexionesBakup");
            SelectedConexionBakup = ListadoConexionesBakup[0]; //SelectedConexionBakup = cnx;
            RaisePropertyChanged("SelectedConexionBakup");
            //habilitar
            //IP = "127.0.0.1";
            //USUARIO = "sgpt";
            //PASS = "sgpt2016";
            //Puertoconexion=5432;
            Mouse.OverrideCursor = null;
            this.Obtener_Conexion();
        }

        #region comanditos CrearRestaurar
        //cmdUbicacionAGuardar
        private ICommand _cmdUbicacionAGuardar;
        public ICommand cmdUbicacionAGuardar { get { return _cmdUbicacionAGuardar ?? (_cmdUbicacionAGuardar = new CommandHandler(() => this.ExaminarRespaldar(), _canExecute)); } }


        private ICommand _cmdUbicacionRestaurar;
        public ICommand cmdUbicacionRestaurar { get { return _cmdUbicacionRestaurar ?? (_cmdUbicacionRestaurar = new CommandHandler(() => this.ExaminarRestaurar(), _canExecute)); } }


        private ICommand _cmdCrearBackup;
        public ICommand cmdCrearBackup { get { return _cmdCrearBackup ?? (_cmdCrearBackup = new CommandHandler(() => MycmdCrearBackup(), _canExecute)); } }

        private async void MycmdCrearBackup()
        {
            //Nombre_Base = "SGPT";
            #region +
                    try
                    {
                        #region +
                        if (String.IsNullOrEmpty(SelectedNombreBase))
                        {
                            //MessageBox.Show("Seleccione La Lista Y La Base De Datos Que Va Respaldar Ó Si Esta Vacia Restaurese Una Nueva", "Bakup y Restauracion SGPT");
                            await AvisaYCerrateVosSolo("Seleccione de la lista la Base De Datos que desea respaldar."+Environment.NewLine+"Si la lista esta vacia, restaure Una Nueva", "Bakup y Restauracion SGPT",2);
                            return;
                        }
                        if (String.IsNullOrEmpty(txtRutaGuardarBackup))
                        {
                            //MessageBox.Show("Seleccione 'Guardar copia en:' para obtener la Ubicación donde se guardara Esta Base De Datos", "Bakup y Restauracion SGPT");
                            await AvisaYCerrateVosSolo("Seleccione 'Guardar copia en:' para obtener la Ubicación donde se guardara Esta Base De Datos", "Ruta para guardar Backup", 2);
                            return;
                        }
                        if (SelectedNombreBase != null && SelectedNombreBase.Trim() != "SGPT")
                        {
                            await AvisaYCerrateVosSolo("No esta permitido realizar Backups de Bases ajenas a SGPT.","Asegurese que el nombre de la base sea SGPT",2);
                            return;
                        }
                        Modificable = new StringBuilder(Ruta_Dump);

                        //MessageBoxResult Resultad_Final = MessageBox.Show("Deseas Obtener Copia De Seguridad De La Base De Datos " + Nombre_Base.ToString() + "", "Bakup y Restauracion SGPT", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        //if (Resultad_Final == MessageBoxResult.Yes)

                        var mySettingsk = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Acepto",
                            NegativeButtonText = "No",
                        };
                        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Desea obtener copia de seguridad de La base de datos " + Nombre_Base.ToString() + " ?", "Atencion: El proceso puede demorar segun los siguientes escenarios:"+Environment.NewLine+"Si es base de datos local, entre 15 y 30 minutos."+Environment.NewLine+"Si es base de datos del servidor, entre 50 minutos y 1:30 horas."+Environment.NewLine+"Si no dispone de suficiente tiempo y conexion electrica directa, aborte el proceso.", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                        if (resultk == MessageDialogResult.Affirmative)
                        {
                            #region +
                            if (Modificable.Length != 0)
                            {
                                #region +
                                Mouse.OverrideCursor = Cursors.Wait;
                                Escribe_Sequencia = new StreamWriter("DBBackup.bat");
                                Environment.SetEnvironmentVariable("PGPASSWORD", PASS);
                                Modificable.Append("pg_dump.exe  --host " + IP + " --port " + Puertoconexion + " --username " + USUARIO + " --format custom --blobs --verbose --file ");

                                Modificable.Append("\"" + txtRutaGuardarBackup + "\"");
                                Modificable.Append(" \"" + Nombre_Base + "\r\n\r\n");
                                Escribe_Sequencia.WriteLine(Modificable);
                                Escribe_Sequencia.Dispose();
                                Escribe_Sequencia.Close();
                                //this.Show();
                                //Ejecutar.Kill();
                                System.Diagnostics.Process Procesando = System.Diagnostics.Process.Start("DBBackup.bat");
                                do
                                { }
                                while (!Procesando.HasExited);
                                {
                                    Mouse.OverrideCursor = null;
                                    await AvisaYCerrateVosSolo("Se Realizo éxitosamente un Backup de seguridad de la Base De Datos " + Nombre_Base +Environment.NewLine+ " En La Carpeta " + txtRutaGuardarBackup + "", "Bakup y Restauracion SGPT",4);
                                    txtRutaGuardarBackup="";
                                    SelectedNombreBase = null;
                                    Nombre_Base = "";
                                }
                                #endregion
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("No esta conectado a ninguna base de datos!", "Bakup y Restauracion SGPT",1);
                            }

                            #endregion
                        }
                        else
                        {
                            txtRutaGuardarBackup="";
                            SelectedNombreBase = null;
                            Nombre_Base = "";
                        }
                        #endregion

                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }

                    #endregion
        }

        //cmdRestaurarBackup
        private ICommand _cmdRestaurarBackup;
        public ICommand cmdRestaurarBackup { get { return _cmdRestaurarBackup?? (_cmdRestaurarBackup= new CommandHandler(() => MycmdRestaurarBackup(), _canExecute)); } }

        private async void MycmdRestaurarBackup()
        {
            #region +
                    try
                    {
                        #region +
                        if (String.IsNullOrEmpty(txtRutaBuscarBackup))
                        {
                            await AvisaYCerrateVosSolo("Seleccione el Archivo Backup que va a restaurar", "Restauracion de Copias de seguridad SGPT",2);
                            return;
                        }
                        bool si = true;
                        if (si)//(Ch_Databases.IsChecked == true)
                        {
                            Nombre_Base = "SGPT";//TxtNombreDatabase.Text;
                        }
                        else
                        {
                            //Nota: no le vamos a permitir que pueda subir bases de datos con nombres diferentes a SGPT
                            #region +
                            //if (SelectedNombreBase!= null)
                            //{
                            //    Nombre_Base = SelectedNombreBase; //((System.Data.DataRowView)LstDatos.SelectedItem as System.Data.DataRowView).Row.ItemArray[0].ToString();
                            //}
                            //else
                            //{
                            //    Nombre_Base = "";
                            //}
                            #endregion
                        }
                        if (!string.IsNullOrEmpty(Nombre_Base))
                        {
                            #region +
                            if (txtRutaBuscarBackup != "")
                            {
                                #region +
                                //MessageBoxResult Resultad_Final = MessageBox.Show("Deseas Restaurar Esta Base De Datos Con El Nombre " + Nombre_Base.ToString() + "", "Bakup y Restauracion SGPT", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                //if (Resultad_Final == MessageBoxResult.Yes)
                                //{
                                var mySettingsk = new MetroDialogSettings()
                                {
                                    AffirmativeButtonText = "Acepto",
                                    NegativeButtonText = "No",
                                };
                                MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Deseas Restaurar Esta Base De Datos Con El Nombre " + Nombre_Base + " ?", "Atencion: El nombre de la Base de datos importada, sera modificado a SGPT", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                                if (resultk == MessageDialogResult.Affirmative)
                                {
                                    #region +
                                    //TxtNombreDatabase.IsReadOnly = true;
                                    Nombre_Base_Defecto="SGPT";
                                    Modificable = new StringBuilder(Ruta_Dump);
                                    if (Modificable.Length != 0)
                                    {
                                        #region +
                                        Mouse.OverrideCursor = Cursors.Wait;
                                        Escribe_Sequencia = new StreamWriter("DBRestore.bat");
                                        await Base_Datos_Existe_Crear(Nombre_Base);
                                        Environment.SetEnvironmentVariable("PGPASSWORD", PASS);
                                        Modificable.Append("pg_restore.exe --host " + IP + " --port " + Puertoconexion + " --username " + USUARIO+ " --dbname");
                                        Modificable.Append(" \"" + Nombre_Base + "\"");
                                        Modificable.Append(" --verbose ");
                                        Modificable.Append("\"" + txtRutaBuscarBackup + "\"");
                                        Escribe_Sequencia.WriteLine(Modificable);
                                        Escribe_Sequencia.Dispose();
                                        Escribe_Sequencia.Close();

                                        System.Diagnostics.Process Procesando = System.Diagnostics.Process.Start("DBRestore.bat");
                                        do
                                        { }
                                        while (!Procesando.HasExited);
                                        {
                                            Mouse.OverrideCursor = null;
                                            await AvisaYCerrateVosSolo("Restauracion éxitosa De Base De Datos " + Nombre_Base + " Seleccionado Desde " + txtRutaBuscarBackup + "", "Bakup y Restauracion SGPT",3);
                                            txtRutaBuscarBackup="";
                                            SelectedNombreBase = null;
                                            Nombre_Base = "";
                                            this.Obtener_Bases("0");
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por Favor Vuelva A Conectarse o Compre La Siguiente Version!", "Bakup y Restauracion SGPT");
                                    }
                                    #endregion
                                }
                                else
                                {
                                    txtRutaBuscarBackup="";
                                    SelectedNombreBase= null;
                                    Nombre_Base = "";
                                    //Ch_Databases.IsChecked = false;
                                    //TxtNombreDatabase.Clear();
                                    //Ch_Databases.Visibility = System.Windows.Visibility.Collapsed;
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            //MessageBox.Show("Porfavor Seleccione La Base De Datos De La Lista Para Remplazarlo Por Esta Ó Click En Check Al Lado Del Boton Restaurar Y Escriba Un Nombre Para Esta Nueva Base De Datos O Llame A su Proveedor Y Consulte La Siguiente Version", "Bakup y Restauracion SGPT");
                            await AvisaYCerrateVosSolo("Porfavor Seleccione La Base De Datos De La Lista Para Remplazarlo Por Esta O Llame A su Proveedor Y Consulte La Siguiente Version", "Bakup y Restauracion SGPT", 3);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }

                    #endregion
        }

        #endregion

        private ICommand _cmdDesConectarABase;
        public ICommand cmdDesConectarABase { get { return _cmdDesConectarABase ?? (_cmdDesConectarABase = new CommandHandler(() => MycmdDesConectarABase(), _canExecute)); } }

        private async void MycmdDesConectarABase()
        {
            #region +
            if (Coneccion.State == System.Data.ConnectionState.Open)
                Coneccion.Close();

            if (Coneccion.State != System.Data.ConnectionState.Open)
            {
                lblubicacion = "¡Desconectado Correctamente";
                LstDatox = null;
                LstDatox = new List<string>();
                RaisePropertyChanged("LstDatox");
                HabilitarConectarBase = true;
                HabilitarDesconectarBase = false;
                HabilitarExaminarRestaurar = false;
                HabilitarExaminarGuardar = false;
                HabilitarCrearBakap = false;
                HabilitarRestaurarBakap = false;
                txtRutaBuscarBackup = string.Empty;
                txtRutaGuardarBackup = string.Empty;
                lblubicacion = string.Empty;
                SelectedConexionBakup = null;
            }
            else
            {
                lblubicacion = "¡No fue posible desconectarse!";
                //HabilitarConectarBase = true;
                //HabilitarDesconectarBase = false;
                //HabilitarExaminarRestaurar = false;
                //HabilitarExaminarGuardar = false;
                //HabilitarCrearBakap = false;
                //HabilitarRestaurarBakap = false;
                //txtRutaBuscarBackup = string.Empty;
                //txtRutaGuardarBackup = string.Empty;
                //lblubicacion = string.Empty;
                //SelectedConexionBakup = null;
               await AvisaYCerrateVosSolo("No se pudo Desconectar...","",1);

            }

            #endregion
        }

        private ICommand _cmdConectarABase;
        public ICommand cmdConectarABase { get { return _cmdConectarABase ?? (_cmdConectarABase = new CommandHandler(() => MycmdConectarABase(), _canExecute)); } }

        private async void MycmdConectarABase()
        {
            if (SelectedConexionBakup != null)
            {
                IP = SelectedConexionBakup.Servidor;
                USUARIO = SelectedConexionBakup.Usuario;
                PASS = SelectedConexionBakup.Pass;
                Puertoconexion = 5432;
                this.Obtener_Conexion();
                HabilitarConectarBase = false;
                HabilitarDesconectarBase = true;
            }
            else
                await AvisaYCerrateVosSolo("Seleccione la conexion que desea utilizar.","",1);
        }

        private async void Obtener_Conexion()
        {
            #region +
                    string Obtener_Version = "postgresql-9.1";
                    String Cse = Comprobar_Si_Existe(ref Obtener_Version);
                    this.txtPostgresVerificar = Obtener_Version;
                    if (Cse == "Si")
                    {
                        #region +

                        //lblpostgresql.Content = "Si Se Encuentra Instalado " + Txtpostgresq.Text + "";
                        
                        bool Bandera = await this.Conectar(IP, USUARIO, PASS);
                        if (Bandera)
                        {
                            #region +
                            this.Obtener_Bases("0");
                            lblubicacion = "Conectado a: " + IP+" Usuario: "+USUARIO;

                            Mouse.OverrideCursor = Cursors.Wait;
                            PG_Dump_Ruta_Exe();
                            Mouse.OverrideCursor = null;

                            HabilitarDesconectarBase=true;
                            HabilitarConectarBase=false;
                            await AvisaYCerrateVosSolo("Conectado...","",1);
                            #endregion
                        }
                        else
                        {
                            #region +
                            lblubicacion = "Imposible conectarse a " + IP;
                            HabilitarConectarBase = true;
                            HabilitarDesconectarBase = false;
                            HabilitarExaminarRestaurar = false;
                            HabilitarExaminarGuardar = false;
                            HabilitarCrearBakap = false;
                            HabilitarRestaurarBakap = false;
                            await AvisaYCerrateVosSolo("No se pudo establecer la conexion con la base de datos...", "Asegurese que la base de datos este disponible.", 2);
                            #endregion
                        }
                        #endregion
                    }
                    else if (Cse == "No")
                    {
                        //lblpostgresql.Content = "No Se Encuentra Instalado " + Txtpostgresq.Text + "";
                        txtPostgresVerificar = "No se encuentra instalado PostgreSql " + txtPostgresVerificar;
                        await AvisaYCerrateVosSolo("No se encuentra instalado PostgreSql v. 9x", "Lea el manual del usuario para continuar.",2);
                        //Color_2();
                    }
                    else if (Cse == "Denegado")
                    {
                        txtPostgresVerificar = "Acceso Denegado Ejecute Como Administrador " + txtPostgresVerificar +"";
                        await AvisaYCerrateVosSolo("Acceso Denegado Ejecute Como Administrador " + txtPostgresVerificar, "", 2);

                        //Color_2();
                    } 
                    #endregion
            GC.Collect();
        }
        private async void PG_Dump_Ruta_Exe()
        {
            await AvisaYCerrateVosSolo("Buscando ruta de pg_dump...","",1);
            #region MyRegion
            try
            {
                if (Str_Ruta_Dump.Length == 0)
                {
                    if (Ruta_Dump == String.Empty)
                    {
                        Ruta_Dump = Buscar_Archivo_Dump("pg_dump.exe");
                        if (Ruta_Dump == String.Empty)
                        {
                            MessageBox.Show("Postgres no está instalado");
                            return;
                        }
                    }
                    int a = Ruta_Dump.IndexOf(":\\", 0);
                    a = a + 2;
                    String strSub = Ruta_Dump.Substring(0, (a - 2));
                    Ruta_Dump = Ruta_Dump.Substring(a, (Ruta_Dump.Length - a));

                    StringBuilder SbS_B1 = new StringBuilder(Ruta_Dump);
                    SbS_B1.Replace("\\", "\r\n\r\ncd ");

                    StringBuilder SbS_B2 = new StringBuilder("cd /D ");
                    SbS_B2.Append(strSub);
                    SbS_B2.Append(":\\");

                    SbS_B1 = SbS_B2.Append(SbS_B1);
                    SbS_B1 = SbS_B1.Remove((SbS_B1.Length - 3), 3);
                    Str_Ruta_Dump = SbS_B1;
                    Ruta_Dump = SbS_B1.ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); } 
            #endregion
        }
        public String Comprobar_Si_Existe(ref string Version)
        {
            //await AvisaYCerrateVosSolo("Comprobando existencia de postgresql 9x...", "", 1);
            #region +
            try
            {
                String clave_Regedit = @"SOFTWARE\PostgreSQL\Installations\" + Version.ToString() + "";
                RegistryKey Rbk_Clave = Registry.LocalMachine;
                Rbk_Clave = Rbk_Clave.OpenSubKey(@clave_Regedit, true);
                if (Rbk_Clave == null)
                {
                    String Rbk_Clave_2 = @"SOFTWARE\Wow6432Node\PostgreSQL\Installations\" + Version.ToString() + "";
                    Rbk_Clave = Registry.LocalMachine;
                    Rbk_Clave = Rbk_Clave.OpenSubKey(@Rbk_Clave_2, true);
                    if (Rbk_Clave == null)
                    {
                        ServiceController[] Servicios = ServiceController.GetServices();
                        foreach (ServiceController Nomb_Serv in Servicios)
                        {
                            if (Nomb_Serv.ServiceName.Contains("postgresql") == true)
                            {
                                Version = Nomb_Serv.ServiceName.ToString();
                                return "Si";
                            }
                        }
                        return "No";
                    }
                    else
                    { return "Si"; }
                }
                else
                {
                    return "Si";
                }
            }
            catch (Exception ex)
            { Console.WriteLine("No tiene Permisos Siga Adelante", ex.Message.ToString()); return "Denegado"; } 
            #endregion
        }
        private String Buscar_Archivo_Dump(String Nombre_Archivo)
        {
            #region +
            //sirve para encontrar en la pc el archivo dump.exe, el cual ejecuta las instrucciones de postgresql. De no encontrarse, todo es en vano.
            String Cadena_Ruta_Dump = String.Empty;
            try
            {
                DriveInfo[] Drives = DriveInfo.GetDrives();
                foreach (DriveInfo Drive in Drives)
                {
                    Cadena_Ruta_Dump = Realizar_Busqueda_Archivo(Drive.Name, Nombre_Archivo);
                    if (Cadena_Ruta_Dump.Length != 0)
                        break;
                }

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            return Cadena_Ruta_Dump; 
            #endregion
        }
        private String Realizar_Busqueda_Archivo(String DirName, String NombreArchivo)
        {
            #region +
            try
            {
                if (Ruta_Dump.Length == 0)
                {
                    try
                    {
                        foreach (String Directorio in Directory.GetDirectories(DirName))
                        {
                            System.Security.Permissions.FileIOPermission ReadPermission =
                                new System.Security.Permissions.FileIOPermission(System.Security.Permissions.FileIOPermissionAccess.Write, Directorio);

                            var Permisos = new System.Security.PermissionSet(System.Security.Permissions.PermissionState.None);
                            Permisos.AddPermission(ReadPermission);
                            Boolean Conceder = Permisos.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet);

                            if (Conceder)
                            {
                                try
                                {
                                    foreach (String dfile in Directory.GetFiles(Directorio, NombreArchivo))
                                    {
                                        Ruta_Dump = Directorio + "\\";
                                        if (Ruta_Dump.Length > 0)
                                        {
                                            Install_Localizado = Ruta_Dump;
                                            break;
                                        }
                                    }
                                    if (Ruta_Dump.Length == 0)
                                        Realizar_Busqueda_Archivo(Directorio, NombreArchivo);
                                }
                                catch (Exception ex)
                                { Console.WriteLine("Carpeta No da Permiso, Siga A delante", ex.Message.ToString()); }
                            }
                            else { MessageBox.Show("No permite"); }
                            if (Ruta_Dump != string.Empty)
                                break;
                        }
                    }
                    catch (Exception ex)
                    { Console.WriteLine("No Permiso Siga A delante", ex.Message.ToString()); }

                }

            }
            catch (Exception ex)
            { Console.WriteLine("No Permiso Siga A delante", ex.Message.ToString()); }
            return Ruta_Dump; 
            #endregion
        }
        public static String Comprobar_Si_ExistePostgreSql(string Version)
        {
            #region +
            try
            {
                #region +
                String clave_Regedit = @"SOFTWARE\PostgreSQL\Installations\" + Version.ToString() + "";
                RegistryKey Rbk_Clave = Registry.LocalMachine;
                Rbk_Clave = Rbk_Clave.OpenSubKey(@clave_Regedit, true);
                if (Rbk_Clave == null)
                {
                    String Rbk_Clave_2 = @"SOFTWARE\Wow6432Node\PostgreSQL\Installations\" + Version.ToString() + "";
                    Rbk_Clave = Registry.LocalMachine;
                    Rbk_Clave = Rbk_Clave.OpenSubKey(@Rbk_Clave_2, true);
                    if (Rbk_Clave == null)
                    {
                        ServiceController[] Servicios = ServiceController.GetServices();
                        foreach (ServiceController Nomb_Serv in Servicios)
                        {
                            if (Nomb_Serv.ServiceName.Contains("postgresql") == true)
                            {
                                Version = Nomb_Serv.ServiceName.ToString();
                                return "Si";
                            }
                        }
                        return "No";
                    }
                    else
                    { return "Si"; }
                }
                else
                {
                    return "Si";
                }
                #endregion
            }
            catch (Exception ex)
            { Console.WriteLine("No Permiso Siga A delante", ex.Message.ToString()); return "Denegado"; } 
            #endregion
        }

        private async void ExaminarRestaurar()
        {
            #region +
            try
            {
                //TxtRuta.Text = String.Empty;
                txtRutaBuscarBackup = String.Empty;
                OpenFileDialog OpenFileDialog = new OpenFileDialog();
                OpenFileDialog.Title = "Seleccione El Archivo A Restaurar";
                OpenFileDialog.Filter = "backup files|*.backup";
                OpenFileDialog.RestoreDirectory = true;
                if (OpenFileDialog.ShowDialog() == true)
                {
                    SelectedNombreBase = null;
                    Nombre_Base = "";
                    txtRutaBuscarBackup = OpenFileDialog.FileName;

                }
                else
                {
                    await AvisaYCerrateVosSolo("No se selecciono el destino.", "Intentelo nuevamente.", 2);
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); } 
            #endregion
        }
        
        private async void ExaminarRespaldar()
        {
            #region +
            try
            {
                if (SelectedNombreBase == null)
                {
                    await AvisaYCerrateVosSolo("Seleccione De La Lista La Base De Datos Que Va Respaldar Ó Si Esta Vacia Restaurese Una Nueva", "Bakup y Restauracion SGPT", 2);
                    //TxtRuta.Text = String.Empty;

                    return;
                }
                SaveFileDialog Guardar_Archivo = new SaveFileDialog();
                Guardar_Archivo.Title = "Ubicar La Ruta Donde Guardar esta copia";
                Guardar_Archivo.Filter = "Backup File|*.backup";
                Guardar_Archivo.FilterIndex = 0;
                Guardar_Archivo.RestoreDirectory = true;
                string dia = DateTime.Now.Day.ToString();
                string mes = DateTime.Now.Month.ToString();
                string año = DateTime.Now.Year.ToString();
                string hora = DateTime.Now.TimeOfDay.ToString("hh\\.mm\\.ss\\.ffffff"); //DateTime.Now.TimeOfDay.ToString();
                String Obtengo_Nombre = Nombre_Base.Trim() + "_" + dia + mes + año + "_" + hora;
                Guardar_Archivo.FileName = Obtengo_Nombre;
                if (Guardar_Archivo.ShowDialog() == true)
                {
                    txtRutaGuardarBackup = Guardar_Archivo.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            #endregion
        }
        #endregion

        /************************************************************************************************/
        #region Metodos
        public async Task<Boolean> Conectar(string Server, string Usuario, string Contraseña)
        {
            await AvisaYCerrateVosSolo("Intentando conectar...","",1);
            #region +
            if (Server.ToString() == "" || Server.ToString() == null)
            {
                await AvisaYCerrateVosSolo("Ingrese Su Servidor o Ip De Su Computadora", "Bakup y Restauracion SGPT", 2);
                return false;
            }
            else if (Usuario.ToString() == "" || Usuario.ToString() == null)
            {
                await AvisaYCerrateVosSolo("Ingrese Su Usuario de base de datos Asignado", "Bakup y Restauracion SGPT", 2);
                return false;
            }
            else if (Contraseña.ToString() == "" || Contraseña.ToString() == null)
            {
                await AvisaYCerrateVosSolo("Ingrese Su Contraseña", "Bakup y Restauracion SGPT", 2);
                return false;
            }
            else
            {
                //Objetos.Objetos.Cadena = "";
                Cadena = "";
                Cadena = "Server=" + Server.ToString() + ";Port=5432;Database=postgres;User id=" + Usuario.ToString() + ";Password=" + Contraseña.ToString() + ";";
                //Objetos.Objetos.Cadena = "Server=" + Server.ToString() + ";Port=5432;Database=SGPT;User id=" + Usuario.ToString() + ";Password=" + Contraseña.ToString() + ";";

                try
                {
                    Coneccion = new NpgsqlConnection(Cadena);
                    Coneccion.Open();
                    //if (boton.Content.ToString() == "Conectar")
                    //{ Coneccion.Open(); }
                    //else
                    //{ Coneccion.Close(); }


                    if (Coneccion.State != System.Data.ConnectionState.Open)
                    {
                        lblubicacion = "¡Desconectado Correctamente";
                        HabilitarConectarBase = true;
                        HabilitarDesconectarBase = false;
                        HabilitarExaminarRestaurar = false;
                        HabilitarExaminarGuardar = false;
                        HabilitarCrearBakap = false;
                        HabilitarRestaurarBakap = false;
                        return false;
                    }
                    else
                    {
                        lblubicacion = "¡Conectado Correctamente";
                        HabilitarConectarBase = false;
                        HabilitarDesconectarBase = true;
                        HabilitarExaminarRestaurar = true;
                        HabilitarExaminarGuardar = true;
                        HabilitarCrearBakap = true;
                        HabilitarRestaurarBakap = true;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Mouse.OverrideCursor = null;
                    lblubicacion = "!No Se Puede Conectar!";
                    Console.WriteLine("No Se Encuentran Bases De Datos", ex.Message.ToString());
                    return false;
                }
            }
            
            #endregion
        }

        public async void Obtener_Bases(string Num)
        {
            await AvisaYCerrateVosSolo("Buscando Bases de datos existentes...", "", 1);
            #region +
            System.Data.DataSet Dts = new System.Data.DataSet();
            try
            {

                String Cadenax = "";

                //Dts = Obtener_Datos("SELECT datname FROM pg_database WHERE datistemplate IS FALSE AND datallowconn IS TRUE AND datname!='postgres' AND datname ILIKE 'db'||'%';");

                if (Num == "0")
                {
                    Cadenax = "SELECT datname FROM pg_database WHERE datistemplate IS FALSE AND datallowconn IS TRUE AND datname!='postgres';";
                }
                else
                {
                    //Cadena = "SELECT usename FROM pg_user WHERE usename ILIKE '" + Num.ToString() + "'||'%' ;";
                }
                Dts = Obtener_Datos(Cadenax);

                LstDatox = new List<string>();
                if (Dts.Tables[0].Rows.Count > 0)
                {
                    //return Dts;
                    LstDatos = Dts.Tables[0].DefaultView;
                    foreach (DataRowView i in LstDatos)
                    {
                        string Nombre_Basex = ((System.Data.DataRowView)i as System.Data.DataRowView).Row.ItemArray[0].ToString();
                        LstDatox.Add(Nombre_Basex);
                    }
                    RaisePropertyChanged("LstDatox");
                    SelectedNombreBase = LstDatox.Find(x => x == "SGPT");
                    if (SelectedNombreBase == null)
                        await AvisaYCerrateVosSolo("No posee ninguna Base de Datos SGPT en ese nodo IP", "Cargue una base de datos, para continuar.", 2);
                }
                else
                {
                    //return Dts;
                }
            }
            catch (Exception ex)
            { Console.WriteLine("No Se Encuentran Bases De Datos", ex.Message.ToString()); }

            //return Dts; 
            #endregion
        }
        public System.Data.DataSet Obtener_Datos(String Cadenax)
        {
            #region +
            System.Data.DataSet objDataSet = new System.Data.DataSet();
            try
            {
                {
                    Coneccion = new NpgsqlConnection(Cadena);
                }

                NpgsqlDataAdapter Objeto_Adaptador = new NpgsqlDataAdapter(Cadenax, Coneccion);
                Objeto_Adaptador.Fill(objDataSet);
                return objDataSet;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("No Se Encuentran Bases De Datos", ex.Message.ToString());
                //await AvisaYCerrateVosSolo("No Se Encuentran Bases De Datos.", "" + ex.InnerException,2);
                this.exception1(ex);
                objDataSet = null;
                return objDataSet;
            } 
            #endregion
        }

        private async void exception1(Exception ex)
        {
            await AvisaYCerrateVosSolo("No Se Encuentran Bases De Datos.", "" + ex.InnerException, 2);
        }

        public async Task<bool> Eliminar_Base_Datos(String Nombre_Database)
        {
            await AvisaYCerrateVosSolo("Eliminando...","",1);
            //String str = "select pg_terminate_backend(procpid) from pg_stat_activity where datname='" + Nombre_Database + "'";
            //nota para postgresql >=9.3.1 el proceso se llama solo pid
            String str = "select pg_terminate_backend(pid) from pg_stat_activity where datname='" + Nombre_Database + "'";
            Ejecutar_Consulta(str);
            String Eliminar = "drop database \"" + Nombre_Database + "\" ";
            Boolean N = Ejecutar_Consulta(Eliminar);
            if (N) { return true; } else { return false; }
        }

        public async Task<bool> Base_Datos_Existe_Crear(String Nombre_Database)
        {
            await AvisaYCerrateVosSolo("Creando...","",1);
            #region +
            try
            {
                String Listado = "SELECT datname FROM pg_database WHERE datistemplate IS FALSE AND datallowconn IS TRUE AND datname!='postgres';";
                System.Data.DataSet ds = new System.Data.DataSet();
                ds = Obtener_Datos(Listado);
                bool Database_Existe = false;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i][0].ToString() == Nombre_Database)
                    {
                        Database_Existe = true;
                        break;
                    }
                }
                if (Database_Existe)
                {
                    String str = "select pg_terminate_backend(pid) from pg_stat_activity where datname='" + Nombre_Database + "'";
                    Ejecutar_Consulta(str);
                    String Eliminar = "drop database \"" + Nombre_Database + "\" ";
                    Ejecutar_Consulta(Eliminar);
                    String Crear = "create database \"" + Nombre_Database + "\" ";
                    Ejecutar_Consulta(Crear);
                    return true;
                }
                else
                {
                    String str = "create database \"" + Nombre_Database + "\" ";
                    Ejecutar_Consulta(str);
                    System.Threading.Thread.Sleep(1000);
                    return true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            } 
            #endregion
        }

        public bool Ejecutar_Consulta(String Accion)
        {
            #region MyRegion
            bool Estado = false;
            try
            {
                Coneccion = new NpgsqlConnection(Cadena);
                int Contador = 0;

                try
                {
                    if (Coneccion.State != System.Data.ConnectionState.Open)
                        Coneccion.Open();
                    if (Coneccion.State == System.Data.ConnectionState.Open)
                    {
                        NpgsqlCommand Comando = new NpgsqlCommand(Accion, Coneccion);
                        Contador = Comando.ExecuteNonQuery();
                        if (Contador == -1) { Estado = true; }
                        else { Estado = false; }

                    }
                    if (Coneccion.State == System.Data.ConnectionState.Open)
                    { Coneccion.Close(); }

                    if (Coneccion != null)
                    { Coneccion.Dispose(); }
                }
                catch (Exception ex)
                {
                    Estado = false;

                    if (Coneccion.State == System.Data.ConnectionState.Open)
                    { Coneccion.Close(); }

                    if (Coneccion != null)
                    { Coneccion.Dispose(); }

                    MessageBox.Show(System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(ex.Message.ToString()), "Bakup y Restauracion SGPT");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(ex.Message.ToString()) + " !NO SE PUEDE REALIZAR LA ACCÓN!", "Bakup y Restauracion SGPT"); }
            return Estado; 
            #endregion
        }
        #endregion
    }
}

