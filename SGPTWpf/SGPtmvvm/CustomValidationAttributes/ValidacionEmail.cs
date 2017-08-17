using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionEmail : ValidationRule
    {
        bool invalido = false;
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                var strCorreo = value.ToString();
                if (strCorreo.Length == 0)
                    return ValidationResult.ValidResult;
                if (EsValidoElEmail(strCorreo))
                {
                    return ValidationResult.ValidResult;
                }
                else if (strCorreo.Length == 0) { return ValidationResult.ValidResult; }
            }
            else
            {
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }


        /******************************************************************/
        public bool EsValidoElEmail(string correitoIn)
        {
            invalido = false;
            if (String.IsNullOrEmpty(correitoIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                correitoIn = Regex.Replace(correitoIn, @"(@)(.+)$", this.DominioMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalido)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(correitoIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        /******************************************************************/

        private string DominioMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string NombreDominio = match.Groups[2].Value;
            try
            {
                NombreDominio = idn.GetAscii(NombreDominio);
            }
            catch (ArgumentException)
            {
                invalido = true;
            }
            return match.Groups[1].Value + NombreDominio;
        }
    }


}

