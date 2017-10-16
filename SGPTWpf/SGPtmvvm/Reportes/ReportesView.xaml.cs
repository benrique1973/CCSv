using CrystalDecisions.CrystalReports.Engine;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SAPBusinessObjects.WPF.Viewer;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;
using System;
using System.Windows;
using System.Windows.Input;
using CrystalDecisions.Shared;

namespace SGPTWpf.SGPtmvvm.Reportes
{
    /// <summary>
    /// Lógica de interacción para ReportesView.xaml
    /// </summary>
    public partial class ReportesView : MetroWindow
    {
        private DialogCoordinator dlg;
        public ReportesView()
        {
            InitializeComponent();
            dlg = new DialogCoordinator();
            //this.DataContext = new ReportesViewModel();
            Messenger.Default.Register<GenerarReporteMensajeModal>(this, "GenerameUnReporte", (recepcionOrdenReportear) => this.IniciarGeneracionReporte(recepcionOrdenReportear));
        }

        
    private void IniciarGeneracionReporte(GenerarReporteMensajeModal msj) //aqui cae el mensaje del solicitante
    {
        try
        {
            #region +
            //usuarioModelo = msj.usuarioModelo;
            //currentEncargo = msj.currentEncargoModelo;  //El encargo puede estar cambiando.
            //currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
            //tokenAUsar = msj.TokenAUtilizar;
            //MensajeModalRecibido = msj;

            Messenger.Default.Unregister<GenerarReporteMensajeModal>(this, "GenerameUnReporte");


            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.ReporteMatrizRiesgos)
            {
                    #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {
                        ReporteMatrizRiesgos rpz = new ReporteMatrizRiesgos();
                        DSMRiesgos ds = new DSMRiesgos();

                        var b = msj.EncabezadosPiesReporteMatrizRiesgos;
                        ds.DataTable2.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.razonSocialFirma,
                            b.encabezadoPantalla,
                            b.descripcionTipoAuditoria,
                            b.razonsocialcliente,
                            b.usuarioEjecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuarioSuperviso,
                            b.fechasuperviso,
                            b.usuarioAprobo,
                            b.fechaaprobo,
                            b.referencia,
                            7
                            }
                            #endregion
                    );

                        foreach (var aa in msj.listaMatrizRiesgoModelo)
                        {
                            #region +
                            var aaa = aa.idCorrelativo;
                            var bb = aa.nombredmr;
                            var c = aa.saldoevaluaciondmr;
                            var d = aa.factoresriesgodmr;
                            var e = aa.evaluacioninherentedmr;
                            var f = aa.evaluacioncontroldmr;
                            var g = aa.evaluacioncombinadodmr;
                            var h = aa.clasespruebasdmr;
                            var i = aa.procedimientosdmr;
                            var j = (decimal)aa.alcanceinherentedmr;
                            var k = (decimal)aa.alcancecontroldmr;
                            var l = (decimal)aa.alcancecombinadodmr;
                            var m = (decimal)aa.riesgoAuditoriadmr;
                            var nn = 7;
                            ds.Tables[0].Rows.Add(new object[] { aaa, bb, c, d, e, f, g, h, i, j, k, l, m, nn });
                            #endregion
                        }
                        ds.DataTable3.Rows.Add
                        (
                        #region +
                                //new object[] {1,2,1,2,1,2,1,3,1,7}
                                new object[]
                            {
                                b.evaluacioninherentedmrAlto,
                                b.evaluacioninherentedmrMedio,
                                b.evaluacioninherentedmrBajo,
                                b.evaluacioncontroldmrAlto,
                                b.evaluacioncontroldmrMedio,
                                b.evaluacioncontroldmrBajo,
                                b.evaluacionDetecciondmrAlto,
                                b.evaluacionDetecciondmrMedio,
                                b.evaluacionDetecciondmrBajo,
                                7
                            }
                            #endregion
                    );
                        ReporteMatrizRiesgos rpt = new Reportes.ReporteMatrizRiesgos();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    } 
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.ReportePrograma || msj.TipoReporteAGenerar == TipoReporteAGenerar.ReporteCuestionario)
            {
                #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {
                        //ReporteMatrizRiesgos rpz = new ReporteMatrizRiesgos();
                        
                        DSProgramasYCuestionarios ds = new DSProgramasYCuestionarios();
                        //DSMRiesgos ds = new DSMRiesgos();

                        var b = msj.EncabezadosPiesReportesProgramasCuestionarios;
                        ds.DataTableEncabezado.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.usuarioejecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuariosuperviso,
                            b.fechasuperviso,
                            b.usuarioaprobo,
                            b.fechaaprobo,
                            "referencia",
                            b.cantidadprocedplan,
                            b.cantidadprocedejecucion,
                            b.indiceejecucion,
                            b.horasplan,
                            b.horasejecucion,
                            b.indicehoras,
                            7
                            }
                            #endregion
                    );

                        //msj.listaObjetivosC = listaObjetivos;
                        //msj.listaAlcancesC = listaAlcances;
                        //msj.listaDetalleProcedimientosC = listaDetalleProcedimientos;
                        //var listaObjetivoz = false;
                        if (msj.TipoReporteAGenerar == TipoReporteAGenerar.ReportePrograma)
                        {
                            foreach (var aa in msj.listaObjetivos)
                            {
                                var aaa = aa.ordenDhPresentacion;
                                var bb = aa.descripciondp;
                                var c = 7;
                                ds.DataTableObjetivos.Rows.Add(new object[] { aaa, bb, c });
                            }
                        }
                        else
                        {
                            foreach (var aa in msj.listaObjetivosC) //Cuestionarios
                            {
                                var aaa = aa.ordenDhPresentacion;
                                var bb = aa.descripciondp;
                                var c = 7;
                                ds.DataTableObjetivos.Rows.Add(new object[] { aaa, bb, c });
                            }
                        }

                        if (msj.TipoReporteAGenerar == TipoReporteAGenerar.ReportePrograma)
                        {
                            foreach (var aa in msj.listaAlcances)
                            {
                                var aaa = aa.ordenDhPresentacion;
                                var bb = aa.descripciondp;
                                var c = 7;
                                ds.DataTableAlcances.Rows.Add(new object[] { aaa, bb, c });
                            }
                        }
                        else
                        {
                            foreach (var aa in msj.listaAlcancesC)
                            {
                                var aaa = aa.ordenDhPresentacion;
                                var bb = aa.descripciondp;
                                var c = 7;
                                ds.DataTableAlcances.Rows.Add(new object[] { aaa, bb, c });
                            }
                        }


                        if (msj.TipoReporteAGenerar == TipoReporteAGenerar.ReportePrograma)
                        {
                            foreach (var aa in msj.listaDetalleProcedimientos)
                            {
                                var aaa = aa.ordenDhPresentacion;  //decimal.Parse(aa.ordenDhPresentacion);//decimal.Parse(aa.idCorrelativo.ToString());
                                var bb = aa.descripciondp;
                                var c = aa.usuarioModificoDp;
                                var d = aa.referenciaPtDp;
                                var e = aa.comentariodp;
                                var f = 7;
                                ds.DataTableDetalleProcedimientos.Rows.Add(new object[] { aaa, bb, c, d, e, f });
                            } 
                        }
                        else
                        {
                            foreach (var aa in msj.listaDetalleProcedimientosC)
                            {
                                var aaa = aa.ordenDhPresentacion;  //decimal.Parse(aa.ordenDhPresentacion);//decimal.Parse(aa.idCorrelativo.ToString());
                                var bb = aa.descripciondp;
                                var c = aa.usuarioModificoDp;
                                var d = aa.referenciaPtDp;
                                var e = aa.comentariodp;
                                var f = 7;
                                ds.DataTableDetalleProcedimientos.Rows.Add(new object[] { aaa, bb, c, d, e, f });
                            }
                        }
                    //ReporteProgramas rpt = new ReporteProgramas();
                    RepProgramasCuestionarios rpt = new RepProgramasCuestionarios();
                    rpt.SetDataSource(ds);
                    crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    } 
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.PortadaCarpeta)
            {
                    #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {
                        //ReporteMatrizRiesgos rpz = new ReporteMatrizRiesgos();

                        DSPortadasCarpetas ds = new Reportes.DSPortadasCarpetas();
                        //DSProgramasYCuestionarios ds = new DSProgramasYCuestionarios();
                        //DSMRiesgos ds = new DSMRiesgos();

                        var b = msj.EncabezadosPiesReportesPortadasCarpetas;
                        ds.DataTableEncabezadoCuerpoPortada.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            7
                            }
                            #endregion
                    );

                        //ReporteProgramas rpt = new ReporteProgramas();
                        //RepProgramasCuestionarios rpt = new RepProgramasCuestionarios();
                        ReportePortadaCarpeta rpt = new ReportePortadaCarpeta();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    }
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.IndiceCarpeta)
            {
                    #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {

                        DSIndiceCarpetas ds = new DSIndiceCarpetas();

                        var b = msj.EncabezadosPiesReportesIndiceCarpetas;
                        ds.DataTableEncabezado.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.usuarioejecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuariosuperviso,
                            b.fechasuperviso,
                            b.usuarioaprobo,
                            b.fechaaprobo,
                            b.itemsObligatorios,
                            b.itemsObligatoriosReferenciados,
                            b.IndiceItemsObligatorios,
                            b.itemsVoluntarios,
                            b.itemsVoluntariosReferenciados,
                            b.IndiceItemsVoluntarios,
                            7
                            }
                            #endregion
                        );


   
                            foreach (var aa in msj.listaDetalleHerramienta)
                            {
                                var aaa = aa.ordenDhPresentacion;  //decimal.Parse(aa.ordenDhPresentacion);//decimal.Parse(aa.idCorrelativo.ToString());
                                var bb = aa.descripcionPresentacion;
                                var c = aa.obligatorioindice;
                                var d = aa.referenciaindice;
                                var e = 7;
                                ds.DataTableCuerpo.Rows.Add(new object[] { aaa, bb, c, d, e});
                            }

                        //ReporteProgramas rpt = new ReporteProgramas();
                        //RepProgramasCuestionarios rpt = new RepProgramasCuestionarios();
                        ReporteIndiceCarpetas rpt = new ReporteIndiceCarpetas();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    }
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.CedulaMarcas)
            {
                #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {

                        //DSIndiceCarpetas ds = new DSIndiceCarpetas();
                        DSCedulaMarcas ds = new DSCedulaMarcas();

                        var b = msj.EncabezadosSinPiesReporteMarcas;
                        ds.DataTableEncabezado.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.usuarioejecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuariosuperviso,
                            b.fechasuperviso,
                            b.usuarioaprobo,
                            b.fechaaprobo,
                            7
                            }
                            #endregion
                        );



                        foreach (var aa in msj.listaCedulaMarcas)
                        {
                            var aaa = aa.idCorrelativo; 
                            var bb = aa.marcama;
                            var c = aa.significadoma;
                            var e = 7;
                            ds.DataTableCuerpo.Rows.Add(new object[] { aaa, bb, c, e });
                        }


                        ReporteCedulaMarcas rpt = new Reportes.ReporteCedulaMarcas();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    }
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.CedulaHallazgos)
            {
                #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {

                        //DSCedulaMarcas ds = new DSCedulaMarcas();
                        DSCedulaHallazgos ds = new DSCedulaHallazgos();

                        var b = msj.EncabezadosSinPiesReporteCedulaHallazgos;
                        ds.DataTableEncabezado.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.referencia,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.usuarioejecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuariosuperviso,
                            b.fechasuperviso,
                            b.usuarioaprobo,
                            b.fechaaprobo,
                            7
                            }
                            #endregion
                        );



                        foreach (var aa in msj.listaCedulaHallazgos)
                        {
                            var aaa = aa.idCorrelativo;
                            var bb = aa.titulohallazgo;
                            var c = aa.descripcionhallazgo;
                            var d = aa.baselegalhallazgo;
                            var e = aa.recomendacionhallazgo;
                            var f = aa.respuestaclientehallazgo;
                            var g = aa.referenciahallazgo;
                            var h = 7;
                            ds.DataTableCuerpo.Rows.Add(new object[] { aaa, bb, c, d, e, f, g, h });
                        }


                        //ReporteCedulaMarcas rpt = new Reportes.ReporteCedulaMarcas();
                        ReporteCedulaHallazgos rpt = new ReporteCedulaHallazgos();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    }
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.CedulaNotas)
            {
                #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {

                        //DSCedulaHallazgos ds = new DSCedulaHallazgos();
                        DSCedulaNotas ds = new Reportes.DSCedulaNotas();

                        var b = msj.EncabezadosSinPiesReporteCedulaNotas;
                        ds.DataTableEncabezado.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.referencia,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.usuarioejecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuariosuperviso,
                            b.fechasuperviso,
                            b.usuarioaprobo,
                            b.fechaaprobo,
                            7
                            }
                            #endregion
                        );



                        foreach (var aa in msj.listaCedulaNotas)
                        {
                            var aaa = aa.idCorrelativo;
                            var bb = aa.numnotapt;
                            var c = aa.referenciapapel;
                            var d = aa.descripcionnotaspt;
                            var e = 7;
                            ds.DataTableCuerpo.Rows.Add(new object[] { aaa, bb, c, d, e });
                        }


                        //ReporteCedulaMarcas rpt = new Reportes.ReporteCedulaMarcas();
                        //ReporteCedulaHallazgos rpt = new ReporteCedulaHallazgos();
                        ReporteCedulaNotas rpt = new ReporteCedulaNotas();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    }
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.CedulaAjustesReclas)
            {
                #region +
                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {

                        //DSCedulaNotas ds = new Reportes.DSCedulaNotas();
                        DSCedulaAjustesReclasificaciones ds = new DSCedulaAjustesReclasificaciones();

                        var b = msj.EncabezadosSinpiesCedulaAjustesReclasificaciones; 
                        ds.DataTableEncabezado.Rows.Add
                        (
                        #region +
                        new object[]
                            {
                            b.logofirma,
                            b.referencia,
                            b.razonsocialfirma,
                            b.encabezadopantalla,
                            b.descripciontipoauditoria,
                            b.razonsocialcliente,
                            b.usuarioejecuto,
                            b.fechaejecuto,
                            b.fechainiperauditencargo,
                            b.fechafinperauditencargo,
                            b.usuariosuperviso,
                            b.fechasuperviso,
                            b.usuarioaprobo,
                            b.fechaaprobo,
                            7
                            }
                            #endregion
                        );



                        foreach (var aa in msj.listaAjustesReclasificaciones)
                        {
                            var aaa = aa.idCorrelativo;
                            var bb = aa.clasepartida;
                            var c = aa.claseRegistro;
                            var d = aa.referencia;
                            var e = aa.codigo;
                            var f = aa.concepto;
                            var g = aa.cargos;
                            var h = aa.abonos;
                            var i = 7;
                            ds.DataTableCuerpo.Rows.Add(new object[] { aaa, bb, c, d, e, f, g, h, i });
                        }

                        //ReporteCedulaNotas rpt = new ReporteCedulaNotas();
                        ReporteCedulaAjustesReclasificaciones rpt = new ReporteCedulaAjustesReclasificaciones();
                        rpt.SetDataSource(ds);
                        crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                    }
                    #endregion
            }

            if (msj.TipoReporteAGenerar == TipoReporteAGenerar.CedulaSumaria)
            {
                #region +
                var crv = new CrystalReportsViewer();
                if (crv != null)
                {

                        //DSCedulaNotas ds = new Reportes.DSCedulaNotas();
                        //DSCedulaAjustesReclasificaciones ds = new DSCedulaAjustesReclasificaciones();
                        //DSCedulaSumaria ds = new DSCedulaSumaria();
                        DSCedulaSumariaa ds = new Reportes.DSCedulaSumariaa();

                    var b = msj.EncabezadosPiesReportesSumarias;
                    ds.DataTableEncabezadoypies.Rows.Add
                    (
                    #region +
                    new object[]
                        {
                        b.logofirma,
                        b.razonsocialfirma,
                        b.encabezadopantalla,
                        b.descripciontipoauditoria,
                        b.razonsocialcliente,
                        b.usuarioejecuto,
                        b.fechaejecuto,
                        b.fechainiperauditencargo,
                        b.fechafinperauditencargo,
                        b.usuariosuperviso,
                        b.fechasuperviso,
                        b.usuarioaprobo,
                        b.fechaaprobo,
                        b.referencia,
                        b.objetivocedula,
                        b.alcancecedula,
                        b.conclusioncedula,
                        7
                        }
                        #endregion
                    );



                    foreach (var aa in msj.listaCedulaSumaria)
                    {
                        var aaa = aa.idCorrelativo;
                            var bb = aa.referenciapapel;
                        var c = aa.codigocontabledc;
                        var d = aa.nombreClaseCuenta;
                        var e = aa.m1dc;
                        var f = aa.saldoactualdc;
                        var g = aa.m2dc;
                        var h = aa.saldoanteriordc;
                        var i = aa.m3dc;
                            var j = aa.aumentodc;
                            var k = aa.variacionporcentual;
                            var l = aa.cargosreajusteyreclasificacion;
                            var m = aa.m4dc;
                            var n = aa.abonoreajusteyreclasificacion;
                            var o = aa.m5dc;
                            var p = aa.saldofinaldc;
                            var q = aa.m6dc;
                            var r = aa.m7dc;
                            var s = 7;
                        ds.DataTableCuerpo.Rows.Add(new object[] { aaa, bb, c, d, e, f, g, h, i , j , k , l , m , n , o , p , q, r, s});
                    }

                    //ReporteCedulaNotas rpt = new ReporteCedulaNotas();
                    ReporteCedulaAjustesReclasificaciones rpt = new ReporteCedulaAjustesReclasificaciones();
                    rpt.SetDataSource(ds);
                    crystalReportsViewer1.ViewerCore.ReportSource = rpt;
                }
                #endregion
            }
                #endregion
            }
        catch (Exception e)
        {
            MessageBox.Show("" + e);
        }
        Mouse.OverrideCursor = null;
    }


}
}
