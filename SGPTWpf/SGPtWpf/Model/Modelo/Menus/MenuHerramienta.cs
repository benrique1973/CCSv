using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Command;
using System;
using System.Collections.ObjectModel;
using SGPTWpf.Support;
using System.ComponentModel.DataAnnotations.Schema;
using SGPTWpf.ViewModel;
using SGPTWpf.Views.Prinicipales.Herramientas;
using SGPTWpf.Views.Administracion.Herramientas;
using SGPTWpf.Views.Principales.Herramientas.Plantillas;
using SGPTWpf.ViewModel.Herramientas.Programas;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using SGPTWpf.ViewModel.Herramientas.Plantillas;
using SGPTWpf.ViewModel.Herramientas;
using SGPTWpf.ViewModel.Herramientas.Indice;
using System.Linq;
using System.Windows.Controls;
using SGPTWpf.Messages.Navegacion;
using System.Collections.Generic;

namespace SGPTWpf.SGPtWpf.Model.Modelo
{
    public class MenuHerramienta : UIBase
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

        public MenuHerramienta NewMenuHerramienta
        {
            get { return GetValue(() => NewMenuHerramienta); }
            set { SetValue(() => NewMenuHerramienta, value); }
        }


        public MenuHerramienta()
        {
            token = "MenuHerramientas";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Programas":
                    ViewType = typeof(ProgramaCrudView);
                    break;
                case "Cuestionarios":
                    ViewType = typeof(CuestionarioCrudView);
                    break;
                case "Plantillas":
                    ViewType = typeof(PlantillasCrudView);
                    break;
                case "Normativa":
                    ViewType = typeof(NormativaCrudView);
                    break;
                case "Indice":
                    ViewType = typeof(IndiceCrudView);
                    break;
                case "Marcas":
                    ViewType = typeof(MarcaCrudView);
                    break;
                default:
                    ViewType = typeof(GenericoHerramientasCrudView);
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
                    case "Programas":
                        ViewModelType = typeof(HerramientasProgramaViewModel);
                        Contexto = new HerramientasProgramaViewModel("Programas");
                        break;
                    case "Cuestionarios":
                        ViewModelType = typeof(HerramientasCuestionarioViewModel);
                        Contexto = new HerramientasCuestionarioViewModel("Cuestionarios");
                        break;
                    case "Plantillas":
                        ViewModelType = typeof(PlantillaViewModel);
                        Contexto = new PlantillaViewModel("Plantillas");
                        break;
                    case "Normativa":
                        ViewModelType = typeof(NormativaViewModel);
                        Contexto = new NormativaViewModel("Normativa");
                        break;
                    case "Indice":
                        ViewModelType = typeof(PlantillaIndiceViewModel);
                        Contexto = new PlantillaIndiceViewModel("Indice");
                        break;
                    case "Marcas":
                        ViewModelType = typeof(MarcasEstandaresViewModel);
                        Contexto = new MarcasEstandaresViewModel("Marcas");
                        break;
                    default:
                        ViewModelType = typeof(GenericoHerramientasViewModel);
                        Contexto = new GenericoHerramientasViewModel();
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }

        #endregion


        #region Public Model Methods

        public static List<MenuHerramienta> GetAll()
        {
            ObservableCollection<MenuHerramienta> lista = new ObservableCollection<MenuHerramienta>
                {
               new MenuHerramienta {
                                id=1,
                                tabla="Programas",
                                ViewType = typeof(HerramientasProgramaViewModel),
                                ViewDisplay ="Programas"
                                },
               new MenuHerramienta {
                                id=2,
                                tabla="Cuestionarios",
                                ViewType = typeof(HerramientasCuestionarioViewModel),
                                ViewDisplay ="Cuestionarios"
                                },
               new MenuHerramienta {
                                id=3,
                                tabla="Plantillas",
                                ViewType = typeof(PlantillaViewModel),
                                ViewDisplay ="Plantillas"
                                },
               new MenuHerramienta {
                                id=4,
                                tabla="Normativa",
                                ViewType =  typeof(NormativaViewModel),
                                ViewDisplay ="Normativa"
                                },
               new MenuHerramienta {
                                id=5,
                                tabla="Indice",
                                ViewType =  typeof(PlantillaIndiceViewModel),
                                ViewDisplay ="Indice"
                                },
               new MenuHerramienta {
                                id=6,
                                tabla="Marcas",
                                ViewType =  typeof(MarcasEstandaresViewModel),
                                ViewDisplay ="Marcas"
                                },
               new MenuHerramienta {
                                id=7,
                                tabla="Marcas",
                                ViewType =  typeof(MarcasEstandaresViewModel),
                                ViewDisplay ="Marcas"
                                },
                    };

            return lista.OrderBy(x => x.id).ToList();
        }
 
        public MenuHerramienta(int i)
        {
            _token = "MenuHerramientas";
        }
        #endregion
    }
}