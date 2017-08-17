using CapaDatos;
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
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

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class DetalleMatrizRiesgoModelo : UIBase
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

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[DisplayName("Código")]
        //public int iddmr
        //{
        //    get { return GetValue(() => iddmr); }
        //    set { SetValue(() => iddmr, value); }
        //}
        #region iddmr
        public int _iddmr;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int iddmr
        {
            get { return _iddmr; }
            set { _iddmr = value; }
        }

        #endregion
        //Identifica el  tipo de elemento contable
        public int? idprograma
        {
            get { return GetValue(() => idprograma); }
            set { SetValue(() => idprograma, value); }
        }

        //Vincula con el sistema contable asociado y asu vez con  el encargo
        public int? idmaterialidad
        {
            get { return GetValue(() => idmaterialidad); }
            set { SetValue(() => idmaterialidad, value); }
        }

        //Encargo al  que corresponde la evaluacion
        public int idmr
        {
            get { return GetValue(() => idmr); }
            set { SetValue(() => idmr, value); }
        }

        //Balance del que se toma la informacion financiera
        public int? idbalance
        {
            get { return GetValue(() => idbalance); }
            set { SetValue(() => idbalance, value); }
        }

        public string codigocontabledmr
        {
            get { return GetValue(() => codigocontabledmr); }
            set { SetValue(() => codigocontabledmr, value); }
        }
        //Fecha a la que corresponde la informacion financiera de los saldos finales
        public string nombredmr
        {
            get { return GetValue(() => nombredmr); }
            set { SetValue(() => nombredmr, value); }
        }
        public decimal saldoevaluaciondmr
        {
            get { return GetValue(() => saldoevaluaciondmr); }
            set { SetValue(() => saldoevaluaciondmr, value); }
        }
        
        public string factoresriesgodmr
        {
            get { return GetValue(() => factoresriesgodmr); }
            set { SetValue(() => factoresriesgodmr, value); }
        }
        public string evaluacioninherentedmr
        {
            get { return GetValue(() => evaluacioninherentedmr); }
            set { SetValue(() => evaluacioninherentedmr, value); }
        }
        
        public string evaluacioncontroldmr
        {
            get { return GetValue(() => evaluacioncontroldmr); }
            set { SetValue(() => evaluacioncontroldmr, value); }
        }
        public string evaluacioncombinadodmr
        {
            get { return GetValue(() => evaluacioncombinadodmr); }
            set { SetValue(() => evaluacioncombinadodmr, value); }
        }

        public string justificaevaluadmr
        {
            get { return GetValue(() => justificaevaluadmr); }
            set { SetValue(() => justificaevaluadmr, value); }
        }
        public string clasespruebasdmr
        {
            get { return GetValue(() => clasespruebasdmr); }
            set { SetValue(() => clasespruebasdmr, value); }
        }

        public string  procedimientosdmr
        {
            get { return GetValue(() =>  procedimientosdmr); }
            set { SetValue(() =>  procedimientosdmr, value); }
        }

        [DisplayName("Riesgo inherente")]
        [Required(ErrorMessage = "Debe ingresar el riesgo de inherente")]
        [Range(0, 100)]
        public decimal? alcanceinherentedmr
        {
            get { return GetValue(() => alcanceinherentedmr); }
            set { SetValue(() => alcanceinherentedmr, value); }
        }
        [DisplayName("Riesgo control")]
        [Required(ErrorMessage = "Debe ingresar el riesgo de control")]
        [Range(0, 100)]
        public decimal? alcancecontroldmr
        {
            get { return GetValue(() => alcancecontroldmr); }
            set { SetValue(() => alcancecontroldmr, value); }
        }
        [DisplayName("Riesgo inherente")]
        [Required(ErrorMessage = "Debe ingresar el riesgo de deteccion")]
        [Range(0, 100)]
        public decimal? alcancecombinadodmr
        {
            get { return GetValue(() => alcancecombinadodmr); }
            set { SetValue(() => alcancecombinadodmr, value); }
        }
        
        public decimal? riesgoAuditoriadmr
        {
            get { return GetValue(() => riesgoAuditoriadmr); }
            set { SetValue(() => riesgoAuditoriadmr, value); }
        }
        public string justificaalcancedmr
        {
            get { return GetValue(() => justificaalcancedmr); }
            set { SetValue(() => justificaalcancedmr, value); }
        }
        public decimal? materialidaddmr
        {
            get { return GetValue(() => materialidaddmr); }
            set { SetValue(() => materialidaddmr, value); }
        }
        //Permite administrar la presentacion
        public decimal? ordencc
        {
            get { return GetValue(() => ordencc); }
            set { SetValue(() => ordencc, value); }
        }

        //Permite la gestión del borrado lógico de los elementos identificándose por A) Activo, B) Borrado
        public string estadodmr
        {
            get { return GetValue(() => estadodmr); }
            set { SetValue(() => estadodmr, value); }
        }

        //NULL=> No usado; 0=> Disponible; 1=> En edicion (Solo debera permitir consultar.)
        public int? isuso
        {
            get { return GetValue(() => isuso); }
            set { SetValue(() => isuso, value); }
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

        public string inicialesusuarioCreo
        {
            get { return GetValue(() => inicialesusuarioCreo); }
            set { SetValue(() => inicialesusuarioCreo, value); }
        }
        public string inicialesusuarioSuperviso
        {
            get { return GetValue(() => inicialesusuarioSuperviso); }
            set { SetValue(() => inicialesusuarioSuperviso, value); }
        }
        public string inicialesusuarioAprobo
        {
            get { return GetValue(() => inicialesusuarioAprobo); }
            set { SetValue(() => inicialesusuarioAprobo, value); }
        }

        #endregion

        #region propiedades para listas
        public string idnitcliente //Tomada de sistema contable
        {
            get { return GetValue(() => idnitcliente); }
            set { SetValue(() => idnitcliente, value); }
        }

        #endregion

        #region colecciones virtuales

        public virtual matrizriesgo matrizRiesgo
        {
            get { return GetValue(() => matrizRiesgo); }
            set { SetValue(() => matrizRiesgo, value); }
        }
        //public virtual UsuarioModelo usuarioModelo
        //{
        //    get { return GetValue(() => usuarioModelo); }
        //    set { SetValue(() => usuarioModelo, value); }
        //}

        #region usuarioModelo

        public UsuarioModelo _usuarioModelo;
        public UsuarioModelo usuarioModelo
        {
            get { return _usuarioModelo; }
            set { _usuarioModelo = value; }
        }

        #endregion
        //Permite evitar duplicacion el critero periodicidad, clase balance, fecha 
        public ObservableCollection<DetalleMatrizRiesgoModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        public virtual MatrizRiesgoModelo matrizRiesgoModelo
        {
            get { return GetValue(() => matrizRiesgoModelo); }
            set { SetValue(() => matrizRiesgoModelo, value); }
        }
        #endregion

        #region Public Model Methods

        public static bool Insert(DetalleMatrizRiesgoModelo modelo, bool resultado)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallematrizriesgos', 'iddmr'), (SELECT MAX(iddmr) FROM sgpt.detallematrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallematrizriesgo
                        {
                            //iddmr = modelo.iddmr,
                            idprograma = modelo.idprograma,
                            idmaterialidad = modelo.idmaterialidad,
                            idmr = modelo.idmr,
                            codigocontabledmr = modelo.codigocontabledmr,
                            nombredmr = modelo.nombredmr,
                            saldoevaluaciondmr = modelo.saldoevaluaciondmr,
                            factoresriesgodmr = modelo.factoresriesgodmr,
                            evaluacioninherentedmr = modelo.evaluacioninherentedmr,
                            evaluacioncontroldmr = modelo.evaluacioncontroldmr,
                            evaluacioncombinadodmr = modelo.evaluacioncombinadodmr,
                            justificaevaluadmr = modelo.justificaevaluadmr,
                            clasespruebasdmr = modelo.clasespruebasdmr,
                            procedimientosdmr = modelo.procedimientosdmr,
                            alcanceinherentedmr = modelo.alcanceinherentedmr,
                            alcancecontroldmr = modelo.alcancecontroldmr,
                            alcancecombinadodmr = modelo.alcancecombinadodmr,
                            justificaalcancedmr = modelo.justificaalcancedmr,
                            materialidaddmr = modelo.materialidaddmr,
                            estadodmr = modelo.estadodmr,
                            isuso = modelo.isuso,
                            ordencc=modelo.ordencc,

                        };
                        _context.detallematrizriesgos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.iddmr = tablaDestino.iddmr;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLEMATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(1));
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
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool InsertCapaDatos(detallematrizriesgo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallematrizriesgos', 'iddmr'), (SELECT MAX(iddmr) FROM sgpt.detallematrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.detallematrizriesgos.Add(modelo);
                        _context.SaveChanges();
                        modelo.iddmr = modelo.iddmr;
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
        public static int Insert(DetalleMatrizRiesgoModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallematrizriesgos', 'iddmr'), (SELECT MAX(iddmr) FROM sgpt.detallematrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new detallematrizriesgo
                        {
                            //iddmr = modelo.iddmr,
                            idprograma = modelo.idprograma,
                            idmaterialidad = modelo.idmaterialidad,
                            idmr = modelo.idmr,
                            codigocontabledmr = modelo.codigocontabledmr,
                            nombredmr = modelo.nombredmr,
                            saldoevaluaciondmr = modelo.saldoevaluaciondmr,
                            factoresriesgodmr = modelo.factoresriesgodmr,
                            evaluacioninherentedmr = modelo.evaluacioninherentedmr,
                            evaluacioncontroldmr = modelo.evaluacioncontroldmr,
                            evaluacioncombinadodmr = modelo.evaluacioncombinadodmr,
                            justificaevaluadmr = modelo.justificaevaluadmr,
                            clasespruebasdmr = modelo.clasespruebasdmr,
                            procedimientosdmr = modelo.procedimientosdmr,
                            alcanceinherentedmr = modelo.alcanceinherentedmr,
                            alcancecontroldmr = modelo.alcancecontroldmr,
                            alcancecombinadodmr = modelo.alcancecombinadodmr,
                            justificaalcancedmr = modelo.justificaalcancedmr,
                            materialidaddmr = modelo.materialidaddmr,
                            estadodmr = modelo.estadodmr,
                            isuso = modelo.isuso,
                            ordencc=modelo.ordencc,

                        };
                        _context.detallematrizriesgos.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.iddmr = tablaDestino.iddmr;
                        result = 1;
                        BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLEMATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(1));
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            //modelo.listaBitacora.Add(temporal);
                        }
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

        public static int InsertInicializacion(MatrizRiesgoModelo modelo, int nivel)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallematrizriesgos', 'iddmr'), (SELECT MAX(iddmr) FROM sgpt.detallematrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        //Obtener registros de cuentas
                        var listaCuentas = DetalleBalanceModelo.GetAllByIdBCAndClaseCuenta((int)modelo.idbalance,nivel);
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var entidad = new detallematrizriesgo();

                        if (listaCuentas.Count > 0)
                        {
                            foreach (DetalleBalanceModelo item in listaCuentas)
                            {
                                
                                entidad = new detallematrizriesgo();
                               // entidad.iddmr = modelo.idmr;
                                //entidad.idprograma = null;
                                //entidad.idmaterialidad = null;
                                entidad.idmr = modelo.idmr;
                                entidad.codigocontabledmr =item.codigoccdb;
                                entidad.nombredmr = item.nombreCuenta;
                                
                                entidad.saldoevaluaciondmr = item.saldofinaldb;
                                //entidad.factoresriesgodmr = modelo.factoresriesgodmr;
                                entidad.evaluacioninherentedmr = "ALTO";
                                entidad.evaluacioncontroldmr = "ALTO";
                                entidad.evaluacioncombinadodmr = "ALTO";
                                //entidad.justificaevaluadmr = modelo.justificaevaluadmr;
                                //entidad.clasespruebasdmr = modelo.clasespruebasdmr;
                                //entidad.procedimientosdmr = modelo.procedimientosdmr;
                                entidad.alcanceinherentedmr = 100;
                                entidad.alcancecontroldmr = 100;
                                entidad.alcancecombinadodmr = 100;
                                //entidad.justificaalcancedmr = modelo.justificaalcancedmr;
                                entidad.materialidaddmr = 0;
                                entidad.estadodmr = "A";
                                entidad.isuso = 0;
                                entidad.ordencc = item.orden;
                                _context.detallematrizriesgos.Add(entidad);
                                _context.SaveChanges();
                                entidad = null;
                            }
                        }
                        result = 1;
                       /* BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLEMATRIZRIESGOS", "Creacion");
                        //Crear registro de bitacora
                        if (BitacoraModelo.Insert(temporal) == 1)
                        {
                            //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                            //modelo.listaBitacora.Add(temporal);
                        }
                        result = 1;*/
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
        public static int InsertByRange(ObservableCollection<detallematrizriesgo> lista)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detallematrizriesgos', 'iddmr'), (SELECT MAX(iddmr) FROM sgpt.detallematrizriesgos) + 1);");
                            sincronizar = true;
                        }
                        _context.detallematrizriesgos.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro \n" + e);
                    return -1;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static DetalleMatrizRiesgoModelo Find(int id)
        {
            var entidad = new DetalleMatrizRiesgoModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detallematrizriesgo modelo = _context.detallematrizriesgos.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.iddmr = modelo.iddmr;
                        entidad.idprograma = modelo.idprograma;
                        entidad.idmaterialidad = modelo.idmaterialidad;
                        entidad.idmr = modelo.idmr;
                        entidad.codigocontabledmr = modelo.codigocontabledmr;
                        entidad.nombredmr = modelo.nombredmr;
                        entidad.saldoevaluaciondmr = modelo.saldoevaluaciondmr;
                        entidad.factoresriesgodmr = modelo.factoresriesgodmr;
                        entidad.evaluacioninherentedmr = modelo.evaluacioninherentedmr;
                        entidad.evaluacioncontroldmr = modelo.evaluacioncontroldmr;
                        entidad.evaluacioncombinadodmr = modelo.evaluacioncombinadodmr;
                        entidad.justificaevaluadmr = modelo.justificaevaluadmr;
                        entidad.clasespruebasdmr = modelo.clasespruebasdmr;
                        entidad.procedimientosdmr = modelo.procedimientosdmr;
                        entidad.alcanceinherentedmr = modelo.alcanceinherentedmr;
                        entidad.alcancecontroldmr = modelo.alcancecontroldmr;
                        entidad.alcancecombinadodmr = modelo.alcancecombinadodmr;
                        entidad.justificaalcancedmr = modelo.justificaalcancedmr;
                        entidad.materialidaddmr = modelo.materialidaddmr;
                        entidad.estadodmr = modelo.estadodmr;
                        entidad.isuso = modelo.isuso;
                        entidad.ordencc = modelo.ordencc;
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
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

        #region Metodos para string 

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetalleMatrizRiesgoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    detallematrizriesgo entidad = _context.detallematrizriesgos.Find(id);
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
                    var modelo = new DetalleMatrizRiesgoModelo();
                    detallematrizriesgo entidad = _context.detallematrizriesgos.Find(id);
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
                    var modelo = new DetalleMatrizRiesgoModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detallematrizriesgos
                            .Where(b => b.estadodmr == "B")
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
                    detallematrizriesgo entidad = _context.detallematrizriesgos.Find(id);
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

        public static void UpdateModelo(DetalleMatrizRiesgoModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detallematrizriesgo entidad = _context.detallematrizriesgos.Find(modelo.iddmr);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.iddmr = modelo.iddmr;
                        entidad.idprograma = modelo.idprograma;
                        entidad.idmaterialidad = modelo.idmaterialidad;
                        entidad.idmr = modelo.idmr;
                        entidad.codigocontabledmr = modelo.codigocontabledmr;
                        entidad.nombredmr = modelo.nombredmr;
                        entidad.saldoevaluaciondmr = modelo.saldoevaluaciondmr;
                        entidad.factoresriesgodmr = modelo.factoresriesgodmr;
                        entidad.evaluacioninherentedmr = modelo.evaluacioninherentedmr;
                        entidad.evaluacioncontroldmr = modelo.evaluacioncontroldmr;
                        entidad.evaluacioncombinadodmr = modelo.evaluacioncombinadodmr;
                        entidad.justificaevaluadmr = modelo.justificaevaluadmr;
                        entidad.clasespruebasdmr = modelo.clasespruebasdmr;
                        entidad.procedimientosdmr = modelo.procedimientosdmr;
                        entidad.alcanceinherentedmr = modelo.alcanceinherentedmr;
                        entidad.alcancecontroldmr = modelo.alcancecontroldmr;
                        entidad.alcancecombinadodmr = modelo.alcancecombinadodmr;
                        entidad.justificaalcancedmr = modelo.justificaalcancedmr;
                        entidad.materialidaddmr = modelo.materialidaddmr;
                        entidad.estadodmr = modelo.estadodmr;
                        entidad.isuso = modelo.isuso;
                        entidad.ordencc = modelo.ordencc;
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

        public static bool UpdateModelo(DetalleMatrizRiesgoModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        detallematrizriesgo entidad = _context.detallematrizriesgos.Find(modelo.iddmr);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            if(entidad.iddmr != modelo.iddmr) {cambio=true;}
                            if(entidad.idprograma != modelo.idprograma) {cambio=true;}
                            if(entidad.idmaterialidad != modelo.idmaterialidad) {cambio=true;}
                            if(entidad.idmr != modelo.idmr) {cambio=true;}
                            if(entidad.codigocontabledmr != modelo.codigocontabledmr) {cambio=true;}
                            if(entidad.nombredmr != modelo.nombredmr) {cambio=true;}
                            if(entidad.saldoevaluaciondmr != modelo.saldoevaluaciondmr) {cambio=true;}
                            if(entidad.factoresriesgodmr != modelo.factoresriesgodmr) {cambio=true;}
                            if(entidad.evaluacioninherentedmr != modelo.evaluacioninherentedmr) {cambio=true;}
                            if(entidad.evaluacioncontroldmr != modelo.evaluacioncontroldmr) {cambio=true;}
                            if(entidad.evaluacioncombinadodmr != modelo.evaluacioncombinadodmr) {cambio=true;}
                            if(entidad.justificaevaluadmr != modelo.justificaevaluadmr) {cambio=true;}
                            if(entidad.clasespruebasdmr != modelo.clasespruebasdmr) {cambio=true;}
                            if(entidad.procedimientosdmr != modelo.procedimientosdmr) {cambio=true;}
                            if(entidad.alcanceinherentedmr != modelo.alcanceinherentedmr) {cambio=true;}
                            if(entidad.alcancecontroldmr != modelo.alcancecontroldmr) {cambio=true;}
                            if(entidad.alcancecombinadodmr != modelo.alcancecombinadodmr) {cambio=true;}
                            if(entidad.justificaalcancedmr != modelo.justificaalcancedmr) {cambio=true;}
                            if(entidad.materialidaddmr != modelo.materialidaddmr) {cambio=true;}
                            if (cambio)
                            {
                                //entidad.iddmr = modelo.iddmr;
                                entidad.iddmr = modelo.iddmr;
                                entidad.idprograma = modelo.idprograma;
                                entidad.idmaterialidad = modelo.idmaterialidad;
                                entidad.idmr = modelo.idmr;
                                entidad.codigocontabledmr = modelo.codigocontabledmr;
                                entidad.nombredmr = modelo.nombredmr;
                                entidad.saldoevaluaciondmr = modelo.saldoevaluaciondmr;
                                entidad.factoresriesgodmr = modelo.factoresriesgodmr;
                                entidad.evaluacioninherentedmr = modelo.evaluacioninherentedmr;
                                entidad.evaluacioncontroldmr = modelo.evaluacioncontroldmr;
                                entidad.evaluacioncombinadodmr = modelo.evaluacioncombinadodmr;
                                entidad.justificaevaluadmr = modelo.justificaevaluadmr;
                                entidad.clasespruebasdmr = modelo.clasespruebasdmr;
                                entidad.procedimientosdmr = modelo.procedimientosdmr;
                                entidad.alcanceinherentedmr = modelo.alcanceinherentedmr;
                                entidad.alcancecontroldmr = modelo.alcancecontroldmr;
                                entidad.alcancecombinadodmr = modelo.alcancecombinadodmr;
                                entidad.justificaalcancedmr = modelo.justificaalcancedmr;
                                entidad.materialidaddmr = modelo.materialidaddmr;
                                entidad.estadodmr = modelo.estadodmr;
                                entidad.isuso = modelo.isuso;

                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //Inserción de modificacion
                                BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLEMATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(2));
                                temporal.detallebitacora = "Actualización de datos";
                                //Crear registro de bitacora
                                if (BitacoraModelo.Insert(temporal) == 1)
                                {
                                    //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                    //modelo.listaBitacora.Add(temporal);
                                }
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
                return false;
            }
        }

        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogico(int id, DetalleMatrizRiesgoModelo modelo)
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
                            BitacoraModelo temporal = new BitacoraModelo(modelo, "DETALLEMATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(8));
                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                                //temporal.idCorrelativoBit = modelo.listaBitacora.Count() + 1;
                                //modelo.listaBitacora.Add(temporal);
                            }

                            #endregion 

                            string commandString = String.Format("UPDATE sgpt.detallematrizriesgos SET estadodmr = 'B' WHERE iddmr={0};", id);
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

        public static bool Delete(ObservableCollection<DetalleMatrizRiesgoModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Debe borrar los hijos
                        detallematrizriesgo entidadTemporal = new detallematrizriesgo();
                        string commandString = string.Empty;
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            //Borrado de bitacora
                            BitacoraModelo.DeleteByTransaccion(item.iddmr);//Borra todas las referencias dentro  de bitacora
                            //Buscar registro
                            commandString = string.Format("DELETE FROM sgpt.detallematrizriesgos WHERE iddmr={0};", item.iddmr);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
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
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return false;
                throw;
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
                        BitacoraModelo.DeleteByTransaccion(id, "DETALLEMATRIZRIESGOS");//Borra todas las referencias dentro  de bitacora

                        string commandString = String.Format("DELETE FROM sgpt.detallematrizriesgos WHERE iddmr={0};", id);
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

        public static void DeleteByRange(ObservableCollection<detallematrizriesgo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        _context.detallematrizriesgos.RemoveRange(lista);
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

                        //DetalleDetalleMatrizRiesgoModelo.DeleteAllByBalance(id);

                        //fin de borrado del detalle
                        //Borrado del registro
                        string commandString = String.Format("DELETE FROM sgpt.detallematrizriesgos WHERE iddmr={0};", id);
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
                throw;
            }
        }


        public static bool DeleteBorradoLogico(ObservableCollection<DetalleMatrizRiesgoModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    //Debe borrar los hijos
                    detallematrizriesgo entidadTemporal = new detallematrizriesgo();
                    int idmaterialidad = (int)lista[0].idmaterialidad;
                    string commandString = "";
                    using (_context = new SGPTEntidades())
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            #region bitacora

                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.iddmr);//Borra todas las referencias dentro  de bitacora
                                                                                         //Inserta registro de borrado
                            BitacoraModelo temporal = new BitacoraModelo(item, "DETALLEMATRIZRIESGOS", EtapaEncargoModelo.seleccionEtapa(8));

                            //Crear registro de bitacora
                            if (BitacoraModelo.Insert(temporal) == 1)
                            {
                               // temporal.idCorrelativoBit = item.listaBitacora.Count() + 1;
                               // item.listaBitacora.Add(temporal);
                            }
                            BitacoraModelo.DeleteBorradoLogicoByIdTransaccion(item.iddmr);//Borra todas las referencias dentro  de bitacora

                            #endregion
                            commandString = String.Format("UPDATE sgpt.detallematrizriesgos SET estadodmr = 'B' WHERE iddmr={0};", item.iddmr);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
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

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<detallematrizriesgo> lista, int iddmr)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detallematrizriesgos SET estadodmr = 'B' WHERE iddmr = {0};", iddmr);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        //Se elimina todo el contenido
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
        public static explicit operator detallematrizriesgo(DetalleMatrizRiesgoModelo modelo)  // explicit byte to digit conversion operator
        {
            detallematrizriesgo entidad = new detallematrizriesgo();
            entidad.iddmr = modelo.iddmr;
            entidad.idprograma = modelo.idprograma;
            entidad.idmaterialidad = modelo.idmaterialidad;
            entidad.idmr = modelo.idmr;
            entidad.codigocontabledmr = modelo.codigocontabledmr;
            entidad.nombredmr = modelo.nombredmr;
            entidad.saldoevaluaciondmr = modelo.saldoevaluaciondmr;
            entidad.factoresriesgodmr = modelo.factoresriesgodmr;
            entidad.evaluacioninherentedmr = modelo.evaluacioninherentedmr;
            entidad.evaluacioncontroldmr = modelo.evaluacioncontroldmr;
            entidad.evaluacioncombinadodmr = modelo.evaluacioncombinadodmr;
            entidad.justificaevaluadmr = modelo.justificaevaluadmr;
            entidad.clasespruebasdmr = modelo.clasespruebasdmr;
            entidad.procedimientosdmr = modelo.procedimientosdmr;
            entidad.alcanceinherentedmr = modelo.alcanceinherentedmr;
            entidad.alcancecontroldmr = modelo.alcancecontroldmr;
            entidad.alcancecombinadodmr = modelo.alcancecombinadodmr;
            entidad.justificaalcancedmr = modelo.justificaalcancedmr;
            entidad.materialidaddmr = modelo.materialidaddmr;
            entidad.estadodmr = modelo.estadodmr;
            entidad.isuso = modelo.isuso;
            entidad.ordencc = modelo.ordencc;
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

                            //Debe remover el  detalle del balance para no  dejar huerfanos

                            //Verificar que  no existan registros relacionados

                            string commandString = String.Format("DELETE FROM sgpt.detallematrizriesgos WHERE iddmr={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : \n" + e);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<DetalleMatrizRiesgoModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallematrizriesgos.Select(entidad =>
                     new DetalleMatrizRiesgoModelo
                     {
                         iddmr = entidad.iddmr,
                         idprograma = entidad.idprograma,
                         idmaterialidad = entidad.idmaterialidad,
                         idmr = entidad.idmr,
                         codigocontabledmr = entidad.codigocontabledmr,
                         nombredmr = entidad.nombredmr,
                         saldoevaluaciondmr = entidad.saldoevaluaciondmr,
                         factoresriesgodmr = entidad.factoresriesgodmr,
                         evaluacioninherentedmr = entidad.evaluacioninherentedmr,
                         evaluacioncontroldmr = entidad.evaluacioncontroldmr,
                         evaluacioncombinadodmr = entidad.evaluacioncombinadodmr,
                         justificaevaluadmr = entidad.justificaevaluadmr,
                         clasespruebasdmr = entidad.clasespruebasdmr,
                         procedimientosdmr = entidad.procedimientosdmr,
                         alcanceinherentedmr = entidad.alcanceinherentedmr,
                         alcancecontroldmr = entidad.alcancecontroldmr,
                         alcancecombinadodmr = entidad.alcancecombinadodmr,
                         justificaalcancedmr = entidad.justificaalcancedmr,
                         materialidaddmr = entidad.materialidaddmr,
                         estadodmr = entidad.estadodmr,
                         isuso = entidad.isuso,
                         ordencc=entidad.ordencc
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordencc).Where(x => x.estadodmr == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    var listaBitacora = BitacoraModelo.GetAllByTabla("DETALLEMATRIZRIESGOS");
                    if (listaBitacora.Count > 0)
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                       }
                    }
                    else
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitara
                            item.inicialesusuarioCreo = string.Empty;
                            item.inicialesusuarioSuperviso = string.Empty;
                            item.inicialesusuarioAprobo = string.Empty;
                        }
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
                    MessageBox.Show("Exception en elaboracion de lista  \n" + e);
                }
                return null;
            }
        }

        public static List<DetalleMatrizRiesgoModelo> GetAll(MatrizRiesgoModelo riesgos)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallematrizriesgos.Select(entidad =>
                     new DetalleMatrizRiesgoModelo
                     {
                         iddmr = entidad.iddmr,
                         idprograma = entidad.idprograma,
                         idmaterialidad = entidad.idmaterialidad,
                         idmr = entidad.idmr,
                         codigocontabledmr = entidad.codigocontabledmr,
                         nombredmr = entidad.nombredmr,
                         saldoevaluaciondmr = entidad.saldoevaluaciondmr,
                         factoresriesgodmr = entidad.factoresriesgodmr,
                         evaluacioninherentedmr = entidad.evaluacioninherentedmr,
                         evaluacioncontroldmr = entidad.evaluacioncontroldmr,
                         evaluacioncombinadodmr = entidad.evaluacioncombinadodmr,
                         justificaevaluadmr = entidad.justificaevaluadmr,
                         clasespruebasdmr = entidad.clasespruebasdmr,
                         procedimientosdmr = entidad.procedimientosdmr,
                         alcanceinherentedmr = entidad.alcanceinherentedmr,
                         alcancecontroldmr = entidad.alcancecontroldmr,
                         alcancecombinadodmr = entidad.alcancecombinadodmr,
                         justificaalcancedmr = entidad.justificaalcancedmr,
                         materialidaddmr = entidad.materialidaddmr,
                         estadodmr = entidad.estadodmr,
                         isuso = entidad.isuso,
                         ordencc=entidad.ordencc,
                         riesgoAuditoriadmr= (entidad.alcanceinherentedmr/100* entidad.alcancecombinadodmr/100* entidad.alcancecontroldmr/100)*100,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordencc).Where(x => x.estadodmr == "A" && x.idmr == riesgos.idmr).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    var listaBitacora = BitacoraModelo.GetAllByTabla("DETALLEMATRIZRIESGOS");
                    if (listaBitacora.Count > 0)
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                        }
                    }
                    else
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitara
                            item.inicialesusuarioCreo = string.Empty;
                            item.inicialesusuarioSuperviso = string.Empty;
                            item.inicialesusuarioAprobo = string.Empty;
                        }
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

        public static List<DetalleMatrizRiesgoModelo> GetAll(MatrizRiesgoModelo riesgos,UsuarioModelo usuario)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallematrizriesgos.Select(entidad =>
                     new DetalleMatrizRiesgoModelo
                     {
                         iddmr = entidad.iddmr,
                         idprograma = entidad.idprograma,
                         idmaterialidad = entidad.idmaterialidad,
                         idmr = entidad.idmr,
                         codigocontabledmr = entidad.codigocontabledmr,
                         nombredmr = entidad.nombredmr,
                         saldoevaluaciondmr = entidad.saldoevaluaciondmr,
                         factoresriesgodmr = entidad.factoresriesgodmr,
                         evaluacioninherentedmr = entidad.evaluacioninherentedmr,
                         evaluacioncontroldmr = entidad.evaluacioncontroldmr,
                         evaluacioncombinadodmr = entidad.evaluacioncombinadodmr,
                         justificaevaluadmr = entidad.justificaevaluadmr,
                         clasespruebasdmr = entidad.clasespruebasdmr,
                         procedimientosdmr = entidad.procedimientosdmr,
                         alcanceinherentedmr = entidad.alcanceinherentedmr,
                         alcancecontroldmr = entidad.alcancecontroldmr,
                         alcancecombinadodmr = entidad.alcancecombinadodmr,
                         justificaalcancedmr = entidad.justificaalcancedmr,
                         materialidaddmr = entidad.materialidaddmr,
                         estadodmr = entidad.estadodmr,
                         isuso = entidad.isuso,
                         ordencc = entidad.ordencc,
                         riesgoAuditoriadmr = (entidad.alcanceinherentedmr / 100 * entidad.alcancecombinadodmr / 100 * entidad.alcancecontroldmr / 100) * 100,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordencc).Where(x => x.estadodmr == "A" && x.idmr == riesgos.idmr).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    var listaBitacora = BitacoraModelo.GetAllByTabla("DETALLEMATRIZRIESGOS");
                    if (listaBitacora.Count > 0)
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            item.usuarioModelo = usuario;
                        }
                    }
                    else
                    {
                        foreach (DetalleMatrizRiesgoModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            //Buscar en bitara
                            item.inicialesusuarioCreo = string.Empty;
                            item.inicialesusuarioSuperviso = string.Empty;
                            item.inicialesusuarioAprobo = string.Empty;
                            item.usuarioModelo = usuario;
                        }
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
        public static ObservableCollection<detallematrizriesgo> GetAllCapaDatosByidmr(int idmr)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.detallematrizriesgos.Where(entidad => (entidad.idmr == idmr && entidad.estadodmr == "A"));
                    ObservableCollection<detallematrizriesgo> temporal = new ObservableCollection<detallematrizriesgo>(lista);
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

        public static bool DeleteByIdProgramaRange(int? idmr)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.detallematrizriesgos.Where(x => x.estadodmr == "A" && x.idmaterialidad == idmaterialidad);
                    var lista = (from p in _context.detallematrizriesgos
                                 where p.idmr == idmr
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.detallematrizriesgos.RemoveRange(lista);
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
                    elementos = _context.detallematrizriesgos.Where(x => x.idmr == id && x.estadodmr == "A").Count();
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

        public DetalleMatrizRiesgoModelo()
        {
            iddmr = 0;
            idprograma = null;
            idmaterialidad = null;
            idmr = 0;
            codigocontabledmr = string.Empty;
            nombredmr = string.Empty;
            saldoevaluaciondmr = 0;
            factoresriesgodmr =  string.Empty;
            evaluacioninherentedmr = string.Empty;
            evaluacioncontroldmr = string.Empty;
            evaluacioncombinadodmr = string.Empty;
            justificaevaluadmr =   string.Empty;
            clasespruebasdmr =   string.Empty;
            procedimientosdmr =  string.Empty;
            alcanceinherentedmr = 0;
            alcancecontroldmr = 0;
            alcancecombinadodmr = 0;
            justificaalcancedmr = string.Empty;
            materialidaddmr = 0;
            estadodmr = "A";
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            usuarioModelo = null;
            ordencc = 0;
        }
        public DetalleMatrizRiesgoModelo(MatrizRiesgoModelo riesgo)
        {
            iddmr = 0;
            idprograma = null;
            idmaterialidad = null;
            idmr = riesgo.idmr;
            codigocontabledmr = string.Empty;
            nombredmr = string.Empty;
            saldoevaluaciondmr = 0;
            factoresriesgodmr = string.Empty;
            evaluacioninherentedmr = string.Empty;
            evaluacioncontroldmr = string.Empty;
            evaluacioncombinadodmr = string.Empty;
            justificaevaluadmr = string.Empty;
            clasespruebasdmr = string.Empty;
            procedimientosdmr = string.Empty;
            alcanceinherentedmr = 0;
            alcancecontroldmr = 0;
            alcancecombinadodmr = 0;
            justificaalcancedmr = string.Empty;
            materialidaddmr = 0;
            estadodmr = "A";
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            usuarioModelo = null;
            ordencc = 0;
        }

        public DetalleMatrizRiesgoModelo(MatrizRiesgoModelo riesgo, UsuarioModelo usuario)
        {
            iddmr = 0;
            idprograma = null;
            idmaterialidad = null;
            idmr = riesgo.idmr;
            codigocontabledmr = string.Empty;
            nombredmr = string.Empty;
            saldoevaluaciondmr = 0;
            factoresriesgodmr = string.Empty;
            evaluacioninherentedmr = string.Empty;
            evaluacioncontroldmr = string.Empty;
            evaluacioncombinadodmr = string.Empty;
            justificaevaluadmr = string.Empty;
            clasespruebasdmr = string.Empty;
            procedimientosdmr = string.Empty;
            alcanceinherentedmr = 0;
            alcancecontroldmr = 0;
            alcancecombinadodmr = 0;
            justificaalcancedmr = string.Empty;
            materialidaddmr = 0;
            estadodmr = "A";
            isuso = 0;
            guardadoBase = false;
            IsSelected = false;
            usuarioModelo = usuario;
            inicialesusuarioCreo = usuario.inicialesusuario;
            ordencc = 0;
        }
    }

}
