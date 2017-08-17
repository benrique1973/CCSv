using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Modales;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;



namespace SGPTmvvm.ViewModel
{
    public class UsuariosViewModel : CrudVMBase 
    {
        private UsuariosVM selectedUsuariosPersonas { get; set; }
        public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }
        public UsuariosViewModel()
        {
            _canExecute = true;
        }
        private bool _canExecute;
        public UsuariosVM SelectedUsuariosPersonas
        {
            get
            {
                return selectedUsuariosPersonas; }
            set 
            { 
                selectedUsuariosPersonas = value;
            }
        }

        public bool CanModify
        {
            get
            {
                return SelectedChangedx != null;
            }
        }


        private UsuariosVM selectedChangedx;
        public UsuariosVM SelectedChangedx
        {
            get
            {
                return selectedChangedx;
            }
            set
            {   
                selectedChangedx = value;
                RaisePropertyChanged("");
                //RaisePropertyChanged("CanModify");
            }
        }

        #region Crear
        private ICommand nuevoUsuario { get; set; }
        public ICommand NuevoUsuarioPersona
        {
            get
            {
                return nuevoUsuario ?? (nuevoUsuario = new CommandHandler(() => cmdNuevo(), _canExecute));
            }
        }

        public void cmdNuevo()
        {
            UsuariosMensajeModal mensajito = new UsuariosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.usuarioAModificar = new UsuariosVM();
            //Messenger.Default.Send<UsuariosMensajeModal>(mensajito);
            //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
            //var res = mivista.ShowDialog();
            this.ObtenerDatos();
            RaisePropertyChanged("UsuariosListado");
            RaisePropertyChanged("");
        }
        #endregion
        #region Editar Usuario
        private ICommand editarUsuario { get; set; }
        public ICommand EditarUsuarioPersona
        {
            get
            {
                return editarUsuario ?? (editarUsuario = new CommandHandler(() => cmdEditar(), _canExecute));
            }
        }
        public void cmdEditar()
        {
            #region 
            if (selectedChangedx != null && selectedChangedx.TheUsuariosPersonas.idduipersona != "")
            {
                if (selectedChangedx.TheUsuariosPersonas.estadopersona=="A")
                {
                    UsuariosMensajeModal mensajito = new UsuariosMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.usuarioAModificar = (UsuariosVM)selectedChangedx;
                    //Messenger.Default.Send<UsuariosMensajeModal>(mensajito);
                    //En ves de enviar un mensaje, de una vez estoy llamando la ventana modal 24092016_12:35pm
                    //PruebaVentanaModal miv = new PruebaVentanaModal(mensajito);
                    //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
                    //var res = mivista.ShowDialog();
                    //MostrarModalDialog(mensajito);

                    this.ObtenerDatos();
                    RaisePropertyChanged("UsuariosListado");
                    RaisePropertyChanged(""); 
                }
                else { MessageBox.Show("No se puede editar un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario para modificarlo.", "Seleccione un usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }  
            #endregion
            /*Recordar actualizar la vista para que recargue los datos actualizados*/
        } 
        #endregion

        #region Consultar Usuario
        private ICommand consultarUsuario { get; set; }
        public ICommand ConsultarUsuarioPersona
        {
            get
            {
                return consultarUsuario ?? (consultarUsuario = new CommandHandler(() => cmdConsultar(), _canExecute));
            }
        }
        public void cmdConsultar()
        {
            #region
            if (selectedChangedx != null && selectedChangedx.TheUsuariosPersonas.idduipersona != "")
            {
                if (selectedChangedx.TheUsuariosPersonas.estadopersona == "A")
                {
                    UsuariosMensajeModal mensajito = new UsuariosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.usuarioAModificar = (UsuariosVM)selectedChangedx;
                    //Messenger.Default.Send<UsuariosMensajeModal>(mensajito);
                    //En ves de enviar un mensaje, de una vez estoy llamando la ventana modal 24092016_12:35pm
                    //PruebaVentanaModal miv = new PruebaVentanaModal(mensajito);
                    //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
                    //var res = mivista.ShowDialog();
                    //MostrarModalDialog(mensajito);

                    this.ObtenerDatos();
                    RaisePropertyChanged("UsuariosListado");
                    RaisePropertyChanged("");
                }
                else { MessageBox.Show("No se puede editar un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario para modificarlo.", "Seleccione un usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            #endregion
            /*Recordar actualizar la vista para que recargue los datos actualizados*/
        }
        #endregion

        #region Permisos roles usuarios
        /**************************************Permisos Roles Usuarios*****************/
        private ICommand permisosUsuarioPersona { get; set; }
        public ICommand PermisosUsuarioPersona
        {
            get
            {
                return permisosUsuarioPersona ?? (permisosUsuarioPersona = new CommandHandler(() => cmdPermisos(), _canExecute));
            }
        }
        public void cmdPermisos()
        {
            #region
            if (selectedChangedx != null && selectedChangedx.TheUsuariosPersonas.idduipersona != "")
            {
                if (selectedChangedx.TheUsuariosPersonas.estadopersona == "A")
                {
                    PermisosRolesMensajeModal mensajito = new PermisosRolesMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.rolesAmodificar = (UsuariosVM)selectedChangedx;
                    //Messenger.Default.Send<RolesMensajeModal>(mensajito);
                    CRUDpermisosRolesView mivista = new CRUDpermisosRolesView(mensajito);
                    var res = mivista.ShowDialog();
                    this.ObtenerDatos();
                    RaisePropertyChanged("UsuariosListado");
                    RaisePropertyChanged("");
                }
                else { MessageBox.Show("No se puede editar el rol de un usuario eliminado. Consulte al administrador para activarlo.", "El usuario ha sido eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario para modificarle permisos.", "Seleccione un usuario", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                /**********************************************/
            }
            #endregion
        }



        /*************************************Fin Permisos roles usuarios***************/
        #endregion


        
       protected override void ObtenerDatos()
        {
            /*La tabla usuario esta relacionada con una referencia circular, con Persona, con Firma, 
             con Pistas, y con los roles*/

            ThrobberVisible = Visibility.Visible;

            ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();     

            try
            {
                List<usuariospersonas> usuariosy;
                using (db = new SGPTEntidades())
                {
                    //db.Configuration.AutoDetectChangesEnabled = false;
                    //db.Configuration.ValidateOnSaveEnabled = false;
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
                }
                                //from t in db.telefonos on p.idduipersona equals t.idduipersona 
                foreach (usuariospersonas usua in usuariosy)
                {
                    using (db = new SGPTEntidades())
                    {
                        try
                        {   if(usua.idrol>0) 
                            {
                                String nombreRolz = (from r in db.roles where r.idrol.Equals(usua.idrol) select r.nombrerol).FirstOrDefault();
                                usua.nombrerol = nombreRolz;
                            }
                            if(usua.usuidusuario>0)
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
                    _usuarios.Add(new UsuariosVM { IsNew = false, TheUsuariosPersonas = usua });
                }
                UsuariosListado = _usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. "+ex,"Error critico.",MessageBoxButton.OK,MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado");
            ThrobberVisible = Visibility.Collapsed;
        }


       private Visibility throbberVisible = Visibility.Visible;
       public Visibility ThrobberVisible
       {
           get { return throbberVisible; }
           set
           {
               throbberVisible = value;
               RaisePropertyChanged();
           }
       }
        //protected override void ConfirmarActualizaciones() { }

        private ICommand _eliminarUsuarioPersona { get; set; }
        public ICommand EliminarUsuarioPersona
        {
            get
            {
                return _eliminarUsuarioPersona ?? (_eliminarUsuarioPersona = new CommandHandler(() => EliminarActual(), _canExecute));
            }
        }
        protected override void EliminarActual()
        {
            UsuarioMensaje msg = new UsuarioMensaje();
            if (SelectedChangedx != null)
            {
                if (selectedChangedx.TheUsuariosPersonas.estadopersona=="A")
                {

                    #region
                    if (selectedChangedx.TheUsuariosPersonas.estadopersona == "A")
                    {
                        #region
                        if (MessageBox.Show("El registro " + selectedChangedx.TheUsuariosPersonas.nombrespersona + ", " + selectedChangedx.TheUsuariosPersonas.apellidospersona + " se eliminara logicamente. Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            #region
                            try
                            {
                                using (db = new SGPTEntidades())
                                {
                                    //SelectedUsuariosPersonas.TheUsuariosPersonas.estadopersona = "B";
                                    //string bz = selectedChangedx.TheUsuariosPersonas.idduipersona;
                                    persona elimpers = db.personas.Find(selectedChangedx.TheUsuariosPersonas.idduipersona);
                                    elimpers.estadopersona = "B";
                                    db.Entry(elimpers).State = EntityState.Modified;
                                    db.SaveChanges();
                                    this.ObtenerDatos();
                                    RaisePropertyChanged("UsuariosListado");
                                    RaisePropertyChanged("");
                                }

                                MessageBox.Show("El registro se elimino correctamente de manera logica.");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Imposible eliminar al usuario seleccionado. Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("Eliminacion abortada. No se realizo ninguna accion", "Cancelado....", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    #endregion 
                }
                else { MessageBox.Show("El usuario seleccionado esta inactivo o eliminado.", "Usuario inexistente o eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); }

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun usuario para eliminar.","Seleccione un usuario",MessageBoxButton.OK,MessageBoxImage.Exclamation);

                msg.Mensaje = "Ningun usuario seleccionado para Eliminar";
            }
            Messenger.Default.Send<UsuarioMensaje>(msg);
        }

        /***********************/

        

    }
}