using MahApps.Metro.Controls;
using SGPTWpf.Views.Compartidas;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias.Detalle
{
    /// <summary>
    /// Lógica de interacción para DetalleCedulaPresentacionView.xaml
    /// </summary>
    public partial class DetalleCedulaPresentacionView : MetroWindow
    {
        public DetalleCedulaPresentacionView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            //Tamaño oficio
            //Horizontal
            this.Width = (11.5 * 96);
            this.Height = //1056(8 * 96);//816

            this.MinHeight = PrincipalAlterna.anchoPagina * 0.5;
            this.MaxHeight = PrincipalAlterna.anchoPagina;
            this.Height = PrincipalAlterna.anchoPagina;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinWidth = PrincipalAlterna.largoPaginaOficio * 0.5;
            this.Width = PrincipalAlterna.largoPaginaOficio - 47;
            this.MaxWidth = PrincipalAlterna.largoPaginaOficio - 47;
        }
    }
}