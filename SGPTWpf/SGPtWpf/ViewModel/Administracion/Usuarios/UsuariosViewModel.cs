using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Modales;
using SGPTmvvm.Model;
using SGPTmvvm.ViewModel.FilaVM;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Text;
using SGPTmvvm.Soporte;
using System.Windows.Input;
using SGPTWpf.SGPtWpf.Messages.Genericos;

namespace SGPTWpf.ViewModel.Crud.Usuario
{

    public sealed class UsuariosViewModel : ViewModeloBase
    {

        #region opcionSeleccionada
        private int _opcionSeleccionada;
        private int opcionSeleccionada
        {
            get { return _opcionSeleccionada; }
            set { _opcionSeleccionada = value; }
        }
        #endregion
        public SGPTEntidades db = new SGPTEntidades();
        MD5 md5Hash = MD5.Create();
        private static Random aleatorio = new Random();
        //private CustomDialog customDialog;
        #region Propiedades privadas

        //private static UsuariosViewModel departamentoViewModel;
        public List<role> ListaRoles { get; set; }
        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int ventanas = 0;
        private static bool activarVentanaConsulta = true;
        permisosrolesusuario permisorolusuariovalidado { get; set; }

        #endregion

        #region ViewModel Properties : tokenRecepcionAdmon

        public const string tokenRecepcionAdmonPropertyName = "tokenRecepcionAdmon";

        private string _tokenRecepcionAdmon;

        public string tokenRecepcionAdmon
        {
            get
            {
                return _tokenRecepcionAdmon;
            }

            set
            {
                if (_tokenRecepcionAdmon == value)
                {
                    return;
                }

                _tokenRecepcionAdmon = value;
                RaisePropertyChanged(tokenRecepcionAdmonPropertyName);
            }
        }

        #endregion

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



        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista
        /// <summary>
        /// The <see cref="Lista" /> property's name.
        /// </summary>
        //public const string ListaPropertyName = "Lista";

        //private ObservableCollection<UsuarioModelo> _Lista;

        //public ObservableCollection<UsuarioModelo> Lista
        //{
        //    get
        //    {
        //        return _Lista;
        //    }

        //    set
        //    {
        //        if (_Lista == value) return;

        //        _Lista = value;

        //        // Update bindings, no broadcast
        //        RaisePropertyChanged(ListaPropertyName);
        //    }
        //}
        public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }

        #endregion

        #region ViewModel Property : currentEntidad

        //public const string currentEntidadPropertyName = "UsuarioSelected";


        ////private UsuarioModelo _currentEntidad;

        ////public UsuarioModelo currentEntidad
        //private UsuariosVM _currentEntidad;

        //public UsuariosVM currentEntidad
        //{
        //    get
        //    {
        //        return _currentEntidad;
        //    }

        //    set
        //    {
        //        if (_currentEntidad == value) return;

        //        _currentEntidad = value;

        //        // Update bindings, no broadcast
        //        RaisePropertyChanged(currentEntidadPropertyName);
        //    }
        //}

        private UsuariosVM _usuarioSelected;
        public UsuariosVM UsuarioSelected
        {
            get
            {
                return _usuarioSelected;
            }
            set
            {
                _usuarioSelected = value;
                RaisePropertyChanged("UsuarioSelected");
                //this.ObtenerDatos();
                //RaisePropertyChanged("UsuariosListado");
            }
        }


        #endregion

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand PermisosCommand { get; set; }
        public RelayCommand cambiarContraseñaCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        //public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand XExcellCommand { get; set; }
        public RelayCommand XWordCommand { get; set; }
        public RelayCommand XPdfCommand { get; set; }

        //public RelayCommand<UsuarioModelo> SelectionChangedCommand { get; set; }
        public RelayCommand<UsuariosVM> SelectionChangedCommand { get; set; }

        #endregion

        #region UsuarioMainModel

        private MainModel _mainModel = null;

        public MainModel UsuarioMainModel
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

        #endregion

        #region ViewModel Public Methods

        #region Constructores

        public UsuariosViewModel()
        {
            //Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));
            //this.PermisosUsuarioValidado("Usuarios");
            //this.ObtenerDatos();
            //Lista = new ObservableCollection<UsuarioModelo>(UsuarioModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<VentanaViewMensajeFin>(this, (ventanaViewMensajeFin) => ControlVentanaViewMensajeFin(ventanaViewMensajeFin));
            UsuarioMainModel = new MainModel();

            _tokenRecepcionAdmon = "Usuarios"+"Administracion";
            Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));


            // this.PermisosUsuarioValidado("Usuarios");
            //this.ObtenerDatos();
            Mouse.OverrideCursor = Cursors.Wait;
            //PruebaInicializadoresEnSegundoPlano();
            //this.ObtenerDatos();
            RaisePropertyChanged("UsuariosListado");
            
        }



        private void ControlAdministracionUsuarioValidadoMensaje(AdministracionUsuarioValidadoMensaje administracionUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = administracionUsuarioValidadoMensaje.usuarioMensaje;
            usuarioModelo = administracionUsuarioValidadoMensaje.usuarioModelo;
            Messenger.Default.Unregister<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon);
            this.PermisosUsuarioValidado("Usuarios");
            Mouse.OverrideCursor = Cursors.Wait;
            PruebaInicializadoresEnSegundoPlano();
            inicializacionTerminada();
            Mouse.OverrideCursor = null;
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionAdmon);
        }

        #endregion

        private void PermisosUsuarioValidado(string Tabla)
        {
            #region -
            using (db = new SGPTEntidades())
            {
                try
                {
                    //extrayendo los permisos dados al usuario segun su rol
                    permisorolusuariovalidado = new permisosrolesusuario();
                    permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == Tabla select p).SingleOrDefault();
                    UsuarioPuedeCrear = permisorolusuariovalidado.crearpru;
                    UsuarioPuedeEliminar = permisorolusuariovalidado.eliminarpru;
                    UsuarioPuedeConsultar = permisorolusuariovalidado.consultarpru;
                    UsuarioPuedeEditar = permisorolusuariovalidado.editarpru;
                    UsuarioPuedeImprimir = permisorolusuariovalidado.impresionpru;
                    UsuarioPuedeExportar = permisorolusuariovalidado.exportacionpru;
                    UsuarioPuedeRevisar = permisorolusuariovalidado.revisarpru;
                    UsuarioPuedeAprobar = permisorolusuariovalidado.aprobarpru;
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los permisos del rol del usuario.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este error", "error critico.", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            #endregion
        }
        /********************************************************************/
        #region Permisos del Usuario Logueado

        private Boolean _UsuarioPuedeCrear = false;
        public Boolean UsuarioPuedeCrear
        {
            get
            {
                return _UsuarioPuedeCrear;
            }
            set
            {
                _UsuarioPuedeCrear = value;
                RaisePropertyChanged("UsuarioPuedeCrear");
            }
        }

        private Boolean _UsuarioPuedeEliminar = false;
        public Boolean UsuarioPuedeEliminar
        {
            get
            {
                return _UsuarioPuedeEliminar;
            }
            set
            {
                _UsuarioPuedeEliminar = value;
                RaisePropertyChanged("UsuarioPuedeEliminar");
            }
        }
        //
        private Boolean _UsuarioPuedeConsultar = false;
        public Boolean UsuarioPuedeConsultar
        {
            get
            {
                return _UsuarioPuedeConsultar;
            }
            set
            {
                _UsuarioPuedeConsultar = value;
                RaisePropertyChanged("UsuarioPuedeConsultar");
            }
        }

        private Boolean _UsuarioPuedeEditar = false;
        public Boolean UsuarioPuedeEditar
        {
            get
            {
                return _UsuarioPuedeEditar;
            }
            set
            {
                _UsuarioPuedeEditar = value;
                RaisePropertyChanged("UsuarioPuedeEditar");
            }
        }
        //
        private Boolean _UsuarioPuedeImprimir = false;
        public Boolean UsuarioPuedeImprimir
        {
            get
            {
                return _UsuarioPuedeImprimir;
            }
            set
            {
                _UsuarioPuedeImprimir = value;
                RaisePropertyChanged("UsuarioPuedeImprimir");
            }
        }
        //
        private Boolean _UsuarioPuedeExportar = false;
        public Boolean UsuarioPuedeExportar
        {
            get
            {
                return _UsuarioPuedeExportar;
            }
            set
            {
                _UsuarioPuedeExportar = value;
                RaisePropertyChanged("UsuarioPuedeExportar");
            }
        }
        //
        private Boolean _UsuarioPuedeRevisar = false;
        public Boolean UsuarioPuedeRevisar
        {
            get
            {
                return _UsuarioPuedeRevisar;
            }
            set
            {
                _UsuarioPuedeRevisar = value;
                RaisePropertyChanged("UsuarioPuedeRevisar");
            }
        }

        private Boolean _UsuarioPuedeAprobar = false;
        public Boolean UsuarioPuedeAprobar
        {
            get
            {
                return _UsuarioPuedeAprobar;
            }
            set
            {
                _UsuarioPuedeAprobar = value;
                RaisePropertyChanged("UsuarioPuedeAprobar");
            }
        }
        #endregion

        #region Envio mensajes
        public void enviarMensaje()
        {
            //Se crea el mensaje
            VentanaViewMensaje apertura = new VentanaViewMensaje();
            apertura.mensaje = ventanas;//Guardo el mensaje
            Messenger.Default.Send<VentanaViewMensaje>(apertura);
            ventanas = ventanas + 1;
            enviarMensajeInhabilitar();
        }
        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            if ((ventanas == 0))
            {
                inhabilitar.mensaje = true;
            }
            else
            {
                inhabilitar.mensaje = false;
            }
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void enviarElemento()
        {
            //Se crea el mensaje
            UsuarioElementoMensaje elemento = new UsuarioElementoMensaje();
            if ((ventanas == 0))
            {
                //elemento.elementoMensaje = UsuarioSelected;
            }
            else
            {
                elemento.elementoMensaje = null;
            }
            Messenger.Default.Send<UsuarioElementoMensaje>(elemento);
        }
        public void enviarLista()
        {
            //Se crea el mensaje
            UsuarioListaMensaje listaEnviada = new UsuarioListaMensaje();
            if ((ventanas == 0))
            {
                //listaEnviada.listaMensaje = Lista;
            }
            else
            {
                listaEnviada.listaMensaje = null;
            }
            Messenger.Default.Send<UsuarioListaMensaje>(listaEnviada);
        }
        #endregion

        #region Receptor de mensajes
        private void ControlVentanaViewMensajeFin(VentanaViewMensajeFin controlVentanaCrearMensaje)
        {
            //Para controlar la ventana abierta
            ventanas = ventanas + controlVentanaCrearMensaje.mensaje;
            if (ventanas < 0)
            { ventanas = 0; }//Para mantener el valor en cero y no en menos
            enviarMensajeInhabilitar();
            //TypeName = null;
            UsuarioMainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    UsuarioSelected = null;
                    break;
                case 2:
                    break;
                case 3:
                    activarVentanaConsulta = true;
                    break;
                default:
                    break;
            }
            comando = 0;
            //Aqui hay que actualizar la lista
            //this.ObtenerDatos();
            PruebaInicializadoresEnSegundoPlano();
            RaisePropertyChanged("UsuariosListado");
        }
        #endregion

        #region Implementacion de comandos
        public async void Nuevo()
        {
            if (UsuarioPuedeCrear)
            {
                if (ventanas == 0)
                {
                    UsuarioMainModel.TypeName = "UsuarioCrearView";

                    UsuariosMensajeModal mensajito = new UsuariosMensajeModal();
                    mensajito.Accion = TipoComando.Nuevo;
                    mensajito.usuarioAModificar = new UsuariosVM();
                    Messenger.Default.Send(mensajito);
                    
                    //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
                    //var res = mivista.ShowDialog();

                    comando = 1;
                    enviarMensaje();
                    //this.ObtenerDatos();
                    //RaisePropertyChanged("UsuariosListado");
                    //RaisePropertyChanged("");
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                }
            }
            else
            {
                //await dlg.ShowMessageAsync(this, "No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad");
                await AvisaYCerrateVosSolo("Atencion, No tiene suficientes permisos para utilizar esta opcion","Consulte con el administrador acerca de esta restriccion de seguridad", 3);
                
                //this.ObtenerDatos();
                PruebaInicializadoresEnSegundoPlano();
            }
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
            //this.ObtenerDatos();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0, String.Format("Proceso Interaccion 1."));
            //this.ObtenerDatos();
            //Mouse.OverrideCursor = Cursors.Wait;

            this.ObtenerDatos();
            //Mouse.OverrideCursor = null;
            worker.ReportProgress(100, "Proceso Finalizado con éxito.");
        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        #endregion

        public void ObtenerDatos()
        {
           // Mouse.OverrideCursor = Cursors.Wait;
            #region +
            /*La tabla usuario esta relacionada con una referencia circular, con Persona, con Firma, 
             con Pistas, y con los roles*/

            ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();

            try
            {
                List<usuariospersonas> usuariosy = new List<usuariospersonas>();
                using (db = new SGPTEntidades())
                {
                    if (currentUsuario.idrol == 7 || currentUsuario.idrol == 8) // si es socio o si es administrador
                    {
                        #region +
                        usuariosy = (from u in db.usuarios
                                     join p in db.personas
                                     on u.idduipersona equals p.idduipersona
                                     orderby p.nombrespersona
                                     where p.estadopersona == "A"
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
                                         nombreCompleto = p.nombrespersona + " " + p.apellidospersona,
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
                    else
                    {
                        #region +
                        usuariosy = (from u in db.usuarios
                                     join p in db.personas
                                     on u.idduipersona equals p.idduipersona
                                     orderby p.nombrespersona
                                     where u.idusuario == currentUsuario.idusuario && p.estadopersona == "A"
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
                                         nombreCompleto = p.nombrespersona + " " + p.apellidospersona,
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
                }
                //from t in db.telefonos on p.idduipersona equals t.idduipersona 
                int i = 1;
                ListaRoles = new List<role>();
                using (db = new SGPTEntidades())
                {
                    ListaRoles = db.roles.ToList();
                }
                foreach (usuariospersonas usua in usuariosy)
                {
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            if (usua.idrol > 0)
                            {
                                string nombreRolz = ListaRoles.Find(x => x.idrol == usua.idrol).nombrerol;
                                //string nombreRolz = (from r in db.roles where r.idrol.Equals(usua.idrol) select r.nombrerol).FirstOrDefault();
                                usua.nombrerol = nombreRolz;
                            }
                            if (usua.usuidusuario > 0)
                            {
                                persona zyx = new persona();
                                zyx = db.personas.Join(db.usuarios, p => p.idduipersona, u => u.idduipersona, (p, u) => new { personas = p, usuarios = u }).Where(uu => uu.usuarios.idusuario == usua.usuidusuario).Select(uu => uu.personas).SingleOrDefault();
                                String nombreJefez = zyx.nombrespersona + ", " + zyx.apellidospersona;
                                usua.nombreusuidusuario = nombreJefez;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("No se pudo recuperar el nombre del rol, ni el nombre del jefe "+e.InnerException);
                        }
                    }
                    usua.correlativo = i;
                    i++;
                    _usuarios.Add(new UsuariosVM { IsNew = false, TheUsuariosPersonas = usua });
                }
                UsuariosListado = new ObservableCollection<UsuariosVM>();
                UsuariosListado = _usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado"); 
            #endregion
            //Mouse.OverrideCursor = null;
        }

        public async void Editar()
        {
            if (UsuarioPuedeEditar)
            {
                if (!(UsuarioSelected == null))
                {
                    if (ventanas == 0)
                    {
                        #region +
                        comando = 2;

                        if (UsuarioSelected.TheUsuariosPersonas.estadopersona == "A")
                        {

                            UsuarioMainModel.TypeName = "UsuarioEditarView";
                            UsuariosMensajeModal mensajito = new UsuariosMensajeModal();
                            mensajito.Accion = TipoComando.Editar;
                            mensajito.usuarioAModificar = (UsuariosVM)UsuarioSelected;
                            Messenger.Default.Send(mensajito);

                            //UsuariosMensajeModal mensajito = new UsuariosMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.usuarioAModificar = (UsuariosVM)UsuarioSelected;
                            //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
                            //var res = mivista.ShowDialog();

                            //this.ObtenerDatos();
                            //RaisePropertyChanged("UsuariosListado");
                            //RaisePropertyChanged("");
                            enviarMensaje();
                        #endregion
                        }
                        else { 
                            //MessageBox.Show("No se puede editar un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); 
                            await AvisaYCerrateVosSolo("No se puede editar un usuario eliminado. Consulte al administrador para activarlo.","El usuario se encuentra eliminado",2);
                        }
                    }
                }
                else
                {
                    //await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                    await AvisaYCerrateVosSolo("No ha seleccionado ningun registro","Seleccione un registro para continuar", 1);
                    
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad",1);
            }
        }
        public async void Consultar()
        {
            if (UsuarioPuedeConsultar)
            {
                if (!(UsuarioSelected == null))
                {
                    if (activarVentanaConsulta)
                    {
                        #region +
                        if (ventanas == 0)
                        {
                            //UsuarioMainModel.TypeName = "UsuarioConsultarView";
                            //enviarElemento();
                            //enviarMensaje();
                            comando = 3;
                            activarVentanaConsulta = false;
                            if (UsuarioSelected.TheUsuariosPersonas.estadopersona == "A")
                            {

                                #region +
                                UsuarioMainModel.TypeName = "UsuarioConsultarView";
                                UsuariosMensajeModal mensajito = new UsuariosMensajeModal();
                                mensajito.Accion = TipoComando.Consultar;
                                mensajito.usuarioAModificar = (UsuariosVM)UsuarioSelected;
                                Messenger.Default.Send(mensajito);


                                //UsuariosMensajeModal mensajito = new UsuariosMensajeModal();
                                //mensajito.Accion = TipoComando.Consultar;
                                //mensajito.usuarioAModificar = (UsuariosVM)UsuarioSelected;
                                //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
                                //var res = mivista.ShowDialog();
                                //MostrarModalDialog(mensajito);

                                //this.ObtenerDatos();
                                //RaisePropertyChanged("UsuariosListado");
                                //RaisePropertyChanged("");
                                activarVentanaConsulta = true;
                                enviarMensaje();
                                #endregion
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("No se puede editar un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado",3);
                            }
                        }
                        else
                        {
                            //await dlg.ShowMessageAsync(this, "Ya tiene una ventana abierta no puede crear otra ", "");
                        }
                        #endregion
                    }
                    else
                    {
                        //La ventana de consulta esta activa
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("Debe seleccionar el registro a consultar", "",1);
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad",3);
            }
        }
        public async void Permisos()
        {
            if (ventanas == 0)
            {
                if (UsuarioSelected.TheUsuariosPersonas.estadopersona == "A")
                {
                    PermisosRolesMensajeModal mensajito = new PermisosRolesMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.currentUsuario = currentUsuario; mensajito.rolesAmodificar = (UsuariosVM)UsuarioSelected;
                    //Messenger.Default.Send<RolesMensajeModal>(mensajito);
                    CRUDpermisosRolesView mivista = new CRUDpermisosRolesView(mensajito);
                    var res = mivista.ShowDialog();
                    //this.ObtenerDatos();
                    PruebaInicializadoresEnSegundoPlano();
                    RaisePropertyChanged("UsuariosListado");
                    RaisePropertyChanged("");
                }
                else {await AvisaYCerrateVosSolo("No se puede editar permisos de un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado",3); }
            }
        }


        public void ConsultarDobleClick()
        {
            this.Consultar();
        }
        public async void Borrar()
        {
            if (UsuarioPuedeEliminar)
            {
                if (!(UsuarioSelected == null))
                {
                    if (ventanas == 0)
                    {
                        if (UsuarioSelected.TheUsuariosPersonas.estadopersona == "A")
                        {
                            #region
                            var mySettingsk = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "Acepto",
                                NegativeButtonText = "Cancelar",
                                
                            };

                            //MessageDialogResult resultf = await dlg.ShowMessageAsync(this, "Esta a punto de cambiar las credenciales al usuario."+Environment.NewLine+"Esta accion no se puede deshacer.", "¿Desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                            //if (resultf == MessageDialogResult.Affirmative)
                            //{

                            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro "+Environment.NewLine+ UsuarioSelected.TheUsuariosPersonas.nombrespersona + ", " + UsuarioSelected.TheUsuariosPersonas.apellidospersona +Environment.NewLine+ " se eliminara logicamente.","Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                            if (resultk == MessageDialogResult.Affirmative)
                            {
                                #region
                                try
                                {
                                    using (db = new SGPTEntidades())
                                    {
                                        persona elimpers = db.personas.Find(UsuarioSelected.TheUsuariosPersonas.idduipersona);
                                        elimpers.estadopersona = "B";
                                        db.Entry(elimpers).State = EntityState.Modified;
                                        usuario elimusu = db.usuarios.Find(UsuarioSelected.TheUsuariosPersonas.idusuario);
                                        elimusu.estadousuario = "B";
                                        elimusu.fechadebaja = DateTime.Now.ToShortDateString();
                                        db.Entry(elimusu).State = EntityState.Modified;
                                        db.SaveChanges();
                                        //this.ObtenerDatos();
                                        PruebaInicializadoresEnSegundoPlano();
                                        RaisePropertyChanged("UsuariosListado");
                                    }

                                    await AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.","Finalizado", 2);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Imposible eliminar al usuario seleccionado. Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                #endregion
                            }
                            else
                            {
                                //MessageBox.Show("Eliminacion abortada. No se realizo ninguna accion", "Cancelado....", MessageBoxButton.OK, MessageBoxImage.Information);
                                await AvisaYCerrateVosSolo("Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario.",1);

                            }
                            #endregion
                        }
                        else 
                        { 
                            await AvisaYCerrateVosSolo("El usuario seleccionado esta inactivo o eliminado!!.", "Usuario inexistente o eliminado",1); 
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("No ha seleccionado ningun usuario para eliminar.", "Seleccione un usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    await AvisaYCerrateVosSolo("No ha seleccionado ningun usuario para eliminar", "Seleccione un usuario para continuar",1);
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad",1);
               // this.ObtenerDatos();
                PruebaInicializadoresEnSegundoPlano();
                RaisePropertyChanged("UsuariosListado");
                RaisePropertyChanged("");
            }
        }


        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content=contenido,
                DialogMessageFontSize=12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos*1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }


        private async void CambiarContraseña()
        {
            if (HayInterSioNo())
	        {
		        #region +
		            if (UsuarioSelected!=null)
                    {
                        var mySettingsx = new LoginDialogSettings
                        {
                            InitialUsername = UsuarioSelected.TheUsuariosPersonas.nickusuariousuario,
                            AffirmativeButtonText = "Ingresar",
                            NegativeButtonText = "Cancelar,"
                        };
                        LoginDialogData result = await dlg.ShowLoginAsync(this, "Hola: " + currentUsuario.nickusuariousuario + " !" + Environment.NewLine + " Has decidido cambiar las credenciales a " + UsuarioSelected.TheUsuariosPersonas.nickusuariousuario + " .:::. " + UsuarioSelected.TheUsuariosPersonas.nombreCompleto, "Por seguridad, es necesario que introduzca sus credenciales nuevamente.",mySettingsx);
                        //LoginDialogData result = await this.ShowLoginAsync(this, "Hola: " + currentUsuario.nickusuariousuario + " !", "Cuales son sus credenciales actuales ?", new LoginDialogSettings { ColorScheme = this.MetroDialogOptions.ColorScheme, InitialUsername = "MahApps" });
                        if (result == null) //usuario preisiono cancelar
                            return;
                        else
                        {
                            string contrasEncriptada=GetMd5Hash(md5Hash, result.Password);
                            //verificar porque llega nulo usuario selected
                            if (UsuarioSelected.TheUsuariosPersonas.nickusuariousuario==result.Username && UsuarioSelected.TheUsuariosPersonas.contraseniausuario==contrasEncriptada) //si el que esta cambiando las credenciales es el mismo usuario
                            {

                                var mySettingsy = new LoginDialogSettings
                                {
                                    InitialUsername = UsuarioSelected.TheUsuariosPersonas.nickusuariousuario,
                                    AffirmativeButtonText = "Enviar y guardar",
                                    NegativeButtonText="Cancelar,"
                                };
                                LoginDialogData result2 = await dlg.ShowLoginAsync(this, "Hola: " + currentUsuario.nickusuariousuario + " !" + Environment.NewLine + "Ingrese las nuevas credenciales a usar", "Nota:" + Environment.NewLine + "La longitud del Nick es entre [5 a 12] caracteres." + Environment.NewLine + "La longitud de la contraseña es entre [8 a 12] caracteres" + Environment.NewLine, mySettingsy);
                                if (result2 !=null)
                                {
                                    #region +
		                            if (!string.IsNullOrEmpty(result2.Username) && !string.IsNullOrEmpty(result2.Password)) // Si no esta vacio el Nick.. aunque lo puede estar. No, mejor que introduzca todo, mas seguro.
                                    {
                                        #region +
                                        if ((result2.Username.Length < 5 && result2.Password.Length > 12) || (result2.Password.Length < 8 && result2.Password.Length > 12)) //esta mal el nick o el password
                                        {
                                            //await dlg.ShowMessageAsync(this, "Se hallaron incongruencias en La longitud de los datos ingresados." + Environment.NewLine + "Las credenciales no estan dentro de los parametros validos", "Nick/Contraseña invalido.");
                                            await AvisaYCerrateVosSolo("Se han encontrado incongruencias en los datos","",1);
                                            return;
                                        }
                                        else //estan buenos los dos. Entonces a guardar y a notificar por correo.
                                        {
                                            if (await comprobarNoEsDuplicadoNck(result2.Username))
                                            {
                                                string NuevacontrasEncriptada = GetMd5Hash(md5Hash, result2.Password);
                                                using (db = new SGPTEntidades())
                                                {
                                                    #region +
                                                    try
                                                    {
                                                        usuario usuarioAnotificar = (from hu in db.usuarios where hu.idusuario == currentUsuario.idusuario select hu).SingleOrDefault();

                                                        string ni = result2.Username;
                                                        string contra = result2.Password;
                                                        usuarioAnotificar.nickusuariousuario = ni;
                                                        usuarioAnotificar.contraseniausuario = NuevacontrasEncriptada;
                                                        db.Entry(usuarioAnotificar).State = EntityState.Modified;
                                                        db.SaveChanges();
                                                        await AvisaYCerrateVosSolo("La clave se ha guardado correctamente.", "El usuario sera notificado por correo electronico", 2);

                                                        await this.notificarAlUsuario(UsuarioSelected.TheUsuariosPersonas.idduipersona, ni, contra);
                                                    }
                                                    catch (Exception e)
                                                    {

                                                        MessageBox.Show("Error al consultar la base de datos. " + e.InnerException);
                                                    }
                                                    #endregion
                                                } 
                                            }
                                        } 
                                        #endregion
                                    }
                                    else 
                                    {
                                        await AvisaYCerrateVosSolo("Atencion, es necesario que introduzca su NickName y su Contraseña","No se realizo ninguna accion.", 2);
                                    } 
	                                #endregion
                                }
                                else{return;}
                            }
                            else //Quiere decir que quien esta cambiando las contraseñas no es el dueño de la cuenta, sino un posible administrador/socio
                            {
                                #region +
                                //UsuariosVM usuarr=(from v in UsuariosListado where v.TheUsuariosPersonas.nickusuariousuario==result.Username && v.TheUsuariosPersonas.contraseniausuario==contrasEncriptada select v).SingleOrDefault();
                                usuario usuarr = new usuario();
                                string usua = result.Username;
                                string contras = GetMd5Hash(md5Hash, result.Password);//result.Password;
                                using (db = new SGPTEntidades())
                                {
                                    usuarr = (from v in db.usuarios where v.nickusuariousuario == usua && v.contraseniausuario == contras select v).SingleOrDefault();
                                }
                                if (usuarr != null) //si las credenciales que metio son de un usuario real
                                {
                                    #region +
                                    if (usuarr.idrol == 7 || usuarr.idrol == 8) //si es administrador o si es Socio
                                    {
                                        var mySettings = new MetroDialogSettings()
                                        {
                                            AffirmativeButtonText = "Acepto",
                                            NegativeButtonText = "Cancelar"
                                        };

                                        MessageDialogResult resultf = await dlg.ShowMessageAsync(this, "Esta a punto de cambiar las credenciales al usuario." + Environment.NewLine + "Esta accion no se puede deshacer.", "¿Desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                                        if (resultf == MessageDialogResult.Affirmative)
                                        {
                                            #region +
                                            string ni = result.Username;
                                            string contra = result.Password;

                                            MessageDialogResult resultx = await dlg.ShowMessageAsync(this, "Atencion" + Environment.NewLine + "Por seguridad las credenciales seran generadas de forma generica y enviadas al correo del usuario modificado.", "¿Desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                                            if (resultx == MessageDialogResult.Affirmative)
                                            {
                                                using (db = new SGPTEntidades())
                                                {
                                                    #region +
                                                    try
                                                    {
                                                        usuario usuarx = (from v in db.usuarios where v.nickusuariousuario == UsuarioSelected.TheUsuariosPersonas.nickusuariousuario && v.contraseniausuario == UsuarioSelected.TheUsuariosPersonas.contraseniausuario select v).SingleOrDefault();

                                                        string Nick = UsuarioSelected.TheUsuariosPersonas.nombrespersona.Substring(0, 3) + UsuarioSelected.TheUsuariosPersonas.apellidospersona.Substring(0, 3) + generarNumero(3);
                                                        var Nickusuariousuario = Nick;
                                                        string Con = generarCodigoUser();
                                                        string Contraseniausuario = GetMd5Hash(md5Hash, Con);

                                                        usuarx.nickusuariousuario = Nick;
                                                        usuarx.contraseniausuario = Contraseniausuario;
                                                        db.Entry(usuarx).State = EntityState.Modified;
                                                        db.SaveChanges();
                                                        //await dlg.ShowMessageAsync(this, "La clave se ha guardado correctamente." + Environment.NewLine + "El usuario sera notificado por correo electronico", "");
                                                        await AvisaYCerrateVosSolo("La clave se ha guardado correctamente.", "El usuario sera notificado por correo electronico", 2);
                                                        await this.notificarAlUsuario(UsuarioSelected.TheUsuariosPersonas.idduipersona, Nickusuariousuario, Con);
                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        MessageBox.Show("Error " + ex.InnerException);
                                                    }
                                                    #endregion
                                                }
                                            }
                                            #endregion
                                        }
                                        else { return; }

                                    }
                                    else
                                    {
                                        //await dlg.ShowMessageAsync(this, "No posee suficientes permisos para realizar esta accion", "");
                                        await AvisaYCerrateVosSolo("No posee suficientes permisos para realizar esta accion", "Consulte al administrador acerca de esta restriccion.", 1);
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region +

                                    //CustomDialog dialog = (BaseMetroDialog)Resources["CustomDialogTest"];
                                    //await dlg.ShowMessageAsync(this, "No posee suficientes permisos para realizar esta accion", "");
                                    await AvisaYCerrateVosSolo("No posee suficientes permisos para realizar esta accion", "Consulte al administrador acerca de esta restriccion.", 1);
                                    //await dlg.HideMetroDialogAsync(dialog); 
                                    #endregion
                                } 
                                #endregion
                            }
                        } 
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("Seleccione el usuario que desea modificar la contraseña!","",1);
                    } 
	        #endregion 
	        }
            else
            {
                await AvisaYCerrateVosSolo("Es necesario tener acceso a internet para realizar esta accion","Verifique que tiene acceso a internet.",1);
            }
            this.PruebaInicializadoresEnSegundoPlano();
                
        }


        private async Task<bool> comprobarNoEsDuplicadoNck(string nck)
        {
            //if (!AccionGuardar && Nickusuariousuario != null)
            //{
                try
                {
                    Random rnd = new Random();
                    //UsuariosListado
                    var regenc = (from u in UsuariosListado where u.TheUsuariosPersonas.nickusuariousuario.Trim() == nck.Trim() select u).SingleOrDefault() ;//UsuariosListado.Find(x => x.nickusuariousuario.Trim() == nck.Trim());
                    //bool enc = ListadoDeUsuarios.Exists(x => x.nickusuariousuario.Trim() == Nickusuariousuario.Trim());
                    if (regenc != null && regenc.TheUsuariosPersonas.idduipersona != currentUsuario.idduipersona && regenc.TheUsuariosPersonas.inicialesusuario != currentUsuario.inicialesusuario)
                    {
                        await AvisaYCerrateVosSolo("El NICK no esta disponible!... ", "Intentelo nuevamente", 2);
                        return false;
                        //string nex = rnd.Next(20, 9999).ToString();
                        //Nickusuariousuario = Nickusuariousuario + nex;
                    }
                    else return true;
                }
                catch (Exception)
                {
                    return false;
                }
            //}
        }
        //private string generarNumero(int p)
        //{
        //    throw new NotImplementedException();
        //}
        
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

        private bool consultarCredenciales(string Nyk, string pxa)
        {
            List<usuariospersonas> uusu = new List<usuariospersonas>();
            
            foreach (var a in UsuariosListado)
            {
                uusu.Add(a.TheUsuariosPersonas);
            }
            string contraencryh = GetMd5Hash(md5Hash, pxa);
            bool usuarioencontrado = uusu.Exists(x => x.nickusuariousuario == Nyk && x.contraseniausuario==contraencryh);

            return usuarioencontrado;
        }


        private bool HayInterSioNo()
        {
            #region +
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                if (host.AddressList!=null)
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
            #endregion
        }

        private async Task<bool> notificarAlUsuario(string Idduipersonay, string userUsuario, string PassUsuario)
        {
            await AvisaYCerrateVosSolo("Verificando los correos de la firma...", "", 1);
            Mouse.OverrideCursor = Cursors.Wait;
            //Mouse.OverrideCursor = null;
            firma ListadoFirmas = new firma();
            List<correo> ListadoCorreos = new List<correo>();
            List<correo> ListadoCorreosFirma = new List<correo>();
            using (db = new SGPTEntidades())
            {
                ListadoFirmas = db.firmas.First();
                if(ListadoFirmas!=null)
                    ListadoCorreosFirma = (ListadoFirmas.correos).ToList();
                ListadoCorreos = UsuarioSelected.TheUsuariosPersonas.correos.ToList(); //(from c in db.correos where c.idduipersona == p.idduipersona && c.estadocorreo == "A" orderby c.idcorreo select c).ToList(),
            }

            if (ListadoFirmas != null && ListadoCorreosFirma.Count>0)
            {
                #region +
                //var ListadoCorreosFirma = (ListadoFirmas.correos).ToList();
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
                        #region _
                        foreach (var a in ListadoCorreos)
                        {
                            #region +
                            string correoDirigidoA = a.direccioncorreo;
                            string titulo = "Notificacion de cambios en su nick y clave de acceso al SGPT";
                            string cuerpo = "\n \t\t*** Notificacion de cuenta de usuario. ***. \n\nLos datos fueron cambiados este dia: " + DateTime.Now.ToShortDateString() + " \n\nRecuerde que puede cambiar estos valores en cualquier momento que lo necesite.\n\n\t\t  Usuario: => \t" + userUsuario + "\n\t\t  Contraseña: => \t " + PassUsuario;
                            //string cuerpo = "\n\t Notificacion de creacion de usuario y clave de acceso al SGPT.\n\t\t*** Notificacion de creacion de cuenta de usuario. ***. \n\nLos datos fueron creados aleatoriamente el dia " + DateTime.Now.ToString() + " por un administrador. \n\nRecuerde que debe cambiar estos valores al primer ingreso, o cuando lo desee.\n\n\t\t  Usuario: => \t" + userUsuario + "\t\t  Contraseña: => \t " + PassUsuario;

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
                        #endregion
                    }
                    else
                    {
                        //MessageBox.Show("No existe ningun correo donde pueda ser notificado el usuario."); 
                        await AvisaYCerrateVosSolo("Atencion, No existe ningun correo donde pueda ser notificado el usuario.", "Introduzca un correo valido del usuario y vuelva a intentarlo", 2);
                        Mouse.OverrideCursor = null;
                        return false;
                    } 
                    #endregion
                }
                else
                { //MessageBox.Show("La firma no posee un correo verificado apto para emitir correos.", "La firma no posee un correo valido", MessageBoxButton.OK, MessageBoxImage.Stop);
                    Mouse.OverrideCursor = null;
                    await AvisaYCerrateVosSolo("La firma no posee un correo verificado apto para emitir correos.", "Ingrese un correo valido del usuario y vuelva a intenterlo",4);
                    return false;
                }
                #endregion
            }
            else
            {
                Mouse.OverrideCursor = null;
                await AvisaYCerrateVosSolo("Atencion, no existe ninguna firma registrada", "Imposible continuar",4);
                
                return false;
            }
        }

        #region _
        public static string ircnEseD(byte[] _cAdd)
        {
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

        }
        #endregion
        //public async Task<string> ShowCustomDialog(string message, string title)
        //{
        //    var metroDialogSettings = new MetroDialogSettings()
        //    {
        //        AffirmativeButtonText = "OK",
        //        NegativeButtonText = "CANCEL",
        //        AnimateHide = true,
        //        AnimateShow = true,
        //        ColorScheme = MetroDialogColorScheme.Accented,
        //    };

        //    LoginDialogSettings settings = null;
        //    settings=settings ?? dlg.metr .MetroDialogOptions;

        //    //create the dialog control
        //    var dialog = new InputDialog(window, settings)
        //    {
        //        Title = title,
        //        Message = message,
        //        Input = settings.DefaultText,
        //    };

        //    return await InvokeOnCurrentDispatcher(async () =>
        //    {
        //        await dlg.ShowMetroDialogAsync(dialog, metroDialogSettings);

        //        await dialog.WaitForButtonPressAsync().ContinueWith((m) =>
        //        {
        //            InvokeOnCurrentDispatcher(() =>  dialog.HideMetroDialogAsync(dialog));
        //        });

        //        return dialog.Input;
        //    });
        //}

        #endregion

        public bool CanSave()
        {
            return !string.IsNullOrEmpty((UsuarioSelected.TheUsuariosPersonas.idduipersona));

        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<UsuarioModelo> listaEntidad)
        {
            //Lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return UsuarioSelected != null;
        }
        public bool CanActivar()
        {
            return false;
        }

        #endregion
        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanDelete);
            BorrarCommand = new RelayCommand(Borrar, CanDelete);
            ConsultarCommand = new RelayCommand(Consultar, CanDelete);
            //public RelayCommand PermisosCommand { get; set; }
            PermisosCommand = new RelayCommand(Permisos, CanDelete);
            cambiarContraseñaCommand = new RelayCommand(CambiarContraseña, CanDelete);

            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            XExcellCommand = new RelayCommand(ExportarExcel, CanActivar);
            XWordCommand = new RelayCommand(ExportarWord, CanActivar);
            XPdfCommand = new RelayCommand(ExportarPdf, CanActivar);
            //SelectionChangedCommand = new RelayCommand<UsuarioModelo>(entidad =>
            SelectionChangedCommand = new RelayCommand<UsuariosVM>(entidad =>
            {
                if (entidad == null) return;
                UsuarioSelected = entidad;
            });
        }

        

        private void ExportarPdf()
        {
            
        }

        private void ExportarWord()
        {

        }

        private void ExportarExcel()
        {
           
        }

        #endregion

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
  
}


