using MahApps.Metro.Controls;
using SGPTWpf.ViewModel;
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

namespace SGPTWpf.SGPtWpf.Views.Compartidas
{
    /// <summary>
    /// Lógica de interacción para InicialView.xaml
    /// </summary>
    public partial class InicialView : MetroWindow
    {
        public InicialView()
        {
            InitializeComponent();
        }

        public InicialViewModel ViewModel
        {
            get { return this.DataContext as InicialViewModel; }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.ViewModel.Dispose();
        }


    }
}
