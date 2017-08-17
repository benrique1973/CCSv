using CapaDatos;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
namespace SGPTmvvm.Modales
{
    public class CRUDfirmaReunioneViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();

        public List<cliente> ClientesListado { get; set; }
        public List<usuariospersonas> ListadoUsuarios { get; set; }//= new List<usuariospersonas>();
        public List<contacto> ListadoContactos { get; set; }

        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        //#region Message y currentUsuario
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

        #endregion

        DialogCoordinator dlg;
        public CRUDfirmaReunioneViewModel(FirmaReunionesMensajeModal msg)
        {
            dlg = new DialogCoordinator();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-SV");
            _canExecute = true;
            this.EscuchandoALaVista(msg);
            //dlg = new DialogCoordinator();//dlgIn;

        }
        private bool _canExecute;
        public System.Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(FirmaReunionesMensajeModal Mensajito)
        {
            currentUsuario = Mensajito.UsuarioValidado;
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    EditarReunion(Mensajito); break;
                case TipoComando.Consultar:
                    ConsultarReunion(Mensajito);
                    break;
                case TipoComando.Nuevo:
                    NuevoInformeTiempo(); break;
                default: break;
            }
        }
        #region Campos

        private int _idreunion;
        private string _idnitcliente;
        private DateTime _fechareunion =DateTime.Now;
        private string _tiempoHduracionreunion;
        private string _tiempoMduracionreunion;
        private string _participanteexternoreunion;
        private string _participantesinternoreunion;
        private string _asuntoreunion;
        private string _conclusionesreunion;
        private string _aprobacionreunion;
        private string _estadoreunion;


        public int Idreunion { get { return _idreunion; } set { _idreunion = value; RaisePropertyChanged("Idreunion"); } }
        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public DateTime Fechareunion { get { return _fechareunion; } set { _fechareunion = value; RaisePropertyChanged("Fechareunion"); } }
        public string TiempoHduracionreunion { get { return _tiempoHduracionreunion; } set { _tiempoHduracionreunion = value; RaisePropertyChanged("TiempoHduracionreunion"); } }
        public string TiempoMduracionreunion { get { return _tiempoMduracionreunion; } set { _tiempoMduracionreunion = value; RaisePropertyChanged("TiempoMduracionreunion"); } }
        public string Participanteexternoreunion { get { return _participanteexternoreunion; } set { _participanteexternoreunion = value; RaisePropertyChanged("Participanteexternoreunion"); } }
        public string Participantesinternoreunion { get { return _participantesinternoreunion; } set { _participantesinternoreunion = value; RaisePropertyChanged("Participantesinternoreunion"); } }
        public string Asuntoreunion { get { return _asuntoreunion; } set { _asuntoreunion = value; RaisePropertyChanged("Asuntoreunion"); } }
        public string Conclusionesreunion { get { return _conclusionesreunion; } set { _conclusionesreunion = value; RaisePropertyChanged("Conclusionesreunion"); } }
        public string Aprobacionreunion { get { return _aprobacionreunion; } set { _aprobacionreunion = value; RaisePropertyChanged("Aprobacionreunion"); } }
        public string Estadoreunion { get { return _estadoreunion; } set { _estadoreunion = value; RaisePropertyChanged("Estadoreunion"); } }


        #endregion

        #region Bindiados

        private string _txtBandera = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }

        private bool _HabilitarComboPartExt=false;
        public bool HabilitarComboPartExt //Habilitar el combobox de los participantes externos. Se activaran hasta que halla un cliente seleccionado
        {
            get { return _HabilitarComboPartExt; }
            set 
            { 
                _HabilitarComboPartExt = value;
                RaisePropertyChanged("HabilitarComboPartExt");
            }
        }
        
        private usuariospersonas _selectedUsuarioFirma;
        public usuariospersonas SelectedUsuarioFirma
        {
            get { return _selectedUsuarioFirma; }
            set
            {
                _selectedUsuarioFirma = value;
                RaisePropertyChanged("SelectedUsuarioInforme");
            }
        }

        private cliente _selectedCliente;
        public cliente SelectedCliente
        {
            get { return _selectedCliente; }
            set
            {
                _selectedCliente = value;
                RaisePropertyChanged("SelectedCliente");
                this.clienteSeleccionado();
                //RaisePropertyChanged("ListadoParticExternos");
            }
        }


        //Prueba para ver si puedo seleccionar multiples objetos en un combobox. Ok. funcional
        public List<DiccioGenericTipoLista> ListadoParticipantesInternos { get; set; }
        public List<DiccioGenericTipoLista> ListadoParticipantesExternos{ get; set; }

        
        #endregion

        public void clienteSeleccionado()
        {
            HabilitarComboPartExt = true;
            ListadoContactos = new List<contacto>();
            using (db = new SGPTEntidades())
            {
                ListadoContactos = (from c in db.contactos 
                                    join e in db.estructurasorganicas
                                    on c.idcargoeo equals e.idcargoeo 
                                    join cl in db.clientes 
                                    on e.idnitcliente equals cl.idnitcliente 
                                    where cl.idnitcliente==SelectedCliente.idnitcliente && c.estadocontacto=="A"
                                    select c).ToList(); 

                ListadoParticipantesExternos = new List<DiccioGenericTipoLista>();
                foreach (var a in ListadoContactos)
                {
                    DiccioGenericTipoLista di = new DiccioGenericTipoLista();
                    di.id = a.idcontacto;
                    di.descripcion = a.nombrescontacto+" "+a.apellidoscontacto;
                    ListadoParticipantesExternos.Add(di);
                }
                RaisePropertyChanged("ListadoParticipantesExternos");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

        /****************************************************************************************************************/
        public void inicializarListados()
        {
            Mouse.OverrideCursor=Cursors.Wait;
            using (db = new SGPTEntidades())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                //Fechainicialdt = DateTime.Now;
                //Fechafinaldt = DateTime.Now;
                
                try
                {
                    #region +
		            ClientesListado = (from c in db.clientes where c.estadocliente == "A" orderby c.razonsocialcliente select c).ToList();
                    RaisePropertyChanged("ClientesListado");

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


                    ListadoParticipantesInternos = new List<DiccioGenericTipoLista>();
                    //DiccioGenericTipoLista dii = new DiccioGenericTipoLista();
                    //dii.id = 0;
                    //dii.descripcion = "Todos";
                    //ListadoParticipantesInternos.Add(dii);
                    foreach (var a in ListadoUsuarios)
                    {
                        DiccioGenericTipoLista di = new DiccioGenericTipoLista();
                        di.id = a.idusuario;
                        di.descripcion = a.nombreCompleto;
                        ListadoParticipantesInternos.Add(di);
                        //ListadoParticipantesInternos.Add(a.nombreCompleto, a.idusuario);
                    }
                    //ListadoParticipantesInternos[2].esSeleccionado = true;
                    //ListadoParticipantesInternos[3].esSeleccionado = true;
                    RaisePropertyChanged("ListadoParticipantesInternos"); 
	#endregion
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error desconocido al iniciar listados "+e.InnerException);
                }
            }
            Mouse.OverrideCursor=null;
        }

        private void NuevoInformeTiempo()
        {
            this.inicializarListados();
            //SelectedUsuarioFirma = ListadoUsuarios.Find(x => x.idusuario == currentUsuario.idusuario);
            //TipoCorrespondencia = ListaBotonesTipoCorrespondencia.cEntrante;
            //Fecharecepcioncorrespondencia = DateTime.Now;
            txtBandera = "1";
            AccionGuardar = true;
            AccionConsultar = false;

            Message = "Nueva reunion";
        }
        private void EditarReunion(FirmaReunionesMensajeModal Mensajito)
        {
            txtBandera = "1";
            AccionGuardar = false;
            AccionConsultar = false;
            this.inicializarListados();
            //CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            Message = "Editar reuniones";
            this.campartidaEditarConsultar(Mensajito);
        }

        private void ConsultarReunion(FirmaReunionesMensajeModal Mensajito)
        {
            this.inicializarListados();
            txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            Message = "Consultar reuniones";
            this.campartidaEditarConsultar(Mensajito);
        }

        private void campartidaEditarConsultar(FirmaReunionesMensajeModal Mensajito)
        {
            try
            {
                ReunionesModelo r = Mensajito.ReunionesAmodificar;
                Idreunion = r.idreunion;
                Fechareunion = DateTime.Parse(r.fechareunion);
                SelectedCliente = ClientesListado.Find(z => z.idnitcliente == r.idnitcliente);

                decimal dd = Math.Floor(r.tiempoduracionreunion);
                decimal df = Math.Floor((r.tiempoduracionreunion - dd) * 60);
                TiempoHduracionreunion = dd.ToString();
                TiempoMduracionreunion = df.ToString();
                string[] partInternos = r.participantesinternoreunion.Split(',');
                string[] partExternos = r.participanteexternoreunion.Split(',');
                if (partInternos.Length > 0)
                {
                    foreach (var a in partInternos)
                    {
                        if (a.Length>1)
                        {
                            var f = ListadoParticipantesInternos.Find(s => s.descripcion == a.Trim());
                            if (f != null) f.esSeleccionado = true;
                            //foreach (var t in ListadoParticipantesInternos)
                            //{
                            //    var f = ListadoParticipantesInternos.Find(s => s.descripcion == a.Trim());
                            //    bool tu = t.descripcion.Equals(a.Trim(), StringComparison.OrdinalIgnoreCase);
                            //    if(tu)
                            //     t.esSeleccionado = true;  
                            //}
                        }
                    }
                }

                if (partExternos.Length > 0)
                {
                    foreach (var z in partExternos)
                    {
                        if (z.Length > 1)
                        {
                            var g = ListadoParticipantesExternos.Find(t => t.descripcion == z.Trim());
                            if (g != null) g.esSeleccionado = true;
                        //    foreach (var t in ListadoParticipantesExternos)
                        //    {
                        //        var f = ListadoParticipantesExternos.Find(s => s.descripcion == z.Trim());
                        //        bool tv = t.descripcion.Equals(z, StringComparison.OrdinalIgnoreCase);
                        //        if (tv)
                        //            t.esSeleccionado = true;
                        //    }
                        }
                    }
                }

                Asuntoreunion = r.asuntoreunion;
                Conclusionesreunion = r.conclusionesreunion;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al recuperar los datos de las reuniones. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error. "+e.InnerException, "Error de compatibilidad de datos");
            }
        }

        private async void cmdCancelar()
        {
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada",1);
            this.FinalizarAction();
        }

        private async void activarBarra()
        {
            ////DejarseVer = Visibility.Visible;
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
            if (ValidacionManualOk())
            {
                #region v
                reunione reunion = new reunione();
                using (db = new SGPTEntidades())
                {
                    if (AccionGuardar)
                        reunion = new reunione();
                    else //es editar
                        reunion = db.reuniones.Find(Idreunion);
                }
                //reunion.idreunion = 1000;//Idreunion;
                reunion.idnitcliente=SelectedCliente.idnitcliente;
                reunion.fechareunion=Fechareunion.ToShortDateString();
                decimal tiempohdur=0;
                decimal tiempomdur=0;
                if(!string.IsNullOrEmpty(TiempoHduracionreunion))
                    tiempohdur=Convert.ToDecimal(TiempoHduracionreunion);
                if(!string.IsNullOrEmpty(TiempoMduracionreunion))
                    tiempomdur=Math.Round(((Convert.ToDecimal(TiempoMduracionreunion))/60),3);

                reunion.tiempoduracionreunion = tiempohdur + tiempomdur;

                reunion.participanteexternoreunion = "";
                foreach (var a in ListadoParticipantesExternos)
                {
                    if(a.esSeleccionado)
                    reunion.participanteexternoreunion += (", "+a.descripcion);
                }

                reunion.participantesinternoreunion = "";
                foreach (var b in ListadoParticipantesInternos)
                {
                    if(b.esSeleccionado)
                    reunion.participantesinternoreunion += (", " + b.descripcion);
                }

                reunion.asuntoreunion = Asuntoreunion;
                reunion.conclusionesreunion = Conclusionesreunion;
                reunion.aprobacionreunion = "P";
                reunion.estadoreunion = "A";

                if (AccionGuardar)
                {
                    #region v
                    //corresp.idcorrespondencia = 1000;

                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            reunion.idreunion = 100000;
                            db.reuniones.Add(reunion);
                            db.SaveChanges();

                           await AvisaYCerrateVosSolo("El registro se guardo con éxito.", "Finalizado.", 2);
                            #endregion
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar en reuniones.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. "+e.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                        #endregion
                    }
                    FinalizarAction();

                    #endregion
                }
                else if (!AccionConsultar)
                {
                    #region v

                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            db.Entry(reunion).State = EntityState.Modified; db.SaveChanges();
                            await AvisaYCerrateVosSolo("Los cambios se guardaron con éxito.", "Finalizado.", 1);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar los cambios en reuniones.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico. "+e.InnerException, "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                            this.cmdCancelar();
                        }
                        #endregion
                    }
                    this.FinalizarAction();
                    #endregion
                }

                #endregion
            }

            else { await AvisaYCerrateVosSolo("Se ha detectado que existe falta de informacion.\n a) Verifique que ha seleccionado al menos dos participantes Internos. \n b) Verifique que el tiempo de la reunion sea de por lo menos 10 minutos y maximo 8 horas", "Falta informacion",3); }
        }


        private bool ValidacionManualOk()
        {
            int j = 0;
            foreach (var i in ListadoParticipantesInternos)
            {
                if (i.esSeleccionado)
                    j++;
            }

            bool tiempoMinutosOk = false; //verifica que el tiempo minimo de la reunion sea de 10 minutos
            if (!String.IsNullOrEmpty(TiempoHduracionreunion))
                tiempoMinutosOk = true;

            if (String.IsNullOrEmpty(TiempoHduracionreunion) && !String.IsNullOrEmpty(TiempoMduracionreunion))
                if (int.Parse(TiempoMduracionreunion) >= 10)
                    tiempoMinutosOk = true;


            if (!String.IsNullOrEmpty(TiempoHduracionreunion) || !String.IsNullOrEmpty(TiempoMduracionreunion) && tiempoMinutosOk)
            if (j > 1)
                return true;
                return false;
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
