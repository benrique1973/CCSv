using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SGPTmvvm.Soporte
{
    public class InputBox
    {

        Window Box = new Window();
        FontFamily font = new FontFamily("Tahoma");
        int FontSize = 25;
        StackPanel sp1 = new StackPanel();
        string title = "InputBox";
        string boxcontent;//title
        string defaulttext = "Escribe aqui...";
        string errormessage = "valor invalido";
        string errortitle = "Error";
        string okbuttontext = "Enviar";
        Brush BoxBackgroundColor = Brushes.GreenYellow;
        Brush InputBackgroundColor = Brushes.Ivory;
        bool clicked = false;
        TextBox input = new TextBox();
        Button ok = new Button();
        bool inputreset = false;
        public InputBox()
        {
            //try
            //{
            //    boxcontent = content;
            //}
            //catch { boxcontent = "Error!"; }
        }

        public string windowdefinic(string contenido, string Htitle, string TextoPorDefault, Brush color)
        {
            try
            {
                boxcontent = contenido;
            }
            catch { boxcontent = "Error!"; }
            try
            {
                BoxBackgroundColor = color;
            }
            catch { BoxBackgroundColor=Brushes.GreenYellow; }
            try
            {
                title = Htitle;
            }
            catch { title = "Error!"; }
            try
            {
                defaulttext = TextoPorDefault;
            }
            catch          {
                defaulttext = "Error!";
            }
            Box.Height = 200;// Box Height
            Box.Width = 500;// Box Width
            Box.MaxHeight = 200;
            Box.MinHeight = 150;// new Point(100, 100);
            Box.MaxWidth = 500;
            Box.MinWidth = 450;
            Box.ShowInTaskbar = false;
            Box.HorizontalAlignment = HorizontalAlignment.Center;
            Box.VerticalAlignment = VerticalAlignment.Center;
            
            Box.Background = BoxBackgroundColor;
            Box.Title = title;
            Box.Content = sp1;
            Box.Closing += Box_Closing;
            TextBlock content = new TextBlock();
            content.TextWrapping = TextWrapping.Wrap;
            content.Background = null;
            content.HorizontalAlignment = HorizontalAlignment.Center;
            content.Text = boxcontent;
            content.FontFamily = font;
            content.FontSize = FontSize;
            sp1.Children.Add(content);

            input.Background = InputBackgroundColor;
            input.FontFamily = font;
            input.FontSize = FontSize;
            input.HorizontalAlignment = HorizontalAlignment.Center;
            input.Text = defaulttext;
            input.MinWidth = 200;
            input.MouseEnter += input_MouseDown;
            sp1.Children.Add(input);
            ok.Width = 70;
            ok.Height = 30;
            ok.Click += ok_Click;
            ok.Content = okbuttontext;
            ok.HorizontalAlignment = HorizontalAlignment.Center;
            sp1.Children.Add(ok);
            string a=ShowDialog();
            return a;
        }
        void Box_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!clicked)
                e.Cancel = true;
        }
        private void input_MouseDown(object sender, MouseEventArgs e)
        {
            if ((sender as TextBox).Text == defaulttext && inputreset == false)
            {
                (sender as TextBox).Text = null;
                inputreset = true;
            }
        }
        void ok_Click(object sender, RoutedEventArgs e)
        {
            clicked = true;
            if (input.Text == defaulttext || input.Text == "")
                MessageBox.Show(errormessage, errortitle);
            else
            {
                Box.Close();
            }
            clicked = false;
        }
        public string ShowDialog()
        {
            Box.ShowDialog();
            return input.Text;
        }


    }
}
