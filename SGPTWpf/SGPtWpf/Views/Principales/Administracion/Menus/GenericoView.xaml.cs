using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Administracion
{
    /// <summary>
    /// Lógica de interacción para GenericoView.xaml
    /// </summary>
    public partial class GenericoView : UserControl
    {
        public GenericoView()
        {
            InitializeComponent();
            InitializeComponent();
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame);//Porque no hay barra lateral
            this.Height = PrincipalAlterna.largoFrame - 42;;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

        }
    }
}
