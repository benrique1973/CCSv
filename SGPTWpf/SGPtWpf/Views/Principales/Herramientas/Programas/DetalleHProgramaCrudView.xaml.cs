using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Programas;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Programas
{
    /// <summary>
    /// Lógica de interacción para DetalleHProgramaCrudView.xaml
    /// </summary>
    public partial class DetalleHProgramaCrudView : MetroWindow
    {
        public DetalleHProgramaCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }
        //http://www.codeproject.com/Articles/579878/MoonPdfPanel-A-WPF-based-PDF-viewer-control

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                DetalleHerramientaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed)
                DetalleHerramientaControllerViewModel.Errors -= 1;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
