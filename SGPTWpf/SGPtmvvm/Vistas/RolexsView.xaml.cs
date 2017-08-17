﻿using SGPTmvvm.ViewModel;
using System.Windows.Controls;
namespace SGPTmvvm.Vistas
{
    /// <summary>
    /// Lógica de interacción para UsuariosView.xaml
    /// </summary>
    public partial class RolexsView : UserControl
    {
        public RolexsView()
        {
            InitializeComponent();
            this.DataContext = new RolexsViewModel();
        }
    }
}
