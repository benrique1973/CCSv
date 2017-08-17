using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Modales;
using SGPTmvvm.ViewModel;
using SGPTmvvm.Vistas;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Administracion.Firma;
using SGPTWpf.Views.Principales.Administracion.Firma;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Model.Menus
{
    public class MenuFirma : UIBase
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
    NavegacionFirma msg = new NavegacionFirma();
    //public FirmaInformeTiempoviewModel Contexto2 { get; set; }

    public MenuFirma NewMenuFirma
    {
        get { return GetValue(() => NewMenuFirma); }
        set { SetValue(() => NewMenuFirma, value); }
    }


    public MenuFirma()
    {
        Navegar = new RelayCommand(NavigateExecute);
    }
    //Var msg;
    public void NavigateExecute()
    {
        switch (ViewDisplay)
        {
            case "Configuracion":
                //ViewType = typeof(ConfiguracionView);
                ViewType = typeof(tabcontenedorFirmaConfiguracion);
                break;
            case "Tiempo":
                ViewType = typeof(TiempoView);
                break;
            case "Correspondencia":
                ViewType = typeof(CorrespondenciaView);
                break;
            case "Reuniones":
                ViewType = typeof(ReunionesView);
                break;
         }

        if ((View != null) && ViewType != null)
        {
            View = (UserControl)Activator.CreateInstance(ViewType);
        }
        else
        {

            View = (UserControl)Activator.CreateInstance(ViewType);

            switch (ViewDisplay)
            {
                case "Configuracion":
                    //ViewModelType = typeof(ViewModel.Administracion.Firma.tabconenedorFirmaConfiguracionViewModel);
                    //Contexto = new ViewModel.Administracion.Firma.tabconenedorFirmaConfiguracionViewModel();
                    ViewModelType = typeof(SGPTmvvm.ViewModel.tabconenedorFirmaConfiguracionViewModel);
                    SGPTmvvm.ViewModel.tabconenedorFirmaConfiguracionViewModel Contexto1 = new SGPTmvvm.ViewModel.tabconenedorFirmaConfiguracionViewModel();
                    msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto1 = Contexto1, opcionMenu=1  };
                    break;
                case "Tiempo":
                    ViewModelType = typeof(TiempoViewModel);
                    Contexto = new TiempoViewModel();
                    msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto, opcionMenu=2 };
                    break;
                case "Correspondencia":
                    ViewModelType = typeof(CorrespondenciaViewModel);
                    Contexto = new CorrespondenciaViewModel();
                    msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto, opcionMenu=3 };
                    break;
                case "Reuniones":
                    ViewModelType = typeof(ReunionesViewModel);
                    Contexto = new ReunionesViewModel();
                    msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto, opcionMenu=4 };
                    break;
              default:
                    //MessageDialog("Error en el switch");
                    break;
            }
        }
        //var msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
        Messenger.Default.Send<NavegacionFirma>(msg);
    }

}
}
