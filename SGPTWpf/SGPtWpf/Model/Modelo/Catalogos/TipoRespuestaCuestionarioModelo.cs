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
    public class TipoRespuestaCuestionarioModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
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
        public virtual ICollection<detallecuestionario> detallecuestionarios
        {
            get { return GetValue(() => detallecuestionarios); }
            set { SetValue(() => detallecuestionarios, value); }
        }
        //public virtual ICollection<detallecuestionarios> detallecuestionarios { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(TipoRespuestaCuestionarioModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tiporespuestacuestionario', 'idtrc'), (SELECT MAX(idtrc) FROM sgpt.tiporespuestacuestionario) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tiporespuestacuestionario
                        {
                            //idtrc = modelo.id,
                            descripciontrc = modelo.descripcion,
                            sistematrc = false,
                            estadotrc = "A"
                        };
                        _context.tiporespuestacuestionarios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtrc;
                        modelo.sistema = tablaDestino.sistematrc;
                        modelo.estado = tablaDestino.estadotrc;
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

        public static string Insert(TipoRespuestaCuestionarioModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tiporespuestacuestionario', 'idtrc'), (SELECT MAX(idtrc) FROM sgpt.tiporespuestacuestionario) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tiporespuestacuestionario
                        {
                            //idtrc = modelo.id,
                            descripciontrc = modelo.descripcion,
                            sistematrc = false,
                            estadotrc = "A"
                        };
                        _context.tiporespuestacuestionarios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtrc;
                        modelo.sistema = tablaDestino.sistematrc;
                        modelo.estado = tablaDestino.estadotrc;
                        result = tablaDestino.idtrc.ToString();
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
            int idtrc = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idtrc = _context.tiporespuestacuestionarios.Max(x => x.idtrc) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idtrc;
        }

        //Devuelve el registro buscado con base al indice
        public static TipoRespuestaCuestionarioModelo Find(int id)
        {
            var entidadModelo = new TipoRespuestaCuestionarioModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idtrc;
                        entidadModelo.descripcion = entidad.descripciontrc;
                        entidadModelo.sistema = entidad.sistematrc;
                        entidadModelo.estado = entidad.estadotrc;
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
                    string commandString = String.Format("DELETE FROM sgpt.tiporespuestacuestionario WHERE idtrc={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static TipoRespuestaCuestionarioModelo Find(string id)
        {
            var modelo = new TipoRespuestaCuestionarioModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idtrc;
                        modelo.descripcion = entidad.descripciontrc;
                        modelo.sistema = entidad.sistematrc;
                        modelo.estado = entidad.estadotrc;

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
                    var modelo = new TipoRespuestaCuestionarioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(id);
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
                    var modelo = new TipoRespuestaCuestionarioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.tiporespuestacuestionarios
                            .Where(b => b.estadotrc == "B")
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
                    tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(id);
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
        public static List<TipoRespuestaCuestionarioModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.tiporespuestacuestionarios.Select(entidad =>
                new TipoRespuestaCuestionarioModelo
                {
                    id = entidad.idtrc,
                    descripcion = entidad.descripciontrc,
                    sistema = entidad.sistematrc,
                    estado = entidad.estadotrc
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
                    var entidad = _context.tiporespuestacuestionarios
                            .Where(b => b.estadotrc == "B")
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

        public static void UpdateModelo(TipoRespuestaCuestionarioModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idtrc = modelo.id;
                        entidad.descripciontrc = modelo.descripcion;
                        entidad.sistematrc = modelo.sistema;
                        entidad.estadotrc = modelo.estado;
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

        public static bool UpdateModelo(TipoRespuestaCuestionarioModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idtrc = modelo.id;
                            entidad.descripciontrc = modelo.descripcion;
                            entidad.sistematrc = modelo.sistema;
                            entidad.estadotrc = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.tiporespuestacuestionario SET estadotrc = 'B' WHERE idtrc={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //tiporespuestacuestionario entidad = _context.tiporespuestacuestionarios.Find(id);
                            //entidad.estadotrc = "B";
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
                            string commandString = String.Format("UPDATE sgpt.tiporespuestacuestionario SET estadotrc = 'B' WHERE idtrc={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.tiporespuestacuestionario WHERE idtrc={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.tiporespuestacuestionario WHERE idtrc={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.tiporespuestacuestionario WHERE idtrc={0};", id);
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

        public static List<TipoRespuestaCuestionarioModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.tiporespuestacuestionarios.Select(entidad =>
                    new TipoRespuestaCuestionarioModelo
                    {
                        id = entidad.idtrc,
                        descripcion = entidad.descripciontrc,
                        sistema = entidad.sistematrc,
                        estado = entidad.estadotrc
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

        #endregion

        public static ObservableCollection<tiporespuestacuestionario> GetAllDisplay()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.tiporespuestacuestionario WHERE estadotrc = 'A' ORDER BY idtrc ;");

                    var listaCapaDatos = _context.tiporespuestacuestionarios.SqlQuery(commandString);
                    ObservableCollection<tiporespuestacuestionario> lista = new ObservableCollection<tiporespuestacuestionario>(listaCapaDatos);
                    //La ordena por el ID notar la notacion
                    tiporespuestacuestionario temporal = new tiporespuestacuestionario
                    {
                        idtrc=0,
                        descripciontrc="",
                        sistematrc=true,
                        estadotrc="A"
                    };
                    lista.Insert(0, temporal);
                    return lista;
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
        public static ObservableCollection<string> GetAllDisplayTexto()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    ObservableCollection<string> listatexto = new ObservableCollection<string>();
                    string commandString = String.Format("SELECT * FROM sgpt.tiporespuestacuestionario WHERE estadotrc = 'A' ORDER BY idtrc ;");

                    var listaCapaDatos = _context.tiporespuestacuestionarios.SqlQuery(commandString);
                    ObservableCollection<tiporespuestacuestionario> lista = new ObservableCollection<tiporespuestacuestionario>(listaCapaDatos);
                    //La ordena por el ID notar la notacion


                    foreach (tiporespuestacuestionario item in lista)
                    {
                        listatexto.Add(item.descripciontrc);
                    }
                    listatexto.Insert(0, " ");
                    return listatexto;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista {0}", e.Source);
                return new ObservableCollection<string>();
            }
        }
        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.tiporespuestacuestionarios
                                   where p.descripciontrc.ToLower().Equals(busqueda)
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
