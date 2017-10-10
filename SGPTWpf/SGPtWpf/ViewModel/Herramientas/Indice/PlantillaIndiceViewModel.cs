using CapaDatos;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model;
using SGPTWpf.Model.Menus.Herramientas;
using SGPTWpf.Model.Modelo.Indice;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace SGPTWpf.ViewModel.Herramientas.Indice
{
    public sealed class PlantillaIndiceViewModel : ViewModeloBase
    {
        #region Propiedades privadas de control
        private MetroDialogSettings configuracionDialogo;

        private string tokenRecepcionPrincipal = "Indice" + "Herramientas";
        private MenuHerramientasPlantillaIndice detallePlantillaIndice;//Es generico el view display es cualquier string
        private string tokenRecepcion = "PlantillaIndiceController";//Identifica la fuente de un mensaje generico
        private string tokenEnvio = "DatosElementoADetalle";//Identifica la fuente de un mensaje generico
        private string tokenEnvioEntidadSeleccionada = "DatosEntidadSeleccionadaADetalle";//Identifica la fuente de un mensaje generico
        private string tokenEnvioEntidadSeleccionadaPreview = "DatosEntidadSeleccionadaADetallePreview";//Identifica la fuente de un mensaje generico

        private static int comando = 0;
        private DialogCoordinator dlg;
        public static int numeroProcesoCrud { get; set; }//Para control de mensajes enviados y recibidos

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

        #region ViewModel Property : currentUsuarioModelo usuario

        public const string currentUsuarioModeloPropertyName = "currentUsuarioModelo";

        private UsuarioModelo _currentUsuarioModelo;

        public UsuarioModelo currentUsuarioModelo
        {
            get
            {
                return _currentUsuarioModelo;
            }

            set
            {
                if (_currentUsuarioModelo == value) return;

                _currentUsuarioModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentUsuarioModeloPropertyName);
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
        #endregion

        #region ViewModel Properties

        #region Indice

        #region ViewModel Properties publicas

        #region ViewModel Properties : listaIndices

        public const string listaIndicesPropertyName = "listaIndices";

        private ObservableCollection<PlantillaIndiceModelo> _listaIndices;

        public ObservableCollection<PlantillaIndiceModelo> listaIndices
        {
            get
            {
                return _listaIndices;
            }

            set
            {
                if (_listaIndices == value) return;

                _listaIndices = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaIndicesPropertyName);
            }
        }

        #endregion

        #region Nombre de Indice

        public const string descripcionpiPropertyName = "descripcionpi";

        private string _descripcionpi = string.Empty;

        public string descripcionpi
        {
            get
            {
                return _descripcionpi;
            }

            set
            {
                if (_descripcionpi == value)
                {
                    return;
                }

                _descripcionpi = value;
                RaisePropertyChanged(descripcionpiPropertyName);
            }
        }

        #endregion

        #region Nombre tipo auditoria

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

        #region Nombre de Indice

        public const string inicialesusuarioPropertyName = "inicialesusuario";

        private string _inicialesusuario = string.Empty;

        public string inicialesusuario
        {
            get
            {
                return _inicialesusuario;
            }

            set
            {
                if (_inicialesusuario == value)
                {
                    return;
                }

                _inicialesusuario = value;
                RaisePropertyChanged(inicialesusuarioPropertyName);
            }
        }

        #endregion

        #region  Primary key

        public const string idtaPropertyName = "idta";

        private int _idta = 0;

        public int idta
        {
            get
            {
                return _idta;
            }

            set
            {
                if (_idta == value)
                {
                    return;
                }

                _idta = value;
                RaisePropertyChanged(idtaPropertyName);
            }
        }

        #endregion

        #region sistemapi

        public const string sistemapiPropertyName = "sistemapi";

        private bool _sistemapi = false;

        public bool sistemapi
        {
            get
            {
                return _sistemapi;
            }

            set
            {
                if (_sistemapi == value)
                {
                    return;
                }

                _sistemapi = value;
                RaisePropertyChanged(sistemapiPropertyName);
            }
        }

        #endregion

        #region Estadopi
        public const string estadopiPropertyName = "estadopi";

        private string _estadopi = string.Empty;

        public string estadopi
        {
            get
            {
                return _estadopi;
            }

            set
            {
                if (_estadopi == value)
                {
                    return;
                }

                _estadopi = value;
                RaisePropertyChanged(estadopiPropertyName);
            }
        }
        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private PlantillaIndiceModelo _currentEntidad;

        public PlantillaIndiceModelo currentEntidad
        {
            get
            {
                return _currentEntidad;
            }

            set
            {
                if (_currentEntidad == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidad = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadPropertyName);
                if ((_currentEntidad !=null) && (_currentEntidad.idpi !=0))
                {
                    esActivoSubMenu = true;
                }
            }
        }

        #endregion


        #region ViewModel Property : currentEntidadDetalleIndice

        public const string currentEntidadDetalleIndicePropertyName = "currentEntidadDetalleIndice";

        private DetallePlantillaIndiceModelo _currentEntidadDetalleIndice;

        public DetallePlantillaIndiceModelo currentEntidadDetalleIndice
        {
            get
            {
                return _currentEntidadDetalleIndice;
            }

            set
            {
                if (_currentEntidadDetalleIndice == value) return;

                if (value == null)
                {
                    //Valor null no se cambia
                }
                else
                {
                    _currentEntidadDetalleIndice = value;
                }

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadDetalleIndicePropertyName);
            }
        }

        #endregion

        #endregion


        #endregion

        #region PlantillaIndiceMainModel 


        private MainModel _PlantillaIndiceMainModel = null;

        public MainModel PlantillaIndiceMainModel
        {
            get
            {
                return _PlantillaIndiceMainModel;
            }

            set
            {
                _PlantillaIndiceMainModel = value;
            }
        }
        #endregion

        #region ViewModel Properties : esActivoSubMenu

        public const string esActivoSubMenuPropertyName = "esActivoSubMenu";

        private bool _esActivoSubMenu = true;

        public bool esActivoSubMenu
        {
            get
            {
                return _esActivoSubMenu;
            }

            set
            {
                if (_esActivoSubMenu == value)
                {
                    return;
                }

                _esActivoSubMenu = value;
                RaisePropertyChanged(esActivoSubMenuPropertyName);
            }
        }

        #endregion


        #endregion



        #endregion


        public PlantillaIndiceViewModel(string origen)//Documentacion/Carpetas
        {
            _origenLlamada = origen;

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
            detallePlantillaIndice = new MenuHerramientasPlantillaIndice();//Es generico el view display es cualquier string
            RegistrarComandos();
            numeroProcesoCrud = 500;
            listaIndices = new ObservableCollection<PlantillaIndiceModelo>(PlantillaIndiceModelo.GetAll());
            if (listaIndices.Count >= 1)
            {
                currentEntidad = listaIndices[0];
                itemDetalleSeleccion();
                descripcion = currentEntidad.tipoAuditoriaModelo.descripcion;
                inicialesusuario = currentEntidad.usuarioModelo.inicialesusuario;
            }
            else
            {
                currentEntidad = null;
            }
                dlg = new DialogCoordinator();
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal,(herramientaUsuarioValidadoMensaje) => ControlHerramientaUsuarioValidadoMensaje(herramientaUsuarioValidadoMensaje));
            //Controla cuando  se lanza una  ventana esta avise  que se ha cerrado
            Messenger.Default.Register<mensajeDeCierreCrud>(this,tokenRecepcion, (mensajeDeCierreCrud => ControlPlantillaIndiceCierreMensaje(mensajeDeCierreCrud)));

            descripcion = "";
            inicialesusuario = "";
            PlantillaIndiceMainModel = new MainModel();
            esActivoSubMenu = true;
        }

        private void ControlPlantillaIndiceCierreMensaje(mensajeDeCierreCrud plantillaIndiceCierreMensaje)
        {
            //TypeName = null;
            PlantillaIndiceMainModel.TypeName = null;
            if (plantillaIndiceCierreMensaje.numeroProcesoCrud == numeroProcesoCrud)
            {
                switch (comando)
                {
                    case 1:
                        currentEntidad = null;
                        actualizarLista();
                        break;
                    case 2:
                        actualizarLista();
                        break;
                    case 3:
                        //activarVentanaConsulta = true;
                        break;
                    case 4:
                        currentEntidad = null;
                        actualizarLista();
                        break;
                    case 5:
                        currentEntidad = null;
                        actualizarLista();
                        break;
                    default:
                        break;
                }
                comando = 0;
                numeroProcesoCrud++;
            }
        }

        private void ControlHerramientaUsuarioValidadoMensaje(UsuarioMensaje herramientaUsuarioValidadoMensaje)
        {
            currentUsuario = herramientaUsuarioValidadoMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = herramientaUsuarioValidadoMensaje.usuarioModeloMensaje; ;
            //Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
        }


        #region ShowWindowCommand

        #region ViewModel Private Methods

        private void RegistrarComandos()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            BuscarCommand = new RelayCommand(Buscar, CanCommand);
            //DoubleClickCommand = new RelayCommand(ConsultarDobleClick);
            XImprimirCommand = new RelayCommand(XImprimir, CanCommand);
            VistaProgramaCommand = new RelayCommand(VistaPrograma, CanCommand);
            DuplicarCommand = new RelayCommand(Seleccion, CanCommand);
            ItemSeleccionadoCommand = new RelayCommand(itemDetalleSeleccion, CanCommand);
            SelectionChangedCommand = new RelayCommand<PlantillaIndiceModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void itemDetalleSeleccion()
        {
            descripcion = currentEntidad.tipoAuditoriaModelo.descripcion;
            inicialesusuario = currentEntidad.usuarioModelo.inicialesusuario;
            detallePlantillaIndice.NavigateExecute();
            //Enviar elemento seleccionado a detalle Plantilla indice
            Messenger.Default.Send(currentEntidad, tokenEnvioEntidadSeleccionada);
        }

        private async void Seleccion()
        {
            if (!(currentEntidad == null))
            {
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };
                
                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Se copiará el indice a otro registro", "¿Desea confirmar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    PlantillaIndiceModelo temporal = new PlantillaIndiceModelo(currentEntidad, currentUsuarioModelo);
                    
                    //PlantillaIndiceMainModel.TypeName = "PlantillaCopiarView";
                    PlantillaIndiceMainModel.TypeName = "PlantillaIndiceCopiarView";
                    comando = 5;
                    enviarDatosPlantillaIndice(temporal); //Debe ir antes, porque evalua si la ventana es cero para enviarse
                }
                else
                {
                    comando = 5;
                    currentEntidad = null;
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        #endregion

        #region ViewModel Commands

        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand BuscarCommand { get; set; }
        //public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand DuplicarCommand { get; set; }

        public RelayCommand ItemSeleccionadoCommand { get; set; }
        public RelayCommand<PlantillaIndiceModelo> SelectionChangedCommand { get; set; }

        //public RelayCommand<LegalNormaModelo> SelectionChangedCommand { get; set; }
        #endregion


        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            PlantillaIndiceMainModel.TypeName = "PlantillaIndiceCrearView";
            currentEntidad = new PlantillaIndiceModelo();
            currentEntidad.idusuario = currentUsuario.idusuario;
            currentEntidad.usuarioModelo = currentUsuarioModelo;
            comando = 1;
            enviarDatosPlantillaIndice();

        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {
                PlantillaIndiceMainModel.TypeName = "PlantillaIndiceEditarView";
                comando = 2;
                currentEntidad.usuarioModelo = currentUsuarioModelo;
                currentEntidad.idusuario = currentUsuario.idusuario;//Se manda por si se modifcica el  valor;
                enviarDatosPlantillaIndice(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a editar", "");
            }
        }
        public async void Consultar()
        {
            if (!(currentEntidad == null))
            {
                PlantillaIndiceMainModel.TypeName = "PlantillaIndiceConsultarView";
                comando = 3;
                enviarDatosPlantillaIndice();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        public async void ConsultarDobleClick()
        {
            if (!(currentEntidad == null))
            {
                PlantillaIndiceMainModel.TypeName = "PlantillaIndiceConsultarView";
                comando = 3;
                enviarDatosPlantillaIndice();
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }

        public async void Borrar()
        {
            if (!(currentEntidad == null))
            {
                {
                    //Unicamente realiza un borrado lógico cambiando el estado a B y actualizando el listado
                    if (PlantillaIndiceModelo.Delete(currentEntidad.idpi, true))
                    //if (PlantillaIndiceModelo.Delete(currentEntidad.id, true))
                    {
                        await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                        actualizarLista();
                        currentEntidad = null;
                        itemDetalleSeleccion();//Refresca la vista dependiente
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible eliminar el registro", "");
                    }
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
        }
        public bool CanSave()
        {
            return !(currentEntidad.idpi == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.descripcionpi);
        }

        public bool CanCommand()
        {
            if ((currentEntidad == null)|| (currentEntidad.idpi == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void Buscar()
        {
            throw new NotImplementedException();
        }

        private void VistaPrograma()
        {
            PlantillaIndiceMainModel.TypeName = "PlantillaIndicePreviewView";
            comando = 5;
            enviarDatosPlantillaIndice(tokenEnvioEntidadSeleccionadaPreview);
        }

        private void XImprimir()
        {
            throw new NotImplementedException();
        }

        private void actualizarLista()
        {
            try
            {
                if (!(listaIndices == null))
                {
                   listaIndices.Clear();
                }
                listaIndices = new ObservableCollection<PlantillaIndiceModelo>(PlantillaIndiceModelo.GetAll());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas de índices " + e.Message, "");
                }
            }
        }

        #endregion


        #region Mensajes
        public void enviarDatosPlantillaIndice()
        {
            //Se crea el mensaje
            PlantillaIndiceMensaje elemento = new PlantillaIndiceMensaje();
            elemento.elementoMensaje = currentEntidad;
            elemento.listaMensaje = listaIndices;
            elemento.numeroProcesoCrudEnviado = numeroProcesoCrud;
            elemento.comandoCrud = comando;
            numeroProcesoCrud = numeroProcesoCrud + 1;//Se incrementa para  proximo envio
            Messenger.Default.Send(elemento,tokenEnvio);
        }

        public void enviarDatosPlantillaIndice(PlantillaIndiceModelo temporal)
        {
            //Se crea el mensaje
            PlantillaIndiceMensaje elemento = new PlantillaIndiceMensaje();
            elemento.elementoMensaje = temporal;
            elemento.listaMensaje = listaIndices;
            elemento.numeroProcesoCrudEnviado = numeroProcesoCrud;
            elemento.comandoCrud = comando;
            numeroProcesoCrud = numeroProcesoCrud + 1;//Se incrementa para  proximo envio
            Messenger.Default.Send(elemento, tokenEnvio);
        }


        public void enviarDatosPlantillaIndice(string token)
        {
            //Se crea el mensaje
            PlantillaIndiceMensaje elemento = new PlantillaIndiceMensaje();
            elemento.elementoMensaje = currentEntidad;
            elemento.listaMensaje = listaIndices;
            elemento.numeroProcesoCrudEnviado = numeroProcesoCrud;
            elemento.comandoCrud = comando;
            numeroProcesoCrud = numeroProcesoCrud + 1;//Se incrementa para  proximo envio
            Messenger.Default.Send(elemento, tokenEnvioEntidadSeleccionadaPreview);
        }
        #endregion

    }
}