//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SGPTWpf.SGPtmvvm.Mensajes
//{
//    class GenerarReporteMensajeModal
//    {
//    }
//}

using CapaDatos;
using SGPTmvvm.Mensajes;
using SGPTmvvm.Model;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPtmvvm.Mensajes
{
    public class GenerarReporteMensajeModal
    {
        public TipoReporteAGenerar TipoReporteAGenerar { get; set; }

        //*****Datos Para reporte de matriz de riesgos*********/
        //se necesita recibir [1] el encabezado, [2] la lista del cuerpo, [3] los calculos del pie de pagina
        //[1]  y [3] los va a recibir en una clase llena previamente por el emisor
        public EncabezadosPiesReporteMatrizRiesgos EncabezadosPiesReporteMatrizRiesgos { get; set; }


        //[2]
        public ObservableCollection<DetalleMatrizRiesgoModelo> listaMatrizRiesgoModelo;


        //*****Datos para reporte de programas y cuestionarios*** (pendiente aun)
        public EncabezadosPiesReportesProgramasCuestionarios EncabezadosPiesReportesProgramasCuestionarios { get; set; }
        public ObservableCollection<DetalleProgramaModelo> listaObjetivos;
        public ObservableCollection<DetalleProgramaModelo> listaAlcances;
        public ObservableCollection<DetalleProgramaModelo> listaDetalleProcedimientos;
        //Para los cuestionarios.
        public ObservableCollection<DetalleCuestionarioModelo> listaObjetivosC;
        public ObservableCollection<DetalleCuestionarioModelo> listaAlcancesC;
        public ObservableCollection<DetalleCuestionarioModelo> listaDetalleProcedimientosC;

        //Para la impresion de portadas de las carpetas Corriente, permanente, etc.
        public EncabezadosPiesReportesPortadasCarpetas EncabezadosPiesReportesPortadasCarpetas { get; set; }

        //Para la impresion del indice de cada una de las carpetas Corriente, permanente, etc.
        public ObservableCollection<IndiceModelo> listaDetalleHerramienta = new ObservableCollection<IndiceModelo>();
        public EncabezadosPiesReportesIndiceCarpetas EncabezadosPiesReportesIndiceCarpetas { get; set; }


        //para la cedula de marcas.
        public ObservableCollection<CedulaMarcasModelo> listaCedulaMarcas = new ObservableCollection<CedulaMarcasModelo>();
        public EncabezadosSinPiesReporteMarcas EncabezadosSinPiesReporteMarcas { get; set; }

        //para la cedula de hallazgos
        public ObservableCollection<CedulaHallazgosModelo> listaCedulaHallazgos = new ObservableCollection<CedulaHallazgosModelo>();
        public EncabezadosSinPiesReporteCedulaHallazgos EncabezadosSinPiesReporteCedulaHallazgos { get; set; }

        //para la cedula de Notas
        public ObservableCollection<CedulaNotasModelo> listaCedulaNotas = new ObservableCollection<CedulaNotasModelo>();
        public EncabezadosSinPiesReporteCedulaNotas EncabezadosSinPiesReporteCedulaNotas { get; set; }

        //para la cedula de Ajustes y Reclasificaciones
        public ObservableCollection<CedulaDiarioModelo> listaAjustesReclasificaciones = new ObservableCollection<CedulaDiarioModelo>();
        public EncabezadosSinpiesCedulaAjustesReclasificaciones EncabezadosSinpiesCedulaAjustesReclasificaciones { get; set; }

        //para las cedulas sumarias.
        public ObservableCollection<DetalleCedulaModelo> listaCedulaSumaria = new ObservableCollection<DetalleCedulaModelo>();
        public EncabezadosPiesReportesSumarias EncabezadosPiesReportesSumarias { get; set; }

        /// <summary>
        /// Esto del final creo que no lo utilizare pq la idea es que todos los datos ya vengan cocinados y solo de mostrar.
        /// asi se cumple que una funcion debe hacerse especificamente para un solo proposito.
        /// </summary>

        public ClienteModelo currentCliente { get; set; }
        //public usuario currentUsuario { get; set; }
        public UsuarioModelo currentUsuario { get; set; }
        public string TokenAUtilizar { get; set; }
        public sistemascontable currentSistemaContable { get; set; }
        public encargo currentEncargos { get; set; }
        public EncargoModelo currentEncargoModelo { get; set; }


        public MatrizRiesgoModelo matrizRiesgoModelo { get; set; }
        public EncargoModelo encargoModelo { get; set; }
        public UsuarioModelo usuarioModelo { get; set; }
        //public ObservableCollection<DetalleMatrizRiesgoModelo> listaMatrizRiesgoModelo;
        public SistemaContableModelo sistemaContableModelo { get; set; }
    }
}

