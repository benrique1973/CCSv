using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Model;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Model;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using SGPTWpf.SGPtmvvm.Vistas;
using SGPTmvvm.Soporte;
using System.Data.Entity;

namespace SGPTWpf.ViewModel
{
    public sealed class LoguinViewModel : ViewModeloBase
    {
        List<usuariospersonas> usuariosy { get; set; }
        public List<usuariospersonas> UsuariosListado { get; set; }
        public bool LaBaseEstaDisponible;

        #region ViewModel Properties
        public SGPTEntidades db = new SGPTEntidades();
        #region fallosClave

        private int _fallosClave;
        private int fallosClave
        {
            get { return _fallosClave; }
            set { _fallosClave = value; }
        }

        #endregion

        #region maxFallosClave

        private int _maxFallosClave;
        private int maxFallosClave
        {
            get { return _maxFallosClave; }
            set { _maxFallosClave = value; }
        }

        #endregion

        private bool inicio;
        public static int Errors { get; set; }//Para controllar los errores de edición

        private string _nickUsuarioUsuarioAnterior;

        #region Binding

        private usuario usuarioValido;

        private usuario usuarioByNickName;

        #region ViewModel Property : currentEntidad UsuarioModelo

        public const string currentEntidadPropertyName = "currentEntidad";

        private UsuarioModelo _currentEntidad;

        public UsuarioModelo currentEntidad
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

        #region nickUsuarioUsuario

        public const string nickUsuarioUsuarioPropertyName = "nickUsuarioUsuario";

        private string _nickUsuarioUsuario = string.Empty;

        public string nickUsuarioUsuario
        {
            get
            {
                return _nickUsuarioUsuario;
            }

            set
            {
                if (_nickUsuarioUsuario == value)
                {
                    return;
                }
                _nickUsuarioUsuario = value;
                RaisePropertyChanged(nickUsuarioUsuarioPropertyName);
                //if ((value.Length > 3) && (value.Length <  13))
                //{
                //    inicio = true;
                //    //if (!(_nickUsuarioUsuarioAnterior.Equals(value)))
                //    //{
                //        conseguirUsuario();
                //        _nickUsuarioUsuarioAnterior = value;
                //    //}
                //}
            }
        }

        #endregion

        #region  contraseniaUsuario

        public const string contraseniaUsuarioPropertyName = "contraseniaUsuario";

        private string _contraseniaUsuario = string.Empty;

        public string contraseniaUsuario
        {
            get
            {
                return _contraseniaUsuario;
            }

            set
            {
                if (_contraseniaUsuario == value)
                {
                    return;
                }

                _contraseniaUsuario = value;
                RaisePropertyChanged(contraseniaUsuarioPropertyName);
            }
        }

        #endregion

        #region LoguinMainModel

        private MainModel _LoguinMainModel = null;

        public MainModel LoguinMainModel
        {
            get
            {
                return _LoguinMainModel;
            }

            set
            {
                _LoguinMainModel = value;
            }
        }


        #endregion

        #endregion

        #endregion

        #region procesos en gestion

        #region ViewModel Properties : isBusy

        public const string isBusyPropertyName = "isBusy";

        private bool _isBusy;

        public bool isBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged(isBusyPropertyName);
            }
        }

        #endregion

        #region  usuarioRecuperado

        public const string usuarioRecuperadoPropertyName = "usuarioRecuperado";

        private bool _usuarioRecuperado;

        public bool usuarioRecuperado
        {
            get
            {
                return _usuarioRecuperado;
            }

            set
            {
                if (_usuarioRecuperado == value)
                {
                    return;
                }

                _usuarioRecuperado = value;
                RaisePropertyChanged(usuarioRecuperadoPropertyName);
            }
        }

        #endregion

        #region  preValidacion

        public const string preValidacionPropertyName = "preValidacion";

        private bool _preValidacion;

        public bool preValidacion
        {
            get
            {
                return _preValidacion;
            }

            set
            {
                if (_preValidacion == value)
                {
                    return;
                }

                _preValidacion = value;
                RaisePropertyChanged(preValidacionPropertyName);
            }
        }

        #endregion

        #region visibilidadProcesando

        public const string visibilidadProcesandoPropertyName = "visibilidadProcesando";

        private Visibility _visibilidadProcesando;

        public Visibility visibilidadProcesando
        {
            get
            {
                return _visibilidadProcesando;
            }

            set
            {
                if (_visibilidadProcesando == value)
                {
                    return;
                }

                _visibilidadProcesando = value;
                RaisePropertyChanged(visibilidadProcesandoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadLoguin

        public const string accesibilidadLoguinPropertyName = "accesibilidadLoguin";

        private bool _accesibilidadLoguin;

        public bool accesibilidadLoguin
        {
            get
            {
                return _accesibilidadLoguin;
            }

            set
            {
                if (_accesibilidadLoguin == value)
                {
                    return;
                }

                _accesibilidadLoguin = value;
                RaisePropertyChanged(accesibilidadLoguinPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadPassword

        public const string accesibilidadPasswordPropertyName = "accesibilidadPassword";

        private bool _accesibilidadPassword;

        public bool accesibilidadPassword
        {
            get
            {
                return _accesibilidadPassword;
            }

            set
            {
                if (_accesibilidadPassword == value)
                {
                    return;
                }

                _accesibilidadPassword = value;
                RaisePropertyChanged(accesibilidadPasswordPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel PropertiesPrivadas

        private DialogCoordinator dlg;

        #endregion

        #region ViewModel Commands

                public GalaSoft.MvvmLight.CommandWpf.RelayCommand CancelarCommand { get; set; }
                public Comando.RelayCommand IngresarCommand { get; set; }

                public GalaSoft.MvvmLight.CommandWpf.RelayCommand OlvidoCommand { get; set; }
                public Comando.RelayCommand DoubleClickCommand { get; set; }
                public GalaSoft.MvvmLight.CommandWpf.RelayCommand SalirCommand { get; set; }
                public GalaSoft.MvvmLight.CommandWpf.RelayCommand ConseguirUsuarioCommand { get; set; }

                //public Comando.RelayCommand ConseguirMD5Command { get; set; }

        #endregion

        #region ViewModel Public Methods

        private async void Cancelar()
                {
                // Basado en : https://social.msdn.microsoft.com/Forums/en-US/fece5464-1863-4d76-b595-b16fb98ce626/messages-dialog-fired-the-viewmodel-through-the-dialogcoordinator-using-mahappsmetro-and-mvvm-light?forum=wpf
                //Debe cerrar el sistema
                await dlg.ShowMessageAsync(this, "Tenga un buen día", "");
                CloseWindow();
                }

        //Basado en : https://code.msdn.microsoft.com/windowsdesktop/Get-Password-from-df012a86
        private async void ingresar(object parameter)
        {
            //if (!(currentEntidad.nickUsuarioUsuario != "" || string.IsNullOrEmpty(currentEntidad.nickUsuarioUsuario)))
            if(Errors==0)
            {
                //await Task.Run(() => conseguirUsuario());
                //Basado en  capítulo 8 Microsoft 10272
                accesibilidadLoguin = false;
                Mouse.OverrideCursor = Cursors.Wait;
                isBusy = true;
                visibilidadProcesando = Visibility.Visible;
                //if (preValidacion && usuarioValido != null && usuarioValido.nickusuariousuario == currentEntidad.nickUsuarioUsuario)
                //{
                //    procesarResultado();
                //}
                //else
                //{
                var passwordContainer = parameter as IHavePassword;
                if (nickUsuarioUsuario != "")
                {
                    currentEntidad.nickUsuarioUsuario = nickUsuarioUsuario;
                }
                MD5 md5Hash = MD5.Create();
                if (fallosClave < maxFallosClave)
                {
                    #region +
                        if (passwordContainer.Password.Length >= 8)
                        {
                            #region +

                            if (usuarioRecuperado)
                            {
                                #region +
                                if (usuarioByNickName.contraseniausuario == GetMd5Hash(md5Hash, ConvertToUnsecureString(passwordContainer.Password)) && usuarioByNickName.nickusuariousuario == currentEntidad.nickUsuarioUsuario)
                                {
                                    usuarioValido = usuarioByNickName;
                                }
                                else
                                {
                                    usuarioValido = null;
                                }
                                procesarResultado();
                                // usuarioValido = UsuarioModelo.validarUsuarioPreValidado(usuarioByNickName, ConvertToUnsecureString(secureString), true); 
                                #endregion
                            }
                            else
                            {
                                #region +
                                BackgroundWorker worker = new BackgroundWorker();

                                //var secureString = passwordContainer.Password;
                                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                                {
                                    usuarioValido = UsuarioModelo.validarUsuario(currentEntidad.nickUsuarioUsuario, ConvertToUnsecureString(passwordContainer.Password), true);
                                };
                                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                                {
                                    procesarResultado();
                                };
                                worker.Dispose();
                                worker.RunWorkerAsync();
                                #endregion
                            } 
                            #endregion
                        }
                        else
                        {
                            Mouse.OverrideCursor = null;
                            accesibilidadLoguin = true;
                            await dlg.ShowMessageAsync(this, "La clave no puede ser vacia o menor de 8 símbolos, verifique", "");
                            fallosClave++;
                            visibilidadProcesando = Visibility.Collapsed;
                            isBusy = false;

                        } 
                        #endregion
                }
                else
                {
                    #region +
                        Mouse.OverrideCursor = null;
                        await dlg.ShowMessageAsync(this, "Rebasó el máximo de intentos permitidos", "el sistema se cerrara");
                        CloseWindow(); 
                        #endregion
                }
                //}
            }
            else
            {
                Mouse.OverrideCursor = null;
                accesibilidadLoguin = true;
                await dlg.ShowMessageAsync(this, "Hacen falta datos o no corresponden a lo requerido", "");
            }

        }


        public async void procesarResultado()

        {
            if (!(usuarioValido == null))
            {
                LoguinMainModel.TypeName = "PrincipalView";
                enviarElemento(usuarioValido);
                CloseWindow();
                Mouse.OverrideCursor = null;
                visibilidadProcesando = Visibility.Collapsed;
                isBusy = false;
            }
            else
            {
                accesibilidadLoguin = true;
                Mouse.OverrideCursor = null;
                fallosClave++;
                await dlg.ShowMessageAsync(this, "Su clave no coincide con su usuario, verifique", "");
                visibilidadProcesando = Visibility.Collapsed;
                isBusy = false;

            }
        }
        public void enviarElemento(usuario usuarioValido)
        {
            //Se crea el mensaje
            UsuarioValidadoMensaje elemento = new UsuarioValidadoMensaje();
            elemento.elementoMensaje = usuarioValido;
            elemento.usuarioModelo = UsuarioModelo.Find(usuarioValido.idusuario);
            Messenger.Default.Send(elemento);
        }
        private void Salir()
        {
            CloseWindow();
        }
        

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            CancelarCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Cancelar);
            IngresarCommand = new Comando.RelayCommand(ingresar, canExecute);
            OlvidoCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Olvido);
            DoubleClickCommand = new Comando.RelayCommand(ingresar, canExecute);
            SalirCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(Salir);
            ConseguirUsuarioCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand(conseguirUsuario);
            //ConseguirMD5Command = new Comando.RelayCommand(preValidar); 
        }

        #region +
        /*private void preValidar(object parameter)
        {
            //Basado en  capítulo 8 Microsoft 10272
            preValidacion = false;
            var passwordContainer = parameter as IHavePassword;
            if (nickUsuarioUsuario != "")
            {
                currentEntidad.nickUsuarioUsuario = nickUsuarioUsuario;
            }
            MD5 md5Hash = MD5.Create();
            if (usuarioRecuperado)
            {
                if (usuarioByNickName.contraseniausuario == GetMd5Hash(md5Hash, ConvertToUnsecureString(passwordContainer.Password)) && usuarioByNickName.nickusuariousuario == currentEntidad.nickUsuarioUsuario)
                {
                    usuarioValido = usuarioByNickName;
                    preValidacion = true;
                }
                else
                {
                    usuarioValido = null;
                }
            }
            else
            {
                BackgroundWorker worker = new BackgroundWorker();

                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    usuarioValido = UsuarioModelo.validarUsuario(currentEntidad.nickUsuarioUsuario, ConvertToUnsecureString(passwordContainer.Password), true);
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    if (usuarioValido == null)
                    {
                        preValidacion = false;
                    }
                    else
                    {
                        preValidacion = true;
                    }
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }*/


        /*private void preValidarPrevia(object parameter)
        {

            //Basado en  capítulo 8 Microsoft 10272
            preValidacion = false;
            var passwordContainer = parameter as IHavePassword;
            if (nickUsuarioUsuario != "")
            {
                currentEntidad.nickUsuarioUsuario = nickUsuarioUsuario;
            }
            MD5 md5Hash = MD5.Create();
            if (usuarioRecuperado)
            {
                if (usuarioByNickName.contraseniausuario == GetMd5Hash(md5Hash, ConvertToUnsecureString(passwordContainer.Password)) && usuarioByNickName.nickusuariousuario == currentEntidad.nickUsuarioUsuario)
                {
                    usuarioValido = usuarioByNickName;
                    preValidacion = true;
                }
                else
                {
                    usuarioValido = null;
                }
            }
            else
            {
                BackgroundWorker worker = new BackgroundWorker();

                //var secureString = passwordContainer.Password;
                worker.DoWork += (object sender, DoWorkEventArgs e) =>
                {
                    usuarioValido = UsuarioModelo.validarUsuario(currentEntidad.nickUsuarioUsuario, ConvertToUnsecureString(passwordContainer.Password), true);
                };
                worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                {
                    if (usuarioValido == null)
                    {
                        preValidacion = false;
                    }
                    else
                    {
                        preValidacion = true;
                    }
                };
                worker.Dispose();
                worker.RunWorkerAsync();
            }
        }*/
        
        #endregion
        private void conseguirUsuario()
        {
            inicio = true;
            accesibilidadPassword = true;
            if (currentEntidad.nickUsuarioUsuario.Length > 3 && currentEntidad.nickUsuarioUsuario.Length < 13)
            {
                inicio = true;
                bool ejecutar = false;
                usuarioRecuperado = false;
                if (usuarioByNickName == null)
                {
                    ejecutar = true;
                }
                else
                {
                    if (usuarioByNickName.nickusuariousuario == currentEntidad.nickUsuarioUsuario)
                    {
                        ejecutar = false;
                    }
                    else
                    {
                        ejecutar = true;
                    }
                }
                if (ejecutar)
                {
                    usuarioByNickName = null;
                    // await dlg.ShowMessageAsync(this, "Conseguir al usuario", "");
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (object sender, DoWorkEventArgs e) =>
                    {
                        if (!(string.IsNullOrWhiteSpace(nickUsuarioUsuario) || nickUsuarioUsuario == ""))
                        {
                            usuarioByNickName = UsuarioModelo.conseguirUsuario(nickUsuarioUsuario);
                        }
                        else
                        {
                            if (!((string.IsNullOrWhiteSpace(currentEntidad.nickUsuarioUsuario)) || currentEntidad.nickUsuarioUsuario == ""))
                            {
                                usuarioByNickName = UsuarioModelo.conseguirUsuario(currentEntidad.nickUsuarioUsuario);
                            }
                            else
                            {
                                usuarioByNickName = null;
                            }
                        }
                        if (usuarioByNickName == null)
                        {
                            usuarioRecuperado = false;
                        }
                        else
                        {
                            usuarioRecuperado = true;
                        }
                    };
                    worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                    {
                        if (usuarioByNickName == null)
                        {
                            usuarioRecuperado = false;
                        }
                        else
                        {
                            usuarioRecuperado = true;
                        }
                    };
                    worker.RunWorkerAsync();
                    //worker.Dispose();
                }
            }
        }

        private void conseguirUsuarioPrevia()
        {
            if (currentEntidad.nickUsuarioUsuario.Length > 3 && currentEntidad.nickUsuarioUsuario.Length < 13)
            {
                inicio = true;
                bool ejecutar = false;
                usuarioRecuperado = false;
                if (usuarioByNickName == null)
                {
                    ejecutar = true;
                }
                else
                {
                    if (usuarioByNickName.nickusuariousuario == currentEntidad.nickUsuarioUsuario)
                    {
                        ejecutar = false;
                    }
                    else
                    {
                        ejecutar = true;
                    }
                }
                if (ejecutar)
                {
                    usuarioByNickName = null;
                    // await dlg.ShowMessageAsync(this, "Conseguir al usuario", "");
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (object sender, DoWorkEventArgs e) =>
                    {
                        #region +
                        if (!(string.IsNullOrWhiteSpace(nickUsuarioUsuario) || nickUsuarioUsuario == ""))
                        {
                            usuarioByNickName = UsuarioModelo.conseguirUsuario(nickUsuarioUsuario);
                        }
                        else
                        {
                            if (!((string.IsNullOrWhiteSpace(currentEntidad.nickUsuarioUsuario)) || currentEntidad.nickUsuarioUsuario == ""))
                            {
                                usuarioByNickName = UsuarioModelo.conseguirUsuario(currentEntidad.nickUsuarioUsuario);
                            }
                            else
                            {
                                usuarioByNickName = null;
                            }
                        }
                        if (usuarioByNickName == null)
                        {
                            usuarioRecuperado = false;
                        }
                        else
                        {
                            usuarioRecuperado = true;
                        } 
                        #endregion
                    };
                    worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
                    {
                        #region +
                        if (usuarioByNickName == null)
                        {
                            usuarioRecuperado = false;
                        }
                        else
                        {
                            usuarioRecuperado = true;
                        } 
                        #endregion
                    };
                    worker.RunWorkerAsync();
                    //worker.Dispose();
                }
            }
        }

        private bool canExecute(object parameter)
        {
                return Errors == 0 && inicio;
                //evaluar = !string.IsNullOrEmpty(currentEntidad.nickUsuarioUsuario) &&
                //            (currentEntidad.nickUsuarioUsuario.Length <= maxnickUsuarioUsuario) &&
                //            (currentEntidad.nickUsuarioUsuario.Length >= minNnickUsuarioUsuario);
                //return evaluar;
        }

        #endregion

        
        public LoguinViewModel()
        {
            LaBaseEstaDisponible = false;
            //this.VerificarCadenaConexion();
            this.DatosOlvidoContrasenia();
            inicio = false;
            _nickUsuarioUsuario = string.Empty;
            _fallosClave = 0;//Control de repeticiones
            _nickUsuarioUsuarioAnterior = string.Empty;
            _maxFallosClave = 3;
            _usuarioRecuperado = false;
            _preValidacion = false;
            RegisterCommands();
            dlg = new DialogCoordinator();
            currentEntidad = new UsuarioModelo();
            currentEntidad.nickUsuarioUsuario=nickUsuarioUsuario;
            LoguinMainModel = new MainModel();
            _visibilidadProcesando = Visibility.Collapsed;
            _accesibilidadLoguin = true;
            usuarioValido = new usuario();
            usuarioByNickName = new usuario();
            _isBusy = false;
            _accesibilidadPassword = true;

        }

        //private async void VerificarCadenaConexion()
        //{
        //    string path = @"c:\sgptArchivos\IpServidor.txt";

        //    if (File.Exists(path))
        //    {
        //        string leerTextConexion = File.ReadAllText(path);
        //        string [] ltc = leerTextConexion.Split(';');
        //        if (ltc.Count() == 2)
        //        {
        //            string Usr = "sgpt";
        //            string Psw = "sgpt2016";
        //            //string Psw = ltc[0];
        //            string ip = ltc[0]; //"localhost"; //ec2-54-242-235-149.compute-1.amazonaws.com
        //            int pto = 5432;
        //            await Task.Delay(1);
        //            bool cambioCadena = CambiarCadenaConexion.CambiarCadenaConexionx(Usr, Psw, ip, pto);
        //            ConfigurationManager.RefreshSection("connectionStrings");
        //            await Task.Delay(1);
        //            //bool cambioCadena = false;
        //            if (cambioCadena)
        //                await AvisaYCerrateVosSolo("Se cambio una conexion", "", 1);
        //            else
        //                await AvisaYCerrateVosSolo("Noooo fue posible cambiar la conexion", "", 1);
        //        }
        //    }
        //}



        #region Olvido Contraseña
        CustomDialog customDialog;
        MD5 md5Hash = MD5.Create();

        #region Campos

        private string _correoT;
        private string _idduipersona;
        private string _nombrespersona;
        private string _apellidospersona;
        public string CorreoT { get { return _correoT; } set { _correoT = value; RaisePropertyChanged("CorreoT"); } }
        public string Idduipersonay { get { return _idduipersona; } set { _idduipersona = value; RaisePropertyChanged("Idduipersonay"); } }

        public string Nombrespersona { get { return _nombrespersona; } set { _nombrespersona = value; RaisePropertyChanged("Nombrespersona"); } }

        public string Apellidospersona { get { return _apellidospersona; } set { _apellidospersona = value; RaisePropertyChanged("Apellidospersona"); } } 
        #endregion

        #region Comandos
        private bool _canExecute=true;
        private ICommand _cmdCancelar_Click;
        public ICommand cmdCancelar_Click
        {
            get
            {
                return _cmdCancelar_Click ?? (_cmdCancelar_Click = new CommandHandler(() => cmdCancelar(), _canExecute));
            }
        }

        private async void cmdCancelar()
        {
            //await dlg.ShowMessageAsync(this, "Tenga un buen día", "");

            await AvisaYCerrateVosSolo("Tenga un buen día.", "Saliendo...", 1);
            await dlg.HideMetroDialogAsync(this, customDialog);
            CloseWindow();
        }

        private ICommand _cmdAceptar_Click;
        public ICommand cmdAceptar_Click
        {
            get
            {
                return _cmdAceptar_Click ?? (_cmdAceptar_Click = new CommandHandler(() => cmdAceptar(), _canExecute));
            }
        }

        private async void cmdAceptar()
        {
            await AvisaYCerrateVosSolo("Procesando..."+Environment.NewLine+" DUI: "+Idduipersonay+Environment.NewLine+"Nombres: "+Nombrespersona+", "+Apellidospersona+Environment.NewLine+"Email: "+CorreoT,"",2);
            usuariospersonas BuscaUxuario = UsuariosListado.Find(x => x.idduipersona==Idduipersonay);
            if (BuscaUxuario != null)
            {
                //var aj=((BuscaUxuario.nombreCompleto).ToUpper());
                //var bj = ((Nombrespersona+" "+Apellidospersona).ToUpper());

                //var ajj = (BuscaUxuario.nombreCompleto).Trim();
                //var bjj = (Nombrespersona+" "+Apellidospersona).Trim();

                bool prueba1 = (((BuscaUxuario.nombreCompleto).ToUpper())==((Nombrespersona+" "+ Apellidospersona).ToUpper())? true : false); 
                List<correo> ls = new List<correo>();
                ls=BuscaUxuario.correos.ToList();
                bool prueba2=(ls.Exists(z=> z.direccioncorreo.ToUpper().Trim()==CorreoT.ToUpper().Trim()));
                if(prueba1&&prueba2) //En este caso ya se comprobo que existe en la base un usuario, pero lo que no sabemos es si en realidad es el dueno de la cuenta que quiere obtener.
                {
                    //pudiera volver a preguntarle la pregunta secreta, pero ,,, NA...asi que quede.
                    //await AvisaYCerrateVosSolo("Datos Aceptados","",2);
                    string Nickusuariousuario = Nombrespersona.Substring(0, 3) + Apellidospersona.Substring(0, 3) + generarNumero(3);
                    string Contraseniausuario = generarCodigoUser();
                    
                    bool notificadoOk=await this.notificarAlUsuario(Idduipersonay, Nickusuariousuario, Contraseniausuario);
                    if (notificadoOk)
                    {
                        try
                        {
                            using (db = new SGPTEntidades())
                            {
                                usuario usuarioRestablecido = new usuario();
                                usuarioRestablecido = db.usuarios.Where(x => x.idduipersona == Idduipersonay).SingleOrDefault(); //UsuariosListado.Find(x => x.idduipersona == Idduipersonay);// db.usuarios.Find(Idduipersonay);
                                usuarioRestablecido.nickusuariousuario = Nickusuariousuario;
                                usuarioRestablecido.contraseniausuario = GetMd5Hash(md5Hash, Contraseniausuario);
                                db.Entry(usuarioRestablecido).State = EntityState.Modified;
                                db.SaveChanges();
                                //asdf=asd
                                //ya aqui lo dejo pasar.
                                await AvisaYCerrateVosSolo("Asegurese de cambiar manualmente sus credenciales en Administracion->Usuarios->Cambiar contraseña.", "", 2);
                                await dlg.HideMetroDialogAsync(this, customDialog);
                                usuarioValido=usuarioRestablecido;
                                this.procesarResultado();
                            }
                        }
                        catch (Exception)
                        {
                            this.Exception1();
                        }
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("No fue posible la restauracion de cuenta. El correo emitio un error desconocido.", "", 2);
                        await dlg.HideMetroDialogAsync(this, customDialog);
                        CloseWindow();
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("Los datos introducidos NO fueron aceptados.", "Cerrando y saliendo.", 2);
                    await dlg.HideMetroDialogAsync(this, customDialog);
                    CloseWindow();
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("Los datos introducidos NO fueron aceptados.","Cerrando y saliendo.",2);
                await dlg.HideMetroDialogAsync(this, customDialog);
                CloseWindow();
            }
        }

        private async void Exception1()
        {
            await AvisaYCerrateVosSolo("Error. no se pudo restablecer la cuenta. La base de datos no esta disponible.","",2);
            await dlg.HideMetroDialogAsync(this, customDialog);
            CloseWindow();
        }

        #endregion

        private void DatosOlvidoContrasenia()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                this.ObtenerDatos();
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
            };
            worker.RunWorkerAsync();
        }
        private async void Olvido() //Dio click enOlvido contrasenia
        {
            try
            {
                #region +
                Mouse.OverrideCursor = Cursors.Wait;
                //if (!HayInterSioNo())
                //{ 
                #region +
                if (!string.IsNullOrEmpty(currentEntidad.nickUsuarioUsuario) && currentEntidad.nickUsuarioUsuario.Length > 3 )// && currentEntidad.nickUsuarioUsuario.Length < 13)// || passwordContainer.Password.Length >= 8)
                {
                    #region +
                    //voy a buscar si el correo existe.
                    usuario usuarioBuscado = new usuario();
                    string commandStringEmail = string.Format("SELECT * FROM sgpt.correos WHERE LOWER(direccioncorreo)='{0}';", currentEntidad.nickUsuarioUsuario);
                    correo correoDigitado = new correo();
                    using (db=new SGPTEntidades())
                    {
                        correoDigitado = db.correos.SqlQuery(commandStringEmail).FirstOrDefault(); 
                    }
                    if (correoDigitado == null)
                    {
                        //No se localizo 
                    }
                    else
                    {
                        //Buscar por el email
                        using (db=new SGPTEntidades())
                        {
                            string commandString = string.Format("SELECT * FROM sgpt.usuarios WHERE LOWER(idduipersona)='{0}';", correoDigitado.idduipersona);
                             usuarioBuscado = db.usuarios.SqlQuery(commandString).FirstOrDefault();
                             usuarioByNickName = usuarioBuscado;
                        }
                    }


                    if (usuarioByNickName != null && usuarioByNickName.nickusuariousuario == currentEntidad.nickUsuarioUsuario || usuarioBuscado.idusuario>0) //si lo encontro por el NICK
                    {
                        #region +
                        pista x = new pista();
                        using (db = new SGPTEntidades())
                        {
                            x = (from p in db.pistas where p.idpista == usuarioByNickName.idpista select p).SingleOrDefault();
                        }
                        if (x != null)
                        {
                            var result = await dlg.ShowInputAsync(this, "Responda la siguiente pregunta personal:", "" + x.descripcionpista);

                            if (result == null) //user pressed cancel
                            {
                                await AvisaYCerrateVosSolo("Ha cancelado la restauracion de las credenciales...", "Cancelado.", 2);
                                Mouse.OverrideCursor = null;
                            }
                            else
                            {
                                #region +
                                // await dlg.ShowMessageAsync(this, "Ingreso", "+ " + result + "!");

                                //usuarioRestablecido = db.usuarios.Find(Idduipersonay);
                                //usuarioRestablecido.nickusuariousuario = nickUsuarioUsuario;
                                string respustaPistaMD5 = GetMd5Hash(md5Hash, result.Trim());
                                if (usuarioByNickName.respuestapistausuario == respustaPistaMD5)
                                {
                                    await AvisaYCerrateVosSolo("Atencion: Asegurese de cambiar sus credenciales antes de salir en Administracion->Usuarios->Cambiar Contraseña", "", 3);
                                    //Aqui ya lo dejo pasar.
                                    usuarioValido = usuarioByNickName;
                                    this.procesarResultado();
                                }
                                else
                                {
                                    await AvisaYCerrateVosSolo("Los datos introducidos NO fueron aceptados.", "", 2);
                                    //await dlg.HideMetroDialogAsync(this, customDialog);
                                    CloseWindow();
                                }
                                #endregion
                            }

                        } 
                        #endregion
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("No se encontro el Nick del usuario...", "Datos erroneos.", 2);
                        if (HayInterSioNo())
                        {
                            #region +
                            var mySettingsk = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "Si",
                                NegativeButtonText = "No recuerdo",

                            };
                            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Puede recordar el Usuario?", "Nota: Si recuerda el usuario, el proceso es mas corto.", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                            if (resultk == MessageDialogResult.Affirmative)
                                Mouse.OverrideCursor = null;
                            if (resultk == MessageDialogResult.Negative)
                            {
                                #region +
                                //await dlg.ShowMessageAsync(this, "Deme el correo + el DUI "+Environment.NewLine+"... Si no lo recuerda tampoco, que abandone", "");

                                //var customDialog = new CustomDialog() { Title = "Restauracion de cuenta de usuario" };
                                customDialog = new CustomDialog()
                                {
                                    Title = "Restauracion de cuenta de usuario",
                                    Content = new DialogoRecuperacionCuentaLoginView { DataContext = this }
                                };

                                await dlg.ShowMetroDialogAsync(this, customDialog);

                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("Atencion. No podra restablecer su cuenta sin conexion a internet.", "Requerido: Es necesario tener conexion a internet.", 4);
                            CloseWindow();
                        }
                    }
                    #endregion
                }
                else //no ingreso bien el nick porque no se acuerda
                {
                    if (HayInterSioNo())
                    {
                        #region +
                        var mySettingsk = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Si",
                            NegativeButtonText = "No recuerdo",

                        };
                        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Puede recordar el Usuario?", "Nota: Si recuerda el usuario, el proceso es mas corto.", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                        if (resultk == MessageDialogResult.Affirmative)
                            Mouse.OverrideCursor = null;
                        if (resultk == MessageDialogResult.Negative)
                        {
                            #region +
                            //await dlg.ShowMessageAsync(this, "Deme el correo + el DUI "+Environment.NewLine+"... Si no lo recuerda tampoco, que abandone", "");

                            //var customDialog = new CustomDialog() { Title = "Restauracion de cuenta de usuario" };
                            customDialog = new CustomDialog()
                            {
                                Title = "Restauracion de cuenta de usuario",
                                Content = new DialogoRecuperacionCuentaLoginView { DataContext = this }
                            };
                            //var LoginViewModel = new LoguinViewModel(instance =>
                            //{
                            //    dlg.HideMetroDialogAsync(this, customDialog);
                            //    System.Diagnostics.Debug.WriteLine(instance.idduipersonay);
                            //});


                            await dlg.ShowMetroDialogAsync(this, customDialog);

                            //DialogoRecuperacionCuentaLoginView

                            #endregion
                        }
                        //await dlg.ShowMessageAsync(this, "Debe introducir por lo menos el usuario."+Environment. Si no lo recuerda tampoco", ""); 
                        #endregion
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("Atencion. No podra restablecer su cuenta sin conexion a internet.", "Requerido: Es necesario tener conexion a internet.", 4);
                        CloseWindow();
                    }
                }
                #endregion
                //}
                //else
                //{
                //    await AvisaYCerrateVosSolo("Atencion. No podra restablecer su cuenta sin conexion a internet.", "Requerido: Es necesario tener conexion a internet", 3);
                //}
                Mouse.OverrideCursor = null;
                #endregion
            }
            catch (Exception)
            {
                this.Exception3();
            }
        }
        private async void Exception3()
        {
            await AvisaYCerrateVosSolo("Error al intentar recuperar las credenciales del usuario", "", 1);
        }
        private void ObtenerDatos()
        {
            //ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();
            UsuariosListado = new List<usuariospersonas>();
            try
            {
                usuariosy=new List<usuariospersonas>();
                using (db = new SGPTEntidades())
                {
                    //db.Configuration.AutoDetectChangesEnabled = false;
                    //db.Configuration.ValidateOnSaveEnabled = false;
                    #region +
                    usuariosy = (from u in db.usuarios
                                 join p in db.personas
                                 on u.idduipersona equals p.idduipersona
                                 orderby p.nombrespersona
                                 select new usuariospersonas
                                 {
                                     #region
                                     idusuario = u.idusuario,
                                     idpista = (int)u.idpista,
                                     usuidusuario = (int)(u.usuidusuario),
                                     idrol = (int)(u.idrol),
                                     //idfirma = (int)u.idfirma,
                                     fecharegistrousuario = u.fecharegistrousuario,
                                     fechadebaja = (u.fechadebaja),
                                     fechacontratacion = (u.fechacontratacion),
                                     nickusuariousuario = u.nickusuariousuario,
                                     contraseniausuario = u.contraseniausuario,
                                     inicialesusuario = u.inicialesusuario,
                                     respuestapistausuario = u.respuestapistausuario,
                                     numerocvpausuario = u.numerocvpausuario,
                                     fechacvpausuario = (u.fechacvpausuario),
                                     estadousuario = u.estadousuario,
                                     idduipersona = p.idduipersona,
                                     nombrespersona = p.nombrespersona,
                                     apellidospersona = p.apellidospersona,
                                     nombreCompleto=p.nombrespersona+" "+p.apellidospersona,
                                     sexopersona = p.sexopersona,
                                     direccionpersona = p.direccionpersona,
                                     noafppersona = p.noafppersona,
                                     noissspersona = p.noissspersona,
                                     nitpersona = p.nitpersona,
                                     estadopersona = p.estadopersona,
                                     correos = (from c in db.correos where c.idduipersona == p.idduipersona && c.estadocorreo == "A" orderby c.idcorreo select c).ToList(),
                                     telefonos = (from t in db.telefonos where t.idduipersona == p.idduipersona && t.estadotelefono == "A" orderby t.idtt select t).ToList()
                                     #endregion
                                 }).ToList(); 
                    #endregion
                }
                //from t in db.telefonos on p.idduipersona equals t.idduipersona 
                foreach (usuariospersonas usua in usuariosy)
                {
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            if (usua.idrol > 0)
                            {
                                String nombreRolz = (from r in db.roles where r.idrol.Equals(usua.idrol) select r.nombrerol).FirstOrDefault();
                                usua.nombrerol = nombreRolz;
                            }
                            if (usua.usuidusuario > 0)
                            {
                                var zyx = db.personas.Join(db.usuarios, p => p.idduipersona, u => u.idduipersona, (p, u) => new { personas = p, usuarios = u }).Where(uu => uu.usuarios.idusuario == usua.usuidusuario).Select(uu => uu.personas).SingleOrDefault();
                                String nombreJefez = zyx.nombrespersona + ", " + zyx.apellidospersona;
                                usua.nombreusuidusuario = nombreJefez;
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("No se pudo recuperar el nombre del rol, ni el nombre del jefe");
                        }
                    }
                    UsuariosListado.Add(usua);
                    //_usuarios.Add(new UsuariosVM { IsNew = false, TheUsuariosPersonas = usua });
                }
                //UsuariosListado = _usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado");
        }

        private bool HayInterSioNo()
        {
            #region +
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                if (host.AddressList != null)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
            #endregion
        }

        #region Generar Codigo Usuario
            private static Random aleatorio = new Random();
            public static string generarCodigoUser()
        {
            string GenMayusc = generarMayuscula(1);
            string GenMixto = generarMixto(5);
            string GenNumero = generarNumero(1);
            string GenEspecial = generarCaracterEspecial(1);
            string CodUsr = GenMayusc + GenEspecial + GenMixto + GenNumero;
            return CodUsr;
        }
            public static string generarCaracterEspecial(int longitud)
            {
                const string chars = "*-+/!@#$%^&()_=?";
                return new string(Enumerable.Repeat(chars, longitud).Select(s => s[aleatorio.Next(s.Length)]).ToArray());
            }
            public static string generarNumero(int longitud)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, longitud).Select(s => s[aleatorio.Next(s.Length)]).ToArray());
        }
            public static string generarMayuscula(int longitud)
        {
            const string chars = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, longitud).Select(s => s[aleatorio.Next(s.Length)]).ToArray());
        }
            public static string generarMixto(int longitud)
        {
            const string chars = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, longitud).Select(s => s[aleatorio.Next(s.Length)]).ToArray());
        }
        #endregion

        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
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
        }
        private async Task<bool> notificarAlUsuario(string Idduipersonay, string userUsuario, string PassUsuario)
        {
            try
            {
                #region +
                await AvisaYCerrateVosSolo("Verificando los correos de la firma...", "", 1);
                Mouse.OverrideCursor = Cursors.Wait;
                //Mouse.OverrideCursor = null;
                firma ListadoFirmas = new firma();
                List<correo> ListadoCorreos = new List<correo>();
                List<correo> ListadoCorreosFirma = new List<correo>();
                using (db = new SGPTEntidades())
                {
                    ListadoFirmas = db.firmas.First();
                    if (ListadoFirmas != null)
                        ListadoCorreosFirma = (ListadoFirmas.correos).ToList();
                    ListadoCorreos = (from c in db.correos where c.idduipersona == Idduipersonay && c.estadocorreo == "A" orderby c.idcorreo select c).ToList();
                }

                if (ListadoFirmas != null && ListadoCorreosFirma.Count > 0)
                {
                    #region +
                    //var ListadoCorreosFirma = (ListadoFirmas[0].correos).ToList();
                    string correoHostEmisor = "";
                    string contrasena = "";
                    int puerto = 0;
                    string host = "";
                    bool sslOk = false;
                    string RazonSocial = ListadoFirmas.razonsocialfirma;
                    int existecorreoFirma = 0;
                    foreach (var k in ListadoCorreosFirma)
                    {
                        if (k.estadoverificacioncorreo == "Verificado" && k.codigosolicitadocorreo == k.codigoverificadocorreo && k.principalcorreo == true)
                        {
                            #region _
                            correoHostEmisor = k.direccioncorreo;
                            contrasena = ircnEseD(k.contraseniacorreo);
                            puerto = (int)k.puertocorreo;
                            host = k.hostcorreo;
                            sslOk = (bool)k.sslrequeridocorreo;
                            existecorreoFirma++;
                            #endregion
                        }
                    }
                    if (existecorreoFirma > 0)
                    {
                        #region +
                        if (ListadoCorreos != null) //si el usuario a modificar tiene correos
                        {
                            Mouse.OverrideCursor = null;
                            await AvisaYCerrateVosSolo("Verificando los correos del usuario...", "", 1);
                            Mouse.OverrideCursor = Cursors.Wait;
                            #region _
                            int correosinformados = 0;
                            if (true)
                            {
                                #region _
                                foreach (var a in ListadoCorreos)
                                {
                                    #region _
                                    string correoDirigidoA = a.direccioncorreo;
                                    //string correoHostEmisor = SelectedCorreoAgregado.direccioncorreo;
                                    //string contrasena = ircnEseD(SelectedCorreoAgregado.contraseniacorreo);
                                    string titulo = "Notificacion de cambios en su nick y clave de acceso";
                                    //int puerto = (int)SelectedCorreoAgregado.puertocorreo;
                                    //string host = SelectedCorreoAgregado.hostcorreo;
                                    //bool sslOk = (bool)SelectedCorreoAgregado.sslrequeridocorreo;

                                    string cuerpo = "\n \t\t*** Notificacion de cuenta de usuario. ***. \n\nLos datos fueron cambiados este dia: " + DateTime.Now.ToShortDateString() + " \n\nRecuerde que puede cambiar estos valores en cualquier momento que lo necesite.\n\n\t\t  Usuario: => \t" + userUsuario + "\n\t\t  Contraseña: => \t " + PassUsuario;
                                    var mensajero = new EnviameElEmailCamaleon();
                                    bool enviado = mensajero.EnviarEmail(correoDirigidoA, correoHostEmisor, RazonSocial, contrasena, titulo, cuerpo, puerto, host, sslOk);
                                    if (enviado)
                                    {
                                        correosinformados++;
                                    }
                                    #endregion
                                }
                                if (correosinformados > 0)
                                {
                                    //MessageBox.Show("El usuario ha sido informado en " + correosinformados + " Correos registrados y validos");
                                    await AvisaYCerrateVosSolo("El usuario ha sido informado en " + correosinformados + " Correos registrados y validos", "", 3);
                                    return true;
                                }
                                else
                                {
                                    await AvisaYCerrateVosSolo("El usuario no pudo ser notificado de su usuario ni contraseñas.", "Verifique haber introducido correctamente los correos electronicos, y que halla acceso a internet.", 2);
                                    return false;
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            //MessageBox.Show("No existe ningun correo donde pueda ser notificado el usuario."); 
                            await AvisaYCerrateVosSolo("Atencion, No existe ningun correo donde pueda ser notificado el usuario.", "Introduzca un correo valido del usuario y vuelva a intentarlo", 4);
                            Mouse.OverrideCursor = null;
                            return false;
                        }
                        #endregion
                    }
                    else
                    { //MessageBox.Show("La firma no posee un correo verificado apto para emitir correos.", "La firma no posee un correo valido", MessageBoxButton.OK, MessageBoxImage.Stop);
                        Mouse.OverrideCursor = null;
                        await AvisaYCerrateVosSolo("La firma no posee un correo verificado apto para emitir correos.", "Ingrese un correo valido del usuario y vuelva a intenterlo", 4);
                        return false;
                    }
                    #endregion
                }
                else
                {
                    Mouse.OverrideCursor = null;
                    await AvisaYCerrateVosSolo("Atencion, no existe ninguna firma registrada", "Imposible continuar", 2);

                    return false;
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al notificar al usuario " + e.InnerException);
            }
            return false;
        }

        public static string ircnEseD(byte[] _cAdd)
        {
            #region +
            if (_cAdd != null)
            {
                char[] chars = new char[_cAdd.Length / sizeof(char)];
                System.Buffer.BlockCopy(_cAdd, 0, chars, 0, _cAdd.Length);
                return new string(chars);
            }
            else
            {
                string chars = "";
                return chars;
            }
            #endregion
        }
        #endregion

        #region Recobrar password

        private string ConvertToUnsecureString(System.Security.SecureString securePassword)
        {
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        #endregion
    }
}