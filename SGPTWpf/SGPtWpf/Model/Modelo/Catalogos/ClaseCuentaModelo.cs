using CapaDatos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
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

namespace SGPTWpf.Model
{
    public class ClaseCuentaModelo : UIBase
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
        [MaxLength(35, ErrorMessage = "Excede de 35 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripcionccuentas
        {
            get { return GetValue(() => descripcionccuentas); }
            set { SetValue(() => descripcionccuentas, value); }
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
        //public virtual ICollection<catalogocuentas> catalogocuentas { get; set; }
        public virtual ObservableCollection<CatalogoCuentasModelo> listaCatalogoCuentaSeleccion
        {
            get { return GetValue(() => listaCatalogoCuentaSeleccion); }
            set { SetValue(() => listaCatalogoCuentaSeleccion, value); }
        }
        #endregion


        #region Public Model Methods

        public static bool Insert(ClaseCuentaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.clasecuentas', 'idccuentas'), (SELECT MAX(idccuentas) FROM sgpt.clasecuentas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new CapaDatos.clasecuenta
                        {
                            //idccuentas = modelo.id,
                            descripcionccuentas = modelo.descripcionccuentas,
                            sistemaccuentas = false,
                            estadoccuentas = "A"
                        };
                        _context.clasecuentas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idccuentas;
                        modelo.sistema = tablaDestino.sistemaccuentas;
                        modelo.estado = tablaDestino.estadoccuentas;
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

        public static string Insert(ClaseCuentaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.clasecuentas', 'idccuentas'), (SELECT MAX(idccuentas) FROM sgpt.clasecuentas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new CapaDatos.clasecuenta
                        {
                            //idccuentas = modelo.id,
                            descripcionccuentas = modelo.descripcionccuentas,
                            sistemaccuentas = false,
                            estadoccuentas = "A"
                        };
                        _context.clasecuentas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idccuentas;
                        modelo.sistema = tablaDestino.sistemaccuentas;
                        modelo.estado = tablaDestino.estadoccuentas;
                        result = tablaDestino.idccuentas.ToString();
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
            int idccuentas = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idccuentas = _context.clasecuentas.Max(x => x.idccuentas) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idccuentas;
        }

        //Devuelve el registro buscado con base al indice
        public static ClaseCuentaModelo Find(int id)
        {
            var entidadModelo = new ClaseCuentaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    clasecuenta entidad = _context.clasecuentas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idccuentas;
                        entidadModelo.descripcionccuentas = entidad.descripcionccuentas;
                        entidadModelo.sistema = entidad.sistemaccuentas;
                        entidadModelo.estado = entidad.estadoccuentas;
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
                    string commandString = String.Format("DELETE FROM sgpt.clasecuentas WHERE idccuentas={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();


                    //clasecuenta entidad = _context.clasecuentas.Find(id);
                    //_context.clasecuentas.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static ClaseCuentaModelo Find(string id)
        {
            var modelo = new ClaseCuentaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    clasecuenta entidad = _context.clasecuentas.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idccuentas;
                        modelo.descripcionccuentas = entidad.descripcionccuentas;
                        modelo.sistema = entidad.sistemaccuentas;
                        modelo.estado = entidad.estadoccuentas;

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
                    var modelo = new ClaseCuentaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    clasecuenta entidad = _context.clasecuentas.Find(id);
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
                    var modelo = new ClaseCuentaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.clasecuentas
                            .Where(b => b.estadoccuentas == "B")
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
                    clasecuenta entidad = _context.clasecuentas.Find(id);
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
        public static List<ClaseCuentaModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.clasecuentas.Select(entidad =>
                new ClaseCuentaModelo
                {
                    id = entidad.idccuentas,
                    descripcionccuentas = entidad.descripcionccuentas,
                    sistema = entidad.sistemaccuentas,
                    estado = entidad.estadoccuentas
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.id).Where(x => x.descripcionccuentas.ToUpper() == Texto).ToList();
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
                    var entidad = _context.clasecuentas
                            .Where(b => b.estadoccuentas == "B")
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

        public static void UpdateModelo(ClaseCuentaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    clasecuenta entidad = _context.clasecuentas.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idccuentas = modelo.id;
                        entidad.descripcionccuentas = modelo.descripcionccuentas;
                        entidad.sistemaccuentas = modelo.sistema;
                        entidad.estadoccuentas = modelo.estado;
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

        public static bool UpdateModelo(ClaseCuentaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        clasecuenta entidad = _context.clasecuentas.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idccuentas = modelo.id;
                            entidad.descripcionccuentas = modelo.descripcionccuentas;
                            entidad.sistemaccuentas = modelo.sistema;
                            entidad.estadoccuentas = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.clasecuentas SET estadoccuentas = 'B' WHERE idccuentas={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //clasecuenta entidad = _context.clasecuentas.Find(id);
                            //entidad.estadoccuentas = "B";
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
                            string commandString = String.Format("UPDATE sgpt.clasecuentas SET estadoccuentas = 'B' WHERE idccuentas={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //clasecuenta entidad = _context.clasecuentas.Find(id);
                            //entidad.estadoccuentas = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.clasecuentas WHERE idccuentas={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    //clasecuenta entidad = _context.clasecuentas.Find(id);
                    //_context.clasecuentas.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.clasecuentas WHERE idccuentas={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //clasecuenta entidad = _context.clasecuentas.Find(id);
                        //_context.clasecuentas.Remove(entidad);
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

                            string commandString = String.Format("DELETE FROM sgpt.clasecuentas WHERE idccuentas={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //clasecuenta entidad = _context.clasecuentas.Find(id);
                            //_context.clasecuentas.Remove(entidad);
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

        public static List<ClaseCuentaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.clasecuentas.Select(entidad =>
                    new ClaseCuentaModelo
                    {
                        id = entidad.idccuentas,
                        descripcionccuentas = entidad.descripcionccuentas,
                        sistema = entidad.sistemaccuentas,
                        estado = entidad.estadoccuentas
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista  \n"+ e);
                throw;
            }
        }

        public static ObservableCollection<clasecuenta> GetAllCapaDatos()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {

                    string commandString = String.Format("SELECT * FROM sgpt.clasecuentas WHERE estadoccuentas = 'A' ORDER BY idccuentas;");
                    var lista = _context.clasecuentas.SqlQuery(commandString).ToList();
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    if (lista.Count() > 0)
                    {
                        return new ObservableCollection<clasecuenta>(lista);
                    }
                    else
                    {
                        return new ObservableCollection<clasecuenta>();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle \n" + e);
                return new ObservableCollection<clasecuenta>();
            }

        }

        public static List<ClaseCuentaModelo> GetAllByCatalogo()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.clasecuentas.Select(entidad =>
                     new ClaseCuentaModelo
                     {
                         id = entidad.idccuentas,
                         descripcionccuentas = entidad.descripcionccuentas,
                         sistema = entidad.sistemaccuentas,
                         estado = entidad.estadoccuentas
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                    ClaseCuentaModelo temporal = new ClaseCuentaModelo
                    {
                        id = 0,
                        descripcionccuentas = "Ninguna",
                        sistema = false,
                        estado = "A"
                    };
                    lista.Add(temporal);
                    return lista.OrderBy(o => o.id).ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista  \n"+ e);
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
                    var entidad = (from p in _context.clasecuentas
                                   where p.descripcionccuentas.ToLower().Equals(busqueda)
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