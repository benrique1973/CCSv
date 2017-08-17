using CapaDatos;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
//using SGPTmvvm.Vistas;
using SGPTWpf.SGPtmvvm;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using SGPTmvvm.Vistas;
using SGPTmvvm.ViewModel;

namespace SGPTWpf.Model.Menus
{
    public class MenuClientes : UIBase
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
        public MenuClientes NewMenuClientes
        {
            get { return GetValue(() => NewMenuClientes); }
            set { SetValue(() => NewMenuClientes, value); }
        }
        public MenuClientes()
        {
            //Navegar = new RelayCommand(NavigateExecute(cliente cli));
        }

        public void NavigateExecute(cliente cli, usuario currentUsuario, int i)
        {
            try
            {
                cliente cc = cli;
                switch (ViewDisplay)
                {
                    case "Contactos":
                        ViewType = typeof(tabcontenedorClienteContactos);
                        //View = (UserControl)Activator.CreateInstance(ViewType);
                        View = new tabcontenedorClienteContactos(currentUsuario);
                        ViewModelType = typeof(tabconenedorClienteContactosViewModel);
                        SGPTmvvm.ViewModel.tabconenedorClienteContactosViewModel Contexto1 = new SGPTmvvm.ViewModel.tabconenedorClienteContactosViewModel(currentUsuario);
                        var msg = new NavegacionCliente { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto1 = Contexto1, opcionMenu = 1 };
                        Messenger.Default.Send<NavegacionCliente>(msg);
                        break;
                    case "Encargos":
                        ViewType = typeof(tabcontenedorClienteEncargos);
                        //View = new tabcontenedorClienteEncargos(cli, currentUsuario, i);
                        View = new tabcontenedorClienteEncargos(currentUsuario);
                        ViewModelType = typeof(SGPTmvvm.ViewModel.tabconenedorClienteEncargosViewModel);
                        //SGPTmvvm.ViewModel.tabconenedorClienteEncargosViewModel Contexto3 = new SGPTmvvm.ViewModel.tabconenedorClienteEncargosViewModel(cli, currentUsuario, i);
                        SGPTmvvm.ViewModel.tabconenedorClienteEncargosViewModel Contexto3 = new SGPTmvvm.ViewModel.tabconenedorClienteEncargosViewModel(currentUsuario);
                        var msgt = new NavegacionCliente { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto3 = Contexto3, opcionMenu = 3 }; //3 es expedientes
                        Messenger.Default.Send<NavegacionCliente>(msgt);
                        break;
                    case "Expedientes":
                        ViewType = typeof(tabcontenedorClienteExpedientes);
                        //View = new tabcontenedorClienteExpedientes(cli, currentUsuario,i); //i=1 es crear, i=2 es editar; i=3 es consultar
                        View = new tabcontenedorClienteExpedientes(currentUsuario); //i=1 es crear, i=2 es editar; i=3 es consultar
                        ViewModelType = typeof(SGPTmvvm.ViewModel.tabconenedorClienteExpedientesViewModel);
                        //SGPTmvvm.ViewModel.tabconenedorClienteExpedientesViewModel Contexto2 = new SGPTmvvm.ViewModel.tabconenedorClienteExpedientesViewModel(cli, currentUsuario, i);
                        SGPTmvvm.ViewModel.tabconenedorClienteExpedientesViewModel Contexto2 = new SGPTmvvm.ViewModel.tabconenedorClienteExpedientesViewModel(currentUsuario);
                        var msgs = new NavegacionCliente { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto2 = Contexto2, opcionMenu = 2 }; //3 es expedientes
                        Messenger.Default.Send<NavegacionCliente>(msgs);
                        break;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error "+er.InnerException);
            }

        }


    }

    //var msg;
    //    if ((View != null) && ViewType != null)
    //    {
    //        View = (UserControl)Activator.CreateInstance(ViewType);
    //    }
    //    else
    //    {

    //        View = (UserControl)Activator.CreateInstance(ViewType);

    //        switch (ViewDisplay)
    //        {
    //            case "Contactos":
    //                ViewModelType = typeof(SGPTmvvm.ViewModel.tabconenedorClienteContactosViewModel);
    //                SGPTmvvm.ViewModel.tabconenedorClienteContactosViewModel Contexto1 = new SGPTmvvm.ViewModel.tabconenedorClienteContactosViewModel();
    //                var msg = new NavegacionCliente { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto1 = Contexto1, opcionMenu = 1 };
    //                Messenger.Default.Send<NavegacionCliente>(msg);
    //                break;
    //            case "Encargos":
    //                //ViewModelType = typeof(ViewModel.Administracion.Firma.tabconenedorFirmaConfiguracionViewModel);
    //                //Contexto = new ViewModel.Administracion.Firma.tabconenedorFirmaConfiguracionViewModel();

    //                //ViewModelType = typeof(SGPTmvvm.ViewModel.tabconenedorFirmaConfiguracionViewModel);
    //                //SGPTmvvm.ViewModel.tabconenedorFirmaConfiguracionViewModel Contexto1 = new SGPTmvvm.ViewModel.tabconenedorFirmaConfiguracionViewModel();
    //                //msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto1 = Contexto1, opcionMenu = 1 };
    //                break;
    //            case "Expedientes":
    //                //ViewModelType = typeof(TiempoViewModel);
    //                //Contexto = new TiempoViewModel();
    //                //msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto, opcionMenu = 2 };
    //                break;              
    //            default:
    //                break;
    //        }
    //    }
    //    //var msg = new NavegacionFirma { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
    //    //Messenger.Default.Send<NavegacionFirma>(msg);
}
