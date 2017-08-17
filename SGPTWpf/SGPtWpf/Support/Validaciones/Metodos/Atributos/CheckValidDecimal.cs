using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Atributos
{
    public class CheckValidDecimal : ValidationAttribute
    {
        public CheckValidDecimal()
        {
            ErrorMessage = "El dato ingresado no es un número válido";
        }

        public override bool IsValid(object value)
        {
            decimal convertedDecimal;
            if (value == null)
            {
                return false;
            }
            else
            {
                try
                {
                    if ((value.ToString()).Length > 0)
                    {
                        convertedDecimal = decimal.Parse(value.ToString());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
    }


}
