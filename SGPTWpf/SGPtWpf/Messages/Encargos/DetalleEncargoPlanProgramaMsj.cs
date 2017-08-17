using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;

namespace SGPTWpf.SGPtWpf.Messages.Encargos
{
    class DetalleEncargoPlanProgramaMsj: MessageBase
    {
        public int opcionMenuPrincipal { get; set; }
        public ProgramaModelo programaModelo { get; set; }
        public UsuarioModelo usuarioModelo { get; set; }
        public int opcionMenuCrud { get; set; }

        public EncargoModelo currentEncargo { get; set; }

    }
}
