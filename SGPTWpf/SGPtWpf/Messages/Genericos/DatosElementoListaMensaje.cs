using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
//Clase generica para trasladar lista, elemento 
namespace SGPTWpf.Messages.Genericos
{
    public class DatosElementoListaMensaje : Messenger
    {
        public object elementoMensaje { get; set; }//Elemento que será trasladado
        public ObservableCollection<Object> listaMensaje { get; set; }//Lista de elementos a ser enviados
        public int numeroProcesoCrudEnviado { get; set; }//Correlativo de proceso para evitar procesar varias veces
        public int comandoCrud { get; set; }//Comando de tipo crud que esta ejecutando
    }
}
