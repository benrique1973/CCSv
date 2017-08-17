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
using SGPTWpf.Model.Modelo.programas;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cedulas
{

    public class DetalleCedulaModelo : UIBase
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
        public int _iddc;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int iddc
        {
            get { return _iddc; }
            set { _iddc = value; }
        }

        #endregion
        public int? idindice
        {
            get { return GetValue(() => idindice); }
            set { SetValue(() => idindice, value); }
        }
        public int? idcedula
        {
            get { return GetValue(() => idcedula); }
            set { SetValue(() => idcedula, value); }
        }

        public int? idpartida
        {
            get { return GetValue(() => idpartida); }
            set { SetValue(() => idpartida, value); }
        }
        public int? padreiddc
        {
            get { return GetValue(() => padreiddc); }
            set { SetValue(() => padreiddc, value); }
        }

        public string codigocontabledc   {  get { return GetValue(() => codigocontabledc); }  set { SetValue(() => codigocontabledc, value); }}
        public string nombrecuenta { get { return GetValue(() => nombrecuenta); } set { SetValue(() => nombrecuenta, value); } }

        public decimal? saldoactualdc   {  get { return GetValue(() => saldoactualdc); }  set { SetValue(() => saldoactualdc, value); }}
        public decimal? saldoanteriordc   {  get { return GetValue(() => saldoanteriordc); }  set { SetValue(() => saldoanteriordc, value); }}
        public decimal? aumentodc   {  get { return GetValue(() => aumentodc); }  set { SetValue(() => aumentodc, value); }}
        public decimal? disminuciondc   {  get { return GetValue(() => disminuciondc); }  set { SetValue(() => disminuciondc, value); }}
        public decimal? saldofinaldc   {  get { return GetValue(() => saldofinaldc); }  set { SetValue(() => saldofinaldc, value); } }
        
        public string descripcionccuentas
        {
            get { return GetValue(() => descripcionccuentas); }
            set { SetValue(() => descripcionccuentas, value); }
        }
        public string fechacreadodc
        {
            get { return GetValue(() => fechacreadodc); }
            set { SetValue(() => fechacreadodc, value); }
        }
        public decimal? ordendc   {  get { return GetValue(() => ordendc); }  set { SetValue(() => ordendc, value); } }


        //Controla el uso concurrente de los registros para evitar datos inconsistentes: 
        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
        }

        //Almacena la referencia para el  papel de  trabajo
        [DisplayName("Referencia de la  evaluación")]
        [Required(ErrorMessage = "Debe ingresar la referencia del documento")]
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


        //Encargo al  que corresponde la evaluacion
        public int? idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }

        public string claseregistro
        {
            get { return GetValue(() => claseregistro); }
            set { SetValue(() => claseregistro, value); }
        }

        public string filasoperadas
        {
            get { return GetValue(() => filasoperadas); }
            set { SetValue(() => filasoperadas, value); }
        }

        public string signooperacion
        {
            get { return GetValue(() => signooperacion); }
            set { SetValue(() => signooperacion, value); }
        }

        public int? idcc
        {
            get { return GetValue(() => idcc); }
            set { SetValue(() => idcc, value); }
        }

        //Permite la gestión del borrado lógico de los elementos identificándose por A) Activo, B) Borrado


        public int? iddb
        {
            get { return GetValue(() => iddb); }
            set { SetValue(() => iddb, value); }
        }
        public int? iddbCompara
        {
            get { return GetValue(() => iddbCompara); }
            set { SetValue(() => iddbCompara, value); }
        }
        public int? idrepositorio
        {
            get { return GetValue(() => idrepositorio); }
            set { SetValue(() => idrepositorio, value); }
        }

        public string estadodc
        {
            get { return GetValue(() => estadodc); }
            set { SetValue(() => estadodc, value); }
        }

            public decimal? cargoreajuste { get { return GetValue(() => cargoreajuste); } set { SetValue(() => cargoreajuste, value); } }
            public decimal? abonoreajuste   {  get { return GetValue(() => abonoreajuste); }  set { SetValue(() => abonoreajuste, value); } }
            public string observaciondc   {  get { return GetValue(() => observaciondc); }  set { SetValue(() => observaciondc, value); }}
            public decimal? cargoreclasificacion   {  get { return GetValue(() => cargoreclasificacion); }  set { SetValue(() => cargoreclasificacion, value); }}
            public decimal? abonoreclasificacion   {  get { return GetValue(() => abonoreclasificacion); }  set { SetValue(() => abonoreclasificacion, value); } }
            public int? idpapeles   {  get { return GetValue(() => idpapeles); }  set { SetValue(() => idpapeles, value); } }


        #region Marcas y notas
           

           //Se usara los primeros 6 para las marcas
           //Se usara del 7 al 12 para notas, iran en parejas 1,7-2,8,-3,9,-4,10,-5,11, 6,12

            public string m1dc { get { return GetValue(() => m1dc); } set { SetValue(() => m1dc, value); } }
            public string m2dc { get { return GetValue(() => m2dc); } set { SetValue(() => m2dc, value); } }

            public string m3dc { get { return GetValue(() => m3dc); } set { SetValue(() => m3dc, value); } }

            public string m4dc { get { return GetValue(() => m4dc); } set { SetValue(() => m4dc, value); } }

            public string m5dc { get { return GetValue(() => m5dc); } set { SetValue(() => m5dc, value); } }

            public string m6dc { get { return GetValue(() => m6dc); } set { SetValue(() => m6dc, value); } }

            public string m7dc { get { return GetValue(() => m7dc); } set { SetValue(() => m7dc, value); } }

            public string m8dc { get { return GetValue(() => m8dc); } set { SetValue(() => m8dc, value); } }

            public string m9dc { get { return GetValue(() => m9dc); } set { SetValue(() => m9dc, value); } }

            public string m10dc { get { return GetValue(() => m10dc); } set { SetValue(() => m10dc, value); } }

            public string m11dc { get { return GetValue(() => m11dc); } set { SetValue(() => m11dc, value); } }

            public string m12dc { get { return GetValue(() => m12dc); } set { SetValue(() => m12dc, value); } }

            public string m13dc { get { return GetValue(() => m13dc); } set { SetValue(() => m13dc, value); } }

            public string m14dc { get { return GetValue(() => m14dc); } set { SetValue(() => m14dc, value); } }

            public string m15dc { get { return GetValue(() => m15dc); } set { SetValue(() => m15dc, value); } }

        #endregion

        #region notas presentacion

        public string nMHP1dc { get { return GetValue(() => nMHP1dc); } set { SetValue(() => nMHP1dc, value); } }
        public string nMHP2dc { get { return GetValue(() => nMHP2dc); } set { SetValue(() => nMHP2dc, value); } }

        public string nMHP3dc { get { return GetValue(() => nMHP3dc); } set { SetValue(() => nMHP3dc, value); } }

        public string nMHP4dc { get { return GetValue(() => nMHP4dc); } set { SetValue(() => nMHP4dc, value); } }

        public string nMHP5dc { get { return GetValue(() => nMHP5dc); } set { SetValue(() => nMHP5dc, value); } }

        public string nMHP6dc { get { return GetValue(() => nMHP6dc); } set { SetValue(() => nMHP6dc, value); } }

        public string nMHP7dc { get { return GetValue(() => nMHP7dc); } set { SetValue(() => nMHP7dc, value); } }

        public string nMHP8dc { get { return GetValue(() => nMHP8dc); } set { SetValue(() => nMHP8dc, value); } }

        public string nMHP9dc { get { return GetValue(() => nMHP9dc); } set { SetValue(() => nMHP9dc, value); } }

        public string nMHP10dc { get { return GetValue(() => nMHP10dc); } set { SetValue(() => nMHP10dc, value); } }

        public string nMHP11dc { get { return GetValue(() => nMHP11dc); } set { SetValue(() => nMHP11dc, value); } }

        public string nMHP12dc { get { return GetValue(() => nMHP12dc); } set { SetValue(() => nMHP12dc, value); } }

        public string nMHP13dc { get { return GetValue(() => nMHP13dc); } set { SetValue(() => nMHP13dc, value); } }

        public string nMHP14dc { get { return GetValue(() => nMHP14dc); } set { SetValue(() => nMHP14dc, value); } }

        public string nMHP15dc { get { return GetValue(() => nMHP15dc); } set { SetValue(() => nMHP15dc, value); } }

        #endregion notas-nMHParcas-presentacion


        #region notas presentacion

        public bool isSelectedMarca1dc { get { return GetValue(() => isSelectedMarca1dc); } set { SetValue(() => isSelectedMarca1dc, value); } }
        public bool isSelectedMarca2dc { get { return GetValue(() => isSelectedMarca2dc); } set { SetValue(() => isSelectedMarca2dc, value); } }

        public bool isSelectedMarca3dc { get { return GetValue(() => isSelectedMarca3dc); } set { SetValue(() => isSelectedMarca3dc, value); } }

        public bool isSelectedMarca4dc { get { return GetValue(() => isSelectedMarca4dc); } set { SetValue(() => isSelectedMarca4dc, value); } }

        public bool isSelectedMarca5dc { get { return GetValue(() => isSelectedMarca5dc); } set { SetValue(() => isSelectedMarca5dc, value); } }

        public bool isSelectedMarca6dc { get { return GetValue(() => isSelectedMarca6dc); } set { SetValue(() => isSelectedMarca6dc, value); } }

        public bool isSelectedMarca7dc { get { return GetValue(() => isSelectedMarca7dc); } set { SetValue(() => isSelectedMarca7dc, value); } }

        public bool isSelectedMarca8dc { get { return GetValue(() => isSelectedMarca8dc); } set { SetValue(() => isSelectedMarca8dc, value); } }

        public bool isSelectedMarca9dc { get { return GetValue(() => isSelectedMarca9dc); } set { SetValue(() => isSelectedMarca9dc, value); } }

        public bool isSelectedMarca10dc { get { return GetValue(() => isSelectedMarca10dc); } set { SetValue(() => isSelectedMarca10dc, value); } }

        public bool isSelectedMarca11dc { get { return GetValue(() => isSelectedMarca11dc); } set { SetValue(() => isSelectedMarca11dc, value); } }

        public bool isSelectedMarca12dc { get { return GetValue(() => isSelectedMarca12dc); } set { SetValue(() => isSelectedMarca12dc, value); } }

        public bool isSelectedMarca13dc { get { return GetValue(() => isSelectedMarca13dc); } set { SetValue(() => isSelectedMarca13dc, value); } }

        public bool isSelectedMarca14dc { get { return GetValue(() => isSelectedMarca14dc); } set { SetValue(() => isSelectedMarca14dc, value); } }

        public bool isSelectedMarca15dc { get { return GetValue(() => isSelectedMarca15dc); } set { SetValue(() => isSelectedMarca15dc, value); } }

        #endregion notas-isSelectedMarcaarcas-presentacion


        public decimal? cargosreajusteyreclasificacion { get { return GetValue(() => cargosreajusteyreclasificacion); } set { SetValue(() => cargosreajusteyreclasificacion, value); } }
        public decimal? abonoreajusteyreclasificacion { get { return GetValue(() => abonoreajusteyreclasificacion); } set { SetValue(() => abonoreajusteyreclasificacion, value); } }


        #region Propiedades adiciones de fechas

        public decimal? variaciónporcentual { get { return GetValue(() => variaciónporcentual); } set { SetValue(() => variaciónporcentual, value); } }
        public decimal? saldoreajustado { get { return GetValue(() => saldoreajustado); } set { SetValue(() => saldoreajustado, value); } }

        
        public detallecedula entidadBase
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

        public int? idnotaspt { get { return GetValue(() => idnotaspt); } set { SetValue(() => idnotaspt, value); } }


        public int? idagenda { get { return GetValue(() => idagenda); } set { SetValue(() => idagenda, value); } }

        public string tiposaldocc
        {
            get { return GetValue(() => tiposaldocc); }
            set { SetValue(() => tiposaldocc, value); }
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
        public string nombreClaseCuenta
        {
            get { return GetValue(() => nombreClaseCuenta); }
            set { SetValue(() => nombreClaseCuenta, value); }
        }

        public int? elementoFinanciero
        {
            get { return GetValue(() => elementoFinanciero); }
            set { SetValue(() => elementoFinanciero, value); }
        }
        #region Control de archivos lanzados

        #endregion


        #region colecciones virtuales

        public virtual BitacoraModelo bitacoraModelo
        {
            get { return GetValue(() => bitacoraModelo); }
            set { SetValue(() => bitacoraModelo, value); }
        }

        public virtual DetalleCedulaModelo detalleCedulaModelo
        {
            get { return GetValue(() => detalleCedulaModelo); }
            set { SetValue(() => detalleCedulaModelo, value); }
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
        public ObservableCollection<DetalleCedulaModelo> listaEntidadSeleccion
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

        public static bool Insert(DetalleCedulaModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecedulas', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecedulas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new detallecedula
                        {
                            //iddc = modelo.iddc,
                            iddc = modelo.iddc,
                            //idindice = modelo.idindice,
                            idcedula = modelo.idcedula,
                            //idpartida = modelo.idpartida,
                            //padreiddc = modelo.padreiddc,
                            codigocontabledc = modelo.codigocontabledc,
                            saldoactualdc = modelo.saldoactualdc,
                            saldoanteriordc = modelo.saldoanteriordc,
                            aumentodc = modelo.aumentodc,
                            disminuciondc = modelo.disminuciondc,
                            saldofinaldc = modelo.saldofinaldc,
                            fechacreadodc = modelo.fechacreadodc,
                            ordendc = (decimal)modelo.ordendc,
                            isuso = modelo.isuso,
                            //referenciapapel = modelo.referenciapapel,
                            //idgenerico = modelo.idgenerico,
                            //tabla = modelo.tabla,
                            //usuariocerro = modelo.usuariocerro,
                            //usuarioaprobo = modelo.usuarioaprobo,
                            //usuariosuperviso = modelo.usuariosuperviso,
                            //fechasupervision = modelo.fechasupervision,
                            //fechaaprobacion = modelo.fechaaprobacion,
                            //fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            idencargo = modelo.idencargo,
                            claseregistro = modelo.claseregistro,
                            //filasoperadas = modelo.filasoperadas,
                            //signooperacion = modelo.signooperacion,
                            idcc = modelo.idcc,
                            iddb = modelo.iddb,
                            //idrepositorio = modelo.idrepositorio,
                            estadodc = modelo.estadodc,
                            nombrecuenta = modelo.nombrecuenta,
                            //cargoreajuste = modelo.cargoreajuste,
                            //abonoreajuste = modelo.abonoreajuste,
                            observaciondc = modelo.observaciondc,
                            //cargoreclasificacion = modelo.cargoreclasificacion,
                            //abonoreclasificacion = modelo.abonoreclasificacion,
                            //idpapeles = modelo.idpapeles,
                            m1dc = modelo.m1dc,
                            m2dc = modelo.m2dc,
                            m3dc = modelo.m3dc,
                            m4dc = modelo.m4dc,
                            m5dc = modelo.m5dc,
                            m6dc = modelo.m6dc,
                            m7dc = modelo.m7dc,
                            m8dc = modelo.m8dc,
                            m9dc = modelo.m9dc,
                            m10dc = modelo.m10dc,
                            m11dc = modelo.m11dc,
                            m12dc = modelo.m12dc,
                            m13dc = modelo.m13dc,
                            m14dc = modelo.m14dc,
                            m15dc = modelo.m15dc,
                            idpapeles = modelo.idpapeles,
                            idnotaspt = modelo.idnotaspt,
                            idagenda = modelo.idagenda,
                        };
                        _context.detallecedulas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.iddc = tablaDestino.iddc;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(1));
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

        public static bool InsertCapaDatos(detallecedula modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecedulas', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecedulas) + 1);");
                            sincronizar = true;
                        }
                        _context.detallecedulas.Add(modelo);
                        _context.SaveChanges();
                        modelo.iddc = modelo.iddc;
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
        public static int Insert(DetalleCedulaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecedulas', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecedulas) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new detallecedula
                        {
                            //iddc = modelo.iddc,
                            //idindice = modelo.idindice,
                            idcedula = modelo.idcedula,
                            //idpartida = modelo.idpartida,
                            //padreiddc = modelo.padreiddc,
                            codigocontabledc = modelo.codigocontabledc,
                            saldoactualdc = modelo.saldoactualdc,
                            saldoanteriordc = modelo.saldoanteriordc,
                            aumentodc = modelo.aumentodc,
                            disminuciondc = modelo.disminuciondc,
                            saldofinaldc = modelo.saldofinaldc,
                            fechacreadodc = modelo.fechacreadodc,
                            ordendc = (decimal)modelo.ordendc,
                            isuso = modelo.isuso,
                            //referenciapapel = modelo.referenciapapel,
                            //idgenerico = modelo.idgenerico,
                            //tabla = modelo.tabla,
                            //usuariocerro = modelo.usuariocerro,
                            //usuarioaprobo = modelo.usuarioaprobo,
                            //usuariosuperviso = modelo.usuariosuperviso,
                            //fechasupervision = modelo.fechasupervision,
                            //fechaaprobacion = modelo.fechaaprobacion,
                            //fechacierre = modelo.fechacierre,
                            etapapapel = modelo.etapapapel,
                            idencargo = modelo.idencargo,
                            claseregistro = modelo.claseregistro,
                            filasoperadas = modelo.filasoperadas,
                            signooperacion = modelo.signooperacion,
                            idcc = modelo.idcc,
                            iddb = modelo.iddb,
                            //idrepositorio = modelo.idrepositorio,
                            estadodc = modelo.estadodc,
                            nombrecuenta = modelo.nombrecuenta,
                            //cargoreajuste = modelo.cargoreajuste,
                            //abonoreajuste = modelo.abonoreajuste,
                            observaciondc = modelo.observaciondc,
                            //cargoreclasificacion = modelo.cargoreclasificacion,
                            //abonoreclasificacion = modelo.abonoreclasificacion,
                            //idpapeles = modelo.idpapeles,
                            m1dc = modelo.m1dc,
                            m2dc = modelo.m2dc,
                            m3dc = modelo.m3dc,
                            m4dc = modelo.m4dc,
                            m5dc = modelo.m5dc,
                            m6dc = modelo.m6dc,
                            m7dc = modelo.m7dc,
                            m8dc = modelo.m8dc,
                            m9dc = modelo.m9dc,
                            m10dc = modelo.m10dc,
                            m11dc = modelo.m11dc,
                            m12dc = modelo.m12dc,
                            m13dc = modelo.m13dc,
                            m14dc = modelo.m14dc,
                            m15dc = modelo.m15dc,
                            idpapeles = modelo.idpapeles,
                            idnotaspt = modelo.idnotaspt,
                            idagenda = modelo.idagenda,

                    };

                        //if (modelo.saldoanteriordc > 0)
                        //{
                        //    tablaDestino.aumentodc = modelo.saldoactualdc - modelo.saldoanteriordc;
                        //    tablaDestino.disminuciondc= (tablaDestino.aumentodc/ modelo.saldoanteriordc)*100;
                        //}
                        tablaDestino.saldofinaldc = modelo.saldoactualdc;
                        _context.detallecedulas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.iddc = tablaDestino.iddc;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(1));
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


        public static int InsertByRangeByCapadatos(ObservableCollection<detallecedula> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallecedulas', 'iddc'), (SELECT MAX(iddc) FROM sgpt.detallecedulas) + 1);");
                            sincronizar = true;
                        }
                        _context.detallecedulas.AddRange(lista);
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

        public static DetalleCedulaModelo Find(int id)
        {
            var entidad = new DetalleCedulaModelo();
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //detallecedula modelo = _context.detallecedulas.Find(id);
                        detallecedula modelo = _context.detallecedulas.Single(x => x.iddc == id);
                        if (modelo != null)
                        {
                            entidad.iddc = modelo.iddc;
                            entidad.idindice = modelo.idindice;
                            entidad.idcedula = modelo.idcedula;
                            entidad.idpartida = modelo.idpartida;
                            entidad.padreiddc = modelo.padreiddc;
                            entidad.codigocontabledc = modelo.codigocontabledc;
                            entidad.saldoactualdc = modelo.saldoactualdc;
                            entidad.m1dc = modelo.m1dc;
                            entidad.m2dc = modelo.m2dc;
                            entidad.saldoanteriordc = modelo.saldoanteriordc;
                            entidad.m3dc = modelo.m3dc;
                            entidad.m4dc = modelo.m4dc;
                            entidad.aumentodc = modelo.aumentodc;
                            entidad.disminuciondc = modelo.disminuciondc;
                            entidad.m5dc = modelo.m5dc;
                            entidad.m6dc = modelo.m6dc;
                            entidad.m7dc = modelo.m7dc;
                            entidad.m8dc = modelo.m8dc;
                            entidad.saldofinaldc = modelo.saldofinaldc;
                            entidad.m9dc = modelo.m9dc;
                            entidad.m10dc = modelo.m10dc;
                            entidad.fechacreadodc = modelo.fechacreadodc;
                            entidad.ordendc = modelo.ordendc;
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
                            entidad.claseregistro = modelo.claseregistro;
                            entidad.filasoperadas = modelo.filasoperadas;
                            entidad.signooperacion = modelo.signooperacion;
                            entidad.idcc = modelo.idcc;
                            entidad.iddb = modelo.iddb;
                            entidad.idrepositorio = modelo.idrepositorio;
                            entidad.estadodc = modelo.estadodc;
                            entidad.nombrecuenta = modelo.nombrecuenta;
                            entidad.cargoreajuste = modelo.cargoreajuste;
                            entidad.abonoreajuste = modelo.abonoreajuste;

                            entidad.cargosreajusteyreclasificacion = modelo.cargoreajuste+ modelo.cargoreajuste;
                            entidad.abonoreajusteyreclasificacion = modelo.abonoreajuste+ modelo.abonoreajuste;

                            entidad.m11dc = modelo.m11dc;
                            entidad.m12dc = modelo.m12dc;
                            entidad.m13dc = modelo.m13dc;
                            entidad.m14dc = modelo.m14dc;
                            entidad.m15dc = modelo.m15dc;
                            entidad.observaciondc = modelo.observaciondc;
                            entidad.cargoreclasificacion = modelo.cargoreclasificacion;
                            entidad.abonoreclasificacion = modelo.abonoreclasificacion;
                            entidad.idpapeles = modelo.idpapeles;
                            entidad.idnotaspt = modelo.idnotaspt;
                            entidad.idagenda = modelo.idagenda;

                            return entidad;
                        }
                        else
                        {
                            return new DetalleCedulaModelo();
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar entidad \n" + e);
                    return new DetalleCedulaModelo();
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
                    var modelo = new DetalleCedulaModelo();
                    detallecedula entidad = _context.detallecedulas.Find(id);
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
                    var modelo = new DetalleCedulaModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detallecedulas
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
                    detallecedula entidad = _context.detallecedulas.Find(id);
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

        public static void UpdateModelo(DetalleCedulaModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detallecedula entidad = _context.detallecedulas.Find(modelo.iddc);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        bool cambiar = false;
                        //if (entidad.iddc != modelo.iddc) { cambiar = true; }
                        if (entidad.idindice != modelo.idindice) { cambiar = true; }
                        //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                        if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                        if (entidad.padreiddc != modelo.padreiddc) { cambiar = true; }
                        if (entidad.codigocontabledc != modelo.codigocontabledc) { cambiar = true; }
                        if (entidad.saldoactualdc != modelo.saldoactualdc) { cambiar = true; }
                        if (entidad.m1dc != modelo.m1dc) { cambiar = true; }
                        if (entidad.m2dc != modelo.m2dc) { cambiar = true; }
                        if (entidad.saldoanteriordc != modelo.saldoanteriordc) { cambiar = true; }
                        if (entidad.m3dc != modelo.m3dc) { cambiar = true; }
                        if (entidad.m4dc != modelo.m4dc) { cambiar = true; }
                        if (entidad.aumentodc != modelo.aumentodc) { cambiar = true; }
                        if (entidad.disminuciondc != modelo.disminuciondc) { cambiar = true; }
                        if (entidad.m5dc != modelo.m5dc) { cambiar = true; }
                        if (entidad.m6dc != modelo.m6dc) { cambiar = true; }
                        if (entidad.m7dc != modelo.m7dc) { cambiar = true; }
                        if (entidad.m8dc != modelo.m8dc) { cambiar = true; }
                        if (entidad.saldofinaldc != modelo.saldofinaldc) { cambiar = true; }
                        if (entidad.m9dc != modelo.m9dc) { cambiar = true; }
                        if (entidad.m10dc != modelo.m10dc) { cambiar = true; }
                        if (entidad.fechacreadodc != modelo.fechacreadodc) { cambiar = true; }
                        if (entidad.ordendc != modelo.ordendc) { cambiar = true; }
                        if (entidad.isuso != modelo.isuso) { cambiar = true; }
                        if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                        //if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                        //if (entidad.tabla != modelo.tabla) { cambiar = true; }
                        //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                        //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                        //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                        //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                        //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                        ////if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                        //if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                        //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                        if (entidad.claseregistro != modelo.claseregistro) { cambiar = true; }
                        if (entidad.filasoperadas != modelo.filasoperadas) { cambiar = true; }
                        if (entidad.signooperacion != modelo.signooperacion) { cambiar = true; }
                        if (entidad.idcc != modelo.idcc) { cambiar = true; }
                        if (entidad.iddb != modelo.iddb) { cambiar = true; }
                        if (entidad.idrepositorio != modelo.idrepositorio) { cambiar = true; }
                        //if (entidad.estadodc != modelo.estadodc) { cambiar = true; }
                        if (entidad.nombrecuenta != modelo.nombrecuenta) { cambiar = true; }
                        if (entidad.cargoreajuste != modelo.cargoreajuste) { cambiar = true; }
                        if (entidad.abonoreajuste != modelo.abonoreajuste) { cambiar = true; }
                        if (entidad.m11dc != modelo.m11dc) { cambiar = true; }
                        if (entidad.m12dc != modelo.m12dc) { cambiar = true; }
                        if (entidad.m13dc != modelo.m13dc) { cambiar = true; }
                        if (entidad.m14dc != modelo.m14dc) { cambiar = true; }
                        if (entidad.m15dc != modelo.m15dc) { cambiar = true; }
                        if (entidad.observaciondc != modelo.observaciondc) { cambiar = true; }
                        if (entidad.cargoreclasificacion != modelo.cargoreclasificacion) { cambiar = true; }
                        if (entidad.abonoreclasificacion != modelo.abonoreclasificacion) { cambiar = true; }
                        if (entidad.idpapeles != modelo.idpapeles) { cambiar = true; }
                        if (entidad.idnotaspt != modelo.idnotaspt) { cambiar = true; }
                        if (entidad.idagenda != modelo.idagenda) { cambiar = true; }


                        if (cambiar)
                        {
                            //entidad.iddc = modelo.iddc;
                            entidad.idindice = modelo.idindice;
                            //entidad.idcedula = modelo.idcedula;
                            entidad.idpartida = modelo.idpartida;
                            entidad.padreiddc = modelo.padreiddc;
                            entidad.codigocontabledc = modelo.codigocontabledc;
                            entidad.saldoactualdc = modelo.saldoactualdc;
                            if (modelo.m1dc == (" "))
                            {
                                entidad.m1dc = string.Empty;
                            }
                            else
                            { 
                            entidad.m1dc = modelo.m1dc;
                            }
                            if (modelo.m2dc == (" "))
                            {
                                entidad.m2dc = string.Empty;
                            }
                            else
                            {
                                entidad.m2dc = modelo.m2dc;
                            }
                            if (modelo.m3dc == (" "))
                            {
                                entidad.m3dc = string.Empty;
                            }
                            else
                            {
                                entidad.m3dc = modelo.m3dc;
                            }
                            if (modelo.m4dc == (" "))
                            {
                                entidad.m4dc = string.Empty;
                            }
                            else
                            {
                                entidad.m4dc = modelo.m4dc;
                            }
                            if (modelo.m5dc == (" "))
                            {
                                entidad.m5dc = string.Empty;
                            }
                            else
                            {
                                entidad.m5dc = modelo.m5dc;
                            }
                            if (modelo.m6dc == (" "))
                            {
                                entidad.m6dc = string.Empty;
                            }
                            else
                            {
                                entidad.m6dc = modelo.m6dc;
                            }
                            if (modelo.m7dc == (" "))
                            {
                                entidad.m7dc = string.Empty;
                            }
                            else
                            {
                                entidad.m7dc = modelo.m7dc;
                            }
                            if (modelo.m8dc == (" "))
                            {
                                entidad.m8dc = string.Empty;
                            }
                            else
                            {
                                entidad.m8dc = modelo.m8dc;
                            }
                            if (modelo.m9dc == (" "))
                            {
                                entidad.m9dc = string.Empty;
                            }
                            else
                            {
                                entidad.m9dc = modelo.m9dc;
                            }
                            if (modelo.m10dc == (" "))
                            {
                                entidad.m10dc = string.Empty;
                            }
                            else
                            {
                                entidad.m10dc = modelo.m10dc;
                            }
                            entidad.saldoanteriordc = modelo.saldoanteriordc;
                            entidad.aumentodc = modelo.aumentodc;
                            entidad.disminuciondc = modelo.disminuciondc;
                            entidad.saldofinaldc = modelo.saldofinaldc;
                            //entidad.fechacreadodc = modelo.fechacreadodc;
                            entidad.ordendc =(decimal) modelo.ordendc;
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
                            //entidad.etapapapel = modelo.etapapapel;
                            //entidad.idencargo = modelo.idencargo;
                            entidad.claseregistro = modelo.claseregistro;
                            entidad.filasoperadas = modelo.filasoperadas;
                            entidad.signooperacion = modelo.signooperacion;
                            entidad.idcc = modelo.idcc;
                            entidad.iddb = modelo.iddb;
                            entidad.idrepositorio = modelo.idrepositorio;
                            entidad.estadodc = modelo.estadodc;
                            entidad.nombrecuenta = modelo.nombrecuenta;
                            entidad.cargoreajuste = modelo.cargoreajuste;
                            entidad.abonoreajuste = modelo.abonoreajuste;
                            entidad.m11dc = modelo.m11dc;
                            entidad.m12dc = modelo.m12dc;
                            entidad.m13dc = modelo.m13dc;
                            entidad.m14dc = modelo.m14dc;
                            entidad.m15dc = modelo.m15dc;
                            entidad.observaciondc = modelo.observaciondc;
                            entidad.cargoreclasificacion = modelo.cargoreclasificacion;
                            entidad.abonoreclasificacion = modelo.abonoreclasificacion;
                            entidad.idpapeles = modelo.idpapeles;
                            entidad.idnotaspt = modelo.idnotaspt;
                            entidad.idagenda = modelo.idagenda;

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

        public static int UpdateModelo(DetalleCedulaModelo modelo, Boolean actualizar)
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
                        detallecedula entidad = _context.detallecedulas.Find(modelo.iddc);
                        if (entidad == null)
                        {
                            return respuesta;
                        }
                        else
                        {
                            //if (entidad.iddc != modelo.iddc) { cambiar = true; }
                            if (entidad.idindice != modelo.idindice) { cambiar = true; }
                            //if (entidad.idcedula != modelo.idcedula) { cambiar = true; }
                            if (entidad.idpartida != modelo.idpartida) { cambiar = true; }
                            if (entidad.padreiddc != modelo.padreiddc) { cambiar = true; }
                            if (entidad.codigocontabledc != modelo.codigocontabledc) { cambiar = true; }
                            if (entidad.saldoactualdc != modelo.saldoactualdc) { cambiar = true; }
                            if (entidad.m1dc != modelo.m1dc) { cambiar = true; }
                            if (entidad.m2dc != modelo.m2dc) { cambiar = true; }
                            if (entidad.saldoanteriordc != modelo.saldoanteriordc) { cambiar = true; }
                            if (entidad.m3dc != modelo.m3dc) { cambiar = true; }
                            if (entidad.m4dc != modelo.m4dc) { cambiar = true; }
                            if (entidad.aumentodc != modelo.aumentodc) { cambiar = true; }
                            if (entidad.disminuciondc != modelo.disminuciondc) { cambiar = true; }
                            if (entidad.m5dc != modelo.m5dc) { cambiar = true; }
                            if (entidad.m6dc != modelo.m6dc) { cambiar = true; }
                            if (entidad.m7dc != modelo.m7dc) { cambiar = true; }
                            if (entidad.m8dc != modelo.m8dc) { cambiar = true; }
                            if (entidad.saldofinaldc != modelo.saldofinaldc) { cambiar = true; }
                            if (entidad.m9dc != modelo.m9dc) { cambiar = true; }
                            if (entidad.m10dc != modelo.m10dc) { cambiar = true; }
                            if (entidad.fechacreadodc != modelo.fechacreadodc) { cambiar = true; }
                            if (entidad.ordendc != modelo.ordendc) { cambiar = true; }
                            if (entidad.isuso != modelo.isuso) { cambiar = true; }
                            if (entidad.referenciapapel != modelo.referenciapapel) { cambiar = true; }
                            //if (entidad.idgenerico != modelo.idgenerico) { cambiar = true; }
                            //if (entidad.tabla != modelo.tabla) { cambiar = true; }
                            //if (entidad.usuariocerro != modelo.usuariocerro) { cambiar = true; }
                            //if (entidad.usuarioaprobo != modelo.usuarioaprobo) { cambiar = true; }
                            //if (entidad.usuariosuperviso != modelo.usuariosuperviso) { cambiar = true; }
                            //if (entidad.fechasupervision != modelo.fechasupervision) { cambiar = true; }
                            //if (entidad.fechaaprobacion != modelo.fechaaprobacion) { cambiar = true; }
                            ////if (entidad.fechacierre != modelo.fechacierre) { cambiar = true; }
                            //if (entidad.etapapapel != modelo.etapapapel) { cambiar = true; }
                            //if (entidad.idencargo != modelo.idencargo) { cambiar = true; }
                            if (entidad.claseregistro != modelo.claseregistro) { cambiar = true; }
                            if (entidad.filasoperadas != modelo.filasoperadas) { cambiar = true; }
                            if (entidad.signooperacion != modelo.signooperacion) { cambiar = true; }
                            if (entidad.idcc != modelo.idcc) { cambiar = true; }
                            if (entidad.iddb != modelo.iddb) { cambiar = true; }
                            if (entidad.idrepositorio != modelo.idrepositorio) { cambiar = true; }
                            //if (entidad.estadodc != modelo.estadodc) { cambiar = true; }
                            if (entidad.nombrecuenta != modelo.nombrecuenta) { cambiar = true; }
                            if (entidad.cargoreajuste != modelo.cargoreajuste) { cambiar = true; }
                            if (entidad.abonoreajuste != modelo.abonoreajuste) { cambiar = true; }
                            if (entidad.m11dc != modelo.m11dc) { cambiar = true; }
                            if (entidad.m12dc != modelo.m12dc) { cambiar = true; }
                            if (entidad.m13dc != modelo.m13dc) { cambiar = true; }
                            if (entidad.m14dc != modelo.m14dc) { cambiar = true; }
                            if (entidad.m15dc != modelo.m15dc) { cambiar = true; }
                            if (entidad.observaciondc != modelo.observaciondc) { cambiar = true; }
                            if (entidad.cargoreclasificacion != modelo.cargoreclasificacion) { cambiar = true; }
                            if (entidad.abonoreclasificacion != modelo.abonoreclasificacion) { cambiar = true; }
                            if (entidad.idpapeles != modelo.idpapeles) { cambiar = true; }
                            if (entidad.idnotaspt != modelo.idnotaspt) { cambiar = true; }
                            if (entidad.idagenda != modelo.idagenda) { cambiar = true; }


                            if (cambiar)
                            {
                                //entidad.iddc = modelo.iddc;
                                entidad.idindice = modelo.idindice;
                                //entidad.idcedula = modelo.idcedula;
                                entidad.idpartida = modelo.idpartida;
                                entidad.padreiddc = modelo.padreiddc;
                                entidad.codigocontabledc = modelo.codigocontabledc;
                                entidad.saldoactualdc = modelo.saldoactualdc;
                                entidad.m1dc = modelo.m1dc;
                                entidad.m2dc = modelo.m2dc;
                                entidad.saldoanteriordc = modelo.saldoanteriordc;
                                entidad.m3dc = modelo.m3dc;
                                entidad.m4dc = modelo.m4dc;
                                entidad.aumentodc = modelo.aumentodc;
                                entidad.disminuciondc = modelo.disminuciondc;
                                entidad.m5dc = modelo.m5dc;
                                entidad.m6dc = modelo.m6dc;
                                entidad.m7dc = modelo.m7dc;
                                entidad.m8dc = modelo.m8dc;
                                entidad.saldofinaldc = modelo.saldofinaldc;
                                entidad.m9dc = modelo.m9dc;
                                entidad.m10dc = modelo.m10dc;
                                //entidad.fechacreadodc = modelo.fechacreadodc;
                                entidad.ordendc = (decimal)modelo.ordendc;
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
                                //entidad.etapapapel = modelo.etapapapel;
                                //entidad.idencargo = modelo.idencargo;
                                entidad.claseregistro = modelo.claseregistro;
                                entidad.filasoperadas = modelo.filasoperadas;
                                entidad.signooperacion = modelo.signooperacion;
                                entidad.idcc = modelo.idcc;
                                entidad.iddb = modelo.iddb;
                                entidad.idrepositorio = modelo.idrepositorio;
                                entidad.estadodc = modelo.estadodc;
                                entidad.nombrecuenta = modelo.nombrecuenta;
                                entidad.cargoreajuste = modelo.cargoreajuste;
                                entidad.abonoreajuste = modelo.abonoreajuste;
                                entidad.m11dc = modelo.m11dc;
                                entidad.m12dc = modelo.m12dc;
                                entidad.m13dc = modelo.m13dc;
                                entidad.m14dc = modelo.m14dc;
                                entidad.m15dc = modelo.m15dc;
                                entidad.observaciondc = modelo.observaciondc;
                                entidad.cargoreclasificacion = modelo.cargoreclasificacion;
                                entidad.abonoreclasificacion = modelo.abonoreclasificacion;
                                entidad.idpapeles = modelo.idpapeles;
                                entidad.idnotaspt = modelo.idnotaspt;
                                entidad.idagenda = modelo.idagenda;

                                entidad.etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(2); ; _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(2));
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
        public static bool DeleteBorradoLogico(int id, DetalleCedulaModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET estadodc = 'B' WHERE iddc={0};", id);
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

        internal static void UpdateModeloReodenar(DetalleCedulaModelo modelo)
        {
            if (!(modelo == null))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET ordendc = {0} WHERE iddc={1};", modelo.ordendc, modelo.idcc);
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

      public static bool UpdateModeloReferencia(DetalleCedulaModelo modelo, UniversalPTModelo papel,int? colIndice)
        {
            if ((modelo != null && papel != null && modelo.iddc != 0 && papel.idUpt != 0))
            {
                try
                {
                    if (colIndice == 1)
                    {
                        using (_context = new SGPTEntidades())
                        {
                            modelo.referenciapapel = papel.referenciaTpt;
                            if (string.IsNullOrEmpty(papel.referenciaTpt))
                            {
                                modelo.referenciapapel = "Pendiente";
                            }
                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET tabla = '{0}',idgenerico={1},referenciapapel='{2}' WHERE iddc={3};", 
                                papel.tablaUpt, 
                                papel.idOrigenUpt,
                                modelo.referenciapapel,
                                modelo.iddc);
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
                    else
                    {
                        return false;
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

        public static bool UpdateModeloReferencia(DetalleCedulaModelo modelo, string referencia)
        {
            if ((modelo != null && modelo.iddc != 0 && referencia != null))
            {
                try
                {
                        using (_context = new SGPTEntidades())
                        {
                            if (string.IsNullOrEmpty(referencia))
                            {
                                modelo.referenciapapel = "Pendiente";
                            }
                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET referenciapapel='{0}' WHERE iddc={1};",
                                referencia,
                                modelo.iddc);
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


        public static void BorrarModeloReferencia(DetalleCedulaModelo modelo)
        {
            if ((modelo != null && modelo.iddc != 0 ))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallecedulas SET tabla = '{0}',idgenerico={1},referenciapapel='{2}' WHERE iddc={3};",
                            string.Empty,
                            null,
                            string.Empty,
                            modelo.iddc);
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


        public static void BorrarModeloMarca(DetalleCedulaModelo modelo,string nombreColumna)
        {
            if ((modelo != null && modelo.iddc != 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallecedulas SET '{0}' = '{1}' WHERE iddc={2};",
                            nombreColumna,
                            string.Empty,
                            modelo.iddc);

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

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET estadodc = 'B' WHERE idcedula={0};", idCedula);
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

        public static int Delete(ObservableCollection<DetalleCedulaModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        detallecedula entidadTemporal = new detallecedula();
                        string commandString = string.Empty;
                        foreach (DetalleCedulaModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.iddc);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.detallecedulas WHERE iddc={0};", item.iddc);
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

        public static int DeleteLogico(ObservableCollection<DetalleCedulaModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        detallecedula entidadTemporal = new detallecedula();
                        string commandString = string.Empty;
                        foreach (DetalleCedulaModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.iddc);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = String.Format("UPDATE sgpt.detallecedulas SET estadodc = 'B' WHERE iddc={0};", item.iddc);
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



        public static int Delete(DetalleCedulaModelo modelo)
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
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("DELETE FROM sgpt.detallecedulas WHERE iddc={0};", modelo.iddc);
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

        public static int DeleteLogico(DetalleCedulaModelo modelo)
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
                            //éxito en la operacion
                            //Continuar
                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET estadodc = 'B' WHERE iddc={0};", modelo.iddc);
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
                        BitacoraModelo.DeleteByTransaccion(id, "DETALLECEDULAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.detallecedulas WHERE iddc={0};", id);
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
                        BitacoraModelo.DeleteByTransaccion(idCedula, "DETALLECEDULAS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.detallecedulas WHERE idcedula={0};", idCedula);
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
        public static void DeleteByRange(ObservableCollection<detallecedula> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.detallecedulas.RemoveRange(lista);
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

                        //DetalleDetalleCedulaModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.detallecedulas WHERE iddc={0};", id);
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


        public static int DeleteBorradoLogico(ObservableCollection<DetalleCedulaModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    detallecedula entidadTemporal = new detallecedula();
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (DetalleCedulaModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.iddc);//Borra todas las referencias dentro  de bitacora
                                                                                             //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                                //item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.iddc);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.detallecedulas SET estadodc = 'B' WHERE iddc={0};", item.iddc);
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

        internal static List<DetalleCedulaModelo> GetAllByEncargosImportacion(EncargoModelo encargo, int? idpartida)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecedulas.Select(entidad =>
                     new DetalleCedulaModelo
                     {
                         iddc = entidad.iddc,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         idpartida = entidad.idpartida,
                         padreiddc = entidad.padreiddc,
                         codigocontabledc = entidad.codigocontabledc,
                         saldoactualdc = entidad.saldoactualdc,
                         m1dc = entidad.m1dc,
                         m2dc = entidad.m2dc,
                         saldoanteriordc = entidad.saldoanteriordc,
                         m3dc = entidad.m3dc,
                         m4dc = entidad.m4dc,
                         aumentodc = entidad.aumentodc,
                         disminuciondc = entidad.disminuciondc,
                         m5dc = entidad.m5dc,
                         m6dc = entidad.m6dc,
                         m7dc = entidad.m7dc,
                         m8dc = entidad.m8dc,
                         saldofinaldc = entidad.saldofinaldc,
                         m9dc = entidad.m9dc,
                         m10dc = entidad.m10dc,
                         fechacreadodc = entidad.fechacreadodc,
                         ordendc = entidad.ordendc,
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
                         claseregistro = entidad.claseregistro,
                         filasoperadas = entidad.filasoperadas,
                         signooperacion = entidad.signooperacion,
                         idcc = entidad.idcc,
                         iddb = entidad.iddb,
                         idrepositorio = entidad.idrepositorio,
                         estadodc = entidad.estadodc,
                         nombrecuenta = entidad.nombrecuenta,
                         cargoreajuste = entidad.cargoreajuste,
                         abonoreajuste = entidad.abonoreajuste,

                         cargosreajusteyreclasificacion = entidad.cargoreajuste + entidad.cargoreajuste,
                         abonoreajusteyreclasificacion = entidad.abonoreajuste + entidad.abonoreajuste,

                         m11dc = entidad.m11dc,
                         m12dc = entidad.m12dc,
                         m13dc = entidad.m13dc,
                         m14dc = entidad.m14dc,
                         m15dc = entidad.m15dc,
                         observaciondc = entidad.observaciondc,
                         cargoreclasificacion = entidad.cargoreclasificacion,
                         abonoreclasificacion = entidad.abonoreclasificacion,
                         idpapeles = entidad.idpapeles,
                         idnotaspt = entidad.idnotaspt,
                         idagenda = entidad.idagenda,

                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idpartida).Where(x => x.estadodc == "A"
                                                          && x.idencargo != encargo.idencargo
                                                          && x.idpartida == idpartida).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (DetalleCedulaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            if (item.saldoanteriordc > 0)
                            {
                                item.variaciónporcentual = (item.aumentodc) / (item.saldoanteriordc);
                            }
                            if (item.tiposaldocc == "D" || item.tiposaldocc == "RD")
                            {
                                item.saldoreajustado = item.saldoactualdc + item.cargoreajuste - item.abonoreajuste;
                            }
                            else
                            {
                                item.saldoreajustado = item.saldoactualdc - item.cargoreajuste + item.abonoreajuste;
                            }
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

        internal static List<DetalleCedulaModelo> GetAllByEncargosImportacionOtros(EncargoModelo encargo, int? idpartida)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecedulas.Select(entidad =>
                     new DetalleCedulaModelo
                     {
                         iddc = entidad.iddc,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         idpartida = entidad.idpartida,
                         padreiddc = entidad.padreiddc,
                         codigocontabledc = entidad.codigocontabledc,
                         saldoactualdc = entidad.saldoactualdc,
                         m1dc = entidad.m1dc,
                         m2dc = entidad.m2dc,
                         saldoanteriordc = entidad.saldoanteriordc,
                         m3dc = entidad.m3dc,
                         m4dc = entidad.m4dc,
                         aumentodc = entidad.aumentodc,
                         disminuciondc = entidad.disminuciondc,
                         m5dc = entidad.m5dc,
                         m6dc = entidad.m6dc,
                         m7dc = entidad.m7dc,
                         m8dc = entidad.m8dc,
                         saldofinaldc = entidad.saldofinaldc,
                         m9dc = entidad.m9dc,
                         m10dc = entidad.m10dc,
                         fechacreadodc = entidad.fechacreadodc,
                         ordendc = entidad.ordendc,
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
                         claseregistro = entidad.claseregistro,
                         filasoperadas = entidad.filasoperadas,
                         signooperacion = entidad.signooperacion,
                         idcc = entidad.idcc,
                         iddb = entidad.iddb,
                         idrepositorio = entidad.idrepositorio,
                         estadodc = entidad.estadodc,
                         nombrecuenta = entidad.nombrecuenta,
                         cargoreajuste = entidad.cargoreajuste,
                         abonoreajuste = entidad.abonoreajuste,
                         m11dc = entidad.m11dc,
                         m12dc = entidad.m12dc,
                         m13dc = entidad.m13dc,
                         m14dc = entidad.m14dc,
                         m15dc = entidad.m15dc,
                         observaciondc = entidad.observaciondc,
                         cargoreclasificacion = entidad.cargoreclasificacion,
                         abonoreclasificacion = entidad.abonoreclasificacion,
                         idpapeles = entidad.idpapeles,
                         idnotaspt = entidad.idnotaspt,
                         idagenda = entidad.idagenda,
                         guardadoBase = true,
                         IsSelected = false,
                         cargosreajusteyreclasificacion = entidad.cargoreajuste + entidad.cargoreajuste,
                         abonoreajusteyreclasificacion = entidad.abonoreajuste + entidad.abonoreajuste,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idpartida).Where(x => x.estadodc == "A"
                                                          && x.idencargo != encargo.idencargo).ToList();
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
                        foreach (DetalleCedulaModelo item in lista)
                        {
                            if (item.saldoanteriordc > 0)
                            {
                                item.variaciónporcentual = (item.aumentodc) / (item.saldoanteriordc);
                            }
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            if (item.tiposaldocc == "D" || item.tiposaldocc == "RD")
                            {
                                item.saldoreajustado = item.saldoactualdc + item.cargoreajuste - item.abonoreajuste;
                            }
                            else
                            {
                                item.saldoreajustado = item.saldoactualdc - item.cargoreajuste + item.abonoreajuste;
                            }
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<detallecedula> lista, int iddc)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallecedulas SET estadodc = 'B' WHERE iddc = {0};", iddc);
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
        public static explicit operator detallecedula(DetalleCedulaModelo modelo)  // explicit byte to digit conversion operator
        {
            detallecedula entidad = new detallecedula();
            entidad.iddc = modelo.iddc;
            entidad.idindice = modelo.idindice;
            entidad.idcedula = modelo.idcedula;
            entidad.idpartida = modelo.idpartida;
            entidad.padreiddc = modelo.padreiddc;
            entidad.codigocontabledc = modelo.codigocontabledc;
            entidad.saldoactualdc = modelo.saldoactualdc;
            entidad.m1dc = modelo.m1dc;
            entidad.m2dc = modelo.m2dc;
            entidad.saldoanteriordc = modelo.saldoanteriordc;
            entidad.m3dc = modelo.m3dc;
            entidad.m4dc = modelo.m4dc;
            entidad.aumentodc = modelo.aumentodc;
            entidad.disminuciondc = modelo.disminuciondc;
            entidad.m5dc = modelo.m5dc;
            entidad.m6dc = modelo.m6dc;
            entidad.m7dc = modelo.m7dc;
            entidad.m8dc = modelo.m8dc;
            entidad.saldofinaldc = modelo.saldofinaldc;
            entidad.m9dc = modelo.m9dc;
            entidad.m10dc = modelo.m10dc;
            entidad.fechacreadodc = modelo.fechacreadodc;
            entidad.ordendc =(decimal) modelo.ordendc;
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
            entidad.claseregistro = modelo.claseregistro;
            entidad.filasoperadas = modelo.filasoperadas;
            entidad.signooperacion = modelo.signooperacion;
            entidad.idcc = modelo.idcc;
            entidad.iddb = modelo.iddb;
            entidad.idrepositorio = modelo.idrepositorio;
            entidad.estadodc = modelo.estadodc;
            entidad.nombrecuenta = modelo.nombrecuenta;
            entidad.cargoreajuste = modelo.cargoreajuste;
            entidad.abonoreajuste = modelo.abonoreajuste;
            entidad.m11dc = modelo.m11dc;
            entidad.m12dc = modelo.m12dc;
            entidad.m13dc = modelo.m13dc;
            entidad.m14dc = modelo.m14dc;
            entidad.m15dc = modelo.m15dc;
            entidad.observaciondc = modelo.observaciondc;
            entidad.cargoreclasificacion = modelo.cargoreclasificacion;
            entidad.abonoreclasificacion = modelo.abonoreclasificacion;
            entidad.idpapeles = modelo.idpapeles;
            entidad.idnotaspt = modelo.idnotaspt;
            entidad.idagenda = modelo.idagenda;
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

                            string commandString = String.Format("DELETE FROM sgpt.detallecedulas WHERE iddc={0};", id);
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

        public static List<DetalleCedulaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecedulas.Select(entidad =>
                     new DetalleCedulaModelo
                     {
                         iddc = entidad.iddc,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         idpartida = entidad.idpartida,
                         padreiddc = entidad.padreiddc,
                         codigocontabledc = entidad.codigocontabledc,
                         saldoactualdc = entidad.saldoactualdc,
                         m1dc = entidad.m1dc,
                         m2dc = entidad.m2dc,
                         saldoanteriordc = entidad.saldoanteriordc,
                         m3dc = entidad.m3dc,
                         m4dc = entidad.m4dc,
                         aumentodc = entidad.aumentodc,
                         disminuciondc = entidad.disminuciondc,
                         m5dc = entidad.m5dc,
                         m6dc = entidad.m6dc,
                         m7dc = entidad.m7dc,
                         m8dc = entidad.m8dc,
                         saldofinaldc = entidad.saldofinaldc,
                         m9dc = entidad.m9dc,
                         m10dc = entidad.m10dc,
                         fechacreadodc = entidad.fechacreadodc,
                         ordendc = entidad.ordendc,
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
                         claseregistro = entidad.claseregistro,
                         filasoperadas = entidad.filasoperadas,
                         signooperacion = entidad.signooperacion,
                         idcc = entidad.idcc,
                         iddb = entidad.iddb,
                         idrepositorio = entidad.idrepositorio,
                         estadodc = entidad.estadodc,
                         nombrecuenta = entidad.nombrecuenta,
                         cargoreajuste = entidad.cargoreajuste,
                         abonoreajuste = entidad.abonoreajuste,
                         m11dc = entidad.m11dc,
                         m12dc = entidad.m12dc,
                         m13dc = entidad.m13dc,
                         m14dc = entidad.m14dc,
                         m15dc = entidad.m15dc,
                         observaciondc = entidad.observaciondc,
                         cargoreclasificacion = entidad.cargoreclasificacion,
                         abonoreclasificacion = entidad.abonoreclasificacion,
                         idpapeles = entidad.idpapeles,
                         idnotaspt = entidad.idnotaspt,
                         idagenda = entidad.idagenda,
                         cargosreajusteyreclasificacion = entidad.cargoreajuste + entidad.cargoreajuste,
                         abonoreajusteyreclasificacion = entidad.abonoreajuste + entidad.abonoreajuste,
                         guardadoBase = true,
                         IsSelected = false,

                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idpartida).Where(x => x.estadodc == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    if (lista.Count > 0)
                    {
                        foreach (DetalleCedulaModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            if (item.saldoanteriordc > 0)
                            {
                                item.variaciónporcentual = (item.aumentodc) / (item.saldoanteriordc);
                            }
                            if (item.tiposaldocc == "D" || item.tiposaldocc == "RD")
                            {
                                item.saldoreajustado = item.saldoactualdc + item.cargoreajuste - item.abonoreajuste;
                            }
                            else
                            {
                                item.saldoreajustado = item.saldoactualdc - item.cargoreajuste + item.abonoreajuste;
                            }
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

        internal static int UpdateCierre(DetalleCedulaModelo modelo, UsuarioModelo usuarioModelo)
        {
            int id = modelo.iddc;
            int result = 0;
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            #region bitacora
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(4));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET usuariocerro = '{0}',fechacierre = '{1}', etapapapel='{2}'  WHERE iddc = {3};",
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

        internal static int UpdateReferencia(DetalleCedulaModelo modelo)
        {
            int id = modelo.iddc;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(2));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET referenciapapel = '{0}',etapapapel ='{1}' WHERE iddc={2};", modelo.referenciapapel, EtapaEncargoModelo.seleccionEtapaIniciales(2), id);
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

        internal static int UpdateSupervision(DetalleCedulaModelo modelo)
        {
            int id = modelo.iddc;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET usuariosuperviso = '{0}',fechasupervision = '{1}',etapapapel ='{2}' WHERE iddc = {3};",
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

        internal static int UpdateAprobacion(DetalleCedulaModelo modelo)
        {
            int id = modelo.iddc;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',etapapapel ='{2}' WHERE iddc = {3};",
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

        internal static int UpdateAprobacionSupervision(DetalleCedulaModelo modelo)
        {
            int id = modelo.iddc;
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

                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(6));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            }
                            temporal = new BitacoraModelo(modelo, "DETALLECEDULAS", EtapaEncargoModelo.seleccionEtapa(3));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                // modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallecedulas SET usuarioaprobo = '{0}',fechaaprobacion = '{1}',usuariosuperviso = '{2}',fechasupervision = '{3}',etapapapel='{4}' WHERE iddc = {5};",
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

        public static ObservableCollection<DetalleCedulaModelo> GetAllEdicion(EncargoModelo encargo, int idCedula)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecedulas.Select(entidad =>
                     new DetalleCedulaModelo
                     {
                         iddc = entidad.iddc,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         idpartida = entidad.idpartida,
                         padreiddc = entidad.padreiddc,
                         codigocontabledc = entidad.codigocontabledc,
                         saldoactualdc = entidad.saldoactualdc,
                         m1dc = entidad.m1dc,
                         m2dc = entidad.m2dc,
                         saldoanteriordc = entidad.saldoanteriordc,
                         m3dc = entidad.m3dc,
                         m4dc = entidad.m4dc,
                         aumentodc = entidad.aumentodc,
                         disminuciondc = entidad.disminuciondc,
                         m5dc = entidad.m5dc,
                         m6dc = entidad.m6dc,
                         m7dc = entidad.m7dc,
                         m8dc = entidad.m8dc,
                         saldofinaldc = entidad.saldofinaldc,
                         m9dc = entidad.m9dc,
                         m10dc = entidad.m10dc,
                         fechacreadodc = entidad.fechacreadodc,
                         ordendc = entidad.ordendc,
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
                         claseregistro = entidad.claseregistro,
                         filasoperadas = entidad.filasoperadas,
                         signooperacion = entidad.signooperacion,
                         idcc = entidad.idcc,
                         iddb = entidad.iddb,
                         idrepositorio = entidad.idrepositorio,
                         estadodc = entidad.estadodc,
                         nombrecuenta = entidad.nombrecuenta,
                         cargoreajuste = entidad.cargoreajuste,
                         abonoreajuste = entidad.abonoreajuste,
                         m11dc = entidad.m11dc,
                         m12dc = entidad.m12dc,
                         m13dc = entidad.m13dc,
                         m14dc = entidad.m14dc,
                         m15dc = entidad.m15dc,
                         observaciondc = entidad.observaciondc,
                         cargoreclasificacion = entidad.cargoreclasificacion,
                         abonoreclasificacion = entidad.abonoreclasificacion,
                         idpapeles = entidad.idpapeles,
                         idnotaspt = entidad.idnotaspt,
                         idagenda = entidad.idagenda,
                         cargosreajusteyreclasificacion = entidad.cargoreajuste + entidad.cargoreajuste,
                         abonoreajusteyreclasificacion = entidad.abonoreajuste + entidad.abonoreajuste,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         nombreClaseCuenta = entidad.catalogocuenta.clasecuenta.descripcionccuentas,
                         guardadoBase = true,
                         IsSelected=false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddc).Where(x => x.estadodc == "A" && x.idencargo == encargo.idencargo && x.idcedula == idCedula).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    string referencia = string.Empty;
                    foreach (DetalleCedulaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        if (item.saldoanteriordc != 0 && item.saldoanteriordc!=null)
                        {
                            item.variaciónporcentual = (item.aumentodc) / (item.saldoanteriordc);
                        }
                        if (item.tiposaldocc == "D" || item.tiposaldocc == "RD")
                        {
                            item.saldoreajustado = item.saldoactualdc + item.cargoreajuste - item.abonoreajuste;
                        }
                        else
                        {
                            item.saldoreajustado = item.saldoactualdc - item.cargoreajuste + item.abonoreajuste;
                        }
                        if (item.claseregistro == "S")
                        {
                            item.cargosreajusteyreclasificacion = item.cargoreajuste + item.cargoreajuste;
                            item.abonoreajusteyreclasificacion = item.abonoreajuste + item.abonoreajuste;
                        }

                        if (item.tabla != null && item.idgenerico!=null && item.idgenerico!=0)
                        {
                            //Actualizar referencias
                            referencia = UniversalPTModelo.GetReferencia(item.tabla, item.idgenerico);
                            if (referencia == "-1")
                            {
                                item.referenciapapel = "Error";
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
                    }
                    return new ObservableCollection<DetalleCedulaModelo>(lista);
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

        public static ObservableCollection<DetalleCedulaModelo> GetAllEdicionResumen(EncargoModelo encargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecedulas.Select(entidad =>
                     new DetalleCedulaModelo
                     {
                         iddc = entidad.iddc,
                         idindice = entidad.idindice,
                         idcedula = entidad.idcedula,
                         idpartida = entidad.idpartida,
                         padreiddc = entidad.padreiddc,
                         codigocontabledc = entidad.codigocontabledc,
                         saldoactualdc = entidad.saldoactualdc,
                         m1dc = entidad.m1dc,
                         m2dc = entidad.m2dc,
                         saldoanteriordc = entidad.saldoanteriordc,
                         m3dc = entidad.m3dc,
                         m4dc = entidad.m4dc,
                         aumentodc = entidad.aumentodc,
                         disminuciondc = entidad.disminuciondc,
                         m5dc = entidad.m5dc,
                         m6dc = entidad.m6dc,
                         m7dc = entidad.m7dc,
                         m8dc = entidad.m8dc,
                         saldofinaldc = entidad.saldofinaldc,
                         m9dc = entidad.m9dc,
                         m10dc = entidad.m10dc,
                         fechacreadodc = entidad.fechacreadodc,
                         ordendc = entidad.ordendc,
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
                         claseregistro = entidad.claseregistro,
                         filasoperadas = entidad.filasoperadas,
                         signooperacion = entidad.signooperacion,
                         idcc = entidad.idcc,
                         iddb = entidad.iddb,
                         idrepositorio = entidad.idrepositorio,
                         estadodc = entidad.estadodc,
                         nombrecuenta = entidad.nombrecuenta,
                         cargoreajuste = entidad.cargoreajuste,
                         abonoreajuste = entidad.abonoreajuste,
                         m11dc = entidad.m11dc,
                         m12dc = entidad.m12dc,
                         m13dc = entidad.m13dc,
                         m14dc = entidad.m14dc,
                         m15dc = entidad.m15dc,
                         observaciondc = entidad.observaciondc,
                         cargoreclasificacion = entidad.cargoreclasificacion,
                         abonoreclasificacion = entidad.abonoreclasificacion,
                         idpapeles = entidad.idpapeles,
                         idnotaspt = entidad.idnotaspt,
                         idagenda = entidad.idagenda,
                         cargosreajusteyreclasificacion = entidad.cargoreajuste + entidad.cargoreajuste,
                         abonoreajusteyreclasificacion = entidad.abonoreajuste + entidad.abonoreajuste,
                         tiposaldocc = entidad.catalogocuenta.tiposaldocc,
                         nombreClaseCuenta = entidad.catalogocuenta.clasecuenta.descripcionccuentas,
                         guardadoBase = true,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.iddc).Where(x => x.estadodc == "A" && x.idencargo == encargo.idencargo && x.claseregistro=="S").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (DetalleCedulaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        if (item.saldoanteriordc != 0 && item.saldoanteriordc != null)
                        {
                            item.variaciónporcentual = (item.aumentodc) / (item.saldoanteriordc);
                        }
                        if (item.tiposaldocc == "D" || item.tiposaldocc == "RD")
                        {
                            item.saldoreajustado = item.saldoactualdc + item.cargoreajuste - item.abonoreajuste;
                        }
                        else
                        {
                            item.saldoreajustado = item.saldoactualdc - item.cargoreajuste + item.abonoreajuste;
                        }
                        if (item.claseregistro == "S")
                        {
                            item.cargosreajusteyreclasificacion = item.cargoreajuste + item.cargoreajuste;
                            item.abonoreajusteyreclasificacion = item.abonoreajuste + item.abonoreajuste;
                        }
                    }
                    return new ObservableCollection<DetalleCedulaModelo>(lista);
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


        internal static DetalleCedulaModelo GetRegistro(int idgenericoindice)
        {
            var entidad = new DetalleCedulaModelo();
            if (!(idgenericoindice == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detallecedula modelo = _context.detallecedulas.Find(idgenericoindice);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.iddc = modelo.iddc;
                        entidad.idindice = modelo.idindice;
                        entidad.idcedula = modelo.idcedula;
                        entidad.idpartida = modelo.idpartida;
                        entidad.padreiddc = modelo.padreiddc;
                        entidad.codigocontabledc = modelo.codigocontabledc;
                        entidad.saldoactualdc = modelo.saldoactualdc;
                        entidad.m1dc = modelo.m1dc;
                        entidad.m2dc = modelo.m2dc;
                        entidad.saldoanteriordc = modelo.saldoanteriordc;
                        entidad.m3dc = modelo.m3dc;
                        entidad.m4dc = modelo.m4dc;
                        entidad.aumentodc = modelo.aumentodc;
                        entidad.disminuciondc = modelo.disminuciondc;
                        entidad.m5dc = modelo.m5dc;
                        entidad.m6dc = modelo.m6dc;
                        entidad.m7dc = modelo.m7dc;
                        entidad.m8dc = modelo.m8dc;
                        entidad.saldofinaldc = modelo.saldofinaldc;
                        entidad.m9dc = modelo.m9dc;
                        entidad.m10dc = modelo.m10dc;
                        entidad.fechacreadodc = modelo.fechacreadodc;
                        entidad.ordendc = modelo.ordendc;
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
                        entidad.claseregistro = modelo.claseregistro;
                        entidad.filasoperadas = modelo.filasoperadas;
                        entidad.signooperacion = modelo.signooperacion;
                        entidad.idcc = modelo.idcc;
                        entidad.iddb = modelo.iddb;
                        entidad.idrepositorio = modelo.idrepositorio;
                        entidad.estadodc = modelo.estadodc;
                        entidad.nombrecuenta = modelo.nombrecuenta;
                        entidad.cargoreajuste = modelo.cargoreajuste;
                        entidad.abonoreajuste = modelo.abonoreajuste;
                        entidad.m11dc = modelo.m11dc;
                        entidad.m12dc = modelo.m12dc;
                        entidad.m13dc = modelo.m13dc;
                        entidad.m14dc = modelo.m14dc;
                        entidad.m15dc = modelo.m15dc;
                        entidad.observaciondc = modelo.observaciondc;
                        entidad.cargoreclasificacion = modelo.cargoreclasificacion;
                        entidad.abonoreclasificacion = modelo.abonoreclasificacion;
                        entidad.idpapeles = modelo.idpapeles;
                        entidad.idnotaspt = modelo.idnotaspt;
                        entidad.idagenda = modelo.idagenda;

                        entidad.cargosreajusteyreclasificacion = modelo.cargoreajuste + modelo.cargoreajuste;
                        entidad.abonoreajusteyreclasificacion = modelo.abonoreajuste + modelo.abonoreajuste;

                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        if (entidad.saldoanteriordc > 0)
                        {
                            entidad.variaciónporcentual = (entidad.aumentodc) / (entidad.saldoanteriordc);
                        }
                        if (entidad.tiposaldocc == "D" || entidad.tiposaldocc == "RD")
                        {
                            entidad.saldoreajustado = entidad.saldoactualdc + entidad.cargoreajuste - entidad.abonoreajuste;
                        }
                        else
                        {
                            entidad.saldoreajustado = entidad.saldoactualdc - entidad.cargoreajuste + entidad.abonoreajuste;
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

        public static ObservableCollection<detallecedula> GetAllCapaDatosByidEncargo(int idencargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallecedulas.Where(entidad => (entidad.idencargo == idencargo && entidad.estadodc == "A"));
                    ObservableCollection<detallecedula> temporal = new ObservableCollection<detallecedula>(lista);
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
                    //var lista = _context.detallecedulas.Where(x => x.estadodc == "A" && x.idcedula == idcedula);
                    var lista = (from p in _context.detallecedulas
                                 where p.idencargo == idEncargo
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.detallecedulas.RemoveRange(lista);
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
                    elementos = _context.detallecedulas.Where(x => x.iddc == id && x.estadodc == "A").Count();
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
                    elementos = (int)_context.detallecedulas.Single(x => x.iddc == id && x.estadodc == "A").isuso;
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

        public static int FindTextoReturnIdBorrados(DetalleCedulaModelo documento)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(documento.claseregistro) || string.IsNullOrWhiteSpace(documento.claseregistro))))
            {
                string busqueda = documento.claseregistro.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detallecedulas.Where(x => x.claseregistro.ToUpper() == busqueda && x.estadodc == "B" && x.idencargo == documento.idencargo).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        public DetalleCedulaModelo()
        {
            iddc = 0;
            idindice = null;
            idcedula = 0;
            idpartida = null;
            padreiddc = null;
            codigocontabledc = string.Empty;
            saldoactualdc = 0;
            saldoanteriordc = 0;
            aumentodc = 0;
            disminuciondc = 0;
            saldofinaldc = 0;
            ordendc = 0;
            isuso = 0;
            referenciapapel = string.Empty;
            idgenerico = 0;
            tabla = "DETALLECEDULA";
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            idencargo = 0;
            claseregistro = "D";
            filasoperadas = null;
            signooperacion = null;
            idcc = null;
            iddb = null;
            idrepositorio = null;
            estadodc = "A";
            cargoreajuste = 0;
            abonoreajuste = 0;
            observaciondc = null;
            cargoreclasificacion = 0;
            abonoreclasificacion = 0;
            idpapeles = null;
            m1dc = null;
            m2dc = null;
            m3dc = null;
            m4dc = null;
            m5dc = null;
            m6dc = null;
            m7dc = null;
            m8dc = null;
            m9dc = null;
            m10dc = null;
            m11dc = null;
            m12dc = null;
            m13dc = null;
            m14dc = null;
            m15dc = null;

            idnotaspt = null;
            idagenda = null;

            fechacreadodc = MetodosModelo.homologacionFecha();
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            nombreClaseCuenta = string.Empty;
            nombrecuenta = string.Empty;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;
        }
        public DetalleCedulaModelo(EncargoModelo encargo)
        {
            iddc = 0;
            idindice = null;
            idcedula = 0;
            idpartida = null;
            padreiddc = null;
            codigocontabledc = string.Empty;
            saldoactualdc = 0;
            saldoanteriordc = 0;
            aumentodc = 0;
            disminuciondc = 0;
            saldofinaldc = 0;
            ordendc = 0;
            isuso = 0;
            referenciapapel = string.Empty;
            idgenerico = 0;
            tabla = "DETALLECEDULA";
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            idencargo = encargo.idencargo;
            claseregistro = "D";
            filasoperadas = null;
            signooperacion = null;
            idcc = null;
            iddb = null;
            idrepositorio = null;
            estadodc = "A";
            cargoreajuste = 0;
            abonoreajuste = 0;
            observaciondc = null;
            cargoreclasificacion = 0;
            abonoreclasificacion = 0;
            idpapeles = null;
            m1dc = null;
            m2dc = null;
            m3dc = null;
            m4dc = null;
            m5dc = null;
            m6dc = null;
            m7dc = null;
            m8dc = null;
            m9dc = null;
            m10dc = null;
            m11dc = null;
            m12dc = null;
            m13dc = null;
            m14dc = null;
            m15dc = null;

            idnotaspt = null;
            idagenda = null;

            fechacreadodc = MetodosModelo.homologacionFecha();
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            nombreClaseCuenta = string.Empty;
            nombrecuenta = string.Empty;
            usuarioModelo = null;
            IsSelected = false;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;

        }

        internal static int evaluarCerrar(DetalleCedulaModelo currentEntidad)
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

        internal static int evaluarBorrar(DetalleCedulaModelo currentEntidad)
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

        public DetalleCedulaModelo(EncargoModelo encargo, UsuarioModelo usuario)
        {
            iddc = 0;
            idindice = null;
            idcedula = 0;
            idpartida = null;
            padreiddc = null;
            codigocontabledc = string.Empty;
            saldoactualdc = 0;
            saldoanteriordc = 0;
            aumentodc = 0;
            disminuciondc = 0;
            saldofinaldc = 0;
            ordendc = 0;
            isuso = 0;
            referenciapapel = string.Empty;
            idgenerico = 0;
            tabla = "DETALLECEDULA";
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            idencargo = encargo.idencargo;
            claseregistro = "D";
            filasoperadas = null;
            signooperacion = null;
            idcc = null;
            iddb = null;
            idrepositorio = null;
            estadodc = "A";
            cargoreajuste = 0;
            abonoreajuste = 0;
            observaciondc = null;
            cargoreclasificacion = 0;
            abonoreclasificacion = 0;
            idpapeles = null;
            m1dc = null;
            m2dc = null;
            m3dc = null;
            m4dc = null;
            m5dc = null;
            m6dc = null;
            m7dc = null;
            m8dc = null;
            m9dc = null;
            m10dc = null;
            m11dc = null;
            m12dc = null;
            m13dc = null;
            m14dc = null;
            m15dc = null;

            idnotaspt = null;
            idagenda = null;

            fechacreadodc = MetodosModelo.homologacionFecha();
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            nombreClaseCuenta = string.Empty;
            nombrecuenta = string.Empty;
            usuarioModelo =usuario;
            IsSelected = false;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;
        }

        public DetalleCedulaModelo(DetalleCedulaModelo entidad, EncargoModelo currentEncargo, UsuarioModelo currentUsuario)
        {

            iddc = entidad.iddc;
            idindice = entidad.idindice;
            idcedula = entidad.idcedula;
            idpartida = entidad.idpartida;
            padreiddc = entidad.padreiddc;
            codigocontabledc = entidad.codigocontabledc;
            saldoactualdc = entidad.saldoactualdc;
            saldoanteriordc = entidad.saldoanteriordc;
            aumentodc = entidad.aumentodc;
            disminuciondc = entidad.disminuciondc;
            saldofinaldc = entidad.saldofinaldc;
            ordendc = entidad.ordendc;
            isuso = entidad.isuso;
            referenciapapel = entidad.referenciapapel;
            idgenerico = entidad.idgenerico;
            tabla = entidad.tabla;
            usuariocerro = entidad.usuariocerro;
            usuarioaprobo = entidad.usuarioaprobo;
            usuariosuperviso = entidad.usuariosuperviso;
            fechasupervision = entidad.fechasupervision;
            fechaaprobacion = entidad.fechaaprobacion;
            fechacierre = entidad.fechacierre;
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            fechacreadodc = MetodosModelo.homologacionFecha();
            idencargo = entidad.idencargo;
            claseregistro = entidad.claseregistro;
            filasoperadas = entidad.filasoperadas;
            signooperacion = entidad.signooperacion;
            idcc = entidad.idcc;
            iddb = entidad.iddb;
            idrepositorio = entidad.idrepositorio;
            estadodc = entidad.estadodc;
            nombrecuenta = entidad.nombrecuenta;
            cargoreajuste = entidad.cargoreajuste;
            abonoreajuste = entidad.abonoreajuste;

            cargosreajusteyreclasificacion = entidad.cargoreajuste + entidad.cargoreajuste;
            abonoreajusteyreclasificacion = entidad.abonoreajuste + entidad.abonoreajuste;

            observaciondc = entidad.observaciondc;
            cargoreclasificacion = entidad.cargoreclasificacion;
            abonoreclasificacion = entidad.abonoreclasificacion;
            idpapeles = entidad.idpapeles;
            isuso = 0;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;
            m1dc = entidad.m1dc;
            m2dc = entidad.m2dc;
            m3dc = entidad.m3dc;
            m4dc = entidad.m4dc;
            m5dc = entidad.m5dc;
            m6dc = entidad.m6dc;
            m7dc = entidad.m7dc;
            m8dc = entidad.m8dc;
            m9dc = entidad.m9dc;
            m10dc = entidad.m10dc;
            m11dc = entidad.m11dc;
            m12dc = entidad.m12dc;
            m13dc = entidad.m13dc;
            m14dc = entidad.m14dc;
            m15dc = entidad.m15dc;
        }

        public DetalleCedulaModelo(CedulaModelo currentMaestro, EncargoModelo encargo,UsuarioModelo usuario )
        {
            iddc = 0;
            idindice = null;
            idcedula = currentMaestro.idcedula;
            idpartida = null;
            padreiddc = null;
            codigocontabledc = string.Empty;
            saldoactualdc = 0;
            saldoanteriordc = 0;
            aumentodc = 0;
            disminuciondc = 0;
            saldofinaldc = 0;
            ordendc = 0;
            isuso = 0;
            referenciapapel = string.Empty;
            idgenerico = 0;
            tabla = "DETALLECEDULA";
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            idencargo = encargo.idencargo;
            claseregistro = "D";
            filasoperadas = null;
            signooperacion = null;
            idcc = null;
            iddb = null;
            idrepositorio = null;
            estadodc = "A";
            cargoreajuste = 0;
            abonoreajuste = 0;
            observaciondc = null;
            cargoreclasificacion = 0;
            abonoreclasificacion = 0;
            idpapeles = null;
            m1dc = null;
            m2dc = null;
            m3dc = null;
            m4dc = null;
            m5dc = null;
            m6dc = null;
            m7dc = null;
            m8dc = null;
            m9dc = null;
            m10dc = null;
            m11dc = null;
            m12dc = null;
            m13dc = null;
            m14dc = null;
            m15dc = null;

            idnotaspt = null;
            idagenda = null;

            fechacreadodc = MetodosModelo.homologacionFecha();
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            nombreClaseCuenta = string.Empty;
            nombrecuenta = string.Empty;
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;
        }

        #region comparativos
        public static ObservableCollection<DetalleCedulaModelo> GetAllCreacionComparativo(int idsc, int idBalance, int idBalanceC, int idEncargo, UsuarioModelo usuarioModelo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = (from pd in _context.catalogocuentas
                                 join od in _context.detallebalances on pd.idcc equals od.idcc
                                 join ct in _context.detallebalances on od.idcc equals ct.idcc
                                 where pd.idsc == idsc && od.idbalance == idBalance && ct.idbalance == idBalanceC
                                 orderby pd.ordencc
                                 select new DetalleCedulaModelo
                                 {
                                     iddc = 0,
                                     idindice = null,
                                     idcedula = null,
                                     idpartida = null,
                                     padreiddc = null,
                                     codigocontabledc = pd.codigocc,
                                     nombrecuenta = pd.descripcioncc,
                                     nombreClaseCuenta = pd.clasecuenta.descripcionccuentas,
                                     tiposaldocc = pd.tiposaldocc,
                                     saldoactualdc = od.saldofinaldb,//Saldo actual
                                     saldoanteriordc = ct.saldofinaldb,
                                     aumentodc = 0,
                                     disminuciondc = 0,
                                     saldofinaldc = od.saldofinaldb,
                                     //fechacreadodc = MetodosModelo.homologacionFecha(),
                                     ordendc = pd.ordencc,
                                     isuso = 0,
                                     referenciapapel = null,
                                     idgenerico = null,
                                     tabla = "DETALLECEDULA",
                                     usuariocerro = null,
                                     usuarioaprobo = null,
                                     usuariosuperviso = null,
                                     fechasupervision = null,
                                     fechaaprobacion = null,
                                     fechacierre = null,
                                     etapapapel = "I",
                                     idencargo = idEncargo,
                                     claseregistro = "D",
                                     filasoperadas = null,
                                     signooperacion = null,
                                     idcc = pd.idcc,
                                     iddb = od.iddb,
                                     iddbCompara = ct.iddb,
                                     idrepositorio = null,
                                     estadodc = pd.estadocc,
                                     IsSelected = false,
                                     m1dc = null,
                                     m2dc = null,
                                     m3dc = null,
                                     m4dc = null,
                                     m5dc = null,
                                     m6dc = null,
                                     m7dc = null,
                                     m8dc = null,
                                     m9dc = null,
                                     m10dc = null,
                                     m11dc = null,
                                     m12dc = null,
                                     m13dc = null,
                                     m14dc = null,
                                     m15dc = null,

                                     idnotaspt = null,
                                     idagenda = null,
                                     elementoFinanciero = pd.elemento.padreidelemento,

                }).ToList().OrderBy(o => o.ordendc).Where(x => x.estadodc == "A");
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    string temporal = MetodosModelo.homologacionFecha();
                    foreach (DetalleCedulaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        item.fechacreadodc = temporal;
                        item.usuarioModelo = usuarioModelo;
                        if (item.saldoanteriordc != 0 && item.saldoanteriordc != null)
                        {
                            item.aumentodc = item.saldoactualdc - item.saldoanteriordc;
                            item.disminuciondc = ((item.saldoactualdc - item.saldoanteriordc) / item.saldoanteriordc) * 100;
                        }
                        i++;
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<DetalleCedulaModelo>(lista);
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

        public static ObservableCollection<DetalleCedulaModelo> GetAllCreacionUnico(int idsc, int idBalance, int idEncargo, UsuarioModelo usuarioModelo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = (from pd in _context.catalogocuentas
                                 join od in _context.detallebalances on pd.idcc equals od.idcc
                                 where pd.idsc == idsc && od.idbalance == idBalance
                                 orderby pd.ordencc
                                 select new DetalleCedulaModelo
                                 {
                                     iddc = 0,
                                     idindice = null,
                                     idcedula = null,
                                     idpartida = null,
                                     padreiddc = null,
                                     codigocontabledc = pd.codigocc,
                                     nombrecuenta=pd.descripcioncc,
                                     nombreClaseCuenta=pd.clasecuenta.descripcionccuentas,
                                     tiposaldocc = pd.tiposaldocc,
                                     saldoactualdc = od.saldofinaldb,//Saldo actual
                                     saldoanteriordc = 0,
                                     aumentodc = 0,
                                     disminuciondc = 0,
                                     saldofinaldc = od.saldofinaldb,
                                     //fechacreadodc = MetodosModelo.homologacionFecha(),
                                     ordendc = pd.ordencc,
                                     isuso = 0,
                                     referenciapapel = null,
                                     idgenerico = null,
                                     tabla = "DETALLECEDULA",
                                     usuariocerro = null,
                                     usuarioaprobo = null,
                                     usuariosuperviso = null,
                                     fechasupervision = null,
                                     fechaaprobacion = null,
                                     fechacierre = null,
                                     etapapapel = "I",
                                     idencargo = idEncargo,
                                     claseregistro = "D",
                                     filasoperadas = null,
                                     signooperacion = null,
                                     idcc = pd.idcc,
                                     iddb = od.iddb,
                                     iddbCompara = null,
                                     idrepositorio = null,
                                     estadodc = "A",
                                     IsSelected = false,
                                     m1dc = null,
                                     m2dc = null,
                                     m3dc = null,
                                     m4dc = null,
                                     m5dc = null,
                                     m6dc = null,
                                     m7dc = null,
                                     m8dc = null,
                                     m9dc = null,
                                     m10dc = null,
                                     m11dc = null,
                                     m12dc = null,
                                     m13dc = null,
                                     m14dc = null,
                                     m15dc = null,

                                     idnotaspt = null,
                                     idagenda = null,
                                     elementoFinanciero = pd.elemento.padreidelemento,
                                 }).ToList().OrderBy(o => o.ordendc).Where(x => x.estadodc == "A");
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    string temporal = MetodosModelo.homologacionFecha();
                    foreach (DetalleCedulaModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        item.fechacreadodc = temporal;
                        item.usuarioModelo = usuarioModelo;
                        i++;
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<DetalleCedulaModelo>(lista);
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

        #endregion

        #region operaciones

        public DetalleCedulaModelo(ObservableCollection<DetalleCedulaModelo> lista, UsuarioModelo usuario, int idEncargo,string signoOperacion,CedulaModelo modelo)
        {

            iddc = 0;
            idindice = null;
            idcedula = modelo.idcedula;
            idpartida = null;
            padreiddc = null;
            //Se usara para  identificar el tipo de área

            codigocontabledc =lista.Min(x=>x.elementoFinanciero).ToString();

            saldoactualdc = lista.Sum(x=>x.saldoactualdc);
            if (lista.Sum(x => x.saldoanteriordc) > 0)
            {
                saldoanteriordc = lista.Sum(x => x.saldoanteriordc);
            }
            else
            {
                saldoanteriordc = 0;
            }
            aumentodc = saldoactualdc-saldoanteriordc;
            if (saldoanteriordc !=0 && saldoanteriordc!=null)
            {
                disminuciondc = (aumentodc / saldoanteriordc) * 100;
            }
            else
            {
                disminuciondc = 0;
            }

            saldofinaldc = lista.Sum(x => x.saldofinaldc);
            ordendc =lista.Max(x=>x.ordendc)+1;
            isuso = 0;
            referenciapapel = string.Empty;
            idgenerico = 0;
            tabla = "DETALLECEDULA";
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            idencargo = idEncargo;
            claseregistro = "S";
            filasoperadas = "";
            signooperacion = signoOperacion;
                foreach (detallecedula item in lista)
                {
                    filasoperadas = filasoperadas + signooperacion + item.iddc;
                }
            idcc = null;
            iddb = null;
            idrepositorio = null;
            estadodc = "A";
            cargoreajuste = 0;
            abonoreajuste = 0;
            observaciondc = null;
            cargoreclasificacion = 0;
            abonoreclasificacion = 0;
            idpapeles = null;
            m1dc = null;
            m2dc = null;
            m3dc = null;
            m4dc = null;
            m5dc = null;
            m6dc = null;
            m7dc = null;
            m8dc = null;
            m9dc = null;
            m10dc = null;
            m11dc = null;
            m12dc = null;
            m13dc = null;
            m14dc = null;
            m15dc = null;

            idnotaspt = null;
            idagenda = null;

            fechacreadodc = MetodosModelo.homologacionFecha();
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            nombreClaseCuenta = string.Empty;
            nombrecuenta = "Totales"; 
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;
        }

        public DetalleCedulaModelo(ObservableCollection<detallecedula> lista, UsuarioModelo usuario, int idEncargo, string signoOperacion)
        {

            iddc = 0;
            idindice = null;
            idcedula = 0;
            idpartida = null;
            padreiddc = null;
            codigocontabledc = string.Empty;
            saldoactualdc = lista.Sum(x => x.saldoactualdc);
            if (lista.Sum(x => x.saldoanteriordc) > 0)
            {
                saldoanteriordc = lista.Sum(x => x.saldoanteriordc);
            }
            else
            {
                saldoanteriordc = 0;
            }
            aumentodc = saldoactualdc - saldoanteriordc;
            if (saldoanteriordc > 0)
            {
                disminuciondc = (aumentodc / saldoanteriordc) * 100;
            }
            else
            {
                disminuciondc = 0;
            }

            saldofinaldc = lista.Sum(x => x.saldofinaldc);
            ordendc = lista.Max(x => x.ordendc) + 1;
            isuso = 0;
            referenciapapel = string.Empty;
            idgenerico = 0;
            tabla = "DETALLECEDULA";
            usuariocerro = string.Empty;
            usuarioaprobo = string.Empty;
            usuariosuperviso = string.Empty;
            fechasupervision = null;
            fechaaprobacion = null;
            fechacierre = null;
            idencargo = idEncargo;
            claseregistro = "S";
            filasoperadas = "";
            signooperacion = signoOperacion;
            foreach (detallecedula item in lista)
            {
                filasoperadas = filasoperadas + signooperacion + item.iddc;
            }
            idcc = null;
            iddb = null;
            idrepositorio = null;
            estadodc = "A";
            cargoreajuste = 0;
            abonoreajuste = 0;
            observaciondc = null;
            cargoreclasificacion = 0;
            abonoreclasificacion = 0;
            idpapeles = null;
            m1dc = null;
            m2dc = null;
            m3dc = null;
            m4dc = null;
            m5dc = null;
            m6dc = null;
            m7dc = null;
            m8dc = null;
            m9dc = null;
            m10dc = null;
            m11dc = null;
            m12dc = null;
            m13dc = null;
            m14dc = null;
            m15dc = null;

            idnotaspt = null;
            idagenda = null;

            fechacreadodc = MetodosModelo.homologacionFecha();
            etapapapel = EtapaEncargoModelo.seleccionEtapaIniciales(1);
            nombreClaseCuenta = string.Empty;
            nombrecuenta = "Totales";
            usuarioModelo = usuario;
            IsSelected = false;
            guardadoBase = false;
            variaciónporcentual = 0;
            saldoreajustado = 0;
        }

        #endregion
    }

}
