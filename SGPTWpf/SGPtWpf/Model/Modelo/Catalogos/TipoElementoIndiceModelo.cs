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
    public class TipoElementoIndiceModelo : UIBase
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
        [DisplayName("Icono")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(131072, ErrorMessage = "Excede de 128Kb caracteres permitidos")]
        public byte[] imagen
        {
            get { return GetValue(() => imagen); }
            set { SetValue(() => imagen, value); }
        }
        public virtual ICollection<detalleplantillaindice> detalleplantillaindices
        {
            get { return GetValue(() => detalleplantillaindices); }
            set { SetValue(() => detalleplantillaindices, value); }
        }
        //public virtual ICollection<detalleplantillaindices> detalleplantillaindices { get; set; }

        public ObservableCollection<TipoElementoIndiceModelo> listaEntidadSeleccionTEI
        {
            get { return GetValue(() => listaEntidadSeleccionTEI); }
            set { SetValue(() => listaEntidadSeleccionTEI, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(TipoElementoIndiceModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tipoelementoindice', 'idtei'), (SELECT MAX(idtei) FROM sgpt.tipoelementoindice) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipoelementoindice
                        {
                            //idtei = modelo.id,
                            descripciontei = modelo.descripcion,
                            imagentet = modelo.imagen,
                            sistematei = false,
                            estadotei = "A"
                        };
                        _context.tipoelementoindices.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtei;
                        modelo.sistema = tablaDestino.sistematei;
                        modelo.estado = tablaDestino.estadotei;
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

        public static string Insert(TipoElementoIndiceModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipoelementoindice
                        {
                            //idtei = modelo.id,
                            descripciontei = modelo.descripcion,
                            imagentet = modelo.imagen,
                            sistematei = false,
                            estadotei = "A"
                        };
                        _context.tipoelementoindices.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtei;
                        modelo.sistema = tablaDestino.sistematei;
                        modelo.estado = tablaDestino.estadotei;
                        result = tablaDestino.idtei.ToString();
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
            int idtei = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idtei = _context.tipoelementoindices.Max(x => x.idtei) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idtei;
        }

        //Devuelve el registro buscado con base al indice
        public static TipoElementoIndiceModelo Find(int id)
        {
            var entidadModelo = new TipoElementoIndiceModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    tipoelementoindice entidad = _context.tipoelementoindices.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idtei;
                        entidadModelo.descripcion = entidad.descripciontei;
                        entidadModelo.imagen = entidad.imagentet;
                        entidadModelo.sistema = entidad.sistematei;
                        entidadModelo.estado = entidad.estadotei;
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
                    string commandString = String.Format("DELETE FROM sgpt.tipoelementoindice WHERE idtei={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static TipoElementoIndiceModelo Find(string id)
        {
            var modelo = new TipoElementoIndiceModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    tipoelementoindice entidad = _context.tipoelementoindices.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idtei;
                        modelo.descripcion = entidad.descripciontei;
                        modelo.imagen = entidad.imagentet;
                        modelo.sistema = entidad.sistematei;
                        modelo.estado = entidad.estadotei;

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
                    var modelo = new TipoElementoIndiceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    tipoelementoindice entidad = _context.tipoelementoindices.Find(id);
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
                    var modelo = new TipoElementoIndiceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.tipoelementoindices
                            .Where(b => b.estadotei == "B")
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
                    tipoelementoindice entidad = _context.tipoelementoindices.Find(id);
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
        public static List<TipoElementoIndiceModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.tipoelementoindices.Select(entidad =>
                new TipoElementoIndiceModelo
                {
                    id = entidad.idtei,
                    descripcion = entidad.descripciontei,
                    sistema = entidad.sistematei,
                    imagen=entidad.imagentet,
                    estado = entidad.estadotei
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
                    var entidad = _context.tipoelementoindices
                            .Where(b => b.estadotei == "B")
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

        public static void UpdateModelo(TipoElementoIndiceModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    tipoelementoindice entidad = _context.tipoelementoindices.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idtei = modelo.id;
                        entidad.descripciontei = modelo.descripcion;
                        entidad.imagentet = modelo.imagen;
                        entidad.sistematei = modelo.sistema;
                        entidad.estadotei = modelo.estado;
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

        public static bool UpdateModelo(TipoElementoIndiceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        tipoelementoindice entidad = _context.tipoelementoindices.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idtei = modelo.id;
                            entidad.descripciontei = modelo.descripcion;
                            entidad.imagentet = modelo.imagen;
                            entidad.sistematei = modelo.sistema;
                            entidad.estadotei = modelo.estado;
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
                            string commandString = String.Format("UPDATE sgpt.tipoelementoindice SET estadotei = 'B' WHERE idtei={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //tipoelementoindice entidad = _context.tipoelementoindices.Find(id);
                            //entidad.estadotei = "B";
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
                            string commandString = String.Format("UPDATE sgpt.tipoelementoindice SET estadotei = 'B' WHERE idtei={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.tipoelementoindice WHERE idtei={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.tipoelementoindice WHERE idtei={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.tipoelementoindice WHERE idtei={0};", id);
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

        public static List<TipoElementoIndiceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.tipoelementoindices.Select(entidad =>
                    new TipoElementoIndiceModelo
                    {
                        id = entidad.idtei,
                        descripcion = entidad.descripciontei,
                        imagen=entidad.imagentet,
                        sistema = entidad.sistematei,
                        estado = entidad.estadotei
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

        public static List<TipoElementoIndiceModelo> GetAllPresentacion()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista= _context.tipoelementoindices.Select(entidad =>
                    new TipoElementoIndiceModelo
                    {
                        id = entidad.idtei,
                        descripcion = entidad.descripciontei,
                        imagen = entidad.imagentet,
                        sistema = entidad.sistematei,
                        estado = entidad.estadotei
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    TipoElementoIndiceModelo temporal=new TipoElementoIndiceModelo
                    {
                        id = 0,
                        descripcion = "Ninguno",
                        imagen = null,
                        sistema = false,
                        estado = "A"
                        //Lista filtrada de elementos que fueron eliminados
                    };
                    lista.Insert(0, temporal);
                    //La ordena por el ID notar la notacion
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n"+ e);
                return new List<TipoElementoIndiceModelo>();
            }
        }

        #endregion

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static int FindTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    int cantidad = (from p in _context.tipoelementoindices
                                   where (p.descripciontei.ToLower().Equals(busqueda) && p.estadotei=="A")
                                   select p).Count();
                    if (cantidad == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        return cantidad;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        #endregion

        public TipoElementoIndiceModelo()
        {
            id = 0;
            descripcion = string.Empty;
            imagen = null;
            sistema = false;
            estado = "A";
        }
    }

}



