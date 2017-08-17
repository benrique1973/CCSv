using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.HerramientasProgramas;
using SGPTWpf.ViewModel.Herramientas.Programas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas.Tools
{
    /// <summary>
    /// Lógica de interacción para HerramientasProgramaCrudView.xaml
    /// </summary>
    public partial class HerramientasProgramaCrudView : MetroWindow
    {
        #region tokenHerramientaRecepcion

        private string _tokenHerramientaRecepcion;
        private string tokenHerramientaRecepcion
        {
            get { return _tokenHerramientaRecepcion; }
            set { _tokenHerramientaRecepcion = value; }
        }

        #endregion
        public HerramientasProgramaCrudView()
        {
            InitializeComponent();

            _tokenHerramientaRecepcion = "HerramientasVistaDatos";

            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            Messenger.Default.Register<NavegacionSgpt>(this, tokenHerramientaRecepcion,(action) => ShowNavegacionHerramientaPrograma(action));

            //Configuracion de elementos

            txtNombreHerramienta.Width = ancho * 0.33;
            txtNombreHerramienta.MinWidth = ancho * 0.30;
            txtNombreHerramienta.MaxWidth = ancho * 0.33;

            cuerpoFrame.Width = ancho ;
            cuerpoFrame.MinWidth = ancho * 0.30;
            cuerpoFrame.MaxWidth = ancho;

            cuerpoFrame.Height = largo*0.792;
            cuerpoFrame.MinHeight = largo * 0.30;
            cuerpoFrame.MaxHeight = largo*0.792 ;
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) HerramientasControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) HerramientasControllerViewModel.Errors -= 1;
        }

        private void ShowNavegacionHerramientaPrograma(NavegacionSgpt datosDetalle)
        {
            datosDetalle.View.DataContext = datosDetalle.Contexto;
            cuerpoFrame.Content = datosDetalle.View;
        }
    }
}
