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
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.Views.Principales.Documentos.Consulta;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class menuIndiceDetalle : UIBase
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

        public menuIndiceDetalle NewmenuIndiceDetalle
        {
            get { return GetValue(() => NewmenuIndiceDetalle); }
            set { SetValue(() => NewmenuIndiceDetalle, value); }
        }


        public menuIndiceDetalle()
        {
            _token = "MenuPlanificacion";//Se usa el mismo token que planificacion porque es al mismo frame que se manda la informacion
            Navegar = new RelayCommand(NavigateExecute);
        }
        public menuIndiceDetalle(string origen)
        {
            _token = origen;
            //_token = "MenuDocumentacion";//Se usa el mismo token que documentacion porque es al mismo frame que se manda la informacion
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Indices":
                    ViewType = typeof(IndiceView);
                    break;
                case "Detalle Indices":
                    ViewType = typeof(DetalleIndiceView);
                    break;
                case "Carpetas":
                    ViewType = typeof(IndiceView);
                    break;
                case "Detalle carpetas":
                    ViewType = typeof(DetalleIndiceView);
                    break;
                case "Revision de papeles":
                    ViewType = typeof(IndiceView);
                    break;
                case "Detalle papeles":
                    ViewType = typeof(DetalleIndiceView);
                    break;
                case "Consulta":
                    ViewType = typeof(IndiceView);
                    break;
                case "Detalle consulta":
                    ViewType = typeof(DetalleIndiceConsultaView);
                    break;
                case "Impresión":
                    ViewType = typeof(IndiceView);
                    break;
                case "Detalle impresión":
                    ViewType = typeof(DetalleIndiceView);
                    break;
                case "Revision de carpetas":
                    ViewType = typeof(IndiceView);
                    break;
                case "Detalle archivos":
                    ViewType = typeof(DetalleIndiceView);
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
                    case "Indices":
                        ViewModelType = typeof(IndiceViewModel);
                        Contexto = new IndiceViewModel("EncargoPlanIndice");
                        break;
                    case "Detalle Indices":
                        ViewModelType = typeof(DetalleIndiceViewModel);
                        Contexto = new DetalleIndiceViewModel("EncargoPlanIndiceDetalle");
                        break;
                    case "Carpetas":
                        ViewModelType = typeof(IndiceViewModel);//Pendiente
                        Contexto = new IndiceViewModel("EncargoDocumentacion");
                        break;
                    case "Detalle carpetas":
                        ViewModelType = typeof(DetalleIndiceViewModel);
                        Contexto = new DetalleIndiceViewModel("EncargoDocumentacionIndiceDetalle");
                        break;
                    case "Revision de papeles":
                        ViewModelType = typeof(IndiceViewModel);//Pendiente
                        Contexto = new IndiceViewModel("EncargoCierre");
                        break;
                    case "Detalle papeles":
                        ViewModelType = typeof(DetalleIndiceViewModel);
                        Contexto = new DetalleIndiceViewModel("EncargoCierreIndiceDetalle");
                        break;
                    case "Consulta":
                        ViewModelType = typeof(IndiceViewModel);//Pendiente
                        Contexto = new IndiceViewModel("EncargoCierre");
                        break;
                    case "Detalle consulta":
                        ViewModelType = typeof(DetalleIndiceViewModel);
                        Contexto = new DetalleIndiceViewModel("DocumentosConsultaIndiceDetalle");
                        break;
                    case "Impresión":
                        ViewModelType = typeof(IndiceViewModel);//Pendiente
                        Contexto = new IndiceViewModel("EncargoCierre");
                        break;
                    case "Detalle impresión":
                        ViewModelType = typeof(DetalleIndiceViewModel);
                        Contexto = new DetalleIndiceViewModel("DocumentosImpresionIndiceDetalle");
                        break;

                    case "Revision de carpetas":
                        ViewModelType = typeof(IndiceViewModel);
                        Contexto = new IndiceViewModel("SupervisionIndice");
                        break;
                    case "Detalle archivos":
                        ViewModelType = typeof(DetalleIndiceViewModel);
                        Contexto = new DetalleIndiceViewModel("EncargoSupervisionIndiceDetalle");
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

        public static List<menuIndiceDetalle> GetAll()
        {
            ObservableCollection<menuIndiceDetalle> lista = new ObservableCollection<menuIndiceDetalle>
                {
               new menuIndiceDetalle {
                                id=1,
                                tabla="Indices",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Indices"
                                },
                new menuIndiceDetalle {
                                id=2,
                                tabla="Detalle Indices",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle Indices"
                                },
               /*new menuIndiceDetalle {
                                id=3,//Se utiliza en documentacion/carpetas
                                tabla="Carpetas",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Carpetas"
                                },
                new menuIndiceDetalle {
                                id=4,//Se utiliza en documentacion/carpetas
                                tabla="Detalle carpetas",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle carpetas"
                                },
               new menuIndiceDetalle {
                                id=5,//Se utiliza en documentacion/carpetas
                                tabla="Revision de papeles",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Revision de papeles"
                                },
                new menuIndiceDetalle {
                                id=6,//Se utiliza en documentacion/carpetas
                                tabla="Detalle papeles",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle papeles"
                                },*/
                    };


            return lista.OrderBy(x => x.id).ToList();
        }

        public static List<menuIndiceDetalle> GetAllDocumentacion()
        {
            ObservableCollection<menuIndiceDetalle> lista = new ObservableCollection<menuIndiceDetalle>
                {
               /*new menuIndiceDetalle("menuDocumentacion") {
                                id=1,
                                tabla="Indices",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Indices"
                                },
                new menuIndiceDetalle ("menuDocumentacion") {
                                id=2,
                                tabla="Detalle Indices",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle Indices"
                                },*/
               new menuIndiceDetalle ("MenuDocumentacion") {
                                id=3,//Se utiliza en documentacion/carpetas
                                tabla="Carpetas",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Carpetas"
                                },
                new menuIndiceDetalle ("MenuDocumentacion") {
                                id=4,//Se utiliza en documentacion/carpetas
                                tabla="Detalle carpetas",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle carpetas"
                                },

                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public static List<menuIndiceDetalle> GetAllCierre()
        {
            ObservableCollection<menuIndiceDetalle> lista = new ObservableCollection<menuIndiceDetalle>
                {
               /*new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=1,
                                tabla="Indices",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Indices"
                                },
                new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=2,
                                tabla="Detalle Indices",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle Indices"
                                },
               new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=3,//Se utiliza en documentacion/carpetas
                                tabla="Carpetas",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Carpetas"
                                },
                new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=4,//Se utiliza en documentacion/carpetas
                                tabla="Detalle carpetas",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle carpetas"
                                },*/
                 new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=5,//Se utiliza en documentacion/carpetas
                                tabla="Revision de papeles",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Revision de papeles"
                                },
                new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=6,//Se utiliza en documentacion/carpetas
                                tabla="Detalle papeles",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle papeles"
                                },
                    };


            return lista.OrderBy(x => x.id).ToList();
        }

        public static List<menuIndiceDetalle> GetAllConsultaDocumentos()
        {
            ObservableCollection<menuIndiceDetalle> lista = new ObservableCollection<menuIndiceDetalle>
                {
                    new menuIndiceDetalle ("MenuDetalleDocumentosConsulta") {
                                id=1,
                                tabla="Detalle consulta",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle consulta"
                                },
                    };


            return lista.OrderBy(x => x.id).ToList();
        }
        public static List<menuIndiceDetalle> GetAllImpresionDocumentos()
        {
            ObservableCollection<menuIndiceDetalle> lista = new ObservableCollection<menuIndiceDetalle>
                {
                    new menuIndiceDetalle ("MenuDetalleDocumentosImpresion") {
                                id=1,
                                tabla="Detalle impresión",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle impresión"
                                },
                    };


            return lista.OrderBy(x => x.id).ToList();
        }

        public static List<menuIndiceDetalle> GetAllSupervision()
        {
            ObservableCollection<menuIndiceDetalle> lista = new ObservableCollection<menuIndiceDetalle>
                {
               /*new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=1,
                                tabla="Indices",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Indices"
                                },
                new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=2,
                                tabla="Detalle Indices",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle Indices"
                                },
               new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=3,//Se utiliza en documentacion/carpetas
                                tabla="Carpetas",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Carpetas"
                                },
                new menuIndiceDetalle ("MenuCierreEncargo") {
                                id=4,//Se utiliza en documentacion/carpetas
                                tabla="Detalle carpetas",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle carpetas"
                                },*/
                 new menuIndiceDetalle ("MenuSupervisión") {
                                id=5,//Se utiliza en documentacion/carpetas
                                tabla="Revision de carpetas",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Revision de carpetas"
                                },
                new menuIndiceDetalle ("MenuSupervisión") {
                                id=6,//Se utiliza en documentacion/carpetas
                                tabla="Detalle archivos",
                                ViewType = typeof(DetalleIndiceViewModel),
                                ViewDisplay ="Detalle archivos"
                                },
                    };


            return lista.OrderBy(x => x.id).ToList();
        }

        //public menuIndiceDetalle(double i)
        //{
        //    _token = "MenuPlanificacion";
        //}

        //public menuIndiceDetalle(decimal i)
        //{
        //    _token = "MenuDocumentacion";
        //}
        //public menuIndiceDetalle(long i)
        //{
        //    _token = "MenuCierreEncargo";
        //}
        #endregion
    }
}