//http://phoneask.cc/questions/3668/wpf-datagrid-validationrule-for-unique-field
//https://social.technet.microsoft.com/wiki/contents/articles/31422.wpf-passing-a-data-bound-value-to-a-validation-rule.aspx
using SGPTWpf.Model;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class UniqueCodigoContableRule : ValidationRule
    {
        public CollectionViewSource CurrentCollection { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null)
            {
                ObservableCollection<ElementoModelo> castedCollection = (ObservableCollection<ElementoModelo>)CurrentCollection.Source;

                ElementoModelo currentValue = (ElementoModelo)((BindingExpression)value).DataItem;

                foreach (ElementoModelo swVM in castedCollection)
                {
                    if (currentValue.GetHashCode() != swVM.GetHashCode() && swVM.digitosElementoModelo.idDigitosModelo.ToString() == currentValue.digitosElementoModelo.idDigitosModelo.ToString())
                    {
                        //return new ValidationResult(false, ResourcesManager.Instance.GetString("DuplicatedRecord"));
                        return new ValidationResult(false,
                          "Los códigos de los  elementos contables no pueden repetirse ");

                    }
                }
            }

            return new ValidationResult(true, null);
        }
    }
}