using System;
using System.Linq;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionISSS : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                var valueAsStringNIT = value.ToString();

                if (valueAsStringNIT.Length == 11)
                {
                    string primerostres = valueAsStringNIT.Substring(0, 3);
                    string p1caracterseparacion = valueAsStringNIT.Substring(3, 1);
                    string segundosdos = valueAsStringNIT.Substring(4, 2);
                    string p2caracterseparacion = valueAsStringNIT.Substring(6, 1);
                    string tercerocuatro = valueAsStringNIT.Substring(7, 4);

                    bool p1todosDigitos = primerostres.All(char.IsDigit);
                    bool p1separadorcorrecto = (p1caracterseparacion == "-" ? true : false);
                    bool p2todosDigitos = segundosdos.All(char.IsDigit);
                    bool p2separadorcorrecto = (p2caracterseparacion == "-" ? true : false);
                    bool p3todosDigitos = tercerocuatro.All(char.IsDigit);

                    if (p1todosDigitos && p1separadorcorrecto && p2todosDigitos && p2separadorcorrecto && p3todosDigitos)
                    {
                        return ValidationResult.ValidResult;
                    }
                }
                else if (valueAsStringNIT.Length == 0) { return ValidationResult.ValidResult; }
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
