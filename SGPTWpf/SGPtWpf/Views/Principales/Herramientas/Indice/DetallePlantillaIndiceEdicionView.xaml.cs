using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Indice;
using SGPTWpf.ViewModel.Herramientas.Programas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas.Indice
{
    /// <summary>
    /// Lógica de interacción para DetallePlantillaIndiceEdicionView.xaml
    /// </summary>
    public partial class DetallePlantillaIndiceEdicionView : MetroWindow
    {
        public DetallePlantillaIndiceEdicionView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }
        //http://www.codeproject.com/Articles/579878/MoonPdfPanel-A-WPF-based-PDF-viewer-control

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                DetallePlantillaIndiceControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed)
                DetallePlantillaIndiceControllerViewModel.Errors -= 1;
        }
    }
}
