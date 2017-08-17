using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.Model.Modelo.programas
{
    public class EtapaProgramaModelo : UIBase
    {
        public int idEtapaPrograma//correlativo
        {
            get { return GetValue(() => idEtapaPrograma); }
            set { SetValue(() => idEtapaPrograma, value); }
        }
        [MaxLength(1, ErrorMessage = "No  puede ser mayor a 1 caracter")]
        public string etapaprograma
        {
            get { return GetValue(() => etapaprograma); }
            set { SetValue(() => etapaprograma, value); }
        }
        public string descripcionEtapaprograma
        {
            get { return GetValue(() => descripcionEtapaprograma); }
            set { SetValue(() => descripcionEtapaprograma, value); }
        }

        #region Public Model Methods

        public static List<EtapaProgramaModelo> GetAll()
        {
            var lista = new ObservableCollection<EtapaProgramaModelo>
            {
               new EtapaProgramaModelo {
                                        idEtapaPrograma=1,
                                        etapaprograma="I",
                                        descripcionEtapaprograma="Inicial"
                                      },
               new EtapaProgramaModelo {
                                        idEtapaPrograma=2,
                                        etapaprograma="P",
                                        descripcionEtapaprograma="En proceso"
                                      },
               new EtapaProgramaModelo {
                                        idEtapaPrograma=3,
                                        etapaprograma="T",
                                        descripcionEtapaprograma="Terminado"
                                      },
                new EtapaProgramaModelo {
                                        idEtapaPrograma=4,
                                        etapaprograma="R",
                                        descripcionEtapaprograma="Revisado"
                                      },
               new EtapaProgramaModelo {
                                        idEtapaPrograma=5,
                                        etapaprograma="C",
                                        descripcionEtapaprograma="Cerrado"
                                      }
            };
            return lista.OrderBy(x => x.idEtapaPrograma).ToList();
        }


        #endregion

        #region Filtro
        public static EtapaProgramaModelo seleccionEtapa(string etapaprograma)
        {
            EtapaProgramaModelo respuesta = null;
            switch (etapaprograma.ToUpper())
            {
                case "I":
                    respuesta = new EtapaProgramaModelo
                    {
                        idEtapaPrograma= 1,
                        etapaprograma = "I",
                        descripcionEtapaprograma = "Inicial"
                    };
                    break;
                case "P":
                    respuesta = respuesta = new EtapaProgramaModelo
                    {
                        idEtapaPrograma= 2,
                        etapaprograma = "P",
                        descripcionEtapaprograma = "En proceso"
                    };
                    break;
                case "T":
                    respuesta = respuesta = new EtapaProgramaModelo
                    {
                        idEtapaPrograma= 3,
                        etapaprograma = "T",
                        descripcionEtapaprograma = "Terminado"
                    };
                    break;
                case "R":
                    respuesta = new EtapaProgramaModelo
                    {
                        idEtapaPrograma= 4,
                        etapaprograma = "R",
                        descripcionEtapaprograma = "Revisado"
                    };
                    break;
                case "C":
                    respuesta = new EtapaProgramaModelo
                    {
                        idEtapaPrograma= 5,
                        etapaprograma = "C",
                        descripcionEtapaprograma = "Cerrado"
                    };
                    break;
                default:
                    respuesta = new EtapaProgramaModelo
                    {
                        idEtapaPrograma= 6,
                        etapaprograma = "Z",
                        descripcionEtapaprograma = "Error en registro"
                    };
                    break;
            }
            return respuesta;
        }

        public static string nombreEtapa(string inicialesEtapaPrograma)
        {
            string respuesta = "";
            switch (inicialesEtapaPrograma.ToUpper())
            {
                case "I":
                    respuesta ="Inicial";
                    break;
                case "P":
                    respuesta = "En proceso";
                    break;
                case "T":
                    respuesta = "Terminado";
                    break;
                case "R":
                    respuesta ="Revisado";
                    break;
                case "C":
                    respuesta ="Cerrado";
                    break;
                default:
                    respuesta = "Error en registro";
                    break;
            }
            return respuesta;
        }

        #endregion
    }
}
