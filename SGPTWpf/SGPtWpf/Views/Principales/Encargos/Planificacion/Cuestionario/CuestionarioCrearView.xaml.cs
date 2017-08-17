using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Cuestionarios;
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

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Cuestionario
{
    /// <summary>
    /// Lógica de interacción para CuestionarioCrearView.xaml
    /// </summary>
    public partial class CuestionarioCrearView : MetroWindow
    {
        public CuestionarioCrearView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);

        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) CuestionarioControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) CuestionarioControllerViewModel.Errors -= 1;
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
