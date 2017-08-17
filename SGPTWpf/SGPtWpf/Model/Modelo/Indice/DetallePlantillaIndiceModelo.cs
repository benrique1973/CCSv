using CapaDatos;
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
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;


namespace SGPTWpf.Model.Modelo.Indice
{

    public class DetallePlantillaIndiceModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public static bool sincronizar { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Código")]
        public int iddpi //correlativo
        {
            get { return GetValue(() => iddpi); }
            set { SetValue(() => iddpi, value); }
        }



        public Nullable<int> idtei //tipo de elemento del indice
        {
            get { return GetValue(() => idtei); }
            set { SetValue(() => idtei, value); }
        }

        public Nullable<int> idpi //tipo de  plantilla del que depende
        {
            get { return GetValue(() => idpi); }
            set { SetValue(() => idpi, value); }
        }

        public Nullable<int> detiddpi //padre del sub-elemento del indice
        {
            get { return GetValue(() => detiddpi); }
            set { SetValue(() => detiddpi, value); }
        }

        [DisplayName("Descripción de procedimiento")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(200, ErrorMessage = "Excede de 200 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La descripción contiene símbolos inválidos")]
        public string descripciondpi
        {
            get { return GetValue(() => descripciondpi); }
            set { SetValue(() => descripciondpi, value); }
        }

        public string descripcionPresentacion
        {
            get { return GetValue(() => descripcionPresentacion); }
            set { SetValue(() => descripcionPresentacion, value); }
        }

        public Nullable<decimal> ordendpi
        {
            get { return GetValue(() => ordendpi); }
            set { SetValue(() => ordendpi, value); }
        }

        public string referenciadpi
        {
            get { return GetValue(() => referenciadpi); }
            set { SetValue(() => referenciadpi, value); }
        }

        public bool obligatoriodpi
        {
            get { return GetValue(() => obligatoriodpi); }
            set { SetValue(() => obligatoriodpi, value); }
        }

        public string estadodpi
        {
            get { return GetValue(() => estadodpi); }
            set { SetValue(() => estadodpi, value); }
        }

        public bool sistemadpi
        {
            get { return GetValue(() => sistemadpi); }
            set { SetValue(() => sistemadpi, value); }
        }

        public decimal? ordendpiPadre
        {
            get { return GetValue(() => ordendpiPadre); }
            set { SetValue(() => ordendpiPadre, value); }
        }
        public string descripcionDpiPadre
        {
            get { return GetValue(() => descripcionDpiPadre); }
            set { SetValue(() => descripcionDpiPadre, value); }
        }
        public virtual DetallePlantillaIndiceModelo detalleplantillaindicePadre
        {
            get { return GetValue(() => detalleplantillaindicePadre); }
            set { SetValue(() => detalleplantillaindicePadre, value); }
        }
        public virtual TipoCarpetaModelo tipoCarpetaModelo
        {
            get { return GetValue(() => tipoCarpetaModelo); }
            set { SetValue(() => tipoCarpetaModelo, value); }
        }
        public virtual TipoElementoIndiceModelo tipoElementoIndiceModelo
        {
            get { return GetValue(() => tipoElementoIndiceModelo); }
            set { SetValue(() => tipoElementoIndiceModelo, value); }
        }

        //Para distinguir entre registros ya con  id de la base y registros  pendientes de guardar
        public bool guardadoBase
        {
            get { return GetValue(() => guardadoBase); }
            set { SetValue(() => guardadoBase, value); }
        }

        public string ordenDhPresentacion
        {
            get { return GetValue(() => ordenDhPresentacion); }
            set { SetValue(() => ordenDhPresentacion, value); }
        }

        #endregion


        #region Propiedades para visualizacion
        public string descripciontc
        {
            get { return GetValue(() => descripciontc); }
            set { SetValue(() => descripciontc, value); }
        }
        public string descripciontei
        {
            get { return GetValue(() => descripciontei); }
            set { SetValue(() => descripciontei, value); }
        }
        public byte[] imagentet
        {
            get { return GetValue(() => imagentet); }
            set { SetValue(() => imagentet, value); }
        }

        public virtual ObservableCollection<string> listaDescripcionSeleccion
        {
            get { return GetValue(() => listaDescripcionSeleccion); }
            set { SetValue(() => listaDescripcionSeleccion, value); }
        }
        #endregion

        #region Public Model Methods


        public static bool Insert(DetallePlantillaIndiceModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.detalleplantillaindice', 'iddpi'), (SELECT MAX(iddpi) FROM sgpt.detalleplantillaindice) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new detalleplantillaindice
                        {
                            //
                            //iddpi = modelo.iddpi,
                            idtei = modelo.tipoElementoIndiceModelo.id,
                            idpi = modelo.idpi,
                            //detiddpi = modelo.detiddpi,
                            descripciondpi = modelo.descripciondpi,
                            ordendpi = modelo.ordendpi,
                            referenciadpi = modelo.referenciadpi,
                            obligatoriodpi = modelo.obligatoriodpi,
                            sistemadpi = false,
                            estadodpi = "A",
                        };
                        if (modelo.detalleplantillaindicePadre != null && modelo.detalleplantillaindicePadre.iddpi != 0)
                        {
                            tablaDestino.detiddpi = modelo.detalleplantillaindicePadre.iddpi;
                            modelo.detiddpi = modelo.detalleplantillaindicePadre.iddpi;
                            modelo.ordendpiPadre = modelo.detalleplantillaindicePadre.ordendpiPadre;
                            modelo.descripcionDpiPadre = modelo.detalleplantillaindicePadre.descripciondpi;
                        }
                        _context.detalleplantillaindices.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.iddpi = tablaDestino.iddpi;
                        modelo.idtei = modelo.tipoElementoIndiceModelo.id;
                        modelo.sistemadpi = tablaDestino.sistemadpi;
                        modelo.estadodpi = tablaDestino.estadodpi;
                        //Se reordena la lista
                        //Reordenar((int)modelo.idpi);
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar detalle de plantilla indice error \n " + e);
                    throw;
                }
                //catch (DbEntityValidationException e)
                //{
                //    //http://stackoverflow.com/questions/7795300/validation-failed-for-one-or-more-entities-see-entityvalidationerrors-propert
                //    foreach (var eve in e.EntityValidationErrors)
                //    {
                //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage);
                //        }
                //    }
                //    throw;
                //}
                return result;
            }
            else
            {
                return result;
            }
        }

        public static string Insert(DetallePlantillaIndiceModelo modelo)
        {
            string result = "";
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        var tablaDestino = new detalleplantillaindice
                        {
                            //
                            //iddpi = modelo.iddpi,
                            idtei = modelo.tipoElementoIndiceModelo.id,
                            idpi = modelo.idpi,
                            //detiddpi = modelo.detiddpi,
                            descripciondpi = modelo.descripciondpi,
                            ordendpi = modelo.ordendpi,
                            referenciadpi = modelo.referenciadpi,
                            obligatoriodpi = modelo.obligatoriodpi,
                            sistemadpi = false,
                            estadodpi = "A",
                        };
                        if (modelo.detiddpi != null || modelo.detiddpi != 0)
                        {
                            tablaDestino.detiddpi = modelo.detiddpi;
                        }
                        _context.detalleplantillaindices.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.iddpi = tablaDestino.iddpi;
                        modelo.sistemadpi = tablaDestino.sistemadpi;
                        modelo.estadodpi = tablaDestino.estadodpi;
                        result = tablaDestino.iddpi.ToString();
                    }
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception en insertar detalle de plantilla indice error \n " + e);
                    throw;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        //Devuelve el registro buscado con base al indice
        public static DetallePlantillaIndiceModelo Find(int id)
        {
            var entidadModelo = new DetallePlantillaIndiceModelo();
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    detalleplantillaindice entidad = _context.detalleplantillaindices.Find(id);
                    if (entidad == null)
                    {
                        entidadModelo = null;
                    }
                    else
                    {
                        //iddpi = entidad.iddpi,
                        entidadModelo.idtei = entidad.idtei;
                        entidadModelo.idpi = entidad.idpi;
                        entidadModelo.detiddpi = entidad.detiddpi;
                        entidadModelo.descripciondpi = entidad.descripciondpi;
                        entidadModelo.ordendpi = entidad.ordendpi;
                        entidadModelo.referenciadpi = entidad.referenciadpi;
                        entidadModelo.obligatoriodpi = entidad.obligatoriodpi;
                        entidadModelo.sistemadpi = entidad.sistemadpi;
                        entidadModelo.estadodpi = entidad.estadodpi;
                        entidadModelo.tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        };
                    }
                    return entidadModelo;
                }
            }
            else
            {
                return entidadModelo = null;
            }
        }

        //Devuelve el maximo del orden de un registro
        public static Nullable<decimal> FindOrden(int iddpi)
        {
            Nullable<decimal> ordenMaximo = 0;
            if (!(iddpi == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    ordenMaximo = _context.detalleplantillaindices.Where(x => x.iddpi == iddpi).Max(p => p.idpi);
                    return ordenMaximo + 1;
                }
            }
            else
            {
                return ordenMaximo;
            }
        }
        #region Metodos para string 

        public static void Delete(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("DELETE FROM sgpt.detalleplantillaindice WHERE iddpi={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();

                }
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static DetallePlantillaIndiceModelo Find(string id)
        {
            var entidadModelo = new DetallePlantillaIndiceModelo();
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {

                    if (string.IsNullOrEmpty(id))
                    {
                        return entidadModelo = null;
                    }
                    detalleplantillaindice entidad = _context.detalleplantillaindices.Find(id);
                    if (entidad == null)
                    {
                        return entidadModelo = null;
                    }
                    else
                    {
                        //iddpi = entidad.iddpi,
                        entidadModelo.idtei = entidad.idtei;
                        entidadModelo.idpi = entidad.idpi;
                        entidadModelo.detiddpi = entidad.detiddpi;
                        entidadModelo.descripciondpi = entidad.descripciondpi;
                        entidadModelo.ordendpi = entidad.ordendpi;
                        entidadModelo.referenciadpi = entidad.referenciadpi;
                        entidadModelo.obligatoriodpi = entidad.obligatoriodpi;
                        entidadModelo.sistemadpi = entidad.sistemadpi;
                        entidadModelo.estadodpi = entidad.estadodpi;
                        entidadModelo.tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        };
                    }
                }
                return entidadModelo;
            }
            else
            {
                return entidadModelo;
            }

        }

        public static bool FindPK(string id)
        {
            if (!(string.IsNullOrEmpty(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetallePlantillaIndiceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return true;
                    }
                    detalleplantillaindice entidad = _context.detalleplantillaindices.Find(id);
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
                    var modelo = new DetallePlantillaIndiceModelo();
                    detalleplantillaindice entidad = _context.detalleplantillaindices.Find(id);
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
        public static bool FindPK(string id, Boolean eliminado)
        {
            if (!(string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id)))
            {
                using (_context = new SGPTEntidades())
                {
                    var modelo = new DetallePlantillaIndiceModelo();
                    if (string.IsNullOrEmpty(id))
                    {
                        return false;
                    }
                    var entidad = _context.detalleplantillaindices
                            .Where(b => b.estadodpi == "B")
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
                    detalleplantillaindice entidad = _context.detalleplantillaindices.Find(id);
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
                    return nombre = _context.detalleplantillaindices.Find(id).descripciondpi;
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
                    return nombre = _context.detalleplantillaindices.Find(id).idpi;
                }
            }
            else
            {
                return nombre;
            }
        }
        //Para realizar busquedas de texto
        public static List<DetallePlantillaIndiceModelo> TransformLista(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                var lista = _context.detalleplantillaindices.Select(entidad =>
                new DetallePlantillaIndiceModelo
                {
                    iddpi = entidad.iddpi,
                    idtei = entidad.idtei,
                    idpi = entidad.idpi,
                    detiddpi = entidad.detiddpi,
                    descripciondpi = entidad.descripciondpi,
                    ordendpi = entidad.ordendpi,
                    referenciadpi = entidad.referenciadpi,
                    obligatoriodpi = entidad.obligatoriodpi,
                    sistemadpi = entidad.sistemadpi,
                    estadodpi = entidad.estadodpi,
                    guardadoBase = true,
                    tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                    {
                        id = entidad.tipoelementoindice.idtei,
                        descripcion = entidad.tipoelementoindice.descripciontei,
                        imagen = entidad.tipoelementoindice.imagentet,
                        sistema = entidad.tipoelementoindice.sistematei,
                        estado = entidad.tipoelementoindice.estadotei
                    }
                    //Lista filtrada de elementos que fueron eliminados

                }).OrderBy(o => o.ordendpi).Where(x => x.descripciondpi.ToUpper() == Texto).ToList();

                foreach (DetallePlantillaIndiceModelo item in lista)
                {
                    item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendpi);
                }
                return lista;
                //La ordena por el idPrograma notar la notacion
            }
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            if (!(id == 0))
            {
                using (_context = new SGPTEntidades())
                {
                    var entidad = _context.detalleplantillaindices
                            .Where(b => b.estadodpi == "B")
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

        public static void UpdateModelo(DetallePlantillaIndiceModelo modelo)
        {
            if (!(modelo == null))
            {
                using (_context = new SGPTEntidades())
                {
                    detalleplantillaindice entidad = _context.detalleplantillaindices.Find(modelo.iddpi);
                    if (entidad == null)
                    {
                        //Error no se encontro
                    }
                    else
                    {
                        entidad.idtei = modelo.tipoElementoIndiceModelo.id;
                        entidad.idpi = modelo.idpi;
                        //entidad.detiddpi = modelo.detiddpi;
                        entidad.descripciondpi = modelo.descripciondpi;
                        entidad.ordendpi = modelo.ordendpi;
                        entidad.referenciadpi = modelo.referenciadpi;
                        entidad.obligatoriodpi = modelo.obligatoriodpi;
                        entidad.sistemadpi = modelo.sistemadpi;
                        entidad.estadodpi = modelo.estadodpi;
                    }
                    if (modelo.detiddpi != null || modelo.detiddpi != 0)
                    {
                        entidad.detiddpi = modelo.detiddpi;
                    }
                    _context.Entry(entidad).State = EntityState.Modified;
                    _context.SaveChanges();
                    modelo.guardadoBase = true;
                }
            }
            else
            {
                //No regresa nada
            }
        }

        public static bool UpdateModelo(DetallePlantillaIndiceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        detalleplantillaindice entidad = _context.detalleplantillaindices.Find(modelo.iddpi);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddpi = modelo.iddpi; no puede cambiar
                            if (!(entidad.idtei == modelo.tipoElementoIndiceModelo.id))
                            {
                                cambio = true;
                                if (!(entidad.ordendpi == modelo.ordendpi))
                                {
                                    cambio = true;
                                }
                            }
                            //entidad.idtei = modelo.idtei; No puede cambiar
                            if (!(entidad.descripciondpi.ToUpper() == modelo.descripciondpi.ToUpper()))
                            {
                                cambio = true;
                            }
                            
                            if (!(entidad.obligatoriodpi == modelo.obligatoriodpi))
                            {
                                cambio = true;
                            }
                            if (modelo.detalleplantillaindicePadre == null)
                            {
                                if (entidad.detiddpi != null)
                                {
                                    cambio = true;
                                }
                            }
                            else
                            {
                                if (!(entidad.detiddpi == modelo.detalleplantillaindicePadre.iddpi))
                                {
                                    if (modelo.detalleplantillaindicePadre != null && modelo.detalleplantillaindicePadre.iddpi != 0)
                                    {
                                        cambio = true;
                                    }
                                    cambio = true;
                                    if (!(entidad.ordendpi == modelo.ordendpi))
                                    {
                                        entidad.ordendpi = modelo.ordendpi;
                                        cambio = true;
                                    }
                                }
                            }
                            //entidad.sistemadpi = modelo.sistemadpi; //No puede cambiar se establece al crearlo
                            if (cambio)
                            {
                                if (modelo.idtei == 1 )
                                {
                                    entidad.detiddpi = null;
                                }
                                else
                                {
                                    entidad.detiddpi = modelo.detiddpi; 
                                }
                                if (modelo.idtei == 1 || modelo.idtei == 2 || modelo.idtei == 3)
                                {
                                    entidad.obligatoriodpi = false;
                                }
                                else
                                {
                                    entidad.obligatoriodpi = modelo.obligatoriodpi;
                                }
                                entidad.idtei = modelo.tipoElementoIndiceModelo.id;
                                entidad.idpi = modelo.idpi;
                               
                                entidad.descripciondpi = modelo.descripciondpi;
                                entidad.ordendpi = modelo.ordendpi;
                                entidad.referenciadpi = modelo.referenciadpi;
                                
                                entidad.sistemadpi = modelo.sistemadpi;
                                entidad.estadodpi = modelo.estadodpi;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                modelo.guardadoBase = true;
                            }
                            //Reordenar((int)modelo.idpi);
                            return true;
                        }
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

        public static void UpdateModeloReodenar(DetallePlantillaIndiceModelo modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.detalleplantillaindice SET ordendpi = {0} WHERE iddpi={1};",modelo.ordendpi, modelo.iddpi);
                        commandString = MetodosModelo.ordenConversionToSQL(commandString);
                        _context.Database.ExecuteSqlCommand(commandString);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                    }
                }
                else
                {
                    //No regresa nada
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("exception en actualizar el orden: \n" + e);
                modelo.guardadoBase = false;
            }
        }

        public static bool UpdateModeloListado(DetallePlantillaIndiceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                //modelo.ordendpi = generaOrden(modelo);Se utilizará el del listado
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        detalleplantillaindice entidad = _context.detalleplantillaindices.Find(modelo.iddpi);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.iddpi = modelo.iddpi; no puede cambiar
                            if (!(entidad.idtei == modelo.tipoElementoIndiceModelo.id))
                            {
                                cambio = true;
                            }
                            //entidad.idtei = modelo.idtei; No puede cambiar
                            if (!(entidad.descripciondpi.ToUpper() == modelo.descripciondpi.ToUpper()))
                            {
                                entidad.descripciondpi = modelo.descripciondpi;
                                cambio = true;
                            }
                            if (!(entidad.ordendpi == modelo.ordendpi))
                            {
                                entidad.ordendpi = modelo.ordendpi;
                                cambio = true;
                            }
                            if (!(entidad.obligatoriodpi == modelo.obligatoriodpi))
                            {
                                entidad.obligatoriodpi = modelo.obligatoriodpi;
                                cambio = true;
                            }
                            if (modelo.detalleplantillaindicePadre == null)
                            {
                                if (entidad.detiddpi != null)
                                {
                                    entidad.detiddpi = null;
                                    cambio = true;
                                }

                            }
                            else
                            {
                                if (!(entidad.detiddpi == modelo.detalleplantillaindicePadre.iddpi))
                                {
                                        entidad.detiddpi = modelo.detalleplantillaindicePadre.iddpi;
                                        cambio = true;
                                }
                            }
                            //entidad.sistemadpi = modelo.sistemadpi; //No puede cambiar se establece al crearlo
                            //entidad.estadodpi = modelo.estadodpi; //No puede cambiar se cambia al crear o eliminar
                            if (cambio)
                            {
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                //modelo.guardadoBase = true;
                            }
                            return true;
                        }
                    }
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation(
                                  "Class: {0}, Property: {1}, Error: {2}",
                                  validationErrors.Entry.Entity.GetType().FullName,
                                  validationError.PropertyName,
                                  validationError.ErrorMessage);
                        }
                    }
                    return false;
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
                            string commandString = String.Format("UPDATE sgpt.detalleplantillaindice SET estadodpi = 'B' WHERE iddpi={0};", id);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();

                            //detalleplantillaindice entidad = _context.detalleplantillaindices.Find(id);
                            //entidad.estadodpi = "B";
                            //_context.Entry(entidad).State = EntityState.Modified;
                            //_context.SaveChanges();
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        //Captura de fallo en la insercion
                        if (e.Source != null)
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
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

        public static bool DeleteBorradoLogico(string id, Boolean actualizar)
        {
            bool result = false;
            if (!((string.IsNullOrEmpty(id)) || string.IsNullOrWhiteSpace(id)))
            {
                {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.detalleplantillaindice SET estadodpi = 'B' WHERE iddpi={0};", id);
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
                            MessageBox.Show("Exception en borrar registro : " + e.Message);
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
        public static bool Delete(int id)
        {
            if (id != 0)
            {
                using (_context = new SGPTEntidades())
                {
                    //Antes de remover es necesario reordenar y eliminar todas las dependientes
                    var listDetallePlantillaIndiceModelo = _context.detalleplantillaindices.Where(x => x.detiddpi == id).ToList(); ;
                    foreach (detalleplantillaindice item in listDetallePlantillaIndiceModelo)
                    {
                        _context.detalleplantillaindices.Remove(item);
                    }
                    string commandString = String.Format("DELETE FROM sgpt.detalleplantillaindice WHERE iddpi={0};", id);
                    commandString = MetodosModelo.ordenConversionToSQL(commandString);
                    _context.Database.ExecuteSqlCommand(commandString);
                    _context.SaveChanges();
                    //Se reodena antes de actualizar el listado
                    //Reordenar(id);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion
        public static bool Delete(int id, Boolean actualizar)
        {
            if (!(id == 0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.detalleplantillaindice WHERE iddpi={0};", id);
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
                    throw;
                }
            }
            else
            {
                return false;
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
                            string commandString = String.Format("DELETE FROM sgpt.detalleplantillaindice WHERE iddpi={0};", id);
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

        public static List<DetallePlantillaIndiceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var resultado = _context.detalleplantillaindices.Select(entidad =>
                     new DetallePlantillaIndiceModelo
                     {
                         iddpi = entidad.iddpi,
                         idtei = entidad.idtei,
                         idpi = entidad.idpi,
                         detiddpi = entidad.detiddpi,
                         descripciondpi = entidad.descripciondpi,
                         ordendpi = entidad.ordendpi,
                         referenciadpi = entidad.referenciadpi,
                         obligatoriodpi = entidad.obligatoriodpi,
                         sistemadpi = entidad.sistemadpi,
                         estadodpi = entidad.estadodpi,
                         tipoElementoIndiceModelo = new TipoElementoIndiceModelo

                         {
                             id = entidad.tipoelementoindice.idtei,
                             descripcion = entidad.tipoelementoindice.descripciontei,
                             imagen = entidad.tipoelementoindice.imagentet,
                             sistema = entidad.tipoelementoindice.sistematei,
                             estado = entidad.tipoelementoindice.estadotei
                         }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendpi).Where(x => x.estadodpi == "A").ToList();
                    foreach (DetallePlantillaIndiceModelo item in resultado)
                    {
                        if (item.detiddpi != null)
                        {
                            for (int i = 0; i < resultado.Count; i++)
                            {
                                if (resultado[i].iddpi == item.detiddpi)
                                {
                                    item.detalleplantillaindicePadre = resultado[i];
                                    item.ordendpiPadre =(decimal) resultado[i].ordendpi;
                                    item.descripcionDpiPadre = resultado[i].descripciondpi;
                                    i = resultado.Count;
                                }
                            }
                        }
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendpi);
                    }
                    return resultado.ToList();
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

        public static List<DetallePlantillaIndiceModelo> GetAll(int? idpi)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var listaInicial = _context.detalleplantillaindices.Select(entidad =>
                         new DetallePlantillaIndiceModelo
                         {
                             iddpi = entidad.iddpi,
                             idtei = entidad.idtei,
                             idpi = entidad.idpi,
                             detiddpi = entidad.detiddpi,
                             descripciondpi = entidad.descripciondpi,
                             ordendpi = entidad.ordendpi,
                             referenciadpi = entidad.referenciadpi,
                             obligatoriodpi = entidad.obligatoriodpi,
                             sistemadpi = entidad.sistemadpi,
                             estadodpi = entidad.estadodpi,
                             guardadoBase = true,
                             tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                             {
                                 id = entidad.tipoelementoindice.idtei,
                                 descripcion = entidad.tipoelementoindice.descripciontei,
                                 imagen = entidad.tipoelementoindice.imagentet,
                                 sistema = entidad.tipoelementoindice.sistematei,
                                 estado = entidad.tipoelementoindice.estadotei
                             },
                             descripciontei = entidad.tipoelementoindice.descripciontei,
                             imagentet = entidad.tipoelementoindice.imagentet
                             //Lista filtrada de elementos que fueron eliminados
                         }).Where(x => x.estadodpi == "A" && x.idpi==idpi).OrderBy(o => o.ordendpi).ToList();
                    List<DetallePlantillaIndiceModelo> lista = RegeneraOrdenSubRegistros(listaInicial);

                    return lista.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible al elaboracion de lista \n" + e);
                    DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                    registroAdicional.iddpi = 0;
                    registroAdicional.descripciondpi = "Error de comunicación";//Se adiciona para facilitar accesibilidad al usuario
                    var lista = new ObservableCollection<DetallePlantillaIndiceModelo>();
                    lista.Add(registroAdicional);
                    return lista.ToList();
            }
        }

        public static List<DetallePlantillaIndiceModelo> GetAllPublicacion(int? idpi)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.detalleplantillaindices.ToList().Where(x => x.estadodpi == "A").Where(x => x.idpi == idpi).Select(entidad => new DetallePlantillaIndiceModelo
                    {
                        iddpi = entidad.iddpi,
                        idtei = entidad.idtei,
                        idpi = entidad.idpi,
                        detiddpi = entidad.detiddpi,
                        descripciondpi = entidad.descripciondpi,
                        ordendpi = entidad.ordendpi,
                        referenciadpi = entidad.referenciadpi,
                        obligatoriodpi = entidad.obligatoriodpi,
                        sistemadpi = entidad.sistemadpi,
                        estadodpi = entidad.estadodpi,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        },
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        imagentet = entidad.tipoelementoindice.imagentet
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendpi);
                    var resultado = DateQuery.ToList();
                    foreach (DetallePlantillaIndiceModelo item in resultado)
                    {
                        item.guardadoBase = true;
                        if (item.detiddpi != null)
                        {
                            for (int i = 0; i < resultado.Count; i++)
                            {
                                if (resultado[i].iddpi == item.detiddpi)
                                {
                                    item.detalleplantillaindicePadre = resultado[i];
                                    item.ordendpiPadre =(decimal) resultado[i].ordendpi;
                                    item.descripcionDpiPadre = resultado[i].descripciondpi;
                                    if ((int)item.ordendpi == item.ordendpi)
                                    {
                                        item.descripciondpi="  " + item.descripciondpi;
                                    }
                                    else
                                    {
                                        if ((int)(item.ordendpi * 10) == item.ordendpi * 10)
                                        {
                                            item.descripciondpi = "    " + item.descripciondpi;
                                        }
                                        else
                                        {
                                            if ((int)(item.ordendpi * 100) == item.ordendpi * 100)
                                            {
                                                item.descripciondpi = "      " + item.descripciondpi;
                                            }
                                            else
                                            {
                                                item.descripciondpi = "        " + item.descripciondpi;
                                            }
                                        }
                                    }

                                    i = resultado.Count;
                                }
                            }
                        }
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendpi);
                    }
                    return resultado.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible al elaboracion de lista " + e.Message + " fuente " + e.Source);
                DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                registroAdicional.iddpi = 0;
                registroAdicional.descripciondpi = "Error de comunicación";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<DetallePlantillaIndiceModelo>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<detalleplantillaindice> GetAllCapaDatos(int? idHerramienta)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.detalleplantillaindice WHERE idpi={0} AND estadodpi = 'A' ORDER BY ordendpi;", idHerramienta);

                    var lista = _context.detalleplantillaindices.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<detalleplantillaindice> temporal = new ObservableCollection<detalleplantillaindice>(lista);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de lista detalle herramientas \n" + e);
                detalleplantillaindice registroAdicional = new detalleplantillaindice();
                registroAdicional.iddpi = 0;
                registroAdicional.descripciondpi = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<detalleplantillaindice>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }


        //Filtra y elimina el registro detallado para efectos de seleccion
        public static List<DetallePlantillaIndiceModelo> GetAll(int? idpi, int? iddpi)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.detalleplantillaindices.ToList().Where(x => x.estadodpi == "A" && x.idpi == idpi && x.iddpi != iddpi).Select(entidad => new DetallePlantillaIndiceModelo
                    {
                        iddpi = entidad.iddpi,
                        idtei = entidad.idtei,
                        idpi = entidad.idpi,
                        detiddpi = entidad.detiddpi,
                        descripciondpi = entidad.descripciondpi,
                        ordendpi = entidad.ordendpi,
                        referenciadpi = entidad.referenciadpi,
                        obligatoriodpi = entidad.obligatoriodpi,
                        sistemadpi = entidad.sistemadpi,
                        estadodpi = entidad.estadodpi,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        },
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        imagentet = entidad.tipoelementoindice.imagentet
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendpi);
                    var resultado = DateQuery.ToList();
                    foreach (DetallePlantillaIndiceModelo item in resultado)
                    {
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendpi);
                        item.descripciondpi = item.ordenDhPresentacion+ "-" + item.descripciondpi;
                        if (item.detiddpi != null)
                        {
                            for (int i = 0; i < resultado.Count; i++)
                            {
                                if (resultado[i].iddpi == item.detiddpi)
                                {
                                    item.detalleplantillaindicePadre = resultado[i];
                                    item.ordendpiPadre =(decimal) resultado[i].ordendpi;
                                    item.descripcionDpiPadre = resultado[i].descripciondpi;
                                    i = resultado.Count;
                                }
                            }
                        }

                    }
                    //Agregando registro para efectos de lista
                    DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                    registroAdicional.descripciondpi = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                    registroAdicional.iddpi = 0;//Se adiciona para facilitar accesibilidad al usuario
                    registroAdicional.ordendpi = 0;
                    registroAdicional.descripciontei = "Ninguno";
                    resultado.Insert(0, registroAdicional);
                    return resultado.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                MessageBox.Show("No fue posible al elaboracion de lista " + e.Message + " fuente " + e.Source);
                DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                registroAdicional.iddpi = 0;
                registroAdicional.descripciontei = "Ninguno";
                registroAdicional.descripciondpi = "Error de comunicación";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<DetallePlantillaIndiceModelo>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<DetallePlantillaIndiceModelo> GetAllSubregistros(int? idpi, int? iddpi)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.detalleplantillaindices.ToList().Where(x => x.estadodpi == "A").Where(x => x.idpi == idpi ).Where(x => x.detiddpi == iddpi).Select(entidad => new DetallePlantillaIndiceModelo
                    {
                        iddpi = entidad.iddpi,
                        idtei = entidad.idtei,
                        idpi = entidad.idpi,
                        detiddpi = entidad.detiddpi,
                        descripciondpi = entidad.descripciondpi,
                        ordendpi = entidad.ordendpi,
                        referenciadpi = entidad.referenciadpi,
                        obligatoriodpi = entidad.obligatoriodpi,
                        sistemadpi = entidad.sistemadpi,
                        estadodpi = entidad.estadodpi,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        },
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        imagentet = entidad.tipoelementoindice.imagentet
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendpi);
                    var resultado = DateQuery.ToList();
                    foreach (DetallePlantillaIndiceModelo item in resultado)
                    {
                        if (item.detiddpi != null)
                        {
                            for (int i = 0; i < resultado.Count; i++)
                            {
                                if (resultado[i].iddpi == item.detiddpi)
                                {
                                    item.detalleplantillaindicePadre = resultado[i];
                                    item.ordendpiPadre =(decimal) resultado[i].ordendpi;
                                    item.descripcionDpiPadre = resultado[i].descripciondpi;
                                    i = resultado.Count;
                                }
                            }
                        }
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendpi);
                    }
                    return resultado.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible al elaboracion de lista " + e.Message + " fuente " + e.Source);
                DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                registroAdicional.iddpi = 0;
                registroAdicional.descripciondpi = "Error de comunicación";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<DetallePlantillaIndiceModelo>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<DetallePlantillaIndiceModelo> GetAllRegistros(int? idpi, int? iddpi)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.detalleplantillaindices.ToList().Where(x => x.estadodpi == "A").Where(x => x.idpi == idpi).Where(x => x.detiddpi == null).Select(entidad => new DetallePlantillaIndiceModelo
                    {
                        iddpi = entidad.iddpi,
                        idtei = entidad.idtei,
                        idpi = entidad.idpi,
                        detiddpi = entidad.detiddpi,
                        descripciondpi = entidad.descripciondpi,
                        ordendpi = entidad.ordendpi,
                        referenciadpi = entidad.referenciadpi,
                        obligatoriodpi = entidad.obligatoriodpi,
                        sistemadpi = entidad.sistemadpi,
                        estadodpi = entidad.estadodpi,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        },
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        imagentet = entidad.tipoelementoindice.imagentet
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordendpi);
                    var resultado = DateQuery.ToList();
                    foreach (DetallePlantillaIndiceModelo item in resultado)
                    {
                        if (item.detiddpi != null)
                        {
                            for (int i = 0; i < resultado.Count; i++)
                            {
                                if (resultado[i].iddpi == item.detiddpi)
                                {
                                    item.detalleplantillaindicePadre = resultado[i];
                                    item.ordendpiPadre =(decimal) resultado[i].ordendpi;
                                    item.descripcionDpiPadre = resultado[i].descripciondpi;
                                    i = resultado.Count;
                                }
                            }
                        }
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordendpi);
                    }
                    return resultado.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible al elaboracion de lista " + e.Message + " fuente " + e.Source);
                DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                registroAdicional.iddpi = 0;
                registroAdicional.descripciondpi = "Error de comunicación";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<DetallePlantillaIndiceModelo>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }
        public static List<DetallePlantillaIndiceModelo> GetAll(int? idtei, int? iddpiSeleccionado, bool seleccion)
        {
            {
                var lista = GetAll(idtei, iddpiSeleccionado);
                DetallePlantillaIndiceModelo registroAdicional = new DetallePlantillaIndiceModelo();
                registroAdicional.iddpi = 0;
                registroAdicional.descripciondpi = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                lista.Add(registroAdicional);
                return lista.OrderBy(o => o.ordendpi).ToList();
            }//Transformacion necesaria por la fecha 
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
                    elementos = _context.detalleplantillaindices.Where(x => x.idpi == id && x.estadodpi == "A" && x.detiddpi == null).Count();
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
                    elementos = _context.detalleplantillaindices.Where(x => x.detiddpi == id && x.estadodpi == "A").Count();
                    return elementos;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en consultar la cantidad de registros \n " + e);
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
                    elementos = _context.detalleplantillaindices.Where(x => x.estadodpi == "A").Count();
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

        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToLower();
                using (_context = new SGPTEntidades())
                {
                    var entidad = (from p in _context.detalleplantillaindices
                                   where p.descripciondpi.ToLower().Equals(busqueda)
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
        public static DetallePlantillaIndiceModelo Clear(DetallePlantillaIndiceModelo modelo)
        {
            modelo.iddpi = 0;
            modelo.idtei = 0;
            modelo.idpi = 0;
            modelo.detiddpi = 0;
            modelo.descripciondpi = "";
            modelo.ordendpi = 1;
            modelo.referenciadpi = "";
            modelo.obligatoriodpi = false;
            modelo.sistemadpi = false;
            modelo.estadodpi = "A";
            return new DetallePlantillaIndiceModelo();
        }
        public DetallePlantillaIndiceModelo()
        {
            iddpi = 0;
            //idtc = 0;
            //idtei = 0;
            //idpi = 0;
            //detiddpi = 0;
            descripciondpi = "";
            ordendpi = 1;
            referenciadpi = "";
            obligatoriodpi = false;
            sistemadpi = false;
            estadodpi = "A";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public static int FindTextoReturnId(string texto)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleplantillaindices.Where(x => x.descripciondpi.ToUpper() == busqueda && x.estadodpi == "A").Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }
        public static int FindTextoReturnId(string texto, int? iddpi)
        {
            int elementos = 0;
            if (!((string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))))
            {
                string busqueda = texto.ToUpper();
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.detalleplantillaindices.Where(x => x.descripciondpi.ToUpper() == busqueda && x.estadodpi == "A" && x.iddpi == iddpi).Count();
                    return elementos;
                }
            }
            else
            {
                return 0;
            }
        }



        #endregion


        #region generacion del orden

        public static List<DetallePlantillaIndiceModelo> RegeneraOrdenSubRegistros(List<DetallePlantillaIndiceModelo> listaDetalleHerramienta)
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
                    decimal contador = 10;
                    //decimal factor = 0;//Para cambiar el orden
                    ObservableCollection<DetallePlantillaIndiceModelo> listaHijos = new ObservableCollection<DetallePlantillaIndiceModelo>();
                    ObservableCollection<DetallePlantillaIndiceModelo> listaPadres = new ObservableCollection<DetallePlantillaIndiceModelo>();
                    ObservableCollection<DetallePlantillaIndiceModelo> listaDetalle = new ObservableCollection<DetallePlantillaIndiceModelo>();

                    foreach (DetallePlantillaIndiceModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.detiddpi == null)
                        {
                            if (itemDetalle.ordendpi != contador)
                            {
                                guardar = true;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordendpi = contador;
                            //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendpi);
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordendpi);
                            itemDetalle.descripcionPresentacion = itemDetalle.descripciondpi;
                            if (guardar)
                            {
                                DetallePlantillaIndiceModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                            listaDetalle.Add(itemDetalle);
                            if (listaDetalleHerramienta.Where(x => x.detiddpi == itemDetalle.iddpi).Count() > 0)
                            {
                                listaPadres.Add(itemDetalle);
                            }
                            contador=contador+10;
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    bool salir = false;
                    decimal factor =(decimal) 0.1;
                    string desplazar = "  ";
                    int ciclos = listaPadres.Count();

                    do
                    {
                        if (listaPadres.Count > 0)
                        {
                            if (ciclos == 0)
                            {
                                factor = factor / 10;
                                desplazar = desplazar + desplazar;
                                ciclos = listaPadres.Count();
                            }
                                salir = true;//No sale volvera a recorrerla
                                             //Recorrer todos los  que tienen hijos
                                listaHijos = new ObservableCollection<DetallePlantillaIndiceModelo>(listaDetalleHerramienta.Where(x => x.detiddpi == listaPadres[0].iddpi));
                                if (listaHijos.Count > 0)
                                {
                                    //Hay hijos
                                    contador = (decimal)listaPadres[0].ordendpi;
                                    //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                                    int j = 1;
                                    guardar = false;
                                    foreach (DetallePlantillaIndiceModelo hijo in listaHijos)
                                    {
                                        //Es un hijo
                                            if (hijo.ordendpi != Decimal.Add((decimal)contador, factor * j))
                                            {
                                                guardar = true;
                                            }
                                            hijo.ordendpiPadre = contador;
                                            hijo.ordendpi = Decimal.Add((decimal)contador, factor * j);
                                            hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordendpi);
                                            hijo.descripcionPresentacion = desplazar + hijo.descripciondpi;

                                            hijo.detalleplantillaindicePadre = listaPadres[0]; ;
                                            hijo.descripcionDpiPadre = hijo.detalleplantillaindicePadre.descripciondpi;

                                            j++;
                                            if (guardar)
                                            {
                                                DetallePlantillaIndiceModelo.UpdateModeloReodenar(hijo);
                                                //Se modifica el orden para mantener una estandarizacion
                                            }
                                            //Agregar a la lista
                                            listaDetalle.Add(hijo);
                                            //Verificar que no tenga hijos
                                            if (listaDetalleHerramienta.Where(x => x.detiddpi == hijo.iddpi).Count() > 0)
                                            {
                                                listaPadres.Add(hijo);
                                            }
                                   }
                                }
                            listaPadres.Remove(listaPadres[0]);
                            ciclos--;
                            }
                        else
                        {
                            salir = false;//Termino el proceso, salir
                        }

                    } while (salir);
                    return listaDetalle.OrderBy(x => x.ordendpi).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta.OrderBy(x => x.ordendpi).ToList();
                    throw;
                }
            }
        }

        #endregion

    }
}
