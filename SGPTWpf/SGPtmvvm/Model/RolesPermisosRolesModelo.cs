//using ModeloSGPT.Modelo;
using CapaDatos;
using SGPTmvvm.Soporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPTmvvm.Model
{
    public class RolesPermisosRolesModelo : CrudVMBase
    {
        //private SGPTEntidades db;

        public int idpru 
        {
            get { return GetValue(() => idpru); }
            set { SetValue(() => idpru, value); } 
        }
        public int idusuario
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }
        public string nombreopcionpru
        {
            get { return GetValue(() => nombreopcionpru); }
            set { SetValue(() => nombreopcionpru, value); }
        }
        public bool crearpru
        {
            get { return GetValue(() => crearpru); }
            set { SetValue(() => crearpru, value); }
        }
        public bool eliminarpru
        {
            get { return GetValue(() => eliminarpru); }
            set { SetValue(() => eliminarpru, value); }
        }
        public bool consultarpru
        {
            get { return GetValue(() => consultarpru); }
            set { SetValue(() => consultarpru, value); }
        }
        public bool editarpru
        {
            get { return GetValue(() => editarpru); }
            set { SetValue(() => editarpru, value); }
        }
        public bool impresionpru
        {
            get { return GetValue(() => impresionpru); }
            set { SetValue(() => impresionpru, value); }
        }
        public bool exportacionpru
        {
            get { return GetValue(() => exportacionpru); }
            set { SetValue(() => exportacionpru, value); }
        }
        public bool revisarpru
        {
            get { return GetValue(() => revisarpru); }
            set { SetValue(() => revisarpru, value); }
        }
        public bool aprobarpru
        {
            get { return GetValue(() => aprobarpru); }
            set { SetValue(() => aprobarpru, value); }
        }
        public string estadopru
        {
            get { return GetValue(() => estadopru); }
            set { SetValue(() => estadopru, value); }
        }

        public virtual usuario usuario { get; set; }
        public virtual role role { get; set; }
        public virtual opcionesrole opcionesrole { get; set; }

        public static int InsertarRolesPermisosRolesModelo(RolesPermisosRolesModelo RolesPermisosRolesModelo)
        {
            return 0;
        }
        //public static RolesPermisosRolesModelo BuscarRolesPermisosRolesModelo(int idpru) { }
    }
}
