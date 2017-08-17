using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion
{
    public class MedicionRiesgo : UIBase
    {
        public int idMedicionRiesgo //correlativo
        {
            get { return GetValue(() => idMedicionRiesgo); }
            set { SetValue(() => idMedicionRiesgo, value); }
        }
        [MaxLength(1, ErrorMessage = "No  puede ser mayor a 1 caracter")]

        public string calificacionRiesgo
        {
            get { return GetValue(() => calificacionRiesgo); }
            set { SetValue(() => calificacionRiesgo, value); }
        }

        #region Public Model Methods

        public static ObservableCollection<MedicionRiesgo> GetAll()
        {
            var lista = new ObservableCollection<MedicionRiesgo>
            {
               new MedicionRiesgo {
                                        idMedicionRiesgo=1,
                                        calificacionRiesgo="Bajo"
                                      },
               new MedicionRiesgo {
                                        idMedicionRiesgo=2,
                                        calificacionRiesgo="Medio"
                                      },
               new MedicionRiesgo {
                                        idMedicionRiesgo=3,
                                        calificacionRiesgo="Alto"
                                      },
               new MedicionRiesgo {
                                        idMedicionRiesgo=4,
                                        calificacionRiesgo="Ninguno"
                                      },
            };
            return lista;
        }

        public static ObservableCollection<string> GetAllCalificacionRiesgo()
        {
            ObservableCollection<string> lista = new ObservableCollection<string>();
            lista.Add("Bajo");
            lista.Add("Medio");
            lista.Add("Alto");
            lista.Add("Ninguno");
            return lista;
        }
        #endregion

        #region Filtro
        public static MedicionRiesgo idRiesgo(int id)
        {
            MedicionRiesgo respuesta = null;
            switch (id)
            {
                case 1:
                    respuesta = new MedicionRiesgo
                    {
                        idMedicionRiesgo = 1,
                        calificacionRiesgo = "Bajo"
                    };
                    break;
                case 2:
                    respuesta = respuesta = new MedicionRiesgo
                    {
                        idMedicionRiesgo = 2,
                        calificacionRiesgo = "Medio"
                    };
                    break;
                case 3:
                    respuesta = new MedicionRiesgo
                    {
                        idMedicionRiesgo = 3,
                        calificacionRiesgo = "Alto"
                    };
                    break;
                default:
                    respuesta = new MedicionRiesgo
                    {
                        idMedicionRiesgo = 4,
                        calificacionRiesgo = "Ninguno"
                    };
                    break;
            }
            return respuesta;
        }

        #endregion
    }
}
