using GalaSoft.MvvmLight;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using SGPTmvvm.Mensajes;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Vistas;
using SGPTmvvm.Soporte;

namespace SGPTmvvm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _canExecute = true;
            //ThrobberVisible = Visibility.Collapsed;
        }
        private bool _canExecute;
        private Visibility throbberVisible;
        public Visibility ThrobberVisible
        {
            get { return throbberVisible; }
            set
            {
                throbberVisible = value;
                RaisePropertyChanged();
            }
        }

        public UserControl Viewx { get; set; }
        public Type ViewTypex { get; set; }
        public Type ViewModelTypex { get; set; }

        public ICommand _clicUsuarios;
        public ICommand ClickUsuarios { get { return _clicUsuarios ?? (_clicUsuarios = new CommandHandler(() => MyUsuarios(), _canExecute)); } }

        
        public ICommand _clickRoles;
        public ICommand ClickRoles { get { return _clickRoles ?? (_clickRoles = new CommandHandler(() => MyRoles(), _canExecute)); } }

        
        public ICommand _clickFirma;
        public ICommand ClickFirma { get { return _clickFirma ?? (_clickFirma = new CommandHandler(() => MyFirma(), _canExecute)); } }

        

        
        //ClickRoles
        private ICommand _clickCommand;
        public ICommand ClickCommand { get{return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction2(), _canExecute));}}
        
        private ICommand _clickCommand2;
        public ICommand ClickCommand2
        {
            get
            {
                return _clickCommand2 ?? (_clickCommand2 = new CommandHandler(() => MyAction3(), _canExecute));
            }
        }

        private ICommand _clickCommand4;
        public ICommand ClickCommand4
        {
            get
            {
                return _clickCommand4 ?? (_clickCommand4 = new CommandHandler(() => MyAction4(), _canExecute));
            }
        }



        private void MyUsuarios()
        {
            GC.Collect();
            //ThrobberVisible = Visibility.Collapsed;
            //RaisePropertyChanged();
            ThrobberVisible = Visibility.Visible;
            RaisePropertyChanged();
            //RaisePropertyChanged("Views");
            ViewTypex = typeof(UsuariosView);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            ViewModelTypex = typeof(UsuariosViewModel);
            var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };

            Messenger.Default.Send<NavegacionMensajeMain>(msg);
            RaisePropertyChanged("Views");
            ThrobberVisible = Visibility.Collapsed;
            RaisePropertyChanged();
        }
        private void MyRoles()
        {
            GC.Collect();
            ThrobberVisible = Visibility.Collapsed;
            RaisePropertyChanged();
            ThrobberVisible = Visibility.Visible;
            RaisePropertyChanged();
            ViewTypex = typeof(PermisosRolesView);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            ViewModelTypex = typeof(PermisosRolesViewModel);
            var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };          
            Messenger.Default.Send<NavegacionMensajeMain>(msg);
            RaisePropertyChanged("Views");
            ThrobberVisible = Visibility.Collapsed;
            RaisePropertyChanged();
            //MessageBox.Show("De regreso en roles");
        }

        private void MyFirma()
        {
            GC.Collect();
            ThrobberVisible = Visibility.Collapsed;
            RaisePropertyChanged();
            ThrobberVisible = Visibility.Visible;
            RaisePropertyChanged();
            ViewTypex = typeof(SubMenuFirmaView);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            //ViewModelTypex = typeof(RolesViewModel);
            var msg = new NavegacionMensajeMainPanelIzquierdo { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };
            Messenger.Default.Send<NavegacionMensajeMainPanelIzquierdo>(msg);
            RaisePropertyChanged("Views");
            ThrobberVisible = Visibility.Collapsed;
            RaisePropertyChanged();
        }
        public void MyAction4()
        {
            //RaisePropertyChanged("Views");
            //ViewTypex = typeof(UserControlCobro);
            //Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            //ViewModelTypex = typeof(userControlPagoViewModel);
            //var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };
            //GC.Collect();
            //Messenger.Default.Send<NavegacionMensajeMain>(msg);
        }
        public void MyAction2()
        {

            //ViewTypex = typeof(ActividadesView);
            //Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            ////ViewModelTypex = typeof(ActividadesViewModel);
            //var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };
            //Messenger.Default.Send<NavegacionMensajeMain>(msg);
        }
        public void MyAction3()
        {
            ////RaisePropertyChanged("Views");
            //ViewTypex = typeof(UserControlPago);
            //Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            //ViewModelTypex = typeof(userControlPagoViewModel);
            //var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };
            //Messenger.Default.Send<NavegacionMensajeMain>(msg);
        }


        /*************************************************************/

          
    }

    //public class CommandHandler : ICommand
    //{
    //    private Action _actionP;
    //    private bool _canExecute;
    //    public CommandHandler(Action actionp, bool canExecute)
    //    {
    //        _actionP = actionp;
    //        _canExecute = canExecute;
    //    }

    //    public bool CanExecute(object parameter)
    //    {
    //        return _canExecute;
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    public void Execute(object parameter)
    //    {
    //        _actionP();
    //    }
    //}  
   
}

  