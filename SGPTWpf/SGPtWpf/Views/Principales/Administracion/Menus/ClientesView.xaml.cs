using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Administracion.Menus
{
    /// <summary>
    /// Lógica de interacción para ClientesView.xaml
    /// </summary>
    public partial class ClientesView : UserControl
    {
        public ClientesView()
        {
            InitializeComponent();
            //Para acciones de catalogo
            Messenger.Default.Register<NavegacionCliente>(this, (action) => ShowClienteControl(action));
            //Tamaño de pantalla
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            MinWidth = PrincipalAlterna.MinanchoFrame - 7;
            Width = PrincipalAlterna.anchoFrame - 7;
            MaxWidth = PrincipalAlterna.MaxanchoFrame - 7;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = PrincipalAlterna.MinlargoFrame - 46;
            MaxHeight = PrincipalAlterna.MaxlargoFrame - 46;
            Height = PrincipalAlterna.largoFrame - 41;

            //Contenedor principal
            gtiDatos.Width = Width - 240;
            gtiDatos.MinWidth = Width * 0.5;
            gtiDatos.MaxHeight = Height;

            //Grid
            gtiDatosGrid.Width = Width - 240;
            gtiDatosGrid.MinWidth = Width * 0.5;
            gtiDatosGrid.MaxHeight = Height;

            //Grid internos
            dataGrid.Width= Width - 245;
            dataGrid.Height = Height - 4;

            dataGridEncargos.Width = Width - 245;
            dataGridEncargos.Height = Height - 4;
            
            //Frame contenedor
            EditFrame.Width = Width - 242;
            EditFrame.Height = Height - 4;

            /* gMenu.Width = Width * 0.20;
             gMenu.Height = Height;*/



            //contenidoMenu.Width = Width * 0.175;
            //contenidoMenu.MinWidth = Width * 0.175;
            //contenidoMenu.MaxWidth = Width * 0.175;

            //dataGridMenu.MinWidth = Width * 0.18;

        }
        private void ShowClienteControl(NavegacionCliente nm)
        {
            //nm.View.DataContext = nm.Contexto;
            if (nm.opcionMenu == 1)
            {
                nm.View.DataContext = nm.Contexto1;
            }
            if (nm.opcionMenu == 2)
            {
                nm.View.DataContext = nm.Contexto2;
            }
            if (nm.opcionMenu == 3)
            {
                nm.View.DataContext = nm.Contexto3;
            }
            if (nm.opcionMenu == 0) //cero es el Listado de los clientes
            {
                nm.View.DataContext = nm.ContextoCliList;
            }


            if (nm.opcionMenu == 4 || nm.opcionMenu == 5)
            {
                nm.View.DataContext = nm.Contexto;
            }

            EditFrame.Content = null;
            GC.Collect();
            EditFrame.Content = nm.View;
            //            Messenger.Default.Unregister<DetalleHerramientoCrudMensaje>(this);
            //Messenger.Default.Unregister<NavegacionCliente>(this);
            GC.Collect();
        }


        //private void PerdioFoco(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    MessageBox.Show("Perdio el foco");
        //}


    }
}
