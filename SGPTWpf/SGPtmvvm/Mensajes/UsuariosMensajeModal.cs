using SGPTmvvm.ViewModel.FilaVM;

/*Navegacion para la tabla usuarios*/
namespace SGPTmvvm.Mensajes
{
    public class UsuariosMensajeModal
    {
        //public bool EsEnvioAccionViewModel { get; set; } //sirve para sub-delegarle el mensaje al viewmodel 'CRUDusuariosViewModel'de accion Nuevo/Editar, que viene desde la ventana del padre Usuarios
        //public bool EsOrdenDesdeViewModel { get; set; } //Orden que emite el viewModel para que la vista se des-Active, y retorne al padre. las ordenes son _result = true; //HideHandlerDialog();
        //public bool EsParaUsuariosView { get; set; } //si el mensaje es para la vista de usuarios.
        //public bool _result { get; set; }
        public TipoComando Accion { get; set; }
        public UsuariosVM usuarioAModificar {get;set;}
        
        //public UserControl vistaModal { get; set; }
    }
}
