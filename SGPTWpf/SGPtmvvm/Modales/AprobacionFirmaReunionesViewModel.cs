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
    public class AprobacionFirmaReunionesViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        //public List<InformeActividadesModelo> ListadoInformesAprobar { get; set; }
        //public List<InformeActividadesModelo> InformeactividadesListado { get; set; } //borrar
        public List<ReunionesModelo> ReunionesListado { get; set; }

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

        private ReunionesModelo _reunionesSelected;
        public ReunionesModelo ReunionesSelected
        {
            get { return _reunionesSelected; }
            set { _reunionesSelected = value; RaisePropertyChanged("InformeSelected"); }
        }

        //private bool AccionGuardar = true; //Borrar 
        //private bool AccionConsultar = false; //Borrar
        private DialogCoordinator dlg,dlgs;
        public AprobacionFirmaReunionesViewModel(FirmaReunionesMensajeModal msg)
        {
            _canExecute = true;
            this.EscuchandoALaVista(msg);
            dlg = new DialogCoordinator();
        }

        public AprobacionFirmaReunionesViewModel(DialogCoordinator dlgIn)
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

        private void EscuchandoALaVista(FirmaReunionesMensajeModal Mensajito)
        {
            switch (Mensajito.Accion)
            {
                case TipoComando.Aprobar: AprobarCorrespondencia(Mensajito); break;
                default: break;
            }
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

        private async void AprobarCorrespondencia(FirmaReunionesMensajeModal msg) //primero que se activa cuando inicia
        {

            try
            {
                using (SGPTEntidades db = new SGPTEntidades())
                {
                    #region +
                    ReunionesListado = (from reu
                                              in db.reuniones
                                        join cli in db.clientes
                                        on reu.idnitcliente equals cli.idnitcliente
                                        where reu.estadoreunion == "A"
                                        orderby reu.idreunion
                                        select new ReunionesModelo
                                        {
                                            idreunion = reu.idreunion,
                                            idnitcliente = reu.idnitcliente,
                                            nombrecliente = cli.razonsocialcliente,
                                            fechareunion = reu.fechareunion,
                                            tiempoduracionreunion = (decimal)reu.tiempoduracionreunion,
                                            participanteexternoreunion = reu.participanteexternoreunion,
                                            participantesinternoreunion = reu.participantesinternoreunion,
                                            asuntoreunion = reu.asuntoreunion,
                                            conclusionesreunion = reu.conclusionesreunion,
                                            aprobacionreunion = reu.aprobacionreunion,
                                            estadoreunion = reu.estadoreunion
                                        }).ToList();

                    RaisePropertyChanged("ReunionesListado");
                    if (ReunionesListado == null)
                    {
                        await AvisaYCerrateVosSolo("No hay ninguna reunion que aprobar.", "La consola de reuniones esta vacia",2);
                        this.FinalizarAction();
                    }
                    else
                    {
                        currentUsuario = msg.UsuarioValidado;
                        //await dlg.ShowMessageAsync(this, "Hola camaleon", "Camaleon");
                    } 
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de la correspondencia.\nNotifique a soporte tecnico acerca de este error. "+ex.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                //dlg.ShowMessageAsync(this, "Error critico al recuperar los datos de los informes de actividades", "Notifique a soporte tecnico acerca de este error." + ex);
            }

            RaisePropertyChanged("CorrespondenciaListado"); //currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
        }


        private async void cmdCancelar()
        {
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada", 2);

            this.FinalizarAction();
        }

        private async void cmdConsultar() // esta opcion tendra que llamar a CRUDfirmaInformeTiemposView
        {
            if (ReunionesSelected != null)
            {
                #region +
                //FirmaCorrespondenciaMensajeModal mensajito = new FirmaCorrespondenciaMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.CorrespondenciaAmodificar = CorrespondenciaSelected; //new InformeActividadesModelo();
                //CRUDfirmaCorrespondenciaView mivista = new CRUDfirmaCorrespondenciaView(mensajito);
                FirmaReunionesMensajeModal mensajito = new FirmaReunionesMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.UsuarioValidado = currentUsuario; mensajito.ReunionesAmodificar = ReunionesSelected;
                CRUDfirmaReunionesView mivista = new CRUDfirmaReunionesView(mensajito);
                this.OcultarVentana();
                var res = mivista.ShowDialog();
                RaisePropertyChanged("InformeSelected");
                this.RestaurarVentana(); 
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("Debe seleccionar un registro para realizar la consulta", "Error", 2);
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
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 2);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }
        }


        private async void cmdGuardar()
        {//***********************************************************************************************************

            if (true)
            {
                #region v

                using (db = new SGPTEntidades())
                {
                    try
                    {
                        int i = 0;
                        foreach (var inf in ReunionesListado)
                        {
                            if (inf.aprobacionreunion != "P") //si el informe no quedo como pendiente, quiere decir que esta aprobado o rechazado
                            {
                                var x = db.reuniones.Find(inf.idreunion);
                                x.usuidusuario = currentUsuario.idusuario;
                                x.aprobacionreunion = inf.aprobacionreunion;
                                x.fechaaprobacionreunion = DateTime.Now.ToShortDateString();
                                db.Entry(x).State = EntityState.Modified;
                                db.SaveChanges();
                                i++;
                            }
                        }
                        if (i > 0)
                        {
                            //MessageBox.Show(i + " Registros fueron actualizados éxitosamente", "Modificacion éxitosa", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo( i + " Registros fueron actualizados éxitosamente", "Modificacion éxitosa", 1);
                            i = 0;
                        }
                        else 
                        {
                            await AvisaYCerrateVosSolo("Atencion, no se guardo nada.", "Modificacion fallida", 1);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al guardar las aprobaciones de los informes de reuniones.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este problema. "+ex.InnerException, "Imposible guardar", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                } FinalizarAction();

                #endregion
            }
            //else if (!AccionConsultar)
            //{
            //    #region v

            //    #endregion
            //}

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