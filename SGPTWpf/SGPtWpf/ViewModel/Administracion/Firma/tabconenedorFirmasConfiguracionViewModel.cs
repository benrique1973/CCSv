using CapaDatos;
using Microsoft.Win32;
using SGPTmvvm.Model;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace SGPTWpf.ViewModel.Administracion.Firma
{
    public class tabconenedorFirmaConfiguracionViewModel : ViewModeloBase
    {
        public SGPTEntidades db = new SGPTEntidades();
        public List<pais> ListadoPaises { get; set; }
        public List<firma> ListadoFirmas { get; set; }
        public List<departamento> ListadoDepartamentos { get; set; }
        public List<municipio> ListadoMunicipios { get; set; }
        public List<tipostelefono> ListadoTipoTelefono { get; set; }
        public List<telefono> ListadoTelefonos { get; set; }
        ObservableCollection<telefono> _telefonos = new ObservableCollection<telefono>();
        public List<correo> ListadoCorreos { get; set; }
        ObservableCollection<correo> _correos = new ObservableCollection<correo>();

        public ObservableCollection<UsuariosVM> UsuariosListado { get; set; }
        List<UsuariosVM> UsuariosListados = new List<UsuariosVM>();
        String strNombre, imagenNombre;
        //byte[] imgListaArray;
        private bool AccionGuardar = true; //variable para al momento de Guardar, diferencie entre Guardar o actualizar(update). 

        public tabconenedorFirmaConfiguracionViewModel()
        {
            _canExecute = true;
            this.ObtenerDatos();
            TipoIP = ListaBotonesTipoIP.IpLocal;
            TipoProtocolo = ListaBotonesProtocoloIP.Ipv4;
            EsConexionPrincipal = true;
        }
        private bool _canExecute;



        #region Parte Sistema
        //public bool IsCheckBoxChecked
        //{
        //    get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
        //    set { SetValue(IsCheckBoxCheckedProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty IsCheckBoxCheckedProperty =
        //    DependencyProperty.Register("IsCheckBoxChecked", typeof(bool), typeof(tabconenedorFirmaConfiguracionViewModel), new PropertyMetadata(false));
        public ICommand _cmdGuardarConfSistema;
        public ICommand cmdGuardarConfSistema { get { return _cmdGuardarConfSistema ?? (_cmdGuardarConfSistema = new CommandHandler(() => MycmdGuardarConfSistema(), _canExecute)); } }

        private void MycmdGuardarConfSistema()
        {
            MessageBox.Show("Selecciono guardar en Sistema");
        }
 

        public enum ListaBotonesTipoIP { IpLocal, IpPublica }
        public enum ListaBotonesProtocoloIP { Ipv4, Ipv6 }

        private bool _esConexionPrincipal;
        public bool EsConexionPrincipal
        {
            get { return _esConexionPrincipal; }
            set { _esConexionPrincipal = value; RaisePropertyChanged("EsConexionPrincipal"); }

        }

        private ListaBotonesTipoIP _tipoIP;
        public ListaBotonesTipoIP TipoIP
        {
            get { return _tipoIP; }
            set
            {
                _tipoIP = value;
                RaisePropertyChanged("TipoIp");
            }
        }
        private ListaBotonesProtocoloIP _tipoProtocolo;
        public ListaBotonesProtocoloIP TipoProtocolo
        {
            get { return _tipoProtocolo; }
            set
            {
                _tipoProtocolo = value;
                RaisePropertyChanged("TipoProtocolo");
            }
        } 
        #endregion

        //este codigo permite enchutar directamente una vista al Frame
        /*public UserControl _vistaFirma;
        public UserControl VistaFirma
        {
            get
            {
                return _vistaFirma;
            }

            set
            {
                this.RaisePropertyChanged("VistaFirma");
                _vistaFirma = value;
                this.RaisePropertyChanged("VistaFirma");
            }
        }

        public UserControl _vistaSistema;
        public UserControl VistaSistema
        {
            get
            {
                return _vistaSistema;
            }

            set
            {
                this.RaisePropertyChanged("VistaSistema");
                _vistaSistema = value;
                this.RaisePropertyChanged("VistaSistema");
            }
        } */

        #region Bindiados
        #region Correos y telefonos
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
                    //if (PropertyChanged != null)
                    //PropertyChanged(this, new PropertyChangedEventArgs("CorreoPrincipalChek"));
                }
            }
        }
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


        #endregion

        /*******************************************************************************************************************/
        #region v
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
        private UsuariosVM _selectedRepresentanteLegal;
        public UsuariosVM SelectedRepresentanteLegal
        {
            get
            {
                return _selectedRepresentanteLegal;
            }
            set
            {
                _selectedRepresentanteLegal = value;
                RaisePropertyChanged("");
            }
        }

        /*******************************************************************************************************************/
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
                RaisePropertyChanged("selectedCorreoAgregado");
            }
        }

        /***********************************************/
        //SelectedTelefonoAgregado
        private telefono _selectedTelefonoAgregado;
        public telefono SelectedTelefonoAgregado
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
        /***********************************************/

        #endregion
        /************************************************Activar y desactivar campos en la vista**********************************/
        #region Habilitadores
        /**********************Inicio Habilitadores campos TabFirma****************************************/
        /**************************************************/
        private Boolean _HabilitartxtNombreFirma;
        public Boolean HabilitartxtNombreFirma
        {
            get
            {
                return _HabilitartxtNombreFirma;
            }
            set
            {
                _HabilitartxtNombreFirma = value;
                RaisePropertyChanged("HabilitartxtNombreFirma");
            }
        }
        /**************************************************/
        private Boolean _HabilitartxtNoCVPV;
        public Boolean HabilitartxtNoCVPV
        {
            get
            {
                return _HabilitartxtNoCVPV;
            }
            set
            {
                _HabilitartxtNoCVPV = value;
                RaisePropertyChanged("HabilitartxtNoCVPV");
            }
        }
        /**************************************************/
        private Boolean _HabilitarRepresentanteLegal;
        public Boolean HabilitarRepresentanteLegal
        {
            get
            {
                return _HabilitarRepresentanteLegal;
            }
            set
            {
                _HabilitarRepresentanteLegal = value;
                RaisePropertyChanged("HabilitarRepresentanteLegal");
            }
        }
        /**************************************************/
        private Boolean _HabilitarComboPaises;
        public Boolean HabilitarComboPaises
        {
            get
            {
                return _HabilitarComboPaises;
            }
            set
            {
                _HabilitarComboPaises = value;
                RaisePropertyChanged("HabilitarComboPaises");
            }
        }
        /**************************************************/
        private Boolean _HabilitarDepartamento;
        public Boolean HabilitarDepartamento
        {
            get
            {
                return _HabilitarDepartamento;
            }
            set
            {
                _HabilitarDepartamento = value;
                RaisePropertyChanged("HabilitarDepartamento");
            }
        }
        /**************************************************/
        private Boolean _HabilitarMunicipio;
        public Boolean HabilitarMunicipio
        {
            get
            {
                return _HabilitarMunicipio;
            }
            set
            {
                _HabilitarMunicipio = value;
                RaisePropertyChanged("HabilitarMunicipio");
            }
        }
        /**************************************************/
        private Boolean _HabilitarDireccion;
        public Boolean HabilitarDireccion
        {
            get
            {
                return _HabilitarDireccion;
            }
            set
            {
                _HabilitarDireccion = value;
                RaisePropertyChanged("HabilitarDireccion");
            }
        }
        /**************************************************/
        private Boolean _HabilitarPaginaWeb;
        public Boolean HabilitarPaginaWeb
        {
            get
            {
                return _HabilitarPaginaWeb;
            }
            set
            {
                _HabilitarPaginaWeb = value;
                RaisePropertyChanged("HabilitarPaginaWeb");
            }
        }
        /**************************************************/
        private Boolean _HabilitarTelefonos;
        public Boolean HabilitarTelefonos
        {
            get
            {
                return _HabilitarTelefonos;
            }
            set
            {
                _HabilitarTelefonos = value;
                RaisePropertyChanged("HabilitarTelefonos");
            }
        }
        /**************************************************/
        private Boolean _HabilitarCorreos;
        public Boolean HabilitarCorreos
        {
            get
            {
                return _HabilitarCorreos;
            }
            set
            {
                _HabilitarCorreos = value;
                RaisePropertyChanged("HabilitarCorreos");
            }
        }
        /*************************************Fin Habilitador campos*****************************/
        /**********************************Habilitador de Botones de Comando TabFirma*****************/
        /**************************************************/
        private Boolean _HabilitarBtnNuevo;
        public Boolean HabilitarBtnNuevo
        {
            get
            {
                return _HabilitarBtnNuevo;
            }
            set
            {
                _HabilitarBtnNuevo = value;
                RaisePropertyChanged("HabilitarBtnNuevo");
            }
        }
        /**************************************************/
        private Boolean _HabilitarBtnModificar;
        public Boolean HabilitarBtnModificar
        {
            get
            {
                return _HabilitarBtnModificar;
            }
            set
            {
                _HabilitarBtnModificar = value;
                RaisePropertyChanged("HabilitarBtnModificar");
            }
        }
        /**************************************************/
        private Boolean _HabilitarBtnLogo;
        public Boolean HabilitarBtnLogo
        {
            get
            {
                return _HabilitarBtnLogo;
            }
            set
            {
                _HabilitarBtnLogo = value;
                RaisePropertyChanged("HabilitarBtnLogo");
            }
        }
        /**************************************************/
        private Boolean _HabilitarBtnGuardar;
        public Boolean HabilitarBtnGuardar
        {
            get
            {
                return _HabilitarBtnGuardar;
            }
            set
            {
                _HabilitarBtnGuardar = value;
                RaisePropertyChanged("HabilitarBtnGuardar");
            }
        }
        /**************************************************/
        private Boolean _HabilitarBtnCancelar;
        public Boolean HabilitarBtnCancelar
        {
            get
            {
                return _HabilitarBtnCancelar;
            }
            set
            {
                _HabilitarBtnCancelar = value;
                RaisePropertyChanged("HabilitarBtnCancelar");
            }
        }

        #endregion

        #endregion


        #region Campos
        #region CorreoyTelefono
        /*Estos dos campos no pertenecen a ninguna de las dos tablas, pero se agregan para bindiarlas con el List de Telefonos y de Correos
         Ya que los correos y los telefonos se guardaran despues de guardado el usuario y la persona pq necesita el id de el*/
        private string _telefonoT;
        private string _correoT;

        public string TelefonoT { get { return _telefonoT; } set { _telefonoT = value; RaisePropertyChanged("TelefonoT"); } }
        public string CorreoT { get { return _correoT; } set { _correoT = value; RaisePropertyChanged("CorreoT"); } }
        #endregion

        private int _idfirma;
        private int _iddepartamento;
        private int _idpais;
        private int _idmunicipio;
        private int _idusuario;
        private string _razonsocialfirma;
        private string _representantefirma;
        private string _nitfirma;
        private string _nrcfirma;
        private string _direccionfirma;
        private string _numerocvpafirma;
        private string _fechainscripcioncvpafirma;
        private string _fechacreadofirma;
        private string _urlfirma;
        private byte[] _logofirma;
        private string _estadofirma;
        public int Idfirma { get { return _idfirma; } set { _idfirma = value; RaisePropertyChanged("Idfirma"); } }
        public int Iddepartamento { get { return _iddepartamento; } set { _iddepartamento = value; RaisePropertyChanged("Iddepartamento"); } }
        public int Idpais { get { return _idpais; } set { _idpais = value; RaisePropertyChanged("Idpais"); } }
        public int Idmunicipio { get { return _idmunicipio; } set { _idmunicipio = value; RaisePropertyChanged("Idmunicipio"); } }
        public int Idusuario { get { return _idusuario; } set { _idusuario = value; RaisePropertyChanged("Idusuario"); } }
        public string Razonsocialfirma              { get { return  _razonsocialfirma; }           set { _razonsocialfirma= value; RaisePropertyChanged("Razonsocialfirma"); } }
        public string Representantefirma { get { return _representantefirma; } set { _representantefirma = value; RaisePropertyChanged("Representantefirma"); } }
        public string Nitfirma { get { return _nitfirma; } set { _nitfirma = value; RaisePropertyChanged("Nitfirma"); } }
        public string Nrcfirma { get { return _nrcfirma; } set { _nrcfirma = value; RaisePropertyChanged("Nrcfirma"); } }
        public string Direccionfirma { get { return _direccionfirma; } set { _direccionfirma = value; RaisePropertyChanged("Direccionfirma"); } }
        public string Numerocvpafirma { get { return _numerocvpafirma; } set { _numerocvpafirma = value; RaisePropertyChanged("Numerocvpafirma"); } }
        public string Fechainscripcioncvpafirma { get { return _fechainscripcioncvpafirma; } set { _fechainscripcioncvpafirma = value; RaisePropertyChanged("Fechainscripcioncvpafirma"); } }
        public string Fechacreadofirma { get { return _fechacreadofirma; } set { _fechacreadofirma = value; RaisePropertyChanged("Fechacreadofirma"); } }
        public string Urlfirma { get { return _urlfirma; } set { _urlfirma = value; RaisePropertyChanged("Urlfirma"); } }
        public byte[] Logofirma { get { return _logofirma; } set { _logofirma = value; RaisePropertyChanged("Logofirma"); } }
        public string Estadofirma { get { return _estadofirma; } set { _estadofirma = value; RaisePropertyChanged("Estadofirma"); } }
        #endregion


        public new event PropertyChangedEventHandler PropertyChanged;

        public new void RaisePropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



        public ICommand _miComanditoFirma;
        public ICommand MiComanditoFirma { get { return _miComanditoFirma ?? (_miComanditoFirma = new CommandHandler(() => MyPestañaFirma(), _canExecute)); } }

        public ICommand _miComanditoSistema;
        public ICommand MiComanditoSistema { get { return _miComanditoSistema ?? (_miComanditoSistema = new CommandHandler(() => MyPestañaSistema(), _canExecute)); } }

        private void MyPestañaSistema()
        {
            //ViewTypex = typeof(RolesView);
            //Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            //VistaSistema = Viewx;

        }

        //Este codigo sirve para capturar el evento click el el tab
        /*public UserControl Viewx { get; set; }
        public Type ViewTypex { get; set; }

        private void MyPestañaFirma()
        {
            ViewTypex = typeof(RolesView);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            VistaFirma = Viewx;
        }*/

        private void MyPestañaFirma()
        {

        }
        

        private void ObtenerDatos() //protected override void ObtenerDatos()
        {
            this.inicializarListados();
            persona persh = new persona();
            //UsuariosVM 
            //List<personaVM> Tpersh = new List<persona>();
            using (db = new SGPTEntidades())
            {
                ListadoFirmas = (from f in db.firmas orderby f.idfirma select f).ToList();
                //persh = db.personas.Join(db.usuarios, p => p.idduipersona, u => u.idduipersona, (p, u) => new { personas = p, usuarios = u }).Where(uu => uu.usuarios.idusuario == usua.usuidusuario).Select(uu => uu.personas).SingleOrDefault();

                ListadoCorreos = (ListadoFirmas[0].correos).ToList();
                foreach (correo coo in ListadoCorreos) { _correos.Add(coo); }
                ListadoTelefonos = (ListadoFirmas[0].telefonos).ToList();
                foreach (telefono too in ListadoTelefonos) { _telefonos.Add(too); }

                foreach (UsuariosVM uxuar in UsuariosListado)
                {
                    if (uxuar.TheUsuariosPersonas.idusuario == ListadoFirmas[0].idusuario)
                    {
                        SelectedRepresentanteLegal = uxuar;
                    }
                }


                foreach (pais paix in ListadoPaises)
                {
                    if (paix.idpais == ListadoFirmas[0].idpais)
                    {
                        SelectedPais = paix;
                    }
                }
                foreach (departamento depx in ListadoDepartamentos)
                {
                    if (depx.iddepartamento == ListadoFirmas[0].iddepartamento)
                    {
                        SelectedDepartamento = depx;
                    }
                }
                foreach (municipio munx in ListadoMunicipios)
                {
                    if (munx.idmunicipio == ListadoFirmas[0].idmunicipio)
                    {
                        SelectedMunicipio = munx;
                    }
                }

            }
            if (ListadoFirmas.Count() > 0)
            {
                //carga de datos a los campos.
                Idfirma = ListadoFirmas[0].idfirma;
                //RaisePropertyChanged("Idfirma");
                Iddepartamento = (int)ListadoFirmas[0].iddepartamento;
                //RaisePropertyChanged("Iddepartamento");
                Idpais = ListadoFirmas[0].idpais;
                //RaisePropertyChanged("Idpais");
                Idmunicipio = ListadoFirmas[0].idmunicipio;
                //RaisePropertyChanged("Idmunicipio");
                Idusuario = (int)ListadoFirmas[0].idusuario;
                //RaisePropertyChanged("Idusuario");
                Razonsocialfirma = ListadoFirmas[0].razonsocialfirma;
                //RaisePropertyChanged("Razonsocialfirma");  
                Representantefirma = ListadoFirmas[0].representantefirma;
                //RaisePropertyChanged("Representantefirma");
                Nitfirma = ListadoFirmas[0].nitfirma;
                //RaisePropertyChanged("Nitfirma");
                Nrcfirma = ListadoFirmas[0].nrcfirma;
                //RaisePropertyChanged("Nrcfirma");
                Direccionfirma = ListadoFirmas[0].direccionfirma;
                //RaisePropertyChanged("Direccionfirma");
                Numerocvpafirma = Convert.ToString(ListadoFirmas[0].numerocvpafirma);
                //RaisePropertyChanged("");
                Fechainscripcioncvpafirma = ListadoFirmas[0].fechainscripcioncvpafirma; RaisePropertyChanged("Fechainscripcioncvpafirma");
                Fechacreadofirma = ListadoFirmas[0].fechacreadofirma; RaisePropertyChanged("Fechacreadofirma");
                Urlfirma = ListadoFirmas[0].urlfirma; RaisePropertyChanged("Urlfirma");
                Logofirma = ListadoFirmas[0].logofirma; RaisePropertyChanged("Logofirma");
                Estadofirma = ListadoFirmas[0].estadofirma; RaisePropertyChanged("Estadofirma");
                /*Recuperamos la foto*/
                #region foto
                try
                {
                    byte[] blob = Logofirma;
                    MemoryStream stream = new MemoryStream();
                    stream.Write(blob, 0, blob.Length);
                    stream.Position = 0;
                    System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();

                    String Ubicacion = Path.Combine(Path.GetTempPath(), "SaveFoto.Bmp"); //Path.GetTempFileName(); 
                    if (!File.Exists(Ubicacion))
                        //File.Delete(Ubicacion);
                        img.Save(Ubicacion, System.Drawing.Imaging.ImageFormat.Bmp);

                    strNombre = "SaveFoto.Bmp";
                    imagenNombre = Ubicacion;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    LaFoto.SetValue(Image.SourceProperty, isc.ConvertFromString(imagenNombre));

                    MyImagenFirma = LaFoto; RaisePropertyChanged("MyImagenFirma");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al recuperar la imagen o logotipo", "Recuperacion imagen", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                #endregion

                //UsuariosListado = Tpersh;
                //SelectedRepresentanteLegal =



                //Control de botones y campos
                HabilitartxtNombreFirma = false;
                HabilitartxtNoCVPV = false;
                HabilitarRepresentanteLegal = false;
                HabilitarComboPaises = false;
                HabilitarDepartamento = false;
                HabilitarMunicipio = false;
                HabilitarDireccion = false;
                HabilitarPaginaWeb = false;

                HabilitarBtnNuevo = false;
                HabilitarBtnModificar = true;
                HabilitarBtnCancelar = true;
                HabilitarBtnLogo = false;
                HabilitarBtnGuardar = false;

            }
            else
            {
                MessageBox.Show("No se han introducido los datos de la firma. Es obligatorio introducirlos, antes de generar documentacion de auditoria.", "Mucha Atencion !!!", MessageBoxButton.OK, MessageBoxImage.Stop);
                HabilitarBtnNuevo = true;
            }
        }
        /*************************************************************************************************************************/
        private void inicializarListados()
        {
            ObservableCollection<UsuariosVM> _usuarios = new ObservableCollection<UsuariosVM>();
            try
            {
                List<usuariospersonas> usuariosy;
                using (db = new SGPTEntidades())
                {
                    ListadoTipoTelefono = (from t in db.tipostelefonos orderby t.idtt select t).ToList(); // .ToList();
                    RaisePropertyChanged("ListadoTipoTelefono");
                    ListadoPaises = (from p in db.paises orderby p.idpais select p).ToList();
                    RaisePropertyChanged("ListadoPaises");

                    //ListadoDepartamentos = (from d in db.departamentos orderby d.iddepartamento select d).ToList();
                    //ListadoMunicipios = (from m in db.municipios orderby m.idmunicipio select m).ToList();

                    usuariosy = (from u in db.usuarios
                                 join p in db.personas
                                 on u.idduipersona equals p.idduipersona
                                 orderby p.nombrespersona
                                 select new usuariospersonas
                                 {
                                     #region
                                     idusuario = u.idusuario,
                                     //idpista = (int)u.idpista,
                                     usuidusuario = (int)(u.usuidusuario),
                                     idrol = (int)(u.idrol),
                                     //fecharegistrousuario = u.fecharegistrousuario,
                                     //fechadebaja = (u.fechadebaja),
                                     //fechacontratacion = (u.fechacontratacion),
                                     //nickusuariousuario = u.nickusuariousuario,
                                     //contraseniausuario = u.contraseniausuario,
                                     //inicialesusuario = u.inicialesusuario,
                                     //respuestapistausuario = u.respuestapistausuario,
                                     //numerocvpausuario = u.numerocvpausuario,
                                     //fechacvpausuario = (u.fechacvpausuario),
                                     estadousuario = u.estadousuario,
                                     idduipersona = p.idduipersona,
                                     //nombrespersona = p.nombrespersona,
                                     //apellidospersona = p.apellidospersona,
                                     nombreCompleto=p.nombrespersona+", "+p.apellidospersona,
                                     sexopersona = p.sexopersona,
                                     direccionpersona = p.direccionpersona,
                                     //noafppersona = p.noafppersona,
                                     //noissspersona = p.noissspersona,
                                     //nitpersona = p.nitpersona,
                                     estadopersona = p.estadopersona,
                                     //correos = (from c in db.correos where c.idduipersona == p.idduipersona && c.estadocorreo == "A" orderby c.idcorreo select c).ToList(),
                                     //telefonos = (from t in db.telefonos where t.idduipersona == p.idduipersona && t.estadotelefono == "A" orderby t.idtt select t).ToList()
                                     #endregion
                                 }).ToList();
                }
                foreach (usuariospersonas usua in usuariosy)
                {

                    //usua.nombreCompleto = usua.nombrespersona + " " + usua.apellidospersona;
                    _usuarios.Add(new UsuariosVM { TheUsuariosPersonas = usua });
                    UsuariosListados.Add(new UsuariosVM {TheUsuariosPersonas = usua });
                }
                UsuariosListado = _usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error critico al recuperar los datos de los usuarios. Notifique a soporte tecnico acerca de este error. " + ex, "Error critico.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            RaisePropertyChanged("UsuariosListado");
            //ThrobberVisible = Visibility.Collapsed;
        }
        /**************************************************************************************************************************/
        /*Comandos para el tab Firma*/
        Image myImagenFirma;
        public Image MyImagenFirma
        {
            get { return myImagenFirma; }
            set { myImagenFirma = value; RaisePropertyChanged("MyImagenFirma"); }
        }

        #region
        public ICommand _cmdLogoFirma_Click;
        public ICommand cmdLogoFirma_Click { get { return _cmdLogoFirma_Click ?? (_cmdLogoFirma_Click = new CommandHandler(() => MycmdLogoFirma(), _canExecute)); } }

        public ICommand _cmdNuevoFirma_Click;
        public ICommand cmdNuevoFirma_Click { get { return _cmdNuevoFirma_Click ?? (_cmdNuevoFirma_Click = new CommandHandler(() => MycmdNuevoFirma(), _canExecute)); } }

        public ICommand _cmdModificarFirma_Click;
        public ICommand cmdModificarFirma_Click { get { return _cmdModificarFirma_Click ?? (_cmdModificarFirma_Click = new CommandHandler(() => MycmdModificarFirma_Click(), _canExecute)); } }



        public ICommand _cmdGuardarFirma_Click;
        public ICommand cmdGuardarFirma_Click { get { return _cmdGuardarFirma_Click ?? (_cmdGuardarFirma_Click = new CommandHandler(() => MycmdGuardarFirma(), _canExecute)); } }

        public ICommand _cmdCancelarFirma_Click;
        public ICommand cmdCancelarFirma_Click { get { return _cmdCancelarFirma_Click ?? (_cmdCancelarFirma_Click = new CommandHandler(() => MycmdCancelarFirma(), _canExecute)); } }

        private Image LaFoto = new Image();
        private void MycmdLogoFirma()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); //Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Imagen Firma (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.FilterIndex = 1;
                if (true == fldlg.ShowDialog())
                {
                    strNombre = fldlg.SafeFileName;
                    imagenNombre = fldlg.FileName;
                    ImageSourceConverter isc = new ImageSourceConverter();
                    LaFoto.SetValue(Image.SourceProperty, isc.ConvertFromString(imagenNombre));
                    MyImagenFirma = LaFoto;
                }
                else
                {
                    MessageBox.Show("por favor seleccione una foto desde su disco local");
                }
                //fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void MycmdNuevoFirma()
        {
            this.inicializarListados();
            AccionGuardar = true;
            HabilitartxtNombreFirma = true;
            HabilitartxtNoCVPV = true;
            HabilitarRepresentanteLegal = true;
            HabilitarComboPaises = true;
            HabilitarDepartamento = true;
            HabilitarMunicipio = true;
            HabilitarDireccion = true;
            HabilitarPaginaWeb = true;
            HabilitarTelefonos = true;
            HabilitarCorreos = true;

            HabilitarBtnNuevo = false;
            HabilitarBtnCancelar = true;
            HabilitarBtnLogo = true;
            HabilitarBtnGuardar = true;
            try
            {
                String Ubicacion = Path.Combine(Path.GetTempPath(), "SaveFoto.Bmp");
                if (File.Exists(Ubicacion))
                    File.Delete(Ubicacion);
            }
            catch { }
        }
        /*********************************************************************************************************/
        private void MycmdModificarFirma_Click()
        {
            AccionGuardar = false;
            HabilitartxtNombreFirma = true;
            HabilitartxtNoCVPV = true;
            HabilitarRepresentanteLegal = true;
            HabilitarComboPaises = true;
            HabilitarDepartamento = true;
            HabilitarMunicipio = true;
            HabilitarDireccion = true;
            HabilitarPaginaWeb = true;
            HabilitarTelefonos = true;
            HabilitarCorreos = true;



            HabilitarBtnNuevo = false;
            HabilitarBtnCancelar = true;
            HabilitarBtnLogo = true;
            HabilitarBtnGuardar = true;
        }
        /**************************************************************************************************************/
        private void MycmdGuardarFirma()
        {
            if (SelectedPais != null && SelectedDepartamento != null && SelectedMunicipio != null & Razonsocialfirma != null && SelectedRepresentanteLegal != null)
            {
                #region Incorporando la imagen
                if (imagenNombre != "")
                {
                    FileStream fs = new FileStream(imagenNombre, FileMode.Open, FileAccess.Read);
                    Logofirma = new byte[fs.Length];
                    fs.Read(Logofirma, 0, Convert.ToInt32(fs.Length));
                    fs.Close();
                }
                #endregion

                //firmasModelo firmasModelo = new firmasModelo();
                firma f;
                cliente c = new cliente();
                if (AccionGuardar)
                {
                    f = new firma();
                    f.idfirma = 1;

                    /*vamos a crear un registro "Oficina" en clientes para utilizarlo en los reportes de tiempos cuando son aplicables a trabajos internos*/
                    
                }
                else
                {
                    using (db = new SGPTEntidades())
                    {
                        f = db.firmas.SingleOrDefault(o => o.idfirma == Idfirma);
                    }
                }
                f.iddepartamento = SelectedDepartamento.iddepartamento;
                f.idpais = SelectedPais.idpais;
                f.idmunicipio = SelectedMunicipio.idmunicipio;
                f.idusuario = SelectedRepresentanteLegal.TheUsuariosPersonas.idusuario;
                f.razonsocialfirma = Razonsocialfirma;
                f.representantefirma = Representantefirma;
                f.nitfirma = Nitfirma;
                f.nrcfirma = Nrcfirma;
                f.direccionfirma = Direccionfirma;
                if (String.IsNullOrEmpty(Numerocvpafirma)) Numerocvpafirma = "0";
                f.numerocvpafirma = int.Parse(Numerocvpafirma);
                f.fechainscripcioncvpafirma = "";
                f.fechacreadofirma = "";
                f.urlfirma = Urlfirma;
                f.logofirma = Logofirma;
                f.estadofirma = "A";
                /*Parte del cliente que no es cliente, sino la misma empresa auditora*/
                c.idnitcliente = Nitfirma;
                c.iddepartamento = SelectedDepartamento.iddepartamento;
                c.idpais = SelectedPais.idpais;
                c.idmunicipio = SelectedMunicipio.idmunicipio;
                c.razonsocialcliente = Razonsocialfirma;
                c.nrccliente = Nrcfirma;
                c.direccioncliente = Direccionfirma;
                c.estadocliente = "A";


                if (AccionGuardar)
                {
                    if (ListadoCorreos != null)
                    {
                        f.correos = ListadoCorreos;
                    }
                    if (ListadoTelefonos != null)
                    {
                        f.telefonos = ListadoTelefonos;
                    }
                }

                using (db = new SGPTEntidades())
                {
                    try
                    {
                        if (AccionGuardar)
                        {
                            db.firmas.Add(f);
                            db.SaveChanges();
                            if (db.clientes.Count() == 0)
                            {
                                db.clientes.Add(c);
                                db.SaveChanges();
                            }
                        }
                        else
                        {
                            db.Entry(f).State = EntityState.Modified;
                            db.SaveChanges();

                            if (db.clientes.Count() == 0)
                            {
                                db.clientes.Add(c);
                                db.SaveChanges();
                            }
                        }
                        //Control de botones y campos
                        HabilitartxtNombreFirma = false;
                        HabilitartxtNoCVPV = false;
                        HabilitarRepresentanteLegal = false;
                        HabilitarComboPaises = false;
                        HabilitarDepartamento = false;
                        HabilitarMunicipio = false;
                        HabilitarDireccion = false;
                        HabilitarPaginaWeb = false;

                        HabilitarBtnNuevo = false;
                        HabilitarBtnModificar = true;
                        HabilitarBtnCancelar = true;
                        HabilitarBtnLogo = false;
                        HabilitarBtnGuardar = false;
                        MessageBox.Show("El registro de la firma fue almacenado con éxito", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocurrio un error al guardar la firma. " + ex, "Error en los datos", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Falta informacion");
            }
        }

        /***************************************************************************************************************/
        private void MycmdCancelarFirma()
        {
            #region v
            //carga de datos a los campos.
            //Idfirma = 0;
            //Iddepartamento = 0;
            //Idpais = 0;
            //Idmunicipio = 0;
            //Idusuario = 0;
            //Razonsocialfirma = "";
            //Representantefirma = "";
            //Nitfirma = "";
            //Nrcfirma = "";
            //Direccionfirma = "";
            //Numerocvpafirma = "";
            //Fechainscripcioncvpafirma = "";
            //Fechacreadofirma = "";
            //Urlfirma = "";
            //Logofirma = null;
            //Estadofirma = "";

            MyImagenFirma = null;

            //Control de botones y campos
            HabilitartxtNombreFirma = false;
            HabilitartxtNoCVPV = false;
            HabilitarRepresentanteLegal = false;
            HabilitarComboPaises = false;
            HabilitarDepartamento = false;
            HabilitarMunicipio = false;
            HabilitarDireccion = false;
            HabilitarPaginaWeb = false;

            SelectedRepresentanteLegal = null;
            SelectedPais = null;
            SelectedDepartamento = null;
            SelectedMunicipio = null;

            HabilitarTelefonos = false;
            HabilitarCorreos = false;

            HabilitarBtnNuevo = true;
            HabilitarBtnModificar = false;
            HabilitarBtnCancelar = false;
            HabilitarBtnLogo = false;
            HabilitarBtnGuardar = false;
            MessageBox.Show("No se guardo nada.", "Cancelado", MessageBoxButton.OK, MessageBoxImage.Warning);

            #endregion
        }
        #endregion

        /**************************************************************************************************************/
        /*Gestiona los correos y los telefonos de los usuarios.*/
        #region AgregarCorreos, QuitarCorreos, AgregarTelefono,QuitarTelefono
        public void cmdAgreTelef()
        {

            if (SelectedTipoTelefono != null && TelefonoT.Length >= 8 && TelefonoT.Length <= 9)
            {
                try
                {
                    #region
                    telefono telef = new telefono();
                    telef.idtelefono = 1;
                    telef.idtt = SelectedTipoTelefono.idtt;
                    telef.numerotelefono = TelefonoT;
                    telef.estadotelefono = "A";
                    _telefonos.Add(telef);
                    ListadoTelefonos = _telefonos.ToList();
                    RaisePropertyChanged("ListadoTelefonos");
                    MessageBox.Show("Telefono agregado.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
                    TelefonoT = "";
                    SelectedTipoTelefono = null;
                    RaisePropertyChanged("TelefonoT");
                    if (!AccionGuardar) //Entonces es Editar
                    {
                        //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                        using (db = new SGPTEntidades())
                        {
                            try
                            {
                                db.telefonos.Add(telef);
                                db.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                    }
                    #endregion
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al agregar el telefono. Verifique el campo DUI tenga valor" + ex, "Falta de Datos", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un numero de telefono de 8 digitos, un tipo de telefono, y el numero de DUI.", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void cmdAgreCorreos()
        {
            if (CorreoT != null && CorreoT.Length >= 7 && CorreoT.Length <= 30)
            {
                Random rnd = new Random();
                try
                {
                    #region
                    correo Corre = new correo();
                    Corre.idcorreo = rnd.Next(1, 100);
                    Corre.direccioncorreo = CorreoT;
                    Corre.principalcorreo = CorreoPrincipalChek;
                    Corre.estadocorreo = "A";
                    _correos.Add(Corre);
                    ListadoCorreos = _correos.ToList();
                    MessageBox.Show("Correo agregado.", "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Information);
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
                                MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                            }
                        }
                    }
                    #endregion
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al agregar el Correo. " + ex, "Finalizado.", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un correo valido, verifique el DUI no este vacio", "Falta Informacion", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void cmdQuitCorreos()
        {
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
                            MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }
                _correos.Remove(SelectedCorreoAgregado);
                ListadoCorreos = _correos.ToList();
                RaisePropertyChanged("");
            }
        }

        private void cmdQuitTelefono()
        {
            if (SelectedTelefonoAgregado != null)
            {

                if (!AccionGuardar) //Entonces es Editar
                {
                    //-------Si la accion es editar al usuario, los telefonos se guardaran directamente en la base.
                    using (db = new SGPTEntidades())
                    {
                        try
                        {
                            SelectedTelefonoAgregado.estadotelefono = "B"; //le cambiamos el estado a Borrado logico.
                            db.Entry(SelectedTelefonoAgregado).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ocurrio un error al actualizar" + ex, "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
                        }
                    }
                }
                _telefonos.Remove(SelectedTelefonoAgregado);
                ListadoTelefonos = _telefonos.ToList();
                RaisePropertyChanged("");
            }

        }
        #endregion

    }
}