using CapaDatos;
using SGPTWpf.SGPtWpf.Support.Validaciones.Atributos;
using SGPTWpf.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Windows;
using SGPTWpf.Model;
using System.Collections.ObjectModel;
using SGPTWpf.SGPtWpf.Support.Validaciones.Metodos;
using System.Data.Entity;
using SGPTWpf.Model.Modelo.Encargos;
using SGPTWpf.Model.Modelo.programas;

namespace SGPTWpf.SGPtWpf.Model.Modelo.Encargos.Planificacion
{
    public class IndiceModelo : UIBase
    {
        #region Model Attributes

        private static SGPTEntidades _context;

        #endregion

        #region Model Properties

        public int idCorrelativo
        {
            get { return GetValue(() => idCorrelativo); }
            set { SetValue(() => idCorrelativo, value); }
        }

        public static bool sincronizar { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id del índice")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idindice
        {
            get { return GetValue(() => idindice); }
            set { SetValue(() => idindice, value); }
        }

        public Nullable<int> idmr
        {
            get { return GetValue(() => idmr); }
            set { SetValue(() => idmr, value); }
        }

        public Nullable<int> idpapeles
        {
            get { return GetValue(() => idpapeles); }
            set { SetValue(() => idpapeles, value); }
        }

        public Nullable<int> idmaf
        {
            get { return GetValue(() => idmaf); }
            set { SetValue(() => idmaf, value); }
        }

        public Nullable<int> idencargo
        {
            get { return GetValue(() => idencargo); }
            set { SetValue(() => idencargo, value); }
        }

        public Nullable<int> idprograma
        {
            get { return GetValue(() => idprograma); }
            set { SetValue(() => idprograma, value); }
        }

        public Nullable<int> indidindice
        {
            get { return GetValue(() => indidindice); }
            set { SetValue(() => indidindice, value); }
        }

        public Nullable<int> idteiindice
        {
            get { return GetValue(() => idteiindice); }
            set { SetValue(() => idteiindice, value); }
        }


        [DisplayName("Descripcion de indice")]
        [Required(ErrorMessage = "Dato requerido")]
        [MaxLength(200, ErrorMessage = "Excede de 200 caracteres permitidos")]
        [ExcludeChar("^Ç", ErrorMessage = "La razón social contiene símbolos inválidos")]
        public string descripcionindice
        {
            get { return GetValue(() => descripcionindice); }
            set { SetValue(() => descripcionindice, value); }
        }

        
        public string descripcionPresentacion
        {
            get { return GetValue(() => descripcionPresentacion); }
            set { SetValue(() => descripcionPresentacion, value); }
        }

        public string descripcionPresentacionPadre
        {
            get { return GetValue(() => descripcionPresentacionPadre); }
            set { SetValue(() => descripcionPresentacionPadre, value); }
        }

        public decimal ordenindice
        {
            get { return GetValue(() => ordenindice); }
            set { SetValue(() => ordenindice, value); }
        }

 
        public decimal ordenindicePadre
        {
            get { return GetValue(() => ordenindicePadre); }
            set { SetValue(() => ordenindicePadre, value); }
        }
        public string referenciaindice
        {
            get { return GetValue(() => referenciaindice); }
            set { SetValue(() => referenciaindice, value); }
        }

        public bool obligatorioindice
        {
            get { return GetValue(() => obligatorioindice); }
            set { SetValue(() => obligatorioindice, value); }
        }

        public bool sistemaindice
        {
            get { return GetValue(() => sistemaindice); }
            set { SetValue(() => sistemaindice, value); }
        }

        public string estadoindice
        {
            get { return GetValue(() => estadoindice); }
            set { SetValue(() => estadoindice, value); }
        }

        public Nullable<int> idtcindice
        {
            get { return GetValue(() => idtcindice); }
            set { SetValue(() => idtcindice, value); }
        }

        public Nullable<int> idgenericoindice //Id para todo tipo de variables
        {
            get { return GetValue(() => idgenericoindice); }
            set { SetValue(() => idgenericoindice, value); }
        }

        public string tablaindice //Nombre de  tabla a que corresponde  el id generico
        {
            get { return GetValue(() => tablaindice); }
            set { SetValue(() => tablaindice, value); }
        }
        // Entidades relacionadas

        /* public virtual MatrizAnalisisFinancieroModelo matrizanalisisfinanciero
         {
             get { return GetValue(() => actividadModelo); }
             set { SetValue(() => actividadModelo, value); }
         }*/


        #endregion

        #region Propiedades para visualizacion
        public byte[] imagentet
        {
            get { return GetValue(() => imagentet); }
            set { SetValue(() => imagentet, value); }
        }

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
        public string ordenDhPresentacion
        {
            get { return GetValue(() => ordenDhPresentacion); }
            set { SetValue(() => ordenDhPresentacion, value); }
        }
        public virtual IndiceModelo indiceModeloPadre
        {
            get { return GetValue(() => indiceModeloPadre); }
            set { SetValue(() => indiceModeloPadre, value); }
        }
        public virtual TipoElementoIndiceModelo tipoElementoIndiceModelo
        {
            get { return GetValue(() => tipoElementoIndiceModelo); }
            set { SetValue(() => tipoElementoIndiceModelo, value); }
        }

        public virtual ObservableCollection<string> listaDescripcionSeleccion
        {
            get { return GetValue(() => listaDescripcionSeleccion); }
            set { SetValue(() => listaDescripcionSeleccion, value); }
        }
        public string descripciontei
        {
            get { return GetValue(() => descripciontei); }
            set { SetValue(() => descripciontei, value); }
        }
        public string referenciamr
        {
            get { return GetValue(() => referenciamr); }
            set { SetValue(() => referenciamr, value); }
        }

        #endregion

        #region Public Model Methods


        public static bool Insert(IndiceModelo modelo)
        {
            throw new NotImplementedException();
        }

        public static bool Insert(IndiceModelo modelo, Boolean insertar)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.indices', 'idindice'), (SELECT MAX(idindice) FROM sgpt.indices) + 1);");
                            sincronizar = true;
                        }
                        var tablaDestino = new index
                        {
                            //
                            //idindice =(int) modelo.idindice,
                            //idmr = modelo.idmr,
                            //idpapeles = modelo.idpapeles,
                            //idmaf = modelo.idmaf,
                            idencargo = modelo.idencargo,
                            //idprograma = modelo.idprograma,
                            //indidindice = modelo.indidindice,
                            descripcionindice = modelo.descripcionindice,
                            ordenindice = modelo.ordenindice,
                            //referenciaindice = modelo.referenciaindice,
                            obligatorioindice = modelo.obligatorioindice,
                            sistemaindice = modelo.sistemaindice,
                            estadoindice = modelo.estadoindice,
                            idteiindice=modelo.idteiindice,
                            idtcindice=modelo.idtcindice,
                        };
                        if (modelo.indiceModeloPadre != null && modelo.indiceModeloPadre.indidindice != 0)
                        {
                            tablaDestino.indidindice = modelo.indiceModeloPadre.idindice;
                            modelo.indidindice = modelo.indiceModeloPadre.idindice;
                            modelo.ordenindicePadre = modelo.indiceModeloPadre.ordenindice;
                            modelo.descripcionPresentacionPadre = modelo.indiceModeloPadre.descripcionindice;
                        }
                        _context.indices.Add(tablaDestino);
                        _context.SaveChanges();
                        modelo.guardadoBase = true;
                        modelo.idindice = tablaDestino.idindice;
                        modelo.idteiindice = modelo.tipoElementoIndiceModelo.id;
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
                    //throw;
                    return false;
                }
                return result;
            }
            else
            {
                return result;
            }
        }

        //Devuelve el registro buscado con base al indice
        public static IndiceModelo Find(int id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        public static IndiceModelo Find(string id)
        {
            throw new NotImplementedException();
        }

        public static bool FindPK(string id)
        {
            throw new NotImplementedException();
        }

        //Devuelve un booleano de éxito en caso de realizarse la eliminacion

        #endregion

        public static bool FindPK(int id)
        {
            throw new NotImplementedException();
        }
        //Para realizar busquedas de texto
        public static List<IndiceModelo> GetAllPkContenido(string texto)
        {

            using (_context = new SGPTEntidades())
            {
                string Texto = texto.ToUpper();
                return _context.indices.Select(entidad =>
                new IndiceModelo
                {
                    idindice = entidad.idindice,
                    idmr = entidad.idmr,
                    idpapeles = entidad.idpapeles,
                    idmaf = entidad.idmaf,
                    idencargo = entidad.idencargo,
                    idprograma = entidad.idprograma,
                    indidindice = entidad.indidindice,
                    descripcionindice = entidad.descripcionindice,
                    ordenindice = entidad.ordenindice,
                    referenciaindice = entidad.referenciaindice,
                    obligatorioindice = entidad.obligatorioindice,
                    sistemaindice = entidad.sistemaindice,
                    estadoindice = entidad.estadoindice,
                    imagentet = entidad.tipoelementoindice.imagentet,
                    descripciontei=entidad.tipoelementoindice.descripciontei,
                    IsSelected = false,
                    tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                    {
                        id = entidad.tipoelementoindice.idtei,
                        descripcion = entidad.tipoelementoindice.descripciontei,
                        imagen = entidad.tipoelementoindice.imagentet,
                        sistema = entidad.tipoelementoindice.sistematei,
                        estado = entidad.tipoelementoindice.estadotei
                    }
                    //Lista filtrada de elementos que fueron eliminados
                }).OrderBy(o => o.ordenindice).Where(x => x.estadoindice == "A").ToList();
                //La ordena por el idPrograma notar la notacion
            }
        }

        //Verifica si el registro existe dentro de los eliminados
        public static bool FindPK(int id, Boolean eliminado)
        {
            throw new NotImplementedException();
        }


        public static bool UpdateModelo(IndiceModelo modelo, Boolean actualizar)
        {
            if (!(modelo == null))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        index entidad = _context.indices.Find(modelo.idindice);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            //entidad.idindice = modelo.idindice; no puede cambiar
                            if (!(entidad.idteiindice == modelo.tipoElementoIndiceModelo.id))
                            {
                                cambio = true;
                                if (!(entidad.ordenindice == modelo.ordenindice))
                                {
                                    cambio = true;
                                }
                            }
                            //entidad.idteiindice = modelo.idteiindice; No puede cambiar
                            if (!(entidad.descripcionindice.ToUpper() == modelo.descripcionindice.ToUpper()))
                            {
                                cambio = true;
                            }

                            if (!(entidad.obligatorioindice == modelo.obligatorioindice))
                            {
                                cambio = true;
                            }
                            if (modelo.indiceModeloPadre == null)
                            {
                                if (entidad.indidindice != null)
                                {
                                    cambio = true;
                                }
                            }
                            else
                            {
                                if (!(entidad.indidindice == modelo.indiceModeloPadre.idindice))
                                {
                                    if (modelo.indiceModeloPadre != null && modelo.indiceModeloPadre.idindice != 0)
                                    {
                                        cambio = true;
                                    }
                                    cambio = true;
                                    if (!(entidad.ordenindice == modelo.ordenindice))
                                    {
                                        entidad.ordenindice = modelo.ordenindice;
                                        cambio = true;
                                    }
                                }
                            }
                            //entidad.sistemadpi = modelo.sistemadpi; //No puede cambiar se establece al crearlo
                            if (cambio)
                            {
                                if (modelo.idteiindice == 1)
                                {
                                    entidad.indidindice = null;
                                }
                                else
                                {
                                    entidad.indidindice = modelo.indidindice;
                                }
                                if (modelo.idteiindice == 1 || modelo.idteiindice == 2 || modelo.idteiindice == 3)
                                {
                                    entidad.obligatorioindice = false;
                                }
                                else
                                {
                                    entidad.obligatorioindice = modelo.obligatorioindice;
                                }
                                entidad.idteiindice = modelo.tipoElementoIndiceModelo.id;
                                entidad.idindice =(int) modelo.idindice;

                                entidad.descripcionindice = modelo.descripcionindice;
                                entidad.ordenindice = modelo.ordenindice;
                                entidad.referenciaindice = modelo.referenciaindice;

                                entidad.sistemaindice = modelo.sistemaindice;
                                entidad.estadoindice = modelo.estadoindice;
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                                modelo.guardadoBase = true;
                            }
                            //Reordenar((int)modelo.idindice);
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

        public static bool UpdateModeloReferencia(IndiceModelo modelo, UniversalPTModelo papel)
        {
            if ((modelo != null && papel!=null && modelo.idindice!=null  && modelo.idindice!=0 && papel.idUpt!=0))
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        bool cambio = false;
                        index entidad = _context.indices.Find(modelo.idindice);
                        if (entidad == null)
                        {
                            return false;
                        }
                        else
                        {
                            switch (papel.tablaUpt)
                            {
                                case "MATRIZRIESGOS": //id 1
                                    if (entidad.idmr != papel.idOrigenUpt || entidad.referenciaindice != papel.referenciaTpt)
                                    {
                                        cambio = true;
                                    }
                                    entidad.idmr = papel.idOrigenUpt;
                                    break;
                                case "PAPELES"://2
                                    if (entidad.idpapeles != papel.idOrigenUpt || entidad.referenciaindice != papel.referenciaTpt)
                                    {
                                        cambio = true;
                                    }
                                    entidad.idpapeles = papel.idOrigenUpt;
                                    break;
                                case "MATRIZANALISISFINANCIERO"://3
                                    if (entidad.idmaf != papel.idOrigenUpt || entidad.referenciaindice != papel.referenciaTpt)
                                    {
                                        cambio = true;
                                    }
                                    entidad.idmaf = papel.idOrigenUpt;
                                    break;
                                case "PROGRAMAS"://4
                                    if (entidad.idprograma != papel.idOrigenUpt || entidad.referenciaindice != papel.referenciaTpt)
                                    {
                                        cambio = true;
                                    }
                                    entidad.idprograma = papel.idOrigenUpt;
                                    break;
                                case "REPOSITORIO"://5
                                    if (entidad.idgenericoindice != papel.idOrigenUpt || entidad.referenciaindice != papel.referenciaTpt)
                                    {
                                        cambio = true;
                                    }
                                    entidad.idgenericoindice = papel.idOrigenUpt;
                                    entidad.tablaindice = papel.tablaUpt;
                                    break;
                                case "CEDULAS"://6
                                    if (entidad.idgenericoindice != papel.idOrigenUpt || entidad.referenciaindice != papel.referenciaTpt)
                                    {
                                        cambio = true;
                                    }
                                    entidad.idgenericoindice = papel.idOrigenUpt;
                                    entidad.tablaindice = papel.tablaUpt;
                                    break;
                            }
                               if(cambio)
                            {
                                entidad.idgenericoindice = papel.idOrigenUpt;
                                entidad.tablaindice = papel.tablaUpt;
                                entidad.referenciaindice = papel.referenciaTpt;
                                if (string.IsNullOrEmpty(entidad.referenciaindice))
                                {
                                    entidad.referenciaindice = "Pendiente";
                                }
                                _context.Entry(entidad).State = EntityState.Modified;
                                _context.SaveChanges();
                            }
                            modelo.guardadoBase = true;
                            //Reordenar((int)modelo.idindice);
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

        public static void UpdateModeloReodenar(IndiceModelo modelo)
        {
            string commandString = string.Empty;
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        commandString = String.Format("UPDATE sgpt.indices SET ordenindice = {0} WHERE idindice={1};", modelo.ordenindice, modelo.idindice);
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
                MessageBox.Show("exception en actualizar el orden: \n"+ commandString+"\n" + e);
                modelo.guardadoBase = false;
            }
        }
        public static bool CopiarModelo(IndiceModelo modelo)
        {
            throw new NotImplementedException();
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
                            string commandString = String.Format("UPDATE sgpt.indices SET estadoindice = 'B' WHERE idindice={0};", id);
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
                            MessageBox.Show("Exception en borrar registro \n" + e);
                        return false;
                    }
                    return result;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool DeleteBorradoLogico(ObservableCollection<IndiceModelo> lista)
        {
            if (lista.Count > 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        foreach (IndiceModelo item in lista)
                        {
                            string commandString = String.Format("UPDATE sgpt.indices SET estadoindice = 'B' WHERE idindice={0};", item.idindice);
                            commandString = MetodosModelo.ordenConversionToSQL(commandString);
                            _context.Database.ExecuteSqlCommand(commandString);
                            _context.SaveChanges();
                        }
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

        public static int DeleteByRangeForTC(int id)
        {
            //id es de carpeta para borrar todos los registros
            int result = 0;
            if (id != 0)
            {
                try
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("DELETE FROM sgpt.indices WHERE idtcindice={0};", id);
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
                        MessageBox.Show("Exception en borrar registro del detalle de programa: \n" + e);
                    return -1;
                }
                return result;
            }
            else
            {
                return result;
            }
        }
        public static int DeleteBorradoLogicoByRangeForTC(int id)
        {
            //id es de carpeta para borrar todos los registros
            int result = 0;
            if (!(id == 0))
            {
                    try
                    {
                        using (_context = new SGPTEntidades())
                        {
                            string commandString = String.Format("UPDATE sgpt.indices SET estadoindice = 'B' WHERE idtcindice={0};", id);
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
                            MessageBox.Show("Exception en borrar registro del detalle de programa: \n" + e);
                        return -1;
                    }
                    return result;
            }
            else
            {
                return result;
            }
        }

        public static bool DeleteBorradoLogico(string id, Boolean actualizar)
        {
            throw new NotImplementedException();
        }
        public static void Delete(int id)
        {
            throw new NotImplementedException();
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
                        //Borrado del catalogos
                            string commandString = String.Format("DELETE FROM sgpt.indices WHERE idindice={0};", id);
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
                    MessageBox.Show("Exception en borrar registro del detalle : \n" + e);
                }
                return false;
            }
        }

        public static bool Delete(string id, Boolean actualizar)
        {
            throw new NotImplementedException();
        }

        public static List<IndiceModelo> GetAll()
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var lista = _context.indices.Select(entidad =>
                    new IndiceModelo
                    {
                        idindice = entidad.idindice,
                        idmr = entidad.idmr,
                        idpapeles = entidad.idpapeles,
                        idmaf = entidad.idmaf,
                        idencargo = entidad.idencargo,
                        idprograma = entidad.idprograma,
                        indidindice = entidad.indidindice,
                        descripcionindice = entidad.descripcionindice,
                        ordenindice = entidad.ordenindice,
                        referenciaindice = entidad.referenciaindice,
                        obligatorioindice = entidad.obligatorioindice,
                        sistemaindice = entidad.sistemaindice,
                        estadoindice = entidad.estadoindice,
                        idteiindice = entidad.idteiindice,
                        IsSelected = false,
                        idgenericoindice = entidad.idgenericoindice,
                        tablaindice = entidad.tablaindice,
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenindice).Where(x => x.estadoindice == "A").ToList();
                    //La ordena por el idPrograma notar la notacion
                    if (lista == null)
                    {
                        return new List<IndiceModelo>();
                    }
                    else
                    {
                        return lista;
                    }
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de Plantilla Indice Modelo " + e.Message);
                }
                return null;
            }
        }

        public static IndiceModelo GetRegistro(int? idindice)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.indices.Select(entidad =>
                    new IndiceModelo
                    {
                        idindice = entidad.idindice,
                        idmr = entidad.idmr,
                        idpapeles = entidad.idpapeles,
                        idmaf = entidad.idmaf,
                        idencargo = entidad.idencargo,
                        idprograma = entidad.idprograma,
                        indidindice = entidad.indidindice,
                        descripcionindice = entidad.descripcionindice,
                        ordenindice = entidad.ordenindice,
                        referenciaindice = entidad.referenciaindice,
                        obligatorioindice = entidad.obligatorioindice,
                        sistemaindice = entidad.sistemaindice,
                        estadoindice = entidad.estadoindice,
                        idteiindice=entidad.idteiindice,
                        idtcindice=entidad.idtcindice,
                        IsSelected=false,
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.idindice == idindice).Where(x => x.estadoindice == "A").FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del cliente " + e.Message);
                }
                return null;
            }
        }
        public static IndiceModelo GetRegistro(string idindice)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    var registro = _context.indices.Select(entidad =>
                    new IndiceModelo
                    {
                        idindice = entidad.idindice,
                        idmr = entidad.idmr,
                        idpapeles = entidad.idpapeles,
                        idmaf = entidad.idmaf,
                        idencargo = entidad.idencargo,
                        idprograma = entidad.idprograma,
                        indidindice = entidad.indidindice,
                        descripcionindice = entidad.descripcionindice,
                        ordenindice = entidad.ordenindice,
                        referenciaindice = entidad.referenciaindice,
                        obligatorioindice = entidad.obligatorioindice,
                        sistemaindice = entidad.sistemaindice,
                        estadoindice = entidad.estadoindice,
                        idtcindice=entidad.idtcindice,
                        idteiindice=entidad.idteiindice,
                        IsSelected=false,
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).Where(x => x.idindice.ToString() == idindice).Where(x => x.estadoindice == "A").FirstOrDefault();
                    return registro;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("No pudo recuperarse el registro del cliente \n" + e);
                }
                return null;
            }
        }

        //Filtra y elimina el registro detallado para efectos de seleccion
        public static List<IndiceModelo> GetAll(int? idTcm, int? idIndice)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    //fuente: http://stackoverflow.com/questions/21038960/linq-query-to-convert-string-to-datetime
                    var DateQuery = _context.indices.ToList().Where(x => x.estadoindice == "A" && x.idtcindice == idTcm && x.idindice != idIndice).Select(entidad => new IndiceModelo
                    {
                        idindice = entidad.idindice,
                        idmr = entidad.idmr,
                        idpapeles = entidad.idpapeles,
                        idmaf = entidad.idmaf,
                        idencargo = entidad.idencargo,
                        idprograma = entidad.idprograma,
                        indidindice = entidad.indidindice,
                        descripcionindice = entidad.descripcionindice,
                        ordenindice = entidad.ordenindice,
                        referenciaindice = entidad.referenciaindice,
                        obligatorioindice = entidad.obligatorioindice,
                        sistemaindice = entidad.sistemaindice,
                        estadoindice = entidad.estadoindice,
                        idtcindice = entidad.idtcindice,
                        idteiindice = entidad.idteiindice,
                        IsSelected = false,
                        idgenericoindice = entidad.idgenericoindice,
                        tablaindice = entidad.tablaindice,
                        descripciontei = entidad.tipoelementoindice.descripciontei,
                        tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                        {
                            id = entidad.tipoelementoindice.idtei,
                            descripcion = entidad.tipoelementoindice.descripciontei,
                            imagen = entidad.tipoelementoindice.imagentet,
                            sistema = entidad.tipoelementoindice.sistematei,
                            estado = entidad.tipoelementoindice.estadotei
                        }
                        //Lista filtrada de elementos que fueron eliminados
                    }).OrderBy(o => o.ordenindice);
                    var resultado = DateQuery.ToList();
                    foreach (IndiceModelo item in resultado)
                    {
                        item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordenindice);
                        item.descripcionindice = item.ordenDhPresentacion + "-" + item.descripcionindice;
                        if (item.indidindice != null)
                        {
                            for (int i = 0; i < resultado.Count; i++)
                            {
                                if (resultado[i].idindice == item.indidindice)
                                {
                                    item.indiceModeloPadre = resultado[i];
                                    item.indiceModeloPadre = resultado[i];
                                    item.ordenindicePadre = (decimal)resultado[i].ordenindice;
                                    item.descripcionPresentacionPadre = resultado[i].descripcionindice;
                                    i = resultado.Count;
                                }
                            }
                        }

                    }
                    //Agregando registro para efectos de lista
                    IndiceModelo registroAdicional = new IndiceModelo();
                    registroAdicional.descripcionindice = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                    registroAdicional.idindice = 0;//Se adiciona para facilitar accesibilidad al usuario
                    registroAdicional.ordenindice = 0;
                    registroAdicional.descripciontei = "Ninguno";
                    resultado.Insert(0, registroAdicional);
                    return resultado.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible al elaboracion de lista \n" + e);
                IndiceModelo registroAdicional = new IndiceModelo();
                registroAdicional.descripcionindice = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                registroAdicional.idindice = 0;//Se adiciona para facilitar accesibilidad al usuario
                registroAdicional.ordenindice = 0;
                registroAdicional.descripciontei = "Ninguno";
                var lista = new ObservableCollection<IndiceModelo>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }


        #region Busqueda duplicados
        //Verifica si el registro existe dentro de los eliminados
        public static bool FindTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public static int FindTextoReturnId(string texto)
        {
            throw new NotImplementedException();
        }

        public static int FindTextoReturnIdBorrados(string texto)
        {
            throw new NotImplementedException();

        }

        public static bool UpdateBorradoModelo(IndiceModelo modelo, bool actualizar)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Limpieza de valores
        //Verifica si el registro existe dentro de los eliminados
        public static IndiceModelo Clear(IndiceModelo modelo)
        {
            throw new NotImplementedException();
        }
        public IndiceModelo()
        {
                        idindice = 0;
                        idmr = 0;
                        idpapeles = 0;
                        idmaf = 0;
                        idencargo = 0;
                        idprograma = 0;
                        indidindice = 0;
                        descripcionindice = string.Empty;
                        ordenindice = 1;
                        referenciaindice = string.Empty;
                        obligatorioindice = false;
                        sistemaindice = false;
                        estadoindice = "A";
                        idtcindice = 0;
                        idteiindice = 0;
                        descripciontei = string.Empty;
                        IsSelected = false;
                //Carga de  entidades
        }


        public IndiceModelo(index comun, index origen)
        {

            idindice = 0;
            idmr = 0;
            idpapeles = 0;
            idmaf = 0;
            idencargo = comun.idencargo;
            idprograma = 0;
            indidindice = 0;
            descripcionindice = origen.descripcionindice;
            ordenindice = origen.ordenindice;
            referenciaindice = string.Empty;
            obligatorioindice =origen.obligatorioindice;
            sistemaindice = false;
            estadoindice = "A";
            idtcindice =origen.idtcindice;
            idteiindice = origen.idteiindice;
            descripciontei = string.Empty;
            IsSelected = false;
        }

        public IndiceModelo(TipoCarpetaModelo currentCarpeta)
        {
            idindice = 0;
            idmr = 0;
            idpapeles = 0;
            idmaf = 0;
            idencargo = 0;
            idprograma = 0;
            indidindice = 0;
            descripcionindice = string.Empty;
            ordenindice = 1;
            referenciaindice = string.Empty;
            obligatorioindice = false;
            sistemaindice = false;
            estadoindice = "A";
            idtcindice = currentCarpeta.id;
            idteiindice = 0;
            descripciontei = string.Empty;
            IsSelected = false;
        }

        public IndiceModelo(TipoCarpetaModelo currentCarpeta, EncargoModelo currentEncargo) : this(currentCarpeta)
        {
            idindice = 0;
            idmr = 0;
            idpapeles = 0;
            idmaf = 0;
            idencargo = currentEncargo.idencargo;
            idprograma = 0;
            indidindice = 0;
            descripcionindice = string.Empty;
            ordenindice = 1;
            referenciaindice = string.Empty;
            obligatorioindice = false;
            sistemaindice = false;
            estadoindice = "A";
            idtcindice = currentCarpeta.id;
            idteiindice = 0;
            descripciontei = string.Empty;
            IsSelected = false;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public static int EvaluarBorrar(int idEncargo)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    int? resultado = (from p in _context.indices
                                            where p.idencargo == idEncargo && p.estadoindice == "A" && string.IsNullOrEmpty(p.referenciaindice)
                                            select p).Count();

                    //string commandString = String.Format("SELECT COUNT(*) FROM sgpt.indices WHERE idencargo={0} AND estadoindice='A' AND referenciaindice IS NOT NULL;", idEncargo);
                    //var respuesta = commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                    //commandString = MetodosModelo.ordenConversionToSQL(commandString);  _context.Database.ExecuteSqlCommand(commandString);
                    if (resultado != null)
                    {
                        if (resultado == -1)
                        {
                            resultado = 0;
                        }
                    }
                    else
                    {
                        resultado = 0;
                    }
                    return (int) resultado;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No pudo recuperarse el registro del cliente \n" + e);
                return -2;
            }
        }

        public static index IndiceConversion(index comun, index origen)
        {
            var tablaDestino = new index
            {
                    idindice = 0,
                    //idmr = 0,
                    //idpapeles = 0,
                    //idmaf = 0,
                    idencargo = comun.idencargo,
                    //idprograma = 0,
                    //indidindice = 0,
                    descripcionindice = origen.descripcionindice,
                    ordenindice = origen.ordenindice,
                    //referenciaindice = string.Empty,
                    obligatorioindice = origen.obligatorioindice,
                    sistemaindice = false,
                    estadoindice = "A",
                    idtcindice = origen.idtcindice,
                    idteiindice=origen.idteiindice,
            };

            return tablaDestino;
        }

        public static index IndiceConversion(index comun, detalleplantillaindice origen)
        {
            var tablaDestino = new index
            {
                idindice = 0,
                //idmr = entidad.idmr,
                //idpapeles = entidad.idpapeles,
                //idmaf = entidad.idmaf,
                idencargo = comun.idencargo,
                //idprograma = entidad.idprograma,
                //indidindice = entidad.indidindice,
                descripcionindice = origen.descripciondpi,
                ordenindice = (decimal)origen.ordendpi,
                //referenciaindice = entidad.referenciaindice,
                obligatorioindice = origen.obligatoriodpi,
                sistemaindice = false,
                estadoindice = "A",
                idtcindice = comun.idtcindice,
                idteiindice=origen.idtei
            };

            return tablaDestino;
        }

        public static int InsertbyImportacionByRange(ObservableCollection<index> lista, UsuarioModelo usuarioModelo)
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
                            "SELECT pg_catalog.setval(pg_get_serial_sequence('sgpt.indices', 'idindice'), (SELECT MAX(idindice) FROM sgpt.indices) + 1);");
                            sincronizar = true;
                        }
                        try
                        {
                            _context.indices.AddRange(lista);
                            _context.SaveChanges();
                            result = 1;//éxito completo
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show("Exception en insertar listado detalle : \n" + e);
                            try
                            {
                                foreach (index item in lista)
                                {
                                    _context.indices.Add(item);
                                    _context.SaveChanges();
                                }
                                result = 1;
                            }
                            catch
                            {
                                MessageBox.Show("Exception en insertar listado detalle : \n" + e);
                                result = 4;
                            }

                        }
                        //El detalle se incorporará posteriormente
                        return result;//éxito
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception en insertar registro de detalle : \n" + e);
                    return result;
                    throw;
                }
            }
            else
            {
                return result;
            }
        }

        public static bool UpdateModeloByImportacion(index modelo)
        {
            try
            {
                if (!(modelo == null))
                {
                    using (_context = new SGPTEntidades())
                    {
                        string commandString = String.Format("UPDATE sgpt.indices SET indidindice = {0} WHERE idindice = {1};", modelo.indidindice, modelo.idindice);
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
                MessageBox.Show("Exception en insertar actualizacion  del principal : \n" + e);
                throw;
            }
        }

        public static List<index> GetAllCapaDatos(int? idencargotc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.indices WHERE idencargo={0} AND estadoindice = 'A' ORDER BY ordenindice;", idencargotc);

                    var lista = _context.indices.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<index> temporal = new ObservableCollection<index>(lista);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                MessageBox.Show("No fue posible la elaboracion de la lista \n" + e);
                index registroAdicional = new index();
                registroAdicional.idindice = 0;
                registroAdicional.descripcionindice = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<index>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }

        public static List<index> GetAllCapaDatosByTipoCarpeta(int? idtcindice)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                    string commandString = String.Format("SELECT * FROM sgpt.indices WHERE estadoindice = 'A' AND idtcindice={0} ORDER BY ordenindice;",idtcindice);

                    var lista = _context.indices.SqlQuery(commandString);
                    //var lista = _context.catalogocuentas.Where(entidad => (entidad.idsc == idSc && entidad.estadocc == "A"));
                    ObservableCollection<index> temporal = new ObservableCollection<index>(lista);
                    return temporal.ToList();
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("No fue posible la elaboracion de la lista \n" + e);
                index registroAdicional = new index();
                registroAdicional.idindice = 0;
                registroAdicional.descripcionindice = "Ninguno";//Se adiciona para facilitar accesibilidad al usuario
                var lista = new ObservableCollection<index>();
                lista.Add(registroAdicional);
                return lista.ToList();
            }
        }


        public static ObservableCollection<IndiceModelo> GetAllByIdTC(int idTc)
        {
            try
            {
                using (_context = new SGPTEntidades())
                {
                     var listaInicial = _context.indices.Select(entidad =>
                     new IndiceModelo
                     {
                         idindice = entidad.idindice,
                         idmr = entidad.idmr,
                         idpapeles = entidad.idpapeles,
                         idmaf = entidad.idmaf,
                         idencargo = entidad.idencargo,
                         idprograma = entidad.idprograma,
                         indidindice = entidad.indidindice,
                         descripcionindice = entidad.descripcionindice,
                         ordenindice = entidad.ordenindice,
                         referenciaindice = entidad.referenciaindice,
                         obligatorioindice = entidad.obligatorioindice,
                         sistemaindice = entidad.sistemaindice,
                         estadoindice = entidad.estadoindice,
                         idteiindice=entidad.idteiindice,
                         imagentet=entidad.tipoelementoindice.imagentet,
                         idtcindice=entidad.idtcindice,
                         guardadoBase=true,
                         IsSelected=false,
                         idgenericoindice=entidad.idgenericoindice,
                         tablaindice=entidad.tablaindice,
                         descripciontei=entidad.tipoelementoindice.descripciontei,
                         tipoElementoIndiceModelo = new TipoElementoIndiceModelo
                         {
                             id = entidad.tipoelementoindice.idtei,
                             descripcion = entidad.tipoelementoindice.descripciontei,
                             imagen = entidad.tipoelementoindice.imagentet,
                             sistema = entidad.tipoelementoindice.sistematei,
                             estado = entidad.tipoelementoindice.estadotei
                         },
                         //Lista filtrada de elementos que fueron eliminados
                     }).OrderBy(o => o.ordenindice).Where(x => x.estadoindice == "A" && x.idtcindice == idTc).ToList();
                    //La ordena por el idPrograma notar la notacion
                    List<IndiceModelo> lista = RegeneraOrdenSubRegistros(listaInicial);
                    int i = 1;
                    foreach (IndiceModelo item in lista)
                    {
                        item.idCorrelativo = i;
                        i++;
                        //item.guardadoBase = true;
                        item.IsSelected = false;
                        //item.ordenDhPresentacion = MetodosModelo.ordenConversion(item.ordenindice);
                    }
                    //lista.ForEach(c => c.guardadoBase = true);
                    return new ObservableCollection<IndiceModelo>(lista);
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                {
                    MessageBox.Show("Exception en elaboracion de lista de indice \n" + e);
                }
                return new ObservableCollection<IndiceModelo>();
            }
        }




        public static bool Delete(ObservableCollection<IndiceModelo> lista)
        {
            try
            {
                if (lista.Count > 0)
                {
                    using (_context = new SGPTEntidades())
                    {
                        detallebalance entidadTemporal = new detallebalance();
                        foreach (IndiceModelo item in lista)
                        {
                            //Buscar registro
                            string commandString = String.Format("DELETE FROM sgpt.indices WHERE idindice={0};", item.idindice);
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
            }
        }
        #endregion

        #region generacion del orden

        public static List<IndiceModelo> RegeneraOrdenSubRegistros(List<IndiceModelo> listaDetalleHerramienta)
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
                    ObservableCollection<IndiceModelo> listaHijos = new ObservableCollection<IndiceModelo>();
                    ObservableCollection<IndiceModelo> listaPadres = new ObservableCollection<IndiceModelo>();
                    ObservableCollection<IndiceModelo> listaDetalle = new ObservableCollection<IndiceModelo>();

                    foreach (IndiceModelo itemDetalle in listaDetalleHerramienta)
                    {
                        guardar = false;
                        if (itemDetalle.indidindice == null)
                        {
                            if (itemDetalle.ordenindice != contador)
                            {
                                guardar = true;
                            }

                            //Se asigna el orden a los principales
                            itemDetalle.ordenindice = contador;
                            //itemDetalle.ordendpPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenindice);
                            itemDetalle.ordenDhPresentacion = MetodosModelo.ordenConversion(itemDetalle.ordenindice);
                            itemDetalle.descripcionPresentacion = itemDetalle.descripcionindice;
                            if (guardar)
                            {
                                IndiceModelo.UpdateModeloReodenar(itemDetalle);
                                //Se modifica el orden para mantener una estandarizacion
                            }
                            listaDetalle.Add(itemDetalle);
                            if (listaDetalleHerramienta.Where(x => x.indidindice == itemDetalle.idindice).Count() > 0)
                            {
                                listaPadres.Add(itemDetalle);
                            }
                            contador = contador + 10;
                        }
                    }
                    //Corrigiendo los sub-procedimientos
                    bool salir = false;
                    decimal factor = (decimal)0.1;
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
                            listaHijos = new ObservableCollection<IndiceModelo>(listaDetalleHerramienta.Where(x => x.indidindice == listaPadres[0].idindice));
                            if (listaHijos.Count > 0)
                            {
                                //Hay hijos
                                contador = (decimal)listaPadres[0].ordenindice;
                                //factor = MetodosModelo.factorPadreIndice(item.descripciontei);
                                int j = 1;
                                guardar = false;
                                foreach (IndiceModelo hijo in listaHijos)
                                {
                                    //Es un hijo
                                    if (hijo.ordenindice != Decimal.Add((decimal)contador, factor * j))
                                    {
                                        guardar = true;
                                    }
                                    hijo.ordenindicePadre = contador;
                                    hijo.ordenindice = Decimal.Add((decimal)contador, factor * j);
                                    hijo.ordenDhPresentacion = MetodosModelo.ordenConversion(hijo.ordenindice);
                                    hijo.descripcionPresentacion = desplazar + hijo.descripcionindice;

                                    hijo.indiceModeloPadre = listaPadres[0]; ;
                                    hijo.descripcionPresentacionPadre = hijo.indiceModeloPadre.descripcionindice;

                                    j++;
                                    if (guardar)
                                    {
                                        IndiceModelo.UpdateModeloReodenar(hijo);
                                        //Se modifica el orden para mantener una estandarizacion
                                    }
                                    //Agregar a la lista
                                    listaDetalle.Add(hijo);
                                    //Verificar que no tenga hijos
                                    if (listaDetalleHerramienta.Where(x => x.indidindice == hijo.idindice).Count() > 0)
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
                    return listaDetalle.OrderBy(x => x.ordenindice).ToList();
                }
                catch (Exception e)
                {
                    //Captura de fallo en la insercion
                    if (e.Source != null)
                        MessageBox.Show("Exception generar el orden \n" + e);
                    return listaDetalleHerramienta.OrderBy(x => x.ordenindice).ToList();
                    throw;
                }
            }
        }

        public static ObservableCollection<index> GetAllCapaDatosByEncargo(int idEncargo)
        {
            string commandString = string.Empty;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    commandString = String.Format("SELECT * FROM sgpt.indices WHERE estadoindice = 'A' AND idencargo={0} ORDER BY idtcindice;", idEncargo);
                    var lista = _context.indices.SqlQuery(commandString).ToList();
                    ObservableCollection<index> temporal = new ObservableCollection<index>(lista);
                    return temporal;
                }
            }
            catch (Exception e)
            {
                //Captura de fallo en la insercion
                if (e.Source != null)
                    MessageBox.Show("Exception en elaboracion de lista \n " + commandString + "  \n " + e);
                return new ObservableCollection<index>();
            }
        }

        public static int ContarSubRegistros(int? id)
        {
            int elementos = 0;
            try
            {
                using (_context = new SGPTEntidades())
                {
                    elementos = _context.indices.Where(x => x.indidindice == id && x.estadoindice == "A").Count();
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
                    elementos = _context.indices.Where(x => x.estadoindice == "A").Count();
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
    }

}



