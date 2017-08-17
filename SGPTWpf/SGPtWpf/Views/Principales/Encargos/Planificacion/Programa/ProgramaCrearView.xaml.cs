using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Planificacion.Programas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion
{
    /// <summary>
    /// Lógica de interacción para ProgramaCrearView.xaml
    /// </summary>
    public partial class ProgramaCrearView : MetroWindow
    {
        public ProgramaCrearView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
           if (e.Action == ValidationErrorEventAction.Added) ProgramaControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) ProgramaControllerViewModel.Errors -= 1;
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
