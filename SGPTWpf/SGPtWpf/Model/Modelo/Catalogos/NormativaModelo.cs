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
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo
{
    public class NormativaModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties


        public static bool sincronizar { get; set; }

        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }
        //Sirve para verificar que no  existan duplicados
        public virtual ObservableCollection<NormativaModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
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
        [MaxLength(25, ErrorMessage = "Excede de 25 caracteres permitidos")]
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
        [DisplayName("Pdf")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(131072, ErrorMessage = "Excede de 128Kb caracteres permitidos")]
        public byte[] binarioNormativa
        {
            get { return GetValue(() => binarioNormativa); }
            set { SetValue(() => binarioNormativa, value); }
        }
        public Nullable<int> idln
        {
            get { return GetValue(() => idln); }
            set { SetValue(() => idln, value); }
        }
        public string idNormalegalNombre
        {
            get { return GetValue(() => idNormalegalNombre); }
            set { SetValue(() => idNormalegalNombre, value); }
        }
        public Nullable<int> idusuario
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }
        public string idUsuarioNombre
        {
            get { return GetValue(() => idUsuarioNombre); }
            set { SetValue(() => idUsuarioNombre, value); }
        }
        [DisplayName("Nombre normativa")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(200, ErrorMessage = "Excede de 200 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string nombrenormativa
        {
            get { return GetValue(() => nombrenormativa); }
            set { SetValue(() => nombrenormativa, value); }
        }

        [DisplayName("Fecha de emisión")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechaemisionnormativa
        {
            get { return GetValue(() => fechaemisionnormativa); }
            set { SetValue(() => fechaemisionnormativa, value); }
        }
        [DisplayName("Fecha de vigencia")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"(^((((0[1-9])|([1-2][0-9])|(3[0-1]))|([1-9]))\x2F(((0[1-9])|(1[0-2]))|([1-9]))\x2F(([0-9]{2})|(((19)|([2]([0]{1})))([0-9]{2}))))$)", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechavigencianormativa
        {
            get { return GetValue(() => fechavigencianormativa); }
            set { SetValue(() => fechavigencianormativa, value); }
        }
        [DisplayName("Fecha de creación del registro")]
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechacreadonormativa
        {
            get { return GetValue(() => fechacreadonormativa); }
            set { SetValue(() => fechacreadonormativa, value); }
        }

        public decimal ordennormativa
        {
            get { return GetValue(() => ordennormativa); }
            set { SetValue(() => ordennormativa, value); }
        }

        public virtual LegalNormaModelo legalNormaModelo
        {
            get { return GetValue(() => legalNormaModelo); }
            set { SetValue(() => legalNormaModelo, value); }
        }
        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion

        public string nombrearchivonormativa
        {
            get { return GetValue(() => nombrearchivonormativa); }
            set { SetValue(() => nombrearchivonormativa, value); }
        }
        #endregion

        #region Public Model Methods


        public static bool Insert(NormativaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.normativas', 'idnormativa'), (SELECT MAX(idnormativa) FROM sgpt.normativas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new normativa
                        {
                            //idtei = modelo.id,
                            idln = modelo.idln,
                            idusuario = modelo.idusuario,
                            nombrenormativa = modelo.nombrenormativa,
                            nombreabreviadonormativa = modelo.descripcion,
                            fechaemisionnormativa = modelo.fechaemisionnormativa,
                            fechavigencianormativa = modelo.fechavigencianormativa,
                            fechacreadonormativa = modelo.fechacreadonormativa,
                            binarionormativa = modelo.binarioNormativa,
                            ordennormativa = modelo.ordennormativa,
                            sistemanormativa = false,
                            nombrearchivonormativa=modelo.nombrearchivonormativa,
                            estadonormativa = "A",
                        };
                        _context.normativas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idnormativa;
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
                /*catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : {0}", e.Source);
                    return false;
                }*/
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(NormativaModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new normativa
                        {
                            //idtei = modelo.id,
                            idln = modelo.idln,
                            idusuario = modelo.idusuario,
                            nombrenormativa = modelo.nombrenormativa,
                            nombreabreviadonormativa = modelo.descripcion,
                            fechaemisionnormativa = modelo.fechaemisionnormativa,
                            fechavigencianormativa = modelo.fechavigencianormativa,
                            fechacreadonormativa = modelo.fechacreadonormativa,
                            binarionormativa = modelo.binarioNormativa,
                            ordennormativa = modelo.ordennormativa,
                            sistemanormativa = false,
                            estadonormativa = "A",
                            nombrearchivonormativa = modelo.nombrearchivonormativa
                        };
                        _context.normativas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idnormativa;
                        result = tablaDestino.idnormativa.ToString();
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
        public static NormativaModelo Find(int id)
        {
            try
            {
                var entidadModelo = new NormativaModelo();
                if (!(id == 0))
                {
                    using (_context = new SGPTEntidades())
                    {
                        //normativa entidad = _context.normativas.Find(id);
                        normativa entidad = _context.normativas
                           .Where(x => x.idnormativa == id)
                           .SingleOrDefault();
                        if (entidad == null)
                        {
                            return entidadModelo = null;
                        }
                        else
                        {
                            entidadModelo.idln = entidad.idln;
                            entidadModelo.id = entidad.idnormativa;
                            entidadModelo.idusuario = entidad.idusuario;
                            entidadModelo.nombrenormativa = entidad.nombrenormativa;
                            entidadModelo.descripcion = entidad.nombreabreviadonormativa;
                            entidadModelo.fechaemisionnormativa = entidad.fechaemisionnormativa;
                            entidadModelo.fechavigencianormativa = entidad.fechavigencianormativa;
                            entidadModelo.fechacreadonormativa = entidad.fechacreadonormativa;
                            entidadModelo.binarioNormativa = entidad.binarionormativa;
                            entidadModelo.ordennormativa = entidad.ordennormativa;
                            entidadModelo.sistema = entidad.sistemanormativa;
                            entidadModelo.estado = entidad.estadonormativa;
                            entidadModelo.nombrearchivonormativa = entidad.nombrearchivonormativa;
                            return entidadModelo;
                        }
                    }
                }
                else
                {
                    return entidadModelo = null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No fue posible recuperar el registro de Normativa por " + e.Message);
                return new NormativaModelo();
            }
        }

        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.normativas WHERE idnormativa = {0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    //Se elimina todo el contenido
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static NormativaModelo Find(string id)
        {
            var entidadModelo = new NormativaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    normativa entidad = _context.normativas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idln = entidad.idln;    
                        entidadModelo.id = entidad.idnormativa;
                        entidadModelo.idusuario = entidad.idusuario;
                        entidadModelo.nombrenormativa = entidad.nombrenormativa;
                        entidadModelo.descripcion = entidad.nombreabreviadonormativa;
                        entidadModelo.fechaemisionnormativa = entidad.fechaemisionnormativa;
                        entidadModelo.fechavigencianormativa = entidad.fechavigencianormativa;
                        entidadModelo.fechacreadonormativa = entidad.fechacreadonormativa;
                        entidadModelo.binarioNormativa = entidad.binarionormativa;
                        entidadModelo.ordennormativa = entidad.ordennormativa;
                        entidadModelo.sistema = entidad.sistemanormativa;
                        entidadModelo.estado = entidad.estadonormativa;
                        entidadModelo.nombrearchivonormativa = entidad.nombrearchivonormativa;
                        return entidadModelo;
                    }
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
                    var modelo = new NormativaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    normativa entidad = _context.normativas.Find(id);
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
                    var modelo = new NormativaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.normativas
                            .Where(b => b.estadonormativa == "B")
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
                    normativa entidad = _context.normativas.Find(id);
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
        public static List<NormativaModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.normativas.Select(entidad =>
                new NormativaModelo
                {
                    id = entidad.idnormativa,
                    idln = entidad.idln,
                    idusuario = entidad.idusuario,
                    nombrenormativa = entidad.nombrenormativa,
                    descripcion = entidad.nombreabreviadonormativa,
                    fechaemisionnormativa = entidad.fechaemisionnormativa,
                    fechavigencianormativa = entidad.fechavigencianormativa,
                    fechacreadonormativa = entidad.fechacreadonormativa,
                    binarioNormativa = entidad.binarionormativa,
                    ordennormativa = entidad.ordennormativa,
                    sistema = entidad.sistemanormativa,
                    estado = entidad.estadonormativa,
                    idNormalegalNombre = entidad.legalnorma.descripcionln,
                    idUsuarioNombre = entidad.usuario.inicialesusuario,
                    nombrearchivonormativa=entidad.nombrearchivonormativa,
                    usuarioModelo = new UsuarioModelo
                    {
                        idUsuario = entidad.usuario.idusuario,
                        idDuiPersona = entidad.usuario.idduipersona,
                        idPista = entidad.usuario.idpista,
                        usuIdUsuario = entidad.usuario.usuidusuario,
                        idRol = entidad.usuario.idrol,
                        fechaRegistroUsuarioString = entidad.usuario.fecharegistrousuario,
                        fechaDeBajaString = entidad.usuario.fechadebaja,
                        fechaContratacionString = entidad.usuario.fechacontratacion,
                        nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                        inicialesusuario = entidad.usuario.inicialesusuario,
                        respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                        numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                        fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                        estadoUsuario = entidad.usuario.estadousuario,
                        contraseniaUsuario = entidad.usuario.contraseniausuario,
                    },
                    legalNormaModelo = new LegalNormaModelo
                    {
                        id = entidad.legalnorma.idln,
                        descripcion = entidad.legalnorma.descripcionln,
                        sistema = entidad.legalnorma.sistemaln,
                        estado = entidad.legalnorma.estadoln
                    }
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
                    var entidad = _context.normativas
                            .Where(b => b.estadonormativa == "B")
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

        public static void UpdateModelo(NormativaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    normativa entidad = _context.normativas.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idln = modelo.idln;
                        entidad.idnormativa= modelo.id;
                        entidad.idusuario = modelo.idusuario;
                        entidad.nombrenormativa = modelo.nombrenormativa;
                        entidad.nombreabreviadonormativa = modelo.descripcion;
                        entidad.fechaemisionnormativa = modelo.fechaemisionnormativa.ToString();
                        entidad.fechavigencianormativa = modelo.fechavigencianormativa.ToString();
                        entidad.fechacreadonormativa = modelo.fechacreadonormativa.ToString();
                        entidad.binarionormativa = modelo.binarioNormativa;
                        entidad.ordennormativa = modelo.ordennormativa;
                        entidad.sistemanormativa = modelo.sistema;
                        entidad.estadonormativa = modelo.estado;
                        entidad.nombrearchivonormativa = modelo.nombrearchivonormativa;

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

        public static bool UpdateModelo(NormativaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        normativa entidad = _context.normativas.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.idln = modelo.idln;
                            entidad.idnormativa = modelo.id;
                            entidad.idusuario = modelo.idusuario;
                            entidad.nombrenormativa = modelo.nombrenormativa;
                            entidad.nombreabreviadonormativa = modelo.descripcion;
                            entidad.fechaemisionnormativa = modelo.fechaemisionnormativa;
                            entidad.fechavigencianormativa = modelo.fechavigencianormativa;
                            entidad.fechacreadonormativa = modelo.fechacreadonormativa;
                            entidad.binarionormativa = modelo.binarioNormativa;
                            entidad.ordennormativa = modelo.ordennormativa;
                            //entidad.sistemanormativa = modelo.sistema;
                            //entidad.estadonormativa = modelo.estado;
                            entidad.nombrearchivonormativa = modelo.nombrearchivonormativa;
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
                            string commandString = String.Format("UPDATE sgpt.normativas SET estadonormativa = 'B' WHERE idnormativa={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //normativa entidad = _context.normativas.Find(id);
                            //entidad.estadonormativa = "B";
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
                            string commandString = String.Format("UPDATE sgpt.normativas SET estadonormativa = 'B' WHERE idnormativa={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //normativa entidad = _context.normativas.Find(id);
                            //entidad.estadonormativa = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.normativas WHERE idnormativa = {0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    //Se elimina todo el contenido
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
                        string commandString = String.Format("DELETE FROM sgpt.normativas WHERE idnormativa = {0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        //Se elimina todo el contenido
                        _context.SaveChanges();
                        //normativa entidad = _context.normativas.Find(id);
                        //_context.normativas.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.normativas WHERE idnormativa = {0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            //Se elimina todo el contenido
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

        public static List<NormativaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.normativas.Select(entidad =>
                    new NormativaModelo
                    {
                        id = entidad.idnormativa,
                        idln=entidad.idln,
                        idusuario = entidad.idusuario,
                        nombrenormativa = entidad.nombrenormativa,
                        descripcion = entidad.nombreabreviadonormativa,
                        fechaemisionnormativa = entidad.fechaemisionnormativa,
                        fechavigencianormativa = entidad.fechavigencianormativa,
                        fechacreadonormativa = entidad.fechacreadonormativa,
                        binarioNormativa = entidad.binarionormativa,
                        ordennormativa = entidad.ordennormativa,
                        sistema = entidad.sistemanormativa,
                        estado = entidad.estadonormativa,
                        idNormalegalNombre=entidad.legalnorma.descripcionln,
                        idUsuarioNombre=entidad.usuario.inicialesusuario,
                        nombrearchivonormativa=entidad.nombrearchivonormativa,
                        usuarioModelo = new UsuarioModelo
                        {
                            idUsuario = entidad.usuario.idusuario,
                            idDuiPersona = entidad.usuario.idduipersona,
                            idPista = entidad.usuario.idpista,
                            usuIdUsuario = entidad.usuario.usuidusuario,
                            idRol = entidad.usuario.idrol,
                            fechaRegistroUsuarioString = entidad.usuario.fecharegistrousuario,
                            fechaDeBajaString = entidad.usuario.fechadebaja,
                            fechaContratacionString = entidad.usuario.fechacontratacion,
                            nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                            inicialesusuario = entidad.usuario.inicialesusuario,
                            respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                            numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                            fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                            estadoUsuario = entidad.usuario.estadousuario,
                            contraseniaUsuario = entidad.usuario.contraseniausuario,
                        },
                        legalNormaModelo = new LegalNormaModelo
                        {
                            id = entidad.legalnorma.idln,
                            descripcion = entidad.legalnorma.descripcionln,
                            sistema = entidad.legalnorma.sistemaln,
                            estado = entidad.legalnorma.estadoln
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista {0}", e.Source);
                }
                return null;
            }
        }


        public static List<NormativaModelo> GetAll(int? idln)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.normativas.Select(entidad =>
                    new NormativaModelo
                    { 
                        id = entidad.idnormativa,
                        idln = entidad.idln,
                        idusuario = entidad.idusuario,
                        nombrenormativa = entidad.nombrenormativa,
                        descripcion = entidad.nombreabreviadonormativa,
                        fechaemisionnormativa = entidad.fechaemisionnormativa,
                        fechavigencianormativa = entidad.fechavigencianormativa,
                        fechacreadonormativa = entidad.fechacreadonormativa,
                        binarioNormativa = entidad.binarionormativa,
                        ordennormativa = entidad.ordennormativa,
                        sistema = entidad.sistemanormativa,
                        estado = entidad.estadonormativa,
                        idNormalegalNombre = entidad.legalnorma.descripcionln,
                        idUsuarioNombre = entidad.usuario.inicialesusuario,
                        nombrearchivonormativa=entidad.nombrearchivonormativa,
                        usuarioModelo = new UsuarioModelo
                        {
                            idUsuario = entidad.usuario.idusuario,
                            idDuiPersona = entidad.usuario.idduipersona,
                            idPista = entidad.usuario.idpista,
                            usuIdUsuario = entidad.usuario.usuidusuario,
                            idRol = entidad.usuario.idrol,
                            fechaRegistroUsuarioString = entidad.usuario.fecharegistrousuario,
                            fechaDeBajaString = entidad.usuario.fechadebaja,
                            fechaContratacionString = entidad.usuario.fechacontratacion,
                            nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                            inicialesusuario = entidad.usuario.inicialesusuario,
                            respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                            numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                            fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                            estadoUsuario = entidad.usuario.estadousuario,
                            contraseniaUsuario = entidad.usuario.contraseniausuario,
                        },
                        legalNormaModelo = new LegalNormaModelo
                        {
                            id = entidad.legalnorma.idln,
                            descripcion = entidad.legalnorma.descripcionln,
                            sistema = entidad.legalnorma.sistemaln,
                            estado = entidad.legalnorma.estadoln
                        }
                    }).Where(x => x.estado == "A").Where(x => x.idln == idln).OrderBy(o=>o.descripcion).ToList();
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista "+e.Message+" "+ e.Source );
                throw;
                //return null;
            }
        }

        public static List<NormativaModelo> GetAllEncabezados(int? idln)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.normativas.Select(entidad =>
                        new NormativaModelo
                        {
                            id = entidad.idnormativa,
                            idln = entidad.idln,
                            descripcion = entidad.nombreabreviadonormativa,
                            idusuario = entidad.idusuario,
                            nombrenormativa = entidad.nombrenormativa,
                            ordennormativa = entidad.ordennormativa,
                            sistema = entidad.sistemanormativa,
                            estado = entidad.estadonormativa,
                            nombrearchivonormativa=entidad.nombrearchivonormativa,
                            usuarioModelo = new UsuarioModelo
                            {
                                idUsuario = entidad.usuario.idusuario,
                                idDuiPersona = entidad.usuario.idduipersona,
                                idPista = entidad.usuario.idpista,
                                usuIdUsuario = entidad.usuario.usuidusuario,
                                idRol = entidad.usuario.idrol,
                                fechaRegistroUsuarioString = entidad.usuario.fecharegistrousuario,
                                fechaDeBajaString = entidad.usuario.fechadebaja,
                                fechaContratacionString = entidad.usuario.fechacontratacion,
                                nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                                inicialesusuario = entidad.usuario.inicialesusuario,
                                respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                                numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                                fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                                estadoUsuario = entidad.usuario.estadousuario,
                                contraseniaUsuario = entidad.usuario.contraseniausuario,
                            },
                            legalNormaModelo = new LegalNormaModelo
                            {
                                id = entidad.legalnorma.idln,
                                descripcion = entidad.legalnorma.descripcionln,
                                sistema = entidad.legalnorma.sistemaln,
                                estado = entidad.legalnorma.estadoln
                            }
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.ordennormativa).Where(x => x.estado == "A").Where(x => x.idln == idln).ToList();
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



        public static List<NormativaModelo> GetAllEncabezados()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.normativas.Select(entidad =>
                        new NormativaModelo
                        {
                            id = entidad.idnormativa,
                            idln = entidad.idln,
                            descripcion = entidad.nombreabreviadonormativa,
                            idusuario = entidad.idusuario,
                            nombrenormativa = entidad.nombrenormativa,
                            ordennormativa = entidad.ordennormativa,
                            sistema = entidad.sistemanormativa,
                            estado = entidad.estadonormativa,
                            nombrearchivonormativa = entidad.nombrearchivonormativa,
                            usuarioModelo = new UsuarioModelo
                            {
                                idUsuario = entidad.usuario.idusuario,
                                idDuiPersona = entidad.usuario.idduipersona,
                                idPista = entidad.usuario.idpista,
                                usuIdUsuario = entidad.usuario.usuidusuario,
                                idRol = entidad.usuario.idrol,
                                fechaRegistroUsuarioString = entidad.usuario.fecharegistrousuario,
                                fechaDeBajaString = entidad.usuario.fechadebaja,
                                fechaContratacionString = entidad.usuario.fechacontratacion,
                                nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                                inicialesusuario = entidad.usuario.inicialesusuario,
                                respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                                numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                                fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                                estadoUsuario = entidad.usuario.estadousuario,
                                contraseniaUsuario = entidad.usuario.contraseniausuario,
                            },
                            legalNormaModelo = new LegalNormaModelo
                            {
                                id = entidad.legalnorma.idln,
                                descripcion = entidad.legalnorma.descripcionln,
                                sistema = entidad.legalnorma.sistemaln,
                                estado = entidad.legalnorma.estadoln
                            }
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.ordennormativa).Where(x => x.estado == "A").ToList();
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
                    elementos = _context.normativas.Where(x => x.idln == id && x.estadonormativa == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
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
                    elementos = _context.normativas.Where(x => x.estadonormativa == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
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
                    var entidad = (from p in _context.normativas
                                   where p.nombreabreviadonormativa.ToLower().Equals(busqueda)
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

        public static int contarRepetidoTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.normativas
                                   where p.nombreabreviadonormativa.ToLower().Equals(busqueda)
                                   select p).ToList();
                    if (entidad == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return entidad.Count;
                    }
                }
            }
            else
            {
                return 0;
            }
        }


        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static NormativaModelo Clear(NormativaModelo modelo)
        {
            return new NormativaModelo ();
        }

        public NormativaModelo()
        {
            
            idln = 0;
            id = 0;
            idusuario = 0;
            nombrenormativa = string.Empty;
            descripcion = string.Empty;
            fechaemisionnormativa = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            fechavigencianormativa = MetodosModelo.homologacionFecha(DateTime.Now.AddDays(1).ToString("d", CultureInfo.CurrentCulture));
            fechacreadonormativa = MetodosModelo.homologacionFecha(DateTime.Now.ToString("d", CultureInfo.CurrentCulture));
            //binarioNormativa
            ordennormativa = 1;
            sistema = false;
            estado = "A";
            nombrearchivonormativa = string.Empty;
            
        }

        #endregion
    }

}



