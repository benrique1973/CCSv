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
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;



namespace SGPTmvvm.ViewModel
{
    public class TabFirmaTiempoViewModel : CrudVMBase 
    {

        //private UsuariosVM selectedUsuariosPersonas { get; set; }
        //public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }
        //public List<role> RolesListado { get; set; }
        public List<detalletiempo> DetalleTiempoListado { get; set; }
        //public List<opcionesrole> OpcionesRolesListado { get; set; }
        public TabFirmaTiempoViewModel()
        {
            _canExecute = true;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
        }
        private bool _canExecute;

        //public UsuariosVM SelectedUsuariosPersonas
        //{
        //    get
        //    {
        //        return selectedUsuariosPersonas; }
        //    set 
        //    { 
        //        selectedUsuariosPersonas = value;
        //    }
        //}

        public bool CanModify
        {
            get
            {
                return SelectedRol != null;
            }
        }

        private role _selectedRol;
        public role SelectedRol
        {
            get { return _selectedRol; }
            set { _selectedRol = value; RaisePropertyChanged("SelectedRol"); }
        }

     

        #region Crear
        private ICommand nuevoRol { get; set; }
        public ICommand NuevoRol
        {
            get
            {
                return nuevoRol ?? (nuevoRol = new CommandHandler(() => cmdNuevo(), _canExecute));
            }
        }

        public void cmdNuevo()
        {
            RolesMensajeModal mensajito = new RolesMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.rolAmodificar = new role();
            CRUDRolesView mivista = new CRUDRolesView(mensajito);
            var res = mivista.ShowDialog();
            this.ObtenerDatos();
            RaisePropertyChanged("RolesListado");
            RaisePropertyChanged("");
        }
        #endregion

        #region Editar Rol
        private ICommand editarRol { get; set; }
        public ICommand EditarRol
        {
            get
            {
                return editarRol ?? (editarRol = new CommandHandler(() => cmdEditar(), _canExecute));
            }
        }
        public void cmdEditar()
        {
            #region 
            if (SelectedRol != null && SelectedRol.idrol != 0)
            {
                if (SelectedRol.estadorol  == "A")
                {
                    RolesMensajeModal mensajito = new RolesMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.rolAmodificar = (role)SelectedRol;
                    //Messenger.Default.Send<UsuariosMensajeModal>(mensajito);
                    //En ves de enviar un mensaje, de una vez estoy llamando la ventana modal 24092016_12:35pm
                    //PruebaVentanaModal miv = new PruebaVentanaModal(mensajito);
                    CRUDRolesView mivista = new CRUDRolesView(mensajito);
                    var res = mivista.ShowDialog();
                    //MostrarModalDialog(mensajito);

                    this.ObtenerDatos();
                    RaisePropertyChanged("RolesListado");
                    RaisePropertyChanged(""); 
                }
                else { MessageBox.Show("No se puede editar un rol eliminado. Consulte al administrador para activarlo.", "El rol ha sido eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun rol para modificarlo.", "Seleccione un rol", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }  
            #endregion
            /*Recordar actualizar la vista para que recargue los datos actualizados*/
        } 
        #endregion

        #region Consultar Rol
        private ICommand consultarRol { get; set; }
        public ICommand ConsultarRol
        {
            get
            {
                return consultarRol ?? (consultarRol = new CommandHandler(() => cmdConsultar(), _canExecute));
            }
        }
        public void cmdConsultar()
        {
            #region
            if (SelectedRol != null && SelectedRol.idrol != 0)
            {
                if (SelectedRol.estadorol == "A")
                {
                    //UsuariosMensajeModal mensajito = new UsuariosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.usuarioAModificar = (UsuariosVM)selectedChangedx;
                    RolesMensajeModal mensajito = new RolesMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.rolAmodificar = (role)SelectedRol;
                    //Messenger.Default.Send<UsuariosMensajeModal>(mensajito);
                    //En ves de enviar un mensaje, de una vez estoy llamando la ventana modal 24092016_12:35pm
                    //PruebaVentanaModal miv = new PruebaVentanaModal(mensajito);
                    CRUDRolesView mivista = new CRUDRolesView(mensajito);
                   
                    var res = mivista.ShowDialog();
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

        
       protected override void ObtenerDatos()
        {
            /*La tabla usuario esta relacionada con una referencia circular, con Persona, con Firma, 
             con Pistas, y con los roles*/

            ThrobberVisible = Visibility.Visible;

            //ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();     

            //try
            //{
            //    using (db = new SGPTEntidades())
            //    {
            //        RolesListado = (from r in db.roles where r.sistemarol==false && r.estadorol=="A" orderby r.nombrerol select r).ToList();
            //        RaisePropertyChanged("RolesListado");

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. "+ex,"Error critico.",MessageBoxButton.OK,MessageBoxImage.Error);
            //}

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

       private ICommand _eliminarRol { get; set; }
       public ICommand EliminarRol
        {
            get
            {
                return _eliminarRol ?? (_eliminarRol = new CommandHandler(() => EliminarActual(), _canExecute));
            }
        }
        protected override void EliminarActual()
        {
            //UsuarioMensaje msg = new UsuarioMensaje();
            if (SelectedRol != null)
            {
                if (SelectedRol.estadorol == "A")
                {

                    #region
                   
                        #region
                    if (MessageBox.Show("El registro " + SelectedRol.nombrerol + ", " + SelectedRol.descripcionrol  + " se eliminara logicamente. Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            #region
                            try
                            {
                                using (db = new SGPTEntidades())
                                {
                                    //SelectedUsuariosPersonas.TheUsuariosPersonas.estadopersona = "B";
                                    //string bz = selectedChangedx.TheUsuariosPersonas.idduipersona;
                                    role elimrol = db.roles.Find(SelectedRol.idrol);
                                    elimrol.estadorol = "B";
                                    db.Entry(elimrol).State = EntityState.Modified;
                                    db.SaveChanges();
                                    this.ObtenerDatos();
                                    RaisePropertyChanged("RolesListado");
                                    RaisePropertyChanged("");
                                }

                                MessageBox.Show("El registro se elimino correctamente de manera logica.");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Imposible eliminar el rol seleccionado. Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            #endregion
                        }
                        #endregion
                   
                        MessageBox.Show("Eliminacion abortada. No se realizo ninguna accion", "Cancelado....", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    #endregion 
                }
                else { MessageBox.Show("El rol seleccionado esta inactivo o eliminado.", "Rol inexistente o eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation); }

            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun rol para eliminar.","Seleccione un rol",MessageBoxButton.OK,MessageBoxImage.Exclamation);

            }
            //Messenger.Default.Send<UsuarioMensaje>(msg);
        }

        /***********************/

        

    }
}