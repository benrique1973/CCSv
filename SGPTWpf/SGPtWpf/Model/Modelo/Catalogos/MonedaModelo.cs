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
    public class MonedaModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }


        [DisplayName("Codigo")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [DisplayName("Código moneda")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(3, ErrorMessage = "Excede de 3 caracteres permitidos")]
        public string simbolomoneda
        {
            get { return GetValue(() => simbolomoneda); }
            set { SetValue(() => simbolomoneda, value); }
        }

        public virtual ICollection<sistemascontable> sistemascontables
        {
            get { return GetValue(() => sistemascontables); }
            set { SetValue(() => sistemascontables, value); }
        }



        #endregion

        #region Public Model Methods

        public static bool Insert(MonedaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.monedas', 'idmoneda'), (SELECT MAX(idmoneda) FROM sgpt.monedas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new moneda
                        {
                        //idmoneda = modelo.id,
                        nombremoneda = modelo.descripcion,
                            simbolomoneda = modelo.simbolomoneda,
                            sistemamoneda = false,
                            estadomoneda = "A"
                        };
                        _context.monedas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idmoneda;
                        modelo.sistema = tablaDestino.sistemamoneda;
                        modelo.estado = tablaDestino.estadomoneda;
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

        public static string Insert(MonedaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.monedas', 'idmoneda'), (SELECT MAX(idmoneda) FROM sgpt.monedas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new moneda
                        {
                            //idmoneda = modelo.id,
                            nombremoneda = modelo.descripcion,
                            simbolomoneda = modelo.simbolomoneda,
                            sistemamoneda = false,
                            estadomoneda = "A"
                        };
                        _context.monedas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idmoneda;
                        modelo.sistema = tablaDestino.sistemamoneda;
                        modelo.estado = tablaDestino.estadomoneda;
                        result = tablaDestino.idmoneda.ToString();
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

        public static int? IdAsignar()
        {
            int? idmoneda = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    if (!(sincronizar))
                    {
                        var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                        "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.monedas', 'idmoneda'), (SELECT MAX(idmoneda) FROM sgpt.monedas) + 1);");
                        sincronizar = true;
                    }
                    idmoneda = _context.monedas.Max(x => x.idmoneda) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idmoneda;
        }

        //Devuelve el registro buscado con base al indice
        public static MonedaModelo Find(int id)
        {
            var entidadModelo = new MonedaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    moneda entidad = _context.monedas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idmoneda;
                        entidadModelo.descripcion = entidad.nombremoneda;
                        entidadModelo.sistema = entidad.sistemamoneda;
                        entidadModelo.estado = entidad.estadomoneda;
                        entidadModelo.simbolomoneda = entidad.simbolomoneda;
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
                    string commandString = String.Format("DELETE FROM sgpt.monedas WHERE idmoneda={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //moneda entidad = _context.monedas.Find(id);
                    //_context.monedas.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static MonedaModelo Find(string id)
        {
            var modelo = new MonedaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    moneda entidad = _context.monedas.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idmoneda;
                        modelo.descripcion = entidad.nombremoneda;
                        modelo.sistema = entidad.sistemamoneda;
                        modelo.estado = entidad.estadomoneda;
                        modelo.simbolomoneda = entidad.simbolomoneda;

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
                    var modelo = new MonedaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    moneda entidad = _context.monedas.Find(id);
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
                    var modelo = new MonedaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.monedas
                            .Where(b => b.estadomoneda == "B")
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
                    moneda entidad = _context.monedas.Find(id);
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
        public static List<MonedaModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.monedas.Select(entidad =>
                new MonedaModelo
                {
                    id = entidad.idmoneda,
                    descripcion = entidad.nombremoneda,
                    sistema = entidad.sistemamoneda,
                    estado = entidad.estadomoneda,
                    simbolomoneda = entidad.simbolomoneda
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
                    var entidad = _context.monedas
                            .Where(b => b.estadomoneda == "B")
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

        public static void UpdateModelo(MonedaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    moneda entidad = _context.monedas.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idmoneda = modelo.id;
                        entidad.nombremoneda = modelo.descripcion;
                        entidad.sistemamoneda = modelo.sistema;
                        entidad.estadomoneda = modelo.estado;
                        entidad.simbolomoneda = modelo.simbolomoneda;
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

        public static bool UpdateModelo(MonedaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        moneda entidad = _context.monedas.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idmoneda = modelo.id;
                            entidad.nombremoneda = modelo.descripcion;
                            entidad.sistemamoneda = modelo.sistema;
                            entidad.estadomoneda = modelo.estado;
                            entidad.simbolomoneda = modelo.simbolomoneda;
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
        public static bool DeleteBorradoLogico(int? id, Boolean actualizar)
        {
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.monedas SET estadomoneda = 'B' WHERE idmoneda={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //moneda entidad = _context.monedas.Find(id);
                            //entidad.estadomoneda = "B";
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
                            string commandString = String.Format("UPDATE sgpt.monedas SET estadomoneda = 'B' WHERE idmoneda={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //moneda entidad = _context.monedas.Find(id);
                            //entidad.estadomoneda = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.monedas WHERE idmoneda={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //moneda entidad = _context.monedas.Find(id);
                    //_context.monedas.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.monedas WHERE idmoneda={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();


                        //moneda entidad = _context.monedas.Find(id);
                        //_context.monedas.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.monedas WHERE idmoneda={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //moneda entidad = _context.monedas.Find(id);
                            //_context.monedas.Remove(entidad);
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

        public static List<MonedaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.monedas.Select(entidad =>
                    new MonedaModelo
                    {
                        id = entidad.idmoneda,
                        descripcion = entidad.nombremoneda,
                        sistema = entidad.sistemamoneda,
                        estado = entidad.estadomoneda,
                        simbolomoneda = entidad.simbolomoneda,
                        //Lista filtrada de monedas que fueron eliminados
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
                    var entidad = (from p in _context.monedas
                                   where p.nombremoneda.ToLower().Equals(busqueda)
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
