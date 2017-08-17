using SGPTWpf.ViewModel;
using System;
using System.Windows.Controls;

namespace SGPTWpf.Messages.Navegacion
{
    //Sirver  para comunicar todas las pantallas con base a la seleccion que se realiza por el usuario
    //Se identifica mediante  los token en cada menu
    public class NavegacionSgpt
    {
        public Type ViewType { get; set; }
        public Type ViewModelType { get; set; }
        public UserControl View { get; set; }
        public ViewModeloBase Contexto { get; set; }
    }
}
