using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.Messages.Genericos;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Repositorio;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using System;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Menus
{
    public class contenidoPDF : UIBase
    {
        public string ViewDisplay { get; set; }
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
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
        public RelayCommand Navegar { get; set; }

        public ViewModeloBase Contexto { get; set; }

        public contenidoPDF NewcontenidoPDF
        {
            get { return GetValue(() => NewcontenidoPDF); }
            set { SetValue(() => NewcontenidoPDF, value); }
        }
        #region token

        private string _token;
        private string token
        {
            get { return _token; }
            set { _token = value; }
        }

        #endregion

        public contenidoPDF()
        {
            _token = "contenidoDocumento";
            Navegar = new RelayCommand(NavigateExecute);
        }
        public void NavigateExecute()
        {
            ViewType = typeof(PDFContenidoView);
            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                ViewModelType = typeof(gestorPDF);
                Contexto = new gestorPDF();
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }
        public void NavigateExecute(RepositorioMsj msj)
        {
            ViewType = typeof(PDFContenidoView);
            if ((View != null) && ViewType != null)
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
            }
            else
            {
                View = (UserControl)Activator.CreateInstance(ViewType);
                ViewModelType = typeof(gestorPDF);
                Contexto = new gestorPDF(msj);
            }
            var msg = new NavegacionSgpt { View = View, ViewModelType = ViewModelType, ViewType = ViewType, Contexto = Contexto };
            Messenger.Default.Send(msg, token);
        }
    }
}