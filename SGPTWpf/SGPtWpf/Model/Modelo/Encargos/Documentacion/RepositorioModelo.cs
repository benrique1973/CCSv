using CapaDatos;
using SGPTWpf.Model;
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
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class RepositorioModelo : UIBase
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
        public int idrepositorio
        {
            get { return GetValue(() => idrepositorio); }
            set { SetValue(() => idrepositorio, value); }
        }

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

        public int? iddocumento
        {
            get { return GetValue(() => iddocumento); }
            set { SetValue(() => iddocumento, value); }
        }


        public int? idindice
        {
            get { return GetValue(() => idindice); }
            set { SetValue(() => idindice, value); }
        }

        [DisplayName("Nombre del  documento")]
        [Required(ErrorMessage = "Debe ingresar el nombre del documento")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(5, ErrorMessage = "Debe ser mayor a 5 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string nombrerepositorio
        {
            get { return GetValue(() => nombrerepositorio); }
            set { SetValue(() => nombrerepositorio, value); }
        }

        [DisplayName("Descripción  documento")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(5, ErrorMessage = "Debe ser mayor a 5 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string comentariorepositorio
        {
            get { return GetValue(() => comentariorepositorio); }
            set { SetValue(() => comentariorepositorio, value); }
        }

        public decimal? versionrepositorio
        {
            get { return GetValue(() => versionrepositorio); }
            set { SetValue(() => versionrepositorio, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechacreadorepositorio
        {
            get { return GetValue(() => fechacreadorepositorio); }
            set { SetValue(() => fechacreadorepositorio, value); }
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

        public string tipoarchivorepositorio
        {
            get { return GetValue(() => tipoarchivorepositorio); }
            set { SetValue(() => tipoarchivorepositorio, value); }
        }

        public byte[] pdfrepositorio
        {
            get { return GetValue(() => pdfrepositorio); }
            set { SetValue(() => pdfrepositorio, value); }
        }

        //Permite la gestión del borrado lógico de los elementos identificándose por A) Activo, B) Borrado
        public string estadorepositorio
        {
            get { return GetValue(() => estadorepositorio); }
            set { SetValue(() => estadorepositorio, value); }
        }

        //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }

        public byte[] binariorepositorio
        {
            get { return GetValue(() => binariorepositorio); }
            set { SetValue(() => binariorepositorio, value); }
        }


        public string nombrepdf
        {
            get { return GetValue(() => nombrepdf); }
            set { SetValue(() => nombrepdf, value); }
        }

        public string nombrebinariorepositorio
        {
            get { return GetValue(() => nombrebinariorepositorio); }
            set { SetValue(() => nombrebinariorepositorio, value); }
        }


        //Almacena la referencia para el  papel de  trabajo
        [DisplayName("Referencia de la  evaluación")]
        [Required(ErrorMessage = "Debe ingresar la referencia del documento")]
        [MaxLength(30, ErrorMessage = "No debe de exceder 30 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string referenciarepositorio
        {
            get { return GetValue(() => referenciarepositorio); }
            set { SetValue(() => referenciarepositorio, value); }
        }

        public int? idgenerico
        {
            get { return GetValue(() => idgenerico); }
            set { SetValue(() => idgenerico, value); }
        }

        public string tabla
        {
            get { return GetValue(() => tabla); }
            set { SetValue(() => tabla, value); }
        }

        #region Propiedades adiciones de fechas


        public string usuariocreo
        {
            get { return GetValue(() => usuariocreo); }
            set { SetValue(() => usuariocreo, value); }
        }

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

        public string etapapapel
        {
            get { return GetValue(() => etapapapel); }
            set { SetValue(() => etapapapel, value); }
        }
        public string idnitcliente
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }

        public repositorio entidadBase
        {
            get { return GetValue(() => entidadBase); }
            set { SetValue(() => entidadBase, value); }
        }
        #endregion

        #region adicionales

        public string fechainiperauditencargo
        {
            get { return GetValue(() => fechainiperauditencargo); }
            set { SetValue(() => fechainiperauditencargo, value); }
        }

        public string fechafinperauditencargo
        {
            get { return GetValue(() => fechafinperauditencargo); }
            set { SetValue(() => fechafinperauditencargo, value); }
        }

        public string descripcionTipoAuditoriaPrograma
        {
            get { return GetValue(() => descripcionTipoAuditoriaPrograma); }
            set { SetValue(() => descripcionTipoAuditoriaPrograma, value); }
        }

        public string descripciondocumento
        {
            get { return GetValue(() => descripciondocumento); }
            set { SetValue(() => descripciondocumento, value); }
        }
        #endregion
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

        #region Control de archivos lanzados

        public Guid guId
        {
            get { return GetValue(() => guId); }
            set { SetValue(() => guId, value); }
        }
        #endregion
        #endregion


        #region colecciones virtuales

        public virtual BitacoraModelo bitacoraModelo
        {
            get { return GetValue(() => bitacoraModelo); }
            set { SetValue(() => bitacoraModelo, value); }
        }

        public virtual RepositorioModelo repositorioModelo
        {
            get { return GetValue(() => repositorioModelo); }
            set { SetValue(() => repositorioModelo, value); }
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
        public ObservableCollection<RepositorioModelo> listaEntidadSeleccion
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

        public static bool Insert(RepositorioModelo modelo, bool resultado)
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
                              /*  int idimaginario = _context.repositorios.Max(t => t.idrepositorio);
                                if (idimaginario < 0 )
                                    idimaginario = 0;
                                string fd = "ALTER SEQUENCE sgpt.repositorio_idrepositorio_seq RESTART WITH " + (idimaginario + 1) + ";";
                                var reiniciarIdPorDefectoDePostgreSql = _context.Database.ExecuteSqlCommand(fd);
                                _context.SaveChanges();*/
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.repositorio', 'idrepositorio'), (SELECT MAX(idrepositorio) FROM sgpt.repositorio) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new repositorio
                        {
                            //idrepositorio = modelo.idrepositorio,
                            idpapeles = modelo.idpapeles,
                            idencargo = modelo.idencargo,
                            iddocumento = modelo.iddocumento,
                            idindice = modelo.idindice,
                            nombrerepositorio = modelo.nombrerepositorio,
                            comentariorepositorio = modelo.comentariorepositorio,
                            versionrepositorio = modelo.versionrepositorio,
                            fechacreadorepositorio = modelo.fechacreadorepositorio,
                            tipoarchivorepositorio = modelo.tipoarchivorepositorio,
                            pdfrepositorio = modelo.pdfrepositorio,
                            estadorepositorio = modelo.estadorepositorio,
                            isuso = modelo.isuso,
                            binariorepositorio = modelo.binariorepositorio,
                            nombrepdf = modelo.nombrepdf,
                            nombrebinariorepositorio = modelo.nombrebinariorepositorio,
                            referenciarepositorio = modelo.referenciarepositorio,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                        };
                        _context.repositorios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idrepositorio = tablaDestino.idrepositorio;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(1));
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
                }
            }
            else
            {
                return result;
            }
        }

        public static bool InsertCapaDatos(repositorio modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.repositorio', 'idrepositorio'), (SELECT MAX(idrepositorio) FROM sgpt.repositorio) + 1);");
                            sincronizar = true;
                        }
                        _context.repositorios.Add(modelo);
                        _context.SaveChanges();
                        modelo.idrepositorio = modelo.idrepositorio;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        public static int Insert(RepositorioModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.repositorio', 'idrepositorio'), (SELECT MAX(idrepositorio) FROM sgpt.repositorio) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new repositorio
                        {
                            //idrepositorio = modelo.idrepositorio,
                            //idpapeles = modelo.idpapeles,
                            idencargo = modelo.idencargo,
                            iddocumento = modelo.iddocumento,
                            //idindice = modelo.idindice,
                            nombrerepositorio = modelo.nombrerepositorio,
                            comentariorepositorio = modelo.comentariorepositorio,
                            versionrepositorio = modelo.versionrepositorio,
                            fechacreadorepositorio = modelo.fechacreadorepositorio,
                            tipoarchivorepositorio = modelo.tipoarchivorepositorio,
                            pdfrepositorio = modelo.pdfrepositorio,
                            estadorepositorio = modelo.estadorepositorio,
                            isuso = modelo.isuso,
                            binariorepositorio = modelo.binariorepositorio,
                            nombrepdf = modelo.nombrepdf,
                            nombrebinariorepositorio = modelo.nombrebinariorepositorio,
                            referenciarepositorio = modelo.referenciarepositorio,
                            //idgenerico = modelo.idgenerico,
                            //tabla = modelo.tabla,
                            //usuariocerro = modelo.usuariocerro,
                            //usuarioaprobo = modelo.usuarioaprobo,
                            //usuariosuperviso = modelo.usuariosuperviso,
                            //fechasupervision = modelo.fechasupervision,
                            //fechaaprobacion = modelo.fechaaprobacion,
                            //fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,

                        };
                        _context.repositorios.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idrepositorio = tablaDestino.idrepositorio;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        BitacoraModelo.Insert(temporal,1);
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


        public static int InsertByRangeByCapadatos(ObservableCollection<repositorio> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.repositorio', 'idrepositorio'), (SELECT MAX(idrepositorio) FROM sgpt.repositorio) + 1);");
                            sincronizar = true;
                        }
                        _context.repositorios.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return -1;
                }
            }
            else
            {
                return result;
            }
        }

        public static RepositorioModelo Find(int id)
        {
            var entidad = new RepositorioModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //repositorio modelo = _context.repositorios.Find(id);
                        repositorio modelo = _context.repositorios.Single(x => x.idrepositorio == id);
                        if (modelo != null)
                        {
                            entidad.idrepositorio = modelo.idrepositorio;
                            entidad.idpapeles = modelo.idpapeles;
                            entidad.idencargo = modelo.idencargo;
                            entidad.iddocumento = modelo.iddocumento;
                            entidad.idindice = modelo.idindice;
                            entidad.nombrerepositorio = modelo.nombrerepositorio;
                            entidad.comentariorepositorio = modelo.comentariorepositorio;
                            entidad.versionrepositorio = modelo.versionrepositorio;
                            entidad.fechacreadorepositorio = modelo.fechacreadorepositorio;
                            entidad.tipoarchivorepositorio = modelo.tipoarchivorepositorio;
                            entidad.pdfrepositorio = modelo.pdfrepositorio;
                            entidad.estadorepositorio = modelo.estadorepositorio;
                            entidad.isuso = modelo.isuso;
                            entidad.binariorepositorio = modelo.binariorepositorio;
                            entidad.nombrepdf = modelo.nombrepdf;
                            entidad.nombrebinariorepositorio = modelo.nombrebinariorepositorio;
                            entidad.referenciarepositorio = modelo.referenciarepositorio;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.entidadBase = modelo;
                            return entidad;
                        }
                        else
                        {
                            return new RepositorioModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new RepositorioModelo();
                }

            }
            else
            {
                return entidad = null;
            }
        }

        #region Metodos para string 

        public static bool FindPK(int? id)
        {
            if (!(string.IsNullOrEmpty(id.ToString())))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new RepositorioModelo();
                    repositorio entidad = _context.repositorios.Find(id);
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
                    var modelo = new RepositorioModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.repositorios
                            .Where(b => b.estadorepositorio == "B")
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
                    repositorio entidad = _context.repositorios.Find(id);
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

        public static void UpdateModelo(RepositorioModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    repositorio entidad = _context.repositorios.Find(modelo.idrepositorio);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        if (entidad.idrepositorio != modelo.idrepositorio) { cambiar = true; }
                        if (entidad.idpapeles != modelo.idpapeles) { cambiar = true; }
                        if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                        if (entidad.iddocumento != modelo.iddocumento) { cambiar = true; }
                        if (entidad.idindice != modelo.idindice) { cambiar = true; }
                        if (entidad.nombrerepositorio != modelo.nombrerepositorio) { cambiar = true; }
                        if (entidad.comentariorepositorio != modelo.comentariorepositorio) { cambiar = true; }
                        if (entidad.versionrepositorio != modelo.versionrepositorio) { cambiar = true; }
                        if (entidad.fechacreadorepositorio != modelo.fechacreadorepositorio) { cambiar = true; }
                        if (entidad.tipoarchivorepositorio != modelo.tipoarchivorepositorio) { cambiar = true; }
                        if (entidad.pdfrepositorio != modelo.pdfrepositorio) { cambiar = true; }
                        if (entidad.estadorepositorio != modelo.estadorepositorio) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }
                        if (entidad.binariorepositorio != modelo.binariorepositorio) { cambiar = true; }
                        if (entidad.nombrepdf != modelo.nombrepdf) { cambiar = true; }
                        if (entidad.nombrebinariorepositorio != modelo.nombrebinariorepositorio) { cambiar = true; }
                        if (entidad.referenciarepositorio != modelo.referenciarepositorio) { cambiar = true; }
                        if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                        if(cambiar)
                        { 
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idpapeles = modelo.idpapeles;
                        entidad.idencargo = modelo.idencargo;
                        entidad.iddocumento = modelo.iddocumento;
                        entidad.idindice = modelo.idindice;
                        entidad.nombrerepositorio = modelo.nombrerepositorio;
                        entidad.comentariorepositorio = modelo.comentariorepositorio;
                        entidad.versionrepositorio = modelo.versionrepositorio;
                        entidad.fechacreadorepositorio = modelo.fechacreadorepositorio;
                        entidad.tipoarchivorepositorio = modelo.tipoarchivorepositorio;
                        entidad.pdfrepositorio = modelo.pdfrepositorio;
                        entidad.estadorepositorio = modelo.estadorepositorio;
                        entidad.isuso = modelo.isuso;
                        entidad.binariorepositorio = modelo.binariorepositorio;
                        entidad.nombrepdf = modelo.nombrepdf;
                        entidad.nombrebinariorepositorio = modelo.nombrebinariorepositorio;
                        entidad.referenciarepositorio = modelo.referenciarepositorio;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.etapapapel = modelo.etapapapel;
                            _context.Entry(entidad).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                    }

                }
            }
            else
            {
                //No regresa nada
            }
        }

        public static bool UpdateArchivo(RepositorioModelo modelo)
        {
            bool respuesta = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string cambioTexto = "";
                        //repositorio entidad = _context.repositorios.Find(modelo.idrepositorio);
                        repositorio entidad =modelo.entidadBase;
                        if (entidad == null)
                        {
                            return respuesta;
                        }
                        else
                        {
                                entidad.versionrepositorio = (modelo.versionrepositorio + (decimal)0.01);
                                entidad.binariorepositorio = modelo.binariorepositorio;
                                entidad.nombrebinariorepositorio = modelo.nombrebinariorepositorio;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = cambioTexto;
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                    // modelo.listaBitacora.Add(temporal);
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
                return true;
            }
        }

        public static int UpdateModelo(RepositorioModelo modelo, Boolean actualizar)
        {
            int respuesta = 0;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambiar = false;
                        string cambioTexto = "";
                        repositorio entidad = _context.repositorios.Find(modelo.idrepositorio);
                        if (entidad == null)
                        {
                            return respuesta;
                        }
                        else
                        {
                            //if (entidad.idrepositorio != modelo.idrepositorio) { cambiar = true; }
                            //if (entidad.idpapeles != modelo.idpapeles) { cambiar = true; }
                            //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            //if (entidad.iddocumento != modelo.iddocumento) { cambiar = true; }
                            if (entidad.idindice != modelo.idindice) { cambiar = true; }
                            if (entidad.nombrerepositorio != modelo.nombrerepositorio) { cambiar = true; }
                            if (entidad.comentariorepositorio != modelo.comentariorepositorio) { cambiar = true; }
                            if (entidad.versionrepositorio != modelo.versionrepositorio) { cambiar = true; }
                            //if (entidad.fechacreadorepositorio != modelo.fechacreadorepositorio) { cambiar = true; }
                            if (entidad.tipoarchivorepositorio != modelo.tipoarchivorepositorio) { cambiar = true; }
                            if (entidad.pdfrepositorio != modelo.pdfrepositorio) { cambiar = true; }
                            //if (entidad.estadorepositorio != modelo.estadorepositorio) { cambiar = true; }
                            //if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            if (entidad.binariorepositorio != modelo.binariorepositorio) { cambiar = true; }
                            if (entidad.nombrepdf != modelo.nombrepdf) { cambiar = true; }
                            if (entidad.nombrebinariorepositorio != modelo.nombrebinariorepositorio) { cambiar = true; }
                            if (entidad.referenciarepositorio != modelo.referenciarepositorio) { cambiar = true; }
                            //if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                            //if (entidad.tabla != modelo.tabla) { cambiar = true; }
                            //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                            //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            //if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }

                            if (cambiar)
                            {
                                //entidad.idrepositorio = modelo.idrepositorio;
                                entidad.idpapeles = modelo.idpapeles;
                                entidad.idencargo = modelo.idencargo;
                                entidad.iddocumento = modelo.iddocumento;
                                entidad.idindice = modelo.idindice;
                                entidad.nombrerepositorio = modelo.nombrerepositorio;
                                entidad.comentariorepositorio = modelo.comentariorepositorio;
                                entidad.versionrepositorio = (modelo.versionrepositorio+(decimal)0.01);
                                entidad.fechacreadorepositorio = modelo.fechacreadorepositorio;
                                entidad.tipoarchivorepositorio = modelo.tipoarchivorepositorio;
                                entidad.pdfrepositorio = modelo.pdfrepositorio;
                                entidad.estadorepositorio = modelo.estadorepositorio;
                                entidad.isuso = modelo.isuso;
                                entidad.binariorepositorio = modelo.binariorepositorio;
                                entidad.nombrepdf = modelo.nombrepdf;
                                entidad.nombrebinariorepositorio = modelo.nombrebinariorepositorio;
                                entidad.referenciarepositorio = modelo.referenciarepositorio;
                                entidad.idgenerico = modelo.idgenerico;
                                entidad.tabla = modelo.tabla;
                                entidad.usuariocerro = modelo.usuariocerro;
                                entidad.usuarioaprobo = modelo.usuarioaprobo;
                                entidad.usuariosuperviso = modelo.usuariosuperviso;
                                entidad.fechasupervision = modelo.fechasupervision;
                                entidad.fechaaprobacion = modelo.fechaaprobacion;
                                entidad.fechacierre = modelo.fechacierre;
                                entidad.etapapapel = modelo.etapapapel;

                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = cambioTexto;
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                    // modelo.listaBitacora.Add(temporal);
                                }
                                return 1;
                            }
                            else
                            {
                                return 1;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id, RepositorioModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET estadorepositorio = 'B' WHERE idrepositorio={0};", id);
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



        public static int Delete(ObservableCollection<RepositorioModelo> lista)
        {
            try
            {
               if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        repositorio entidadTemporal = new repositorio();
                        string commandString = string.Empty;
                        foreach (RepositorioModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idrepositorio);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.repositorio WHERE idrepositorio={0};", item.idrepositorio);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return -1;
            }
        }

        public static int DeleteLogico(ObservableCollection<RepositorioModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        repositorio entidadTemporal = new repositorio();
                        string commandString = string.Empty;
                        foreach (RepositorioModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idrepositorio);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.repositorio SET estadorepositorio = 'B' WHERE idrepositorio={0};", item.idrepositorio);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        return 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return -1;
            }
        }



        public static int Delete(RepositorioModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.iddocumento != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                               //éxito en la operacion
                                    //Continuar
                                    string commandString = String.Format("DELETE FROM sgpt.repositorio WHERE idrepositorio={0};", modelo.idrepositorio);
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
                            MessageBox.Show("Exception en borrar registro \n" + e);
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

        public static int DeleteLogico(RepositorioModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.iddocumento != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.repositorio SET estadorepositorio = 'B' WHERE idrepositorio={0};", modelo.idrepositorio);
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
                            MessageBox.Show("Exception en borrar registro \n" + e);
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
                           string commandString = String.Format("UPDATE sgpt.programas SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                " etapapapel ='{6}' WHERE idrepositorio={7};",
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


        public static void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id, "REPOSITORIO");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.repositorio WHERE idrepositorio={0};", id);
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

        public static void DeleteByRange(ObservableCollection<repositorio> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.repositorios.RemoveRange(lista);
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

                        //DetalleRepositorioModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.repositorio WHERE idrepositorio={0};", id);
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
            }
        }


        public static int DeleteBorradoLogico(ObservableCollection<RepositorioModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    repositorio entidadTemporal = new repositorio();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (RepositorioModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idrepositorio);//Borra todas las referencias dentro  de bitacora
                                                                                         //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idrepositorio);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.repositorio SET estadorepositorio = 'B' WHERE idrepositorio={0};", item.idrepositorio);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                        _context.SaveChanges();
                    }

                    return 1;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                    }
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        internal static List<RepositorioModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idDocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idnitcliente=entidad.encargo.idnitcliente,
                         descripciondocumento=entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddocumento).Where(x => x.estadorepositorio == "A" 
                                                          && x.idencargo!=encargo.idencargo 
                                                          && x.idnitcliente==encargo.idnitcliente
                                                          && x.iddocumento == idDocumento).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (RepositorioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                        }
                        //lista.ForEach(c => c.guardadoBase = true);
                    }
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

        internal static List<RepositorioModelo> GetAllByEncargosImportacionOtros(EncargoModelo encargo, int? idDocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idnitcliente = entidad.encargo.idnitcliente,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddocumento).Where(x => x.estadorepositorio == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idnitcliente == encargo.idnitcliente
                                                          && x.iddocumento != 2
                                                          && x.iddocumento != 7
                                                          && x.iddocumento != 8).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (RepositorioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                        }
                        //lista.ForEach(c => c.guardadoBase = true);
                    }
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

        internal static List<RepositorioModelo> GetAllByEncargosImportacionEncabezados(EncargoModelo encargo, int? idDocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         //fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         //pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         //binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idnitcliente = entidad.encargo.idnitcliente,

                         fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                         fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                         descripcionTipoAuditoriaPrograma = entidad.encargo.tiposauditoria.descripcionta,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddocumento).Where(x => x.estadorepositorio == "A"
                                                          && x.idencargo != encargo.idencargo 
                                                          && x.idnitcliente == encargo.idnitcliente
                                                          && x.iddocumento == idDocumento).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (RepositorioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                        }
                        //lista.ForEach(c => c.guardadoBase = true);
                    }
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

        internal static List<RepositorioModelo> GetAllByEncargosImportacionEncabezadosOtros(EncargoModelo encargo, int? idDocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         //fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         //pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         //binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idnitcliente = entidad.encargo.idnitcliente,

                         fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                         fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                         descripcionTipoAuditoriaPrograma = entidad.encargo.tiposauditoria.descripcionta,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddocumento).Where(x => x.estadorepositorio == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idnitcliente == encargo.idnitcliente
                                                          && x.iddocumento != 2
                                                          && x.iddocumento != 7
                                                          && x.iddocumento != 8).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (RepositorioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                        }
                        //lista.ForEach(c => c.guardadoBase = true);
                    }
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<repositorio> lista, int idrepositorio)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.repositorio SET estadorepositorio = 'B' WHERE idrepositorio = {0};", idrepositorio);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
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

        //Conversion explicita
        public static explicit operator repositorio(RepositorioModelo modelo)  // explicit byte to digit conversion operator
        {
            repositorio entidad = new repositorio();
            entidad.idrepositorio = modelo.idrepositorio;
            entidad.idpapeles = modelo.idpapeles;
            entidad.idencargo = modelo.idencargo;
            entidad.iddocumento = modelo.iddocumento;
            entidad.idindice = modelo.idindice;
            entidad.nombrerepositorio = modelo.nombrerepositorio;
            entidad.comentariorepositorio = modelo.comentariorepositorio;
            entidad.versionrepositorio = modelo.versionrepositorio;
            entidad.fechacreadorepositorio = modelo.fechacreadorepositorio;
            entidad.tipoarchivorepositorio = modelo.tipoarchivorepositorio;
            entidad.pdfrepositorio = modelo.pdfrepositorio;
            entidad.estadorepositorio = modelo.estadorepositorio;
            entidad.isuso = modelo.isuso;
            entidad.binariorepositorio = modelo.binariorepositorio;
            entidad.nombrepdf = modelo.nombrepdf;
            entidad.nombrebinariorepositorio = modelo.nombrebinariorepositorio;
            entidad.referenciarepositorio = modelo.referenciarepositorio;
            entidad.idgenerico = modelo.idgenerico;
            entidad.tabla = modelo.tabla;
            entidad.usuariocerro = modelo.usuariocerro;
            entidad.usuarioaprobo = modelo.usuarioaprobo;
            entidad.usuariosuperviso = modelo.usuariosuperviso;
            entidad.fechasupervision = modelo.fechasupervision;
            entidad.fechaaprobacion = modelo.fechaaprobacion;
            entidad.fechacierre = modelo.fechacierre;
            entidad.etapapapel = modelo.etapapapel;
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

                            string commandString = String.Format("DELETE FROM sgpt.repositorio WHERE idrepositorio={0};", id);
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
                        { MessageBox.Show("Exception en borrar registro : " + e.Source);

                        }
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<RepositorioModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         descripciondocumento=entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddocumento).Where(x => x.estadorepositorio == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (RepositorioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                        }
                        //lista.ForEach(c => c.guardadoBase = true);
                    }
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

        internal static int UpdateModificacion(RepositorioModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idrepositorio;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET fechaevaluacionmr = '{0}',etapapapel ='{1}' WHERE idrepositorio = {2};",
                            modelo.iddocumento,
                            EtapaEncargoModelo.seleccionEtapaIniciales(2),
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
        internal static int UpdateCierre(RepositorioModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idrepositorio;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idrepositorio = {3};",
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

        internal static int UpdateReferencia(RepositorioModelo modelo)
        {
            int id = modelo.idrepositorio;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET referenciarepositorio = '{0}',etapapapel ='{1}' WHERE idrepositorio={2};", modelo.referenciarepositorio, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(RepositorioModelo modelo)
        {
            int id = modelo.idrepositorio;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idrepositorio = {3};",
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

        internal static int UpdateAprobacion(RepositorioModelo modelo)
        {
            int id = modelo.idrepositorio;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idrepositorio = {3};",
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

        internal static int UpdateAprobacionSupervision(RepositorioModelo modelo)
        {
            int id = modelo.idrepositorio;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "REPOSITORIO", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.repositorio SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idrepositorio = {5};",
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

        public static List<RepositorioModelo> GetAll(EncargoModelo encargo, int iddocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         descripciondocumento=entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idrepositorio).Where(x => x.estadorepositorio == "A" && x.idencargo == encargo.idencargo && x.iddocumento==iddocumento).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    //var listaBitacora = BitacoraModelo.GetAllByTabla("REPOSITORIO");
                    //if (listaBitacora.Count > 0)
                    //{
                    //    string etapaBuscada = EtapaEncargoModelo.seleccionEtapa(1);//Creacion
                    //    foreach (RepositorioModelo item in lista)
                    //    {
                    //        item.idCorrelativo = i;
                    //        i++;
                    //        item.guardadoBase = true;
                    //        item.IsSelected = false;

                    //        //Buscar en bitara
                    //        try
                    //        {
                    //            item.usuariocreo = listaBitacora.Single(x => x.idtransaccionbitacora == item.idrepositorio && x.accionbitacora.Contains(etapaBuscada)).inicialesusuariobitacora;
                    //        }
                    //        catch (Exception e)
                    //        {
                    //            item.usuariocreo = string.Empty;
                    //            MessageBox.Show("Exception en elaboracion del detalle \n" + e);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                        foreach (RepositorioModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitacora
                            item.usuariocreo = string.Empty;
                    //    }
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

        public static List<RepositorioModelo> GetAllOtros(EncargoModelo encargo, int iddocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idrepositorio).Where(x => x.estadorepositorio == "A" && x.idencargo == encargo.idencargo
                        && x.iddocumento != 2
                        && x.iddocumento != 7
                        && x.iddocumento != 8).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    //var listaBitacora = BitacoraModelo.GetAllByTabla("REPOSITORIO");
                    //if (listaBitacora.Count > 0)
                    //{
                    //    string etapaBuscada = EtapaEncargoModelo.seleccionEtapa(1);//Creacion
                    //    foreach (RepositorioModelo item in lista)
                    //    {
                    //        item.idCorrelativo = i;
                    //        i++;
                    //        item.guardadoBase = true;
                    //        item.IsSelected = false;

                    //        //Buscar en bitara
                    //        try
                    //        {
                    //            item.usuariocreo = listaBitacora.Single(x => x.idtransaccionbitacora == item.idrepositorio && x.accionbitacora.Contains(etapaBuscada)).inicialesusuariobitacora;
                    //        }
                    //        catch (Exception e)
                    //        {
                    //            item.usuariocreo = string.Empty;
                    //            MessageBox.Show("Exception en elaboracion del detalle \n" + e);
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    foreach (RepositorioModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        //Buscar en bitacora
                        item.usuariocreo = string.Empty;
                        //    }
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

        public static List<RepositorioModelo> GetAllEncabezado(int? idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         //pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         //binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idrepositorio).Where(x => x.estadorepositorio == "A" && x.idencargo == idEncargo ).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (RepositorioModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        //Buscar en bitacora
                        item.usuariocreo = string.Empty;
                        //    }
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

        public static ObservableCollection<RepositorioModelo> GetAllReferenciacion(int? idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         nombrerepositorio = entidad.nombrerepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idrepositorio).Where(x => x.estadorepositorio == "A" && x.idencargo == idEncargo).ToList();
                    //La ordena por el idPrograma notar la notacion
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<RepositorioModelo>(lista.ToList());
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

        public static List<RepositorioModelo> GetAllEncabezado(EncargoModelo encargo, int iddocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         //pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         //binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         descripciondocumento=entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idrepositorio).Where(x => x.estadorepositorio == "A" && x.idencargo == encargo.idencargo && x.iddocumento == iddocumento).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (RepositorioModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        //Buscar en bitacora
                        item.usuariocreo = string.Empty;
                        //    }
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

        public static List<RepositorioModelo> GetAllEncabezadosOtros(EncargoModelo encargo, int iddocumento)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Select(entidad =>
                     new RepositorioModelo
                     {
                         idrepositorio = entidad.idrepositorio,
                         idpapeles = entidad.idpapeles,
                         idencargo = entidad.idencargo,
                         iddocumento = entidad.iddocumento,
                         idindice = entidad.idindice,
                         nombrerepositorio = entidad.nombrerepositorio,
                         comentariorepositorio = entidad.comentariorepositorio,
                         versionrepositorio = entidad.versionrepositorio,
                         fechacreadorepositorio = entidad.fechacreadorepositorio,
                         tipoarchivorepositorio = entidad.tipoarchivorepositorio,
                         //pdfrepositorio = entidad.pdfrepositorio,
                         estadorepositorio = entidad.estadorepositorio,
                         isuso = entidad.isuso,
                         //binariorepositorio = entidad.binariorepositorio,
                         nombrepdf = entidad.nombrepdf,
                         nombrebinariorepositorio = entidad.nombrebinariorepositorio,
                         referenciarepositorio = entidad.referenciarepositorio,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         descripciondocumento = entidad.documento.descripciondocumento,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idrepositorio).Where(x => x.estadorepositorio == "A" && x.idencargo == encargo.idencargo 
                     && x.iddocumento != 2
                     && x.iddocumento != 7
                     && x.iddocumento != 8).ToList();
                    //La ordena por el idPrograma notar la notacion
                    //1;"Actas";"A";TRUE
                    //2;"Carta";"A";TRUE
                    //3;"Cédula";"A";TRUE
                    //4;"Confirmación";"A";TRUE
                    //5;"Email";"A";TRUE
                    //6;"Estados financieros";"A";TRUE
                    //7;"Informe de auditoría";"A";TRUE
                    //8;"Memorando";"A";TRUE
                    //9;"Reunión";"A";TRUE
                    //10;"Otros";"A";TRUE
                    int i = 1;
                    foreach (RepositorioModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        //Buscar en bitacora
                        item.usuariocreo = string.Empty;
                        //    }
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


        internal static RepositorioModelo GetRegistro(int idgenericoindice)
        {
            var entidad = new RepositorioModelo();
            if (!(idgenericoindice == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    repositorio modelo = _context.repositorios.Find(idgenericoindice);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idpapeles = modelo.idpapeles;
                        entidad.idencargo = modelo.idencargo;
                        entidad.iddocumento = modelo.iddocumento;
                        entidad.idindice = modelo.idindice;
                        entidad.nombrerepositorio = modelo.nombrerepositorio;
                        entidad.comentariorepositorio = modelo.comentariorepositorio;
                        entidad.versionrepositorio = modelo.versionrepositorio;
                        entidad.fechacreadorepositorio = modelo.fechacreadorepositorio;
                        entidad.tipoarchivorepositorio = modelo.tipoarchivorepositorio;
                        entidad.pdfrepositorio = modelo.pdfrepositorio;
                        entidad.estadorepositorio = modelo.estadorepositorio;
                        entidad.isuso = modelo.isuso;
                        entidad.binariorepositorio = modelo.binariorepositorio;
                        entidad.nombrepdf = modelo.nombrepdf;
                        entidad.nombrebinariorepositorio = modelo.nombrebinariorepositorio;
                        entidad.referenciarepositorio = modelo.referenciarepositorio;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.etapapapel = modelo.etapapapel;
                        entidad.descripciondocumento = modelo.documento.descripciondocumento;
                        int i = 1;
                        var listaBitacora = BitacoraModelo.GetAllByTabla("REPOSITORIO");
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
                                entidad.usuariocreo = listaBitacora.Single(x => x.idtransaccionbitacora == entidad.idrepositorio && x.accionbitacora.Contains(etapaBuscada)).inicialesusuariobitacora;
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

        public static ObservableCollection<repositorio> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.repositorios.Where(entidad => (entidad.idencargo == idencargo && entidad.estadorepositorio == "A"));
                    ObservableCollection<repositorio> temporal = new ObservableCollection<repositorio>(lista);
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

        public static bool DeleteByIdEncargoRange(int? idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.repositorios.Where(x => x.estadorepositorio == "A" && x.idpapeles == idpapeles);
                    var lista = (from p in _context.repositorios
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.repositorios.RemoveRange(lista);
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
                    elementos = _context.repositorios.Where(x => x.idrepositorio == id && x.estadorepositorio == "A").Count();
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

        public static int isEditable(int? id)
        {
            int elementos = 0;
            //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
            //NULL => No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
  
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos =(int) _context.repositorios.Single(x => x.idrepositorio == id && x.estadorepositorio == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(RepositorioModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.nombrerepositorio) || string.IsNullOrWhiteSpace(documento.nombrerepositorio))))
            {
                string busqueda = documento.nombrerepositorio.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.repositorios.Where(x => x.nombrerepositorio.ToUpper() == busqueda && x.estadorepositorio == "B" && x.idencargo==documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public RepositorioModelo()
        {
            idrepositorio = 0;
            idpapeles = null;
            idencargo = null;
            iddocumento = null;
            idindice =null;
            nombrerepositorio = string.Empty;
            comentariorepositorio = string.Empty;
            versionrepositorio = 0;
            fechacreadorepositorio = string.Empty;
            tipoarchivorepositorio = string.Empty;
            pdfrepositorio = null;
            isuso = 0;
            binariorepositorio =null;
            nombrepdf = string.Empty;
            nombrebinariorepositorio = string.Empty;
            idgenerico =null;
            tabla = string.Empty;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            estadorepositorio = "A";
            referenciarepositorio = string.Empty;
            guardadoBase = false;
            descripciondocumento = string.Empty;
            IsSelected = false;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
            usuarioModelo = null;
        }
        public RepositorioModelo(EncargoModelo encargo)
        {
            idrepositorio = 0;
            idpapeles = null;
            idencargo = encargo.idencargo;
            iddocumento = null;
            idindice = null;
            nombrerepositorio = string.Empty;
            comentariorepositorio = string.Empty;
            versionrepositorio = 0;
            fechacreadorepositorio = MetodosModelo.homologacionFecha();
            tipoarchivorepositorio = string.Empty;
            pdfrepositorio = null;
            isuso = 0;
            binariorepositorio = null;
            nombrepdf = string.Empty;
            nombrebinariorepositorio = string.Empty;
            idgenerico = null;
            tabla = string.Empty;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            estadorepositorio = "A";
            referenciarepositorio = string.Empty;
            guardadoBase = false;
            descripciondocumento = string.Empty;
            IsSelected = false;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
            usuarioModelo = null;
        }

        internal static int evaluarCerrar(RepositorioModelo currentEntidad)
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

        internal static int evaluarBorrar(RepositorioModelo currentEntidad)
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

        public RepositorioModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idrepositorio = 0;
            idpapeles = null;
            idencargo = encargo.idencargo;
            iddocumento = null;
            idindice = null;
            nombrerepositorio = string.Empty;
            comentariorepositorio = string.Empty;
            versionrepositorio = 1;
            fechacreadorepositorio = MetodosModelo.homologacionFecha();
            tipoarchivorepositorio = string.Empty;
            pdfrepositorio = null;
            isuso = 0;
            binariorepositorio = null;
            nombrepdf = string.Empty;
            nombrebinariorepositorio = string.Empty;
            idgenerico = null;
            tabla = string.Empty;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            estadorepositorio = "A";
            referenciarepositorio = string.Empty;
            guardadoBase = false;
            descripciondocumento = string.Empty;
            IsSelected = false;
            usuarioaprobo = string.Empty;
            fechacierre = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            usuariocerro = string.Empty;
            usuariosuperviso = string.Empty;
            usuarioModelo = usuario;
        }

        public RepositorioModelo(RepositorioModelo modelo, EncargoModelo currentEncargo, UsuarioModelo currentUsuario)
        {
            idrepositorio = modelo.idrepositorio;
            //idpapeles = modelo.idpapeles;
            idencargo = currentEncargo.idencargo;
            iddocumento = modelo.iddocumento;
            //idindice = modelo.idindice;
            nombrerepositorio = modelo.nombrerepositorio;
            comentariorepositorio = modelo.comentariorepositorio;
            versionrepositorio = 1;
            fechacreadorepositorio = MetodosModelo.homologacionFecha();
            tipoarchivorepositorio = modelo.tipoarchivorepositorio;
            pdfrepositorio = modelo.pdfrepositorio;
            estadorepositorio = modelo.estadorepositorio;
            isuso = 0;
            binariorepositorio = modelo.binariorepositorio;
            nombrepdf = modelo.nombrepdf;
            nombrebinariorepositorio = modelo.nombrebinariorepositorio;
            referenciarepositorio = modelo.referenciarepositorio;
            //idgenerico = modelo.idgenerico;
            //tabla = modelo.tabla;
            //usuariocerro = modelo.usuariocerro;
            //usuarioaprobo = modelo.usuarioaprobo;
            //usuariosuperviso = modelo.usuariosuperviso;
            //fechasupervision = modelo.fechasupervision;
            //fechaaprobacion = modelo.fechaaprobacion;
            //fechacierre = modelo.fechacierre;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1); ;
            usuarioModelo = currentUsuario;
        }
    }
    
}
