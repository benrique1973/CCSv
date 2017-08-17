using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
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

namespace SGPTWpf.Views.Principales.Encargos.Cierre
{
    /// <summary>
    /// Lógica de interacción para CierreView.xaml
    /// </summary>
    public partial class CierreView : UserControl
    {
        private string token = "MenuCierreEncargo";
        public CierreView()
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


            gridMenuLateral.MinWidth = Width * 0.08;
            gridMenuLateral.Width = 200;
            gridMenuLateral.MaxWidth = 245;

            gridMenuLateral.MinHeight = Height - 1;
            gridMenuLateral.Height = Height - 1;
            gridMenuLateral.MinHeight = Height * 0.5;

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
