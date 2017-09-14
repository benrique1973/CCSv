using MahApps.Metro.Controls;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Ajustes
{
    /// <summary>
    /// Lógica de interacción para AjustesConsulta.xaml
    /// </summary>
    public partial class AjustesConsulta : MetroWindow
    {
        public AjustesConsulta()
        {
            InitializeComponent();
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

    }
}