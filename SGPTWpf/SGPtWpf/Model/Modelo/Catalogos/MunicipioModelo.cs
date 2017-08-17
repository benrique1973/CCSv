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

namespace SGPTWpf.Model
{
    public class MunicipioModelo : UIBase
    {
        #region Model Attributes

        public static bool sincronizar { get; set; }


        private static SGPTEntidades _context;

        #endregion

        #region Model Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Codigo")]
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

        public Nullable<int> iddepartamento
        {
            get { return GetValue(() => iddepartamento); }
            set { SetValue(() => iddepartamento, value); }
        }

        public virtual ICollection<cliente> clientes
        {
            get { return GetValue(() => clientes); }
            set { SetValue(() => clientes, value); }
        }
        //public virtual ICollection<clientes> clientes { get; set; }

        public virtual DepartamentoModelo departamento 
        {
            get { return GetValue(() => departamento); }
            set { SetValue(() => departamento, value); }
        }

        public virtual ICollection<firma> firmas
        {
            get { return GetValue(() => firmas); }
            set { SetValue(() => firmas, value); }
        }

        public string nombrePais
        {
            get { return GetValue(() => nombrePais); }
            set { SetValue(() => nombrePais, value); }
        }
        public string nombreDepartamento
        {
            get { return GetValue(() => nombreDepartamento); }
            set { SetValue(() => nombreDepartamento, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(MunicipioModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.municipios', 'idmunicipio'), (SELECT MAX(idmunicipio) FROM sgpt.municipios) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new CapaDatos.municipio
                        {
                            //idmunicipio = modelo.id,
                            nombremunicipio = modelo.descripcion,
                            sistemamunicipio = false,
                            estadomunicipio = "A",
                            iddepartamento = modelo.iddepartamento
                        };
                        _context.municipios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idmunicipio;
                        modelo.sistema = tablaDestino.sistemamunicipio;
                        modelo.estado = tablaDestino.estadomunicipio;
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

        public static string Insert(MunicipioModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.municipios', 'idmunicipio'), (SELECT MAX(idmunicipio) FROM sgpt.municipios) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new CapaDatos.municipio
                        {
                            //idmunicipio = modelo.id,
                            nombremunicipio = modelo.descripcion,
                            sistemamunicipio = false,
                            estadomunicipio = "A",
                            iddepartamento = modelo.iddepartamento
                        };
                        _context.municipios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idmunicipio;
                        modelo.sistema = tablaDestino.sistemamunicipio;
                        modelo.estado = tablaDestino.estadomunicipio;
                        result = tablaDestino.idmunicipio.ToString();
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

        public static int? IdAsignar()
        {
            int? idmunicipio = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    if (!(sincronizar))
                    {
                        var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                        "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.municipios', 'idmunicipio'), (SELECT MAX(idmunicipio) FROM sgpt.municipios) + 1);");
                        sincronizar = true;
                    }
                    idmunicipio = _context.municipios.Max(x => x.idmunicipio) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idmunicipio;
        }

        //Devuelve el registro buscado con base al indice
        public static MunicipioModelo Find(int id)
        {
            var entidadModelo = new MunicipioModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    municipio entidad = _context.municipios.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idmunicipio;
                        entidadModelo.descripcion = entidad.nombremunicipio;
                        entidadModelo.iddepartamento = entidad.iddepartamento;
                        entidadModelo.sistema = entidad.sistemamunicipio;
                        entidadModelo.estado = entidad.estadomunicipio;
                        entidadModelo.nombreDepartamento = entidad.departamento.nombredepartamento;
                        entidadModelo.nombrePais = entidad.departamento.pais.nombrepais;
                        entidadModelo.departamento = new DepartamentoModelo
                        {
                            id = entidad.departamento.iddepartamento,
                            descripcion = entidad.departamento.nombredepartamento,
                            sistema = entidad.departamento.sistemadepartamento,
                            idpais = entidad.departamento.idpais,
                            estado = entidad.departamento.estadodepartamento,
                            pais = new PaisModelo
                            {
                                id = entidad.departamento.pais.idpais,
                                descripcion = entidad.departamento.pais.nombrepais,
                                sistema = entidad.departamento.pais.sistemapais,
                                estado = entidad.departamento.pais.estadopais
                            }
                        };
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
                    string commandString = String.Format("DELETE FROM sgpt.municipios WHERE idmunicipio={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //municipio entidad = _context.municipios.Find(id);
                    //_context.municipios.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static MunicipioModelo Find(string id)
        {
            var modelo = new MunicipioModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    municipio entidad = _context.municipios.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idmunicipio;
                        modelo.descripcion = entidad.nombremunicipio;
                        modelo.sistema = entidad.sistemamunicipio;
                        modelo.estado = entidad.estadomunicipio;
                        modelo.iddepartamento = entidad.iddepartamento;
                        modelo.departamento = new DepartamentoModelo
                        {
                            id = entidad.departamento.iddepartamento,
                            descripcion = entidad.departamento.nombredepartamento,
                            sistema = entidad.departamento.sistemadepartamento,
                            idpais = entidad.departamento.idpais,
                            estado = entidad.departamento.estadodepartamento,
                            pais = new PaisModelo
                            {
                                id = entidad.departamento.pais.idpais,
                                descripcion = entidad.departamento.pais.nombrepais,
                                sistema = entidad.departamento.pais.sistemapais,
                                estado = entidad.departamento.pais.estadopais
                            }
                        };
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
                    var modelo = new MunicipioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    municipio entidad = _context.municipios.Find(id);
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
                    var modelo = new MunicipioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.municipios
                            .Where(b => b.estadomunicipio == "B")
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
                    municipio entidad = _context.municipios.Find(id);
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
        public static List<MunicipioModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.municipios.Select(entidad =>
                new MunicipioModelo
                {
                    id = entidad.idmunicipio,
                    descripcion = entidad.nombremunicipio,
                    sistema = entidad.sistemamunicipio,
                    estado = entidad.estadomunicipio,
                    nombrePais = entidad.departamento.pais.nombrepais,
                    nombreDepartamento = entidad.departamento.nombredepartamento,
                    iddepartamento = entidad.iddepartamento,
                    departamento = new DepartamentoModelo
                    {
                        id = entidad.departamento.iddepartamento,
                        descripcion = entidad.departamento.nombredepartamento,
                        sistema = entidad.departamento.sistemadepartamento,
                        idpais = entidad.departamento.idpais,
                        estado = entidad.departamento.estadodepartamento,
                        pais = new PaisModelo
                        {
                            id = entidad.departamento.pais.idpais,
                            descripcion = entidad.departamento.pais.nombrepais,
                            sistema = entidad.departamento.pais.sistemapais,
                            estado = entidad.departamento.pais.estadopais
                        }
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
                    var entidad = _context.municipios
                            .Where(b => b.estadomunicipio == "B")
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

        public static void UpdateModelo(MunicipioModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    municipio entidad = _context.municipios.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idmunicipio = modelo.id;
                        entidad.nombremunicipio = modelo.descripcion;
                        entidad.sistemamunicipio = modelo.sistema;
                        entidad.estadomunicipio = modelo.estado;
                        entidad.iddepartamento = modelo.iddepartamento;
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

        public static bool UpdateModelo(MunicipioModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        municipio entidad = _context.municipios.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idmunicipio = modelo.id;
                            entidad.nombremunicipio = modelo.descripcion;
                            entidad.sistemamunicipio = modelo.sistema;
                            entidad.estadomunicipio = modelo.estado;
                            entidad.iddepartamento = modelo.iddepartamento;
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
                            string commandString = String.Format("UPDATE sgpt.municipios SET estadomunicipio = 'B' WHERE idmunicipio={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //municipio entidad = _context.municipios.Find(id);
                            //entidad.estadomunicipio = "B";
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
                            string commandString = String.Format("UPDATE sgpt.municipios SET estadomunicipio = 'B' WHERE idmunicipio={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();


                            //municipio entidad = _context.municipios.Find(id);
                            //entidad.estadomunicipio = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.municipios WHERE idmunicipio={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //municipio entidad = _context.municipios.Find(id);
                    //_context.municipios.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.municipios WHERE idmunicipio={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                        //municipio entidad = _context.municipios.Find(id);
                        //_context.municipios.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.municipios WHERE idmunicipio={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //municipio entidad = _context.municipios.Find(id);
                            //_context.municipios.Remove(entidad);
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

        public static List<MunicipioModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.municipios.Select(entidad =>
                    new MunicipioModelo
                    {
                        id = entidad.idmunicipio,
                        descripcion = entidad.nombremunicipio,
                        sistema = entidad.sistemamunicipio,
                        estado = entidad.estadomunicipio,
                        nombrePais = entidad.departamento.pais.nombrepais,
                        nombreDepartamento = entidad.departamento.nombredepartamento,
                        iddepartamento = entidad.iddepartamento,
                        departamento = new DepartamentoModelo
                        {
                            id = entidad.departamento.iddepartamento,
                            descripcion = entidad.departamento.nombredepartamento,
                            sistema = entidad.departamento.sistemadepartamento,
                            idpais = entidad.departamento.idpais,
                            estado = entidad.departamento.estadodepartamento,
                            pais = new PaisModelo
                            {
                                id = entidad.departamento.pais.idpais,
                                descripcion = entidad.departamento.pais.nombrepais,
                                sistema = entidad.departamento.pais.sistemapais,
                                estado = entidad.departamento.pais.estadopais
                            }
                        }
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.nombrePais).OrderBy(o => o.nombreDepartamento).OrderBy(o => o.nombreDepartamento).Where(x => x.estado == "A").ToList();
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
                    var entidad = (from p in _context.municipios
                                   where p.nombremunicipio.ToLower().Equals(busqueda)
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
        public static bool FindTexto(MunicipioModelo modelo)
        {
            string busqueda = modelo.descripcion.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.municipios
                                   where p.nombremunicipio.ToLower().Equals(busqueda) && modelo.iddepartamento == p.iddepartamento
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
    }

}




