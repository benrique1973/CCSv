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

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Documentacion
{

    public class CatalogoCuentasModelo : UIBase
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
        public int idcc
        {
            get { return GetValue(() => idcc); }
            set { SetValue(() => idcc, value); }
        }

        //Identifica el  tipo de elemento contable
        public Nullable<int> idelementos
        {
            get { return GetValue(() => idelementos); }
            set { SetValue(() => idelementos, value); }
        }

        //Vincula con el sistema contable asociado y asu vez con  el encargo
        public Nullable<int> idsc
        {
            get { return GetValue(() => idsc); }
            set { SetValue(() => idsc, value); }
        }

        //Almacena el id del padre de la cuenta
        public int? catidcc
        {
            get { return GetValue(() => catidcc); }
            set { SetValue(() => catidcc, value); }
        }

        //Identifica el  tipo de cuenta 1 Elemento, 2 rubro, 3 cuenta , 4 sub cuenta 5, sub sub cuenta
        public Nullable<int> idccuentas
        {
            get { return GetValue(() => idccuentas); }
            set { SetValue(() => idccuentas, value); }
        }

        //Codigo de la cuenta contable
        [DisplayName("Código")]
        [Required(ErrorMessage = "El código es necesario")]
        [MinLength(1, ErrorMessage = "Debe ser mayor a 1 caracter")]
        [MaxLength(30, ErrorMessage = "Excede de 30 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string codigocc
        {
            get { return GetValue(() => codigocc); }
            set { SetValue(() => codigocc, value); }
        }

        [DisplayName("Descripción de procedimiento")]
        [Required(ErrorMessage = "Descripción requerida")]
        [MinLength(5, ErrorMessage = "No es una descripcion válida")]
        [MaxLength(100, ErrorMessage = "Excede de 100 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        //[UnqiueProgramaDetalle(ErrorMessage = "Nombre duplicado ya existe en otro registro")]
        public string descripcioncc
        {
            get { return GetValue(() => descripcioncc); }
            set { SetValue(() => descripcioncc, value); }
        }

        public string nombreCuenta
        {
            get { return GetValue(() => nombreCuenta); }
            set { SetValue(() => nombreCuenta, value); }
        }

        public string descripcionccuentas
        {
            get { return GetValue(() => descripcionccuentas); }
            set { SetValue(() => descripcionccuentas, value); }
        }

        //Registra la naturaleza del saldo de la cuenta: D= Deudor, A=Acreedor,  RD=Resultado deudor, RA=Resultado acreedor
        public string tiposaldocc
        {
            get { return GetValue(() => tiposaldocc); }
            set { SetValue(() => tiposaldocc, value); }
        }

        [DisplayName("Fecha de creación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true),
        Required(ErrorMessage = "Formato de fecha incorrecto")]
        [Range(typeof(DateTime), "1/1/1970", "31/12/2050",
        ErrorMessage = "El valor {0} debe estar entre  {1} y {2}")]
        [RegularExpression(@"^(?:3[01]|[12][0-9]|0?[1-9])([\-/.])(0?[1-9]|1[1-2])\1\d{4}$", ErrorMessage = "Deben ser números del formado dd-mm-aaaa")]
        public string fechacreacioncc
        {
            get { return GetValue(() => fechacreacioncc); }
            set { SetValue(() => fechacreacioncc, value); }
        }

        [DisplayName("Orden de presentación")]
        [Required(ErrorMessage = "Dato requerido")]
        [Range(1, 100, ErrorMessage = "El maximo es de 100 y mínimo de 1")]
        public Nullable<decimal> ordencc
        {
            get { return GetValue(() => ordencc); }
            set { SetValue(() => ordencc, value); }
        }

        public string estadocc
        {
            get { return GetValue(() => estadocc); }
            set { SetValue(() => estadocc, value); }
        }

        //Adicionadas
        public string ordenDhPresentacion
        {
            get { return GetValue(() => ordenDhPresentacion); }
            set { SetValue(() => ordenDhPresentacion, value); }
        }
        public Nullable<decimal> ordenccPadre
        {
            get { return GetValue(() => ordenccPadre); }
            set { SetValue(() => ordenccPadre, value); }
        }


        public string nombreElemento
        {
            get { return GetValue(() => nombreElemento); }
            set { SetValue(() => nombreElemento, value); }
        }
        public string nombreClaseCuenta
        {
            get { return GetValue(() => nombreClaseCuenta); }
            set { SetValue(() => nombreClaseCuenta, value); }
        }

        public string nombreTipoSaldoCuenta
        {
            get { return GetValue(() => nombreTipoSaldoCuenta); }
            set { SetValue(() => nombreTipoSaldoCuenta, value); }
        }

        public string nombrePadre
        {
            get { return GetValue(() => nombrePadre); }
            set { SetValue(() => nombrePadre, value); }
        }
        public string codigoContablePadre
        {
            get { return GetValue(() => codigoContablePadre); }
            set { SetValue(() => codigoContablePadre, value); }
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

        public bool IsOperable
        {
            get { return GetValue(() => IsOperable); }
            set { SetValue(() => IsOperable, value); }
        }
        #endregion

        #region colecciones virtuales

        public virtual ElementoModelo elementoModeloCC
        {
            get { return GetValue(() => elementoModeloCC); }
            set { SetValue(() => elementoModeloCC, value); }
        }

        public virtual CatalogoCuentasModelo CatalogoCuentasModeloPadre
        {
            get { return GetValue(() => CatalogoCuentasModeloPadre); }
            set { SetValue(() => CatalogoCuentasModeloPadre, value); }
        }


        public virtual SistemaContableModelo sistemaContableModeloCC
        {
            get { return GetValue(() => sistemaContableModeloCC); }
            set { SetValue(() => sistemaContableModeloCC, value); }
        }

        public virtual ClaseCuentaModelo claseCuentaModeloCC
        {
            get { return GetValue(() => claseCuentaModeloCC); }
            set { SetValue(() => claseCuentaModeloCC, value); }
        }

        public virtual TipoSaldoCuentaModelo tipoSaldoCuentaModelo
        {
            get { return GetValue(() => tipoSaldoCuentaModelo); }
            set { SetValue(() => tipoSaldoCuentaModelo, value); }
        }
        public virtual ObservableCollection<CatalogoCuentasModelo> listaEntidadSeleccion
        {
            get { return GetValue(() => listaEntidadSeleccion); }
            set { SetValue(() => listaEntidadSeleccion, value); }
        }

        public virtual ObservableCollection<CatalogoCuentasModelo> listaSubCuentasMayorizacion
        {
            get { return GetValue(() => listaSubCuentasMayorizacion); }
            set { SetValue(() => listaSubCuentasMayorizacion, value); }
        }
        //De Eliezer no borrar porfa.
        public virtual List<ElementoModelo> listaElementos { get; set; }
        public virtual ElementoModelo Elementoss { get; set; }
        public virtual List<ClaseCuentaModelo> listaClaseCuenta { get; set; }
        public virtual ClaseCuentaModelo ClaseCuenta { get; set; }
        public virtual List<TipoSaldo> listaTipoSaldo{get;set;}
        public virtual TipoSaldo tipoSaldo { get; set; }

        public List<TipoSaldo> listaTipoSaldoX = new List<TipoSaldo>
        {
            new TipoSaldo{Id="D", tiposaldo="Deudor"},
            new TipoSaldo{Id="A", tiposaldo="Acreedor"},
            new TipoSaldo{Id="RD", tiposaldo="Resultado deudor"},
            new TipoSaldo{Id="RA", tiposaldo="Resultado acreedor"}
        };

        public class TipoSaldo 
        {
            public string Id { get; set;}
            public string tiposaldo { get; set;}
        }

        #endregion

        #region Public Model Methods

        public static bool Insert(CatalogoCuentasModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new catalogocuenta
                        {
                            //idcc = modelo.idcc,
                            idelementos = modelo.idelementos,
                            idsc = modelo.idsc,
                            catidcc = modelo.catidcc,
                            idccuentas = modelo.idccuentas,
                            codigocc = modelo.codigocc,
                            descripcioncc = modelo.descripcioncc,
                            tiposaldocc = modelo.tiposaldocc,
                            fechacreacioncc = modelo.fechacreacioncc,
                            estadocc = modelo.estadocc,
                            ordencc = modelo.ordencc,
                        };
                        _context.catalogocuentas.Add(tablaDestino);
                        _context.SaveChanges();
                        if (modelo.catidcc != null)
                        {
                            modelo.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)modelo.catidcc);
                            modelo.nombrePadre = modelo.CatalogoCuentasModeloPadre.descripcioncc;
                            modelo.ordenccPadre = modelo.CatalogoCuentasModeloPadre.ordencc;
                            modelo.ordenDhPresentacion = MetodosModelo.ordenConversion(modelo.ordencc);
                            modelo.codigoContablePadre = modelo.CatalogoCuentasModeloPadre.codigocc;
                        }
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idcc = tablaDestino.idcc;

                        modelo.elementoModeloCC=ElementoModelo.Find((int)modelo.idelementos);
                        modelo.nombreElemento = modelo.elementoModeloCC.descripcion;

                        modelo.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)modelo.idccuentas);
                        modelo.nombreClaseCuenta = modelo.claseCuentaModeloCC.descripcionccuentas;

                        modelo.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(modelo.tiposaldocc);
                        modelo.nombreTipoSaldoCuenta = modelo.tipoSaldoCuentaModelo.descripcionTSCuenta;
                        return result;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de catalogo de cuentas: " + e.Message);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static int Insert(CatalogoCuentasModelo modelo)
        {
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        var tablaDestino = new catalogocuenta
                        {
                            //idcc = modelo.idcc,
                            idelementos = modelo.idelementos,
                            idsc = modelo.idsc,
                            catidcc = modelo.catidcc,
                            idccuentas = modelo.idccuentas,
                            codigocc = modelo.codigocc,
                            descripcioncc = modelo.descripcioncc,
                            tiposaldocc = modelo.tiposaldocc,
                            fechacreacioncc = modelo.fechacreacioncc,
                            estadocc = modelo.estadocc,
                            ordencc = modelo.ordencc,
                            isuso=0,
                        };
                        _context.catalogocuentas.Add(tablaDestino);
                        _context.SaveChanges();
                        if (modelo.catidcc != null)
                        {
                            modelo.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)modelo.catidcc);
                            modelo.nombrePadre = modelo.CatalogoCuentasModeloPadre.descripcioncc;
                            modelo.ordenccPadre = modelo.CatalogoCuentasModeloPadre.ordencc;
                            modelo.ordenDhPresentacion = MetodosModelo.ordenConversion(modelo.ordencc);
                            modelo.codigoContablePadre = modelo.CatalogoCuentasModeloPadre.codigocc;
                        }
                        modelo.guardadoBase = true;
                        modelo.IsSelected = false;
                        modelo.idcc = tablaDestino.idcc;

                        modelo.elementoModeloCC = ElementoModelo.Find((int)modelo.idelementos);
                        modelo.nombreElemento = modelo.elementoModeloCC.descripcion;

                        modelo.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)modelo.idccuentas);
                        modelo.nombreClaseCuenta = modelo.claseCuentaModeloCC.descripcionccuentas;

                        modelo.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(modelo.tiposaldocc);
                        modelo.nombreTipoSaldoCuenta = modelo.tipoSaldoCuentaModelo.descripcionTSCuenta;
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de catalogo de cuentas: \n" + e);
                    return -1;
                }
            }
            else
            {
                return result;
            }
        }


        public static int InsertByRange(ObservableCollection<catalogocuenta> lista)
        {
            int result = 0;
            if (lista.Count>0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        if (!(sincronizar))
                        {
                            var valorMantenimiento = _context.Database.ExecuteSqlCommand(
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.catalogocuentas', 'idcc'), (SELECT MAX(idcc) FROM sgpt.catalogocuentas) + 1);");
                            sincronizar = true;
                        }
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        _context.catalogocuentas.AddRange(lista);
                        _context.SaveChanges();
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de catalogo de cuentas: " + e.Message);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static void UpdateByRange(ObservableCollection<catalogocuenta> lista,bool retorno)
        {
            //int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        foreach (catalogocuenta item in lista)
                        {
                            _context.Entry(item).State = EntityState.Modified;
                            _context.SaveChanges();
                        }
                        //result = 1;
                        //return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en actualizar registro de catalogo de cuentas: " + e.Message);
                    throw;
                    //return result;
                }
            }
            else
            {
                //return result;
            }
        }
        public static int UpdateByRange(ObservableCollection<catalogocuenta> lista)
        {
            int result = 0;
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        //var items = from c in _context.maestrocatalogos select c.idmaestrocatalogo;
                        foreach (catalogocuenta item in lista)
                        { 
                        _context.Entry(item).State = EntityState.Modified;
                        _context.SaveChanges();
                        }
                        result = 1;
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de catalogo de cuentas: " + e.Message);
                    return result;
                }
            }
            else
            {
                return result;
            }
        }
        //Devuelve el registro buscado con base al indice
        public static CatalogoCuentasModelo Find(int id)
        {
            var entidad = new CatalogoCuentasModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    catalogocuenta modelo = _context.catalogocuentas.Find(id);
                    if (modelo == null)
                    {
                        modelo = null;
                    }
                    else
                    {
                        entidad.idcc = modelo.idcc;
                        entidad.idelementos = modelo.idelementos;
                        entidad.idsc = modelo.idsc;
                        entidad.catidcc = modelo.catidcc;
                        entidad.idccuentas = modelo.idccuentas;
                        entidad.codigocc = modelo.codigocc;
                        entidad.descripcioncc = modelo.descripcioncc;
                        entidad.tiposaldocc = modelo.tiposaldocc;
                        entidad.fechacreacioncc = modelo.fechacreacioncc;
                        entidad.estadocc = modelo.estadocc;
                        entidad.ordencc = modelo.ordencc;
                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                        if (entidad.catidcc != null)
                        {
                            entidad.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)entidad.catidcc);
                            entidad.nombrePadre = entidad.CatalogoCuentasModeloPadre.descripcioncc;
                            entidad.ordenccPadre = entidad.CatalogoCuentasModeloPadre.ordencc;
                            entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                            entidad.codigoContablePadre = entidad.CatalogoCuentasModeloPadre.codigocc;
                        }
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.elementoModeloCC = ElementoModelo.Find((int)entidad.idelementos);
                        entidad.nombreElemento = entidad.elementoModeloCC.descripcion;

                        entidad.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)entidad.idccuentas);
                        entidad.nombreClaseCuenta = entidad.claseCuentaModeloCC.descripcionccuentas;

                        entidad.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(entidad.tiposaldocc);
                        entidad.nombreTipoSaldoCuenta = entidad.tipoSaldoCuentaModelo.descripcionTSCuenta;
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

        //Devuelve el maximo del orden de un registro
        public static Nullable<decimal> FindOrden(int idsc)
        {
            decimal? ordenMaximo = 0;
            if (!(idsc == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    ordenMaximo = _context.catalogocuentas.Where(x => x.idsc == idsc).Max(p => p.ordencc);
                    if (ordenMaximo == null)
                    {
                        return ordenMaximo = 1;
                    }
                    else
                    { 
                        return ordenMaximo + 1;
                    }
                }
            }
            else
            {
                return ordenMaximo;
            }
        }
        #region Metodos para string 


        public static CatalogoCuentasModelo GetRegistro(string id)
        {
            var entidad = new CatalogoCuentasModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidad = null;
                    }
                    catalogocuenta modelo = _context.catalogocuentas.Find(id);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.idcc = modelo.idcc;
                        entidad.idelementos = modelo.idelementos;
                        entidad.idsc = modelo.idsc;
                        entidad.catidcc = modelo.catidcc;
                        entidad.idccuentas = modelo.idccuentas;
                        entidad.codigocc = modelo.codigocc;
                        entidad.descripcioncc = modelo.descripcioncc;
                        entidad.tiposaldocc = modelo.tiposaldocc;
                        entidad.fechacreacioncc = modelo.fechacreacioncc;
                        entidad.estadocc = modelo.estadocc;
                        entidad.ordencc = modelo.ordencc;
                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                        if (entidad.catidcc != null)
                        {
                            entidad.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)entidad.catidcc);
                            entidad.nombrePadre = entidad.CatalogoCuentasModeloPadre.descripcioncc;
                            entidad.ordenccPadre = entidad.CatalogoCuentasModeloPadre.ordencc;
                            entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                            entidad.codigoContablePadre = entidad.CatalogoCuentasModeloPadre.codigocc;
                       }
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.elementoModeloCC = ElementoModelo.Find((int)entidad.idelementos);
                        entidad.nombreElemento = entidad.elementoModeloCC.descripcion;

                        entidad.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)entidad.idccuentas);
                        entidad.nombreClaseCuenta = entidad.claseCuentaModeloCC.descripcionccuentas;

                        entidad.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(entidad.tiposaldocc);
                        entidad.nombreTipoSaldoCuenta = entidad.tipoSaldoCuentaModelo.descripcionTSCuenta;
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
                return entidad;
            }

        }

        public static CatalogoCuentasModelo GetRegistroById(int id)
        {
            var entidad = new CatalogoCuentasModelo();
            if (id!=0)
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id.ToString()))
                    {
                        return entidad = null;
                    }
                    catalogocuenta modelo = _context.catalogocuentas.Find(id);
                    if (modelo == null)
                    {
                        return entidad = null;
                    }
                    else
                    {
                        entidad.idcc = modelo.idcc;
                        entidad.idelementos = modelo.idelementos;
                        entidad.idsc = modelo.idsc;
                        entidad.catidcc = modelo.catidcc;
                        entidad.idccuentas = modelo.idccuentas;
                        entidad.codigocc = modelo.codigocc;
                        entidad.descripcioncc = modelo.descripcioncc;
                        entidad.tiposaldocc = modelo.tiposaldocc;
                        entidad.fechacreacioncc = modelo.fechacreacioncc;
                        entidad.estadocc = modelo.estadocc;
                        entidad.ordencc = modelo.ordencc;
                        //entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                        if (entidad.catidcc != null)
                        {
                            entidad.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)entidad.catidcc);
                            entidad.nombrePadre = entidad.CatalogoCuentasModeloPadre.descripcioncc;
                            entidad.ordenccPadre = entidad.CatalogoCuentasModeloPadre.ordencc;
                            entidad.ordenDhPresentacion = MetodosModelo.ordenConversion(entidad.ordencc);
                            entidad.codigoContablePadre = entidad.CatalogoCuentasModeloPadre.codigocc;
                        }
                        entidad.guardadoBase = true;
                        entidad.IsSelected = false;
                        entidad.elementoModeloCC = ElementoModelo.Find((int)entidad.idelementos);
                        entidad.nombreElemento = entidad.elementoModeloCC.descripcion;

                        entidad.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)entidad.idccuentas);
                        entidad.nombreClaseCuenta = entidad.claseCuentaModeloCC.descripcionccuentas;

                        entidad.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(entidad.tiposaldocc);
                        entidad.nombreTipoSaldoCuenta = entidad.tipoSaldoCuentaModelo.descripcionTSCuenta;
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
                return entidad;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new CatalogoCuentasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    catalogocuenta entidad = _context.catalogocuentas.Find(id);
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
                    var modelo = new CatalogoCuentasModelo();
                    catalogocuenta entidad = _context.catalogocuentas.Find(id);
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
                    var modelo = new CatalogoCuentasModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.catalogocuentas
                            .Where(b => b.estadocc == "B")
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
                    catalogocuenta entidad = _context.catalogocuentas.Find(id);
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

        public static string FindNombreById(int? id)
        {
            string nombre = string.Empty;
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    return nombre = _context.catalogocuentas.Find(id).descripcioncc;
                }
            }
            else
            {
                return nombre;
            }
        }
        public static Nullable<decimal> FindOrdenPadreById(int? id)
        {
            Nullable<decimal> nombre = 0;
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    return nombre = _context.catalogocuentas.Find(id).ordencc;
                }
            }
            else
            {
                return nombre;
            }
        }
        //Para realizar busquedas de texto

        public static void UpdateModelo(CatalogoCuentasModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    catalogocuenta entidad = _context.catalogocuentas.Find(modelo.idcc);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idcc = modelo.idcc;
                        entidad.idelementos = modelo.idelementos;
                        entidad.idsc = modelo.idsc;
                        entidad.catidcc = modelo.catidcc;
                        entidad.idccuentas = modelo.idccuentas;
                        entidad.codigocc = modelo.codigocc;
                        entidad.descripcioncc = modelo.descripcioncc;
                        entidad.tiposaldocc = modelo.tiposaldocc;
                        entidad.fechacreacioncc = modelo.fechacreacioncc;
                        entidad.estadocc = modelo.estadocc;
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

        public static void UpdateModeloReodenar(CatalogoCuentasModelo modelo)
        {
            if (!(modelo == null))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.catalogocuentas SET ordencc = {0} WHERE idcc={1};",modelo.ordencc,modelo.idcc);
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

        public static bool UpdateModelo(CatalogoCuentasModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        catalogocuenta entidad = _context.catalogocuentas.Find(modelo.idcc);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.idcc = modelo.idcc; no puede cambiar
                            if (!(entidad.catidcc == modelo.catidcc))
                            {
                                entidad.catidcc = modelo.catidcc;
                                cambio = true;
                            }
                            if (!(entidad.idelementos == modelo.idelementos))
                            {
                                entidad.idelementos = modelo.idelementos;
                                cambio = true;
                            }
                            //entidad.idsc = modelo.idsc; No puede cambiar
                            if (!(entidad.descripcioncc.ToUpper().Trim() == modelo.descripcioncc.ToUpper().Trim()))
                            {
                                entidad.descripcioncc = modelo.descripcioncc;
                                cambio = true;
                            }
                            //if (!(entidad.fechacreacioncc == modelo.fechacreacioncc.ToString()))
                            //{
                            //    entidad.fechacreacioncc = modelo.fechacreacioncc.ToString();
                            //    cambio = true;
                            //}
                            if (!(entidad.ordencc == modelo.ordencc))
                            {
                                entidad.ordencc = modelo.ordencc;
                                cambio = true;
                            }

                            if (!(entidad.idccuentas == modelo.idccuentas))
                            {
                                entidad.idccuentas = modelo.idccuentas;
                                cambio = true;
                            }

                            if (!(entidad.tiposaldocc == modelo.tiposaldocc))
                            {
                                entidad.tiposaldocc = modelo.tiposaldocc;
                                cambio = true;
                            }
                            if (!(entidad.codigocc == modelo.codigocc))
                            {
                                entidad.idccuentas = modelo.idccuentas;
                                cambio = true;
                            }
                            if (cambio)
                            {
                                //entidad.idcc = modelo.idcc;
                                entidad.idelementos = modelo.idelementos;
                                entidad.idsc = modelo.idsc;
                                entidad.catidcc = modelo.catidcc;
                                entidad.idccuentas = modelo.idccuentas;
                                entidad.codigocc = modelo.codigocc;
                                entidad.descripcioncc = modelo.descripcioncc;
                                entidad.tiposaldocc = modelo.tiposaldocc;
                                entidad.fechacreacioncc = modelo.fechacreacioncc;
                                entidad.estadocc = modelo.estadocc;
                                entidad.ordencc = modelo.ordencc;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            return true;
                        }
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en actualizar entidad catalogo de cuentas : " + e.Message);
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
        public static bool DeleteBorradoLogico(int id, Boolean actualizar)
        {
            bool result = false;
            if (!(id == 0))
            {
                {

                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.catalogocuentas SET estadocc = 'B' WHERE idcc={0};", id);
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
                            MessageBox.Show("Exception en borrar registro del catalogo: " + e.Message);
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
        
        public static void Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.catalogocuentas WHERE idcc={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                throw;
            }
        }

        public static void DeleteByRange(ObservableCollection<catalogocuenta> lista)
        {
            try
            {
                if (lista.Count> 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                            _context.catalogocuentas.RemoveRange(lista);
                            _context.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en borrar registro del rango : " + e.Message);
                throw;
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
                        string commandString = String.Format("DELETE FROM sgpt.catalogocuentas WHERE idcc={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                }
                return false;
                throw;
            }
        }

        public static bool DeleteAllByIdsc(int idsc)
        {
            try
            {
                if (idsc != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                       string commandString = String.Format("DELETE FROM sgpt.catalogocuentas WHERE idsc = {0};", idsc);
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
                    MessageBox.Show("Exception en borrar catalogo : " + e.Message);
                }
                return false;
                throw;
            }
        }

        public static bool DeleteLogicoAllByIdsc(int idsc)
        {
            try
            {
                if (idsc != 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.catalogocuentas SET estadocc = 'B' WHERE idsc = {0};", idsc);
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
                    MessageBox.Show("Exception en borrar catalogo : " + e.Message);
                }
                return false;
                throw;
            }
        }

        public static bool Delete(ObservableCollection<CatalogoCuentasModelo> lista)
        {
            try
            {
                if (lista.Count> 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        int idSc =(int) lista[0].idsc;
                        catalogocuenta entidadTemporal = new catalogocuenta();
                        ////Obtener la lista que esta en la base
                        //var query = from c in _context.catalogocuentas
                        //            where c.idsc == idSc
                        //            select c;
                        foreach (CatalogoCuentasModelo item in  lista)
                        {
                            //Buscar registro
                            string commandString = String.Format("DELETE FROM sgpt.catalogocuentas WHERE idcc={0};", item.idcc);
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
                    MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                }
                return false;
                throw;
            }
        }

        internal static decimal GetOrdenRegistro(int idSc)
        {

            if (!(idSc == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        var entidadTemporal = _context.catalogocuentas.Find(idSc);
                        if (entidadTemporal != null)
                        {
                            return (decimal)entidadTemporal.ordencc;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error en  la recuperacion del  registro "+e.Message);
                    return 0;
                    throw;
                }
            }
            else
            {
                return 0;
            }
        }

        public static bool DeleteBorradoLogico(ObservableCollection<CatalogoCuentasModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    catalogocuenta entidadTemporal = new catalogocuenta();
                    int idsc = (int)lista[0].idsc;
                    using (_context = new SGPTEntidades())
                    {
                        foreach (CatalogoCuentasModelo item in lista)
                        {
                            string commandString = String.Format("UPDATE sgpt.catalogocuentas SET estadocc = 'B' WHERE idcc={0};", item.idcc);
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
                        MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                    }
                    return false;
                    throw;
                }
            }
            else
                {
                return true;
            }
        }

        public static bool DeleteBorradoLogicoTotal(ObservableCollection<catalogocuenta> lista, int idsc)
        {
            if (lista.Count > 0)
            {
                try
                {
                        using (_context = new SGPTEntidades())
                        {
                        string commandString = String.Format("UPDATE sgpt.catalogocuentas SET estadocc = 'B' WHERE idsc = {0};", idsc);
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
                        MessageBox.Show("Exception en borrar registro del detalle : " + e.Message);
                    }
                    return false;
                    throw;
                }
            }
            else
            {
                return true;
            }
        }

        //Conversion explicita
        public static explicit operator catalogocuenta(CatalogoCuentasModelo modelo)  // explicit byte to digit conversion operator
        {
            catalogocuenta entidad = new catalogocuenta();
            entidad.idcc = modelo.idcc;
            entidad.idelementos = modelo.idelementos;
            entidad.idsc = modelo.idsc;
            entidad.catidcc = modelo.catidcc;
            entidad.idccuentas = modelo.idccuentas;
            entidad.codigocc = modelo.codigocc;
            entidad.descripcioncc = modelo.descripcioncc;
            entidad.tiposaldocc = modelo.tiposaldocc;
            entidad.fechacreacioncc = modelo.fechacreacioncc;
            entidad.estadocc = modelo.estadocc;
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
                            string commandString = String.Format("DELETE FROM sgpt.catalogocuentas WHERE idcc={0};", id);
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

        public static ObservableCollection<CatalogoCuentasModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.catalogocuentas.Select(entidad =>
                     new CatalogoCuentasModelo
                     {
                         idcc = entidad.idcc,
                         idelementos = entidad.idelementos,
                         idsc = entidad.idsc,
                         catidcc = entidad.catidcc,
                         idccuentas = entidad.idccuentas,
                         codigocc = entidad.codigocc,
                         descripcioncc = entidad.descripcioncc,
                         tiposaldocc = entidad.tiposaldocc,
                         fechacreacioncc = entidad.fechacreacioncc,
                         estadocc = entidad.estadocc,
                         ordencc=entidad.ordencc,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.codigocc).Where(x => x.estadocc == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;


                    foreach (CatalogoCuentasModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                        if (item.catidcc != null)
                        {
                            item.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)item.catidcc);
                            item.nombrePadre = item.CatalogoCuentasModeloPadre.descripcioncc;
                            item.ordenccPadre = item.CatalogoCuentasModeloPadre.ordencc;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                            item.codigoContablePadre = item.CatalogoCuentasModeloPadre.codigocc;

                        }
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.elementoModeloCC = ElementoModelo.Find((int)item.idelementos);
                        item.nombreElemento = item.elementoModeloCC.descripcion;

                        item.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)item.idccuentas);
                        item.nombreClaseCuenta = item.claseCuentaModeloCC.descripcionccuentas;

                        item.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(item.tiposaldocc);
                        item.nombreTipoSaldoCuenta = item.tipoSaldoCuentaModelo.descripcionTSCuenta;
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return RegeneraOrdenSubRegistros(new ObservableCollection<CatalogoCuentasModelo>(lista));
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }

        public static List<CatalogoCuentasModelo> GetAllByIdScForDisplay(int idSc)
        {
            //Exclusivo para crud de balance
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.catalogocuentas.Select(entidad =>
                     new CatalogoCuentasModelo
                     {
                         idcc = entidad.idcc,
                         idelementos = entidad.idelementos,
                         idsc = entidad.idsc,
                         catidcc = entidad.catidcc,
                         idccuentas = entidad.idccuentas,
                         codigocc = entidad.codigocc,
                         descripcioncc = entidad.descripcioncc,
                         tiposaldocc = entidad.tiposaldocc,
                         fechacreacioncc = entidad.fechacreacioncc,
                         estadocc = entidad.estadocc,
                         ordencc = entidad.ordencc,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordencc).Where(x => x.estadocc == "A" && x.idsc==idSc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CatalogoCuentasModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.descripcioncc = item.codigocc + "-" + item.descripcioncc;
                    }
                    CatalogoCuentasModelo temporal = new CatalogoCuentasModelo
                    {
                        idcc = 0,
                        idelementos = 0,
                        idsc = idSc,
                        catidcc = 0,
                        idccuentas = 0,
                        codigocc = "",
                        descripcioncc = "Ninguna",
                        tiposaldocc = "A",
                        fechacreacioncc = MetodosModelo.homologacionFecha(),
                        estadocc = "A",
                        ordencc = 1,
                    };
                    lista.Insert(0, temporal);
                    //lista.ForEach(c => c.guardadoBase = true);
                    return lista;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<CatalogoCuentasModelo> GetAllByIdScForDisplayToPartidas(int idSc)
        {
            //Exclusivo para crud de balance
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.catalogocuentas.Select(entidad =>
                     new CatalogoCuentasModelo
                     {
                         idcc = entidad.idcc,
                         idelementos = entidad.idelementos,
                         idsc = entidad.idsc,
                         catidcc = entidad.catidcc,
                         idccuentas = entidad.idccuentas,
                         codigocc = entidad.codigocc,
                         descripcioncc = entidad.descripcioncc,
                         tiposaldocc = entidad.tiposaldocc,
                         fechacreacioncc = entidad.fechacreacioncc,
                         estadocc = entidad.estadocc,
                         ordencc = entidad.ordencc,
                         nombreClaseCuenta = entidad.clasecuenta.descripcionccuentas,
                         nombreElemento = entidad.elemento.descripcionelementos,
                         IsOperable=false,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordencc).Where(x => x.estadocc == "A" && x.idsc == idSc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CatalogoCuentasModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;
                        item.IsSelected = false;
                        item.nombreCuenta = item.codigocc + "-" + item.descripcioncc;
                        switch (item.nombreClaseCuenta.ToUpper().Trim())
                        {
                            case "CUENTA":
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    item.IsOperable = false;
                                }
                                else
                                {
                                    item.IsOperable = true;
                                }
                                break;
                            case "SUB-CUENTA":
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    item.IsOperable = false;
                                }
                                else
                                {
                                    item.IsOperable = true;
                                }
                                break;
                            case "SUB-SUB-CUENTA":
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    item.IsOperable = false;
                                }
                                else
                                {
                                    item.IsOperable = true;
                                }
                                break;
                            case "SUB-SUB-SUB-CUENTA":
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    item.IsOperable = false;
                                }
                                else
                                {
                                    item.IsOperable = true;
                                }
                                break;
                            case "SUB-SUB-SUB-SUB-CUENTA":
                                if (lista.Count(x => x.catidcc == item.idcc) > 0)
                                {
                                    item.IsOperable = false;
                                }
                                else
                                {
                                    item.IsOperable = true;
                                }
                                break;
                        }

                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<CatalogoCuentasModelo>(lista.ToList());
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return new ObservableCollection<CatalogoCuentasModelo>();
            }
        }



        public static ObservableCollection<catalogocuenta> GetAllCapaDatosByidSC(int idSc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.catalogocuentas WHERE idsc={0} AND estadocc = 'A';", idSc);
                    
                    var lista= _context.catalogocuentas.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<catalogocuenta> temporal = new ObservableCollection<catalogocuenta>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<catalogocuenta> GetAllCapaDatos()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.catalogocuentas;");

                    var lista = _context.catalogocuentas.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<catalogocuenta> temporal = new ObservableCollection<catalogocuenta>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo \n" + e);
                }
                return null;
            }
        }

        public static int GetAllCountByIdSc(int idSc)
        {
            try
            {
                int respuesta = 0;
                using (_context = new SGPTEntidades())
                {
                    respuesta = (from p in _context.catalogocuentas
                                            where p.idsc == idSc && p.estadocc == "A" 
                                            select p).Count();
                    //string commandString = String.Format("SELECT COUNT(*) FROM sgpt.catalogocuentas WHERE idSC={0};", idSc);
                    //commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    //respuesta = _context.Database.ExecuteSqlCommand(commandString);
                    return respuesta;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return -1;
            }
        }

        public static List<CatalogoCuentasModelo> GetAllByIdElementoYIdClaseCuenta(ElementoModelo elementoModelo,ClaseCuentaModelo claseCuenta, SistemaContableModelo sistemaContable)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.catalogocuentas.Select(entidad =>
                     new CatalogoCuentasModelo
                     {
                         idcc = entidad.idcc,
                         idelementos = entidad.idelementos,
                         idsc = entidad.idsc,
                         catidcc = entidad.catidcc,
                         idccuentas = entidad.idccuentas,
                         codigocc = entidad.codigocc,
                         descripcioncc = entidad.descripcioncc,
                         tiposaldocc = entidad.tiposaldocc,
                         fechacreacioncc = entidad.fechacreacioncc,
                         estadocc = entidad.estadocc,
                         ordencc = entidad.ordencc,
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.codigocc).Where(x => x.estadocc == "A" && x.idsc==sistemaContable.idsc && x.idelementos==elementoModelo.id ).ToList();
                    //La ordena por el idPrograma notar la notacion
                    int i = 1;
                    foreach (CatalogoCuentasModelo item in lista)
                    {
                        item.descripcioncc = item.codigocc + " " + item.descripcioncc;
                        item.idCorrelativo = i;
                        i++;
                        item.guardadoBase = true;

                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                        if (item.catidcc != null)
                        {
                            item.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)item.catidcc);
                            item.nombrePadre = item.CatalogoCuentasModeloPadre.descripcioncc;
                            item.ordenccPadre = item.CatalogoCuentasModeloPadre.ordencc;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                            item.codigoContablePadre = item.CatalogoCuentasModeloPadre.codigocc;
                        }
                        item.IsSelected = true;

                        item.elementoModeloCC = ElementoModelo.Find((int)item.idelementos);
                        item.nombreElemento = item.elementoModeloCC.descripcion;

                        item.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)item.idccuentas);
                        item.nombreClaseCuenta = item.claseCuentaModeloCC.descripcionccuentas;

                        item.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(item.tiposaldocc);
                        item.nombreTipoSaldoCuenta = item.tipoSaldoCuentaModelo.descripcionTSCuenta;
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
                    MessageBox.Show("Exception en elaboracion de lista del catalogo" + e.Message);
                }
                return null;
            }
        }

        public static ObservableCollection<CatalogoCuentasModelo> GetAllImportacion(int idEncargo)
        {
            try
            {
                //listaTipoSaldo= new List<TipoSaldo>();
                //TipoSaldo tp = new TipoSaldo();
                //tp.Id="D"; tp.tiposaldo="Deudor"; 
                SistemaContableModelo scm = SistemaContableModelo.GetRegistroByIdEncargo(idEncargo);
                using (_context = new SGPTEntidades())
                {
                    var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)scm.idsc));
                    var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

                    var listaElementos2 = listaElementos.ToList();
                    var listaClaseCuenta2 = listaClaseCuenta.ToList();
                    //var elemnts = ElementoModelo.GetBySistemaContableAll((int)scm.idsc);
                    var lista = _context.catalogocuentas.Select(entidad =>
                    new CatalogoCuentasModelo
                    {
                        idcc = entidad.idcc,
                        idelementos = entidad.idelementos,
                        idsc = entidad.idsc,
                        catidcc = entidad.catidcc,
                        idccuentas = entidad.idccuentas,
                        codigocc = entidad.codigocc,
                        descripcioncc = entidad.descripcioncc,
                        tiposaldocc = entidad.tiposaldocc,
                        fechacreacioncc = entidad.fechacreacioncc,
                        estadocc = entidad.estadocc,
                        ordencc = entidad.ordencc,
                        nombreClaseCuenta = entidad.clasecuenta.descripcionccuentas,
                        nombreElemento = entidad.elemento.descripcionelementos,
                        //Elementoss = ElementoModelo.GetRegistroById((int)entidad.idelementos),//listaElementos2.Find(y=>(int)y.idscelementos==(int)entidad.idelementos),
                        //ClaseCuenta = ClaseCuentaModelo.get listaClaseCuenta2.Find(z=>z.id==(int)entidad.idccuentas),
                         // elemnts.Find(y=>y.id== entidad.elemento.idelementos),
                        
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordencc).Where(x => x.estadocc == "A" && x.idsc == scm.idsc).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new ObservableCollection<CatalogoCuentasModelo>();
                    }
                    else
                    {
                        int i = 1;
                        //var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)scm.idsc));
                        //var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

                        foreach (CatalogoCuentasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                            if (item.catidcc != null)
                            {
                                //Se vuelvea ha hacer consulta a la base??
                                //item.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)item.catidcc);
                                //Se busca en  la lista en  lugar de ir por cada registro
                                item.CatalogoCuentasModeloPadre = lista.Single(d => d.idcc == item.catidcc);
                                item.nombrePadre = item.CatalogoCuentasModeloPadre.descripcioncc;
                                item.ordenccPadre = item.CatalogoCuentasModeloPadre.ordencc;
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                                item.codigoContablePadre = item.CatalogoCuentasModeloPadre.codigocc;
                            }

                            //item.elementoModeloCC = ElementoModelo.Find((int)item.idelementos);
                            item.elementoModeloCC = listaElementos.Single(p => p.id == item.idelementos);

                            //item.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)item.idccuentas);
                            item.claseCuentaModeloCC = listaClaseCuenta.Single(z => z.id == item.idccuentas);

                            item.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(item.tiposaldocc);
                            item.nombreTipoSaldoCuenta = item.tipoSaldoCuentaModelo.descripcionTSCuenta;

                            //De Eliezer
                            item.listaClaseCuenta = listaClaseCuenta2;
                            item.listaElementos = listaElementos2;
                            item.Elementoss = listaElementos2.Find(y=>(int)y.id==(int)item.idelementos); //ElementoModelo.GetRegistroById((int)entidad.idelementos),//
                            item.ClaseCuenta = listaClaseCuenta2.Find(z=>z.id== (int)item.idccuentas);// (int)entidad.idccuentas),
                            item.tipoSaldo = item.listaTipoSaldoX.Find(x => x.Id == item.tiposaldocc);
                            item.listaTipoSaldo=item.listaTipoSaldoX;
                        }
                        return RegeneraOrdenSubRegistros(new ObservableCollection<CatalogoCuentasModelo>(lista));
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                return new ObservableCollection<CatalogoCuentasModelo>();
            }
        }
        public static ObservableCollection<CatalogoCuentasModelo> GetAll(int idEncargo)
        {
            try
            {
                SistemaContableModelo scm = SistemaContableModelo.GetRegistroByIdEncargo(idEncargo);
                using (_context = new SGPTEntidades())
                {

                    var lista = _context.catalogocuentas.Select(entidad =>
                    new CatalogoCuentasModelo
                    {
                        idcc = entidad.idcc,
                        idelementos = entidad.idelementos,
                        idsc = entidad.idsc,
                        catidcc = entidad.catidcc,
                        idccuentas = entidad.idccuentas,
                        codigocc = entidad.codigocc,
                        descripcioncc = entidad.descripcioncc,
                        tiposaldocc = entidad.tiposaldocc,
                        fechacreacioncc = entidad.fechacreacioncc,
                        estadocc = entidad.estadocc,
                        ordencc = entidad.ordencc,
                        nombreClaseCuenta = entidad.clasecuenta.descripcionccuentas,
                        nombreElemento = entidad.elemento.descripcionelementos,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordencc).Where(x => x.estadocc == "A" && x.idsc == scm.idsc).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new ObservableCollection<CatalogoCuentasModelo>();
                    }
                    else
                    {
                        int i = 1;
                        var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion((int)scm.idsc));
                        var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

                        foreach (CatalogoCuentasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                            if (item.catidcc != null)
                            {
                                //Se vuelvea ha hacer consulta a la base??
                                //item.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)item.catidcc);
                                //Se busca en  la lista en  lugar de ir por cada registro
                                item.CatalogoCuentasModeloPadre = lista.Single(d => d.idcc == item.catidcc);
                                item.nombrePadre = item.CatalogoCuentasModeloPadre.descripcioncc;
                                item.ordenccPadre = item.CatalogoCuentasModeloPadre.ordencc;
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                                item.codigoContablePadre = item.CatalogoCuentasModeloPadre.codigocc;
                            }

                            //item.elementoModeloCC = ElementoModelo.Find((int)item.idelementos);
                            item.elementoModeloCC = listaElementos.Single(p => p.id == item.idelementos);

                            //item.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)item.idccuentas);
                            item.claseCuentaModeloCC = listaClaseCuenta.Single(z => z.id == item.idccuentas);

                            item.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(item.tiposaldocc);
                            item.nombreTipoSaldoCuenta = item.tipoSaldoCuentaModelo.descripcionTSCuenta;

                            //De Eliezer
                            //item.listaClaseCuenta = listaClaseCuenta;
                            //item.listaElementos = listaElementos;
                        }
                        return RegeneraOrdenSubRegistros(new ObservableCollection<CatalogoCuentasModelo>(lista));
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                return new ObservableCollection<CatalogoCuentasModelo>();
            }
        }
        public static ObservableCollection<CatalogoCuentasModelo> GetAll(int scm, bool resultado)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {

                    var lista = _context.catalogocuentas.Select(entidad =>
                    new CatalogoCuentasModelo
                    {
                        idcc = entidad.idcc,
                        idelementos = entidad.idelementos,
                        idsc = entidad.idsc,
                        catidcc = entidad.catidcc,
                        idccuentas = entidad.idccuentas,
                        codigocc = entidad.codigocc,
                        descripcioncc = entidad.descripcioncc,
                        tiposaldocc = entidad.tiposaldocc,
                        fechacreacioncc = entidad.fechacreacioncc,
                        estadocc = entidad.estadocc,
                        ordencc = entidad.ordencc,
                        nombreClaseCuenta = entidad.clasecuenta.descripcionccuentas,
                        nombreElemento = entidad.elemento.descripcionelementos,
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordencc).Where(x => x.estadocc == "A" && x.idsc == scm).ToList();

                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count == 0)
                    {
                        return new ObservableCollection<CatalogoCuentasModelo>();
                    }
                    else
                    {
                        int i = 1;
                        var listaElementos = new ObservableCollection<ElementoModelo>(ElementoModelo.GetBySistemaContableAllForSeleccion(scm));
                        var listaClaseCuenta = new ObservableCollection<ClaseCuentaModelo>(ClaseCuentaModelo.GetAllByCatalogo());

                        foreach (CatalogoCuentasModelo item in lista)
                        {
                            item.idCorrelativo = i;
                            i++;
                            item.guardadoBase = true;
                            item.IsSelected = false;
                            item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                            if (item.catidcc != null)
                            {
                                //Se vuelvea ha hacer consulta a la base??
                                //item.CatalogoCuentasModeloPadre = CatalogoCuentasModelo.GetRegistroById((int)item.catidcc);
                                //Se busca en  la lista en  lugar de ir por cada registro
                                item.CatalogoCuentasModeloPadre = lista.Single(d => d.idcc == item.catidcc);
                                item.nombrePadre = item.CatalogoCuentasModeloPadre.descripcioncc;
                                item.ordenccPadre = item.CatalogoCuentasModeloPadre.ordencc;
                                item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordencc);
                                item.codigoContablePadre = item.CatalogoCuentasModeloPadre.codigocc;
                            }

                            //item.elementoModeloCC = ElementoModelo.Find((int)item.idelementos);
                            item.elementoModeloCC = listaElementos.Single(p => p.id == item.idelementos);

                            //item.claseCuentaModeloCC = ClaseCuentaModelo.Find((int)item.idccuentas);
                            item.claseCuentaModeloCC = listaClaseCuenta.Single(z => z.id == item.idccuentas);

                            item.tipoSaldoCuentaModelo = TipoSaldoCuentaModelo.findByTipoSaldo(item.tiposaldocc);
                            item.nombreTipoSaldoCuenta = item.tipoSaldoCuentaModelo.descripcionTSCuenta;
                        }
                        return RegeneraOrdenSubRegistros(new ObservableCollection<CatalogoCuentasModelo>(lista));
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas " + e.Message + " fuente " + e.Source);
                var lista = new ObservableCollection<CatalogoCuentasModelo>();
                return lista;
            }
        }
        public static bool DeleteByIdProgramaRange(int? idsc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //var lista = _context.catalogocuentas.Where(x => x.estadocc == "A" && x.idsc == idsc);
                    var lista = (from p in _context.catalogocuentas
                                 where p.idsc == idsc
                                 select p);
                    //La ordena por el idPrograma notar la notacion
                    if (lista.Count() == 0)
                    {
                        return true;
                    }
                    else
                    {
                        _context.catalogocuentas.RemoveRange(lista);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la eliminacion de la lista detalle herramientas " + e.Message + " fuente " + e.Source);
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
                    elementos = _context.catalogocuentas.Where(x => x.idsc == id && x.estadocc == "A").Count();
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

        public static int ContarSubRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.catalogocuentas.Where(x => x.catidcc == id && x.estadocc == "A").Count();
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

        public static int ContarRegistros()
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.catalogocuentas.Where(x => x.estadocc == "A").Count();
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


        #endregion

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.catalogocuentas
                                   where p.descripcioncc.ToLower().Equals(busqueda)
                                   select p).FirstOrDefault();
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

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados

        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.catalogocuentas.Where(x => x.descripcioncc.ToUpper() == busqueda && x.estadocc == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int FindTextoReturnId(string texto, int? idcc)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.catalogocuentas.Where(x => x.descripcioncc.ToUpper() == busqueda && x.estadocc == "A" && x.idcc == idcc).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }

        #region generacion del orden

        private decimal ordenRegistro(CatalogoCuentasModelo padre,int idSc)
        {
            decimal ordenRespuesta = 0;
            if ((padre != null))
            {
                if (!(padre.idcc == 0))
                {
                    int registros = CatalogoCuentasModelo.ContarSubRegistros(padre.idcc) + 1;
                    decimal factorSuma = MetodosModelo.factorPadre(padre.nombreClaseCuenta);
                    if (registros == 1)
                    {
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordencc, factorSuma);
                    }
                    else
                    {
                        ordenRespuesta = Decimal.Add((Decimal)padre.ordencc, factorSuma * registros);
                    }
                }
            }
            else
            {
                ordenRespuesta = (decimal)CatalogoCuentasModelo.FindOrden(idSc);
            }
            return ordenRespuesta;
        }

        public static ObservableCollection<CatalogoCuentasModelo> RegeneraOrdenSubRegistros(ObservableCollection<CatalogoCuentasModelo> listaDetalleHerramienta)
        {

            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    bool guardar = false;
                    decimal contador = 1;
                    int escalarCuenta = 100000;//Sirve para escalar el contador
                    decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<CatalogoCuentasModelo> listaHijos = new ObservableCollection<CatalogoCuentasModelo>();
                    int ubicacion = 0;
                    foreach (CatalogoCuentasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.catidcc == null)
                        {
                            if (itemDetalle.ordencc != contador*escalarCuenta)
                            {
                                guardar = true;
                                //Se asigna el orden a los principales
                                itemDetalle.ordencc = contador * escalarCuenta;
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                            }
                            contador++;
                            if (guardar)
                            {
                                CatalogoCuentasModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                        }
                        else
                        {
                            //Se verifica que segun el tipo de procedimiento deba tener hijos o  no
                            if (!MetodosModelo.correccionOrdenCatogo(itemDetalle.nombreClaseCuenta))
                            {
                                if (itemDetalle.catidcc != null)
                                {
                                    guardar = true;
                                    itemDetalle.catidcc = null;
                                    itemDetalle.ordenccPadre = null;
                                }
                                if (itemDetalle.ordencc != contador*escalarCuenta)
                                {
                                    guardar = true;
                                    //Se asigna el orden a los principales
                                    itemDetalle.ordencc = contador * escalarCuenta;
                                    //itemDetalle.ordenccPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                    itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                }
                                contador++;
                                if (guardar)
                                {
                                    CatalogoCuentasModelo.UpdateModeloReodenar(itemDetalle);
                                    //Se modifica el orden para mantener una estandarizacion
                                }
                            }
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    foreach (CatalogoCuentasModelo item in listaDetalleHerramienta)
                    {
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<CatalogoCuentasModelo>(listaDetalleHerramienta.Where(x => x.catidcc == item.idcc));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)item.ordencc;
                            factor = MetodosModelo.factorPadreCatalogo(item.nombreClaseCuenta);
                            int j = 1;
                            guardar = false;
                            ubicacion = -1;
                            foreach (CatalogoCuentasModelo hijo in listaHijos)
                            {

                                //Es un hijo
                                ubicacion = listaDetalleHerramienta.IndexOf(hijo);
                                if (ubicacion != -1)
                                {
                                    if (listaDetalleHerramienta[ubicacion].ordencc != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                        listaDetalleHerramienta[ubicacion].ordenccPadre = contador;
                                        listaDetalleHerramienta[ubicacion].ordencc = Decimal.Add((decimal)contador, factor * j);
                                        //listaDetalleHerramienta[ubicacion].ordenccPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        listaDetalleHerramienta[ubicacion].ordenDhPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        CatalogoCuentasModelo.UpdateModeloReodenar(listaDetalleHerramienta[ubicacion]);
                                    }
                                    j++;
                                }
                            }
                        }
                    }
                    listaDetalleHerramienta.OrderBy(x => x.ordencc);
                    return listaDetalleHerramienta;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta;
                    throw;
                }
            }
        }

        public static ObservableCollection<CatalogoCuentasModelo> RegeneraOrdenSubRegistrosSinGuardar(ObservableCollection<CatalogoCuentasModelo> listaDetalleHerramienta)
        {

            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    bool guardar = false;
                    decimal contador = 1;
                    int escalarCuenta = 100000;//Sirve para escalar el contador
                    decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<CatalogoCuentasModelo> listaHijos = new ObservableCollection<CatalogoCuentasModelo>();
                    int ubicacion = 0;
                    foreach (CatalogoCuentasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.catidcc == null)
                        {
                            if (itemDetalle.ordencc != contador * escalarCuenta)
                            {
                                guardar = true;
                                //Se asigna el orden a los principales
                                itemDetalle.ordencc = contador * escalarCuenta;
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                            }
                            contador++;
                            if (guardar)
                            {
                                //CatalogoCuentasModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                        }
                        else
                        {
                            //Se verifica que segun el tipo de procedimiento deba tener hijos o  no
                            if (!MetodosModelo.correccionOrdenCatogo(itemDetalle.nombreClaseCuenta))
                            {
                                if (itemDetalle.catidcc != null)
                                {
                                    guardar = true;
                                    itemDetalle.catidcc = null;
                                    itemDetalle.ordenccPadre = null;
                                }
                                if (itemDetalle.ordencc != contador * escalarCuenta)
                                {
                                    guardar = true;
                                    //Se asigna el orden a los principales
                                    itemDetalle.ordencc = contador * escalarCuenta;
                                    //itemDetalle.ordenccPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                    itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                }
                                contador++;
                                if (guardar)
                                {
                                    //CatalogoCuentasModelo.UpdateModeloReodenar(itemDetalle);
                                    //Se modifica el orden para mantener una estandarizacion
                                }
                            }
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    foreach (CatalogoCuentasModelo item in listaDetalleHerramienta)
                    {
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<CatalogoCuentasModelo>(listaDetalleHerramienta.Where(x => x.catidcc == item.idcc));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)item.ordencc;
                            factor = MetodosModelo.factorPadreCatalogo(item.nombreClaseCuenta);
                            int j = 1;
                            guardar = false;
                            ubicacion = -1;
                            foreach (CatalogoCuentasModelo hijo in listaHijos)
                            {

                                //Es un hijo
                                ubicacion = listaDetalleHerramienta.IndexOf(hijo);
                                if (ubicacion != -1)
                                {
                                    if (listaDetalleHerramienta[ubicacion].ordencc != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                        listaDetalleHerramienta[ubicacion].ordenccPadre = contador;
                                        listaDetalleHerramienta[ubicacion].ordencc = Decimal.Add((decimal)contador, factor * j);
                                        //listaDetalleHerramienta[ubicacion].ordenccPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        listaDetalleHerramienta[ubicacion].ordenDhPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        //CatalogoCuentasModelo.UpdateModeloReodenar(listaDetalleHerramienta[ubicacion]);
                                    }
                                    j++;
                                }
                            }
                        }
                    }
                    listaDetalleHerramienta.OrderBy(x => x.ordencc);
                    return listaDetalleHerramienta;
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta;
                    throw;
                }
            }
        }

        public static ObservableCollection<CatalogoCuentasModelo> OrdenarImportacion(ObservableCollection<CatalogoCuentasModelo> listaDetalleHerramienta)
        {

            if (listaDetalleHerramienta.Count == 0)
            {
                return listaDetalleHerramienta;
            }
            else
            {
                try
                {
                    //bool guardar = false;
                    decimal contador = 1;
                    int escalarCuenta = 100000;//Sirve para escalar el contador
                    decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<CatalogoCuentasModelo> listaHijos = new ObservableCollection<CatalogoCuentasModelo>();
                    int ubicacion = 0;
                    foreach (CatalogoCuentasModelo itemDetalle in listaDetalleHerramienta)
                    {
                        //guardar = false;
                        if (itemDetalle.catidcc == null)
                        {
                            if (itemDetalle.ordencc != contador * escalarCuenta)
                            {
                                //guardar = true;
                                //Se asigna el orden a los principales
                                itemDetalle.ordencc = contador * escalarCuenta;
                                itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                            }
                            contador++;
                            /*if (guardar)
                            {
                                CatalogoCuentasModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }*/
                        }
                        else
                        {
                            //Se verifica que segun el tipo de procedimiento deba tener hijos o  no
                            if (!MetodosModelo.correccionOrdenCatogo(itemDetalle.nombreClaseCuenta))
                            {
                                if (itemDetalle.catidcc != null)
                                {
                                    //guardar = true;
                                    itemDetalle.catidcc = null;
                                    itemDetalle.ordenccPadre = null;
                                }
                                if (itemDetalle.ordencc != contador * escalarCuenta)
                                {
                                    //guardar = true;
                                    //Se asigna el orden a los principales
                                    itemDetalle.ordencc = contador * escalarCuenta;
                                    //itemDetalle.ordenccPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                    itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordencc);
                                }
                                contador++;
                                /*if (guardar)
                                {
                                    CatalogoCuentasModelo.UpdateModeloReodenar(itemDetalle);
                                    //Se modifica el orden para mantener una estandarizacion
                                }*/
                            }
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    foreach (CatalogoCuentasModelo item in listaDetalleHerramienta)
                    {
                        //Recorrer todos los  que tienen hijos
                        listaHijos = new ObservableCollection<CatalogoCuentasModelo>(listaDetalleHerramienta.Where(x => x.catidcc == item.idcc));
                        if (listaHijos.Count > 0)
                        {
                            //Hay hijos
                            contador = (decimal)item.ordencc;
                            factor = MetodosModelo.factorPadreCatalogo(item.nombreClaseCuenta);
                            int j = 1;
                            //guardar = false;
                            ubicacion = -1;
                            foreach (CatalogoCuentasModelo hijo in listaHijos)
                            {

                                //Es un hijo
                                ubicacion = listaDetalleHerramienta.IndexOf(hijo);
                                if (ubicacion != -1)
                                {
                                    if (listaDetalleHerramienta[ubicacion].ordencc != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        //guardar = true;
                                        listaDetalleHerramienta[ubicacion].ordenccPadre = contador;
                                        listaDetalleHerramienta[ubicacion].ordencc = Decimal.Add((decimal)contador, factor * j);
                                        //listaDetalleHerramienta[ubicacion].ordenccPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        listaDetalleHerramienta[ubicacion].ordenDhPresentacion = MetodosModelo.ordenConversion(listaDetalleHerramienta[ubicacion].ordencc);
                                        //CatalogoCuentasModelo.UpdateModeloReodenar(listaDetalleHerramienta[ubicacion]);
                                    }
                                    j++;
                                }
                            }
                        }
                    }
                    return new ObservableCollection < CatalogoCuentasModelo >(listaDetalleHerramienta.OrderBy(x => x.ordencc).ToList());
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return new ObservableCollection<CatalogoCuentasModelo>(listaDetalleHerramienta.OrderBy(x => x.ordencc).ToList());
                    throw;
                }
            }
        }
        #endregion

        public CatalogoCuentasModelo()
        {

            idcc = 0;
            idelementos = 0;
            idsc = 0;
            catidcc = null;
            idccuentas = 0;
            codigocc = string.Empty;
            descripcioncc = string.Empty;
            tiposaldocc = string.Empty;
            fechacreacioncc = MetodosModelo.homologacionFecha();
            estadocc = "A";
            idcc = 0;
            idelementos = 0;
            idsc = 0;
            guardadoBase = false;
            IsSelected = false;
            ordencc = 1;
            //listaSubCuentasMayorizacion = new ObservableCollection<CatalogoCuentasModelo>();
            //listaEntidadSeleccion = new ObservableCollection<CatalogoCuentasModelo>();
        }
        public CatalogoCuentasModelo(SistemaContableModelo sistemaContableModelo)
        {

            idcc = 0;
            idelementos = 0;
            idsc = sistemaContableModelo.idsc;
            catidcc = null;
            idccuentas = 0;
            codigocc = string.Empty;
            descripcioncc = string.Empty;
            tiposaldocc = string.Empty;
            fechacreacioncc = MetodosModelo.homologacionFecha();
            estadocc = "A";
            guardadoBase = false;
            IsSelected = false;
            ordencc = 1;
            //listaSubCuentasMayorizacion = new ObservableCollection<CatalogoCuentasModelo>();
            //listaEntidadSeleccion = new ObservableCollection<CatalogoCuentasModelo>();
        }

        public static bool validarConversionCatalogo(int idDscOrigen, int idDscDestino)
        {

            //Obtener los  registros  de ambos catalodos
            ObservableCollection<catalogocuenta> listaCatalogoDestino = CatalogoCuentasModelo.GetAllCapaDatosByidSC(idDscDestino);
            ObservableCollection<catalogocuenta> listaCatalogoOrigen = CatalogoCuentasModelo.GetAllCapaDatosByidSC(idDscOrigen);
            bool resultado = true;
            //Todo códido de listaCatalogoOrigen debe estar en listaCatalogoDestino, no  se verificara dependencia
            for (int i = 0; i < listaCatalogoOrigen.Count; i++)
            {
                //Verificando que el  codigo contable existe
                if (!(listaCatalogoDestino.Where(x => x.codigocc.Contains(listaCatalogoOrigen[i].codigocc)).Count() == 1))
                {
                    //El codigo contable no existe, no es factible la conversion, debe importar primero el catalogo
                    resultado = false;
                    i = listaCatalogoOrigen.Count;
                }
            }
            return resultado;
        }
        public CatalogoCuentasModelo(CatalogoCuentasModelo comun, CatalogoCuentasModelo origen)
        {
            idcc = 0;
            idelementos = origen.idelementos;
            idsc = comun.idsc;//Programa del que depende

            descripcioncc = origen.descripcioncc;
            fechacreacioncc = MetodosModelo.homologacionFecha();// DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            ordencc = (decimal)origen.ordencc;
            estadocc = "A";
            //fechasupervision = DateTime.Now.ToString("d", CultureInfo.CurrentCulture);
            //Se utiliza ipapelesdp para almacenar el id original, se usa idpadredp para vincular y establecer equivalencia

            catidcc = origen.idcc;
            guardadoBase = false;
            IsSelected = false;
        }

        #endregion
    }

}
