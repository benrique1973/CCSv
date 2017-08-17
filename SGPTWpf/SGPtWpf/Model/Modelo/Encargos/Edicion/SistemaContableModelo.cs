using CapaDatos;
using SGPTWpf.SGPtWpf.Support;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace SGPTWpf.Model.Modelo.Encargos
{
    public partial class SistemaContableModelo : UIBaseAlterna, IDataErrorInfo
    {
            #region Model Attributes

            private static SGPTEntidades _context;

            #endregion

            #region Model Properties

            public static bool sincronizar { get; set; }

            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [DisplayName("Id de sistema contable")]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int idsc
            {
                get { return GetValue(() => idsc); }
                set { SetValue(() => idsc, value); }
            }

            public Nullable<int> idmoneda
            {
                get { return GetValue(() => idmoneda); }
                set { SetValue(() => idmoneda, value); }
            }

            public string idnitcliente
            {
                get { return GetValue(() => idnitcliente); }
                set { SetValue(() => idnitcliente, value); }
            }


            public int ideef
            {
                get { return GetValue(() => ideef); }
                set { SetValue(() => ideef, value); }
            }
        public Nullable<int> idencargodsc
        {
            get { return GetValue(() => idencargodsc); }
            set { SetValue(() => idencargodsc, value); }
        }

            [DisplayName("Fecha de creación")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
            Required(ErrorMessage = "Formato de fecha incorrecto")]
            [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
            ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
            [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
            public string fechasc
            {
                get { return GetValue(() => fechasc); }
                set { SetValue(() => fechasc, value); }
            }

        //Permite determinar si es un encargo recurrente (segunda o mas veces) que se hace el encargo del cliente.
        //True=El encargo es recurrente, False= Primera vez que se hace la auditoria. 
        //En el caso de las auditorias recurrentes permite utilizar archivos del encargo inmediato anterior.
        [Required(ErrorMessage = "Dato requerido")]
        [Range(1, 20, ErrorMessage = "Los valores posibles son de  1 a 20")]
        public int digitoscuentamayorsc
            {
                get { return GetValue(() => digitoscuentamayorsc); }
                set { SetValue(() => digitoscuentamayorsc, value); }
            }
        //Permite gestionar las diferentes etapas de los archivos que componen las auditorias. 
        //Se distinguen las siguientes etapas; I=inicial, P=En proceso, R=Revisado, C=Cerrado. 
        //Un encargo con estado = "Cerrado" no se debe modificar ningun elemento asociado a el.
        [Required(ErrorMessage = "Dato requerido")]
        [Range(1, 20, ErrorMessage = "Los valores posibles son de  1 a 20")]

        public int digitosrubroscontablessc
            {
                get { return GetValue(() => digitosrubroscontablessc); }
                set { SetValue(() => digitosrubroscontablessc, value); }
            }
        [DisplayName("Inicio")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido formato dd/mm")]
        [RegularExpression(@"^([0-3]{1}[1-9]{1}[/]{1}[0-1]{1}[1-9]{1})", ErrorMessage = "Deben ser en formato dd/mm ejemplo 01/01")]
        public string periodoiniciosc 
            {
                get { return GetValue(() => periodoiniciosc ); }
                set { SetValue(() => periodoiniciosc , value); }
            }
        [DisplayName("Fin")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Dato requerido formato dd/mm")]
        [RegularExpression(@"^([0-3]{1}[1-9]{1}[/]{1}[0-1]{1}[1-9]{1})", ErrorMessage = "Deben ser en formato dd/mm ejemplo 01/01")]
        public string periodofinsc
            {
                get { return GetValue(() => periodofinsc); }
                set { SetValue(() => periodofinsc, value); }
            }

            public string estadosc
            {
                get { return GetValue(() => estadosc); }
                set { SetValue(() => estadosc, value); }
            }

        // Entidades relacionadas

        [DisplayName("Estructura de estados financieros")]
        [Required(ErrorMessage = "Dato requerido")]
        public virtual EstructuraEstadoFinancieroModelo estructuraEstadoFinancieroModelo
            {
                get { return GetValue(() => estructuraEstadoFinancieroModelo); }
                set { SetValue(() => estructuraEstadoFinancieroModelo, value); }
            }
        [DisplayName("Monedas")]
        [Required(ErrorMessage = "Dato requerido")]
        public virtual MonedaModelo monedaModelo
            {
                get { return GetValue(() => monedaModelo); }
                set { SetValue(() => monedaModelo, value); }
            }
        [DisplayName("Digitos de cuentas")]
        [Required(ErrorMessage = "Dato requerido")]
        public virtual DigitosModelo digitosCuentaMayorSc
        {
            get { return GetValue(() => digitosCuentaMayorSc); }
            set { SetValue(() => digitosCuentaMayorSc, value); }
        }
        [DisplayName("Digitos de rubros")]
        [Required(ErrorMessage = "Dato requerido")]
        public virtual DigitosModelo digitosRubrosContablesSc
        {
            get { return GetValue(() => digitosRubrosContablesSc); }
            set { SetValue(() => digitosRubrosContablesSc, value); }
        }

        public virtual ICollection<ElementoModelo> listaElementoModelo
        {
            get { return GetValue(() => listaElementoModelo); }
            set { SetValue(() => listaElementoModelo, value); }
        }

        public virtual EncargoModelo encargoModeloSc
        {
            get { return GetValue(() => encargoModeloSc); }
            set { SetValue(() => encargoModeloSc, value); }
        }
        #endregion

        #region Propiedades de presentacion

        #endregion

        #region Public Model Methods


        public static bool Insert(SistemaContableModelo modelo)
            {
                throw new NotImplementedException();
            }

        public static bool Insert(SistemaContableModelo modelo, bool valor)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.sistemascontables', 'idsc'), (SELECT MAX(idsc) FROM sgpt.sistemascontables) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new sistemascontable
                        {
                            //idsc = entidad.idsc,
                            idmoneda = modelo.idmoneda,
                            idnitcliente = modelo.idnitcliente,
                            ideef = modelo.ideef,
                            fechasc = modelo.fechasc,
                            digitoscuentamayorsc = modelo.digitoscuentamayorsc,
                            digitosrubroscontablessc = modelo.digitosrubroscontablessc,
                            idencargodsc=modelo.idencargodsc,
                            periodoiniciosc = modelo.periodoiniciosc,
                            periodofinsc = modelo.periodofinsc,
                            estadosc = modelo.estadosc,
                            
                        };
                        _context.sistemascontables.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idsc = tablaDestino.idsc;
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
        public static SistemaContableModelo Find(int id)
            {
            var modelo = new SistemaContableModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    sistemascontable entidad = _context.sistemascontables.Find(id);
                    if (entidad == null)
                    {
                        return modelo = null;
                    }
                    else
                    {
                            modelo.idsc = entidad.idsc;
                            modelo.idmoneda = entidad.idmoneda;
                            modelo.idnitcliente = entidad.idnitcliente;
                            modelo.ideef = entidad.ideef;
                            modelo.fechasc = entidad.fechasc;
                            modelo.digitoscuentamayorsc = entidad.digitoscuentamayorsc;
                            modelo.digitosrubroscontablessc = entidad.digitosrubroscontablessc;
                            modelo.periodoiniciosc = entidad.periodoiniciosc;
                            modelo.periodofinsc = entidad.periodofinsc;
                            modelo.estadosc = entidad.estadosc;
                            modelo.idencargodsc = entidad.idencargodsc;
                            //Carga de  entidades
                            modelo.estructuraEstadoFinancieroModelo = new EstructuraEstadoFinancieroModelo
                            {
                                id = entidad.estructuraestadofinanciero.ideef,
                                descripcion = entidad.estructuraestadofinanciero.descripcioneef,
                                sistema = entidad.estructuraestadofinanciero.sistemaeef,
                                estado = entidad.estructuraestadofinanciero.estadoeef
                            };

                        modelo.monedaModelo = new MonedaModelo
                        {
                            id = entidad.moneda.idmoneda,
                            descripcion = entidad.moneda.nombremoneda,
                            sistema = entidad.moneda.sistemamoneda,
                            estado = entidad.moneda.estadomoneda,
                            simbolomoneda = entidad.moneda.simbolomoneda
                        };
                        modelo.encargoModeloSc = new EncargoModelo
                        {
                            idencargo = entidad.encargo.idencargo,
                            idnitcliente = entidad.encargo.idnitcliente,
                            idta = entidad.encargo.idta,
                            fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                            tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                            etapaencargo = entidad.encargo.etapaencargo,
                            costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                            honorariosencargo = entidad.encargo.honorariosencargo,
                            fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                            fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                            estadoencargo = entidad.encargo.estadoencargo,
                            tipoAuditoriaModelo = new TipoAuditoriaModelo
                            {
                                id = entidad.encargo.tiposauditoria.idta,
                                descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                sistema = entidad.encargo.tiposauditoria.sistemata,
                                estado = entidad.encargo.tiposauditoria.estadota
                            },
                            descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta,
                        };
                        modelo.digitosCuentaMayorSc = new DigitosModelo(modelo.digitoscuentamayorsc);
                        modelo.digitosRubrosContablesSc = new DigitosModelo(modelo.digitosrubroscontablessc);
                        modelo.listaElementoModelo = ElementoModelo.GetAll(modelo.idsc);//Guarda los elementos de  un sistema contable;
                        }
                    if (modelo.idencargodsc == null)
                    {
                        modelo.idencargodsc = 0;
                    }
                       return modelo;
                    }
                }
            else
            {
                return modelo = null;
            }

        }


        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static SistemaContableModelo Find(string id)
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


        public static bool UpdateModelo(SistemaContableModelo modelo, Boolean actualizar)
        {
            bool guardar = false;
            if (!(modelo == null))
            {
                if (modelo.digitosCuentaMayorSc != null)
                {
                    if (modelo.digitoscuentamayorsc == modelo.digitosCuentaMayorSc.idDigitosModelo)
                    { modelo.digitoscuentamayorsc = (int)(modelo.digitosCuentaMayorSc.idDigitosModelo);
                        guardar = true;
                    }
                }
                if (!guardar)
                {
                    if (modelo.digitosRubrosContablesSc != null)
                    {
                        if (modelo.digitosrubroscontablessc == (modelo.digitosCuentaMayorSc.idDigitosModelo))
                        {
                            modelo.digitosrubroscontablessc = (int)(modelo.digitosCuentaMayorSc.idDigitosModelo);
                            guardar = true;
                        }
                    }
                }
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        sistemascontable entidad = _context.sistemascontables.Find(modelo.idsc);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!guardar)
                            {
                                if (entidad.idmoneda == modelo.idmoneda)
                                {
                                    guardar = true;
                                }
                            }

                            if (!guardar)
                            {
                                if (entidad.idnitcliente == modelo.idnitcliente)
                                {
                                    guardar = true;
                                }
                            }
                            if (!guardar)
                            {
                                if (entidad.ideef == modelo.ideef)
                                {
                                    guardar = true;
                                }
                            }

                            if (!guardar)
                            {
                                if (entidad.periodoiniciosc == modelo.periodoiniciosc)
                                {
                                    guardar = true;
                                }
                            }
                            if (!guardar)
                            {
                                if (entidad.periodofinsc == modelo.periodofinsc)
                                {
                                    guardar = true;
                                }
                            }

                            if (guardar)
                            { 
                            //idsc = entidad.idsc,
                            entidad.idmoneda = modelo.idmoneda;
                            entidad.idnitcliente = modelo.idnitcliente;
                            entidad.ideef = modelo.ideef;
                            entidad.periodoiniciosc = modelo.periodoiniciosc;
                            entidad.periodofinsc = modelo.periodofinsc;

                            entidad.fechasc = modelo.fechasc;
                            entidad.digitoscuentamayorsc = modelo.digitoscuentamayorsc;
                            entidad.digitosrubroscontablessc = modelo.digitosrubroscontablessc;
                            entidad.idencargodsc = modelo.idencargodsc;

                            //entidad.estadosc = modelo.estadosc;
                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                            }
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


        public static bool CopiarModelo(SistemaContableModelo modelo)
            {
                throw new NotImplementedException();
            }
            //Pendiente el definir la forma de consulta y eliminacion

            public static void DeleteBorradoLogico(int id)
            {
            if (!(id==0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            sistemascontable entidad = _context.sistemascontables.Find(id);
                            //Borrado lógico de elementos
                            if (entidad.elementos.Count > 0)
                            {
                                foreach (elemento item in entidad.elementos)
                                {
                                    ElementoModelo.DeleteBorradoLogico(item.idelementos, true);
                                }
                            }
                            else
                            {
                                //Verificar que no existe el elemento en la tabla
                                var listaElementos = ElementoModelo.GetAll(id);
                                if (listaElementos.Count > 0)
                                {
                                    foreach (ElementoModelo item in listaElementos)
                                    {
                                        ElementoModelo.DeleteBorradoLogico(item.id, true);
                                    }
                                }
                            }
                            string commandString = String.Format("UPDATE sgpt.sistemascontables SET estadosc = 'B' WHERE idsc={0};", id);
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
                            MessageBox.Show("Exception en borrar registro de sistema contable: \n"+ e);
                        throw;
                    }
                    //return result;
                }
            }
            else
            {
                //return result;
            }
        }

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
                            sistemascontable entidad = _context.sistemascontables.Find(id);
                            //Borrado lógico de elementos
                            foreach (elemento item in entidad.elementos)
                            {
                                ElementoModelo.DeleteBorradoLogico(item.idelementos, true);
                            }
                            string commandString = String.Format("UPDATE sgpt.sistemascontables SET estadosc = 'B' WHERE idsc={0};", id);
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
                            MessageBox.Show("Exception en borrar registro de sistema contable: {0}", e.Source);
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

        public static bool DeleteBorradoLogico(string idSc, Boolean actualizar)
            {
            bool result = false;
            if (!((string.IsNullOrEmpty(idSc)) || string.IsNullOrWhiteSpace(idSc)))
            {
                int id = int.Parse(idSc);
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            sistemascontable entidad = _context.sistemascontables.Find(id);
                            //Borrado lógico de elementos
                                //Verificar que no existe el elemento en la tabla
                                var listaElementos = ElementoModelo.GetAll(id);
                                if (listaElementos.Count > 0)
                                {
                                    foreach (ElementoModelo item in listaElementos)
                                    {
                                        ElementoModelo.DeleteBorradoLogico(item.id, true);
                                    }
                                }
                            entidad.estadosc = "B";
                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro de sistema contable: {0}", e.Source);
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

        public static void Delete(int idSistemaContable)
            {

            if (!(idSistemaContable == 0))
            {
                try
                {
                    //Borrar antes los elementos del sistema contable
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrarse los elementos contables
                        //Borrado de elementos
                            //Verificar que no existe el elemento en la tabla
                            var listaElementos = ElementoModelo.GetAll(idSistemaContable);
                            if (listaElementos.Count > 0)
                            {
                                foreach (ElementoModelo item in listaElementos)
                                {
                                    ElementoModelo.Delete(item.id, true);
                                }
                            }
                        //Eliminados los elementos se puede remover el sistema contable
                        string commandString = String.Format("DELETE FROM sgpt.sistemascontables WHERE idsc={0};", idSistemaContable);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                        //return true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en borrar el sistema contable : ", e.Message);
                    throw;
                }
            }
            else
            {
                //return false;
            }

        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    //Borrar antes los elementos del sistema contable
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrarse los elementos contables
                        //sistemascontable entidad = _context.sistemascontables.Find(id);
                        //Borrado lógico de elementos
                            //Verificar que no existe el elemento en la tabla
                            var listaElementos = ElementoModelo.GetAll(id);
                            if (listaElementos.Count > 0)
                            {
                                foreach (ElementoModelo item in listaElementos)
                                {
                                    ElementoModelo.Delete(item.id, true);
                                }
                            }
                        //Eliminados los elementos se puede remover el sistema contable
                        string commandString = String.Format("DELETE FROM sgpt.sistemascontables WHERE idsc={0};", id);
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
                        MessageBox.Show("Exception en borrar el sistema contable : ", e.Message);
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Delete(string idSistemacontable, Boolean actualizar)
        {
            if (!(string.IsNullOrEmpty(idSistemacontable)))
            {
                int id =int.Parse(idSistemacontable);
                try
                {
                    //Borrar antes los elementos del sistema contable
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrarse los elementos contables
                        //sistemascontable entidad = _context.sistemascontables.Find(id);
                        //Borrado lógico de elementos
                            //Verificar que no existe el elemento en la tabla
                            var listaElementos = ElementoModelo.GetAll(id);
                            if (listaElementos.Count > 0)
                            {
                                foreach (ElementoModelo item in listaElementos)
                                {
                                    ElementoModelo.Delete(item.id, true);
                                }
                            }
                        //Eliminados los elementos se puede remover el sistema contable
                        string commandString = String.Format("DELETE FROM sgpt.sistemascontables WHERE idsc={0};", id);
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
                        MessageBox.Show("Exception en borrar el sistema contable : ", e.Message);
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public static List<SistemaContableModelo> GetAll()
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        var listado = _context.sistemascontables.Select(entidad =>
                        new SistemaContableModelo
                        {
                            idsc = entidad.idsc,
                            idmoneda = entidad.idmoneda,
                            idnitcliente = entidad.idnitcliente,
                            ideef = entidad.ideef,
                            fechasc = entidad.fechasc,
                            digitoscuentamayorsc = entidad.digitoscuentamayorsc,
                            digitosrubroscontablessc = entidad.digitosrubroscontablessc,
                            periodoiniciosc = entidad.periodoiniciosc,
                            periodofinsc = entidad.periodofinsc,
                            estadosc = entidad.estadosc,
                            idencargodsc=entidad.idencargodsc,
                            //Carga de  entidades
                            estructuraEstadoFinancieroModelo = new EstructuraEstadoFinancieroModelo 
                                    {
                                    id = entidad.estructuraestadofinanciero.ideef,
                                    descripcion = entidad.estructuraestadofinanciero.descripcioneef,
                                    sistema = entidad.estructuraestadofinanciero.sistemaeef,
                                    estado = entidad.estructuraestadofinanciero.estadoeef
                                    },

                            monedaModelo= new MonedaModelo
                                    {
                                    id = entidad.moneda.idmoneda,
                                    descripcion = entidad.moneda.nombremoneda,
                                    sistema = entidad.moneda.sistemamoneda,
                                    estado = entidad.moneda.estadomoneda,
                                    simbolomoneda = entidad.moneda.simbolomoneda
                                    },
                            //Lista filtrada de elementos que fueron eliminados
                            encargoModeloSc = new EncargoModelo
                            {
                                idencargo = entidad.encargo.idencargo,
                                idnitcliente = entidad.encargo.idnitcliente,
                                idta = entidad.encargo.idta,
                                fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                                tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                                etapaencargo = entidad.encargo.etapaencargo,
                                costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                                honorariosencargo = entidad.encargo.honorariosencargo,
                                fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                                fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                                estadoencargo = entidad.encargo.estadoencargo,
                                tipoAuditoriaModelo = new TipoAuditoriaModelo
                                {
                                    id = entidad.encargo.tiposauditoria.idta,
                                    descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                    sistema = entidad.encargo.tiposauditoria.sistemata,
                                    estado = entidad.encargo.tiposauditoria.estadota
                                },
                                descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta,
                            }
                        }).OrderBy(o => o.ideef).Where(x => x.estadosc == "A").ToList();
                        if (listado == null)
                        {
                            return new List<SistemaContableModelo>();
                        }
                        else
                        {
                            foreach (SistemaContableModelo item in listado)
                            {
                                item.digitosCuentaMayorSc = new DigitosModelo(item.digitoscuentamayorsc);
                                item.digitosRubrosContablesSc = new DigitosModelo(item.digitosrubroscontablessc);
                                item.listaElementoModelo = ElementoModelo.GetAll(item.idsc);//Guarda los elementos de  un sistema contable;
                            if (item.idencargodsc == null)
                            {
                                item.idencargodsc = 0;
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

            public static SistemaContableModelo GetRegistro(int idSistemaContable)
            {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.sistemascontables.Select(entidad =>
                    new SistemaContableModelo
                    {
                        idsc = entidad.idsc,
                        idmoneda = entidad.idmoneda,
                        idnitcliente = entidad.idnitcliente,
                        ideef = entidad.ideef,
                        fechasc = entidad.fechasc,
                        digitoscuentamayorsc = entidad.digitoscuentamayorsc,
                        digitosrubroscontablessc = entidad.digitosrubroscontablessc,
                        periodoiniciosc = entidad.periodoiniciosc,
                        periodofinsc = entidad.periodofinsc,
                        estadosc = entidad.estadosc,
                        idencargodsc=entidad.idencargodsc,
                            //Carga de  entidades
                            estructuraEstadoFinancieroModelo = new EstructuraEstadoFinancieroModelo
                        {
                            id = entidad.estructuraestadofinanciero.ideef,
                            descripcion = entidad.estructuraestadofinanciero.descripcioneef,
                            sistema = entidad.estructuraestadofinanciero.sistemaeef,
                            estado = entidad.estructuraestadofinanciero.estadoeef
                        },

                        monedaModelo = new MonedaModelo
                        {
                            id = entidad.moneda.idmoneda,
                            descripcion = entidad.moneda.nombremoneda,
                            sistema = entidad.moneda.sistemamoneda,
                            estado = entidad.moneda.estadomoneda,
                            simbolomoneda = entidad.moneda.simbolomoneda
                        },
                        encargoModeloSc = new EncargoModelo
                        {
                            idencargo = entidad.encargo.idencargo,
                            idnitcliente = entidad.encargo.idnitcliente,
                            idta = entidad.encargo.idta,
                            fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                            tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                            etapaencargo = entidad.encargo.etapaencargo,
                            costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                            honorariosencargo = entidad.encargo.honorariosencargo,
                            fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                            fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                            estadoencargo = entidad.encargo.estadoencargo,
                            tipoAuditoriaModelo = new TipoAuditoriaModelo
                            {
                                id = entidad.encargo.tiposauditoria.idta,
                                descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                sistema = entidad.encargo.tiposauditoria.sistemata,
                                estado = entidad.encargo.tiposauditoria.estadota
                            },
                            descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta,
                        }
                    //Lista filtrada de elementos que fueron eliminados
                }).Where(x => x.estadosc == "A" && x.idsc == idSistemaContable).FirstOrDefault();
                    if (registro == null)
                    {
                        return registro;
                    }
                    else
                    {
                        registro.digitosCuentaMayorSc = new DigitosModelo(registro.digitoscuentamayorsc);
                        registro.digitosRubrosContablesSc = new DigitosModelo(registro.digitosrubroscontablessc);
                        registro.listaElementoModelo = ElementoModelo.GetAll(registro.idsc);//Guarda los elementos de  un sistema contable;
                        if (registro.idencargodsc == null)
                        {
                            registro.idencargodsc = 0;
                        }
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

        public static SistemaContableModelo GetRegistroByIdEncargo(int idEncargo)
        {
            try
            {

                using (_context = new SGPTEntidades())
                {
                    var registro = _context.sistemascontables.Select(entidad =>
                    new SistemaContableModelo
                    {
                        idsc = entidad.idsc,
                        idmoneda = entidad.idmoneda,
                        idnitcliente = entidad.idnitcliente,
                        ideef = entidad.ideef,
                        fechasc = entidad.fechasc,
                        digitoscuentamayorsc = entidad.digitoscuentamayorsc,
                        digitosrubroscontablessc = entidad.digitosrubroscontablessc,
                        periodoiniciosc = entidad.periodoiniciosc,
                        periodofinsc = entidad.periodofinsc,
                        estadosc = entidad.estadosc,
                        idencargodsc = entidad.idencargodsc,
                        //Carga de  entidades
                        estructuraEstadoFinancieroModelo = new EstructuraEstadoFinancieroModelo
                        {
                            id = entidad.estructuraestadofinanciero.ideef,
                            descripcion = entidad.estructuraestadofinanciero.descripcioneef,
                            sistema = entidad.estructuraestadofinanciero.sistemaeef,
                            estado = entidad.estructuraestadofinanciero.estadoeef
                        },

                        monedaModelo = new MonedaModelo
                        {
                            id = entidad.moneda.idmoneda,
                            descripcion = entidad.moneda.nombremoneda,
                            sistema = entidad.moneda.sistemamoneda,
                            estado = entidad.moneda.estadomoneda,
                            simbolomoneda = entidad.moneda.simbolomoneda
                        },
                        encargoModeloSc = new EncargoModelo
                        {
                            idencargo = entidad.encargo.idencargo,
                            idnitcliente = entidad.encargo.idnitcliente,
                            idta = entidad.encargo.idta,
                            fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                            tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                            etapaencargo = entidad.encargo.etapaencargo,
                            costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                            honorariosencargo = entidad.encargo.honorariosencargo,
                            fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                            fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                            estadoencargo = entidad.encargo.estadoencargo,
                            tipoAuditoriaModelo = new TipoAuditoriaModelo
                            {
                                id = entidad.encargo.tiposauditoria.idta,
                                descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                sistema = entidad.encargo.tiposauditoria.sistemata,
                                estado = entidad.encargo.tiposauditoria.estadota
                            },
                            descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta,
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadosc == "A" && x.idencargodsc == idEncargo).FirstOrDefault();
                    if (registro == null)
                    {
                        return registro;
                    }
                    else
                    {
                        registro.digitosCuentaMayorSc = new DigitosModelo(registro.digitoscuentamayorsc);
                        registro.digitosRubrosContablesSc = new DigitosModelo(registro.digitosrubroscontablessc);
                        registro.listaElementoModelo = ElementoModelo.GetAll(registro.idsc);//Guarda los elementos de  un sistema contable;
                        if (registro.idencargodsc == null)
                        {
                            registro.idencargodsc = 0;
                        }
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

        public static sistemascontable GetRegistroByIdEncargoCapaDatos(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.sistemascontables.Where(x => x.estadosc == "A" && x.idencargodsc == idEncargo).FirstOrDefault();
                    return registro;
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

        public static SistemaContableModelo GetRegistroIdClienteVacio(string idnitcliente)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.sistemascontables.Select(entidad =>
                    new SistemaContableModelo
                    {
                        idsc = entidad.idsc,
                        idmoneda = entidad.idmoneda,
                        idnitcliente = entidad.idnitcliente,
                        ideef = entidad.ideef,
                        fechasc = entidad.fechasc,
                        digitoscuentamayorsc = entidad.digitoscuentamayorsc,
                        digitosrubroscontablessc = entidad.digitosrubroscontablessc,
                        periodoiniciosc = entidad.periodoiniciosc,
                        periodofinsc = entidad.periodofinsc,
                        estadosc = entidad.estadosc,
                        idencargodsc = entidad.idencargodsc,
                        //Carga de  entidades
                        estructuraEstadoFinancieroModelo = new EstructuraEstadoFinancieroModelo
                        {
                            id = entidad.estructuraestadofinanciero.ideef,
                            descripcion = entidad.estructuraestadofinanciero.descripcioneef,
                            sistema = entidad.estructuraestadofinanciero.sistemaeef,
                            estado = entidad.estructuraestadofinanciero.estadoeef
                        },

                        monedaModelo = new MonedaModelo
                        {
                            id = entidad.moneda.idmoneda,
                            descripcion = entidad.moneda.nombremoneda,
                            sistema = entidad.moneda.sistemamoneda,
                            estado = entidad.moneda.estadomoneda,
                            simbolomoneda = entidad.moneda.simbolomoneda
                        },
                        encargoModeloSc = new EncargoModelo
                        {
                            idencargo = entidad.encargo.idencargo,
                            idnitcliente = entidad.encargo.idnitcliente,
                            idta = entidad.encargo.idta,
                            fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                            tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                            etapaencargo = entidad.encargo.etapaencargo,
                            costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                            honorariosencargo = entidad.encargo.honorariosencargo,
                            fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                            fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                            estadoencargo = entidad.encargo.estadoencargo,
                            tipoAuditoriaModelo = new TipoAuditoriaModelo
                            {
                                id = entidad.encargo.tiposauditoria.idta,
                                descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                sistema = entidad.encargo.tiposauditoria.sistemata,
                                estado = entidad.encargo.tiposauditoria.estadota
                            },
                            descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta,
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.estadosc == "A" && x.idnitcliente == idnitcliente && x.idencargodsc == null).FirstOrDefault();
                    if (registro == null)
                    {
                        return registro;
                    }
                    else
                    {
                        registro.digitosCuentaMayorSc = new DigitosModelo(registro.digitoscuentamayorsc);
                        registro.digitosRubrosContablesSc = new DigitosModelo(registro.digitosrubroscontablessc);
                        registro.listaElementoModelo = ElementoModelo.GetAll(registro.idsc);//Guarda los elementos de  un sistema contable;
                        if (registro.idencargodsc == null)
                        {
                            registro.idencargodsc = 0;
                        }
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
        #region Contar registros
        public static int ContarRegistros(int? idnitcliente)
            {
                throw new NotImplementedException();
            }

            public static int ContarRegistros()
            {
                throw new NotImplementedException();
            }


        #endregion

        #region Busqueda duplicados
        public static int contarRepetidoRegistro(SistemaContableModelo registro)
        {
            if (registro != null)
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.sistemascontables
                                   where ((p.idnitcliente == registro.idnitcliente) && (p.idencargodsc == registro.idencargodsc) )
                                   select p).ToList();
                    if (entidad == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return entidad.Count;
                    }
                }
            }
            else
            {
                return 0;
            }
        }

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

            public static bool UpdateBorradoModelo(SistemaContableModelo modelo, bool actualizar)
            {
                throw new NotImplementedException();
            }

            #endregion

            #region Limpieza de valores
            //Verifica si el registro existe dentro de los eliminados
            public static SistemaContableModelo Clear(SistemaContableModelo modelo)
            {
                throw new NotImplementedException();
            }
            public SistemaContableModelo()
            {
            
            idsc = 0;
            idmoneda = 1;
            idnitcliente = string.Empty;
            ideef = 2;
            idencargodsc=0;//Para comparar
            fechasc = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            digitoscuentamayorsc = 4;
            digitosrubroscontablessc = 2;
            //periodoiniciosc = new DateTime(DateTime.Now.Year, 1, 1).ToString("d");
            periodoiniciosc = "01/01";
            //periodofinsc = new DateTime(DateTime.Now.Year - 1, 12, 31).ToString("d");
            periodofinsc = "31/12";
            estadosc = "A";
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
            return digitosrubroscontablessc < digitoscuentamayorsc;
            //Digitos contables  debe ser mayor que las cuentas de mayor
        }

        private bool _IsValidPeriodoInicio()
        {
                Regex regex = new Regex("[0-3]{1}[1-9]{1}[/]{1}[0-1]{1}[0-9]{1}"); //regex that matches disallowed text
            var resultado=regex.IsMatch(periodoiniciosc);
            return regex.IsMatch(periodoiniciosc);

        }
        private bool _IsValidPeriodoFinalEInicial()
        {
            try
            {
                if ((int.Parse(periodoiniciosc.Substring(3, 2)) <= int.Parse(periodofinsc.Substring(3, 2))))
                    return true;
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }

        }
        private bool _IsValidPeriodoFinal()
        {
                Regex regex = new Regex("[0-3]{1}[1-9]{1}[/]{1}[0-1]{1}[0-9]{1}"); //regex that matches disallowed text
            var resultado = regex.IsMatch(periodofinsc);
            return regex.IsMatch(periodofinsc);

        }

        private bool _IsValidMesDia(string fecha)
        {
            try
            {
                if ((int.Parse(fecha.Substring(3, 2)) == 2))//Mes de febrero
                {
                    if ((int.Parse(fecha.Substring(0, 2)) <= 28) && (int.Parse(fecha.Substring(0, 2)) >= 1))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } 
                else
                {
                    if ((int.Parse(fecha.Substring(3, 2)) == 1)|| (int.Parse(fecha.Substring(3, 2)) == 3)|| (int.Parse(fecha.Substring(3, 2)) == 5)|| (int.Parse(fecha.Substring(3, 2)) == 7)|| (int.Parse(fecha.Substring(3, 2)) == 8)|| (int.Parse(fecha.Substring(3, 2)) == 10)|| (int.Parse(fecha.Substring(3, 2)) == 12))
                    {
                        if ((int.Parse(fecha.Substring(0, 2)) <= 31) && (int.Parse(fecha.Substring(0, 2)) >= 1))
                        {
                            return true;
                        }
                        else
                        {
                            if ((int.Parse(fecha.Substring(0, 2)) <= 30) && (int.Parse(fecha.Substring(0, 2)) >= 1))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "digitosrubroscontablessc":
                        if (!_IsValid())
                            result = "La cantidad  de dígitos de los rubros debe ser menor que la cantidad de dígitos de las cuentas!";
                        break;
                    case "digitoscuentamayorsc":
                        if (!_IsValid())
                            result = "La cantidad  de dígitos de cuentas debe ser mayor que la cantidad de dígitos de rubros!";
                        break;
                    case "periodoiniciosc":
                        if (periodoiniciosc.Length>0)
                        { 
                        if (periodoiniciosc.Length > 5)
                        {
                            result = "El máximo son 5 caracteres en formato dd/mm ejemplo 01/01";
                        }
                        else
                        {
                                if (!_IsValidPeriodoInicio())
                                { result = "Deben ser en formato dd/mm ejemplo 01/01"; }
                                else
                                {
                                    if (!_IsValidPeriodoFinalEInicial())
                                    {
                                        result = "El mes de inicio debe ser menor o igual que el mes de fin";
                                    }
                                    else
                                    {
                                        if (!_IsValidMesDia(periodoiniciosc))
                                        {
                                            result = "Los meses o los días no son válidos";
                                        }
                                    }
                                }
                        }
                        }
                        else
                        {
                            result = "Debe introducir un valor en formato dd/mm ejemplo 01/01";
                        }
                        break;
                    case "periodofinsc":
                        if (periodofinsc.Length > 0)
                        {
                            if (periodofinsc.Length > 5)
                            {
                                result = "El máximo son 5 caracteres en formato dd/mm ejemplo 31/12";
                            }
                            else
                            {
                                if (!_IsValidPeriodoFinal())
                                { result = "Deben ser en formato dd/mm ejemplo 31/12"; }
                                else
                                {
                                    if (!_IsValidPeriodoFinalEInicial())
                                    {
                                        result = "El mes de inicio debe ser menor o igual que el mes de fin";
                                    }
                                    else
                                    {
                                        if (!_IsValidMesDia(periodofinsc))
                                        {
                                            result = "Los meses o los días no son válidos";
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            result = "Debe introducir un valor en formato dd/mm ejemplo 31/12";
                        }
                        break;
                }
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
    public partial class SistemaContableModelo
    {

        //http://blogs.msmvps.com/otelis/2012/05/27/validaci-243-n-de-datos-de-entrada-con-enlace-a-datos-en-wpf/
        //http://docs.telerik.com/data-access/deprecated/developers-guide/code-generation/developer-guide-code-generation-implement-idataerrorinfo
        partial void ValidateProperty(string propertyName, ref string error)
        {
            error = string.Empty;
            switch (propertyName)
            {
                case "digitosrubroscontablessc":
                    if (!_IsValid())
                        error = "La cantidad  de dígitos de los rubros debe ser menor que la cantidad de dígitos de las cuentas!"; 
                    break;
                case "digitoscuentamayorsc":
                    if (!_IsValid())
                        error = "La cantidad  de dígitos de cuentas debe ser mayor que la cantidad de dígitos de las cuentas!";
                    break;
                case "periodoiniciosc":
                    if (!_IsValidPeriodoInicio())
                        error = "Deben ser en formato dd/mm ejemplo 01/01";
                    break;
                case "periodofinsc":
                    if (!_IsValidPeriodoFinal())
                        error = "Deben ser en formato dd/mm ejemplo 31/12";
                    break;
            }
        }
    }
}



