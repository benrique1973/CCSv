using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace SGPTWpf.SGPtWpf.Views.Principales.Encargos.Cedulas.Sumarias
{
    /// <summary>
    /// Lógica de interacción para SumariaPresentacionView.xaml
    /// </summary>
    public partial class SumariaPresentacionView : MetroWindow
    {
        public SumariaPresentacionView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            //Tamaño oficio
            //Horizontal
            this.Width = (11.5 * 96);
            this.Height = //1056(8 * 96);//816

            this.MinHeight = PrincipalAlterna.anchoPagina * 0.5;
            this.MaxHeight = PrincipalAlterna.anchoPagina;
            this.Height = PrincipalAlterna.anchoPagina;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.MinWidth = PrincipalAlterna.largoPaginaOficio * 0.5;
            this.Width = PrincipalAlterna.largoPaginaOficio;
            this.MaxWidth = PrincipalAlterna.largoPaginaOficio;
        }
    }
}