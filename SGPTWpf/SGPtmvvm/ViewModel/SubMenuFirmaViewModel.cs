using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Soporte;
using SGPTmvvm.Vistas;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTmvvm.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SubMenuFirmaViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SubMenuFirmaViewModel class.
        /// </summary>
        public SubMenuFirmaViewModel()
        {
            _canExecute = true;
        }
        private bool _canExecute;
        public UserControl Viewx { get; set; }
        public Type ViewTypex { get; set; }
        public Type ViewModelTypex { get; set; }

        public ICommand _clicFirmaConfiguracion;
        public ICommand ClickFirmaConfiguracion { get { return _clicFirmaConfiguracion ?? (_clicFirmaConfiguracion = new CommandHandler(() => MyFirmaConfiguracion(), _canExecute)); } }

        public ICommand _clicFirmaTiempo;
        public ICommand ClickFirmaTiempo { get { return _clicFirmaTiempo ?? (_clicFirmaTiempo = new CommandHandler(() => MyFirmaTiempo(), _canExecute)); } }

        public ICommand _clicFirmaCorrespondencia;
        public ICommand ClickFirmaCorrespondencia { get { return _clicFirmaCorrespondencia ?? (_clicFirmaCorrespondencia = new CommandHandler(() => MyFirmaCorrespondencia(), _canExecute)); } }

        public ICommand _clicFirmaRuniones;
        public ICommand ClickFirmaReuniones { get { return _clicFirmaRuniones ?? (_clicFirmaRuniones = new CommandHandler(() => MyFirmaReuniones(), _canExecute)); } }


        //private ICommand firmaConfiguracion { get; set; }
        //public ICommand FirmaConfiguracion
        //{
        //    get
        //    {
        //        return firmaConfiguracion ?? (firmaConfiguracion = new CommandHandler(() => cmdFirmaConfiguracion(), _canExecute));
        //    }
        //}

        private void MyFirmaConfiguracion()
        {
            GC.Collect();
            try
            {
                String Ubicacion = Path.Combine(Path.GetTempPath(), "SaveFoto.Bmp");
                if (File.Exists(Ubicacion))
                    File.Delete(Ubicacion);
            }
            catch { }
            ViewTypex = typeof(tabcontenedorFirmaConfiguracion);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex, pestaña = "Firmas", cualPanel = "Derecho"};
            Messenger.Default.Send<NavegacionMensajeMain>(msg);
            
            RaisePropertyChanged("Views");
            RaisePropertyChanged();
        }

        private void MyFirmaTiempo()
        {
            ViewTypex = typeof(TabFirmaTiempo);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex, pestaña = "Firmas", cualPanel = "Derecho" };
            Messenger.Default.Send<NavegacionMensajeMain>(msg);

            RaisePropertyChanged("Views");
            RaisePropertyChanged();
        }
        private void MyFirmaCorrespondencia()
        {
            ViewTypex = typeof(TabFirmaCorrespondencia);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex, pestaña = "Firmas", cualPanel = "Derecho" };
            Messenger.Default.Send<NavegacionMensajeMain>(msg);

            RaisePropertyChanged("Views");
            RaisePropertyChanged();
        }
        private void MyFirmaReuniones()
        {
            ViewTypex = typeof(TabFirmaReuniones);
            Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex, pestaña = "Firmas", cualPanel = "Derecho" };
            Messenger.Default.Send<NavegacionMensajeMain>(msg);

            RaisePropertyChanged("Views");
            RaisePropertyChanged();
        }
    }
}