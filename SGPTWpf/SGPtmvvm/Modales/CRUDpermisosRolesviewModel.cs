using CapaDatos;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using SGPTWpf.SGPtmvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace SGPTmvvm.Modales
{
    public class CRUDpermisosRolesviewModel : INotifyPropertyChanged
    {
        private DialogCoordinator dlg;
        public SGPTEntidades db = new SGPTEntidades();
        public ICollectionView permisitosRolesView { get; set; }


        public ObservableCollection<permisosrolesusuario> PermisosRolesUsuarioss = new ObservableCollection<permisosrolesusuario>();

        public List<permisosrolesusuario> PermisosQueSufrieronCambios { get; set; } //Aqui registro los permisos que sufrieron modificaciones, para luego notificar al socio.

        public ObservableCollection<PermisosRolesUsuariosVM> permisosRolesUsuarios { get; set; }
        public List<permisosRolesModelo> permisosRolesUsuariosv { get; set; }

        public List<permisosrolesusuario> PermisosRolesUsuarios { get; set; }
        //public CollectionView <permisosrolesusuario> aa = new CollectionView<permisosrolesusuario>());

        List<permisosrolesusuario> permisosActuales = new List<permisosrolesusuario>(); //permisos actuales de la base antes de la modificacion.
        public int CantidadRegistrosActualizados = 0;
        public CRUDpermisosRolesviewModel(PermisosRolesMensajeModal msg)
        {
            dlg = new DialogCoordinator();
            _canExecute = true;
            CurrentUsuario = msg.currentUsuario;
            this.EscuchandoALaVista(msg);
        }
        #region v

        //valorBarrita
        #endregion
        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(PermisosRolesMensajeModal Mensajito)
        {
            //BarraProgresoVisible = Visibility.Collapsed;
            //RaisePropertyChanged("BarraProgresoVisible");
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar: EditarRolUsuario(Mensajito); break;
                default: break;
            }
            
        }


        #region currentUsuario
        private usuario _currentUsuario;

        public usuario CurrentUsuario
        {
            get
            {
                return _currentUsuario;
            }

            set
            {
                if (_currentUsuario == value) 
                    return;

                _currentUsuario = value;
                RaisePropertyChanged("CurrentUsuario");
            }
        }
        #endregion


        #region Campos
        private string _idduipersona;
        private int _idusuario;
        private int _idrol;
        private string _nombrespersona;
        private string _apellidospersona;
        private string _rol;
        public string Idduipersona { get { return _idduipersona; } set { _idduipersona = value; RaisePropertyChanged("Idduipersona"); } }
        public int IdUsuario { get { return _idusuario; } set { _idusuario = value; RaisePropertyChanged("IdUsuario"); } }
        public int IdRol { get { return _idrol; } set { _idrol = value; RaisePropertyChanged("IdRol"); } }
        public string Nombrespersona { get { return _nombrespersona; } set { _nombrespersona = value; RaisePropertyChanged("Nombrespersona"); } }
        public string Apellidospersona { get { return _apellidospersona; } set { _apellidospersona = value; RaisePropertyChanged("Apellidospersona"); } }
        public string Rol { get { return _rol; } set { _rol = value; RaisePropertyChanged("Rol"); } }
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

        #region pruebaParaBarraProgreso
        /*******************************************************Inicio Barra Progreso*********************************/


        private Visibility _DejarseVer;
        public Visibility DejarseVer
        {
            get { return _DejarseVer; }
            set
            {
                _DejarseVer = value;
                RaisePropertyChanged();
            }
        }

        private int _ValorDejarseVer; //valor de la barra progreso. normalmente entre [0 y 100]
        public int ValorDejarseVer
        {
            get { return _ValorDejarseVer; }
            set
            {
                _ValorDejarseVer = value;
                RaisePropertyChanged();
            }
        }

        private string _valorProgresoTextBox; //Leyenda del avance en porcentaje o el proceso que se ejecuta
        public string valorProgresoTextBox
        {
            get { return _valorProgresoTextBox; }
            set { _valorProgresoTextBox = value; RaisePropertyChanged(); }
        }
        /**************************************Fin Manejar Barra Progreso*****************************************************/
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

        private void EditarRolUsuario(PermisosRolesMensajeModal Mensajito)
        {


            //Aqui tengo que destapar el mensajito, y extraer el usuario. Luego tengo que hacer una consulta a la tabla permisos roles usuarios para extraer los permisos de el.

            usuariospersonas usua = Mensajito.rolesAmodificar.TheUsuariosPersonas;
            Idduipersona = usua.idduipersona;
            IdUsuario = usua.idusuario;
            IdRol = usua.idrol;
            Nombrespersona = usua.nombrespersona;
            Apellidospersona = usua.apellidospersona;
            Rol = usua.nombrerol;
            List<permisosrolesusuario> xPermisos = new List<permisosrolesusuario>();
            //ObservableCollection<PermisosRolesUsuariosVM> yPermisos = new ObservableCollection<PermisosRolesUsuariosVM>();

            //para v1.1
            permisosRolesModelo permisosmodelo = new permisosRolesModelo();
            using (db = new SGPTEntidades())
            {
                xPermisos = (from p in db.permisosrolesusuarios where p.idusuario == usua.idusuario && p.mostrarenmenupru==true orderby p.nombreopcionpru select p).ToList();

                //foreach (permisosrolesusuario p in xPermisos)
                //{
                //    yPermisos.Add(new PermisosRolesUsuariosVM { ThePermisosRolesUsuarios = p }); //lo agregamos a la coleccion
                //    permisosmodelo.idpru = p.idpru;
                //    permisosmodelo.idusuario = (int)p.idusuario;
                //    permisosmodelo.idrol = (int)p.idrol;
                //    //permisosmodelo.Menu = "";
                //    //permisosmodelo.nombreopcionpru = p.nombreopcionpru;
                //    //permisosmodelo.

                //}
                //permisosRolesUsuarios = yPermisos;
                //RaisePropertyChanged("PermisosRolesUsuarios");
                //RaisePropertyChanged("");

                IList<permisosrolesusuario> permisitos = xPermisos;
                permisitosRolesView = CollectionViewSource.GetDefaultView(permisitos);
                permisitosRolesView.GroupDescriptions.Clear();
                permisitosRolesView.GroupDescriptions.Add(new PropertyGroupDescription("menupru"));
                permisitosRolesView.GroupDescriptions.Add(new PropertyGroupDescription("submenupru"));
                permisitosRolesView.GroupDescriptions.Add(new PropertyGroupDescription("subsubmenupru"));

                //ListCollectionView collectionView = new ListCollectionView(permisosRolesUsuarios);// ListCollectionView(permisosrolesusuario);
                //collectionView.GroupDescriptions.Add(new PropertyGroupDescription("idusuario"));
                //mycollection.Source = permisosRolesUsuarios;
                //mycollection.GroupDescriptions.Add(new PropertyGroupDescription("PropertyToGroup"));
                //RaisePropertyChanged("mycollection");
                //dataGrid.ItemsSource = mycollection.View;

            }
        }

        private async void cmdCancelar()
        {
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.","Operacion cancelada",1);
            this.FinalizarAction();
        }

        private async void activarBarra()
        {
            DejarseVer = Visibility.Visible;
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
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 1);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.cmdCancelar();
            }

            /*OJO No borrar, puede servir para cuando se necesite proceso en segundo plano*/

            //BackgroundWorker worker = new BackgroundWorker();
            //worker.RunWorkerCompleted += worker_procesoFinalizado;
            //worker.WorkerReportsProgress = true;
            //worker.DoWork += worker_DoWork;
            //worker.ProgressChanged += worker_ProgressChanged;
            //worker.RunWorkerAsync(); 
        }

        #region Prueba de sub-Proceso en segundo plano 
        //private void worker_procesoFinalizado(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    //MessageBox.Show("Finalizado");
        //    ValorDejarseVer = 100;
        //    RaisePropertyChanged();
        //    valorProgresoTextBox = "Espere...";
        //    RaisePropertyChanged();
        //}

        //private void worker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    var worker = sender as BackgroundWorker;
        //    worker.ReportProgress(0, String.Format("Proceso Interaccion 1."));
        //    for (int i = 0; i < 100; i++)
        //    {
        //        Thread.Sleep(105);
        //        worker.ReportProgress((i + 1) * 1, String.Format(" {0} ", i + 2));
        //    }
        //    worker.ReportProgress(100, "Proceso Finalizado con éxito.");
        //}

        //private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    RaisePropertyChanged();
        //    ValorDejarseVer = e.ProgressPercentage;
        //    RaisePropertyChanged();
        //    //valorProgresoTextBox = (string)e.UserState;
        //    //RaisePropertyChanged();
        //} 
        #endregion



        private async void cmdGuardar()
        {
            if (HayInterSioNo())
            {
                #region +
                PermisosQueSufrieronCambios = new List<permisosrolesusuario>();
                permisosrolesusuario ppp = new permisosrolesusuario();
                int i = 0;
                var vpv = permisitosRolesView.Cast<permisosrolesusuario>().ToList();
                foreach (var r in vpv)
                {
                    #region +
                    i = i + 1;
                    ValorDejarseVer = i;
                    RaisePropertyChanged();
                    valorProgresoTextBox = String.Format("Comparando: {0}  registro {1}", r.nombreopcionpru, i);
                    RaisePropertyChanged();

                    ppp = r;
                    permisosrolesusuario a = await DameUnRegistro(ppp);
                    if (ppp.crearpru != a.crearpru || ppp.eliminarpru != a.eliminarpru || ppp.consultarpru != a.consultarpru
                        || ppp.editarpru != a.editarpru || ppp.impresionpru != a.impresionpru || ppp.exportacionpru != a.exportacionpru
                        || ppp.revisarpru != a.revisarpru || ppp.aprobarpru != a.aprobarpru)
                    {
                        #region +
                        a.crearpru = ppp.crearpru;
                        a.editarpru = ppp.editarpru;
                        a.revisarpru = ppp.revisarpru;
                        a.eliminarpru = ppp.eliminarpru;
                        a.impresionpru = ppp.impresionpru;
                        a.aprobarpru = ppp.aprobarpru;
                        a.consultarpru = ppp.consultarpru;
                        a.exportacionpru = ppp.exportacionpru;
                        using (db = new SGPTEntidades())
                        {
                            try
                            {
                                db.Entry(a).State = EntityState.Modified; db.SaveChanges();
                                PermisosQueSufrieronCambios.Add(a); //Aqui registro los permisos que sufrieron modificaciones, para luego notificar al socio.
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Se produjo un error al guardar. Verifique los datos modificados. Informe a Soporte tecnico para este error.  " + ex.InnerException, "Error.", MessageBoxButton.OK, MessageBoxImage.Stop);
                                this.FinalizarAction();
                            }
                        }
                        CantidadRegistrosActualizados += 1;
                        #endregion
                    }
                    #endregion
                }

                if (CantidadRegistrosActualizados > 0)
                {
                    #region +
                    ValorDejarseVer = 100;
                    RaisePropertyChanged();
                    valorProgresoTextBox = String.Format("Finalizado...  Registros actualizados: {0}", CantidadRegistrosActualizados);
                    RaisePropertyChanged("valorProgresoTextBox");
                    this.notificarAlUsuarioSocio();
                    //MessageBox.Show(CantidadRegistrosActualizados + " Registros fueron actualizaron", "Modificacion con éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    await dlg.ShowMessageAsync(this, CantidadRegistrosActualizados + " Registros fueron actualizaron", "Modificacion con éxito");
                    CantidadRegistrosActualizados = 0;

                    #endregion
                }
                else
                {
                    #region +
                    CantidadRegistrosActualizados = 0;
                    ValorDejarseVer = 100;
                    RaisePropertyChanged();
                    valorProgresoTextBox = String.Format("Finalizado. No se realizo ninguna modificacion.");
                    RaisePropertyChanged();
                    await AvisaYCerrateVosSolo("No se realizo ninguna modificacion", "Operacion fallida", 1);
                    #endregion
                }
                this.FinalizarAction();
                #endregion 
            }
            else
            {
                await AvisaYCerrateVosSolo("No es posible guardar los cambios en los permisos. Asegurese que tenga conexion a Internet","Es requisito notificar al/los socios por correo acerca de este cambio.",2);
            }
        }

        public async Task<permisosrolesusuario> DameUnRegistro(permisosrolesusuario ppp)
        {
            //Funcion que permite que permite una espera minima para que otro proceso se ejecute o notifique.. en este caso, la barra de progreso.
            using (db = new SGPTEntidades())
            {
                permisosrolesusuario a = db.permisosrolesusuarios.Where(x => x.idusuario == ppp.idusuario && x.idpru == ppp.idpru).SingleOrDefault();
                await Task.Delay(1);
                return a;
            }
        }

        private async void notificarAlUsuarioSocio()
        {
            if (HayInterSioNo())
            {
                #region +
                ValorDejarseVer = 5;
                RaisePropertyChanged();
                valorProgresoTextBox = String.Format("Notificando a los socios acerca de los cambios... La operacion puede tardar varios minutos.");
                RaisePropertyChanged("valorProgresoTextBox");
                await this.cuenteUno();
                //List<firma> ListadoFirmas = new List<firma>();
                firma ListadoFirmas = new firma();
                List<correo> ListadoCorreosSocios = new List<correo>();
                List<usuario> ListadoUsuariosSocios = new List<usuario>();
                using (db = new SGPTEntidades())
                {
                    #region +
                    ListadoFirmas = db.firmas.First(); // (from f in db.firmas select f).ToList();

                    ListadoUsuariosSocios = (from u in db.usuarios where u.idrol == 8 select u).ToList(); 
                    //Que busque todos los socios. El 8 es el ID del Socio por defecto.
                    if (ListadoUsuariosSocios != null)
                    {
                        foreach (var a in ListadoUsuariosSocios)
                        {
                            var b = (from t in db.correos where t.idduipersona == a.idduipersona && t.estadocorreo=="A" select t).ToList();
                            foreach (var c in b)
                            {
                                ListadoCorreosSocios.Add(c); //aqui van a caer todos los correos de todos los socios, a los cuales se les enviara notificacion de cambios en los permisos del usuario modificado
                            }
                        }
                    }

                    #endregion
                }
                ValorDejarseVer = 20;
                RaisePropertyChanged();
                await this.cuenteUno();

                if (ListadoFirmas != null && ListadoCorreosSocios != null)
                {
                    using (db = new SGPTEntidades())
                    {
                        #region +
                        string RazonSocial = ListadoFirmas.razonsocialfirma;// ListadoFirmas[0].razonsocialfirma;
                         //(ListadoFirmas[0].correos).ToList(); //extraemos todos los correos de la firma, y de aqui seleccionaremos los que estan validados.
                        string correoHostEmisor = "";
                        string contrasena = "";
                        int puerto = 0;
                        string host = "";
                        bool sslOk = false;
                        int ffirma = ListadoFirmas.idfirma; //ListadoFirmas[0].idfirma;
                        var ListadoCorreosFirma = (from c in db.correos where c.idfirma == ffirma select c).ToList();
                        int existecorreoFirma = 0;
                        foreach (var k in ListadoCorreosFirma)
                        {
                            if (k.estadoverificacioncorreo == "Verificado" && k.codigosolicitadocorreo == k.codigoverificadocorreo && k.principalcorreo == true)
                            {
                                #region _
                                correoHostEmisor = k.direccioncorreo;
                                contrasena = ircnEseD(k.contraseniacorreo);
                                puerto = (int)k.puertocorreo;
                                host = k.hostcorreo;
                                sslOk = (bool)k.sslrequeridocorreo;
                                existecorreoFirma++;
                                #endregion
                            }
                        }
                        if (existecorreoFirma > 0)
                        {
                            if (ListadoCorreosSocios != null)
                            {
                                ValorDejarseVer = 40;
                                RaisePropertyChanged("ValorDejarseVer");
                                await this.cuenteUno();
                                string cambiosQueOcurrieron = "Se le informa que en el SGPT han ocurrido los siguiente eventos: \n\n";
                                foreach (var t in PermisosQueSufrieronCambios)
                                {

                                    cambiosQueOcurrieron += "\n En la opcion: " + t.nombreopcionpru.ToUpper() +" que se ubica en el menu: "+t.menupru.ToUpper()+ " -> "+t.submenupru.ToUpper()+ " Se han realizado las siguientes configuraciones en los permisos.\n";
                                    if (t.crearpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Crear     \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Crear     \n";
                                    if (t.eliminarpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Eliminar  \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Eliminar  \n";
                                    if (t.consultarpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Consultar \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Consultar \n";
                                    if (t.editarpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Editar      \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Editar    \n";
                                    if (t.impresionpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Impresion   \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Impresion   \n";
                                    if (t.exportacionpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Exportacion \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Exportacion \n";
                                    if (t.revisarpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Revisar \n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Revisar \n";
                                    if (t.aprobarpru) cambiosQueOcurrieron += "\t\t" + t.nombreopcionpru + ": Se ha Habilitado la opcion de: Aprobar \n\n"; else cambiosQueOcurrieron += "\t\t " + t.nombreopcionpru + ": Se ha Deshabilitado la opcion de: Aprobar \n\n";

                                }
                                #region _
                                int correosinformados = 0;
                                #region _
                                await this.cuenteUno();
                                ValorDejarseVer = 70;
                                RaisePropertyChanged("ValorDejarseVer");

                                foreach (var a in ListadoCorreosSocios)
                                {
                                    #region +
                                    string correoDirigidoA = a.direccioncorreo;
                                    string nome = (Nombrespersona + " " + Apellidospersona).ToUpper();
                                    string titulo = "Notificacion de modificaciones en los permisos del usuario: " + nome + " Con Rol: " + Rol.ToUpper();
                                    string cuerpo = cambiosQueOcurrieron + " \n\n Los cambios fueron realizados por el usuario: " + CurrentUsuario.inicialesusuario + " -  con Nick: " + CurrentUsuario.nickusuariousuario + " \nEl cual posee los permisos suficientes para realizar dichos cambios. \n " + DateTime.Now.ToString();
                                    

                                    var mensajero = new EnviameElEmailCamaleon();
                                    bool enviado = mensajero.EnviarEmail(correoDirigidoA, correoHostEmisor, RazonSocial, contrasena, titulo, cuerpo, puerto, host, sslOk);
                                    if (enviado)
                                    {
                                        correosinformados++;
                                    }
                                    #endregion
                                }
                                ValorDejarseVer = 100;
                                RaisePropertyChanged("ValorDejarseVer");
                                valorProgresoTextBox = String.Format("Notificando a los socios acerca de los cambios... La operacion puede tardar varios minutos.");
                                RaisePropertyChanged("valorProgresoTextBox");
                                await this.cuenteUno();
                                if (correosinformados > 0)
                                {
                                    //MessageBox.Show("El usuario ha sido informado en " + correosinformados + " Correos registrados y validos");
                                    await AvisaYCerrateVosSolo(correosinformados+ "correos ha sido informado el socio acerca de los cambios en permisos del usuario","", 1);
                                    //return true;
                                }
                                else
                                {
                                    //MessageBox.Show("El usuario no pudo ser notificado de su usuario ni contraseñas.\n Verifique haber introducido correctamente los correos electronicos, y que tenga acceso a internet. \n ", "Error. correos invalidos", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    await AvisaYCerrateVosSolo("El socio no pudo ser notificado de los cambios en los permisos del usuario.", "Verifique haber introducido correctamente los correos electronicos, y que halla acceso a internet.",2);
                                    //return false;
                                }
                                #endregion
                                #endregion
                            }
                            else
                            { //MessageBox.Show("La firma no posee un correo verificado apto para emitir correos.", "La firma no posee un correo valido", MessageBoxButton.OK, MessageBoxImage.Stop);
                                await AvisaYCerrateVosSolo("La firma no posee ningun Socio con un correo valido para recibir notificaciones por correo electronico.", "La firma no posee ningun socio que tenga un correo valido",2);
                                //return false;
                            }

                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("No existe ningun correo valido disponible para emitir informacion", "La firma no posee un correo valido",2);
                            //return false;
                        }
                        #endregion
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("No es posible notificarle a ningun socio, porque no existe el registro de la firma", "Ingrese una Firma, los socios y el personal",2);
                    //return false;
                }
                #endregion 
            }
            else
            {
                await dlg.ShowMessageAsync(this, "No fue posible notificar los cambios en los permisos al socio. Se perdio la conexion a Internet en el proceso", "Ocurrio un error al notificar al socio, ya que la conexion a internet se perdio.");
                //return false;
            }
        }

        private async Task cuenteUno()
        {
            await Task.Delay(1);

        }

        private bool HayInterSioNo()
        {
            #region +
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                if (host.AddressList != null)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
            #endregion
        }
        #region _
        public static string ircnEseD(byte[] _cAdd)
        {
            if (_cAdd != null)
            {
                char[] chars = new char[_cAdd.Length / sizeof(char)];
                System.Buffer.BlockCopy(_cAdd, 0, chars, 0, _cAdd.Length);
                return new string(chars);
            }
            else
            {
                string chars = "";
                return chars;
            }

        }
        #endregion 

        public class GruposToTotalConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is ReadOnlyObservableCollection<object>)
                {
                    var items = (ReadOnlyObservableCollection<object>)value;
                    Decimal total = 0;
                    //foreach (Order element in items) {
                    //    total += element.amount;
                    //}
                    total = 1;
                    return total.ToString();
                }

                return "";
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                return value;
            }

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