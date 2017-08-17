using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Programas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Programas
{
    /// <summary>
    /// Lógica de interacción para HProgramaCrearView.xaml
    /// </summary>
    public partial class HProgramaCrearView : MetroWindow
    {
        public HProgramaCrearView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) HerramientasControllerCrearViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) HerramientasControllerCrearViewModel.Errors -= 1;
        }


        //protected override void OnTextInput(TextCompositionEventArgs e)
        //{
        //    string
        //    fullText = Text.Remove(SelectionStart, SelectionLength) + e.Text;
        //    if
        //    (_regex !=
        //    null
        //     && !_regex.IsMatch(fullText)) { e.Handled = true; }
        //    else
        //    {
        //        base
        //       .OnTextInput(e);
        //    }
        //}
    }
}
