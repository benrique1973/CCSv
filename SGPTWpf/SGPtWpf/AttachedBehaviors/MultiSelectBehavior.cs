using SGPTWpf.SGPtWpf.ViewModel.Encargos.Documentacion.CatalogoCuentas;
using SGPTWpf.SGPtWpf.Views.Principales.Encargos.Documentacion;
using System.Windows.Interactivity;

namespace SGPTWpf.AttachedBehaviors
{
    public class MultiSelectBehavior : Behavior<CatalogoCuentasView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            ((CatalogoCuentasViewModel)this.AssociatedObject.DataContext).SelectedItems = this.AssociatedObject.SelectedItems;
        }
    }
}
