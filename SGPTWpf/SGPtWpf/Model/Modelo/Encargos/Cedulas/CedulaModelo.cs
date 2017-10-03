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
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas
{

    public class CedulaModelo : UIBase
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

        public int _idcedula;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int idcedula
        {
            get { return _idcedula; }
            set { _idcedula = value; }
        }

        #endregion
        public int? idvisita
        {
            get { return GetValue(() => idvisita); }
            set { SetValue(() => idvisita, value); }
        }
        public int? idindice
        {
            get { return GetValue(() => idindice); }
            set { SetValue(() => idindice, value); }
        }
        public int? idtc
        {
            get { return GetValue(() => idtc); }
            set { SetValue(() => idtc, value); }
        }
        public int? idrepositorio
        {
            get { return GetValue(() => idrepositorio); }
            set { SetValue(() => idrepositorio, value); }
        }
        //Encargo al  que corresponde la evaluacion
        public int? idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }

        [DisplayName("Nombre del  documento")]
        [Required(ErrorMessage = "Debe ingresar el nombre de la cédula")]
        [MaxLength(100, ErrorMessage = "No debe de exceder 100 caracteres")]
        [MinLength(5, ErrorMessage = "Debe ser mayor a 5 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string titulocedula
        {
            get { return GetValue(() => titulocedula); }
            set { SetValue(() => titulocedula, value); }
        }
        public string etapapapel
        {
            get { return GetValue(() => etapapapel); }
            set { SetValue(() => etapapapel, value); }
        }

        public string fechacreadocedula
        {
            get { return GetValue(() => fechacreadocedula); }
            set { SetValue(() => fechacreadocedula, value); }
        }

        [DisplayName("Conclusión")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(5, ErrorMessage = "Debe ser mayor a 5 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string conclusioncedula
        {
            get { return GetValue(() => conclusioncedula); }
            set { SetValue(() => conclusioncedula, value); }
        }

        [DisplayName("Objetivo")]
        //[Required(ErrorMessage = "Debe ingresar el nombre de la cédula")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(5, ErrorMessage = "Debe ser mayor a 5 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string objetivocedula
        {
            get { return GetValue(() => objetivocedula); }
            set { SetValue(() => objetivocedula, value); }
        }

        [DisplayName("Alcance")]
        //[Required(ErrorMessage = "Debe ingresar el nombre de la cédula")]
        [MaxLength(250, ErrorMessage = "No debe de exceder 250 caracteres")]
        [MinLength(5, ErrorMessage = "Debe ser mayor a 5 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string alcancecedula 
        {
            get { return GetValue(() => alcancecedula ); }
            set { SetValue(() => alcancecedula , value); }
        }

        //Permite la gestión del borrado lógico de los elementos identificándose por A) Activo, B) Borrado
        public string estadocedula
        {
            get { return GetValue(() => estadocedula); }
            set { SetValue(() => estadocedula, value); }
        }


        //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }

        //Almacena la referencia para el  papel de  trabajo
        [DisplayName("Referencia de la  evaluación")]
        //[Required(ErrorMessage = "Debe ingresar la referencia del documento")]
        [MaxLength(30, ErrorMessage = "No debe de exceder 30 caracteres")]
        [MinLength(3, ErrorMessage = "Debe ser mayor a 3 letras")]
        [ExcludeChar("!@", ErrorMessage = "No puede contener !@")]
        public string referenciacedula
        {
            get { return GetValue(() => referenciacedula); }
            set { SetValue(() => referenciacedula, value); }
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


        public int? idbalance
        {
            get { return GetValue(() => idbalance); }
            set { SetValue(() => idbalance, value); }
        }

        public int? padreidcedula
        {
            get { return GetValue(() => padreidcedula); }
            set { SetValue(() => padreidcedula, value); }
        }

        public int? idbalanceanterior
        {
            get { return GetValue(() => idbalanceanterior); }
            set { SetValue(() => idbalanceanterior, value); }
        }


        #region Propiedades adiciones de fechas

        public cedula entidadBase
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

        public string descripciontc
        {
            get { return GetValue(() => descripciontc); }
            set { SetValue(() => descripciontc, value); }
        }
        public string descripcionTipoAuditoriaPrograma
        {
            get { return GetValue(() => descripcionTipoAuditoriaPrograma); }
            set { SetValue(() => descripcionTipoAuditoriaPrograma, value); }
        }
        public string descripcionvisita
        {
            get { return GetValue(() => descripcionvisita); }
            set { SetValue(() => descripcionvisita, value); }
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

        #region Propiedades de balance

        public string fechabalancebalance
        {
            get { return GetValue(() => fechabalancebalance); }
            set { SetValue(() => fechabalancebalance, value); }
        }

        //Clase de balance
        public string periodicidadperiodos
        {
            get { return GetValue(() => periodicidadperiodos); }
            set { SetValue(() => periodicidadperiodos, value); }
        }

        public string descripcioncb
        {
            get { return GetValue(() => descripcioncb); }
            set { SetValue(() => descripcioncb, value); }
        }

        public string fechabalancebalanceComparativo
        {
            get { return GetValue(() => fechabalancebalanceComparativo); }
            set { SetValue(() => fechabalancebalanceComparativo, value); }
        }

        //Clase de balance
        public string periodicidadperiodosComparativo
        {
            get { return GetValue(() => periodicidadperiodosComparativo); }
            set { SetValue(() => periodicidadperiodosComparativo, value); }
        }

        public string descripcioncbComparativo
        {
            get { return GetValue(() => descripcioncbComparativo); }
            set { SetValue(() => descripcioncbComparativo, value); }
        }

        public decimal? ordencedula
        {
            get { return GetValue(() => ordencedula); }
            set { SetValue(() => ordencedula, value); }
        }
        #endregion

        #region propiedades de resumen

        public decimal? saldoactualdc { get { return GetValue(() => saldoactualdc); } set { SetValue(() => saldoactualdc, value); } }
        public decimal? saldoanteriordc { get { return GetValue(() => saldoanteriordc); } set { SetValue(() => saldoanteriordc, value); } }
        public decimal? aumentodc { get { return GetValue(() => aumentodc); } set { SetValue(() => aumentodc, value); } }
        public decimal? disminuciondc { get { return GetValue(() => disminuciondc); } set { SetValue(() => disminuciondc, value); } }
        public decimal? saldofinaldc { get { return GetValue(() => saldofinaldc); } set { SetValue(() => saldofinaldc, value); } }

        public decimal? cargoreajuste { get { return GetValue(() => cargoreajuste); } set { SetValue(() => cargoreajuste, value); } }
        public decimal? abonoreajuste { get { return GetValue(() => abonoreajuste); } set { SetValue(() => abonoreajuste, value); } }
        public decimal? cargoreclasificacion { get { return GetValue(() => cargoreclasificacion); } set { SetValue(() => cargoreclasificacion, value); } }
        public decimal? abonoreclasificacion { get { return GetValue(() => abonoreclasificacion); } set { SetValue(() => abonoreclasificacion, value); } }
        public decimal? cargosreajusteyreclasificacion { get { return GetValue(() => cargosreajusteyreclasificacion); } set { SetValue(() => cargosreajusteyreclasificacion, value); } }
        public decimal? abonoreajusteyreclasificacion { get { return GetValue(() => abonoreajusteyreclasificacion); } set { SetValue(() => abonoreajusteyreclasificacion, value); } }

        public decimal? variacionporcentual { get { return GetValue(() => variacionporcentual); } set { SetValue(() => variacionporcentual, value); } }
        public decimal? saldoreajustado { get { return GetValue(() => saldoreajustado); } set { SetValue(() => saldoreajustado, value); } }

        public int? idagenda { get { return GetValue(() => idagenda); } set { SetValue(() => idagenda, value); } }

        public string tiposaldocc
        {
            get { return GetValue(() => tiposaldocc); }
            set { SetValue(() => tiposaldocc, value); }
        }

        public string claseregistro
        {
            get { return GetValue(() => claseregistro); }
            set { SetValue(() => claseregistro, value); }
        }
        public string elementoFinanciero
        {
            get { return GetValue(() => elementoFinanciero); }
            set { SetValue(() => elementoFinanciero, value); }
        }

        #endregion para gestion de resumen


        #region colecciones virtuales

        public virtual BitacoraModelo bitacoraModelo
        {
            get { return GetValue(() => bitacoraModelo); }
            set { SetValue(() => bitacoraModelo, value); }
        }

        public virtual CedulaModelo cedulaModelo
        {
            get { return GetValue(() => cedulaModelo); }
            set { SetValue(() => cedulaModelo, value); }
        }

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion

        #region detalleCedula

        public ObservableCollection<DetalleCedulaModelo> _listaDetalleCedula;
        public ObservableCollection<DetalleCedulaModelo> listaDetalleCedula
        {
            get { return _listaDetalleCedula; }
            set { _listaDetalleCedula = value; }
        }

        #endregion

        //Permite evitar duplicacion el critero periodicidad, clase balance, fecha 
        public ObservableCollection<CedulaModelo> listaEntidadSeleccion
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

        public static int Insert(CedulaModelo modelo, bool resultado)
        {
           if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.cedulas', 'idcedula'), (SELECT MAX(idcedula) FROM sgpt.cedulas) + 1);");
                            sincronizar = true;
                        }
                        modelo.ordencedula = _context.cedulas.Where(x => x.idencargo== modelo.idencargo && x.estadocedula == "A").Count()+1;
                        var tablaDestino = new cedula
                        {
                            //idcedula = modelo.idcedula,
                            idvisita = modelo.idvisita,
                            idindice = modelo.idindice,
                            idtc = modelo.idtc,
                            idrepositorio = modelo.idrepositorio,
                            idencargo = modelo.idencargo,
                            titulocedula = modelo.titulocedula,
                            etapapapel = modelo.etapapapel,
                            fechacreadocedula = modelo.fechacreadocedula,
                            conclusioncedula = modelo.conclusioncedula,
                            objetivocedula = modelo.objetivocedula,
                            alcancecedula = modelo.alcancecedula,
                            estadocedula = modelo.estadocedula,
                            isuso = modelo.isuso,
                            referenciacedula = modelo.referenciacedula,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            idbalance = modelo.idbalance,
                            idbalanceanterior = modelo.idbalanceanterior,
                            padreidcedula=modelo.padreidcedula,
                            ordencedula = modelo.ordencedula,
                        };
                        _context.cedulas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idcedula = tablaDestino.idcedula;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            //modelo.listaBitacora.Add(temporal);
                        }

                        return 1;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n " + e);
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        public static bool InsertCapaDatos(cedula modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.cedulas', 'idcedula'), (SELECT MAX(idcedula) FROM sgpt.cedulas) + 1);");
                            sincronizar = true;
                        }
                        modelo.ordencedula = _context.cedulas.Where(x => x.idencargo == modelo.idencargo && x.estadocedula == "A").Count() + 1;
                        _context.cedulas.Add(modelo);
                        _context.SaveChanges();
                        modelo.idcedula = modelo.idcedula;
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
        public static int Insert(CedulaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.cedulas', 'idcedula'), (SELECT MAX(idcedula) FROM sgpt.cedulas) + 1);");
                            sincronizar = true;
                        }
                        modelo.ordencedula = _context.cedulas.Where(x => x.idencargo == modelo.idencargo && x.estadocedula == "A").Count() + 1;
                        var tablaDestino = new cedula
                        {
                            //idcedula = modelo.idcedula,
                            idvisita = modelo.idvisita,
                            idindice = modelo.idindice,
                            idtc = modelo.idtc,
                            idrepositorio = modelo.idrepositorio,
                            idencargo = modelo.idencargo,
                            titulocedula = modelo.titulocedula,
                            etapapapel = modelo.etapapapel,
                            fechacreadocedula = modelo.fechacreadocedula,
                            conclusioncedula = modelo.conclusioncedula,
                            objetivocedula = modelo.objetivocedula,
                            alcancecedula = modelo.alcancecedula,
                            estadocedula = modelo.estadocedula,
                            isuso = modelo.isuso,
                            referenciacedula = modelo.referenciacedula,
                            idgenerico = modelo.idgenerico,
                            tabla = modelo.tabla,
                            usuariocerro = modelo.usuariocerro,
                            usuarioaprobo = modelo.usuarioaprobo,
                            usuariosuperviso = modelo.usuariosuperviso,
                            fechasupervision = modelo.fechasupervision,
                            fechaaprobacion = modelo.fechaaprobacion,
                            fechacierre = modelo.fechacierre,
                            idbalance = modelo.idbalance,
                            idbalanceanterior = modelo.idbalanceanterior,
                            padreidcedula=modelo.padreidcedula,
                            ordencedula = modelo.ordencedula,
                        };
                        _context.cedulas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idcedula = tablaDestino.idcedula;
                        //guardar la referencia
                        result = 1;
                        foreach (DetalleCedulaModelo item in modelo.listaDetalleCedula)
                        {
                            item.idcedula = modelo.idcedula;
                            try
                            {
                                item.aumentodc = item.saldoactualdc - item.saldoanteriordc;
                                if (item.saldoanteriordc != null && item.saldoanteriordc != 0)
                                {
                                    item.disminuciondc = (item.aumentodc / item.saldoanteriordc) * 100;
                                }
                                //Se envian los detalles
                                switch (DetalleCedulaModelo.Insert(item))
                                {
                                    case 0://No se pudo insertar
                                        result = 2;
                                        break;
                                    case 1://Se inserto con éxito

                                        break;
                                    case -1:
                                        result = -2;
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                result = -2;
                                MessageBox.Show("No ha sido posible insertar el registro \n"+e);
                            }
                        }
                        #region insercion de totales
                        
                        //Insercion de totales
                        try
                        {
                            DetalleCedulaModelo total = new DetalleCedulaModelo(modelo.listaDetalleCedula, modelo.usuarioModelo, (int)modelo.idencargo, "+",modelo);
                            switch (DetalleCedulaModelo.Insert(total))
                            {
                                case 0://No se pudo insertar
                                    result = 2;
                                    break;
                                case 1://Se inserto con éxito

                                    break;
                                case -1:
                                    result = -2;
                                    break;
                            }
                            modelo.listaDetalleCedula.Add(total);
                        }
                        catch (Exception e)
                        {
                            result = -2;
                            MessageBox.Show("No ha sido posible insertar el total \n" + e);
                        }

                        #endregion
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        BitacoraModelo.Insert(temporal, 1);
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

        //Permite almacenar cuentas particulares que se adicionen a la cédula.
        public static int InsertCuentas(CedulaModelo modelo)
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

                        CedulaModelo tablaDestino = modelo;
                        //guardar la referencia
                        foreach (DetalleCedulaModelo item in modelo.listaDetalleCedula)
                        {
                            if (item.iddc==0 && item.isuso==0 && item.claseregistro=="D")//Solo registros nuevos
                            {
                                item.idcedula = modelo.idcedula;
                                try
                                {
                                    item.aumentodc = item.saldoactualdc - item.saldoanteriordc;
                                    if (item.saldoanteriordc != null && item.saldoanteriordc != 0)
                                    {
                                        item.disminuciondc = (item.aumentodc / item.saldoanteriordc) * 100;
                                    }
                                    //Se envian los detalles
                                    switch (DetalleCedulaModelo.Insert(item))
                                    {
                                        case 0://No se pudo insertar
                                            result = 2;
                                            break;
                                        case 1://Se inserto con éxito
                                            result = 1;
                                            break;
                                        case -1:
                                            result = -2;
                                            break;
                                    }
                                }
                                catch (Exception e)
                                {
                                    result = -2;
                                    MessageBox.Show("No ha sido posible insertar el registro \n" + e);
                                }
                            }
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

        public static CedulaModelo Find(int id)
        {
            var entidad = new CedulaModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //cedula modelo = _context.cedulas.Find(id);
                        cedula modelo = _context.cedulas.Single(x => x.idcedula == id);
                        if (modelo != null)
                        {
                            entidad.idcedula = modelo.idcedula;
                            entidad.idvisita = modelo.idvisita;
                            entidad.idindice = modelo.idindice;
                            entidad.idtc = modelo.idtc;
                            entidad.idrepositorio = modelo.idrepositorio;
                            entidad.idencargo = modelo.idencargo;
                            entidad.titulocedula = modelo.titulocedula;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.fechacreadocedula = modelo.fechacreadocedula;
                            entidad.conclusioncedula = modelo.conclusioncedula;
                            entidad.objetivocedula = modelo.objetivocedula;
                            entidad.alcancecedula = modelo.alcancecedula;
                            entidad.estadocedula = modelo.estadocedula;
                            entidad.isuso = modelo.isuso;
                            entidad.referenciacedula = modelo.referenciacedula;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.idbalance = modelo.idbalance;
                            entidad.idbalanceanterior = modelo.idbalanceanterior;
                            entidad.entidadBase = modelo;
                            entidad.ordencedula = modelo.ordencedula;
                            entidad.padreidcedula = modelo.padreidcedula;
                            return entidad;
                        }
                        else
                        {
                            return new CedulaModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new CedulaModelo();
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
                    var modelo = new CedulaModelo();
                    cedula entidad = _context.cedulas.Find(id);
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
                    var modelo = new CedulaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.cedulas
                            .Where(b => b.estadocedula == "B")
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
                    cedula entidad = _context.cedulas.Find(id);
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

        public static void UpdateModelo(CedulaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    cedula entidad = _context.cedulas.Find(modelo.idcedula);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        if (entidad.idvisita != modelo.idvisita) { cambiar = true; }
                        if (entidad.idindice != modelo.idindice) { cambiar = true; }
                        if (entidad.idtc != modelo.idtc) { cambiar = true; }
                        if (entidad.idrepositorio != modelo.idrepositorio) { cambiar = true; }
                        if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                        if (entidad.titulocedula != modelo.titulocedula) { cambiar = true; }
                        if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                        if (entidad.fechacreadocedula != modelo.fechacreadocedula) { cambiar = true; }
                        if (entidad.conclusioncedula != modelo.conclusioncedula) { cambiar = true; }
                        if (entidad.objetivocedula != modelo.objetivocedula) { cambiar = true; }
                        if (entidad.alcancecedula != modelo.alcancecedula) { cambiar = true; }
                        if (entidad.estadocedula != modelo.estadocedula) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }
                        if (entidad.referenciacedula != modelo.referenciacedula) { cambiar = true; }
                        if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        if (entidad.idbalance != modelo.idbalance) { cambiar = true; }
                        if (entidad.idbalanceanterior != modelo.idbalanceanterior) { cambiar = true; }
                        if (entidad.ordencedula != modelo.ordencedula) { cambiar = true; }
                        if (cambiar)
                        {
                            entidad.idcedula = modelo.idcedula;
                            entidad.idvisita = modelo.idvisita;
                            entidad.idindice = modelo.idindice;
                            entidad.idtc = modelo.idtc;
                            entidad.idrepositorio = modelo.idrepositorio;
                            entidad.idencargo = modelo.idencargo;
                            entidad.titulocedula = modelo.titulocedula;
                            entidad.etapapapel = modelo.etapapapel;
                            entidad.fechacreadocedula = modelo.fechacreadocedula;
                            entidad.conclusioncedula = modelo.conclusioncedula;
                            entidad.objetivocedula = modelo.objetivocedula;
                            entidad.alcancecedula = modelo.alcancecedula;
                            entidad.estadocedula = modelo.estadocedula;
                            entidad.isuso = modelo.isuso;
                            entidad.referenciacedula = modelo.referenciacedula;
                            entidad.idgenerico = modelo.idgenerico;
                            entidad.tabla = modelo.tabla;
                            entidad.usuariocerro = modelo.usuariocerro;
                            entidad.usuarioaprobo = modelo.usuarioaprobo;
                            entidad.usuariosuperviso = modelo.usuariosuperviso;
                            entidad.fechasupervision = modelo.fechasupervision;
                            entidad.fechaaprobacion = modelo.fechaaprobacion;
                            entidad.fechacierre = modelo.fechacierre;
                            entidad.idbalance = modelo.idbalance;
                            entidad.idbalanceanterior = modelo.idbalanceanterior;
                            entidad.ordencedula = modelo.ordencedula;
                            entidad.padreidcedula = modelo.padreidcedula;
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

        public static int UpdateModelo(CedulaModelo modelo, Boolean actualizar)
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
                        cedula entidad = _context.cedulas.Find(modelo.idcedula);
                        if (entidad == null)
                        {
                            return respuesta;
                        }
                        else
                        {
                            if (entidad.idvisita != modelo.idvisita) { cambiar = true; }
                            if (entidad.titulocedula != modelo.titulocedula) { cambiar = true; }
                            if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                            if (entidad.fechacreadocedula != modelo.fechacreadocedula) { cambiar = true; }
                            if (entidad.ordencedula != modelo.ordencedula) { cambiar = true; }
                            if (entidad.conclusioncedula != modelo.conclusioncedula) { cambiar = true; }
                            if (entidad.objetivocedula != modelo.objetivocedula) { cambiar = true; }
                            if (entidad.alcancecedula != modelo.alcancecedula) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            if (cambiar)
                            {
                                //entidad.idcedula = modelo.idcedula;
                                entidad.idvisita = modelo.idvisita;
                                entidad.titulocedula = modelo.titulocedula;
                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2);
                                entidad.fechacreadocedula = MetodosModelo.homologacionFecha();
                                entidad.conclusioncedula = modelo.conclusioncedula;
                                entidad.objetivocedula = modelo.objetivocedula;
                                entidad.alcancecedula = modelo.alcancecedula;
                                entidad.isuso = modelo.isuso;
                                entidad.ordencedula = modelo.ordencedula;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(2));
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
        public static bool DeleteBorradoLogico(int id, CedulaModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET estadocedula = 'B' WHERE idcedula={0};", id);
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



        public static int Delete(ObservableCollection<CedulaModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        cedula entidadTemporal = new cedula();
                        string commandString = string.Empty;
                        foreach (CedulaModelo item in lista)
                        {
                            //Continuar
                            //Borrar registros dependientes
                            DetalleCedulaModelo.Delete(item.idcedula);
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.idcedula);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.cedulas WHERE idcedula={0};", item.idcedula);
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

        public static int DeleteLogico(ObservableCollection<CedulaModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        cedula entidadTemporal = new cedula();
                        string commandString = string.Empty;
                        foreach (CedulaModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idcedula);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.cedulas SET estadocedula = 'B' WHERE idcedula={0};", item.idcedula);
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



        public static int Delete(CedulaModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idtc != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            //éxito en la operacion
                            //Continuar
                            //Borrar registros dependientes
                            DetalleCedulaModelo.Delete(modelo.idcedula);
                            //Borrado de bitacora
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(modelo.idcedula, "CEDULAS");//Borra todas las referencias dentro  de bitacora
                            //Borrar el propio registro
                            string commandString = String.Format("DELETE FROM sgpt.cedulas WHERE idcedula={0};", modelo.idcedula);
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

        public static int DeleteLogico(CedulaModelo modelo)
        {
            int result = 0;
            if (modelo != null && modelo.idtc != 0)
            {
                {

                    try
                    {
                        //Debe borrar los hijos
                        using (_context = new SGPTEntidades())
                        {
                            DetalleCedulaModelo.DeleteBorradoLogicoByIdCedula(modelo.idcedula);
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(modelo.idcedula, "CEDULAS");//Borra todas las referencias dentro  de bitacora

                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.cedulas SET estadocedula = 'B' WHERE idcedula={0};", modelo.idcedula);
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
                        BitacoraModelo.DeleteByTransaccion(id, "CEDULAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.cedulas WHERE idcedula={0};", id);
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

        public static void DeleteByRange(ObservableCollection<cedula> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.cedulas.RemoveRange(lista);
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

                        //DetalleCedulaModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.cedulas WHERE idcedula={0};", id);
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
                            string commandString = String.Format("UPDATE sgpt.cedulas SET  usuarioaprobo ='{0}', fechacierre ='{1}'," +
                                "fechasupervision ='{2}', fechaaprobacion ='{3}', usuariocerro ='{4}', usuariosuperviso ='{5}', " +
                                " etapapapel ='{6}' WHERE idcedula={7};",
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


        public static int DeleteBorradoLogico(ObservableCollection<CedulaModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    cedula entidadTemporal = new cedula();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CedulaModelo item in lista)
                        {
                            #region detallecedula

                            DetalleCedulaModelo.DeleteBorradoLogicoByIdCedula(item.idcedula);

                            #endregion

                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idcedula);//Borra todas las referencias dentro  de bitacora
                                                                                                  //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.idcedula);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.cedulas SET estadocedula = 'B' WHERE idcedula={0};", item.idcedula);
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

        internal static List<CedulaModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idtc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Select(entidad =>
                     new CedulaModelo
                     {
                         idcedula = entidad.idcedula,
                         idvisita = entidad.idvisita,
                         idindice = entidad.idindice,
                         idtc = entidad.idtc,
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         titulocedula = entidad.titulocedula,
                         etapapapel = entidad.etapapapel,
                         fechacreadocedula = entidad.fechacreadocedula,
                         conclusioncedula = entidad.conclusioncedula,
                         objetivocedula = entidad.objetivocedula,
                         alcancecedula = entidad.alcancecedula,
                         estadocedula = entidad.estadocedula,
                         isuso = entidad.isuso,
                         referenciacedula = entidad.referenciacedula,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         idbalance = entidad.idbalance,
                         idbalanceanterior = entidad.idbalanceanterior,
                         ordencedula = entidad.ordencedula,
                         padreidcedula=entidad.padreidcedula,

                         descripciontc = entidad.tiposcedula.descripciontc,
                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,

                         fechabalancebalanceComparativo = entidad.balance1.fechabalancebalance,
                         descripcioncbComparativo = entidad.balance1.clasesbalance.descripcioncb,
                         periodicidadperiodosComparativo = entidad.balance1.periodo.periodicidadperiodos,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idtc).Where(x => x.estadocedula == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idtc == idtc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaModelo item in lista)
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

        internal static List<CedulaModelo> GetAllByEncargosImportacionOtros(EncargoModelo encargo, int? idtc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Select(entidad =>
                     new CedulaModelo
                     {
                         idcedula = entidad.idcedula,
                         idvisita = entidad.idvisita,
                         idindice = entidad.idindice,
                         idtc = entidad.idtc,
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         titulocedula = entidad.titulocedula,
                         etapapapel = entidad.etapapapel,
                         fechacreadocedula = entidad.fechacreadocedula,
                         conclusioncedula = entidad.conclusioncedula,
                         objetivocedula = entidad.objetivocedula,
                         alcancecedula = entidad.alcancecedula,
                         estadocedula = entidad.estadocedula,
                         isuso = entidad.isuso,
                         referenciacedula = entidad.referenciacedula,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         idbalance = entidad.idbalance,
                         idbalanceanterior = entidad.idbalanceanterior,
                         padreidcedula=entidad.padreidcedula,

                         ordencedula=entidad.ordencedula,
                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,

                         fechabalancebalanceComparativo = entidad.balance1.fechabalancebalance,
                         descripcioncbComparativo = entidad.balance1.clasesbalance.descripcioncb,
                         periodicidadperiodosComparativo = entidad.balance1.periodo.periodicidadperiodos,
                         //Lista filtrada de elementos que fueron eliminados
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idtc).Where(x => x.estadocedula == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idtc != 2
                                                          && x.idtc != 7
                                                          && x.idtc != 8).ToList();
                                                            /*
                                                            1; "Sumaria"; "A"; TRUE
                                                            2; "Analítica"; "A"; TRUE
                                                            3; "De detalle"; "A"; TRUE
                                                            4; "De variaciones"; "A"; TRUE
                                                            5; "Cumplimiento legal"; "A"; TRUE
                                                            6; "Hallazgos"; "A"; TRUE
                                                            7; "Notas"; "A"; TRUE
                                                            8; "Correspondencia"; "A"; TRUE
                                                            9; "Reuniones"; "A"; TRUE
                                                            10; "Contactos"; "A"; TRUE
                                                            11; "Expediente"; "A"; TRUE
                                                            12; "Cronograma"; "A"; TRUE
                                                            13; "Marcas"; "A"; TRUE
                                                            14; "Confirmaciones"; "A"; TRUE
                                                            15; "Ajustes y reclasificaciones"; "A"; TRUE
                                                            */
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaModelo item in lista)
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

         public static bool DeleteBorradoLogicoTotal(ObservableCollection<cedula> lista, int idcedula)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.cedulas SET estadocedula = 'B' WHERE idcedula = {0};", idcedula);
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
        public static explicit operator cedula(CedulaModelo modelo)  // explicit byte to digit conversion operator
        {
            cedula entidad = new cedula();
            entidad.idcedula = modelo.idcedula;
            entidad.idvisita = modelo.idvisita;
            entidad.idindice = modelo.idindice;
            entidad.idtc = modelo.idtc;
            entidad.idrepositorio = modelo.idrepositorio;
            entidad.idencargo = modelo.idencargo;
            entidad.titulocedula = modelo.titulocedula;
            entidad.etapapapel = modelo.etapapapel;
            entidad.fechacreadocedula = modelo.fechacreadocedula;
            entidad.conclusioncedula = modelo.conclusioncedula;
            entidad.objetivocedula = modelo.objetivocedula;
            entidad.alcancecedula = modelo.alcancecedula;
            entidad.estadocedula = modelo.estadocedula;
            entidad.isuso = modelo.isuso;
            entidad.referenciacedula = modelo.referenciacedula;
            entidad.idgenerico = modelo.idgenerico;
            entidad.tabla = modelo.tabla;
            entidad.usuariocerro = modelo.usuariocerro;
            entidad.usuarioaprobo = modelo.usuarioaprobo;
            entidad.usuariosuperviso = modelo.usuariosuperviso;
            entidad.fechasupervision = modelo.fechasupervision;
            entidad.fechaaprobacion = modelo.fechaaprobacion;
            entidad.fechacierre = modelo.fechacierre;
            entidad.idbalance = modelo.idbalance;
            entidad.idbalanceanterior = modelo.idbalanceanterior;
            entidad.ordencedula = modelo.ordencedula;
            entidad.padreidcedula = modelo.padreidcedula;
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

                            string commandString = String.Format("DELETE FROM sgpt.cedulas WHERE idcedula={0};", id);
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

        public static List<CedulaModelo> GetAll(EncargoModelo encargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Select(entidad =>
                     new CedulaModelo
                     {
                         idcedula = entidad.idcedula,
                         idvisita = entidad.idvisita,
                         idindice = entidad.idindice,
                         idtc = entidad.idtc,
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         titulocedula = entidad.titulocedula,
                         etapapapel = entidad.etapapapel,
                         fechacreadocedula = entidad.fechacreadocedula,
                         conclusioncedula = entidad.conclusioncedula,
                         objetivocedula = entidad.objetivocedula,
                         alcancecedula = entidad.alcancecedula,
                         estadocedula = entidad.estadocedula,
                         isuso = entidad.isuso,
                         referenciacedula = entidad.referenciacedula,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         idbalance = entidad.idbalance,
                         idbalanceanterior = entidad.idbalanceanterior,
                         descripcionvisita = entidad.visita.descripcionvisita,
                         descripciontc = entidad.tiposcedula.descripciontc,
                         padreidcedula=entidad.padreidcedula,

                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,

                         fechabalancebalanceComparativo = entidad.balance1.fechabalancebalance,
                         descripcioncbComparativo = entidad.balance1.clasesbalance.descripcioncb,
                         periodicidadperiodosComparativo = entidad.balance1.periodo.periodicidadperiodos,
                         //Lista filtrada de elementos que fueron eliminados
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idcedula).Where(x => x.estadocedula == "A" && x.idencargo == encargo.idencargo).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        //Buscar en bitacora
                        item.usuariocreo = string.Empty;
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


        public static List<CedulaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Select(entidad =>
                     new CedulaModelo
                     {
                         idcedula = entidad.idcedula,
                         idvisita = entidad.idvisita,
                         idindice = entidad.idindice,
                         idtc = entidad.idtc,
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         titulocedula = entidad.titulocedula,
                         etapapapel = entidad.etapapapel,
                         fechacreadocedula = entidad.fechacreadocedula,
                         conclusioncedula = entidad.conclusioncedula,
                         objetivocedula = entidad.objetivocedula,
                         alcancecedula = entidad.alcancecedula,
                         estadocedula = entidad.estadocedula,
                         isuso = entidad.isuso,
                         referenciacedula = entidad.referenciacedula,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         idbalance = entidad.idbalance,
                         idbalanceanterior = entidad.idbalanceanterior,
                         ordencedula=entidad.ordencedula,
                         padreidcedula=entidad.padreidcedula,
                         

                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,
                         descripciontc = entidad.tiposcedula.descripciontc,
                         fechabalancebalanceComparativo = entidad.balance1.fechabalancebalance,
                         descripcioncbComparativo = entidad.balance1.clasesbalance.descripcioncb,
                         periodicidadperiodosComparativo = entidad.balance1.periodo.periodicidadperiodos,
                         //Lista filtrada de elementos que fueron eliminados
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idtc).Where(x => x.estadocedula == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaModelo item in lista)
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

        public static List<CedulaModelo> GetAll(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Select(entidad =>
                     new CedulaModelo
                     {
                         idcedula = entidad.idcedula,
                         idvisita = entidad.idvisita,
                         idindice = entidad.idindice,
                         idtc = entidad.idtc,
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         titulocedula = entidad.titulocedula,
                         etapapapel = entidad.etapapapel,
                         fechacreadocedula = entidad.fechacreadocedula,
                         conclusioncedula = entidad.conclusioncedula,
                         objetivocedula = entidad.objetivocedula,
                         alcancecedula = entidad.alcancecedula,
                         estadocedula = entidad.estadocedula,
                         isuso = entidad.isuso,
                         referenciacedula = entidad.referenciacedula,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         idbalance = entidad.idbalance,
                         idbalanceanterior = entidad.idbalanceanterior,
                         ordencedula=entidad.ordencedula,
                         padreidcedula=entidad.padreidcedula,

                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,
                         descripciontc = entidad.tiposcedula.descripciontc,
                         fechabalancebalanceComparativo = entidad.balance1.fechabalancebalance,
                         descripcioncbComparativo = entidad.balance1.clasesbalance.descripcioncb,
                         periodicidadperiodosComparativo = entidad.balance1.periodo.periodicidadperiodos,
                         //Lista filtrada de elementos que fueron eliminados
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idtc).Where(x => x.estadocedula == "A" && x.idencargo==idEncargo).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (CedulaModelo item in lista)
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


        internal static int UpdateCierre(CedulaModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.idcedula;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE idcedula = {3};",
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
        internal static int UpdateCierre(CedulaModelo modelo, UsuarioModelo usuarioModelo,string conclusion)
        {
            int id = modelo.idcedula;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}', conclusioncedula='{3}'  WHERE idcedula = {4};",
                                usuarioModelo.inicialesusuario,
                                modelo.fechacierre,
                                EtapaEncargoModelo.seleccionEtapaIniciales(4),
                                conclusion,
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

        internal static int UpdateReferencia(CedulaModelo modelo)
        {
            int id = modelo.idcedula;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET referenciacedula = '{0}',etapapapel ='{1}' WHERE idcedula={2};", modelo.referenciacedula, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(CedulaModelo modelo)
        {
            int id = modelo.idcedula;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE idcedula = {3};",
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

        internal static int UpdateAprobacion(CedulaModelo modelo)
        {
            int id = modelo.idcedula;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE idcedula = {3};",
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

        internal static int UpdateAprobacionSupervision(CedulaModelo modelo)
        {
            int id = modelo.idcedula;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "CEDULAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.cedulas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE idcedula = {5};",
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

        public static List<CedulaModelo> GetAll(EncargoModelo encargo, int idtc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Select(entidad =>
                     new CedulaModelo
                     {
                         idcedula = entidad.idcedula,
                         idvisita = entidad.idvisita,
                         idindice = entidad.idindice,
                         idtc = entidad.idtc,
                         idrepositorio = entidad.idrepositorio,
                         idencargo = entidad.idencargo,
                         titulocedula = entidad.titulocedula,
                         etapapapel = entidad.etapapapel,
                         fechacreadocedula = entidad.fechacreadocedula,
                         conclusioncedula = entidad.conclusioncedula,
                         objetivocedula = entidad.objetivocedula,
                         alcancecedula = entidad.alcancecedula,
                         estadocedula = entidad.estadocedula,
                         isuso = entidad.isuso,
                         referenciacedula = entidad.referenciacedula,
                         idgenerico = entidad.idgenerico,
                         tabla = entidad.tabla,
                         usuariocerro = entidad.usuariocerro,
                         usuarioaprobo = entidad.usuarioaprobo,
                         usuariosuperviso = entidad.usuariosuperviso,
                         fechasupervision = entidad.fechasupervision,
                         fechaaprobacion = entidad.fechaaprobacion,
                         fechacierre = entidad.fechacierre,
                         idbalance = entidad.idbalance,
                         idbalanceanterior = entidad.idbalanceanterior,
                         descripcionvisita=entidad.visita.descripcionvisita,
                         ordencedula=entidad.ordencedula,
                         padreidcedula=entidad.padreidcedula,

                         fechabalancebalance = entidad.balance.fechabalancebalance,
                         descripcioncb = entidad.balance.clasesbalance.descripcioncb,
                         periodicidadperiodos = entidad.balance.periodo.periodicidadperiodos,
                         descripciontc = entidad.tiposcedula.descripciontc,
                         fechabalancebalanceComparativo = entidad.balance1.fechabalancebalance,
                         descripcioncbComparativo = entidad.balance1.clasesbalance.descripcioncb,
                         periodicidadperiodosComparativo = entidad.balance1.periodo.periodicidadperiodos,
                         //Lista filtrada de elementos que fueron eliminados
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idcedula).Where(x => x.estadocedula == "A" && x.idencargo == encargo.idencargo && x.idtc == idtc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CedulaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        //Buscar en bitacora
                        item.usuariocreo = string.Empty;
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


        public static ObservableCollection<CedulaModelo> GetAllResumen(int idEncargo, int idTc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = (from pd in _context.cedulas
                                 join od in _context.detallecedulas on pd.idcedula equals od.idcedula
                                 where pd.idencargo == idEncargo && pd.idtc==idTc && od.claseregistro=="S"
                                 orderby pd.ordencedula
                                 select new CedulaModelo
                                 {
                                     idcedula = pd.idcedula,
                                     idvisita = pd.idvisita,
                                     idindice = pd.idindice,
                                     idtc = pd.idtc,
                                     idrepositorio = pd.idrepositorio,
                                     idencargo = pd.idencargo,
                                     titulocedula = pd.titulocedula,
                                     etapapapel = pd.etapapapel,
                                     fechacreadocedula = pd.fechacreadocedula,
                                     conclusioncedula = pd.conclusioncedula,
                                     objetivocedula = pd.objetivocedula,
                                     alcancecedula = pd.alcancecedula,
                                     estadocedula = pd.estadocedula,
                                     isuso = pd.isuso,
                                     referenciacedula = pd.referenciacedula,
                                     idgenerico = pd.idgenerico,
                                     tabla = pd.tabla,
                                     usuariocerro = pd.usuariocerro,
                                     usuarioaprobo = pd.usuarioaprobo,
                                     usuariosuperviso = pd.usuariosuperviso,
                                     fechasupervision = pd.fechasupervision,
                                     fechaaprobacion = pd.fechaaprobacion,
                                     fechacierre = pd.fechacierre,
                                     idbalance = pd.idbalance,
                                     idbalanceanterior = pd.idbalanceanterior,
                                     descripcionvisita = pd.visita.descripcionvisita,
                                     ordencedula = pd.ordencedula,
                                     padreidcedula=pd.padreidcedula,

                                     elementoFinanciero = od.codigocontabledc,

                                     fechabalancebalance = pd.balance.fechabalancebalance,
                                     descripcioncb = pd.balance.clasesbalance.descripcioncb,
                                     periodicidadperiodos = pd.balance.periodo.periodicidadperiodos,
                                     descripciontc = pd.tiposcedula.descripciontc,
                                     fechabalancebalanceComparativo = pd.balance1.fechabalancebalance,
                                     descripcioncbComparativo = pd.balance1.clasesbalance.descripcioncb,
                                     periodicidadperiodosComparativo = pd.balance1.periodo.periodicidadperiodos,
                                      
                                     saldoactualdc = od.saldoactualdc,
                                     saldoanteriordc = od.saldoanteriordc,
                                     aumentodc = od.aumentodc,
                                     disminuciondc = od.disminuciondc,
                                     saldofinaldc = od.saldofinaldc,
                                     cargoreajuste = od.cargoreajuste,
                                     abonoreajuste = od.abonoreajuste,
                                     cargoreclasificacion = od.cargoreclasificacion,
                                     abonoreclasificacion = od.abonoreclasificacion,
                                     idagenda = od.idagenda,
                                     cargosreajusteyreclasificacion = od.cargoreajuste + od.cargoreajuste,
                                     abonoreajusteyreclasificacion = od.abonoreajuste + od.abonoreajuste,
                                     tiposaldocc = od.catalogocuenta.tiposaldocc,
                                     claseregistro="D",

                                 }).ToList().OrderBy(o => o.elementoFinanciero).ThenBy(r=>r.ordencedula).Where(x => x.estadocedula == "A");
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    ObservableCollection<CedulaModelo> listaTemporal = new ObservableCollection<CedulaModelo>(lista.ToList());
                    int elementoBuscado = 0;
                    int posicion = 0;
                    CedulaModelo cedulaElemento = new CedulaModelo();
                    for (int k = 0; k < 8; k++)
                    {
                        elementoBuscado = k + 1;
                        if(listaTemporal.Count(x=>x.elementoFinanciero== elementoBuscado.ToString())>0)
                        {
                            cedulaElemento = listaTemporal.Last(x => x.elementoFinanciero == elementoBuscado.ToString());
                            posicion = listaTemporal.IndexOf(cedulaElemento);
                            listaTemporal.Insert(posicion+1,new CedulaModelo(listaTemporal, elementoBuscado.ToString(),cedulaElemento));
                        }
                        cedulaElemento = new CedulaModelo();
                    }
                    listaTemporal.OrderBy(o => o.elementoFinanciero).ThenBy(r => r.ordencedula);
                    foreach (CedulaModelo item in listaTemporal)
                    {
                        item.idCorrelativo = i;
                        i++;
                        if (item.aumentodc != null && item.aumentodc != 0 && item.saldoanteriordc != null && item.saldoanteriordc != 0)
                        {
                            item.variacionporcentual = item.aumentodc / item.saldoanteriordc;
                        }
                    }

                    return new ObservableCollection<CedulaModelo>(listaTemporal);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista comparativa  \n" + e);
                }
                return null;
            }
        }

        public static ObservableCollection<CedulaModelo> GetAllResumen(int idEncargo, int idTc, int idVisita)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = (from pd in _context.cedulas
                                 join od in _context.detallecedulas on pd.idcedula equals od.idcedula
                                 where pd.idencargo == idEncargo && pd.idtc == idTc && od.claseregistro == "S" &&  pd.idvisita==idVisita
                                 orderby pd.ordencedula
                                 select new CedulaModelo
                                 {
                                     idcedula = pd.idcedula,
                                     idvisita = pd.idvisita,
                                     idindice = pd.idindice,
                                     idtc = pd.idtc,
                                     idrepositorio = pd.idrepositorio,
                                     idencargo = pd.idencargo,
                                     titulocedula = pd.titulocedula,
                                     etapapapel = pd.etapapapel,
                                     fechacreadocedula = pd.fechacreadocedula,
                                     conclusioncedula = pd.conclusioncedula,
                                     objetivocedula = pd.objetivocedula,
                                     alcancecedula = pd.alcancecedula,
                                     estadocedula = pd.estadocedula,
                                     isuso = pd.isuso,
                                     referenciacedula = pd.referenciacedula,
                                     idgenerico = pd.idgenerico,
                                     tabla = pd.tabla,
                                     usuariocerro = pd.usuariocerro,
                                     usuarioaprobo = pd.usuarioaprobo,
                                     usuariosuperviso = pd.usuariosuperviso,
                                     fechasupervision = pd.fechasupervision,
                                     fechaaprobacion = pd.fechaaprobacion,
                                     fechacierre = pd.fechacierre,
                                     idbalance = pd.idbalance,
                                     idbalanceanterior = pd.idbalanceanterior,
                                     descripcionvisita = pd.visita.descripcionvisita,
                                     ordencedula = pd.ordencedula,
                                     padreidcedula=pd.padreidcedula,

                                     elementoFinanciero = od.codigocontabledc,

                                     fechabalancebalance = pd.balance.fechabalancebalance,
                                     descripcioncb = pd.balance.clasesbalance.descripcioncb,
                                     periodicidadperiodos = pd.balance.periodo.periodicidadperiodos,
                                     descripciontc = pd.tiposcedula.descripciontc,
                                     fechabalancebalanceComparativo = pd.balance1.fechabalancebalance,
                                     descripcioncbComparativo = pd.balance1.clasesbalance.descripcioncb,
                                     periodicidadperiodosComparativo = pd.balance1.periodo.periodicidadperiodos,

                                     saldoactualdc = od.saldoactualdc,
                                     saldoanteriordc = od.saldoanteriordc,
                                     aumentodc = od.aumentodc,
                                     disminuciondc = od.disminuciondc,
                                     saldofinaldc = od.saldofinaldc,
                                     cargoreajuste = od.cargoreajuste,
                                     abonoreajuste = od.abonoreajuste,
                                     cargoreclasificacion = od.cargoreclasificacion,
                                     abonoreclasificacion = od.abonoreclasificacion,
                                     idagenda = od.idagenda,
                                     cargosreajusteyreclasificacion = od.cargoreajuste + od.cargoreajuste,
                                     abonoreajusteyreclasificacion = od.abonoreajuste + od.abonoreajuste,
                                     tiposaldocc = od.catalogocuenta.tiposaldocc,
                                     claseregistro = "D",

                                 }).ToList().OrderBy(o => o.elementoFinanciero).ThenBy(r => r.ordencedula).Where(x => x.estadocedula == "A");
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    ObservableCollection<CedulaModelo> listaTemporal = new ObservableCollection<CedulaModelo>(lista.ToList());
                    int elementoBuscado = 0;
                    int posicion = 0;
                    CedulaModelo cedulaElemento = new CedulaModelo();
                    for (int k = 0; k < 8; k++)
                    {
                        elementoBuscado = k + 1;
                        if (listaTemporal.Count(x => x.elementoFinanciero == elementoBuscado.ToString()) > 0)
                        {
                            cedulaElemento = listaTemporal.Last(x => x.elementoFinanciero == elementoBuscado.ToString());
                            posicion = listaTemporal.IndexOf(cedulaElemento);
                            listaTemporal.Insert(posicion + 1, new CedulaModelo(listaTemporal, elementoBuscado.ToString(), cedulaElemento));
                        }
                        cedulaElemento = new CedulaModelo();
                    }
                    listaTemporal.OrderBy(o => o.elementoFinanciero).ThenBy(r => r.ordencedula);
                    foreach (CedulaModelo item in listaTemporal)
                    {
                        item.idCorrelativo = i;
                        i++;
                        if (item.aumentodc != null && item.aumentodc != 0 && item.saldoanteriordc!=null && item.saldoanteriordc!=0)
                        {
                            item.variacionporcentual = item.aumentodc / item.saldoanteriordc;
                        }
                    }

                    return new ObservableCollection<CedulaModelo>(listaTemporal);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista comparativa  \n" + e);
                }
                return null;
            }
        }


        public CedulaModelo(ObservableCollection<CedulaModelo> listaRegistro, string idElementoFinanciero,CedulaModelo temporal)
        {
            try
            {
                ObservableCollection<CedulaModelo> lista = new ObservableCollection<CedulaModelo>(listaRegistro.Where(x => x.elementoFinanciero == idElementoFinanciero));
                string clase = string.Empty;
                if (lista.Count > 0)
                {
                    switch (idElementoFinanciero)
                    {
                        case "1":
                            clase = "Activos";
                            break;
                        case "2":
                            clase = "Pasivo";
                            break;
                        case "3":
                            clase = "Patrimonio";
                            break;
                        case "4":
                            clase = "Costos y gastos";
                            break;
                        case "5":
                            clase = "Ingresos o ventas";
                            break;
                        case "6":
                            clase = "Cuentas de cierre";
                            break;
                        case "7":
                            clase = "Cuentas de orden";
                            break;
                        case "8":
                            clase = "Cuentas de orden por contra";
                            break;
                    }
                    //CedulaModelo temporal = lista.FirstOrDefault(x => x.elementoFinanciero == idElementoFinanciero);
                    idcedula = temporal.idcedula;
                    idvisita = temporal.idvisita;
                    idindice = temporal.idindice;
                    idtc = temporal.idtc;
                    idrepositorio = temporal.idrepositorio;
                    idencargo = temporal.idencargo;
                    titulocedula = "Total de " + clase;
                    etapapapel = temporal.etapapapel;
                    fechacreadocedula = temporal.fechacreadocedula;
                    conclusioncedula = temporal.conclusioncedula;
                    objetivocedula = temporal.objetivocedula;
                    alcancecedula = temporal.alcancecedula;
                    estadocedula = temporal.estadocedula;
                    isuso = temporal.isuso;
                    referenciacedula = temporal.referenciacedula;
                    idgenerico = temporal.idgenerico;
                    tabla = temporal.tabla;
                    usuariocerro = temporal.usuariocerro;
                    usuarioaprobo = temporal.usuarioaprobo;
                    usuariosuperviso = temporal.usuariosuperviso;
                    fechasupervision = temporal.fechasupervision;
                    fechaaprobacion = temporal.fechaaprobacion;
                    fechacierre = temporal.fechacierre;
                    idbalance = temporal.idbalance;
                    idbalanceanterior = temporal.idbalanceanterior;
                    descripcionvisita = temporal.descripcionvisita;
                    padreidcedula = temporal.padreidcedula;

                    ordencedula = temporal.ordencedula+(decimal)0.25;
                    elementoFinanciero =idElementoFinanciero;

                    fechabalancebalance = temporal.fechabalancebalance;
                    descripcioncb = temporal.descripcioncb;
                    periodicidadperiodos = temporal.periodicidadperiodos;
                    descripciontc = temporal.descripciontc;
                    fechabalancebalanceComparativo = temporal.fechabalancebalance;
                    descripcioncbComparativo = temporal.descripcioncb;
                    periodicidadperiodosComparativo = temporal.periodicidadperiodos;

                    saldoactualdc = lista.Sum(x => x.saldoactualdc);

                    saldoanteriordc = lista.Sum(x => x.saldoanteriordc);
                    aumentodc = lista.Sum(x => x.aumentodc);
                    disminuciondc = lista.Sum(x => x.disminuciondc);
                    saldofinaldc = lista.Sum(x => x.saldofinaldc);
                    cargoreajuste = lista.Sum(x => x.cargoreajuste);
                    abonoreajuste = lista.Sum(x => x.abonoreajuste);
                    cargoreclasificacion = lista.Sum(x => x.cargoreclasificacion);
                    abonoreclasificacion = lista.Sum(x => x.abonoreclasificacion);
                    idagenda = temporal.idagenda;
                    cargosreajusteyreclasificacion = cargoreajuste + cargoreajuste;
                    abonoreajusteyreclasificacion = abonoreajuste + abonoreajuste;
                    tiposaldocc = temporal.tiposaldocc;
                    claseregistro = "S";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception creación de registro resumen  \n" + e);
            }
            }



        internal static CedulaModelo GetRegistro(int idgenericoindice)
        {
            var entidad = new CedulaModelo();
            if (!(idgenericoindice == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    cedula modelo = _context.cedulas.Find(idgenericoindice);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idcedula = modelo.idcedula;
                        entidad.idvisita = modelo.idvisita;
                        entidad.idindice = modelo.idindice;
                        entidad.idtc = modelo.idtc;
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.idencargo = modelo.idencargo;
                        entidad.titulocedula = modelo.titulocedula;
                        entidad.etapapapel = modelo.etapapapel;
                        entidad.fechacreadocedula = modelo.fechacreadocedula;
                        entidad.conclusioncedula = modelo.conclusioncedula;
                        entidad.objetivocedula = modelo.objetivocedula;
                        entidad.alcancecedula = modelo.alcancecedula;
                        entidad.estadocedula = modelo.estadocedula;
                        entidad.isuso = modelo.isuso;
                        entidad.referenciacedula = modelo.referenciacedula;
                        entidad.idgenerico = modelo.idgenerico;
                        entidad.tabla = modelo.tabla;
                        entidad.usuariocerro = modelo.usuariocerro;
                        entidad.usuarioaprobo = modelo.usuarioaprobo;
                        entidad.usuariosuperviso = modelo.usuariosuperviso;
                        entidad.fechasupervision = modelo.fechasupervision;
                        entidad.fechaaprobacion = modelo.fechaaprobacion;
                        entidad.fechacierre = modelo.fechacierre;
                        entidad.idbalance = modelo.idbalance;
                        entidad.idbalanceanterior = modelo.idbalanceanterior;
                        entidad.ordencedula = modelo.ordencedula;
                        entidad.padreidcedula = modelo.padreidcedula;

                        int i = 1;
                        var listaBitacora = BitacoraModelo.GetAllByTabla("CEDULAS");
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

        public static ObservableCollection<cedula> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.cedulas.Where(entidad => (entidad.idencargo == idencargo && entidad.estadocedula == "A"));
                    ObservableCollection<cedula> temporal = new ObservableCollection<cedula>(lista);
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
                    //var lista = _context.cedulas.Where(x => x.estadocedula == "A" && x.idvisita == idvisita);
                    var lista = (from p in _context.cedulas
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.cedulas.RemoveRange(lista);
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
                    elementos = _context.cedulas.Where(x => x.idcedula == id && x.estadocedula == "A").Count();
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
                    elementos = (int)_context.cedulas.Single(x => x.idcedula == id && x.estadocedula == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(CedulaModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.titulocedula) || string.IsNullOrWhiteSpace(documento.titulocedula))))
            {
                string busqueda = documento.titulocedula.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.cedulas.Where(x => x.titulocedula.ToUpper() == busqueda && x.estadocedula == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        public static CedulaModelo FindMaestro(int idEncargo, int idTc,string titulocedula)
        {
            cedula modelo = new cedula();
            CedulaModelo entidad = new CedulaModelo();
            try
            {
                string busqueda = titulocedula.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    modelo = _context.cedulas.SingleOrDefault(x => x.titulocedula.ToUpper() == busqueda && x.estadocedula == "A"
                    && x.idencargo == idEncargo && x.idtc == idTc);
                }
                if (modelo == null)
                {
                    return entidad;
                }
                else
                {
                    entidad.idcedula = modelo.idcedula;
                    entidad.idvisita = modelo.idvisita;
                    entidad.idindice = modelo.idindice;
                    entidad.idtc = modelo.idtc;
                    entidad.idrepositorio = modelo.idrepositorio;
                    entidad.idencargo = modelo.idencargo;
                    entidad.titulocedula = modelo.titulocedula;
                    entidad.etapapapel = modelo.etapapapel;
                    entidad.fechacreadocedula = modelo.fechacreadocedula;
                    entidad.conclusioncedula = modelo.conclusioncedula;
                    entidad.objetivocedula = modelo.objetivocedula;
                    entidad.alcancecedula = modelo.alcancecedula;
                    entidad.estadocedula = modelo.estadocedula;
                    entidad.isuso = modelo.isuso;
                    entidad.referenciacedula = modelo.referenciacedula;
                    entidad.idgenerico = modelo.idgenerico;
                    entidad.tabla = modelo.tabla;
                    entidad.usuariocerro = modelo.usuariocerro;
                    entidad.usuarioaprobo = modelo.usuarioaprobo;
                    entidad.usuariosuperviso = modelo.usuariosuperviso;
                    entidad.fechasupervision = modelo.fechasupervision;
                    entidad.fechaaprobacion = modelo.fechaaprobacion;
                    entidad.fechacierre = modelo.fechacierre;
                    entidad.idbalance = modelo.idbalance;
                    entidad.idbalanceanterior = modelo.idbalanceanterior;
                    entidad.ordencedula = modelo.ordencedula;
                    entidad.padreidcedula = modelo.padreidcedula;
                    return entidad;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar el registro \n" + e);
                entidad.idcedula = -1;
                return entidad;
            }

        }

        public static CedulaModelo FindMaestro(int idEncargo, int idTc, string titulocedula,int? idVisita)
        {
            cedula modelo = new cedula();
            CedulaModelo entidad = new CedulaModelo();
            ObservableCollection<visita> listaVisita = new ObservableCollection<visita>();
            try
            {
                string busqueda = titulocedula.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    modelo = _context.cedulas.SingleOrDefault(x => x.titulocedula.ToUpper() == busqueda 
                    && x.estadocedula == "A"
                    && x.idencargo == idEncargo 
                    && x.idvisita==idVisita
                    && x.idtc == idTc);
                    var listaVisitas=_context.visitas.OrderBy(o => o.idvisita).Where(x => x.estadovisita == "A").ToList();
                    //La ordena por el ID notar la notacion
                    if ((listaVisitas.Count) > 0)
                    {
                        listaVisita = new ObservableCollection<visita>(listaVisitas);
                    }

                }
                if (modelo == null)
                {
                    return entidad;
                }
                else
                {
                    entidad.idcedula = modelo.idcedula;
                    entidad.idvisita = modelo.idvisita;
                    entidad.idindice = modelo.idindice;
                    entidad.idtc = modelo.idtc;
                    entidad.idrepositorio = modelo.idrepositorio;
                    entidad.idencargo = modelo.idencargo;
                    entidad.titulocedula = modelo.titulocedula;
                    entidad.etapapapel = modelo.etapapapel;
                    entidad.fechacreadocedula = modelo.fechacreadocedula;
                    entidad.conclusioncedula = modelo.conclusioncedula;
                    entidad.objetivocedula = modelo.objetivocedula;
                    entidad.alcancecedula = modelo.alcancecedula;
                    entidad.estadocedula = modelo.estadocedula;
                    entidad.isuso = modelo.isuso;
                    entidad.referenciacedula = modelo.referenciacedula;
                    entidad.idgenerico = modelo.idgenerico;
                    entidad.tabla = modelo.tabla;
                    entidad.usuariocerro = modelo.usuariocerro;
                    entidad.usuarioaprobo = modelo.usuarioaprobo;
                    entidad.usuariosuperviso = modelo.usuariosuperviso;
                    entidad.fechasupervision = modelo.fechasupervision;
                    entidad.fechaaprobacion = modelo.fechaaprobacion;
                    entidad.fechacierre = modelo.fechacierre;
                    entidad.idbalance = modelo.idbalance;
                    entidad.idbalanceanterior = modelo.idbalanceanterior;
                    entidad.ordencedula = modelo.ordencedula;
                    entidad.padreidcedula = modelo.padreidcedula;

                    if (listaVisita.Count > 0 && entidad.idvisita!=null)
                    {
                        entidad.descripcionvisita = listaVisita.Single(x => x.idvisita == entidad.idvisita).descripcionvisita;
                    }
                    else
                    {
                        entidad.descripcionvisita = "";
                    }
                    return entidad;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar el registro \n" + e);
                entidad.idcedula = -1;
                return entidad;
            }

        }

        public CedulaModelo()
        {
            idcedula = 0;
            idvisita = null;
            idindice =null;
            idtc =null;
            idrepositorio =null;
            idencargo =null;
            titulocedula =string.Empty;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            fechacreadocedula = MetodosModelo.homologacionFecha(); ;
            conclusioncedula = string.Empty;
            objetivocedula = string.Empty;
            alcancecedula = string.Empty;
            estadocedula = "A";
            isuso = 0;
            referenciacedula = string.Empty; ;
            idgenerico = null;
            tabla = string.Empty; 
            usuariocerro = string.Empty; 
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            fechacierre = string.Empty;
            idbalance = null;
            idbalanceanterior = null;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            fechabalancebalance = string.Empty;
            descripcioncb = string.Empty;
            periodicidadperiodos = string.Empty;
            ordencedula =0;
            padreidcedula = null;

            fechabalancebalanceComparativo = string.Empty;
            descripcioncbComparativo = string.Empty;
            periodicidadperiodosComparativo = string.Empty;
        }
        public CedulaModelo(EncargoModelo encargo)
        {
            idcedula = 0;
            idvisita = null;
            idindice = null;
            idtc = null;
            idrepositorio = null;
            idencargo = encargo.idencargo;
            titulocedula = string.Empty;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            fechacreadocedula = MetodosModelo.homologacionFecha(); 
            conclusioncedula = string.Empty;
            objetivocedula = string.Empty;
            alcancecedula = string.Empty;
            estadocedula = "A";
            isuso = 0;
            referenciacedula = string.Empty; ;
            idgenerico = null;
            tabla = string.Empty;
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            fechacierre = string.Empty;
            idbalance = null;
            idbalanceanterior = null;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            fechabalancebalance = string.Empty;
            descripcioncb = string.Empty;
            periodicidadperiodos = string.Empty;
            ordencedula = 0;
            padreidcedula = null;

            fechabalancebalanceComparativo = string.Empty;
            descripcioncbComparativo = string.Empty;
            periodicidadperiodosComparativo = string.Empty;
        }

        internal static int evaluarCerrar(CedulaModelo currentEntidad)
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

        internal static int evaluarBorrar(CedulaModelo currentEntidad)
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

        public CedulaModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            idcedula = 0;
            idvisita = null;
            idindice = null;
            idtc = null;
            idrepositorio = null;
            idencargo = encargo.idencargo;
            titulocedula = string.Empty;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            fechacreadocedula = MetodosModelo.homologacionFecha(); ;
            conclusioncedula = string.Empty;
            objetivocedula = string.Empty;
            alcancecedula = string.Empty;
            estadocedula = "A";
            isuso = 0;
            referenciacedula = string.Empty; ;
            idgenerico = null;
            tabla = string.Empty;
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = string.Empty;
            fechaaprobacion = string.Empty;
            fechacierre = string.Empty;
            idbalance = null;
            idbalanceanterior = null;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            usuarioModelo = usuario;
            fechabalancebalance = string.Empty;
            descripcioncb = string.Empty;
            periodicidadperiodos = string.Empty;
            ordencedula = 1;
            padreidcedula = null;

            fechabalancebalanceComparativo = string.Empty;
            descripcioncbComparativo = string.Empty;
            periodicidadperiodosComparativo = string.Empty;
        }

        public CedulaModelo(CedulaModelo entidad, EncargoModelo currentEncargo, UsuarioModelo currentUsuario)
        {
            idcedula = entidad.idcedula;
            idvisita = entidad.idvisita;
            idindice = entidad.idindice;
            idtc = entidad.idtc;
            idrepositorio = entidad.idrepositorio;
            idencargo = currentEncargo.idencargo;
            titulocedula = entidad.titulocedula;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1); 
            fechacreadocedula = MetodosModelo.homologacionFecha();
            conclusioncedula = entidad.conclusioncedula;
            objetivocedula = entidad.objetivocedula;
            alcancecedula = entidad.alcancecedula;
            estadocedula = entidad.estadocedula;
            isuso = entidad.isuso;
            referenciacedula = entidad.referenciacedula;
            idgenerico = entidad.idgenerico;
            tabla = entidad.tabla;
            usuariocerro = entidad.usuariocerro;
            usuarioaprobo = entidad.usuarioaprobo;
            usuariosuperviso = entidad.usuariosuperviso;
            fechasupervision = entidad.fechasupervision;
            fechaaprobacion = entidad.fechaaprobacion;
            fechacierre = entidad.fechacierre;
            idbalance = entidad.idbalance;
            idbalanceanterior = entidad.idbalanceanterior;
            usuarioModelo = currentUsuario;
            padreidcedula = null;

            isuso = 0;
            guardadoBase = false;
            fechabalancebalance = string.Empty;
            descripcioncb = string.Empty;
            periodicidadperiodos = string.Empty;
            ordencedula = 0;
            fechabalancebalanceComparativo = string.Empty;
            descripcioncbComparativo = string.Empty;
            periodicidadperiodosComparativo = string.Empty;
        }
    }

}
