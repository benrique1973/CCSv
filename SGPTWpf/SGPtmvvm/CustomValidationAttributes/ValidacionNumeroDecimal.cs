using System;
using System.Globalization;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionNumeroDecimal : ValidationRule
    {
        private Double _valorMayorIgualQue=0;
        public Double ValorMayorIgualQue
        {
            get { return _valorMayorIgualQue; }
            set { _valorMayorIgualQue = value; }
        }

        private Double _valorMenorIgualQue=0;
        public Double ValorMenorIgualQue
        {
            get { return _valorMenorIgualQue; }
            set { _valorMenorIgualQue = value; }
        }

        private bool _soloEnteros = false;
        public bool SoloEnteros
        {
            get { return _soloEnteros; }
            set { _soloEnteros = value; }
        }

        private bool _esRequerido = false;
        public bool EsRequerido
        {
            get { return _esRequerido; }
            set { _esRequerido = value; }
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            NumberStyles style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
            CultureInfo cultura = CultureInfo.CreateSpecificCulture("es-SV");
            decimal numero;
            if (value != null)
            {
                var valueAsString = value.ToString();

                if (valueAsString.Length > 0 && Decimal.TryParse(valueAsString, style, cultura, out numero))
                {
                    if (ValorMayorIgualQue>0)
                    {
                        #region +
                        if (ValorMenorIgualQue > 0)
                        {
                            double dm = Double.Parse(valueAsString);
                            if (dm >= ValorMayorIgualQue && dm <= ValorMenorIgualQue)
                            {
                                return ValidationResult.ValidResult;
                            }
                            else
                            {
                                Message = "Tiempo de reunion erroneo. Rango [ " + ValorMayorIgualQue.ToString() + " ] - [ " + ValorMenorIgualQue.ToString() + " ]";
                            }
                        }
                        else
                        {
                            double dm = Double.Parse(valueAsString);
                            if (dm >= ValorMayorIgualQue)
                            {
                                return ValidationResult.ValidResult;
                            }
                            else
                            {
                                Message = "Tiempo de reunion erroneo. Rango debe ser mayor que [ " + ValorMayorIgualQue.ToString() + " ] ";
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region +
                        if (ValorMenorIgualQue > 0)
                        {
                            double dm = Double.Parse(valueAsString);
                            if (dm <= ValorMenorIgualQue)
                            {
                                return ValidationResult.ValidResult;
                            }
                            else
                            {
                                Message = "Tiempo de reunion erroneo. El valor debe ser menor o igual que: " + ValorMenorIgualQue.ToString();
                            }
                        }
                        else
                        {
                            //Message = "Dato requerido";
                        } 
                        #endregion
                    }
                }
                else 
                {
                    //Message = "Tiempo de reunion erroneo";
                    if (valueAsString.Length == 0)
                    {
                        if (!EsRequerido)
                        {
                            return ValidationResult.ValidResult;
                        }
                        else { Message = "Dato requerido"; }
                    } 
                }
            }
            else
            {
                if (!EsRequerido)
                {
                    return ValidationResult.ValidResult; 
                }
                else { Message = "Dato requerido"; }
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }
    }
}
