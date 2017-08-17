using SGPTmvvm.Soporte;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
namespace SGPTmvvm.CustomValidationAttributes
{
    public class ValidacionCompareDos : ValidationRule
    {
        private ContComparaContrasenia contenedorContrasenia;
        public ContComparaContrasenia ContenedorContraseña
        {
            get { return contenedorContrasenia; }
            set { contenedorContrasenia = value; }
        }

        private bool _esRequerido = false;
        public bool EsRequerido
        {
            get { return _esRequerido; }
            set { _esRequerido = value; }
        }       
       

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo CurrentCulture)
        {
            String VerifContrasenia = value.ToString(); //es la replicacion de la contraseña.
            String Contrasenia = ContenedorContraseña.Valux;
            //PasswordBox pwd = contenedorContrasenia.CajaClaves;
            System.Security.SecureString ab = ContenedorContraseña.Valux2;
            if (value != null)
            {
                if (String.Equals(Contrasenia, VerifContrasenia))
                {
                    return ValidationResult.ValidResult;
                }
            }
            else
            {
                if (EsRequerido)
                { /*MessageBox.Show("Es requerido"); //no mensajes*/}
                else { return ValidationResult.ValidResult; }
            }
            return new ValidationResult(false, Message);
        }
        public String Message { get; set; }
    }
}
