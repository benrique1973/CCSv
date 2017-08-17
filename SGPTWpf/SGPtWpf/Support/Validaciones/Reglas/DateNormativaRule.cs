using System;
using System.Globalization;
using System.Windows.Controls;
namespace SGPTWpf.SGPtWpf.Support.Validaciones.Reglas
{
    public class DateNormativaRule : ValidationRule
    {
        private DateTime _fechalimiteInicial;
        private DateTime _fechaLimiteFinal;

        public DateNormativaRule()
        {
            _fechalimiteInicial = new DateTime((DateTime.Now.Year - 60), 1, 1);
            _fechaLimiteFinal = DateTime.Now.AddYears(2);

        }

        public override ValidationResult Validate(object value, CultureInfo CurrentCulture)
        {
            DateTime valorAConvertir = DateTime.Now;

            try
            {
                if (((string)value).Length > 0)
                    valorAConvertir = DateTime.Parse(value.ToString(), CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return new ValidationResult(false, "No es una fecha válida");
            }

            if ((valorAConvertir < _fechalimiteInicial) || (valorAConvertir > _fechaLimiteFinal))
            {
                return new ValidationResult(false,
                  "Por favor ingrese fechas en el siguiente rango: " + _fechalimiteInicial.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + " - " + _fechaLimiteFinal.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture) + ".");
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}


