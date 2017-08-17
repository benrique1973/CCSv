using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Support;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{
    public class TipoSaldoCuentaModelo : UIBase
    {
        public int idTSaldoCuenta//correlativo
        {
            get { return GetValue(() => idTSaldoCuenta); }
            set { SetValue(() => idTSaldoCuenta, value); }
        }
        [MaxLength(1, ErrorMessage = "No  puede ser mayor a 2 caracteres")]
        public string tiposaldocc
        {
            get { return GetValue(() => tiposaldocc); }
            set { SetValue(() => tiposaldocc, value); }
        }
        public string descripcionTSCuenta
        {
            get { return GetValue(() => descripcionTSCuenta); }
            set { SetValue(() => descripcionTSCuenta, value); }
        }

        #region Public Model Methods
        public static List<TipoSaldoCuentaModelo> GetAll()
        {
            var lista = new ObservableCollection<TipoSaldoCuentaModelo>
            {
               new TipoSaldoCuentaModelo {
                                        idTSaldoCuenta=0,
                                        tiposaldocc="X",
                                        descripcionTSCuenta="Ninguno"
                                      },
               new TipoSaldoCuentaModelo {
                                        idTSaldoCuenta=1,
                                        tiposaldocc="D",
                                        descripcionTSCuenta="Deudor"
                                      },
               new TipoSaldoCuentaModelo {
                                        idTSaldoCuenta=2,
                                        tiposaldocc="A",
                                        descripcionTSCuenta="Acreedor"
                                      },
               new TipoSaldoCuentaModelo {
                                        idTSaldoCuenta=3,
                                        tiposaldocc="RD",
                                        descripcionTSCuenta="Resultado deudor"
                                      },
                new TipoSaldoCuentaModelo {
                                        idTSaldoCuenta=4,
                                        tiposaldocc="RA",
                                        descripcionTSCuenta="Resultado acreedor"
                                      },
                new TipoSaldoCuentaModelo {
                                        idTSaldoCuenta=5,
                                        tiposaldocc="E",
                                        descripcionTSCuenta="Error en tipo"
                                      },
            };
            return lista.OrderBy(x => x.idTSaldoCuenta).ToList();
        }


        #endregion

        #region Filtro
        public static TipoSaldoCuentaModelo findByTipoSaldo(string tiposaldocc)
        {
            TipoSaldoCuentaModelo respuesta = null;
            switch (tiposaldocc.ToUpper())
            {
                case "D":
                    respuesta = new TipoSaldoCuentaModelo
                    {
                        idTSaldoCuenta = 1,
                        tiposaldocc = "D",
                        descripcionTSCuenta = "Deudor"
                    };
                    break;
                case "A":
                    respuesta = respuesta = new TipoSaldoCuentaModelo
                    {
                        idTSaldoCuenta = 2,
                        tiposaldocc = "A",
                        descripcionTSCuenta = "Acreedor"
                    };
                    break;
                case "RD":
                    respuesta = respuesta = new TipoSaldoCuentaModelo
                    {
                        idTSaldoCuenta = 3,
                        tiposaldocc = "RD",
                        descripcionTSCuenta = "Resultado deudor"
                    };
                    break;
                case "RA":
                    respuesta = new TipoSaldoCuentaModelo
                    {
                        idTSaldoCuenta = 4,
                        tiposaldocc = "RA",
                        descripcionTSCuenta = "Resultado acreedor"
                    };
                    break;
                default:
                    respuesta = new TipoSaldoCuentaModelo
                    {
                        idTSaldoCuenta = 5,
                        tiposaldocc = "E",
                        descripcionTSCuenta = "Error en registro"
                    };
                    break;
            }
            return respuesta;
        }

        public static TipoSaldoCuentaModelo claseSaldo(ElementoModelo elementoModelo)
        {
            TipoSaldoCuentaModelo respuesta=new TipoSaldoCuentaModelo();
            switch (elementoModelo.descripcion.ToUpper().Trim())
            {
                case "ACTIVO":
                    respuesta= findByTipoSaldo("D");
                    break;
                case "PASIVO":
                    respuesta= findByTipoSaldo("A");
                    break;
                case "PATRIMONIO":
                    respuesta= findByTipoSaldo("A");
                    break;
                case "COSTOS Y GASTOS":
                    respuesta= findByTipoSaldo("RD");
                    break;
                case "INGRESOS O VENTAS":
                    respuesta= findByTipoSaldo("RA");
                    break;
                case "CUENTAS DE ORDEN":
                    respuesta= findByTipoSaldo("D");
                    break;
                case "CUENTAS DE ORDEN POR CONTRA":
                    respuesta= findByTipoSaldo("A");
                    break;
            }
            return respuesta;
    }


        public static string claseSaldoByElemento(elemento elementoModelo)
        {
            string respuesta = string.Empty;
            switch (elementoModelo.descripcionelementos.ToUpper().Trim())
            {
                case "ACTIVO":
                    respuesta = "D";
                    break;
                case "PASIVO":
                    respuesta = "A";
                    break;
                case "PATRIMONIO":
                    respuesta = "A";
                    break;
                case "COSTOS Y GASTOS":
                    respuesta = "RD";
                    break;
                case "INGRESOS O VENTAS":
                    respuesta = "RA";
                    break;
                case "CUENTAS DE ORDEN":
                    respuesta = "D";
                    break;
                case "CUENTAS DE ORDEN POR CONTRA":
                    respuesta = "A";
                    break;
                default:
                    respuesta = "E";
                    break;
            }
            return respuesta;
        }

        public static string claseSaldoByIdElemento(elemento elementoModelo)
        {
            string respuesta = string.Empty;
            switch (elementoModelo.padreidelemento)
            {
                case 1:
                    respuesta = "D";
                    break;
                case 2:
                    respuesta = "A";
                    break;
                case 3:
                    respuesta = "A";
                    break;
                case 4:
                    respuesta = "RD";
                    break;
                case 5:
                    respuesta = "RA";
                    break;
                case 6:
                    respuesta = "D";
                    break;
                case 7:
                    respuesta = "A";
                    break;
                default:
                    respuesta = "E";
                    break;
            }
            return respuesta;
        }
        public static TipoSaldoCuentaModelo claseSaldo(int idElementoModelo)
        {
            ElementoModelo elementoModelo =ElementoModelo.Find(idElementoModelo);
            return claseSaldo(elementoModelo);
        }

        public static string claseSaldoByClaseElemento(int idElemento)
        {
            string respuesta = string.Empty;
            switch (idElemento)
            {
                case 1:
                    respuesta = "D";
                    break;
                case 2:
                    respuesta = "A";
                    break;
                case 3:
                    respuesta = "A";
                    break;
                case 4:
                    respuesta = "RD";
                    break;
                case 5:
                    respuesta = "RA";
                    break;
                case 6:
                    respuesta = "D";
                    break;
                case 7:
                    respuesta = "A";
                    break;
                default:
                    respuesta = "E";
                    break;
            }
            return respuesta;
        }
        #endregion
    }
}
