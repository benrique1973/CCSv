using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionMenorQue:ValidationRule
    {
        //int numero;
        //public static readonly DependencyProperty NumeroProperty = DependencyProperty.Register
        //    (
        //         "Numerito",
        //         typeof(string),
        //         typeof(ValidacionMenorQue),
        //         new PropertyMetadata(string.Empty)
        //    );
        private bool _esRequerido=false;
        public bool EsRequerido
        {
            get { return _esRequerido; }
            set { _esRequerido = value; }
        }

        private int _numeritomenorque=-1;
        public int NumeritoMenorQue
        {
            get { return _numeritomenorque; }
            set { _numeritomenorque = value; }
        }
        private int _numeritomenorigualque=-1;
        public int NumeritoMenorIgualQue
        {
            get { return _numeritomenorigualque; }
            set { _numeritomenorigualque = value; }
        }
        private int _numeritomayorque=-1;
        public int NumeritoMayorQue
        {
            get { return _numeritomayorque; }
            set { _numeritomayorque = value; }
        }
        private int _numeritomayorigualque=-1;
        public int NumeritoMayorIgualQue
        {
            get { return _numeritomayorigualque; }
            set { _numeritomayorigualque = value; }
        }
            public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
            {
                string str = value as string;
                //int numx = NumeritoMenorQue;
                if (str != null)
                {
                    if (str.Length == 0)
                        return ValidationResult.ValidResult;
                    if (NumeritoMenorQue>=0 && NumeritoMenorIgualQue>=0 && NumeritoMayorQue>=0 && NumeritoMayorIgualQue>=0)
                    { /*Es locura de comandos desde la vista. no hacer nada*/}
                    else
                    {
                        if (NumeritoMayorQue>=0 || NumeritoMayorIgualQue>=0)
                        {
                            if (NumeritoMenorQue>=0||NumeritoMenorIgualQue>=0)
                            {
                                //aqui las validaciones deben ser compuestas
                                //verificar que no traigan valores juntamente los mayorque y mayorigualque. si trajeran se tomara el mayorigualque
                                //verificar que no traigan valores juntamente los menorque y menorigualque. si trajeran se tomara el menorigualque
                                if (NumeritoMayorQue >= 0 && NumeritoMayorIgualQue >= 0)
                                {
                                    #region v
                                    if (NumeritoMenorQue >= 0)
                                    {
                                        if (str.Length >= NumeritoMayorIgualQue && str.Length < NumeritoMenorQue)
                                            return ValidationResult.ValidResult;
                                    }
                                    if (NumeritoMenorIgualQue >= 0)
                                    {
                                        if (str.Length >= NumeritoMayorIgualQue && str.Length <= NumeritoMenorIgualQue)
                                            return ValidationResult.ValidResult;
                                    } 
                                    #endregion
                                }
                                else // uno de los dos no trae valor valido
                                {
                                    #region v
                                    if (NumeritoMayorQue >= 0)
                                    {
                                        #region v
                                        if (NumeritoMenorQue >= 0)
                                        {
                                            if (str.Length > NumeritoMayorQue && str.Length < NumeritoMenorQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        if (NumeritoMenorIgualQue >= 0)
                                        {
                                            if (str.Length > NumeritoMayorQue && str.Length <= NumeritoMenorIgualQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        #endregion
                                    }
                                    if (NumeritoMayorIgualQue >= 0)
                                    {
                                        #region v
                                        if (NumeritoMenorQue >= 0)
                                        {
                                            if (str.Length >= NumeritoMayorIgualQue && str.Length < NumeritoMenorQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        if (NumeritoMenorIgualQue >= 0)
                                        {
                                            if (str.Length >= NumeritoMayorIgualQue && str.Length <= NumeritoMenorIgualQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        #endregion
                                    } 
                                    #endregion
                                }

                                /****************************/
                                if (NumeritoMenorQue >= 0 && NumeritoMenorIgualQue >= 0)
                                {
                                    #region v
                                    if (NumeritoMayorQue >= 0)
                                    {
                                        if (str.Length > NumeritoMayorQue && str.Length <= NumeritoMenorIgualQue)
                                            return ValidationResult.ValidResult;
                                    }
                                    if (NumeritoMayorIgualQue >= 0)
                                    {
                                        if (str.Length >= NumeritoMayorQue && str.Length <= NumeritoMenorIgualQue)
                                            return ValidationResult.ValidResult;
                                    }
                                    #endregion
                                }
                                else // uno de los dos no trae valor valido
                                {
                                    #region v
                                    if (NumeritoMenorQue >= 0)
                                    {
                                        #region v
                                        if (NumeritoMayorQue >= 0)
                                        {
                                            if (str.Length > NumeritoMayorQue && str.Length < NumeritoMenorQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        if (NumeritoMayorIgualQue >= 0)
                                        {
                                            if (str.Length >= NumeritoMayorQue && str.Length < NumeritoMenorQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        #endregion
                                    }
                                    if (NumeritoMenorIgualQue >= 0)
                                    {
                                        #region v
                                        if (NumeritoMayorQue >= 0)
                                        {
                                            if (str.Length > NumeritoMayorQue && str.Length <= NumeritoMenorIgualQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        if (NumeritoMayorIgualQue >= 0)
                                        {
                                            if (str.Length >= NumeritoMayorQue && str.Length <= NumeritoMenorIgualQue)
                                                return ValidationResult.ValidResult;
                                        }
                                        #endregion
                                    }
                                    #endregion
                                }
                            }
                            else //entonces se abrira la validacion simple para mayorque
                            {
                                #region v
                                if (NumeritoMayorQue >= 0) //si no se usa esta validacion, traera valor -1
                                {
                                    if (str.Length > NumeritoMayorQue)
                                        return ValidationResult.ValidResult;
                                }
                                if (NumeritoMayorIgualQue >= 0) //si no se usa esta validacion, traera valor -1
                                {
                                    if (str.Length >= NumeritoMayorIgualQue)
                                        return ValidationResult.ValidResult;
                                } 
                                #endregion
                            }
                        }
                        else //solo habilitar validacion simple para los menorque
                        {
                            #region v
                            if (NumeritoMenorQue >= 0) //si no se usa esta validacion, traera valor -1
                            {
                                if (str.Length < NumeritoMenorQue)
                                    return ValidationResult.ValidResult;
                            }
                            if (NumeritoMenorIgualQue >= 0) //si no se usa esta validacion, traera valor -1
                            {
                                if (str.Length <= NumeritoMenorIgualQue)
                                    return ValidationResult.ValidResult;
                            }
                            #endregion
                        }
                    }
                }
                else
                {
                    if (EsRequerido){//MessageBox.Show("Es requerido"); //no mensajes
                    }
                    else { return ValidationResult.ValidResult; }
                }
                return new ValidationResult(false, Message);
            }
            public String Message { get; set; }
        }
}
