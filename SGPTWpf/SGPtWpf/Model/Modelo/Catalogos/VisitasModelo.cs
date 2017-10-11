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
    public class VisitaModelo : UIBase
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
        public virtual ICollection<cedula> cedulas
        {
            get { return GetValue(() => cedulas); }
            set { SetValue(() => cedulas, value); }
        }

        public virtual ICollection<detallecronograma> detallecronogramas
        {
            get { return GetValue(() => detallecronogramas); }
            set { SetValue(() => detallecronogramas, value); }
        }

        //public virtual ICollection<cedulas> cedulas { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(VisitaModelo modelo, Boolean insertar)
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
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new visita
                        {
                            //idvisita = modelo.id,
                            descripcionvisita = modelo.descripcion,
                            sistemavisita = false,
                            estadovisita = "A"
                        };
                        _context.visitas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idvisita;
                        modelo.sistema = tablaDestino.sistemavisita;
                        modelo.estado = tablaDestino.estadovisita;
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

        public static string Insert(VisitaModelo modelo)
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
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new visita
                        {
                            //idvisita = modelo.id,
                            descripcionvisita = modelo.descripcion,
                            sistemavisita = false,
                            estadovisita = "A"
                        };
                        _context.visitas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idvisita;
                        modelo.sistema = tablaDestino.sistemavisita;
                        modelo.estado = tablaDestino.estadovisita;
                        result = tablaDestino.idvisita.ToString();
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
            int idvisita = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idvisita = _context.visitas.Max(x => x.idvisita) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idvisita;
        }

        //Devuelve el registro buscado con base al indice
        public static VisitaModelo Find(int id)
        {
            var entidadModelo = new VisitaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    visita entidad = _context.visitas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idvisita;
                        entidadModelo.descripcion = entidad.descripcionvisita;
                        entidadModelo.sistema = entidad.sistemavisita;
                        entidadModelo.estado = entidad.estadovisita;
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
                    string commandString = String.Format("DELETE FROM sgpt.visitas WHERE idvisita={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static VisitaModelo Find(string id)
        {
            var modelo = new VisitaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    visita entidad = _context.visitas.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idvisita;
                        modelo.descripcion = entidad.descripcionvisita;
                        modelo.sistema = entidad.sistemavisita;
                        modelo.estado = entidad.estadovisita;

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
                    var modelo = new VisitaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    visita entidad = _context.visitas.Find(id);
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
                    visita entidad = _context.visitas.Find(id);
                    if (entidad == null)
                    {
                        return false;
                    }
                    else
                    {
                        if (entidad.estadovisita == "B")
                        {
                            return true;
                        }
                        else
                        {
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
                    visita entidad = _context.visitas.Find(id);
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
        public static List<VisitaModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.visitas.Select(entidad =>
                new VisitaModelo
                {
                    id = entidad.idvisita,
                    descripcion = entidad.descripcionvisita,
                    sistema = entidad.sistemavisita,
                    estado = entidad.estadovisita
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
                    var entidad = _context.visitas
                            .Where(b => b.estadovisita == "B")
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

        public static void UpdateModelo(VisitaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    visita entidad = _context.visitas.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idvisita = modelo.id;
                        entidad.descripcionvisita = modelo.descripcion;
                        entidad.sistemavisita = modelo.sistema;
                        entidad.estadovisita = modelo.estado;
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

        public static bool UpdateModelo(VisitaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        visita entidad = _context.visitas.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idvisita = modelo.id;
                            entidad.descripcionvisita = modelo.descripcion;
                            entidad.sistemavisita = modelo.sistema;
                            entidad.estadovisita = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.visitas SET estadovisita = 'B' WHERE idvisita={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //visita entidad = _context.visitas.Find(id);
                            //entidad.estadovisita = "B";
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
                            string commandString = String.Format("UPDATE sgpt.visitas SET estadovisita = 'B' WHERE idvisita={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.visitas WHERE idvisita={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.visitas WHERE idvisita={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.visitas WHERE idvisita={0};", id);
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

        public static List<VisitaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.visitas.Select(entidad =>
                    new VisitaModelo
                    {
                        id = entidad.idvisita,
                        descripcion = entidad.descripcionvisita,
                        sistema = entidad.sistemavisita,
                        estado = entidad.estadovisita
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
        public static List<VisitaModelo> GetAllSeleccion()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.visitas.Select(entidad =>
                    new VisitaModelo
                    {
                        id = entidad.idvisita,
                        descripcion = entidad.descripcionvisita,
                        sistema = entidad.sistemavisita,
                        estado = entidad.estadovisita
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    VisitaModelo registroAdicional = new VisitaModelo();
                    registroAdicional.id = 0;
                    registroAdicional.descripcion = "Ninguna";//Se adiciona para facilitar accesibilidad al usuario
                    lista.Add(registroAdicional);
                    return lista.OrderBy(o => o.id).ToList();
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
        public static List<VisitaModelo> GetAll(bool listadosDetalle)
        {

            {
                var lista = GetAll();
                VisitaModelo registroAdicional = new VisitaModelo();
                registroAdicional.id = 0;
                registroAdicional.descripcion = "Ninguna";//Se adiciona para facilitar accesibilidad al usuario
                lista.Add(registroAdicional);
                return lista.OrderBy(o => o.id).ToList();
            }//Transformacion necesaria por la fecha 
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
                    var entidad = (from p in _context.visitas
                                   where p.descripcionvisita.ToLower().Equals(busqueda)
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
        public static string FindNombreById(int? id)
        {
            string nombre = string.Empty;
            if (id != null)
            {
                if (!(id == 0))
                {
                    using (_context = new SGPTEntidades())
                    {
                        return nombre = _context.visitas.Find(id).descripcionvisita;
                    }
                }
                else
                {
                    return nombre;
                }
            }
            else
            {
                return nombre;
            }
        }
        #endregion
    }

}



