using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Support;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas
{

    public class CedulaDiarioModelo : UIBase
    {

        #region Model Properties
        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }

        public int idpartida
        {
            get { return GetValue(() => idpartida); }
            set { SetValue(() => idpartida, value); }
        }
        public string claseRegistro { get { return GetValue(() => claseRegistro); } set { SetValue(() => claseRegistro, value); } }

        public string clasepartida { get { return GetValue(() => clasepartida); } set { SetValue(() => clasepartida, value); } }

        public string referencia { get { return GetValue(() => referencia); } set { SetValue(() => referencia, value); } }

        public string codigo { get { return GetValue(() => codigo); } set { SetValue(() => codigo, value); } }

        public string concepto { get { return GetValue(() => concepto); } set { SetValue(() => concepto, value); } }

        public decimal? parcial { get { return GetValue(() => parcial); } set { SetValue(() => parcial, value); } }

        public decimal? cargos { get { return GetValue(() => cargos); } set { SetValue(() => cargos, value); } }

        public decimal? abonos { get { return GetValue(() => abonos); } set { SetValue(() => abonos, value); } }
        public string aprobadapartida { get { return GetValue(() => aprobadapartida); } set { SetValue(() => aprobadapartida, value); } }

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }

        public string commandButton { get { return GetValue(() => commandButton); } set { SetValue(() => commandButton, value); } }


        #endregion
        public static string conversionIniciales(string etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo.ToUpper())
            {
                case "ENCABEZADO":
                    respuesta = "E";
                    break;
                case "TITULO":
                    respuesta = "T";
                    break;
                case "CUENTACARGO":
                    respuesta = "CC";
                    break;
                case "CUENTAABONO":
                    respuesta = "CA";
                    break;
                case "DESCRIPCION":
                    respuesta = "D";
                    break;
                case "SUMA":
                    respuesta = "S";
                    break;
                case "INTERMEDIO":
                    respuesta = "I";
                    break;
                default:
                    respuesta = "N";
                    break;
            }
            return respuesta;
        }
        public static string conversionIniciales(int etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo)
            {
                case 1:
                    respuesta = "E";
                    break;
                case 2:
                    respuesta = "T";
                    break;
                case 3:
                    respuesta = "CC";
                    break;
                case 4:
                    respuesta = "CA";
                    break;
                case 5:
                    respuesta = "D";
                    break;
                case 6:
                    respuesta = "S";
                    break;
                case 7:
                    respuesta = "I";
                    break;
                default:
                    respuesta = "N";
                    break;
            }
            return respuesta;
        }
        public static string conversionRegistro(string etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo.ToUpper())
            {
                case "E":
                    respuesta = "Encabezado";
                    break;
                case "T":
                    respuesta = "Titulo";
                    break;
                case "CC":
                    respuesta = "Cuenta cargos";
                    break;
                case "CA":
                    respuesta = "Cuenta abonos";
                    break;
                case "D":
                    respuesta = "Descripcion";
                    break;
                case "S":
                    respuesta = "Suma";
                    break;
                case "I":
                    respuesta = "Intermedio";
                    break;
                default:
                    respuesta = "No identificado";
                    break;
            }
            return respuesta;
        }
        public static string conversionRegistro(int etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo)
            {
                case 1:
                    respuesta = "Encabezado";
                    break;
                case 2:
                    respuesta = "Titulo";
                    break;
                case 3:
                    respuesta = "Cuenta cargos";
                    break;
                case 4:
                    respuesta = "Cuenta abonos";
                    break;
                case 5:
                    respuesta = "Descripcion";
                    break;
                case 6:
                    respuesta = "Suma";
                    break;
                case 7:
                    respuesta = "Intermedio";
                    break;
                default:
                    respuesta = "No identificado";
                    break;
            }
            return respuesta;
        }
        #region Llenado

        public static ObservableCollection<CedulaDiarioModelo> GetAllEdicion(EncargoModelo encargo, int idCedula)
        {
            try
            {
                ObservableCollection<CedulaPartidasModelo> lista = new ObservableCollection<CedulaPartidasModelo>(CedulaPartidasModelo.GetAllEdicion(encargo, idCedula));
                ObservableCollection<CedulaMovimientoModelo> listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>(CedulaMovimientoModelo.GetAllEdicion(encargo));
                ObservableCollection<CedulaMovimientoModelo> listaMovimientosCargos = new ObservableCollection<CedulaMovimientoModelo>();
                ObservableCollection<CedulaMovimientoModelo> listaMovimientosAbonos = new ObservableCollection<CedulaMovimientoModelo>();
                ObservableCollection<CedulaDiarioModelo> listaDiario = new ObservableCollection<CedulaDiarioModelo>();
                CedulaDiarioModelo temporal = new CedulaDiarioModelo();
                   int i = 1;
                    foreach (CedulaPartidasModelo item in lista)
                    {
                        item.idCorrelativo = i;
                    for (int j=0;i<7;i++)
                    {
                        switch (j)
                        {
                            case 1:
                                //Encabezado
                                temporal.referencia = item.referenciapapel;
                                temporal.clasepartida = item.descripciontp;
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = item.conceptopartida;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 2:
                                //"Titulo";
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = "Partida No. "+item.numeropartida;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 3:
                                //Cuentas de cargos
                                listaMovimientosCargos = new ObservableCollection<CedulaMovimientoModelo>(listaMovimientos.Where(x => x.idpartida==item.idpartida && x.cargomovimiento>0).OrderBy(x=>x.ordencc));
                                if (listaMovimientosCargos.Count > 0)
                                { 
                                foreach (CedulaMovimientoModelo elemento in listaMovimientos)
                                {
                                        //"Titulo";
                                        temporal.idCorrelativo = i;
                                        temporal.claseRegistro = conversionIniciales(j);
                                        temporal.codigo = elemento.codigocc;
                                        temporal.concepto =elemento.descripcioncc;
                                        temporal.cargos = elemento.cargomovimiento;
                                        temporal.idpartida = item.idpartida;
                                        listaDiario.Add(temporal);
                                        i++;
                                        temporal = new CedulaDiarioModelo();
                                }
                                }
                                break;
                            case 4:
                                //"Cuenta abonos";
                                listaMovimientosAbonos = new ObservableCollection<CedulaMovimientoModelo>(listaMovimientos.Where(x => x.idpartida == item.idpartida && x.abonomovimiento > 0).OrderBy(x => x.ordencc));
                                if (listaMovimientosCargos.Count > 0)
                                {
                                    foreach (CedulaMovimientoModelo elemento in listaMovimientos)
                                    {
                                        //"Titulo";
                                        temporal.idCorrelativo = i;
                                        temporal.claseRegistro = conversionIniciales(j);
                                        temporal.codigo = elemento.codigocc;
                                        temporal.concepto = elemento.descripcioncc;
                                        temporal.abonos = elemento.abonomovimiento;
                                        temporal.idpartida = item.idpartida;
                                        listaDiario.Add(temporal);
                                        i++;
                                        temporal = new CedulaDiarioModelo();
                                    }
                                }
                                break;
                            case 5:
                                //"Descripcion";
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = item.comentariopartida;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 6:
                                //"Suma";
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = "Totales";
                                temporal.cargos =(decimal)listaMovimientosCargos.Sum(x => x.cargomovimiento);
                                temporal.abonos=(decimal)listaMovimientosAbonos.Sum(x => x.abonomovimiento);
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 7:
                                //"Intermedio";
                                //"Suma";
                                temporal.idCorrelativo = i;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                        }
                    }
                    }
                return listaDiario;
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaDiarioModelo>();
            }
        }

        public static ObservableCollection<CedulaDiarioModelo> GetAllEdicion(EncargoModelo encargo, int idCedula, ObservableCollection<CedulaPartidasModelo> lista, ObservableCollection<CedulaMovimientoModelo> listaMovimientos)
        {
            try
            {
                //ObservableCollection<CedulaPartidasModelo> lista = new ObservableCollection<CedulaPartidasModelo>(CedulaPartidasModelo.GetAllEdicion(encargo, idCedula));
                //ObservableCollection<CedulaMovimientoModelo> listaMovimientos = new ObservableCollection<CedulaMovimientoModelo>(CedulaMovimientoModelo.GetAllEdicion(encargo, idCedula));
                ObservableCollection<CedulaMovimientoModelo> listaMovimientosCargos = new ObservableCollection<CedulaMovimientoModelo>();
                ObservableCollection<CedulaMovimientoModelo> listaMovimientosAbonos = new ObservableCollection<CedulaMovimientoModelo>();
                ObservableCollection<CedulaDiarioModelo> listaDiario = new ObservableCollection<CedulaDiarioModelo>();
                CedulaDiarioModelo temporal = new CedulaDiarioModelo();
                int i = 1;
                foreach (CedulaPartidasModelo item in lista)
                {
                    item.idCorrelativo = i;
                    for (int j = 0; j < 7; j++)
                    {
                        switch (item.aprobadapartida.ToUpper())
                        {
                            case "APROBADA":
                                temporal.commandButton = "Verificado";
                                break;
                            case "PROPUESTA":
                                temporal.commandButton = "Aprobar";
                                break;
                        }
                        switch (j)
                        {
                            case 1:
                                //Encabezado
                                temporal.referencia = item.referenciapapel;
                                temporal.clasepartida = item.descripciontp;
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = item.conceptopartida;
                                temporal.idpartida = item.idpartida;
                                temporal.aprobadapartida = item.aprobadapartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 2:
                                //"Titulo";
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = "Partida No. " + item.numeropartida;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 3:
                                //Cuentas de cargos
                                listaMovimientosCargos = new ObservableCollection<CedulaMovimientoModelo>(listaMovimientos.Where(x => x.idpartida == item.idpartida && x.cargomovimiento > 0).OrderBy(x => x.ordencc));
                                if (listaMovimientosCargos.Count > 0)
                                {
                                    foreach (CedulaMovimientoModelo elemento in listaMovimientosCargos)
                                    {
                                        //"Titulo";
                                        temporal.idCorrelativo = i;
                                        temporal.claseRegistro = conversionIniciales(j);
                                        temporal.codigo = elemento.codigocc;
                                        temporal.concepto = elemento.descripcioncc;
                                        temporal.cargos = elemento.cargomovimiento;
                                        temporal.idpartida = item.idpartida;
                                        listaDiario.Add(temporal);
                                        i++;
                                        temporal = new CedulaDiarioModelo();
                                    }
                                }
                                break;
                            case 4:
                                //"Cuenta abonos";
                                listaMovimientosAbonos = new ObservableCollection<CedulaMovimientoModelo>(listaMovimientos.Where(x => x.idpartida == item.idpartida && x.abonomovimiento > 0).OrderBy(x => x.ordencc));
                                if (listaMovimientosAbonos.Count > 0)
                                {
                                    foreach (CedulaMovimientoModelo elemento in listaMovimientosAbonos)
                                    {
                                        //"Titulo";
                                        temporal.idCorrelativo = i;
                                        temporal.claseRegistro = conversionIniciales(j);
                                        temporal.codigo = elemento.codigocc;
                                        temporal.concepto = elemento.descripcioncc;
                                        temporal.abonos = elemento.abonomovimiento;
                                        temporal.idpartida = item.idpartida;
                                        listaDiario.Add(temporal);
                                        i++;
                                        temporal = new CedulaDiarioModelo();
                                    }
                                }
                                break;
                            case 5:
                                //"Descripcion";
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = item.comentariopartida;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 6:
                                //"Suma";
                                temporal.idCorrelativo = i;
                                temporal.claseRegistro = conversionIniciales(j);
                                temporal.concepto = "Totales";
                                temporal.cargos = (decimal)item.sumacargopartida;
                                temporal.abonos = (decimal)item.sumaabonopartida;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                            case 7:
                                //"Intermedio";
                                //"Suma";
                                temporal.idCorrelativo = i;
                                temporal.idpartida = item.idpartida;
                                listaDiario.Add(temporal);
                                i++;
                                temporal = new CedulaDiarioModelo();
                                break;
                        }
                    }
                }
                return listaDiario;
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaDiarioModelo>();
            }
        }

        public CedulaDiarioModelo()
        {
            idCorrelativo = 0;

            claseRegistro = string.Empty;

            clasepartida = string.Empty;

            referencia = string.Empty;

            codigo = string.Empty;

            concepto = string.Empty;

            parcial = 0;

            cargos = 0;

            abonos = 0;

            IsSelected = false;
        }


        #endregion
    }
}
