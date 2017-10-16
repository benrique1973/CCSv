using CapaDatos;
using CrystalDecisions.CrystalReports.Engine;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SAPBusinessObjects.WPF.Viewer;
using SGPtmvvm.Mensajes;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Soporte;
using SGPTWpf.Messages;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.ViewModel;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGPTWpf.SGPtmvvm.Reportes
{
    public class ReportesViewModel : ViewModel.ViewModeloBase
    {

        private bool _canExecute;
        private DialogCoordinator dlg;
        public SGPTEntidades db = new SGPTEntidades();


        private string _message;
        public string Message { get { return _message; } set { _message = value; RaisePropertyChanged("Message"); } }


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

        private GenerarReporteMensajeModal _MensajeModalRecibido;
        public GenerarReporteMensajeModal MensajeModalRecibido
        {
            get { return _MensajeModalRecibido; }
            set { _MensajeModalRecibido = value; RaisePropertyChanged("MensajeModalRecibido"); }
        }
        #endregion


        public ReportesViewModel()
        {
            //Messenger.Default.Register<GenerarReporteMensajeModal>(this, "GenerameUnReporte", (recepcionOrdenReportear) => this.IniciarGeneracionReporte(recepcionOrdenReportear));

            dlg = new DialogCoordinator();
            RegisterCommands();
            this.inicializadoresBasicos();
        }

        private void IniciarGeneracionReporte(GenerarReporteMensajeModal msj) //aqui cae el mensaje del solicitante
        {
            try
            {
                #region +
                //usuarioModelo = msj.usuarioModelo;
                //currentEncargo = msj.currentEncargoModelo;  //El encargo puede estar cambiando.
                //currentSistemaContable = SistemaContableModelo.GetRegistroByIdEncargo(currentEncargo.idencargo);
                tokenAUsar = msj.TokenAUtilizar;
                MensajeModalRecibido = msj;

                Messenger.Default.Unregister<GenerarReporteMensajeModal>(this, "GenerameUnReporte");


                if (msj.TipoReporteAGenerar == TipoReporteAGenerar.ReporteMatrizRiesgos)
                {
                    dlg.ShowMessageAsync(this, "Reporte de Matriz de riesgos ha sido llamado", "");

                    var crv = new CrystalReportsViewer();
                    if (crv != null)
                    {
                        //crv.ViewerCore.ReportSource = e.NewValue;
                        ReporteMatrizRiesgos rpz = new ReporteMatrizRiesgos();
                        DSMRiesgos ds = new DSMRiesgos();

                        var b = msj.EncabezadosPiesReporteMatrizRiesgos;
                    //    ds.DataTable2.Rows.Add
                    //    (
                    //    #region +
                    //        new object[]
                    //        {
                    //            "",
                    //            b.razonSocialFirma,
                    //            b.encabezadoPantalla,
                    //            b.descripcionTipoAuditoria,
                    //            b.razonsocialcliente,
                    //            b.usuarioEjecuto,
                    //            b.fechaejecuto,
                    //            b.fechainiperauditencargo,
                    //            b.fechafinperauditencargo,
                    //            b.usuarioSuperviso,
                    //            b.fechasuperviso,
                    //            b.usuarioAprobo,
                    //            b.fechaaprobo,
                    //            b.referencia,
                    //            7
                    //        }
                    //        #endregion
                    //);

                        //foreach (var a in msj.listaMatrizRiesgoModelo)
                        //{
                        //    ds.Tables[0].Rows.Add
                        //    (
                        //    #region +
                        //    new object[]
                        //        {
                        //        a.idCorrelativo,
                        //        a.nombredmr,
                        //        a.saldoevaluaciondmr,
                        //        a.factoresriesgodmr,
                        //        a.evaluacioninherentedmr,
                        //        a.evaluacioncontroldmr,
                        //        a.evaluacioncombinadodmr,
                        //        a.clasespruebasdmr,
                        //        a.procedimientosdmr,
                        //        (decimal)a.alcanceinherentedmr,
                        //        (decimal)a.alcancecontroldmr,
                        //        (decimal)a.alcancecombinadodmr,
                        //        (decimal)a.riesgoAuditoriadmr,
                        //        7
                        //        }
                        //        #endregion
                        //);
                        //}


                        ds.Tables[2].Rows.Add
                        (
                        #region +
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
                        //ds.AcceptChanges();
                        //DataSet dxs = new DataSet();
                        //dxs = ds;
                        //ReportDocument oRep = new ReportDocument();
                        //    //oRep.Load();
                        //oRep.SetDataSource(rpz);
                        //oRep.Database.Tables[1].SetDataSource(ds.Tables[1]);

                        //    //rpz.SetDataSource(dxs);
                        //    //oRep.SetDataSource(dxs);
                        //crv.ViewerCore.ReportSource = oRep;//rpz;
                        //crv.ViewerCore.RefreshReport();

                        //DSMRiesgosx dx = new DSMRiesgosx();
                        //dx.Tables[0].Rows.Add(new object[] { 1, "Eliezer", "Dimas", "Hombre" });
                        //dx.Tables[0].Rows.Add(new object[] { 2, "Sandra", "de Dimas", "Mujer" });
                        //dx.Tables[0].Rows.Add(new object[] { 3, "Alessia", "Dimas", "Mujer" });
                        //dx.Tables[0].Rows.Add(new object[] { 1, "Esteban", "Dimas", "Hombre" });
                        //dx.Tables[0].Rows.Add(new object[] { 1, "Shalom", "Dimas", "mujer" });
                        ReportDocument oo = new ReportDocument();
                        RepMatrizRiesgosx rp = new RepMatrizRiesgosx();
                        //oo.Load(@"C:\Users\ELIEL\Documents\Proyecto SGPT\SGPTWpf\SGPtmvvm\Reportes\RepMatrizRiesgosx.rpt");// = rp;
                        //oo.SetDataSource(dx);
                        //rp.SetDataSource(dx);
                        //crv.ViewerCore.ReportSource = rp; //oo;
                        //crv.ViewerCore.RefreshReport();
                    }
                }
                enviarMensajeInhabilitar();
                #endregion
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e);
            }
            Mouse.OverrideCursor = null;

        }
        public void enviarMensajeInhabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = false;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }

        public void enviarMensajeHabilitar()
        {
            //Se crea el mensaje
            TabItemMensaje inhabilitar = new TabItemMensaje();
            inhabilitar.mensaje = true;
            Messenger.Default.Send<TabItemMensaje>(inhabilitar);
        }
        #region ReportSourceProperty
        //public static class ReportSourceBehaviour
        //{

        public static readonly DependencyProperty ReportSourceProperty =
                DependencyProperty.RegisterAttached(
                "ReportSource",
                typeof(object),
                typeof(ReportesViewModel),
                new PropertyMetadata(ReportSourceChanged)
                );

        private static void ReportSourceChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var crviewer = d as CrystalReportsViewer;
            if (crviewer != null)
            {
                crviewer.ViewerCore.ReportSource = e.NewValue;
            }
        }

        public static void SetReportSource(DependencyObject target, object value)
        {
            target.SetValue(ReportSourceProperty, value);
        }

        public static object GetReportSource(DependencyObject target)
        {
            return target.GetValue(ReportSourceProperty);
        }

        //       }
        #endregion

        private void inicializadoresBasicos()
        {

        }


        private string _TokenAUsar;
        public string tokenAUsar
        {
            get { return _TokenAUsar; }
            set { _TokenAUsar = value; RaisePropertyChanged("tokenAUsar"); }
        }


        #region Cancelar
        private ICommand _cmdCancelar;
        public ICommand cmdCancelar
        {
            get
            {
                return _cmdCancelar ?? (_cmdCancelar = new CommandHandler(() => MycmdCancelar(), _canExecute));
            }
        }

        private void MycmdCancelar()
        {
            //await AvisaYCerrateVosSolo("Cancelado ", "", 1);

            Messenger.Default.Send<int>(2, tokenAUsar); //le envio al s0licitante la respuesta de la importacion.
            GC.Collect();
            //-1 fracaso
            //0 inicializadores (No usar)
            //1 éxito
            //2 Cancelo
            this.cmdCancelarX();
        }

        private void cmdCancelarX()
        {

            enviarMensaje();
            CloseWindow();
        }

        public void enviarMensaje()
        {
            //Messenger.Default.Unregister<UsuariosMensajeModal>(this);
            //Creando el mensaje de cierre
            VentanaViewMensajeFin cierre = new VentanaViewMensajeFin();
            cierre.mensaje = -1;
            Messenger.Default.Send<VentanaViewMensajeFin>(cierre);
        }
        #endregion


        #region Comando Salida

        public RelayCommand SalirCommand { get; set; }
        //private ICommand _SalirCommand;
        //public ICommand SalirCommand
        //{
        //    get
        //    {
        //        return _SalirCommand ?? (_SalirCommand = new CommandHandler(() => Salir(), _canExecute));
        //    }
        //}
        private void RegisterCommands()
        {

            SalirCommand = new RelayCommand(Salir);
        }


        private void Salir()
        {
            //Creando el mensaje de cierre

            //Messenger.Default.Send(-1, "RecepcionCargaCatalogo");
            Messenger.Default.Send(-1, tokenAUsar);
            enviarMensajeHabilitar();
            CloseWindow();
        }

        #endregion      

        private async Task cuenteUno()
        {
            await Task.Delay(1);
        }

        public async Task AvisaYCerrateVosSolo(string titulo, string contenido, int segundos)
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