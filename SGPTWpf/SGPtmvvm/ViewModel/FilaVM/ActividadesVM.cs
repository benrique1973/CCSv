using CapaDatos;
namespace SGPTmvvm.ViewModel.FilaVM
{
    public class ActividadesVM : SGPTmvvm.Soporte.VMBase
    {
        public actividade TheActividades { get; set; }
        public ActividadesVM()
        {
            TheActividades = new actividade();
        }
    }
}
