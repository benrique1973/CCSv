using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionHorasMinutos : ValidationRule
    {
        private bool _esRequerido = false;
        public bool EsRequerido
        {
            get { return _esRequerido; }
            set { _esRequerido = value; }
        }

        private string _valorMinutox="";
        public string ValorMinutox
        {
            get { return _valorMinutox; }
            set { _valorMinutox = value; }
        }

        private string _valorHorax="";
        public string ValorHorax
        {
            get { return _valorHorax; }
            set { _valorHorax = value; }
        }

        private int queEs;
        public int Quees
        {
            get { return queEs; }
            set { queEs = value; }
        }


        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            //int ValorMinutos = int.Parse(value.ToString()); //es la replicacion de la contraseña.
            //string ValorMinutos = value.ToString();
            //int ValorHorass = ValorHoras;



            if (value != null)
            {

                string ValorMinutos="0";
                string ValorHoras="0";
                if (Quees == 1) //el campo actual es horas tratando de validarse. Entonces los minutos vienen como parametro
                {
                    ValorHoras = value.ToString();
                    ValorMinutos = ValorMinutox;
                }
                if (Quees == 2) //el campo actual es minutos tratando de validarse. Entonces las horas vienen como parametro
                {
                    ValorMinutos = value.ToString();
                    ValorHoras = ValorHorax;
                }

                if(string.IsNullOrEmpty(ValorMinutos))
                    ValorMinutos="0";

                //string ValorHorass = ValorHoras;
                if (string.IsNullOrEmpty(ValorHoras))
                    ValorHoras = "0";


                bool sonTodosDigitosMin = ValorMinutos.All(char.IsDigit);
                bool sonTodosDigitosHor = ValorHoras.All(char.IsDigit);
                //if (sonTodosDigitos)
                //{
                //    return ValidationResult.ValidResult;
                //}

                if (sonTodosDigitosHor && sonTodosDigitosMin)
                {
                        decimal vall = int.Parse(ValorHoras) + (decimal.Parse(ValorMinutos) / 60);
                        if (vall <= 8)
                        {
                            return ValidationResult.ValidResult;
                        }
                        else
                        {
                            Message = "Error. Maximo 8 horas por dia laboral";
                        }  
                }
                else
                {
                    if (EsRequerido)
                    { /*MessageBox.Show("Es requerido"); //no mensajes*/ Message = "Dato requerido"; }
                    else { return ValidationResult.ValidResult; }
                }
            }
            else
            {
                if (EsRequerido)
                { /*MessageBox.Show("Es requerido"); //no mensajes*/ Message="Dato requediro";}
                else { return ValidationResult.ValidResult; }
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }
    }
}
