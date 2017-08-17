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
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Administracion.Firma
{
    class CorrespondenciaViewModel : ViewModeloBase
    {
        public SGPTEntidades db = new SGPTEntidades();
        permisosrolesusuario permisorolusuariovalidado { get; set; }
        public List<InformeActividadesModelo> InformeactividadesListado { get; set; } //borrar
        public List<CorrespondenciaModelo> CorrespondenciaListado { get; set; }
        private DialogCoordinator dlg;

        #region Constructores

        public CorrespondenciaViewModel()
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
                        permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == "Correspondencias" select p).SingleOrDefault();
                        UsuarioPuedeCrear = permisorolusuariovalidado.crearpru;
                        UsuarioPuedeEliminar = permisorolusuariovalidado.eliminarpru;
                        UsuarioPuedeConsultar = permisorolusuariovalidado.consultarpru;
                        UsuarioPuedeEditar = permisorolusuariovalidado.editarpru;
                        UsuarioPuedeImprimir=permisorolusuariovalidado.impresionpru;
                        UsuarioPuedeExportar=permisorolusuariovalidado.exportacionpru;
                        UsuarioPuedeRevisar=permisorolusuariovalidado.revisarpru;
                        UsuarioPuedeAprobar = permisorolusuariovalidado.aprobarpru;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio un error al recuperar los permisos del rol del usuario. "+e.InnerException, "La base de datos tardo demasido en responder.");
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
        
        private CorrespondenciaModelo _correspondenciaSelected;
        public CorrespondenciaModelo CorrespondenciaSelected
        {
            get { return _correspondenciaSelected; }
            set { _correspondenciaSelected = value; RaisePropertyChanged("InformeSelected"); }
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
                Mouse.OverrideCursor = Cursors.Wait;
                #region +
                try
                {
                    using (SGPTEntidades db = new SGPTEntidades())
                    {
                        CorrespondenciaListado = new List<CorrespondenciaModelo>();
                        CorrespondenciaListado = (from cor
                                                      in db.correspondencias
                                                  join ct in db.correspondenciatipos
                                                  on cor.idct equals ct.idct
                                                  join cli in db.clientes
                                                  on cor.idnitcliente equals cli.idnitcliente
                                                  where cor.estadocorrespondencia == "A"
                                                  orderby cor.salientecorrespondencia
                                                  select new CorrespondenciaModelo
                                                  {
                                                      idcorrespondencia = cor.idcorrespondencia,
                                                      idpapeles = (int)cor.idpapeles,
                                                      idusuario = cor.idusuario,
                                                      idct = cor.idct,
                                                      TipoCorrespondencia = ct.descripcionct,
                                                      idnitcliente = cor.idnitcliente,
                                                      razonsocialcliente = cli.razonsocialcliente,
                                                      usuidusuario = (int)cor.usuidusuario,
                                                      numerocorrespondencia = cor.numerocorrespondencia,
                                                      asuntocorrespondencia = cor.asuntocorrespondencia,
                                                      firmacorrespondencia = cor.firmacorrespondencia,
                                                      fecharecepcioncorrespondencia = cor.fecharecepcioncorrespondencia,
                                                      comentariocorrespondencia = cor.comentariocorrespondencia,
                                                      aprobacioncorrespondencia = cor.aprobacioncorrespondencia,
                                                      fechacreadocorrespondencia = cor.fecharecepcioncorrespondencia,
                                                      fechaaprobacioncorrespondenci = cor.fecharecepcioncorrespondencia,
                                                      salientecorrespondencia = cor.salientecorrespondencia,
                                                      QueCorrespondencia = (cor.salientecorrespondencia == true) ? "Saliente" : "Entrante",
                                                      estadocorrespondencia = cor.estadocorrespondencia,
                                                      //archivocorrespondencia=cor.archivocorrespondencia,
                                                      nombrefilecorrespondencia=cor.nombrefilecorrespondencia,
                                                      idcontactofirmacorrespondencia=(int)cor.idcontactofirmacorrespondencia,
                                                      tienePDF=(cor.archivocorrespondencia!=null?"PDF":"No")
                                                      //if(estadocorrespondencia=="A")
                                                      //    estadocorrespondencia2="Aprobado";
                                                      //estadocorrespondencia2=(cor.estadocorrespondencia==)
                                                  }).ToList();
                        foreach (var a in CorrespondenciaListado)
                        {
                            if (a.aprobacioncorrespondencia == "A")
                                a.estadocorrespondencia2 = "Aprobado";
                            if (a.aprobacioncorrespondencia == "R")
                                a.estadocorrespondencia2 = "Rechazado";
                            if (a.aprobacioncorrespondencia == "P")
                                a.estadocorrespondencia2 = "Pendiente";
                        }

                        //RaisePropertyChanged("CorrespondenciaListado");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error critico al recuperar el listado de las correspondencias. Notifique a soporte tecnico acerca de este error. " + ex.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                    //dlg.ShowMessageAsync(this, "Error critico al recuperar los datos de los informes de actividades", "Notifique a soporte tecnico acerca de este error." + ex);
                }

                RaisePropertyChanged("CorrespondenciaListado");
                //ThrobberVisible = Visibility.Collapsed; 
                #endregion
                Mouse.OverrideCursor = null;
            }
            public async void Nuevo()
            {
                try
                {
                    if (UsuarioPuedeCrear) //si tiene permisos de crear
                    {

                        FirmaCorrespondenciaMensajeModal mensajito = new FirmaCorrespondenciaMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.CorrespondenciaAmodificar = new CorrespondenciaModelo();
                        CRUDfirmaCorrespondenciaView mivista = new CRUDfirmaCorrespondenciaView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("CorrespondenciaSelected");
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.",1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "");
                } 

            }

            public async void Editar()
            {
                if (!(CorrespondenciaSelected == null))
                {
                    try
                    {
                        //if (permisorolusuariovalidado.editarpru && permisorolusuariovalidado != null)
                        if(UsuarioPuedeEditar)
                        {
                            if(! String.IsNullOrEmpty(CorrespondenciaSelected.nombrefilecorrespondencia))
                            {
                                Mouse.OverrideCursor = Cursors.Wait;
                                using(db=new SGPTEntidades())
	                            {
	                            	var r=db.correspondencias.Find(CorrespondenciaSelected.idcorrespondencia); 
                                    CorrespondenciaSelected.archivocorrespondencia=r.archivocorrespondencia;
	                            }
                                Mouse.OverrideCursor = null;
                            }
                            FirmaCorrespondenciaMensajeModal mensajito = new FirmaCorrespondenciaMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.CorrespondenciaAmodificar = CorrespondenciaSelected; //new InformeActividadesModelo();
                            CRUDfirmaCorrespondenciaView mivista = new CRUDfirmaCorrespondenciaView(mensajito);
                            var res = mivista.ShowDialog();
                            this.ObtenerDatos();
                            RaisePropertyChanged("CorrespondenciaSelected");
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para editar este tipo de informes.", "Consulte al administrador acerca de esta restriccion.",1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio un error al comparar los permisos del usuario. "+e.InnerException, "");
                    }             
                }
                else
                {
                    await AvisaYCerrateVosSolo("Debe seleccionar el registro a editar", "",1);
                }
            }
            private async void Consultar()
            {
                if (!(CorrespondenciaSelected == null))
                {
                    try
                    {
                        if(UsuarioPuedeConsultar)
                        {
                            if (activarVentanaConsulta)
                            {
                                if(! String.IsNullOrEmpty(CorrespondenciaSelected.nombrefilecorrespondencia))
                                {
                                    Mouse.OverrideCursor = Cursors.Wait;
                                    using(db=new SGPTEntidades())
	                                {
	                                	var r=db.correspondencias.Find(CorrespondenciaSelected.idcorrespondencia); 
                                        CorrespondenciaSelected.archivocorrespondencia=r.archivocorrespondencia;
	                                }
                                    Mouse.OverrideCursor = null;
                                }
                                FirmaCorrespondenciaMensajeModal mensajito = new FirmaCorrespondenciaMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.CorrespondenciaAmodificar = CorrespondenciaSelected; //new InformeActividadesModelo();
                                CRUDfirmaCorrespondenciaView mivista = new CRUDfirmaCorrespondenciaView(mensajito);
                                var res = mivista.ShowDialog();
                                this.ObtenerDatos();
                                RaisePropertyChanged("CorrespondenciaSelected");
                                RaisePropertyChanged("");

                            }
                            else
                            {
                                //La ventana de consulta esta activa
                            }
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para consultar este tipo de informes.", "Consulte al administrador acerca de esta restriccion.",1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "");
                    }              
                }
                else
                {
                       await AvisaYCerrateVosSolo("No ha seleccionado ningun registro para consultarlo.", "Seleccione un rol para continuar...",1);
                }
            }
            public void ConsultarDobleClick()
            {
                this.Consultar();
            }

            private async void Aprobar()
            {
                try
                {
                    if(UsuarioPuedeAprobar)
                    {
                        FirmaCorrespondenciaMensajeModal mensajito = new FirmaCorrespondenciaMensajeModal(); mensajito.Accion = TipoComando.Aprobar; mensajito.UsuarioValidado = currentUsuario; mensajito.CorrespondenciaAmodificar = CorrespondenciaSelected; //new InformeActividadesModelo();
                        AprobacionFirmaCorrespondenciaView mivista = new AprobacionFirmaCorrespondenciaView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("CorrespondenciaSelected");
                        RaisePropertyChanged("");
                    }
                    else
                    {
                         await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para aprobar este tipo de informes.", "Consulte al administrador acerca de esta restriccion.",1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "");
                }
                    //}
            }
            public async void Borrar() //borrado desactivado por ahorita... No olvidar activarlo.. ya esta activo 29/11/2016
            {
                if (!(CorrespondenciaSelected == null))
                {
                    try
                    {
                        //if (permisorolusuariovalidado.eliminarpru && permisorolusuariovalidado != null)
                        if(UsuarioPuedeEliminar)
                        {
                            //if (MessageBox.Show("El registro " + CorrespondenciaSelected.idcorrespondencia + ", de fecha: " + CorrespondenciaSelected.fechacreadocorrespondencia + " se eliminara logicamente. Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            //{
                            var mySettingsk = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "Acepto",
                                NegativeButtonText = "No",
                            };
                            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro " + CorrespondenciaSelected.idcorrespondencia + ", de fecha: " + CorrespondenciaSelected.fechacreadocorrespondencia + " se eliminara logicamente. Desea continuar?", "Advertencia... ", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                            if (resultk == MessageDialogResult.Affirmative)
                            {
                                #region
                                try
                                {
                                    using (SGPTEntidades db = new SGPTEntidades())
                                    {
                                        correspondencia elimcor = db.correspondencias.Find(CorrespondenciaSelected.idcorrespondencia);
                                        elimcor.estadocorrespondencia = "B";
                                        db.Entry(elimcor).State = EntityState.Modified;
                                        this.ObtenerDatos();
                                        RaisePropertyChanged("CorrespondenciaSelected");
                                    }
                                        await AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.", "Proceso completado.",1);
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Imposible eliminar el rol seleccionado. Consulte a soporte tecnico acerca de este error. "+e.InnerException, "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                #endregion
                            }
                            else
                               await AvisaYCerrateVosSolo("Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...",1);
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.",1);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "");
                    }
                }
                else
                {
                    //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                        await AvisaYCerrateVosSolo("Debe seleccionar el registro a eliminar", "",1);
                }
            }
        #endregion

            #region Verificaciones
            public bool CanActivarse()
            {
                return CorrespondenciaSelected != null;
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
