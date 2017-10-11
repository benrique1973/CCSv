using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages.Administracion.Usuario;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Messages.Navegacion.PDF;
using SGPTWpf.Model;
using SGPTWpf.Model.Menus.Herramientas;
using SGPTWpf.Model.Modelo;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTWpf.ViewModel.Herramientas
{
    public sealed class NormativaViewModel : ViewModeloBase
    {
        #region Propiedades privadas de control

        private MetroDialogSettings configuracionDialogo;

        #region token

        private string _token;
        private string token
        {
            get { return _token; }
            set { _token = value; }
        }

        #endregion

        #region idln
        //Permite mantener el control del tipo de normativa seleccionada en el menu
        private int? _idln;
        private int? idln
        {
            get { return _idln; }
            set { _idln = value; }
        }

        #endregion

        

        //Permite conocer cual es el menu en que se encuentra.

        #region origenNormas

        private bool _origenNormas;
        private bool origenNormas
        {
            get { return _origenNormas; }
            set { _origenNormas = value; }
        }

        #endregion

        #region tokenRecepcionPrincipal

        private string _tokenRecepcionPrincipal;
        private string tokenRecepcionPrincipal
        {
            get { return _tokenRecepcionPrincipal; }
            set { _tokenRecepcionPrincipal = value; }
        }

        #endregion

        #region tokeNormativaDatos

        private string _tokeNormativaDatos;
        private string tokeNormativaDatos
        {
            get { return _tokeNormativaDatos; }
            set { _tokeNormativaDatos = value; }
        }

        #endregion

        #region Properties : cursorWindow

        public const string cursorWindowPropertyName = "cursorWindow";

        private Cursor _cursorWindow;

        public Cursor cursorWindow
        {
            get
            {
                return _cursorWindow;
            }

            set
            {
                if (_cursorWindow == value)
                {
                    return;
                }

                _cursorWindow = value;
                RaisePropertyChanged(cursorWindowPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentUsuario usuario

        public const string currentUsuarioPropertyName = "currentUsuario";

        private UsuarioModelo _currentUsuario;

        public UsuarioModelo currentUsuario
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

        #region Visibilidad de  botones

        #region visibilidadMCrear

        public const string visibilidadMCrearPropertyName = "visibilidadMCrear";

        private Visibility _visibilidadMCrear = Visibility.Collapsed;

        public Visibility visibilidadMCrear
        {
            get
            {
                return _visibilidadMCrear;
            }

            set
            {
                if (_visibilidadMCrear == value)
                {
                    return;
                }

                _visibilidadMCrear = value;
                RaisePropertyChanged(visibilidadMCrearPropertyName);
            }
        }

        #endregion

        #region visibilidadMEditar

        public const string visibilidadMEditarPropertyName = "visibilidadMEditar";

        private Visibility _visibilidadMEditar = Visibility.Collapsed;

        public Visibility visibilidadMEditar
        {
            get
            {
                return _visibilidadMEditar;
            }

            set
            {
                if (_visibilidadMEditar == value)
                {
                    return;
                }

                _visibilidadMEditar = value;
                RaisePropertyChanged(visibilidadMEditarPropertyName);
            }
        }

        #endregion

        #region visibilidadMReferenciar

        public const string visibilidadMReferenciarPropertyName = "visibilidadMReferenciar";

        private Visibility _visibilidadMReferenciar = Visibility.Collapsed;

        public Visibility visibilidadMReferenciar
        {
            get
            {
                return _visibilidadMReferenciar;
            }

            set
            {
                if (_visibilidadMReferenciar == value)
                {
                    return;
                }

                _visibilidadMReferenciar = value;
                RaisePropertyChanged(visibilidadMReferenciarPropertyName);
            }
        }

        #endregion

        #region visibilidadMCerrar

        public const string visibilidadMCerrarPropertyName = "visibilidadMCerrar";

        private Visibility _visibilidadMCerrar = Visibility.Collapsed;

        public Visibility visibilidadMCerrar
        {
            get
            {
                return _visibilidadMCerrar;
            }

            set
            {
                if (_visibilidadMCerrar == value)
                {
                    return;
                }

                _visibilidadMCerrar = value;
                RaisePropertyChanged(visibilidadMCerrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMSupervisar

        public const string visibilidadMSupervisarPropertyName = "visibilidadMSupervisar";

        private Visibility _visibilidadMSupervisar = Visibility.Collapsed;

        public Visibility visibilidadMSupervisar
        {
            get
            {
                return _visibilidadMSupervisar;
            }

            set
            {
                if (_visibilidadMSupervisar == value)
                {
                    return;
                }

                _visibilidadMSupervisar = value;
                RaisePropertyChanged(visibilidadMSupervisarPropertyName);
            }
        }

        #endregion

        #region visibilidadMAprobar

        public const string visibilidadMAprobarPropertyName = "visibilidadMAprobar";

        private Visibility _visibilidadMAprobar = Visibility.Collapsed;

        public Visibility visibilidadMAprobar
        {
            get
            {
                return _visibilidadMAprobar;
            }

            set
            {
                if (_visibilidadMAprobar == value)
                {
                    return;
                }

                _visibilidadMAprobar = value;
                RaisePropertyChanged(visibilidadMAprobarPropertyName);
            }
        }

        #endregion

        #region visibilidadMBorrar

        public const string visibilidadMBorrarPropertyName = "visibilidadMBorrar";

        private Visibility _visibilidadMBorrar = Visibility.Collapsed;

        public Visibility visibilidadMBorrar
        {
            get
            {
                return _visibilidadMBorrar;
            }

            set
            {
                if (_visibilidadMBorrar == value)
                {
                    return;
                }

                _visibilidadMBorrar = value;
                RaisePropertyChanged(visibilidadMBorrarPropertyName);
            }
        }

        #endregion

        #region visibilidadMConsulta

        public const string visibilidadMConsultaPropertyName = "visibilidadMConsulta";

        private Visibility _visibilidadMConsulta = Visibility.Collapsed;

        public Visibility visibilidadMConsulta
        {
            get
            {
                return _visibilidadMConsulta;
            }

            set
            {
                if (_visibilidadMConsulta == value)
                {
                    return;
                }

                _visibilidadMConsulta = value;
                RaisePropertyChanged(visibilidadMConsultaPropertyName);
            }
        }

        #endregion

        #region visibilidadMDetalle

        public const string visibilidadMDetallePropertyName = "visibilidadMDetalle";

        private Visibility _visibilidadMDetalle = Visibility.Collapsed;

        public Visibility visibilidadMDetalle
        {
            get
            {
                return _visibilidadMDetalle;
            }

            set
            {
                if (_visibilidadMDetalle == value)
                {
                    return;
                }

                _visibilidadMDetalle = value;
                RaisePropertyChanged(visibilidadMDetallePropertyName);
            }
        }

        #endregion

        #region visibilidadMVista

        public const string visibilidadMVistaPropertyName = "visibilidadMVista";

        private Visibility _visibilidadMVista = Visibility.Collapsed;

        public Visibility visibilidadMVista
        {
            get
            {
                return _visibilidadMVista;
            }

            set
            {
                if (_visibilidadMVista == value)
                {
                    return;
                }

                _visibilidadMVista = value;
                RaisePropertyChanged(visibilidadMVistaPropertyName);
            }
        }

        #endregion

        #region visibilidadMRegresar

        public const string visibilidadMRegresarPropertyName = "visibilidadMRegresar";

        private Visibility _visibilidadMRegresar = Visibility.Hidden;

        public Visibility visibilidadMRegresar
        {
            get
            {
                return _visibilidadMRegresar;
            }

            set
            {
                if (_visibilidadMRegresar == value)
                {
                    return;
                }

                _visibilidadMRegresar = value;
                RaisePropertyChanged(visibilidadMRegresarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImportar

        public const string visibilidadMImportarPropertyName = "visibilidadMImportar";

        private Visibility _visibilidadMImportar = Visibility.Collapsed;

        public Visibility visibilidadMImportar
        {
            get
            {
                return _visibilidadMImportar;
            }

            set
            {
                if (_visibilidadMImportar == value)
                {
                    return;
                }

                _visibilidadMImportar = value;
                RaisePropertyChanged(visibilidadMImportarPropertyName);
            }
        }

        #endregion

        #region visibilidadMImprimir

        public const string visibilidadMImprimirPropertyName = "visibilidadMImprimir";

        private Visibility _visibilidadMImprimir = Visibility.Hidden;

        public Visibility visibilidadMImprimir
        {
            get
            {
                return _visibilidadMImprimir;
            }

            set
            {
                if (_visibilidadMImprimir == value)
                {
                    return;
                }

                _visibilidadMImprimir = value;
                RaisePropertyChanged(visibilidadMImprimirPropertyName);
            }
        }

        #endregion

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region menuElegido

        private string _menuElegido;
        private string menuElegido
        {
            get { return _menuElegido; }
            set { _menuElegido = value; }
        }

        #endregion

        #endregion

        #region ViewModel Properties

        #region Normas

        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista

        public const string ListaPropertyName = "Lista";

        private ObservableCollection<NormativaModelo> _Lista;

        public ObservableCollection<NormativaModelo> Lista
        {
            get
            {
                return _Lista;
            }

            set
            {
                if (_Lista == value) return;

                _Lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPropertyName);
            }
        }

        #endregion

        #region Descripcion de norma

        public const string descripcionNormaPropertyName = "descripcionNorma";

        private string _descripcionNorma = string.Empty;

        public string descripcionNorma
        {
            get
            {
                return _descripcionNorma;
            }

            set
            {
                if (_descripcionNorma == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(descripcionNormaPropertyName);
            }
        }

        #endregion

        #region  Primary key

        public const string idPropertyName = "id";

        private int _id = 0;

        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(idPropertyName);
            }
        }

        #endregion

        #region Sistema

        public const string sistemaPropertyName = "sistema";

        private bool _sistema = false;

        public bool sistema
        {
            get
            {
                return _sistema;
            }

            set
            {
                if (_sistema == value)
                {
                    return;
                }

                _sistema = value;
                RaisePropertyChanged(sistemaPropertyName);
            }
        }

        #endregion

        #region archivoBin

        public const string archivoBinPropertyName = "archivoBin";

        private byte[] _archivoBin = null;

        public byte[] archivoBin
        {
            get
            {
                return _archivoBin;
            }

            set
            {
                if (_archivoBin == value)
                {
                    return;
                }

                _archivoBin = value;
                RaisePropertyChanged(archivoBinPropertyName);
            }
        }

        #endregion

        #region Estado
        public const string estadoPropertyName = "estado";

        private string _estado = string.Empty;

        public string estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(estadoPropertyName);
            }
        }
        #endregion

        #region Entidad en uso


        #endregion


        #endregion

        #region MainModel
        //Cambiarlo
        private MainModel _mainModel = null;

        public MainModel MainModel
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



        #endregion


        #region ViewModel Properties : accesibilidadTab

        public const string accesibilidadTabPropertyName = "AccesibilidadTab";

        private bool _accesibilidadTab = true;

        public bool accesibilidadTab
        {
            get
            {
                return _accesibilidadTab;
            }

            set
            {
                if (_accesibilidadTab == value)
                {
                    return;
                }

                _accesibilidadTab = value;
                RaisePropertyChanged(accesibilidadTabPropertyName);
            }
        }

        #endregion

        #region Vistas SGPT

        #region ViewModel Properties : Vistas

        #region Prueba Listas

        public const string ListaVistaPropertyName = "ListaVista";

        private ObservableCollection<LegalNormaModelo> _ListaVista;

        public ObservableCollection<LegalNormaModelo> ListaVista
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

        #region ViewModel Property : currentEntidadItem

        public const string currentEntidadItemPropertyName = "currentEntidadItem";

        private LegalNormaModelo _currentEntidadItem;

        public LegalNormaModelo currentEntidadItem
        {
            get
            {
                return _currentEntidadItem;
            }

            set
            {
                if (_currentEntidadItem == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadItem = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadItemPropertyName);
            }
        }

        #endregion


        #region ViewModel Property : currentEntidadNormativa

        public const string currentEntidadNormativaPropertyName = "currentEntidadNormativa";

        private NormativaModelo _currentEntidadNormativa;

        public NormativaModelo currentEntidadNormativa
        {
            get
            {
                return _currentEntidadNormativa;
            }

            set
            {
                if (_currentEntidadNormativa == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadNormativa = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadNormativaPropertyName);
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

        #region Opciones
        public const string ListaPrincipalPropertyName = "ListaNavegacion";

        private List<MenuLegalNorma> _ListaPrincipal;
        public List<MenuLegalNorma> ListaPrincipal
        {
            get
            {
                return _ListaPrincipal;
            }

            set
            {
                if (_ListaPrincipal == value) return;

                _ListaPrincipal = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(ListaPrincipalPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel PropertiesPrivadas

        private DialogCoordinator dlg;

        #endregion

        #endregion


        private void ControlPrincipalUsuarioValidadoMensaje(PrincipalUsuarioValidadoMensaje principalUsuarioValidadoMensaje)
        {
            //Recibe al usuario que se ha validado
            currentUsuario = principalUsuarioValidadoMensaje.usuarioModelo;
            inicializacionTerminada();
            Messenger.Default.Unregister<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal);
        }

        public NormativaViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;
            dlg = new DialogCoordinator();
            ListaVista = new ObservableCollection<LegalNormaModelo>(LegalNormaModelo.GetAll());
            List<MenuLegalNorma> opcion = new List<MenuLegalNorma>
            { new MenuLegalNorma() { ViewDisplay = "" }};//Es generico el view display es cualquier string

            switch (origen)
                { 
                case "Normas":
                    _origenLlamada = origen;
                    _menuElegido = "Normas";
                    RegistrarComandos();
                    _token = "MenuPrincipal";
                    _idln = 0;
                    _origenNormas = false;
                    _cursorWindow = Cursors.Hand;
                    _tokenRecepcionPrincipal = "Normas";
                    ListaPrincipal = opcion;
                    currentEntidadNormativa = NormativaModelo.Clear(currentEntidadNormativa);
                    currentEntidadItem = LegalNormaModelo.Clear(currentEntidadItem);
                    //Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
                    Messenger.Default.Register<HerramientasMensajesInicio>(this, (herramientasMensajesInicio) => ControlHerramientasMensajesInicio(herramientasMensajesInicio));
                    Messenger.Default.Register<SeleccionRadioButtonHerramientas>(this, (seleccionRadioButtonHerramientas) => ControlSeleccionRadioButtonHerramientas(seleccionRadioButtonHerramientas));
                    //Mensaje para actualizar el listado
                    Messenger.Default.Register<NormaLegalCrearActualizarMensaje>(this, (normaLegalCrearActualizarMensaje) => ControlNormaLegalCrearActualizarMensaje(normaLegalCrearActualizarMensaje));
                    Messenger.Default.Register<NavegacionSgpt>(this, token, (navegacionMenu) => ControlNavegacionMenuMensaje(navegacionMenu));
                    //Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal, (herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
                    Messenger.Default.Register<PrincipalUsuarioValidadoMensaje>(this, tokenRecepcionPrincipal, (principalUsuarioValidadoMensaje) => ControlPrincipalUsuarioValidadoMensaje(principalUsuarioValidadoMensaje));

                    _tokeNormativaDatos = "finCargaNormativaVista";//Para determinar que se termino la carga
                    break;
                case "Normativa" :
                    menuElegido = "Herramientas";
                    _token = "MenuPrincipal";
                    _idln = 0;
                    _origenNormas = false;
                    RegistrarComandos();
                    _cursorWindow = Cursors.Hand;
                    _tokenRecepcionPrincipal = "Normativa" + "Herramientas";
                    ListaPrincipal = opcion;
                    currentEntidadNormativa = NormativaModelo.Clear(currentEntidadNormativa);
                    currentEntidadItem = LegalNormaModelo.Clear(currentEntidadItem);
                    //Messenger.Default.Register<TabItemMensaje>(this, (tabItemMensaje) => ControlTabitemMensaje(tabItemMensaje));
                    Messenger.Default.Register<HerramientasMensajesInicio>(this, (herramientasMensajesInicio) => ControlHerramientasMensajesInicio(herramientasMensajesInicio));
                    Messenger.Default.Register<SeleccionRadioButtonHerramientas>(this, (seleccionRadioButtonHerramientas) => ControlSeleccionRadioButtonHerramientas(seleccionRadioButtonHerramientas));
                    //Mensaje para actualizar el listado
                    Messenger.Default.Register<NormaLegalCrearActualizarMensaje>(this, (normaLegalCrearActualizarMensaje) => ControlNormaLegalCrearActualizarMensaje(normaLegalCrearActualizarMensaje));
                    Messenger.Default.Register<NavegacionSgpt>(this, token, (navegacionMenu) => ControlNavegacionMenuMensaje(navegacionMenu));
                    Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal, (herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
                    _tokeNormativaDatos = "finCargaNormativaVista";//Para determinar que se termino la carga
                    break;
            }
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            #region  menu

            _visibilidadMCrear = Visibility.Visible;
            _visibilidadMEditar = Visibility.Visible;
            _visibilidadMBorrar = Visibility.Visible;
            _visibilidadMConsulta = Visibility.Visible;
            _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
            _visibilidadMRegresar = Visibility.Collapsed;
            _visibilidadMVista = Visibility.Collapsed;
            _visibilidadMImportar = Visibility.Collapsed;
            _visibilidadMDetalle = Visibility.Collapsed;

            _visibilidadMCerrar = Visibility.Collapsed;
            _visibilidadMSupervisar = Visibility.Collapsed;
            _visibilidadMAprobar = Visibility.Collapsed;
            _visibilidadMImprimir = Visibility.Collapsed;
            #endregion

        }

        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 10,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }

        private void permisos()
        {
            if (currentUsuario.listaPermisos != null)
            {
                try
                {
                    if (currentUsuario.listaPermisos.Count(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()) > 0)
                    {
                        #region  permisos asignados

                        permisosrolesusuario permisosAsignados = currentUsuario.listaPermisos.Single(x => x.nombreopcionpru.ToUpper() == origenLlamada.ToUpper()
                        && x.menupru.ToUpper() == menuElegido.ToUpper());

                        if (permisosAsignados != null)
                        {


                            if (permisosAsignados.crearpru)
                            {
                                _visibilidadMCrear = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMCrear = Visibility.Collapsed;
                            }
                            if (permisosAsignados.editarpru)
                            {
                                _visibilidadMEditar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMEditar = Visibility.Collapsed;
                            }
                            if (permisosAsignados.consultarpru)
                            {
                                _visibilidadMConsulta = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMConsulta = Visibility.Collapsed;
                            }
                            if (permisosAsignados.eliminarpru)
                            {
                                _visibilidadMBorrar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMBorrar = Visibility.Collapsed;
                            }
                            if (permisosAsignados.impresionpru)
                            {
                                _visibilidadMVista = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMVista = Visibility.Collapsed;
                            }
                            if (permisosAsignados.crearpru)
                            {
                                _visibilidadMImportar = Visibility.Visible;
                            }
                            else
                            {
                                _visibilidadMImportar = Visibility.Collapsed;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error en opción y la base de datos de la entidad\nRevise la opción programada");
                        }
                        #endregion fin de region de permisos
                    }
                    else
                    {
                        MessageBox.Show("Error en opción y la base de datos\nRevise la opción programada");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al identificar los permisos\nRevise la opción programada");
                    #region  menu
                    _visibilidadMCrear = Visibility.Collapsed;
                    _visibilidadMEditar = Visibility.Collapsed;
                    _visibilidadMBorrar = Visibility.Collapsed;
                    _visibilidadMConsulta = Visibility.Collapsed;
                    _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                    _visibilidadMRegresar = Visibility.Collapsed;
                    _visibilidadMVista = Visibility.Visible;
                    _visibilidadMImportar = Visibility.Visible;
                    _visibilidadMDetalle = Visibility.Collapsed;

                    _visibilidadMCerrar = Visibility.Collapsed;
                    _visibilidadMSupervisar = Visibility.Collapsed;
                    _visibilidadMAprobar = Visibility.Collapsed;
                    _visibilidadMImprimir = Visibility.Collapsed;
                    #endregion
                }
            }
            else
            {
                #region  menu
                MessageBox.Show("No están definidos los permisos\nRevise los permisos del usuario");
                _visibilidadMCrear = Visibility.Collapsed;
                _visibilidadMEditar = Visibility.Collapsed;
                _visibilidadMBorrar = Visibility.Collapsed;
                _visibilidadMConsulta = Visibility.Collapsed;
                _visibilidadMReferenciar = Visibility.Collapsed;//Pendiente
                _visibilidadMRegresar = Visibility.Collapsed;
                _visibilidadMVista = Visibility.Collapsed;
                _visibilidadMImportar = Visibility.Collapsed;
                _visibilidadMDetalle = Visibility.Collapsed;

                _visibilidadMCerrar = Visibility.Collapsed;
                _visibilidadMSupervisar = Visibility.Collapsed;
                _visibilidadMAprobar = Visibility.Collapsed;
                _visibilidadMImprimir = Visibility.Collapsed;
                #endregion
            }

        }


        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
        {
            currentUsuario = herramientaUsuarioValidadoMensaje.usuarioModeloMensaje;
            permisos();
            Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
            inicializacionTerminada();
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenRecepcionPrincipal);
        }

        private void ControlNavegacionMenuMensaje(NavegacionSgpt navegacionMenu)
        {
            if (navegacionMenu.ViewType.Name == "NormasView")
            {
                //Se identifica que es solo consulta de normativa
                origenNormas = true;
                if (Lista == null)
                {
                    //Nada la lista es vacia
                }
                else
                {
                    Lista.Clear();
                }
                currentEntidadItem = LegalNormaModelo.Clear(currentEntidadItem);
                currentEntidadNormativa = NormativaModelo.Clear(currentEntidadNormativa);
            }
            else
            {
                origenNormas = false;
            }
        }

        private  void ControlNormaLegalCrearActualizarMensaje(NormaLegalCrearActualizarMensaje normaLegalCrearActualizarMensaje)
        {
            if (normaLegalCrearActualizarMensaje.actualizar)
                try
                {
                    if (Lista == null)
                    {
                        Lista = new ObservableCollection<NormativaModelo>(NormativaModelo.GetAllEncabezados(idln));
                    }
                    else
                    {
                        Lista.Clear();
                        Lista = new ObservableCollection<NormativaModelo>(NormativaModelo.GetAllEncabezados(idln));
                    }
                }
                catch (Exception e)
                {
                    if (e.Source != null)
                    {
                        dlg.ShowMessageAsync(this, "Problema de comunicacion en la inserción " + e.Message, "");
                    }
                }
        }


        private void ControlSeleccionRadioButtonHerramientas(SeleccionRadioButtonHerramientas seleccionRadioButtonHerramientas)
        {
            for (int i = 0; i < ListaVista.Count; i++)
            {
                if (ListaVista[i].descripcion == seleccionRadioButtonHerramientas.seleccionNormativa)
                {
                    currentEntidadItem = ListaVista[i];
                    idln = ListaVista[i].id;//Almacena el tipo de normativa seleccionada
                    i = ListaVista.Count + 1;
                }
            }
            Ejecutar();
        }

        private void ControlHerramientasMensajesInicio(HerramientasMensajesInicio herramientasMensajesInicio)
        {
            if (herramientasMensajesInicio.inicio)
            {
                Lista= new ObservableCollection<NormativaModelo>();
                currentEntidadItem =new LegalNormaModelo();
                currentEntidadNormativa = new NormativaModelo ();
            }
        }


        #region ShowWindowCommand
        
        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            VerVistaCommand = new RelayCommand(Ejecutar);
            VerPDFCommand = new RelayCommand(EjecutarPDF);

        }

        #endregion

        #region ViewModel Commands

        public RelayCommand VerPDFCommand { get; set; }
        public RelayCommand VerVistaCommand { get; set; }
        //public RelayCommand<LegalNormaModelo> SelectionChangedCommand { get; set; }
        #endregion

        #region Redireccion de comandos

        public async void EjecutarPDF()
        {
            //await dlg.ShowMessageAsync(this, "Llamar al PDF", "");
            if (!(string.IsNullOrEmpty(currentEntidadNormativa.ToString())))
            {
                Messenger.Default.Register<ComandoTerminado>(this, tokeNormativaDatos, (comandoTerminado) => ControlComandoTerminado(comandoTerminado));
                cursorWindow = Cursors.Wait;
                //Mandar el archivo a a vista
                enviarNormativaPDFMensaje();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Error el binario que quiere enviar Normativa es nulo ", "");
            }
        }

        public async void Ejecutar()
        {

            if (currentEntidadItem == null)
            {
            }
            else
            {
                if (origenNormas)
                {
                    ListaPrincipal[0].NavigateExecuteNormas();//Ejecuta el comando generico
                }
                else
                {
                    ListaPrincipal[0].NavigateExecute();//Ejecuta el comando generico
                }
                if (!(NormativaModelo.ContarRegistros(idln) == 0))
                {
                    try
                    {
                        Lista = new ObservableCollection<NormativaModelo>(NormativaModelo.GetAllEncabezados(idln));
                    }
                    catch (Exception e)
                    {
                        if (e.Source != null)
                        {
                            //await dlg.ShowMessageAsync(this, "Problema de comunicacion " + e.Message, "");
                        }
                    }
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No hay registros de este tipo", "");
                    if (Lista == null)
                    {
                        //Nada la lista es vacia
                    }
                    else
                    {
                        Lista.Clear();
                    }
                    currentEntidadNormativa = NormativaModelo.Clear(currentEntidadNormativa);
                    enviarNormativaVaciaPDFMensaje();
                }
            }
            enviarNormaLegalSeleccionMensaje();
        }

        #endregion
        #endregion

        public void enviarNormativaPDFMensaje()
        {
            //Se crea el mensaje
            NormativaPDFmensaje elemento = new NormativaPDFmensaje();
            elemento.idNormativaModeloPdfMensaje = currentEntidadNormativa.id;//Guardo el mensaje
            Messenger.Default.Send(elemento);
        }
        public void enviarNormativaVaciaPDFMensaje()
        {
            //Se crea el mensaje
            NormativaPDFmensaje elemento = new NormativaPDFmensaje();
            elemento.idNormativaModeloPdfMensaje = -1;//Para saber que esta vacia
            Messenger.Default.Send(elemento);
        }

        public void enviarNormaLegalSeleccionMensaje()
        {
            //Se crea el mensaje
            NormaLegalSeleccionMensaje elemento = new NormaLegalSeleccionMensaje();
            elemento.idln = idln;//Para saber que esta vacia
            elemento.usuarioValidadoMensaje = currentUsuario;
            elemento.listaMensaje = Lista;
            Messenger.Default.Send(elemento);
        }

        #region Normas

        #region Descripcion de cuentas

        public const string descripcionPropertyName = "descripcion";

        private string _descripcion = string.Empty;

        public string descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(descripcionPropertyName);
            }
        }
        #endregion

        private void ControlComandoTerminado(ComandoTerminado comandoTerminado)
        {
            //Termino el proceso de  carga de  datos
            cursorWindow = comandoTerminado.cursorWindow;
            Messenger.Default.Unregister<ComandoTerminado>(this, tokeNormativaDatos);
            //currentEntidad = new MenuCatalogoModelo();
        }
        #endregion
    }
}