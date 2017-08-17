using CapaDatos;
using SGPTmvvm.ViewModel;
using System.Windows.Controls;

namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para tabcontenedorCliente
    /// </summary>
    public partial class tabcontenedorClienteContactos : UserControl
    {
        public tabcontenedorClienteContactos(usuario currentUsuario)
        {
            InitializeComponent();
            this.DataContext = new tabconenedorClienteContactosViewModel(currentUsuario);
        }
    }
}
