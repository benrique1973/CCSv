using CapaDatos;
using SGPTWpf.Model.Modelo.Encargos;
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
using SGPTWpf.Model;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Supervision;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class BitacoraModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;



        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativoBit
        {
            get { return GetValue(() => idCorrelativoBit); }
            set { SetValue(() => idCorrelativoBit, value); }
        }
        public static bool sincronizar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idbitacora
        {
            get { return GetValue(() => idbitacora); }
            set { SetValue(() => idbitacora, value); }
        }

        //Vincula con el sistema contable asociado y asu vez con  el encargo
        public int? idusuariobitacora
        {
            get { return GetValue(() => idusuariobitacora); }
            set { SetValue(() => idusuariobitacora, value); }
        }

        public string fechahorabitacora
        {
            get { return GetValue(() => fechahorabitacora); }
            set { SetValue(() => fechahorabitacora, value); }
        }

        public string accionbitacora
        {
            get { return GetValue(() => accionbitacora); }
            set { SetValue(() => accionbitacora, value); }
        }

        //Identifica la tabla utilizada
        public string nombretablabitacora
        {
            get { return GetValue(() => nombretablabitacora); }
            set { SetValue(() => nombretablabitacora, value); }
        }

        //Registra la naturaleza del saldo de la cuenta: D= Deudor, A=Acreedor,  RD=Resultado deudor, RA=Resultado acreedor
        //Permite identificar el encargo, el catalogo, etc, segun la accion realizada
        public int? idgenericobitacora
        {
            get { return GetValue(() => idgenericobitacora); }
            set { SetValue(() => idgenericobitacora, value); }
        }

        public int? idtransaccionbitacora
        {
            get { return GetValue(() => idtransaccionbitacora); }
            set { SetValue(() => idtransaccionbitacora, value); }
        }
        //Muestra el detalle del contenido de la accion realizada
        public string detallebitacora
        {
            get { return GetValue(() => detallebitacora); }
            set { SetValue(() => detallebitacora, value); }
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

        public string inicialesusuariobitacora
        {
            get { return GetValue(() => inicialesusuariobitacora); }
            set { SetValue(() => inicialesusuariobitacora, value); }
        }

        #endregion


        #region Public Model Methods

        public static bool Insert(BitacoraModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.bitacora', 'idbitacora'), (SELECT MAX(idbitacora) FROM sgpt.bitacora) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new bitacora
                        {
                            //idbitacora = modelo.idbitacora,
                            idbitacora = modelo.idbitacora,
                            idusuariobitacora = modelo.idusuariobitacora,

                            fechahorabitacora = modelo.fechahorabitacora,
                            detallebitacora = modelo.detallebitacora,
                            idgenericobitacora = modelo.idgenericobitacora,
                            idtransaccionbitacora = modelo.idtransaccionbitacora,
                            accionbitacora = modelo.accionbitacora,
                            nombretablabitacora = modelo.nombretablabitacora,
                        };
                        _context.bitacoras.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idbitacora = tablaDestino.idbitacora;
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de bitacora: " + e.Message);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static int Insert(BitacoraModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.bitacora', 'idbitacora'), (SELECT MAX(idbitacora) FROM sgpt.bitacora) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new bitacora
                        {
                            //idbitacora = modelo.idbitacora,
                            idusuariobitacora = modelo.idusuariobitacora,
                            fechahorabitacora = modelo.fechahorabitacora,
                            detallebitacora = modelo.detallebitacora,
                            idgenericobitacora = modelo.idgenericobitacora,
                            idtransaccionbitacora = modelo.idtransaccionbitacora,
                            accionbitacora = modelo.accionbitacora,
                            nombretablabitacora = modelo.nombretablabitacora,
                        };
                        _context.bitacoras.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idbitacora = tablaDestino.idbitacora;
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de bitacora: \n" + e);
                    return -1;
                }
            }
            else
            {
                return result;
            }
        }


        public static void Insert(BitacoraModelo modelo, int evaluar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.bitacora', 'idbitacora'), (SELECT MAX(idbitacora) FROM sgpt.bitacora) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new bitacora
                        {
                            //idbitacora = modelo.idbitacora,
                            idusuariobitacora = modelo.idusuariobitacora,
                            fechahorabitacora = modelo.fechahorabitacora,
                            detallebitacora = modelo.detallebitacora,
                            idgenericobitacora = modelo.idgenericobitacora,
                            idtransaccionbitacora = modelo.idtransaccionbitacora,
                            accionbitacora = modelo.accionbitacora,
                            nombretablabitacora = modelo.nombretablabitacora,
                        };
                        _context.bitacoras.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idbitacora = tablaDestino.idbitacora;

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de bitacora: \n" + e);
                }
            }
        }


        public static int InsertByRange(ObservableCollection<bitacora> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.bitacora', 'idbitacora'), (SELECT MAX(idbitacora) FROM sgpt.bitacora) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.bitacoras.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de bitacora: " + e.Message);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static BitacoraModelo Find(int id)
        {
            var entidad = new BitacoraModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    bitacora modelo = _context.bitacoras.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idbitacora = modelo.idbitacora;
                        entidad.idbitacora = modelo.idbitacora;
                        entidad.idusuariobitacora = modelo.idusuariobitacora;
                        entidad.fechahorabitacora = modelo.fechahorabitacora;
                        entidad.detallebitacora = modelo.detallebitacora;
                        entidad.idtransaccionbitacora = modelo.idtransaccionbitacora;
                        entidad.accionbitacora = modelo.accionbitacora;
                        entidad.nombretablabitacora = modelo.nombretablabitacora;
                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                        entidad.idgenericobitacora = (int)modelo.idgenericobitacora;
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
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


        public static BitacoraModelo GetRegistro(string id)
        {
            try
            {
                int idBuscado = int.Parse(id);
                return BitacoraModelo.Find(idBuscado);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception en búsqueda de  registros: " + e.Message);
                return new BitacoraModelo();
                throw;
            }
        }

        public static BitacoraModelo GetRegistroById(int id)
        {
            try
            {
                return BitacoraModelo.Find(id);
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception en búsqueda de  registros: " + e.Message);
                return new BitacoraModelo();
                throw;
            }
        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new BitacoraModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    bitacora entidad = _context.bitacoras.Find(id);
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
                    var modelo = new BitacoraModelo();
                    bitacora entidad = _context.bitacoras.Find(id);
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
                    var modelo = new BitacoraModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.bitacoras
                            .Where(b => b.detallebitacora == "B")
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
                    bitacora entidad = _context.bitacoras.Find(id);
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

        public static void UpdateModelo(BitacoraModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    bitacora entidad = _context.bitacoras.Find(modelo.idbitacora);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        if(!(BitacoraModelo.Equals(modelo,entidad)))
                        { 
                        entidad.idbitacora = modelo.idbitacora;
                        entidad.idbitacora = modelo.idbitacora;
                        entidad.idusuariobitacora = modelo.idusuariobitacora;
                        entidad.fechahorabitacora = modelo.fechahorabitacora;
                        entidad.detallebitacora = modelo.detallebitacora;
                        entidad.idgenericobitacora = modelo.idgenericobitacora;
                        entidad.idtransaccionbitacora = modelo.idtransaccionbitacora;
                        entidad.accionbitacora = modelo.accionbitacora;
                        entidad.nombretablabitacora = modelo.nombretablabitacora;
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


        public static bool UpdateModelo(BitacoraModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bitacora entidad = _context.bitacoras.Find(modelo.idbitacora);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!BitacoraModelo.Equals(modelo,entidad))
                            {
                                //entidad.idbitacora = modelo.idbitacora;
                                entidad.idbitacora = modelo.idbitacora;
                                entidad.idusuariobitacora = modelo.idusuariobitacora;
                                entidad.fechahorabitacora = modelo.fechahorabitacora;
                                entidad.detallebitacora = modelo.detallebitacora;
                                entidad.idgenericobitacora = modelo.idgenericobitacora;
                                entidad.idtransaccionbitacora = modelo.idtransaccionbitacora;
                                entidad.accionbitacora = modelo.accionbitacora;
                                entidad.nombretablabitacora = modelo.nombretablabitacora;
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
                            string commandString = String.Format("UPDATE sgpt.bitacora SET detallebitacora = 'B' WHERE idbitacora={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.bitacora WHERE idbitacora={0};", id);
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

        public static void DeleteByTransaccion(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.bitacora WHERE idtransaccionbitacora={0};", id);
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

        public static void DeleteByTransaccion(int id, string tabla)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.bitacora WHERE idtransaccionbitacora={0} AND nombretablabitacora='{1}';", id,tabla);
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
        public static void DeleteByRange(ObservableCollection<bitacora> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.bitacoras.RemoveRange(lista);
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
                        string commandString = String.Format("DELETE FROM sgpt.bitacora WHERE idbitacora={0};", id);
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


        public static bool DeleteBorradoLogico(ObservableCollection<BitacoraModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    bitacora entidadTemporal = new bitacora();
                    int idusuariobitacora = (int)lista[0].idbitacora;
                    using (_context = new SGPTEntidades())
                    {
                        foreach (BitacoraModelo item in lista)
                        {
                            //entidadTemporal = _context.bitacoras.Find(item.idbitacora);
                            ////Borrado del catalogos
                            //entidadTemporal.detallebitacora = "B";
                            //_context.Entry(entidadTemporal).State = EntityState.Modified;

                            string commandString = String.Format("UPDATE sgpt.bitacora SET detallebitacora = 'B' WHERE idbitacora={0};",item.idbitacora);
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


        public static void DeleteBorradoLogicoByIdTransaccion(int id)
        {
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.bitacora SET detallebitacora = 'B' WHERE idtransaccionbitacora={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro de bitacoras: " + e.Message);
                        throw;
                    }
                }
            }
        }
        public static bool DeleteBorradoLogicoTotal(ObservableCollection<bitacora> lista, int idusuariobitacora)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.bitacora SET detallebitacora = 'B' WHERE idusuariobitacora = {0};", idusuariobitacora);
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
        public static explicit operator bitacora(BitacoraModelo modelo)  // explicit byte to digit conversion operator
        {
            bitacora entidad = new bitacora();
            entidad.idbitacora = modelo.idbitacora;
            entidad.idusuariobitacora = modelo.idusuariobitacora;
            entidad.fechahorabitacora = modelo.fechahorabitacora;
            entidad.detallebitacora = modelo.detallebitacora;
            entidad.idgenericobitacora = modelo.idgenericobitacora;
            entidad.idtransaccionbitacora = modelo.idtransaccionbitacora;
            entidad.accionbitacora = modelo.accionbitacora;
            entidad.nombretablabitacora = modelo.nombretablabitacora;
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

                            //Debe remover el  detalle del bitacora para no  dejar huerfanos

                            //Verificar que  no existan registros relacionados

                            string commandString = String.Format("DELETE FROM sgpt.bitacora WHERE idbitacora={0};", id);
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

        public static List<BitacoraModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.bitacoras.Select(entidad =>
                     new BitacoraModelo
                     {
                         idbitacora = entidad.idbitacora,
                         idusuariobitacora = entidad.idusuariobitacora,
                         fechahorabitacora = entidad.fechahorabitacora,
                         detallebitacora = entidad.detallebitacora,
                         idtransaccionbitacora = entidad.idtransaccionbitacora,
                         accionbitacora = entidad.accionbitacora,
                         nombretablabitacora = entidad.nombretablabitacora,
                         idgenericobitacora=entidad.idgenericobitacora,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idbitacora).Where(x => x.detallebitacora == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BitacoraModelo item in lista)
                    {
                        item.idCorrelativoBit = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
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
                    MessageBox.Show("Exception en elaboracion de lista de registros" + e.Message);
                }
                return null;
            }
        }

        public static List<BitacoraModelo> GetAllByIdSc(int idSc, string tabla)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.bitacoras.Select(entidad =>
                     new BitacoraModelo
                     {
                         idbitacora = entidad.idbitacora,
                         idusuariobitacora = entidad.idusuariobitacora,
                         fechahorabitacora = entidad.fechahorabitacora,
                         detallebitacora = entidad.detallebitacora,
                         idtransaccionbitacora = entidad.idtransaccionbitacora,
                         accionbitacora = entidad.accionbitacora,
                         nombretablabitacora = entidad.nombretablabitacora,
                         idgenericobitacora = entidad.idgenericobitacora,
                         inicialesusuariobitacora=entidad.usuario.inicialesusuario,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idbitacora).Where(x => x.idgenericobitacora== idSc && x.nombretablabitacora.Contains(tabla));
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BitacoraModelo item in lista)
                    {
                        item.idCorrelativoBit = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de registros" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<BitacoraModelo> GetAllByTabla(string tabla)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.bitacoras.Select(entidad =>
                     new BitacoraModelo
                     {
                         idbitacora = entidad.idbitacora,
                         idusuariobitacora = entidad.idusuariobitacora,
                         fechahorabitacora = entidad.fechahorabitacora,
                         detallebitacora = entidad.detallebitacora,
                         idtransaccionbitacora = entidad.idtransaccionbitacora,
                         accionbitacora = entidad.accionbitacora,
                         nombretablabitacora = entidad.nombretablabitacora,
                         idgenericobitacora = entidad.idgenericobitacora,
                         inicialesusuariobitacora = entidad.usuario.inicialesusuario,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idbitacora).Where(x =>  x.nombretablabitacora.Contains(tabla));
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (BitacoraModelo item in lista)
                    {
                        item.idCorrelativoBit = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<BitacoraModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de registros \n" + e);
                }
                return new ObservableCollection<BitacoraModelo>();
            }
        }
        public static ObservableCollection<bitacora> GetAllByTablaCapaDatos(string tabla)
        {
            try
            {
                //SistemaContableModelo scm = SistemaContableModelo.GetRegistroByIdEncargo(Encargo.idencargo);
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.bitacoras.Where(x => (x.nombretablabitacora.Contains(tabla)));
                    if (lista.Count() == 0)
                    {
                        return new ObservableCollection<bitacora>();
                    }
                    else
                    {
                        return new ObservableCollection<bitacora>(lista);
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista de registros \n" + e);
                return new ObservableCollection<bitacora>(); 
            }
        }

        public static bool DeleteByIdProgramaRange(int? idgenericobitacora)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.bitacoras.Where(x => x.detallebitacora == "A" && x.idusuariobitacora == idusuariobitacora);
                    var lista = (from p in _context.bitacoras
                                 where p.idgenericobitacora == idgenericobitacora
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.bitacoras.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista de registros " + e.Message + " fuente " + e.Source);
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
                    elementos = _context.bitacoras.Where(x => x.idgenericobitacora == id && x.detallebitacora == "A").Count();
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
                    elementos = _context.bitacoras.Where(x => x.idgenericobitacora == id && x.detallebitacora == "A").Count();
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
                    elementos = _context.bitacoras.Where(x => x.detallebitacora == "A").Count();
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

        public BitacoraModelo()
        {
            idbitacora = 0;
            idusuariobitacora = 0;
            accionbitacora = EtapaEncargoModelo.seleccionEtapa(1);
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            idbitacora = 0;
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = 0;
            idtransaccionbitacora = 0;
        }

        public BitacoraModelo(BalanceModelo modelo,string tabla,string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = EtapaEncargoModelo.seleccionEtapa(1);
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            //idgenericobitacora = 0;
            //idtransaccionbitacora = 0;
            idgenericobitacora = modelo.idscbalance;//Sistema contable
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idbalance;//Id del balance creado
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }
        public BitacoraModelo(MatrizRiesgoModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idmr;//Id de la matriz de riesgo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idmr;//Id de la matriz de riesgo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        internal static int evaluarEstado(MatrizRiesgoModelo currentEntidad, int etapaProceso, string tabla)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string etapa = EtapaEncargoModelo.seleccionEtapa(etapaProceso);
                    var elementos = (from p in _context.bitacoras
                                     where p.accionbitacora != etapa
                                     && p.idgenericobitacora == currentEntidad.idmr
                                     && p.nombretablabitacora.Contains(tabla)
                                     select p).ToList();
                    //elementos = _context.detalleprogramas.Where(x => x.estadoprocedimientodp != "I" && x.estadodp == "A").Count();
                    return elementos.Count();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros de bitacora \n " + e);
                return -1;//No podra borrar
            }

        }

        internal static string evaluarEstado(string tabla, int idRegistro)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var elementos = (from p in _context.bitacoras
                                     where p.idgenericobitacora == idRegistro
                                     && p.nombretablabitacora.Contains(tabla)
                                     select p).ToList().OrderBy(x=>x.idbitacora);
                    //elementos = _context.detalleprogramas.Where(x => x.estadoprocedimientodp != "I" && x.estadodp == "A").Count();
                    return elementos.Last().accionbitacora;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros de bitacora \n " + e);
                return "-1";//No podra borrar
            }

        }
        internal static bitacora ultimoRegistro(string tabla, int idRegistro)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var elementos = (from p in _context.bitacoras
                                     where p.idgenericobitacora == idRegistro
                                     && p.nombretablabitacora.Contains(tabla)
                                     select p).ToList().OrderBy(x => x.idbitacora);
                    //elementos = _context.detalleprogramas.Where(x => x.estadoprocedimientodp != "I" && x.estadodp == "A").Count();
                    return elementos.Last();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros de bitacora \n " + e);
                return new bitacora();//No podra borrar
            }

        }

        internal static string estadoRegistro(MatrizRiesgoModelo currentEntidad,string tabla)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var elementos = (from p in _context.bitacoras
                                     where p.idgenericobitacora == currentEntidad.idmr && p.nombretablabitacora.Contains(tabla)
                                     select p).ToList().OrderBy(x=>x.idbitacora);
                    //elementos = _context.detalleprogramas.Where(x => x.estadoprocedimientodp != "I" && x.estadodp == "A").Count();
                    string estado = elementos.LastOrDefault(x => x.idgenericobitacora == currentEntidad.idmr).accionbitacora;
                    return estado;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros de bitacora \n " + e);
                return "Error";//No podra borrar
            }

        }
        public BitacoraModelo(DetalleMatrizRiesgoModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idmr;//Id de la matriz de riesgo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idmr;//Id de la matriz de riesgo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(TipoCarpetaModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.id;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.id;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(EncargoModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idencargo;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idencargo;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(RepositorioModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idrepositorio;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idrepositorio;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(CedulaModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idcedula;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(DetalleCedulaModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idcc;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(CedulaMarcasModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idma;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(CedulaHallazgosModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idhallazgo;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(CedulaAgendaModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idagenda;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(CedulaPartidasModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idpartida;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public BitacoraModelo(CedulaNotasModelo modelo, string tabla, string accion)
        {
            idbitacora = 0;
            //idusuariobitacora = 0;
            accionbitacora = string.Empty;
            fechahorabitacora = MetodosModelo.homologacionFecha();
            detallebitacora = "A";
            guardadoBase = false;
            IsSelected = false;
            idgenericobitacora = modelo.idnotaspt;//Id de tipo carpeta modelo
            idusuariobitacora = modelo.usuarioModelo.idUsuario;//Usuario que realizo la operacion
            idtransaccionbitacora = modelo.idcedula;///Id de tipo carpeta modelo
            inicialesusuariobitacora = modelo.usuarioModelo.inicialesusuario;
            nombretablabitacora = tabla;
            guardadoBase = false;
            accionbitacora = accion;
            detallebitacora = string.Empty;
        }

        public static bool Equals(BitacoraModelo modelo, bitacora entidad)
        {
            if(modelo!=null && entidad !=null)
            { 
                if ((entidad.idbitacora == modelo.idbitacora)
                    && (entidad.idusuariobitacora == modelo.idusuariobitacora)
                    && (entidad.idgenericobitacora == modelo.idgenericobitacora)
                    && (entidad.idtransaccionbitacora == modelo.idtransaccionbitacora)
                    && (entidad.accionbitacora == modelo.accionbitacora)
                    && (entidad.nombretablabitacora == modelo.nombretablabitacora)
                    && (entidad.fechahorabitacora == modelo.fechahorabitacora)
                    && (entidad.detallebitacora == modelo.detallebitacora))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
