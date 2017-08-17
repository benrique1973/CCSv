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

namespace SGPTWpf.SGPtWpf.Recursos.controles.Impresion
{
    /// <summary>
    /// Lógica de interacción para Encabezado.xaml
    /// </summary>
    public partial class Encabezado : UserControl
    {
        public Encabezado()
        {
            InitializeComponent();
            //Tamaño de pantalla
            double ancho = PrincipalAlterna.ancho;
            double largo = PrincipalAlterna.largo;

            this.Width = 1123;
            this.Height = 150;

            //this.Height = largo - 1;
            //datosConsulta.Width = Width ;
            datosConsulta.MinWidth = Width * 0.5;
            datosConsulta.MaxWidth = PrincipalAlterna.largoPaginaOficio; //Margen derecho e izquierdo=864
            //datosConsulta.Height = Height - 300;
            //datosConsulta.MaxHeight = Height - 62;
            //datosConsulta.MinHeight = Height * 0.5;

        }
    }
}
