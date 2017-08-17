using CapaDatos;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Modales.AdmonClientes;
using System.Data.Entity;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using SGPTWpf.SGPtmvvm.Model;

namespace SGPTmvvm.ViewModel
{
    public class tabconenedorClienteContactosViewModel : INotifyPropertyChanged //, ViewModeloBase
    {
        public SGPTEntidades db = new SGPTEntidades();

        public List<estructurasorganica> ListadoEstructuraO { get; set; }
        public List<contacto> ListadoContactos { get; set; }
        public List<ContactosModelo> ListadoContactosx { get; set; }
        public List<ContactosModelo> ListadoContactosy = new List<ContactosModelo>();

        permisosrolesusuario permisorolusuariovalidado { get; set; }

        public List<cliente> ListadoClientes { get; set; }
        public List<ClienteContactoModelo> ListadoClientesM { get; set; }


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


        cliente currentCliente2 = new cliente();
        private ClienteContactoModelo _currentCliente;

        public ClienteContactoModelo currentCliente
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

        private ContactosModelo _selectedContacto;
        public ContactosModelo SelectedContactox
        {
            get { return _selectedContacto; }
            set 
            { 
                _selectedContacto = value;
                RaisePropertyChanged("SelectedContactox");
            }
        }

        private estructurasorganica _SelectedMiembroEstructura;
        public estructurasorganica SelectedMiembroEstructura
        {
            get { return _SelectedMiembroEstructura; }
            set
            {
                _SelectedMiembroEstructura=value;
                RaisePropertyChanged("SelectedMiembroEstructura");
            }
        }

        #endregion
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update).
        private bool AccionConsultar;
        private bool HayRegistroTemporalCreado; //variable para saber si se debera guardar cambios en una posible modificacion

        private bool _canExecute=true;
        private DialogCoordinator dlg;

        private ClienteContactoModelo _clienteSelected;
        public ClienteContactoModelo ClienteSelected
        {
            get { return _clienteSelected; }
            set
            {
                _clienteSelected = value;
                RaisePropertyChanged("ClienteSelected");
            }
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="currentUsuariox"></param>
        public tabconenedorClienteContactosViewModel(usuario currentUsuariox) 
        {
            AccionGuardar = true;
            AccionConsultar = false;
            HayRegistroTemporalCreado = false; //sirve para saber si he creado un cliente temporal

            this.PestañaSeleccionada = 0;
            UsuarioPuedeCrear = false;
            UsuarioPuedeEliminar = false;
            UsuarioPuedeConsultar = false;
            UsuarioPuedeEditar = false;
            UsuarioPuedeImprimir = false;
            UsuarioPuedeExportar = false;
            UsuarioPuedeRevisar = false;
            UsuarioPuedeAprobar = false;

            txtBanderaRegresar = "1"; //La opcion volver esta habilitada.
            txtBandera = "0"; //la opcion guardar esta deshabilitada
            txtBanderaNuevo = "1";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "0";
            txtBanderaCancelar = "0";
            dlg = new DialogCoordinator();
            HabilitarListadoClientes = Visibility.Visible;
            HabilitarTabContactos = Visibility.Hidden;
            currentUsuario = currentUsuariox;
            currentCliente = new ClienteContactoModelo();

            currentUsuario = currentUsuariox;
            //currentCliente = Clientx;
            //this.PermisosUsuarioValidado(); //Obtenemos los permisos del currentUsuario
            this.PermisosUsuarioValidado("Estructuras Orgánicas");
            //this.ObtenerDatos();
            this.PruebaInicializadoresEnSegundoPlano();
            Mouse.OverrideCursor = null;
        }

        private void EscuchandoALaVista(int opc)
        {
            FocoPestañaSeleccionada = 0;
            if (opc == 1 || opc == 2 || opc == 3)
            {
                if (opc != 3) //si no es consultar
                    txtBandera = "1";
                else
                    txtBandera = "0";

                txtBanderaNuevo = "0";
                txtBanderaEditar = "0";
                txtBanderaConsultar = "0";
                txtBanderaEliminar = "0";
                txtBanderaCancelar = "1";
            }
            //using(db=new SGPTEntidades())
            //{
            //    //CurrentSistemaContable = db.sistemascontables.Where(s => s.idsc == currentCliente.idsc).SingleOrDefault();
            //}
            switch (opc)
            {
                case 2:
                    OpcionDeVisitaAqui = 2; if (PestañaSeleccionada==1)	this.MycmdEditarEstructura(); else this.MycmdEditarContacto();
                        break;
                case 3:
                    OpcionDeVisitaAqui = 3; txtBandera = "0"; 
                    if (PestañaSeleccionada==1)	this.MycmdConsultarEstructura(); else this.MycmdConsultarContacto();
                    break;
                case 1:
                    OpcionDeVisitaAqui = 1;
                    if (PestañaSeleccionada == 1) this.MycmdCrearEstructura(); else this.MycmdCrearContacto();
                    
                    break;
                default: break;
            }
        }

        /***********Acoplamiento de Botones segun barra de menu 20/02/2017*************************************************************************
         */
        #region + Botones Barra
        private ICommand _Nuevo;
        public ICommand cmdNuevoClientes_Click
        {
            get
            {
                return _Nuevo ?? (_Nuevo = new CommandHandler(() => NuevoM(), _canExecute));
            }
        }

        private async void NuevoM()
        {
            if (ClienteSelected!=null)
            {
                if (ClienteSelected.estructuraorganica=="No")
                {
                    #region +
                    if (UsuarioPuedeCrear)
                    {
                        //await dlg.ShowMessageAsync(this, "Nuevo", "");
                        txtBanderaCancelar = "1";
                        PestañaSeleccionada = 1;
                        currentCliente = ClienteSelected;
                        txtBanderaRegresar = "0"; //deshabilitamos el boton regresar pq en nuevo creamos un registro temporal que debe ser eliminado ne caso que abandone
                        HabilitarListadoClientes = Visibility.Hidden;
                        HabilitarTabContactos = Visibility.Visible;
                        
                        //Ojo, me gustaria que para agregar elementos a la estructura organica y a los contactos, que lo haga desde el boton agregar, y no desde nuevo.
                        //if(PestañaSeleccionada!=0) 
                        //this.EscuchandoALaVista(1);
                        txtBanderaNuevo = "0";
                        txtBanderaAgregar = "1";
                        await AvisaYCerrateVosSolo("Click en AGREGAR para crear un nuevo registo.", "", 2);
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 2);
                    }
                    #endregion 
                }
                else
                {
                    await AvisaYCerrateVosSolo("El cliente ya posee una estructura organica" + Environment.NewLine + "Para realizar cambios, seleccione Editar", "Imposible crear otra estructura organica.", 3);
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("Seleccione un cliente para continuar", "", 1);
            }
        }

        private ICommand _Editar;
        public ICommand cmdEditarClientes_Click
        {
            get
            {
                return _Editar ?? (_Editar = new CommandHandler(() => EditarM(), _canExecute));
            }
        }

        private async void EditarM()
        {
            if (ClienteSelected!=null)
            {
                #region +
                if (ClienteSelected.estructuraorganica == "Si")
                {
                    if (UsuarioPuedeEditar)
                    {
                        #region +
                        if (ClienteSelected != null)
                        {
                            txtBandera = "1";
                            txtBanderaNuevo = "0";
                            txtBanderaEditar = "1";
                            txtBanderaConsultar = "1";
                            txtBanderaEliminar = "1";
                            txtBanderaAgregar = "1";
                            txtBanderaCancelar = "1";
                            txtBanderaRegresar = "0";
                            currentCliente = ClienteSelected;
                            
                            HabilitarListadoClientes = Visibility.Hidden;
                            HabilitarTabContactos = Visibility.Visible;
                            if (PestañaSeleccionada == 0)
                            {
                                this.MyPestañaEstructuraO();
                                Mouse.OverrideCursor = Cursors.Wait;
                                this.ObtenerDatos();
                                this.ObtenerDatosContactos();
                                Mouse.OverrideCursor = null;
                            }
                            else
                                this.EscuchandoALaVista(2);
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("Seleccione un cliente para continuar...", "", 1);
                            txtBandera = "0";
                            txtBanderaNuevo = "1";
                            txtBanderaEditar = "1";
                            txtBanderaConsultar = "1";
                            txtBanderaEliminar = "1";
                            txtBanderaAgregar = "0";
                            txtBanderaCancelar = "0";
                            txtBanderaRegresar = "1";
                        }
                        #endregion
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 2);
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("El cliente No posee una estructura organica" + Environment.NewLine + "Para continuar, seleccione Nuevo", "Imposible editar la estructura organica.", 3);
                }  
                #endregion
            }
            else
                await AvisaYCerrateVosSolo("Seleccione un cliente para continuar", "", 1);
        }

        private ICommand _Eliminar;
        public ICommand cmdEliminarClientes_Click
        {
            get
            {
                return _Eliminar ?? (_Eliminar = new CommandHandler(() => EliminarM(), _canExecute));
            }
        }

        private async void EliminarM()
        {
            if (ClienteSelected!=null)
            {
                if (ClienteSelected.estructuraorganica=="Si")
                {
                    #region +
                    
                        if (UsuarioPuedeEliminar)
                        {
                            if (PestañaSeleccionada == 2)
                            {
                                //this.MycmdEliminarPersonal();
                                if (SelectedContactox != null)
                                {
                                    this.MycmdEliminarContacto();
                                }
                                else
                                    await AvisaYCerrateVosSolo("Seleccione el contacto que desea eliminar", "", 2);
                            }
                            else
                            {
                                #region +
                                if (SelectedMiembroEstructura != null)
                                {
                                    #region +
                                    //    try
                                    //    {
                                    //        #region +
                                    //        var mySettingsk = new MetroDialogSettings()
                                    //        {
                                    //            AffirmativeButtonText = "Acepto",
                                    //            NegativeButtonText = "Cancelar",

                                    //        };
                                    //        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro " + Environment.NewLine + ClienteSelected.razonsocialcliente + " se eliminara logicamente del sistema.", "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                                    //        if (resultk == MessageDialogResult.Affirmative)
                                    //        {
                                    //            #region
                                    //            try
                                    //            {
                                    //                using (SGPTEntidades db = new SGPTEntidades())
                                    //                {
                                    //                    //ojo aclarar que es lo que se eliminara aqui, pq no tiene logica eliminar al cliente, sino la estructura organica y juntamente sus contactos. 
                                    //                    //Por mi que no se pueda eliminar nada.
                                    //                    cliente cli = db.clientes.Find(ClienteSelected.idnitcliente);
                                    //                    cli.estadocliente = "A"; //ojo estaba en B
                                    //                    db.Entry(cli).State = EntityState.Modified;
                                    //                    db.SaveChanges();
                                    //                    //this.ObtenerDatos();
                                    //                    this.ObtenerListadoClientes();
                                    //                    //this.ObtenerDatosContactos();
                                    //                }
                                    //                //await dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                    //                AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.", "Proceso completado.", 2);
                                    //                //MessageBox.Show("El registro se elimino correctamente de manera logica.", "Proceso completado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                    //            }
                                    //            catch (Exception)
                                    //            {
                                    //                MessageBox.Show("Imposible eliminar el contacto seleccionado.\n La base de datos tardo demasiado en responder.\n Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                                    //            }
                                    //            #endregion
                                    //        }
                                    //        else
                                    //            //await dlg.ShowMessageAsync(this, "Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...");
                                    //            //MessageBox.Show("Eliminacion abortada por el usuario. \nNo se realizo ninguna accion.", "Cancelado por el usuario...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                    //            AvisaYCerrateVosSolo("Eliminacion abortada por usted.", "No se realizo ninguna accion.", 2);
                                    //        #endregion
                                    //    }
                                    //    catch (Exception)
                                    //    {
                                    //        MessageBox.Show("Ocurrio un error al comparar los permisos del usuario", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Stop);
                                    //    }
                                    //    #endregion
                                    //}
                                    //else
                                    //{
                                    //    AvisaYCerrateVosSolo("Seleccione un cliente para continuar...", "", 1);
                                    //    txtBandera = "0";
                                    //    txtBanderaNuevo = "1";
                                    //    txtBanderaEditar = "1";
                                    //    txtBanderaConsultar = "1";
                                    //    txtBanderaEliminar = "1";
                                    //    txtBanderaAgregar = "0";
                                    //    txtBanderaCancelar = "0";
                                    //    txtBanderaRegresar = "1";
                                    //}
                                    #endregion
                                    this.MycmdEliminarEstructura();
                                }
                                else
                                    await AvisaYCerrateVosSolo("Seleccione el puesto que desea eliminar", "", 2);
                                #endregion
                            }
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 2);
                        }
                    //}
                    #endregion  
                }
                else
                {
                    await AvisaYCerrateVosSolo("El cliente No posee una estructura organica" + Environment.NewLine + "Para continuar, seleccione Nuevo", "Imposible eliminar la estructura organica.", 3);
                }
            }
            else
                await AvisaYCerrateVosSolo("Seleccione un cliente para continuar", "", 1);
        }

        private ICommand _Consultar;
        public ICommand cmdConsultarClientes_Click
        {
            get
            {
                return _Consultar ?? (_Consultar = new CommandHandler(() => ConsultarM(), _canExecute));
            }
        }

        private async void ConsultarM()
        {
            
            if (ClienteSelected != null)
            {
                if (ClienteSelected.estructuraorganica == "Si")
                {
                    #region +
                        if (UsuarioPuedeConsultar)
                        {
                            #region +
                            //txtBanderaEliminar = "0";
                            //txtBanderaAgregar = "0";
                            txtBandera = "0";
                            txtBanderaNuevo = "0";
                            txtBanderaEditar = "0";
                            txtBanderaConsultar = "0";
                            txtBanderaEliminar = "0";
                            txtBanderaAgregar = "0";
                            txtBanderaCancelar = "1";
                            txtBanderaRegresar = "1";
                            //await dlg.ShowMessageAsync(this, "Consultar", "");
                            if (ClienteSelected != null)
                            {
                                currentCliente = ClienteSelected;
                                
                                HabilitarListadoClientes = Visibility.Hidden;
                                HabilitarTabContactos = Visibility.Visible;
                                if (PestañaSeleccionada == 0)
                                {
                                    this.MyPestañaEstructuraO();
                                    Mouse.OverrideCursor = Cursors.Wait;
                                    this.ObtenerDatos();
                                    this.ObtenerDatosContactos();
                                    Mouse.OverrideCursor = null;
                                }
                                else
                                    this.EscuchandoALaVista(3);
                            }
                            else
                            {
                                //await dlg.ShowMessageAsync(this, "Seleccione un cliente para continuar...", "");
                                await AvisaYCerrateVosSolo("Seleccione un cliente para continuar...", "", 1);

                                txtBandera = "0";
                                txtBanderaNuevo = "1";
                                txtBanderaEditar = "1";
                                txtBanderaConsultar = "1";
                                txtBanderaEliminar = "1";
                                txtBanderaAgregar = "0";
                                txtBanderaCancelar = "1";
                                txtBanderaRegresar = "1";
                            }
                            #endregion
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 1);
                        }
                    #endregion
                }
                else
                {
                    await AvisaYCerrateVosSolo("El cliente No posee una estructura organica" + Environment.NewLine + "Para continuar, seleccione Nuevo", "Imposible eliminar la estructura organica.", 3);
                    txtBandera = "0";
                    txtBanderaNuevo = "1";
                    txtBanderaEditar = "1";
                    txtBanderaConsultar = "1";
                    txtBanderaEliminar = "1";
                    txtBanderaAgregar = "0";
                    txtBanderaCancelar = "1";
                    txtBanderaRegresar = "1";
                }
            }
            else
                await AvisaYCerrateVosSolo("Seleccione un cliente para continuar", "", 1);
        }

        private ICommand _Agregar;
        public ICommand Agregar
        {
            get
            {
                return _Agregar ?? (_Agregar = new CommandHandler(() => AgregarM(), _canExecute));
            }
        }

        private async void AgregarM()
        {
            if (PestañaSeleccionada == 1)
            {
                currentCliente = ClienteSelected;
                this.EscuchandoALaVista(1);
            }
            else if (PestañaSeleccionada==2 && ListadoEstructuraO!=null)
            {
                //if (PestañaSeleccionada == 0)
                //    this.MyPestañaEstructuraO();
                //else
                //    this.EscuchandoALaVista(3);
                currentCliente = ClienteSelected;
                this.EscuchandoALaVista(1); 
            }
            else
            {
                await AvisaYCerrateVosSolo("Es necesario que primeramente se introduzca la estructura organica del cliente", "", 2);
            }
        }

        private ICommand _Guardar;
        public ICommand cmdGuardarClientes_Click
        {
            get
            {
                return _Guardar ?? (_Guardar = new CommandHandler(() => GuardarM(), _canExecute));
            }
        }

        private void GuardarM()
        {
            //await dlg.ShowMessageAsync(this, "Guardar", "");
            //this.activarBarraGuardarDatos();
        }

        private ICommand _Cancelar;
        public ICommand cmdCancelarClientes_Click
        {
            get
            {
                return _Cancelar ?? (_Cancelar = new CommandHandler(() => CancelarM(), _canExecute));
            }
        }

        private async void CancelarM()
        {
            await AvisaYCerrateVosSolo("Cancelado por usted...", "", 1);

            PestañaSeleccionada = 0;
            txtBandera = "0";
            txtBanderaNuevo = "1";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "0";
            txtBanderaCancelar = "0";
            txtBanderaRegresar = "1";
            HabilitarListadoClientes = Visibility.Visible;
            HabilitarTabContactos = Visibility.Hidden;
           
            this.ObtenerListadoClientes();
        }
        #endregion

        
        

        private void PruebaInicializadoresEnSegundoPlano()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.RunWorkerCompleted += worker_procesoFinalizado;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerAsync();
        }

        #region Prueba de sub-Proceso en segundo plano
        private void worker_procesoFinalizado(object sender, RunWorkerCompletedEventArgs e)
        {
            //this.ObtenerDatos();
            //this.ObtenerDatosContactos();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            worker.ReportProgress(0, String.Format("Proceso Interaccion 1."));
            //this.ObtenerDatos();
            this.ObtenerListadoClientes();
            //this.PermisosUsuarioValidado("Clientes");
            worker.ReportProgress(100, "Proceso Finalizado con éxito.");
        }


        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }
        #endregion


        #region Bindiados



        #region Banderas de control de barra de botones
        private string _txtBandera; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }

        private string _txtBanderaNuevo; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBanderaNuevo
        {
            get { return _txtBanderaNuevo; }
            set { _txtBanderaNuevo = value; RaisePropertyChanged("txtBanderaNuevo"); }
        }

        private string _txtBanderaEditar; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBanderaEditar
        {
            get { return _txtBanderaEditar; }
            set { _txtBanderaEditar = value; RaisePropertyChanged("txtBanderaEditar"); }
        }

        private string _txtBanderaConsultar; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBanderaConsultar
        {
            get { return _txtBanderaConsultar; }
            set { _txtBanderaConsultar = value; RaisePropertyChanged("txtBanderaConsultar"); }
        }

        private string _txtBanderaEliminar; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBanderaEliminar
        {
            get { return _txtBanderaEliminar; }
            set { _txtBanderaEliminar = value; RaisePropertyChanged("txtBanderaEliminar"); }
        }

        private string _txtBanderaAgregar; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBanderaAgregar
        {
            get { return _txtBanderaAgregar; }
            set { _txtBanderaAgregar = value; RaisePropertyChanged("txtBanderaAgregar"); }
        }

        private string _txtBanderaCancelar; //Sirve para cancelar.
        public string txtBanderaCancelar
        {
            get { return _txtBanderaCancelar; }
            set { _txtBanderaCancelar = value; RaisePropertyChanged("txtBanderaCancelar"); }
        }


        private string _txtBanderaRegresar; //Sirve para cancelar.
        public string txtBanderaRegresar
        {
            get { return _txtBanderaRegresar; }
            set { _txtBanderaRegresar = value; RaisePropertyChanged("txtBanderaRegresar"); }
        } 
        #endregion


        public ICommand _CmdVolver; //permite volver al listado de clientes.
        public ICommand CmdVolver { get { return _CmdVolver ?? (_CmdVolver = new CommandHandler(() => MyCmdVolver(), _canExecute)); } }


        private void MyCmdVolver() //Sirve para reactivar el panel izquierdo
        {
            Messenger.Default.Send<String>("1", "mensajevacio");
        }


        private Visibility _habilitarListadoClientes;
        public Visibility HabilitarListadoClientes
        {
            get { return _habilitarListadoClientes; }
            set
            {
                _habilitarListadoClientes = value;
                RaisePropertyChanged("HabilitarListadoClientes");
            }
        }

        private Visibility _HabilitarTabContactos;
        public Visibility HabilitarTabContactos
        {
            get { return _HabilitarTabContactos; }
            set
            {
                _HabilitarTabContactos = value;
                RaisePropertyChanged("HabilitarTabContactos");
            }
        }
        #endregion

        private int _opcionDeVisitaAqui;
        public int OpcionDeVisitaAqui
        {
            get { return _opcionDeVisitaAqui; }
            set
            {
                _opcionDeVisitaAqui = value;
                RaisePropertyChanged("OpcionDeVisitaAqui");
            }
        }

        private int _FocoPestañaSeleccionada;
        public int FocoPestañaSeleccionada
        {
            get { return _FocoPestañaSeleccionada; }
            set
            {
                _FocoPestañaSeleccionada = value;
                RaisePropertyChanged("FocoPestañaSeleccionada");
            }
        }

        private int _PestañaSeleccionada;
        public int PestañaSeleccionada
        {
            get { return _PestañaSeleccionada; }
            set
            {
                _PestañaSeleccionada = value;
                RaisePropertyChanged("PestañaSeleccionada");
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


        /// <summary>
        /// Permisos del usuario validado Variables y metodo
        /// </summary>
        /// <param name="Tabla"></param>

        #region Metodo del usuario validado
        private void PermisosUsuarioValidado(string Tabla)
        {
            #region -
            using (db = new SGPTEntidades())
            {
                try
                {
                    //extrayendo los permisos dados al usuario segun su rol
                    permisorolusuariovalidado = new permisosrolesusuario();
                    permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == Tabla select p).SingleOrDefault();
                    UsuarioPuedeCrear = permisorolusuariovalidado.crearpru;
                    UsuarioPuedeEliminar = permisorolusuariovalidado.eliminarpru;
                    UsuarioPuedeConsultar = permisorolusuariovalidado.consultarpru;
                    UsuarioPuedeEditar = permisorolusuariovalidado.editarpru;
                    UsuarioPuedeImprimir = permisorolusuariovalidado.impresionpru;
                    UsuarioPuedeExportar = permisorolusuariovalidado.exportacionpru;
                    UsuarioPuedeRevisar = permisorolusuariovalidado.revisarpru;
                    UsuarioPuedeAprobar = permisorolusuariovalidado.aprobarpru;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los permisos del rol del usuario.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este error "+e.InnerException, "error critico.", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            #endregion
        }
        #endregion

        #region Variables de Permisos del Usuario Logueado

        private Boolean _UsuarioPuedeCrear = false;
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

        private Boolean _UsuarioPuedeEliminar = false;
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
        private Boolean _UsuarioPuedeConsultar = false;
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

        private Boolean _UsuarioPuedeEditar = false;
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
        private Boolean _UsuarioPuedeImprimir = false;
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
        private Boolean _UsuarioPuedeExportar = false;
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
        private Boolean _UsuarioPuedeRevisar = false;
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

        private Boolean _UsuarioPuedeAprobar = false;
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


        //********************************************************************************************************

        /// <summary>
        /// Comando de control de Pestañas
        /// </summary>
        #region +
        public ICommand _miComanditoEstructuraO;
        public ICommand MiComanditoEstructuraO { get { return _miComanditoEstructuraO ?? (_miComanditoEstructuraO = new CommandHandler(() => MyPestañaEstructuraO(), _canExecute)); } }

        public ICommand _miComanditoContactos;
        public ICommand MiComanditoContactos { get { return _miComanditoContactos ?? (_miComanditoContactos = new CommandHandler(() => MyPestañaMiComanditoContactos(), _canExecute)); } }

        private void MyPestañaMiComanditoContactos()
        {
            PestañaSeleccionada = 2;
            this.PermisosUsuarioValidado("Contactos");
            //this.ObtenerDatosContactos();
        }


        private void MyPestañaEstructuraO()
        {
            PestañaSeleccionada = 1;
            this.PermisosUsuarioValidado("Estructuras Orgánicas");
            //this.ObtenerDatos();
            //this.ObtenerDatosContactos();
        } 
        #endregion
        //************************************************************************************************************



        private void ObtenerListadoClientes()
        {
            //GC.Collect();
            using (db = new SGPTEntidades())
            {

                try
                {
                    var estructuras = db.estructurasorganicas.ToList();
                    var contactcliente = db.contactoclientes.ToList();
                    ListadoClientes = new List<cliente>();
                    ListadoClientes = (from c in db.clientes where c.estadocliente == "A" orderby c.razonsocialcliente select c).ToList();
                    RaisePropertyChanged("ListadoClientes");

                    ListadoClientesM = new List<ClienteContactoModelo>();
                    if(ListadoClientes!=null)
                    {
                        foreach (cliente a in ListadoClientes)
                        {
                            
                            ClienteContactoModelo c = new ClienteContactoModelo();
                            c.idnitcliente = a.idnitcliente;
                            c.razonsocialcliente = a.razonsocialcliente;
                            bool encont = estructuras.Exists(x => x.idnitcliente == a.idnitcliente);
                            c.estructuraorganica=(encont==true?"Si":"No");
                            int contactencont = contactcliente.Count(y=>y.idnitcliente==a.idnitcliente);
                            c.cantidadcontactos = contactencont;
                            ListadoClientesM.Add(c);
                        }
                    }
                    RaisePropertyChanged("ListadoClientesM");
                    this.cuente();
                }
                catch (System.Exception)
                {
                    dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los datos del cliente", "");
                }
            }
            if (ListadoClientes == null || ListadoClientes.Count == 0)
                dlg.ShowMessageAsync(this, "No posee ningun cliente registrado", "");
        }

        private void ObtenerDatos() //()
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoEstructuraO = new List<estructurasorganica>();
                    ListadoEstructuraO = (from e in db.estructurasorganicas where e.idnitcliente == currentCliente.idnitcliente && e.estadoeo=="A" orderby e.nombrecargoeo select e).ToList();
                    RaisePropertyChanged("ListadoEstructuraO");
                }
                catch (Exception e)
                {

                    MessageBox.Show("Error critico al recuperar los datos de la estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. "+e.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void ObtenerDatosContactos() //holass
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoContactos = new List<contacto>();
                    ListadoContactos = (from c in db.contactos
                                        join e in db.estructurasorganicas
                                        on c.idcargoeo equals e.idcargoeo
                                        join cl in db.clientes
                                        on e.idnitcliente equals cl.idnitcliente
                                        where cl.idnitcliente == currentCliente.idnitcliente && c.estadocontacto == "A"
                                        select c).ToList();

                    ListadoContactosx = new List<ContactosModelo>();
                    foreach (var a in ListadoContactos)
                    {
                        ContactosModelo c = new ContactosModelo();
                        c.idcontacto = a.idcontacto;
                        c.idcargoeo = (int)a.idcargoeo;
                        c.nombrecargo = a.estructurasorganica.nombrecargoeo;
                        c.nombrescontacto = a.nombrescontacto;
                        c.apellidoscontacto = a.apellidoscontacto;
                        c.nombrecompleto = a.nombrescontacto + " " + a.apellidoscontacto;
                        c.fechainiciofuncioncontacto = a.fechainiciofuncioncontacto;
                        c.fechacesefuncioncontacto = a.fechacesefuncioncontacto;
                        c.observacionescontacto = a.observacionescontacto;
                        c.estadocontacto = a.estadocontacto;
                        //extrayendo los telefonos
                        var tel = (from t in db.telefonos where t.idcontacto == c.idcontacto select t).ToList();
                        foreach (var s in tel)
                        {
                            c.telefonos += s.numerotelefono + "  ";
                        }
                        if (tel == null || tel.Count == 0)
                            c.telefonos = "N/D";

                        var cor = (from u in db.correos where u.idcontacto == c.idcontacto select u).ToList();
                        foreach (var t in cor)
                        {
                            c.correos += t.direccioncorreo + "  ";
                        }
                        if (cor == null || cor.Count == 0)
                            c.correos = "N/D";
                        ListadoContactosx.Add(c);
                    }
                    RaisePropertyChanged("ListadoContactosx");
                }
                catch (Exception e)
                {

                    MessageBox.Show("Error critico al recuperar los datos de los contactos del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. "+e.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private async void cuente()
        {
            await cuenteUno();
        }

        private async Task cuenteUno()
        {
            await Task.Delay(1);
        }


        
        

        /// <summary>
        /// Comandos y Metodos de Estructura Organica************************************************************************************************************
        /// </summary>
        #region Comandos Estructura organica
        public ICommand _cmdCrear;
        public ICommand cmdCrearUno
        {
            get
            {
                return _cmdCrear ?? (_cmdCrear = new CommandHandler(() => MycmdCrearEstructura(), _canExecute));
            }
        }

        public ICommand _cmdEditar;
        public ICommand cmdEditarUno 
        { 
            get 
            { 
                return _cmdEditar ?? (_cmdEditar = new CommandHandler(() => MycmdEditarEstructura(), _canExecute)); 
            } 
        }
        public ICommand _cmdEliminar;
        public ICommand cmdEliminarUno { get { return _cmdEliminar ?? (_cmdEliminar = new CommandHandler(() => MycmdEliminarEstructura(), _canExecute)); } }


        public ICommand _cmdConsultar;
        public ICommand cmdConsultarUno { get { return _cmdConsultar ?? (_cmdConsultar = new CommandHandler(() => MycmdConsultarEstructura(), _canExecute)); } }

        #endregion

        #region Metodos estructura Organica
        private async void MycmdCrearEstructura()
        {
            try
            {
                if (UsuarioPuedeCrear) //si tiene permisos de crear
                {
                    currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                    ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente2; mensajito.EstructuraAmodificar = new estructurasorganica();
                    CRUDclientesContactosEstructuraView mivista = new CRUDclientesContactosEstructuraView(mensajito);
                    var res = mivista.ShowDialog();
                    this.ObtenerDatos();
                    RaisePropertyChanged("");
                    txtBandera = "0";
                txtBanderaNuevo = "0";
                txtBanderaEditar = "1";
                txtBanderaConsultar = "1";
                txtBanderaEliminar = "1";
                txtBanderaAgregar = "1";
                txtBanderaCancelar = "1";
                txtBanderaRegresar = "1";
                }
                else
                {
                    //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                    await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            txtBandera = "0";
            txtBanderaNuevo = "0";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "1";
            txtBanderaCancelar = "1";
            txtBanderaRegresar = "1";
        }
        private async void MycmdEditarEstructura()
        {
            if (SelectedMiembroEstructura != null)
            {
                #region +
                try
                {
                    if (UsuarioPuedeEditar) //si tiene permisos de crear
                    {
                        currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente2; mensajito.EstructuraAmodificar = SelectedMiembroEstructura;
                        CRUDclientesContactosEstructuraView mivista = new CRUDclientesContactosEstructuraView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("");
                        txtBandera = "0";
                        txtBanderaNuevo = "0";
                        txtBanderaEditar = "1";
                        txtBanderaConsultar = "1";
                        txtBanderaEliminar = "1";
                        txtBanderaAgregar = "1";
                        txtBanderaCancelar = "1";
                        txtBanderaRegresar = "1";
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a editar", "", 1);
                txtBandera = "0";
                txtBanderaNuevo = "0";
                txtBanderaEditar = "1";
                txtBanderaConsultar = "1";
                txtBanderaEliminar = "1";
                txtBanderaAgregar = "1";
                txtBanderaCancelar = "1";
                txtBanderaRegresar = "1";
            }
        }
        private async void MycmdConsultarEstructura()
        {
            if (SelectedMiembroEstructura != null)
            {
                #region +
                try
                {
                    if (UsuarioPuedeConsultar) //si tiene permisos de consultar
                    {
                        currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente2; mensajito.EstructuraAmodificar = SelectedMiembroEstructura;
                        CRUDclientesContactosEstructuraView mivista = new CRUDclientesContactosEstructuraView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatos();
                        RaisePropertyChanged("");
                        txtBandera = "0";
                        txtBanderaNuevo = "0";
                        txtBanderaEditar = "1";
                        txtBanderaConsultar = "1";
                        txtBanderaEliminar = "1";
                        txtBanderaAgregar = "1";
                        txtBanderaCancelar = "1";
                        txtBanderaRegresar = "1";
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a consultar", "", 2);
                txtBandera = "0";
                txtBanderaNuevo = "0";
                txtBanderaEditar = "1";
                txtBanderaConsultar = "1";
                txtBanderaEliminar = "1";
                txtBanderaAgregar = "1";
                txtBanderaCancelar = "1";
                txtBanderaRegresar = "1";
            }
        }
        private async void MycmdEliminarEstructura()
        {
            if ((SelectedMiembroEstructura != null))
            {
                #region +
                try
                {
                    //if (permisorolusuariovalidado.eliminarpru && permisorolusuariovalidado != null)
                    if (UsuarioPuedeEliminar)
                    {
                        //if (MessageBox.Show("El puesto " + SelectedMiembroEstructura.nombrecargoeo + ", se eliminara logicamente.\n     Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        //{
                        var mySettingsk = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Acepto",
                            NegativeButtonText = "No",
                        };
                        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El puesto " + SelectedMiembroEstructura.nombrecargoeo + ", se eliminara logicamente.\n     Desea continuar?", "Advertencia... ", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                        if (resultk == MessageDialogResult.Affirmative)
                        {
                            #region
                            try
                            {
                                using (SGPTEntidades db = new SGPTEntidades())
                                {
                                    //correspondencia elimcor = db.correspondencias.Find(CorrespondenciaSelected.idcorrespondencia);
                                    estructurasorganica elimcor = db.estructurasorganicas.Find(SelectedMiembroEstructura.idcargoeo);
                                    elimcor.estadoeo = "B";
                                    db.Entry(elimcor).State = EntityState.Modified;
                                    db.SaveChanges();
                                    this.ObtenerDatos();
                                }
                                //await dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                await AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.", "Proceso completado.", 1);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Imposible eliminar el puesto seleccionado.\n La base de datos tardo demasiado en responder.\n Consulte a soporte tecnico acerca de este error. "+e.InnerException, "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            #endregion
                        }
                        else
                            await AvisaYCerrateVosSolo("Eliminacion abortada. No se realizo ninguna accion", "Cancelado por usted...",1);
                            //MessageBox.Show("Eliminacion abortada. No se realizo ninguna accion.", "Cancelado por el usuario...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            //await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.");
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.", 1);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
                #endregion
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar", "", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                //await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a eliminar", "", 2);
                txtBandera = "0";
                txtBanderaNuevo = "0";
                txtBanderaEditar = "1";
                txtBanderaConsultar = "1";
                txtBanderaEliminar = "1";
                txtBanderaAgregar = "1";
                txtBanderaCancelar = "1";
                txtBanderaRegresar = "1";
            }
        } 
        #endregion
        /*****************************************************************************************/


        /// <summary>
        /// Comandos y Metodos de Contactos
        /// </summary>
        #region Comandos contactos
        public ICommand _cmdCrearDos;
        public ICommand cmdCrearDos 
        { 
            get 
            { 
                return _cmdCrearDos ?? (_cmdCrearDos = new CommandHandler(() => MycmdCrearContacto(), _canExecute)); 
            } 
        }

        public ICommand _cmdEditarDos;
        public ICommand cmdEditarDos 
        { 
            get 
            { 
                return _cmdEditarDos ?? (_cmdEditarDos = new CommandHandler(() => MycmdEditarContacto(), _canExecute)); 
            } 
        }
        
        public ICommand _cmdConsultarDos;
        public ICommand cmdConsultarDos { get { return _cmdConsultarDos ?? (_cmdConsultarDos = new CommandHandler(() => MycmdConsultarContacto(), _canExecute)); } }


        public ICommand _cmdEliminarDos;
        public ICommand cmdEliminarDos { get { return _cmdEliminarDos ?? (_cmdEliminarDos = new CommandHandler(() => MycmdEliminarContacto(), _canExecute)); } }

        #endregion

        #region Metodos contactos
        private async void MycmdCrearContacto()
        {
            try
            {
                if (UsuarioPuedeCrear) //si tiene permisos de crear
                {
                    Messenger.Default.Register<ClientesContactosMensajeModal>(this, "Contactos", (ClientesContactosMensajeModal) => ControlContactoCapturado(ClientesContactosMensajeModal));
                    currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                    ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente2; mensajito.ContactosAmodificar = new ContactosModelo(); mensajito.llamadoDesde = "Contactos";
                    CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
                    var res = mivista.ShowDialog();
                    Messenger.Default.Unregister<ClientesContactosMensajeModal>(this); //mato el mensaje,para que libere memoria. pueda ser que la vista externa no mande nada.
                    //this.ObtenerDatosContactos();
                    RaisePropertyChanged("");
                }
                else
                {
                    //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                    //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear contactos  del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
                    await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            FocoPestañaSeleccionada = 1;
            txtBandera = "0";
            txtBanderaNuevo = "0";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "1";
            txtBanderaCancelar = "1";
            txtBanderaRegresar = "1";
        }
        private async void MycmdEditarContacto()
        {
            if (SelectedContactox != null)
            {
                #region +
                try
                {
                    if (UsuarioPuedeEditar) //si tiene permisos de crear
                    {
                        #region +
                        //Ojo, aqui recibo el contacto, aqui tengo que agregarlo a la lista, para que cuando guarde obtenga el id de la estructura organica... con un solo boton.
                        Messenger.Default.Register<ClientesContactosMensajeModal>(this, "Contactos", (ClientesContactosMensajeModal) => ControlContactoCapturado(ClientesContactosMensajeModal));
                        currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente2; mensajito.ContactosAmodificar = SelectedContactox; mensajito.llamadoDesde = "Contactos";
                        CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
                        var res = mivista.ShowDialog();
                        Messenger.Default.Unregister<ClientesContactosMensajeModal>(this); //mato el mensaje,para que libere memoria. pueda ser que la vista externa no mande nada.
                        //this.ObtenerDatosContactos();
                        RaisePropertyChanged("");

                        //Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this,tokenRecepcionAdmon, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));

                        #region ViewModel Properties : tokenRecepcionAdmon

                        //public const string tokenRecepcionAdmonPropertyName = "tokenRecepcionAdmon";

                        //private string _tokenRecepcionAdmon;

                        //public string tokenRecepcionAdmon
                        //{
                        //    get
                        //    {
                        //        return _tokenRecepcionAdmon;
                        //    }
                        //
                        //    set
                        //    {
                        //        if (_tokenRecepcionAdmon == value)
                        //        {
                        //            return;
                        //        }
                        //
                        //        _tokenRecepcionAdmon = value;
                        //        RaisePropertyChanged(tokenRecepcionAdmonPropertyName);
                        //    }
                        //}

                        #endregion

                        //private string token = "MenuAdministracion";
                        //var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
                        //Messenger.Default.Send(msg, token); 
                        #endregion
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear contactos  del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
                } 
                #endregion
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar", "Seleccione.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a editar", "", 1);
            }
            FocoPestañaSeleccionada = 1;
            txtBandera = "0";
            txtBanderaNuevo = "0";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "1";
            txtBanderaCancelar = "1";
            txtBanderaRegresar = "1";
        }

        private void ControlContactoCapturado(ClientesContactosMensajeModal cN)
        {
            if (cN.Accion==TipoComando.Nuevo)
            {
                if (cN.ContactosAmodificar != null)
                {
                    contacto cont = new contacto();
                    cont.idcontacto = 100000;
                    cont.idcargoeo = cN.ContactosAmodificar.idcargoeo;
                    cont.nombrescontacto = cN.ContactosAmodificar.nombrescontacto;
                    cont.apellidoscontacto = cN.ContactosAmodificar.apellidoscontacto;
                    cont.fechainiciofuncioncontacto = cN.ContactosAmodificar.fechainiciofuncioncontacto;
                    cont.fechacesefuncioncontacto = cN.ContactosAmodificar.fechacesefuncioncontacto;
                    cont.estadocontacto = "A";
                    cont.observacionescontacto = cN.ContactosAmodificar.observacionescontacto;

                    using (db=new SGPTEntidades())
                    {
                        try
                        {
                            db.contactos.Add(cont);
                            db.SaveChanges();

                            //Tenemos una tabla comodin que elimina la relacion muchos a muchos.
                            contactocliente concli = new contactocliente();
                            concli.idnitcliente = currentCliente.idnitcliente;
                            concli.idcontacto = cont.idcontacto;
                            db.contactoclientes.Add(concli);
                            db.SaveChanges();

                            if (cN.ContactosAmodificar.correo != null && cN.ContactosAmodificar.correo.direccioncorreo != null)
                            {
                                #region +
                                correo corr = new correo();
                                corr = cN.ContactosAmodificar.correo;
                                corr.idcontacto = cont.idcontacto;
                                db.correos.Add(corr);
                                db.SaveChanges();
                                #endregion
                            }

                            telefono telf = new telefono(); //oficina fijo
                            telf = cN.ContactosAmodificar.telefonoFijo;
                            telf.idcontacto = cont.idcontacto;
                            db.telefonos.Add(telf);

                            telefono celf = new telefono(); //celular de oficina
                            celf = cN.ContactosAmodificar.telefonoCelular;
                            celf.idcontacto = cont.idcontacto;
                            db.telefonos.Add(celf);
                            db.SaveChanges();

                        }
                        catch (Exception)
                        {
                            
                        }
                    }

                    this.ObtenerDatosContactos();
                    //ListadoContactosy.Add(ClientesContactosMensajeModal.ContactosAmodificar);
                    //ListadoContactosx = new List<ContactosModelo>();
                    //int i = 0;
                    //foreach (var ñ in ListadoContactosy)
                    //{
                    //    i++;
                    //    ñ.correlativo = i;
                    //    ListadoContactosx.Add(ñ);
                    //}
                    //RaisePropertyChanged("ListadoContactosx");
                } 
            }
            else if (cN.Accion == TipoComando.Editar)
            {
                if (cN.ContactosAmodificar != null)
                {
                    contacto cont = new contacto();
                    //cont.idcontacto = 100000;
                    cont.idcargoeo = cN.ContactosAmodificar.idcargoeo;
                    cont.nombrescontacto = cN.ContactosAmodificar.nombrescontacto;
                    cont.apellidoscontacto = cN.ContactosAmodificar.apellidoscontacto;
                    cont.fechainiciofuncioncontacto = cN.ContactosAmodificar.fechainiciofuncioncontacto;
                    cont.fechacesefuncioncontacto = cN.ContactosAmodificar.fechacesefuncioncontacto;
                    cont.estadocontacto = "A";
                    cont.observacionescontacto = cN.ContactosAmodificar.observacionescontacto;

                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            db.Entry(cont).State = EntityState.Modified;
                            db.SaveChanges();

                            //Tenemos una tabla comodin que elimina la relacion muchos a muchos.

                            //ojo, aqui no cambiamos nada, pq esto ya existe.
                            //contactocliente concli = new contactocliente();
                            //concli.idnitcliente = currentCliente.idnitcliente;
                            //concli.idcontacto = cont.idcontacto;
                            //db.contactoclientes.Add(concli);
                            //db.SaveChanges();

                            if (cN.ContactosAmodificar.correo != null && cN.ContactosAmodificar.correo.direccioncorreo != null)
                            {
                                #region +
                                correo corr = new correo();
                                corr = cN.ContactosAmodificar.correo;
                                //corr.idcontacto = cont.idcontacto;
                                //db.correos.Add(corr);
                                db.Entry(corr).State = EntityState.Modified;
                                db.SaveChanges();
                                #endregion
                            }

                            telefono telf = new telefono(); //oficina fijo
                            telf = cN.ContactosAmodificar.telefonoFijo;
                            db.Entry(telf).State = EntityState.Modified;
                            db.SaveChanges();
                            //telf.idcontacto = cont.idcontacto;
                            //db.telefonos.Add(telf);

                            telefono celf = new telefono(); //celular de oficina
                            celf = cN.ContactosAmodificar.telefonoCelular;
                            //celf.idcontacto = cont.idcontacto;
                            //db.telefonos.Add(celf);
                            db.Entry(celf).State = EntityState.Modified;
                            db.SaveChanges();

                        }
                        catch (Exception)
                        {

                        }
                    }
                    //ListadoContactosy.Remove(cN.ContactosAmodificar);
                    //ListadoContactosy.Add(cN.ContactosAmodificar);
                    //ListadoContactosx = new List<ContactosModelo>();
                    //int i = 0;
                    //foreach (var ñ in ListadoContactosy)
                    //{
                    //    i++;
                    //    ñ.correlativo = i;
                    //    ListadoContactosx.Add(ñ);
                    //}
                    //RaisePropertyChanged("ListadoContactosx");
                } 
            }
            //Messenger.Default.Unregister<ClientesContactosMensajeModal>(this);
            this.ObtenerDatosContactos();
        }

        private async void MycmdConsultarContacto()
        {
            if (SelectedContactox != null)
            {
                try
                {
                    if (UsuarioPuedeConsultar) //si tiene permisos de crear
                    {
                        currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente2; mensajito.ContactosAmodificar = SelectedContactox; ;
                        CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatosContactos();
                        RaisePropertyChanged("");
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear contactos  del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a consultar", "Seleccione.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a consultar", "", 2);
            }
            FocoPestañaSeleccionada = 1;
            txtBandera = "0";
            txtBanderaNuevo = "0";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "1";
            txtBanderaCancelar = "1";
            txtBanderaRegresar = "1";
        }
        private async void MycmdEliminarContacto()
        {
            if (SelectedContactox != null)
            {
                #region +
                try
                {
                    if (UsuarioPuedeEliminar)
                    {
                        //if (MessageBox.Show("El contacto " + SelectedContactox.nombrecompleto + ", se eliminara logicamente.\n     Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                         var mySettingsk = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Si",
                            NegativeButtonText = "No",
                        };
                        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El contacto " + SelectedContactox.nombrecompleto + ", se eliminara logicamente.\n     Desea continuar?", "Advertencia... ", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                        if (resultk == MessageDialogResult.Affirmative)
                        {
                            #region
                            try
                            {
                                using (SGPTEntidades db = new SGPTEntidades())
                                {
                                    contacto elimcon = db.contactos.Find(SelectedContactox.idcontacto);
                                    elimcon.estadocontacto = "B";
                                    db.Entry(elimcon).State = EntityState.Modified;
                                    db.SaveChanges();
                                    this.ObtenerDatosContactos();
                                }
                                //await dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                await AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.", "Proceso completado.", 2);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Imposible eliminar el contacto seleccionado.\n La base de datos tardo demasiado en responder.\n Consulte a soporte tecnico acerca de este error. "+e.InnerException, "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            #endregion
                        }
                        else
                            //await dlg.ShowMessageAsync(this, "Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...");
                            await AvisaYCerrateVosSolo("Eliminacion abortada. No se realizo ninguna accion.", "Cancelado por el usuario...", 2);
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.");
                        //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Stop);
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear estructura organica del cliente.", "Consulte al administrador acerca de esta restriccion.", 2);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
                #endregion
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a eliminar", "Seleccione.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                //await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a eliminar", "", 1);
               
            }
            FocoPestañaSeleccionada = 1;
            txtBandera = "0";
            txtBanderaNuevo = "0";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "1";
            txtBanderaCancelar = "1";
            txtBanderaRegresar = "1";
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