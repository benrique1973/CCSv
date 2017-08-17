using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.firmas
{

    public class FirmaModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }



        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idfirma
        {
            get { return GetValue(() => idfirma); }
            set { SetValue(() => idfirma, value); }
        }

        public Nullable<int> iddepartamento
        {
            get { return GetValue(() => iddepartamento); }
            set { SetValue(() => iddepartamento, value); }
        }

        public int idpais
        {
            get { return GetValue(() => idpais); }
            set { SetValue(() => idpais, value); }
        }
        public int idmunicipio
        {
            get { return GetValue(() => idmunicipio); }
            set { SetValue(() => idmunicipio, value); }
        }
        public Nullable<int> idusuario
        {
            get { return GetValue(() => idusuario); }
            set { SetValue(() => idusuario, value); }
        }
        public string razonsocialfirma
        {
            get { return GetValue(() => razonsocialfirma); }
            set { SetValue(() => razonsocialfirma, value); }
        }
        public string representantefirma
        {
            get { return GetValue(() => representantefirma); }
            set { SetValue(() => representantefirma, value); }
        }
        public string nitfirma
        {
            get { return GetValue(() => nitfirma); }
            set { SetValue(() => nitfirma, value); }
        }
        public string nrcfirma
        {
            get { return GetValue(() => nrcfirma); }
            set { SetValue(() => nrcfirma, value); }
        }
        public string direccionfirma
        {
            get { return GetValue(() => direccionfirma); }
            set { SetValue(() => direccionfirma, value); }
        }
        public Nullable<int> numerocvpafirma
        {
            get { return GetValue(() => numerocvpafirma); }
            set { SetValue(() => numerocvpafirma, value); }
        }
        public string fechainscripcioncvpafirma
        {
            get { return GetValue(() => fechainscripcioncvpafirma); }
            set { SetValue(() => fechainscripcioncvpafirma, value); }
        }
        public string fechacreadofirma
        {
            get { return GetValue(() => fechacreadofirma); }
            set { SetValue(() => fechacreadofirma, value); }
        }
        public string urlfirma
        {
            get { return GetValue(() => urlfirma); }
            set { SetValue(() => urlfirma, value); }
        }
        public byte[] logofirma
        {
            get { return GetValue(() => logofirma); }
            set { SetValue(() => logofirma, value); }
        }
        public string estadofirma
        {
            get { return GetValue(() => estadofirma); }
            set { SetValue(() => estadofirma, value); }
        }

        public virtual ICollection<correo> correos
        {
            get { return GetValue(() => correos); }
            set { SetValue(() => correos, value); }
        }
        public virtual departamento departamento
        {
            get { return GetValue(() => departamento); }
            set { SetValue(() => departamento, value); }
        }
        public virtual municipio municipio
        {
            get { return GetValue(() => municipio); }
            set { SetValue(() => municipio, value); }
        }
        public virtual pais pais
        {
            get { return GetValue(() => pais); }
            set { SetValue(() => pais, value); }
        }
        public virtual usuario usuario
        {
            get { return GetValue(() => usuario); }
            set { SetValue(() => usuario, value); }
        }

        public virtual ICollection<telefono> telefonos
        {
            get { return GetValue(() => telefonos); }
            set { SetValue(() => telefonos, value); }
        }


        #endregion

        #region Public Model Methods

        #region Propiedades de la vista

        public bool activarCaptura { get; set; }


        #endregion

        public static bool Insert(FirmaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.firmas', 'idfirma'), (SELECT MAX(idfirma) FROM sgpt.firmas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new firma
                        {
                            //
                            //idfirma = modelo.idfirma,

                            //sistemadh = false,
                            //estadodh = "A",
                        };
                        _context.firmas.Add(tablaDestino);
                        _context.SaveChanges();
                        /*modelo.guardadoBase = true;
                        modelo.idfirma = tablaDestino.idfirma;
                        modelo.sistemaDh = tablaDestino.sistemadh;
                        modelo.estadoDh = tablaDestino.estadodh;
                        modelo.fechaCreadoDh = DateTime.Parse(tablaDestino.fechacreadodh);*/
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
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(FirmaModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {

                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new firma
                        {
                            //
                            //idfirma = modelo.idfirma,
                           /* idtprocedimiento = modelo.idtProcedimiento,
                            idusuariodh = modelo.idUsuario,
                            idherramienta = modelo.idHerramienta,
                            descripcionbyteadh = modelo.descripcionByteaDh,
                            descripciondh = modelo.descripcionDh,
                            fechacreadodh = DateTime.Now.ToString("d"),
                            horasplandh = modelo.horasPlanDh,
                            iddhprincipaldh = modelo.idDhPrincipalDh,
                            idvisitadh = modelo.idVisitaDh,
                            ordendh = modelo.ordenDh,
                            sistemadh = false,
                            estadodh = "A",*/
                        };
                        _context.firmas.Add(tablaDestino);
                        _context.SaveChanges();
                        /*modelo.guardadoBase = true;
                        modelo.idfirma = tablaDestino.idfirma;
                        modelo.sistemaDh = tablaDestino.sistemadh;
                        modelo.estadoDh = tablaDestino.estadodh;
                        modelo.fechaCreadoDh = DateTime.Parse(tablaDestino.fechacreadodh);*/
                        result = tablaDestino.idfirma.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : " + e.Message);
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
        public static FirmaModelo Find(int id)
        {
            var entidadModelo = new FirmaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    firma entidad = _context.firmas.Find(id);
                    if (entidad == null)
                    {
                        entidadModelo = null;
                    }
                    else
                    {
                        //idfirma = modelo.idfirma,
                        entidadModelo.idfirma = entidad.idfirma;
                        /*entidadModelo.idUsuario = entidad.idusuariodh;
                        entidadModelo.idtProcedimiento = entidad.idtprocedimiento;
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.descripcionDh = entidad.descripciondh;
                        entidadModelo.descripcionByteaDh = entidad.descripcionbyteadh;
                        entidadModelo.fechaCreadoDhString = entidad.fechacreadodh;//Generara error conversion de fechas
                        entidadModelo.ordenDh = entidad.ordendh;
                        entidadModelo.idVisitaDh = entidad.idvisitadh;
                        entidadModelo.horasPlanDh = entidad.horasplandh;
                        entidadModelo.idDhPrincipalDh = entidad.iddhprincipaldh;
                        entidadModelo.sistemaDh = entidad.sistemadh;
                        entidadModelo.guardadoBase = true;
                        entidadModelo.estadoDh = entidad.estadodh;*/
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
//                    entidadModelo.fechaCreadoDh = DateTime.Parse(entidadModelo.fechaCreadoDhString);
                    return entidadModelo;
                }
            }
            else
            {
                return entidadModelo = null;
            }
        }

        //Devuelve el maximo del orden de un registro
        public static decimal FindOrden(int id)
        {
            decimal ordenMaximo = 0;
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
  //                  ordenMaximo = _context.firmas.Where(x => x.estadodh == "A" && x.idherramienta == id).Count();
                    return ordenMaximo + 1;
                }
            }
            else
            {
                return ordenMaximo;
            }
        }
        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    firma entidad = _context.firmas.Find(id);
                    _context.firmas.Remove(entidad);
                    _context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static FirmaModelo Find(string id)
        {
            var entidadModelo = new FirmaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    firma entidad = _context.firmas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
    /*                    entidadModelo.idfirma = entidad.idfirma;
                        entidadModelo.idUsuario = entidadModelo.idUsuario;
                        entidadModelo.idtProcedimiento = entidad.idtprocedimiento;
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.descripcionDh = entidad.descripciondh;
                        entidadModelo.descripcionByteaDh = entidad.descripcionbyteadh;
                        entidadModelo.fechaCreadoDhString = entidad.fechacreadodh;//Generara error conversion de fechas
                        entidadModelo.ordenDh = entidad.ordendh;
                        entidadModelo.idVisitaDh = entidad.idvisitadh;
                        entidadModelo.idDhPrincipalDh = entidad.iddhprincipaldh;
                        entidadModelo.horasPlanDh = entidad.horasplandh;
                        entidadModelo.sistemaDh = entidad.sistemadh;
                        entidadModelo.guardadoBase = true;
                        entidadModelo.estadoDh = entidad.estadodh;*/
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
//                    entidadModelo.fechaCreadoDh = DateTime.Parse(entidadModelo.fechaCreadoDhString);
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
                    var modelo = new FirmaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    firma entidad = _context.firmas.Find(id);
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
                    var modelo = new FirmaModelo();
                    firma entidad = _context.firmas.Find(id);
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
                    var modelo = new FirmaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.firmas
  //                          .Where(b => b.estadodh == "B")
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
                    firma entidad = _context.firmas.Find(id);
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
/*        public static List<FirmaModelo> TransformLista(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.firmas.Select(entidad =>
                new FirmaModelo
                {
                    idfirma = entidad.idfirma,
                    idUsuario = entidad.idusuariodh,
                    idtProcedimiento = entidad.idtprocedimiento,
                    idHerramienta = entidad.idherramienta,
                    descripcionDh = entidad.descripciondh,
                    descripcionByteaDh = entidad.descripcionbyteadh,
                    fechaCreadoDhString = entidad.fechacreadodh,//Generara error conversion de fechas
                    sistemaDh = entidad.sistemadh,
                    idDhPrincipalDh = entidad.iddhprincipaldh,
                    idVisitaDh = entidad.idvisitadh,
                    horasPlanDh = entidad.horasplandh,
                    estadoDh = entidad.estadodh,
                    ordenDh = entidad.ordendh,
                    guardadoBase = true
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idfirma).Where(x => x.descripcionDh.ToUpper() == Texto).ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }*/

/*        public static List<FirmaModelo> GetAllPkContenido(string texto)
        {
            var Lista = TransformLista(texto);
            //Lista.ForEach(c => c.fechaCreadoDh = DateTime.Parse(c.fechaCreadoDhString));
            return Lista;   //Transformacion necesaria por la fecha 
        }
        */


        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.firmas
              //              .Where(b => b.estadodh == "B")
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

        /*public static void UpdateModelo(FirmaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    firma entidad = _context.firmas.Find(modelo.idfirma);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idfirma = modelo.idfirma;
                        entidad.idusuariodh = modelo.idUsuario;
                        entidad.idtprocedimiento = modelo.idtProcedimiento;
                        entidad.idherramienta = modelo.idHerramienta;
                        entidad.descripciondh = modelo.descripcionDh;
                        entidad.descripcionbyteadh = modelo.descripcionByteaDh;
                        entidad.fechacreadodh = modelo.fechaCreadoDh.ToString();
                        entidad.idvisitadh = modelo.idVisitaDh;
                        entidad.iddhprincipaldh = modelo.idDhPrincipalDh;
                        entidad.ordendh = modelo.ordenDh;
                        entidad.horasplandh = modelo.horasPlanDh;
                        entidad.sistemadh = modelo.sistemaDh;
                        entidad.estadodh = modelo.estadoDh;
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

        public static bool UpdateModelo(FirmaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        firma entidad = _context.firmas.Find(modelo.idfirma);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idfirma = modelo.idfirma;
                            entidad.idusuariodh = modelo.idUsuario;
                            entidad.idtprocedimiento = modelo.idtProcedimiento;
                            entidad.idherramienta = modelo.idHerramienta;
                            entidad.descripciondh = modelo.descripcionDh;
                            entidad.descripcionbyteadh = modelo.descripcionByteaDh;
                            entidad.fechacreadodh = modelo.fechaCreadoDh.ToString();
                            entidad.ordendh = modelo.ordenDh;
                            entidad.idvisitadh = modelo.idVisitaDh;
                            entidad.horasplandh = modelo.horasPlanDh;
                            entidad.iddhprincipaldh = modelo.idDhPrincipalDh;
                            entidad.sistemadh = modelo.sistemaDh;
                            entidad.estadodh = modelo.estadoDh;
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
                        MessageBox.Show("Exception en actualizar : " + e.Message);
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
                            firma entidad = _context.firmas.Find(id);
                            entidad.estadodh = "B";
                            _context.Entry(entidad).State = EntityState.Modified;
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
                            firma entidad = _context.firmas.Find(id);
                            entidad.estadodh = "B";
                            _context.Entry(entidad).State = EntityState.Modified;
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
        public static void Delete(int id)
        {
            if (id == 0)
            {
                using (_context = new SGPTEntidades())
                {
                    firma entidad = _context.firmas.Find(id);
                    _context.firmas.Remove(entidad);
                    _context.SaveChanges();
                }
            }
            else
            {
                //No regresa nada
            }
        }*/

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        /*public static bool Delete(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        firma entidad = _context.firmas.Find(id);
                        if (entidad.sistemadh)
                        {
                            entidad.estadodh = "B";
                        }
                        else
                        {
                            _context.firmas.Remove(entidad);
                        }
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
                            firma entidad = _context.firmas.Find(id);
                            _context.firmas.Remove(entidad);
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
        */
        public static List<FirmaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.firmas.Select(entidad =>
                    new FirmaModelo
                    {
                        idfirma = entidad.idfirma,
                        razonsocialfirma=entidad.razonsocialfirma,
                        estadofirma=entidad.estadofirma
                     }).OrderBy(o => o.idfirma).Where(x => x.estadofirma == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
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
        /*
        public static List<FirmaModelo> GetAll()
        {
            var Lista = GetAllTransform();
            Lista.ForEach(c => c.fechaCreadoDh = DateTime.Parse(c.fechaCreadoDhString));
            Lista.ForEach(c => c.guardadoBase = true);
            return Lista;   //Transformacion necesaria por la fecha 
        }


        public static List<FirmaModelo> GetAll(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.firmas.ToList().Where(x => x.estadodh == "A").Where(x => x.idherramienta == idHerramienta).Select(entidad => new FirmaModelo
                    {
                        idfirma = entidad.idfirma,
                        idUsuario = entidad.idusuariodh,
                        idtProcedimiento = entidad.idtprocedimiento,
                        idHerramienta = entidad.idherramienta,
                        descripcionDh = entidad.descripciondh,
                        descripcionByteaDh = entidad.descripcionbyteadh,
                        fechaCreadoDhString = entidad.fechacreadodh,//Generara error conversion de fechas
                        fechaCreadoDh = DateTime.Parse(entidad.fechacreadodh),
                        horasPlanDh = entidad.horasplandh,
                        idDhPrincipalDh = entidad.iddhprincipaldh,
                        ordenDh = entidad.ordendh,
                        idVisitaDh = entidad.idvisitadh,
                        sistemaDh = entidad.sistemadh,
                        estadoDh = entidad.estadodh,
                    }).OrderBy(o => o.ordenDh);
                    var lista = DateQuery.ToList();
                    lista.ForEach(c => c.guardadoBase = true);
                    return lista;
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

        public static List<FirmaModelo> GetAllEncabezados(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var consulta = _context.firmas.Select(entidad =>
                          new FirmaModelo
                          {
                              idfirma = entidad.idfirma,
                              idUsuario = entidad.idusuariodh,
                              idtProcedimiento = entidad.idtprocedimiento,
                              idHerramienta = entidad.idherramienta,
                              descripcionDh = entidad.descripciondh,
                              descripcionByteaDh = entidad.descripcionbyteadh,
                              horasPlanDh = entidad.horasplandh,
                              idVisitaDh = entidad.idvisitadh,
                              idDhPrincipalDh = entidad.iddhprincipaldh,
                              ordenDh = entidad.ordendh,
                              estadoDh = entidad.estadodh,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idfirma).Where(x => x.estadoDh == "A").Where(x => x.idHerramienta == idHerramienta).ToList();
                    consulta.ForEach(c => c.guardadoBase = true);
                    return consulta;
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

    */

        /*  public static List<FirmaModelo> GetAllEncabezados()
          {
              try
              {
                  using (_context = new SGPTEntidades())
                  {
                      var lista = _context.firmas.Select(entidad =>
                           new FirmaModelo
                           {
                               idfirma = entidad.idfirma,
                               idUsuario = entidad.idusuariodh,
                               idtProcedimiento = entidad.idtprocedimiento,
                               idHerramienta = entidad.idherramienta,
                               descripcionDh = entidad.descripciondh,
                               descripcionByteaDh = entidad.descripcionbyteadh,
                               ordenDh = entidad.ordendh,
                               idDhPrincipalDh = entidad.iddhprincipaldh,
                               idVisitaDh = entidad.idvisitadh,
                               horasPlanDh = entidad.horasplandh,
                               estadoDh = entidad.estadodh,
                              //Lista filtrada de elementos que fueron eliminados
                          }).OrderBy(o => o.idfirma).Where(x => x.estadoDh == "A").ToList();
                      lista.ForEach(c => c.guardadoBase = true);
                      return lista;
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
                  #region Contar registros*/
        public static int ContarRegistros()
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.firmas.Where(x => x.estadofirma == "A").Count();
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
        /*
        public static int ContarRegistros()
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.firmas.Where(x => x.estadodh == "A").Count();
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
                    var entidad = (from p in _context.firmas
                                   where p.descripciondh.ToLower().Equals(busqueda)
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

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static FirmaModelo Clear(FirmaModelo modelo)
        {
            return new FirmaModelo();
        }
        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.firmas.Where(x => x.descripciondh.ToUpper() == busqueda && x.estadodh == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }*/
        #endregion
    }

}

