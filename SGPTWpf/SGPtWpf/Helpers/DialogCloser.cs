using System.Windows;
//Fuente: http://social.technet.microsoft.com/wiki/contents/articles/13536.easy-mvvm-examples-in-extreme-detail.aspx
namespace SGPTWpf.Helpers
{
    class DialogCloser
    {
        public static readonly DependencyProperty DialogResultProperty =
        DependencyProperty.RegisterAttached(
        "DialogResult",
        typeof(bool?),
        typeof(DialogCloser),
        new PropertyMetadata(DialogResultChanged));

        private static void DialogResultChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
        {
            var window = d as Window;
            if (window != null)
                window.Close();
        }
        public static void SetDialogResult(Window target, bool? value)
        {
            target.SetValue(DialogResultProperty, value);
        }
    }
}
