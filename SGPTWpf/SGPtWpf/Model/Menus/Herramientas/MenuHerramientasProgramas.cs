using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.HerramientasProgramas;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Herramientas.Programas;
using SGPTWpf.Views.Principales.Herramientas.Tools;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Model.Menus.Herramientas
{
    public class MenuHerramientasProgramas : UIBase
    {
        public string ViewDisplay { get; set; }
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public RelayCommand Navegar { get; set; }
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
        public ViewModeloBase Contexto { get; set; }

        #region tokenHerramientaEnvio

        private string _tokenHerramientaEnvio;
        private string tokenHerramientaEnvio
        {
            get { return _tokenHerramientaEnvio; }
            set { _tokenHerramientaEnvio = value; }
        }

        #endregion

        public MenuHerramientasProgramas NewMenuHerramientasProgramas
        {
            get { return GetValue(() => NewMenuHerramientasProgramas); }
            set { SetValue(() => NewMenuHerramientasProgramas, value); }
        }


        public MenuHerramientasProgramas()
        {
            Navegar = new RelayCommand(NavigateExecute);
            _tokenHerramientaEnvio = "HerramientasVistaDatos";
        }
        public void NavigateExecute()
        {
            ViewType = typeof(HerramientasProgramaEdicionView);
            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                ViewModelType = typeof(DetalleHerramientaViewModel);
                Contexto = new DetalleHerramientaViewModel();
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, tokenHerramientaEnvio);
        }
    }
}