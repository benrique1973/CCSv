using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Model;
using SGPTmvvm.Model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Modales;
using SGPTWpf.Messages.Administracion.Usuario;
using System.Data.Entity;

namespace SGPTWpf.ViewModel.Administracion.Firma
{
    class ReunionesViewModel : ViewModeloBase
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
        permisosrolesusuario permisorolusuariovalidado { get; set; }
        //public List<CorrespondenciaModelo> CorrespondenciaListado { get; set; } //borrar
        public List<ReunionesModelo> ReunionesListado { get; set; }

        

        private DialogCoordinator dlg;

        #region Constructores

        public ReunionesViewModel()
        {
            RegisterCommands();
            dlg = new DialogCoordinator();
            Messenger.Default.Register<NivSecund_Administracion_UsuarioValidadoMensaje>(this, (usuarioValidado) => UsuarioValidado(usuarioValidado));
            MainModel = new MainModel();
        }
        
        private void UsuarioValidado(NivSecund_Administracion_UsuarioValidadoMensaje usuarioValidado)
        {
            if (usuarioValidado.elementoMensaje!=null)
            {
                currentUsuario = usuarioValidado.elementoMensaje;
                using (db=new SGPTEntidades())
                {
                    try
                    {
                        //extrayendo los permisos dados al usuario segun su rol
                        permisorolusuariovalidado = new permisosrolesusuario();
                        permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == "Reuniones" select p).SingleOrDefault();
                        UsuarioPuedeCrear = permisorolusuariovalidado.crearpru;
                        UsuarioPuedeEliminar = permisorolusuariovalidado.eliminarpru;
                        UsuarioPuedeConsultar = permisorolusuariovalidado.consultarpru;
                        UsuarioPuedeEditar = permisorolusuariovalidado.editarpru;
                        UsuarioPuedeImprimir=permisorolusuariovalidado.impresionpru;
                        UsuarioPuedeExportar=permisorolusuariovalidado.exportacionpru;
                        UsuarioPuedeRevisar=permisorolusuariovalidado.revisarpru;
                        UsuarioPuedeAprobar = permisorolusuariovalidado.aprobarpru;
                    }
                    catch (Exception)
                    {
                        dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los permisos del rol del usuario", "La base de datos tardo demasido en responder.");
                    } 
                }
            }
            this.ObtenerDatos(); //Lo pongo hasta aqui, pq sino truena cuando recupero el listado de actividades que son solo del usuario actual
        }
        #endregion

        /********************************************************************/
        #region Permisos del Usuario Logueado

        private Boolean _UsuarioPuedeCrear;
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

        private Boolean _UsuarioPuedeEliminar;
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
        private Boolean _UsuarioPuedeConsultar;
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

        private Boolean _UsuarioPuedeEditar;
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
        private Boolean _UsuarioPuedeImprimir;
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
        private Boolean _UsuarioPuedeExportar;
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
        private Boolean _UsuarioPuedeRevisar;
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

        private Boolean _UsuarioPuedeAprobar;
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


         #region Propiedades privadas
        private static bool activarVentanaConsulta = true; 

        #endregion

         #region ViewModel Properties publicas

        #region ViewModel Properties : Lista


        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentUsuario

        //public usuario usuarioLogueado { get; set; }
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
                RaisePropertyChanged(currentUsuarioPropertyName);
            }
        }
        
        private ReunionesModelo _reunionesSelected;
        public ReunionesModelo ReunionesSelected
        {
            get { return _reunionesSelected; }
            set { _reunionesSelected = value; RaisePropertyChanged("InformeSelected"); }
        }

        #endregion

        #endregion

        #endregion

         #region ViewModel Comandos


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand AprobarCommand { get; set; }

        public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        //public RelayCommand<RolModelo> SelectionChangedCommand { get; set; }

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

        #region Implementacion de comandos
            private void ObtenerDatos()
            {
                try
                {
                    using (SGPTEntidades db = new SGPTEntidades())
                    {

                        ReunionesListado = (from reu
                                                      in db.reuniones
                                                  join cli in db.clientes
                                                  on reu.idnitcliente equals cli.idnitcliente
                                                  where reu.estadoreunion == "A"
                                                  orderby reu.idreunion
                                                  select new ReunionesModelo
                                                  {
                                                           idreunion    =reu.idreunion,
                                                           idnitcliente =reu.idnitcliente  ,
                                                           nombrecliente=cli.razonsocialcliente ,
                                                           fechareunion =reu.fechareunion  ,
                                                           tiempoduracionreunion=(decimal)reu.tiempoduracionreunion,
                                                           participanteexternoreunion =reu.participanteexternoreunion ,
                                                           participantesinternoreunion=reu.participantesinternoreunion,
                                                           asuntoreunion       =reu.asuntoreunion,
                                                           conclusionesreunion =reu.conclusionesreunion ,
                                                           aprobacionreunion   =reu.aprobacionreunion,
                                                           estadoreunion       =reu.estadoreunion
                                                  }).ToList();
                        foreach (var a in ReunionesListado)
                        {
                            if (a.aprobacionreunion == "A")
                                a.estadoreunion2 = "Aprobado";
                            if (a.aprobacionreunion == "R")
                                a.estadoreunion2 = "Rechazado";
                            if (a.aprobacionreunion == "P")
                                a.estadoreunion2 = "Pendiente";
                        }

                        RaisePropertyChanged("ReunionesListado");
                    }
  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error critico al recuperar los datos de los reuniones.\nLa base de datos tardo demasiado en responder. \nNotifique a soporte tecnico acerca de este error. ", "Error critico. "+ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                    //dlg.ShowMessageAsync(this, "Error critico al recuperar los datos de los informes de actividades", "Notifique a soporte tecnico acerca de este error." + ex);
                }

                RaisePropertyChanged("ReunionesListado");
                //ThrobberVisible = Visibility.Collapsed;
            }
            public void Nuevo()
            {
                try
                {
                    if (UsuarioPuedeCrear) //si tiene permisos de crear
                    {
                        FirmaReunionesMensajeModal mensajito = new FirmaReunionesMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.ReunionesAmodificar = new ReunionesModelo();
                        CRUDfirmaReunionesView mivista = new CRUDfirmaReunionesView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged();
                    }
                    else
                    {
                        AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de reuniones.", "Consulte al administrador acerca de esta restriccion.",2);
                    }
                }
                catch (Exception)
                {
                    AvisaYCerrateVosSolo("Ocurrio un error al comparar los permisos del usuario", "",1);
                } 

            }

            public async void Editar()
            {
                if (!(ReunionesSelected == null))
                {
                    try
                    {
                        if(UsuarioPuedeEditar)
                        {
                            FirmaReunionesMensajeModal mensajito = new FirmaReunionesMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.ReunionesAmodificar = ReunionesSelected;
                            CRUDfirmaReunionesView mivista = new CRUDfirmaReunionesView(mensajito);
                            var res = mivista.ShowDialog();
                            this.ObtenerDatos();
                            RaisePropertyChanged("CorrespondenciaSelected");
                            RaisePropertyChanged("");
                        }
                        else
                        {
                            await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para editar reuniones.", "Consulte al administrador acerca de esta restriccion.");
                        }
                    }
                    catch (Exception)
                    {
                        //dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "");
                        
                    }             
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                }
            }
            private void Consultar()
            {
                if (!(ReunionesSelected == null))
                {
                    try
                    {
                        if(UsuarioPuedeConsultar)
                        {
                            if (activarVentanaConsulta)
                            {
                                FirmaReunionesMensajeModal mensajito = new FirmaReunionesMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.UsuarioValidado = currentUsuario; mensajito.ReunionesAmodificar = ReunionesSelected;
                                CRUDfirmaReunionesView mivista = new CRUDfirmaReunionesView(mensajito);
                                var res = mivista.ShowDialog();
                                this.ObtenerDatos();
                                RaisePropertyChanged();

                            }
                            else
                            {
                                //La ventana de consulta esta activa
                            }
                        }
                        else
                        {
                           dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para consultar reuniones.", "Consulte al administrador acerca de esta restriccion.");
                        }
                    }
                    catch (Exception)
                    {
                     dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "");
                    }              
                }
                else
                {
                     dlg.ShowMessageAsync(this, "No ha seleccionado ningun registro para consultarlo.", "Seleccione un rol para continuar...");
                }
            }
            public void ConsultarDobleClick()
            {
                this.Consultar();
            }

            private  void Aprobar()
            {
                try
                {
                    if(UsuarioPuedeAprobar)
                    {
                        FirmaReunionesMensajeModal mensajito = new FirmaReunionesMensajeModal(); mensajito.Accion = TipoComando.Aprobar; mensajito.UsuarioValidado = currentUsuario; mensajito.ReunionesAmodificar = new ReunionesModelo();
                        AprobacionFirmaReunionesView mivista = new AprobacionFirmaReunionesView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("");
                    }
                    else
                    {
                        dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para aprobar este tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                    }
                }
                catch (Exception)
                {
                     dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "");
                }
                    //}
            }
            public  void Borrar() //borrado desactivado por ahorita... No olvidar activarlo.. ya esta activo 29/11/2016
            {
                if (!(ReunionesSelected == null))
                {
                    try
                    {
                        //if (permisorolusuariovalidado.eliminarpru && permisorolusuariovalidado != null)
                        if(UsuarioPuedeEliminar)
                        {
                            if (MessageBox.Show("El registro " + ReunionesSelected.idreunion + ", de fecha: " + ReunionesSelected.fechareunion + " se eliminara logicamente. Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                #region
                                try
                                {
                                    using (SGPTEntidades db = new SGPTEntidades())
                                    {
                                        reunione elimcor = db.reuniones.Find(ReunionesSelected.idreunion);
                                        elimcor.estadoreunion = "B";
                                        db.Entry(elimcor).State = EntityState.Modified;
                                        this.ObtenerDatos();
                                        RaisePropertyChanged("ReunionesSelected");
                                        RaisePropertyChanged("");
                                    }
                                        dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Imposible eliminar la reunion. Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                #endregion
                            }
                            else
                                dlg.ShowMessageAsync(this, "Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...");
                        }
                        else
                        {
                            dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.");
                        }
                    }
                    catch (Exception)
                    {
                         dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "La base de datos tardo demasiado en responder");
                    }
                }
                else
                {
                    //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                        dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
                }
            }
        #endregion

            #region Verificaciones
            public bool CanActivarse()
            {
                return ReunionesSelected != null;
            }
            #endregion
        #endregion

        #region ViewModel Private Methods
        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanActivarse);
            BorrarCommand = new RelayCommand(Borrar, CanActivarse);
            ConsultarCommand = new RelayCommand(Consultar, CanActivarse);
            AprobarCommand = new RelayCommand(Aprobar);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
        }
        #endregion

        private async void AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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
