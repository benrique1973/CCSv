using System;
using System.Globalization;
using System.Windows.Controls;
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class DateBalanceRule : ValidationRule
    {
        private DateTime _fechalimiteInicial;
        private DateTime _fechaLimiteFinal;

        public DateBalanceRule()
        {
            _fechalimiteInicial = new DateTime((DateTime.Now.Year - 2), 1, 1);
            _fechaLimiteFinal = DateTime.Now.AddYears(2);
        }

        public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
        {
            DateTime valorAConvertir = DateTime.Now;
            _fechaLimiteFinal = DateTime.Now.AddYears(2);
            _fechalimiteInicial= new DateTime((DateTime.Now.Year - 2), 1, 1);
            try
            {
                if (value.ToString().Length > 0)
                {
                    valorAConvertir = DateTime.Parse(value.ToString(), CultureInfo.CurrentCulture);
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "No es una fecha válida");
            }

            if ((valorAConvertir < _fechalimiteInicial) || (valorAConvertir > _fechaLimiteFinal))
            {
                return new ValidationResult(false,
                  "Por favor ingrese fechas en el siguiente rango: " + _fechalimiteInicial.ToShortDateString() + " - " + _fechaLimiteFinal.ToShortDateString() + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
