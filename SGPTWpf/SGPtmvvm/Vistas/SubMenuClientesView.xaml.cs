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
    public partial class SubMenuClientesView : UserControl
    {
        //private bool _canExecute;
        public SubMenuClientesView()
        {
            InitializeComponent();
            //_canExecute = true;
            this.DataContext = new SubMenuClientesViewModel();
        }
 

    }

    
}
