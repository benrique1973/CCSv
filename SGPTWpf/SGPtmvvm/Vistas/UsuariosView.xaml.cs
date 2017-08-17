using SGPTmvvm.ViewModel;
using System.Windows.Controls;
namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para UsuariosView.xaml
    /// </summary>
    public partial class UsuariosView : UserControl
    {
        public UsuariosView()
        {
            InitializeComponent();
            this.DataContext = new UsuariosViewModel();
        }
    }
}
