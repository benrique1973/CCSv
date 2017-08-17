using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
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

    public class CedulaPartidasModelo : UIBase
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

        #region  idpartida
        public int _idpartida;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idpartida
        {
            get { return _idpartida; }
            set { _idpartida = value; }
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

        #region  idbalance
        public int? _idbalance;
        public int? idbalance
        {
            get { return _idbalance; }
            set { _idbalance = value; }
        }
        #endregion

        #region  idtp
        public int? _idtp;
        public int? idtp
        {
            get { return _idtp; }
            set { _idtp = value; }
        }
        #endregion
        public decimal numeropartida { get { return GetValue(() => numeropartida); } set { SetValue(() => numeropartida, value); } }

        [Required(ErrorMessage = "Encabezado de partida necesario")]
        [MaxLength(100, ErrorMessage = "No debe de exceder 100 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string conceptopartida { get { return GetValue(() => conceptopartida); } set { SetValue(() => conceptopartida, value); } }

        public string fechapartida { get { return GetValue(() => fechapartida); } set { SetValue(() => fechapartida, value); } }

        public string fechasistemapartida { get { return GetValue(() => fechasistemapartida); } set { SetValue(() => fechasistemapartida, value); } }


       public string aprobadapartida { get { return GetValue(() => aprobadapartida); } set { SetValue(() => aprobadapartida, value); } }

        public string elaboradapartida { get { return GetValue(() => elaboradapartida); } set { SetValue(() => elaboradapartida, value); } }

        [Required(ErrorMessage = "Concepto de partida")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string comentariopartida { get { return GetValue(() => comentariopartida); } set { SetValue(() => comentariopartida, value); } }


       public string clienteaplicopartida { get { return GetValue(() => clienteaplicopartida); } set { SetValue(() => clienteaplicopartida, value); } }

        [Required(ErrorMessage = "Toda partida debe tener cargos")]
        [Range(typeof(decimal), "1", "10000000000", ErrorMessage = "Valor no aceptable")]
        public decimal sumacargopartida
        {
            get { return GetValue(() => sumacargopartida); }
            set { SetValue(() => sumacargopartida, value); }
        }
        [Required(ErrorMessage = "Toda partida debe tener cargos")]
        [Range(typeof(decimal), "1", "10000000000",ErrorMessage ="Valor no aceptable")]
        public decimal sumaabonopartida
        {
            get { return GetValue(() => sumaabonopartida); }
            set { SetValue(() => sumaabonopartida, value); }
        }
        public string estadopartida { get { return GetValue(() => estadopartida); } set { SetValue(() => estadopartida, value); } }

        #region  isuso
        public int? _isuso;
        public int? isuso
        {
            get { return _isuso; }
            set { _isuso = value; }
        }
        #endregion

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



        #region  idencargo
        public int? _idencargo;
        public int? idencargo
        {
            get { return _idencargo; }
            set { _idencargo = value; }
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
        

        public string descripciontp
        {
            get { return GetValue(() => descripciontp); }
            set { SetValue(() => descripciontp, value); }
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
        public ObservableCollection<CedulaPartidasModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        public ObservableCollection<CedulaMovimientoModelo> listaCedulaMovimientoModelo
        {
            get { return GetValue(() => listaCedulaMovimientoModelo); }
            set { SetValue(() => listaCedulaMovimientoModelo, value); }
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(CedulaPartidasModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.partidas', 'idpartida'), (SELECT MAX(idpartida) FROM sgpt.partidas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new partida
                        {
                            idpartida = modelo.idpartida,
                            idcedula = modelo.idcedula,
                            idbalance =(int) modelo.idbalance,
                            idtp = modelo.idtp,
                            numeropartida = modelo.numeropartida,
                            conceptopartida = modelo.conceptopartida,
                            fechapartida = modelo.fechapartida,
                            fechasistemapartida = modelo.fechasistemapartida,
                            aprobadapartida = "P",
                            elaboradapartida = modelo.elaboradapartida,
                            comentariopartida = modelo.comentariopartida,
                            clienteaplicopartida = modelo.clienteaplicopartida,
                            sumacargopartida = modelo.sumacargopartida,
                            sumaabonopartida = modelo.sumaabonopartida,
                            estadopartida = modelo.estadopartida,
                            isuso = modelo.isuso,
                            referenciapapel = modelo.referenciapapel,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            idencargo = modelo.idencargo,
                        };
                        _context.partidas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idpartida = tablaDestino.idpartida;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
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

        public static bool InsertCapaDatos(partida modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.partidas', 'idpartida'), (SELECT MAX(idpartida) FROM sgpt.partidas) + 1);");
                            sincronizar = true;
                        }
                        _context.partidas.Add(modelo);
                        _context.SaveChanges();
                        modelo.idpartida = modelo.idpartida;
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
        public static int Insert(CedulaPartidasModelo modelo, ObservableCollection<CedulaMovimientoModelo> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.partidas', 'idpartida'), (SELECT MAX(idpartida) FROM sgpt.partidas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new partida
                        {
                            //idpartida = modelo.idpartida,
                            idcedula = modelo.idcedula,
                            idtp = modelo.idtp,
                            numeropartida = modelo.numeropartida,
                            conceptopartida = modelo.conceptopartida,
                            fechapartida = modelo.fechapartida,
                            fechasistemapartida = modelo.fechasistemapartida,
                            aprobadapartida = "P",
                            elaboradapartida = modelo.elaboradapartida,
                            comentariopartida = modelo.comentariopartida,
                            clienteaplicopartida = modelo.clienteaplicopartida,
                            sumacargopartida = modelo.sumacargopartida,
                            sumaabonopartida = modelo.sumaabonopartida,
                            estadopartida = modelo.estadopartida,
                            isuso = modelo.isuso,
                            referenciapapel = modelo.referenciapapel,
                            tabla = modelo.tabla,
                            //usuariocerro = modelo.usuariocerro,
                            //usuarioaprobo = modelo.usuarioaprobo,
                            //usuariosuperviso = modelo.usuariosuperviso,
                            //fechasupervision = modelo.fechasupervision,
                            //fechaaprobacion = modelo.fechaaprobacion,
                            //fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            idencargo = modelo.idencargo,
                        };
                        if (modelo.idbalance != null && modelo.idbalance != 0)
                        {
                           tablaDestino.idbalance = (int)modelo.idbalance;
                        };
                        if (modelo.idgenerico != null && modelo.idgenerico != 0)
                        {
                            tablaDestino.idgenerico = (int)modelo.idgenerico;
                        };
                        _context.partidas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idpartida = tablaDestino.idpartida;
                        for (int k = 0; k < lista.Count; k++)
                        {
                            lista[k].idpartida = modelo.idpartida;
                            try
                            {
                                //Se envian los detalles
                                result = CedulaMovimientoModelo.Insert(lista[k]);
                            }
                            catch (Exception)
                            {
                                //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                MessageBox.Show("No ha sido posible insertar el registro");
                                result = -1;
                            }
                            if (result != 1)
                            {
                                k = modelo.listaCedulaMovimientoModelo.Count;
                            }
                        }
                        if (result == 1)
                        {
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(1));
                            //Crear registro de bitacora
                            BitacoraModelo.Insert(temporal, 1);
                            result = 1;
                        }
                        else
                        {
                           int valor= CedulaPartidasModelo.Delete(modelo);
                        }
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


        public static int InsertByRangeByCapadatos(ObservableCollection<partida> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.partidas', 'idpartida'), (SELECT MAX(idpartida) FROM sgpt.partidas) + 1);");
                            sincronizar = true;
                        }
                        _context.partidas.AddRange(lista);
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

        public static CedulaPartidasModelo Find(int id)
        {
            var entidad = new CedulaPartidasModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //partida modelo = _context.partidas.Find(id);
                        partida modelo = _context.partidas.Single(x => x.idpartida == id);
                        if (modelo != null)
                        {
                            entidad.idpartida = modelo.idpartida;
                            entidad.idcedula = modelo.idcedula;
                            entidad.idbalance = modelo.idbalance;
                            entidad.idtp = modelo.idtp;
                            entidad.numeropartida = modelo.numeropartida;
                            entidad.conceptopartida = modelo.conceptopartida;
                            entidad.fechapartida = modelo.fechapartida;
                            entidad.fechasistemapartida = modelo.fechasistemapartida;
                            entidad.aprobadapartida =conversion(modelo.aprobadapartida);
                            entidad.elaboradapartida = modelo.elaboradapartida;
                            entidad.comentariopartida = modelo.comentariopartida;
                            entidad.clienteaplicopartida = modelo.clienteaplicopartida;
                            entidad.sumacargopartida = modelo.sumacargopartida;
                            entidad.sumaabonopartida = modelo.sumaabonopartida;
                            entidad.estadopartida = modelo.estadopartida;
                            entidad.isuso = modelo.isuso;
                            entidad.referenciapapel = modelo.referenciapapel;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.idencargo = modelo.idencargo;
                            entidad.IsSelected = false;
                            entidad.guardadoBase = true;
                            entidad.usuarioModelo = new UsuarioModelo();
                            return entidad;
                        }
                        else
                        {
                            return new CedulaPartidasModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaPartidasModelo();
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
                    var modelo = new CedulaPartidasModelo();
                   partida entidad = _context.partidas.Find(id);
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
                    var modelo = new CedulaPartidasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.partidas
                            .Where(b => b.estadopartida == "B")
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
                   partida entidad = _context.partidas.Find(id);
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

        public static void UpdateModelo(CedulaPartidasModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                   partida entidad = _context.partidas.Find(modelo.idpartida);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                        //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        //if (entidad.idbalance != modelo.idbalance) { cambiar = true; }
                        if (entidad.idtp != modelo.idtp) { cambiar = true; }
                        if (entidad.numeropartida != modelo.numeropartida) { cambiar = true; }
                        if (entidad.conceptopartida != modelo.conceptopartida) { cambiar = true; }
                        if (entidad.fechapartida != modelo.fechapartida) { cambiar = true; }
                        //if (entidad.fechasistemapartida != modelo.fechasistemapartida) { cambiar = true; }
                        if (entidad.aprobadapartida != conversion(modelo.aprobadapartida)) { cambiar = true; }
                        if (entidad.elaboradapartida != modelo.elaboradapartida) { cambiar = true; }
                        if (entidad.comentariopartida != modelo.comentariopartida) { cambiar = true; }
                        if (entidad.clienteaplicopartida != modelo.clienteaplicopartida) { cambiar = true; }
                        if (entidad.sumacargopartida != modelo.sumacargopartida) { cambiar = true; }
                        if (entidad.sumaabonopartida != modelo.sumaabonopartida) { cambiar = true; }
                        if (entidad.estadopartida != modelo.estadopartida) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }
                        if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                        if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        //if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                        //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }

                        if (cambiar)
                        {
                            //entidad.idpartida = modelo.idpartida;
                            //entidad.idcedula = modelo.idcedula;
                            //entidad.idbalance = modelo.idbalance;
                            entidad.idtp = modelo.idtp;
                            entidad.numeropartida = modelo.numeropartida;
                            entidad.conceptopartida = modelo.conceptopartida;
                            entidad.fechapartida = modelo.fechapartida;
                            //entidad.fechasistemapartida = modelo.fechasistemapartida;
                            entidad.aprobadapartida = conversionIniciales(modelo.aprobadapartida);
                            entidad.elaboradapartida = modelo.elaboradapartida;
                            entidad.comentariopartida = modelo.comentariopartida;
                            entidad.clienteaplicopartida = modelo.clienteaplicopartida;
                            entidad.sumacargopartida = modelo.sumacargopartida;
                            entidad.sumaabonopartida = modelo.sumaabonopartida;
                            //entidad.estadopartida = modelo.estadopartida;
                            entidad.isuso = modelo.isuso;
                            entidad.referenciapapel = modelo.referenciapapel;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            //entidad.usuariocerro = modelo.usuariocerro;
                            //entidad.usuarioaprobo = modelo.usuarioaprobo;
                            //entidad.usuariosuperviso = modelo.usuariosuperviso;
                            //entidad.fechasupervision = modelo.fechasupervision;
                            //entidad.fechaaprobacion = modelo.fechaaprobacion;
                            //entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                            //entidad.idencargo = modelo.idencargo;
                            //entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
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

        public static int UpdateModelo(CedulaPartidasModelo modelo, ObservableCollection<CedulaMovimientoModelo> lista)
        {
            int result = 0;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                       partida entidad = _context.partidas.Find(modelo.idpartida);
                        if (entidad == null)
                        {
                            return 0;
                        }
                        else
                        {
                            bool cambiar = false;
                            //if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                            //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                            //if (entidad.idbalance != modelo.idbalance) { cambiar = true; }
                            if (entidad.idtp != modelo.idtp) { cambiar = true; }
                            if (entidad.numeropartida != modelo.numeropartida) { cambiar = true; }
                            if (entidad.conceptopartida != modelo.conceptopartida) { cambiar = true; }
                            if (entidad.fechapartida != modelo.fechapartida) { cambiar = true; }
                            //if (entidad.fechasistemapartida != modelo.fechasistemapartida) { cambiar = true; }
                            if (entidad.aprobadapartida !=conversion(modelo.aprobadapartida)) { cambiar = true; }
                            if (entidad.elaboradapartida != modelo.elaboradapartida) { cambiar = true; }
                            if (entidad.comentariopartida != modelo.comentariopartida) { cambiar = true; }
                            if (entidad.clienteaplicopartida != modelo.clienteaplicopartida) { cambiar = true; }
                            if (entidad.sumacargopartida != modelo.sumacargopartida) { cambiar = true; }
                            if (entidad.sumaabonopartida != modelo.sumaabonopartida) { cambiar = true; }
                            if (entidad.estadopartida != modelo.estadopartida) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                            if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                            if (entidad.tabla != modelo.tabla) { cambiar = true; }
                            //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                            //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            //if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                            //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            //Tratamiento del sub-registros

                            //Recuperar lista Original
                            ObservableCollection<movimiento> listaAnterior = new ObservableCollection<movimiento>(CedulaMovimientoModelo.GetAllCapaDatosByidpartida(modelo.idpartida,(int)modelo.idencargo));
                            movimiento temporalItem = new movimiento();
                            for (int k = 0; k < lista.Count; k++)
                            {
                                lista[k].idpartida = modelo.idpartida;
                                try
                                {
                                    //Se envian los detalles
                                    if (lista[k].idmovimiento == 0)
                                    {
                                        //Nuevo registro se inserta 
                                        result = CedulaMovimientoModelo.Insert(lista[k]);
                                    }
                                    else
                                    {
                                        temporalItem = listaAnterior.Single(x => x.idmovimiento == lista[k].idmovimiento);
                                        result = CedulaMovimientoModelo.UpdateModelo(lista[k], temporalItem);
                                        if (result == 1)
                                        {
                                            listaAnterior.Remove(temporalItem);
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    //await dlg.ShowMessageAsync(this, "No ha sido posible insertar el registro", "");
                                    MessageBox.Show("No ha sido posible insertar el registro");
                                    result = -1;
                                }
                                if (result != 1)
                                {
                                    k = modelo.listaCedulaMovimientoModelo.Count;
                                }
                            }
                            try
                            {
                                //Borrar registros huerfanos
                                if (listaAnterior.Count > 0)
                                {
                                    foreach (movimiento item in listaAnterior)
                                    {
                                        CedulaMovimientoModelo.Delete(item.idmovimiento);
                                    }
                                }
                            }
                            catch (Exception f)
                            {
                                MessageBox.Show("No ha sido posible eliminar registros huérfanos\n"+f);
                                result = -1;
                            }

                            if (result == 1)
                            {
                                if (cambiar)
                                {
                                    //entidad.idpartida = modelo.idpartida;
                                    //entidad.idcedula = modelo.idcedula;
                                    //entidad.idbalance = modelo.idbalance;
                                    entidad.idtp = modelo.idtp;
                                    entidad.numeropartida = modelo.numeropartida;
                                    entidad.conceptopartida = modelo.conceptopartida;
                                    entidad.fechapartida = modelo.fechapartida;
                                    //entidad.fechasistemapartida = modelo.fechasistemapartida;
                                    entidad.aprobadapartida = conversionIniciales(modelo.aprobadapartida);
                                    entidad.elaboradapartida = modelo.elaboradapartida;
                                    entidad.comentariopartida = modelo.comentariopartida;
                                    entidad.clienteaplicopartida = modelo.clienteaplicopartida;
                                    entidad.sumacargopartida = modelo.sumacargopartida;
                                    entidad.sumaabonopartida = modelo.sumaabonopartida;
                                    //entidad.estadopartida = modelo.estadopartida;
                                    entidad.isuso = modelo.isuso;
                                    entidad.referenciapapel = modelo.referenciapapel;
                                    entidad.idgenerico = modelo.idgenerico;
                                    entidad.tabla = modelo.tabla;
                                    //entidad.usuariocerro = modelo.usuariocerro;
                                    //entidad.usuarioaprobo = modelo.usuarioaprobo;
                                    //entidad.usuariosuperviso = modelo.usuariosuperviso;
                                    //entidad.fechasupervision = modelo.fechasupervision;
                                    //entidad.fechaaprobacion = modelo.fechaaprobacion;
                                    //entidad.fechacierre = modelo.fechacierre;
                                    entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                                    //entidad.idencargo = modelo.idencargo;
                                    //entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); 
                                    _context.Entry(entidad).State = EntityState.Modified;
                                    _context.SaveChanges();
                                    //Inserción de modificacion
                                    BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(2));
                                    temporal.detallebitacora = "Actualización";
                                    //Crear registro de bitacora
                                    if (BitacoraModelo.Insert(temporal) == 1)
                                    {
                                        //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                        // modelo.listaBitacora.Add(temporal);
                                    }
                                }
                            }
                            else
                            {
                                return result;
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
        public static bool DeleteBorradoLogico(int id, CedulaPartidasModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.partidas SET estadopartida = 'B' WHERE idpartida={0};", id);
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

                            string commandString = String.Format("UPDATE sgpt.partidas SET estadopartida = 'B' WHERE idcedula={0};", idCedula);
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

        public static int Delete(ObservableCollection<CedulaPartidasModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                       partida entidadTemporal = new partida();
                        string commandString = string.Empty;
                        foreach (CedulaPartidasModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idpartida);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.partidas WHERE idpartida={0};", item.idpartida);
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

        public static int DeleteLogico(ObservableCollection<CedulaPartidasModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                       partida entidadTemporal = new partida();
                        string commandString = string.Empty;
                        foreach (CedulaPartidasModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idpartida);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.partidas SET estadopartida = 'B' WHERE idpartida={0};", item.idpartida);
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



        public static int Delete(CedulaPartidasModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idpartida != 0)
            {
                {

                    try
                    {
                        //Borrar hijos


                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(modelo.idpartida);//Borra todas las referencias dentro  de bitacora
                            //Borrar movimientos
                            CedulaMovimientoModelo.DeleteByIdPartida(modelo.idpartida);
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.partidas WHERE idpartida={0};", modelo.idpartida);
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

        public static int DeleteLogico(CedulaPartidasModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idpartida != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(modelo.idpartida);//Borra todas las referencias dentro  de bitacora
                                                                                              //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(modelo.idpartida);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            //Borrando movimientos
                            CedulaMovimientoModelo.DeleteBorradoLogicoByidPartida(modelo.idpartida);

                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.partidas SET estadopartida = 'B' WHERE idpartida={0};", modelo.idpartida);
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
                        BitacoraModelo.DeleteByTransaccion(id, "PARTIDAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.partidas WHERE idpartida={0};", id);
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
                        BitacoraModelo.DeleteByTransaccion(idCedula, "PARTIDAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.partidas WHERE idcedula={0};", idCedula);
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
        public static void DeleteByRange(ObservableCollection<partida> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.partidas.RemoveRange(lista);
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
                        string commandString = String.Format("DELETE FROM sgpt.partidas WHERE idpartida={0};", id);
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


        public static int DeleteBorradoLogico(ObservableCollection<CedulaPartidasModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                   partida entidadTemporal = new partida();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaPartidasModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idpartida);//Borra todas las referencias dentro  de bitacora
                                                                                             //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idpartida);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.partidas SET estadopartida = 'B' WHERE idpartida={0};", item.idpartida);
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

        internal static List<CedulaPartidasModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idcedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.partidas.Select(entidad =>
                     new CedulaPartidasModelo
                     {
                         idpartida = entidad.idpartida,
                         idcedula = entidad.idcedula,
                         idbalance = entidad.idbalance,
                         idtp = entidad.idtp,
                         numeropartida = entidad.numeropartida,
                         conceptopartida = entidad.conceptopartida,
                         fechapartida = entidad.fechapartida,
                         fechasistemapartida = entidad.fechasistemapartida,
                         aprobadapartida = entidad.aprobadapartida,
                         elaboradapartida = entidad.elaboradapartida,
                         comentariopartida = entidad.comentariopartida,
                         clienteaplicopartida = entidad.clienteaplicopartida,
                         sumacargopartida = entidad.sumacargopartida,
                         sumaabonopartida = entidad.sumaabonopartida,
                         estadopartida = entidad.estadopartida,
                         isuso = entidad.isuso,
                         referenciapapel = entidad.referenciapapel,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idencargo = entidad.idencargo,
                         guardadoBase = true,
                         IsSelected = false,
                         descripciontp = entidad.tipopartida.descripciontp,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idpartida).Where(x => x.estadopartida == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idcedula == idcedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaPartidasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            item.aprobadapartida = conversion(item.aprobadapartida);
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<partida> lista, int idpartida)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.partidas SET estadopartida = 'B' WHERE idpartida = {0};", idpartida);
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
        public static explicit operator partida(CedulaPartidasModelo modelo)  // explicit byte to digit conversion operator
        {
            partida entidad = new partida();
            entidad.idpartida = modelo.idpartida;
            entidad.idcedula = modelo.idcedula;
            entidad.idbalance =(int) modelo.idbalance;
            entidad.idtp = modelo.idtp;
            entidad.numeropartida = modelo.numeropartida;
            entidad.conceptopartida = modelo.conceptopartida;
            entidad.fechapartida = modelo.fechapartida;
            entidad.fechasistemapartida = modelo.fechasistemapartida;
            entidad.aprobadapartida =conversionIniciales(modelo.aprobadapartida);
            entidad.elaboradapartida = modelo.elaboradapartida;
            entidad.comentariopartida = modelo.comentariopartida;
            entidad.clienteaplicopartida = modelo.clienteaplicopartida;
            entidad.sumacargopartida = modelo.sumacargopartida;
            entidad.sumaabonopartida = modelo.sumaabonopartida;
            entidad.estadopartida = modelo.estadopartida;
            entidad.isuso = modelo.isuso;
            entidad.referenciapapel = modelo.referenciapapel;
            entidad.idgenerico = modelo.idgenerico;
            entidad.tabla = modelo.tabla;
            entidad.usuariocerro = modelo.usuariocerro;
            entidad.usuarioaprobo = modelo.usuarioaprobo;
            entidad.usuariosuperviso = modelo.usuariosuperviso;
            entidad.fechasupervision = modelo.fechasupervision;
            entidad.fechaaprobacion = modelo.fechaaprobacion;
            entidad.fechacierre = modelo.fechacierre;
            entidad.etapapapel = modelo.etapapapel;
            entidad.idencargo = modelo.idencargo;

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

                            string commandString = String.Format("DELETE FROM sgpt.partidas WHERE idpartida={0};", id);
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

        public static List<CedulaPartidasModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.partidas.Select(entidad =>
                     new CedulaPartidasModelo
                     {
                         idpartida = entidad.idpartida,
                         idcedula = entidad.idcedula,
                         idbalance = entidad.idbalance,
                         idtp = entidad.idtp,
                         numeropartida = entidad.numeropartida,
                         conceptopartida = entidad.conceptopartida,
                         fechapartida = entidad.fechapartida,
                         fechasistemapartida = entidad.fechasistemapartida,
                         aprobadapartida = entidad.aprobadapartida,
                         elaboradapartida = entidad.elaboradapartida,
                         comentariopartida = entidad.comentariopartida,
                         clienteaplicopartida = entidad.clienteaplicopartida,
                         sumacargopartida = entidad.sumacargopartida,
                         sumaabonopartida = entidad.sumaabonopartida,
                         estadopartida = entidad.estadopartida,
                         isuso = entidad.isuso,
                         referenciapapel = entidad.referenciapapel,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idencargo = entidad.idencargo,

                         guardadoBase = true,
                         IsSelected = false,
                         descripciontp = entidad.tipopartida.descripciontp
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idpartida).Where(x => x.estadopartida == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaPartidasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            item.aprobadapartida = conversion(item.aprobadapartida);
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

        internal static int UpdateCierre(CedulaPartidasModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idpartida;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.partidas SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idpartida = {3};",
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

        internal static int AprobatTarea(CedulaPartidasModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idpartida;
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion

                            string commandString = String.Format("UPDATE sgpt.partidas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}', etapapapel='{2}',aprobadapartida='{3}' WHERE idpartida = {4};",
                                usuarioModelo.inicialesusuario,
                                MetodosModelo.homologacionFecha(),
                                EtapaEncargoModelo.seleccionEtapaIniciales(6),
                                "A",
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

        internal static int UpdateReferencia(CedulaPartidasModelo modelo)
        {
            int id = modelo.idpartida;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.partidas SET referenciapapel = '{0}',etapapapel ='{1}' WHERE idpartida={2};", modelo.referenciapapel, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(CedulaPartidasModelo modelo)
        {
            int id = modelo.idpartida;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.partidas SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idpartida = {3};",
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

        internal static int UpdateAprobacion(CedulaPartidasModelo modelo)
        {
            int id = modelo.idpartida;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.partidas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idpartida = {3};",
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

        internal static int UpdateAprobacionSupervision(CedulaPartidasModelo modelo)
        {
            int id = modelo.idpartida;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "PARTIDAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.partidas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idpartida = {5};",
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

        public static ObservableCollection<CedulaPartidasModelo> GetAllEdicion(EncargoModelo encargo, int idCedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.partidas.Select(entidad =>
                     new CedulaPartidasModelo
                     {
                         idpartida = entidad.idpartida,
                         idcedula = entidad.idcedula,
                         idbalance = entidad.idbalance,
                         idtp = entidad.idtp,
                         numeropartida = entidad.numeropartida,
                         conceptopartida = entidad.conceptopartida,
                         fechapartida = entidad.fechapartida,
                         fechasistemapartida = entidad.fechasistemapartida,
                         aprobadapartida = entidad.aprobadapartida,
                         elaboradapartida = entidad.elaboradapartida,
                         comentariopartida = entidad.comentariopartida,
                         clienteaplicopartida = entidad.clienteaplicopartida,
                         sumacargopartida = entidad.sumacargopartida,
                         sumaabonopartida = entidad.sumaabonopartida,
                         estadopartida = entidad.estadopartida,
                         isuso = entidad.isuso,
                         referenciapapel = entidad.referenciapapel,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         etapapapel = entidad.etapapapel,
                         idencargo = entidad.idencargo,

                         descripciontp = entidad.tipopartida.descripciontp,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.numeropartida).Where(x => x.estadopartida == "A" && x.idencargo == encargo.idencargo && x.idcedula == idCedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaPartidasModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        item.aprobadapartida = conversion(item.aprobadapartida);
                        i++;
                    }
                    return new ObservableCollection<CedulaPartidasModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaPartidasModelo>();
            }
        }

        internal static CedulaPartidasModelo GetRegistro(int idpartida)
        {
            var entidad = new CedulaPartidasModelo();
            if (!(idpartida == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    partida modelo = _context.partidas.Find(idpartida);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idpartida = modelo.idpartida;
                        entidad.idcedula = modelo.idcedula;
                        entidad.idbalance = modelo.idbalance;
                        entidad.idtp = modelo.idtp;
                        entidad.numeropartida = modelo.numeropartida;
                        entidad.conceptopartida = modelo.conceptopartida;
                        entidad.fechapartida = modelo.fechapartida;
                        entidad.fechasistemapartida = modelo.fechasistemapartida;
                        entidad.aprobadapartida =conversion( modelo.aprobadapartida);
                        entidad.elaboradapartida = modelo.elaboradapartida;
                        entidad.comentariopartida = modelo.comentariopartida;
                        entidad.clienteaplicopartida = modelo.clienteaplicopartida;
                        entidad.sumacargopartida = modelo.sumacargopartida;
                        entidad.sumaabonopartida = modelo.sumaabonopartida;
                        entidad.estadopartida = modelo.estadopartida;
                        entidad.isuso = modelo.isuso;
                        entidad.referenciapapel = modelo.referenciapapel;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.etapapapel = modelo.etapapapel;
                        entidad.idencargo = modelo.idencargo;

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

        public static ObservableCollection<partida> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.partidas.Where(entidad => (entidad.idencargo == idencargo && entidad.estadopartida == "A"));
                    ObservableCollection<partida> temporal = new ObservableCollection<partida>(lista);
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
                    //var lista = _context.partidas.Where(x => x.estadopartida == "A" && x.idcedula == idcedula);
                    var lista = (from p in _context.partidas
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.partidas.RemoveRange(lista);
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
                    elementos = _context.partidas.Where(x => x.idpartida == id && x.estadopartida == "A").Count();
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
                    elementos = (int)_context.partidas.Single(x => x.idpartida == id && x.estadopartida == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(CedulaPartidasModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.comentariopartida) || string.IsNullOrWhiteSpace(documento.comentariopartida))))
            {
                string busqueda = documento.comentariopartida.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.partidas.Where(x => x.comentariopartida.ToUpper() == busqueda && x.estadopartida == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public CedulaPartidasModelo()
        {

            idpartida = 0;
            idcedula = null;
            idbalance = null;
            idtp = null;
            numeropartida = 0;
            conceptopartida = null;
            fechapartida = null;
            fechasistemapartida = MetodosModelo.homologacionFecha(); ;
            aprobadapartida = conversion("P"); 
            elaboradapartida = null;
            comentariopartida = null;
            clienteaplicopartida = null;
            sumacargopartida = 0;
            sumaabonopartida = 0;
            estadopartida ="A";
            isuso = null;
            referenciapapel = null;
            idgenerico = null;
            tabla = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            idencargo = null;
            descripciontp = string.Empty;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            listaCedulaMovimientoModelo = new ObservableCollection<CedulaMovimientoModelo>();
            elaboradapartida = string.Empty;
        }
        public CedulaPartidasModelo(EncargoModelo encargo)
        {
            idpartida = 0;
            idcedula = null;
            idbalance = null;
            idtp = null;
            numeropartida = 0;
            conceptopartida = null;
            fechapartida = null;
            fechasistemapartida = MetodosModelo.homologacionFecha(); ;
            aprobadapartida = conversion("P"); 
            elaboradapartida = null;
            comentariopartida = null;
            clienteaplicopartida = null;
            sumacargopartida = 0;
            sumaabonopartida = 0;
            estadopartida = "A";
            isuso = null;
            referenciapapel = null;
            idgenerico = null;
            tabla = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            idencargo = encargo.idencargo;
            listaCedulaMovimientoModelo = new ObservableCollection<CedulaMovimientoModelo>();
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;

        }

        internal static int evaluarCerrar(CedulaPartidasModelo currentEntidad)
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

        internal static int evaluarBorrar(CedulaPartidasModelo currentEntidad)
        {
            int respuesta = 0;
            try
            {
                if (currentEntidad.aprobadapartida == "Propuesta" || currentEntidad.aprobadapartida == "No identificada")
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

        public CedulaPartidasModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idpartida = 0;
            idcedula = null;
            idbalance = null;
            idtp = null;
            numeropartida = 0;
            conceptopartida = null;
            fechapartida = null;
            fechasistemapartida = MetodosModelo.homologacionFecha(); ;
            aprobadapartida = conversion("P");
            elaboradapartida = null;
            comentariopartida = null;
            clienteaplicopartida = null;
            sumacargopartida = 0;
            sumaabonopartida = 0;
            estadopartida = "A";
            isuso = null;
            referenciapapel = null;
            idgenerico = null;
            tabla = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            idencargo = encargo.idencargo;
            listaCedulaMovimientoModelo = new ObservableCollection<CedulaMovimientoModelo>();
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
        }

        public CedulaPartidasModelo(CedulaModelo currentMaestro, EncargoModelo encargo, UsuarioModelo usuario)
        {
            idpartida = 0;
            idcedula = currentMaestro.idcedula;
            idbalance = null;
            idtp = null;
            numeropartida = 0;
            conceptopartida = null;
            fechapartida = null;
            fechasistemapartida = MetodosModelo.homologacionFecha(); ;
            aprobadapartida = conversion("P"); 
            elaboradapartida = null;
            comentariopartida = null;
            clienteaplicopartida = null;
            sumacargopartida = 0;
            sumaabonopartida = 0;
            estadopartida = "A";
            isuso = null;
            referenciapapel = null;
            idgenerico = null;
            tabla = null;
            usuariocerro = null;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            idencargo = encargo.idencargo;
            listaCedulaMovimientoModelo = new ObservableCollection<CedulaMovimientoModelo>();
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
        }

        public static string conversion(string etapaencargo)
        {
            string respuesta = string.Empty;
            switch (etapaencargo.ToUpper())
            {
                case "A":
                    respuesta = "Aprobada";
                    break;
                case "P":
                    respuesta = "Propuesta";
                    break;
                case "R":
                    respuesta = "Rechazada";
                    break;
                case "V":
                    respuesta = "Verificada";
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
                case "APROBADA":
                    respuesta = "A";
                    break;
                case "RECHAZADA":
                    respuesta = "R";
                    break;
                case "VERIFICADA":
                    respuesta = "V";
                    break;
                case "PROPUESTA":
                    respuesta = "P";
                    break;
                default:
                    respuesta = "N";
                    break;
            }
            return respuesta;
        }
    }

}
