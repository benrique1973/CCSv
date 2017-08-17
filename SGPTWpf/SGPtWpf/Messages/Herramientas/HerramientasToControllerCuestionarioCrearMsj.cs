using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Model.Modelo.Herramientas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.Messages.Herramientas
{
    class HerramientasToControllerCuestionarioCrearMsj
    {
        public HerramientasModelo herramientaModeloElemento { get; set; }

        public ObservableCollection<HerramientasModelo> listaHerramientas { get; set; }
        public DetalleHerramientasModelo detalleHerramientaModelo { get; set; }

        public UsuarioModelo usuarioValidado { get; set; }

        public int cmd { set; get; }

        public int opcionMenu { get; set; }
    }
}
