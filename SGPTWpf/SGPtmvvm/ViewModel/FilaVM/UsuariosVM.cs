using SGPTmvvm.Soporte;
using SGPTmvvm.Model;



namespace SGPTmvvm.ViewModel.FilaVM
{
    public class UsuariosVM : VMBase
    {
        public usuariospersonas TheUsuariosPersonas { get; set; }
        public UsuariosVM()
        {
            TheUsuariosPersonas = new usuariospersonas();
        }
    }
}