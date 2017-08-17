using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Modales.AdmonClientes;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTWpf.SGPtmvvm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace SGPTmvvm.Modales
{

    public class CRUDfirmaCorrespondenciaViewModel : INotifyPropertyChanged
    {
        public SGPTEntidades db = new SGPTEntidades();

        public List<cliente> ClientesListado { get; set; }
        public List<usuariospersonas> ListadoUsuarios { get; set; }//= new List<usuariospersonas>();
        public List<contacto> ListadoContactos { get; set; }
        public List<contacto> ListadoContactosGenerales { get; set; }
        public List<correspondenciatipos> ListadoTipoCorrespondencia { get; set; }
        public List<correspondencia> ListadoCorrespondencias { get; set; }

        private DialogCoordinator dlg;

        public enum ListaBotonesTipoCorrespondencia { cEntrante, cSaliente }
        private ListaBotonesTipoCorrespondencia _tipoCorrespondencia;
        public ListaBotonesTipoCorrespondencia TipoCorrespondencia
        {
            get { return _tipoCorrespondencia; }
            set
            {
                _tipoCorrespondencia = value;
                RaisePropertyChanged("TipoCorrespondencia");
                this.EntradaSalidaCorrespondencia();
            }
        }

        private void EntradaSalidaCorrespondencia()
        {
            //Lo que hace es activar o desactivar los dos tipos de combobox, cuando es entrante, busca los contactos de ese cliente.
            if (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cSaliente) //saliente es la por defecto
            {
                HabilitarcmbUsuarioRecibe = true;
                HabilitarcmbClienteEmite = false;
                HabilitarcmdNuevoContacto = false;
                SelectedContactoFirma = null;
            }
            else if (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cEntrante)
            {
                HabilitarcmbUsuarioRecibe = false;
                HabilitarcmbClienteEmite = true;
                HabilitarcmdNuevoContacto = true;
                SelectedUsuarioFirma = null;
                this.BuscarContactos(); //buscamos los contactos de este cliente
            }
        }

        WebBrowser browser;

        public int CantidadRegistrosActualizados = 0;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 
        private bool AccionConsultar = false;
        //private bool HayCambiosEnLaEdicion = false; //variable para saber si se debera guardar cambios en una posible modificacion
        #region Message y currentUsuario
        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }
        #region ViewModel Property : currentUsuario usuario

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

        private string _currentNumeroCorrespondencia;
        public string currentNumeroCorrespondencia
        {
            get { return _currentNumeroCorrespondencia; }
            set { _currentNumeroCorrespondencia = value; RaisePropertyChanged("currentNumeroCorrespondencia"); }
        }
        private string _añoCorrespondencia;
        public string añoCorrespondencia
        {
            get { return _añoCorrespondencia; }
            set { _añoCorrespondencia = value; RaisePropertyChanged("añoCorrespondencia"); }
        }

        //ultimaCorrespondencia
        private string _ultimaCorrespondencia;
        public string ultimaCorrespondencia
        {
            get { return _ultimaCorrespondencia; }
            set { _ultimaCorrespondencia = value; RaisePropertyChanged("ultimaCorrespondencia"); }
        }

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
        //public CRUDfirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg, DialogCoordinator dlgIn)
        public CRUDfirmaCorrespondenciaViewModel(FirmaCorrespondenciaMensajeModal msg)
        {
            dlg = new DialogCoordinator();
            currentNumeroCorrespondencia = String.Empty;
            
            _canExecute = true;
            HabilitarGridCorresp = false;
            this.EscuchandoALaVista(msg);
        }
        #region v

        #region habilitarPersonaQueFirma

        private bool _HabilitarGridCorresp;
        public bool HabilitarGridCorresp
        {
            get { return _HabilitarGridCorresp; }
            set { _HabilitarGridCorresp = value; RaisePropertyChanged("HabilitarGridCorresp"); }
        }
        private bool _HabilitarcmbUsuarioRecibe;
        public bool HabilitarcmbUsuarioRecibe
        {
            get { return _HabilitarcmbUsuarioRecibe; }
            set { _HabilitarcmbUsuarioRecibe = value; RaisePropertyChanged("HabilitarcmbUsuarioRecibe"); }
        }

        private bool _HabilitarcmbClienteEmite;
        public bool HabilitarcmbClienteEmite
        {
            get { return _HabilitarcmbClienteEmite; }
            set { _HabilitarcmbClienteEmite = value; RaisePropertyChanged("HabilitarcmbClienteEmite"); }
        }

        private bool _HabilitarcmdNuevoContacto;
        public bool HabilitarcmdNuevoContacto
        {
            get { return _HabilitarcmdNuevoContacto; }
            set { _HabilitarcmdNuevoContacto = value; RaisePropertyChanged("HabilitarcmdNuevoContacto"); }
        }

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
        #endregion

        #region nombrearchivonormativa


        private string _nombrearchivopdf;
        public string Nombrearchivopdf
        {
            get
            {
                return _nombrearchivopdf;
            }

            set
            {
                if (_nombrearchivopdf == value)
                {
                    return;
                }
                _nombrearchivopdf = value;
                RaisePropertyChanged(Nombrearchivopdf);
            }
        }

        #region binarioCorrespondencia

        private byte[] _binarioCorrespondencia = null;

        public byte[] BinarioCorrespondencia
        {
            get
            {
                return _binarioCorrespondencia;
            }

            set
            {
                if (_binarioCorrespondencia == value)
                {
                    return;
                }

                _binarioCorrespondencia = value;
                RaisePropertyChanged("BinarioCorrespondencia");
            }
        }

        #endregion

        #endregion
        public Frame _vistapdf;
        public Frame VistaFramePDF
        {
            get
            {
                return _vistapdf;
            }

            set
            {
                _vistapdf = value;
                this.RaisePropertyChanged("VistaFramePDF");
            }
        }
        #endregion
        private bool _canExecute;
        public Action FinalizarAction { get; set; } //Permite cerrar la ventana(Window) que es la modal
        private void EscuchandoALaVista(FirmaCorrespondenciaMensajeModal Mensajito)
        {
            HabilitarGridCorresp = false;
            currentUsuario = Mensajito.UsuarioValidado;
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    OpcionDeVisitaAqui = 2; EditarCorrespondencia(Mensajito); break;
                case TipoComando.Consultar:
                    OpcionDeVisitaAqui = 3; ConsultarCorrespondencia(Mensajito);
                    break;
                case TipoComando.Nuevo:
                    OpcionDeVisitaAqui = 1; NuevoInformeTiempo(); break;
                default: break;
            }

        }


        #region Campos


        private int _idcorrespondencia;
        private int _idpapeles;
        private int _idusuario;
        private int _idct;
        private string _idnitcliente;
        private int _usuidusuario;
        private string _numerocorrespondencia;
        private string _asuntocorrespondencia;
        private string _firmacorrespondencia;
        private DateTime _fecharecepcioncorrespondencia;
        private string _comentariocorrespondencia;
        private string _aprobacioncorrespondencia;
        private DateTime _fechacreadocorrespondencia;
        private DateTime _fechaaprobacioncorrespondenci;
        private bool _salientecorrespondencia;
        private string _estadocorrespondencia;

        public int Idcorrespondencia { get { return _idcorrespondencia; } set { _idcorrespondencia = value; RaisePropertyChanged("Idcorrespondencia"); } }
        public int Idpapeles { get { return _idpapeles; } set { _idpapeles = value; RaisePropertyChanged("Idpapeles"); } }
        public int Idusuario { get { return _idusuario; } set { _idusuario = value; RaisePropertyChanged("Idusuario"); } }
        public int Idct { get { return _idct; } set { _idct = value; RaisePropertyChanged("Idct"); } }
        public string Idnitcliente { get { return _idnitcliente; } set { _idnitcliente = value; RaisePropertyChanged("Idnitcliente"); } }
        public int Usuidusuario { get { return _usuidusuario; } set { _usuidusuario = value; RaisePropertyChanged("Usuidusuario"); } }
        public string Numerocorrespondencia { get { return _numerocorrespondencia; } set { _numerocorrespondencia = value; RaisePropertyChanged("Numerocorrespondencia"); this.cambionumero(); } }

        private async void cambionumero()
        {
            try
            {
                #region +
                if (ListadoCorrespondencias != null && ListadoCorrespondencias.Count() > 0)
                {
                    if (ListadoCorrespondencias.Exists(x => x.numerocorrespondencia == Numerocorrespondencia))
                    {
                        if (OpcionDeVisitaAqui==1)
                        {
                            await AvisaYCerrateVosSolo("El numero correspondencia ya existe", "Ingrese el siguiente numero que corresponde segun el orden", 1);
                            txtBandera = "0";
                        }
                        else if (OpcionDeVisitaAqui == 2 && Numerocorrespondencia != currentNumeroCorrespondencia)
                        {
                            await AvisaYCerrateVosSolo("El numero correspondencia ya existe", "Ingrese el siguiente numero que corresponde segun el orden", 1);
                            txtBandera = "0";
                        }
                    }
                    else
                        txtBandera = "1";
                }
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show(""+e);
            }
        }
        public string Asuntocorrespondencia { get { return _asuntocorrespondencia; } set { _asuntocorrespondencia = value; RaisePropertyChanged("Asuntocorrespondencia"); } }
        //Nombre de la persona que emite o recibe la correspondencia
        public string Firmacorrespondencia { get { return _firmacorrespondencia; } set { _firmacorrespondencia = value; RaisePropertyChanged("Firmacorrespondencia"); } }
        public DateTime Fecharecepcioncorrespondencia { get { return _fecharecepcioncorrespondencia; } set { _fecharecepcioncorrespondencia = value; RaisePropertyChanged("Fecharecepcioncorrespondencia"); } }
        public string Comentariocorrespondencia { get { return _comentariocorrespondencia; } set { _comentariocorrespondencia = value; RaisePropertyChanged("Comentariocorrespondencia"); } }
        public string Aprobacioncorrespondencia { get { return _aprobacioncorrespondencia; } set { _aprobacioncorrespondencia = value; RaisePropertyChanged("Aprobacioncorrespondencia"); } }
        public DateTime Fechacreadocorrespondencia { get { return _fechacreadocorrespondencia; } set { _fechacreadocorrespondencia = value; RaisePropertyChanged("Fechacreadocorrespondencia"); } }
        public DateTime Fechaaprobacioncorrespondenci { get { return _fechaaprobacioncorrespondenci; } set { _fechaaprobacioncorrespondenci = value; RaisePropertyChanged("Fechaaprobacioncorrespondenci"); } }
        public bool Salientecorrespondencia { get { return _salientecorrespondencia; } set { _salientecorrespondencia = value; RaisePropertyChanged("Salientecorrespondencia"); } }
        public string Estadocorrespondencia { get { return _estadocorrespondencia; } set { _estadocorrespondencia = value; RaisePropertyChanged("Estadocorrespondencia"); } }


        #endregion

        #region Bindiados

        private string _txtBandera = "1"; //Sirve para habilitar el paso de guardado sin contraseña, solo cuando se crea un nuevo usuario.
        public string txtBandera
        {
            get { return _txtBandera; }
            set { _txtBandera = value; RaisePropertyChanged("txtBandera"); }
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

        private contacto _SelectedContactoFirma;
        public contacto SelectedContactoFirma
        {
            get { return _SelectedContactoFirma; }
            set { _SelectedContactoFirma = value; RaisePropertyChanged("SelectedContactoFirma"); }
        }


        private cliente _selectedCliente;
        public cliente SelectedCliente
        {
            get { return _selectedCliente; }
            set
            {
                _selectedCliente = value;
                RaisePropertyChanged("SelectedCliente");
                HabilitarGridCorresp = true;
                this.BuscarUltimasCorrespondenciasCliente();
                this.BuscarContactos();
            }
        }

        private async void BuscarUltimasCorrespondenciasCliente()
        {
            try
            {
                #region +
                //ojo, solo se le propondra cuando sea nueva correspondencia 
                if (OpcionDeVisitaAqui == 1 || OpcionDeVisitaAqui == 2)
                {
                    Mouse.OverrideCursor = Cursors.Wait;
                    añoCorrespondencia = DateTime.Now.Year.ToString();
                    #region +
                    if (SelectedCliente != null)
                    {
                        using (db = new SGPTEntidades())
                        {
                            ListadoCorrespondencias = new List<correspondencia>();

                            ListadoCorrespondencias = (from c in db.correspondencias where c.idnitcliente == SelectedCliente.idnitcliente && c.estadocorrespondencia == "A" select c).ToList();
                            if (ListadoCorrespondencias != null && ListadoCorrespondencias.Count() > 0)
                            {
                                #region +
                                var listado2 = ListadoCorrespondencias;
                                ListadoCorrespondencias = new List<correspondencia>();
                                foreach (var a in listado2)
                                {
                                    int anio = DateTime.Parse(a.fechacreadocorrespondencia).Year;
                                    if (anio == DateTime.Now.Year)
                                        ListadoCorrespondencias.Add(a);
                                }
                                if (OpcionDeVisitaAqui == 1 || OpcionDeVisitaAqui == 2)
                                {
                                    if (ListadoCorrespondencias != null) //si es nuevo registro calcula
                                    {
                                        #region +
                                        //primero busco la fecha mayor
                                        DateTime tempDate = DateTime.MinValue;
                                        DateTime fd = ListadoCorrespondencias.Select(x => DateTime.TryParse(x.fechacreadocorrespondencia, out tempDate)).Select(x => tempDate).Max();
                                        //ahora busco todas las correspondencias del cliente que se enviaron el dia maximo
                                        var listita = (from l in ListadoCorrespondencias where DateTime.Parse(l.fechacreadocorrespondencia) == fd select l).ToList();
                                        if (listita.Count == 1)
                                        {
                                            if (OpcionDeVisitaAqui == 1)
                                            {
                                                await AvisaYCerrateVosSolo("El ultimo numero de correspondencia encontrado es: " + listita[0].numerocorrespondencia, "", 2);
                                                Numerocorrespondencia = string.Empty;
                                            }
                                            ultimaCorrespondencia = listita[0].numerocorrespondencia;
                                        }
                                        else
                                        {
                                            //Ordeno la lista ascendentemente y tomo el ultimo registro
                                            var j = listita.OrderBy(x => x.numerocorrespondencia);
                                            if (OpcionDeVisitaAqui == 1)
                                            {
                                                await AvisaYCerrateVosSolo("El ultimo numero correspondencia encontrado es: " + j.Last().numerocorrespondencia, "", 2);
                                                Numerocorrespondencia = string.Empty;
                                            }
                                            ultimaCorrespondencia = j.Last().numerocorrespondencia;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        await dlg.ShowMessageAsync(this, "No tiene ninguna correspondencia de este cliente este año" + Environment.NewLine + "El sistema le propondra un nuevo numero que sera complementado con el año actual." + Environment.NewLine + "El cual puede aceptar o cambiar a su necesidad.", "");
                                        Numerocorrespondencia = "A-0001";
                                        añoCorrespondencia = DateTime.Now.Year.ToString();
                                        ultimaCorrespondencia = "N/D";
                                    } 
                                }
                                #endregion
                            }
                            else
                            {
                                await dlg.ShowMessageAsync(this, "No tiene ninguna correspondencia de este cliente este año" + Environment.NewLine + "El sistema le propondra un nuevo numero que sera complementado con el año actual." + Environment.NewLine + "El cual puede aceptar o cambiar a su necesidad.", "");
                                Numerocorrespondencia = "A-0001";
                                //añoCorrespondencia=DateTime.Now.Year.ToString();
                                ultimaCorrespondencia = "N/D";
                            }


                            //int ids=ListadoCorrespondencias.Select(u=> u.idcorrespondencia).Max();
                            //var idsx = ListadoCorrespondencias.Find(x => x.idcorrespondencia == ids);
                            //MessageBox.Show("ver1 el ultimo numero correspondencia buscandolo por idmaximo es: " + idsx.numerocorrespondencia);

                            //correspondencia d=ListadoCorrespondencias.Min(
                            //var listita = (from l in ListadoCorrespondencias where DateTime.Parse(l.fechacreadocorrespondencia) == fd select l).ToList();
                            //if(listita.Count==1)
                            //    //MessageBox.Show("V2 El ultimo numero de correspondencia es: "+ listita[0].numerocorrespondencia);
                            //else
                            //{
                            //    ////var ik = listita.OrderByDescending(x=>x.numerocorrespondencia);
                            //    //var j = listita.OrderBy(x => x.numerocorrespondencia);
                            //    ////MessageBox.Show("v3 El ultimo ingresado es ultimo: "+ik.Last().numerocorrespondencia+" Primero: "+ik.First());
                            //    //MessageBox.Show("v3.1 El ultimo ingresado es ultimo: " + j.Last().numerocorrespondencia + " Primero: " + j.First());
                            //    //int imax=0, i=0;
                            //    //foreach (var a in listita)
                            //    //{
                            //    //    //if(listita.Count==1)
                            //    //    //    MessageBox.Show("El ultimo numero de correspondencia es: "+a.numerocorrespondencia);
                            //    //    if (a.idcorrespondencia > imax)
                            //    //        imax = a.idcorrespondencia;
                            //    //    i++;
                            //    //    if(i==listita.Count())
                            //    //        MessageBox.Show("v2 El ultimo numero de correspondencia es: " + a.numerocorrespondencia);
                            //    //}

                            //}
                        }
                    }
                    #endregion
                    Mouse.OverrideCursor = null;
                }
                else
                {
                    HabilitarGridCorresp = false;
                }
                #endregion
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al buscar la ultima correspondencia " + e);
            }
        }

        private void BuscarContactos()
        {
            if (SelectedCliente != null)
            {
                Mouse.OverrideCursor = Cursors.Wait;
                #region +
                if (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cEntrante)
                {
                    using (db = new SGPTEntidades())
                    {
                        #region BuscarContactos
                        ListadoContactos = new List<contacto>();

                        ListadoContactos = (from c in db.contactos
                                            join e in db.contactoclientes
                                            on c.idcontacto equals e.idcontacto
                                            where e.idnitcliente == SelectedCliente.idnitcliente && c.estadocontacto == "A"
                                            select c).ToList();
                        foreach (var a in ListadoContactos)
                        {
                            a.nombrescontacto = a.nombrescontacto + " " + a.apellidoscontacto;
                        }
                        RaisePropertyChanged("ListadoContactos");
                        #endregion
                    }
                } 
                #endregion
                Mouse.OverrideCursor = null;
            }
        }

        private correspondenciatipos _selectedTipoCorrespondencia;
        public correspondenciatipos SelectedTipoCorrespondencia
        {
            get { return _selectedTipoCorrespondencia; }
            set { _selectedTipoCorrespondencia = value; RaisePropertyChanged("SelectedTipoCorrespondencia"); }
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

        private ICommand _SalirCommand;
        public ICommand SalirCommand
        {
            get
            {
                return _SalirCommand ?? (_SalirCommand = new CommandHandler(() => cmdSalir(), _canExecute));
            }
        }

        private async void cmdSalir()
        {
            if (browser != null)
            {
                browser.Dispose();
                VistaFramePDF.Content = null;
            }


            //frame.Content = null;

            //MessageBox.Show("No se realizo ninguna modificacion.", "Operacion cancelada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //await dlg.ShowMessageAsync(this, "No se realizo ninguna modificacion", "");
            await AvisaYCerrateVosSolo("Saliendo...", "", 1);
            this.FinalizarAction();
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

        private ICommand _cmdNuevoContacto_Click;
        public ICommand cmdNuevoContacto_Click
        {
            get
            {
                return _cmdNuevoContacto_Click ?? (_cmdNuevoContacto_Click = new CommandHandler(() => this.mycmdNuevoContacto(), _canExecute));
            }
        }

        private async void mycmdNuevoContacto()
        {
            try
            {
                if (SelectedCliente!=null) //si tiene permisos de crear
                {
                    //await AvisaYCerrateVosSolo("Redirigiendo a Crear nuevo contacto", "", 1);
                    Messenger.Default.Register<ClientesContactosMensajeModal>(this, "Correspondencia", (ClientesContactosMensajeModal) => ControlContactoCapturado(ClientesContactosMensajeModal));
                    //currentCliente2.idnitcliente = currentCliente.idnitcliente; //solo necesito enviarle el idnit.
                    ClientesContactosMensajeModal mensajito = new ClientesContactosMensajeModal(); mensajito.Accion = TipoComando.Nuevo; mensajito.UsuarioValidado = currentUsuario; mensajito.currentCliente = SelectedCliente; mensajito.ContactosAmodificar = new ContactosModelo(); mensajito.llamadoDesde = "Correspondencia";
                    CRUDclientesContactosContactoView mivista = new CRUDclientesContactosContactoView(mensajito);
                    var res = mivista.ShowDialog();
                    Messenger.Default.Unregister<ClientesContactosMensajeModal>(this); //mato el mensaje,para que libere memoria. pueda ser que la vista externa no mande nada.
                    //this.ObtenerDatosContactos();
                    RaisePropertyChanged("");
                }
                else
                {

                    await AvisaYCerrateVosSolo("No ha seleccionado el cliente.", "Seleccione un cliente para continuar", 2);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al comparar los permisos del usuario " + e.InnerException, "Error al levantar la vista de la estructura organica", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            //FocoPestañaSeleccionada = 1;
            //txtBandera = "0";
            //txtBanderaNuevo = "0";
            //txtBanderaEditar = "1";
            //txtBanderaConsultar = "1";
            //txtBanderaEliminar = "1";
            //txtBanderaAgregar = "1";
            //txtBanderaCancelar = "1";
            //txtBanderaRegresar = "1";
        }

        private void ControlContactoCapturado(ClientesContactosMensajeModal cN)
        {
            if (cN.Accion == TipoComando.Nuevo)
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

                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            db.contactos.Add(cont);
                            db.SaveChanges();

                            //Tenemos una tabla comodin que elimina la relacion muchos a muchos.
                            contactocliente concli = new contactocliente();
                            concli.idnitcliente = SelectedCliente.idnitcliente;
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
                            this.BuscarContactos(); //volvemos a recargar el combobox de los contactos para que aparezca el nuevo.

                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Error al recibir el nuevo contacto " + e);
                        }
                    }

                    //this.ObtenerDatosContactos();

                }
            }

            //this.ObtenerDatosContactos();
        }

        private ICommand _cmdCargarPDF_Click;
        public ICommand cmdCargarPDF_Click
        {
            get
            {
                return _cmdCargarPDF_Click ?? (_cmdCargarPDF_Click = new CommandHandler(() => this.MycmdCargarPDF_Click(), _canExecute));
            }
        }

        private void MycmdCargarPDF_Click()
        {
            //AvisaYCerrateVosSolo("Intentando cargar un pdf","",2);
            //VistaFramePDF
            //browser = new WebBrowser();
            //Frame fr = new Frame();
            OpenFileDialog arc = new OpenFileDialog();
            arc.Filter = "Archivos PDF |*.pdf";
            arc.Title = "Abrir carta de correspondencia";
            arc.ShowDialog();
            string sArchivo = arc.FileName;

            if (!string.IsNullOrEmpty(sArchivo))
            {
                //string filename = sArchivo;
                //browser.Navigate(new Uri(filename));
                ////fr.Content = browser;
                //VistaFramePDF = new Frame();
                //VistaFramePDF.Content = browser; //fr; 
                this.MuestreImagenPDF(sArchivo);

                try
                {
                    if (!(string.IsNullOrEmpty(sArchivo)))
                    {
                        using (FileStream fsSource = new FileStream(sArchivo, FileMode.Open, FileAccess.Read))
                        {
                            //Leer la imagen en un array de bytes
                            ///////////////////////////////////////////////////
                            //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                            //Byte[] ByteArray = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //binarioNormativa = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //nombrearchivonormativa= rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                            //currentEntidad.binarioNormativa = File.ReadAllBytes(rutaArchivo);//Para comparar y probar
                            //currentEntidad.nombrearchivonormativa = rutaArchivo.Substring(rutaArchivo.LastIndexOf("\\") + 1);
                            //binarioNormativa = currentEntidad.binarioNormativa;
                            //nombrearchivonormativa = currentEntidad.nombrearchivonormativa;
                            Nombrearchivopdf = sArchivo.Substring(sArchivo.LastIndexOf("\\") + 1);
                            BinarioCorrespondencia = File.ReadAllBytes(sArchivo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al procesar el binario del pdf " + ex.InnerException);
                }
            }
        }

        private void MuestreImagenPDF(string sArchivo)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            browser = new WebBrowser();
            string filename = sArchivo.Trim();
            browser.Navigate(new Uri(filename));
            //fr.Content = browser;
            VistaFramePDF = new Frame();
            VistaFramePDF.Content = browser; //fr; 
            Mouse.OverrideCursor = null;
        }
        public void inicializarListados()
        {
            Mouse.OverrideCursor = Cursors.Wait;
            #region MyRegion
            using (db = new SGPTEntidades())
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Configuration.ValidateOnSaveEnabled = false;
                //Fechainicialdt = DateTime.Now;
                //Fechafinaldt = DateTime.Now;
                try
                {
                    ClientesListado = (from c in db.clientes where c.estadocliente == "A" orderby c.razonsocialcliente select c).ToList();

                    //cliente seleccionecliente = new cliente();
                    //seleccionecliente.idnitcliente = "-1";
                    //seleccionecliente.razonsocialcliente = "--Seleccione un cliente--";
                    //ClientesListado.Insert(0, seleccionecliente);

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

                    ListadoContactosGenerales = new List<contacto>();
                    ListadoContactosGenerales = db.contactos.ToList();
                    //ListadoContactos = new List<contacto>();

                    //ListadoContactos = (from c in db.contactos
                    //                    join e in db.contactoclientes
                    //                    on c.idcontacto equals e.idcontacto
                    //                    where e.idnitcliente == currentCliente.idnitcliente && c.estadocontacto == "A"
                    //                    select c).ToList();
                    //usuariospersonas seleccioneunusuario = new usuariospersonas();
                    //seleccioneunusuario.idduipersona = "N";
                    //seleccioneunusuario.nombreCompleto = "--Seleccione un usuario--";
                    //ListadoUsuarios.Insert(0, seleccioneunusuario);

                    ListadoTipoCorrespondencia = (from ct in db.correspondenciatipos where ct.estadoct == "A" orderby ct.descripcionct select ct).ToList();
                    //correspondenciatipos selectipo = new correspondenciatipos();
                    //selectipo.idct = 0;
                    //selectipo.descripcionct = "--Seleccione tipo correspondencia --";
                    //ListadoTipoCorrespondencia.Insert(0,selectipo);

                    //ListadoCorrespondencias=

                    //RaisePropertyChanged();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Iniciar listado. La base de datos tardo demasiado en responder. " + e.InnerException);
                }
            }

            RaisePropertyChanged("");
            #endregion
            Mouse.OverrideCursor = null;
        }


        private void NuevoInformeTiempo()
        {
            //EjecutarMensaje();

            //dlg.ShowMessageAsync(this, "Nuevo informe tiempo", "adfas"); *
            //dlg.ShowMessageAsync(this, "El usuario:  no tiene permisos para crear ningun tipo de informes.", "Consulte al administrador acerca de esta restriccion.");
            //this.Habilitadores(true); //le solicito que active todos los campos
            this.inicializarListados();
            SelectedUsuarioFirma = ListadoUsuarios.Find(x => x.idusuario == currentUsuario.idusuario);
            TipoCorrespondencia = ListaBotonesTipoCorrespondencia.cEntrante;
            Fecharecepcioncorrespondencia = DateTime.Now;
            txtBandera = "1";
            AccionGuardar = true;
            AccionConsultar = false;

            Message = "Nueva correspondencia";

            //vamos a proponerle el ultimo numero de correspondencia.
            añoCorrespondencia = DateTime.Now.Year.ToString();


        }
        private void EditarCorrespondencia(FirmaCorrespondenciaMensajeModal Mensajito)
        {
            //dlg.ShowMessageAsync(this, "Hola", "");
            //AvisaYCerrateVosSolo("Editando", "", 1);
            txtBandera = "1";
            AccionGuardar = false;
            AccionConsultar = false;
            this.inicializarListados();

            Message = "Editar correpondencia";
            this.CompartidaEditarConsultar(Mensajito);
        }

        private void CompartidaEditarConsultar(FirmaCorrespondenciaMensajeModal Mensajito)
        {
            CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            try
            {
            #region -
            Idcorrespondencia = CorrespondenciaRecibida.idcorrespondencia;
            Numerocorrespondencia = CorrespondenciaRecibida.numerocorrespondencia.Substring(0, CorrespondenciaRecibida.numerocorrespondencia.Length - 5);
            currentNumeroCorrespondencia = CorrespondenciaRecibida.numerocorrespondencia;
                string [] l = CorrespondenciaRecibida.numerocorrespondencia.Split('-');

                añoCorrespondencia = l[l.Count() - 1];
            if (CorrespondenciaRecibida.idnitcliente.Length > 15) SelectedCliente = ClientesListado.Find(y => y.idnitcliente == CorrespondenciaRecibida.idnitcliente);
            else SelectedCliente = null;
            //corresp.salientecorrespondencia = (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cEntrante ? false : true);
            TipoCorrespondencia = (CorrespondenciaRecibida.salientecorrespondencia == false) ? ListaBotonesTipoCorrespondencia.cEntrante : ListaBotonesTipoCorrespondencia.cSaliente;
            if (CorrespondenciaRecibida.salientecorrespondencia == false) { HabilitarcmbClienteEmite = true; HabilitarcmbUsuarioRecibe = false; } else { HabilitarcmbUsuarioRecibe = true; HabilitarcmbClienteEmite = false; };
            Asuntocorrespondencia = CorrespondenciaRecibida.asuntocorrespondencia;
            //if (CorrespondenciaRecibida.idusuario >= 1) SelectedUsuarioFirma = ListadoUsuarios.Find(x => x.idusuario == CorrespondenciaRecibida.idusuario);
            //if (CorrespondenciaRecibida.idusuario >= 1) 
            if (CorrespondenciaRecibida.idct > 0)
                SelectedTipoCorrespondencia = ListadoTipoCorrespondencia.Find(z => z.idct == CorrespondenciaRecibida.idct);
            else SelectedTipoCorrespondencia = null;

            if (CorrespondenciaRecibida.idcontactofirmacorrespondencia > 0)
                SelectedContactoFirma = ListadoContactos.Find(x => x.idcontacto == (int)(CorrespondenciaRecibida.idcontactofirmacorrespondencia));
            else SelectedContactoFirma = null;

            if (!string.IsNullOrEmpty(CorrespondenciaRecibida.firmacorrespondencia))
                SelectedUsuarioFirma = ListadoUsuarios.Find(x => x.idusuario == int.Parse(CorrespondenciaRecibida.firmacorrespondencia));
            else SelectedUsuarioFirma = null;

            


            Fecharecepcioncorrespondencia = DateTime.Parse(CorrespondenciaRecibida.fecharecepcioncorrespondencia);
            Comentariocorrespondencia = CorrespondenciaRecibida.comentariocorrespondencia;
            

            if (!string.IsNullOrEmpty(CorrespondenciaRecibida.nombrefilecorrespondencia) && CorrespondenciaRecibida.archivocorrespondencia != null)
            {
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string fileName = String.Empty;
                //fileName = Path.g.GetTempPath() + currentEntidad.nombrearchivonormativa;
                if (!string.IsNullOrEmpty(mydocpath))
                {
                    fileName = mydocpath + @"\" + CorrespondenciaRecibida.nombrefilecorrespondencia;
                }
                else
                {

                    fileName = Path.GetTempPath() + CorrespondenciaRecibida.nombrefilecorrespondencia;
                }
                try
                {
                    //if(File.Exists())
                    //string file = @"C:\subfolder\test.txt";
                    if (Directory.Exists(Path.GetDirectoryName(fileName)))
                    {
                        System.IO.File.Delete(fileName);
                    }
                    //await Task.Delay(1);
                    File.WriteAllBytes(fileName, CorrespondenciaRecibida.archivocorrespondencia);
                    this.MuestreImagenPDF(fileName);
                }
                catch (Exception g)
                {
                    MessageBox.Show("No soportado imagen pdf " + g.InnerException);
                }
            }
            else
            {
                //await dlg.ShowMessageAsync(this,"Debe cargar el pdf de la correspondencia","");
                //await AvisaYCerrateVosSolo("No ha cargado aun el pdf de la correspondencia", "", 1);
            }
            //RaisePropertyChanged();
            #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocurrio un error al recuperar los datos de la correspondencia en compartida editarconsultar. \nProblema de compatibilidad de los datos\nInforme a soporte tecnico acerca de este error. " + e, "Error de compatibilidad");
            }
        }

        private void ConsultarCorrespondencia(FirmaCorrespondenciaMensajeModal Mensajito)
        {
            this.inicializarListados();
            txtBandera = "0";
            AccionGuardar = false;
            AccionConsultar = true;
            HabilitarGridCorresp = false;
            //CorrespondenciaModelo CorrespondenciaRecibida = Mensajito.CorrespondenciaAmodificar;
            Message = "Consultar correspondencia";
            this.CompartidaEditarConsultar(Mensajito);
        }

        private async void cmdCancelar()
        {
            //WebBrowser browser = VistaFramePDF.Content as WebBrowser;

            if (browser != null)
            {
                browser.Dispose();
                VistaFramePDF.Content = null;
            }


            //frame.Content = null;

            //MessageBox.Show("No se realizo ninguna modificacion.", "Operacion cancelada", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //await dlg.ShowMessageAsync(this, "No se realizo ninguna modificacion", "");
            await AvisaYCerrateVosSolo("No se realizo ninguna modificacion.", "Operacion cancelada", 1);
            this.FinalizarAction();
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
            //Atencion averiguar que el numero de correspondencia ingresado no se halla asignado previamente.23/03/2017 //ya
            if (await ValidacionManualOk())
            {
                #region v
                correspondencia corresp, correspx = new correspondencia(); ;
                using (db = new SGPTEntidades())
                {
                    if (AccionGuardar) { corresp = new correspondencia(); }
                    else
                    {
                        correspx = db.correspondencias.Find(Idcorrespondencia);
                        corresp = db.correspondencias.Find(Idcorrespondencia);
                    }
                }

                //corresp.idcorrespondencia = 1000;

                corresp.idusuario = currentUsuario.idusuario;
                if (SelectedTipoCorrespondencia != null)
                    corresp.idct = SelectedTipoCorrespondencia.idct;
                if (SelectedCliente != null)
                    corresp.idnitcliente = SelectedCliente.idnitcliente;
                corresp.numerocorrespondencia = (Numerocorrespondencia+"-"+DateTime.Now.Year.ToString()).Trim();
                corresp.asuntocorrespondencia = Asuntocorrespondencia;
                if (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cSaliente && SelectedUsuarioFirma!=null)
                    corresp.firmacorrespondencia = SelectedUsuarioFirma.idusuario.ToString();
                else if (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cEntrante && SelectedContactoFirma!=null)
                    corresp.idcontactofirmacorrespondencia = SelectedContactoFirma.idcontacto;
                corresp.fecharecepcioncorrespondencia = DateTime.Now.ToShortDateString();
                corresp.comentariocorrespondencia = Comentariocorrespondencia;
                corresp.fechacreadocorrespondencia = DateTime.Now.ToShortDateString();
                corresp.salientecorrespondencia = (TipoCorrespondencia == ListaBotonesTipoCorrespondencia.cEntrante ? false : true);
                corresp.aprobacioncorrespondencia = "P";
                /*Ahora vamos a guardar el pdf convertido a bytes*/
                if (!string.IsNullOrEmpty(Nombrearchivopdf) && BinarioCorrespondencia != null)
                {
                    corresp.archivocorrespondencia = BinarioCorrespondencia;
                    corresp.nombrefilecorrespondencia = Nombrearchivopdf;
                }
                corresp.estadocorrespondencia = "A";

                if (AccionGuardar)
                {
                    #region v
                    corresp.idcorrespondencia = 1000;

                    using (db = new SGPTEntidades())
                    {
                        #region _
                        try
                        {
                            #region _
                            Mouse.OverrideCursor = Cursors.Wait;
                            db.correspondencias.Add(corresp);
                            db.SaveChanges();
                            Mouse.OverrideCursor = null;
                            //MessageBox.Show("El registro se guardo con éxito.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                            await AvisaYCerrateVosSolo("El registro se guardo con éxito.", "Finalizado.", 2);
                            #endregion
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al guardar en correspondencia.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico de este problema. " + ex.InnerException, "Imposible guardar el informe de tiempo", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                        #endregion
                    }
                    //this.FinalizarAction();
                    this.cmdSalir();

                    #endregion
                }
                else if (!AccionConsultar)
                {
                    #region v

                    using (db = new SGPTEntidades())
                    {
                        bool com = false;// = j.Equals(k);

                        if (!com)
                        {
                            #region _
                            try
                            {
                                Mouse.OverrideCursor = Cursors.Wait;
                                db.Entry(corresp).State = EntityState.Modified; db.SaveChanges();
                                await AvisaYCerrateVosSolo("Los cambios se guardaron con éxito.", "Finalizado.", 2);
                                Mouse.OverrideCursor = null;
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Ocurrio un error al guardar los cambios en correspondencia.\nLa base de datos tardo demasiado en responder.\nSi el problema continua, informe a soporte tecnico. " + e.InnerException, "Error al intentar guardar.", MessageBoxButton.OK, MessageBoxImage.Stop);
                                this.cmdCancelar();
                            }
                            #endregion
                        }
                        else { await AvisaYCerrateVosSolo("No hay nada que guardar...", "Sin cambios", 1); }
                    }
                    //this.FinalizarAction();
                    this.cmdSalir();
                    #endregion
                }

                #endregion
            }
        }

        private async Task<bool> ValidacionManualOk()
        {
            //Nota, averiguar que el numero de correspondencia no se repita en la base. 23/03/2017. ya
            if (!String.IsNullOrEmpty(Numerocorrespondencia))
            {
                #region _
                if (!String.IsNullOrEmpty(Asuntocorrespondencia))
                {
                    #region _
                    //if (SelectedUsuarioFirma.idduipersona.Length > 7)
                    //{
                        #region _
                        return true;
                        #endregion

                    //}
                    //else
                    //{
                    //    await AvisaYCerrateVosSolo("Ingrese el usuario que firma", "Usuario que firma", 1);
                    //}
                    #endregion
                }
                else
                {
                    await AvisaYCerrateVosSolo("Ingrese un asunto para la correspondencia.", "Falta asunto en correspondencia", 2);
                }
                #endregion
            }
            else
            {
                await AvisaYCerrateVosSolo("Ingrese un numero de correspondencia", "Numero de correspondencia", 1);
            }
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