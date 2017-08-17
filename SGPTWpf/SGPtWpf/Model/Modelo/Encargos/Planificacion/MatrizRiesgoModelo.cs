using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
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
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class MatrizRiesgoModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties
        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }
        public static bool sincronizar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idmr
        {
            get { return GetValue(() => idmr); }
            set { SetValue(() => idmr, value); }
        }

        //Identifica el  tipo de elemento contable
        public int? idindice
        {
            get { return GetValue(() => idindice); }
            set { SetValue(() => idindice, value); }
        }

        //Vincula con el sistema contable asociado y asu vez con  el encargo
        public int? idpapeles
        {
            get { return GetValue(() => idpapeles); }
            set { SetValue(() => idpapeles, value); }
        }

        //Encargo al  que corresponde la evaluacion
        public int? idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }

        //Balance del que se toma la informacion financiera
        public int? idbalance
        {
            get { return GetValue(() => idbalance); }
            set { SetValue(() => idbalance, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechasistemamr
        {
            get { return GetValue(() => fechasistemamr); }
            set { SetValue(() => fechasistemamr, value); }
        }
        //Codigo de la cuenta contable
        [DisplayName("Fecha de evaluacion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
         Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
         ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        //Fecha a la que corresponde la informacion financiera de los saldos finales
        public string fechaevaluacionmr
        {
            get { return GetValue(() => fechaevaluacionmr); }
            set { SetValue(() => fechaevaluacionmr, value); }
        }

        //Permite la gestión del borrado lógico de los elementos identificándose por A) Activo, B) Borrado
        public string estadomr
        {
            get { return GetValue(() => estadomr); }
            set { SetValue(() => estadomr, value); }
        }

        //Almacena la referencia para el  papel de  trabajo
        [DisplayName("Referencia de la  evaluación")]
        [Required(ErrorMessage = "Debe ingresar la referencia del documento")]
        [MaxLength(20, ErrorMessage = "No debe de exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string referenciamr 
        {
            get { return GetValue(() => referenciamr ); }
            set { SetValue(() => referenciamr , value); }
        }

        //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
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

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }

        public string usuariocreo
        {
            get { return GetValue(() => usuariocreo); }
            set { SetValue(() => usuariocreo, value); }
        }
        public string inicialesusuariosuperviso
        {
            get { return GetValue(() => inicialesusuariosuperviso); }
            set { SetValue(() => inicialesusuariosuperviso, value); }
        }
        public string inicialesusuariocerro
        {
            get { return GetValue(() => inicialesusuariocerro); }
            set { SetValue(() => inicialesusuariocerro, value); }
        }
        #endregion

        #region propiedades para listas
        public string idnitcliente //Tomada de sistema contable
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }
        #region Propiedades de presentacion

        public string fechabalancebalance
        {
            get { return GetValue(() => fechabalancebalance); }
            set { SetValue(() => fechabalancebalance, value); }
        }
        public string descripcioncb
        {
            get { return GetValue(() => descripcioncb); }
            set { SetValue(() => descripcioncb, value); }
        }


        //Clase de balance
        public string periodicidadperiodos
        {
            get { return GetValue(() => periodicidadperiodos); }
            set { SetValue(() => periodicidadperiodos, value); }
        }

        #endregion
        #endregion

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
            get { return GetValue(() => fechacierre ); }
            set { SetValue(() => fechacierre , value); }
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

        #endregion

        #region colecciones virtuales

        public virtual BitacoraModelo bitacoraModelo
        {
            get { return GetValue(() => bitacoraModelo); }
            set { SetValue(() => bitacoraModelo, value); }
        }

        public virtual MatrizRiesgoModelo matrizRiesgoModelo
        {
            get { return GetValue(() => matrizRiesgoModelo); }
            set { SetValue(() => matrizRiesgoModelo, value); }
        }

        public virtual matrizriesgo matrizRiesgo
        {
            get { return GetValue(() => matrizRiesgo); }
            set { SetValue(() => matrizRiesgo, value); }
        }
        public virtual PeriodoModelo periodoModelo
        {
            get { return GetValue(() => periodoModelo); }
            set { SetValue(() => periodoModelo, value); }
        }
        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        //Permite evitar duplicacion el critero periodicidad, clase balance, fecha 
        public ObservableCollection<MatrizRiesgoModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        public ObservableCollection<BitacoraModelo> listaBitacora
        {
            get { return GetValue(() => listaBitacora); }
            set { SetValue(() => listaBitacora, value); }
        }

        public ObservableCollection<matrizriesgo> listamatrizRiesgo
        {
            get { return GetValue(() => listamatrizRiesgo); }
            set { SetValue(() => listamatrizRiesgo, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(MatrizRiesgoModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.matrizriesgos', 'idmr'), (SELECT MAX(idmr) FROM sgpt.matrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new matrizriesgo
                        {
                            //idmr = modelo.idmr,
                            idindice = modelo.idindice,
                            
                            idencargo = modelo.idencargo,
                            idbalance = modelo.idbalance,
                            fechasistemamr = modelo.fechasistemamr,
                            fechaevaluacionmr = modelo.fechaevaluacionmr,
                            estadomr = modelo.estadomr,
                            referenciamr = modelo.referenciamr,
                            isuso = modelo.isuso,
                            usuarioaprobo = modelo.usuarioaprobo,
                            fechacierre = modelo.fechacierre,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            usuariocerro = modelo.usuariocerro,
                            usuariosuperviso = modelo.usuariosuperviso,
                        };
                        _context.matrizriesgos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idmr = tablaDestino.idmr;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            //modelo.listaBitacora.Add(temporal);
                        }

                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n " + e);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool InsertCapaDatos(matrizriesgo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.matrizriesgos', 'idmr'), (SELECT MAX(idmr) FROM sgpt.matrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.matrizriesgos.Add(modelo);
                        _context.SaveChanges();
                        modelo.idmr = modelo.idmr;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de balance: \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        public static int Insert(MatrizRiesgoModelo modelo)
        {
            //-1 Fallo en la insercion
            //1 éxito en la operacion
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.matrizriesgos', 'idmr'), (SELECT MAX(idmr) FROM sgpt.matrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new matrizriesgo
                        {
                            //idmr = modelo.idmr,
                            idindice = modelo.idindice,
                            
                            idencargo = modelo.idencargo,
                            idbalance = modelo.idbalance,
                            fechasistemamr = modelo.fechasistemamr,
                            fechaevaluacionmr = modelo.fechaevaluacionmr,
                            estadomr = modelo.estadomr,
                            referenciamr = modelo.referenciamr,
                            isuso = modelo.isuso,
                            usuarioaprobo = modelo.usuarioaprobo,
                            fechacierre = modelo.fechacierre,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            usuariocerro = modelo.usuariocerro,
                            usuariosuperviso = modelo.usuariosuperviso,

                        };
                        _context.matrizriesgos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idmr = tablaDestino.idmr;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            //modelo.listaBitacora.Add(temporal);
                        }
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return -1;//Error en la inserción
                }
            }
            else
            {
                return result;
            }
        }


        public static int InsertByRange(ObservableCollection<matrizriesgo> lista)
        {
            int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.matrizriesgos', 'idmr'), (SELECT MAX(idmr) FROM sgpt.matrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        _context.matrizriesgos.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return -1;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static MatrizRiesgoModelo Find(int id)
        {
            var entidad = new MatrizRiesgoModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    matrizriesgo modelo = _context.matrizriesgos.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idmr = modelo.idmr;
                        entidad.idindice = modelo.idindice;
                        
                        entidad.idencargo = modelo.idencargo;
                        entidad.idbalance = modelo.idbalance;
                        entidad.fechasistemamr = modelo.fechasistemamr;
                        entidad.fechaevaluacionmr = modelo.fechaevaluacionmr;
                        entidad.estadomr = modelo.estadomr;
                        entidad.referenciamr = modelo.referenciamr;
                        entidad.isuso = modelo.isuso;
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;

                    }
                }
                if (entidad == null)
                    return entidad;
                else
                {
                    return entidad;
                }
            }
            else
            {
                return entidad = null;
            }
        }

        #region Metodos para string 

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new MatrizRiesgoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    matrizriesgo entidad = _context.matrizriesgos.Find(id);
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
                    var modelo = new MatrizRiesgoModelo();
                    matrizriesgo entidad = _context.matrizriesgos.Find(id);
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
        public static bool FindPKEliminados(string id)
        {
            if (!(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new MatrizRiesgoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.matrizriesgos
                            .Where(b => b.estadomr == "B")
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
                    matrizriesgo entidad = _context.matrizriesgos.Find(id);
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

        public static void UpdateModelo(MatrizRiesgoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    matrizriesgo entidad = _context.matrizriesgos.Find(modelo.idmr);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idmr = modelo.idmr;
                        entidad.idindice = modelo.idindice;
                        
                        entidad.idencargo = modelo.idencargo;
                        entidad.idbalance = modelo.idbalance;
                        entidad.fechasistemamr = modelo.fechasistemamr;
                        entidad.fechaevaluacionmr = modelo.fechaevaluacionmr;
                        entidad.estadomr = modelo.estadomr;
                        entidad.referenciamr = modelo.referenciamr;
                        entidad.isuso = modelo.isuso;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;

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

        public static bool UpdateModelo(MatrizRiesgoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambiar = false;
                        string cambioTexto = "";
                        matrizriesgo entidad = _context.matrizriesgos.Find(modelo.idmr);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.idmr = modelo.idmr; no puede cambiar
                            //if (entidad.idmr != modelo.idmr) { cambiar = true; }
                            if (entidad.idindice != modelo.idindice) { cambiar = true; }
                            if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            //if (entidad.idbalance != modelo.idbalance) { cambiar = true; }
                            //if (entidad.fechasistemamr != modelo.fechasistemamr) { cambiar = true; }
                            if (entidad.fechaevaluacionmr != modelo.fechaevaluacionmr) { cambiar = true; }
                            //if (entidad.estadomr != modelo.estadomr) { cambiar = true; }
                            if (entidad.referenciamr != modelo.referenciamr) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }

                            if (cambiar)
                            {
                                //entidad.idmr = modelo.idmr;
                                entidad.idindice = modelo.idindice;
                                
                                entidad.idencargo = modelo.idencargo;
                                entidad.idbalance = modelo.idbalance;
                                entidad.fechasistemamr = modelo.fechasistemamr;
                                entidad.fechaevaluacionmr = modelo.fechaevaluacionmr;
                                entidad.estadomr = modelo.estadomr;
                                entidad.referenciamr = modelo.referenciamr;
                                entidad.isuso = modelo.isuso;
                                entidad.usuarioaprobo = modelo.usuarioaprobo;
                                entidad.fechacierre = modelo.fechacierre;
                                entidad.fechasupervision = modelo.fechasupervision;
                                entidad.fechaaprobacion = modelo.fechaaprobacion;
                                entidad.usuariocerro = modelo.usuariocerro;
                                entidad.usuariosuperviso = modelo.usuariosuperviso;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = cambioTexto;
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                   // modelo.listaBitacora.Add(temporal);
                                }
                            }
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id, MatrizRiesgoModelo modelo)
        {
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(id);//Borra todas las referencias dentro  de bitacora
                                                                                  //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                               // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET estadomr = 'B' WHERE idmr={0};", id);
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
                            MessageBox.Show("Exception en borrar registro  \n" + e);
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

        public static bool Delete(ObservableCollection<MatrizRiesgoModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        matrizriesgo entidadTemporal = new matrizriesgo();
                        string commandString = string.Empty;
                        foreach (MatrizRiesgoModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idmr);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.matrizriesgos WHERE idmr={0};", item.idmr);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return false;
                throw;
            }
        }
        public static void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id, "MATRIZRIESGOS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.matrizriesgos WHERE idmr={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
            }
        }

        public static void DeleteByRange(ObservableCollection<matrizriesgo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.matrizriesgos.RemoveRange(lista);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del rango \n" + e);
            }
        }
        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id);//Borra todas las referencias dentro  de bitacora

                        //Borrar el detalle del balance

                        //DetalleMatrizRiesgoModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.matrizriesgos WHERE idmr={0};", id);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle \n" + e);
                }
                return false;
                throw;
            }
        }


        public static bool DeleteBorradoLogico(ObservableCollection<MatrizRiesgoModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    matrizriesgo entidadTemporal = new matrizriesgo();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (MatrizRiesgoModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idmr);//Borra todas las referencias dentro  de bitacora
                                                                                              //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idmr);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.matrizriesgos SET estadomr = 'B' WHERE idmr={0};", item.idmr);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        _context.SaveChanges();
                    }

                    return true;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                    }
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<matrizriesgo> lista, int idmr)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.matrizriesgos SET estadomr = 'B' WHERE idmr = {0};", idmr);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        //Se elimina todo el contenido
                        _context.SaveChanges();
                    }
                    return true;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                    }
                    return false;
                    throw;
                }
            }
            else
            {
                return true;
            }
        }

        //Conversion explicita
        public static explicit operator matrizriesgo(MatrizRiesgoModelo modelo)  // explicit byte to digit conversion operator
        {
            matrizriesgo entidad = new matrizriesgo();
            entidad.idmr = modelo.idmr;
            entidad.idindice = modelo.idindice;
            
            entidad.fechaevaluacionmr = modelo.fechaevaluacionmr;
            entidad.fechasistemamr = modelo.fechasistemamr;
            entidad.estadomr = modelo.estadomr;
            entidad.idencargo = modelo.idencargo;
            entidad.usuarioaprobo = modelo.usuarioaprobo;
            entidad.fechacierre = modelo.fechacierre;
            entidad.fechasupervision = modelo.fechasupervision;
            entidad.fechaaprobacion = modelo.fechaaprobacion;
            entidad.usuariocerro = modelo.usuariocerro;
            entidad.usuariosuperviso = modelo.usuariosuperviso;

            // explicit conversion
            return entidad;
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

                            //Debe remover el  detalle del balance para no  dejar huerfanos

                            //Verificar que  no existan registros relacionados

                            string commandString = String.Format("DELETE FROM sgpt.matrizriesgos WHERE idmr={0};", id);
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

        public static List<MatrizRiesgoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.matrizriesgos.Select(entidad =>
                     new MatrizRiesgoModelo
                     {
                         idmr = entidad.idmr,
                         idindice = entidad.idindice,
                         
                         idencargo = entidad.idencargo,
                         idbalance = entidad.idbalance,
                         fechasistemamr = entidad.fechasistemamr,
                         fechaevaluacionmr = entidad.fechaevaluacionmr,
                         estadomr = entidad.estadomr,
                         referenciamr = entidad.referenciamr,
                         isuso = entidad.isuso,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,
                         fechabalancebalance=entidad.balance.fechabalancebalance,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechaevaluacionmr).Where(x => x.estadomr == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    var listaBitacora = BitacoraModelo.GetAllByTabla("MATRIZRIESGOS");
                    if (listaBitacora.Count > 0)
                    {
                        foreach (MatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitara
                            //try
                            //{
                            //    item.usuariocreo = listaBitacora.SingleOrDefault(x => x.idtransaccionbitacora == item.idmr && x.accionbitacora.Contains("Creacion")).inicialesusuariobitacora;
                            //    item.inicialesusuariosuperviso = listaBitacora.SingleOrDefault(x => x.idtransaccionbitacora == item.idmr && x.accionbitacora.Contains("Superviso")).inicialesusuariobitacora;
                            //    item.inicialesusuariocerro = listaBitacora.SingleOrDefault(x => x.idtransaccionbitacora == item.idmr && x.accionbitacora.Contains("Aprobo")).inicialesusuariobitacora;
                            //}
                            //catch (Exception e)
                            //{
                            //    item.usuariocreo = string.Empty;
                            //    item.inicialesusuariosuperviso = string.Empty;
                            //    item.inicialesusuariocerro = string.Empty;
                            //    MessageBox.Show("Exception en elaboracion del detalle \n" + e);
                            //}
                        }
                    }
                    else
                    {
                        foreach (MatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitara
                            item.usuariocreo = string.Empty;
                            item.inicialesusuariosuperviso = string.Empty;
                            item.inicialesusuariocerro = string.Empty;
                        }
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de balances \n" + e);
                }
                return null;
            }
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
                           string   commandString = String.Format("UPDATE sgpt.matrizriesgos SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                    "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                    " etapapapel ='{6}' WHERE idmr={7};",
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

        internal static int UpdateModificacion(MatrizRiesgoModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idmr;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET fechaevaluacionmr = '{0}' WHERE idmr = {1};",
                                modelo.fechaevaluacionmr,
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
                            MessageBox.Show("Exception en borrar registro  \n" + e);
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
        internal static int UpdateCierre(MatrizRiesgoModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idmr;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET usuariocerro = '{0}',fechacierre = '{1}' WHERE idmr = {2};",
                                usuarioModelo.inicialesusuario,
                                modelo.fechacierre, 
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

        internal static int UpdateReferencia(MatrizRiesgoModelo modelo)
        {
            int id = modelo.idmr;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET referenciamr = '{0}' WHERE idmr={1};", modelo.referenciamr, id);
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
                            MessageBox.Show("Exception en operacion registro  \n" + e);
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

        internal static int UpdateSupervision(MatrizRiesgoModelo modelo)
        {
            int id = modelo.idmr;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET usuariosuperviso = '{0}',fechasupervision = '{1}' WHERE idmr = {2};",
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechasupervision,
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

        internal static int UpdateAprobacion(MatrizRiesgoModelo modelo)
        {
            int id = modelo.idmr;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET usuarioaprobo = '{0}',fechaaprobacion = '{1}' WHERE idmr = {2};",
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechaaprobacion,
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

        internal static int UpdateAprobacionSupervision(MatrizRiesgoModelo modelo)
        {
            int id = modelo.idmr;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }
                            temporal = new BitacoraModelo(modelo, "MATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.matrizriesgos SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}' WHERE idmr = {4};",
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechaaprobacion,//Se utiliza la misma fecha
                                modelo.usuarioModelo.inicialesusuario,
                                modelo.fechaaprobacion, //Se utiliza la misma fecha
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

        public static List<MatrizRiesgoModelo> GetAll(EncargoModelo encargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.matrizriesgos.Select(entidad =>
                     new MatrizRiesgoModelo
                     {
                         idmr = entidad.idmr,
                         idindice = entidad.idindice,
                         
                         idencargo = entidad.idencargo,
                         idbalance = entidad.idbalance,
                         fechasistemamr = entidad.fechasistemamr,
                         fechaevaluacionmr = entidad.fechaevaluacionmr,
                         estadomr = entidad.estadomr,
                         referenciamr = entidad.referenciamr,
                         isuso = entidad.isuso,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,
                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         usuarioaprobo = entidad.usuarioaprobo,
                         fechacierre = entidad.fechacierre,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         usuariocerro = entidad.usuariocerro,
                         usuariosuperviso = entidad.usuariosuperviso,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.fechaevaluacionmr).Where(x => x.estadomr == "A" && x.idencargo==encargo.idencargo).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    var listaBitacora = BitacoraModelo.GetAllByTabla("MATRIZRIESGOS");
                    if (listaBitacora.Count > 0)
                    {
                        string etapaBuscada = EtapaEncargoModelo.seleccionEtapa(1);//Creacion
                        foreach (MatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            
                            //Buscar en bitara
                            try
                            {
                                item.usuariocreo = listaBitacora.Single(x => x.idtransaccionbitacora == item.idmr && x.accionbitacora.Contains(etapaBuscada)).inicialesusuariobitacora;
                            }
                            catch (Exception e)
                            {
                                item.usuariocreo = string.Empty;
                                MessageBox.Show("Exception en elaboracion del detalle \n" + e);
                            }
                            }
                    }
                    else
                    {
                        foreach (MatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitara
                            item.usuariocreo = string.Empty;
                            item.inicialesusuariosuperviso = string.Empty;
                            item.inicialesusuariocerro = string.Empty;
                        }
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
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

        internal static MatrizRiesgoModelo GetRegistro(int idgenericoindice)
        {
            var entidad = new MatrizRiesgoModelo();
            if (!(idgenericoindice == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    matrizriesgo modelo = _context.matrizriesgos.Find(idgenericoindice);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idmr = modelo.idmr;
                        entidad.idindice = modelo.idindice;
                        
                        entidad.idencargo = modelo.idencargo;
                        entidad.idbalance = modelo.idbalance;
                        entidad.fechasistemamr = modelo.fechasistemamr;
                        entidad.fechaevaluacionmr = modelo.fechaevaluacionmr;
                        entidad.estadomr = modelo.estadomr;
                        entidad.referenciamr = modelo.referenciamr;
                        entidad.isuso = modelo.isuso;
                        entidad.descripcioncb = modelo.balance.clasesbalance.descripcioncb;
                        entidad.periodicidadperiodos = modelo.balance.periodo.periodicidadperiodos;
                        entidad.fechabalancebalance = modelo.balance.fechabalancebalance;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        int i = 1;
                        var listaBitacora = BitacoraModelo.GetAllByTabla("MATRIZRIESGOS");
                        if (listaBitacora.Count > 0)
                        {
                            string etapaBuscada = EtapaEncargoModelo.seleccionEtapa(1);//Creacion

                            entidad.idCorrelativo = i;
                            i++;
                            entidad.guardadoBase = true;
                            entidad.IsSelected = false;

                            //Buscar en bitara
                            try
                            {
                                entidad.usuariocreo = listaBitacora.Single(x => x.idtransaccionbitacora == entidad.idmr && x.accionbitacora.Contains(etapaBuscada)).inicialesusuariobitacora;
                            }
                            catch (Exception e)
                            {
                                entidad.usuariocreo = string.Empty;
                                MessageBox.Show("Exception en elaboracion del detalle \n" + e);
                            }
                        }
                    }
                }

                if (entidad == null)
                    return entidad;
                else
                {
                    return entidad;
                }
            }
            else
            {
                return entidad = null;
            }
        }

        public static ObservableCollection<matrizriesgo> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.matrizriesgos.Where(entidad => (entidad.idencargo == idencargo && entidad.estadomr == "A"));
                    ObservableCollection<matrizriesgo> temporal = new ObservableCollection<matrizriesgo>(lista);
                    return temporal;
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

        public static bool DeleteByIdProgramaRange(int? idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.matrizriesgos.Where(x => x.estadomr == "A" && x.idpapeles == idpapeles);
                    var lista = (from p in _context.matrizriesgos
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.matrizriesgos.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista \n " + e);
                return false;
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
                    elementos = _context.matrizriesgos.Where(x => x.idencargo == id && x.estadomr == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: \n" + e);
                return elementos;
            }
        }

  
        #endregion

        public MatrizRiesgoModelo()
        {
            idmr = 0;
            idindice =null;
            idpapeles = null;
            idencargo =null ;
            idbalance = null ;
            fechasistemamr = MetodosModelo.homologacionFecha();
            fechaevaluacionmr = MetodosModelo.homologacionFecha();
            estadomr = "A";
            referenciamr = string.Empty;
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            idencargo = 0;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;

        }
        public MatrizRiesgoModelo(EncargoModelo encargo)
        {
            idmr = 0;
            idindice = null;
            idpapeles = null;
            idencargo = encargo.idencargo;
            idbalance = null;
            fechasistemamr = MetodosModelo.homologacionFecha();
            fechaevaluacionmr = MetodosModelo.homologacionFecha();
            estadomr = "A";
            referenciamr = string.Empty;
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            idencargo = 0;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;

        }

        internal static int evaluarCerrar(MatrizRiesgoModelo currentEntidad)
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

        internal static int evaluarBorrar(MatrizRiesgoModelo currentEntidad)
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

        public MatrizRiesgoModelo(EncargoModelo encargo,UsuarioModelo usuario)
        {
            idmr = 0;
            idindice = null;
            idpapeles = null;
            idencargo = encargo.idencargo;
            idbalance = null;
            fechasistemamr = MetodosModelo.homologacionFecha();
            fechaevaluacionmr = MetodosModelo.homologacionFecha();
            estadomr = "A";
            referenciamr = string.Empty;
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            usuarioModelo = usuario;
            usuariocreo = usuario.inicialesusuario;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
        }


    }

}
