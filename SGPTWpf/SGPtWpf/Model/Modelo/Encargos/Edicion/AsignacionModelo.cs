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
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public class AsignacionModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id de sistema contable")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idasignacion
        {
            get { return GetValue(() => idasignacion); }
            set { SetValue(() => idasignacion, value); }
        }
        public Nullable<int> idusuario
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }
        public int idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }
        public string fechacreaasignacion
        {
            get { return GetValue(() => fechacreaasignacion); }
            set { SetValue(() => fechacreaasignacion, value); }
        }

        [DisplayName("Horas asignadas")]
        [DataType(DataType.Currency, ErrorMessage = "Debe ser un valor numérico")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 1000, ErrorMessage = "El mínimo es de 0 y menor de 1000")]
        [RegularExpression(@"^[-+]?[\d.]+$", ErrorMessage = "Deben ser números mayores que cero y no letras")]
        public Nullable<decimal> horasplanasignacion
        {
            get { return GetValue(() => horasplanasignacion); }
            set { SetValue(() => horasplanasignacion, value); }
        }
        [DisplayName("Horas ejecutadas")]
        //[DataType(DataType.Currency, ErrorMessage = "Debe ser un valor numérico")]
        [Required(ErrorMessage = "Debe ingresar una cantidad")]
        [Range(0, 1000, ErrorMessage = "El mínimo es de 0 y menor de 1000")]
        //[RegularExpression(@"^[-+]?[\d.]+$", ErrorMessage = "Deben ser números mayores que cero y no se admiten letras")]
        public Nullable<decimal> horasejecucionasignacion
        {
            get { return GetValue(() => horasejecucionasignacion); }
            set { SetValue(() => horasejecucionasignacion, value); }
        }
        [DisplayName("Valor por hora")]
        //[ValidarDecimal(ErrorMessage = "Los datos ingresados no corresponden a un valor aceptable")]
        //[DataType(DataType.MultilineText)]
        [CheckValidDecimal]
        public Nullable<decimal> preciohoraasignacion
        {
            get { return GetValue(() => preciohoraasignacion); }
            set { SetValue(() => preciohoraasignacion, value); }
        }
        public string estadoasignacion
        {
            get { return GetValue(() => estadoasignacion); }
            set { SetValue(() => estadoasignacion, value); }
        }


        // Entidades relacionadas

        public int numeroCorrelativo
        {
            get { return GetValue(() => numeroCorrelativo); }
            set { SetValue(() => numeroCorrelativo, value); }
        }
        public virtual UsuarioModelo usuarioModeloAsignacion
        {
            get { return GetValue(() => usuarioModeloAsignacion); }
            set { SetValue(() => usuarioModeloAsignacion, value); }
        }

        #endregion

        #region Propiedades de presentacion
        public string rolUsuarioAsignacion
        {
            get { return GetValue(() => rolUsuarioAsignacion); }
            set { SetValue(() => rolUsuarioAsignacion, value); }
        }

        public string nombreUsuario
        {
            get { return GetValue(() => nombreUsuario); }
            set { SetValue(() => nombreUsuario, value); }
        }
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        public Nullable<decimal> totalCosto
        {
            get { return GetValue(() => totalCosto); }
            set { SetValue(() => totalCosto, value); }
        }

        #endregion



        #region Public Model Methods


        public static bool Insert(AsignacionModelo modelo)
        {
            throw new NotImplementedException();
        }

        public static bool Insert(AsignacionModelo modelo, bool valor)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.asignaciones', 'idasignacion'), (SELECT MAX(idasignacion) FROM sgpt.asignaciones) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new asignacione
                        {
                            //idasignacion = modelo.idasignacion,
                            idusuario = modelo.usuarioModeloAsignacion.idUsuario,
                            idencargo = modelo.idencargo,
                            fechacreaasignacion = modelo.fechacreaasignacion,
                            horasplanasignacion =TruncateDecimal((decimal) modelo.horasplanasignacion,2),
                            horasejecucionasignacion = TruncateDecimal((decimal)modelo.horasejecucionasignacion,2),
                            preciohoraasignacion = TruncateDecimal((decimal)modelo.preciohoraasignacion,2),
                            estadoasignacion = modelo.estadoasignacion,
                         };
                        _context.asignaciones.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idasignacion = tablaDestino.idasignacion;
                        modelo.guardadoBase = true;
                        //Se reordena la lista
                        result = true;
                    }
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException e)
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

        //Devuelve el registro buscado con base al indice
        public static AsignacionModelo Find(int id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static AsignacionModelo Find(string id)
        {
            throw new NotImplementedException();
        }

        public static bool FindPK(string id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        #endregion

        public static bool FindPK(int id)
        {
            throw new NotImplementedException();
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            throw new NotImplementedException();
        }


        public static bool UpdateModelo(AsignacionModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    asignacione entidad = _context.asignaciones.Find(modelo.idasignacion);
                    if (entidad == null)
                    {
                        return false;
                    }
                    else
                    {
                        //idasignacion = modelo.idasignacion
                        bool cambio = false;
                        if (entidad.idusuario != modelo.usuarioModeloAsignacion.idUsuario)
                        { cambio = true; }
                        else
                        {
                            if (entidad.horasplanasignacion != modelo.horasplanasignacion)
                            { cambio = true; }
                            else
                            {
                                if (entidad.horasejecucionasignacion != modelo.horasejecucionasignacion)
                                { cambio = true; }
                                else
                                {
                                    if (entidad.preciohoraasignacion != modelo.preciohoraasignacion)
                                    { cambio = true; }
                                }
                            }
                        }
                        if (cambio)
                        { 
                        entidad.idusuario = modelo.usuarioModeloAsignacion.idUsuario;
                        entidad.idencargo = modelo.idencargo;
                        entidad.fechacreaasignacion = modelo.fechacreaasignacion;
                        entidad.horasplanasignacion = modelo.horasplanasignacion;
                        entidad.horasejecucionasignacion = modelo.horasejecucionasignacion;
                        entidad.preciohoraasignacion = modelo.preciohoraasignacion;
                        entidad.estadoasignacion = modelo.estadoasignacion;
                        _context.Entry(entidad).State = EntityState.Modified;
                        _context.SaveChanges();
                            modelo.guardadoBase = true;
                        }
                        return true;
                    }
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
            if ((id != 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.asignaciones SET estadoasignacion = 'B' WHERE idasignacion={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //asignacione entidad = _context.asignaciones.Find(id);
                            //entidad.estadoasignacion = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro de asignacion : " + e.Message);
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

        public static void DeleteBorradoLogico(int id)
        {
            if ((id != 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.asignaciones SET estadoasignacion = 'B' WHERE idasignacion={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro de asignacion : \n" + e);
                        throw;
                    }
                }
            }
            else
            {
               // return result;
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
                            string commandString = String.Format("UPDATE sgpt.asignaciones SET estadoasignacion = 'B' WHERE idasignacion={0};", id);
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
                            MessageBox.Show("Exception en borrar registro de asignacion : " + e.Message);
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
            if (id != 0)
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.asignaciones WHERE idasignacion={0};", id);
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
            if ((id != 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.asignaciones WHERE idasignacion={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.asignaciones WHERE idasignacion={0};", id);
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


        public static List<AsignacionModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.asignaciones.Select(entidad =>
                    new AsignacionModelo
                    {
                        idasignacion = entidad.idasignacion,
                        idusuario = entidad.idusuario,
                        idencargo = entidad.idencargo,
                        fechacreaasignacion = entidad.fechacreaasignacion,
                        horasplanasignacion = entidad.horasplanasignacion,
                        horasejecucionasignacion = entidad.horasejecucionasignacion,
                        preciohoraasignacion = entidad.preciohoraasignacion,
                        estadoasignacion = entidad.estadoasignacion,
                        usuarioModeloAsignacion = new UsuarioModelo
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
                            //Lista filtrada de elementos que fueron eliminados
                            personaModelo = new PersonaModelo
                            {
                                idduipersona = entidad.usuario.persona.idduipersona,
                                nombrespersona = entidad.usuario.persona.nombrespersona,
                                apellidospersona = entidad.usuario.persona.apellidospersona,
                                estadopersona = entidad.usuario.persona.estadopersona,
                                nombreCompleto = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona
                            },
                        },
                        nombreUsuario = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona,
                        rolUsuarioAsignacion = entidad.usuario.role.descripcionrol,

                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idusuario).Where(x => x.estadoasignacion == "A").ToList();
                    if (listado == null)
                    {
                        return new List<AsignacionModelo>();
                    }
                    else
                    {
                        if (listado.Count>0)
                        {
                            int k = 1;
                        foreach (AsignacionModelo item in listado)
                            {
                                item.totalCosto =Math.Round( Decimal.Multiply((decimal)item.horasplanasignacion,(decimal) item.preciohoraasignacion),2);
                                item.numeroCorrelativo = k;
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
                {
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo " + e.Message);
                }
                return null;
            }
        }

        public static List<AsignacionModelo> GetAll(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.asignaciones.Select(entidad =>
                    new AsignacionModelo
                    {
                        idasignacion = entidad.idasignacion,
                        idusuario = entidad.idusuario,
                        idencargo = entidad.idencargo,
                        fechacreaasignacion = entidad.fechacreaasignacion,
                        horasplanasignacion = entidad.horasplanasignacion,
                        horasejecucionasignacion = entidad.horasejecucionasignacion,
                        preciohoraasignacion = entidad.preciohoraasignacion,
                        estadoasignacion = entidad.estadoasignacion,
                        usuarioModeloAsignacion = new UsuarioModelo
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
                            personaModelo = new PersonaModelo
                            {
                                idduipersona = entidad.usuario.persona.idduipersona,
                                nombrespersona = entidad.usuario.persona.nombrespersona,
                                apellidospersona = entidad.usuario.persona.apellidospersona,
                                estadopersona = entidad.usuario.persona.estadopersona,
                                nombreCompleto = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona
                            },

                            //Lista filtrada de elementos que fueron eliminados
                        },
                        nombreUsuario = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona,
                        rolUsuarioAsignacion = entidad.usuario.role.descripcionrol
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idusuario).Where(x => x.estadoasignacion == "A" && x.idencargo== idEncargo).ToList();
                    if (listado == null)
                    {
                        return new List<AsignacionModelo>();
                    }
                    else
                    {
                        int k = 1;
                        foreach (AsignacionModelo item in listado)
                        {
                            item.totalCosto = Math.Round(Decimal.Multiply((decimal)item.horasplanasignacion, (decimal)item.preciohoraasignacion), 2);
                            item.numeroCorrelativo = k;
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
                {
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo " + e.Message);
                }
                return null;
            }
        }


        public static List<AsignacionModelo> GetAllByIdUsuario(int idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.asignaciones.Select(entidad =>
                    new AsignacionModelo
                    {
                        idasignacion = entidad.idasignacion,
                        idusuario = entidad.idusuario,
                        idencargo = entidad.idencargo,
                        fechacreaasignacion = entidad.fechacreaasignacion,
                        horasplanasignacion = entidad.horasplanasignacion,
                        horasejecucionasignacion = entidad.horasejecucionasignacion,
                        preciohoraasignacion = entidad.preciohoraasignacion,
                        estadoasignacion = entidad.estadoasignacion,
                        usuarioModeloAsignacion = new UsuarioModelo
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
                            personaModelo = new PersonaModelo
                            {
                                idduipersona = entidad.usuario.persona.idduipersona,
                                nombrespersona = entidad.usuario.persona.nombrespersona,
                                apellidospersona = entidad.usuario.persona.apellidospersona,
                                estadopersona = entidad.usuario.persona.estadopersona,
                                nombreCompleto = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona
                            },

                            //Lista filtrada de elementos que fueron eliminados
                        },
                        nombreUsuario = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona,
                        rolUsuarioAsignacion = entidad.usuario.role.descripcionrol
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idusuario).Where(x => x.estadoasignacion == "A" && x.idusuario == idUsuario).ToList();
                    if (listado == null)
                    {
                        return new List<AsignacionModelo>();
                    }
                    else
                    {
                        int k = 1;
                        foreach (AsignacionModelo item in listado)
                        {
                            item.totalCosto = Math.Round(Decimal.Multiply((decimal)item.horasplanasignacion, (decimal)item.preciohoraasignacion), 2);
                            item.numeroCorrelativo = k;
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
                {
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo " + e.Message);
                }
                return null;
            }
        }
        public static AsignacionModelo GetRegistro(int idAsignacion)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.asignaciones.Select(entidad =>
                    new AsignacionModelo
                    {
                        idasignacion = entidad.idasignacion,
                        idusuario = entidad.idusuario,
                        idencargo = entidad.idencargo,
                        fechacreaasignacion = entidad.fechacreaasignacion,
                        horasplanasignacion = entidad.horasplanasignacion,
                        horasejecucionasignacion = entidad.horasejecucionasignacion,
                        preciohoraasignacion = entidad.preciohoraasignacion,
                        estadoasignacion = entidad.estadoasignacion,
                        usuarioModeloAsignacion = new UsuarioModelo
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
                            personaModelo = new PersonaModelo
                            {
                                idduipersona = entidad.usuario.persona.idduipersona,
                                nombrespersona = entidad.usuario.persona.nombrespersona,
                                apellidospersona = entidad.usuario.persona.apellidospersona,
                                estadopersona = entidad.usuario.persona.estadopersona,
                                nombreCompleto = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona
                            }
                        },
                        nombreUsuario = entidad.usuario.persona.nombrespersona + " " + entidad.usuario.persona.apellidospersona,
                        rolUsuarioAsignacion = entidad.usuario.role.descripcionrol,
                        guardadoBase = true
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadoasignacion == "A" && x.idasignacion == idAsignacion).FirstOrDefault();
                    if (registro == null)
                    {
                        return registro;
                    }
                    else
                    {
                        registro.totalCosto = Math.Round(Decimal.Multiply((decimal)registro.horasplanasignacion, (decimal)registro.preciohoraasignacion), 2);

                        return registro;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del sistema contable " + e.Message);
                }
                return null;
            }
        }

        public static decimal GetValorHoraEmpleado(int? idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.asignaciones.Select(entidad =>
                    new AsignacionModelo
                    {
                        idasignacion = entidad.idasignacion,
                        idusuario = entidad.idusuario,
                        idencargo = entidad.idencargo,
                        fechacreaasignacion = entidad.fechacreaasignacion,
                        horasplanasignacion = entidad.horasplanasignacion,
                        horasejecucionasignacion = entidad.horasejecucionasignacion,
                        preciohoraasignacion = entidad.preciohoraasignacion,
                        estadoasignacion = entidad.estadoasignacion,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadoasignacion == "A" && x.idusuario == idUsuario).Max(x=>x.preciohoraasignacion);
                    if (lista == null)
                    {
                        return 0;
                    }
                    else
                    {
                       return (decimal) lista;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del sistema contable " + e.Message);
                }
                return 0;
            }
        }

        #region Contar registros
        public static int ContarRegistros(int? idnitcliente)
        {
            throw new NotImplementedException();
        }

        public static int ContarRegistrosUsuario(int idUsuario)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.asignaciones.Where(x => x.idusuario == idUsuario && x.estadoasignacion == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de asignaciones: " + e.Message);
                return elementos;
            }
        }


        #endregion

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public static int FindTextoReturnId(string texto)
        {
            throw new NotImplementedException();
        }

        public static int FindTextoReturnIdBorrados(string texto)
        {
            throw new NotImplementedException();
        }

        public static bool UpdateBorradoModelo(AsignacionModelo modelo, bool actualizar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static AsignacionModelo Clear(AsignacionModelo modelo)
        {
            throw new NotImplementedException();
        }
        public AsignacionModelo()
        {
            
                        idasignacion = 0;
                        idusuario = 0;
                        idencargo =0;
                        fechacreaasignacion = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
                        horasplanasignacion = 0;
                        horasejecucionasignacion = 0;
                        preciohoraasignacion = 0;
                        estadoasignacion ="A";
                        numeroCorrelativo = 0;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion
        #region metodos auxiliares

        public static string Left(string param, int length)
        {
            string result = param.Substring(0, length);
            return result;
        }
        public static string Right(string param, int length)
        {
            int value = param.Length - length;
            string result = param.Substring(value, length);
            return result;
        }



        #endregion

        #region Funciones

        public static decimal TruncateDecimal(decimal value, int precision)
        {
            decimal step = (decimal)Math.Pow(10, precision);
            int tmp = (int)Math.Truncate(step * value);
            return tmp / step;
        }
        #endregion


    }

}



