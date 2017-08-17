using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;

namespace SGPTWpf.SGPtWpf.Support.Validaciones.Metodos
{
    class MetodosModelo
    {
        public static DateTime conversionFechas(string fechaAConvertir, int i)
        {
        bool isValidFechainiperauditencargo=false;
        DateTime temporalInicio= new DateTime();
        switch (i)
            {
            case 1:
                    isValidFechainiperauditencargo = DateTime.TryParseExact(
                    fechaAConvertir,
                    "dd/MM/yyyy",
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out temporalInicio);
                    break;
            case 2:
                    isValidFechainiperauditencargo = DateTime.TryParseExact(
                    fechaAConvertir,
                    "d/M/yyyy",
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out temporalInicio);
                    break;
            case 3:
                    isValidFechainiperauditencargo = DateTime.TryParseExact(
                    fechaAConvertir,
                    "dd/M/yyyy",
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out temporalInicio);
                    break;
            case 4:
                    isValidFechainiperauditencargo = DateTime.TryParseExact(
                    fechaAConvertir,
                    "d/MM/yyyy",
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out temporalInicio);
                    break;
            }
            if (isValidFechainiperauditencargo)
            {
                return temporalInicio;
            }
            else
            {
                return temporalInicio;
            }
        }
        public static int validadConversionFechas(string fechaAConvertir)
        {
            DateTime temporalInicio;
            bool isValidFechainiperauditencargo = DateTime.TryParseExact(
            fechaAConvertir,
            "dd/MM/yyyy",
            CultureInfo.CurrentCulture,
            DateTimeStyles.None, out temporalInicio);
            if (!isValidFechainiperauditencargo)
            {
                isValidFechainiperauditencargo = DateTime.TryParseExact(
                fechaAConvertir,
                "d/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, out temporalInicio);
                if (!isValidFechainiperauditencargo)
                {
                    isValidFechainiperauditencargo = DateTime.TryParseExact(
                    fechaAConvertir,
                    "dd/M/yyyy",
                    CultureInfo.CurrentCulture,
                    DateTimeStyles.None, out temporalInicio);
                    if (!isValidFechainiperauditencargo)
                    {
                        isValidFechainiperauditencargo = DateTime.TryParseExact(
                        fechaAConvertir,
                        "d/MM/yyyy",
                        CultureInfo.CurrentCulture,
                        DateTimeStyles.None, out temporalInicio);
                        if (!isValidFechainiperauditencargo)
                        {
                            return 0;
                        }
                        else
                        {
                            return 4;
                        }
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 1;
            }

        }
        public static DateTime convertirFecha(string fecha)
        {
            try
            {
                string fechaSaliente = "";
                string fechatemporal = "";
                string dias;
                string mes;
                string anual;
                int fin = fecha.IndexOf(" ");
                if (!(fin == -1))
                {
                    fechaSaliente = fecha.Substring(0, fin);//Se trunca la fecha
                }
                else
                {
                    fechaSaliente = fecha;//Se trunca la fecha
                }
                fin = fecha.IndexOf("/");
                if (!(fin == -1)&& fecha.Length>=8)
                {
                    dias = fecha.Substring(0, fin);//Se trunca la fecha
                    fechatemporal = fecha.Substring(fin+1, fecha.Length - fin-1);
                    fin = fechatemporal.IndexOf("/");
                    mes = fechatemporal.Substring(0, fin);//Se trunca para el mes
                    anual = fechatemporal.Substring(fin+1, 4);

                    if (dias.Length == 1)
                    {
                        dias = "0" + dias;
                    }
                    if (mes.Length == 1)
                    {
                        mes = "0" + mes;
                    }
                    if (int.Parse(mes) > 12)
                    {
                        fechaSaliente = mes + "/" + dias + "/" + anual;
                    }
                    else
                    { 
                        fechaSaliente = dias + "/" + mes + "/" + anual;
                    }
                }
                else
                {
                    fechaSaliente = fecha;//No se trunca la fecha
                }
                return MetodosModelo.conversionFechas(fechaSaliente, 1);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la conversión de la fecha", "");
                return new DateTime((DateTime.Now.Year - 1), 12, 31);
            }
        }

        public static string homologacionFecha(string fecha)
        {
            try
            {
                string fechaSaliente = "";
                string fechatemporal = "";
                string dias;
                string mes;
                string anual;
                int fin = fecha.IndexOf(" ");
                if (!(fin == -1))
                {
                    fechaSaliente = fecha.Substring(0, fin);//Se trunca la fecha
                }
                else
                {
                    fechaSaliente = fecha;//Se trunca la fecha
                }
                fin = fecha.IndexOf("/");
                if (!(fin == -1) && fecha.Length >= 8)
                {
                    dias = fecha.Substring(0, fin);//Se trunca la fecha
                    fechatemporal = fecha.Substring(fin + 1, fecha.Length - fin - 1);
                    fin = fechatemporal.IndexOf("/");
                    mes = fechatemporal.Substring(0, fin);//Se trunca para el mes
                    anual = fechatemporal.Substring(fin + 1, 4);

                    if (dias.Length == 1)
                    {
                        dias = "0" + dias;
                    }
                    if (mes.Length == 1)
                    {
                        mes = "0" + mes;
                    }
                    if (int.Parse(mes) > 12)
                    {
                        fechaSaliente = mes + "/" + dias + "/" + anual;
                    }
                    else
                    {
                        fechaSaliente = dias + "/" + mes + "/" + anual;
                    }
                }
                else
                {
                    fechaSaliente = fecha;//No se trunca la fecha
                }
                return fechaSaliente;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la conversión de la fecha", "");
                return fecha;
            }
        }
        public static string homologacionFecha()
        {
            string fecha = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            try
            {
                string fechaSaliente = "";
                string fechatemporal = "";
                string dias;
                string mes;
                string anual;
                int fin = fecha.IndexOf(" ");
                if (!(fin == -1))
                {
                    fechaSaliente = fecha.Substring(0, fin);//Se trunca la fecha
                }
                else
                {
                    fechaSaliente = fecha;//Se trunca la fecha
                }
                fin = fecha.IndexOf("/");
                if (!(fin == -1) && fecha.Length >= 8)
                {
                    dias = fecha.Substring(0, fin);//Se trunca la fecha
                    fechatemporal = fecha.Substring(fin + 1, fecha.Length - fin - 1);
                    fin = fechatemporal.IndexOf("/");
                    mes = fechatemporal.Substring(0, fin);//Se trunca para el mes
                    anual = fechatemporal.Substring(fin + 1, 4);

                    if (dias.Length == 1)
                    {
                        dias = "0" + dias;
                    }
                    if (mes.Length == 1)
                    {
                        mes = "0" + mes;
                    }
                    if (int.Parse(mes) > 12)
                    {
                        fechaSaliente = mes + "/" + dias + "/" + anual;
                    }
                    else
                    {
                        fechaSaliente = dias + "/" + mes + "/" + anual;
                    }
                }
                else
                {
                    fechaSaliente = fecha;//No se trunca la fecha
                }
                return fechaSaliente;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la conversión de la fecha", "");
                return fecha;
            }
        }

        public static DateTime FechaHoy()
        {
            string fecha = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            try
            {
                string fechaSaliente = "";
                string fechatemporal = "";
                string dias;
                string mes;
                string anual;
                int fin = fecha.IndexOf(" ");
                if (!(fin == -1))
                {
                    fechaSaliente = fecha.Substring(0, fin);//Se trunca la fecha
                }
                else
                {
                    fechaSaliente = fecha;//Se trunca la fecha
                }
                fin = fecha.IndexOf("/");
                if (!(fin == -1) && fecha.Length >= 8)
                {
                    dias = fecha.Substring(0, fin);//Se trunca la fecha
                    fechatemporal = fecha.Substring(fin + 1, fecha.Length - fin - 1);
                    fin = fechatemporal.IndexOf("/");
                    mes = fechatemporal.Substring(0, fin);//Se trunca para el mes
                    anual = fechatemporal.Substring(fin + 1, 4);

                    if (dias.Length == 1)
                    {
                        dias = "0" + dias;
                    }
                    if (mes.Length == 1)
                    {
                        mes = "0" + mes;
                    }
                    if (int.Parse(mes) > 12)
                    {
                        fechaSaliente = mes + "/" + dias + "/" + anual;
                    }
                    else
                    {
                        fechaSaliente = dias + "/" + mes + "/" + anual;
                    }
                }
                else
                {
                    fechaSaliente = fecha;//No se trunca la fecha
                }
                return convertirFecha(fechaSaliente);
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la conversión de la fecha", "");
                return convertirFecha(fecha);
            }
        }


        #region gestion del orden de presentacion

        public static string ordenConversion(string orden)
        {
            if (string.IsNullOrEmpty(orden))
            {
                return orden;
            }
            else
            {
                if (orden.IndexOf(".") == -1)
                {
                    return orden;
                }
                else
                {
                    string temporal = orden;
                    for (int i = orden.Length; i > orden.IndexOf("."); i--)
                    {
                        if (orden.Substring(i - 1, 1) == "0")
                        {
                            //Continua
                        }
                        else
                        {
                            temporal = orden.Substring(0, i);
                            i = -1;
                        }
                    }
                    return temporal;
                }
            }
        }
        public static string ordenConversion(int ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }
        public static string ordenConversion(decimal ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }
        public static string ordenConversion(double ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }
        public static string ordenConversion(decimal? ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }

        #endregion

        #region Determinacion del factor de orden

        public static decimal factorHijo(string claseProcedimiento)
        {
            decimal respuesta =(decimal) 0.1;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "PROCEDIMIENTO":
                    respuesta = (decimal)0.1;
                    break;
                case "PREGUNTA":
                    respuesta = (decimal)0.1;
                    break;
                case "OBJETIVO":
                    respuesta = (decimal)0.1;
                    break;
                case "TITULO":
                    respuesta = (decimal)0.1;
                    break;
                case "INDICACIONES":
                    respuesta = (decimal)0.1;
                    break;
                case "ALCANCE":
                    respuesta = (decimal)0.1;
                    break;
                case "SUB-SUB-TITULO":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-TITULO":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-INDICACIONES":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-INDICACIONES":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-PROCEDIMIENTO":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-PROCEDIMIENTO":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-PREGUNTA":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-OBJETIVO":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-OBJETIVO":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-ALCANCE":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-ALCANCE":
                    respuesta = (decimal)0.0001;
                    break;
            }
            return respuesta;
        }

        public static decimal factorPadre(string claseProcedimiento)
        {
            decimal respuesta = (decimal)0.1;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "PROCEDIMIENTO":
                    respuesta = (decimal)0.01;
                    break;
                case "PREGUNTA":
                    respuesta = (decimal)0.01;
                    break;
                case "OBJETIVO":
                    respuesta = (decimal)0.01;
                    break;
                case "TITULO":
                    respuesta = (decimal)0.01;
                    break;
                case "INDICACIONES":
                    respuesta = (decimal)0.01;
                    break;
                case "ALCANCE":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-TITULO":
                    respuesta = (decimal)0.00001;
                    break;
                case "SUB-TITULO":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-SUB-INDICACIONES":
                    respuesta = (decimal)0.00001;
                    break;
                case "SUB-INDICACIONES":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-PROCEDIMIENTO":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-SUB-PROCEDIMIENTO":
                    respuesta = (decimal)0.00001;
                    break;
                case "SUB-PREGUNTA":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-OBJETIVO":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-SUB-OBJETIVO":
                    respuesta = (decimal)0.00001;
                    break;
                case "SUB-ALCANCE":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-SUB-ALCANCE":
                    respuesta = (decimal)0.00001;
                    break;
            }
            return respuesta;
        }


        public static bool correccionOrden(string claseProcedimiento)
        {
            bool respuesta = false;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "PROCEDIMIENTO":
                    respuesta = false;
                    break;
                case "PREGUNTA":
                    respuesta = false;
                    break;
                case "OBJETIVO":
                    respuesta = false;
                    break;
                case "TITULO":
                    respuesta = false;
                    break;
                case "INDICACIONES":
                    respuesta = false;
                    break;
                case "ALCANCE":
                    respuesta = false;
                    break;
                default:
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public static bool correccionOrdenIndice(string claseProcedimiento)
        {
            bool respuesta = false;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "CEDULAS":
                    respuesta = false;
                    break;
                case "CÉDULA":
                    respuesta = false;
                    break;
                case "ANALITICA":
                    respuesta = false;
                    break;
                case "ANÁLITICA":
                    respuesta = false;
                    break;
                case "ARCHIVO":
                    respuesta = false;
                    break;
                default:
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public static bool correccionOrdenCatogo(string claseProcedimiento)
        {
            bool respuesta = false;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "ELEMENTOS":
                    respuesta = false;
                    break;
                case "ELEMENTO":
                    respuesta = false;
                    break;
                //case "Rubros":
                //    respuesta = false;
                //    break;
                //case "Cuentas de mayor":
                //    respuesta = false;
                //    break;
                //case "Sub-Cuenta":
                //    respuesta = false;
                //    break;
                //case "Cuenta de detalle":
                //    respuesta = false;
                //    break;
                default:
                    respuesta = true;
                    break;
            }
            return respuesta;
        }

        public static decimal factorPadreCatalogo(string claseProcedimiento)
        {
            decimal respuesta = (decimal)1;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "ELEMENTO":
                    respuesta = (decimal)10000;
                    break;
                case "ELEMENTOS":
                    respuesta = (decimal)10000;
                    break;
                case "RUBRO":
                    respuesta = (decimal)1000;
                    break;
                case "RUBROS":
                    respuesta = (decimal)1000;
                    break;
                case "CUENTAS":
                    respuesta = (decimal)100;
                    break;
                case "CUENTA":
                    respuesta = (decimal)100;
                    break;
                case "SUB-CUENTA":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-CUENTA":
                    respuesta = (decimal)0.00001;
                    break;
                case "SUB-SUB-SUB-CUENTA":
                    respuesta = (decimal)0.0000001;
                    break;
                case "SUB-CUENTAS":
                    respuesta = (decimal)0.01;
                    break;
                case "SUB-SUB-CUENTAS":
                    respuesta = (decimal)0.00001;
                    break;
                case "SUB-SUB-SUB-CUENTAS":
                    respuesta = (decimal)0.0000001;
                    break;
            }
            return respuesta;
        }

        public static decimal factorHijoCatalogo(string claseProcedimiento)
        {
            decimal respuesta = (decimal)10;
            switch (claseProcedimiento.ToUpper().Trim())
            {
                case "ELEMENTO":
                    respuesta = (decimal)100000;
                    break;
                case "ELEMENTOS":
                    respuesta = (decimal)100000;
                    break;
                case "RUBRO":
                    respuesta = (decimal)10000;
                    break;
                case "RUBROS":
                    respuesta = (decimal)10000;
                    break;
                case "CUENTAS":
                    respuesta = (decimal)1000;
                    break;
                case "CUENTA":
                    respuesta = (decimal)1000;
                    break;
                case "SUB-CUENTA":
                    respuesta = (decimal)0.1;
                    break;
                case "SUB-SUB-CUENTA":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-SUB-SUB-CUENTA":
                    respuesta = (decimal)0.000001;
                    break;
                case "SUB-CUENTAS":
                    respuesta = (decimal)0.1;
                    break;
                case "SUB-SUB-CUENTAS":
                    respuesta = (decimal)0.0001;
                    break;
                case "SUB-SUB-SUB-CUENTAS":
                    respuesta = (decimal)0.000001;
                    break;
            }
            return respuesta;
        }



        #endregion

        #region

        public static string ordenConversionToSQL(string serie)
        {
            string orden = serie;
            if (string.IsNullOrEmpty(orden))
            {
                return orden;
            }
            else
            {
                if ((orden.IndexOf("0,") == -1) ||
                    (orden.IndexOf("1,") == -1) ||
                    (orden.IndexOf("2,") == -1) ||
                    (orden.IndexOf("3,") == -1) ||
                    (orden.IndexOf("4,") == -1) ||
                    (orden.IndexOf("5,") == -1) ||
                    (orden.IndexOf("6,") == -1) ||
                    (orden.IndexOf("9,") == -1) ||
                    (orden.IndexOf("8,") == -1) ||
                    (orden.IndexOf("9,") == -1))
                {
                    return orden;
                }
                else
                {
                        bool salir = false;
                        string temporal = "";
                        int posicion = -1;
                        do
                        {
                        if ((orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("0,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("1,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("2,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("3,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("4,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("5,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("6,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("9,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("8,") == -1) ||
                            (orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf("9,") == -1))
                        {
                            salir = false;
                        }
                        else
                        {
                            //Obtiene la posición que ubica la coma
                            //posicion = orden.IndexOf(",");
                            posicion = orden.Substring(posicion + 1, orden.Length - (posicion + 1)).IndexOf(",");
                            if (posicion == -1)
                            {
                                salir = false; ;
                            }
                            else
                            {
                                if ((orden.Substring(posicion - 1, posicion) == "0,") ||
                                    (orden.Substring(posicion - 1, posicion) == "1,") ||
                                    (orden.Substring(posicion - 1, posicion) == "2,") ||
                                    (orden.Substring(posicion - 1, posicion) == "3,") ||
                                    (orden.Substring(posicion - 1, posicion) == "4,") ||
                                    (orden.Substring(posicion - 1, posicion) == "5,") ||
                                    (orden.Substring(posicion - 1, posicion) == "6,") ||
                                    (orden.Substring(posicion - 1, posicion) == "7,") ||
                                    (orden.Substring(posicion - 1, posicion) == "8,") ||
                                    (orden.Substring(posicion - 1, posicion) == "9,"))
                                {
                                    salir = true;
                                    temporal = orden.Substring(0, posicion) + "." + orden.Substring(posicion + 1, orden.Length - (posicion + 1));
                                }
                                else
                                {
                                    temporal= orden.Substring(0, posicion) + "," + orden.Substring(posicion + 1, orden.Length - (posicion + 1));
                                }
                            }
                            orden = temporal;
                        }
                    }
                    while (salir);
                    return temporal;
                }
            }
        }

        public static string ordenConversionToSQL(decimal ordenNumero)
        {
            return ordenConversionToSQL(ordenNumero.ToString());
        }

        public static string ordenConversionToSQL(decimal? ordenNumero)
        {
            if (ordenNumero == null)
            {
                return "0";
            }
            else
            { 
            return ordenConversionToSQL(ordenNumero.ToString());
            }
        }
        //http://www.c-sharpcorner.com/uploadfile/puranindia/regular-expressions-in-C-Sharp/
        // Function to test whether the string is valid number or not
        public static bool IsNumber(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern =
            "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern
            + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(strNumber) &&
            !objTwoDotPattern.IsMatch(strNumber) &&
            !objTwoMinusPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }
        public static bool IsCodigoContable(String strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            String strValidRealPattern =
            "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern
            + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(strNumber) &&
            objNumberPattern.IsMatch(strNumber);
        }
        // Function To test for Alphabets.
        public static bool IsAlpha(String strToCheck)
        {
            Regex objAlphaPattern =new Regex("[a-zA-Z]");
            bool evaluar= objAlphaPattern.IsMatch(strToCheck);
            return objAlphaPattern.IsMatch(strToCheck);
        }

        // Function to Check for AlphaNumeric.
        public static bool IsAlphaNumeric(String strToCheck)
        {
            Regex objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }

        #endregion
    }
}
