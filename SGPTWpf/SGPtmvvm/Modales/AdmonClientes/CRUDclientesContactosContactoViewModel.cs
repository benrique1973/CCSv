using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTmvvm.Modales.AdmonClientes
{

    public class CRUDclientesContactosContactoViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<DiccioGenericTipoLista> otrasFuncionesListad { get; set; }
        public List<estructurasorganica> estructuraOListado { get; set; }
        public List<estructurasorganica> ListadoEstructuraO { get; set; }

        public List<cliente> ClientesListado { get; set; }
       // public List<usuariospersonas> ListadoUsuarios { get; set; }//= new List<usuariospersonas>();


        private DialogCoordinator dlg;



        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        #region Message y currentUsuario
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }

        private string _MessageCliente;
        public string MessageCliente { get { return _MessageCliente; } set { _MessageCliente = value; RaisePropertyChanged("MessageCliente"); } }
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

        private string _llamadoDesde;
        public string llamadoDesde
        {
            get { return _llamadoDesde; }
            set
            {
                _llamadoDesde = value;
                RaisePropertyChanged("llamadoDesde");
            }
        }

        private ContactosModelo _ContactoAModificar;
        public ContactosModelo ContactoAModificar
        {
            get{return _ContactoAModificar;}
            set{_ContactoAModificar=value; RaisePropertyChanged("ContactoAModificar");}
        }

        #endregion
        #endregion
        //public CRUDfirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg, DialogCoordinator dlgIn)
        public CRUDclientesContactosContactoViewModel(ClientesContactosMensajeModal msg)
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            _canExecute = true;
            currentUsuario = msg.UsuarioValidado;
            currentCliente = msg.currentCliente;
            ContactoAModificar=msg.ContactosAmodificar;
            MessageCliente = currentCliente.razonsocialcliente;
            this.inicializarListados();
            llamadoDesde = msg.llamadoDesde;
            this.EscuchandoALaVista(msg);
            dlg = new DialogCoordinator();//dlgIn;

        }

        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(ClientesContactosMensajeModal Mensajito)
        {
            //currentUsuario = Mensajito.UsuarioValidado;
            //currentCliente = Mensajito.currentCliente;
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    Editar(Mensajito); break;
                case TipoComando.Consultar:
                    Consultar(Mensajito);
                    break;
                case TipoComando.Nuevo:
                    Nuevo(); break;
                default: break;
            }

        }


        #region Campos
            #region Campos Estructura Organica
            //private int _idcargoeo;
            //private int _estidcargoeo;
            //private string _idnitcliente;
            //private string _nombrecargoeo;
            //private string _responsabilidadeo;
            //private string _funcionadicionaleo;
            //private string _estadoeo;

            //public int Idcargoeo { get { return _idcargoeo; } set { _idcargoeo = value; RaisePropertyChanged("Idcargoeo"); } }
            //public int Estidcargoeo { get { return _estidcargoeo; } set { _estidcargoeo = value; RaisePropertyChanged("Estidcargoeo"); } }
            //public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
            //public string Nombrecargoeo { get { return _nombrecargoeo; } set { _nombrecargoeo = value; RaisePropertyChanged("Nombrecargoeo"); } }
            //public string Responsabilidadeo { get { return _responsabilidadeo; } set { _responsabilidadeo = value; RaisePropertyChanged("Responsabilidadeo"); } }
            //public string Funcionadicionaleo { get { return _funcionadicionaleo; } set { _funcionadicionaleo = value; RaisePropertyChanged("Funcionadicionaleo"); } }
            //public string Estadoeo { get { return _estadoeo; } set { _estadoeo = value; RaisePropertyChanged("Estadoeo"); } }

            #endregion
            #region Campos Contactos
            private int _idcontacto;
            private int _idcargoeoc;
            private string _nombrescontacto;
            private string _apellidoscontacto;
            private string _telefono;
            private string _celular;
            private string _email;
            private string _observaciones;
            private DateTime _fechainiciofuncioncontacto;
            private string _fechacesefuncioncontacto;
            private string _estadocontacto;

            public int Idcontacto { get { return _idcontacto; } set { _idcontacto = value; RaisePropertyChanged("Idcontacto"); } }
            public int Idcargoeoc { get { return _idcargoeoc; } set { _idcargoeoc = value; RaisePropertyChanged("Idcargoeoc"); } }
            public string Nombrescontacto { get { return _nombrescontacto; } set { _nombrescontacto = value; RaisePropertyChanged("Nombrescontacto"); } }
            public string Apellidoscontacto { get { return _apellidoscontacto; } set { _apellidoscontacto = value; RaisePropertyChanged("Apellidoscontacto"); } }

            public string Telefono { get { return _telefono; } set { _telefono = value; RaisePropertyChanged("Telefono"); } }
            public string Celular { get { return _celular; } set { _celular = value; RaisePropertyChanged("Celular"); } }
            public string Email { get { return _email; } set { _email = value; RaisePropertyChanged("Email"); } }
            public string Observaciones { get { return _observaciones; } set { _observaciones = value; RaisePropertyChanged("Observaciones"); } }

            public DateTime Fechainiciofuncioncontacto { get { return _fechainiciofuncioncontacto; } set { _fechainiciofuncioncontacto = value; RaisePropertyChanged("Fechainiciofuncioncontacto"); } }
            public string Fechacesefuncioncontacto { get { return _fechacesefuncioncontacto; } set { _fechacesefuncioncontacto = value; RaisePropertyChanged("Fechacesefuncioncontacto"); } }
            public string Estadocontacto { get { return _estadocontacto; } set { _estadocontacto = value; RaisePropertyChanged("Estadocontacto"); } }
            #endregion

        #endregion

        #region Bindiados

        private string _txtBandera = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }

        private estructurasorganica _selectedEstructuraO;
        public estructurasorganica SelectedEstructuraO
        {
            get { return _selectedEstructuraO; }
            set
            {
                _selectedEstructuraO = value;
                RaisePropertyChanged("SelectedEstructuraO");
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

        private ICommand _cmdNuevoCargo_Click;
        public ICommand cmdNuevoCargo_Click
        {
            get
            {
                return _cmdNuevoCargo_Click ?? (_cmdNuevoCargo_Click = new CommandHandler(() => this.NuevoCargo(), _canExecute));
            }
        }

        private void NuevoCargo()
        {
            try
            {
                ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.EstructuraAmodificar = new estructurasorganica();
                CRUDclientesContactosEstructuraView mivista = new CRUDclientesContactosEstructuraView(mensajito);
                var res = mivista.ShowDialog();
                this.inicializarListados();
                RaisePropertyChanged("");
            }
            catch (Exception)
            {
                MessageBox.Show("Error desconocido al crear un nuevo cargo", "Error",MessageBoxButton.OK,MessageBoxImage.Stop);
            }
        }


        public void inicializarListados()
        {
            using (db = new SGPTEntidades())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                try
                {
                    ListadoEstructuraO = new List<estructurasorganica>();
                    ListadoEstructuraO = (from e in db.estructurasorganicas where e.idnitcliente == currentCliente.idnitcliente && e.estadoeo == "A" orderby e.nombrecargoeo select e).ToList();
                    RaisePropertyChanged("ListadoEstructuraO");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los datos de la estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nSi el problema continua de aviso a soporte tecnico.");
                }
            }

            RaisePropertyChanged("");
        }
        
        //private async void EjecutarMensaje() /// Esta prueba es para experimentar si se puede emitir mensajes mahajaksd
        //{
        //    var x = await dlg.ShowMessageAsync(this, "Mensaje para el viewmodel", "Prueba Eliezer", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings
        //    {
        //        AffirmativeButtonText = "Aceptar",
        //        NegativeButtonText = "CANCELAR",
        //        AnimateShow = true,
        //        AnimateHide = false
        //    });

        //}
        private void Nuevo()
        {
            this.inicializarListados();
            txtBandera = "1";
            //txtBandera = "0";
            Fechainiciofuncioncontacto = DateTime.Now;
            AccionGuardar = true;
            AccionConsultar = false;
            Message = "Nuevo contacto";
        }
        private void Editar(ClientesContactosMensajeModal Mensajito)
        {
            txtBandera = "1";
            //txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = false;
            
            //CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            Message = "Editar contacto";
            this.compartidaEditarConsultar(Mensajito);
        }
        private void compartidaEditarConsultar(ClientesContactosMensajeModal Mensajito)
        {
            this.inicializarListados();
            ContactosModelo conn = Mensajito.ContactosAmodificar;
            //estructurasorganica est = Mensajito.EstructuraAmodificar;
            try
            {
                #region -
                SelectedEstructuraO = ListadoEstructuraO.Find(x => x.idcargoeo == conn.idcargoeo);
                //SelectedEstructuraO.idcargoeo
                RaisePropertyChanged("SelectedEstructuraO");

                Idcargoeoc = conn.idcargoeo;
                Idcontacto = conn.idcontacto;
                Nombrescontacto= conn.nombrescontacto;
                Apellidoscontacto= conn.apellidoscontacto;
                //var r = db.telefonos.Where(x => x.idcontacto == conn.idcontacto && x.idtt == 5);
                //Telefono = db.telefonos.Where(x => x.idcontacto == conn.idcontacto && x.idtt==5).Select(z=> z.numerotelefono).ToString();

                using (db=new SGPTEntidades())
                {
                    var a = (from t in db.telefonos where t.idcontacto == Idcontacto select t).ToList(); 
                
                    foreach (var b in a)
                    {
                        #region -
                        if (b.idtt == 5)
                        {
                            Telefono = b.numerotelefono;
                        }
                        if (b.idtt == 2 && b.numerotelefono != Celular)
                        {
                            Celular = b.numerotelefono;
                        }
                        #endregion
                    }
                    var h = (from c in db.correos where c.idcontacto == Idcontacto select c).ToList();
                    foreach (var r in h)
                    {
                        #region +
                        Email = r.direccioncorreo;
                        #endregion
                    }
                }
                //Celular = db.telefonos.Where(x => x.idcontacto == conn.idcontacto && x.idtt == 2).Select(z => z.numerotelefono).ToString();
                //Email = db.correos.Where(y => y.idcontacto == conn.idcontacto).Select(w => w.direccioncorreo).ToString();
                Fechainiciofuncioncontacto= DateTime.Parse(conn.fechainiciofuncioncontacto);
                Observaciones= conn.observacionescontacto;
                RaisePropertyChanged();
                //Estadoeo = "A";
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al recuperar los datos de la correspondencia. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error.", "Error de compatibilidad");
            }
        }
        private void Consultar(ClientesContactosMensajeModal Mensajito)
        {
            //this.inicializarListados();
            txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            //CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            Message = "Consultar contacto";
            this.compartidaEditarConsultar(Mensajito);
        }

        private void cmdCancelar()
        {
            //MessageBox.Show("No se realizo ninguna modificacion.", "Operacion cancelada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            AvisaYCerrateVosSolo("No se realizo ninguna modificacion", "Operacion cancelada por usted", 2);
            this.FinalizarAction();
        }

        private async void activarBarra()
        {
            //DejarseVer = Visibility.Visible;
            //RaisePropertyChanged();
            //MessageBoxResult Guarde = MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            //switch (Guarde)
            //{
            //    case MessageBoxResult.Yes: this.cmdGuardar(); break;
            //    case MessageBoxResult.No: MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
            //    case MessageBoxResult.Cancel: this.cmdCancelar(); break;
            //}

            var mySettingsk = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "Si",
                                NegativeButtonText = "No",
                                FirstAuxiliaryButtonText="Cancelar",
                            };
                            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettingsk);
                            if (resultk == MessageDialogResult.Affirmative)
                            {
                                this.cmdGuardar();
                            }
                            else if (resultk == MessageDialogResult.Negative)
                            {
                                AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado", "No se guardo nada", 2);
                            }
                            else if(resultk==MessageDialogResult.FirstAuxiliary)
                            {
                                this.cmdCancelar();
                            }

        }


        private void cmdGuardar()
        {//***********************************************************************************************************
            if (ValidacionManualOk())
            {
                #region v
                //if (!llamadoDesde = "Contactos") //entonces es llamado desde expedientes
                //{
                    #region +
                    ContactosModelo cont = new ContactosModelo();
                    if (AccionGuardar)
                        cont = new ContactosModelo();
                    else if (!AccionConsultar)
                        cont = ContactoAModificar;

                    cont.idcargoeo = SelectedEstructuraO.idcargoeo;
                    cont.nombrecargo = SelectedEstructuraO.nombrecargoeo;
                    cont.nombrescontacto = Nombrescontacto;
                    cont.apellidoscontacto = Apellidoscontacto;
                    cont.nombrecompleto = Nombrescontacto + " " + Apellidoscontacto;
                    cont.fechainiciofuncioncontacto = Fechainiciofuncioncontacto.ToShortDateString();
                    cont.estadocontacto = "A";
                    cont.observacionescontacto = Observaciones;


                    correo cor = new correo();
                    cor.idcorreo = 100000;
                    cor.idcontacto = cont.idcontacto;
                    cor.direccioncorreo = Email;
                    cor.estadocorreo = "A";
                    cont.correo = cor;
                    cont.correos = Email;

                    telefono tel = new telefono(); //oficina fijo
                    tel.idtelefono = 100000;
                    tel.idcontacto = cont.idcontacto;
                    tel.idtt = 5;
                    tel.numerotelefono = Telefono;
                    tel.estadotelefono = "A";
                    cont.telefonoFijo = tel;

                    telefono cel = new telefono(); //celular de oficina
                    cel.idtelefono = 100001;
                    cel.idcontacto = cont.idcontacto;
                    cel.idtt = 2;
                    cel.numerotelefono = Celular;
                    cel.estadotelefono = "A";
                    cont.telefonoCelular = cel;

                    cont.telefonos = Telefono + ", " + Celular;
                    if (true)
                    {
                        TipoComando comm = new TipoComando();
                        if(AccionGuardar)
                            comm=TipoComando.Nuevo;
                        else if(!AccionConsultar)
                            comm=TipoComando.Editar;

                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.ContactosAmodificar = cont; mensajito.Accion=comm;
                        //Aqui tengo que usar un token para saber quien fue que invoco esta vista y responderle a el.
                        if (llamadoDesde == "Contactos") //entonces es llamado desde expedientes
                            Messenger.Default.Send<ClientesContactosMensajeModal>(mensajito,"Contactos");
                        else if (llamadoDesde == "Expedientes") 
                            Messenger.Default.Send<ClientesContactosMensajeModal>(mensajito,"Expedientes");
                        else if (llamadoDesde == "Correspondencia")
                            Messenger.Default.Send<ClientesContactosMensajeModal>(mensajito, "Correspondencia");

                        AvisaYCerrateVosSolo("Procesando y enviando...", "", 1);
                        this.FinalizarAction();
                    } 
                    #endregion
                //}
                #endregion
            }
        }

        private async void AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 30,
                DialogTitleFontSize = 30,

            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

        private bool ValidacionManualOk()
        {
            return true;
        }
    }
}