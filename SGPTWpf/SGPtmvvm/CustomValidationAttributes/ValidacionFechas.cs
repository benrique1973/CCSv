using System;
using System.Globalization;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionFechas : ValidationRule
    {
        //private DateTime _FechaMayorIgualQue=DateTime.Now.AddYears(-100);
        //public DateTime FechaMayorIgualQue
        //{
        //    get { return _FechaMayorIgualQue; }
        //    set { _FechaMayorIgualQue = value; }
        //}

        //private DateTime _FechaMenorIgualQue = DateTime.Now.AddYears(-100);
        //public DateTime FechaMenorIgualQue
        //{
        //    get { return _FechaMenorIgualQue; }
        //    set { _FechaMenorIgualQue = value; }
        //}

        private DateTime _fechaInicial;
        public DateTime FechaInicial
        {
            get { return _fechaInicial; }
            set { _fechaInicial = value; }
        }

        private DateTime _fechaFinal;
        public DateTime FechaFinal
        {
            get { return _fechaFinal; }
            set { _fechaFinal = value; }
        }

        private int queEs;
        public int Quees
        {
            get { return queEs; }
            set { queEs = value; }
        }

        private bool _esRequerido = false;
        public bool EsRequerido
        {
            get { return _esRequerido; }
            set { _esRequerido = value; }
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                DateTime FechaInicialx=DateTime.Now;
                DateTime FechaFinalx=DateTime.Now;
                var valueAsString = value.ToString();
                DateTime dm = DateTime.Parse(value.ToString());
                if (queEs == 1)
                {
                    FechaInicialx = DateTime.Parse(value.ToString());
                    FechaFinalx = FechaFinal;
                }
                if (Quees == 2)
                {
                    FechaFinalx = DateTime.Parse(value.ToString());
                    FechaInicialx = FechaInicial;
                }

                if (valueAsString.Length > 0)
                {
                    if (FechaInicialx<=DateTime.Now && FechaFinalx<=DateTime.Now)//FechaMayorIgualQue != DateTime.Now.AddYears(-100))//(!string.IsNullOrEmpty(FechaMayorIgualQue.ToShortDateString()) && validarFechaCorrecta(FechaMayorIgualQue))
                    {
                        //DateTime ValorMayorIgualQue = FechaMayorIgualQue; // DateTime.Parse(FechaMayorIgualQue);
                        #region +
                        if (FechaInicialx<=FechaFinalx)  //(!string.IsNullOrEmpty(FechaMenorIgualQue) && validarFechaCorrecta(FechaMenorIgualQue))//(ValorMenorIgualQue > 0)
                        {
                            return ValidationResult.ValidResult;
                        }
                        else
                        {
                           Message = "Fecha inicial debe ser MENOR o IGUAL que la fecha final";
                        }

                        #endregion
                    }
                    else
                    {
                        Message = "La fecha inicial y la fecha final no pueden ser mayor que la fecha actual";
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

        #region +
        //public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        //{
        //    if (value != null)
        //    {
        //        var valueAsString = value.ToString();
        //        DateTime dm = DateTime.Parse(value.ToString());
        //        if (valueAsString.Length > 0)
        //        {
        //            if (FechaMayorIgualQue != DateTime.Now.AddYears(-100))//(!string.IsNullOrEmpty(FechaMayorIgualQue.ToShortDateString()) && validarFechaCorrecta(FechaMayorIgualQue))
        //            {
        //                DateTime ValorMayorIgualQue = FechaMayorIgualQue; // DateTime.Parse(FechaMayorIgualQue);
        //                #region +
        //                if (FechaMenorIgualQue != DateTime.Now.AddYears(-100))  //(!string.IsNullOrEmpty(FechaMenorIgualQue) && validarFechaCorrecta(FechaMenorIgualQue))//(ValorMenorIgualQue > 0)
        //                {
        //                    //double dm = Double.Parse(valueAsString);
        //                    DateTime ValorMenorIgualQue = FechaMenorIgualQue; //DateTime.Parse(FechaMenorIgualQue);

        //                    if (dm >= ValorMayorIgualQue && dm <= ValorMenorIgualQue)
        //                    {
        //                        return ValidationResult.ValidResult;
        //                    }
        //                    else
        //                    {
        //                        Message = "Fecha erronea. Rango [ " + ValorMayorIgualQue.ToShortDateString() + " ] - [ " + ValorMenorIgualQue.ToShortDateString() + " ]";
        //                    }
        //                }
        //                else
        //                {
        //                    if (dm >= ValorMayorIgualQue)
        //                    {
        //                        return ValidationResult.ValidResult;
        //                    }
        //                    else
        //                    {
        //                        Message = "Fecha erronea. Rango [ >= " + ValorMayorIgualQue.ToShortDateString() + " ]";
        //                    }
        //                }

        //                #endregion
        //            }
        //            else
        //            {
        //                #region +
        //                DateTime ValorMenorIgualQue = FechaMenorIgualQue; // DateTime.Parse(FechaMenorIgualQue);
        //                if (FechaMenorIgualQue != DateTime.Now.AddYears(-100)) //(!string.IsNullOrEmpty(FechaMenorIgualQue) && validarFechaCorrecta(FechaMenorIgualQue))//(ValorMenorIgualQue > 0)
        //                {
        //                    if (dm <= ValorMenorIgualQue)
        //                    {
        //                        return ValidationResult.ValidResult;
        //                    }
        //                    else
        //                    {
        //                        Message = "Fecha erronea. Rango [ < " + ValorMenorIgualQue.ToShortDateString() + " ]";
        //                    }
        //                }
        //                else
        //                {
        //                    Message = "Dato requerido";
        //                }
        //                #endregion
        //            }
        //        }
        //        else
        //        {
        //            //Message = "Tiempo de reunion erroneo";
        //            if (valueAsString.Length == 0)
        //            {
        //                if (!EsRequerido)
        //                {
        //                    return ValidationResult.ValidResult;
        //                }
        //                else { Message = "Dato requerido"; }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (!EsRequerido)
        //        {
        //            return ValidationResult.ValidResult;
        //        }
        //        else { Message = "Dato requerido"; }
        //    }
        //    return new ValidationResult(false, Message);
        //} 
        #endregion

        //private bool validarFechaCorrecta(string FechaRecibida)
        //{
        //    DateTime dateValue;
        //    if (DateTime.TryParse(FechaRecibida, out dateValue))
        //        return true;
        //    return false;
        //}
        public String Message { get; set; }
    }
}