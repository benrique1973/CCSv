﻿using GalaSoft.MvvmLight.Messaging;
using SGPTWpf.Messages.Navegacion;
using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.Views.Principales.Herramientas
{
    /// <summary>
    /// Lógica de interacción para HerramientasView.xaml
    /// </summary>
    public partial class HerramientasView : UserControl
    {
        private string token = "MenuHerramientas";
        public HerramientasView()
        {
            InitializeComponent();
            Messenger.Default.Register<NavegacionSgpt>(this, token,(action) => ShowMenuControl(action));
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


            PantallaFrame.Width = ancho - 3;
            PantallaFrame.Height = largo - 3;

        }
        private void ShowMenuControl(NavegacionSgpt nm)
        {
            nm.View.DataContext = nm.Contexto;
            PantallaFrame.Content = nm.View;
        }
    }
}