﻿using System.Windows.Controls;

namespace SGPTWpf.SGPtWpf.Recursos.controles.Impresion
{
    /// <summary>
    /// Lógica de interacción para EncabezadoIndice.xaml
    /// </summary>
    public partial class EncabezadoIndice : UserControl
    {
        public EncabezadoIndice()
        {
            InitializeComponent();
            //double ancho = PrincipalAlterna.anchoPagina;
            //double largo = PrincipalAlterna.largoPaginaBond;

            this.Width = 624;
            this.Height = 170;

            //this.Height = largo - 1;
            //datosConsulta.Width = Width ;
            datosConsultaEncabezado.MinWidth = Width * 0.5;
            datosConsultaEncabezado.MaxWidth = 624; //Margen derecho e izquierdo
            //datosConsulta.Height = Height - 300;
            //datosConsulta.MaxHeight = Height - 62;
            //datosConsulta.MinHeight = Height * 0.5;

        }
    }
}
