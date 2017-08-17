using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Command;
using SGPTWpf.Messages;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
using System;
using SGPTWpf.Messages.Navegacion.PDF;
using SGPTWpf.Messages.Genericos;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.ViewModel;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;

namespace SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio
{

    public sealed class gestorPDF : ViewModeloBase
    {
        #region Propiedades privadas

        private MetroDialogSettings configuracionDialogo;

        #region tokenDocumentoBinarioEnvio

        private string _tokenDocumentoBinarioEnvio;
        private string tokenDocumentoBinarioEnvio
        {
            get { return _tokenDocumentoBinarioEnvio; }
            set { _tokenDocumentoBinarioEnvio = value; }
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

        #region ViewModel Properties : listaEntidadSeleccion

        public const string listaEntidadSeleccionPropertyName = "listaEntidadSeleccion";

        private ObservableCollection<RepositorioModelo> _listaEntidadSeleccion;

        public ObservableCollection<RepositorioModelo> listaEntidadSeleccion
        {
            get
            {
                return _listaEntidadSeleccion;
            }
            set
            {
                if (_listaEntidadSeleccion == value) return;

                _listaEntidadSeleccion = value;

                RaisePropertyChanged(listaEntidadSeleccionPropertyName);
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

        private DialogCoordinator dlg;


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

        #region procesamiento Archivos

        #region ViewModel Properties : fileName

        public const string fileNamePropertyName = "fileName";

        private string _fileName;

        public string fileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                if (_fileName == value)
                {
                    return;
                }

                _fileName = value;
                RaisePropertyChanged(fileNamePropertyName);
            }
        }

        #endregion

        #endregion

        #region procesos en gestion

        #region ViewModel Properties : isBusy

        public const string isBusyPropertyName = "isBusy";

        private bool _isBusy;

        public bool isBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                if (_isBusy == value)
                {
                    return;
                }

                _isBusy = value;
                RaisePropertyChanged(isBusyPropertyName);
            }
        }

        #endregion

        #region visibilidadProcesando

        public const string visibilidadProcesandoPropertyName = "visibilidadProcesando";

        private Visibility _visibilidadProcesando;

        public Visibility visibilidadProcesando
        {
            get
            {
                return _visibilidadProcesando;
            }

            set
            {
                if (_visibilidadProcesando == value)
                {
                    return;
                }

                _visibilidadProcesando = value;
                RaisePropertyChanged(visibilidadProcesandoPropertyName);
            }
        }

        #endregion

        #region ViewModel Properties : accesibilidadLoguin

        public const string accesibilidadLoguinPropertyName = "accesibilidadLoguin";

        private bool _accesibilidadLoguin;

        public bool accesibilidadLoguin
        {
            get
            {
                return _accesibilidadLoguin;
            }

            set
            {
                if (_accesibilidadLoguin == value)
                {
                    return;
                }

                _accesibilidadLoguin = value;
                RaisePropertyChanged(accesibilidadLoguinPropertyName);
            }
        }

        #endregion

        #endregion


        #region ViewModel Properties publicas

        #region ViewModel Properties : Lista

        public const string ListaPropertyName = "Lista";

        private ObservableCollection<RepositorioModelo> _Lista;

        public ObservableCollection<RepositorioModelo> Lista
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

        #region visibilidadPdf

        public const string visibilidadPdfPropertyName = "visibilidadPdf";

        private Visibility _visibilidadPdf;

        public Visibility visibilidadPdf
        {
            get
            {
                return _visibilidadPdf;
            }

            set
            {
                if (_visibilidadPdf == value)
                {
                    return;
                }

                _visibilidadPdf = value;
                RaisePropertyChanged(visibilidadPdfPropertyName);
            }
        }

        #endregion

        #region visibilidadMenuPdf

        public const string visibilidadMenuPdfPropertyName = "visibilidadMenuPdf";

        private Visibility _visibilidadMenuPdf;

        public Visibility visibilidadMenuPdf
        {
            get
            {
                return _visibilidadMenuPdf;
            }

            set
            {
                if (_visibilidadMenuPdf == value)
                {
                    return;
                }

                _visibilidadMenuPdf = value;
                RaisePropertyChanged(visibilidadMenuPdfPropertyName);
            }
        }

        #endregion

        #region visibilidadVistaPdf

        public const string visibilidadVistaPdfPropertyName = "visibilidadVistaPdf";


        private bool _visibilidadVistaPdf = false;

        public bool visibilidadVistaPdf
        {
            get
            {
                return _visibilidadVistaPdf;
            }

            set
            {
                if (_visibilidadVistaPdf == value)
                {
                    return;
                }

                _visibilidadVistaPdf = value;
                RaisePropertyChanged(visibilidadVistaPdfPropertyName);
            }
        }


        #endregion

        #region Descripcion de norma

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

        #region  Primary key

        public const string idPropertyName = "id";

        private int _id = 0;

        public int idtei
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



        #region pdfrepositorio

        public const string pdfrepositorioPropertyName = "pdfrepositorio";

        private byte[] _pdfrepositorio = null;

        public byte[] pdfrepositorio
        {
            get
            {
                return _pdfrepositorio;
            }

            set
            {
                if (_pdfrepositorio == value)
                {
                    return;
                }

                _pdfrepositorio = value;
                RaisePropertyChanged(pdfrepositorioPropertyName);
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

        #region nombrearchivonormativa

        public const string nombrearchivonormativaPropertyName = "nombrearchivonormativa";

        private string _nombrearchivonormativa = string.Empty;

        public string nombrearchivonormativa
        {
            get
            {
                return _nombrearchivonormativa;
            }

            set
            {
                if (_nombrearchivonormativa == value)
                {
                    return;
                }

                _nombrearchivonormativa = value;
                RaisePropertyChanged(nombrearchivonormativaPropertyName);
            }
        }
        #endregion

        #region Entidad en uso

        #region ViewModel Property : currentEntidad

        public const string currentEntidadPropertyName = "currentEntidad";

        private RepositorioModelo _currentEntidad;

        public RepositorioModelo currentEntidad
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


        #region currentEntidadNueva//Se usa en el caso de se cree un registro

        public const string currentEntidadNuevaPropertyName = "currentEntidadNueva";

        private RepositorioModelo _currentEntidadNueva;
        public RepositorioModelo currentEntidadNueva
        {
            get
            {
                return _currentEntidadNueva;
            }

            set
            {
                if (_currentEntidadNueva == value) return;

                _currentEntidadNueva = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadNuevaPropertyName);
            }
        }
        #endregion

        #region ViewModel Property : currentEntidadNorma

        public const string currentEntidadNormaPropertyName = "currentEntidadNorma";

        private LegalNormaModelo _currentEntidadNorma;

        public LegalNormaModelo currentEntidadNorma
        {
            get
            {
                return _currentEntidadNorma;
            }

            set
            {
                if (_currentEntidadNorma == value) return;

                _currentEntidadNorma = value;

                // Update bindings, no broadcast
                RaisePropertyChanged(currentEntidadNormaPropertyName);
            }
        }

        #endregion

        #endregion

        #region viewTypePdf

        public const string viewTypePdfPropertyName = "viewTypePdf";

        private string _viewTypePdf = "SinglePage";

        public string viewTypePdf
        {
            get
            {
                return _viewTypePdf;
            }

            set
            {
                if (_viewTypePdf == value)
                {
                    return;
                }

                _viewTypePdf = value;
                RaisePropertyChanged(viewTypePdfPropertyName);
            }
        }

        #endregion


        #region viewPaginaPdf

        public const string viewPaginaPdfPropertyName = "viewPaginaPdf";

        private string _viewPaginaPdf = string.Empty;

        public string viewPaginaPdf
        {
            get
            {
                return _viewPaginaPdf;
            }

            set
            {
                if (_viewPaginaPdf == value)
                {
                    return;
                }

                _viewPaginaPdf = value;
                RaisePropertyChanged(viewPaginaPdfPropertyName);
            }
        }

        #endregion


        #region totalPaginas

        public const string totalPaginasPropertyName = "totalPaginas";

        private int _totalPaginas = 0;

        public int totalPaginas
        {
            get
            {
                return _totalPaginas;
            }

            set
            {
                if (_totalPaginas == value)
                {
                    return;
                }

                _totalPaginas = value;
                RaisePropertyChanged(totalPaginasPropertyName);
            }
        }

        #endregion

        #region paginaDestino

        public const string paginaDestinoPropertyName = "paginaDestino";

        private int _paginaDestino = 1;

        public int paginaDestino
        {
            get
            {
                return _paginaDestino;
            }

            set
            {
                if (_paginaDestino == value)
                {
                    return;
                }

                _paginaDestino = value;
                RaisePropertyChanged(paginaDestinoPropertyName);
            }
        }

        #endregion

        #endregion

        #region ViewModel Commands


        public RelayCommand ExportarPdfCommand { get; set; }
        public RelayCommand VerVistaCommand { get; set; }
        public RelayCommand cambiarVistaPageCommand { get; set; }
        public RelayCommand cambiarContinuaPageCommand { get; set; }
        public RelayCommand rotarIzquierdaCommand { get; set; }

        public RelayCommand rotarDerechaCommand { get; set; }

        public RelayCommand zoomInCommand { get; set; }
        public RelayCommand zoomOutCommand { get; set; }

        public RelayCommand paginaInicialCommand { get; set; }
        public RelayCommand paginaPreviaCommand { get; set; }
        public RelayCommand paginaSiguienteCommand { get; set; }
        public RelayCommand paginaUltimaCommand { get; set; }
        public RelayCommand paginaEscogerCommand { get; set; }

        public RelayCommand genericoCommand { get; set; }
        public RelayCommand<RepositorioModelo> SelectionChangedCommand { get; set; }

        #endregion

        #region ViewModel Public Methods

        #region Constructores

        public gestorPDF()
        {
        }

        public gestorPDF(RepositorioMsj msj)
        {
            configuracionDialogo = new MetroDialogSettings()
            {
                AnimateShow = false,
                AnimateHide = false
            };
            RegisterCommands();
            _tokenDocumentoBinarioEnvio = "DocumentoBinario";
            _tokenRecepcionPadre= "mandatoMenu";
            dlg = new DialogCoordinator();
            //Suscribiendo al tipo de mensaje
            //Messenger.Default.Register<RepositorioMsj>(this, (normativaPDFmensaje) => ControlNormativaPDFmensaje(normativaPDFmensaje));
            Messenger.Default.Register<TotalPagesMessages>(this, (totalPagesMessages) => ControlTotalPagesMessages(totalPagesMessages));
            Messenger.Default.Register<CurrentPageMensaje>(this, (currentPageMensaje) => ControlCurrentPageMensaje(currentPageMensaje));
            Messenger.Default.Register<bool>(this, tokenRecepcionPadre,(msjMenu) => ControlmsjMenu(msjMenu));

            visibilidadPdf = Visibility.Collapsed;
            visibilidadMenuPdf = Visibility.Visible;
            #region control de procesado

            _visibilidadProcesando = Visibility.Collapsed;
            _accesibilidadLoguin = true;
            _accesibilidadWindow = false;
            _isBusy = false;

            #endregion

            fileName = "";
            ControlNormativaPDFmensaje(msj);
        }

        private void ControlmsjMenu(bool msjMenu)
        {
            if (msjMenu)
            {
                visibilidadMenuPdf = Visibility.Visible;
            }
            else
            {
                visibilidadMenuPdf = Visibility.Collapsed;
            }
        }

        #region procesando archivos pesados

        private void ControlNormativaPDFmensaje(RepositorioMsj normativaPDFmensaje)
        {
            //Basado en  capítulo 8 Microsoft 10272
            Mouse.OverrideCursor = Cursors.Wait;
            isBusy = true;
            currentUsuario = normativaPDFmensaje.usuarioModelo;
            visibilidadProcesando = Visibility.Visible;
            //Asignacion de  entidades
            currentEntidad = normativaPDFmensaje.entidadTrasladada;
            pdfrepositorio = currentEntidad.pdfrepositorio;
                    if (pdfrepositorio != null)
                    {
                        enviarBinario();
                        visibilidadPdf = Visibility.Visible;
                    }
                    else
                    {
                        mensaje();
                        //await dlg.ShowMessageAsync(this, "No se pudo localizar el registro", "");
                    }
                    visibilidadPdf = Visibility.Collapsed;
                    Mouse.OverrideCursor = null;
                    visibilidadProcesando = Visibility.Collapsed;
                    isBusy = false;


        }

        #endregion


        private async void mensaje()
        {
            await dlg.ShowMessageAsync(this, "No se pudo localizar el registro", "");
        }

        private void ControlCurrentPageMensaje(CurrentPageMensaje currentPageMensaje)
        {
            paginaDestino = currentPageMensaje.currentPage;
        }

        private void ControlTotalPagesMessages(TotalPagesMessages totalPagesMessages)
        {
            totalPaginas = totalPagesMessages.totalPages;
        }


        private async void enviarBinario()
        {
            if (!(string.IsNullOrEmpty(pdfrepositorio.ToString())))
            {
                ArchivoBinario elemento = new ArchivoBinario();
                elemento.archivoBinario = pdfrepositorio;
                Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
            }
            else
            {
                await dlg.ShowMessageAsync(this, "No se envia el binario por ser vacio ", "");
            }
        }
        private void enviarBinarioNulo()
        {
            //Se envia para limpiar el contenido del PDF mostrado
            ArchivoBinario elemento = new ArchivoBinario();
            elemento.archivoBinario = null;
            Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
        }
        #endregion

        #region Envio mensajes

        #endregion

        public bool CanSave()
        {
            return !(currentEntidad.idrepositorio == 0) &&
                   !string.IsNullOrEmpty(currentEntidad.nombrerepositorio);
        }

        #region Verificaciones

        public void Actualizar(ObservableCollection<RepositorioModelo> listaEntidad)
        {
            Lista = listaEntidad;
        }

        public bool CanDelete()
        {
            return currentEntidad != null;
        }

        public bool CanCommand()
        {
            try
            {
                return currentEntidad.idrepositorio != 0;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #endregion

        #endregion

        #region ViewModel Private Methods

        private void RegisterCommands()
        {
            VerVistaCommand = new RelayCommand(VerVistaContextual);
            cambiarVistaPageCommand = new RelayCommand(cambiarVistaPage, CanCommand);
            ExportarPdfCommand = new RelayCommand(ExportarPdf, CanCommand);
            cambiarContinuaPageCommand = new RelayCommand(cambiarContinuaPage, CanCommand);
            rotarIzquierdaCommand = new RelayCommand(rotarIzquierda, CanCommand);
            rotarDerechaCommand = new RelayCommand(rotarDerecha, CanCommand);
            zoomInCommand = new RelayCommand(zoomIn, CanCommand);
            zoomOutCommand = new RelayCommand(zoomOut, CanCommand);
            //Tratamiento de navegacion
            paginaInicialCommand = new RelayCommand(paginaInicial, CanCommand);
            paginaPreviaCommand = new RelayCommand(paginaPrevia, CanCommand);
            paginaSiguienteCommand = new RelayCommand(paginaSiguiente, CanCommand);
            paginaUltimaCommand = new RelayCommand(paginaUltima, CanCommand);
            paginaEscogerCommand = new RelayCommand(paginaEscoger, CanCommand);
            genericoCommand = new RelayCommand(generico, CanCommand);

            SelectionChangedCommand = new RelayCommand<RepositorioModelo>(entidad =>
            {
                if (entidad == null) return;
                currentEntidad = entidad;
            });
        }

        private void ExportarPdf()
        {
            bool resultado = false;
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (object sender, DoWorkEventArgs e) =>
            {
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //fileName = Path.g.GetTempPath() + currentEntidad.nombrepdf;
                if (!string.IsNullOrEmpty(mydocpath))
                {
                    //https://msdn.microsoft.com/es-es/library/6ka1wd3w(v=vs.110).aspx
                    fileName = mydocpath + @"\" + currentEntidad.nombrepdf;
                }
                else
                {
                    //http://stackoverflow.com/questions/7867254/create-a-temporary-file-from-stream-object-in-c-sharp
                    fileName = Path.GetTempPath() + currentEntidad.nombrepdf;
                }
                try
                {
                    File.WriteAllBytes(fileName, currentEntidad.pdfrepositorio);
                    //listaArchivosCreados.Add(fileName);
                    //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                    Process.Start(fileName);
                    //this.CloseWindow();
                    resultado = true;
                }
                catch (Exception g)
                {
                    mensajeFalloPdf(g);
                    //dlg.ShowMessageAsync(this, "No tiene una aplicación instalada que maneje el archivo " + k.Message, "");
                    resultado = false;
                }
            };
            worker.RunWorkerCompleted += (object sender, RunWorkerCompletedEventArgs e) =>
            {
                if (!(resultado))
                {
                    // mensajeFalloPdf(e);
                }
            };
            worker.RunWorkerAsync();
            worker.Dispose();
        }

        private async void mensajeFalloPdf(RunWorkerCompletedEventArgs e)
        {
            await dlg.ShowMessageAsync(this, "No se pudo exportar el archivo " + e, "");
        }

        private async void mensajeFalloPdf(Exception e)
        {
            await dlg.ShowMessageAsync(this, "No se pudo exportar el archivo porque hay otro archivo con el mismo nombre estando abierto" + e.Message, "");
        }


        private void generico()
        {
            //Nada solo para bloquear
        }

        private async void paginaEscoger()
        {
            if (!(paginaDestino == 0) || paginaDestino <= 0)
            {
                if (paginaDestino <= totalPaginas)
                {
                    goToPaginaMensaje(paginaDestino);
                }
                else
                {
                    await dlg.ShowMessageAsync(this, "El número de página debe ser menor al total", "");
                }
            }
            else
            {
                await dlg.ShowMessageAsync(this, "Debe ingresar el número de página y mayor que cero", "");
            }
        }

        private bool CanEscoger()
        {
            return (!(paginaDestino == 0) && paginaDestino <= totalPaginas && paginaDestino > 0);
        }

        private void paginaInicial()
        {
            goToPaginaMensaje(1);
        }
        private void paginaPrevia()
        {
            goToPaginaMensaje(2);
        }
        private void paginaSiguiente()
        {
            goToPaginaMensaje(3);
        }
        private void paginaUltima()
        {
            goToPaginaMensaje(4);
        }

        private void cambiarVistaPage()
        {
            if (viewTypePdf == "SinglePage")
            {
                viewTypePdf = "BookView";
            }
            else
            {
                if (viewTypePdf == "BookView")
                {
                    viewTypePdf = "Facing";
                }
                else
                {
                    viewTypePdf = "SinglePage";
                }
            }
            tipoVistaMensaje(viewTypePdf);
        }

        private void tipoVistaMensaje(string seleccion)
        {
            {
                //Se crea el mensaje
                ViewTypeMessages elemento = new ViewTypeMessages();
                elemento.viewType = seleccion;
                Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
            }
        }

        private void goToPaginaMensaje(int seleccion)
        {
            {
                //Se crea el mensaje
                PaginasPdfMensaje elemento = new PaginasPdfMensaje();
                elemento.Opcion = seleccion;
                Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
            }
        }

        private void rotarDerecha()
        {
            {
                //Se crea el mensaje
                RotarDerechaMensaje elemento = new RotarDerechaMensaje();
                elemento.rotarDerecha = true;
                Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
            }
        }

        private void zoomIn()
        {
            ZoomInMensaje elemento = new ZoomInMensaje();
            elemento.zoomIn = true;
            Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
        }

        private void zoomOut()
        {
            ZoomOutMensaje elemento = new ZoomOutMensaje();
            elemento.zoomOut = true;
            Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
        }

        private void rotarIzquierda()
        {
            {
                //Se crea el mensaje
                RotarIzquierdaMensaje elemento = new RotarIzquierdaMensaje();
                elemento.rotarIzquierda = true;
                Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
            }
        }


        private void cambiarContinuaPage()
        {
            if (viewPaginaPdf == "ContinuousPageRows")
            {
                viewPaginaPdf = "SinglePageRow";
            }
            else
            {
                viewPaginaPdf = "ContinuousPageRows";
            }
            cambiarPresentacionPagina(viewPaginaPdf);
        }


        private void cambiarPresentacionPagina(string pageRowDisplay)
        {
            {
                //Se crea el mensaje
                PageRowDisplayMessages elemento = new PageRowDisplayMessages();
                elemento.PageRowDisplay = pageRowDisplay;
                Messenger.Default.Send(elemento, tokenDocumentoBinarioEnvio);
            }
        }
        private void VerVistaContextual()
        {
            visibilidadVistaPdf = true;
        }


        #endregion

        #region Gestion de comandos

        private void iniciarComando()
        {
            //cursorWindow = Cursors.Wait;
            Mouse.OverrideCursor = Cursors.Wait;
            accesibilidadWindow = false;
        }

        private void finComando()
        {
            //cursorWindow = null;
            Mouse.OverrideCursor = null;
            accesibilidadWindow = true;
        }

        #endregion Fin de comando
    }
}