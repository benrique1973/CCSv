using CapaDatos;
using SGPTWpf.Model;
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

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class DetalleBalanceModelo : UIBase
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

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DisplayName("Código")]
        //public int iddb
        //{
        //    get { return GetValue(() => iddb); }
        //    set { SetValue(() => iddb, value); }
        //}
        #region iddb

        public int _iddb;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int iddb
        {
            get { return _iddb; }
            set { _iddb = value; }
        }

        #endregion

        public int _idcedula;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idcedula
        {
            get { return _idcedula; }
            set { _idcedula = value; }
        }

        #endregion

        //Identifica el  tipo de elemento contable
        //public int? idcc
        //{
        //    get { return GetValue(() => idcc); }
        //    set { SetValue(() => idcc, value); }
        //}
        #region idcc

        public int? _idcc;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int? idcc
        {
            get { return _idcc; }
            set { _idcc = value; }
        }

        #endregion
        //Vincula con el sistema contable asociado y asu vez con  el encargo
        public Nullable<int> idbalance
        {
            get { return GetValue(() => idbalance); }
            set { SetValue(() => idbalance, value); }
        }

        //Almacena el id del padre de la cuenta
        public decimal saldoanteriordb
        {
            get { return GetValue(() => saldoanteriordb); }
            set { SetValue(() => saldoanteriordb, value); }
        }

        //Identifica el  tipo de cuenta 1 Elemento, 2 rubro, 3 cuenta , 4 sub cuenta 5, sub sub cuenta
        public decimal cargodb
        {
            get { return GetValue(() => cargodb); }
            set { SetValue(() => cargodb, value); }
        }

        //Codigo de la cuenta contable

        public decimal abonodb
        {
            get { return GetValue(() => abonodb); }
            set { SetValue(() => abonodb, value); }
        }

        //[UnqiueProgramaDetalle(ErrorMessage = "Nombre duplicado ya existe en otro registro")]
        public decimal saldofinaldb
        {
            get { return GetValue(() => saldofinaldb); }
            set { SetValue(() => saldofinaldb, value); }
        }

         public string estadodb
        {
            get { return GetValue(() => estadodb); }
            set { SetValue(() => estadodb, value); }
        }
         public string nombreClaseCuenta
        {
            get { return GetValue(() => nombreClaseCuenta); }
            set { SetValue(() => nombreClaseCuenta, value); }
        }
        public Nullable<decimal> orden
        {
            get { return GetValue(() => orden); }
            set { SetValue(() => orden, value); }
        }
        

        //Adicionadas
        public string ordenDhPresentacion
        {
            get { return GetValue(() => ordenDhPresentacion); }
            set { SetValue(() => ordenDhPresentacion, value); }
        }

        //Registra la naturaleza del saldo de la cuenta: D= Deudor, A=Acreedor,  RD=Resultado deudor, RA=Resultado acreedor
        public string codigoccdb
        {
            get { return GetValue(() => codigoccdb); }
            set { SetValue(() => codigoccdb, value); }
        }

        public string nombreCuenta
        {
            get { return GetValue(() => nombreCuenta); }
            set { SetValue(() => nombreCuenta, value); }
        }
        public string tiposaldocc
        {
            get { return GetValue(() => tiposaldocc); }
            set { SetValue(() => tiposaldocc, value); }
        }

        public string comentariodb
        {
            get { return GetValue(() => comentariodb); }
            set { SetValue(() => comentariodb, value); }
        }

        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }
        //Para distinguir entre registros ya con  id de la base y registros  pendientes de guardar
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        //Clase cuenta 
        #region idccuentas
        public int? idccuentas
        {
            get { return GetValue(() => idccuentas); }
            set { SetValue(() => idccuentas, value); }
        }
        #endregion

        #region colecciones virtuales

        public virtual BalanceModelo balanceModelo
        {
            get { return GetValue(() => balanceModelo); }
            set { SetValue(() => balanceModelo, value); }
        }

        public virtual CatalogoCuentasModelo catalogoCuentaModelo
        {
            get { return GetValue(() => catalogoCuentaModelo); }
            set { SetValue(() => catalogoCuentaModelo, value); }
        }
        //public virtual BitacoraModelo bitacoraModelo
        //{
        //    get { return GetValue(() => bitacoraModelo); }
        //    set { SetValue(() => bitacoraModelo, value); }
        //}
        #region bitacoraModelo

        public BitacoraModelo _bitacoraModelo;
        public BitacoraModelo bitacoraModelo
        {
            get { return _bitacoraModelo; }
            set { _bitacoraModelo = value; }
        }

        #endregion

        //public virtual UsuarioModelo usuarioModelo
        //{
        //    get { return GetValue(() => usuarioModelo); }
        //    set { SetValue(() => usuarioModelo, value); }
        //}
        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        public ObservableCollection<DetalleBalanceModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }
        public ObservableCollection<DetalleMatrizRiesgoModelo> listaEntidadSeleccionRiesgo
        {
            get { return GetValue(() => listaEntidadSeleccionRiesgo); }
            set { SetValue(() => listaEntidadSeleccionRiesgo, value); }
        }
        public ObservableCollection<CatalogoCuentasModelo> listaCatalogoCuentasModelo
        {
            get { return GetValue(() => listaCatalogoCuentasModelo); }
            set { SetValue(() => listaCatalogoCuentasModelo, value); }
        }
        public ObservableCollection<BitacoraModelo> listaBitacora
        {
            get { return GetValue(() => listaBitacora); }
            set { SetValue(() => listaBitacora, value); }
        }
        #endregion

        #region Public Model Methods

        public static bool Insert(DetalleBalanceModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallebalances', 'iddb'), (SELECT MAX(iddb) FROM sgpt.detallebalances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallebalance
                        {
                            //iddb = modelo.iddb,
                            idcc = modelo.idcc,
                            idbalance = modelo.idbalance,
                            saldoanteriordb = modelo.saldoanteriordb,
                            cargodb = modelo.cargodb,
                            abonodb = modelo.abonodb,
                            saldofinaldb = modelo.saldofinaldb,
                            estadodb = modelo.estadodb,
                            orden = modelo.orden,
                            comentariodb = modelo.comentariodb,
                            isuso = modelo.isuso,

                        };
                        _context.detallebalances.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.iddb = tablaDestino.iddb;
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de detalle del balance: " + e.Message);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static int Insert(DetalleBalanceModelo modelo)
        {
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallebalances', 'iddb'), (SELECT MAX(iddb) FROM sgpt.detallebalances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallebalance
                        {
                            //iddb = modelo.iddb,
                            idcc = modelo.idcc,
                            idbalance = modelo.idbalance,
                            saldoanteriordb = modelo.saldoanteriordb,
                            cargodb = modelo.cargodb,
                            abonodb = modelo.abonodb,
                            saldofinaldb = modelo.saldofinaldb,
                            estadodb = modelo.estadodb,
                            orden = modelo.orden,
                            comentariodb = modelo.comentariodb,
                            isuso = modelo.isuso,
                        };
                        _context.detallebalances.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.iddb = tablaDestino.iddb;

                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de detalle del balance: " + e.Message);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }


        public static int InsertByRange(ObservableCollection<detallebalance> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallebalances', 'iddb'), (SELECT MAX(iddb) FROM sgpt.detallebalances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        foreach(detallebalance item in lista)
                        { 
                        _context.detallebalances.Add(item);
                        _context.SaveChanges();
                        }
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de detalle del balance: \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static void UpdateByRange(ObservableCollection<detallebalance> lista, bool retorno)
        {
            //int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        foreach (detallebalance item in lista)
                        {
                            _context.Entry(item).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        //result = 1;
                        //return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar registro de detalle del balance: " + e.Message);
                    throw;
                    //return result;
                }
            }
            else
            {
                //return result;
            }
        }
        public static int UpdateByRange(ObservableCollection<detallebalance> lista)
        {
            int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        foreach (detallebalance item in lista)
                        {
                            _context.Entry(item).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de detalle del balance: " + e.Message);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        //Devuelve el registro buscado con base al indice
        public static DetalleBalanceModelo Find(int id)
        {
            var entidad = new DetalleBalanceModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detallebalance modelo = _context.detallebalances.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.iddb = modelo.iddb;
                        entidad.idcc = modelo.idcc;
                        entidad.idbalance = modelo.idbalance;
                        entidad.saldoanteriordb = modelo.saldoanteriordb;
                        entidad.cargodb = modelo.cargodb;
                        entidad.abonodb = modelo.abonodb;
                        entidad.saldofinaldb = modelo.saldofinaldb;
                        entidad.estadodb = modelo.estadodb;
                        entidad.orden = modelo.orden;
                        entidad.comentariodb = modelo.comentariodb;
                        entidad.isuso = modelo.isuso;

                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.orden);
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.balanceModelo = BalanceModelo.Find((int)entidad.idcc);

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

        //Devuelve el maximo del orden de un registro
        public static Nullable<decimal> FindOrden(int idbalance)
        {
            decimal? ordenMaximo = 0;
            if (!(idbalance == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    ordenMaximo = _context.detallebalances.Where(x => x.idbalance == idbalance).Max(p => p.orden);
                    if (ordenMaximo == null)
                    {
                        return ordenMaximo = 1;
                    }
                    else
                    {
                        return ordenMaximo + 1;
                    }
                }
            }
            else
            {
                return ordenMaximo;
            }
        }
        #region Metodos para string 


        public static DetalleBalanceModelo GetRegistro(string id)
        {
            var entidad = new DetalleBalanceModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidad = null;
                    }
                    detallebalance modelo = _context.detallebalances.Find(id);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.iddb = modelo.iddb;
                        entidad.idcc = modelo.idcc;
                        entidad.idbalance = modelo.idbalance;
                        entidad.saldoanteriordb = modelo.saldoanteriordb;
                        entidad.cargodb = modelo.cargodb;
                        entidad.abonodb = modelo.abonodb;
                        entidad.saldofinaldb = modelo.saldofinaldb;
                        entidad.estadodb = modelo.estadodb;
                        entidad.orden = modelo.orden;
                        entidad.comentariodb = modelo.comentariodb;
                        entidad.isuso = modelo.isuso;

                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.orden);
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.balanceModelo = BalanceModelo.Find((int)entidad.idcc);
                        entidad.nombreCuenta = entidad.catalogoCuentaModelo.descripcioncc;
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
                return entidad;
            }

        }

        public static DetalleBalanceModelo GetRegistroById(int id)
        {
            var entidad = new DetalleBalanceModelo();
            if (id != 0)
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id.ToString()))
                    {
                        return entidad = null;
                    }
                    detallebalance modelo = _context.detallebalances.Find(id);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.iddb = modelo.iddb;
                        entidad.idcc = modelo.idcc;
                        entidad.idbalance = modelo.idbalance;
                        entidad.saldoanteriordb = modelo.saldoanteriordb;
                        entidad.cargodb = modelo.cargodb;
                        entidad.abonodb = modelo.abonodb;
                        entidad.saldofinaldb = modelo.saldofinaldb;
                        entidad.estadodb = modelo.estadodb;
                        entidad.orden = modelo.orden;
                        entidad.comentariodb = modelo.comentariodb;
                        entidad.isuso = modelo.isuso;

                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.orden);
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.balanceModelo = BalanceModelo.Find((int)entidad.idcc);
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
                return entidad;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleBalanceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    detallebalance entidad = _context.detallebalances.Find(id);
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

        public static bool FindPK(int? id)
        {
            if (!(string.IsNullOrEmpty(id.ToString())))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleBalanceModelo();
                    detallebalance entidad = _context.detallebalances.Find(id);
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
                    var modelo = new DetalleBalanceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detallebalances
                            .Where(b => b.estadodb == "B")
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
                    detallebalance entidad = _context.detallebalances.Find(id);
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

        public static Nullable<decimal> FindOrdenPadreById(int? id)
        {
            Nullable<decimal> nombre = 0;
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    return nombre = _context.detallebalances.Find(id).orden;
                }
            }
            else
            {
                return nombre;
            }
        }
        //Para realizar busquedas de texto

        public static void UpdateModelo(DetalleBalanceModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detallebalance entidad = _context.detallebalances.Find(modelo.iddb);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.iddb = modelo.iddb;
                        entidad.idcc = modelo.idcc;
                        entidad.idbalance = modelo.idbalance;
                        entidad.saldoanteriordb = modelo.saldoanteriordb;
                        entidad.cargodb = modelo.cargodb;
                        entidad.abonodb = modelo.abonodb;
                        entidad.saldofinaldb = modelo.saldofinaldb;
                        entidad.estadodb = modelo.estadodb;
                        entidad.orden = modelo.orden;
                        entidad.comentariodb = modelo.comentariodb;
                        entidad.isuso = modelo.isuso;

                    }
                    _context.Entry(entidad).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }
            else
            {
                //No regresa nada
            }
        }


        public static bool UpdateModelo(DetalleBalanceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        detallebalance entidad = _context.detallebalances.Find(modelo.iddb);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            if(entidad.iddb != modelo.iddb) {cambio=true;}
                            if(entidad.idcc != modelo.idcc) {cambio=true;}
                            if(entidad.idbalance != modelo.idbalance) {cambio=true;}
                            if(entidad.saldoanteriordb != modelo.saldoanteriordb) {cambio=true;}
                            if(entidad.cargodb != modelo.cargodb) {cambio=true;}
                            if(entidad.abonodb != modelo.abonodb) {cambio=true;}
                            if(entidad.saldofinaldb != modelo.saldofinaldb) {cambio=true;}
                            if(entidad.estadodb != modelo.estadodb) {cambio=true;}
                            if(entidad.orden != modelo.orden) {cambio=true;}
                            if(entidad.comentariodb != modelo.comentariodb) {cambio=true;}
                            if(entidad.isuso != modelo.isuso) {cambio=true;}

                            if (cambio)
                            {
                                //entidad.iddb = modelo.iddb;
                                //entidad.idcc = modelo.idcc;
                                //entidad.idbalance = modelo.idbalance;
                                entidad.saldoanteriordb = modelo.saldoanteriordb;
                                entidad.cargodb = modelo.cargodb;
                                entidad.abonodb = modelo.abonodb;
                                entidad.saldofinaldb = modelo.saldofinaldb;
                                //entidad.estadodb = modelo.estadodb;
                                //entidad.orden = modelo.orden;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad catalogo de cuentas : " + e);
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id, Boolean actualizar)
        {
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.detallebalances SET estadodb = 'B' WHERE iddb={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //detallebalance entidad = _context.detallebalances.Find(id);
                            ////Borrado del catalogos
                            //entidad.estadodb = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del catalogo: " + e.Message);
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

        public static void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.detallebalances WHERE iddb={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                throw;
            }
        }

        public static void DeleteAllByBalance(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.detallebalances WHERE idbalance={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //return true;
                    }
                }
                else
                {
                    //return true;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                //return false;
                throw;
            }
        }
        public static bool DeleteAllByBalanceBorradoLogico(int id)
        {
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.detallebalances SET estadodb = 'B' WHERE idbalance={0};", id);
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
                            MessageBox.Show("Exception en borrar registro del catalogo: \n" + e);
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
        public static void DeleteByRange(ObservableCollection<detallebalance> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.detallebalances.RemoveRange(lista);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del rango : " + e.Message);
                throw;
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
                        //detallebalance entidad = _context.detallebalances.Find(id);
                        //Borrado del catalogos
                            string commandString = String.Format("DELETE FROM sgpt.detallebalances WHERE iddb={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return false;
            }
        }

        public static bool Delete(ObservableCollection<DetalleBalanceModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        detallebalance entidadTemporal = new detallebalance();
                        foreach (DetalleBalanceModelo item in lista)
                        {
                            //Buscar registro
                            string commandString = String.Format("DELETE FROM sgpt.detallebalances WHERE iddb={0};",item.iddb);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
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
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return false;
            }
        }

        public static bool DeleteBorradoLogico(ObservableCollection<DetalleBalanceModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        foreach (DetalleBalanceModelo item in lista)
                        {
                            string commandString = String.Format("UPDATE sgpt.detallebalances SET estadodb = 'B' WHERE iddb={0};", item.iddb);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<detallebalance> lista, int idbalance)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallebalances SET estadodb = 'B' WHERE idbalance = {0};", idbalance);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        //Se elimina todo el contenido
                        _context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                    }
                    return false;
                    throw;
                }
            }
            else
            {
                return true;
            }
        }

        //Conversion explicita
        public static explicit operator detallebalance(DetalleBalanceModelo modelo)  // explicit byte to digit conversion operator
        {
            detallebalance entidad = new detallebalance();
            entidad.iddb = modelo.iddb;
            entidad.idcc = modelo.idcc;
            entidad.idbalance = modelo.idbalance;
            entidad.saldoanteriordb = modelo.saldoanteriordb;
            entidad.cargodb = modelo.cargodb;
            entidad.abonodb = modelo.abonodb;
            entidad.saldofinaldb = modelo.saldofinaldb;
            entidad.estadodb = modelo.estadodb;
            entidad.orden = modelo.orden;
            entidad.comentariodb = modelo.comentariodb;
            entidad.isuso = modelo.isuso;

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
                            string commandString = String.Format("DELETE FROM sgpt.detallebalances WHERE iddb={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Source);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<DetalleBalanceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallebalances.Select(entidad =>
                     new DetalleBalanceModelo
                     {
                         iddb = entidad.iddb,
                         idcc = entidad.idcc,
                         idbalance = entidad.idbalance,
                         saldoanteriordb = entidad.saldoanteriordb,
                         cargodb = entidad.cargodb,
                         abonodb = entidad.abonodb,
                         saldofinaldb = entidad.saldofinaldb,
                         estadodb = entidad.estadodb,
                         orden = entidad.orden,
                         comentariodb = entidad.comentariodb,
                         isuso = entidad.isuso,

                         codigoccdb = entidad.catalogocuenta.codigocc,
                         nombreCuenta = entidad.catalogocuenta.descripcioncc,
                         nombreClaseCuenta = entidad.catalogocuenta.elemento.descripcionelementos,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         idccuentas = entidad.catalogocuenta.idccuentas,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.abonodb).Where(x => x.estadodb == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (DetalleBalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.orden);

                        item.balanceModelo = BalanceModelo.Find((int)item.idcc);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return RegeneraOrdenSubRegistros(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<DetalleBalanceModelo> GetAllByIdBC(int idBc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallebalances.Select(entidad =>
                     new DetalleBalanceModelo
                     {
                         iddb = entidad.iddb,
                         idcc = entidad.idcc,
                         idbalance = entidad.idbalance,
                         saldoanteriordb = entidad.saldoanteriordb,
                         cargodb = entidad.cargodb,
                         abonodb = entidad.abonodb,
                         saldofinaldb = entidad.saldofinaldb,
                         estadodb = entidad.estadodb,
                         orden = entidad.catalogocuenta.ordencc,
                         comentariodb = entidad.comentariodb,
                         isuso = entidad.isuso,

                         codigoccdb = entidad.catalogocuenta.codigocc,
                         nombreCuenta = entidad.catalogocuenta.descripcioncc,
                         nombreClaseCuenta = entidad.catalogocuenta.elemento.descripcionelementos,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         idccuentas=entidad.catalogocuenta.idccuentas,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.orden).Where(x => x.estadodb == "A" && x.idbalance==idBc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    BalanceModelo temporal= BalanceModelo.Find((int)idBc);
                    foreach (DetalleBalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.orden);
                        item.balanceModelo = temporal;
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<DetalleBalanceModelo>(lista);
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

        public static ObservableCollection<DetalleBalanceModelo> GetAllByIdBCRiesgo(int idBc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallebalances.Select(entidad =>
                     new DetalleBalanceModelo
                     {
                         iddb = entidad.iddb,
                         idcc = entidad.idcc,
                         idbalance = entidad.idbalance,
                         saldoanteriordb = entidad.saldoanteriordb,
                         cargodb = entidad.cargodb,
                         abonodb = entidad.abonodb,
                         saldofinaldb = entidad.saldofinaldb,
                         estadodb = entidad.estadodb,
                         orden = entidad.catalogocuenta.ordencc,
                         comentariodb = entidad.comentariodb,
                         isuso = entidad.isuso,
                         codigoccdb = entidad.catalogocuenta.codigocc,
                         nombreCuenta = entidad.catalogocuenta.descripcioncc,
                         nombreClaseCuenta = entidad.catalogocuenta.elemento.descripcionelementos,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         idccuentas = entidad.catalogocuenta.idccuentas,
                         guardadoBase = false,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.orden).Where(x => x.estadodb == "A" && x.idbalance == idBc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    //int i = 1;
                    //foreach (DetalleBalanceModelo item in lista)
                    //{
                    //    item.idCorrelativo = i;
                    //    i++;
                    //    item.guardadoBase = true;
                    //    item.IsSelected = false;
                    //    item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.orden);
                    //    item.balanceModelo = BalanceModelo.Find((int)item.idcc);
                    //}
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<DetalleBalanceModelo>(lista);
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
        public static ObservableCollection<DetalleBalanceModelo> GetAllByIdBCAndClaseCuenta(int idBc, int idccuentas)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallebalances.Select(entidad =>
                     new DetalleBalanceModelo
                     {
                         iddb = entidad.iddb,
                         idcc = entidad.idcc,
                         idbalance = entidad.idbalance,
                         saldoanteriordb = entidad.saldoanteriordb,
                         cargodb = entidad.cargodb,
                         abonodb = entidad.abonodb,
                         saldofinaldb = entidad.saldofinaldb,
                         estadodb = entidad.estadodb,
                         orden = entidad.catalogocuenta.ordencc,
                         comentariodb = entidad.comentariodb,
                         isuso = entidad.isuso,

                         codigoccdb = entidad.catalogocuenta.codigocc,
                         nombreCuenta = entidad.catalogocuenta.descripcioncc,
                         nombreClaseCuenta = entidad.catalogocuenta.elemento.descripcionelementos,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         idccuentas = entidad.catalogocuenta.idccuentas,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.orden).Where(x => x.estadodb == "A" && x.idbalance == idBc && x.idccuentas==idccuentas).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (DetalleBalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.orden);
                        item.balanceModelo = BalanceModelo.Find((int)item.idcc);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<DetalleBalanceModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }
        public static ObservableCollection<detallebalance> GetAllCapaDatosByidBc(int idBc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallebalances.Where(entidad => (entidad.idbalance == idBc && entidad.estadodb == "A"));
                    ObservableCollection<detallebalance> temporal = new ObservableCollection<detallebalance>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<detallebalance> GetAllCapaDatosByCodigoContable(int idCc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallebalances.Where(entidad => (entidad.idcc == idCc && entidad.estadodb == "A"));
                    ObservableCollection<detallebalance> temporal = new ObservableCollection<detallebalance>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo \n" + e);
                }
                return null;
            }
        }
        public static bool DeleteByIdProgramaRange(int? idbalance)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.detallebalances.Where(x => x.estadodb == "A" && x.idbalance == idbalance);
                    var lista = (from p in _context.detallebalances
                                 where p.idbalance == idbalance
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.detallebalances.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista detalle herramientas " + e.Message + " fuente " + e.Source);
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
                    elementos = _context.detallebalances.Where(x => x.idbalance == id && x.estadodb == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: " + e.Message);
                return elementos;
            }
        }

        public static int ContarSubRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detallebalances.Where(x => x.saldoanteriordb == id && x.estadodb == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: " + e.Message);
                return elementos;
            }
        }

        public static int ContarRegistros()
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detallebalances.Where(x => x.estadodb == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: " + e.Message);
                return elementos;
            }
        }


        #endregion


        #region Limpieza de valores

        #region generacion del orden

        private decimal ordenRegistro(DetalleBalanceModelo registro, int idSc)
        {
            decimal ordenRespuesta = 0;
            if ((registro != null))
            {
                if (!(registro.iddb == 0))
                {
                    //Busca el orden en que esta en el catalogo
                    ordenRespuesta = CatalogoCuentasModelo.GetOrdenRegistro(idSc);
                }
            }
            else
            {
                ordenRespuesta = 0;
            }
            return ordenRespuesta;
        }

        public static List<DetalleBalanceModelo> RegeneraOrdenSubRegistros(List<DetalleBalanceModelo> listaDetalleHerramienta)
        {

            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    //Obtener el  balance (maestro) para usar el idDc
                    var balanceAplicado = BalanceModelo.GetRegistroById((int)listaDetalleHerramienta[0].idbalance);
                    //Obtener el orden del catalogo y aplicarlo
                    var listaCatalogo = CatalogoCuentasModelo.GetAll(balanceAplicado.idscbalance);
                    decimal ordenAnterior = 0;
                    foreach (DetalleBalanceModelo itemDetalle in listaDetalleHerramienta)
                    {
                        ordenAnterior =(decimal) listaCatalogo.Single(x => x.idcc == itemDetalle.idcc).ordencc;
                            if (itemDetalle.orden != ordenAnterior)
                            {
                                //Se asigna el orden a los principales
                                itemDetalle.orden = ordenAnterior;
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.orden);
                                DetalleBalanceModelo.UpdateModelo(itemDetalle);
                            }
                        ordenAnterior = 0;
                    }
                    return listaDetalleHerramienta.OrderBy(x => x.orden).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden " + e.Message);
                    return listaDetalleHerramienta.OrderBy(x => x.orden).ToList();
                    throw;
                }
            }
        }

        #endregion

        public DetalleBalanceModelo(BalanceModelo balance,CatalogoCuentasModelo cuenta)
        {
            iddb = 0;
            idcc = 0;
            idbalance = balance.idbalance;
            saldoanteriordb = 0;
            cargodb = 0;
            abonodb = 0;
            saldofinaldb = 0;
            estadodb = "A";
            orden = cuenta.ordencc;
            comentariodb = string.Empty;
            isuso = 0;

            codigoccdb = cuenta.codigocc;
            guardadoBase = false;
            IsSelected = false;
        }
        public DetalleBalanceModelo()
        {

            iddb = 0;
            idcc = 0;
            idbalance = 0;
            saldoanteriordb = 0;
            cargodb = 0;
            codigoccdb = string.Empty;
            estadodb = "A";
            guardadoBase = false;
            IsSelected = false;
            orden = 0;
            usuarioModelo = null;
            bitacoraModelo = null;
            comentariodb = string.Empty;
            listaEntidadSeleccion = new ObservableCollection<DetalleBalanceModelo>();
            listaBitacora = new ObservableCollection<BitacoraModelo>();
        }
        public DetalleBalanceModelo(BalanceModelo balance)
        {

            iddb = 0;
            idcc = 0;
            idbalance = balance.idbalance;
            saldoanteriordb = 0;
            cargodb = 0;
            codigoccdb = string.Empty;
            estadodb = "A";
            guardadoBase = false;
            IsSelected = false;
            orden = 0;
            usuarioModelo = null;
            bitacoraModelo = null;
            comentariodb = string.Empty;
            listaEntidadSeleccion = new ObservableCollection<DetalleBalanceModelo>();
            listaBitacora = new ObservableCollection<BitacoraModelo>();
        }

        public DetalleBalanceModelo(DetalleBalanceModelo comun, DetalleBalanceModelo origen)
        {
            iddb = 0;
            idcc = origen.idcc;
            idbalance = comun.idbalance;//Programa del que depende

            saldofinaldb = origen.saldofinaldb;
            orden = (decimal)origen.orden;
            estadodb = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            saldoanteriordb = origen.iddb;
            guardadoBase = false;
            IsSelected = false;
            comentariodb =origen.comentariodb;
            usuarioModelo = null;
            bitacoraModelo = null;
            listaEntidadSeleccion = new ObservableCollection<DetalleBalanceModelo>();
            listaBitacora = new ObservableCollection<BitacoraModelo>();
        }

        #endregion
    }

}
