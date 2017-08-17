using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTmvvm.Mensajes;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;


namespace SGPTmvvm.Modales
{
    public partial class CRUDfirmaCorrespondenciaView: MetroWindow
    {
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public CRUDfirmaCorrespondenciaView(FirmaCorrespondenciaMensajeModal Mensajito)
        {
            InitializeComponent();
            //DataContext = new MainWindowViewModel(DialogCoordinator.Instance);
            #region 
            CRUDfirmaCorrespondenciaViewModel vModel = new CRUDfirmaCorrespondenciaViewModel(Mensajito);
            #region _
            #endregion
            this.DataContext = vModel;
            this.Owner = Application.Current.MainWindow;
            if (vModel.FinalizarAction == null)
                vModel.FinalizarAction = new Action(this.Close);
            #endregion
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }  

    }
}

