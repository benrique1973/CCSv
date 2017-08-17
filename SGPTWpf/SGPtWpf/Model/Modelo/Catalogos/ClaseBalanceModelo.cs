using CapaDatos;
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
    public class ClaseBalanceModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        public int idCorrelativoCB
        {
            get { return GetValue(() => idCorrelativoCB); }
            set { SetValue(() => idCorrelativoCB, value); }
        }

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
        public virtual ICollection<balance> balances
        {
            get { return GetValue(() => balances); }
            set { SetValue(() => balances, value); }
        }
        //public virtual ICollection<balances> balances { get; set; }

        #endregion

        #region Propiedades para listas
        public int idCb
        {
            get { return GetValue(() => idCb); }
            set { SetValue(() => idCb, value); }
        }

        public string descripcionCb
        {
            get { return GetValue(() => descripcionCb); }
            set { SetValue(() => descripcionCb, value); }
        }

        public virtual ObservableCollection<ClaseBalanceModelo> listaEntidadSeleccionCb
        {
            get { return GetValue(() => listaEntidadSeleccionCb); }
            set { SetValue(() => listaEntidadSeleccionCb, value); }
        }
        #endregion

        #region Public Model Methods

        public static bool Insert(ClaseBalanceModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.clasesbalance', 'idcb'), (SELECT MAX(idcb) FROM sgpt.clasesbalance) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new clasesbalance
                        {
                            //idcb = modelo.id,
                            descripcioncb = modelo.descripcion,
                            sistemacb = false,
                            estadocb = "A"
                        };
                        _context.clasesbalances.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idcb;
                        modelo.sistema = tablaDestino.sistemacb;
                        modelo.estado = tablaDestino.estadocb;
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

        public static string Insert(ClaseBalanceModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.clasesbalance', 'idcb'), (SELECT MAX(idcb) FROM sgpt.clasesbalance) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new clasesbalance
                        {
                            //idcb = modelo.id,
                            descripcioncb = modelo.descripcion,
                            sistemacb = false,
                            estadocb = "A"
                        };
                        _context.clasesbalances.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idcb;
                        modelo.sistema = tablaDestino.sistemacb;
                        modelo.estado = tablaDestino.estadocb;
                        result = tablaDestino.idcb.ToString();
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
            int idcb = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idcb = _context.clasesbalances.Max(x => x.idcb) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idcb;
        }

        //Devuelve el registro buscado con base al indice
        public static ClaseBalanceModelo Find(int id)
        {
            var entidadModelo = new ClaseBalanceModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    clasesbalance entidad = _context.clasesbalances.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idcb;
                        entidadModelo.descripcion = entidad.descripcioncb;
                        entidadModelo.sistema = entidad.sistemacb;
                        entidadModelo.estado = entidad.estadocb;
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
                    string commandString = String.Format("DELETE FROM sgpt.clasesbalance WHERE idcb={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //clasesbalance entidad = _context.clasesbalances.Find(id);
                    //_context.clasesbalances.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static ClaseBalanceModelo Find(string id)
        {
            var modelo = new ClaseBalanceModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    clasesbalance entidad = _context.clasesbalances.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idcb;
                        modelo.descripcion = entidad.descripcioncb;
                        modelo.sistema = entidad.sistemacb;
                        modelo.estado = entidad.estadocb;

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
                    var modelo = new ClaseBalanceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    clasesbalance entidad = _context.clasesbalances.Find(id);
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
                    var modelo = new ClaseBalanceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.clasesbalances
                            .Where(b => b.estadocb == "B")
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
                    clasesbalance entidad = _context.clasesbalances.Find(id);
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
        public static List<ClaseBalanceModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.clasesbalances.Select(entidad =>
                new ClaseBalanceModelo
                {
                    id = entidad.idcb,
                    descripcion = entidad.descripcioncb,
                    sistema = entidad.sistemacb,
                    estado = entidad.estadocb
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
                    var entidad = _context.clasesbalances
                            .Where(b => b.estadocb == "B")
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

        public static void UpdateModelo(ClaseBalanceModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    clasesbalance entidad = _context.clasesbalances.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idcb = modelo.id;
                        entidad.descripcioncb = modelo.descripcion;
                        entidad.sistemacb = modelo.sistema;
                        entidad.estadocb = modelo.estado;
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

        public static bool UpdateModelo(ClaseBalanceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        clasesbalance entidad = _context.clasesbalances.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idcb = modelo.id;
                            entidad.descripcioncb = modelo.descripcion;
                            entidad.sistemacb = modelo.sistema;
                            entidad.estadocb = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.clasesbalance SET estadocb = 'B' WHERE idcb={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //clasesbalance entidad = _context.clasesbalances.Find(id);
                            //entidad.estadocb = "B";
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
                            string commandString = String.Format("UPDATE sgpt.clasesbalance SET estadocb = 'B' WHERE idcb={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //clasesbalance entidad = _context.clasesbalances.Find(id);
                            //entidad.estadocb = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.clasesbalance WHERE idcb={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    //clasesbalance entidad = _context.clasesbalances.Find(id);
                    //_context.clasesbalances.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.clasesbalance WHERE idcb={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //clasesbalance entidad = _context.clasesbalances.Find(id);
                        //_context.clasesbalances.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.clasesbalance WHERE idcb={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //clasesbalance entidad = _context.clasesbalances.Find(id);
                            //_context.clasesbalances.Remove(entidad);
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

        public static List<ClaseBalanceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista= _context.clasesbalances.Select(entidad =>
                    new ClaseBalanceModelo
                    {
                        id = entidad.idcb,
                        descripcion = entidad.descripcioncb,
                        sistema = entidad.sistemacb,
                        estado = entidad.estadocb
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                    int i = 1;
                    foreach(ClaseBalanceModelo item in lista)
                    {
                        item.idCorrelativoCB = i;
                        i++;
                    }
                    return lista.ToList();
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

        public static List<ClaseBalanceModelo> GetAllToDisplay()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.clasesbalances.Select(entidad =>
                     new ClaseBalanceModelo
                     {
                         id=entidad.idcb,
                         descripcion=entidad.descripcioncb,
                         idCb = entidad.idcb,
                         descripcionCb = entidad.descripcioncb,
                         estado=entidad.estadocb
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idCb).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                    ClaseBalanceModelo temporal = new ClaseBalanceModelo
                    {
                        id=0,
                        descripcion="Ninguno",
                        idCb = 0,
                        descripcionCb = "Ninguno",
                        sistema = false,
                        estado = "A",
                    };
                    lista.Add(temporal);
                    int i = 1;
                    foreach (ClaseBalanceModelo item in lista)
                    {
                        item.idCorrelativoCB = i;
                        i++;
                    }
                    return lista.OrderBy(o => o.idCb).ToList();
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
                    var entidad = (from p in _context.clasesbalances
                                   where p.descripcioncb.ToLower().Equals(busqueda)
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
