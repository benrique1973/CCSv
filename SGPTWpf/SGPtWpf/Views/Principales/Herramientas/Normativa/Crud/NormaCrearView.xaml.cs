using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using SGPTWpf.ViewModel.Herramientas.Normativa;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas.Normativa.Crud
{
    public partial class NormaCrearView : MetroWindow
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

        #region tokenNormaViewEnvio

        private string _tokenNormaViewEnvio;
        private string tokenNormaViewEnvio
        {
            get { return _tokenNormaViewEnvio; }
            set { _tokenNormaViewEnvio = value; }
        }

        #endregion

        public NormaCrearView()
        {
            InitializeComponent();
            _tokenEnvioController = "datosNormaCrearVista";
            _tokenNormaViewEnvio = "NormalLegalCaptura";
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }
        //http://www.codeproject.com/Articles/579878/MoonPdfPanel-A-WPF-based-PDF-viewer-control
        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            // Stream para cargar la imagen
            // dialogo para cargar la imagen
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Seleccione el PDF a cargar";
            openDialog.Filter = "PDF File (*.pdf)|*.pdf";
            openDialog.Multiselect = false;
            // Abrir el cuadro de dialogo para cargar una imagen de un archivo
            if (openDialog.ShowDialog() == true)
            {
                if (new FileInfo(openDialog.FileName).Length > tamanoArchivo)
                {
                    //MessageBox.Show(
                    //"El tamaño máximo permitido de la imagen es de 2 Megabytes",
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
                Messenger.Default.Send(openDialog.FileName, tokenNormaViewEnvio);
                btnBuscar.Content = "Quitar";
                }
            }
            else
            {
                btnBuscar.Content = "Agregar pdf";
                txtRuta.Text = "";
            }
        }
        public void enviarMensajeError()
        {
            //Creando el mensaje de cierre
            Messenger.Default.Send<bool>(true, tokenEnvioController);

        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) NormaLegalControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) NormaLegalControllerViewModel.Errors -= 1;
        }
    }
}