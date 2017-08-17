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
    public class TipoHerramientaModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Codigo")]
        public int id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(50, ErrorMessage = "Excede de 50 caracteres permitidos")]
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
        public virtual ICollection<herramienta> herramientas
        {
            get { return GetValue(() => herramientas); }
            set { SetValue(() => herramientas, value); }
        }

        public virtual ICollection<programa> programas
        {
            get { return GetValue(() => programas); }
            set { SetValue(() => programas, value); }
        }

        //public virtual ICollection<herramientas> herramientas { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(TipoHerramientaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tiposherramientas', 'idth'), (SELECT MAX(idth) FROM sgpt.tiposherramientas) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tiposherramienta
                        {
                            //idth = modelo.id,
                            descripcionth = modelo.descripcion,
                            sistemath = false,
                            estadoth = "A"
                        };
                        _context.tiposherramientas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idth;
                        modelo.sistema = tablaDestino.sistemath;
                        modelo.estado = tablaDestino.estadoth;
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

        public static string Insert(TipoHerramientaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tiposherramientas', 'idth'), (SELECT MAX(idth) FROM sgpt.tiposherramientas) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tiposherramienta
                        {
                            //idth = modelo.id,
                            descripcionth = modelo.descripcion,
                            sistemath = false,
                            estadoth = "A"
                        };
                        _context.tiposherramientas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idth;
                        modelo.sistema = tablaDestino.sistemath;
                        modelo.estado = tablaDestino.estadoth;
                        result = tablaDestino.idth.ToString();
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
            int idth = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idth = _context.tiposherramientas.Max(x => x.idth) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idth;
        }

        //Devuelve el registro buscado con base al indice
        public static TipoHerramientaModelo GetRegistro(int id)
        {
            var entidadModelo = new TipoHerramientaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    tiposherramienta entidad = _context.tiposherramientas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idth;
                        entidadModelo.descripcion = entidad.descripcionth;
                        entidadModelo.sistema = entidad.sistemath;
                        entidadModelo.estado = entidad.estadoth;
                        return entidadModelo;
                    }
                }
            }
            else
            {
                return entidadModelo = null;
            }

        }

        public static string FindNombre(int id)
        {
            string descripcionTh = "Todos";
            if (id == 0 || string.IsNullOrEmpty(id.ToString()))
            {
                return descripcionTh;
            }
            else
            {
                    using (_context = new SGPTEntidades())
                    {
                        tiposherramienta entidad = _context.tiposherramientas.Find(id);
                        if (entidad == null)
                        {
                            return descripcionTh;
                        }
                        else
                        {
                        descripcionTh=entidad.descripcionth;
                        return descripcionTh;
                        }
                    }
            }
        }
        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.tiposherramientas WHERE idth={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static TipoHerramientaModelo Find(string id)
        {
            var modelo = new TipoHerramientaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    tiposherramienta entidad = _context.tiposherramientas.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idth;
                        modelo.descripcion = entidad.descripcionth;
                        modelo.sistema = entidad.sistemath;
                        modelo.estado = entidad.estadoth;

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
                    var modelo = new TipoHerramientaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    tiposherramienta entidad = _context.tiposherramientas.Find(id);
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
                    var modelo = new TipoHerramientaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.tiposherramientas
                            .Where(b => b.estadoth == "B")
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
                    tiposherramienta entidad = _context.tiposherramientas.Find(id);
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
        public static List<TipoHerramientaModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.tiposherramientas.Select(entidad =>
                new TipoHerramientaModelo
                {
                    id = entidad.idth,
                    descripcion = entidad.descripcionth,
                    sistema = entidad.sistemath,
                    estado = entidad.estadoth
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
                    var entidad = _context.tiposherramientas
                            .Where(b => b.estadoth == "B")
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

        public static void UpdateModelo(TipoHerramientaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    tiposherramienta entidad = _context.tiposherramientas.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idth = modelo.id;
                        entidad.descripcionth = modelo.descripcion;
                        entidad.sistemath = modelo.sistema;
                        entidad.estadoth = modelo.estado;
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

        public static bool UpdateModelo(TipoHerramientaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        tiposherramienta entidad = _context.tiposherramientas.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idth = modelo.id;
                            entidad.descripcionth = modelo.descripcion;
                            entidad.sistemath = modelo.sistema;
                            entidad.estadoth = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.tiposherramientas SET estadoth = 'B' WHERE idth={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //tiposherramienta entidad = _context.tiposherramientas.Find(id);
                            //entidad.estadoth = "B";
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
                            string commandString = String.Format("UPDATE sgpt.tiposherramientas SET estadoth = 'B' WHERE idth={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.tiposherramientas WHERE idth={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.tiposherramientas WHERE idth={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.tiposherramientas WHERE idth={0};", id);
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

        public static List<TipoHerramientaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.tiposherramientas.Select(entidad =>
                    new TipoHerramientaModelo
                    {
                        id = entidad.idth,
                        descripcion = entidad.descripcionth,
                        sistema = entidad.sistemath,
                        estado = entidad.estadoth
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
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

        public static List<TipoHerramientaModelo> GetAllSeleccion()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var seleccion=_context.tiposherramientas.Select(entidad =>
                    new TipoHerramientaModelo
                    {
                        id = entidad.idth,
                        descripcion = entidad.descripcionth,
                        sistema = entidad.sistemath,
                        estado = entidad.estadoth
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                    TipoHerramientaModelo adicion = new TipoHerramientaModelo();
                    adicion.id = 0;
                    adicion.descripcion = "Todos";
                    adicion.sistema = true;
                    adicion.estado = "A";
                    seleccion.Add(adicion);
                    return seleccion;
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
                    var entidad = (from p in _context.tiposherramientas
                                   where p.descripcionth.ToLower().Equals(busqueda)
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
