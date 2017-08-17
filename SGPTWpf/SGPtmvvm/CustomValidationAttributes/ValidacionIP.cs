using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionIP : ValidationRule
    {
        private string Permitidosipv6 = "ABCDEFabcdef1234567890"; //permitidos en ipv6
        //public string Permitidosipv6
        //{
        //    get { return _caracterespermitidosipv6; }
        //    set { _caracterespermitidosipv6 = value; }
        //}

        private string Permitidosipv4 = ".1234567890"; //caracteres permitidos en ipv4
        //public string Permitidosipv4
        //{
        //    get { return _caracterespermitidosipv4; }
        //    set { _caracterespermitidosipv4 = value; }
        //}
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            if (value != null)
            {
                var valueAsStringIP = value.ToString();

                if (valueAsStringIP.Length == 19) //Validacion ipv6  // ej: 2001:ODB8:AC10:FE01
                {
                    #region _
                    string primeroscuatro = valueAsStringIP.Substring(0, 4);
                    string p1caracterseparacion = valueAsStringIP.Substring(4, 1);
                    string segundocuatro = valueAsStringIP.Substring(5, 4);
                    string p2caracterseparacion = valueAsStringIP.Substring(9, 1);
                    string tercerocuatro = valueAsStringIP.Substring(10, 4);
                    string p3caracterseparacion = valueAsStringIP.Substring(14, 1);
                    string cuartocuatro = valueAsStringIP.Substring(15, 4);

                    bool p1todosCorrectos = verificarTodoBienipv6(primeroscuatro);//primeroscuatro.All(char.IsDigit);
                    bool p1separadorcorrecto = (p1caracterseparacion == ":" ? true : false);
                    bool p2todosCorrectos = verificarTodoBienipv6(segundocuatro);
                    bool p2separadorcorrecto = (p2caracterseparacion == ":" ? true : false);
                    bool p3todosCorrectos = verificarTodoBienipv6(tercerocuatro);
                    bool p3separadorcorrecto = (p3caracterseparacion == ":" ? true : false);
                    bool p4todosCorrectos = verificarTodoBienipv6(cuartocuatro);

                    if (p1todosCorrectos && p1separadorcorrecto && p2todosCorrectos && p2separadorcorrecto && p3todosCorrectos && p3separadorcorrecto && p4todosCorrectos)
                    {
                        return ValidationResult.ValidResult;
                    } 
                    #endregion
                }
                else //validacion ipv4
                    if (valueAsStringIP.Length >= 7 && valueAsStringIP.Length <= 15) //Ej: 192.168.101.110 otro 10.1.1.1
                    {
                        #region _
                        //if (verificarTodoBienipv4(valueAsStringIP))
                        //{
                        //    string recorte = valueAsStringIP;
                        //    string primerOcteto = "";
                        //    string segundoOcteto = "";
                        //    string tercerOcteto = "";
                        //    string cuartoOcteto = "";
                        //    for (int i = 1; i <= 4; i++) //4 octetos
                        //    {
                        //        #region _
                        //        for (int j = 0; j < 3; j++)
                        //        {
                        //            #region _
                        //            if (i == 1)
                        //            {
                        //                #region _

                        //                //if (verificarTodoBienipv4(recorte.Substring(j, 1)))
                        //                if (recorte.Substring(j, 1) != ".")
                        //                    primerOcteto = primerOcteto + recorte.Substring(j, 1);
                        //                else
                        //                {
                        //                    recorte = recorte.Substring(j + 1, (recorte.Length - (j + 1)));
                        //                    j = 3; //encontro el primer octeto ordeno que se salga
                        //                }
                        //                if (j == 2) //esta es la ultima vez que pasa por aqui
                        //                {
                        //                    recorte = recorte.Substring(j + 1, (recorte.Length - (j + 1)));
                        //                }
                        //                #endregion
                        //            }
                        //            if (i == 2) //10.1.1.1
                        //            {
                        //                #region _
                        //                //segundoOcteto = "";
                        //                //if (verificarTodoBienipv4(recorte.Substring(j, 1))) 19.197.
                        //                if (recorte.Length >= 5)
                        //                {
                        //                    string caracter = recorte.Substring(j, 1);
                        //                    if (caracter != ".")
                        //                        segundoOcteto = segundoOcteto + caracter;
                        //                    else
                        //                    {
                        //                        recorte = recorte.Substring(j + 1, recorte.Length - (j + 1));
                        //                        j = 3; //encontro el segundo octeto ordeno que se salga
                        //                    }
                        //                    if (j == 2) //esta es la ultima vez que pasa por aqui
                        //                    {
                        //                        recorte = recorte.Substring(j + 1, (recorte.Length - (j + 1)));
                        //                    }
                        //                }
                        //                #endregion
                        //            }
                        //            if (i == 3)
                        //            {
                        //                #region _
                        //                //tercerOcteto = "0";
                        //                //if (verificarTodoBienipv4(recorte.Substring(j, 1)))
                        //                if (recorte.Length >= 3)
                        //                {
                        //                    if (recorte.Substring(j, 1) != ".")
                        //                        tercerOcteto = tercerOcteto + recorte.Substring(j, 1);
                        //                    else
                        //                    {
                        //                        recorte = recorte.Substring(j + 1, recorte.Length - (j + 1));
                        //                        j = 3; //encontro el segundo octeto ordeno que se salga
                        //                    }
                        //                    if (j == 2) //esta es la ultima vez que pasa por aqui
                        //                    {
                        //                        recorte = recorte.Substring(j + 1, (recorte.Length - (j + 1)));
                        //                    }
                        //                }
                        //                #endregion
                        //            }
                        //            if (i == 4)
                        //            {
                        //                #region _
                        //                if (recorte.Substring(j, 1) != ".")
                        //                    cuartoOcteto = cuartoOcteto + recorte.Substring(j, 1);
                        //                else
                        //                {
                        //                    recorte = recorte.Substring(j + 1, recorte.Length - cuartoOcteto.Length);
                        //                    j = 3; //encontro el segundo octeto ordeno que se salga
                        //                    if (recorte.Length == 0) i = 5;
                        //                }
                        //                if (j == 2) //esta es la ultima vez que pasa por aqui
                        //                {
                        //                    recorte = recorte.Substring(j + 1, (recorte.Length - (j + 1)));
                        //                }
                        //                #endregion
                        //            }
                        //            #endregion
                        //        }
                        //        #endregion
                        //    }
                        //    if (primerOcteto.Length == 0) primerOcteto = "0";
                        //    if (segundoOcteto.Length == 0) segundoOcteto = "0";
                        //    if (tercerOcteto.Length == 0) tercerOcteto = "0";
                        //    if (cuartoOcteto.Length == 0) cuartoOcteto = "0";

                        //    if (int.Parse(primerOcteto) > 10 && int.Parse(primerOcteto) < 256 && int.Parse(segundoOcteto) > 10 && int.Parse(segundoOcteto) < 256 && int.Parse(tercerOcteto) > 10 && int.Parse(tercerOcteto) < 256 && int.Parse(cuartoOcteto) > 10 && int.Parse(cuartoOcteto) < 256)
                        //        return ValidationResult.ValidResult;
                        //} 
                        #endregion

                       
                        //IPAddress address; // = IPAddress.Parse(valueAsStringIP);
                        //bool sd = IPAddress.TryParse(valueAsStringIP, out address);

                        //if (IPAddress.TryParse(valueAsStringIP, out address))
                        //return ValidationResult.ValidResult;

                        if (esIPv4Valida(valueAsStringIP))
                        { return ValidationResult.ValidResult; };
                    }
            }
           // else
            //{
            //    return ValidationResult.ValidResult;
            //}
            Message = "La Ip que introdujo no es real";
            return new ValidationResult(false, Message);
        }

        private bool esIPv4Valida(string StringIP)
        {
            string[] arrOctets = StringIP.Split('.');
            if (arrOctets.Length != 4)
            {
                return false;
            }
            //  Comprobar cada subcadena g checking that the int value is less than 255 and that is char[] length is !> 2
            Int16 MAXVALUE = 255;
            Int32 temp; // Parse retorna Int32
            foreach (String strOctet in arrOctets)
            {
                if (strOctet.Length > 3)
                {
                    return false;
                }

                if (!string.IsNullOrEmpty(strOctet))
                {
                    try
                    {
                        temp = int.Parse(strOctet);
                        if (temp > MAXVALUE)
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;  
                    } 
                }
                else { return false; }
            }
            IPAddress address; 

            if (!IPAddress.TryParse(StringIP, out address))
                return false;

            return true;
        }

        private bool verificarTodoBienipv6(string losCuatro) //Ipv6
        {
            int cuentita = 0;
            for (int i = 0; i < losCuatro.Length; i++)
            {
                var str = losCuatro;
                var b = losCuatro.Substring(i, 1);
                if (Permitidosipv6.Contains(b))//if (str.Contains(Permitidosipv6[i]))
                {
                    cuentita++;
                }
            }
            if (cuentita == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool verificarTodoBienipv4(string losCuatro) //Ipv4
        {
            int cuentita = 0;
            for (int i = 0; i < losCuatro.Length; i++)
            {
                var str = losCuatro;
                var a = losCuatro.Substring(i, 1);
                if (Permitidosipv4.Contains(a))
                {
                    //cuentita++;
                }
                else
                {
                    cuentita++;
                }
            }
            if (cuentita > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public String Message { get; set; }
    }
}
