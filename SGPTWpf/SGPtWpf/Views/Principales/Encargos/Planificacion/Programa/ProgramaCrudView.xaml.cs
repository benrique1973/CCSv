using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.ViewModel.Planificacion.Programas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion
{
    /// <summary>
    /// Lógica de interacción para ProgramaCrudView.xaml
    /// </summary>
    public partial class ProgramaCrudView : MetroWindow
    {
        #region tokenProgramaRecepcion

        private string _tokenProgramaRecepcion;
        private string tokenProgramaRecepcion
        {
            get { return _tokenProgramaRecepcion; }
            set { _tokenProgramaRecepcion = value; }
        }

        #endregion
        public ProgramaCrudView()
        {
            InitializeComponent();

            _tokenProgramaRecepcion = "EncargosPlanificacionProgramaDatosVista";

            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            Messenger.Default.Register<NavegacionSgpt>(this, tokenProgramaRecepcion, (action) => ShowNavegacionEncargoPrograma(action));

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

    //private DataRowView rowBeingEdited = null;
    private void Validation_Error(object sender, ValidationErrorEventArgs e)
    {
        if (e.Action == ValidationErrorEventAction.Added) ProgramaControllerViewModel.Errors += 1;
        if (e.Action == ValidationErrorEventAction.Removed) ProgramaControllerViewModel.Errors -= 1;
    }

    private void ShowNavegacionEncargoPrograma(NavegacionSgpt datosDetalle)
        {
            datosDetalle.View.DataContext = datosDetalle.Contexto;
            cuerpoFrame.Content = datosDetalle.View;
        }
    }
}
