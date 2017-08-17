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
    sealed class TiempoViewModel : ViewModeloBase
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
        public List<usuariospersonas> ListadoUsuarios { get; set; }
        private DialogCoordinator dlg;

        #region Constructores


        
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
                        permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == "Informe Actividades" select p).SingleOrDefault();
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
            this.ObtenerListadoUsuarios();
            this.ObtenerDatos(); //Lo pongo hasta aqui, pq sino truena cuando recupero el listado de actividades que son solo del usuario actual
        }

        private void ObtenerListadoUsuarios()
        {
            using (db = new SGPTEntidades())
            {
                ListadoUsuarios = new List<usuariospersonas>();
                ListadoUsuarios = (from u in db.usuarios
                                   join p in db.personas
                                   on u.idduipersona equals p.idduipersona
                                   where p.estadopersona == "A"
                                   orderby p.nombrespersona
                                   select new usuariospersonas
                                   {
                                       #region
                                       idusuario = u.idusuario,
                                       idpista = (int)u.idpista,
                                       usuidusuario = (int)(u.usuidusuario),
                                       idrol = (int)(u.idrol),
                                       estadousuario = u.estadousuario,
                                       idduipersona = p.idduipersona,
                                       nombrespersona = p.nombrespersona,
                                       apellidospersona = p.apellidospersona,
                                       inicialesusuario = u.inicialesusuario,
                                       nombreCompleto = u.inicialesusuario + " - " + p.nombrespersona + " " + p.apellidospersona,
                                       nitpersona = p.nitpersona,
                                       estadopersona = p.estadopersona,
                                       #endregion
                                   }).ToList();
                RaisePropertyChanged("ListadoUsuarios");
            }
        }
        public TiempoViewModel()
        {
            Messenger.Default.Register<NivSecund_Administracion_UsuarioValidadoMensaje>(this, (usuarioValidado) => UsuarioValidado(usuarioValidado));
            RegisterCommands();
            MainModel = new MainModel();
            dlg = new DialogCoordinator();
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
        public List<InformeActividadesModelo> InformeactividadesListado {get;set;}

        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentUsuario

                public usuario usuarioLogueado { get; set; }
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
        private InformeActividadesModelo _informeSelected;
        public InformeActividadesModelo InformeSelected
        {
            get { return _informeSelected; }
            set { _informeSelected = value; RaisePropertyChanged("InformeSelected"); }
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
                        //InformeactividadesListado2 =(from inf in db.informeactividades where inf.estadoia=="A" orderby inf.idia select inf).ToList();
                        InformeactividadesListado = (from inf 
                                                         in db.informeactividades
                                                     where inf.estadoia == "A" && inf.idusuario==currentUsuario.idusuario 
                                                     orderby inf.idia 
                                                     select new InformeActividadesModelo 
                                                     {
                                                         #region +
                                                         idia = inf.idia,
                                                         idusuario = (int)inf.idusuario,
                                                         usuidusuario = (int)inf.usuidusuario,
                                                         fechainicialia = inf.fechainicialia,
                                                         fechafinalia = inf.fechafinalia,
                                                         totalhorasia = (decimal)inf.totalhorasia,
                                                         tiempodias = ((decimal)inf.totalhorasia) / 8,
                                                         observacionesia = inf.observacionesia,
                                                         aprobacionia = inf.aprobacionia,
                                                         fechaaprobacionia = inf.fechaaprobacionia,
                                                         estadoia = inf.estadoia 
                                                         #endregion
                                                     }).ToList();
                        int i=1;
                        foreach(var a in InformeactividadesListado)
                        {
                            a.correlativo=i; i++;
                            var j = ListadoUsuarios.Find(x => x.idusuario == a.idusuario);
                            a.nombreCompletoUsuario=j.nombreCompleto;
                        }
                        RaisePropertyChanged("InformeactividadesListado");
                    }
  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error critico al recuperar los datos de los informes de actividades. Notifique a soporte tecnico acerca de este error. " + ex, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                    //dlg.ShowMessageAsync(this, "Error critico al recuperar los datos de los informes de actividades", "Notifique a soporte tecnico acerca de este error." + ex);
                }

                RaisePropertyChanged("InformeactividadesListado");
                //ThrobberVisible = Visibility.Collapsed;
            }
            public void Nuevo()
            {
                try
                {
                    if (UsuarioPuedeCrear) //si tiene permisos de crear
                    {
                        FirmaTiemposMensajeModal mensajito = new FirmaTiemposMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.InformeAmodificar = new InformeActividadesModelo();
                        CRUDfirmaInformeTiemposView mivista = new CRUDfirmaInformeTiemposView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("InformeSelected");
                        RaisePropertyChanged("");
                    }
                    else
                    {
                        dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                    }
                }
                catch (Exception)
                {
                     dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "");
                } 

            }

            public void Editar()
            {
                if (!(InformeSelected == null))
                {
                    try
                    {
                        //if (permisorolusuariovalidado.editarpru && permisorolusuariovalidado != null)
                        if(UsuarioPuedeEditar)
                        {
                            FirmaTiemposMensajeModal mensajito = new FirmaTiemposMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.InformeAmodificar = InformeSelected; //new InformeActividadesModelo();
                            CRUDfirmaInformeTiemposView mivista = new CRUDfirmaInformeTiemposView(mensajito);
                            var res = mivista.ShowDialog();
                            this.ObtenerDatos();
                            RaisePropertyChanged("InformeSelected");
                            RaisePropertyChanged("");
                        }
                        else
                        {
                            dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para editar este tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        }
                    }
                    catch (Exception)
                    {
                     dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "");
                    }             
                }
                else
                {
                    dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
                }
            }
            private void Consultar()
            {
                if (!(InformeSelected == null))
                {
                    try
                    {
                        //if (permisorolusuariovalidado.consultarpru && permisorolusuariovalidado != null)
                        if(UsuarioPuedeConsultar)
                        {
                            if (activarVentanaConsulta)
                            {
                                FirmaTiemposMensajeModal mensajito = new FirmaTiemposMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.InformeAmodificar = InformeSelected; //new InformeActividadesModelo();
                                CRUDfirmaInformeTiemposView mivista = new CRUDfirmaInformeTiemposView(mensajito);
                                var res = mivista.ShowDialog();
                                this.ObtenerDatos();
                                RaisePropertyChanged("InformeSelected");
                                RaisePropertyChanged("");

                            }
                            else
                            {
                                //La ventana de consulta esta activa
                            }
                        }
                        else
                        {
                               dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para consultar este tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
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

            private void Aprobar()
            {
                try
                {
                    //if (permisorolusuariovalidado.aprobarpru && permisorolusuariovalidado!=null)
                    if(UsuarioPuedeAprobar)
                    {
                        FirmaTiemposMensajeModal mensajito = new FirmaTiemposMensajeModal(); mensajito.Accion = TipoComando.Aprobar; mensajito.UsuarioValidado = currentUsuario; mensajito.InformeAmodificar = InformeSelected; //new InformeActividadesModelo();
                        //CRUDfirmaInformeTiemposView mivista = new CRUDfirmaInformeTiemposView(mensajito);
                        AprobacionInformesTiempoView mivista = new AprobacionInformesTiempoView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("InformeSelected");
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
            public void Borrar() //borrado desactivado por ahorita... No olvidar activarlo.. ya esta activo 29/11/2016
            {
                if (!(InformeSelected == null))
                {
                    try
                    {
                        //if (permisorolusuariovalidado.eliminarpru && permisorolusuariovalidado != null)
                        if(UsuarioPuedeEliminar)
                        {
                            if (MessageBox.Show("El registro " + InformeSelected.idia + ", de fecha: " + InformeSelected.fechainicialia + " se eliminara logicamente. Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                #region
                                try
                                {
                                    using (SGPTEntidades db = new SGPTEntidades())
                                    {
                                        informeactividade eliminf = db.informeactividades.Find(InformeSelected.idia);
                                        eliminf.estadoia = "B";
                                        db.Entry(eliminf).State = EntityState.Modified;
                                        this.ObtenerDatos();
                                        RaisePropertyChanged("InformeSelected");
                                        RaisePropertyChanged("");
                                    }
                                    dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Imposible eliminar el rol seleccionado. Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        dlg.ShowMessageAsync(this, "Ocurrio un error al comparar los permisos del usuario", "");
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
                return InformeSelected != null;
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
    }
}
