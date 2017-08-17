using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.Encargos
{
    class AsignacionDatosMensaje
    {
        public AsignacionModelo asignacionModelo { get; set; }
        public ObservableCollection<AsignacionModelo> listaAsignacionModelo { get; set; }
        public int comandoCrud { get; set; }
        public UsuarioModelo usuarioModelo { get; set; }
    }
}
