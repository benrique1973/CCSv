using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using SGPTWpf.Messages.Administracion.NormaLegal;
using MoonPdfLib.MuPdf;
using SGPTWpf.Messages.Navegacion.PDF;
using System;
using MahApps.Metro.Controls.Dialogs;
using MoonPdfLib;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.Views.Principales.Normas
{

    public partial class GenericoNormaConsultaView : UserControl
    {
        public string tokenNormaLegalBinarioRecepcion = "NormaLegalBinario";
        private bool apertura = false;
        private bool controlPageRowDisplay = false;
        private DialogCoordinator dlg;
        internal MoonPdfPanel MoonPdfPanel { get { return this.moonPdfPanel; } }
        public GenericoNormaConsultaView()
        {
            InitializeComponent();
            dlg = new DialogCoordinator();
            apertura = false;
            controlPageRowDisplay = false;

            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = ancho - 205;
            this.Height = PrincipalAlterna.largoFrame - 40;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width;

            datosConsulta.MinHeight = Height * 0.5;
            datosConsulta.Height = Height - 15;
            datosConsulta.MaxHeight = Height - 15;

            gtiDatosNorma.Width = Width - 5;
            gtiDatosNorma.MinHeight = Height * 0.5;
            gtiDatosNorma.MaxHeight = Height - 60;
            gtiDatosNorma.Height = Height - 5;

            //Suscribiendo mensaje con el binario
            Messenger.Default.Register<ArchivoBinario>(this, tokenNormaLegalBinarioRecepcion,(normativaPdfBinario) => ControlNormativaPdfBinario(normativaPdfBinario));
            Messenger.Default.Register<RotarDerechaMensaje>(this, (rotarDerechaMensaje) => ControlRotarDerechaMensaje(rotarDerechaMensaje));
            Messenger.Default.Register<RotarIzquierdaMensaje>(this, (rotarIzquierdaMensaje) => ControlRotarIzquierdaMensaje(rotarIzquierdaMensaje));
            Messenger.Default.Register<ZoomInMensaje>(this, (zoomInMensaje) => ControlZoomInMensaje(zoomInMensaje));
            Messenger.Default.Register<ZoomOutMensaje>(this, (zoomOutMensaje) => ControlZoomOutMensaje(zoomOutMensaje));
            Messenger.Default.Register<PaginasPdfMensaje>(this, (paginasPdfMensaje) => ControlPaginasPdfMensaje(paginasPdfMensaje));
            Messenger.Default.Register<PageRowDisplayMessages>(this, (pageRowDisplayMessages) => ControlPageRowDisplayMessages(pageRowDisplayMessages));
            Messenger.Default.Register<ViewTypeMessages>(this, (viewTypeMessages) => ControlViewTypeMessages(viewTypeMessages));

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
            try
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
                controlPageRowDisplay = true;
            }
            catch (Exception e)
            {
                moonPdfPanel.GotoPage(1);
                comunicarPaginaEnUso();
                dlg.ShowMessageAsync(this, "Error traslado de página verifique " + e.Message, "");
            }
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
            catch (Exception e)
            {
                //moonPdfPanel.GotoPage(1);
                comunicarPaginaEnUso();
                dlg.ShowMessageAsync(this, "Error traslado de página verifique " + e.Message, "");
            }

        }

        private void ControlZoomOutMensaje(ZoomOutMensaje zoomOutMensaje)
        {
            try
            {
                moonPdfPanel.ZoomOut();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "Error zoomOut la izquierda verifique " + e.Message, "");
            }
        }

        private void ControlZoomInMensaje(ZoomInMensaje zoomInMensaje)
        {
            try
            {
                moonPdfPanel.ZoomIn();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "Error en el zoom in verifique " + e.Message, "");
            }
        }

        private void ControlRotarIzquierdaMensaje(RotarIzquierdaMensaje rotarIzquierdaMensaje)
        {
            try
            {
                moonPdfPanel.RotateLeft();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "Error rotado a la izquierda verifique " + e.Message, "");
            }
        }

        private void ControlRotarDerechaMensaje(RotarDerechaMensaje rotarDerechaMensaje)
        {
            try
            {
                moonPdfPanel.RotateRight();
            }
            catch (Exception e)
            {
                dlg.ShowMessageAsync(this, "Error rotado a la derecha verifique " + e.Message, "");
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
                    moonPdfPanel.Visibility = System.Windows.Visibility.Collapsed;
                    apertura = false;
                }
            }
            catch (Exception )
            {
                //dlg.ShowMessageAsync(this, "Error en apertura de archivo " , "");
                moonPdfPanel.Visibility = System.Windows.Visibility.Collapsed;
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
                catch (Exception e)
                {
                    dlg.ShowMessageAsync(this, "Error en totales de pagina " + e.Message, "");
                    CurrentPageMensaje elemento = new CurrentPageMensaje();
                    elemento.currentPage = 1;
                    Messenger.Default.Send(elemento);
                }
            }
        }
        private void moonPdfPanel_ScrollChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            if ((controlPageRowDisplay))
            {
                controlPageRowDisplay = false;
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

