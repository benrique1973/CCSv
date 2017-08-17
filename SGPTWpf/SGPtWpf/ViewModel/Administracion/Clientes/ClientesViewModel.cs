using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Model.Menus;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System;
using System.Windows.Input;
using SGPTmvvm.Soporte;
using SGPTmvvm.Model;
using System.Data.Entity;
using System.Globalization;
using SGPTWpf.SGPtWpf.Messages.Genericos;

namespace SGPTWpf.ViewModel.Administracion
{
    /// <summary>
    /// Atencion, se necesita enviar un mensaje al menu principal para que des-active los demas menus, 
    /// pq cuando selecciono un opcion dejo inhabilitado el panel izquierdo, el cual se activara hasta que regrese a mostrar el listado de los clientes.
    /// 
    /// </summary>
    public sealed class ClientesViewModel : ViewModeloBase
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
        public List<cliente> ListadoClientes { get; set; }
        public List<EncargosModelo> ListadoEncargos { get; set; }
        permisosrolesusuario permisorolusuariovalidado { get; set; }


        #region ViewModel Properties : tokenRecepcionAdmon

        public const string tokenRecepcionAdmonPropertyName = "tokenRecepcionAdmon";

        private string _tokenRecepcionAdmon;

        public string tokenRecepcionAdmon
        {
            get
            {
                return _tokenRecepcionAdmon;
            }

            set
            {
                if (_tokenRecepcionAdmon == value)
                {
                    return;
                }

                _tokenRecepcionAdmon = value;
                RaisePropertyChanged(tokenRecepcionAdmonPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : tokenControlarMenu

        public const string tokenControlarMenuPropertyName = "tokenControlarMenu";

        private string _tokenControlarMenu;

        public string tokenControlarMenu
        {
            get
            {
                return _tokenControlarMenu;
            }

            set
            {
                if (_tokenControlarMenu == value)
                {
                    return;
                }

                _tokenControlarMenu = value;
                RaisePropertyChanged(tokenControlarMenuPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties

        private bool _canExecute = true;

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

        private cliente _clienteSelected;
        public cliente ClienteSelected
        {
            get { return _clienteSelected; }
            set
            {
                _clienteSelected = value;
                RaisePropertyChanged("ClienteSelected");
            }
        }
        private EncargosModelo _encargoSelected;
        public EncargosModelo EncargoSelected
        {
            get { return _encargoSelected; }
            set
            {
                _encargoSelected = value;
                RaisePropertyChanged("EncargoSelected");
            }
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

        //Listado de Encargos
        private Visibility _habilitarListadoEncargos = Visibility.Hidden;
        public Visibility HabilitarListadoEncargos
        {
            get { return _habilitarListadoEncargos; }
            set
            {
                _habilitarListadoEncargos = value;
                RaisePropertyChanged("HabilitarListadoEncargos");
            }
        }

        private Visibility _habilitarFrame;
        public Visibility HabilitarFrame
        {
            get { return _habilitarFrame; }
            set
            {
                _habilitarFrame = value;
                RaisePropertyChanged("HabilitarFrame");
            }
        }

        private Visibility _habilitarBotonesExpedientes = Visibility.Hidden;
        public Visibility HabilitarBotonesExpedientes
        {
            get { return _habilitarBotonesExpedientes; }
            set
            {
                _habilitarBotonesExpedientes = value;
                RaisePropertyChanged("HabilitarBotonesExpedientes");
            }
        }

        private bool _habilitarMenuIzquierdo = true;
        public bool HabilitarMenuIzquierdo
        {
            get { return _habilitarMenuIzquierdo; }
            set
            {
                _habilitarMenuIzquierdo = value;
                RaisePropertyChanged("HabilitarMenuIzquierdo");
            }
        }

        #region Vistas SGPT

        #region ViewModel Properties : Vistas

        #region Prueba Listas

        public const string ListaVistaPropertyName = "ListaVista";

        private List<MenuClientes> _ListaVista;

        public List<MenuClientes> ListaVista
        {
            get
            {
                return _ListaVista;
            }

            set
            {
                if (_ListaVista == value) return;

                _ListaVista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaVistaPropertyName);
            }
        }

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private MenuClientes _currentEntidad;

        public MenuClientes currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                _currentEntidad = value;

                // Update bindings, no broadcast
                //RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion

        #endregion
        #endregion
        #region Propiedades


        public const string VisiblePropertyName = "Visible";


        private bool _Visible = false;

        public bool Visible
        {
            get
            {
                return _Visible;
            }

            set
            {
                if (_Visible == value)
                {
                    return;
                }

                _Visible = value;
                RaisePropertyChanged(VisiblePropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel PropertiesPrivadas

        private DialogCoordinator dlg;

        #endregion

        #endregion



        public ClientesViewModel()
        {
            dlg = new DialogCoordinator();
            _tokenRecepcionAdmon = "Clientes" + "Administracion";
            _tokenControlarMenu = "ClienteControlMenu";
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            HabilitarFrame = Visibility.Hidden;
            HabilitarListadoClientes = Visibility.Visible;
            HabilitarMenuIzquierdo = true;
            RegistrarComandos();
            this.ObtenerDatos();

            ListaVista = actualizarListadoMenu();
            //opcion[0].NavigateExecute();

            Messenger.Default.Register<String>(this, "mensajevacio", CtrlX); //mensaje vacio sirve para controlar el panel izquierdo


            Messenger.Default.Register<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon, (administracionUsuarioValidadoMensaje) => ControlAdministracionUsuarioValidadoMensaje(administracionUsuarioValidadoMensaje));

        }

        public List<MenuClientes> actualizarListadoMenu()
        {
            List<MenuClientes> opcion = new List<MenuClientes>
            {
                new MenuClientes() { ViewDisplay="Expedientes"},
                new MenuClientes() { ViewDisplay="Encargos"},
                new MenuClientes() { ViewDisplay="Contactos"},

            };
            return opcion;
        }
        private void CtrlX(string msj)
        {
            //var a = msj;
            if (msj == "1")
                this.ObtenerDatos();
            else if (msj == "2")
                this.ObtenerDatosEncargos();
            this.enviarMensajeHabilitar();
        }




        private void ControlAdministracionUsuarioValidadoMensaje(AdministracionUsuarioValidadoMensaje administracionUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = administracionUsuarioValidadoMensaje.usuarioMensaje;
            inicializacionTerminada();
            Messenger.Default.Unregister<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon);
            Mouse.OverrideCursor = null;
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionAdmon);
        }

        private bool UsuarioValidado(String QueTabla)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            using (db = new SGPTEntidades())
            {
                #region MyRegion
                try
                {
                    //extrayendo los permisos dados al usuario segun su rol
                    permisorolusuariovalidado = new permisosrolesusuario();
                    if (QueTabla == "Expedientes")
                        permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == "Clientes" select p).SingleOrDefault();
                    else
                        permisorolusuariovalidado = (from p in db.permisosrolesusuarios where p.idusuario == currentUsuario.idusuario && p.idrol == currentUsuario.idrol && p.nombreopcionpru == QueTabla select p).SingleOrDefault();
                    UsuarioPuedeCrear = permisorolusuariovalidado.crearpru;
                    UsuarioPuedeEliminar = permisorolusuariovalidado.eliminarpru;
                    UsuarioPuedeConsultar = permisorolusuariovalidado.consultarpru;
                    UsuarioPuedeEditar = permisorolusuariovalidado.editarpru;
                    UsuarioPuedeImprimir = permisorolusuariovalidado.impresionpru;
                    UsuarioPuedeExportar = permisorolusuariovalidado.exportacionpru;
                    UsuarioPuedeRevisar = permisorolusuariovalidado.revisarpru;
                    UsuarioPuedeAprobar = permisorolusuariovalidado.aprobarpru;
                    if (
                        UsuarioPuedeCrear ||
                        UsuarioPuedeEliminar ||
                        UsuarioPuedeConsultar ||
                        UsuarioPuedeEditar ||
                        UsuarioPuedeImprimir ||
                        UsuarioPuedeExportar ||
                        UsuarioPuedeRevisar ||
                        UsuarioPuedeAprobar)
                        return true;
                }
                catch (Exception)
                {
                    dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los permisos del rol del usuario", "La base de datos tardo demasido en responder.");
                }
                #endregion
            }
            Mouse.OverrideCursor = null;
            return false;

        }
        //#endregion

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





        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            bool inhabilitar = false;
            Messenger.Default.Send<bool>(inhabilitar, tokenControlarMenu);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            bool habilitar = true;
            Messenger.Default.Send<bool>(habilitar, tokenControlarMenu);
        }


        #region ShowWindowCommand
        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            VerVistaCrudCommand = new RelayCommand(Mostrar);

            //opcPanelLateral = new RelayCommand(CualOpc);
            ExpedientesCommand = new RelayCommand(Expedientes);
            EncargosCommand = new RelayCommand(Encargos);
            ContactosCommand = new RelayCommand(Contactos);
        }


        #region Comandos Expedientes

        public ICommand _cmdCrear;
        public ICommand cmdCrearExp
        {
            get
            {
                return _cmdCrear ?? (_cmdCrear = new CommandHandler(() => MycmdCrearExpediente(), _canExecute));
            }
        }
        public ICommand _cmdEditar;
        public ICommand cmdEditarExp
        {
            get
            {
                return _cmdEditar ?? (_cmdEditar = new CommandHandler(() => MycmdEditarExpediente(), _canExecute));
            }
        }

        public ICommand _cmdConsultar;
        public ICommand cmdConsultarExp { get { return _cmdConsultar ?? (_cmdConsultar = new CommandHandler(() => MycmdConsultarExpediente(), _canExecute)); } }

        public ICommand _cmdEliminar;
        public ICommand cmdEliminarExp { get { return _cmdEliminar ?? (_cmdEliminar = new CommandHandler(() => MycmdEliminarExpediente(), _canExecute)); } }
        #endregion

        #region Metodos CrearExpediente
        private void MycmdCrearExpediente()
        {
            if (currentEntidad.ViewDisplay == "Expedientes")
            {
                //MessageBox.Show("Crear Exp");
                HabilitarListadoClientes = Visibility.Hidden;
                RaisePropertyChanged("HabilitarListadoClientes");
                HabilitarBotonesExpedientes = Visibility.Hidden;
                RaisePropertyChanged("HabilitarBotonesExpedientes");
                HabilitarFrame = Visibility.Visible;
                RaisePropertyChanged("HabilitarFrame");
                cliente cl = new cliente();
                currentEntidad.NavigateExecute(cl, currentUsuario, 1);
                currentEntidad = null;
                ClienteSelected = null;
                HabilitarMenuIzquierdo = false;
                this.enviarMensajeInhabilitar(); //no furula pq desactiva todo
            }
            else if (currentEntidad.ViewDisplay == "Encargos") // ok. funcional
            {
                HabilitarListadoClientes = Visibility.Hidden;
                HabilitarListadoEncargos = Visibility.Hidden;
                RaisePropertyChanged("HabilitarListadoClientes");
                HabilitarFrame = Visibility.Visible;
                RaisePropertyChanged("HabilitarFrame");
                HabilitarBotonesExpedientes = Visibility.Hidden;
                RaisePropertyChanged("HabilitarBotonesExpedientes");
                currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 1);
                currentEntidad = null;
                ClienteSelected = null;
                HabilitarMenuIzquierdo = false;
                this.enviarMensajeInhabilitar();
            }
        }

        private void MycmdEditarExpediente()
        {
            if (currentEntidad.ViewDisplay == "Expedientes")
            {
                if (ClienteSelected != null)
                {
                    //MessageBox.Show("Crear Exp");
                    HabilitarListadoClientes = Visibility.Hidden;
                    RaisePropertyChanged("HabilitarListadoClientes");
                    HabilitarBotonesExpedientes = Visibility.Hidden;
                    RaisePropertyChanged("HabilitarBotonesExpedientes");
                    HabilitarFrame = Visibility.Visible;
                    RaisePropertyChanged("HabilitarFrame");
                    cliente cl = ClienteSelected;
                    currentEntidad.NavigateExecute(cl, currentUsuario, 2);
                    currentEntidad = null;
                    ClienteSelected = null;
                    HabilitarMenuIzquierdo = false;
                    this.enviarMensajeInhabilitar();
                }
                else
                {
                    dlg.ShowMessageAsync(this, "Seleccione un cliente para continuar...", "");
                }
            }
            else if (currentEntidad.ViewDisplay == "Encargos")//**************************************************************************************************************************************
            {
                MessageBox.Show("La opcion editar en Encargos aun no ha sido habilitada");
                //this.enviarMensajeInhabilitar();

                //HabilitarListadoClientes = Visibility.Hidden;
                //HabilitarListadoEncargos = Visibility.Hidden;
                //RaisePropertyChanged("HabilitarListadoClientes");
                //HabilitarFrame = Visibility.Visible;
                //RaisePropertyChanged("HabilitarFrame");
                //HabilitarBotonesExpedientes = Visibility.Hidden;
                //RaisePropertyChanged("HabilitarBotonesExpedientes");
                //currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 0);
                //currentEntidad = null;
                //ClienteSelected = null;
                //HabilitarMenuIzquierdo = false;
            }
        }

        private void MycmdConsultarExpediente()
        {
            if (currentEntidad.ViewDisplay == "Expedientes")
            {
                if (ClienteSelected != null)
                {
                    //MessageBox.Show("Crear Exp");
                    HabilitarListadoClientes = Visibility.Hidden;
                    RaisePropertyChanged("HabilitarListadoClientes");
                    HabilitarBotonesExpedientes = Visibility.Hidden;
                    RaisePropertyChanged("HabilitarBotonesExpedientes");
                    HabilitarFrame = Visibility.Visible;
                    RaisePropertyChanged("HabilitarFrame");
                    cliente cl = ClienteSelected;
                    currentEntidad.NavigateExecute(cl, currentUsuario, 3);
                    currentEntidad = null;
                    ClienteSelected = null;
                    HabilitarMenuIzquierdo = false;
                    this.enviarMensajeInhabilitar();
                }
                else
                {
                    dlg.ShowMessageAsync(this, "Seleccione un cliente para continuar...", "");
                }
            }
            else if (currentEntidad.ViewDisplay == "Encargos")
            {
                MessageBox.Show("La opcion Consultar en Encargos aun no ha sido habilitada");
                //this.enviarMensajeInhabilitar();

                //HabilitarListadoClientes = Visibility.Hidden;
                //HabilitarListadoEncargos = Visibility.Hidden;
                //RaisePropertyChanged("HabilitarListadoClientes");
                //HabilitarFrame = Visibility.Visible;
                //RaisePropertyChanged("HabilitarFrame");
                //HabilitarBotonesExpedientes = Visibility.Hidden;
                //RaisePropertyChanged("HabilitarBotonesExpedientes");
                //currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 0);
                //currentEntidad = null;
                //ClienteSelected = null;
                //HabilitarMenuIzquierdo = false;
            }
        }

        private void MycmdEliminarExpediente()
        {
            if (currentEntidad.ViewDisplay == "Expedientes")
            {
                if (ClienteSelected != null)
                {
                    #region +
                    try
                    {
                        #region +
                        if (UsuarioPuedeEliminar)
                        {
                            #region +
                            if (MessageBox.Show("El cliente " + ClienteSelected.razonsocialcliente + ", se eliminara logicamente.\n     Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                            {
                                #region
                                try
                                {
                                    using (SGPTEntidades db = new SGPTEntidades())
                                    {
                                        cliente cli = db.clientes.Find(ClienteSelected.idnitcliente);
                                        cli.estadocliente = "B";
                                        db.Entry(cli).State = EntityState.Modified;
                                        db.SaveChanges();
                                        this.ObtenerDatos();
                                        //this.ObtenerDatosContactos();
                                    }
                                    //await dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                    MessageBox.Show("El registro se elimino correctamente de manera logica.", "Proceso completado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Imposible eliminar el contacto seleccionado.\n La base de datos tardo demasiado en responder.\n Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                #endregion
                            }
                            else
                                //await dlg.ShowMessageAsync(this, "Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...");
                                MessageBox.Show("Eliminacion abortada por el usuario. \nNo se realizo ninguna accion.", "Cancelado por el usuario...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            #endregion
                        }
                        else
                        {
                            //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.");
                            MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                        #endregion
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrio un error al comparar los permisos del usuario", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Stop);
                    }
                    #endregion
                }
                else
                {
                    dlg.ShowMessageAsync(this, "Seleccione un cliente para continuar...", "");
                }
            }
            else if (currentEntidad.ViewDisplay == "Encargos")
            {
                MessageBox.Show("La opcion Eliminar en Encargos aun no ha sido habilitada");
                //HabilitarListadoClientes = Visibility.Hidden;
                //HabilitarListadoEncargos = Visibility.Hidden;
                //RaisePropertyChanged("HabilitarListadoClientes");
                //HabilitarFrame = Visibility.Visible;
                //RaisePropertyChanged("HabilitarFrame");
                //HabilitarBotonesExpedientes = Visibility.Hidden;
                //RaisePropertyChanged("HabilitarBotonesExpedientes");
                //currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 0);
                //currentEntidad = null;
                //ClienteSelected = null;
                //HabilitarMenuIzquierdo = false;
            }
        }
        #endregion


        public ICommand _miComanditoConta;
        public ICommand MiComanditoCont { get { return _miComanditoConta ?? (_miComanditoConta = new CommandHandler(() => MyPestañaMiComanditoConta(), _canExecute)); } }

        private void MyPestañaMiComanditoConta()
        {
            //MessageBox.Show("Recibido");
            //this.PermisosUsuarioValidado("Contactos");
        }


        public void ObtenerDatos()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            HabilitarFrame = Visibility.Hidden;
            RaisePropertyChanged("HabilitarFrame");
            HabilitarListadoClientes = Visibility.Visible;
            RaisePropertyChanged("HabilitarListadoClientes");
            HabilitarMenuIzquierdo = true;
            RaisePropertyChanged("HabilitarMenuIzquierdo");

            GC.Collect();
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoClientes = (from c in db.clientes where c.estadocliente == "A" orderby c.razonsocialcliente select c).ToList();
                    RaisePropertyChanged("ListadoClientes");
                }
                catch (System.Exception)
                {
                    dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los datos del cliente", "");
                }
            }
            if (ListadoClientes == null || ListadoClientes.Count == 0)
                dlg.ShowMessageAsync(this, "No posee ningun cliente registrado", "");
            Mouse.OverrideCursor = null;
        }

        public void ObtenerDatosEncargos()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            HabilitarListadoClientes = Visibility.Hidden;
            HabilitarListadoEncargos = Visibility.Visible;
            HabilitarFrame = Visibility.Hidden;
            HabilitarBotonesExpedientes = Visibility.Visible;
            HabilitarMenuIzquierdo = true;

            GC.Collect();
            using (db = new SGPTEntidades())
            {
                #region +
                //try
                //{
                //    #region +
                //    ListadoEncargos = new List<EncargosModelo>();
                //    var exped = (from e in db.encargos where e.estadoencargo == "A" orderby e.fechacreadoencargo descending select e).ToList();
                //    if (exped != null || ListadoEncargos.Count != 0)
                //    {
                //        foreach (var e in exped)
                //        {
                //            #region +
                //            EncargosModelo d = new EncargosModelo();
                //            d.idencargo = e.idencargo;
                //            d.idnitcliente = e.idnitcliente;
                //            var x = ListadoClientes.Find(z => z.idnitcliente == e.idnitcliente);
                //            d.razonsocialcliente = x.razonsocialcliente;
                //            d.idta = (int)e.idta;
                //            //d.idsc = (int)e.idsc;
                //            d.fechacreadoencargo = e.fechacreadoencargo;
                //            d.tipoclienteencargo = (bool)e.tipoclienteencargo;
                //            d.etapaencargo = e.etapaencargo;
                //            d.costoejecucionencargo = (decimal)e.costoejecucionencargo;
                //            d.honorariosencargo = (decimal)e.costoejecucionencargo;
                //            d.fechainiperauditencargo = e.fechainiperauditencargo;
                //            if (!String.IsNullOrEmpty(e.fechainiperauditencargo) && !String.IsNullOrEmpty(e.fechafinperauditencargo))
                //                d.añoencargo = (DateTime.Parse(e.fechainiperauditencargo)).Month.ToString() + " / " + (DateTime.Parse(e.fechainiperauditencargo)).Year.ToString() + "  -  " + (DateTime.Parse(e.fechafinperauditencargo)).Month.ToString() + " / " + (DateTime.Parse(e.fechafinperauditencargo)).Year.ToString();
                //            else
                //                d.añoencargo = "N/D";
                //            d.fechafinperauditencargo = e.fechafinperauditencargo;
                //            ListadoEncargos.Add(d);
                //            #endregion
                //        }
                //        RaisePropertyChanged("ListadoEncargos");
                //    } 
                //    #endregion
                //}
                //catch (System.Exception)
                //{
                //    dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los datos del cliente", "");
                //}

                #endregion
                try
                {
                    #region +
                    ListadoEncargos = new List<EncargosModelo>();
                    var joji = db.encargos.ToList();
                    List<encargo> exped = new List<encargo>();
                    exped = (from g in db.encargos where g.estadoencargo == "A" select g).ToList();//(from e in db.encargos where e.estadoencargo == "A" orderby e.fechacreadoencargo descending select e).ToList();
                    if (exped != null || ListadoEncargos.Count != 0)
                    {
                        var ta = db.tiposauditorias.ToList();
                        foreach (var e in exped)
                        {
                            #region +
                            EncargosModelo d = new EncargosModelo();
                            d.idencargo = e.idencargo;
                            d.idnitcliente = e.idnitcliente;
                            var x = ListadoClientes.Find(z => z.idnitcliente == e.idnitcliente);
                            d.razonsocialcliente = x.razonsocialcliente;
                            d.idta = (int)e.idta;
                            //d.idsc = (int)e.idsc;
                            d.nombreTa = ta.Find(v => v.idta == (int)e.idta).descripcionta;
                            d.fechacreadoencargo = e.fechacreadoencargo;
                            d.tipoclienteencargo = (bool)e.tipoclienteencargo;
                            d.etapaencargo = e.etapaencargo;
                            switch (e.etapaencargo)
                            {
                                case "I": d.nombreetapaencargo = "Inicial"; break;
                                case "P": d.nombreetapaencargo = "En proceso"; break;
                                case "R": d.nombreetapaencargo = "Revisado"; break;
                                case "C": d.nombreetapaencargo = "Cerrado"; break;
                            }

                            d.costoejecucionencargo = (decimal)e.costoejecucionencargo;
                            d.honorariosencargo = (decimal)e.costoejecucionencargo;
                            d.fechainiperauditencargo = e.fechainiperauditencargo;
                            if (!String.IsNullOrEmpty(e.fechainiperauditencargo) && !String.IsNullOrEmpty(e.fechafinperauditencargo))
                                d.añoencargo = (DateTime.Parse(e.fechainiperauditencargo)).Month.ToString() + " / " + (DateTime.Parse(e.fechainiperauditencargo)).Year.ToString() + "  -  " + (DateTime.Parse(e.fechafinperauditencargo)).Month.ToString() + " / " + (DateTime.Parse(e.fechafinperauditencargo)).Year.ToString();
                            else
                                d.añoencargo = "N/D";
                            d.fechafinperauditencargo = e.fechafinperauditencargo;
                            ListadoEncargos.Add(d);
                            #endregion
                        }
                        RaisePropertyChanged("ListadoEncargos");
                    }
                    #endregion
                }
                catch (System.Exception)
                {
                    dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los datos del cliente", "");
                }
            }
            if (ListadoEncargos == null || ListadoEncargos.Count == 0)
                dlg.ShowMessageAsync(this, "No posee ningun encargo registrado", "");
            Mouse.OverrideCursor = null;
        }

        private void Contactos()
        {
            // MessageBox.Show("Contactos");
            //currentEntidad.ViewDisplay = "Contactos";
            currentEntidad = ListaVista[2];
            this.Mostrar();
        }


        private void Encargos()
        {
            //MessageBox.Show("Encargos");
            //currentEntidad.ViewDisplay = "Encargos";
            this.ObtenerDatosEncargos();
            currentEntidad = ListaVista[1];
            this.Mostrar();
        }

        private void Expedientes()
        {
            //MessageBox.Show("Expedientes");
            //currentEntidad.ViewDisplay = "Expedientes";
            currentEntidad = ListaVista[0];
            this.Mostrar();
        }

        #endregion
        #region ViewModel Commands


        public RelayCommand VerVistaCrudCommand { get; set; }
        public RelayCommand VerVistaHerramientasCommand { get; set; }

        public RelayCommand opcPanelLateral { get; set; }

        public RelayCommand ExpedientesCommand { get; set; }
        public RelayCommand EncargosCommand { get; set; }
        public RelayCommand ContactosCommand { get; set; }

        #endregion

        #region Redireccion de comandos
        public void Mostrar()
        {
            if (currentEntidad != null)
            {
                if (UsuarioValidado(currentEntidad.ViewDisplay))
                {

                    try
                    {
                        switch (currentEntidad.ViewDisplay)
                        {
                            case "Contactos":
                                #region +
                                // if (ClienteSelected != null)
                                //{
                                //    HabilitarListadoClientes = Visibility.Hidden;
                                //    //RaisePropertyChanged("HabilitarListadoClientes");
                                //    HabilitarBotonesExpedientes = Visibility.Hidden;
                                //    //RaisePropertyChanged("HabilitarBotonesExpedientes");
                                //    HabilitarFrame = Visibility.Visible;
                                //    //RaisePropertyChanged("HabilitarFrame");

                                //    currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 0);
                                //    currentEntidad = null;
                                //    ClienteSelected = null;

                                //    HabilitarMenuIzquierdo = false;
                                //    this.enviarMensajeInhabilitar(); //no furula pq desactiva todo
                                //}
                                HabilitarListadoClientes = Visibility.Hidden;
                                HabilitarListadoEncargos = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarListadoClientes");
                                HabilitarFrame = Visibility.Visible;
                                RaisePropertyChanged("HabilitarFrame");
                                HabilitarBotonesExpedientes = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarBotonesExpedientes");
                                currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 0);
                                currentEntidad = null;
                                ClienteSelected = null;
                                HabilitarMenuIzquierdo = false;
                                this.enviarMensajeInhabilitar();
                                #endregion
                                //MessageBox.Show("Crear Exp");

                                break;
                            case "Encargos":
                                //if (ClienteSelected != null)
                                //{
                                HabilitarListadoClientes = Visibility.Hidden;
                                //RaisePropertyChanged("HabilitarListadoClientes");
                                HabilitarListadoEncargos = Visibility.Visible;
                                //RaisePropertyChanged("HabilitarListadoEncargos");
                                HabilitarFrame = Visibility.Hidden;
                                //RaisePropertyChanged("HabilitarFrame");

                                //HabilitarBotonesExpedientes = Visibility.Visible;
                                //RaisePropertyChanged("HabilitarBotonesExpedientes");

                                //currentEntidad.NavigateExecute(ClienteSelected, currentUsuario,0);
                                //currentEntidad = null;
                                //ClienteSelected = null;
                                //this.enviarMensajeHabilitar();


                                HabilitarListadoClientes = Visibility.Hidden;
                                HabilitarListadoEncargos = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarListadoClientes");
                                HabilitarFrame = Visibility.Visible;
                                RaisePropertyChanged("HabilitarFrame");
                                HabilitarBotonesExpedientes = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarBotonesExpedientes");
                                currentEntidad.NavigateExecute(ClienteSelected, currentUsuario, 1);
                                currentEntidad = null;
                                ClienteSelected = null;
                                HabilitarMenuIzquierdo = false;
                                this.enviarMensajeInhabilitar();

                                break;
                            case "Expedientes":
                                //HabilitarListadoClientes = Visibility.Visible;
                                //HabilitarListadoEncargos = Visibility.Hidden;
                                //HabilitarFrame = Visibility.Hidden;
                                //HabilitarBotonesExpedientes = Visibility.Visible;


                                HabilitarListadoClientes = Visibility.Hidden;
                                HabilitarListadoEncargos = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarListadoClientes");
                                HabilitarFrame = Visibility.Visible;
                                RaisePropertyChanged("HabilitarFrame");
                                HabilitarBotonesExpedientes = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarBotonesExpedientes");

                                HabilitarListadoClientes = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarListadoClientes");
                                HabilitarBotonesExpedientes = Visibility.Hidden;
                                RaisePropertyChanged("HabilitarBotonesExpedientes");
                                HabilitarFrame = Visibility.Visible;
                                RaisePropertyChanged("HabilitarFrame");
                                cliente cl = new cliente();
                                currentEntidad.NavigateExecute(cl, currentUsuario, 1);
                                currentEntidad = null;
                                ClienteSelected = null;
                                HabilitarMenuIzquierdo = false;
                                this.enviarMensajeInhabilitar(); //no furula pq desactiva todo

                                break;
                        }
                        //Recarga del listado
                        ListaVista = actualizarListadoMenu();
                    }
                    catch (Exception er)
                    {
                        MessageBox.Show("Error inesperado al Mostrar los clientes", "Error desconocido" + er.Message, MessageBoxButton.OK, MessageBoxImage.Stop);
                    }

                }
                else
                    dlg.ShowMessageAsync(this, "No tiene suficientes permisos para usar esta opcion: " + currentEntidad.ViewDisplay, "");
            }

        }
        #endregion
        #endregion

    }
}