using CapaDatos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion;
using SGPTWpf.SGPtWpf.Support;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public partial class EncargoModelo : UIBaseAlterna, IDataErrorInfo
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

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DisplayName("Id de encargo")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int idencargo
        //{
        //    get { return GetValue(() => idencargo); }
        //    set { SetValue(() => idencargo, value); }
        //}
        #region idencargo
        public int _idencargo;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idencargo
        {
            get { return _idencargo; }
            set { _idencargo = value; }
        }

        #endregion
        public string idnitcliente
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }

        public int idta
        {
            get { return GetValue(() => idta); }
            set { SetValue(() => idta, value); }
        }



        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechacreadoencargo
        {
            get { return GetValue(() => fechacreadoencargo); }
            set { SetValue(() => fechacreadoencargo, value); }
        }

        //Permite determinar si es un encargo recurrente (segunda o mas veces) que se hace el encargo del cliente.
        //True=El encargo es recurrente, False= Primera vez que se hace la auditoria. 
        //En el caso de las auditorias recurrentes permite utilizar archivos del encargo inmediato anterior.
        public bool tipoclienteencargo
        {
            get { return GetValue(() => tipoclienteencargo); }
            set { SetValue(() => tipoclienteencargo, value); }
        }
        //Permite gestionar las diferentes etapas de los archivos que componen las auditorias. 
        //Se distinguen las siguientes etapas; I=inicial, P=En proceso, R=Revisado, C=Cerrado. 
        //Un encargo con estado = "Cerrado" no se debe modificar ningun elemento asociado a el.
        public string etapaencargo
        {
            get { return GetValue(() => etapaencargo); }
            set { SetValue(() => etapaencargo, value); }
        }

        [DisplayName("Costo de ejecucion")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0,50000000,ErrorMessage = "El mínimo de 0")]
        public decimal? costoejecucionencargo
        {
            get { return GetValue(() => costoejecucionencargo); }
            set { SetValue(() => costoejecucionencargo, value); }
        }
        [DisplayName("Honorarios")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(0, 50000000, ErrorMessage = "El mínimo de 0")]
        public decimal? honorariosencargo
        {
            get { return GetValue(() => honorariosencargo); }
            set { SetValue(() => honorariosencargo, value); }
        }

        [DisplayName("Fecha de inicinon de auditoría")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/2010", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechainiperauditencargo
        {
            get { return GetValue(() => fechainiperauditencargo); }
            set { SetValue(() => fechainiperauditencargo, value); }
        }

        [DisplayName("Fecha de fin de auditoría")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/2010", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechafinperauditencargo
        {
            get { return GetValue(() => fechafinperauditencargo); }
            set { SetValue(() => fechafinperauditencargo, value); }
        }

        public string estadoencargo
        {
            get { return GetValue(() => estadoencargo); }
            set { SetValue(() => estadoencargo, value); }
        }

        // Entidades relacionadas


        public virtual TipoAuditoriaModelo tipoAuditoriaModelo
        {
            get { return GetValue(() => tipoAuditoriaModelo); }
            set { SetValue(() => tipoAuditoriaModelo, value); }
        }

        public virtual EtapaEncargoModelo etapaEncargoModelo
        {
            get { return GetValue(() => etapaEncargoModelo); }
            set { SetValue(() => etapaEncargoModelo, value); }
        }
        public virtual TipoClienteEncargoModelo tipoClienteEncargoModelo
        {
            get { return GetValue(() => tipoClienteEncargoModelo); }
            set { SetValue(() => tipoClienteEncargoModelo, value); }
        }

        public virtual ClienteModelo clienteModelo
        {
            get { return GetValue(() => clienteModelo); }
            set { SetValue(() => clienteModelo, value); }
        }
        public string referenciamr
        {
            get { return GetValue(() => referenciamr); }
            set { SetValue(() => referenciamr, value); }
        }

        #endregion

        #region propiedades de usuario


        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }

        public int? idsc
        {
            get { return GetValue(() => idsc); }
            set { SetValue(() => idsc, value); }
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

        #endregion

        #region Propiedades de presentacion

        public string razonsocialcliente
        {
            get { return GetValue(() => razonsocialcliente); }
            set { SetValue(() => razonsocialcliente, value); }
        }

        public string descripcionEtapaEncargo
        {
            get { return GetValue(() => descripcionEtapaEncargo); }
            set { SetValue(() => descripcionEtapaEncargo, value); }
        }
        public string descripcionTipoClienteEncargo
        {
            get { return GetValue(() => descripcionTipoClienteEncargo); }
            set { SetValue(() => descripcionTipoClienteEncargo, value); }
        }
        public string descripcionTipoAuditoria
        {
            get { return GetValue(() => descripcionTipoAuditoria); }
            set { SetValue(() => descripcionTipoAuditoria, value); }
        }

        public bool seleccionEncargo
        {
            get { return GetValue(() => seleccionEncargo); }
            set { SetValue(() => seleccionEncargo, value); }
        }
        public virtual SistemaContableModelo sistemaContableModelo
        {
            get { return GetValue(() => sistemaContableModelo); }
            set { SetValue(() => sistemaContableModelo, value); }
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
        public ObservableCollection<EncargoModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        public ObservableCollection<BitacoraModelo> listaBitacora
        {
            get { return GetValue(() => listaBitacora); }
            set { SetValue(() => listaBitacora, value); }
        }
        #endregion

        #region Public Model Methods


        public static bool Insert(EncargoModelo modelo)
        {
            throw new NotImplementedException();
        }

        public static bool Insert(EncargoModelo modelo, bool valor)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.encargos', 'idencargo'), (SELECT MAX(idencargo) FROM sgpt.encargos) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new encargo
                        {
                            //idencargo = modelo.idencargo,
                            idnitcliente = modelo.idnitcliente,
                            idta = modelo.idta,
                            fechacreadoencargo = modelo.fechacreadoencargo,
                            tipoclienteencargo = modelo.tipoclienteencargo,
                            etapaencargo = modelo.etapaencargo,
                            costoejecucionencargo = modelo.costoejecucionencargo,
                            honorariosencargo = modelo.honorariosencargo,
                            fechainiperauditencargo = modelo.fechainiperauditencargo,
                            fechafinperauditencargo = modelo.fechafinperauditencargo,
                            estadoencargo = modelo.estadoencargo,
                        };
                        _context.encargos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idencargo = tablaDestino.idencargo;
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
        public static EncargoModelo Find(int id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static EncargoModelo Find(string id)
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
        //Para realizar busquedas de texto
        public static List<EncargoModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                var listado= _context.encargos.Select(entidad =>
                new EncargoModelo
                {
                    idencargo = entidad.idencargo,
                    idnitcliente = entidad.idnitcliente,
                    idta = entidad.idta,
                    fechacreadoencargo = entidad.fechacreadoencargo,
                    tipoclienteencargo = (bool) entidad.tipoclienteencargo,
                    etapaencargo = entidad.etapaencargo,
                    costoejecucionencargo = entidad.costoejecucionencargo,
                    honorariosencargo = entidad.honorariosencargo,
                    fechainiperauditencargo = entidad.fechainiperauditencargo,
                    fechafinperauditencargo = entidad.fechafinperauditencargo,
                    estadoencargo = entidad.estadoencargo,
                    tipoAuditoriaModelo = new TipoAuditoriaModelo
                    {
                        id = entidad.tiposauditoria.idta,
                        descripcion = entidad.tiposauditoria.descripcionta,
                        sistema = entidad.tiposauditoria.sistemata,
                        estado = entidad.tiposauditoria.estadota
                    },
                    descripcionTipoAuditoria=entidad.tiposauditoria.descripcionta,
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idencargo).Where(x => x.estadoencargo == "A").ToList();
                var listadoClientes = ClienteModelo.GetAll();
                foreach (EncargoModelo item in listado)
                {
                    item.razonsocialcliente = listadoClientes.Single(i => i.idnitcliente == item.idnitcliente).razonsocialcliente;
                    item.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(item.etapaencargo);
                    item.descripcionEtapaEncargo = item.etapaEncargoModelo.descripcionEtapaEncargo;
                    item.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(item.tipoclienteencargo);
                    item.descripcionTipoClienteEncargo = item.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;
                }
                return listado.ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            throw new NotImplementedException();
        }


        public static bool UpdateModelo(EncargoModelo modelo)
        {
            if (!(modelo == null))
            {
                if (modelo.etapaencargo != "C")
                {
                    using (_context = new SGPTEntidades())
                    {
                        encargo entidad = _context.encargos.Find(modelo.idencargo);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            bool guardar = false;
                            if (entidad.idta != modelo.idta)
                            {
                                guardar = true;
                            }
                            else
                            {
                                if (entidad.tipoclienteencargo != modelo.tipoclienteencargo)
                                {
                                    guardar = true;
                                }
                                else
                                {
                                    if (entidad.costoejecucionencargo != modelo.costoejecucionencargo)
                                    {
                                        guardar = true;
                                    }
                                    else
                                    {
                                        if (entidad.honorariosencargo != modelo.honorariosencargo)
                                        {
                                            guardar = true;
                                        }
                                        else
                                        {
                                            if (entidad.fechainiperauditencargo != modelo.fechainiperauditencargo)
                                            {
                                                guardar = true;
                                            }
                                            else
                                            {
                                                if (entidad.fechafinperauditencargo != modelo.fechafinperauditencargo)
                                                {
                                                    guardar = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (guardar)
                            {
                                //entidad.idencargo = modelo.idencargo,
                                //entidad.idnitcliente = modelo.idnitcliente;No puede modificarse el cliente
                                entidad.idta = modelo.idta;
                                //entidad.fechacreadoencargo = modelo.fechacreadoencargo;
                                entidad.tipoclienteencargo = modelo.tipoclienteencargo;
                                //entidad.etapaencargo = modelo.etapaencargo;
                                entidad.costoejecucionencargo = modelo.costoejecucionencargo;
                                entidad.honorariosencargo = modelo.honorariosencargo;
                                entidad.fechainiperauditencargo = modelo.fechainiperauditencargo;
                                entidad.fechafinperauditencargo = modelo.fechafinperauditencargo;
                                //entidad.estadoencargo = modelo.estadoencargo;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            return true;//No se guarda pero el proceso de evaluación se hizo
                        }

                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        public static bool CopiarModelo(EncargoModelo modelo)
        {
            throw new NotImplementedException();
        }
        //Pendiente el definir la forma de consulta y eliminacion

        public static bool DeleteBorradoLogico(EncargoModelo registro)
        {
            //id de encargo
            if ((registro != null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        int id = registro.idencargo;
                        //Borrado de asignaciones
                        var listaAsignaciones = AsignacionModelo.GetAll(id);
                        if (listaAsignaciones.Count > 0)
                        {
                            foreach (AsignacionModelo item in listaAsignaciones)
                            {
                                AsignacionModelo.DeleteBorradoLogico(item.idasignacion);
                            }
                        }
                        //Borrado de programas
                        var listaprogramaModelo = ProgramaModelo.GetAllByEncargo(id);
                        if (listaprogramaModelo.Count > 0)
                        {
                            foreach (ProgramaModelo item in listaprogramaModelo)
                            {
                                if (item.idthprograma == 1)
                                {
                                    ProgramaModelo.DeleteBorradoLogicoByPrograma(item.idprograma, true);
                                }
                                else
                                {
                                    ProgramaModelo.DeleteByDetalleCuestionario(item.idprograma, true);
                                }
                            }
                        }
                        //Borrado de indices
                        var listaIndiceModelo = IndiceModelo.GetAllCapaDatosByEncargo(id);
                        if (listaIndiceModelo.Count > 0)
                        {
                            foreach (index item in listaIndiceModelo)
                            {
                                IndiceModelo.DeleteBorradoLogico((int)item.idindice, true);
                            }
                        }
                        //Borrado de carpetas de indice
                        var listaCarpetasModelo = TipoCarpetaModelo.GetAllEncargos(id);
                        if (listaIndiceModelo.Count > 0)
                        {
                            foreach (TipoCarpetaModelo item in listaCarpetasModelo)
                            {
                                TipoCarpetaModelo.DeleteBorradoLogico((int)item.id, true);
                            }
                        }

                        //Borrado de balances
                        var sistemaContableItem = SistemaContableModelo.GetRegistroByIdEncargo(id);
                        if (sistemaContableItem != null)
                        {
                            var listaBalancesModelo = BalanceModelo.GetAllByIsSc(sistemaContableItem.idsc);
                            if (listaIndiceModelo.Count > 0)
                            {
                                foreach (BalanceModelo item in listaBalancesModelo)
                                {
                                    BalanceModelo.DeleteBorradoLogico(item.idbalance,item);
                                }
                            }
                        }
                        //Borrado de catalogo
                        if (sistemaContableItem != null)
                        {
                            if (CatalogoCuentasModelo.DeleteLogicoAllByIdsc(sistemaContableItem.idsc))
                            {

                            }
                            else
                            {

                            }
                        }
                        //Borrado de sistema contables
                        if (sistemaContableItem != null)
                        {
                            SistemaContableModelo.DeleteBorradoLogico(sistemaContableItem.idsc);
                        }


                        string commandString = String.Format("UPDATE sgpt.encargos SET estadoencargo = 'B' WHERE idencargo={0};", id);
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
                        MessageBox.Show("Exception en borrar registro de encargo : " + e.Message);
                    throw;

                }
            }
            else
            {
                return false;
            }
        }

        public static bool Delete(EncargoModelo registro)
        {
            //id de encargo
            if ((registro != null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        int id = registro.idencargo;
                        //Borrado de asignaciones
                        var listaAsignaciones = AsignacionModelo.GetAll(id);
                        if (listaAsignaciones.Count > 0)
                        {
                            foreach (AsignacionModelo item in listaAsignaciones)
                            {
                                AsignacionModelo.Delete(item.idasignacion);
                            }
                        }
                        //Borrado de programas
                        var listaprogramaModelo = ProgramaModelo.GetAllByEncargo(id);
                        if (listaprogramaModelo.Count > 0)
                        {
                            foreach (ProgramaModelo item in listaprogramaModelo)
                            {
                                if (item.idthprograma == 1)
                                {
                                    ProgramaModelo.DeleteByDetallePrograma(item.idprograma, true);
                                }
                                else
                                {
                                    ProgramaModelo.DeleteByDetalleCuestionario(item.idprograma, true);
                                }
                            }
                        }
                        //Borrado de indices
                        var listaIndiceModelo = IndiceModelo.GetAllCapaDatosByEncargo(id);
                        if (listaIndiceModelo.Count > 0)
                        {
                            foreach (index item in listaIndiceModelo)
                            {
                                    IndiceModelo.Delete((int)item.idindice, true);
                            }
                        }
                        //Borrado de carpetas de indice
                        var listaCarpetasModelo = TipoCarpetaModelo.GetAllEncargos(id);
                        if (listaIndiceModelo.Count > 0)
                        {
                            foreach (TipoCarpetaModelo item in listaCarpetasModelo)
                            {
                                TipoCarpetaModelo.Delete((int)item.id, true);
                            }
                        }

                        //Borrado de balances
                        var sistemaContableItem = SistemaContableModelo.GetRegistroByIdEncargo(id);
                        if (sistemaContableItem!=null)
                        { 
                        var listaBalancesModelo = BalanceModelo.GetAllCapaDatosByidSc(sistemaContableItem.idsc);
                        if (listaIndiceModelo.Count > 0)
                        {
                            foreach (balance item in listaBalancesModelo)
                            {
                                    BalanceModelo.Delete((int)item.idbalance, true);
                            }
                        }
                        }
                        //Borrado de catalogo
                        if (sistemaContableItem != null)
                        {
                            if (CatalogoCuentasModelo.DeleteAllByIdsc(sistemaContableItem.idsc))
                            {

                            }
                            else
                            {

                            }
                        }
                        //Borrado de sistema contables
                        if (sistemaContableItem != null)
                        {
                            SistemaContableModelo.Delete(sistemaContableItem.idsc);
                        }


                        string commandString = String.Format("DELETE FROM sgpt.encargos WHERE idencargo={0};", id);
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
                        MessageBox.Show("Exception en borrar registro de encargo : " + e.Message);
                    throw;
                    
                }
            }
            else
            {
                return false;
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion


        public static List<EncargoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.encargos.Select(entidad =>
                    new EncargoModelo
                    {
                        idencargo = entidad.idencargo,
                        idnitcliente = entidad.idnitcliente,
                        idta = entidad.idta,
                        fechacreadoencargo = entidad.fechacreadoencargo,
                        tipoclienteencargo = (bool)entidad.tipoclienteencargo,
                        etapaencargo = entidad.etapaencargo,
                        costoejecucionencargo = entidad.costoejecucionencargo,
                        honorariosencargo = entidad.honorariosencargo,
                        fechainiperauditencargo = entidad.fechainiperauditencargo,
                        fechafinperauditencargo = entidad.fechafinperauditencargo,
                        estadoencargo = entidad.estadoencargo,
                        razonsocialcliente = entidad.cliente.razonsocialcliente,
                        descripcionTipoAuditoria = entidad.tiposauditoria.descripcionta,
                        tipoAuditoriaModelo = new TipoAuditoriaModelo
                        {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
                        },
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idencargo).Where(x => x.estadoencargo == "A").ToList();
                    if (listado == null)
                    {
                        return new List<EncargoModelo>();
                    }
                    else
                    {
                        int j = 1;
                        //var listadoClientes = ClienteModelo.GetAll();
                        foreach (EncargoModelo item in listado)
                        {
                            item.idCorrelativo = j;
                            j++;
                            item.seleccionEncargo = false;
                            //item.razonsocialcliente = listadoClientes.Single(i => i.idnitcliente == item.idnitcliente).razonsocialcliente;
                            item.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(item.etapaencargo);
                            item.descripcionEtapaEncargo = item.etapaEncargoModelo.descripcionEtapaEncargo;
                            item.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(item.tipoclienteencargo);
                            item.descripcionTipoClienteEncargo = item.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;
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
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo \n" +e);
                }
                return null;
            }
        }

        public static List<EncargoModelo> GetAllByCliente(EncargoModelo encargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.encargos.Select(entidad =>
                    new EncargoModelo
                    {
                        idencargo = entidad.idencargo,
                        idnitcliente = entidad.idnitcliente,
                        idta = entidad.idta,
                        fechacreadoencargo = entidad.fechacreadoencargo,
                        tipoclienteencargo = (bool)entidad.tipoclienteencargo,
                        etapaencargo = entidad.etapaencargo,
                        costoejecucionencargo = entidad.costoejecucionencargo,
                        honorariosencargo = entidad.honorariosencargo,
                        fechainiperauditencargo = entidad.fechainiperauditencargo,
                        fechafinperauditencargo = entidad.fechafinperauditencargo,
                        estadoencargo = entidad.estadoencargo,
                        razonsocialcliente = entidad.cliente.razonsocialcliente,
                        descripcionTipoAuditoria = entidad.tiposauditoria.descripcionta,
                        usuarioaprobo = entidad.usuarioaprobo,
                        fechacierre = entidad.fechacierre,
                        fechasupervision = entidad.fechasupervision,
                        fechaaprobacion = entidad.fechaaprobacion,
                        usuariocerro = entidad.usuariocerro,
                        usuariosuperviso = entidad.usuariosuperviso,
                        tipoAuditoriaModelo = new TipoAuditoriaModelo
                        {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
                        },
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idencargo).Where(x => x.estadoencargo == "A" && x.idnitcliente==encargo.idnitcliente).ToList();
                    if (listado == null)
                    {
                        return new List<EncargoModelo>();
                    }
                    else
                    {
                        int j = 1;
                        //var listadoClientes = ClienteModelo.GetAll();
                        foreach (EncargoModelo item in listado)
                        {
                            item.idCorrelativo = j;
                            j++;
                            item.seleccionEncargo = false;
                            //item.razonsocialcliente = listadoClientes.Single(i => i.idnitcliente == item.idnitcliente).razonsocialcliente;
                            item.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(item.etapaencargo);
                            item.descripcionEtapaEncargo = item.etapaEncargoModelo.descripcionEtapaEncargo;
                            item.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(item.tipoclienteencargo);
                            item.descripcionTipoClienteEncargo = item.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;
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
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo \n" + e);
                }
                return null;
            }
        }

        public static List<EncargoModelo> GetAllByIdCliente(string idCliente)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var listado = _context.encargos.Select(entidad =>
                    new EncargoModelo
                    {
                        idencargo = entidad.idencargo,
                        idnitcliente = entidad.idnitcliente,
                        idta = entidad.idta,
                        fechacreadoencargo = entidad.fechacreadoencargo,
                        tipoclienteencargo = (bool)entidad.tipoclienteencargo,
                        etapaencargo = entidad.etapaencargo,
                        costoejecucionencargo = entidad.costoejecucionencargo,
                        honorariosencargo = entidad.honorariosencargo,
                        fechainiperauditencargo = entidad.fechainiperauditencargo,
                        fechafinperauditencargo = entidad.fechafinperauditencargo,
                        estadoencargo = entidad.estadoencargo,
                        tipoAuditoriaModelo = new TipoAuditoriaModelo
                        {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
                        },
                        descripcionTipoAuditoria = entidad.tiposauditoria.descripcionta,
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idencargo).Where(x => x.estadoencargo == "A" && x.idnitcliente.Contains(idCliente)).ToList();
                    if (listado == null)
                    {
                        return new List<EncargoModelo>();
                    }
                    else
                    {
                        int j = 1;
                        var listadoClientes = ClienteModelo.GetAll();
                        foreach (EncargoModelo item in listado)
                        {
                            item.idCorrelativo = j;
                            j++;
                            item.seleccionEncargo = false;
                            item.razonsocialcliente = listadoClientes.Single(i => i.idnitcliente == item.idnitcliente).razonsocialcliente;
                            item.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(item.etapaencargo);
                            item.descripcionEtapaEncargo = item.etapaEncargoModelo.descripcionEtapaEncargo;
                            item.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(item.tipoclienteencargo);
                            item.descripcionTipoClienteEncargo = item.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;
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
        public static List<EncargoModelo> GetAll(ObservableCollection<AsignacionModelo> listadoAsignaciones)
        {
            if (listadoAsignaciones.Count > 0)
            {
                var listaFiltrada=new ObservableCollection<EncargoModelo>();
                foreach (AsignacionModelo item in listadoAsignaciones)
                {
                    listaFiltrada.Add(EncargoModelo.GetRegistro(item.idencargo));
                }
                return listaFiltrada.OrderBy(z=>z.razonsocialcliente).ToList();
            }
            else
            {
                return new List<EncargoModelo>();
            }
        }

        public static EncargoModelo GetRegistro(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.encargos.Select(entidad =>
                    new EncargoModelo
                    {
                        idencargo = entidad.idencargo,
                        idnitcliente = entidad.idnitcliente,
                        idta = entidad.idta,
                        fechacreadoencargo = entidad.fechacreadoencargo,
                        tipoclienteencargo = (bool)entidad.tipoclienteencargo,
                        etapaencargo = entidad.etapaencargo,
                        costoejecucionencargo = entidad.costoejecucionencargo,
                        honorariosencargo = entidad.honorariosencargo,
                        fechainiperauditencargo = entidad.fechainiperauditencargo,
                        fechafinperauditencargo = entidad.fechafinperauditencargo,
                        estadoencargo = entidad.estadoencargo,

                        //Carga de  entidades
                        /*indiceModelo = new IndiceModelo
                        {
                            idindice = entidad.index.idindice,
                            idencargo = entidad.index.idencargo,
                            idpapeles = entidad.index.idpapeles,
                            idmaf = entidad.index.idmaf,
                            idencargo = entidad.index.idencargo,
                            idprograma = entidad.index.idprograma,
                            indidindice = entidad.index.indidindice,
                            descripcionindice = entidad.index.descripcionindice,
                            ordenindice = entidad.index.ordenindice,
                            referenciaindice = entidad.index.referenciaindice,
                            obligatorioindice = entidad.index.obligatorioindice,
                            sistemaindice = entidad.index.sistemaindice,
                            estadoindice = entidad.index.estadoindice
                        },*/
                        tipoAuditoriaModelo = new TipoAuditoriaModelo
                        {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
                        },
                        descripcionTipoAuditoria = entidad.tiposauditoria.descripcionta,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.idencargo == idEncargo).Where(x => x.estadoencargo == "A").FirstOrDefault();
                    var listadoClientes = ClienteModelo.GetAll();
                    registro.razonsocialcliente = listadoClientes.Single(i => i.idnitcliente == registro.idnitcliente).razonsocialcliente;
                    registro.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(registro.etapaencargo);
                    registro.descripcionEtapaEncargo = registro.etapaEncargoModelo.descripcionEtapaEncargo;
                    registro.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(registro.tipoclienteencargo);
                    registro.descripcionEtapaEncargo = registro.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del encargo " + e.Message);
                }
                return null;
            }
        }
        public static EncargoModelo GetRegistro(string idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.encargos.Select(entidad =>
                    new EncargoModelo
                    {
                        idencargo = entidad.idencargo,
                        idnitcliente = entidad.idnitcliente,
                        idta = entidad.idta,
                        fechacreadoencargo = entidad.fechacreadoencargo,
                        tipoclienteencargo =(bool) entidad.tipoclienteencargo,
                        etapaencargo = entidad.etapaencargo,
                        costoejecucionencargo = entidad.costoejecucionencargo,
                        honorariosencargo = entidad.honorariosencargo,
                        fechainiperauditencargo = entidad.fechainiperauditencargo,
                        fechafinperauditencargo = entidad.fechafinperauditencargo,
                        estadoencargo = entidad.estadoencargo,

                        //Carga de  entidades
                        /*indiceModelo = new IndiceModelo
                        {
                            idindice = entidad.index.idindice,
                            idencargo = entidad.index.idencargo,
                            idpapeles = entidad.index.idpapeles,
                            idmaf = entidad.index.idmaf,
                            idencargo = entidad.index.idencargo,
                            idprograma = entidad.index.idprograma,
                            indidindice = entidad.index.indidindice,
                            descripcionindice = entidad.index.descripcionindice,
                            ordenindice = entidad.index.ordenindice,
                            referenciaindice = entidad.index.referenciaindice,
                            obligatorioindice = entidad.index.obligatorioindice,
                            sistemaindice = entidad.index.sistemaindice,
                            estadoindice = entidad.index.estadoindice
                        },*/
                        tipoAuditoriaModelo = new TipoAuditoriaModelo
                        {
                            id = entidad.tiposauditoria.idta,
                            descripcion = entidad.tiposauditoria.descripcionta,
                            sistema = entidad.tiposauditoria.sistemata,
                            estado = entidad.tiposauditoria.estadota
                        },
                        descripcionTipoAuditoria = entidad.tiposauditoria.descripcionta,
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.idencargo.ToString() == idencargo).Where(x => x.estadoencargo == "A").FirstOrDefault();
                var listadoClientes = ClienteModelo.GetAll();
                registro.razonsocialcliente = listadoClientes.Single(i => i.idnitcliente == registro.idnitcliente).razonsocialcliente;
                registro.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(registro.etapaencargo);
                registro.descripcionEtapaEncargo = registro.etapaEncargoModelo.descripcionEtapaEncargo;
                registro.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(registro.tipoclienteencargo);
                registro.descripcionEtapaEncargo = registro.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;
                return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del encargo " + e.Message);
                }
                return null;
            }
        }
        #region Contar registros
        public static int ContarRegistros(int? idta)
        {
            throw new NotImplementedException();
        }

        public static int ContarRegistros()
        {
            throw new NotImplementedException();
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

        public static bool UpdateBorradoModelo(EncargoModelo modelo, bool actualizar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static EncargoModelo Clear(EncargoModelo modelo)
        {
            throw new NotImplementedException();
        }
        public EncargoModelo()
        {
            
                    idencargo = 0;
                    idnitcliente =string.Empty;
                    idta = 1;
                    fechacreadoencargo = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture); 
                    tipoclienteencargo = false;//No es recurrente
                    etapaencargo = "I";//Etapa inicial
                    costoejecucionencargo = 0;
                    honorariosencargo = 0;
                    fechainiperauditencargo = MetodosModelo.homologacionFecha( new DateTime((DateTime.Now.Year-1), 1, 1).ToString("dd/MM/yyyy",CultureInfo.CurrentCulture));
                    fechafinperauditencargo = MetodosModelo.homologacionFecha(new DateTime((DateTime.Now.Year-1), 12, 31).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
                    estadoencargo = "A";
        }

        internal static bool Delete(ObservableCollection<EncargoModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        encargo entidadTemporal = new encargo();
                        string commandString = string.Empty;
                        foreach (EncargoModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idencargo);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.encargos WHERE idencargo={0};", item.idencargo);
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

        public static bool DeleteBorradoLogico(int id, EncargoModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.encargos SET estadoencargos = 'B' WHERE idencargo={0};", id);
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

        public static bool DeleteBorradoLogico(ObservableCollection<EncargoModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    encargo entidadTemporal = new encargo();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (EncargoModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idencargo);//Borra todas las referencias dentro  de bitacora
                                                                                         //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idencargo);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.encargos SET estadoencargo = 'B' WHERE idencargo={0};", item.idencargo);
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

        public EncargoModelo(EncargoModelo currentEncargo, UsuarioModelo usuarioModelo)
        {
            idencargo = 0;
            idnitcliente = string.Empty;
            idta = 1;
            fechacreadoencargo = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture); 
            tipoclienteencargo = false;//No es recurrente
            etapaencargo = "I";//Etapa inicial
            costoejecucionencargo = 0;
            honorariosencargo = 0;
            fechainiperauditencargo = MetodosModelo.homologacionFecha(new DateTime((DateTime.Now.Year - 1), 1, 1).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
            fechafinperauditencargo = MetodosModelo.homologacionFecha(new DateTime((DateTime.Now.Year - 1), 12, 31).ToString("dd/MM/yyyy", CultureInfo.CurrentCulture));
            estadoencargo = "A";
            this.usuarioModelo = usuarioModelo;
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            this.usuarioModelo = usuarioModelo;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
        }

        public static int contarRepetidoRegistro(EncargoModelo registro)
        {

            if (registro != null)
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.encargos
                                   where ((p.idnitcliente == registro.idnitcliente) && (p.idta == registro.idta))

                                   //where ((p.idnitcliente==registro.idnitcliente) && (p.idta == registro.idta) && (p.fechainiperauditencargo == registro.fechainiperauditencargo) && (p.fechafinperauditencargo == registro.fechafinperauditencargo))
                                   select p).ToList();
                    if (entidad.Count == 0)
                    {
                        return 0;
                    }
                    else
                    {
                        int evaluacion = 0;
                        DateTime inicio = new DateTime();
                        DateTime fin = new DateTime();
                        DateTime inicioCompara = new DateTime();
                        DateTime finCompara = new DateTime();
                        bool evaluar = true;
                        int cuenta = 0;
                        for (int i = 0; i < entidad.Count; i++)
                        {
                            if (entidad[i].idencargo != registro.idencargo)
                            {
                                evaluacion = MetodosModelo.validadConversionFechas(entidad[i].fechainiperauditencargo);
                                if (evaluacion != 0)
                                {
                                    inicio = MetodosModelo.conversionFechas(entidad[i].fechainiperauditencargo, evaluacion);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo convertir la fecha de inicio  de la auditoria", "");
                                    evaluar = false;
                                }
                                evaluacion = MetodosModelo.validadConversionFechas(entidad[i].fechafinperauditencargo);
                                if (evaluacion != 0)
                                {
                                    fin = MetodosModelo.conversionFechas(entidad[i].fechafinperauditencargo, evaluacion);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo convertir la fecha de fin  de la auditoria", "");
                                    evaluar = false;
                                }


                                evaluacion = MetodosModelo.validadConversionFechas(registro.fechainiperauditencargo);
                                if (evaluacion != 0)
                                {
                                    inicioCompara = MetodosModelo.conversionFechas(registro.fechainiperauditencargo, evaluacion);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo convertir la fecha de inicio Compara de la auditoria", "");
                                    evaluar = false;
                                }
                                evaluacion = MetodosModelo.validadConversionFechas(registro.fechafinperauditencargo);
                                if (evaluacion != 0)
                                {
                                    finCompara = MetodosModelo.conversionFechas(registro.fechafinperauditencargo, evaluacion);
                                }
                                else
                                {
                                    MessageBox.Show("No se pudo convertir la fecha de fin Compara  de la auditoria", "");
                                    evaluar = false;
                                }
                                if (evaluar)
                                {
                                    if ((inicio == inicioCompara) && (fin == finCompara))
                                    {
                                        cuenta++;
                                    }
                                }
                            }
                            else
                            {
                                cuenta++;
                            }
                        }
                        return cuenta;
                    }
                        
                    }
                }
                    else
                    {
                        return 0;
                    }
        }

        internal static int evaluarCerrar(EncargoModelo currentEntidad)
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


        #endregion

        #region procesos de  cierre

        internal static int UpdateCierre(EncargoModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idencargo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.encargos SET usuariocerro = '{0}',fechacierre = '{1}', estadoencargo='{2}' WHERE idencargo = {3};",
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


        internal static int UpdateSupervision(EncargoModelo modelo)
        {
            int id = modelo.idencargo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.encargos SET usuariosuperviso = '{0}',fechasupervision = '{1}', estadoencargo='{2}' WHERE idencargo = {3};",
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

        internal static int UpdateAprobacion(EncargoModelo modelo)
        {
            int id = modelo.idencargo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.encargos SET usuarioaprobo = '{0}',fechaaprobacion = '{1}', estadoencargo='{2}' WHERE idencargo = {3};",
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

        internal static int UpdateAprobacionSupervision(EncargoModelo modelo)
        {
            int id = modelo.idencargo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }
                            temporal = new BitacoraModelo(modelo, "ENCARGOS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.encargos SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}' , estadoencargo='{4}' WHERE idencargo = {5};",
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

        #region IDataErrorInfo Members

        //public string Error
        //{
        //    get { throw new NotImplementedException(); }
        //}

        private string error = string.Empty;

        public string Error
        {
            get
            {
                return this.error;
            }
        }

        private bool _IsValid()
        {
            DateTime fechainicio;
            DateTime fechafin;
            fechainicio = MetodosModelo.convertirFecha(fechainiperauditencargo);
            fechafin = MetodosModelo.convertirFecha(fechafinperauditencargo);
            return fechafin > fechainicio;
        }


        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "fechainiperauditencargo" && !_IsValid())
                    result = "El inicio de la auditoria debe ser antes que  el final!";
                else if (columnName == "fechafinperauditencargo" && !_IsValid())
                    result = "El final debe ocurrir despues del  inicio de  la auditoría!";
                return result;
            }
        }
        public string this[string propertyName]
        {
            get
            {
                this.ValidatePropertyInternal(propertyName, ref this.error);

                return this.error;
            }
        }

        protected virtual void ValidatePropertyInternal(string propertyName, ref string error)
        {
            this.ValidateProperty(propertyName, ref error);
        }

        // Please implement this method in a partial class in order to provide 
        // the error message depending on each of the properties.
        partial void ValidateProperty(string propertyName, ref string error);


        #endregion
    }
    public partial class EncargoModelo
    {

        //http://blogs.msmvps.com/otelis/2012/05/27/validaci-243-n-de-datos-de-entrada-con-enlace-a-datos-en-wpf/
        //http://docs.telerik.com/data-access/deprecated/developers-guide/code-generation/developer-guide-code-generation-implement-idataerrorinfo
        partial void ValidateProperty(string propertyName, ref string error)
        {
            error = string.Empty;
            switch (propertyName)
            {
                case "fechainiperauditencargo":
                    if (!_IsValid())
                        error = "El inicio de la auditoria debe ser antes que  el final!";
                    break;
                case "fechafinperauditencargo":
                    if (!_IsValid())
                        error = "El final debe ocurrir despues del  inicio de  la auditoría!";
                    break;
            }
        }
    }
}



