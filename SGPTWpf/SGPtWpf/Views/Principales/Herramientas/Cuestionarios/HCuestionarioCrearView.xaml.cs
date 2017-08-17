using MahApps.Metro.Controls;
using SGPTWpf.ViewModel.Herramientas.Cuestionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SGPTWpf.SGPtWpf.Views.Principales.Herramientas.Cuestionarios
{
    /// <summary>
    /// Lógica de interacción para HCuestionarioCrearView.xaml
    /// </summary>
    public partial class HCuestionarioCrearView : MetroWindow
    {
        public HCuestionarioCrearView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) HerramientasCuestionarioControllerCrearViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) HerramientasCuestionarioControllerCrearViewModel.Errors -= 1;
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
