using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.Ajustes;
using SGPTWpf.Views.Compartidas;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Ajustes
{
    /// <summary>
    /// Lógica de interacción para AjustesCrudView.xaml
    /// </summary>
    public partial class AjustesCrudView : MetroWindow
    {

        public AjustesCrudView()
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
            if (e.Action == ValidationErrorEventAction.Added) AjustesReclasificacionesControllerViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) AjustesReclasificacionesControllerViewModel.Errors -= 1;
        }

    }
}