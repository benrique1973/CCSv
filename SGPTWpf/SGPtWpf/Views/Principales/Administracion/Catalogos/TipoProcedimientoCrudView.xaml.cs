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

namespace SGPTWpf.Views.Principales.Administracion.Catalogos
{
    /// <summary>
    /// Lógica de interacción para TipoProcedimientoCrudView.xaml
    /// </summary>
    public partial class TipoProcedimientoCrudView : UserControl
    {
        public TipoProcedimientoCrudView()
        {
            InitializeComponent();
            //Tamaño de pantalla
            //double ancho = System.Windows.SystemParameters.PrimaryScreenWidth;
            double ancho = PrincipalAlterna.anchoFrame;
            double largo = PrincipalAlterna.MaxlargoFrame;

            this.Width = (PrincipalAlterna.anchoFrame - 25) * (1 - 0.18); ;
            this.Height = PrincipalAlterna.largoFrame - 42;;

            MinWidth = Width * 0.6;
            MaxWidth = Width;

            //double largo = System.Windows.SystemParameters.PrimaryScreenHeight;
            MinHeight = Height * 0.5;
            MaxHeight = Height;

            datosConsulta.Width = Width;
            datosConsulta.Height = Height - 15;
            datosConsulta.MaxHeight = Height - 15;

            dataGrid.Width = Width;
            dataGrid.MaxHeight = Height - 60;
            dataGrid.Height = Height - 60;


            correlativo.Width = Width * 0.10;
            correlativo.MinWidth = Width * 0.05;
            correlativo.MaxWidth = Width * 0.10;

            datosdescripcionIdThTp.Width = Width * 0.44;
            datosdescripcionIdThTp.MinWidth = Width * 0.10;
            datosdescripcionIdThTp.MaxWidth = Width * 0.44;

            datosdescripcionIdThTp.Width = Width * 0.44;
            datosdescripcionIdThTp.MinWidth = Width * 0.10;
            datosdescripcionIdThTp.MaxWidth = Width * 0.44;
        }
    }
}
