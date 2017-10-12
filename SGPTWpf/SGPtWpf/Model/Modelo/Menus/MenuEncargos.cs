using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Encargos;
using SGPTWpf.ViewModel.Encargos.Cierre;
using SGPTWpf.ViewModel.Encargos.Documentacion;
using SGPTWpf.ViewModel.Encargos.Planificacion;
using SGPTWpf.ViewModel.Encargos.Supervision;
using SGPTWpf.Views.Administracion;
using SGPTWpf.Views.Principales.Encargos.Cierre;
using SGPTWpf.Views.Principales.Encargos.Documentacion;
using SGPTWpf.Views.Principales.Encargos.Edicion;
using SGPTWpf.Views.Principales.Encargos.Planificacion;
using SGPTWpf.Views.Principales.Encargos.Supervision;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;
namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class MenuEncargos : UIBase
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

        #region Menu Documentacion Programas
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

        public MenuEncargos NewMenuEncargos
        {
            get { return GetValue(() => NewMenuEncargos); }
            set { SetValue(() => NewMenuEncargos, value); }
        }


        public MenuEncargos()
        {
            _token = "MenuEncargos";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Edición":
                    ViewType = typeof(EdicionView);
                    break;
                case "Planificación":
                    ViewType = typeof(PlanificacionView);
                    break;
                case "Documentacion":
                    ViewType = typeof(DocumentacionView);
                    break;
                case "Supervision":
                    ViewType = typeof(SupervisionView);
                    break;
                case "Cierre":
                    ViewType = typeof(CierreView);
                    break;
                case "Cédulas":
                    ViewType = typeof(CedulasView);
                    break;
                default:
                    ViewType = typeof(GenericoView);
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
                    case "Edición":
                        ViewModelType = typeof(EdicionViewModel);
                        Contexto = new EdicionViewModel("Edición");
                        break;
                    case "Planificación":
                        ViewModelType = typeof(PlanificacionViewModel);
                        Contexto = new PlanificacionViewModel();
                        break;
                    case "Documentacion":
                        ViewModelType = typeof(DocumentacionViewModel);
                        Contexto = new DocumentacionViewModel();
                        break;
                    case "Supervision":
                        ViewModelType = typeof(SupervisionViewModel);
                        Contexto = new SupervisionViewModel();
                        break;
                    case "Cierre":
                        ViewModelType = typeof(CierreViewModel);
                        Contexto = new CierreViewModel();
                        break;
                    case "Cédulas":
                        ViewModelType = typeof(CedulasViewModel);
                        Contexto = new CedulasViewModel();
                        break;
                    default:
                        //MessageDialog("Error en el switch");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }

        public void NavigateExecute(string opcion)
        {
            switch (ViewDisplay)
            {
                case "Edición":
                    ViewModelType = typeof(EdicionViewModel);
                    Contexto = new EdicionViewModel("Edición");
                    break;
                case "Planificación":
                    ViewModelType = typeof(PlanificacionViewModel);
                    Contexto = new PlanificacionViewModel();
                    break;
                case "Documentacion":
                    ViewModelType = typeof(DocumentacionViewModel);
                    Contexto = new DocumentacionViewModel();
                    break;
                case "Supervision":
                    ViewModelType = typeof(SupervisionViewModel);
                    Contexto = new SupervisionViewModel();
                    break;
                case "Cierre":
                    ViewModelType = typeof(CierreViewModel);
                    Contexto = new CierreViewModel();
                    break;
                case "Cédulas":
                    ViewModelType = typeof(CedulasViewModel);
                    Contexto = new CedulasViewModel();
                    break;
                default:
                    //MessageDialog("Error en el switch");
                    break;
            }

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                //View = (UserControl)Activator.CreateInstance(ViewType);

                switch (ViewDisplay)
                {
                    case "Edición":
                        ViewModelType = typeof(EdicionViewModel);
                        Contexto = new EdicionViewModel("Edición");
                        break;
                    case "Planificación":
                        ViewModelType = typeof(PlanificacionViewModel);
                        Contexto = new PlanificacionViewModel();
                        break;
                    case "Documentacion":
                        ViewModelType = typeof(DocumentacionViewModel);
                        Contexto = new DocumentacionViewModel();
                        break;
                    case "Supervision":
                        ViewModelType = typeof(SupervisionViewModel);
                        Contexto = new SupervisionViewModel();
                        break;
                    case "Cierre":
                        ViewModelType = typeof(CierreViewModel);
                        Contexto = new CierreViewModel();
                        break;
                    case "Cedulas":
                        ViewModelType = typeof(CedulasViewModel);
                        Contexto = new CedulasViewModel();
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

        public static List<MenuEncargos> GetAll()
        {
            ObservableCollection<MenuEncargos> lista = new ObservableCollection<MenuEncargos>
                {
                    new MenuEncargos {
                                id=1,
                                tabla="Edición",
                                ViewType = typeof(EdicionViewModel),
                                ViewDisplay ="Edición"
                                },
                    new MenuEncargos
                                {
                                id = 2,
                                tabla = "Planificación",
                                ViewType = typeof(PlanificacionViewModel),
                                ViewDisplay = "Planificación"
                                },
                    new MenuEncargos
                                {
                                id = 3,
                                tabla = "Documentacion",
                                ViewType = typeof(DocumentacionViewModel),
                                ViewDisplay = "Documentacion"
                                },
                    new MenuEncargos
                                {
                                id = 4,
                                tabla = "Supervision",
                                ViewType = typeof(SupervisionViewModel),
                                ViewDisplay = "Supervision"
                                },
                    new MenuEncargos
                                {
                                id = 5,
                                tabla = "Cierre",
                                ViewType = typeof(CierreViewModel),
                                ViewDisplay = "Cierre"
                                },
                    new MenuEncargos
                                {
                                id = 6,
                                tabla = "Cedulas",
                                ViewType = typeof(CierreViewModel),
                                ViewDisplay = "Cédulas"
                                },

                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public MenuEncargos(int i)
        {
            _token = "MenuEncargos";
        }
        #endregion
    }
}