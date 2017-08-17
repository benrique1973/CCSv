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
    public class TipoProcedimientoModelo : UIBase
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

        public int idThTprocedimiento
        {
            get { return GetValue(() => idThTprocedimiento); }
            set { SetValue(() => idThTprocedimiento, value); }
        }

        public string descripcionIdThTp
        {
            get { return GetValue(() => descripcionIdThTp); }
            set { SetValue(() => descripcionIdThTp, value); }
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
        public virtual ICollection<detalleherramienta> detalleherramientas
        {
            get { return GetValue(() => detalleherramientas); }
            set { SetValue(() => detalleherramientas, value); }
        }

        public virtual ICollection<detalleprograma> detalleprogramas
        {
            get { return GetValue(() => detalleprogramas); }
            set { SetValue(() => detalleprogramas, value); }
        }

        //public virtual ICollection<detalleherramientas> detalleherramientas { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(TipoProcedimientoModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tipoprocedimiento', 'idtprocedimiento'), (SELECT MAX(idtprocedimiento) FROM sgpt.tipoprocedimiento) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipoprocedimiento
                        {
                            //idtprocedimiento = modelo.id,
                            descripciontprocedimiento = modelo.descripcion,
                            sistematprocedimiento = false,
                            idthtprocedimiento=modelo.idThTprocedimiento,
                            estadotprocedimiento = "A"
                        };
                        _context.tipoprocedimientoes.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtprocedimiento;
                        modelo.sistema = tablaDestino.sistematprocedimiento;
                        modelo.estado = tablaDestino.estadotprocedimiento;
                        modelo.descripcionIdThTp= TipoHerramientaModelo.FindNombre(modelo.idThTprocedimiento);
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

        public static string Insert(TipoProcedimientoModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tipoprocedimiento', 'idtprocedimiento'), (SELECT MAX(idtprocedimiento) FROM sgpt.tipoprocedimiento) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipoprocedimiento
                        {
                            //idtprocedimiento = modelo.id,
                            descripciontprocedimiento = modelo.descripcion,
                            sistematprocedimiento = false,
                            idthtprocedimiento = modelo.idThTprocedimiento,
                            estadotprocedimiento = "A"
                        };
                        _context.tipoprocedimientoes.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtprocedimiento;
                        modelo.sistema = tablaDestino.sistematprocedimiento;
                        modelo.estado = tablaDestino.estadotprocedimiento;
                        modelo.descripcionIdThTp = TipoHerramientaModelo.FindNombre(modelo.idThTprocedimiento);
                        result = tablaDestino.idtprocedimiento.ToString();
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
            int idtprocedimiento = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idtprocedimiento = _context.tipoprocedimientoes.Max(x => x.idtprocedimiento) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idtprocedimiento;
        }

        //Devuelve el registro buscado con base al indice
        public static TipoProcedimientoModelo Find(int id)
        {
            var entidadModelo = new TipoProcedimientoModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idtprocedimiento;
                        entidadModelo.descripcion = entidad.descripciontprocedimiento;
                        entidadModelo.sistema = entidad.sistematprocedimiento;
                        entidadModelo.idThTprocedimiento = entidad.idthtprocedimiento;
                        entidadModelo.descripcionIdThTp = TipoHerramientaModelo.FindNombre(entidad.idthtprocedimiento);
                        entidadModelo.idThTprocedimiento = entidad.idthtprocedimiento;
                        entidadModelo.estado = entidad.estadotprocedimiento;
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
                    string commandString = String.Format("DELETE FROM sgpt.tipoprocedimiento WHERE idtprocedimiento={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static TipoProcedimientoModelo Find(string id)
        {
            var modelo = new TipoProcedimientoModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idtprocedimiento;
                        modelo.descripcion = entidad.descripciontprocedimiento;
                        modelo.sistema = entidad.sistematprocedimiento;
                        modelo.estado = entidad.estadotprocedimiento;
                        modelo.descripcionIdThTp = TipoHerramientaModelo.FindNombre(entidad.idthtprocedimiento);
                        modelo.idThTprocedimiento = entidad.idthtprocedimiento;
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
                    var modelo = new TipoProcedimientoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(id);
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
                    var modelo = new TipoProcedimientoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.tipoprocedimientoes
                            .Where(b => b.estadotprocedimiento == "B")
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
                    tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(id);
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
        public static List<TipoProcedimientoModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.tipoprocedimientoes.Select(entidad =>
                new TipoProcedimientoModelo
                {
                    id = entidad.idtprocedimiento,
                    descripcion = entidad.descripciontprocedimiento,
                    sistema = entidad.sistematprocedimiento,
                    estado = entidad.estadotprocedimiento,
                    idThTprocedimiento=entidad.idthtprocedimiento,
                    descripcionIdThTp = TipoHerramientaModelo.FindNombre(entidad.idthtprocedimiento),
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
                    var entidad = _context.tipoprocedimientoes
                            .Where(b => b.estadotprocedimiento == "B")
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

        public static void UpdateModelo(TipoProcedimientoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idtprocedimiento = modelo.id;
                        entidad.descripciontprocedimiento = modelo.descripcion;
                        entidad.sistematprocedimiento = modelo.sistema;
                        entidad.idthtprocedimiento = modelo.idThTprocedimiento;
                        entidad.estadotprocedimiento = modelo.estado;
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

        public static bool UpdateModelo(TipoProcedimientoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idtprocedimiento = modelo.id;
                            entidad.descripciontprocedimiento = modelo.descripcion;
                            entidad.sistematprocedimiento = modelo.sistema;
                            entidad.estadotprocedimiento = modelo.estado;
                            entidad.idthtprocedimiento = modelo.idThTprocedimiento;
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
                            string commandString = String.Format("UPDATE sgpt.tipoprocedimiento SET estadotprocedimiento = 'B' WHERE idtprocedimiento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //tipoprocedimiento entidad = _context.tipoprocedimientoes.Find(id);
                            //entidad.estadotprocedimiento = "B";
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
                            string commandString = String.Format("UPDATE sgpt.tipoprocedimiento SET estadotprocedimiento = 'B' WHERE idtprocedimiento={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.tipoprocedimiento WHERE idtprocedimiento={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.tipoprocedimiento WHERE idtprocedimiento={0};", id);
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
                            string commandString = String.Format("DELETE FROM sgpt.tipoprocedimiento WHERE idtprocedimiento={0};", id);
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

        public static List<TipoProcedimientoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var resultado = _context.tipoprocedimientoes.Select(entidad =>
                    new TipoProcedimientoModelo
                    {
                        id = entidad.idtprocedimiento,
                        descripcion = entidad.descripciontprocedimiento,
                        sistema = entidad.sistematprocedimiento,
                        idThTprocedimiento = entidad.idthtprocedimiento,
                        estado = entidad.estadotprocedimiento
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                    foreach (TipoProcedimientoModelo elemento in resultado)
                    {
                        elemento.descripcionIdThTp = TipoHerramientaModelo.FindNombre(elemento.idThTprocedimiento);
                    }
                    return resultado;
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



    public static List<TipoProcedimientoModelo> GetAllByIdTh(int? idTh)
        {
            if (idTh == 0)
            {
                return null;
            }
            else {  
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var resultado= _context.tipoprocedimientoes.Select(entidad =>
                    new TipoProcedimientoModelo
                    {
                        id = entidad.idtprocedimiento,
                        descripcion = entidad.descripciontprocedimiento,
                        sistema = entidad.sistematprocedimiento,
                        idThTprocedimiento = entidad.idthtprocedimiento,
                        estado = entidad.estadotprocedimiento
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A").Where(x=>x.idThTprocedimiento== idTh|| x.idThTprocedimiento == 0).ToList();
                        //La ordena por el ID notar la notacion
                        foreach (TipoProcedimientoModelo elemento in resultado)
                        {
                            elemento.descripcionIdThTp = TipoHerramientaModelo.FindNombre(elemento.idThTprocedimiento);
                        }
                        return resultado;
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
        }

        public static List<TipoProcedimientoModelo> GetAllByIdTh(int? idTh,bool listadosDetalle)
        {
            {
                var lista = GetAllByIdTh(idTh);
                TipoProcedimientoModelo registroAdicional = new TipoProcedimientoModelo();
                registroAdicional.id = 0;
                registroAdicional.descripcion = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                lista.Insert(0,registroAdicional);
                return lista.OrderBy(o => o.id).ToList();
            }//Transformacion necesaria por la fecha 
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
                    var entidad = (from p in _context.tipoprocedimientoes
                                   where p.descripciontprocedimiento.ToLower().Equals(busqueda)
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

        public static string FindNombreById(int? id)
        {
            string nombre = string.Empty;
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    return nombre = _context.tipoprocedimientoes.Find(id).descripciontprocedimiento;
                }
            }
            else
            {
                return nombre;
            }
        }
        #endregion
    }

}
