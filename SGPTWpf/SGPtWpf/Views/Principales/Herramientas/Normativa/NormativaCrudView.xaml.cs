using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Messages.Navegacion.Herramientas;
using SGPTWpf.Views.Compartidas;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.Views.Administracion.Herramientas
{
    /// <summary>
    /// Lógica de interacción para NormativaCrudView.xaml
    /// </summary>
    public partial class NormativaCrudView : UserControl
    {
        private string token = "MenuLegalNormas";
        public NormativaCrudView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionSgpt>(this, token,(action) => ShowContenidoControl(action));
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

            EditFrameNorma.Width = Width-225;
            EditFrameNorma.Height = largo;

            gtiDatosNorma.Width = Width -225;
            gtiDatosNorma.MinWidth = Width*0.5;
            gtiDatosNorma.Height = largo-82;
            gtiDatosNorma.MaxHeight = largo-82;



            gridMenuLateral.MinWidth = 230;
            gridMenuLateral.Width = 200;
            gridMenuLateral.MaxWidth = 230;
            gridMenuLateral.MinHeight = Height - 82;
            gridMenuLateral.Height = Height - 82;
            gridMenuLateral.MinHeight = Height - 82;


            dataGridMenuNorma.MaxHeight = Height-100;    //Ancho del datagrid
            dataGridMenuNorma.MinWidth = 230;
            dataGridMenuNorma.Width = 230;
            dataGridMenuNorma.MaxWidth = 230;

            dataGridMenuNorma.MaxHeight = Height-82;
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