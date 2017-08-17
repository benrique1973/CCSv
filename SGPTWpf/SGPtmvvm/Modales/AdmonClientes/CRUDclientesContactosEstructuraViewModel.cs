using CapaDatos;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTWpf.SGPtmvvm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace SGPTmvvm.Modales.AdmonClientes
{

    public class CRUDclientesContactosEstructuraViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<DiccioGenericTipoLista> otrasFuncionesListad { get; set; }
        public List<estructurasorganica> estructuraOListado { get; set; }

        public List<cliente> ClientesListado { get; set; }
       // public List<usuariospersonas> ListadoUsuarios { get; set; }//= new List<usuariospersonas>();


        private DialogCoordinator dlg;



        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        #region Message y currentUsuario
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }
        #region ViewModel Property : currentUsuario usuario

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

        private cliente _currentCliente;

        public cliente currentCliente
        {
            get
            {
                return _currentCliente;
            }

            set
            {
                if (_currentCliente == value) return;

                _currentCliente = value;

                RaisePropertyChanged("currentCliente");
            }
        }

        #endregion
        #endregion
        //public CRUDfirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg, DialogCoordinator dlgIn)
        public CRUDclientesContactosEstructuraViewModel(ClientesContactosMensajeModal msg)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            _canExecute = true;
            currentUsuario = msg.UsuarioValidado;
            currentCliente = msg.currentCliente;
            this.inicializarListados();
            this.EscuchandoALaVista(msg);
            dlg = new DialogCoordinator();//dlgIn;

        }

        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(ClientesContactosMensajeModal Mensajito)
        {
            //currentUsuario = Mensajito.UsuarioValidado;
            //currentCliente = Mensajito.currentCliente;
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    Editar(Mensajito); break;
                case TipoComando.Consultar:
                    Consultar(Mensajito);
                    break;
                case TipoComando.Nuevo:
                    NuevoInformeTiempo(); break;
                default: break;
            }

        }


        #region Campos
        private int     _idcargoeo;
        private int     _estidcargoeo;
        private string _idnitcliente ;
        private string _nombrecargoeo;
        private string _responsabilidadeo ;
        private string _funcionadicionaleo;
        private string _estadoeo;

        public int Idcargoeo { get { return _idcargoeo; } set { _idcargoeo = value; RaisePropertyChanged("Idcargoeo"); } }
        public int Estidcargoeo { get { return _estidcargoeo; } set { _estidcargoeo = value; RaisePropertyChanged("Estidcargoeo"); } }
        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public string Nombrecargoeo { get { return _nombrecargoeo; } set { _nombrecargoeo = value; RaisePropertyChanged("Nombrecargoeo"); } }
        public string Responsabilidadeo { get { return _responsabilidadeo; } set { _responsabilidadeo = value; RaisePropertyChanged("Responsabilidadeo"); } }
        public string Funcionadicionaleo { get { return _funcionadicionaleo; } set { _funcionadicionaleo = value; RaisePropertyChanged("Funcionadicionaleo"); } }
        public string Estadoeo { get { return _estadoeo; } set { _estadoeo = value; RaisePropertyChanged("Estadoeo"); } }
        

       
        #endregion

        #region Bindiados

        private string _txtBandera = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }

        private estructurasorganica _selectedEstructuraO;
        public estructurasorganica SelectedEstructuraO
        {
            get { return _selectedEstructuraO; }
            set
            {
                _selectedEstructuraO = value;
                RaisePropertyChanged("SelectedEstructuraO");
            }
        }


        private void activarbotonguardar()
        {
            if (AccionConsultar == false && AccionGuardar == false) { txtBandera = "1"; RaisePropertyChanged("txtBandera"); }
        }

        #endregion

        #region Activadores

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


        public void inicializarListados()
        {
            using (db = new SGPTEntidades())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                try
                {
                    estructuraOListado = (from e in db.estructurasorganicas where e.idnitcliente==currentCliente.idnitcliente && e.estadoeo == "A" orderby e.nombrecargoeo select e).ToList();
                    RaisePropertyChanged("estructuraOListado");
                    otrasFuncionesListad = new List<DiccioGenericTipoLista>();
                    DiccioGenericTipoLista o = new DiccioGenericTipoLista();
                    o.id = 1;
                    o.descripcion = "Representante legal";
                    otrasFuncionesListad.Add(o);
                    o = new DiccioGenericTipoLista();
                    o.id = 2;
                    o.descripcion = "Miembro junta directiva";
                    otrasFuncionesListad.Add(o);
                    o = new DiccioGenericTipoLista();
                    o.id = 3;
                    o.descripcion = "Accionista";
                    otrasFuncionesListad.Add(o);
                    o = new DiccioGenericTipoLista();
                    o.id = 4;
                    o.descripcion = "Empleado";
                    otrasFuncionesListad.Add(o);
                    o = new DiccioGenericTipoLista();
                    o.id = 5;
                    o.descripcion = "Otros cargos";
                    otrasFuncionesListad.Add(o);

                    RaisePropertyChanged("otrasFuncionesListad");

                    RaisePropertyChanged();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los datos de la estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nSi el problema continua de aviso a soporte tecnico.");
                }
            }

            RaisePropertyChanged("");
        }
        
        private async void EjecutarMensaje() /// Esta prueba es para experimentar si se puede emitir mensajes mahajaksd
        {
            var x = await dlg.ShowMessageAsync(this, "Mensaje para el viewmodel", "Prueba Eliezer", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings
            {
                AffirmativeButtonText = "Aceptar",
                NegativeButtonText = "CANCELAR",
                AnimateShow = true,
                AnimateHide = false
            });

        }
        private void NuevoInformeTiempo()
        {
            this.inicializarListados();
            txtBandera = "1";
            AccionGuardar = true;
            AccionConsultar = false;



            Message = "Nuevo puesto de estructura organica";
        }
        private void Editar(ClientesContactosMensajeModal Mensajito)
        {
            txtBandera = "1";
            AccionGuardar = false;
            AccionConsultar = false;
            
            //CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            Message = "Editar cargo estructura organica";
            this.compartidaEditarConsultar(Mensajito);
        }
        private void compartidaEditarConsultar(ClientesContactosMensajeModal Mensajito)
        {
            this.inicializarListados();
            estructurasorganica est = Mensajito.EstructuraAmodificar;
            try
            {
                #region -
                Idcargoeo = est.idcargoeo;
                //Estidcargoeo = (int)est.estidcargoeo;
                SelectedEstructuraO = estructuraOListado.Find(x => x.idcargoeo == est.estidcargoeo);
                Idnitcliente = est.idnitcliente;
                Nombrecargoeo = est.nombrecargoeo;
                Responsabilidadeo = est.responsabilidadeo;
                //Funcionadicionaleo = est.funcionadicionaleo;
                if (!string.IsNullOrEmpty(est.funcionadicionaleo))
                {
                    string[] oFunc = est.funcionadicionaleo.Split(','); //r.participanteexternoreunion.Split(',');
                    if (oFunc.Length > 0)
                    {
                        foreach (var a in oFunc)
                        {
                            if (a.Length > 1)
                            {
                                var f = otrasFuncionesListad.Find(s => s.descripcion == a.Trim());
                                if (f != null) f.esSeleccionado = true;
                            }
                        }
                    }
                }
                RaisePropertyChanged("otrasFuncionesListad");
                //Estadoeo = "A";
                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al recuperar los datos de la correspondencia. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error.", "Error de compatibilidad");
            }
        }
        private void Consultar(ClientesContactosMensajeModal Mensajito)
        {
            //this.inicializarListados();
            txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            //CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            Message = "Consultar cargo estructura organica";
            this.compartidaEditarConsultar(Mensajito);
        }

        private void cmdCancelar()
        {
            AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada por usted",2);
            this.FinalizarAction();
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
                #region v
                estructurasorganica est = new estructurasorganica();
                using (db = new SGPTEntidades())
                {
                    if (AccionGuardar) { est = new estructurasorganica(); }
                    else
                    {
                        est = db.estructurasorganicas.Find(Idcargoeo);
                    }
                }
                //est.idcargoeo = 1000;
                Funcionadicionaleo = "";
                foreach (var a in otrasFuncionesListad)
                {
                    if(a.esSeleccionado)
                    Funcionadicionaleo += a.descripcion + ",";
                }
                if(SelectedEstructuraO!=null)
                    est.estidcargoeo = SelectedEstructuraO.idcargoeo;
                est.idnitcliente = currentCliente.idnitcliente;
                est.nombrecargoeo = Nombrecargoeo;
                est.responsabilidadeo = Responsabilidadeo;
                est.funcionadicionaleo = Funcionadicionaleo;
                est.estadoeo = "A";
                if (AccionGuardar)
                {
                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            est.idcargoeo = 10000;
                            //est.estidcargoeo = 1;//Estidcargoeo;
                            //est.idnitcliente = "0615-011255-144-1";
                            //est.nombrecargoeo = "prueba";
                            //est.responsabilidadeo = "asdfafd";
                            //est.funcionadicionaleo = "R";
                            //est.estadoeo = "A";
                            db.estructurasorganicas.Add(est);
                            db.SaveChanges();

                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            AvisaYCerrateVosSolo("El registro se guardo con éxito.", "Finalizado.", 2);

                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al guardar en estructura organica.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. "+ex.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                        #endregion
                    }
                    FinalizarAction();
                }
                else if (!AccionConsultar)
                {
                    #region v

                    using (db = new SGPTEntidades())
                    {

                        #region _
                        try
                        {
                            db.Entry(est).State = EntityState.Modified; db.SaveChanges();
                            //MessageBox.Show("Los cambios se guardaron con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            AvisaYCerrateVosSolo("Los cambios se guardaron con éxito.", "Finalizado.", 2);
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show("Ocurrio un error al guardar los cambios en estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico.", "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                            AvisaYCerrateVosSolo("Ocurrio un error al guardar los cambios en estructura organica del cliente"+Environment.NewLine+"La base de datos tardo demasiado en responder"+Environment.NewLine+"Si el problema continua, informe a soporte tecnico.", "Error al intentar guardar.", 2);
                            this.cmdCancelar();
                        }
                        #endregion

                    }
                    this.FinalizarAction();
                    #endregion
                }

                #endregion
            }
        }


        private bool ValidacionManualOk()
        {
            return true;
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

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }
    }
}