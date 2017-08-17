using CapaDatos;
using SGPTWpf.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.Administracion.Usuario
{
    class AdministracionUsuarioValidadoMensaje
    {
        public usuario usuarioMensaje { get; set; }

        public UsuarioModelo usuarioModelo { get; set; }
    }
}
