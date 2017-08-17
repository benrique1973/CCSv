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
    public class RequerimientoModelo : UIBase
    {
        #region Model Attributes


        public static bool sincronizar { get; set; }

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Codigo")]
        public int id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(100, ErrorMessage = "Excede de 100 caracteres permitidos")]
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
        [DisplayName("Orden")]
        [Required(ErrorMessage = "Debe darle un orden de presentación")]
        public Nullable<decimal> ordenrequerimiento
        {
            get { return GetValue(() => ordenrequerimiento); }
            set { SetValue(() => ordenrequerimiento, value); }
        }
        public virtual ICollection<usuariorequerimientosaccion> usuariorequerimientosaccions
        {
            get { return GetValue(() => usuariorequerimientosaccions); }
            set { SetValue(() => usuariorequerimientosaccions, value); }
        }


        //public virtual ICollection<usuariorequerimientosaccions> usuariorequerimientosaccions { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(RequerimientoModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.requerimientos', 'idrequerimiento'), (SELECT MAX(idrequerimiento) FROM sgpt.requerimientos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new requerimiento
                        {
                            //idrequerimiento = modelo.id,
                            descripcionrequerimiento = modelo.descripcion,
                            ordenrequerimiento = modelo.ordenrequerimiento,
                            sistemarequerimiento = false,
                            estadorequerimiento = "A"
                        };
                        _context.requerimientos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idrequerimiento;
                        modelo.sistema = tablaDestino.sistemarequerimiento;
                        modelo.estado = tablaDestino.estadorequerimiento;
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

        public static string Insert(RequerimientoModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.requerimientos', 'idrequerimiento'), (SELECT MAX(idrequerimiento) FROM sgpt.requerimientos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new requerimiento
                        {
                            //idrequerimiento = modelo.id,
                            descripcionrequerimiento = modelo.descripcion,
                            ordenrequerimiento = modelo.ordenrequerimiento,
                            sistemarequerimiento = false,
                            estadorequerimiento = "A"
                        };
                        _context.requerimientos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idrequerimiento;
                        modelo.sistema = tablaDestino.sistemarequerimiento;
                        modelo.estado = tablaDestino.estadorequerimiento;
                        result = tablaDestino.idrequerimiento.ToString();
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
            int idrequerimiento = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idrequerimiento = _context.requerimientos.Max(x => x.idrequerimiento) + 1;
                    //idrequerimiento = _context.requerimientos.Count() + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idrequerimiento;
        }

        //Devuelve el registro buscado con base al indice
        public static RequerimientoModelo Find(int id)
        {
            var entidadModelo = new RequerimientoModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    requerimiento entidad = _context.requerimientos.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idrequerimiento;
                        entidadModelo.descripcion = entidad.descripcionrequerimiento;
                        entidadModelo.ordenrequerimiento = entidad.ordenrequerimiento;
                        entidadModelo.sistema = entidad.sistemarequerimiento;
                        entidadModelo.estado = entidad.estadorequerimiento;
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
                    string commandString = String.Format("DELETE FROM sgpt.requerimientos WHERE idrequerimiento={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //requerimiento entidad = _context.requerimientos.Find(id);
                    //_context.requerimientos.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static RequerimientoModelo Find(string id)
        {
            var modelo = new RequerimientoModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    requerimiento entidad = _context.requerimientos.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idrequerimiento;
                        modelo.descripcion = entidad.descripcionrequerimiento;
                        modelo.sistema = entidad.sistemarequerimiento;
                        modelo.estado = entidad.estadorequerimiento;

                        return modelo;
                    }
                }
            }
            else
            {
                return modelo;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new RequerimientoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    requerimiento entidad = _context.requerimientos.Find(id);
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
                    var modelo = new RequerimientoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.requerimientos
                            .Where(b => b.estadorequerimiento == "B")
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
                    requerimiento entidad = _context.requerimientos.Find(id);
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
        public static List<RequerimientoModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.requerimientos.Select(entidad =>
                new RequerimientoModelo
                {
                    id = entidad.idrequerimiento,
                    descripcion = entidad.descripcionrequerimiento,
                    sistema = entidad.sistemarequerimiento,
                    ordenrequerimiento = entidad.ordenrequerimiento,
                    estado = entidad.estadorequerimiento
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
                    var entidad = _context.requerimientos
                            .Where(b => b.estadorequerimiento == "B")
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

        public static void UpdateModelo(RequerimientoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    requerimiento entidad = _context.requerimientos.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idrequerimiento = modelo.id;
                        entidad.descripcionrequerimiento = modelo.descripcion;
                        entidad.ordenrequerimiento = modelo.ordenrequerimiento;
                        entidad.sistemarequerimiento = modelo.sistema;
                        entidad.estadorequerimiento = modelo.estado;
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

        public static bool UpdateModelo(RequerimientoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        requerimiento entidad = _context.requerimientos.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idrequerimiento = modelo.id;
                            entidad.descripcionrequerimiento = modelo.descripcion;
                            entidad.sistemarequerimiento = modelo.sistema;
                            entidad.ordenrequerimiento = modelo.ordenrequerimiento;
                            entidad.estadorequerimiento = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.requerimientos SET estadorequerimiento = 'B' WHERE idrequerimiento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //requerimiento entidad = _context.requerimientos.Find(id);
                            //entidad.estadorequerimiento = "B";
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
                            string commandString = String.Format("UPDATE sgpt.requerimientos SET estadorequerimiento = 'B' WHERE idrequerimiento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //requerimiento entidad = _context.requerimientos.Find(id);
                            //entidad.estadorequerimiento = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.requerimientos WHERE idrequerimiento={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //requerimiento entidad = _context.requerimientos.Find(id);
                    //_context.requerimientos.Remove(entidad);
                    //_context.SaveChanges();
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
                        string commandString = String.Format("DELETE FROM sgpt.requerimientos WHERE idrequerimiento={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.requerimientos WHERE idrequerimiento={0};", id);
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

        public static List<requerimiento> GetAllOriginal()
        {
            var requerimiento = _context.requerimientos;
            return requerimiento.ToList();
        }
        public static List<RequerimientoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.requerimientos.Select(entidad =>
                    new RequerimientoModelo
                    {
                        id = entidad.idrequerimiento,
                        descripcion = entidad.descripcionrequerimiento,
                        sistema = entidad.sistemarequerimiento,
                        ordenrequerimiento = entidad.ordenrequerimiento,
                        estado = entidad.estadorequerimiento
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenrequerimiento).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista {0}", e.Source);
                throw;
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
                    var entidad = (from p in _context.requerimientos
                                   where p.descripcionrequerimiento.ToLower().Equals(busqueda)
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
