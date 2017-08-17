using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Model.Modelo.Encargos;
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
using SGPTWpf.Model.Modelo.programas;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion
{

    public class DetalleProgramaModelo : UIBase
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


        #region iddp
        public int _iddp;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int iddp
        {
            get { return _iddp; }
            set { _iddp = value; }
        }

        #endregion
        public Nullable<int> idtprocedimientodp
        {
            get { return GetValue(() => idtprocedimientodp); }
            set { SetValue(() => idtprocedimientodp, value); }
        }

        public int idprogramadp
        {
            get { return GetValue(() => idprogramadp); }
            set { SetValue(() => idprogramadp, value); }
        }

        public int? idpapelesdp
        {
            get { return GetValue(() => idpapelesdp); }
            set { SetValue(() => idpapelesdp, value); }
        }

        [DisplayName("Descripción de procedimiento")]
        [MaxLength(500, ErrorMessage = "Excede de 500 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripciondp
        {
            get { return GetValue(() => descripciondp); }
            set { SetValue(() => descripciondp, value); }
        }

        public string descripciondpSeleccion
        {
            get { return GetValue(() => descripciondpSeleccion); }
            set { SetValue(() => descripciondpSeleccion, value); }
        }

        public string descripcionPadre
        {
            get { return GetValue(() => descripcionPadre); }
            set { SetValue(() => descripcionPadre, value); }
        }

        public string fechacreadodp
        {
            get { return GetValue(() => fechacreadodp); }
            set { SetValue(() => fechacreadodp, value); }
        }

        public decimal ordendp
        {
            get { return GetValue(() => ordendp); }
            set { SetValue(() => ordendp, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd/mm/aaaa")]
        public string fechainidp
        {
            get { return GetValue(() => fechainidp); }
            set { SetValue(() => fechainidp, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechafindp
        {
            get { return GetValue(() => fechafindp); }
            set { SetValue(() => fechafindp, value); }
        }

        [DisplayName("Horas planificadas")]
        [Range(0, 100, ErrorMessage = "Las horas deben ser mayores de cero")]
        //[RegularExpression(@"^([0-9]{4}$", ErrorMessage = "Deben ser números no  letras")]

        public Nullable<decimal> horaplandp
        {
            get { return GetValue(() => horaplandp); }
            set { SetValue(() => horaplandp, value); }
        }
        [DisplayName("Horas ejecutadas")]
        [Range(0, 100, ErrorMessage = "Las horas deben ser mayores de cero")]
        public Nullable<decimal> horaejecdp
        {
            get { return GetValue(() => horaejecdp); }
            set { SetValue(() => horaejecdp, value); }
        }


        public string estadoprocedimientodp
        {
            get { return GetValue(() => estadoprocedimientodp); }
            set { SetValue(() => estadoprocedimientodp, value); }
        }

        [DisplayName("Descripción de procedimiento")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(500, ErrorMessage = "Excede de 500 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string comentariodp
        {
            get { return GetValue(() => comentariodp); }
            set { SetValue(() => comentariodp, value); }
        }


        public string estadodp
        {
            get { return GetValue(() => estadodp); }
            set { SetValue(() => estadodp, value); }
        }

        public string fechasupervision
        {
            get { return GetValue(() => fechasupervision); }
            set { SetValue(() => fechasupervision, value); }
        }
        public int? idvisitadp
        {
            get { return GetValue(() => idvisitadp); }
            set { SetValue(() => idvisitadp, value); }
        }

        //Almacena el procedimiento padre, si no hubiera queda vacio
        public int? idpadredp
        {
            get { return GetValue(() => idpadredp); }
            set { SetValue(() => idpadredp, value); }
        }

        public string ordenDhPresentacion
        {
            get { return GetValue(() => ordenDhPresentacion); }
            set { SetValue(() => ordenDhPresentacion, value); }
        }
        public Nullable<decimal> ordendpPadre
        {
            get { return GetValue(() => ordendpPadre); }
            set { SetValue(() => ordendpPadre, value); }
        }
        public string nombreVisita
        {
            get { return GetValue(() => nombreVisita); }
            set { SetValue(() => nombreVisita, value); }
        }
        public string nombreTipoProcedimiento
        {
            get { return GetValue(() => nombreTipoProcedimiento); }
            set { SetValue(() => nombreTipoProcedimiento, value); }
        }

        public string nombreDetallePadre
        {
            get { return GetValue(() => nombreDetallePadre); }
            set { SetValue(() => nombreDetallePadre, value); }
        }

        //Para distinguir entre registros ya con  id de la base y registros  pendientes de guardar
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        #region usuarioProgramaAccionModeloDp

        public UsuarioProgramaAccionModelo _usuarioProgramaAccionModeloDp;
        public UsuarioProgramaAccionModelo usuarioProgramaAccionModeloDp
        {
            get { return _usuarioProgramaAccionModeloDp; }
            set { _usuarioProgramaAccionModeloDp = value; }
        }

        #endregion
        public string usuarioModificoDp
        {
            get { return GetValue(() => usuarioModificoDp); }
            set { SetValue(() => usuarioModificoDp, value); }
        }

        public int? idusuarioejecuto   {  get { return GetValue(() => idusuarioejecuto); }  set { SetValue(() => idusuarioejecuto, value); }
        }

        public UsuarioModelo usuarioModeloDp
        {
            get { return GetValue(() => usuarioModeloDp); }
            set { SetValue(() => usuarioModeloDp, value); }
        }
        public string fechaUltimaModificacionProgramaDp
        {
            get { return GetValue(() => fechaUltimaModificacionProgramaDp); }
            set { SetValue(() => fechaUltimaModificacionProgramaDp, value); }
        }

        public string referenciaPtDp
        {
            get { return GetValue(() => referenciaPtDp); }
            set { SetValue(() => referenciaPtDp, value); }
        }
        public string referenciaPt
        {
            get { return GetValue(() => referenciaPt); }
            set { SetValue(() => referenciaPt, value); }
        }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public bool IsEditable
        {
            get { return GetValue(() => IsEditable); }
            set { SetValue(() => IsEditable, value); }
        }

        
        public int? isuso   {  get { return GetValue(() => isuso); }  set { SetValue(() => isuso, value); }}
        public int? idrepositorio   {  get { return GetValue(() => idrepositorio); }  set { SetValue(() => idrepositorio, value); }}
        public int? idcedula   {  get { return GetValue(() => idcedula); }  set { SetValue(() => idcedula, value); }}
        public int? idgenerico   {  get { return GetValue(() => idgenerico); }  set { SetValue(() => idgenerico, value); }}
        public string tabla   {  get { return GetValue(() => tabla); }  set { SetValue(() => tabla, value); }}
        public int? iddcedulas   {  get { return GetValue(() => iddcedulas); }  set { SetValue(() => iddcedulas, value); }}
        public int? idnotaspt   {  get { return GetValue(() => idnotaspt); }  set { SetValue(() => idnotaspt, value); }}
        public int? idagenda   {  get { return GetValue(() => idagenda); }  set { SetValue(() => idagenda, value); }}

        public bool isBotonReferenciar
        {
            get { return GetValue(() => isBotonReferenciar); }
            set { SetValue(() => isBotonReferenciar, value); }
        }

        #endregion

        #region colecciones virtuales

        public virtual EtapaEncargoModelo modeloEstadoProcedimientoDp
        {
            get { return GetValue(() => modeloEstadoProcedimientoDp); }
            set { SetValue(() => modeloEstadoProcedimientoDp, value); }
        }

        public string nombreEstadoProcedimientoDp
        {
            get { return GetValue(() => nombreEstadoProcedimientoDp); }
            set { SetValue(() => nombreEstadoProcedimientoDp, value); }
        }

        public virtual DetalleProgramaModelo DetalleProgramaModeloPadre
        {
            get { return GetValue(() => DetalleProgramaModeloPadre); }
            set { SetValue(() => DetalleProgramaModeloPadre, value); }
        }


        public virtual TipoProcedimientoModelo tipoProcedimientoModelo
        {
            get { return GetValue(() => tipoProcedimientoModelo); }
            set { SetValue(() => tipoProcedimientoModelo, value); }
        }

        public virtual VisitaModelo visitaModelo
        {
            get { return GetValue(() => visitaModelo); }
            set { SetValue(() => visitaModelo, value); }
        }

        public virtual ObservableCollection<DetalleProgramaModelo> listaEntidadSeleccion
        {
              get { return GetValue(() => listaEntidadSeleccion); }
                set { SetValue(() => listaEntidadSeleccion, value); }          
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(DetalleProgramaModelo modelo, Boolean insertar,int idEncargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleprogramas', 'iddp'), (SELECT MAX(iddp) FROM sgpt.detalleprogramas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detalleprograma
                        {
                            //iddp = modelo.iddp,
                            idtprocedimientodp = modelo.idtprocedimientodp,
                            idprogramadp = modelo.idprogramadp,
                            idpapelesdp = modelo.idpapelesdp,
                            descripciondp = modelo.descripciondp,
                            fechacreadodp = modelo.fechacreadodp,
                            ordendp = modelo.ordendp,
                            fechainidp = modelo.fechainidp,
                            fechafindp = modelo.fechafindp,
                            horaplandp = modelo.horaplandp,
                            horaejecdp = modelo.horaejecdp,
                            estadoprocedimientodp = modelo.estadoprocedimientodp,
                            comentariodp = modelo.comentariodp,
                            estadodp = modelo.estadodp,
                            fechasupervision = modelo.fechasupervision,
                            idvisitadp = modelo.idvisitadp,
                            idpadredp = modelo.idpadredp,

                            isuso = modelo.isuso,
                            idrepositorio = modelo.idrepositorio,
                            idcedula = modelo.idcedula,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            iddcedulas = modelo.iddcedulas,
                            idnotaspt = modelo.idnotaspt,
                            idagenda = modelo.idagenda,

                        };
                        _context.detalleprogramas.Add(tablaDestino);
                        _context.SaveChanges();
                        if (!(modelo.idpadredp == null))
                        {
                            modelo.nombreDetallePadre = DetalleProgramaModelo.FindNombreById(modelo.idpadredp);
                            modelo.ordendpPadre = DetalleProgramaModelo.FindOrdenPadreById(modelo.idpadredp);
                            modelo.ordenDhPresentacion = MetodosModelo.ordenConversion(modelo.ordendp);
                        }
                        //ReordenaSubRegistros(tablaDestino.iddp);
                        modelo.guardadoBase = true;
                        modelo.iddp = tablaDestino.iddp;
                        if (!(modelo.idtprocedimientodp == null))
                        {
                            modelo.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(modelo.idtprocedimientodp);
                        }
                        if (!(modelo.idvisitadp == null))
                        {
                            modelo.nombreVisita = VisitaModelo.FindNombreById(modelo.idvisitadp);
                        }
                        //Creación de registro auxiliar de acción realizada
                        modelo.usuarioProgramaAccionModeloDp.idprograma = modelo.idprogramadp;
                        modelo.usuarioProgramaAccionModeloDp.idusuarioupa = modelo.usuarioModeloDp.idUsuario;
                        modelo.usuarioProgramaAccionModeloDp.iddp = modelo.iddp;
                        modelo.usuarioProgramaAccionModeloDp.idencargo = idEncargo;
                        result = true;
                        if (UsuarioProgramaAccionModelo.InsertByDetallePrograma(modelo.usuarioProgramaAccionModeloDp,idEncargo))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error al insertar el detalle de la accion  en programa ");
                        }
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar detalle programa \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static int InsertbyImportacion(DetalleProgramaModelo modelo,int idEncargo)
        {
            int result = 0;//Valor por defecto
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleprogramas', 'iddp'), (SELECT MAX(iddp) FROM sgpt.detalleprogramas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detalleprograma
                        {
                            //iddp = modelo.iddp,
                            idtprocedimientodp = modelo.idtprocedimientodp,
                            idprogramadp = modelo.idprogramadp,
                            //idpapelesdp = modelo.idpapelesdp,
                            descripciondp = modelo.descripciondp,
                            fechacreadodp = modelo.fechacreadodp,
                            ordendp = modelo.ordendp,
                            fechainidp = modelo.fechainidp,
                            fechafindp = modelo.fechafindp,
                            horaplandp = modelo.horaplandp,
                            horaejecdp = modelo.horaejecdp,
                            estadoprocedimientodp = modelo.estadoprocedimientodp,
                            comentariodp = modelo.comentariodp,
                            estadodp = modelo.estadodp,
                            fechasupervision = modelo.fechasupervision,
                            idvisitadp = modelo.idvisitadp,
                            //idpadredp = modelo.idpadredp,
                            //isuso = modelo.isuso,
                            //idrepositorio = modelo.idrepositorio,
                            //idcedula = modelo.idcedula,
                            //idgenerico = modelo.idgenerico,
                            //tabla = modelo.tabla,
                            //iddcedulas = modelo.iddcedulas,
                            //idnotaspt = modelo.idnotaspt,
                            //idagenda = modelo.idagenda,

                        };

                        _context.detalleprogramas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.iddp = tablaDestino.iddp;
                        //Creación de registro auxiliar de acción realizada
                        modelo.usuarioProgramaAccionModeloDp.idprograma = modelo.idprogramadp;
                        modelo.usuarioProgramaAccionModeloDp.idusuarioupa = modelo.usuarioModeloDp.idUsuario;
                        modelo.usuarioProgramaAccionModeloDp.iddp = modelo.iddp;
                        modelo.usuarioProgramaAccionModeloDp.idencargo = idEncargo;
                        if (UsuarioProgramaAccionModelo.InsertByDetallePrograma(modelo.usuarioProgramaAccionModeloDp,idEncargo))
                        {
                            result = 1;//éxito completo
                        }
                        else
                        {
                            result=2;//Error al  insertar registro  auxiliar
                        }
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar detalle programa \n" + e);
                    return 3;//Hay una excepcion
                    throw;
                }
                //    //http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
            }
            else
            {
                return result;
            }
        }
        public static bool InsertByPrograma(DetalleProgramaModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleprogramas', 'iddp'), (SELECT MAX(iddp) FROM sgpt.detalleprogramas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detalleprograma
                        {
                            //iddp = modelo.iddp,
                            idtprocedimientodp = modelo.idtprocedimientodp,
                            idprogramadp = modelo.idprogramadp,
                            idpapelesdp = modelo.idpapelesdp,
                            descripciondp = modelo.descripciondp,
                            fechacreadodp = modelo.fechacreadodp,
                            ordendp = modelo.ordendp,
                            fechainidp = modelo.fechainidp,
                            fechafindp = modelo.fechafindp,
                            horaplandp = modelo.horaplandp,
                            horaejecdp = modelo.horaejecdp,
                            estadoprocedimientodp = modelo.estadoprocedimientodp,
                            comentariodp = modelo.comentariodp,
                            estadodp = modelo.estadodp,
                            fechasupervision = modelo.fechasupervision,
                            idvisitadp = modelo.idvisitadp,
                            idpadredp = modelo.idpadredp,
                        };
                        if (tablaDestino.idtprocedimientodp == 0)
                        {
                            tablaDestino.idtprocedimientodp = null;
                        }
                        _context.detalleprogramas.Add(tablaDestino);
                        _context.SaveChanges();
                        if (!(modelo.idpadredp == null))
                        {
                            modelo.nombreDetallePadre = DetalleProgramaModelo.FindNombreById(modelo.idpadredp);
                            modelo.ordendpPadre = DetalleProgramaModelo.FindOrdenPadreById(modelo.idpadredp);
                        }
                        //ReordenaSubRegistros(tablaDestino.iddp);
                        modelo.guardadoBase = true;
                        modelo.iddp = tablaDestino.iddp;
                        if (!(modelo.idtprocedimientodp == null))
                        {
                            modelo.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(modelo.idtprocedimientodp);
                        }
                        if (!(modelo.idvisitadp == null))
                        {
                            modelo.nombreVisita = VisitaModelo.FindNombreById(modelo.idvisitadp);
                        }
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    ////http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
                    //foreach (var eve in e.EntityValidationErrors)
                    //{
                    //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    //    foreach (var ve in eve.ValidationErrors)
                    //    {
                    //        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                    //            ve.PropertyName, ve.ErrorMessage);
                    //    }
                    //}
                    //throw;
                    MessageBox.Show("Exception en insertar detalle cuestionario : " + e);
                    return false;//Hay una excepcion
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        //Devuelve el registro buscado con base al indice
        public static DetalleProgramaModelo Find(int id)
        {
            var entidad = new DetalleProgramaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detalleprograma modelo = _context.detalleprogramas.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.iddp = modelo.iddp;
                        entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                        entidad.idprogramadp = modelo.idprogramadp;
                        entidad.idpapelesdp = modelo.idpapelesdp;
                        entidad.descripciondp = modelo.descripciondp;
                        entidad.fechacreadodp = modelo.fechacreadodp;
                        entidad.ordendp = modelo.ordendp;
                        entidad.fechainidp = modelo.fechainidp;
                        entidad.fechafindp = modelo.fechafindp;
                        entidad.horaplandp = modelo.horaplandp;
                        entidad.horaejecdp = modelo.horaejecdp;
                        entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                        entidad.comentariodp = modelo.comentariodp;
                        entidad.estadodp = modelo.estadodp;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.idvisitadp = modelo.idvisitadp;
                        entidad.idpadredp = modelo.idpadredp;
                        MetodosModelo.ordenConversion(modelo.ordendp);
                        entidad.fechainidp = modelo.fechainidp;
                        entidad.fechafindp = modelo.fechafindp;
                        entidad.horaejecdp = modelo.horaejecdp;
                        entidad.horaplandp = modelo.horaplandp;
                        entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordendp);
                        if (!(entidad.idpadredp == null))
                        {
                            entidad.nombreDetallePadre = DetalleProgramaModelo.FindNombreById(entidad.idpadredp);
                            entidad.ordendpPadre = DetalleProgramaModelo.FindOrdenPadreById(entidad.idpadredp);
                            entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordendp);
                        }
                        if (!(entidad.idtprocedimientodp == null))
                        {
                            entidad.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(entidad.idtprocedimientodp);
                        }
                        if (!(entidad.idvisitadp == null))
                        {
                            entidad.nombreVisita = VisitaModelo.FindNombreById(entidad.idvisitadp);
                        }
                        entidad.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(entidad.estadoprocedimientodp);
                        entidad.nombreEstadoProcedimientoDp = entidad.modeloEstadoProcedimientoDp.etapaencargo;
                        entidad.isuso = modelo.isuso;
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idcedula = modelo.idcedula;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.iddcedulas = modelo.iddcedulas;
                        entidad.idnotaspt = modelo.idnotaspt;
                        entidad.idagenda = modelo.idagenda;

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

        //Devuelve el maximo del orden de un registro
        public static Nullable<decimal> FindOrden(int idprogramadp)
        {
            Nullable<decimal> ordenMaximo = 0;
            if (!(idprogramadp == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    ordenMaximo = _context.detalleprogramas.Where(x => x.idprogramadp == idprogramadp).Max(p => p.ordendp);
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
                    string commandString = String.Format("DELETE FROM sgpt.detalleprogramas WHERE iddp={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static DetalleProgramaModelo GetRegistro(string id)
        {
            var entidad = new DetalleProgramaModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidad = null;
                    }
                    detalleprograma modelo = _context.detalleprogramas.Find(id);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.iddp = modelo.iddp;
                        entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                        entidad.idprogramadp = modelo.idprogramadp;
                        entidad.idpapelesdp = modelo.idpapelesdp;
                        entidad.descripciondp = modelo.descripciondp;
                        entidad.fechacreadodp = modelo.fechacreadodp;
                        entidad.ordendp = modelo.ordendp;
                        entidad.fechainidp = modelo.fechainidp;
                        entidad.fechafindp = modelo.fechafindp;
                        entidad.horaplandp = modelo.horaplandp;
                        entidad.horaejecdp = modelo.horaejecdp;
                        entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                        entidad.comentariodp = modelo.comentariodp;
                        entidad.estadodp = modelo.estadodp;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.idvisitadp = modelo.idvisitadp;
                        entidad.idpadredp = modelo.idpadredp;
                        entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordendp);
                        entidad.fechainidp = modelo.fechainidp;
                        entidad.fechafindp = modelo.fechafindp;
                        entidad.horaejecdp = modelo.horaejecdp;
                        entidad.horaplandp = modelo.horaplandp;
                        if (!(entidad.idpadredp == null))
                        {
                            entidad.nombreDetallePadre = DetalleProgramaModelo.FindNombreById(entidad.idpadredp);
                            entidad.ordendpPadre = DetalleProgramaModelo.FindOrdenPadreById(entidad.idpadredp);
                            entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordendp);
                        }
                        if (!(entidad.idtprocedimientodp == null))
                        {
                            entidad.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(entidad.idtprocedimientodp);
                        }
                        if (!(entidad.idvisitadp == null))
                        {
                            entidad.nombreVisita = VisitaModelo.FindNombreById(entidad.idvisitadp);
                        }
                        entidad.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(entidad.estadoprocedimientodp);
                        entidad.nombreEstadoProcedimientoDp = entidad.modeloEstadoProcedimientoDp.etapaencargo;
                        entidad.isuso = modelo.isuso;
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idcedula = modelo.idcedula;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.iddcedulas = modelo.iddcedulas;
                        entidad.idnotaspt = modelo.idnotaspt;
                        entidad.idagenda = modelo.idagenda;

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
                return entidad;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleProgramaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    detalleprograma entidad = _context.detalleprogramas.Find(id);
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
                    var modelo = new DetalleProgramaModelo();
                    detalleprograma entidad = _context.detalleprogramas.Find(id);
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
                    var modelo = new DetalleProgramaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detalleprogramas
                            .Where(b => b.estadodp == "B")
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
                    detalleprograma entidad = _context.detalleprogramas.Find(id);
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
                    return nombre = _context.detalleprogramas.Find(id).descripciondp;
                }
            }
            else
            {
                return nombre;
            }
        }
        public static Nullable<decimal> FindOrdenPadreById(int? id)
        {
            Nullable<decimal> nombre = 0;
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    return nombre = _context.detalleprogramas.Find(id).ordendp;
                }
            }
            else
            {
                return nombre;
            }
        }
        //Para realizar busquedas de texto

        public static void UpdateModelo(DetalleProgramaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detalleprograma entidad = _context.detalleprogramas.Find(modelo.iddp);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.iddp = modelo.iddp;
                        entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                        entidad.idprogramadp = modelo.idprogramadp;
                        entidad.idpapelesdp = modelo.idpapelesdp;
                        entidad.descripciondp = modelo.descripciondp;
                        entidad.fechacreadodp = modelo.fechacreadodp;
                        entidad.ordendp = modelo.ordendp;
                        entidad.fechainidp = modelo.fechainidp;
                        entidad.fechafindp = modelo.fechafindp;
                        entidad.horaplandp = modelo.horaplandp;
                        entidad.horaejecdp = modelo.horaejecdp;
                        entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                        entidad.comentariodp = modelo.comentariodp;
                        entidad.estadodp = modelo.estadodp;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.idvisitadp = modelo.idvisitadp;
                        entidad.idpadredp = modelo.idpadredp;
                        entidad.fechainidp = modelo.fechainidp;
                        entidad.fechafindp = modelo.fechafindp;
                        entidad.horaejecdp = modelo.horaejecdp;
                        entidad.horaplandp = modelo.horaplandp;

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
        public static void UpdateModeloReodenar(DetalleProgramaModelo modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {

                        string commandString = String.Format("UPDATE sgpt.detalleprogramas SET ordendp = {0} WHERE iddp = {1};", modelo.ordendp, modelo.iddp);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                    }
                }
                else
                {
                    //No regresa nada
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("exception en actualizar el orden: \n" + e);
            }
        }

        public static bool UpdateModeloByImportacion(DetalleProgramaModelo modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detalleprogramas SET idpadredp = {0} WHERE iddp = {1};", modelo.idpadredp, modelo.iddp);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                       /* detalleprograma entidad = _context.detalleprogramas.Find(modelo.iddp);
                        if (entidad == null)
                        {
                            //Error no se encontro
                        }
                        else
                        {
                            //entidad.iddp = modelo.iddp;
                            //entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                            //entidad.idprogramadp = modelo.idprogramadp;
                            //entidad.idpapelesdp = modelo.idpapelesdp;
                            //entidad.descripciondp = modelo.descripciondp;
                            //entidad.fechacreadodp = modelo.fechacreadodp;
                            //entidad.ordendp = modelo.ordendp;
                            //entidad.fechainidp = modelo.fechainidp;
                            //entidad.fechafindp = modelo.fechafindp;
                            //entidad.horaplandp = modelo.horaplandp;
                            //entidad.horaejecdp = modelo.horaejecdp;
                            //entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                            //entidad.comentariodp = modelo.comentariodp;
                            //entidad.estadodp = modelo.estadodp;
                            //entidad.fechasupervision = modelo.fechasupervision;
                            //entidad.idvisitadp = modelo.idvisitadp;
                            entidad.idpadredp = modelo.idpadredp;
                        }
                        _context.Entry(entidad).State = EntityState.Modified;
                        _context.SaveChanges();*/
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
                MessageBox.Show("Exception en insertar actualizacion  del principal \n" + e);
                throw;
            }
        }
        public static bool UpdateModeloByImportacion(detalleprograma modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detalleprogramas SET idpadredp = {0} WHERE iddp = {1};", modelo.idpadredp, modelo.iddp);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();

                        /* detalleprograma entidad = _context.detalleprogramas.Find(modelo.iddp);
                         if (entidad == null)
                         {
                             //Error no se encontro
                         }
                         else
                         {
                             //entidad.iddp = modelo.iddp;
                             //entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                             //entidad.idprogramadp = modelo.idprogramadp;
                             //entidad.idpapelesdp = modelo.idpapelesdp;
                             //entidad.descripciondp = modelo.descripciondp;
                             //entidad.fechacreadodp = modelo.fechacreadodp;
                             //entidad.ordendp = modelo.ordendp;
                             //entidad.fechainidp = modelo.fechainidp;
                             //entidad.fechafindp = modelo.fechafindp;
                             //entidad.horaplandp = modelo.horaplandp;
                             //entidad.horaejecdp = modelo.horaejecdp;
                             //entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                             //entidad.comentariodp = modelo.comentariodp;
                             //entidad.estadodp = modelo.estadodp;
                             //entidad.fechasupervision = modelo.fechasupervision;
                             //entidad.idvisitadp = modelo.idvisitadp;
                             entidad.idpadredp = modelo.idpadredp;
                         }
                         _context.Entry(entidad).State = EntityState.Modified;
                         _context.SaveChanges();*/
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
                MessageBox.Show("Exception en insertar actualizacion  del principal \n" + e);
                throw;
            }
        }
        public static bool UpdateModelo(DetalleProgramaModelo modelo, UsuarioModelo usuarioModelo,int idEncargo)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        string rolAccion = "M";
                        detalleprograma entidad = _context.detalleprogramas.Find(modelo.iddp);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddp = modelo.iddp; no puede cambiar
                            if (!(entidad.idpapelesdp == modelo.idpapelesdp))
                            {
                                //entidad.idpapelesdp = modelo.idpapelesdp;
                                rolAccion = "R";
                                cambio = true;
                            }
                            if (!(entidad.idtprocedimientodp == modelo.idtprocedimientodp))
                            {
                                //entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                                cambio = true;
                            }
                            //entidad.idprogramadp = modelo.idprogramadp; No puede cambiar
                            if (!(entidad.descripciondp.ToUpper() == modelo.descripciondp.ToUpper()))
                            {
                                //entidad.descripciondp = modelo.descripciondp;
                                cambio = true;
                            }
                            if (!(entidad.fechacreadodp == modelo.fechacreadodp.ToString()))
                            {
                                //entidad.fechacreadodp = modelo.fechacreadodp.ToString();
                                cambio = true;
                            }
                            if (!(entidad.ordendp == modelo.ordendp))
                            {
                                //entidad.ordendp = modelo.ordendp;
                                cambio = true;
                            }
                            if (!(entidad.idvisitadp == modelo.idvisitadp))
                            {
                                //entidad.idvisitadp = modelo.idvisitadp;
                                cambio = true;
                            }
                            if (!(entidad.idpadredp == modelo.idpadredp))
                            {
                                //entidad.idpadredp = modelo.idpadredp;
                                cambio = true;
                            }
                            if (!(entidad.comentariodp == modelo.comentariodp))
                            {
                                //entidad.comentariodp = modelo.comentariodp;
                                cambio = true;
                                rolAccion = "M";
                            }
                            //Datos ejecucion
                            if (!(entidad.idpapelesdp == modelo.idpapelesdp))
                            {
                                //entidad.comentariodp = modelo.comentariodp;
                                cambio = true;
                                rolAccion = "M";
                            }
                            if (!(entidad.horaejecdp == modelo.horaejecdp))
                            {
                                //entidad.horaejecdp = modelo.horaejecdp;
                                cambio = true;
                                rolAccion = "M";
                            }
                            if (!(entidad.fechainidp == modelo.fechainidp))
                            {
                                //entidad.fechainidp = modelo.fechainidp;
                                cambio = true;
                                rolAccion = "M";
                            }
                            if (!(entidad.fechafindp == modelo.fechafindp))
                            {
                                //entidad.fechafindp = modelo.fechafindp;
                                cambio = true;
                                rolAccion = "M";
                            }
                            if (!(entidad.fechasupervision == modelo.fechasupervision))
                            {
                                //entidad.fechasupervision = modelo.fechasupervision;
                                cambio = true;
                                rolAccion = "M";
                            }                            
                            //entidad.estadoprocedimientodp = modelo.estadoprocedimientodp; //No puede cambiar se establece al crearlo
                            //entidad.estadodp = modelo.estadodp; //No puede cambiar se cambia al crear o eliminar
                            if (cambio)
                            {
                                //entidad.iddp = modelo.iddp;
                                entidad.iddp = modelo.iddp;
                                entidad.idtprocedimientodp = modelo.idtprocedimientodp;
                                entidad.idprogramadp = modelo.idprogramadp;
                                entidad.idpapelesdp = modelo.idpapelesdp;
                                entidad.descripciondp = modelo.descripciondp;
                                entidad.fechacreadodp = modelo.fechacreadodp;
                                entidad.ordendp = modelo.ordendp;
                                if (!string.IsNullOrEmpty(modelo.fechainidp))
                                {
                                    entidad.fechainidp = MetodosModelo.homologacionFecha(modelo.fechainidp);
                                }
                                if (!string.IsNullOrEmpty(modelo.fechafindp))
                                {
                                    entidad.fechafindp = MetodosModelo.homologacionFecha(modelo.fechafindp);
                                }
                                entidad.horaplandp = modelo.horaplandp;
                                entidad.horaejecdp = modelo.horaejecdp;
                                entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                                entidad.comentariodp = modelo.comentariodp;
                                entidad.estadodp = modelo.estadodp;
                                if (!string.IsNullOrEmpty(modelo.fechasupervision))
                                {
                                    entidad.fechasupervision = MetodosModelo.homologacionFecha(modelo.fechasupervision);
                                }
                                entidad.idvisitadp = modelo.idvisitadp;
                                entidad.idpadredp = modelo.idpadredp;
                                entidad.horaejecdp = modelo.horaejecdp;
                                entidad.horaplandp = modelo.horaplandp;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Crear modificacion del registro 
                                UsuarioProgramaAccionModelo temporal = new UsuarioProgramaAccionModelo();
                                temporal.idusuarioupa = usuarioModelo.idUsuario;
                                temporal.idprograma = modelo.idprogramadp;
                                temporal.iddp = modelo.iddp;
                                temporal.nombreUsuario = usuarioModelo.inicialesusuario;
                                temporal.rolupa = rolAccion;
                                temporal.idencargo = idEncargo;
                                //Creación de registro auxiliar de acción realizada
                                if (UsuarioProgramaAccionModelo.InsertByPrograma(temporal,idEncargo))
                                {
                                    return true; //éxito completo
                                }
                                else
                                {
                                    //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                                    return true;//No se inserto el registro auxiliar
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
                        MessageBox.Show("Exception en actualizar entidad Detalle programa \n" + e);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateModeloCierreProcedimiento(DetalleProgramaModelo modelo, UsuarioModelo usuarioModelo,int idEncargo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detalleprogramas SET estadoprocedimientodp = 'T',idusuarioejecuto={0} WHERE iddp = {1};", usuarioModelo.idUsuario,  modelo.iddp);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        modelo.estadoprocedimientodp = "T";
                        modelo.idusuarioejecuto = usuarioModelo.idUsuario;
                        modelo.usuarioModificoDp = usuarioModelo.inicialesusuario;
                        //Crear modificacion del registro 
                        UsuarioProgramaAccionModelo temporal = new UsuarioProgramaAccionModelo();
                        temporal.idusuarioupa = usuarioModelo.idUsuario;
                        temporal.idprograma = modelo.idprogramadp;
                        temporal.iddp = modelo.iddp;
                        temporal.nombreUsuario = usuarioModelo.inicialesusuario;
                        temporal.rolupa = "E";
                        temporal.idencargo = idEncargo;
                        //Creación de registro auxiliar de acción realizada
                        if (UsuarioProgramaAccionModelo.InsertByPrograma(temporal,idEncargo))
                        {
                            //return true; //éxito completo
                        }
                        else
                        {
                            //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                            //return true;//No se inserto el registro auxiliar
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
                MessageBox.Show("Exception en insertar actualizacion  cierre de procedimiento : \n" + e);
                throw;
            }
        }
        public static bool UpdateModeloCierre(DetalleProgramaModelo modelo, UsuarioModelo usuarioModelo,int idEncargo)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        string rolAccion = "E";
                        detalleprograma entidad = _context.detalleprogramas.Find(modelo.iddp);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddp = modelo.iddp; no puede cambiar
                            if (!(entidad.idpapelesdp == modelo.idpapelesdp))
                            {
                                //entidad.idpapelesdp = modelo.idpapelesdp;
                                cambio = true;
                            }
                            if (!(entidad.comentariodp == modelo.comentariodp))
                            {
                                //entidad.comentariodp = modelo.comentariodp;
                                cambio = true;
                            }
                            //Datos ejecucion
                            if (!(entidad.horaejecdp == modelo.horaejecdp))
                            {
                                //entidad.horaejecdp = modelo.horaejecdp;
                                cambio = true;
                            }
                            if (!(entidad.fechainidp == modelo.fechainidp))
                            {
                                //entidad.fechainidp = modelo.fechainidp;
                                cambio = true;
                            }
                            if (!(entidad.fechafindp == modelo.fechafindp))
                            {
                                //entidad.fechafindp = modelo.fechafindp;
                                cambio = true;
                            }
                            if (!(entidad.fechasupervision == modelo.fechasupervision))
                            {
                                //entidad.fechasupervision = modelo.fechasupervision;
                                cambio = true;
                            }
                            if (entidad.idusuarioejecuto != modelo.idusuarioejecuto) { cambio = true; }

                            if (cambio)
                            {
                                entidad.idprogramadp = modelo.idprogramadp;
                                entidad.idpapelesdp = modelo.idpapelesdp;
                                modelo.estadoprocedimientodp = "P";
                                if (!string.IsNullOrEmpty(modelo.fechainidp))
                                {
                                    entidad.fechainidp = MetodosModelo.homologacionFecha(modelo.fechainidp);
                                }
                                if (!string.IsNullOrEmpty(modelo.fechafindp))
                                {
                                    entidad.fechafindp = MetodosModelo.homologacionFecha(modelo.fechafindp);
                                }
                                entidad.horaejecdp = modelo.horaejecdp;
                                entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                                entidad.comentariodp = modelo.comentariodp;
                                if (!string.IsNullOrEmpty(modelo.fechasupervision))
                                {
                                    entidad.fechasupervision = MetodosModelo.homologacionFecha(modelo.fechasupervision);
                                }
                                entidad.horaejecdp = modelo.horaejecdp;
                                entidad.idusuarioejecuto = usuarioModelo.idUsuario;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                if (modelo.usuarioModificoDp == "" && modelo.idusuarioejecuto!=null && modelo.idusuarioejecuto!=0)
                                {
                                    modelo.usuarioModificoDp = usuarioModelo.inicialesusuario;
                                }
                                //Crear modificacion del registro 
                                UsuarioProgramaAccionModelo temporal = new UsuarioProgramaAccionModelo();
                                temporal.idusuarioupa = usuarioModelo.idUsuario;
                                temporal.idprograma = modelo.idprogramadp;
                                temporal.iddp = modelo.iddp;
                                temporal.nombreUsuario = usuarioModelo.inicialesusuario;
                                temporal.rolupa = rolAccion;
                                temporal.idencargo = idEncargo;
                                //Creación de registro auxiliar de acción realizada
                                if (UsuarioProgramaAccionModelo.InsertByPrograma(temporal,idEncargo))
                                {
                                    return true; //éxito completo
                                }
                                else
                                {
                                    //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                                    return true;//No se inserto el registro auxiliar
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
                        MessageBox.Show("Exception en actualizar entidad Detalle programa \n" + e);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

       public static bool UpdateModeloReferencia(DetalleProgramaModelo modelo, UniversalPTModelo papel)
        {
            if ((modelo != null && papel != null && modelo.iddp != 0 && papel.idUpt != 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                            modelo.referenciaPtDp = papel.referenciaTpt;
                                if (string.IsNullOrEmpty(papel.referenciaTpt))
                                {
                                modelo.referenciaPtDp = "Pendiente";
                                }
                            string commandString = String.Format("UPDATE sgpt.detalleprogramas SET tabla = '{0}',idgenerico={1} WHERE iddp={2};", papel.tablaUpt, papel.idOrigenUpt, modelo.iddp);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //    _context.SaveChanges();
                            modelo.guardadoBase = true;
                            //Reordenar((int)modelo.iddp);
                            return true;
                        //}
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("exception en actualizar el orden: \n" + e);
                    return false;
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
                            //detalleprograma entidad = _context.detalleprogramas.Find(id);
                            //Borrado del detalle de programas
                            var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByDetallePrograma(id);
                            if (listaDetalleAcciones.Count > 0)
                            {
                                foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                                {
                                    UsuarioProgramaAccionModelo.DeleteBorradoLogico(item.idupa);
                                }
                            }
                            string commandString = String.Format("UPDATE sgpt.detalleprogramas SET estadodp = 'B' WHERE iddp={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //entidad.estadodp = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del detalle de programa\n" + e);
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
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        int idHijo;
                        int cantidad;
                        //detalleprograma entidad = _context.detalleprogramas.Find(id);
                        //Borrado del detalle de programas
                        var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByDetallePrograma(id);
                        if (listaDetalleAcciones.Count > 0)
                        {
                            foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                            {
                                UsuarioProgramaAccionModelo.Delete(item.idupa);
                            }
                        }
                        cantidad = _context.detalleprogramas.Count(j => j.idpadredp == id);
                        while (_context.detalleprogramas.Count(j => j.idpadredp == id) > 0)
                        {
                                idHijo = _context.detalleprogramas.Where(j => j.idpadredp == id).FirstOrDefault().iddp;
                                DetalleProgramaModelo.Delete(idHijo);
                        }
                            //int idHijo = _context.detalleprogramas.Single(j => j.idpadredp == id).iddp;
                            //No tiene hijos se puede borrar
                            string commandString = String.Format("DELETE FROM sgpt.detalleprogramas WHERE iddp={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle \n" + e);
                throw;
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
                        int idHijo;
                        //detalleprograma entidad = _context.detalleprogramas.Find(id);
                        //Borrado del detalle de programas
                            var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByDetallePrograma(id);
                            if (listaDetalleAcciones.Count > 0)
                            {
                                foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                                {
                                    UsuarioProgramaAccionModelo.Delete(item.idupa);
                                }
                            }
                            while (_context.detalleprogramas.Count(j => j.idpadredp == id) > 0)
                            {
                                idHijo = _context.detalleprogramas.Where(j => j.idpadredp == id).FirstOrDefault().iddp;
                                DetalleProgramaModelo.Delete(idHijo);
                            }
                            //int idHijo = _context.detalleprogramas.Single(j => j.idpadredp == id).iddp;
                            //No tiene hijos se puede borrar
                            string commandString = String.Format("DELETE FROM sgpt.detalleprogramas WHERE iddp={0};", id);
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

        public static bool Delete(string id, Boolean actualizar)
        {
            {

                if (!((string.IsNullOrEmpty(id)) || string.IsNullOrWhiteSpace(id)))
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("DELETE FROM sgpt.detalleprogramas WHERE iddp={0};", id);
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

        public static List<DetalleProgramaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista= _context.detalleprogramas.Select(entidad =>
                    new DetalleProgramaModelo
                    {
                        iddp = entidad.iddp,
                        idtprocedimientodp = entidad.idtprocedimientodp,
                        idprogramadp = entidad.idprogramadp,
                        idpapelesdp = entidad.idpapelesdp,
                        descripciondp = entidad.descripciondp,
                        fechacreadodp = entidad.fechacreadodp,
                        ordendp = entidad.ordendp,
                        fechainidp = entidad.fechainidp,
                        fechafindp = entidad.fechafindp,
                        horaplandp = entidad.horaplandp,
                        horaejecdp = entidad.horaejecdp,
                        estadoprocedimientodp = entidad.estadoprocedimientodp,
                        comentariodp = entidad.comentariodp,
                        estadodp = entidad.estadodp,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadp,
                        idpadredp = entidad.idpadredp,
                        usuarioModificoDp=entidad.usuario.inicialesusuario,
                        idusuarioejecuto=entidad.idusuarioejecuto,
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (DetalleProgramaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                        item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);

                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return RegeneraOrdenSubRegistros(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del detalle" + e.Message);
                }
                return null;
            }
        }

        public static List<DetalleProgramaModelo> GetAll(int? idprogramadp, bool ordenar)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detalleprogramas.Select(entidad =>
                    new DetalleProgramaModelo
                    {
                        iddp = entidad.iddp,
                        idtprocedimientodp = entidad.idtprocedimientodp,
                        idprogramadp = entidad.idprogramadp,
                        idpapelesdp = entidad.idpapelesdp,
                        descripciondp = entidad.descripciondp,
                        fechacreadodp = entidad.fechacreadodp,
                        ordendp = entidad.ordendp,
                        fechainidp = entidad.fechainidp,
                        fechafindp = entidad.fechafindp,
                        horaplandp = entidad.horaplandp,
                        horaejecdp = entidad.horaejecdp,
                        estadoprocedimientodp = entidad.estadoprocedimientodp,
                        comentariodp = entidad.comentariodp,
                        estadodp = entidad.estadodp,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadp,
                        idpadredp = entidad.idpadredp,
                        IsSelected = false,
                        referenciaPt = "",
                        tipoProcedimientoModelo = new TipoProcedimientoModelo
                        {
                            id = entidad.tipoprocedimiento.idtprocedimiento,
                            descripcion = entidad.tipoprocedimiento.descripciontprocedimiento,
                            sistema = entidad.tipoprocedimiento.sistematprocedimiento,
                            idThTprocedimiento = entidad.tipoprocedimiento.idthtprocedimiento,
                            estado = entidad.tipoprocedimiento.estadotprocedimiento
                        },
                        visitaModelo = new VisitaModelo
                        {
                            id = entidad.visita.idvisita,
                            descripcion = entidad.visita.descripcionvisita,
                            sistema = entidad.visita.sistemavisita,
                            estado = entidad.visita.estadovisita
                        },
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        usuarioModificoDp = entidad.usuario.inicialesusuario,
                        idusuarioejecuto = entidad.idusuarioejecuto,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp).ToList();
                    //Obtener el listado de bitacora

                    var listaBitacora = UsuarioProgramaAccionModelo.GetAllListaByDetallePrograma(idprogramadp);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleProgramaModelo>();
                    }
                    else
                    {
                        DetalleProgramaModelo temporal;
                        int i = 1;
                        foreach (DetalleProgramaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            item.guardadoBase = true;
                            item.IsEditable = false;
                            if (!(item.idpadredp == null))
                            {
                                //temporal = DetalleCuestionarioModelo.Find((int)item.idpadredp);
                                temporal = lista.SingleOrDefault(x => x.iddp == item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleProgramaModeloPadre = temporal;
                            }

                            item.guardadoBase = true;
                            item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                            item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                            if(item.nombreEstadoProcedimientoDp=="C")
                            { 
                                //Solo en caso de estar cerrado el procedimiento
                                    try
                                    {
                                        item.usuarioProgramaAccionModeloDp = listaBitacora.LastOrDefault(x => x.iddp == item.iddp && x.rolupa.Contains("E"));
                                        item.usuarioModificoDp = item.usuarioProgramaAccionModeloDp.nombreUsuario;
                                        item.fechafindp = item.usuarioProgramaAccionModeloDp.fechacreadoupa;
                                    }
                                    catch (Exception)
                                    {
                                        //item.usuarioProgramaAccionModeloDp = listaBitacora.LastOrDefault(x => x.iddp == item.iddp && x.rolupa.Contains("C"));
                                        item.usuarioModificoDp = "";
                                        //item.fechaUltimaModificacionProgramaDp = item.usuarioProgramaAccionModeloDp.fechacreadoupa;
                                    }
                            }
                            if (item.nombreEstadoProcedimientoDp == "P")
                            {
                                //Solo en caso de estar cerrado el procedimiento
                                try
                                {
                                    item.usuarioProgramaAccionModeloDp = listaBitacora.LastOrDefault(x => x.iddp == item.iddp && x.rolupa.Contains("M"));
                                    item.usuarioModificoDp = item.usuarioProgramaAccionModeloDp.nombreUsuario;
                                    item.fechainidp = item.usuarioProgramaAccionModeloDp.fechacreadoupa;
                                }
                                catch (Exception)
                                {
                                    //item.usuarioProgramaAccionModeloDp = listaBitacora.LastOrDefault(x => x.iddp == item.iddp && x.rolupa.Contains("C"));
                                    item.usuarioModificoDp = "";
                                    //item.fechaUltimaModificacionProgramaDp = item.usuarioProgramaAccionModeloDp.fechacreadoupa;
                                }
                            }
                        }
                        if (ordenar)
                        {
                            return RegeneraOrdenSubRegistros(lista);
                        }
                        else
                        {
                            return lista;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas \n" + e );
                var lista = new ObservableCollection<DetalleProgramaModelo>();
                return lista.ToList();
            }
        }
        public static List<DetalleProgramaModelo> GetAll(int? idprogramadp)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detalleprogramas.Select(entidad =>
                    new DetalleProgramaModelo
                    {
                        iddp = entidad.iddp,
                        idtprocedimientodp = entidad.idtprocedimientodp,
                        idprogramadp = entidad.idprogramadp,
                        idpapelesdp = entidad.idpapelesdp,
                        descripciondp = entidad.descripciondp,
                        fechacreadodp = entidad.fechacreadodp,
                        ordendp = entidad.ordendp,
                        fechainidp = entidad.fechainidp,
                        fechafindp = entidad.fechafindp,
                        horaplandp = entidad.horaplandp,
                        horaejecdp = entidad.horaejecdp,
                        estadoprocedimientodp = entidad.estadoprocedimientodp,
                        comentariodp = entidad.comentariodp,
                        estadodp = entidad.estadodp,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadp,
                        idpadredp = entidad.idpadredp,
                    tipoProcedimientoModelo = new TipoProcedimientoModelo
                        {
                            id = entidad.tipoprocedimiento.idtprocedimiento,
                            descripcion = entidad.tipoprocedimiento.descripciontprocedimiento,
                            sistema = entidad.tipoprocedimiento.sistematprocedimiento,
                            idThTprocedimiento = entidad.tipoprocedimiento.idthtprocedimiento,
                            estado = entidad.tipoprocedimiento.estadotprocedimiento
                        },
                        visitaModelo = new VisitaModelo
                        {
                            id = entidad.visita.idvisita,
                            descripcion = entidad.visita.descripcionvisita,
                            sistema = entidad.visita.sistemavisita,
                            estado = entidad.visita.estadovisita
                        },
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        usuarioModificoDp = entidad.usuario.inicialesusuario,
                        idusuarioejecuto = entidad.idusuarioejecuto,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleProgramaModelo>();
                    }
                    else
                    {
                        DetalleProgramaModelo temporal;
                        int i = 1;
                        foreach (DetalleProgramaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            item.guardadoBase = true;
                            if (!(item.idpadredp == null))
                            {
                                temporal = DetalleProgramaModelo.Find((int)item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleProgramaModeloPadre = temporal;
                            }
                                item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                                item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                        }
                        return RegeneraOrdenSubRegistros(lista);
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                var lista = new ObservableCollection<DetalleProgramaModelo>();
                return lista.ToList();
            }
        }

       public static List<DetalleProgramaModelo> GetAllVistaEjecucion(int? idprogramadp,int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detalleprogramas.Select(entidad =>
                    new DetalleProgramaModelo
                    {

                        iddp = entidad.iddp,
                        idtprocedimientodp = entidad.idtprocedimientodp,
                        idprogramadp = entidad.idprogramadp,
                        idpapelesdp = entidad.idpapelesdp,
                        descripciondp = entidad.descripciondp,
                        fechacreadodp = entidad.fechacreadodp,
                        ordendp = entidad.ordendp,
                        fechainidp = entidad.fechainidp,
                        fechafindp = entidad.fechafindp,
                        horaplandp = entidad.horaplandp,
                        horaejecdp = entidad.horaejecdp,
                        estadoprocedimientodp = entidad.estadoprocedimientodp,
                        comentariodp = entidad.comentariodp,
                        estadodp = entidad.estadodp,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadp,
                        idpadredp = entidad.idpadredp,
                        isuso = entidad.isuso,
                        idrepositorio = entidad.idrepositorio,
                        idcedula = entidad.idcedula,
                        idgenerico = entidad.idgenerico,
                        tabla = entidad.tabla,
                        iddcedulas = entidad.iddcedulas,
                        idnotaspt = entidad.idnotaspt,
                        idagenda = entidad.idagenda,

                        IsSelected = false,
                        referenciaPt = "",
                        nombreDetallePadre = "",

                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        guardadoBase = true,
                        IsEditable = false,
                        isBotonReferenciar = false,
                        usuarioModificoDp = entidad.usuario.inicialesusuario,
                        idusuarioejecuto = entidad.idusuarioejecuto,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleProgramaModelo>();
                    }
                    else
                    {
                        ObservableCollection<UniversalPTModelo> referencias = UniversalPTModelo.GetAllContenido(idEncargo);
                        DetalleProgramaModelo temporal;
                        int i = 1;
                        foreach (DetalleProgramaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            item.guardadoBase = true;
                            item.IsEditable = false;
                            if (!(item.idpadredp == null))
                            {
                                //temporal = DetalleProgramaModelo.Find((int)item.idpadredp);
                                temporal = lista.SingleOrDefault(x => x.iddp == item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleProgramaModeloPadre = temporal;
                            }
                            item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                            item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                            switch (item.nombreTipoProcedimiento)
                            {
                                case "Procedimiento":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-procedimiento":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-Sub-procedimiento":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Pregunta":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-Pregunta":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-Sub-Pregunta":
                                    item.isBotonReferenciar = true;
                                    break;
                            }
                            if (item.idgenerico != null && item.idgenerico > 0)
                            {
                                try
                                {
                                    item.referenciaPt = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                    item.referenciaPtDp = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                    if (string.IsNullOrEmpty(item.referenciaPtDp))
                                    {
                                        item.referenciaPtDp = "Pendiente";
                                    }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Error en la busqueda dela referencia \n" + e);
                                }
                            }

                        }
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                var lista = new ObservableCollection<DetalleProgramaModelo>();
                return lista.ToList();
            }
        }

        internal static List<detalleprograma> GetAllCapaDatos(int? idprograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.detalleprogramas WHERE idprogramadp={0} AND estadodp = 'A' ORDER BY ordendp;", idprograma);

                    var lista = _context.detalleprogramas.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<detalleprograma> temporal = new ObservableCollection<detalleprograma>(lista);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista del detalle  \n" + e);
                detalleprograma registroAdicional = new detalleprograma();
                registroAdicional.iddp = 0;
                registroAdicional.descripciondp = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<detalleprograma>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<DetalleProgramaModelo> GetAllVista(int? idprogramadp,int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detalleprogramas.Select(entidad =>
                    new DetalleProgramaModelo
                    {
                        iddp = entidad.iddp,
                        idtprocedimientodp = entidad.idtprocedimientodp,
                        idprogramadp = entidad.idprogramadp,
                        idpapelesdp = entidad.idpapelesdp,
                        descripciondp = entidad.descripciondp,
                        fechacreadodp = entidad.fechacreadodp,
                        ordendp = entidad.ordendp,
                        fechainidp = entidad.fechainidp,
                        fechafindp = entidad.fechafindp,
                        horaplandp = entidad.horaplandp,
                        horaejecdp = entidad.horaejecdp,
                        estadoprocedimientodp = entidad.estadoprocedimientodp,
                        comentariodp = entidad.comentariodp,
                        estadodp = entidad.estadodp,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadp,
                        idpadredp = entidad.idpadredp,
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        usuarioModificoDp = entidad.usuario.inicialesusuario,
                        guardadoBase = true,
                        IsEditable = false,
                        isBotonReferenciar = false,
                        isuso = entidad.isuso,
                        idrepositorio = entidad.idrepositorio,
                        idcedula = entidad.idcedula,
                        idgenerico = entidad.idgenerico,
                        tabla = entidad.tabla,
                        iddcedulas = entidad.iddcedulas,
                        idnotaspt = entidad.idnotaspt,
                        idagenda = entidad.idagenda,
                        idusuarioejecuto = entidad.idusuarioejecuto,

                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleProgramaModelo>();
                    }
                    else
                    {
                        ObservableCollection<UniversalPTModelo> referencias = UniversalPTModelo.GetAllContenido(idEncargo);

                        DetalleProgramaModelo temporal;
                        int i = 1;
                        foreach (DetalleProgramaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            item.guardadoBase = true;
                            if (!(item.idpadredp == null))
                            {
                                temporal = DetalleProgramaModelo.Find((int)item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleProgramaModeloPadre = temporal;
                            }
                            item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                            item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                            switch (item.nombreTipoProcedimiento)
                            {
                                case "Procedimiento":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-procedimiento":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-Sub-procedimiento":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Pregunta":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-Pregunta":
                                    item.isBotonReferenciar = true;
                                    break;
                                case "Sub-Sub-Pregunta":
                                    item.isBotonReferenciar = true;
                                    break;
                            }
                            if (item.idgenerico != null && item.idgenerico > 0)
                            {
                                try
                                {
                                    item.referenciaPt = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                    item.referenciaPtDp = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                    if (string.IsNullOrEmpty(item.referenciaPtDp))
                                    {
                                        item.referenciaPtDp = "Pendiente";
                                    }
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Error en la busqueda dela referencia \n" + e);
                                }
                            }

                        }
                        return RegeneraOrdenSubRegistros(lista);
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                var lista = new ObservableCollection<DetalleProgramaModelo>();
                return lista.ToList();
            }
        }

        internal static decimal? IndiceEjecucion(int idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.detalleprogramas WHERE idprogramadp={0} AND estadodp = 'A' ORDER BY ordendp;", idPrograma);
                    int preguntas = 1;
                    int subpreguntas = 2;
                    int subsubpreguntas = 3;
                    var lista = _context.detalleprogramas.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    decimal cantidadPreguntas = lista.Where(x => x.idtprocedimientodp == preguntas).Count();
                    decimal cantidadPreguntasRespuesta = lista.Where(x => x.idtprocedimientodp == preguntas && x.idpapelesdp != null).Count();
                    if (lista.Count() > 0 && cantidadPreguntas > 0 && cantidadPreguntasRespuesta > 0)
                    {
                        #region Inicializacion

                        var listaHijos = lista.Where(x => x.idpadredp != null && x.idtprocedimientodp == subpreguntas).OrderBy(x => x.idpadredp);

                        var listaNietos = lista.Where(x => x.idpadredp != null && x.idtprocedimientodp == subsubpreguntas).OrderBy(x => x.idpadredp);

                        detalleprograma anterior = new detalleprograma();
                        anterior.idpadredp = 0;

                        decimal cantidadPreguntasHijos = 0;
                        decimal cantidadPreguntasRespuestaHijos = 0;

                        decimal cantidadPreguntasNietos = 0;
                        decimal cantidadPreguntasRespuestaNietos = 0;

                        decimal indice = 0;


                        //Calculo inicial
                        indice = (cantidadPreguntasRespuesta / cantidadPreguntas);

                        #endregion
                        if (listaHijos.Count() > 0)
                        {
                            foreach (detalleprograma item in listaHijos)
                            {
                                if (item.idpadredp != anterior.idpadredp)
                                {
                                    if (lista.Where(x => x.idtprocedimientodp == preguntas && x.idpapelesdp != null && x.iddp == item.idpadredp).Count() > 0)
                                    {
                                        //Si tiene respuesta se ajusta el total restandole la respuesta 
                                        indice = indice - (1 / cantidadPreguntas);
                                    }

                                    // Se adiciona las sub-respuestas respondidas ponderadas por la cantidad de preguntas

                                    cantidadPreguntasHijos = lista.Where(x => x.idpadredp == item.idpadredp
                                    && (x.idtprocedimientodp == subpreguntas)).Count();

                                    cantidadPreguntasRespuestaHijos = lista.Where(x => x.idpadredp == item.idpadredp
                                    && (x.idtprocedimientodp == subpreguntas)
                                    && x.idpapelesdp != null).Count();

                                    //Ajustar por respuesta de nietos
                                    if (listaNietos.Where(x => x.idpadredp == item.iddp).Count() > 0)
                                    {
                                        cantidadPreguntasNietos = lista.Where(x => x.idpadredp == item.iddp
                                        && (x.idtprocedimientodp == subsubpreguntas)).Count();

                                        cantidadPreguntasRespuestaNietos = lista.Where(x => x.idpadredp == item.iddp
                                        && (x.idtprocedimientodp == subsubpreguntas)
                                        && x.idpapelesdp != null).Count();

                                        if (lista.Where(x => x.idtprocedimientodp == subpreguntas && x.idpapelesdp != null && x.idpadredp == item.iddp).Count() > 0)
                                        {
                                            //Si tiene respuesta se ajusta el total restandole la respuesta 
                                            cantidadPreguntasRespuestaHijos = cantidadPreguntasRespuestaHijos - (1 / cantidadPreguntasHijos) * (1 / cantidadPreguntas);
                                        }
                                        //El subregistro tiene nietos
                                        indice = indice +
                                        (cantidadPreguntasRespuestaHijos / cantidadPreguntasHijos)
                                        * (1 / cantidadPreguntas) +
                                        (cantidadPreguntasRespuestaNietos / cantidadPreguntasNietos)
                                        * (1 / cantidadPreguntasHijos) * (1 / cantidadPreguntas);
                                    }
                                    else
                                    {
                                        //No tiene nietos
                                        indice = indice +
                                        (cantidadPreguntasRespuestaHijos / cantidadPreguntasHijos)
                                        * (1 / cantidadPreguntas);
                                    }
                                }
                                //reiniciando el anterior para evitar repeticion
                                anterior = item;
                            }//Fin de ciclo

                        }
                        //Contar los procedimiento

                        return indice * 100;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle cuestionario \n" + e);
                return 0;
            }

        }

        internal static ProgramaModelo ResumenEjecucion(int idPrograma)
        {
            ProgramaModelo respuesta = new ProgramaModelo();
            try
            {
                using (_context = new SGPTEntidades())
                {

                    string commandString = String.Format("SELECT * FROM sgpt.detalleprogramas WHERE idprogramadp={0} AND estadodp = 'A' ORDER BY ordendp;", idPrograma);
                    int preguntas = 1; //1 "Procedimiento"
                    int subpreguntas = 2;//2; "Sub-procedimiento"
                    int subsubpreguntas = 3;//3; "Sub-Sub-procedimiento"
                    var lista = _context.detalleprogramas.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    decimal cantidadPreguntas = lista.Where(x => x.idtprocedimientodp == preguntas).Count();
                    decimal cantidadPreguntasRespuesta = lista.Where(x => x.idtprocedimientodp == preguntas && x.idpapelesdp != null).Count();
                    if (lista.Count() > 0 && cantidadPreguntas > 0 && cantidadPreguntasRespuesta > 0)
                    {
                        #region Inicializacion

                        var listaHijos = lista.Where(x => x.idpadredp != null && x.idtprocedimientodp == subpreguntas).OrderBy(x => x.idpadredp);

                        var listaNietos = lista.Where(x => x.idpadredp != null && x.idtprocedimientodp == subsubpreguntas).OrderBy(x => x.idpadredp);

                        detalleprograma anterior = new detalleprograma();
                        anterior.idpadredp = 0;

                        decimal cantidadPreguntasHijos = 0;
                        decimal cantidadPreguntasRespuestaHijos = 0;

                        decimal cantidadPreguntasNietos = 0;
                        decimal cantidadPreguntasRespuestaNietos = 0;

                        decimal indice = 0;


                        //Calculo inicial
                        indice = (cantidadPreguntasRespuesta / cantidadPreguntas);

                        #endregion
                        if (listaHijos.Count() > 0)
                        {
                            foreach (detalleprograma item in listaHijos)
                            {
                                if (item.idpadredp != anterior.idpadredp)
                                {
                                    if (lista.Where(x => x.idtprocedimientodp == preguntas && x.idpapelesdp != null && x.iddp == item.idpadredp).Count() > 0)
                                    {
                                        //Si tiene respuesta se ajusta el total restandole la respuesta 
                                        indice = indice - (1 / cantidadPreguntas);
                                    }

                                    // Se adiciona las sub-respuestas respondidas ponderadas por la cantidad de preguntas

                                    cantidadPreguntasHijos = lista.Where(x => x.idpadredp == item.idpadredp
                                    && (x.idtprocedimientodp == subpreguntas)).Count();

                                    cantidadPreguntasRespuestaHijos = lista.Where(x => x.idpadredp == item.idpadredp
                                    && (x.idtprocedimientodp == subpreguntas)
                                    && x.idpapelesdp != null).Count();

                                    //Ajustar por respuesta de nietos
                                    if (listaNietos.Where(x => x.idpadredp == item.iddp).Count() > 0)
                                    {
                                        cantidadPreguntasNietos = lista.Where(x => x.idpadredp == item.iddp
                                        && (x.idtprocedimientodp == subsubpreguntas)).Count();

                                        cantidadPreguntasRespuestaNietos = lista.Where(x => x.idpadredp == item.iddp
                                        && (x.idtprocedimientodp == subsubpreguntas)
                                        && x.idpapelesdp != null).Count();

                                        if (lista.Where(x => x.idtprocedimientodp == subpreguntas && x.idpapelesdp != null && x.idpadredp == item.iddp).Count() > 0)
                                        {
                                            //Si tiene respuesta se ajusta el total restandole la respuesta 
                                            cantidadPreguntasRespuestaHijos = cantidadPreguntasRespuestaHijos - (1 / cantidadPreguntasHijos) * (1 / cantidadPreguntas);
                                        }
                                        //El subregistro tiene nietos
                                        indice = indice +
                                        (cantidadPreguntasRespuestaHijos / cantidadPreguntasHijos)
                                        * (1 / cantidadPreguntas) +
                                        (cantidadPreguntasRespuestaNietos / cantidadPreguntasNietos)
                                        * (1 / cantidadPreguntasHijos) * (1 / cantidadPreguntas);
                                    }
                                    else
                                    {
                                        //No tiene nietos
                                        indice = indice +
                                        (cantidadPreguntasRespuestaHijos / cantidadPreguntasHijos)
                                        * (1 / cantidadPreguntas);
                                    }
                                }
                                //reiniciando el anterior para evitar repeticion
                                anterior = item;
                            }//Fin de ciclo
                        }
                        //Contar los procedimiento
                        respuesta.cantidadProcedimientosPlan = cantidadPreguntas;
                        respuesta.cantidadProcedimientosEjecucion = indice * cantidadPreguntas;
                        respuesta.indiceEjecucionprograma = indice * 100;
                        return respuesta;
                    }
                    else
                    {
                        respuesta.cantidadProcedimientosPlan = cantidadPreguntas;
                        respuesta.cantidadProcedimientosEjecucion = 0;
                        respuesta.indiceEjecucionprograma = 0;
                        return respuesta;
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle cuestionario \n" + e);
                return respuesta;
            }

        }


        public static bool DeleteByIdProgramaRange(int? idprogramadp)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //07-04-2017
                    string commandString = String.Format("DELETE FROM sgpt.detalleprogramas WHERE idprogramadp={0};", idprogramadp);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    return true;
                    /*
                    //var lista = _context.detalleprogramas.Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp);
                    var lista = (from p in _context.detalleprogramas
                                   where p.idprogramadp==idprogramadp
                                   select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.detalleprogramas.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }*/
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista detalle herramientas " + e.Message + " fuente " + e.Source);
                    return false;
            }
        }

        public static Nullable<Decimal> SumaHora(int? idprogramadp)
        {
            Nullable<decimal> suma = 0;
            if (!(idprogramadp == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    suma = _context.detalleprogramas.Where(x => x.idprogramadp == idprogramadp).Sum(p => p.horaplandp);
                    return suma;
                }
            }
            else
            {
                return suma;
            }
        }

        public static List<DetalleProgramaModelo> GetAll(int? idprogramadp, int? iddpSeleccionado)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.detalleprogramas.Select(entidad =>
                    new DetalleProgramaModelo
                    {
                        iddp = entidad.iddp,
                        idtprocedimientodp = entidad.idtprocedimientodp,
                        idprogramadp = entidad.idprogramadp,
                        idpapelesdp = entidad.idpapelesdp,
                        descripciondp = entidad.descripciondp,
                        fechacreadodp = entidad.fechacreadodp,
                        ordendp = entidad.ordendp,
                        fechainidp = entidad.fechainidp,
                        fechafindp = entidad.fechafindp,
                        horaplandp = entidad.horaplandp,
                        horaejecdp = entidad.horaejecdp,
                        estadoprocedimientodp = entidad.estadoprocedimientodp,
                        comentariodp = entidad.comentariodp,
                        estadodp = entidad.estadodp,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadp,
                        idpadredp = entidad.idpadredp,
                    tipoProcedimientoModelo = new TipoProcedimientoModelo
                        {
                            id = entidad.tipoprocedimiento.idtprocedimiento,
                            descripcion = entidad.tipoprocedimiento.descripciontprocedimiento,
                            sistema = entidad.tipoprocedimiento.sistematprocedimiento,
                            idThTprocedimiento = entidad.tipoprocedimiento.idthtprocedimiento,
                            estado = entidad.tipoprocedimiento.estadotprocedimiento
                        },
                        visitaModelo = new VisitaModelo
                        {
                            id = entidad.visita.idvisita,
                            descripcion = entidad.visita.descripcionvisita,
                            sistema = entidad.visita.sistemavisita,
                            estado = entidad.visita.estadovisita
                        },
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        usuarioModificoDp = entidad.usuario.inicialesusuario,
                        idusuarioejecuto = entidad.idusuarioejecuto,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp && x.iddp == iddpSeleccionado).ToList();
                    DetalleProgramaModelo temporal;
                    int i = 1;
                    foreach (DetalleProgramaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                        item.guardadoBase = true;
                        if (!(item.idpadredp == null))
                        {
                            temporal = DetalleProgramaModelo.Find((int)item.idpadredp);
                            item.nombreDetallePadre = temporal.descripciondp;
                            item.ordendpPadre = temporal.ordendp;
                            item.DetalleProgramaModeloPadre = temporal;
                        }
                            item.guardadoBase = true;
                            item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                            item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                    }
                    return RegeneraOrdenSubRegistros(lista);
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

        //public static List<DetalleProgramaModelo> GetAll(int? idprogramadp, int? iddpSeleccionado, bool seleccion)
        //{
        //    try
        //    {
        //        using (_context = new SGPTEntidades())
        //        {
        //            //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
        //            var lista = _context.detalleprogramas.Select(entidad =>
        //            new DetalleProgramaModelo
        //            {
        //                iddp = entidad.iddp,
        //                idtprocedimientodp = entidad.idtprocedimientodp,
        //                idprogramadp = entidad.idprogramadp,
        //                idpapelesdp = entidad.idpapelesdp,
        //                descripciondp = entidad.descripciondp,
        //                fechacreadodp = entidad.fechacreadodp,
        //                ordendp = entidad.ordendp,
        //                fechainidp = entidad.fechainidp,
        //                fechafindp = entidad.fechafindp,
        //                horaplandp = entidad.horaplandp,
        //                horaejecdp = entidad.horaejecdp,
        //                estadoprocedimientodp = entidad.estadoprocedimientodp,
        //                comentariodp = entidad.comentariodp,
        //                estadodp = entidad.estadodp,
        //                fechasupervision = entidad.fechasupervision,
        //                idvisitadp = entidad.idvisitadp,
        //                idpadredp = entidad.idpadredp,
        //                ordenDhPresentacion = entidad.ordendp,
                       
        //            tipoProcedimientoModelo = new TipoProcedimientoModelo
        //                {
        //                    id = entidad.tipoprocedimiento.idtprocedimiento,
        //                    descripcion = entidad.tipoprocedimiento.descripciontprocedimiento,
        //                    sistema = entidad.tipoprocedimiento.sistematprocedimiento,
        //                    idThTprocedimiento = entidad.tipoprocedimiento.idthtprocedimiento,
        //                    estado = entidad.tipoprocedimiento.estadotprocedimiento
        //                },
        //                visitaModelo = new VisitaModelo
        //                {
        //                    id = entidad.visita.idvisita,
        //                    descripcion = entidad.visita.descripcionvisita,
        //                    sistema = entidad.visita.sistemavisita,
        //                    estado = entidad.visita.estadovisita
        //                },
        //                nombreDetallePadre = "",
        //                nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
        //                nombreVisita = entidad.visita.descripcionvisita,
        //                //Lista filtrada de elementos que fueron eliminados
        //            }).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp && x.iddp != iddpSeleccionado).ToList();
        //            //}).OrderBy(o => o.ordendp).Where(x => x.estadodp == "A" && x.idprogramadp == idprogramadp && x.iddp == iddpSeleccionado && x.iddp != iddpSeleccionado).ToList();

        //            DetalleProgramaModelo temporal;
        //            foreach (DetalleProgramaModelo item in lista)
        //            {
        //                item.descripciondp = item.ordendp.ToString() + "-" + item.descripciondp;
        //                item.guardadoBase = true;
        //                if (!(item.idpadredp == null))
        //                {
        //                    temporal = DetalleProgramaModelo.Find((int)item.idpadredp);
        //                    item.nombreDetallePadre = temporal.descripciondp;
        //                    item.ordendpPadre = temporal.ordendp;
        //                    item.DetalleProgramaModeloPadre = temporal;
        //                }
        //                    item.guardadoBase = true;
        //                    item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
        //                    item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
        //            }
        //            DetalleProgramaModelo registroAdicional = new DetalleProgramaModelo();
        //            registroAdicional.iddp = 0;
        //            registroAdicional.descripciondp = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
        //            registroAdicional.nombreTipoProcedimiento = "Ninguno";
        //            registroAdicional.tipoProcedimientoModelo = new TipoProcedimientoModelo();
        //            lista.Insert(0, registroAdicional);
        //            return RegeneraOrdenSubRegistros(lista);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //Captura de fallo en la insercion
        //        if (e.Source != null)
        //            MessageBox.Show("Exception en elaboracion de lista " + e.Message + " " + e.Source);
        //        throw;
        //        //return null;
        //    }
        //}


        #endregion

        #region Contar registros
        public static int ContarRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleprogramas.Where(x => x.idprogramadp == id && x.estadodp == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros\n" + e);
                return elementos;
            }
        }

        public static int ContarSubRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleprogramas.Where(x => x.idpadredp == id && x.estadodp == "A").Count();
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

        public static int ContarRegistros()
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleprogramas.Where(x => x.estadodp == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros\n" + e);
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
                    var entidad = (from p in _context.detalleprogramas
                                   where p.descripciondp.ToLower().Equals(busqueda)
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

        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleprogramas.Where(x => x.descripciondp.ToUpper() == busqueda && x.estadodp == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int FindTextoReturnId(string texto, int? iddp)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleprogramas.Where(x => x.descripciondp.ToUpper() == busqueda && x.estadodp == "A" && x.iddp == iddp).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }


        public static int InsertbyImportacionByRange(ObservableCollection<detalleprograma> lista, UsuarioModelo usuarioModelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleprogramas', 'iddp'), (SELECT MAX(iddp) FROM sgpt.detalleprogramas) + 1);");
                            sincronizar = true;
                        }
                        try
                        {
                            _context.detalleprogramas.AddRange(lista);
                            _context.SaveChanges();
                            result = 1;//éxito completo
                        }
                        catch (Exception )
                        {
                            //MessageBox.Show("Exception en insertar listado detalle : \n" + e);
                            try
                            {

                                foreach (detalleprograma item in lista)
                                {
                                    //_context.detalleprogramas.Add(item);
                                    //_context.SaveChanges();
                                    if (DetalleProgramaModelo.Insert(item))
                                    {
                                        result = 1;
                                    }
                                    else
                                    {
                                        result = -1;
                                    }
                                }
                            }
                            catch (Exception f)
                            {
                                MessageBox.Show("Exception en insertar listado detalle # \n" + f);
                                result = 4;
                            }

                        }
                        //El detalle se incorporará posteriormente
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de detalle : \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool Insert(detalleprograma modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleprogramas', 'iddp'), (SELECT MAX(iddp) FROM sgpt.detalleprogramas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.detalleprogramas.Add(modelo);
                        _context.SaveChanges();
                        result = true;
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar detalle programa : \n "+ "datos \n"+modelo +"\n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        public DetalleProgramaModelo()
        {
            iddp = 0;
            idtprocedimientodp = 0;
            idprogramadp = 0;
            //idpapelesdp = 0;
            descripciondp = string.Empty;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = 1;
            //fechainidp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture); 
            horaplandp = 0;
            horaejecdp = 0;
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            estadodp = "A";
            //fechasupervision = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //idvisitadp = entidad.idvisitadp;
            //idpadredp = entidad.idpadredp;
            ordenDhPresentacion = MetodosModelo.ordenConversion(ordendp);
            //idvisitadp = 0;
            guardadoBase = false;
            descripciondpSeleccion = string.Empty;
        }
        public DetalleProgramaModelo(int idTprocedimientodp,int  idProgramadp, UsuarioModelo usuarioModelo)
        {
            iddp = 0;
            idtprocedimientodp = idTprocedimientodp;
            idprogramadp = idProgramadp;
            //idpapelesdp = 0;
            descripciondp = string.Empty;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)FindOrden(idprogramadp) + 1; ;
            //fechainidp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            horaplandp = 0;
            horaejecdp = 0;
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            estadodp = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //idvisitadp = entidad.idvisitadp;
            //idpadredp = entidad.idpadredp;
            //idvisitadp = 0;
            ordenDhPresentacion = MetodosModelo.ordenConversion(ordendp);
            //idvisitadp = 0;
            guardadoBase = false;
            usuarioModeloDp = usuarioModelo;
            usuarioModificoDp = usuarioModelo.inicialesusuario;
            usuarioProgramaAccionModeloDp =new UsuarioProgramaAccionModelo(iddp);
            descripciondpSeleccion = string.Empty;
        }
        public DetalleProgramaModelo(int idProgramadp, UsuarioModelo usuarioModelo)
        {
            iddp = 0;
            idtprocedimientodp = 0;
            idprogramadp = idProgramadp;
            //idpapelesdp = 0;
            descripciondp = string.Empty;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp =(decimal) FindOrden(idprogramadp)+1;
            //fechainidp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            horaplandp = 0;
            horaejecdp = 0;
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            estadodp = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //idvisitadp = entidad.idvisitadp;
            idpadredp = null;
            //idvisitadp = 0;
            ordenDhPresentacion = MetodosModelo.ordenConversion(ordendp);
            //idvisitadp = 0;
            guardadoBase = false;
            usuarioModeloDp = usuarioModelo;
            usuarioModificoDp = usuarioModelo.inicialesusuario;
            usuarioProgramaAccionModeloDp = new UsuarioProgramaAccionModelo(iddp);
            descripciondpSeleccion = string.Empty;
        }

        public static DetalleProgramaModelo equivalencia(DetalleProgramaModelo comun, DetalleHerramientasModelo origen)
        {
            DetalleProgramaModelo destino = new DetalleProgramaModelo();
            destino.iddp = 0;
            destino.idtprocedimientodp = origen.idtProcedimiento;
            destino.idprogramadp = comun.idprogramadp;//Programa del que depende
            
            destino.descripciondp = origen.descripcionDh;
            destino.fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.ordendp =(decimal) origen.ordenDh;
            //fechainidp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.horaplandp = origen.horasPlanDh;
            destino.horaejecdp = 0;
            destino.estadoprocedimientodp = "I";
            destino.comentariodp = "";
            destino.estadodp = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.idvisitadp = origen.idVisitaDh;
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            destino.idpapelesdp = origen.idDh;
            destino.idpadredp = origen.idDhPrincipalDh;//Pendiente para actualizacion se guarda el id

            destino.ordenDhPresentacion = MetodosModelo.ordenConversion(decimal.Parse(origen.ordenDhPresentacion));
            destino.guardadoBase = false;
            destino.usuarioModeloDp = comun.usuarioModeloDp;
            destino.usuarioModificoDp = comun.usuarioModificoDp;
            destino.usuarioProgramaAccionModeloDp = comun.usuarioProgramaAccionModeloDp;
            return destino;
        }

        public DetalleProgramaModelo(DetalleProgramaModelo comun, DetalleHerramientasModelo origen)
        {
            iddp = 0;
            idtprocedimientodp = origen.idtProcedimiento;
            idprogramadp = comun.idprogramadp;//Programa del que depende

            descripciondp = origen.descripcionDh;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)origen.ordenDh;
            //fechainidp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            horaplandp = origen.horasPlanDh;
            horaejecdp = 0;
            estadoprocedimientodp = "I";
            comentariodp = string.Empty; ;
            estadodp = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            idvisitadp = origen.idVisitaDh;
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            idpapelesdp = origen.idDh;
            idpadredp = origen.idDhPrincipalDh;//Pendiente para actualizacion se guarda el id

            ordenDhPresentacion = MetodosModelo.ordenConversion(decimal.Parse( origen.ordenDhPresentacion));
            guardadoBase = false;
            usuarioModeloDp = comun.usuarioModeloDp;
            usuarioModificoDp = comun.usuarioModificoDp;
            usuarioProgramaAccionModeloDp = comun.usuarioProgramaAccionModeloDp;
            descripciondpSeleccion = string.Empty;
        }

        public DetalleProgramaModelo(DetalleProgramaModelo comun, DetalleProgramaModelo origen)
        {
            iddp = 0;
            idtprocedimientodp = origen.idtprocedimientodp;
            idprogramadp = comun.idprogramadp;//Programa del que depende

            descripciondp = origen.descripciondp;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)origen.ordendp;
            //fechainidp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            horaplandp = origen.horaplandp;
            horaejecdp = 0;
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            estadodp = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            idvisitadp = origen.idvisitadp;
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            idpapelesdp = origen.iddp;
            idpadredp = origen.idpadredp;//Pendiente para actualizacion se guarda el id

            ordenDhPresentacion = origen.ordenDhPresentacion;
            guardadoBase = false;
            usuarioModeloDp = comun.usuarioModeloDp;
            usuarioModificoDp = comun.usuarioModificoDp;
            usuarioProgramaAccionModeloDp = comun.usuarioProgramaAccionModeloDp;
            descripciondpSeleccion = string.Empty;
        }

        public static detalleprograma DetalleProgramaConversion(DetalleProgramaModelo comun, detalleherramienta origen)
        {
            var tablaDestino = new detalleprograma
            {
                iddp = 0,
                idtprocedimientodp = origen.idtprocedimiento,
                idprogramadp = comun.idprogramadp,
                //idpapelesdc = origen.idpapelesdp,
                descripciondp = origen.descripciondh,
                fechacreadodp = MetodosModelo.homologacionFecha(),
                ordendp = (decimal)origen.ordendh,
                //idtrcdc = origen.idtrcdc,
                horaplandp = origen.horasplandh,
                horaejecdp=0,
                estadoprocedimientodp = "I",
                //fechasupervision = origen.fechasupervision,
                idvisitadp = origen.idvisitadh,
                //Se utiliza comentario para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia
                comentariodp = string.Empty,
                //comentariodc = origen.iddh.ToString(),
                //No se traslada la referenciacion por necesitarse crear primero
                //idpadredc = origen.iddh,
                estadodp = origen.estadodh,

            };

            return tablaDestino;
        }




        #endregion

        #region generacion del orden

        public static List<DetalleProgramaModelo> RegeneraOrdenSubRegistros2(List<DetalleProgramaModelo> listaDetalleHerramienta)
        {

            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    bool guardar = false;
                    decimal contador = 1;
                    decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<DetalleProgramaModelo> listaHijos = new ObservableCollection<DetalleProgramaModelo>();
                    int ubicacion = 0;
                    foreach (DetalleProgramaModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.idpadredp == null)
                        {
                            if (itemDetalle.ordendp != contador)
                            {
                                guardar = true;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordendp = contador;
                            //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                            contador++;
                            if (guardar)
                            {
                                DetalleProgramaModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                        }
                        else
                        {
                            //Se verifica que segun el tipo de procedimiento deba tener hijos o  no
                            if (!MetodosModelo.correccionOrden(itemDetalle.nombreTipoProcedimiento))
                            {
                                itemDetalle.idpadredp = null;
                                itemDetalle.ordendpPadre = null;
                                if (itemDetalle.ordendp != contador)
                                {
                                    guardar = true;
                                }

                                //Se asigna el orden a los principales
                                itemDetalle.ordendp = contador;
                                //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                                contador++;
                                if (guardar)
                                {
                                    DetalleProgramaModelo.UpdateModeloReodenar(itemDetalle);
                                    //Se modifica el orden para mantener una estandarizacion
                                }
                            }
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    foreach (DetalleProgramaModelo item in listaDetalleHerramienta)
                    {
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<DetalleProgramaModelo>(listaDetalleHerramienta.Where(x => x.idpadredp == item.iddp));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)item.ordendp;
                            factor = MetodosModelo.factorPadre(item.nombreTipoProcedimiento);
                            int j = 1;
                            guardar = false;
                            ubicacion = -1;
                            foreach (DetalleProgramaModelo hijo in listaHijos)
                            {

                                //Es un hijo
                                ubicacion = listaDetalleHerramienta.IndexOf(hijo);
                                if (ubicacion != -1)
                                {
                                    if (listaDetalleHerramienta[ubicacion].ordendp != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                    }
                                    listaDetalleHerramienta[ubicacion].ordendpPadre = contador;
                                    listaDetalleHerramienta[ubicacion].ordendp = Decimal.Add((decimal)contador, factor * j);
                                    //listaDetalleHerramienta[ubicacion].ordendpPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordendp);
                                    listaDetalleHerramienta[ubicacion].ordenDhPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordendp);

                                    j++;
                                    if (guardar)
                                    {
                                        DetalleProgramaModelo.UpdateModelo(listaDetalleHerramienta[ubicacion]);
                                        //Se modifica el orden para mantener una estandarizacion
                                    }
                                }
                            }
                        }
                    }
                    return listaDetalleHerramienta.OrderBy(x => x.ordendp).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden " + e.Message);
                    return listaDetalleHerramienta.OrderBy(x => x.ordendp).ToList();
                    throw;
                }
            }
        }

        #endregion

        #region generacion del orden



        public static List<DetalleProgramaModelo> RegeneraOrdenSubRegistros(List<DetalleProgramaModelo> listaDetalleHerramienta)
        {
            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    bool guardar = false;
                    decimal contador = 1;
                    //decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<DetalleProgramaModelo> listaHijos = new ObservableCollection<DetalleProgramaModelo>();
                    ObservableCollection<DetalleProgramaModelo> listaPadres = new ObservableCollection<DetalleProgramaModelo>();
                    ObservableCollection<DetalleProgramaModelo> listaDetalle = new ObservableCollection<DetalleProgramaModelo>();

                    foreach (DetalleProgramaModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.idpadredp == null)
                        {
                            if (itemDetalle.ordendp != contador)
                            {
                                guardar = true;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordendp = contador;
                            //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendp);
                            itemDetalle.descripciondpSeleccion = itemDetalle.descripciondpSeleccion;
                            if (guardar)
                            {
                                DetalleProgramaModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                            listaDetalle.Add(itemDetalle);
                            if (listaDetalleHerramienta.Where(x => x.idpadredp == itemDetalle.iddp).Count() > 0)
                            {
                                listaPadres.Add(itemDetalle);
                            }
                            contador = contador + 1;
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    bool salir = false;
                    decimal factor = (decimal)0.1;
                    string desplazar = "  ";
                    int ciclos = listaPadres.Count();

                    do
                    {
                        if (listaPadres.Count > 0)
                        {
                            if (ciclos == 0)
                            {
                                //factor = factor / 10;
                                desplazar = desplazar + desplazar;
                                ciclos = listaPadres.Count();
                            }
                            salir = true;//No sale volvera a recorrerla
                                         //Recorrer todos los  que tienen hijos
                            listaHijos = new ObservableCollection<DetalleProgramaModelo>(listaDetalleHerramienta.Where(x => x.idpadredp == listaPadres[0].iddp));
                            if (listaHijos.Count > 0)
                            {
                                //Hay hijos
                                contador = (decimal)listaPadres[0].ordendp;
                                //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                                int j = 1;
                                guardar = false;
                                foreach (DetalleProgramaModelo hijo in listaHijos)
                                {
                                    //Es un hijo
                                    if (hijo.ordendp != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                    }
                                    hijo.ordendpPadre = contador;
                                    factor = MetodosModelo.factorHijo(hijo.nombreTipoProcedimiento);
                                    hijo.ordendp = Decimal.Add((decimal)contador, factor * j);
                                    hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordendp);
                                    hijo.descripciondpSeleccion = desplazar + hijo.descripciondp;

                                    hijo.DetalleProgramaModeloPadre = listaPadres[0]; ;
                                    hijo.descripcionPadre = hijo.DetalleProgramaModeloPadre.descripciondpSeleccion;

                                    j++;
                                    if (guardar)
                                    {
                                        DetalleProgramaModelo.UpdateModeloReodenar(hijo);
                                        //Se modifica el orden para mantener una estandarizacion
                                    }
                                    //Agregar a la lista
                                    listaDetalle.Add(hijo);
                                    //Verificar que no tenga hijos
                                    if (listaDetalleHerramienta.Where(x => x.idpadredp == hijo.iddp).Count() > 0)
                                    {
                                        listaPadres.Add(hijo);
                                    }
                                }
                            }
                            listaPadres.Remove(listaPadres[0]);
                            ciclos--;
                        }
                        else
                        {
                            salir = false;//Termino el proceso, salir
                        }

                    } while (salir);
                    return listaDetalle.OrderBy(x => x.ordendp).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta.OrderBy(x => x.ordendp).ToList();
                    throw;
                }
            }
        }

        #endregion
    }

}
