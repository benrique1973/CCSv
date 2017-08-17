using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
//Agrupa reglas de validacion
//https://msdn.microsoft.com/en-us/library/system.windows.data.binding.updatesourceexceptionfilter(v=vs.110).aspx

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class DateRangeRule : ValidationRule
    {
        private DateTime _min;
        private DateTime _max;

        public DateRangeRule()
        {
        }

        public DateTime Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public DateTime Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
        {
            DateTime valorAConvertir = DateTime.Now;

            try
            {
                if (((string)value).Length > 0)
                    //valorAConvertir = DateTime.Parse(value.ToString());
                    valorAConvertir = DateTime.Parse(value.ToString(), CultureInfo.CurrentCulture);
            }
            catch (Exception )
            {
                return new ValidationResult(false, "No es una fecha válida");
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
