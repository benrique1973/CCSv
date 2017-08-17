using System;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;

namespace SGPTmvvm.ViewModel.FilaVM
{
    public class VistaVM
    {
        public string ViewDisplay { get; set; }
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public RelayCommand Navigate { get; set; }
        public VistaVM()
        {
            Navigate = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            if (View == null && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            var msg = new NavegacionMensaje { view = View, ViewModelType = ViewModelType, ViewType = ViewType };
            Messenger.Default.Send<NavegacionMensaje>(msg);
        }
    }
}
