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
using Microsoft.Win32;
using Microsoft.Office.Interop.Excel;
using SGPTWpf.SGPtmvvm.Modales.ImportarArchivos;
using SGPTWpf.SGPtmvvm.Model;
using System.Globalization;
using System.Threading.Tasks;
using SGPtmvvm.Mensajes;
using SGPTWpf.Model;
namespace SGPTmvvm.ViewModel
{
    public class tabconenedorClienteEncargosViewModel : INotifyPropertyChanged //, ViewModeloBase
    {
        public SGPTEntidades db = new SGPTEntidades();
        private DialogCoordinator dlg;

        private static int _Errors;
        private bool EstaEditandoFilaEnPersonal;
        private bool EstaEditandoFilaEnCronograma;
        public static int Errors
        {
            get { return _Errors; }
            set { _Errors = value; }
        }//Para controllar los errores de edición

        private bool habilitarComprobacionDeAuditoria;

        //*********************************************************************************************************************
        #region Listas de objetos 
        public List<EncargosModelo> ListadoEncargos { get; set; }
        //*************
        public List<cliente> ListadoClientes { get; set; }
        public List<tiposauditoria> ListadoTiposAuditoria { get; set; }
        permisosrolesusuario permisorolusuariovalidado { get; set; }
        public List<string> ListadoTiposClienteRecurrente { get; set; }
        public List<string> ListadoEtapasEncargos { get; set; }

        //**************Personal*****************************
        public List<usuariospersonas> ListadoUsuarios { get; set; }
        public List<AsignacionesModelo> ListadoPersonalAsignado { get; set; }
        public List<AsignacionesModelo> ListadoPersonalAsignado2 { get; set; }


        //Sistema Contable
        public List<moneda> ListadoMonedas { get; set; }
        public List<estructuraestadofinanciero> ListadoEstructuraEstFin { get; set; }
        public List<int> ListitaCantidadDigitos { get; set; }
        public List<int> ListitaDias { get; set; }
        public List<string> ListitaMeses { get; set; }
        public List<elemento> ListadoElementosD { get; set; }
        public List<ElementosContablesModelo> ListadoElementos { get; set; }
        //***************Cronograma****************************************
        public List<procesosauditoria> ListadoProcesosAuditoria { get; set; }
        public List<visita> ListadoVisitas { get; set; }
        public List<detalleCronogramaModelo> ListadoDetalleCronograma2 = new List<detalleCronogramaModelo>();
        public List<detalleCronogramaModelo> ListadoDetalleCronograma { get; set; }
        //public List<L>
        public List<AsignacionesModelo> ListadoPersonalSeleccionadoxEtapa = new List<AsignacionesModelo>();

        //******************Presupuesto*************************************
        public class Presupuesto
        {
            #region +
            public int correlativo { get; set; }
            public string etapaauditoria { get; set; }
            public int personalasignado { get; set; }
            public decimal preciomediohora { get; set; }
            public decimal horastotales { get; set; }
            public decimal MontoPorEtapa { get; set; }
            #endregion
        }
        public List<Presupuesto> ListadoPresupuesto { get; set; } 
        #endregion
        //*********************************************************************************************************************

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

        private sistemascontable _currentSistemaContable;
        public sistemascontable CurrentSistemaContable
        {
            get { return _currentSistemaContable; }
            set
            {
                _currentSistemaContable = value;
                RaisePropertyChanged("CurrentSistemaContable");
            }
        }
        private ElementosContablesModelo _SelectedElemento;
        public ElementosContablesModelo SelectedElemento
        {
            get { return _SelectedElemento; }
            set { _SelectedElemento = value; RaisePropertyChanged("SelectedElemento"); }
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

        private EncargosModelo _currentEncargo;

        public EncargosModelo currentEncargo
        {
            get
            {
                return _currentEncargo;
            }

            set
            {
                if (_currentEncargo == value) return;

                _currentEncargo = value;

                RaisePropertyChanged("currentEncargo");
            }
        }


        private cronograma _currentCronograma;

        public cronograma currentCronograma
        {
            get
            {
                return _currentCronograma;
            }

            set
            {
                if (_currentCronograma == value) return;

                _currentCronograma = value;

                RaisePropertyChanged("currentCronograma");
            }
        }

        #endregion

        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }

        private string _MessagePresupuesto;
        public string MessagePresupuesto { get { return _MessagePresupuesto; } set { _MessagePresupuesto = value; RaisePropertyChanged("MessagePresupuesto"); } }
        private string _messageSistCont;
        public string MessageSistCont { get { return _messageSistCont; } set { _messageSistCont = value; RaisePropertyChanged("MessageSistCont"); } }

        private bool _canExecute=true;
        //private bool canSave;
        int _opcionDeVisitaAqui = 0; //1 = nuevo, 2=Editar, 3=Consultar, 4=eliminar (no disponible aqui) , 0=ninguna accion.
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

        //public tabconenedorClienteEncargosViewModel(cliente Clientx, usuario currentUsuariox, int opc)
        #region EDCatalogoCuentasMainModel

        private SGPTWpf.Model.MainModel _mainModel = null;

        public SGPTWpf.Model.MainModel EDCatalogoCuentasMainModel
        {
            get
            {
                return _mainModel;
            }

            set
            {
                _mainModel = value;
            }
        }


        #endregion
        public tabconenedorClienteEncargosViewModel(usuario currentUsuariox)
        {
            Mouse.OverrideCursor = null;
            Errors = 0;
            habilitarComprobacionDeAuditoria = false;
            AccionGuardar = true;
            AccionConsultar = false;
            //HayRegistroTemporalCreado = false; //sirve para saber si he creado un cliente temporal

            this.FocoPestañaSeleccionada =0;
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
            txtBanderaCargarCatalogo = "0";
            EDCatalogoCuentasMainModel = new SGPTWpf.Model.MainModel();
            Honorariosencargo = "0";
            dlg = new DialogCoordinator();

            EstaEditandoFilaEnPersonal=false;
            EstaEditandoFilaEnCronograma=false;

            HabilitarListadoEncargos = Visibility.Visible;
            HabilitarTabEncargos = Visibility.Hidden;
            HabilitarAceptarCancelarModifPersonal = Visibility.Hidden;
            HabilitarAceptarCancelarModifCronograma = Visibility.Hidden;
            HabilitarBarraDeMenuSuperior = true;
            HabilitarDatagridPersonal = true;
            HabilitarDatagridCronograma = true;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            ListadoPersonalAsignado2 = new List<AsignacionesModelo>();
            currentUsuario = currentUsuariox;
            //currentCliente = Clientx;
            //this.PermisosUsuarioValidado(); //Obtenemos los permisos del currentUsuario
            this.PermisosUsuarioValidado("Encargos");
            //this.EscuchandoALaVista(opc);

            Mouse.OverrideCursor = Cursors.Wait;
            this.ObtenerDatos();
            this.ObtenerDatosSistemasCont();
            this.ObtenerListadoEncargos();
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
            switch (opc)
            {
                case 2:
                    OpcionDeVisitaAqui = 2; EditarEncargo(); break;
                case 3:
                    OpcionDeVisitaAqui = 3; txtBandera = "0"; ConsultarEncargo(); break;
                case 1:
                    OpcionDeVisitaAqui = 1; NuevoEncargo(); break;
                default: break;
            }
        }

        /***********Acoplamiento de Botones segun barra de menu 20/02/2017*************************************************************************
         */
        #region + Botones Barra
        private ICommand _Nuevo;
        public ICommand cmdNuevoEncargo_Click
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
                currentEncargo = new EncargosModelo();
                
                habilitarcmbCliente = true;
                FocoPestañaSeleccionada = 0;
                //await dlg.ShowMessageAsync(this, "Nuevo", "");
                //txtBanderaCancelar = "1";
                txtBanderaRegresar = "0"; //deshabilitamos el boton regresar pq en nuevo creamos un registro temporal que debe ser eliminado ne caso que abandone
                txtBanderaCancelar = "1";
                HabilitarListadoEncargos = Visibility.Hidden;
                HabilitarTabEncargos = Visibility.Visible;
                this.habilitarComprobacionDeAuditoria = true;
                this.ObtenerDatosSistemasCont();
                this.EscuchandoALaVista(1); 
            }
            else
            {
                await AvisaYCerrateVosSolo("No posee suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 1);
            }
        }

        private ICommand _Editar;
        public ICommand cmdEditarEncargos_Click
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
                if (EncargoSelected != null)
                {
                    if (PestañaSeleccionada==2 || PestañaSeleccionada==4) //si ya esta editando y selecciona la pestaña de personal o la de cronograma
                    {
                        #region +
                        if (PestañaSeleccionada == 2)
                        {
                            if (SelectedPersonalAsignado != null)
                            {
                                EstaEditandoFilaEnPersonal = true;
                                SelectedUsuarioPersonal = ListadoUsuarios.Find(x => x.idusuario == SelectedPersonalAsignado.idusuario);
                                HorasPlaneadasPersonal = SelectedPersonalAsignado.horasplanasignacion;
                                CostoHoraUs = SelectedPersonalAsignado.preciohoraasignacion.ToString();
                                HabilitarAceptarCancelarModifPersonal = Visibility.Visible;
                                HabilitarBarraDeMenuSuperior = false;
                                HabilitarDatagridPersonal = false;
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("Seleccione la fila que desea editar", "", 1);
                            }
                        }
                        if (PestañaSeleccionada == 4)
                        {
                            if (SelectedDetalleCronograma!=null)
                            {
                                EstaEditandoFilaEnCronograma = true;
                                SelectedProcesosAuditoria = ListadoProcesosAuditoria.Find(x => x.idpa == SelectedDetalleCronograma.idpa);
                                SelectedVisita = ListadoVisitas.Find(y => y.idvisita == SelectedDetalleCronograma.idvisita);
                                Actividaddc = SelectedDetalleCronograma.actividaddc;
                                Fechainicialdc = SelectedDetalleCronograma.fechainicialdc;
                                Fechafinaldc = SelectedDetalleCronograma.fechafinaldc;
                                HabilitarAceptarCancelarModifCronograma = Visibility.Visible;
                                HabilitarBarraDeMenuSuperior = false;
                                HabilitarDatagridCronograma = false;
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("Seleccione la fila que desea editar", "", 1);
                            }
                        } 
                        #endregion
                    }
                    else
                    {
                        habilitarcmbCliente = false;
                        currentEncargo = EncargoSelected;
                        using (db = new SGPTEntidades())
                        {
                            currentCliente = db.clientes.Find(currentEncargo.idnitcliente);
                        }


                        HabilitarListadoEncargos = Visibility.Hidden;
                        HabilitarTabEncargos = Visibility.Visible;

                        txtBanderaCancelar = "1";
                        txtBanderaEliminar = "1";
                        txtBanderaCargarCatalogo = "0";
                        this.habilitarComprobacionDeAuditoria = false;
                        FocoPestañaSeleccionada = 1;
                        this.EscuchandoALaVista(2); 
                    }
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
                    habilitarcmbCliente = true;
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 2);
            }
        }

        private ICommand _Eliminar;
        public ICommand cmdEliminarEncargos_Click
        {
            get
            {
                return _Eliminar ?? (_Eliminar = new CommandHandler(() => EliminarM(), _canExecute));
            }
        }

        private async void EliminarM()
        {
            if (PestañaSeleccionada == 2 || PestañaSeleccionada==4)
            {
                //this.MycmdEliminarPersonal();
                if (PestañaSeleccionada == 2) // selecciono personal
                {
                    if (SelectedPersonalAsignado != null)
                    {
                        this.MycmdEliminarPersonal();
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("Seleccione la fila que desea eliminar...", "", 1);
                    }
                }
                if (PestañaSeleccionada == 4) // selecciono cronograma
                {
                    if (SelectedDetalleCronograma != null)
                    {
                        this.MycmdEliminarDetCrono();
                    }
                    else
                    {
                        await AvisaYCerrateVosSolo("Seleccione la fila que desea eliminar...", "", 1);
                    }
                }
            }
            else
            {
                if (UsuarioPuedeEliminar)
                {
                    #region +
                    if (EncargoSelected != null)
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
                            MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "El registro " + Environment.NewLine + EncargoSelected.idnitcliente+" "+ EncargoSelected.fechacreadoencargo+" se eliminara logicamente del sistema.", "Esta seguro que desea continuar?", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                            if (resultk == MessageDialogResult.Affirmative)
                            {
                                #region
                                try
                                {
                                    using (SGPTEntidades db = new SGPTEntidades())
                                    {
                                        //cliente cli = db.clientes.Find(ClienteSelected.idnitcliente);
                                        //cli.estadocliente = "B";
                                        //db.Entry(cli).State = EntityState.Modified;
                                        //db.SaveChanges();
                                        //this.ObtenerListadoClientes();

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
        public ICommand cmdConsultarEncargos_Click
        {
            get
            {
                return _Consultar ?? (_Consultar = new CommandHandler(() => ConsultarM(), _canExecute));
            }
        }

        private async void ConsultarM()
        {
            if (PestañaSeleccionada == 2)
            {
                //this.MycmdConsultarPersonal();
            }
            else
            {
                #region +
                if (UsuarioPuedeConsultar)
                {
                    habilitarcmbCliente = false;
                    #region +
                    txtBanderaEliminar = "0";
                    txtBanderaAgregar = "0";
                    //await dlg.ShowMessageAsync(this, "Consultar", "");
                    if (EncargoSelected != null)
                    {
                        #region +
                        //currentCliente = ClienteSelected;
                        currentEncargo = EncargoSelected;
                        HabilitarListadoEncargos = Visibility.Hidden;
                        HabilitarTabEncargos = Visibility.Visible;
                        this.habilitarComprobacionDeAuditoria = false;
                        this.EscuchandoALaVista(3);
                        #endregion
                    }
                    else
                    {
                        #region +
                        //await dlg.ShowMessageAsync(this, "Seleccione un cliente para continuar...", "");
                        await AvisaYCerrateVosSolo("Seleccione un cliente para continuar...", "", 1);

                        txtBandera = "0";
                        txtBanderaNuevo = "1";
                        txtBanderaEditar = "1";
                        txtBanderaConsultar = "1";
                        txtBanderaEliminar = "1";
                        txtBanderaAgregar = "0";
                        txtBanderaCancelar = "0";
                        txtBanderaRegresar = "1";
                        habilitarcmbCliente = true;
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    await AvisaYCerrateVosSolo("No posees suficientes permisos para realizar esta accion.", "Consulte con el administrador acerca de esta restriccion", 1);
                } 
                #endregion
            }
        }

        private ICommand _Guardar;
        public ICommand cmdGuardarEncargos_Click 
        {
            get
            {
                return _Guardar ?? (_Guardar = new CommandHandler(() => GuardarM(), _canExecute));
            }
        }

        //public bool canSave()
        //{
        //    bool evaluar = false;

        //        if (Errors == 0)
        //            return evaluar = true ;
        //        return evaluar;
        //}
        private void GuardarM()
        {
            //await dlg.ShowMessageAsync(this, "Guardar", "");

            //Le avisamos si le faltan el personal y el cronograma, pero lo dejamos guardar para que luego pueda modificarlo.
            
            this.activarBarraGuardarDatos();
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
            if (PestañaSeleccionada == 2) // selecciono personal
            {
                if (SelectedUsuarioPersonal != null && HorasPlaneadasPersonal > 0 && !string.IsNullOrEmpty(CostoHoraUs))
                {
                    this.MycmdAgregarPersonal();
                }
                else
                {
                    await AvisaYCerrateVosSolo("Seleccione el auditor, el numero de horas y el costo", "Falta informacion", 2);
                }
            }
            if(PestañaSeleccionada==4) // selecciono cronograma
            {
                if (SelectedProcesosAuditoria!=null && SelectedVisita!=null && !string.IsNullOrEmpty(Actividaddc) && Fechainicialdc!=null && Fechafinaldc!=null)
                {
                    this.MycmdAgregarDetCrono();
                    txtBanderaAgregar = "0";
                }
                else
                {
                    await AvisaYCerrateVosSolo("Faltan datos","",1);
                }
            }
        }

        private ICommand _Cancelar;
        public ICommand cmdCancelarEncargos_Click //comando de la barra
        {
            get
            {
                return _Cancelar ?? (_Cancelar = new CommandHandler(() => CancelarM(), _canExecute));
            }
        }

        private async void CancelarM()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            await AvisaYCerrateVosSolo("Cancelado por usted...", "", 1);

            PestañaSeleccionada = 1;
            txtBandera = "0";
            txtBanderaNuevo = "1";
            txtBanderaEditar = "1";
            txtBanderaConsultar = "1";
            txtBanderaEliminar = "1";
            txtBanderaAgregar = "0";
            txtBanderaCancelar = "0";
            txtBanderaRegresar = "1";
            HabilitarListadoEncargos = Visibility.Visible;
            HabilitarTabEncargos = Visibility.Hidden;
            habilitarcmbCliente = true;
            ListadoDetalleCronograma = null;
            RaisePropertyChanged("ListadoDetalleCronograma");
            ListadoDetalleCronograma2 = null;
            ListadoPersonalAsignado = null;
            RaisePropertyChanged("ListadoPersonalAsignado");
            ListadoPersonalAsignado2 = null;
            ListadoElementos=null;
            RaisePropertyChanged("ListadoElementos");

            TotalHoras = 0;
            TotalUs = 0;

            //this.PruebaInicializadoresEnSegundoPlano();
            this.ObtenerListadoEncargos();
            this.PermisosUsuarioValidado("Encargos");
            Mouse.OverrideCursor = null;
        }
        #endregion
        /***********************************/


        #region Bindiados y habilitadores

        #region Habilitadores Barra menu
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

        private string _txtBanderaCargarCatalogo; //Sirve para activar/desactivar el cargar catalogo de cuentas.
        public string txtBanderaCargarCatalogo
        {
            get { return _txtBanderaCargarCatalogo; }
            set { _txtBanderaCargarCatalogo = value; RaisePropertyChanged("txtBanderaCargarCatalogo"); }
        }

        private string _txtBanderaRegresar; //Sirve para cancelar.
        public string txtBanderaRegresar
        {
            get { return _txtBanderaRegresar; }
            set { _txtBanderaRegresar = value; RaisePropertyChanged("txtBanderaRegresar"); }
        }
        #endregion

        private bool _habilitarcmbCliente;
        public bool habilitarcmbCliente
        {
            get { return _habilitarcmbCliente; }
            set { _habilitarcmbCliente = value; RaisePropertyChanged("habilitarcmbCliente"); }
        }

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

        private Visibility _HabilitarAceptarCancelarModifPersonal;
        public Visibility HabilitarAceptarCancelarModifPersonal
        {
            get { return _HabilitarAceptarCancelarModifPersonal; }
            set
            {
                _HabilitarAceptarCancelarModifPersonal = value;
                RaisePropertyChanged("HabilitarAceptarCancelarModifPersonal");
            }
        }
        private Visibility _HabilitarAceptarCancelarModifCronograma;
        public Visibility HabilitarAceptarCancelarModifCronograma
        {
            get { return _HabilitarAceptarCancelarModifCronograma; }
            set
            {
                _HabilitarAceptarCancelarModifCronograma = value;
                RaisePropertyChanged("HabilitarAceptarCancelarModifCronograma");
            }
        }

        private bool _HabilitarBarraDeMenuSuperior;
        public bool HabilitarBarraDeMenuSuperior
        {
            get { return _HabilitarBarraDeMenuSuperior; }
            set { _HabilitarBarraDeMenuSuperior = value; RaisePropertyChanged("HabilitarBarraDeMenuSuperior"); }
        }

        private bool _HabilitarDatagridPersonal;
        public bool HabilitarDatagridPersonal
        {
            get { return _HabilitarDatagridPersonal; }
            set
            {
                _HabilitarDatagridPersonal = value;
                RaisePropertyChanged("HabilitarDatagridPersonal");
            }
        }
        private bool _HabilitarDatagridCronograma;
        public bool HabilitarDatagridCronograma
        {
            get { return _HabilitarDatagridCronograma; }
            set
            {
                _HabilitarDatagridCronograma = value;
                RaisePropertyChanged("HabilitarDatagridCronograma");
            }
        }

        private Visibility _habilitarListadoEncargos;
        public Visibility HabilitarListadoEncargos
        {
            get { return _habilitarListadoEncargos; }
            set
            {
                _habilitarListadoEncargos = value;
                RaisePropertyChanged("HabilitarListadoEncargos");
            }
        }

        private Visibility _HabilitarTabEncargos;
        public Visibility HabilitarTabEncargos
        {
            get { return _HabilitarTabEncargos; }
            set
            {
                _HabilitarTabEncargos = value;
                RaisePropertyChanged("HabilitarTabEncargos");
            }
        } 
        #endregion

        private void EditarEncargo()
        {
            txtBandera = "1"; //permite activar el boton guardar
            AccionGuardar = false;
            AccionConsultar = false;
            Message = "Editar encargo";
            //MessageSistCont = "Editar sistema contable";
            this.campartidaEditarConsultar();
        }
        private async void campartidaEditarConsultar()
        {
            try
            {
                SelectedCliente = ListadoClientes.Find(x => x.idnitcliente == currentEncargo.idnitcliente);
                Honorariosencargo = currentEncargo.honorariosencargo.ToString();
                Fechainiperauditencargo = DateTime.Parse(currentEncargo.fechainiperauditencargo);
                Fechafinperauditencargo = DateTime.Parse(currentEncargo.fechafinperauditencargo);
                SelectedTipoAuditoria = ListadoTiposAuditoria.Find(z => z.idta == currentEncargo.idta);
                //string op1, op2; op1 = "Recurrente"; op2 = "No recurrente";
                SelectedTiposClienteRecurrente = (currentEncargo.tipoclienteencargo==true?ListadoTiposClienteRecurrente[0]:ListadoTiposClienteRecurrente[1]);//ListadoTiposClienteRecurrente.Find(currentEncargo.tipoclienteencargo);
                //string te1, te2, te3, te4; te1 = "Inicial"; te2 = "En proceso"; te3="Revisado"; te4="Cerrado";
                switch (currentEncargo.etapaencargo)
                {
                    case "I": SelectedEtapasEncargos = ListadoEtapasEncargos[0]; break;
                    case "P": SelectedEtapasEncargos = ListadoEtapasEncargos[1]; break;
                    case "R": SelectedEtapasEncargos = ListadoEtapasEncargos[2]; break;
                    case "C": SelectedEtapasEncargos = ListadoEtapasEncargos[3]; break;
                }
                
                #region +
                //HabilitarTabSistemaCont = true;
                RaisePropertyChanged("HabilitarTabSistemaCont");
                //HabilitarTabPersonal = true;
                RaisePropertyChanged("HabilitarTabPersonal");
                this.habilitarComprobacionDeAuditoria = true;
                #endregion
                this.ObtenerDatosPersonal();
                this.ObtenerDatosCronograma();
                //this.ObtenerDatosContable();
                this.recargarListadoPersonal();
                #region Parte Contable
                if (OpcionDeVisitaAqui == 2 || OpcionDeVisitaAqui == 3) //string[] partInternos = r.participantesinternoreunion.Split(',');
                {
                    #region +
                    try
                    {
                        #region +
                        using (db = new SGPTEntidades())
                        {
                            CurrentSistemaContable = db.sistemascontables.Where(ss => ss.idnitcliente == currentEncargo.idnitcliente && ss.idencargodsc == currentEncargo.idencargo).SingleOrDefault();

                            if (CurrentSistemaContable != null)
                            {
                                #region +
                                ListadoElementosD = new List<elemento>();
                                ListadoElementosD = (from e in db.elementos where e.idnitcliente == currentEncargo.idnitcliente && e.idscelementos == CurrentSistemaContable.idsc select e).ToList();
                                if (ListadoElementosD == null)
                                {
                                    await AvisaYCerrateVosSolo("Atencion, El encargo y su sistema contable asociado, no poseen un registro  numeracion de los elementos contables." + Environment.NewLine + "Nota: Se cargaran los datos por defecto.", "Asegurese de guardar antes de abandonar esta pantalla", 2);
                                    ListadoElementosD = (from e in db.elementos where e.sistemaelementos == true select e).ToList();
                                    RaisePropertyChanged("ListadoElementosD");
                                }
                                int i = 1;
                                ListadoElementos = new List<ElementosContablesModelo>();
                                foreach (var a in ListadoElementosD)
                                {
                                    ElementosContablesModelo el = new ElementosContablesModelo();
                                    el.correlativo = i;
                                    i++;
                                    el.idelementos = a.idelementos;
                                    el.idnitcliente = a.idnitcliente;
                                    el.descripcionelementos = a.descripcionelementos;
                                    el.fechacreacionelementos = a.fechacreacionelementos;
                                    el.sistemaelementos = a.sistemaelementos;
                                    el.estadoelementos = a.estadoelementos;
                                    el.idscelementos = (int)a.idscelementos;
                                    el.codigoelemento = a.codigoelemento;
                                    ListadoElementos.Add(el);
                                }

                                RaisePropertyChanged("ListadoElementos");
                                #region +
                                string[] perinic = CurrentSistemaContable.periodoiniciosc.Split('/');
                                //string[] perfin = CurrentSistemaContable.periodofinsc.Split('/');
                                string[] perfin = CurrentSistemaContable.periodofinsc.Split('/');

                                SelectedDiaInicio = ListitaDias.Find(di => di == int.Parse(perinic[0]));
                                SelectedMesInicio = ListitaMeses.Find(mi => mi == nommbreMesX(perinic[1]));
                                SelectedDiaFin = ListitaDias.Find(df => df == int.Parse(perfin[0]));
                                SelectedMesFin = ListitaMeses.Find(mi => mi == nommbreMesX(perfin[1]));

                                SelectedCantDigitCtasMayor = ListitaCantidadDigitos.Find(dcm => dcm == CurrentSistemaContable.digitoscuentamayorsc);
                                SelectedCantDigitRubrosCont = ListitaCantidadDigitos.Find(dcm => dcm == CurrentSistemaContable.digitosrubroscontablessc);
                                SelectedMoneda = ListadoMonedas.Find(Mo => Mo.idmoneda == CurrentSistemaContable.idmoneda);
                                SelectedEstructuraEstFin = ListadoEstructuraEstFin.Find(eef => eef.ideef == CurrentSistemaContable.ideef);
                                if (OpcionDeVisitaAqui == 3)
                                    txtBanderaCat = "0";
                                else
                                    txtBanderaCat = "1";
                                //HabilitarCargarCatalogo = true; 
                                #endregion
                                #endregion
                            }
                        }
                        #endregion
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Pcontable");
                    }
                    #endregion
                }
                else
                {
                    try
                    {
                        #region +
                        CurrentSistemaContable = new sistemascontable();
                        ListadoElementosD = new List<elemento>();
                        using (db = new SGPTEntidades())
                        {
                            ListadoElementosD = (from e in db.elementos where e.sistemaelementos == true && e.estadoelementos == "A" select e).ToList();
                        }
                        int i = 0;
                        ListadoElementos = new List<ElementosContablesModelo>();
                        foreach (var a in ListadoElementosD)
                        {
                            ElementosContablesModelo el = new ElementosContablesModelo();
                            i++;
                            el.correlativo = i;
                            el.idelementos = a.idelementos;
                            el.idnitcliente = a.idnitcliente;
                            el.descripcionelementos = a.descripcionelementos;
                            el.fechacreacionelementos = a.fechacreacionelementos;
                            el.sistemaelementos = a.sistemaelementos;
                            el.estadoelementos = a.estadoelementos;
                            //el.idscelementos = (int)a.idscelementos;
                            el.codigoelemento = a.codigoelemento;
                            ListadoElementos.Add(el);
                        }

                        RaisePropertyChanged("ListadoElementos");
                        #endregion
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Pcontable " + e.InnerException);
                    }
                }
                #endregion


                this.recargarListadoDetalleCronograma();
                
            }
            catch (Exception e)
            {
                //AvisaYCerrateVosSolo("" + e.InnerException, "", 1);
                MessageBox.Show("Ocurrio un error al recuperar los datos de las reuniones. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error. "+e.InnerException, "Error de compatibilidad de datos");
            }
        }

        private async void recargarListadoDetalleCronograma()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            this.FocoPestañaSeleccionada = 0;
            #region Parte cronograma
            if (OpcionDeVisitaAqui == 2 || OpcionDeVisitaAqui == 3) //string[] partInternos = r.participantesinternoreunion.Split(',');
            {
                #region +
                using (db = new SGPTEntidades())
                {
                    try
                    {
                        #region +
                        currentCronograma = (from c in db.cronogramas where c.idencargo == currentEncargo.idencargo && c.estadocronograma == "A" select c).SingleOrDefault();
                        if (currentCronograma != null)
                        {
                            List<detallecronograma> detCrono = new List<detallecronograma>();
                            detCrono= (from d in db.detallecronogramas where d.idcronograma == currentCronograma.idcronograma && d.estadodc == "A" select d).ToList();
                            //ListadoDetalleCronograma2

                            ListadoDetalleCronograma2 = new List<detalleCronogramaModelo>();
                            foreach (var k in detCrono)
                            {
                                #region +
                                detalleCronogramaModelo det = new detalleCronogramaModelo();
                                det.iddc = k.iddc;
                                det.idpa = (int)k.idpa; // SelectedProcesosAuditoria.idpa;
                                det.nombreProcesoAuditoria = ListadoProcesosAuditoria.Find(l => l.idpa == k.idpa).descripcionpa;
                                det.idvisita = (int)k.idvisita;
                                det.nombreVisita = ListadoVisitas.Find(j => j.idvisita == k.idvisita).descripcionvisita;
                                det.idcronograma = (int)k.idcronograma;
                                det.actividaddc = k.actividaddc;
                                det.fechainicialdc = DateTime.Parse(k.fechaprogramadacronograma);// Fechainicialdc;
                                det.fechafinaldc = DateTime.Parse(k.fechafinaldc);
                                det.horasplaneadasdc = (decimal)k.horasplaneadasdc;
                                var personl = (from p in db.designaciones where p.iddc == k.iddc select p).ToList();
                                if (personl!=null)
                                    det.cantidadPersonasAsignadasPorEtapa = personl.Count();
                                foreach (var a in personl)
                                {
                                    det.iDpersonalPorEtapa += ";" + a.idusuario.ToString() + ": " + a.horasplandesignacion.ToString();
                                    det.personalPorEtapa += ListadoUsuarios.Find(x => x.idusuario == a.idusuario).nombreCompleto + "," + "=> horas: " + a.horasplandesignacion.ToString() + ", ";
                                    asignacione l = new asignacione();
                                    l = (from b in db.asignaciones where b.idencargo == currentEncargo.idencargo && b.idusuario == a.idusuario select b).SingleOrDefault(); //(db.asignaciones.Where(x => x.idencargo == currentEncargo.idencargo && x.idusuario == a.idusuario).Select(t => t.preciohoraasignacion));
                                    //var j = l.preciohoraasignacion;
                                    if (l != null)
                                        det.valorUs += (decimal)(l.preciohoraasignacion) * (decimal)a.horasplandesignacion; //a.UssPlaneado;
                                }

                                //foreach (var a in ListadoPersonalSeleccionadoxEtapa)
                                //{
                                //    det.horasplaneadasdc += a.horasplanasignacion;
                                //    det.iDpersonalPorEtapa += ";" + a.idusuario.ToString() + ": " + a.horasplanasignacion.ToString();
                                //    det.personalPorEtapa += a.nombreCompletoUsuario + "=> horas: " + a.horasplanasignacion.ToString() + ", ";
                                //    det.valorUs += a.UssPlaneado;
                                //}
                                det.fechacreadodc = k.fechacreadodc;
                                det.estadodc = k.estadodc;
                                if (k.idusuario != null)
                                    det.idusuario = (int)k.idusuario;

                                ListadoDetalleCronograma2.Add(det);
                                ListadoDetalleCronograma = new List<detalleCronogramaModelo>();
                                TotalHoras = 0;
                                TotalUs = 0;
                                int i = 1;
                                foreach (var a in ListadoDetalleCronograma2)
                                {
                                    a.correlativo = i; i++;
                                    TotalHoras += a.horasplaneadasdc;
                                    TotalUs += a.valorUs;

                                    ListadoDetalleCronograma.Add(a);
                                }
                                //ListadoDetalleCronograma = ListadoDetalleCronograma2;
                                RaisePropertyChanged("ListadoDetalleCronograma");

                                // ahora hay que limpiar los campos.
                                SelectedProcesosAuditoria = null;
                                SelectedVisita = null;
                                Actividaddc = "";
                                Fechainicialdc = DateTime.Now;
                                Fechafinaldc = DateTime.Now.AddDays(15);
                                txtPuedeAgregarDetCronograma = "0";
                                ListadoPersonalSeleccionadoxEtapa = null;
                                #endregion
                            }
                            RaisePropertyChanged("ListadoPersonalAsignado");
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("Atencion, el cliente " + currentCliente.razonsocialcliente + Environment.NewLine + "No tiene registrado ningun cronograma de actividades," + Environment.NewLine + "para el siguiente encargo: " + currentEncargo.nombreTa + Environment.NewLine + " Para el periodo : " + currentEncargo.añoencargo, "Ingrese un cronograma para este cliente y asigne el personal adecuado", 3);
                        }
                        #endregion
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Pcronograma " + e.InnerException);
                    }
                }
                #endregion
            }
            #endregion
            Mouse.OverrideCursor=null;
        }

        private void recargarListadoPersonal()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region Parte personal
            if (OpcionDeVisitaAqui == 2 || OpcionDeVisitaAqui == 3) //string[] partInternos = r.participantesinternoreunion.Split(',');
            {
                #region +
                using (db = new SGPTEntidades())
                {
                    try
                    {
                        #region +
                        ListadoPersonalAsignado2 = new List<AsignacionesModelo>();
                        var personl = (from p in db.asignaciones where p.idencargo == currentEncargo.idencargo && p.estadoasignacion == "A" select p).ToList();
                        foreach (var k in personl)
                        {
                            var u = ListadoUsuarios.Find(x => x.idusuario == k.idusuario);
                            AsignacionesModelo asi = new AsignacionesModelo();
                            asi.idasignacion = k.idasignacion;
                            asi.idusuario = u.idusuario;
                            asi.nombreCompletoUsuario = u.nombreCompleto;
                            asi.idrol = u.idrol;
                            asi.rolUsuario = u.nombrerol;
                            asi.horasplanasignacion = (decimal)(k.horasplanasignacion);//Math.Round((Convert.ToDecimal(CostoHoraUs)), 2);
                            asi.preciohoraasignacion = (decimal)k.preciohoraasignacion;
                            asi.UssPlaneado = (decimal)(k.horasplanasignacion) * (decimal)(k.preciohoraasignacion);//HorasPlaneadasPersonal * Math.Round((Convert.ToDecimal(CostoHoraUs)), 2);
                            asi.UssEjecutado = 0;
                            asi.Indice = 0;
                            ListadoPersonalAsignado2.Add(asi);
                            ListadoPersonalAsignado = new List<AsignacionesModelo>();
                            foreach (var x in ListadoPersonalAsignado2)
                            {
                                ListadoPersonalAsignado.Add(x);
                            }
                        }
                        RaisePropertyChanged("ListadoPersonalAsignado");
                        #endregion
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error de comunicacion con la base de datos " + e.InnerException);
                    }
                }
                #endregion
            }
            #endregion
            Mouse.OverrideCursor = null;
        }

        
        private void ConsultarEncargo()
        {
            //this.inicializarListados();
            txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            Message = "Consultar encargo";
            //MessageSistCont = "Consultar sistema contable";
            this.campartidaEditarConsultar();
        }

        private void NuevoEncargo()
        {
            try
            {
                FocoPestañaSeleccionada = 0;
                txtBandera = "1";
                AccionGuardar = true;
                AccionConsultar = false;
                //Fechaconstitucioncliente = DateTime.Now;
                Message = "Nuevo encargo";
                //MessageSistCont = "Nuevo sistema contable";
                //HabilitarTabSistemaCont = true; //ojo, despues deshabilitarlo
                //HabilitarTabPersonal = true; //ojo, despues quitar esto
                //Pestaña generales
                SelectedCliente = null;
                Fechainiperauditencargo = DateTime.Parse("01/01/" + DateTime.Now.Year.ToString());
                Fechafinperauditencargo = DateTime.Parse("31/12/" + DateTime.Now.Year.ToString());
                SelectedTipoAuditoria = ListadoTiposAuditoria[0];
                SelectedTiposClienteRecurrente = null;
                SelectedEtapasEncargos = ListadoEtapasEncargos[0];


                //pestaña personal
                ListadoPersonalAsignado = new List<AsignacionesModelo>();
                RaisePropertyChanged("ListadoPersonalAsignado");
                ListadoPersonalAsignado2 = new List<AsignacionesModelo>();
                //pestaña sistema contable
                SelectedDiaInicio = 1;
                SelectedMesInicio = "Enero";
                SelectedDiaFin = 31;
                SelectedMesFin = "Diciembre";
                SelectedCantDigitCtasMayor = 2;
                SelectedCantDigitRubrosCont = 4;
                SelectedMoneda = ListadoMonedas[0];
                SelectedEstructuraEstFin = ListadoEstructuraEstFin[2];
                //Pestaña cronograma
                ListadoDetalleCronograma = new List<detalleCronogramaModelo>();
                RaisePropertyChanged("ListadoDetalleCronograma");
                ListadoDetalleCronograma2 = new List<detalleCronogramaModelo>();

                this.habilitarComprobacionDeAuditoria = true;

                ListadoElementosD = new List<elemento>();
                using (db = new SGPTEntidades())
                {
                    ListadoElementosD = (from e in db.elementos where e.sistemaelementos == true select e).ToList();

                }
                int i = 1;
                ListadoElementos = new List<ElementosContablesModelo>();
                foreach (var a in ListadoElementosD)
                {
                    ElementosContablesModelo el = new ElementosContablesModelo();
                    el.correlativo = i;
                    i++;
                    el.idelementos = a.idelementos;
                    //el.idnitcliente = a.idnitcliente;
                    el.descripcionelementos = a.descripcionelementos;
                    el.fechacreacionelementos = a.fechacreacionelementos;
                    el.sistemaelementos = a.sistemaelementos;
                    el.estadoelementos = a.estadoelementos;
                    //el.idscelementos = (int)a.idscelementos;
                    el.codigoelemento = a.codigoelemento;
                    ListadoElementos.Add(el);
                }
                this.ObtenerDatosCronograma();
                RaisePropertyChanged("ListadoElementos");
            }
            catch (Exception e)
            {
                MessageBox.Show("Error desconocido al iniciar la creacion de un nuevo encargo "+e);
            }
        }

        //private string _txtBandera = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        //public string txtBandera
        //{
        //    get { return _txtBandera; }
        //    set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        //}

        private string _txtBanderaCat = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBanderaCat
        {
            get { return _txtBanderaCat; }
            set { _txtBanderaCat = value; RaisePropertyChanged("txtBanderaCat"); }
        }

        //**************************Datos Generales************************************************
        #region +
        private string _txtPuedeAgregarDetCronograma = "0"; //Sirve para habilitar el paso de agregar una nueva fila.
        public string txtPuedeAgregarDetCronograma
        {
            get { return _txtPuedeAgregarDetCronograma; }
            set { _txtPuedeAgregarDetCronograma = value; RaisePropertyChanged("txtPuedeAgregarDetCronograma"); }
        }

        private cliente _SelectedCliente;
        public cliente SelectedCliente
        {
            get { return _SelectedCliente; }
            set
            {
                _SelectedCliente = value;
                RaisePropertyChanged("SelectedCliente");
                this.BuscarAuditoriasSimilares();
            }
        }

        private string _SelectedTiposClienteRecurrente;
        public string SelectedTiposClienteRecurrente
        {
            get { return _SelectedTiposClienteRecurrente; }
            set
            {
                _SelectedTiposClienteRecurrente = value;
                RaisePropertyChanged("SelectedTiposClienteRecurrente");
                this.BuscarAuditoriasSimilares();
            }
        }


        private tiposauditoria _SelectedTipoAuditoria;
        public tiposauditoria SelectedTipoAuditoria
        {
            get { return _SelectedTipoAuditoria; }
            set
            {
                _SelectedTipoAuditoria = value;
                RaisePropertyChanged("SelectedTipoAuditoria");
                this.BuscarAuditoriasSimilares();
            }
        }

        private async void BuscarAuditoriasSimilares()
        {
            if (SelectedCliente != null && SelectedTipoAuditoria !=null && habilitarComprobacionDeAuditoria==true)
            {
                if (currentEncargo!=null)
                {
                    if (SelectedTipoAuditoria.idta != currentEncargo.idta)
                    {
                        #region +
                        txtBandera = "1";
                        var auditsencontradas = (from e in ListadoEncargos where e.idnitcliente == SelectedCliente.idnitcliente && e.idta == SelectedTipoAuditoria.idta select e).ToList();
                        foreach (var a in auditsencontradas)
                        {
                            DateTime fini = DateTime.Parse(a.fechainiperauditencargo);
                            DateTime ffin = DateTime.Parse(a.fechafinperauditencargo);
                            if ((Fechainiperauditencargo <= fini && fini <= Fechafinperauditencargo) || (Fechainiperauditencargo <= ffin && ffin <= Fechafinperauditencargo))
                            {
                                await AvisaYCerrateVosSolo("El cliente ya posee una auditoria de este tipo que abarca el rango de fechas seleccionadas", "Modifique los valores", 3);
                                txtBandera = "0";
                            }
                        }
                        #endregion
                    } 
                }
                else
                {
                    #region +
                    txtBandera = "1";
                    var auditsencontradas = (from e in ListadoEncargos where e.idnitcliente == SelectedCliente.idnitcliente && e.idta == SelectedTipoAuditoria.idta select e).ToList();
                    foreach (var a in auditsencontradas)
                    {
                        DateTime fini = DateTime.Parse(a.fechainiperauditencargo);
                        DateTime ffin = DateTime.Parse(a.fechafinperauditencargo);
                        if ((Fechainiperauditencargo <= fini && fini <= Fechafinperauditencargo) || (Fechainiperauditencargo <= ffin && ffin <= Fechafinperauditencargo))
                        {
                            await AvisaYCerrateVosSolo("El cliente ya posee una auditoria de este tipo que abarca el rango de fechas seleccionadas", "Modifique los valores", 3);
                            txtBandera = "0";
                        }
                    }
                    #endregion
                }
            }
        }

        private string _SelectedEtapasEncargos;
        public string SelectedEtapasEncargos
        {
            get { return _SelectedEtapasEncargos; }
            set
            {
                _SelectedEtapasEncargos = value;
                RaisePropertyChanged("SelectedEtapasEncargos");
                this.BuscarAuditoriasSimilares();
            }
        } 
        #endregion

        //**********************Personal******************
        #region +
        
        public ICommand _btnAceptarCambiosPersonal;
        public ICommand btnAceptarCambiosPersonal { get { return _btnAceptarCambiosPersonal ?? (_btnAceptarCambiosPersonal = new CommandHandler(() => MybtnAceptarCambiosPersonal(), _canExecute)); } }

        private void MybtnAceptarCambiosPersonal()
        {
            if (PestañaSeleccionada==2)
            {
                //AvisaYCerrateVosSolo("Aceptar cambios", "", 1);
                HabilitarAceptarCancelarModifPersonal = Visibility.Hidden;
                HabilitarBarraDeMenuSuperior = true;
                HabilitarDatagridPersonal = true;
                if (HorasPlaneadasPersonal > 0 && !string.IsNullOrEmpty(CostoHoraUs))
                {
                    this.MycmdAgregarPersonal();
                }


                EstaEditandoFilaEnPersonal = false;
                SelectedUsuarioPersonal = null;
                HorasPlaneadasPersonal = 0;
                CostoHoraUs = "";
            }
            else if (PestañaSeleccionada == 4)
            {
                HabilitarAceptarCancelarModifCronograma = Visibility.Hidden;
                HabilitarBarraDeMenuSuperior = true;
                HabilitarDatagridCronograma = true;

                //if (SelectedProcesosAuditoria != null && SelectedVisita != null && !string.IsNullOrEmpty(Actividaddc) && Fechainicialdc >= DateTime.Now && Fechafinaldc >= DateTime.Now)
                if (SelectedProcesosAuditoria != null && SelectedVisita != null && !string.IsNullOrEmpty(Actividaddc) && Fechainicialdc.Year >= DateTime.Now.Year && Fechafinaldc.Year >= DateTime.Now.Year)
                {
                    this.MycmdAgregarDetCrono();
                }

                EstaEditandoFilaEnCronograma = false;
                SelectedProcesosAuditoria = null;
                SelectedVisita = null;
                Actividaddc = "";
                Fechainicialdc = DateTime.Now; ;
                Fechafinaldc = DateTime.Now.AddDays(15);
            }
        }

        public ICommand _btnCancelarCambiosPersonal;
        public ICommand btnCancelarCambiosPersonal { get { return _btnCancelarCambiosPersonal ?? (_btnCancelarCambiosPersonal = new CommandHandler(() => MybtnCancelarCambiosPersonal(), _canExecute)); } }

        private void MybtnCancelarCambiosPersonal()
        {
            if (PestañaSeleccionada==2)
            {
                HabilitarAceptarCancelarModifPersonal = Visibility.Hidden;
                HabilitarBarraDeMenuSuperior = true;
                HabilitarDatagridPersonal = true;
                EstaEditandoFilaEnPersonal = false;
                SelectedUsuarioPersonal = null;
                HorasPlaneadasPersonal = 0;
                CostoHoraUs = "";
            }
            else if (PestañaSeleccionada == 4)
            {
                HabilitarAceptarCancelarModifPersonal = Visibility.Hidden;
                HabilitarAceptarCancelarModifCronograma = Visibility.Hidden;
                HabilitarBarraDeMenuSuperior = true;
                HabilitarDatagridPersonal = true;
                HabilitarDatagridCronograma = true;
                EstaEditandoFilaEnPersonal = false;
                EstaEditandoFilaEnCronograma = false;

                SelectedProcesosAuditoria   = null;
                SelectedVisita              = null;
                Actividaddc     = "";
                Fechainicialdc  = DateTime.Now;
                Fechafinaldc    = DateTime.Now.AddDays(15);
            }
        }


        private usuariospersonas _SelectedUsuarioPersonal;
        public usuariospersonas SelectedUsuarioPersonal
        {
            get { return _SelectedUsuarioPersonal; }
            set
            {
                _SelectedUsuarioPersonal = value;
                RaisePropertyChanged("SelectedUsuarioPersonal");
            }
        }

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

        private decimal _HorasPlaneadasPersonal;
        public decimal HorasPlaneadasPersonal
        {
            get { return _HorasPlaneadasPersonal; }
            set
            {
                _HorasPlaneadasPersonal = value;
                RaisePropertyChanged("HorasPlaneadasPersonal");
            }
        }

        private string _CostoHoraUs;
        public string CostoHoraUs
        {
            get { return _CostoHoraUs; }
            set
            {
                _CostoHoraUs = value;
                RaisePropertyChanged("CostoHoraUs");
            }
        } 
        #endregion

        //*********************Sistemas contables*************************************************
        #region +
        private moneda _selectedMoneda;
        public moneda SelectedMoneda
        {
            get { return _selectedMoneda; }
            set
            {
                _selectedMoneda = value;
                RaisePropertyChanged("SelectedMoneda");
            }
        }

        private int _SelectedDiaInicio;
        public int SelectedDiaInicio
        {
            get { return _SelectedDiaInicio; }
            set { _SelectedDiaInicio = value; RaisePropertyChanged("SelectedDiaInicio"); }
        }

        private int _SelectedDiaFin;
        public int SelectedDiaFin
        {
            get { return _SelectedDiaFin; }
            set { _SelectedDiaFin = value; RaisePropertyChanged("SelectedDiaFin"); }
        }

        private string _SelectedMesInicio;
        public string SelectedMesInicio
        {
            get { return _SelectedMesInicio; }
            set
            {
                _SelectedMesInicio = value;
                RaisePropertyChanged("SelectedMesInicio");
            }
        }

        private string _SelectedMesFin;
        public string SelectedMesFin
        {
            get { return _SelectedMesFin; }
            set { _SelectedMesFin = value; RaisePropertyChanged("SelectedMesFin"); }
        }

        private estructuraestadofinanciero _selectedEstructuraEstFin;
        public estructuraestadofinanciero SelectedEstructuraEstFin
        {
            get { return _selectedEstructuraEstFin; }
            set
            {
                _selectedEstructuraEstFin = value;
                RaisePropertyChanged("SelectedEstructuraEstFin");
            }
        }

        private int _SelectedCantDigitCtasMayor;
        public int SelectedCantDigitCtasMayor
        {
            get { return _SelectedCantDigitCtasMayor; }
            set
            {
                _SelectedCantDigitCtasMayor = value;
                RaisePropertyChanged("SelectedCantDigitCtasMayor");
            }
        }

        private int _SelectedCantDigitRubrosCont;
        public int SelectedCantDigitRubrosCont
        {
            get { return _SelectedCantDigitRubrosCont; }
            set
            {
                _SelectedCantDigitRubrosCont = value;
                RaisePropertyChanged("SelectedCantDigitRubrosCont");
            }
        } 
        #endregion


        //**********************Cronograma*****************
        #region +
        private procesosauditoria _SelectedProcesosAuditoria;
        public procesosauditoria SelectedProcesosAuditoria
        {
            get { return _SelectedProcesosAuditoria; }
            set
            {
                _SelectedProcesosAuditoria = value;
                RaisePropertyChanged("SelectedProcesosAuditoria");
            }
        }

        private visita _SelectedVisita;
        public visita SelectedVisita
        {
            get { return _SelectedVisita; }
            set
            {
                _SelectedVisita = value;
                RaisePropertyChanged("SelectedVisita");
            }
        }

        private detalleCronogramaModelo _SelectedDetalleCronograma;
        public detalleCronogramaModelo SelectedDetalleCronograma
        {
            get { return _SelectedDetalleCronograma; }
            set
            {
                _SelectedDetalleCronograma = value;
                RaisePropertyChanged("SelectedDetalleCronograma");
            }
        }

        private string _Actividaddc;
        public string Actividaddc
        {
            get { return _Actividaddc; }
            set
            {
                _Actividaddc = value;
                RaisePropertyChanged("Actividaddc");
            }
        }

        private DateTime _Fechainicialdc = DateTime.Now;
        public DateTime Fechainicialdc
        {
            get { return _Fechainicialdc; }
            set { _Fechainicialdc = value; RaisePropertyChanged("Fechainicialdc"); }
        }

        private DateTime _Fechafinaldc = DateTime.Now.AddDays(15);
        public DateTime Fechafinaldc
        {
            get { return _Fechafinaldc; }
            set
            {
                _Fechafinaldc = value;
                RaisePropertyChanged("Fechafinaldc");
            }
        }

        private decimal _TotalHoras;
        public decimal TotalHoras
        {
            get { return _TotalHoras; }
            set
            {
                _TotalHoras = value;
                RaisePropertyChanged("TotalHoras");
            }
        }

        private decimal _TotalUs;
        public decimal TotalUs
        {
            get { return _TotalUs; }
            set
            {
                _TotalUs = value;
                RaisePropertyChanged("TotalUs");
            }
        } 
        #endregion

        //****************************************************************


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
                    MessageBox.Show("Ocurrio un error al recuperar los permisos del rol del usuario.\nLa base de datos tardo demasiado en responder.\nInforme a soporte tecnico acerca de este error. "+e.InnerException, "error critico.", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        private int _idencargo;
        private string _idnitcliente;
        private DateTime _fechainiperauditencargo=DateTime.Now;
        private DateTime _fechafinperauditencargo=DateTime.Now.AddDays(90);
        private string _honorariosencargo="0";

        public int Idencargo { get { return _idencargo; } set { _idencargo = value; RaisePropertyChanged("Idencargo"); } }
        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public DateTime Fechainiperauditencargo { get { return _fechainiperauditencargo; } set { _fechainiperauditencargo = value; RaisePropertyChanged("Fechainiperauditencargo"); this.BuscarAuditoriasSimilares(); } }

        public DateTime Fechafinperauditencargo { get { return _fechafinperauditencargo; } set { _fechafinperauditencargo = value; RaisePropertyChanged("Fechafinperauditencargo"); this.BuscarAuditoriasSimilares(); } }

        public string Honorariosencargo { get { return _honorariosencargo; } set { _honorariosencargo = value; RaisePropertyChanged("Honorariosencargo"); } }

        private int _txtSumaTotalPersonasPresupuesto;
        private int _txtHorasTotalesPresupuesto     ;
        private decimal _txtCostoTotalPresupuesto   ;
        private decimal _txtIndicePresupuesto       ;

        public int txtSumaTotalPersonasPresupuesto { get { return _txtSumaTotalPersonasPresupuesto; } set { _txtSumaTotalPersonasPresupuesto = value; RaisePropertyChanged("txtSumaTotalPersonasPresupuesto"); } }
        public int txtHorasTotalesPresupuesto { get { return _txtHorasTotalesPresupuesto; } set { _txtHorasTotalesPresupuesto = value; RaisePropertyChanged("txtHorasTotalesPresupuesto"); } }
        public decimal txtCostoTotalPresupuesto { get { return _txtCostoTotalPresupuesto; } set { _txtCostoTotalPresupuesto = value; RaisePropertyChanged("txtCostoTotalPresupuesto"); } }
        public decimal txtIndicePresupuesto { get { return _txtIndicePresupuesto; } set { _txtIndicePresupuesto = value; RaisePropertyChanged("txtIndicePresupuesto"); } }

        #region Campos SistemasContables
        //private int _idsc;
        private int _idmoneda;
        //private string _idnitcliente;
        private int _ideef;
        //private string _fechasc;
        private decimal _digitoscuentamayorsc;
        private decimal _digitosrubroscontablessc;
        private DateTime _periodoiniciosc;
        private DateTime _periodofinsc;
        //private string _estadosc;

        //public int Idsc { get{return _idsc;}; set; } YA ESTA DECLARADO EL IDSC Y SIRVE PARA TODOS
        public int Idmoneda { get { return _idmoneda; } set { _idmoneda = value; RaisePropertyChanged("Idmoneda"); } }
        //public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; } }
        public int Ideef { get { return _ideef; } set { _ideef = value; RaisePropertyChanged("Ideef"); } }
        //public string Fechasc { get; set; }
        public decimal Digitoscuentamayorsc { get { return _digitoscuentamayorsc; } set { _digitoscuentamayorsc = value; RaisePropertyChanged("Digitoscuentamayorsc"); } }
        public decimal Digitosrubroscontablessc { get { return _digitosrubroscontablessc; } set { _digitosrubroscontablessc = value; RaisePropertyChanged("Digitosrubroscontablessc"); } }
        public DateTime Periodoiniciosc { get { return _periodoiniciosc; } set { _periodoiniciosc = value; RaisePropertyChanged("Periodoiniciosc"); } }
        public DateTime Periodofinsc { get { return _periodofinsc; } set { _periodofinsc = value; RaisePropertyChanged("Periodofinsc"); } }
        //public string Estadosc { get; set; }
        #endregion
        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        private ICommand _MiComanditoDatosGenerales;
        public ICommand MiComanditoDatosGenerales { get { return _MiComanditoDatosGenerales ?? (_MiComanditoDatosGenerales = new CommandHandler(() => MyPestañaDatosGenerales(), _canExecute)); } }

        private ICommand _miComanditoPersonal;
        public ICommand MiComanditoPersonal { get { return _miComanditoPersonal ?? (_miComanditoPersonal = new CommandHandler(() => MyPestañaMiComanditoPersonal(), _canExecute)); } }

        public ICommand _miComanditoContable;
        public ICommand MiComanditoContable { get { return _miComanditoContable ?? (_miComanditoContable = new CommandHandler(() => MyPestañaContable(), _canExecute)); } }

        private ICommand _MiComanditoCronograma;
        public ICommand MiComanditoCronograma { get { return _MiComanditoCronograma ?? (_MiComanditoCronograma = new CommandHandler(() => MyPestañaMiComanditoCronograma(), _canExecute)); } }

        private ICommand _MiComanditoPresupuesto;
        public ICommand MiComanditoPresupuesto { get { return _MiComanditoPresupuesto ?? (_MiComanditoPresupuesto = new CommandHandler(() => MyPestañaMiComanditoPresupuesto(), _canExecute)); } }

        private void MyPestañaDatosGenerales()
        {
            this.MybtnCancelarCambiosPersonal(); //restablece la barra y el datagrid del personal, por si estan atascados
            PestañaSeleccionada = 1;
            txtBanderaAgregar = "0";
            txtBanderaEliminar = "0";
            if (OpcionDeVisitaAqui == 1 || OpcionDeVisitaAqui == 2)
            {
                txtBandera = "1";
                txtBanderaEditar = "0";
            }
            this.PermisosUsuarioValidado("Encargos");
        }
        private void MyPestañaMiComanditoPersonal()
        {
            this.MybtnCancelarCambiosPersonal(); //restablece la barra y el datagrid del personal, por si estan atascados
            PestañaSeleccionada = 2;
            this.PermisosUsuarioValidado("Asignaciones");
            this.ObtenerDatosPersonal();
            if (OpcionDeVisitaAqui == 1 || OpcionDeVisitaAqui == 2)
            {
                txtBanderaAgregar = "1";
                txtBanderaEliminar="1";
                txtBanderaEditar = "1";
            }
            

        }

        public async void ObtenerListadoEncargos()
        {
            GC.Collect();
            
                #region +
                try
                {
                    using (db = new SGPTEntidades())
                    {
                        #region +
                        ListadoEncargos = new List<EncargosModelo>();
                        //var joji = db.encargos.ToList();
                        List<encargo> exped = new List<encargo>();
                        exped = (from g in db.encargos where g.estadoencargo == "A" select g).ToList();//(from e in db.encargos where e.estadoencargo == "A" orderby e.fechacreadoencargo descending select e).ToList();
                        if (exped != null && exped.Count() > 0)//|| ListadoEncargos.Count != 0)
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
                            d.honorariosencargo = (decimal)e.honorariosencargo; ;
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
                        else
                        {
                        await Task.Delay(1);
                            //await AvisaYCerrateVosSolo("No posee encargos registrados de ningun cliente", "", 1);
                        }
                        #endregion
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error, la base de datos tardo demasiado en responder. " + e);
                    //dlg.ShowMessageAsync(this, "Ocurrio un error al recuperar los datos del cliente", "");
                    //AvisaYCerrateVosSolo("Ocurrio un error al recuperar los datos del encargo", "", 1);
                } 
                #endregion
            
            //if (ListadoEncargos == null || ListadoEncargos.Count == 0)
            //    dlg.ShowMessageAsync(this, "No posee ningun encargo registrado", "");
                //this.habilitarComprobacionDeAuditoria = true;
        }

        private void ObtenerDatos() //Pestaña 2 Encargos (Datos Generales)
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoClientes = new List<cliente>();
                    ListadoClientes=(from c in db.clientes where c.estadocliente=="A" orderby c.razonsocialcliente select c).ToList();
                    RaisePropertyChanged("ListadoClientes");
                    ListadoTiposAuditoria=(from t in db.tiposauditorias where t.estadota=="A" select t).ToList();
                    RaisePropertyChanged("ListadoTiposAuditoria");
                    ListadoTiposClienteRecurrente = new List<string>();
                    string op1, op2; op1 = "Recurrente"; op2 = "No recurrente";
                    ListadoTiposClienteRecurrente.Add(op1);
                    ListadoTiposClienteRecurrente.Add(op2);

                    ListadoEtapasEncargos = new List<string>();
                    string te1, te2, te3, te4; te1 = "Inicial"; te2 = "En proceso"; te3="Revisado"; te4="Cerrado";
                    ListadoEtapasEncargos.Add(te1);
                    ListadoEtapasEncargos.Add(te2);
                    ListadoEtapasEncargos.Add(te3);
                    ListadoEtapasEncargos.Add(te4);
                    SelectedEtapasEncargos = ListadoEtapasEncargos[0];
                    //ListadoEstructuraO = new List<estructurasorganica>();
                    //ListadoEstructuraO = (from e in db.estructurasorganicas where e.idnitcliente == currentCliente.idnitcliente && e.estadoeo=="A" orderby e.nombrecargoeo select e).ToList();
                    

                }
                catch (Exception)
                {

                    MessageBox.Show("Error critico al recuperar los datos de la estructura organica del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. ", "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        private void ObtenerDatosPersonal() //Pestaña 2 (Personal)
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    
                    ListadoUsuarios = new List<usuariospersonas>();
                    ListadoUsuarios = (from u in db.usuarios
                                       join p in db.personas
                                       on u.idduipersona equals p.idduipersona
                                       join r in db.roles 
                                       on u.idrol equals r.idrol 
                                       where p.estadopersona == "A"
                                       orderby p.nombrespersona
                                       select new usuariospersonas
                                       {
                                           #region
                                           idusuario = u.idusuario,
                                           idpista = (int)u.idpista,
                                           usuidusuario = (int)(u.usuidusuario),
                                           idrol = (int)(u.idrol),
                                           nombrerol= r.nombrerol,
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
                    RaisePropertyChanged("ListadoUsuarios");

                }
                catch (Exception)
                {

                    MessageBox.Show("Error critico al recuperar los datos de los contactos del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. ", "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void ObtenerDatosSistemasCont() // Pestaña 3
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    ListadoMonedas = new List<moneda>();
                    ListadoMonedas = (from m in db.monedas where m.estadomoneda == "A" orderby m.nombremoneda select m).ToList();
                    RaisePropertyChanged("ListadoMonedas");

                    ListadoEstructuraEstFin = new List<estructuraestadofinanciero>();
                    ListadoEstructuraEstFin = (from e in db.estructuraestadofinancieros where e.estadoeef == "A" orderby e.descripcioneef select e).ToList();
                    RaisePropertyChanged("ListadoEstructuraEstFin");

                    ListitaCantidadDigitos = new List<int>();
                    for (int i = 1; i <= 10; i++)
                        ListitaCantidadDigitos.Add(i);
                    RaisePropertyChanged("ListitaCantidadDigitos");

                    ListitaDias = new List<int>();
                    for (int y = 1; y <= 31; y++)
                        ListitaDias.Add(y);

                    RaisePropertyChanged("ListitaDias");

                    ListitaMeses = new List<string>();
                    string ene = "Enero", feb = "Febrero", mar = "Marzo", abr = "Abril";
                    string may = "Mayo", jun = "Junio", jul = "Julio", ago = "Agosto";
                    string sep = "Septiembre", oct = "Octubre", nov = "Noviembre", dic = "Diciembre";
                    ListitaMeses.Add(ene); ListitaMeses.Add(feb); ListitaMeses.Add(mar); ListitaMeses.Add(abr);
                    ListitaMeses.Add(may); ListitaMeses.Add(jun); ListitaMeses.Add(jul); ListitaMeses.Add(ago);
                    ListitaMeses.Add(sep); ListitaMeses.Add(oct); ListitaMeses.Add(nov); ListitaMeses.Add(dic);
                    RaisePropertyChanged("ListitaMeses");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error critico al recuperar los datos del sistema contable del cliente.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. ", "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        } 

        private void ObtenerDatosCronograma()// Pestaña 4 (Cronograma)
        {
            using (db = new SGPTEntidades())
            {
                try
                {
                    //ListadoEtapasEncargos=
                    ListadoProcesosAuditoria=new List<procesosauditoria>();
                    ListadoProcesosAuditoria=(from p in db.procesosauditorias where p.estadopa=="A" select p).ToList();
                    RaisePropertyChanged("ListadoProcesosAuditoria");

                    ListadoVisitas=new List<visita>();
                    ListadoVisitas = (from v in db.visitas where v.estadovisita == "A" select v).ToList();
                    RaisePropertyChanged("ListadoVisitas");
                }
                catch (Exception)
                {
                    MessageBox.Show("Error critico al recuperar los datos del detalle del cronograma.\nLa base de datos tardo demasiado en responder.\nNotifique a soporte tecnico acerca de este error si continua. ", "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ObtenerDatosPresupuesto()//Pestaña 5 (Presupuesto) Todos son puros calculos
        {
            if(ListadoProcesosAuditoria!=null)
            {
                ListadoPresupuesto = new List<Presupuesto>();
                try 
	            {
                    int i = 1;
	            	foreach (var a in ListadoProcesosAuditoria)
	                {
                        Mouse.OverrideCursor = Cursors.Wait;
                        #region +
                        Presupuesto pr = new Presupuesto();
                        pr.correlativo = i; i++;
                        pr.etapaauditoria = a.descripcionpa;
                        var pers = (from p in ListadoDetalleCronograma where p.idpa == a.idpa select p).ToList();
                        if (pers != null && pers.Count>0)
                        {
                            pr.personalasignado = pers.Sum(x => x.cantidadPersonasAsignadasPorEtapa);
                            pr.horastotales = Math.Round(pers.Sum(z => z.horasplaneadasdc));
                            decimal pm = pers.Sum(y => y.valorUs);
                            pr.preciomediohora = pm / pr.horastotales;
                            pr.MontoPorEtapa = pers.Sum(j => j.valorUs);
                        }
                        else
                        {
                            pr.personalasignado = 0;
                            pr.preciomediohora = 0;
                            pr.horastotales = 0;
                            pr.MontoPorEtapa = 0;
                        }
                        ListadoPresupuesto.Add(pr);

                        #endregion
                        Mouse.OverrideCursor = null;
	                }
                    RaisePropertyChanged("ListadoPresupuesto");
                    txtSumaTotalPersonasPresupuesto= ListadoPresupuesto.Sum(r=>r.personalasignado);
                        txtHorasTotalesPresupuesto= (int)(Math.Round(ListadoPresupuesto.Sum(s=>s.horastotales)));
                        txtCostoTotalPresupuesto=ListadoPresupuesto.Sum(t=>t.MontoPorEtapa); 
                        //Honorariosencargo=
                        if (decimal.Parse(Honorariosencargo) > 0)
                            txtIndicePresupuesto = txtCostoTotalPresupuesto / decimal.Parse(Honorariosencargo);
                        else
                            txtIndicePresupuesto = 0;

	            }
	            catch (Exception e)
	            {
	            	MessageBox.Show("Ocurrio un error en la creacion del presupuesto "+e.InnerException);
	            }
            }
            
        }


        //***********************Datos Generales*****************************
        //Nada

        //***********************Personal************************

        #region +
        public ICommand _cmdAgregarPersonal;
        public ICommand cmdAgregarPersonal
        {
            get
            {
                return _cmdAgregarPersonal ?? (_cmdAgregarPersonal = new CommandHandler(() => MycmdAgregarPersonal(), _canExecute));
            }
        }
        private async void MycmdAgregarPersonal()
        {
            if (EstaEditandoFilaEnPersonal)
            {
                #region +
                ListadoPersonalAsignado2.Remove(SelectedPersonalAsignado);
                SelectedPersonalAsignado.horasplanasignacion = HorasPlaneadasPersonal;
                SelectedPersonalAsignado.preciohoraasignacion = Math.Round((Convert.ToDecimal(CostoHoraUs)), 2);
                ListadoPersonalAsignado2.Add(SelectedPersonalAsignado);
                ListadoPersonalAsignado = new List<AsignacionesModelo>();
                foreach (var x in ListadoPersonalAsignado2)
                {
                    ListadoPersonalAsignado.Add(x);
                }
                RaisePropertyChanged("ListadoPersonalAsignado");
                if (OpcionDeVisitaAqui==2) //si es editar, tiene que guardar directamente en la base.
                {
                    using (db = new SGPTEntidades())
                    {
                        //foreach (var z in ListadoPersonalAsignado)
                        //{
                        #region +
                        asignacione a = new asignacione();
                        a = db.asignaciones.Find(SelectedPersonalAsignado.idasignacion);
                        if (a != null) //significa que lo hallo en la base
                        {
                            a.horasplanasignacion = SelectedPersonalAsignado.horasplanasignacion;
                            a.preciohoraasignacion = SelectedPersonalAsignado.preciohoraasignacion;
                            db.Entry(a).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        else // significa qeu NO lo hallo en la base. tiene ue hallarlo, porque es una edicion
                        {

                        }
                        #endregion
                        //}
                    }  
                }
                #endregion
            }
            else
            {
                Random r = new Random();
                //MessageBox.Show("Agregar Personal");
                if (await NoEstaAsignadoElAuditor())
                {
                    //using (db = new SGPTEntidades())
                    //{
                    try
                    {
                        #region +
                        var u = ListadoUsuarios.Find(x => x.idusuario == SelectedUsuarioPersonal.idusuario);
                        AsignacionesModelo asi = new AsignacionesModelo();
                        asi.idusuario = u.idusuario;
                        asi.nombreCompletoUsuario = u.nombreCompleto;
                        asi.idrol = u.idrol;
                        asi.rolUsuario = u.nombrerol;
                        asi.horasplanasignacion = HorasPlaneadasPersonal;
                        asi.preciohoraasignacion = Math.Round((Convert.ToDecimal(CostoHoraUs)), 2);
                        asi.UssPlaneado = HorasPlaneadasPersonal * Math.Round((Convert.ToDecimal(CostoHoraUs)), 2);
                        asi.UssEjecutado = 0;
                        asi.Indice = 0;
                        ListadoPersonalAsignado2.Add(asi);
                        ListadoPersonalAsignado = new List<AsignacionesModelo>();
                        foreach (var x in ListadoPersonalAsignado2)
                        {
                            ListadoPersonalAsignado.Add(x);
                        }
                        //ListadoPersonalAsignado = ListadoPersonalAsignado2;
                        RaisePropertyChanged("ListadoPersonalAsignado");
                        /*Actualizo la base de un solo*/
                        if (OpcionDeVisitaAqui==2)
                        {
                            using (db = new SGPTEntidades())
                            {
                                foreach (var z in ListadoPersonalAsignado)
                                {
                                    #region +
                                    asignacione a = new asignacione();
                                    a = db.asignaciones.Find(z.idasignacion);
                                    if (a != null) //significa que lo hallo en la base
                                    {
                                        //a.horasplanasignacion = z.horasplanasignacion;
                                        //a.preciohoraasignacion = z.preciohoraasignacion;
                                        //db.Entry(a).State = EntityState.Modified;
                                    }
                                    else // significa qeu NO lo hallo en la base.
                                    {
                                        a = new asignacione();
                                        a.idusuario = SelectedUsuarioPersonal.idusuario; // z.idusuario;
                                        a.idencargo = currentEncargo.idencargo;
                                        a.fechacreaasignacion = DateTime.Now.ToShortDateString();
                                        a.horasplanasignacion = z.horasplanasignacion;
                                        a.horasejecucionasignacion = z.horasejecucionasignacion;
                                        a.preciohoraasignacion = z.preciohoraasignacion;
                                        a.idasignacion = r.Next(1000, 100000);
                                        a.estadoasignacion = "A";
                                        db.asignaciones.Add(a);
                                        db.SaveChanges();
                                    }
                                    #endregion
                                }
                            } 
                        }

                        SelectedUsuarioPersonal = null;
                        HorasPlaneadasPersonal = 0;
                        CostoHoraUs = "";
                        SelectedPersonalAsignado = null;
                        #endregion
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio un error al agregar la fila. "+e.InnerException);
                        //AvisaYCerrateVosSolo("Ocurrio un error al agregar una nueva fila ", "Error al agregar una nueva fila",1);
                    }
                    //} 
                } 
            }
        }

        private async Task<bool> NoEstaAsignadoElAuditor()
        {
            if (SelectedUsuarioPersonal!=null)
            {
                var si = ListadoPersonalAsignado2.Find(x => x.idusuario == SelectedUsuarioPersonal.idusuario);
                if (si == null)
                    return true;
                else
                {
                    await AvisaYCerrateVosSolo("El auditor: [ " + si.nombreCompletoUsuario + " ] ya fue asignado al listado.", "Seleccione otro auditor", 2);
                    return false;
                } 
            }
            else
            {
                await AvisaYCerrateVosSolo("No ha seleccionado el personal del listado", "", 1);
                return false;
            }

        }

        public ICommand _cmdEliminarPersonal;
        public ICommand cmdEliminarPersonal
        {
            get
            {
                return _cmdEliminarPersonal ?? (_cmdEliminarPersonal = new CommandHandler(() => MycmdEliminarPersonal(), _canExecute));
            }
        }

        private async void MycmdEliminarPersonal()
        {

            try
            {
                if (SelectedPersonalAsignado != null)
                {
                    asignacione dej = new asignacione();
                    using (db = new SGPTEntidades())
                    {
                        dej = db.asignaciones.Find(SelectedPersonalAsignado.idasignacion);

                        if (dej != null)
                        {
                            db.Entry(dej).State = EntityState.Deleted;
                            db.SaveChanges();
                            ListadoPersonalAsignado2.Remove(SelectedPersonalAsignado);
                            ListadoPersonalAsignado = new List<AsignacionesModelo>();
                            foreach (var x in ListadoPersonalAsignado2)
                            {
                                ListadoPersonalAsignado.Add(x);
                            }
                            RaisePropertyChanged("ListadoPersonalAsignado");
                            await AvisaYCerrateVosSolo("Una fila fue removida", "", 1);
                        }
                        else
                        {
                            ListadoPersonalAsignado2.Remove(SelectedPersonalAsignado);
                            ListadoPersonalAsignado = new List<AsignacionesModelo>();
                            foreach (var x in ListadoPersonalAsignado2)
                            {
                                ListadoPersonalAsignado.Add(x);
                            }
                            RaisePropertyChanged("ListadoPersonalAsignado");
                            await AvisaYCerrateVosSolo("Una fila fue removida", "", 1);
                        }
                    }
                }
                else
                {
                    await AvisaYCerrateVosSolo("Debe Seleccionar un registro para quitarlo de la lista", "Seleccione un registro", 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error "+e.InnerException);
                //AvisaYCerrateVosSolo("" + e.InnerException, "", 1);
            }
        } 
        #endregion

        /*****************************************************************************************/
        /*Sistema Contable*/
        //Sistema Contable

        ///*********************Sistema Contable*******************/

        #region +

        private void MyPestañaContable() //Al hacer click en pestaña 3
        {
            this.MybtnCancelarCambiosPersonal(); //restablece la barra y el datagrid del personal, por si estan atascados
            //txtBanderaCargarCatalogo = "1";
            PestañaSeleccionada = 3;
            txtBanderaAgregar = "0";
            txtBanderaEliminar = "0";
            this.PermisosUsuarioValidado("Sistemas Contables");
            //this.ObtenerDatosSistemasCont();
            if (OpcionDeVisitaAqui == 1 || OpcionDeVisitaAqui == 2)
            {
                txtBanderaEditar = "0";
            }
        }
        //private void MyPestañaContablePerdioFoco() //Al perder el foco pestaña 3
        //{
        //    MessageBox.Show("Perdio foco mi pestaña contable");
        //    txtBanderaCargarCatalogo = "0";
        //}
        private ICommand _cmdCargarCatalogo;
        public ICommand cmdCargarCatalogo { get { return _cmdCargarCatalogo ?? (_cmdCargarCatalogo = new CommandHandler(() => MycmdCargarCatalogo3(), _canExecute)); } }
        //public ICommand cmdCargarCatalogo { get { return _cmdCargarCatalogo ?? (_cmdCargarCatalogo = new CommandHandler(() => cargarCat2(), _canExecute)); } }
        //cargarCat2

        private async void MycmdCargarCatalogo3()
        {
            //Atencion 01/03/2017 00:33 am aqui hay que cambiar, ya que el catalogo de cuentas no pertenece al cliente directamente, sino a un encargo del cliente. El cliente puede tener muchos encargos en diferentes periodos.
            if (EncargoSelected != null)
            {
                #region +
                try
                {
                    #region +
                    if (UsuarioPuedeCrear) //si tiene permisos de crear
                    {
                        ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal();
                        if (OpcionDeVisitaAqui == 1)
                        {
                            mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.SistemaContableAModificar = CurrentSistemaContable;
                        }
                        else if (OpcionDeVisitaAqui == 2)
                        {
                            mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Editar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.SistemaContableAModificar = CurrentSistemaContable;
                        }
                        else if (OpcionDeVisitaAqui == 3)
                        {
                            mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Consultar; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = currentCliente; mensajito.SistemaContableAModificar = CurrentSistemaContable;
                        }
                        //CargarCatalogoClientesExpedientes mivista = new CargarCatalogoClientesExpedientes(mensajito);
                        //var res = mivista.ShowDialog();

                        EDCatalogoCuentasMainModel.TypeName = "CatalogoCuentasModeloCargarView";

                        CargarArchivosMensajeModal carga = new CargarArchivosMensajeModal();
                        carga.TipoArchivoACargar = TipoArchivoCargar.CatalogoDeCuenta;
                        carga.encargoModelo = SGPTWpf.Model.Modelo.Encargos.EncargoModelo.GetRegistro(EncargoSelected.idencargo);
                        carga.usuarioModelo = UsuarioModelo.GetRegistroById(currentUsuario.idusuario);
                        //ImportarArchivosGeneralesView mivista2 = new ImportarArchivosGeneralesView(carga); //Original
                        //var rz = mivista2.ShowDialog();


                        //enviarMensajeCargarCatalogo();


                        Messenger.Default.Send<CargarArchivosMensajeModal>(carga, "ImportarArchivos");
                        //this.ObtenerDatosContactos();

                        RaisePropertyChanged("");
                    }
                    else
                    {
                        //await dlg.ShowMessageAsync(this, "El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
                        MessageBox.Show("El usuario: " + currentUsuario.nickusuariousuario + " no tiene permisos para crear catalogos del cliente.", "Consulte al administrador acerca de esta restriccion.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    #endregion
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al comparar los permisos del usuario", "Error al levantar la vista de la carga de catalogos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("Seleccione un encargo para continuar.", "", 2);
            }
        }
        private void MycmdCargarCatalogo()
        {
            #region +
            //MessageBox.Show("Cargar catalogo");

            OpenFileDialog arc = new OpenFileDialog();
            arc.Filter = "Excel Files |*.xlsx";
            arc.Title = "Abrir catalogo";
            arc.ShowDialog();
            string sArchivo = arc.FileName;

            Microsoft.Office.Interop.Excel.Application exlApp;
            Workbook exlWbook;
            Worksheet exlWsheet;

            exlApp = new Microsoft.Office.Interop.Excel.Application();

            exlWbook = exlApp.Workbooks.Open(sArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            exlWsheet = (Worksheet)exlWbook.Worksheets.get_Item(1);
            Range exlRange;
            string sValor;

            //Definimos el el rango de celdas que seran leidas
            exlRange = exlWsheet.UsedRange;
            System.Data.DataTable dt = new System.Data.DataTable();
            //Recorremos el archivo excel como si fuera una matriz
            for (int i = 1; i <= exlRange.Rows.Count; i++)
            {
                sValor = "";
                for (int j = 1; j <= exlRange.Columns.Count; j++)
                {
                    sValor += " " + (exlRange.Cells[i, j] as Range).Value + "";
                }
                //lstbDatos.Add(sValor);
                dt.Columns.Add(sValor);
                RaisePropertyChanged("lstbDatos");
            }

            //cerramos el libro y la aplicacion
            exlWbook.Close();
            exlApp.Quit();
            #endregion
        }

        private System.Data.DataView _dtGrd;
        public System.Data.DataView dtGrd
        {
            get { return _dtGrd; }
            set
            {
                _dtGrd = value;
                RaisePropertyChanged("dtGrd");
            }
        }

        private void cargarCat2()
        {
            #region +
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {
                string sArchivo = openfile.FileName;
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(sArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                System.Data.DataTable dt = new System.Data.DataTable();
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    dt.Columns.Add(strColumn, typeof(string));
                }

                for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    string strData = "";
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += strCellData + "|";
                        }
                        catch (Exception)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                }

                //dtGrid.ItemsSource = dt.DefaultView;
                dtGrd = dt.DefaultView;


                excelBook.Close(true, null, null);
                excelApp.Quit();
            }
            #endregion
        }
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
        private async void MycmdGuardarCatalogo(int idencargo)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region +
            if (ValidacionManualCatOk())
            {
                #region v

                cliente cli = new cliente();
                sistemascontable sis = new sistemascontable();

                using (db = new SGPTEntidades())
                {
                    if (AccionGuardar) { sis = new sistemascontable(); }
                    else
                    {
                        sis = db.sistemascontables.Find(CurrentSistemaContable.idsc);
                    }
                }

                //sis.idsc = 1000;
                sis.idencargodsc = idencargo;
                sis.idmoneda = SelectedMoneda.idmoneda;
                sis.idnitcliente = SelectedCliente.idnitcliente;//Idnitcliente;
                sis.ideef = SelectedEstructuraEstFin.ideef;
                sis.fechasc = DateTime.Now.ToShortDateString();
                sis.digitoscuentamayorsc = SelectedCantDigitCtasMayor;
                sis.digitosrubroscontablessc = SelectedCantDigitRubrosCont;
                string mesinic = NumeroMes(SelectedMesInicio);
                string mesfin = NumeroMes(SelectedMesFin);
                sis.periodoiniciosc = SelectedDiaInicio.ToString() + "/" + mesinic; //Periodoiniciosc.ToShortDateString();
                sis.periodofinsc = SelectedDiaFin.ToString() + "/" + mesfin;//Periodofinsc.ToShortDateString();
                sis.estadosc = "A";

                if (AccionGuardar)
                {
                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            sis.idsc = 100000;
                            db.sistemascontables.Add(sis);
                            //await cuenteUno();
                            db.SaveChanges();

                            CurrentSistemaContable = sis;
                            foreach (var a in ListadoElementos)
                            {
                                elemento el = new elemento();
                                el.idelementos = 10000000;
                                el.idnitcliente = SelectedCliente.idnitcliente;
                                el.descripcionelementos = a.descripcionelementos;
                                el.fechacreacionelementos = DateTime.Now.ToShortDateString();
                                el.sistemaelementos = false;
                                el.estadoelementos = "A";
                                el.idscelementos = sis.idsc;
                                el.codigoelemento = a.codigoelemento;
                                db.elementos.Add(el);
                                db.SaveChanges();
                            }
                            txtBanderaCat = "0"; //Lo desactivo para que ya no pueda guardar nuevamento lo mismo
                            RaisePropertyChanged("txtBanderaCat");
                            Message = "Sistema Contable guardado.";
                            //HabilitarCargarCatalogo = true;
                            //HabilitarTabPersonal = true;
                            //RaisePropertyChanged("HabilitarTabPersonal");
                            //PestañaSeleccionada = 1;
                            //RaisePropertyChanged("PestañaSeleccionada");
                            MessageSistCont = "Sistema contable ha sido guardado.";
                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("Mucha atencion!!!"+Environment.NewLine+"Es necesario que ingrese el catalogo de cuentas asociado a este encargo.", "Importar catalogo de cuentas",2);
                            #endregion
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar en Sistema Contable.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. " + e.InnerException, "Imposible guardar el sistema contable", MessageBoxButton.OK, MessageBoxImage.Stop);
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
                            db.Entry(sis).State = EntityState.Modified; db.SaveChanges();
                            CurrentSistemaContable = sis;

                            foreach (var a in ListadoElementos)
                            {
                                elemento el = new elemento();
                                el = db.elementos.Find(a.idelementos);
                                //el.idnitcliente = SelectedCliente.idnitcliente;
                                //el.descripcionelementos = a.descripcionelementos;
                                //el.fechacreacionelementos = DateTime.Now.ToShortDateString();
                                //el.sistemaelementos = false;
                                //el.estadoelementos = "A";
                                //el.idscelementos = sis.idsc;
                                el.codigoelemento = a.codigoelemento;
                                db.Entry(el).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            await AvisaYCerrateVosSolo("Los cambios se guardaron con éxito.", "Finalizado.", 1);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ocurrio un error al guardar los cambios en sistemas contables.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico.", "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                            //this.cmdCancelar();
                        }
                        #endregion

                    }
                    //this.FinalizarAction();
                    #endregion
                }

                #endregion
            }
            
            #endregion
            Mouse.OverrideCursor = null;
        }  //Ojo, por el momento esta invalidado 13/03/2017 porque la importacion del catalogo se hara en otra ventana
        #endregion

        //*********************Cronograma***********************
        #region +
        private void MyPestañaMiComanditoCronograma()
        {
            this.MybtnCancelarCambiosPersonal(); //restablece la barra y el datagrid del personal, por si estan atascados
            if (ListadoPersonalAsignado2 == null || ListadoPersonalAsignado2.Count==0) //necesito el listado de los auditores disponibles
                this.MyPestañaMiComanditoPersonal();

            PestañaSeleccionada = 4;
            this.PermisosUsuarioValidado("Cronogramas");
            
            //this.ObtenerDatosCronograma();
            if (OpcionDeVisitaAqui == 1 || OpcionDeVisitaAqui == 2)
            {
                txtBanderaAgregar = "0";
                txtBanderaEliminar = "1";
                txtBanderaEditar = "1";
            }

            //this.PermisosUsuarioValidado("Asignaciones");
            //this.ObtenerDatosPersonal();
            //this.ObtenerDatosCronograma();
        }
        //cmdAsignarPersonal_Click

        public ICommand _cmdAsignarPersonal_Click;
        public ICommand cmdAsignarPersonal_Click
        {
            get
            {
                return _cmdAsignarPersonal_Click ?? (_cmdAsignarPersonal_Click = new CommandHandler(() => MycmdAsignarPersonal_Click(), _canExecute));
            }
        }

        private async void MycmdAsignarPersonal_Click()
        {
            if (OpcionDeVisitaAqui!=3)
            {
                if (ListadoPersonalAsignado2 != null || ListadoPersonalAsignado2.Count == 0)
                {
                    if (EstaEditandoFilaEnCronograma == true)
                    {
                        await dlg.ShowMessageAsync(this,"Atencion, el personal actual y sus horas asignadas para esta tarea, se veran afectados y reemplazados por estos cambios", "Haga click en Cancelar para abortar...");
                    }
                    #region +
                    Messenger.Default.Register<ClientesEncargosCronogramaMensajeModal>(this, (ClientesEncargosCronogramaMensajeModal) => PersonalAsignadoPorEtapa(ClientesEncargosCronogramaMensajeModal));
                    //calculamos cuantas horas maximas pueden ser asignadas
                    //foreach (var pers in ListadoPersonalAsignado)
                    //{
                    //    foreach (var cro in ListadoDetalleCronograma)
                    //    {
                    //        pers.HorasQueQuedanPorAsignar = pers.horasplanasignacion - cro.horasplaneadasdc;
                    //    }
                    //}

                    ClientesEncargosCronogramaMensajeModal mensajito = new ClientesEncargosCronogramaMensajeModal(); mensajito.ListadoPersonalAsignado = ListadoPersonalAsignado; mensajito.Etapa = SelectedProcesosAuditoria.idpa; mensajito.nombreEtapa = SelectedProcesosAuditoria.descripcionpa; mensajito.Visita = SelectedVisita.idvisita; mensajito.nombreVisita = SelectedVisita.descripcionvisita;
                    //Messenger.Default.Send<UsuariosMensajeModal>(mensajito);
                    //CRUDusuariosView mivista = new CRUDusuariosView(mensajito);
                    AsigPersClientesEncargosCronograma mivista = new AsigPersClientesEncargosCronograma(mensajito);
                    var res = mivista.ShowDialog();
                    //MostrarModalDialog(mensajito);
                    Messenger.Default.Unregister<ClientesEncargosCronogramaMensajeModal>(this);
                    txtBanderaAgregar = "1"; //activo el boton de la barra para que pueda agregar la nueva fila al datagrid. 
                    #endregion
                }
                else
                {
                    await AvisaYCerrateVosSolo("Es necesario que cree el listado de los auditores disponibles para este encargo.", "Agregue el personal en la pestaña PERSONAL", 3);
                } 
            }
            else
            {
                await AvisaYCerrateVosSolo("No se puede asignar personal en modo de consulta","",1);
            }
        }

        private async void PersonalAsignadoPorEtapa(ClientesEncargosCronogramaMensajeModal PersonalMensajeModal)
        {
            if (PersonalMensajeModal.HayAgregadosSioNo)
            {
                txtPuedeAgregarDetCronograma = "1";
                ListadoPersonalSeleccionadoxEtapa = new List<AsignacionesModelo>();
                ListadoPersonalSeleccionadoxEtapa = PersonalMensajeModal.ListadoPersonalSeleccionado;
                txtBanderaAgregar = "1";
                //AvisaYCerrateVosSolo("El personal fue asignado. \nHaga click en el boton 'AGREGAR' para insertar la fila", "Listo. Haga click en Agregar",3);
                if (EstaEditandoFilaEnCronograma == true)
                {
                    await dlg.ShowMessageAsync(this, "El personal fue asignado. \nHaga click en el boton 'ACEPTAR' para ver los cambios.", "Listo. Haga click en Aceptar y no se olvide de guardar antes de salir.");
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El personal fue asignado. \nHaga click en el boton 'AGREGAR' para insertar la fila", "Listo. Haga click en Agregar");
                }
                
            }
            else
            {
                if (EstaEditandoFilaEnCronograma == true)
                {
                    await AvisaYCerrateVosSolo("El personal designado para la tarea no sufrio cambios...","",1); 
                }
                else
                {
                    await AvisaYCerrateVosSolo("Atencion!!! \nEl personal No ha sido asignado para esta tarea.\n Haga click en el boton Asignar para continuar", "Haga click en Asignar", 3);
                }
                txtPuedeAgregarDetCronograma = "0";
                txtBanderaAgregar = "0";
            }
        }


        //cmdAgregarDetCrono

        public ICommand _cmdAgregarDetCrono;
        public ICommand cmdAgregarDetCrono
        {
            get
            {
                return _cmdAgregarDetCrono ?? (_cmdAgregarDetCrono = new CommandHandler(() => MycmdAgregarDetCrono(), _canExecute));
            }
        }

        private void MycmdAgregarDetCrono()
        {
            
                if (EstaEditandoFilaEnCronograma)
                {
                    try
                    {
                        #region +
                        var det = ListadoDetalleCronograma2.Find(x => x.correlativo == SelectedDetalleCronograma.correlativo);
                        det.idpa = SelectedProcesosAuditoria.idpa;
                        det.nombreProcesoAuditoria = SelectedProcesosAuditoria.descripcionpa;
                        det.idvisita = SelectedVisita.idvisita;
                        det.nombreVisita = SelectedVisita.descripcionvisita;
                        det.actividaddc = Actividaddc;
                        det.fechainicialdc = Fechainicialdc;
                        det.fechafinaldc = Fechafinaldc;

                        if (ListadoPersonalSeleccionadoxEtapa != null)
                        {
                            det.horasplaneadasdc = 0;
                            det.iDpersonalPorEtapa = "";
                            det.cantidadPersonasAsignadasPorEtapa = ListadoPersonalSeleccionadoxEtapa.Count();
                            det.personalPorEtapa = "";
                            det.valorUs = 0;
                            foreach (var a in ListadoPersonalSeleccionadoxEtapa)
                            {
                                det.horasplaneadasdc += a.horasplanasignacion;
                                det.iDpersonalPorEtapa += ";" + a.idusuario.ToString() + ": " + a.horasplanasignacion.ToString();
                                det.personalPorEtapa += a.nombreCompletoUsuario + "=> horas: " + a.horasplanasignacion.ToString() + ", ";
                                det.valorUs += a.UssPlaneado;
                            }
                        }
                        ListadoDetalleCronograma = new List<detalleCronogramaModelo>();
                        TotalHoras = 0;
                        TotalUs = 0;
                        int i = 1;
                        foreach (var a in ListadoDetalleCronograma2)
                        {
                            a.correlativo = i; i++;
                            TotalHoras += a.horasplaneadasdc;
                            TotalUs += a.valorUs;

                            ListadoDetalleCronograma.Add(a);
                        }
                        RaisePropertyChanged("ListadoDetalleCronograma"); 
                        #endregion
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("PDetCronograma " + e.InnerException);
                    }
                }
                else
                {
                    try
                    {
                        if (ListadoDetalleCronograma2 == null || ListadoDetalleCronograma2.Count()==0 )
                            ListadoDetalleCronograma2 = new List<detalleCronogramaModelo>();
                        #region +
                        //MessageBox.Show("Agregar cronograma");
                        detalleCronogramaModelo det = new detalleCronogramaModelo();
                        det.idpa = SelectedProcesosAuditoria.idpa;
                        det.nombreProcesoAuditoria = SelectedProcesosAuditoria.descripcionpa;
                        det.idvisita = SelectedVisita.idvisita;
                        det.nombreVisita = SelectedVisita.descripcionvisita;
                        det.actividaddc = Actividaddc;
                        det.fechainicialdc = Fechainicialdc;
                        det.fechafinaldc = Fechafinaldc;

                        if (ListadoPersonalSeleccionadoxEtapa != null)
                        {
                            det.cantidadPersonasAsignadasPorEtapa = ListadoPersonalSeleccionadoxEtapa.Count();
                            foreach (var a in ListadoPersonalSeleccionadoxEtapa)
                            {
                                det.horasplaneadasdc += a.horasplanasignacion;
                                det.iDpersonalPorEtapa += ";" + a.idusuario.ToString() + ": " + a.horasplanasignacion.ToString();
                                det.personalPorEtapa += a.nombreCompletoUsuario + "=> horas: " + a.horasplanasignacion.ToString() + ", ";
                                det.valorUs += a.UssPlaneado;
                            }
                        }

                        ListadoDetalleCronograma2.Add(det);
                        ListadoDetalleCronograma = new List<detalleCronogramaModelo>();
                        TotalHoras = 0;
                        TotalUs = 0;
                        int i = 1;
                        foreach (var a in ListadoDetalleCronograma2)
                        {
                            a.correlativo = i; i++;
                            TotalHoras += a.horasplaneadasdc;
                            TotalUs += a.valorUs;

                            ListadoDetalleCronograma.Add(a);
                        }
                        //ListadoDetalleCronograma = ListadoDetalleCronograma2;
                        RaisePropertyChanged("ListadoDetalleCronograma");

                        // ahora hay que limpiar los campos.
                        SelectedProcesosAuditoria = null;
                        SelectedVisita = null;
                        Actividaddc = "";
                        Fechainicialdc = DateTime.Now;
                        Fechafinaldc = DateTime.Now.AddDays(15);
                        txtPuedeAgregarDetCronograma = "0";
                        ListadoPersonalSeleccionadoxEtapa = null;

                        #endregion
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("PDetCronograma " + e);
                    }
                }
            
        }

        public ICommand _cmdEliminarDetCrono;
        public ICommand cmdEliminarDetCrono
        {
            get
            {
                return _cmdEliminarDetCrono ?? (_cmdEliminarDetCrono = new CommandHandler(() => MycmdEliminarDetCrono(), _canExecute));
            }
        }

        private async void MycmdEliminarDetCrono() //atencion, falta volver a calcular los totales.15/03/2016
        {
            //MessageBox.Show("Eliminar cronograma");
            if (SelectedDetalleCronograma != null) 
            {
                detallecronograma dej = new detallecronograma();
                using (db = new SGPTEntidades())
                {
                    dej=db.detallecronogramas.Find(SelectedDetalleCronograma.iddc);
                }
                if (dej!=null)
	            {
		            #region +
		            var mySettingsk = new MetroDialogSettings()
                    {
                        AffirmativeButtonText = "Si",
                        NegativeButtonText = "No",
                    };
                    MessageDialogResult resultk = await dlg.ShowMessageAsync(this, "Se eliminara directamente desde la base de datos."+Environment.NewLine+"Esta seguro que desea continuar?", "Eliminando sin poder recuperar", MessageDialogStyle.AffirmativeAndNegative, mySettingsk);
                   if (resultk == MessageDialogResult.Affirmative)
	                {
	            	    try 
	                    {	        
                            #region +
		                
                            using(db=new SGPTEntidades())
	                        {
                                //Atencion, al eliminar aqui, lo haremos de un solo desde la base, pq esta complejo modificar y guardar.
	                	        detallecronograma detcro = new detallecronograma();
                                detcro = db.detallecronogramas.Find(SelectedDetalleCronograma.iddc);
                                db.Entry(detcro).State = EntityState.Deleted;
                                db.SaveChanges(); 
	                        }
                            ListadoDetalleCronograma2.Remove(SelectedDetalleCronograma);
                            ListadoDetalleCronograma = new List<detalleCronogramaModelo>();
                            int i = 1;
                            foreach (var a in ListadoDetalleCronograma2)
                            {
                                a.correlativo = i; i++;
                                ListadoDetalleCronograma.Add(a);
                            }
                            //ListadoDetalleCronograma = ListadoDetalleCronograma2;
                            RaisePropertyChanged("ListadoDetalleCronograma"); 
	                        #endregion
	                    }
	                    catch (Exception e)
	                    {
                            MessageBox.Show("Error al eliminar "+e.InnerException);
	                	    //AvisaYCerrateVosSolo("No se pudo eliminar la fila","",1);
	                    } 
	                } 
	                #endregion 
	            }
                else
                {
                    ListadoDetalleCronograma2.Remove(SelectedDetalleCronograma);
                    ListadoDetalleCronograma = new List<detalleCronogramaModelo>();
                    int i = 1;
                    foreach (var a in ListadoDetalleCronograma2)
                    {
                        a.correlativo = i; i++;
                        ListadoDetalleCronograma.Add(a);
                    }
                    //ListadoDetalleCronograma = ListadoDetalleCronograma2;
                    RaisePropertyChanged("ListadoDetalleCronograma"); 
                }
                
            }
            else
            {
                await AvisaYCerrateVosSolo("Debe seleccionar el registro que desea quitar.", "Seleccione un registro para continuar",1);
            }
        } 
        #endregion

        //*********************Presupuesto**********************

        #region +
        private async void MyPestañaMiComanditoPresupuesto()
        {
            this.MybtnCancelarCambiosPersonal(); //restablece la barra y el datagrid del personal, por si estan atascados
            if (ListadoDetalleCronograma != null)
            {
                if (ListadoDetalleCronograma.Count()>0)
                {
                    #region +
                    if (OpcionDeVisitaAqui == 1)
                    {
                        if (SelectedCliente != null)
                        {
                            MessagePresupuesto = "Presupuesto del cliente: " + SelectedCliente.razonsocialcliente + " para el encargo: Actual/Sin guardar aun.";
                            txtBanderaNuevo = "0";
                            txtBanderaEditar = "0";
                            txtBanderaConsultar = "0";
                            txtBanderaCancelar = "1";
                            txtBanderaAgregar = "0";
                            txtBanderaEliminar = "0";
                            this.PermisosUsuarioValidado("Cronogramas");
                            this.ObtenerDatosPresupuesto();
                        }
                        else
                        {
                            await AvisaYCerrateVosSolo("No disponible por el momento.", "Seleccione el cliente propietario del encargo", 2);
                            FocoPestañaSeleccionada = 0;
                        }
                    }
                    else
                    {
                        MessagePresupuesto = "Presupuesto del cliente: " + currentCliente.razonsocialcliente + " para el encargo: " + currentEncargo.nombreTa;
                        txtBanderaNuevo = "0";
                        txtBanderaEditar = "0";
                        txtBanderaConsultar = "0";
                        txtBanderaCancelar = "1";
                        txtBanderaAgregar = "0";
                        txtBanderaEliminar = "0";
                        this.PermisosUsuarioValidado("Cronogramas");
                        this.ObtenerDatosPresupuesto(); 
                    }
                        

                    //if (ListadoDetalleCronograma == null)
                    //{
                    //    AvisaYCerrateVosSolo("Es necesario crear el cronograma de actividades", "No ha introducido el cronograma para este encargo", 2);
                    //    FocoPestañaSeleccionada = 3;
                    //}

                    
                    
                    #endregion
                }
                else
                {
                    await AvisaYCerrateVosSolo("Es necesario que ingrese primeramente el cronograma","No hay ningun cronograma de actividades para el encargo",1);
                    FocoPestañaSeleccionada = 4;
                }
            }
            else
            {
                await AvisaYCerrateVosSolo("Es necesario que ingrese primeramente el cronograma", "No hay ningun cronograma de actividades para el encargo", 1);
                FocoPestañaSeleccionada = 4;
            }
        }
        #endregion
        //********Control general**Guardar todo y cancelar todo********************************************************/
        private ICommand _cmdGuardarDatos;
        public ICommand cmdGuardarDatos
        {
            get { return _cmdGuardarDatos ?? (_cmdGuardarDatos = new CommandHandler(() => MycmdGuardarDatos(), _canExecute)); }
        }

        public ICommand _CmdVolver; //permite volver al listado de clientes.
        public ICommand CmdVolverA { get { return _CmdVolver ?? (_CmdVolver = new CommandHandler(() => MyCmdVolver(), _canExecute)); } }


        private void MyCmdVolver() //Sirve para reactivar el panel izquierdo
        {
            Messenger.Default.Send<String>("2", "mensajevacio");
        }

        private async void activarBarraGuardarDatos()
        {
            #region +
            if (ListadoPersonalAsignado == null || ListadoPersonalAsignado.Count == 0)
            {
                await AvisaYCerrateVosSolo("Atencion, no ha ingresado el personal para atender este encargo.","Encargo incompleto, pero puede editarlo despues", 1);
            }


            if (ListadoDetalleCronograma == null || ListadoDetalleCronograma.Count == 0)
            {
                await AvisaYCerrateVosSolo("Atencion, no ha ingresado el cronograma de actividades para este encargo.","Encargo incompleto, pero puede editarlo despues", 1);
            }
            var mySettingsk = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Si",
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
            //dlg.ShowMessageAsync(this, "Guardar en linea 2025","");
            if (ValidacionManualCatOk())
            {
                #region v
                Mouse.OverrideCursor = Cursors.Wait;
                encargo enc = new encargo();

                sistemascontable y = new sistemascontable();
                using (db = new SGPTEntidades())
                {
                    //nota: para que buscamos el sistema contable? hacerlo diferente, porque aqui lo vamos a agregar ahorita.
                    //y = (from x in db.sistemascontables where x.idnitcliente == SelectedCliente.idnitcliente select x).SingleOrDefault();
                    if (AccionGuardar) { enc = new encargo(); }
                    else
                    {
                        enc = db.encargos.Find(currentEncargo.idencargo);
                    }
                }

                enc.idnitcliente = SelectedCliente.idnitcliente;
                enc.idta = SelectedTipoAuditoria.idta;
                //if (y != null)
                    //enc.idsc = y.idsc;
                enc.fechacreadoencargo = DateTime.Now.ToShortDateString();
                enc.tipoclienteencargo = SelectedTiposClienteRecurrente == "Recurrente" ? true : false;
                switch (SelectedEtapasEncargos)
                {
                    case "Inicial": enc.etapaencargo = "I"; break;
                    case "En proceso": enc.etapaencargo = "P"; break;
                    case "Revisado": enc.etapaencargo = "R"; break;
                    case "Cerrado": enc.etapaencargo = "C"; break;
                    default: enc.etapaencargo = "I"; break;
                }
                enc.costoejecucionencargo = TotalUs;
                enc.honorariosencargo = Math.Round(Decimal.Parse(Honorariosencargo, CultureInfo.InvariantCulture), 2); // Decimal.Parse(Honorariosencargo,);
                enc.fechainiperauditencargo = Fechainiperauditencargo.ToShortDateString();
                enc.fechafinperauditencargo = Fechafinperauditencargo.ToShortDateString();
                enc.estadoencargo = "A";
                //enc.etapaencargo=SelectedEtapasEncargos.
                //te2 = "En proceso"; te3="Revisado"; te4="Cerrado";
                Random r = new Random();
                if (AccionGuardar)
                {

                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            enc.idencargo = 100000;

                            //sis.idsc = 10000;
                            db.encargos.Add(enc);
                            //await cuenteUno();
                            db.SaveChanges();
                            //currentEncargo = enc;
                            //Vamos a guardar la pestaña de personal***********************
                            //Random r = new Random();
                            foreach (var z in ListadoPersonalAsignado)
                            {
                                #region +
                                asignacione a = new asignacione();
                                a.idasignacion = r.Next(1000, 100000);
                                a.idusuario = z.idusuario;
                                a.idencargo = enc.idencargo;
                                a.fechacreaasignacion = DateTime.Now.ToShortDateString();
                                a.horasplanasignacion = z.horasplanasignacion;
                                a.horasejecucionasignacion = z.horasejecucionasignacion;
                                a.preciohoraasignacion = z.preciohoraasignacion;
                                db.asignaciones.Add(a);
                                db.SaveChanges(); 
                                #endregion
                            }
                            

                            //Guardaremos ahora el Cronograma y el detalle del cronograma**********
                            if (ListadoDetalleCronograma!=null)
                            {
                                #region +
                                cronograma cr = new cronograma();
                                cr.idcronograma = r.Next(1000, 100000);
                                cr.idencargo = enc.idencargo;
                                cr.fechaprogramadacronograma = Fechainicialdc.ToShortDateString();
                                cr.fechafinalcronograma = Fechafinaldc.ToShortDateString();
                                cr.horastotalesplaneadascronogr = TotalHoras;
                                cr.fechacreadocronograma = DateTime.Now.ToShortDateString();
                                cr.estadocronograma = "A";
                                db.cronogramas.Add(cr);
                                db.SaveChanges();

                                foreach (var f in ListadoDetalleCronograma)
                                {
                                    #region +
                                    detallecronograma det = new detallecronograma();
                                    det.iddc = r.Next(10000, 100000);
                                    det.idpa = f.idpa;
                                    det.idvisita = f.idvisita;
                                    det.idcronograma = cr.idcronograma;
                                    det.actividaddc = f.actividaddc;
                                    det.fechaprogramadacronograma = f.fechainicialdc.ToShortDateString();
                                    det.fechafinaldc = f.fechafinaldc.ToShortDateString();
                                    det.horasplaneadasdc = f.horasplaneadasdc;
                                    det.fechacreadodc = DateTime.Now.ToShortDateString();
                                    det.estadodc = "A";
                                    db.detallecronogramas.Add(det);
                                    db.SaveChanges();
                                    #endregion
                                    /*Despues que ya se guardo el detalleCronograma, ahora guardo en la tabla designaciones, a los auditores asignados*/
                                    string[] dd = f.iDpersonalPorEtapa.Split(';');

                                    foreach (var au in dd)
                                    {
                                        #region +
                                        if (!string.IsNullOrEmpty(au))
                                        {
                                            string[] ds = au.Split(':');
                                            designacione desi = new designacione();
                                            desi.iddesignacion = r.Next(10000, 100000);
                                            desi.idusuario = int.Parse(ds[0]);
                                            desi.iddc = det.iddc;
                                            desi.fechacreadadesignacion = DateTime.Now.ToShortDateString();
                                            desi.horasplandesignacion = decimal.Parse(ds[1]);      //ojo modificar esto
                                            desi.horasejecuciondesignacion = 0; //ojo modificar esto
                                            desi.estadodesignacion = "A";
                                            db.designaciones.Add(desi);
                                            db.SaveChanges();
                                        }
                                        #endregion
                                    }
                                }
                                #endregion 
                            }
                            else
                            {
                                await AvisaYCerrateVosSolo("Atencion, no se guardo ningun cronograma, porque se encontro vacio el registro", "Ninguna actividad registrada para el cronograma", 1);
                            }

                            //Guardamos el sistema contable
                            this.MycmdGuardarCatalogo(enc.idencargo);

                            await AvisaYCerrateVosSolo("El registro se guardo con éxito.", "Finalizado.",1);
                            this.MyCmdVolver();
                            //MessageBox.Show("Mucha atencion. \nEs necesario que ingrese el catalogo de cuentas del cliente.", "Importar catalogo de cuentas", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            #endregion
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar en Sistema Contable.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. \n"+e.InnerException, "Imposible guardar el sistema contable", MessageBoxButton.OK, MessageBoxImage.Stop);
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
                            db.Entry(enc).State = EntityState.Modified; db.SaveChanges();
                            //CurrentSistemaContable = sis;
                            //MessageBox.Show("Los cambios se guardaron con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);

                            //foreach (var z in ListadoPersonalAsignado)
                            //{
   
                         //    #region +
                            //    asignacione a = new asignacione();
                            //    a = db.asignaciones.Find(a.idasignacion);
                            //    if (a!=null) //significa que lo hallo en la base
                            //    {
                            //        a.horasplanasignacion = z.horasplanasignacion;
                            //        a.preciohoraasignacion = z.preciohoraasignacion;
                            //        db.Entry(a).State = EntityState.Modified;
                            //    }
                            //    else // significa qeu NO lo hallo en la base.
                            //    {
                            //        a.idusuario = z.idusuario;
                            //        a.idencargo = enc.idencargo;
                            //        a.fechacreaasignacion = DateTime.Now.ToShortDateString();
                            //        a.horasplanasignacion = z.horasplanasignacion;
                            //        a.horasejecucionasignacion = z.horasejecucionasignacion;
                            //        a.preciohoraasignacion = z.preciohoraasignacion;
                            //        a.idasignacion = r.Next(1000, 100000);
                            //        db.asignaciones.Add(a);
                            //        db.SaveChanges();
                            //    } 
                            //    #endregion
                            //}

                            //Guardaremos ahora el Cronograma y el detalle del cronograma**********
                            cronograma cr = new cronograma();
                            cr = db.cronogramas.Where(z=>z.idencargo==currentEncargo.idencargo).SingleOrDefault();//currentCronograma;
                            //cr.idcronograma = r.Next(1000, 100000);
                            //cr.idencargo = enc.idencargo;
                            cr.fechaprogramadacronograma = Fechainicialdc.ToShortDateString();
                            cr.fechafinalcronograma = Fechafinaldc.ToShortDateString();
                            cr.horastotalesplaneadascronogr = TotalHoras;
                            //cr.fechacreadocronograma = DateTime.Now.ToShortDateString();
                            //cr.estadocronograma = "A";
                            db.Entry(cr).State=EntityState.Modified;
                            db.SaveChanges();
                            foreach (var f in ListadoDetalleCronograma)
                            {
                                #region +
                                detallecronograma det = new detallecronograma();
                                //det.iddc = r.Next(10000, 100000);
                                det = db.detallecronogramas.Find(f.iddc);
                                if (det != null && f.iddc>0)
                                {
                                    #region +
                                    //Nota: ya es posible editar registros del listado.
                                    det.idpa = f.idpa;
                                    det.idvisita = f.idvisita;
                                    det.idcronograma = cr.idcronograma;
                                    det.actividaddc = f.actividaddc;
                                    det.fechaprogramadacronograma = f.fechainicialdc.ToShortDateString();
                                    det.fechafinaldc = f.fechafinaldc.ToShortDateString();
                                    det.horasplaneadasdc = f.horasplaneadasdc;
                                    det.fechacreadodc = DateTime.Now.ToShortDateString();

                                    db.Entry(det).State = EntityState.Modified;
                                    db.SaveChanges();

                                    //Aqui tengo que eliminar o modificar de la base las designaciones y agregar las nuevas.

                                    string[] dd = f.iDpersonalPorEtapa.Split(';');

                                    foreach (var au in dd)
                                    {
                                        #region +
                                        if (!string.IsNullOrEmpty(au))
                                        {
                                            string[] ds = au.Split(':');
                                            int ak = int.Parse(ds[0]);

                                            designacione buscarDesignacion = (from d in db.designaciones where d.iddc == det.iddc && d.idusuario == ak select d).SingleOrDefault();
                                            if (buscarDesignacion != null)
                                            {
                                                designacione desi = new designacione();
                                                desi = buscarDesignacion;
                                                //desi.iddesignacion = r.Next(10000, 100000);
                                                //desi.idusuario = int.Parse(ds[0]);
                                                //desi.iddc = det.iddc;
                                                //desi.fechacreadadesignacion = DateTime.Now.ToShortDateString();
                                                desi.horasplandesignacion = decimal.Parse(ds[1]);      //ojo modificar esto
                                                //desi.horasejecuciondesignacion = 0; //ojo modificar esto
                                                //desi.estadodesignacion = "A";
                                                db.Entry(desi).State = EntityState.Modified;
                                                db.SaveChanges();
                                            }
                                            else //no hay designacion registrada, asi que la ingreso.
                                            {
                                                designacione desi = new designacione();
                                                desi.iddesignacion = r.Next(10000, 100000);
                                                desi.idusuario = int.Parse(ds[0]);
                                                desi.iddc = det.iddc;
                                                desi.fechacreadadesignacion = DateTime.Now.ToShortDateString();
                                                desi.horasplandesignacion = decimal.Parse(ds[1]);      //ojo modificar esto
                                                desi.horasejecuciondesignacion = 0; //ojo modificar esto
                                                desi.estadodesignacion = "A";
                                                db.designaciones.Add(desi);
                                                db.SaveChanges();
                                            }

                                        }
                                        #endregion
                                    } 
                                    #endregion
                                }
                                else // si no esta en la base, es porque es un registro nuevo que se agrego en la edicion del encargo
                                {
                                    det = new detallecronograma();
                                    det.iddc = r.Next(10000, 100000);
                                    det.idpa = f.idpa;
                                    det.idvisita = f.idvisita;
                                    det.idcronograma = cr.idcronograma;
                                    det.actividaddc = f.actividaddc;
                                    det.fechaprogramadacronograma = f.fechainicialdc.ToShortDateString();
                                    det.fechafinaldc = f.fechafinaldc.ToShortDateString();
                                    det.horasplaneadasdc = f.horasplaneadasdc;
                                    det.fechacreadodc = DateTime.Now.ToShortDateString();
                                    det.estadodc = "A";
                                    db.detallecronogramas.Add(det);
                                    db.SaveChanges();
                               
                                    /*Despues que ya se guardo el detalleCronograma, ahora guardo en la tabla designaciones, a los auditores asignados*/
                                    string[] dd = f.iDpersonalPorEtapa.Split(';');

                                    foreach (var au in dd)
                                    {
                                        #region +
                                        if (!string.IsNullOrEmpty(au))
                                        {
                                            string[] ds = au.Split(':');
                                            designacione desi = new designacione();
                                            desi.iddesignacion = r.Next(10000, 100000);
                                            desi.idusuario = int.Parse(ds[0]);
                                            desi.iddc = det.iddc;
                                            desi.fechacreadadesignacion = DateTime.Now.ToShortDateString();
                                            desi.horasplandesignacion = decimal.Parse(ds[1]);      //ojo modificar esto
                                            desi.horasejecuciondesignacion = 0; //ojo modificar esto
                                            desi.estadodesignacion = "A";
                                            db.designaciones.Add(desi);
                                            db.SaveChanges();
                                        }
                                        #endregion
                                    }
                                }
                                #endregion
                            }
                            this.MycmdGuardarCatalogo(currentEncargo.idencargo);
                            await AvisaYCerrateVosSolo("El proceso de guardado ha finalizado sin errores","Finalizado.",1);
                            this.MyCmdVolver();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Ocurrio un error al guardar los cambios en encargos.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico.", "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                            //this.cmdCancelar();
                        }
                        #endregion

                    }
                    //this.FinalizarAction();
                    #endregion
                }

                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("Faltan datos... No se pudo almacenar nada. \n Verifique que los campos obligatorios esten completos", "Faltante de informacion", 1);
            }
            Mouse.OverrideCursor = null;
        }

        private bool ValidacionManualCatOk()
        {
            if (SelectedCliente != null && SelectedTipoAuditoria != null && SelectedTiposClienteRecurrente != null && SelectedEtapasEncargos != null)
                return true;
            return false;
        }

        private async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
        {
            await Task.Delay(segundos);
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }
    }
}