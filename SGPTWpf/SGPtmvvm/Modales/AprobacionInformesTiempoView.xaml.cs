using SGPTmvvm.Mensajes;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

using MahApps.Metro.Controls;


namespace SGPTmvvm.Modales
{
    /// <summary>
    /// Lógica de interacción para AprobacionInformesTiempoView.xaml
    /// </summary>
    public partial class AprobacionInformesTiempoView : MetroWindow
    {
        //private const int GWL_STYLE = -16;
        //private const int WS_SYSMENU = 0x80000;

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        //[DllImport("user32.dll")]
        //private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        public AprobacionInformesTiempoView(FirmaTiemposMensajeModal Mensajito)
        {
            InitializeComponent();
            AprobacionInformesTiempoViewModel vModel = new AprobacionInformesTiempoViewModel(Mensajito);
            this.DataContext = vModel;
            this.Owner = Application.Current.MainWindow;
            if (vModel.FinalizarAction == null)
                vModel.FinalizarAction = new Action(this.Close);
            if (vModel.OcultarVentana == null)
                vModel.OcultarVentana = new Action(this.Hide);
            if (vModel.RestaurarVentana == null)
                vModel.RestaurarVentana = new Action(this.Show);
        }
        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var hwnd = new WindowInteropHelper(this).Handle;
        //    SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        //}  

    }
}
