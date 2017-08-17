using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Indices;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Indice
{
    public partial class IndiceCrudView : MetroWindow
    {
        public IndiceCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) IndiceControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) IndiceControllerViewModel.Errors -= 1;
        }
    }
}