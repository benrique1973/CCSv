using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Gestion
{
    /// <summary>
    /// Lógica de interacción para GestionEncargos.xaml
    /// </summary>
    public partial class GestionEncargos : UserControl
    {
        private string token = "MenuEncargo";
        public GestionEncargos()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionSgpt>(this, token, (action) => ShowContenidoControl(action));
            //Tamaño de pantalla
            double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;

            Width = ancho * 0.996;
            MinWidth = ancho * 0.20;

            double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = largo * 0.50;
            Height = largo * 0.784;

            EditFrame.Width = Width * 0.82;
            EditFrame.Height = Height;

            gtiDatos.Width = Width * 0.82;
            gtiDatos.MinWidth = Width * 0.40;
            gtiDatos.MaxHeight = Height;

            contenidoMenu.Width = Width * 0.18;
            contenidoMenu.MinWidth = Width * 0.18;
            contenidoMenu.MaxWidth = Width * 0.18;

            dataGridMenu.MinWidth = Width * 0.18;

        }
        private void ShowContenidoControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            EditFrame.Content = nm.View;
        }
    }
}
