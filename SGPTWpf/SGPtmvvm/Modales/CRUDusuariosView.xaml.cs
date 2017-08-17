using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using SGPTmvvm.Mensajes;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;


namespace SGPTmvvm.Modales
{
    public partial class CRUDusuariosView : MetroWindow //, YoTengoPassword
    {
        /*private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);*/

        public CRUDusuariosView()
        {
            InitializeComponent();
            #region 
            //UsuariosMensajeModal Mensajito
            //CRUDusuariosViewModel vModel = new CRUDusuariosViewModel(Mensajito);
            //se capturara aqui el valor de la contraseña, pq el PasswordBox no es bindiable de ningun lado fuera de aqui.
            Messenger.Default.Register<UsuariosMensajeModal>(this, (usuariosMensajeModal) => ControlUsuariosMensajeModal(usuariosMensajeModal));

            #region _

            #endregion
            /*this.DataContext = vModel;
            if (vModel.FinalizarAction == null)
                vModel.FinalizarAction = new Action(this.Close);*/
            #endregion
        }

        private void ControlUsuariosMensajeModal(UsuariosMensajeModal Mensajito)
        {
            switch (Mensajito.Accion)
            {
                case TipoComando.Editar:
                    txtContraseña.Password = Mensajito.usuarioAModificar.TheUsuariosPersonas.contraseniausuario;
                    txtRepitaContraseña.Password = Mensajito.usuarioAModificar.TheUsuariosPersonas.contraseniausuario;
                    break;
                default: break;
            }
        }

        /*private void Window_Loaded(object sender, RoutedEventArgs e)
{
   var hwnd = new WindowInteropHelper(this).Handle;
   SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
}  */
        #region _
        private void PerdioFocoContraseña(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtContraseña.Password))
            {
                txtContraseña.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                txtContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 255, 10, 10));
            } 
        }
        private void CambioContraPrueba(object sender, RoutedEventArgs e)
        {
            #region .
            if (String.IsNullOrWhiteSpace(txtContraseña.Password) || txtContraseña.Password.Length < 8 || txtContraseña.Password.Length > 12)
            {
                txtContraseña.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                txtContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 255, 10, 10));
                txtBandera.Text = "0"; //Bandera Ilogica que ayuda a activar el boton guardar, solo si las claves son iguales
                txtRepitaContraseña.Password = "";
                txtRepitaContraseña.IsEnabled = false;
            }
            else
            {
                txtRepitaContraseña.Password = "";
                txtRepitaContraseña.IsEnabled = true;
                //txtContraseña.BorderBrush = new SolidColorBrush(Color.FromRgb(255,255, 255));
                txtContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 10, 255, 10));
            }
            #endregion
        }

        private void RepitaContaseniaChanged(object sender, RoutedEventArgs e)
        {
            #region .
            //Comprobar si son iguales. 
            var ContraseniaSeguraPadre = txtContraseña.SecurePassword;
            var ContraseniaSeguraConfirmada = txtRepitaContraseña.SecurePassword;
            string ContraNoSeguraPadre = ConvertirACadenaInsegura(ContraseniaSeguraPadre);
            string ContraNoSeguraConfirmada = ConvertirACadenaInsegura(ContraseniaSeguraConfirmada);
            if (String.Equals(ContraNoSeguraPadre, ContraNoSeguraConfirmada))
            {
                //MessageBox.Show("Las contraseñas no son iguales","Atencion",MessageBoxButton.OK, MessageBoxImage.Error);
                txtContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 10, 255, 10));
                txtRepitaContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 10, 255, 10));
                txtBandera.Text = "1";
                //cmdGuardar.IsEnabled = true;
            }
            else
            {
                txtContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 255, 10, 10));
                txtRepitaContraseña.Background = new SolidColorBrush(Color.FromArgb(50, 255, 10, 10));
                //cmdGuardar.IsEnabled = false;
            }
            #endregion
        }

        private string ConvertirACadenaInsegura(System.Security.SecureString securePassword)
        {
            #region v
            if (securePassword == null)
            {
                return string.Empty;
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = System.Runtime.InteropServices.Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return System.Runtime.InteropServices.Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            #endregion
        }

        private void PerdioFocoRepitaContrasenia(object sender, RoutedEventArgs e)
        {
                    txtContraseña.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    txtRepitaContraseña.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            if (!String.IsNullOrWhiteSpace(txtContraseña.Password) && !String.IsNullOrWhiteSpace(txtRepitaContraseña.Password))
            {
                #region .
                //Comprobar si son iguales. 
                var ContraseniaSeguraPadre = txtContraseña.SecurePassword;
                var ContraseniaSeguraConfirmada = txtRepitaContraseña.SecurePassword;
                string ContraNoSeguraPadre = ConvertirACadenaInsegura(ContraseniaSeguraPadre);
                string ContraNoSeguraConfirmada = ConvertirACadenaInsegura(ContraseniaSeguraConfirmada);
                if (String.Equals(ContraNoSeguraPadre, ContraNoSeguraConfirmada) && !String.IsNullOrWhiteSpace(txtContraseña.Password))
                {
                    //MessageBox.Show("Las contraseñas no son iguales","Atencion",MessageBoxButton.OK, MessageBoxImage.Error);
                    txtContraseña.Background = new SolidColorBrush(Colors.White);//SolidColorBrush(Color.FromRgb(255, 255, 255));
                    txtRepitaContraseña.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    txtBandera.Text = "1";
                    //cmdGuardar.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Las contraseñas no son iguales", "Atencion", MessageBoxButton.OK, MessageBoxImage.Error);
                } 
            }
            #endregion
        } 
        #endregion




    }
}

