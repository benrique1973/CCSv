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
using SGPTWpf.Views.Principales.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas;
using SGPTWpf.ViewModel.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Cuestionarios;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class MenuDocumentacion : UIBase
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

        public MenuDocumentacion NewMenuHerramienta
        {
            get { return GetValue(() => NewMenuHerramienta); }
            set { SetValue(() => NewMenuHerramienta, value); }
        }


        public MenuDocumentacion()
        {
            _token = "MenuDocumentacion";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Balances":
                    ViewType = typeof(BalancesView);
                    break;
                //case "Carga de Datos":
                //    ViewType = typeof(CargaDeDatosView);
                //    break;
                case "Catalogo cuentas":
                    ViewType = typeof(CatalogoCuentasView);
                    break;
                case "Cuestionarios":
                    ViewType = typeof(CuestionariosView);//Para ejecucion
                    break;
                case "Cartas":
                    //ViewType = typeof(CartasView);
                    ViewType = typeof(RepositorioView);
                    break;
                //case "Cédulas":
                //    ViewType = typeof(CedulasView);
                //    break;
                case "Carpetas":
                    ViewType = typeof(IndiceView);
                    break;
                case "Programas":
                    ViewType = typeof(ProgramasView);
                    break;
                case "Memorandos":
                    ViewType = typeof(RepositorioView);
                    break;
                //case "Consulta materialidad":
                //    ViewType = typeof(ConsultaMaterialidadView);
                //    break;
                //case "Confirmaciones":
                //    ViewType = typeof(ConfirmacionesView);
                //    break;
                case "Informe auditoría":
                    ViewType = typeof(RepositorioView);
                    break;
                case "Otros documentos":
                    ViewType = typeof(RepositorioOtrosView);
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
                    case "Balances":
                        ViewModelType = typeof(BalancesViewModel);
                        Contexto = new BalancesViewModel("Balances");
                        break;
                    case "Catalogo cuentas":
                        ViewModelType = typeof(CatalogoCuentasViewModel);
                        Contexto = new CatalogoCuentasViewModel("Catalogo cuentas");
                        break;
                    //case "Carga de Datos":
                    //    ViewModelType = typeof(CargaDeDatosViewModel);
                    //    Contexto = new CargaDeDatosViewModel();
                    //    break;
                    case "Cuestionarios":
                        //Uso de una variable para cargar otro controlador
                        ViewModelType = typeof(CuestionariosViewModel);
                        Contexto = new CuestionariosViewModel("MenuDocumentacion");
                        break;
                    case "Cartas":
                        ViewModelType = typeof(RepositorioViewModel);
                        Contexto = new RepositorioViewModel("opcionCartas");
                        break;
                    case "Otros documentos":
                        ViewModelType = typeof(RepositorioViewModel);
                        Contexto = new RepositorioViewModel("opcionOtros");
                        break;                    //case "Cédulas":
                    //    ViewModelType = typeof(CedulasViewModel);
                    //    Contexto = new CedulasViewModel();
                    //    break;
                    case "Carpetas":
                        ViewModelType = typeof(IndiceViewModel);
                        Contexto = new IndiceViewModel("EncargoDocumentacion");
                        break;
                    case "Programas":
                        ViewModelType = typeof(ProgramasViewModel);
                        Contexto = new ProgramasViewModel("MenuDocumentacion");
                        break;
                    case "Memorandos":
                        ViewModelType = typeof(RepositorioViewModel);
                        Contexto = new RepositorioViewModel("opcionMemorandos");
                        break;
                    //case "Consulta materialidad":
                    //    ViewModelType = typeof(ConsultaMaterialidadViewModel);
                    //    Contexto = new ConsultaMaterialidadViewModel();
                    //    break;
                    //case "Confirmaciones":
                    //    ViewModelType = typeof(ConfirmacionesViewModel);
                    //    Contexto = new ConfirmacionesViewModel();
                    //    break;
                    case "Informe auditoría":
                        ViewModelType = typeof(RepositorioViewModel);
                        Contexto = new RepositorioViewModel("opcionInformes");
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

        public static List<MenuDocumentacion> GetAll()
        {
            ObservableCollection<MenuDocumentacion> lista = new ObservableCollection<MenuDocumentacion>
                {
               new MenuDocumentacion {
                                id=1,
                                tabla="Balances",
                                ViewType = typeof(BalancesViewModel),
                                ViewDisplay ="Balances"
                                },
                new MenuDocumentacion {
                                id=2,
                                tabla="Catalogo cuentas",
                                ViewType = typeof(CatalogoCuentasViewModel),
                                ViewDisplay ="Catalogo cuentas"
                                },
               //new MenuDocumentacion {
               //                 id=2,
               //                 tabla="Carga de Datos",
               //                 ViewType = typeof(CargaDeDatosViewModel),
               //                 ViewDisplay ="Carga de Datos"
               //                 },
               new MenuDocumentacion {
                                id=3,
                                tabla="Cuestionarios",
                                ViewType = typeof(CuestionariosViewModel),
                                ViewDisplay ="Cuestionarios"
                                },
               new MenuDocumentacion {
                                id=4,
                                tabla="CartasRepositorio",
                                ViewType =  typeof(RepositorioViewModel),
                                ViewDisplay = "Cartas"
                                },
               //new MenuDocumentacion {
               //                 id=5,
               //                 tabla="Cédulas",
               //                 ViewType =  typeof(CedulasViewModel),
               //                 ViewDisplay ="Cédulas"
               //                 },
               new MenuDocumentacion {
                                id=6,
                                tabla="Indices",
                                ViewType =  typeof(IndiceViewModel),
                                ViewDisplay ="Carpetas"
                                },
                new MenuDocumentacion {
                                id=7,
                                tabla="Programas",
                                ViewType =  typeof(ProgramasViewModel),
                                ViewDisplay ="Programas"
                                },
               new MenuDocumentacion {
                                id=8,
                                tabla="Memorandos",
                                ViewType =  typeof(RepositorioViewModel),
                                ViewDisplay ="Memorandos"
                                },
               //new MenuDocumentacion {
               //                 id=9,
               //                 tabla="Consulta materialidad",
               //                 ViewType =  typeof(ConsultaMaterialidadViewModel),
               //                 ViewDisplay = "Consulta materialidad"
               //                 },
               //new MenuDocumentacion {
               //                 id=10,
               //                 tabla="Confirmaciones",
               //                 ViewType =  typeof(ConfirmacionesViewModel),
               //                 ViewDisplay ="Confirmaciones"
               //                 },
               new MenuDocumentacion {
                                id=11,
                                tabla="Informe auditoría",
                                ViewType =  typeof(RepositorioViewModel),
                                ViewDisplay ="Informe auditoría"
                                },
               new MenuDocumentacion {
                                id=12,
                                tabla="Otros documentos",
                                ViewType =  typeof(RepositorioViewModel),
                                ViewDisplay ="Otros documentos"
                                },
            };

            return lista.OrderBy(x => x.id).ToList();
        }

        public MenuDocumentacion(int i)
        {
            _token = "MenuDocumentacion"; 
        }
        #endregion
    }
}