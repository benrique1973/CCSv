using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SGPTWpf.Model.Modelo.Plantilla
{
    public class TipoArchivoModelo : UIBase
    {
        public int idTipoArchivo //correlativo
        {
            get { return GetValue(() => idTipoArchivo); }
            set { SetValue(() => idTipoArchivo, value); }
        }
        public string nombreTipoArchivo
        {
            get { return GetValue(() => nombreTipoArchivo); }
            set { SetValue(() => nombreTipoArchivo, value); }
        }

        public string rutaTipoArchivo  //tipo de  plantilla del que depende
        {
            get { return GetValue(() => rutaTipoArchivo); }
            set { SetValue(() => rutaTipoArchivo, value); }
        }
        public string extension  //tipo de  plantilla del que depende
        {
            get { return GetValue(() => extension); }
            set { SetValue(() => extension, value); }
        }
        public byte[] imagenTipoArchivo
        {
            get { return GetValue(() => imagenTipoArchivo); }
            set { SetValue(() => imagenTipoArchivo, value); }
        }
        #region Public Model Methods

        public static List<TipoArchivoModelo> GetAll()
        {
            var lista = new ObservableCollection<TipoArchivoModelo>
        {
               new TipoArchivoModelo {
                                        idTipoArchivo=1,
                                        nombreTipoArchivo="Word",
                                        extension="docx",
                                        rutaTipoArchivo=""
                                      },
               new TipoArchivoModelo {
                                        idTipoArchivo=2,
                                        nombreTipoArchivo="Excell",
                                        extension="xlsx",
                                        rutaTipoArchivo=""
                                      },
               //new TipoArchivoModelo {
               //                         idTipoArchivo=3,
               //                         nombreTipoArchivo="texto plano",
               //                         extension="txt",
               //                         rutaTipoArchivo=""
               //                       },
               new TipoArchivoModelo {
                                        idTipoArchivo=4,
                                        nombreTipoArchivo="Power point",
                                        extension="pptx",
                                        rutaTipoArchivo=""
                                      },
               //new TipoArchivoModelo {
               //                         idTipoArchivo=5,
               //                         nombreTipoArchivo="Texto enriquecido",
               //                         extension="rtf",
               //                         rutaTipoArchivo=""
               //                       },
               new TipoArchivoModelo {
                                        idTipoArchivo=6,
                                        nombreTipoArchivo="PDF",
                                        extension="pdf",
                                        rutaTipoArchivo=""
                                      },
               new TipoArchivoModelo {
                                        idTipoArchivo=7,
                                        nombreTipoArchivo="Cualquiera",
                                        extension="*",
                                        rutaTipoArchivo=""
                                      }
            };
            return lista.OrderBy(x => x.nombreTipoArchivo).ToList();
        }


        #endregion

        #region Filtro
        public static string seleccionTipoArchivo(string Seleccion)
        {
            string respuesta = "Error";
            switch (Seleccion.ToUpper())
            {
                case "WORD":
                    respuesta = "Word Documents|*.doc;*.docx";
                    break;
                case "EXCELL":
                    respuesta = "Excel Worksheets|*.xls;*.xlsx";
                    break;
                case "POWER POINT":
                    respuesta = "PowerPoint Presentations| *.ppt; *.pptx";
                    break;
                case "TEXTO PLANO":
                    respuesta = "Texto plano| *.txt";
                    break;
                case "TEXTO ENRIQUECIDO":
                    respuesta = "Texto enriquecido| *.rtf";
                    break;
                case "PDF":
                    respuesta = "PDF| *.pdf";
                    break;
                default:
                    respuesta = "Todos | *.*";
                    break;
            }
            return respuesta;
        }

        public static TipoArchivoModelo selecciontipoarchivoplantilla(string tipoarchivoplantilla)
        {
            TipoArchivoModelo respuesta = null;
            switch (tipoarchivoplantilla.ToUpper())
            {
                case "DOCX":
                    respuesta = 
                    new TipoArchivoModelo
                    {
                        idTipoArchivo = 1,
                        nombreTipoArchivo = "Word",
                        extension = "docx",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "XLS":
                    respuesta = 
                    new TipoArchivoModelo
                    {
                        idTipoArchivo = 2,
                        nombreTipoArchivo = "Excell",
                        extension = "xlsx",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "PPTX":
                    respuesta = 
                 new TipoArchivoModelo
                    {
                        idTipoArchivo = 4,
                        nombreTipoArchivo = "Power point",
                        extension = "pptx",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "DOC":
                    respuesta=new TipoArchivoModelo
                    {
                        idTipoArchivo = 1,
                        nombreTipoArchivo = "Word",
                        extension = "docx",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "XLSX":
                    respuesta =
                    new TipoArchivoModelo
                    {
                        idTipoArchivo = 2,
                        nombreTipoArchivo = "Excell",
                        extension = "xlsx",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "PPT":
                    respuesta =
                 new TipoArchivoModelo
                 {
                     idTipoArchivo = 4,
                     nombreTipoArchivo = "Power point",
                     extension = "pptx",
                     rutaTipoArchivo = ""
                 };
                    break;
                case "TEXTO PLANO":
                    respuesta = 
                    new TipoArchivoModelo
                    {
                        idTipoArchivo = 3,
                        nombreTipoArchivo = "texto plano",
                        extension = "txt",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "RTF":
                    respuesta = 
                    new TipoArchivoModelo
                    {
                        idTipoArchivo = 5,
                        nombreTipoArchivo = "Texto enriquecido",
                        extension = "rtf",
                        rutaTipoArchivo = ""
                    };
                    break;
                case "PDF":
                    respuesta =
                    new TipoArchivoModelo
                    {
                        idTipoArchivo = 6,
                        nombreTipoArchivo = "PDF",
                        extension = "pdf",
                        rutaTipoArchivo = ""
                    };
                    break;
                default:
                    respuesta = new TipoArchivoModelo
                    {
                        idTipoArchivo = 7,
                        nombreTipoArchivo = "Cualquiera",
                        extension = "*",
                        rutaTipoArchivo = ""
                    };
                    break;
            }
            return respuesta;
        }

        #endregion
    }
}
