using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Repositorio
{
    /// <summary>
    /// Lógica de interacción para PDFView.xaml
    /// </summary>
    public partial class PDFView : MetroWindow
    {
        #region token

        private string _token;
        private string token
        {
            get { return _token; }
            set { _token = value; }
        }
        #endregion
        public PDFView()
        {
            InitializeComponent();
            //Tamaño oficio
             token = "contenidoDocumento";
            Messenger.Default.Register<NavegacionSgpt>(this, token, (action) => ShowContenidoControl(action));
            this.Width = (8 * 96);//816
            this.Height = (11.5 * 96);//1056
            this.MinWidth = PrincipalAlterna.anchoPagina * 0.5;
            this.Width = PrincipalAlterna.anchoPagina;
            this.MaxWidth = PrincipalAlterna.anchoPagina;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinHeight = PrincipalAlterna.largoPaginaBond * 0.5;
            this.MaxHeight = PrincipalAlterna.largoPaginaBond - 47;
            this.Height = PrincipalAlterna.largoPaginaBond - 47;
            //consultaDatos.MaxWidth = MaxWidth - 2 * 96;
            //consultaDatos.MaxHeight = MaxHeight - 96;
            //Suscribiendo mensaje con el binario

            gtiDatosNorma.MaxWidth = 620;
            gtiDatosNorma.MinWidth = 620 * 0.5;
            gtiDatosNorma.MinHeight = 850*0.50;
            gtiDatosNorma.MaxHeight = 850;

            EditFrameNorma.MaxWidth = 620;
            EditFrameNorma.MinWidth = 620 * 0.5;
            EditFrameNorma.MinHeight = 850 * 0.50;
            EditFrameNorma.MaxHeight = 850;

        }
        private void ShowContenidoControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            EditFrameNorma.Content = nm.View;
        }


    }
}

