using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Programas;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Programa
{
    /// <summary>
    /// Lógica de interacción para DetalleProgramaCrudView.xaml
    /// </summary>
    public partial class DetalleProgramaCrudView : MetroWindow
    {
        public DetalleProgramaCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }
        //http://www.codeproject.com/Articles/579878/MoonPdfPanel-A-WPF-based-PDF-viewer-control

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                DetalleProgramaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed)
                DetalleProgramaControllerViewModel.Errors -= 1;
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
