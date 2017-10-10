using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Materialidad;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Crud.Materialidad;
using SGPTWpf.ViewModel.Encargos.Planificacion;
using SGPTWpf.ViewModel.Planificacion.Programas;
using SGPTWpf.Views.Catalogos;
using SGPTWpf.Views.Principales.Encargos.Planificacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Modelo
{
    public class PlanificacionModelo : UIBase
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

        #endregion

        public PlanificacionModelo NewPlanificacionModelo
        {
            get { return GetValue(() => NewPlanificacionModelo); }
            set { SetValue(() => NewPlanificacionModelo, value); }
        }

        public PlanificacionModelo()
        {
            _token = "MenuPlanificacion";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Riesgo":
                    ViewType = typeof(RiesgoView);
                    break;
                case "Programas":
                    ViewType = typeof(ProgramasView);
                    break;
                case "Cuestionarios":
                    ViewType = typeof(CuestionariosView);
                    break;
                case "Indices":
                    ViewType = typeof(IndiceView);
                    break;
                case "Materialidad":
                    ViewType = typeof(MaterialidadView);
                    break;
                default:
                    ViewType = typeof(GenericoCrudView);
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
                    case "Riesgo":
                        ViewModelType = typeof(MatrizRiesgoViewModel);
                        Contexto = new MatrizRiesgoViewModel();
                        break;
                    case "Programas":
                        ViewModelType = typeof(ProgramasViewModel);
                        Contexto = new ProgramasViewModel();
                        break;
                    case "Cuestionarios":
                        ViewModelType = typeof(CuestionariosViewModel);
                        Contexto = new CuestionariosViewModel();
                        break;
                    case "Indices":
                        ViewModelType = typeof(IndiceViewModel);
                        Contexto = new IndiceViewModel("EncargoPlanIndice");
                        break;
                    case "Materialidad":
                        ViewModelType = typeof(MaterialidadViewModel);
                        Contexto = new MaterialidadViewModel("Criterios  de  materialidad");
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

        public static List<PlanificacionModelo> GetAll()
        {
            var lista = new ObservableCollection<PlanificacionModelo>
        {
               new PlanificacionModelo {
                                id=1,
                                tabla="Riesgo",
                                ViewType = typeof(RiesgoView),
                                ViewDisplay ="Riesgo"
                                },
               new PlanificacionModelo {
                                id=2,
                                tabla="Programas",
                                ViewType = typeof(ProgramasView),
                                ViewDisplay ="Programas"
                                },
               new PlanificacionModelo {
                                id=3,
                                tabla="Cuestionarios",
                                ViewType = typeof(CuestionariosView),
                                ViewDisplay="Cuestionarios"
                                },
               new PlanificacionModelo {
                                id=4,
                                tabla="Indices",
                                ViewType = typeof(IndiceView),
                                ViewDisplay="Indices"
                                },
               //new PlanificacionModelo {
               //                 id=5,
               //                 tabla="Materialidad",
               //                 ViewType = typeof(MaterialidadView),
               //                 ViewDisplay="Materialidad"
               //                 },
            };
            return lista.OrderBy(x => x.ViewDisplay).ToList();
        }

        public PlanificacionModelo(int i)
        {
            _token = "MenuPlanificacion";
        }
        #endregion
    }
}