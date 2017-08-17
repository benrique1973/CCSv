using SGPTWpf.Support;
using System;
using System.Collections.ObjectModel;

namespace SGPTWpf.Model.Modelo.Auxiliares
{
    public class MarcasSimbolos : UIBase
    {
        public string simbolo
        {
            get { return GetValue(() => simbolo); }
            set { SetValue(() => simbolo, value); }
        }
        public static ObservableCollection<MarcasSimbolos> generarListaSimbolos()
        {

            ObservableCollection<MarcasSimbolos> listaLetras = new ObservableCollection<MarcasSimbolos>();
            for (int i = 33; i <= 127; i++)
            {
                MarcasSimbolos item = new MarcasSimbolos();
                item.simbolo=Convert.ToChar(i).ToString();
                listaLetras.Add(item);
            }
            for (int i = 8700; i <= 8800; i++)
            {
                MarcasSimbolos item = new MarcasSimbolos();
                item.simbolo = Convert.ToChar(i).ToString();
                listaLetras.Add(item);
            }
            for (int i = 10000; i <= 10220; i++)
            {
                MarcasSimbolos item = new MarcasSimbolos();
                item.simbolo = Convert.ToChar(i).ToString();
                listaLetras.Add(item);
            }

            return listaLetras;
        }
        public MarcasSimbolos()
        {
            simbolo = "";
        }

    }
}
