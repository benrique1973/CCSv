using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public class EtapaEncargoModelo : UIBase
    {
        public int idEtapaEncargo //correlativo
        {
            get { return GetValue(() => idEtapaEncargo); }
            set { SetValue(() => idEtapaEncargo, value); }
        }
        [MaxLength(1, ErrorMessage = "No  puede ser mayor a 1 caracter")]
        public string etapaencargo
        {
            get { return GetValue(() => etapaencargo); }
            set { SetValue(() => etapaencargo, value); }
        }
        public string descripcionEtapaEncargo  
        {
            get { return GetValue(() => descripcionEtapaEncargo); }
            set { SetValue(() => descripcionEtapaEncargo, value); }
        }
        public string descripcionTipoAuditoria
        {
            get { return GetValue(() => descripcionTipoAuditoria); }
            set { SetValue(() => descripcionTipoAuditoria, value); }
        }

        #region Public Model Methods

        public static List<EtapaEncargoModelo> GetAll()
        {
            var lista = new ObservableCollection<EtapaEncargoModelo>
            {
               new EtapaEncargoModelo {
                                        idEtapaEncargo=1,
                                        etapaencargo="I",
                                        descripcionEtapaEncargo="Inicial"
                                      },
               new EtapaEncargoModelo {
                                        idEtapaEncargo=2,
                                        etapaencargo="P",
                                        descripcionEtapaEncargo="En proceso"
                                      },
               new EtapaEncargoModelo {
                                        idEtapaEncargo=3,
                                        etapaencargo="R",
                                        descripcionEtapaEncargo="Revisado"
                                      },
               new EtapaEncargoModelo {
                                        idEtapaEncargo=4,
                                        etapaencargo="C",
                                        descripcionEtapaEncargo="Cerrado"
                                      },
               new EtapaEncargoModelo {
                                        idEtapaEncargo=5,
                                        etapaencargo="E",
                                        descripcionEtapaEncargo="Ejecutado"
                                      },
               new EtapaEncargoModelo {
                                        idEtapaEncargo=6,
                                        etapaencargo="A",
                                        descripcionEtapaEncargo="Aprobado"
                                      },
               new EtapaEncargoModelo {
                                        idEtapaEncargo=7,
                                        etapaencargo="T",
                                        descripcionEtapaEncargo="Terminado"
                                      }
            };
            return lista.OrderBy(x => x.idEtapaEncargo).ToList();
        }


        #endregion

        #region Filtro
        public static EtapaEncargoModelo seleccionEtapa(string etapaencargo)
        {
            EtapaEncargoModelo respuesta =null;
            switch (etapaencargo.ToUpper())
            {
                case "I":
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 1,
                        etapaencargo = "I",
                        descripcionEtapaEncargo = "Inicial"
                    };
                    break;
                case "P":
                    respuesta = respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 2,
                        etapaencargo = "P",
                        descripcionEtapaEncargo = "En proceso"
                    };
                    break;
                case "R":
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 3,
                        etapaencargo = "R",
                        descripcionEtapaEncargo = "Revisado"
                    };
                    break;
                case "C":
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 4,
                        etapaencargo = "C",
                        descripcionEtapaEncargo = "Cerrado"
                    }; 
                    break;
                case "E":
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 5,
                        etapaencargo = "E",
                        descripcionEtapaEncargo = "Ejecutado"
                    };
                    break;
                case "A":
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 6,
                        etapaencargo = "A",
                        descripcionEtapaEncargo = "Aprobado"
                    };
                    break;
                case "T":
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 7,
                        etapaencargo = "T",
                        descripcionEtapaEncargo = "Terminado"
                    };
                    break;
                default:
                    respuesta = new EtapaEncargoModelo
                    {
                        idEtapaEncargo = 10,
                        etapaencargo = "Z",
                        descripcionEtapaEncargo = "Error en registro"
                    };
                    break;
            }
            return respuesta;
        }

        public static string descripcionEtapa(string etapaencargo)
        {
            string descripcionEtapaEncargo = null;
            switch (etapaencargo.ToUpper())
            {
                case "I":
                    descripcionEtapaEncargo = "Inicial";
                    break;
                case "P":
                    descripcionEtapaEncargo = "En proceso";
                    break;
                case "R":
                    descripcionEtapaEncargo = "Revisado";
                    break;
                case "C":
                    descripcionEtapaEncargo = "Cerrado";
                    break;
                case "E":
                    descripcionEtapaEncargo = "Ejecutado";
                    break;
                case "A":
                    descripcionEtapaEncargo = "Aprobado";
                    break;
                case "T":
                    descripcionEtapaEncargo = "Terminado";
                    break;
                default:
                    descripcionEtapaEncargo = "Error en registro";
                    break;
            }
            return descripcionEtapaEncargo;
        }

        public static string seleccionEtapaIniciales(int idEtapa)
        {
            string descripcionEtapaEncargo = "X";
            switch (idEtapa)
            {
                case 1:
                    descripcionEtapaEncargo = "I";
                    break;
                case 2:
                    descripcionEtapaEncargo = "P";
                    break;
                case 3:
                    descripcionEtapaEncargo = "R";
                    break;
                case 4:
                    descripcionEtapaEncargo = "C";
                    break;
                case 5:
                    descripcionEtapaEncargo = "E";
                    break;
                case 6:
                    descripcionEtapaEncargo = "A";
                    break;
                case 7:
                    descripcionEtapaEncargo = "T";
                    break;
                case 8:
                    descripcionEtapaEncargo = "B";
                    break;
                default:
                    descripcionEtapaEncargo = "X";
                    break;
            }
            return descripcionEtapaEncargo;
        }
        public static string seleccionEtapa(int idEtapa)
        {
            string descripcionEtapaEncargo = "nada";
            switch (idEtapa)
            {
                case 1:
                    descripcionEtapaEncargo = "Inicial";
                    break;
                case 2:
                    descripcionEtapaEncargo = "En proceso";
                    break;
                case 3:
                    descripcionEtapaEncargo = "Revisado";
                    break;
                case 4:
                    descripcionEtapaEncargo = "Cerrado";
                    break;
                case 5:
                    descripcionEtapaEncargo = "Ejecutado";
                    break;
                case 6:
                        descripcionEtapaEncargo = "Aprobado";
                    break;
                case 7:
                        descripcionEtapaEncargo = "Terminado";
                    break;
                case 8:
                        descripcionEtapaEncargo = "Borrado";
                    break;
                default:
                    descripcionEtapaEncargo = "Error en registro";
                    break;
            }
            return descripcionEtapaEncargo;
        }
        #endregion
    }
}
