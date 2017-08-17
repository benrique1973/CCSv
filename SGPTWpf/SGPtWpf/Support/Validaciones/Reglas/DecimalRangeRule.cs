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
    public class DecimalRangeRule : ValidationRule
    {
        private decimal _min;
        private decimal _max;
        private string _valor;
        private string _valorEvaluar;
        public DecimalRangeRule()
        {
            _valor = "";
            _valorEvaluar = "";
        }

        public decimal Min
        {
            get { return _min; }
            set { _min = value; }
        }

        public decimal Max
        {
            get { return _max; }
            set { _max = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal valorAConvertir = 0;
            NumberStyles style;
            CultureInfo provider;
            _valor = "";
            _valorEvaluar = "";
            try
            {
                style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                provider = CultureInfo.CurrentCulture;
                //https://msdn.microsoft.com/es-sv/library/s84kdbzx(v=vs.110).aspx
                //number = Decimal.Parse(value, style, provider);
                if (value.ToString().Length > 0)
                {
                    if (value.ToString().Contains("US$"))
                    {
                        _valor = value.ToString().Remove(1, 3);
                    }
                    else
                    {
                        _valor = value.ToString();
                    }
                    for (int i = 0; i < _valor.Length; i++)
                    {
                        switch (_valor[i].ToString())
                        {
                            case " ":
                                break;
                            case ",":
                                break;
                            default:
                                _valorEvaluar = _valorEvaluar + _valor[i];
                                break;
                        }
                    }
                    //valorAConvertir = decimal.Parse(value.ToString());
                    valorAConvertir = decimal.Parse(_valorEvaluar, style, provider)/100;
                }
                else
                {
                    return new ValidationResult(false, "Debe ingresar un valor");
                }
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
        }
    }
}
