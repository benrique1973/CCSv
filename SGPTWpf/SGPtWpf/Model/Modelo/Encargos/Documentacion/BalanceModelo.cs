using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class  BalanceModelo : UIBase
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


        //public int idbalance
        //{
        //    get { return GetValue(() => idbalance); }
        //    set { SetValue(() => idbalance, value); }
        //}
        #region idbalance

        public int _idbalance;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idbalance
        {
            get { return _idbalance; }
            set { _idbalance = value; }
        }

        #endregion
        //Identifica el  tipo de elemento contable
        public int idcb
        {
            get { return GetValue(() => idcb); }
            set { SetValue(() => idcb, value); }
        }

        //Vincula con el sistema contable asociado y asu vez con  el encargo
        public int idperiodos
        {
            get { return GetValue(() => idperiodos); }
            set { SetValue(() => idperiodos, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechasistemabalance
        {
            get { return GetValue(() => fechasistemabalance); }
            set { SetValue(() => fechasistemabalance, value); }
        }
        //Codigo de la cuenta contable
        [DisplayName("Fecha de balance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
         Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
         ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechabalancebalance 
        {
            get { return GetValue(() => fechabalancebalance ); }
            set { SetValue(() => fechabalancebalance , value); }
        }

        //Clase de balance
        public string periodicidadperiodos
        {
            get { return GetValue(() => periodicidadperiodos); }
            set { SetValue(() => periodicidadperiodos, value); }
        }

        public string descripcioncb
        {
            get { return GetValue(() => descripcioncb); }
            set { SetValue(() => descripcioncb, value); }
        }

        //Registra la naturaleza del saldo de la cuenta: D= Deudor, A=Acreedor,  RD=Resultado deudor, RA=Resultado acreedor
        public int idscbalance
        {
            get { return GetValue(() => idscbalance); }
            set { SetValue(() => idscbalance, value); }
        }

        public string estadobalance
        {
            get { return GetValue(() => estadobalance); }
            set { SetValue(() => estadobalance, value); }
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

        public string inicialesusuariocb
        {
            get { return GetValue(() => inicialesusuariocb); }
            set { SetValue(() => inicialesusuariocb, value); }
        }

        #endregion

        #region propiedades para listas
        public string idnitcliente //Tomada de sistema contable
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }
        #region Propiedades de presentacion

        public string descripcionTipoAuditoria
        {
            get { return GetValue(() => descripcionTipoAuditoria); }
            set { SetValue(() => descripcionTipoAuditoria, value); }
        }

        public string fechainiperauditencargo
        {
            get { return GetValue(() => fechainiperauditencargo); }
            set { SetValue(() => fechainiperauditencargo, value); }
        }
        public string fechafinperauditencargo
        {
            get { return GetValue(() => fechafinperauditencargo); }
            set { SetValue(() => fechafinperauditencargo, value); }
        }

        #endregion
        #endregion

        #region colecciones virtuales

        public virtual BitacoraModelo bitacoraModelo
        {
            get { return GetValue(() => bitacoraModelo); }
            set { SetValue(() => bitacoraModelo, value); }
        }

        public virtual ClaseBalanceModelo claseBalanceModelo
        {
            get { return GetValue(() => claseBalanceModelo); }
            set { SetValue(() => claseBalanceModelo, value); }
        }

        public virtual PeriodoModelo periodoModelo
        {
            get { return GetValue(() => periodoModelo); }
            set { SetValue(() => periodoModelo, value); }
        }
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
        //Permite evitar duplicacion el critero periodicidad, clase balance, fecha 
        public ObservableCollection<BalanceModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        public ObservableCollection<BitacoraModelo> listaBitacora
        {
            get { return GetValue(() => listaBitacora); }
            set { SetValue(() => listaBitacora, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(BalanceModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.balances', 'idbalance'), (SELECT MAX(idbalance) FROM sgpt.balances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new balance
                        {
                            //idbalance = modelo.idbalance,
                            idcb = modelo.idcb,
                            idperiodos = modelo.idperiodos,
                            fechabalancebalance  = modelo.fechabalancebalance ,
                            fechasistemabalance = modelo.fechasistemabalance,
                            estadobalance = modelo.estadobalance,
                            idscbalance=modelo.idscbalance,
                        };
                        _context.balances.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idbalance = tablaDestino.idbalance;
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de balance: " + e.Message);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool Insert(balance modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.balances', 'idbalance'), (SELECT MAX(idbalance) FROM sgpt.balances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.balances.Add(modelo);
                        _context.SaveChanges();
                        modelo.idbalance = modelo.idbalance;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de balance: \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        public static int Insert(BalanceModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.balances', 'idbalance'), (SELECT MAX(idbalance) FROM sgpt.balances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new balance
                        {
                            //idbalance = modelo.idbalance,
                            idcb = modelo.idcb,
                            idperiodos = modelo.idperiodos,
                            fechabalancebalance  = modelo.fechabalancebalance ,
                            fechasistemabalance = modelo.fechasistemabalance,
                            estadobalance = modelo.estadobalance,
                            idscbalance=modelo.idscbalance,
                        };
                        _context.balances.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idbalance = tablaDestino.idbalance;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "BALANCES", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            temporal.idCorrelativoBit = modelo.listaBitacora.Count()+1;
                            modelo.listaBitacora.Add(temporal);
                        }
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de balance: " + e.Message);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }


        public static int InsertByRange(ObservableCollection<balance> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.balances', 'idbalance'), (SELECT MAX(idbalance) FROM sgpt.balances) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.balances.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de balance: " + e.Message);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static BalanceModelo Find(int id)
        {
            var entidad = new BalanceModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    balance modelo = _context.balances.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idbalance = modelo.idbalance;
                        entidad.idcb = modelo.idcb;
                        entidad.idperiodos = modelo.idperiodos;
                        entidad.fechabalancebalance  = modelo.fechabalancebalance ;
                        entidad.fechasistemabalance = modelo.fechasistemabalance;
                        entidad.estadobalance = modelo.estadobalance;
                        entidad.periodicidadperiodos = modelo.periodo.periodicidadperiodos;
                        entidad.descripcioncb = modelo.clasesbalance.descripcioncb;
                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                        entidad.idscbalance = modelo.idscbalance;
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.claseBalanceModelo = ClaseBalanceModelo.Find(entidad.idcb);
                        entidad.periodoModelo =PeriodoModelo.Find(entidad.idperiodos);
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

        #region Metodos para string 


        public static BalanceModelo GetRegistro(string id)
        {
            try
            {
                int idBuscado = int.Parse(id);
                return BalanceModelo.Find(idBuscado);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception en búsqueda de  registros: " + e.Message);
                return new BalanceModelo();
                throw;
            }
        }

        public static BalanceModelo GetRegistroById(int id)
        {
            try
            {
                return BalanceModelo.Find(id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception en búsqueda de  registros: " + e.Message);
                return new BalanceModelo();
                throw;
            }
        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new BalanceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    balance entidad = _context.balances.Find(id);
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
                    var modelo = new BalanceModelo();
                    balance entidad = _context.balances.Find(id);
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
                    var modelo = new BalanceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.balances
                            .Where(b => b.estadobalance == "B")
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
                    balance entidad = _context.balances.Find(id);
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

        public static void UpdateModelo(BalanceModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    balance entidad = _context.balances.Find(modelo.idbalance);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idbalance = modelo.idbalance;
                        entidad.idcb = modelo.idcb;
                        entidad.idperiodos = modelo.idperiodos;
                        entidad.fechabalancebalance  = modelo.fechabalancebalance ;
                        entidad.fechasistemabalance = modelo.fechasistemabalance;
                        entidad.estadobalance = modelo.estadobalance;
                        entidad.idscbalance = modelo.idscbalance;
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


        public static bool UpdateModelo(BalanceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        string cambioTexto = "";
                        balance entidad = _context.balances.Find(modelo.idbalance);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.idbalance = modelo.idbalance; no puede cambiar
                            if (!(entidad.idcb == modelo.idcb))
                            {
                                cambioTexto = String.Format(" Clases balance ");
                                entidad.idcb = modelo.idcb;
                                cambio = true;

                            }
                            if (!(entidad.idperiodos == modelo.idperiodos))
                            {
                                cambioTexto = String.Format(" periodo- ")+cambioTexto;
                                entidad.idperiodos = modelo.idperiodos;
                                cambio = true;
                            }                            //entidad.idperiodos = modelo.idperiodos; No puede cambiar
                            if (!(entidad.fechabalancebalance  == modelo.fechabalancebalance ))
                            {
                                cambioTexto = String.Format("fecha balance- ") + cambioTexto;
                                entidad.fechabalancebalance = modelo.fechabalancebalance;
                                cambio = true;
                            }
                            //if (!(entidad.idscbalance == modelo.idscbalance))
                            //{
                            //    entidad.idscbalance = modelo.idscbalance;
                            //    cambio = true;
                            //}
                            if (cambio)
                            {
                                //entidad.idbalance = modelo.idbalance;
                                entidad.idcb = modelo.idcb;
                                entidad.idperiodos = modelo.idperiodos;
                                entidad.fechabalancebalance  = modelo.fechabalancebalance ;
                                entidad.fechasistemabalance = modelo.fechasistemabalance;
                                entidad.estadobalance = modelo.estadobalance;
                                entidad.idscbalance = modelo.idscbalance;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "BALANCES", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = cambioTexto;
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    temporal.idCorrelativoBit = modelo.listaBitacora.Count()+1;
                                    modelo.listaBitacora.Add(temporal);
                                }
                            }
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad catalogo de cuentas : " + e.Message);
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
        public static bool DeleteBorradoLogico(int id, BalanceModelo modelo)
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
                            #region bitacora
                            
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(id);//Borra todas las referencias dentro  de bitacora
                                                                                  //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "BALANCES", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                temporal.idCorrelativoBit = modelo.listaBitacora.Count()+1;
                                modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.balances SET estadobalance = 'B' WHERE idbalance={0};", id);
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

        public static bool Delete(ObservableCollection<BalanceModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        balance entidadTemporal = new balance();
                        string commandString = string.Empty;
                        foreach (BalanceModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idbalance);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.balances WHERE idbalance={0};", item.idbalance);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                }
                return false;
                throw;
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
                        string commandString = String.Format("DELETE FROM sgpt.balances WHERE idbalance={0};", id);
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

        public static void DeleteByRange(ObservableCollection<balance> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.balances.RemoveRange(lista);
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
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id);//Borra todas las referencias dentro  de bitacora

                        //Borrar el detalle del balance

                        DetalleBalanceModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.balances WHERE idbalance={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                }
                return false;
                throw;
            }
        }


        public static bool DeleteBorradoLogico(ObservableCollection<BalanceModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    balance entidadTemporal = new balance();
                    int idperiodos = (int)lista[0].idperiodos;
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (BalanceModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idbalance);//Borra todas las referencias dentro  de bitacora
                                                                                  //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "BALANCES", EtapaEncargoModelo.seleccionEtapa(8));
                            
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                temporal.idCorrelativoBit = item.listaBitacora.Count()+1;
                                item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idbalance);//Borra todas las referencias dentro  de bitacora
                            
                            #endregion 
                            commandString = String.Format("UPDATE sgpt.balances SET estadobalance = 'B' WHERE idbalance={0};", item.idbalance);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<balance> lista, int idperiodos)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.balances SET estadobalance = 'B' WHERE idperiodos = {0};", idperiodos);
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
        public static explicit operator balance(BalanceModelo modelo)  // explicit byte to digit conversion operator
        {
            balance entidad = new balance();
            entidad.idbalance = modelo.idbalance;
            entidad.idcb = modelo.idcb;
            entidad.idperiodos = modelo.idperiodos;
            entidad.fechabalancebalance  = modelo.fechabalancebalance ;
            entidad.fechasistemabalance = modelo.fechasistemabalance;
            entidad.estadobalance = modelo.estadobalance;
            entidad.idscbalance = modelo.idscbalance;
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

                            //Debe remover el  detalle del balance para no  dejar huerfanos

                            //Verificar que  no existan registros relacionados

                            string commandString = String.Format("DELETE FROM sgpt.balances WHERE idbalance={0};", id);
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

        public static List<BalanceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Select(entidad =>
                     new BalanceModelo
                     {
                         idbalance = entidad.idbalance,
                         idcb = entidad.idcb,
                         idperiodos = entidad.idperiodos,
                         fechabalancebalance = entidad.fechabalancebalance,
                         fechasistemabalance = entidad.fechasistemabalance,
                         estadobalance = entidad.estadobalance,
                         descripcioncb = entidad.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                         idscbalance=entidad.idscbalance,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechabalancebalance ).Where(x => x.estadobalance == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.claseBalanceModelo = ClaseBalanceModelo.Find(item.idcb);
                        item.periodoModelo = PeriodoModelo.Find(item.idperiodos);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances \n" + e);
                }
                return null;
            }
        }

        public static List<BalanceModelo> GetAllByIsSc(int idsc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Select(entidad =>
                     new BalanceModelo
                     {
                         idbalance = entidad.idbalance,
                         idcb = entidad.idcb,
                         idperiodos = entidad.idperiodos,
                         fechabalancebalance = entidad.fechabalancebalance,
                         fechasistemabalance = entidad.fechasistemabalance,
                         estadobalance = entidad.estadobalance,
                         descripcioncb = entidad.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                         idscbalance = entidad.idscbalance,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechabalancebalance).Where(x => x.estadobalance == "A" && x.idscbalance==idsc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.claseBalanceModelo = ClaseBalanceModelo.Find(item.idcb);
                        item.periodoModelo = PeriodoModelo.Find(item.idperiodos);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances \n" + e);
                }
                return null;
            }
        }

        public static List<BalanceModelo> GetAllByIsScForCedulas(EncargoModelo encargo)
        {
            try
            {
               
                sistemascontable scm = SistemaContableModelo.GetRegistroByIdEncargoCapaDatos(encargo.idencargo);
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Select(entidad =>
                     new BalanceModelo
                     {
                         idbalance = entidad.idbalance,
                         idcb = entidad.idcb,
                         idperiodos = entidad.idperiodos,
                         fechabalancebalance = entidad.fechabalancebalance,
                         fechasistemabalance = entidad.fechasistemabalance,
                         estadobalance = entidad.estadobalance,
                         descripcioncb = entidad.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                         idscbalance = entidad.idscbalance,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechabalancebalance).Where(x => x.estadobalance == "A" && x.idscbalance == scm.idsc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    BalanceModelo temporal = new BalanceModelo
                    {
                        idCorrelativo = 0,
                        idbalance = 0,
                        idcb = 0,
                        idperiodos = 0,
                        fechabalancebalance = string.Empty,
                        fechasistemabalance = string.Empty,
                        estadobalance = "A",
                        descripcioncb = "Ninguno",
                        periodicidadperiodos = string.Empty,
                        idscbalance = 0,

                    };
                    foreach (BalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.claseBalanceModelo = ClaseBalanceModelo.Find(item.idcb);
                        item.periodoModelo = PeriodoModelo.Find(item.idperiodos);
                    }
                    lista.Insert(0, temporal);
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances \n" + e);
                }
                return null;
            }
        }

        public static List<BalanceModelo> GetAllForImportacion(string idCliente, int idSc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Select(entidad =>
                     new BalanceModelo
                     {
                         idbalance = entidad.idbalance,
                         idcb = entidad.idcb,
                         idperiodos = entidad.idperiodos,
                         fechabalancebalance = entidad.fechabalancebalance,
                         fechasistemabalance = entidad.fechasistemabalance,
                         estadobalance = entidad.estadobalance,
                         descripcioncb = entidad.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                         idscbalance = entidad.idscbalance,
                         idnitcliente=entidad.sistemascontable.idnitcliente,
                         descripcionTipoAuditoria=entidad.sistemascontable.encargo.tiposauditoria.descripcionta,
                         fechainiperauditencargo= entidad.sistemascontable.encargo.fechainiperauditencargo,
                         fechafinperauditencargo=entidad.sistemascontable.encargo.fechafinperauditencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechabalancebalance).Where(x => x.estadobalance == "A" && x.idnitcliente.Contains(idCliente) && x.idscbalance!=idSc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.claseBalanceModelo = ClaseBalanceModelo.Find(item.idcb);
                        item.periodoModelo = PeriodoModelo.Find(item.idperiodos);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances" + e.Message);
                }
                return null;
            }
        }


        public static List<BalanceModelo> GetAllForRiesto(string idCliente, int idSc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Select(entidad =>
                     new BalanceModelo
                     {
                         idbalance = entidad.idbalance,
                         idcb = entidad.idcb,
                         idperiodos = entidad.idperiodos,
                         fechabalancebalance = entidad.fechabalancebalance,
                         fechasistemabalance = entidad.fechasistemabalance,
                         estadobalance = entidad.estadobalance,
                         descripcioncb = entidad.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                         idscbalance = entidad.idscbalance,
                         idnitcliente = entidad.sistemascontable.idnitcliente,
                         descripcionTipoAuditoria = entidad.sistemascontable.encargo.tiposauditoria.descripcionta,
                         fechainiperauditencargo = entidad.sistemascontable.encargo.fechainiperauditencargo,
                         fechafinperauditencargo = entidad.sistemascontable.encargo.fechafinperauditencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechabalancebalance).Where(x => x.estadobalance == "A" && x.idnitcliente.Contains(idCliente) && x.idscbalance == idSc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BalanceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.claseBalanceModelo = ClaseBalanceModelo.Find(item.idcb);
                        item.periodoModelo = PeriodoModelo.Find(item.idperiodos);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<balance> GetAllCapaDatosByidperiodos(int idperiodos)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Where(entidad => (entidad.idperiodos == idperiodos && entidad.estadobalance == "A"));
                    ObservableCollection<balance> temporal = new ObservableCollection<balance>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<balance> GetAllCapaDatosByidSc(int idSc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.balances.Where(entidad => (entidad.idscbalance == idSc && entidad.estadobalance == "A"));
                    ObservableCollection<balance> temporal = new ObservableCollection<balance>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances \n" + e);
                }
                return null;
            }
        }
        public static List<BalanceModelo> GetAll(EncargoModelo Encargo)
        {
            try
            {

                SistemaContableModelo scm = SistemaContableModelo.GetRegistroByIdEncargo(Encargo.idencargo);
                //string commandString = string.Format("SELECT * FROM sgpt.balances WHERE idscbalance={0} ORDER BY ;", scm.idsc);
                //string commandString = string.Format("select* from sgpt.balances as b join sgpt.clasesbalance as cb on b.idcb = cb.idcb  join sgpt.periodos as p on p.idperiodos = b.idperiodos where b.idscbalance = 1 and b.estadobalance = 'A' order by fechabalancebalance;", scm.idsc);
                //var lista= _context.usuarios.SqlQuery(commandString).ToList();
                BalanceModelo temporal = new BalanceModelo();
                using (_context = new SGPTEntidades())
                {
                    //string commandString = string.Format("select * from sgpt.balances as b join sgpt.clasesbalance as cb on b.idcb = cb.idcb  join sgpt.periodos as p on p.idperiodos = b.idperiodos where b.idscbalance = 1 and b.estadobalance = 'A' order by fechabalancebalance;", scm.idsc);
                    /*string commandString = string.Format("select * from sgpt.balances idscbalance = {0} and estadobalance = 'A' order by fechabalancebalance;", scm.idsc);
                    ObservableCollection<BalanceModelo> listaCorregida = new ObservableCollection<BalanceModelo>();
                    var lista = _context.balances.SqlQuery(commandString).ToList();
                    foreach (balance entidad in lista)
                    {
                        temporal=new BalanceModelo
                        {
                            idbalance = entidad.idbalance,
                            idcb = entidad.idcb,
                            idperiodos = entidad.idperiodos,
                            fechabalancebalance = entidad.fechabalancebalance,
                            fechasistemabalance = entidad.fechasistemabalance,
                            estadobalance = entidad.estadobalance,
                            descripcioncb = entidad.clasesbalance.descripcioncb,
                            periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                            idscbalance = entidad.idscbalance,
                            //Lista filtrada de elementos que fueron eliminados
                        };
                        listaCorregida.Add(temporal);
                    }*/

                    var lista = _context.balances.Select(entidad =>
                    new BalanceModelo
                    {
                        idbalance = entidad.idbalance,
                        idcb = entidad.idcb,
                        idperiodos = entidad.idperiodos,
                        fechabalancebalance  = entidad.fechabalancebalance ,
                        fechasistemabalance = entidad.fechasistemabalance,
                        estadobalance = entidad.estadobalance,
                        descripcioncb = entidad.clasesbalance.descripcioncb,
                        periodicidadperiodos = entidad.periodo.periodicidadperiodos,
                        idscbalance = entidad.idscbalance,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.fechabalancebalance).Where(x => x.estadobalance == "A" && x.idscbalance== scm.idsc).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<BalanceModelo>();
                    }
                    else
                    {
                        //Obtener todas las listas de bitacora

                        int i = 1;
                        //Obtiene los registros existentes
                        ObservableCollection <BitacoraModelo> listaBitacora= new ObservableCollection<BitacoraModelo>(BitacoraModelo.GetAllByIdSc(scm.idsc, "BALANCES"));
                        foreach (BalanceModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //item.claseBalanceModelo = ElementoModelo.Find((int)item.idcb);
                            item.claseBalanceModelo = ClaseBalanceModelo.Find(item.idcb);
                            item.periodoModelo = PeriodoModelo.Find(item.idperiodos);
                            item.listaBitacora = new ObservableCollection<BitacoraModelo>(listaBitacora.Where(x => x.idtransaccionbitacora==item.idbalance));
                            if (item.listaBitacora.Count > 0)
                            {
                                item.inicialesusuariocb = item.listaBitacora.Last().inicialesusuariobitacora;
                                int k = 1;
                                foreach (BitacoraModelo itemB in item.listaBitacora)
                                {
                                    itemB.idCorrelativoBit = k;
                                    k++;
                                }
                            }
                        }
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista de balances " + e.Message + " fuente " + e.Source);
                var lista = new ObservableCollection<BalanceModelo>();
                return lista.ToList();
                throw;
            }
        }

        public static bool DeleteByIdProgramaRange(int? idperiodos)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.balances.Where(x => x.estadobalance == "A" && x.idperiodos == idperiodos);
                    var lista = (from p in _context.balances
                                 where p.idperiodos == idperiodos
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.balances.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista de balances " + e.Message + " fuente " + e.Source);
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
                    elementos = _context.balances.Where(x => x.idscbalance == id && x.estadobalance == "A").Count();
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
                    elementos = _context.balances.Where(x => x.idscbalance == id && x.estadobalance == "A").Count();
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
                    elementos = _context.balances.Where(x => x.estadobalance == "A").Count();
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

        public BalanceModelo()
        {

            idbalance = 0;
            idcb = 0;
            idperiodos = 0;
            fechabalancebalance  = MetodosModelo.homologacionFecha(); ;
            periodicidadperiodos = string.Empty;
            fechasistemabalance = MetodosModelo.homologacionFecha();
            estadobalance = "A";
            idbalance = 0;
            idcb = 0;
            idperiodos = 0;
            guardadoBase = false;
            IsSelected = false;
            idscbalance = 0;
        }
        public BalanceModelo(SistemaContableModelo sistemaContableModelo)
        {
            idbalance = 0;
            idcb = 0;
            idCorrelativo = 1;
            idperiodos = 0;
            idscbalance = sistemaContableModelo.idsc;
            fechabalancebalance  = string.Empty;
            periodicidadperiodos = string.Empty;
            fechasistemabalance = MetodosModelo.homologacionFecha();
            estadobalance = "A";
            guardadoBase = false;
            IsSelected = false;
            listaBitacora = new ObservableCollection<BitacoraModelo>();
        }
        public BalanceModelo(SistemaContableModelo sistemaContableModelo,UsuarioModelo usuario)
        {

            idbalance = 0;
            idcb = 0;
            idCorrelativo = 1;
            idperiodos = 0;
            idscbalance = sistemaContableModelo.idsc;
            fechabalancebalance = string.Empty;
            periodicidadperiodos = string.Empty;
            fechasistemabalance = MetodosModelo.homologacionFecha();
            estadobalance = "A";
            guardadoBase = false;
            IsSelected = false;
            usuarioModelo = usuario;
            listaBitacora = new ObservableCollection<BitacoraModelo>();
        }

        public BalanceModelo(BalanceModelo comun, BalanceModelo origen)
        {
            idbalance = 0;
            idcb = origen.idcb;
            idperiodos = comun.idperiodos;//Programa del que depende

            periodicidadperiodos = origen.periodicidadperiodos;
            fechasistemabalance = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadobalance = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
           //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia
            guardadoBase = false;
            IsSelected = false;
            listaBitacora = new ObservableCollection<BitacoraModelo>();
        }
    }

}
