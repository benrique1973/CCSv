using CapaDatos;
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
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace SGPTWpf.Model.Modelo.detalleherramientas
{

    public class DetalleHerramientasModelo : UIBase
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
        //[DisplayName("Código")]
        //public int idDh
        //{
        //    get { return GetValue(() => idDh); }
        //    set { SetValue(() => idDh, value); }
        //}
        #region idDh

        public int _idDh;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idDh
        {
            get { return _idDh; }
            set { _idDh = value; }
        }

        #endregion
        public int? idUsuario
        {
            get { return GetValue(() => idUsuario); }
            set { SetValue(() => idUsuario, value); }
        }
        public Nullable<int> idtProcedimiento
        {
            get { return GetValue(() => idtProcedimiento); }
            set { SetValue(() => idtProcedimiento, value); }
        }

        public int idHerramienta
        {
            get { return GetValue(() => idHerramienta); }
            set { SetValue(() => idHerramienta, value); }
        }
        [DisplayName("Descripción de procedimiento")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(500, ErrorMessage = "Excede de 500 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripcionDh
        {
            get { return GetValue(() => descripcionDh); }
            set { SetValue(() => descripcionDh, value); }
        }

        public string descripcionDhSeleccion
        {
            get { return GetValue(() => descripcionDhSeleccion); }
            set { SetValue(() => descripcionDhSeleccion, value); }
        }

        public byte[] descripcionByteaDh
        {
            get { return GetValue(() => descripcionByteaDh); }
            set { SetValue(() => descripcionByteaDh, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechaCreadoDh
        {
            get { return GetValue(() => fechaCreadoDh); }
            set { SetValue(() => fechaCreadoDh, value); }
        }

        public string estadoDh
        {
            get { return GetValue(() => estadoDh); }
            set { SetValue(() => estadoDh, value); }
        }

        public bool sistemaDh
        {
            get { return GetValue(() => sistemaDh); }
            set { SetValue(() => sistemaDh, value); }
        }


        [DisplayName("Orden de presentación")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(1, 100, ErrorMessage = "El maximo es de 100 y mínimo de 1")]
        public Nullable<decimal> ordenDh
        {
            get { return GetValue(() => ordenDh); }
            set { SetValue(() => ordenDh, value); }
        }
        public string ordenDhPresentacion
        {
            get { return GetValue(() => ordenDhPresentacion); }
            set { SetValue(() => ordenDhPresentacion, value); }
        }
        public string descripcionPadre
        {
            get { return GetValue(() => descripcionPadre); }
            set { SetValue(() => descripcionPadre, value); }
        }
        public Nullable<decimal> ordenDhPadre
        {
            get { return GetValue(() => ordenDhPadre); }
            set { SetValue(() => ordenDhPadre, value); }
        }
        [DisplayName("Horas planificadas")]
        [Range(0, 100, ErrorMessage = "Las horas deben ser mayores de cero")]
        public Nullable<decimal> horasPlanDh
        {
            get { return GetValue(() => horasPlanDh); }
            set { SetValue(() => horasPlanDh, value); }
        }

        public int? idVisitaDh
        {
            get { return GetValue(() => idVisitaDh); }
            set { SetValue(() => idVisitaDh, value); }
        }
        //Almacena el procedimiento padre, si no hubiera queda vacio
        public int? idDhPrincipalDh
        {
            get { return GetValue(() => idDhPrincipalDh); }
            set { SetValue(() => idDhPrincipalDh, value); }
        }

    //Entidades relacionadas
        /*public VisitaModelo Visita { get; set; }
        public TipoProcedimientoModelo TipoProcedimiento { get; set; }
        public virtual DetalleHerramientasModelo detalleHerramientasModelo { get; set; }
        public virtual UsuarioModelo UsuarioModelo { get; set; }*/
        //Propiedades de  nombres para presentacion

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

        #endregion

        #region colecciones virtuales

        public virtual DetalleHerramientasModelo detalleHerramientasModeloPadre
        {
            get { return GetValue(() => detalleHerramientasModeloPadre); }
            set { SetValue(() => detalleHerramientasModeloPadre, value); }
        }
        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion

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
        //Almacena los datos de los procedimientos
        //public virtual ObservableCollection<DetalleHerramientasModelo> listaEntidadSeleccion
        //{
        //    get { return GetValue(() => listaEntidadSeleccion); }
        //    set { SetValue(() => listaEntidadSeleccion, value); }
        //}
        #endregion

        #region listaEntidadSeleccion

        public ObservableCollection<DetalleHerramientasModelo> _listaEntidadSeleccion;
        public ObservableCollection<DetalleHerramientasModelo> listaEntidadSeleccion
        {
            get { return _listaEntidadSeleccion; }
            set { _listaEntidadSeleccion = value; }
        }

        #endregion


        #region Public Model Methods

        #region Propiedades de la vista
        //Seteando un valor por defecto
        private bool _activarCaptura=true;
        public bool activarCaptura {
                                    get { return this._activarCaptura; }
                                    set { this._activarCaptura = value; }
                                    }
        #endregion

        public static bool Insert(DetalleHerramientasModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleherramientas', 'iddh'), (SELECT MAX(iddh) FROM sgpt.detalleherramientas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detalleherramienta
                        {
                            //
                            //idDh = modelo.idDh,
                            idtprocedimiento = modelo.idtProcedimiento,
                            idusuariodh=modelo.idUsuario,
                            idherramienta = modelo.idHerramienta,
                            descripciondh = modelo.descripcionDh,
                            descripcionbyteadh=modelo.descripcionByteaDh,
                            fechacreadodh = DateTime.Now.ToString("d"),
                            horasplandh=modelo.horasPlanDh,
                            idvisitadh=modelo.idVisitaDh,
                            iddhprincipaldh=modelo.idDhPrincipalDh,
                            ordendh = modelo.ordenDh,
                            sistemadh = false,
                            estadodh = "A",
                        };
                        if (tablaDestino.idtprocedimiento == 0)
                        {
                            tablaDestino.idtprocedimiento = null;
                        }
                        _context.detalleherramientas.Add(tablaDestino);
                        _context.SaveChanges();
                        if (!(modelo.idDhPrincipalDh == null))
                        {
                            modelo.nombreDetallePadre = DetalleHerramientasModelo.FindNombreById(modelo.idDhPrincipalDh);
                            modelo.ordenDhPadre = DetalleHerramientasModelo.FindOrdenPadreById(modelo.idDhPrincipalDh);
                            modelo.ordenDhPresentacion= ordenConversion(modelo.ordenDh);
                        }
                        modelo.guardadoBase = true;
                        modelo.idDh = tablaDestino.iddh;
                        modelo.sistemaDh = tablaDestino.sistemadh;
                        modelo.estadoDh = tablaDestino.estadodh;
                        if (!(modelo.idtProcedimiento == null))
                        {
                            modelo.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(modelo.idtProcedimiento);
                        }
                        if (!(modelo.idVisitaDh == null))
                        {
                            modelo.nombreVisita = VisitaModelo.FindNombreById(modelo.idVisitaDh);
                        }
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


        public static string Insert(DetalleHerramientasModelo modelo)
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
                        var tablaDestino = new detalleherramienta
                        {
                            //
                            //idDh = modelo.idDh,
                            idtprocedimiento = modelo.idtProcedimiento,
                            idusuariodh=modelo.idUsuario,
                            idherramienta = modelo.idHerramienta,
                            descripcionbyteadh=modelo.descripcionByteaDh,
                            descripciondh = modelo.descripcionDh,
                            fechacreadodh = DateTime.Now.ToString("d"),
                            horasplandh = modelo.horasPlanDh,
                            iddhprincipaldh = modelo.idDhPrincipalDh,
                            idvisitadh = modelo.idVisitaDh,
                            ordendh = modelo.ordenDh,
                            sistemadh = false,
                            estadodh = "A",
                        };
                        _context.detalleherramientas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.idDh = tablaDestino.iddh;
                        modelo.sistemaDh = tablaDestino.sistemadh;
                        modelo.estadoDh = tablaDestino.estadodh;
                        if (!(modelo.idDhPrincipalDh == null))
                        {
                            modelo.nombreDetallePadre = DetalleHerramientasModelo.FindNombreById(modelo.idDhPrincipalDh);
                            modelo.ordenDhPadre = DetalleHerramientasModelo.FindOrdenPadreById(modelo.idDhPrincipalDh);
                            modelo.ordenDhPresentacion = ordenConversion(modelo.ordenDh);
                        }
                        if (!(modelo.idtProcedimiento == null))
                        {
                            modelo.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(modelo.idtProcedimiento);
                        }
                        if (!(modelo.idVisitaDh == null))
                        {
                            modelo.nombreVisita = VisitaModelo.FindNombreById(modelo.idVisitaDh);
                        }
                        result = tablaDestino.iddh.ToString();
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
        public static DetalleHerramientasModelo Find(int id)
        {
            var entidadModelo = new DetalleHerramientasModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                   detalleherramienta entidad = _context.detalleherramientas.Find(id);
                    if (entidad == null)
                    {
                        entidadModelo = null;
                    }
                    else
                    {
                        //idDh = modelo.idDh,
                        entidadModelo.idDh = entidad.iddh;
                        entidadModelo.idUsuario = entidad.idusuariodh;
                        entidadModelo.idtProcedimiento = entidad.idtprocedimiento;
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.descripcionDh = entidad.descripciondh;
                        entidadModelo.descripcionByteaDh = entidad.descripcionbyteadh;
                        entidadModelo.fechaCreadoDh = entidad.fechacreadodh;//Generara error conversion de fechas
                        entidadModelo.ordenDh = entidad.ordendh;
                        entidadModelo.ordenDhPresentacion = ordenConversion(entidad.ordendh);
                        entidadModelo.idVisitaDh = entidad.idvisitadh;
                        entidadModelo.horasPlanDh = entidad.horasplandh;
                        entidadModelo.idDhPrincipalDh = entidad.iddhprincipaldh;
                        entidadModelo.sistemaDh = entidad.sistemadh;
                        entidadModelo.guardadoBase = true;
                        entidadModelo.estadoDh = entidad.estadodh;
                        if (!(entidadModelo.idDhPrincipalDh == null))
                        {
                            entidadModelo.nombreDetallePadre = DetalleHerramientasModelo.FindNombreById(entidadModelo.idDhPrincipalDh);
                            entidadModelo.ordenDhPadre = DetalleHerramientasModelo.FindOrdenPadreById(entidadModelo.idDhPrincipalDh);
                            entidadModelo.ordenDhPresentacion = ordenConversion(entidadModelo.ordenDh);
                        }
                        if (!(entidadModelo.idtProcedimiento == null))
                        {
                            entidadModelo.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(entidadModelo.idtProcedimiento);
                        }
                        if (!(entidadModelo.idVisitaDh == null))
                        {
                            entidadModelo.nombreVisita = VisitaModelo.FindNombreById(entidadModelo.idVisitaDh);
                        }
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

        //Devuelve el maximo del orden de un registro
        public static Nullable<decimal> FindOrden(int idHerramienta)
        {
            Nullable<decimal> ordenMaximo  = 0;
            if (!(idHerramienta == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    ordenMaximo = _context.detalleherramientas.Where(x=>x.idherramienta == idHerramienta).Max(p => p.ordendh);
                    return ordenMaximo+1;
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
                    string commandString = String.Format("DELETE FROM sgpt.detalleherramientas WHERE iddh={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static DetalleHerramientasModelo Find(string id)
        {
            var entidadModelo = new DetalleHerramientasModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    detalleherramienta entidad = _context.detalleherramientas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idDh = entidad.iddh;
                        entidadModelo.idUsuario = entidadModelo.idUsuario;
                        entidadModelo.idtProcedimiento = entidad.idtprocedimiento;
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.descripcionDh = entidad.descripciondh;
                        entidadModelo.descripcionByteaDh = entidad.descripcionbyteadh;
                        entidadModelo.fechaCreadoDh = entidad.fechacreadodh;//Generara error conversion de fechas
                        entidadModelo.ordenDh = entidad.ordendh;
                        entidadModelo.ordenDhPresentacion = ordenConversion(entidad.ordendh);
                        entidadModelo.idVisitaDh = entidad.idvisitadh;
                        entidadModelo.idDhPrincipalDh = entidad.iddhprincipaldh;
                        entidadModelo.horasPlanDh = entidad.horasplandh;
                        entidadModelo.sistemaDh = entidad.sistemadh;
                        entidadModelo.guardadoBase = true;
                        entidadModelo.estadoDh = entidad.estadodh;
                        entidadModelo.guardadoBase = true;
                            if (!(entidadModelo.idDhPrincipalDh == null))
                            {
                            entidadModelo.nombreDetallePadre = DetalleHerramientasModelo.FindNombreById(entidadModelo.idDhPrincipalDh);
                            entidadModelo.ordenDhPadre = DetalleHerramientasModelo.FindOrdenPadreById(entidadModelo.idDhPrincipalDh);
                            }
                            if (!(entidadModelo.idtProcedimiento == null))
                            {
                            entidadModelo.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(entidadModelo.idtProcedimiento);
                            }
                            if (!(entidadModelo.idVisitaDh == null))
                            {
                            entidadModelo.nombreVisita = VisitaModelo.FindNombreById(entidadModelo.idVisitaDh);
                        }
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
                    var modelo = new DetalleHerramientasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    detalleherramienta entidad = _context.detalleherramientas.Find(id);
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
                    var modelo = new DetalleHerramientasModelo();
                    detalleherramienta entidad = _context.detalleherramientas.Find(id);
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
                    var modelo = new DetalleHerramientasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detalleherramientas
                            .Where(b => b.estadodh == "B")
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
                    detalleherramienta entidad = _context.detalleherramientas.Find(id);
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
                    return nombre = _context.detalleherramientas.Find(id).descripciondh;
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
                    return nombre = _context.detalleherramientas.Find(id).ordendh;
                }
            }
            else
            {
                return nombre;
            }
        }
        //Para realizar busquedas de texto
        public static List<DetalleHerramientasModelo> TransformLista(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                var lista = _context.detalleherramientas.Select(entidad =>
                new DetalleHerramientasModelo
                {
                    idDh = entidad.iddh,
                    idUsuario=entidad.idusuariodh,
                    idtProcedimiento = entidad.idtprocedimiento,
                    idHerramienta = entidad.idherramienta,
                    descripcionDh = entidad.descripciondh,
                    descripcionByteaDh=entidad.descripcionbyteadh,
                    fechaCreadoDh = entidad.fechacreadodh,//Generara error conversion de fechas
                    sistemaDh = entidad.sistemadh,
                    idDhPrincipalDh = entidad.iddhprincipaldh,
                    idVisitaDh = entidad.idvisitadh,
                    horasPlanDh = entidad.horasplandh,
                    estadoDh = entidad.estadodh,
                    ordenDh = entidad.ordendh,
                    
                    guardadoBase =true
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idDh).Where(x => x.descripcionDh.ToUpper() == Texto).ToList();
                foreach (DetalleHerramientasModelo item in lista)
                {
                    item.guardadoBase = true;
                    item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                    if (!(item.idDhPrincipalDh == null))
                    {
                        item.nombreDetallePadre = DetalleHerramientasModelo.FindNombreById(item.idDhPrincipalDh);
                        item.ordenDhPadre = DetalleHerramientasModelo.FindOrdenPadreById(item.idDhPrincipalDh);
                    }
                    if (!(item.idtProcedimiento == null))
                    {
                        item.nombreTipoProcedimiento = TipoProcedimientoModelo.FindNombreById(item.idtProcedimiento);
                    }
                    if (!(item.idVisitaDh == null))
                    {
                        item.nombreVisita = VisitaModelo.FindNombreById(item.idVisitaDh);
                    }
                }
                return lista;

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
                    var entidad = _context.detalleherramientas
                            .Where(b => b.estadodh == "B")
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

        public static void UpdateModelo(DetalleHerramientasModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detalleherramienta entidad = _context.detalleherramientas.Find(modelo.idDh);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        //entidad.iddh = modelo.idDh;
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
                        //entidad.sistemadh = modelo.sistemaDh;
                        //entidad.estadodh = modelo.estadoDh;
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

        public static void UpdateModeloReodenar(DetalleHerramientasModelo modelo)
        {
            string commandString = string.Empty;
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {

                        commandString = String.Format("UPDATE sgpt.detalleherramientas SET ordendh = {0} WHERE iddh={1};", modelo.ordenDh, modelo.idDh);

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
                MessageBox.Show("exception en actualizar el orden: \n" + commandString + "\n"+e);
            }
        }



        public static bool UpdateModelo(DetalleHerramientasModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        bool aplicarOrden = false;
                        detalleherramienta entidad = _context.detalleherramientas.Find(modelo.idDh);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddh = modelo.idDh; no puede cambiar
                            if (!(entidad.idusuariodh == modelo.idUsuario))
                            { entidad.idusuariodh = modelo.idUsuario;
                                cambio = true;
                            }
                            if (!(entidad.idtprocedimiento == modelo.idtProcedimiento))
                            {
                                cambio = true;
                                //aplicar el orden\
                                aplicarOrden = true;
                            }
                            //entidad.idherramienta = modelo.idHerramienta; No puede cambiar
                            if (!(entidad.descripciondh.ToUpper() == modelo.descripcionDh.ToUpper()))
                            {
                                cambio = true;
                            }
                            if (!(entidad.descripcionbyteadh == modelo.descripcionByteaDh))
                            {
                                cambio = true;
                            }
                            if (!(entidad.fechacreadodh == modelo.fechaCreadoDh.ToString()))
                            {
                                cambio = true;
                            }
                            if (!(entidad.ordendh == modelo.ordenDh))
                            {
                                //entidad.ordendh = modelo.ordenDh;Basado en  el orden
                                cambio = true;
                            }
                            if (!(entidad.idvisitadh == modelo.idVisitaDh))
                            {
                                entidad.idvisitadh = modelo.idVisitaDh;
                                cambio = true;
                            }
                            if (!(entidad.horasplandh == modelo.horasPlanDh))
                            {
                                cambio = true;
                            }
                            if (!(entidad.iddhprincipaldh == modelo.idDhPrincipalDh))
                            {
                                cambio = true;
                                aplicarOrden = true;
                                //Cambiar el orden
                            }
                            //entidad.sistemadh = modelo.sistemaDh; //No puede cambiar se establece al crearlo
                            //entidad.estadodh = modelo.estadoDh; //No puede cambiar se cambia al crear o eliminar
                            if (cambio)
                            {
                                //entidad.iddh = modelo.idDh;
                                entidad.idusuariodh = modelo.idUsuario;
                                entidad.idtprocedimiento = modelo.idtProcedimiento;
                                entidad.idherramienta = modelo.idHerramienta;
                                entidad.descripciondh = modelo.descripcionDh;
                                entidad.descripcionbyteadh = modelo.descripcionByteaDh;
                                entidad.fechacreadodh = modelo.fechaCreadoDh.ToString();
                                entidad.idvisitadh = modelo.idVisitaDh;
                                entidad.iddhprincipaldh = modelo.idDhPrincipalDh;
                                if (aplicarOrden)
                                { 
                                entidad.ordendh = modelo.ordenDh;
                                }
                                entidad.horasplandh = modelo.horasPlanDh;
                                //entidad.sistemadh = modelo.sistemaDh;
                                //entidad.estadodh = modelo.estadoDh;
                                _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                            }
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    //captura de fallo en la insercion
                    MessageBox.Show("exception en actualizar entidad detalle herramienta : " + e.Message);
                    throw;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            Trace.TraceInformation(
                //                  "Class: {0}, Property: {1}, Error: {2}",
                //                  validationErrors.Entry.Entity.GetType().FullName,
                //                  validationError.PropertyName,
                //                  validationError.ErrorMessage);
                //        }
                //    }
                //    return false;
                //}
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
                            string commandString = String.Format("UPDATE sgpt.detalleherramientas SET estadodh = 'B' WHERE iddh={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //detalleherramienta entidad = _context.detalleherramientas.Find(id);
                            //entidad.estadodh = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
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
                            string commandString = String.Format("UPDATE sgpt.detalleherramientas SET estadodh = 'B' WHERE iddh={0};", id);
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
                    string commandString = String.Format("DELETE FROM sgpt.detalleherramientas WHERE iddh={0};", id);
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
                        detalleherramienta entidad = _context.detalleherramientas.Find(id);
                        if (entidad.sistemadh)
                        {
                            entidad.estadodh = "B";
                        }
                        else
                        {
                            _context.detalleherramientas.Remove(entidad);
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
                            string commandString = String.Format("DELETE FROM sgpt.detalleherramientas WHERE iddh={0};", id);
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

        public static List<DetalleHerramientasModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista= _context.detalleherramientas.Select(entidad =>
                    new DetalleHerramientasModelo
                    {
                        idDh = entidad.iddh,
                        idUsuario=entidad.idusuariodh,
                        idtProcedimiento = entidad.idtprocedimiento,
                        idHerramienta = entidad.idherramienta,
                        descripcionDh = entidad.descripciondh,
                        descripcionByteaDh=entidad.descripcionbyteadh,
                        fechaCreadoDh = entidad.fechacreadodh,//Generara error conversion de fechas
                        ordenDh = entidad.ordendh,
                        
                        idDhPrincipalDh = entidad.iddhprincipaldh,
                        idVisitaDh = entidad.idvisitadh,
                        horasPlanDh = entidad.horasplandh,
                        sistemaDh = entidad.sistemadh,
                        estadoDh = entidad.estadodh,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count>0)
                    {
                        int cuenta = 1;
                    foreach (DetalleHerramientasModelo item in lista)
                    {
                        item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                        item.idCorrelativo = cuenta;
                        cuenta++;
                            item.guardadoBase = false;
                    }
                    }
                    return RegeneraOrdenSubRegistros(lista);
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


        public static List<DetalleHerramientasModelo> GetAll(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detalleherramientas.Select(entidad =>
                    new DetalleHerramientasModelo
                    {
                        idDh = entidad.iddh,
                        idUsuario = entidad.idusuariodh,
                        idtProcedimiento = entidad.idtprocedimiento,
                        idHerramienta = entidad.idherramienta,
                        descripcionDh = entidad.descripciondh,
                        descripcionByteaDh = entidad.descripcionbyteadh,
                        fechaCreadoDh = entidad.fechacreadodh,//Generara error conversion de fechas
                        horasPlanDh = entidad.horasplandh,
                        idDhPrincipalDh = entidad.iddhprincipaldh,
                        ordenDh = entidad.ordendh,
                        
                        idVisitaDh = entidad.idvisitadh,
                        sistemaDh = entidad.sistemadh,
                        estadoDh = entidad.estadodh,
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
                        },
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
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A" && x.idHerramienta == idHerramienta).ToList();
                
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleHerramientasModelo>();
                    }
                    else
                    {
                        int cuenta = 1;
                        DetalleHerramientasModelo temporal;
                        foreach (DetalleHerramientasModelo item in lista)
                        {
                            item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                            item.guardadoBase = true;
                            item.idCorrelativo = cuenta;
                            cuenta++;
                            if (item.idDhPrincipalDh != null)
                            {
                                //temporal = DetalleHerramientasModelo.Find((int)item.idDhPrincipalDh);
                                temporal = lista.SingleOrDefault(x => x.idDh==item.idDhPrincipalDh);
                                if (temporal != null)
                                {
                                    item.nombreDetallePadre = temporal.descripcionDh;
                                    item.ordenDhPadre = temporal.ordenDh;
                                    item.detalleHerramientasModeloPadre = temporal;
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
                MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas \n" + e );
                DetalleHerramientasModelo registroAdicional = new DetalleHerramientasModelo();
                registroAdicional.idDh = 0;
                registroAdicional.descripcionDh = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                registroAdicional.nombreTipoProcedimiento = "Ninguno";
                var lista = new ObservableCollection<DetalleHerramientasModelo>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<detalleherramienta> GetAllCapaDatos(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.detalleherramientas WHERE idherramienta={0} AND estadodh = 'A' ORDER BY ordendh;", idHerramienta);

                    var lista = _context.detalleherramientas.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<detalleherramienta> temporal = new ObservableCollection<detalleherramienta>(lista);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                detalleherramienta registroAdicional = new detalleherramienta();
                registroAdicional.iddh = 0;
                registroAdicional.descripciondh = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                registroAdicional.descripciondh = "Ninguno";
                var lista = new ObservableCollection<detalleherramienta>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<DetalleHerramientasModelo> GetAllVista(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detalleherramientas.Select(entidad =>
                    new DetalleHerramientasModelo
                    {
                        idDh = entidad.iddh,
                        idUsuario = entidad.idusuariodh,
                        idtProcedimiento = entidad.idtprocedimiento,
                        idHerramienta = entidad.idherramienta,
                        descripcionDh = entidad.descripciondh,
                        fechaCreadoDh = entidad.fechacreadodh,//Generara error conversion de fechas
                        horasPlanDh = entidad.horasplandh,
                        idDhPrincipalDh = entidad.iddhprincipaldh,
                        ordenDh = entidad.ordendh,

                        idVisitaDh = entidad.idvisitadh,
                        sistemaDh = entidad.sistemadh,
                        estadoDh = entidad.estadodh,
                        nombreDetallePadre = "",
                        nombreTipoProcedimiento = entidad.tipoprocedimiento.descripciontprocedimiento,
                        nombreVisita = entidad.visita.descripcionvisita,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A" && x.idHerramienta == idHerramienta).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new List<DetalleHerramientasModelo>();
                    }
                    else
                    {
                        int cuenta = 1;
                        DetalleHerramientasModelo temporal;
                        foreach (DetalleHerramientasModelo item in lista)
                        {
                            item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                            item.guardadoBase = true;
                            item.idCorrelativo = cuenta;
                            cuenta++;
                            if (!(item.idDhPrincipalDh == null))
                            {
                                temporal = DetalleHerramientasModelo.Find((int)item.idDhPrincipalDh);
                                item.nombreDetallePadre = temporal.descripcionDh;
                                item.ordenDhPadre = temporal.ordenDh;
                                item.detalleHerramientasModeloPadre = temporal;
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
                {
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                }
                    var lista = new ObservableCollection<DetalleHerramientasModelo>();
                    return lista.ToList();
            }
        }

        public static Nullable<Decimal> SumaHora(int? idHerramienta)
        {
            Nullable<decimal> ordenMaximo = 0;
            if (!(idHerramienta == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    ordenMaximo = _context.detalleherramientas.Where(x=>x.idherramienta==idHerramienta).Sum(p => p.horasplandh);
                    return ordenMaximo;
                }
            }
            else
            {
                return ordenMaximo;
            }
        }

        public static List<DetalleHerramientasModelo> GetAll(int? idHerramienta, int? idDhSeleccionado)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.detalleherramientas.Select(entidad =>
                    new DetalleHerramientasModelo
                    {
                        idDh = entidad.iddh,
                        idUsuario = entidad.idusuariodh,
                        idtProcedimiento = entidad.idtprocedimiento,
                        idHerramienta = entidad.idherramienta,
                        descripcionDh = entidad.descripciondh,
                        descripcionByteaDh = entidad.descripcionbyteadh,
                        fechaCreadoDh = entidad.fechacreadodh,//Generara error conversion de fechas
                        horasPlanDh = entidad.horasplandh,
                        idDhPrincipalDh = entidad.iddhprincipaldh,
                        ordenDh = entidad.ordendh,
                        
                        idVisitaDh = entidad.idvisitadh,
                        sistemaDh = entidad.sistemadh,
                        estadoDh = entidad.estadodh,
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
                        },
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
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A" && x.idHerramienta == idHerramienta && x.idDh== idDhSeleccionado).ToList();
                    DetalleHerramientasModelo temporal;
                    int cuenta = 1;
                    foreach (DetalleHerramientasModelo item in lista)
                    {
                        item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                        item.guardadoBase = true;
                        item.idCorrelativo = cuenta;
                        cuenta++;
                        if (!(item.idDhPrincipalDh == null))
                        {
                            temporal = DetalleHerramientasModelo.Find((int)item.idDhPrincipalDh);
                            item.nombreDetallePadre = temporal.descripcionDh;
                            item.ordenDhPadre = temporal.ordenDh;
                            item.detalleHerramientasModeloPadre = temporal;
                        }
                        if (!(item.idtProcedimiento == null))
                        {
                            //item.tipoProcedimientoModelo = TipoProcedimientoModelo.Find((int)item.idtProcedimiento);
                            item.nombreTipoProcedimiento = item.tipoProcedimientoModelo.descripcion;
                        }
                        if (!(item.idVisitaDh == null))
                        {
                            item.nombreVisita = item.visitaModelo.descripcion;
                        }
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

        public static List<DetalleHerramientasModelo> GetAll(int? idHerramienta, int? idDhSeleccionado,bool seleccion)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.detalleherramientas.Select(entidad =>
                    new DetalleHerramientasModelo
                    {
                        idDh = entidad.iddh,
                        idUsuario = entidad.idusuariodh,
                        idtProcedimiento = entidad.idtprocedimiento,
                        idHerramienta = entidad.idherramienta,
                        descripcionDh = entidad.descripciondh,
                        descripcionByteaDh = entidad.descripcionbyteadh,
                        fechaCreadoDh = entidad.fechacreadodh,//Generara error conversion de fechas
                        horasPlanDh = entidad.horasplandh,
                        idDhPrincipalDh = entidad.iddhprincipaldh,
                        ordenDh = entidad.ordendh,
                        
                        idVisitaDh = entidad.idvisitadh,
                        sistemaDh = entidad.sistemadh,
                        estadoDh = entidad.estadodh,
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
                        },
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
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A" && x.idHerramienta == idHerramienta && x.idDh != idDhSeleccionado).ToList();
                //}).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A" && x.idHerramienta == idHerramienta && x.idDh == idDhSeleccionado && x.idDh != idDhSeleccionado).ToList();

                DetalleHerramientasModelo temporal;
                    int cuenta = 2;
                    foreach (DetalleHerramientasModelo item in lista)
                    {
                        item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                        item.descripcionDh= item.ordenDh + "-" + item.descripcionDh;
                        item.guardadoBase = true;
                        item.idCorrelativo = cuenta;
                        cuenta++;
                        if (!(item.idDhPrincipalDh == null))
                        {
                            temporal = DetalleHerramientasModelo.Find((int)item.idDhPrincipalDh);
                            item.nombreDetallePadre = temporal.descripcionDh;
                            item.ordenDhPadre = temporal.ordenDh;
                            item.detalleHerramientasModeloPadre = temporal;
                        }
                        //if (!(item.idtProcedimiento == null))
                        //{
                        //    //item.tipoProcedimientoModelo = TipoProcedimientoModelo.Find((int)item.idtProcedimiento);
                        //    item.nombreTipoProcedimiento = item.tipoProcedimientoModelo.descripcion;
                        //}
                        //if (!(item.idVisitaDh == null))
                        //{
                        //    item.nombreVisita = item.visitaModelo.descripcion;
                        //}
                    }
                    DetalleHerramientasModelo registroAdicional = new DetalleHerramientasModelo();
                    registroAdicional.idDh = 0;
                    registroAdicional.descripcionDh = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                    registroAdicional.nombreTipoProcedimiento = "Ninguno";
                    registroAdicional.tipoProcedimientoModelo = new TipoProcedimientoModelo();
                    lista.Insert(0, registroAdicional);
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



        public static List<DetalleHerramientasModelo> GetAllEncabezados(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista=_context.detalleherramientas.Select(entidad =>
                        new DetalleHerramientasModelo
                        {
                            idDh = entidad.iddh,
                            idUsuario=entidad.idusuariodh,
                            idtProcedimiento = entidad.idtprocedimiento,
                            idHerramienta = entidad.idherramienta,
                            descripcionDh = entidad.descripciondh,
                            descripcionByteaDh=entidad.descripcionbyteadh,
                            horasPlanDh = entidad.horasplandh,
                            idVisitaDh=entidad.idvisitadh,
                            idDhPrincipalDh = entidad.iddhprincipaldh,
                            ordenDh = entidad.ordendh,
                            estadoDh = entidad.estadodh,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A").Where(x => x.idHerramienta == idHerramienta).ToList();
                    int cuenta = 1;
                    foreach (DetalleHerramientasModelo item in lista)
                    {
                        item.guardadoBase = true;
                        item.ordenDhPresentacion = ordenConversion(item.ordenDh);
                        item.idCorrelativo = cuenta;
                        cuenta++;
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



        public static List<DetalleHerramientasModelo> GetAllEncabezados()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista= _context.detalleherramientas.Select(entidad =>
                        new DetalleHerramientasModelo
                        {
                            idDh = entidad.iddh,
                            idUsuario=entidad.idusuariodh,
                            idtProcedimiento = entidad.idtprocedimiento,
                            idHerramienta = entidad.idherramienta,
                            descripcionDh = entidad.descripciondh,
                            descripcionByteaDh=entidad.descripcionbyteadh,
                            ordenDh = entidad.ordendh,
                            idDhPrincipalDh = entidad.iddhprincipaldh,
                            idVisitaDh =entidad.idvisitadh,
                            horasPlanDh=entidad.horasplandh,
                            estadoDh = entidad.estadodh,
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.ordenDh).Where(x => x.estadoDh == "A").ToList();
                    int cuenta = 1;
                    foreach (DetalleHerramientasModelo item in lista)
                    {
                        item.guardadoBase = true;
                        item.ordenDhPresentacion = ordenConversion((item.ordenDh));
                        item.idCorrelativo = cuenta;
                        cuenta++;
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
                    elementos = _context.detalleherramientas.Where(x => x.idherramienta == id && x.estadodh == "A").Count();
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
                    elementos = _context.detalleherramientas.Where(x => x.iddhprincipaldh == id && x.estadodh == "A").Count();
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
                    elementos = _context.detalleherramientas.Where(x => x.estadodh == "A").Count();
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
                    var entidad = (from p in _context.detalleherramientas
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
        public static DetalleHerramientasModelo Clear(DetalleHerramientasModelo modelo)
        {
            return new DetalleHerramientasModelo();
        }
        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleherramientas.Where(x => x.descripciondh.ToUpper() == busqueda && x.estadodh == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int FindTextoReturnId(string texto, int? idDh)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleherramientas.Where(x => x.descripciondh.ToUpper() == busqueda && x.estadodh == "A" && x.iddh==idDh).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public DetalleHerramientasModelo()
        {
            
                        idDh = 0;
                        idUsuario = 0;
                        idtProcedimiento = 0;
                        idHerramienta = 0;
                        descripcionDh =string.Empty;
                        //descripcionByteaDh ;
                        fechaCreadoDh = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
                        horasPlanDh = 0;
                        //idDhPrincipalDh =0;
                        ordenDh = 1;
                        ordenDhPresentacion = "1";
                        //idVisitaDh = 0;
                        sistemaDh = false;
                        estadoDh = "A";
                        guardadoBase = false;
                        listaEntidadSeleccion = new ObservableCollection<DetalleHerramientasModelo>();
                        descripcionDhSeleccion = string.Empty;

        }
        public DetalleHerramientasModelo(int idHerramienta, UsuarioModelo usuario)
        {

            idDh = 0;
            idUsuario = usuario.idUsuario;
            idtProcedimiento = 0;
            this.idHerramienta = idHerramienta;
            descripcionDh = string.Empty;
            //descripcionByteaDh ;
            fechaCreadoDh = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            horasPlanDh = 0;
            //idDhPrincipalDh =0;
            ordenDh = 1;
            ordenDhPresentacion = "1";
            //idVisitaDh = 0;
            sistemaDh = false;
            estadoDh = "A";
            guardadoBase = false;
            idDhPrincipalDh = null;
            listaEntidadSeleccion = new ObservableCollection<DetalleHerramientasModelo>();
            descripcionDhSeleccion = string.Empty;
        }

        #region gestion del orden de presentacion

        public static string ordenConversion(string orden)
        {
            if (string.IsNullOrEmpty(orden))
            {
                return orden;
            }
            else
            {
                if (orden.IndexOf(".") == -1)
                {
                    return orden;
                }
                else
                {
                    string temporal=orden;
                    for (int i =orden.Length;i> orden.IndexOf("."); i--)
                    {
                        if (orden.Substring(i-1, 1) == "0")
                        {
                         //Continua
                        }
                        else
                        {
                            temporal = orden.Substring(0, i);
                            i = -1;
                        }
                    }
                    return temporal;
                }
            }
        }

        public static string ordenConversion(int ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }
        public static string ordenConversion(decimal ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }
        public static string ordenConversion(double ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }
        public static string ordenConversion(decimal? ordenNumero)
        {
            return ordenConversion(ordenNumero.ToString());
        }

        #endregion

        #region generacion del orden

       /* public static List<DetalleHerramientasModelo> RegeneraOrdenSubRegistros2(List<DetalleHerramientasModelo> listaDetalleHerramienta)
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
                    ObservableCollection<DetalleHerramientasModelo> listaHijos = new ObservableCollection<DetalleHerramientasModelo>();
                    int ubicacion = 0;
                    foreach (DetalleHerramientasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.idDhPrincipalDh == null)
                        {
                            if (itemDetalle.ordenDh != contador)
                            {
                                guardar = true;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordenDh = contador;
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenDh);
                            contador++;
                            if (guardar)
                            {
                                DetalleHerramientasModelo.UpdateModelo(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                        }
                        //Se verifica que segun el tipo de procedimiento deba tener hijos o  no
                        else
                        {
                            if (!MetodosModelo.correccionOrden(itemDetalle.nombreTipoProcedimiento))
                            {
                                itemDetalle.idDhPrincipalDh = null;
                                itemDetalle.ordenDhPadre = null;
                                if (itemDetalle.ordenDh != contador)
                                {
                                    guardar = true;
                                }

                                //Se asigna el orden a los principales
                                itemDetalle.ordenDh = contador;
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenDh);
                                contador++;
                                if (guardar)
                                {
                                    DetalleHerramientasModelo.UpdateModeloReodenar(itemDetalle);
                                    //Se modifica el orden para mantener una estandarizacion
                                }
                            }
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    foreach (DetalleHerramientasModelo item in listaDetalleHerramienta)
                    {
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<DetalleHerramientasModelo>(listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == item.idDh));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)item.ordenDh;
                            factor = MetodosModelo.factorPadre(item.nombreTipoProcedimiento);
                            int j = 1;
                            guardar = false;
                            ubicacion = -1;
                            foreach (DetalleHerramientasModelo hijo in listaHijos)
                            {

                                //Es un hijo
                                ubicacion = listaDetalleHerramienta.IndexOf(hijo);
                                if (ubicacion != -1)
                                {
                                    if (listaDetalleHerramienta[ubicacion].ordenDh != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                    }
                                    listaDetalleHerramienta[ubicacion].ordenDhPadre = contador;
                                    listaDetalleHerramienta[ubicacion].ordenDh = Decimal.Add((decimal)contador, factor * j);
                                    listaDetalleHerramienta[ubicacion].ordenDhPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordenDh);
                                    j++;
                                    if (guardar)
                                    {
                                        DetalleHerramientasModelo.UpdateModeloReodenar(listaDetalleHerramienta[ubicacion]);
                                        //Se modifica el orden para mantener una estandarizacion
                                    }
                                }
                            }
                        }
                    }
                    return listaDetalleHerramienta.OrderBy(x => x.ordenDh).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    throw;
                }
            }
        }

    */
        public static List<DetalleHerramientasModelo> RegeneraOrdenSubRegistros(List<DetalleHerramientasModelo> listaDetalleHerramienta)
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
                    ObservableCollection<DetalleHerramientasModelo> listaHijos = new ObservableCollection<DetalleHerramientasModelo>();
                    ObservableCollection<DetalleHerramientasModelo> listaPadres = new ObservableCollection<DetalleHerramientasModelo>();
                    ObservableCollection<DetalleHerramientasModelo> listaDetalle = new ObservableCollection<DetalleHerramientasModelo>();

                    foreach (DetalleHerramientasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.idDhPrincipalDh == null)
                        {
                            if (itemDetalle.ordenDh != contador)
                            {
                                guardar = true;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordenDh = contador;
                            //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenDh);
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenDh);
                            itemDetalle.descripcionDhSeleccion = itemDetalle.descripcionDh;
                            if (guardar)
                            {
                                DetalleHerramientasModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                            listaDetalle.Add(itemDetalle);
                            if (listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == itemDetalle.idDh).Count() > 0)
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
                            listaHijos = new ObservableCollection<DetalleHerramientasModelo>(listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == listaPadres[0].idDh));
                            if (listaHijos.Count > 0)
                            {
                                //Hay hijos
                                contador = (decimal)listaPadres[0].ordenDh;
                                //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                                int j = 1;
                                guardar = false;
                                foreach (DetalleHerramientasModelo hijo in listaHijos)
                                {
                                    //Es un hijo
                                    if (hijo.ordenDh != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                    }
                                    hijo.ordenDhPadre = contador;
                                    factor = MetodosModelo.factorHijo(hijo.nombreTipoProcedimiento);
                                    hijo.ordenDh = Decimal.Add((decimal)contador, factor * j);
                                    hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordenDh);
                                    hijo.descripcionDhSeleccion = desplazar + hijo.descripcionDh;

                                    hijo.detalleHerramientasModeloPadre = listaPadres[0]; ;
                                    hijo.descripcionPadre = hijo.detalleHerramientasModeloPadre.descripcionDh;

                                    j++;
                                    if (guardar)
                                    {
                                        DetalleHerramientasModelo.UpdateModeloReodenar(hijo);
                                        //Se modifica el orden para mantener una estandarizacion
                                    }
                                    //Agregar a la lista
                                    listaDetalle.Add(hijo);
                                    //Verificar que no tenga hijos
                                    if (listaDetalleHerramienta.Where(x => x.idDhPrincipalDh == hijo.idDh).Count() > 0)
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
                    return listaDetalle.OrderBy(x => x.ordenDh).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta.OrderBy(x => x.ordenDh).ToList();
                    throw;
                }
            }
        }

        #endregion

        #endregion
    }

}
