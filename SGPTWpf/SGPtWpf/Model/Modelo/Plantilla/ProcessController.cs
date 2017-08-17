using System;
using System.IO;
using System.Diagnostics;
////https://geeks.ms/lfranco/2011/08/19/editar-documentos-almacenados-como-array-de-bits-en-sql-server-filestream-3n/
namespace SGPTWpf.Model.Modelo.Plantilla
{
    namespace SGPTWpf.Model.Modelo.Plantilla
    {
        public class ProcessController : Process
        {
            DateTime originalLastWriteTime;
            Byte[] document = null;

            string tempfileName = string.Empty;
            public string TempFileName
            {
                get
                {
                    return tempfileName;
                }
            }

            Guid fileId;
            public Guid FileId
            {
                get
                {
                    return fileId;
                }
            }

            public int idPlantilla { get; set; }//Identificador del Id del  archivo abierto


            public ProcessController(Byte[] documentBytes, Guid docId, string originalfilename, string ruta,int idPlantilla)
                : base()
            {
                //tempfileName = Path.GetTempFileName().Replace("tmp", getExtension(originalfilename));
                tempfileName = ruta;
                document = documentBytes;
                fileId = docId;
                this.StartInfo.FileName = tempfileName;
                this.idPlantilla = idPlantilla;
            }

            public void EditInAssociatedApplication()
            {
                if (tempfileName == null) return;
                if (File.Exists(tempfileName)) File.Delete(tempfileName);
                File.WriteAllBytes(tempfileName, document);
                originalLastWriteTime = File.GetLastWriteTime(tempfileName);
                this.EnableRaisingEvents = true;
                this.Start();
            }

            public bool HasChanged()
            {
                if (tempfileName == null) return false;
                var modifiedtime = File.GetLastWriteTime(tempfileName);
                return (modifiedtime != originalLastWriteTime);
            }

            private string getExtension(string filename)
            {
                var parts = filename.Split('.');
                if (parts.Length > 0)
                    return parts[parts.Length - 1];
                else
                    return string.Empty;
            }
        }
    }
}