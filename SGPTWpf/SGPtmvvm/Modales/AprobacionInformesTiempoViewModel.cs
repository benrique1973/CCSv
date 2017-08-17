using CapaDatos;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;

namespace SGPTmvvm.Modales
{
    /// <summary>
    /// Esta pantalla permite validar por parte del supervisor de la firma, los informes presentados por los usuarios.
    /// 23/11/2016
    /// </summary>
    public class AprobacionInformesTiempoViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<opcionesrole> permisosRolesRol { get; set; } //borrar
        public List<InformeActividadesModelo> ListadoInformesAprobar { get; set; }
        public List<InformeActividadesModelo> InformeactividadesListado { get; set; }

        //public List<permisosrolesusuario> PermisosRolesUsuarios { get; set; }

        List<permisosrolesusuario> permisosActuales = new List<permisosrolesusuario>(); //borrar
        public int CantidadRegistrosActualizados = 0;

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

        //private bool AccionGuardar = true; //Borrar 
        //private bool AccionConsultar = false; //Borrar
        private DialogCoordinator dlg;
        public AprobacionInformesTiempoViewModel(FirmaTiemposMensajeModal msg)
        {
            dlg=new DialogCoordinator();
            _canExecute = true;
            this.EscuchandoALaVista(msg);
            //_barraProgresoVisible = Visibility.Collapsed;
            //BarraProgresoVisible = Visibility.Collapsed;
            //valorBarrita = 0;
            //RaisePropertyChanged("valorBarrita");
        }

        
        public enum ListaBotonesAprobacion { A, R, P }
        private ListaBotonesAprobacion _tipoAprobacion;
        public ListaBotonesAprobacion TipoAprobacion
        {
            get { return _tipoAprobacion; }
            set
            {
                _tipoAprobacion = value;
                RaisePropertyChanged("TipoAprobacion");
            }
        }

        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        public Action OcultarVentana { get; set; } //Permite ocultar AprobacionInformeTiempoView, pq se presenta otra ventana para consultar informes.
        public Action RestaurarVentana { get; set; } //Permite ocultar AprobacionInformeTiempoView, pq se presenta otra ventana para consultar informes.

        private void EscuchandoALaVista(FirmaTiemposMensajeModal Mensajito)
        {
            switch (Mensajito.Accion)
            {
                case TipoComando.Aprobar: AprobarInformes(Mensajito); break;
                default: break;
            }
        }

        

        #region Campos
        private int _idRol;
        private string _NombreRol;
        private string _DescripcionRol;

        public int IdRol { get { return _idRol; } set { _idRol = value; RaisePropertyChanged("IdRol"); } }
        public string NombreRol { get { return _NombreRol; } set { _NombreRol = value; RaisePropertyChanged("NombreRol"); } }
        public string DescripcionRol { get { return _DescripcionRol; } set { _DescripcionRol = value; RaisePropertyChanged("DescripcionRol"); } }
        
        #endregion

        private InformeActividadesModelo _InformeActSelected;
        public InformeActividadesModelo InformeActSelected 
        {
            get { return _InformeActSelected; }
            set { _InformeActSelected = value; RaisePropertyChanged("InformeActSelected"); }

        }
        #region Habilitadores
        private Boolean _habilitarcmdGuardar=false;
        public Boolean HabilitarcmdGuardar
        {
            get
            {
                return _habilitarcmdGuardar;
            }
            set
            {
                _habilitarcmdGuardar = value;
                RaisePropertyChanged("HabilitarcmdGuardar");
            }
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

        
        private ICommand _cmdConsultar_Click;
        public ICommand cmdConsultar_Click
        {
            get
            {
                return _cmdConsultar_Click ?? (_cmdConsultar_Click = new CommandHandler(() => cmdConsultar(), _canExecute));
            }
        }

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

        private async void AprobarInformes(FirmaTiemposMensajeModal msg) //primero que se activa cuando inicia
        {
            
            try
            {
                using (SGPTEntidades db = new SGPTEntidades())
                {
                    int o = 0; o++;
                    //InformeactividadesListado2 =(from inf in db.informeactividades where inf.estadoia=="A" orderby inf.idia select inf).ToList();
                    InformeactividadesListado = (from inf
                                                     in db.informeactividades
                                                     join u in db.usuarios 
                                                     on inf.idusuario equals u.idusuario
                                                 where inf.estadoia == "A" && inf.aprobacionia=="P"
                                                 orderby inf.idia
                                                 select new InformeActividadesModelo
                                                 {
                                                     idia = inf.idia,
                                                     idusuario = (int)inf.idusuario,
                                                     usuidusuario = (int)inf.usuidusuario,
                                                     usuarioNick=u.nickusuariousuario+" - "+u.inicialesusuario,
                                                     fechainicialia = inf.fechainicialia,
                                                     fechafinalia = inf.fechafinalia,
                                                     totalhorasia = (decimal)inf.totalhorasia,
                                                     tiempodias = ((decimal)inf.totalhorasia) / 8,
                                                     observacionesia = inf.observacionesia,
                                                     aprobacionia = inf.aprobacionia,
                                                     fechaaprobacionia = inf.fechaaprobacionia,
                                                     estadoia = inf.estadoia
                                                 }).ToList();
                                           
                    RaisePropertyChanged("InformeactividadesListado");
                    if (InformeactividadesListado == null)
                    {
                        await AvisaYCerrateVosSolo("No hay ningun informe que aprobar.", "La consola de informes esta vacia",2);
                        this.FinalizarAction();
                    }
                    else
                    {
                        currentUsuario = msg.UsuarioValidado;
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error critico al recuperar los datos de los informes de actividades.\nNotifique a soporte tecnico acerca de este error. " + e.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                //dlg.ShowMessageAsync(this, "Error critico al recuperar los datos de los informes de actividades", "Notifique a soporte tecnico acerca de este error." + ex);
            }

            RaisePropertyChanged("InformeactividadesListado");
        }

       
        private async void cmdCancelar()
        {
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.","Operacion cancelada por usted",1);
            
            this.FinalizarAction();
        }

        private async void cmdConsultar() // esta opcion tendra que llamar a CRUDfirmaInformeTiemposView
        {
            if (InformeActSelected != null)
            {
                FirmaTiemposMensajeModal mensajito = new FirmaTiemposMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.InformeAmodificar = InformeActSelected; //new InformeActividadesModelo();
                CRUDfirmaInformeTiemposView mivista = new CRUDfirmaInformeTiemposView(mensajito);
                this.OcultarVentana();
                var res = mivista.ShowDialog();
                RaisePropertyChanged("InformeSelected");
                RaisePropertyChanged("");
                this.RestaurarVentana();
            }
            else
            {
                await AvisaYCerrateVosSolo("Debe seleccionar un registro para realizar la consulta", "Error", 1);
            }
        }
        private async void activarBarra()
        {
            //DejarseVer = Visibility.Visible;
            //RaisePropertyChanged();
            //MessageBoxResult Guarde=MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            //switch (Guarde)
            //{
            //    case MessageBoxResult.Yes: this.cmdGuardar(); break;
            //    case MessageBoxResult.No: MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
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
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 2);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }
        }
                
        private async void cmdGuardar()
        {//***********************************************************************************************************
            //if (AccionGuardar)
            //{
                #region v

                using (db = new SGPTEntidades())
                {
                    try
                    {
                        int i = 0;
                        foreach (var inf in InformeactividadesListado)
                        {
                            if (inf.aprobacionia != "P") //si el informe no quedo como pendiente, quiere decir que esta aprobado o rechazado
                            {
                                var x = db.informeactividades.Find(inf.idia);
                                x.usuidusuario = currentUsuario.idusuario;
                                x.aprobacionia = inf.aprobacionia;
                                x.fechaaprobacionia = DateTime.Now.ToShortDateString();
                                db.Entry(x).State = EntityState.Modified;
                                db.SaveChanges();
                                i++;
                            }
                        }
                        if (i > 0)
                        {
                            await AvisaYCerrateVosSolo(i + " Registros fueron actualizados éxitosamente", "Modificacion éxitosa", 2);
                            i = 0;
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("Atencion, no se guardo nada.", "Modificacion fallida",2);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al guardar las aprobaciones de los informes.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este problema. " + ex.InnerException, "Imposible guardar", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                } FinalizarAction();

                #endregion
            //}

        }

        public async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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