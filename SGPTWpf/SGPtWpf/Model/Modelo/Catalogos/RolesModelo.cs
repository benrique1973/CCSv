using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model
{
    public class RolModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        #region Model Properties

        public static bool sincronizar { get; set; }


        [DisplayName("Codigo")]
        public int id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(20, ErrorMessage = "Excede de 20 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripcion
        {
            get { return GetValue(() => descripcion); }
            set { SetValue(() => descripcion, value); }
        }
        [DisplayName("Sistema")]
        public bool sistema
        {
            get { return GetValue(() => sistema); }
            set { SetValue(() => sistema, value); }
        }
        [DisplayName("Estado")]
        public string estado
        {
            get { return GetValue(() => estado); }
            set { SetValue(() => estado, value); }
        }
        public virtual ICollection<opcionesrole> opcionesroles
        {
            get { return GetValue(() => opcionesroles); }
            set { SetValue(() => opcionesroles, value); }
        }

        public virtual ICollection<permisosrolesusuario> permisosrolesusuarios
        {
            get { return GetValue(() => permisosrolesusuarios); }
            set { SetValue(() => permisosrolesusuarios, value); }
        }
        public virtual ICollection<usuario> usuarios
        {
            get { return GetValue(() => usuarios); }
            set { SetValue(() => usuarios, value); }
        }
        //public virtual ICollection<opcionesroles> opcionesroles { get; set; }

        [DisplayName("Nombre Rol")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(100, ErrorMessage = "Excede de 100 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripcionrol
        {
            get { return GetValue(() => descripcionrol); }
            set { SetValue(() => descripcionrol, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(RolModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.roles', 'idrol'), (SELECT MAX(idrol) FROM sgpt.roles) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new role
                        {
                            //idrol = modelo.id,
                            nombrerol = modelo.descripcion,
                            descripcionrol = modelo.descripcionrol,
                            sistemarol = false,
                            estadorol = "A"
                        };
                        _context.roles.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idrol;
                        modelo.sistema = tablaDestino.sistemarol;
                        modelo.estado = tablaDestino.estadorol;
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : {0}", e.Source);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(RolModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.roles', 'idrol'), (SELECT MAX(idrol) FROM sgpt.roles) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new role
                        {
                            //idrol = modelo.id,
                            nombrerol = modelo.descripcion,
                            descripcionrol = modelo.descripcionrol,
                            sistemarol = false,
                            estadorol = "A"
                        };
                        _context.roles.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idrol;
                        modelo.sistema = tablaDestino.sistemarol;
                        modelo.estado = tablaDestino.estadorol;
                        result = tablaDestino.idrol.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : {0}", e.Source);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static int IdAsignar()
        {
            int idrol = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idrol = _context.roles.Max(x => x.idrol) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idrol;
        }

        //Devuelve el registro buscado con base al indice
        public static RolModelo Find(int id)
        {
            var entidadModelo = new RolModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    role entidad = _context.roles.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idrol;
                        entidadModelo.descripcion = entidad.nombrerol;
                        entidadModelo.descripcionrol = entidad.descripcionrol;
                        entidadModelo.sistema = entidad.sistemarol;
                        entidadModelo.estado = entidad.estadorol;
                        return entidadModelo;
                    }
                }
            }
            else
            {
                return entidadModelo = null;
            }

        }

        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.roles WHERE idrol={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //role entidad = _context.roles.Find(id);
                    //_context.roles.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static RolModelo Find(string id)
        {
            var modelo = new RolModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    role entidad = _context.roles.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idrol;
                        modelo.descripcion = entidad.nombrerol;
                        modelo.descripcionrol = entidad.descripcionrol;
                        modelo.sistema = entidad.sistemarol;
                        modelo.estado = entidad.estadorol;

                        return modelo;
                    }
                }
            }
            else
            {
                return modelo;
            }

        }


        public static int FindIdRolBase(int? id)
        {
            try {
                int modelo = 0;
                if (id != null && id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        role rolBuscado = new role();
                        string commandString = string.Format("SELECT * FROM sgpt.roles WHERE idrol='{0}';", id);
                        rolBuscado = _context.roles.SqlQuery(commandString).FirstOrDefault();
                        if (rolBuscado == null)
                        {
                            return 0;
                        }
                        else
                        {
                            modelo = (int)rolBuscado.basadoenrol;
                            return modelo;
                        }
                    }
                }
                else
                {
                    return modelo;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al recuperar rol \n" + e);
                return 0;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new RolModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    role entidad = _context.roles.Find(id);
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
        public static bool FindPK(string id, Boolean eliminado)
        {
            if (!(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new RolModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.roles
                            .Where(b => b.estadorol == "B")
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
                    role entidad = _context.roles.Find(id);
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
        //Para realizar busquedas de texto
        public static List<RolModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.roles.Select(entidad =>
                new RolModelo
                {
                    id = entidad.idrol,
                    descripcion = entidad.nombrerol,
                    descripcionrol = entidad.descripcionrol,
                    sistema = entidad.sistemarol,
                    estado = entidad.estadorol
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.id).Where(x => x.descripcion.ToUpper() == Texto).ToList();
                //La ordena por el ID notar la notacion
            }

        }
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.roles
                            .Where(b => b.estadorol == "B")
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

        public static void UpdateModelo(RolModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    role entidad = _context.roles.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idrol = modelo.id;
                        entidad.descripcionrol = modelo.descripcionrol;
                        entidad.nombrerol = modelo.descripcion;
                        entidad.sistemarol = modelo.sistema;
                        entidad.estadorol = modelo.estado;
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

        public static bool UpdateModelo(RolModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        role entidad = _context.roles.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idrol = modelo.id;
                            entidad.nombrerol = modelo.descripcion;
                            entidad.descripcionrol = modelo.descripcionrol;
                            entidad.sistemarol = modelo.sistema;
                            entidad.estadorol = modelo.estado;
                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                            return true;
                        }

                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar : {0}", e.Source);
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
                            string commandString = String.Format("UPDATE sgpt.roles SET estadorol = 'B' WHERE idrol={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //role entidad = _context.roles.Find(id);
                            //entidad.estadorol = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : \n"+ e);
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
                            string commandString = String.Format("UPDATE sgpt.roles SET estadorol = 'B' WHERE idrol={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //role entidad = _context.roles.Find(id);
                            //entidad.estadorol = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : \n"+ e);
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
            if (id == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.roles WHERE idrol={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
            else
            {
                //No regresa nada
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
                        string commandString = String.Format("DELETE FROM sgpt.roles WHERE idrol={0};", id);
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
                        MessageBox.Show("Exception en borrar registro : \n"+ e);
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
                            string commandString = String.Format("DELETE FROM sgpt.roles WHERE idrol={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : \n"+ e);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<RolModelo> GetAll()
        {
            List<RolModelo> r = new List<RolModelo>();
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.roles.Select(entidad =>
                    new RolModelo
                    {
                        id = entidad.idrol,
                        descripcion = entidad.nombrerol,
                        descripcionrol = entidad.descripcionrol,
                        sistema = entidad.sistemarol,
                        estado = entidad.estadorol
                        //Lista filtrada de elementos que fueron eliminados y de valores que no son sistema
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").Where(x => x.sistema == false).ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Error en la recuperacion del listado de rol ");
                return r;
            }
           
        }

        #endregion

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.roles
                                   where p.descripcionrol.ToLower().Equals(busqueda)
                                   select p).FirstOrDefault();
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

        #endregion
    }

}
