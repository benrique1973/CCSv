using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice
{
    /// <summary>
    /// Lógica de interacción para DetalleIndiceCrudView.xaml
    /// </summary>
    public partial class DetalleIndiceCrudView : MetroWindow
    {
        public DetalleIndiceCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }
        //http://www.codeproject.com/Articles/579878/MoonPdfPanel-A-WPF-based-PDF-viewer-control

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                DetalleIndiceControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed)
                DetalleIndiceControllerViewModel.Errors -= 1;
        }
    }
}
