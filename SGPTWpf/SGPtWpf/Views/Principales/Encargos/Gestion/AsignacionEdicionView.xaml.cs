using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Encargos.Gestion;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Encargos.Gestion
{
    /// <summary>
    /// Lógica de interacción para AsignacionEdicionView.xaml
    /// </summary>
    public partial class AsignacionEdicionView : MetroWindow
    {
        public AsignacionEdicionView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);

        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) AsignacionControllerViewModel.Errors+= 1;
            if (e.Action == ValidationErrorEventAction.Removed) AsignacionControllerViewModel.Errors -= 1;
        }

    }
}
