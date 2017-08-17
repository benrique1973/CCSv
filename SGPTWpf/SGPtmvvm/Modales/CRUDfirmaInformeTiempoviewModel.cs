using CapaDatos;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTWpf.Model.Modelo.Encargos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WindowFactoryNamespace.Helpers;

namespace SGPTmvvm.Modales
{

    public class CRUDfirmaInformeTiempoviewModel : INotifyPropertyChanged
    {
        DialogCoordinator dlg;
        public SGPTEntidades db = new SGPTEntidades();

        public ObservableCollection<detalletiempoModelo> DetalleTiempoListado {get; set;} // = new List<detalletiempo>();
        public List<detalletiempoModelo> ItemEliminadosDelListado { get; set; }
        public List<detalletiempoModelo> DTiempoListado = new List<detalletiempoModelo>();
        public List<detalletiempo> ListaDetalleTiempo { get; set; }
        public List<cliente> ClientesListado { get; set; }
        public List<EncargoModelo> EncargosListado { get; set; }
        public List<persona> ListadoPersonas { get; set; }
        public List<usuariospersonas> ListadoUsuarios { get; set; }//= new List<usuariospersonas>();
        public RelayCommand DoubleClickCommand { get; set; }

    
        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
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

        #endregion
        #endregion
        public CRUDfirmaInformeTiempoviewModel(FirmaTiemposMensajeModal msg)
        {
            dlg = new DialogCoordinator();
            Fechainicialdt = DateTime.Today;
            Fechafinaldt = DateTime.Today;
            //this.inicializadoresDeObjetosBasico();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            _canExecute = true;
            _HabilitartxtTarea=true;
            this.EscuchandoALaVista(msg);
        }

        private void inicializadoresDeObjetosBasico()
        {
            
        }
        #region v

        //valorBarrita
        #endregion
        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(FirmaTiemposMensajeModal Mensajito)
        {
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    EditarInformeTiempo(Mensajito); break;
                case TipoComando.Consultar:
                    ConsultarInformeTiempo(Mensajito); 
                    break;
                case TipoComando.Nuevo:
                    NuevoInformeTiempo(); break;
                default: break;
            }
            currentUsuario = Mensajito.UsuarioValidado;
            //DoubleClickCommand = new RelayCommand(DatagridTuvoCambio);
        }

        //private void DatagridTuvoCambio(object obj)
        //{
        //    MessageBox.Show("Cambios en datagrid"); 
        //}

        #region Campos
        private int _iddt;
        private string _idnitcliente;
        private int _idia;
        private int _idchh;
        private int _idencargo;
        private int _idindice;
        private string _actividaddt;
        private DateTime _fechainicialdt;
        private DateTime _fechafinaldt;
        private DateTime _fechaaprobacionia;
        private decimal _tiempohorasdt;
        private string _tiempoHduracionreunion;
        private string _tiempoMduracionreunion;
        private decimal _tiempodias;
        private string _comentariosdt;
        private string _estadodt;
        private bool _HabilitartxtTarea;
        public int Iddt { get { return _iddt; } set { _iddt = value; RaisePropertyChanged("Iddt "); } }
        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public int Idia { get { return _idia; } set { _idia = value; RaisePropertyChanged("Idia"); } }
        public int Idchh { get { return _idchh; } set { _idchh = value; RaisePropertyChanged("Idchh"); } }
        public int Idencargo { get { return _idencargo; } set { _idencargo = value; RaisePropertyChanged("Idencargo"); } }
        public int Idindice { get { return _idindice; } set { _idindice = value; RaisePropertyChanged("Idindice"); } }
        public string Actividaddt { get { return _actividaddt; } set { _actividaddt = value; RaisePropertyChanged("Actividaddt"); } }
        public DateTime Fechainicialdt { get { return _fechainicialdt; } set { _fechainicialdt = value; RaisePropertyChanged("Fechainicialdt"); } }
        public DateTime Fechafinaldt { get { return _fechafinaldt; } set { _fechafinaldt = value; RaisePropertyChanged("Fechafinaldt"); } }
        public DateTime Fechaaprobacionia { get { return _fechaaprobacionia; } set { _fechaaprobacionia = value; RaisePropertyChanged("Fechaaprobacionia"); } }
        public string TiempoHduracionreunion { get { return _tiempoHduracionreunion; } set { _tiempoHduracionreunion = value; RaisePropertyChanged("TiempoHduracionreunion"); } }
        public string TiempoMduracionreunion { get { return _tiempoMduracionreunion; } set { _tiempoMduracionreunion = value; RaisePropertyChanged("TiempoMduracionreunion"); } }
        public decimal Tiempohorasdt { get { return _tiempohorasdt; } set { _tiempohorasdt = value; RaisePropertyChanged("Tiempohorasdt"); } }
        public decimal Tiempodias { get { return _tiempodias; } set { _tiempodias = value; RaisePropertyChanged("Tiempodias"); } }
        public string Comentariosdt { get { return _comentariosdt; } set { _comentariosdt = value; RaisePropertyChanged("Comentariosdt"); } }
        public string Estadodt { get { return _estadodt; } set { _estadodt = value; RaisePropertyChanged("Estadodt"); } }

        public bool HabilitartxtTarea { get { return _HabilitartxtTarea; } set { _HabilitartxtTarea = value; RaisePropertyChanged("HabilitartxtTarea"); } }

        #endregion

        #region Bindiados

        private string _txtBandera; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
        }
        private usuariospersonas _selectedUsuarioInforme;
        public usuariospersonas SelectedUsuarioInforme
        {
            get { return _selectedUsuarioInforme; }
            set
            {
                _selectedUsuarioInforme = value;
                RaisePropertyChanged("SelectedUsuarioInforme");
            }
        }

        private cliente _selectedClienteInforme;
        public cliente SelectedClienteInforme
        {
            get { return _selectedClienteInforme; }
            set
            {
                _selectedClienteInforme = value;
                RaisePropertyChanged("SelectedClienteInforme");
                if (_selectedClienteInforme != null)
                {
                    this.BuscarLosEncargosDelCliente();
                }
            }
        }

        private void BuscarLosEncargosDelCliente()
        {
            using (db=new SGPTEntidades())
            {
                //EncargosListado = new List<encargo>();
                //EncargosListado = (from e in db.encargos where e.estadoencargo == "A" && e.idnitcliente == SelectedClienteInforme.idnitcliente select e).ToList();
                EncargosListado = new List<EncargoModelo>();
                EncargosListado = SGPTWpf.Model.Modelo.Encargos.EncargoModelo.GetAllByIdCliente(SelectedClienteInforme.idnitcliente);
                RaisePropertyChanged("EncargosListado");
            }
        }

        private EncargoModelo _selectedEncargoInforme;
        public EncargoModelo SelectedEncargoInforme
        {
            get { return _selectedEncargoInforme; }
            set
            {
                _selectedEncargoInforme = value;
                RaisePropertyChanged("SelectedEncargoInforme");
            }
        }

        private detalletiempoModelo _selectedDetalleInformex;
        public detalletiempoModelo SelectedDetalleInformex
        {
            get { return _selectedDetalleInformex; }
            set
            {
                _selectedDetalleInformex = value;
                RaisePropertyChanged("SelectedDetalleInformex");
            }
        }
        private decimal _totalHoras;
        public decimal TotalHoras
        {
            get { return _totalHoras; }
            set { _totalHoras = value;
            RaisePropertyChanged("TotalHoras");
            }
        }

        private DateTime _fechainicio;
        public DateTime FechainicioTotal
        {
            get { return _fechainicio; }
            set { _fechainicio = value; RaisePropertyChanged("FechainicioTotal"); }
        }

        private DateTime _fechafinal;
        public DateTime FechafinalTotal
        {
            get { return _fechafinal; }
            set { _fechafinal = value; RaisePropertyChanged("FechafinalTotal"); }
        }
        //SelectedDetalleInformex
        private string _observaciones;
        public string ObservacionesX
        {
            get { return _observaciones; }
            set { _observaciones = value; RaisePropertyChanged("ObservacionesX"); this.activarbotonguardar(); }
        }

        private void activarbotonguardar()
        {
            if (AccionConsultar == false && AccionGuardar==false) { txtBandera = "1"; RaisePropertyChanged("txtBandera"); }
        }

        #endregion

        #region Activadores
        private bool _cmdInsertarHabilitado;
        public bool cmdInsertarHabilitado
        {
            get { return _cmdInsertarHabilitado; }
            set { _cmdInsertarHabilitado = value; RaisePropertyChanged("cmdInsertarHabilitado"); }
        }

        private bool _cmdEliminarHabilitado;
        public bool cmdEliminarHabilitado
        {
            get { return _cmdEliminarHabilitado; }
            set { _cmdEliminarHabilitado = value; RaisePropertyChanged("cmdEliminarHabilitado"); }
        }

        private bool _cmdModificarHabilitado;
        public bool cmdModificarHabilitado
        {
            get { return _cmdModificarHabilitado; }
            set { _cmdModificarHabilitado = value; RaisePropertyChanged("cmdModificarHabilitado"); }
        }

        private Visibility _cmdAceptarVisible;
        public Visibility cmdAceptarVisible
        {
            get { return _cmdAceptarVisible; }
            set { _cmdAceptarVisible = value; RaisePropertyChanged("cmdAceptarVisible"); }
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

        private ICommand _cmdInsertar_Click;
        public ICommand cmdInsertar_Click
        {
            get
            {
                return _cmdInsertar_Click ?? (_cmdInsertar_Click = new CommandHandler(() => cmdInsertar(), _canExecute));
            }
        }

        private ICommand _cmdEliminar_Click;
        public ICommand cmdEliminar_Click
        {
            get
            {
                return _cmdEliminar_Click ?? (_cmdEliminar_Click = new CommandHandler(() => cmdEliminar(), _canExecute));
            }
        }
        private ICommand _cmdModificar_Click;
        public ICommand cmdModificar_Click
        {
            get
            {
                return _cmdModificar_Click ?? (_cmdModificar_Click = new CommandHandler(() => cmdModificar(), _canExecute));
            }
        }

        private ICommand _cmdAceptar_Click;
        public ICommand cmdAceptar_Click
        {
            get
            {
                return _cmdAceptar_Click ?? (_cmdAceptar_Click= new CommandHandler(()=> cmdAceptar(), _canExecute));
            }
        }


        private async void cmdInsertar() //Inserta una fila al grid.
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-SV");
            //TiempoHduracionreunion>0 || TiempoMduracionreunion>0 
            decimal tiempohdur=0;
            decimal tiempomdur=0;
            if(!string.IsNullOrEmpty(TiempoHduracionreunion))
                tiempohdur=Convert.ToDecimal(TiempoHduracionreunion);
            if(!string.IsNullOrEmpty(TiempoMduracionreunion))
                tiempomdur=Math.Round(((Convert.ToDecimal(TiempoMduracionreunion))/60),3);

            Tiempohorasdt = tiempohdur + tiempomdur;

            if (Fechainicialdt<=DateTime.Now && Fechafinaldt<=DateTime.Now && Fechainicialdt<= Fechafinaldt && !String.IsNullOrEmpty(Actividaddt) && Tiempohorasdt>0 )
            {
                //if(Fechainicialdt==Fechafinaldt)

                if (verificarQueHorasCorresponden(Fechainicialdt,Fechafinaldt,Tiempohorasdt))
                {
                    #region -
                    detalletiempoModelo Lineax = new detalletiempoModelo();
                    Lineax.fechainicialdt = Fechainicialdt;// Fechainicialdt.ToShortDateString();
                    Lineax.fechafinaldt = Fechafinaldt;// Fechafinaldt.ToShortDateString();
                    Lineax.actividaddt = Actividaddt;
                    if (SelectedClienteInforme != null)
                    {
                        Lineax.idnitcliente = SelectedClienteInforme.idnitcliente;
                        Lineax.descripcioncliente = SelectedClienteInforme.razonsocialcliente;
                    }
                    else { Lineax.descripcioncliente = "N/D"; }
                    if (SelectedEncargoInforme != null && SelectedEncargoInforme.idencargo>0)
                    {
                        Lineax.idencargo = SelectedEncargoInforme.idencargo;
                        Lineax.descripcionencargo = SelectedEncargoInforme.idencargo+" Nit: "+ SelectedEncargoInforme.idnitcliente;
                    }
                    else { Lineax.descripcionencargo = "N/D"; }
                    Lineax.tiempohorasdt = Tiempohorasdt;
                    Lineax.estadodt = "A";
                    //int numeritox = DetalleTiempoListado.Count() + 1;

                    //Lineax.iddt = numeritox;
                    DetalleTiempoListado.Add(Lineax);
                    SelectedClienteInforme = null;
                    SelectedEncargoInforme = null;
                    txtBandera = "1";
                    RaisePropertyChanged("txtBandera");
                    this.consolidados();
                    #endregion 
                }
                else { await AvisaYCerrateVosSolo("Las horas reportadas no corresponden a 8 horas por dia laborado.","Incongruencia de horas",1); }
            } 
               
            else
            {
                await AvisaYCerrateVosSolo("Falta informacion para agregar nueva fila.\n1. Verifique que la fecha inicial y final no sea mayor que el dia actual.\n 2. Verifique que la fecha inicial no sea mayor que la fecha final.\n 3. Verifique que la actividad no este vacia. \n 4. Verifique que el tiempo sea mayor que cero.", "El tiempo declarado es erroneo", 2);
            }
        }

        private bool verificarQueHorasCorresponden(DateTime Fechainicial, DateTime Fechafinal, decimal Tiempohoras)
        {
            if (Fechainicial == Fechafinal && Tiempohoras <= 8)
                return true;
            else
            {
                int resta = (Fechafinal - Fechainicial).Days; //Ojo (mañana - hoy = 1) pero hay dos dias
                //var resta2 = (Fechafinal - Fechainicial).Days;
                int calc = (resta+1) * 8; //le sumo uno pq se cuenta tambien el dia de inicio (hoy + mañana = 2) 
                if (Tiempohoras <= calc && Tiempohoras>0)
                    return true;
            }
            
            return false;
        } //comprueba que las horas reportadas sean 8 horas maximo por dia

        private void consolidados() //Realiza el calculo de horas y fecha inicial y final. tambien da un orden numerico a las filas
        {
            if (DetalleTiempoListado.Count()>0)
            {
                decimal sumita = 0;
                int num = 0;
                foreach (var a in DetalleTiempoListado)
                {
                    DetalleTiempoListado[num].iddt2 = num + 1;
                    RaisePropertyChanged("DetalleTiempoListado");
                    num++;
                    sumita = sumita + a.tiempohorasdt;
                }

                TotalHoras = (decimal)sumita;
                DTiempoListado = DetalleTiempoListado.ToList();
                DetalleTiempoListado = null;
                DetalleTiempoListado = new ObservableCollection<detalletiempoModelo>();
                foreach (detalletiempoModelo a in DTiempoListado)
                {
                    DetalleTiempoListado.Add(a);
                }

                DTiempoListado.Sort((a, b) => a.fechainicialdt.CompareTo(b.fechainicialdt));
                FechainicioTotal = DTiempoListado[0].fechainicialdt;
                DTiempoListado.Sort((a, b) => b.fechafinaldt.CompareTo(a.fechafinaldt));
                FechafinalTotal = DTiempoListado[0].fechafinaldt;
                RaisePropertyChanged("DetalleTiempoListado");
                RaisePropertyChanged();

                Fechainicialdt = DateTime.Now;
                Fechafinaldt = DateTime.Now;
                Actividaddt = "";
                //SelectedClienteInforme = ClientesListado[0];
                //SelectedEncargoInforme = EncargosListado[0];
                Tiempohorasdt = 0;  
            }
        } //saca los totales de horas y la fecha inicial minima y final maxima
        private async void cmdEliminar() //Eliminar una fila
        {
            if (SelectedDetalleInformex != null)
            {
                ItemEliminadosDelListado.Add(SelectedDetalleInformex); //esto servira para descargarlo tambien de la base de datos
                DetalleTiempoListado.Remove(SelectedDetalleInformex);
                RaisePropertyChanged("DetalleTiempoListado");
                if(DetalleTiempoListado.Count()==0)
                {
                    txtBandera = "0";
                    RaisePropertyChanged("txtBandera");
                }
                this.consolidados();
            }
            else { await AvisaYCerrateVosSolo("Seleccione la fila que desea eliminar", "Seleccione una fila",1); ; }
        }
        private async void cmdModificar() //Modifica una fila
        {

            //MessageBox.Show("Modificar fila");
            if (SelectedDetalleInformex != null)
            {
                Fechainicialdt = SelectedDetalleInformex.fechainicialdt;
                Fechafinaldt = SelectedDetalleInformex.fechafinaldt;
                Actividaddt = SelectedDetalleInformex.actividaddt;
                string asd = SelectedDetalleInformex.idnitcliente;
                try
                {
                    if (SelectedDetalleInformex.idnitcliente.Length>15)
                    {
                        SelectedClienteInforme = ClientesListado.Find(y => y.idnitcliente.Equals(SelectedDetalleInformex.idnitcliente)); //(from c in ClientesListado where c.idnitcliente==asd select c).Single();//ClientesListado.Find(asd);
                        
                    }
                    if (SelectedDetalleInformex.idencargo>0)
                    {
                        SelectedEncargoInforme = EncargosListado.Find(x => x.idencargo.Equals(SelectedDetalleInformex.idencargo)); 
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error desconocido. "+e.InnerException);
                }
                Tiempohorasdt = SelectedDetalleInformex.tiempohorasdt;
                RaisePropertyChanged();
            
                cmdInsertarHabilitado=false;
                cmdEliminarHabilitado=false;
                cmdModificarHabilitado=false;
                cmdAceptarVisible= Visibility.Visible;
            }
            else
            {
                await AvisaYCerrateVosSolo("Seleccione la fila que desea modificar", "Seleccione una fila", 1);
            }
        
        }

        private void cmdAceptar() //Acepta los cambios en las filas
        {
            cmdInsertarHabilitado = true;
            cmdEliminarHabilitado = true;
            cmdModificarHabilitado = true;
            cmdAceptarVisible = Visibility.Hidden;


            detalletiempoModelo Lineax = DetalleTiempoListado.FirstOrDefault(z=> z.iddt==SelectedDetalleInformex.iddt); // (from dd in DetalleTiempoListado where dd.iddt == SelectedDetalleInformex.iddt select dd).Single();//new detalletiempoModelo();
            Lineax.fechainicialdt = Fechainicialdt;// Fechainicialdt.ToShortDateString();
            Lineax.fechafinaldt = Fechafinaldt;// Fechafinaldt.ToShortDateString();
            Lineax.actividaddt = Actividaddt;
            if (SelectedClienteInforme != null)
            {
                Lineax.idnitcliente = SelectedClienteInforme.idnitcliente;
            }
            if (SelectedEncargoInforme != null)
            {
                Lineax.idencargo = SelectedEncargoInforme.idencargo;
            }
            Lineax.tiempohorasdt = Tiempohorasdt;
            //DetalleTiempoListado
            RaisePropertyChanged("DetalleTiempoListado");
            RaisePropertyChanged("actividaddt");
            this.consolidados();
            //int numeritox = DetalleTiempoListado.Count() + 1;

            //Lineax.iddt = numeritox;
            //DetalleTiempoListado.Add(Lineax);


            //if (EnviarEmail())
            //    MessageBox.Show("revisa tu correo");
            //else
            //{
            //    MessageBox.Show("fallo el correo");
            //}
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


        public void inicializarListados()
        {
            ItemEliminadosDelListado = new List<detalletiempoModelo>();
            using (db = new SGPTEntidades())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                Fechainicialdt = DateTime.Now;
                Fechafinaldt = DateTime.Now;
                try
                {
                    ClientesListado = (from c in db.clientes where c.estadocliente == "A" orderby c.razonsocialcliente select c).ToList();
                    //EncargosListado = new List<EncargoModelo>();
                    EncargosListado = SGPTWpf.Model.Modelo.Encargos.EncargoModelo.GetAll();//.GetAllByIdCliente(SelectedClienteInforme.idnitcliente);
                    //RaisePropertyChanged("EncargosListado");
                    //EncargosListado = (from e in db.encargos where e.estadoencargo == "A" orderby e.fechacreadoencargo select e).ToList(); //Estos se van a llenar segun los encargos del cliente


                    DetalleTiempoListado = new ObservableCollection<detalletiempoModelo>();
                    ListadoUsuarios = new List<usuariospersonas>();

                    cliente seleccionecliente = new cliente();
                    seleccionecliente.idnitcliente = "-1";
                    seleccionecliente.razonsocialcliente = "--Seleccione un cliente--";
                    ClientesListado.Insert(0, seleccionecliente);

                    EncargoModelo seleccioneencargo = new EncargoModelo();
                    seleccioneencargo.idencargo = -1;
                    seleccioneencargo.idnitcliente = "--Seleccion un encargo--";
                    EncargosListado.Insert(0, seleccioneencargo);

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
                                           nombreCompleto = p.nombrespersona + " " + p.apellidospersona,
                                           nitpersona = p.nitpersona,
                                           estadopersona = p.estadopersona,
                                           #endregion
                                       }).ToList();
                    
                    usuariospersonas seleccioneunusuario = new usuariospersonas();
                    seleccioneunusuario.idduipersona = "N";
                    seleccioneunusuario.nombreCompleto = "--Seleccione un usuario--";
                    ListadoUsuarios.Insert(0, seleccioneunusuario);

                    //detalletiempo Lineax = new detalletiempo();
                    //Lineax.fechainicialdt = "hola camaleon";
                    //Lineax.fechafinaldt = "Salu camaleon";
                    //DetalleTiempoListado.Add(Lineax);
                    cmdInsertarHabilitado = true;
                    cmdEliminarHabilitado = true;
                    cmdModificarHabilitado = true;
                    cmdAceptarVisible = Visibility.Hidden;
                    RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error desconocido "+e.InnerException);
                }
            }

            RaisePropertyChanged("");
        }
        private void NuevoInformeTiempo()
        {
            //this.Habilitadores(true); //le solicito que active todos los campos
            AccionGuardar = true;
            AccionConsultar = false;

            this.inicializarListados();
            Idia = 0;//InformeRecibido.idia;
            //Fechacvpausuario = DateTime.Now;
            Message = "Nuevo informe de tiempo";
        }
        private void EditarInformeTiempo(FirmaTiemposMensajeModal Mensajito)
        {
            AccionGuardar = false;
            AccionConsultar = false;
            this.inicializarListados();
            //MessageBox.Show("Presiono editar");
            InformeActividadesModelo InformeRecibido = Mensajito.InformeAmodificar;
            Message = "Editar informe de tiempo";
            ObservacionesX = InformeRecibido.observacionesia;
            Idia = InformeRecibido.idia;
            using (db = new SGPTEntidades())
            {
                var DetalleTiempoListadoX = (from d in db.detalletiempoes where d.idia == InformeRecibido.idia && d.estadodt == "A" select d).ToList();
                foreach (var a in DetalleTiempoListadoX)
                {
                    detalletiempoModelo Lineax = new detalletiempoModelo();
                    Lineax.iddt = a.iddt;
                    Lineax.fechainicialdt = DateTime.Parse(a.fechainicialdt); // Fechainicialdt;// Fechainicialdt.ToShortDateString();
                    Lineax.fechafinaldt = DateTime.Parse(a.fechafinaldt);  //Fechafinaldt;// Fechafinaldt.ToShortDateString();
                    Lineax.actividaddt = a.actividaddt;
                    if (!string.IsNullOrEmpty(a.idnitcliente))
                    {
                        var xs=ClientesListado.Find(x=>x.idnitcliente==a.idnitcliente);
                        Lineax.idnitcliente = a.idnitcliente;
                        Lineax.descripcioncliente = xs.razonsocialcliente;
                    }
                    if (a.idencargo > 0)
                    {
                        var ls = EncargosListado.Find(y => y.idencargo == a.idencargo);
                        Lineax.idencargo = (int)a.idencargo;
                        Lineax.descripcionencargo = ls.descripcionTipoAuditoria+ " - "+ls.fechainiperauditencargo+" al " +ls.fechafinperauditencargo;// a.idencargo + " Nit: " + ls.idnitcliente;
                    }
                    Lineax.tiempohorasdt = a.tiempohorasdt;
                    Lineax.estadodt = a.estadodt;
                    //int numeritox = DetalleTiempoListado.Count() + 1;


                    //Lineax.iddt = numeritox;
                    DetalleTiempoListado.Add(Lineax);
                    //txtBandera = "1";
                    //RaisePropertyChanged("txtBandera");
                }
                RaisePropertyChanged("DetalleTiempoListado");
                this.consolidados();
            }
        }

        private void ConsultarInformeTiempo(FirmaTiemposMensajeModal Mensajito)
        {
            this.inicializarListados();
            txtBandera = "0";
            cmdInsertarHabilitado = false;
            //RaisePropertyChanged("cmdInsertarHabilitado");
            cmdEliminarHabilitado = false;
            //RaisePropertyChanged("cmdEliminarHabilitado");
            cmdModificarHabilitado = false;
            RaisePropertyChanged();
            AccionGuardar = false;
            AccionConsultar = true;

            InformeActividadesModelo InformeRecibido = Mensajito.InformeAmodificar;
            Message = "Consultar informe de tiempo";
            ObservacionesX = InformeRecibido.observacionesia;
            Idia = InformeRecibido.idia;
            using (db = new SGPTEntidades())
            {
                var DetalleTiempoListadoX = (from d in db.detalletiempoes where d.idia == InformeRecibido.idia && d.estadodt == "A" select d).ToList();
                foreach (var a in DetalleTiempoListadoX)
                {
                    detalletiempoModelo Lineax = new detalletiempoModelo();
                    Lineax.iddt = a.iddt;
                    Lineax.fechainicialdt = DateTime.Parse(a.fechainicialdt); // Fechainicialdt;// Fechainicialdt.ToShortDateString();
                    Lineax.fechafinaldt = DateTime.Parse(a.fechafinaldt);  //Fechafinaldt;// Fechafinaldt.ToShortDateString();
                    Lineax.actividaddt = a.actividaddt;
                    if (!string.IsNullOrEmpty(a.idnitcliente))
                    {
                        var xs = ClientesListado.Find(x => x.idnitcliente == a.idnitcliente);
                        Lineax.idnitcliente = a.idnitcliente;
                        Lineax.descripcioncliente = xs.razonsocialcliente;
                    }
                    if (a.idencargo > 0)
                    {
                        var ls = EncargosListado.Find(y => y.idencargo == a.idencargo);
                        Lineax.idencargo = (int)a.idencargo;
                        Lineax.descripcionencargo = ls.descripcionTipoAuditoria + " - " + ls.fechainiperauditencargo + " al " + ls.fechafinperauditencargo;// a.idencargo + " Nit: " + ls.idnitcliente;
                        //Lineax.descripcionencargo = a.idencargo + " Nit: " + ls.idnitcliente;
                    }
                    Lineax.tiempohorasdt = a.tiempohorasdt;
                    Lineax.estadodt = a.estadodt;
                    DetalleTiempoListado.Add(Lineax);
                }
                RaisePropertyChanged("DetalleTiempoListado");
                this.consolidados();
            }
        }

        private async void cmdCancelar()
        {
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada",2);
            this.FinalizarAction();
        }

        private async void activarBarra()
        {
            //DejarseVer = Visibility.Visible;
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
        {//***********************************************************************************************************

            //OJO 21/11/2016 El idusuario va a venir en un mensajito, desde que el usuario se loguea. ese sera el creador del informe.
            informeactividade infactiv = new informeactividade();

            //if(SelectedUsuarioInforme!=null && SelectedUsuarioInforme.idduipersona.Length>9)
            //infactiv.idusuario=SelectedUsuarioInforme.idusuario;
            if (currentUsuario != null)
                infactiv.idusuario = currentUsuario.idusuario;
            infactiv.fechainicialia =FechainicioTotal.ToShortDateString(); 
            infactiv.fechafinalia = FechafinalTotal.ToShortDateString();
            infactiv.totalhorasia = TotalHoras;
            infactiv.observacionesia = ObservacionesX;
            infactiv.aprobacionia = "P";
            infactiv.estadoia = "A";

            ListaDetalleTiempo = new List<detalletiempo>();
            
            foreach(var a in DetalleTiempoListado)
            {
                #region _
                detalletiempo dt = new detalletiempo();
                dt.iddt = a.iddt;
                //dt.idia = 1;
                dt.idchh = a.idchh;
                dt.idencargo = a.idencargo;
                dt.idindice = a.idindice;
                dt.idnitcliente = a.idnitcliente;
                dt.actividaddt = a.actividaddt;
                dt.fechainicialdt = a.fechainicialdt.ToShortDateString();
                dt.fechafinaldt = a.fechafinaldt.ToShortDateString();
                dt.tiempohorasdt = a.tiempohorasdt;
                dt.comentariosdt = a.comentariosdt;
                dt.estadodt = a.estadodt;
                ListaDetalleTiempo.Add(dt); 
                #endregion
            }
            if (AccionGuardar)
            {
                #region v
                infactiv.idia = 100000;
                if (ListaDetalleTiempo != null)
                {                
                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            db.informeactividades.Add(infactiv);
                            db.SaveChanges();

                            foreach (var a in ListaDetalleTiempo)
                            {
                                #region _
                                detalletiempo dett = new detalletiempo();
                                dett.idia = infactiv.idia;
                                dett.iddt = a.iddt;
                                if (a.idencargo > 0)
                                    dett.idencargo = a.idencargo;
                                dett.idnitcliente = a.idnitcliente;
                                dett.actividaddt = a.actividaddt;
                                dett.fechainicialdt = a.fechainicialdt;
                                dett.fechafinaldt = a.fechafinaldt;
                                dett.tiempohorasdt = a.tiempohorasdt;
                                dett.estadodt = a.estadodt;
                                db.detalletiempoes.Add(dett);
                                db.SaveChanges();
                                #endregion
                            }
                            await AvisaYCerrateVosSolo("El registro se guardo con éxito.", "Finalizado.",1);
                            #endregion
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Ocurrio un error al guardar el nuevo informe de tiempo.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. "+e.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                        } 
                        #endregion
                    }
                }
                else
                {
                   await AvisaYCerrateVosSolo("Ocurrio un error al guardar el nuevo informe de tiempo.\nEl informe no contiene un detalle de actividades.\nConsulte el manual para conocer como crear informes. ", "Imposible guardar el informe de tiempo",2);
                }

                FinalizarAction();

                #endregion
            }
            else if (!AccionConsultar) //Entonces es Editar
            {
                //Nota, aqui ocurre un fenomeno. Cuando el reporte se le ha quitado una fila, debe de quitarse de la base de datos tambien.
                #region v

                using (db = new SGPTEntidades())
                {
                    try
                    {
                        foreach (var a in ListaDetalleTiempo)
                        {
                            #region _
                            if (a.iddt > 0)
                            {
                                #region _
                                detalletiempo dettl = new detalletiempo();
                                dettl = db.detalletiempoes.Find(a.iddt);
                                if (a.idencargo > 0)
                                    dettl.idencargo = a.idencargo;
                                dettl.idnitcliente = a.idnitcliente;
                                dettl.actividaddt = a.actividaddt;
                                dettl.fechainicialdt = a.fechainicialdt;
                                dettl.fechafinaldt = a.fechafinaldt;
                                dettl.tiempohorasdt = a.tiempohorasdt;
                                dettl.estadodt = a.estadodt;
                                db.Entry(dettl).State = EntityState.Modified; db.SaveChanges();
                                #endregion
                            }
                            else //quiere decir que no existe en la base y hay que insertarlo
                            {
                                #region _
                                detalletiempo dett = new detalletiempo();
                                if (a.idencargo > 0)
                                    dett.idencargo = a.idencargo;
                                dett.idnitcliente = a.idnitcliente;
                                dett.actividaddt = a.actividaddt;
                                dett.fechainicialdt = a.fechainicialdt;
                                dett.fechafinaldt = a.fechafinaldt;
                                dett.tiempohorasdt = a.tiempohorasdt;
                                dett.estadodt = a.estadodt;
                                dett.iddt = 10000;
                                dett.idia = Idia;
                                db.detalletiempoes.Add(dett);
                                db.SaveChanges();
                                #endregion
                            } 
                            #endregion
                        }

                        var ff = db.informeactividades.Find(Idia);
                        if( ff.fechainicialia != FechainicioTotal.ToShortDateString()||
                        ff.fechafinalia != FechafinalTotal.ToShortDateString()||
                        ff.totalhorasia != TotalHoras||
                        ff.observacionesia != ObservacionesX)
                        {
                            #region _
                            ff.fechainicialia = FechainicioTotal.ToShortDateString();
                            ff.fechafinalia = FechafinalTotal.ToShortDateString();
                            ff.totalhorasia = TotalHoras;
                            ff.observacionesia = ObservacionesX;
                            db.Entry(ff).State = EntityState.Modified; db.SaveChanges();  
                            #endregion
                        }
                        if (ItemEliminadosDelListado.Count > 0) //si han eliminado alguna fila, aqui lo descargo de la base tambien.
                        {
                            foreach (var a in ItemEliminadosDelListado)
                            {
                                detalletiempo ddf = new detalletiempo();
                                ddf = db.detalletiempoes.Find(a.iddt);
                                db.Entry(ddf).State = EntityState.Deleted; db.SaveChanges();
                            }
                        }

                        await AvisaYCerrateVosSolo("Los cambios en el informe de activiades se guardaron con éxito.", "Finalizado.", 1);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Ocurrio un error al guardar los cambios en informe de actividades.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico. "+e.InnerException, "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                        this.cmdCancelar();
                    }
                }
                this.FinalizarAction();
                #endregion
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
        //public async Task<permisosrolesusuario> DameUnRegistro(permisosrolesusuario ppp)
        //{
        //    //Funcion que permite que permite una espera minima para que otro proceso se ejecute o notifique.. en este caso, la barra de progreso.
        //    using (db = new SGPTEntidades())
        //    {
        //        permisosrolesusuario a = db.permisosrolesusuarios.Where(x => x.idusuario == ppp.idusuario && x.idpru == ppp.idpru).SingleOrDefault();
        //        await Task.Delay(1);
        //        //return Task.Run(() => a);
        //        return a;
        //    }
        //}
    }
}