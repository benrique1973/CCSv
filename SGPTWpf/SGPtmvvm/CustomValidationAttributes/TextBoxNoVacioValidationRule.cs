using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class TextBoxNoVacioValidationRule : ValidationRule 
        {
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
            {
                string str = value as string;
                if (str != null)
                {
                    if (str.Length > 1)
                        return ValidationResult.ValidResult;
                }
                return new ValidationResult(false, Message);
            }
            public String Message { get; set; }
        }
}
