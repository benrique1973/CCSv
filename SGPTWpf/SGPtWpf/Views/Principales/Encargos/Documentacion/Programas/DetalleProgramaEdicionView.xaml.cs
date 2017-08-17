using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.Programa;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion.Programas
{
    /// <summary>
    /// Lógica de interacción para DetalleProgramaEdicionView.xaml
    /// </summary>
    public partial class DetalleProgramaEdicionView : MetroWindow
    {
        public DetalleProgramaEdicionView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);

        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) DetalleProgramaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) DetalleProgramaControllerViewModel.Errors -= 1;
        }
    }
}
