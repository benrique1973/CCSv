using CapaDatos;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
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
using SGPTWpf.Model.Modelo.Indice;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre;

namespace SGPTWpf.Model
{
    public class TipoCarpetaModelo : UIBase
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

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Codigo")]
        public int id
        {
            get { return GetValue(() => id); }
            set { SetValue(() => id, value); }
        }

        [DisplayName("Descripción")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(30, ErrorMessage = "Excede de 30 caracteres permitidos")]
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

        public Nullable<int> idencargotc
        {
            get { return GetValue(() => idencargotc); }
            set { SetValue(() => idencargotc, value); }
        }


        public Nullable<int> padreidtc
        {
            get { return GetValue(() => padreidtc); }
            set { SetValue(() => padreidtc, value); }
        }


        public Nullable<decimal> indiceCarpeta
        {
            get { return GetValue(() => indiceCarpeta); }
            set { SetValue(() => indiceCarpeta, value); }
        }
        public virtual ICollection<detalleplantillaindice> detalleplantillaindices
        {
            get { return GetValue(() => detalleplantillaindices); }
            set { SetValue(() => detalleplantillaindices, value); }
        }
        public virtual ICollection<repositorio> repositorios
        {
            get { return GetValue(() => repositorios); }
            set { SetValue(() => repositorios, value); }
        }

        //public virtual ICollection<detalleplantillaindices> detalleplantillaindices { get; set; }

        #region Propiedades adiciones de fechas

        public string usuarioaprobo
        {
            get { return GetValue(() => usuarioaprobo); }
            set { SetValue(() => usuarioaprobo, value); }
        }

        public string usuariosuperviso
        {
            get { return GetValue(() => usuariosuperviso); }
            set { SetValue(() => usuariosuperviso, value); }
        }

        public string usuariocerro
        {
            get { return GetValue(() => usuariocerro); }
            set { SetValue(() => usuariocerro, value); }
        }
        public string fechacierre
        {
            get { return GetValue(() => fechacierre); }
            set { SetValue(() => fechacierre, value); }
        }
        public string fechasupervision
        {
            get { return GetValue(() => fechasupervision); }
            set { SetValue(() => fechasupervision, value); }
        }
        public string fechaaprobacion
        {
            get { return GetValue(() => fechaaprobacion); }
            set { SetValue(() => fechaaprobacion, value); }
        }
        //-- Almacena el estado del papel asi: 1, sigla  :I, nombre  :Inicial 2, sigla  :
        //P, nombre  :En proceso 3, sigla  :R, nombre  :Revisado 4, sigla  :
        //C, nombre  :Cerrado 5, sigla  :E, nombre  :Ejecutado 6, sigla  :
        //A, nombre  :Aprobado 7, sigla  :T, nombre  :Terminado
        public string etapapapel
        {
            get { return GetValue(() => etapapapel); }
            set { SetValue(() => etapapapel, value); }
        }
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }

        //Para distinguir entre registros ya con  id de la base y registros  pendientes de guardar
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        //public virtual UsuarioModelo usuarioModelo
        //{
        //    get { return GetValue(() => usuarioModelo); }
        //    set { SetValue(() => usuarioModelo, value); }
        //}
        #region usuarioModelo
        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        #endregion

        #region Propiedades para importacion

        public bool seleccionEntidad
        {
            get { return GetValue(() => seleccionEntidad); }
            set { SetValue(() => seleccionEntidad, value); }
        }

        #region propiedades para importacion de programas
        public string razonsocialclientePrograma
        {
            get { return GetValue(() => razonsocialclientePrograma); }
            set { SetValue(() => razonsocialclientePrograma, value); }
        }
        public string descripcionTipoAuditoriaPrograma
        {
            get { return GetValue(() => descripcionTipoAuditoriaPrograma); }
            set { SetValue(() => descripcionTipoAuditoriaPrograma, value); }
        }

        public string fechainiperauditencargoPrograma
        {
            get { return GetValue(() => fechainiperauditencargoPrograma); }
            set { SetValue(() => fechainiperauditencargoPrograma, value); }
        }
        public string fechafinperauditencargoPrograma
        {
            get { return GetValue(() => fechafinperauditencargoPrograma); }
            set { SetValue(() => fechafinperauditencargoPrograma, value); }
        }
        public bool seleccionPrograma
        {
            get { return GetValue(() => seleccionPrograma); }
            set { SetValue(() => seleccionPrograma, value); }
        }

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public virtual ObservableCollection<ProgramaModelo> listadoProgramaModelo
        {
            get { return GetValue(() => listadoProgramaModelo); }
            set { SetValue(() => listadoProgramaModelo, value); }
        }

        public virtual ObservableCollection<UsuarioProgramaAccionModelo> listadoBitacora
        {
            get { return GetValue(() => listadoBitacora); }
            set { SetValue(() => listadoBitacora, value); }
        }
        #endregion
        #endregion


        #region Propiedades para presentacion

        public decimal? IndiceItemsObligatorios
        {
            get { return GetValue(() => IndiceItemsObligatorios); }
            set { SetValue(() => IndiceItemsObligatorios, value); }
        }

        public decimal? IndiceItemsTotales
        {
            get { return GetValue(() => IndiceItemsTotales); }
            set { SetValue(() => IndiceItemsTotales, value); }
        }

        public decimal? IndiceItemsVoluntarios
        {
            get { return GetValue(() => IndiceItemsVoluntarios); }
            set { SetValue(() => IndiceItemsVoluntarios, value); }
        }

        public Nullable<int> itemsObligatorios
        {
            get { return GetValue(() => itemsObligatorios); }
            set { SetValue(() => itemsObligatorios, value); }
        }

        public Nullable<int> itemsVoluntarios
        {
            get { return GetValue(() => itemsVoluntarios); }
            set { SetValue(() => itemsVoluntarios, value); }
        }

        public Nullable<int> itemsTotales
        {
            get { return GetValue(() => itemsTotales); }
            set { SetValue(() => itemsTotales, value); }
        }

        public Nullable<int> itemsVoluntariosReferenciados
        {
            get { return GetValue(() => itemsVoluntariosReferenciados); }
            set { SetValue(() => itemsVoluntariosReferenciados, value); }
        }

        public Nullable<int> itemsTotalesReferenciados
        {
            get { return GetValue(() => itemsTotalesReferenciados); }
            set { SetValue(() => itemsTotalesReferenciados, value); }
        }

        public Nullable<int> itemsObligatoriosReferenciados
        {
            get { return GetValue(() => itemsObligatoriosReferenciados); }
            set { SetValue(() => itemsObligatoriosReferenciados, value); }
        }

        #endregion


        #endregion

        #region Public Model Methods

        public static bool Insert(TipoCarpetaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tipocarpeta', 'idtc'), (SELECT MAX(idtc) FROM sgpt.tipocarpeta) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipocarpeta
                        {
                            //idtc = modelo.id,
                            //idencargotc=modelo.idencargotc,
                            descripciontc = modelo.descripcion,
                            sistematc = false,
                            estadotc = "A",
                            //padreidtc=modelo.padreidtc,
                            
                        };
                        _context.tipocarpetas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtc;
                        modelo.sistema = tablaDestino.sistematc;
                        modelo.estado = tablaDestino.estadotc;
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar \n" + e);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static int Insert(TipoCarpetaModelo modelo, EncargoModelo encargo)
        {
            int result = 0;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tipocarpeta', 'idtc'), (SELECT MAX(idtc) FROM sgpt.tipocarpeta) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipocarpeta
                        {
                            //idtc = modelo.id,
                            idencargotc=modelo.idencargotc,
                            descripciontc = modelo.descripcion,
                            sistematc = false,
                            estadotc = "A",
                            padreidtc=modelo.padreidtc,

                        };
                        _context.tipocarpetas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtc;
                        modelo.sistema = tablaDestino.sistematc;
                        modelo.estado = tablaDestino.estadotc;
                        result = 1;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar \n" + e);
                    return result;
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        public static string Insert(TipoCarpetaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.tipocarpeta', 'idtc'), (SELECT MAX(idtc) FROM sgpt.tipocarpeta) + 1);");
                            sincronizar = true;
                        }                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new tipocarpeta
                        {
                            //idtc = modelo.id,
                            //idencargotc = modelo.idencargotc,
                            descripciontc = modelo.descripcion,
                            sistematc = false,
                            estadotc = "A",
                            //padreidtc=modelo.padreidtc,
                        };
                        _context.tipocarpetas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.id = tablaDestino.idtc;
                        modelo.sistema = tablaDestino.sistematc;
                        modelo.estado = tablaDestino.estadotc;
                        result = tablaDestino.idtc.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar \n" +e);
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
            int idtc = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    idtc = _context.tipocarpetas.Max(x => x.idtc) + 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n"+ e);
                throw;
            }
            return idtc;
        }

        //Devuelve el registro buscado con base al indice
        public static TipoCarpetaModelo Find(int id)
        {
            var entidadModelo = new TipoCarpetaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    tipocarpeta entidad = _context.tipocarpetas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.id = entidad.idtc;
                        entidadModelo.descripcion = entidad.descripciontc;
                        entidadModelo.sistema = entidad.sistematc;
                        entidadModelo.estado = entidad.estadotc;
                        entidadModelo.idencargotc = entidad.idencargotc;
                        entidadModelo.IsSelected = false;
                        entidadModelo.padreidtc = entidad.padreidtc;
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
                    string commandString = String.Format("DELETE FROM sgpt.tipocarpeta WHERE idtc={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                }
            }
        }

        public static TipoCarpetaModelo Find(string id)
        {
            var modelo = new TipoCarpetaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return modelo = null;
                    }
                    tipocarpeta entidad = _context.tipocarpetas.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                        modelo.id = entidad.idtc;
                        modelo.descripcion = entidad.descripciontc;
                        modelo.sistema = entidad.sistematc;
                        modelo.estado = entidad.estadotc;
                        modelo.idencargotc = entidad.idencargotc;
                        modelo.IsSelected = false;
                        modelo.padreidtc = entidad.padreidtc;
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
                    var modelo = new TipoCarpetaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    tipocarpeta entidad = _context.tipocarpetas.Find(id);
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
                    var modelo = new TipoCarpetaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.tipocarpetas
                            .Where(b => b.estadotc == "B")
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
                    tipocarpeta entidad = _context.tipocarpetas.Find(id);
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
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.tipocarpetas
                            .Where(b => b.estadotc == "B")
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

        public static void UpdateModelo(TipoCarpetaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    tipocarpeta entidad = _context.tipocarpetas.Find(modelo.id);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idtc = modelo.id;
                        entidad.descripciontc = modelo.descripcion;
                        entidad.sistematc = modelo.sistema;
                        //entidad.estadotc = modelo.estado;
                        entidad.idencargotc = modelo.idencargotc;
                        //entidad.padreidtc = modelo.padreidtc;
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

        public static bool UpdateModelo(TipoCarpetaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        tipocarpeta entidad = _context.tipocarpetas.Find(modelo.id);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            entidad.idtc = modelo.id;
                            entidad.descripciontc = modelo.descripcion;
                            entidad.sistematc = modelo.sistema;
                            entidad.estadotc = modelo.estado;
                            //entidad.idencargotc = modelo.idencargotc;
                            //entidad.padreidtc = modelo.padreidtc;
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
                        MessageBox.Show("Exception en actualizar \n"+ e);
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
                            string commandString = String.Format("UPDATE sgpt.tipocarpeta SET estadotc = 'B' WHERE idtc={0};", id);
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

        public static int DeleteBorradoLogico(ObservableCollection<TipoCarpetaModelo> lista)
        {
            int resultado = 0;
            ObservableCollection<int> resultados = new ObservableCollection<int>(); ;
            if (lista.Count > 0)
            {
                try
                {
                        foreach (TipoCarpetaModelo item in lista)
                        {
                        // commandString = String.Format("UPDATE sgpt.tipocarpeta SET estadotc = 'B' WHERE idtc={0};", item.id);
                        // commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                        //_context.SaveChanges();
                        switch (TipoCarpetaModelo.DeleteBorradoLogico(item))
                        {
                            case -2:
                                resultados.Add(2);
                                //Hay error en el procedimiento
                                break;
                            case -1:
                                resultados.Add(-1); 
                                break;
                            case 0:
                                resultados.Add(0);
                                break;
                            case 1:
                                resultados.Add(1); 
                                break;
                        }
                        }
                    if (resultados.Where(x => x == 1).Count() == lista.Count)
                    {
                        resultado = 1;
                    }
                    else
                    { 
                        if (resultados.Where(x => x == -2).Count() == lista.Count)
                            {
                                resultado = -2;//Los  valores la lista eran nulos
                            }
                            else
                            {
                            if (resultados.Where(x => x == -1).Count() == lista.Count)
                            {
                                resultado = -1;//Se dio errores en la eliminacion
                            }
                            else
                            {
                                resultado = 2;//Resultados mixtos
                            }
                            }
                    }
                    return resultado;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle \n " + e);
                    }
                    return -1;
                    throw;
                }
            }
            else
            {
                return resultado;
            }
        }

        public static int Delete(ObservableCollection<TipoCarpetaModelo> lista)
        {
            int resultado = 0;
            ObservableCollection<int> resultados = new ObservableCollection<int>(); ;
            if (lista.Count > 0)
            {
                try
                {
                    foreach (TipoCarpetaModelo item in lista)
                    {
                        // commandString = String.Format("UPDATE sgpt.tipocarpeta SET estadotc = 'B' WHERE idtc={0};", item.id);
                        // commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                        //_context.SaveChanges();
                        switch (TipoCarpetaModelo.Delete(item))
                        {
                            case -2:
                                resultados.Add(2);
                                //Hay error en el procedimiento
                                break;
                            case -1:
                                resultados.Add(-1);
                                break;
                            case 0:
                                resultados.Add(0);
                                break;
                            case 1:
                                resultados.Add(1);
                                break;
                        }
                    }
                    if (resultados.Where(x => x == 1).Count() == lista.Count)
                    {
                        resultado = 1;
                    }
                    else
                    {
                        if (resultados.Where(x => x == -2).Count() == lista.Count)
                        {
                            resultado = -2;//Los  valores la lista eran nulos
                        }
                        else
                        {
                            if (resultados.Where(x => x == -1).Count() == lista.Count)
                            {
                                resultado = -1;//Se dio errores en la eliminacion
                            }
                            else
                            {
                                resultado = 2;//Resultados mixtos
                            }
                        }
                    }
                    return resultado;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle \n " + e);
                    }
                    return -1;
                    throw;
                }
            }
            else
            {
                return resultado;
            }
        }
        //Pendiente el definir la forma de consulta y eliminacion
        public static int DeleteBorradoLogico(TipoCarpetaModelo modelo)
        {
            int result = 0;
            if (modelo!=null && modelo.id != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            switch (IndiceModelo.DeleteBorradoLogicoByRangeForTC(modelo.id))
                            {
                                case -1:
                                    //Caso de error
                                    result= - 2;//Error en la eliminacion de registros dependientes
                                  break;
                                case 0:
                                    //El id es un valor nulo
                                    result= 2;
                                    break;
                                case 1:
                                    //éxito en la operacion
                                    //Continuar
                                    string commandString = String.Format("UPDATE sgpt.tipocarpeta SET estadotc = 'B' WHERE idtc={0};", modelo.id);
                                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                    _context.Database.ExecuteSqlCommand(commandString);
                                    _context.SaveChanges();
                                    result = 1;
                                    break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del catalogo: \n" + e);
                        result = -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static int Delete(TipoCarpetaModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.id != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            switch (IndiceModelo.DeleteByRangeForTC(modelo.id))
                            {
                                case -1:
                                    //Caso de error
                                    result = -2;//Error en la eliminacion de registros dependientes
                                    break;
                                case 0:
                                    //El id es un valor nulo
                                    result = 2;
                                    break;
                                case 1:
                                    //éxito en la operacion
                                    //Continuar
                                    string commandString = String.Format("DELETE FROM sgpt.tipocarpeta WHERE idtc={0};", modelo.id);
                                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                    _context.Database.ExecuteSqlCommand(commandString);
                                    _context.SaveChanges();
                                    result = 1;
                                    break;
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del catalogo: \n" + e);
                        result = -1;
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
                            string commandString = String.Format("UPDATE sgpt.tipocarpeta SET estadotc = 'B' WHERE idtc={0};", id);
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
                            MessageBox.Show("Exception en borrar registro \n"+ e);
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
                    string commandString = String.Format("DELETE FROM sgpt.tipocarpeta WHERE idtc={0};", id);
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
                        string commandString = String.Format("DELETE FROM sgpt.tipocarpeta WHERE idtc={0};", id);
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
                        MessageBox.Show("Exception en borrar registro "+ e);
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
                            string commandString = String.Format("DELETE FROM sgpt.tipocarpeta WHERE idtc={0};", id);
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
                            MessageBox.Show("Exception en borrar registro \n" + e);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<TipoCarpetaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.tipocarpetas.Select(entidad =>
                     new TipoCarpetaModelo
                     {
                         id = entidad.idtc,
                         descripcion = entidad.descripciontc,
                         sistema = entidad.sistematc,
                         estado = entidad.estadotc,
                         idencargotc = entidad.idencargotc,
                         padreidtc=entidad.padreidtc,
                         IsSelected = false,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A" ).ToList();
                    ObservableCollection<TipoCarpetaModelo> temporal = new ObservableCollection<TipoCarpetaModelo>(lista.Where(x => x.idencargotc == null));
                    int i = 1;
                    foreach (TipoCarpetaModelo item in temporal)
                    {
                        item.idCorrelativo = i;
                        i++;
                    }
                    return temporal.ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n"+ e);
                throw;
            }
        }

        public static List<TipoCarpetaModelo> GetAllEncargos(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.tipocarpetas.Select(entidad =>
                     new TipoCarpetaModelo
                     {
                         id = entidad.idtc,
                         descripcion = entidad.descripciontc,
                         sistema = entidad.sistematc,
                         estado = entidad.estadotc,
                         idencargotc = entidad.idencargotc,
                         padreidtc = entidad.padreidtc,
                         isuso = entidad.isuso,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         IsSelected = false,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.id).Where(x => x.estado == "A" && x.idencargotc==idEncargo).ToList();
                    ObservableCollection<TipoCarpetaModelo> temporal = new ObservableCollection<TipoCarpetaModelo>(lista);
                    if(temporal.Count>0)
                    { 
                    int i = 1;
                    //Calcular los indices por item
                   ObservableCollection <index> listaDetalleHerramienta = IndiceModelo.GetAllCapaDatosByEncargo(idEncargo);
                    foreach (TipoCarpetaModelo item in temporal)
                    {
                        item.idCorrelativo = i;
                        i++;

                            #region Totales

                            item.itemsTotales = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 && x.idtcindice==item.id &&
                                                                              x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10).Count();
                            item.itemsTotalesReferenciados = listaDetalleHerramienta.Where(x => x.idteiindice != 1 && x.idteiindice != 2 && x.idteiindice != 3 && x.idtcindice == item.id &&
                                                                              x.idteiindice != 8 && x.idteiindice != 9 && x.idteiindice != 10 && x.referenciaindice != null).Count();
                            if (item.itemsTotales > 0)
                            {
                                item.IndiceItemsTotales =(decimal.Divide((decimal)item.itemsTotalesReferenciados,(decimal)item.itemsTotales)) * 100;
                                item.indiceCarpeta = item.IndiceItemsTotales;
                            }
                            else
                            {
                                item.IndiceItemsTotales = 0;
                                item.indiceCarpeta = item.IndiceItemsTotales;
                            }

                            #endregion

                        }
                    }
                    return temporal.ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                throw;
            }
        }


        public static List<TipoCarpetaModelo> GetAllByEncargosImportacion(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.tipocarpetas.Select(entidad =>
                     new TipoCarpetaModelo
                     {
                         id = entidad.idtc,
                         descripcion = entidad.descripciontc,
                         sistema = entidad.sistematc,
                         estado = entidad.estadotc,
                         idencargotc = entidad.idencargotc,
                         IsSelected = false,
                         padreidtc = entidad.padreidtc,
                         seleccionEntidad = false,
                         descripcionTipoAuditoriaPrograma = entidad.encargo.tiposauditoria.descripcionta,
                         razonsocialclientePrograma = entidad.encargo.cliente.razonsocialcliente,
                         fechainiperauditencargoPrograma = entidad.encargo.fechainiperauditencargo,
                         fechafinperauditencargoPrograma = entidad.encargo.fechafinperauditencargo,

                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.id).Where(x => x.estado == "A" && x.idencargotc != idEncargo && x.padreidtc !=null).ToList();
                    ObservableCollection<TipoCarpetaModelo> temporal = new ObservableCollection<TipoCarpetaModelo>(lista);
                    int i = 1;
                    foreach (TipoCarpetaModelo item in temporal)
                    {
                        item.idCorrelativo = i;
                        i++;
                    }
                    return temporal.ToList();
                    //La ordena por el ID notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                throw;
            }
        }
        public static List<tipocarpeta> GetAllCapaDatos()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.tipocarpeta WHERE estadotc = 'A' ORDER BY idtc;");
                    var lista = _context.tipocarpetas.SqlQuery(commandString).ToList();
                    //La ordena por el ID notar la notacion
                    ObservableCollection<tipocarpeta> temporal = new ObservableCollection<tipocarpeta>(lista.Where(x=>x.idencargotc==null));
                    //int i = 1;
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n "+ e);
                throw;
            }
        }

        public static List<tipocarpeta> GetAllCapaDatosSeleccion()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.tipocarpeta WHERE estadotc = 'A' ORDER BY idtc;");
                    var lista = _context.tipocarpetas.SqlQuery(commandString).ToList();
                    //La ordena por el ID notar la notacion
                    ObservableCollection<tipocarpeta> temporal = new ObservableCollection<tipocarpeta>(lista.Where(x => x.idencargotc == null));
                    tipocarpeta temporalElemento = new tipocarpeta
                    {
                        idtc = 0,
                        descripciontc = "Ninguna",
                        sistematc = true,
                        estadotc = "A",
                        idencargotc = 0,
                        padreidtc = 0,
                        //Lista filtrada de elementos que fueron eliminados
                    };
                    temporal.Insert(0,temporalElemento);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n " + e);
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
                    var entidad = (from p in _context.tipocarpetas
                                   where p.descripciontc.ToLower().Equals(busqueda)
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

        public TipoCarpetaModelo()
        {
            id = 0;
            descripcion = string.Empty;
            sistema = false;
            estado = "A";
            idencargotc = 0;
            IsSelected = false;
            indiceCarpeta=0;
            padreidtc = 0;
            IndiceItemsObligatorios = 0;
            IndiceItemsTotales = 0;
            IndiceItemsVoluntarios = 0;
            itemsObligatorios = 0;
            itemsVoluntarios = 0;
            itemsTotales = 0;
            itemsVoluntariosReferenciados = 0;
            itemsTotalesReferenciados = 0;
            itemsTotalesReferenciados = 0;
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
            usuarioModelo = null;
        }
        public TipoCarpetaModelo(EncargoModelo encargo)
        {
            id = 0;
            descripcion = string.Empty;
            sistema = false;
            estado = "A";
            idencargotc = encargo.idencargo;
            IsSelected = false;
            indiceCarpeta = 0;
            padreidtc = 0;
            IndiceItemsObligatorios = 0;
            IndiceItemsTotales = 0;
            IndiceItemsVoluntarios = 0;
            itemsObligatorios = 0;
            itemsVoluntarios = 0;
            itemsTotales = 0;
            itemsVoluntariosReferenciados = 0;
            itemsTotalesReferenciados = 0;
            itemsTotalesReferenciados = 0;
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
            usuarioModelo = null;
        }

        internal static int Reapertura(UniversalPT modelo)
        {
            int id = modelo.idOrigenUpt;
            int result = 0;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                           string commandString = String.Format("UPDATE sgpt.tipocarpeta SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                " etapapapel ='{6}' WHERE idtc={7};",
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                string.Empty,
                                "P",//Proceso
                            modelo.idOrigenUpt);
                            modelo.fechaaprobacion = string.Empty;
                            modelo.fechacierre = string.Empty;
                            modelo.fechasupervision = string.Empty;
                            modelo.usuarioaprobo = string.Empty;
                            modelo.usuariocerro = string.Empty;
                            modelo.usuariosuperviso = string.Empty;
                            modelo.etapapapel = "En proceso";
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en operacion de reapertura  \n" + e);
                        return -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static TipoCarpetaModelo  equivalencia(TipoCarpetaModelo destino, PlantillaIndiceModelo origen, EncargoModelo currentEncargo)
        {
            destino.id = 0;
            destino.descripcion = origen.descripciontc;
            destino.sistema = false;
            destino.estado = "A";
            destino.idencargotc = currentEncargo.idencargo;
            destino.IsSelected = false;
            destino.indiceCarpeta = 0;
            destino.padreidtc = origen.idtcpi;
            destino.isuso = 0;
            destino.guardadoBase = false;
            destino.IsSelected = false;
            destino.usuarioaprobo = string.Empty;
            destino.fechacierre = string.Empty;
            destino.fechasupervision = string.Empty;
            destino.fechaaprobacion = string.Empty;
            destino.usuariocerro = string.Empty;
            destino.usuariosuperviso = string.Empty;

            return destino;
        }


        public static int evaluarImportacion(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    int cantidadCarpetas = (from p in _context.tipocarpetas
                                   where p.idencargotc == idencargo && p.estadotc == "A" && p.padreidtc != null
                                   select p).Count();

                    //string commandString = String.Format("SELECT COUNT(*) FROM sgpt.tipocarpeta WHERE idencargotc={0} AND estadotc='A' AND padreidtc IS NOT NULL;", idencargo);
                    //var cantidadCarpetas = commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                    int cantidadCarpetasModelo = (from p in _context.tipocarpetas
                                            where p.estadotc == "A" && p.padreidtc == null
                                            select p).Count();
                    //commandString = String.Format("SELECT COUNT(*) FROM sgpt.tipocarpeta WHERE  estadotc='A' AND padreidtc IS NULL;");
                    //var cantidadCarpetasModelo = _context.tipocarpetas.SqlQuery(commandString);

                    if (cantidadCarpetas == cantidadCarpetasModelo)
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
               }
            }
            catch (Exception e)
            {
                MessageBox.Show("No pudo verificar para hacer la importacion \n" + e);
                return -1;
            }
        }


        public static TipoCarpetaModelo equivalencia(TipoCarpetaModelo destino, TipoCarpetaModelo origen)
        {

            destino.id = 0;
            destino.descripcion = origen.descripcion;
            destino.sistema = false;
            destino.estado = "A";
            destino.idencargotc = destino.idencargotc;
            destino.IsSelected = false;
            destino.indiceCarpeta = 0;
            destino.padreidtc = origen.padreidtc;
            destino.isuso = 0;
            destino.guardadoBase = false;
            destino.IsSelected = false;
            destino.usuarioaprobo = string.Empty;
            destino.fechacierre = string.Empty;
            destino.fechasupervision = string.Empty;
            destino.fechaaprobacion = string.Empty;
            destino.usuariocerro = string.Empty;
            destino.usuariosuperviso = string.Empty;
            return destino;
        }
        #endregion

        #region Cierre
        internal static int evaluarCerrar(TipoCarpetaModelo currentEntidad)
        {
            int respuesta = 0;
            try
            {
                if (currentEntidad.fechacierre == null || currentEntidad.fechacierre == string.Empty || string.IsNullOrWhiteSpace(currentEntidad.fechacierre))
                {
                    return 1;
                }
                else
                {
                    return respuesta;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception función: \n" + e);
                return -1;
            }
        }

        internal static int evaluarBorrar(TipoCarpetaModelo currentEntidad)
        {
            int respuesta = 0;
            try
            {
                if (currentEntidad.fechacierre == null || currentEntidad.fechacierre == string.Empty || string.IsNullOrWhiteSpace(currentEntidad.fechacierre))
                {
                    return 1;
                }
                else
                {
                    return respuesta;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception función: \n" + e);
                return -1;
            }
        }

         internal static int UpdateCierre(TipoCarpetaModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.id;
            int result = 0;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "TIPOCARPETA", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.tipocarpeta SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}' WHERE idtc = {3};",
                                usuarioModelo.inicialesusuario,
                                modelo.fechacierre,
                                EtapaEncargoModelo.seleccionEtapaIniciales(4),
                                id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en operacion de registro  \n" + e);
                        return -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }

        }

  
        internal static int UpdateSupervision(TipoCarpetaModelo modelo)
        {
            int id = modelo.id;
            int result = 0;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "TIPOCARPETA", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.tipocarpeta SET usuariosuperviso = '{0}',fechasupervision = '{1}', etapapapel='{2}' WHERE idtc = {3};",
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechasupervision,
                                EtapaEncargoModelo.seleccionEtapaIniciales(3),
                                id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en operacion de  registro  \n" + e);
                        return -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }

        }

        internal static int UpdateAprobacion(TipoCarpetaModelo modelo)
        {
            int id = modelo.id;
            int result = 0;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "TIPOCARPETA", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.tipocarpeta SET usuarioaprobo = '{0}',fechaaprobacion = '{1}', etapapapel='{2}' WHERE idtc = {3};",
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechaaprobacion,
                                EtapaEncargoModelo.seleccionEtapaIniciales(6),
                                id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en operacion de  registro  \n" + e);
                        return -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }

        }

        internal static int UpdateAprobacionSupervision(TipoCarpetaModelo modelo)
        {
            int id = modelo.id;
            int result = 0;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "TIPOCARPETA", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }
                            temporal = new BitacoraModelo(modelo, "TIPOCARPETA", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.tipocarpeta SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}' , etapapapel='{4}' WHERE idtc = {5};",
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechaaprobacion,//Se utiliza la misma fecha
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechaaprobacion, //Se utiliza la misma fecha
                                EtapaEncargoModelo.seleccionEtapaIniciales(6),
                                id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            result = 1;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en operacion de  registro  \n" + e);
                        return -1;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }

        }


        #endregion
    }

}
