using SGPTmvvm.ViewModel;
using System.Windows.Controls;

namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para RolesView.xaml
    /// </summary>
    public partial class PermisosRolesView : UserControl
    {
        public PermisosRolesView()
        {
            InitializeComponent();
            this.DataContext = new PermisosRolesViewModel();
        }
    }
}
