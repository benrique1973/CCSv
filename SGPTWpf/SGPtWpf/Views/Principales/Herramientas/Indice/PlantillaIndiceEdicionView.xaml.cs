using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Indice;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas.Indice
{
    /// <summary>
    /// Lógica de interacción para PlantillaIndiceEdicionView.xaml
    /// </summary>
    public partial class PlantillaIndiceEdicionView : MetroWindow
    {
        public PlantillaIndiceEdicionView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) PlantillaIndiceControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) PlantillaIndiceControllerViewModel.Errors -= 1;
        }
    }
}
