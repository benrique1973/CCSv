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
using SGPTWpf.Model;
using SGPTWpf.Model.Modelo.Encargos;
using System.Collections.ObjectModel;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using SGPTWpf.Model.Modelo.Herramientas;
using SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Cierre;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion
{
    public class ProgramaModelo : UIBase
    {

        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        //Sirve para presentar un correlativo diferente al Id del registro
        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }

        #region idprograma

        public int _idprograma;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idprograma
        {
            get { return _idprograma; }
            set { _idprograma = value; }
        }

        #endregion


        #region idthprograma
        public Nullable<int> _idthprograma;
        public Nullable<int> idthprograma
        {
            get { return _idthprograma; }
            set { _idthprograma = value; }
        }

        #endregion

        #region idtpprograma
        public Nullable<int> _idtpprograma;
        public Nullable<int> idtpprograma
        {
            get { return _idtpprograma; }
            set { _idtpprograma = value; }
        }

        #endregion

        public Nullable<int> idindiceprograma
        {
            get { return GetValue(() => idindiceprograma); }
            set { SetValue(() => idindiceprograma, value); }
        }

        public Nullable<int> idcedulaprograma
        {
            get { return GetValue(() => idcedulaprograma); }
            set { SetValue(() => idcedulaprograma, value); }
        }

        public Nullable<int> idpapelesprograma
        {
            get { return GetValue(() => idpapelesprograma); }
            set { SetValue(() => idpapelesprograma, value); }
        }

        [DisplayName("Nombre de programa")]
        [Required(ErrorMessage = "Dato requerido")]
        [MinLength(5, ErrorMessage = "Debe ser un nombre significativo")]
        [MaxLength(500, ErrorMessage = "Excede de 500 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string nombreprograma
        {
            get { return GetValue(() => nombreprograma); }
            set { SetValue(() => nombreprograma, value); }
        }
        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechahoyprograma
        {
            get { return GetValue(() => fechahoyprograma); }
            set { SetValue(() => fechahoyprograma, value); }
        }


        [DisplayName("Horas planeadas")]
        [Range(0, 1000, ErrorMessage = "Debe ser un valor mayor o igual a cero y menor que 1000")]
        public Nullable<decimal> horasplanprograma
        {
            get { return GetValue(() => horasplanprograma); }
            set { SetValue(() => horasplanprograma, value); }
        }

        public string estadoprograma
        {
            get { return GetValue(() => estadoprograma); }
            set { SetValue(() => estadoprograma, value); }
        }


        #region etapaprograma

        public string _etapaprograma;
        public string etapaprograma
        {
            get { return _etapaprograma; }
            set { _etapaprograma = value; }
        }

        #endregion
        [DisplayName("Horas ejecutadas")]
        [Range(0, 1000, ErrorMessage = "Debe ser un valor mayor o igual a cero y menor que 1000")]
        public Nullable<decimal> horasejecucionprograma
        {
            get { return GetValue(() => horasejecucionprograma); }
            set { SetValue(() => horasejecucionprograma, value); }
        }

        public int idencargoprograma
        {
            get { return GetValue(() => idencargoprograma); }
            set { SetValue(() => idencargoprograma, value); }
        }

        //Propiedades de presentacion
        public string idTpNombre //Nombre del tipo de  programa
        {
            get { return GetValue(() => idTpNombre); }
            set { SetValue(() => idTpNombre, value); }
        }

        #region tipoProgramaModeloPrograma
        public TipoProgramaModelo _tipoProgramaModeloPrograma;
        public TipoProgramaModelo tipoProgramaModeloPrograma
        {
            get { return _tipoProgramaModeloPrograma; }
            set { _tipoProgramaModeloPrograma = value; }
        }

        #endregion

        #region tipoHerramientaModeloPrograma
        public TipoHerramientaModelo _tipoHerramientaModeloPrograma;
        public TipoHerramientaModelo tipoHerramientaModeloPrograma
        {
            get { return _tipoHerramientaModeloPrograma; }
            set { _tipoHerramientaModeloPrograma = value; }
        }

        #endregion

        #region encargoModeloPrograma

        public EncargoModelo _encargoModeloPrograma;
        public EncargoModelo encargoModeloPrograma
        {
            get { return _encargoModeloPrograma; }
            set { _encargoModeloPrograma = value; }
        }

        #endregion
        public virtual IndiceModelo indiceModeloPrograma
        {
            get { return GetValue(() => indiceModeloPrograma); }
            set { SetValue(() => indiceModeloPrograma, value); }
        }
        #region etapaEncargoModeloPrograma

        public EtapaEncargoModelo _etapaEncargoModeloPrograma;
        public EtapaEncargoModelo etapaEncargoModeloPrograma
        {
            get { return _etapaEncargoModeloPrograma; }
            set { _etapaEncargoModeloPrograma = value; }
        }

        #endregion

        #region usuarioProgramaAccionModelo

        public UsuarioProgramaAccionModelo _usuarioProgramaAccionModelo;
        public UsuarioProgramaAccionModelo usuarioProgramaAccionModelo
        {
            get { return _usuarioProgramaAccionModelo; }
            set { _usuarioProgramaAccionModelo = value; }
        }

        #endregion
        public string usuarioModifico
        {
            get { return GetValue(() => usuarioModifico); }
            set { SetValue(() => usuarioModifico, value); }
        }
        public string usuarioEjecuto
        {
            get { return GetValue(() => usuarioEjecuto); }
            set { SetValue(() => usuarioEjecuto, value); }
        }

        public string usuarioSuperviso
        {
            get { return GetValue(() => usuarioSuperviso); }
            set { SetValue(() => usuarioSuperviso, value); }
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

        public string usuarioAprobo
        {
            get { return GetValue(() => usuarioAprobo); }
            set { SetValue(() => usuarioAprobo, value); }
        }

        [DisplayName("Referencia Programa")]
        [MinLength(3, ErrorMessage = "Debe ser un nombre significativo")]
        [MaxLength(30, ErrorMessage = "Excede de 30 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string referenciaPrograma
        {
            get { return GetValue(() => referenciaPrograma); }
            set { SetValue(() => referenciaPrograma, value); }
        }
        public string descripcionEtapaEncargo
        {
            get { return GetValue(() => descripcionEtapaEncargo); }
            set { SetValue(() => descripcionEtapaEncargo, value); }
        }
        #region Resumen de resultados

        public Nullable<decimal> cantidadProcedimientosPlan
        {
            get { return GetValue(() => cantidadProcedimientosPlan); }
            set { SetValue(() => cantidadProcedimientosPlan, value); }
        }
        public Nullable<decimal> cantidadProcedimientosEjecucion
        {
            get { return GetValue(() => cantidadProcedimientosEjecucion); }
            set { SetValue(() => cantidadProcedimientosEjecucion, value); }
        }

        public Nullable<decimal> indiceEjecucionprograma
        {
            get { return GetValue(() => indiceEjecucionprograma); }
            set { SetValue(() => indiceEjecucionprograma, value); }
        }

        public Nullable<decimal> indiceHoras
        {
            get { return GetValue(() => indiceHoras); }
            set { SetValue(() => indiceHoras, value); }
        }
        #endregion


        #region usuarioModeloPrograma

        public UsuarioModelo _usuarioModeloPrograma;
        public UsuarioModelo usuarioModeloPrograma
        {
            get { return _usuarioModeloPrograma; }
            set { _usuarioModeloPrograma = value; }
        }

        #endregion
        public string fechaUltimaModificacionPrograma
        {
            get { return GetValue(() => fechaUltimaModificacionPrograma); }
            set { SetValue(() => fechaUltimaModificacionPrograma, value); }
        }
        public virtual ObservableCollection<UsuarioProgramaAccionModelo> listaUsuarioProgramaAccionModelo
        {
            get { return GetValue(() => listaUsuarioProgramaAccionModelo); }
            set { SetValue(() => listaUsuarioProgramaAccionModelo, value); }
        }



        #region propiedades para importacion de programas
        public string razonsocialclientePrograma
        {
            get { return GetValue(() => razonsocialclientePrograma); }
            set { SetValue(() => razonsocialclientePrograma, value); }
        }
        public string descripcionTipoAuditoriaPrograma
        {
            get { return GetValue(() => descripcionTipoAuditoriaPrograma); }
            set { SetValue(() => descripcionTipoAuditoriaPrograma, value); }
        }

        public string fechainiperauditencargoPrograma
        {
            get { return GetValue(() => fechainiperauditencargoPrograma); }
            set { SetValue(() => fechainiperauditencargoPrograma, value); }
        }
        public string fechafinperauditencargoPrograma
        {
            get { return GetValue(() => fechafinperauditencargoPrograma); }
            set { SetValue(() => fechafinperauditencargoPrograma, value); }
        }
        public bool seleccionPrograma
        {
            get { return GetValue(() => seleccionPrograma); }
            set { SetValue(() => seleccionPrograma, value); }
        }

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }
        public virtual ObservableCollection<ProgramaModelo> listadoProgramaModelo
        {
            get { return GetValue(() => listadoProgramaModelo); }
            set { SetValue(() => listadoProgramaModelo, value); }
        }

        public virtual ObservableCollection<UsuarioProgramaAccionModelo> listadoBitacora
        {
            get { return GetValue(() => listadoBitacora); }
            set { SetValue(() => listadoBitacora, value); }
        }
        #endregion


        public static bool Insert(ProgramaModelo modelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.programas', 'idprograma'), (SELECT MAX(idprograma) FROM sgpt.programas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new programa
                        {
                            //idprograma = modelo.idprograma,
                            //referenciaprograma=modelo.referenciaPrograma,
                            idthprograma = modelo.idthprograma,
                            idtpprograma = modelo.idtpprograma,
                            idindiceprograma = modelo.idindiceprograma,
                            idcedulaprograma = modelo.idcedulaprograma,
                            idpapelesprograma = modelo.idpapelesprograma,
                            nombreprograma = modelo.nombreprograma,
                            fechahoyprograma = modelo.fechahoyprograma,
                            horasplanprograma = modelo.horasplanprograma,
                            estadoprograma = modelo.estadoprograma,
                            etapaprograma = modelo.etapaprograma,
                            horasejecucionprograma = modelo.horasejecucionprograma,
                            idencargoprograma = modelo.idencargoprograma,
                        };
                        //Registro de creación
                        _context.programas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idprograma = tablaDestino.idprograma;
                        //Creación de registro auxiliar de acción realizada

                        result = true;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar programa : " + e.Message);
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        public static int InsertByCreacion(ProgramaModelo modelo)
        {
            int result = 0;//No se realizó la operación
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.programas', 'idprograma'), (SELECT MAX(idprograma) FROM sgpt.programas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new programa
                        {
                            //idprograma = modelo.idprograma,
                            //referenciaprograma=modelo.referenciaPrograma,
                            idthprograma = modelo.idthprograma,
                            idtpprograma = modelo.idtpprograma,
                            //idindiceprograma = modelo.idindiceprograma,
                            //idcedulaprograma = modelo.idcedulaprograma,
                            //idpapelesprograma = modelo.idpapelesprograma,
                            nombreprograma = modelo.nombreprograma,
                            fechahoyprograma = modelo.fechahoyprograma,
                            horasplanprograma = modelo.horasplanprograma,
                            estadoprograma = modelo.estadoprograma,
                            etapaprograma = modelo.etapaprograma,
                            horasejecucionprograma = modelo.horasejecucionprograma,
                            idencargoprograma = modelo.idencargoprograma,
                        };
                        //Registro de creación
                        _context.programas.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.idprograma = tablaDestino.idprograma;
                        //Creación de registro auxiliar de acción realizada
                        modelo.usuarioProgramaAccionModelo.idprograma = modelo.idprograma;
                        modelo.usuarioProgramaAccionModelo.idusuarioupa = modelo.usuarioModeloPrograma.idUsuario;
                        //modelo.usuarioProgramaAccionModelo.idusuarioupa = usuarioModelo.idUsuario;
                        if (UsuarioProgramaAccionModelo.InsertByPrograma(modelo.usuarioProgramaAccionModelo,modelo.idencargoprograma))
                        {
                            result = 1;//éxito completo
                        }
                        else
                        {
                            //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                            result = 2;//No se inserto el registro auxiliar
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar programa : " + e.Message);
                    result = 3;//Hubo una excepcion
                    throw;
                }
                return result;
            }
            else
            {
                return result;//No se envio registro
            }
        }
        //Devuelve el registro buscado con base al indice
        public static ProgramaModelo GetRegistro(int id)
        {
            var entidad = new ProgramaModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    programa modelo = _context.programas.Find(id);
                    if (modelo == null)
                    {
                        entidad = null;
                    }
                    else
                    {
                        entidad.idprograma = modelo.idprograma;
                        entidad.referenciaPrograma = modelo.referenciaprograma;
                        entidad.idthprograma = modelo.idthprograma;
                        entidad.idtpprograma = modelo.idtpprograma;
                        entidad.idindiceprograma = modelo.idindiceprograma;
                        entidad.idcedulaprograma = modelo.idcedulaprograma;
                        entidad.idpapelesprograma = modelo.idpapelesprograma;
                        entidad.nombreprograma = modelo.nombreprograma;
                        entidad.fechahoyprograma = modelo.fechahoyprograma;
                        entidad.horasplanprograma = modelo.horasplanprograma;
                        entidad.estadoprograma = modelo.estadoprograma;
                        entidad.etapaprograma = modelo.etapaprograma;
                        entidad.horasejecucionprograma = modelo.horasejecucionprograma;
                        entidad.idencargoprograma = modelo.idencargoprograma;
                        entidad.idTpNombre = modelo.tiposprograma.descripciontp;
                    }
                    if (entidad.idencargoprograma != 0)
                        entidad.encargoModeloPrograma = EncargoModelo.GetRegistro(entidad.idencargoprograma);
                    if (entidad.idthprograma != 0)
                        entidad.tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro((int)entidad.idthprograma);
                    if (entidad.idtpprograma != 0)
                        entidad.tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro((int)entidad.idtpprograma);
                    if (entidad.idindiceprograma != 0)
                        entidad.indiceModeloPrograma = IndiceModelo.GetRegistro(entidad.idindiceprograma);
                    entidad.etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(entidad.etapaprograma);
                }
                return entidad;
            }
            else
            {
                return entidad = null;
            }
        }

        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.programas WHERE idprograma={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
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
                    programa entidad = _context.programas.Find(id);
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
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.programas
                            .Where(b => b.estadoprograma == "B")
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
        //Para actualizar sumas de modelo programa
        public static bool UpdateSumaModelo(int idPrograma)
        {
            if (!(idPrograma == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        programa entidad = _context.programas.Find(idPrograma);
                        if (!(entidad == null))
                        {
                            if (entidad.idthprograma == 1)
                            {
                                //entidad.idprograma = modelo.idprograma;
                                entidad.horasplanprograma = DetalleProgramaModelo.SumaHora(idPrograma);
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

        public static bool UpdateSumaModelo(ProgramaModelo modelo)
        {
            if (!(modelo.idprograma == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        programa entidad = _context.programas.Find(modelo.idprograma);
                        if (!(entidad == null))
                        {
                            if (entidad.idthprograma == 1)
                            {
                                //entidad.idprograma = modelo.idprograma;
                                entidad.horasplanprograma = DetalleProgramaModelo.SumaHora(modelo.idprograma);
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                modelo.horasplanprograma = entidad.horasplanprograma;
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
        public static bool UpdateModelo(ProgramaModelo modelo, UsuarioModelo usuarioValidado)
        {

            bool cambio = false;
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        programa entidad = _context.programas.Find(modelo.idprograma);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {

                            //entidad.idprograma = modelo.idprograma;
                            if (!(entidad.idtpprograma == modelo.idtpprograma))
                            {
                                cambio = true;
                            }
                            else
                            {
                                if (!(entidad.idthprograma == modelo.idthprograma))
                                {
                                    cambio = true;
                                }
                                else
                                {
                                    if (!(entidad.nombreprograma == modelo.nombreprograma))
                                    {
                                        cambio = true;
                                    }
                                    else
                                    {
                                        if (entidad.idthprograma == 1)
                                        {
                                            if (!(entidad.horasplanprograma == DetalleHerramientasModelo.SumaHora(modelo.idprograma)))
                                            {
                                                cambio = true;
                                            }
                                        }
                                        else
                                        {
                                            if (!(entidad.horasplanprograma == modelo.horasplanprograma))
                                            {
                                                cambio = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (!(entidad.referenciaprograma == modelo.referenciaPrograma))
                            {
                                cambio = true;
                            }

                            if (modelo.fechaaprobacion != null)
                            {
                                if (entidad.fechaaprobacion != null)
                                {
                                    if (entidad.fechaaprobacion != modelo.fechaaprobacion)
                                    {
                                        cambio = true;
                                    }
                                }
                                else
                                {
                                    cambio = true;
                                }
                            }

                            if (modelo.fechacierre != null)
                            {
                                if (entidad.fechacierre != null)
                                {
                                    if (entidad.fechacierre != modelo.fechacierre)
                                    {
                                        cambio = true;
                                    }
                                }
                                else
                                {
                                    cambio = true;
                                }
                            }

                            if (modelo.fechasupervision != null)
                            {
                                if (entidad.fechasupervision != null)
                                {
                                    if (entidad.fechasupervision != modelo.fechasupervision)
                                    {
                                        cambio = true;
                                    }
                                }
                                else
                                {
                                    cambio = true;
                                }
                            }

                            if (cambio)
                            {
                                entidad.idprograma = modelo.idprograma;
                                entidad.referenciaprograma = modelo.referenciaPrograma;
                                entidad.idthprograma = modelo.idthprograma;
                                entidad.idtpprograma = modelo.idtpprograma;
                                entidad.idindiceprograma = modelo.idindiceprograma;
                                entidad.idcedulaprograma = modelo.idcedulaprograma;
                                entidad.idpapelesprograma = modelo.idpapelesprograma;
                                entidad.nombreprograma = modelo.nombreprograma;
                                entidad.fechahoyprograma = modelo.fechahoyprograma;
                                entidad.horasplanprograma = modelo.horasplanprograma;
                                entidad.estadoprograma = modelo.estadoprograma;
                                entidad.etapaprograma = modelo.etapaprograma;
                                entidad.horasejecucionprograma = modelo.horasejecucionprograma;
                                entidad.idencargoprograma = modelo.idencargoprograma;

                                entidad.fechasupervision = modelo.fechasupervision;
                                entidad.fechacierre = modelo.fechacierre;
                                entidad.fechaaprobacion = modelo.fechaaprobacion;

                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                modelo.horasplanprograma = entidad.horasplanprograma;

                                //Creación de registro auxiliar de acción realizada
                                if (UsuarioProgramaAccionModelo.InsertByPrograma(modelo.usuarioProgramaAccionModelo,modelo.idencargoprograma))
                                {
                                    return true; ;//éxito completo
                                }
                                else
                                {
                                    //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                                    return true;//No se inserto el registro auxiliar
                                }
                            }
                            else
                            {
                                return true;//No hay cambio se  da por valida
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                    {
                        MessageBox.Show("Exception en actualizar programa : " + e.Message);
                    }
                    return false;
                    throw;

                }
            }
            else
            {
                return false;
            }
        }

        //Pendiente el definir la forma de consulta y eliminacion
        public static bool DeleteBorradoLogicoByPrograma(int id, Boolean actualizar)
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
                            //programa entidad = _context.programas.Find(id);
                            //Borrado del detalle de cuestionarios
                            //Borrado del detalle de programas
                            var listaDetalleCuestionarios = DetalleProgramaModelo.GetAll(id);
                            if (listaDetalleCuestionarios.Count > 0)
                            {
                                foreach (DetalleProgramaModelo item in listaDetalleCuestionarios)
                                {
                                    DetalleProgramaModelo.DeleteBorradoLogico(item.iddp, true);
                                }
                            }
                            //Borrado del detalle de usuario accion
                            var listaDetalleAcciones = UsuarioProgramaAccionModelo.GetAllByPrograma(id);
                            if (listaDetalleAcciones.Count > 0)
                            {
                                foreach (UsuarioProgramaAccionModelo item in listaDetalleAcciones)
                                {
                                    UsuarioProgramaAccionModelo.DeleteBorradoLogico(item.idupa);
                                }
                            }
                            //eliminacion del padre
                            string commandString = String.Format("UPDATE sgpt.programas SET estadoprograma = 'B' WHERE idprograma={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //entidad.estadoprograma = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

                }
            }
            else
            {
                return result;
            }
        }

        public static void UpdateCambiarEstadoByPrograma(int id)
        {
            //Permite controlar hacer guardado, únicamente cuando se ha modificado algo en los registros
            if (!(id == 0))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.programas SET etapaprograma = 'P' WHERE idprograma={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en cambiar el estado del registro : \n" + e);
                    }

                }
            }
            else
            {
                //return result;
            }
        }
        public static bool DeleteBorradoLogicoByCuestionario(int id, Boolean actualizar)
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
                            //programa entidad = _context.programas.Find(id);
                            //Borrado del detalle de cuestionarios
                            //Borrado del detalle de programas
                            DetalleCuestionarioModelo.DeleteBorradoLogicoByIdCuestionario(id);

                            //eliminacion del padre
                            string commandString = String.Format("UPDATE sgpt.programas SET estadoprograma = 'B' WHERE idprograma={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
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
                    string commandString = String.Format("DELETE FROM sgpt.programas WHERE idprograma={0};", id);
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
        public static bool DeleteByDetallePrograma(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (DetalleProgramaModelo.DeleteByIdProgramaRange(id))
                        {
                            if (UsuarioProgramaAccionModelo.DeleteByProgramaRange(id))
                            {
                                string commandString = String.Format("DELETE FROM sgpt.programas WHERE idprograma={0};", id);
                                commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                _context.Database.ExecuteSqlCommand(commandString);
                                _context.SaveChanges();
                                //_context.programas.Remove(entidad);
                                //_context.SaveChanges();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
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
                        MessageBox.Show("Exception en borrar registro de programa \n" + e);
                    throw;
                }

            }
            else
            {
                return false;
            }
        }

        public static bool DeleteByDetalleCuestionario(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (DetalleCuestionarioModelo.DeleteByIdProgramaRange(id))
                        {
                            if (UsuarioProgramaAccionModelo.DeleteByProgramaRange(id))
                            {
                                string commandString = String.Format("DELETE FROM sgpt.programas WHERE idprograma={0};", id);
                                commandString = MetodosModelo.ordenConversionToSQL(commandString);
                                _context.Database.ExecuteSqlCommand(commandString);
                                _context.SaveChanges();
                                //_context.programas.Remove(entidad);
                                //_context.SaveChanges();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
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
                        MessageBox.Show("Exception en borrar registro de programa : \n" + e);
                    throw;
                }

            }
            else
            {
                return false;
            }
        }


        public static bool UpdateCierreByCuestionario(int id, UsuarioModelo usuario,int idEncargo)
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
                            //programa entidad = _context.programas.Find(id);
                            DetalleCuestionarioModelo.UpdateCierreIdCuestionario(id);
                            //eliminacion del padre
                            string commandString = String.Format("UPDATE sgpt.programas SET etapaprograma = 'T', fechacierre={0} WHERE idprograma={1};", MetodosModelo.homologacionFecha(), id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //Cambiar el estado de los procedimientos a Terminado
                            commandString = String.Format("UPDATE sgpt.detallecuestionarios SET estadoprocedimientodc = 'T' WHERE idprogramadc={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();


                            //Insertar registro de cierre
                            UsuarioProgramaAccionModelo temporal = new UsuarioProgramaAccionModelo
                            {
                                idupa = 0,
                                idprograma = id,
                                idusuarioupa = usuario.idUsuario,
                                rolupa= "E" ,//Termino la ejecución
                                idencargo=idEncargo
                            };
                            if (UsuarioProgramaAccionModelo.InsertByPrograma(temporal,idEncargo))
                            {
                                return true; ;//éxito completo
                            }
                            else
                            {
                                //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                                return true;//No se inserto el registro auxiliar
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

                }
            }
            else
            {
                return result;
            }
        }

        public static bool UpdateCierreByPrograma(int id, UsuarioModelo usuario,int idEncargo)
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
                            //programa entidad = _context.programas.Find(id);
                            DetalleCuestionarioModelo.UpdateCierreIdCuestionario(id);
                            //eliminacion del padre
                            string commandString = String.Format("UPDATE sgpt.programas SET etapaprograma = 'T', fechacierre={0} WHERE idprograma={1};", MetodosModelo.homologacionFecha(), id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //Cambiar el estado de los procedimientos a Terminado
                            commandString = String.Format("UPDATE sgpt.detalleprogramas SET estadoprocedimientodp = 'T' WHERE idprogramadp={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();


                            //Insertar registro de cierre
                            UsuarioProgramaAccionModelo temporal = new UsuarioProgramaAccionModelo
                            {
                                idupa = 0,
                                idprograma = id,
                                idusuarioupa = usuario.idUsuario,
                                rolupa = "E", //Termino la ejecución
                                idencargo=idEncargo
                            };
                            if (UsuarioProgramaAccionModelo.InsertByPrograma(temporal,idEncargo))
                            {
                                return true; ;//éxito completo
                            }
                            else
                            {
                                //MessageBox.Show("Error al insertar el detalle de la accion en programa ");
                                return true;//No se inserto el registro auxiliar
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
                        return result;
                    }

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
                                " etapapapel ='{6}' WHERE idprograma={7};",
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

        public static bool Delete(string id, Boolean actualizar)
        {
            {

                if (!((string.IsNullOrEmpty(id)) || string.IsNullOrWhiteSpace(id)))
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("DELETE FROM sgpt.programas WHERE idprograma={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Source);
                        throw;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<ProgramaModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.programas.Select(entidad =>
                      new ProgramaModelo
                      {
                          idprograma = entidad.idprograma,
                          referenciaPrograma=entidad.referenciaprograma,
                          idthprograma = entidad.idthprograma,
                          idtpprograma = entidad.idtpprograma,
                          idindiceprograma = entidad.idindiceprograma,
                          idcedulaprograma = entidad.idcedulaprograma,
                          idpapelesprograma = entidad.idpapelesprograma,
                          nombreprograma = entidad.nombreprograma,
                          fechahoyprograma = entidad.fechahoyprograma,
                          horasplanprograma = entidad.horasplanprograma,
                          estadoprograma = entidad.estadoprograma,
                          etapaprograma = entidad.etapaprograma,
                          horasejecucionprograma = entidad.horasejecucionprograma,
                          idencargoprograma = entidad.idencargoprograma,
                          idTpNombre = entidad.tiposprograma.descripciontp,
                          IsSelected=false,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (ProgramaModelo item in lista)
                    {
                        if (item.idencargoprograma != 0)
                            item.encargoModeloPrograma = EncargoModelo.GetRegistro(item.idencargoprograma);
                        if (item.idthprograma != 0)
                            item.tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro((int)item.idthprograma);
                        if (item.idtpprograma != 0)
                            item.tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro((int)item.idtpprograma);
                        if (item.idindiceprograma != 0)
                            item.indiceModeloPrograma = IndiceModelo.GetRegistro(item.idindiceprograma);
                        item.etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(item.etapaprograma);
                        item.idCorrelativo = i;
                        i++;
                    }
                    return lista.ToList();
                }

            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de programas " + e.Message);
                }
                return new ObservableCollection<ProgramaModelo>().ToList();
            }
        }

        public static List<ProgramaModelo> GetAll(int? idthprograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.programas.Select(entidad =>
                     new ProgramaModelo
                     {
                         idprograma = entidad.idprograma,
                         referenciaPrograma = entidad.referenciaprograma,
                         idthprograma = entidad.idthprograma,
                         idtpprograma = entidad.idtpprograma,
                         idindiceprograma = entidad.idindiceprograma,
                         idcedulaprograma = entidad.idcedulaprograma,
                         idpapelesprograma = entidad.idpapelesprograma,
                         nombreprograma = entidad.nombreprograma,
                         fechahoyprograma = entidad.fechahoyprograma,
                         horasplanprograma = entidad.horasplanprograma,
                         estadoprograma = entidad.estadoprograma,
                         etapaprograma = entidad.etapaprograma,
                         horasejecucionprograma = entidad.horasejecucionprograma,
                         idencargoprograma = entidad.idencargoprograma,
                         idTpNombre = entidad.tiposprograma.descripciontp,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                         encargoModeloPrograma = new EncargoModelo
                         {
                             idencargo = entidad.encargo.idencargo,
                             idnitcliente = entidad.encargo.idnitcliente,
                             idta = entidad.encargo.idta,
                             fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                             tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                             etapaencargo = entidad.encargo.etapaencargo,
                             costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                             honorariosencargo = entidad.encargo.honorariosencargo,
                             fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                             fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                             estadoencargo = entidad.encargo.estadoencargo,
                             tipoAuditoriaModelo = new TipoAuditoriaModelo
                             {
                                 id = entidad.encargo.tiposauditoria.idta,
                                 descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                 sistema = entidad.encargo.tiposauditoria.sistemata,
                                 estado = entidad.encargo.tiposauditoria.estadota
                             },
                             descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta
                         },
                         seleccionPrograma=false,
                        }
                         ).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A" && x.idthprograma == idthprograma).ToList();
                    int i = 1;
                    var listadoClientes = ClienteModelo.GetAll();
                    foreach (ProgramaModelo item in lista)
                    {
                        if (item.idencargoprograma != 0)
                        { 
                            item.encargoModeloPrograma = EncargoModelo.GetRegistro(item.idencargoprograma);
                            item.encargoModeloPrograma.razonsocialcliente = listadoClientes.Single(j => j.idnitcliente == item.encargoModeloPrograma.idnitcliente).razonsocialcliente;
                            item.encargoModeloPrograma.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(item.encargoModeloPrograma.etapaencargo);
                            item.encargoModeloPrograma.descripcionEtapaEncargo = item.encargoModeloPrograma.etapaEncargoModelo.descripcionEtapaEncargo;
                            item.encargoModeloPrograma.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(item.encargoModeloPrograma.tipoclienteencargo);
                            item.encargoModeloPrograma.descripcionEtapaEncargo = item.encargoModeloPrograma.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;

                            item.razonsocialclientePrograma = item.encargoModeloPrograma.razonsocialcliente;
                            item.descripcionTipoAuditoriaPrograma = item.encargoModeloPrograma.descripcionTipoAuditoria;
                            item.fechainiperauditencargoPrograma = item.encargoModeloPrograma.fechainiperauditencargo;
                            item.fechafinperauditencargoPrograma = item.encargoModeloPrograma.fechafinperauditencargo;
                        }
                        if (item.idthprograma != 0)
                            item.tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro((int)item.idthprograma);
                        if (item.idtpprograma != 0)
                            item.tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro((int)item.idtpprograma);
                        if (item.idindiceprograma != 0)
                            item.indiceModeloPrograma = IndiceModelo.GetRegistro(item.idindiceprograma);
                        item.usuarioProgramaAccionModelo = UsuarioProgramaAccionModelo.GetRegistroByPrograma(item.idprograma);
                        if (item.usuarioProgramaAccionModelo.idupa != 0)
                        {
                            item.usuarioModifico = item.usuarioProgramaAccionModelo.nombreUsuario;
                        }
                        item.etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(item.etapaprograma);
                        item.idCorrelativo = i;
                        i++;
                    }
                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de programas" + e.Message + " " + e.Source);
                return new ObservableCollection<ProgramaModelo>().ToList();
                //return null;
            }
        }

        public static List<ProgramaModelo> GetAllByHerramientaNotEncargo(int? idthprograma, int idEncargoprograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.programas.Select(entidad =>
                     new ProgramaModelo
                     {
                         idprograma = entidad.idprograma,
                         referenciaPrograma=entidad.referenciaprograma,
                         idthprograma = entidad.idthprograma,
                         idtpprograma = entidad.idtpprograma,
                         idindiceprograma = entidad.idindiceprograma,
                         idcedulaprograma = entidad.idcedulaprograma,
                         idpapelesprograma = entidad.idpapelesprograma,
                         nombreprograma = entidad.nombreprograma,
                         fechahoyprograma = entidad.fechahoyprograma,
                         horasplanprograma = entidad.horasplanprograma,
                         estadoprograma = entidad.estadoprograma,
                         etapaprograma = entidad.etapaprograma,
                         horasejecucionprograma = entidad.horasejecucionprograma,
                         idencargoprograma = entidad.idencargoprograma,
                         idTpNombre = entidad.tiposprograma.descripciontp,
                         IsSelected=false,
                         //Lista filtrada de elementos que fueron eliminados
                         encargoModeloPrograma = new EncargoModelo
                         {
                             idencargo = entidad.encargo.idencargo,
                             idnitcliente = entidad.encargo.idnitcliente,
                             idta = entidad.encargo.idta,
                             fechacreadoencargo = entidad.encargo.fechacreadoencargo,
                             tipoclienteencargo = (bool)entidad.encargo.tipoclienteencargo,
                             etapaencargo = entidad.encargo.etapaencargo,
                             costoejecucionencargo = entidad.encargo.costoejecucionencargo,
                             honorariosencargo = entidad.encargo.honorariosencargo,
                             fechainiperauditencargo = entidad.encargo.fechainiperauditencargo,
                             fechafinperauditencargo = entidad.encargo.fechafinperauditencargo,
                             estadoencargo = entidad.encargo.estadoencargo,
                             tipoAuditoriaModelo = new TipoAuditoriaModelo
                             {
                                 id = entidad.encargo.tiposauditoria.idta,
                                 descripcion = entidad.encargo.tiposauditoria.descripcionta,
                                 sistema = entidad.encargo.tiposauditoria.sistemata,
                                 estado = entidad.encargo.tiposauditoria.estadota
                             },
                             descripcionTipoAuditoria = entidad.encargo.tiposauditoria.descripcionta
                         },
                         seleccionPrograma = false,
                     }
                         ).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A" && x.idthprograma == idthprograma && x.idencargoprograma!= idEncargoprograma).ToList();
                    int i = 1;
                    var listadoClientes = ClienteModelo.GetAll();
                    foreach (ProgramaModelo item in lista)
                    {
                        if (item.idencargoprograma != 0)
                        {
                            item.encargoModeloPrograma = EncargoModelo.GetRegistro(item.idencargoprograma);
                            item.encargoModeloPrograma.razonsocialcliente = listadoClientes.Single(j => j.idnitcliente == item.encargoModeloPrograma.idnitcliente).razonsocialcliente;
                            item.encargoModeloPrograma.etapaEncargoModelo = EtapaEncargoModelo.seleccionEtapa(item.encargoModeloPrograma.etapaencargo);
                            item.encargoModeloPrograma.descripcionEtapaEncargo = item.encargoModeloPrograma.etapaEncargoModelo.descripcionEtapaEncargo;
                            item.encargoModeloPrograma.tipoClienteEncargoModelo = TipoClienteEncargoModelo.seleccionTipoClienteEncargo(item.encargoModeloPrograma.tipoclienteencargo);
                            item.encargoModeloPrograma.descripcionEtapaEncargo = item.encargoModeloPrograma.tipoClienteEncargoModelo.descripcionTipoClienteEncargo;

                            item.razonsocialclientePrograma = item.encargoModeloPrograma.razonsocialcliente;
                            item.descripcionTipoAuditoriaPrograma = item.encargoModeloPrograma.descripcionTipoAuditoria;
                            item.fechainiperauditencargoPrograma = item.encargoModeloPrograma.fechainiperauditencargo;
                            item.fechafinperauditencargoPrograma = item.encargoModeloPrograma.fechafinperauditencargo;
                        }
                        if (item.idthprograma != 0)
                            item.tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro((int)item.idthprograma);
                        if (item.idtpprograma != 0)
                            item.tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro((int)item.idtpprograma);
                        if (item.idindiceprograma != 0)
                            item.indiceModeloPrograma = IndiceModelo.GetRegistro(item.idindiceprograma);
                        item.usuarioProgramaAccionModelo = UsuarioProgramaAccionModelo.GetRegistroByPrograma(item.idprograma);
                        if (item.usuarioProgramaAccionModelo.idupa != 0)
                        {
                            item.usuarioModifico = item.usuarioProgramaAccionModelo.nombreUsuario;
                        }
                        item.etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(item.etapaprograma);
                        item.idCorrelativo = i;
                        i++;
                    }
                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de programas" + e.Message + " " + e.Source);
                return new ObservableCollection<ProgramaModelo>().ToList();
                //return null;
            }
        }

        public static List<ProgramaModelo> GetAllByEncargo(int? idthprograma, EncargoModelo encargoModelo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.programas.Select(entidad =>
                     new ProgramaModelo
                     {
                         idprograma = entidad.idprograma,
                         referenciaPrograma = entidad.referenciaprograma,
                         idthprograma = entidad.idthprograma,
                         idtpprograma = entidad.idtpprograma,
                         idindiceprograma = entidad.idindiceprograma,
                         idcedulaprograma = entidad.idcedulaprograma,
                         idpapelesprograma = entidad.idpapelesprograma,
                         nombreprograma = entidad.nombreprograma,
                         fechahoyprograma = entidad.fechahoyprograma,
                         horasplanprograma = entidad.horasplanprograma,
                         estadoprograma = entidad.estadoprograma,
                         etapaprograma = entidad.etapaprograma,
                         horasejecucionprograma = entidad.horasejecucionprograma,
                         idencargoprograma = entidad.idencargoprograma,
                         idTpNombre = entidad.tiposprograma.descripciontp,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A" && x.idthprograma == idthprograma && x.idencargoprograma == encargoModelo.idencargo).ToList(); ;
                    if (lista.Count() >= 1)
                    {
                        int i = 1;
                        //bool registroEncargo = false;
                        ObservableCollection<TipoHerramientaModelo> listaTipoherramienta = new ObservableCollection<TipoHerramientaModelo>(TipoHerramientaModelo.GetAll());
                        ObservableCollection<TipoProgramaModelo> listaTipoPrograma = new ObservableCollection<TipoProgramaModelo>(TipoProgramaModelo.GetAll());
                        ObservableCollection<UsuarioProgramaAccionModelo> listaUsuarioProgramaAccionModelo = new ObservableCollection<UsuarioProgramaAccionModelo>(UsuarioProgramaAccionModelo.GetAllByEncargo(encargoModelo.idencargo));
                        foreach (ProgramaModelo item in lista)
                        {
                            item.encargoModeloPrograma = encargoModelo;

                            if (item.idthprograma != 0)
                            {
                                //item.tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro((int)item.idthprograma);
                                item.tipoHerramientaModeloPrograma = listaTipoherramienta.SingleOrDefault(x => x.id == item.idthprograma);
                            }
                            if (item.idtpprograma != 0)
                            {
                                //item.tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro((int)item.idtpprograma);
                                item.tipoProgramaModeloPrograma = listaTipoPrograma.SingleOrDefault(x=>x.id==item.idtpprograma);
                            }
                            //if (item.idindiceprograma != 0)
                            //{
                            //    item.indiceModeloPrograma = IndiceModelo.GetRegistro(item.idindiceprograma);
                            //}
                            item.etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(item.etapaprograma);
                            item.descripcionEtapaEncargo = item.etapaEncargoModeloPrograma.descripcionEtapaEncargo;
                            item.idCorrelativo = i;
                            i++;
                            try
                            {
                                if (listaUsuarioProgramaAccionModelo.Where(x=>x.idprograma==item.idprograma).Count() > 0)
                                {
                                    item.usuarioProgramaAccionModelo = listaUsuarioProgramaAccionModelo.Last(x => x.idprograma == item.idprograma);
                                }
                                else
                                {
                                    item.usuarioProgramaAccionModelo = new UsuarioProgramaAccionModelo(item);
                                }
                                }
                            catch (Exception e)
                            {
                                MessageBox.Show("Exception en elaboracion de lista de programas \n" + e);
                                item.usuarioProgramaAccionModelo = new UsuarioProgramaAccionModelo(item);
                            }
                                if (item.usuarioProgramaAccionModelo.idupa != 0)
                            {
                                item.usuarioModifico = item.usuarioProgramaAccionModelo.nombreUsuario;
                                item.fechahoyprograma = item.usuarioProgramaAccionModelo.fechacreadoupa;
                            }
                            if (item.horasplanprograma > 0)
                            {
                                item.indiceHoras = (item.horasejecucionprograma / item.horasplanprograma) * 100;
                            }
                            else
                            { 
                                item.indiceHoras = 0;
                            }
                        }
                        return lista.ToList();
                    }
                    else
                    {
                        return new ObservableCollection<ProgramaModelo>().ToList();
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de programas \n" + e);
                return new ObservableCollection<ProgramaModelo>().ToList();
                //return null;
            }
        }

        public static List<ProgramaModelo> GetAllByEncargo(EncargoModelo encargoModelo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.programas.Select(entidad =>
                     new ProgramaModelo
                     {
                         idprograma = entidad.idprograma,
                         referenciaPrograma = entidad.referenciaprograma,
                         idthprograma = entidad.idthprograma,
                         idtpprograma = entidad.idtpprograma,
                         idindiceprograma = entidad.idindiceprograma,
                         idcedulaprograma = entidad.idcedulaprograma,
                         idpapelesprograma = entidad.idpapelesprograma,
                         nombreprograma = entidad.nombreprograma,
                         fechahoyprograma = entidad.fechahoyprograma,
                         horasplanprograma = entidad.horasplanprograma,
                         estadoprograma = entidad.estadoprograma,
                         etapaprograma = entidad.etapaprograma,
                         horasejecucionprograma = entidad.horasejecucionprograma,
                         idencargoprograma = entidad.idencargoprograma,
                         idTpNombre = entidad.tiposprograma.descripciontp,
                         IsSelected = false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A" && x.idencargoprograma == encargoModelo.idencargo).ToList(); ;
                    if (lista.Count() >= 1)
                    {
                        int i = 1;
                        //bool registroEncargo = false;
                        foreach (ProgramaModelo item in lista)
                        {
                            item.encargoModeloPrograma = encargoModelo;
                            //if (!registroEncargo)
                            //{
                            //    if (item.idencargoprograma != 0)
                            //    {
                            //        temp = EncargoModelo.GetRegistro(item.idencargoprograma);
                            //    }
                            //    item.encargoModeloPrograma = EncargoModelo.GetRegistro(item.idencargoprograma);
                            //}
                            //else
                            //{
                            //    item.encargoModeloPrograma = temp;
                            //}
                            if (item.idthprograma != 0)
                                item.tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro((int)item.idthprograma);
                            if (item.idtpprograma != 0)
                                item.tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro((int)item.idtpprograma);
                            if (item.idindiceprograma != 0)
                                item.indiceModeloPrograma = IndiceModelo.GetRegistro(item.idindiceprograma);
                            item.etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(item.etapaprograma);
                            item.idCorrelativo = i;
                            i++;
                            item.usuarioProgramaAccionModelo = UsuarioProgramaAccionModelo.GetRegistroByPrograma(item.idprograma);
                            if (item.usuarioProgramaAccionModelo.idupa != 0)
                            {
                                item.usuarioModifico = item.usuarioProgramaAccionModelo.nombreUsuario;
                                item.fechahoyprograma = item.usuarioProgramaAccionModelo.fechacreadoupa;
                            }
                        }
                        return lista.ToList();
                    }
                    else
                    {
                        return new ObservableCollection<ProgramaModelo>().ToList();
                    }

                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de programas" + e.Message + " " + e.Source);
                return new ObservableCollection<ProgramaModelo>().ToList();
                //return null;
            }
        }

        public static List<ProgramaModelo> GetAllByEncargo(encargo encargoModelo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.programas.Select(entidad =>
                     new ProgramaModelo
                     {
                         idprograma = entidad.idprograma,
                         referenciaPrograma=entidad.referenciaprograma,
                         idthprograma = entidad.idthprograma,
                         idtpprograma = entidad.idtpprograma,
                         idindiceprograma = entidad.idindiceprograma,
                         idcedulaprograma = entidad.idcedulaprograma,
                         idpapelesprograma = entidad.idpapelesprograma,
                         nombreprograma = entidad.nombreprograma,
                         fechahoyprograma = entidad.fechahoyprograma,
                         horasplanprograma = entidad.horasplanprograma,
                         estadoprograma = entidad.estadoprograma,
                         etapaprograma = entidad.etapaprograma,
                         horasejecucionprograma = entidad.horasejecucionprograma,
                         idencargoprograma = entidad.idencargoprograma,
                         idTpNombre = entidad.tiposprograma.descripciontp,
                         IsSelected=false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A" && x.idencargoprograma == encargoModelo.idencargo).ToList();
                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de programas" + e.Message + " " + e.Source);
                return new ObservableCollection<ProgramaModelo>().ToList();
                //return null;
            }
        }

        public static List<ProgramaModelo> GetAllByEncargo(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var lista = _context.programas.Select(entidad =>
                     new ProgramaModelo
                     {
                         idprograma = entidad.idprograma,
                         referenciaPrograma=entidad.referenciaprograma,
                         idthprograma = entidad.idthprograma,
                         idtpprograma = entidad.idtpprograma,
                         idindiceprograma = entidad.idindiceprograma,
                         idcedulaprograma = entidad.idcedulaprograma,
                         idpapelesprograma = entidad.idpapelesprograma,
                         nombreprograma = entidad.nombreprograma,
                         fechahoyprograma = entidad.fechahoyprograma,
                         horasplanprograma = entidad.horasplanprograma,
                         estadoprograma = entidad.estadoprograma,
                         etapaprograma = entidad.etapaprograma,
                         horasejecucionprograma = entidad.horasejecucionprograma,
                         idencargoprograma = entidad.idencargoprograma,
                         idTpNombre = entidad.tiposprograma.descripciontp,
                         IsSelected=false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.idprograma).Where(x => x.estadoprograma == "A" && x.idencargoprograma == idEncargo).ToList();
                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista de programas" + e.Message + " " + e.Source);
                return new ObservableCollection<ProgramaModelo>().ToList();
                //return null;
            }
        }

        #region Contar registros
        public static int ContarRegistros(int? idthprograma)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.programas.Where(x => x.idthprograma == idthprograma && x.estadoprograma == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros de programas: " + e.Message);
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
                    elementos = _context.programas.Where(x => x.estadoprograma == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros: " + e.Message);
                return elementos;
            }
        }

        public static int evaluarEstadoPrograma(int idPrograma)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                   var elementos = (from p in _context.detalleprogramas
                                  where p.estadoprocedimientodp!="I" && p.estadodp == "A" && p.idprogramadp == idPrograma
                                  select p).ToList();
                    //elementos = _context.detalleprogramas.Where(x => x.estadoprocedimientodp != "I" && x.estadodp == "A").Count();
                    return elementos.Count();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros iniciados: " + e.Message);
                return -1;//No podra borrar
            }
        }
        public static int evaluarEstadoCuestionario(int idPrograma)
        {
            //int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var elementos = (from p in _context.detalleprogramas
                                     where p.estadoprocedimientodp != "I" && p.estadodp == "A" && p.idprogramadp == idPrograma
                                     select p).ToList();
                    //elementos = _context.detalleprogramas.Where(x => x.estadoprocedimientodp != "I" && x.estadodp == "A").Count();
                    return elementos.Count();
                    //elementos = _context.detallecuestionarios.Where(x => x.estadoprocedimientodc != "I" && x.estadodc == "A").Count();
                    //return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de preguntas iniciadas: " + e.Message);
                return -1;
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
                    elementos = _context.programas.Where(x => x.nombreprograma.ToUpper() == busqueda && x.estadoprograma == "A").Count();

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
                    elementos = _context.programas.Where(x => x.nombreprograma.ToUpper() == busqueda && x.estadoprograma == "A").Count();
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
        public static ProgramaModelo Clear(ProgramaModelo modelo)
        {
            return new ProgramaModelo();
        }

        #endregion

        #region Copia

        public static bool CopiarModelo(ProgramaModelo modelo)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //Registro a copiar
                        programa entidad = _context.programas.Find(modelo.idprograma);
                        //Inserta el registro con los nuevos datos
                        if (Insert(modelo))
                        {
                            //éxito en la copia
                            /*var lista = DetalleHerramientasModelo.GetAll(entidad.idprograma);
                            foreach (DetalleHerramientasModelo item in lista)
                            {
                                anterior = item.idDh;
                                item.idprograma = modelo.idprograma;//Nuevo id del padre
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
                            }*/

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

        #endregion

        #region Constructor

        public ProgramaModelo()
        {
            idprograma = 0;
            idthprograma = 0;
            idtpprograma = 0;
            idindiceprograma = 0;
            idcedulaprograma = 0;
            idpapelesprograma = 0;
            nombreprograma = string.Empty;
            fechahoyprograma = MetodosModelo.homologacionFecha(); //DateTime.Now.ToString("d", CultureInfo.CurrentCulture); ;
            horasplanprograma = 0;
            estadoprograma = "A";
            etapaprograma = "I"; //I de iniciado
            horasejecucionprograma = 0;
            idencargoprograma = 0;
            IsSelected = false;
            cantidadProcedimientosPlan = 0;
            cantidadProcedimientosEjecucion = 0;
            indiceEjecucionprograma = 0;
            indiceHoras = 0;
        }
        public ProgramaModelo(UsuarioModelo usuarioModelo)
        {
            idprograma = 0;
            idthprograma = 0;
            idtpprograma = 0;
            idindiceprograma = 0;
            idcedulaprograma = 0;
            idpapelesprograma = 0;
            nombreprograma = string.Empty;
            fechahoyprograma = MetodosModelo.homologacionFecha(); //DateTime.Now.ToString("d", CultureInfo.CurrentCulture); ;
            horasplanprograma = 0;
            estadoprograma = "A";
            etapaprograma = "I"; //I de iniciado
            horasejecucionprograma = 0;
            idencargoprograma = 0;
            IsSelected = false;
            usuarioModeloPrograma = usuarioModeloPrograma;
            cantidadProcedimientosPlan = 0;
            cantidadProcedimientosEjecucion = 0;
            indiceEjecucionprograma = 0;
            indiceHoras = 0;
        }
        public ProgramaModelo(int idThPrograma, int idtpPrograma, UsuarioModelo usuarioModelo,EncargoModelo encargoModelo)
        {
            idprograma = 0;
            idthprograma = idThPrograma;
            idtpprograma = idtpPrograma;
            idindiceprograma = 0;
            idcedulaprograma = 0;
            idpapelesprograma = 0;
            nombreprograma = string.Empty;
            //fechahoyprograma = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            fechahoyprograma = MetodosModelo.homologacionFecha();
            horasplanprograma = 0;
            estadoprograma = "A";
            etapaprograma = "I"; //I de iniciado
            horasejecucionprograma = 0;
            //idencargoprograma = idencargoPrograma;
            tipoProgramaModeloPrograma = TipoProgramaModelo.GetRegistro(idtpPrograma);
            tipoHerramientaModeloPrograma = TipoHerramientaModelo.GetRegistro(idThPrograma);
            etapaEncargoModeloPrograma = EtapaEncargoModelo.seleccionEtapa(etapaprograma);
            usuarioProgramaAccionModelo = new UsuarioProgramaAccionModelo();
            usuarioModeloPrograma = usuarioModelo;
            encargoModeloPrograma = encargoModelo;
            IsSelected = false;
            cantidadProcedimientosPlan = 0;
            cantidadProcedimientosEjecucion = 0;
            indiceEjecucionprograma = 0;
            indiceHoras = 0;
            idencargoprograma = encargoModelo.idencargo;
        }

        public static ProgramaModelo equivalencia(ProgramaModelo destino, HerramientasModelo origen,UsuarioModelo usuarioModelo, EncargoModelo encargoModelo)
        {
            destino.idprograma = 0;
            destino.idthprograma = origen.idTh;
            destino.idtpprograma = origen.idTp;
            //destino.idindiceprograma = 0;
            //destino.idcedulaprograma = 0;
            //destino.idpapelesprograma = 0;
            destino.nombreprograma = origen.nombreHerramienta;
            //destino.fechahoyprograma = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.fechahoyprograma = MetodosModelo.homologacionFecha();
            destino.horasplanprograma = origen.horasPlanHerramienta;
            destino.estadoprograma = "A";
            destino.etapaprograma = "I"; //I de iniciado
            destino.horasejecucionprograma = 0;
            //destino.idencargoprograma = idencargoPrograma;
            //destino.tipoProgramaModeloPrograma = destino.tipoProgramaModeloPrograma;
            //destino.tipoHerramientaModeloPrograma = destino.tipoHerramientaModeloPrograma;
            destino.etapaEncargoModeloPrograma = destino.etapaEncargoModeloPrograma;
            destino.encargoModeloPrograma = destino.encargoModeloPrograma;
            destino.usuarioProgramaAccionModelo = new UsuarioProgramaAccionModelo();
            destino.usuarioModeloPrograma = usuarioModelo;
            destino.encargoModeloPrograma = encargoModelo;
            destino.idencargoprograma = encargoModelo.idencargo;
            return destino;
        }

        public static ProgramaModelo equivalencia(ProgramaModelo destino, ProgramaModelo origen)
        {
            destino.idprograma = 0;
            destino.idthprograma = origen.idthprograma;
            destino.idtpprograma = origen.idtpprograma;
            //destino.idindiceprograma = 0;
            //destino.idcedulaprograma = 0;
            //destino.idpapelesprograma = 0;
            destino.nombreprograma = origen.nombreprograma;
            //destino.fechahoyprograma = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            destino.fechahoyprograma = MetodosModelo.homologacionFecha();
            destino.horasplanprograma = origen.horasplanprograma;
            destino.estadoprograma = "A";
            destino.etapaprograma = "I"; //I de iniciado
            destino.horasejecucionprograma = 0;
            //destino.idencargoprograma = idencargoPrograma;
            destino.tipoProgramaModeloPrograma = destino.tipoProgramaModeloPrograma;
            destino.tipoHerramientaModeloPrograma = destino.tipoHerramientaModeloPrograma;
            destino.etapaEncargoModeloPrograma = destino.etapaEncargoModeloPrograma;
            destino.encargoModeloPrograma = destino.encargoModeloPrograma;
            destino.usuarioProgramaAccionModelo = new UsuarioProgramaAccionModelo();
            destino.usuarioModeloPrograma = destino.usuarioModeloPrograma;
            destino.encargoModeloPrograma = destino.encargoModeloPrograma;
            destino.idencargoprograma = destino.encargoModeloPrograma.idencargo;
            return destino;
        }
        #endregion

        #endregion
    }
}


