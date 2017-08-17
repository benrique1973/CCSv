using MahApps.Metro.Controls;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Marcas
{
    /// <summary>
    /// Lógica de interacción para MarcasImpresionView.xaml
    /// </summary>
    public partial class MarcasImpresionView : MetroWindow
    {
        public MarcasImpresionView()
        {
            InitializeComponent();
            //Tamaño oficio
            this.Width = (8 * 96);//816
            this.Height = (11.5 * 96);//1056
            this.MinWidth = PrincipalAlterna.anchoPagina * 0.5;
            this.Width = PrincipalAlterna.anchoPagina;
            this.MaxWidth = PrincipalAlterna.anchoPagina;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinHeight = PrincipalAlterna.largoPaginaBond * 0.5;
            this.MaxHeight = PrincipalAlterna.largoPaginaBond - 47;
            this.Height = PrincipalAlterna.largoPaginaBond - 47;

            //consultaDatos.MaxWidth = MaxWidth - 2 * 96;
            //consultaDatos.MaxHeight = MaxHeight - 96;
        }

    }
}