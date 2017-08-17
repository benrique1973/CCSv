using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;

namespace SGPTWpf.Model
{
    public class ElementoModelo : UIBase
    {
        #region Model Attributes

        public static bool sincronizar { get; set; }


        private static SGPTEntidades _context;

        //Sirve para presentar un correlativo diferente al Id del registro
        #endregion

        #region Model Properties

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

        [DisplayName("Código elemento")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(1, ErrorMessage = "Excede de 1 caracter permitido")]
        [Range(1, 9, ErrorMessage = "Es un valor entre 1 y 9")]
        [RegularExpression(@"^[0-9]{1}", ErrorMessage = "Deben ser números del 1  al 9 ")]
        public int? codigoelemento
        {
            get { return GetValue(() => codigoelemento); }
            set { SetValue(() => codigoelemento, value); }
        }


        [DisplayName("FechaCreacion")]
        public string fechacreacion
        {
            get { return GetValue(() => fechacreacion); }
            set { SetValue(() => fechacreacion, value); }
        }

        public string idnitcliente //Id de  cliente
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }
        public Nullable<int> idscelementos //Sistema contable
        {
            get { return GetValue(() => idscelementos); }
            set { SetValue(() => idscelementos, value); }
        }

        public Nullable<int> padreidelemento //Sistema contable
        {
            get { return GetValue(() => padreidelemento); }
            set { SetValue(() => padreidelemento, value); }
        }

        public virtual ClienteModelo clienteModelo
        {
            get { return GetValue(() => clienteModelo); }
            set { SetValue(() => clienteModelo, value); }
        }

        public virtual DigitosModelo digitosElementoModelo
        {
            get { return GetValue(() => digitosElementoModelo); }
            set { SetValue(() => digitosElementoModelo, value); }
        }

        public virtual SistemaContableModelo sistemaContableModelo
        {
            get { return GetValue(() => sistemaContableModelo); }
            set { SetValue(() => sistemaContableModelo, value); }
        }

        //Creado para trasladar el contenido
        public virtual ElementoModelo elementoModelo
        {
            get { return GetValue(() => elementoModelo); }
            set { SetValue(() => elementoModelo, value); }
        }

        public bool modificadoCodigo
        {
            get { return GetValue(() => modificadoCodigo); }
            set { SetValue(() => modificadoCodigo, value); }
        }

        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        public int numeroCorrelativoElemento
        {
            get { return GetValue(() => numeroCorrelativoElemento); }
            set { SetValue(() => numeroCorrelativoElemento, value); }
        }

        public virtual ObservableCollection<ElementoModelo> listaElementoSeleccion
        {
            get { return GetValue(() => listaElementoSeleccion); }
            set { SetValue(() => listaElementoSeleccion, value); }
        }
        #endregion



        #region Public Model Methods

        public static bool Insert(ElementoModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.elementos', 'idelementos'), (SELECT MAX(idelementos) FROM sgpt.elementos) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new elemento
                        {
                            //idelementos = modelo.id,
                            descripcionelementos = modelo.descripcion,
                            fechacreacionelementos = DateTime.Now.ToString("d"),
                            codigoelemento =(int) modelo.codigoelemento,
                            sistemaelementos = false,
                            estadoelementos = "A",
                            padreidelemento=modelo.padreidelemento,
                        };
                        _context.elementos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id= tablaDestino.idelementos;
                        modelo.sistema = tablaDestino.sistemaelementos;
                        modelo.estado = tablaDestino.estadoelementos;
                        modelo.fechacreacion = tablaDestino.fechacreacionelementos;
                        modelo.modificadoCodigo = false;
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

        public static bool Insert(ElementoModelo modelo, string insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.elementos', 'idelementos'), (SELECT MAX(idelementos) FROM sgpt.elementos) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new elemento
                        {
                            //idelementos = modelo.id,
                            descripcionelementos = modelo.descripcion,
                            idnitcliente=modelo.idnitcliente,
                            idscelementos=modelo.idscelementos,
                            fechacreacionelementos = DateTime.Now.ToString("d"),
                            codigoelemento = (int)modelo.codigoelemento,
                            sistemaelementos = false,
                            estadoelementos = "A",
                             padreidelemento = modelo.padreidelemento,
                        };
                        _context.elementos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idelementos;
                        modelo.sistema = tablaDestino.sistemaelementos;
                        modelo.estado = tablaDestino.estadoelementos;
                        modelo.fechacreacion = tablaDestino.fechacreacionelementos;
                        modelo.modificadoCodigo = false;
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

        public static string Insert(ElementoModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                if (modelo.digitosElementoModelo != null)
                {
                    modelo.codigoelemento = (modelo.digitosElementoModelo.idDigitosModelo);
                }
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.elementos', 'idelementos'), (SELECT MAX(idelementos) FROM sgpt.elementos) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new elemento
                        {
                            //idelementos = modelo.id,
                            descripcionelementos = modelo.descripcion,
                            codigoelemento = (int) modelo.codigoelemento,
                            fechacreacionelementos = DateTime.Now.ToString("d"),
                            sistemaelementos = false,
                            estadoelementos = "A",
                            padreidelemento = modelo.padreidelemento,

                        };
                        _context.elementos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idelementos;
                        modelo.sistema = tablaDestino.sistemaelementos;
                        modelo.estado = tablaDestino.estadoelementos;
                        modelo.modificadoCodigo = false;
                        result = tablaDestino.idelementos.ToString();
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

        //Devuelve el registro buscado con base al indice
        public static ElementoModelo Find(int id)
        {
            var entidadModelo = new ElementoModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    elemento entidad = _context.elementos.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idelementos;
                        entidadModelo.descripcion = entidad.descripcionelementos;
                        entidadModelo.sistema = entidad.sistemaelementos;
                        entidadModelo.estado = entidad.estadoelementos;
                        entidadModelo.codigoelemento = entidad.codigoelemento;
                        entidadModelo.fechacreacion = entidad.fechacreacionelementos;
                        entidadModelo.digitosElementoModelo = new DigitosModelo(entidadModelo.codigoelemento);
                        entidadModelo.modificadoCodigo = false;
                        entidadModelo.padreidelemento = entidad.padreidelemento;
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
                    string commandString = String.Format("DELETE FROM sgpt.elementos WHERE idelementos={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //elemento entidad = _context.elementos.Find(id);
                    //_context.elementos.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static ElementoModelo Find(string id)
        {
            var modelo = new ElementoModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    elemento entidad = _context.elementos.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idelementos;
                        modelo.descripcion = entidad.descripcionelementos;
                        modelo.sistema = entidad.sistemaelementos;
                        modelo.estado = entidad.estadoelementos;
                        modelo.codigoelemento = entidad.codigoelemento;
                        modelo.fechacreacion = entidad.fechacreacionelementos;
                        modelo.digitosElementoModelo = new DigitosModelo(modelo.codigoelemento);
                        modelo.modificadoCodigo = false;
                        modelo.padreidelemento = entidad.padreidelemento;
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
                    var modelo = new ElementoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    elemento entidad = _context.elementos.Find(id);
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
                    var modelo = new ElementoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.elementos
                            .Where(b => b.estadoelementos == "B")
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
                    elemento entidad = _context.elementos.Find(id);
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
        public static List<ElementoModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                var listado= _context.elementos.Select(entidad =>
                new ElementoModelo
                {
                    id = entidad.idelementos,
                    descripcion = entidad.descripcionelementos,
                    sistema = entidad.sistemaelementos,
                    estado = entidad.estadoelementos,
                    codigoelemento = entidad.codigoelemento,
                    fechacreacion = entidad.fechacreacionelementos,
                    padreidelemento=entidad.padreidelemento,
            }).OrderBy(o => o.id).Where(x => x.descripcion.ToUpper() == Texto).ToList();
                //La ordena por el ID notar la notacion
                if (listado == null)
                {
                    return new List<ElementoModelo>();
                }
                else
                {
                    int k = 1;
                    foreach (ElementoModelo item in listado)
                    {
                        item.numeroCorrelativoElemento = k;
                        item.digitosElementoModelo = new DigitosModelo(item.codigoelemento);
                        item.modificadoCodigo = false;
                        k++;
                    }
                    return listado.ToList();
                }
            }

        }



        public static ElementoModelo GetRegistroById(int id)
        {

            using (_context = new SGPTEntidades())
            {
                //string Texto = texto.ToUpper();
                var elementox = _context.elementos.Select(entidad =>
                new ElementoModelo
                {
                    id = entidad.idelementos,
                    descripcion = entidad.descripcionelementos,
                    sistema = entidad.sistemaelementos,
                    estado = entidad.estadoelementos,
                    codigoelemento = entidad.codigoelemento,
                    fechacreacion = entidad.fechacreacionelementos,
                    padreidelemento=entidad.padreidelemento,
                }).Where(x => x.id == id).SingleOrDefault();
                //La ordena por el ID notar la notacion
                if (elementox == null)
                {
                    return new ElementoModelo();
                }
                else
                {
                    return elementox;
                }
            }

        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.elementos
                            .Where(b => b.estadoelementos == "B")
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

        public static void UpdateModelo(ElementoModelo modelo)
        {
            if (!(modelo == null))
            {
                if (modelo.digitosElementoModelo != null)
                {
                    modelo.codigoelemento = (modelo.digitosElementoModelo.idDigitosModelo);
                }
                using (_context = new SGPTEntidades())
                {
                    elemento entidad = _context.elementos.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idelementos = modelo.id;
                        entidad.descripcionelementos = modelo.descripcion;
                        entidad.sistemaelementos = modelo.sistema;
                        entidad.estadoelementos = modelo.estado;
                        entidad.codigoelemento=(int)modelo.codigoelemento;
                        entidad.fechacreacionelementos=modelo.fechacreacion;
                        entidad.padreidelemento = modelo.padreidelemento;
                    }
                    _context.Entry(entidad).State = EntityState.Modified;
                    _context.SaveChanges();
                    modelo.modificadoCodigo = false;
                }
            }
            else
            {
                //No regresa nada
            }
        }

        public static bool UpdateModelo(ElementoModelo modelo, Boolean accion)
        {
            if (!(modelo == null))
            {
                if (modelo.digitosElementoModelo != null)
                {
                    modelo.codigoelemento = (modelo.digitosElementoModelo.idDigitosModelo);
                }
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        elemento entidad = _context.elementos.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            bool actualizar = false;
                            if (entidad.descripcionelementos != modelo.descripcion)
                            {
                                actualizar = true;
                            }
                            else
                            {
                                if (entidad.codigoelemento != (int)modelo.codigoelemento)
                                {
                                    actualizar = true;
                                }
                            }

                            if(actualizar)
                            { 
                            entidad.idelementos = modelo.id;
                            entidad.descripcionelementos = modelo.descripcion;
                            entidad.sistemaelementos = modelo.sistema;
                            entidad.estadoelementos = modelo.estado;
                            entidad.codigoelemento = (int) modelo.codigoelemento;
                            entidad.fechacreacionelementos = modelo.fechacreacion;
                            entidad.padreidelemento = modelo.padreidelemento;
                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                            modelo.modificadoCodigo = false;
                            }
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
                            string commandString = String.Format("UPDATE sgpt.elementos SET estadoelementos = 'B' WHERE idelementos = {0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //elemento entidad = _context.elementos.Find(id);
                            //entidad.estadoelementos = "B";
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
                            string commandString = String.Format("UPDATE sgpt.elementos SET estadoelementos = 'B' WHERE idelementos = {0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //elemento entidad = _context.elementos.Find(id);
                            //entidad.estadoelementos = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.elementos WHERE idelementos={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    //elemento entidad = _context.elementos.Find(id);
                    //_context.elementos.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.elementos WHERE idelementos={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //elemento entidad = _context.elementos.Find(id);
                        //_context.elementos.Remove(entidad);
                        //_context.SaveChanges();
                        return true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en borrar registro de Elemento contable : {0}", e.Source);
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
                            string commandString = String.Format("DELETE FROM sgpt.elementos WHERE idelementos={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //elemento entidad = _context.elementos.Find(id);
                            //_context.elementos.Remove(entidad);
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

        public static List<ElementoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.elementos.Select(entidad =>
                     new ElementoModelo
                     {
                         id = entidad.idelementos,
                         descripcion = entidad.descripcionelementos,
                         sistema = entidad.sistemaelementos,
                         estado = entidad.estadoelementos,
                         idnitcliente=entidad.idnitcliente,
                         idscelementos=entidad.idscelementos,
                         codigoelemento = entidad.codigoelemento,
                         fechacreacion = entidad.fechacreacionelementos,
                         padreidelemento=entidad.padreidelemento,
                          guardadoBase = false,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                        if (listado == null)
                        {
                            return new List<ElementoModelo>();
                        }
                        else
                        {
                        if (listado.Count >= 1)
                        {
                            var itemsToRemove = new ObservableCollection<ElementoModelo>();
                            for (int i = 0; i < listado.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(listado[i].idnitcliente)  || listado[i].idscelementos != null)
                                {
                                    itemsToRemove.Add(listado[i]);
                                }

                            }
                            foreach (var item in itemsToRemove)
                            {
                                listado.Remove(item);
                            }
                        }
                        int k = 1;
                        foreach (ElementoModelo item in listado)
                            {
                                item.digitosElementoModelo = new DigitosModelo(item.codigoelemento);
                                item.modificadoCodigo = false;
                                item.numeroCorrelativoElemento = k;
                                k++;
                            }
                            return listado.ToList();
                        }
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

        public static List<ElementoModelo> GetAllForEncargo()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.elementos.Select(entidad =>
                     new ElementoModelo
                     {
                         id = entidad.idelementos,
                         descripcion = entidad.descripcionelementos,
                         sistema = entidad.sistemaelementos,
                         estado = entidad.estadoelementos,
                         idnitcliente = entidad.idnitcliente,
                         idscelementos = entidad.idscelementos,
                         codigoelemento = entidad.codigoelemento,
                         fechacreacion = entidad.fechacreacionelementos,
                         padreidelemento = entidad.idelementos,
                         guardadoBase = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                    if (listado == null)
                    {
                        return new List<ElementoModelo>();
                    }
                    else
                    {
                        if (listado.Count >= 1)
                        {
                            var itemsToRemove = new ObservableCollection<ElementoModelo>();
                            for (int i = 0; i < listado.Count; i++)
                            {
                                if (!string.IsNullOrEmpty(listado[i].idnitcliente) || listado[i].idscelementos != null)
                                {
                                    itemsToRemove.Add(listado[i]);
                                }

                            }
                            foreach (var item in itemsToRemove)
                            {
                                listado.Remove(item);
                            }
                        }
                        int k = 1;
                        foreach (ElementoModelo item in listado)
                        {
                            item.digitosElementoModelo = new DigitosModelo(item.codigoelemento);
                            item.modificadoCodigo = false;
                            item.numeroCorrelativoElemento = k;
                            k++;
                        }
                        return listado.ToList();
                    }
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
        public static ObservableCollection<elemento> GetBySistemaContableAllCapaDatos(int idSistemaContable)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {

                    string commandString = String.Format("SELECT * FROM sgpt.elementos WHERE idscelementos={0} AND estadoelementos = 'A' ORDER BY idelementos;", idSistemaContable);
                    var lista = _context.elementos.SqlQuery(commandString).ToList();
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    if (lista.Count() > 0)
                    {
                        return new ObservableCollection<elemento>(lista);
                    }
                    else
                    {
                        return new ObservableCollection<elemento>();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista \n" + e);
                return new ObservableCollection<elemento>();
            }

        }

        public static List<ElementoModelo> GetBySistemaContableAll(int idSistemaContable)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.elementos.Select(entidad =>
                     new ElementoModelo
                     {
                         id = entidad.idelementos,
                         descripcion = entidad.descripcionelementos,
                         sistema = entidad.sistemaelementos,
                         estado = entidad.estadoelementos,
                         idnitcliente = entidad.idnitcliente,
                         idscelementos = entidad.idscelementos,
                         codigoelemento = entidad.codigoelemento,
                         fechacreacion = entidad.fechacreacionelementos,
                         padreidelemento=entidad.padreidelemento,
                         guardadoBase = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.id).Where(x => x.estado == "A" && x.idscelementos==idSistemaContable).ToList();
                    //La ordena por el ID notar la notacion
                    if (listado == null)
                    {
                        return new List<ElementoModelo>();
                    }
                    else
                    {
                        if (listado.Count >= 1)
                        {
                            int k = 1;
                            foreach (ElementoModelo item in listado)
                            {
                                item.digitosElementoModelo = new DigitosModelo(item.codigoelemento);
                                item.modificadoCodigo = false;
                                item.numeroCorrelativoElemento = k;
                                k++;
                            }
                        }
                        return listado.ToList();
                    }
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

        public static List<ElementoModelo> GetBySistemaContableAllForSeleccion(int idSistemaContable)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.elementos.Select(entidad =>
                     new ElementoModelo
                     {
                         id = entidad.idelementos,
                         descripcion = entidad.descripcionelementos,
                         sistema = entidad.sistemaelementos,
                         estado = entidad.estadoelementos,
                         idnitcliente = entidad.idnitcliente,
                         idscelementos = entidad.idscelementos,
                         codigoelemento = entidad.codigoelemento,
                         fechacreacion = entidad.fechacreacionelementos,
                         padreidelemento=entidad.padreidelemento,
                         guardadoBase = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.id).Where(x => x.estado == "A" && x.idscelementos == idSistemaContable).ToList();
                    //La ordena por el ID notar la notacion
                    if (listado == null)
                    {
                        return new List<ElementoModelo>();
                    }
                    else
                    {
                        if (listado.Count >= 1)
                        {
                            int k = 1;
                            foreach (ElementoModelo item in listado)
                            {
                                item.digitosElementoModelo = new DigitosModelo(item.codigoelemento);
                                item.modificadoCodigo = false;
                                item.numeroCorrelativoElemento = k;
                                k++;
                            }
                        }
                        ElementoModelo temporal = new ElementoModelo
                        {
                            id = 0,
                            descripcion = "Ninguno",
                            sistema = false,
                            estado = "A",
                            idnitcliente = string.Empty,
                            idscelementos = 0,
                            codigoelemento = 0,
                            fechacreacion = MetodosModelo.homologacionFecha(),
                            guardadoBase = false,
                        };
                        listado.Add(temporal);
                        return listado.OrderBy(o => o.id).ToList();
                    }
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

        public static ObservableCollection<elemento> GetBySistemaContableAllForSeleccionForCapaDatos(int idSistemaContable)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.elementos.Where(entidad => (entidad.idscelementos == idSistemaContable && entidad.estadoelementos == "A"));
                    ObservableCollection<elemento> temporal = new ObservableCollection<elemento>(lista);
                    return temporal;
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
                    var entidad = (from p in _context.elementos
                                   where p.descripcionelementos.ToLower().Equals(busqueda)
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
        public static bool FindTexto(ElementoModelo modelo)
        {
            string busqueda = modelo.descripcion.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = (from p in _context.elementos
                                   where ((p.descripcionelementos.ToLower().Equals(busqueda) || modelo.codigoelemento == p.codigoelemento))
                                   select p).ToList();
                    if (listado.Count == 0)
                    {
                        return false;
                    }
                    else
                    {
                        //Se remueven los  items que son de clientes o de sistemas contables
                        var itemsToRemove = new ObservableCollection<elemento>();
                        for (int i = 0; i < listado.Count; i++)
                        {
                            if (listado[i].idnitcliente!=null|| listado[i].idscelementos != null)
                            {
                                itemsToRemove.Add(listado[i]);
                            }

                        }
                        foreach (var item in itemsToRemove)
                        {
                            listado.Remove(item);
                        }
                        if(listado.Count==0)
                        {
                            return false;
                        }
                        else
                        { 
                            return true;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public static int ContarRepetidos(ElementoModelo modelo)
        {
            string busqueda = modelo.descripcion.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = (from p in _context.elementos
                                   where ((p.descripcionelementos.ToLower().Equals(busqueda)) || (modelo.codigoelemento == p.codigoelemento)) && (p.estadoelementos == "A")
                                   select p).ToList();
                    if (listado.Count == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        //Se remueven los  items que son de clientes o de sistemas contables
                        var itemsToRemove = new ObservableCollection<elemento>();
                        for (int i = 0; i < listado.Count; i++)
                        {
                            if (listado[i].idnitcliente != null || listado[i].idscelementos != null)
                            {
                                itemsToRemove.Add(listado[i]);
                            }

                        }
                        foreach (var item in itemsToRemove)
                        {
                            listado.Remove(item);
                        }
                        if (listado.Count == 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return listado.Count;
                        }
                    }
                }
            }
            else
            {
                return 0;
            }
        }

        #endregion

        #region Constructor
        public ElementoModelo()
        {
                    
                    id = 0;
                    descripcion = string.Empty;
                    sistema = false;
                    estado = "A";
                    codigoelemento = 0;
                    fechacreacion = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
        }
        #endregion

        #region Metodos para registro con clientes
        public static List<ElementoModelo> GetAll(int idSistemaContable)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.elementos.Select(entidad =>
                    new ElementoModelo
                    {
                        id = entidad.idelementos,
                        descripcion = entidad.descripcionelementos,
                        sistema = entidad.sistemaelementos,
                        estado = entidad.estadoelementos,
                        codigoelemento = entidad.codigoelemento,
                        fechacreacion = entidad.fechacreacionelementos,
                        idnitcliente = entidad.idnitcliente,
                        idscelementos = entidad.idscelementos,
                        padreidelemento=entidad.padreidelemento,
                        clienteModelo = new ClienteModelo
                        {
                            idnitcliente = entidad.cliente.idnitcliente,
                            idclasificacion = entidad.cliente.idclasificacion,
                            idpais = entidad.cliente.idpais,
                            idcodigoactividad = entidad.cliente.idcodigoactividad,
                            idsc = entidad.cliente.idsc,
                            iddepartamento = entidad.cliente.iddepartamento,
                            idmunicipio = entidad.cliente.idmunicipio,
                            razonsocialcliente = entidad.cliente.razonsocialcliente,
                            nrccliente = entidad.cliente.nrccliente,
                            direccioncliente = entidad.cliente.direccioncliente,
                            actividadcliente = entidad.cliente.actividadcliente,
                            paginawebcliente = entidad.cliente.paginawebcliente,
                            fechaconstitucioncliente = entidad.cliente.fechaconstitucioncliente,
                            estadocliente = entidad.cliente.estadocliente,
                            //Carga de  entidades
                            actividadModelo = new ActividadModelo
                            {
                                id = entidad.cliente.actividade.idcodigoactividad,
                                descripcion = entidad.cliente.actividade.descripcionactividad,
                                sistema = entidad.cliente.actividade.sistemaactividad,
                                estado = entidad.cliente.actividade.estadoactividad
                            },
                            clasificacionModelo = new ClasificacionModelo
                            {
                                id = entidad.cliente.clasificacione.idclasificacion,
                                descripcion = entidad.cliente.clasificacione.descripcionclasificacion,
                                sistema = entidad.cliente.clasificacione.sistemaclasificacion,
                                estado = entidad.cliente.clasificacione.estadoclasificacion
                            },
                            paisModelo = new PaisModelo
                            {
                                id = entidad.cliente.pais.idpais,
                                descripcion = entidad.cliente.pais.nombrepais,
                                sistema = entidad.cliente.pais.sistemapais,
                                estado = entidad.cliente.pais.estadopais
                            },
                            departamentoModelo = new DepartamentoModelo
                            {
                                id = entidad.cliente.departamento.iddepartamento,
                                descripcion = entidad.cliente.departamento.nombredepartamento,
                                sistema = entidad.cliente.departamento.sistemadepartamento,
                                idpais = entidad.cliente.departamento.idpais,
                                estado = entidad.cliente.departamento.estadodepartamento,
                                pais = new PaisModelo
                                {
                                    id = entidad.cliente.departamento.pais.idpais,
                                    descripcion = entidad.cliente.departamento.pais.nombrepais,
                                    sistema = entidad.cliente.departamento.pais.sistemapais,
                                    estado = entidad.cliente.departamento.pais.estadopais
                                }
                            },
                            municipioModelo = new MunicipioModelo
                            {
                                id = entidad.cliente.municipio.idmunicipio,
                                descripcion = entidad.cliente.municipio.nombremunicipio,
                                sistema = entidad.cliente.municipio.sistemamunicipio,
                                estado = entidad.cliente.municipio.estadomunicipio,
                                nombrePais = entidad.cliente.municipio.departamento.pais.nombrepais,
                                nombreDepartamento = entidad.cliente.municipio.departamento.nombredepartamento,
                                iddepartamento = entidad.cliente.municipio.iddepartamento,
                                departamento = new DepartamentoModelo
                                {
                                    id = entidad.cliente.municipio.departamento.iddepartamento,
                                    descripcion = entidad.cliente.municipio.departamento.nombredepartamento,
                                    sistema = entidad.cliente.municipio.departamento.sistemadepartamento,
                                    idpais = entidad.cliente.municipio.departamento.idpais,
                                    estado = entidad.cliente.municipio.departamento.estadodepartamento,
                                    pais = new PaisModelo
                                    {
                                        id = entidad.cliente.municipio.departamento.pais.idpais,
                                        descripcion = entidad.cliente.municipio.departamento.pais.nombrepais,
                                        sistema = entidad.cliente.municipio.departamento.pais.sistemapais,
                                        estado = entidad.cliente.municipio.departamento.pais.estadopais
                                    }
                                }
                            }
                        },
                        sistemaContableModelo = new SistemaContableModelo
                        {
                            idsc = entidad.sistemascontable.idsc,
                            idmoneda = entidad.sistemascontable.idmoneda,
                            idnitcliente = entidad.sistemascontable.idnitcliente,
                            ideef = entidad.sistemascontable.ideef,
                            fechasc = entidad.sistemascontable.fechasc,
                            digitoscuentamayorsc = entidad.sistemascontable.digitoscuentamayorsc,
                            digitosrubroscontablessc = entidad.sistemascontable.digitosrubroscontablessc,
                            periodoiniciosc = entidad.sistemascontable.periodoiniciosc,
                            periodofinsc = entidad.sistemascontable.periodofinsc,
                            estadosc = entidad.sistemascontable.estadosc,
                            //Carga de  entidades
                            estructuraEstadoFinancieroModelo = new EstructuraEstadoFinancieroModelo
                            {
                                id = entidad.sistemascontable.estructuraestadofinanciero.ideef,
                                descripcion = entidad.sistemascontable.estructuraestadofinanciero.descripcioneef,
                                sistema = entidad.sistemascontable.estructuraestadofinanciero.sistemaeef,
                                estado = entidad.sistemascontable.estructuraestadofinanciero.estadoeef
                            },

                            monedaModelo = new MonedaModelo
                            {
                                id = entidad.sistemascontable.moneda.idmoneda,
                                descripcion = entidad.sistemascontable.moneda.nombremoneda,
                                sistema = entidad.sistemascontable.moneda.sistemamoneda,
                                estado = entidad.sistemascontable.moneda.estadomoneda,
                                simbolomoneda = entidad.sistemascontable.moneda.simbolomoneda
                            },

                        },
                        guardadoBase = true,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.codigoelemento).Where(x => x.estado == "A" && ((x.idscelementos == idSistemaContable))).ToList();
                    //La ordena por el ID notar la notacion
                    if (listado == null)
                    {
                        return new List<ElementoModelo>();
                    }
                    else
                    {
                        int k = 1;
                        foreach (ElementoModelo item in listado)
                        {
                            item.digitosElementoModelo = new DigitosModelo(item.codigoelemento);
                            item.modificadoCodigo = false;
                            item.numeroCorrelativoElemento = k;
                            k++;
                        }
                        return listado.ToList();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de Elementos {0}", e.Source);
                throw;
            }
        }
        #endregion


        #region IDataErrorInfo Members

        //public string Error
        //{
        //    get { throw new NotImplementedException(); }
        //}

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "descripcion")
                {
                    if (string.IsNullOrEmpty(descripcion))
                        result = "Por favor introduzca la descripción del elemento contable";
                }
                if (columnName == "codigoelemento")
                {
                    if (codigoelemento <= 0 || codigoelemento >= 10)
                        result = "Por favor introduzca un código  válido  entre 1 y 9";
                }
                return result;
            }
        }

        public static bool Iguales(ElementoModelo destino, elemento origen)
        {
            bool igual = true;
            if (destino.id == origen.idelementos)
                igual = false;
            if (destino.descripcion.Trim().ToUpper() == origen.descripcionelementos.Trim().ToUpper())
                igual = false;
            if (destino.sistema== origen.sistemaelementos)
                igual = false;
            if (destino.estado == origen.estadoelementos)
                igual = false;
            if (destino.codigoelemento == (int)origen.codigoelemento)
                igual = false;
            if (destino.fechacreacion == origen.fechacreacionelementos)
               igual = false;
            return igual;
        }

        public static ElementoModelo Clonar(ElementoModelo destino, elemento origen)
        {
            destino.id = origen.idelementos;
            destino.descripcion = origen.descripcionelementos;
            destino.sistema = origen.sistemaelementos;
            destino.estado = origen.estadoelementos;
            destino.codigoelemento = (int)origen.codigoelemento;
            destino.fechacreacion = origen.fechacreacionelementos;
            destino.padreidelemento = origen.padreidelemento;
            return destino;
        }

        public static bool DeleteBorradoLogico(ObservableCollection<ElementoModelo> lista, int idsc)
        {
            if (lista.Count > 0)
            {
                try
                {
                        using (_context = new SGPTEntidades())
                        {
                        string commandString = String.Format("UPDATE sgpt.elementos SET estadoelementos = 'B' WHERE idscelementos = {0};", idsc);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //string commandString = String.Format("UPDATE  sgpt.elementos SET  estadoelementos = 'B' WHERE idscelementos = {0};", idsc);
                        //commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                        //    //Se elimina todo el contenido
                        //    _context.SaveChanges();
                        }
                    return true;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                    }
                    return false;
                    throw;
                }
            }
            else
            {
                return true;
            }
        }

        //Conversion explicita
        public static explicit operator elemento(ElementoModelo modelo)  // explicit byte to digit conversion operator
        {
            elemento entidad = new elemento();
            entidad.idelementos = modelo.id;
            entidad.descripcionelementos = modelo.descripcion;
            entidad.sistemaelementos = modelo.sistema;
            entidad.estadoelementos = modelo.estado;
            entidad.codigoelemento = (int)modelo.codigoelemento;
            entidad.fechacreacionelementos = modelo.fechacreacion;
            entidad.padreidelemento = modelo.padreidelemento;
            // explicit conversion
            return entidad;
        }

        public static int InsertByRange(ObservableCollection<elemento> lista)
        {
            int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.elementos', 'idelementos'), (SELECT MAX(idelementos) FROM sgpt.elementos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.elementos.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de catalogo de cuentas: " + e.Message);
                    return result;
                    throw;

                }
            }
            else
            {
                return result;
            }
        }


        #endregion
    }

}

