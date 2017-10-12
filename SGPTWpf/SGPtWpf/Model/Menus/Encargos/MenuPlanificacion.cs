using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using SGPTWpf.ViewModel.Encargos.Planificacion;
using SGPTWpf.ViewModel.Planificacion.Programas;
using SGPTWpf.Views.Principales.Encargos.Planificacion;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Model.Menus.Encargos
{
    public class MenuPlanificacion : UIBase
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
        public MenuPlanificacion NewMenuPlanificacion
        {
            get { return GetValue(() => NewMenuPlanificacion); }
            set { SetValue(() => NewMenuPlanificacion, value); }
        }


        public MenuPlanificacion()
        {
            _tokenEnvio = "MenuPlanificacion";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            switch (ViewDisplay)
            {
                case "Riesgo":
                    ViewType = typeof(RiesgoView);
                    break;
                case "Programas":
                    ViewType = typeof(ProgramasView);
                    break;
                case "Cuestionarios":
                    ViewType = typeof(CuestionariosView);
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
                    case "Riesgo":
                        ViewModelType = typeof(MatrizRiesgoViewModel);
                        Contexto = new MatrizRiesgoViewModel();
                        break;
                    case "Programas":
                        ViewModelType = typeof(ProgramasViewModel);
                        Contexto = new ProgramasViewModel("Programas");
                        break;
                    case "Cuestionarios":
                        ViewModelType = typeof(CuestionariosViewModel);
                        Contexto = new CuestionariosViewModel("Cuestionarios");
                        break;
                    default:
                        //MessageDialog("Error en el switch");
                        break;
                }
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, tokenEnvio);
        }
    }
}
