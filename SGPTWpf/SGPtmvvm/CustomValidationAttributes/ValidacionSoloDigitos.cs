using System;
using System.Linq;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionSoloDigitos: ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();

                if (valueAsString.Length > 0)
                {
                    bool sonTodosDigitos = valueAsString.All(char.IsDigit);

                    if (sonTodosDigitos)
                    {
                        return ValidationResult.ValidResult;
                    }
                }
                else if (valueAsString.Length == 0) { return ValidationResult.ValidResult; }
            }
            else
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }
    }
}
