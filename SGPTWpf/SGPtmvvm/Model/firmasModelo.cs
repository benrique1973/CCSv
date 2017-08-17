using CapaDatos;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class firmasModelo : CrudVMBase
    {
        #region Propiedades
        public int idfirma { get { return GetValue(() => idfirma); } set { SetValue(() => idfirma, value); } }
        public int iddepartamento { get { return GetValue(() => iddepartamento); } set { SetValue(() => iddepartamento, value); } }
        public int idpais { get { return GetValue(() => idpais); } set { SetValue(() => idpais, value); } }
        public int idmunicipio { get { return GetValue(() => idmunicipio); } set { SetValue(() => idmunicipio, value); } }
        public int idusuario { get { return GetValue(() => idusuario); } set { SetValue(() => idusuario, value); } }
        public string razonsocialfirma { get { return GetValue(() => razonsocialfirma); } set { SetValue(() => razonsocialfirma, value); } }
        public string representantefirma { get { return GetValue(() => representantefirma); } set { SetValue(() => representantefirma, value); } }
        public string nitfirma { get { return GetValue(() => nitfirma); } set { SetValue(() => nitfirma, value); } }
        public string nrcfirma { get { return GetValue(() => nrcfirma); } set { SetValue(() => nrcfirma, value); } }
        public string direccionfirma { get { return GetValue(() => direccionfirma); } set { SetValue(() => direccionfirma, value); } }
        public int numerocvpafirma { get { return GetValue(() => numerocvpafirma); } set { SetValue(() => numerocvpafirma, value); } }
        public string fechainscripcioncvpafirma { get { return GetValue(() => fechainscripcioncvpafirma); } set { SetValue(() => fechainscripcioncvpafirma, value); } }
        public string fechacreadofirma { get { return GetValue(() => fechacreadofirma); } set { SetValue(() => fechacreadofirma, value); } }
        public string urlfirma { get { return GetValue(() => urlfirma); } set { SetValue(() => urlfirma, value); } }
        public byte[] logofirma { get { return GetValue(() => logofirma); } set { SetValue(() => logofirma, value); } }
        public string estadofirma { get { return GetValue(() => estadofirma); } set { SetValue(() => estadofirma, value); } }

        public virtual departamento departamento { get; set; }
        public virtual municipio municipio { get; set; }
        public virtual pais pais { get; set; }
        public virtual usuario usuario { get; set; }
        #endregion
    }
}
