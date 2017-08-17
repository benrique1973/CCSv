using SGPTWpf.Support;
using System.Collections.ObjectModel;
using System.Linq;

namespace SGPTWpf.Model.Modelo.programas
{
    public class TablasPTModelo : UIBase
    {
        public int idTpt//correlativo que servirá como id
        {
            get { return GetValue(() => idTpt); }
            set { SetValue(() => idTpt, value); }
        }

        public string codIdTpt //Código de id de la tabla de origen
        {
            get { return GetValue(() => codIdTpt); }
            set { SetValue(() => codIdTpt, value); }
        }
        public string tablaTpt //Tabla de la que proviene los datos
        {
            get { return GetValue(() => tablaTpt); }
            set { SetValue(() => tablaTpt, value); }
        }
        public string vistaTpt //vista de la que proviene los datos
        {
            get { return GetValue(() => vistaTpt); }
            set { SetValue(() => vistaTpt, value); }
        }
        public string controladorTpt //controlador de la que proviene los datos
        {
            get { return GetValue(() => controladorTpt); }
            set { SetValue(() => controladorTpt, value); }
        }

        public string nombreMostrarTpt //Nombre a presentar al usuario
        {
            get { return GetValue(() => nombreMostrarTpt); }
            set { SetValue(() => nombreMostrarTpt, value); }
        }
        public string complementoTpt //Complemento para  diferenciar
        {
            get { return GetValue(() => complementoTpt); }
            set { SetValue(() => complementoTpt, value); }
        }
        #region Public Model Methods

        public static ObservableCollection<TablasPTModelo> GetAll()
        {
            var lista = new ObservableCollection<TablasPTModelo>
            {
               new TablasPTModelo {
                                           idTpt =0,
                                           codIdTpt="Ninguno",//Código de id de la tabla de origen
                                           tablaTpt="Ninguna", //Tabla de la que proviene los datos
                                           vistaTpt="Ninguna", //vista de la que proviene los datos
                                           controladorTpt="Ninguno", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Ninguno",
                                           complementoTpt=string.Empty,
                                   },
               new TablasPTModelo {
                                           idTpt =1,
                                           codIdTpt="idmr",//Matriz de riesgo
                                           tablaTpt="MATRIZRIESGOS", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Análisis de riesgos",
                                           complementoTpt=string.Empty,
                                      },
               new TablasPTModelo {
                                           idTpt =2,
                                           codIdTpt="idpapeles",//Matriz de riesgo
                                           tablaTpt="PAPELES", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Papeles",
                                           complementoTpt=string.Empty,
                                      },
                new TablasPTModelo {
                                           idTpt =3,
                                           codIdTpt="idmaf",//Matriz de riesgo
                                           tablaTpt="MATRIZANALISISFINANCIERO", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Análisis de riesgo",
                                           complementoTpt=string.Empty,
                                      },
               new TablasPTModelo {
                                           idTpt =4,
                                           codIdTpt="idprograma",//Matriz de riesgo
                                           tablaTpt="PROGRAMAS", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Programas y cuestionarios",
                                           complementoTpt=string.Empty,
                                      },
               new TablasPTModelo {
                                           idTpt =5,
                                           codIdTpt="idrepositorio",//Repositorio  de papeles
                                           tablaTpt="REPOSITORIO", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Documentos en pdf",
                                           complementoTpt=string.Empty,
                                      },
               new TablasPTModelo {
                                           idTpt =6,
                                           codIdTpt="idcedula",//Repositorio  de papeles
                                           tablaTpt="CEDULAS", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Cedulas",
                                           complementoTpt=string.Empty,
                                      },
               new TablasPTModelo {
                                           idTpt =7,
                                           codIdTpt="idtc",//Repositorio  de papeles
                                           tablaTpt="TIPOCARPETA", //Tabla de la que proviene los datos
                                           vistaTpt="Pendiente", //vista de la que proviene los datos
                                           controladorTpt="Pendiente", //controlador de la que proviene los datos
                                           nombreMostrarTpt="Carpetas",
                                           complementoTpt=string.Empty,
                                      },
            };
            ObservableCollection<TablasPTModelo> respuesta = new ObservableCollection<TablasPTModelo>(lista.OrderBy(x => x.idTpt));
            return respuesta;
        }


        #endregion

        #region Filtro
        public static TablasPTModelo seleccionTabla(string idTpt)
        {
            TablasPTModelo respuesta = null;
            switch (idTpt.ToString())
            {
                case "0":
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 0,
                        codIdTpt = "Ninguno",//Código de id de la tabla de origen
                        tablaTpt = "Ninguna", //Tabla de la que proviene los datos
                        vistaTpt = "Ninguna", //vista de la que proviene los datos
                        controladorTpt = "Ninguno", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Ninguno",
                        complementoTpt = string.Empty,
                    };
                    break;
                case "1":
                    respuesta = respuesta = new TablasPTModelo
                    {
                        idTpt = 1,
                        codIdTpt = "idmr",//Matriz de riesgo
                        tablaTpt = "MATRIZRIESGOS", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Análisis de riesgos",
                        complementoTpt = string.Empty,
                    };
                    break;
                case "2":
                    respuesta = respuesta = new TablasPTModelo
                    {
                        idTpt = 2,
                        codIdTpt = "idpapeles",//Matriz de riesgo
                        tablaTpt = "PAPELES", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Papeles",
                        complementoTpt = string.Empty,
                    };
                    break;
                case "3":
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 3,
                        codIdTpt = "idmaf",//Matriz de riesgo
                        tablaTpt = "MATRIZANALISISFINANCIERO", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Análisis de riesgo",
                        complementoTpt = string.Empty,
                    };
                    break;
                case "4":
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 4,
                        codIdTpt = "idprograma",//Matriz de riesgo
                        tablaTpt = "PROGRAMAS", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Programas y cuestionarios",
                        complementoTpt = string.Empty,
                    };
                    break;
                case "5":
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 5,
                        codIdTpt = "idrepositorio",//Matriz de riesgo
                        tablaTpt = "REPOSITORIO", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Documentos en pdf",
                        complementoTpt = string.Empty,
                    };
                    break;
                case "6":
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 6,
                        codIdTpt = "idrepositorio",//Matriz de riesgo
                        tablaTpt = "REPOSITORIO", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Documentos en pdf",
                        complementoTpt = string.Empty,
                    };
                    break;
                default:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 0,
                        codIdTpt = "Ninguno",//Código de id de la tabla de origen
                        tablaTpt = "Ninguna", //Tabla de la que proviene los datos
                        vistaTpt = "Ninguna", //vista de la que proviene los datos
                        controladorTpt = "Ninguno", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Ninguno",
                        complementoTpt = string.Empty,
                    };
                    break;
            }
            return respuesta;
        }
        public static TablasPTModelo seleccionTabla(int idTpt)
        {
            TablasPTModelo respuesta = null;
            switch (idTpt)
            {
                case  0:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 0,
                        codIdTpt = "Ninguno",//Código de id de la tabla de origen
                        tablaTpt = "Ninguna", //Tabla de la que proviene los datos
                        vistaTpt = "Ninguna", //vista de la que proviene los datos
                        controladorTpt = "Ninguno", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Ninguno",
                        complementoTpt = string.Empty,
                    };
                    break;
                case  1:
                    respuesta = respuesta = new TablasPTModelo
                    {
                        idTpt = 1,
                        codIdTpt = "idmr",//Matriz de riesgo
                        tablaTpt = "MATRIZRIESGOS", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Análisis de riesgos",
                        complementoTpt = string.Empty,
                    };
                    break;
                case  2:
                    respuesta = respuesta = new TablasPTModelo
                    {
                        idTpt = 2,
                        codIdTpt = "idpapeles",//Matriz de riesgo
                        tablaTpt = "PAPELES", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Papeles",
                        complementoTpt = string.Empty,
                    };
                    break;
                case  3:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 3,
                        codIdTpt = "idmaf",//Matriz de riesgo
                        tablaTpt = "MATRIZANALISISFINANCIERO", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Análisis financiero",
                        complementoTpt = string.Empty,
                    };
                    break;
                case  4:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 4,
                        codIdTpt = "idprograma",//Matriz de riesgo
                        tablaTpt = "PROGRAMAS", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Programas y cuestionarios",
                        complementoTpt = string.Empty,
                    };
                    break;
                case 5:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 5,
                        codIdTpt = "idrepositorio",//Matriz de riesgo
                        tablaTpt = "REPOSITORIO", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Documentos en pdf",
                        complementoTpt = string.Empty,
                    };
                    break;
                case 6:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 6,
                        codIdTpt = "idcedula",//Repositorio  de papeles
                        tablaTpt = "CEDULAS", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Cedulas",
                        complementoTpt = string.Empty,
                    };
                    break;
                case 7:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 7,
                        codIdTpt = "idtc",//Repositorio  de papeles
                        tablaTpt = "TIPOCARPETA", //Tabla de la que proviene los datos
                        vistaTpt = "Pendiente", //vista de la que proviene los datos
                        controladorTpt = "Pendiente", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Carpetas",
                        complementoTpt = string.Empty,
                    };
                    break;
                default:
                    respuesta = new TablasPTModelo
                    {
                        idTpt = 0,
                        codIdTpt = "Ninguno",//Código de id de la tabla de origen
                        tablaTpt = "Ninguna", //Tabla de la que proviene los datos
                        vistaTpt = "Ninguna", //vista de la que proviene los datos
                        controladorTpt = "Ninguno", //controlador de la que proviene los datos
                        nombreMostrarTpt = "Ninguno",
                        complementoTpt = string.Empty,
                    };
                    break;
            }
            return respuesta;
        }

        #endregion
    }
}
