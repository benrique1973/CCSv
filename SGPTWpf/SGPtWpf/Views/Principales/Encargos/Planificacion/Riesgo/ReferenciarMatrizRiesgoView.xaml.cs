using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Planificacion.Riesgo;
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

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Planificacion.Riesgo
{
    /// <summary>
    /// Lógica de interacción para ReferenciarMatrizRiesgoView.xaml
    /// </summary>
    public partial class ReferenciarMatrizRiesgoView : MetroWindow
    {
        public ReferenciarMatrizRiesgoView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
            txtReferencia.Focus();
        }
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) MatrizRiesgoControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) MatrizRiesgoControllerViewModel.Errors -= 1;
        }

    }
}
