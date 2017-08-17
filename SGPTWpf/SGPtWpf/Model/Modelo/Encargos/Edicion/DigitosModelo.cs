using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public class DigitosModelo : UIBase
    {

        [DisplayName("Código elemento")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 10, ErrorMessage = "El tamaño es de 1 a 9")]
        [RegularExpression(@"^[1-9]{1,10}$", ErrorMessage = "Deben ser números del 1  al 9 ")]
        public int? idDigitosModelo //correlativo
        {
            get { return GetValue(() => idDigitosModelo); }
            set { SetValue(() => idDigitosModelo, value); }
        }

        #region Public Model Methods

        public static List<DigitosModelo> GetAll()
        {
            var lista = new ObservableCollection<DigitosModelo>();
                for (int i=1;i<12;i++)
            {
                lista.Add(new DigitosModelo
                {
                    idDigitosModelo = i,
                });
            }
            return lista.OrderBy(x => x.idDigitosModelo).ToList();
        }
        #endregion

        #region Filtro
        public DigitosModelo(int digitos)
        {
            idDigitosModelo = digitos;
        }
        public DigitosModelo()
        {
            idDigitosModelo = 0;
        }

        public DigitosModelo(int? codigoelemento)
        {
            this.idDigitosModelo = codigoelemento;
        }

        //https://msdn.microsoft.com/es-es/library/hf9z3s65(v=vs.110).aspx
        public void ConvertStringDecimal(string stringVal)
        {
            decimal decimalVal = 0;

            try
            {
                decimalVal = System.Convert.ToDecimal(stringVal);
                System.Console.WriteLine(
                    "The string as a decimal is {0}.", decimalVal);
            }
            catch (System.OverflowException)
            {
                System.Console.WriteLine(
                    "The conversion from string to decimal overflowed.");
            }
            catch (System.FormatException)
            {
                System.Console.WriteLine(
                    "The string is not formatted as a decimal.");
            }
            catch (System.ArgumentNullException)
            {
                System.Console.WriteLine(
                    "The string is null.");
            }

            // Decimal to string conversion will not overflow.
            stringVal = System.Convert.ToString(decimalVal);
            System.Console.WriteLine(
                "The decimal as a string is {0}.", stringVal);
        }
        #endregion
    }
}
