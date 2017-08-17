using SGPTWpf.Properties;
using SGPTWpf.ViewModel;
//08-05-2017***************************************************
//Tomadode  curso  10261A Developin Windows Applicacion  with Microsoft capitulo 14 ejercicio
//AdventureWorks.WorkOrders.Views

namespace SGPTWpf.SGPtWpf.Support
{
    public class OptionsViewModel : ViewModeloBase
    {
        public OptionsViewModel() : base()
        {
        }

        public double Left
        {
            get { return Settings.Default.Left; }
            set { Settings.Default.Left = value; }
        }

        public double Top
        {
            get { return Settings.Default.Top; }
            set { Settings.Default.Top = value; }
        }

        public double Width
        {
            get { return Settings.Default.Width; }
            set { Settings.Default.Width = value; }
        }

        public double Height
        {
            get { return Settings.Default.Height; }
            set { Settings.Default.Height = value; }
        }

        public string ConnectionString
        {
            get { return Settings.Default.ConnectionString; }
        }

        public void Save()
        {
            Settings.Default.Save();
        }

        public void Reload()
        {
            Settings.Default.Reload();
        }
    }
}
