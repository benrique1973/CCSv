using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion.Firma
{
    /// <summary>
    /// Lógica de interacción para ConfiguracionView.xaml
    /// </summary>
    public partial class ConfiguracionView : UserControl
    {
        public ConfiguracionView()
        {
            InitializeComponent();
            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            Width = ancho * 0.806;
            MinWidth = ancho * 0.20;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = largo * 0.50;
            Height = largo * 0.781;

        }
    }
}
