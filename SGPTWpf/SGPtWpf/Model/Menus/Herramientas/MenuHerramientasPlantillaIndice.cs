using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.Views.Principales.Herramientas.Indice;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Model.Menus.Herramientas
{
    public class MenuHerramientasPlantillaIndice : UIBase
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

        public string token = "MenuHerramientasPlantillasIndices";

        public MenuHerramientasPlantillaIndice NewMenuHerramientasPlantillaIndice
        {
            get { return GetValue(() => NewMenuHerramientasPlantillaIndice); }
            set { SetValue(() => NewMenuHerramientasPlantillaIndice, value); }
        }


        public MenuHerramientasPlantillaIndice()
        {
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            ViewType = typeof(DetalleIndiceCrudView);
            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                ViewModelType = typeof(DetallePlantillaIndiceViewModel);
                Contexto = new DetallePlantillaIndiceViewModel();
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }
    }
}
