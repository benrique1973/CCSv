using CapaDatos;
using SGPTmvvm.ViewModel.FilaVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Mensajes
{
    public class PermisosRolesMensajeModal
    {
        public TipoComando Accion { get; set; }
        public usuario currentUsuario { get; set; }
        public UsuariosVM rolesAmodificar { get; set; }
    }
}
