using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SGPTWpf.Views.Catalogos.Generico.TipoElementoIndice
{
    /// <summary>
    /// Lógica de interacción para TipoElementoIndiceCrearView.xaml
    /// </summary>
    public partial class TipoElementoIndiceCrearView : MetroWindow
    {
        #region tokenEnvioController

        private string _tokenEnvioController;
        private string tokenEnvioController
        {
            get { return _tokenEnvioController; }
            set { _tokenEnvioController = value; }
        }

        #endregion

        public TipoElementoIndiceCrearView()
        {
            InitializeComponent();
            _tokenEnvioController = "datosTipoElementoVista";
        }
        //Fuente: http://blogs.msmvps.com/otelis/2012/05/24/conversi-243-n-de-valores-con-enlace-a-datos/
        private void btnFoto_Click(object sender, RoutedEventArgs e)
        {
            if (imgFoto.Source == null)
            {
                OpenFileDialog openFile = new OpenFileDialog();
                BitmapImage b = new BitmapImage();
                openFile.Title = "Seleccione la Imagen a Mostrar";
                openFile.Filter = "Imágenes | *.jpg; *.gif; *.png; *.bmp";
                openFile.Multiselect = false;
                if (openFile.ShowDialog() == true)
                {
                    if (new FileInfo(openFile.FileName).Length > 131072)
                    {
                        enviarMensajeError();
                        return;
                    }

                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    b.EndInit();
                    imgFoto.Stretch = Stretch.Fill;
                    imgFoto.Source = b;
                    btnBuscar.Content = "Quitar imagen";
                }
            }
            else
            {
                imgFoto.Source = null;
                btnBuscar.Content = "Agregar imagen";
            }
        }
        public void enviarMensajeError()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send<bool>(true, tokenEnvioController);

        }

    }
}
