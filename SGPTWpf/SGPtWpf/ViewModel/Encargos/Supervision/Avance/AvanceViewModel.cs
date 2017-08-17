using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Encargos;
using System.Windows.Input;
using SGPTWpf.Messages;
using SGPTWpf.ViewModel;
using System.Threading.Tasks;
using CapaDatos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Avance
{

    public sealed class AvanceViewModel : ViewModeloBase
    {

        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        private readonly IDialogCoordinator _dialogCoordinator;
        public static int Errors { get; set; }//Para controllar los errores de edición

        #region origenLlamada

        private string _origenLlamada;
        private string origenLlamada
        {
            get { return _origenLlamada; }
            set { _origenLlamada = value; }
        }

        #endregion

        #region tablaDetalle

        private string _tablaDetalle;
        private string tablaDetalle
        {
            get { return _tablaDetalle; }
            set { _tablaDetalle = value; }
        }

        #endregion

        #region tokenRecepcionPadre

        private string _tokenRecepcionPadre;
        private string tokenRecepcionPadre
        {
            get { return _tokenRecepcionPadre; }
            set { _tokenRecepcionPadre = value; }
        }

        #endregion

        #region tokenRecepcionHijo

        private string _tokenRecepcionHijo;
        private string tokenRecepcionHijo
        {
            get { return _tokenRecepcionHijo; }
            set { _tokenRecepcionHijo = value; }
        }

        #endregion

        #region tokenRecepcionSubMenu
        private string _tokenRecepcionSubMenu;
        private string tokenRecepcionSubMenu
        {
            get { return _tokenRecepcionSubMenu; }
            set { _tokenRecepcionSubMenu = value; }
        }
        #endregion

        #region tokenEnvioPadre

        private string _tokenEnvioPadre;
        private string tokenEnvioPadre
        {
            get { return _tokenEnvioPadre; }
            set { _tokenEnvioPadre = value; }
        }

        #endregion

        #region comando

        private int _comando;
        private int comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        #endregion

        #region fuenteLlamado //Sirve para diferenciar las fuentas de  la llamada para las vistas
        //0 Sin identificar
        //1 Plan Indices
        //2 Plan Indices detalle
        //3 Documentacion indice
        //4 Documentacion detalle indice

        private int _fuenteLlamado;
        private int fuenteLlamado
        {
            get { return _fuenteLlamado; }
            set { _fuenteLlamado = value; }
        }

        #endregion

        #region idtc //Sirve para diferenciar las fuentas de  la llamada para las vistas
        private int _idtc;
        private int idtc
        {
            get { return _idtc; }
            set { _idtc = value; }
        }

        #endregion

        private DialogCoordinator dlg;

        #endregion

        #region tokenEnvioDatosAHijo

        private string _tokenEnvioDatosAHijo;
        private string tokenEnvioDatosAHijo
        {
            get { return _tokenEnvioDatosAHijo; }
            set { _tokenEnvioDatosAHijo = value; }
        }

        #endregion

        #region tokenEnvioDatosCarga

        private string _tokenEnvioDatosCarga;
        private string tokenEnvioDatosCarga
        {
            get { return _tokenEnvioDatosCarga; }
            set { _tokenEnvioDatosCarga = value; }
        }

        #endregion


        #region tokenRecepcionDatosCarga

        private string _tokenRecepcionDatosCarga;
        private string tokenRecepcionDatosCarga
        {
            get { return _tokenRecepcionDatosCarga; }
            set { _tokenRecepcionDatosCarga = value; }
        }

        #endregion

        #region ViewModel Properties : IsSelected

        public const string IsSelectedPropertyName = "IsSelected";

        private bool _IsSelected;

        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }

            set
            {
                if (_IsSelected == value)
                {
                    return;
                }

                _IsSelected = value;
                RaisePropertyChanged(IsSelectedPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : usuarioModelo usuario

        public const string usuarioModeloPropertyName = "usuarioModelo";

        private UsuarioModelo _usuarioModelo;

        public UsuarioModelo usuarioModelo
        {
            get
            {
                return _usuarioModelo;
            }

            set
            {
                if (_usuarioModelo == value) return;

                _usuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(usuarioModeloPropertyName);
            }
        }

        #endregion

        #region ViewModel Property : currentEncargo

        public const string currentEncargoPropertyName = "currentEncargo";

        private EncargoModelo _currentEncargo;

        public EncargoModelo currentEncargo
        {
            get
            {
                return _currentEncargo;
            }

            set
            {
                if (_currentEncargo == value) return;

                _currentEncargo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEncargoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaPrograma

        public const string listaProgramaPropertyName = "listaPrograma";

        private ObservableCollection<ProgramaModelo> _listaPrograma;

        public ObservableCollection<ProgramaModelo> listaPrograma
        {
            get
            {
                return _listaPrograma;
            }

            set
            {
                if (_listaPrograma == value) return;

                _listaPrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaProgramaPropertyName);
            }
        }

        #endregion

        #region currentEntidadPrograma

        public const string currentEntidadProgramaPropertyName = "currentEntidadPrograma";

        private ProgramaModelo _currentEntidadPrograma;

        public ProgramaModelo currentEntidadPrograma
        {
            get
            {
                return _currentEntidadPrograma;
            }

            set
            {
                if (_currentEntidadPrograma == value) return;

                _currentEntidadPrograma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadProgramaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCuestionarios

        public const string listaCuestionariosPropertyName = "listaCuestionarios";

        private ObservableCollection<ProgramaModelo> _listaCuestionarios;

        public ObservableCollection<ProgramaModelo> listaCuestionarios
        {
            get
            {
                return _listaCuestionarios;
            }

            set
            {
                if (_listaCuestionarios == value) return;

                _listaCuestionarios = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCuestionariosPropertyName);
            }
        }

        #endregion

        #region currentEntidadCuestionario

        public const string currentEntidadCuestionarioPropertyName = "currentEntidadCuestionario";

        private ProgramaModelo _currentEntidadCuestionario;

        public ProgramaModelo currentEntidadCuestionario
        {
            get
            {
                return _currentEntidadCuestionario;
            }

            set
            {
                if (_currentEntidadCuestionario == value) return;

                _currentEntidadCuestionario = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadCuestionarioPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCarpetas

        public const string listaCarpetasPropertyName = "listaCarpetas";

        private ObservableCollection<TipoCarpetaModelo> _listaCarpetas;

        public ObservableCollection<TipoCarpetaModelo> listaCarpetas
        {
            get
            {
                return _listaCarpetas;
            }

            set
            {
                if (_listaCarpetas == value) return;

                _listaCarpetas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCarpetasPropertyName);
            }
        }

        #endregion

        #region currentEntidadCarpetas

        public const string currentEntidadCarpetasPropertyName = "currentEntidadCarpetas";

        private TipoCarpetaModelo _currentEntidadCarpetas;

        public TipoCarpetaModelo currentEntidadCarpetas
        {
            get
            {
                return _currentEntidadCarpetas;
            }

            set
            {
                if (_currentEntidadCarpetas == value) return;

                _currentEntidadCarpetas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadCarpetasPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : listaCedulas

        public const string listaCedulasPropertyName = "listaCedulas";

        private ObservableCollection<CedulaModelo> _listaCedulas;

        public ObservableCollection<CedulaModelo> listaCedulas
        {
            get
            {
                return _listaCedulas;
            }

            set
            {
                if (_listaCedulas == value) return;

                _listaCedulas = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaCedulasPropertyName);
            }
        }

        #endregion

        #region currentEntidadCedula

        public const string currentEntidadCedulaPropertyName = "currentEntidadCedula";

        private CedulaModelo _currentEntidadCedula;

        public CedulaModelo currentEntidadCedula
        {
            get
            {
                return _currentEntidadCedula;
            }

            set
            {
                if (_currentEntidadCedula == value) return;

                _currentEntidadCedula = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadCedulaPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadWindow

        public const string accesibilidadWindowPropertyName = "accesibilidadWindow";

        private bool _accesibilidadWindow;

        public bool accesibilidadWindow
        {
            get
            {
                return _accesibilidadWindow;
            }

            set
            {
                if (_accesibilidadWindow == value)
                {
                    return;
                }

                _accesibilidadWindow = value;
                RaisePropertyChanged(accesibilidadWindowPropertyName);
            }
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


        #region ECMainModel

        private MainModel _mainModel = null;

        public MainModel ECMainModel
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

        #region activarCaptura

        public const string activarCapturaPropertyName = "activarCaptura";

        private bool _activarCaptura;

        public bool activarCaptura
        {
            get
            {
                return _activarCaptura;
            }

            set
            {
                if (_activarCaptura == value)
                {
                    return;
                }

                _activarCaptura = value;
                RaisePropertyChanged(activarCapturaPropertyName);
            }
        }

        public int NumberOfItemsSelected { get; private set; }

        #endregion

        #region ViewModel Public Methods

        #region Constructores

        //Llamado desde planificacion
        public AvanceViewModel()//Caso Encargo/PlanIndice
        {
        }

        //Llamado desde documentacion
        public AvanceViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;
            _tablaDetalle = string.Empty;
            _tokenEnvioPadre = string.Empty;
            _tokenRecepcionSubMenu = string.Empty;

            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };

            switch (origen)
            {
                case "SupervisionAvance":
                    fuenteLlamado = 1;
                    _idtc = 6;//
                    //6;"Hallazgos";"A";TRUE
                    #region tokens

                    _tokenRecepcionPadre = "Consulta de avance" + "Supervision";//Permite captar los mensajes del  menú planificacion, corresponde a Indices

                    _tokenEnvioDatosAHijo = "datosEncargoCedulasAvances";//Para control de los datos que  remite programas a sub-ventanas

                    _tokenRecepcionHijo = "datosEncargoCedulasAvancesController";

                    #endregion

                    _tablaDetalle = "Avance";
                    break;

            }

           _dialogCoordinator = new DialogCoordinator();
            _cursorWindow = Cursors.Hand;//Definición preliminar

            _accesibilidadWindow = false;
            _IsSelected = false;

            _cursorWindow = Cursors.Hand;

            Messenger.Default.Register<EncargosDatosMsj>(this, tokenRecepcionPadre, (recepcionDatos) => ControlRecepcionDatos(recepcionDatos));
            currentEncargo = null;
            _comando = 0;
            dlg = new DialogCoordinator();
            ECMainModel = new MainModel();
            //Messenger.Default.Register<int>(this, tokenRecepcionSubMenu, (detalleTerminado) => ControlVentanaMensaje(detalleTerminado));
        }

        private void ControlRecepcionDatos(EncargosDatosMsj msj)
        {
            usuarioModelo = msj.usuarioModelo;
            currentEncargo = msj.encargoModelo;  //El encargo puede estar cambiando.
            accesibilidadWindow = true;
            _tokenEnvioPadre = msj.tokenRespuesta;
            _tokenRecepcionSubMenu = msj.tokenRespuestaDetalle;
            Messenger.Default.Unregister<EncargosDatosMsj>(this, tokenRecepcionPadre);
            //Verificar que exista el  registro de cedulay en caso  contrario crearlo
            actualizarListaPrograma();
            //await mensajeAutoCerrado("Programas recuperados", "", 1);
            actualizarListaCuestionrios();
            //await mensajeAutoCerrado("Cuestionarios recuperados", "", 1);
            actualizarListaCarpetas();
            //await mensajeAutoCerrado("Carpetas recuperadas", "", 1);
            actualizarListaCedula();
            //await mensajeAutoCerrado("Cédulas recuperadas", "", 1);
            inicializacionTerminada();

        }

        private void actualizarListaPrograma()
        {
            try
            {
                int opcionTipoHerramientaprograma = 1;
                listaPrograma = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(opcionTipoHerramientaprograma, currentEncargo));
                if (origenLlamada != "")
                {
                    ProgramaModelo temporal = new ProgramaModelo();
                    //Obtener el  detalle de cada programa y calcular el el % de avance
                    foreach (ProgramaModelo item in listaPrograma)
                    {
                        //Hasta que este referenciado se da por cerrado el caso
                        temporal = DetalleProgramaModelo.ResumenEjecucion(item.idprograma);
                        //item.indiceEjecucionprograma = DetalleProgramaModelo.IndiceEjecucion(item.idprograma);
                        item.indiceEjecucionprograma = temporal.indiceEjecucionprograma;
                        item.cantidadProcedimientosEjecucion = temporal.cantidadProcedimientosEjecucion;
                        item.cantidadProcedimientosPlan = temporal.cantidadProcedimientosPlan;
                        temporal = new ProgramaModelo();
                        if (item.indiceEjecucionprograma > 0)
                        {
                            //Verificar si no ha cambiado el  estado, debe cambiarlo
                            if (item.etapaprograma == "I")
                            {
                                //Debe cambiarse el  estado
                                ProgramaModelo.UpdateCambiarEstadoByPrograma(item.idprograma);
                                item.descripcionEtapaEncargo = "En proceso";
                            }
                        }
                    }


                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista \n" + e, "");
                }
            }
        }

        private void actualizarListaCuestionrios()
        {
            try
            {
                int opcionTipoHerramientaprograma = 2;
                listaCuestionarios = new ObservableCollection<ProgramaModelo>(ProgramaModelo.GetAllByEncargo(opcionTipoHerramientaprograma, currentEncargo));
                if (origenLlamada != "")
                {
                    ProgramaModelo temporal = new ProgramaModelo();
                    //Obtener el  detalle de cada programa y calcular el el % de avance
                    foreach (ProgramaModelo item in listaCuestionarios)
                    {
                        //Hasta que este referenciado se da por cerrado el caso
                        temporal = DetalleProgramaModelo.ResumenEjecucion(item.idprograma);
                        //item.indiceEjecucionprograma = DetalleProgramaModelo.IndiceEjecucion(item.idprograma);
                        item.indiceEjecucionprograma = temporal.indiceEjecucionprograma;
                        item.cantidadProcedimientosEjecucion = temporal.cantidadProcedimientosEjecucion;
                        item.cantidadProcedimientosPlan = temporal.cantidadProcedimientosPlan;
                        temporal = new ProgramaModelo();
                        if (item.indiceEjecucionprograma > 0)
                        {
                            //Verificar si no ha cambiado el  estado, debe cambiarlo
                            if (item.etapaprograma == "I")
                            {
                                //Debe cambiarse el  estado
                                ProgramaModelo.UpdateCambiarEstadoByPrograma(item.idprograma);
                                item.descripcionEtapaEncargo = "En proceso";
                            }
                        }
                    }


                }
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista \n" + e, "");
                }
            }
        }

        private void actualizarListaCarpetas()
        {
            //guardarlista();
            try
            {
                //Internamenteo consigo el id del sistema contable
                //lista = new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAll(currentEncargo.idencargo));
                listaCarpetas= new ObservableCollection<TipoCarpetaModelo>(TipoCarpetaModelo.GetAllEncargos(currentEncargo.idencargo));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e, "");

                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }

        private void actualizarListaCedula()
        {
            //guardarlista();
            try
            {
                listaCedulas = new ObservableCollection<CedulaModelo>(CedulaModelo.GetAll(currentEncargo));

            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de lista " + e, "");

                }
            }
            //Se manda a la vista actualizada
            ///enviarMensaje();No aplica porque no  se envia  la lista a la vista
        }

        #endregion


        #endregion


        #region ViewModel Private Methods





        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        public void inicializacionTerminada()
        {
            //Se crea el mensaje
            ComandoTerminado cursor = new ComandoTerminado();
            cursor.cursorWindow = Cursors.Hand;
            Messenger.Default.Send<ComandoTerminado>(cursor, tokenEnvioPadre);
        }
        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }


        private void iniciarComandoBorrar()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            enviarMensajeInhabilitar();
            accesibilidadWindow = false;
        }

        private void finComandoBorrar()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            enviarMensajeHabilitar();
            accesibilidadWindow = true;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            Messenger.Default.Unregister<int>(this, tokenRecepcionHijo);
            Messenger.Default.Unregister<bool>(this, tokenRecepcionHijo);
            accesibilidadWindow = true;
            //if (comando != 9)
            //{
            //    enviarMensajeHabilitar();
            //}
        }


        #endregion Fin de comando

        public async Task mensajeAutoCerrado(string titulo, string contenido, int segundos)
        {
            var dialog = new CustomDialog()
            {
                Title = titulo,
                Content = contenido,
                DialogMessageFontSize = 12,
            };
            await dlg.ShowMetroDialogAsync(this, dialog);

            await System.Threading.Tasks.Task.Delay(segundos * 1000);
            await dlg.HideMetroDialogAsync(this, dialog);
        }


    }
}