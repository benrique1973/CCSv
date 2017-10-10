using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading.Tasks;

namespace SGPTmvvm.Modales
{
    public class CRUDusuariosViewModel : ViewModeloBase
    {

        #region Listas 
        public SGPTEntidades db = new SGPTEntidades();
        private DialogCoordinator dlg;
        public List<role> ListadoRoles { get; set; }
        //public List<telefono> ListadoTelefonos { get; set; }
        //ObservableCollection<telefono> _telefonos = new ObservableCollection<telefono>();
        public List<telefonoModelo> ListadoTelefonos { get; set; }
        List<telefono> _telefonos = new List<telefono>();
        public List<correo> ListadoCorreos { get; set; }
        List<correo> _correos = new List<correo>();
        public List<persona> ListadoPersonas { get; set; }
        public List<usuario> ListadoUsuarios = new List<usuario>();
        public List<usuario> ListadoDeUsuarios { get; set; } //este listado solamente servira para verificar que no exista un duplicado en las iniciales.
        public ObservableCollection<permisosrolesusuario> permisosRolesU = new ObservableCollection<permisosrolesusuario>();
        public List<String> QueSexo { get; set; }
        public List<pista> ListadoPistas { get; set; }
        public List<tipostelefono> ListadoTipoTelefono { get; set; }
        private static Random aleatorio = new Random();

        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;

        public string correosYCodigosDeActivacion;
        #endregion

        public CRUDusuariosViewModel()
        {
            dlg = new DialogCoordinator();
            correosYCodigosDeActivacion = string.Empty;
            //UsuariosMensajeModal msg
            this.comprobarInternet();
            //MessageBox.Show("Atencion. No podra guardar nada si no posee conexion a internet.", "No posee conexion a internet",MessageBoxButton.OK,MessageBoxImage.Warning);
            Messenger.Default.Register<UsuariosMensajeModal>(this, (usuariosMensajeModal) => EscuchandoALaVista(usuariosMensajeModal));

            cmdGuardar_Click = new SGPTmvvm.Soporte.RelayCommando(cmdGuardar); //Cambie la forma de llamar al cmdGuardar, porque el RelayComando me permite enviar como parametro casi cualquier cosa, y en este caso, traigo el objeto PasswordBox completo ya que ilogicamente no es bindiable.
            _canExecute = true;
            //this.EscuchandoALaVista(msg);
        }

        private async void comprobarInternet()
        {
            if (!HayInterSioNo())
                await AvisaYCerrateVosSolo("Atencion. No podra guardar nada si no posee conexion a internet.", "No posee conexion a internet", 2);
        }


        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(UsuariosMensajeModal Mensajito)
        {
            //currentUsuario = Mensajito.usuarioAModificar;
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    this.EditarUsuario(Mensajito); break;
                case TipoComando.Consultar:
                    this.ConsultarUsuario(Mensajito); break;
                case TipoComando.Nuevo:
                    this.NuevoUsuario(); break;
                default: break;
            }
        }


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
        #endregion

        public ICommand cmdGuardar_Click
        {
            get;
            private set;
        }


        private ICommand _cmdQuitCorreos_Click;
        public ICommand cmdQuitCorreos_Click
        {
            get
            {
                return _cmdQuitCorreos_Click ?? (_cmdQuitCorreos_Click = new CommandHandler(() => cmdQuitCorreos(), _canExecute));
            }
        }

        private ICommand _cmdAgreCorreos_Click;
        public ICommand cmdAgreCorreos_Click
        {
            get
            {
                return _cmdAgreCorreos_Click ?? (_cmdAgreCorreos_Click = new CommandHandler(() => cmdAgreCorreos(), _canExecute));
            }
        }

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

        private ICommand _cmdCancelar_Click;
        public ICommand cmdCancelar_Click
        {
            get
            {
                return _cmdCancelar_Click ?? (_cmdCancelar_Click = new CommandHandler(() => cmdCancelar(), _canExecute));
            }
        }

        #region Message
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }
        #endregion


        /***********************************/
        #region Eventos

        //public event PropertyChangedEventHandler PropertyChanged;

        //public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}


        #endregion

        /***********************************/
        #region Campos
        #region CorreoyTelefono
        /*Estos dos campos no pertenecen a ninguna de las dos tablas, pero se agregan para bindiarlas con el List de Telefonos y de Correos
         Ya que los correos y los telefonos se guardaran despues de guardado el usuario y la persona pq necesita el id de el*/
        private string _telefonoT;
        private string _correoT;

        public string TelefonoT { get { return _telefonoT; } set { _telefonoT = value; RaisePropertyChanged("TelefonoT "); } }
        public string CorreoT { get { return _correoT; } set { _correoT = value; RaisePropertyChanged("CorreoT"); } }
        #endregion

        private string _idduipersona;
        //private string _DUIChanged;
        private string _nombrespersona;
        private string _apellidospersona;
        private string _sexopersona;
        private string _direccionpersona;
        private string _noafppersona;
        private string _noissspersona;
        private string _nitpersona;
        private string _estadopersona;

        private DateTime _fechacontratacion = DateTime.Now.AddYears(1);//DateTime.Now.ToShortDateString()+"am";
        private string _fechadebaja;
        private string _fecharegistrousuario;
        //private int _idfirma;
        private int _idrol;
        private int _usuidusuario;
        private int _idpista;
        private int _idusuario;

        private string _nickusuariousuario;
        private String _contraseniausuario;
        private string _repetircontraseniausuario;
        private string _inicialesusuario;
        private string _respuestapistausuario;
        private string _numerocvpausuario;
        private DateTime _fechacvpausuario;
        private string _estadousuario;

        //[DisplayName("DUI")]
        //[MaxLength(9, ErrorMessage = "Excede de 9 caracteres permitidos")]
        //[Required(ErrorMessage = "El DUI es requerido")]
        //public string Idduipersonay { get { return GetValue(() => _idduipersona); } set { SetValue(() => _idduipersona, value); RaisePropertyChanged("Idduipersonay"); } }

        //DUIChanged
        public string Idduipersonay { get { return _idduipersona; } set { _idduipersona = value; RaisePropertyChanged("Idduipersonay"); } }
        //public string DUIChanged { get { return _DUIChanged; } set { _DUIChanged = value; MessageBox.Show(_DUIChanged.Length+" Cambio "); RaisePropertyChanged("DUIChanged"); } }
        
        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(9, ErrorMessage = "Excede de 9 caracteres permitidos")]
        public string Nombrespersona { get { return GetValue(() => _nombrespersona); } set { SetValue(() => _nombrespersona, value); RaisePropertyChanged("Nombrespersona"); this.CalcularIniciales(); } }
        //[ExcludeChar(ErrorMessage = "El Apellido contiene caracteres invalidos")]
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Apellidospersona { get { return GetValue(() => _apellidospersona); } set { SetValue(() => _apellidospersona, value); RaisePropertyChanged("Apellidospersona"); this.CalcularIniciales(); } }

        private void CalcularIniciales()
        {
            try
            {
                if (!string.IsNullOrEmpty(Nombrespersona) && !string.IsNullOrEmpty(Apellidospersona))
                {
                    #region +
                    string[] nom = Nombrespersona.Split(' ');
                    string[] ape = Apellidospersona.Split(' ');
                    string Iniciales = "";
                    foreach (var a in nom)
                    {
                        if (a.Length > 0)
                        {
                            Iniciales += a.Substring(0, 1).ToUpper();
                        }
                    }
                    foreach (var a in ape)
                    {
                        if (a.Length > 0)
                        {
                            Iniciales += a.Substring(0, 1).ToUpper();
                        }
                    }
                    //Voy a recorrer el listado de usuarios y buscar que ninguno tenga las iniciales aqui calculadas. de lo contrario le agregaremos un correlativo
                    int encontrados = 0;
                    bool enc = ListadoDeUsuarios.Exists(x => x.inicialesusuario.Trim() == Iniciales.Trim());
                    if (enc)
                    {
                        string aini;
                        foreach (var a in ListadoDeUsuarios)
                        {
                            bool esnum = (a.inicialesusuario.Trim()).Substring(a.inicialesusuario.Length-1,1).All(char.IsDigit);
                            bool esnum2 = (a.inicialesusuario.Trim()).Substring(a.inicialesusuario.Length - 2, 2).All(char.IsDigit);
                            aini= (a.inicialesusuario.Trim());
                            if(esnum2) //si los dos ultimos caracteres son digitos
                                aini= (a.inicialesusuario.Trim()).Substring(0, a.inicialesusuario.Length - 2);
                            else if(esnum) // si solo el ultimo caracter es digito.
                                aini= (a.inicialesusuario.Trim()).Substring(0, a.inicialesusuario.Length - 1);
                            //}
                            
                            if (aini == Iniciales.Trim())
                                encontrados++;
                        }
                        if (encontrados > 0)
                        {
                            encontrados++;
                            Iniciales += encontrados.ToString();
                        } 
                    }

                    Inicialesusuario = Iniciales;
                    RaisePropertyChanged("Inicialesusuario");
                    #endregion
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al calcular las iniciales " + e.InnerException);
            }
        }
        public string Sexopersona { get { return _sexopersona; } set { _sexopersona = value; RaisePropertyChanged("Sexopersona"); } }

        public string Direccionpersona { get { return _direccionpersona; } set { _direccionpersona = value; RaisePropertyChanged("Direccionpersona"); } }
        public string Noafppersona { get { return _noafppersona; } set { _noafppersona = value; RaisePropertyChanged("Noafppersona"); } }
        public string Noissspersona { get { return _noissspersona; } set { _noissspersona = value; RaisePropertyChanged("Noissspersona"); } }
        public string Nitpersona { get { return _nitpersona; } set { _nitpersona = value; RaisePropertyChanged("Nitpersona"); } }
        public string Estadopersona { get { return _estadopersona; } set { _estadopersona = value; RaisePropertyChanged("Estadopersona"); } }
        /*Usuarios*/

        public int Idusuario { get { return _idusuario; } set { _idusuario = value; RaisePropertyChanged("Idusuario"); } }
        public int Idpista { get { return _idpista; } set { _idpista = value; RaisePropertyChanged("Idpista"); } }
        public int Usuidusuario { get { return _usuidusuario; } set { _usuidusuario = value; RaisePropertyChanged("Usuidusuario"); } }
        public int Idrol { get { return _idrol; } set { _idrol = value; RaisePropertyChanged("Idrol"); } }
        //public int Idfirma { get { return _idfirma; } set { _idfirma = value; RaisePropertyChanged("Idfirma"); } }
        public string Fecharegistrousuario { get { return _fecharegistrousuario; } set { _fecharegistrousuario = value; RaisePropertyChanged("Fecharegistrousuario"); } }
        public string Fechadebaja { get { return _fechadebaja; } set { _fechadebaja = value; RaisePropertyChanged("Fechadebaja"); } }
        public DateTime Fechacontratacion { get { return _fechacontratacion; } set { _fechacontratacion = value; RaisePropertyChanged("Fechacontratacion"); } }

        public string Nickusuariousuario { get { return _nickusuariousuario; } set { _nickusuariousuario = value; RaisePropertyChanged("Nickusuariousuario"); this.comprobarNoEsDuplicadoNck(); } }

        private async void comprobarNoEsDuplicadoNck()
        {
            if (!AccionGuardar && Nickusuariousuario!=null)
            {
                try
                {
                    Random rnd = new Random();
                    if (ListadoDeUsuarios != null)
                    {
                        var regenc = ListadoDeUsuarios.Find(x => x.nickusuariousuario.Trim() == Nickusuariousuario.Trim());
                        //bool enc = ListadoDeUsuarios.Exists(x => x.nickusuariousuario.Trim() == Nickusuariousuario.Trim());
                        if (regenc != null && regenc.idduipersona != Idduipersonay && regenc.inicialesusuario != Inicialesusuario)
                        {
                            await AvisaYCerrateVosSolo("El NICK no esta disponible!... ", "El sistema le propondra una mejora", 2);
                            string nex = rnd.Next(20, 9999).ToString();
                            Nickusuariousuario = Nickusuariousuario + nex;
                        }
                    }
                    else
                        await AvisaYCerrateVosSolo("No se pudo establecer la comunicacion con la base de datos.","Verifique su disponibilidad",2);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error al intentar comunicarse con la base de datos. " + e, "Verifique la disponibilidad de la base de datos.");
                }
            }
        }
        public string Contraseniausuario { get { return _contraseniausuario; } set { this.Repetircontraseniausuario="";
                                                                                    if (this._contraseniausuario == value)return; 
                                                                                    _contraseniausuario = value; 
                                                                                    RaisePropertyChanged("Contraseniausuario"); } }
        //[CompareAttribute("Contraseniausuario", ErrorMessage = "Verifique que la contraseña sea la misma")]
        public string Repetircontraseniausuario { get { return _repetircontraseniausuario; } set { _repetircontraseniausuario=value; RaisePropertyChanged("Repetircontraseniausuario"); } }
        //public string Repetircontraseniausuario{ get { return GetValue(() => _repetircontraseniausuario); } set { SetValue(() => _repetircontraseniausuario, value); RaisePropertyChanged("Repetircontraseniausuario"); } }
        public string Inicialesusuario { get { return _inicialesusuario; } set { _inicialesusuario = value; RaisePropertyChanged("Inicialesusuario"); } }
        public string Respuestapistausuario { get { return _respuestapistausuario; } set { _respuestapistausuario = value; RaisePropertyChanged("Respuestapistausuario"); } }
        public string Numerocvpausuario { get { return _numerocvpausuario; } set { _numerocvpausuario = value; RaisePropertyChanged("Numerocvpausuario"); } }
        public DateTime Fechacvpausuario { get { return _fechacvpausuario; } set { _fechacvpausuario = value; RaisePropertyChanged("Fechacvpausuario"); } }
        public string Estadousuario { get { return _estadousuario; } set { _estadousuario = value; RaisePropertyChanged("Estadousuario"); } }

        #endregion
        /***********************************/
        #region Bindiados

        private string _txtBandera; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }
        /*************************************/
        private bool _correoPrincipalChek;
        public bool CorreoPrincipalChek
        {
            get { return _correoPrincipalChek; }
            set
            {
                if (CorreoPrincipalChek != value)
                {
                    _correoPrincipalChek = value;
                    RaisePropertyChanged("CorreoPrincipalChek");
                    //if (PropertyChanged != null)
                        //PropertyChanged(this, new PropertyChangedEventArgs("CorreoPrincipalChek"));
                }
            }
        }
        /**********************************************/
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
                //RaisePropertyChanged("CanModify");
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
                RaisePropertyChanged("SelectedCorreoAgregado");
                //RaisePropertyChanged("CanModify");
            }
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

      

        private persona _selectedJefeSuperior;
        public persona SelectedJefeSuperior
        {
            get
            {
                return _selectedJefeSuperior;
            }
            set
            {
                _selectedJefeSuperior = value;
                RaisePropertyChanged("SelectedJefeSuperior");
            }
        }
        /**************************************************/
        private pista _selectedPistas;
        public pista SelectedPistas
        {
            get
            {
                return _selectedPistas;
            }
            set
            {
                _selectedPistas = value;
                RaisePropertyChanged("SelectedPistas");
            }
        }
        /***************************************************/
        //SelectedRol
        private role _selectedRol;
        public role SelectedRol
        {
            get
            {
                return _selectedRol;
            }
            set
            {
                _selectedRol = value;
                RaisePropertyChanged("SelectedRol");
            }
        }
        /**************************************************/
       
        /**************************************************/
        #endregion
        /***********************************/
        public void Habilitadores(bool estado)
        {
            if (estado)
            {
                #region v
                HabilitarDUI = true;
                HabilitartxtNombrex = true;
                HabilitartxtApellidos = true;
                HabilitartxtNickUsuario = true;
                HabilitartxtContraseña = true;
                HabilitartxtRepitaContraseña = true;
                HabilitartxtIniciales = true;
                HabilitarcmbPista = true;
                HabilitartxtRespuestaPista = true;
                HabilitardpickFechaCVPA = true;
                HabilitarcmbSexo = true;
                HabilitartxtCVPA = true;
                HabilitartxtDireccion = true;
                HabilitartxtAFP = true;
                Habilitartxtnoissspersona = true;
                HabilitartxtNIT = true;
                HabilitarcmbRoles = true;
                HabilitarcmbJefes = true;
                HabilitarGridCorreos = true;
                HabilitarGridTelefonos = true; 
                #endregion
            }
            else 
            {
                #region v
                HabilitarDUI = false;
                HabilitartxtNombrex = false;
                HabilitartxtApellidos = false;
                HabilitartxtNickUsuario = false;
                HabilitartxtContraseña = false;
                HabilitartxtRepitaContraseña = false;
                HabilitartxtIniciales = false;
                HabilitarcmbPista = false;
                HabilitartxtRespuestaPista = false;
                HabilitardpickFechaCVPA = false;
                HabilitarcmbSexo = false;
                HabilitartxtCVPA = false;
                HabilitartxtDireccion = false;
                HabilitartxtAFP = false;
                Habilitartxtnoissspersona = false;
                HabilitartxtNIT = false;
                HabilitarcmbRoles = false;
                HabilitarcmbJefes = false;
                HabilitarGridCorreos = false;
                HabilitarGridTelefonos = false;
                #endregion
            }
        }
        #region HAbilitadores
        private Boolean _habilitarDUI;
        public Boolean HabilitarDUI
        {
            get
            {
                return _habilitarDUI;
            }
            set
            {
                _habilitarDUI = value;
                RaisePropertyChanged("HabilitarDUI");
            }
        }

        private Boolean _HabilitartxtNombrex;
        public Boolean HabilitartxtNombrex
        {
            get
            {
                return _HabilitartxtNombrex;
            }
            set
            {
                _HabilitartxtNombrex = value;
                RaisePropertyChanged("HabilitartxtNombrex");
            }
        }

        private Boolean _HabilitartxtApellidos;
        public Boolean HabilitartxtApellidos
        {
            get
            {
                return _HabilitartxtApellidos;
            }
            set
            {
                _HabilitartxtApellidos = value;
                RaisePropertyChanged("HabilitartxtApellidos");
            }
        }

        private Boolean _HabilitartxtNickUsuario;
        public Boolean HabilitartxtNickUsuario
        {
            get
            {
                return _HabilitartxtNickUsuario;
            }
            set
            {
                _HabilitartxtNickUsuario = value;
                RaisePropertyChanged("HabilitartxtNickUsuario");
            }
        }

        private Boolean _HabilitartxtContraseña;
        public Boolean HabilitartxtContraseña
        {
            get
            {
                return _HabilitartxtContraseña;
            }
            set
            {
                _HabilitartxtContraseña = value;
                RaisePropertyChanged("HabilitartxtContraseña");
            }
        }

        private Boolean _HabilitartxtRepitaContraseña;
        public Boolean HabilitartxtRepitaContraseña
        {
            get
            {
                return _HabilitartxtRepitaContraseña;
            }
            set
            {
                _HabilitartxtRepitaContraseña = value;
                RaisePropertyChanged("txtRepitaContraseña");
            }
        }

        private Boolean _HabilitartxtIniciales;
        public Boolean HabilitartxtIniciales
        {
            get
            {
                return _HabilitartxtIniciales;
            }
            set
            {
                _HabilitartxtIniciales = value;
                RaisePropertyChanged("HabilitartxtIniciales");
            }
        }

        private Boolean _HabilitarcmbPista=true;
        public Boolean HabilitarcmbPista
        {
            get
            {
                return _HabilitarcmbPista;
            }
            set
            {
                _HabilitarcmbPista = value;
                RaisePropertyChanged("HabilitarcmbPista");
            }
        }

        private Boolean _HabilitartxtRespuestaPista=true;
        public Boolean HabilitartxtRespuestaPista
        {
            get
            {
                return _HabilitartxtRespuestaPista;
            }
            set
            {
                _HabilitartxtRespuestaPista = value;
                RaisePropertyChanged("HabilitartxtRespuestaPista");
            }
        }

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

        private Boolean _HabilitarcmbSexo;
        public Boolean HabilitarcmbSexo
        {
            get
            {
                return _HabilitarcmbSexo;
            }
            set
            {
                _HabilitarcmbSexo = value;
                RaisePropertyChanged("HabilitarcmbSexo");
            }
        }

        private Boolean _habilitartxtCVPA;
        public Boolean HabilitartxtCVPA
        {
            get
            {
                return _habilitartxtCVPA;
            }
            set
            {
                _habilitartxtCVPA = value;
                RaisePropertyChanged("habilitartxtCVPA");
            }
        }

        private Boolean _HabilitartxtDireccion;
        public Boolean HabilitartxtDireccion
        {
            get
            {
                return _HabilitartxtDireccion;
            }
            set
            {
                _HabilitartxtDireccion = value;
                RaisePropertyChanged("HabilitartxtDireccion");
            }
        }

        private Boolean _HabilitartxtAFP;
        public Boolean HabilitartxtAFP
        {
            get
            {
                return _HabilitartxtAFP;
            }
            set
            {
                _HabilitartxtAFP = value;
                RaisePropertyChanged("HabilitartxtAFP");
            }
        }

        private Boolean _Habilitartxtnoissspersona;
        public Boolean Habilitartxtnoissspersona
        {
            get
            {
                return _Habilitartxtnoissspersona;
            }
            set
            {
                _Habilitartxtnoissspersona = value;
                RaisePropertyChanged("Habilitartxtnoissspersona");
            }
        }

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

        private Boolean _HabilitarcmbRoles;
        public Boolean HabilitarcmbRoles
        {
            get
            {
                return _HabilitarcmbRoles;
            }
            set
            {
                _HabilitarcmbRoles = value;
                RaisePropertyChanged("HabilitarcmbRoles");
            }
        }

        private Boolean _HabilitarcmbJefes;
        public Boolean HabilitarcmbJefes
        {
            get
            {
                return _HabilitarcmbJefes;
            }
            set
            {
                _HabilitarcmbJefes = value;
                RaisePropertyChanged("HabilitarcmbJefes");
            }
        }

        private Boolean _HabilitarGridCorreos;
        public Boolean HabilitarGridCorreos
        {
            get
            {
                return _HabilitarGridCorreos;
            }
            set
            {
                _HabilitarGridCorreos = value;
                RaisePropertyChanged("HabilitarGridCorreos");
            }
        }

        private Boolean _HabilitarGridTelefonos;
        public Boolean HabilitarGridTelefonos
        {
            get
            {
                return _HabilitarGridTelefonos;
            }
            set
            {
                _HabilitarGridTelefonos = value;
                RaisePropertyChanged("HabilitarGridTelefonos");
            }
        }
        #endregion

        public void enviarMensaje()
        {
            Messenger.Default.Unregister<UsuariosMensajeModal>(this);
            //Creando el mensaje de cierre
            VentanaViewMensajeFin cierre = new VentanaViewMensajeFin();
            cierre.mensaje = -1;
            Messenger.Default.Send<VentanaViewMensajeFin>(cierre);
        }

        public void inicializarListados()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region +
            
                try
                {
                    using (db = new SGPTEntidades())
                    {
                    #region +
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;

                    ListadoRoles = (from r in db.roles where r.sistemarol == false && r.estadorol=="A" orderby r.nombrerol select r).ToList();
                    //role seleccioneunrol = new role();
                    //seleccioneunrol.idrol = -1; seleccioneunrol.nombrerol = "--Seleccione un rol--";
                    //ListadoRoles.Insert(0, seleccioneunrol);

                    //ListadoFirmas = (from f in db.firmas orderby f.idfirma select f).ToList();
                    ListadoPistas = (from p in db.pistas orderby p.idpista select p).ToList();


                    ListadoTipoTelefono = (from p in db.tipostelefonos orderby p.idtt select p).ToList();
                    ListadoPersonas = (from a in db.personas
                                       orderby a.nombrespersona
                                       where a.estadopersona == "A"
                                       select a).ToList();

                    ListadoUsuarios = new List<usuario>();
                    ListadoDeUsuarios = db.usuarios.ToList(); //Listado solo para verificar que no haya un duplicado de iniciales

                    persona seleccioneunjefe = new persona();
                    seleccioneunjefe.idduipersona = "N";
                    seleccioneunjefe.nombrespersona = "--Seleccione un jefe--";
                    ListadoPersonas.Insert(0, seleccioneunjefe); 
                    #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La base de datos tardo demasiado en responder.\n Informe a soporte tecnico acerca de este error. " + ex.InnerException, "No se pudo accesar a la base de datos", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            
            QueSexo = new List<string>() { "Masculino", "Femenino" };
            RaisePropertyChanged(""); 
            #endregion
            Mouse.OverrideCursor = null;
        }
        /*Listado Correos telefonos se utiliza para recuperarlos cuando se va modificar un usuario*/
        public void listadoCorreosTelefonos(String DUI)
        //recupera los correos y los telefonos del usuario a modificar.
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region +
            try
            {
                using (db = new SGPTEntidades())
                {
                    #region +
                    //ListadoTelefonos = (from t in db.telefonos where t.idduipersona == DUI orderby t.idtt select t).ToList();
                    var lListadoTelefonos = (from t in db.telefonos where t.idduipersona == DUI orderby t.idtt select t).ToList();
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

                    ListadoCorreos = (from t in db.correos where t.idduipersona == DUI orderby t.idcorreo select t).ToList();

                    RaisePropertyChanged("");
                    #endregion
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al recuperar el listado de los telefonos " + e.InnerException);
            } 
            #endregion
            Mouse.OverrideCursor = null;
        }

        private void NuevoUsuario()
        {
            #region +
            this.Habilitadores(true); //le solicito que active todos los campos
            AccionGuardar = true;
            AccionConsultar = false;
            this.inicializarListados();
            Fechacvpausuario = DateTime.Now;
            Fechacontratacion = DateTime.Now.AddYears(1);
            HabilitarDUI = true;
            Nickusuariousuario = "Automatico";
            string genegene = generarCodigoUser();
            Contraseniausuario = genegene;
            RaisePropertyChanged("Contraseniausuario");
            Repetircontraseniausuario = genegene;
            /*Deshabilito los campos, pq cuando se crea el administrador no conoce el usuario ni la contraseña generado, sino que se notificara por email al usuario*/
            HabilitartxtNickUsuario = false;
            HabilitartxtContraseña = false;
            HabilitartxtRepitaContraseña = false;
            HabilitarcmbPista = false;
            HabilitartxtRespuestaPista = false;
            txtBandera = "1";
            RaisePropertyChanged("");

            //HabilitarTipoFirma = true;
            Message = "Nuevo Usuario"; 
            #endregion
        }

        #region Generar Codigo Usuario
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

        static public DateTime convierteEnFecha(string fecha)
        {
            #region +
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
            #endregion
        }
        private void EditarUsuario(UsuariosMensajeModal Mensajito)
        {
            this.Habilitadores(true); //le solicito que active todos los campos
            this.inicializarListados();
            AccionGuardar = false;
            AccionConsultar = false;
            Message = "Modificar usuario ";
            this.CompartidaConsultarEditar(Mensajito);
        }

        private void CompartidaConsultarEditar(UsuariosMensajeModal Mensajito)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region MyRegion
            try
            {
                #region +
                usuariospersonas usua = Mensajito.usuarioAModificar.TheUsuariosPersonas;
                //firma fir = new firma();
                role rolh = new role();
                pista pist = new pista();
                persona persh = new persona();
                List<persona> Tpersh = new List<persona>();

                List<role> Trolh = new List<role>();
                List<pista> Tpist = new List<pista>();

                try
                {
                    #region +
                    using (db = new SGPTEntidades())
                    {
                        //rolh = db.roles.Find(usua.idrol);//lo sacamos para precargarlo por defecto en el evento SelectedItem
                        //Trolh = (db.roles).ToList();
                        Trolh = (from r in db.roles where r.sistemarol == false orderby r.nombrerol select r).ToList();
                        rolh = Trolh.Find(x => x.idrol == usua.idrol);
                        //pist = db.pistas.Find(usua.idpista);//lo sacamos para precargarlo por defecto en el evento SelectedItem
                        Tpist = (db.pistas).ToList(); //lo obtenemos para que el usuario pueda seleccionar otras opciones en el combobox
                        pist = Tpist.Find(y => y.idpista == usua.idpista);
                        persh = db.personas.Join(db.usuarios, p => p.idduipersona, u => u.idduipersona, (p, u) => new { personas = p, usuarios = u }).Where(uu => uu.usuarios.idusuario == usua.usuidusuario).Select(uu => uu.personas).SingleOrDefault();

                        Tpersh = (db.personas).Where(p => p.estadopersona == "A" && p.idduipersona != usua.idduipersona).ToList(); //lo obtenemos para que el usuario pueda seleccionar otras opciones en el combobox 
                    }
                    #endregion
                }
                catch (Exception e)
                {

                    MessageBox.Show("Ocurrio un error al recuperar los datos del usuario: " + e.InnerException);
                }

                //Idfirma = usua.idfirma;
                //ListadoFirmas.Add(fir);
                //SelectedTipoFirma = fir; //actualizamos el binding de la firma
                //MessageBox.Show("3 Cargando los datos en los controles en editar");
                //---------------------------------
                Idrol = usua.idrol;
                ListadoRoles = Trolh;
                SelectedRol = rolh;

                //---------------------------------
                Idpista = usua.idpista;
                ListadoPistas = Tpist;
                SelectedPistas = pist;
                //---------------------------------
                Sexopersona = (usua.sexopersona == "M") ? "Masculino" : "Femenino";
                //----------------------------------
                //HabilitarTipoFirma = false; //Deshabilitamos el combobox para que no se pueda modificar/seleccionar otra la firma.
                Idduipersonay = usua.idduipersona;
                HabilitarDUI = false;
                //----------------------------------
                Usuidusuario = usua.usuidusuario;
                ListadoPersonas = Tpersh;
                SelectedJefeSuperior = persh; //Le indicamos al combobox cual es el jefe seleccionado antes de la modificacion
                //----------------------------------
                Nombrespersona = usua.nombrespersona;
                Apellidospersona = usua.apellidospersona;

                Direccionpersona = usua.direccionpersona;
                Noafppersona = usua.noafppersona;
                Noissspersona = usua.noissspersona;
                Nitpersona = usua.nitpersona;
                Estadopersona = usua.estadopersona;
                Idpista = usua.idpista; //Int32.Parse(cmbPista.Text),
                Usuidusuario = usua.usuidusuario; //Int32.Parse(cmbJefes.Text),
                //MessageBox.Show("4 antes de primera fecha");
                Fecharegistrousuario = usua.fecharegistrousuario;
                Nickusuariousuario = usua.nickusuariousuario;
                Contraseniausuario = usua.contraseniausuario;
                Inicialesusuario = usua.inicialesusuario;
                Respuestapistausuario = usua.respuestapistausuario;//GetMd5Hash(md5Hash, txtRespuestaPista.Text),
                Numerocvpausuario = usua.numerocvpausuario;
                // Atencion, falta regresar la base al modo fecha.
                //Fechacvpausuario = Convert.ToDateTime(usua.fechacvpausuario);
                Fechacvpausuario = convierteEnFecha(usua.fechacvpausuario);
                if (usua.fechacontratacion.Length > 5)
                    Fechacontratacion = convierteEnFecha(usua.fechacontratacion);
                else
                    Fechacontratacion = DateTime.Now.AddYears(1);
                Estadousuario = usua.estadousuario;

                //MessageBox.Show("cargando los correos en editar");
                ListadoCorreos = (usua.correos).ToList();
                foreach (correo coo in ListadoCorreos)
                { if (coo.estadocorreo == "A") _correos.Add(coo); }
                //ListadoTelefonos = (usua.telefonos).ToList();
                //foreach (telefono too in ListadoTelefonos) { _telefonos.Add(too); }
                var lListadoTelefonos = (usua.telefonos).ToList();
                ListadoTelefonos = new List<telefonoModelo>();
                foreach (telefono too in lListadoTelefonos)
                {
                    if (too.estadotelefono == "A")
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
                }
                RaisePropertyChanged("ListadoTelefonos");

                /*activamos la bandera, para que cuando Click en guardar, haga un Update*/
                AccionGuardar = false;
                RaisePropertyChanged("");
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error La base de datos no ha respondido en el tiempo permitido. " + e.InnerException);
            } 
            #endregion
            Mouse.OverrideCursor = null;
        }

        private void ConsultarUsuario(UsuariosMensajeModal Mensajito)
        {
            this.Habilitadores(false); //le solicito que desactive todos los campos
            this.inicializarListados();
            AccionGuardar = false;
            AccionConsultar = true;

            Message = "Consultar usuario ";

            this.CompartidaConsultarEditar(Mensajito);
        }


        private async Task<bool> validacionManualOK()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region +
            try
            {
                //Permite verificar que la informacion que se quiere guardar este completa y en orden valido
                #region +
                if (AccionGuardar)
                {
                    #region
                    if (Idduipersonay != null && Idduipersonay.Length >= 9) //Obligatorio
                    {
                        #region MyRegion
                        if (Nombrespersona != null && Nombrespersona.Length > 3 && Nombrespersona.Length <= 30 && Apellidospersona != null && Apellidospersona.Length > 1 && Apellidospersona.Length <= 30) //Obligatorio
                        {
                            #region
                            if (Inicialesusuario != null && Inicialesusuario.Length > 2 && Inicialesusuario.Length <= 6) //Obligatorio
                            {
                                #region
                                //if (Nickusuariousuario != null && Nickusuariousuario.Length > 1 && Nickusuariousuario.Length <= 12) //Obligatorio
                                //{
                                #region
                                //if (Contraseniausuario != null && Contraseniausuario.Length >= 8 && Contraseniausuario.Length <= 12)//Obligatorio
                                //{
                                #region
                                if (SelectedPistas != null || SelectedPistas == null) //No es obligatorio
                                {
                                    #region
                                    //if (Respuestapistausuario != null  && Respuestapistausuario.Length > 0 && Respuestapistausuario.Length < 33)//Obligatorio pq MD5 llega a 32
                                    //{
                                    if (Fechacvpausuario <= DateTime.Now)
                                    {
                                        #region
                                        if (String.IsNullOrEmpty(Numerocvpausuario) || Numerocvpausuario.Length < 5)
                                        {
                                            #region
                                            if (Sexopersona != null) //Obligatorio
                                            {
                                                #region
                                                if (String.IsNullOrEmpty(Noafppersona) || Noafppersona.Length >= 11 && Noafppersona.Length <= 12)
                                                {
                                                    #region
                                                    if (String.IsNullOrEmpty(Noissspersona) || Noissspersona.Length >= 9 && Noissspersona.Length <= 11)
                                                    {
                                                        #region
                                                        if (String.IsNullOrEmpty(Nitpersona) || Nitpersona.Length >= 14 && Nitpersona.Length <= 17)
                                                        {
                                                            #region
                                                            if (SelectedRol != null) //Obligatorio
                                                            {
                                                                if (ListadoCorreos != null)
                                                                {
                                                                    //Si todo se cumplio, entonces emitimos true para que pueda guardar
                                                                    return true;
                                                                }
                                                                else
                                                                { //MessageBox.Show("Es obligatorio uno o mas correos electronicos validos del usuario. \nServira para enviarle su Nick y su Contraseña segura", "Atencion, Ingrese un correo electronico", MessageBoxButton.OK, MessageBoxImage.Stop); 
                                                                    await AvisaYCerrateVosSolo("Es obligatorio uno o mas correos electronicos validos del usuario. \nServira para enviarle su Nick y su Contraseña segura", "Atencion, Ingrese un correo electronico", 2);
                                                                    return false;
                                                                }
                                                            }
                                                            else
                                                            { //MessageBox.Show("Imposible guardar. Seleccione un rol para este usuario. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Stop); 
                                                                await AvisaYCerrateVosSolo("Asigne un rol para el usuario", "", 2);
                                                                return false;
                                                            }
                                                            #endregion
                                                        }
                                                        else
                                                        { //MessageBox.Show("Imposible guardar. La longitud del NIT no puede superar los 17. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                            await AvisaYCerrateVosSolo("La longitud del NIT esta incorrecta.", "ingrese un nit con el siguiente formato 9999-999999-999-9", 2);
                                                            return false;
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    { //MessageBox.Show("Imposible guardar. Longitud del numero de ISSS debe ser menor o igual que 11. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                        await AvisaYCerrateVosSolo("El numero de ISSS es erroneo", "La longitud menor o igual a 11", 2);
                                                        return false;
                                                    }
                                                    #endregion
                                                }
                                                else
                                                { //MessageBox.Show("Imposible guardar. Longitud del numero AFP la longitud debe ser menor o igual que 12. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                    await AvisaYCerrateVosSolo("Numero AFP es erroneo", "La longitud debe ser menor o igual a 12", 1);
                                                    return false;
                                                }
                                                #endregion
                                            }
                                            else
                                            { //MessageBox.Show("Imposible guardar. Seleccione el sexo del usuario. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                await AvisaYCerrateVosSolo("Seleccione el sexo", "", 1);
                                                return false;
                                            }
                                            #endregion
                                        }
                                        else
                                        { //MessageBox.Show("Imposible guardar. El numero CVPA no debe ser mayor a 4  . ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                            await AvisaYCerrateVosSolo("El numero CVPA debe ser menor o igual que 4 digitos", "", 1);
                                            return false;
                                        }
                                        #endregion
                                    }
                                    else
                                    { //MessageBox.Show("Imposible guardar. La fecha introducida no es valida.", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                        await AvisaYCerrateVosSolo("La fecha introducida no es valida", "", 1);
                                        return false;
                                    }
                                    //}
                                    //else { MessageBox.Show("Imposible guardar. Ingrese una respuesta que le sea facil recordar para la pista seleccionada. longitud [1 y 32]", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); return false; }
                                    #endregion
                                }
                                else
                                { //MessageBox.Show("Imposible guardar. Seleccione una pista que servira para recordar su contraseña", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                    await AvisaYCerrateVosSolo("Seleccione una pista que servira para recordar su contraseña", "", 1);
                                    return false;
                                }
                                #endregion
                                //}
                                //else { MessageBox.Show("Imposible guardar. Ingrese una contraseña segura de longitud entre [6 y 10]", "Atencion", MessageBoxButton.OK, MessageBoxImage.Stop); return false; }
                                #endregion
                                //}
                                //else { MessageBox.Show("Imposible guardar. Digite un NICK que lo identifique y que pueda recordar facilmente. Le servira para iniciar sesion. Longitud [2 y 12]", "Informacion critica!!!", MessageBoxButton.OK, MessageBoxImage.Stop); return false; }
                            }
                                #endregion
                            else
                            { //MessageBox.Show("Imposible guardar. Digite las iniciales que utilizara para la auditoria. Longitud [3 y 6]", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                await AvisaYCerrateVosSolo("Digite las iniciales que utilizara para firmar la auditoria", "", 1);
                                return false;
                            }
                            #endregion
                        }
                        else
                        { //MessageBox.Show("Imposible guardar. Digite un Nombre y un Apellido valido", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                            await AvisaYCerrateVosSolo("Digite un nombre y apellidos validos", "", 1);
                            return false;
                        }
                        #endregion
                    }
                    else
                    { //MessageBox.Show("Imposible guardar. Digite un Numero de DUI valido", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                        await AvisaYCerrateVosSolo("Digite un DUI valido", "", 1);
                        Mouse.OverrideCursor = null;
                        return false;
                    }
                    #endregion
                }
                else//si la accion es Modificar
                {
                    #region
                    if (Idduipersonay != null && Idduipersonay.Length >= 9) //Obligatorio
                    {
                        #region MyRegion
                        if (Nombrespersona != null && Nombrespersona.Length > 3 && Nombrespersona.Length <= 30 && Apellidospersona != null && Apellidospersona.Length > 1 && Apellidospersona.Length <= 30) //Obligatorio
                        {
                            #region
                            if (Inicialesusuario != null && Inicialesusuario.Length > 2 && Inicialesusuario.Length <= 6) //Obligatorio
                            {
                                #region
                                
                                if (Nickusuariousuario != null && Nickusuariousuario.Length > 3 && Nickusuariousuario.Length <= 12) //Obligatorio
                                {
                                    //bool nickduplicado = ListadoDeUsuarios.Exists(x => x.nickusuariousuario.Trim() == Nickusuariousuario.Trim());
                                    //if (!nickduplicado)
                                    //{
                                        #region
                                        if (Contraseniausuario != null && Contraseniausuario.Length >= 8 && Contraseniausuario.Length <= 12 || Contraseniausuario.Length == 32)//Obligatorio
                                        {
                                            #region
                                            if (SelectedPistas != null) //Obligatorio
                                            {
                                                #region
                                                if (Respuestapistausuario != null && Respuestapistausuario.Length > 0 && Respuestapistausuario.Length < 33)//Obligatorio pq MD5 llega a 32
                                                {
                                                    if (Fechacvpausuario <= DateTime.Now)
                                                    {
                                                        #region
                                                        if (String.IsNullOrEmpty(Numerocvpausuario) || Numerocvpausuario.Length < 5)
                                                        {
                                                            #region
                                                            if (Sexopersona != null) //Obligatorio
                                                            {
                                                                #region
                                                                if (String.IsNullOrEmpty(Noafppersona) || Noafppersona.Length >= 11 && Noafppersona.Length <= 12)
                                                                {
                                                                    #region
                                                                    if (String.IsNullOrEmpty(Noissspersona) || Noissspersona.Length >= 9 && Noissspersona.Length <= 11)
                                                                    {
                                                                        #region
                                                                        if (String.IsNullOrEmpty(Nitpersona) || Nitpersona.Length >= 14 && Nitpersona.Length <= 17)
                                                                        {
                                                                            #region
                                                                            if (SelectedRol != null) //Obligatorio
                                                                            {
                                                                                //Si todo se cumplio, entonces emitimos true para que pueda guardar
                                                                                return true;
                                                                            }
                                                                            else
                                                                            { //MessageBox.Show("Imposible guardar. Seleccione un rol para este usuario. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Stop); 
                                                                                await AvisaYCerrateVosSolo("Seleccione un rol para este usuario", "", 1);
                                                                                return false;
                                                                            }
                                                                            #endregion
                                                                        }
                                                                        else
                                                                        { //MessageBox.Show("Imposible guardar. La longitud del NIT no puede superar los 17. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                                            await AvisaYCerrateVosSolo("La longitud del NIT esta incorrecta.", "ingrese un nit con el siguiente formato 9999-999999-999-9", 1);
                                                                            return false;
                                                                        }
                                                                        #endregion
                                                                    }
                                                                    else
                                                                    { //MessageBox.Show("Imposible guardar. Longitud del numero de ISSS debe ser menor o igual que 11. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                                        await AvisaYCerrateVosSolo("El numero de ISSS es erroneo", "La longitud menor o igual a 11", 1);
                                                                        return false;
                                                                    }
                                                                    #endregion
                                                                }
                                                                else
                                                                { //MessageBox.Show("Imposible guardar. Longitud del numero AFP la longitud debe ser menor o igual que 12. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                                    await AvisaYCerrateVosSolo("Numero AFP es erroneo", "La longitud debe ser menor o igual a 12", 1);
                                                                    return false;
                                                                }
                                                                #endregion
                                                            }
                                                            else
                                                            { //MessageBox.Show("Imposible guardar. Seleccione el sexo del usuario. ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                                await AvisaYCerrateVosSolo("Seleccione el sexo del usuario", "", 1);
                                                                return false;
                                                            }
                                                            #endregion
                                                        }
                                                        else
                                                        { //MessageBox.Show("Imposible guardar. El numero CVPA no debe ser mayor a 4  . ", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                            await AvisaYCerrateVosSolo("El numero CVPA debe ser menor o igual que 4 digitos", "", 1);
                                                            return false;
                                                        }
                                                        #endregion
                                                    }
                                                    else
                                                    { //MessageBox.Show("Imposible guardar. La fecha introducida no es valida.", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                        await AvisaYCerrateVosSolo("La fecha introducida no es valida", "", 1);
                                                        return false;
                                                    }
                                                }
                                                else
                                                { //MessageBox.Show("Imposible guardar. Ingrese una respuesta que le sea facil recordar para la pista seleccionada. longitud [1 y 32]", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                    await AvisaYCerrateVosSolo("Ingrese una respuesta que le sea facil recordar para la pista seleccionada. longitud [1 y 32]", "", 1);
                                                    return false;
                                                }
                                                #endregion
                                            }
                                            else
                                            { //MessageBox.Show("Imposible guardar. Seleccione una pista que servira para recordar su contraseña", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                                await AvisaYCerrateVosSolo("Seleccione una pista que servira para recordar su contraseña", "", 1);
                                                return false;
                                            }
                                            #endregion
                                        }
                                        else
                                        { //MessageBox.Show("Imposible guardar. Ingrese una contraseña segura de longitud entre [6 y 10]", "Atencion", MessageBoxButton.OK, MessageBoxImage.Stop); 
                                            await AvisaYCerrateVosSolo("Ingrese una contraseña segura de longitud entre [8 y 12]", "", 1);
                                            return false;
                                        }
                                        #endregion
                                    //}
                                    //else
                                    //{
                                    //    await AvisaYCerrateVosSolo("El NICK introducido no esta disponible", "Cambie el Nick para continuar...", 1);
                                    //    return false;
                                    //}
                                }
                                else
                                { //MessageBox.Show("Imposible guardar. Digite un NICK que lo identifique y que pueda recordar facilmente. Le servira para iniciar sesion. Longitud [2 y 12]", "Informacion critica!!!", MessageBoxButton.OK, MessageBoxImage.Stop); 
                                    await AvisaYCerrateVosSolo("Digite un NICK que lo identifique y que pueda recordar facilmente", "Le servira para iniciar sesion. Longitud [2 y 12]", 1);
                                    return false;
                                }
                            }
                                #endregion
                            else
                            { //MessageBox.Show("Imposible guardar. Digite las iniciales que utilizara para la auditoria. Longitud [3 y 6]", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                                await AvisaYCerrateVosSolo("Digite las iniciales que utilizara para firmar la auditoria", "", 1);
                                return false;
                            }
                            #endregion
                        }
                        else
                        { //MessageBox.Show("Imposible guardar. Digite un Nombre y un Apellido valido", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                            await AvisaYCerrateVosSolo("Digite un nombre y apellidos validos", "", 1);
                            return false;
                        }
                        #endregion
                    }
                    else
                    { //MessageBox.Show("Imposible guardar. Digite un Numero de DUI valido", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                        await AvisaYCerrateVosSolo("Digite un DUI valido", "Ej. 99999999-9", 1);
                        return false;
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en la validacion manual " + e.InnerException);
                Mouse.OverrideCursor = null;
                return false;
            } 
            #endregion

        }

        //Comprobamos que el DUI del nueovo usuario no se encuentre en la base.
        private bool noesduplicadoUsuarioOK()
        {
            #region +
            try
            {
                var encontrado = ListadoPersonas.Find(x => x.idduipersona == Idduipersonay);
                if (encontrado != null) { return true; }
                else { return false; }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al verificar si no es duplicado " + e.InnerException);
            }
            return false; 
            #endregion
        }

        /*Funcion para desenmascarar una clave textboxchar encriptada*/
        private string ConvertirACadenaInsegura(System.Security.SecureString securePassword)
        {
            //try
            //{
                #region +
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
                #endregion
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Error al convertir a cadena insegura "+e.InnerException);
            //}
        }

        private void ConvertirASombi()
        {
            //necesita no ser sombi
        }
//*************************************************************************************************************************************************************************
        private async void cmdGuardar(Object parametroDesdeVista) //Traigo el passwordbox como parametro desde el relayCommand, ya que el passwordBox no se deja Bindiar.
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region +
            try
            {
                if (HayInterSioNo())
                {
                    #region _
                    //Contenedor Password es un PasswordBox que como no se puede bindiar, entonces viene como una referencia de toda la vista
                    PasswordBox parametroDesdeVistas = (PasswordBox)parametroDesdeVista;
                    var ContenedorPassword = parametroDesdeVistas.SecurePassword; //parametroDesdeVista as YoTengoPassword;

                    if (ContenedorPassword != null)
                    {
                        var cadenaSegura = ContenedorPassword; //.Password;// ContenedorPassword.Password;
                        Contraseniausuario = ConvertirACadenaInsegura(cadenaSegura);
                    }

                    if (!noesduplicadoUsuarioOK())
                    {
                        #region v
                        if (await validacionManualOK()) //envia a validar la informacion.
                        {
                            #region _
                            MD5 md5Hash = MD5.Create();
                            int Usuidusu = 0;
                            if (SelectedJefeSuperior != null && SelectedJefeSuperior.idduipersona.Length > 9)
                            {
                                #region
                                //vamos a traer un valor especifico, si no lo encuentra, entonces devolvera null en int?
                                using (db = new SGPTEntidades())
                                {
                                    int? IdxUsu = (from f in db.usuarios where f.idduipersona.Equals(SelectedJefeSuperior.idduipersona) select f.idusuario).FirstOrDefault();
                                    if (IdxUsu != null)
                                    {
                                        Usuidusu = (int)IdxUsu;
                                    }
                                }

                                #endregion
                            }

                            String Sexopersonax = "";
                            if (Sexopersona != null) { Sexopersonax = (Sexopersona == "Masculino") ? "M" : "F"; }
                            if (AccionGuardar)
                            {
                                #region _
                                if (ListadoCorreos != null)
                                {
                                    #region
                                    //using (db = new SGPTEntidades())
                                    //{
                                        /*****************************Guardando lo de la tabla usuarios************/
                                        #region Preparacion de datos de tabla usuarios
                                        if (SelectedPistas != null)
                                            Idpista = SelectedPistas.idpista; //valor capturado en el combobox
                                        else
                                            Idpista = 1; //lo dejo quemado "Cual es su mascota favorita"
                                        //Idfirma = SelectedTipoFirma.idfirma;//valor capturado en el combobox
                                        Idrol = SelectedRol.idrol;//valor capturado en el combobox
                                        string fechacvpausuariox = "";
                                        if (Fechacvpausuario != null) //verifico que no este vacia.
                                        {
                                            #region *
                                            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                                            fechacvpausuariox = Fechacvpausuario.ToString();
                                            #endregion
                                        }

                                        #endregion
                                        usuario usuaLL = new usuario();
                                        #region
                                        usuaLL.idusuario = 1000;
                                        usuaLL.idduipersona = Idduipersonay;
                                        if (Idpista > 0)
                                            usuaLL.idpista = Idpista;
                                        usuaLL.usuidusuario = Usuidusu;
                                        usuaLL.idrol = Idrol;
                                        //usuaLL.idfirma = Idfirma;
                                        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                                        usuaLL.fecharegistrousuario = (DateTime.Now).ToString();
                                        usuaLL.fechadebaja = "";
                                        if (Fechacontratacion.Year == DateTime.Now.AddYears(1).Year) // por defecto tiene un año mas que la fecha actual. Es entendido que no puede registrar el contrato de una persona con fecha mayor que la de hoy mas un año. 
                                            usuaLL.fechacontratacion = "";
                                        else
                                            usuaLL.fechacontratacion = Fechacontratacion.ToShortDateString();
                                        Nickusuariousuario = Nombrespersona.Substring(0, 3) + Apellidospersona.Substring(0, 3) + generarNumero(3);
                                        usuaLL.nickusuariousuario = Nickusuariousuario;
                                        string genegene = generarCodigoUser();
                                        Contraseniausuario = genegene;

                                        usuaLL.contraseniausuario = GetMd5Hash(md5Hash, Contraseniausuario);
                                        usuaLL.inicialesusuario = Inicialesusuario;

                                        Respuestapistausuario = "osito"; //lo dejo quemado y se lo envio al correo
                                        if (!string.IsNullOrEmpty(Respuestapistausuario))
                                            usuaLL.respuestapistausuario = GetMd5Hash(md5Hash, Respuestapistausuario);
                                        usuaLL.numerocvpausuario = Numerocvpausuario;
                                        usuaLL.fechacvpausuario = fechacvpausuariox;
                                        usuaLL.estadousuario = "A";

                                        ListadoUsuarios.Add(usuaLL);
                                        #endregion
                                   
                                        /*****************************Guardando lo de la tabla personas************/

                                        var pers = new persona
                                        {
                                            #region
                                            usuarios = ListadoUsuarios,
                                            idduipersona = Idduipersonay,
                                            nombrespersona = Nombrespersona,
                                            apellidospersona = Apellidospersona,
                                            sexopersona = Sexopersonax,
                                            direccionpersona = Direccionpersona,
                                            noafppersona = Noafppersona,
                                            noissspersona = Noissspersona,
                                            nitpersona = Nitpersona,
                                            estadopersona = "A"
                                            #endregion
                                        };
                                        if (ListadoCorreos != null)
                                        {
                                            pers.correos = ListadoCorreos;
                                        }
                                        if (ListadoTelefonos != null)
                                        {
                                            pers.telefonos = _telefonos.ToList(); //ListadoTelefonos;
                                        }
                                        /***************************/


                                        #region
                                        try
                                        {

                                            if (await this.notificarAlUsuario(Idduipersonay, Nickusuariousuario, Contraseniausuario))
                                            {
                                            //int i=1;
                                            //if(i==1)
                                            //{
                                                using (db=new SGPTEntidades())
                                                {
                                                    db.personas.Add(pers);
                                                    db.SaveChanges(); 
                                                }
                                                /****************************************************************************/
                                                //Va notificar al usuario.
                                                /****************************************************************************/

                                                //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                                //dlg.ShowMessageAsync(this, "El registro se guardo con éxito", "Finalizado.");
                                                await AvisaYCerrateVosSolo("El registro se guardo con éxito", "Finalizado.", 2);
                                                /************************************************************************************/
                                                /*****Reiniciamos todos los valores a null para un nuevo usuarios*/
                                                //////
                                                this.ReiniciarTodosLosObjetos();
                                                //*******Activamos la bandera de cerrar la vista modal*********/
                                                //_result = true;
                                                //FinalizarAction();
                                                enviarMensaje();
                                                CloseWindow();

                                            }
                                            else
                                            {
                                                //MessageBox.Show("Se ha cancelado la operacion guardar. Complete alguna de las siguientes indicaciones.\n a) Verifique que tenga conexion a internet. \n b) Compruebe que la firma tiene configurado un correo electronico valido.\n c) Verifique que ha digitado correctamente los correos electronicos del usuario creado.\n d) Asegurese por otros medios si los correos propocionados por el usuario son validos."); 
                                                //await dlg.ShowMessageAsync(this,"Se ha cancelado la operacion guardar. Complete alguna de las siguientes indicaciones" + Environment.NewLine + "a) Verifique que tenga conexion a internet. \n b) Compruebe que la firma tiene configurado un correo electronico valido.\n c) Verifique que ha digitado correctamente los correos electronicos del usuario creado.\n d) Asegurese por otros medios si los correos propocionados por el usuario son validos.", "");
                                                await AvisaYCerrateVosSolo("Se ha cancelado la operacion guardar. Complete alguna de las siguientes indicaciones" + Environment.NewLine + "a) Verifique que tenga conexion a internet. \n b) Compruebe que la firma tiene configurado un correo electronico valido.\n c) Verifique que ha digitado correctamente los correos electronicos del usuario creado.\n d) Asegurese por otros medios si los correos propocionados por el usuario son validos.", "", 5);

                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error. no se pudo almacenar la Persona. \nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este error " + ex, "Error al guardar", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                        #endregion
                                    //}

                                    #endregion
                                }
                                else
                                {
                                    //MessageBox.Show("El nuevo usuario debe ser notificado por correo electronico. \nAgregue por lo menos un correo electronico valido del usuario.", "Se requiere un correo electronico valido", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    await AvisaYCerrateVosSolo("El nuevo usuario debe ser notificado por correo electronico.", "Agregue por lo menos un correo electronico valido del usuario.", 2);
                                }
                                #endregion
                            }
                            else //es una actualizacion.. verificar si no es una consulta
                            {
                                #region _
                                if (!AccionConsultar)
                                {
                                    using (db = new SGPTEntidades())
                                    {
                                        #region
                                        //-------vamos a traer el registro original que va a sufrir modificacion.
                                        usuario usuaOriginal = db.usuarios.SingleOrDefault(o => o.idduipersona == Idduipersonay);
                                        persona persOriginal = db.personas.Find(Idduipersonay);
                                        /*****************************Actualizando lo de la tabla usuarios************/
                                        #region Preparacion de datos de tabla usuarios
                                        Idpista = _selectedPistas.idpista; //valor capturado en el combobox
                                        Idrol = SelectedRol.idrol;//valor capturado en el combobox
                                        string fechacvpausuariox = "";
                                        if (Fechacvpausuario != null)
                                        {
                                            //CurrentCulture es = new CultureInfo("es-SV");
                                            //DateTime fechaTemporal;
                                            //String cadenaFecha = Fechacvpausuario.ToString();
                                            //DateTime.TryParseExact(cadenaFecha, "dd/MM/yyyy", es, DateTimeStyles.AdjustToUniversal, out fechaTemporal);
                                            //Fechacvpausuario = fechaTemporal; //DateTime.ParseExact(usua.fechacvpausuario, "dd/MM/YYYY", new CultureInfo("es-SV"));

                                            //fechacvpausuariox = fechaTemporal.ToString();//
                                            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                                            fechacvpausuariox = Fechacvpausuario.ToString();
                                        }
                                        string fechacontratacionx = "";
                                        if (Fechacontratacion == DateTime.Now.AddYears(1))
                                            fechacontratacionx = "";
                                        else
                                            fechacontratacionx = Fechacontratacion.ToShortDateString();
                                        #endregion

                                        //----------------------Actualizando la tabla usuarios----------------------------------------/
                                        bool hayCambiosEnUsuario = false;
                                        if (usuaOriginal.idrol != Idrol) { usuaOriginal.idrol = Idrol; hayCambiosEnUsuario = true; }
                                        if (usuaOriginal.idpista != Idpista) { usuaOriginal.idpista = Idpista; hayCambiosEnUsuario = true; }
                                        if (usuaOriginal.usuidusuario != Usuidusu) { usuaOriginal.usuidusuario = Usuidusu; hayCambiosEnUsuario = true; }
                                        /*falta dar de baja*/

                                        int banderaDeCambiosEnUsuarioAndPassword = 0;
                                        if (usuaOriginal.nickusuariousuario != Nickusuariousuario) { usuaOriginal.nickusuariousuario = Nickusuariousuario; hayCambiosEnUsuario = true; banderaDeCambiosEnUsuarioAndPassword++; }
                                        if (Contraseniausuario.Length <= 12)
                                        {
                                            if (!(VerifyMd5Hash(md5Hash, Contraseniausuario, usuaOriginal.contraseniausuario))) { usuaOriginal.contraseniausuario = GetMd5Hash(md5Hash, Contraseniausuario); hayCambiosEnUsuario = true; banderaDeCambiosEnUsuarioAndPassword++; }
                                        }

                                        if (usuaOriginal.inicialesusuario != Inicialesusuario) { usuaOriginal.inicialesusuario = Inicialesusuario; hayCambiosEnUsuario = true; }
                                        if (Respuestapistausuario.Length <= 12)
                                        {
                                            if (!(VerifyMd5Hash(md5Hash, Respuestapistausuario, usuaOriginal.respuestapistausuario))) { usuaOriginal.respuestapistausuario = GetMd5Hash(md5Hash, Respuestapistausuario); hayCambiosEnUsuario = true; }
                                        }
                                        if (usuaOriginal.numerocvpausuario != Numerocvpausuario) { usuaOriginal.numerocvpausuario = Numerocvpausuario; hayCambiosEnUsuario = true; }
                                        //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
                                        if (usuaOriginal.fechacvpausuario != fechacvpausuariox) { usuaOriginal.fechacvpausuario = fechacvpausuariox; hayCambiosEnUsuario = true; }
                                        if (usuaOriginal.fechacontratacion != fechacontratacionx) { usuaOriginal.fechacontratacion = fechacontratacionx; hayCambiosEnUsuario = true; }

                                        if (hayCambiosEnUsuario)
                                        {
                                            #region v
                                            try
                                            {
                                                db.Entry(usuaOriginal).State = EntityState.Modified;
                                                db.SaveChanges();

                                                if (banderaDeCambiosEnUsuarioAndPassword > 0)
                                                {
                                                    await this.notificarAlUsuario(Idduipersonay, Nickusuariousuario, Contraseniausuario);
                                                    banderaDeCambiosEnUsuarioAndPassword = 0;
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Se produjo un error al guardar. \nLa base de datos tardo demasiado en responder. \nInforme a Soporte tecnico acerca de este error. " + ex.InnerException, "Error al guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                                            }
                                            #endregion
                                        }
                                        //----------------------Actualizando lo de la tabla personas----------------------------------/
                                        bool hayCambiosEnPersonas = false;
                                        #region
                                        String Sexopersonaj = "";
                                        if (Sexopersona != null) { Sexopersonaj = (Sexopersona == "Masculino") ? "M" : "F"; }
                                        if (persOriginal.nombrespersona != Nombrespersona) { persOriginal.nombrespersona = Nombrespersona; hayCambiosEnPersonas = true; }
                                        if (persOriginal.apellidospersona != Apellidospersona) { persOriginal.apellidospersona = Apellidospersona; hayCambiosEnPersonas = true; }
                                        if (persOriginal.sexopersona != Sexopersonaj) { persOriginal.sexopersona = Sexopersonaj; hayCambiosEnPersonas = true; }
                                        if (persOriginal.direccionpersona != Direccionpersona) { persOriginal.direccionpersona = Direccionpersona; hayCambiosEnPersonas = true; }
                                        if (persOriginal.noafppersona != Noafppersona) { persOriginal.noafppersona = Noafppersona; hayCambiosEnPersonas = true; }
                                        if (persOriginal.noissspersona != Noissspersona) { persOriginal.noissspersona = Noissspersona; hayCambiosEnPersonas = true; }
                                        if (persOriginal.nitpersona != Nitpersona) { persOriginal.nitpersona = Nitpersona; hayCambiosEnPersonas = true; }
                                        if (hayCambiosEnPersonas)
                                        {
                                            #region v
                                            try
                                            {
                                                db.Entry(persOriginal).State = EntityState.Modified;
                                                db.SaveChanges();

                                                //MessageBox.Show("El registro se actualizo con éxito.","Finalizado.",MessageBoxButton.OK,MessageBoxImage.Information);
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show("Se produjo un error al guardar. \nLa base de datos tardo demasiado en responder. \nInforme a Soporte tecnico acerca este error. " + ex.InnerException, "Error.", MessageBoxButton.OK, MessageBoxImage.Stop);
                                            }
                                            #endregion
                                        }
                                        if (hayCambiosEnUsuario || hayCambiosEnPersonas)
                                        {
                                            await AvisaYCerrateVosSolo("El registro se guardo con éxito", "", 1);
                                            //await dlg.ShowMessageAsync(this, "El registro se guardo con éxito x2","" );
                                            //MessageBox.Show("El registro se guardo con éxito");
                                        }
                                        else
                                        {
                                            await AvisaYCerrateVosSolo("No se guardo nada", "", 1);
                                        }
                                        #endregion
                                        //---------------------------------------------------------------------------------------------/
                                        //MessageBox.Show("El registro se actualizo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                        //dlg.ShowMessageAsync(this, "El registro se actualizo con éxito", "Finalizado.!");

                                        this.ReiniciarTodosLosObjetos();
                                        //FinalizarAction();
                                        enviarMensaje();
                                        CloseWindow();
                                        #endregion
                                    }
                                }
                                else //Presiono el boton guardar cuando esta en una consulta. Debera Salir sin guardar nada
                                {
                                    //MessageBox.Show("No hay nada que guardar.", "Salir", MessageBoxButton.OK, MessageBoxImage.Information);
                                    await AvisaYCerrateVosSolo("No hay cambios que guardar.", "", 1);
                                    this.cmdCancelar();
                                }
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            //MessageBox.Show("Imposible guardar. \nSolucione las observaciones antes de poder continuar.", "Mucha atencion!!!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            await AvisaYCerrateVosSolo("Imposible guardar. Solucione las observaciones antes de poder continuar", "Mucha atencion", 2);
                        }
                        #endregion
                    }
                    else
                    { //MessageBox.Show("Imposible guardar.\n El DUI ingresado ya existe." + "\n" + " Sugerencia: Active este usuario con permisos de administrador.", "Atencion", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                        await AvisaYCerrateVosSolo("Imposible guardar, el DUI ingresado ya existe", "", 2);
                    }
                    #endregion
                }
                else
                {
                    //MessageBox.Show("Imposible guardar. Es necesario tener conexion a internet para notificar al usuario acerca de los cambios","No hay conexion a internet",MessageBoxButton.OK,MessageBoxImage.Stop);
                    await AvisaYCerrateVosSolo("Imposible guardar. Es necesario tener conexion a internet para notificar al usuario acerca de los cambios", "No hay conexion a internet", 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error desconocido al guardar el objeto usuario " + e.InnerException);
            } 
            #endregion
            Mouse.OverrideCursor = null;
        }

        /*********************/
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

        /**********************/

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

        private async Task<bool> notificarAlUsuario(string Idduipersonay, string userUsuario, string PassUsuario)
        {
            try
            {
                #region +
                await AvisaYCerrateVosSolo("Verificando los correos de la firma...", "", 1);
                Mouse.OverrideCursor = Cursors.Wait;
                //Mouse.OverrideCursor = null;
                firma ListadoFirmas = new firma();
                
                List<correo> ListadoCorreosFirma = new List<correo>();
                using (db = new SGPTEntidades())
                {
                    ListadoFirmas = db.firmas.First();
                    if (ListadoFirmas != null)
                        ListadoCorreosFirma = (ListadoFirmas.correos).ToList();
                    if (!AccionGuardar || ListadoCorreos == null || ListadoCorreos.Count == 0) //Si no es guardar, entonces es editar
                    {
                        ListadoCorreos = new List<correo>();
                        ListadoCorreos = (from c in db.correos where c.idduipersona == Idduipersonay && c.estadocorreo == "A" orderby c.idcorreo select c).ToList();
                    }
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
                            if (AccionGuardar)
                            {
                                #region _
                                foreach (var a in ListadoCorreos)
                                {
                                    string correoDirigidoA = a.direccioncorreo;

                                    string titulo = "Notificacion de generacion de usuario y clave de acceso al SGPT";
                                    string cuerpo = "\n Sistema de Gestion de Papeles de Trabajo TG-UES2016.\n\n\t Notificacion de creacion de usuario y clave de acceso al SGPT.\n\n\t\t*** Notificacion de creacion de cuenta de usuario. ***. \n\nLos datos fueron creados aleatoriamente el dia " + DateTime.Now.ToString() + " por un administrador. \n\nATENCION: Recuerde por seguridad que debe CAMBIAR estos valores al primer ingreso, o cuando lo desee.\n****************************************\n\n\t\t  Usuario: => \t" + userUsuario + "\t\t  Contraseña: => \t " + PassUsuario + "\t\t  Respuesta a pregunta secreta: => \t " + Respuestapistausuario + "\n****************************************\n\n\n Codigos de activacion de correos. \n\t"+correosYCodigosDeActivacion; //

                                    var mensajero = new EnviameElEmailCamaleon();
                                    bool enviado = mensajero.EnviarEmail(correoDirigidoA, correoHostEmisor, RazonSocial, contrasena, titulo, cuerpo, puerto, host, sslOk);
                                    if (enviado)
                                    {
                                        correosinformados++;
                                    }
                                }
                                if (correosinformados > 0)
                                {
                                    #region +
                                    //MessageBox.Show("El usuario ha sido informado en " + correosinformados + " Correos registrados y validos");
                                    Mouse.OverrideCursor = null;
                                    await AvisaYCerrateVosSolo("El usuario ha sido informado en " + correosinformados + " Correos registrados y validos", "Proceso finalizado con éxito", 2);

                                    return true;
                                    #endregion
                                }
                                else
                                {
                                    #region +
                                    //MessageBox.Show("El usuario no pudo ser notificado de su usuario ni contraseñas.\n Verifique haber introducido correctamente los correos electronicos, y que tenga acceso a internet. \n ", "Error. correos invalidos", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    Mouse.OverrideCursor = null;
                                    await AvisaYCerrateVosSolo("El usuario no pudo ser notificado" + Environment.NewLine + "de los cambios en sus credenciales de usuario ni contraseñas.", "Verifique haber introducido correctamente los correos electronicos" + Environment.NewLine + "Verifique que halla acceso a internet y repita el proceso.", 4);

                                    return false;
                                    #endregion
                                }
                                #endregion
                            }
                            else //si es editar
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
                                    await AvisaYCerrateVosSolo( "El usuario ha sido informado en " + correosinformados + " Correos registrados y validos", "",2);
                                    return true;
                                }
                                else
                                {
                                    await AvisaYCerrateVosSolo("El usuario no pudo ser notificado de su usuario ni contraseñas.", "Verifique haber introducido correctamente los correos electronicos, y que halla acceso a internet.",2);
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
                MessageBox.Show("Error al notificar al usuario "+e.InnerException);
            }
            return false;
        }

        #region _
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

        private void cmdCancelar() 
		{
            this.ReiniciarTodosLosObjetos();
            //_result = false;
            //FinalizarAction();
            enviarMensaje();
            CloseWindow();
        }


        /*****************************/
        #region Encriptacion
        /************************/
        /*Clases GethMD5Hash y VerifyMd5Hash, son recursos para encriptar la clave del usuario*/
        static string GetMd5Hash(MD5 md5Hash, string input)
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

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private async Task cuenteUno(int c)
        {
            await Task.Delay(c);
        }

        /*Gestiona los correos y los telefonos de los usuarios.*/
        #region AgregarCorreos, QuitarCorreos, AgregarTelefono,QuitarTelefono

        public async void cmdAgreTelef()
        {
            try
            {
                #region +
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
                            telef.idduipersona = Idduipersonay;
                            telef.numerotelefono = TelefonoT;
                            telef.estadotelefono = "A";
                            _telefonos.Add(telef);

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
                            //MessageBox.Show("Telefono agregado.", "Finalizado..", MessageBoxButton.OK, MessageBoxImage.Information);
                            //await dlg.ShowMessageAsync(this, "El telefono ha sido agregado", "Finalizado.!");
                            await AvisaYCerrateVosSolo("El telefono ha sido agregado", "Finalizado.", 1);
                            //await cuenteUno(10);
                            //await dlg.HideMetroDialogAsync(this,null);
                            TelefonoT = "";
                            SelectedTipoTelefono = null;
                            RaisePropertyChanged("TelefonoT");
                            if (!AccionGuardar) //Entonces es Editar
                            {
                                //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                                Random rnd = new Random();
                                using (db = new SGPTEntidades())
                                {
                                    try
                                    {
                                        telef.idtelefono = rnd.Next(1000, 100000);
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
                        //await dlg.ShowMessageAsync(this, "El numero de telefono ya existe", "");
                        await AvisaYCerrateVosSolo("El numero de telefono ya existe", "Digite uno nuevo", 2);
                    }
                }
                else
                {
                    //MessageBox.Show("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI.", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    await AvisaYCerrateVosSolo("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI", "Falta informacion",2);
                }

                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error en agregar el telefono "+e.InnerException);
            }
        }
        private async void cmdQuitTelefono()
        {
            try
            {
                #region +
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
                    await AvisaYCerrateVosSolo("Un telefono fue quitado", "", 1);
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al quitar el telefono "+e.InnerException);
            }
        }

        private async void cmdAgreCorreos()
        {
            try
            {
                #region +
                if (Idduipersonay != null && Idduipersonay.Length >= 9 && CorreoT != null && CorreoT.Length >= 7 && CorreoT.Length <= 60)
                {
                    bool correoencontrado = _correos.Exists(y => y.direccioncorreo == CorreoT);
                    if (!correoencontrado)
                    {
                        Random rnd = new Random();
                        try
                        {
                            #region
                            correo Corre = new correo();
                            Corre.idcorreo = rnd.Next(1, 100);
                            //Corre.idfirma = SelectedTipoFirma.idfirma;
                            Corre.idduipersona = Idduipersonay;
                            Corre.direccioncorreo = CorreoT;
                            Corre.principalcorreo = CorreoPrincipalChek;
                            string cod = generarCodigoComprobacion(10);
                            Corre.codigosolicitadocorreo = cod;
                            Corre.estadoverificacioncorreo = "No verificado";
                            correosYCodigosDeActivacion += "; Correo: " + CorreoT + " => Codigo activacion: " + cod;
                            Corre.estadocorreo = "A";
                            _correos.Add(Corre);
                            ListadoCorreos = _correos.ToList();
                            //await dlg.ShowMessageAsync(this, "El correo ha sido agregado", "Finalizado.!");
                            await AvisaYCerrateVosSolo("El correo ha sido agregado", "Finalizado.", 1);
                            //await cuenteUno(10);
                            //await dlg.HideMetroDialogAsync(this, null);
                            //MessageBox.Show("Correo agregado.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            CorreoPrincipalChek = false; //reiniciamos para que quede deshabilitado
                            CorreoT = "";
                            RaisePropertyChanged("");
                            if (!AccionGuardar) //Entonces es Editar
                            {
                                //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                                using (db = new SGPTEntidades())
                                {
                                    try
                                    {
                                        db.correos.Add(Corre);
                                        db.SaveChanges();

                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Ocurrio un error al actualizar correo " + ex.InnerException, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    }
                                }
                            }
                            #endregion
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al agregar el Correo.\n La base de datos gtardo demasiado en responder.\n Informe a soporte tecnico acerca de este error. " + ex, "Error al guardar", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El E-mail ya existe", "");
                        await AvisaYCerrateVosSolo("El E-mail ya existe y esta registrado", "", 2);
                    }
                }
                else
                {
                    //MessageBox.Show("Ingrese un correo valido, verifique el DUI no este vacio", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    await AvisaYCerrateVosSolo("Ingrese un correo valido, verifique el DUI no este vacio", "Falta informacion",1);
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al agregar el correo "+e.InnerException);
            }
        }

        //private string generarCodigoComprobacion(int p)
        //{
        //    throw new NotImplementedException();
        //}
        #region cadenaverificacionAleatoria
        private static Random aleatoriox = new Random();
        public static string generarCodigoComprobacion(int longitud)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, longitud).Select(s => s[aleatoriox.Next(s.Length)]).ToArray());
        }

        #endregion

        private async void cmdQuitCorreos()
        {
            try
            {
                #region +
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
                                MessageBox.Show("Ocurrio un error al eliminar el correo.\n la base de datos tardo demasiado en responder. \n informe a soporte tecnico acerca de este error." + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                    }
                    _correos.Remove(SelectedCorreoAgregado);
                    ListadoCorreos = _correos.ToList();
                    RaisePropertyChanged("ListadoCorreos");
                    await AvisaYCerrateVosSolo("Un correo fue eliminado", "", 1);
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al quitar el correo " + e.InnerException);
            }
        }

        #endregion

        private void ReiniciarTodosLosObjetos()
        {
            try
            {
                #region +
                /*Limpiamos todas las listas*/
                if (ListadoRoles != null)
                {
                    ListadoRoles.Clear();
                }
                if (ListadoTelefonos != null)
                {
                    ListadoTelefonos.Clear();
                }
                if (_telefonos != null)
                {
                    _telefonos.Clear();
                }
                if (ListadoCorreos != null)
                {
                    ListadoCorreos.Clear();
                }
                if (_correos != null)
                {
                    _correos.Clear();
                }
                if (ListadoPersonas != null)
                {
                    ListadoPersonas.Clear();
                }
                if (ListadoUsuarios != null)
                {
                    ListadoUsuarios.Clear();
                }
                //if (ListadoFirmas != null)
                //{
                //    ListadoFirmas.Clear();
                //}
                if (ListadoPistas != null)
                {
                    ListadoPistas.Clear();
                }
                if (ListadoTipoTelefono != null)
                {
                    ListadoTipoTelefono.Clear();
                }

                /*Limpiamos todos los campos*/
                Idduipersonay = null;
                Nombrespersona = null;
                Apellidospersona = null;
                Sexopersona = null;
                Direccionpersona = null;
                Noafppersona = null;
                Noissspersona = null;
                Nitpersona = null;
                Estadopersona = null;

                Fechacontratacion = DateTime.Now.AddYears(1);
                Fechadebaja = null;
                Fecharegistrousuario = null;
                //Idfirma = 0;
                Idrol = 0;
                Usuidusuario = 0;
                Idpista = 0;
                Idusuario = 0;

                Nickusuariousuario = null;
                Contraseniausuario = null;
                Inicialesusuario = null;
                Respuestapistausuario = null;
                Numerocvpausuario = null;
                Fechacvpausuario = Convert.ToDateTime("01/01/0001 01:01:01");
                Estadousuario = null;
                RaisePropertyChanged("");
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al reiniciar todos los objetos " + e.InnerException);
            }
        }
    }
    
}