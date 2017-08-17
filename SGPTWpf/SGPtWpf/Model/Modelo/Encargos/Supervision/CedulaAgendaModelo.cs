using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas;
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

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Supervision
{

    public class CedulaAgendaModelo : UIBase
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

        #region  idagenda
        public int _idagenda;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idagenda
        {
            get { return _idagenda; }
            set { _idagenda = value; }
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

        public string fechacreadoagenda { get { return GetValue(() => fechacreadoagenda); } set { SetValue(() => fechacreadoagenda, value); } }

        public string fechaterminacionagenda { get { return GetValue(() => fechaterminacionagenda); } set { SetValue(() => fechaterminacionagenda, value); } }

        public string fecharevisionagenda { get { return GetValue(() => fecharevisionagenda); } set { SetValue(() => fecharevisionagenda, value); } }

        public string fechaaprobacionagenda { get { return GetValue(() => fechaaprobacionagenda); } set { SetValue(() => fechaaprobacionagenda, value); } }

        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(50, ErrorMessage = "No debe de exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string encabezadoagenda { get { return GetValue(() => encabezadoagenda); } set { SetValue(() => encabezadoagenda, value); } }

        public string padreencabezadoagenda { get { return GetValue(() => padreencabezadoagenda); } set { SetValue(() => padreencabezadoagenda, value); } }


        [Required(ErrorMessage = "Debe incluir la descripción de la asignación")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string descripcionagenda { get { return GetValue(() => descripcionagenda); } set { SetValue(() => descripcionagenda, value); } }

       
        public string referenciahallazgo
        {
            get { return GetValue(() => referenciahallazgo); }
            set { SetValue(() => referenciahallazgo, value); }
        }

        public string estadoprocesoagenda
        {
            get { return GetValue(() => estadoprocesoagenda); }
            set { SetValue(() => estadoprocesoagenda, value); }
        }


        //[Required(ErrorMessage = "Debe explicar  el trabajo realizado")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string comentariorespuestaagenda { get { return GetValue(() => comentariorespuestaagenda); } set { SetValue(() => comentariorespuestaagenda, value); } }


        public string estadoagenda { get { return GetValue(() => estadoagenda); } set { SetValue(() => estadoagenda, value); } }


        #region  isuso
        public int? _isuso;
        public int? isuso
        {
            get { return _isuso; }
            set { _isuso = value; }
        }
        #endregion

        #region  idencargo
        public int? _idencargo;
        public int? idencargo
        {
            get { return _idencargo; }
            set { _idencargo = value; }
        }
        #endregion

        #region  idusuarioasigna
        public int? _idusuarioasigna;
        public int? idusuarioasigna
        {
            get { return _idusuarioasigna; }
            set { _idusuarioasigna = value; }
        }

        #endregion


        #region  idusuarioresponable
        public int? _idusuarioresponable;
        public int? idusuarioresponable
        {
            get { return _idusuarioresponable; }
            set { _idusuarioresponable = value; }
        }
        #endregion

        #region  padreidagenda
        public int? _padreidagenda;
        public int? padreidagenda
        {
            get { return _padreidagenda; }
            set { _padreidagenda = value; }
        }
        #endregion


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

        public string referenciapapel { get { return GetValue(() => referenciapapel); } set { SetValue(() => referenciapapel, value); } }



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

        //Se usará para almacenar al  usuario  que asigno
        public string usuariocerro
        {
            get { return GetValue(() => usuariocerro); }
            set { SetValue(() => usuariocerro, value); }
        }
        //Se usara para la fecha de asignacion
        public string fechacierre
        {
            get { return GetValue(() => fechacierre); }
            set { SetValue(() => fechacierre, value); }
        }
        //Se usara para usuario  responsable
        public string fechasupervision
        {
            get { return GetValue(() => fechasupervision); }
            set { SetValue(() => fechasupervision, value); }
        }
        //Para registrar fecha de terminacion
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
        public ObservableCollection<CedulaAgendaModelo> listaEntidadSeleccion
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

        public static bool Insert(CedulaAgendaModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.agendas', 'idagenda'), (SELECT MAX(idagenda) FROM sgpt.agendas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new agenda
                        {
                            //idagenda = modelo.idagenda,
                            idcedula = modelo.idcedula,
                            fechacreadoagenda = modelo.fechacreadoagenda,
                            fechaterminacionagenda = modelo.fechaterminacionagenda,
                            fecharevisionagenda = modelo.fecharevisionagenda,
                            fechaaprobacionagenda = modelo.fechaaprobacionagenda,
                            encabezadoagenda = modelo.encabezadoagenda,
                            descripcionagenda = modelo.descripcionagenda,
                            estadoprocesoagenda = conversionIniciales(modelo.estadoprocesoagenda),
                            comentariorespuestaagenda = modelo.comentariorespuestaagenda,
                            estadoagenda = modelo.estadoagenda,
                            isuso = modelo.isuso,
                            idencargo = modelo.idencargo,
                            idusuarioasigna = modelo.idusuarioasigna,
                            idusuarioresponable = modelo.idusuarioresponable,
                            padreidagenda = modelo.padreidagenda,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            referenciapapel = modelo.referenciapapel,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,


                        };
                        _context.agendas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idagenda = tablaDestino.idagenda;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(1));
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

        public static bool InsertCapaDatos(agenda modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.agendas', 'idagenda'), (SELECT MAX(idagenda) FROM sgpt.agendas) + 1);");
                            sincronizar = true;
                        }
                        _context.agendas.Add(modelo);
                        _context.SaveChanges();
                        modelo.idagenda = modelo.idagenda;
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
        public static int Insert(CedulaAgendaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.agendas', 'idagenda'), (SELECT MAX(idagenda) FROM sgpt.agendas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new agenda
                        {
                            //idagenda = modelo.idagenda,
                            idcedula = modelo.idcedula,
                            fechacreadoagenda = modelo.fechacreadoagenda,
                            //fechaterminacionagenda = modelo.fechaterminacionagenda,
                            //fecharevisionagenda = modelo.fecharevisionagenda,
                            //fechaaprobacionagenda = modelo.fechaaprobacionagenda,
                            encabezadoagenda = modelo.encabezadoagenda,
                            descripcionagenda = modelo.descripcionagenda,
                            estadoprocesoagenda = conversionIniciales(modelo.estadoprocesoagenda),
                            //comentariorespuestaagenda = modelo.comentariorespuestaagenda,
                            estadoagenda = modelo.estadoagenda,
                            isuso = modelo.isuso,
                            idencargo = modelo.idencargo,
                            idusuarioasigna = modelo.idusuarioasigna,
                            idusuarioresponable = modelo.idusuarioresponable,
                            padreidagenda = modelo.padreidagenda,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            referenciapapel = modelo.referenciapapel,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,


                        };
                        _context.agendas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idagenda = tablaDestino.idagenda;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(1));
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


        public static int InsertByRangeByCapadatos(ObservableCollection<agenda> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.agendas', 'idagenda'), (SELECT MAX(idagenda) FROM sgpt.agendas) + 1);");
                            sincronizar = true;
                        }
                        _context.agendas.AddRange(lista);
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

        public static CedulaAgendaModelo Find(int id)
        {
            var entidad = new CedulaAgendaModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //agenda modelo = _context.agendas.Find(id);
                        agenda modelo = _context.agendas.Single(x => x.idagenda == id);
                        if (modelo != null)
                        {
                            entidad.idagenda = modelo.idagenda;
                            entidad.idcedula = modelo.idcedula;
                            entidad.fechacreadoagenda = modelo.fechacreadoagenda;
                            entidad.fechaterminacionagenda = modelo.fechaterminacionagenda;
                            entidad.fecharevisionagenda = modelo.fecharevisionagenda;
                            entidad.fechaaprobacionagenda = modelo.fechaaprobacionagenda;
                            entidad.encabezadoagenda = modelo.encabezadoagenda;
                            entidad.descripcionagenda = modelo.descripcionagenda;
                            entidad.estadoprocesoagenda = modelo.estadoprocesoagenda;
                            entidad.comentariorespuestaagenda = modelo.comentariorespuestaagenda;
                            entidad.estadoagenda = modelo.estadoagenda;
                            entidad.isuso = modelo.isuso;
                            entidad.idencargo = modelo.idencargo;
                            entidad.idusuarioasigna = modelo.idusuarioasigna;
                            entidad.idusuarioresponable = modelo.idusuarioresponable;
                            entidad.padreidagenda = modelo.padreidagenda;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.referenciapapel = modelo.referenciapapel;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.IsSelected = false;
                            entidad.guardadoBase = true;
                            if (modelo.padreidagenda != null && modelo.padreidagenda != 0)
                            {
                                entidad.padreencabezadoagenda = modelo.agenda1.encabezadoagenda;
                            }
                            return entidad;
                        }
                        else
                        {
                            return new CedulaAgendaModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaAgendaModelo();
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
                    var modelo = new CedulaAgendaModelo();
                    agenda entidad = _context.agendas.Find(id);
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
                    var modelo = new CedulaAgendaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.agendas
                            .Where(b => b.estadoagenda == "B")
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
                    agenda entidad = _context.agendas.Find(id);
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

        public static void UpdateModelo(CedulaAgendaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    agenda entidad = _context.agendas.Find(modelo.idagenda);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idagenda != modelo.idagenda) { cambiar = true; }
                        if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        if (entidad.fechacreadoagenda != modelo.fechacreadoagenda) { cambiar = true; }
                        if (entidad.fechaterminacionagenda != modelo.fechaterminacionagenda) { cambiar = true; }
                        if (entidad.fecharevisionagenda != modelo.fecharevisionagenda) { cambiar = true; }
                        if (entidad.fechaaprobacionagenda != modelo.fechaaprobacionagenda) { cambiar = true; }
                        if (entidad.encabezadoagenda != modelo.encabezadoagenda) { cambiar = true; }
                        if (entidad.descripcionagenda != modelo.descripcionagenda) { cambiar = true; }
                        //if (entidad.estadoprocesoagenda != modelo.estadoprocesoagenda) { cambiar = true; }
                        if (entidad.comentariorespuestaagenda != modelo.comentariorespuestaagenda) { cambiar = true; }
                        if (entidad.estadoagenda != modelo.estadoagenda) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }
                        //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                        if (entidad.idusuarioasigna != modelo.idusuarioasigna) { cambiar = true; }
                        if (entidad.idusuarioresponable != modelo.idusuarioresponable) { cambiar = true; }
                        if (entidad.padreidagenda != modelo.padreidagenda) { cambiar = true; }
                        //if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        //if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        //if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                        //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        //if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }

                        if (cambiar)
                        {
                            //entidad.idagenda = modelo.idagenda;
                            //entidad.idcedula = modelo.idcedula;
                            entidad.fechacreadoagenda = modelo.fechacreadoagenda;
                            entidad.fechaterminacionagenda = modelo.fechaterminacionagenda;
                            entidad.fecharevisionagenda = modelo.fecharevisionagenda;
                            entidad.fechaaprobacionagenda = modelo.fechaaprobacionagenda;
                            entidad.encabezadoagenda = modelo.encabezadoagenda;
                            entidad.descripcionagenda = modelo.descripcionagenda;
                            entidad.estadoprocesoagenda = conversionIniciales(modelo.estadoprocesoagenda);
                            entidad.comentariorespuestaagenda = modelo.comentariorespuestaagenda;
                            entidad.estadoagenda = modelo.estadoagenda;
                            entidad.isuso = modelo.isuso;
                            entidad.idencargo = modelo.idencargo;
                            entidad.idusuarioasigna = modelo.idusuarioasigna;
                            entidad.idusuarioresponable = modelo.idusuarioresponable;
                            entidad.padreidagenda = modelo.padreidagenda;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            //entidad.referenciapapel = modelo.referenciapapel;
                            //entidad.usuariocerro = modelo.usuariocerro;
                            //entidad.usuarioaprobo = modelo.usuarioaprobo;
                            //entidad.usuariosuperviso = modelo.usuariosuperviso;
                            //entidad.fechasupervision = modelo.fechasupervision;
                            //entidad.fechaaprobacion = modelo.fechaaprobacion;
                            //entidad.fechacierre = modelo.fechacierre;
                            //entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                            entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
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

        public static int UpdateModelo(CedulaAgendaModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        agenda entidad = _context.agendas.Find(modelo.idagenda);
                        if (entidad == null)
                        {
                            return 1;
                        }
                        else
                        {
                            bool cambiar = false;
                            //if (entidad.idagenda != modelo.idagenda) { cambiar = true; }
                            if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                            if (entidad.fechacreadoagenda != modelo.fechacreadoagenda) { cambiar = true; }
                            if (entidad.fechaterminacionagenda != modelo.fechaterminacionagenda) { cambiar = true; }
                            if (entidad.fecharevisionagenda != modelo.fecharevisionagenda) { cambiar = true; }
                            if (entidad.fechaaprobacionagenda != modelo.fechaaprobacionagenda) { cambiar = true; }
                            if (entidad.encabezadoagenda != modelo.encabezadoagenda) { cambiar = true; }
                            if (entidad.descripcionagenda != modelo.descripcionagenda) { cambiar = true; }
                            //if (entidad.estadoprocesoagenda != modelo.estadoprocesoagenda) { cambiar = true; }
                            if (entidad.comentariorespuestaagenda != modelo.comentariorespuestaagenda) { cambiar = true; }
                            if (entidad.estadoagenda != modelo.estadoagenda) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            if (entidad.idusuarioasigna != modelo.idusuarioasigna) { cambiar = true; }
                            if (entidad.idusuarioresponable != modelo.idusuarioresponable) { cambiar = true; }
                            if (entidad.padreidagenda != modelo.padreidagenda) { cambiar = true; }
                            //if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                            //if (entidad.tabla != modelo.tabla) { cambiar = true; }
                            //if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                            if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                            if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }

                            if (cambiar)
                            {
                                //entidad.idagenda = modelo.idagenda;
                                //entidad.idcedula = modelo.idcedula;
                                entidad.fechacreadoagenda = modelo.fechacreadoagenda;
                                entidad.fechaterminacionagenda = modelo.fechaterminacionagenda;
                                entidad.fecharevisionagenda = modelo.fecharevisionagenda;
                                entidad.fechaaprobacionagenda = modelo.fechaaprobacionagenda;
                                entidad.encabezadoagenda = modelo.encabezadoagenda;
                                entidad.descripcionagenda = modelo.descripcionagenda;
                                //entidad.estadoprocesoagenda = conversionIniciales(modelo.estadoprocesoagenda);
                                entidad.comentariorespuestaagenda = modelo.comentariorespuestaagenda;
                                entidad.estadoagenda = modelo.estadoagenda;
                                entidad.isuso = modelo.isuso;
                                entidad.idencargo = modelo.idencargo;
                                entidad.idusuarioasigna = modelo.idusuarioasigna;
                                entidad.idusuarioresponable = modelo.idusuarioresponable;
                                entidad.padreidagenda = modelo.padreidagenda;
                                entidad.idgenerico = modelo.idgenerico;
                                entidad.tabla = modelo.tabla;
                                entidad.referenciapapel = modelo.referenciapapel;
                                entidad.usuariocerro = modelo.usuariocerro;
                                entidad.usuarioaprobo = modelo.usuarioaprobo;
                                entidad.usuariosuperviso = modelo.usuariosuperviso;
                                entidad.fechasupervision = modelo.fechasupervision;
                                entidad.fechaaprobacion = modelo.fechaaprobacion;
                                entidad.fechacierre = modelo.fechacierre;
                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(2));
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
        public static bool DeleteBorradoLogico(int id, CedulaAgendaModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET estadoagenda = 'B' WHERE idagenda={0};", id);
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

 
        public static void DeleteBorradoLogicoByIdCedula(int idCedula)
        {
            if (!(idCedula == 0))
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(idCedula);//Borra todas las referencias dentro  de bitacora
                                                                                        //Inserta registro de borrado
                            #endregion

                            string commandString = String.Format("UPDATE sgpt.agendas SET estadoagenda = 'B' WHERE idcedula={0};", idCedula);
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

        public static int Delete(ObservableCollection<CedulaAgendaModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        agenda entidadTemporal = new agenda();
                        string commandString = string.Empty;
                        foreach (CedulaAgendaModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idagenda);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.agendas WHERE idagenda={0};", item.idagenda);
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

        public static int DeleteLogico(ObservableCollection<CedulaAgendaModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        agenda entidadTemporal = new agenda();
                        string commandString = string.Empty;
                        foreach (CedulaAgendaModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idagenda);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.agendas SET estadoagenda = 'B' WHERE idagenda={0};", item.idagenda);
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



        public static int Delete(CedulaAgendaModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idagenda != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.agendas WHERE idagenda={0};", modelo.idagenda);
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

        public static int DeleteLogico(CedulaAgendaModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idagenda != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.agendas SET estadoagenda = 'B' WHERE idagenda={0};", modelo.idagenda);
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
                        BitacoraModelo.DeleteByTransaccion(id, "AGENDAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.agendas WHERE idagenda={0};", id);
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
        public static void DeleteByIdCedula(int idCedula)
        {
            try
            {
                if (idCedula != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Borrado de bitacora
                        BitacoraModelo.DeleteByTransaccion(idCedula, "AGENDAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.agendas WHERE idcedula={0};", idCedula);
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
        public static void DeleteByRange(ObservableCollection<agenda> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.agendas.RemoveRange(lista);
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
                        string commandString = String.Format("DELETE FROM sgpt.agendas WHERE idagenda={0};", id);
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


        public static int DeleteBorradoLogico(ObservableCollection<CedulaAgendaModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    agenda entidadTemporal = new agenda();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaAgendaModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idagenda);//Borra todas las referencias dentro  de bitacora
                                                                                               //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idagenda);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.agendas SET estadoagenda = 'B' WHERE idagenda={0};", item.idagenda);
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

        internal static List<CedulaAgendaModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idcedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.agendas.Select(entidad =>
                     new CedulaAgendaModelo
                     {
                         idagenda = entidad.idagenda,
                         idcedula = entidad.idcedula,
                         fechacreadoagenda = entidad.fechacreadoagenda,
                         fechaterminacionagenda = entidad.fechaterminacionagenda,
                         fecharevisionagenda = entidad.fecharevisionagenda,
                         fechaaprobacionagenda = entidad.fechaaprobacionagenda,
                         encabezadoagenda = entidad.encabezadoagenda,
                         descripcionagenda = entidad.descripcionagenda,
                         estadoprocesoagenda = entidad.estadoprocesoagenda,
                         comentariorespuestaagenda = entidad.comentariorespuestaagenda,
                         estadoagenda = entidad.estadoagenda,
                         isuso = entidad.isuso,
                         idencargo = entidad.idencargo,
                         idusuarioasigna = entidad.idusuarioasigna,
                         idusuarioresponable = entidad.idusuarioresponable,
                         padreidagenda = entidad.padreidagenda,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,


                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idagenda).Where(x => x.estadoagenda == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idcedula == idcedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaAgendaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.estadoprocesoagenda = conversion(item.estadoprocesoagenda);
                            if (item.padreidagenda != null && item.padreidagenda != 0)
                            {
                                item.padreencabezadoagenda = lista.SingleOrDefault(x => x.idagenda == item.padreidagenda).encabezadoagenda;
                            }
                            //item.guardadoBase = true;
                            //item.IsSelected = false;
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<agenda> lista, int idagenda)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.agendas SET estadoagenda = 'B' WHERE idagenda = {0};", idagenda);
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
        public static explicit operator agenda(CedulaAgendaModelo modelo)  // explicit byte to digit conversion operator
        {
            agenda entidad = new agenda();
            entidad.idagenda = modelo.idagenda;
            entidad.idcedula = modelo.idcedula;
            entidad.fechacreadoagenda = modelo.fechacreadoagenda;
            entidad.fechaterminacionagenda = modelo.fechaterminacionagenda;
            entidad.fecharevisionagenda = modelo.fecharevisionagenda;
            entidad.fechaaprobacionagenda = modelo.fechaaprobacionagenda;
            entidad.encabezadoagenda = modelo.encabezadoagenda;
            entidad.descripcionagenda = modelo.descripcionagenda;
            entidad.estadoprocesoagenda = modelo.estadoprocesoagenda;
            entidad.comentariorespuestaagenda = modelo.comentariorespuestaagenda;
            entidad.estadoagenda = modelo.estadoagenda;
            entidad.isuso = modelo.isuso;
            entidad.idencargo = modelo.idencargo;
            entidad.idusuarioasigna = modelo.idusuarioasigna;
            entidad.idusuarioresponable = modelo.idusuarioresponable;
            entidad.padreidagenda = modelo.padreidagenda;
            entidad.idgenerico = modelo.idgenerico;
            entidad.tabla = modelo.tabla;
            entidad.referenciapapel = modelo.referenciapapel;
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

                            string commandString = String.Format("DELETE FROM sgpt.agendas WHERE idagenda={0};", id);
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

        public static List<CedulaAgendaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.agendas.Select(entidad =>
                     new CedulaAgendaModelo
                     {
                         idagenda = entidad.idagenda,
                         idcedula = entidad.idcedula,
                         fechacreadoagenda = entidad.fechacreadoagenda,
                         fechaterminacionagenda = entidad.fechaterminacionagenda,
                         fecharevisionagenda = entidad.fecharevisionagenda,
                         fechaaprobacionagenda = entidad.fechaaprobacionagenda,
                         encabezadoagenda = entidad.encabezadoagenda,
                         descripcionagenda = entidad.descripcionagenda,
                         estadoprocesoagenda = entidad.estadoprocesoagenda,
                         comentariorespuestaagenda = entidad.comentariorespuestaagenda,
                         estadoagenda = entidad.estadoagenda,
                         isuso = entidad.isuso,
                         idencargo = entidad.idencargo,
                         idusuarioasigna = entidad.idusuarioasigna,
                         idusuarioresponable = entidad.idusuarioresponable,
                         padreidagenda = entidad.padreidagenda,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,

                         guardadoBase = true,
                         IsSelected = false,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idagenda).Where(x => x.estadoagenda == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaAgendaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.estadoprocesoagenda = conversion(item.estadoprocesoagenda);
                            if (item.padreidagenda != null && item.padreidagenda != 0)
                            {
                                item.padreencabezadoagenda = lista.SingleOrDefault(x => x.idagenda == item.padreidagenda).encabezadoagenda;
                            }
                            //item.guardadoBase = true;
                            //item.IsSelected = false;
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

        internal static int UpdateCierre(CedulaAgendaModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idagenda;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idagenda = {3};",
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

        internal static int AprobatTarea(CedulaAgendaModelo modelo, UsuarioModelo usuarioModelo)
        {
                int id = modelo.idagenda;
                int result = 0;
                if (!(id == 0))
                {
                    {
                        try
                        {
                            using (_context = new SGPTEntidades())
                            {
                            #region bitacora
                                modelo.usuarioModelo = usuarioModelo;
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(6));
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                }

                                #endregion

                                string commandString = String.Format("UPDATE sgpt.agendas SET usuarioaprobo = '{0}',fechacierre = '{1}', etapapapel='{2}',fechaaprobacionagenda='{3}',estadoprocesoagenda='{4}'  WHERE idagenda = {5};",
                                    usuarioModelo.inicialesusuario,
                                    MetodosModelo.homologacionFecha(),
                                    EtapaEncargoModelo.seleccionEtapaIniciales(6),
                                    MetodosModelo.homologacionFecha(),
                                    "T",
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

        internal static int UpdateReferencia(CedulaAgendaModelo modelo)
        {
            int id = modelo.idagenda;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET referenciahallazgo = '{0}',etapapapel ='{1}' WHERE idagenda={2};", modelo.referenciahallazgo, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(CedulaAgendaModelo modelo)
        {
            int id = modelo.idagenda;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idagenda = {3};",
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
        internal static int UpdateResponder(CedulaAgendaModelo modelo)
        {
            int id = modelo.idagenda;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET comentariorespuestaagenda='{0}', usuariosuperviso = '{1}',fechaterminacionagenda = '{2}',fechasupervision = '{3}',etapapapel ='{4}',estadoprocesoagenda='{5}' WHERE idagenda = {6};",
                                modelo.comentariorespuestaagenda,
                                modelo.usuarioModelo.inicialesusuario,
                                MetodosModelo.homologacionFecha(),//Fecha de  supervision
                                MetodosModelo.homologacionFecha(),//Fecha de respuesta
                                EtapaEncargoModelo.seleccionEtapaIniciales(3),
                                "R",
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

        internal static int UpdateAprobacion(CedulaAgendaModelo modelo)
        {
            int id = modelo.idagenda;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idagenda = {3};",
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

        internal static int UpdateAprobacionSupervision(CedulaAgendaModelo modelo)
        {
            int id = modelo.idagenda;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "AGENDAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.agendas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idagenda = {5};",
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

        public static ObservableCollection<CedulaAgendaModelo> GetAllEdicion(EncargoModelo encargo, int idCedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.agendas.Select(entidad =>
                     new CedulaAgendaModelo
                     {
                         idagenda = entidad.idagenda,
                         idcedula = entidad.idcedula,
                         fechacreadoagenda = entidad.fechacreadoagenda,
                         fechaterminacionagenda = entidad.fechaterminacionagenda,
                         fecharevisionagenda = entidad.fecharevisionagenda,
                         fechaaprobacionagenda = entidad.fechaaprobacionagenda,
                         encabezadoagenda = entidad.encabezadoagenda,
                         descripcionagenda = entidad.descripcionagenda,
                         estadoprocesoagenda = entidad.estadoprocesoagenda,
                         comentariorespuestaagenda = entidad.comentariorespuestaagenda,
                         estadoagenda = entidad.estadoagenda,
                         isuso = entidad.isuso,
                         idencargo = entidad.idencargo,
                         idusuarioasigna = entidad.idusuarioasigna,
                         idusuarioresponable = entidad.idusuarioresponable,
                         padreidagenda = entidad.padreidagenda,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,

                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idagenda).Where(x => x.estadoagenda == "A" && x.idencargo == encargo.idencargo && x.idcedula == idCedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaAgendaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.estadoprocesoagenda = conversion(item.estadoprocesoagenda);
                        if (item.padreidagenda != null && item.padreidagenda != 0)
                        {
                            item.padreencabezadoagenda = lista.SingleOrDefault(x => x.idagenda == item.padreidagenda).encabezadoagenda;
                        }
                    }
                    return new ObservableCollection<CedulaAgendaModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaAgendaModelo>();
            }
        }
        public static ObservableCollection<CedulaAgendaModelo> GetAllEdicionByUsuario(EncargoModelo encargo, int idCedula,int idUsuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.agendas.Select(entidad =>
                     new CedulaAgendaModelo
                     {
                         idagenda = entidad.idagenda,
                         idcedula = entidad.idcedula,
                         fechacreadoagenda = entidad.fechacreadoagenda,
                         fechaterminacionagenda = entidad.fechaterminacionagenda,
                         fecharevisionagenda = entidad.fecharevisionagenda,
                         fechaaprobacionagenda = entidad.fechaaprobacionagenda,
                         encabezadoagenda = entidad.encabezadoagenda,
                         descripcionagenda = entidad.descripcionagenda,
                         estadoprocesoagenda = entidad.estadoprocesoagenda,
                         comentariorespuestaagenda = entidad.comentariorespuestaagenda,
                         estadoagenda = entidad.estadoagenda,
                         isuso = entidad.isuso,
                         idencargo = entidad.idencargo,
                         idusuarioasigna = entidad.idusuarioasigna,
                         idusuarioresponable = entidad.idusuarioresponable,
                         padreidagenda = entidad.padreidagenda,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         referenciapapel = entidad.referenciapapel,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,

                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idagenda).Where(x => x.estadoagenda == "A" 
                     && x.idencargo == encargo.idencargo 
                     && x.idcedula == idCedula
                     && (x.idusuarioasigna==idUsuario || x.idusuarioresponable==idUsuario)).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaAgendaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.estadoprocesoagenda = conversion(item.estadoprocesoagenda);
                        if (item.padreidagenda != null && item.padreidagenda != 0)
                        {
                            item.padreencabezadoagenda = lista.SingleOrDefault(x => x.idagenda == item.padreidagenda).encabezadoagenda;
                        }
                    }
                    return new ObservableCollection<CedulaAgendaModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaAgendaModelo>();
            }
        }

        internal static CedulaAgendaModelo GetRegistro(int idagenda)
        {
            var entidad = new CedulaAgendaModelo();
            if (!(idagenda == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    agenda modelo = _context.agendas.Find(idagenda);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idagenda = modelo.idagenda;
                        entidad.idcedula = modelo.idcedula;
                        entidad.fechacreadoagenda = modelo.fechacreadoagenda;
                        entidad.fechaterminacionagenda = modelo.fechaterminacionagenda;
                        entidad.fecharevisionagenda = modelo.fecharevisionagenda;
                        entidad.fechaaprobacionagenda = modelo.fechaaprobacionagenda;
                        entidad.encabezadoagenda = modelo.encabezadoagenda;
                        entidad.descripcionagenda = modelo.descripcionagenda;
                        entidad.estadoprocesoagenda = conversion(modelo.estadoprocesoagenda);
                        entidad.comentariorespuestaagenda = modelo.comentariorespuestaagenda;
                        entidad.estadoagenda = modelo.estadoagenda;
                        entidad.isuso = modelo.isuso;
                        entidad.idencargo = modelo.idencargo;
                        entidad.idusuarioasigna = modelo.idusuarioasigna;
                        entidad.idusuarioresponable = modelo.idusuarioresponable;
                        entidad.padreidagenda = modelo.padreidagenda;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.referenciapapel = modelo.referenciapapel;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.etapapapel = modelo.etapapapel;
                        entidad.padreencabezadoagenda = modelo.agenda1.encabezadoagenda;
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

        public static ObservableCollection<agenda> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.agendas.Where(entidad => (entidad.idencargo == idencargo && entidad.estadoagenda== "A"));
                    ObservableCollection<agenda> temporal = new ObservableCollection<agenda>(lista);
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
                    //var lista = _context.agendas.Where(x => x.estadoagenda == "A" && x.idcedula == idcedula);
                    var lista = (from p in _context.agendas
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.agendas.RemoveRange(lista);
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
                    elementos = _context.agendas.Where(x => x.idagenda == id && x.estadoagenda == "A").Count();
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
                    elementos = (int)_context.agendas.Single(x => x.idagenda == id && x.estadoagenda == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(CedulaAgendaModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.encabezadoagenda) || string.IsNullOrWhiteSpace(documento.encabezadoagenda))))
            {
                string busqueda = documento.encabezadoagenda.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.agendas.Where(x => x.encabezadoagenda.ToUpper() == busqueda && x.estadoagenda == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public CedulaAgendaModelo()
        {
            idagenda = 0;
            idcedula = null;
            fechacreadoagenda = MetodosModelo.homologacionFecha();
            fechaterminacionagenda = null;
            fecharevisionagenda = null;
            fechaaprobacionagenda = null;
            encabezadoagenda = null;
            descripcionagenda = null;
            estadoprocesoagenda = conversion("A");
            comentariorespuestaagenda = null;
            estadoagenda = "A"; 
            isuso = null;
            idencargo = null;
            idusuarioasigna = null;
            idusuarioresponable = null;
            padreidagenda = null;
            idgenerico = null;
            tabla = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            padreencabezadoagenda = string.Empty;
        }
        public CedulaAgendaModelo(EncargoModelo encargo)
        {
            idagenda = 0;
            idcedula = null;
            fechacreadoagenda = MetodosModelo.homologacionFecha();
            fechaterminacionagenda = null;
            fecharevisionagenda = null;
            fechaaprobacionagenda = null;
            encabezadoagenda = null;
            descripcionagenda = null;
            estadoprocesoagenda = conversion("A");
            comentariorespuestaagenda = null;
            estadoagenda = "A";
            isuso = null;
            idencargo = encargo.idencargo;
            idusuarioasigna = null;
            idusuarioresponable = null;
            padreidagenda = null;
            idgenerico = null;
            tabla = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            padreencabezadoagenda = string.Empty;
        }

        internal static int evaluarCerrar(CedulaAgendaModelo currentEntidad)
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

        internal static int evaluarBorrar(CedulaAgendaModelo currentEntidad)
        {
            int respuesta = 0;
            try
            {
                if (currentEntidad.estadoprocesoagenda== "Asignada"||currentEntidad.estadoprocesoagenda== "No identificada")
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

        public CedulaAgendaModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idagenda = 0;
            idcedula = null;
            fechacreadoagenda = MetodosModelo.homologacionFecha();
            fechaterminacionagenda = null;
            fecharevisionagenda = null;
            fechaaprobacionagenda = null;
            encabezadoagenda = null;
            descripcionagenda = null;
            estadoprocesoagenda = conversion("A");
            comentariorespuestaagenda = null;
            estadoagenda = "A";
            isuso = null;
            idencargo = encargo.idencargo;
            idusuarioasigna = null;
            idusuarioresponable = null;
            padreidagenda = null;
            idgenerico = null;
            tabla = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
            padreencabezadoagenda = string.Empty;
        }

        public CedulaAgendaModelo(CedulaModelo currentMaestro, EncargoModelo encargo, UsuarioModelo usuario)
        {
            idagenda = 0;
            idcedula = currentMaestro.idcedula;
            fechacreadoagenda = MetodosModelo.homologacionFecha();
            fechaterminacionagenda = null;
            fecharevisionagenda = null;
            fechaaprobacionagenda = null;
            encabezadoagenda = null;
            descripcionagenda = null;
            estadoprocesoagenda = conversion("A");
            comentariorespuestaagenda = null;
            estadoagenda = "A";
            isuso = null;
            idencargo = encargo.idencargo;
            idusuarioasigna = null;
            idusuarioresponable = null;
            padreidagenda = null;
            idgenerico = null;
            tabla = null;
            referenciapapel = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
            padreencabezadoagenda = string.Empty;
        }

        public  static string conversion(string etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo.ToUpper())
            {
                case "A":
                    respuesta = "Asignada";
                    break;
                case "R":
                    respuesta = "Respondida";
                    break;
                case "T":
                    respuesta = "Terminada";
                    break;
                default:
                    respuesta = "No identificada";
                    break;
            }
            return respuesta;
        }
        public static string conversionIniciales(string etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo.ToUpper())
            {
                case "ASIGNADA":
                    respuesta ="A" ;
                    break;
                case "RESPONDIDA":
                    respuesta = "R";
                    break;
                case "TERMINADA":
                    respuesta = "T";
                    break;
                default:
                    respuesta = "N";
                    break;
            }
            return respuesta;
        }
    }

}
