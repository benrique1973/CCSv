
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
    public class SimboloModelo : UIBase
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
        [MaxLength(1, ErrorMessage = "Excede de 1 caracter permitid")]
        [RegularExpression(@"^[^A-Z,^a-z,^0-9]{1}$", ErrorMessage = "Deben ser símbolos para formulas")]

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
        [DisplayName("Clase de símbolo")]
        [Required(ErrorMessage = "Debe seleccionar el tipo de simbolo")]
        public Nullable<int> idtd
        {
            get { return GetValue(() => idtd); }
            set { SetValue(() => idtd, value); }
        }
        public string tiposdescriptor
        {
            get { return GetValue(() => tiposdescriptor); }
            set { SetValue(() => tiposdescriptor, value); }
        }
        public virtual ICollection<tiposdescriptore> tiposdescriptores
        {
            get { return GetValue(() => tiposdescriptores); }
            set { SetValue(() => tiposdescriptores, value); }
        }

        public virtual tiposdescriptore tipossimbolo
        {
            get { return GetValue(() => tipossimbolo); }
            set { SetValue(() => tipossimbolo, value); }
        }



        #endregion

        #region Public Model Methods

        public static bool Insert(SimboloModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.simbolos', 'idsimbolo'), (SELECT MAX(idsimbolo) FROM sgpt.simbolos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new simbolo
                        {
                            //idsimbolo = modelo.id,
                            caractersimbolo = modelo.descripcion,
                            idtd = modelo.idtd,
                            sistemasimbolo = false,
                            estadosimbolo = "A"
                        };
                        _context.simbolos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idsimbolo;
                        modelo.sistema = tablaDestino.sistemasimbolo;
                        modelo.estado = tablaDestino.estadosimbolo;
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

        public static string Insert(SimboloModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.simbolos', 'idsimbolo'), (SELECT MAX(idsimbolo) FROM sgpt.simbolos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new simbolo
                        {
                            //idsimbolo = modelo.id,
                            caractersimbolo = modelo.descripcion,
                            idtd = modelo.idtd,
                            sistemasimbolo = false,
                            estadosimbolo = "A"
                        };
                        _context.simbolos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idsimbolo;
                        modelo.sistema = tablaDestino.sistemasimbolo;
                        modelo.estado = tablaDestino.estadosimbolo;
                        result = tablaDestino.idsimbolo.ToString();
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
            int idsimbolo = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idsimbolo =  _context.simbolos.Max(x => x.idsimbolo) + 1;
                    //idsimbolo = _context.simbolos.Count() + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idsimbolo;
        }

        //Devuelve el registro buscado con base al indice
        public static SimboloModelo Find(int id)
        {
            var entidadModelo = new SimboloModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    simbolo entidad =  _context.simbolos.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idsimbolo;
                        entidadModelo.descripcion = entidad.caractersimbolo;
                        entidadModelo.idtd = entidad.idtd;
                        entidadModelo.sistema = entidad.sistemasimbolo;
                        entidadModelo.estado = entidad.estadosimbolo;
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
                    string commandString = String.Format("DELETE FROM sgpt.simbolos WHERE idsimbolo={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static SimboloModelo Find(string id)
        {
            var modelo = new SimboloModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    simbolo entidad =  _context.simbolos.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idsimbolo;
                        modelo.descripcion = entidad.caractersimbolo;
                        modelo.sistema = entidad.sistemasimbolo;
                        modelo.estado = entidad.estadosimbolo;

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
                    var modelo = new SimboloModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    simbolo entidad =  _context.simbolos.Find(id);
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
                    var modelo = new SimboloModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.simbolos
                            .Where(b => b.estadosimbolo == "B")
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
                    simbolo entidad =  _context.simbolos.Find(id);
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
        public static List<SimboloModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.simbolos.Select(entidad =>
                new SimboloModelo
                {
                    id = entidad.idsimbolo,
                    descripcion = entidad.caractersimbolo,
                    sistema = entidad.sistemasimbolo,
                    idtd = entidad.idtd,
                    estado = entidad.estadosimbolo
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
                    var entidad = _context.simbolos
                            .Where(b => b.estadosimbolo == "B")
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

        public static void UpdateModelo(SimboloModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    simbolo entidad =  _context.simbolos.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idsimbolo = modelo.id;
                        entidad.caractersimbolo = modelo.descripcion;
                        entidad.idtd = modelo.idtd;
                        entidad.sistemasimbolo = modelo.sistema;
                        entidad.estadosimbolo = modelo.estado;
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

        public static bool UpdateModelo(SimboloModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        simbolo entidad =  _context.simbolos.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idsimbolo = modelo.id;
                            entidad.caractersimbolo = modelo.descripcion;
                            entidad.sistemasimbolo = modelo.sistema;
                            entidad.idtd = modelo.idtd;
                            entidad.estadosimbolo = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.simbolos SET estadosimbolo = 'B' WHERE idsimbolo={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //simbolo entidad =  _context.simbolos.Find(id);
                            //entidad.estadosimbolo = "B";
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
                            string commandString = String.Format("UPDATE sgpt.simbolos SET estadosimbolo = 'B' WHERE idsimbolo={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.simbolos WHERE idsimbolo={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.simbolos WHERE idsimbolo={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.simbolos WHERE idsimbolo={0};", id);
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

        public static List<simbolo> GetAllOriginal()
        {
            var simbolo = _context.simbolos.Include(d => d.idtd);
            return simbolo.ToList();
        }
        public static List<SimboloModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.simbolos.Select(entidad =>
                    new SimboloModelo
                    {
                        id = entidad.idsimbolo,
                        descripcion = entidad.caractersimbolo,
                        sistema = entidad.sistemasimbolo,
                        idtd = entidad.tiposdescriptore.idtd,
                        tiposdescriptor = entidad.tiposdescriptore.tipotd,
                        estado = entidad.estadosimbolo
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.tiposdescriptor).Where(x => x.estado == "A").ToList();
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

        public static List<SimboloModelo> GetAllByPais(int id)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.simbolos.Select(entidad =>
                    new SimboloModelo
                    {
                        id = entidad.idsimbolo,
                        descripcion = entidad.caractersimbolo,
                        sistema = entidad.sistemasimbolo,
                        idtd = entidad.tiposdescriptore.idtd,
                        tiposdescriptor = entidad.tiposdescriptore.tipotd,
                        estado = entidad.estadosimbolo
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.tiposdescriptor).Where(x => (x.estado == "A") && (x.idtd == id)).ToList();
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
                    var entidad = (from p in _context.simbolos
                                   where p.caractersimbolo.ToLower().Equals(busqueda)
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

