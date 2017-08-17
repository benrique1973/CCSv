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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;

namespace SGPTmvvm.Modales
{
    /// <summary>
    /// Esta pantalla permite validar por parte del supervisor de la firma, las correspondencias presentados por los usuarios.
    /// 23/11/2016
    /// </summary>
    public class AprobacionFirmaCorrespondenciaViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        //public List<InformeActividadesModelo> ListadoInformesAprobar { get; set; }
        //public List<InformeActividadesModelo> InformeactividadesListado { get; set; } //borrar
        public List<CorrespondenciaModelo> CorrespondenciaListado { get; set; }

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
        private DialogCoordinator dlg,dlgs;
        public AprobacionFirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg)
        {
            _canExecute = true;
            this.EscuchandoALaVista(msg);
            dlg = new DialogCoordinator();
        }

        public AprobacionFirmaCorrespondenciaViewModel(DialogCoordinator dlgIn)
        {
            dlg = dlgIn;
            dlgs = new DialogCoordinator();
            //_canExecute = true;
            //this.EscuchandoALaVista(msg);
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

        private void EscuchandoALaVista(FirmaCorrespondenciaMensajeModal Mensajito)
        {
            switch (Mensajito.Accion)
            {
                case TipoComando.Aprobar: AprobarCorrespondencia(Mensajito); break;
                default: break;
            }
        }



        #region Campos

        #endregion

        //private InformeActividadesModelo _InformeActSelected; //borrar
        //public InformeActividadesModelo InformeActSelected
        //{
        //    get { return _InformeActSelected; }
        //    set { _InformeActSelected = value; RaisePropertyChanged("InformeActSelected"); }

        //}


        private CorrespondenciaModelo _CorrespondenciaSelected;
        public CorrespondenciaModelo CorrespondenciaSelected
        {
            get { return _CorrespondenciaSelected; }
            set { _CorrespondenciaSelected = value; RaisePropertyChanged("CorrespondenciaSelected"); }

        }

        #region Habilitadores
        private Boolean _habilitarcmdGuardar = false;
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

        private async void AprobarCorrespondencia(FirmaCorrespondenciaMensajeModal msg) //primero que se activa cuando inicia
        {

            try
            {
                using (SGPTEntidades db = new SGPTEntidades())
                {
                    int o = 0; o++;

                    CorrespondenciaListado = (from cor
                                                      in db.correspondencias
                                              join u in db.usuarios
                                              on cor.idusuario equals u.idusuario
                                              join p in db.personas
                                              on u.idduipersona equals p.idduipersona
                                              join ct in db.correspondenciatipos
                                              on cor.idct equals ct.idct
                                              where cor.estadocorrespondencia == "A" && cor.aprobacioncorrespondencia=="P"
                                              orderby cor.salientecorrespondencia
                                              select new CorrespondenciaModelo
                                              {
                                                  #region _
                                                  idcorrespondencia = cor.idcorrespondencia,
                                                  idpapeles = (int)cor.idpapeles,
                                                  idusuario = cor.idusuario,
                                                  idct = cor.idct,
                                                  TipoCorrespondencia = ct.descripcionct,
                                                  idnitcliente = cor.idnitcliente,
                                                  usuidusuario = (int)cor.usuidusuario,
                                                  numerocorrespondencia = cor.numerocorrespondencia,
                                                  asuntocorrespondencia = cor.asuntocorrespondencia,
                                                  firmacorrespondencia = cor.firmacorrespondencia,
                                                  auditorfirmacarta = u.inicialesusuario + " - " + p.nombrespersona + " " + p.apellidospersona,
                                                  fecharecepcioncorrespondencia = cor.fecharecepcioncorrespondencia,
                                                  comentariocorrespondencia = cor.comentariocorrespondencia,
                                                  aprobacioncorrespondencia = cor.aprobacioncorrespondencia,
                                                  fechacreadocorrespondencia = cor.fecharecepcioncorrespondencia,
                                                  fechaaprobacioncorrespondenci = cor.fecharecepcioncorrespondencia,
                                                  salientecorrespondencia = cor.salientecorrespondencia,
                                                  QueCorrespondencia = (cor.salientecorrespondencia == true) ? "Saliente" : "Entrante",
                                                  estadocorrespondencia = cor.estadocorrespondencia 
                                                  #endregion
                                              }).ToList();
                    int i = 1;
                    foreach (var a in CorrespondenciaListado)
                    {
                        a.correlativo = i; i++;
                    }

                    RaisePropertyChanged("CorrespondenciaListado");
                    if (CorrespondenciaListado == null)
                    {
                        await AvisaYCerrateVosSolo("No hay ninguna correspondencia que aprobar.", "La consola de correspondencia esta vacia", 2);
                        this.FinalizarAction();
                    }
                    else
                    {
                        currentUsuario = msg.UsuarioValidado;
                        //await dlg.ShowMessageAsync(this, "Hola camaleon", "Camaleon");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de la correspondencia.\nNotifique a soporte tecnico acerca de este error. "+ex.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                //dlg.ShowMessageAsync(this, "Error critico al recuperar los datos de los informes de actividades", "Notifique a soporte tecnico acerca de este error." + ex);
            }

            RaisePropertyChanged("CorrespondenciaListado");
        }


        private async void cmdCancelar()
        {
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada", 1);

            this.FinalizarAction();
        }

        private async void cmdConsultar() // esta opcion tendra que llamar a CRUDfirmaInformeTiemposView
        {
            if (CorrespondenciaSelected != null)
            {
                FirmaCorrespondenciaMensajeModal mensajito = new FirmaCorrespondenciaMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.CorrespondenciaAmodificar = CorrespondenciaSelected; //new InformeActividadesModelo();
                CRUDfirmaCorrespondenciaView mivista = new CRUDfirmaCorrespondenciaView(mensajito);
                this.OcultarVentana();
                var res = mivista.ShowDialog();
                RaisePropertyChanged("InformeSelected");
                this.RestaurarVentana();
            }
            else
            {
                await AvisaYCerrateVosSolo("Debe seleccionar un registro para realizar la consulta.", "Seleccione un registro para continuar", 1);
            }
        }
        private async void activarBarra()
        {
            //DejarseVer = Visibility.Visible;
            //RaisePropertyChanged();
            //MessageBoxResult Guarde = MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
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
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 1);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }
        }

        private async void cmdGuardar()
        {//***********************************************************************************************************
            #region v

                using (db = new SGPTEntidades())
                {
                    try
                    {
                        int i = 0;
                        foreach (var inf in CorrespondenciaListado)
                        {
                            if (inf.aprobacioncorrespondencia != "P") //si el informe no quedo como pendiente, quiere decir que esta aprobado o rechazado
                            {
                                var x = db.correspondencias.Find(inf.idcorrespondencia);
                                x.usuidusuario = currentUsuario.idusuario;
                                x.aprobacioncorrespondencia = inf.aprobacioncorrespondencia;
                                x.fechaaprobacioncorrespondenci = DateTime.Now.ToShortDateString();
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
                        MessageBox.Show("Ocurrio un error al guardar las aprobaciones de los informes de correspondencia.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este problema. "+ex.InnerException, "Imposible guardar", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                } FinalizarAction();

                #endregion
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