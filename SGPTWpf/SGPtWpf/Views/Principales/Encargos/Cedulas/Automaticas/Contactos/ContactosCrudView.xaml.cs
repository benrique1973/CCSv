using MahApps.Metro.Controls;
using SGPTWpf.SGPtWpf.ViewModel.Encargos.Cedulas.PreElaboradas.Contactos;
using SGPTWpf.Views.Compartidas;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Automaticas.Contactos
{
    /// <summary>
    /// Lógica de interacción para ContactosCrudView.xaml
    /// </summary>
    public partial class ContactosCrudView : MetroWindow
    {
        public ContactosCrudView()
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
            if (e.Action == ValidationErrorEventAction.Added) ContactosControllerViewModelo.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) ContactosControllerViewModelo.Errors -= 1;
        }

    }
}