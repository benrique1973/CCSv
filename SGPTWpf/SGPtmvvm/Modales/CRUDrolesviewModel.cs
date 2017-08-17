using CapaDatos;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Data;

namespace SGPTmvvm.Modales
{
    public class CRUDRolesviewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the CRUDrolesviewModel class.
        /// </summary>
        public SGPTEntidades db = new SGPTEntidades();
        public List<role> ListadoRolesSistema { get; set; } //listado de los roles predeterminados en los cuales se basaran los nuevos creados.
        public List<opcionesrole> permisosRolesRol { get; set; }
        public ICollectionView permisitosRolesRolView { get; set; }
        //public List<permisosrolesusuario> PermisosRolesUsuarios { get; set; }

        List<permisosrolesusuario> permisosActuales = new List<permisosrolesusuario>(); //permisos actuales de la base antes de la modificacion.
        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar;
        private bool AccionRestablecerRol;
        private DialogCoordinator dlg;
        public CRUDRolesviewModel(RolesMensajeModal msg)
        {
            AccionRestablecerRol = false;
            AccionConsultar = false;
            AccionGuardar = true;
            _canExecute = true;
            this.EscuchandoALaVista(msg);
            dlg = new DialogCoordinator();
        }

        //public CRUDRolesviewModel(DialogCoordinator dlgIn)
        //{
        //    //dlg = dlgIn;
        //    //_canExecute = true;
        //    //this.EscuchandoALaVista(msg);
        //}

        #region v
        private role _currentRole;
        public role currentRole
        {
            get { return _currentRole; }
            set
            {
                _currentRole = value;
                RaisePropertyChanged("currentRole");
            }
        }
        private role _SelectedRolSistema;
        public role SelectedRolSistema
        {
            get { return _SelectedRolSistema; }
            set
            {
                _SelectedRolSistema = value;
                RaisePropertyChanged("SelectedRolSistema");
                this.ExtraerPermisosDelRolSistema();
            }
        }

        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }

        private void ExtraerPermisosDelRolSistema()
        {
            if (AccionGuardar)
            {
                #region +
                using (db = new SGPTEntidades())
                {
                    try
                    {
                        var xOpciones = (from p in db.opcionesroles where p.idrol == SelectedRolSistema.idrol && p.mostrarenmenuor == true orderby p.nombreopcionor select p).ToList();

                        //int i = 1;
                        //foreach (opcionesrole p in xOpciones)
                        //{
                        //    p.idrol = null;
                        //    p.idor = i; i++;
                        //}
                        //permisosRolesRol = new List<opcionesrole>();
                        //permisosRolesRol = xOpciones;

                        IList<opcionesrole> permisitos = xOpciones;
                        permisitosRolesRolView = CollectionViewSource.GetDefaultView(permisitos);
                        permisitosRolesRolView.GroupDescriptions.Clear();
                        permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("menuor"));
                        permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("submenuor"));
                        permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("subsubmenuor"));
                        //RaisePropertyChanged("permisitosRolesRolView");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Problema al recuperar el listado de opciones roles. \nLa base de datos tardo demasiado en responder. "+e.InnerException, "Error. El tiempo de espera excedio.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }

                RaisePropertyChanged("permisitosRolesRolView");
                #endregion 
            }
        }
        
        #endregion
        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(RolesMensajeModal Mensajito)
        {
            //BarraProgresoVisible = Visibility.Collapsed;
            //RaisePropertyChanged("BarraProgresoVisible");
            //role rolx = Mensajito.rolAmodificar;
            //IdRol = rolx.idrol;
            switch (Mensajito.Accion)
            {
                case TipoComando.Nuevo: NuevoRol(); break;
                case TipoComando.Editar: EditarRol(Mensajito); break;
                case TipoComando.Consultar: ConsultarRol(Mensajito); break;
                default: break;
            }
        }

        #region Campos
        private int _idRol;
        private string _NombreRol;
        private string _DescripcionRol;
        private int _BasadoEnRol;

        public int IdRol { get { return _idRol; } set { _idRol = value; RaisePropertyChanged("IdRol"); } }
        public string NombreRol { get { return _NombreRol; } set { _NombreRol = value; RaisePropertyChanged("NombreRol"); } }
        public string DescripcionRol { get { return _DescripcionRol; } set { _DescripcionRol = value; RaisePropertyChanged("DescripcionRol"); } }
        public int Basadoenrol { get { return _BasadoEnRol; } set { _BasadoEnRol = value; RaisePropertyChanged("Basadoenrol"); } }
        #endregion

        #region Habilitadores
        private Boolean _HabilitarBotonCancelar;
        public Boolean HabilitarBotonCancelar
        {
            get
            {
                return _HabilitarBotonCancelar;
            }
            set
            {
                _HabilitarBotonCancelar = value;
                RaisePropertyChanged("HabilitarBotonCancelar");
            }
        }
        private bool _HabilitarCmdRestablecer;
        public bool HabilitarCmdRestablecer
        {
            get { return _HabilitarCmdRestablecer; }
            set
            {
                _HabilitarCmdRestablecer = value;
                RaisePropertyChanged("HabilitarCmdRestablecer");
            }
        }

        private Boolean _HabilitartxtNombreRol;
        public Boolean HabilitartxtNombreRol
        {
            get
            {
                return _HabilitartxtNombreRol;
            }
            set
            {
                _HabilitartxtNombreRol = value;
                RaisePropertyChanged("HabilitartxtNombreRol");
            }
        }

        private Boolean _HabilitartxtDescripcionRol;
        public Boolean HabilitartxtDescripcionRol
        {
            get
            {
                return _HabilitartxtDescripcionRol;
            }
            set
            {
                _HabilitartxtDescripcionRol = value;
                RaisePropertyChanged("HabilitartxtDescripcionRol");
            }
        }

        private bool _HabilitarcmbRolesSistema;
        public bool HabilitarcmbRolesSistema
        {
            get { return _HabilitarcmbRolesSistema; }
            set
            {
                _HabilitarcmbRolesSistema = value;
                RaisePropertyChanged("HabilitarcmbRolesSistema");
            }
        }
        //HabilitarGridRoles
        private Boolean _HabilitarGridRoles;
        public Boolean HabilitarGridRoles
        {
            get
            {
                return _HabilitarGridRoles;
            }
            set
            {
                _HabilitarGridRoles = value;
                RaisePropertyChanged("HabilitarGridRoles");
            }
        }

        private Boolean _HabilitarPuedeCrear;
        public Boolean HabilitarPuedeCrear{ 
            get
            {
                return _HabilitarPuedeCrear;
            }
            set
            {
                _HabilitarPuedeCrear = value;
                RaisePropertyChanged("HabilitarPuedeCrear");
            }
        }

        private Boolean _HabilitarPuedeEliminar;
        public Boolean HabilitarPuedeEliminar
        {
            get
            {
                return _HabilitarPuedeEliminar;
            }
            set
            {
                _HabilitarPuedeEliminar = value;
                RaisePropertyChanged("HabilitarPuedeEliminar");
            }
        }
        //
        private Boolean _HabilitarPuedeConsultar;
        public Boolean HabilitarPuedeConsultar
        {
            get
            {
                return _HabilitarPuedeConsultar;
            }
            set
            {
                _HabilitarPuedeConsultar = value;
                RaisePropertyChanged("HabilitarPuedeConsultar");
            }
        }

        private Boolean _HabilitarPuedeEditar;
        public Boolean HabilitarPuedeEditar
        {
            get
            {
                return _HabilitarPuedeEditar;
            }
            set
            {
                _HabilitarPuedeEditar = value;
                RaisePropertyChanged("HabilitarPuedeEditar");
            }
        }
        //
        private Boolean _HabilitarPuedeImprimir;
        public Boolean HabilitarPuedeImprimir
        {
            get
            {
                return _HabilitarPuedeImprimir;
            }
            set
            {
                _HabilitarPuedeImprimir = value;
                RaisePropertyChanged("HabilitarPuedeImprimir");
            }
        }
        //
        private Boolean _HabilitarPuedeExportar;
        public Boolean HabilitarPuedeExportar
        {
            get
            {
                return _HabilitarPuedeExportar;
            }
            set
            {
                _HabilitarPuedeExportar = value;
                RaisePropertyChanged("HabilitarPuedeExportar");
            }
        }
        //
        private Boolean _HabilitarPuedeRevisar;
        public Boolean HabilitarPuedeRevisar
        {
            get
            {
                return _HabilitarPuedeRevisar;
            }
            set
            {
                _HabilitarPuedeRevisar = value;
                RaisePropertyChanged("HabilitarPuedeRevisar");
            }
        }

        private Boolean _HabilitarPuedeAprobar;
        public Boolean HabilitarPuedeAprobar
        {
            get
            {
                return _HabilitarPuedeAprobar;
            }
            set
            {
                _HabilitarPuedeAprobar = value;
                RaisePropertyChanged("HabilitarPuedeAprobar");
            }
        }
        #endregion

        #region ControlHabilitadores
        public void Habilitadores(bool estado)
        {
            HabilitartxtNombreRol=estado;
            HabilitartxtDescripcionRol=estado;
            //HabilitarGridRoles
            HabilitarGridRoles=estado;
            HabilitarPuedeCrear=estado;
            HabilitarPuedeEliminar=estado;
            HabilitarPuedeConsultar=estado;
            HabilitarPuedeEditar=estado;
            HabilitarPuedeImprimir=estado;
            HabilitarPuedeExportar=estado;
            HabilitarPuedeRevisar=estado;
            HabilitarPuedeAprobar=estado;
        }
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

        #region pruebaParaBarraProgreso
        /*******************************************************Inicio Barra Progreso*********************************/
        //private ICommand _Acepte;
        //public ICommand Acepte
        //{
        //    get
        //    {
        //        return _Acepte ?? (_Acepte = new CommandHandler(() => cmdAcepte(), _canExecute));
        //    }
        //}

        //private void cmdAcepte()
        //{
        //    DejarseVer = Visibility.Visible;
        //    RaisePropertyChanged();
        //    //RaisePropertyChanged("ThrobberVisible");
        //    //ThrobberVisible = Visibility.Visible;
        //    //RaisePropertyChanged("ThrobberVisible");
        //}



        //private ICommand _NoAcepte;
        //public ICommand NoAcepte
        //{
        //    get
        //    {
        //        return _NoAcepte ?? (_NoAcepte = new CommandHandler(() => cmdNoAcepte(), _canExecute));
        //    }
        //}

        //private void cmdNoAcepte()
        //{
        //    DejarseVer = Visibility.Collapsed;
        //    RaisePropertyChanged();
        //    //RaisePropertyChanged("ThrobberVisible");
        //    ////ThrobberVisible = Visibility.Hidden;
        //    //RaisePropertyChanged("ThrobberVisible");
        //}

        //DejarseVer

        private Visibility _DejarseVer;
        public Visibility DejarseVer
        {
            get { return _DejarseVer; }
            set
            {
                _DejarseVer = value;
                RaisePropertyChanged();
            }
        }

        private int _ValorDejarseVer; //valor de la barra progreso. normalmente entre [0 y 100]
        public int ValorDejarseVer
        {
            get { return _ValorDejarseVer; }
            set
            {
                _ValorDejarseVer = value;
                RaisePropertyChanged();
            }
        }

        private string _valorProgresoTextBox; //Leyenda del avance en porcentaje o el proceso que se ejecuta
        public string valorProgresoTextBox
        {
            get { return _valorProgresoTextBox; }
            set { _valorProgresoTextBox = value; RaisePropertyChanged(); }
        }
        /**************************************Fin Manejar Barra Progreso*****************************************************/
        #endregion

        private ICommand _cmdCancelar_Click;
        public ICommand cmdCancelar_Click
        {
            get
            {
                return _cmdCancelar_Click ?? (_cmdCancelar_Click = new CommandHandler(() => cmdCancelar(), _canExecute));
            }
        }
        private ICommand _cmdRestablecer_Click;
        public ICommand cmdRestablecer_Click
        {
            get
            {
                return _cmdRestablecer_Click ?? (_cmdRestablecer_Click = new CommandHandler(() => cmdRestablecer(), _canExecute));
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
        private void NuevoRol()
        {
            Message = "Crear rol";
            AccionGuardar = true;
            AccionConsultar = false;
            HabilitarcmbRolesSistema = true;
            HabilitarBotonCancelar = true;
            HabilitarCmdRestablecer = false;
            HabilitartxtNombreRol = true;
            RaisePropertyChanged("HabilitartxtNombreRol");
            HabilitartxtDescripcionRol = true;
            RaisePropertyChanged("HabilitartxtDescripcionRol");
            HabilitarGridRoles = true;
            RaisePropertyChanged("HabilitarGridRoles");
            //Lo que se pretende es crear un listado de roles predeterminados, de entre los cuales se creara cualquier rol
            ListadoRolesSistema = new List<role>();

            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoRolesSistema = (from r in db.roles where r.sistemarol == true orderby r.nombrerol select r).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Problema al recuperar el listado de roles. La base tardo demasiado en responder. "+e.InnerException,"Error en el tiempo de espera",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                }
            }

            //permisosRolesRol = new List<opcionesrole>(); // lo inicializo para que quede listo en tomar cualquier valor
            //List<opcionesrole> xOpciones = new List<opcionesrole>();
            
            
            //role rolz = new role();

            //using(db=new SGPTEntidades())
            //{
		        
            //    //permisosRolesRol=
            //        rolz = (from r in db.roles select r).First();
            //        int numrol=rolz.idrol+1;
            //        xOpciones = (from p in db.opcionesroles where p.idrol == numrol orderby p.nombreopcionor select p).ToList();
            //}
            //int i = 1;
            //    foreach (opcionesrole p in xOpciones)
            //    {
            //        p.idrol = null;
            //        p.idor = i; i++;
            //        p.crearor = true;
            //        p.eliminaror = true;
            //        p.consultaror = true;
            //        p.editaror = true;
            //        p.impresionor = true;
            //        p.exportacionor = true;
            //        p.revisaror = true;
            //        p.aprobaror = true;
            //    }
            //    permisosRolesRol = xOpciones;

            //    RaisePropertyChanged("permisosRolesRol");
            //RaisePropertyChanged();
        }

        private void EditarRol(RolesMensajeModal Mensajito)
        {
            Message = "Editar rol";
            //Aqui tengo que destapar el mensajito, y extraer el idrol. Luego tengo que hacer una consulta a la tabla opciones roles para extraer los permisos de el.
            HabilitarcmbRolesSistema = false;
            HabilitarBotonCancelar = true;
            HabilitarCmdRestablecer = true;

            this.Habilitadores(true); //Habilitamos los controles de la vista para poder hacer efectivo los cambios
            AccionGuardar = false;
            AccionConsultar = false;
            this.compartidaEditarConsultar(Mensajito);
            
        }
        private void compartidaEditarConsultar(RolesMensajeModal Mensajito)
        {
            currentRole = Mensajito.rolAmodificar;
            IdRol = currentRole.idrol;

            NombreRol = currentRole.nombrerol;
            RaisePropertyChanged("NombreRol");

            DescripcionRol = currentRole.descripcionrol;
            RaisePropertyChanged("DescripcionRol");

            Basadoenrol = (int)currentRole.basadoenrol;

            


            
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoRolesSistema = new List<role>();
                    ListadoRolesSistema = (from r in db.roles where r.sistemarol == true orderby r.nombrerol select r).ToList();
                    RaisePropertyChanged("ListadoRolesSistema");

                    role tr = new role(); tr= db.roles.Find(Basadoenrol);
                    SelectedRolSistema = tr;
                    RaisePropertyChanged("SelectedRolSistema");
                    //permisosRolesRol = (from p in db.opcionesroles where p.idrol == rolx.idrol orderby p.nombreopcionor select p).ToList();

                    //RaisePropertyChanged("permisosRolesRol");
                    var xOpciones = (from p in db.opcionesroles where p.idrol == currentRole.idrol && p.mostrarenmenuor == true select p).ToList();

                    IList<opcionesrole> permisitos = xOpciones;
                    permisitosRolesRolView = CollectionViewSource.GetDefaultView(permisitos);
                    permisitosRolesRolView.GroupDescriptions.Clear();
                    permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("menuor"));
                    permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("submenuor"));
                    permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("subsubmenuor"));
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los permisos del rol. \nLa base de datos tardo demasiado en responder. "+e.InnerException, "Error de tiempo de espera", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            RaisePropertyChanged("permisitosRolesRolView");
        }

        private void ConsultarRol(RolesMensajeModal Mensajito)
        {
            Message = "Consultar rol";
            HabilitarcmbRolesSistema = false;
            HabilitarBotonCancelar = true;
            HabilitarCmdRestablecer = false;
            this.Habilitadores(false); //Deshabilitamos los controles de la vista para que no se pueda guardar nada.
            AccionGuardar = false;
            AccionConsultar = true;

            this.compartidaEditarConsultar(Mensajito);

            //role rolx = Mensajito.rolAmodificar;
            //NombreRol = rolx.nombrerol;
            //RaisePropertyChanged("NombreRol");

            //DescripcionRol = rolx.descripcionrol;
            //RaisePropertyChanged("DescripcionRol");
            //using (db = new SGPTEntidades())
            //{
            //    permisosRolesRol = (from p in db.opcionesroles where p.idrol == rolx.idrol orderby p.nombreopcionor select p).ToList();

            //    RaisePropertyChanged("permisosRolesRol");
            //}
        }

        private async void cmdRestablecer()
        {
            using (db=new SGPTEntidades())
            {
                var rodl = db.roles.Find(Basadoenrol);
                await AvisaYCerrateVosSolo("ADVERTENCIA. Los cambios en el rol afectaran los permisos a TODOS los usuario que posean este rol", "Sera restablecido a la configuracion del rol: " + rodl.nombrerol,2); 
            }
            //MessageBoxResult Guarde = MessageBox.Show("Esta seguro que desea restablecer el rol a su estado original?", "Restablecimiento de rol", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            //switch (Guarde)
            //{
            //    case MessageBoxResult.Yes: aceptoRestablecer();  this.cmdGuardar(); break;
            //    case MessageBoxResult.No: await dlg.ShowMessageAsync(this, "Operacion guardar ha sido cancelado por usted", "No se guardo nada"); break;//MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
            //    case MessageBoxResult.Cancel: this.cmdCancelar(); break;
            //}

            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Si, Restablecer",
                NegativeButtonText = "No",
                FirstAuxiliaryButtonText = "Cancelar",
            };
            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Esta seguro que desea restablecer el rol a su estado original?", "Restablecimiento de rol", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettingsk);
            if (resultk == MessageDialogResult.Affirmative)
            {
                this.aceptoRestablecer();
            }
            else if (resultk == MessageDialogResult.Negative)
            {
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 1);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }
        }
        private void aceptoRestablecer()
        {
            AccionRestablecerRol = true;
            using (db = new SGPTEntidades())
            {
                try
                {
                    var xOpciones = (from p in db.opcionesroles where p.idrol == Basadoenrol  && p.mostrarenmenuor == true select p).ToList();
                    foreach (var f in xOpciones)
                    {
                        f.idrol = currentRole.idrol;
                    }

                    IList<opcionesrole> permisitoss = xOpciones;
                    permisitosRolesRolView = CollectionViewSource.GetDefaultView(permisitoss);
                    permisitosRolesRolView.GroupDescriptions.Clear();
                    permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("menuor"));
                    permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("submenuor"));
                    permisitosRolesRolView.GroupDescriptions.Add(new PropertyGroupDescription("subsubmenuor"));

                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los permisos del rol. \nLa base de datos tardo demasiado en responder. "+e.InnerException, "Error de tiempo de espera", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            RaisePropertyChanged("permisitosRolesRolView");
        }

        private async void cmdCancelar()
        {
            //MessageBox.Show("No se realizo ninguna modificacion.","Operacion cancelada",MessageBoxButton.OK, MessageBoxImage.Exclamation);
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion", "Operacion cancelada por el usuario",1);
            this.FinalizarAction();
        }

        private async void activarBarra()
        {
            DejarseVer = Visibility.Visible;
            //RaisePropertyChanged();
            //MessageBoxResult Guarde=MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            //switch (Guarde)
            //{
            //    case MessageBoxResult.Yes: this.cmdGuardar(); break;
            //    case MessageBoxResult.No: dlg.ShowMessageAsync(this,"Operacion guardar ha sido cancelado por usted","No se guardo nada"); break;//MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
            //    case MessageBoxResult.Cancel: this.cmdCancelar(); break;
            //}

            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Acepto",
                NegativeButtonText = "No",
                FirstAuxiliaryButtonText = "Cancelar",
            };
            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettingsk);
            if (resultk == MessageDialogResult.Affirmative)
            {
                this.cmdGuardar();
            }
            else if (resultk == MessageDialogResult.Negative)
            {
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 1);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }
            /*OJO No borrar, puede servir para cuando se necesite proceso en segundo plano*/

            //BackgroundWorker worker = new BackgroundWorker();
            //worker.RunWorkerCompleted += worker_procesoFinalizado;
            //worker.WorkerReportsProgress = true;
            //worker.DoWork += worker_DoWork;
            //worker.ProgressChanged += worker_ProgressChanged;
            //worker.RunWorkerAsync(); 
        }

        #region Prueba de sub-Proceso en segundo plano 
        //private void worker_procesoFinalizado(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //MessageBox.Show("Finalizado");
        //    ValorDejarseVer = 100;
        //    RaisePropertyChanged();
        //    valorProgresoTextBox = "Espere...";
        //    RaisePropertyChanged();
        //}

        //private void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var worker = sender as BackgroundWorker;
        //    worker.ReportProgress(0, String.Format("Proceso Interaccion 1."));
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(105);
        //        worker.ReportProgress((i + 1) * 1, String.Format(" {0} ", i + 2));
        //    }
        //    worker.ReportProgress(100, "Proceso Finalizado con éxito.");
        //}

        //private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    RaisePropertyChanged();
        //    ValorDejarseVer = e.ProgressPercentage;
        //    RaisePropertyChanged();
        //    //valorProgresoTextBox = (string)e.UserState;
        //    //RaisePropertyChanged();
        //} 
        #endregion


        private async void cmdGuardar()
        {//***********************************************************************************************************
            if (await validacionManualOk())
            {
                int cambiosEncabezados = 0;
                HabilitarBotonCancelar = false;
                HabilitarCmdRestablecer = false;
                HabilitartxtNombreRol = false;
                role roly = new role();

                roly.nombrerol = NombreRol;

                roly.descripcionrol = DescripcionRol;
                if (AccionGuardar)
                {
                    #region v
                    roly.idrol = 10000;
                    roly.estadorol = "A";
                    roly.sistemarol = false;
                    roly.basadoenrol = SelectedRolSistema.idrol;
                    int idPostInsercion = 0;
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            #region +
                            HabilitartxtNombreRol = false;
                            valorProgresoTextBox = String.Format("Guardando... Paciencia...El proceso puede demorarse lo necesario.");
                            RaisePropertyChanged("valorProgresoTextBox");
                            db.roles.Add(roly);
                            db.SaveChanges();
                            idPostInsercion = roly.idrol;
                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            //*******Activamos la bandera de cerrar la vista modal*********/
                            valorProgresoTextBox = String.Format("Proceso 1 de 2. finalizado éxitosamente.");
                            RaisePropertyChanged("valorProgresoTextBox");
                            #endregion
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar el nuevo rol. Informe a soporte tecnico de este problema. " + e.InnerException, "Imposible guardar el rol", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }

                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            #region +
                            valorProgresoTextBox = String.Format("Proceso 2 de 2. Iniciando almacenamiento de opcionesrol...");
                            RaisePropertyChanged();
                            int i = 0;
                            var vpw = permisitosRolesRolView.Cast<opcionesrole>().ToList();
                            foreach (opcionesrole op in vpw)
                            {
                                await cuenteUno();
                                op.idrol = idPostInsercion;
                                db.opcionesroles.Add(op);
                                db.SaveChanges();

                                i++;
                                ValorDejarseVer = i;
                                RaisePropertyChanged();
                                valorProgresoTextBox = String.Format("Almacenando: {0}  registro {1}", op.nombreopcionor, i);
                                RaisePropertyChanged();
                            }
                            ValorDejarseVer = 100;
                            RaisePropertyChanged();
                            valorProgresoTextBox = String.Format("Finalizado...  Registros actualizados: {0}", i);
                            RaisePropertyChanged();
                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("El registro se guardo con éxito!", "Finalizado.",1);
                            HabilitarBotonCancelar = true;
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al guardar los permisos del rol. Informe a soporte tecnico de este problema. " + ex.InnerException, "Imposible guardar el rol", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    } FinalizarAction();

                    #endregion
                }
                else if (!AccionConsultar) //entonces es editar
                {
                    #region v
                    List<usuario> ListadoUsuariosConRolEditado = new List<usuario>();
                    bool hayUsuariosConEseRol = false;
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            /*Aqui debo crear un listado de los usuarios que tengan el rol X que se esta modificando*/
                            ListadoUsuariosConRolEditado = (from u in db.usuarios where u.idrol == IdRol select u).ToList();
                            if (ListadoUsuariosConRolEditado != null)
                                hayUsuariosConEseRol = true;
                            //*********


                            role rolyy = (from r in db.roles where r.idrol == IdRol select r).SingleOrDefault();
                            rolyy.nombrerol = NombreRol;
                            rolyy.descripcionrol = DescripcionRol;
                            if (!rolyy.sistemarol)
                            {
                                db.Entry(rolyy).State = EntityState.Modified; db.SaveChanges(); cambiosEncabezados = 1;
                            }
                            else
                            {
                                //MessageBox.Show("No se permite cambiar el nombre al rol.\n El rol es un proceso del sistema predeterminado", "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Warning);
                                await AvisaYCerrateVosSolo("No se permite cambiar el nombre al rol.\n El rol es un proceso del sistema predeterminado", "No fue posible guardar",2);
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar los cambios. \nLa base de datos no pudo procesar los cambios. "+e.InnerException, "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }

                    opcionesrole ppp = new opcionesrole();
                    int i = 0;

                    var vpw = permisitosRolesRolView.Cast<opcionesrole>().ToList();
                    foreach (var r in vpw)
                    {
                        await this.cuenteUno();
                        #region +
                        i++;
                        ValorDejarseVer = i;
                        RaisePropertyChanged();
                        valorProgresoTextBox = String.Format("Comparando: {0}  registro {1}", r.nombreopcionor, i);
                        RaisePropertyChanged();

                        ppp = r;
                        //permisosrolesusuario a = await DameUnRegistro(ppp);
                        opcionesrole a = new opcionesrole();
                        if (!AccionRestablecerRol)
                        {
                            #region +
                            a = await DameUnRegistro(ppp);
                            if (ppp.crearor != a.crearor || ppp.eliminaror != a.eliminaror || ppp.consultaror != a.consultaror
                                || ppp.editaror != a.editaror || ppp.impresionor != a.impresionor || ppp.exportacionor != a.exportacionor
                                || ppp.revisaror != a.revisaror || ppp.aprobaror != a.aprobaror)
                            {
                                a.crearor = ppp.crearor;
                                a.editaror = ppp.editaror;
                                a.revisaror = ppp.revisaror;
                                a.eliminaror = ppp.eliminaror;
                                a.impresionor = ppp.impresionor;
                                a.aprobaror = ppp.aprobaror;
                                a.consultaror = ppp.consultaror;
                                a.exportacionor = ppp.exportacionor;
                                using (db = new SGPTEntidades())
                                {
                                    #region +
                                    try
                                    {
                                        db.Entry(a).State = EntityState.Modified; db.SaveChanges();
                                        if (hayUsuariosConEseRol)
                                        {
                                            foreach (var k in ListadoUsuariosConRolEditado)
                                            {
                                                var z = (from v in db.permisosrolesusuarios where v.idusuario == k.idusuario && v.idrol == k.idrol && v.nombreopcionpru == a.nombreopcionor select v).SingleOrDefault();
                                                z.crearpru = ppp.crearor;
                                                z.editarpru = ppp.editaror;
                                                z.revisarpru = ppp.revisaror;
                                                z.eliminarpru = ppp.eliminaror;
                                                z.impresionpru = ppp.impresionor;
                                                z.aprobarpru = ppp.aprobaror;
                                                z.consultarpru = ppp.consultaror;
                                                z.exportacionpru = ppp.exportacionor;
                                                db.Entry(z).State = EntityState.Modified; db.SaveChanges();
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Se produjo un error al guardar el rol: " + NombreRol + ".\nLa base de datos tardo demasiado en responder. Informe a Soporte tecnico para este error.  " + ex.InnerException, "Tiempo de espera excedido.", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        this.FinalizarAction();
                                    }
                                    #endregion
                                }
                                CantidadRegistrosActualizados += 1;
                            }  
                            #endregion 
                        }
                        else //Es restablecer rol a su estado original (la plantilla de la que fue sacado)
                        {
                            a = await DameUnRegistro(ppp);

                            a.crearor = r.crearor;
                            a.editaror = r.editaror;
                            a.revisaror = r.revisaror;
                            a.eliminaror = r.eliminaror;
                            a.impresionor = r.impresionor;
                            a.aprobaror = r.aprobaror;
                            a.consultaror = r.consultaror;
                            a.exportacionor = r.exportacionor;
                            using (db = new SGPTEntidades())
                            {
                                #region +
                                    try
                                    {

                                        db.Entry(a).State = EntityState.Modified; db.SaveChanges();
                                        if (hayUsuariosConEseRol)
                                        {
                                            foreach (var k in ListadoUsuariosConRolEditado)
                                            #region +
                                            {
                                                permisosrolesusuario z = new permisosrolesusuario();
                                                z = (from v in db.permisosrolesusuarios where v.idusuario == k.idusuario && v.idrol == k.idrol && v.nombreopcionpru==a.nombreopcionor select v).SingleOrDefault();
                                                z.crearpru = ppp.crearor;
                                                z.editarpru = ppp.editaror;
                                                z.revisarpru = ppp.revisaror;
                                                z.eliminarpru = ppp.eliminaror;
                                                z.impresionpru = ppp.impresionor;
                                                z.aprobarpru = ppp.aprobaror;
                                                z.consultarpru = ppp.consultaror;
                                                z.exportacionpru = ppp.exportacionor;
                                                db.Entry(z).State = EntityState.Modified; db.SaveChanges();
                                                await this.cuenteUno();
                                                valorProgresoTextBox = String.Format("Actualizando el permiso al usuario: "+k.inicialesusuario);
                                                RaisePropertyChanged("valorProgresoTextBox");
                                                //MessageBox.Show("registro: " + CantidadRegistrosActualizados+1);
                                            #endregion
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Se produjo un error al guardar el rol: " + NombreRol + ".\nLa base de datos tardo demasiado en responder. Informe a Soporte tecnico para este error.  " + ex.InnerException, "Tiempo de espera excedido.", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        this.FinalizarAction();
                                    }
                                    #endregion
                            } //Fin Using
                            CantidadRegistrosActualizados += 1;
                        }//Fin si no es establecer rol
                        #endregion
                    } //Fin del Foreach

                    if (CantidadRegistrosActualizados > 0)
                    {
                        #region +
                        if (cambiosEncabezados == 1)
                        {
                            CantidadRegistrosActualizados++;
                            cambiosEncabezados = 0;
                        }

                        ValorDejarseVer = 100;
                        RaisePropertyChanged();
                        valorProgresoTextBox = String.Format("Finalizado...  Registros actualizados: {0}", CantidadRegistrosActualizados);
                        RaisePropertyChanged();
                        //MessageBox.Show(CantidadRegistrosActualizados + " Registros fueron actualizaron", "Modificacion con éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                        await AvisaYCerrateVosSolo(CantidadRegistrosActualizados + " Registros fueron actualizaron", "Modificacion completada con éxito!",2);
                        CantidadRegistrosActualizados = 0; 
                        #endregion
                    }
                    else
                    {
                        #region +
                        CantidadRegistrosActualizados = 0;
                        ValorDejarseVer = 100;
                        RaisePropertyChanged();
                        valorProgresoTextBox = String.Format("Finalizado. No se realizo ninguna modificacion en los permisos.");
                        RaisePropertyChanged();
                        if (cambiosEncabezados == 1)
                            //MessageBox.Show("Cambios en los encabezados almacenados éxitosamente.", "Guardando", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("Cambios en los encabezados fueron almacenados éxitosamente.", "Finalizado",1);
                        else
                            //MessageBox.Show("No se realizo ninguna modificacion", "Operacion fallida", MessageBoxButton.OK, MessageBoxImage.Warning);
                            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion", "Operacion fallida.",1);
                        cambiosEncabezados = 0; 
                        #endregion
                    }
                    AccionRestablecerRol = false;
                    this.FinalizarAction();
                    #endregion
                } 
            }
        }

        private async Task<bool> validacionManualOk()
        {
            if (SelectedRolSistema!=null)
            {
                using (db = new SGPTEntidades())
                {
                    try
                    {
                        var l = db.roles.ToList();
                        if (l != null)
                        {
                            foreach (var g in l)
                            {
                                if (g.nombrerol == NombreRol && g.nombrerol != currentRole.nombrerol)
                                {
                                    //MessageBox.Show("Este rol ya existe. Cambie el nombre y asigne los permisos correspondientes", "Error en el nombre al rol", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    await AvisaYCerrateVosSolo("Atencion, este rol ya existe!. Cambie el nombre y asigne los permisos correspondientes", "Error en el nombre al rol",1);
                                    return false;
                                }
                            }
                        }
                        //else
                        //{
                        //    return true;
                        //}
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error en la validacion de roles no duplicados.\nLa base de datos tardo demasiado en responder. "+e.InnerException, "Error en el tiempo de espera", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                } 
            }
            else
            {
                return false;
            }
            return true;
        }

        private async Task cuenteUno()
        {
            await Task.Delay(1);
        }

        public async Task<opcionesrole> DameUnRegistro(opcionesrole ppp)
        {
            //Nota, aqui debo hacer que el rol que se este modificando sea igual al rol plantilla a la que este regresando.
            //Funcion que permite que permite una espera minima para que otro proceso se ejecute o notifique.. en este caso, la barra de progreso.
            using (db = new SGPTEntidades())
            {
                opcionesrole a = new opcionesrole();
                if (!AccionRestablecerRol)
                {
                    a = db.opcionesroles.Where(x => x.idrol == ppp.idrol && x.idor == ppp.idor).SingleOrDefault(); 
                }
                else if (AccionRestablecerRol)
                {
                    a = db.opcionesroles.Where(x => x.idrol == currentRole.idrol && x.nombreopcionor==ppp.nombreopcionor).SingleOrDefault();
                }
                await Task.Delay(1);
                //return Task.Run(() => a);
                return a;
            }
        }

        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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
    }
}