using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;

namespace SGPTWpf.SGPtWpf.Messages.Genericos
{
    public class EncargosDatosMsj //: Messenger
    {
            public UsuarioModelo usuarioModelo {get; set;}
            public EncargoModelo encargoModelo { get; set; }

            public string tokenRespuesta { get; set; }

            public string tokenRespuestaDetalle { get; set; }

            public string tabla { get; set; }

    }
}