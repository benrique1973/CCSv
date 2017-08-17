using System;
using System.Globalization;
using System.Windows.Controls;
//Agrupa reglas de validacion
//https://msdn.microsoft.com/en-us/library/system.windows.data.binding.updatesourceexceptionfilter(v=vs.110).aspx
//https://msdn.microsoft.com/en-us/library/ms753962(v=vs.110).aspx
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class CodigoContableRule : ValidationRule
    {
        private int _min;
        private int _max;

        public CodigoContableRule()
        {
            _min = 1;
            _max = 9;
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

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int valorAConvertir = 0;

            try
            {
                if (value.ToString().Length > 0)
                {
                    if (int.TryParse(value.ToString(), out valorAConvertir))
                    {
                        valorAConvertir = int.Parse(value.ToString());
                    }
                    else
                    {
                        return new ValidationResult(false,
                          "Ingrese un valor válido, no letras: ");
                    }
                }
                else
                {
                    return new ValidationResult(false,
                      "Debe ingresar un valor ");
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
    }
}
