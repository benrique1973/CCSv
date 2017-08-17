using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion.HerramientasProgramas;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using SGPTWpf.Views.Principales.Herramientas.Cuestionarios;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Model.Menus.Herramientas
{
    public class MenuHerramientasCuestionario : UIBase
    {
        public string ViewDisplay { get; set; }
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public RelayCommand Navegar { get; set; }

        public ViewModeloBase Contexto { get; set; }
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
        public MenuHerramientasCuestionario NewMenuHerramientasCuestionario
        {
            get { return GetValue(() => NewMenuHerramientasCuestionario); }
            set { SetValue(() => NewMenuHerramientasCuestionario, value); }
        }


        public MenuHerramientasCuestionario()
        {
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            ViewType = typeof(HerramientaCuestionarioEdicionView);
            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                ViewModelType = typeof(DetalleHerramientaCuestionarioViewModel);
                Contexto = new DetalleHerramientaCuestionarioViewModel();
            }
            var msg = new NavegacionHerramientaCuestionario { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg);
        }
    }
}