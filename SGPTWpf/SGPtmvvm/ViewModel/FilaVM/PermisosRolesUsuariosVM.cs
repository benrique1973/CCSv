using CapaDatos;
using SGPTmvvm.Soporte;

namespace SGPTmvvm.ViewModel.FilaVM
{
    public class PermisosRolesUsuariosVM : VMBase
    {
        public permisosrolesusuario ThePermisosRolesUsuarios { get; set; }

        public PermisosRolesUsuariosVM()
        {
            ThePermisosRolesUsuarios = new permisosrolesusuario();
        }
    }
}
