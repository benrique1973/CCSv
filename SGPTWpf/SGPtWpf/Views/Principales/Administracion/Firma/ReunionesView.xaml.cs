using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion.Firma
{
    /// <summary>
    /// Lógica de interacción para ReunionesView.xaml
    /// </summary>
    public partial class ReunionesView : UserControl
    {
        public ReunionesView()
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


            IDreu.Width = Width * 0.10;
            IDreu.MinWidth = Width * 0.05;
            IDreu.MaxWidth = Width * 0.10;

            fechareu.Width = Width * 0.12;
            fechareu.MinWidth = Width * 0.10;
            fechareu.MaxWidth = Width * 0.15;

            Clientereu.Width = Width * 0.15;
            Clientereu.MinWidth = Width * 0.20;
            Clientereu.MaxWidth = Width * 0.25;

            asuntoreu.Width = Width * 0.20;
            asuntoreu.MinWidth = Width * 0.25;
            asuntoreu.MaxWidth = Width * 0.30;

            tiemporeu.Width = Width * 0.12;
            tiemporeu.MinWidth = Width * 0.10;
            tiemporeu.MaxWidth = Width * 0.15;

            conclureu.Width = Width * 0.20;
            conclureu.MinWidth = Width * 0.25;
            conclureu.MaxWidth = Width * 0.30;
        }
    }
}
