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
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Globalization;
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;
using MahApps.Metro.Controls.Dialogs;
using Npgsql;

namespace SGPTmvvm.ViewModel
{
    public class tabconenedorClienteExpedientesViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();
        private DialogCoordinator dlg;
        //DAtos generales expediente
        public List<pais> ListadoPaises { get; set; }
        public List<departamento> ListadoDepartamentos { get; set; }
        public List<municipio> ListadoMunicipios { get; set; }
        public List<clasificacione> ListadoTipoEntidades { get; set; }
        public List<actividade> ListadoActividadEconomica { get; set; }
        public List<tipostelefono> ListadoTipoTelefono { get; set; }

        //public List<telefono> ListadoTelefonos { get; set; }
        //ObservableCollection<telefono> _telefonos = new ObservableCollection<telefono>();
        //public List<correo> ListadoCorreos { get; set; }
        //ObservableCollection<correo> _correos = new ObservableCollection<correo>();

        public List<telefonoModelo> ListadoTelefonos { get; set; }
        List<telefono> _telefonos = new List<telefono>();
        public List<correo> ListadoCorreos { get; set; }
        List<correo> _correos = new List<correo>();

        public List<string> lstbDatos { get; set; }        //List<telefono> _telefonos = new List<telefono>();
        //public List<correo> ListadoCorreos { get; set; }
        //ObservableCollection<correo> _correos = new ObservableCollection<correo>();

        //Personal
        public List<estructurasorganica> ListadoEstructuraO { get; set; }
        public List<contacto> ListadoContactos { get; set; }
        public List<ContactosModelo> ListadoContactosx { get; set; }
        public List<ContactosModelo> ListadoContactosy = new List<ContactosModelo>();
        public List<cliente> ListadoClientes { get; set; }

        ////Sistema Contable
        //public List<moneda> ListadoMonedas { get; set; }
        //public List<estructuraestadofinanciero> ListadoEstructuraEstFin { get; set; }
        //public List<int> ListitaCantidadDigitos { get; set; }
        //public List<int> ListitaDias {get;set;}
        //public List<string> ListitaMeses{get;set;}

        permisosrolesusuario permisorolusuariovalidado { get; set; }

        private bool AccionGuardar; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar;
        private bool HayRegistroTemporalCreado; //variable para saber si se debera guardar cambios en una posible modificacion
        //#region Message y currentUsuario
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }

        //private string _messageSistCont;
        //public string MessageSistCont { get { return _messageSistCont; } set { _messageSistCont = value; RaisePropertyChanged("MessageSistCont"); } }

        private int _opcionDeVisitaAqui=0; //1 = nuevo, 2=Editar, 3=Consultar, 4=eliminar (no disponible aqui) , 0=ninguna accion.

        //public tabconenedorClienteExpedientesViewModel(cliente Clientx, usuario currentUsuariox, int opc)
        public tabconenedorClienteExpedientesViewModel(usuario currentUsuariox)
        {
            AccionGuardar = true;
            AccionConsultar = false;
            HayRegistroTemporalCreado = false; //sirve para saber si he creado un cliente temporal

            this.PestañaSeleccionada = 1;
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
            HabilitarTabExpedientes = Visibility.Hidden;
            currentUsuario = currentUsuariox;
            currentCliente = new cliente();
            //this.PermisosUsuarioValidado(); //Obtenemos los permisos del currentUsuario

            //this.cuente(); 
            this.PermisosUsuarioValidado("Clientes");
            this.PruebaInicializadoresEnSegundoPlano();
            //this.ObtenerListadoClientes();

            //this.EscuchandoALaVista(opc);
            //this.ObtenerDatos();
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

        //public class GridItem
        //{
        //    public string Name { get; set; }
        //    public CompanyItem Company { get; set; }
        //    public IEnumerable<CompanyItem> CompanyList { get; set; }
        //}

        //public class CompanyItem
        //{
        //    public int ID { get; set; }
        //    public string Name { get; set; }

        //    public override string ToString() { return Name; }
        //}


        private Visibility _HabilitarTabExpedientes;
        public Visibility HabilitarTabExpedientes
        {
            get { return _HabilitarTabExpedientes; }
            set
            {
                _HabilitarTabExpedientes = value;
                RaisePropertyChanged("HabilitarTabExpedientes");
            }
        }

        public int OpcionDeVisitaAqui
        {
            get { return _opcionDeVisitaAqui; }
            set
            {
                _opcionDeVisitaAqui = value;
                RaisePropertyChanged("OpcionDeVisitaAqui");
            }
        }

        #region : currentUsuario usuario, current cliente

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
            #region +
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
            #endregion
        }

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

        //private sistemascontable _currentSistemaContable;
        //public sistemascontable CurrentSistemaContable
        //{
        //    get { return _currentSistemaContable; }
        //    set 
        //    { 
        //        _currentSistemaContable = value;
        //        RaisePropertyChanged("CurrentSistemaContable");
        //    }
        //}

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

       
        private bool _canExecute=true;

        

        private async void cuente()
        {
            await cuenteUno();
        }

        private void EscuchandoALaVista(int opc)
        {
            FocoPestañaSeleccionada = 0;
            if(opc==1 || opc==2 || opc==3)
            {
                if (opc != 3) //si no es consultar
                    txtBandera = "1";
                else
                    txtBandera = "0";

                txtBanderaNuevo     = "0";
                txtBanderaEditar = "0";
                txtBanderaConsultar ="0";
                txtBanderaEliminar ="0";
                txtBanderaCancelar = "1";
            }
                //using(db=new SGPTEntidades())
                //{
                //    //CurrentSistemaContable = db.sistemascontables.Where(s => s.idsc == currentCliente.idsc).SingleOrDefault();
                //}
            switch (opc)
            {
                case 2: 
                    OpcionDeVisitaAqui=2;EditarCliente(); break;
                case 3: 
                    OpcionDeVisitaAqui=3;txtBandera="0"; ConsultarCliente();  break;
                case 1 : 
                    OpcionDeVisitaAqui=1;NuevoCliente();  break;
                default: break;
            }
        }

        private void EditarCliente()
        {
            #region +
		            //txtBandera = "1"; //permite activar el boton guardar
            AccionGuardar = false;
            AccionConsultar = false;
            Message = "Editar cliente";
            //MessageSistCont = "Editar sistema contable";
            this.campartidaEditarConsultar(); 
	    #endregion
        }
        private void campartidaEditarConsultar()
        {
            #region +
		            try
            {
                using (db=new SGPTEntidades())
                {

                    if (OpcionDeVisitaAqui == 2 || OpcionDeVisitaAqui == 3)
                    {
                        #region +
                        ////ListadoTelefonos = (from t in db.telefonos where t.idnitcliente == currentCliente.idnitcliente select t).ToList();
                        //ListadoTelefonos = db.telefonos.Where(t => t.idnitcliente == currentCliente.idnitcliente).ToList();
                        ////ListadoCorreos = (from c in db.correos where c.idnitcliente == currentCliente.idnitcliente select c).ToList();
                        //ListadoCorreos = db.correos.Where(c => c.idnitcliente == currentCliente.idnitcliente).ToList();


                        ListadoCorreos = db.correos.Where(c => c.idnitcliente == currentCliente.idnitcliente).ToList(); //(usua.correos).ToList();
                        foreach (correo coo in ListadoCorreos) { _correos.Add(coo); }
                        //ListadoTelefonos = (usua.telefonos).ToList();
                        //foreach (telefono too in ListadoTelefonos) { _telefonos.Add(too); }
                        var lListadoTelefonos = db.telefonos.Where(t => t.idnitcliente == currentCliente.idnitcliente).ToList(); //(usua.telefonos).ToList();
                        ListadoTelefonos = new List<telefonoModelo>();
                        foreach (telefono too in lListadoTelefonos)
                        {
                            #region _
                            _telefonos.Add(too);
                            telefonoModelo tte = new telefonoModelo();
                            tte.idtelefono = too.idtelefono;
                            tte.idtt = (int)too.idtt;
                            var b = ListadoTipoTelefono.Find(x => x.idtt == too.idtt);
                            tte.descripciontelefono = b.descripciontt;
                            tte.numerotelefono = too.numerotelefono;
                            tte.estadotelefono = too.estadotelefono;
                            ListadoTelefonos.Add(tte);
                            #endregion
                        }
                        RaisePropertyChanged("ListadoTelefonos");

                        Razonsocialcliente = currentCliente.razonsocialcliente;
                        Fechaconstitucioncliente = DateTime.Parse(currentCliente.fechaconstitucioncliente);
                        SelectedTipoEntidad = ListadoTipoEntidades.Find(x => x.idclasificacion == currentCliente.idclasificacion);
                        Direccioncliente = currentCliente.direccioncliente;
                        SelectedPais = ListadoPaises.Find(y => y.idpais == currentCliente.idpais);
                        if (currentCliente.iddepartamento > 0)
                        {
                            using (db = new SGPTEntidades())
                            {
                                //ListadoDepartamentos = db.departamentos.Where(d => d.idpais == currentCliente.idpais && d.estadodepartamento == "A").ToList();
                                SelectedDepartamento = ListadoDepartamentos.Find(dd => dd.iddepartamento == currentCliente.iddepartamento);
                                //SelectedDepartamento = db.departamentos.Where(x => x.iddepartamento == currentCliente.iddepartamento && x.idpais == currentCliente.idpais).SingleOrDefault();
                                RaisePropertyChanged("SelectedDepartamento");
                            }
                            //SelectedDepartamento = (from d in db.departamentos where d.iddepartamento == currentCliente.iddepartamento && d.idpais == currentCliente.idpais select d).SingleOrDefault();
                        }
                        if (currentCliente.idmunicipio > 0)
                        {
                            using (db = new SGPTEntidades())
                            {
                                //ListadoMunicipios = db.municipios.Where(z => z.iddepartamento == currentCliente.iddepartamento).ToList();
                                SelectedMunicipio = ListadoMunicipios.Find(mm => mm.idmunicipio == currentCliente.idmunicipio);
                                RaisePropertyChanged("SelectedMunicipio");
                            }
                        }
                        SelectedActividadEconomica = ListadoActividadEconomica.Find(l => l.idcodigoactividad == currentCliente.idcodigoactividad);
                        Actividadcliente = currentCliente.actividadcliente;
                        Idnitcliente = currentCliente.idnitcliente;
                        Nrccliente = currentCliente.nrccliente;
                        Paginawebcliente = currentCliente.paginawebcliente;

                        #endregion
                    } 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al recuperar los datos de las reuniones. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error. "+e.InnerException, "Error de compatibilidad de datos");
            } 
	    #endregion
        }

        private void ConsultarCliente()
        {
            #region +
		            //this.inicializarListados();
            //txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            Message = "Consultar cliente";
            //MessageSistCont = "Consultar sistema contable";
            this.campartidaEditarConsultar(); 
	    #endregion
        }

        private void NuevoCliente()
        {
            #region +
		    //txtBandera = "1";
            currentCliente = new cliente();
            //txtBanderaCancelar = "1";
            
            AccionGuardar = true;
            AccionConsultar = false;
            Fechaconstitucioncliente = DateTime.Now;
            Message = "Nuevo cliente";
            //MessageSistCont = "Nuevo sistema contable";
            //HabilitarTabSistemaCont = true; //ojo, despues deshabilitarlo
            //HabilitarTabPersonal = true; //ojo, despues quitar esto


            ListadoTelefonos = new List<telefonoModelo>();
            ListadoCorreos = new List<correo>();

            ListadoContactosx = new List<ContactosModelo>();
            ListadoContactosy = new List<ContactosModelo>();
            ListadoContactos = new List<contacto>();
            Razonsocialcliente = "";
            Fechaconstitucioncliente = DateTime.Now.AddDays(-8);
            SelectedTipoEntidad = null;
            Direccioncliente = "";
            SelectedPais =null;
            SelectedDepartamento = null;
            SelectedMunicipio = null;
            SelectedActividadEconomica = null;
            Actividadcliente = "";
            Idnitcliente = "";
            Nrccliente = "";
            Paginawebcliente = "";
            #endregion        
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
            if (UsuarioPuedeCrear)
            {
                //await dlg.ShowMessageAsync(this, "Nuevo", "");
                //txtBanderaCancelar = "1";
                txtBanderaRegresar = "0"; //deshabilitamos el boton regresar pq en nuevo creamos un registro temporal que debe ser eliminado ne caso que abandone
                HabilitarListadoClientes = Visibility.Hidden;
                HabilitarTabExpedientes = Visibility.Visible;
                this.EscuchandoALaVista(1); 
            }
            else
            {
                await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 2);
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
            if (UsuarioPuedeEditar)
            {
                //await dlg.ShowMessageAsync(this, "editar", "");
                if (ClienteSelected != null)
                {
                    currentCliente = ClienteSelected;

                    HabilitarListadoClientes = Visibility.Hidden;
                    HabilitarTabExpedientes = Visibility.Visible;
                    this.EscuchandoALaVista(2);
                }
                else
                {
                   await AvisaYCerrateVosSolo("Seleccione un cliente para continuar...", "",1);
                   txtBandera = "0";
                   txtBanderaNuevo = "1";
                   txtBanderaEditar = "1";
                   txtBanderaConsultar = "1";
                   txtBanderaEliminar = "1";
                   txtBanderaAgregar = "0";
                   txtBanderaCancelar = "0";
                   txtBanderaRegresar = "1";
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 2);
            } 
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
            if (PestañaSeleccionada==2)
            {
                this.MycmdEliminarPersonal();
            }
            else
            {
                if (UsuarioPuedeEliminar)
                {
                    #region +
                    if (ClienteSelected != null)
                    {
                        #region +
                        try
                        {
                            #region +
                            var mySettingsk = new MetroDialogSettings()
                            {
                                AffirmativeButtonText = "Acepto",
                                NegativeButtonText = "Cancelar",

                            };
                            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro " + Environment.NewLine + ClienteSelected.razonsocialcliente + " se eliminara logicamente del sistema.", "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                            if (resultk == MessageDialogResult.Affirmative)
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
                                        //this.ObtenerDatos();
                                        this.ObtenerListadoClientes();
                                        //this.ObtenerDatosContactos();
                                    }
                                    //await dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                    await AvisaYCerrateVosSolo("El registro se elimino correctamente de manera logica.", "Proceso completado.", 2);
                                    //MessageBox.Show("El registro se elimino correctamente de manera logica.", "Proceso completado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Imposible eliminar el contacto seleccionado.\n La base de datos tardo demasiado en responder.\n Consulte a soporte tecnico acerca de este error.", "Error desconocido...", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                #endregion
                            }
                            else
                                //await dlg.ShowMessageAsync(this, "Eliminacion abortada. No se realizo ninguna accion", "Cancelado por el usuario...");
                                //MessageBox.Show("Eliminacion abortada por el usuario. \nNo se realizo ninguna accion.", "Cancelado por el usuario...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                await AvisaYCerrateVosSolo("Eliminacion abortada por usted.", "No se realizo ninguna accion.", 2);
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
            if (PestañaSeleccionada==2)
            {
                this.MycmdConsultarPersonal();
            }
            else
            {
                if (UsuarioPuedeConsultar)
                {
                    txtBanderaEliminar = "0";
                    txtBanderaAgregar = "0";
                    //await dlg.ShowMessageAsync(this, "Consultar", "");
                    if (ClienteSelected != null)
                    {
                        currentCliente = ClienteSelected;
                        HabilitarListadoClientes = Visibility.Hidden;
                        HabilitarTabExpedientes = Visibility.Visible;
                        this.EscuchandoALaVista(3);
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "Seleccione un cliente para continuar...", "");
                        await AvisaYCerrateVosSolo("Seleccione un cliente para continuar...", "", 1);
                        
                        txtBandera = "0";
                        txtBanderaNuevo  = "1";
                        txtBanderaEditar = "1";
                        txtBanderaConsultar ="1";
                        txtBanderaEliminar  ="1";
                        txtBanderaAgregar = "0";
                        txtBanderaCancelar = "0";
                        txtBanderaRegresar = "1";
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 1);
                } 
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
            this.activarBarraGuardarDatos();
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

            PestañaSeleccionada = 1;
            txtBandera = "0";
            txtBanderaNuevo  = "1";
            txtBanderaEditar = "1";
            txtBanderaConsultar ="1";
            txtBanderaEliminar  ="1";
            txtBanderaAgregar = "0";
            txtBanderaCancelar = "0";
            txtBanderaRegresar = "1";
            HabilitarListadoClientes = Visibility.Visible;
            HabilitarTabExpedientes = Visibility.Hidden;
            if (HayRegistroTemporalCreado) //El registro temporal se crea cuando agrego el personal, porque debo crear puestos en la estructura organica y no hay un idnit real. 
            {
                using(db=new SGPTEntidades())
	            {
                    var temporal = db.clientes.Find(currentCliente.idnitcliente);
                    try
                    {
                        if (temporal != null)
                        {
                            db.clientes.Remove(temporal);
                            db.SaveChanges();
                        }
                    }
                    catch (Exception)
                    {
                       if (temporal != null)
                        {
                            db.clientes.Remove(temporal);
                            db.SaveChanges();
                        }
                    }
	            }
            }
            //this.PruebaInicializadoresEnSegundoPlano();
            this.ObtenerListadoClientes();
            this.PermisosUsuarioValidado("Clientes");
        } 
        #endregion
        /***********************************/


        private ICommand _cmdQuitCorreos_Click;
        public ICommand cmdQuitCorreos_Click
        {
            get
            {
                return _cmdQuitCorreos_Click ?? (_cmdQuitCorreos_Click = new CommandHandler(() => cmdQuitCorreos(), _canExecute));
            }
        }

        private ICommand _cmdAgreCorreos_Click;
        public ICommand cmdAgreCorreos_Click
        {
            get
            {
                return _cmdAgreCorreos_Click ?? (_cmdAgreCorreos_Click = new CommandHandler(() => cmdAgreCorreos(), _canExecute));
            }
        }

        private ICommand _cmdQuitTelefono_Click;
        public ICommand cmdQuitTelefono_Click
        {
            get
            {
                return _cmdQuitTelefono_Click ?? (_cmdQuitTelefono_Click = new CommandHandler(() => cmdQuitTelefono(), _canExecute));
            }
        }

        private ICommand _cmdAgreTelef_Click;
        public ICommand cmdAgreTelef_Click
        {
            get
            {
                return _cmdAgreTelef_Click ?? (_cmdAgreTelef_Click = new CommandHandler(() => cmdAgreTelef(), _canExecute));
            }
        }


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
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al recuperar los permisos del rol del usuario.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este error", "error critico.", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            #endregion

        }
        /********************************************************************/
        #region Permisos del Usuario Logueado

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

        #region campos
        #region CorreoyTelefono
        /*Estos dos campos no pertenecen a ninguna de las dos tablas, pero se agregan para bindiarlas con el List de Telefonos y de Correos
         Ya que los correos y los telefonos se guardaran despues de guardado el usuario y la persona pq necesita el id de el*/
        private string _telefonoT;
        private string _correoT;

        public string TelefonoT { get { return _telefonoT; } set { _telefonoT = value; RaisePropertyChanged("TelefonoT "); } }
        public string CorreoT { get { return _correoT; } set { _correoT = value; RaisePropertyChanged("CorreoT"); } }
        #endregion

        #region Campos DatosGenerales (Clientes)
        public string _idnitcliente;
        private int _idclasificacion;
        private int _idpais;
        private string _idcodigoactividad;
        private int _idsc;
        private int _iddepartamento;
        private int _idmunicipio;
        private string _razonsocialcliente;
        private string _nrccliente;
        private string _direccioncliente;
        private string _actividadcliente;
        private string _paginawebcliente;
        private DateTime _fechaconstitucioncliente;

        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public int Idclasificacion { get { return _idclasificacion; } set { _idclasificacion = value; RaisePropertyChanged("Idclasificacion"); } }
        public int Idpais { get { return _idpais; } set { _idpais = value; RaisePropertyChanged("Idpais"); } }
        public string Idcodigoactividad { get { return _idcodigoactividad; } set { _idcodigoactividad = value; RaisePropertyChanged("Idcodigoactividad"); } }
        public int Idsc { get { return _idsc; } set { _idsc = value; RaisePropertyChanged("Idsc"); } }
        public int Iddepartamento { get { return _iddepartamento; } set { _iddepartamento = value; RaisePropertyChanged("Iddepartamento"); } }
        public int Idmunicipio { get { return _idmunicipio; } set { _idmunicipio = value; RaisePropertyChanged("Idmunicipio"); } }
        public string Razonsocialcliente { get { return _razonsocialcliente; } set { _razonsocialcliente = value; RaisePropertyChanged("Razonsocialcliente"); } }
        public string Nrccliente { get { return _nrccliente; } set { _nrccliente = value; RaisePropertyChanged("Nrccliente"); } }
        public string Direccioncliente { get { return _direccioncliente; } set { _direccioncliente = value; RaisePropertyChanged("Direccioncliente"); } }
        public string Actividadcliente { get { return _actividadcliente; } set { _actividadcliente = value; RaisePropertyChanged("Actividadcliente"); } }
        public string Paginawebcliente { get { return _paginawebcliente; } set { _paginawebcliente = value; RaisePropertyChanged("Paginawebcliente"); } }
        public DateTime Fechaconstitucioncliente { get { return _fechaconstitucioncliente; } set { _fechaconstitucioncliente = value; RaisePropertyChanged("Fechaconstitucioncliente"); } }
        //public string Estadocliente             { get { return _ ; } set { _  = value; RaisePropertyChanged("Estadocliente"); } } 
        #endregion

        
        #endregion

        #region Bindiados

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
        //private string _txtBanderaCat = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        //public string txtBanderaCat
        //{
        //    get { return _txtBanderaCat; }
        //    set { _txtBanderaCat = value; RaisePropertyChanged("txtBanderaCat"); }
        //}
        public ICommand _CmdVolver; //permite volver al listado de clientes.
        public ICommand CmdVolver { get { return _CmdVolver ?? (_CmdVolver = new CommandHandler(() => MyCmdVolver(), _canExecute)); } }


        private void MyCmdVolver() //Sirve para reactivar el panel izquierdo
        {
            //MessageBox.Show("MyCMdVolver");
            Messenger.Default.Send<String>("1", "mensajevacio");
        }

        private clasificacione _selectedTipoEntidad;
        public clasificacione SelectedTipoEntidad
        {
            get { return _selectedTipoEntidad; }
            set
            {
                _selectedTipoEntidad = value;
                RaisePropertyChanged("SelectedTipoEntidad");
            }
        }

        private actividade _SelectedActividadEconomica;
        public actividade SelectedActividadEconomica
        {
            get { return _SelectedActividadEconomica; }
            set { _SelectedActividadEconomica = value; RaisePropertyChanged("SelectedActividadEconomica"); }
        }

        private pais _selectedPais;
        public pais SelectedPais
        {
            get
            {
                return _selectedPais;
            }
            set
            {
                _selectedPais = value;
                RaisePropertyChanged("");
                this.PaisSeleccionado();
            }
        }

        private void PaisSeleccionado()
        {
            if (SelectedPais != null)
            {
                using (db = new SGPTEntidades())
                {
                    ListadoDepartamentos = (from d in db.departamentos where d.idpais == SelectedPais.idpais orderby d.iddepartamento select d).ToList();
                    ListadoMunicipios = null;
                }
                RaisePropertyChanged("ListadoDepartamentos");
            }
            //ListadoMunicipios = (from m in db.municipios orderby m.idmunicipio select m).ToList();
        }
        /*******************************************************************************************************************/
        private departamento _selectedDepartamento;
        public departamento SelectedDepartamento
        {
            get
            {
                return _selectedDepartamento;
            }
            set
            {
                _selectedDepartamento = value;
                RaisePropertyChanged("");
                this.DepartamentoSeleccionado();
            }
        }

        private void DepartamentoSeleccionado()
        {
            if (SelectedDepartamento != null)
            {
                using (db = new SGPTEntidades())
                {
                    ListadoMunicipios = (from m in db.municipios where m.iddepartamento == SelectedDepartamento.iddepartamento orderby m.idmunicipio select m).ToList();
                }
                RaisePropertyChanged("ListadoMunicipios");
            }

        }
        /*******************************************************************************************************************/
        private municipio _selectedMunicipio;
        public municipio SelectedMunicipio
        {
            get
            {
                return _selectedMunicipio;
            }
            set
            {
                _selectedMunicipio = value;
                RaisePropertyChanged("");
            }
        }

        /*******************************************************************************************************************/
        private bool _correoPrincipalChek;
        public bool CorreoPrincipalChek
        {
            get { return _correoPrincipalChek; }
            set
            {
                if (CorreoPrincipalChek != value)
                {
                    _correoPrincipalChek = value;
                    RaisePropertyChanged("CorreoPrincipalChek");
                }
            }
        }
        //Binding SelectedTipoTelefono notifica cuando un valor del combobox de los tipos de telefono ha sido seleccionado
        private tipostelefono _selectedTipoTelefono;
        public tipostelefono SelectedTipoTelefono
        {
            get
            {
                return _selectedTipoTelefono;
            }
            set
            {
                _selectedTipoTelefono = value;
                RaisePropertyChanged("SelectedTipoTelefono");
            }
        }
        /************************************************/
        //Binding selectedCorreoAgregado notifica cuando un valor del combobox de los correos agregados ha sido seleccionado para eliminar
        private correo _selectedCorreoAgregado;
        public correo SelectedCorreoAgregado
        {
            get
            {
                return _selectedCorreoAgregado;
            }
            set
            {
                _selectedCorreoAgregado = value;
                RaisePropertyChanged("SelectedCorreoAgregado");

            }
        }

        /***************************************************/
        private telefonoModelo _selectedTelefonoAgregado;
        public telefonoModelo SelectedTelefonoAgregado
        {
            get
            {
                return _selectedTelefonoAgregado;
            }
            set
            {
                _selectedTelefonoAgregado = value;
                RaisePropertyChanged("selectedTelefonoAgregado");
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
        
        ////Sistemas contables*************************************************
        //private moneda _selectedMoneda;
        //public moneda SelectedMoneda
        //{
        //    get { return _selectedMoneda; }
        //    set 
        //    { 
        //        _selectedMoneda = value;
        //        RaisePropertyChanged("SelectedMoneda");
        //    }
        //}

        //private int _SelectedDiaInicio;
        //public int SelectedDiaInicio
        //{
        //    get { return _SelectedDiaInicio; }
        //    set { _SelectedDiaInicio = value; RaisePropertyChanged("SelectedDiaInicio"); }
        //}

        //private int _SelectedDiaFin;
        //public int SelectedDiaFin
        //{
        //    get { return _SelectedDiaFin; }
        //    set { _SelectedDiaFin = value; RaisePropertyChanged("SelectedDiaFin"); }
        //}

        //private string _SelectedMesInicio;
        //public string SelectedMesInicio
        //{
        //    get { return _SelectedMesInicio; }
        //    set
        //    {
        //        _SelectedMesInicio = value;
        //        RaisePropertyChanged("SelectedMesInicio");
        //    }
        //}

        //private string _SelectedMesFin;
        //public string SelectedMesFin
        //{
        //    get { return _SelectedMesFin; }
        //    set { _SelectedMesFin = value; RaisePropertyChanged("SelectedMesFin"); }
        //}

        //private estructuraestadofinanciero _selectedEstructuraEstFin;
        //public estructuraestadofinanciero SelectedEstructuraEstFin
        //{
        //    get { return _selectedEstructuraEstFin; }
        //    set
        //    {
        //        _selectedEstructuraEstFin = value;
        //        RaisePropertyChanged("SelectedEstructuraEstFin");
        //    }
        //}

        //private int _SelectedCantDigitCtasMayor;
        //public int SelectedCantDigitCtasMayor
        //{
        //    get { return _SelectedCantDigitCtasMayor; }
        //    set 
        //    {
        //        _SelectedCantDigitCtasMayor = value;
        //        RaisePropertyChanged("SelectedCantDigitCtasMayor");
        //    }
        //}

        //private int _SelectedCantDigitRubrosCont;
        //public int SelectedCantDigitRubrosCont
        //{
        //    get { return _SelectedCantDigitRubrosCont; }
        //    set
        //    {
        //        _SelectedCantDigitRubrosCont = value;
        //        RaisePropertyChanged("SelectedCantDigitRubrosCont");
        //    }
        //}

        //SelectedCantDigitCtasMayor
        #endregion
  
        #region HabilitadoresPestañas
        //Ojo las pestañas van a estar deshabilitadas hasta que guarde al nuevo cliente, pq se necesita el NIT del cliente para guardar el personal de contacto y el sistema contable.
        private int _PestañaSeleccionada = 0;
        public int PestañaSeleccionada
        {
            get { return _PestañaSeleccionada; }
            set
            {
                _PestañaSeleccionada = value;
                RaisePropertyChanged("PestañaSeleccionada");
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
        //FocoPestañaSeleccionada

        private bool _HabilitarTabPersonal=false;
        public bool HabilitarTabPersonal
        {
            get { return _HabilitarTabPersonal; }
            set
            {
                _HabilitarTabPersonal = value;
                RaisePropertyChanged("HabilitarTabPersonal");
            }
        }

        //private bool _HabilitarTabSistemaCont=false;
        //public bool HabilitarTabSistemaCont
        //{
        //    get { return _HabilitarTabSistemaCont; }
        //    set 
        //    { 
        //        _HabilitarTabSistemaCont = value;
        //        RaisePropertyChanged("HabilitarTabSistemaCont");
        //    }
        //}

        private bool _HabilitarCargarCatalogo=false;
        public bool HabilitarCargarCatalogo
        {
            get { return _HabilitarCargarCatalogo; }
            set
            {
                _HabilitarCargarCatalogo = value;
                RaisePropertyChanged("HabilitarCargarCatalogo");
            }
        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        /*MiComandito: Datos,Personal,Contable son los que escuchan cuando ha cambiado la pestaña en el tab*/
        private ICommand _miComanditoDatosG;
        #region +
        public ICommand MiComanditoDatosG
        {
            get
            {
                return _miComanditoDatosG ?? (_miComanditoDatosG = new CommandHandler(() => MyPestañaDatosG(), _canExecute));
            }
        }
        private void MyPestañaDatosG() //Al hacer click en pestaña 1
        {
            //dlg.ShowMessageAsync(this, "pestaña 1", "");
            txtBanderaAgregar = "0";
            txtBanderaConsultar = "0";
            txtBanderaEliminar = "0";
            this.PestañaSeleccionada = 1;
            //this.PermisosUsuarioValidado("Clientes");
        } 
        #endregion

        public ICommand _miComanditoPersonal;
        #region +
        public ICommand MiComanditoPersonal { get { return _miComanditoPersonal ?? (_miComanditoPersonal = new CommandHandler(() => MyPestañaMiComanditoPersonal(), _canExecute)); } }
        private void MyPestañaMiComanditoPersonal() //Al hacer click en pestaña 2
        {
            //dlg.ShowMessageAsync(this, "pestaña2","");
            this.PestañaSeleccionada = 2;
            if (OpcionDeVisitaAqui==3) //si es consultar
            {
                txtBanderaConsultar = "1";
                txtBanderaEliminar = "0";
                txtBanderaAgregar = "0"; 
            }
            else
            {
                txtBanderaConsultar = "1";
                txtBanderaEliminar = "1";
                txtBanderaAgregar = "1"; 
            }
            //this.PermisosUsuarioValidado("Contactos");
            if (OpcionDeVisitaAqui!=1)
            this.ObtenerDatosContactos();
        } 
        #endregion

        //public ICommand _miComanditoContable;
        //public ICommand MiComanditoContable { get { return _miComanditoContable ?? (_miComanditoContable = new CommandHandler(() => MyPestañaContable(), _canExecute)); } }

        //private void MyPestañaContable() //Al hacer click en pestaña 3
        //{
        //    this.PermisosUsuarioValidado("Sistemas Contables");
        //    this.ObtenerDatosSistemasCont();
        //    if (OpcionDeVisitaAqui == 2 || _opcionDeVisitaAqui == 3) //string[] partInternos = r.participantesinternoreunion.Split(',');
        //    {
        //        using(db=new SGPTEntidades())
        //        {
        //            CurrentSistemaContable = db.sistemascontables.Where(ss=> ss.idnitcliente == currentCliente.idnitcliente).SingleOrDefault();
        //        }
        //        if (CurrentSistemaContable != null)
        //        {
        //            string[] perinic = CurrentSistemaContable.periodoiniciosc.Split('/');
        //            //string[] perfin = CurrentSistemaContable.periodofinsc.Split('/');
        //            string[] perfin = CurrentSistemaContable.periodofinsc.Split('/');

        //            SelectedDiaInicio = ListitaDias.Find(di => di == int.Parse(perinic[0]));
        //            SelectedMesInicio = ListitaMeses.Find(mi => mi == nommbreMesX(perinic[1]));
        //            SelectedDiaFin = ListitaDias.Find(df => df == int.Parse(perfin[0]));
        //            SelectedMesFin = ListitaMeses.Find(mi => mi == nommbreMesX(perfin[1]));

        //            SelectedCantDigitCtasMayor = ListitaCantidadDigitos.Find(dcm => dcm == CurrentSistemaContable.digitoscuentamayorsc);
        //            SelectedCantDigitRubrosCont = ListitaCantidadDigitos.Find(dcm => dcm == CurrentSistemaContable.digitosrubroscontablessc);
        //            SelectedMoneda = ListadoMonedas.Find(Mo => Mo.idmoneda == CurrentSistemaContable.idmoneda);
        //            SelectedEstructuraEstFin = ListadoEstructuraEstFin.Find(eef => eef.ideef == CurrentSistemaContable.ideef);
        //            if (OpcionDeVisitaAqui == 3)
        //                txtBanderaCat = "0";
        //            else
        //                txtBanderaCat = "1";
        //            HabilitarCargarCatalogo = true;
        //        }
        //    }
        //}

        private string nommbreMesX(string p)
        {
            #region +
            string sMes = "Enero";
            switch (p)
            {
                case "1": sMes = "Enero"; break;
                case "2": sMes = "Febrero"; break;
                case "3": sMes = "Marzo"; break;
                case "4": sMes = "Abril"; break;
                case "5": sMes = "Mayo"; break;
                case "6": sMes = "Junio"; break;
                case "7": sMes = "Julio"; break;
                case "8": sMes = "Agosto"; break;
                case "9": sMes = "Septiembre"; break;
                case "10": sMes = "Octubre"; break;
                case "11": sMes = "Noviembre"; break;
                case "12": sMes = "Diciembre"; break;
                default: break;
            }
            return sMes; 
            #endregion
        }

        private async void ObtenerListadoClientes()
        {
            //GC.Collect();
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoClientes = new List<cliente>();
                    ListadoClientes = (from c in db.clientes where c.estadocliente == "A" orderby c.razonsocialcliente select c).ToList();
                    RaisePropertyChanged("ListadoClientes");
                    this.cuente();
                }
                catch (Exception e)
                {
                    //dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los datos del cliente", "");
                    MessageBox.Show("Error al recuperar el listado de clientes"+e.InnerException);
                }
            }
            if (ListadoClientes == null || ListadoClientes.Count == 0)
                await AvisaYCerrateVosSolo("No posee ningun cliente registrado", "",1);
        }

        private void ObtenerDatos() //Datos de Datos generales pestaña 1
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    //Mouse.OverrideCursor = null;
                    //AvisaYCerrateVosSolo("Verificando los correos del usuario...", "", 1);
                    Mouse.OverrideCursor = Cursors.Wait;
                    ListadoPaises = (from p in db.paises where p.estadopais == "A" orderby p.nombrepais select p).ToList();
                    //RaisePropertyChanged("ListadoPaises");
                    ListadoActividadEconomica = (from a in db.actividades where a.estadoactividad == "A" orderby a.descripcionactividad select a).ToList();
                    //RaisePropertyChanged("ListadoActividadEconomica");
                    ListadoTipoEntidades = (from e in db.clasificaciones where e.estadoclasificacion == "A" orderby e.descripcionclasificacion select e).ToList();
                    ListadoTipoTelefono = (from t in db.tipostelefonos orderby t.idtt select t).ToList(); // .ToList();
                    //RaisePropertyChanged("ListadoTipoTelefono");
                    Mouse.OverrideCursor = null;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error critico al recuperar los datos de la estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. "+e.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void ObtenerDatosContactos() //Pestaña 2
        {
            if (currentCliente!=null && currentCliente.idnitcliente!=null)
            {
                #region +
                using (db = new SGPTEntidades())
                {
                    try
                    {

                        ListadoContactos = new List<contacto>();

                        ListadoContactos = (from c in db.contactos
                                            join e in db.contactoclientes
                                            on c.idcontacto equals e.idcontacto
                                            where e.idnitcliente == currentCliente.idnitcliente && c.estadocontacto == "A"
                                            select c).ToList();

                        ListadoContactosx = new List<ContactosModelo>();
                        if (ListadoContactos != null)
                        {
                            int j = 0;
                            foreach (var a in ListadoContactos)
                            {
                                #region +
                                ContactosModelo c = new ContactosModelo();
                                j++;
                                c.correlativo = j;
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
                                #endregion
                            }
                        }
                        RaisePropertyChanged("ListadoContactosx");
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error critico al recuperar los datos de los contactos del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. "+e.InnerException, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }  
                #endregion
            }
        }

        //private void ObtenerDatosSistemasCont() // Pestaña 3
        //{
        //    using (db = new SGPTEntidades())
        //    {
        //        try
        //        {
        //            ListadoMonedas = new List<moneda>();
        //            ListadoMonedas=(from m in db.monedas where m.estadomoneda=="A" orderby m.nombremoneda select m).ToList();
        //            RaisePropertyChanged("ListadoMonedas");

        //            ListadoEstructuraEstFin = new List<estructuraestadofinanciero>();
        //            ListadoEstructuraEstFin = (from e in db.estructuraestadofinancieros where e.estadoeef == "A" orderby e.descripcioneef select e).ToList();
        //            RaisePropertyChanged("ListadoEstructuraEstFin");

        //            ListitaCantidadDigitos = new List<int>();
        //            for (int i = 1; i <= 10; i++)
        //                ListitaCantidadDigitos.Add(i);
        //            RaisePropertyChanged("ListitaCantidadDigitos");

        //            ListitaDias = new List<int>();
        //            for(int y=1; y<=31; y++)
        //                ListitaDias.Add(y);

        //            RaisePropertyChanged("ListitaDias");

        //            ListitaMeses=new List<string>();
        //            string ene="Enero", feb="Febrero", mar="Marzo", abr="Abril";
        //            string may="Mayo", jun="Junio", jul="Julio",ago="Agosto";
        //            string sep="Septiembre",oct="Octubre", nov="Noviembre", dic="Diciembre";
        //            ListitaMeses.Add(ene);ListitaMeses.Add(feb);ListitaMeses.Add(mar);ListitaMeses.Add(abr);
        //            ListitaMeses.Add(may);ListitaMeses.Add(jun);ListitaMeses.Add(jul);ListitaMeses.Add(ago);
        //            ListitaMeses.Add(sep);ListitaMeses.Add(oct);ListitaMeses.Add(nov);ListitaMeses.Add(dic);
        //            RaisePropertyChanged("ListitaMeses");
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("Error critico al recuperar los datos del sistema contable del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. ", "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //} 
        
        /********************DatosGenerales**************/
        //public ICommand _cmdGuardarDatos;
        //public ICommand cmdGuardarDatos
        //{
        //    get
        //    {
        //        return _cmdGuardarDatos ?? (_cmdGuardarDatos = new CommandHandler(() => activarBarraGuardarDatos(), _canExecute));
        //    }
        //}
        public ICommand _cmdCancelarDatos;
        public ICommand cmdCancelarDatos { get { return _cmdCancelarDatos ?? (_cmdCancelarDatos = new CommandHandler(() => MycmdCancelarDatos(), _canExecute)); } }
       
        /*********************Personal*******************/


        private ICommand _cmdAgregarPersonal;
        public ICommand cmdAgregarPersonal { get { return _cmdAgregarPersonal ?? (_cmdAgregarPersonal = new CommandHandler(() => MycmdAgregarPersonal(), _canExecute)); } }

        //public ICommand _cmdEditarPersonal;
        //public ICommand cmdEditarPersonal { get { return _cmdEditarPersonal?? (_cmdEditarPersonal = new CommandHandler(() => MycmdEditarContacto(), _canExecute)); } }

        private ICommand _cmdConsultarPersonal;
        public ICommand cmdConsultarPersonal { get { return _cmdConsultarPersonal ?? (_cmdConsultarPersonal = new CommandHandler(() => MycmdConsultarPersonal(), _canExecute)); } }//**************************************************************************************************************************************

        private ICommand _cmdEliminarPersonal;
        public ICommand cmdEliminarPersonal { get { return _cmdEliminarPersonal ?? (_cmdEliminarPersonal = new CommandHandler(() => MycmdEliminarPersonal(), _canExecute)); } }

        ///*********************Sistema Contable*******************/

        //private ICommand _cmdCargarCatalogo;
        //public ICommand cmdCargarCatalogo { get { return _cmdCargarCatalogo ?? (_cmdCargarCatalogo = new CommandHandler(() => MycmdCargarCatalogo3(), _canExecute)); } }
        ////public ICommand cmdCargarCatalogo { get { return _cmdCargarCatalogo ?? (_cmdCargarCatalogo = new CommandHandler(() => cargarCat2(), _canExecute)); } }
        ////cargarCat2
        //public ICommand _cmdGuardarSistemaContable;
        //public ICommand cmdGuardarSistemaContable
        //{
        //    get
        //    {
        //        return _cmdGuardarSistemaContable ?? (_cmdGuardarSistemaContable = new CommandHandler(() => activarBarraGuardarSistemaContable(), _canExecute));
        //    }
        //}

        
        //public ICommand _cmdCancelarSistemaContable;
        //public ICommand cmdCancelarSistemaContable { get { return _cmdCancelarSistemaContable ?? (_cmdCancelarSistemaContable = new CommandHandler(() => MycmdCancelarSistemaContable(), _canExecute)); } }

        
       

        /****************************************************/
        //Datos Generales Cliente
        private async void activarBarraGuardarDatos()
        {
            #region +
            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Acepto",
                NegativeButtonText = "No",
                FirstAuxiliaryButtonText = "Cancelar",
            };
            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, mySettingsk);
            if (resultk == MessageDialogResult.Affirmative)
            {
                this.MycmdGuardarDatos();
            }
            else if (resultk == MessageDialogResult.Negative)
            {
                await AvisaYCerrateVosSolo("Operacion guardar ha sido cancelado por usted", "No se guardo nada.", 1);
            }
            else if (resultk == MessageDialogResult.FirstAuxiliary)
            {
                this.CancelarM();
            } 
            #endregion
        }


        private async void MycmdGuardarDatos()
        {
            if (ValidacionManualOk())
            {
                #region v
                //contacto cont = new contacto();
                cliente cli = new cliente();

                using (db = new SGPTEntidades())
                {
                    if (AccionGuardar) 
                    {
                        if (HayRegistroTemporalCreado) //pregunto si hay un cliente temporal en la base, si es cierto, solo lo actualizo
                            cli = db.clientes.Find(currentCliente.idnitcliente);
                        else
                            cli=new cliente(); 
                    }
                    else
                    {
                        //cont = db.contactos.Find(Idcontacto);
                        cli = db.clientes.Find(Idnitcliente);
                    }
                }

                //cli.idnitcliente = Idnitcliente;
                cli.idclasificacion = SelectedTipoEntidad.idclasificacion;
                cli.idpais = SelectedPais.idpais;
                cli.idcodigoactividad = SelectedActividadEconomica.idcodigoactividad;
                if (SelectedDepartamento != null)
                    cli.iddepartamento = SelectedDepartamento.iddepartamento;
                if (SelectedMunicipio != null)
                    cli.idmunicipio = SelectedMunicipio.idmunicipio;
                cli.razonsocialcliente = Razonsocialcliente;
                cli.nrccliente = Nrccliente;
                cli.direccioncliente = Direccioncliente;
                cli.actividadcliente = Actividadcliente;
                cli.paginawebcliente = Paginawebcliente;
                cli.fechaconstitucioncliente = Fechaconstitucioncliente.ToShortDateString();
                cli.estadocliente = "A";

                if (AccionGuardar)
                {
                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            if (ListadoCorreos != null)
                            {
                                cli.correos = ListadoCorreos;
                            }
                            if (_telefonos != null && _telefonos.Count() > 0)
                            {
                                cli.telefonos = _telefonos; // ListadoTelefonos;
                            }
                            if (!HayRegistroTemporalCreado)
                            {
                                cli.idnitcliente = Idnitcliente;
                                db.clientes.Add(cli);
                                db.SaveChanges();
                                currentCliente = cli;
                            }
                            else
                            {
                                #region +
                                //cli.idnitcliente = Idnitcliente; //si cambio aqui el nit, el EntityFramework truena, mejor lo haremos con una insercion manual con NpgsqlConnection
                                db.Entry(cli).State = EntityState.Modified;
                                db.SaveChanges();

                                //Nota: la idea es modificar el id del cliente, pero el problema es que es un PK y el entity Framework truena y no los deja hacer.
                                //vamos a tratar de hacerlo sin entity framework

                                //String cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["SGPTEntidades"].ConnectionString;
                                var caden = System.Configuration.ConfigurationManager.ConnectionStrings["SGPTEntidades"];
                                //var caden2 = "metadata=res://*/Modelo.csdl|res://*/Modelo.ssdl|res://*/Modelo.msl;provider=Npgsql;provider connection string=\"Application Name=Sgpt;Database=SGPT;Host=ec2-52-206-62-65.compute-1.amazonaws.com;Password=Pa$$w0rd;Username=postgres\"";
                                string[] cadens = caden.ToString().Split(';');
                                string[] datab = cadens[3].Split('=');
                                string[] serve = cadens[4].Split('=');
                                string[] passw = cadens[5].Split('=');
                                string[] usuar = cadens[6].Split('=');

                                /****************************************************************/
                                string Base = datab[1];
                                string Server = serve[1];//"ec2-52-206-62-65.compute-1.amazonaws.com";
                                //string Puerto = "5432";
                                string Usuario = usuar[1]; //"postgres";
                                Usuario = Usuario.Substring(0, Usuario.Length - 1);
                                string Pass = passw[1];//"Pa$$w0rd";
                                string connString = "Server= " + Server + "; port=5432; Database =" + Base + "; User id=" + Usuario + "; password= " + Pass;

                                string cmdComando = String.Format("UPDATE sgpt.clientes SET idnitcliente='{0}' WHERE idnitcliente='{1}'", Idnitcliente, currentCliente.idnitcliente);

                                try
                                {
                                    NpgsqlConnection cn = new NpgsqlConnection(connString);
                                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdComando, cn))
                                    {
                                        cn.Open();
                                        pgsqlcommand.ExecuteNonQuery();
                                        cn.Close();
                                        await AvisaYCerrateVosSolo("Actualizado con éxito", "", 1);
                                    }

                                }
                                catch (NpgsqlException ex) { throw ex; }
                                catch (Exception ex) { throw ex; } 
                                #endregion
                                
                            }
                            cli.idnitcliente = Idnitcliente;
                            currentCliente = cli;

                            //if (ListadoCorreos != null)
                            //{
                            //    //foreach(correo cor in ListadoCorreos)
                            //    //{
                            //    //    cor.idnitcliente = currentCliente.idnitcliente;
                            //    //}
                            //    //db.correos.AddRange(ListadoCorreos);
                            //    //db.SaveChanges();
                            //}
                            //if (_telefonos != null && _telefonos.Count() > 0)
                            //{
                            //    //foreach (telefono t in _telefonos)
                            //    //{
                            //    //    t.idnitcliente = currentCliente.idnitcliente;
                            //    //}
                            //    //db.telefonos.AddRange(_telefonos);
                            //    //db.SaveChanges();
                            //}

                            //Tenemos una tabla comodin que elimina la relacion muchos a muchos.
                            if (ListadoContactosx != null)
                            {
                                await AvisaYCerrateVosSolo("Agregando los contactos", "", 1);
                                foreach (var c in ListadoContactosx)
                                {
                                    #region +
                                    using (db = new SGPTEntidades())
                                    {
                                        #region _
                                        try
                                        {
                                            #region _
                                            contacto cont = new contacto();
                                            cont.idcontacto = 100000;
                                            cont.idcargoeo = c.idcargoeo;
                                            cont.nombrescontacto = c.nombrescontacto;
                                            cont.apellidoscontacto = c.apellidoscontacto;
                                            cont.fechainiciofuncioncontacto = c.fechainiciofuncioncontacto;
                                            cont.fechacesefuncioncontacto = c.fechacesefuncioncontacto;
                                            cont.estadocontacto = "A";
                                            cont.observacionescontacto = c.observacionescontacto;
                                            db.contactos.Add(cont);
                                            db.SaveChanges();

                                            //Tenemos una tabla comodin que elimina la relacion muchos a muchos.
                                            contactocliente concli = new contactocliente();
                                            concli.idnitcliente = currentCliente.idnitcliente;
                                            concli.idcontacto = cont.idcontacto;
                                            db.contactoclientes.Add(concli);
                                            db.SaveChanges();
                                            //Preparando para guardar el email del contacto
                                            if (c.correo!=null && c.correo.direccioncorreo!=null)
                                            {
                                                #region +
                                                correo cor = new correo();
                                                cor = c.correo;
                                                cor.idcorreo = 100000;
                                                cor.idcontacto = cont.idcontacto;
                                                //cor.direccioncorreo = Email;
                                                //cor.estadocorreo = "A";
                                                //cor.idcorreo = 100000;
                                                db.correos.Add(cor);
                                                db.SaveChanges(); 
                                                #endregion
                                            }

                                            //Preparando los telefonos
                                            if (c.telefonoFijo!=null && c.telefonoFijo.numerotelefono!=null)
                                            {
                                                #region +
                                                telefono tel = new telefono();
                                                tel = c.telefonoFijo;
                                                tel.idtelefono = 100000;
                                                tel.idcontacto = cont.idcontacto;
                                                //tel.idtt = 5;
                                                //tel.numerotelefono = Telefono;
                                                //tel.estadotelefono = "A";
                                                
                                                db.telefonos.Add(tel);
                                                db.SaveChanges(); 
                                                #endregion
                                            }
                                            if (c.telefonoCelular != null && c.telefonoCelular.numerotelefono != null)
                                            {
                                                #region +
                                                telefono cel = new telefono();
                                                cel = c.telefonoCelular;
                                                cel.idtelefono = 100001;
                                                cel.idcontacto = cont.idcontacto;
                                                //cel.idtt = 2;
                                                //cel.numerotelefono = Celular;
                                                //cel.estadotelefono = "A";
                                                db.telefonos.Add(cel);
                                                db.SaveChanges(); 
                                                #endregion
                                            }

                                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                            #endregion
                                        }
                                        catch (Exception e)
                                        {
                                            MessageBox.Show("Ocurrio un error al guardar en estructura organica.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. "+e.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                        #endregion
                                    } 
                                    #endregion
                                }
                                await AvisaYCerrateVosSolo("Contactos agregados", "", 1);
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("Atencion, No ha ingresado ningun contacto para este cliente","Falta agregar los contactos",1); 
                            }

                            txtBandera = "0"; //Lo desactivo para que ya no pueda guardar nuevamento lo mismo
                            RaisePropertyChanged("txtBandera");
                            Message = "Cliente guardado.";

                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("El registro se guardo con éxito", "Finalizado.!", 1);
                            HabilitarListadoClientes = Visibility.Visible;
                            HabilitarTabExpedientes = Visibility.Hidden;
                            this.ObtenerListadoClientes();
                            txtBandera = "0";
                            txtBanderaNuevo = "1";
                            txtBanderaEditar = "1";
                            txtBanderaConsultar = "1";
                            txtBanderaEliminar = "1";
                            txtBanderaAgregar = "0";
                            txtBanderaCancelar = "0";
                            txtBanderaRegresar = "1";
                            #endregion
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar en clientes.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. "+e.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                        #endregion
                    }
                    //FinalizarAction();

                    //#endregion
                }
                else if (!AccionConsultar)
                {
                    #region v

                    using (db = new SGPTEntidades())
                    {

                        #region _
                        try
                        {
                            db.Entry(cli).State = EntityState.Modified; db.SaveChanges();

                            currentCliente = cli;
                            //Tenemos una tabla comodin que elimina la relacion muchos a muchos.
                            if (ListadoContactosx != null)
                            {
                                await AvisaYCerrateVosSolo("Guardando los contactos", "", 1);
                                foreach (var c in ListadoContactosx)
                                {
                                    #region +
                                    using (db = new SGPTEntidades())
                                    {
                                        #region _
                                        try
                                        {
                                            contacto cont = new contacto();
                                            cont= db.contactos.Find(c.idcontacto);
                                            if (cont != null)
                                            {
                                             //Ojo, lo dejo deshabilitado pq el prototipo no dice que puede actualizar el contacto, debe hacerlo en la opcion 3 del menu lateral (Contactos)   
                                                //cont.idcargoeo = c.idcargoeo;
                                                //cont.nombrescontacto = c.nombrescontacto;
                                                //cont.apellidoscontacto = c.apellidoscontacto;
                                                //cont.fechainiciofuncioncontacto = c.fechainiciofuncioncontacto;
                                                //cont.fechacesefuncioncontacto = c.fechacesefuncioncontacto;
                                                //cont.estadocontacto = "A";
                                                //cont.observacionescontacto = c.observacionescontacto;
                                                //db.Entry(cont).State = EntityState.Modified;
                                                //db.SaveChanges();
                                            }
                                            else //osea que es un nuevo registro de contacto
                                            {
                                                cont = new contacto();
                                                cont.idcontacto = 100000;
                                                //cont.idcontacto = 100000;
                                                cont.idcargoeo = c.idcargoeo;
                                                cont.nombrescontacto = c.nombrescontacto;
                                                cont.apellidoscontacto = c.apellidoscontacto;
                                                cont.fechainiciofuncioncontacto = c.fechainiciofuncioncontacto;
                                                cont.fechacesefuncioncontacto = c.fechacesefuncioncontacto;
                                                cont.estadocontacto = "A";
                                                cont.observacionescontacto = c.observacionescontacto;
                                                db.contactos.Add(cont);
                                                db.SaveChanges();
                                                //Tenemos una tabla comodin que elimina la relacion muchos a muchos.
                                                //contactocliente concli = new contactocliente();
                                                //concli.idnitcliente = currentCliente.idnitcliente;
                                                //concli.idcontacto = cont.idcontacto;
                                                //db.contactoclientes.Add(concli);
                                                db.SaveChanges();


                                                //Preparando para guardar el email del contacto
                                                if (c.correo != null && c.correo.direccioncorreo != null)
                                                {
                                                    #region +
                                                    correo cor = new correo();
                                                    cor = c.correo;
                                                    cor.idcorreo = 100000;
                                                    cor.idcontacto = cont.idcontacto;
                                                    //cor.direccioncorreo = Email;
                                                    //cor.estadocorreo = "A";
                                                    //cor.idcorreo = 100000;
                                                    db.correos.Add(cor);
                                                    db.SaveChanges();
                                                    #endregion
                                                }

                                                //Preparando los telefonos
                                                if (c.telefonoFijo != null && c.telefonoFijo.numerotelefono != null)
                                                {
                                                    #region +
                                                    telefono tel = new telefono();
                                                    tel = c.telefonoFijo;
                                                    tel.idtelefono = 100000;
                                                    tel.idcontacto = cont.idcontacto;
                                                    //tel.idtt = 5;
                                                    //tel.numerotelefono = Telefono;
                                                    //tel.estadotelefono = "A";

                                                    db.telefonos.Add(tel);
                                                    db.SaveChanges();
                                                    #endregion
                                                }
                                                if (c.telefonoCelular != null && c.telefonoCelular.numerotelefono != null)
                                                {
                                                    #region +
                                                    telefono cel = new telefono();
                                                    cel = c.telefonoCelular;
                                                    cel.idtelefono = 100001;
                                                    cel.idcontacto = cont.idcontacto;
                                                    //cel.idtt = 2;
                                                    //cel.numerotelefono = Celular;
                                                    //cel.estadotelefono = "A";
                                                    db.telefonos.Add(cel);
                                                    db.SaveChanges();
                                                    #endregion
                                                }
                                            }
                                            #region _

                                            

                                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                                            #endregion
                                        }
                                        catch (Exception e)
                                        {
                                            MessageBox.Show("Ocurrio un error al guardar en estructura organica.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. " + e.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                                //AvisaYCerrateVosSolo("Contactos agregados", "", 1);
                            }

                            txtBandera = "0"; //Lo desactivo para que ya no pueda guardar nuevamento lo mismo
                            RaisePropertyChanged("txtBandera");
                            Message = "Cliente guardado.";

                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("El registro se guardo con éxito", "Finalizado.!", 1);
                            HabilitarListadoClientes = Visibility.Visible;
                            HabilitarTabExpedientes = Visibility.Hidden;
                            this.ObtenerListadoClientes();
                            txtBandera = "0";
                            txtBanderaNuevo = "1";
                            txtBanderaEditar = "1";
                            txtBanderaConsultar = "1";
                            txtBanderaEliminar = "1";
                            txtBanderaAgregar = "0";
                            txtBanderaCancelar = "0";
                            txtBanderaRegresar = "1";
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ocurrio un error al guardar los cambios en estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico.", "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                            //this.cmdCancelar();
                        }
                        #endregion

                    }
                    //this.FinalizarAction();
                    #endregion
                }

                #endregion
                HayRegistroTemporalCreado = false; //Lo reinicio para permitir un nuevo registro de clientes.
            }

        }

        private bool ValidacionManualOk()
        {
            return true;
        }
        private async void MycmdCancelarDatos()
        {
            //this.MyCmdVolver();
            HabilitarTabExpedientes = Visibility.Hidden;
            HabilitarListadoClientes = Visibility.Visible;
            await AvisaYCerrateVosSolo("Cancelado por usted.", "", 1);
        }

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
            this.ObtenerDatos();
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
  
        /*****************************************************************************************/
        //Personal
        private async void MycmdAgregarPersonal()
        {
            Random rnd = new Random();
            try
            {
                if (UsuarioPuedeCrear) //si tiene permisos de crear
                {
                    if (currentCliente == null || currentCliente.idnitcliente==null)
                    {
                        try
                        {
                            using (db = new SGPTEntidades())
                            {
                                cliente cl = new cliente();
                                string aleat = rnd.Next(100, 999).ToString();
                                cl.idnitcliente = "9999-999999-"+aleat+"-A";
                                cl.idclasificacion = 1; //persona natural
                                cl.idpais = 1;
                                cl.razonsocialcliente = "Temporal, sin guardar aun.";
                                cl.nrccliente = "Temporal";
                                cl.direccioncliente = "Temporal Borrar si";
                                cl.fechaconstitucioncliente = DateTime.Now.ToShortDateString();
                                cl.estadocliente = "B";
                                db.clientes.Add(cl);
                                db.SaveChanges();
                                HayRegistroTemporalCreado = true;
                                currentCliente = cl;
                            }

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error "+e.InnerException);
                            this.CancelarM();
                        }
                    }
                    Messenger.Default.Register<ClientesContactosMensajeModal>(this, "Expedientes", (ClientesContactosMensajeModal) => ControlContactoCapturado(ClientesContactosMensajeModal));

                    ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.ContactosAmodificar = new ContactosModelo(); mensajito.llamadoDesde = "Expedientes";
                    CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
                    var res = mivista.ShowDialog();
                    Messenger.Default.Unregister<ClientesContactosMensajeModal>(this); //mato el mensaje,para que libere memoria. pueda ser que la vista externa no mande nada.
                    //this.ObtenerDatosContactos();
                    //RaisePropertyChanged("");
                }
                else
                {
                    //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                    await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes", "Consulte al administrador acerca de esta restriccion.", 2);
                    //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear contactos  del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al comparar los permisos del usuario "+e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ControlContactoCapturado(ClientesContactosMensajeModal ClientesContactosMensajeModal)
        {
            if (ClientesContactosMensajeModal.ContactosAmodificar != null)
            {
                ListadoContactosy.Add(ClientesContactosMensajeModal.ContactosAmodificar);
                ListadoContactosx = new List<ContactosModelo>();
                int i = 0;
                foreach (var ñ in ListadoContactosy)
                {   
                    i++;
                    ñ.correlativo= i;
                    ListadoContactosx.Add(ñ);
                }
                RaisePropertyChanged("ListadoContactosx");
            }
            //Messenger.Default.Unregister<ClientesContactosMensajeModal>(this);
        }

        //private void ControlAdministracionUsuarioValidadoMensaje(AdministracionUsuarioValidadoMensaje administracionUsuarioValidadoMensaje)
        //{
        //    //Recibe al usuario que se ha validado
        //    currentUsuario = administracionUsuarioValidadoMensaje.usuarioMensaje;
        //    usuarioModelo = administracionUsuarioValidadoMensaje.usuarioModelo;
        //    Messenger.Default.Unregister<AdministracionUsuarioValidadoMensaje>(this, tokenRecepcionAdmon);
        //    this.PermisosUsuarioValidado("Usuarios");

        //}


        private void MycmdEditarContacto() //Deshabilitado por hoy
        {
            #region +
            //try
            //{
            //    if (UsuarioPuedeEditar) //si tiene permisos de crear
            //    {
            //        //ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.ContactosAmodificar = ;
            //        //CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
            //        //var res = mivista.ShowDialog();
            //        //this.ObtenerDatosContactos();
            //        //RaisePropertyChanged("");
            //    }
            //    else
            //    {
            //        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
            //        MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear contactos  del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario", "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
            //} 
            #endregion
        } //Deshabilitado por hoy
        private async void MycmdConsultarPersonal() 
        {
            if (SelectedContactox != null)
            {
                try
                {
                    if (UsuarioPuedeConsultar) //si tiene permisos de crear
                    {
                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.ContactosAmodificar = SelectedContactox; ;
                        CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
                        var res = mivista.ShowDialog();
                        this.ObtenerDatosContactos();
                        RaisePropertyChanged("");
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes", "Consulte al administrador acerca de esta restriccion.", 3);
                        //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear contactos  del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
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
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a consultar", "Sin seleccion", 1);
            }
        }
        private async void MycmdEliminarPersonal() //Pestaña 2 ok
        {
            //MessageBox.Show("cmdEliminarPersonal");
            if (SelectedContactox != null)
            {
                #region +
                try
                {
                    if (UsuarioPuedeEliminar)
                    {
                        //if (MessageBox.Show("El contacto " + SelectedContactox.nombrecompleto + ", se eliminara logicamente.\n     Desea continuar?", "Advertencia... " + DateTime.Now.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        //{
                        var mySettingsk = new MetroDialogSettings()
                        {
                            AffirmativeButtonText = "Acepto",
                            NegativeButtonText = "Cancelar",

                        };
                        MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro " + Environment.NewLine +SelectedContactox.nombrecompleto  +" se eliminara logicamente del sistema.", "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                        if (resultk == MessageDialogResult.Affirmative)
                        {
                            #region
                            try
                            {
                                using (SGPTEntidades db = new SGPTEntidades())
                                {
                                    contacto elimcon = db.contactos.Find(SelectedContactox.idcontacto);
                                    elimcon.estadocontacto = "B";
                                    elimcon.fechacesefuncioncontacto = DateTime.Now.ToShortDateString();
                                    db.Entry(elimcon).State = EntityState.Modified;
                                    db.SaveChanges();
                                    this.ObtenerDatosContactos();
                                }
                                //await dlg.ShowMessageAsync(this, "El registro se elimino correctamente de manera logica.", "Proceso completado.");
                                //MessageBox.Show("El registro se elimino correctamente de manera logica.", "Proceso completado.", MessageBoxButton.OK, MessageBoxImage.Information);
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
                            //MessageBox.Show("Eliminacion abortada por el usuario. \nNo se realizo ninguna accion.", "Cancelado por el usuario...", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            await AvisaYCerrateVosSolo("Eliminacion abortada por el usuario."+Environment.NewLine+"No se realizo ninguna accion.", "Cancelado por usted...",2);
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.");
                        await AvisaYCerrateVosSolo("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes", "Consulte al administrador acerca de esta restriccion.", 2);
                        //MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para eliminar.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Stop);
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
                await AvisaYCerrateVosSolo("Debe seleccionar el registro a eliminar", "Seleccione.", 1);
            }
        }
        

        /*Gestiona los correos y los telefonos de los clientes.*/
        #region AgregarCorreos, QuitarCorreos, AgregarTelefono,QuitarTelefono

        #region +

        #endregion

        public async void cmdAgreTelef()
        {
            //bool noencontrado = _telefonos.Exists(x => x.numerotelefono == SelectedTelefonoAgregado.numerotelefono);
            //if (noencontrado)
            //{
            if (SelectedTipoTelefono != null && TelefonoT.Length >= 8 && TelefonoT.Length <= 9)
            {
                bool encontrado = _telefonos.Exists(x => x.numerotelefono == TelefonoT);
                if (!encontrado)
                {
                    #region +
                    try
                    {
                        #region
                        telefono telef = new telefono();
                        if (_telefonos != null)
                            telef.idtelefono = _telefonos.Count() + 1;
                        else
                            telef.idtelefono = 1;
                        telef.idtt = SelectedTipoTelefono.idtt;
                        //telef.idduipersona = Idduipersonay;
                        //telef.idnitcliente = Idnitcliente;
                        telef.numerotelefono = TelefonoT;
                        telef.estadotelefono = "A";
                        _telefonos.Add(telef);

                        ListadoTelefonos = new List<telefonoModelo>();
                        foreach (var a in _telefonos)
                        {
                            telefonoModelo tte = new telefonoModelo();
                            tte.idtelefono = a.idtelefono;
                            tte.idtt = (int)a.idtt;
                            var b = ListadoTipoTelefono.Find(x => x.idtt == a.idtt);
                            tte.descripciontelefono = b.descripciontt;
                            tte.numerotelefono = a.numerotelefono;
                            tte.estadotelefono = a.estadotelefono;
                            ListadoTelefonos.Add(tte);
                        }

                        //ListadoTelefonos = _telefonos.ToList();

                        RaisePropertyChanged("ListadoTelefonos");
                        //MessageBox.Show("Telefono agregado.", "Finalizado..", MessageBoxButton.OK, MessageBoxImage.Information);
                        await AvisaYCerrateVosSolo("El telefono ha sido agregado", "Finalizado.!",2);

                        //await cuenteUno(10);
                        //await dlg.HideMetroDialogAsync(this,null);
                        TelefonoT = "";
                        SelectedTipoTelefono = null;
                        RaisePropertyChanged("TelefonoT");
                        if (!AccionGuardar) //Entonces es Editar
                        {
                            //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                            Random rnd = new Random();
                            using (db = new SGPTEntidades())
                            {
                                try
                                {
                                    telef.idtelefono = rnd.Next(1000, 100000);
                                    db.telefonos.Add(telef);
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocurrio un error al actualizar " + ex.InnerException, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al agregar el telefono. Verifique el campo DUI tenga valor" + ex.InnerException, "Falta de Datos", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    #endregion
                }
                else
                {
                    //await dlg.ShowMessageAsync(this, "El numero de telefono ya existe", "");
                    await AvisaYCerrateVosSolo("El numero de telefono ya existe", "Ingrese uno nuevo", 1);

                }
            }
            else
            {
                //MessageBox.Show("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI.", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                await AvisaYCerrateVosSolo("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de NIT", "Falta informacion",1);
            }
            //}
        }
        private async void cmdQuitTelefono()
        {
            //TimeSpan interval;
            //string value = "5.001";

            //TimeSpan.TryParseExact(value, "ss\\.fff", null, out interval);
            //Window owner = CreateAutoCloseWindow(interval);
            //MessageBoxResult result = MessageBox.Show(owner, "hola camaleon");
            if (SelectedTelefonoAgregado != null && true)
            {
                var tp = _telefonos.Find(x => x.idtelefono == SelectedTelefonoAgregado.idtelefono && x.numerotelefono == SelectedTelefonoAgregado.numerotelefono && x.idtt == SelectedTelefonoAgregado.idtt);
                if (!AccionGuardar) //Entonces es Editar
                {
                    //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            tp.estadotelefono = "B";//SelectedTelefonoAgregado.estadotelefono = "B"; //le cambiamos el estado a Borrado logico.
                            db.Entry(tp).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al actualizar" + ex.InnerException, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }
                //telefono to = 

                _telefonos.Remove(tp);
                ListadoTelefonos = null;
                ListadoTelefonos = new List<telefonoModelo>();
                foreach (var a in _telefonos)
                {
                    telefonoModelo tte = new telefonoModelo();
                    tte.idtelefono = a.idtelefono;
                    tte.idtt = (int)a.idtt;
                    var b = ListadoTipoTelefono.Find(x => x.idtt == a.idtt);
                    tte.descripciontelefono = b.descripciontt;
                    tte.numerotelefono = a.numerotelefono;
                    tte.estadotelefono = a.estadotelefono;
                    ListadoTelefonos.Add(tte);
                }
                //ListadoTelefonos = _telefonos.ToList();
                RaisePropertyChanged("ListadoTelefonos");
                await AvisaYCerrateVosSolo("Telefono eliminado", "", 1);
            }

        }

        private async void cmdAgreCorreos()
        {
            #region +
            if (Idnitcliente != null && Idnitcliente.Length >= 17 && CorreoT != null && CorreoT.Length >= 7 && CorreoT.Length <= 60)
            {
                bool correoencontrado = _correos.Exists(y => y.direccioncorreo == CorreoT);
                if (!correoencontrado)
                {
                    Random rnd = new Random();
                    try
                    {
                        #region
                        correo Corre = new correo();
                        Corre.idcorreo = rnd.Next(1, 10000);
                        //Corre.idfirma = SelectedTipoFirma.idfirma;
                        //Corre.idduipersona = Idduipersonay;
                        //Corre.idnitcliente = Idnitcliente;
                        Corre.direccioncorreo = CorreoT;
                        Corre.principalcorreo = CorreoPrincipalChek;
                        Corre.estadocorreo = "A";
                        _correos.Add(Corre);
                        ListadoCorreos = _correos.ToList();
                        await AvisaYCerrateVosSolo("El correo ha sido agregado", "Finalizado.!",1);
                        //await cuenteUno(10);
                        //await dlg.HideMetroDialogAsync(this, null);
                        //MessageBox.Show("Correo agregado.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                        CorreoPrincipalChek = false; //reiniciamos para que quede deshabilitado
                        CorreoT = "";
                        RaisePropertyChanged("");
                        if (!AccionGuardar) //Entonces es Editar
                        {
                            //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                            using (db = new SGPTEntidades())
                            {
                                try
                                {
                                    db.correos.Add(Corre);
                                    db.SaveChanges();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Ocurrio un error al actualizar" + ex.InnerException, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                                }
                            }
                        }
                        #endregion
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al agregar el Correo.\n La base de datos gtardo demasiado en responder.\n Informe a soporte tecnico acerca de este error. " + ex.InnerException, "Error al guardar", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El E-mail ya existe", "");
                }
            }
            else
            {
                //MessageBox.Show("Ingrese un correo valido, verifique el DUI no este vacio", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                await dlg.ShowMessageAsync(this, "Ingrese un correo valido, verifique el NIT no este vacio", "Falta informacion");
            }
            #endregion
        }

        private void cmdQuitCorreos()
        {
            #region +
            if (SelectedCorreoAgregado != null)
            {
                if (!AccionGuardar) //Entonces es Editar
                {
                    //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            SelectedCorreoAgregado.estadocorreo = "B"; //le cambiamos el estado a Borrado logico.
                            db.Entry(SelectedCorreoAgregado).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al eliminar el correo.\n la base de datos tardo demasiado en responder. \n informe a soporte tecnico acerca de este error." + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }
                _correos.Remove(SelectedCorreoAgregado);
                ListadoCorreos = _correos.ToList();
                RaisePropertyChanged("ListadoCorreos");
            }
            #endregion
        }
        #endregion


        
        //private void activarBarraGuardarSistemaContable()
        //{
        //    //DejarseVer = Visibility.Visible;
        //    RaisePropertyChanged();
        //    MessageBoxResult Guarde = MessageBox.Show("Esta seguro que desea guardar los cambios?", "Guardando cambios", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
        //    switch (Guarde)
        //    {
        //        case MessageBoxResult.Yes: this.MycmdGuardarCatalogo(); break;
        //        case MessageBoxResult.No: MessageBox.Show("Operacion guardar ha sido cancelado..", "No se guardo nada", MessageBoxButton.OK, MessageBoxImage.Exclamation); break;
        //        case MessageBoxResult.Cancel: this.MycmdCancelarDatos(); break;
        //    }
        //}



        private string NumeroMes(string mes)
        {
            string Mmes = "0";
            switch (mes)
            {
                #region +
                case "Enero": Mmes = "1"; break;
                case "Febrero": Mmes = "2"; break;
                case "Marzo": Mmes = "3"; break;
                case "Abril": Mmes = "4"; break;
                case "Mayo": Mmes = "5"; break;
                case "Junio": Mmes = "6"; break;
                case "Julio": Mmes = "7"; break;
                case "Agosto": Mmes = "8"; break;
                case "Septiembre": Mmes = "9"; break;
                case "Octubre": Mmes = "10"; break;
                case "Noviembre": Mmes = "11"; break;
                case "Diciembre": Mmes = "12"; break;
                //default: break; 
                #endregion
            }
            return Mmes;
        }
        private async Task cuenteUno()
        {
            await Task.Delay(1);
        }
        //private bool ValidacionManualCatOk()
        //{
        //    return true;
        //}
        //private void MycmdCancelarSistemaContable()
        //{
        //    this.MyCmdVolver();
        //}

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