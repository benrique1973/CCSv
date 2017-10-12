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

namespace SGPTWpf.Model.Modelo
{
    public class MarcasEstandaresModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        #region Model Properties

        public static bool sincronizar { get; set; }


        [DisplayName("Codigo")]
        public int idMe //idme
        {
            get { return GetValue(() => idMe); }
            set { SetValue(() => idMe, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(100, ErrorMessage = "Excede de 100 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string significadoMe //significadome
        {
            get { return GetValue(() => significadoMe); }
            set { SetValue(() => significadoMe, value); }
        }

        public string inicialesusuario //significadome
        {
            get { return GetValue(() => inicialesusuario); }
            set { SetValue(() => inicialesusuario, value); }
        }
        public virtual UsuarioModelo usuario
        {
            get { return GetValue(() => usuario); }
            set { SetValue(() => usuario, value); }
        }

        [DisplayName("Codigo usuario")]
        public Nullable<int> idusuario //idme
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }
        [DisplayName("Simbolo")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(1, ErrorMessage = "Excede de 1 caracter permitido")]
        [ExcludeChar("ñ$Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string marcame
        {
            get { return GetValue(() => marcame); }
            set { SetValue(() => marcame, value); }
        }

        [DisplayName("Fecha de creación del registro")]
        [Required(ErrorMessage = "Dato requerido")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechahoyme
        {
            get { return GetValue(() => fechahoyme); }
            set { SetValue(() => fechahoyme, value); }
        }
        public DateTime fechahoymeDate
        {
            get { return GetValue(() => fechahoymeDate); }
            set { SetValue(() => fechahoymeDate, value); }
        }
        [DisplayName("Tipografía")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(20, ErrorMessage = "Excede de 20 caracter permitido")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string tipografiame
        {
            get { return GetValue(() => tipografiame); }
            set { SetValue(() => tipografiame, value); }
        }

        public Nullable<decimal> tamaniotipografiame
        {
            get { return GetValue(() => tamaniotipografiame); }
            set { SetValue(() => tamaniotipografiame, value); }
        }
        [DisplayName("Sistema")]
        public bool sistema //estadome
        {
            get { return GetValue(() => sistema); }
            set { SetValue(() => sistema, value); }
        }
        [DisplayName("Estado")]
        public string estado //sistemame
        {
            get { return GetValue(() => estado); }
            set { SetValue(() => estado, value); }
        }

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        #endregion

        #region Public Model Methods

        public static bool Insert(MarcasEstandaresModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.marcasestandares', 'idme'), (SELECT MAX(idme) FROM sgpt.marcasestandares) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new marcasestandare
                        {
                            //idme= modelo.significadoMe,
                            idusuario = modelo.idusuario,
                            marcame = modelo.marcame,
                            significadome = modelo.significadoMe,
                            fechahoyme = DateTime.Now.ToString("d"),
                            tipografiame = modelo.tipografiame,
                            tamaniotipografiame = modelo.tamaniotipografiame,
                            estadome = "A",
                            sistemame = false,
                        };
                        _context.marcasestandares.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idMe = tablaDestino.idme;
                        modelo.sistema = tablaDestino.sistemame;
                        modelo.estado = tablaDestino.estadome;
                        modelo.fechahoyme = tablaDestino.fechahoyme;
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : {0}", e.Source);
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(MarcasEstandaresModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.marcasestandares', 'idme'), (SELECT MAX(idme) FROM sgpt.marcasestandares) + 1);");
                            sincronizar = true;
                        }                           //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new marcasestandare
                        {
                            //idme= modelo.significadoMe,
                            idusuario = modelo.idusuario,
                            marcame = modelo.marcame,
                            significadome = modelo.significadoMe,
                            fechahoyme = DateTime.Now.ToString("d"),
                            tipografiame = modelo.tipografiame,
                            tamaniotipografiame = modelo.tamaniotipografiame,
                            estadome = "A",
                            sistemame = false,
                        };
                        _context.marcasestandares.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idMe = tablaDestino.idme;
                        modelo.sistema = tablaDestino.sistemame;
                        modelo.estado = tablaDestino.estadome;
                        modelo.fechahoyme = tablaDestino.fechahoyme;
                        result = tablaDestino.idme.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar");
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
            int idrol = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idrol = _context.marcasestandares.Max(x => x.idme) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idrol;
        }

        //Devuelve el registro buscado con base al indice
        public static MarcasEstandaresModelo Find(int idMe)
        {
            var entidadModelo = new MarcasEstandaresModelo();
            if (!(idMe == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    marcasestandare entidad = _context.marcasestandares.Find(idMe);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                            entidadModelo.idMe = entidad.idme;
                            entidadModelo.idusuario= entidad.idusuario;
                            entidadModelo.marcame = entidad.marcame  ;
                            entidadModelo.significadoMe = entidad.significadome  ;
                            entidadModelo.tipografiame = entidad.tipografiame  ;
                            entidadModelo.tamaniotipografiame = entidad.tamaniotipografiame ;
                            entidadModelo.sistema = entidad.sistemame;
                            entidadModelo.estado = entidad.estadome;
                            entidadModelo.fechahoyme = entidad.fechahoyme;
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
                    string commandString = String.Format("DELETE FROM sgpt.marcasestandares WHERE idme={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //marcasestandare entidad = _context.marcasestandares.Find(idMe);
                    //_context.marcasestandares.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static MarcasEstandaresModelo Find(string idMe)
        {
            var entidadModelo = new MarcasEstandaresModelo();
            if (!(string.IsNullOrEmpty(idMe)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(idMe))
                    {
                        return entidadModelo = null;
                    }
                    marcasestandare entidad = _context.marcasestandares.Find(idMe);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idMe = entidad.idme;
                        entidadModelo.idusuario = entidad.idusuario;
                        entidadModelo.marcame = entidad.marcame;
                        entidadModelo.significadoMe = entidad.significadome;
                        entidadModelo.tipografiame = entidad.tipografiame;
                        entidadModelo.tamaniotipografiame = entidad.tamaniotipografiame;
                        entidadModelo.sistema = entidad.sistemame;
                        entidadModelo.estado = entidad.estadome;
                        entidadModelo.fechahoyme = entidad.fechahoyme;

                        return entidadModelo;
                    }
                }
            }
            else
            {
                return entidadModelo;
            }

        }

        public static bool FindPK(string idMe)
        {
            if (!(string.IsNullOrEmpty(idMe)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new MarcasEstandaresModelo();
                    if (string.IsNullOrEmpty(idMe))
                    {
                        return true;
                    }
                    marcasestandare entidad = _context.marcasestandares.Find(idMe);
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
        public static bool FindPK(string idMe, Boolean eliminado)
        {
            if (!(string.IsNullOrEmpty(idMe) || string.IsNullOrWhiteSpace(idMe)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new MarcasEstandaresModelo();
                    if (string.IsNullOrEmpty(idMe))
                    {
                        return false;
                    }
                    var entidad = _context.marcasestandares
                            .Where(b => b.estadome == "B")
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

        public static bool FindPK(int idMe)
        {
            if (idMe == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    marcasestandare entidad = _context.marcasestandares.Find(idMe);
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
        public static List<MarcasEstandaresModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.marcasestandares.Select(entidad =>
                new MarcasEstandaresModelo
                {
                            idMe = entidad.idme,
                            idusuario= entidad.idusuario,
                            marcame = entidad.marcame  ,
                            significadoMe = entidad.significadome  ,
                            tipografiame = entidad.tipografiame  ,
                            tamaniotipografiame = entidad.tamaniotipografiame ,
                            sistema = entidad.sistemame,
                            estado = entidad.estadome,
                            fechahoyme = entidad.fechahoyme,
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idMe).Where(x => x.significadoMe.ToUpper() == Texto).ToList();
                //La ordena por el idMe notar la notacion
            }

        }
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int idMe, Boolean eliminado)
        {
            if (!(idMe == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.marcasestandares
                            .Where(b => b.estadome == "B")
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

        public static void UpdateModelo(MarcasEstandaresModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    marcasestandare entidad = _context.marcasestandares.Find(modelo.idMe);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idme= modelo.idMe;
                        entidad.idusuario = modelo.idusuario;
                        entidad.marcame = modelo.marcame;
                        entidad.significadome = modelo.significadoMe;
                        entidad.tipografiame = modelo.tipografiame;
                        entidad.tamaniotipografiame = modelo.tamaniotipografiame;
                        entidad.sistemame = modelo.sistema;
                        entidad.estadome = modelo.estado;
                        entidad.fechahoyme = modelo.fechahoyme;
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

        public static bool UpdateModelo(MarcasEstandaresModelo modelo, Boolean actualizar)
        {
            bool guardar = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        marcasestandare entidad = _context.marcasestandares.Find(modelo.idMe);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            
                            if (!(entidad.idusuario == modelo.idusuario))
                            {
                                guardar = true;
                            }
                            else
                            {
                                if (!(entidad.marcame == modelo.marcame))
                                {
                                    guardar = true;
                                }
                                else
                                {
                                    if (!(entidad.significadome.ToUpper() == modelo.significadoMe.ToUpper()))
                                    {
                                        guardar = true;
                                    }
                                    else
                                    {
                                        if (!(entidad.tipografiame == modelo.tipografiame))
                                        {
                                            guardar = true;
                                        }
                                        else
                                        {
                                            if (!(entidad.tamaniotipografiame == modelo.tamaniotipografiame))
                                            {
                                                guardar = true;
                                            }
                                            else
                                            {

                                            }
                                        }
                                    }
                                }
                            }
                            if(guardar)
                            {
                                //entidad.idme = modelo.idMe;
                                entidad.idusuario = modelo.idusuario;
                                entidad.marcame = modelo.marcame;
                                entidad.significadome = modelo.significadoMe;
                                entidad.tipografiame = modelo.tipografiame;
                                entidad.tamaniotipografiame = modelo.tamaniotipografiame;
                                //entidad.sistemame = modelo.sistema;
                                //entidad.estadome = modelo.estado;
                                entidad.fechahoyme = modelo.fechahoyme;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
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

        public static bool UpdateBorradoModelo(MarcasEstandaresModelo modelo, bool actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        marcasestandare entidad = _context.marcasestandares.Find(modelo.idMe);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idme = modelo.idMe;
                            entidad.idusuario = modelo.idusuario;
                            entidad.marcame = modelo.marcame;
                            entidad.significadome = modelo.significadoMe;
                            entidad.tipografiame = modelo.tipografiame;
                            entidad.tamaniotipografiame = modelo.tamaniotipografiame;
                            entidad.sistemame = modelo.sistema;
                            entidad.estadome = "A";//Se reactiva el registro
                            entidad.fechahoyme = modelo.fechahoyme;
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
                            string commandString = String.Format("UPDATE sgpt.marcasestandares SET estadome = 'B' WHERE idme={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //marcasestandare entidad = _context.marcasestandares.Find(idMe);
                            //entidad.estadome = "B";
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
                            string commandString = String.Format("UPDATE sgpt.marcasestandares SET estadome = 'B' WHERE idme={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //marcasestandare entidad = _context.marcasestandares.Find(idMe);
                            //entidad.estadome = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.marcasestandares WHERE idme={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //marcasestandare entidad = _context.marcasestandares.Find(idMe);
                    //_context.marcasestandares.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.marcasestandares WHERE idme={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //marcasestandare entidad = _context.marcasestandares.Find(idMe);
                        //_context.marcasestandares.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.marcasestandares WHERE idme={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //marcasestandare entidad = _context.marcasestandares.Find(idMe);
                            //_context.marcasestandares.Remove(entidad);
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

        public static ObservableCollection<MarcasEstandaresModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista= _context.marcasestandares.Select(entidad =>
                    new MarcasEstandaresModelo
                    {
                        idMe = entidad.idme,
                        idusuario = entidad.idusuario,
                        marcame = entidad.marcame,
                        significadoMe = entidad.significadome,
                        tipografiame = entidad.tipografiame,
                        tamaniotipografiame = entidad.tamaniotipografiame,
                        sistema = entidad.sistemame,
                        estado = entidad.estadome,
                        fechahoyme = entidad.fechahoyme,
                        inicialesusuario=entidad.usuario.inicialesusuario,
                        //usuarioModelo = new UsuarioModelo
                        //{
                        //    idUsuario = entidad.usuario.idusuario,
                        //    idDuiPersona = entidad.usuario.idduipersona,
                        //    idPista = entidad.usuario.idpista,
                        //    usuIdUsuario = entidad.usuario.usuidusuario,
                        //    idRol = entidad.usuario.idrol,
                        //    fechaRegistroUsuarioString = entidad.usuario.fecharegistrousuario,
                        //    fechaDeBajaString = entidad.usuario.fechadebaja,
                        //    fechaContratacionString = entidad.usuario.fechacontratacion,
                        //    nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                        //    inicialesusuario = entidad.usuario.inicialesusuario,
                        //    respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                        //    numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                        //    fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                        //    estadoUsuario = entidad.usuario.estadousuario,
                        //    contraseniaUsuario = entidad.usuario.contraseniausuario,
                        //}
                        //Lista filtrada de elementos que fueron eliminados y de valores que no son sistema
                    }).OrderBy(o => o.idMe).Where(x => x.estado == "A").ToList();
                    //La ordena por el idMe notar la notacion
                    if (lista.Count > 0)

                    {
                        return (new ObservableCollection<MarcasEstandaresModelo>(lista));
                    }
                    else
                    {
                        return (new ObservableCollection<MarcasEstandaresModelo>());
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
                    var entidad = (from p in _context.marcasestandares
                                   where p.significadome.ToLower().Equals(busqueda)
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

        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.marcasestandares.Where(x => x.significadome.ToUpper() == busqueda && x.estadome == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public static int FindTextoReturnIdBorrados(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.marcasestandares.Where(x => x.significadome.ToUpper() == busqueda && x.estadome == "B").Count();
                    return elementos;
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
