using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Administracion;
using SGPTWpf.ViewModel.Crud.Usuario;
using SGPTWpf.Views.Administracion;
using SGPTWpf.Views.Principales.Administracion;
using SGPTWpf.Views.Principales.Administracion.Menus;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class MenuAdministracion : UIBase
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

        public MenuAdministracion NewMenuAdministracion
        {
            get { return GetValue(() => NewMenuAdministracion); }
            set { SetValue(() => NewMenuAdministracion, value); }
        }


        public MenuAdministracion()
        {
            _token = "MenuAdministracion";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Catalogos":
                    ViewType = typeof(CatalogosView);
                    break;
                case "Usuarios":
                    ViewType = typeof(UsuariosView);
                    break;
                case "Roles":
                    ViewType = typeof(RolesView);
                    break;
                case "Firma":
                    ViewType = typeof(FirmaView);
                    break;
                case "Clientes":
                    ViewType = typeof(ClientesView);
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
                    case "Catalogos":
                        ViewModelType = typeof(CatalogosViewModel);
                        Contexto = new CatalogosViewModel();
                        break;
                    case "Usuarios":
                        ViewModelType = typeof(UsuariosViewModel);
                        Contexto = new UsuariosViewModel();
                        break;
                    case "Roles":
                        ViewModelType = typeof(RolesViewModel);
                        Contexto = new RolesViewModel();
                        break;
                    case "Firma":
                        ViewModelType = typeof(FirmaViewModel);
                        Contexto = new FirmaViewModel();
                        break;
                    case "Clientes":
                        ViewModelType = typeof(ClientesViewModel);
                        Contexto = new ClientesViewModel();
                        /**************************************************/
                        //Nota: Aqui debo solicitar que muestre una vista con el listado de los clientes
                        //se opta por modificar el ClienteViewModel y su vista para que soporte un listado de clientes
                        //lo cual es necesario para que cada
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
                case "Catalogos":
                    ViewType = typeof(CatalogosView);
                    break;
                case "Usuarios":
                    ViewType = typeof(UsuariosView);
                    break;
                case "Roles":
                    ViewType = typeof(RolesView);
                    break;
                case "Firma":
                    ViewType = typeof(FirmaView);
                    break;
                case "Clientes":
                    ViewType = typeof(ClientesView);
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
                    case "Catalogos":
                        ViewModelType = typeof(CatalogosViewModel);
                        Contexto = new CatalogosViewModel();
                        break;
                    case "Usuarios":
                        ViewModelType = typeof(UsuariosViewModel);
                        Contexto = new UsuariosViewModel();
                        break;
                    case "Roles":
                        ViewModelType = typeof(RolesViewModel);
                        Contexto = new RolesViewModel();
                        break;
                    case "Firma":
                        ViewModelType = typeof(FirmaViewModel);
                        Contexto = new FirmaViewModel();
                        break;
                    case "Clientes":
                        ViewModelType = typeof(ClientesViewModel);
                        Contexto = new ClientesViewModel();
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

        public static List<MenuAdministracion> GetAll()
        {
            ObservableCollection<MenuAdministracion> lista = new ObservableCollection<MenuAdministracion>
                {
                    new MenuAdministracion {
                                id=1,
                                tabla="Catalogos",
                                ViewType = typeof(CatalogosViewModel),
                                ViewDisplay ="Catalogos"
                                },
                    new MenuAdministracion
                                {
                                id = 2,
                                tabla = "Usuarios",
                                ViewType = typeof(UsuariosViewModel),
                                ViewDisplay = "Usuarios"
                                },
                    new MenuAdministracion
                                {
                                id = 3,
                                tabla = "Roles",
                                ViewType = typeof(RolesViewModel),
                                ViewDisplay = "Roles"
                                },
                    new MenuAdministracion
                                {
                                id = 4,
                                tabla = "Firma",
                                ViewType = typeof(FirmaViewModel),
                                ViewDisplay = "Firma"
                                },
                    new MenuAdministracion
                                {
                                id = 5,
                                tabla = "Clientes",
                                ViewType = typeof(ClientesViewModel),
                                ViewDisplay = "Clientes"
                                },

                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public MenuAdministracion(int i)
        {
            _token = "MenuAdministracion";
        }
        #endregion
    }
}