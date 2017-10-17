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
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Balances;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Balances.DetalleBalance;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class menuBalanceDetalle : UIBase
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

        public menuBalanceDetalle NewMenuHerramienta
        {
            get { return GetValue(() => NewMenuHerramienta); }
            set { SetValue(() => NewMenuHerramienta, value); }
        }


        public menuBalanceDetalle()
        {
            _token = "MenuDocumentacion";//Se usa el mismo token que documentacion porque es al mismo frame que se manda la informacion
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Balances":
                    ViewType = typeof(BalancesView);
                    break;
                case "Detalle Balance":
                    ViewType = typeof(DetalleBalanceView);
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
                    case "Detalle Balance":
                        ViewModelType = typeof(DetalleBalanceViewModel);
                        Contexto = new DetalleBalanceViewModel("Detalle Balance");
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

        public static List<menuBalanceDetalle> GetAll()
        {
            ObservableCollection<menuBalanceDetalle> lista = new ObservableCollection<menuBalanceDetalle>
                {
               new menuBalanceDetalle {
                                id=1,
                                tabla="Balances",
                                ViewType = typeof(BalancesViewModel),
                                ViewDisplay ="Balances"
                                },
                new menuBalanceDetalle {
                                id=2,
                                tabla="Detalle Balance",
                                ViewType = typeof(DetalleBalanceViewModel),
                                ViewDisplay ="Detalle Balance"
                                },
                    };

            return lista.OrderBy(x => x.id).ToList();
        }

        public menuBalanceDetalle(int i)
        {
            _token = "MenuDocumentacion";
        }
        #endregion
    }
}