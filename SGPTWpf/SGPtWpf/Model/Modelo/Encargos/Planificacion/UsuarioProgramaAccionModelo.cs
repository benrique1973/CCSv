using CapaDatos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using SGPTWpf.Model.Modelo.programas;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Model;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion
{
    public class  UsuarioProgramaAccionModelo : UIBase
    {

        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }

        #region idupa
        public int _idupa;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código de acción")]
        public int idupa
        {
            get { return _idupa; }
            set { _idupa = value; }
        }

        #endregion
        //public int idprograma
        //{
        //    get { return GetValue(() => idprograma); }
        //    set { SetValue(() => idprograma, value); }
        //}

        #region idprograma
        public int _idprograma;
        public int idprograma
        {
            get { return _idprograma; }
            set { _idprograma = value; }
        }

        #endregion
        public Nullable<int> iddp
        {
            get { return GetValue(() => iddp); }
            set { SetValue(() => iddp, value); }
        }

        public Nullable<int> idusuarioupa
        {
            get { return GetValue(() => idusuarioupa); }
            set { SetValue(() => idusuarioupa, value); }
        }

        //public string rolupa
        //{
        //    get { return GetValue(() => rolupa); }
        //    set { SetValue(() => rolupa, value); }
        //}

        #region rolupa
        public string _rolupa;
        public string rolupa
        {
            get { return _rolupa; }
            set { _rolupa = value; }
        }

        #endregion
        public string fechacreadoupa
        {
            get { return GetValue(() => fechacreadoupa); }
            set { SetValue(() => fechacreadoupa, value); }
        }

        public string estadoupa
        {
            get { return GetValue(() => estadoupa); }
            set { SetValue(() => estadoupa, value); }
        }

        public Nullable<int> iddcupa
        {
            get { return GetValue(() => iddcupa); }
            set { SetValue(() => iddcupa, value); }
        }

        #region entidades de soporte

        //public virtual RolUsuarioModelo rolUsuarioModelo
        //{
        //    get { return GetValue(() => rolUsuarioModelo); }
        //    set { SetValue(() => rolUsuarioModelo, value); }
        //}
        #region rolUsuarioModelo
        public  RolUsuarioModelo _rolUsuarioModelo;

        public RolUsuarioModelo rolUsuarioModelo
        {
            get { return _rolUsuarioModelo; }
            set { _rolUsuarioModelo = value; }
        }

        #endregion

        public string nombreRolUpa
        {
            get { return GetValue(() => nombreRolUpa); }
            set { SetValue(() => nombreRolUpa, value); }
        }
        public string nombreUsuario
        {
            get { return GetValue(() => nombreUsuario); }
            set { SetValue(() => nombreUsuario, value); }
        }
        #endregion
        public string ambitoBitacora
        {
            get { return GetValue(() => ambitoBitacora); }
            set { SetValue(() => ambitoBitacora, value); }
        }

        public int? idencargo   {  get { return GetValue(() => idencargo); }  set { SetValue(() => idencargo, value); }}

        #endregion

        //Propiedades de presentacion

        public static bool Insert(UsuarioProgramaAccionModelo modelo, int idencargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarioprogramasaccion', 'idupa'), (SELECT MAX(idupa) FROM sgpt.usuarioprogramasaccion) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new usuarioprogramasaccion
                        {
                            //idupa = modelo.idupa,
                            idprograma = modelo.idprograma,
                            iddp = modelo.iddp,
                            idusuarioupa = modelo.idusuarioupa,
                            rolupa = modelo.rolupa,
                            fechacreadoupa = modelo.fechacreadoupa,
                            estadoupa = modelo.estadoupa,
                            iddcupa = modelo.iddcupa,
                            idencargo=idencargo
                        };
                        //Registro de creación
                        _context.usuarioprogramasaccions.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idupa = tablaDestino.idupa;
                        //Creación de registro auxiliar de acción realizada
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar usuario programas accion : " + e.Message);
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static bool InsertByPrograma(UsuarioProgramaAccionModelo modelo, int idEncargo)
        {
            bool result = false;
            if (!(modelo == null))
            {
                try
                {
                    modelo.fechacreadoupa = MetodosModelo.homologacionFecha();
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarioprogramasaccion', 'idupa'), (SELECT MAX(idupa) FROM sgpt.usuarioprogramasaccion) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new usuarioprogramasaccion
                        {
                            //idupa = modelo.idupa,
                            idprograma = modelo.idprograma,
                            //iddp = modelo.iddp,
                            idusuarioupa = modelo.idusuarioupa,
                            rolupa = modelo.rolupa,
                            fechacreadoupa = modelo.fechacreadoupa,
                            estadoupa = modelo.estadoupa,
                            idencargo=idEncargo,
                            //iddcupa = modelo.iddcupa,
                        };
                        //Registro de creación
                        _context.usuarioprogramasaccions.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idupa = tablaDestino.idupa;
                        //Creación de registro auxiliar de acción realizada
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar usuario programas accion : " + e.Message);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        public static bool InsertByDetallePrograma(UsuarioProgramaAccionModelo modelo,int idencargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarioprogramasaccion', 'idupa'), (SELECT MAX(idupa) FROM sgpt.usuarioprogramasaccion) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new usuarioprogramasaccion
                        {
                            //idupa = modelo.idupa,
                            idprograma = modelo.idprograma,
                            iddp = modelo.iddp,
                            idusuarioupa = modelo.idusuarioupa,
                            rolupa = modelo.rolupa,
                            fechacreadoupa = modelo.fechacreadoupa,
                            estadoupa = modelo.estadoupa,
                            idencargo=idencargo
                            //iddcupa = modelo.iddcupa,
                        };
                        //Registro de creación
                        _context.usuarioprogramasaccions.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idupa = tablaDestino.idupa;
                        //Creación de registro auxiliar de acción realizada
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar usuario programas accion : " + e.Message);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static bool InsertByCuestionarioPrograma(UsuarioProgramaAccionModelo modelo, int idencargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarioprogramasaccion', 'idupa'), (SELECT MAX(idupa) FROM sgpt.usuarioprogramasaccion) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new usuarioprogramasaccion
                        {
                            //idupa = modelo.idupa,
                            idprograma = modelo.idprograma,
                            //iddp = modelo.iddp,
                            idusuarioupa = modelo.idusuarioupa,
                            rolupa = modelo.rolupa,
                            fechacreadoupa = modelo.fechacreadoupa,
                            estadoupa = modelo.estadoupa,
                            iddcupa = modelo.iddcupa,
                            idencargo=idencargo,
                        };
                        //Registro de creación
                        _context.usuarioprogramasaccions.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idupa = tablaDestino.idupa;
                        //Creación de registro auxiliar de acción realizada
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar usuario programas accion : " + e);
                    return false;
                    //throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        //Devuelve el registro buscado con base al indice
        public static UsuarioProgramaAccionModelo GetRegistro(int id)
        {
            var entidad = new UsuarioProgramaAccionModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    usuarioprogramasaccion modelo = _context.usuarioprogramasaccions.Find(id);
                    if (modelo == null)
                    {
                        entidad = null;
                    }
                    else
                    {
                        entidad.idupa = modelo.idupa;
                        entidad.idprograma = modelo.idprograma;
                        entidad.iddp = modelo.iddp;
                        entidad.idusuarioupa = modelo.idusuarioupa;
                        entidad.rolupa = modelo.rolupa;
                        entidad.fechacreadoupa = modelo.fechacreadoupa;
                        entidad.estadoupa = modelo.estadoupa;
                        entidad.iddcupa = modelo.iddcupa;
                        entidad.idencargo = modelo.idencargo;

                    }
                }
                entidad.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(entidad.rolupa);
                entidad.nombreRolUpa = entidad.rolUsuarioModelo.nombreRolUsuario;
                return entidad;
            }
            else
            {
                return entidad = null;
            }
        }

        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.usuarioprogramasaccion WHERE idupa={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
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
                    usuarioprogramasaccion entidad = _context.usuarioprogramasaccions.Find(id);
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
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.usuarioprogramasaccions
                            .Where(b => b.estadoupa == "B")
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
        public static bool UpdateModelo(UsuarioProgramaAccionModelo modelo)
        {

            bool cambio = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        usuarioprogramasaccion entidad = _context.usuarioprogramasaccions.Find(modelo.idupa);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {

                            //entidad.idupa = modelo.idupa;
                            if (!(entidad.iddp == modelo.iddp))
                            {
                                cambio = true;
                            }
                            else
                            {
                                if (!(entidad.idprograma == modelo.idprograma))
                                {
                                    cambio = true;
                                }
                            }
                            if (cambio)
                            {

                                entidad.idupa = modelo.idupa;
                                entidad.idprograma = modelo.idprograma;
                                entidad.iddp = modelo.iddp;
                                entidad.idusuarioupa = modelo.idusuarioupa;
                                entidad.rolupa = modelo.rolupa;
                                entidad.fechacreadoupa = modelo.fechacreadoupa;
                                entidad.estadoupa = modelo.estadoupa;
                                entidad.iddcupa = modelo.iddcupa;
                                //Creación de registro auxiliar de acción realizada
                            }
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar usuario programas accion : " + e.Message);
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id)
        {
            //Permite controlar hacer guardado, únicamente cuando se ha modificado algo en los registros
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.usuarioprogramasaccion SET estadoupa = 'B' WHERE idupa={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //usuarioprogramasaccion entidad = _context.usuarioprogramasaccions.Find(id);
                            ////eliminacion del padre
                            //entidad.estadoupa = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

                }
            }
            else
            {
                return result;
            }
        }

        public static bool DeleteBorradoLogicoByIdPrograma(int id)
        {
            //Permite controlar hacer guardado, únicamente cuando se ha modificado algo en los registros
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.usuarioprogramasaccion SET estadoupa = 'B' WHERE idprograma={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

                }
            }
            else
            {
                return result;
            }
        }

        public static bool DeleteBorradoLogico(string id, Boolean actualizar)
        {
            bool result = false;
            if (!((string.IsNullOrEmpty(id)) || string.IsNullOrWhiteSpace(id)))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.usuarioprogramasaccion SET estadoupa = 'B' WHERE idupa={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

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
                if (!(id == 0))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.usuarioprogramasaccion WHERE idupa={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception en borrar registro de usuario  programa accion modelo del detalle de  programa: " + e.Message);
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.usuarioprogramasaccion WHERE idupa={0};", id);
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
                        MessageBox.Show("Exception en borrar registro de usuarioprogramasaccion : " + e.Message);
                    throw;
                }

            }
            else
            {
                return false;
            }
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
                            string commandString = String.Format("DELETE FROM sgpt.usuarioprogramasaccion WHERE idupa={0};", id);
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

        public static List<UsuarioProgramaAccionModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                      new UsuarioProgramaAccionModelo
                      {
                          idupa = entidad.idupa,
                          idprograma = entidad.idprograma,
                          iddp = entidad.iddp,
                          idusuarioupa = entidad.idusuarioupa,
                          rolupa = entidad.rolupa,
                          fechacreadoupa = entidad.fechacreadoupa,
                          estadoupa = entidad.estadoupa,
                          iddcupa = entidad.iddcupa,
                          idencargo=entidad.idencargo,
                          //Lista filtrada de elementos que fueron eliminados
                      }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A");
                    //La ordena por el idupa notar la notacion
                    int i = 1;
                    foreach (UsuarioProgramaAccionModelo item in lista)
                    {
                        item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                        item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                        item.idCorrelativo = i;
                        i++;
                    }
                    return lista.ToList();
                }

            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de usuario programas accions " + e.Message);
                }
                return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
            }
        }

        public static ObservableCollection<UsuarioProgramaAccionModelo> GetAll(int idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                      new UsuarioProgramaAccionModelo
                      {
                          idupa = entidad.idupa,
                          idprograma = entidad.idprograma,
                          iddp = entidad.iddp,
                          idusuarioupa = entidad.idusuarioupa,
                          rolupa = entidad.rolupa,
                          fechacreadoupa = entidad.fechacreadoupa,
                          estadoupa = entidad.estadoupa,
                          iddcupa = entidad.iddcupa,
                          nombreUsuario=entidad.usuario.inicialesusuario,
                          idencargo=entidad.idencargo,
                          //Lista filtrada de elementos que fueron eliminados
                      }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A" && x.idprograma== idPrograma);
                    //La ordena por el idupa notar la notacion
                    ObservableCollection<UsuarioProgramaAccionModelo> temporal = new ObservableCollection<UsuarioProgramaAccionModelo>(lista);
                    int i = 1;
                    foreach (UsuarioProgramaAccionModelo item in temporal)
                    {
                        item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                        item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                        item.idCorrelativo = i;
                        if (item.iddp != null && item.iddp!=0)
                        {
                            item.ambitoBitacora = "Realizado  en el detalle";
                        }
                        i++;
                    }
                    return temporal;
                }

            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de usuario programas acciones \n" + e);
                }
                return new ObservableCollection<UsuarioProgramaAccionModelo>();
            }
        }
        public static bool DeleteByProgramaRange(int? idprograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {

                    string commandString = String.Format("DELETE FROM sgpt.usuarioprogramasaccion WHERE idprograma={0};", idprograma);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    return true;

                    ////fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    ////var lista = _context.usuarioprogramasaccions.Where(x => x.estadoupa == "A" && x.idprograma == idprograma).ToList();
                    //var lista = (from p in _context.usuarioprogramasaccions
                    // where p.idprograma == idprograma
                    // select p);
                    //if (lista.Count() == 0)
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    _context.usuarioprogramasaccions.RemoveRange(lista);
                    //    _context.SaveChanges();
                    //    return true;
                    //}
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                MessageBox.Show("Exception en eliminacion de lista de usuario programas accions" + e.Message + " " + e.Source);
                return false;
                //return null;
            }
        }


        public static List<UsuarioProgramaAccionModelo> GetAllByPrograma(int? idprograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                     new UsuarioProgramaAccionModelo
                     {
                         idupa = entidad.idupa,
                         idprograma = entidad.idprograma,
                         iddp = entidad.iddp,
                         idusuarioupa = entidad.idusuarioupa,
                         rolupa = entidad.rolupa,
                         fechacreadoupa = entidad.fechacreadoupa,
                         estadoupa = entidad.estadoupa,
                         iddcupa = entidad.iddcupa,
                         idencargo=entidad.idencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A" && x.idprograma == idprograma).ToList();
                    int i = 1;
                    foreach (UsuarioProgramaAccionModelo item in lista)
                    {
                        item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                        item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                        item.idCorrelativo = i;
                        i++;
                    }
                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de usuario programas accions" + e.Message + " " + e.Source);
                return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                //return null;
            }
        }

        public static List<UsuarioProgramaAccionModelo> GetAllByDetallePrograma(int iddp)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                     new UsuarioProgramaAccionModelo
                     {
                         idupa = entidad.idupa,
                         idprograma = entidad.idprograma,
                         iddp = entidad.iddp,
                         idusuarioupa = entidad.idusuarioupa,
                         rolupa = entidad.rolupa,
                         fechacreadoupa = entidad.fechacreadoupa,
                         estadoupa = entidad.estadoupa,
                         iddcupa = entidad.iddcupa,
                         nombreUsuario=entidad.usuario.inicialesusuario,
                         idencargo=entidad.idencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A" && x.iddp == iddp).ToList();
                    if (lista.Count() >= 1)
                    {
                        int i = 1;
                        foreach (UsuarioProgramaAccionModelo item in lista)
                        {
                            item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                            item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                            item.idCorrelativo = i;
                            i++;
                        }
                        return lista.ToList();
                    }
                    else
                    {
                        return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de usuario programas accions" + e.Message + " " + e.Source);
                return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                //return null;
            }
        }

        public static List<UsuarioProgramaAccionModelo> GetAllListaByDetallePrograma(int? idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                     new UsuarioProgramaAccionModelo
                     {
                         idupa = entidad.idupa,
                         idprograma = entidad.idprograma,
                         iddp = entidad.iddp,
                         idusuarioupa = entidad.idusuarioupa,
                         rolupa = entidad.rolupa,
                         fechacreadoupa = entidad.fechacreadoupa,
                         estadoupa = entidad.estadoupa,
                         iddcupa = entidad.iddcupa,
                         nombreUsuario = entidad.usuario.inicialesusuario,
                         idencargo=entidad.idencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A" && x.idprograma == idPrograma).ToList();
                    if (lista.Count() >= 1)
                    {
                        int i = 1;
                        foreach (UsuarioProgramaAccionModelo item in lista)
                        {
                            item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                            item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                            item.idCorrelativo = i;
                            i++;
                        }
                        return lista.ToList();
                    }
                    else
                    {
                        return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de usuario programas accions" + e.Message + " " + e.Source);
                return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                //return null;
            }
        }
        public static UsuarioProgramaAccionModelo GetRegistroByPrograma(int idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                    new UsuarioProgramaAccionModelo
                    {
                        idupa = entidad.idupa,
                        idprograma = entidad.idprograma,
                        iddp = entidad.iddp,
                        idusuarioupa = entidad.idusuarioupa,
                        rolupa = entidad.rolupa,
                        fechacreadoupa = entidad.fechacreadoupa,
                        estadoupa = entidad.estadoupa,
                        iddcupa = entidad.iddcupa,
                        nombreUsuario = entidad.usuario.inicialesusuario,
                        idencargo=entidad.idencargo,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.idprograma == idPrograma).Where(x => x.estadoupa == "A" ).OrderBy(x=>x.idupa).ToList();
                    if (lista.Count >= 1)
                    {
                        UsuarioProgramaAccionModelo registro = new UsuarioProgramaAccionModelo();
                        registro = lista.Where(x => x.iddp == null && x.iddcupa == null).LastOrDefault();

                        if (!(registro==null))
                        {
                            registro.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(registro.rolupa);
                            registro.nombreRolUpa = registro.rolUsuarioModelo.nombreRolUsuario;
                        }
                        return registro;
                    }
                    else
                    {
                        return new UsuarioProgramaAccionModelo(); ;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del encargo " + e.Message);
                }
                return null;
            }
        }
        public static List<UsuarioProgramaAccionModelo> GetAllByDetalleCuestionario(int iddcupa)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                     new UsuarioProgramaAccionModelo
                     {
                         idupa = entidad.idupa,
                         idprograma = entidad.idprograma,
                         iddp = entidad.iddp,
                         idusuarioupa = entidad.idusuarioupa,
                         rolupa = entidad.rolupa,
                         fechacreadoupa = entidad.fechacreadoupa,
                         estadoupa = entidad.estadoupa,
                         iddcupa = entidad.iddcupa,
                         nombreUsuario = entidad.usuario.inicialesusuario,
                         idencargo=entidad.idencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A" && x.iddcupa == iddcupa).ToList();
                    if (lista.Count() >= 1)
                    {
                        int i = 1;
                        foreach (UsuarioProgramaAccionModelo item in lista)
                        {
                            item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                            item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                            item.idCorrelativo = i;
                            i++;
                        }
                        return lista.ToList();
                    }
                    else
                    {
                        return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de usuario programas accions" + e.Message + " " + e.Source);
                return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                //return null;
            }
        }


        #region Contar registros
        public static int ContarRegistros(int? idprograma)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.usuarioprogramasaccions.Where(x => x.idprograma == idprograma && x.estadoupa == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros de usuarioprogramasaccions: " + e.Message);
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
                    elementos = _context.usuarioprogramasaccions.Where(x => x.estadoupa == "A").Count();
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


        #region Constructor

        public UsuarioProgramaAccionModelo()
        {
            idupa = 0;
            idprograma = 0;
            //iddp = 0;
            idusuarioupa = 0;
            rolupa = "C";
            fechacreadoupa= MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoupa = "A";
            //iddcupa = 0;
            rolUsuarioModelo = RolUsuarioModelo.GetRegistro(rolupa);
            nombreRolUpa = rolUsuarioModelo.nombreRolUsuario;
            idencargo = null;
        }

        public UsuarioProgramaAccionModelo(int idDp)
        {
            idupa = 0;
            idprograma = 0;
            iddp = idDp;
            idusuarioupa = 0;
            rolupa = "C";
            fechacreadoupa = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoupa = "A";
            //iddcupa = 0;
            rolUsuarioModelo = RolUsuarioModelo.GetRegistro(rolupa);
            nombreRolUpa = rolUsuarioModelo.nombreRolUsuario;
        }

        public UsuarioProgramaAccionModelo(ProgramaModelo item)
        {
            idupa = 0;
            idprograma = item.idprograma;
            //iddp = null;
            idusuarioupa = 0;
            rolupa = "C";
            fechacreadoupa = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoupa = "A";
            //iddcupa = 0;
            rolUsuarioModelo = RolUsuarioModelo.GetRegistro(rolupa);
            nombreRolUpa = rolUsuarioModelo.nombreRolUsuario;
            idencargo = item.idencargoprograma;
        }

        internal static List<UsuarioProgramaAccionModelo> GetAllByEncargo(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.usuarioprogramasaccions.Select(entidad =>
                     new UsuarioProgramaAccionModelo
                     {
                         idupa = entidad.idupa,
                         idprograma = entidad.idprograma,
                         iddp = entidad.iddp,
                         idusuarioupa = entidad.idusuarioupa,
                         rolupa = entidad.rolupa,
                         fechacreadoupa = entidad.fechacreadoupa,
                         estadoupa = entidad.estadoupa,
                         iddcupa = entidad.iddcupa,
                         nombreUsuario = entidad.usuario.inicialesusuario,
                         idencargo = entidad.idencargo,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idupa).Where(x => x.estadoupa == "A" && x.idencargo == idEncargo).ToList();
                    if (lista.Count() >= 1)
                    {
                        int i = 1;
                        foreach (UsuarioProgramaAccionModelo item in lista)
                        {
                            item.rolUsuarioModelo = RolUsuarioModelo.GetRegistro(item.rolupa);
                            item.nombreRolUpa = item.rolUsuarioModelo.nombreRolUsuario;
                            item.idCorrelativo = i;
                            i++;
                        }
                        return lista.ToList();
                    }
                    else
                    {
                        return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                MessageBox.Show("Exception en elaboracion de lista de usuario programas accions \n" + e);
                return new ObservableCollection<UsuarioProgramaAccionModelo>().ToList();
                //return null;
            }

        }
        #endregion
    }

}




