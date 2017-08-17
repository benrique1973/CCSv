using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionDUI : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value !=null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Length==10)
                {
                    string primerosochocaracteres = valueAsString.Substring(0, 8);
                    string caracterseparacion = valueAsString.Substring(8,1);
                    string c = valueAsString.Substring(9,1);
                    char ultimocaracter = char.Parse(c);
                    bool todosDigitos = primerosochocaracteres.All(char.IsDigit);// int.TryParse(valueAsString.Substring(0,8));
                    bool separadorcorrecto = (caracterseparacion=="-" ? true:false);
                    bool esultimodigito = char.IsDigit(ultimocaracter);
                    if (todosDigitos && separadorcorrecto&&esultimodigito)
                    {
                        return ValidationResult.ValidResult;
                    } 
                }
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }
    }
}
