using CapaDatos;
using SGPTmvvm.Mensajes;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPtmvvm.Mensajes
{
    public class CargarArchivosMensajeModal
    {
        public TipoArchivoCargar TipoArchivoACargar { get; set; }
        //public cliente currentCliente { get; set; }
        public ClienteModelo currentCliente { get; set; }
        //public usuario currentUsuario { get; set; }
        public UsuarioModelo usuarioModelo { get; set; }
        public string TokenAUtilizar { get; set; }
        public sistemascontable currentSistemaContable { get; set; }
        //public encargo currentEncargos { get; set; }
        public EncargoModelo encargoModelo { get; set; }
    }
}
