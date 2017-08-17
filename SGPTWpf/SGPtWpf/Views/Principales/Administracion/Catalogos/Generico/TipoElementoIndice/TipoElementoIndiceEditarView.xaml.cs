using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGPTWpf.Views.Catalogos.Generico.TipoElementoIndice
{


    public partial class TipoElementoIndiceEditarView :  MetroWindow
    {
        #region tokenEnvioController

        private string _tokenEnvioController;
        private string tokenEnvioController
        {
            get { return _tokenEnvioController; }
            set { _tokenEnvioController = value; }
        }

        #endregion
        public TipoElementoIndiceEditarView()
        {
            InitializeComponent();
            _tokenEnvioController = "datosTipoElementoVista";
        }
        private void btnFoto_Click(object sender, RoutedEventArgs e)
        {
            if (!(imgFoto.Source == null))
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
                btnBuscar.Content = "Modificar imagen";
            }
        }
        public void enviarMensajeError()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send<bool>(true, tokenEnvioController);

        }
    }
}
