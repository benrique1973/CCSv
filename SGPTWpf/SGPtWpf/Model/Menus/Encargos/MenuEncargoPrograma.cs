using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Programas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;

using System;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Menus.Encargos
{
    public class MenuEncargoProgramas : UIBase
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

        #region tokenEnvio

        private string _tokenEnvio;
        private string tokenEnvio
        {
            get { return _tokenEnvio; }
            set { _tokenEnvio = value; }
        }

        #endregion
        public MenuEncargoProgramas NewMenuEncargoProgramas
        {
            get { return GetValue(() => NewMenuEncargoProgramas); }
            set { SetValue(() => NewMenuEncargoProgramas, value); }
        }


        public MenuEncargoProgramas()
        {
            _tokenEnvio = "EncargosPlanificacionProgramaDatosVista";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            ViewType = typeof(DetalleProgramaEdicionView);
            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                ViewModelType = typeof(DetalleProgramaViewModel);
                Contexto = new DetalleProgramaViewModel("Programas");
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, tokenEnvio);
        }

    }
}