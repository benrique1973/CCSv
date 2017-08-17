using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas.Plantillas
{
    /// <summary>
    /// Lógica de interacción para PlantillasCrudView.xaml
    /// </summary>
    public partial class PlantillasCrudView : UserControl
    {
        public PlantillasCrudView()
        {
            InitializeComponent();
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame);//Porque no hay barra lateral
            this.Height = PrincipalAlterna.largoFrame - 42;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width - 8;
            datosConsulta.MinWidth = MinWidth;
            datosConsulta.MaxWidth = MaxWidth;

            datosConsulta.Height = Height - 60;
            datosConsulta.MinHeight = MinHeight - 3;
            datosConsulta.MaxHeight = MaxHeight - 3;

            dataGrid.Width = datosConsulta.Width - 1;
            dataGrid.MinWidth = datosConsulta.MinWidth - 1;
            dataGrid.MaxWidth = datosConsulta.MaxWidth - 1;

            dataGrid.MaxHeight = datosConsulta.Height - 1;
            dataGrid.MinHeight = datosConsulta.MinHeight - 1;
            dataGrid.MaxHeight = datosConsulta.MaxHeight - 1;

            gridMenu.Width = datosConsulta.Width - 1;
            gridMenu.MinWidth = datosConsulta.MinWidth - 1;
            gridMenu.MaxWidth = datosConsulta.MaxWidth - 1;

            /////////////////////////////////////////////////////////
        }
    }
}
