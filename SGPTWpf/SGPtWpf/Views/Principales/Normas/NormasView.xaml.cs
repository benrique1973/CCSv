using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Views.Compartidas;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.Views.Administracion
{
    /// <summary>
    /// Lógica de interacción para NormasView.xaml
    /// </summary>
    public partial class NormasView : UserControl
    {
        private string token = "MenuLegalNormas";
        public NormasView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionSgpt>(this,token, (action) => ShowContenidoControl(action));
            //Tamaño de pantalla
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            MinWidth = PrincipalAlterna.MinanchoFrame - 3;
            Width = PrincipalAlterna.anchoFrame - 3;
            MaxWidth = PrincipalAlterna.MaxanchoFrame - 3;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = PrincipalAlterna.MinlargoFrame - 3;
            MaxHeight = PrincipalAlterna.MaxlargoFrame - 3;
            Height = PrincipalAlterna.largoFrame - 3;


            Principal.Width = ancho - 3;
            Principal.Height = largo - 3;

            EditFrameNorma.Width = Width - 225;
            EditFrameNorma.MinWidth = Width*0.5;
            EditFrameNorma.MaxWidth = Width - 225;

            EditFrameNorma.Height = Height- 32;
            EditFrameNorma.MinHeight = Height*0.41;
            EditFrameNorma.MaxHeight = Height - 32;

            gtiDatosNorma.Width = Width - 225;
            gtiDatosNorma.MinWidth = Width * 0.5;
            gtiDatosNorma.MaxWidth = Width - 225;

            gtiDatosNorma.Height = Height - 32;
            gtiDatosNorma.MaxHeight = Height - 32;
            gtiDatosNorma.MinHeight = Height* 0.5;


            gridMenuLateral.MinWidth = 230;
            gridMenuLateral.Width = 200;
            gridMenuLateral.MaxWidth = 230;

            gridMenuLateral.MaxHeight = Height -41;
            gridMenuLateral.Height = Height - 41;
            gridMenuLateral.MinHeight = Height*0.5;


            dataGridMenuNorma.MaxHeight = Height - 43;   //Ancho del datagrid
            dataGridMenuNorma.MinHeight = Height*0.45;    //Ancho del datagrid
            dataGridMenuNorma.Height = Height - 43;    //Ancho del datagrid


            dataGridMenuNorma.MinWidth = 230;
            dataGridMenuNorma.Width = 230;
            dataGridMenuNorma.MaxWidth = 230;

        }
        private void ShowContenidoControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            EditFrameNorma.Content = nm.View;
        }
        /*https://www.dotnetperls.com/radiobutton-wpf*/
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var button = sender as RadioButton;

            //Se crea el mensaje para seleccion
            SeleccionRadioButtonHerramientas elemento = new SeleccionRadioButtonHerramientas();
            elemento.seleccionNormativa = button.Content.ToString();
            Messenger.Default.Send(elemento);

        }
    }
}