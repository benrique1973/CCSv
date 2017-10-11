using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Model.Modelo.programas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion;
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

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas
{

    public class CedulaNotasModelo : UIBase
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

        #endregion

        #region  idnotaspt
        public int _idnotaspt;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idnotaspt
        {
            get { return _idnotaspt; }
            set { _idnotaspt = value; }
        }

        #endregion

        #region  idcedula
        public int? _idcedula;
        public int? idcedula
        {
            get { return _idcedula; }
            set { _idcedula = value; }
        }
        #endregion


        #region  idusuariocreador
        public int? _idusuariocreador;
        public int? idusuariocreador
        {
            get { return _idusuariocreador; }
            set { _idusuariocreador = value; }
        }
        #endregion

        [Required(ErrorMessage = "Descripción requerida")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string descripcionnotaspt { get { return GetValue(() => descripcionnotaspt); } set { SetValue(() => descripcionnotaspt, value); } }

        //Almacena la referencia para el  papel de  trabajo
        public string numnotapt
        {
            get { return GetValue(() => numnotapt); }
            set { SetValue(() => numnotapt, value); }
        }

        public string fechacreadonotaspt { get { return GetValue(() => fechacreadonotaspt); } set { SetValue(() => fechacreadonotaspt, value); } }

        public string estadonota
        {
            get { return GetValue(() => estadonota); }
            set { SetValue(() => estadonota, value); }
        }
        public string referenciapapel { get { return GetValue(() => referenciapapel); } set { SetValue(() => referenciapapel, value); } }

        #region  idgenerico
        public int? _idgenerico;
        public int? idgenerico
        {
            get { return _idgenerico; }
            set { _idgenerico = value; }
        }
        #endregion
        #region  tabla
        public string _tabla;
        public string tabla
        {
            get { return _tabla; }
            set { _tabla = value; }
        }
        #endregion

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
        #region  idencargo
        public int? _idencargo;
        public int? idencargo
        {
            get { return _idencargo; }
            set { _idencargo = value; }
        }
        #endregion

        #region  idindice
        public int? _idindice;
        public int? idindice
        {
            get { return _idindice; }
            set { _idindice = value; }
        }
        #endregion
        public string etapapapel
        {
            get { return GetValue(() => etapapapel); }
            set { SetValue(() => etapapapel, value); }
        }


        //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)

        #region  isuso
        public int? _isuso;
        public int? isuso
        {
            get { return _isuso; }
            set { _isuso = value; }
        }
        #endregion

        //Encargo al  que corresponde la evaluacion

        //Para distinguir entre registros ya con  id de la base y registros  pendientes de guardar
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        public string commandButton { get { return GetValue(() => commandButton); } set { SetValue(() => commandButton, value); } }

        public string usuariocreo
        {
            get { return GetValue(() => usuariocreo); }
            set { SetValue(() => usuariocreo, value); }
        }
        public string etapaPapelDescripcion
        {
            get { return GetValue(() => etapaPapelDescripcion); }
            set { SetValue(() => etapaPapelDescripcion, value); }
        }
        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }

        #region colecciones virtuales

        public virtual BitacoraModelo bitacoraModelo
        {
            get { return GetValue(() => bitacoraModelo); }
            set { SetValue(() => bitacoraModelo, value); }
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
        public ObservableCollection<CedulaNotasModelo> listaEntidadSeleccion
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

        public static bool Insert(CedulaNotasModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.notaspt', 'idnotaspt'), (SELECT MAX(idnotaspt) FROM sgpt.notaspt) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new notaspt
                        {
                            idnotaspt = modelo.idnotaspt,
                            descripcionnotaspt = modelo.descripcionnotaspt,
                            fechacreadonotaspt = modelo.fechacreadonotaspt,
                            idusuariocreador = modelo.idusuariocreador,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            estadonota = modelo.estadonota,
                            idencargo = modelo.idencargo,
                            idindice = modelo.idindice,
                            idcedula = modelo.idcedula,
                            referenciapapel = modelo.referenciapapel,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            numnotapt = modelo.numnotapt,
                            isuso = modelo.isuso,
                        };
                        _context.notaspts.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idnotaspt = tablaDestino.idnotaspt;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(1));
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

        public static bool InsertCapaDatos(notaspt modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.notaspt', 'idnotaspt'), (SELECT MAX(idnotaspt) FROM sgpt.notaspt) + 1);");
                            sincronizar = true;
                        }
                        _context.notaspts.Add(modelo);
                        _context.SaveChanges();
                        modelo.idnotaspt = modelo.idnotaspt;
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
        public static int Insert(CedulaNotasModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.notaspt', 'idnotaspt'), (SELECT MAX(idnotaspt) FROM sgpt.notaspt) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new notaspt
                        {
                            //idnotaspt = modelo.idnotaspt,
                            descripcionnotaspt = modelo.descripcionnotaspt,
                            fechacreadonotaspt = modelo.fechacreadonotaspt,
                            idusuariocreador = modelo.idusuariocreador,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            estadonota = modelo.estadonota,
                            idencargo = modelo.idencargo,
                            idindice = modelo.idindice,
                            idcedula = modelo.idcedula,
                            referenciapapel = modelo.referenciapapel,
                            //usuariocerro = modelo.usuariocerro,
                            //usuarioaprobo = modelo.usuarioaprobo,
                            //usuariosuperviso = modelo.usuariosuperviso,
                            //fechasupervision = modelo.fechasupervision,
                            //fechaaprobacion = modelo.fechaaprobacion,
                            //fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            numnotapt = modelo.numnotapt,
                            isuso = modelo.isuso,

                        };
                        _context.notaspts.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idnotaspt = tablaDestino.idnotaspt;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        BitacoraModelo.Insert(temporal, 1);
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


        public static int InsertByRangeByCapadatos(ObservableCollection<notaspt> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.notaspt', 'idnotaspt'), (SELECT MAX(idnotaspt) FROM sgpt.notaspt) + 1);");
                            sincronizar = true;
                        }
                        _context.notaspts.AddRange(lista);
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

        public static CedulaNotasModelo Find(int id)
        {
            var entidad = new CedulaNotasModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //notaspt modelo = _context.notaspts.Find(id);
                        notaspt modelo = _context.notaspts.Single(x => x.idnotaspt == id);
                        if (modelo != null)
                        {
                            entidad.idnotaspt = modelo.idnotaspt;
                            entidad.descripcionnotaspt = modelo.descripcionnotaspt;
                            entidad.fechacreadonotaspt = modelo.fechacreadonotaspt;
                            entidad.idusuariocreador = modelo.idusuariocreador;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.estadonota = modelo.estadonota;
                            entidad.idencargo = modelo.idencargo;
                            entidad.idindice = modelo.idindice;
                            entidad.idcedula = modelo.idcedula;
                            entidad.referenciapapel = modelo.referenciapapel;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.numnotapt = modelo.numnotapt;
                            entidad.isuso = modelo.isuso;

                            return entidad;
                        }
                        else
                        {
                            return new CedulaNotasModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaNotasModelo();
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
                    var modelo = new CedulaNotasModelo();
                    notaspt entidad = _context.notaspts.Find(id);
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
                    var modelo = new CedulaNotasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.notaspts
                            .Where(b => b.estadonota == "B")
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
                    notaspt entidad = _context.notaspts.Find(id);
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

        public static void UpdateModelo(CedulaNotasModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    notaspt entidad = _context.notaspts.Find(modelo.idnotaspt);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idnotaspt != modelo.idnotaspt) { cambiar = true; }
                        if (entidad.descripcionnotaspt != modelo.descripcionnotaspt) { cambiar = true; }
                        //if (entidad.fechacreadonotaspt != modelo.fechacreadonotaspt) { cambiar = true; }
                        //if (entidad.idusuariocreador != modelo.idusuariocreador) { cambiar = true; }
                        if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        //if (entidad.estadonota != modelo.estadonota) { cambiar = true; }
                        //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                        if (entidad.idindice != modelo.idindice) { cambiar = true; }
                        if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                        //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                        if (entidad.numnotapt != modelo.numnotapt) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }

                        if (cambiar)
                        {
                            //entidad.idnotaspt = modelo.idnotaspt;
                            entidad.descripcionnotaspt = modelo.descripcionnotaspt;
                            //entidad.fechacreadonotaspt = modelo.fechacreadonotaspt;
                            entidad.idusuariocreador = modelo.idusuariocreador;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.estadonota = modelo.estadonota;
                            entidad.idencargo = modelo.idencargo;
                            entidad.idindice = modelo.idindice;
                            entidad.idcedula = modelo.idcedula;
                            entidad.referenciapapel = modelo.referenciapapel;
                            //entidad.usuariocerro = modelo.usuariocerro;
                            //entidad.usuarioaprobo = modelo.usuarioaprobo;
                            //entidad.usuariosuperviso = modelo.usuariosuperviso;
                            //entidad.fechasupervision = modelo.fechasupervision;
                            //entidad.fechaaprobacion = modelo.fechaaprobacion;
                            //entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.numnotapt = modelo.numnotapt;
                            entidad.isuso = modelo.isuso;
                            entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2);
                            entidad.isuso = modelo.isuso;
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

        public static int UpdateModelo(CedulaNotasModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        notaspt entidad = _context.notaspts.Find(modelo.idnotaspt);
                        if (entidad == null)
                        {
                            return 1;
                        }
                        else
                        {
                            bool cambiar = false;
                            //if (entidad.idnotaspt != modelo.idnotaspt) { cambiar = true; }
                            if (entidad.descripcionnotaspt != modelo.descripcionnotaspt) { cambiar = true; }
                            //if (entidad.fechacreadonotaspt != modelo.fechacreadonotaspt) { cambiar = true; }
                            //if (entidad.idusuariocreador != modelo.idusuariocreador) { cambiar = true; }
                            if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                            if (entidad.tabla != modelo.tabla) { cambiar = true; }
                            //if (entidad.estadonota != modelo.estadonota) { cambiar = true; }
                            //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            if (entidad.idindice != modelo.idindice) { cambiar = true; }
                            //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                            if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                            //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                            //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                            if (entidad.numnotapt != modelo.numnotapt) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }

                            if (cambiar)
                            {
                                //entidad.idnotaspt = modelo.idnotaspt;
                                entidad.descripcionnotaspt = modelo.descripcionnotaspt;
                                //entidad.fechacreadonotaspt = modelo.fechacreadonotaspt;
                                //entidad.idusuariocreador = modelo.idusuariocreador;
                                entidad.idgenerico = modelo.idgenerico;
                                entidad.tabla = modelo.tabla;
                                entidad.estadonota = modelo.estadonota;
                                //entidad.idencargo = modelo.idencargo;
                                entidad.idindice = modelo.idindice;
                                //entidad.idcedula = modelo.idcedula;
                                entidad.referenciapapel = modelo.referenciapapel;
                                //entidad.usuariocerro = modelo.usuariocerro;
                                //entidad.usuarioaprobo = modelo.usuarioaprobo;
                                //entidad.usuariosuperviso = modelo.usuariosuperviso;
                                //entidad.fechasupervision = modelo.fechasupervision;
                                //entidad.fechaaprobacion = modelo.fechaaprobacion;
                                //entidad.fechacierre = modelo.fechacierre;
                                entidad.numnotapt = modelo.numnotapt;
                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2);
                                entidad.isuso = modelo.isuso;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = "Actualización";
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                    // modelo.listaBitacora.Add(temporal);
                                }
                            }
                        }
                        return 1;
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
        public static bool DeleteBorradoLogico(int id, CedulaNotasModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.notaspt SET estadonota = 'B' WHERE idnotaspt={0};", id);
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

        public static void DeleteBorradoLogicoByidcedula(int idcedula)
        {
            if (!(idcedula == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(idcedula);//Borra todas las referencias dentro  de bitacora
                                                                                        //Inserta registro de borrado
                            #endregion

                            string commandString = String.Format("UPDATE sgpt.notaspt SET estadonota = 'B' WHERE idcedula={0};", idcedula);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro  \n" + e);
                    }
                }
            }
        }

        public static int Delete(ObservableCollection<CedulaNotasModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        notaspt entidadTemporal = new notaspt();
                        string commandString = string.Empty;
                        foreach (CedulaNotasModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idnotaspt);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.notaspt WHERE idnotaspt={0};", item.idnotaspt);
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

        public static int DeleteLogico(ObservableCollection<CedulaNotasModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        notaspt entidadTemporal = new notaspt();
                        string commandString = string.Empty;
                        foreach (CedulaNotasModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idnotaspt);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.notaspt SET estadonota = 'B' WHERE idnotaspt={0};", item.idnotaspt);
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



        public static int Delete(CedulaNotasModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idnotaspt != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.notaspt WHERE idnotaspt={0};", modelo.idnotaspt);
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

        public static int DeleteLogico(CedulaNotasModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idnotaspt != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.notaspt SET estadonota = 'B' WHERE idnotaspt={0};", modelo.idnotaspt);
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

        public static void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(id, "NOTASPT");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.notaspt WHERE idnotaspt={0};", id);
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
        public static void DeleteByidcedula(int idcedula)
        {
            try
            {
                if (idcedula != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(idcedula, "NOTASPT");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.notaspt WHERE idcedula={0};", idcedula);
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
        public static void DeleteByRange(ObservableCollection<notaspt> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.notaspts.RemoveRange(lista);
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

                        //marcasauditoriaMarcasModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.notaspt WHERE idnotaspt={0};", id);
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


        public static int DeleteBorradoLogico(ObservableCollection<CedulaNotasModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    notaspt entidadTemporal = new notaspt();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaNotasModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idnotaspt);//Borra todas las referencias dentro  de bitacora
                                                                                              //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idnotaspt);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.notaspt SET estadonota = 'B' WHERE idnotaspt={0};", item.idnotaspt);
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

        internal static List<CedulaNotasModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idcedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.notaspts.Select(entidad =>
                     new CedulaNotasModelo
                     {
                         idnotaspt = entidad.idnotaspt,
                         descripcionnotaspt = entidad.descripcionnotaspt,
                         fechacreadonotaspt = entidad.fechacreadonotaspt,
                         idusuariocreador = entidad.idusuariocreador,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         estadonota = entidad.estadonota,
                         idencargo = entidad.idencargo,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         numnotapt = entidad.numnotapt,
                         isuso = entidad.isuso,
                         usuariocreo = entidad.usuario.inicialesusuario,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idnotaspt).Where(x => x.estadonota == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idcedula == idcedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaNotasModelo item in lista)
                        {
                            item.etapaPapelDescripcion = EtapaEncargoModelo.descripcionEtapa(item.etapapapel);
                            item.commandButton = CedulaNotasModelo.seleccionCommand(item.etapapapel);
                            //item.usuariocreo = UsuarioModelo.GetInicialesCapaDatosByid((int)item.idusuariocreador);
                            item.idCorrelativo = i;
                            i++;
                        }
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<notaspt> lista, int idnotaspt)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.notaspt SET estadonota = 'B' WHERE idnotaspt = {0};", idnotaspt);
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
        public static explicit operator notaspt(CedulaNotasModelo modelo)  // explicit byte to digit conversion operator
        {
            notaspt entidad = new notaspt();
            entidad.idnotaspt = modelo.idnotaspt;
            entidad.descripcionnotaspt = modelo.descripcionnotaspt;
            entidad.fechacreadonotaspt = modelo.fechacreadonotaspt;
            entidad.idusuariocreador = modelo.idusuariocreador;
            entidad.idgenerico = modelo.idgenerico;
            entidad.tabla = modelo.tabla;
            entidad.estadonota = modelo.estadonota;
            entidad.idencargo = modelo.idencargo;
            entidad.idindice = modelo.idindice;
            entidad.idcedula = modelo.idcedula;
            entidad.referenciapapel = modelo.referenciapapel;
            entidad.usuariocerro = modelo.usuariocerro;
            entidad.usuarioaprobo = modelo.usuarioaprobo;
            entidad.usuariosuperviso = modelo.usuariosuperviso;
            entidad.fechasupervision = modelo.fechasupervision;
            entidad.fechaaprobacion = modelo.fechaaprobacion;
            entidad.fechacierre = modelo.fechacierre;
            entidad.etapapapel = modelo.etapapapel;
            entidad.numnotapt = modelo.numnotapt;
            entidad.isuso = modelo.isuso;
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

                            string commandString = String.Format("DELETE FROM sgpt.notaspt WHERE idnotaspt={0};", id);
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
                        {
                            MessageBox.Show("Exception en borrar registro : " + e.Source);

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

        public static List<CedulaNotasModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.notaspts.Select(entidad =>
                     new CedulaNotasModelo
                     {
                         idnotaspt = entidad.idnotaspt,
                         descripcionnotaspt = entidad.descripcionnotaspt,
                         fechacreadonotaspt = entidad.fechacreadonotaspt,
                         idusuariocreador = entidad.idusuariocreador,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         estadonota = entidad.estadonota,
                         idencargo = entidad.idencargo,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         numnotapt = entidad.numnotapt,
                         isuso = entidad.isuso,
                         usuariocreo=entidad.usuario.inicialesusuario,
                         guardadoBase = true,
                         IsSelected = false,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idnotaspt).Where(x => x.estadonota == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaNotasModelo item in lista)
                        {
                            item.etapaPapelDescripcion = EtapaEncargoModelo.descripcionEtapa(item.etapapapel);
                            item.commandButton = CedulaNotasModelo.seleccionCommand(item.etapapapel);
                            //item.usuariocreo = UsuarioModelo.GetInicialesCapaDatosByid((int)item.idusuariocreador);
                            item.idCorrelativo = i;
                            i++;
                        }
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

        internal static int UpdateCierre(CedulaNotasModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idnotaspt;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.notaspt SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idnotaspt = {3};",
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

        internal static int UpdateReferencia(CedulaNotasModelo modelo)
        {
            int id = modelo.idnotaspt;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.notaspt SET numnotapt = '{0}',etapapapel ='{1}' WHERE idnotaspt={2};", modelo.numnotapt, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(CedulaNotasModelo modelo)
        {
            int id = modelo.idnotaspt;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.notaspt SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idnotaspt = {3};",
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

        internal static int UpdateAprobacion(CedulaNotasModelo modelo)
        {
            int id = modelo.idnotaspt;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.notaspt SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idnotaspt = {3};",
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

        internal static int UpdateAprobacionSupervision(CedulaNotasModelo modelo)
        {
            int id = modelo.idnotaspt;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "NOTASPT", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.notaspt SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idnotaspt = {5};",
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

        public static ObservableCollection<CedulaNotasModelo> GetAllEdicion(EncargoModelo encargo, int idcedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.notaspts.Select(entidad =>
                     new CedulaNotasModelo
                     {
                         idnotaspt = entidad.idnotaspt,
                         descripcionnotaspt = entidad.descripcionnotaspt,
                         fechacreadonotaspt = entidad.fechacreadonotaspt,
                         idusuariocreador = entidad.idusuariocreador,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         estadonota = entidad.estadonota,
                         idencargo = entidad.idencargo,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         numnotapt = entidad.numnotapt,
                         isuso = entidad.isuso,
                         usuariocreo = entidad.usuario.inicialesusuario,
                         guardadoBase = true,
                         IsSelected = false,
                         
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idnotaspt).Where(x => x.estadonota == "A" && x.idencargo == encargo.idencargo && x.idcedula == idcedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    string referencia;
                    foreach (CedulaNotasModelo item in lista)
                    {
                        if (item.tabla != null && item.idgenerico != null && item.idgenerico != 0)
                        {
                            //Actualizar referencias
                            referencia = UniversalPTModelo.GetReferencia(item.tabla, item.idgenerico);
                            if (referencia == "-1")
                            {
                                item.referenciapapel = "Error";
                                item.referenciapapel = "Error";
                                //Limpia la referencia
                                item.referenciapapel = string.Empty;
                                item.idgenerico = null;
                                item.tabla = string.Empty;
                                //No se identifica el papel origen se elimina la  refencia que genera error
                                BorrarModeloReferencia(item);
                            }
                            else
                            {
                                if (item.referenciapapel == referencia)
                                {
                                    item.referenciapapel = referencia;
                                }
                                else
                                {
                                    //Asignarlo y guardarlo
                                    item.referenciapapel = referencia;
                                    if (!UpdateModeloReferencia(item, referencia))
                                    {
                                        MessageBox.Show("Error en actualizar referencia");
                                    }
                                }
                            }
                        }
                        item.etapaPapelDescripcion = EtapaEncargoModelo.descripcionEtapa(item.etapapapel);
                        item.commandButton = CedulaNotasModelo.seleccionCommand(item.etapaPapelDescripcion);
                        //item.usuariocreo = UsuarioModelo.GetInicialesCapaDatosByid((int)item.idusuariocreador);
                        item.idCorrelativo = i;
                        i++;
                    }
                    return new ObservableCollection<CedulaNotasModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaNotasModelo>();
            }
        }

        public static bool UpdateModeloReferencia(CedulaNotasModelo modelo, string referencia)
        {
            if ((modelo != null && modelo.idnotaspt != 0 && referencia != null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (string.IsNullOrEmpty(referencia))
                        {
                            modelo.referenciapapel = "Pendiente";
                        }
                        string commandString = String.Format("UPDATE sgpt.notaspt SET referenciapapel='{0}' WHERE idnotaspt={1};",
                            referencia,
                            modelo.idnotaspt);
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
                    MessageBox.Show("exception en actualizar referencia: \n" + e);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static void BorrarModeloReferencia(CedulaNotasModelo modelo)
        {
            if ((modelo != null && modelo.idnotaspt != 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.notaspt  SET tabla = '',idgenerico=null,referenciapapel='' WHERE idnotaspt={0};",
                            modelo.idnotaspt);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        //_context.Entry(entidad).State = EntityState.Modified;
                        //    _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.referenciapapel = string.Empty;
                        //Reordenar((int)modelo.iddp);
                        //}
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("exception en actualizar referencia: \n" + e);
                }
            }
        }

        internal static CedulaNotasModelo GetRegistro(int idnotaspt)
        {
            var entidad = new CedulaNotasModelo();
            if (!(idnotaspt == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    notaspt modelo = _context.notaspts.Find(idnotaspt);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idnotaspt = modelo.idnotaspt;
                        entidad.descripcionnotaspt = modelo.descripcionnotaspt;
                        entidad.fechacreadonotaspt = modelo.fechacreadonotaspt;
                        entidad.idusuariocreador = modelo.idusuariocreador;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.estadonota = modelo.estadonota;
                        entidad.idencargo = modelo.idencargo;
                        entidad.idindice = modelo.idindice;
                        entidad.idcedula = modelo.idcedula;
                        entidad.referenciapapel = modelo.referenciapapel;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.etapapapel = modelo.etapapapel;
                        entidad.numnotapt = modelo.numnotapt;
                        entidad.isuso = modelo.isuso;
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        return entidad;
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

        public static ObservableCollection<notaspt> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.notaspts.Where(entidad => (entidad.idencargo == idencargo && entidad.estadonota == "A"));
                    ObservableCollection<notaspt> temporal = new ObservableCollection<notaspt>(lista);
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
                    //var lista = _context.notaspts.Where(x => x.estadonota == "A" && x.idcedula == idcedula);
                    var lista = (from p in _context.notaspts
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.notaspts.RemoveRange(lista);
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
                    elementos = _context.notaspts.Where(x => x.idnotaspt == id && x.estadonota == "A").Count();
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
                    elementos = (int)_context.notaspts.Single(x => x.idnotaspt == id && x.estadonota == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(CedulaNotasModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.descripcionnotaspt) || string.IsNullOrWhiteSpace(documento.descripcionnotaspt))))
            {
                string busqueda = documento.descripcionnotaspt.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.notaspts.Where(x => x.descripcionnotaspt.ToUpper() == busqueda && x.estadonota == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public CedulaNotasModelo()
        {
            idnotaspt = 0;
            descripcionnotaspt = string.Empty;
            fechacreadonotaspt = MetodosModelo.homologacionFecha();
            idusuariocreador = null;
            idgenerico = null;
            tabla = null;
            estadonota = "A";
            idencargo = null;
            idindice = null;
            idcedula = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            numnotapt = null;
            isuso = null;


            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
        }
        public CedulaNotasModelo(EncargoModelo encargo)
        {
            idnotaspt = 0;
            descripcionnotaspt = string.Empty;
            fechacreadonotaspt = MetodosModelo.homologacionFecha();
            idusuariocreador = null;
            idgenerico = null;
            tabla = null;
            estadonota = "A";
            idencargo = encargo.idencargo;
            idindice = null;
            idcedula = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            numnotapt = null;
            isuso = null;


            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
        }

        internal static int evaluarCerrar(CedulaNotasModelo currentEntidad)
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

        internal static int evaluarBorrar(CedulaNotasModelo currentEntidad)
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

        public CedulaNotasModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idnotaspt = 0;
            descripcionnotaspt = string.Empty;
            fechacreadonotaspt = MetodosModelo.homologacionFecha();
            idusuariocreador = usuario.idUsuario;
            idgenerico = null;
            tabla = null;
            estadonota = "A";
            idencargo = encargo.idencargo;
            idindice = null;
            idcedula = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            numnotapt = null;
            isuso = null;


            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
        }

        public CedulaNotasModelo(CedulaModelo currentMaestro, EncargoModelo encargo, UsuarioModelo usuario)
        {
            idnotaspt = 0;
            descripcionnotaspt = string.Empty;
            fechacreadonotaspt = MetodosModelo.homologacionFecha();
            idusuariocreador = usuario.idUsuario;
            idgenerico = null;
            tabla = null;
            estadonota = "A";
            idencargo = encargo.idencargo;
            idindice = null;
            idcedula = currentMaestro.idcedula;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            numnotapt = null;
            isuso = null;


            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
        }

        public static string indice(int n)
        {
            string respuesta = string.Empty;
            int r = n % 26;
            int z = n / 26;
                switch (z)
                {
                    case 0:
                    respuesta= char.ConvertFromUtf32(r + 96);
                    break;
                    default:
                    respuesta = indice(r) + indice(z);
                    //Llega hasta zz;
                    break;
                }
                return respuesta;
        }

        public static string seleccionCommand(string etapa)
        {
            string comando = string.Empty;
            switch (etapa)
            {
                case "Inicial":
                    comando = "Cerrar";
                    break;
                case "En proceso":
                    comando = "Cerrar";
                    break;
                case "Revisado":
                    comando = "Aprobar";
                    break;
                case "Cerrado":
                    comando = "Revisado";
                    break;
                case "Ejecutado":
                    comando = "Cerrar";
                    break;
                case "Aprobado":
                    comando = string.Empty;
                    break;
                case "Terminado":
                    comando = "Cerrar";
                    break;
                case "Borrado":
                    comando = string.Empty;
                    break;
                case "Error en registro":
                    break;
            }
            return comando;
        }

    }

}
