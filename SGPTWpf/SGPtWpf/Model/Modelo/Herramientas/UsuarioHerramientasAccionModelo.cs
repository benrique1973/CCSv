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
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.Herramientas
{
    
    public class UsuarioHerramientasAccionModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idUha
        {
            get { return GetValue(() => idUha); }
            set { SetValue(() => idUha, value); }
        }
        public int idHerramienta
        {
            get { return GetValue(() => idHerramienta); }
            set { SetValue(() => idHerramienta, value); }
        }
        public Nullable<int> idUsuario
        {
            get { return GetValue(() => idUsuario); }
            set { SetValue(() => idUsuario, value); }
        }


        [DisplayName("Rol del usuario")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(1, ErrorMessage = "Excede de 1 caracter permitido")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string rolUha
        {
            get { return GetValue(() => rolUha); }
            set { SetValue(() => rolUha, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public DateTime fechaCreadoUha
        {
            get { return GetValue(() => fechaCreadoUha); }
            set { SetValue(() => fechaCreadoUha, value); }
        }

        public string fechaCreadoUhaString
        {
            get { return GetValue(() => fechaCreadoUhaString); }
            set { SetValue(() => fechaCreadoUhaString, value); }
        }

        [MaxLength(1, ErrorMessage = "Excede de 1 caracter permitido")]
        public string estadoUha
        {
            get { return GetValue(() => estadoUha); }
            set { SetValue(() => estadoUha, value); }
        }

        public virtual usuario usuario
        {
            get { return GetValue(() => usuario); }
            set { SetValue(() => usuario, value); }
        }

        #endregion

        #region Public Model Methods

        #region Propiedades de la vista

        #endregion

        public static bool Insert(UsuarioHerramientasAccionModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarioherramientasaccion', 'iduha'), (SELECT MAX(iduha) FROM sgpt.usuarioherramientasaccion) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new usuarioherramientasaccion
                        {
                            //
                            //idUha = modelo.idUha,
                            idusuario = modelo.idUsuario,
                            idherramienta = modelo.idHerramienta,
                            roluha = modelo.rolUha,
                            fechacreadouha = DateTime.Now.ToString("d"),
                            estadouha = "A",
                        };
                        _context.usuarioherramientasaccions.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idUha = tablaDestino.iduha;
                        modelo.estadoUha = tablaDestino.estadouha;
                        modelo.fechaCreadoUha = DateTime.Parse(tablaDestino.fechacreadouha);
                        result = true;
                    }
                }
                catch (DbEntityValidationException e)
                {
                    //http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(UsuarioHerramientasAccionModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        var tablaDestino = new usuarioherramientasaccion
                        {
                            //
                            //idUha = modelo.idUha,
                            idusuario = modelo.idUsuario,
                            idherramienta = modelo.idHerramienta,
                            roluha = modelo.rolUha,
                            fechacreadouha = DateTime.Now.ToString("d"),
                            estadouha = "A",
                        };
                        _context.usuarioherramientasaccions.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idUha = tablaDestino.iduha;
                        modelo.estadoUha = tablaDestino.estadouha;
                        modelo.fechaCreadoUha = DateTime.Parse(tablaDestino.fechacreadouha);
                        result = tablaDestino.iduha.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : " + e.Message);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        //Devuelve el registro buscado con base al indice
        public static UsuarioHerramientasAccionModelo Find(int id)
        {
            var entidadModelo = new UsuarioHerramientasAccionModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(id);
                    if (entidad == null)
                    {
                        entidadModelo = null;
                    }
                    else
                    {
                        //idUha = modelo.idUha,
                        entidadModelo.idUha = entidad.iduha;
                        entidadModelo.idUsuario = entidad.idusuario;
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.rolUha = entidad.roluha;
                        entidadModelo.fechaCreadoUhaString = entidad.fechacreadouha;//Generara error conversion de fechas
                        
                        
                        entidadModelo.estadoUha = entidad.estadouha;
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
                    entidadModelo.fechaCreadoUha = DateTime.Parse(entidadModelo.fechaCreadoUhaString);
                    return entidadModelo;
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
                    string commandString = String.Format("DELETE FROM sgpt.usuarioherramientasaccion WHERE iduha={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static UsuarioHerramientasAccionModelo Find(string id)
        {
            var entidadModelo = new UsuarioHerramientasAccionModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idUha = entidad.iduha;
                        entidadModelo.idUsuario = entidad.idusuario;
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.rolUha = entidad.roluha;
                        entidadModelo.fechaCreadoUhaString = entidad.fechacreadouha;//Generara error conversion de fechas
                        entidadModelo.estadoUha = entidad.estadouha;
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
                    entidadModelo.fechaCreadoUha = DateTime.Parse(entidadModelo.fechaCreadoUhaString);
                    return entidadModelo;
                }
            }
            else
            {
                return entidadModelo;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new UsuarioHerramientasAccionModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(id);
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
                    var modelo = new UsuarioHerramientasAccionModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.usuarioherramientasaccions
                            .Where(b => b.estadouha == "B")
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
                    usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(id);
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
        public static List<UsuarioHerramientasAccionModelo> TransformLista(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.usuarioherramientasaccions.Select(entidad =>
                new UsuarioHerramientasAccionModelo
                {
                    idUha = entidad.iduha,
                    idUsuario = entidad.idusuario,
                    idHerramienta = entidad.idherramienta,
                    rolUha = entidad.roluha,
                    fechaCreadoUhaString = entidad.fechacreadouha,//Generara error conversion de fechas
                    estadoUha = entidad.estadouha,
                    
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idUha).Where(x => x.rolUha.ToUpper() == Texto).ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }

        public static List<UsuarioHerramientasAccionModelo> GetAllPkContenido(string texto)
        {
            var Lista = TransformLista(texto);
            Lista.ForEach(c => c.fechaCreadoUha = DateTime.Parse(c.fechaCreadoUhaString));
            return Lista;   //Transformacion necesaria por la fecha 
        }



        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.usuarioherramientasaccions
                            .Where(b => b.estadouha == "B")
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

        public static void UpdateModelo(UsuarioHerramientasAccionModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(modelo.idUha);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.iduha = modelo.idUha;
                        entidad.idusuario = modelo.idUsuario;
                        entidad.idherramienta = modelo.idHerramienta;
                        entidad.roluha = modelo.rolUha;
                        entidad.fechacreadouha = modelo.fechaCreadoUha.ToString();
                        
                        
                        entidad.estadouha = modelo.estadoUha;
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

        public static bool UpdateModelo(UsuarioHerramientasAccionModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(modelo.idUha);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.iduha = modelo.idUha;
                            entidad.idusuario = modelo.idUsuario;
                            entidad.idherramienta = modelo.idHerramienta;
                            entidad.roluha = modelo.rolUha;
                            entidad.fechacreadouha = modelo.fechaCreadoUha.ToString();
                            entidad.estadouha = modelo.estadoUha;
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
                        MessageBox.Show("Exception en actualizar : " + e.Message);
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
                            string commandString = String.Format("UPDATE sgpt.usuarioherramientasaccion SET estadouha = 'B' WHERE iduha={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //usuarioherramientasaccion entidad = _context.usuarioherramientasaccions.Find(id);
                            //entidad.estadouha = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
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
                            string commandString = String.Format("UPDATE sgpt.usuarioherramientasaccion SET estadouha = 'B' WHERE iduha={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
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
                    string commandString = String.Format("DELETE FROM sgpt.usuarioherramientasaccion WHERE iduha={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.usuarioherramientasaccion WHERE iduha={0};", id);
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
                        MessageBox.Show("Exception en borrar registro : " + e.Message);
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
                            string commandString = String.Format("DELETE FROM sgpt.usuarioherramientasaccion WHERE iduha={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Source);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<UsuarioHerramientasAccionModelo> GetAllTransform()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.usuarioherramientasaccions.Select(entidad =>
                    new UsuarioHerramientasAccionModelo
                    {
                        idUha = entidad.iduha,
                        idUsuario = entidad.idusuario,
                        idHerramienta = entidad.idherramienta,
                        rolUha = entidad.roluha,
                        fechaCreadoUhaString = entidad.fechacreadouha,//Generara error conversion de fechas
                        estadoUha = entidad.estadouha,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idUha).Where(x => x.estadoUha == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista " + e.Message);
                }
                return null;
            }
        }
        public static List<UsuarioHerramientasAccionModelo> GetAll()
        {
            var Lista = GetAllTransform();
            Lista.ForEach(c => c.fechaCreadoUha = DateTime.Parse(c.fechaCreadoUhaString));
            return Lista;   //Transformacion necesaria por la fecha 
        }


        public static List<UsuarioHerramientasAccionModelo> GetAll(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.usuarioherramientasaccions.ToList().Where(x => x.estadouha == "A").Where(x => x.idherramienta == idHerramienta).Select(entidad => new UsuarioHerramientasAccionModelo
                    {
                        idUha = entidad.iduha,
                        idUsuario = entidad.idusuario,
                        idHerramienta = entidad.idherramienta,
                        rolUha = entidad.roluha,
                        fechaCreadoUhaString = entidad.fechacreadouha,//Generara error conversion de fechas
                        fechaCreadoUha = DateTime.Parse(entidad.fechacreadouha),
                        estadoUha = entidad.estadouha,
                    });
                    return DateQuery.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista " + e.Message + " " + e.Source);
                throw;
                //return null;
            }
        }

        public static List<UsuarioHerramientasAccionModelo> GetAllEncabezados(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.usuarioherramientasaccions.Select(entidad =>
                        new UsuarioHerramientasAccionModelo
                        {
                            idUha = entidad.iduha,
                            idUsuario = entidad.idusuario,
                            idHerramienta = entidad.idherramienta,
                            rolUha = entidad.roluha,
                            estadoUha = entidad.estadouha,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idUha).Where(x => x.estadoUha == "A").Where(x => x.idHerramienta == idHerramienta).ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista " + e.Message + " " + e.Source);
                throw;
                //return null;
            }
        }



        public static List<UsuarioHerramientasAccionModelo> GetAllEncabezados()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.usuarioherramientasaccions.Select(entidad =>
                        new UsuarioHerramientasAccionModelo
                        {
                            idUha = entidad.iduha,
                            idUsuario = entidad.idusuario,
                            idHerramienta = entidad.idherramienta,
                            rolUha = entidad.roluha,
                            
                            estadoUha = entidad.estadouha,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idUha).Where(x => x.estadoUha == "A").ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista " + e.Message + " " + e.Source);
                throw;
                //return null;
            }
        }
        #endregion

        #region Contar registros
        public static int ContarRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.usuarioherramientasaccions.Where(x => x.idherramienta == id && x.estadouha == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: " + e.Message);
                return elementos;
            }
        }

        public static int ContarRegistros()
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.usuarioherramientasaccions.Where(x => x.estadouha == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: " + e.Message);
                return elementos;
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
                    var entidad = (from p in _context.usuarioherramientasaccions
                                   where p.roluha.ToLower().Equals(busqueda)
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

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static UsuarioHerramientasAccionModelo Clear(UsuarioHerramientasAccionModelo modelo)
        {
            return new UsuarioHerramientasAccionModelo();
        }

        #endregion
    }
}




