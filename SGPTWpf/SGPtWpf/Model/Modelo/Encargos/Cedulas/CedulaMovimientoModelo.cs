using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas
{

    public class CedulaMovimientoModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties
        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }
        public static bool sincronizar { get; set; }

        #endregion

        #region  idmovimiento
        public int _idmovimiento;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idmovimiento
        {
            get { return _idmovimiento; }
            set { _idmovimiento = value; }
        }

        #endregion

        #region  idcc
        public int? _idcc;
        public int? idcc
        {
            get { return _idcc; }
            set { _idcc = value; }
        }
        #endregion

        #region  idencargo
        public int? _idencargo;
        public int? idencargo
        {
            get { return _idencargo; }
            set { _idencargo = value; }
        }
        #endregion

        #region  idpartida
        public int? _idpartida;
        public int? idpartida
        {
            get { return _idpartida; }
            set { _idpartida = value; }
        }
        #endregion

        public Nullable<decimal> cargomovimiento { get { return GetValue(() => cargomovimiento); } set { SetValue(() => cargomovimiento, value); } }

        public Nullable<decimal> abonomovimiento { get { return GetValue(() => abonomovimiento); } set { SetValue(() => abonomovimiento, value); } }

        public string fecharevisionmovimiento { get { return GetValue(() => fecharevisionmovimiento); } set { SetValue(() => fecharevisionmovimiento, value); } }


        public string estadomovimiento { get { return GetValue(() => estadomovimiento); } set { SetValue(() => estadomovimiento, value); } }


 
        //Para distinguir entre registros ya con  id de la base y registros  pendientes de guardar
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }
        public bool cuentaValida
        {
            get { return GetValue(() => cuentaValida); }
            set { SetValue(() => cuentaValida, value); }
        }
        public bool tieneDecimales
        {
            get { return GetValue(() => tieneDecimales); }
            set { SetValue(() => tieneDecimales, value); }
        }

        public int cargosActivados
        {
            get { return GetValue(() => cargosActivados); }
            set { SetValue(() => cargosActivados, value); }
        }

        public int abonosActivados
        {
            get { return GetValue(() => abonosActivados); }
            set { SetValue(() => abonosActivados, value); }
        }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }


        public bool IsOperable
        {
            get { return GetValue(() => IsOperable); }
            set { SetValue(() => IsOperable, value); }
        }

        #region colecciones virtuales

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;

        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        //Permite evitar duplicacion el critero periodicidad, clase balance, fecha 
        public ObservableCollection<CedulaMovimientoModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        #endregion
        #region adicionales

        //Codigo de la cuenta contable
        public string codigocc
        {
            get { return GetValue(() => codigocc); }
            set { SetValue(() => codigocc, value); }
        }

        public string descripcioncc
        {
            get { return GetValue(() => descripcioncc); }
            set { SetValue(() => descripcioncc, value); }
        }

        public Nullable<decimal> ordencc
        {
            get { return GetValue(() => ordencc); }
            set { SetValue(() => ordencc, value); }
        }

        public string nombreElemento
        {
            get { return GetValue(() => nombreElemento); }
            set { SetValue(() => nombreElemento, value); }
        }
        public string nombreClaseCuenta
        {
            get { return GetValue(() => nombreClaseCuenta); }
            set { SetValue(() => nombreClaseCuenta, value); }
        }

        public string nombreTipoSaldoCuenta
        {
            get { return GetValue(() => nombreTipoSaldoCuenta); }
            set { SetValue(() => nombreTipoSaldoCuenta, value); }
        }

        public string nombreCuenta
        {
            get { return GetValue(() => nombreCuenta); }
            set { SetValue(() => nombreCuenta, value); }
        }
        //Registra la naturaleza del saldo de la cuenta: D= Deudor, A=Acreedor,  RD=Resultado deudor, RA=Resultado acreedor
        public string tiposaldocc
        {
            get { return GetValue(() => tiposaldocc); }
            set { SetValue(() => tiposaldocc, value); }
        }


        #endregion


        #region Public Model Methods

        public static bool Insert(CedulaMovimientoModelo modelo, bool resultado)
        {
            bool result = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.movimientos', 'idmovimiento'), (SELECT MAX(idmovimiento) FROM sgpt.movimientos) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new movimiento
                        {
                            //idmovimiento = modelo.idmovimiento,
                            idcc = modelo.idcc,
                            idpartida =(int) modelo.idpartida,
                            cargomovimiento = modelo.cargomovimiento,
                            abonomovimiento = modelo.abonomovimiento,
                            estadomovimiento = modelo.estadomovimiento,
                            idencargo=modelo.idencargo,
                        };
                        _context.movimientos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idmovimiento = tablaDestino.idmovimiento;

                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n " + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool InsertCapaDatos(movimiento modelo)
        {
            bool result = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.movimientos', 'idmovimiento'), (SELECT MAX(idmovimiento) FROM sgpt.movimientos) + 1);");
                            sincronizar = true;
                        }
                        _context.movimientos.Add(modelo);
                        _context.SaveChanges();
                        modelo.idmovimiento = modelo.idmovimiento;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        public static int Insert(CedulaMovimientoModelo modelo)
        {
            //-1 Fallo en la insercion
            //1 éxito en la operacion
            int result = 0;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.movimientos', 'idmovimiento'), (SELECT MAX(idmovimiento) FROM sgpt.movimientos) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new movimiento
                        {
                           // idmovimiento = modelo.idmovimiento,
                            idcc = modelo.idcc,
                            idpartida =(int) modelo.idpartida,
                            cargomovimiento = modelo.cargomovimiento,
                            abonomovimiento = modelo.abonomovimiento,
                            estadomovimiento = modelo.estadomovimiento,
                            idencargo=modelo.idencargo,
                        };
                        _context.movimientos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idmovimiento = tablaDestino.idmovimiento;
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return -1;//Error en la inserción
                }
            }
            else
            {
                return result;
            }
        }


        public static int InsertByRangeByCapadatos(ObservableCollection<movimiento> lista)
        {
            int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.movimientos', 'idmovimiento'), (SELECT MAX(idmovimiento) FROM sgpt.movimientos) + 1);");
                            sincronizar = true;
                        }
                        _context.movimientos.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return -1;
                }
            }
            else
            {
                return result;
            }
        }

        public static CedulaMovimientoModelo Find(int id)
        {
            var entidad = new CedulaMovimientoModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //movimiento modelo = _context.movimientos.Find(id);
                        movimiento modelo = _context.movimientos.Single(x => x.idmovimiento == id);
                        if (modelo != null)
                        {
                            entidad.idmovimiento = modelo.idmovimiento;
                            entidad.idcc = modelo.idcc;
                            entidad.idpartida = modelo.idpartida;
                            entidad.cargomovimiento = modelo.cargomovimiento;
                            entidad.abonomovimiento = modelo.abonomovimiento;
                            entidad.estadomovimiento = modelo.estadomovimiento;
                            entidad.idencargo = modelo.idencargo;
                            entidad.IsSelected = false;
                            entidad.guardadoBase = true;

                            return entidad;
                        }
                        else
                        {
                            return new CedulaMovimientoModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaMovimientoModelo();
                }

            }
            else
            {
                return entidad = null;
            }
        }

        #region Metodos para string 

        public static bool FindPK(int? id)
        {
            if (!(string.IsNullOrEmpty(id.ToString())))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new CedulaMovimientoModelo();
                    movimiento entidad = _context.movimientos.Find(id);
                    if (entidad == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }

        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPKEliminados(string id)
        {
            if (!(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new CedulaMovimientoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.movimientos
                            .Where(b => b.estadomovimiento == "B")
                            .FirstOrDefault();
                    if (entidad == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        #endregion

        public static bool FindPK(int id)
        {
            if (id == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    movimiento entidad = _context.movimientos.Find(id);
                    if (entidad == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }

        }

        public static void UpdateModelo(CedulaMovimientoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    movimiento entidad = _context.movimientos.Find(modelo.idmovimiento);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idmovimiento != modelo.idmovimiento) { cambiar = true; }
                        if (entidad.idcc != modelo.idcc) { cambiar = true; }
                        if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                        if (entidad.cargomovimiento != modelo.cargomovimiento) { cambiar = true; }
                        if (entidad.abonomovimiento != modelo.abonomovimiento) { cambiar = true; }
                        //if (entidad.estadomovimiento != modelo.estadomovimiento) { cambiar = true; }

                        if (cambiar)
                        {
                            entidad.idmovimiento = modelo.idmovimiento;
                            entidad.idcc = modelo.idcc;
                            entidad.idpartida =(int) modelo.idpartida;
                            entidad.cargomovimiento = modelo.cargomovimiento;
                            entidad.abonomovimiento = modelo.abonomovimiento;
                            //entidad.idencargo = modelo.idencargo;
                            //entidad.estadomovimiento = modelo.estadomovimiento;

                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                    }

                }
            }
            else
            {
                //No regresa nada
            }
        }

        public static int UpdateModelo(CedulaMovimientoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        movimiento entidad = _context.movimientos.Find(modelo.idmovimiento);
                        if (entidad == null)
                        {
                            return 1;
                        }
                        else
                        {
                            bool cambiar = false;
                            //if (entidad.idmovimiento != modelo.idmovimiento) { cambiar = true; }
                            if (entidad.idcc != modelo.idcc) { cambiar = true; }
                            if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                            if (entidad.cargomovimiento != modelo.cargomovimiento) { cambiar = true; }
                            if (entidad.abonomovimiento != modelo.abonomovimiento) { cambiar = true; }
                            //if (entidad.estadomovimiento != modelo.estadomovimiento) { cambiar = true; }

                            if (cambiar)
                            {
                                entidad.idmovimiento = modelo.idmovimiento;
                                entidad.idcc = modelo.idcc;
                                entidad.idpartida = (int)modelo.idpartida;
                                entidad.cargomovimiento = modelo.cargomovimiento;
                                entidad.abonomovimiento = modelo.abonomovimiento;
                                //entidad.estadomovimiento = modelo.estadomovimiento;
                                //entidad.idencargo = modelo.idencargo;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                        }
                        return 1;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int UpdateModelo(CedulaMovimientoModelo modelo, movimiento entidad)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //movimiento entidad = _context.movimientos.Find(modelo.idmovimiento);
                        if (entidad == null)
                        {
                            return 1;
                        }
                        else
                        {
                            bool cambiar = false;
                            //if (entidad.idmovimiento != modelo.idmovimiento) { cambiar = true; }
                            if (entidad.idcc != modelo.idcc) { cambiar = true; }
                            if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                            if (entidad.cargomovimiento != modelo.cargomovimiento) { cambiar = true; }
                            if (entidad.abonomovimiento != modelo.abonomovimiento) { cambiar = true; }
                            //if (entidad.estadomovimiento != modelo.estadomovimiento) { cambiar = true; }

                            if (cambiar)
                            {
                                entidad.idmovimiento = modelo.idmovimiento;
                                entidad.idcc = modelo.idcc;
                                entidad.idpartida = (int)modelo.idpartida;
                                entidad.cargomovimiento = modelo.cargomovimiento;
                                entidad.abonomovimiento = modelo.abonomovimiento;
                                //entidad.estadomovimiento = modelo.estadomovimiento;
                                //entidad.idencargo = modelo.idencargo;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                        }
                        return 1;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }


        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id, CedulaMovimientoModelo modelo)
        {
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.movimientos SET estadomovimiento = 'B' WHERE idmovimiento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro  \n" + e);
                        throw;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }


        public static void DeleteBorradoLogicoByidPartida(int idPartida)
        {
            if (!(idPartida == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(idPartida);//Borra todas las referencias dentro  de bitacora
                                                                                        //Inserta registro de borrado
                            #endregion

                            string commandString = String.Format("UPDATE sgpt.movimientos SET estadomovimiento = 'B' WHERE idpartida={0};", idPartida);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro  \n" + e);
                    }
                }
            }
        }

        public static int Delete(ObservableCollection<CedulaMovimientoModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        movimiento entidadTemporal = new movimiento();
                        string commandString = string.Empty;
                        foreach (CedulaMovimientoModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idmovimiento);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.movimientos WHERE idmovimiento={0};", item.idmovimiento);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return -1;
            }
        }

        public static int DeleteLogico(ObservableCollection<CedulaMovimientoModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        movimiento entidadTemporal = new movimiento();
                        string commandString = string.Empty;
                        foreach (CedulaMovimientoModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idmovimiento);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.movimientos SET estadomovimiento = 'B' WHERE idmovimiento={0};", item.idmovimiento);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return -1;
            }
        }



        public static int Delete(CedulaMovimientoModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idmovimiento != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.movimientos WHERE idmovimiento={0};", modelo.idmovimiento);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro \n" + e);
                        result = -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static int DeleteLogico(CedulaMovimientoModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idmovimiento != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.movimientos SET estadomovimiento = 'B' WHERE idmovimiento={0};", modelo.idmovimiento);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro \n" + e);
                        result = -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id, "MOVIMIENTOS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.movimientos WHERE idmovimiento={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
            }
        }
        public static void DeleteByIdPartida(int IdPartida)
        {
            try
            {
                if (IdPartida != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(IdPartida, "MOVIMIENTOS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.movimientos WHERE idpartida={0};", IdPartida);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
            }
        }
        public static void DeleteByRange(ObservableCollection<movimiento> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.movimientos.RemoveRange(lista);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del rango \n" + e);
            }
        }
        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id);//Borra todas las referencias dentro  de bitacora

                        //Borrar el detalle del balance

                        //marcasauditoriaMarcasModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.movimientos WHERE idmovimiento={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle \n" + e);
                }
                return false;
            }
        }


        public static int DeleteBorradoLogico(ObservableCollection<CedulaMovimientoModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    movimiento entidadTemporal = new movimiento();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaMovimientoModelo item in lista)
                        {
                             commandString = String.Format("UPDATE sgpt.movimientos SET estadomovimiento = 'B' WHERE idmovimiento={0};", item.idmovimiento);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        _context.SaveChanges();
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                    }
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        internal static List<CedulaMovimientoModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idcc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.movimientos.Select(entidad =>
                     new CedulaMovimientoModelo
                     {
                         idmovimiento = entidad.idmovimiento,
                         idcc = entidad.idcc,
                         idpartida = entidad.idpartida,
                         cargomovimiento = entidad.cargomovimiento,
                         abonomovimiento = entidad.abonomovimiento,
                         estadomovimiento = entidad.estadomovimiento,
                         codigocc = entidad.catalogocuenta.codigocc,
                         descripcioncc = entidad.catalogocuenta.descripcioncc,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         ordencc = entidad.catalogocuenta.ordencc,
                         nombreCuenta = entidad.catalogocuenta.descripcioncc,
                         idencargo=entidad.idencargo,
                         guardadoBase = true,
                         IsSelected = false,
                         cuentaValida = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idmovimiento).Where(x => x.estadomovimiento == "A"
                                                          && x.idcc == idcc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaMovimientoModelo item in lista)
                        {
                            item.nombreCuenta= item.codigocc + "-" + item.descripcioncc;
                            item.idCorrelativo = i;
                            i++;
                        }
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return null;
            }
        }

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<movimiento> lista, int idmovimiento)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.movimientos SET estadomovimiento = 'B' WHERE idmovimiento = {0};", idmovimiento);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                    }
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        //Conversion explicita
        public static explicit operator movimiento(CedulaMovimientoModelo modelo)  // explicit byte to digit conversion operator
        {
            movimiento entidad = new movimiento();
            entidad.idmovimiento = modelo.idmovimiento;
            entidad.idcc = modelo.idcc;
            entidad.idencargo = modelo.idencargo;
            entidad.idpartida =(int) modelo.idpartida;
            entidad.cargomovimiento = modelo.cargomovimiento;
            entidad.abonomovimiento = modelo.abonomovimiento;
            entidad.estadomovimiento = modelo.estadomovimiento;

            // explicit conversion
            return entidad;
        }
        public static bool Delete(string id, Boolean actualizar)
        {
            {

                if (!((string.IsNullOrEmpty(id)) || string.IsNullOrWhiteSpace(id)))
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {

                            string commandString = String.Format("DELETE FROM sgpt.movimientos WHERE idmovimiento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                        {
                            MessageBox.Show("Exception en borrar registro : " + e.Source);

                        }
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<CedulaMovimientoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.movimientos.Select(entidad =>
                     new CedulaMovimientoModelo
                     {
                         idmovimiento = entidad.idmovimiento,
                         idcc = entidad.idcc,
                         idpartida = entidad.idpartida,
                         cargomovimiento = entidad.cargomovimiento,
                         abonomovimiento = entidad.abonomovimiento,
                         estadomovimiento = entidad.estadomovimiento,
                         codigocc = entidad.catalogocuenta.codigocc,
                         descripcioncc = entidad.catalogocuenta.descripcioncc,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         ordencc = entidad.catalogocuenta.ordencc,
                         idencargo=entidad.idencargo,
                         cuentaValida = false,
                         guardadoBase = true,
                         IsSelected = false,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idmovimiento).Where(x => x.estadomovimiento == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaMovimientoModelo item in lista)
                        {
                            item.nombreCuenta=item.codigocc + "-" + item.descripcioncc;
                            item.idCorrelativo = i;
                            i++;
                        }
                        //lista.ForEach(c => c.guardadoBase = true);
                    }
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return null;
            }
        }

 
 

 
        public static ObservableCollection<CedulaMovimientoModelo> GetAllEdicionByIdPartida(EncargoModelo encargo, int idpartida)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.movimientos.Select(entidad =>
                     new CedulaMovimientoModelo
                     {
                         idmovimiento = entidad.idmovimiento,
                         idcc = entidad.idcc,
                         idpartida = entidad.idpartida,
                         cargomovimiento = entidad.cargomovimiento,
                         abonomovimiento = entidad.abonomovimiento,
                         estadomovimiento = entidad.estadomovimiento,
                         codigocc = entidad.catalogocuenta.codigocc,
                         descripcioncc = entidad.catalogocuenta.descripcioncc,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         ordencc = entidad.catalogocuenta.ordencc,
                         idencargo=entidad.idencargo,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.codigocc).Where(x => x.estadomovimiento == "A" &&  x.idpartida == idpartida).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaMovimientoModelo item in lista)
                    {
                        item.nombreCuenta= item.codigocc + "-" + item.descripcioncc;
                        item.idCorrelativo = i;
                        i++;
                    }
                    return new ObservableCollection<CedulaMovimientoModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaMovimientoModelo>();
            }
        }

        public static ObservableCollection<CedulaMovimientoModelo> GetAllEdicion(EncargoModelo encargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.movimientos.Select(entidad =>
                     new CedulaMovimientoModelo
                     {
                         idmovimiento = entidad.idmovimiento,
                         idcc = entidad.idcc,
                         idpartida = entidad.idpartida,
                         cargomovimiento = entidad.cargomovimiento,
                         abonomovimiento = entidad.abonomovimiento,
                         estadomovimiento = entidad.estadomovimiento,
                         codigocc = entidad.catalogocuenta.codigocc,
                         descripcioncc = entidad.catalogocuenta.descripcioncc,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         ordencc = entidad.catalogocuenta.ordencc,
                         nombreTipoSaldoCuenta=entidad.catalogocuenta.tiposaldocc,
                         idencargo=entidad.idencargo,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.codigocc).Where(x => x.estadomovimiento == "A" ).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaMovimientoModelo item in lista)
                    {
                        item.nombreCuenta = item.codigocc + "-" + item.descripcioncc;
                        item.idCorrelativo = i;
                        i++;
                    }
                    return new ObservableCollection<CedulaMovimientoModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaMovimientoModelo>();
            }
        }


        internal static CedulaMovimientoModelo GetRegistro(int idmovimiento)
        {
            var entidad = new CedulaMovimientoModelo();
            if (!(idmovimiento == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    movimiento modelo = _context.movimientos.Find(idmovimiento);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idmovimiento = modelo.idmovimiento;
                        entidad.idcc = modelo.idcc;
                        entidad.idpartida = modelo.idpartida;
                        entidad.cargomovimiento = modelo.cargomovimiento;
                        entidad.abonomovimiento = modelo.abonomovimiento;
                        entidad.estadomovimiento = modelo.estadomovimiento;
                        entidad.idencargo = modelo.idencargo;
                        entidad.cuentaValida = false;
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        return entidad;
                    }
                }

                if (entidad == null)
                    return entidad;
                else
                {
                    return entidad;
                }
            }
            else
            {
                return entidad = null;
            }
        }

        public static ObservableCollection<movimiento> GetAllCapaDatosByidpartida(int idpartida,int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.movimientos.Where(entidad => (entidad.idpartida == idpartida 
                    && entidad.estadomovimiento == "A"
                    && entidad.idencargo == idEncargo));
                    ObservableCollection<movimiento> temporal = new ObservableCollection<movimiento>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return null;
            }
        }

        public static bool DeleteByidpartidaRange(int? idpartida)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.movimientos.Where(x => x.estadomovimiento == "A" && x.idcc == idcc);
                    var lista = (from p in _context.movimientos
                                 where p.idpartida == idpartida
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.movimientos.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista \n " + e);
                return false;
            }
        }

        #endregion

        #region Contar registros
        public static int ContarRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.movimientos.Where(x => x.idmovimiento == id && x.estadomovimiento == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n" + e);
                return elementos;
            }
        }


        #endregion

 
        public CedulaMovimientoModelo()
        {

            idmovimiento = 0;
            idcc = null;
            idpartida = null;
            cargomovimiento = 0;
            abonomovimiento = 0;
            estadomovimiento = "A";
            codigocc = string.Empty;
            descripcioncc = string.Empty;
            nombreCuenta = "";
            tiposaldocc = string.Empty;
            ordencc = 0;
            IsSelected = false;
            guardadoBase = false;
            cargosActivados = 0;
            abonosActivados = 0;
            idencargo = 0;
            tieneDecimales = true;
            cuentaValida = false;
        }

        public CedulaMovimientoModelo(CedulaMovimientoModelo entidad)
        {
                         idmovimiento = entidad.idmovimiento;
                         idcc = entidad.idcc;
                         idpartida = entidad.idpartida;
                         cargomovimiento = entidad.cargomovimiento;
                         abonomovimiento = entidad.abonomovimiento;
                         estadomovimiento = entidad.estadomovimiento;
                         codigocc = entidad.codigocc;
                         descripcioncc = entidad.descripcioncc;
                         nombreCuenta= entidad.codigocc + "-" + entidad.descripcioncc;
                         tiposaldocc = entidad.tiposaldocc;
                         ordencc = entidad.ordencc;
                        idencargo = entidad.idencargo;
                         guardadoBase = entidad.guardadoBase;
                         IsSelected = entidad.IsSelected;
                         cuentaValida = entidad.cuentaValida;
        }

        //internal static ObservableCollection<CedulaMovimientoModelo> GetListaVacia()
        //{
        //    try
        //    {
        //        ObservableCollection<CedulaMovimientoModelo> temporal = new ObservableCollection<CedulaMovimientoModelo>();
        //        CedulaMovimientoModelo item = new CedulaMovimientoModelo();
        //        int i = 1;
        //            for (int j=0;i<12;i++)
        //            {
        //            item.idCorrelativo = j;
        //            item.cuentaValida = false;
        //            temporal.Add(item);
        //            item = new CedulaMovimientoModelo();
        //            }
        //       return new ObservableCollection<CedulaMovimientoModelo>(temporal);
        //    }
        //    catch (Exception e)
        //    {
        //        //Captura de fallo en la insercion
        //        if (e.Source != null)
        //        {
        //            MessageBox.Show("Exception en elaboracion de lista \n" + e);
        //        }
        //        return new ObservableCollection<CedulaMovimientoModelo>();
        //    }
        //}

        internal static ObservableCollection<CedulaMovimientoModelo> GetListaVacia(EncargoModelo encargo)
        {
            try
            {
                ObservableCollection<CedulaMovimientoModelo> temporal = new ObservableCollection<CedulaMovimientoModelo>();
                CedulaMovimientoModelo item = new CedulaMovimientoModelo();
                for (int j = 0; j < 12; j++)
                {
                    item.idCorrelativo = j;
                    item.cuentaValida = false;
                    item.idencargo = encargo.idencargo;
                    temporal.Add(item);
                    item = new CedulaMovimientoModelo();
                }
                return new ObservableCollection<CedulaMovimientoModelo>(temporal);
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaMovimientoModelo>();
            }
        }

        internal static ObservableCollection<CedulaMovimientoModelo> GetListaComplementaria(EncargoModelo encargo, ObservableCollection<CedulaMovimientoModelo> lista, CedulaPartidasModelo partida)
        {
            ObservableCollection<CedulaMovimientoModelo> temporal = new ObservableCollection<CedulaMovimientoModelo>();

            int cantidadRegistros = lista.Count();
            int k = 0;
            foreach (CedulaMovimientoModelo item in lista)
            {
                item.idCorrelativo = k;
                item.cuentaValida = true;
                item.guardadoBase = true;
                temporal.Add(item);

                k++;
            }

            try
            {

                CedulaMovimientoModelo item = new CedulaMovimientoModelo();
                for (int j = k; j < 12; j++)
                {
                    item.idpartida = partida.idpartida;
                    item.idCorrelativo = j;
                    item.cuentaValida = false;
                    item.guardadoBase = false;
                    item.idencargo = encargo.idencargo;
                    temporal.Add(item);
                    item = new CedulaMovimientoModelo();
                }
                return new ObservableCollection<CedulaMovimientoModelo>(temporal);
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaMovimientoModelo>();
            }
        }

    }
}
