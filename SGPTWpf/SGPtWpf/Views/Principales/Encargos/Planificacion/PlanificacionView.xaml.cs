using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Encargos.Planificacion
{
    /// <summary>
    /// Lógica de interacción para PlanificacionView.xaml
    /// </summary>
    public partial class PlanificacionView : UserControl
    {
        private string token = "MenuPlanificacion";
        public PlanificacionView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionSgpt>(this,token, (action) => ShowContenidoControl(action));
            //Tamaño de pantalla

            this.MinWidth = PrincipalAlterna.MinanchoFrame * 0.5;
            this.Width = PrincipalAlterna.anchoFrame - 2;
            this.MaxWidth = PrincipalAlterna.MaxanchoFrame - 2;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinHeight = PrincipalAlterna.MinlargoFrame * 0.5;
            this.MaxHeight = PrincipalAlterna.MaxlargoFrame - 40;
            this.Height = PrincipalAlterna.largoFrame - 40;


            gridMenuLateral.MinWidth = Width*0.08;
            gridMenuLateral.Width = 200;
            gridMenuLateral.MaxWidth = 245;

            gridMenuLateral.MinHeight = Height - 1;
            gridMenuLateral.Height = Height - 1;
            gridMenuLateral.MinHeight = Height*0.5;

            //gtiDatos.Width = Width - 200;
            gtiDatos.Width = Width - 200;
            gtiDatos.MinWidth = Width * 0.5;

            gtiDatos.Height = Height - 1;
            gtiDatos.MaxHeight = Height - 1;



            /////////////////////////////////////////////////////////
            EditFrame.Width = Width - 200;
            EditFrame.Height = Height - 1;

            contenidoMenu.Width = gridMenuLateral.Width - 1;
            contenidoMenu.MinWidth = gridMenuLateral.Width - 1;
            contenidoMenu.MaxWidth = gridMenuLateral.Width - 1;

        }
        private void ShowContenidoControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            EditFrame.Content = nm.View;
        }
    }
}
