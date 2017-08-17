using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using MoonPdfLib;
using MoonPdfLib.MuPdf;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Messages.Navegacion.PDF;
using SGPTWpf.Views.Compartidas;
using System;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio
{

    public partial class PDFContenidoView : UserControl
    {
        #region tokenDocumentoBinarioRecepcion

        private string _tokenDocumentoBinarioRecepcion;
        private string tokenDocumentoBinarioRecepcion
        {
            get { return _tokenDocumentoBinarioRecepcion; }
            set { _tokenDocumentoBinarioRecepcion = value; }
        }
        #endregion

        private bool apertura = false;
        private bool cambioPageRowDisplay = false;
        private DialogCoordinator dlg;
        internal MoonPdfPanel MoonPdfPanel { get { return this.moonPdfPanel; } }
        public PDFContenidoView()
        {
            InitializeComponent();
            tokenDocumentoBinarioRecepcion = "DocumentoBinario";
            dlg = new DialogCoordinator();
            apertura = false;
            cambioPageRowDisplay = false;
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = 640;
            this.Height = 850;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width;
            datosConsulta.Height = Height;
            datosConsulta.MaxHeight = Height;

            gtiDatosNorma.Width = Width-1;
            gtiDatosNorma.MaxHeight = Height-57;
            gtiDatosNorma.Height = Height-57;


            //Suscribiendo mensaje con el binario
            Messenger.Default.Register<ArchivoBinario>(this, tokenDocumentoBinarioRecepcion, (normativaPdfBinario) => ControlNormativaPdfBinario(normativaPdfBinario));
            Messenger.Default.Register<RotarDerechaMensaje>(this, tokenDocumentoBinarioRecepcion, (rotarDerechaMensaje) => ControlRotarDerechaMensaje(rotarDerechaMensaje));
            Messenger.Default.Register<RotarIzquierdaMensaje>(this, tokenDocumentoBinarioRecepcion, (rotarIzquierdaMensaje) => ControlRotarIzquierdaMensaje(rotarIzquierdaMensaje));
            Messenger.Default.Register<ZoomInMensaje>(this, tokenDocumentoBinarioRecepcion, (zoomInMensaje) => ControlZoomInMensaje(zoomInMensaje));
            Messenger.Default.Register<ZoomOutMensaje>(this, tokenDocumentoBinarioRecepcion, (zoomOutMensaje) => ControlZoomOutMensaje(zoomOutMensaje));
            Messenger.Default.Register<PaginasPdfMensaje>(this, tokenDocumentoBinarioRecepcion, (paginasPdfMensaje) => ControlPaginasPdfMensaje(paginasPdfMensaje));
            Messenger.Default.Register<PageRowDisplayMessages>(this, tokenDocumentoBinarioRecepcion, (pageRowDisplayMessages) => ControlPageRowDisplayMessages(pageRowDisplayMessages));
            Messenger.Default.Register<ViewTypeMessages>(this, tokenDocumentoBinarioRecepcion, (viewTypeMessages) => ControlViewTypeMessages(viewTypeMessages));

        }

        private void ControlViewTypeMessages(ViewTypeMessages viewTypeMessages)
        {
            switch (viewTypeMessages.viewType)
            {
                case "SinglePage":
                    moonPdfPanel.ViewType = MoonPdfLib.ViewType.SinglePage;
                    break;
                case "BookView":
                    moonPdfPanel.ViewType = MoonPdfLib.ViewType.BookView;
                    break;
                case "Facing":
                    moonPdfPanel.ViewType = MoonPdfLib.ViewType.Facing;
                    break;
            }
            var visibilidad = moonPdfPanel.Visibility.ToString();
        }

        private void ControlPageRowDisplayMessages(PageRowDisplayMessages pageRowDisplayMessages)
        {

            switch (pageRowDisplayMessages.PageRowDisplay)
            {
                case "ContinuousPageRows":
                    moonPdfPanel.PageRowDisplay = MoonPdfLib.PageRowDisplayType.ContinuousPageRows;
                    break;
                case "SinglePageRow":
                    moonPdfPanel.PageRowDisplay = MoonPdfLib.PageRowDisplayType.SinglePageRow;
                    break;
            }
            cambioPageRowDisplay = true;
        }

        private void ControlPaginasPdfMensaje(PaginasPdfMensaje paginasPdfMensaje)
        {
            int actual = moonPdfPanel.GetCurrentPageNumber();
            try
            {
                switch (paginasPdfMensaje.Opcion.ToString())
                {
                    case "1":
                        moonPdfPanel.GotoFirstPage();
                        break;
                    case "2":
                        moonPdfPanel.GotoPreviousPage();
                        break;
                    case "3":
                        moonPdfPanel.GotoNextPage();
                        break;
                    case "4":
                        moonPdfPanel.GotoLastPage();
                        break;
                    default:
                        moonPdfPanel.GotoPage(paginasPdfMensaje.Opcion);
                        break;
                }
                comunicarPaginaEnUso();
            }
            catch (Exception)
            {
                //moonPdfPanel.GotoPage(1);
                //comunicarPaginaEnUso();
                // dlg.ShowMessageAsync(this, "Error traslado de página verifique " + e.Message, "");
            }

        }

        private void ControlZoomOutMensaje(ZoomOutMensaje zoomOutMensaje)
        {
            try
            {
                moonPdfPanel.ZoomOut();
            }
            catch (Exception)
            {
                // dlg.ShowMessageAsync(this, "Error zoomOut la izquierda verifique " + e.Message, "");
            }
        }

        private void ControlZoomInMensaje(ZoomInMensaje zoomInMensaje)
        {
            try
            {
                moonPdfPanel.ZoomIn();
            }
            catch (Exception)
            {
                // await dlg.ShowMessageAsync(this, "Error en el zoom in verifique " + e.Message, "");
            }
        }

        private void ControlRotarIzquierdaMensaje(RotarIzquierdaMensaje rotarIzquierdaMensaje)
        {
            try
            {
                moonPdfPanel.RotateLeft();
            }
            catch (Exception)
            {
                //await dlg.ShowMessageAsync(this, "Error rotado a la izquierda verifique " + e.Message, "");
            }
        }

        private void ControlRotarDerechaMensaje(RotarDerechaMensaje rotarDerechaMensaje)
        {
            try
            {
                moonPdfPanel.RotateRight();
            }
            catch (Exception)
            {
                //dlg.ShowMessageAsync(this, "Error rotado a la derecha verifique " + e.Message, "");
            }
        }

        private void ControlNormativaPdfBinario(ArchivoBinario normativaPdfBinario)
        {
            try
            {
                if (!(string.IsNullOrEmpty(normativaPdfBinario.archivoBinario.ToString())))
                {
                    var source = new MemorySource(normativaPdfBinario.archivoBinario);
                    moonPdfPanel.Open(source);
                    moonPdfPanel.Visibility = System.Windows.Visibility.Visible;
                    comunicarTotalPaginas();
                    apertura = true;
                }
                else
                {
                    moonPdfPanel.Visibility = System.Windows.Visibility.Hidden;
                    apertura = false;
                }
            }
            catch (Exception)
            {
                //dlg.ShowMessageAsync(this, "Error en apertura de archivo " + e.Message, "");
                moonPdfPanel.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        private void comunicarTotalPaginas()
        {
            {
                //Se crea el mensaje
                TotalPagesMessages elemento = new TotalPagesMessages();
                elemento.totalPages = moonPdfPanel.TotalPages;
                Messenger.Default.Send(elemento);
            }
        }

        private void comunicarPaginaEnUso()
        {
            {
                //Se crea el mensaje
                try
                {
                    CurrentPageMensaje elemento = new CurrentPageMensaje();
                    elemento.currentPage = moonPdfPanel.GetCurrentPageNumber();
                    Messenger.Default.Send(elemento);
                }
                catch (Exception)
                {
                    CurrentPageMensaje elemento = new CurrentPageMensaje();
                    elemento.currentPage = 1;
                    Messenger.Default.Send(elemento);
                }
            }
        }
        private void moonPdfPanel_ScrollChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!(cambioPageRowDisplay))
            {
                cambioPageRowDisplay = false;
            }
            else
            {
                if (apertura)
                {
                    comunicarPaginaEnUso();
                }
            }
        }
    }
}
