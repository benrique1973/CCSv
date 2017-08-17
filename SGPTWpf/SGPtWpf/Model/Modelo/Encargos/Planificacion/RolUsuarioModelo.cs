
using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.Model.Modelo.programas
{
    public class RolUsuarioModelo : UIBase
    {
        public int idrolUsuario//correlativo
        {
            get { return GetValue(() => idrolUsuario); }
            set { SetValue(() => idrolUsuario, value); }
        }
        [MaxLength(1, ErrorMessage = "No  puede ser mayor a 1 caracter")]
        public string rolUsuario
        {
            get { return GetValue(() => rolUsuario); }
            set { SetValue(() => rolUsuario, value); }
        }
        public string nombreRolUsuario
        {
            get { return GetValue(() => nombreRolUsuario); }
            set { SetValue(() => nombreRolUsuario, value); }
        }

        #region Public Model Methods

        public static List<RolUsuarioModelo> GetAll()
        {
            var lista = new ObservableCollection<RolUsuarioModelo>
            {
               new RolUsuarioModelo {
                                        idrolUsuario=1,
                                        rolUsuario="C",
                                        nombreRolUsuario="Creador"//Usuario que crea el documento, proceso o archivo
                                      },
               new RolUsuarioModelo {
                                        idrolUsuario=2,
                                        rolUsuario="M",
                                        nombreRolUsuario="Modificado"//Usuario que modifica el registro
                                      },
               new RolUsuarioModelo {
                                        idrolUsuario=3,
                                        rolUsuario="S",
                                        nombreRolUsuario="Revisado"//Usuario que supervisa el contenido y lo aprueba
                                      },
                new RolUsuarioModelo {
                                        idrolUsuario=4,
                                        rolUsuario="A",
                                        nombreRolUsuario="Aprobado"//Usuario que autoriza el registro
                                      },
               new RolUsuarioModelo {
                                        idrolUsuario=5,
                                        rolUsuario="B",
                                        nombreRolUsuario="Borrado"//Usuario que borra el registro
                                      },
               new RolUsuarioModelo {
                                        idrolUsuario=6,
                                        rolUsuario="E",
                                        nombreRolUsuario="Ejecutado"//Usuario que ejecuta el procedimiento.
                                      },
               new RolUsuarioModelo {
                                        idrolUsuario=7,
                                        rolUsuario="R",
                                        nombreRolUsuario="Referenciación"//Usuario que ejecuta el procedimiento.
                                      }
            };
            return lista.OrderBy(x => x.idrolUsuario).ToList();
        }


        #endregion

        #region Filtro
        public static RolUsuarioModelo GetRegistro(string rolUsuario)
        {
            RolUsuarioModelo respuesta = null;
            switch (rolUsuario.ToUpper())
            {
                case "C":
                    respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 1,
                        rolUsuario = "C",
                        nombreRolUsuario = "Creador"
                    };
                    break;
                case "M":
                    respuesta = respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 2,
                        rolUsuario = "M",
                        nombreRolUsuario = "Modificado"
                    };
                    break;
                case "S":
                    respuesta = respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 3,
                        rolUsuario = "S",
                        nombreRolUsuario = "Revisado"
                    };
                    break;
                case "A":
                    respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 4,
                        rolUsuario = "A",
                        nombreRolUsuario = "Aprobado"
                    };
                    break;
                case "B":
                    respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 5,
                        rolUsuario = "B",
                        nombreRolUsuario = "Borrado"
                    };
                    break;
                case "E":
                    respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 6,
                        rolUsuario = "E",
                        nombreRolUsuario = "Ejecutado"//Usuario que ejecuta el procedimiento.
                    };
                    break;
                case "R":
                    respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 7,
                        rolUsuario = "R",
                        nombreRolUsuario = "Referenciación"//Usuario que ejecuta el procedimiento.
                    };
                    break;
                default:
                    respuesta = new RolUsuarioModelo
                    {
                        idrolUsuario = 6,
                        rolUsuario = "Z",
                        nombreRolUsuario = "Error en registro"
                    };
                    break;
            }
            return respuesta;
        }

        #endregion

        #region
        RolUsuarioModelo()
        {

        }
        RolUsuarioModelo(string rolUsuario)
        {
            switch (rolUsuario.ToUpper())
            {
                case "C":
                    idrolUsuario = 1;
                    rolUsuario = "C";
                    nombreRolUsuario = "Creador";
                    break;
                case "M":

                    idrolUsuario = 2;
                    rolUsuario = "M";
                    nombreRolUsuario = "Modificado";
                    break;
                case "R":
                        idrolUsuario = 3;
                        rolUsuario = "R";
                        nombreRolUsuario = "Revisado";
                    break;
                case "A":
                    idrolUsuario = 4;
                    rolUsuario = "A";
                    nombreRolUsuario = "Aprobado";
                    break;
                case "B":

                    idrolUsuario = 5;
                    rolUsuario = "B";
                    nombreRolUsuario = "Borrado";
                    break;
                case "E":
                    idrolUsuario = 6;
                    rolUsuario = "E";
                    nombreRolUsuario = "Ejecutado";//Usuario que ejecuta el procedimiento.

                    break;
                default:
                    idrolUsuario = 6;
                    rolUsuario = "Z";
                    nombreRolUsuario = "Error en registro";
                    break;
            }
        }

        RolUsuarioModelo(int codigoRolUsuario)
        {
            switch (codigoRolUsuario)
            {
                case 1:
                    idrolUsuario = 1;
                    rolUsuario = "C";
                    nombreRolUsuario = "Creador";
                    break;
                case 2:

                    idrolUsuario = 2;
                    rolUsuario = "M";
                    nombreRolUsuario = "Modificado";
                    break;
                case 3:
                        idrolUsuario = 3;
                        rolUsuario = "R";
                        nombreRolUsuario = "Revisado";
                    break;
                case 4:
                    idrolUsuario = 4;
                    rolUsuario = "A";
                    nombreRolUsuario = "Aprobado";
                    break;
                case 5:

                    idrolUsuario = 5;
                    rolUsuario = "B";
                    nombreRolUsuario = "Borrado";
                    break;
                case 6:
                    idrolUsuario = 6;
                    rolUsuario = "E";
                    nombreRolUsuario = "Ejecutado";//Usuario que ejecuta el procedimiento.

                    break;
                default:
                    idrolUsuario = 6;
                    rolUsuario = "Z";
                    nombreRolUsuario = "Error en registro";
                    break;
            }
        }
        #endregion
    }
}
