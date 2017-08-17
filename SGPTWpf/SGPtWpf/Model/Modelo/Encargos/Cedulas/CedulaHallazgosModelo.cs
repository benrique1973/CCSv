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

    public class CedulaHallazgosModelo : UIBase
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

        #region  idhallazgo
        public int _idhallazgo;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idhallazgo
        {
            get { return _idhallazgo; }
            set { _idhallazgo = value; }
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

        #region  detidcedula
        public int? _detidcedula;
        public int? detidcedula
        {
            get { return _detidcedula; }
            set { _detidcedula = value; }
        }

        #endregion

        #region  idcorrespondencia
        public int? _idcorrespondencia;
        public int? idcorrespondencia
        {
            get { return _idcorrespondencia; }
            set { _idcorrespondencia = value; }
        }
        #endregion

        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string descripcionhallazgo { get { return GetValue(() => descripcionhallazgo); } set { SetValue(() => descripcionhallazgo, value); } }

        //Almacena la referencia para el  papel de  trabajo
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string referenciahallazgo
        {
            get { return GetValue(() => referenciahallazgo); }
            set { SetValue(() => referenciahallazgo, value); }
        }

        public string fechacreadohallazgo { get { return GetValue(() => fechacreadohallazgo); } set { SetValue(() => fechacreadohallazgo, value); } }

        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string baselegalhallazgo { get { return GetValue(() => baselegalhallazgo); } set { SetValue(() => baselegalhallazgo, value); } }
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string recomendacionhallazgo { get { return GetValue(() => recomendacionhallazgo); } set { SetValue(() => recomendacionhallazgo, value); } }
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string respuestaclientehallazgo { get { return GetValue(() => respuestaclientehallazgo); } set { SetValue(() => respuestaclientehallazgo, value); } }
        public string fecharespclientehallazgo { get { return GetValue(() => fecharespclientehallazgo); } set { SetValue(() => fecharespclientehallazgo, value); } }

        public string estadohallazgo
        {
            get { return GetValue(() => estadohallazgo); }
            set { SetValue(() => estadohallazgo, value); }
        }
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(50, ErrorMessage = "No debe de exceder 50 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string titulohallazgo
        {
            get { return GetValue(() => titulohallazgo); }
            set { SetValue(() => titulohallazgo, value); }
        }
        public string referenciapapel   {  get { return GetValue(() => referenciapapel); }  set { SetValue(() => referenciapapel, value); }}

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


        public string etapapapel
        {
            get { return GetValue(() => etapapapel); }
            set { SetValue(() => etapapapel, value); }
        }

        public decimal? orden { get { return GetValue(() => orden); } set { SetValue(() => orden, value); } }


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
        public ObservableCollection<CedulaHallazgosModelo> listaEntidadSeleccion
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

        public static bool Insert(CedulaHallazgosModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.hallazgos', 'idhallazgo'), (SELECT MAX(idhallazgo) FROM sgpt.hallazgos) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new hallazgo
                        {
                            //idhallazgo = modelo.idhallazgo,
                            idcedula = modelo.idcedula,
                            detidcedula = modelo.detidcedula,
                            idcorrespondencia = modelo.idcorrespondencia,
                            descripcionhallazgo = modelo.descripcionhallazgo,
                            referenciahallazgo = modelo.referenciahallazgo,
                            fechacreadohallazgo = modelo.fechacreadohallazgo,
                            baselegalhallazgo = modelo.baselegalhallazgo,
                            recomendacionhallazgo = modelo.recomendacionhallazgo,
                            respuestaclientehallazgo = modelo.respuestaclientehallazgo,
                            fecharespclientehallazgo = modelo.fecharespclientehallazgo,
                            estadohallazgo = modelo.estadohallazgo,
                            titulohallazgo = modelo.titulohallazgo,
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
                            orden = modelo.orden,


                        };
                        _context.hallazgos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idhallazgo = tablaDestino.idhallazgo;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(1));
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

        public static bool InsertCapaDatos(hallazgo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.hallazgos', 'idhallazgo'), (SELECT MAX(idhallazgo) FROM sgpt.hallazgos) + 1);");
                            sincronizar = true;
                        }
                        _context.hallazgos.Add(modelo);
                        _context.SaveChanges();
                        modelo.idhallazgo = modelo.idhallazgo;
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
        public static int Insert(CedulaHallazgosModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.hallazgos', 'idhallazgo'), (SELECT MAX(idhallazgo) FROM sgpt.hallazgos) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new hallazgo
                        {
                            //idhallazgo = modelo.idhallazgo,
                            idcedula = modelo.idcedula,
                            detidcedula = modelo.detidcedula,
                            idcorrespondencia = modelo.idcorrespondencia,
                            descripcionhallazgo = modelo.descripcionhallazgo,
                            referenciahallazgo = modelo.referenciahallazgo,
                            fechacreadohallazgo = modelo.fechacreadohallazgo,
                            baselegalhallazgo = modelo.baselegalhallazgo,
                            recomendacionhallazgo = modelo.recomendacionhallazgo,
                            respuestaclientehallazgo = modelo.respuestaclientehallazgo,
                            fecharespclientehallazgo = modelo.fecharespclientehallazgo,
                            estadohallazgo = modelo.estadohallazgo,
                            titulohallazgo = modelo.titulohallazgo,
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
                            orden = modelo.orden,

                        };
                        _context.hallazgos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idhallazgo = tablaDestino.idhallazgo;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(1));
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


        public static int InsertByRangeByCapadatos(ObservableCollection<hallazgo> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.hallazgos', 'idhallazgo'), (SELECT MAX(idhallazgo) FROM sgpt.hallazgos) + 1);");
                            sincronizar = true;
                        }
                        _context.hallazgos.AddRange(lista);
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

        public static CedulaHallazgosModelo Find(int id)
        {
            var entidad = new CedulaHallazgosModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //hallazgo modelo = _context.hallazgos.Find(id);
                        hallazgo modelo = _context.hallazgos.Single(x => x.idhallazgo == id);
                        if (modelo != null)
                        {
                            entidad.idhallazgo = modelo.idhallazgo;
                            entidad.idcedula = modelo.idcedula;
                            entidad.descripcionhallazgo = modelo.descripcionhallazgo;
                            entidad.baselegalhallazgo = modelo.baselegalhallazgo;
                            entidad.fechacreadohallazgo = modelo.fechacreadohallazgo;
                            entidad.recomendacionhallazgo = modelo.recomendacionhallazgo;
                            entidad.respuestaclientehallazgo = modelo.respuestaclientehallazgo;
                            entidad.estadohallazgo = modelo.estadohallazgo;
                            entidad.titulohallazgo = modelo.titulohallazgo;
                            entidad.idencargo = modelo.idencargo;
                            entidad.referenciahallazgo = modelo.referenciahallazgo;
                            entidad.idgenerico =(int) modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.isuso = modelo.isuso;
                            entidad.orden = modelo.orden;
                            return entidad;
                        }
                        else
                        {
                            return new CedulaHallazgosModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaHallazgosModelo();
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
                    var modelo = new CedulaHallazgosModelo();
                    hallazgo entidad = _context.hallazgos.Find(id);
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
                    var modelo = new CedulaHallazgosModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.hallazgos
                            .Where(b => b.estadohallazgo == "B")
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
                    hallazgo entidad = _context.hallazgos.Find(id);
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

        public static void UpdateModelo(CedulaHallazgosModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    hallazgo entidad = _context.hallazgos.Find(modelo.idhallazgo);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idhallazgo != modelo.idhallazgo) { cambiar = true; }
                        //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        if (entidad.detidcedula != modelo.detidcedula) { cambiar = true; }
                        if (entidad.idcorrespondencia != modelo.idcorrespondencia) { cambiar = true; }
                        if (entidad.descripcionhallazgo != modelo.descripcionhallazgo) { cambiar = true; }
                        if (entidad.referenciahallazgo != modelo.referenciahallazgo) { cambiar = true; }
                        if (entidad.fechacreadohallazgo != modelo.fechacreadohallazgo) { cambiar = true; }
                        if (entidad.baselegalhallazgo != modelo.baselegalhallazgo) { cambiar = true; }
                        if (entidad.recomendacionhallazgo != modelo.recomendacionhallazgo) { cambiar = true; }
                      if (entidad.respuestaclientehallazgo != modelo.respuestaclientehallazgo) { cambiar = true; }
                        if (entidad.fecharespclientehallazgo != modelo.fecharespclientehallazgo) { cambiar = true; }
                        if (entidad.estadohallazgo != modelo.estadohallazgo) { cambiar = true; }
                        if (entidad.titulohallazgo != modelo.titulohallazgo) { cambiar = true; }
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
                        if (entidad.orden != modelo.orden) { cambiar = true; }

                        if (cambiar)
                        {
                            //entidad.idhallazgo = modelo.idhallazgo;
                            //entidad.idcedula = modelo.idcedula;
                            entidad.detidcedula = modelo.detidcedula;
                            entidad.idcorrespondencia = modelo.idcorrespondencia;
                            entidad.descripcionhallazgo = modelo.descripcionhallazgo;
                            entidad.referenciahallazgo = modelo.referenciahallazgo;
                            entidad.fechacreadohallazgo = modelo.fechacreadohallazgo;
                            entidad.baselegalhallazgo = modelo.baselegalhallazgo;
                            entidad.recomendacionhallazgo = modelo.recomendacionhallazgo;
                            entidad.respuestaclientehallazgo = modelo.respuestaclientehallazgo;
                            entidad.fecharespclientehallazgo = modelo.fecharespclientehallazgo;
                            entidad.estadohallazgo = modelo.estadohallazgo;
                            entidad.titulohallazgo = modelo.titulohallazgo;
                            entidad.referenciapapel = modelo.referenciapapel;
                            //entidad.idgenerico = modelo.idgenerico;
                            //entidad.tabla = modelo.tabla;
                            //entidad.usuariocerro = modelo.usuariocerro;
                            //entidad.usuarioaprobo = modelo.usuarioaprobo;
                            //entidad.usuariosuperviso = modelo.usuariosuperviso;
                            //entidad.fechasupervision = modelo.fechasupervision;
                            //entidad.fechaaprobacion = modelo.fechaaprobacion;
                            //entidad.fechacierre = modelo.fechacierre;
                            //entidad.idencargo = modelo.idencargo;
                            entidad.orden = modelo.orden;
                            entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
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

        public static int UpdateModelo(CedulaHallazgosModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        hallazgo entidad = _context.hallazgos.Find(modelo.idhallazgo);
                        if (entidad == null)
                        {
                            return 1;
                        }
                        else
                        {
                            bool cambiar = false;
                            //if (entidad.idhallazgo != modelo.idhallazgo) { cambiar = true; }
                            //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                            if (entidad.detidcedula != modelo.detidcedula) { cambiar = true; }
                            if (entidad.idcorrespondencia != modelo.idcorrespondencia) { cambiar = true; }
                            if (entidad.descripcionhallazgo != modelo.descripcionhallazgo) { cambiar = true; }
                            if (entidad.referenciahallazgo != modelo.referenciahallazgo) { cambiar = true; }
                            if (entidad.fechacreadohallazgo != modelo.fechacreadohallazgo) { cambiar = true; }
                            if (entidad.baselegalhallazgo != modelo.baselegalhallazgo) { cambiar = true; }
                            if (entidad.recomendacionhallazgo != modelo.recomendacionhallazgo) { cambiar = true; }
                            if (entidad.respuestaclientehallazgo != modelo.respuestaclientehallazgo) { cambiar = true; }
                            if (entidad.fecharespclientehallazgo != modelo.fecharespclientehallazgo) { cambiar = true; }
                            if (entidad.estadohallazgo != modelo.estadohallazgo) { cambiar = true; }
                            if (entidad.titulohallazgo != modelo.titulohallazgo) { cambiar = true; }
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
                            if (entidad.orden != modelo.orden) { cambiar = true; }

                            if (cambiar)
                            {
                                //entidad.idhallazgo = modelo.idhallazgo;
                                //entidad.idcedula = modelo.idcedula;
                                entidad.detidcedula = modelo.detidcedula;
                                entidad.idcorrespondencia = modelo.idcorrespondencia;
                                entidad.descripcionhallazgo = modelo.descripcionhallazgo;
                                entidad.referenciahallazgo = modelo.referenciahallazgo;
                                entidad.fechacreadohallazgo = modelo.fechacreadohallazgo;
                                entidad.baselegalhallazgo = modelo.baselegalhallazgo;
                                entidad.recomendacionhallazgo = modelo.recomendacionhallazgo;
                                entidad.respuestaclientehallazgo = modelo.respuestaclientehallazgo;
                                entidad.fecharespclientehallazgo = modelo.fecharespclientehallazgo;
                                entidad.estadohallazgo = modelo.estadohallazgo;
                                entidad.titulohallazgo = modelo.titulohallazgo;
                                entidad.referenciapapel = modelo.referenciapapel;
                                //entidad.idgenerico = modelo.idgenerico;
                                //entidad.tabla = modelo.tabla;
                                //entidad.usuariocerro = modelo.usuariocerro;
                                //entidad.usuarioaprobo = modelo.usuarioaprobo;
                                //entidad.usuariosuperviso = modelo.usuariosuperviso;
                                //entidad.fechasupervision = modelo.fechasupervision;
                                //entidad.fechaaprobacion = modelo.fechaaprobacion;
                                //entidad.fechacierre = modelo.fechacierre;
                                //entidad.idencargo = modelo.idencargo;
                                entidad.orden = modelo.orden;
                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ;
                                entidad.isuso = modelo.isuso;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(2));
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
        public static bool DeleteBorradoLogico(int id, CedulaHallazgosModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET estadohallazgo = 'B' WHERE idhallazgo={0};", id);
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

        internal static void UpdateModeloReodenar(CedulaHallazgosModelo modelo)
        {
            if (!(modelo == null))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.hallazgos SET orden = {0} WHERE idhallazgo={1};", modelo.orden, modelo.idhallazgo);
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

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET estadohallazgo = 'B' WHERE idcedula={0};", idCedula);
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

        public static int Delete(ObservableCollection<CedulaHallazgosModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        hallazgo entidadTemporal = new hallazgo();
                        string commandString = string.Empty;
                        foreach (CedulaHallazgosModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idhallazgo);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.hallazgos WHERE idhallazgo={0};", item.idhallazgo);
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

        public static int DeleteLogico(ObservableCollection<CedulaHallazgosModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        hallazgo entidadTemporal = new hallazgo();
                        string commandString = string.Empty;
                        foreach (CedulaHallazgosModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idhallazgo);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.hallazgos SET estadohallazgo = 'B' WHERE idhallazgo={0};", item.idhallazgo);
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



        public static int Delete(CedulaHallazgosModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idhallazgo != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.hallazgos WHERE idhallazgo={0};", modelo.idhallazgo);
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

        public static int DeleteLogico(CedulaHallazgosModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idhallazgo != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.hallazgos SET estadohallazgo = 'B' WHERE idhallazgo={0};", modelo.idhallazgo);
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
                        BitacoraModelo.DeleteByTransaccion(id, "HALLAZGOS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.hallazgos WHERE idhallazgo={0};", id);
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
                        BitacoraModelo.DeleteByTransaccion(idCedula, "HALLAZGOS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.hallazgos WHERE idcedula={0};", idCedula);
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
        public static void DeleteByRange(ObservableCollection<hallazgo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.hallazgos.RemoveRange(lista);
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
                        string commandString = String.Format("DELETE FROM sgpt.hallazgos WHERE idhallazgo={0};", id);
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


        public static int DeleteBorradoLogico(ObservableCollection<CedulaHallazgosModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    hallazgo entidadTemporal = new hallazgo();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaHallazgosModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idhallazgo);//Borra todas las referencias dentro  de bitacora
                                                                                         //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idhallazgo);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.hallazgos SET estadohallazgo = 'B' WHERE idhallazgo={0};", item.idhallazgo);
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

        internal static List<CedulaHallazgosModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idcedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.hallazgos.Select(entidad =>
                     new CedulaHallazgosModelo
                     {
                         idhallazgo = entidad.idhallazgo,
                         idcedula = entidad.idcedula,
                         detidcedula = entidad.detidcedula,
                         idcorrespondencia = entidad.idcorrespondencia,
                         descripcionhallazgo = entidad.descripcionhallazgo,
                         referenciahallazgo = entidad.referenciahallazgo,
                         fechacreadohallazgo = entidad.fechacreadohallazgo,
                         baselegalhallazgo = entidad.baselegalhallazgo,
                         recomendacionhallazgo = entidad.recomendacionhallazgo,
                         respuestaclientehallazgo = entidad.respuestaclientehallazgo,
                         fecharespclientehallazgo = entidad.fecharespclientehallazgo,
                         estadohallazgo = entidad.estadohallazgo,
                         titulohallazgo = entidad.titulohallazgo,
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
                         orden = entidad.orden,

                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idhallazgo).Where(x => x.estadohallazgo == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idcedula == idcedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaHallazgosModelo item in lista)
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<hallazgo> lista, int idhallazgo)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.hallazgos SET estadohallazgo = 'B' WHERE idhallazgo = {0};", idhallazgo);
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
        public static explicit operator hallazgo(CedulaHallazgosModelo modelo)  // explicit byte to digit conversion operator
        {
            hallazgo entidad = new hallazgo();
            entidad.idhallazgo = modelo.idhallazgo;
            entidad.idcedula = modelo.idcedula;
            entidad.descripcionhallazgo = modelo.descripcionhallazgo;
            entidad.baselegalhallazgo = modelo.baselegalhallazgo;
            entidad.fechacreadohallazgo = modelo.fechacreadohallazgo;
            entidad.recomendacionhallazgo = modelo.recomendacionhallazgo;
            entidad.respuestaclientehallazgo = modelo.respuestaclientehallazgo;
            entidad.estadohallazgo = modelo.estadohallazgo;
            entidad.titulohallazgo = modelo.titulohallazgo;
            entidad.idencargo = modelo.idencargo;
            entidad.referenciahallazgo = modelo.referenciahallazgo;
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
            entidad.orden = modelo.orden;
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

                            string commandString = String.Format("DELETE FROM sgpt.hallazgos WHERE idhallazgo={0};", id);
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

        public static List<CedulaHallazgosModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.hallazgos.Select(entidad =>
                     new CedulaHallazgosModelo
                     {
                         idhallazgo = entidad.idhallazgo,
                         idcedula = entidad.idcedula,
                         descripcionhallazgo = entidad.descripcionhallazgo,
                         baselegalhallazgo = entidad.baselegalhallazgo,
                         fechacreadohallazgo = entidad.fechacreadohallazgo,
                         recomendacionhallazgo = entidad.recomendacionhallazgo,
                         respuestaclientehallazgo = entidad.respuestaclientehallazgo,
                         estadohallazgo = entidad.estadohallazgo,
                         titulohallazgo = entidad.titulohallazgo,
                         idencargo = entidad.idencargo,
                         referenciahallazgo = entidad.referenciahallazgo,
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
                         orden = entidad.orden,
                         guardadoBase = true,
                         IsSelected = false,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idhallazgo).Where(x => x.estadohallazgo == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaHallazgosModelo item in lista)
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

        internal static int UpdateCierre(CedulaHallazgosModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idhallazgo;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idhallazgo = {3};",
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

        internal static int UpdateReferencia(CedulaHallazgosModelo modelo)
        {
            int id = modelo.idhallazgo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET referenciahallazgo = '{0}',etapapapel ='{1}' WHERE idhallazgo={2};", modelo.referenciahallazgo, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(CedulaHallazgosModelo modelo)
        {
            int id = modelo.idhallazgo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idhallazgo = {3};",
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

        internal static int UpdateAprobacion(CedulaHallazgosModelo modelo)
        {
            int id = modelo.idhallazgo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idhallazgo = {3};",
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

        internal static int UpdateAprobacionSupervision(CedulaHallazgosModelo modelo)
        {
            int id = modelo.idhallazgo;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "HALLAZGOS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.hallazgos SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idhallazgo = {5};",
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

        public static ObservableCollection<CedulaHallazgosModelo> GetAllEdicion(EncargoModelo encargo, int idCedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.hallazgos.Select(entidad =>
                     new CedulaHallazgosModelo
                     {
                         idhallazgo = entidad.idhallazgo,
                         idcedula = entidad.idcedula,
                         detidcedula = entidad.detidcedula,
                         idcorrespondencia = entidad.idcorrespondencia,
                         descripcionhallazgo = entidad.descripcionhallazgo,
                         referenciahallazgo = entidad.referenciahallazgo,
                         fechacreadohallazgo = entidad.fechacreadohallazgo,
                         baselegalhallazgo = entidad.baselegalhallazgo,
                         recomendacionhallazgo = entidad.recomendacionhallazgo,
                         respuestaclientehallazgo = entidad.respuestaclientehallazgo,
                         fecharespclientehallazgo = entidad.fecharespclientehallazgo,
                         estadohallazgo = entidad.estadohallazgo,
                         titulohallazgo = entidad.titulohallazgo,
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
                         orden = entidad.orden,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idhallazgo).Where(x => x.estadohallazgo == "A" && x.idencargo == encargo.idencargo && x.idcedula == idCedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaHallazgosModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                    }
                    return new ObservableCollection<CedulaHallazgosModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista \n" + e);
                }
                return new ObservableCollection<CedulaHallazgosModelo>();
            }
        }

        internal static CedulaHallazgosModelo GetRegistro(int idHallazgo)
        {
            var entidad = new CedulaHallazgosModelo();
            if (!(idHallazgo == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    hallazgo modelo = _context.hallazgos.Find(idHallazgo);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idhallazgo = modelo.idhallazgo;
                        entidad.idcedula = modelo.idcedula;
                        entidad.detidcedula = modelo.detidcedula;
                        entidad.idcorrespondencia = modelo.idcorrespondencia;
                        entidad.descripcionhallazgo = modelo.descripcionhallazgo;
                        entidad.referenciahallazgo = modelo.referenciahallazgo;
                        entidad.fechacreadohallazgo = modelo.fechacreadohallazgo;
                        entidad.baselegalhallazgo = modelo.baselegalhallazgo;
                        entidad.recomendacionhallazgo = modelo.recomendacionhallazgo;
                        entidad.respuestaclientehallazgo = modelo.respuestaclientehallazgo;
                        entidad.fecharespclientehallazgo = modelo.fecharespclientehallazgo;
                        entidad.estadohallazgo = modelo.estadohallazgo;
                        entidad.titulohallazgo = modelo.titulohallazgo;
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
                        entidad.orden = modelo.orden;
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

        public static ObservableCollection<hallazgo> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.hallazgos.Where(entidad => (entidad.idencargo == idencargo && entidad.estadohallazgo == "A"));
                    ObservableCollection<hallazgo> temporal = new ObservableCollection<hallazgo>(lista);
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
                    //var lista = _context.hallazgos.Where(x => x.estadohallazgo == "A" && x.idcedula == idcedula);
                    var lista = (from p in _context.hallazgos
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.hallazgos.RemoveRange(lista);
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
                    elementos = _context.hallazgos.Where(x => x.idhallazgo == id && x.estadohallazgo == "A").Count();
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
                    elementos = (int)_context.hallazgos.Single(x => x.idhallazgo == id && x.estadohallazgo == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(CedulaHallazgosModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.descripcionhallazgo) || string.IsNullOrWhiteSpace(documento.descripcionhallazgo))))
            {
                string busqueda = documento.descripcionhallazgo.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.hallazgos.Where(x => x.descripcionhallazgo.ToUpper() == busqueda && x.estadohallazgo == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public CedulaHallazgosModelo()
        {
            idhallazgo = 0;
            idcedula = null;
            detidcedula = null;
            idcorrespondencia = null;
            descripcionhallazgo = null;
            referenciahallazgo = null;
            fechacreadohallazgo = MetodosModelo.homologacionFecha();
            baselegalhallazgo = null;
            recomendacionhallazgo = null;
            respuestaclientehallazgo = null;
            fecharespclientehallazgo = null;
            estadohallazgo = "A";
            titulohallazgo = null;
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
            orden = null;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
        }
        public CedulaHallazgosModelo(EncargoModelo encargo)
        {
            idhallazgo = 0;
            idcedula = null;
            detidcedula = null;
            idcorrespondencia = null;
            descripcionhallazgo = null;
            referenciahallazgo = null;
            fechacreadohallazgo = MetodosModelo.homologacionFecha();
            baselegalhallazgo = null;
            recomendacionhallazgo = null;
            respuestaclientehallazgo = null;
            fecharespclientehallazgo = null;
            estadohallazgo = "A";
            titulohallazgo = null;
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
            orden = null;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
        }

        internal static int evaluarCerrar(CedulaHallazgosModelo currentEntidad)
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

        internal static int evaluarBorrar(CedulaHallazgosModelo currentEntidad)
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

        public CedulaHallazgosModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idhallazgo = 0;
            idcedula = null;
            detidcedula = null;
            idcorrespondencia = null;
            descripcionhallazgo = null;
            referenciahallazgo = null;
            fechacreadohallazgo = MetodosModelo.homologacionFecha();
            baselegalhallazgo = null;
            recomendacionhallazgo = null;
            respuestaclientehallazgo = null;
            fecharespclientehallazgo = null;
            estadohallazgo = "A";
            titulohallazgo = null;
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
            orden = null;
            usuarioModelo =usuario;
            IsSelected = false;
            guardadoBase = false; ;
        }

        public CedulaHallazgosModelo(CedulaModelo currentMaestro, EncargoModelo encargo, UsuarioModelo usuario)
        {
            idhallazgo = 0;
            idcedula = currentMaestro.idcedula;
            detidcedula = null;
            idcorrespondencia = null;
            descripcionhallazgo = null;
            referenciahallazgo = null;
            fechacreadohallazgo = MetodosModelo.homologacionFecha();
            baselegalhallazgo = null;
            recomendacionhallazgo = null;
            respuestaclientehallazgo = null;
            fecharespclientehallazgo = null;
            estadohallazgo = "A";
            titulohallazgo = null;
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
            orden = null;
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false; ;
        }

    }

}
