using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Command;
using System;
using System.Collections.ObjectModel;
using SGPTWpf.Support;
using System.ComponentModel.DataAnnotations.Schema;
using SGPTWpf.ViewModel;
using System.Linq;
using System.Windows.Controls;
using SGPTWpf.Messages.Navegacion;
using System.Collections.Generic;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Ajustes;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Conclusiones;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.CumplimientoLegal;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Marcas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Cronograma;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Expediente;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.DeDetalle;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Analiticas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.DeDetalle;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Marcas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.CumplimientoLegal;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Conclusiones;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Agenda;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Detalle;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.PreElaboradas.Expediente;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.PreElaboradas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.PreElaboradas.Cronograma;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Automaticas.Correspondencia;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Automaticas.Reuniones;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Automaticas.Contactos;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Ajustes;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Resumen;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Resumen;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Sumarias.Centralizadora;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Centralizadora;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Notas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Notas;
using SGPTWpf.Views.Principales.Encargos.Supervision;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class menuCedulaDetalle : UIBase
    {
        #region Model Attributes

        #endregion

        #region Model Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }

        public string tabla
        {
            get { return GetValue(() => tabla); }
            set { SetValue(() => tabla, value); }
        }
        public Type ViewType
        {
            get { return GetValue(() => ViewType); }
            set { SetValue(() => ViewType, value); }
        }
        public string ViewDisplay
        {
            get { return GetValue(() => ViewDisplay); }
            set { SetValue(() => ViewDisplay, value); }
        }

        #endregion

        #region Menu Encargos Planificacion
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public RelayCommand Navegar { get; set; }

        public ViewModeloBase Contexto { get; set; }

        #region token

        private string _token;
        private string token
        {
            get { return _token; }
            set { _token = value; }
        }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public bool opcionSeleccionada
        {
            get { return GetValue(() => opcionSeleccionada); }
            set { SetValue(() => opcionSeleccionada, value); }
        }
        #endregion

        public menuCedulaDetalle NewmenuCedulaDetalle
        {
            get { return GetValue(() => NewmenuCedulaDetalle); }
            set { SetValue(() => NewmenuCedulaDetalle, value); }
        }


        public menuCedulaDetalle()
        {
            _token = "MenuCedulas";
            Navegar = new RelayCommand(NavigateExecute);
        }

        public menuCedulaDetalle(string tokenDestino)
        {
            _token = tokenDestino;
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Sumarias":
                    ViewType = typeof(SumariasView);
                    break;
                case "Detalle de Sumarias":
                    ViewType = typeof(DetalleCedulaView);
                    break;
                case "Analíticas":
                    ViewType = typeof(AnaliticasView);
                    break;
                case "De Detalle":
                    ViewType = typeof(DeDetalleView);
                    break;
                case "Correspondencia":
                    ViewType = typeof(CorrespondenciaView);//Para ejecucion
                    break;
                case "Reuniones":
                    ViewType = typeof(ReunionesView);
                    break;
                case "Contactos":
                    ViewType = typeof(ContactosView);
                    break;
                case "Expediente":
                    ViewType = typeof(ExpedienteView);
                    break;
                case "Cronograma":
                    ViewType = typeof(CronogramaView);
                    break;
                case "Marcas":
                    ViewType = typeof(MarcasView);
                    break;
                case "Cumplimiento Legal":
                    ViewType = typeof(CumplimientoLegalView);
                    break;
                case "Conclusiones":
                    ViewType = typeof(ConclusionesView);
                    break;
                case "Hallazgos":
                    ViewType = typeof(HallazgosView);
                    break;
                case "Agenda":
                    ViewType = typeof(AgendaView);
                    break;
                case "Ajustes y reclasificaciones":
                    ViewType = typeof(AjustesView);
                    break;
                case "Resumen de Sumarias":
                    ViewType = typeof(CentralizadoraView);
                    break;
                case "Notas":
                    ViewType = typeof(NotasView);
                    break;
                case "Consulta de hallazgos":
                    ViewType = typeof(ConsultaHallazgosView);
                    break;
            }

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);

                switch (ViewDisplay)
                {
                    case "Sumarias":
                        ViewModelType = typeof(SumariasViewModel);
                        Contexto = new SumariasViewModel("cedulasSumarias");
                        break;
                    case "Detalle de Sumarias":
                        ViewModelType = typeof(DetalleCedulaViewModel);
                        Contexto = new DetalleCedulaViewModel("cedulasSumariasDetalle");
                        break;
                    case "Resumen de Sumarias":
                        ViewModelType = typeof(CentralizadoraViewModel);
                        Contexto = new CentralizadoraViewModel("cedulasResumenSumariasDetalle");
                        break;
                    case "De Detalle":
                        ViewModelType = typeof(DeDetalleViewModel);
                        Contexto = new DeDetalleViewModel(token);
                        break;
                    case "Analíticas":
                        ViewModelType = typeof(AnaliticasViewModel);
                        Contexto = new AnaliticasViewModel(token);
                        break;
                    case "Correspondencia":
                        //Uso de una variable para cargar otro controlador
                        ViewModelType = typeof(AutomaticasViewModel);
                        Contexto = new AutomaticasViewModel("cedulasCorrespondencia");
                        break;
                    case "Reuniones":
                        ViewModelType = typeof(AutomaticasViewModel);
                        Contexto = new AutomaticasViewModel("cedulasReuniones");
                        break;
                    case "Contactos":
                        ViewModelType = typeof(AutomaticasViewModel);
                        Contexto = new AutomaticasViewModel("cedulasContactos");
                        break;
                    case "Expediente":
                        ViewModelType = typeof(ExpedienteViewModel);
                        Contexto = new ExpedienteViewModel("cedulasExpediente");
                        break;
                    case "Cronograma":
                        ViewModelType = typeof(CronogramaViewModel);
                        Contexto = new CronogramaViewModel("cedulasCronograma");
                        break;
                    case "Marcas":
                        ViewModelType = typeof(MarcasViewModel);
                        Contexto = new MarcasViewModel(token);
                        break;
                    case "Cumplimiento Legal":
                        ViewModelType = typeof(CumplimientoLegalViewModel);
                        Contexto = new CumplimientoLegalViewModel(token);
                        break;
                    case "Conclusiones":
                        ViewModelType = typeof(ConclusionesViewModel);
                        Contexto = new ConclusionesViewModel(token);
                        break;
                    case "Hallazgos":
                        ViewModelType = typeof(HallazgosViewModel);
                        Contexto = new HallazgosViewModel("cedulasHallazgos");
                        break;
                    case "Agenda":
                        ViewModelType = typeof(AgendaViewModel);
                        Contexto = new AgendaViewModel(token);
                        break;
                    case "Ajustes y reclasificaciones":
                        ViewModelType = typeof(AjustesReclasificacionesViewModel);
                        Contexto = new AjustesReclasificacionesViewModel("cedulasAjustesYReclasificaciones");
                        break;
                    case "Notas":
                        ViewModelType = typeof(NotasViewModel);
                        Contexto = new NotasViewModel("cedulasNotas");
                        break;
                    case "Consulta de hallazgos":
                        ViewModelType = typeof(HallazgosViewModel);
                        Contexto = new HallazgosViewModel("SupervisionDetalleHallazgos");
                        break;
                    default:
                        //MessageDialog("Error en el switch");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }

        #endregion


        #region Public Model Methods

        public static List<menuCedulaDetalle> GetAll()
        {
            ObservableCollection<menuCedulaDetalle> lista = new ObservableCollection<menuCedulaDetalle>
                {
               new menuCedulaDetalle {
                                id=1,
                                tabla="Sumarias",
                                ViewType = typeof(SumariasViewModel),
                                ViewDisplay ="Sumarias"
                                },
                new menuCedulaDetalle {
                                id=2,
                                tabla="De Detalle",
                                ViewType = typeof(DeDetalleViewModel),
                                ViewDisplay ="De Detalle"
                                },
               new menuCedulaDetalle {
                                id=3,
                                tabla="Analíticas",
                                ViewType = typeof(AnaliticasViewModel),
                                ViewDisplay ="Analíticas"
                                },
               new menuCedulaDetalle {
                                id=4,
                                tabla="Correspondencia",
                                ViewType = typeof(AutomaticasViewModel),
                                ViewDisplay ="Correspondencia"
                                },
               new menuCedulaDetalle {
                                id=5,
                                tabla="Reuniones",
                                ViewType =  typeof(AutomaticasViewModel),
                                ViewDisplay = "Reuniones"
                                },
               new menuCedulaDetalle {
                                id=6,
                                tabla="Contactos",
                                ViewType =  typeof(AutomaticasViewModel),
                                ViewDisplay ="Contactos"
                                },
               new menuCedulaDetalle {
                                id=7,
                                tabla="Expedientes",
                                ViewType =  typeof(ExpedienteViewModel),
                                ViewDisplay ="Expediente"
                                },
                new menuCedulaDetalle {
                                id=8,
                                tabla="Cronograma",
                                ViewType =  typeof(CronogramaViewModel),
                                ViewDisplay ="Cronograma"
                                },
               new menuCedulaDetalle {
                                id=9,
                                tabla="Marcas",
                                ViewType =  typeof(MarcasViewModel),
                                ViewDisplay ="Marcas"
                                },
               new menuCedulaDetalle {
                                id=10,
                                tabla="Cumplimiento Legal",
                                ViewType =  typeof(CumplimientoLegalViewModel),
                                ViewDisplay = "Cumplimiento Legal"
                                },
               new menuCedulaDetalle {
                                id=11,
                                tabla="Conclusiones",
                                ViewType =  typeof(ConclusionesViewModel),
                                ViewDisplay ="Conclusiones"
                                },
               new menuCedulaDetalle {
                                id=12,
                                tabla="Hallazgos",
                                ViewType =  typeof(HallazgosViewModel),
                                ViewDisplay ="Hallazgos"
                                },
               new menuCedulaDetalle {
                                id=13,
                                tabla="Agenda",
                                ViewType =  typeof(AgendaViewModel),
                                ViewDisplay ="Agenda"
                                },
               new menuCedulaDetalle {
                                id=14,
                                tabla="Ajustes y reclasificaciones",
                                ViewType =  typeof(AjustesReclasificacionesViewModel),
                                ViewDisplay ="Ajustes y reclasificaciones"
                                },
              new menuCedulaDetalle {
                                id=15,
                                tabla="detallecedulas",
                                ViewType =  typeof(DetalleCedulaViewModel),
                                ViewDisplay ="Detalle de Sumarias"
                                },
              new menuCedulaDetalle {
                                id=16,
                                tabla="resumenSumariascedulas",
                                ViewType =  typeof(CentralizadoraViewModel),
                                ViewDisplay ="Resumen de Sumarias"
                                },
                new menuCedulaDetalle {
                                id=17,
                                tabla="Notas",
                                ViewType =  typeof(NotasViewModel),
                                ViewDisplay ="Notas"
                                },
               new menuCedulaDetalle ("MenuSupervisión") {
                                id=18,
                                tabla="Consulta de hallazgos",
                                ViewType =  typeof(HallazgosViewModel),
                                ViewDisplay ="Consulta de hallazgos"
                                },
                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public menuCedulaDetalle(int i)
        {
            _token = "MenuCedulas";
        }
        #endregion
    }
}
