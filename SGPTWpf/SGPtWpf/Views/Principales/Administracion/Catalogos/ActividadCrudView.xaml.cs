﻿using SGPTWpf.Views.Compartidas;
using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Views.Principales.Administracion.Catalogos
{
    /// <summary>
    /// Lógica de interacción para ActividadCrudView.xaml
    /// </summary>
    public partial class ActividadCrudView : UserControl
    {
        public ActividadCrudView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width= (PrincipalAlterna.anchoFrame - 25) * (1 - 0.18); ;
            this.Height = PrincipalAlterna.largoFrame - 42;;

            MinWidth = Width*0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height*0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width;
            datosConsulta.Height = Height-15;
            datosConsulta.MaxHeight = Height-15;

            dataGrid.Width = Width;
            dataGrid.MaxHeight = Height-60;
            dataGrid.Height = Height-60;


            correlativo.Width = Width * 0.10;
            correlativo.MinWidth = Width * 0.05;
            correlativo.MaxWidth = Width * 0.10;

            codigo.Width = Width * 0.10;
            codigo.MinWidth = Width * 0.05;
            codigo.MaxWidth = Width * 0.10;

            datos.Width = Width * 0.78;
            datos.MinWidth = Width * 0.30;
            datos.MaxWidth = Width * 0.78;
        }
    }
}
