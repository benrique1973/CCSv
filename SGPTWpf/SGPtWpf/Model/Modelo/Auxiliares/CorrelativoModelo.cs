using SGPTWpf.Support;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGPTWpf.Model.Modelo.Auxiliares
{
    public class CorrelativoModelo : UIBase
    {
        [DisplayName("Tamaño de letra")]
        [Range(8, 32, ErrorMessage = "El tamaño es de 8 a 32")]
        public int correlativo
        {
            get { return GetValue(() => correlativo); }
            set { SetValue(() => correlativo, value); }
        }
        public static ObservableCollection<CorrelativoModelo> generarListaCorrelativo(int inicio,int fin)
        {
            ObservableCollection<CorrelativoModelo> lista = new ObservableCollection<CorrelativoModelo>();
            if ((inicio >= 0) && (fin >= 0) && (inicio < fin))
            {
                for (int i = inicio; i < fin; i++)
                {
                    CorrelativoModelo item = new CorrelativoModelo();
                    item.correlativo = i;
                    lista.Add(item);
                }
            }
            return lista;
        }

        public CorrelativoModelo()
        {
            this.correlativo = 10;
        }
        public CorrelativoModelo(int indice)
        {
            this.correlativo = indice;
        }

    }
}

