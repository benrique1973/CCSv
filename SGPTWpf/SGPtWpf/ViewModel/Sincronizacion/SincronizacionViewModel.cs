using MahApps.Metro.Controls.Dialogs;
//Libreria indispensable para realizar la validacion de can executa.
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Linq;
using SGPTWpf.Model;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.ViewModel;
using CapaDatos;
using SGPTWpf.Messages.Administracion.Usuario;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading.Tasks;
using Npgsql;
using System.Windows;
using System.Data;

namespace SGPTWpf.SGPtWpf.ViewModel.Sincronizacion
{
    public sealed class SincronizacionViewModel : ViewModeloBase
    {
        public SGPTEntidades db = new SGPTEntidades();
        public static NpgsqlConnection Coneccion = new NpgsqlConnection();
        public static String Cadena = String.Empty;
        public enum ListaBotonesTipoIP { IpLocal, IpPublica }

        private bool _chkSubirCambiosRecientes;
        private bool _chkSincroizarCatalogos;
        private bool _chkSincronizacionCompleta;

        public bool chkSubirCambiosRecientes
        {
            get { return _chkSubirCambiosRecientes; }
            set { _chkSubirCambiosRecientes = value; RaisePropertyChanged("chkSubirCambiosRecientes"); }
        }
        public bool chkSincroizarCatalogos
        { 
            get{return _chkSincroizarCatalogos;}
            set { _chkSincroizarCatalogos  = value; RaisePropertyChanged("chkSincroizarCatalogos");}
        }
        public bool chkSincronizacionCompleta
        {
            get { return _chkSincronizacionCompleta; }
            set { _chkSincronizacionCompleta = value; RaisePropertyChanged("chkSincronizacionCompleta"); }
        }

        private string _txtConectado;
        public string txtConectado
        {
            get { return _txtConectado; }
            set { _txtConectado = value; RaisePropertyChanged("txtConectado"); }
        }

        private string _txtServidor;
        public string txtServidor
        {
            get { return _txtServidor; }
            set { _txtServidor = value; RaisePropertyChanged("txtServidor"); }

        }

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
        private string _ipconexion;
        private string _tipoip;
        private bool _protocoloconexion;
        private int _puertoconexion;
        private bool _principalconexion;
        private string _estadoconexion;

        
        public string Ipconexion { get { return _ipconexion; } set { _ipconexion = value; RaisePropertyChanged("Ipconexion"); } }
        public string Tipoip { get { return _tipoip; } set { _tipoip = value; RaisePropertyChanged("Tipoip"); } }





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


        #endregion

        #region ViewModel Commands
        public RelayCommand SincronizarCommand { get; set; }
        public RelayCommand CancelarCommand { get; set; }
        public RelayCommand SalirCommand { get; set; }

        #endregion


        #region ViewModel Public Methods

        #region Constructores

        public SincronizacionViewModel()
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            _tokenEnvioController = "SincronizarTerminada";
            _resultadoProceso = 0;
            Errors = 0;
            _tokenRecepcionPadre = "SincronizarBase"; ;
            _accesibilidadWindow = false;
            _accesibilidadCuerpo = false;
            //Suscribiendo el mensaje
            Messenger.Default.Register<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPadre, (datosMsj) => ControlDatosMsj(datosMsj));
            //Inicializar el contenido del frame con el detalle de procedimientos
            dlg = new DialogCoordinator();
            RegisterCommands();
            this.VerificarServidor();
        }

        private void VerificarServidor()
        {
            chkSubirCambiosRecientes = true;
            chkSincroizarCatalogos = false;
            chkSincronizacionCompleta = false;
            this.dondeEstoyConectado();
            this.verificarAlcanceIPservidor();
        }

        private void ControlDatosMsj(PrincipalUsuarioValidadoMensaje datosMsj)
        {
            //Asignacion de  entidades
            currentUsuario = datosMsj.usuarioModelo;
            Messenger.Default.Unregister<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPadre);
            finComando();
        }

        #endregion

        private async void Cancelar()
    {
            // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
            //Debe cerrar el sistema
            iniciarComando();
            resultadoProceso = 2;
            var controller = await dlg.ShowProgressAsync(this, "Operación cancelada", "Este mensaje desaparecerá en 1 segundo", settings: configuracionDialogo);
            controller.SetIndeterminate();
            await TaskEx.Delay(1000);
            await controller.CloseAsync();
            CloseWindow();
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
    }


        public async void Sincronizar()
        {
            iniciarComando();
            try
            {
                //Proceso  de cierre
                await dlg.ShowMessageAsync(this,"Se ha iniciado un proceso de sincronizacion. Espere su finalizacion.","");
                //using (var context = new SGPTEntidades())
                //{
                //    var result = context.Database.ExecuteSqlCommand("select sgpt.syncronizacion()");
                //}
                Coneccion.Close();
                bool Bandera = await this.Conectar("127.0.0.1", "sgpt", "sgpt2016");
                if (Bandera)
                {
                    String sincronizar = "select sync_local_paises();";


                    //bool si = Ejecutar_Consulta(sincronizar);
                    ////this.MycmdDesConectarABase();
                    //if (si)
                    //    await AvisaYCerrateVosSolo("Proceso de sincronizacion ha finalizado con exito","",2);
                    //else
                    //    await AvisaYCerrateVosSolo("FALLO el Proceso de sincronizacion.", "", 2);



                    try

                    {

                        int result;

                        result = 0;

                        Cadena = "";
                        string Server = "127.0.0.1";
                        string Usuario = "postgres";
                        string Contraseña = "toortoor";
                        //string Usuario = "programador3";
                        //string Contraseña = "Pa$$w0rd";
                        Cadena = "Server=" + Server.ToString() + ";Port=5432;Database=SGPT;User id=" + Usuario.ToString() + ";Password=" + Contraseña.ToString() + ";";
                        using (NpgsqlConnection Conn = new NpgsqlConnection(Cadena))
                        {
                            Conn.Open();
                            NpgsqlCommand command = new NpgsqlCommand("INSERT INTO sgpt.syncronizacion(store_procedure,descripcion) values (:storet, :nombre) ;", Conn);
                            command.Parameters.Add(new NpgsqlParameter("storet", NpgsqlTypes.NpgsqlDbType.Varchar));
                            command.Parameters.Add(new NpgsqlParameter("nombre", NpgsqlTypes.NpgsqlDbType.Varchar));
                            //command.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
                            command.Parameters[0].Value = "sgpt.sync_local_paises()";
                            command.Parameters[1].Value = "paises";
                            command.CommandTimeout = 0;
                            command.ExecuteNonQuery();
                            Conn.Close();
                            await AvisaYCerrateVosSolo("Finalizado...", " " , 1);
                            //conn.Open();
                            //using (NpgsqlTransaction  tra = conn.BeginTransaction())
                            //using (NpgsqlCommand command = new NpgsqlCommand("select sgpt.prueba_para_paises();", conn)) //sgpt.sync_local_paises
                            //{
                            //    command.CommandType = CommandType.Text;//.StoredProcedure;
                            //    command.CommandTimeout = 0;
                            //    var drx = command.ExecuteScalar();//.ExecuteNonQuery();//ExecuteScalar();//ExecuteReader();
                            //    await AvisaYCerrateVosSolo("Finalizado...", " " + drx, 2);
                            //    conn.Close();
                            //}
                        }

                        //NpgsqlTransaction tran = conn.BeginTransaction();
                        //NpgsqlCommand command = new NpgsqlCommand("select sgpt.syncronizacion();", conn);

                        //command.CommandType = CommandType.StoredProcedure;

                        //NpgsqlDataReader 
                        //var  dr = command.ExecuteNonQuery();
                        //DataTable dt = new DataTable();
                        //dt.Load(dr);
                        //conn.Close();
                        //command.Connection = Coneccion; // npgsqlConnection;

                        //command.Parameters.Add(new NpgsqlParameter("@ArticleId", DbType.String));

                        //command.Parameters["@ArticleId"].Value = "1";

                        //npgsqlConnection.Open();

                        //result = command.ExecuteNonQuery();



                    }

                    catch (Exception ex)

                    {

                        //throw new Exception(ex.Message);
                        MessageBox.Show(""+ex);

                    }

                    finally

                    {

                        if (Coneccion.State == ConnectionState.Open)
                        {

                            Coneccion.Close();

                        }

                    }

                }

                //fin de  cierre
                #region para comunicar el cierre
                resultadoProceso = 1;
                CloseWindow();
                #endregion
            }
            catch (Exception e)
            {
                //Errores
                await dlg.ShowMessageAsync(this, "Error en proceso", "" + e);
            }
        }

        #endregion

        #region Mensajes

        public void enviarMensaje()
    {
        //Creando el mensaje de cierre
        Messenger.Default.Send(resultadoProceso, tokenEnvioController);
    }


    #endregion

       #region Metodos de apoyo

    public bool CanSave()
    {
        return true;
    }

    #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
    {
        SincronizarCommand = new RelayCommand(Sincronizar, CanSave);//Caso de nuevo registro
        CancelarCommand = new RelayCommand(Cancelar);
        SalirCommand = new RelayCommand(Salir);
    }

        #endregion

        #region Lanzado de  comando

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }


        #endregion Fin de comando

        private void dondeEstoyConectado()
        {
            Mouse.OverrideCursor = Cursors.Wait;

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
            //ListadoConexionesBakup = new List<Conexion>();
            //Conexion cnx = new Conexion();
            txtConectado = Server;
            if (Server == "localhost" || Server == "127.0.0.1") //esta conectado a la base local
            {

                //IP = "127.0.0.1";
                //USUARIO = "sgpt";
                //PASS = "sgpt2016";
                //Puertoconexion = 5432;


                if (Ipconexion != "localhost" || Ipconexion != "127.0.0.1" || !string.IsNullOrEmpty(Ipconexion)) //esta conectado a la base local
                {
                    //bool Bandera = await this.Conectar(Ipconexion, "programador1", "Pa$$w0rd");
                    //if (Bandera)
                    //{

                    //    //this.MycmdDesConectarABase();
                    //}
                }

            }
            else //esta conectado al servidor. (Base de datos centralizada.)
            {

                //IP = Server;
                //USUARIO = Usuario;
                //PASS = Pass;
                //Puertoconexion = 5432;

                //bool Bandera = await this.Conectar("127.0.0.1", "sgpt", "sgpt2016");
                //if (Bandera)
                //{

                //    this.MycmdDesConectarABase();
                //}
            }
            RaisePropertyChanged("ListadoConexionesBakup");
            //SelectedConexionBakup = ListadoConexionesBakup[0]; //SelectedConexionBakup = cnx;
            RaisePropertyChanged("SelectedConexionBakup");
            //habilitar
            //IP = "127.0.0.1";
            //USUARIO = "sgpt";
            //PASS = "sgpt2016";
            //Puertoconexion=5432;
            //Mouse.OverrideCursor = null;
            //this.Obtener_Conexion();
        }

        private async void verificarAlcanceIPservidor()
        {
            conexione connet = new conexione();
            using (db=new SGPTEntidades())
            {
                connet = (from c in db.conexiones where c.idconexion > 0 select c).FirstOrDefault();
                if (connet.idconexion > 0)
                {
                    Ipconexion = connet.ipconexion;
                    if (connet.tipoip == "P") TipoIP = ListaBotonesTipoIP.IpPublica;
                    else TipoIP = ListaBotonesTipoIP.IpLocal;
                    txtServidor = connet.ipconexion;
                }
            }
            if (!string.IsNullOrEmpty(Ipconexion))
            {
                if (TipoIP == ListaBotonesTipoIP.IpLocal)
                {
                    if (parseIP(Ipconexion))
                    {
                        #region +
                        Ping pingSender = new Ping();
                        IPAddress address = IPAddress.Parse(Ipconexion);//IPAddress.Loopback;
                        PingReply reply = pingSender.Send(address);

                        if (reply.Status == IPStatus.Success)
                        {
                            EstadoActualIPServidor = "Disponible";

                        }
                        else
                        {
                            EstadoActualIPServidor = "Inaccesible" + reply.Status;
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
                            EstadoActualIPServidor = "Disponible";
                        }
                        else
                        {
                            EstadoActualIPServidor = "Inaccesible" + reply.Status;
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
                                EstadoActualIPServidor = "Inaccesible" + reply.Status;
                                await AvisaYCerrateVosSolo("La Ip servidor no esta al alcance en la red. Se intentara crear una conexion directa a la base de datos servidor", "", 2);

                                Mouse.OverrideCursor = Cursors.Wait;
                                bool Bandera = await this.Conectar(Ipconexion, "programador1", "Pa$$w0rd");
                                if (Bandera)
                                {
                                    EstadoActualIPServidor = "Disponible";
                                }
                                this.MycmdDesConectarABase();
                                Mouse.OverrideCursor = null;
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
                        catch (ArgumentException)
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

            catch (ArgumentNullException)
            {
                EstadoActualIPServidor = "IP erronea...";
            }

            catch (FormatException)
            {
                EstadoActualIPServidor = "IP erronea...";
            }

            catch (Exception)
            {
                EstadoActualIPServidor = "IP erronea...";
            }
            //Si llego hasta aqui es porque la ip produjo algun error.
            //Voy a intentar obtener la ip si es que es una ip publica.

            return false;
        }
        public async Task<Boolean> Conectar(string Server, string Usuario, string Contraseña)
        {
            await AvisaYCerrateVosSolo("Intentando conectar...", "", 1);
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
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Mouse.OverrideCursor = null;
                    //lblubicacion = "!No Se Puede Conectar!";
                    Console.WriteLine("No Se Encuentran Bases De Datos", ex.Message.ToString());
                    return false;
                }
            }

            #endregion
        }
        public bool Ejecutar_Consulta(String Accion)
        {
            #region MyRegion
            bool Estado = false;
            try
            {
                //Coneccion = new NpgsqlConnection(Cadena);
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

        private async void MycmdDesConectarABase()
        {
            #region +
            if (Coneccion.State == System.Data.ConnectionState.Open)
                Coneccion.Close();

            if (Coneccion.State != System.Data.ConnectionState.Open)
            {
            }
            else
            {
                //lblubicacion = "¡No fue posible desconectarse!";
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
                await AvisaYCerrateVosSolo("No se pudo Desconectar...", "", 1);

            }

            #endregion
        }
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
    }
}