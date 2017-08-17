using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Roles;
using SGPTWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Modales;
using System.Data.Entity;
using SGPTWpf.Messages.Administracion.Usuario;
using System.Threading.Tasks;
using SGPTWpf.SGPtmvvm.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Administracion
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public sealed  class RolesViewModel : ViewModeloBase
    {
        permisosrolesusuario permisorolusuariovalidado { get; set; }


        #region Propiedades privadas

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
        public SGPTEntidades db = new SGPTEntidades();
        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int ventanas = 0;
        private static bool activarVentanaConsulta = true;

        #endregion



        #region Permisos del Usuario
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
        public const string ListaPropertyName = "Lista";

        private ObservableCollection<RolModelo> _Lista;

        public ObservableCollection<RolModelo> Lista
        {
            get
            {
                return _Lista;
            }

            set
            {
                if (_Lista == value) return;

                _Lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPropertyName);
            }
        }

        public List<role> RolesListado { get; set; }
        public List<RolesModelo> RolesListado2 { get; set; }
        //RolesModelo
        public List<opcionesrole> OpcionesRolesListado { get; set; }

        #endregion

        #region Nombre de rol

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

        #region Descripcion de rol

        public const string descripcionRolPropertyName = "descripcionRol";

        private string _descripcionRol = string.Empty;

        public string descripcionRol
        {
            get
            {
                return _descripcionRol;
            }

            set
            {
                if (_descripcionRol == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(descripcionRolPropertyName);
            }
        }

        #endregion

        #region  Primary key

        /// <summary>
        /// The <see cref="id" /> property's name.
        /// </summary>
        public const string idPropertyName = "id";

        private int _id = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idrol
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

        #region Sistema

        /// <summary>
        /// The <see cref="sistema" /> property's name.
        /// </summary>

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        /// <summary>
        /// Sets and gets the sistemamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool sistema
        {
            get
            {
                return _sistema;
            }

            set
            {
                if (_sistema == value)
                {
                    return;
                }

                _sistema = value;
                RaisePropertyChanged(sistemaPropertyName);
            }
        }

        #endregion

        #region Estado
        /// <summary>
        /// The <see cref="estado" /> property's name.
        /// </summary>
        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        /// <summary>
        /// Sets and gets the estadomc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(estadoPropertyName);
            }
        }
        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        /// <summary>
        /// The <see cref="currentEntidad" /> property's name.
        /// </summary>
        //public const string currentEntidadPropertyName = "currentEntidad";

        //private RolModelo _currentEntidad;

        //public RolModelo currentEntidad
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
        private role _selectedRol;
        public role SelectedRol
        {
            get { return _selectedRol; }
            set { _selectedRol = value; RaisePropertyChanged("SelectedRol"); }
        }

        private RolesModelo _selectedRol2;
        public RolesModelo SelectedRol2
        {
            get { return _selectedRol2; }
            set { _selectedRol2 = value; RaisePropertyChanged("SelectedRol2"); }
        }

        #endregion

        #endregion


        #endregion

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand PermisosCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand XExcellCommand { get; set; }
        public RelayCommand XWordCommand { get; set; }
        public RelayCommand XPdfCommand { get; set; }

        public RelayCommand<RolModelo> SelectionChangedCommand { get; set; }

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

        #region MainModel

        private MainModel _mainModel = null;

        public MainModel MainModel
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

        #region ViewModel Public Methods

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the catalogosViewModel class.

        public RolesViewModel()
        {
            Lista = new ObservableCollection<RolModelo>(RolModelo.GetAll());
            this.ObtenerDatos();
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<VentanaViewMensaje>(this, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            MainModel = new MainModel();
            //Nuevo();
            _tokenRecepcionAdmon = "Roles" + "Administracion";
            Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));

        }

        private void ControlAdministracionUsuarioValidadoMensaje(AdministracionUsuarioValidadoMensaje administracionUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = administracionUsuarioValidadoMensaje.usuarioMensaje;
            usuarioModelo = administracionUsuarioValidadoMensaje.usuarioModelo;
            Messenger.Default.Unregister<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon);
            this.PermisosUsuarioValidado("Roles");
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
            RolElementoMensaje elemento = new RolElementoMensaje();
            if ((ventanas == 0))
            {
                //elemento.elementoMensaje = currentEntidad;
            }
            else
            {
                //elemento.elementoMensaje = null;
            }
            Messenger.Default.Send<RolElementoMensaje>(elemento);
        }
        public void enviarLista()
        {
            //Se crea el mensaje
            RolListaMensaje listaEnviada = new RolListaMensaje();
            if ((ventanas == 0))
            {
                listaEnviada.listaMensaje = Lista;
            }
            else
            {
                listaEnviada.listaMensaje = null;
            }
            Messenger.Default.Send<RolListaMensaje>(listaEnviada);
        }
        #endregion

        #region Receptor de mensajes
        private void ControlVentanaMensaje(VentanaViewMensaje controlVentanaCrearMensaje)
        {
            //Para controlar la ventana abierta
            ventanas = ventanas + controlVentanaCrearMensaje.mensaje;
            if (ventanas < 0)
            { ventanas = 0; }//Para mantener el valor en cero y no en menos
            enviarMensajeInhabilitar();
            //TypeName = null;
            MainModel.TypeName = null;
            switch (comando)
            {
                case 1:
                    SelectedRol = null;
                    SelectedRol2 = null;
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

        }
        #endregion

        #region Implementacion de comandos
        private void ObtenerDatos()
        {
            /*La tabla usuario esta relacionada con una referencia circular, con Persona, con Firma, 
             con Pistas, y con los roles*/

            //ThrobberVisible = Visibility.Visible;

            //ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();

            try
            {
                using (SGPTEntidades db = new SGPTEntidades())
                {
                    RolesListado = (from r in db.roles where r.sistemarol == false && r.estadorol == "A" orderby r.nombrerol select r).ToList();
                    RaisePropertyChanged("RolesListado");
                    RolesListado2 = new List<RolesModelo>();
                    int i = 1;
                    foreach (var a in RolesListado)
                    {
                        RolesModelo r = new RolesModelo();
                        r.correlativo = i; i++;
                        r.idrol = a.idrol;
                        r.nombrerol = a.nombrerol;
                        r.sistemarol = a.sistemarol;
                        r.descripcionrol = a.descripcionrol;
                        r.basadoenrol = a.basadoenrol;
                        RolesListado2.Add(r);
                    }
                    RaisePropertyChanged("RolesListado2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            //ThrobberVisible = Visibility.Collapsed;
        }
        public async void Nuevo()
        {
            if (UsuarioPuedeCrear)
            {
                if (ventanas == 0)
                {

                    //MainModel.TypeName = "RolCrearView";
                    //currentEntidad = new RolModelo();
                    RolesMensajeModal mensajito = new RolesMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.rolAmodificar = new role();
                    CRUDRolesView mivista = new CRUDRolesView(mensajito);
                    var res = mivista.ShowDialog();
                    this.ObtenerDatos();
                    RaisePropertyChanged("RolesListado2");
                    RaisePropertyChanged("");
                    //enviarElemento();
                    //enviarLista();
                    //enviarMensaje();
                    //comando = 1;

                }
                else
                {
                    await AvisaYCerrateVosSolo("Ya tiene una ventana abierta no puede crear otra ", "",1);
                } 
            }
            else
            {
                await AvisaYCerrateVosSolo("No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad",1);
            }
        }

        public async void Editar()
        {
            if (UsuarioPuedeEditar)
            {
                if (!(SelectedRol2 == null))
                {
                    if (ventanas == 0)
                    {
                        //MainModel.TypeName = "RolEditarView";
                        //enviarElemento();//Debe ir antes, porque evalua si la ventana es cero para enviarse
                        //enviarLista();
                        //enviarMensaje();
                        //comando = 2;
                        SelectedRol = RolesListado.Find(x => x.idrol == SelectedRol2.idrol);
                        RolesMensajeModal mensajito = new RolesMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.rolAmodificar = (role)SelectedRol;
                        CRUDRolesView mivista = new CRUDRolesView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("RolesListado");
                    }

                }
                else
                {
                    await AvisaYCerrateVosSolo("Debe seleccionar el registro a editar", "",1);
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
                if (!(SelectedRol2 == null))
                {
                    if (activarVentanaConsulta)
                    {
                        if (ventanas == 0)
                        {
                            #region +
                            //MainModel.TypeName = "RolConsultarView";
                            //enviarElemento();
                            //enviarMensaje();
                            //comando = 3;
                            //activarVentanaConsulta = false;
                            //UsuariosMensajeModal mensajito = new UsuariosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.usuarioAModificar = (UsuariosVM)selectedChangedx;
                            SelectedRol = RolesListado.Find(x => x.idrol == SelectedRol2.idrol);
                            RolesMensajeModal mensajito = new RolesMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.rolAmodificar = (role)SelectedRol;
                            CRUDRolesView mivista = new CRUDRolesView(mensajito);
                            var res = mivista.ShowDialog();
                            this.ObtenerDatos();
                            RaisePropertyChanged("UsuariosListado");
                            
                            #endregion
                        }
                    }
                    else
                    {
                        //La ventana de consulta esta activa
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("No ha seleccionado ningun rol para modificarlo.", "Seleccione un rol para continuar...",1);
                } 
            }
            else
            {
                await AvisaYCerrateVosSolo("No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad",1);
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
                if (!(SelectedRol2 == null))
                {
                    if (ventanas == 0)
                    {
                        var mySettingsk = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Acepto",
                            NegativeButtonText = "No",
                        };
                        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro " + SelectedRol2.nombrerol + ", " + SelectedRol2.descripcionrol + " se eliminara logicamente."+Environment.NewLine+"Seguro que desea continuar?", "Advertencia... " + DateTime.Now.ToString("d"), MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                        if (resultk == MessageDialogResult.Affirmative)
                        {
                            #region
                            try
                            {
                                using (SGPTEntidades db = new SGPTEntidades())
                                {
                                    role elimrol = db.roles.Find(SelectedRol2.idrol);
                                    if (!elimrol.sistemarol)
                                    {
                                        elimrol.estadorol = "B";
                                        db.Entry(elimrol).State = EntityState.Modified;
                                        db.SaveChanges();
                                        this.ObtenerDatos();
                                        RaisePropertyChanged("RolesListado");
                                    }
                                    else
                                    {
                                        await AvisaYCerrateVosSolo("Imposible eliminar el rol.", "El rol es un proceso del sistema creado predeterminadamente.",2);
                                    }
                                }

                                //MessageBox.Show("El registro se elimino correctamente de manera logica.");
                                await AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.", "Proceso completado.",2);
                            }
                            catch (Exception e)
                            {
                                //await AvisaYCerrateVosSolo("Imposible eliminar el rol seleccionado. Consulte a soporte tecnico acerca de este error.", "Abortado por el sistema",2);
                                MessageBox.Show("Imposible eliminar el rol seleccionado. Consulte a soporte tecnico acerca de este error. "+e.InnerException, "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            #endregion
                        }
                        else

                            //MessageBox.Show("Eliminacion abortada. No se realizo ninguna accion", "Cancelado....", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...",2);
                    }
                }
                else
                {
                    //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                    await AvisaYCerrateVosSolo("Debe seleccionar el registro a eliminar", "",1);
                } 
            }
            else
            {
                await AvisaYCerrateVosSolo("No tiene suficientes permisos para utilizar esta opcion ", "Consulte con el administrador acerca de esta restriccion de seguridad",1);
            }
        }

        #endregion

        public bool CanSave()
        {
            return !(SelectedRol2.idrol == 0); //&&
            //       !string.IsNullOrEmpty(currentEntidad.descripcion);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<RolModelo> listaEntidad)
        {
            Lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return SelectedRol2 != null;
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
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            PermisosCommand = new RelayCommand(ExportarExcel, CanActivar); //CanActivar lo deja inhabilitado de un solo
            XExcellCommand = new RelayCommand(ExportarExcel, CanActivar);
            XWordCommand = new RelayCommand(ExportarWord, CanActivar);
            XPdfCommand = new RelayCommand(ExportarPdf, CanActivar);
            //SelectionChangedCommand = new RelayCommand<RolModelo>(entidad =>
            //{
            //    if (entidad == null) return;
            //    currentEntidad = entidad;
            //});
        }

        #endregion

        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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
}
