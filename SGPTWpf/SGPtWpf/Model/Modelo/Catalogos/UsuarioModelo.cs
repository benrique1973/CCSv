using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Collections.ObjectModel;

namespace SGPTWpf.Model
{
    public class UsuarioModelo : UIBase
    {
        #region Model Attributes
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }

        public static bool sincronizar { get; set; }

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Codigo")]
        public int idUsuario
        {
            get { return GetValue(() => idUsuario); }
            set { SetValue(() => idUsuario, value); }
        }

        public string idDuiPersona
        {
            get { return GetValue(() => idDuiPersona); }
            set { SetValue(() => idDuiPersona, value); }
        }

        public Nullable<int> idPista
        {
            get { return GetValue(() => idPista); }
            set { SetValue(() => idPista, value); }
        }

        public Nullable<int> usuIdUsuario
        {
            get { return GetValue(() => usuIdUsuario); }
            set { SetValue(() => usuIdUsuario, value); }
        }
        [DisplayName("Rol")]
        [Required(ErrorMessage = "Debe seleccionar un rol")]
        public Nullable<int> idRol
        {
            get { return GetValue(() => idRol); }
            set { SetValue(() => idRol, value); }
        }
        public Nullable<int> idRolPadre
        {
            get { return GetValue(() => idRolPadre); }
            set { SetValue(() => idRolPadre, value); }
        }
        public string fechaRegistroUsuario
        {
            get { return GetValue(() => fechaRegistroUsuario); }
            set { SetValue(() => fechaRegistroUsuario, value); }
        }
        public string rolUsuario
        {
            get { return GetValue(() => rolUsuario); }
            set { SetValue(() => rolUsuario, value); }
        }
        //Sirve para procesos de conversion
        public string fechaRegistroUsuarioString
        {
            get { return GetValue(() => fechaRegistroUsuarioString); }
            set { SetValue(() => fechaRegistroUsuarioString, value); }
        }

        public string fechaDeBaja
        {
            get { return GetValue(() => fechaDeBaja); }
            set { SetValue(() => fechaDeBaja, value); }
        }

        public string fechaDeBajaString
        {
            get { return GetValue(() => fechaDeBajaString); }
            set { SetValue(() => fechaDeBajaString, value); }
        }
        public string fechaContratacion
        {
            get { return GetValue(() => fechaContratacion); }
            set { SetValue(() => fechaContratacion, value); }
        }
        public string fechaContratacionString
        {
            get { return GetValue(() => fechaContratacionString); }
            set { SetValue(() => fechaContratacionString, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Debe introducir su nickname")]
        [MinLength(3, ErrorMessage = "Es menor a 3 caracteres")]
        [MaxLength(25, ErrorMessage = "Excede de 25 caracteres permitidos")]
        [ExcludeChar("#$%^Ç/;[]{}()*-+~^_=!\'&><", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string nickUsuarioUsuario
        {
            get { return GetValue(() => nickUsuarioUsuario); }
            set { SetValue(() => nickUsuarioUsuario, value); }
        }

        public string inicialesusuario
        {
            get { return GetValue(() => inicialesusuario); }
            set { SetValue(() => inicialesusuario, value); }
        }
        public string respuestaPistaUsuario
        {
            get { return GetValue(() => respuestaPistaUsuario); }
            set { SetValue(() => respuestaPistaUsuario, value); }
        }
        public string numeroCvpaUsuario
        {
            get { return GetValue(() => numeroCvpaUsuario); }
            set { SetValue(() => numeroCvpaUsuario, value); }
        }
        public string fechaCvpaUsuario
        {
            get { return GetValue(() => fechaCvpaUsuario); }
            set { SetValue(() => fechaCvpaUsuario, value); }
        }
        public string fechaCvpaUsuarioString
        {
            get { return GetValue(() => fechaCvpaUsuarioString); }
            set { SetValue(() => fechaCvpaUsuarioString, value); }
        }

        [DisplayName("Estado")]
        public string estadoUsuario
        {
            get { return GetValue(() => estadoUsuario); }
            set { SetValue(() => estadoUsuario, value); }
        }

        public string contraseniaUsuario
        {
            get { return GetValue(() => contraseniaUsuario); }
            set { SetValue(() => contraseniaUsuario, value); }
        }
        public int? basadoenrol
        {
            get { return GetValue(() => basadoenrol); }
            set { SetValue(() => basadoenrol, value); }
        }
        public string nombreUsuario
        {
            get { return GetValue(() => nombreUsuario); }
            set { SetValue(() => nombreUsuario, value); }
        }

       public virtual RolModelo rolModeloUsuario
        {
            get { return GetValue(() => rolModeloUsuario); }
            set { SetValue(() => rolModeloUsuario, value); }
        }

        public virtual PersonaModelo personaModelo
        {
            get { return GetValue(() => personaModelo); }
            set { SetValue(() => personaModelo, value); }
        }

        public ObservableCollection<permisosrolesusuario> listaPermisos
        {
            get { return GetValue(() => listaPermisos); }
            set { SetValue(() => listaPermisos, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(UsuarioModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarios', 'idusuario'), (SELECT MAX(idusuario) FROM sgpt.usuarios) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new usuario
                        {
                            //idusuario = modelo.idUsuario,
                            nickusuariousuario = modelo.nickUsuarioUsuario,
                            idrol = modelo.idRol,

                            estadousuario = "A"
                        };
                        _context.usuarios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idUsuario = tablaDestino.idusuario;
                        modelo.estadoUsuario = tablaDestino.estadousuario;
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

        public static string Insert(UsuarioModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.usuarios', 'idusuario'), (SELECT MAX(idusuario) FROM sgpt.usuarios) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new usuario
                        {
                            //idusuario = modelo.idUsuario,
                            nickusuariousuario = modelo.nickUsuarioUsuario,
                            idrol = modelo.idRol,
                            estadousuario = "A"
                        };
                        _context.usuarios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idUsuario = tablaDestino.idusuario;
                        modelo.estadoUsuario = tablaDestino.estadousuario;
                        result = tablaDestino.idusuario.ToString();
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
            int idusuario = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idusuario = _context.usuarios.Max(x => x.idusuario) + 1;
                    //idusuario = _context.usuarios.Count() + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idusuario;
        }

        //Devuelve el registro buscado con base al indice
        public static UsuarioModelo Find(int? idUsuario)
        {
            UsuarioModelo entidad = new UsuarioModelo();
            if (!(idUsuario == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    usuario modelo = _context.usuarios.Find(idUsuario);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.idUsuario = modelo.idusuario;
                        entidad.idDuiPersona = modelo.idduipersona;
                        entidad.idPista = modelo.idpista;
                        entidad.usuIdUsuario = modelo.usuidusuario;
                        entidad.idRol = modelo.idrol;
                        entidad.fechaRegistroUsuario = modelo.fecharegistrousuario;
                        entidad.fechaDeBaja = modelo.fechadebaja;
                        entidad.fechaContratacion = modelo.fechacontratacion;
                        entidad.nickUsuarioUsuario = modelo.nickusuariousuario;
                        entidad.inicialesusuario = modelo.inicialesusuario;
                        entidad.respuestaPistaUsuario = modelo.respuestapistausuario;
                        entidad.numeroCvpaUsuario = modelo.numerocvpausuario;
                        entidad.fechaCvpaUsuario = modelo.fechacvpausuario;
                        entidad.estadoUsuario = modelo.estadousuario;
                        entidad.contraseniaUsuario = modelo.contraseniausuario;
                        //entidad.temacolorsistemausuario = modelo.temacolorsistemausuario;
                        //entidad.isuso = modelo.isuso;

                        if (entidad.idRol <= 6)
                        {
                            entidad.basadoenrol = entidad.idRol;
                        }
                        else
                        {
                            //Buscar el rol de referencia
                            entidad.basadoenrol = RolModelo.FindIdRolBase(entidad.idRol);
                        }
                        entidad.personaModelo = new PersonaModelo
                        {
                            idduipersona = modelo.persona.idduipersona,
                            nombrespersona = modelo.persona.nombrespersona,
                            apellidospersona = modelo.persona.apellidospersona,
                            estadopersona = modelo.persona.estadopersona,
                            nombreCompleto = modelo.persona.nombrespersona + " " + modelo.persona.apellidospersona
                        };

                        entidad.rolModeloUsuario = new RolModelo
                        {
                            id = modelo.role.idrol,
                            descripcion = modelo.role.nombrerol,
                            descripcionrol = modelo.role.descripcionrol,
                            sistema = modelo.role.sistemarol,
                            estado = modelo.role.estadorol
                        };
                        entidad.nombreUsuario = entidad.personaModelo.nombreCompleto;
                        entidad.listaPermisos = conseguirPermisos((int)idUsuario);
                        return entidad;
                    }
                }
            }
            else
            {
                return entidad = null;
            }

        }


        public static UsuarioModelo igualar(usuario entidad)
        {
            if (entidad != null)
            {
                var usuarioModelo = new UsuarioModelo
                {
                    idUsuario = entidad.idusuario,
                    idDuiPersona = entidad.idduipersona,
                    idPista = entidad.idpista,
                    usuIdUsuario = entidad.usuidusuario,
                    idRol = entidad.idrol,
                    fechaRegistroUsuarioString = entidad.fecharegistrousuario,
                    fechaDeBajaString = entidad.fechadebaja,
                    fechaContratacionString = entidad.fechacontratacion,
                    nickUsuarioUsuario = entidad.nickusuariousuario,
                    inicialesusuario = entidad.inicialesusuario,
                    respuestaPistaUsuario = entidad.respuestapistausuario,
                    numeroCvpaUsuario = entidad.numerocvpausuario,
                    fechaCvpaUsuarioString = entidad.fechacvpausuario,
                    estadoUsuario = entidad.estadousuario,
                    contraseniaUsuario = entidad.contraseniausuario,
                };
                if (usuarioModelo.idRol <= 6)
                {
                    usuarioModelo.basadoenrol = usuarioModelo.idRol;
                }
                else
                {
                    //Buscar el rol de referencia
                    usuarioModelo.basadoenrol = RolModelo.FindIdRolBase(usuarioModelo.idRol);
                }
                return usuarioModelo;
            }
            else
            {
                return null;
            }

        }

    #region Metodos para string 

    public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.usuarios WHERE idusuario={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static UsuarioModelo Find(string idUsuario)
        {
            var modelo = new UsuarioModelo();
            if (!(string.IsNullOrEmpty(idUsuario)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(idUsuario))
                    {
                        return modelo = null;
                    }
                    usuario entidad = _context.usuarios.Find(idUsuario);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.idUsuario = entidad.idusuario;
                        modelo.nickUsuarioUsuario = entidad.nickusuariousuario;
                        modelo.estadoUsuario = entidad.estadousuario;
                        modelo.idRolPadre = entidad.role.basadoenrol;
                        if (modelo.idRol <= 6)
                        {
                            modelo.basadoenrol = modelo.idRol;
                        }
                        else
                        {
                            //Buscar el rol de referencia
                            modelo.basadoenrol = RolModelo.FindIdRolBase(modelo.idRol);
                        }
                        modelo.personaModelo = new PersonaModelo
                        {
                            idduipersona = entidad.persona.idduipersona,
                            nombrespersona = entidad.persona.nombrespersona,
                            apellidospersona = entidad.persona.apellidospersona,
                            estadopersona = entidad.persona.estadopersona,
                            nombreCompleto = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                        };
                        modelo.nombreUsuario = modelo.personaModelo.nombreCompleto;
                        return modelo;
                    }
                }
            }
            else
            {
                return modelo;
            }

        }

        public static bool FindPK(string idUsuario)
        {
            if (!(string.IsNullOrEmpty(idUsuario)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new UsuarioModelo();
                    if (string.IsNullOrEmpty(idUsuario))
                    {
                        return true;
                    }
                    usuario entidad = _context.usuarios.Find(idUsuario);
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
        public static bool FindPK(string idUsuario, Boolean eliminado)
        {
            if (!(string.IsNullOrEmpty(idUsuario) || string.IsNullOrWhiteSpace(idUsuario)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new UsuarioModelo();
                    if (string.IsNullOrEmpty(idUsuario))
                    {
                        return false;
                    }
                    var entidad = _context.usuarios
                            .Where(b => b.estadousuario == "B")
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

        public static bool FindPK(int idUsuario)
        {
            if (idUsuario == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    usuario entidad = _context.usuarios.Find(idUsuario);
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
        public static List<UsuarioModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.usuarios.Select(entidad =>
                new UsuarioModelo
                {
                    idUsuario = entidad.idusuario,
                    nickUsuarioUsuario = entidad.nickusuariousuario,
                    idRol = entidad.idrol,
                    idRolPadre = entidad.role.basadoenrol,
                    estadoUsuario = entidad.estadousuario,
                    basadoenrol=entidad.role.basadoenrol,
                    personaModelo = new PersonaModelo
                    {
                        idduipersona = entidad.persona.idduipersona,
                        nombrespersona = entidad.persona.nombrespersona,
                        apellidospersona = entidad.persona.apellidospersona,
                        estadopersona = entidad.persona.estadopersona,
                        nombreCompleto = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                    },
                    rolModeloUsuario = new RolModelo
                    {
                        id = entidad.role.idrol,
                        descripcion = entidad.role.nombrerol,
                        descripcionrol = entidad.role.descripcionrol,
                        sistema = entidad.role.sistemarol,
                        estado = entidad.role.estadorol
                    },
                nombreUsuario = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idUsuario).Where(x => x.nickUsuarioUsuario.ToUpper() == Texto).ToList();
                //La ordena por el ID notar la notacion
            }

        }
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int idUsuario, Boolean eliminado)
        {
            if (!(idUsuario == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.usuarios
                            .Where(b => b.estadousuario == "B")
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

        public static void UpdateModelo(UsuarioModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    usuario entidad = _context.usuarios.Find(modelo.idUsuario);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idusuario = modelo.idUsuario;
                        entidad.nickusuariousuario = modelo.nickUsuarioUsuario;
                        entidad.idrol = modelo.idRol;
                        entidad.estadousuario = modelo.estadoUsuario;
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

        public static bool UpdateModelo(UsuarioModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        usuario entidad = _context.usuarios.Find(modelo.idUsuario);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idusuario = modelo.idUsuario;
                            entidad.nickusuariousuario = modelo.nickUsuarioUsuario;
                            entidad.idrol = modelo.idRol;
                            entidad.estadousuario = modelo.estadoUsuario;
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
        public static bool DeleteBorradoLogico(int idUsuario, Boolean actualizar)
        {
            bool result = false;
            if (!(idUsuario == 0))
            {
                {

                    try
                    {
                        int id = idUsuario;
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.usuarios SET estadousuario = 'B' WHERE idusuario={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //usuario entidad = _context.usuarios.Find(idUsuario);
                            //entidad.estadousuario = "B";
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

        public static bool DeleteBorradoLogico(string idUsuario, Boolean actualizar)
        {
            bool result = false;
            if (!((string.IsNullOrEmpty(idUsuario)) || string.IsNullOrWhiteSpace(idUsuario)))
            {
                {
                    try
                    { 
                    int id = int.Parse(idUsuario);
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.usuarios SET estadousuario = 'B' WHERE idusuario={0};", id);
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
        public static void Delete(int idUsuario)
        {
            if (idUsuario == 0)
            {
                int id = idUsuario;
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.usuarios WHERE idusuario={0};", id);
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
        public static bool Delete(int idUsuario, Boolean actualizar)
        {
            if (!(idUsuario == 0))
            {
                try
                {
                    int id = idUsuario;
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.usuarios WHERE idusuario={0};", id);
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

        public static bool Delete(string idUsuario, Boolean actualizar)
        {
            {

                if (!((string.IsNullOrEmpty(idUsuario)) || string.IsNullOrWhiteSpace(idUsuario)))
                {
                    try
                    {
                        int id = int.Parse(idUsuario);
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("DELETE FROM sgpt.usuarios WHERE idusuario={0};", id);
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

        public static List<usuario> GetAllOriginal()
        {
            var usuario = _context.usuarios.Include(d => d.role);
            return usuario.ToList();
        }
        public static List<UsuarioModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var  lista= _context.usuarios.Select(entidad =>
                    new UsuarioModelo
                    {
                        idUsuario = entidad.idusuario,
                        nickUsuarioUsuario = entidad.nickusuariousuario,
                        idRol = entidad.role.idrol,
                        idRolPadre=entidad.role.basadoenrol,
                        estadoUsuario = entidad.estadousuario,
                        //basadoenrol=entidad.role.basadoenrol,
                        personaModelo = new PersonaModelo
                        {
                            idduipersona = entidad.persona.idduipersona,
                            nombrespersona = entidad.persona.nombrespersona,
                            apellidospersona = entidad.persona.apellidospersona,
                            estadopersona = entidad.persona.estadopersona,
                            nombreCompleto = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                        },
                        rolModeloUsuario = new RolModelo
                        {
                            id = entidad.role.idrol,
                            descripcion = entidad.role.nombrerol,
                            descripcionrol = entidad.role.descripcionrol,
                            sistema = entidad.role.sistemarol,
                            estado = entidad.role.estadorol
                        },
                        nombreUsuario = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.nickUsuarioUsuario).Where(x => x.estadoUsuario == "A").ToList();
                    //La ordena por el ID notar la notacion
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

        public static List<UsuarioModelo> GetAllByPais(int idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.usuarios.Select(entidad =>
                    new UsuarioModelo
                    {
                        idUsuario = entidad.idusuario,
                        nickUsuarioUsuario = entidad.nickusuariousuario,
                        idRol = entidad.role.idrol,
                        idRolPadre=entidad.role.basadoenrol,
                        estadoUsuario = entidad.estadousuario,
                        //basadoenrol=entidad.role.basadoenrol,
                        personaModelo = new PersonaModelo
                        {
                            idduipersona = entidad.persona.idduipersona,
                            nombrespersona = entidad.persona.nombrespersona,
                            apellidospersona = entidad.persona.apellidospersona,
                            estadopersona = entidad.persona.estadopersona,
                            nombreCompleto = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                        },
                        rolModeloUsuario = new RolModelo
                        {
                            id = entidad.role.idrol,
                            descripcion = entidad.role.nombrerol,
                            descripcionrol = entidad.role.descripcionrol,
                            sistema = entidad.role.sistemarol,
                            estado = entidad.role.estadorol
                        },
                        nombreUsuario = entidad.persona.nombrespersona + " " + entidad.persona.apellidospersona
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.nickUsuarioUsuario).Where(x => (x.estadoUsuario == "A") && (x.idRol == idUsuario)).ToList();
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

        internal static ObservableCollection<permisosrolesusuario> conseguirPermisos(int idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.permisosrolesusuarios.Where(entidad => (entidad.idusuario == idUsuario && entidad.estadopru == "A"));
                    ObservableCollection<permisosrolesusuario> temporal = new ObservableCollection<permisosrolesusuario>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Error en obtencion de lista de permisos" + e);
                }
                return new ObservableCollection<permisosrolesusuario>();
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
                    var entidad = (from p in _context.usuarios
                                   where p.nickusuariousuario.ToLower().Equals(busqueda)
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

        public static bool FindTexto(UsuarioModelo modelo)
        {
            string busqueda = modelo.nickUsuarioUsuario.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.usuarios
                                   where p.nickusuariousuario.ToLower().Equals(busqueda) && modelo.idRol == p.idrol
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


        public static bool validarUsuario(string nickUsuarioUsuario, string contraseniaUsuario)
        {
            MD5 md5Hash = MD5.Create();
            string busqueda = nickUsuarioUsuario.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                try {
                    using (_context = new SGPTEntidades())
                    {
                        var entidad = (from p in _context.usuarios
                                       where p.nickusuariousuario.ToLower().Equals(busqueda)
                                       select p).FirstOrDefault();
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //Conversion de la clave y comparación
                            if (entidad.contraseniausuario == GetMd5Hash(md5Hash, contraseniaUsuario))
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
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Hubo problemas de comunicación \n" + e);
                    return false;
                }


            }
            else
            {
                return false;
            }
        }

        public static usuario validarUsuario(string nickUsuarioUsuario, string contraseniaUsuario, bool opcion)
        {
            usuario usuarioBuscado=null;
            correo correoDigitado = new correo();
            MD5 md5Hash = MD5.Create();
            string busqueda = nickUsuarioUsuario.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda)|| string.IsNullOrEmpty(contraseniaUsuario) || string.IsNullOrWhiteSpace(contraseniaUsuario))))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = string.Format("SELECT * FROM sgpt.usuarios WHERE LOWER(nickusuariousuario)='{0}';", busqueda);
                        usuarioBuscado = _context.usuarios.SqlQuery(commandString).FirstOrDefault();

                        /*usuarioBuscado = (from p in _context.usuarios
                                       where p.nickusuariousuario.ToLower().Equals(busqueda)
                                       select p).FirstOrDefault();*/
                        if (usuarioBuscado == null)
                        {
                            //Buscar si  no es email
                            string commandStringEmail = string.Format("SELECT * FROM sgpt.correos WHERE LOWER(direccioncorreo)='{0}';", busqueda);
                            correoDigitado = _context.correos.SqlQuery(commandStringEmail).FirstOrDefault();
                            if (correoDigitado == null)
                            {
                                //No se localizo 
                                return usuarioBuscado;
                            }
                            else
                            {
                                //Buscar por el email
                                commandString = string.Format("SELECT * FROM sgpt.usuarios WHERE LOWER(idduipersona)='{0}';", correoDigitado.idduipersona);
                                usuarioBuscado = _context.usuarios.SqlQuery(commandString).FirstOrDefault();
                            }
                        }

                        if (usuarioBuscado == null)
                        {
                            return usuarioBuscado;
                        }
                        else
                        {
                            //Conversion de la clave y comparación
                            if (usuarioBuscado.contraseniausuario == GetMd5Hash(md5Hash, contraseniaUsuario))
                            {
                                return usuarioBuscado;
                            }
                            else
                            {
                                usuarioBuscado = null;
                                return usuarioBuscado;
                            }

                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Hubo problemas de comunicación " + e.Message);
                    usuarioBuscado = null;
                    return usuarioBuscado;
                }


            }
            else
            {
                return usuarioBuscado;
            }
        }

        public static usuario validarUsuarioPreValidado(usuario nickUsuarioUsuario, string contraseniaUsuario, bool opcion)
        {
            usuario usuarioBuscado=null;
            MD5 md5Hash = MD5.Create();
            //string busqueda = nickUsuarioUsuario.ToLower();
            if (!(string.IsNullOrEmpty(contraseniaUsuario) || string.IsNullOrWhiteSpace(contraseniaUsuario)))
            {
                try
                {
                            //Conversion de la clave y comparación
                            if (nickUsuarioUsuario.contraseniausuario == GetMd5Hash(md5Hash, contraseniaUsuario))
                            {
                                return nickUsuarioUsuario;
                            }
                            else
                            {
                                return usuarioBuscado;
                            }

                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Hubo problemas de comunicación " + e.Message);
                    usuarioBuscado = null;
                    return usuarioBuscado;
                }


            }
            else
            {
                return usuarioBuscado;
            }
        }

        public static usuario conseguirUsuario(string nickUsuarioUsuario)
        {
            if (string.IsNullOrEmpty(nickUsuarioUsuario) || nickUsuarioUsuario == "")
            {
                return null;
            }
            else
            {
                try
                {
                    usuario registro = null;
                    string busqueda = nickUsuarioUsuario.ToLower();
                    using (_context = new SGPTEntidades())
                    {

                        string commandString = string.Format("SELECT * FROM sgpt.usuarios WHERE LOWER(nickusuariousuario)='{0}';", busqueda);
                        registro = _context.usuarios.SqlQuery(commandString).FirstOrDefault();
                        /*registro = (from p in _context.usuarios
                                    where p.nickusuariousuario.ToLower().Equals(busqueda)
                                    select p).FirstOrDefault();*/
                        if (registro != null)
                        {
                            if (registro.nickusuariousuario == nickUsuarioUsuario)
                            {
                                return registro;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error en recuperar " + e.Message);
                    return null;
                }
            }
        }
        #endregion

        public static UsuarioModelo GetRegistroByNickName(string nickUsuarioUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.usuarios.Select(entidad =>
                    new UsuarioModelo
                    {
                                idUsuario = entidad.idusuario,
                                idDuiPersona = entidad.idduipersona,
                                idPista = entidad.idpista,
                                usuIdUsuario = entidad.usuidusuario,
                                idRol = entidad.idrol,
                                idRolPadre=entidad.role.basadoenrol,
                                fechaRegistroUsuarioString = entidad.fecharegistrousuario,
                                fechaDeBajaString = entidad.fechadebaja,
                                fechaContratacionString = entidad.fechacontratacion,
                                nickUsuarioUsuario = entidad.nickusuariousuario,
                                inicialesusuario = entidad.inicialesusuario,
                                respuestaPistaUsuario = entidad.respuestapistausuario,
                                numeroCvpaUsuario = entidad.numerocvpausuario,
                                fechaCvpaUsuarioString = entidad.fechacvpausuario,
                                estadoUsuario = entidad.estadousuario,
                                contraseniaUsuario = entidad.contraseniausuario,
                                basadoenrol=entidad.role.basadoenrol,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadoUsuario == "A" && x.nickUsuarioUsuario == nickUsuarioUsuario).FirstOrDefault();
                        return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del usuario " + e.Message);
                }
                return null;
            }
        }

        public static UsuarioModelo GetRegistroByIniciales(string Iniciales)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.usuarios.Select(entidad =>
                    new UsuarioModelo
                    {
                        idUsuario = entidad.idusuario,
                        idDuiPersona = entidad.idduipersona,
                        idPista = entidad.idpista,
                        usuIdUsuario = entidad.usuidusuario,
                        idRol = entidad.idrol,
                        idRolPadre = entidad.role.basadoenrol,
                        fechaRegistroUsuarioString = entidad.fecharegistrousuario,
                        fechaDeBajaString = entidad.fechadebaja,
                        fechaContratacionString = entidad.fechacontratacion,
                        nickUsuarioUsuario = entidad.nickusuariousuario,
                        inicialesusuario = entidad.inicialesusuario,
                        respuestaPistaUsuario = entidad.respuestapistausuario,
                        numeroCvpaUsuario = entidad.numerocvpausuario,
                        fechaCvpaUsuarioString = entidad.fechacvpausuario,
                        estadoUsuario = entidad.estadousuario,
                        contraseniaUsuario = entidad.contraseniausuario,
                        basadoenrol = entidad.role.basadoenrol,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadoUsuario == "A" && x.inicialesusuario == Iniciales).FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del usuario " + e.Message);
                }
                return null;
            }
        }

        public static UsuarioModelo GetInicialesById(string Iniciales)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.usuarios.Select(entidad =>
                    new UsuarioModelo
                    {
                        idUsuario = entidad.idusuario,
                        idDuiPersona = entidad.idduipersona,
                        idPista = entidad.idpista,
                        usuIdUsuario = entidad.usuidusuario,
                        idRol = entidad.idrol,
                        idRolPadre = entidad.role.basadoenrol,
                        fechaRegistroUsuarioString = entidad.fecharegistrousuario,
                        fechaDeBajaString = entidad.fechadebaja,
                        fechaContratacionString = entidad.fechacontratacion,
                        nickUsuarioUsuario = entidad.nickusuariousuario,
                        inicialesusuario = entidad.inicialesusuario,
                        respuestaPistaUsuario = entidad.respuestapistausuario,
                        numeroCvpaUsuario = entidad.numerocvpausuario,
                        fechaCvpaUsuarioString = entidad.fechacvpausuario,
                        estadoUsuario = entidad.estadousuario,
                        contraseniaUsuario = entidad.contraseniausuario,
                        basadoenrol = entidad.role.basadoenrol,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadoUsuario == "A" && x.inicialesusuario == Iniciales).FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del usuario " + e.Message);
                }
                return null;
            }
        }
        public static UsuarioModelo GetRegistroById(int idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.usuarios.Select(entidad =>
                    new UsuarioModelo
                    {
                        idUsuario = entidad.idusuario,
                        idDuiPersona = entidad.idduipersona,
                        idPista = entidad.idpista,
                        usuIdUsuario = entidad.usuidusuario,
                        idRol = entidad.idrol,
                        idRolPadre = entidad.role.basadoenrol,
                        fechaRegistroUsuarioString = entidad.fecharegistrousuario,
                        fechaDeBajaString = entidad.fechadebaja,
                        fechaContratacionString = entidad.fechacontratacion,
                        nickUsuarioUsuario = entidad.nickusuariousuario,
                        inicialesusuario = entidad.inicialesusuario,
                        respuestaPistaUsuario = entidad.respuestapistausuario,
                        numeroCvpaUsuario = entidad.numerocvpausuario,
                        fechaCvpaUsuarioString = entidad.fechacvpausuario,
                        estadoUsuario = entidad.estadousuario,
                        contraseniaUsuario = entidad.contraseniausuario,
                        basadoenrol = entidad.role.basadoenrol,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadoUsuario == "A" && x.idUsuario == idUsuario).FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del usuario " + e.Message);
                }
                return null;
            }
        }

        public static usuario GetRegistroByIdUsarioCapaDatos(int idUsuarioModelo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.usuarios.Where(x=>x.idusuario == idUsuarioModelo).FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del usuario " + e.Message);
                }
                return null;
            }
        }

        #region Encriptacion Tomadas de SGPTmvvm
        /************************/
        /*Clases GethMD5Hash y VerifyMd5Hash, son recursos para encriptar la clave del usuario*/
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Constructor;
        public UsuarioModelo ()
        {
            
            idUsuario = 0;
            idDuiPersona = string.Empty;
            idPista = 0;
            usuIdUsuario = 0;
            idRol = 0;
            idRolPadre = 0;
            fechaRegistroUsuario = MetodosModelo.homologacionFecha();
            fechaRegistroUsuarioString = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            fechaDeBaja = MetodosModelo.homologacionFecha();
            fechaDeBajaString = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            fechaContratacion = MetodosModelo.homologacionFecha();
            fechaContratacionString = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            nickUsuarioUsuario = string.Empty;
            inicialesusuario = string.Empty;
            respuestaPistaUsuario = string.Empty;
            numeroCvpaUsuario = string.Empty;
            fechaCvpaUsuario = MetodosModelo.homologacionFecha();
            fechaCvpaUsuarioString = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoUsuario = "A";
            contraseniaUsuario = string.Empty;
            basadoenrol = 0;
         }

        #endregion


        #region Lista de asignados
        public static ObservableCollection<UsuarioModelo> GetAllAsignados(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = (from pd in _context.usuarios
                                 join od in _context.asignaciones on pd.idusuario equals od.idusuario
                                 where od.idencargo == idEncargo
                                 orderby pd.idusuario
                                 select new UsuarioModelo
                                 {
                                     idUsuario = pd.idusuario,
                                     nickUsuarioUsuario = pd.nickusuariousuario,
                                     idRol = pd.role.idrol,
                                     idRolPadre = pd.role.basadoenrol,
                                     estadoUsuario = pd.estadousuario,
                                     //basadoenrol=pd.role.basadoenrol,
                                     //personaModelo = new PersonaModelo
                                     //{
                                     //    idduipersona = pd.persona.idduipersona,
                                     //    nombrespersona = pd.persona.nombrespersona,
                                     //    apellidospersona = pd.persona.apellidospersona,
                                     //    estadopersona = pd.persona.estadopersona,
                                     //    nombreCompleto = pd.persona.nombrespersona + " " + pd.persona.apellidospersona
                                     //},
                                     //rolModeloUsuario = new RolModelo
                                     //{
                                     //    id = pd.role.idrol,
                                     //    descripcion = pd.role.nombrerol,
                                     //    descripcionrol = pd.role.descripcionrol,
                                     //    sistema = pd.role.sistemarol,
                                     //    estado = pd.role.estadorol
                                     //},
                                     nombreUsuario = pd.persona.nombrespersona + " " + pd.persona.apellidospersona,
                                     inicialesusuario = pd.inicialesusuario,
                                     basadoenrol = pd.role.basadoenrol,
                                     rolUsuario=pd.role.descripcionrol,

                                 }).ToList().OrderBy(o => o.nombreUsuario).Where(x => x.estadoUsuario == "A");
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    UsuarioModelo temporal = new UsuarioModelo
                    {
                        idUsuario = 0,
                        nickUsuarioUsuario = string.Empty,
                        idRol = null,
                        idRolPadre = null,
                        estadoUsuario = "A",
                        nombreUsuario = "Ninguno",
                        inicialesusuario = string.Empty,
                        basadoenrol = null,
                        rolUsuario = string.Empty,
                    };
                    ObservableCollection<UsuarioModelo> temporallista = new ObservableCollection<UsuarioModelo>(lista.ToList());
                    temporallista.Insert(0, temporal);  
                    foreach (UsuarioModelo item in temporallista)
                    {
                        item.idCorrelativo = i;
                        i++;
                    }
                    return temporallista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return null;
            }
        }

        public static string GetInicialesCapaDatosByid(int idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    usuario registro = _context.usuarios.Single(entidad => (entidad.idusuario == idUsuario && entidad.estadousuario == "A"));
                    return registro.inicialesusuario;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                    MessageBox.Show("Exception busqueda\n" + e);
                    return "";
            }
        }
        #endregion
    }
}

