using System.Windows.Controls;
using System.Linq;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionTelefono : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                var strTelef = value.ToString();
                if (strTelef.Length == 0)
                    return ValidationResult.ValidResult;
                if (strTelef.Length == 9)
                {
                    //string primerdigito = strTelef.Substring(0, 1); //obligar que empiece con 2,7,8,9
                    string c = strTelef.Substring(0,1);
                    char primerdigito = char.Parse(c);

                    string primeroscuatrocaracteres = strTelef.Substring(0, 4);
                    string caracterseparacion = strTelef.Substring(4, 1);
                    string segundoscuatrocaracteres = strTelef.Substring(5, 4);
                    bool primerDigitoCorrecto=false;
                    if (char.IsDigit(primerdigito))
                    {
                        int i = int.Parse(c);
                        if(i==2 || i==7 || i==8 || i==9) 
                            primerDigitoCorrecto=true;
                    }
                    bool p1todosDigitos = primeroscuatrocaracteres.All(char.IsDigit);// int.TryParse(valueAsString.Substring(0,8));
                    bool separadorcorrecto = (caracterseparacion == "-" ? true : false);
                    bool p2todosDigitos = primeroscuatrocaracteres.All(char.IsDigit);
                    if (primerDigitoCorrecto && p1todosDigitos && separadorcorrecto && p2todosDigitos)
                    {
                        return ValidationResult.ValidResult;
                    }
                }
            }
            else
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, Message);
        }
        public System.String Message { get; set; }
    }
}
