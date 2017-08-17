using CapaDatos;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SGPTmvvm.Modales;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;


namespace SGPTmvvm.ViewModel
{

    public class PermisosRolesViewModel : CrudVMBase
    {
        public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }
        DialogCoordinator dlg;
        public PermisosRolesViewModel()
        {
            _canExecute = true;
            dlg = new DialogCoordinator();
            //ThrobberVisible = Visibility.Collapsed;
        }
        private bool _canExecute;

        private UsuariosVM selectedUsuariosRol;
        public UsuariosVM SelectedUsuariosRol
        {
            get
            {
                return selectedUsuariosRol;
            }
            set
            {
                selectedUsuariosRol = value;
                RaisePropertyChanged("");
                RaisePropertyChanged("CanModify");
            }
        }

        #region Editar Usuario
        private ICommand editarRolDeUsuario { get; set; }
        public ICommand EditarRolDeUsuario
        {
            get
            {
                return editarRolDeUsuario ?? (editarRolDeUsuario = new CommandHandler(() => cmdEditar(), _canExecute));
            }
        }
        public async void cmdEditar()
        {
            #region
            if (SelectedUsuariosRol != null && SelectedUsuariosRol.TheUsuariosPersonas.idduipersona != "")
            {
                if (SelectedUsuariosRol.TheUsuariosPersonas.estadopersona == "A")
                {
                    PermisosRolesMensajeModal mensajito = new PermisosRolesMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.rolesAmodificar = (UsuariosVM)SelectedUsuariosRol;
                    //Messenger.Default.Send<RolesMensajeModal>(mensajito);
                    CRUDpermisosRolesView mivista = new CRUDpermisosRolesView(mensajito);
                    var res = mivista.ShowDialog();
                    this.ObtenerDatos();
                    RaisePropertyChanged("UsuariosListado");
                }
                else { await AvisaYCerrateVosSolo("No se puede editar el rol de un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado", 1); }
            }
            else
            {
                await AvisaYCerrateVosSolo("No ha seleccionado ningun usuario para modificarlo.", "Seleccione un usuario", 1);
                /**********************************************/
            }
            #endregion
            /*Recordar actualizar la vista para que recargue los datos actualizados*/
        }
        #endregion
        protected override void ObtenerDatos()
        {
            /*La tabla usuario esta relacionada con una referencia circular, con Persona, con Firma, 
             con Pistas, y con los roles*/

            //ThrobberVisible = Visibility.Visible;

            ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();

            try
            {
                List<usuariospersonas> usuariosy;
                using (db = new SGPTEntidades())
                {
                    usuariosy = (from u in db.usuarios
                                 join p in db.personas
                                 on u.idduipersona equals p.idduipersona
                                 where p.estadopersona=="A"
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
                                     sexopersona = p.sexopersona,
                                     direccionpersona = p.direccionpersona,
                                     noafppersona = p.noafppersona,
                                     noissspersona = p.noissspersona,
                                     nitpersona = p.nitpersona,
                                     estadopersona = p.estadopersona,
                                     
                                     #endregion
                                 }).ToList();
                    foreach (usuariospersonas usua in usuariosy)
                    {
                        //using (db = new SGPTRelaciones())
                        //{
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
                            catch (Exception e)
                            {
                                MessageBox.Show("No se pudo recuperar el nombre del rol, ni el nombre del jefe "+e.InnerException);
                            }
                        //}
                        _usuarios.Add(new UsuariosVM { IsNew = false, TheUsuariosPersonas = usua });
                    }
                    UsuariosListado = _usuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado");
            //ThrobberVisible = Visibility.Collapsed;
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
        //public class CommandHandler : ICommand
        //{
        //    #region
        //    private Action _actionP;
        //    private bool _canExecute;
        //    public CommandHandler(Action actionp, bool canExecute)
        //    {
        //        _actionP = actionp;
        //        _canExecute = canExecute;
        //    }

        //    public bool CanExecute(object parameter)
        //    {
        //        return _canExecute;
        //    }

        //    public event EventHandler CanExecuteChanged; //lo implementamos pq asi lo demanda la interfaz

        //    public void Execute(object parameter)
        //    {
        //        _actionP();
        //    }
        //    #endregion
        //}  
    }
}