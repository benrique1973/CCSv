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

namespace SGPTWpf.Model.Modelo.Plantilla
{
    public class DetalleDocumentoModelo : UIBase
    {
        #region Model Attributes


        public static bool sincronizar { get; set; }

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Codigo")]
        public int iddd
        {
            get { return GetValue(() => iddd); }
            set { SetValue(() => iddd, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(100, ErrorMessage = "Excede de 100 caracteres permitidddos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidddos")]
        public string descripciondd
        {
            get { return GetValue(() => descripciondd); }
            set { SetValue(() => descripciondd, value); }
        }
        [DisplayName("sistema")]
        public bool sistemadd
        {
            get { return GetValue(() => sistemadd); }
            set { SetValue(() => sistemadd, value); }
        }
        [DisplayName("estado")]
        public string estadodd
        {
            get { return GetValue(() => estadodd); }
            set { SetValue(() => estadodd, value); }
        }
        [DisplayName("Documento")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de  documento")]
        public Nullable<int> iddocumento
        {
            get { return GetValue(() => iddocumento); }
            set { SetValue(() => iddocumento, value); }
        }
        public string nombreDocumento
        {
            get { return GetValue(() => nombreDocumento); }
            set { SetValue(() => nombreDocumento, value); }
        }

        public virtual DocumentoModelo documentoModelo
        {
            get { return GetValue(() => documentoModelo); }
            set { SetValue(() => documentoModelo, value); }
        }

        //public virtual ICollection<clientes> clientes { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(DetalleDocumentoModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalledocumentos', 'iddd'), (SELECT MAX(iddd) FROM sgpt.detalledocumentos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idddmaestrocatalogo;
                        var tablaDestino = new detalledocumento
                        {
                            //iddd = modelo.iddd,
                            descripciondd = modelo.descripciondd,
                            iddocumento = modelo.documentoModelo.id,
                            sistemadd = false,
                            estadodd = "A"
                        };
                        _context.detalledocumentos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.iddd = tablaDestino.iddd;
                        modelo.sistemadd = tablaDestino.sistemadd;
                        modelo.estadodd = tablaDestino.estadodd;
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

        public static string Insert(DetalleDocumentoModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.departamentos', 'iddd'), (SELECT MAX(iddd) FROM sgpt.departamentos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idddmaestrocatalogo;
                        var tablaDestino = new detalledocumento
                        {
                            //iddd = modelo.iddd,
                            descripciondd = modelo.descripciondd,
                            iddocumento = modelo.iddocumento,
                            sistemadd = false,
                            estadodd = "A"
                        };
                        _context.detalledocumentos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.iddd = tablaDestino.iddd;
                        modelo.sistemadd = tablaDestino.sistemadd;
                        modelo.estadodd = tablaDestino.estadodd;
                        result = tablaDestino.iddd.ToString();
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
            int iddd = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    iddd = _context.detalledocumentos.Max(x => x.iddd) + 1;
                    //iddd = _context.detalledocumentos.Count() + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidddad de registros: {0}", e.Source);
                throw;
            }
            return iddd;
        }

        //Devuelve el registro buscado con base al indice
        public static DetalleDocumentoModelo Find(int iddd)
        {
            var entidadModelo = new DetalleDocumentoModelo();
            if (!(iddd == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detalledocumento entidad = _context.detalledocumentos.Find(iddd);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.iddd = entidad.iddd;
                        entidadModelo.descripciondd = entidad.descripciondd;
                        entidadModelo.iddocumento = entidad.iddocumento;
                        entidadModelo.sistemadd = entidad.sistemadd;
                        entidadModelo.estadodd = entidad.estadodd;
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

        public static void Delete(string iddd)
        {
            if (!(string.IsNullOrEmpty(iddd)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.detalledocumentos WHERE iddd={0};", iddd);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static DetalleDocumentoModelo Find(string iddd)
        {
            var modelo = new DetalleDocumentoModelo();
            if (!(string.IsNullOrEmpty(iddd)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(iddd))
                    {
                        return modelo = null;
                    }
                    detalledocumento entidad = _context.detalledocumentos.Find(iddd);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.iddd = entidad.iddd;
                        modelo.descripciondd = entidad.descripciondd;
                        modelo.sistemadd = entidad.sistemadd;
                        modelo.estadodd = entidad.estadodd;

                        return modelo;
                    }
                }
            }
            else
            {
                return modelo;
            }

        }

        public static bool FindPK(string iddd)
        {
            if (!(string.IsNullOrEmpty(iddd)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleDocumentoModelo();
                    if (string.IsNullOrEmpty(iddd))
                    {
                        return true;
                    }
                    detalledocumento entidad = _context.detalledocumentos.Find(iddd);
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
        public static bool FindPK(string iddd, Boolean eliminado)
        {
            if (!(string.IsNullOrEmpty(iddd) || string.IsNullOrWhiteSpace(iddd)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleDocumentoModelo();
                    if (string.IsNullOrEmpty(iddd))
                    {
                        return false;
                    }
                    var entidad = _context.detalledocumentos
                            .Where(b => b.estadodd == "B")
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

        public static bool FindPK(int iddd)
        {
            if (iddd == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    detalledocumento entidad = _context.detalledocumentos.Find(iddd);
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
        public static List<DetalleDocumentoModelo> GetAllPkContenidddo(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.detalledocumentos.Select(entidad =>
                new DetalleDocumentoModelo
                {
                    iddd = entidad.iddd,
                    descripciondd = entidad.descripciondd,
                    sistemadd = entidad.sistemadd,
                    iddocumento = entidad.iddocumento,
                    estadodd = entidad.estadodd,
                    documentoModelo = new DocumentoModelo
                    {
                        id = entidad.documento.iddocumento,
                        descripcion = entidad.documento.descripciondocumento,
                        sistema = entidad.documento.sistemadocumento,
                        estado = entidad.documento.estadodocumento
                    }
        }).OrderBy(o => o.iddd).Where(x => x.descripciondd.ToUpper() == Texto).ToList();
                //La ordena por el ID notar la notacion
            }

        }
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int iddd, Boolean eliminado)
        {
            if (!(iddd == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.detalledocumentos
                            .Where(b => b.estadodd == "B")
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

        public static void UpdateModelo(DetalleDocumentoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detalledocumento entidad = _context.detalledocumentos.Find(modelo.iddd);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.iddd = modelo.iddd;
                        entidad.descripciondd = modelo.descripciondd;
                        entidad.iddocumento = modelo.iddocumento;
                        entidad.sistemadd = modelo.sistemadd;
                        entidad.estadodd = modelo.estadodd;
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

        public static bool UpdateModelo(DetalleDocumentoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        detalledocumento entidad = _context.detalledocumentos.Find(modelo.iddd);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddd = modelo.iddd;
                            entidad.descripciondd = modelo.descripciondd;
                            entidad.sistemadd = modelo.sistemadd;
                            entidad.iddocumento = modelo.documentoModelo.id;
                            entidad.estadodd = "A";
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
        public static bool DeleteBorradoLogico(int iddd, Boolean actualizar)
        {
            bool result = false;
            if (!(iddd == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.detalledocumentos SET estadodd = 'B' WHERE iddd={0};", iddd);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //detalledocumento entidad = _context.detalledocumentos.Find(iddd);
                            //entidad.estadodd = "B";
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

        public static bool DeleteBorradoLogico(string iddd, Boolean actualizar)
        {
            bool result = false;
            if (!((string.IsNullOrEmpty(iddd)) || string.IsNullOrWhiteSpace(iddd)))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.detalledocumentos SET estadodd = 'B' WHERE iddd={0};", iddd);
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
        public static void Delete(int iddd)
        {
            if (iddd == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.detalledocumentos WHERE iddd={0};", iddd);
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
        public static bool Delete(int iddd, Boolean actualizar)
        {
            if (!(iddd == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.detalledocumentos WHERE iddd={0};", iddd);
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

        public static bool Delete(string iddd, Boolean actualizar)
        {
            {

                if (!((string.IsNullOrEmpty(iddd)) || string.IsNullOrWhiteSpace(iddd)))
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("DELETE FROM sgpt.detalledocumentos WHERE iddd={0};", iddd);
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

        public static List<DetalleDocumentoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.detalledocumentos.Select(entidad =>
                    new DetalleDocumentoModelo
                    {
                        iddd = entidad.iddd,
                        descripciondd = entidad.descripciondd,
                        sistemadd = entidad.sistemadd,
                        iddocumento = entidad.documento.iddocumento,
                        nombreDocumento = entidad.documento.descripciondocumento,
                        estadodd = entidad.estadodd,
                        documentoModelo= new DocumentoModelo {
                            id = entidad.documento.iddocumento,
                            descripcion = entidad.documento.descripciondocumento,
                            sistema = entidad.documento.sistemadocumento,
                            estado = entidad.documento.estadodocumento
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.nombreDocumento).Where(x => x.estadodd == "A").ToList();
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

        public static List<DetalleDocumentoModelo> GetAll(int iddocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.detalledocumentos.Select(entidad =>
                    new DetalleDocumentoModelo
                    {
                        iddd = entidad.iddd,
                        descripciondd = entidad.descripciondd,
                        sistemadd = entidad.sistemadd,
                        iddocumento = entidad.documento.iddocumento,
                        nombreDocumento = entidad.documento.descripciondocumento,
                        estadodd = entidad.estadodd,
                                            documentoModelo = new DocumentoModelo
                                            {
                                                id = entidad.documento.iddocumento,
                                                descripcion = entidad.documento.descripciondocumento,
                                                sistema = entidad.documento.sistemadocumento,
                                                estado = entidad.documento.estadodocumento
                                            }
                                            //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.nombreDocumento).Where(x => (x.estadodd == "A" && x.iddocumento == iddocumento)).ToList();
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
                    var entidad = (from p in _context.detalledocumentos
                                   where p.descripciondd.ToLower().Equals(busqueda)
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

        public static bool FindTexto(DetalleDocumentoModelo modelo)
        {
            string busqueda = modelo.descripciondd.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.detalledocumentos
                                   where p.descripciondd.ToLower().Equals(busqueda)
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
        public static int FindTextoEliminados(DetalleDocumentoModelo modelo)
        {
            string busqueda = modelo.descripciondd.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.detalledocumentos
                                   where p.estadodd=="B" && p.descripciondd.ToLower().Equals(busqueda)
                                   select p).FirstOrDefault();
                    if (entidad == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return entidad.iddd;
                    }
                }
            }
            else
            {
                return 0;
            }
        }
        
        #endregion
    }

}
