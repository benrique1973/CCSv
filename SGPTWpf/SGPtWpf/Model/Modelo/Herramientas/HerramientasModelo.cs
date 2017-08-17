using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.Model.Modelo.detalleherramientas;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Collections.ObjectModel;

namespace SGPTWpf.Model.Modelo.Herramientas
{
    public class HerramientasModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativoHerramienta
        {
            get { return GetValue(() => idCorrelativoHerramienta); }
            set { SetValue(() => idCorrelativoHerramienta, value); }
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DisplayName("Código de herramienta")]
        //public int idHerramienta
        //{
        //    get { return GetValue(() => idHerramienta); }
        //    set { SetValue(() => idHerramienta, value); }
        //}
        #region idHerramienta
        public int _idHerramienta;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idHerramienta
        {
            get { return _idHerramienta; }
            set { _idHerramienta = value; }
        }

        #endregion
        public Nullable<int> idTp
        {
            get { return GetValue(() => idTp); }
            set { SetValue(() => idTp, value); }
        }

        public Nullable<int> idTh
        {
            get { return GetValue(() => idTh); }
            set { SetValue(() => idTh, value); }
        }

        //public string nombreHerramienta
        //{
        //    get { return GetValue(() => nombreHerramienta); }
        //    set { SetValue(() => nombreHerramienta, value); }
        //}
        #region nombreHerramienta
        public string _nombreHerramienta;
        [DisplayName("Nombre de herramienta")]
        [Required(ErrorMessage = "Descripción de herramienta requerida")]
        [MaxLength(200, ErrorMessage = "Excede de 200 caracteres permitidos")]
        [MinLength(5,ErrorMessage ="No es un título  descriptivo")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string nombreHerramienta
        {
            get { return GetValue(() => nombreHerramienta); }
            set { SetValue(() => nombreHerramienta, value); }
        }

        #endregion

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public DateTime fechacreadoherramienta
        {
            get { return GetValue(() => fechacreadoherramienta); }
            set { SetValue(() => fechacreadoherramienta, value); }
        }

        //public string fechacreadoherramientaString
        //{
        //    get { return GetValue(() => fechacreadoherramientaString); }
        //    set { SetValue(() => fechacreadoherramientaString, value); }
        //}
        public string _fechacreadoherramientaString;
        public string fechacreadoherramientaString
        {
            get { return _fechacreadoherramientaString; }
            set { _fechacreadoherramientaString = value; }
        }
        [DisplayName("Autorizó plantilla")]
        [MaxLength(30, ErrorMessage = "Excede de 30 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string autorizadoPorHerramienta
        {
            get { return GetValue(() => autorizadoPorHerramienta); }
            set { SetValue(() => autorizadoPorHerramienta, value); }
        }
        [DisplayName("Horas planeadas")]
        [Range(0, 1000, ErrorMessage = "Debe ser un valor mayor o igual a cero y menor que 1000")]
        public Nullable<decimal> horasPlanHerramienta
        {
            get { return GetValue(() => horasPlanHerramienta); }
            set { SetValue(() => horasPlanHerramienta, value); }
        }

        public string estadoHerramienta
        {
            get { return GetValue(() => estadoHerramienta); }
            set { SetValue(() => estadoHerramienta, value); }
        }

        public bool sistemaHerramienta
        {
            get { return GetValue(() => sistemaHerramienta); }
            set { SetValue(() => sistemaHerramienta, value); }
        }

        //Propiedades de presentacion
        public string idTpNombre
        {
            get { return GetValue(() => idTpNombre); }
            set { SetValue(() => idTpNombre, value); }
        }

        /*public virtual tiposprograma tiposPrograma
        {
            get { return GetValue(() => tiposPrograma); }
            set { SetValue(() => tiposPrograma, value); }
        }*/

        //public virtual TipoProgramaModelo tipoProgramaModelo
        //{
        //    get { return GetValue(() => tiposProgramaModelo); }
        //    set { SetValue(() => tiposProgramaModelo, value); }
        //}

        public TipoProgramaModelo _tiposProgramaModelo;
        public TipoProgramaModelo tiposProgramaModelo
        {
            get { return _tiposProgramaModelo; }
            set { _tiposProgramaModelo = value; }
        }
        /*public virtual tiposherramienta tiposHerramienta
        {
            get { return GetValue(() => tiposHerramienta); }
            set { SetValue(() => tiposHerramienta, value); }
        }*/
        //public virtual TipoHerramientaModelo tipoHerramientaModelo
        //{
        //    get { return GetValue(() => tipoHerramientaModelo); }
        //    set { SetValue(() => tipoHerramientaModelo, value); }
        //}


        #region tipoHerramientaModelo

        public TipoHerramientaModelo _tipoHerramientaModelo;
        public TipoHerramientaModelo tipoHerramientaModelo
        {
            get { return _tipoHerramientaModelo; }
            set { _tipoHerramientaModelo = value; }
        }

        #endregion
        public bool seleccionHerramienta
        {
            get { return GetValue(() => seleccionHerramienta); }
            set { SetValue(() => seleccionHerramienta, value); }
        }

        public ObservableCollection<HerramientasModelo> listadoHerramientaModelo
        {
            get { return GetValue(() => listadoHerramientaModelo); }
            set { SetValue(() => listadoHerramientaModelo, value); }
        }

        #endregion

        #region Public Model Methods

        #region Propiedades de la vista
        public string encabezadoHerramienta { get; set; }

        public string contenidoControlCarga { get; set; }

        private bool _activarCaptura = true;
        public bool activarCaptura
        {
            get { return this._activarCaptura; }
            set { this._activarCaptura = value; }
        }

        public Visibility visibilidadCrear { get; set; }


        public Visibility visibilidadTipoPrograma
        {
            get { return this.visibilidadTipoPrograma; }
            set { this.visibilidadTipoPrograma = value; }
        }

        public Visibility visibilidadEditar { get; set; }
        public Visibility visibilidadConsultar { get; set; }
        public string widthTipoPrograma { get; set; }
        /*public string heightConsultar { get; set; }
        public string heightEditar { get; set; }*/
        public string marcaAguaArchivo { get; set; }
        public bool activarCrear { get; set; }
        public bool activarConsultar { get; set; }
        public bool activarEditar { get; set; }

        #endregion
        public static bool Insert(HerramientasModelo modelo, UsuarioModelo usuarioValidado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.herramientas', 'idherramienta'), (SELECT MAX(idherramienta) FROM sgpt.herramientas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new herramienta
                        {
                            //idherramienta = modelo.idHerramienta,
                            idtp = modelo.idTp,
                            idth = modelo.idTh,
                            nombreherramienta = modelo.nombreHerramienta,
                            fechacreadoherramienta =DateTime.Now.ToString("d"),
                            autorizadoporherramienta = usuarioValidado.inicialesusuario.ToUpper(),
                            horasplanherramienta = modelo.horasPlanHerramienta,
                            estadoherramienta = "A",
                            sistemaherramienta = false
                        };
                        //Registro de creación
                        _context.herramientas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idHerramienta = tablaDestino.idherramienta;
                        modelo.autorizadoPorHerramienta = usuarioValidado.inicialesusuario.ToUpper();
                        modelo.sistemaHerramienta = tablaDestino.sistemaherramienta;
                        modelo.estadoHerramienta = tablaDestino.estadoherramienta;
                        modelo.fechacreadoherramienta = DateTime.Parse(tablaDestino.fechacreadoherramienta);
                        //Creación de registro auxiliar de acción realizada
                        var tablaDestinoAuxiliar = new usuarioherramientasaccion
                        {
                            //iduha
                            idherramienta =modelo.idHerramienta,
                            idusuario=usuarioValidado.idUsuario,
                            roluha="C",
                            fechacreadouha=DateTime.Now.ToString("d"),
                            estadouha="A"
                        };
                        //Registro de creación
                        _context.usuarioherramientasaccions.Add(tablaDestinoAuxiliar);
                        _context.SaveChanges();
                        result = true;
                    }
                }
                catch (Exception e)
                {
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

        public static string Insert(HerramientasModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new herramienta
                        {
                            //
                            //idherramienta = modelo.idHerramienta,
                            idtp = modelo.idTp,
                            idth = modelo.idTh,
                            nombreherramienta = modelo.nombreHerramienta,
                            fechacreadoherramienta = DateTime.Now.ToString("d"),
                            autorizadoporherramienta = modelo.autorizadoPorHerramienta,
                            horasplanherramienta = modelo.horasPlanHerramienta,
                            sistemaherramienta = false,
                            estadoherramienta = "A",
                        };
                        _context.herramientas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idHerramienta = tablaDestino.idherramienta;
                        modelo.sistemaHerramienta = tablaDestino.sistemaherramienta;
                        modelo.estadoHerramienta = tablaDestino.estadoherramienta;
                        modelo.fechacreadoherramienta = DateTime.Parse(tablaDestino.fechacreadoherramienta);
                        result = tablaDestino.idherramienta.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar : "+ e.Message);
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
        public static HerramientasModelo Find(int id)
        {
            var entidadModelo = new HerramientasModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    herramienta entidad = _context.herramientas.Find(id);
                    if (entidad == null)
                    {
                        entidadModelo = null;
                    }
                    else
                    {
                        //idherramienta = modelo.idHerramienta,
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.idTp =  entidad.idtp;
                        entidadModelo.idTh  = entidad.idth;
                        entidadModelo.nombreHerramienta  = entidad.nombreherramienta;
                        entidadModelo.fechacreadoherramientaString= entidad.fechacreadoherramienta;//Generara error conversion de fechas
                        entidadModelo.autorizadoPorHerramienta  = entidad.autorizadoporherramienta;
                        entidadModelo.horasPlanHerramienta  = entidad.horasplanherramienta;
                        entidadModelo.sistemaHerramienta = entidad.sistemaherramienta;
                        entidadModelo.estadoHerramienta = entidad.estadoherramienta;

                       
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
                    entidadModelo.fechacreadoherramienta = DateTime.Parse(entidadModelo.fechacreadoherramientaString);
                    return entidadModelo;
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
                    string commandString = String.Format("DELETE FROM sgpt.herramientas WHERE idherramienta={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();


                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static HerramientasModelo Find(string id)
        {
            var entidadModelo = new HerramientasModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    herramienta entidad = _context.herramientas.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        entidadModelo.idHerramienta = entidad.idherramienta;
                        entidadModelo.idTp = entidad.idtp;
                        entidadModelo.idTh = entidad.idth;
                        entidadModelo.nombreHerramienta = entidad.nombreherramienta;
                        entidadModelo.fechacreadoherramientaString = entidad.fechacreadoherramienta;//Generara error conversion de fechas
                        entidadModelo.autorizadoPorHerramienta = entidad.autorizadoporherramienta;
                        entidadModelo.horasPlanHerramienta = entidad.horasplanherramienta;
                        entidadModelo.sistemaHerramienta = entidad.sistemaherramienta;
                        entidad.estadoherramienta = entidad.estadoherramienta;
                    }
                }
                if (entidadModelo == null)
                    return entidadModelo;
                else
                {
                    entidadModelo.fechacreadoherramienta = DateTime.Parse(entidadModelo.fechacreadoherramientaString);
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
                    var modelo = new HerramientasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    herramienta entidad = _context.herramientas.Find(id);
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
                    var modelo = new HerramientasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.herramientas
                            .Where(b => b.estadoherramienta == "B")
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
                    herramienta entidad = _context.herramientas.Find(id);
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
        public static List<HerramientasModelo> TransformLista(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.herramientas.Select(entidad =>
                new HerramientasModelo
                {
                    idHerramienta = entidad.idherramienta,
                    idTp = entidad.idtp,
                    idTh = entidad.idth,
                    nombreHerramienta = entidad.nombreherramienta,
                    fechacreadoherramientaString = entidad.fechacreadoherramienta,//Generara error conversion de fechas
                    autorizadoPorHerramienta = entidad.autorizadoporherramienta,
                    horasPlanHerramienta = entidad.horasplanherramienta,
                    sistemaHerramienta = entidad.sistemaherramienta,
                    estadoHerramienta = entidad.estadoherramienta,
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.idHerramienta).Where(x => x.nombreHerramienta.ToUpper() == Texto).ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }

        public static List<HerramientasModelo> GetAllPkContenido(string texto)
        {
            var Lista = TransformLista(texto);
            Lista.ForEach(c=>c.fechacreadoherramienta = DateTime.Parse(c.fechacreadoherramientaString));
            return Lista;   //Transformacion necesaria por la fecha 
        }



        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.herramientas
                            .Where(b => b.estadoherramienta == "B")
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
        //Para actualizar sumas de modelo herramienta
        public static bool UpdateSumaModelo(int idModelo)
        {
            if (!(idModelo == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        herramienta entidad = _context.herramientas.Find(idModelo);
                        if (!(entidad == null))
                        {
                           if(entidad.idth == 1)
                            { 
                            //entidad.idherramienta = modelo.idHerramienta;
                            entidad.horasplanherramienta = DetalleHerramientasModelo.SumaHora(idModelo);
                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                            }
                            return true;
                            //Creación de registro auxiliar de acción realizada
                            //No creo el registro auxiliar debido a que es el sistema el que esta actualizando
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar : " + e.Message);
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateSumaModelo(HerramientasModelo modelo)
        {
            if (!(modelo.idHerramienta == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        herramienta entidad = _context.herramientas.Find(modelo.idHerramienta);
                        if (!(entidad == null))
                        {
                            if (entidad.idth == 1)
                            {
                                //entidad.idprograma = modelo.idprograma;
                                entidad.horasplanherramienta = DetalleHerramientasModelo.SumaHora(modelo.idHerramienta);
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                modelo.horasPlanHerramienta = entidad.horasplanherramienta;
                            }
                            return true;
                            //Creación de registro auxiliar de acción realizada
                            //No creo el registro auxiliar debido a que es el sistema el que esta actualizando
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar : " + e.Message);
                    return false;
                    throw;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateModelo(HerramientasModelo modelo, UsuarioModelo usuarioValidado)
        {
            
            bool cambio = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        herramienta entidad = _context.herramientas.Find(modelo.idHerramienta);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {

                            //entidad.idherramienta = modelo.idHerramienta;
                            if ((entidad.idtp != modelo.idTp))
                            {
                                cambio = true;
                            }

                            if ((entidad.idth != modelo.idTh))
                            {
                                cambio = true;
                            }

                            if ((entidad.nombreherramienta != modelo.nombreHerramienta))
                            {
                                cambio = true;
                            }
                            if(entidad.idth==1)
                            { 
                            if (entidad.horasplanherramienta != DetalleHerramientasModelo.SumaHora(modelo.idHerramienta))
                            {
                                cambio = true;
                            }
                            }
                            if ((entidad.horasplanherramienta != modelo.horasPlanHerramienta))
                            {
                                cambio = true;
                            }

                            if (cambio)
                            {
                                entidad.idtp = modelo.idTp;
                                entidad.idth = modelo.idTh;
                                entidad.nombreherramienta = modelo.nombreHerramienta;
                                entidad.fechacreadoherramienta = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);//Se actualiza por la modificacion
                                entidad.autorizadoporherramienta = usuarioValidado.inicialesusuario.ToUpper();
                                if (entidad.idth == 1)
                                {
                                    entidad.horasplanherramienta = DetalleHerramientasModelo.SumaHora(modelo.idHerramienta);
                                }
                                else
                                {
                                    entidad.horasplanherramienta = modelo.horasPlanHerramienta;
                                }
                                entidad.sistemaherramienta = modelo.sistemaHerramienta;
                                entidad.estadoherramienta = modelo.estadoHerramienta;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                modelo.horasPlanHerramienta = entidad.horasplanherramienta;
                                //Creación de registro auxiliar de acción realizada
                                var tablaDestinoAuxiliar = new usuarioherramientasaccion
                                {
                                    //iduha
                                    idherramienta = modelo.idHerramienta,
                                    idusuario = usuarioValidado.idUsuario,
                                    roluha = "M", //Modificado=M
                                    fechacreadouha = DateTime.Now.ToString("d"),
                                    estadouha = "A"
                                };
                                //Registro de creación
                                _context.usuarioherramientasaccions.Add(tablaDestinoAuxiliar);
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
                        MessageBox.Show("Exception en actualizar : "+e.Message);
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
            //Permite controlar hacer guardado, únicamente cuando se ha modificado algo en los registros
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            //herramienta entidad = _context.herramientas.Find(id);
                            //Listado de registros hijos y eliminacion
                            var listDetailUsuarioHerramientasAccions = _context.usuarioherramientasaccions.Where(x => x.idherramienta == id).ToList(); ;
                            foreach (var registroDetallado in listDetailUsuarioHerramientasAccions)
                            {
                                registroDetallado.estadouha = "B";
                                _context.Entry(registroDetallado).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            var listDetailDetalleHerramientas = _context.detalleherramientas.Where(x => x.idherramienta == id).ToList(); ;
                            foreach (var detalleHerramientas in listDetailDetalleHerramientas)
                            {
                                detalleHerramientas.estadodh = "B";
                                _context.Entry(detalleHerramientas).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            //eliminacion del padre
                            string commandString = String.Format("UPDATE sgpt.herramientas SET estadoherramienta = 'B' WHERE idherramienta={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();



                            //entidad.estadoherramienta = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : "+e.Message);
                        return result;
                    }
                   
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
                            //herramienta entidad = _context.herramientas.Find(id);
                            //Listado de registros hijos y eliminacion
                            var listDetailUsuarioHerramientasAccions = _context.usuarioherramientasaccions.Where(x => x.idherramienta.ToString() == id).ToList(); ;
                            foreach (var registroDetallado in listDetailUsuarioHerramientasAccions)
                            {
                               registroDetallado.estadouha="B";
                                _context.Entry(registroDetallado).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            var listDetailDetalleHerramientas = _context.detalleherramientas.Where(x => x.idherramienta.ToString() == id).ToList(); ;
                            foreach (var detalleHerramientas in listDetailDetalleHerramientas)
                            {
                                detalleHerramientas.estadodh = "B";
                                _context.Entry(detalleHerramientas).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            //eliminacion del padre
                            string commandString = String.Format("UPDATE sgpt.herramientas SET estadoherramienta = 'B' WHERE idherramienta={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : "+e.Message);
                        return result;
                    }
                    
                }
            }
            else
            {
                return result;
            }
        }
        public static void Delete(int id)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.herramientas WHERE idherramienta={0};", id);
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
                        //herramienta entidad = _context.herramientas.Find(id);
                        //Listado de registros hijos y eliminacion
                        var listDetailUsuarioHerramientasAccions = _context.usuarioherramientasaccions.Where(x => x.idherramienta == id).ToList(); ;
                        foreach (var registroDetallado in listDetailUsuarioHerramientasAccions)
                        {
                            _context.usuarioherramientasaccions.Remove(registroDetallado);
                        }
                        var listDetailDetalleHerramientas = _context.detalleherramientas.Where(x => x.idherramienta == id).ToList(); ;
                        foreach (var detalleHerramientas in listDetailDetalleHerramientas)
                        {
                            _context.detalleherramientas.Remove(detalleHerramientas);
                        }
                        //eliminacion del padre
                        string commandString = String.Format("DELETE FROM sgpt.herramientas WHERE idherramienta={0};", id);
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
                        MessageBox.Show("Exception en borrar registro : "+e.Message);
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
                            //herramienta entidad = _context.herramientas.Find(id);
                            //Listado de registros hijos y eliminacion
                            var listDetailUsuarioHerramientasAccions = _context.usuarioherramientasaccions.Where(x => x.idherramienta.ToString() == id).ToList(); ;
                            foreach (var registroDetallado in listDetailUsuarioHerramientasAccions)
                            {
                                _context.usuarioherramientasaccions.Remove(registroDetallado);
                            }
                            var listDetailDetalleHerramientas = _context.detalleherramientas.Where(x => x.idherramienta.ToString() == id).ToList(); ;
                            foreach (var detalleHerramientas in listDetailDetalleHerramientas)
                            {
                                _context.detalleherramientas.Remove(detalleHerramientas);
                            }
                            //eliminacion del padre
                            string commandString = String.Format("DELETE FROM sgpt.herramientas WHERE idherramienta={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : "+ e.Source);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<HerramientasModelo> GetAllTransform()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.herramientas.Select(entidad =>
                    new HerramientasModelo
                    {
                        idHerramienta = entidad.idherramienta,
                        idTp = entidad.idtp,
                        idTh = entidad.idth,
                        nombreHerramienta = entidad.nombreherramienta,
                        fechacreadoherramientaString = entidad.fechacreadoherramienta,//Generara error conversion de fechas
                        autorizadoPorHerramienta = entidad.autorizadoporherramienta,
                        horasPlanHerramienta = entidad.horasplanherramienta,
                        sistemaHerramienta = entidad.sistemaherramienta,
                        estadoHerramienta = entidad.estadoherramienta,
                        tiposProgramaModelo = new TipoProgramaModelo
                        {
                            id = entidad.tiposprograma.idtp,
                            descripcion = entidad.tiposprograma.descripciontp,
                            sistema = entidad.tiposprograma.sistematp,
                            estado = entidad.tiposprograma.estadotp
                        },
                        tipoHerramientaModelo = new TipoHerramientaModelo
                        {
                            id = entidad.tiposherramienta.idth,
                            descripcion = entidad.tiposherramienta.descripcionth,
                            sistema = entidad.tiposherramienta.sistemath,
                            estado = entidad.tiposherramienta.estadoth
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idHerramienta).Where(x => x.estadoHerramienta == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista "+ e.Message);
                }
                return null;
            }
        }
        public static List<HerramientasModelo> GetAll()
        {
            var Lista = GetAllTransform();
            Lista.ForEach(c => c.fechacreadoherramienta = DateTime.Parse(c.fechacreadoherramientaString));
            return Lista;   //Transformacion necesaria por la fecha 
        }


        public static List<HerramientasModelo> GetAll(int? idTh)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.herramientas.ToList().Where(x => x.estadoherramienta == "A").Where(x => x.idth == idTh).Select(entidad => new HerramientasModelo
                    {
                        idHerramienta = entidad.idherramienta,
                        idTp = entidad.idtp,
                        idTh = entidad.idth,
                        nombreHerramienta = entidad.nombreherramienta,
                        fechacreadoherramientaString = entidad.fechacreadoherramienta,//Generara error conversion de fechas
                        fechacreadoherramienta= DateTime.Parse(entidad.fechacreadoherramienta),
                        autorizadoPorHerramienta = entidad.autorizadoporherramienta,
                        horasPlanHerramienta = entidad.horasplanherramienta,
                        sistemaHerramienta = entidad.sistemaherramienta,
                        estadoHerramienta = entidad.estadoherramienta,
                        idTpNombre=entidad.tiposprograma.descripciontp,
                        seleccionHerramienta=false,
                    });
                    var lista= DateQuery.ToList();
                    int i = 1;
                    if (lista.Count>=1)
                    { 
                        foreach (HerramientasModelo item in lista)
                        {
                            item.idCorrelativoHerramienta = i;
                            i++;
                        }
                    }
                    return lista.ToList();
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

        public static List<HerramientasModelo> GetAllEncabezados(int? idTp)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.herramientas.Select(entidad =>
                        new HerramientasModelo
                        {
                            idHerramienta = entidad.idherramienta,
                            idTp = entidad.idtp,
                            idTh = entidad.idth,
                            nombreHerramienta = entidad.nombreherramienta,
                            autorizadoPorHerramienta = entidad.autorizadoporherramienta,
                            horasPlanHerramienta = entidad.horasplanherramienta,
                            estadoHerramienta = entidad.estadoherramienta,
                            fechacreadoherramientaString = entidad.fechacreadoherramienta,
                            idTpNombre = entidad.tiposprograma.descripciontp
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idHerramienta).Where(x => x.estadoHerramienta == "A").Where(x => x.idTp == idTp).ToList();
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



        public static List<HerramientasModelo> GetAllEncabezados()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    return _context.herramientas.Select(entidad =>
                        new HerramientasModelo
                        {
                            idHerramienta = entidad.idherramienta,
                            idTp = entidad.idtp,
                            idTh = entidad.idth,
                            nombreHerramienta = entidad.nombreherramienta,
                            autorizadoPorHerramienta = entidad.autorizadoporherramienta,
                            horasPlanHerramienta = entidad.horasplanherramienta,
                            estadoHerramienta = entidad.estadoherramienta,
                            fechacreadoherramientaString = entidad.fechacreadoherramienta
                            //Lista filtrada de elementos que fueron eliminados
                        }).OrderBy(o => o.idHerramienta).Where(x => x.estadoHerramienta == "A").ToList();
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
                    elementos = _context.herramientas.Where(x => x.idth == id && x.estadoherramienta == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: "+e.Message);
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
                    elementos = _context.herramientas.Where(x => x.estadoherramienta == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: "+e.Message);
                return elementos;
            }
        }


        #endregion

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.herramientas.Where(x => x.nombreherramienta.ToUpper() == busqueda && x.estadoherramienta == "A").Count();

                    if (elementos == 0)
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

        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.herramientas.Where(x => x.nombreherramienta.ToUpper() == busqueda && x.estadoherramienta == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        
        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static HerramientasModelo Clear(HerramientasModelo modelo)
        {
            return new HerramientasModelo();
        }

        #endregion

        #region Copia
        public static HerramientasModelo GetRegistro(int idBuscado)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.herramientas.Select(entidad =>
                     new HerramientasModelo
                     {
                         idHerramienta = entidad.idherramienta,
                         idTp = entidad.idtp,
                         idTh = entidad.idth,
                         nombreHerramienta = entidad.nombreherramienta,
                         fechacreadoherramientaString = entidad.fechacreadoherramienta,//Generara error conversion de fechas
                         autorizadoPorHerramienta = entidad.autorizadoporherramienta,
                         horasPlanHerramienta = entidad.horasplanherramienta,
                         sistemaHerramienta = entidad.sistemaherramienta,
                         estadoHerramienta = entidad.estadoherramienta,
                         tiposProgramaModelo = new TipoProgramaModelo
                         {
                             id = entidad.tiposprograma.idtp,
                             descripcion = entidad.tiposprograma.descripciontp,
                             sistema = entidad.tiposprograma.sistematp,
                             estado = entidad.tiposprograma.estadotp
                         },
                         tipoHerramientaModelo = new TipoHerramientaModelo
                         {
                             id = entidad.tiposherramienta.idth,
                             descripcion = entidad.tiposherramienta.descripcionth,
                             sistema = entidad.tiposherramienta.sistemath,
                             estado = entidad.tiposherramienta.estadoth
                         }
                         //Lista filtrada de elementos que fueron eliminados
                     }).Where(x => x.idHerramienta == idBuscado).Where(x => x.estadoHerramienta == "A").FirstOrDefault();
                    //La ordena por el idPrograma notar la notacion
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro a copiar de herramienta modelo " + e.Message);
                }
                return null;
            }
        }

        public static bool CopiarModelo(HerramientasModelo modelo, UsuarioModelo usuarioValidado)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Registro a copiar
                        herramienta entidad = _context.herramientas.Find(modelo.idHerramienta);
                        //Inserta el registro con los nuevos datos
                        if (Insert(modelo, usuarioValidado))
                        {
                            //éxito en la copia
                            int anterior = 0;
                            var lista = DetalleHerramientasModelo.GetAll(entidad.idherramienta);
                            foreach (DetalleHerramientasModelo item in lista)
                            {
                                anterior = item.idDh;
                                item.idHerramienta = modelo.idHerramienta;//Nuevo id del padre
                                if (item.idDhPrincipalDh == null)
                                {
                                    item.idDh = 0;
                                    if (DetalleHerramientasModelo.Insert(item, true))
                                    {
                                        foreach (DetalleHerramientasModelo itemHijo in lista)
                                        {
                                            if (itemHijo.idDhPrincipalDh == anterior)
                                            {
                                                itemHijo.idDhPrincipalDh = item.idDh;
                                                itemHijo.detalleHerramientasModeloPadre = item;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error en la  inserción del detalle programas con id : " + item.idDh);
                                    }
                                }
                            }
                            foreach (DetalleHerramientasModelo item in lista)
                            {
                                if (item.idDhPrincipalDh != null)
                                {
                                    item.idDh = 0;
                                    if (!(DetalleHerramientasModelo.Insert(item, true)))
                                    {
                                        MessageBox.Show("Error en la  inserción del detalle con id : " + item.idDh);
                                    }
                                }
                            }

                            return true;
                        }
                        {
                            //Fallo la copia
                            return false;
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

        public HerramientasModelo()
        {
                         idHerramienta =0;
                         idTp = null;
                         idTh = null;
                         nombreHerramienta = string.Empty;
                         fechacreadoherramientaString = MetodosModelo.homologacionFecha();//Generara error conversion de fechas
                         autorizadoPorHerramienta = string.Empty;
                         horasPlanHerramienta = 0;
                         sistemaHerramienta = false;
                         estadoHerramienta = "A";
                         tiposProgramaModelo = null;
                         tipoHerramientaModelo = null;
        }

        public HerramientasModelo(int tipoHerramienta, UsuarioModelo usuario)
        {
            idHerramienta = 0;
            idTp = null;
            idTh = tipoHerramienta; //1 Para programa 2 para cuestionario
            nombreHerramienta = string.Empty;
            fechacreadoherramientaString = MetodosModelo.homologacionFecha();//Generara error conversion de fechas
            fechacreadoherramienta= MetodosModelo.FechaHoy();
            autorizadoPorHerramienta = usuario.inicialesusuario.ToUpper();
            horasPlanHerramienta = 0;
            sistemaHerramienta = false;
            estadoHerramienta = "A";
            tiposProgramaModelo = null;
            tipoHerramientaModelo = null;
        }
        public HerramientasModelo(int tipoHerramienta, UsuarioModelo usuario,TipoHerramientaModelo tipoHerramientaOrigen)
        {
            idHerramienta = 0;
            idTp = null;
            idTh = tipoHerramienta; //1 Para programa 2 para cuestionario
            nombreHerramienta = string.Empty;
            fechacreadoherramientaString = MetodosModelo.homologacionFecha();//Generara error conversion de fechas
            fechacreadoherramienta = MetodosModelo.FechaHoy();
            autorizadoPorHerramienta = usuario.inicialesusuario.ToUpper();
            horasPlanHerramienta = 0;
            sistemaHerramienta = false;
            estadoHerramienta = "A";
            tiposProgramaModelo = null;
            this.tipoHerramientaModelo = tipoHerramientaOrigen;
            idTh = tipoHerramientaOrigen.id;

        }

        #endregion
    }

}



