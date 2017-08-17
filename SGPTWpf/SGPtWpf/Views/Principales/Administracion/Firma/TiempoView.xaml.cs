using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion.Firma
{
    /// <summary>
    /// Lógica de interacción para TiempoView.xaml
    /// </summary>
    public partial class TiempoView : UserControl
    {
        public TiempoView()
        {
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

            datosConsulta.Width = Width - 2.5;
            datosConsulta.Height = Height - 59;
            datosConsulta.MaxHeight = Height - 59;

            dataGrid.Width = Width;
            dataGrid.MaxHeight = Height - 60;
            dataGrid.Height = Height - 60;

            correlativo1.Width = Width * 0.08;
            correlativo1.MinWidth = Width * 0.05;
            correlativo1.MaxWidth = Width * 0.10;

            Finicial1.Width = Width * 0.15;
            Finicial1.MinWidth = Width * 0.10;
            Finicial1.MaxWidth = Width * 0.18;

            Ffinal1.Width = Width * 0.15;
            Ffinal1.MinWidth = Width * 0.10;
            Ffinal1.MaxWidth = Width * 0.18;

            Thoras1.Width = Width * 0.15;
            Thoras1.MinWidth = Width * 0.10;
            Thoras1.MaxWidth = Width * 0.18;

            Tdias1.Width = Width * 0.15;
            Tdias1.MinWidth = Width * 0.10;
            Tdias1.MaxWidth = Width * 0.18;

            NObservaciones1.Width = Width * 0.32;
            NObservaciones1.MinWidth = Width * 0.25;
            NObservaciones1.MaxWidth = Width * 0.50;

        }
    }
}
