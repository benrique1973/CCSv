using MahApps.Metro.Controls;
using SGPTmvvm.Mensajes;
using System;
using System.Windows;

namespace SGPTmvvm.Modales
{
    /// <summary>
    /// Lógica de interacción para CRUDpermisosrolesView.xaml
    /// </summary>
    public partial class CRUDpermisosRolesView : MetroWindow
    {
        public CRUDpermisosRolesView(PermisosRolesMensajeModal Mensajito)
        {
            InitializeComponent();
            CRUDpermisosRolesviewModel vModel = new CRUDpermisosRolesviewModel(Mensajito);
            this.DataContext = vModel;
            this.Owner = Application.Current.MainWindow;
            if (vModel.FinalizarAction == null)
                vModel.FinalizarAction = new Action(this.Close);
        }

    }
}
