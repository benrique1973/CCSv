using SGPTWpf.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.Administracion.Usuario
{
    class UsuarioListaMensaje
    {
        public ObservableCollection<UsuarioModelo> listaMensaje { get; set; }
    }
}
