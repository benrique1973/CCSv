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

    public class CedulaMarcasModelo : UIBase
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

        #region
        public int _idma;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idma
        {
            get { return _idma; }
            set { _idma = value; }
        }

        #endregion
        public int? idcedula
        {
            get { return GetValue(() => idcedula); }
            set { SetValue(() => idcedula, value); }
        }


        public string marcama { get { return GetValue(() => marcama); } set { SetValue(() => marcama, value); } }
        public string significadoma { get { return GetValue(() => significadoma); } set { SetValue(() => significadoma, value); } }
        public string fechahoyme { get { return GetValue(() => fechahoyme); } set { SetValue(() => fechahoyme, value); } }
        public string tipografiama { get { return GetValue(() => tipografiama); } set { SetValue(() => tipografiama, value); } }
        public Nullable<decimal> tamaniotipografiama { get { return GetValue(() => tamaniotipografiama); } set { SetValue(() => tamaniotipografiama, value); } }

        public string estadoma
        {
            get { return GetValue(() => estadoma); }
            set { SetValue(() => estadoma, value); }
        }

        public bool sistemama
        {
            get { return GetValue(() => sistemama); }
            set { SetValue(() => sistemama, value); }
        }

        public int? idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }

        //Almacena la referencia para el  papel de  trabajo
        [DisplayName("Referencia de la  evaluación")]
        [MaxLength(30, ErrorMessage = "No debe de exceder 30 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string referenciapapel
        {
            get { return GetValue(() => referenciapapel); }
            set { SetValue(() => referenciapapel, value); }
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

        public decimal? ordenma { get { return GetValue(() => ordenma); } set { SetValue(() => ordenma, value); } }


        //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }



        //Encargo al  que corresponde la evaluacion


         #region Propiedades adiciones de fechas

        public marcasauditoria entidadBase
        {
            get { return GetValue(() => entidadBase); }
            set { SetValue(() => entidadBase, value); }
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
        public ObservableCollection<CedulaMarcasModelo> listaEntidadSeleccion
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

        public static bool Insert(CedulaMarcasModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.marcasauditoria', 'idma'), (SELECT MAX(idma) FROM sgpt.marcasauditoria) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new marcasauditoria
                        {
                            //idma = modelo.idma,
                            idcedula = modelo.idcedula,
                            marcama = modelo.marcama,
                            significadoma = modelo.significadoma,
                            fechahoyme = modelo.fechahoyme,
                            tipografiama = modelo.tipografiama,
                            tamaniotipografiama = modelo.tamaniotipografiama,
                            estadoma = modelo.estadoma,
                            sistemama = modelo.sistemama,
                            idencargo = modelo.idencargo,
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
                            isuso = modelo.isuso,
                            ordenma = modelo.ordenma,

                        };
                        _context.marcasauditorias.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idma = tablaDestino.idma;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(1));
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

        public static bool InsertCapaDatos(marcasauditoria modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.marcasauditoria', 'idma'), (SELECT MAX(idma) FROM sgpt.marcasauditoria) + 1);");
                            sincronizar = true;
                        }
                        _context.marcasauditorias.Add(modelo);
                        _context.SaveChanges();
                        modelo.idma = modelo.idma;
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
        public static int Insert(CedulaMarcasModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.marcasauditoria', 'idma'), (SELECT MAX(idma) FROM sgpt.marcasauditoria) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new marcasauditoria
                        {
                            //idma = modelo.idma,
                            idcedula = modelo.idcedula,
                            marcama = modelo.marcama,
                            significadoma = modelo.significadoma,
                            fechahoyme = modelo.fechahoyme,
                            tipografiama = modelo.tipografiama,
                            tamaniotipografiama = modelo.tamaniotipografiama,
                            estadoma = "A",
                            sistemama = false,
                            idencargo = modelo.idencargo,
                            //referenciapapel = modelo.referenciapapel,
                            //idgenerico = modelo.idgenerico,
                            //tabla = modelo.tabla,
                            usuariocerro = modelo.usuariocerro,
                            //usuarioaprobo = modelo.usuarioaprobo,
                            //usuariosuperviso = modelo.usuariosuperviso,
                            //fechasupervision = modelo.fechasupervision,
                            //fechaaprobacion = modelo.fechaaprobacion,
                            //fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            isuso = modelo.isuso,
                            ordenma = modelo.ordenma,
                        };
                        _context.marcasauditorias.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idma = tablaDestino.idma;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(1));
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


        public static int InsertByRangeByCapadatos(ObservableCollection<marcasauditoria> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.marcasauditoria', 'idma'), (SELECT MAX(idma) FROM sgpt.marcasauditoria) + 1);");
                            sincronizar = true;
                        }
                        _context.marcasauditorias.AddRange(lista);
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

        public static CedulaMarcasModelo Find(int id)
        {
            var entidad = new CedulaMarcasModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //marcasauditoria modelo = _context.marcasauditorias.Find(id);
                        marcasauditoria modelo = _context.marcasauditorias.Single(x => x.idma == id);
                        if (modelo != null)
                        {
                            entidad.idma = modelo.idma;
                            entidad.idcedula = modelo.idcedula;
                            entidad.marcama = modelo.marcama;
                            entidad.significadoma = modelo.significadoma;
                            entidad.fechahoyme = modelo.fechahoyme;
                            entidad.tipografiama = modelo.tipografiama;
                            entidad.tamaniotipografiama = modelo.tamaniotipografiama;
                            entidad.estadoma = modelo.estadoma;
                            entidad.sistemama = modelo.sistemama;
                            entidad.idencargo = modelo.idencargo;
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
                            entidad.isuso = modelo.isuso;
                            entidad.ordenma = modelo.ordenma;
                            return entidad;
                        }
                        else
                        {
                            return new CedulaMarcasModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaMarcasModelo();
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
                    var modelo = new CedulaMarcasModelo();
                    marcasauditoria entidad = _context.marcasauditorias.Find(id);
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
                    var modelo = new CedulaMarcasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.marcasauditorias
                            .Where(b => b.estadoma == "B")
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
                    marcasauditoria entidad = _context.marcasauditorias.Find(id);
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

        public static void UpdateModelo(CedulaMarcasModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    marcasauditoria entidad = _context.marcasauditorias.Find(modelo.idma);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idma != modelo.idma) { cambiar = true; }
                        //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        if (entidad.marcama != modelo.marcama) { cambiar = true; }
                        if (entidad.significadoma != modelo.significadoma) { cambiar = true; }
                        if (entidad.fechahoyme != modelo.fechahoyme) { cambiar = true; }
                        if (entidad.tipografiama != modelo.tipografiama) { cambiar = true; }
                        if (entidad.tamaniotipografiama != modelo.tamaniotipografiama) { cambiar = true; }
                        if (entidad.estadoma != modelo.estadoma) { cambiar = true; }
                        //if (entidad.sistemama != modelo.sistemama) { cambiar = true; }
                        //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                        if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                        if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }
                        if (entidad.ordenma != modelo.ordenma) { cambiar = true; }
                        if (cambiar)
                        {
                            //entidad.idma = modelo.idma;
                            //entidad.idcedula = modelo.idcedula;
                            entidad.marcama = modelo.marcama;
                            entidad.significadoma = modelo.significadoma;
                            entidad.fechahoyme = modelo.fechahoyme;
                            entidad.tipografiama = modelo.tipografiama;
                            entidad.tamaniotipografiama = modelo.tamaniotipografiama;
                            //entidad.estadoma = modelo.estadoma;
                            //entidad.sistemama = modelo.sistemama;
                            //entidad.idencargo = modelo.idencargo;
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
                            entidad.isuso = modelo.isuso;
                            entidad.ordenma = modelo.ordenma;
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

        public static int UpdateModelo(CedulaMarcasModelo modelo, Boolean actualizar)
        {
            int respuesta = 0;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambiar = false;
                        marcasauditoria entidad = _context.marcasauditorias.Find(modelo.idma);
                        if (entidad == null)
                        {
                            return respuesta;
                        }
                        else
                        {
                            //if (entidad.idma != modelo.idma) { cambiar = true; }
                            //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                            if (entidad.marcama != modelo.marcama) { cambiar = true; }
                            if (entidad.significadoma != modelo.significadoma) { cambiar = true; }
                            if (entidad.fechahoyme != modelo.fechahoyme) { cambiar = true; }
                            if (entidad.tipografiama != modelo.tipografiama) { cambiar = true; }
                            if (entidad.tamaniotipografiama != modelo.tamaniotipografiama) { cambiar = true; }
                            if (entidad.estadoma != modelo.estadoma) { cambiar = true; }
                            //if (entidad.sistemama != modelo.sistemama) { cambiar = true; }
                            //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                            if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                            if (entidad.tabla != modelo.tabla) { cambiar = true; }
                            if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                            //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            //if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            if (entidad.ordenma != modelo.ordenma) { cambiar = true; }
                            if (cambiar)
                            {
                                //entidad.idma = modelo.idma;
                                //entidad.idcedula = modelo.idcedula;
                                entidad.marcama = modelo.marcama;
                                entidad.significadoma = modelo.significadoma;
                                entidad.fechahoyme = MetodosModelo.homologacionFecha(); 
                                entidad.tipografiama = modelo.tipografiama;
                                entidad.tamaniotipografiama = modelo.tamaniotipografiama;
                                //entidad.estadoma = modelo.estadoma;
                                //entidad.sistemama = modelo.sistemama;
                                //entidad.idencargo = modelo.idencargo;
                                //entidad.referenciapapel = modelo.referenciapapel;
                                //entidad.idgenerico = modelo.idgenerico;
                                //entidad.tabla = modelo.tabla;
                                //entidad.usuariocerro = modelo.usuariocerro;
                                //entidad.usuarioaprobo = modelo.usuarioaprobo;
                                //entidad.usuariosuperviso = modelo.usuariosuperviso;
                                //entidad.fechasupervision = modelo.fechasupervision;
                                //entidad.fechaaprobacion = modelo.fechaaprobacion;
                                //entidad.fechacierre = modelo.fechacierre;
                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                                entidad.isuso = modelo.isuso;
                                entidad.ordenma = modelo.ordenma;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = "Actualización";
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
        public static bool DeleteBorradoLogico(int id, CedulaMarcasModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET estadoma = 'B' WHERE idma={0};", id);
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

        internal static void UpdateModeloReodenar(CedulaMarcasModelo modelo)
        {
            if (!(modelo == null))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET ordenma = {0} WHERE idma={1};", modelo.ordenma, modelo.idma);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                            modelo.guardadoBase = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en actualizar orden del registro: \n" + e);
                        throw;
                    }
                }
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

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET estadoma = 'B' WHERE idcedula={0};", idCedula);
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

        public static int Delete(ObservableCollection<CedulaMarcasModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        marcasauditoria entidadTemporal = new marcasauditoria();
                        string commandString = string.Empty;
                        foreach (CedulaMarcasModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idma);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.marcasauditoria WHERE idma={0};", item.idma);
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

        public static int DeleteLogico(ObservableCollection<CedulaMarcasModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        marcasauditoria entidadTemporal = new marcasauditoria();
                        string commandString = string.Empty;
                        foreach (CedulaMarcasModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idma);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.marcasauditoria SET estadoma = 'B' WHERE idma={0};", item.idma);
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



        public static int Delete(CedulaMarcasModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idma != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.marcasauditoria WHERE idma={0};", modelo.idma);
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

        public static int DeleteLogico(CedulaMarcasModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idma != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET estadoma = 'B' WHERE idma={0};", modelo.idma);
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
                        BitacoraModelo.DeleteByTransaccion(id, "MARCASAUDITORIA");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.marcasauditoria WHERE idma={0};", id);
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
                        BitacoraModelo.DeleteByTransaccion(idCedula, "MARCASAUDITORIA");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.marcasauditoria WHERE idcedula={0};", idCedula);
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
        public static void DeleteByRange(ObservableCollection<marcasauditoria> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.marcasauditorias.RemoveRange(lista);
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
                        string commandString = String.Format("DELETE FROM sgpt.marcasauditoria WHERE idma={0};", id);
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


        public static int DeleteBorradoLogico(ObservableCollection<CedulaMarcasModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    marcasauditoria entidadTemporal = new marcasauditoria();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaMarcasModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idma);//Borra todas las referencias dentro  de bitacora
                                                                                         //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idma);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.marcasauditoria SET estadoma = 'B' WHERE idma={0};", item.idma);
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

        internal static List<CedulaMarcasModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idcedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.marcasauditorias.Select(entidad =>
                     new CedulaMarcasModelo
                     {
                         idma = entidad.idma,
                         idcedula = entidad.idcedula,
                         marcama = entidad.marcama,
                         significadoma = entidad.significadoma,
                         fechahoyme = entidad.fechahoyme,
                         tipografiama = entidad.tipografiama,
                         tamaniotipografiama = entidad.tamaniotipografiama,
                         estadoma = entidad.estadoma,
                         sistemama = entidad.sistemama,
                         idencargo = entidad.idencargo,
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
                         isuso = entidad.isuso,
                         ordenma = entidad.ordenma,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idma).Where(x => x.estadoma == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idcedula == idcedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaMarcasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<marcasauditoria> lista, int idma)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.marcasauditoria SET estadoma = 'B' WHERE idma = {0};", idma);
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
        public static explicit operator marcasauditoria(CedulaMarcasModelo modelo)  // explicit byte to digit conversion operator
        {
            marcasauditoria entidad = new marcasauditoria();
            entidad.idma = modelo.idma;
            entidad.idcedula = modelo.idcedula;
            entidad.marcama = modelo.marcama;
            entidad.significadoma = modelo.significadoma;
            entidad.fechahoyme = modelo.fechahoyme;
            entidad.tipografiama = modelo.tipografiama;
            entidad.tamaniotipografiama = modelo.tamaniotipografiama;
            entidad.estadoma = modelo.estadoma;
            entidad.sistemama = modelo.sistemama;
            entidad.idencargo = modelo.idencargo;
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
            entidad.isuso = modelo.isuso;
            entidad.ordenma = modelo.ordenma;
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

                            string commandString = String.Format("DELETE FROM sgpt.marcasauditoria WHERE idma={0};", id);
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

        public static List<CedulaMarcasModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.marcasauditorias.Select(entidad =>
                     new CedulaMarcasModelo
                     {
                         idma = entidad.idma,
                         idcedula = entidad.idcedula,
                         marcama = entidad.marcama,
                         significadoma = entidad.significadoma,
                         fechahoyme = entidad.fechahoyme,
                         tipografiama = entidad.tipografiama,
                         tamaniotipografiama = entidad.tamaniotipografiama,
                         estadoma = entidad.estadoma,
                         sistemama = entidad.sistemama,
                         idencargo = entidad.idencargo,
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
                         isuso = entidad.isuso,
                         ordenma = entidad.ordenma,
                         guardadoBase = true,
                         IsSelected = false,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idma).Where(x => x.estadoma == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaMarcasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
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

        internal static int UpdateCierre(CedulaMarcasModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idma;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idma = {3};",
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

        internal static int UpdateReferencia(CedulaMarcasModelo modelo)
        {
            int id = modelo.idma;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET referenciapapel = '{0}',etapapapel ='{1}' WHERE idma={2};", modelo.referenciapapel, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(CedulaMarcasModelo modelo)
        {
            int id = modelo.idma;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idma = {3};",
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

        internal static int UpdateAprobacion(CedulaMarcasModelo modelo)
        {
            int id = modelo.idma;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idma = {3};",
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

        internal static int UpdateAprobacionSupervision(CedulaMarcasModelo modelo)
        {
            int id = modelo.idma;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "MARCASAUDITORIA", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.marcasauditoria SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idma = {5};",
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

        public static ObservableCollection<CedulaMarcasModelo> GetAllEdicion(EncargoModelo encargo, int idCedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.marcasauditorias.Select(entidad =>
                     new CedulaMarcasModelo
                     {
                         idma = entidad.idma,
                         idcedula = entidad.idcedula,
                         marcama = entidad.marcama,
                         significadoma = entidad.significadoma,
                         fechahoyme = entidad.fechahoyme,
                         tipografiama = entidad.tipografiama,
                         tamaniotipografiama = entidad.tamaniotipografiama,
                         estadoma = entidad.estadoma,
                         sistemama = entidad.sistemama,
                         idencargo = entidad.idencargo,
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
                         isuso = entidad.isuso,
                         ordenma = entidad.ordenma,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idma).Where(x => x.estadoma == "A" && x.idencargo == encargo.idencargo && x.idcedula == idCedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaMarcasModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        //item.guardadoBase = true;
                        //item.IsSelected = true;
                        //Buscar en bitacora
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<CedulaMarcasModelo>(lista);
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

        internal static CedulaMarcasModelo GetRegistro(int idgenericoindice)
        {
            var entidad = new CedulaMarcasModelo();
            if (!(idgenericoindice == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    marcasauditoria modelo = _context.marcasauditorias.Find(idgenericoindice);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idma = modelo.idma;
                        entidad.idcedula = modelo.idcedula;
                        entidad.marcama = modelo.marcama;
                        entidad.significadoma = modelo.significadoma;
                        entidad.fechahoyme = modelo.fechahoyme;
                        entidad.tipografiama = modelo.tipografiama;
                        entidad.tamaniotipografiama = modelo.tamaniotipografiama;
                        entidad.estadoma = modelo.estadoma;
                        entidad.sistemama = modelo.sistemama;
                        entidad.idencargo = modelo.idencargo;
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
                        entidad.isuso = modelo.isuso;
                        entidad.ordenma = modelo.ordenma;
                        int i = 1;
                        var listaBitacora = BitacoraModelo.GetAllByTabla("MARCASAUDITORIA");
                        if (listaBitacora.Count > 0)
                        {
                            string etapaBuscada = EtapaEncargoModelo.seleccionEtapa(1);//Creacion

                            entidad.idCorrelativo = i;
                            i++;
                            entidad.guardadoBase = true;
                            entidad.IsSelected = false;

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

        public static ObservableCollection<marcasauditoria> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.marcasauditorias.Where(entidad => (entidad.idencargo == idencargo && entidad.estadoma == "A"));
                    ObservableCollection<marcasauditoria> temporal = new ObservableCollection<marcasauditoria>(lista);
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
                    //var lista = _context.marcasauditorias.Where(x => x.estadoma == "A" && x.idcedula == idcedula);
                    var lista = (from p in _context.marcasauditorias
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.marcasauditorias.RemoveRange(lista);
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
                    elementos = _context.marcasauditorias.Where(x => x.idma == id && x.estadoma == "A").Count();
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
                    elementos = (int)_context.marcasauditorias.Single(x => x.idma == id && x.estadoma == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(CedulaMarcasModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.marcama) || string.IsNullOrWhiteSpace(documento.marcama))))
            {
                string busqueda = documento.marcama.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.marcasauditorias.Where(x => x.marcama.ToUpper() == busqueda && x.estadoma == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public CedulaMarcasModelo()
        {
            idma = 0;
            idcedula = null;
            marcama = null;
            significadoma = null;
            fechahoyme = MetodosModelo.homologacionFecha();
            tipografiama = null;
            tamaniotipografiama = null;
            estadoma = null;
            sistemama = false;
            idencargo = null;
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
            isuso = 0;
            ordenma = 0;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
        }
        public CedulaMarcasModelo(EncargoModelo encargo)
        {
            idma = 0;
            idcedula = null;
            marcama = null;
            significadoma = null;
            fechahoyme = MetodosModelo.homologacionFecha();
            tipografiama = "Arial";
            tamaniotipografiama = 11;
            estadoma = null;
            sistemama = false;
            idencargo = encargo.idencargo;
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
            isuso = 0;
            ordenma = 0;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
         }

        internal static int evaluarCerrar(CedulaMarcasModelo currentEntidad)
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

        internal static int evaluarBorrar(CedulaMarcasModelo currentEntidad)
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

        public CedulaMarcasModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idma = 0;
            idcedula = null;
            marcama = null;
            significadoma = null;
            fechahoyme = MetodosModelo.homologacionFecha();
            tipografiama = null;
            tamaniotipografiama = null;
            estadoma = null;
            sistemama = false;
            idencargo = encargo.idencargo;
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
            isuso = 0;
            ordenma = 0;
            IsSelected = false;
            guardadoBase = false;
            usuarioModelo = usuario;
        }

        public CedulaMarcasModelo(CedulaModelo currentMaestro, EncargoModelo encargo, UsuarioModelo usuario)
        {
            idma = 0;
            idcedula = currentMaestro.idcedula;
            marcama = null;
            significadoma = null;
            fechahoyme = MetodosModelo.homologacionFecha();
            tipografiama = null;
            tamaniotipografiama = null;
            estadoma = null;
            sistemama = false;
            idencargo = encargo.idencargo;
            referenciapapel = null;
            idgenerico = null;
            tabla = null;
            usuariocerro = usuario.inicialesusuario;
            usuarioaprobo = null;
            usuariosuperviso = null;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            isuso = 0;
            ordenma = 0;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            usuarioModelo = usuario;
        }
    }

}
