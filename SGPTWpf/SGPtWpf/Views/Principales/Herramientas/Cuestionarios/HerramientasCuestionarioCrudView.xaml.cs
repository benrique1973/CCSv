using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTWpf.Messages.Navegacion.HerramientasProgramas;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas.Cuestionarios
{
    /// <summary>
    /// Lógica de interacción para HerramientasCuestionarioCrudView.xaml
    /// </summary>
    public partial class HerramientasCuestionarioCrudView : MetroWindow
    {
        public HerramientasCuestionarioCrudView()
        {
            InitializeComponent();
            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            Messenger.Default.Register<NavegacionHerramientaCuestionario>(this, (action) => ShowNavegacionHerramientaCuestionario(action));

            //Configuracion de elementos

            txtNombreHerramienta.Width = ancho * 0.33;
            txtNombreHerramienta.MinWidth = ancho * 0.30;
            txtNombreHerramienta.MaxWidth = ancho * 0.33;

            cuerpoFrame.Width = ancho;
            cuerpoFrame.MinWidth = ancho * 0.30;
            cuerpoFrame.MaxWidth = ancho;

            cuerpoFrame.Height = largo * 0.792;
            cuerpoFrame.MinHeight = largo * 0.30;
            cuerpoFrame.MaxHeight = largo * 0.792;

            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }


        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) HerramientasCuestionarioControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) HerramientasCuestionarioControllerViewModel.Errors -= 1;
        }
        private void ShowNavegacionHerramientaCuestionario(NavegacionHerramientaCuestionario datos)
        {
            datos.View.DataContext = datos.Contexto;
            cuerpoFrame.Content = datos.View;
        }

    }
}
