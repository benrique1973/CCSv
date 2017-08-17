using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Hallazgos;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Supervision.Avance;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Agenda;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Avance;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class MenuSupervision : UIBase
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
        //public virtual ICollection<cedulas> cedulas { get; set; }
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

        #region MenuSupervision
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

        #endregion

        public MenuSupervision NewMenuSupervision
        {
            get { return GetValue(() => NewMenuSupervision); }
            set { SetValue(() => NewMenuSupervision, value); }
        }

        public MenuSupervision()
        {
            _token = "MenuSupervisión";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Revision de carpetas":
                    ViewType = typeof(IndiceView);
                    break;
                case "Consulta de avance":
                    ViewType = typeof(AvanceView);
                    break;
                case "Asuntos pendientes":
                    ViewType = typeof(AgendaView);
                    break;
                case "Consulta de hallazgos":
                    ViewType = typeof(ConsultaResumenHallazgosView);
                    break;
            }

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                //View = (UserControl)Activator.CreateInstance(ViewType);ç
                switch (ViewDisplay)
                {
                    case "Revision de carpetas":
                        ViewModelType = typeof(IndiceViewModel);
                        Contexto = new IndiceViewModel("SupervisionIndice");
                        break;
                    case "Asuntos pendientes":
                        ViewModelType = typeof(AgendaViewModel);
                        Contexto = new AgendaViewModel("SupervisionAgenda");
                        break;
                    case "Consulta de avance":
                        ViewModelType = typeof(AvanceViewModel);
                        Contexto = new AvanceViewModel("SupervisionAvance");
                        break;
                    //case "Consulta de hallazgos":
                    //    ViewModelType = typeof(HallazgosViewModel);
                    //    Contexto = new HallazgosViewModel("SupervisionHallazgos");
                    //    break;
                    case "Consulta de hallazgos":
                        ViewModelType = typeof(SumariaHallazgosViewModel);
                        Contexto = new SumariaHallazgosViewModel("SupervisionHallazgos");
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

        public static List<MenuSupervision> GetAll()
        {
            var lista = new ObservableCollection<MenuSupervision>
        {
               new MenuSupervision {
                                id=1,
                                tabla="Revision de carpetas",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Revision de carpetas"
                                },
               new MenuSupervision {
                                id=2,
                                tabla="Avance",
                                ViewType =  typeof(AvanceViewModel),
                                ViewDisplay ="Consulta de avance"
                                },
               new MenuSupervision {
                                id=3,
                                tabla="Asuntos pendientes",
                                ViewType = typeof(AgendaViewModel),
                                ViewDisplay ="Asuntos pendientes"
                                },
               //new MenuSupervision {
               //                 id=4,
               //                 tabla="Consulta de hallazgos",
               //                 ViewType =  typeof(HallazgosViewModel),
               //                 ViewDisplay ="Consulta de hallazgos"
               //                 },
               new MenuSupervision {
                                id=4,
                                tabla="Consulta de hallazgos",
                                ViewType =  typeof(SumariaHallazgosViewModel),
                                ViewDisplay ="Consulta de hallazgos"
                                },
            };
            return lista.OrderBy(x => x.ViewDisplay).ToList();
        }

        public MenuSupervision(int i)
        {
            _token = "MenuSupervisión";
        }
        #endregion
    }
}