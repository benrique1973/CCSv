using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Supervision.Avance
{
    /// <summary>
    /// Lógica de interacción para AvanceView.xaml
    /// </summary>
    public partial class AvanceView : UserControl
    {
        public AvanceView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = ancho - 205;
            ///this.Height = PrincipalAlterna.largoFrame - 42;
            this.Height = PrincipalAlterna.largoFrame;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width - 7;
            datosConsulta.MinWidth = Width * 0.5;
            datosConsulta.MaxWidth = Width - 7;

            datosConsulta.Height = Height-45 ;
            datosConsulta.MaxHeight = Height-45 ;
            datosConsulta.MinHeight = Height * 0.5;

            #region superior

            Gsuperior.Width = datosConsulta.Width/2;
            Gsuperior.MinWidth = 0.50*datosConsulta.Width/2;
            Gsuperior.MaxWidth = datosConsulta.Width/2;

            Gsuperior.Height = datosConsulta.Height/2;
            Gsuperior.MaxHeight = datosConsulta.Height/2;
            Gsuperior.MinHeight = datosConsulta.Height*0.25;

            dataGridPrograma.Width = Gsuperior.Width;
            dataGridPrograma.MinWidth = Gsuperior.MinWidth;
            dataGridPrograma.MaxWidth = Gsuperior.Width ;

            dataGridPrograma.Height = Gsuperior.Height;
            dataGridPrograma.MaxHeight = Gsuperior.Height;
            dataGridPrograma.MinHeight = Gsuperior.MinHeight;

            #endregion
            #region superiorDerecha
            GsuperiorDerecho.Width = datosConsulta.Width / 2;
            GsuperiorDerecho.MinWidth = 0.50 * datosConsulta.Width / 2;
            GsuperiorDerecho.MaxWidth = datosConsulta.Width / 2;

            GsuperiorDerecho.Height = datosConsulta.Height / 2;
            GsuperiorDerecho.MaxHeight = datosConsulta.Height / 2;
            GsuperiorDerecho.MinHeight = datosConsulta.Height * 0.25;

            dataGridCuestionarios.Width = GsuperiorDerecho.Width;
            dataGridCuestionarios.MinWidth = GsuperiorDerecho.MinWidth;
            dataGridCuestionarios.MaxWidth = GsuperiorDerecho.Width;

            dataGridCuestionarios.Height = GsuperiorDerecho.Height;
            dataGridCuestionarios.MaxHeight = GsuperiorDerecho.Height;
            dataGridCuestionarios.MinHeight = GsuperiorDerecho.MinHeight;
            #endregion

            #region inferior
            Ginferior.Width = datosConsulta.Width / 2;
            Ginferior.MinWidth = 0.50 * datosConsulta.Width / 2;
            Ginferior.MaxWidth = datosConsulta.Width / 2;

            Ginferior.Height = datosConsulta.Height / 2;
            Ginferior.MaxHeight = datosConsulta.Height / 2;
            Ginferior.MinHeight = datosConsulta.Height * 0.25;

            dataGridCarpetas.Width = Ginferior.Width;
            dataGridCarpetas.MinWidth = Ginferior.MinWidth;
            dataGridCarpetas.MaxWidth = Ginferior.Width;

            dataGridCarpetas.Height = Ginferior.Height;
            dataGridCarpetas.MaxHeight = Ginferior.Height;
            dataGridCarpetas.MinHeight = Ginferior.MinHeight;
            #endregion
            #region inferiorDerecha
            GinferiorDerecho.Width = datosConsulta.Width / 2;
            GinferiorDerecho.MinWidth = 0.50 * datosConsulta.Width / 2;
            GinferiorDerecho.MaxWidth = datosConsulta.Width / 2;

            GinferiorDerecho.Height = datosConsulta.Height / 2;
            GinferiorDerecho.MaxHeight = datosConsulta.Height / 2;
            GinferiorDerecho.MinHeight = datosConsulta.Height * 0.25;

            dataGridCedulas.Width = GinferiorDerecho.Width;
            dataGridCedulas.MinWidth = GinferiorDerecho.MinWidth;
            dataGridCedulas.MaxWidth = GinferiorDerecho.Width;

            dataGridCedulas.Height = GinferiorDerecho.Height;
            dataGridCedulas.MaxHeight = GinferiorDerecho.Height;
            dataGridCedulas.MinHeight = GinferiorDerecho.MinHeight;
            #endregion
            //dataGrid.Width = datosConsulta.Width - 1;
            //dataGrid.MaxWidth = datosConsulta.MinWidth - 1;
            //dataGrid.MinWidth = datosConsulta.MaxWidth - 1;

            //dataGrid.Height = datosConsulta.Height - 60;
            //dataGrid.MaxHeight = datosConsulta.MaxHeight - 60;
            //dataGrid.MinHeight = datosConsulta.MinHeight - 60;
        }
    }
}
