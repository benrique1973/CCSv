using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using SGPTWpf.Support;
using SGPTWpf.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGPTWpf.Views
{

    public partial class LoguinView : MetroWindow , IHavePassword
    {
        public LoguinView()
        {
            InitializeComponent();
            var errors = GrdDatosCuerpo.GetValue(Validation.ErrorsProperty);
        }

        public LoguinViewModel ViewModel
        {
            get { return this.DataContext as LoguinViewModel; }
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            this.ViewModel.Dispose();
        }

        //private DataRowView rowBeingEdited = null;
        private void Validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) LoguinViewModel.Errors += 1;
            if (e.Action == ValidationErrorEventAction.Removed) LoguinViewModel.Errors -= 1;
        }

        //https://code.msdn.microsoft.com/windowsdesktop/Get-Password-from-df012a86
        public System.Security.SecureString Password
        {
            get
            {
                return pBoxClave.SecurePassword;
            }
        }
        //http://stackoverflow.com/questions/17451497/how-to-use-the-enter-key-to-submit-login-details
        private void txtUsuarioKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                pBoxClave.Focus();
            }
        //TODO: do login
        }
        private void txtClaveKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                comandIngresar.Focus();
            }
            //TODO: do login
        }
    }
}