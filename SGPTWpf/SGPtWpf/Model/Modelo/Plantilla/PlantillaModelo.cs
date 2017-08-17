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
using System.Diagnostics;
using System.Linq;
using System.Windows;


namespace SGPTWpf.Model.Modelo.Plantilla
{

    public class PlantillaModelo: UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idplantilla //correlativo
        {
            get { return GetValue(() => idplantilla); }
            set { SetValue(() => idplantilla, value); }
        }

        public Nullable<int> idusuario //Tipo de carpeta
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }

        public Nullable<int> iddd//Detalle de documentos
        {
            get { return GetValue(() => iddd); }
            set { SetValue(() => iddd, value); }
        }

        [DisplayName("Nombre plantilla")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(200, ErrorMessage = "Excede de 200 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string nombreplantilla
        {
            get { return GetValue(() => nombreplantilla); }
            set { SetValue(() => nombreplantilla, value); }
        }

        [DisplayName("Comentario")]
        [MaxLength(100, ErrorMessage = "Excede de 100 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "El comentario contiene símbolos inválidos")]
        public string comentarioplantilla
        {
            get { return GetValue(() => comentarioplantilla); }
            set { SetValue(() => comentarioplantilla, value); }
        }

        public decimal versionplantilla
        {
            get { return GetValue(() => versionplantilla); }
            set { SetValue(() => versionplantilla, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechacreadoplantilla
        {
            get { return GetValue(() => fechacreadoplantilla); }
            set { SetValue(() => fechacreadoplantilla, value); }
        }



        public string tipoarchivoplantilla  //extension del archivo a utilizar
        {
            get { return GetValue(() => tipoarchivoplantilla ); }
            set { SetValue(() => tipoarchivoplantilla , value); }
        }

        public byte[] ficherobinarioplantilla
        {
            get { return GetValue(() => ficherobinarioplantilla); }
            set { SetValue(() => ficherobinarioplantilla, value); }
        }

        public bool sistemaplantilla
        {
            get { return GetValue(() => sistemaplantilla); }
            set { SetValue(() => sistemaplantilla, value); }
        }


        public string estadoplantilla
        {
            get { return GetValue(() => estadoplantilla); }
            set { SetValue(() => estadoplantilla, value); }
        }
        public string nombrearchivoplantilla
        {
            get { return GetValue(() => nombrearchivoplantilla); }
            set { SetValue(() => nombrearchivoplantilla, value); }
        }
        public string nombreDetalleDocumento
        {
            get { return GetValue(() => nombreDetalleDocumento); }
            set { SetValue(() => nombreDetalleDocumento, value); }
        }

        public string inicialesusuario
        {
            get { return GetValue(() => inicialesusuario); }
            set { SetValue(() => inicialesusuario, value); }
        }
        public string nombreDocumento
        {
            get { return GetValue(() => nombreDocumento); }
            set { SetValue(() => nombreDocumento, value); }
        }
        public virtual DetalleDocumentoModelo detalleDocumentosModelo
        {
            get { return GetValue(() => detalleDocumentosModelo); }
            set { SetValue(() => detalleDocumentosModelo, value); }
        }

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion

        public virtual TipoArchivoModelo tipoArchivoModelo
        {
            get { return GetValue(() => tipoArchivoModelo); }
            set { SetValue(() => tipoArchivoModelo, value); }
        }

        #endregion

        #region Control de archivos lanzados

        public Guid guId
        {
            get { return GetValue(() => guId); }
            set { SetValue(() => guId, value); }
        }
        #endregion


        #region Public Model Methods


        public static bool Insert(PlantillaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.plantillas', 'idplantilla'), (SELECT MAX(idplantilla) FROM sgpt.plantillas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new plantilla
                        {
                            //idplantilla
                            idusuario=modelo.usuarioModelo.idUsuario,
                            iddd=modelo.detalleDocumentosModelo.iddd,
                            nombreplantilla= modelo.nombreplantilla,
                            comentarioplantilla= modelo.comentarioplantilla,
                            versionplantilla =(decimal) 1.0,
                            fechacreadoplantilla = modelo.fechacreadoplantilla,

                            tipoarchivoplantilla = modelo.tipoArchivoModelo.extension,

                            ficherobinarioplantilla =modelo.ficherobinarioplantilla,
                            sistemaplantilla=false,
                            estadoplantilla="A",
                            nombrearchivoplantilla=modelo.nombrearchivoplantilla
                        };
                        _context.plantillas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idplantilla = tablaDestino.idplantilla;
                        modelo.sistemaplantilla = tablaDestino.sistemaplantilla;
                        modelo.estadoplantilla = tablaDestino.estadoplantilla;
                        //Se reordena la lista
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
                    //foreach (var eve in e.EntityValidationErrors)
                    //{
                    //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    //    foreach (var ve in eve.ValidationErrors)
                    //    {
                    //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    //            ve.PropertyName, ve.ErrorMessage);
                    //    }
                    //}
                    MessageBox.Show("Error "+e.Message);
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
        public static PlantillaModelo Find(int id)
        {
            var entidad = new PlantillaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    plantilla modelo= _context.plantillas.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                             entidad.idplantilla = modelo.idplantilla;
                             entidad.idusuario = modelo.idusuario;
                             entidad.iddd = modelo.iddd;
                             entidad.nombreplantilla = modelo.nombreplantilla;
                             entidad.comentarioplantilla = modelo.comentarioplantilla;
                             entidad.versionplantilla = modelo.versionplantilla;
                             entidad.fechacreadoplantilla = modelo.fechacreadoplantilla;
                             entidad.tipoarchivoplantilla = modelo.tipoarchivoplantilla;
                             entidad.ficherobinarioplantilla = modelo.ficherobinarioplantilla;
                             entidad.sistemaplantilla = modelo.sistemaplantilla;
                             entidad.estadoplantilla = modelo.estadoplantilla;
                             entidad.nombrearchivoplantilla = modelo.nombrearchivoplantilla;
                             entidad.nombreDocumento = modelo.detalledocumento.documento.descripciondocumento;
                             entidad.detalleDocumentosModelo = new DetalleDocumentoModelo
                             {
                                 iddd = modelo.detalledocumento.iddd,
                                 descripciondd = modelo.detalledocumento.descripciondd,
                                 sistemadd = modelo.detalledocumento.sistemadd,
                                 iddocumento = modelo.detalledocumento.documento.iddocumento,
                                 nombreDocumento = modelo.detalledocumento.documento.descripciondocumento,
                                 estadodd = modelo.detalledocumento.estadodd,
                                 documentoModelo = new DocumentoModelo
                                 {
                                     id = modelo.detalledocumento.documento.iddocumento,
                                     descripcion = modelo.detalledocumento.documento.descripciondocumento,
                                     sistema = modelo.detalledocumento.documento.sistemadocumento,
                                     estado = modelo.detalledocumento.documento.estadodocumento
                                 }
                                 //Lista filtrada de elementos que fueron eliminados
                             };
                            entidad.usuarioModelo = new UsuarioModelo
                            {
                                idUsuario = modelo.usuario.idusuario,
                                idDuiPersona = modelo.usuario.idduipersona,
                                idPista = modelo.usuario.idpista,
                                usuIdUsuario = modelo.usuario.usuidusuario,
                                idRol = modelo.usuario.idrol,
                                fechaRegistroUsuarioString = modelo.usuario.fecharegistrousuario,
                                fechaDeBajaString = modelo.usuario.fechadebaja,
                                fechaContratacionString = modelo.usuario.fechacontratacion,
                                inicialesusuario = modelo.usuario.inicialesusuario,
                                //inicialesusuario = modelo.usuario.inicialesusuario,
                                respuestaPistaUsuario = modelo.usuario.respuestapistausuario,
                                numeroCvpaUsuario = modelo.usuario.numerocvpausuario,
                                fechaCvpaUsuarioString = modelo.usuario.fechacvpausuario,
                                estadoUsuario = modelo.usuario.estadousuario,
                                contraseniaUsuario = modelo.usuario.contraseniausuario,
                            };
                    }
                    var lista = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                    entidad.tipoArchivoModelo= lista.Single(i => i.extension == entidad.tipoarchivoplantilla);
                    return entidad;
                }
            }
            else
            {
                return entidad = null;
            }
        }

        //Devuelve el maximo del orden de un registro
        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.plantillas WHERE idplantilla={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static PlantillaModelo Find(string id)
        { 
            var entidad = new PlantillaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    plantilla modelo = _context.plantillas.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idplantilla = modelo.idplantilla;
                        entidad.idusuario = modelo.idusuario;
                        entidad.iddd = modelo.iddd;
                        entidad.nombreplantilla = modelo.nombreplantilla;
                        entidad.comentarioplantilla = modelo.comentarioplantilla;
                        entidad.versionplantilla = modelo.versionplantilla;
                        entidad.fechacreadoplantilla = modelo.fechacreadoplantilla;
                        entidad.tipoarchivoplantilla = modelo.tipoarchivoplantilla;
                        entidad.ficherobinarioplantilla = modelo.ficherobinarioplantilla;
                        entidad.sistemaplantilla = modelo.sistemaplantilla;
                        entidad.estadoplantilla = modelo.estadoplantilla;
                        entidad.nombrearchivoplantilla = modelo.nombrearchivoplantilla;
                        entidad.nombreDocumento = modelo.detalledocumento.documento.descripciondocumento;
                        entidad.detalleDocumentosModelo = new DetalleDocumentoModelo
                        {
                            iddd = modelo.detalledocumento.iddd,
                            descripciondd = modelo.detalledocumento.descripciondd,
                            sistemadd = modelo.detalledocumento.sistemadd,
                            iddocumento = modelo.detalledocumento.documento.iddocumento,
                            nombreDocumento = modelo.detalledocumento.documento.descripciondocumento,
                            estadodd = modelo.detalledocumento.estadodd,
                            documentoModelo = new DocumentoModelo
                            {
                                id = modelo.detalledocumento.documento.iddocumento,
                                descripcion = modelo.detalledocumento.documento.descripciondocumento,
                                sistema = modelo.detalledocumento.documento.sistemadocumento,
                                estado = modelo.detalledocumento.documento.estadodocumento
                            }
                            //Lista filtrada de elementos que fueron eliminados
                        };
                        entidad.usuarioModelo = new UsuarioModelo
                        {
                            idUsuario = modelo.usuario.idusuario,
                            idDuiPersona = modelo.usuario.idduipersona,
                            idPista = modelo.usuario.idpista,
                            usuIdUsuario = modelo.usuario.usuidusuario,
                            idRol = modelo.usuario.idrol,
                            fechaRegistroUsuarioString = modelo.usuario.fecharegistrousuario,
                            fechaDeBajaString = modelo.usuario.fechadebaja,
                            fechaContratacionString = modelo.usuario.fechacontratacion,
                            inicialesusuario = modelo.usuario.inicialesusuario,
                            //inicialesusuario = modelo.usuario.inicialesusuario,
                            respuestaPistaUsuario = modelo.usuario.respuestapistausuario,
                            numeroCvpaUsuario = modelo.usuario.numerocvpausuario,
                            fechaCvpaUsuarioString = modelo.usuario.fechacvpausuario,
                            estadoUsuario = modelo.usuario.estadousuario,
                            contraseniaUsuario = modelo.usuario.contraseniausuario,
                        };
                    }
                    var lista = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                    entidad.tipoArchivoModelo = lista.Single(i => i.extension == entidad.tipoarchivoplantilla);
                    return entidad;
                }
            }
            else
            {
                return entidad = null;
            }
        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new PlantillaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    plantilla entidad = _context.plantillas.Find(id);
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

        public static bool FindPK(int? id)
        {
            if (!(string.IsNullOrEmpty(id.ToString())))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new PlantillaModelo();
                    plantilla entidad = _context.plantillas.Find(id);
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
                    var modelo = new PlantillaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.plantillas
                            .Where(b => b.estadoplantilla == "B")
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
                    plantilla entidad = _context.plantillas.Find(id);
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
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    return nombre = _context.plantillas.Find(id).nombreplantilla;
                }
            }
            else
            {
                return nombre;
            }
        }

        //Para realizar busquedas de texto
        public static List<PlantillaModelo> TransformLista(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                var resultado = _context.plantillas.Select(entidad =>
                new PlantillaModelo
                {
                    idplantilla = entidad.idplantilla,
                    idusuario = entidad.idusuario,
                    iddd = entidad.iddd,
                    nombreplantilla = entidad.nombreplantilla,
                    comentarioplantilla = entidad.comentarioplantilla,
                    versionplantilla = entidad.versionplantilla,
                    fechacreadoplantilla = entidad.fechacreadoplantilla,
                    tipoarchivoplantilla = entidad.tipoarchivoplantilla,
                    ficherobinarioplantilla = entidad.ficherobinarioplantilla,
                    sistemaplantilla = entidad.sistemaplantilla,
                    estadoplantilla = entidad.estadoplantilla,
                    nombrearchivoplantilla = entidad.nombrearchivoplantilla,
                    nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                    detalleDocumentosModelo = new DetalleDocumentoModelo
                    {
                        iddd = entidad.detalledocumento.iddd,
                        descripciondd = entidad.detalledocumento.descripciondd,
                        sistemadd = entidad.detalledocumento.sistemadd,
                        iddocumento = entidad.detalledocumento.documento.iddocumento,
                        nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                        estadodd = entidad.detalledocumento.estadodd,
                        documentoModelo = new DocumentoModelo
                        {
                            id = entidad.detalledocumento.documento.iddocumento,
                            descripcion = entidad.detalledocumento.documento.descripciondocumento,
                            sistema = entidad.detalledocumento.documento.sistemadocumento,
                            estado = entidad.detalledocumento.documento.estadodocumento
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    },
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
                        inicialesusuario = entidad.usuario.inicialesusuario,
                        //inicialesusuario = entidad.usuario.inicialesusuario,
                        respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                        numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                        fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                        estadoUsuario = entidad.usuario.estadousuario,
                        contraseniaUsuario = entidad.usuario.contraseniausuario,
                        //Lista filtrada de elementos que fueron eliminados
                    }
                    }).OrderBy(o => o.idplantilla).Where(x => x.nombreplantilla.ToUpper() == Texto).ToList();
                var lista = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                foreach (PlantillaModelo item in resultado)
                {
                    item.tipoArchivoModelo = lista.Single(i => i.extension == item.tipoarchivoplantilla);
                }

                return resultado;
                //La ordena por el idPrograma notar la notacion
            }
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.plantillas
                            .Where(b => b.estadoplantilla == "B")
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

        public static void UpdateModelo(PlantillaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    plantilla entidad = _context.plantillas.Find(modelo.idplantilla);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        //entidad.idplantilla = modelo.idplantilla;
                        entidad.idusuario = (int)modelo.idusuario;
                        entidad.iddd = modelo.iddd;
                        entidad.nombreplantilla = modelo.nombreplantilla;
                        entidad.comentarioplantilla = modelo.comentarioplantilla;
                        entidad.versionplantilla = modelo.versionplantilla+(decimal)0.01;
                        entidad.fechacreadoplantilla = modelo.fechacreadoplantilla;
                        entidad.tipoarchivoplantilla = modelo.tipoArchivoModelo.extension;
                        entidad.ficherobinarioplantilla = modelo.ficherobinarioplantilla;
                        //entidad.sistemaplantilla = modelo.sistemaplantilla;
                        //entidad.estadoplantilla = modelo.estadoplantilla;
                        entidad.nombrearchivoplantilla = modelo.nombrearchivoplantilla;
                        _context.Entry(entidad).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                }
            }
            else
            {
                //No regresa nada

            }
        }

        public static bool UpdateModelo(PlantillaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        plantilla entidad = _context.plantillas.Find(modelo.idplantilla);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!(entidad.idusuario == modelo.usuarioModelo.idUsuario))
                            {
                                entidad.idusuario = modelo.usuarioModelo.idUsuario;
                                cambio = true;
                            }
                            if (!(entidad.iddd== modelo.detalleDocumentosModelo.iddd))
                            {
                                entidad.idusuario = modelo.detalleDocumentosModelo.iddd;
                                cambio = true;
                            }
                            if (!(entidad.nombreplantilla.ToUpper() == modelo.nombreplantilla.ToUpper()))
                            {
                                entidad.nombreplantilla = modelo.nombreplantilla;
                                cambio = true;
                            }
                            /*if (!(entidad.versionplantilla == modelo.versionplantilla))
                            {
                                entidad.versionplantilla = modelo.versionplantilla;
                                cambio = true;
                            }*/
                            if (!(entidad.fechacreadoplantilla == modelo.fechacreadoplantilla))
                            {
                                entidad.fechacreadoplantilla = modelo.fechacreadoplantilla;
                                cambio = true;
                            }
                            if (!(entidad.comentarioplantilla == modelo.comentarioplantilla))
                            {
                                entidad.comentarioplantilla = modelo.comentarioplantilla;
                                cambio = true;
                            }
                            if (!(entidad.ficherobinarioplantilla == modelo.ficherobinarioplantilla))
                            {
                                entidad.comentarioplantilla = modelo.comentarioplantilla;
                                cambio = true;
                            }
                            if (!(entidad.tipoarchivoplantilla == modelo.tipoArchivoModelo.extension))
                            {
                                entidad.tipoarchivoplantilla = modelo.tipoArchivoModelo.extension;
                                cambio = true;
                            }
                            if (!(entidad.nombrearchivoplantilla == modelo.nombrearchivoplantilla))
                            {
                                entidad.nombrearchivoplantilla = modelo.nombrearchivoplantilla;
                                cambio = true;
                            }
                            if (cambio)
                            {
                                //entidad.idplantilla = modelo.idplantilla;
                                entidad.idusuario = (int)modelo.idusuario;
                                entidad.iddd = modelo.iddd;
                                entidad.nombreplantilla = modelo.nombreplantilla;
                                entidad.comentarioplantilla = modelo.comentarioplantilla;
                                entidad.versionplantilla = Decimal.Add(modelo.versionplantilla,(decimal)0.01);
                                entidad.fechacreadoplantilla = modelo.fechacreadoplantilla;
                                entidad.tipoarchivoplantilla = modelo.tipoArchivoModelo.extension;
                                entidad.ficherobinarioplantilla = modelo.ficherobinarioplantilla;
                                //entidad.sistemaplantilla = modelo.sistemaplantilla;
                                //entidad.estadoplantilla = modelo.estadoplantilla;
                                entidad.nombrearchivoplantilla = modelo.nombrearchivoplantilla;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            return true;
                        }
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                  "Class: {0}, Property: {1}, Error: {2}",
                                  validationErrors.Entry.Entity.GetType().FullName,
                                  validationError.PropertyName,
                                  validationError.ErrorMessage);
                        }
                    }
                    return false;
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
                            string commandString = String.Format("UPDATE sgpt.plantillas SET estadoplantilla = 'B' WHERE idplantilla={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //plantilla entidad = _context.plantillas.Find(id);
                            //entidad.estadoplantilla = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception )
                    {
                        //Captura de fallo en la insercion
                        //if (e.Source != null)
                        //    MessageBox.Show("Exception en borrar registro : " + e.Message);
                        //throw;
                        result = true;
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
                            string commandString = String.Format("UPDATE sgpt.plantillas SET estadoplantilla = 'B' WHERE idplantilla={0};", id);
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
        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.plantillas WHERE idplantilla={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                        return true;
                    }
                }
                catch (Exception )
                {
                    //Captura de fallo en la insercion
                    //if (e.Source != null)
                    //    MessageBox.Show("Exception en borrar registro de Plantilla: " + e.Message);
                    //throw;
                    return true;
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
                            string commandString = String.Format("DELETE FROM sgpt.plantillas WHERE idplantilla={0};", id);
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

        public static List<PlantillaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var resultado = _context.plantillas.Select(entidad =>
                     new PlantillaModelo
                     {
                         idplantilla = entidad.idplantilla,
                         idusuario = entidad.idusuario,
                         iddd = entidad.iddd,
                         nombreplantilla = entidad.nombreplantilla,
                         comentarioplantilla = entidad.comentarioplantilla,
                         versionplantilla = entidad.versionplantilla,
                         fechacreadoplantilla = entidad.fechacreadoplantilla,
                         tipoarchivoplantilla = entidad.tipoarchivoplantilla,
                         //ficherobinarioplantilla = entidad.ficherobinarioplantilla, No se carga para acelerar la vista
                         sistemaplantilla = entidad.sistemaplantilla,
                         estadoplantilla = entidad.estadoplantilla,
                         nombrearchivoplantilla = entidad.nombrearchivoplantilla,
                         nombreDetalleDocumento=entidad.detalledocumento.descripciondd,
                         nombreDocumento=entidad.detalledocumento.documento.descripciondocumento,
                         detalleDocumentosModelo = new DetalleDocumentoModelo
                         {
                             iddd = entidad.detalledocumento.iddd,
                             descripciondd = entidad.detalledocumento.descripciondd,
                             sistemadd = entidad.detalledocumento.sistemadd,
                             iddocumento = entidad.detalledocumento.documento.iddocumento,
                             nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                             estadodd = entidad.detalledocumento.estadodd,
                             documentoModelo = new DocumentoModelo
                             {
                                 id = entidad.detalledocumento.documento.iddocumento,
                                 descripcion = entidad.detalledocumento.documento.descripciondocumento,
                                 sistema = entidad.detalledocumento.documento.sistemadocumento,
                                 estado = entidad.detalledocumento.documento.estadodocumento
                             }
                             //Lista filtrada de elementos que fueron eliminados
                         },
                         inicialesusuario=entidad.usuario.inicialesusuario,
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
                             inicialesusuario = entidad.usuario.inicialesusuario,
                             respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                             numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                             fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                             estadoUsuario = entidad.usuario.estadousuario,
                             contraseniaUsuario = entidad.usuario.contraseniausuario,
                             //Lista filtrada de elementos que fueron eliminados
                         }
                     }).OrderBy(o => o.nombreplantilla).Where(x => x.estadoplantilla == "A").ToList();
                    var lista= new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                    foreach (PlantillaModelo item in resultado)
                    {
                        item.tipoArchivoModelo =lista.Single(i => i.extension == item.tipoarchivoplantilla);
                    }
                    return resultado.ToList();
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


        public static List<PlantillaModelo> GetAllFull()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var resultado = _context.plantillas.Select(entidad =>
                     new PlantillaModelo
                     {
                         idplantilla = entidad.idplantilla,
                         idusuario = entidad.idusuario,
                         iddd = entidad.iddd,
                         nombreplantilla = entidad.nombreplantilla,
                         comentarioplantilla = entidad.comentarioplantilla,
                         versionplantilla = entidad.versionplantilla,
                         fechacreadoplantilla = entidad.fechacreadoplantilla,
                         tipoarchivoplantilla = entidad.tipoarchivoplantilla,
                         ficherobinarioplantilla = entidad.ficherobinarioplantilla,
                         sistemaplantilla = entidad.sistemaplantilla,
                         estadoplantilla = entidad.estadoplantilla,
                         nombrearchivoplantilla = entidad.nombrearchivoplantilla,
                         nombreDetalleDocumento = entidad.detalledocumento.descripciondd,
                         nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                         detalleDocumentosModelo = new DetalleDocumentoModelo
                         {
                             iddd = entidad.detalledocumento.iddd,
                             descripciondd = entidad.detalledocumento.descripciondd,
                             sistemadd = entidad.detalledocumento.sistemadd,
                             iddocumento = entidad.detalledocumento.documento.iddocumento,
                             nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                             estadodd = entidad.detalledocumento.estadodd,
                             documentoModelo = new DocumentoModelo
                             {
                                 id = entidad.detalledocumento.documento.iddocumento,
                                 descripcion = entidad.detalledocumento.documento.descripciondocumento,
                                 sistema = entidad.detalledocumento.documento.sistemadocumento,
                                 estado = entidad.detalledocumento.documento.estadodocumento
                             }
                             //Lista filtrada de elementos que fueron eliminados
                         },
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
                             inicialesusuario = entidad.usuario.inicialesusuario,
                             respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                             numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                             fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                             estadoUsuario = entidad.usuario.estadousuario,
                             contraseniaUsuario = entidad.usuario.contraseniausuario,
                             //Lista filtrada de elementos que fueron eliminados
                         }
                     }).OrderBy(o => o.nombreplantilla).Where(x => x.estadoplantilla == "A").ToList();
                    var lista = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                    foreach (PlantillaModelo item in resultado)
                    {
                        item.tipoArchivoModelo = lista.Single(i => i.extension == item.tipoarchivoplantilla);
                    }
                    return resultado.ToList();
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
        //Filtra y elimina el registro detallado para efectos de seleccion

        public static PlantillaModelo GetAllItem(int idPlantilla)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var resultado = _context.plantillas.Select(entidad =>
                     new PlantillaModelo
                     {
                         idplantilla = entidad.idplantilla,
                         idusuario = entidad.idusuario,
                         iddd = entidad.iddd,
                         nombreplantilla = entidad.nombreplantilla,
                         comentarioplantilla = entidad.comentarioplantilla,
                         versionplantilla = entidad.versionplantilla,
                         fechacreadoplantilla = entidad.fechacreadoplantilla,
                         tipoarchivoplantilla = entidad.tipoarchivoplantilla,
                         ficherobinarioplantilla = entidad.ficherobinarioplantilla,
                         sistemaplantilla = entidad.sistemaplantilla,
                         estadoplantilla = entidad.estadoplantilla,
                         nombrearchivoplantilla = entidad.nombrearchivoplantilla,
                         nombreDetalleDocumento = entidad.detalledocumento.descripciondd,
                         nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                         detalleDocumentosModelo = new DetalleDocumentoModelo
                         {
                             iddd = entidad.detalledocumento.iddd,
                             descripciondd = entidad.detalledocumento.descripciondd,
                             sistemadd = entidad.detalledocumento.sistemadd,
                             iddocumento = entidad.detalledocumento.documento.iddocumento,
                             nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                             estadodd = entidad.detalledocumento.estadodd,
                             documentoModelo = new DocumentoModelo
                             {
                                 id = entidad.detalledocumento.documento.iddocumento,
                                 descripcion = entidad.detalledocumento.documento.descripciondocumento,
                                 sistema = entidad.detalledocumento.documento.sistemadocumento,
                                 estado = entidad.detalledocumento.documento.estadodocumento
                             }
                             //Lista filtrada de elementos que fueron eliminados
                         },
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
                             inicialesusuario = entidad.usuario.inicialesusuario,
                             respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                             numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                             fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                             estadoUsuario = entidad.usuario.estadousuario,
                             contraseniaUsuario = entidad.usuario.contraseniausuario,
                             //Lista filtrada de elementos que fueron eliminados
                         }
                     }).Where(x => x.estadoplantilla == "A" && x.idplantilla== idPlantilla).FirstOrDefault();
                    var lista = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                    resultado.tipoArchivoModelo = lista.Single(i => i.extension == resultado.tipoarchivoplantilla);
                    return resultado;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion obtencion de registro " + e.Message);
                }
                return null;
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
                    elementos = _context.plantillas.Where(x => x.idplantilla  == id && x.estadoplantilla == "A" ).Count();
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
                    elementos = _context.plantillas.Where(x => x.estadoplantilla == "A").Count();
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
                    var entidad = (from p in _context.plantillas
                                   where p.nombreplantilla.ToLower().Equals(busqueda)
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

        public static bool FindTexto(PlantillaModelo modelo)
        {
            string busqueda = modelo.nombreplantilla.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.plantillas
                                   where p.nombreplantilla.ToLower().Equals(busqueda)
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
        public static int FindTextoEliminados(PlantillaModelo modelo)
        {
            string busqueda = modelo.nombreplantilla.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.plantillas
                                   where p.estadoplantilla == "B" && p.nombreplantilla.ToLower().Equals(busqueda)
                                   select p).FirstOrDefault();
                    if (entidad == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return entidad.idplantilla;
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
        public PlantillaModelo()
        {
            
            idplantilla = 0;
            // idusuario = modelo.usuarioModelo.idUsuario,
            // iddd = modelo.detalleDocumentosModelo.iddd,
            // nombreplantilla = modelo.nombreplantilla,
            // comentarioplantilla = modelo.comentarioplantilla,
            // versionplantilla = modelo.versionplantilla,
            fechacreadoplantilla = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //tipoarchivoplantilla = modelo.tipoarchivoplantilla,
            // ficherobinarioplantilla = modelo.ficherobinarioplantilla,
            sistemaplantilla = false;
            estadoplantilla = "A";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.plantillas.Where(x => x.nombreplantilla.ToUpper() == busqueda && x.estadoplantilla == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int FindTextoReturnId(string texto, int? idplantilla)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.plantillas.Where(x => x.nombreplantilla.ToUpper() == busqueda && x.estadoplantilla == "A" && x.idplantilla == idplantilla).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        #endregion

        public static PlantillaModelo GetRegistro(int idplantilla)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.plantillas.Select(entidad =>
                     new PlantillaModelo
                     {
                         idplantilla = entidad.idplantilla,
                         idusuario = entidad.idusuario,
                         iddd = entidad.iddd,
                         nombreplantilla = entidad.nombreplantilla,
                         comentarioplantilla = entidad.comentarioplantilla,
                         versionplantilla = entidad.versionplantilla,
                         fechacreadoplantilla = entidad.fechacreadoplantilla,
                         tipoarchivoplantilla = entidad.tipoarchivoplantilla,
                         ficherobinarioplantilla = entidad.ficherobinarioplantilla,
                         sistemaplantilla = entidad.sistemaplantilla,
                         estadoplantilla = entidad.estadoplantilla,
                         nombrearchivoplantilla = entidad.nombrearchivoplantilla,
                         nombreDetalleDocumento = entidad.detalledocumento.descripciondd,
                         nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                         detalleDocumentosModelo = new DetalleDocumentoModelo
                         {
                             iddd = entidad.detalledocumento.iddd,
                             descripciondd = entidad.detalledocumento.descripciondd,
                             sistemadd = entidad.detalledocumento.sistemadd,
                             iddocumento = entidad.detalledocumento.documento.iddocumento,
                             nombreDocumento = entidad.detalledocumento.documento.descripciondocumento,
                             estadodd = entidad.detalledocumento.estadodd,
                             documentoModelo = new DocumentoModelo
                             {
                                 id = entidad.detalledocumento.documento.iddocumento,
                                 descripcion = entidad.detalledocumento.documento.descripciondocumento,
                                 sistema = entidad.detalledocumento.documento.sistemadocumento,
                                 estado = entidad.detalledocumento.documento.estadodocumento
                             }
                             //Lista filtrada de elementos que fueron eliminados
                         },
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
                             inicialesusuario = entidad.usuario.inicialesusuario,
                             respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                             numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                             fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                             estadoUsuario = entidad.usuario.estadousuario,
                             contraseniaUsuario = entidad.usuario.contraseniausuario,
                             //Lista filtrada de elementos que fueron eliminados
                         }
                     }).Where(x => x.idplantilla == idplantilla).Where(x => x.estadoplantilla == "A").FirstOrDefault();
                    var lista = new ObservableCollection<TipoArchivoModelo>(TipoArchivoModelo.GetAll());
                    registro.tipoArchivoModelo = lista.Single(i => i.extension == registro.tipoarchivoplantilla);
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro a copiar de Indice Modelo " + e.Message);
                }
                return null;
            }
        }

    }
}

