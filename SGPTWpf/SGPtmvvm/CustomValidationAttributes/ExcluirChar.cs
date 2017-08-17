using System;
using System.Linq;
using System.Windows.Controls;
namespace SGPTmvvm.CustomValidationAttributes
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ExcluirChar : ValidationRule 
    {
        private bool _esRequerido = false;
        public bool EsRequerido
        {
            get { return _esRequerido; }
            set { _esRequerido = value; }
        }

        private string _caractereslocos= "/.,;[]{}()*-+~^&_=!@#$%1234567890"; //si no se especifica nada, estos tomara por defecto
        public string NoPermitir
        {
            get { return _caractereslocos; }
            set { _caractereslocos= value; }
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            int cuentita = 0;
            if (value != null)
            {
                for (int i = 0; i < NoPermitir.Length; i++)
                {
                    var str = value.ToString();
                    if (str.Contains(NoPermitir[i]))
                    {
                        cuentita++;
                    }    
                }
                if(cuentita==0)
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                if (EsRequerido)
                {/*MessageBox.Show("Es requerido"); //no mensajes*/}
                else { return ValidationResult.ValidResult; }
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }
    }
}