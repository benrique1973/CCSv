using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Documentos.Consulta;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Ajustes;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Marcas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Notas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Centralizadora;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.Views.Principales.Documentos.Consulta;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Ajustes;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Marcas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Notas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Centralizadora;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Cuestionarios;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Agenda;
using SGPTWpf.Views.Compartidas;
using System;
using System.Windows;

namespace SGPTWpf.AttachedBehaviors
{
    public static class WFBIndices
    {
        #region Private Section
        private static string vista = string.Empty;
        private static string vistaAnterior = string.Empty;
        private static bool controlStrin = true;

        #endregion

        #region Name Dependency Property

        public static readonly DependencyProperty NameProperty;

        public static void SetName(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(NameProperty, value);
        }

        public static string GetName(DependencyObject DepObject)
        {
            return (string)DepObject.GetValue(NameProperty);
        }

        #endregion

        #region WFBIndices Constructor

        static WFBIndices()
        {
            NameProperty = DependencyProperty.RegisterAttached("Name",
                                                               typeof(string),
                                                               typeof(WFBIndices),
                                                               new UIPropertyMetadata(String.Empty, IsFactoryStart));
        }

        #endregion

        #region IsFactoryStart

        private static void IsFactoryStart(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {

            if (e.NewValue is String && String.IsNullOrEmpty((string)e.NewValue) == false)
            {
                if (controlStrin)
                {
                    vista = e.NewValue.ToString();
                    controlStrin = false;
                }
                else
                {
                    vistaAnterior = e.NewValue.ToString();
                    controlStrin = true;
                }
                if (vistaAnterior == vista)
                {
                    //Repetido
                }
                else
                {
                    var crearVentana = new MetroWindow();
                    string encabezado = "";
                    double ancho = PrincipalAlterna.ancho;
                    double largo = PrincipalAlterna.largo;
                    crearVentana.WindowStartupLocation = WindowStartupLocation.Manual;

                    switch (e.NewValue.ToString())
                    {
                        /*Casos de Encargos planificacion programas */

                        case "TipoCarpetaModeloImportarView":
                            encabezado = "Importacion de carpetas de auditoría";
                            crearVentana = new ImportarSeleccionView();
                            crearVentana.DataContext = new IndiceControllerViewModel("Documentacion");
                            crearVentana.MinHeight = 150;
                            crearVentana.MinWidth = 250;
                            break;
                        case "TipoCarpetaModeloCrearview":
                            encabezado = "Creación de carpeta de auditoría";
                            crearVentana = new IndiceCrudView();
                            crearVentana.DataContext = new IndiceControllerViewModel("Documentacion");
                            crearVentana.MinHeight = 150;
                            crearVentana.MinWidth = 250;
                            break;
                        case "TipoCarpetaModeloEditarView":
                            encabezado = "Actualización de carpeta de auditoría";
                            crearVentana = new IndiceCrudView();
                            crearVentana.DataContext = new IndiceControllerViewModel("Documentacion");
                            crearVentana.MinHeight = 150;
                            crearVentana.MinWidth = 250;
                            break;
                        case "TipoCarpetaModeloConsultarView":
                            encabezado = "Consulta de carpeta de auditoría";
                            crearVentana = new IndiceCrudView();
                            crearVentana.DataContext = new IndiceControllerViewModel("Documentacion");
                            crearVentana.MinHeight = 150;
                            crearVentana.MinWidth = 250;
                            break;
                        case "DocumentacionTipoCarpetaModeloConsultarView":
                            //Encargos/documentacion/indices/
                            encabezado = "Consulta de carpeta de auditoría";
                            crearVentana = new IndiceCrudView();
                            crearVentana.DataContext = new IndiceControllerViewModel("DocumentacionIndiceModelo");
                            crearVentana.MinHeight = 150;
                            crearVentana.MinWidth = 250;
                            break;
                        case "CierreTipoCarpetaModeloConsultarView":
                            //Encargos/documentacion/indices/
                            encabezado = "Consulta de carpeta de auditoría";
                            crearVentana = new IndiceCrudView();
                            crearVentana.DataContext = new IndiceControllerViewModel("DocumentacionIndiceModelo");
                            crearVentana.MinHeight = 150;
                            crearVentana.MinWidth = 250;
                            break;
                        case "IndiceEncargoPlanVistaPreviaView":
                            encabezado = "Vista preliminar de contenido de carpeta de auditoría";
                            crearVentana = new IndiceViewImpresion();
                            crearVentana.DataContext = new IndicePresentacionViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Top = 0;
                            break;

                        case "IndiceDocumentosVistaPreviaView":
                            encabezado = "Vista preliminar de contenido de carpeta de auditoría";
                            crearVentana = new IndiceViewImpresion();
                            crearVentana.DataContext = new IndicePresentacionViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Top = 0;
                            break;
                        case "PortadaIndiceDocumentosVistaPreviaView":
                            encabezado = "Vista preliminar de portada de carpeta de auditoría";
                            crearVentana = new PortadaView();
                            crearVentana.DataContext = new IndicePortadaViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Top = 0;
                            break;
                        case "PortadaIndiceDocumentosImprimirPreviaView":
                            encabezado = "Vista preliminar de portada de carpeta de auditoría";
                            crearVentana = new PortadaView();
                            crearVentana.DataContext = new IndicePortadaViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Top = 0;
                            break;
                        case "IndiceDocumentosImprimirPreviaView":
                            encabezado = "Vista preliminar de contenido de carpeta de auditoría";
                            crearVentana = new IndiceViewImpresion();
                            crearVentana.DataContext = new IndicePresentacionViewModel();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Top = 0;
                            break;
                        /*Casos detalle*/
                        case "DetalleIndiceModeloCrearview":
                            encabezado = "Creación de contenido de índices";
                            crearVentana = new DetalleIndiceCrudView();
                            crearVentana.DataContext = new DetalleIndiceControllerViewModel("PlaneacionIndices");
                            crearVentana.MinWidth = 250;
                            crearVentana.MinHeight = 150;
                            break;
                        case "DetalleIndiceModeloEditarview":
                            encabezado = "Actualización de contenido de índices";
                            crearVentana = new DetalleIndiceCrudView();
                            crearVentana.DataContext = new DetalleIndiceControllerViewModel("PlaneacionIndices");
                            crearVentana.MinWidth = 250;
                            crearVentana.MinHeight = 150;
                            break;
                        case "DetalleIndiceModeloConsultarview":
                            encabezado = "Consulta de contenido de índices";
                            crearVentana = new DetalleIndiceCrudView();
                            crearVentana.DataContext = new DetalleIndiceControllerViewModel("PlaneacionIndices");
                            crearVentana.MinWidth = 250;
                            crearVentana.MinHeight = 150;
                            break;

                            
                        case "DetalleIndiceModeloReferenciarview":
                            encabezado = "Referenciar contenido al índice de  papeles";
                            crearVentana = new IndiceReferenciacionView();
                            crearVentana.DataContext = new DetalleIndiceControllerViewModel("PlaneacionIndices");
                            crearVentana.MinWidth = 250;
                            crearVentana.MinHeight = 150;
                            break;

                        //Vistas de referencias
                        case "ProgramaModeloVerProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Height = largo;

                            crearVentana.DataContext = new ProgramaPresentacionViewModel("Ejecucion");
                            break;
                        //Referencia cuestionario    
                        case "CuestionarioModeloVerCuestionarioView":
                            encabezado = "Vista preliminar del cuestionario de auditoría";
                            crearVentana = new CuestionarioViewImpresion();
                            crearVentana.MinHeight = largo * 0.30;
                            crearVentana.MinWidth = ancho * 0.20;
                            crearVentana.Width = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Height = largo;

                            crearVentana.DataContext = new CuestionarioPresentacionViewModel("Ejecucion");
                            break;

                        case "MatrizRiesgoModeloVerView":
                            encabezado = "Vista preliminar de matriz";
                            crearVentana = new RiesgoViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RiesgoPresentacionViewModel();
                            break;
                        case "MatrizRiesgoModeloImprimirView":
                            encabezado = "Vista preliminar de matriz para impresión";
                            crearVentana = new RiesgoViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RiesgoPresentacionViewModel();
                            //encabezado = "Vista preliminar de matriz";
                            //crearVentana = new ReportesView();
                            //crearVentana.MinHeight = largo * 0.15;
                            //crearVentana.MinWidth = ancho * 0.15;
                            //crearVentana.MaxWidth = ancho;
                            //crearVentana.MaxHeight = largo;
                            //crearVentana.DataContext = new ReportesViewModel();
                            break;
                        //case "ProgramaModeloImprimirProgramaView":
                        //    encabezado = "Vista preliminar del programa de auditoría";
                        //    crearVentana = new ReportesView();
                        //    crearVentana.MinHeight = largo * 0.15;
                        //    crearVentana.MinWidth = ancho * 0.15;
                        //    crearVentana.MaxWidth = ancho;
                        //    crearVentana.MaxHeight = largo;
                        //    //crearVentana.Height = largo;

                        //    crearVentana.DataContext = new ReportesViewModel();
                        //    break;
                        //case "CuestionarioModeloImprimirCuestionarioView":
                        //    encabezado = "Vista preliminar del cuestionario de auditoría";
                        //    crearVentana = new ReportesView();
                        //    crearVentana.MinHeight = largo * 0.15;
                        //    crearVentana.MinWidth = ancho * 0.15;
                        //    crearVentana.MaxWidth = ancho;
                        //    crearVentana.MaxHeight = largo;
                        //    crearVentana.DataContext = new ReportesViewModel();
                        //    break;
                        //Vistas de referencias
                        case "ProgramaModeloImprimirProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas.ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.Name = "Cuestionario";
                            crearVentana.DataContext = new ProgramaPresentacionViewModel("Ejecucion");
                            break;
                        //Referencia cuestionario    
                        case "CuestionarioModeloImprimirCuestionarioView":
                            encabezado = "Vista preliminar del cuestionario de auditoría";
                            crearVentana = new CuestionarioViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;

                            crearVentana.DataContext = new CuestionarioPresentacionViewModel("Ejecucion");
                            break;
                        case "ProgramaModeloConsultarProgramaView":
                            encabezado = "Vista preliminar del programa de auditoría";
                            crearVentana = new SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas.ProgramaViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;

                            crearVentana.DataContext = new ProgramaPresentacionViewModel("Ejecucion");
                            break;
                        //Referencia cuestionario    
                        case "CuestionarioModeloConsultarCuestionarioView":
                            encabezado = "Vista preliminar del cuestionario de auditoría";
                            crearVentana = new CuestionarioViewImpresion();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;

                            crearVentana.DataContext = new CuestionarioPresentacionViewModel("Ejecucion");
                            break;
                        case "RepositorioVistaPDFPreviaView":
                            encabezado = "Documento escaneado";
                            crearVentana = new PDFView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioPDFControllerViewModel("IndiceDocumentacion");
                            break;
                        case "RepositorioImprimirPDFPreviaView":
                            encabezado = "Documento escaneado";
                            crearVentana = new PDFView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new RepositorioPDFControllerViewModel("IndiceDocumentacion");
                            break;
                        case "CedulaMarcasVistaPDFPreviaView":
                            encabezado = "Vista de Marcas";
                            crearVentana = new MarcasImpresionView();
                            crearVentana.DataContext = new MarcasPresentacionViewModel("IndiceCedulaMarcas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaMarcasImprimirPDFPreviaView":
                            encabezado = "Vista de Marcas";
                            crearVentana = new MarcasImpresionView();
                            crearVentana.DataContext = new MarcasPresentacionViewModel("ImprimirIndiceCedulaMarcas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaHallazgosVerPDFPreviaView":
                            encabezado = "Vista de Hallazgos";
                            crearVentana = new HallazgosImpresionView();
                            crearVentana.DataContext = new HallazgosPresentacionViewModel("IndiceCedulaHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaHallazgosImprimirPDFPreviaView":
                            encabezado = "Vista de Hallazgos";
                            crearVentana = new HallazgosImpresionView();
                            crearVentana.DataContext = new HallazgosPresentacionViewModel("ImprimirIndiceCedulaHallazgos");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAgendaVerPDFPreviaView":
                            encabezado = "Vista de Agenda";
                            crearVentana = new AgendaPresentacionView();
                            crearVentana.DataContext = new AgendaPresentacionViewModel("IndiceCedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAgendaImprimirPDFPreviaView":
                            encabezado = "Vista de Agenda";
                            crearVentana = new AgendaPresentacionView();
                            crearVentana.DataContext = new AgendaPresentacionViewModel("ImprimirIndiceCedulaAgenda");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        #region Cierre
                        case "IndiceModeloCerrarView":
                            encabezado = "Cierre del documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new IndiceControllerViewModel("IndiceModeloCerrar");
                            break;
                        case "IndiceModeloSupervisarView":
                            encabezado = "Supervisa y aprueba el documento";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new IndiceControllerViewModel("IndiceModeloCerrar");
                            break;
                        case "IndiceModeloAprobarView":
                            encabezado = "Terminación del papel de trabajo";
                            crearVentana = new ReferenciarMatrizRiesgoView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new IndiceControllerViewModel("IndiceModeloCerrar");
                            break;
                        case "CedulaAjustesYReclasificacionesMsjImprimirPDFPreviaView":
                            encabezado = "Vista de ajustes y reclasificaciones";
                            crearVentana = new AjustesPresentacionView();
                            crearVentana.DataContext = new AjustesReclasificacionesPresentacionViewModel("ImprimirIndiceCedulaAjustesReclasificaciones");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaAjustesYReclasificacionesMsjVerPDFPreviaView":
                            encabezado = "Vista de ajustes y reclasificaciones";
                            crearVentana = new AjustesPresentacionView();
                            crearVentana.DataContext = new AjustesReclasificacionesPresentacionViewModel("IndiceCedulaAjustesReclasificaciones");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        #endregion
                        case "CedulaNotasVerPDFPreviaView":
                            encabezado = "Vista de notas";
                            crearVentana = new NotasImpresionView();
                            crearVentana.DataContext = new NotasPresentacionViewModel("IndiceCedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaNotasImprimirPDFPreviaView":
                            encabezado = "Vista de notas";
                            crearVentana = new NotasImpresionView();
                            crearVentana.DataContext = new NotasPresentacionViewModel("ImprimirIndiceCedulaNotas");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaSumariaImprimirPDFPreviaView":
                            encabezado = "Cédula Sumaria";
                            crearVentana = new SumariaPresentacionView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaPresentacionViewModel("ImprimirIndiceCedulaSumaria");
                            break;
                        case "CedulaSumariaVerPDFPreviaView":
                            encabezado = "Cédula Sumaria";
                            crearVentana = new SumariaPresentacionView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaPresentacionViewModel("IndiceCedulaSumaria");
                            break;
                        case "CedulaSumariaAnaliticasVerPDFPreviaView":
                            encabezado = "Cédula analítica";
                            crearVentana = new SumariaPresentacionView();
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            crearVentana.DataContext = new SumariaPresentacionViewModel("IndiceCedulaAnaliticas");
                            break;
                        case "CedulaCentralizadoraPDFPreviaView":
                            encabezado = "Vista de resúmenes de sumarias";
                            crearVentana = new CentralizadoraPresentacionView();
                            crearVentana.DataContext = new CentralizadoraPresentacionViewModel("IndiceCedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        case "CedulaCentralizadoraImprimirPDFPreviaView":
                            encabezado = "Vista de resúmenes de sumarias";
                            crearVentana = new CentralizadoraPresentacionView();
                            crearVentana.DataContext = new CentralizadoraPresentacionViewModel("ImprimirIndiceCedulaCentralizadora");
                            crearVentana.MinHeight = largo * 0.15;
                            crearVentana.MinWidth = ancho * 0.15;
                            crearVentana.MaxWidth = ancho;
                            crearVentana.MaxHeight = largo;
                            break;
                        default:
                            //Controller y vista solo para mientras
                            encabezado = "Error";
                            break;
                    }
                    crearVentana.Title = encabezado;
                    crearVentana.Owner = Application.Current.MainWindow;
                    crearVentana.Show();
                }
            }
            else
            {
                vista = string.Empty;
                vistaAnterior = string.Empty;
                controlStrin = true;
            }
        }
        #endregion
    }
}