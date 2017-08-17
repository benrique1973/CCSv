using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cierre.Reapertura;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cierre.Reapertura;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Encargos.Cierre;
using SGPTWpf.Views.Principales.Encargos.Cierre;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class CierreModelo : UIBase
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

        public CierreModelo NewCierreModelo
        {
            get { return GetValue(() => NewCierreModelo); }
            set { SetValue(() => NewCierreModelo, value); }
        }

        public CierreModelo()
        {
            _token = "MenuCierreEncargo";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Revision de papeles":
                    ViewType = typeof(IndiceView);
                    break;
                case "Cierre de encargo":
                    ViewType = typeof(CierreEncargoView);
                    break;
                case "Reapertura de papeles":
                    ViewType = typeof(ReaperturaView);
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
                    case "Revision de papeles":
                        ViewModelType = typeof(IndiceViewModel);
                        Contexto = new IndiceViewModel("EncargoCierre");
                        break;
                    case "Cierre de encargo":
                        ViewModelType = typeof(CierreEncargoViewModel);
                        Contexto = new CierreEncargoViewModel();
                        break;
                    case "Reapertura de papeles":
                        ViewModelType = typeof(ReaperturaViewModel);
                        Contexto = new ReaperturaViewModel("EncargosCierreReapertura");
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

        public static List<CierreModelo> GetAll()
        {
            var lista = new ObservableCollection<CierreModelo>
        {
               new CierreModelo {
                                id=1,
                                tabla="Indices",
                                ViewType = typeof(IndiceViewModel),
                                ViewDisplay ="Revision de papeles"
                                },
               new CierreModelo {
                                id=2,
                                tabla="Encargos",
                                ViewType =  typeof(CierreEncargoViewModel),
                                ViewDisplay ="Cierre de encargo"
                                },
               new CierreModelo {
                                id=3,
                                tabla="Reapertura",
                                ViewType =  typeof(ReaperturaViewModel),
                                ViewDisplay ="Reapertura de papeles"
                                },
            };
            return lista.OrderBy(x => x.ViewDisplay).ToList();
        }

        public CierreModelo(int i)
        {
            _token = "MenuCierreEncargo";
        }
        #endregion
    }
}