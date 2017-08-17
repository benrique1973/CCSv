using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion.Clientes
{
    /// <summary>
    /// Lógica de interacción para ExpedienteView.xaml
    /// </summary>
    public partial class ExpedienteView : UserControl
    {
        public ExpedienteView()
        {
            InitializeComponent();
            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            Width = ancho * 0.806;
            MinWidth = ancho * 0.20;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = largo * 0.50;
            Height = largo * 0.781;


            dataGrid.Width = Width * 0.9995;
            dataGrid.MaxHeight = Height;


            correlativo.Width = Width * 0.10;
            correlativo.MinWidth = Width * 0.05;
            correlativo.MaxWidth = Width * 0.10;

            datos.Width = Width * 0.88;
            datos.MinWidth = Width * 0.30;
            datos.MaxWidth = Width * 0.88;
        }
    }
}
