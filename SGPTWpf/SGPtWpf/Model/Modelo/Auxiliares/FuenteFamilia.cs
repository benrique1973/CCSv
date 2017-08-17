using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SGPTWpf.Model.Modelo.Auxiliares
{
    public class FuenteFamilia : UIBase
    {
        public FontFamily fuente
        {
            get { return GetValue(() => fuente); }
            set { SetValue(() => fuente, value); }
        }
     private ObservableCollection<FontFamily> _systemFonts = new ObservableCollection<FontFamily>();
        public ObservableCollection<FontFamily> SystemFonts
        {
            get { return _systemFonts; }
        }

        public static ObservableCollection<FontFamily> listaFuentes()
        {
            ObservableCollection<FontFamily> lista = new ObservableCollection<FontFamily>();
            var fonts = Fonts.SystemFontFamilies.OrderBy(f => f.ToString());

            foreach (var f in fonts)
                lista.Add(f);
            return lista;
        }
    }
}