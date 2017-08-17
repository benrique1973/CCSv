using MahApps.Metro.Controls;
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
    /// <summary>
    /// Lógica de interacción para TipoElementoIndiceConsultarView.xaml
    /// </summary>
    public partial class TipoElementoIndiceConsultarView : MetroWindow
    {
        public TipoElementoIndiceConsultarView()
        {
            InitializeComponent();
        }
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
                        MessageBox.Show(
                    "El tamaño máximo permitido de la imagen es de 128 KB",
                            "Mensaje de Sistema",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning,
                        MessageBoxResult.OK);
                        return;
                    }

                    b.BeginInit();
                    b.UriSource = new Uri(openFile.FileName);
                    b.EndInit();
                    imgFoto.Stretch = Stretch.Fill;
                    imgFoto.Source = b;
                    btnBuscar.Content = "Quitar Foto";
                }
            }
            else
            {
                imgFoto.Source = null;
                btnBuscar.Content = "Agregar Foto";
            }
        }
    }
}
