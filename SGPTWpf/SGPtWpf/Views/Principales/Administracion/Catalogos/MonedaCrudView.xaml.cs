using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Catalogos
{
    /// <summary>
    /// Lógica de interacción para MonedaCrudView.xaml
    /// </summary>
    public partial class MonedaCrudView : UserControl
    {
        public MonedaCrudView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame - 25) * (1 - 0.18); ;
            this.Height = PrincipalAlterna.largoFrame - 42;;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width;
            datosConsulta.Height = Height - 15;
            datosConsulta.MaxHeight = Height - 15;

            dataGrid.Width = Width;
            dataGrid.MaxHeight = Height - 60;
            dataGrid.Height = Height - 60;



            correlativo.Width = Width * 0.10;
            correlativo.MinWidth = Width * 0.05;
            correlativo.MaxWidth = Width * 0.10;

            datosParticular.Width = Width * 0.30;
            datosParticular.MinWidth = Width * 0.10;
            datosParticular.MaxWidth = Width * 0.30;

            datos.Width = Width * 0.59;
            datos.MinWidth = Width * 0.20;
            datos.MaxWidth = Width * 0.59;

        }
    }
}
