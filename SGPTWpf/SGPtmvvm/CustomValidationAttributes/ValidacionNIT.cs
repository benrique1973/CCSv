using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionNIT : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                var valueAsStringNIT = value.ToString();

                if (valueAsStringNIT.Length == 17)
                {
                    string primeroscuatro = valueAsStringNIT.Substring(0, 4);
                    string p1caracterseparacion = valueAsStringNIT.Substring(4, 1);
                    string segundosseis = valueAsStringNIT.Substring(5, 6);
                    string p2caracterseparacion = valueAsStringNIT.Substring(11, 1);
                    string tercerotres = valueAsStringNIT.Substring(12, 3);
                    string p3caracterseparacion = valueAsStringNIT.Substring(15, 1);
                    string c = valueAsStringNIT.Substring(16, 1);
                    char ultimocaracter = char.Parse(c);

                    bool p1todosDigitos = primeroscuatro.All(char.IsDigit);
                    bool p1separadorcorrecto = (p1caracterseparacion == "-" ? true : false);
                    bool p2todosDigitos = segundosseis.All(char.IsDigit);
                    bool p2separadorcorrecto = (p2caracterseparacion == "-" ? true : false);
                    bool p3todosDigitos = tercerotres.All(char.IsDigit);
                    bool p3separadorcorrecto = (p3caracterseparacion == "-" ? true : false);

                    bool esultimodigito = char.IsDigit(ultimocaracter);
                    if (p1todosDigitos && p1separadorcorrecto && p2todosDigitos && p2separadorcorrecto && p3todosDigitos && p3separadorcorrecto && esultimodigito)
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
