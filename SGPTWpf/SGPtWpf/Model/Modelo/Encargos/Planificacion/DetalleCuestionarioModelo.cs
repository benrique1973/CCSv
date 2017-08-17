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
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;
using SGPTWpf.Model.Modelo.programas;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion
{

    public class DetalleCuestionarioModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

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
        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }
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
        [Required(ErrorMessage = "Descripción requerida")]
        [MinLength(5, ErrorMessage = "No es una descripcion válida")]
        [MaxLength(500, ErrorMessage = "Excede de 500 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        //[UnqiueProgramaDetalle(ErrorMessage = "Nombre duplicado ya existe en otro registro")]
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

        public Nullable<int> idtrcdc  //Tipo de  respuesta cuestionario
        {
            get { return GetValue(() => idtrcdc); }
            set { SetValue(() => idtrcdc, value); }
        }

        public string estadodc
        {
            get { return GetValue(() => estadodc); }
            set { SetValue(() => estadodc, value); }
        }

        public string estadoprocedimientodp
        {
            get { return GetValue(() => estadoprocedimientodp); }
            set { SetValue(() => estadoprocedimientodp, value); }
        }

        [DisplayName("Descripción de procedimiento")]
        [MaxLength(500, ErrorMessage = "Excede de 500 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string comentariodp
        {
            get { return GetValue(() => comentariodp); }
            set { SetValue(() => comentariodp, value); }
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

        public bool IsEditable
        {
            get { return GetValue(() => IsEditable); }
            set { SetValue(() => IsEditable, value); }
        }

        #region usuarioProgramaAccionModeloDp

        public UsuarioProgramaAccionModelo _usuarioProgramaAccionModeloDp;
        public UsuarioProgramaAccionModelo usuarioProgramaAccionModeloDp
        {
            get { return _usuarioProgramaAccionModeloDp; }
            set { _usuarioProgramaAccionModeloDp = value; }
        }

        #endregion
        public virtual tiporespuestacuestionario SelectedTipoRespuesta
        {
            get { return GetValue(() => SelectedTipoRespuesta); }
            set { SetValue(() => SelectedTipoRespuesta, value); }
        }
        public virtual tiporespuestacuestionario tiporespuestacuestionario
        {
            get { return GetValue(() => tiporespuestacuestionario); }
            set { SetValue(() => tiporespuestacuestionario, value); }
        }
        public string descripciontrc
        {
            get { return GetValue(() => descripciontrc); }
            set { SetValue(() => descripciontrc, value); }
        }
        public string respuestaCuestionarioDp
        {
            get { return GetValue(() => respuestaCuestionarioDp); }
            set { SetValue(() => respuestaCuestionarioDp, value); }
        }
        public string referenciaPtDp
        {
            get { return GetValue(() => referenciaPtDp); }
            set { SetValue(() => referenciaPtDp, value); }
        }
        public string usuarioModificoDp
        {
            get { return GetValue(() => usuarioModificoDp); }
            set { SetValue(() => usuarioModificoDp, value); }
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

        public string referenciaPt
        {
            get { return GetValue(() => referenciaPt); }
            set { SetValue(() => referenciaPt, value); }
        }

        //Respuesta seleccionada por el usuario
        public string respuestaSeleccionadadc
        {
            get { return GetValue(() => respuestaSeleccionadadc); }
            set { SetValue(() => respuestaSeleccionadadc, value); }
        }

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public bool isBotonReferenciar
        {
            get { return GetValue(() => isBotonReferenciar); }
            set { SetValue(() => isBotonReferenciar, value); }
        }


        public int? isuso   {  get { return GetValue(() => isuso); }  set { SetValue(() => isuso, value); }}
        public int? idrepositorio   {  get { return GetValue(() => idrepositorio); }  set { SetValue(() => idrepositorio, value); }}
        public int? idcedulas   {  get { return GetValue(() => idcedulas); }  set { SetValue(() => idcedulas, value); }}
        public int? idgenerico   {  get { return GetValue(() => idgenerico); }  set { SetValue(() => idgenerico, value); }}
        public string tabla   {  get { return GetValue(() => tabla); }  set { SetValue(() => tabla, value); } }
        public int? iddcedulas   {  get { return GetValue(() => iddcedulas); }  set { SetValue(() => iddcedulas, value); }}

        
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

        public virtual DetalleCuestionarioModelo DetalleCuestionarioModeloPadre
        {
            get { return GetValue(() => DetalleCuestionarioModeloPadre); }
            set { SetValue(() => DetalleCuestionarioModeloPadre, value); }
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

        public virtual ObservableCollection<DetalleCuestionarioModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(DetalleCuestionarioModelo modelo, Boolean insertar,int idEncargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecuestionarios', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecuestionarios) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallecuestionario
                        {
                            //iddp = modelo.iddp,
                            idtprocedimientodc = modelo.idtprocedimientodp,
                            idprogramadc = modelo.idprogramadp,
                            //idpapelesdc = modelo.idpapelesdp,
                            descripciondc = modelo.descripciondp,
                            fechacreadodc = modelo.fechacreadodp,
                            ordendc = modelo.ordendp,
                            //idtrcdc = modelo.idtrcdc,
                            estadoprocedimientodc = modelo.estadoprocedimientodp,
                            //comentariodc = modelo.comentariodp,
                            //fechasupervision = modelo.fechasupervision,
                            //idvisitadc = modelo.idvisitadp,
                            idpadredc = modelo.idpadredp,
                            estadodc = modelo.estadodc,
                        };
                        _context.detallecuestionarios.Add(tablaDestino);
                        _context.SaveChanges();
                        if (!(modelo.idpadredp == null))
                        {
                            modelo.nombreDetallePadre = DetalleCuestionarioModelo.FindNombreById(modelo.idpadredp);
                            modelo.ordendpPadre = DetalleCuestionarioModelo.FindOrdenPadreById(modelo.idpadredp);
                            modelo.ordenDhPresentacion = MetodosModelo.ordenConversion(modelo.ordendp);
                        }
                        modelo.guardadoBase = true;
                        modelo.IsEditable = false;
                        modelo.iddp = tablaDestino.iddc;
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
                        modelo.usuarioProgramaAccionModeloDp.iddcupa = modelo.iddp;
                        modelo.usuarioProgramaAccionModeloDp.idencargo = idEncargo;
                        result = true;
                        if (UsuarioProgramaAccionModelo.InsertByCuestionarioPrograma(modelo.usuarioProgramaAccionModeloDp,idEncargo))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error al insertar el detalle de la accion en cuestionario ");
                        }
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar detalle cuestionario : \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static int InsertbyImportacionByRange(ObservableCollection<detallecuestionario> lista, UsuarioModelo usuarioModelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecuestionarios', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecuestionarios) + 1);");
                            sincronizar = true;
                        }
                        try
                        {
                            _context.detallecuestionarios.AddRange(lista);
                            _context.SaveChanges();
                            result = 1;//éxito completo
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Exception en insertar listado detalle : \n" + e);
                            try
                            {
                                foreach (detallecuestionario item in lista)
                                {
                                    _context.detallecuestionarios.Add(item);
                                    _context.SaveChanges();
                                }
                                result = 1;
                            }
                            catch
                            {
                                MessageBox.Show("Exception en insertar listado detalle : \n" + e);
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
                    throw;
                }
            }
            else
            {
                return result;
            }
        }
        public static int InsertbyImportacion(DetalleCuestionarioModelo modelo,int idEncargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecuestionarios', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecuestionarios) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallecuestionario
                        {
                            //iddp = modelo.iddp,
                            idtprocedimientodc = modelo.idtprocedimientodp,
                            idprogramadc = modelo.idprogramadp,
                            //idpapelesdc = modelo.idpapelesdp,
                            descripciondc = modelo.descripciondp,
                            fechacreadodc = modelo.fechacreadodp,
                            ordendc = modelo.ordendp,
                            idtrcdc = modelo.idtrcdc,
                            estadoprocedimientodc = modelo.estadoprocedimientodp,
                            comentariodc = modelo.comentariodp,
                            fechasupervision = modelo.fechasupervision,
                            idvisitadc = modelo.idvisitadp,
                            estadodc = modelo.estadodc,
                            //idpadredc = modelo.idpadredp,
                        };

                        _context.detallecuestionarios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsEditable = false;
                        modelo.iddp = tablaDestino.iddc;
                        //Creación de registro auxiliar de acción realizada
                        modelo.usuarioProgramaAccionModeloDp.idprograma = modelo.idprogramadp;
                        modelo.usuarioProgramaAccionModeloDp.idusuarioupa = modelo.usuarioModeloDp.idUsuario;
                        modelo.usuarioProgramaAccionModeloDp.iddcupa = modelo.iddp;
                        modelo.usuarioProgramaAccionModeloDp.idencargo = idEncargo;
                        if (UsuarioProgramaAccionModelo.InsertByCuestionarioPrograma(modelo.usuarioProgramaAccionModeloDp,idEncargo))
                        {
                            result = 1;//éxito completo
                        }
                        else
                        {
                            result = 2;//Error al  insertar registro  auxiliar
                        }
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar detalle cuestionario : " + e.Message);
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

        public static int InsertbyImportacion(detallecuestionario modelo, UsuarioModelo usuarioModelo,int idEncargo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecuestionarios', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecuestionarios) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.detallecuestionarios.Add(modelo);
                        _context.SaveChanges();
                        //Creación de registro auxiliar de acción realizada
                        //modelo.usuarioProgramaAccionModeloDp.idprograma = modelo.idprogramadp;
                        //modelo.usuarioProgramaAccionModeloDp.idusuarioupa = modelo.usuarioModeloDp.idUsuario;
                        //modelo.usuarioProgramaAccionModeloDp.iddcupa = modelo.iddp;
                        UsuarioProgramaAccionModelo accion = new UsuarioProgramaAccionModelo();
                        accion.idprograma = modelo.idprogramadc;
                        accion.idusuarioupa = usuarioModelo.idUsuario;
                        accion.iddcupa = modelo.iddc;
                        accion.rolupa = "C";
                        accion.idencargo = idEncargo;
                        if (UsuarioProgramaAccionModelo.InsertByCuestionarioPrograma(accion,idEncargo))
                        {
                            result = 1;//éxito completo
                        }
                        else
                        {
                            result = 2;//Error al  insertar registro  auxiliar
                        }
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar detalle cuestionario : " + e);
                    return 3;//Hay una excepcion
                    //throw;
                }
                //    //http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
            }
            else
            {
                return result;
            }
        }


        public static bool InsertByPrograma(DetalleCuestionarioModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecuestionarios', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecuestionarios) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallecuestionario
                        {
                            //iddp = modelo.iddp,
                            idtprocedimientodc = modelo.idtprocedimientodp,
                            idprogramadc = modelo.idprogramadp,
                            idpapelesdc = modelo.idpapelesdp,
                            descripciondc = modelo.descripciondp,
                            fechacreadodc = modelo.fechacreadodp,
                            ordendc = modelo.ordendp,
                            idtrcdc = modelo.idtrcdc,
                            estadoprocedimientodc = modelo.estadoprocedimientodp,
                            comentariodc = modelo.comentariodp,
                            fechasupervision = modelo.fechasupervision,
                            idvisitadc = modelo.idvisitadp,
                            idpadredc = modelo.idpadredp,
                            estadodc = modelo.estadodc,
                        };
                        if (tablaDestino.idtprocedimientodc == 0)
                        {
                            tablaDestino.idtprocedimientodc = null;
                        }
                        _context.detallecuestionarios.Add(tablaDestino);
                        _context.SaveChanges();
                        if (!(modelo.idpadredp == null))
                        {
                            modelo.nombreDetallePadre = DetalleCuestionarioModelo.FindNombreById(modelo.idpadredp);
                            modelo.ordendpPadre = DetalleCuestionarioModelo.FindOrdenPadreById(modelo.idpadredp);
                        }
                        //ReordenaSubRegistros(tablaDestino.iddc);
                        modelo.guardadoBase = true;
                        modelo.IsEditable = false;
                        modelo.iddp = tablaDestino.iddc;
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
        public static DetalleCuestionarioModelo Find(int id)
        {
            var entidad = new DetalleCuestionarioModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detallecuestionario modelo = _context.detallecuestionarios.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.iddp = modelo.iddc;
                        entidad.idtprocedimientodp = modelo.idtprocedimientodc;
                        entidad.idprogramadp = modelo.idprogramadc;
                        entidad.idpapelesdp = modelo.idpapelesdc;
                        entidad.descripciondp = modelo.descripciondc;
                        entidad.fechacreadodp = modelo.fechacreadodc;
                        entidad.ordendp = modelo.ordendc;
                        entidad.idtrcdc = modelo.idtrcdc;
                        entidad.estadoprocedimientodp = modelo.estadoprocedimientodc;
                        entidad.comentariodp = modelo.comentariodc;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.idvisitadp = modelo.idvisitadc;
                        entidad.idpadredp = modelo.idpadredc;
                        entidad.estadodc = modelo.estadodc;
                        entidad.IsSelected = false;
                        entidad.referenciaPt = "";
                        entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordendp);
                        if (!(entidad.idpadredp == null))
                        {
                            entidad.nombreDetallePadre = DetalleCuestionarioModelo.FindNombreById(entidad.idpadredp);
                            entidad.ordendpPadre = DetalleCuestionarioModelo.FindOrdenPadreById(entidad.idpadredp);
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
                        ObservableCollection<tiporespuestacuestionario> listarespuestas = TipoRespuestaCuestionarioModelo.GetAllDisplay();
                        if (!(entidad.idtrcdc == null))
                        {
                            entidad.tiporespuestacuestionario = listarespuestas.SingleOrDefault(x => x.idtrc == entidad.idtrcdc);
                            entidad.respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc;
                        }
                        entidad.isuso = modelo.isuso;
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.iddcedulas = modelo.iddcedulas;

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
                    ordenMaximo = _context.detallecuestionarios.Where(x => x.idprogramadc == idprogramadp).Max(p => p.ordendc);
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
                    string commandString = String.Format("DELETE FROM sgpt.detallecuestionarios WHERE iddc={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString); 
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static DetalleCuestionarioModelo GetRegistro(string id)
        {
            var entidad = new DetalleCuestionarioModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidad = null;
                    }
                    detallecuestionario modelo = _context.detallecuestionarios.Find(id);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.iddp = modelo.iddc;
                        entidad.idtprocedimientodp = modelo.idtprocedimientodc;
                        entidad.idprogramadp = modelo.idprogramadc;
                        entidad.idpapelesdp = modelo.idpapelesdc;
                        entidad.descripciondp = modelo.descripciondc;
                        entidad.fechacreadodp = modelo.fechacreadodc;
                        entidad.ordendp = modelo.ordendc;
                        entidad.idtrcdc = modelo.idtrcdc;
                        entidad.estadoprocedimientodp = modelo.estadoprocedimientodc;
                        entidad.comentariodp = modelo.comentariodc;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.idvisitadp = modelo.idvisitadc;
                        entidad.idpadredp = modelo.idpadredc;
                        entidad.estadodc = modelo.estadodc;
                        entidad.IsSelected = false;
                        entidad.referenciaPt = "";
                        entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordendp);
                        if (!(entidad.idpadredp == null))
                        {
                            entidad.nombreDetallePadre = DetalleCuestionarioModelo.FindNombreById(entidad.idpadredp);
                            entidad.ordendpPadre = DetalleCuestionarioModelo.FindOrdenPadreById(entidad.idpadredp);
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
                        ObservableCollection<tiporespuestacuestionario> listarespuestas = TipoRespuestaCuestionarioModelo.GetAllDisplay();
                        if (!(entidad.idtrcdc == null))
                        {
                            entidad.tiporespuestacuestionario = listarespuestas.SingleOrDefault(x => x.idtrc == entidad.idtrcdc);
                            entidad.respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc;
                        }
                        entidad.isuso = modelo.isuso;
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.iddcedulas = modelo.iddcedulas;

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

        internal static decimal? IndiceEjecucion(int idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.detallecuestionarios WHERE idprogramadc={0} AND estadodc = 'A' ORDER BY ordendc;", idPrograma);
                    int preguntas = 4;
                    int subpreguntas = 5;
                    int subsubpreguntas = 6;
                    var lista = _context.detallecuestionarios.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    decimal cantidadPreguntas = lista.Where(x => x.idtprocedimientodc == preguntas).Count();
                    decimal cantidadPreguntasRespuesta = lista.Where(x => x.idtprocedimientodc == preguntas && x.idtrcdc != null).Count();
                    if (lista.Count() > 0 && cantidadPreguntas > 0 && cantidadPreguntasRespuesta > 0)
                    {
                        #region Inicializacion

                        var listaHijos = lista.Where(x => x.idpadredc != null && x.idtprocedimientodc == subpreguntas).OrderBy(x => x.idpadredc);

                        var listaNietos = lista.Where(x => x.idpadredc != null && x.idtprocedimientodc == subsubpreguntas).OrderBy(x => x.idpadredc);

                        detallecuestionario anterior = new detallecuestionario();
                        anterior.idpadredc = 0;

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
                            foreach (detallecuestionario item in listaHijos)
                            {
                                if (item.idpadredc != anterior.idpadredc)
                                {
                                    if (lista.Where(x => x.idtprocedimientodc == preguntas && x.idtrcdc != null && x.iddc == item.idpadredc).Count() > 0)
                                    {
                                        //Si tiene respuesta se ajusta el total restandole la respuesta 
                                        indice = indice - (1 / cantidadPreguntas);
                                    }

                                    // Se adiciona las sub-respuestas respondidas ponderadas por la cantidad de preguntas

                                    cantidadPreguntasHijos = lista.Where(x => x.idpadredc == item.idpadredc
                                    && (x.idtprocedimientodc == subpreguntas)).Count();

                                    cantidadPreguntasRespuestaHijos = lista.Where(x => x.idpadredc == item.idpadredc
                                    && (x.idtprocedimientodc == subpreguntas)
                                    && x.idtrcdc != null).Count();

                                    //Ajustar por respuesta de nietos
                                    if (listaNietos.Where(x => x.idpadredc == item.iddc).Count() > 0)
                                    {
                                        cantidadPreguntasNietos = lista.Where(x => x.idpadredc == item.iddc
                                        && (x.idtprocedimientodc == subsubpreguntas)).Count();

                                        cantidadPreguntasRespuestaNietos = lista.Where(x => x.idpadredc == item.iddc
                                        && (x.idtprocedimientodc == subsubpreguntas)
                                        && x.idtrcdc != null).Count();

                                        if (lista.Where(x => x.idtprocedimientodc == subpreguntas && x.idtrcdc != null && x.idpadredc == item.iddc).Count() > 0)
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

                    string commandString = String.Format("SELECT * FROM sgpt.detallecuestionarios WHERE idprogramadc={0} AND estadodc = 'A' ORDER BY ordendc;", idPrograma);
                    int preguntas = 4;
                    int subpreguntas = 5;
                    int subsubpreguntas = 6;
                    var lista = _context.detallecuestionarios.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    decimal cantidadPreguntas = lista.Where(x => x.idtprocedimientodc == preguntas).Count();
                    decimal cantidadPreguntasRespuesta = lista.Where(x => x.idtprocedimientodc == preguntas && x.idtrcdc != null).Count();
                    if (lista.Count() > 0 && cantidadPreguntas > 0 && cantidadPreguntasRespuesta > 0)
                    {
                        #region Inicializacion

                        var listaHijos = lista.Where(x => x.idpadredc != null && x.idtprocedimientodc == subpreguntas).OrderBy(x => x.idpadredc);

                        var listaNietos = lista.Where(x => x.idpadredc != null && x.idtprocedimientodc == subsubpreguntas).OrderBy(x => x.idpadredc);

                        detallecuestionario anterior = new detallecuestionario();
                        anterior.idpadredc = 0;

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
                            foreach (detallecuestionario item in listaHijos)
                            {
                                if (item.idpadredc != anterior.idpadredc)
                                {
                                    if (lista.Where(x => x.idtprocedimientodc == preguntas && x.idtrcdc != null && x.iddc == item.idpadredc).Count() > 0)
                                    {
                                        //Si tiene respuesta se ajusta el total restandole la respuesta 
                                        indice = indice - (1 / cantidadPreguntas);
                                    }

                                    // Se adiciona las sub-respuestas respondidas ponderadas por la cantidad de preguntas

                                    cantidadPreguntasHijos = lista.Where(x => x.idpadredc == item.idpadredc
                                    && (x.idtprocedimientodc == subpreguntas)).Count();

                                    cantidadPreguntasRespuestaHijos = lista.Where(x => x.idpadredc == item.idpadredc
                                    && (x.idtprocedimientodc == subpreguntas)
                                    && x.idtrcdc != null).Count();

                                    //Ajustar por respuesta de nietos
                                    if (listaNietos.Where(x => x.idpadredc == item.iddc).Count() > 0)
                                    {
                                        cantidadPreguntasNietos = lista.Where(x => x.idpadredc == item.iddc
                                        && (x.idtprocedimientodc == subsubpreguntas)).Count();

                                        cantidadPreguntasRespuestaNietos = lista.Where(x => x.idpadredc == item.iddc
                                        && (x.idtprocedimientodc == subsubpreguntas)
                                        && x.idtrcdc != null).Count();

                                        if (lista.Where(x => x.idtprocedimientodc == subpreguntas && x.idtrcdc != null && x.idpadredc == item.iddc).Count() > 0)
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

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleCuestionarioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    detallecuestionario entidad = _context.detallecuestionarios.Find(id);
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
                    var modelo = new DetalleCuestionarioModelo();
                    detallecuestionario entidad = _context.detallecuestionarios.Find(id);
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
                    var modelo = new DetalleCuestionarioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detallecuestionarios
                            .Where(b => b.estadodc == "B")
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
                    detallecuestionario entidad = _context.detallecuestionarios.Find(id);
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
                    return nombre = _context.detallecuestionarios.Find(id).descripciondc;
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
                    return nombre = _context.detallecuestionarios.Find(id).ordendc;
                }
            }
            else
            {
                return nombre;
            }
        }
        //Para realizar busquedas de texto

        public static void UpdateModelo(DetalleCuestionarioModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detallecuestionario entidad = _context.detallecuestionarios.Find(modelo.iddp);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        //entidad.iddc = modelo.iddp;
                        entidad.idtprocedimientodc = modelo.idtprocedimientodp;
                        entidad.idprogramadc = modelo.idprogramadp;
                        entidad.idpapelesdc = modelo.idpapelesdp;
                        entidad.descripciondc = modelo.descripciondp;
                        entidad.fechacreadodc = modelo.fechacreadodp;
                        entidad.ordendc = modelo.ordendp;
                        entidad.idtrcdc = modelo.idtrcdc;
                        entidad.estadoprocedimientodc = modelo.estadoprocedimientodp;
                        entidad.comentariodc = modelo.comentariodp;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.idvisitadc = modelo.idvisitadp;
                        entidad.idpadredc = modelo.idpadredp;
                        entidad.estadodc = modelo.estadodc;

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

        public static void UpdateModeloReodenar(DetalleCuestionarioModelo modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {

                        string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET ordendc = {0} WHERE iddc = {1};", modelo.ordendp, modelo.iddp);
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

        public static bool UpdateModeloByImportacion(DetalleCuestionarioModelo modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET idpadredc = {0} WHERE iddc = {1};", modelo.idpadredp, modelo.iddp);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString); 
                        _context.SaveChanges();
                        /*detallecuestionario entidad = _context.detallecuestionarios.Find(modelo.iddp);
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
                            //entidad.idtrcdc = modelo.idtrcdc;
                            //entidad.fechafindp = modelo.fechafindp;
                            //entidad.horaplandp = modelo.horaplandp;
                            //entidad.horaejecdp = modelo.horaejecdp;
                            //entidad.estadoprocedimientodp = modelo.estadoprocedimientodp;
                            //entidad.comentariodp = modelo.comentariodp;
                            //entidad.estadodp = modelo.estadodp;
                            //entidad.fechasupervision = modelo.fechasupervision;
                            //entidad.idvisitadp = modelo.idvisitadp;
                            entidad.idpadredc = modelo.idpadredp;
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
                MessageBox.Show("Exception en insertar actualizacion  del principal : " + e.Message);
                throw;
            }
        }

        public static bool UpdateModeloByImportacion(detallecuestionario modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET idpadredc = {0} WHERE iddc = {1};", modelo.idpadredc, modelo.iddc);
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
                MessageBox.Show("Exception en insertar actualizacion  del principal : " + e.Message);
                throw;
            }
        }

       public static bool UpdateModeloReferencia(DetalleCuestionarioModelo modelo, UniversalPTModelo papel)
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
                        string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET tabla = '{0}',idgenerico={1} WHERE iddc={2};", papel.tablaUpt, papel.idOrigenUpt, modelo.iddp);
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

        public static bool UpdateModeloEjecucion(DetalleCuestionarioModelo modelo)
        {
            if (modelo != null && modelo.iddp != 0)
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            //Borrado de acciones
                            //UsuarioProgramaAccionModelo.DeleteBorradoLogicoByIdPrograma(id);

                            string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET comentariodc = '{0}', idtrcdc={1} WHERE iddc={2};", modelo.comentariodp, modelo.idtrcdc, modelo.iddp);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            return true;

                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        MessageBox.Show("Exception guardado de ejecución \n " + e);
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }

        public static bool UpdateModeloEjecucion(DetalleCuestionarioModelo modelo, int caso)
        {
            string commandString = string.Empty;
            if (modelo != null && modelo.iddp != 0)
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            //Borrado de acciones
                            //UsuarioProgramaAccionModelo.DeleteBorradoLogicoByIdPrograma(id);
                            switch (caso)
                            { 
                            case 1://Cambio solo tipo de respuesta
                                commandString = String.Format("UPDATE sgpt.detallecuestionarios SET idtrcdc={0} WHERE iddc={1};", modelo.idtrcdc, modelo.iddp);
                                commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                    _context.Database.ExecuteSqlCommand(commandString);
                                    _context.SaveChanges();
                                    break;
                            case 2://Cambio  comentario y tipo de respuesta
                                commandString = String.Format("UPDATE sgpt.detallecuestionarios SET comentariodc = '{0}', idtrcdc={1} WHERE iddc={2};", modelo.comentariodp, modelo.idtrcdc, modelo.iddp);
                                commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                    _context.Database.ExecuteSqlCommand(commandString);
                                    _context.SaveChanges();
                                    break;
                            case 3:// cambio solo comentario
                                    commandString = String.Format("UPDATE sgpt.detallecuestionarios SET comentariodc = '{0}' WHERE iddc={1};", modelo.comentariodp, modelo.iddp);
                                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                    _context.Database.ExecuteSqlCommand(commandString);
                                    _context.SaveChanges();
                                    break;
                                default:
                                    MessageBox.Show("Error en el cambio del registro ");
                                    break;
                            }
                            return true;

                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        MessageBox.Show("Exception guardado de ejecución \n " + e);
                        return false;
                    }
                }
            }
            else
            {
                return true;
            }
        }


        public static bool UpdateModelo(DetalleCuestionarioModelo modelo, UsuarioModelo usuarioModelo,int idEncargo)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        string rolAccion = "M";
                        detallecuestionario entidad = _context.detallecuestionarios.Find(modelo.iddp);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddp = modelo.iddp; no puede cambiar
                            if (!(entidad.idpapelesdc == modelo.idpapelesdp))
                            {
                                entidad.idpapelesdc = modelo.idpapelesdp;
                                rolAccion = "R";
                                cambio = true;
                            }
                            if (!(entidad.idtprocedimientodc == modelo.idtprocedimientodp))
                            {
                                entidad.idtprocedimientodc = modelo.idtprocedimientodp;
                                cambio = true;
                            }
                            //entidad.idprogramadc = modelo.idprogramadp; No puede cambiar
                            if (!(entidad.descripciondc.ToUpper() == modelo.descripciondp.ToUpper()))
                            {
                                entidad.descripciondc = modelo.descripciondp;
                                cambio = true;
                            }
                            if (!(entidad.ordendc == modelo.ordendp))
                            {
                                entidad.ordendc = modelo.ordendp;
                                cambio = true;
                            }
                            if (!(entidad.idvisitadc == modelo.idvisitadp))
                            {
                                entidad.idvisitadc = modelo.idvisitadp;
                                cambio = true;
                            }
                            if (!(entidad.idpadredc == modelo.idpadredp))
                            {
                                entidad.idpadredc = modelo.idpadredp;
                                cambio = true;
                            }
                            if (!(entidad.idtrcdc == modelo.idtrcdc))
                            {
                                if (modelo.idtrcdc != 0)
                                {
                                    entidad.idtrcdc = modelo.idtrcdc;
                                }
                                else
                                {
                                    //Se limpia el registro
                                    //detallecuestionario registro = new detallecuestionario();
                                    modelo.idtrcdc = null;
                                }
                                cambio = true;
                                rolAccion = "E";
                            }
                            if (!(entidad.comentariodc == modelo.comentariodp))
                            {
                                entidad.comentariodc = modelo.comentariodp;
                                cambio = true;
                                rolAccion = "E";
                            }
                            if (cambio)
                            {
                                //entidad.iddp = modelo.iddp;
                                entidad.iddc = modelo.iddp;
                                entidad.idtprocedimientodc = modelo.idtprocedimientodp;
                                entidad.idprogramadc = modelo.idprogramadp;
                                entidad.idpapelesdc = modelo.idpapelesdp;
                                entidad.descripciondc = modelo.descripciondp;
                                entidad.fechacreadodc = modelo.fechacreadodp;
                                entidad.ordendc = modelo.ordendp;
                                entidad.idtrcdc = modelo.idtrcdc;
                                entidad.estadoprocedimientodc = modelo.estadoprocedimientodp;
                                entidad.comentariodc = modelo.comentariodp;
                                entidad.fechasupervision = modelo.fechasupervision;
                                entidad.idvisitadc = modelo.idvisitadp;
                                entidad.idpadredc = modelo.idpadredp;
                                entidad.estadodc = modelo.estadodc;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();

                                //Crear modificacion del registro 
                                UsuarioProgramaAccionModelo temporal = new UsuarioProgramaAccionModelo();
                                temporal.idusuarioupa = usuarioModelo.idUsuario;
                                temporal.idprograma = modelo.idprogramadp;
                                temporal.iddcupa = modelo.iddp;
                                temporal.nombreUsuario = usuarioModelo.inicialesusuario;
                                temporal.idencargo = idEncargo;
                                temporal.rolupa = rolAccion;
                                //Creación de registro auxiliar de acción realizada
                                if (UsuarioProgramaAccionModelo.InsertByPrograma(temporal,idEncargo))
                                {
                                    return true; ;//éxito completo
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
                        MessageBox.Show("Exception en actualizar entidad detalle cuestionario \n" + e);
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
                            //detallecuestionario entidad = _context.detallecuestionarios.Find(id);
                            //Borrado del detalle de programas
                            var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByDetalleCuestionario(id);
                            if (listaDetalleAcciones.Count > 0)
                            {
                                foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                                {
                                    UsuarioProgramaAccionModelo.DeleteBorradoLogico(item.idupa);
                                }
                            }
                            string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET estadodc = 'B' WHERE iddc={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString); 
                            _context.SaveChanges();

                            //entidad.estadodc = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del detalle de cuestionario: " + e.Message);
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

        public static void DeleteBorradoLogicoByIdCuestionario(int id)
        {
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            //Borrado de acciones
                            UsuarioProgramaAccionModelo.DeleteBorradoLogicoByIdPrograma(id);

                            string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET estadodc = 'B' WHERE idprogramadc={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString); 
                            _context.SaveChanges();

                            //entidad.estadodc = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();

                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del detalle de cuestionario: " + e.Message);
                        throw;
                    }
                }
            }
        }

        internal static bool UpdateModeloCierreProcedimiento(DetalleCuestionarioModelo modelo, UsuarioModelo usuarioModelo,int idEncargo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET estadoprocedimientodc = 'T' WHERE iddc = {0};", modelo.iddp);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString); 
                        _context.SaveChanges();
                        modelo.estadoprocedimientodp = "T";
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
                MessageBox.Show("Exception en insertar actualizacion cierre de preguntas : \n" + e);
                throw;
            }
        }

        public static void UpdateCierreIdCuestionario(int id)
        {
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            //Borrado de acciones
                            //UsuarioProgramaAccionModelo.DeleteBorradoLogicoByIdPrograma(id);

                            string commandString = String.Format("UPDATE sgpt.detallecuestionarios SET estadoprocedimientodc = 'T' WHERE idprogramadc={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString); 
                            _context.SaveChanges();

                            //entidad.estadodc = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();

                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro del detalle de cuestionario: " + e.Message);
                        throw;
                    }
                }
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
                        //detallecuestionario entidad = _context.detallecuestionarios.Find(id);
                        //Borrado del detalle de programas

                        var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByDetalleCuestionario(id);
                        if (listaDetalleAcciones.Count > 0)
                        {
                            foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                            {
                                UsuarioProgramaAccionModelo.Delete(item.idupa);
                            }
                        }
                        cantidad = _context.detallecuestionarios.Count(j => j.idpadredc == id);
                        while (_context.detallecuestionarios.Count(j => j.idpadredc == id) > 0)
                        {
                            idHijo = _context.detallecuestionarios.Where(j => j.idpadredc == id).FirstOrDefault().iddc;
                            DetalleCuestionarioModelo.Delete(idHijo);
                        }
                        //int idHijo = _context.detallecuestionarios.Single(j => j.idpadredp == id).iddp;
                        //No tiene hijos se puede borrar
                        string commandString = String.Format("DELETE FROM sgpt.detallecuestionarios WHERE iddc={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
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
                        //detallecuestionario entidad = _context.detallecuestionarios.Find(id);
                        //Borrado del detalle de programas
                        var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByDetalleCuestionario(id);
                        if (listaDetalleAcciones.Count > 0)
                        {
                            foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                            {
                                UsuarioProgramaAccionModelo.Delete(item.idupa);
                            }
                        }
                        while (_context.detallecuestionarios.Count(j => j.idpadredc == id) > 0)
                        {
                            idHijo = _context.detallecuestionarios.Where(j => j.idpadredc == id).FirstOrDefault().iddc;
                            DetalleCuestionarioModelo.Delete(idHijo);
                        }
                        //int idHijo = _context.detallecuestionarios.Single(j => j.idpadredp == id).iddp;
                        //No tiene hijos se puede borrar
                        string commandString = String.Format("DELETE FROM sgpt.detallecuestionarios WHERE iddc={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
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
                            string commandString = String.Format("DELETE FROM sgpt.detallecuestionarios WHERE iddc={0};", id);
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

        public static List<DetalleCuestionarioModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecuestionarios.Select(entidad =>
                     new DetalleCuestionarioModelo
                     {
                         iddp = entidad.iddc,
                         idtprocedimientodp = entidad.idtprocedimientodc,
                         idprogramadp = entidad.idprogramadc,
                         idpapelesdp = entidad.idpapelesdc,
                         descripciondp = entidad.descripciondc,
                         fechacreadodp = entidad.fechacreadodc,
                         ordendp = entidad.ordendc,
                         idtrcdc = entidad.idtrcdc,
                         estadoprocedimientodp = entidad.estadoprocedimientodc,
                         comentariodp = entidad.comentariodc,
                         fechasupervision = entidad.fechasupervision,
                         idvisitadp = entidad.idvisitadc,
                         idpadredp = entidad.idpadredc,
                         estadodc = entidad.estadodc,
                         IsSelected = false,
                         referenciaPt = "",
                         respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordendp).Where(x => x.estadodc == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (DetalleCuestionarioModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                        item.guardadoBase = true;
                        item.IsEditable = false;
                        item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                        item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
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


        public static List<DetalleCuestionarioModelo> GetAll(int? idprogramadp, int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecuestionarios.Select(entidad =>
                    new DetalleCuestionarioModelo
                    {
                        iddp = entidad.iddc,
                        idtprocedimientodp = entidad.idtprocedimientodc,
                        idprogramadp = entidad.idprogramadc,
                        idpapelesdp = entidad.idpapelesdc,
                        descripciondp = entidad.descripciondc,
                        fechacreadodp = entidad.fechacreadodc,
                        ordendp = entidad.ordendc,
                        idtrcdc = entidad.idtrcdc,
                        estadoprocedimientodp = entidad.estadoprocedimientodc,
                        comentariodp = entidad.comentariodc,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadc,
                        idpadredp = entidad.idpadredc,
                        estadodc = entidad.estadodc,
                        IsSelected = false,
                        referenciaPt = "",
                        respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc,
                        //tipoProcedimientoModelo = new TipoProcedimientoModelo
                        //{
                        //    id = entidad.tipoprocedimiento.idtprocedimiento,
                        //    descripcion = entidad.tipoprocedimiento.descripciontprocedimiento,
                        //    sistema = entidad.tipoprocedimiento.sistematprocedimiento,
                        //    idThTprocedimiento = entidad.tipoprocedimiento.idthtprocedimiento,
                        //    estado = entidad.tipoprocedimiento.estadotprocedimiento
                        //},
                        //visitaModelo = new VisitaModelo
                        //{
                        //    id = entidad.visita.idvisita,
                        //    descripcion = entidad.visita.descripcionvisita,
                        //    sistema = entidad.visita.sistemavisita,
                        //    estado = entidad.visita.estadovisita
                        //},
                        respuestaCuestionarioDp = entidad.tiporespuestacuestionario.descripciontrc,
                        descripciontrc = entidad.tiporespuestacuestionario.descripciontrc,
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        isuso = entidad.isuso,
                        idrepositorio = entidad.idrepositorio,
                        idcedulas = entidad.idcedulas,
                        idgenerico = entidad.idgenerico,
                        tabla = entidad.tabla,
                        iddcedulas = entidad.iddcedulas,

                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodc == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleCuestionarioModelo>();
                    }
                    else
                    {
                        //Obtener listados de referencias

                        ObservableCollection<UniversalPTModelo> referencias = UniversalPTModelo.GetAllContenido(idEncargo);

                        DetalleCuestionarioModelo temporal;
                        int i = 1;
                        foreach (DetalleCuestionarioModelo item in lista)
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
                                item.DetalleCuestionarioModeloPadre = temporal;
                            }
                            if (item.idgenerico != null && item.idgenerico > 0)
                            {
                                try
                                {
                                    item.referenciaPt = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                    item.referenciaPtDp = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Error en la busqueda dela referencia \n" + e);
                                }
                            }
                            item.guardadoBase = true;
                            item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                            item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                        }
                        //Obtener la referencias


                        return RegeneraOrdenSubRegistros(lista);
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas \n" + e);
                var lista = new ObservableCollection<DetalleCuestionarioModelo>();
                return lista.ToList();
            }
        }

        public static List<DetalleCuestionarioModelo> GetAll(int? idprogramadp, bool ordenar,int? idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecuestionarios.Select(entidad =>
                    new DetalleCuestionarioModelo
                    {
                        iddp = entidad.iddc,
                        idtprocedimientodp = entidad.idtprocedimientodc,
                        idprogramadp = entidad.idprogramadc,
                        idpapelesdp = entidad.idpapelesdc,
                        descripciondp = entidad.descripciondc,
                        fechacreadodp = entidad.fechacreadodc,
                        ordendp = entidad.ordendc,
                        idtrcdc = entidad.idtrcdc,
                        estadoprocedimientodp = entidad.estadoprocedimientodc,
                        comentariodp = entidad.comentariodc,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadc,
                        idpadredp = entidad.idpadredc,
                        estadodc = entidad.estadodc,
                        IsSelected = false,
                        referenciaPt = "",
                        respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc,
                        //tipoProcedimientoModelo = new TipoProcedimientoModelo
                        //{
                        //    id = entidad.tipoprocedimiento.idtprocedimiento,
                        //    descripcion = entidad.tipoprocedimiento.descripciontprocedimiento,
                        //    sistema = entidad.tipoprocedimiento.sistematprocedimiento,
                        //    idThTprocedimiento = entidad.tipoprocedimiento.idthtprocedimiento,
                        //    estado = entidad.tipoprocedimiento.estadotprocedimiento
                        //},
                        //visitaModelo = new VisitaModelo
                        //{
                        //    id = entidad.visita.idvisita,
                        //    descripcion = entidad.visita.descripcionvisita,
                        //    sistema = entidad.visita.sistemavisita,
                        //    estado = entidad.visita.estadovisita
                        //},
                        respuestaCuestionarioDp = entidad.tiporespuestacuestionario.descripciontrc,
                        descripciontrc = entidad.tiporespuestacuestionario.descripciontrc,
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        isuso = entidad.isuso,
                        idrepositorio = entidad.idrepositorio,
                        idcedulas = entidad.idcedulas,
                        idgenerico = entidad.idgenerico,
                        tabla = entidad.tabla,
                        iddcedulas = entidad.iddcedulas,
                        guardadoBase=true,
                        IsEditable=false,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodc == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleCuestionarioModelo>();
                    }
                    else
                    {
                        DetalleCuestionarioModelo temporal;
                        int i = 1;
                        ObservableCollection<UniversalPTModelo> referencias = UniversalPTModelo.GetAllContenido(idEncargo);

                        foreach (DetalleCuestionarioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            if (!(item.idpadredp == null))
                            {
                                //temporal = DetalleCuestionarioModelo.Find((int)item.idpadredp);
                                temporal = lista.SingleOrDefault(x => x.iddp == item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleCuestionarioModeloPadre = temporal;
                            }
                            item.modeloEstadoProcedimientoDp = EtapaEncargoModelo.seleccionEtapa(item.estadoprocedimientodp);
                            item.nombreEstadoProcedimientoDp = item.modeloEstadoProcedimientoDp.descripcionEtapaEncargo;
                            if (item.idgenerico != null && item.idgenerico > 0)
                            {
                                try
                                {
                                    item.referenciaPt = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                    item.referenciaPtDp = referencias.Single(x => x.idOrigenUpt == item.idgenerico && x.tablaUpt == item.tabla).referenciaTpt;
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("Error en la busqueda dela referencia \n" + e);
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
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                var lista = new ObservableCollection<DetalleCuestionarioModelo>();
                return lista.ToList();
            }
        }

        public static List<detallecuestionario> GetAllCapaDatos(int? idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.detallecuestionarios WHERE idprogramadc={0} AND estadodc = 'A' ORDER BY ordendc;", idPrograma);

                    var lista = _context.detallecuestionarios.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<detallecuestionario> temporal = new ObservableCollection<detallecuestionario>(lista);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle cuestionario \n" + e);
                detallecuestionario registroAdicional = new detallecuestionario();
                registroAdicional.iddc = 0;
                registroAdicional.descripciondc = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<detallecuestionario>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }
        public static List<DetalleCuestionarioModelo> GetAllVista(int? idprogramadp)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecuestionarios.Select(entidad =>
                    new DetalleCuestionarioModelo
                    {
                        iddp = entidad.iddc,
                        idtprocedimientodp = entidad.idtprocedimientodc,
                        idprogramadp = entidad.idprogramadc,
                        idpapelesdp = entidad.idpapelesdc,
                        descripciondp = entidad.descripciondc,
                        fechacreadodp = entidad.fechacreadodc,
                        ordendp = entidad.ordendc,
                        idtrcdc = entidad.idtrcdc,
                        estadoprocedimientodp = entidad.estadoprocedimientodc,
                        comentariodp = entidad.comentariodc,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadc,
                        idpadredp = entidad.idpadredc,
                        estadodc = entidad.estadodc,
                        respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc,
                        nombreDetallePadre = "",
                        IsSelected = false,
                        referenciaPt = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodc == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleCuestionarioModelo>();
                    }
                    else
                    {
                        DetalleCuestionarioModelo temporal;
                        int i = 1;
                        foreach (DetalleCuestionarioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            item.guardadoBase = true;
                            item.IsEditable = false;
                            if (!(item.idpadredp == null))
                            {
                                temporal = DetalleCuestionarioModelo.Find((int)item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleCuestionarioModeloPadre = temporal;
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
                var lista = new ObservableCollection<DetalleCuestionarioModelo>();
                return lista.ToList();
            }
        }

        public static List<DetalleCuestionarioModelo> GetAllVistaEjecucion(int? idprogramadp,int? idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecuestionarios.Select(entidad =>
                    new DetalleCuestionarioModelo
                    {
                        iddp = entidad.iddc,
                        idtprocedimientodp = entidad.idtprocedimientodc,
                        idprogramadp = entidad.idprogramadc,
                        idpapelesdp = entidad.idpapelesdc,
                        descripciondp = entidad.descripciondc,
                        fechacreadodp = entidad.fechacreadodc,
                        ordendp = entidad.ordendc,
                        idtrcdc = entidad.idtrcdc,
                        estadoprocedimientodp = entidad.estadoprocedimientodc,
                        comentariodp = entidad.comentariodc,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadc,
                        idpadredp = entidad.idpadredc,
                        estadodc = entidad.estadodc,
                        IsSelected = false,
                        referenciaPt = "",
                        respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc,
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        descripciontrc = entidad.tiporespuestacuestionario.descripciontrc,
                        isuso = entidad.isuso,
                        idrepositorio = entidad.idrepositorio,
                        idcedulas = entidad.idcedulas,
                        idgenerico = entidad.idgenerico,
                        tabla = entidad.tabla,
                        iddcedulas = entidad.iddcedulas,
                        guardadoBase = true,
                        IsEditable = false,
                        isBotonReferenciar = false,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodc == "A" && x.idprogramadp == idprogramadp).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleCuestionarioModelo>();
                    }
                    else
                    {
                        ObservableCollection<UniversalPTModelo> referencias = UniversalPTModelo.GetAllContenido(idEncargo);
                        DetalleCuestionarioModelo temporal;
                        int i = 1;
                        foreach (DetalleCuestionarioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                            if (!(item.idpadredp == null))
                            {
                                //temporal = DetalleCuestionarioModelo.Find((int)item.idpadredp);
                                temporal = lista.SingleOrDefault(x => x.iddp == item.idpadredp);
                                item.nombreDetallePadre = temporal.descripciondp;
                                item.ordendpPadre = temporal.ordendp;
                                item.DetalleCuestionarioModeloPadre = temporal;
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
                var lista = new ObservableCollection<DetalleCuestionarioModelo>();
                return lista.ToList();
            }
        }

        public static bool DeleteByIdProgramaRange(int? idprogramadp)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.detallecuestionarios WHERE idprogramadc={0};", idprogramadp);
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
                    MessageBox.Show("No fue posible la eliminacion de la lista detalle herramientas \n" + e);
                return false;
            }
        }

        public static List<DetalleCuestionarioModelo> GetAll(int? idprogramadp, int? iddpSeleccionado)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.detallecuestionarios.Select(entidad =>
                    new DetalleCuestionarioModelo
                    {
                        iddp = entidad.iddc,
                        idtprocedimientodp = entidad.idtprocedimientodc,
                        idprogramadp = entidad.idprogramadc,
                        idpapelesdp = entidad.idpapelesdc,
                        descripciondp = entidad.descripciondc,
                        fechacreadodp = entidad.fechacreadodc,
                        ordendp = entidad.ordendc,
                        idtrcdc = entidad.idtrcdc,
                        estadoprocedimientodp = entidad.estadoprocedimientodc,
                        comentariodp = entidad.comentariodc,
                        fechasupervision = entidad.fechasupervision,
                        idvisitadp = entidad.idvisitadc,
                        idpadredp = entidad.idpadredc,
                        estadodc = entidad.estadodc,
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
                        tiporespuestacuestionario = entidad.tiporespuestacuestionario,
                        descripciontrc = entidad.tiporespuestacuestionario.descripciontrc,
                        respuestaSeleccionadadc = entidad.tiporespuestacuestionario.descripciontrc,
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendp).Where(x => x.estadodc == "A" && x.idprogramadp == idprogramadp && x.iddp == iddpSeleccionado).ToList();
                    DetalleCuestionarioModelo temporal;
                    int i = 1;
                    foreach (DetalleCuestionarioModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendp);
                        item.guardadoBase = true;
                        item.IsEditable = false;
                        if (!(item.idpadredp == null))
                        {
                            temporal = DetalleCuestionarioModelo.Find((int)item.idpadredp);
                            item.nombreDetallePadre = temporal.descripciondp;
                            item.ordendpPadre = temporal.ordendp;
                            item.DetalleCuestionarioModeloPadre = temporal;
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


        #endregion

        #region Contar registros
        public static int ContarRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detallecuestionarios.Where(x => x.idprogramadc == id && x.estadodc == "A").Count();
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

        public static int ContarSubRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detallecuestionarios.Where(x => x.idpadredc == id && x.estadodc == "A").Count();
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
                    elementos = _context.detallecuestionarios.Where(x => x.estadodc == "A").Count();
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
                    var entidad = (from p in _context.detallecuestionarios
                                   where p.descripciondc.ToLower().Equals(busqueda)
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
                    elementos = _context.detallecuestionarios.Where(x => x.descripciondc.ToUpper() == busqueda && x.estadodc == "A").Count();
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
                string busqueda = texto.ToUpper().Trim();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detallecuestionarios.Where(x => x.descripciondc.ToUpper().Trim() == busqueda && x.estadodc == "A" && x.iddc == iddp).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

       
        #endregion

        #region generacion del orden

        #region generacion del orden

        public static List<DetalleCuestionarioModelo> RegeneraOrdenSubRegistros2(List<DetalleCuestionarioModelo> listaDetalleHerramienta)
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
                    ObservableCollection<DetalleCuestionarioModelo> listaHijos = new ObservableCollection<DetalleCuestionarioModelo>();
                    int ubicacion = 0;
                    foreach (DetalleCuestionarioModelo itemDetalle in listaDetalleHerramienta)
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
                                DetalleCuestionarioModelo.UpdateModeloReodenar(itemDetalle);
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
                                    DetalleCuestionarioModelo.UpdateModeloReodenar(itemDetalle);
                                    //Se modifica el orden para mantener una estandarizacion
                                }
                            }
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    foreach (DetalleCuestionarioModelo item in listaDetalleHerramienta)
                    {
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<DetalleCuestionarioModelo>(listaDetalleHerramienta.Where(x => x.idpadredp == item.iddp));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)item.ordendp;
                            factor = MetodosModelo.factorPadre(item.nombreTipoProcedimiento);
                            int j = 1;
                            guardar = false;
                            ubicacion = -1;
                            foreach (DetalleCuestionarioModelo hijo in listaHijos)
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
                                        DetalleCuestionarioModelo.UpdateModelo(listaDetalleHerramienta[ubicacion]);
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
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta.OrderBy(x => x.ordendp).ToList();
                    throw;
                }
            }
        }

        public static List<DetalleCuestionarioModelo> RegeneraOrdenSubRegistros(List<DetalleCuestionarioModelo> listaDetalleHerramienta)
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
                    ObservableCollection<DetalleCuestionarioModelo> listaHijos = new ObservableCollection<DetalleCuestionarioModelo>();
                    ObservableCollection<DetalleCuestionarioModelo> listaPadres = new ObservableCollection<DetalleCuestionarioModelo>();
                    ObservableCollection<DetalleCuestionarioModelo> listaDetalle = new ObservableCollection<DetalleCuestionarioModelo>();

                    foreach (DetalleCuestionarioModelo itemDetalle in listaDetalleHerramienta)
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
                                DetalleCuestionarioModelo.UpdateModeloReodenar(itemDetalle);
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
                            listaHijos = new ObservableCollection<DetalleCuestionarioModelo>(listaDetalleHerramienta.Where(x => x.idpadredp == listaPadres[0].iddp));
                            if (listaHijos.Count > 0)
                            {
                                //Hay hijos
                                contador = (decimal)listaPadres[0].ordendp;
                                //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                                int j = 1;
                                guardar = false;
                                foreach (DetalleCuestionarioModelo hijo in listaHijos)
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

                                    hijo.DetalleCuestionarioModeloPadre = listaPadres[0]; ;
                                    hijo.descripcionPadre = hijo.DetalleCuestionarioModeloPadre.descripciondpSeleccion;

                                    j++;
                                    if (guardar)
                                    {
                                        DetalleCuestionarioModelo.UpdateModeloReodenar(hijo);
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

        #endregion

        #region constructores

        public DetalleCuestionarioModelo()
        {
            iddp = 0;
            idtprocedimientodp = 0;
            idprogramadp = 0;
            //idpapelesdp = 0;
            descripciondp = string.Empty;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = 1;
            //idtrcdc = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture); 
            estadoprocedimientodp = "I";
            comentariodp = "";
            //fechasupervision = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //idvisitadp = entidad.idvisitadp;
            //idpadredp = entidad.idpadredp;
            ordenDhPresentacion = MetodosModelo.ordenConversion(ordendp);
            estadodc = "A";
            //idvisitadp = 0;
            guardadoBase = false;
            IsEditable = false;
            descripciontrc = string.Empty;
            IsSelected = false;
            referenciaPt = string.Empty;
            descripciondpSeleccion = string.Empty;
            isuso = 0;
            idrepositorio = null;
            idcedulas = null;
            idgenerico = null;
            tabla = null;
            iddcedulas = null;
        }
        public DetalleCuestionarioModelo(int idTprocedimientodp, int idProgramadp, UsuarioModelo usuarioModelo)
        {
            iddp = 0;
            idtprocedimientodp = idTprocedimientodp;
            idprogramadp = idProgramadp;
            //idpapelesdp = 0;
            descripciondp = string.Empty;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)FindOrden(idprogramadp) + 1; ;
            //idtrcdc = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //idvisitadp = entidad.idvisitadp;
            //idpadredp = entidad.idpadredp;
            //idvisitadp = 0;
            ordenDhPresentacion = MetodosModelo.ordenConversion(ordendp);
            //idvisitadp = 0;
            estadodc = "A";
            guardadoBase = false;
            IsEditable = false;
            usuarioModeloDp = usuarioModelo;
            usuarioModificoDp = usuarioModelo.inicialesusuario;
            usuarioProgramaAccionModeloDp = new UsuarioProgramaAccionModelo(iddp);
            IsSelected = false;
            descripciontrc = string.Empty;
            referenciaPt = string.Empty;
            descripciondpSeleccion = string.Empty;
            guardadoBase = false;
            IsEditable = false;
            descripciontrc = string.Empty;
            IsSelected = false;
            referenciaPt = string.Empty;
            descripciondpSeleccion = string.Empty;
            isuso = 0;
            idrepositorio = null;
            idcedulas = null;
            idgenerico = null;
            tabla = null;
            iddcedulas = null;
        }
        public DetalleCuestionarioModelo(int idProgramadp, UsuarioModelo usuarioModelo)
        {
            iddp = 0;
            idtprocedimientodp = 0;
            idprogramadp = idProgramadp;
            //idpapelesdp = 0;
            descripciondp = string.Empty;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)FindOrden(idprogramadp) + 1;
            //idtrcdc = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //idvisitadp = entidad.idvisitadp;
            idpadredp = null;
            //idvisitadp = 0;
            ordenDhPresentacion = MetodosModelo.ordenConversion(ordendp);
            //idvisitadp = 0;
            estadodc = "A";
            guardadoBase = false;
            IsEditable = false;
            usuarioModeloDp = usuarioModelo;
            usuarioModificoDp = usuarioModelo.inicialesusuario;
            usuarioProgramaAccionModeloDp = new UsuarioProgramaAccionModelo(iddp);
            IsSelected = false;
            referenciaPt = "";
            descripciontrc = string.Empty;
            referenciaPt = string.Empty;
            descripciondpSeleccion = string.Empty;
            guardadoBase = false;
            IsEditable = false;
            IsSelected = false;
            referenciaPt = string.Empty;
            descripciondpSeleccion = string.Empty;
            isuso = 0;
            idrepositorio = null;
            idcedulas = null;
            idgenerico = null;
            tabla = null;
            iddcedulas = null;
        }

        public static DetalleCuestionarioModelo equivalencia(DetalleCuestionarioModelo comun, DetalleHerramientasModelo origen)
        {
            DetalleCuestionarioModelo destino = new DetalleCuestionarioModelo();
            destino.iddp = 0;
            destino.idtprocedimientodp = origen.idtProcedimiento;
            destino.idprogramadp = comun.idprogramadp;//Programa del que depende

            destino.descripciondp = origen.descripcionDh;
            destino.fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.ordendp = (decimal)origen.ordenDh;
            //idtrcdc = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.estadoprocedimientodp = "I";
            destino.comentariodp = "";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.idvisitadp = origen.idVisitaDh;
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            destino.idpapelesdp = origen.idDh;
            destino.idpadredp = origen.idDhPrincipalDh;//Pendiente para actualizacion se guarda el id

            destino.ordenDhPresentacion = MetodosModelo.ordenConversion(decimal.Parse(origen.ordenDhPresentacion));
            destino.guardadoBase = false;
            destino.IsEditable = false;
            destino.usuarioModeloDp = comun.usuarioModeloDp;
            destino.usuarioModificoDp = comun.usuarioModificoDp;
            destino.usuarioProgramaAccionModeloDp = comun.usuarioProgramaAccionModeloDp;
            return destino;
        }

        public DetalleCuestionarioModelo(DetalleCuestionarioModelo comun, DetalleHerramientasModelo origen)
        {
            iddp = 0;
            idtprocedimientodp = origen.idtProcedimiento;
            idprogramadp = comun.idprogramadp;//Programa del que depende

            descripciondp = origen.descripcionDh;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)origen.ordenDh;
            //idtrcdc = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoprocedimientodp = "I";
            comentariodp = string.Empty; ;
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            idvisitadp = origen.idVisitaDh;
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            idpapelesdp = origen.idDh;
            idpadredp = origen.idDhPrincipalDh;//Pendiente para actualizacion se guarda el id
            estadodc = origen.estadoDh;
            ordenDhPresentacion = MetodosModelo.ordenConversion(decimal.Parse(origen.ordenDhPresentacion));
            guardadoBase = false;
            IsEditable = false;
            usuarioModeloDp = comun.usuarioModeloDp;
            usuarioModificoDp = comun.usuarioModificoDp;
            usuarioProgramaAccionModeloDp = comun.usuarioProgramaAccionModeloDp;
            descripciondpSeleccion = string.Empty;
        }

        public static detallecuestionario DetalleCuestionarioConversion(DetalleCuestionarioModelo comun, detalleherramienta origen)
        {
            var tablaDestino = new detallecuestionario
            {
                iddc = 0,
                idtprocedimientodc = origen.idtprocedimiento,
                idprogramadc = comun.idprogramadp,
                //idpapelesdc = origen.idpapelesdp,
                descripciondc = origen.descripciondh,
                fechacreadodc = MetodosModelo.homologacionFecha(),
                ordendc = (decimal)origen.ordendh,
                //idtrcdc = origen.idtrcdc,
                estadoprocedimientodc = "I",
                //fechasupervision = origen.fechasupervision,
                idvisitadc = origen.idvisitadh,
                //Se utiliza comentario para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia
                comentariodc = string.Empty,
                //comentariodc = origen.iddh.ToString(),
                //No se traslada la referenciacion por necesitarse crear primero
                //idpadredc = origen.iddh,
                estadodc = origen.estadodh,

            };

            //idpadredc = modelo.idpadredp,

            //if (origen.iddhprincipaldh != null || origen.iddhprincipaldh != 0)
            //{
            //    //Se utiliza comentario para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia
            //    tablaDestino.comentariodc = origen.iddh.ToString();
            //}
            return tablaDestino;
        }

        public DetalleCuestionarioModelo(DetalleCuestionarioModelo comun, DetalleCuestionarioModelo origen)
        {
            iddp = 0;
            idtprocedimientodp = origen.idtprocedimientodp;
            idprogramadp = comun.idprogramadp;//Programa del que depende

            descripciondp = origen.descripciondp;
            fechacreadodp = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordendp = (decimal)origen.ordendp;
            //idtrcdc = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //fechafindp = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            estadoprocedimientodp = "I";
            comentariodp = string.Empty;
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            idvisitadp = origen.idvisitadp;
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            idpapelesdp = origen.iddp;

            idpadredp = origen.idpadredp;//Pendiente para actualizacion se guarda el id
            estadodc = origen.estadodc;
            ordenDhPresentacion = origen.ordenDhPresentacion;
            guardadoBase = false;
            IsEditable = false;
            usuarioModeloDp = comun.usuarioModeloDp;
            usuarioModificoDp = comun.usuarioModificoDp;
            usuarioProgramaAccionModeloDp = comun.usuarioProgramaAccionModeloDp;
            IsSelected = false;
            referenciaPt = "";
        }

        #endregion
    }


}
