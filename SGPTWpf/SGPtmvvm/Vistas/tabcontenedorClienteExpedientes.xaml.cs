using CapaDatos;
using SGPTmvvm.ViewModel;
using System.Windows.Controls;

namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para tabcontenedorCliente
    /// </summary>
    public partial class tabcontenedorClienteExpedientes : UserControl
    {
        //public tabcontenedorClienteExpedientes(cliente Clientx, usuario currentUsuario, int opc)
        public tabcontenedorClienteExpedientes(usuario currentUsuario)
        {
            InitializeComponent();
            this.DataContext = new tabconenedorClienteExpedientesViewModel(currentUsuario);
        }
    }
}
