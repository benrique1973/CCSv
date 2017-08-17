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
    public class DepartamentoModelo : UIBase
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
        [MaxLength(20, ErrorMessage = "Excede de 20 caracteres permitidos")]
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
        [DisplayName("Pais")]
        [Required(ErrorMessage = "Debe seleccionar un país")]
        public Nullable<int> idpais
        {
            get { return GetValue(() => idpais); }
            set { SetValue(() => idpais, value); }
        }
        public string nombrePais
        {
            get { return GetValue(() => nombrePais); }
            set { SetValue(() => nombrePais, value); }
        }
        public virtual ICollection<cliente> clientes
        {
            get { return GetValue(() => clientes); }
            set { SetValue(() => clientes, value); }
        }

        public virtual PaisModelo pais
        {
            get { return GetValue(() => pais); }
            set { SetValue(() => pais, value); }
        }

        public virtual ICollection<firma> firmas
        {
            get { return GetValue(() => firmas); }
            set { SetValue(() => firmas, value); }
        }

        public virtual ICollection<municipio> municipios
        {
            get { return GetValue(() => municipios); }
            set { SetValue(() => municipios, value); }
        }



        //public virtual ICollection<clientes> clientes { get; set; }

        #endregion

        #region Public Model Methods

        public static bool Insert(DepartamentoModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.departamentos', 'iddepartamento'), (SELECT MAX(iddepartamento) FROM sgpt.departamentos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new departamento
                        {
                            //iddepartamento = modelo.id,
                            nombredepartamento = modelo.descripcion,
                            idpais=modelo.idpais,
                            sistemadepartamento = false,
                            estadodepartamento = "A"
                        };
                        _context.departamentos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.iddepartamento;
                        modelo.sistema = tablaDestino.sistemadepartamento;
                        modelo.estado = tablaDestino.estadodepartamento;
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar :  \n"+ e);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(DepartamentoModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.departamentos', 'iddepartamento'), (SELECT MAX(iddepartamento) FROM sgpt.departamentos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new departamento
                        {
                            //iddepartamento = modelo.id,
                            nombredepartamento = modelo.descripcion,
                            idpais = modelo.idpais,
                            sistemadepartamento = false,
                            estadodepartamento = "A"
                        };
                        _context.departamentos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.iddepartamento;
                        modelo.sistema = tablaDestino.sistemadepartamento;
                        modelo.estado = tablaDestino.estadodepartamento;
                        result = tablaDestino.iddepartamento.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar :  \n"+ e);
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
            int iddepartamento = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    iddepartamento = _context.departamentos.Max(x => x.iddepartamento) + 1;
                    //iddepartamento = _context.departamentos.Count() + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return iddepartamento;
        }

        //Devuelve el registro buscado con base al indice
        public static DepartamentoModelo Find(int id)
        {
            var entidadModelo = new DepartamentoModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    departamento entidad = _context.departamentos.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.iddepartamento;
                        entidadModelo.descripcion = entidad.nombredepartamento;
                        entidadModelo.idpais=entidad.idpais;
                        entidadModelo.sistema = entidad.sistemadepartamento;
                        entidadModelo.estado = entidad.estadodepartamento;
                        entidadModelo.pais = new PaisModelo
                        {
                            id = entidad.pais.idpais,
                            descripcion = entidad.pais.nombrepais,
                            sistema = entidad.pais.sistemapais,
                            estado = entidad.pais.estadopais
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
                    string commandString = String.Format("DELETE FROM sgpt.departamentos WHERE iddepartamento={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                    //departamento entidad = _context.departamentos.Find(id);
                    //_context.departamentos.Remove(entidad);
                    //_context.SaveChanges();
                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static DepartamentoModelo Find(string id)
        {
            var modelo = new DepartamentoModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    departamento entidad = _context.departamentos.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.iddepartamento;
                        modelo.descripcion = entidad.nombredepartamento;
                        modelo.sistema = entidad.sistemadepartamento;
                        modelo.estado = entidad.estadodepartamento;
                        modelo.pais = new PaisModelo
                        {
                            id = entidad.pais.idpais,
                            descripcion = entidad.pais.nombrepais,
                            sistema = entidad.pais.sistemapais,
                            estado = entidad.pais.estadopais
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
                    var modelo = new DepartamentoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    departamento entidad = _context.departamentos.Find(id);
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
                    var modelo = new DepartamentoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.departamentos
                            .Where(b => b.estadodepartamento == "B")
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
                    departamento entidad = _context.departamentos.Find(id);
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
        public static List<DepartamentoModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.departamentos.Select(entidad =>
                new DepartamentoModelo
                {
                    id = entidad.iddepartamento,
                    descripcion = entidad.nombredepartamento,
                    sistema = entidad.sistemadepartamento,
                    idpais=entidad.idpais,
                    estado = entidad.estadodepartamento,
                    pais = new PaisModelo
                    {
                        id = entidad.pais.idpais,
                        descripcion = entidad.pais.nombrepais,
                        sistema = entidad.pais.sistemapais,
                        estado = entidad.pais.estadopais
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
                    var entidad = _context.departamentos
                            .Where(b => b.estadodepartamento == "B")
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

        public static void UpdateModelo(DepartamentoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    departamento entidad = _context.departamentos.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.iddepartamento = modelo.id;
                        entidad.nombredepartamento = modelo.descripcion;
                        entidad.idpais = modelo.idpais;
                        entidad.sistemadepartamento = modelo.sistema;
                        entidad.estadodepartamento = modelo.estado;
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

        public static bool UpdateModelo(DepartamentoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        departamento entidad = _context.departamentos.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.iddepartamento = modelo.id;
                            entidad.nombredepartamento = modelo.descripcion;
                            entidad.sistemadepartamento = modelo.sistema;
                            entidad.idpais = modelo.idpais;
                            entidad.estadodepartamento = modelo.estado;
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
                        MessageBox.Show("Exception en actualizar :  \n"+ e);
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
                            string commandString = String.Format("UPDATE sgpt.departamentos SET estadodepartamento = 'B' WHERE iddepartamento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //departamento entidad = _context.departamentos.Find(id);
                            //entidad.estadodepartamento = "B";
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
                            string commandString = String.Format("UPDATE sgpt.departamentos SET estadodepartamento = 'B' WHERE iddepartamento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            departamento entidad = _context.departamentos.Find(id);
                            //entidad.estadodepartamento = "B";
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
                    string commandString = String.Format("DELETE FROM sgpt.departamentos WHERE iddepartamento={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    //departamento entidad = _context.departamentos.Find(id);
                    //_context.departamentos.Remove(entidad);
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
                        string commandString = String.Format("DELETE FROM sgpt.departamentos WHERE iddepartamento={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //departamento entidad = _context.departamentos.Find(id);
                        //_context.departamentos.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.departamentos WHERE iddepartamento={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //departamento entidad = _context.departamentos.Find(id);
                            //_context.departamentos.Remove(entidad);
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

        public static List<departamento> GetAllOriginal()
        {
            var departamento = _context.departamentos.Include(d => d.pais);
            return departamento.ToList();
        }
        public static List<DepartamentoModelo> GetAll()
        {
           try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.departamentos.Select(entidad =>
                    new DepartamentoModelo
                    {
                        id = entidad.iddepartamento,
                        descripcion = entidad.nombredepartamento,
                        sistema = entidad.sistemadepartamento,
                        idpais =entidad.pais.idpais,
                        nombrePais=entidad.pais.nombrepais,
                        estado = entidad.estadodepartamento,
                        pais = new PaisModelo
                        {
                            id = entidad.pais.idpais,
                            descripcion = entidad.pais.nombrepais,
                            sistema = entidad.pais.sistemapais,
                            estado = entidad.pais.estadopais
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.nombrePais).Where(x => x.estado == "A").ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista  \n"+ e);
                throw;
            }
        }

        public static List<DepartamentoModelo> GetAllByPais(int id)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.departamentos.Select(entidad =>
                    new DepartamentoModelo
                    {
                        id = entidad.iddepartamento,
                        descripcion = entidad.nombredepartamento,
                        sistema = entidad.sistemadepartamento,
                        idpais = entidad.pais.idpais,
                        nombrePais = entidad.pais.nombrepais,
                        estado = entidad.estadodepartamento,
                        pais = new PaisModelo
                        {
                            id = entidad.pais.idpais,
                            descripcion = entidad.pais.nombrepais,
                            sistema = entidad.pais.sistemapais,
                            estado = entidad.pais.estadopais
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.nombrePais).Where(x => (x.estado == "A")&& (x.idpais == id)).ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista  \n"+ e);
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
                    var entidad = (from p in _context.departamentos
                                   where p.nombredepartamento.ToLower().Equals(busqueda)
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

        public static bool FindTexto(DepartamentoModelo modelo)
        {
            string busqueda = modelo.descripcion.ToLower();
            if (!((string.IsNullOrEmpty(busqueda) || string.IsNullOrWhiteSpace(busqueda))))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.departamentos
                                   where p.nombredepartamento.ToLower().Equals(busqueda) && modelo.idpais==p.idpais
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

