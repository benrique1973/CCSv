using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using SGPTWpf.Messages.Genericos;
using SGPTWpf.Model.Modelo.Plantilla;
using System;
using System.IO;
using System.Windows;

namespace SGPTWpf.Views.Principales.Herramientas.Plantillas
{
    /// <summary>
    /// Lógica de interacción para PlantillaIndiceEdicionView.xaml
    /// </summary>
    public partial class PlantillaEdicionView : MetroWindow
    {
        private int tamanoArchivo = 2867200;
        
        #region tokenEnvioController

        private string _tokenEnvioController;
        private string tokenEnvioController
        {
            get { return _tokenEnvioController; }
            set { _tokenEnvioController = value; }
        }

        #endregion

        #region tokenByte

        private string _tokenByte;
        private string tokenByte
        {
            get { return _tokenByte; }
            set { _tokenByte = value; }
        }

        #endregion

        public PlantillaEdicionView()
        {
            InitializeComponent();
            _tokenByte = "PlantillaByte";
            _tokenEnvioController = "datosPlantillaEdicicionVista";
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            // Stream para cargar la imagen
            // dialogo para cargar la imagen
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Seleccione el archivo a cargar";
            openDialog.Filter = TipoArchivoModelo.seleccionTipoArchivo(comboSeleccion.Text);
            openDialog.Multiselect = false;
            // Abrir el cuadro de dialogo para cargar una imagen de un archivo
            if (openDialog.ShowDialog() == true)
            {
                if (new FileInfo(openDialog.FileName).Length > tamanoArchivo)
                {
                    //MessageBox.Show(
                    //"El tamaño es mayor al permitido de 2.80 megas",
                    //    "Mensaje de Sistema",
                    //MessageBoxButton.OK,
                    //MessageBoxImage.Warning,
                    //MessageBoxResult.OK);
                    enviarMensajeError();
                    return;
                }
                else
                {
                    txtRuta.Text = openDialog.FileName;
                    Messenger.Default.Send(openDialog.FileName, tokenByte);
                    btnBuscar.Content = "Quitar";
                }
            }
            else
            {
                btnBuscar.Content = "Cargar";
            }
        }





        /*        //http://www.codeproject.com/Articles/579878/MoonPdfPanel-A-WPF-based-PDF-viewer-control
                private void btnBuscar_Click(object sender, RoutedEventArgs e)
                {
                    // Stream para cargar la imagen
                        Stream stream;
                        // dialogo para cargar la imagen
                        OpenFileDialog openDialog = new OpenFileDialog();
                        openDialog.Title = "Seleccione el archivo a cargar";
                        openDialog.Filter = TipoArchivoModelo.seleccionTipoArchivo(comboSeleccion.Text);
                        openDialog.Multiselect = false;
                        // Abrir el cuadro de dialogo para cargar una imagen de un archivo
                        if (openDialog.ShowDialog() == true)
                        {
                            if (new FileInfo(openDialog.FileName).Length > tamanoArchivo)
                            {
                                MessageBox.Show(
                                "El tamaño es mayor al permitido de 2.80 megas",
                                    "Mensaje de Sistema",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning,
                                MessageBoxResult.OK);
                                return;
                            }
                            try
                            {
                                if ((stream = openDialog.OpenFile()) != null)
                                {
                                    using (stream)
                                    {
                                        byte[] imageData = new byte[stream.Length];
                                    //Leer la imagen en un array de bytes
                                    ///////////////////////////////////////////////////
                                    //https://www.codeproject.com/Questions/477577/howplustoplusconvertplusaplus-doc-f-docx-f-pdf
                                    Byte[] ByteArray = File.ReadAllBytes(openDialog.FileName);//Para comparar y probar
                                    //////////////////////////////////////////////////

                                    //imageData = ReadFully(stream,0 );//probar para archivos grandes
                                    stream.Read(imageData, 0, (int)stream.Length);
                                    //Se crea el mensaje
                                        ArchivoBinario elemento = new ArchivoBinario();
                                        elemento.archivoBinario = imageData;
                                        elemento.nombre = openDialog.FileName.Substring(openDialog.FileName.LastIndexOf("\\") + 1);
                                        Messenger.Default.Send(elemento, tokenByte);
                                        stream.Close();//Evaluar
                                        btnBuscar.Content = "Quitar";
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: No se puede subir el archivo " + ex.Message);
                            }
                        }
                        else
                        {
                            btnBuscar.Content = "Cargar";
                        }
                }*/


        //http://www.yoda.arachsys.com/csharp/readbinary.html
        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        public byte[] ReadFully(Stream stream, int initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }
        //http://stackoverflow.com/questions/2030847/best-way-to-read-a-large-file-into-a-byte-array-in-c
        //Note the Integer.MaxValue - file size limitation placed by the Read method. In other words you can only read a 2GB chunk at once.
        public byte[] ReadAllBytes(string fileName)
        {
            byte[] buffer = null;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }
        public void enviarMensajeError()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send<bool>(true, tokenEnvioController);

        }

    }
}
