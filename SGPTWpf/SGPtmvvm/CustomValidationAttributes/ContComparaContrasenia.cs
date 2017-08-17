using System;
using System.Windows;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ContComparaContrasenia : FrameworkElement
    {
        //Creamos una inyeccion de dependencia para acceder al valor del textbox
        public string Valux
        {
            get { return (string)GetValue(ValuxProperty); }
            set
            {
                var valorViejo = (string)GetValue(ValuxProperty);
                if (valorViejo != value)
                    SetValue(ValuxProperty, value);
            }
        }
        //This code is automatic generated.
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValuxProperty =
            DependencyProperty.Register(
            "Valux",
            typeof(string),
            typeof(ContComparaContrasenia),
            new UIPropertyMetadata(String.Empty,ContraseniaPropertyChangedCallback));

        private static void ContraseniaPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.Print("OldValue: {0}", e.OldValue);
            System.Diagnostics.Debug.Print("NewValue: {0}", e.NewValue);
        }





        public System.Security.SecureString Valux2
        {
            get { return (System.Security.SecureString)GetValue(Valux2Property); }
            set
            {
                var valorViejo = (System.Security.SecureString)GetValue(Valux2Property);
                if (valorViejo != value)
                    SetValue(Valux2Property, value);
            }
        }
        //This code is automatic generated.
        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Valux2Property =
            DependencyProperty.Register(
            "Valux2",
            typeof(System.Security.SecureString),
            typeof(ContComparaContrasenia),
            new UIPropertyMetadata(ContraseniaPropertyChangedCallback2));

        private static void ContraseniaPropertyChangedCallback2(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.Print("OldValue: {0}", e.OldValue);
            System.Diagnostics.Debug.Print("NewValue: {0}", e.NewValue);
        }


        /*Tratamos de agarrar todo el passwordbox*/
        //Creamos una inyeccion de dependencia para acceder al valor del textbox
        #region c
        //public PasswordBox CajaClaves
        //{
        //    get { return (PasswordBox)GetValue(ValuxProperty); }
        //    set
        //    {
        //        var valorViejo = (PasswordBox)GetValue(ValuxProperty);
        //        if (valorViejo != value)
        //            SetValue(CajaClavesProperty, value);
        //    }
        //}
        ////This code is automatic generated.
        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CajaClavesProperty =
        //    DependencyProperty.Register(
        //    "CajaClaves",
        //    typeof(PasswordBox),
        //    typeof(ContComparaContrasenia),
        //    new PropertyMetadata()); 
        #endregion

    }
}