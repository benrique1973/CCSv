using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;
//Valida enteros
//https://social.msdn.microsoft.com/Forums/vstudio/en-US/9eed8586-7443-43e0-a65a-b7046ada1fd2/validation-error-value-could-not-be-converted?forum=wpf

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class EnteroRangeRule : ValidationRule
    {
        private int _min;
        private int _max;

        public EnteroRangeRule()
        {
        }

        public int Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        //http://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
            public override ValidationResult Validate(object value, CultureInfo cultureInfo)
            {
            int valorAConvertir = 0;
            var validationResult = new ValidationResult(true, null);
            try { 
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(value.ToString()))
                    {
                        var regex = new Regex("[^0-9]+"); //regex that matches disallowed text
                        var parsingOk = !regex.IsMatch(value.ToString());
                        if (!parsingOk)
                        {
                            validationResult = new ValidationResult(false, "Ingreso caracteres inválidos, Por favor ingrese un valor entero");
                            return validationResult;
                        }
                        else
                        {
                            valorAConvertir = int.Parse(value.ToString());
                        }
                    }
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Contiene caracteres no válidos");
            }

            if ((valorAConvertir < Min) || (valorAConvertir > Max))
            {
                return new ValidationResult(false,
                  "Por favor ingrese valores  en el siguiente rango: " + Min + " - " + Max + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }

        /* public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
         {
             int valorAConvertir = 0;

             try
             {
                 if (((string)value).Length > 0)
                     valorAConvertir = int.Parse(value.ToString());
             }
             catch (Exception )
             {
                 return new ValidationResult(false, "Contiene caracteres no válidos");
             }

             if ((valorAConvertir < Min) || (valorAConvertir > Max))
             {
                 return new ValidationResult(false,
                   "Por favor ingrese valores  en el siguiente rango: " + Min + " - " + Max + ".");
             }
             else
             {
                 return new ValidationResult(true, null);
             }
         }*/
    }
}
