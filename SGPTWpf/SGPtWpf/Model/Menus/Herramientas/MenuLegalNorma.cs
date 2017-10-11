using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Crud.CatalogoNormaLegalIndice;
using SGPTWpf.Views.Principales.Herramientas.Normativa;
using SGPTWpf.Views.Principales.Normas;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Model.Menus.Herramientas
{
    public class MenuLegalNorma : UIBase
    {
        public string ViewDisplay { get; set; }
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public RelayCommand Navegar { get; set; }

        public RelayCommand NavegarNormas { get; set; }
        public ViewModeloBase Contexto { get; set; }

        private string token = "MenuLegalNormas";
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
        public MenuLegalNorma NewMenuLegalNorma
        {
            get { return GetValue(() => NewMenuLegalNorma); }
            set { SetValue(() => NewMenuLegalNorma, value); }
        }
        public MenuLegalNorma()
        {
            Navegar = new RelayCommand(NavigateExecute);
            NavegarNormas = new RelayCommand(NavigateExecuteNormas);
        }
        public void NavigateExecute()
        {
            ViewType = typeof(GenericoNormaView);

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);

                        ViewModelType = typeof(CatalogoNormaLegalViewModel);
                        Contexto = new CatalogoNormaLegalViewModel("Normativa");
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }
        public void NavigateExecuteNormas()
        {
            ViewType = typeof(GenericoNormaConsultaView);

            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);

                ViewModelType = typeof(CatalogoNormaLegalViewModel);
                Contexto = new CatalogoNormaLegalViewModel("Normas");
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }
    }
}