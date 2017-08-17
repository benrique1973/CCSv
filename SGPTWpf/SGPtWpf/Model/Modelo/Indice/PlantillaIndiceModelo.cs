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

namespace SGPTWpf.Model.Modelo.Indice
{
    public class PlantillaIndiceModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }

        #region idpi

        public int _idpi;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idpi
        {
            get { return _idpi; }
            set { _idpi = value; }
        }

        #endregion
        public int? idusuario
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }

        public Nullable<int> idta
        {
            get { return GetValue(() => idta); }
            set { SetValue(() => idta, value); }
        }
        
        [DisplayName("Nombre breve del indice")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(40, ErrorMessage = "Excede de 40 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripcionpi
        {
            get { return GetValue(() => descripcionpi); }
            set { SetValue(() => descripcionpi, value); }
        }

        public bool sistemapi
        {
            get { return GetValue(() => sistemapi); }
            set { SetValue(() => sistemapi, value); }
        }


        public string estadopi
        {
            get { return GetValue(() => estadopi); }
            set { SetValue(() => estadopi, value); }
        }

        public Nullable<int> idtcpi //Tipo de carpeta
        {
            get { return GetValue(() => idtcpi); }
            set { SetValue(() => idtcpi, value); }
        }

        public string descripciontc
        {
            get { return GetValue(() => descripciontc); }
            set { SetValue(() => descripciontc, value); }
        }


        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechacreadopi
        {
            get { return GetValue(() => fechacreadopi); }
            set { SetValue(() => fechacreadopi, value); }
        }

        #region tipoAuditoriaModelo

        public TipoAuditoriaModelo _tipoAuditoriaModelo;
        public TipoAuditoriaModelo tipoAuditoriaModelo
        {
            get { return _tipoAuditoriaModelo; }
            set { _tipoAuditoriaModelo = value; }
        }

        #endregion

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        public string inicialesusuario
        {
            get { return GetValue(() => inicialesusuario); }
            set { SetValue(() => inicialesusuario, value); }
        }

        public string descripcionta
        {
            get { return GetValue(() => descripcionta); }
            set { SetValue(() => descripcionta, value); }
        }

        public virtual tipocarpeta Tipocarpeta
        {
            get { return GetValue(() => Tipocarpeta); }
            set { SetValue(() => Tipocarpeta, value); }
        }

        #endregion

        #region propiedades para importacion

        public bool seleccionPlantilla
        {
            get { return GetValue(() => seleccionPlantilla); }
            set { SetValue(() => seleccionPlantilla, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(PlantillaIndiceModelo modelo, UsuarioModelo usuarioValidado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.plantillaindice', 'idpi'), (SELECT MAX(idpi) FROM sgpt.plantillaindice) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        if (modelo.tipoAuditoriaModelo != null)
                        {
                            var tablaDestino = new plantillaindice
                            {
                                //idpi = modelo.idpi,
                                idtcpi = modelo.idtcpi,
                                idusuario = modelo.idusuario,
                                idta = modelo.tipoAuditoriaModelo.id,
                                descripcionpi = modelo.descripcionpi,
                                fechacreadopi = DateTime.Now.ToString("d"),
                                estadopi = "A",
                                sistemapi = false
                            };
                            //Registro de creación
                            _context.plantillaindices.Add(tablaDestino);
                            _context.SaveChanges();
                            modelo.idpi = tablaDestino.idpi;
                            modelo.usuarioModelo = UsuarioModelo.Find(modelo.idusuario);
                            modelo.sistemapi = tablaDestino.sistemapi;
                            modelo.estadopi = tablaDestino.estadopi;
                        }
                        else
                        {
                            var tablaDestino = new plantillaindice
                            {
                                //idpi = modelo.idpi,
                                idusuario = modelo.idusuario,
                                idtcpi = modelo.idtcpi,
                                //idta = modelo.tipoAuditoriaModelo.id, valor nulo
                                descripcionpi = modelo.descripcionpi,
                                fechacreadopi = DateTime.Now.ToString("d"),
                                estadopi = "A",
                                sistemapi = false
                            };
                            //Registro de creación
                            _context.plantillaindices.Add(tablaDestino);
                            _context.SaveChanges();
                            modelo.idpi = tablaDestino.idpi;
                            modelo.usuarioModelo = UsuarioModelo.Find(modelo.idusuario);
                            modelo.sistemapi = tablaDestino.sistemapi;
                            modelo.estadopi = tablaDestino.estadopi;
                        }
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar : \n" + e);
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(PlantillaIndiceModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        if (modelo.tipoAuditoriaModelo != null)
                        {
                            var tablaDestino = new plantillaindice
                            {
                                //idpi = modelo.idpi,
                                idtcpi = modelo.idtcpi,
                                idusuario = modelo.idusuario,
                                idta = modelo.tipoAuditoriaModelo.id,
                                descripcionpi = modelo.descripcionpi,
                                fechacreadopi = DateTime.Now.ToString("d"),
                                estadopi = "A",
                                sistemapi = false
                            };
                            //Registro de creación
                            _context.plantillaindices.Add(tablaDestino);
                            _context.SaveChanges();
                            modelo.idpi = tablaDestino.idpi;
                            modelo.sistemapi = tablaDestino.sistemapi;
                            modelo.estadopi = tablaDestino.estadopi;
                            result = tablaDestino.idpi.ToString();
                        }
                        else
                        {
                            var tablaDestino = new plantillaindice
                            {
                                //idpi = modelo.idpi,
                                idusuario = modelo.idusuario,
                                idtcpi = modelo.idtcpi,
                                //idta = modelo.tipoAuditoriaModelo.id, valor nulo
                                descripcionpi = modelo.descripcionpi,
                                fechacreadopi = DateTime.Now.ToString("d"),
                                estadopi = "A",
                                sistemapi = false
                            };
                            //Registro de creación
                            _context.plantillaindices.Add(tablaDestino);
                            _context.SaveChanges();
                            modelo.idpi = tablaDestino.idpi;
                            modelo.sistemapi = tablaDestino.sistemapi;
                            modelo.estadopi = tablaDestino.estadopi;
                            result = tablaDestino.idpi.ToString();
                        }
                        
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : \n" + e);
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
        public static PlantillaIndiceModelo Find(int id)
        {
            var entidadModelo = new PlantillaIndiceModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    plantillaindice entidad = _context.plantillaindices.Find(id);
                    if (entidad == null)
                    {
                        entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idpi = entidad.idpi;
                        entidadModelo.idta = entidad.idta;
                        entidadModelo.idtcpi = entidad.idtcpi;
                        entidadModelo.idusuario = entidad.idusuario;
                        entidadModelo.idta = entidad.idta;
                        entidadModelo.descripcionpi = entidad.descripcionpi;
                        entidadModelo.fechacreadopi = entidad.fechacreadopi;//Generara error conversion de fechas
                        entidadModelo.sistemapi = entidad.sistemapi;
                        entidadModelo.estadopi = entidad.estadopi;
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
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
                    string commandString = String.Format("DELETE FROM sgpt.plantillaindice WHERE idpi={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static PlantillaIndiceModelo Find(string id)
        {
            var entidadModelo = new PlantillaIndiceModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    plantillaindice entidad = _context.plantillaindices.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idpi = entidad.idpi;
                        entidadModelo.idta = entidad.idta;
                        entidadModelo.idtcpi = entidad.idtcpi;
                        entidadModelo.idusuario = entidad.idusuario;
                        entidadModelo.idta = entidad.idta;
                        entidadModelo.descripcionpi = entidad.descripcionpi;
                        entidadModelo.fechacreadopi = entidad.fechacreadopi;//Generara error conversion de fechas
                        entidadModelo.sistemapi = entidad.sistemapi;
                        entidadModelo.estadopi = entidad.estadopi;
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
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
                    var modelo = new PlantillaIndiceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    plantillaindice entidad = _context.plantillaindices.Find(id);
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
                    var modelo = new PlantillaIndiceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.plantillaindices
                            .Where(b => b.estadopi == "B")
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
                    plantillaindice entidad = _context.plantillaindices.Find(id);
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
        public static List<PlantillaIndiceModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.plantillaindices.Select(entidad =>
                new PlantillaIndiceModelo
                {
                    idpi = entidad.idpi,
                    idta = entidad.idta,
                    idusuario = entidad.idusuario,
                    descripcionpi = entidad.descripcionpi,
                    fechacreadopi = entidad.fechacreadopi,//Generara error conversion de fechas
                    sistemapi = entidad.sistemapi,
                    estadopi = entidad.estadopi,
                    idtcpi=entidad.idtcpi,
                    descripciontc=entidad.tipocarpeta.descripciontc,
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idpi).Where(x => x.descripcionpi.ToUpper() == Texto).ToList();
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
                    var entidad = _context.plantillaindices
                            .Where(b => b.estadopi == "B")
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


        public static bool UpdateModelo(PlantillaIndiceModelo modelo)
        {
            
            bool cambio = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        plantillaindice entidad = _context.plantillaindices.Find(modelo.idpi);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!(entidad.idusuario == modelo.idusuario))
                            {
                                cambio = true;
                            }
                                if (!(entidad.descripcionpi == modelo.descripcionpi))
                                {
                                    cambio = true;
                                }
                            if (modelo.tipoAuditoriaModelo != null)
                            {
                                if (modelo.tipoAuditoriaModelo.id != entidad.idta)
                                {
                                    entidad.idta = modelo.tipoAuditoriaModelo.id;
                                    cambio = true;
                                }
                            }
                            if (modelo.idtcpi != entidad.idtcpi)
                            {
                                entidad.idtcpi = modelo.idtcpi;
                                cambio = true;
                            }
                        }
                            if (cambio)
                            {
                                entidad.idusuario = modelo.usuarioModelo.idUsuario;
                                entidad.descripcionpi = modelo.descripcionpi;
                                entidad.fechacreadopi = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);//Se actualiza por la modificacion
                                entidad.sistemapi = modelo.sistemapi;
                                entidad.estadopi = modelo.estadopi;
                                entidad.idtcpi = modelo.idtcpi;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();

                        }
                            return true;
                        }
                    }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar : \n" + e);
                    throw;
                }
            }
            else
            {
                return false;
            }
        }


        public static bool CopiarModelo(PlantillaIndiceModelo modelo)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Registro a copiar
                        plantillaindice entidad = _context.plantillaindices.Find(modelo.idpi);
                        //Inserta el registro con los nuevos datos
                        if (Insert(modelo, modelo.usuarioModelo))
                        {
                            //éxito en la copia
                            int  anterior = 0;
                            var lista = DetallePlantillaIndiceModelo.GetAll(entidad.idpi);
                            foreach (DetallePlantillaIndiceModelo item in lista)
                            {
                                anterior = item.iddpi;
                                item.idpi = modelo.idpi;//Nuevo id del padre
                                if(item.detiddpi == null)
                                {
                                    item.iddpi =0;
                                    if (DetallePlantillaIndiceModelo.Insert(item, true))
                                    {
                                        foreach (DetallePlantillaIndiceModelo itemHijo in lista)
                                        {
                                            if (itemHijo.detiddpi == anterior)
                                            {
                                                itemHijo.detiddpi = item.iddpi;
                                                itemHijo.detalleplantillaindicePadre = item;
                                            }
                                        }
                                    }
                                    else
                                    {
                                       MessageBox.Show("Error en la  inserción del detalle con id : " + item.iddpi);
                                    }
                                }
                            }
                            foreach (DetallePlantillaIndiceModelo item in lista)
                            {
                                if (item.detiddpi != null)
                                {
                                    item.iddpi = 0;
                                    if (!(DetallePlantillaIndiceModelo.Insert(item, true)))
                                    {
                                        MessageBox.Show("Error en la  inserción del detalle con id : " + item.iddpi);
                                    }
                                }
                            }

                            return true;
                        }
                        {
                            //Fallo la copia
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar : \n" + e);
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
            //Permite controlar hacer guardado, únicamente cuando se ha modificado algo en los registros
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            //plantillaindice entidad = _context.plantillaindices.Find(id);
                            //Listado de registros hijos y eliminacion
                            var listDetallePlantillaIndiceModelo = _context.detalleplantillaindices.Where(x => x.idpi == id).ToList();
                            string commandString = String.Format("UPDATE sgpt.plantillaindice SET estadopi = 'B' WHERE idpi={0};", id);
                            foreach (var registroDetallado in listDetallePlantillaIndiceModelo)
                            {
                                commandString = String.Format("UPDATE sgpt.detalleplantillaindice SET estadodpi = 'B' WHERE iddpi={0};", registroDetallado.iddpi);
                                commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                _context.Database.ExecuteSqlCommand(commandString);
                                _context.SaveChanges();
                            }
                            //eliminacion del padre
                            commandString = String.Format("UPDATE sgpt.plantillaindice SET estadopi = 'B' WHERE idpi={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //entidad.estadopi = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

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
                            //plantillaindice entidad = _context.plantillaindices.Find(id);
                            //Listado de registros hijos y eliminacion
                            var listDetallePlantillaIndiceModelo = _context.detalleplantillaindices.Where(x => x.idpi.ToString() == id).ToList(); ;
                            string commandString = String.Format("UPDATE sgpt.detalleplantillaindice SET estadodpi = 'B' WHERE iddpi={0};", id);
                            foreach (var registroDetallado in listDetallePlantillaIndiceModelo)
                            {
                                commandString = String.Format("UPDATE sgpt.detalleplantillaindice SET estadodpi = 'B' WHERE iddpi={0};", registroDetallado.iddpi);
                                commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                _context.Database.ExecuteSqlCommand(commandString);
                                _context.SaveChanges();
                                //registroDetallado.estadodpi = "B";
                                //_context.Entry(registroDetallado).State = EntityState.Modified;
                                //_context.SaveChanges();
                            }
                            //eliminacion del padre
                            commandString = String.Format("UPDATE sgpt.plantillaindice SET estadopi = 'B' WHERE idpi={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : \n" + e);
                        return result;
                    }

                }
            }
            else
            {
                return result;
            }
        }
        public static void Delete(int id)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.plantillaindice WHERE idpi={0};", id);
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
                        //plantillaindice entidad = _context.plantillaindices.Find(id);
                        //Listado de registros hijos y eliminacion
                        var listDetallePlantillaIndiceModelo = _context.detalleplantillaindices.Where(x => x.idpi == id).ToList(); ;
                        foreach (var registroDetallado in listDetallePlantillaIndiceModelo)
                        {
                            _context.detalleplantillaindices.Remove(registroDetallado);
                        }
                        //eliminacion del padre
                        string commandString = String.Format("DELETE FROM sgpt.plantillaindice WHERE idpi={0};", id);
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
                        MessageBox.Show("Exception en borrar registro : \n" + e);
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
                            //plantillaindice entidad = _context.plantillaindices.Find(id);
                            //Listado de registros hijos y eliminacion
                            var listDetallePlantillaIndiceModelo = _context.detalleplantillaindices.Where(x => x.idpi.ToString() == id).ToList(); ;
                            foreach (var registroDetallado in listDetallePlantillaIndiceModelo)
                            {
                                _context.detalleplantillaindices.Remove(registroDetallado);
                            }
                            //eliminacion del padre
                            string commandString = String.Format("DELETE FROM sgpt.plantillaindice WHERE idpi={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : \n" + e);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<PlantillaIndiceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.plantillaindices.Select(entidad =>
                     new PlantillaIndiceModelo
                     {
                         idpi = entidad.idpi,
                         idta = entidad.idta,
                         idusuario = entidad.idusuario,
                         descripcionpi = entidad.descripcionpi,
                         fechacreadopi = entidad.fechacreadopi,//Generara error conversion de fechas
                         sistemapi = entidad.sistemapi,
                         estadopi = entidad.estadopi,
                         idtcpi = entidad.idtcpi,
                         descripciontc = entidad.tipocarpeta.descripciontc,
                         seleccionPlantilla = false,
                         descripcionta = entidad.tiposauditoria.descripcionta,
                         inicialesusuario=entidad.usuario.inicialesusuario,
                        tipoAuditoriaModelo = new TipoAuditoriaModelo
                        {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
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
                            nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                            inicialesusuario = entidad.usuario.inicialesusuario,
                            respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                            numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                            fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                            estadoUsuario = entidad.usuario.estadousuario,
                            contraseniaUsuario = entidad.usuario.contraseniausuario,
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idpi).Where(x => x.estadopi == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    if (lista == null)
                    {
                        return new List<PlantillaIndiceModelo>();
                    }
                    else
                    {
                        int i = 1;
                        foreach (PlantillaIndiceModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.seleccionPlantilla = false;
                        }
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo \n" + e);
                }
                return null;
            }
        }

        public static PlantillaIndiceModelo GetRegistro(int idBuscado)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.plantillaindices.Select(entidad =>
                     new PlantillaIndiceModelo
                     {
                         idpi = entidad.idpi,
                         idta = entidad.idta,
                         idusuario = entidad.idusuario,
                         descripcionpi = entidad.descripcionpi,
                         fechacreadopi = entidad.fechacreadopi,//Generara error conversion de fechas
                         sistemapi = entidad.sistemapi,
                         estadopi = entidad.estadopi,
                         idtcpi=entidad.idtcpi,
                         descripciontc=entidad.tipocarpeta.descripciontc,
                         inicialesusuario=entidad.usuario.inicialesusuario,
                         tipoAuditoriaModelo = new TipoAuditoriaModelo
                         {
                             id = entidad.tiposauditoria.idta,
                             descripcion = entidad.tiposauditoria.descripcionta,
                             sistema = entidad.tiposauditoria.sistemata,
                             estado = entidad.tiposauditoria.estadota
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
                             nickUsuarioUsuario = entidad.usuario.nickusuariousuario,
                             inicialesusuario = entidad.usuario.inicialesusuario,
                             respuestaPistaUsuario = entidad.usuario.respuestapistausuario,
                             numeroCvpaUsuario = entidad.usuario.numerocvpausuario,
                             fechaCvpaUsuarioString = entidad.usuario.fechacvpausuario,
                             estadoUsuario = entidad.usuario.estadousuario,
                             contraseniaUsuario = entidad.usuario.contraseniausuario,
                         }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idpi).Where(x => x.idpi == idBuscado ).Where(x => x.estadopi == "A").FirstOrDefault();
                    //La ordena por el idPrograma notar la notacion
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

        public static List<PlantillaIndiceModelo> GetAll(int? idta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.plantillaindices.ToList().Where(x => x.estadopi == "A").Where(x => x.idta == idta).Select(entidad => new PlantillaIndiceModelo
                    {
                        idpi = entidad.idpi,
                        idta = entidad.idta,
                        idusuario = entidad.idusuario,
                        descripcionpi = entidad.descripcionpi,
                        fechacreadopi = entidad.fechacreadopi,//Generara error conversion de fechas
                        sistemapi = entidad.sistemapi,
                        estadopi = entidad.estadopi,
                        idtcpi=entidad.idtcpi,
                        descripciontc=entidad.tipocarpeta.descripciontc,
                        tipoAuditoriaModelo=new TipoAuditoriaModelo
                         {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
                        }
                    });
                    return DateQuery.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                throw;
                //return null;
            }
        }

        public static List<PlantillaIndiceModelo> GetAllEncabezados(int? idta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.plantillaindices.Select(entidad =>
                        new PlantillaIndiceModelo
                        {
                            idpi = entidad.idpi,
                            idta = entidad.idta,
                            idusuario = entidad.idusuario,
                            descripcionpi = entidad.descripcionpi,
                            estadopi = entidad.estadopi,
                            fechacreadopi = entidad.fechacreadopi,
                            idtcpi=entidad.idtcpi,
                            descripciontc=entidad.tipocarpeta.descripciontc,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idpi).Where(x => x.estadopi == "A").Where(x => x.idta == idta).ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                throw;
                //return null;
            }
        }



        public static List<PlantillaIndiceModelo> GetAllEncabezados()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.plantillaindices.Select(entidad =>
                        new PlantillaIndiceModelo
                        {
                            idpi = entidad.idpi,
                            idta = entidad.idta,
                            idusuario = entidad.idusuario,
                            descripcionpi = entidad.descripcionpi,
                            estadopi = entidad.estadopi,
                            fechacreadopi = entidad.fechacreadopi,
                            idtcpi=entidad.idtcpi,
                            descripciontc=entidad.tipocarpeta.descripciontc,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idpi).Where(x => x.estadopi == "A").ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                throw;
                //return null;
            }
        }
        #endregion

        #region Contar registros
        public static int ContarRegistros(int? idta)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.plantillaindices.Where(x => x.idta == idta && x.estadopi == "A").Count();
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
                    elementos = _context.plantillaindices.Where(x => x.estadopi == "A").Count();
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
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.plantillaindices.Where(x => x.descripcionpi.ToUpper() == busqueda && x.estadopi == "A").Count();

                    if (elementos == 0)
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
                    elementos = _context.plantillaindices.Where(x => x.descripcionpi.ToUpper() == busqueda && x.estadopi == "A").Count();
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
                    elementos = _context.plantillaindices.Where(x => x.descripcionpi.ToUpper() == busqueda && x.estadopi == "B").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public static bool UpdateBorradoModelo(PlantillaIndiceModelo modelo, bool actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        plantillaindice entidad = _context.plantillaindices.Find(modelo.idpi);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idta = modelo.idta;
                            entidad.idusuario = modelo.idusuario;
                            entidad.descripcionpi = modelo.descripcionpi;
                            entidad.fechacreadopi = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);//Se actualiza por la modificacion
                            entidad.sistemapi = modelo.sistemapi;
                            entidad.estadopi ="A"; // se reactiva el registro
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
                        MessageBox.Show("Exception en reactivar el registro de plantilla indice modelo : \n"+ e);
                    throw;
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
        public static PlantillaIndiceModelo Clear(PlantillaIndiceModelo modelo)
        {
            /*modelo.idpi = 0;
            modelo.idusuario = 0;
            modelo.idta = 0;
            modelo.descripcionpi = "";
            modelo.fechacreadopi = DateTime.Now.ToString("d", CultureInfo.InvariantCulture);
            modelo.estadopi = "A";
            modelo.sistemapi = false;*/
            return new PlantillaIndiceModelo();
        }


        public PlantillaIndiceModelo ()
        {
            
            idpi = 0;
            idusuario = 0;
            //idta = 0;
            idtcpi = 0;
            descripciontc = "";
            descripcionpi = "";
            fechacreadopi = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadopi = "A";
            sistemapi = false;
        }

        public PlantillaIndiceModelo(PlantillaIndiceModelo entidad, UsuarioModelo usuarioModelo)
        {
                idpi = entidad.idpi;
                idta = entidad.idta;
                idusuario = entidad.idusuario;
                descripcionpi = entidad.descripcionpi;
                fechacreadopi = MetodosModelo.homologacionFecha();
                sistemapi = false;
                estadopi = "A";
                idtcpi = entidad.idtcpi;
                descripciontc = entidad.descripciontc;
                seleccionPlantilla = false;
                descripcionta = entidad.descripcionta;
                inicialesusuario = entidad.inicialesusuario;
                tipoAuditoriaModelo = entidad.tipoAuditoriaModelo;
                this.usuarioModelo = usuarioModelo;
        }

        /*public PlantillaIndiceModelo(PlantillaIndiceModelo entidad)
        {
            this.idpi = entidad.idpi;
            this.idta = entidad.idta;
            this.idusuario = entidad.idusuario;
            this.idta = entidad.idta;
            this.descripcionpi = entidad.descripcionpi;
            this.fechacreadopi = entidad.fechacreadopi;
            this.sistemapi = entidad.sistemapi;
            this.estadopi = entidad.estadopi;
            this.tipoAuditoriaModelo = entidad.tipoAuditoriaModelo;
            this.usuario = entidad.usuario;
        }*/

            #endregion
        }

}



