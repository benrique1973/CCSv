using SGPTmvvm.ViewModel;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para tabcontenedorFirmaConfiguracion.xaml
    /// </summary>
    public partial class tabcontenedorFirmaConfiguracion : UserControl
    {
        public tabcontenedorFirmaConfiguracion()
        {
            InitializeComponent();
            this.DataContext = new tabconenedorFirmaConfiguracionViewModel();
            InitializeComponent();
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame - 15) * (1 - 0.18); ;
            this.Height = PrincipalAlterna.largoFrame - 48;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width-2.5;
            //datosConsulta.Height = Height - 15;
            //datosConsulta.MaxHeight = Height - 15;
            datosConsulta.Height = Height - 59;
            datosConsulta.MaxHeight = Height - 59;
        }
    }
}

