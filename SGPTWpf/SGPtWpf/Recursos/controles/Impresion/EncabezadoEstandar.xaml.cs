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
    /// Lógica de interacción para EncabezadoEstandar.xaml
    /// </summary>
    public partial class EncabezadoEstandar : UserControl
    {
        public EncabezadoEstandar()
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