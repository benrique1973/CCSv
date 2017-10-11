using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Administracion;
using SGPTWpf.ViewModel.Documentos;
using SGPTWpf.ViewModel.Herramientas;
using SGPTWpf.ViewModel.Herramientas.Plantillas;
using SGPTWpf.Views.Administracion;
using SGPTWpf.Views.Principales.Herramientas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class MenuPrincipal : UIBase
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

        public MenuPrincipal NewMenuPrincipal
        {
            get { return GetValue(() => NewMenuPrincipal); }
            set { SetValue(() => NewMenuPrincipal, value); }
        }


        public MenuPrincipal()
        {
            _token = "MenuPrincipal";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Administracion":
                    ViewType = typeof(AdministracionMenuView);
                    break;
                case "Encargos":
                    ViewType = typeof(EncargosView);
                    break;
                case "Herramientas":
                    ViewType = typeof(HerramientasView);
                    break;
                case "Documentos":
                    ViewType = typeof(DocumentosView);
                    break;
                case "Normas":
                    ViewType = typeof(NormasView);
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
                //View = (UserControl)Activator.CreateInstance(ViewType);ç

                switch (ViewDisplay)
                {
                    case "Administracion":
                        ViewModelType = typeof(AdministracionViewModel);
                        Contexto = new AdministracionViewModel();
                        break;
                    case "Encargos":
                        ViewModelType = typeof(EncargosViewModel);
                        Contexto = new EncargosViewModel();
                        break;
                    case "Herramientas":
                        ViewModelType = typeof(PlantillaViewModel);
                        Contexto = new HerramientasViewModel();
                        break;
                    case "Normas":
                        //ViewModelType = typeof(NormasViewModel);
                        //Contexto = new NormasViewModel(DialogCoordinator.Instance);
                        ViewModelType = typeof(NormativaViewModel);
                        Contexto = new NormativaViewModel("Normas");
                        break;
                    case "Documentos":
                        ViewModelType = typeof(DocumentosViewModel);
                        Contexto = new DocumentosViewModel();
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
                case "Administracion":
                    ViewType = typeof(AdministracionMenuView);
                    break;
                case "Encargos":
                    ViewType = typeof(EncargosView);
                    break;
                case "Herramientas":
                    ViewType = typeof(HerramientasView);
                    break;
                case "Documentos":
                    ViewType = typeof(DocumentosView);
                    break;
                case "Normas":
                    ViewType = typeof(NormasView);
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
                //View = (UserControl)Activator.CreateInstance(ViewType);

                switch (ViewDisplay)
                {
                    case "Administracion":
                        ViewModelType = typeof(AdministracionViewModel);
                        Contexto = new AdministracionViewModel();
                        break;
                    case "Encargos":
                        ViewModelType = typeof(EncargosViewModel);
                        Contexto = new EncargosViewModel();
                        break;
                    case "Herramientas":
                        ViewModelType = typeof(PlantillaViewModel);
                        Contexto = new HerramientasViewModel();
                        break;
                    case "Normas":
                        //ViewModelType = typeof(NormasViewModel);
                        //Contexto = new NormasViewModel(DialogCoordinator.Instance);
                        ViewModelType = typeof(NormativaViewModel);
                        Contexto = new NormativaViewModel("Normas");
                        break;
                    case "Documentos":
                        ViewModelType = typeof(DocumentosViewModel);
                        Contexto = new DocumentosViewModel();
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

        public static List<MenuPrincipal> GetAll()
        {
            ObservableCollection<MenuPrincipal> lista = new ObservableCollection<MenuPrincipal>
                {
                    new MenuPrincipal {
                                id=1,
                                tabla="Administracion",
                                ViewType = typeof(AdministracionViewModel),
                                ViewDisplay ="Administracion"
                                },
                    new MenuPrincipal
                                {
                                id = 2,
                                tabla = "Encargos",
                                ViewType = typeof(EncargosViewModel),
                                ViewDisplay = "Encargos"
                                },
                    new MenuPrincipal
                                {
                                id = 3,
                                tabla = "Herramientas",
                                ViewType = typeof(PlantillaViewModel),
                                ViewDisplay = "Herramientas"
                                },
                    new MenuPrincipal
                                {
                                id = 4,
                                tabla = "Documentos",
                                ViewType = typeof(DocumentosViewModel),
                                ViewDisplay = "Documentos"
                                },
                    new MenuPrincipal
                                {
                                id = 5,
                                tabla = "Normas",
                                ViewType = typeof(NormativaViewModel),
                                ViewDisplay = "Normas"
                                },

                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public MenuPrincipal(int i)
        {
            _token = "MenuPrincipal";
        }
        #endregion
    }
}