using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Marcas;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Marcas
{
    /// <summary>
    /// Lógica de interacción para MarcasCrudView.xaml
    /// </summary>
    public partial class MarcasCrudView : MetroWindow
    {
        public MarcasCrudView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.MaxWidth = ancho;
            this.MaxHeight = PrincipalAlterna.largoFrame;

            MinWidth = ancho * 0.6;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = MaxHeight * 0.5;
            MaxHeight = MaxHeight;

        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) MarcasControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) MarcasControllerViewModel.Errors -= 1;
        }

    }
}