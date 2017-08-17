using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTmvvm.Modales.AdmonClientes
{

    public class AsigPersClientesEncargosCronogramaViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<AsignacionesModelo> ListadoAuditoresDisponibles { get; set; }
        public List<AsignacionesModelo> ListadoAuditoresSeleccionados { get; set; }
        public List<AsignacionesModelo> ListadoAuditoresSeleccionados2 { get; set; }
        //public List<DiccioGenericTipoLista> otrasFuncionesListad { get; set; }
        //public List<estructurasorganica> estructuraOListado { get; set; }

        //public List<cliente> ClientesListado { get; set; }
       // public List<usuariospersonas> ListadoUsuarios { get; set; }//= new List<usuariospersonas>();


        private DialogCoordinator dlg;



        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        #region Message y currentUsuario
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }
        

        #endregion
        //public CRUDfirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg, DialogCoordinator dlgIn)
        public AsigPersClientesEncargosCronogramaViewModel(ClientesEncargosCronogramaMensajeModal msg)
        {
            dlg = new DialogCoordinator();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            _canExecute = true;
            //currentUsuario = msg.UsuarioValidado;
            //currentCliente = msg.currentCliente;
            //this.inicializarListados();
            this.EscuchandoALaVista(msg);
            //dlg = new DialogCoordinator();//dlgIn;

        }

        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(ClientesEncargosCronogramaMensajeModal Mensajito)
        {

            Message = "Etapa: "+Mensajito.nombreEtapa+" -*- Visita: "+Mensajito.nombreVisita;
            ListadoAuditoresSeleccionados2 = new List<AsignacionesModelo>();
            ListadoAuditoresDisponibles = new List<AsignacionesModelo>();
            ListadoAuditoresDisponibles = Mensajito.ListadoPersonalAsignado;
            RaisePropertyChanged("ListadoAuditoresDisponibles");
            //switch (Mensajito.Accion)
            //{
                //case TipoComando.Editar:
                //    Editar(Mensajito); break;
                //case TipoComando.Consultar:
                //    Consultar(Mensajito);
                //    break;
                //case TipoComando.Nuevo:
                //    NuevoInformeTiempo(); break;
                //default: break;
            //}

        }


        #region Bindiados

        private string _txtBandera = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }

        private AsignacionesModelo _SelectedAuditorDisponible;
        public AsignacionesModelo SelectedAuditorDisponible
        {
            get { return _SelectedAuditorDisponible; }
            set
            {
                _SelectedAuditorDisponible = value;
                RaisePropertyChanged("SelectedAuditorDisponible");
                this.cargarSusValores();
            }
        }

        private void cargarSusValores()
        {
            if (SelectedAuditorDisponible!=null)
            {
                //this.HorasAsignadas = (int)(SelectedAuditorDisponible.horasplanasignacion);
                this.CostoPorHora = SelectedAuditorDisponible.preciohoraasignacion.ToString();  
            }
        }


        private int _HorasAsignadas;
        public int HorasAsignadas
        {
            get { return _HorasAsignadas; }
            set
            {
                _HorasAsignadas = value;
                RaisePropertyChanged("HorasAsignadas");
            }
        }

        private string _CostoPorHora;
        public string CostoPorHora
        {
            get { return _CostoPorHora; }
            set
            {
                _CostoPorHora = value;
                RaisePropertyChanged("CostoPorHora");
            }
        }


        //Datagrid
        private AsignacionesModelo _SelectedPersonalAsignado;
        public AsignacionesModelo SelectedPersonalAsignado
        {
            get { return _SelectedPersonalAsignado; }
            set
            {
                _SelectedPersonalAsignado = value;
                RaisePropertyChanged("SelectedPersonalAsignado");
            }
        }

        //private void activarbotonguardar()
        //{
        //    if (AccionConsultar == false && AccionGuardar == false) { txtBandera = "1"; RaisePropertyChanged("txtBandera"); }
        //}

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

        //cmdAgregar_Click
        private ICommand _cmdAgregar_Click;
        public ICommand cmdAgregar_Click
        {
            get
            {
                return _cmdAgregar_Click ?? (_cmdAgregar_Click = new CommandHandler(() => cmdAgregar(), _canExecute));
            }
        }

        private void cmdAgregar()
        {
            if (NoEstaAsignadoElAuditor())
            {
                ListadoAuditoresSeleccionados = new List<AsignacionesModelo>();
                AsignacionesModelo asi = new AsignacionesModelo();
                asi.idusuario = SelectedAuditorDisponible.idusuario;
                asi.nombreCompletoUsuario = SelectedAuditorDisponible.nombreCompletoUsuario;
                asi.rolUsuario = SelectedAuditorDisponible.rolUsuario;
                asi.horasplanasignacion = HorasAsignadas;
                //var dd = Decimal.Parse(CostoPorHora);//Convert.ToDecimal(CostoPorHora);
                //var cc = Decimal.Parse(CostoPorHora, CultureInfo.InvariantCulture);
                //var asd = Math.Round(dd,2);
                asi.preciohoraasignacion = Math.Round(Decimal.Parse(CostoPorHora, CultureInfo.InvariantCulture), 2);
                asi.UssPlaneado = HorasAsignadas * Math.Round((Decimal.Parse(CostoPorHora, CultureInfo.InvariantCulture)), 2);
                ListadoAuditoresSeleccionados2.Add(asi);
                foreach (var a in ListadoAuditoresSeleccionados2)
                {
                    ListadoAuditoresSeleccionados.Add(a);
                }
                RaisePropertyChanged("ListadoAuditoresSeleccionados");

                if (ListadoAuditoresSeleccionados.Count() > 0)
                    txtBandera = "1";
                else
                    txtBandera = "0";
                SelectedAuditorDisponible = null;
                HorasAsignadas = 0;
                CostoPorHora = ""; 
            }
        }

        private bool NoEstaAsignadoElAuditor()
        {
            var si = ListadoAuditoresSeleccionados2.Find(x => x.idusuario == SelectedAuditorDisponible.idusuario);
            if (si == null)
                return true;
            else
            {
                AvisaYCerrateVosSolo("El auditor: [ " + si.nombreCompletoUsuario + " ] ya fue asignado y agregado al listado.", "Seleccione otro auditor", 2);
                return false;
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
                return _cmdGuardar_Click ?? (_cmdGuardar_Click = new CommandHandler(() => this.cmdGuardar(), _canExecute));
            }
        }


        public void inicializarListados()
        {
            using (db = new SGPTEntidades())
            {

                try
                {
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los datos de la estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nSi el problema continua de aviso a soporte tecnico.");
                }
            }

            RaisePropertyChanged("");
        }
        

        //private void NuevoInformeTiempo()
        //{
        //    this.inicializarListados();
        //    txtBandera = "1";
        //    AccionGuardar = true;
        //    AccionConsultar = false;

        //    Message = "Nuevo puesto de estructura organica";
        //}



        private void cmdCancelar()
        {
            AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada", 2);
            this.FinalizarAction();
            ClientesEncargosCronogramaMensajeModal mensajito = new ClientesEncargosCronogramaMensajeModal(); mensajito.HayAgregadosSioNo = false;
            Messenger.Default.Send<ClientesEncargosCronogramaMensajeModal>(mensajito);


        }

        //private void activarBarra()
        //{
        //    //DejarseVer = Visibility.Visible;
        //    RaisePropertyChanged();
        //    MessageBoxResult Guarde = MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        //    switch (Guarde)
        //    {
        //        case MessageBoxResult.Yes: this.cmdGuardar(); break;
        //        case MessageBoxResult.No: MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
        //        case MessageBoxResult.Cancel: this.cmdCancelar(); break;
        //    }

        //}
        private async void activarBarra()
        {
            #region +
            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Si",
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
                AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 2);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }
            #endregion
        }

        private void cmdGuardar()
        {//***********************************************************************************************************
            if (ValidacionManualOk())
            {
                if (ListadoAuditoresSeleccionados.Count > 0)
                {
                    this.FinalizarAction();
                    ClientesEncargosCronogramaMensajeModal mensajito = new ClientesEncargosCronogramaMensajeModal(); mensajito.ListadoPersonalSeleccionado = ListadoAuditoresSeleccionados; mensajito.HayAgregadosSioNo = true;
                    Messenger.Default.Send<ClientesEncargosCronogramaMensajeModal>(mensajito);
                }
                else
                {
                    //MessageBox.Show("No hay nada que guardar.\nSeleccione los auditores a asignar a esta etapa.","Sin auditores seleccionados",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                    AvisaYCerrateVosSolo("No hay nada que guardar.\nSeleccione los auditores a asignar a esta etapa.", "Sin auditores seleccionados", 2);
                }
            }
        }


        private bool ValidacionManualOk()
        {
            if(ListadoAuditoresSeleccionados.Count>0)
            return true;
            return false;
        }

        private async void AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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