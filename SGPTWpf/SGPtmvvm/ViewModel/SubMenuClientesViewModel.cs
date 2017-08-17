using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Soporte;
using SGPTmvvm.Vistas;
using System;
using System.Windows;
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
    public class SubMenuClientesViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the SubMenuFirmaViewModel class.
        /// </summary>
        public SubMenuClientesViewModel()
        {
            _canExecute = true;
        }
        private bool _canExecute;
        public UserControl Viewx { get; set; }
        public Type ViewTypex { get; set; }
        public Type ViewModelTypex { get; set; }

        public ICommand _clickClientesContactos;
        public ICommand ClickClientesContactos 
        { 
            get 
            { 
                return _clickClientesContactos ?? (_clickClientesContactos = new CommandHandler(() => MyClientesContacto(), _canExecute)); 
            } 
        }


        public ICommand _ClickClientesEncargos;
        public ICommand ClickClientesEncargos { get { return _ClickClientesEncargos ?? (_ClickClientesEncargos = new CommandHandler(() => MyClientesEncargo(), _canExecute)); } }


        public ICommand _ClickClientesExpedientes;
        public ICommand ClickClientesExpedientes { get { return _ClickClientesExpedientes ?? (_ClickClientesExpedientes = new CommandHandler(() => MyClientesExpedientes(), _canExecute)); } }

        //public ICommand _clicFirmaRuniones;
        //public ICommand ClickFirmaReuniones { get { return _clicFirmaRuniones ?? (_clicFirmaRuniones = new CommandHandler(() => MyFirmaReuniones(), _canExecute)); } }


        private void MyClientesContacto()
        {
            MessageBox.Show("ClientesContactos");
            GC.Collect();

            //ViewTypex = typeof(tabcontenedorClientesContactos);
            //Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
            //var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex, pestaña = "Clientes", cualPanel = "Derecho" };
            //Messenger.Default.Send<NavegacionMensajeMain>(msg);

            RaisePropertyChanged("Views");
            RaisePropertyChanged();
        }

        private void MyClientesEncargo()
        {
            MessageBox.Show("En desarrollo...");
        }

        private void MyClientesExpedientes()
        {
            MessageBox.Show("En desarrollo...");
        }

    }
}