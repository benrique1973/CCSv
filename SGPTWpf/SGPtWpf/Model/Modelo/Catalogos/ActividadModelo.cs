using CapaDatos;
//using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model
{
    public class ActividadModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        [DisplayName("Codigo")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(10, ErrorMessage = "Excede de 10 caracteres permitidos")]
        [RegularExpression(@"^[0-9]{1,10}$", ErrorMessage = "Deben ser números del 0  al 9 y como maximo 10")]
        [UnqiueActividad(ErrorMessage = "Código duplicado ya existe en otro registro")]
        //        [RegularExpression(@"/^\d{8}-\d$/", ErrorMessage = "Deben ser números del 0  al 9 y como maximo 10")]


        public string id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }


        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(200, ErrorMessage = "Excede de 200 caracteres permitidos")]
        [MinLength(5, ErrorMessage = "El contenido es muy pequeño para ser una actividad")] 
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
        public virtual ICollection<cliente> clientes
        {
            get { return GetValue(() => clientes); }
            set { SetValue(() => clientes, value); }
        }
        //public virtual ICollection<clientes> clientes { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(ActividadModelo modelo, Boolean insertar)
        {
            bool result = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new actividade
                        {
                            idcodigoactividad = modelo.id,
                            descripcionactividad = modelo.descripcion,
                            sistemaactividad = false,
                            estadoactividad = "A"
                        };
                        _context.actividades.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idcodigoactividad;
                        modelo.sistema = tablaDestino.sistemaactividad;
                        modelo.estado = tablaDestino.estadoactividad;
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar :  \n"+ e);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(ActividadModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new actividade
                        {
                            idcodigoactividad = modelo.id,
                            descripcionactividad = modelo.descripcion,
                            sistemaactividad = false,
                            estadoactividad = "A"
                        };
                        _context.actividades.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idcodigoactividad;
                        modelo.sistema = tablaDestino.sistemaactividad;
                        modelo.estado = tablaDestino.estadoactividad;
                        result = tablaDestino.idcodigoactividad.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar :  \n"+ e);
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
            int idcodigoactividad = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idcodigoactividad = _context.actividades.Count() + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idcodigoactividad;
        }

        //Devuelve el registro buscado con base al indice
        public static ActividadModelo Find(int id)
        {
            var entidadModelo = new ActividadModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    actividade entidad = _context.actividades.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idcodigoactividad;
                        entidadModelo.descripcion = entidad.descripcionactividad;
                        entidadModelo.sistema = entidad.sistemaactividad;
                        entidadModelo.estado = entidad.estadoactividad;
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
                    string commandString = String.Format("DELETE FROM sgpt.actividades WHERE idcodigoactividad ='{0}';", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //actividade entidad = _context.actividades.Find(id);
                    //_context.actividades.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static ActividadModelo Find(string id)
        {
            var modelo = new ActividadModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    actividade entidad = _context.actividades.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idcodigoactividad;
                        modelo.descripcion = entidad.descripcionactividad;
                        modelo.sistema = entidad.sistemaactividad;
                        modelo.estado = entidad.estadoactividad;

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
                    var modelo = new ActividadModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    actividade entidad = _context.actividades.Find(id);
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
                    var modelo = new ActividadModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    actividade entidad = _context.actividades.Find(id);
                    if (entidad == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (entidad.estadoactividad == "B")
                        {
                            return true;
                        }
                        else {
                            return false;
                        }
                        
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
                    actividade entidad = _context.actividades.Find(id);
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
        public static List<ActividadModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.actividades.Select(entidad =>
                new ActividadModelo
                {
                    id = entidad.idcodigoactividad,
                    descripcion = entidad.descripcionactividad,
                    sistema = entidad.sistemaactividad,
                    estado = entidad.estadoactividad
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
                    var entidad = _context.actividades
                            .Where(b => b.estadoactividad == "B")
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

        public static void UpdateModelo(ActividadModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    actividade entidad = _context.actividades.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idcodigoactividad = modelo.id;
                        entidad.descripcionactividad = modelo.descripcion;
                        entidad.sistemaactividad = modelo.sistema;
                        entidad.estadoactividad = modelo.estado;
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

        public static bool UpdateModelo(ActividadModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        actividade entidad = _context.actividades.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idcodigoactividad = modelo.id;
                            entidad.descripcionactividad = modelo.descripcion;
                            entidad.sistemaactividad = modelo.sistema;
                            entidad.estadoactividad = modelo.estado;
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
                        MessageBox.Show("Exception en actualizar :  \n"+ e);
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
                            string commandString = String.Format("UPDATE sgpt.actividades SET estadoactividad = 'B' WHERE idcodigoactividad ={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //actividade entidad = _context.actividades.Find(id);
                            //entidad.estadoactividad = "B";
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
                            string commandString = String.Format("UPDATE sgpt.actividades SET estadoactividad = 'B' WHERE idcodigoactividad ='{0}';", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //actividade entidad = _context.actividades.Find(id);
                            //entidad.estadoactividad = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.actividades WHERE  idcodigoactividad ={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    //actividade entidad = _context.actividades.Find(id);
                    //_context.actividades.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.actividades WHERE idcodigoactividad ={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //actividade entidad = _context.actividades.Find(id);
                        //_context.actividades.Remove(entidad);
                        //_context.SaveChanges();
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
                            string commandString = String.Format("DELETE FROM sgpt.actividades WHERE idcodigoactividad ='{0}';", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //actividade entidad = _context.actividades.Find(id);
                            //_context.actividades.Remove(entidad);
                            //_context.SaveChanges();
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

        public static List<ActividadModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.actividades.Select(entidad =>
                    new ActividadModelo
                    {
                        id = entidad.idcodigoactividad,
                        descripcion = entidad.descripcionactividad,
                        sistema = entidad.sistemaactividad,
                        estado = entidad.estadoactividad
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Error en ActividadModelo.cs. Exception en elaboracion de lista {0} ", e.Source);
                throw;
            }
        }

        #endregion
        
        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto)||string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.actividades
                                      where p.descripcionactividad.ToLower().Equals(busqueda)
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

