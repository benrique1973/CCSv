using GalaSoft.MvvmLight.Messaging;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Soporte;
using SGPTmvvm.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para SubMenuFirma.xaml
    /// Submenu para el panel izquierdo de la opcion Administracion -> Firma. Tiene cuatro opciones: 1-Configuracion, 2-Tiempo, 3-Correspondencia, 4-Reuniones. 
    /// </summary>
    public partial class SubMenuFirmaView : UserControl
    {
       
        public SubMenuFirmaView()
        {
            InitializeComponent();
            this.DataContext = new SubMenuFirmaViewModel();
        }
        //public UserControl Viewx { get; set; }
        //public Type ViewTypex { get; set; }
        //public Type ViewModelTypex { get; set; }

        //public ICommand _clicFirmaConfiguracion;
        //public ICommand ClickFirmaConfiguracion { get { return _clicFirmaConfiguracion ?? (_clicFirmaConfiguracion = new CommandHandler(() => MyFirmaConfiguracion(), _canExecute)); } }

        //public ICommand _clicFirmaTiempo;
        //public ICommand ClickFirmaTiempo { get { return _clicFirmaTiempo ?? (_clicFirmaTiempo = new CommandHandler(() => MyFirmaTiempo(), _canExecute)); } }

        //public ICommand _clicFirmaCorrespondencia;
        //public ICommand ClickFirmaCorrespondencia { get { return _clicFirmaCorrespondencia ?? (_clicFirmaCorrespondencia = new CommandHandler(() => MyFirmaCorrespondencia(), _canExecute)); } }

        //public ICommand _clicFirmaRuniones;
        //public ICommand ClickFirmaReuniones { get { return _clicFirmaRuniones ?? (_clicFirmaRuniones = new CommandHandler(() => MyFirmaReuniones(), _canExecute)); } }

        //private void MyFirmaReuniones()
        //{
        //    throw new NotImplementedException();
        //}

        //private void MyFirmaCorrespondencia()
        //{
        //    throw new NotImplementedException();
        //}

        //private void MyFirmaTiempo()
        //{
        //    throw new NotImplementedException();
        //}
        //private void MyFirmaConfiguracion()
        //{
        //    GC.Collect();
        //    //ThrobberVisible = Visibility.Collapsed;
        //    //RaisePropertyChanged();
        //    //ThrobberVisible = Visibility.Visible;
        //    //RaisePropertyChanged();
        //    ViewTypex = typeof(RolesView);
        //    Viewx = (UserControl)Activator.CreateInstance(ViewTypex);
        //   // ViewModelTypex = typeof(RolesViewModel);
        //    var msg = new NavegacionMensajeMain { view = Viewx, ViewModelType = ViewModelTypex, ViewType = ViewTypex };
        //    Messenger.Default.Send<NavegacionMensajeMain>(msg);
        //    //RaisePropertyChanged("Views");
        //    //ThrobberVisible = Visibility.Collapsed;
        //    //RaisePropertyChanged();
        //    //MessageBox.Show("De regreso en roles");
        //    GC.Collect();
        //}

    }

    
}
