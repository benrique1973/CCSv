using CapaDatos;
using SGPTmvvm.ViewModel;
using System.Windows.Controls;

namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para tabcontenedorCliente
    /// </summary>
    public partial class tabcontenedorClienteEncargos : UserControl
    {
        //public tabcontenedorClienteEncargos(cliente Clientx, usuario currentUsuario, int opc)
        public tabcontenedorClienteEncargos(usuario currentUsuario)
        {
            InitializeComponent();
            //this.DataContext = new tabconenedorClienteEncargosViewModel(Clientx, currentUsuario, opc);
            this.DataContext = new tabconenedorClienteEncargosViewModel(currentUsuario);
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) tabconenedorClienteEncargosViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) tabconenedorClienteEncargosViewModel.Errors -= 1;
        }
        //public static int Errors { get; set; }//Para controllar los errores de edición
    }
}
