using CapaDatos;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Herramientas;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Plantilla;
using System;
using System.Collections.ObjectModel;
using Word = NetOffice.WordApi;
using System.IO;
//using NetOffice.OfficeApi.Tools;
using Excel = NetOffice.ExcelApi;

using PowerPoint = NetOffice.PowerPointApi;
using System.Globalization;
using System.Collections.Generic;
using SGPTWpf.Model.Modelo.Plantilla.SGPTWpf.Model.Modelo.Plantilla;
using System.Windows.Forms;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.ViewModel.Herramientas.Plantillas
{
    public sealed class PlantillaViewModel : ViewModeloBase
    {
        #region Propiedades privadas

        private static int comando = 0;
        private string tokenEnvio = "PlantillaModelo";
        private string tokenRecepcionPrincipal = "Plantillas" + "Herramientas";
        private string tokenRecepcionCierre = "CrudPlantillaCerrada";
        private DialogCoordinator dlg;
        private string fileName = "";//Ruta de archivos creado;
        #endregion

        #region ViewModel Properties publicas

        #region lista entidades

        public const string listaPropertyName = "lista";


        private ObservableCollection<PlantillaModelo> _lista;

        public ObservableCollection<PlantillaModelo> lista
        {
            get
            {
                return _lista;
            }

            set
            {
                if (_lista == value) return;

                _lista = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaPropertyName);
            }
        }

        #endregion

        #region listaArchivosCreados entidades

        //Mantendra un histórico de los archivos que se descargan y los borrará

        public const string listaArchivosCreadosPropertyName = "listaArchivosCreados";


        private ObservableCollection<string> _listaArchivosCreados;

        public ObservableCollection<string> listaArchivosCreados
        {
            get
            {
                return _listaArchivosCreados;
            }

            set
            {
                if (_listaArchivosCreados == value) return;

                _listaArchivosCreados = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(listaArchivosCreadosPropertyName);
            }
        }

        #endregion

        #region  Primary key plantilla idplantilla

        public const string idplantillaPropertyName = "idplantilla";

        private int _idplantilla = 0;

        public int idplantilla
        {
            get
            {
                return _idplantilla;
            }

            set
            {
                if (_idplantilla == value)
                {
                    return;
                }

                _idplantilla = value;
                RaisePropertyChanged(idplantillaPropertyName);
            }
        }

        #endregion

        #region  Primary key plantilla idusuario

        public const string idusuarioPropertyName = "idusuario";

        private int _idusuario = 0;

        /// <summary>
        /// Sets and gets the nombretablamc property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int idusuario
        {
            get
            {
                return _idusuario;
            }

            set
            {
                if (_idusuario == value)
                {
                    return;
                }

                _idusuario = value;
                RaisePropertyChanged(idusuarioPropertyName);
            }
        }

        #endregion

        #region  Primary key plantilla iddd

        public const string idddPropertyName = "iddd";

        private int _iddd = 0;

        public int iddd
        {
            get
            {
                return _iddd;
            }

            set
            {
                if (_iddd == value)
                {
                    return;
                }

                _iddd = value;
                RaisePropertyChanged(idddPropertyName);
            }
        }

        #endregion

        #region nombre de plantilla

        public const string nombreplantillaPropertyName = "nombreplantilla";

        private string _nombreplantilla = string.Empty;

        public string nombreplantilla
        {
            get
            {
                return _nombreplantilla;
            }

            set
            {
                if (_nombreplantilla == value)
                {
                    return;
                }

                _nombreplantilla = value;
                RaisePropertyChanged(nombreplantillaPropertyName);
            }
        }


        #endregion

        #region Comentario plantilla

        public const string comentarioplantillaPropertyName = "comentarioplantilla";

        private string _comentarioplantilla = string.Empty;

        public string comentarioplantilla
        {
            get
            {
                return _comentarioplantilla;
            }

            set
            {
                if (_comentarioplantilla == value)
                {
                    return;
                }

                _comentarioplantilla = value;
                RaisePropertyChanged(comentarioplantillaPropertyName);
            }
        }

        #endregion

        #region versionplantilla

        public const string versionplantillaPropertyName = "versionplantilla";

        private decimal _versionplantilla = 0;

        public decimal versionplantilla
        {
            get
            {
                return _versionplantilla;
            }

            set
            {
                if (_versionplantilla == value)
                {
                    return;
                }

                _versionplantilla = value;
                RaisePropertyChanged(versionplantillaPropertyName);
            }
        }

        #endregion

        #region fecha de modificacion de plantilla

        public const string fechacreadoplantillaPropertyName = "fechacreadoplantilla";

        private string _fechacreadoplantilla = string.Empty;

        public string fechacreadoplantilla
        {
            get
            {
                return _fechacreadoplantilla;
            }

            set
            {
                if (_fechacreadoplantilla == value)
                {
                    return;
                }

                _fechacreadoplantilla = value;
                RaisePropertyChanged(fechacreadoplantillaPropertyName);
            }
        }

        #endregion

        #region Tipo  de archivo

        public const string tipoarchivoplantillaPropertyName = "tipoarchivoplantilla";

        private string _tipoarchivoplantilla = string.Empty;

        public string tipoarchivoplantilla
        {
            get
            {
                return _tipoarchivoplantilla;
            }

            set
            {
                if (_tipoarchivoplantilla == value)
                {
                    return;
                }

                _tipoarchivoplantilla = value;
                RaisePropertyChanged(tipoarchivoplantillaPropertyName);
            }
        }

        #endregion

        #region ficherobinarioplantilla

        public const string ficherobinarioplantillaPropertyName = "ficherobinarioplantilla";

        private byte[] _ficherobinarioplantilla = null;

        public byte[] ficherobinarioplantilla
        {
            get
            {
                return _ficherobinarioplantilla;
            }

            set
            {
                if (_ficherobinarioplantilla == value)
                {
                    return;
                }

                _ficherobinarioplantilla = value;
                RaisePropertyChanged(ficherobinarioplantillaPropertyName);
            }
        }

        #endregion

        #region sistemaplantilla
        public const string sistemaplantillaPropertyName = "sistemaplantilla";

        private bool _sistemaplantilla = false;

        public bool sistemaplantilla
        {
            get
            {
                return _sistemaplantilla;
            }

            set
            {
                if (_sistemaplantilla == value)
                {
                    return;
                }

                _sistemaplantilla = value;
                RaisePropertyChanged(sistemaplantillaPropertyName);
            }
        }

        #endregion

        #region estadoplantilla

        public const string estadoplantillaPropertyName = "estadoplantilla";

        private string _estadoplantilla = string.Empty;

        public string estadoplantilla
        {
            get
            {
                return _estadoplantilla;
            }

            set
            {
                if (_estadoplantilla == value)
                {
                    return;
                }

                _estadoplantilla = value;
                RaisePropertyChanged(estadoplantillaPropertyName);
            }
        }
        #endregion

        #region nombre de detalle documento

        public const string nombreDetalleDocumentoPropertyName = "nombreDetalleDocumento";

        private string _nombreDetalleDocumento = string.Empty;

        public string nombreDetalleDocumento
        {
            get
            {
                return _nombreDetalleDocumento;
            }

            set
            {
                if (_nombreDetalleDocumento == value)
                {
                    return;
                }

                _nombreDetalleDocumento = value;
                RaisePropertyChanged(nombreDetalleDocumentoPropertyName);
            }
        }


        #endregion

        #region nombre clase de documento

        public const string nombreDocumentoPropertyName = "nombreDocumento";

        private string _nombreDocumento = string.Empty;

        public string nombreDocumento
        {
            get
            {
                return _nombreDocumento;
            }

            set
            {
                if (_nombreDocumento == value)
                {
                    return;
                }

                _nombreDocumento = value;
                RaisePropertyChanged(nombreDocumentoPropertyName);
            }
        }


        #endregion        

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private PlantillaModelo _currentEntidad;

        public PlantillaModelo currentEntidad
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
                RaisePropertyChanged(currentEntidadPropertyName);
            }
        }

        #endregion

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

        #region ViewModel Property : detalleDocumentosModelo usuario

        public const string detalleDocumentosModeloPropertyName = "detalleDocumentosModelo";

        private usuario _detalleDocumentosModelo;

        public usuario detalleDocumentosModelo
        {
            get
            {
                return _detalleDocumentosModelo;
            }

            set
            {
                if (_detalleDocumentosModelo == value) return;

                _detalleDocumentosModelo = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(detalleDocumentosModeloPropertyName);
            }
        }

        #endregion



        #endregion


        #region inicialesusuario

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

        #endregion

        #region ViewModel Commands


        public RelayCommand NuevoCommand { get; set; }
        public RelayCommand EditarCommand { get; set; }
        public RelayCommand BorrarCommand { get; set; }
        public RelayCommand ConsultarCommand { get; set; }
        public RelayCommand BuscarCommand { get; set; }
        public RelayCommand DuplicarCommand { get; set; }
        public RelayCommand VistaProgramaCommand { get; set; }
        public RelayCommand DoubleClickCommand { get; set; }

        //public RelayCommand DoubleClickCommand { get; set; }
        public RelayCommand XImprimirCommand { get; set; }

        public RelayCommand ItemSeleccionadoCommand { get; set; }
        public RelayCommand<PlantillaModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region MainModel

        private MainModel _PlantillaMainModel = null;

        public MainModel PlantillaMainModel
        {
            get
            {
                return _PlantillaMainModel;
            }

            set
            {
                _PlantillaMainModel = value;
            }
        }
        #endregion

        #region ViewModel Public Methods

        #region Constructores

        public PlantillaViewModel()
        {
            
            //lista = new ObservableCollection<PlantillaModelo>(PlantillaModelo.GetAll());
            RegisterCommands();
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            Messenger.Default.Register<bool>(this, tokenRecepcionCierre, (controlVentanaMensaje) => ControlVentanaMensaje(controlVentanaMensaje));
            Messenger.Default.Register<UsuarioMensaje>(this, tokenRecepcionPrincipal, (usuarioMensaje) => ControlUsuarioMensaje(usuarioMensaje));
            PlantillaMainModel = new MainModel();
            listaArchivosCreados = new ObservableCollection<string>();
        }

        private void ControlUsuarioMensaje(UsuarioMensaje usuarioMensaje)
        {
            currentUsuario = usuarioMensaje.usuarioMensaje;//Usuario que navega
            currentUsuarioModelo = usuarioMensaje.usuarioModeloMensaje;
            //Messenger.Default.Unregister<UsuarioMensaje>(this, tokenRecepcionPrincipal);//El usuario  no puede cambiar a menos que vuelva a ingresar
            actualizarLista();
        }

        #endregion

        public void enviarDatos()
        {
            //Se crea el mensaje
            DetallePlantillaCrudMensaje elemento = new DetallePlantillaCrudMensaje();
            elemento.elementoModelo = currentEntidad;
            elemento.listaElementos = lista;
            elemento.comandoCrud = comando;
            elemento.usuarioModeloValidado = currentUsuarioModelo;
            Messenger.Default.Send(elemento, tokenEnvio);
        }

        #region Receptor de mensajes
        private void ControlVentanaMensaje(bool controlVentanaCrearMensaje)
        {
            if (controlVentanaCrearMensaje)
            {
                //Para controlar la ventana abierta
                PlantillaMainModel.TypeName = null;
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
                        break;
                    case 5:
                        actualizarLista();
                        break;
                    default:
                        break;
                }
                comando = 0;
            }
        }
        #endregion

        #region Implementacion de comandos
        public void Nuevo()
        {
            PlantillaMainModel.TypeName = "PlantillaModeloCrearView";
            currentEntidad = new PlantillaModelo();
            currentEntidad.usuarioModelo = currentUsuarioModelo;
            comando = 1;
            enviarDatos();
        }

        public async void Editar()
        {
            if (!(currentEntidad == null))
            {

                PlantillaMainModel.TypeName = "PlantillaModeloEditarView";
                currentEntidad = PlantillaModelo.GetAllItem(currentEntidad.idplantilla);
                currentEntidad.usuarioModelo = currentUsuarioModelo;
                comando = 2;
                enviarDatos();

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

                PlantillaMainModel.TypeName = "PlantillaModeloConsultarView";
                comando = 3;
                enviarDatos();

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

                PlantillaMainModel.TypeName = "PlantillaModeloConsultarView";
                comando = 3;
                enviarDatos();
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
                //Unicamente realiza un borrado lógico cambiando el estadoplantilla a B y actualizando el listado
                if (PlantillaModelo.Delete(currentEntidad.idplantilla, true))
                {
                    await dlg.ShowMessageAsync(this, "Se borro el registro", "");
                    lista.Remove(currentEntidad);
                    currentEntidad = null;
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "No ha sido posible posible eliminar el registro", "");
                }
            }
            else
            {
                //MessageBox.Show("Debe seleccionar el registro a editar","" ,MessageBoxButton.OKCancel);
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a eliminar", "");
            }
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

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "Se copiará la plantila a otro registro", "¿Desea confirmar?", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                    int idCopia = currentEntidad.idplantilla;
                    currentEntidad = new PlantillaModelo();
                    currentEntidad = PlantillaModelo.GetRegistro(idCopia);
                    currentEntidad.idplantilla = 0;
                    currentEntidad.idusuario = currentUsuario.idusuario;
                    currentEntidad.usuarioModelo = currentUsuarioModelo;
                    currentEntidad.fechacreadoplantilla = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
                    PlantillaMainModel.TypeName = "PlantillaIndiceCopiarView";
                    comando = 5;
                    enviarDatos(); //Debe ir antes, porque evalua si la ventana es cero para enviarse
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

        /*        private async void VistaPlantilla()
                {
                    if (!(currentEntidad == null))
                    {
                        comando = 5;
                        currentEntidad = PlantillaModelo.GetAllItem(currentEntidad.idplantilla);
                        //VistaDocumento(currentEntidad);

                        switch (currentEntidad.tipoarchivoplantilla)
                        {
                            case "docx":

                                VistaProgramaWord();
                                break;
                            case "doc":
                                VistaProgramaWord();
                                break;
                            case "xlsx":
                                VistaProgramaExcel();
                                break;
                            case "xls":
                                VistaProgramaExcel();
                                break;
                            case "pptx":
                                VistaProgramaPower();
                                break;
                            case "ppt":
                                VistaProgramaPower();
                                break;
                            case "txt":
                                await dlg.ShowMessageAsync(this, "Pendiente", "");
                                break;
                            case "rft":
                                await dlg.ShowMessageAsync(this, "Pendiente", "");
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
                    }
                }*/


        private async void VistaPlantilla()
        {
            if (!(currentEntidad == null))
            {
                comando = 5;
                currentEntidad = PlantillaModelo.GetAllItem(currentEntidad.idplantilla);
                //VistaDocumento(currentEntidad);
                //VistaDocumentoUniversal(currentEntidad);
                editDocument();
                /*switch (currentEntidad.tipoarchivoplantilla)
                {
                    case "docx":

                        VistaProgramaWord();
                        break;
                    case "doc":
                        VistaProgramaWord();
                        break;
                    case "xlsx":
                        VistaProgramaExcel();
                        break;
                    case "xls":
                        VistaProgramaExcel();
                        break;
                    case "pptx":
                        VistaProgramaPower();
                        break;
                    case "ppt":
                        VistaProgramaPower();
                        break;
                    case "txt":
                        await dlg.ShowMessageAsync(this, "Pendiente", "");
                        break;
                    case "rft":
                        await dlg.ShowMessageAsync(this, "Pendiente", "");
                        break;
                    default:
                        break;
                }*/
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe seleccionar el registro a consultar", "");
            }
        }


        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.idplantilla == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.nombreplantilla);
        }

        #region Verificaciones

        public bool CanCommand()
        {
            return currentEntidad != null;
        }

        private void actualizarLista()
        {
            //borrarTemporales();//Para borrar cualquier  archivo creado
            try
            {
                lista = new ObservableCollection<PlantillaModelo>(PlantillaModelo.GetAll());
            }
            catch (Exception )
            {
                    dlg.ShowMessageAsync(this, "Problema de comunicacion en la actualizacion de listas ", "");
                    lista = new ObservableCollection<PlantillaModelo>();
            }
        }

        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            NuevoCommand = new RelayCommand(Nuevo, null);
            EditarCommand = new RelayCommand(Editar, CanCommand);
            BorrarCommand = new RelayCommand(Borrar, CanCommand);
            ConsultarCommand = new RelayCommand(Consultar, CanCommand);
            DoubleClickCommand = new RelayCommand(ConsultarDobleClick, CanCommand);
            DuplicarCommand = new RelayCommand(Seleccion, CanCommand);
            VistaProgramaCommand = new RelayCommand(VistaPlantilla, CanCommand);
            SelectionChangedCommand = new RelayCommand<PlantillaModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        #endregion

        #region Procesado  de word

 /*       #region Fields

        private Word.Application _wordApplication;
        private Excel.Application excelApplication;
        private PowerPoint.Application powerApplication;
        
        #endregion*/


        #region Methods

 /*       private Word.Template GetNormalDotTemplate()
        {
            foreach (Word.Template installedTemplate in _wordApplication.Templates)
            {
                //  returns normal.dot template (normal.dotm in modern word versions)
                if (installedTemplate.Name.StartsWith("normal", StringComparison.InvariantCultureIgnoreCase))
                {
                    return installedTemplate;
                }
                installedTemplate.Dispose();
            }

            throw new IndexOutOfRangeException("Template not found.");
        }*/

        #endregion

        //Basado en : http://netoffice.codeplex.com/

 /*       private void VistaDocumentoUniversal(PlantillaModelo currentEntidad)
        {
            fileName = Path.GetTempPath() + currentEntidad.nombrearchivoplantilla;
            //Nombre del archivo temporal

            //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
            //fileName = Path.GetTempFileName();//Se crea archivo aleatorio
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                listaArchivosCreados.Add(fileName);
                //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                //this.CloseWindow();
                //http://geeks.ms/jirigoyen/2010/03/25/constryete-tu-propio-gestor-documental/
                Process process = new Process { StartInfo = { FileName = fileName } };
                process.Start();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "No tiene una aplicación instalada que maneje el archivo " + e.Message, "");
            }
        }*/

 /*       private void VistaDocumento(PlantillaModelo currentEntidad)
        {
            fileName = Path.GetTempPath() + currentEntidad.nombrearchivoplantilla;
            //Nombre del archivo temporal

            //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
            //fileName = Path.GetTempFileName();//Se crea archivo aleatorio
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                listaArchivosCreados.Add(fileName);
                //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                Process.Start(fileName);
                //this.CloseWindow();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "No tiene una aplicación instalada que maneje el archivo " + e.Message, "");
            }
        }*/
       /* private void VistaProgramaWord()
        {
            // start word and turn off msg boxes
            bool éxito = false;
            _wordApplication = new Word.Application();
            _wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            // create a utils instance, not need for but helpful to keep the lines of code low
            CommonUtils utils = new CommonUtils(_wordApplication);

            Office.CommandBar commandBar = null;
            Office.CommandBarButton commandBarBtn = null;


            Word.Template normalDotTemplate = GetNormalDotTemplate();

            normalDotTemplate.Saved = true;
            // make visible & set buttons
            _wordApplication.Visible = true;


            //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
            fileName = Path.GetTempFileName();//Se crea nombre de archivo aleatorio
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                listaArchivosCreados.Add(fileName);

            }
            catch (Exception)
            {
                dlg.ShowMessageAsync(this, "Error para crear archivo ", "");
            }

            //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
            //Word.Document newDocument = _wordApplication.Documents.Add(fileName);
            Word.Document newDocument = _wordApplication.Documents.Add(fileName);
            _wordApplication.CustomizationContext = normalDotTemplate;

            //_wordApplication.Documents.Add(fileName);
            #region Create a new toolbar

            // add a new toolbar
            commandBar = _wordApplication.CommandBars.Add("SGPtBar", MsoBarPosition.msoBarTop, false, true);
            commandBar.Visible = true;

            // add a button to the toolbar
            commandBarBtn = (Office.CommandBarButton)commandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndWrapCaption;
            commandBarBtn.Caption = "Guardar en SGPt";
            commandBarBtn.FaceId = 3;
            commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

            normalDotTemplate.Saved = true;

            // make visible & set buttons
            _wordApplication.Visible = true;


            #endregion

            //_wordApplication.Quit();
            _wordApplication.Dispose();

        }*/

 /*       private void VistaProgramaExcel()
        {
            // start excel and turn off msg boxes
            excelApplication = new Excel.Application();
            excelApplication.DisplayAlerts = false;
            // create a utils instance, not need for but helpful to keep the lines of code low
            Excel.Tools.CommonUtils utils = new Excel.Tools.CommonUtils(excelApplication);
            excelApplication.Visible = true;
            //Nombre del archivo temporal

            //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
            fileName = Path.GetTempFileName();//Se crea archivo aleatorio
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                //Word.Document newDocument = _wordApplication.Documents.Add(fileName);
                Excel.Workbook workBook = excelApplication.Workbooks.Open(fileName);
                Excel.Worksheet workSheet = (Excel.Worksheet)workBook.Worksheets[1];
                //_wordApplication.Documents.Add(fileName);
            }
            finally
            {
                //File.Delete(fileName);
            }
            //_wordApplication.Quit();
            excelApplication.Dispose();

        }*/

 /*       private void VistaProgramaPower()
        {
            // start powerpoint
            powerApplication = new PowerPoint.Application();

            // create a utils instance, not need for but helpful to keep the lines of code low
            PowerPoint.Tools.CommonUtils utils = new PowerPoint.Tools.CommonUtils(powerApplication);

            powerApplication.Visible = MsoTriState.msoTrue;
            //fileName = Path.GetTempPath()+currentEntidad.nombrearchivoplantilla;
            //Nombre del archivo temporal

            //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
            fileName = Path.GetTempFileName();//Se crea archivo aleatorio
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                PowerPoint.Presentation presentation = powerApplication.Presentations.Open(fileName);
            }
            finally
            {
                //File.Delete(fileName);
            }
            powerApplication.Dispose();

        }*/
        private static string GetDefaultExtension(Excel.Application application)
        {
            double Version = Convert.ToDouble(application.Version, CultureInfo.InvariantCulture);
            if (Version >= 12.00)
                return ".xlsx";
            else
                return ".xls";
        }

        private static string GetDefaultExtension(PowerPoint.Application application)
        {
            double Version = Convert.ToDouble(application.Version, CultureInfo.InvariantCulture);
            if (Version >= 12.00)
                return ".pptx";
            else
                return ".ppt";
        }
        private static string GetDefaultExtension(Word.Application application)
        {
            double version = Convert.ToDouble(application.Version, CultureInfo.InvariantCulture);
            if (version >= 12.00)
                return ".docx";
            else
                return ".doc";
        }

        private void TryDeleteDocument(string _documentPath)
        {
            try
            {
                if (File.Exists(_documentPath))
                    File.Delete(_documentPath);
            }
            catch
            {
                // its already open - aren't so?
                // we ignore this and dont refuse the user
                Console.WriteLine("Unable to delete {0}.", _documentPath);
            }
        }
        private string TryDeleteFile(string _documentPath)
        {
            try
            {
                if (File.Exists(_documentPath))
                {
                    File.Delete(_documentPath);
                    return "1";//Existe
                }
                else
                {
                    return "0";//No existe
                }
            }
            catch
            {
                // its already open - aren't so?
                // we ignore this and dont refuse the user
                Console.WriteLine("Unable to delete {0}.", _documentPath);
                return _documentPath; //Esta siendo ocupado
            }
        }
        private void borrarTemporales()
        {

            if (listaArchivosCreados.Count >= 1)
            {
                var itemsToRemove = new ObservableCollection<string>();
                for (int i = 0; i < listaArchivosCreados.Count; i++)
                {
                    listaArchivosCreados[i] = TryDeleteFile(listaArchivosCreados[i]);
                    if (listaArchivosCreados[i] == "0" || listaArchivosCreados[i] == "1")
                    {
                        itemsToRemove.Add(listaArchivosCreados[i]);
                    }

                }
                foreach (var item in itemsToRemove)
                {
                    listaArchivosCreados.Remove(item);
                }
            }
        }
        #endregion


        #region Prueba word

        private delegate void UpdateEventTextDelegate(string Message);

/*        private void VistaProgramaUniversal()
        {
            //Se crea nombre de archivo aleatorio
            //fileName = Path.GetTempFileName();
            fileName = Path.GetTempPath() + currentEntidad.nombrearchivoplantilla;
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                listaArchivosCreados.Add(fileName);
            }
            catch (Exception)
            {
                dlg.ShowMessageAsync(this, "Error al archivo ", "");
            }
            // start word and turn off msg boxes
            _wordApplication = new Word.Application();
            _wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;

            Office.CommandBar commandBar = null;
            Office.CommandBarButton commandBarBtn = null;

            // we register some events. note: the event trigger was called from word, means an other Thread
            //wordApplication.DocumentBeforeCloseEvent += new NetOffice.WordApi.Application_DocumentBeforeCloseEventHandler(wordApplication_DocumentBeforeCloseEvent);
            _wordApplication.DocumentBeforeSaveEvent += new NetOffice.WordApi.Application_DocumentBeforeSaveEventHandler(guardarSave);
            _wordApplication.QuitEvent += new NetOffice.WordApi.Application_QuitEventHandler(guardarSalir);



            // add a new document
            _wordApplication.Documents.Open(fileName);
            //TryDeleteDocument(fileName);//Se borra el temporal
            Word.Template normalDotTemplate = GetNormalDotTemplate();
            _wordApplication.CustomizationContext = normalDotTemplate;

            // add a new toolbar
            commandBar = _wordApplication.CommandBars.Add("SGPtBar", MsoBarPosition.msoBarTop, false, true);
            commandBar.Visible = true;

            // add a button to the toolbar
            commandBarBtn = (Office.CommandBarButton)commandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
            commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndWrapCaption;
            commandBarBtn.Caption = "Guardar en SGPt";
            commandBarBtn.FaceId = 3;
            commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

            normalDotTemplate.Saved = true;

            // make visible & set buttons
            _wordApplication.Visible = true;

        }*/
 /*       private void VistaProgramaWord()
        {
            //Se crea nombre de archivo aleatorio
            //fileName = Path.GetTempFileName();
            fileName = Path.GetTempPath() + currentEntidad.nombrearchivoplantilla;
            try
            {
                File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
                listaArchivosCreados.Add(fileName);
            }
            catch (Exception)
            {
                dlg.ShowMessageAsync(this, "Error al archivo ", "");
            }
            // start word and turn off msg boxes
                _wordApplication = new Word.Application();
                _wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;

                Office.CommandBar commandBar = null;
                Office.CommandBarButton commandBarBtn = null;

            // we register some events. note: the event trigger was called from word, means an other Thread
            //wordApplication.DocumentBeforeCloseEvent += new NetOffice.WordApi.Application_DocumentBeforeCloseEventHandler(wordApplication_DocumentBeforeCloseEvent);
            _wordApplication.DocumentBeforeSaveEvent += new NetOffice.WordApi.Application_DocumentBeforeSaveEventHandler(guardarSave);
            _wordApplication.QuitEvent += new NetOffice.WordApi.Application_QuitEventHandler(guardarSalir);



            // add a new document
            _wordApplication.Documents.Open(fileName);
                //TryDeleteDocument(fileName);//Se borra el temporal
                Word.Template normalDotTemplate = GetNormalDotTemplate();
                _wordApplication.CustomizationContext = normalDotTemplate;

                // add a new toolbar
                commandBar = _wordApplication.CommandBars.Add("SGPtBar", MsoBarPosition.msoBarTop, false, true);
                commandBar.Visible = true;

                // add a button to the toolbar
                commandBarBtn = (Office.CommandBarButton)commandBar.Controls.Add(MsoControlType.msoControlButton, System.Type.Missing, System.Type.Missing, System.Type.Missing, true);
                commandBarBtn.Style = MsoButtonStyle.msoButtonIconAndWrapCaption;
                commandBarBtn.Caption = "Guardar en SGPt";
                commandBarBtn.FaceId = 3;
                commandBarBtn.ClickEvent += new Office.CommandBarButton_ClickEventHandler(commandBarBtn_Click);

                normalDotTemplate.Saved = true;

                // make visible & set buttons
                _wordApplication.Visible = true;

        }*/

/*        private void guardarSalir()
        {
            _wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            actualizarBinario();
        }

        private void guardarSave(Word.Document Doc, ref bool SaveAsUI, ref bool Cancel)
        {
            actualizarBinario();
        }
        */
 /*       private void commandBarBtn_Click(Office.CommandBarButton Ctrl, ref bool CancelDefault)
        {
            //textBoxEvents.BeginInvoke(_updateDelegate, new object[] { "Click called." });
            _wordApplication.Visible = false;
            actualizarBinario();
            //Ctrl.Dispose();
        }*/

  /*      private async void actualizarBinario()
        {
                Word.Tools.CommonUtils utils = new Word.Tools.CommonUtils(_wordApplication);
                var mySettings = new MetroDialogSettings()
                {
                    AffirmativeButtonText = "Ok",
                    NegativeButtonText = "Cancelar",
                };

                MessageDialogResult result = await dlg.ShowMessageAsync(this, "¿Desea guardar los cambios?", "Ok para confirmar", MessageDialogStyle.AffirmativeAndNegative, mySettings);

                if (result == MessageDialogResult.Affirmative)
                {
                // save the document
                // add a new document
                Word.Document newDocument = _wordApplication.Documents.Add();
                _wordApplication.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                //string documentFile = utils.File.Combine(Path.GetTempPath(), currentEntidad.nombrearchivoplantilla, Word.Tools.DocumentFormat.Normal);
                //newDocument.SaveAs(documentFile);
                _wordApplication.Documents.Save();
                // close word and dispose reference
                _wordApplication.Quit();
                _wordApplication.Documents.Dispose();

                //_wordApplication.Documents.Save(fileName);
                currentEntidad.ficherobinarioplantilla = File.ReadAllBytes(fileName);
                    if (PlantillaModelo.UpdateModelo(currentEntidad, true))
                    {
                        await dlg.ShowMessageAsync(this, "Registro actualizado con éxito", "");
                        TryDeleteDocument(fileName);
                    }
                    else
                    {
                        await dlg.ShowMessageAsync(this, "No ha sido posible actualizar el registro", "guarde los cambios en  forma independiente");
                        _wordApplication.Visible = true;
                    }
                }
                else
                {
                    _wordApplication.Visible = true;
                }
        }*/

        #endregion

        #region Prueba captura de procesos
        //https://geeks.ms/lfranco/2011/08/19/editar-documentos-almacenados-como-array-de-bits-en-sql-server-filestream-3n/
        List<ProcessController> Processes = new List<ProcessController>();

        private void editDocument()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Guid guidId;
            // Create and display the value of two GUIDs.
            guidId = Guid.NewGuid();
            currentEntidad.guId = guidId;
            //fileName = Path.g.GetTempPath() + currentEntidad.nombrearchivonormativa;
            if (!string.IsNullOrEmpty(mydocpath))
            {
                //https://msdn.microsoft.com/es-es/library/6ka1wd3w(v=vs.110).aspx
                fileName = mydocpath + @"\" + currentEntidad.nombrearchivoplantilla;
            }
            else
            {
                //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
                fileName = Path.GetTempPath() + currentEntidad.nombrearchivoplantilla;
            }
            listaArchivosCreados.Add(fileName);
            File.WriteAllBytes(fileName, currentEntidad.ficherobinarioplantilla);
            if (currentEntidad.ficherobinarioplantilla == null) return;
            ProcessController process = new ProcessController(
                currentEntidad.ficherobinarioplantilla,
                currentEntidad.guId, currentEntidad.nombrearchivoplantilla,fileName,currentEntidad.idplantilla);
                process.Exited += process_Exited;
                process.EditInAssociatedApplication();
                Processes.Add(process);
        }

        void process_Exited(object sender, EventArgs e)
        {
            ProcessController process = sender as ProcessController;
            if (process == null) return;
            if (process.HasChanged())
            {
                string message = "Usted ha hecho cambios en  el  archivo. Desea que se actualicela version en la base de datos?";
                string caption = "Se detecto cambios en el archivo";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == DialogResult.Yes)
                {
                    //Guardar en la entidad y guardarla
                    saveDocument(process.FileId, process.TempFileName, process.idPlantilla);
                    Processes.Remove(process);//Se remueve del listado el proceso creado
                }
            }
            else
            {
                TryDeleteDocument(process.TempFileName);
                Processes.Remove(process);
                borrarTemporales();
            }
        }

        private void saveDocument(Guid docId, string filename, int idPlantilla)
        {
            DialogCoordinator dlg = new DialogCoordinator();
            var filestreamDoc = PlantillaModelo.Find(idPlantilla);
            if (filestreamDoc == null) return;
            if (File.Exists(filename))
            {
                filestreamDoc.usuarioModelo = currentUsuarioModelo;
                filestreamDoc.idusuario = currentUsuarioModelo.idUsuario;
                filestreamDoc.ficherobinarioplantilla = File.ReadAllBytes(filename);
                if (PlantillaModelo.UpdateModelo(filestreamDoc, true))
                {
                    borrarTemporales();
                    TryDeleteDocument(filename);
                    MessageBox.Show("Registro actualizado con éxito");
                }
                else
                {
                    MessageBox.Show("Registro actualizado con éxito");
                    listaArchivosCreados.Remove(filename);//No debe eliminarse porque no pudo actualizarse el archivo en la base
                }
            }
        }
        #endregion
    }
}

