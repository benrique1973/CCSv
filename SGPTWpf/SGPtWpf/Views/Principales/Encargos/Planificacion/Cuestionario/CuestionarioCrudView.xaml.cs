using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Cuestionario
{
    /// <summary>
    /// Lógica de interacción para CuestionarioCrudView.xaml
    /// </summary>
    public partial class CuestionarioCrudView : MetroWindow
    {
        #region tokenCuestionarioRecepcion

        private string _tokenCuestionarioRecepcion;
        private string tokenCuestionarioRecepcion
        {
            get { return _tokenCuestionarioRecepcion; }
            set { _tokenCuestionarioRecepcion = value; }
        }

        #endregion

        public static double largoFrame = 0;
        public static double anchoFrame = 0;
        public CuestionarioCrudView()
        {
            InitializeComponent();

            _tokenCuestionarioRecepcion = "EncargosPlanificacionCuestionarioDatosVista"; 

            Messenger.Default.Register<NavegacionSgpt>(this, tokenCuestionarioRecepcion, (action) => ShowNavegacionEncargoPrograma(action));

            //Tamaño de pantalla
            double ancho = PrincipalAlterna.ancho;
            double largo = PrincipalAlterna.largo;

            this.Width = ancho - 205;
            this.Height = PrincipalAlterna.largoFrame - 42;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            //Configuracion de elementos

            txtNombreHerramienta.Width = ancho * 0.33;
            txtNombreHerramienta.MinWidth = ancho * 0.30;
            txtNombreHerramienta.MaxWidth = ancho * 0.33;

            cuerpoFrame.Width = ancho-1;
            cuerpoFrame.MinWidth = ancho * 0.30;
            cuerpoFrame.MaxWidth = ancho-1;

            cuerpoFrame.Height = largo -100;
            cuerpoFrame.MinHeight = largo * 0.30;
            cuerpoFrame.MaxHeight = largo -100;

            anchoFrame = cuerpoFrame.Width;
            largoFrame = cuerpoFrame.Height;

            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) CuestionarioControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) CuestionarioControllerViewModel.Errors -= 1;
        }

        private void ShowNavegacionEncargoPrograma(NavegacionSgpt datosDetalle)
        {
            datosDetalle.View.DataContext = datosDetalle.Contexto;
            cuerpoFrame.Content = datosDetalle.View;
        }
    }
}
